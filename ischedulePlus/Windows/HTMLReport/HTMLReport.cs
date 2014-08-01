using System.Collections.Generic;
using System.Data;
using System.Text;
using ReportHelper;

namespace ischedulePlus
{
    public class HTMLReport
    {
        public string ResourceType { get; set; }

        public string ResourceName { get; set; }

        public string StartDateTime { get; set; }

        public string EndDateTime { get; set; }

        public List<HTMLReportRecord> Records { get; set; }

        public HTMLReport()
        {
            Records = new List<HTMLReportRecord>();
        }

        public DataSet ToDataSet()
        {
            DataSet DataSet = new DataSet("DataSection");

            DataSet.Tables.Add(ResourceType.ToDataTable("調代類別", "調代類別"));
            DataSet.Tables.Add(ResourceName.ToDataTable("調代名稱", "調代名稱"));
            DataSet.Tables.Add((StartDateTime + "~" + EndDateTime).ToDataTable("調代區間", "調代區間"));

            DataTable Table = new DataTable("調代明細");

            //調代 日期 星期 節次 教師 科目 場地 代課教師
            Table.Columns.Add("調代");
            Table.Columns.Add("日期");
            Table.Columns.Add("星期");
            Table.Columns.Add("節次");
            Table.Columns.Add("教師");
            Table.Columns.Add("科目");
            Table.Columns.Add("場地");
            Table.Columns.Add("代課教師");

            foreach (HTMLReportRecord Record in Records)
                Table.Rows.Add(Record.ToDataRow(Table));

            DataSet.Tables.Add(Table);

            return DataSet;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("<P>"+ResourceType +"："+ResourceName +"  調代區間："+ StartDateTime +"~"+ EndDateTime +"</P>");

            strBuilder.AppendLine("<Table border='1'>");

            strBuilder.AppendLine("<tr><th>調代</th><th>日期</th><th>星期</th><th>節次</th><th>教師</th><th>科目</th><th>場地</th><th>代課教師</th></tr>");

            foreach (HTMLReportRecord Record in Records)
                strBuilder.AppendLine(Record.ToString());

            strBuilder.AppendLine("</Table>");

            return strBuilder.ToString();
        }
    }
}