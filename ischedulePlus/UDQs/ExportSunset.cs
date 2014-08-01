using System;
using System.Collections.Generic;
using System.Text;

namespace ischedulePlus
{
    /// <summary>
    /// 匯出排課系統相關資料
    /// </summary>
    public class ExportSunset
    {
        /// <summary>
        /// 匯出所有班級
        /// </summary>
        public static void ExportClassEx()
        {
            string sql1 = "$scheduler.class_ex.class_name as 班級名稱";
            string sql2 = "$scheduler.class_ex.grade_year as 班級年級";
            string sql3 = "$scheduler.class_ex.class_code as 班級代碼";
            string sql4 = "$scheduler.class_ex.note as 註記";
            QueryExport.Execute("班級", string.Format("select {0},{1},{2},{3} from $scheduler.class_ex order by $scheduler.class_ex.grade_year,$scheduler.class_ex.class_name", sql1, sql2, sql3, sql4));
        }

        /// <summary>
        /// 匯出排課獨立教師清單
        /// </summary>
        public static void ExportTeacherEx()
        {
            string sql1 = "$scheduler.teacher_ex.teacher_name as 教師姓名";
            string sql2 = "$scheduler.teacher_ex.nickname as 教師暱稱";
            string sql3 = "$scheduler.teacher_ex.teacher_code as 教師代碼";
            string sql4 = "$scheduler.teacher_ex.teaching_expertise as 教學專長";
            string sql5 = "$scheduler.teacher_ex.note as 註記";
            QueryExport.Execute("教師", string.Format("select {0},{1},{2},{3},{4} from $scheduler.teacher_ex order by $scheduler.teacher_ex.teacher_code,$scheduler.teacher_ex.teacher_name,$scheduler.teacher_ex.nickname", sql1, sql2, sql3, sql4, sql5));
        }

        /// <summary>
        /// 依照開始日期及結束日期匯出週課程分段
        /// </summary>
        /// <param name="StartDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        public static void ExportWeekdayCourseSection(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate != null && EndDate != null)
            {
                StringBuilder SQLBuilder = new StringBuilder();

                SQLBuilder.AppendLine("select course.course_name as 課程名稱,course.school_year as 學年度,course.semester as 學期,to_char($scheduler.week_course_section.date,'YYYY/MM/DD') as 日期,$scheduler.week_course_section.week as 週次,$scheduler.week_course_section.weekday as 星期,$scheduler.week_course_section.period as 節次,$scheduler.week_course_section.length as 節數,(CASE WHEN $scheduler.week_course_section.long_break=true THEN '是' ELSE '' END) as 跨中午,(CASE WHEN $scheduler.week_course_section.week_flag=1 THEN '單' WHEN $scheduler.week_course_section.week_flag=2 THEN '雙' ELSE '單雙' END) as 單雙週,$scheduler.week_course_section.weekday_condition as 星期條件,$scheduler.week_course_section.period_condition as 節次條件,$scheduler.classroom.name as 場地名稱 ");
                SQLBuilder.AppendLine("from course left outer join $scheduler.week_course_section on $scheduler.week_course_section.ref_course_id=course.id left outer join $scheduler.classroom on $scheduler.week_course_section.ref_classroom_id=$scheduler.classroom.uid ");
                SQLBuilder.AppendLine("where date>='" + StartDate.ToShortDateString() + "' and date<='" + EndDate.ToShortDateString() + "' order by course.course_name,course.school_year,course.semester,$scheduler.week_course_section.date");

                QueryExport.Execute("週課程分段", SQLBuilder.ToString());
            }
        }

        /// <summary>
        /// 匯出課程行事曆
        /// </summary>
        public static void ExportCourseSchedule()
        {
            StringBuilder SQLBuilder = new StringBuilder();
            SQLBuilder.AppendLine("select course.course_name as 課程名稱,course.school_year as 學年度,course.semester as 學期,$scheduler.course_calendar.subject as 科目名稱,$scheduler.course_calendar.level as 科目級別,teacher.teacher_name as 教師名稱,class.class_name as 班級名稱,$scheduler.course_calendar.classroom_name as 場地名稱,to_char($scheduler.course_calendar.start_date_time,'YYYY/MM/DD') as 開始日期,to_char($scheduler.course_calendar.start_date_time, 'HH24:MI') as 開始時間,to_char($scheduler.course_calendar.end_date_time,'YYYY/MM/DD') as 結束日期,to_char($scheduler.course_calendar.end_date_time, 'HH24:MI') as 結束時間,$scheduler.course_calendar.weekday as 星期,$scheduler.course_calendar.period as 節次,comment as 註記 from $scheduler.course_calendar left outer join teacher on teacher.id=$scheduler.course_calendar.ref_teacher_id left outer join class on class.id=$scheduler.course_calendar.ref_class_id left outer join course on course.id=$scheduler.course_calendar.ref_course_id");

            QueryExport.Execute("課程行事曆", SQLBuilder.ToString());
        }

        /// <summary>
        /// 匯出選取教師不排課時段
        /// </summary>
        /// <param name="TeacherIDs">教師系統編號列表</param>
        public static void ExportTeacherBusy(List<string> TeacherIDs)
        {
            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherIDs))
            {
                StringBuilder SQLBuilder = new StringBuilder();

                //SQLBuilder.AppendLine("select $scheduler.teacher_busy.uid as 系統編號,teacher.teacher_name as 教師姓名,teacher.nickname as 教師暱稱,$scheduler.teacher_busy.weekday as 星期,to_char($scheduler.teacher_busy.begin_time, 'HH24:MI') as 開始時間,to_char($scheduler.teacher_busy.begin_time + cast($scheduler.teacher_busy.duration || ' minute' as interval),'HH24:MI') as 結束時間,$scheduler.teacher_busy.busy_description as 不排課描述,$scheduler.location.name as 所在地點 ");
                //SQLBuilder.AppendLine("select teacher.teacher_name as 教師姓名,teacher.nickname as 教師暱稱,$scheduler.teacher_busy.weekday as 星期,to_char($scheduler.teacher_busy.begin_time, 'HH24:MI') as 開始時間,to_char($scheduler.teacher_busy.begin_time + cast($scheduler.teacher_busy.duration || ' minute' as interval),'HH24:MI') as 結束時間,$scheduler.teacher_busy.busy_description as 不排課描述,$scheduler.location.name as 所在地點 ");

                SQLBuilder.AppendLine("select teacher.teacher_name as 教師姓名,teacher.nickname as 教師暱稱,to_char($scheduler.teacher_busy_date.begin_date_time,'YYYY/MM/DD') as 日期,to_char($scheduler.teacher_busy_date.begin_date_time, 'HH24:MI') as 開始時間,to_char($scheduler.teacher_busy_date.end_date_time,'HH24:MI') as 結束時間,$scheduler.teacher_busy_date.busy_description as 不調代描述 ");
                SQLBuilder.AppendLine("from teacher left outer join $scheduler.teacher_busy_date on $scheduler.teacher_busy_date.ref_teacher_id=teacher.id ");
                SQLBuilder.AppendLine("where teacher.id in (" + string.Join(",", TeacherIDs.ToArray()) + ") order by teacher.teacher_name,teacher.nickname,$scheduler.teacher_busy_date.begin_date_time");

                QueryExport.Execute("教師不調代課時段", SQLBuilder.ToString());
            }
        }
    }
}