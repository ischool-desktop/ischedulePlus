using System.Data;

namespace ischedulePlus
{
    /// <summary>
    /// HTML調代明細
    /// </summary>
    public class HTMLReportRecord
    {
        /// <summary>
        /// 調或代
        /// </summary>
        public string Type { get; set;}

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set;}

        /// <summary>
        /// 星期
        /// </summary>
        public string Weekday { get; set;}

        /// <summary>
        /// 節次
        /// </summary>
        public string Period { get; set;}

        /// <summary>
        /// 教師姓名
        /// </summary>
        public string TeacherName { get; set;}

        /// <summary>
        /// 教師系統編號
        /// </summary>
        public string TeacherID { get; set; }

        /// <summary>
        /// 科目名稱
        /// </summary>
        public string Subject { get; set;}

        /// <summary>
        /// 場地名稱
        /// </summary>
        public string Classroom { get; set;}

        /// <summary>
        /// 代課教師名稱
        /// </summary>
        public string ReplaceTeacherName { get; set;}

        /// <summary>
        /// 代課教師系統編號
        /// </summary>
        public string ReplaceTeahcerID { get; set; }

        public DataRow ToDataRow(DataTable Table)
        {
            DataRow Row = Table.NewRow();

            Row.SetField<string>("調代", Type);
            Row.SetField<string>("日期", Date);
            Row.SetField<string>("星期", Weekday);
            Row.SetField<string>("節次", Period);
            Row.SetField<string>("教師", TeacherName);
            Row.SetField<string>("科目", Subject);
            Row.SetField<string>("場地", Classroom);
            Row.SetField<string>("代課教師",ReplaceTeacherName);

            return Row;
        }

        /// <summary>
        /// 輸出內容
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "<tr><td>" + Type + "</td><td>" + Date + "</td><td>" + Weekday + "</td><td>" + Period + "</td><td>" + TeacherName + "</td><td>" + Subject + "</td><td>" + Classroom + "</td><td>"+ReplaceTeacherName+"</td></tr>";
        }
    }
}
