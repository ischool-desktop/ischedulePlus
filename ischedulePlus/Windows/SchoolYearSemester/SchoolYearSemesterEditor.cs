using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using DevComponents.DotNetBar.Controls;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 單一時間表（含時間表分段）編輯器
    /// 需要補上資料行驗證訊息。
    /// </summary>
    public partial class SchoolYearSemesterEditor : UserControl, IContentEditor<SchoolYearSemesterPackage>
    {
        private const string DateTimeFormat = "yyyy/MM/dd";  
        private AccessHelper mHelper = Utility.AccessHelper;
        private SchoolYearSemesterPackage mSchoolYearSemesterPackage;
        //private TimeTableBusyEditor mTimeTableBusyEditor = null;
        private List<Period> mPeriods = new List<Period>();
        private string mEditorName = string.Empty;
        private bool mIsDirty = false;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public SchoolYearSemesterEditor()
        {
            InitializeComponent();
        }

        #region private functions

        #endregion

        #region IContentEditor<List<TimeTableSec>> 成員

        /// <summary>
        /// 初始化
        /// </summary>
        public void Prepare()
        {

        }

        /// <summary>
        /// 是否被修改
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return mIsDirty;
            }
            set
            {
                mIsDirty = value;

                lblName.Text = mIsDirty ? mEditorName + "<font color='red'>（已修改）</font>" : mEditorName;
            }
        }


        /// <summary>
        /// 取得或設定編輯內容
        /// </summary>
        public SchoolYearSemesterPackage Content
        {
            get
            {
                #region 取得年級學期開始及結束日期
                XElement elmGradeYears = new XElement("GradeYears");

                foreach (DataGridViewRow Row in grdGradeYear.Rows)
                {
                    string GradeYear = "" + Row.Cells[0].Value;
                    string StartDate = "" + Row.Cells[1].Value;
                    string EndDate = "" + Row.Cells[2].Value;

                    if (!string.IsNullOrEmpty(GradeYear) && 
                        !string.IsNullOrEmpty(StartDate) && 
                        !string.IsNullOrEmpty(EndDate))
                    {
                        XElement elmGradeYear = new XElement("GradeYear");
                        elmGradeYear.SetAttributeValue("GradeYear", GradeYear);
                        elmGradeYear.SetAttributeValue("StartDate", StartDate);
                        elmGradeYear.SetAttributeValue("EndDate", EndDate);

                        elmGradeYears.Add(elmGradeYear);
                    }
                }

                mSchoolYearSemesterPackage.SchoolYearSemesterDate.GradeYearStartEndDate = elmGradeYears.ToString();
                mSchoolYearSemesterPackage.SchoolYearSemesterDate.StartDate = dteStart.Value;
                mSchoolYearSemesterPackage.SchoolYearSemesterDate.EndDate = dteEnd.Value;
                #endregion

                #region 取得假日
                XElement elmHolidays = new XElement("Holidays");

                foreach(DataGridViewRow Row in grdHoliday.Rows)
                {
                    string strDate = "" + Row.Cells[0].Value;
                    string strPeriods = "" + Row.Cells[1].Value;

                    if (!string.IsNullOrEmpty(strDate))
                    {
                        XElement elmHoliday = new XElement("Holiday", strDate);
                        elmHoliday.SetAttributeValue("Periods", strPeriods);
                        elmHolidays.Add(elmHoliday);
                    }
                }

                mSchoolYearSemesterPackage.SchoolYearSemesterDate.Holidays = "" + elmHolidays;
                #endregion

                return mSchoolYearSemesterPackage;
            }
            set
            {
                mSchoolYearSemesterPackage = value;

                if (value.SchoolYearSemesterDate != null)
                {
                    dteStart.Value = value.SchoolYearSemesterDate.StartDate;
                    dteEnd.Value = value.SchoolYearSemesterDate.EndDate;

                    grdGradeYear.Rows.Clear();

                    if (!string.IsNullOrEmpty(value.SchoolYearSemesterDate.GradeYearStartEndDate))
                    {
                        XElement elmGradeYears = XElement.Load(new StringReader(value.SchoolYearSemesterDate.GradeYearStartEndDate));

                        foreach (XElement elmGradeYear in elmGradeYears.Elements("GradeYear"))
                        {
                            string strGradeYear = elmGradeYear.AttributeText("GradeYear");
                            string strStartDate = elmGradeYear.AttributeText("StartDate");
                            string strEndDate = elmGradeYear.AttributeText("EndDate");

                            grdGradeYear.Rows.Add(strGradeYear, strStartDate, strEndDate);
                        }
                    }

                    grdHoliday.Rows.Clear();

                    if (!string.IsNullOrEmpty(value.SchoolYearSemesterDate.Holidays))
                    {
                        XElement elmHolidays = XElement.Load(new StringReader(value.SchoolYearSemesterDate.Holidays));

                        foreach (XElement elmHoliday in elmHolidays.Elements("Holiday"))
                        {
                            string strHoliday = elmHoliday.Value;
                            string strPeriods = elmHoliday.AttributeText("Periods");

                            if (string.IsNullOrWhiteSpace(strPeriods))
                                strPeriods = "整天";

                            int RowIndex = grdHoliday.Rows.Add(strHoliday,strPeriods);

                            DataGridViewButtonXCell Cell = grdHoliday.Rows[RowIndex].Cells[1] as DataGridViewButtonXCell;
                       }
                    }

                    mEditorName = value.SchoolYearSemesterDate.SchoolYear + " " + value.SchoolYearSemesterDate.Semester;
                    lblName.Text = mEditorName;
                }
            }
        }

        /// <summary>
        /// 將自己傳回
        /// </summary>
        public UserControl Control { get { return this; } }

        /// <summary>
        /// 驗證表單資料是否合法
        /// </summary>
        /// <returns></returns>
        public new bool Validate()
        {
            foreach (DataGridViewRow Row in grdGradeYear.Rows)
            {
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    if (!string.IsNullOrEmpty(Cell.ErrorText))
                        return false;
                }
            }

            foreach (DataGridViewRow Row in grdHoliday.Rows)
            {
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    if (!string.IsNullOrEmpty(Cell.ErrorText))
                        return false;
                }
            }

            if (dteEnd.Value < dteStart.Value)
            {
                return false;
            }

            return true;
        }

        public void SetTitle(string name)
        {
            lblName.Text = name;
        }
        #endregion

        private void grdHoliday_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colHoliday.Index)
            {
                DataGridViewCell cell = grdHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = "" + cell.Value;
                cell.ErrorText = "";
                if (string.IsNullOrEmpty(value)) //沒有資料就不作任何檢查。
                    return;

                DateTime dt;
                if (!DateTime.TryParse(value, out dt))
                {
                    cell.ErrorText = "日期格式錯誤。";
                }
                else
                {
                    cell.Value = dt.ToString(DateTimeFormat);
                }
            }
        }

        private void grdGradeYear_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colStartDate.Index || 
                e.ColumnIndex == colEndDate.Index)
            {
                DataGridViewCell cell = grdGradeYear.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = "" + cell.Value;
                cell.ErrorText = "";
                if (string.IsNullOrEmpty(value)) //沒有資料就不作任何檢查。
                    return;

                DateTime dt;
                if (!DateTime.TryParse(value, out dt))
                {
                    cell.ErrorText = "日期格式錯誤。";
                }
                else
                {
                    cell.Value = dt.ToString(DateTimeFormat);
                }
            }
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dteEnd.Value < dteStart.Value)
            {
                errorProvider1.SetError(dteEnd, "結束日期必須大於開始日期！");
            }
            else
            {
                errorProvider1.SetError(dteEnd, string.Empty);
            }
        }

        private void grdHoliday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string strValue = "" + grdHoliday.Rows[e.RowIndex].Cells[1].Value;

                frmPeriodsSetting PeriodsSettings = new frmPeriodsSetting(strValue);

                if (PeriodsSettings.ShowDialog() == DialogResult.OK)
                {
                    grdHoliday.Rows[e.RowIndex].Cells[1].Value = PeriodsSettings.Periods;
                }
            }
        }

        private void grdHoliday_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string CellValue = "" + grdHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                DateTime? Date = K12.Data.DateTimeHelper.Parse(CellValue);

                if (Date.HasValue)
                {
                    if (Date < mSchoolYearSemesterPackage.SchoolYearSemesterDate.StartDate ||
                        Date > mSchoolYearSemesterPackage.SchoolYearSemesterDate.EndDate)
                    {
                        //grdHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "日期需介於開始及結束日期間！";
                    }
                    else
                    {
                        //grdHoliday.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                    }
                }
            }
        }
    }
}