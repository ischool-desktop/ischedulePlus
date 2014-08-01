using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Authentication;
using FISCA.Presentation;
using K12.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 調代課畫面
    /// </summary>
    public partial class frmExchangeReplace : FISCA.Presentation.Controls.BaseForm
    {
        private DateTime dateCalendarStart;
        private DateTime dateCalendarEnd;
        private Teacher mReplaceTeacher;
        private CalendarRecord mExchangeRecord;
        private List<CalendarRecord> mSelectedCalendars;
        private Subjects mSelectedSubjects;
        private string mSelectedTeacherName;

        /// <summary>
        /// 初始化
        /// </summary>
        public frmExchangeReplace(string TeacherName)
        {
            InitializeComponent();

            mSelectedTeacherName = TeacherName;
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReplace_Load(object sender, EventArgs e)
        {
            this.TitleText = mSelectedTeacherName + " 教師調代課" ; 

            #region 將日期預設為本週的開始日期及結束日期
            dateQueryStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            dateQueryEnd.Value = dateQueryStart.Value.AddDays(6);

            dateExchangeStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            dateExchangeEnd.Value = dateExchangeStart.Value.AddDays(6);

            dateCalendarStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            dateCalendarEnd = dateCalendarStart.AddDays(6);

            lblCalendarRange.Text = K12.Data.DateTimeHelper.ToDisplayString(dateCalendarStart) + "~" + K12.Data.DateTimeHelper.ToDisplayString(dateCalendarEnd);                
            #endregion

            //取得所有教師清單
            //1.先依照學年度學期對照表取得開始日期及結束日期
            //2.若無對照表則依照目前日期加減前後兩週
            Calendar.Instance.RefreshTeachers();

            if (!(DSAServices.AccountType == AccountType.Greening))
                MotherForm.SetStatusBarMessage("您使用非ischool Account登入，無法查詢其他部別課表。");
        }

        /// <summary>
        /// 查詢行事曆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryCalendar_Click(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 查詢
        /// </summary>
        private void Query()
        {
            #region 根據教師系統編號、開始日期及結束日期尋找行事曆

            DateTime StartDate = dateQueryStart.Value.ToDayStart();
            DateTime EndDate = dateQueryEnd.Value.ToDayEnd();
            List<string> TeacherNames = new List<string>() { mSelectedTeacherName };
            List<CalendarRecord> Calendars = Calendar.Instance.Find(
                TeacherNames,
                null,
                null,
                StartDate,
                EndDate,
                null);
            #endregion

            #region 將行事曆顯示在畫面上
            grdCourseCalendar.Rows.Clear();

            foreach (CalendarRecord vCalendar in Calendars)
            {
                int AddRowIndex = grdCourseCalendar.Rows.Add();
                DataGridViewRow Row = grdCourseCalendar.Rows[AddRowIndex];
                Row.Tag = vCalendar;
                Row.FillColor(vCalendar);

                grdCourseCalendar.Rows[AddRowIndex].SetValues(
                    K12.Data.DateTimeHelper.ToDisplayString(vCalendar.StartDateTime),
                    vCalendar.Weekday,
                    vCalendar.Period,
                    vCalendar.ClassName,
                    vCalendar.FullSubject,
                    vCalendar.ClassroomName);
            }
            #endregion
        }

        /// <summary>
        /// 顯示調課行事曆
        /// </summary>
        /// <param name="Records"></param>
        private void DisplayExchangeCalendars(int ExchangeCount,List<CalendarRecord> Records)
        {
            //Records = Records
            //    .OrderBy(x => x.Weekday)
            //    .ThenBy(x=>x.Period)
            //    .ToList();

            //Dictionary<string, List<CalendarRecord>> GroupCalendarsRecords = new Dictionary<string, List<CalendarRecord>>();

            ////根據相同的星期、科目及教師進行分類
            //foreach (CalendarRecord vCalendar in Records)
            //{
            //    string Key = vCalendar.Weekday + "," + vCalendar.FullSubject + "," + vCalendar.TeacherName;

            //    if (!GroupCalendarsRecords.ContainsKey(Key))
            //        GroupCalendarsRecords.Add(Key, new List<CalendarRecord>());

            //    GroupCalendarsRecords[Key].Add(vCalendar);
            //}

            //List<string> RemoveKeys = new List<string>();

            ////檢查節次是否連續
            //foreach (string Key in GroupCalendarsRecords.Keys)
            //{
            //    List<CalendarRecord> GroupCalendars = GroupCalendarsRecords[Key]
            //        .OrderBy(x=>x.Period)
            //        .ToList();

            //    for(int i=1;i<GroupCalendarsRecords[Key].Count;i++)
            //        if (!(GroupCalendarsRecords[Key][i].Period - 1).Equals(GroupCalendarsRecords[Key][i - 1].Period))
            //        {
 
            //        }
            //}

            //日期 星期 節次 班級 科目 場地
            grdExchangeReplace.Columns.Clear();

            DataGridViewColumn colDate = Extensions.CreateColumn("colExDate", "日期", 80, 8.25F);
            DataGridViewColumn colWeekday = Extensions.CreateColumn("colExWeekday", "星期", 20, 8.25F);
            DataGridViewColumn colPeriod = Extensions.CreateColumn("colExPeriod", "節次", 20, 8.25F);
            DataGridViewColumn colTeacher = Extensions.CreateColumn("colExTeacher", "教師", 60, 8.25F);
            DataGridViewColumn colClass = Extensions.CreateColumn("colExClass", "班級", 60, 8.25F);
            DataGridViewColumn colSubject = Extensions.CreateColumn("colExSubject", "科目", 120, 8.25F);
            DataGridViewColumn colClassroom = Extensions.CreateColumn("colExClassroom", "場地", 60, 8.25F);

            grdExchangeReplace.Columns.Add(colDate);
            grdExchangeReplace.Columns.Add(colWeekday);
            grdExchangeReplace.Columns.Add(colPeriod);
            grdExchangeReplace.Columns.Add(colTeacher);
            grdExchangeReplace.Columns.Add(colSubject);
            grdExchangeReplace.Columns.Add(colClass);
            grdExchangeReplace.Columns.Add(colClassroom);

            grdExchangeReplace.Rows.Clear();

            //日期 星期 節次 班級 科目 場地
            foreach (CalendarRecord vCalendar in Records)
            {
                int AddRowIndex = grdExchangeReplace.Rows.Add();
                DataGridViewRow Row = grdExchangeReplace.Rows[AddRowIndex];
                Row.Tag = vCalendar;
                grdExchangeReplace.Rows[AddRowIndex].SetValues(
                    K12.Data.DateTimeHelper.ToDisplayString(vCalendar.StartDateTime),
                    vCalendar.Weekday,
                    vCalendar.Period,
                    vCalendar.TeacherName,
                    vCalendar.FullSubject,
                    vCalendar.ClassName,
                    vCalendar.ClassroomName);
            }

            if (Records.Count >0)
            {
                mExchangeRecord = Records[0];
                btnConfirmExchange.Enabled = true;
                btnConfirmReplace.Enabled = false;
            }
        }

        /// <summary>
        /// 顯示代課教師
        /// </summary>
        private void DisplayReplaceTeachers(List<Teacher> Whos)
        {
            grdExchangeReplace.Columns.Clear();

            DataGridViewColumn TeacherNameColumn = Extensions.CreateColumn("TeacherName","教師名稱",100, 8.25F);
            DataGridViewColumn TeacherCommentColumn = Extensions.CreateColumn("TeacherComment", "註記",200, 8.25F);

            grdExchangeReplace.Columns.Add(TeacherNameColumn);
            grdExchangeReplace.Columns.Add(TeacherCommentColumn);

            grdExchangeReplace.Rows.Clear();

            //教師姓名及註記
            foreach (Teacher vWho in Whos)
            {
                int AddRowIndex = grdExchangeReplace.Rows.Add();
                DataGridViewRow Row = grdExchangeReplace.Rows[AddRowIndex];
                Row.Tag = vWho;
                grdExchangeReplace.Rows[AddRowIndex].SetValues(vWho.Name,vWho.Comment);
            }

            if (Whos.Count > 0)
            {
                mReplaceTeacher = Whos[0];
                btnConfirmReplace.Enabled = true;
                btnConfirmExchange.Enabled = false;
            }
        }

        /// <summary>
        /// 查詢代課
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplaceQuery_Click(object sender, EventArgs e)
        {
            mReplaceTeacher = null;
            mExchangeRecord = null;
            mSelectedCalendars = grdCourseCalendar.GetSelectedCalendars();
            mSelectedSubjects = mSelectedCalendars.GetCalendarSubjects();     

            bool IsReplace = false;

            foreach (CalendarRecord vCalendar in mSelectedCalendars)
                if (!string.IsNullOrEmpty(vCalendar.ReplaceID))
                    IsReplace = true;

            if (IsReplace)
            {
                MessageBox.Show("選取行事曆已經代過課！");
                return;
            }

            Dictionary<string,Teacher> ReplaceTeachers = new Dictionary<string,Teacher>();

            #region 複製所有教師及教授科目
            foreach (string TeacherName in Calendar.Instance.Teachers.Keys)
            {
                if (!ReplaceTeachers.ContainsKey(TeacherName))
                    ReplaceTeachers.Add(TeacherName, Calendar.Instance.Teachers[TeacherName]);
            }
            #endregion

            try
            {
                #region 找出交集的教師行事曆，並自清單中移除。
                List<CalendarRecord> Calendars = Calendar.Instance.FindIntersect(null,null,mSelectedCalendars);

                foreach (CalendarRecord vCalendar in Calendars)
                {
                    string TeacherName = vCalendar.TeacherName;

                    if (ReplaceTeachers.ContainsKey(TeacherName))
                        ReplaceTeachers.Remove(TeacherName);
                }
                #endregion

                #region 尋找時段忙碌的教師，並自清單中移除；暫時先不考慮。
                //List<TeacherBusy> TeacherBusys = Calendar.Instance
                //    .FindBusyTeacher(null,mSelectedCalendars);

                //IEnumerable<string> TeacherIDs = TeacherBusys.Select(x => x.TeacherID);

                //foreach (string TeacherID in TeacherIDs)
                //    if (ReplaceTeachers.ContainsKey(TeacherID))
                //        ReplaceTeachers.Remove(TeacherID);
                #endregion

                //將教師排序
                List<Teacher> SortTeachers = ReplaceTeachers
                    .Values
                    .ToList()
                    .Sort(mSelectedSubjects.ToList());

                //將可代課教師顯示在畫面上
                DisplayReplaceTeachers(SortTeachers);

                //指定行事曆日期
                SetCalendarDay(mSelectedCalendars[0].StartDateTime);
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
            }
        }

        /// <summary>
        /// 是否能進行調課查詢
        /// </summary>
        /// <returns></returns>
        private bool IsExchangeQuery()
        {
            //調課選擇多筆狀況
            if (grdCourseCalendar.SelectedRows.Count >= 1)
            {
                CalendarRecord vFirstCalendar = grdCourseCalendar.SelectedRows[0].Tag as CalendarRecord;

                if (vFirstCalendar == null)
                    return false;

                string FullSubject = vFirstCalendar.FullSubject;
                string Weekday = vFirstCalendar.Weekday;
                string ClassName = vFirstCalendar.ClassName;

                List<int> Periods = new List<int>();

                foreach (DataGridViewRow Row in grdCourseCalendar.SelectedRows)
                {
                    CalendarRecord vCalendar = Row.Tag as CalendarRecord;

                    //若是被取消，或是代課情況，就不能選取
                    if (vCalendar.Cancel || 
                        !string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        return false;

                    //若科目不相同不能選取
                    if (!vCalendar.FullSubject.Equals(FullSubject))
                        return false;

                    //若星期不相同不能選取
                    if (!vCalendar.Weekday.Equals(Weekday))
                        return false;

                    //若班級不相同不能選取
                    if (!vCalendar.ClassName.Equals(ClassName))
                        return false;

                    Periods.Add(K12.Data.Int.Parse(vCalendar.Period));
                }

                #region 判斷選取的節次是否連續
                Periods.Sort();

                for (int i = 1; i < Periods.Count; i++)
                    if (!(Periods[i] - 1).Equals(Periods[i - 1]))
                        return false;
                #endregion
            }

            return true;
        }

        /// <summary>
        /// 是否能進行代課查詢
        /// </summary>
        /// <returns></returns>
        private bool IsReplaceQuery()
        {
            if (grdCourseCalendar.SelectedRows.Count >= 1)
            {
                bool Result = true;

                foreach (DataGridViewRow Row in grdCourseCalendar.SelectedRows)
                {
                    CalendarRecord vCalendar = Row.Tag as CalendarRecord;

                    if (vCalendar != null)
                    {
                        //三種狀況不能代課查詢。
                        //1.課程已被停用
                        //2.已是代課記錄
                        //3.已是調課記錄
                        if (vCalendar.Cancel || !string.IsNullOrEmpty(vCalendar.ReplaceID) || !string.IsNullOrEmpty(vCalendar.ExchangeID))
                        {
                            Result = false;
                        }
                    }
                }

                return Result;
            }

            return false;
        }

        /// <summary>
        /// 當選取改變時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdCourseCalendar_SelectionChanged(object sender, EventArgs e)
        {
            grdExchangeReplace.Rows.Clear();
            grdCalendar.Rows.Clear();    

            btnReplaceQuery.Enabled = IsReplaceQuery();
            btnExchangeQuery.Enabled = IsExchangeQuery();
        }

        /// <summary>
        /// 查詢調課
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExchangeQuery_Click(object sender, EventArgs e)
        {
            mReplaceTeacher = null;
            mExchangeRecord = null;

            if (grdCourseCalendar.SelectedRows.Count == 0)
            {
                MessageBox.Show("沒有選擇調課！");
                return;
            }

            mSelectedCalendars = grdCourseCalendar.GetSelectedCalendars();
            CalendarRecord vAbsenceCalendar = mSelectedCalendars[0];

            if (string.IsNullOrEmpty(vAbsenceCalendar.ClassName))
            {
                MessageBox.Show("調課必須要指定班級！");
                return;
            }

            //針對在指定日期區間(由Client決定)內的這個班級的課程分段的所有教師和場地。
            DateTime ExchangeStartDate = dateExchangeStart.Value.ToDayStart();
            DateTime ExchangeEndDate = dateExchangeEnd.Value.ToDayEnd();

            if (ExchangeEndDate.CompareTo(ExchangeStartDate) < 0)
            {
                MessageBox.Show("結束日期必須要大於開始日期！");
                return;
            }

            #region 尋找班級行事曆，是否可換到請假行事曆

            //1.尋找班級可調課行事曆
            List<CalendarRecord> records = Calendar.Instance.Find(
                null
                ,new List<string>(){vAbsenceCalendar.ClassName }
                ,null
                ,ExchangeStartDate
                ,ExchangeEndDate
                ,false);

            //2.調課行事曆時間要一樣，並且該行事曆不能已是代課的
            records = records
                .FindAll(x => x.Duration.Equals(mSelectedCalendars[0].Duration) && string.IsNullOrEmpty(x.ReplaceID));

            #region 尋找班級行事曆中所有的教師及場地
            //3.尋找班級行事曆中所有的教師
            List<string> TeahcerNames = records
                .Select(x => x.TeacherName)
                .Distinct()
                .ToList();

            //4.尋找班級行事曆中所有的場地
            List<string> ClassroomNames = records
                .Where(x => !string.IsNullOrEmpty(x.ClassroomName))
                .Select(x => x.ClassroomName)
                .Distinct()
                .ToList();
            #endregion

            //5.尋找在指定日期時間區間內，有行事曆的教師或場地
            List<CalendarRecord> IntersectRecords = Calendar.Instance
                .FindIntersect(
                TeahcerNames, 
                ClassroomNames,
                mSelectedCalendars
                );

            //6.尋找有交集的教師系統編號
            List<string> IntersectTeacherNames = IntersectRecords
                .Select(x => x.TeacherName)
                .Distinct()
                .ToList();

            //7.尋找有交集的場地名稱
            List<string> IntersectClassrooms = IntersectRecords
                .Where(x => !string.IsNullOrEmpty(x.ClassroomName))
                .Select(x => x.ClassroomName)
                .Distinct()
                .ToList();

            //9.尋找在指定日期時間區間內，有教師不調代時段的老師
            List<TeacherBusy> TeacherBusys = Calendar.Instance.FindBusyTeacher(null,new List<CalendarRecord>() { vAbsenceCalendar });

            IEnumerable<string> BusyTeacherIDs = TeacherBusys.Select(x => x.TeacherName);

            //8.將教師及場地自行事曆中去除。
            List<CalendarRecord> RemoveRecords = records.FindAll(x => 
                IntersectTeacherNames.Contains(x.TeacherName) || 
                IntersectClassrooms.Contains(x.ClassroomName) ||
                BusyTeacherIDs.Contains(x.TeacherID));

            //10.將無法調課的行事曆移除
            RemoveRecords.ForEach(x => records.Remove(x));
            #endregion

            #region 檢查請假行事曆，可否換到調課行事曆
            if (records.Count > 0)
            {
                //檢查調課課程的可否調過去，在請假課程中的教師及場地有否衝突
                List<CalendarRecord> TargetRecords = Calendar.Instance.FindIntersect(
                   new List<string>() { vAbsenceCalendar.TeacherName },
                   new List<string>() { vAbsenceCalendar.ClassroomName },
                   records);

                //尋找請假課程教師，在調課課程中是否有不調代時段
                List<TeacherBusy> vTeacherBusys = Calendar.Instance.FindBusyTeacher(
                    new List<string>() {vAbsenceCalendar.TeacherID }, 
                    records);

                List<CalendarRecord> RemoveTargetRecords = new List<CalendarRecord>();

                foreach (CalendarRecord vCalendar in records)
                {
                    foreach (CalendarRecord vTargetCalendar in TargetRecords)
                    {
                        if (vCalendar.IsIntersect(vTargetCalendar))
                        {
                            if (!RemoveTargetRecords.Contains(vCalendar))
                                RemoveTargetRecords.Add(vCalendar);
                        }
                    }

                    foreach (TeacherBusy vTeacherBusy in vTeacherBusys)
                    {
                        if (vCalendar.IsIntersect(vTeacherBusy))
                        {
                            if (!RemoveTargetRecords.Contains(vCalendar))
                                RemoveTargetRecords.Add(vCalendar);
                        }
                    }
                }

                RemoveTargetRecords.ForEach(x => records.Remove(x));
            }
            #endregion

            //顯示記錄
            DisplayExchangeCalendars(mSelectedCalendars.Count,records);

            //指定行事曆日期
            SetCalendarDay(mSelectedCalendars[0].StartDateTime);
        }

        /// <summary>
        /// 更新行事曆
        /// </summary>
        private void UpdateCalendar()
        {
            string TeacherName = mReplaceTeacher != null ? mReplaceTeacher.Name : string.Empty;
            string ClassName = mExchangeRecord != null ? mExchangeRecord.ClassName : string.Empty;
            List<CalendarRecord> crosscalendars = new List<CalendarRecord>();
            dateCalendarStart = dateCalendarStart.ToDayStart();
            dateCalendarEnd = dateCalendarEnd.ToDayEnd();

            if (string.IsNullOrEmpty(TeacherName) && string.IsNullOrEmpty(ClassName))
                return;

            if (!string.IsNullOrEmpty(TeacherName))
            {
                pnlCalendar.Text = mReplaceTeacher.Name + "功課表";
                crosscalendars = Calendar.Instance.FindCross(
                    new List<string>() { mReplaceTeacher.Name },
                    dateCalendarStart, 
                    dateCalendarEnd
                    , false);
            }
            else if (!string.IsNullOrEmpty(ClassName))
            {
                pnlCalendar.Text = mExchangeRecord.ClassName + "功課表";
            }

            grdCalendar.Columns.Clear();
            DataGridViewColumn col0 = Extensions.CreateColumn("col0", " ", 25, 8.75F);
            col0.SortMode = DataGridViewColumnSortMode.NotSortable;
            grdCalendar.Columns.Add(col0);
            DataGridViewColumn col1 = Extensions.CreateColumn("col1", "一 " + dateCalendarStart.ToMonthDay(), 80, 8.75F);
            col1.SortMode = DataGridViewColumnSortMode.NotSortable;
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdCalendar.Columns.Add(col1);
            DataGridViewColumn col2 = Extensions.CreateColumn("col2", "二 " + dateCalendarStart.AddDays(1).ToMonthDay(), 80, 8.75F);
            col2.SortMode = DataGridViewColumnSortMode.NotSortable;
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdCalendar.Columns.Add(col2);
            DataGridViewColumn col3 = Extensions.CreateColumn("col3", "三 " + dateCalendarStart.AddDays(2).ToMonthDay(), 80, 8.75F);
            col3.SortMode = DataGridViewColumnSortMode.NotSortable;
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdCalendar.Columns.Add(col3);
            DataGridViewColumn col4 = Extensions.CreateColumn("col4", "四 " + dateCalendarStart.AddDays(3).ToMonthDay(), 80, 8.75F);
            col4.SortMode = DataGridViewColumnSortMode.NotSortable;
            col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdCalendar.Columns.Add(col4);
            DataGridViewColumn col5 = Extensions.CreateColumn("col5", "五 " + dateCalendarStart.AddDays(4).ToMonthDay(), 80, 8.75F);
            col5.SortMode = DataGridViewColumnSortMode.NotSortable;
            col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdCalendar.Columns.Add(col5);

            grdCalendar.Rows.Clear();

            List<CalendarRecord> records = Calendar.Instance.Find(
                new List<string>(){TeacherName},
                new List<string>(){ClassName},
                null,
                dateCalendarStart, 
                dateCalendarEnd
                ,false);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(crosscalendars))
                records.AddRange(crosscalendars);

            List<string> DisplayFields = new List<string>(){"Subject"};

            if (mReplaceTeacher!=null)
                DisplayFields.Add("Class");
            else if (mExchangeRecord!=null)
                DisplayFields.Add("Teacher");

            SortedDictionary<int, DisplayCalendarRecord> DisplayRecords = records.ToDisplay(DisplayFields,9);

            foreach (DisplayCalendarRecord r in DisplayRecords.Values)
            {
                int AddRowIndex = grdCalendar.Rows.Add();
                DataGridViewRow Row = grdCalendar.Rows[AddRowIndex];
                Row.Height = 40;
                Row.Tag = r;
                grdCalendar.Rows[AddRowIndex].SetValues(r.PeriodNo, r.Mon, r.Tue, r.Wed, r.Thu, r.Fri, r.Sat, r.Sun);
            }

            lblCalendarRange.Text = K12.Data.DateTimeHelper.ToDisplayString(dateCalendarStart) + "~" + K12.Data.DateTimeHelper.ToDisplayString(dateCalendarEnd);
        }

        /// <summary>
        /// 調代課結果選擇改變
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdExchangeReplace_SelectionChanged(object sender, EventArgs e)
        {
            if (grdExchangeReplace.SelectedRows.Count == 1)
            {
                object SelectRowTag = grdExchangeReplace.SelectedRows[0].Tag;

                if (SelectRowTag is Teacher)
                {
                    mReplaceTeacher = grdExchangeReplace.SelectedRows[0].Tag as Teacher;
                    mExchangeRecord = null;
                    UpdateCalendar();
                }
                else if (SelectRowTag is CalendarRecord)
                {
                    mExchangeRecord = grdExchangeReplace.SelectedRows[0].Tag as CalendarRecord;
                    mReplaceTeacher = null;
                    UpdateCalendar();
                }
            }
        }

        /// <summary>
        /// 指定行事曆日期
        /// </summary>
        /// <param name="Date"></param>
        private void SetCalendarDay(DateTime Date)
        {
            dateCalendarStart = Date.StartOfWeek(DayOfWeek.Monday);
            dateCalendarEnd = dateCalendarStart.AddDays(6);

            UpdateCalendar();
        }

        /// <summary>
        /// 上週行事曆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreWeek_Click(object sender, EventArgs e)
        {
            DateTime datePreWeek = dateCalendarStart.AddDays(-3);

            dateCalendarStart = datePreWeek.StartOfWeek(DayOfWeek.Monday);
            dateCalendarEnd = dateCalendarStart.AddDays(6);

            UpdateCalendar();
        }

        /// <summary>
        /// 下週行事曆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            DateTime dateNextWeek = dateCalendarEnd.AddDays(3);

            dateCalendarStart = dateNextWeek.StartOfWeek(DayOfWeek.Monday);
            dateCalendarEnd = dateCalendarStart.AddDays(6);

            UpdateCalendar();
        }

        /// <summary>
        /// 確認代課
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmReplace_Click(object sender, EventArgs e)
        {
           if (!(grdExchangeReplace.SelectedRows.Count ==1))
           {
               MessageBox.Show("請選擇一位代課教師！");
               return;
           }

           Teacher vTeacher = grdExchangeReplace.SelectedRows[0].Tag as Teacher;

           frmReplaceConfirm ReplaceConfirm = new frmReplaceConfirm(mSelectedCalendars, vTeacher);

           if (ReplaceConfirm.ShowDialog() == DialogResult.OK)
           {
               string Comment = ReplaceConfirm.Comment;
               string Absence = ReplaceConfirm.AbsenceName;

               

               Tuple<bool, string> result = Calendar.Instance.Replace(mSelectedCalendars, vTeacher, Absence, Comment);

               if (!result.Item1)
                   MessageBox.Show(result.Item2);
               else
               {
                   List<string> UIDs = mSelectedCalendars.Select(x => x.UID).ToList();

                   Calendar.Instance.FindReplaceRecords(UIDs);

                   grdCourseCalendar.Rows.Clear();
                   grdExchangeReplace.Rows.Clear();

                   StringBuilder strBuilder = new StringBuilder();

                   strBuilder.AppendLine("《請假課程》");
                   foreach(CalendarRecord vCalendar in mSelectedCalendars)
                       strBuilder.AppendLine(vCalendar.ToString());
                   strBuilder.AppendLine("《代課教師》");
                   strBuilder.AppendLine(vTeacher.Name);
                   strBuilder.AppendLine("《假別註記》");
                   strBuilder.AppendLine("假別：" + Absence + ",註記：" + Comment);

                   Query();

                   FISCA.LogAgent.ApplicationLog.Log(Logs.調代課,Logs.代課作業, strBuilder.ToString());

                   MotherForm.SetStatusBarMessage("已成功執行代課！");
               }
           }
        }

        /// <summary>
        /// 確認調課
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmExchange_Click(object sender, EventArgs e)
        {
            if (!(grdExchangeReplace.SelectedRows.Count == 1))
            {
                MessageBox.Show("請選擇調課行事曆！");
                return;
            }  

            CalendarRecord vSrcCalendar = mSelectedCalendars[0];
            CalendarRecord vDesCalendar = grdExchangeReplace.SelectedRows[0].Tag as CalendarRecord;

            List<CalendarRecord> vSrcCalendars = new List<CalendarRecord>();
            vSrcCalendars.Add(vSrcCalendar);

            List<CalendarRecord> vDesCalendars = new List<CalendarRecord>();
            vDesCalendars.Add(vDesCalendar);

            frmExchangeConfirm ExchangeConfirm = new frmExchangeConfirm(vSrcCalendars,vDesCalendars);

            if (ExchangeConfirm.ShowDialog() == DialogResult.OK)
            {
                string AbsenceName = ExchangeConfirm.AbsenceName;
                string Comment = ExchangeConfirm.Comment;
                bool NoRecord = ExchangeConfirm.NoRecord;

                Tuple<bool, string> result = Calendar.Instance.Exchange(
                    vSrcCalendar,
                    vDesCalendar,
                    NoRecord,
                    AbsenceName,
                    Comment);

                if (!result.Item1)
                    MessageBox.Show(result.Item2);
                else
                {
                    grdCourseCalendar.Rows.Clear();
                    grdExchangeReplace.Rows.Clear();

                    StringBuilder strBuilder = new StringBuilder();

                    strBuilder.AppendLine("《請假課程》");
                    strBuilder.AppendLine(vSrcCalendar.ToString());
                    strBuilder.AppendLine("《調課課程》");
                    strBuilder.AppendLine(vDesCalendar.ToString());
                    strBuilder.AppendLine("《假別註記》");
                    strBuilder.AppendLine("假別：" + AbsenceName + ",註記：" + Comment);

                    Query();

                    FISCA.LogAgent.ApplicationLog.Log(Logs.調代課,Logs.調課作業, strBuilder.ToString());

                    MotherForm.SetStatusBarMessage("已成功執行調課！");
                }
            }
        }

        private void grdCalendar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateQueryStart_ValueChanged(object sender, EventArgs e)
        {
            dateQueryEnd.Value = dateQueryStart.Value.AddDays(6);
            dateExchangeStart.Value = dateQueryStart.Value;
        }

        private void dateExchangeStart_ValueChanged(object sender, EventArgs e)
        {
            dateExchangeEnd.Value = dateExchangeStart.Value.AddDays(6);
        }
    }
}