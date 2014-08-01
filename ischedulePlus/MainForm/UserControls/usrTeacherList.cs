using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 教師清單
    /// </summary>
    public partial class usrTeacherList : UserControl
    {
        private string mSelectedSchoolYear = string.Empty;
        private string mSelectedSemester = string.Empty;
        private List<string> mTeacherNames = new List<string>();
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private string idSaveWho1 = string.Empty;
        private string idSaveWho2 = string.Empty;
        private string idSaveWho3 = string.Empty;
        private Node mSelectedNode = null;
        private List<TeacherEx> mTeachers = new List<TeacherEx>();

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public usrTeacherList()
        {
            InitializeComponent();
        }

        private void usrTeacherList_Load(object sender, EventArgs e)
        {
            menuExpand.Click += (vsender,ve) =>
            {
                Node nodeRoot = treeWho.Nodes[0];

                nodeRoot.Expand();

                nodeRoot.ExpandAll();
            };

            menuCollapse.Click += (vsender, ve) =>
            {
                treeWho.Nodes[0].Collapse();
            };

            CalendarEvents.TeacherUpdateEvent += (vsender, ve) => RefreshAll();

            CalendarEvents.SchoolYearSemesterChangeEvent += (vsender, ve) =>
            {
                btnSchoolYearSemester.Text = ve.SchoolYear + "學年度 第" + ve.Semester + "學期";

                treeWho.SelectedNode = null;

                RefreshAll();

                MainForm.Instance.ClearTeacherCalendar();
            };

            RefreshSchoolYearSemester();

            RefreshAll();
        }

        private void CalendarEvents_ReplaceEvent(object sender, EventArgs e)
        {
            SelectCalendar();
        }

        #region private function 

        private void RefreshSchoolYearSemester()
        {
            foreach (SchoolYearSemesterDate vSchoolYearSemesterDate in SchoolYearSemesterOption.Instance.SchoolYearSemesterDates)
            {
                string DisplaySchoolYearSemester = vSchoolYearSemesterDate.SchoolYear + "學年度 第" + vSchoolYearSemesterDate.Semester + "學期";

                if (SchoolYearSemesterOption.Instance.SchoolYear.Equals(vSchoolYearSemesterDate.SchoolYear) &&
                    SchoolYearSemesterOption.Instance.Semester.Equals(vSchoolYearSemesterDate.Semester))
                    btnSchoolYearSemester.Text = vSchoolYearSemesterDate.SchoolYear + "學年度 第" + vSchoolYearSemesterDate.Semester + "學期";

                ButtonItem Item = new ButtonItem(DisplaySchoolYearSemester, DisplaySchoolYearSemester);

                Item.Click += (vsender,ve)=>
                {
                    if (!Item.Text.Equals(btnSchoolYearSemester.Text))
                    {
                        SchoolYearSemesterOption.Instance.SchoolYear = vSchoolYearSemesterDate.SchoolYear;
                        SchoolYearSemesterOption.Instance.Semester = vSchoolYearSemesterDate.Semester;
                        SchoolYearSemesterOption.Instance.Save();
                    }
                };

                btnSchoolYearSemester.SubItems.Add(Item);
            }
        }

        /// <summary>
        /// 更新所有教師清單
        /// </summary>
        private void RefreshAll()
        {
            RefreshContent(string.Empty);
        }

        /// <summary>
        /// 判斷是否新增教師到左方TreeView中
        /// </summary>
        /// <param name="Who"></param>
        /// <returns></returns>
        private bool IsAddWho(string Who)
        {
            if (!string.IsNullOrWhiteSpace(Who) && !Who.Equals("無"))
            {
                //若搜尋字串為空白則全部顯示
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    return true;
                else
                    return Who.Contains(txtSearch.Text);
            }else
                return false;
        }

        /// <summary>
        /// 根據姓名更新教師列表，同時考量到關鍵字搜尋
        /// </summary>
        private void RefreshByName(string idWho)
        {
            mAccessHelper = Utility.AccessHelper;

            mTeachers = mAccessHelper.Select<TeacherEx>();
            mTeachers = mTeachers.SortByCode();

            //根據分課的科目進行分類
            Dictionary<string,string> TeacherNames = new Dictionary<string,string>();

            foreach (TeacherEx Teacher in mTeachers)
            {
                //若科目名稱不在字典中則新增
                if (!TeacherNames.ContainsKey(Teacher.FullTeacherName) 
                    &&　mTeacherNames.Contains(Teacher.FullTeacherName))
                    TeacherNames.Add(Teacher.FullTeacherName, Teacher.FullTeacherName);
            }

            treeWho.Nodes.Clear();

            Node nodeAll = new Node("所有教師");
            nodeAll.TagString = string.Empty;

            treeWho.Nodes.Add(nodeAll);

            foreach (string WhoName in TeacherNames.Keys)
            {
                if (WhoName.Equals("無"))
                    continue;

                TeacherEx whoPaint = mTeachers.Find(x => x.FullTeacherName.Equals(WhoName));

                if (whoPaint != null)
                {
                    if (IsAddWho(whoPaint.FullTeacherName) || 
                        IsAddWho(whoPaint.TeacherCode))
                    {
                        //string DisplayTeacherName = !string.IsNullOrEmpty(whoPaint.TeacherCode) ? whoPaint.FullTeacherName + "(" + whoPaint.TeacherCode + ")" : whoPaint.FullTeacherName;

                        Node nodeWho = new Node(whoPaint.FullTeacherName);
                        nodeWho.TagString = whoPaint.FullTeacherName;
                        nodeAll.Nodes.Add(nodeWho);
                    }
                }
            }

            nodeAll.Text = nodeAll.Text + "(" + (mTeacherNames.Count) + ")";
            nodeAll.Expand();
        }

        /// <summary>
        /// 根據教師編號更新教師清單，若傳入空白則更新所有教師清單
        /// </summary>
        /// <param name="idWho">教師編號</param>
        private void RefreshContent(string idWho)
        {
            mTeacherNames.Clear();

            string strStartDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterStartDate.ToShortDateString();
            string strEndDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterEndDate.ToShortDateString();

            string strSQL = "select distinct teacher_name from $scheduler.course_calendar where start_date_time>='" + strStartDate + "' and start_date_time<='" + strEndDate+"'";

            DataTable table = mQueryHelper.Select(strSQL);

            foreach (DataRow row in table.Rows)
                mTeacherNames.Add(row.Field<string>("teacher_name")); 

            RefreshByName(idWho);
        }

                /// <summary>
        /// 根據分課表編號更新教師清單
        /// </summary>
        /// <param name="EventID">分課表編號</param>
        private void RefreshEvent(string EventID)
        {
            //目前先所有更新，暫不支援單筆更新
            RefreshAll();        
        }
        
        /// <summary>
        /// 儲存分課表的教師編號
        /// </summary>
        /// <param name="EventID">分課表編號</param>
        private void SaveWho(string EventID)
        {
            //idSaveWho1 = schLocal.CEvents[EventID].TeacherID1;
            //idSaveWho2 = schLocal.CEvents[EventID].TeacherID2;
            //idSaveWho3 = schLocal.CEvents[EventID].TeacherID3;
        }     

        /// <summary>
        /// 根據教師編號更新教師清單
        /// </summary>
        private void RefreshSaveWho()
        {
            //目前先更新所有，不逐筆更新
            RefreshAll();
        }

        /// <summary>
        /// 取得選取值
        /// </summary>
        /// <returns></returns>
        private string GetSelectedValue()
        {
            Node SelectNode = treeWho.SelectedNode;

            if (SelectNode == null)
                return string.Empty;

            return SelectNode.TagString;
        }
        #endregion


        #region Event Handler
        /// <summary>
        /// 關鍵字改變時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshContent(string.Empty);
        }

        /// <summary>
        /// 處理點選右鍵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeWho_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string TagString = e.Node.TagString;

                if (e.Node.Text.StartsWith("所有"))
                {
                    menuExpand.Visible = true;
                    menuCollapse.Visible = true;
                    menuOpenNewLPView.Visible = false;
                }
                else if (!string.IsNullOrEmpty(TagString))
                {
                    menuExpand.Visible = false;
                    menuCollapse.Visible = false;
                    menuOpenNewLPView.Visible = true;
                }
                else
                {
                    menuExpand.Visible = false;
                    menuCollapse.Visible = false;
                    menuOpenNewLPView.Visible = false;
                }
            }
        }

        /// <summary>
        /// 點下節點
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeWho_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {

        }
        #endregion


        private void SelectCalendar()
        {
            if (mSelectedNode == null)
                return;

            string AssocID = mSelectedNode.TagString;

            if (!string.IsNullOrEmpty(AssocID))
            {
                MainForm.Instance.OpenTeacherCalendarList(CalendarType.Teacher, AssocID);
                MainForm.Instance.OpenTeacherCalendarContent(CalendarType.Teacher, AssocID);
            }
        }

        private void treeWho_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node == null)
                return;

            mSelectedNode = e.Node;

            SelectCalendar();
        }
    }
}