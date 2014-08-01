using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Aspose.Cells;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 產生課程行事曆
    /// </summary>
    public partial class frmCreateTeacherCalendar : FISCA.Presentation.Controls.BaseForm
    {
        private Workbook mbook = new Workbook();
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private Dictionary<string,SchoolYearSemesterDateHelper> mSchoolYearSemesterDate = new Dictionary<string,SchoolYearSemesterDateHelper>();
        private BackgroundWorker worker = new BackgroundWorker();
        private List<TeacherBusyDateSource> mTeacherBusySources = new List<TeacherBusyDateSource>();
        private List<TeacherBusyDate> mTeacherBusyDates = new List<TeacherBusyDate>();
        private Dictionary<string, TeacherEx> mTeachers = new Dictionary<string, TeacherEx>();

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public frmCreateTeacherCalendar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 開啟檔案
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

        /// <summary>
        /// 離開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 表單載入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCreateTeacherBusyDate_Load(object sender, EventArgs e)
        {
            //取得學年度學期設定
            foreach (SchoolYearSemesterDate vSchoolYearSemesterDate in mAccessHelper.Select<SchoolYearSemesterDate>())
            {
                string SchoolYearSemester = vSchoolYearSemesterDate.SchoolYear + "," + vSchoolYearSemesterDate.Semester;

                if (!mSchoolYearSemesterDate.ContainsKey(SchoolYearSemester))
                    mSchoolYearSemesterDate.Add(SchoolYearSemester,new SchoolYearSemesterDateHelper(vSchoolYearSemesterDate));
            }

            //取得所有教師
            foreach (TeacherEx vTeacher in mAccessHelper.Select<TeacherEx>())
            {
                if (!mTeachers.ContainsKey(vTeacher.FullTeacherName))
                    mTeachers.Add(vTeacher.FullTeacherName, vTeacher);
            }

            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarX1.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarX1.Value = 100;

            mTeacherBusySources = e.Result as List<TeacherBusyDateSource>;

            mbook.Worksheets[0].Cells[0,8].PutValue("產生報告");

            for (int i = 0; i < mTeacherBusySources.Count; i++)
                mbook.Worksheets[0].Cells[i + 1, 8].PutValue(mTeacherBusySources[i].TransferComment);

            this.Close();

            new frmCreateTeacherBusyConfirm(mTeacherBusyDates, mbook).ShowDialog();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<TeacherBusyDateSource> TeacherSources = e.Argument as List<TeacherBusyDateSource>;

            mTeacherBusyDates = new List<TeacherBusyDate>();

            for (int i = 0; i < TeacherSources.Count; i++)
            {
                string SchoolYearSemesterKey = TeacherSources[i].SchoolYear + "," + TeacherSources[i].Semester;

                if (mSchoolYearSemesterDate.ContainsKey(SchoolYearSemesterKey))
                {
                    Tuple<DateTime, DateTime> StartEndDate = mSchoolYearSemesterDate[SchoolYearSemesterKey].GetStartEndDate();
                    TeacherSources[i].CreateTeacherBusy(StartEndDate.Item1,StartEndDate.Item2,mTeachers);
                    mTeacherBusyDates.AddRange(TeacherSources[i].TeacherBusyDates);
                }

                worker.ReportProgress((int)((double)i / TeacherSources.Count * 100), "產生教師不調代時段中...");
            }

            e.Result = TeacherSources;
        }

        private void lblSchoolYearSemester_Click(object sender, EventArgs e)
        {
            SchoolYearSemesterEditor vSchoolYearSemesterEditor = new SchoolYearSemesterEditor();

            SchoolYearSemesterPackageDataAccess SchoolYearSemesterDataAccess = new SchoolYearSemesterPackageDataAccess();

            winConfiguration<SchoolYearSemesterPackage> configSchoolYearSemster = new winConfiguration<SchoolYearSemesterPackage>(SchoolYearSemesterDataAccess, vSchoolYearSemesterEditor);
            vSchoolYearSemesterEditor.Prepare();
            configSchoolYearSemster.ShowDialog();
        }

        #region private function


        private void CreateCourseCalendar()
        {
            try
            {
                mbook = new Workbook();
                mbook.Open(txtFilename.Text);

                int Progress = 0;
                int MaxDataRow = mbook.Worksheets[0].Cells.MaxDataRow;

                List<TeacherBusyDateSource> TeacherBusySources = new List<TeacherBusyDateSource>();

                for (int i = 1; i <= MaxDataRow; i++)
                {
                    Progress = (int)((double)i / MaxDataRow * 100);
                    TeacherBusyDateSource vTeacherBusySource = new TeacherBusyDateSource(mbook.Worksheets[0].Cells, i);
                    TeacherBusySources.Add(vTeacherBusySource);
                }

                worker.RunWorkerAsync(TeacherBusySources);
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
            }
        }
        #endregion

        private void btnRun_Click(object sender, EventArgs e)
        {
            CreateCourseCalendar();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            Workbook book = new Workbook();

            book.Worksheets.Add();          					

            book.Worksheets[0].Name = "教師不調代時段";
            book.Worksheets[0].Cells[0, 0].PutValue("教師姓名");
            book.Worksheets[0].Cells[0, 1].PutValue("星期");
            book.Worksheets[0].Cells[0, 2].PutValue("節次");
            book.Worksheets[0].Cells[0, 3].PutValue("開始時間");
            book.Worksheets[0].Cells[0, 4].PutValue("結束時間");
            book.Worksheets[0].Cells[0, 5].PutValue("不調代描述");

            book.Worksheets[0].AutoFitColumns();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "教師不調代時段匯入格式";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            book.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }
    }
}