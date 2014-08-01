using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using Aspose.Cells;
using Campus.Report;
using FISCA.Data;
using ischedulePlus.Properties;
using K12.Data.Configuration;
using ReportHelper;

namespace ischedulePlus
{
    /// <summary>
    /// 調代明細統計報表
    /// </summary>
    public partial class frmExchangeReplaceSatReport : FISCA.Presentation.Controls.BaseForm
    {
        private QueryHelper mHelper = Utility.QueryHelper;
        private List<string> mPeriods = new List<string>();
        private List<string> mSelectedCommonPeriods = new List<string>();
        private List<string> mSelectedOtherPeriods = new List<string>();

        /// <summary>
        /// 建構式
        /// </summary>
        public frmExchangeReplaceSatReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 載入節次列表
        /// </summary>
        private void LoadPeriodList()
        {
            mSelectedCommonPeriods.Clear();
            mSelectedOtherPeriods.Clear();

            #region 取得所有節次清單，若是有儲存設定則加入儲存設定，否則加入所有節次到一般統計
            Campus.Configuration.ConfigData configPeriod = Campus.Configuration.Config.User["請假代課統計表"];

            string PeriodOption = configPeriod["PeriodOption"];

            if (!string.IsNullOrWhiteSpace(PeriodOption))
            {
                XElement Element = XElement.Load(new StringReader(PeriodOption));

                foreach (XElement elmPeriodOption in Element.Elements("PeriodOption"))
                {
                    PeriodOption vPeriodOption = new PeriodOption(elmPeriodOption);

                    if (vPeriodOption.Checked)
                    {
                        if (vPeriodOption.Type.Equals("一般"))
                            mSelectedCommonPeriods.Add(vPeriodOption.Period);
                        else if (vPeriodOption.Type.Equals("其他"))
                            mSelectedOtherPeriods.Add(vPeriodOption.Period);
                    }
                }
            }
            else
            {
                List<string> PeriodList = Calendar.Instance.GetPeriodList();
                mSelectedCommonPeriods.AddRange(PeriodList);
            }
            #endregion
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExchangeReplaceMonthReport_Load(object sender, EventArgs e)
        {
            #region 將日期預設為本月的開始日期及結束日期
            dateStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateEnd.Value = dateStart.Value.AddMonths(1).AddDays(-1);
            #endregion

            #region 設定樣版
            lnkPrintSetup.Click += (vsender, ve) =>
            {
                frmExchangeReplaceSatTemplateConfig frmConfig = new frmExchangeReplaceSatTemplateConfig();

                //若設定儲存OK則重新載入節次清單
                if (frmConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LoadPeriodList();
            };
            #endregion

            //載入節次清單
            LoadPeriodList();
        }

        /// <summary>
        /// 選取其他節數
        /// </summary>
        public List<string> SelectedOtherPeriods
        {
            get
            {
                return mSelectedOtherPeriods;
            }
        }

        /// <summary>
        /// 選取一般節數
        /// </summary>
        public List<string> SelectedCommonPeriods
        {
            get
            {
                return mSelectedCommonPeriods;
            }
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
            bkwPrint.RunWorkerAsync(new List<object>(){
                dateStart.Value,
                dateEnd.Value,
                SelectedCommonPeriods,
                SelectedOtherPeriods}); 
        }

        private void bkwPrint_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FISCA.Presentation.MotherForm.SetStatusBarMessage("" + e.UserState, e.ProgressPercentage);
        }

        private void bkwPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> Arguments = e.Argument as List<object>;

            DateTime StartDate = ((DateTime)Arguments[0]).ToDayStart();
            DateTime EndDate = ((DateTime)Arguments[1]).ToDayEnd();
            List<string> CommonPeriods = Arguments[2] as List<string>;
            List<string> OtherPeriods = Arguments[3] as List<string>;

            Dictionary<string, List<DataSet>> result = new Dictionary<string, List<DataSet>>();

            DataSet DataSet = new DataSet("DataSection");

            result.Add("請假代課統計表", new List<DataSet>());

            result["請假代課統計表"].Add(DataSet);

            DataSet.Tables.Add(StartDate.ToShortDateString().ToDataTable("開始日期", "開始日期"));
            DataSet.Tables.Add(EndDate.ToShortDateString().ToDataTable("結束日期", "結束日期"));
            DataSet.Tables.Add(K12.Data.School.DefaultSchoolYear.ToDataTable("學年度", "學年度"));
            DataSet.Tables.Add(K12.Data.School.DefaultSemester.ToDataTable("學期", "學期"));
            DataSet.Tables.Add(StartDate.Month.ToDataTable("月份", "月份"));

            List<CalendarRecord> Records = Calendar.Instance.FindReplaceRecords(null, null, null,null,StartDate, EndDate);

            SatRecords vSatRecords = new SatRecords(CommonPeriods, OtherPeriods);

            foreach (CalendarRecord Record in Records)
                vSatRecords.Add(Record);

            DataSet.Tables.Add(vSatRecords.ToDataTable());

            e.Result = result;
        }

        private void bkwPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, List<DataSet>> result = e.Result as Dictionary<string, List<DataSet>>;

            FISCA.Presentation.MotherForm.SetStatusBarMessage("請假代課統計表產生完成");

            try
            {
                byte[] Byte = Properties.Resources.請假代課統計表; //將成績單先為預設

                #region 判斷是否用自訂範本，以及自訂範本是否有內容才套用
                Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["請假代課統計表"];
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

        /// <summary>
        /// 選取一般節次時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCommonPeriod_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //#region 將原本選取項目記憶起來
            //List<string> SelectedCommonPeriods = new List<string>();
            //List<string> SelectedOtherPeriods = new List<string>();

            //foreach (ListViewItem Item in lstCommonPeriod.Items)
            //    if (Item.Checked)
            //        SelectedCommonPeriods.Add(Item.Text);

            //foreach (ListViewItem Item in lstOtherPeriod.Items)
            //    if (Item.Checked)
            //        SelectedOtherPeriods.Add(Item.Text);
            //#endregion

            //lstOtherPeriod.Items.Clear();

            //#region 重新新增其他節次，去掉在一般節次中已有的才新增
            //foreach (string Period in mPeriods)
            //{
            //    if (!SelectedCommonPeriods.Contains(Period))
            //    {
            //        ListViewItem Item = new ListViewItem();
            //        Item.Name = Period;
            //        Item.Text = Period;

            //        if (SelectedOtherPeriods.Contains(Period))
            //            Item.Checked = true;

            //        lstOtherPeriod.Items.Add(Item);
            //    }
            //}
            //#endregion
        }

        /// <summary>
        /// 全選/全不選
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void chkSelect_CheckedChanged(object sender, EventArgs e)
        //{
        //    lstCommonPeriod.Items.Clear();
        //    foreach (string Period in mPeriods)
        //    {
        //        ListViewItem Item = new ListViewItem();
        //        Item.Text = Period;
        //        Item.Name = Period;
        //        Item.Checked = chkSelect.Checked;
        //        lstCommonPeriod.Items.Add(Item);
        //    }
        //}
    }
}