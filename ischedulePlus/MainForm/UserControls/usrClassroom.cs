using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 場地清單
    /// </summary>
    public partial class usrClassroomList : UserControl
    {
        private AccessHelper mAccessHelper = Utility.AccessHelper;
        private string mSelectedSchoolYear = string.Empty;
        private string mSelectedSemester = string.Empty;
        private List<SchoolYearSemesterDate> mSchoolYearSemesterDates = new List<SchoolYearSemesterDate>();
        private AccessHelper mHelper = Utility.AccessHelper;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private List<string> mClassroomNames = new List<string>();
        private Node mSelectedNode = null;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public usrClassroomList()
        {
            InitializeComponent();
        }

        private void usrClassroomList_Load(object sender, EventArgs e)
        {
            menuOpenNewLPView.Click += (vsender, ve) =>
            {
                string AssocID = GetSelectedValue();
            };

            menuExpand.Click += (vsender, ve) =>
            {
                Node nodeRoot = nodeTree.Nodes[0];

                nodeRoot.Expand();

                nodeRoot.ExpandAll();
            };

            menuCollapse.Click += (vsender, ve) =>
            {
                nodeTree.Nodes[0].Collapse();
            };

            CalendarEvents.SchoolYearSemesterChangeEvent += (vsender, ve) =>
            {
                btnSchoolYearSemester.Text = ve.SchoolYear + "學年度 第" + ve.Semester + "學期";
                RefreshAll();
                MainForm.Instance.ClearClassroomCalendar();
            };

            RefreshSchoolYearSemester();

            RefreshAll();
        }

        private void RefreshSchoolYearSemester()
        {
            foreach (SchoolYearSemesterDate vSchoolYearSemesterDate in SchoolYearSemesterOption.Instance.SchoolYearSemesterDates)
            {
                string DisplaySchoolYearSemester = vSchoolYearSemesterDate.SchoolYear + "學年度 第" + vSchoolYearSemesterDate.Semester + "學期";

                if (SchoolYearSemesterOption.Instance.SchoolYear.Equals(vSchoolYearSemesterDate.SchoolYear) &&
                    SchoolYearSemesterOption.Instance.Semester.Equals(vSchoolYearSemesterDate.Semester))
                    btnSchoolYearSemester.Text = vSchoolYearSemesterDate.SchoolYear + "學年度 第" + vSchoolYearSemesterDate.Semester + "學期";

                ButtonItem Item = new ButtonItem(DisplaySchoolYearSemester, DisplaySchoolYearSemester);

                Item.Click += (vsender, ve) =>
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

        private void SelectCalendar()
        {
            if (mSelectedNode == null)
               return;

            string AssocID = mSelectedNode.TagString;

            if (!string.IsNullOrEmpty(AssocID))
            {
                MainForm.Instance.OpenClassroomCalendarList(CalendarType.Classroom, AssocID);
                MainForm.Instance.OpenClassroomCalendarContent(CalendarType.Classroom, AssocID, false);
            }
        }

        private void CalendarEvents_ExchangeEvent(object sender, EventArgs e)
        {
            SelectCalendar();
        }

        #region private function
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
        /// <param name="Whom"></param>
        /// <returns></returns>
        private bool IsAddWhom(string Whom)
        {
            if (!string.IsNullOrWhiteSpace(Whom))
            {
                //若搜尋字串為空白則全部顯示
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    return true;
                else
                    return Whom.Contains(txtSearch.Text);
            }
            else
                return false;
        }

        /// <summary>
        /// 根據班級名稱更新班級列表，同時考量到關鍵字搜尋
        /// </summary>
        private void RefreshByName(string idWhom)
        {
            nodeTree.Nodes.Clear();

            Node nodeAll = new Node("所有場地");
            nodeAll.TagString = string.Empty;


            nodeTree.Nodes.Add(nodeAll);

            foreach (string ClassroomName in mClassroomNames)
            {
                if (IsAddWhom(ClassroomName))
                {
                    Node nodeClassroom = new Node(ClassroomName);
                    nodeClassroom.TagString = ClassroomName;
                    nodeAll.Nodes.Add(nodeClassroom);
                }
            }

            nodeAll.Text = nodeAll.Text + "(" + (mClassroomNames.Count) + ")";
            nodeAll.Expand();
        }

        /// <summary>
        /// 根據班級編號更新班級清單，若傳入空白則更新所有班級清單
        /// </summary>
        /// <param name="idWhom">教師編號</param>
        private void RefreshContent(string idWhom)
        {
            mClassroomNames.Clear();

            string strStartDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterStartDate.ToShortDateString();
            string strEndDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterEndDate.ToShortDateString();

            DataTable table = mQueryHelper.Select("select distinct classroom_name from $scheduler.course_calendar where start_date_time>='" + strStartDate + "' and start_date_time<='" + strEndDate + "' order by classroom_name");

                foreach (DataRow row in table.Rows)
                    mClassroomNames.Add(row.Field<string>("classroom_name"));

            RefreshByName(idWhom);
        }

        /// <summary>
        /// 根據分課表編號更新班級清單
        /// </summary>
        /// <param name="EventID">分課表編號</param>
        private void RefreshEvent(string EventID)
        {
            //目前先所有更新，暫不支援單筆更新
            RefreshAll();
        }

        /// <summary>
        /// 根據教師編號更新班級清單
        /// </summary>
        private void RefreshSaveWhom()
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
            Node SelectNode = nodeTree.SelectedNode;

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

        private void nodeTree_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node != null)
                mSelectedNode = e.Node;

            SelectCalendar();
        }
        #endregion
    }
}