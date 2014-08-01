using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using FISCA.Data;
using ischedulePlus.Properties;

namespace ischedulePlus
{
    public delegate void PeriodClickedHandler(object sender, PeriodEventArgs e);

    /// <summary>
    /// 排課顏色
    /// </summary>
    public class SchedulerColor
    {
        public static Color lvBusyBackColor = Color.FromArgb(230, 230, 230);
        public static Color lvBusyForeColor = Color.FromArgb(86, 86, 86);

        //private const string lvBusyBackColor = "#e6e6e6";
        //private const string lvBusyForeColor = "#565656";

        public static Color lvFreeBackColor = Color.White;
        public static Color lvFreeForeColor = Color.FromArgb(86, 86, 86);

        //private const string lvFreeBackColor = "White";
        //private const string lvFreeForeColor = "#565656";

        public static Color lvScheduledBackColor = Color.Snow;
        public static Color lvScheduledForeColor = Color.FromArgb(2, 123, 204);

        //private const string lvScheduledBackColor = "Snow";
        //private const string lvScheduledForeColor = "#027bcc";

        public static Color lvTimeTableBackColor = Color.FromArgb(230, 230, 230);
        public static Color lvTimeTableForeColor = Color.FromArgb(86, 86, 86);

        //private const string lvTimeTableBackColor = "#e6e6e6";
        //private const string lvTimeTableForeColor = "#565656";

        public static Color lvSchedulableBackColor = Color.FromArgb(254, 252, 128);
        public static Color lvSchedulableForeColor = Color.White;

        //private const string lvSchedulableBackColor = "#fefc80";
        //private const string lvSchedulableForeColor = "White";

        public static Color lvNoSolutionBackColor = Color.FromArgb(230, 230, 230);
        public static Color lvNoSolutionForeColor = Color.FromArgb(86, 86, 86);

        //private const string lvNoSolutionBackColor = "#e6e6e6";
        //private const string lvNoSolutionForeColor = "#565656";
    }

    
    /// <summary>
    /// 功課表類型，有：教師課表、班級課表，以及場地課表
    /// </summary>
    public enum CalendarType
    {
        Teacher, Class, Classroom
    }

    /// <summary>
    /// 節次類別
    /// </summary>
    public class DecPeriod
    {
        private string mToolTipHeader = string.Empty;
        private string mTooltipContent = string.Empty;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private DecPeriodSuperTooltipProvider mSP = null;
        private BalloonTip mTip = new BalloonTip();
        private SuperTooltip mSuperTip = new SuperTooltip();
        private CalendarOption Option;
        private const int lblCount = 4;
        private string TimeTableID = string.Empty;
        private DevComponents.DotNetBar.PanelEx _pnl;
        private CalendarType _calType = CalendarType.Teacher;
        private int _colIndex = -1;
        private int _rowIndex = -1;
        //private CEvent _vo;
        private List<CalendarRecord> _calendars = new List<CalendarRecord>();  //此節次的課程分段，可能多個，如單雙週，或場地可同時多門課程。
        private bool _selected = false;
        private bool mIsSetTooltip = false;
        private PictureBox picBox;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        //private Panel pnlCover;
        private Color unselectedColor = Color.FromArgb(234, 234, 234);

        private bool isBindEvent = false;
        private bool isValid;   //是否有效的節次，用來辨別出現在課表中，但不屬於上課時間表的節次。

        private Dictionary<string, Label> dicLables;

        /// <summary>
        /// 星期
        /// </summary>
        public int Weekday { get { return this._colIndex; } }

        /// <summary>
        /// 節次
        /// </summary>
        public int Period { get { return this._rowIndex; } }

        /// <summary>
        /// 節次按下時的事件
        /// </summary>
        public event PeriodClickedHandler OnPeriodClicked;

        /*  Constructor  */
        public DecPeriod(DevComponents.DotNetBar.PanelEx pnl,
            int colIndex,
            int rowIndex,
            CalendarType calType)
        {
            this._pnl = pnl;
            this._calType = calType;
            this._colIndex = colIndex;
            this._rowIndex = rowIndex;
            this._pnl.Tag = this;

            mSP = new DecPeriodSuperTooltipProvider(this);
            mTip.ShowBalloonOnFocus = true;
            mTip.ShowCloseButton = false;

            /* 註冊事件  */

            this._pnl.Click += new EventHandler(_pnl_MouseEnter);
            this._pnl.MouseEnter += new EventHandler(_pnl_MouseEnter);

            //this._pnl.MouseLeave += new EventHandler(_pnl_MouseLeave);

            /* picBox */
            this.picBox = new PictureBox();
            Size s = new Size(32, 16);
            Point pt = new Point(this._pnl.Width - s.Width - 6, this._pnl.Height - s.Height - 6);
            this.picBox.Size = s;
            this.picBox.Location = pt;
            //this.picBox.Image = Properties.Resources.busy;
            this.picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picBox.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this._pnl.Controls.Add(this.picBox);
            //this.picBox.Click += new EventHandler(picBox_Click);

            /* 建立 label */
            this.dicLables = new Dictionary<string, Label>();
            int initX = 5;
            int initY = 5;
            int labelHeight = 18;
            for (int i = 0; i < lblCount; i++)
            {
                Label lbl = new Label();
                lbl.Name = string.Format("label{0}", (i + 1).ToString());
                lbl.Visible = true;
                lbl.AutoSize = true;
                lbl.Text = string.Empty;

                Font vFont = new Font("微軟正黑體", 9f);

                lbl.Font = vFont;

                Point p = new Point(initX, initY + i * labelHeight);
                lbl.Location = p;
                if (i == 0)
                    this.lbl1 = lbl;
                else if (i == 1)
                    this.lbl2 = lbl;
                else if (i == 2)
                    this.lbl3 = lbl;
                else if (i == 3)
                    this.lbl4 = lbl;

                /*
                lbl.Click += new EventHandler(_pnl_Click);

                lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                lbl.MouseLeave += new EventHandler(lbl_MouseLeave);

                    * */
                this.dicLables.Add(lbl.Name, lbl);
                this._pnl.Controls.Add(lbl);
            }
        }

        public void RebindEvent()
        {
            this.lbl1.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl1.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl1.Click -= new EventHandler(_label_Click);

            this.lbl2.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl2.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl2.Click -= new EventHandler(_label_Click);

            this.lbl3.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl3.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl3.Click -= new EventHandler(_label_Click);

            this.lbl4.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl4.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl4.Click -= new EventHandler(_label_Click);

            this.picBox.Click -= new EventHandler(picBox_Click);

            this._pnl.Click -= new EventHandler(_pnl_Click);
            this._pnl.MouseLeave -= new EventHandler(_pnl_MouseLeave);

            if (!string.IsNullOrEmpty("" + this.lbl1.Tag))
            {
                this.lbl1.MouseEnter += new EventHandler(lbl_MouseEnter);
                this.lbl1.MouseLeave += new EventHandler(lbl_MouseLeave);
                this.lbl1.Click += new EventHandler(_label_Click);
            }

            if (!string.IsNullOrEmpty("" + this.lbl2.Tag))
            {
                this.lbl2.MouseEnter += new EventHandler(lbl_MouseEnter);
                this.lbl2.MouseLeave += new EventHandler(lbl_MouseLeave);
                this.lbl2.Click += new EventHandler(_label_Click);
            }

            if (!string.IsNullOrEmpty("" + this.lbl3.Tag))
            {
                this.lbl3.MouseEnter += new EventHandler(lbl_MouseEnter);
                this.lbl3.MouseLeave += new EventHandler(lbl_MouseLeave);
                this.lbl3.Click += new EventHandler(_label_Click);
            }

            if (!string.IsNullOrEmpty("" + this.lbl4.Tag))
            {
                this.lbl4.MouseEnter += new EventHandler(lbl_MouseEnter);
                this.lbl4.MouseLeave += new EventHandler(lbl_MouseLeave);
                this.lbl4.Click += new EventHandler(_label_Click);
            }

            this._pnl.Click += new EventHandler(_pnl_Click);
            this._pnl.MouseLeave += new EventHandler(_pnl_MouseLeave);

            this.picBox.Click += new EventHandler(picBox_Click);
        }

        /// <summary>
        /// 根據時間表編號初始化內容
        /// </summary>
        /// <param name="TimeTableID"></param>
        public void InitialContent(CalendarOption Option)
        {
            this.isBindEvent = false;
            this.Option = Option;
            this.lbl1.Text = string.Empty;
            this.lbl1.Tag = string.Empty;
            this.lbl1.Visible = true;
            this.lbl1.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl1.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl1.Click -= new EventHandler(_label_Click);

            this.lbl2.Text = string.Empty;
            this.lbl2.Tag = string.Empty;
            this.lbl2.Visible = true;
            this.lbl2.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl2.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl2.Click -= new EventHandler(_label_Click);

            this.lbl3.Text = string.Empty;
            this.lbl3.Tag = string.Empty;
            this.lbl3.Visible = true;
            this.lbl3.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl3.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl3.Click -= new EventHandler(_label_Click);

            this.lbl4.Text = string.Empty;
            this.lbl4.Tag = string.Empty;
            this.lbl4.Visible = true;
            this.lbl4.MouseEnter -= new EventHandler(lbl_MouseEnter);
            this.lbl4.MouseLeave -= new EventHandler(lbl_MouseLeave);
            this.lbl4.Click -= new EventHandler(_label_Click);

            this.picBox.Image = Resources.blank;
            this.picBox.Tag = string.Empty;
            this.picBox.Click -= new EventHandler(picBox_Click);

            this._pnl.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
            this._pnl.Style.BorderWidth = 1;
            this._pnl.Click -= new EventHandler(_pnl_Click);
            this._pnl.MouseLeave -= new EventHandler(_pnl_MouseLeave);
            this.BackColor = SchedulerColor.lvTimeTableBackColor;

            this._calendars.Clear();
        }

        void picBox_Click(object sender, EventArgs e)
        {
            /* 再把事件丟出去給上層容器 */
            if (OnPeriodClicked != null)
            {
                this.OnPeriodClicked(this, new PeriodEventArgs(this._colIndex, this._rowIndex, this._calendars));
            }
        }

        void lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Black;
            this._pnl_MouseLeave(sender, e);
        }

        void lbl_MouseEnter(object sender, EventArgs e)
        {
            
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Red;
            this.MouseEnterHandler(sender, e);
        }

        void _pnl_MouseLeave(object sender, EventArgs e)
        {
            mSP.Hide();
            //this._pnl.Cursor = Cursors.Default;
            //Console.WriteLine("_pnl_MouseLeave");
        }

        /// <summary>
        /// 設定Tooltip
        /// </summary>
        private void SetTooltip()
        {
            mIsSetTooltip = true;

            if (this.picBox.Tag.Equals("調課"))
            {
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (sender, e) =>
                {
                    DataTable table = mQueryHelper.Select("select target_exchange_id from $scheduler.course_calendar where uid=" + this._calendars[0].UID);

                    if (table.Rows.Count > 0)
                    {
                        string TargetExchangeID = "" + table.Rows[0][0];

                        if (!string.IsNullOrWhiteSpace(TargetExchangeID))
                        {
                            table = mQueryHelper.Select("select * from $scheduler.course_calendar where uid=" + TargetExchangeID);

                            if (table.Rows.Count > 0)
                                SetTooltip(table.Rows[0], "(調課)");
                        }
                        else
                        {
                            table = mQueryHelper.Select("select * from $scheduler.course_calendar where target_exchange_id=" + this._calendars[0].UID);

                            if (table.Rows.Count > 0)
                                SetTooltip(table.Rows[0], "(調課)");
                        }
                    }
                };

                worker.RunWorkerCompleted += (sender, e) => ShowTooltip();

                worker.RunWorkerAsync();
            }
            else if (this.picBox.Tag.Equals("代課"))
            {
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (sender, e) =>
                {
                    DataTable table = mQueryHelper.Select("select * from $scheduler.course_calendar where uid=" + this._calendars[0].ReplaceID);

                    if (table.Rows.Count > 0)
                        SetTooltip(table.Rows[0], "(請假)");
                };

                worker.RunWorkerCompleted += (sender, e) =>
                {
                    ShowTooltip();
                };

                worker.RunWorkerAsync();
            }
            else if (this.picBox.Tag.Equals("請假"))
            {
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (sender, e) =>
                {
                    DataTable table = mQueryHelper.Select("select * from $scheduler.course_calendar where replace_id=" + this._calendars[0].UID);

                    if (table.Rows.Count > 0)
                        SetTooltip(table.Rows[0], "(代課)");
                };

                worker.RunWorkerCompleted += (sender, e) =>
                {
                    ShowTooltip();
                };

                worker.RunWorkerAsync();
            }
            else if (this.picBox.Tag.Equals("缺課"))
            {
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (sender, e) =>
                {
                    DataTable table = mQueryHelper.Select("select * from $scheduler.course_calendar where replace_id=" + this._calendars[0].UID);

                    if (table.Rows.Count > 0)
                        SetTooltip(table.Rows[0], "(缺課)");
                };

                worker.RunWorkerCompleted += (sender, e) =>
                {
                    ShowTooltip();
                };

                worker.RunWorkerAsync();
            }
        }

        private void ShowTooltip()
        {
            mSuperTip.SetSuperTooltip(mSP, new SuperTooltipInfo(mToolTipHeader,string.Empty,mTooltipContent,null,null,DevComponents.DotNetBar.eTooltipColor.Lemon));
            mSP.Show(); 
        }

        void _pnl_MouseEnter(object sender, EventArgs e)
        {
            List<string> TooltipTags = new List<string>() {"調課","代課","請假","缺課"};

            if (TooltipTags.Contains("" + this.picBox.Tag))
            {
                if (!mIsSetTooltip)
                    SetTooltip();
                else
                    ShowTooltip();
            }

            this.MouseEnterHandler(sender, e);

            if (!this.isBindEvent)
            {
                if (!string.IsNullOrEmpty("" + this.lbl1.Tag))
                {
                    this.lbl1.MouseEnter += new EventHandler(lbl_MouseEnter);
                    this.lbl1.MouseLeave += new EventHandler(lbl_MouseLeave);
                    this.lbl1.Click += new EventHandler(_label_Click);
                }

                if (!string.IsNullOrEmpty("" + this.lbl2.Tag))
                {
                    this.lbl2.MouseEnter += new EventHandler(lbl_MouseEnter);
                    this.lbl2.MouseLeave += new EventHandler(lbl_MouseLeave);
                    this.lbl2.Click += new EventHandler(_label_Click);
                }

                if (!string.IsNullOrEmpty("" + this.lbl3.Tag))
                {
                    this.lbl3.MouseEnter += new EventHandler(lbl_MouseEnter);
                    this.lbl3.MouseLeave += new EventHandler(lbl_MouseLeave);
                    this.lbl3.Click += new EventHandler(_label_Click);
                }

                if (!string.IsNullOrEmpty("" + this.lbl4.Tag))
                {
                    this.lbl4.MouseEnter += new EventHandler(lbl_MouseEnter);
                    this.lbl4.MouseLeave += new EventHandler(lbl_MouseLeave);
                    this.lbl4.Click += new EventHandler(_label_Click);
                }

                this._pnl.Click += new EventHandler(_pnl_Click);
                this._pnl.MouseLeave += new EventHandler(_pnl_MouseLeave);

                this.picBox.Click += new EventHandler(picBox_Click);
                this.isBindEvent = true;
            }
        }

        private void MouseEnterHandler(object sender, EventArgs e)
        {
            this._pnl.Cursor = Cursors.Hand;

        }

        private void _label_Click(object sender, EventArgs e)
        {
            /* 再把事件丟出去給上層容器 */
            if (OnPeriodClicked != null)
            {
                this.OnPeriodClicked(sender, new PeriodEventArgs(this._colIndex, this._rowIndex, this._calendars));
            }
        }

        private void _pnl_Click(object sender, EventArgs e)
        {
            /* 可已先行處理，如果有需要的話。 */

            /* 再把事件丟出去給上層容器 */
            if (OnPeriodClicked != null)
            {
                this.OnPeriodClicked(this, new PeriodEventArgs(this._colIndex, this._rowIndex, this._calendars));
            }
        }

        #region properties
        /// <summary>
        /// 是否選取
        /// </summary>
        public bool IsSelected
        {
            get { return this._selected; }
            set
            {
                this._selected = value;
                if (this._selected)
                {
                    this._pnl.Style.BorderColor.Color = Color.Orange;
                    this._pnl.Style.BorderWidth = 2;
                }
                else
                {
                    this._pnl.Style.BorderColor.ColorSchemePart = eColorSchemePart.PanelBorder;
                    this._pnl.Style.BorderWidth = 1;

                    //if (!("" + this.picBox.Tag).Equals("busy"))
                    //{
                    //    this.picBox.Image = Resources.blank;
                    //    this.picBox.Tag = string.Empty;
                    //}
                }
            }
        }

        /// <summary>
        /// 設為可排課時段
        /// </summary>
        public void SetSchedulable()
        {
            picBox.Image = Resources.blank;
            BackColor = SchedulerColor.lvSchedulableBackColor;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            this._calendars = new List<CalendarRecord>();
        }

        /// <summary>
        /// 註明為不排課時段
        /// </summary>
        public void SetAsBusy(string BusyDesc)
        {
            this.lbl1.Text = BusyDesc;
            this.lbl2.Text = string.Empty;
            this.lbl3.Text = string.Empty;
            this.lbl4.Text = string.Empty;
            this.picBox.Image = null;
            //this.picBox.Image = Properties.Resources.忙碌;
            this.picBox.Tag = "busy";
            this.BackColor = SchedulerColor.lvBusyBackColor;
            this._calendars = new List<CalendarRecord>();
        }

        /// <summary>
        /// 是否為不調代時段
        /// </summary>
        public bool IsBusy
        {
            get 
            {
                if (this.picBox != null && 
                    this.picBox.Tag != null)
                    return this.picBox.Tag.Equals("busy");
                else
                    return false;
            }
        }

        /// <summary>
        /// 設定無解
        /// </summary>
        /// <param name="ReasonDesc">無解原因</param>
        public void SetNoSolution(string ReasonDesc)
        {
            BackColor = SchedulerColor.lvNoSolutionBackColor;
            lbl1.Text = ReasonDesc;
            this._calendars = new List<CalendarRecord>();
        }

        /// <summary>
        /// 設定無解，可連結資源
        /// </summary>
        /// <param name="ReasonDesc"></param>
        /// <param name="AssocType"></param>
        /// <param name="AssocID"></param>
        /// <param name="AssocName"></param>
        public void SetNoSolution(string ReasonDesc, CalendarType AssocType, string AssocID, string AssocName)
        {
            lbl1.Text = AssocName;
            lbl1.Tag = ("" + AssocType) + "：" + AssocID;
            lbl2.Text = ReasonDesc;
            this._calendars = new List<CalendarRecord>();
            BackColor = SchedulerColor.lvNoSolutionBackColor;
        }

        /// <summary>
        /// 設定多筆分課資料
        /// </summary>
        private void SetMultipleEvents()
        {

        }

        private void SetLabelText(ref int Index, string Text, string Tag)
        {
            if (Index == 1)
            {
                lbl1.Text = Text;
                lbl1.Tag = Tag;
            }
            else if (Index == 2)
            {
                lbl2.Text = Text;
                lbl2.Tag = Tag;
            }
            else if (Index == 3)
            {
                lbl3.Text = Text;
                lbl3.Tag = Tag;
            }
            else if (Index == 4)
            {
                lbl4.Text = Text;
                lbl4.Tag = Tag;
            }

            Index++;
        }

        private void SetTooltip(DataRow Row,string TeacherNameComment)
        {
            StringBuilder strBuilder = new StringBuilder();

            List<string> strWeekdays = new List<string>() { "一", "二", "三", "四", "五", "六", "日" };

            int Weekday = K12.Data.Int.Parse("" + Row["weekday"]);

            string strDatetime = ""+Row["start_date_time"];
            DateTime StartDateTime = K12.Data.DateTimeHelper.ParseDirect(strDatetime);

            strBuilder.AppendLine(StartDateTime.ToShortDateString());
            strBuilder.AppendLine("週" + strWeekdays[Weekday-1] + " 第" + Row["period"] +"節");

            mToolTipHeader = strBuilder.ToString();

            strBuilder.Clear();

            if (Option.IsSubject)
                strBuilder.AppendLine(""+Row["subject"]);

            if (Option.IsSubjectAlias)
                strBuilder.AppendLine(""+Row["subject_alias"]);

            if (Option.IsClass)
                strBuilder.AppendLine(""+Row["class_name"]);

            strBuilder.AppendLine("" + Row["teacher_name"] + TeacherNameComment);

            if (Option.IsClassroom)
                strBuilder.AppendLine(""+Row["classroom_name"]);

            mTooltipContent = strBuilder.ToString();
        }

        private void SetCalendar(CalendarRecord _vo)
        {
            mIsSetTooltip = false;

            if (string.IsNullOrWhiteSpace(_vo.Status))
            {
                this.picBox.Image = null;
                this.picBox.Tag = string.Empty;
            }
            else if (_vo.Status.Equals("調課"))
            {
                this.picBox.Image = Resources.調課;
                this.picBox.Tag = "調課";
            }
            else if (_vo.Status.Equals("代課"))
            {
                if (!string.IsNullOrWhiteSpace(_vo.TeacherName))
                    this.picBox.Image = Resources.代課;
                else
                    this.picBox.Image = Resources.缺課;

                this.picBox.Tag = "代課";
            }
            else if (_vo.Status.Equals("請假"))
            {
                this.picBox.Image = Resources.請假;
                this.picBox.Tag = "請假";
                this.BackColor = SchedulerColor.lvNoSolutionBackColor;
            }
            else if (_vo.Status.Equals("缺課"))
            {
                this.picBox.Image = Resources.缺課;
                this.picBox.Tag = "缺課";
                this.BackColor = SchedulerColor.lvNoSolutionBackColor;
            }
            else
                throw new Exception("不存在的節次狀態！");


            int index = 1;

            if (Option.IsSubject)
                SetLabelText(ref index, _vo.FullSubject, string.Empty);

            if (Option.IsSubjectAlias)
                SetLabelText(ref index, _vo.SubjectAlias, string.Empty);

            if (Option.IsClass)
                SetLabelText(
                    ref index,
                    _vo.ClassName,
                    !string.IsNullOrEmpty(_vo.ClassName) ? string.Format("Class：{0}", _vo.ClassName) : string.Empty);

            if (Option.IsTeacher)
                SetLabelText(
                    ref index,
                    _vo.TeacherName,
                    !string.IsNullOrEmpty(_vo.TeacherName) ? string.Format("Teacher：{0}", _vo.TeacherName) : string.Empty);

            if (Option.IsClassroom)
                SetLabelText(
                    ref index,
                    _vo.ClassroomName,
                    !string.IsNullOrEmpty(_vo.ClassroomName) ? string.Format("Classroom：{0}", _vo.ClassroomName) : string.Empty);

            mTip.SetBalloonText(_pnl, _vo.FullSubject);
        }

        /// <summary>
        /// 指定事件
        /// </summary>
        public List<CalendarRecord> Data
        {
            get { return this._calendars; }
            set
            {
                this._calendars = value;
                this.BackColor = SchedulerColor.lvFreeBackColor;

                if (_calendars.Count == 1)
                {
                    CalendarRecord _vo = _calendars[0];

                    SetCalendar(_vo);
                }
                else
                    SetMultipleEvents();
            }
        }

        public DevComponents.DotNetBar.PanelEx Panel
        {
            get { return this._pnl; }
        }

        /// <summary>
        /// 背景顏色
        /// </summary>
        public Color BackColor
        {
            get { return this._pnl.Style.BackColor1.Color; }
            set
            {
                this._pnl.Style.BackColor1.Color = value;
                this._pnl.Style.BackColor2.Color = value;
            }
        }
        #endregion

        #region ===========  Method decleration  ========
        public void AdjustAppearance(Point location, Size size)
        {
            this._pnl.Location = location;
            this._pnl.Size = size;
        }

        /// <summary>
        /// 標記為無效的節次。
        /// 通常在畫出上課時間表的矩陣時，某些節次並不在上課時間表範圍內，就呼叫此方法設為無效。
        /// </summary>
        public bool IsValid
        {
            get { return this.isValid; }
            set
            {
                this.isValid = value;
                this.lbl1.Text = "";
                this.BackColor = (this.isValid) ? Color.White : this.unselectedColor;

            }
        }

        /* 因為Bind Event Handler 效能慢，所以選在顯示之後， 再呼叫此方法 bind events */
        //public void AttachEvents()
        //{
        //    this._pnl.Click += (object sender, EventArgs e) =>
        //    {
        //        this.IsSelected = true;
        //        if (OnPeriodClicked != null)
        //        {
        //            if (this._vo != null)
        //                this.OnPeriodClicked(this, new PeriodEventArgs(this._colIndex, this._rowIndex, this._vo));
        //        }
        //    };
        //}


        #endregion
    }

    /// <summary>
    /// 節次事件
    /// </summary>
    public class PeriodEventArgs : EventArgs
    {
        public int Weekday;
        public int Period;
        public List<CalendarRecord> Value;

        public PeriodEventArgs(int weekday, int period, List<CalendarRecord> vo)
        {
            this.Weekday = weekday;
            this.Period = period;
            this.Value = vo;
        }
    }
}