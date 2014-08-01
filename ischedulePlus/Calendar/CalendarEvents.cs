using System;
using System.Collections.Generic;

namespace ischedulePlus
{

    /// <summary>
    /// 排課課程更新事件
    /// </summary>
    public static class CalendarEvents
    {

        /// <summary>
        /// 引發教師更新事件
        /// </summary>
        public static void RaiseTeacherUpdateEvent()
        {
            if (TeacherUpdateEvent != null)
                TeacherUpdateEvent(null, new EventArgs());
        }

        /// <summary>
        /// /引發班級更新事件
        /// </summary>
        public static void RaiseClassUpdateEvent()
        {
            if (ClassUpdateEvent != null)
                ClassUpdateEvent(null, new EventArgs());
        }

        /// <summary>
        /// 引發代課更新事件
        /// </summary>
        public static void RaiseReplaceEvent()
        {
            if (ReplaceEvent != null)
                ReplaceEvent(null,new EventArgs());
        }

        /// <summary>
        /// 引發調課更新事件
        /// </summary>
        public static void RaiseExchangeEvent()
        {
            if (ExchangeEvent != null)
                ExchangeEvent(null, new EventArgs());
        }

        /// <summary>
        /// 引發週次變更事件
        /// </summary>
        public static void RaiseWeekChangeEvent(CalendarType Type,string AssocID)
        {
            if (WeekChangeEvent != null)
                WeekChangeEvent(null, new WeekChangeEventArgs(Type,AssocID));
        }

        /// <summary>
        /// 引發週次節數變更事件
        /// </summary>
        /// <param name="Weekday"></param>
        /// <param name="Periods"></param>
        public static void RaiseWeekdayPeriodChangeEvent(int Weekday,List<PeriodSetting> Periods)
        {
            if (WeekdayPeriodChangeEvent != null)
                WeekdayPeriodChangeEvent(null, new WeekdayPeriodEventArgs(Weekday,Periods));
        }

        /// <summary>
        /// 引發排課課程更新事件
        /// </summary>
        public static void RaisePeriodSelected(PeriodEventArgs Period)
        {
            if (PeriodSelected != null)
                PeriodSelected(null, Period);
        }

        /// <summary>
        /// 引發學年度學期改變事件
        /// </summary>
        public static void RaiseSchoolYearSemesterChange(string SchoolYear,string Semester)
        {
            if (SchoolYearSemesterChangeEvent != null)
                SchoolYearSemesterChangeEvent(null, new SchoolYearSemesterEventArgs(SchoolYear, Semester));    
        }

        /// <summary>
        /// 註冊列印事件按鈕
        /// </summary>
        public static void RaiseRegisterPrintButton()
        {
            if (RegisterPrintButtonEvent != null)
                RegisterPrintButtonEvent(null, new EventArgs());
        }

        /// <summary>
        /// 註冊列印事件
        /// </summary>
        public static event EventHandler RegisterPrintButtonEvent;

        /// <summary>
        /// 代課事件
        /// </summary>
        public static event EventHandler ReplaceEvent;

        /// <summary>
        /// 調課事件
        /// </summary>
        public static event EventHandler ExchangeEvent;

        /// <summary>
        /// 學年度學期改變事件
        /// </summary>
        public static event EventHandler<SchoolYearSemesterEventArgs> SchoolYearSemesterChangeEvent;

        /// <summary>
        /// 週變換事件
        /// </summary>
        public static event EventHandler<WeekChangeEventArgs> WeekChangeEvent;

        /// <summary>
        /// 星期節次改變設定
        /// </summary>
        public static event EventHandler<WeekdayPeriodEventArgs> WeekdayPeriodChangeEvent;

        /// <summary>
        /// 節次選取事件
        /// </summary>
        public static event EventHandler<PeriodEventArgs> PeriodSelected;

        /// <summary>
        /// 班級更新事件
        /// </summary>
        public static event EventHandler ClassUpdateEvent;

        /// <summary>
        /// 教師更新事件
        /// </summary>
        public static event EventHandler TeacherUpdateEvent;

        /// <summary>
        /// 星期改變事件
        /// </summary>
        public class WeekChangeEventArgs : EventArgs 
        {
            /// <summary>
            /// 行事曆類別
            /// </summary>
            public CalendarType Type { get; set; }

            /// <summary>
            /// 資源編號
            /// </summary>
            public string AssocID { get; set; }

            /// <summary>
            /// 建構式，傳入行事曆類別及資源編號
            /// </summary>
            /// <param name="Type"></param>
            /// <param name="AssocID"></param>
            public WeekChangeEventArgs(CalendarType Type, string AssocID)
            {
                this.Type = Type;
                this.AssocID = AssocID;
            }
        }

        /// <summary>
        /// 星期節次設定事件
        /// </summary>
        public class WeekdayPeriodEventArgs : EventArgs
        {
            /// <summary>
            /// 星期
            /// </summary>
            public int Weekday { get; set; }

            /// <summary>
            /// 節次列表
            /// </summary>
            public List<PeriodSetting> Periods { get; set; }

            public WeekdayPeriodEventArgs(int Weekday,List<PeriodSetting> Periods)
            {
                this.Weekday = Weekday;
                this.Periods = Periods;
            }
        }

        /// <summary>
        /// 學年度學期設定
        /// </summary>
        public class SchoolYearSemesterEventArgs : EventArgs
        {
            /// <summary>
            /// 學年度
            /// </summary>
            public string SchoolYear { get; set; }

            /// <summary>
            /// 學期
            /// </summary>
            public string Semester { get; set; }

            public SchoolYearSemesterEventArgs(string SchoolYear,string Semester)
            {
                this.SchoolYear = SchoolYear;
                this.Semester = Semester;
            }
        }
    }
}