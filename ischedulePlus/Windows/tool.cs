using FISCA.Data;
using FISCA.UDT;
using K12.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 俊威建立的一個常用副程式或功能
    /// </summary>
    static class tool
    {
        static public AccessHelper _A = Utility.AccessHelper;
        static public QueryHelper _Q = Utility.QueryHelper;
        static public UpdateHelper _Update = new UpdateHelper();

        static public int SortTimeTables(TimeTable dt1, TimeTable dt2)
        {
            return dt1.TimeTableName.CompareTo(dt2.TimeTableName);
        }
    }
}
