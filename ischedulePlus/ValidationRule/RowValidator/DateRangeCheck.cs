using Campus.DocumentValidator;
using System;

namespace ischedulePlus
{
    /// <summary>
    /// 檢查結束日期是否大於開始日期
    /// </summary>
    public class iDateRangeCheck : IRowVaildator
    {
        #region IRowVaildator 成員

        public string Correct(IRowStream Value)
        {
            return string.Empty;
        }

        public string ToString(string template)
        {
            return template;
        }

        public bool Validate(IRowStream Value)
        {
            if (Value.Contains("開始日期") && Value.Contains("結束日期"))
            {
                DateTime StartDate = new DateTime(); 
                DateTime EndDate = new DateTime(); 

                if (DateTime.TryParse(Value.GetValue("開始日期"),out StartDate) && DateTime.TryParse(Value.GetValue("結束日期"),out EndDate))
                {
                    int Compare = DateTime.Compare(EndDate,StartDate);

                    bool Result = Compare >= 0;

                    return Result;
                }
            }

            return false;
        }

        #endregion
    }
}