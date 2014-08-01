using System;
using System.Collections.Generic;
using System.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 以教師為主的請假明細
    /// </summary>
    public class AbsenceRecord
    {
        /// <summary>
        /// 教師姓名
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// 請假日期
        /// </summary>
        public List<DateTime> Dates { get; set; }

        /// <summary>
        /// 輸出日期
        /// </summary>
        public string DatesString
        {
            get
            {
                List<string> result = new List<string>();

                Dates = Dates.Distinct().ToList();

                foreach (DateTime Date in Dates)
                    result.Add(Date.ToString("MM/dd"));

                string strResult = string.Join(" ", result.ToArray());

                return strResult;
            }
        }

        /// <summary>
        /// 請假節數
        /// </summary>
        public int AbsenceCount { get; set; }

        /// <summary>
        /// 代課細節
        /// </summary>
        public Dictionary<string,int> Replaces { get; set; }

        /// <summary>
        /// 假別列表
        /// </summary>
        public List<string> AbsenceNames { get; set; }

        /// <summary>
        /// 建構式
        /// </summary>
        public AbsenceRecord()
        {
            AbsenceCount = 0;
            Dates = new List<DateTime>();
            Replaces = new Dictionary<string, int>();
            AbsenceNames = new List<string>();
        }
    }
}