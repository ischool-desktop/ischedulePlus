using System;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 節次設定
    /// </summary>
    public class PeriodSetting
    {
        /// <summary>
        /// 建構式，傳入節次、小時、分鐘、持續分鐘
        /// </summary>
        /// <param name="Period"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Duration"></param>
        public PeriodSetting(int Period,int Hour,int Minute,int Duration)
        {
            this.Period = Period;
            this.StartTime = new DateTime(1900, 1, 1, Hour, Minute,0);
            this.Duration = Duration;
        }

        /// <summary>
        /// 建構式，傳入XmlElement
        /// </summary>
        /// <param name="element"></param>
        public PeriodSetting(XElement element)
        {
            Period = K12.Data.Int.Parse(element.Value);

            Tuple<DateTime,int> result = Utility.GetStorageTime(element.AttributeText("StartTime"), element.AttributeText("EndTime"));

            StartTime = result.Item1;
            Duration = result.Item2;
        }

        /// <summary>
        /// 節次
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 長度
        /// </summary>
        public int Duration { get; set; }
    }
}