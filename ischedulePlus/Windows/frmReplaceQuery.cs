using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.LogAgent;
using FISCA.Presentation;

namespace ischedulePlus
{
    /// <summary>
    /// 代課查詢
    /// </summary>
    public partial class frmReplaceQuery : FISCA.Presentation.Controls.BaseForm
    {
        private List<CalendarRecord> mSelectedCalendars = new List<CalendarRecord>();
        //private Subjects mSelectedSubjects = new Subjects();
        private Teacher mReplaceTeacher = null;
        private DecCalendar decCalendar = null;

        /// <summary>
        /// 代課查詢，傳入多筆行事曆
        /// </summary>
        /// <param name="vCalendarRecords"></param>
        public frmReplaceQuery(List<CalendarRecord> vCalendarRecords)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(vCalendarRecords))
            {
                MessageBox.Show("沒有選取的行事曆！");                

                this.Close();

                return;
            }

            InitializeComponent();

            mSelectedCalendars = vCalendarRecords;
        }

        private void frmReplaceQuery_Load(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (vsender, ve) =>
            {
                if (Calendar.Instance.Teachers.Values.Count == 0)
                    Calendar.Instance.RefreshTeachers();

                //mSelectedSubjects = mSelectedCalendars.GetCalendarSubjects();

                bool IsReplace = false;

                foreach (CalendarRecord vCalendar in mSelectedCalendars)
                    if (!string.IsNullOrEmpty(vCalendar.ReplaceID))
                        IsReplace = true;

                if (IsReplace)
                    throw new Exception("選取行事曆已經代過課！");

                Dictionary<string, Teacher> ReplaceTeachers = new Dictionary<string, Teacher>();

                #region 複製所有教師及教授科目
                foreach (string TeacherName in Calendar.Instance.Teachers.Keys)
                {
                    if (!ReplaceTeachers.ContainsKey(TeacherName))
                        ReplaceTeachers.Add(TeacherName, Calendar.Instance.Teachers[TeacherName]);
                }
                #endregion

                #region 找出交集的教師行事曆，並自清單中移除。
                List<CalendarRecord> Calendars = Calendar.Instance.FindIntersect(null, null, mSelectedCalendars);

                foreach (CalendarRecord vCalendar in Calendars)
                {
                    string TeacherName = vCalendar.TeacherName;

                    if (ReplaceTeachers.ContainsKey(TeacherName))
                        ReplaceTeachers.Remove(TeacherName);
                }
                #endregion

                #region 尋找時段忙碌的教師，並自清單中移除。
                List<TeacherBusy> TeacherBusys = Calendar.Instance
                    .FindBusyTeacher(null, mSelectedCalendars);

                IEnumerable<string> TeacherNames = TeacherBusys.Select(x => x.TeacherName);

                foreach (string TeacherName in TeacherNames)
                    if (ReplaceTeachers.ContainsKey(TeacherName))
                        ReplaceTeachers.Remove(TeacherName);
                #endregion

                //將教師排序
                List<Teacher> Teachers = ReplaceTeachers.Values
                              .ToList().SortByCode();

                ve.Result = Teachers;
            };

            worker.RunWorkerCompleted += (vsender, ve) =>
            {
                if (ve.Error != null)
                {
                    MessageBox.Show(ve.Error.Message);
                    this.Close();
                }
                else
                {
                    decCalendar = new DecCalendar(panelEx1);

                    List<Teacher> Teachers = ve.Result as List<Teacher>;

                    Teacher SelectedTeacher = Calendar.Instance.Teachers.ContainsKey(mSelectedCalendars[0].TeacherName)?
                        Calendar.Instance.Teachers[mSelectedCalendars[0].TeacherName]:null;

                    DisplayReplaceTeachers(Teachers,SelectedTeacher);
                    this.TitleText = "代課查詢";
                }
            };

            this.TitleText = "代課查詢 資料查詢中..";
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 顯示代課教師
        /// </summary>
        private void DisplayReplaceTeachers(
            List<Teacher> Teachers,
            Teacher SelectedTeacher)
        {
            string StartCode = string.Empty;
            
            if ((SelectedTeacher!=null) && 
                !string.IsNullOrWhiteSpace(SelectedTeacher.Code))
                StartCode = SelectedTeacher.Code.Substring(0, 1);

            grdReplace.Columns.Clear();

            DataGridViewColumn TeacherNameColumn = Extensions.CreateColumn("TeacherName", "教師名稱", 120, 12F);
            DataGridViewColumn TeacherCommentColumn = Extensions.CreateColumn("TeacherComment", "教師專長", 180, 12F);
            DataGridViewColumn TeacherCodeColumn = Extensions.CreateColumn("TeacherCode","教師代碼",100,12F);
            TeacherCodeColumn.Visible = false;

            grdReplace.Columns.Add(TeacherNameColumn);
            grdReplace.Columns.Add(TeacherCommentColumn);
            grdReplace.Columns.Add(TeacherCodeColumn);

            grdReplace.Rows.Clear();

            //教師姓名及註記
            foreach (Teacher vTeacher in Teachers)
            {
                int AddRowIndex = grdReplace.Rows.Add();
                DataGridViewRow Row = grdReplace.Rows[AddRowIndex];
                Row.Tag = vTeacher;
                grdReplace.Rows[AddRowIndex].SetValues(
                    vTeacher.Name,
                    vTeacher.Comment,
                    vTeacher.Code);
            }

            foreach (DataGridViewRow Row in grdReplace.Rows)
            {
                string TeacherCode = "" + Row.Cells[TeacherCodeColumn.Index].Value;

                if (!string.IsNullOrWhiteSpace(TeacherCode) &&
                   !string.IsNullOrWhiteSpace(StartCode))
                    if (TeacherCode.StartsWith(StartCode))
                    {
                        Row.Selected = true;
                        grdReplace.FirstDisplayedScrollingRowIndex = Row.Index;
                        break;
                    }
            }


            if (Teachers.Count > 0)
            {
                mReplaceTeacher = Teachers[0];
            }
        }

        /// <summary>
        /// 代課確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmReplace_Click(object sender, EventArgs e)
        {
            if (!(grdReplace.SelectedRows.Count == 1))
            {
                MessageBox.Show("請選擇一位代課教師！");
                return;
            }

            Teacher vTeacher = grdReplace.SelectedRows[0].Tag as Teacher;

            frmReplaceConfirm ReplaceConfirm = new frmReplaceConfirm(mSelectedCalendars, vTeacher);

            if (ReplaceConfirm.ShowDialog() == DialogResult.OK)
            {
                string Comment = ReplaceConfirm.Comment;
                string Absence = ReplaceConfirm.AbsenceName;

                List<CalendarRecord> vrecords = ReplaceConfirm.SelectedCalendars;

                Tuple<bool, string> result = Calendar.Instance.Replace(vrecords, vTeacher, Absence, Comment);

                if (!result.Item1)
                    MessageBox.Show(result.Item2);
                else
                {
                    StringBuilder strBuilder = new StringBuilder();

                    strBuilder.AppendLine("《請假課程》");
                    foreach (CalendarRecord vCalendar in vrecords)
                        strBuilder.AppendLine(vCalendar.ToString());
                    strBuilder.AppendLine("《代課教師》");
                    strBuilder.AppendLine(vTeacher.Name);
                    strBuilder.AppendLine("《假別註記》");
                    strBuilder.AppendLine("假別：" + Absence + ",註記：" + Comment);

                    ApplicationLog.Log(Logs.調代課,Logs.代課作業, strBuilder.ToString());

                    CalendarEvents.RaiseReplaceEvent();

                    MotherForm.SetStatusBarMessage("已成功執行代課！");

                    //#region 取出代課系統編號進行列印
                    //if (ReplaceConfirm.IsPrint)
                    //{
                    //    List<string> UIDs = mSelectedCalendars.Select(x => x.UID).ToList();

                    //    List<CalendarRecord> records = Calendar.Instance.FindReplaceRecords(UIDs);

                    //    Dictionary<string, List<CalendarRecord>> GroupRecords = new Dictionary<string, List<CalendarRecord>>();

                    //    foreach (CalendarRecord record in records)
                    //    {
                    //        string Key =
                    //        record.StartDateTime.ToShortDateString() + "-" +
                    //        record.FullSubject + "-" +
                    //        record.TeacherName;

                    //        if (!GroupRecords.ContainsKey(Key))
                    //            GroupRecords.Add(Key, new List<CalendarRecord>());

                    //        GroupRecords[Key].Add(record);
                    //    }

                    //    ExchangeReplaceReport.Instance.Print(GroupRecords);
                    //}
                    //#endregion
                }
            }

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdReplace_SelectionChanged(object sender, EventArgs e)
        {
            if (grdReplace.SelectedRows.Count == 1)
            {
                string TeacherName = "" + grdReplace.SelectedRows[0].Cells[0].Value;

                decCalendar.Type = CalendarType.Teacher;
                decCalendar.AssocID = TeacherName;
                decCalendar.UpdateContent();
            }
        }
    }
}