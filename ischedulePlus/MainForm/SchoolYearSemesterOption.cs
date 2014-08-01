using System;
using System.Collections.Generic;
using System.Linq;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 學年度學期設定
    /// </summary>
    public class SchoolYearSemesterOption
    {
        private static SchoolYearSemesterOption mOption = null;
        private AccessHelper mAccessHelper = Utility.AccessHelper;

        /// <summary>
        /// 封閉無參數建構式
        /// </summary>
        private SchoolYearSemesterOption()
        {
            LoadSchoolYearSemester();
        }

        /// <summary>
        /// 取得學年度學期設定
        /// </summary>
        public static SchoolYearSemesterOption Instance
        {
            get
            {
                if (mOption == null)
                    mOption = new SchoolYearSemesterOption();

                return mOption;
            }
        }

        /// <summary>
        /// 學年度
        /// </summary>
        public string SchoolYear { get; set; }

        /// <summary>
        /// 學期
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// 學年度學期開始日期
        /// </summary>
        public DateTime SchoolYearSemesterStartDate { get; set; }

        /// <summary>
        /// 學年度學期結束日期
        /// </summary>
        public DateTime SchoolYearSemesterEndDate { get; set; }

        /// <summary>
        /// 學年度學期設定
        /// </summary>
        public List<SchoolYearSemesterDate> SchoolYearSemesterDates { get; set; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 設定學年度學期開始結束日期
        /// </summary>
        private void SetSchoolYearSemesterStartEndDate()
        {
            SchoolYearSemesterDate vSchoolYearSemesterDate = SchoolYearSemesterDates
               .Find(x => x.SchoolYear.Equals(this.SchoolYear) && x.Semester.Equals(this.Semester));

            if (vSchoolYearSemesterDate != null)
            {
                Tuple<DateTime, DateTime> StartEndDate = vSchoolYearSemesterDate.GetStartEndDate();

                this.SchoolYearSemesterStartDate = StartEndDate.Item1;
                this.SchoolYearSemesterEndDate = StartEndDate.Item2;
            }
            else if (SchoolYearSemesterDates.Count > 0)
            {
                this.SchoolYear = SchoolYearSemesterDates[0].SchoolYear;
                this.Semester = SchoolYearSemesterDates[0].Semester;

                Tuple<DateTime, DateTime> StartEndDate = SchoolYearSemesterDates[0].GetStartEndDate();

                this.SchoolYearSemesterStartDate = StartEndDate.Item1;
                this.SchoolYearSemesterEndDate = StartEndDate.Item2;
            }

            if (DateTime.Now >= this.SchoolYearSemesterStartDate && DateTime.Now <= this.SchoolYearSemesterEndDate)
            {
                this.StartDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToDayStart();
                this.EndDate = this.StartDate.AddDays(6);
            }
            else
            {
                this.StartDate = this.SchoolYearSemesterStartDate.StartOfWeek(DayOfWeek.Monday);
                this.EndDate = this.StartDate.AddDays(6);
            }

            //不需要重新啟動事件，等使用者點選後再開啟
            //CalendarEvents.RaiseWeekChangeEvent();
        }

        /// <summary>
        /// 載入學年度學期設定
        /// </summary>
        public void LoadSchoolYearSemester()
        {
            StartDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToDayStart();
            EndDate = StartDate.AddDays(6).ToDayEnd();

            #region 載入學年度學期設定
            Campus.Configuration.ConfigData configSchoolYearSemester = Campus.Configuration.Config.User["OptionPreference"];
            string SaveSchoolYear = configSchoolYearSemester["SchoolYear"];
            string SaveSemester = configSchoolYearSemester["Semester"];

            SchoolYearSemesterDates = mAccessHelper.Select<SchoolYearSemesterDate>()
                .OrderBy(x=>K12.Data.Int.Parse(x.SchoolYear))
                .ThenBy(x=>x.Semester)
                .ToList();

            //若儲存的學年度學期不為空白
            if (!string.IsNullOrWhiteSpace(SaveSchoolYear)
                && !string.IsNullOrWhiteSpace(SaveSemester))
            {
                this.SchoolYear = SaveSchoolYear;
                this.Semester = SaveSemester;
            }

            SetSchoolYearSemesterStartEndDate();
            #endregion
        }

        /// <summary>
        /// 儲存學年度學期設定
        /// </summary>
        public void Save()
        {
            Campus.Configuration.ConfigData configSchoolYearSemester = Campus.Configuration.Config.User["OptionPreference"];

            configSchoolYearSemester["SchoolYear"] = this.SchoolYear;
            configSchoolYearSemester["Semester"] = this.Semester;
            configSchoolYearSemester.Save();

            SetSchoolYearSemesterStartEndDate();

            CalendarEvents.RaiseSchoolYearSemesterChange(this.SchoolYear,this.Semester);
        }
    }
}