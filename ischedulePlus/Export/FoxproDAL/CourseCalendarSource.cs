using System;
using System.Collections.Generic;
using System.Diagnostics;
using Aspose.Cells;

namespace ischedulePlus
{
    /// <summary>
    /// 課程行事曆原始資料
    /// </summary>
    public class CalendarSource
    {
        private const int colCourseName = 0;
        private const int colSchoolYear = 1;
        private const int colSemester = 2;
        private const int colSubject = 3;
        private const int colSubjectLevel = 4;
        private const int colSubjectAlias = 5;
        private const int colTeacherName1 = 6;
        private const int colTeacherCode1 = 7;
        private const int colTeacherName2 = 8;
        private const int colTeacherCode2 = 9;
        private const int colTeacherName3 = 10;
        private const int colTeacherCode3 = 11;
        private const int colClass = 12;
        private const int colClassYear = 13;
        private const int colClassroom = 14;
        private const int colWeekday = 15;
        private const int colPeriod = 16;
        private const int colStartTime = 17;
        private const int colEndTime = 18;
        private const int colLock = 19;
        private const int colComment = 20;

        public CalendarSource(Cells Cells,int Row)
        {
            SchoolYear = ("" + Cells[Row, colSchoolYear].Value).Trim();
            Semester = ("" + Cells[Row, colSemester].Value).Trim();
            ClassYear = ("" + Cells[Row, colClassYear].Value).Trim();
            Subject = ("" + Cells[Row, colSubject].Value).Trim();
            SubjectLevel = ("" + Cells[Row, colSubjectLevel].Value).Trim();
            SubjectAlias = ("" + Cells[Row, colSubjectAlias].Value).Trim();
            TeacherName = ("" + Cells[Row, colTeacherName1].Value).Trim();
            TeacherCode = ("" + Cells[Row, colTeacherCode1].Value).Trim();
            ClassName = ("" + Cells[Row, colClass].Value).Trim();
            ClassroomName = ("" + Cells[Row, colClassroom].Value).Trim();
            Weekday = ("" + Cells[Row, colWeekday].Value).Trim();
            Period = ("" + Cells[Row, colPeriod].Value).Trim();
            StartTime = ("" + Cells[Row, colStartTime].Value).Trim();
            EndTime = ("" + Cells[Row, colEndTime].Value).Trim();
            Lock = ("" + Cells[Row, colLock].Value).Trim();
            Comment = ("" + Cells[Row, colComment].Value).Trim();
        }

        public string SchoolYear { get; set; }

        public string Semester { get; set; }

        public string SchoolYearSemester { get { return SchoolYear + "," + Semester; } }

        public string ClassYear { get; set; }

        public string Subject { get; set; }

        public string SubjectLevel { get; set; }

        public string SubjectAlias { get; set; }

        public string TeacherName { get; set; }

        public string TeacherCode { get; set; }

        public string ClassName { get; set; }

        public string ClassroomName { get; set; }

        public string Weekday { get; set; }

        public string Period { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Lock { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// 轉換備忘
        /// </summary>
        public string TransferComment { get; set; }

        public List<CourseCalendar> Calendars { get; set; }

        /// <summary>
        /// 轉換為課程行事曆
        /// </summary>
        /// <param name="SchoolYearSemesterDates"></param>
        /// <returns></returns>
        public void CreateCourseCalendar(Dictionary<string,SchoolYearSemesterDateHelper> SchoolYearSemesterDates)
        {
            Stopwatch mStopwatch = new Stopwatch();

            mStopwatch.Start();

            Calendars = new List<CourseCalendar>();
            List<string> IngoreHolidays = new List<string>();

            if (SchoolYearSemesterDates.ContainsKey(SchoolYearSemester))
            {
                SchoolYearSemesterDateHelper vSchoolYearSemesterDate = SchoolYearSemesterDates[SchoolYearSemester];

                if (vSchoolYearSemesterDate.GradeYearDates.ContainsKey(ClassYear))
                {
                    //年級的學期開始日期及結束日期
                    DateTime dteStart = vSchoolYearSemesterDate.GradeYearDates[ClassYear].StartDate;
                    DateTime dteEnd = vSchoolYearSemesterDate.GradeYearDates[ClassYear].EndDate;
                    
                    int StartWeekday = dteStart.GetWeekday();
                    DateTime dteStartWeekday = dteStart.StartOfWeek(DayOfWeek.Monday);
                    int intWeekday = K12.Data.Int.Parse(Weekday);
                    dteStartWeekday = intWeekday < StartWeekday ? dteStartWeekday = dteStartWeekday.AddDays(7).AddDays(intWeekday - 1) : dteStartWeekday = dteStartWeekday.AddDays(intWeekday - 1);

                    while (dteStartWeekday <= dteEnd)
                    {
                        CourseCalendar Calendar = new CourseCalendar();

                        Calendar.Subject = Subject;
                        Calendar.Level = K12.Data.Int.ParseAllowNull(SubjectLevel);
                        Calendar.SubjectAlias = SubjectAlias;
                        Calendar.TeacherName = TeacherName;
                        Calendar.ClassName = ClassName;
                        Calendar.ClassroomName = ClassroomName;
                        Calendar.WeekDay = intWeekday;
                        Calendar.Period = K12.Data.Int.Parse(Period);

                        DateTime StartDateTime = new DateTime();
                        DateTime EndDateTime = new DateTime();

                        DateTime.TryParse(dteStartWeekday.ToShortDateString() + " " + StartTime, out StartDateTime);
                        DateTime.TryParse(dteStartWeekday.ToShortDateString() + " " + EndTime, out EndDateTime);

                        Calendar.StartDateTime = StartDateTime;
                        Calendar.EndDateTime = EndDateTime;
                        Calendar.Lock = Lock;
                        Calendar.Comment = Comment;

                        if (!vSchoolYearSemesterDate.Holidays.Contains(Calendar.StartDateTime.ToShortDateString()))
                            Calendars.Add(Calendar);
                        else
                            IngoreHolidays.Add(Calendar.StartDateTime.ToShortDateString());

                        dteStartWeekday = dteStartWeekday.AddDays(7);
                    }

                    if (Calendars.Count>0)
                        TransferComment = "此筆資料已產生" + Calendars.Count +"筆課程行事曆；開始日期為" + Calendars[0].StartDateTime.ToShortDateString() + "、結束日期為" + Calendars[Calendars.Count-1].StartDateTime.ToShortDateString();

                    if (IngoreHolidays.Count > 0)
                        TransferComment += ";略過假日" + string.Join(",", IngoreHolidays.ToArray());
                }
                else
                    TransferComment = "此筆資料找不到學期設定中的年級，無法進行轉換。";
            }
            else
                TransferComment = "此筆資料找不到學期設定中的學年度學期，無法進行轉換。";

            mStopwatch.Stop();
            Console.WriteLine(mStopwatch.Elapsed.TotalMilliseconds);
        }
    }
}