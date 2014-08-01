using System;

namespace ischedulePlus
{
    /// <summary>
    /// 取消行事曆記錄
    /// </summary>
    [FISCA.UDT.TableName("scheduler.cancel_course_calendar")]
    public class CancelCourseCalendar : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 無參數建構式
        /// </summary>
        public CancelCourseCalendar()
        {
 
        }

        /// <summary>
        /// 建構式，傳入CalendarRecord
        /// </summary>
        /// <param name="record"></param>
        public CancelCourseCalendar(CalendarRecord record)
        {
            StartDate = record.StartDateTime;
            EndDate = record.EndDateTime;
            TeacherName = record.TeacherName;
            AbsenceTeacherName = record.AbsTeacherName;
            ClassroomName = record.ClassroomName;

            if (record.ExchangeCalendar != null)
            {
                ExStartDate = record.ExchangeCalendar.StartDateTime;
                ExEndDate = record.ExchangeCalendar.EndDateTime;
                ExTeacherName = record.ExchangeCalendar.TeacherName;
                ExClassName = record.ExchangeCalendar.ClassName;
                ExClassroomName = record.ExchangeCalendar.ClassroomName;
                Type = "調課";
            }
            else
                Type = "代課";

            Content = record.ToXml().ToString();
        }

        /// <summary>
        /// 類別，代課或調課
        /// </summary>
        [FISCA.UDT.Field(Field = "type")]
        public string Type { get; set; }
        
        /// <summary>
        /// 開始日期，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="start_date")]
        public DateTime StartDate { get; set;}

        /// <summary>
        /// 結束日期，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="end_date")]
        public DateTime EndDate { get; set;}

        /// <summary>
        /// 教師姓名，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="teacher_name")]
        public string TeacherName { get; set; }

        /// <summary>
        /// 場地名稱，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="classroom_name")]
        public string ClassroomName { get; set; }

        /// <summary>
        /// 請假教師姓名，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="absence_teacher_name")]
        public string AbsenceTeacherName { get; set;}

        /// <summary>
        /// 調課開始日期，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="ex_start_date")]
        public DateTime ExStartDate { get; set; }

        /// <summary>
        /// 調課結束日期，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="ex_end_date")]
        public DateTime ExEndDate { get; set; }

        /// <summary>
        /// 調課教師，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="ex_teacher_name")]
        public string ExTeacherName { get; set; }

        /// <summary>
        /// 調課班級，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="ex_class_name")]
        public string ExClassName { get; set; }

        /// <summary>
        /// 調課場地，供查詢使用
        /// </summary>
        [FISCA.UDT.Field(Field="ex_classroom_name")]
        public string ExClassroomName { get; set; }

        /// <summary>
        /// 內容
        /// </summary>
        [FISCA.UDT.Field(Field="content")]
        public string Content { get; set; }
    }
}