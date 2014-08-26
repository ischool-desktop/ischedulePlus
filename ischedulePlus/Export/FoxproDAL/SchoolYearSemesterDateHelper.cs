using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 年級開始日期、結束日期
    /// </summary>
    public class GradeYearDate
    {
        /// <summary>
        /// 建構式，傳入年級XElement
        /// </summary>
        /// <param name="elmContent"></param>
        public GradeYearDate(XElement elmContent)
        {
            if (elmContent != null)
            {
                GradeYear = elmContent.AttributeText("GradeYear");
                StartDate = K12.Data.DateTimeHelper.ParseDirect(elmContent.AttributeText("StartDate"));
                EndDate = K12.Data.DateTimeHelper.ParseDirect(elmContent.AttributeText("EndDate"));
            }
        }

        /// <summary>
        /// 年級
        /// </summary>
        public string GradeYear { get; set; }

        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime EndDate { get; set; }
    }


    public class SchoolYearSemesterDateHelper
    {
        private SchoolYearSemesterDate mSchoolYearSemesterDate;

        public SchoolYearSemesterDateHelper(SchoolYearSemesterDate vSchoolYearSemesterDate)
        {
            if (vSchoolYearSemesterDate == null)
                throw new NullReferenceException();

            mSchoolYearSemesterDate = vSchoolYearSemesterDate;
            SchoolYear = mSchoolYearSemesterDate.SchoolYear;
            Semester = mSchoolYearSemesterDate.Semester;

            GradeYearDates = new Dictionary<string, GradeYearDate>();

            if (!string.IsNullOrEmpty(mSchoolYearSemesterDate.GradeYearStartEndDate))
            {
                XElement Element = XElement.Load(new StringReader(mSchoolYearSemesterDate.GradeYearStartEndDate));
                GradeYearDates = new Dictionary<string, GradeYearDate>();

                foreach (XElement elmGradeYear in Element.Elements("GradeYear"))
                {
                    GradeYearDate vGradeYearDate = new GradeYearDate(elmGradeYear);
                    GradeYearDates.Add(vGradeYearDate.GradeYear, vGradeYearDate);
                }
            }

            Holidays = new List<string>();

            if (!string.IsNullOrEmpty(mSchoolYearSemesterDate.Holidays))
            {
                Holidays = new List<string>();

                XElement Element = XElement.Load(new StringReader(mSchoolYearSemesterDate.Holidays));

                foreach (XElement elmHoliday in Element.Elements("Holiday"))
                {
                    string Holiday = elmHoliday.Value;

                    Holidays.Add(K12.Data.DateTimeHelper.ParseDirect(Holiday).ToShortDateString());
                }
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
        /// 年級日期
        /// </summary>
        public Dictionary<string, GradeYearDate> GradeYearDates { get; set; }

        /// <summary>
        /// 假日列表
        /// </summary>
        public List<string> Holidays { get; set; }

        /// <summary>
        /// 取得開始及結束日期
        /// </summary>
        /// <returns></returns>
        public Tuple<DateTime, DateTime> GetStartEndDate()
        {
            //加減年是因為，最大、最小日期在後面運算後會產生超過日期可顯示範圍的問題。
            //加個 10 年為防止此問題。
            DateTime StartDateTime = DateTime.MaxValue.AddYears(-10);
            DateTime EndDateTime = DateTime.MinValue.AddYears(10);

            foreach (GradeYearDate GradeYear in GradeYearDates.Values)
            {
                if (GradeYear.StartDate < StartDateTime)
                    StartDateTime = GradeYear.StartDate.ToDayStart();
                if (GradeYear.EndDate > EndDateTime)
                    EndDateTime = GradeYear.EndDate.ToDayEnd();
            }

            return new Tuple<DateTime, DateTime>(StartDateTime, EndDateTime);
        }
    }
}