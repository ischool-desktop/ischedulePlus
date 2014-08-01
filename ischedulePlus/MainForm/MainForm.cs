using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using FISCA.Presentation;
using FISCA.UDT;

namespace ischedulePlus
{
    public class MainForm : FISCA.Presentation.BlankPanel
    {
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.SuperTabControl tabContent;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.Panel pnlWhoList;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdTeacherCalendar;
        private System.Windows.Forms.Panel panel5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblTeacher;
        private DevComponents.DotNetBar.ButtonX btnTeacherEventExpand;
        private DevComponents.DotNetBar.ExpandableSplitter splTeacher;
        private System.Windows.Forms.Panel pnlWhoLPView;
        private DevComponents.DotNetBar.TabControl tabTeacherCalendar;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanelTeacher;
        private DevComponents.DotNetBar.TabItem tabItemTeacher;
        private System.ComponentModel.IContainer components;
        private DevComponents.DotNetBar.SuperTabItem tabTeacher;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.ExpandableSplitter splClass;
        private System.Windows.Forms.Panel pnlWhomLPView;
        private DevComponents.DotNetBar.TabControl tabClassCalendar;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanelClass;
        private DevComponents.DotNetBar.TabItem tabItemClass;
        private System.Windows.Forms.Panel pnlWhomList;
        private System.Windows.Forms.Panel panel10;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdClassCalendar;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblClass;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnClassEventExpand;
        private DevComponents.DotNetBar.SuperTabItem tabClass;
        private DevComponents.DotNetBar.SuperTabItem tabClassroom;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.NavigationPane LeftNavigationPanel;
        private DevComponents.DotNetBar.NavigationPanePanel pnlClassroom;
        private DevComponents.DotNetBar.NavigationPanePanel pnlClass;
        private DevComponents.DotNetBar.ButtonItem btnClass;
        private DevComponents.DotNetBar.NavigationPanePanel pnlTeacher;
        private DevComponents.DotNetBar.ButtonItem btnTeacher;
        private static MainForm mMainForm;
        public usrTeacherList TeacherList { get; set; }
        public usrClassList ClassList { get; set; }
        public usrClassroomList ClassroomList { get; set; }
        private DevComponents.DotNetBar.NavigationPanePanel pnlPlace;
        private DevComponents.DotNetBar.ButtonItem btnClassroom;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem tabPlace;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private Panel panel1;
        private Panel panel6;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel7;
        private DevComponents.DotNetBar.SuperTabItem superTabItem4;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        private Panel panel7;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private Panel panel8;
        private Panel panel9;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Panel panel11;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel6;
        private Panel panel12;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private Panel panel13;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter3;
        private Panel panel14;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem3;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter4;
        private DevComponents.DotNetBar.NavigationPane navigationPane1;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel8;
        private Panel pnlWhereList;
        private Panel panel15;
        private Panel panel16;
        private DevComponents.DotNetBar.LabelX lblClassroom;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.ButtonX btnClassroomEventExpand;
        private DevComponents.DotNetBar.ExpandableSplitter splClassroom;
        private Panel pnlWhereLPView;
        private DevComponents.DotNetBar.TabControl tabClassroomCalendar;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanelClassroom;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdPlaceCalendar;

        private DecCalendarList mTeacherList = null;
        private DecCalendarList mClassList = null;
        private DecCalendarList mClassroomList = null;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn colClassStatus;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private DataGridViewTextBoxColumn colSubject;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colSolutionCount;
        private DataGridViewTextBoxColumn colWeekDay;
        private DataGridViewTextBoxColumn colPeriodNo;
        private DataGridViewTextBoxColumn colSubjectName;
        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colLength;
        private DataGridViewTextBoxColumn colWhoName;
        private AccessHelper mAccessHelper = Utility.AccessHelper;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Group = "調代課";

            mTeacherList = new DecCalendarList(this.grdTeacherCalendar);
            mClassList = new DecCalendarList(this.grdClassCalendar);
            mClassroomList = new DecCalendarList(this.grdPlaceCalendar);

            LoadResourceList();
            grdTeacherCalendar.AutoGenerateColumns = false;
            grdClassCalendar.AutoGenerateColumns = false;
            grdPlaceCalendar.AutoGenerateColumns = false;

            btnTeacher.Click += (sender, e) => tabContent.SelectedTab = tabTeacher;
            btnClass.Click += (sender, e) => tabContent.SelectedTab = tabClass;
            btnClassroom.Click += (sender, e) => tabContent.SelectedTab = tabPlace;

            CalendarEvents.PeriodSelected += CalendarEvents_PeriodSelected;

            this.btnTeacherEventExpand.Click += (vsender, ve) =>
            {
                if (splTeacher.Expanded)
                {
                    //寫入紀錄(目前顯示欄位)
                    btnTeacherEventExpand.Text = "<<";
                    btnTeacherEventExpand.Tooltip = "還原";
                    splTeacher.Expanded = false;
                }
                else
                {
                    btnTeacherEventExpand.Text = ">>";
                    btnTeacherEventExpand.Tooltip = "最大化";
                    splTeacher.Expanded = true;
                }
            };

            this.btnClassEventExpand.Click += (vsender, ve) =>
            {
                if (splClass.Expanded)
                {
                    //寫入紀錄(目前顯示欄位)
                    btnClassEventExpand.Text = "<<";
                    btnClassEventExpand.Tooltip = "還原";
                    splClass.Expanded = false;
                }
                else
                {
                    btnClassEventExpand.Text = ">>";
                    btnClassEventExpand.Tooltip = "最大化";
                    splClass.Expanded = true;
                }
            };

            this.btnClassroomEventExpand.Click += (vsender, ve) =>
            {
                if (splClassroom.Expanded)
                {
                    //寫入紀錄(目前顯示欄位)
                    btnClassroomEventExpand.Text = "<<";
                    btnClassroomEventExpand.Tooltip = "還原";
                    splClassroom.Expanded = false;
                }
                else
                {
                    btnClassroomEventExpand.Text = ">>";
                    btnClassroomEventExpand.Tooltip = "最大化";
                    splClassroom.Expanded = true;
                }
            };
        }

        private void CalendarEvents_PeriodSelected(object sender, PeriodEventArgs e)
        {
            grdTeacherCalendar.SelectionChanged -= grdTeacherCalendar_SelectionChanged;
            grdClassCalendar.SelectionChanged -= grdClassCalendar_SelectionChanged;
            grdPlaceCalendar.SelectionChanged -= grdClassroomCalendar_SelectionChanged;

            List<string> CalendarUIDs = e.Value.Select(x=>x.UID).ToList();

            if (tabTeacher.IsSelected)
            {
               foreach(DataGridViewRow Row in grdTeacherCalendar.Rows)
               {
                   CalendarRecord vCalendar = Row.DataBoundItem as CalendarRecord;

                   Row.Selected = CalendarUIDs.Contains(vCalendar.UID);
               }                
            }else if (tabClass.IsSelected)
            {
               foreach(DataGridViewRow Row in grdClassCalendar.Rows)
               {
                   CalendarRecord vCalendar = Row.DataBoundItem as CalendarRecord;
                   Row.Selected = CalendarUIDs.Contains(vCalendar.UID);
               }
            }
            else if (tabPlace.IsSelected)
            {
                foreach (DataGridViewRow Row in grdPlaceCalendar.Rows)
                {
                    CalendarRecord vCalendar = Row.DataBoundItem as CalendarRecord;
                    Row.Selected = CalendarUIDs.Contains(vCalendar.UID);
                } 
            }

            grdTeacherCalendar.SelectionChanged += grdTeacherCalendar_SelectionChanged;
            grdClassCalendar.SelectionChanged += grdClassCalendar_SelectionChanged;
            grdPlaceCalendar.SelectionChanged += grdClassroomCalendar_SelectionChanged;
        }

        /// <summary>
        /// 清除教師行事曆
        /// </summary>
        public void ClearTeacherCalendar()
        {
            lblTeacher.Text = string.Empty;
            mTeacherList.Clear();
            Utility.CloseCalendarView(tabTeacherCalendar);
        }

        /// <summary>
        /// 清除班級行事曆
        /// </summary>
        public void ClearClassCalendar()
        {
            lblClass.Text = string.Empty;
            mClassList.Clear();
            Utility.CloseCalendarView(tabClassCalendar);
        }

        /// <summary>
        /// 清除場地行事曆
        /// </summary>
        public void ClearClassroomCalendar()
        {
            lblClassroom.Text = string.Empty;
            mClassroomList.Clear();
            Utility.CloseCalendarView(tabClassroomCalendar);
        }

        /// <summary>
        /// 設定教師行事曆清單
        /// </summary>
        /// <param name="Calednars"></param>
        public void OpenTeacherCalendarList(CalendarType CalendarType,string AssocID)
        {
            mTeacherList.DataGrid.SelectionChanged -= grdTeacherCalendar_SelectionChanged;
            mTeacherList.CalendarType = CalendarType;
            mTeacherList.AssocID = AssocID;
            mTeacherList.UpdateContent();
            mTeacherList.DataGrid.SelectionChanged += grdTeacherCalendar_SelectionChanged;
        }

        /// <summary>
        /// 設定班級行事曆清單
        /// </summary>
        /// <param name="Calendars"></param>
        public void OpenClassCalendarList(CalendarType CalendarType, string AssocID)
        {
            mClassList.DataGrid.SelectionChanged -= grdClassCalendar_SelectionChanged;
            mClassList.CalendarType = CalendarType;
            mClassList.AssocID = AssocID;
            mClassList.UpdateContent();
            mClassList.DataGrid.SelectionChanged += grdClassCalendar_SelectionChanged;
        }

        /// <summary>
        /// 設定場地行事曆清單
        /// </summary>
        /// <param name="Calendars"></param>
        public void OpenClassroomCalendarList(CalendarType CalendarType, string AssocID)
        {
            mClassroomList.DataGrid.SelectionChanged -= grdClassroomCalendar_SelectionChanged;
            mClassroomList.CalendarType = CalendarType;
            mClassroomList.AssocID = AssocID;
            mClassroomList.UpdateContent();
            mClassroomList.DataGrid.SelectionChanged += grdClassroomCalendar_SelectionChanged;
        }

        /// <summary>
        /// 更新教師行事曆內容
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="AssocID"></param>
        public void OpenTeacherCalendarContent(
            CalendarType AssocType,
            string AssocID
            ,bool OpenNew=false)
        {
            Stopwatch vWatch = Stopwatch.StartNew();

            TabItem SelectedTab = null;
            TabControlPanel SelectedPanel = null;
            DecCalendar vDecCalendar = null;

            //假設不是開新分頁，強制指到第一頁。
            if (!OpenNew)
            {
                SelectedTab = tabTeacherCalendar.Tabs[0];
                SelectedPanel = SelectedTab.AttachedControl as TabControlPanel;
                tabTeacherCalendar.SelectedTab = SelectedTab;  
            }
            else
            {
                bool IsFind = false;

                #region 尋找是否有現有資料表
                if (tabTeacherCalendar.Tabs.Count >1)
                {
                    for(int i=1;i<tabTeacherCalendar.Tabs.Count;i++)
                    {
                        TabItem vTabItem = tabTeacherCalendar.Tabs[i];

                        if (vTabItem.Visible.Equals(false))
                        {
                            SelectedTab = vTabItem;
                            SelectedPanel = SelectedTab.AttachedControl as TabControlPanel;
                            tabTeacherCalendar.SelectedTab = SelectedTab;
                            IsFind = true;
                            break;
                        }
                    }
                }
                #endregion

                if (!IsFind)
                {
                    SelectedTab = tabTeacherCalendar.CreateTab(AssocID);
                    SelectedTab.CloseButtonVisible = true;

                    tabTeacherCalendar.SelectedTab = SelectedTab;
                    SelectedPanel = tabTeacherCalendar.SelectedPanel;
                }
            }

            if (SelectedPanel.Tag == null)
                vDecCalendar = new DecCalendar(SelectedPanel);

            SelectedTab.Text = AssocID;

            //取得功課表
            vDecCalendar = SelectedPanel.Tag as DecCalendar;
            vDecCalendar.Type = AssocType;
            vDecCalendar.AssocID = AssocID;
            vDecCalendar.UpdateContent();                   //在指定資料來源時清空內容

            if (!SelectedTab.Visible)
            {
                SelectedTab.Visible = true;
                SelectedPanel.Visible = true;
            }

            vWatch.Stop();
        }

        /// <summary>
        /// 更新班級行事曆內容
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="AssocID"></param>
        public void OpenClassCalendarContent(
            CalendarType AssocType,
            string AssocID,
            bool OpenNew = false)
        {
            TabItem SelectedTab = null;
            TabControlPanel SelectedPanel = null;
            DecCalendar vDecCalendar = null;

            //假設不是開新分頁，強制指到第一頁。
            if (!OpenNew)
            {
                SelectedTab = tabClassCalendar.Tabs[0];
                SelectedPanel = SelectedTab.AttachedControl as TabControlPanel;
                tabClassCalendar.SelectedTab = SelectedTab;
            }
            else
            {
                bool IsFind = false;

                if (tabClassCalendar.Tabs.Count > 1)
                {
                    for (int i = 1; i < tabClassCalendar.Tabs.Count; i++)
                    {
                        TabItem vTabItem = tabClassCalendar.Tabs[i];

                        if (vTabItem.Visible.Equals(false))
                        {
                            SelectedTab = vTabItem;
                            SelectedPanel = SelectedTab.AttachedControl as TabControlPanel;

                            tabClassCalendar.SelectedTab = SelectedTab;
                            IsFind = true;
                            break;
                        }
                    }
                }

                if (!IsFind)
                {
                    SelectedTab = tabClassCalendar.CreateTab(AssocID);
                    SelectedTab.CloseButtonVisible = true;
                    tabClassCalendar.SelectedTab = SelectedTab;
                    SelectedPanel = tabClassCalendar.SelectedPanel;
                }
            }

            if (SelectedPanel.Tag == null)
                vDecCalendar = new DecCalendar(SelectedPanel);

            DateTime StartDate = SchoolYearSemesterOption.Instance.StartDate;
            DateTime EndDate = SchoolYearSemesterOption.Instance.EndDate;

            string DisplayText = Utility.GetAssocNote(AssocType, AssocID) + " " + StartDate.Month + "/" + StartDate.Day + "~" + EndDate.Month + "/" + EndDate.Day;
            SelectedTab.Text = AssocID;

            //取得功課表
            vDecCalendar = SelectedPanel.Tag as DecCalendar;
            vDecCalendar.Type = AssocType;
            vDecCalendar.AssocID = AssocID;
            vDecCalendar.UpdateContent();                //在指定資料來源時清空內容

            if (!SelectedTab.Visible)
            {
                SelectedTab.Visible = true;
                SelectedPanel.Visible = true;
            }
        }

        /// <summary>
        /// 更新場地行事曆內容
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="AssocID"></param>
        public void OpenClassroomCalendarContent(
            CalendarType AssocType,
            string AssocID,
            bool OpenNew=false)
        {
            TabItem SelectedTab = null;
            TabControlPanel SelectedPanel = null;
            DecCalendar vDecCalendar = null;

            //假設不是開新分頁，強制指到第一頁。
            if (!OpenNew)
            {
                SelectedTab = tabClassroomCalendar.Tabs[0];
                SelectedPanel = SelectedTab.AttachedControl as TabControlPanel;
                tabClassroomCalendar.SelectedTab = SelectedTab;
            }
            else
            {
                bool IsFind = false;

                if (tabClassroomCalendar.Tabs.Count > 1)
                {
                    for (int i = 1; i < tabClassroomCalendar.Tabs.Count; i++)
                    {
                        TabItem vTabItem = tabClassroomCalendar.Tabs[i];

                        if (vTabItem.Visible.Equals(false))
                        {
                            SelectedTab = vTabItem;
                            SelectedPanel = SelectedTab.AttachedControl as TabControlPanel;

                            tabClassroomCalendar.SelectedTab = SelectedTab;
                            IsFind = true;
                            break;
                        }
                    }
                }

                if (!IsFind)
                {
                    SelectedTab = tabClassroomCalendar.CreateTab(AssocID);
                    SelectedTab.CloseButtonVisible = true;
                    tabClassroomCalendar.SelectedTab = SelectedTab;
                    SelectedPanel = tabClassroomCalendar.SelectedPanel;
                }
            }

            if (SelectedPanel.Tag == null)
                vDecCalendar = new DecCalendar(SelectedPanel);

            DateTime StartDate = SchoolYearSemesterOption.Instance.StartDate;
            DateTime EndDate = SchoolYearSemesterOption.Instance.EndDate;

            string DisplayText = Utility.GetAssocNote(AssocType, AssocID) + " " + StartDate.Month + "/" + StartDate.Day + "~" + EndDate.Month +"/" + EndDate.Day;
            SelectedTab.Text = AssocID;

            //取得功課表
            vDecCalendar = SelectedPanel.Tag as DecCalendar;
            vDecCalendar.Type = AssocType;
            vDecCalendar.AssocID = AssocID;
            vDecCalendar.UpdateContent();                //在指定資料來源時清空內容

            if (!SelectedTab.Visible)
            {
                SelectedTab.Visible = true;
                SelectedPanel.Visible = true;
            }
        }

        /// <summary>
        /// 取得教師選取行事曆
        /// </summary>
        /// <returns></returns>
        public List<CalendarRecord> GetTeacherSelectedCalendar()
        {
            List<CalendarRecord> records = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in grdTeacherCalendar.SelectedRows)
            {
                CalendarRecord record = Row.DataBoundItem as CalendarRecord;
                records.Add(record);
            }

            return records;
        }

        /// <summary>
        /// 取得班級選取行事曆
        /// </summary>
        /// <returns></returns>
        public List<CalendarRecord> GetClassSelectedCalendar()
        {
            List<CalendarRecord> records = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in grdClassCalendar.SelectedRows)
            {
                CalendarRecord record = Row.DataBoundItem as CalendarRecord;
                records.Add(record);
            }

            return records;
        }

        /// <summary>
        /// 取得場地選取行事曆
        /// </summary>
        /// <returns></returns>
        public List<CalendarRecord> GetClassroomSelectedCalendar()
        {
            List<CalendarRecord> records = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in grdPlaceCalendar.SelectedRows)
            {
                CalendarRecord record = Row.DataBoundItem as CalendarRecord;
                records.Add(record);
            }

            return records;
        }

        private void grdTeacherCalendar_SelectionChanged(object sender, EventArgs e)
        {
            if (!mTeacherList.IsUpdating)
            {
                List<CalendarRecord> SelectedCalendars = GetTeacherSelectedCalendar();

                MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Enable = Permissions.代課查詢權限 && SelectedCalendars.CanQueryReplace();
                MotherForm.RibbonBarItems["調代課", "調代課"]["缺課"].Enable = Permissions.代課查詢權限 && SelectedCalendars.CanQueryReplace();
                MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Enable = Permissions.取消代課權限 && SelectedCalendars.CanCancelReplace() ;
                MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Enable = Permissions.取消調課查詢權限 &&　SelectedCalendars.CanCancelExchange();

                DecCalendar decTeacherCalendar = tabTeacherCalendar.SelectedPanel.Tag as DecCalendar;

                if (decTeacherCalendar != null)
                {
                    decTeacherCalendar.SelectedCalendars = SelectedCalendars;
                    decTeacherCalendar.UpdateUI();
                }
            }
        }

        private void grdClassCalendar_SelectionChanged(object sender, EventArgs e)
        {
            if (!mClassList.IsUpdating)
            {
                List<CalendarRecord> SelectedCalendars = GetClassSelectedCalendar();

                MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Enable = Permissions.代課查詢權限 && SelectedCalendars.CanQueryReplace();
                MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Enable = Permissions.取消代課權限 && SelectedCalendars.CanCancelReplace();
                MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Enable = Permissions.取消調課查詢權限 && SelectedCalendars.CanCancelExchange();


                DecCalendar decClassCalendar = tabClassCalendar.SelectedPanel.Tag as DecCalendar;

                if (decClassCalendar != null)
                {
                    //若選取超過一堂則進行多堂調課判斷
                    if (SelectedCalendars.Count > 1)
                    {
                        //若能進行多堂課則指定，若不能則清空選取內容
                        if (decClassCalendar.IsCanMultipleExchange(SelectedCalendars))
                        {
                            decClassCalendar.SelectedCalendars = SelectedCalendars;
                            decClassCalendar.UpdateUI();
                        }
                        else
                        {
                            decClassCalendar.SelectedCalendars = new List<CalendarRecord>();
                            decClassCalendar.UpdateUI();
                        }
                    }
                    else
                    {
                        decClassCalendar.SelectedCalendars = SelectedCalendars;
                        decClassCalendar.UpdateUI();
                    }
                }
            }
        }

        private void grdClassroomCalendar_SelectionChanged(object sender, EventArgs e)
        {
            if (!mClassroomList.IsUpdating)
            {
                List<CalendarRecord> SelectedCalendars = GetClassroomSelectedCalendar();

                MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Enable = Permissions.代課查詢權限 && SelectedCalendars.CanQueryReplace();
                MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Enable = Permissions.取消代課權限 && SelectedCalendars.CanCancelReplace();
                MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Enable = Permissions.取消調課查詢權限 && SelectedCalendars.CanCancelExchange();

                DecCalendar decClassroomCalendar = tabClassroomCalendar.SelectedPanel.Tag as DecCalendar;

                if (decClassroomCalendar != null)
                {
                    decClassroomCalendar.SelectedCalendars = SelectedCalendars;
                    decClassroomCalendar.UpdateUI();
                }
            }
        }

        /// <summary>
        /// 載入資源列表
        /// </summary>
        private void LoadResourceList()
        {
            TeacherList = new usrTeacherList();
            TeacherList.Dock = DockStyle.Fill;
            pnlTeacher.Controls.Add(TeacherList);

            ClassList = new usrClassList();
            ClassList.Dock = DockStyle.Fill;
            pnlClass.Controls.Add(ClassList);

            ClassroomList = new usrClassroomList();
            ClassroomList.Dock = DockStyle.Fill;
            pnlPlace.Controls.Add(ClassroomList);
        }

        /// <summary>
        /// 取得實體
        /// </summary>
        public static MainForm Instance
        {
            get
            {
                if (mMainForm == null)
                {
                    mMainForm = new MainForm();
                }

                return mMainForm;
            }
        }

        /// <summary>
        /// 取得目前選取的類別
        /// </summary>
        /// <returns></returns>
        public string GetSelectedType()
        {
            if (tabTeacher.IsSelected)
                return "Teacher";
            else if (tabClass.IsSelected)
                return "Class";
            else if (tabPlace.IsSelected)
                return "Classroom";
            else
                return string.Empty;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabContent = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.splClass = new DevComponents.DotNetBar.ExpandableSplitter();
            this.pnlWhomLPView = new System.Windows.Forms.Panel();
            this.tabClassCalendar = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanelClass = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemClass = new DevComponents.DotNetBar.TabItem(this.components);
            this.pnlWhomList = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.grdClassCalendar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colClassStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lblClass = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnClassEventExpand = new DevComponents.DotNetBar.ButtonX();
            this.tabClass = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.pnlWhoList = new System.Windows.Forms.Panel();
            this.grdTeacherCalendar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolutionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeekDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblTeacher = new DevComponents.DotNetBar.LabelX();
            this.btnTeacherEventExpand = new DevComponents.DotNetBar.ButtonX();
            this.splTeacher = new DevComponents.DotNetBar.ExpandableSplitter();
            this.pnlWhoLPView = new System.Windows.Forms.Panel();
            this.tabTeacherCalendar = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanelTeacher = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItemTeacher = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabTeacher = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabControlPanel8 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.pnlWhereList = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.grdPlaceCalendar = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel16 = new System.Windows.Forms.Panel();
            this.lblClassroom = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.btnClassroomEventExpand = new DevComponents.DotNetBar.ButtonX();
            this.splClassroom = new DevComponents.DotNetBar.ExpandableSplitter();
            this.pnlWhereLPView = new System.Windows.Forms.Panel();
            this.tabClassroomCalendar = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanelClassroom = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabClassroom = new DevComponents.DotNetBar.SuperTabItem();
            this.tabPlace = new DevComponents.DotNetBar.SuperTabItem();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.LeftNavigationPanel = new DevComponents.DotNetBar.NavigationPane();
            this.pnlTeacher = new DevComponents.DotNetBar.NavigationPanePanel();
            this.btnTeacher = new DevComponents.DotNetBar.ButtonItem();
            this.pnlClassroom = new DevComponents.DotNetBar.NavigationPanePanel();
            this.pnlClass = new DevComponents.DotNetBar.NavigationPanePanel();
            this.btnClass = new DevComponents.DotNetBar.ButtonItem();
            this.pnlPlace = new DevComponents.DotNetBar.NavigationPanePanel();
            this.btnClassroom = new DevComponents.DotNetBar.ButtonItem();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel13 = new System.Windows.Forms.Panel();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.expandableSplitter3 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new System.Windows.Forms.Panel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.expandableSplitter4 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.navigationPane1 = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel1 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.ContentPanePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabContent)).BeginInit();
            this.tabContent.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.pnlWhomLPView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabClassCalendar)).BeginInit();
            this.tabClassCalendar.SuspendLayout();
            this.pnlWhomList.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClassCalendar)).BeginInit();
            this.panel3.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.pnlWhoList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTeacherCalendar)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnlWhoLPView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTeacherCalendar)).BeginInit();
            this.tabTeacherCalendar.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            this.superTabControlPanel8.SuspendLayout();
            this.pnlWhereList.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlaceCalendar)).BeginInit();
            this.panel16.SuspendLayout();
            this.pnlWhereLPView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabClassroomCalendar)).BeginInit();
            this.tabClassroomCalendar.SuspendLayout();
            this.LeftNavigationPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panel11.SuspendLayout();
            this.navigationPane1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanePanel
            // 
            this.ContentPanePanel.Controls.Add(this.panel2);
            this.ContentPanePanel.Location = new System.Drawing.Point(0, 163);
            this.ContentPanePanel.Size = new System.Drawing.Size(1016, 504);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 504);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabContent);
            this.panel4.Controls.Add(this.expandableSplitter1);
            this.panel4.Controls.Add(this.LeftNavigationPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1016, 504);
            this.panel4.TabIndex = 2;
            // 
            // tabContent
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabContent.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabContent.ControlBox.MenuBox.Name = "";
            this.tabContent.ControlBox.Name = "";
            this.tabContent.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabContent.ControlBox.MenuBox,
            this.tabContent.ControlBox.CloseBox});
            this.tabContent.Controls.Add(this.superTabControlPanel1);
            this.tabContent.Controls.Add(this.superTabControlPanel2);
            this.tabContent.Controls.Add(this.superTabControlPanel4);
            this.tabContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContent.Location = new System.Drawing.Point(209, 0);
            this.tabContent.Name = "tabContent";
            this.tabContent.ReorderTabsEnabled = true;
            this.tabContent.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.tabContent.SelectedTabIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(807, 504);
            this.tabContent.TabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabContent.TabIndex = 11;
            this.tabContent.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabTeacher,
            this.tabClass,
            this.tabPlace});
            this.tabContent.TabsVisible = false;
            this.tabContent.Text = "superTabControl1";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.splClass);
            this.superTabControlPanel2.Controls.Add(this.pnlWhomList);
            this.superTabControlPanel2.Controls.Add(this.pnlWhomLPView);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(807, 504);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabClass;
            // 
            // splClass
            // 
            this.splClass.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClass.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClass.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.splClass.Dock = System.Windows.Forms.DockStyle.Right;
            this.splClass.ExpandableControl = this.pnlWhomLPView;
            this.splClass.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClass.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClass.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splClass.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splClass.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splClass.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splClass.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splClass.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splClass.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.splClass.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.splClass.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.splClass.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.splClass.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClass.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClass.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splClass.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splClass.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClass.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClass.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splClass.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splClass.Location = new System.Drawing.Point(204, 0);
            this.splClass.Name = "splClass";
            this.splClass.Size = new System.Drawing.Size(3, 504);
            this.splClass.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.splClass.TabIndex = 2;
            this.splClass.TabStop = false;
            // 
            // pnlWhomLPView
            // 
            this.pnlWhomLPView.Controls.Add(this.tabClassCalendar);
            this.pnlWhomLPView.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWhomLPView.Location = new System.Drawing.Point(207, 0);
            this.pnlWhomLPView.Name = "pnlWhomLPView";
            this.pnlWhomLPView.Size = new System.Drawing.Size(600, 504);
            this.pnlWhomLPView.TabIndex = 0;
            // 
            // tabClassCalendar
            // 
            this.tabClassCalendar.AutoCloseTabs = true;
            this.tabClassCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabClassCalendar.CanReorderTabs = true;
            this.tabClassCalendar.CloseButtonOnTabsVisible = true;
            this.tabClassCalendar.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabClassCalendar.Controls.Add(this.tabControlPanelClass);
            this.tabClassCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClassCalendar.Location = new System.Drawing.Point(0, 0);
            this.tabClassCalendar.Name = "tabClassCalendar";
            this.tabClassCalendar.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.tabClassCalendar.SelectedTabIndex = -1;
            this.tabClassCalendar.Size = new System.Drawing.Size(600, 504);
            this.tabClassCalendar.TabIndex = 2;
            this.tabClassCalendar.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabClassCalendar.Tabs.Add(this.tabItemClass);
            this.tabClassCalendar.Text = "tabControl1";
            this.tabClassCalendar.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabCalendar_TabItemClose);
            // 
            // tabControlPanelClass
            // 
            this.tabControlPanelClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanelClass.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanelClass.Name = "tabControlPanelClass";
            this.tabControlPanelClass.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanelClass.Size = new System.Drawing.Size(600, 476);
            this.tabControlPanelClass.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanelClass.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanelClass.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanelClass.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanelClass.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanelClass.Style.GradientAngle = 90;
            this.tabControlPanelClass.TabIndex = 1;
            this.tabControlPanelClass.TabItem = this.tabItemClass;
            // 
            // tabItemClass
            // 
            this.tabItemClass.AttachedControl = this.tabControlPanelClass;
            this.tabItemClass.CloseButtonVisible = false;
            this.tabItemClass.Name = "tabItemClass";
            this.tabItemClass.Text = "行事曆";
            // 
            // pnlWhomList
            // 
            this.pnlWhomList.Controls.Add(this.panel10);
            this.pnlWhomList.Controls.Add(this.panel3);
            this.pnlWhomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWhomList.Location = new System.Drawing.Point(0, 0);
            this.pnlWhomList.Name = "pnlWhomList";
            this.pnlWhomList.Size = new System.Drawing.Size(207, 504);
            this.pnlWhomList.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.grdClassCalendar);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 35);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(207, 469);
            this.panel10.TabIndex = 10;
            // 
            // grdClassCalendar
            // 
            this.grdClassCalendar.AllowUserToAddRows = false;
            this.grdClassCalendar.AllowUserToDeleteRows = false;
            this.grdClassCalendar.AllowUserToOrderColumns = true;
            this.grdClassCalendar.AllowUserToResizeRows = false;
            this.grdClassCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdClassCalendar.BackgroundColor = System.Drawing.Color.White;
            this.grdClassCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdClassCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClassStatus,
            this.dataGridViewTextBoxColumn70,
            this.dataGridViewTextBoxColumn71,
            this.dataGridViewTextBoxColumn78,
            this.colSubject,
            this.dataGridViewTextBoxColumn80,
            this.dataGridViewTextBoxColumn73,
            this.dataGridViewTextBoxColumn74});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdClassCalendar.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdClassCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdClassCalendar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdClassCalendar.Location = new System.Drawing.Point(0, 0);
            this.grdClassCalendar.Name = "grdClassCalendar";
            this.grdClassCalendar.ReadOnly = true;
            this.grdClassCalendar.RowHeadersVisible = false;
            this.grdClassCalendar.RowTemplate.Height = 24;
            this.grdClassCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClassCalendar.Size = new System.Drawing.Size(207, 469);
            this.grdClassCalendar.TabIndex = 10;
            this.grdClassCalendar.VirtualMode = true;
            this.grdClassCalendar.SelectionChanged += new System.EventHandler(this.grdClassCalendar_SelectionChanged);
            // 
            // colClassStatus
            // 
            this.colClassStatus.DataPropertyName = "Status";
            this.colClassStatus.HeaderText = "狀態";
            this.colClassStatus.Name = "colClassStatus";
            this.colClassStatus.ReadOnly = true;
            this.colClassStatus.Width = 54;
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.DataPropertyName = "Date";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn70.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn70.HeaderText = "日期";
            this.dataGridViewTextBoxColumn70.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            this.dataGridViewTextBoxColumn70.ReadOnly = true;
            this.dataGridViewTextBoxColumn70.Width = 60;
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.DataPropertyName = "DisplayWeekDay";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn71.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn71.HeaderText = "星期";
            this.dataGridViewTextBoxColumn71.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            this.dataGridViewTextBoxColumn71.ReadOnly = true;
            this.dataGridViewTextBoxColumn71.Width = 54;
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn78.DataPropertyName = "Period";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn78.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn78.HeaderText = "節次";
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            this.dataGridViewTextBoxColumn78.ReadOnly = true;
            this.dataGridViewTextBoxColumn78.Width = 54;
            // 
            // colSubject
            // 
            this.colSubject.DataPropertyName = "Subject";
            this.colSubject.HeaderText = "科目名稱";
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            this.colSubject.Width = 78;
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn80.DataPropertyName = "TeacherName";
            this.dataGridViewTextBoxColumn80.HeaderText = "教師名稱";
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            this.dataGridViewTextBoxColumn80.ReadOnly = true;
            this.dataGridViewTextBoxColumn80.Width = 78;
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.DataPropertyName = "ClassName";
            this.dataGridViewTextBoxColumn73.HeaderText = "班級名稱";
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            this.dataGridViewTextBoxColumn73.ReadOnly = true;
            this.dataGridViewTextBoxColumn73.Width = 78;
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn74.DataPropertyName = "ClassroomName";
            this.dataGridViewTextBoxColumn74.HeaderText = "場地名稱";
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            this.dataGridViewTextBoxColumn74.ReadOnly = true;
            this.dataGridViewTextBoxColumn74.Width = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelX6);
            this.panel3.Controls.Add(this.lblClass);
            this.panel3.Controls.Add(this.labelX3);
            this.panel3.Controls.Add(this.labelX1);
            this.panel3.Controls.Add(this.btnClassEventExpand);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 35);
            this.panel3.TabIndex = 9;
            // 
            // labelX6
            // 
            this.labelX6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX6.Location = new System.Drawing.Point(48, 4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(123, 26);
            this.labelX6.TabIndex = 4;
            this.labelX6.Text = "黃色為未排分課";
            this.labelX6.Visible = false;
            // 
            // lblClass
            // 
            this.lblClass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClass.AutoSize = true;
            // 
            // 
            // 
            this.lblClass.BackgroundStyle.Class = "";
            this.lblClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblClass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblClass.Location = new System.Drawing.Point(7, 4);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(0, 0);
            this.lblClass.TabIndex = 3;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX3.Location = new System.Drawing.Point(7, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(0, 0);
            this.labelX3.TabIndex = 2;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX1.Location = new System.Drawing.Point(7, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(0, 0);
            this.labelX1.TabIndex = 1;
            // 
            // btnClassEventExpand
            // 
            this.btnClassEventExpand.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClassEventExpand.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClassEventExpand.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClassEventExpand.Location = new System.Drawing.Point(173, 5);
            this.btnClassEventExpand.Name = "btnClassEventExpand";
            this.btnClassEventExpand.Size = new System.Drawing.Size(28, 23);
            this.btnClassEventExpand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClassEventExpand.TabIndex = 0;
            this.btnClassEventExpand.Text = ">>";
            // 
            // tabClass
            // 
            this.tabClass.AttachedControl = this.superTabControlPanel2;
            this.tabClass.GlobalItem = false;
            this.tabClass.Name = "tabClass";
            this.tabClass.Text = "班級";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.pnlWhoList);
            this.superTabControlPanel1.Controls.Add(this.splTeacher);
            this.superTabControlPanel1.Controls.Add(this.pnlWhoLPView);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(807, 474);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabTeacher;
            // 
            // pnlWhoList
            // 
            this.pnlWhoList.Controls.Add(this.grdTeacherCalendar);
            this.pnlWhoList.Controls.Add(this.panel5);
            this.pnlWhoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWhoList.Location = new System.Drawing.Point(0, 0);
            this.pnlWhoList.Name = "pnlWhoList";
            this.pnlWhoList.Size = new System.Drawing.Size(204, 474);
            this.pnlWhoList.TabIndex = 6;
            // 
            // grdTeacherCalendar
            // 
            this.grdTeacherCalendar.AllowUserToAddRows = false;
            this.grdTeacherCalendar.AllowUserToDeleteRows = false;
            this.grdTeacherCalendar.AllowUserToOrderColumns = true;
            this.grdTeacherCalendar.AllowUserToResizeRows = false;
            this.grdTeacherCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTeacherCalendar.BackgroundColor = System.Drawing.Color.White;
            this.grdTeacherCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTeacherCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colSolutionCount,
            this.colWeekDay,
            this.colPeriodNo,
            this.colSubjectName,
            this.colCourseName,
            this.colLength,
            this.colWhoName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTeacherCalendar.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdTeacherCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTeacherCalendar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdTeacherCalendar.Location = new System.Drawing.Point(0, 35);
            this.grdTeacherCalendar.Name = "grdTeacherCalendar";
            this.grdTeacherCalendar.ReadOnly = true;
            this.grdTeacherCalendar.RowHeadersVisible = false;
            this.grdTeacherCalendar.RowTemplate.Height = 24;
            this.grdTeacherCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTeacherCalendar.Size = new System.Drawing.Size(204, 439);
            this.grdTeacherCalendar.TabIndex = 9;
            this.grdTeacherCalendar.VirtualMode = true;
            this.grdTeacherCalendar.SelectionChanged += new System.EventHandler(this.grdTeacherCalendar_SelectionChanged);
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "狀態";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 54;
            // 
            // colSolutionCount
            // 
            this.colSolutionCount.DataPropertyName = "Date";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSolutionCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSolutionCount.HeaderText = "日期";
            this.colSolutionCount.MinimumWidth = 60;
            this.colSolutionCount.Name = "colSolutionCount";
            this.colSolutionCount.ReadOnly = true;
            this.colSolutionCount.Width = 60;
            // 
            // colWeekDay
            // 
            this.colWeekDay.DataPropertyName = "DisplayWeekDay";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colWeekDay.DefaultCellStyle = dataGridViewCellStyle2;
            this.colWeekDay.HeaderText = "星期";
            this.colWeekDay.MinimumWidth = 40;
            this.colWeekDay.Name = "colWeekDay";
            this.colWeekDay.ReadOnly = true;
            this.colWeekDay.Width = 54;
            // 
            // colPeriodNo
            // 
            this.colPeriodNo.DataPropertyName = "Period";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPeriodNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPeriodNo.HeaderText = "節次";
            this.colPeriodNo.Name = "colPeriodNo";
            this.colPeriodNo.ReadOnly = true;
            this.colPeriodNo.Width = 54;
            // 
            // colSubjectName
            // 
            this.colSubjectName.DataPropertyName = "Subject";
            this.colSubjectName.HeaderText = "科目名稱";
            this.colSubjectName.Name = "colSubjectName";
            this.colSubjectName.ReadOnly = true;
            this.colSubjectName.Width = 78;
            // 
            // colCourseName
            // 
            this.colCourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCourseName.DataPropertyName = "TeacherName";
            this.colCourseName.HeaderText = "教師名稱";
            this.colCourseName.Name = "colCourseName";
            this.colCourseName.ReadOnly = true;
            this.colCourseName.Width = 78;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colLength.DataPropertyName = "ClassName";
            this.colLength.HeaderText = "班級名稱";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 78;
            // 
            // colWhoName
            // 
            this.colWhoName.DataPropertyName = "ClassroomName";
            this.colWhoName.HeaderText = "場地名稱";
            this.colWhoName.Name = "colWhoName";
            this.colWhoName.ReadOnly = true;
            this.colWhoName.Width = 78;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelX2);
            this.panel5.Controls.Add(this.lblTeacher);
            this.panel5.Controls.Add(this.btnTeacherEventExpand);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(204, 35);
            this.panel5.TabIndex = 8;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX2.Location = new System.Drawing.Point(23, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(140, 26);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "灰色為停課行事曆";
            this.labelX2.Visible = false;
            // 
            // lblTeacher
            // 
            this.lblTeacher.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTeacher.AutoSize = true;
            // 
            // 
            // 
            this.lblTeacher.BackgroundStyle.Class = "";
            this.lblTeacher.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTeacher.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTeacher.Location = new System.Drawing.Point(7, 4);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(0, 0);
            this.lblTeacher.TabIndex = 1;
            // 
            // btnTeacherEventExpand
            // 
            this.btnTeacherEventExpand.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTeacherEventExpand.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTeacherEventExpand.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTeacherEventExpand.Location = new System.Drawing.Point(170, 5);
            this.btnTeacherEventExpand.Name = "btnTeacherEventExpand";
            this.btnTeacherEventExpand.Size = new System.Drawing.Size(28, 23);
            this.btnTeacherEventExpand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTeacherEventExpand.TabIndex = 0;
            this.btnTeacherEventExpand.Text = ">>";
            // 
            // splTeacher
            // 
            this.splTeacher.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splTeacher.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splTeacher.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.splTeacher.Dock = System.Windows.Forms.DockStyle.Right;
            this.splTeacher.ExpandableControl = this.pnlWhoLPView;
            this.splTeacher.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splTeacher.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splTeacher.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splTeacher.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splTeacher.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splTeacher.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splTeacher.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splTeacher.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splTeacher.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.splTeacher.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.splTeacher.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.splTeacher.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.splTeacher.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splTeacher.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splTeacher.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splTeacher.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splTeacher.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splTeacher.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splTeacher.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splTeacher.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splTeacher.Location = new System.Drawing.Point(204, 0);
            this.splTeacher.Name = "splTeacher";
            this.splTeacher.Size = new System.Drawing.Size(3, 474);
            this.splTeacher.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.splTeacher.TabIndex = 5;
            this.splTeacher.TabStop = false;
            // 
            // pnlWhoLPView
            // 
            this.pnlWhoLPView.Controls.Add(this.tabTeacherCalendar);
            this.pnlWhoLPView.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWhoLPView.Location = new System.Drawing.Point(207, 0);
            this.pnlWhoLPView.Name = "pnlWhoLPView";
            this.pnlWhoLPView.Size = new System.Drawing.Size(600, 474);
            this.pnlWhoLPView.TabIndex = 4;
            // 
            // tabTeacherCalendar
            // 
            this.tabTeacherCalendar.AutoCloseTabs = true;
            this.tabTeacherCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabTeacherCalendar.CanReorderTabs = true;
            this.tabTeacherCalendar.CloseButtonOnTabsVisible = true;
            this.tabTeacherCalendar.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabTeacherCalendar.Controls.Add(this.tabControlPanelTeacher);
            this.tabTeacherCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTeacherCalendar.Location = new System.Drawing.Point(0, 0);
            this.tabTeacherCalendar.Name = "tabTeacherCalendar";
            this.tabTeacherCalendar.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.tabTeacherCalendar.SelectedTabIndex = -1;
            this.tabTeacherCalendar.Size = new System.Drawing.Size(600, 474);
            this.tabTeacherCalendar.TabIndex = 1;
            this.tabTeacherCalendar.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabTeacherCalendar.Tabs.Add(this.tabItemTeacher);
            this.tabTeacherCalendar.Text = "tabControl1";
            this.tabTeacherCalendar.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabCalendar_TabItemClose);
            // 
            // tabControlPanelTeacher
            // 
            this.tabControlPanelTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanelTeacher.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanelTeacher.Name = "tabControlPanelTeacher";
            this.tabControlPanelTeacher.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanelTeacher.Size = new System.Drawing.Size(600, 446);
            this.tabControlPanelTeacher.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanelTeacher.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanelTeacher.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanelTeacher.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanelTeacher.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanelTeacher.Style.GradientAngle = 90;
            this.tabControlPanelTeacher.TabIndex = 1;
            this.tabControlPanelTeacher.TabItem = this.tabItemTeacher;
            // 
            // tabItemTeacher
            // 
            this.tabItemTeacher.AttachedControl = this.tabControlPanelTeacher;
            this.tabItemTeacher.CloseButtonVisible = false;
            this.tabItemTeacher.Name = "tabItemTeacher";
            this.tabItemTeacher.Text = "行事曆";
            // 
            // tabTeacher
            // 
            this.tabTeacher.AttachedControl = this.superTabControlPanel1;
            this.tabTeacher.GlobalItem = false;
            this.tabTeacher.Name = "tabTeacher";
            this.tabTeacher.Text = "教師";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.superTabControlPanel8);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(807, 504);
            this.superTabControlPanel4.TabIndex = 1;
            this.superTabControlPanel4.TabItem = this.tabPlace;
            // 
            // superTabControlPanel8
            // 
            this.superTabControlPanel8.Controls.Add(this.pnlWhereList);
            this.superTabControlPanel8.Controls.Add(this.splClassroom);
            this.superTabControlPanel8.Controls.Add(this.pnlWhereLPView);
            this.superTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel8.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel8.Name = "superTabControlPanel8";
            this.superTabControlPanel8.Size = new System.Drawing.Size(807, 504);
            this.superTabControlPanel8.TabIndex = 1;
            this.superTabControlPanel8.TabItem = this.tabClassroom;
            // 
            // pnlWhereList
            // 
            this.pnlWhereList.Controls.Add(this.panel15);
            this.pnlWhereList.Controls.Add(this.panel16);
            this.pnlWhereList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWhereList.Location = new System.Drawing.Point(0, 0);
            this.pnlWhereList.Name = "pnlWhereList";
            this.pnlWhereList.Size = new System.Drawing.Size(204, 504);
            this.pnlWhereList.TabIndex = 2;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.grdPlaceCalendar);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 35);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(204, 469);
            this.panel15.TabIndex = 11;
            // 
            // grdPlaceCalendar
            // 
            this.grdPlaceCalendar.AllowUserToAddRows = false;
            this.grdPlaceCalendar.AllowUserToDeleteRows = false;
            this.grdPlaceCalendar.AllowUserToOrderColumns = true;
            this.grdPlaceCalendar.AllowUserToResizeRows = false;
            this.grdPlaceCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPlaceCalendar.BackgroundColor = System.Drawing.Color.White;
            this.grdPlaceCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlaceCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPlaceCalendar.DefaultCellStyle = dataGridViewCellStyle12;
            this.grdPlaceCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlaceCalendar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdPlaceCalendar.Location = new System.Drawing.Point(0, 0);
            this.grdPlaceCalendar.Name = "grdPlaceCalendar";
            this.grdPlaceCalendar.ReadOnly = true;
            this.grdPlaceCalendar.RowHeadersVisible = false;
            this.grdPlaceCalendar.RowTemplate.Height = 24;
            this.grdPlaceCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPlaceCalendar.Size = new System.Drawing.Size(204, 469);
            this.grdPlaceCalendar.TabIndex = 11;
            this.grdPlaceCalendar.VirtualMode = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn24.HeaderText = "狀態";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 54;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Date";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn17.HeaderText = "日期";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 60;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "DisplayWeekDay";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn18.HeaderText = "星期";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 54;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Period";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn19.HeaderText = "節次";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 54;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Subject";
            this.dataGridViewTextBoxColumn20.HeaderText = "科目名稱";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 78;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "TeacherName";
            this.dataGridViewTextBoxColumn21.HeaderText = "教師名稱";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 78;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "ClassName";
            this.dataGridViewTextBoxColumn22.HeaderText = "班級名稱";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 78;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "ClassroomName";
            this.dataGridViewTextBoxColumn23.HeaderText = "場地名稱";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 78;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.lblClassroom);
            this.panel16.Controls.Add(this.labelX12);
            this.panel16.Controls.Add(this.labelX13);
            this.panel16.Controls.Add(this.btnClassroomEventExpand);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(204, 35);
            this.panel16.TabIndex = 10;
            // 
            // lblClassroom
            // 
            this.lblClassroom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClassroom.AutoSize = true;
            // 
            // 
            // 
            this.lblClassroom.BackgroundStyle.Class = "";
            this.lblClassroom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblClassroom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblClassroom.Location = new System.Drawing.Point(7, 4);
            this.lblClassroom.Name = "lblClassroom";
            this.lblClassroom.Size = new System.Drawing.Size(0, 0);
            this.lblClassroom.TabIndex = 3;
            // 
            // labelX12
            // 
            this.labelX12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX12.AutoSize = true;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX12.Location = new System.Drawing.Point(7, 4);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(0, 0);
            this.labelX12.TabIndex = 2;
            // 
            // labelX13
            // 
            this.labelX13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX13.AutoSize = true;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX13.Location = new System.Drawing.Point(7, 4);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(0, 0);
            this.labelX13.TabIndex = 1;
            // 
            // btnClassroomEventExpand
            // 
            this.btnClassroomEventExpand.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClassroomEventExpand.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClassroomEventExpand.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClassroomEventExpand.Location = new System.Drawing.Point(170, 5);
            this.btnClassroomEventExpand.Name = "btnClassroomEventExpand";
            this.btnClassroomEventExpand.Size = new System.Drawing.Size(28, 23);
            this.btnClassroomEventExpand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClassroomEventExpand.TabIndex = 0;
            this.btnClassroomEventExpand.Text = ">>";
            // 
            // splClassroom
            // 
            this.splClassroom.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClassroom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClassroom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.splClassroom.Dock = System.Windows.Forms.DockStyle.Right;
            this.splClassroom.ExpandableControl = this.pnlWhereLPView;
            this.splClassroom.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClassroom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClassroom.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splClassroom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splClassroom.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splClassroom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splClassroom.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splClassroom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splClassroom.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.splClassroom.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.splClassroom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.splClassroom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.splClassroom.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClassroom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClassroom.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splClassroom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splClassroom.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splClassroom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splClassroom.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splClassroom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splClassroom.Location = new System.Drawing.Point(204, 0);
            this.splClassroom.Name = "splClassroom";
            this.splClassroom.Size = new System.Drawing.Size(3, 504);
            this.splClassroom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.splClassroom.TabIndex = 1;
            this.splClassroom.TabStop = false;
            // 
            // pnlWhereLPView
            // 
            this.pnlWhereLPView.Controls.Add(this.tabClassroomCalendar);
            this.pnlWhereLPView.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWhereLPView.Location = new System.Drawing.Point(207, 0);
            this.pnlWhereLPView.Name = "pnlWhereLPView";
            this.pnlWhereLPView.Size = new System.Drawing.Size(600, 504);
            this.pnlWhereLPView.TabIndex = 0;
            // 
            // tabClassroomCalendar
            // 
            this.tabClassroomCalendar.AutoCloseTabs = true;
            this.tabClassroomCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabClassroomCalendar.CanReorderTabs = true;
            this.tabClassroomCalendar.CloseButtonOnTabsVisible = true;
            this.tabClassroomCalendar.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabClassroomCalendar.Controls.Add(this.tabControlPanelClassroom);
            this.tabClassroomCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClassroomCalendar.Location = new System.Drawing.Point(0, 0);
            this.tabClassroomCalendar.Name = "tabClassroomCalendar";
            this.tabClassroomCalendar.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.tabClassroomCalendar.SelectedTabIndex = -1;
            this.tabClassroomCalendar.Size = new System.Drawing.Size(600, 504);
            this.tabClassroomCalendar.TabIndex = 3;
            this.tabClassroomCalendar.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabClassroomCalendar.Tabs.Add(this.tabItem4);
            this.tabClassroomCalendar.Text = "tabControl1";
            this.tabClassroomCalendar.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabCalendar_TabItemClose);
            // 
            // tabControlPanelClassroom
            // 
            this.tabControlPanelClassroom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanelClassroom.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanelClassroom.Name = "tabControlPanelClassroom";
            this.tabControlPanelClassroom.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanelClassroom.Size = new System.Drawing.Size(600, 476);
            this.tabControlPanelClassroom.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanelClassroom.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanelClassroom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanelClassroom.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanelClassroom.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanelClassroom.Style.GradientAngle = 90;
            this.tabControlPanelClassroom.TabIndex = 1;
            this.tabControlPanelClassroom.TabItem = this.tabItem4;
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanelClassroom;
            this.tabItem4.CloseButtonVisible = false;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "行事曆";
            // 
            // tabClassroom
            // 
            this.tabClassroom.GlobalItem = false;
            this.tabClassroom.Name = "tabClassroom";
            this.tabClassroom.Text = "場地";
            // 
            // tabPlace
            // 
            this.tabPlace.AttachedControl = this.superTabControlPanel4;
            this.tabPlace.GlobalItem = false;
            this.tabPlace.Name = "tabPlace";
            this.tabPlace.Text = "場地";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(206, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(3, 504);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 10;
            this.expandableSplitter1.TabStop = false;
            // 
            // LeftNavigationPanel
            // 
            this.LeftNavigationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftNavigationPanel.CanCollapse = true;
            this.LeftNavigationPanel.Controls.Add(this.pnlTeacher);
            this.LeftNavigationPanel.Controls.Add(this.pnlClassroom);
            this.LeftNavigationPanel.Controls.Add(this.pnlClass);
            this.LeftNavigationPanel.Controls.Add(this.pnlPlace);
            this.LeftNavigationPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftNavigationPanel.ItemPaddingBottom = 2;
            this.LeftNavigationPanel.ItemPaddingTop = 2;
            this.LeftNavigationPanel.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnTeacher,
            this.btnClass,
            this.btnClassroom});
            this.LeftNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftNavigationPanel.Name = "LeftNavigationPanel";
            this.LeftNavigationPanel.Padding = new System.Windows.Forms.Padding(1);
            this.LeftNavigationPanel.Size = new System.Drawing.Size(206, 504);
            this.LeftNavigationPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LeftNavigationPanel.TabIndex = 9;
            // 
            // 
            // 
            this.LeftNavigationPanel.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LeftNavigationPanel.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LeftNavigationPanel.TitlePanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftNavigationPanel.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.LeftNavigationPanel.TitlePanel.Name = "panelTitle";
            this.LeftNavigationPanel.TitlePanel.Size = new System.Drawing.Size(202, 24);
            this.LeftNavigationPanel.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.LeftNavigationPanel.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.LeftNavigationPanel.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.LeftNavigationPanel.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.LeftNavigationPanel.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.LeftNavigationPanel.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.LeftNavigationPanel.TitlePanel.Style.GradientAngle = 90;
            this.LeftNavigationPanel.TitlePanel.Style.MarginLeft = 4;
            this.LeftNavigationPanel.TitlePanel.TabIndex = 0;
            this.LeftNavigationPanel.TitlePanel.Text = "教師";
            // 
            // pnlTeacher
            // 
            this.pnlTeacher.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeacher.Location = new System.Drawing.Point(1, 25);
            this.pnlTeacher.Name = "pnlTeacher";
            this.pnlTeacher.ParentItem = this.btnTeacher;
            this.pnlTeacher.Size = new System.Drawing.Size(202, 444);
            this.pnlTeacher.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlTeacher.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlTeacher.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlTeacher.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlTeacher.Style.GradientAngle = 90;
            this.pnlTeacher.TabIndex = 2;
            // 
            // btnTeacher
            // 
            this.btnTeacher.Checked = true;
            this.btnTeacher.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.OptionGroup = "navBar";
            this.btnTeacher.Text = "教師";
            // 
            // pnlClassroom
            // 
            this.pnlClassroom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlClassroom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClassroom.Location = new System.Drawing.Point(1, 1);
            this.pnlClassroom.Name = "pnlClassroom";
            this.pnlClassroom.ParentItem = null;
            this.pnlClassroom.Size = new System.Drawing.Size(202, 468);
            this.pnlClassroom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlClassroom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlClassroom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlClassroom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlClassroom.Style.GradientAngle = 90;
            this.pnlClassroom.TabIndex = 4;
            // 
            // pnlClass
            // 
            this.pnlClass.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClass.Location = new System.Drawing.Point(1, 1);
            this.pnlClass.Name = "pnlClass";
            this.pnlClass.ParentItem = this.btnClass;
            this.pnlClass.Size = new System.Drawing.Size(202, 468);
            this.pnlClass.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlClass.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlClass.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlClass.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlClass.Style.GradientAngle = 90;
            this.pnlClass.TabIndex = 3;
            // 
            // btnClass
            // 
            this.btnClass.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnClass.Name = "btnClass";
            this.btnClass.OptionGroup = "navBar";
            this.btnClass.Text = "班級";
            // 
            // pnlPlace
            // 
            this.pnlPlace.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlace.Location = new System.Drawing.Point(1, 1);
            this.pnlPlace.Name = "pnlPlace";
            this.pnlPlace.ParentItem = this.btnClassroom;
            this.pnlPlace.Size = new System.Drawing.Size(202, 468);
            this.pnlPlace.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlPlace.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlPlace.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlPlace.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlPlace.Style.GradientAngle = 90;
            this.pnlPlace.TabIndex = 5;
            // 
            // btnClassroom
            // 
            this.btnClassroom.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnClassroom.Name = "btnClassroom";
            this.btnClassroom.OptionGroup = "navBar";
            this.btnClassroom.Text = "場地";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel3;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "superTabItem1";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(661, 391);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.superTabControl1);
            this.panel6.Controls.Add(this.expandableSplitter4);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 100);
            this.panel6.TabIndex = 0;
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel6);
            this.superTabControl1.Controls.Add(this.superTabControlPanel7);
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(3, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(197, 100);
            this.superTabControl1.TabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.superTabControl1.TabIndex = 11;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem3,
            this.superTabItem2,
            this.superTabItem4});
            this.superTabControl1.TabsVisible = false;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.panel12);
            this.superTabControlPanel6.Controls.Add(this.expandableSplitter3);
            this.superTabControlPanel6.Controls.Add(this.panel14);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(197, 70);
            this.superTabControlPanel6.TabIndex = 1;
            this.superTabControlPanel6.TabItem = this.superTabItem3;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.dataGridViewX2);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(0, 70);
            this.panel12.TabIndex = 6;
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AllowUserToOrderColumns = true;
            this.dataGridViewX2.AllowUserToResizeRows = false;
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewX2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 35);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.ReadOnly = true;
            this.dataGridViewX2.RowHeadersVisible = false;
            this.dataGridViewX2.RowTemplate.Height = 24;
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(0, 35);
            this.dataGridViewX2.TabIndex = 9;
            this.dataGridViewX2.VirtualMode = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Date";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn9.HeaderText = "日期";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DisplayWeekDay";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn10.HeaderText = "星期";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 54;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Period";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn11.HeaderText = "節次";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 54;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Subject";
            this.dataGridViewTextBoxColumn12.HeaderText = "科目名稱";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 78;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "TeacherName";
            this.dataGridViewTextBoxColumn13.HeaderText = "教師名稱";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 78;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ClassName";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn14.HeaderText = "班級名稱";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 78;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ClassroomName";
            this.dataGridViewTextBoxColumn15.HeaderText = "場地名稱";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 78;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn16.HeaderText = "狀態";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 54;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.labelX9);
            this.panel13.Controls.Add(this.labelX10);
            this.panel13.Controls.Add(this.buttonX2);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(0, 35);
            this.panel13.TabIndex = 8;
            // 
            // labelX9
            // 
            this.labelX9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX9.Location = new System.Drawing.Point(-181, 3);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(140, 26);
            this.labelX9.TabIndex = 2;
            this.labelX9.Text = "灰色為停課行事曆";
            this.labelX9.Visible = false;
            // 
            // labelX10
            // 
            this.labelX10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX10.Location = new System.Drawing.Point(7, 4);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(0, 0);
            this.labelX10.TabIndex = 1;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(-34, 5);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(28, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 0;
            this.buttonX2.Text = ">>";
            // 
            // expandableSplitter3
            // 
            this.expandableSplitter3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter3.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandableSplitter3.ExpandableControl = this.panel14;
            this.expandableSplitter3.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter3.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter3.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter3.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter3.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter3.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter3.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter3.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter3.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter3.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter3.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter3.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter3.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter3.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter3.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter3.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter3.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter3.Location = new System.Drawing.Point(-406, 0);
            this.expandableSplitter3.Name = "expandableSplitter3";
            this.expandableSplitter3.Size = new System.Drawing.Size(3, 70);
            this.expandableSplitter3.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter3.TabIndex = 5;
            this.expandableSplitter3.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.tabControl2);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(-403, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(600, 70);
            this.panel14.TabIndex = 4;
            // 
            // tabControl2
            // 
            this.tabControl2.AutoCloseTabs = true;
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.CloseButtonOnTabsVisible = true;
            this.tabControl2.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabControl2.Controls.Add(this.tabControlPanel4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = -1;
            this.tabControl2.Size = new System.Drawing.Size(600, 70);
            this.tabControl2.TabIndex = 1;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.Text = "tabControl1";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(600, 42);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel4;
            this.tabItem2.CloseButtonVisible = false;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "行事曆";
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel6;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "教師";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(197, 100);
            this.superTabControlPanel7.TabIndex = 1;
            this.superTabControlPanel7.TabItem = this.superTabItem4;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel7;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "場地";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.expandableSplitter2);
            this.superTabControlPanel5.Controls.Add(this.panel8);
            this.superTabControlPanel5.Controls.Add(this.panel7);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(197, 100);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem2;
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandableSplitter2.ExpandableControl = this.panel7;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.Location = new System.Drawing.Point(-406, 0);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(3, 100);
            this.expandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter2.TabIndex = 2;
            this.expandableSplitter2.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tabControl1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(-403, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(600, 100);
            this.panel7.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.AutoCloseTabs = true;
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.CloseButtonOnTabsVisible = true;
            this.tabControl1.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = -1;
            this.tabControl1.Size = new System.Drawing.Size(600, 100);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(600, 72);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 1;
            this.tabControlPanel3.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel3;
            this.tabItem1.CloseButtonVisible = false;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "行事曆";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(0, 100);
            this.panel8.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataGridViewX1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 35);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(0, 65);
            this.panel9.TabIndex = 10;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(0, 65);
            this.dataGridViewX1.TabIndex = 10;
            this.dataGridViewX1.VirtualMode = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn1.HeaderText = "日期";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DisplayWeekDay";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn2.HeaderText = "星期";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Period";
            this.dataGridViewTextBoxColumn3.HeaderText = "節次";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 54;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Subject";
            this.dataGridViewTextBoxColumn4.HeaderText = "科目名稱";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TeacherName";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn5.HeaderText = "教師名稱";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 78;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ClassName";
            this.dataGridViewTextBoxColumn6.HeaderText = "班級名稱";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 78;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ClassroomName";
            this.dataGridViewTextBoxColumn7.HeaderText = "場地名稱";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 78;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn8.HeaderText = "狀態";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 54;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.labelX4);
            this.panel11.Controls.Add(this.labelX5);
            this.panel11.Controls.Add(this.labelX7);
            this.panel11.Controls.Add(this.labelX8);
            this.panel11.Controls.Add(this.buttonX1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(0, 35);
            this.panel11.TabIndex = 9;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX4.Location = new System.Drawing.Point(-159, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(123, 26);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "黃色為未排分課";
            this.labelX4.Visible = false;
            // 
            // labelX5
            // 
            this.labelX5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX5.Location = new System.Drawing.Point(7, 4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(0, 0);
            this.labelX5.TabIndex = 3;
            // 
            // labelX7
            // 
            this.labelX7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX7.Location = new System.Drawing.Point(7, 4);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(0, 0);
            this.labelX7.TabIndex = 2;
            // 
            // labelX8
            // 
            this.labelX8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX8.Location = new System.Drawing.Point(7, 4);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(0, 0);
            this.labelX8.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(-34, 5);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(28, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = ">>";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel5;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "班級";
            // 
            // expandableSplitter4
            // 
            this.expandableSplitter4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter4.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter4.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter4.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter4.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter4.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter4.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter4.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter4.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter4.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter4.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter4.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter4.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter4.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter4.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter4.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter4.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter4.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter4.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter4.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter4.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter4.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter4.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter4.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter4.Name = "expandableSplitter4";
            this.expandableSplitter4.Size = new System.Drawing.Size(3, 100);
            this.expandableSplitter4.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter4.TabIndex = 10;
            this.expandableSplitter4.TabStop = false;
            // 
            // navigationPane1
            // 
            this.navigationPane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigationPane1.CanCollapse = true;
            this.navigationPane1.Controls.Add(this.navigationPanePanel1);
            this.navigationPane1.ItemPaddingBottom = 2;
            this.navigationPane1.ItemPaddingTop = 2;
            this.navigationPane1.Location = new System.Drawing.Point(0, 0);
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.NavigationBarHeight = 38;
            this.navigationPane1.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPane1.Size = new System.Drawing.Size(150, 192);
            this.navigationPane1.TabIndex = 0;
            // 
            // 
            // 
            this.navigationPane1.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPane1.TitlePanel.Name = "panelTitle";
            this.navigationPane1.TitlePanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.navigationPane1.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(56)))), ((int)(((byte)(148)))));
            this.navigationPane1.TitlePanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.navigationPane1.TitlePanel.Style.ForeColor.Color = System.Drawing.Color.White;
            this.navigationPane1.TitlePanel.TabIndex = 0;
            // 
            // navigationPanePanel1
            // 
            this.navigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel1.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel1.Name = "navigationPanePanel1";
            this.navigationPanePanel1.ParentItem = null;
            this.navigationPanePanel1.Size = new System.Drawing.Size(146, 150);
            this.navigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel1.Style.GradientAngle = 90;
            this.navigationPanePanel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.MainForm_Layout);
            this.ContentPanePanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabContent)).EndInit();
            this.tabContent.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.pnlWhomLPView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabClassCalendar)).EndInit();
            this.tabClassCalendar.ResumeLayout(false);
            this.pnlWhomList.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClassCalendar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.superTabControlPanel1.ResumeLayout(false);
            this.pnlWhoList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTeacherCalendar)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlWhoLPView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabTeacherCalendar)).EndInit();
            this.tabTeacherCalendar.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel8.ResumeLayout(false);
            this.pnlWhereList.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlaceCalendar)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.pnlWhereLPView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabClassroomCalendar)).EndInit();
            this.tabClassroomCalendar.ResumeLayout(false);
            this.LeftNavigationPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel6.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.navigationPane1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("MainForm Load！");
        }

        private void PrepareTabControl(DevComponents.DotNetBar.TabControl TabControl)
        {
            foreach (TabItem vTabItem in TabControl.Tabs)
            {
                TabControlPanel Panel = vTabItem.AttachedControl as TabControlPanel;

                if (Panel.Tag == null)
                {
                    DecCalendar vCalendar = new DecCalendar(Panel);

                    if (vTabItem.CloseButtonVisible == true)
                        vTabItem.Visible = false;
                }
            }
        }

        private void MainForm_Layout(object sender, LayoutEventArgs e)
        {
            //預先建立教師的行事曆介面
            //PrepareTabControl(tabTeacherCalendar);
            //PrepareTabControl(tabClassCalendar);
            //PrepareTabControl(tabClassroomCalendar);
        }

        private void tabCalendar_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            e.Cancel = true;           

            DevComponents.DotNetBar.TabControl vTabControl = sender as DevComponents.DotNetBar.TabControl;

            if (vTabControl != null)
            {
                DecCalendar Calendar = vTabControl.SelectedPanel.Tag as DecCalendar;
                Calendar.InitialUI();
                vTabControl.SelectedTab.Text = string.Empty;
                vTabControl.SelectedTab.Visible = false;
            }
        }

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    DecCalendar vCalendar = new DecCalendar(tabControlPanel6);

        //    tabControlPanel6.Tag = vCalendar;

        //    vCalendar.Type = CalendarType.Teacher;
        //    vCalendar.AssocID = "張惠君";
        //    vCalendar.UpdateContent();
        //}
    }
}