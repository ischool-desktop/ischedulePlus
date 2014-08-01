using System;
using System.Collections.Generic;
using Aspose.Cells;

namespace ischedulePlus
{
    /// <summary>
    /// 課程行事曆原始資料
    /// </summary>
    public class ClassBusyDateSource
    {
        private const int colSchoolYear = 0;
        private const int colSemester = 1;
        private const int colClassName = 2;
        private const int colWeekday = 3;
        private const int colPeriod = 4;
        private const int colStartTime = 5;
        private const int colEndTime = 6;
        private const int colDesc = 7;

        public ClassBusyDateSource(Cells Cells, int Row)
        {
            SchoolYear = ("" + Cells[Row, colSchoolYear].Value).Trim();
            Semester = ("" + Cells[Row, colSemester].Value).Trim();
            ClassName = ("" + Cells[Row, colClassName].Value).Trim();
            Weekday = ("" + Cells[Row, colWeekday].Value).Trim();
            Period = ("" + Cells[Row, colPeriod].Value).Trim();
            StartTime = ("" + Cells[Row, colStartTime].Value).Trim();
            EndTime = ("" + Cells[Row, colEndTime].Value).Trim();
            Desc = ("" + Cells[Row, colDesc].Value).Trim();
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
        /// 教師姓名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string Weekday { get; set; }

        /// <summary>
        /// 節次
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 結束時間
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 轉換說明
        /// </summary>
        public string TransferComment { get; set; }

        /// <summary>
        /// 轉換後結果
        /// </summary>
        public List<ClassBusyDate> ClassBusyDates { get; set; }

        /// <summary>
        /// 轉換為課程行事曆
        /// </summary>
        /// <param name="SchoolYearSemesterDates"></param>
        /// <returns></returns>
        public void CreateClassBusy(
            DateTime dteStart,
            DateTime dteEnd,
            Dictionary<string,ClassEx> Classes)
        {
            ClassBusyDates = new List<ClassBusyDate>();

            if (!Classes.ContainsKey(this.ClassName))
            {
                TransferComment = "此筆資料找不到系統中對應的班級，無法進行轉換。";
                return;
            }

            int StartWeekday = dteStart.GetWeekday();
            DateTime dteStartWeekday = dteStart.StartOfWeek(DayOfWeek.Monday);
            int intWeekday = K12.Data.Int.Parse(Weekday);
            dteStartWeekday = intWeekday < StartWeekday ? dteStartWeekday = dteStartWeekday.AddDays(7).AddDays(intWeekday - 1) : dteStartWeekday = dteStartWeekday.AddDays(intWeekday - 1);

            while (dteStartWeekday <= dteEnd)
            {
                ClassBusyDate vClassBusyDate = new ClassBusyDate();

                DateTime StartDateTime = new DateTime();
                DateTime EndDateTime = new DateTime();

                DateTime.TryParse(dteStartWeekday.ToShortDateString() + " " + StartTime, out StartDateTime);
                DateTime.TryParse(dteStartWeekday.ToShortDateString() + " " + EndTime, out EndDateTime);

                vClassBusyDate.WeekDay = K12.Data.Int.Parse(Weekday);
                vClassBusyDate.Period = K12.Data.Int.Parse(Period);
                vClassBusyDate.BeginDateTime = StartDateTime;
                vClassBusyDate.EndDateTime = EndDateTime;
                vClassBusyDate.BusyDesc = Desc;
                vClassBusyDate.ClassID = K12.Data.Int.Parse(Classes[ClassName].UID);
                ClassBusyDates.Add(vClassBusyDate);

                dteStartWeekday = dteStartWeekday.AddDays(7);
            }
            if (ClassBusyDates.Count > 0)
                TransferComment = "此筆資料已產生" + ClassBusyDates.Count + "筆班級不調代時段；開始日期為" + ClassBusyDates[0].BeginDateTime.ToShortDateString() + "、結束日期為" + ClassBusyDates[ClassBusyDates.Count - 1].BeginDateTime.ToShortDateString();
            else
                TransferComment = "此筆資料未產生班級不調代時段";
        }
    }
}