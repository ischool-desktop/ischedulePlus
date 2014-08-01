using System;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 教師忙碌描述
    /// </summary>
    public class ClassBusy
    {
        public ClassBusy(XElement Element)
        {
            ClassName = Element.ElementText("ClassName");
            StartDateTime = K12.Data.DateTimeHelper.ParseDirect(Element.ElementText("BeginDateTime"));
            EndDateTime = K12.Data.DateTimeHelper.ParseDirect(Element.ElementText("EndDateTime"));
            Weekday = Element.ElementText("Weekday");
            Period = Element.ElementText("Period");
            Description = Element.ElementText("Description");
        }

        /// <summary>
        /// 班級名稱
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
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// 持續分鐘
        /// </summary>
        public int Duration
        {
            get
            {
                TimeSpan ts = EndDateTime.Subtract(StartDateTime);
                return (int)ts.TotalMinutes;
            }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 輸出字串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "班級姓名：" + ClassName + " 不調代描述：" + Description + " 時段：" + StartDateTime.GetDateTimeString() + " 至 " + EndDateTime.GetDateTimeString();
        }
    }
}