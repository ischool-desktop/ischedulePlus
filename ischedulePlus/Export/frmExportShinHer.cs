using System;
using System.Windows.Forms;
using Aspose.Cells;

namespace ischedulePlus
{
    /// <summary>
    /// 匯出欣河排課資料
    /// </summary>
    public partial class frmExportShinHer : FISCA.Presentation.Controls.BaseForm
    {
        public frmExportShinHer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 開啟Excel檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();

            Dialog.Filter = "Excel(.xls)|*.xls"; // Filter files by extension

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            txtFilename.Text = Dialog.FileName;
        }

        private Tuple<string,string> GetPeriodTimeString(string Period)
        {
            if (Period.Equals("0"))
                return new Tuple<string, string>("07:30", "07:50");
            else if (Period.Equals("1"))
                return new Tuple<string, string>("08:10", "09:00");
            else if (Period.Equals("2"))
                return new Tuple<string, string>("09:10", "10:00");
            else if (Period.Equals("3"))
                return new Tuple<string, string>("10:10", "11:00");
            else if (Period.Equals("4"))
                return new Tuple<string, string>("11:10", "12:00");
            else if (Period.Equals("5"))
                return new Tuple<string, string>("13:10", "14:00");
            else if (Period.Equals("6"))
                return new Tuple<string, string>("14:10", "15:00");
            else if (Period.Equals("7"))
                return new Tuple<string, string>("15:10", "16:00");
            else if (Period.Equals("8"))
                return new Tuple<string, string>("16:15", "17:05");
            else
                return new Tuple<string, string>(string.Empty, string.Empty);
        }

        //private Tuple<string, string> GetSubjectDetail(string Subject)
        //{
 
        //}

        /// <summary>
        /// 匯出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                #region 建立空白表格
                Workbook book = new Workbook();

                book.Worksheets.Add();

                book.Worksheets[0].Name = "週課表";
                book.Worksheets[0].Cells[0, 0].PutValue("課程名稱");
                book.Worksheets[0].Cells[0, 1].PutValue("學年度");
                book.Worksheets[0].Cells[0, 2].PutValue("學期");
                book.Worksheets[0].Cells[0, 3].PutValue("科目名稱");
                book.Worksheets[0].Cells[0, 4].PutValue("科目級別");
                book.Worksheets[0].Cells[0, 5].PutValue("科目簡稱");

                book.Worksheets[0].Cells[0, 6].PutValue("授課教師一");
                book.Worksheets[0].Cells[0, 7].PutValue("授課教師一代碼");

                book.Worksheets[0].Cells[0, 8].PutValue("授課教師二");
                book.Worksheets[0].Cells[0, 9].PutValue("授課教師二代碼");

                book.Worksheets[0].Cells[0, 10].PutValue("授課教師三");
                book.Worksheets[0].Cells[0, 11].PutValue("授課教師三代碼");

                book.Worksheets[0].Cells[0, 12].PutValue("所屬班級");
                book.Worksheets[0].Cells[0, 13].PutValue("班級年級");
                book.Worksheets[0].Cells[0, 14].PutValue("場地");
                book.Worksheets[0].Cells[0, 15].PutValue("星期");
                book.Worksheets[0].Cells[0, 16].PutValue("節次");
                book.Worksheets[0].Cells[0, 17].PutValue("開始時間");
                book.Worksheets[0].Cells[0, 18].PutValue("結束時間");
                book.Worksheets[0].Cells[0, 19].PutValue("鎖定");
                book.Worksheets[0].Cells[0, 20].PutValue("註記");

                book.Worksheets[1].Name = "教師不調代時段";
                book.Worksheets[1].Cells[0, 0].PutValue("學年度");
                book.Worksheets[1].Cells[0, 1].PutValue("學期");
                book.Worksheets[1].Cells[0, 2].PutValue("教師姓名");
                book.Worksheets[1].Cells[0, 3].PutValue("星期");
                book.Worksheets[1].Cells[0, 4].PutValue("節次");
                book.Worksheets[1].Cells[0, 5].PutValue("開始時間");
                book.Worksheets[1].Cells[0, 6].PutValue("結束時間");
                book.Worksheets[1].Cells[0, 7].PutValue("不調代描述");

                book.Worksheets[0].AutoFitColumns();
                book.Worksheets[1].AutoFitColumns();
                #endregion 

                Workbook mbook = new Workbook();
                mbook.Open(txtFilename.Text);

                int Progress = 0;
                int MaxDataRow = mbook.Worksheets[0].Cells.MaxDataRow;
                int MaxDataCol = mbook.Worksheets[0].Cells.MaxDataColumn;
                int OutputRow = 1;

                for (int RowIndex = 1; RowIndex <= MaxDataRow; RowIndex++)
                {
                    Progress = (int)((double)RowIndex / MaxDataRow * 100);

                    for (int ColIndex = 2; ColIndex <= MaxDataCol; ColIndex++)
                    {
                        string CellValue = ("" + mbook.Worksheets[0].Cells[RowIndex, ColIndex].Value).Trim();

                        if (mbook.Worksheets[0].Cells[0,ColIndex].StringValue.StartsWith("s") &&
                            !string.IsNullOrWhiteSpace(CellValue))
                        {
                            string TeacherName = mbook.Worksheets[0].Cells[RowIndex, 1].StringValue;
                            string Classroom = mbook.Worksheets[0].Cells[RowIndex, ColIndex - 1].StringValue;
                            string Weekday = mbook.Worksheets[0].Cells[0, ColIndex].StringValue.Substring(1, 1);
                            string Period = mbook.Worksheets[0].Cells[0, ColIndex].StringValue.Substring(2, 1);
                            Tuple<string, string> PeriodTimes = GetPeriodTimeString(Period);
                            string SubjectName = string.Empty;
                            string ClassName = string.Empty;
                            string GradeYear = string.Empty;

                            string[] CellValues = CellValue.Split(new char[] { ' ' });

                            if (CellValues.Length>=2)
                            {
                                SubjectName = CellValues[0].Trim();
                                ClassName = CellValues[CellValues.Length-1].Trim();
                                GradeYear = ClassName.Substring(0, 1);
                            }

                            book.Worksheets[0].Cells[OutputRow, 0].PutValue(string.Empty);
                            book.Worksheets[0].Cells[OutputRow, 1].PutValue(txtSchoolYear.Text);
                            book.Worksheets[0].Cells[OutputRow, 2].PutValue(txtSemester.Text);
                            book.Worksheets[0].Cells[OutputRow, 3].PutValue(SubjectName);
                            book.Worksheets[0].Cells[OutputRow, 4].PutValue("");
                            book.Worksheets[0].Cells[OutputRow, 5].PutValue(SubjectName);

                            book.Worksheets[0].Cells[OutputRow, 6].PutValue(TeacherName);
                            book.Worksheets[0].Cells[OutputRow, 7].PutValue(string.Empty);

                            book.Worksheets[0].Cells[OutputRow, 8].PutValue(string.Empty);
                            book.Worksheets[0].Cells[OutputRow, 9].PutValue(string.Empty);

                            book.Worksheets[0].Cells[OutputRow, 10].PutValue(string.Empty);
                            book.Worksheets[0].Cells[OutputRow, 11].PutValue(string.Empty);

                            book.Worksheets[0].Cells[OutputRow, 12].PutValue(ClassName);
                            book.Worksheets[0].Cells[OutputRow, 13].PutValue(GradeYear);
                            book.Worksheets[0].Cells[OutputRow, 14].PutValue(Classroom);
                            book.Worksheets[0].Cells[OutputRow, 15].PutValue(Weekday);
                            book.Worksheets[0].Cells[OutputRow, 16].PutValue(Period);
                            book.Worksheets[0].Cells[OutputRow, 17].PutValue(PeriodTimes.Item1);
                            book.Worksheets[0].Cells[OutputRow, 18].PutValue(PeriodTimes.Item2);
                            book.Worksheets[0].Cells[OutputRow, 19].PutValue(string.Empty);
                            book.Worksheets[0].Cells[OutputRow, 20].PutValue(string.Empty);

                            OutputRow ++;
                        }
                    }
                }

                MaxDataRow = mbook.Worksheets[1].Cells.MaxDataRow;
                MaxDataCol = mbook.Worksheets[1].Cells.MaxDataColumn;
                OutputRow = 1;

                for (int RowIndex = 1; RowIndex <= MaxDataRow; RowIndex++)
                {
                    string TeacherName = mbook.Worksheets[1].Cells[RowIndex, 5].StringValue;
                    string StartDay = mbook.Worksheets[1].Cells[RowIndex, 1].StringValue;
                    string EndDay = mbook.Worksheets[1].Cells[RowIndex, 2].StringValue;
                    string StartSec = mbook.Worksheets[1].Cells[RowIndex, 3].StringValue;
                    string EndSec = mbook.Worksheets[1].Cells[RowIndex, 4].StringValue;

                    //teacher_no	start_day	end_day	start_sec	end_sec	teach_name
                    //0001	1	1	0	2	涂淑惠     

                    if (StartDay.Equals(EndDay) && 
                        StartSec.Equals(EndSec))
                    {
                        if (!StartSec.Equals("0") &&
                            !EndSec.Equals("0"))
                        {
                            Tuple<string, string> StartEndTime = GetPeriodTimeString(StartSec);

                            book.Worksheets[1].Cells[OutputRow, 0].PutValue(txtSchoolYear.Text);
                            book.Worksheets[1].Cells[OutputRow, 1].PutValue(txtSemester.Text);
                            book.Worksheets[1].Cells[OutputRow, 2].PutValue(TeacherName);
                            book.Worksheets[1].Cells[OutputRow, 3].PutValue(StartDay);
                            book.Worksheets[1].Cells[OutputRow, 4].PutValue(StartSec);
                            book.Worksheets[1].Cells[OutputRow, 5].PutValue(StartEndTime.Item1);
                            book.Worksheets[1].Cells[OutputRow, 6].PutValue(StartEndTime.Item2);
                            book.Worksheets[1].Cells[OutputRow, 7].PutValue(string.Empty);

                            OutputRow++;
                        }
                    }
                }

                #region 儲存檔案
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FileName = "排課週課表";
                saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

                book.Save(saveFileDialog1.FileName);

                if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                #endregion
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
            }
        }

        /// <summary>
        /// 關閉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}