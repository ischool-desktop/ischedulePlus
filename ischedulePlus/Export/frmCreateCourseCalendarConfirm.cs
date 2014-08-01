using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Aspose.Cells;
using FISCA.Data;
using FISCA.Presentation;
using FISCA.UDT;

namespace ischedulePlus
{
    public partial class frmCreateCourseCalendarConfirm : FISCA.Presentation.Controls.BaseForm
    {
        private QueryHelper mQueryHelper = new QueryHelper();
        private AccessHelper mAccessHelper = new AccessHelper();
        private Dictionary<string, string> mCourseCalendarIDs = null;
        private List<CourseCalendar> mCourseCalendars = null;
        private Workbook mbook = null;

        public frmCreateCourseCalendarConfirm(
            List<CourseCalendar> vCourseCalendars,
            Workbook vbook)
        {
            InitializeComponent();

            if (vCourseCalendars == null)
                throw new NullReferenceException("要新增的課程行事曆不得為空白！");

            if (vbook == null)
                throw new NullReferenceException("要檢視的課程行事曆產生報告不得為空白！");

            this.mCourseCalendars = vCourseCalendars;
            this.mbook = vbook;
        }

        private void frmCreateCourseCalendarConfirm_Load(object sender, EventArgs e)
        {
            lblCount.Text = "已產生課程行事曆共" + mCourseCalendars.Count + "筆";
        }

        private void lblViewReport_Click(object sender, EventArgs e)
        {
            if (mbook == null)
                return;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "課程行事曆產生報告";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            mbook.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private List<string> GetUIDs(List<CourseCalendar> PackageRecords)
        {
            List<string> UIDs = new List<string>();

            for (int i = 0; i < PackageRecords.Count; i++)
            {
                string strDateTime = PackageRecords[i].StartDateTime.GetDateTimeString();
                string strTeacherName = PackageRecords[i].TeacherName;
                string Key = strTeacherName + "^_^" + strDateTime;

                if (mCourseCalendarIDs.ContainsKey(Key))
                    UIDs.Add(mCourseCalendarIDs[Key]);
            }

            return UIDs;
        }

        private void InsertCourseCalendar(List<CourseCalendar> PackageRecords)
        {
            List<string> strConditions = new List<string>();

            List<string> UIDs = GetUIDs(PackageRecords);

            List<CourseCalendar> CourseCalendars = new List<CourseCalendar>();
            
            if (UIDs.Count >0)
                CourseCalendars = mAccessHelper.Select<CourseCalendar>("uid in ("+ string.Join(",",UIDs.ToArray()) +")");

            Dictionary<string,CourseCalendar> DicCourseCalendars = new Dictionary<string,CourseCalendar>();

            foreach(CourseCalendar Calendar in CourseCalendars)
            {
                string Key = Calendar.StartDateTime.GetDateTimeString() + "^_^" +Calendar.TeacherName;

                if (!DicCourseCalendars.ContainsKey(Key))
                    DicCourseCalendars.Add(Key,Calendar);
            }

            List<CourseCalendar> InsertRecords = new List<CourseCalendar>();

            List<CourseCalendar> UpdateRecords = new List<CourseCalendar>();

            foreach (CourseCalendar record in PackageRecords)
            {
                string Key = record.StartDateTime.GetDateTimeString() + "^_^" + record.TeacherName;

                if (DicCourseCalendars.ContainsKey(Key))
                {
                    CourseCalendar UpdateRecord = DicCourseCalendars[Key];

                    UpdateRecord.AbsenceName = record.AbsenceName;
                    UpdateRecord.ClassID = record.ClassID;
                    UpdateRecord.ClassName = record.ClassName;
                    UpdateRecord.ClassroomName = record.ClassroomName;
                    UpdateRecord.Comment = record.Comment;
                    UpdateRecord.CourseID = record.CourseID;
                    UpdateRecord.EMailLog = record.EMailLog;
                    UpdateRecord.EndDateTime = record.EndDateTime;
                    UpdateRecord.Level = record.Level;
                    UpdateRecord.Period = record.Period;
                    UpdateRecord.ScheduleComment = record.ScheduleComment;
                    UpdateRecord.Subject = record.Subject;
                    UpdateRecord.SubjectAlias = record.SubjectAlias;
                    UpdateRecord.TeacherID = record.TeacherID;
                    UpdateRecord.TeacherID2 = record.TeacherID2;
                    UpdateRecord.TeacherID3 = record.TeacherID3;
                    UpdateRecord.TeacherName2 = record.TeacherName2;
                    UpdateRecord.TeacherName3 = record.TeacherName3;
                    UpdateRecord.Lock = record.Lock;
                    UpdateRecord.WeekDay = record.WeekDay;

                    UpdateRecords.Add(UpdateRecord);
                }
                else
                    InsertRecords.Add(record);
            }

            if (UpdateRecords.Count > 0)
                mAccessHelper.UpdateValues(UpdateRecords);

            if (InsertRecords.Count >0)
                mAccessHelper.InsertValues(InsertRecords);
        }

        private void InsertCourseCalendar()
        {
            btnConfirmInsert.Enabled = false;

            if (mCourseCalendars.Count > 0)
            {
                #region 新增課程行事曆
                int PackageSize = 1000;

                BackgroundWorker worker = new BackgroundWorker();

                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += (vsender, ve) => progressBarX1.Value = ve.ProgressPercentage;
                worker.DoWork += (vsender, ve) =>
                {
                    #region
                    List<DateTime> DateTimes = mCourseCalendars.Select(x => x.StartDateTime).ToList();

                    DateTime StartDateTime = DateTimes.Min();
                    DateTime EndDateTime = DateTimes.Max();

                    DataTable table = new DataTable();

                    int RowLimit = 100;
                    int RowOffset = 0;

                    mCourseCalendarIDs = new Dictionary<string, string>();

                    string strSQL = "select uid,start_date_time,teacher_name from $scheduler.course_calendar where  start_date_time>='" + StartDateTime.ToShortDateString() + "' and start_date_time<='" + EndDateTime.ToShortDateString() +"'";

                    table = mQueryHelper.Select(strSQL);

                    foreach (DataRow row in table.Rows)
                    {
                        string uid = row.Field<string>("uid");
                        string start_date_time = DateTime.Parse(row.Field<string>("start_date_time")).GetDateTimeString();
                        string teacher_name = row.Field<string>("teacher_name");
                        string key = teacher_name + "^_^" + start_date_time;

                        if (!mCourseCalendarIDs.ContainsKey(key))
                            mCourseCalendarIDs.Add(key, uid);
                    }

                    //#region 分頁操作，先暫不使用，怪怪的
                    //do
                    //{
                    //    string strSQL = "select uid,start_date_time,teacher_name from $scheduler.course_calendar where  start_date_time>='" + StartDateTime.ToShortDateString() + "' and start_date_time<='" + EndDateTime.ToShortDateString() + "' limit " + RowLimit + " offset " + RowOffset;

                    //    table = mQueryHelper.Select(strSQL);

                    //    foreach (DataRow row in table.Rows)
                    //    {
                    //        string uid = row.Field<string>("uid");
                    //        string start_date_time = DateTime.Parse(row.Field<string>("start_date_time")).GetDateTimeString();
                    //        string teacher_name = row.Field<string>("teacher_name");
                    //        string key = teacher_name + "^_^" + start_date_time;

                    //        if (!mCourseCalendarIDs.ContainsKey(key))
                    //            mCourseCalendarIDs.Add(key, uid);
                    //    }

                    //    RowOffset += RowLimit;

                    //} while ( table.Rows.Count.Equals(RowLimit));
                    //#endregion

                    #endregion

                    List<CourseCalendar> PackageRecords = new List<CourseCalendar>();

                    for (int i = 0; i < mCourseCalendars.Count; i++)
                    {
                        PackageRecords.Add(mCourseCalendars[i]);

                        #region 1000筆為單位新增
                        if ((i > 0) && (i % PackageSize == 0))
                        {
                            InsertCourseCalendar(PackageRecords);
                            PackageRecords.Clear();
                        }
                        #endregion

                        worker.ReportProgress((int)(((float)i / (float)mCourseCalendars.Count) * 100), "新增課程行事曆中");
                    }

                    #region 將剩下的進行新增
                    if (PackageRecords.Count > 0)
                    {
                        InsertCourseCalendar(PackageRecords);
                    }
                    #endregion

                    worker.ReportProgress(100, "已成功新增或課程行事曆共" + mCourseCalendars.Count + "筆");
                    MotherForm.SetStatusBarMessage("已成功新增或課程行事曆共" + mCourseCalendars.Count + "筆");
                };

                worker.RunWorkerCompleted += (vsender, ve) =>
                {
                    MessageBox.Show("已成功新增或更新" + mCourseCalendars.Count + "筆課程行事曆！");
                    mCourseCalendars.Clear();
                };
                worker.RunWorkerAsync();
                #endregion
            }
        }

        /// <summary>
        /// 確認新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmInsert_Click(object sender, EventArgs e)
        {
            InsertCourseCalendar();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}