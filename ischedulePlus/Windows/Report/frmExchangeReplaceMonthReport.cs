using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Aspose.Cells;
using Campus.Report;
using ischedulePlus.Properties;
using K12.Data.Configuration;
using ReportHelper;

namespace ischedulePlus
{
    public partial class frmExchangeReplaceMonthReport : FISCA.Presentation.Controls.BaseForm
    {
        /// <summary>
        /// 請假代課明細表
        /// </summary>
        public frmExchangeReplaceMonthReport()
        {
            InitializeComponent();
        }

        private List<string> GetSelectedClassNames()
        {

            List<ClassEx> Classes = Calendar.Instance.Classes.Values.ToList();

            if (chkSH.Checked)
            {
                Classes = Classes.FindAll(x=>x.ClassCode.ToUpper().StartsWith("C"));

                return Classes.Select(x => x.ClassName).ToList();
            }
            else if (chkSHPro.Checked)
            {
                Classes = Classes.FindAll
                    (x => 
                        !(x.ClassCode.ToUpper().StartsWith("C") || x.ClassCode.ToUpper().StartsWith("Z"))
                    );

                return Classes.Select(x => x.ClassName).ToList();
            }
            else if (chkJH.Checked)
            {
                Classes = Classes.FindAll(x => x.ClassCode.ToUpper().StartsWith("Z"));

                return Classes.Select(x => x.ClassName).ToList();
            }
            
            return new List<string>();
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExchangeReplaceMonthReport_Load(object sender, EventArgs e)
        {
            #region 將日期設為本月的開始日期及結束日期
            dateStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateEnd.Value = dateStart.Value.AddMonths(1).AddDays(-1);
            #endregion

            #region 讀取樣版設定
            lnkPrintSetup.Click += (vsender, ve) =>
            {
                ConfigData config = K12.Data.School.Configuration["請假代課明細表"];

                if (config != null)
                {
                    int _useTemplateNumber = 0;
                    int.TryParse(config["TemplateNumber"], out _useTemplateNumber);

                    string customize = config["CustomizeTemplate"];
                    byte[] _buffer = Resources.請假代課明細表;

                    if (!string.IsNullOrEmpty(customize))
                        _buffer = Convert.FromBase64String(customize);

                    frmExchangeReplaceMonthemplateConfig frmConfig = new frmExchangeReplaceMonthemplateConfig(_buffer, _useTemplateNumber);

                    frmConfig.ShowDialog();
                }
            };
            #endregion
        }

        /// <summary>
        /// 列印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            BackgroundWorker bkwPrint = new BackgroundWorker();
            bkwPrint.WorkerReportsProgress = true;
            bkwPrint.DoWork += new DoWorkEventHandler(bkwPrint_DoWork);
            bkwPrint.ProgressChanged += new ProgressChangedEventHandler(bkwPrint_ProgressChanged);
            bkwPrint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkwPrint_RunWorkerCompleted);
            //將開始日期及結束日期傳入
            bkwPrint.RunWorkerAsync(new List<object>(){
                dateStart.Value,
                dateEnd.Value});
        }

        /// <summary>
        /// 進度改變
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bkwPrint_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FISCA.Presentation.MotherForm.SetStatusBarMessage("" + e.UserState, e.ProgressPercentage);
        }

        /// <summary>
        /// 列印中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bkwPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> Arguments = e.Argument as List<object>;

            DateTime StartDate = ((DateTime)Arguments[0]).ToDayStart();
            DateTime EndDate = ((DateTime)Arguments[1]).ToDayEnd();

            Dictionary<string, List<DataSet>> result = new Dictionary<string, List<DataSet>>();

            DataSet DataSet = new DataSet("DataSection");

            result.Add("請假代課明細表",new List<DataSet>());

            result["請假代課明細表"].Add(DataSet);

            #region 輸出開始日期、結束日期、月份及學年度學期
            DataSet.Tables.Add(StartDate.ToShortDateString().ToDataTable("開始日期","開始日期"));
            DataSet.Tables.Add(EndDate.ToShortDateString().ToDataTable("結束日期","結束日期"));
            DataSet.Tables.Add(StartDate.Month.ToDataTable("月份", "月份"));

            Tuple<string, string> SchoolYearSemester = Utility.GetSchoolYearSemester(StartDate);

            DataSet.Tables.Add(SchoolYearSemester.Item1.ToDataTable("學年度", "學年度"));
            DataSet.Tables.Add(SchoolYearSemester.Item2.ToDataTable("學期", "學期"));
            #endregion

            List<string> ClassNames = GetSelectedClassNames();

            //根據開始日期及結束日期取得代課記錄
            List<CalendarRecord> Records = Calendar.Instance.FindReplaceRecords(null, null,ClassNames, null,StartDate, EndDate);

            //新增代課明細集合
            AbsenceRecords vAbsenceRecords = new AbsenceRecords();

            foreach (CalendarRecord Record in Records)
            {
                vAbsenceRecords.Add(Record);
            }

            DataSet.Tables.Add(vAbsenceRecords.ToDataTable());

            e.Result = result;
        }

        private void bkwPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, List<DataSet>> result = e.Result as Dictionary<string, List<DataSet>>;

            FISCA.Presentation.MotherForm.SetStatusBarMessage("請假代課明細表產生完成");

            try
            {
                byte[] Byte = Properties.Resources.請假代課明細表; //將成績單先為預設

                #region 判斷是否用自訂範本，以及自訂範本是否有內容才套用
                ConfigData config = K12.Data.School.Configuration["請假代課明細表"];
                int _useTemplateNumber = 0;
                int.TryParse(config["TemplateNumber"], out _useTemplateNumber);
                string customize = config["CustomizeTemplate"];
                if (!string.IsNullOrEmpty(customize) && _useTemplateNumber == 1)
                    Byte = Convert.FromBase64String(customize);
                #endregion

                MemoryStream Stream = new MemoryStream(Byte);

                Workbook wb = ReportHelper.Report.Produce(result, Stream);

                foreach (Worksheet sheet in wb.Worksheets)
                    sheet.PageSetup.CenterHorizontally = true;

                string mSaveFilePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Reports\\請假代課明細表.xls";

                ReportSaver.SaveWorkbook(wb, mSaveFilePath);
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
                SmartSchool.ErrorReporting.ReportingService.ReportException(ve);
            }
        }

        /// <summary>
        /// 離開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
