using System;
using System.IO;
using System.Xml.Linq;

namespace ischedulePlus
{
    public static class SchoolYearSemesterDateExtension
    {
        public static Tuple<DateTime, DateTime> GetStartEndDate(this SchoolYearSemesterDate vSchoolYearSemester)
        {
            SchoolYearSemesterDateHelper vSchoolYearSemesterHelper = new SchoolYearSemesterDateHelper(vSchoolYearSemester);

            return vSchoolYearSemesterHelper.GetStartEndDate(); 
        }
    }

    /// <summary>
    /// 學年度學期日期對照，調代課系統用來產生週課程分段
    /// </summary>
    [FISCA.UDT.TableName("scheduler.schoolyear_semester_date")]
    public class SchoolYearSemesterDate : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 學年度
        /// </summary>
        [FISCA.UDT.Field(Field = "schoolyear")]
        public string SchoolYear { get; set; }

        /// <summary>
        /// 學期
        /// </summary>
        [FISCA.UDT.Field(Field = "semester")]
        public string Semester { get; set; }

        /// <summary>
        /// 年級開始及結束日期，用xml來描述
        /// </summary>
        [FISCA.UDT.Field(Field ="grade_year_start_end_date")]
        public string GradeYearStartEndDate { get; set; }

        /// <summary>
        /// 假日設定，用xml來描述
        /// </summary>
        [FISCA.UDT.Field(Field = "holidays")]
        public string Holidays { get; set; }

        /// <summary>
        /// 開始日期
        /// </summary>
        [FISCA.UDT.Field(Field = "start_date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 結束日期
        /// </summary>
        [FISCA.UDT.Field(Field = "end_date")]
        public DateTime EndDate { get; set; }
    }
}