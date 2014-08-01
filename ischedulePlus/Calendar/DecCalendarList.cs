using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace ischedulePlus
{
    /// <summary>
    /// 行事曆列表
    /// </summary>
    public class DecCalendarList
    {
        /// <summary>
        /// 行事曆類別
        /// </summary>
        public CalendarType CalendarType { get; set; }

        /// <summary>
        /// 相關行事曆編號
        /// </summary>
        public string AssocID { get; set; }

        /// <summary>
        /// 實體資料來源
        /// </summary>
        public DataGridViewX DataGrid { get; set;}

        /// <summary>
        /// 是否正在更新
        /// </summary>
        public bool IsUpdating { get; set; }

        /// <summary>
        /// 建構式，傳入資料來源
        /// </summary>
        /// <param name="vDataSource"></param>
        public DecCalendarList(DataGridViewX vDataSource)
        {
            if (vDataSource == null)
                throw new NullReferenceException("資料來源為null");

            this.DataGrid = vDataSource;
            this.AssocID = string.Empty;
            this.IsUpdating = false;

            CalendarEvents.WeekChangeEvent +=CalendarEvents_WeekChangeEvent;
            CalendarEvents.ReplaceEvent += CalendarEvents_ReplaceEvent;
            CalendarEvents.ExchangeEvent += CalendarEvents_ExchangeEvent;

            ContextMenuStrip ContextMenu = new ContextMenuStrip();

            #region 停課
            ToolStripItem item停課 = ContextMenu.Items.Add("停課");
            item停課.Click +=item停課_Click;
            #endregion

            #region 修改日期(星期)
            ToolStripItem item修改日期 = ContextMenu.Items.Add("修改日期");
            item修改日期.Click += item修改日期_Click;
            #endregion

            #region 修改節次
            ToolStripItem item修改節次 = ContextMenu.Items.Add("修改節次");
            item修改節次.Click += item修改節次_Click;
            #endregion

            #region 修改教師
            ToolStripItem item修改教師 = ContextMenu.Items.Add("修改教師");
            item修改教師.Click += item修改教師_Click;
            #endregion

            ToolStripItem item修改場地 = ContextMenu.Items.Add("修改場地");
            item修改場地.Click += item修改場地_Click;

            #region 刪除
            ToolStripItem item刪除 = ContextMenu.Items.Add("刪除");
            item刪除.Click += item刪除_Click;
            #endregion

            DataGrid.ContextMenuStrip = ContextMenu;
        }



        #region private function
        /// <summary>
        /// 取得選取行事曆
        /// </summary>
        /// <returns></returns>
        private List<CalendarRecord> GetSelectedCalendars()
        {
            List<CalendarRecord> records = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in DataGrid.SelectedRows)
            {
                CalendarRecord record = Row.DataBoundItem as CalendarRecord;

                if (string.IsNullOrWhiteSpace(record.ReplaceID) &&
                   string.IsNullOrWhiteSpace(record.ExchangeID) &&
                   string.IsNullOrWhiteSpace(record.Delete))
                {
                    records.Add(record);
                }
            }

            return records;
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item刪除_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.DeleteCalendar(records);
        }

        /// <summary>
        /// 修改教師
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item修改教師_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdateTeacherName(records);
        }

        /// <summary>
        /// 修改節次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item修改節次_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdatePeriod(records);
        }

        /// <summary>
        /// 修改日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item修改日期_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdateDate(records);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item修改場地_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.UpdateClassroom(records);
        }

        /// <summary>
        /// 停課
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item停課_Click(object sender, EventArgs e)
        {
            List<CalendarRecord> records = GetSelectedCalendars();

            Utility.CancelCalendar(records);
        }

        /// <summary>
        /// 調課事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarEvents_ExchangeEvent(object sender, EventArgs e)
        {
            UpdateContent();
        }

        /// <summary>
        /// 代課事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarEvents_ReplaceEvent(object sender, EventArgs e)
        {
            UpdateContent();
        }

        /// <summary>
        /// 週次改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarEvents_WeekChangeEvent(object sender, CalendarEvents.WeekChangeEventArgs e)
        {
            if (e.Type.Equals(this.CalendarType) && 
                e.AssocID.Equals(this.AssocID))
            {
                UpdateContent();
            }
        }
        #endregion

        #region public function
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            this.DataGrid.DataSource = null;
        }

        /// <summary>
        /// 更新內容
        /// </summary>
        public void UpdateContent()
        {
            BackgroundWorker worker = new BackgroundWorker();

            CalendarBindingList records = new CalendarBindingList();

            worker.DoWork += (sender, e) =>
            {
                DateTime StartDate = SchoolYearSemesterOption.Instance.StartDate;
                DateTime EndDate = SchoolYearSemesterOption.Instance.EndDate;

                if (this.CalendarType.Equals(CalendarType.Teacher))
                {
                    Utility.GetTeacherCalendars(this.AssocID, StartDate, EndDate).ForEach(x => records.Add(x));
                }
                else if (this.CalendarType.Equals(CalendarType.Class))
                {
                    Utility.GetClassCalendars(this.AssocID, StartDate, EndDate).ForEach(x => records.Add(x));

                }
                else if (this.CalendarType.Equals(CalendarType.Classroom))
                {
                    Utility.GetPlaceCalendars(this.AssocID, StartDate, EndDate).ForEach(x => records.Add(x));
                }
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                this.DataGrid.DataSource = records;
                if (records.Count > 0)
                    this.DataGrid.Rows[0].Selected = false;
                this.IsUpdating = false;
            };

            this.IsUpdating = true;
            worker.RunWorkerAsync();
        }
        #endregion
    }
}