using System;

namespace ischedulePlus
{
    /// <summary>
    /// 班級不調代時段
    /// </summary>
    [FISCA.UDT.TableName("scheduler.class_busy_date")]
    public class ClassBusyDate : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 班級系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_class_id")]
        public int ClassID { get; set; }

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
        [FISCA.UDT.Field(Field = "begin_date_time")]
        public DateTime BeginDateTime { get; set; }

        /// <summary>
        /// 持續時間
        /// </summary>
        [FISCA.UDT.Field(Field = "end_date_time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// 不調代描述
        /// </summary>
        [FISCA.UDT.Field(Field = "busy_description")]
        public string BusyDesc { get; set; }
    }
}