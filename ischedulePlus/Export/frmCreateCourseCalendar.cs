using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Aspose.Cells;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 產生課程行事曆
    /// </summary>
    public partial class frmCreateCourseCalendar : FISCA.Presentation.Controls.BaseForm
    {
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private Dictionary<string,SchoolYearSemesterDateHelper> mSchoolYearSemesterDate = new Dictionary<string,SchoolYearSemesterDateHelper>();
        private BackgroundWorker worker = new BackgroundWorker();
        private Workbook mbook = null;
        private List<CalendarSource> mCalendarSources = null;
        private List<CourseCalendar> mCourseCalendars = null;
        private Dictionary<string, TeacherEx> mTeachers = null;
        private Dictionary<string, ClassEx> mClasses = null;

        public frmCreateCourseCalendar()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();

            Dialog.Filter = "Excel(.xls)|*.xls"; // Filter files by extension

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            txtFilename.Text = Dialog.FileName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateCourseCalendar_Load(object sender, EventArgs e)
        {
            foreach (SchoolYearSemesterDate vSchoolYearSemesterDate in mAccessHelper.Select<SchoolYearSemesterDate>())
            {
                string SchoolYearSemester = vSchoolYearSemesterDate.SchoolYear + "," + vSchoolYearSemesterDate.Semester;

                if (!mSchoolYearSemesterDate.ContainsKey(SchoolYearSemester))
                    mSchoolYearSemesterDate.Add(SchoolYearSemester,new SchoolYearSemesterDateHelper(vSchoolYearSemesterDate));
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

            mCalendarSources = e.Result as List<CalendarSource>;

            mbook.Worksheets[0].Cells[0,20].PutValue("產生報告");

            for (int i = 0; i < mCalendarSources.Count; i++)
                mbook.Worksheets[0].Cells[i + 1, 20].PutValue(mCalendarSources[i].TransferComment);

            this.Close();

            new frmCreateCourseCalendarConfirm(mCourseCalendars,mbook).ShowDialog();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch mStopwatch = new Stopwatch();

            mStopwatch.Start();

            List<CalendarSource> CalendarSources = e.Argument as List<CalendarSource>;

            mCourseCalendars = new List<CourseCalendar>();

            for (int i = 0; i < CalendarSources.Count; i++)
            {
                CalendarSources[i].CreateCourseCalendar(mSchoolYearSemesterDate);
                mCourseCalendars.AddRange(CalendarSources[i].Calendars);
                worker.ReportProgress((int)((double)i / CalendarSources.Count * 100), "產生課程行事曆中...");
            }

            mStopwatch.Stop();
            Console.WriteLine(mStopwatch.Elapsed.TotalMilliseconds);

            e.Result = CalendarSources;
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
                //btnCreateCourseCalendar.Enabled = false;

                mbook = new Workbook();
                mbook.Open(txtFilename.Text);

                List<CourseCalendar> Calendars = new List<CourseCalendar>();
                mTeachers = new Dictionary<string, TeacherEx>();
                mClasses = new Dictionary<string, ClassEx>();

                int Progress = 0;
                int MaxDataRow = mbook.Worksheets[0].Cells.MaxDataRow;

                List<CalendarSource> CalendarSources = new List<CalendarSource>();
                mTeachers = new Dictionary<string, TeacherEx>();
                mClasses = new Dictionary<string, ClassEx>();

                for (int i = 1; i <= MaxDataRow; i++)
                {
                    Progress = (int)((double)i / MaxDataRow * 100);
                    CalendarSource vCalendarSource = new CalendarSource(mbook.Worksheets[0].Cells, i);
                    CalendarSources.Add(vCalendarSource);

                    if (!string.IsNullOrEmpty(vCalendarSource.TeacherName) &&
                        !mTeachers.ContainsKey(vCalendarSource.TeacherName))
                    {
                        TeacherEx vTeacher = new TeacherEx();
                        vTeacher.TeacherName = vCalendarSource.TeacherName;
                        mTeachers.Add(vCalendarSource.TeacherName, vTeacher);
                    }

                    if (!string.IsNullOrEmpty(vCalendarSource.ClassName) &&
                        !mClasses.ContainsKey(vCalendarSource.ClassName))
                    {
                        ClassEx vClass = new ClassEx();
                        vClass.ClassName = vCalendarSource.ClassName;
                        vClass.GradeYear = K12.Data.Int.ParseAllowNull(vCalendarSource.ClassYear);
                        mClasses.Add(vCalendarSource.ClassName, vClass);
                    }
                }

                worker.RunWorkerAsync(CalendarSources);
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
            book.Worksheets[0].AutoFitColumns();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "學期課表匯入格式";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            book.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }
    }
}