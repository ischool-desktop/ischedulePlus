using System;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 課程行事曆
    /// </summary>
    [FISCA.UDT.TableName("scheduler.course_calendar")]
    public class CourseCalendar : ActiveRecord
    {
        /// <summary>
        /// 課程編號
        /// </summary>
        [FISCA.UDT.Field(Field="ref_course_id")]
        public int? CourseID { get; set; }

        /// <summary>
        /// 科目名稱
        /// </summary>
        [FISCA.UDT.Field(Field = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// 科目簡稱
        /// </summary>
        [FISCA.UDT.Field(Field = "subject_alias")]
        public string SubjectAlias { get; set; }

        /// <summary>
        /// 科目級別
        /// </summary>
        [FISCA.UDT.Field(Field = "level")]
        public int? Level { get; set; }

        /// <summary>
        /// 教師姓名
        /// </summary>
        [FISCA.UDT.Field(Field = "teacher_name")]
        public string TeacherName { get; set; }

        /// <summary>
        /// 教師系統編號
        /// </summary>
        [FISCA.UDT.Field(Field ="ref_teacher_id")]
        public int? TeacherID { get; set; }

        /// <summary>
        /// 教師姓名二
        /// </summary>
        [FISCA.UDT.Field(Field = "teacher_name_2")]
        public string TeacherName2 { get; set; }

        /// <summary>
        /// 教師系統編號二
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_teacher_id_2")]
        public int? TeacherID2 { get; set; }

        /// <summary>
        /// 教師姓名三
        /// </summary>
        [FISCA.UDT.Field(Field = "teacher_name_3")]
        public string TeacherName3 { get; set; }

        /// <summary>
        /// 教師系統編號三
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_teacher_id_3")]
        public int? TeacherID3 { get; set; }

        /// <summary>
        /// 班級名稱
        /// </summary>
        [FISCA.UDT.Field(Field = "class_name")]
        public string ClassName { get; set; }

        /// <summary>
        /// 班級系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_class_id")]
        public int? ClassID { get; set; }

        /// <summary>
        /// 場地名稱
        /// </summary>
        [FISCA.UDT.Field(Field ="classroom_name")]
        public string ClassroomName { get; set; }

        /// <summary>
        /// 開始日期時間
        /// </summary>
        [FISCA.UDT.Field(Field = "start_date_time")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 結束日期時間
        /// </summary>
        [FISCA.UDT.Field(Field = "end_date_time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        [FISCA.UDT.Field(Field="weekday")]
        public int WeekDay { get; set; }

        /// <summary>
        /// 節次
        /// </summary>
        [FISCA.UDT.Field(Field="period")]
        public int Period { get; set; }

        /// <summary>
        /// 代課(原)系統編號
        /// </summary>
        [FISCA.UDT.Field(Field="replace_id")]
        public int? ReplaceID { get; set;}

        /// <summary>
        /// 調課(原)系統編號
        /// </summary>
        [FISCA.UDT.Field(Field="exchange_id")]
        public int? ExchangeID { get; set;}

        [FISCA.UDT.Field(Field = "target_exchange_id")]
        public int? TargetExchangeID { get; set; }

        /// <summary>
        /// 假別名稱
        /// </summary>
        [FISCA.UDT.Field(Field="absence_name")]
        public string AbsenceName { get; set;}
        
        /// <summary>
        /// 註記
        /// </summary>
        [FISCA.UDT.Field(Field="comment")]
        public string Comment { get; set;}

        /// <summary>
        /// 排課註記
        /// </summary>
        [FISCA.UDT.Field(Field="schedule_comment")]
        public string ScheduleComment { get; set; }

        /// <summary>
        /// 取消
        /// </summary>
        [FISCA.UDT.Field(Field="cancel")]
        public bool Cancel{ get; set;}

        /// <summary>
        /// 電子郵件寄送記錄
        /// </summary>
        [FISCA.UDT.Field(Field="email_log")]
        public string EMailLog { get; set; }

        /// <summary>
        /// 鎖定
        /// </summary>
        [FISCA.UDT.Field(Field="lock")]
        public string Lock { get; set; }
    }
}