using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 調課確認
    /// </summary>
    public partial class frmExchangeConfirm : FISCA.Presentation.Controls.BaseForm
    {
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private List<CalendarRecord> mCalendar;
        private List<CalendarRecord> mExchangeCalendar;
        private List<ExchangeCalendarPair> mExchangePairs;
        private ExchangeCalendarPair mExchangePair;
        private Dictionary<string, List<CalendarRecord>> mPrevCalendars;


        /// <summary>
        /// 建構式，傳入調課行事曆
        /// </summary>
        /// <param name="Calendar"></param>
        /// <param name="ExchangeCalendar"></param>
        public frmExchangeConfirm(
            List<CalendarRecord> Calendar,
            List<CalendarRecord> ExchangeCalendar)
        {
            InitializeComponent();

            chkMultiExchagne.CheckedChanged += (sender, e) => intMultiExchange.Enabled = chkMultiExchagne.Checked;

            mCalendar = Calendar;
            mExchangeCalendar = ExchangeCalendar;

            mExchangePair = new ExchangeCalendarPair();
            mExchangePair.DateTime = mCalendar[0].StartDateTime;
            mExchangePair.Calendar = mCalendar;
            mExchangePair.ExchangeDateTime = mExchangeCalendar[0].StartDateTime;
            mExchangePair.ExchangeCalendar = mExchangeCalendar;

            mExchangePairs = new List<ExchangeCalendarPair>();
            //mExchangePairs.Add(mExchangePair);
        }

        /// <summary>
        /// 是否列印
        /// </summary>
        public bool IsPrint
        {
            get { return chkPrintReport.Checked; }
        }

        /// <summary>
        /// 取得假別
        /// </summary>
        public string AbsenceName
        {
            get { return "" + cmbAbsenceName.Text; }
        }

        /// <summary>
        /// 註記
        /// </summary>
        public string Comment { get { return txtComment.Text; } }
        
        /// <summary>
        /// 是否不記錄
        /// </summary>
        public bool NoRecord { get { return chkNoRecord.Checked; } }

        /// <summary>
        /// 選取調課行事曆
        /// </summary>
        public List<ExchangeCalendarPair> SelectedExchangeCalendarPairs
        {
            get
            {
                List<ExchangeCalendarPair> result = new List<ExchangeCalendarPair>();

                if (chkMultiExchagne.Checked)
                {
                    for (int i = cmbAfterDate.SelectedIndex; i < cmbAfterDate.SelectedIndex + intMultiExchange.Value; i++)
                    {
                        if (i<cmbAfterDate.Items.Count)
                            result.Add(cmbAfterDate.Items[i] as ExchangeCalendarPair);
                    }
                }
                else
                {
                    result.Add(cmbAfterDate.SelectedItem as ExchangeCalendarPair);

                    string BeforeDate = "" + cmbBeforeDate.SelectedItem;

                    if (mPrevCalendars.ContainsKey(BeforeDate))
                        result[0].Calendar = mPrevCalendars[BeforeDate];
                    else 
                        result[0].Calendar = mCalendar;
                }

                return result;
            }
        }

        /// <summary>
        /// 更新介面
        /// </summary>
        private void RefreshUI()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, e) =>
            {
                List<SchoolYearSemesterDate> SchoolYearSemesterDates = mAccessHelper.Select<SchoolYearSemesterDate>();

                SchoolYearSemesterDate SelectedSchoolYearSemesterDate = null;
                Tuple<DateTime, DateTime> StartEndDate = new Tuple<DateTime, DateTime>(new DateTime(), new DateTime());

                List<DateTime> PrevDateTimes = new List<DateTime>();
                mPrevCalendars = new Dictionary<string, List<CalendarRecord>>();


                foreach (SchoolYearSemesterDate vSchoolYearSemesterDate in SchoolYearSemesterDates)
                {
                    StartEndDate = vSchoolYearSemesterDate.GetStartEndDate();

                    if (mCalendar[0].StartDateTime >= StartEndDate.Item1 && mCalendar[0].EndDateTime <= StartEndDate.Item2 &&
                        mExchangeCalendar[0].EndDateTime >= StartEndDate.Item1 && mExchangeCalendar[0].EndDateTime <= StartEndDate.Item2)
                    {
                        SelectedSchoolYearSemesterDate = vSchoolYearSemesterDate;
                        break;
                    }
                }

                if (SelectedSchoolYearSemesterDate != null)
                {
                    DateTime StartDate = StartEndDate.Item1.StartOfWeek(DayOfWeek.Monday);
                    DateTime EndDate = StartEndDate.Item2.StartOfWeek(DayOfWeek.Monday).AddDays(6);

                    int Weekday = mExchangePair.DateTime.GetWeekday();
                    int ExchangeWeekday = mExchangePair.ExchangeDateTime.GetWeekday();

                    DateTime NextDateTime = StartDate.AddDays(Weekday -1);          //mCalendar[0].StartDateTime.AddDays(7);
                    DateTime NextExchangeDateTime = StartDate.AddDays(ExchangeWeekday - 1);  //mExchangeCalendar[0].StartDateTime.AddDays(7);

                    DateTime PrevDateTime = StartDate.AddDays(Weekday - 1);          //mCalendar[0].StartDateTime.AddDays(-7);
                    DateTime PrevExchangeDateTime = StartDate.AddDays(ExchangeWeekday - 1);  //mExchangeCalendar[0].StartDateTime.AddDays(-7);

                    //測試下個日期區間是否在學年度學期內
                    while (NextDateTime >= StartDate && NextDateTime <= EndDate &&
                        NextExchangeDateTime >= StartDate && NextExchangeDateTime <= EndDate)
                    {
                        ExchangeCalendarPair Pair = new ExchangeCalendarPair();
                        Pair.DateTime = NextDateTime;
                        Pair.ExchangeDateTime = NextExchangeDateTime;
                        mExchangePairs.Add(Pair);

                        NextDateTime = NextDateTime.AddDays(7);
                        NextExchangeDateTime = NextExchangeDateTime.AddDays(7);
                    }

                    //測試上個日期區間是否在學年度學期內
                    while (PrevDateTime >= StartDate && 
                        PrevDateTime <= EndDate)
                    {
                        PrevDateTimes.Add(PrevDateTime);
                        PrevDateTime = PrevDateTime.AddDays(7);
                    }
                }

                if (mExchangePairs.Count > 1)
                {
                    List<DateTime> SelectedDates = new List<DateTime>();

                    for (int i = 0; i < mExchangePairs.Count; i++)
                    {
                        if (!SelectedDates.Contains(mExchangePairs[i].DateTime))
                            SelectedDates.Add(mExchangePairs[i].DateTime);

                        if (!SelectedDates.Contains(mExchangePairs[i].ExchangeDateTime))
                            SelectedDates.Add(mExchangePairs[i].ExchangeDateTime);
                    }

                    SelectedDates.AddRange(PrevDateTimes);

                    SelectedDates = SelectedDates.Distinct().ToList();

                    List<CalendarRecord> records = Calendar.Instance.Find(mCalendar[0].ClassName,SelectedDates);

                    records = records.FindAll(x => x.Cancel.Equals(false));

                    List<ExchangeCalendarPair> removeList = new List<ExchangeCalendarPair>();

                    #region 往後尋找
                    for (int i = 0; i < mExchangePairs.Count; i++)
                    {
                        ExchangeCalendarPair CurrentPair = mExchangePairs[i];

                        for(int j=0;j<mCalendar.Count;j++)
                        {
                            CalendarRecord vCalendar = null;
                            CalendarRecord ExCalendar = null;

                            try
                            {
                                //2014/1/8：注意在比對課程行事曆時，不比對場地
                                vCalendar = records.Find(x =>
                                    x.StartDateTime.ToShortDateString().Equals(CurrentPair.DateTime.ToShortDateString()) &&
                                    x.Weekday.Equals(mCalendar[j].Weekday) &&
                                    x.Period.Equals(mCalendar[j].Period) &&
                                    x.TeacherName.Equals(mCalendar[j].TeacherName) &&
                                    x.ClassName.Equals(mCalendar[j].ClassName) &&
                                    //x.ClassroomName.Equals(mCalendar[j].ClassroomName) &&
                                    x.FullSubject.Equals(mCalendar[j].FullSubject));

                                if (vCalendar != null)
                                    CurrentPair.Calendar.Add(vCalendar);
                            }catch
                            {

                            }

                            try
                            {
                                //2014/1/8：注意在比對課程行事曆時，不比對場地
                                ExCalendar = records.Find(x =>
                                    x.StartDateTime.ToShortDateString().Equals(CurrentPair.ExchangeDateTime.ToShortDateString()) &&
                                    x.Weekday.Equals(mExchangeCalendar[j].Weekday) &&
                                    x.Period.Equals(mExchangeCalendar[j].Period) &&
                                    x.TeacherName.Equals(mExchangeCalendar[j].TeacherName) &&
                                    x.ClassName.Equals(mExchangeCalendar[j].ClassName) &&
                                    //x.ClassroomName.Equals(mExchangeCalendar[j].ClassroomName) &&
                                    x.FullSubject.Equals(mExchangeCalendar[j].FullSubject));

                                if (ExCalendar != null)
                                    CurrentPair.ExchangeCalendar.Add(ExCalendar);
                            }
                            catch
                            {
 
                            }

                            if (K12.Data.Utility.Utility.IsNullOrEmpty(CurrentPair.Calendar) &&
                                K12.Data.Utility.Utility.IsNullOrEmpty(CurrentPair.ExchangeCalendar))
                                removeList.Add(CurrentPair);
                        }
                    }
                    #endregion

                    #region 往前尋找

                    foreach (DateTime vDate in PrevDateTimes)
                    {
                        for (int j = 0; j < mCalendar.Count; j++)
                        {
                            //2014/1/8：注意在比對課程行事曆時，不比對場地
                            CalendarRecord vCalendar = records.Find(x =>
                                x.StartDateTime.ToShortDateString().Equals(vDate.ToShortDateString()) &&
                                x.Weekday.Equals(mCalendar[j].Weekday) &&
                                x.Period.Equals(mCalendar[j].Period) &&
                                x.TeacherName.Equals(mCalendar[j].TeacherName) &&
                                x.ClassName.Equals(mCalendar[j].ClassName) &&
                                //x.ClassroomName.Equals(mCalendar[j].ClassroomName) &&
                                x.FullSubject.Equals(mCalendar[j].FullSubject));

                            string strPrevDateTime = vDate.ToShortDateString();

                            if (vCalendar != null)
                            {
                                if (!mPrevCalendars.ContainsKey(strPrevDateTime))
                                    mPrevCalendars.Add(strPrevDateTime, new List<CalendarRecord>());

                                mPrevCalendars[strPrevDateTime].Add(vCalendar);
                            }
                        }
                    }
                    #endregion

                    removeList.ForEach(x => mExchangePairs.Remove(x));
                }
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                try
                {

                    List<string> AbsenceList = Utility.GetAbsenceList();

                    AbsenceList.ForEach(x => cmbAbsenceName.Items.Add(x));

                    mCalendar = mCalendar
                        .OrderBy(x => x.Period)
                        .ToList();

                    mExchangeCalendar = mExchangeCalendar
                        .OrderBy(x => x.Period)
                        .ToList();

                    lblBeforeTeacher.Text = mCalendar[0].TeacherName + " 老師";
                    lblAfterTeacher.Text = mExchangeCalendar[0].TeacherName + " 老師";

                    int SelectedIndex = 0;
                    int Index = 0;

                    foreach (string vDateTime in mPrevCalendars.Keys)
                    {
                        cmbBeforeDate.Items.Add(vDateTime);

                        if (vDateTime.Equals(mExchangePair.DateTime.ToShortDateString()))
                            SelectedIndex = Index;

                        Index++;
                    }

                    cmbBeforeDate.SelectedIndex = SelectedIndex;

                    lblBeforeDate.Text = mCalendar[0].StartDateTime.ToShortDateString();

                    SelectedIndex = 0;
                    Index = 0;

                    foreach (ExchangeCalendarPair Pair in mExchangePairs)
                    {
                        if (Pair.ExchangeDateTime.ToShortDateString()
                            .Equals(mExchangePair.ExchangeDateTime.ToShortDateString()))
                        {
                            SelectedIndex = Index;
                            break;
                        }

                        Index++;
                    }

                    cmbAfterDate.DataSource = mExchangePairs;
                    cmbAfterDate.SelectedIndex = SelectedIndex;

                    string BeforeEndPeriod = mCalendar.Count > 1 ? "-" + mCalendar[mCalendar.Count - 1].Period : string.Empty;
                    string AfterEndPeriod = mExchangeCalendar.Count > 1 ? "-" + mExchangeCalendar[mExchangeCalendar.Count - 1].Period : string.Empty;

                    lblBeforeWeekdayPeriod.Text = "星期" + mCalendar[0].DisplayWeekday + " 第" + mCalendar[0].Period + BeforeEndPeriod + "節";
                    lblAfterWeekdayPeriod.Text = "星期" + mExchangeCalendar[0].DisplayWeekday + " 第" + mExchangeCalendar[0].Period + AfterEndPeriod + "節";

                    lblBeforeCourseName.Text = mCalendar[0].ClassName + " " + mCalendar[0].FullSubject;
                    lblAfterCourseName.Text = mExchangeCalendar[0].ClassName + " " + mExchangeCalendar[0].FullSubject;
                    lblBeforeClassroom.Text = mCalendar[0].ClassroomName;
                    lblAfterClassroom.Text = mExchangeCalendar[0].ClassroomName;
                    intMultiExchange.MaxValue = mExchangePairs.Count;
                }
                catch (Exception ve)
                {
                    SmartSchool.ErrorReporting.ReportingService.ReportException(ve);
                    MessageBox.Show(ve.Message);
                }
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExchangeConfirm_Load(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }

    /// <summary>
    /// 交換行事曆組合
    /// </summary>
    public class ExchangeCalendarPair
    {
        /// <summary>
        /// 目標調課日期
        /// </summary>
        public string ExchangeDate
        {
            get
            {
                return ExchangeDateTime != null ? ExchangeDateTime.ToShortDateString() : string.Empty;
            }
        }

        /// <summary>
        /// 來源調課日期
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 目標調課日期
        /// </summary>
        public DateTime ExchangeDateTime { get; set; }

        /// <summary>
        /// 來源調課行事曆
        /// </summary>
        public List<CalendarRecord> Calendar { get; set; }

        /// <summary>
        /// 目標調課行事曆
        /// </summary>
        public List<CalendarRecord> ExchangeCalendar { get; set; }

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public ExchangeCalendarPair()
        {
            Calendar = new List<CalendarRecord>();

            ExchangeCalendar = new List<CalendarRecord>();
        }
    }
}