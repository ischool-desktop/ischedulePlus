using System;

namespace ischedulePlus
{
    /// <summary>
    /// 教師不調代時段
    /// </summary>
    [FISCA.UDT.TableName("scheduler.teacher_busy_date")]
    public class TeacherBusyDate : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 教師系統編號
        /// </summary>
        [FISCA.UDT.Field(Field="ref_teacher_id")]
        public int TeacherID { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        [FISCA.UDT.Field(Field = "weekday")]
        public int WeekDay { get; set; }

        /// <summary>
        /// 節次
        /// </summary>
        [FISCA.UDT.Field(Field = "period")]
        public int Period { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        [FISCA.UDT.Field(Field="begin_date_time")]
        public DateTime BeginDateTime { get; set; }

        /// <summary>
        /// 持續時間
        /// </summary>
        [FISCA.UDT.Field(Field="end_date_time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// 不排課描述
        /// </summary>
        [FISCA.UDT.Field(Field="busy_description")]
        public string BusyDesc { get; set; }
    }
}