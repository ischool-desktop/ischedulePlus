using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Aspose.Cells;
using Campus.Report;
using FISCA.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 匯出查詢類別
    /// </summary>
    public class QueryExport
    {
        /// <summary>
        /// 執行查詢並匯出成Excel格式
        /// </summary>
        /// <param name="QueryName">查詢名稱</param>
        /// <param name="Query">查詢內容</param>
        public static void Execute(string QueryName,string Query)
        {
            QueryHelper mQuery = Utility.QueryHelper;

            FISCA.Presentation.MotherForm.SetStatusBarMessage("查詢資料中!");

            DataTable mTableResult = mQuery.Select(Query);

            FISCA.Presentation.MotherForm.SetStatusBarMessage("查詢完成!");

            BackgroundWorker bkwExport = new BackgroundWorker();

            bkwExport.WorkerReportsProgress = true;
            bkwExport.DoWork += delegate(object vsender, DoWorkEventArgs ve)
            {
                DataTable  Table = (ve.Argument as DataTable);
                Workbook book = new Workbook();

                if (Table != null)
                {
                    for (int i = 0; i < Table.Columns.Count; i++)
                        book.Worksheets[0].Cells[0, i].PutValue(Table.Columns[i].ColumnName);

                    int RowIndex = 1;

                    foreach (DataRow Row in Table.Rows)
                    {
                        for (int ColumnIndex = 0; ColumnIndex < Table.Columns.Count; ColumnIndex++)
                            book.Worksheets[0].Cells[RowIndex, ColumnIndex].PutValue(Row.Field<string>(ColumnIndex));
                        bkwExport.ReportProgress((RowIndex / Table.Rows.Count) * 100);
                        RowIndex++;
                    }
                }

                book.Worksheets[0].AutoFitColumns();
                book.Worksheets[0].AutoFitRows();

                ve.Result = book;
            };

            bkwExport.ProgressChanged += delegate(object vsender, ProgressChangedEventArgs ve)
            {
                FISCA.Presentation.MotherForm.SetStatusBarMessage("產生中...", ve.ProgressPercentage);
            };

            bkwExport.RunWorkerCompleted += delegate(object vsender, RunWorkerCompletedEventArgs ve)
            {
                Workbook vWorkbook =  (Workbook)ve.Result;
                vWorkbook.Worksheets[0].Name = QueryName;

                FISCA.Presentation.MotherForm.SetStatusBarMessage("產生完成!");
                ReportSaver.SaveWorkbook(vWorkbook,Application.StartupPath +"\\Reports\\"+QueryName+".xls");
            };

            bkwExport.RunWorkerAsync(mTableResult);
        }
    }
}