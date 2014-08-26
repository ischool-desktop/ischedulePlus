using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class frmCalendarQuery : FISCA.Presentation.Controls.BaseForm
    {
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private CardPanelEx pnlCard = new CardPanelEx();

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public frmCalendarQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 載入表單事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExchangeReplaceQuery_Load(object sender, EventArgs e)
        {
            #region 將日期預設為本週的開始日期及結束日期
            dateStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            dateEnd.Value = dateStart.Value.AddDays(6);
            #endregion

            lstClass.FillClass();
            cmbTeacher.FillTeacher();
            cmbClassroom.FillClassroom();

            chkQueryByDate.CheckedChanged += (vsender, ve) => pnlQueryByDate.Enabled = chkQueryByDate.Checked;
            chkQueryByRole.CheckedChanged += (vsender, ve) => pnlQueryByResource.Enabled = chkQueryByRole.Checked;
            chkQueryPeriod.CheckedChanged += (vsender, ve) => pnlQueryPeriod.Enabled = chkQueryPeriod.Checked;
            chkQueryByClass.CheckedChanged += (vsender, ve) => pnlClass.Enabled = chkQueryByClass.Checked;

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
                if (chkQueryByClass.Checked)
                    return lstClass.GetClassNames();
                else
                    return new List<string>();
            }
        }

        /// <summary>
        /// 取得選取場地名稱
        /// </summary>
        public List<string> ClassroomNames
        {
            get
            {
                if (chkQueryByRole.Checked)
                    return cmbClassroom.GetClassroomNames();
                else
                    return new List<string>();
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
        /// 查詢行事曆，已確認OK
        /// </summary>
        private void QueryCalendar()
        {
            DateTime dteStart = StartDateTime;
            DateTime dteEnd = EndDateTime;
            List<string> SelectedTeacherNames = TeacherNames;
            List<string> SelectedClassNames = ClassNames;
            List<string> SelectedClassroomNames = ClassroomNames;

            List<CalendarRecord> records = Calendar.Instance.Find(
                SelectedTeacherNames,
                SelectedClassNames,
                SelectedClassroomNames,
                dteStart, 
                dteEnd,
                null);

            if (chkQueryPeriod.Checked)
            {
                List<string> SelectedPeriods = new List<string>();

                foreach (Control vContorl in pnlCard.Controls)
                {
                    CheckBoxX box = vContorl as CheckBoxX;

                    if (box.Checked)
                        SelectedPeriods.Add(box.Text);
                }

                records = records
                    .FindAll(x => SelectedPeriods.Contains(x.Period));
            }

            grdResult.BindCalendar(records);
            grdResult.ContextMenuStrip = menuCalendar;
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

                QueryCalendar();
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
            grdResult.Export("行事曆查詢");
        }


        /// <summary>
        /// 取得選取行事曆
        /// </summary>
        /// <returns></returns>
        private List<CalendarRecord> GetSelectedCalendars()
        {
            List<CalendarRecord> records = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in grdResult.SelectedRows)
            {
                CalendarRecord vCalendar = Row.Tag as CalendarRecord;

                if (string.IsNullOrEmpty(vCalendar.ExchangeID) &&
                    string.IsNullOrEmpty(vCalendar.ReplaceID) &&
                    !vCalendar.Cancel)
                    records.Add(vCalendar);
            }

            return records;
        }

        private void 鎖定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.LockCalendar(records,true);
        }

        private void 解除鎖定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.LockCalendar(records, false);
        }

        private void 停課ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.CancelCalendar(records);
        }

        private void 上課ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in grdResult.SelectedRows)
            {
                CalendarRecord vCalendar = Row.Tag as CalendarRecord;

                if (vCalendar.Cancel)
                    records.Add(vCalendar);
            }

            #region 檢查記錄是否有被相依，為代課或調課記錄相依，若有的話就移除
            if (records.Count>0)
            {
                QueryHelper helper = Utility.QueryHelper;

                string strIDList = string.Join(",",records.Select(x=>x.UID).ToArray());

                DataTable table = helper.Select("select exchange_id,replace_id from $scheduler.course_calendar where exchange_id in ("+ strIDList +") or replace_id in ("+strIDList+")");

                List<string> IDs = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    string ExchangeID = row.Field<string>("exchange_id");
                    string ReplaceID = row.Field<string>("replace_id");

                    if (!string.IsNullOrEmpty(ExchangeID) && !IDs.Contains(ExchangeID))
                        IDs.Add(ExchangeID);

                    if (!string.IsNullOrEmpty(ReplaceID) && !IDs.Contains(ReplaceID))
                        IDs.Add(ReplaceID);
                }

                List<CalendarRecord> RemoveList = new List<CalendarRecord>();

                foreach (CalendarRecord vCalendar in records)
                    if (IDs.Contains(vCalendar.UID))
                        RemoveList.Add(vCalendar);

                RemoveList.ForEach(x => records.Remove(x));
            }
            #endregion

            Calendar.Instance.Cancel(records, false);

            Query();
        }

        /// <summary>
        /// 取消調代記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否確認取消共" + grdResult.SelectedRows.Count + "筆調代記錄？", "取消確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                List<string> UnCancelUIDs = new List<string>();
                List<string> DeleteUIDs = new List<string>();

                List<CancelCourseCalendar> CancelRecords = new List<CancelCourseCalendar>();

                foreach(DataGridViewRow Row in grdResult.SelectedRows)
                {
                    CalendarRecord record = Row.Tag as CalendarRecord;

                    CancelCourseCalendar CancelCalendar = new CancelCourseCalendar(record);
                     
                    CancelRecords.Add(CancelCalendar);

                    //代課記錄
                    if (record.ExchangeCalendar == null)
                    {
                        UnCancelUIDs.Add(record.ReplaceID);
                        DeleteUIDs.Add(record.UID);
                    }
                    //調課記錄
                    else
                    {
                        UnCancelUIDs.Add(record.ExchangeID);
                        UnCancelUIDs.Add(record.ExchangeCalendar.ExchangeID);
                        DeleteUIDs.Add(record.UID);
                        DeleteUIDs.Add(record.ExchangeCalendar.UID);
                    } 
                }

                //儲存取消的行事曆記錄
                CancelRecords.SaveAll();

                //先將行事曆啟用
                Calendar.Instance.Cancel(UnCancelUIDs, false);

                //將行事曆刪除
                Calendar.Instance.Delete(DeleteUIDs);

                //重新執行查詢
                Query();
            }
        }

        /// <summary>
        /// 修改節次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改節次ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdatePeriod(records);
        }

        /// <summary>
        /// 修改教師
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改教師ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdateTeacherName(records);
        }

        /// <summary>
        /// 修改日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdateDate(records);
        }

        /// <summary>
        /// 刪除課程行事曆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.DeleteCalendar(records);
        }

        /// <summary>
        /// 修改場地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改場地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdateClassroom(records);
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

        private void btnCheckDuplicate_Click(object sender, EventArgs e)
        {
            Query();
        }
    }
}