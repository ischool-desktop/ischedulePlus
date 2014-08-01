using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using Campus.Report;
using FISCA.Presentation;
using ischedulePlus.Properties;
using K12.Data;
using K12.Data.Configuration;

namespace ischedulePlus
{
    /// <summary>
    /// 調代課通知單
    /// </summary>
    public partial class frmExchangeReplaceReport : FISCA.Presentation.Controls.BaseForm
    {
        //查詢結果
        private List<CalendarRecord> QueryResult = new List<CalendarRecord>();

        #region Private Property

        /// <summary>
        /// 取得開始日期時間
        /// </summary>
        private DateTime StartDateTime
        {
            get
            {
                DateTime StartDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterStartDate.StartOfWeek(DayOfWeek.Monday).ToDayStart();
                DateTime EndDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterEndDate.StartOfWeek(DayOfWeek.Monday).AddDays(6).ToDayStart();

                DateTime result = StartDate;

                //若有考慮日期則取得，否則回傳最小日期
                if (chkQueryByDate.Checked)
                {
                    DateTime value = dateStart.GetDateTime("", "", 0, 0);

                    if (value > StartDate && value < EndDate)
                        result = value;
                }

                dateStart.Value = result;

                return result;
            }
        }

        /// <summary>
        /// 取得結束日期時間
        /// </summary>
        private DateTime EndDateTime
        {
            get
            {
                DateTime StartDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterStartDate.StartOfWeek(DayOfWeek.Monday).ToDayStart();
                DateTime EndDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterEndDate.StartOfWeek(DayOfWeek.Monday).AddDays(6).ToDayStart();

                DateTime result = EndDate;

                //若有考慮日期則取得，否則回傳最大日期
                if (chkQueryByDate.Checked)
                {
                    DateTime value = dateEnd.GetDateTime("", "", 23, 59);

                    if (value > StartDate && value < EndDate)
                        result = value;
                }

                dateEnd.Value = result;

                return result;
            }
        }
        #endregion

        #region Public Property

        /// <summary>
        /// 列印型態
        /// </summary>
        public enum PrintType { Excel, EMail }

        /// <summary>
        /// 列印選擇
        /// </summary>
        public PrintType PrintChoice{ get; set; }

        /// <summary>
        /// 取得選取教師系統編號
        /// </summary>
        public List<string> TeacherNames
        {
            get
            {
                if (chkQueryByRole.Checked)
                    return cmbTeacher.GetTeacherNames();
                else
                    return new List<string>();
            }
        }

        /// <summary>
        /// 取得選取班級系統編號
        /// </summary>
        public List<string> ClassNames
        {
            get
            {
                if (chkQueryByRole.Checked)
                    return cmbClass.GetClassNames();
                else
                    return new List<string>();
            }
        }

        /// <summary>
        /// 選擇類別
        /// </summary>
        public string SelectedType
        {
            get
            {
                if (cmbTeacher.SelectedItem != null)
                    return "教師";
                else if (cmbClass.SelectedItem != null)
                    return "班級";
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 寄件者電子郵件
        /// </summary>
        public string SenderEMail { get; set; }

        /// <summary>
        /// 寄件者密碼
        /// </summary>
        public string SenderPassword { get; set; }

        /// <summary>
        /// 寄件副本
        /// </summary>
        public string MailCC { get; set; }

        /// <summary>
        /// 使用者選取的行事曆
        /// </summary>
        public List<CalendarRecord> SelectedCalendars { get; set; }

        /// <summary>
        /// 使用者選取的群組行事曆
        /// </summary>
        public Dictionary<string, List<CalendarRecord>> SelectedGroupCalendars { get; set; }
        #endregion

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public frmExchangeReplaceReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExchangeReplaceReport_Load(object sender, EventArgs e)
        {
            #region 將日期預設為本週的開始日期及結束日期
            dateStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            dateEnd.Value = dateStart.Value.AddDays(6);
            #endregion

            cmbClass.FillClass();
            cmbTeacher.FillTeacher();

            chkQueryByDate.CheckedChanged += (vsender, ve) => pnlQueryByDate.Enabled = chkQueryByDate.Checked;
            chkQueryByRole.CheckedChanged += (vsender, ve) => pnlQueryByResource.Enabled = chkQueryByRole.Checked;            


            //cmbClass.TextChanged += (vsender,ve)=> cmbClass.SelectedItem = null;
            //cmbTeacher.TextChanged += (vsender,ve)=> cmbTeacher.SelectedItem = null;
        }

        /// <summary>
        /// 查詢調代課記錄
        /// </summary>
        private void Query()
        {
            if (cmbClass.SelectedItem == null && cmbTeacher.SelectedItem == null)
            {
                MessageBox.Show("請選擇班級或教師！");
                return;
            }

            btnEMail.Enabled = SelectedType.Equals("教師");

            QueryResult = new List<CalendarRecord>();

            //查詢代課者的代課記錄
            DateTime dteStart = StartDateTime;
            DateTime dteEnd = EndDateTime;
            List<string> SelectedClassNames = ClassNames;
            List<string> SelectedTeacherNames = TeacherNames;

            if (chkExchangeReplace.Checked || chkExchange.Checked)
            {
                #region 找出調課記錄
                List<CalendarRecord> ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null,
                null, null, null, null, null);

                List<CalendarRecord> ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                null, null, null, null, null,
                dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null);

                Dictionary<string, CalendarRecord> Records = new Dictionary<string, CalendarRecord>();

                foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                    if (!Records.ContainsKey(ExchangeRecord.UID))
                        Records.Add(ExchangeRecord.UID, ExchangeRecord);

                foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                    if (!Records.ContainsKey(ExchangeRecord.UID))
                        Records.Add(ExchangeRecord.UID, ExchangeRecord);

                QueryResult.AddRange(Records.Values);
                #endregion
            }

            if (chkExchangeReplace.Checked || chkReplace.Checked)
            {
                //找出代課記錄
                List<CalendarRecord> RepRecords = Calendar.Instance.FindReplaceRecords(
                    SelectedTeacherNames, null, ClassNames, null, dteStart, dteEnd);

                List<CalendarRecord> AbsRecords = Calendar.Instance.FindReplaceRecords(
                    null, SelectedTeacherNames, ClassNames, null, dteStart, dteEnd);

                Dictionary<string, CalendarRecord> Records = new Dictionary<string, CalendarRecord>();

                foreach (CalendarRecord RepRecord in RepRecords)
                    if (!Records.ContainsKey(RepRecord.UID))
                        Records.Add(RepRecord.UID, RepRecord);

                foreach (CalendarRecord AbsRecord in AbsRecords)
                    if (!Records.ContainsKey(AbsRecord.UID))
                        Records.Add(AbsRecord.UID, AbsRecord);

                QueryResult.AddRange(Records.Values);

                //找出取消代課記錄
                List<CalendarRecord> CancelReplaceRecord = Calendar.Instance.FindCancelReplaceRecords(
                    TeacherNames, 
                    ClassNames,
                    null, 
                    StartDateTime, 
                    EndDateTime);

                QueryResult.AddRange(CancelReplaceRecord);
            }

            //將代課記錄繫結到畫面上
            grdResult.BindExchangeCalendar(QueryResult);
        }

        /// <summary>
        /// 查詢調代課記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        } 

        /// <summary>
        /// 報表選項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportOption_Click(object sender, EventArgs e)
        {
            #region 讀取 Preference
            ConfigData configExchagne = K12.Data.School.Configuration["調課通知單"];
            ConfigData configReplace = K12.Data.School.Configuration["代課通知單"];

            if (configExchagne != null && configReplace!=null)
            {
                int _useTemplateNumber = 0;
                int.TryParse(configExchagne["TemplateNumber"], out _useTemplateNumber);

                string customize = configExchagne["CustomizeTemplate"];
                byte[] _buffer = Resources.調課通知單;

                if (!string.IsNullOrEmpty(customize))
                    _buffer = Convert.FromBase64String(customize);

                int _useReplaceTemplateNumber = 0;
                int.TryParse(configReplace["TemplateNumber"], out _useReplaceTemplateNumber);

                string customizeReplace = configReplace["CustomizeTemplate"];
                byte[] _bufferReplace = Resources.代課通知單;

                if (!string.IsNullOrEmpty(customizeReplace))
                    _bufferReplace = Convert.FromBase64String(customizeReplace);

                frmTemplateConfig frmConfig = new frmTemplateConfig(
                    _buffer, 
                    _useTemplateNumber,
                    _bufferReplace,
                    _useReplaceTemplateNumber);

                frmConfig.ShowDialog();
            }
            #endregion
        }

        /// <summary>
        /// 匯出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            grdResult.Export("調代課通知單查詢");
        }

        /// <summary>
        /// 列印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            PrintChoice = PrintType.Excel;

            Print();
        }

        /// <summary>
        /// 寄發電子郵件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEMail_Click(object sender, EventArgs e)
        {
            PrintChoice = PrintType.EMail;
            Print();
        }

        /// <summary>
        /// 列印
        /// </summary>
        private void Print()
        {
            #region 初步選擇資料
            if (grdResult.Rows.Count == 0)
            {
                MessageBox.Show("查詢無資料！");
                return;
            }
            #endregion

            if (PrintChoice == PrintType.EMail)
            {
                frmEMailConfirm MailConfirm = new frmEMailConfirm();

                if (MailConfirm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SenderEMail = MailConfirm.SenderEMail;
                    SenderPassword = MailConfirm.SenderPasssword;
                    MailCC = MailConfirm.MailCC;
                    PrintChoice = PrintType.EMail;
                }
                else
                    return;
            }

            string ResourceType = SelectedType;                        //取得選取班級或教師
            string StartDate = StartDateTime.ToShortDateString();      //取得開始日期
            string EndDate = EndDateTime.ToShortDateString();          //取得結束日期
            SelectedCalendars = grdResult.GetSelectedCalendars();      //取得行事曆

            BackgroundWorker bkwPrint = new BackgroundWorker();
            bkwPrint.WorkerReportsProgress = true;
            bkwPrint.DoWork += new DoWorkEventHandler(bkwPrint_DoWork);
            bkwPrint.ProgressChanged += new ProgressChangedEventHandler(bkwPrint_ProgressChanged);
            bkwPrint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkwPrint_RunWorkerCompleted);
            bkwPrint.RunWorkerAsync(new List<object>(){
                ResourceType,
                StartDate,
                EndDate,
                SelectedCalendars}); 
        }

        private void bkwPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PrintChoice == PrintType.EMail)
                SendEMail(e);
            else if (PrintChoice == PrintType.Excel)
                SendExcel(e);
        }

        private void SendExcel(RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, HTMLReport> vresult = e.Result as Dictionary<string, HTMLReport>;

            Dictionary<string,List<DataSet>> result = vresult.ToReportHelper();

            FISCA.Presentation.MotherForm.SetStatusBarMessage("調代課通知單產生完成");

            try
            {
                byte[] ByteExchange = Properties.Resources.調課通知單;
                byte[] ByteReplace = Properties.Resources.代課通知單;

                #region 判斷是否用自訂範本，以及自訂範本是否有內容才套用
                //ConfigData config = K12.Data.School.Configuration["調代課通知單"];
                //int _useTemplateNumber = 0;
                //int.TryParse(config["TemplateNumber"], out _useTemplateNumber);
                //string customize = config["CustomizeTemplate"];
                //if (!string.IsNullOrEmpty(customize) && _useTemplateNumber == 1)
                //    Byte = Convert.FromBase64String(customize);
                #endregion

                MemoryStream Stream = new MemoryStream(ByteExchange);

                Workbook wb = ReportHelper.Report.Produce(result, Stream);

                foreach (Worksheet sheet in wb.Worksheets)
                    sheet.PageSetup.CenterHorizontally = true;

                string mSaveFilePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Reports\\調代課通知單.xls";

                ReportSaver.SaveWorkbook(wb, mSaveFilePath);
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
                SmartSchool.ErrorReporting.ReportingService.ReportException(ve);
            } 
        }

        private void SendEMail(RunWorkerCompletedEventArgs e)
        {
            //建立SMTP連線
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            try
            {
                //建立傳送電子郵件認證
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential(
                this.SenderEMail,
                this.SenderPassword);

                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = cred;
                smtp.Port = 587;
            }
            catch (Exception ve)
            {
                FISCA.ErrorBox.Show("認證寄件者資訊發生錯誤！", ve);
            }

            Dictionary<string, HTMLReport> result = e.Result as Dictionary<string, HTMLReport>;

            K12.Data.Teacher.RemoveByIDs(result.Keys);

            List<TeacherRecord> Teachers = K12.Data.Teacher.SelectByIDs(result.Keys);

            List<MailMessage> MailMessages = new List<MailMessage>();
            List<string> NoMailTeachers = new List<string>();

            foreach (string Key in result.Keys)
            {
                TeacherRecord vTeacher = Teachers.Find(x => x.ID.Equals(Key));

                if (!string.IsNullOrEmpty(vTeacher.Email))
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine("<html>");
                    strBuilder.AppendLine("<header><title></title></header>");
                    strBuilder.AppendLine("<body>");
                    strBuilder.AppendLine(result[Key].ToString());
                    strBuilder.AppendLine("</body>");
                    strBuilder.AppendLine("</html>");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.To.Add(vTeacher.Email);
                    if (!string.IsNullOrEmpty(MailCC))
                        mail.To.Add(MailCC);
                    mail.Subject = "調代課通知單 (" + DateTime.Now.ToString("yyyy/MM/dd") + ")"; ;

                    mail.From = new System.Net.Mail.MailAddress(this.SenderEMail);
                    mail.IsBodyHtml = true;
                    mail.Body = strBuilder.ToString();

                    MailMessages.Add(mail);
                }
                else
                    NoMailTeachers.Add(string.IsNullOrEmpty(vTeacher.Nickname) ? vTeacher.Name : vTeacher.Name + "(" + vTeacher.Nickname + ")");
            }

            if (NoMailTeachers.Count > 0)
                if (MessageBox.Show("以下教師「" + string.Join(",", NoMailTeachers.ToArray()) + "」沒有電子郵件，是否繼續傳送？", "寄發電子郵件提醒", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    return;

            try
            {
                //實際寄送電子郵件
                MailMessages.ForEach(x => smtp.Send(x));

                //寄送電子郵件Log
                Calendar.Instance.LogEMail(SelectedCalendars, Teachers);
            }
            catch (Exception ve)
            {
                FISCA.ErrorBox.Show("寄送電子郵件發生錯誤！", ve);
            }

            //記錄電子郵件列表
            MotherForm.SetStatusBarMessage("調代課通知單寄發完成。");
        }

        private void bkwPrint_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FISCA.Presentation.MotherForm.SetStatusBarMessage("" + e.UserState, e.ProgressPercentage);
        }

        private void bkwPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> Arguments = e.Argument as List<object>;

            string ResourceType = "" + Arguments[0];
            string StartDateTime = "" + Arguments[1];
            string EndDateTime = "" + Arguments[2];
            List<CalendarRecord> vCalendars = Arguments[3] as List<CalendarRecord>;
            //處理進度計數器
            double progress = 0;

            BackgroundWorker bkw = ((BackgroundWorker)sender);

            bkw.ReportProgress(1);

            Dictionary<string, HTMLReport> vResults = new Dictionary<string, HTMLReport>();

            foreach (CalendarRecord vCalendar in vCalendars)
            {
                Dictionary<string, string> ResourceIDNames = new Dictionary<string, string>();

                if (ResourceType.Equals("教師"))
                {
                    if (vCalendar.ExchangeCalendar != null)
                    {
                        ResourceIDNames.Add(vCalendar.TeacherName, vCalendar.TeacherName);
                        ResourceIDNames.Add(vCalendar.ExchangeCalendar.TeacherName, vCalendar.ExchangeCalendar.TeacherName);
                    }
                    else
                    {
                        ResourceIDNames.Add(vCalendar.TeacherName, vCalendar.TeacherName);
                        ResourceIDNames.Add(vCalendar.AbsTeacherName, vCalendar.AbsTeacherName);
                    }
                }
                else if (ResourceType.Equals("班級"))
                    ResourceIDNames.Add(vCalendar.ClassName,vCalendar.ClassName);

                foreach (string ResourceID in ResourceIDNames.Keys)
                {
                    if (!vResults.ContainsKey(ResourceID))
                    {
                        vResults.Add(ResourceID, new HTMLReport());
                        vResults[ResourceID].ResourceType = ResourceType;
                        vResults[ResourceID].ResourceName = ResourceIDNames[ResourceID];
                        vResults[ResourceID].StartDateTime = StartDateTime;
                        vResults[ResourceID].EndDateTime = EndDateTime;
                    }
                }

                if (vCalendar.ExchangeCalendar != null)
                {
                    HTMLReportRecord SrcRecord = new HTMLReportRecord();

                    SrcRecord.Type = "調";
                    SrcRecord.Date = vCalendar.StartDateTime.ToShortDateString();
                    SrcRecord.Weekday = vCalendar.Weekday;
                    SrcRecord.Period = vCalendar.Period;
                    SrcRecord.TeacherName = vCalendar.TeacherName;
                    SrcRecord.TeacherID = vCalendar.TeacherID;
                    SrcRecord.Subject = vCalendar.FullSubject;
                    SrcRecord.Classroom = vCalendar.ClassroomName;
                    SrcRecord.ReplaceTeacherName = string.Empty;
                    SrcRecord.ReplaceTeahcerID = string.Empty;

                    HTMLReportRecord DesRecord = new HTMLReportRecord();

                    DesRecord.Type = "調";
                    DesRecord.Date = vCalendar.ExchangeCalendar.StartDateTime.ToShortDateString();
                    DesRecord.Weekday = vCalendar.ExchangeCalendar.Weekday;
                    DesRecord.Period = vCalendar.ExchangeCalendar.Period;
                    DesRecord.TeacherName = vCalendar.ExchangeCalendar.TeacherName;
                    DesRecord.TeacherID = vCalendar.ExchangeCalendar.TeacherID;
                    DesRecord.Subject = vCalendar.ExchangeCalendar.FullSubject;
                    DesRecord.Classroom = vCalendar.ExchangeCalendar.ClassroomName;
                    DesRecord.ReplaceTeacherName = string.Empty;
                    DesRecord.ReplaceTeahcerID = string.Empty;

                    foreach (string ResourceID in ResourceIDNames.Keys)
                    {
                        vResults[ResourceID].Records.Add(SrcRecord);
                        vResults[ResourceID].Records.Add(DesRecord);
                    }
                }
                else
                {
                    HTMLReportRecord Record = new HTMLReportRecord();

                    Record.Type = "代";
                    Record.Date = vCalendar.StartDateTime.ToShortDateString();
                    Record.Weekday = vCalendar.Weekday;
                    Record.Period = vCalendar.Period;
                    Record.TeacherName = vCalendar.AbsTeacherName;
                    Record.TeacherID = vCalendar.AbsTeacherID;
                    Record.Subject = vCalendar.FullSubject;
                    Record.Classroom = vCalendar.ClassroomName;
                    Record.ReplaceTeacherName = vCalendar.TeacherName;
                    Record.ReplaceTeahcerID = vCalendar.TeacherID;

                    foreach (string ResourceID in ResourceIDNames.Keys)
                        vResults[ResourceID].Records.Add(Record);
                }

                bkw.ReportProgress((int)(++progress * 100.0d / grdResult.SelectedRows.Count), "調代課通知單產生中...");
            }

            e.Result = vResults;
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            dateEnd.Value = dateStart.Value.AddDays(6);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintNew_Click(object sender, EventArgs e)
        {
            //#region 初步選擇資料
            //if (grdResult.Rows.Count == 0)
            //{
            //    MessageBox.Show("請選擇一筆調代資料");
            //    return;
            //}

            //string ResourceType = SelectedType;                        //取得選取班級或教師
            //string StartDate = StartDateTime.ToShortDateString();      //取得開始日期
            //string EndDate = EndDateTime.ToShortDateString();          //取得結束日期
            //SelectedCalendars = grdResult.GetSelectedCalendars();      //取得行事曆

            //SelectedGroupCalendars = grdResult.GetSelectedGroupCalendars(QueryResult);

            //ExchangeReplaceReport.Instance.Print(SelectedGroupCalendars,StartDate,EndDate);

            //ExchangeReplaceReport.Instance.Print(SelectedCalendars);
            //#endregion
        }
    }
}