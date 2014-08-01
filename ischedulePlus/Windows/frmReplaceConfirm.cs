using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 代課確認
    /// </summary>
    public partial class frmReplaceConfirm : FISCA.Presentation.Controls.BaseForm
    {
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private List<CalendarRecord> mCalendars;
        private Teacher mTeacher;
        private List<ReplaceCalendarList> mReplacePairs;

        /// <summary>
        /// 是否列印
        /// </summary>
        public bool IsPrint { get { return chkPrintReport.Checked; } }

        /// <summary>
        /// 建構式，傳入多筆行事曆及代課教師
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="Teacher"></param>
        public frmReplaceConfirm(List<CalendarRecord> Calendars,Teacher Teacher)
        {
            InitializeComponent();

            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
            {
                MessageBox.Show("沒有選取的行事曆！");

                this.Close();

                return;
            }

            chkMultiReplace.CheckedChanged += (sender, e) => intMultiReplace.Enabled = chkMultiReplace.Checked;

            mCalendars = Calendars;
            mTeacher = Teacher;

            ReplaceCalendarList mRepalceCalendarList = new ReplaceCalendarList();

            mReplacePairs = new List<ReplaceCalendarList>();
            mRepalceCalendarList.DateTimes = mCalendars.Select(x => x.StartDateTime).ToList();
            mRepalceCalendarList.Calendars = mCalendars;
            mReplacePairs.Add(mRepalceCalendarList);
        }

        /// <summary>
        /// 取得假別
        /// </summary>
        public string AbsenceName
        {
            get { return "" + cmbAbsenceName.Text; }
        }
        
        /// <summary>
        /// 取得註解
        /// </summary>
        public string Comment
        {
            get { return txtComment.Text; }
        }

                /// <summary>
        /// 選取調課行事曆
        /// </summary>
        public List<CalendarRecord> SelectedCalendars
        {
            get
            {
                List<CalendarRecord> result = new List<CalendarRecord>();

                if (chkMultiReplace.Checked)
                {
                    for (int i = 0; i < intMultiReplace.Value; i++)
                        result.AddRange(mReplacePairs[i].Calendars);
                }
                else
                {
                    result.AddRange(mReplacePairs[0].Calendars);
                }

                return result;
            }
        }

        /// <summary>
        /// 取得下個代課日期列表
        /// </summary>
        private List<DateTime> GetNextDateTimes(List<DateTime> DateTimes)
        {
            List<DateTime> result = new List<DateTime>();

            foreach (DateTime vDateTime in DateTimes)
            {
                result.Add(vDateTime.AddDays(7));
            }

            return result;
        }

        /// <summary>
        /// 是否在日期區間內
        /// </summary>
        /// <param name="DateTimes"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        private bool IsInDateRange(
            List<DateTime> DateTimes,
            DateTime StartDate,
            DateTime EndDate)
        {
            foreach(DateTime DateTime in DateTimes)
            {
                if (!(DateTime>=StartDate && DateTime <=EndDate))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 重新整理UI
        /// </summary>
        private void RefreshUI()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, e) =>
            {
                List<SchoolYearSemesterDate> SchoolYearSemesterDates = mAccessHelper.Select<SchoolYearSemesterDate>();

                SchoolYearSemesterDate SelectedSchoolYearSemesterDate = null;
                Tuple<DateTime, DateTime> StartEndDate = new Tuple<DateTime, DateTime>(new DateTime(), new DateTime());

                //取得目前學年度學期
                foreach (SchoolYearSemesterDate vSchoolYearSemesterDate in SchoolYearSemesterDates)
                {
                    StartEndDate = vSchoolYearSemesterDate.GetStartEndDate();

                    if (mCalendars[0].StartDateTime >= StartEndDate.Item1 && mCalendars[0].EndDateTime <= StartEndDate.Item2)
                    {
                        SelectedSchoolYearSemesterDate = vSchoolYearSemesterDate;
                        break;
                    }
                }

                if (SelectedSchoolYearSemesterDate != null)
                {
                    //取得所有要代課的日期
                    List<DateTime> NextDateTimes = mCalendars.Select(x=>x.StartDateTime).ToList();
                    
                    NextDateTimes = GetNextDateTimes(NextDateTimes);

                    //測試下個日期區間是否在學年度學期內
                    while (IsInDateRange(NextDateTimes,StartEndDate.Item1,StartEndDate.Item2))
                    {
                        ReplaceCalendarList Pair = new ReplaceCalendarList();
                        Pair.DateTimes = NextDateTimes;

                        mReplacePairs.Add(Pair);

                        NextDateTimes = GetNextDateTimes(NextDateTimes);
                    }
                }

                if (mReplacePairs.Count >1)
                {
                    List<DateTime> SelectedDates = new List<DateTime>();

                    for (int i = 1; i < mReplacePairs.Count; i++)
                    {
                        mReplacePairs[i].DateTimes.ForEach
                        (x =>
                            {
                                if (!SelectedDates.Contains(x))
                                    SelectedDates.Add(x);
                            }
                        );
                    }

                    List<CalendarRecord> records = Calendar.Instance.FindByTeacherNameAndDates(
                        mCalendars[0].TeacherName,
                        SelectedDates);

                    List<ReplaceCalendarList> removeList = new List<ReplaceCalendarList>();

                    for (int i = 1; i < mReplacePairs.Count; i++)
                    {
                        ReplaceCalendarList CurrentPair = mReplacePairs[i];
                        CurrentPair.Calendars = new List<CalendarRecord>();

                        for(int j=0;j<CurrentPair.DateTimes.Count;j++)
                        {
                            CalendarRecord mCalendar = mCalendars[j];
                            CalendarRecord vCalendar = records.Find(x =>
                            x.StartDateTime.ToShortDateString().Equals(CurrentPair.DateTimes[j].ToShortDateString()) &&
                            x.Weekday.Equals(mCalendar.Weekday) &&
                            x.Period.Equals(mCalendar.Period) &&
                            x.TeacherName.Equals(mCalendar.TeacherName) &&
                            x.ClassName.Equals(mCalendar.ClassName) &&
                            x.ClassroomName.Equals(mCalendar.ClassroomName) &&
                            x.FullSubject.Equals(mCalendar.FullSubject));

                            if (vCalendar != null)
                            {
                                //2014/3/25 修正，只有代課系統編號為空白才可以代課
                                //if (string.IsNullOrWhiteSpace(vCalendar.ReplaceID) &&
                                //    string.IsNullOrWhiteSpace(vCalendar.ExchangeID))

                                if (string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                                    CurrentPair.Calendars.Add(vCalendar);
                            }
                        }

                        if (K12.Data.Utility.Utility.IsNullOrEmpty(CurrentPair.Calendars))
                            removeList.Add(CurrentPair);
                    }

                    removeList.ForEach(x => mReplacePairs.Remove(x));
                }
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                grdReplace.Rows.Clear();

                foreach (CalendarRecord vCalendar in mCalendars)
                {
                    int RowIndex = grdReplace.Rows.Add();
                    DataGridViewRow row = grdReplace.Rows[RowIndex];

                    row.Tag = vCalendar;
                    row.SetValues(vCalendar.TeacherName,
                    vCalendar.Date,
                    vCalendar.DisplayWeekday,
                    vCalendar.Period,
                    vCalendar.ClassName + " " + vCalendar.FullSubject);
                }

                lblAfterTeacher.Text = "代課老師 " + mTeacher.Name;

                List<string> AbsenceList = Utility.GetAbsenceList();

                AbsenceList.ForEach(x => cmbAbsenceName.Items.Add(x));
                intMultiReplace.MaxValue = mReplacePairs.Count;
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 載入表單事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReplaceConfirm_Load(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// 代課行事曆組合
    /// </summary>
    public class ReplaceCalendarList
    {
        /// <summary>
        /// 行事曆日期列表
        /// </summary>
        public List<DateTime> DateTimes { get; set; }

        /// <summary>
        /// 行事曆列表
        /// </summary>
        public List<CalendarRecord> Calendars { get; set; }
    }
}