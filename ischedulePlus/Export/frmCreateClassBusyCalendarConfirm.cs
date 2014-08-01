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
    public partial class frmCreateClassBusyConfirm : FISCA.Presentation.Controls.BaseForm
    {
        private List<ClassBusyDate> mClassBusyDates = null;
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private Workbook mbook = null;

        public frmCreateClassBusyConfirm(
            List<ClassBusyDate> vClassBusyDates,
            Workbook vbook)
        {
            InitializeComponent();

            if (vClassBusyDates == null)
                throw new NullReferenceException("要新增的課程行事曆不得為空白！");

            if (vbook == null)
                throw new NullReferenceException("要檢視的課程行事曆產生報告不得為空白！");

            this.mClassBusyDates = vClassBusyDates;
            this.mbook = vbook;
        }

        private void frmCreateCourseCalendarConfirm_Load(object sender, EventArgs e)
        {
            lblCount.Text = "已產生班級不調代時段共" + mClassBusyDates.Count + "筆";
        }

        private void lblViewReport_Click(object sender, EventArgs e)
        {
            if (mbook == null)
                return;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "班級不調代時段產生報告";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            mbook.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void InsertClassBusy(List<ClassBusyDate> ClassBusyDates)
        {
            List<string> strConditions = new List<string>();

            foreach (ClassBusyDate record in ClassBusyDates)
            {
                string strDateTime = record.BeginDateTime.GetDateTimeString();

                strConditions.Add("(to_char(begin_date_time,'yyyy/mm/dd HH24:MI')='" + strDateTime + "' and ref_class_id=" + record.ClassID + ")");
            }

            string strSQL = "select uid from $scheduler.class_busy_date where " + string.Join(" or ", strConditions.ToArray());

            DataTable table = mQueryHelper.Select(strSQL);

            List<string> UIDs = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                UIDs.Add(row.Field<string>("uid"));
            }

            List<ClassBusyDate> ExistClassBusyDates = new List<ClassBusyDate>();
            
            if (UIDs.Count>0)
                ExistClassBusyDates = mAccessHelper.Select<ClassBusyDate>("uid in (" + string.Join(",", UIDs.ToArray()) + ")");

            Dictionary<string, ClassBusyDate> DicClassBusyDates = new Dictionary<string, ClassBusyDate>();

            foreach (ClassBusyDate vClassBusyDate in ExistClassBusyDates)
            {
                string Key = vClassBusyDate.BeginDateTime.GetDateTimeString() + "^_^" + vClassBusyDate.ClassID;

                if (!DicClassBusyDates.ContainsKey(Key))
                    DicClassBusyDates.Add(Key, vClassBusyDate);
            }

            List<ClassBusyDate> InsertRecords = new List<ClassBusyDate>();

            List<ClassBusyDate> UpdateRecords = new List<ClassBusyDate>();

            foreach (ClassBusyDate record in ClassBusyDates)
            {
                string Key = record.BeginDateTime.GetDateTimeString() + "^_^" + record.ClassID;

                if (DicClassBusyDates.ContainsKey(Key))
                {
                    ClassBusyDate UpdateRecord = DicClassBusyDates[Key];

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

            if (InsertRecords.Count > 0)
                mAccessHelper.InsertValues(InsertRecords);
        }

        private void InsertCourseCalendar()
        {
            btnConfirmInsert.Enabled = false;

            if (mClassBusyDates.Count > 0)
            {
                #region 新增班級不調代時段
                int PackageSize = 300;

                BackgroundWorker worker = new BackgroundWorker();

                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += (vsender, ve) => progressBarX1.Value = ve.ProgressPercentage;
                worker.DoWork += (vsender, ve) =>
                {
                    List<ClassBusyDate> PackageRecords = new List<ClassBusyDate>();

                    for (int i = 0; i < mClassBusyDates.Count; i++)
                    {
                        PackageRecords.Add(mClassBusyDates[i]);

                        if ((i > 0) && (i % PackageSize == 0))
                        {
                            InsertClassBusy(PackageRecords);
                            PackageRecords.Clear();
                        }

                        worker.ReportProgress((int)(((float)i / (float)mClassBusyDates.Count) * 100), "新增班級不調代時段中");
                    }

                    if (PackageRecords.Count > 0)
                        InsertClassBusy(PackageRecords);

                    worker.ReportProgress(100, "已成功新增班級不調代時段共" + mClassBusyDates.Count + "筆");
                };

                worker.RunWorkerCompleted += (vsender, ve) =>
                {
                    MessageBox.Show("已成功新增" + mClassBusyDates.Count + "筆班級不調代時段！");
                    mClassBusyDates.Clear();
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
            InsertCourseCalendar();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}