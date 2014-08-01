using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using FISCA.Authentication;
using FISCA.Data;
using FISCA.Presentation;

namespace ischedulePlus
{
    /// <summary>
    /// 調代課查詢畫面
    /// </summary>
    public partial class frmTeacherNoBusyQuery : FISCA.Presentation.Controls.BaseForm
    {
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private CardPanelEx pnlCard = new CardPanelEx();

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public frmTeacherNoBusyQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 選取節次
        /// </summary>
        public List<string> SelectedPeriods
        {
            get
            {
                List<string> result = new List<string>();

                if (chkQueryPeriod.Checked)
                {
                    foreach (Control vContorl in pnlCard.Controls)
                    {
                        CheckBoxX box = vContorl as CheckBoxX;

                        if (box.Checked)
                            result.Add(box.Text);
                    }
                }

                return result;               
            }
        }


        /// <summary>
        /// 載入表單事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTeacherNoBusyQuery_Load(object sender, EventArgs e)
        {
            #region 將日期預設為本週的開始日期及結束日期
            dateStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            dateEnd.Value = dateStart.Value.AddDays(6);
            #endregion

            chkQueryByDate.CheckedChanged += (vsender, ve) => pnlQueryByDate.Enabled = chkQueryByDate.Checked;
            chkQueryPeriod.CheckedChanged += (vsender, ve) => pnlQueryPeriod.Enabled = chkQueryPeriod.Checked;

            CalendarEvents.WeekChangeEvent += (vsender, ve) => Query();

            pnlCard.CardWidth = 80;
          
            pnlCard.Controls.Clear();

            pnlCard.Dock = DockStyle.Fill;
            pnlCard.AutoScroll = true;

            List<string> Periods = Utility.GetPeriodList();

            for (int i = 0; i < Periods.Count; i++)
            {
                CheckBoxX box = new CheckBoxX();
                box.Text = Periods[i];
                box.ForeColor = Color.FromArgb(22, 66, 113);
                box.Checked = true;
                box.Size = new System.Drawing.Size(80, 23);
                pnlCard.Controls.Add(box);
            }

            pnlQueryPeriod.Controls.Add(pnlCard);

            if (!(DSAServices.AccountType == AccountType.Greening))
                MotherForm.SetStatusBarMessage("您使用非ischool Account登入，無法查詢其他部別課表。");
        }

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

                    if (value > StartDate && value<EndDate)
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

        private void grdResult_SelectionChanged(object sender, EventArgs e)
        {
            bool IsDisplay = true;

            foreach (DataGridViewRow Row in grdResult.SelectedRows)
            {
                CalendarRecord record = Row.Tag as CalendarRecord;

                if (!string.IsNullOrWhiteSpace(record.Delete))
                {
                    IsDisplay = false;
                    break;
                }
            }

            if (IsDisplay)
                grdResult.ContextMenuStrip = menuCancel;
            else
                grdResult.ContextMenuStrip = null;
        }
      
        /// <summary>
        /// 查詢無課教師
        /// </summary>
        private void QueryFreeTime()
        {
            Dictionary<string, Teacher> ReplaceWhos = new Dictionary<string, Teacher>();

            Calendar.Instance.RefreshTeachers();

            #region 複製所有教師及教授科目
            foreach (string TeacherName in Calendar.Instance.Teachers.Keys)
            {
                if (!ReplaceWhos.ContainsKey(TeacherName))
                    ReplaceWhos.Add(TeacherName, Calendar.Instance.Teachers[TeacherName]);
            }
            #endregion

            try
            {
                #region 尋找出區間內的行事曆
                DateTime dteStart = StartDateTime;
                DateTime dteEnd = EndDateTime;
                List<CalendarRecord> Calendars = Calendar.Instance.Find(
                    null,
                    null,
                    null,
                    dteStart, 
                    dteEnd,
                    false);

                Calendars = Calendars
                    .FindAll(x => this.SelectedPeriods.Contains(x.Period));
                #endregion

                foreach (CalendarRecord vCalendar in Calendars)
                {
                    string TeacherName = vCalendar.TeacherName;

                    if (ReplaceWhos.ContainsKey(TeacherName))
                        ReplaceWhos.Remove(TeacherName);
                }

                //將教師排序
                List<Teacher> SortTeachers = ReplaceWhos
                    .Values
                    .ToList()
                    .SortByCode();

                //將可代課教師顯示在畫面上
                grdResult.BindTeacher(SortTeachers); 
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        private void Query()
        {
            try
            {
                grdResult.SelectionChanged -= grdResult_SelectionChanged;
                grdResult.ContextMenuStrip = null;

                QueryFreeTime();
            }
            catch (OutOfMemoryException e)
            {
                MessageBox.Show("您查詢的資料量過大，造成記憶體不足，建議您以較小的區間進行篩選！");
                SmartSchool.ErrorReporting.ReportingService.ReportException(e);
            }
            catch (Exception e)
            {
                MessageBox.Show("查詢資料時發生錯誤，詳細訊息如下：" + e.Message);
                SmartSchool.ErrorReporting.ReportingService.ReportException(e);
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 匯出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            grdResult.Export("無課教師查詢");
        }
        
        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            dateEnd.Value = dateStart.Value.AddDays(6);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateEnd.Value < dateStart.Value)
            {
                MessageBox.Show("結束日期不能小於開始日期！");
                dateEnd.Value = dateStart.Value.AddDays(6);
            }
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            //frmPeriodsSetting PeriodsSetting = new frmPeriodsSetting(string.Empty);

            //if (PeriodsSetting.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            //{
            //    lblPeriods.Text = PeriodsSetting.Periods;
            //}
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control vContorl in pnlCard.Controls)
            {
                CheckBoxX box = vContorl as CheckBoxX;

                box.Checked = chkSelectAll.Checked;
            } 
        }
    }
}