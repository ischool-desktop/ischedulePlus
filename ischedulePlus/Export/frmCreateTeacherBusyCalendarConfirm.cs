using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Aspose.Cells;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    public partial class frmCreateTeacherBusyConfirm : FISCA.Presentation.Controls.BaseForm
    {
        private List<TeacherBusyDate> mTeacherBusyDates = null;
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private Workbook mbook = null;

        public frmCreateTeacherBusyConfirm(
            List<TeacherBusyDate> vTeacherBusyDates,
            Workbook vbook)
        {
            InitializeComponent();

            if (vTeacherBusyDates == null)
                throw new NullReferenceException("要新增的課程行事曆不得為空白！");

            if (vbook == null)
                throw new NullReferenceException("要檢視的課程行事曆產生報告不得為空白！");

            this.mTeacherBusyDates = vTeacherBusyDates;
            this.mbook = vbook;
        }

        private void frmCreateCourseCalendarConfirm_Load(object sender, EventArgs e)
        {
            lblCount.Text = "已產生教師不調代時段共" + mTeacherBusyDates.Count + "筆";
        }

        private void lblViewReport_Click(object sender, EventArgs e)
        {
            if (mbook == null)
                return;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "教師不調代時段產生報告";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            mbook.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void InsertTeacherBusy(List<TeacherBusyDate> TeacherBusyDates)
        {
            List<string> strConditions = new List<string>();

            foreach (TeacherBusyDate record in TeacherBusyDates)
            {
                string strDateTime = record.BeginDateTime.GetDateTimeString();

                strConditions.Add("(to_char(begin_date_time,'yyyy/mm/dd HH24:MI')='" + strDateTime + "' and ref_teacher_id=" + record.TeacherID + ")");
            }            

            string strSQL = "select uid from $scheduler.teacher_busy_date where " + string.Join(" or ", strConditions.ToArray());
         
            DataTable table = mQueryHelper.Select(strSQL);

            List<string> UIDs = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                UIDs.Add(row.Field<string>("uid"));
            }

            List<TeacherBusyDate> ExistTeacherBusyDates = new List<TeacherBusyDate>();
            
            if (UIDs.Count>0)
                ExistTeacherBusyDates = mAccessHelper.Select<TeacherBusyDate>("uid in (" + string.Join(",", UIDs.ToArray()) + ")");

            Dictionary<string, TeacherBusyDate> DicTeacherBusyDates = new Dictionary<string,TeacherBusyDate>();

            foreach (TeacherBusyDate vTeacherBusyDate in ExistTeacherBusyDates)
            {
                string Key = vTeacherBusyDate.BeginDateTime.GetDateTimeString() + "^_^" + vTeacherBusyDate.TeacherID;

                if (!DicTeacherBusyDates.ContainsKey(Key))
                    DicTeacherBusyDates.Add(Key,vTeacherBusyDate);
            }

            List<TeacherBusyDate> InsertRecords = new List<TeacherBusyDate>();

            List<TeacherBusyDate> UpdateRecords = new List<TeacherBusyDate>();

            foreach (TeacherBusyDate record in TeacherBusyDates)
            {
                string Key = record.BeginDateTime.GetDateTimeString() + "^_^" + record.TeacherID;

                if (DicTeacherBusyDates.ContainsKey(Key))
                {
                    TeacherBusyDate UpdateRecord = DicTeacherBusyDates[Key];

                    UpdateRecord.BusyDesc = record.BusyDesc;
                    UpdateRecord.EndDateTime = record.EndDateTime;
                    UpdateRecord.Period = record.Period;
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

        private void InsertTeacherBusy()
        {
            btnConfirmInsert.Enabled = false;

            if (mTeacherBusyDates.Count > 0)
            {
                #region 新增或更新教師不調代時段
                int PackageSize = 300;

                BackgroundWorker worker = new BackgroundWorker();

                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += (vsender, ve) => progressBarX1.Value = ve.ProgressPercentage;
                worker.DoWork += (vsender, ve) =>
                {
                    List<TeacherBusyDate> PackageRecords = new List<TeacherBusyDate>();

                    for (int i = 0; i < mTeacherBusyDates.Count; i++)
                    {
                        PackageRecords.Add(mTeacherBusyDates[i]);

                        if ((i > 0) && (i % PackageSize == 0))
                        {
                            InsertTeacherBusy(PackageRecords);
                            PackageRecords.Clear();
                        }

                        worker.ReportProgress((int)(((float)i / (float)mTeacherBusyDates.Count) * 100), "新增教師不調代時段中");
                    }

                    if (PackageRecords.Count > 0)
                    {
                        InsertTeacherBusy(PackageRecords);
                    }

                    worker.ReportProgress(100, "已成功新增或更新教師不調代時段共" + mTeacherBusyDates.Count + "筆");
                };

                worker.RunWorkerCompleted += (vsender, ve) =>
                {
                    MessageBox.Show("已成功新增或更新" + mTeacherBusyDates.Count + "筆教師不調代時段！");
                    mTeacherBusyDates.Clear();
                    mbook = new Workbook();
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
            InsertTeacherBusy();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}