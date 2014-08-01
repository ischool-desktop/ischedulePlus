namespace ischedulePlus
{
    partial class frmTeacherNoBusyQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlQueryByDate = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dateEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.errStartTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.errEndTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.停課ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上課ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改節次ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改教師ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改場地ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刪除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCancel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.chkQueryByDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkQueryPeriod = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pnlQueryPeriod = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pnlQueryByDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).BeginInit();
            this.menuCalendar.SuspendLayout();
            this.menuCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlQueryByDate
            // 
            this.pnlQueryByDate.BackColor = System.Drawing.Color.Transparent;
            this.pnlQueryByDate.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlQueryByDate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlQueryByDate.Controls.Add(this.labelX2);
            this.pnlQueryByDate.Controls.Add(this.labelX1);
            this.pnlQueryByDate.Controls.Add(this.dateEnd);
            this.pnlQueryByDate.Controls.Add(this.dateStart);
            this.pnlQueryByDate.DrawTitleBox = false;
            this.pnlQueryByDate.Enabled = false;
            this.pnlQueryByDate.Location = new System.Drawing.Point(17, 12);
            this.pnlQueryByDate.Name = "pnlQueryByDate";
            this.pnlQueryByDate.Size = new System.Drawing.Size(241, 147);
            // 
            // 
            // 
            this.pnlQueryByDate.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlQueryByDate.Style.BackColorGradientAngle = 90;
            this.pnlQueryByDate.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlQueryByDate.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByDate.Style.BorderBottomWidth = 1;
            this.pnlQueryByDate.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlQueryByDate.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByDate.Style.BorderLeftWidth = 1;
            this.pnlQueryByDate.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByDate.Style.BorderRightWidth = 1;
            this.pnlQueryByDate.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByDate.Style.BorderTopWidth = 1;
            this.pnlQueryByDate.Style.Class = "";
            this.pnlQueryByDate.Style.CornerDiameter = 4;
            this.pnlQueryByDate.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlQueryByDate.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlQueryByDate.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlQueryByDate.StyleMouseDown.Class = "";
            this.pnlQueryByDate.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlQueryByDate.StyleMouseOver.Class = "";
            this.pnlQueryByDate.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlQueryByDate.TabIndex = 0;
            this.pnlQueryByDate.Text = "日期";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(16, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "結束日期";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "開始日期";
            // 
            // dateEnd
            // 
            this.dateEnd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dateEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateEnd.ButtonDropDown.Visible = true;
            this.dateEnd.IsPopupCalendarOpen = false;
            this.dateEnd.Location = new System.Drawing.Point(82, 48);
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateEnd.MonthCalendar.BackgroundStyle.Class = "";
            this.dateEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dateEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateEnd.MonthCalendar.TodayButtonVisible = true;
            this.dateEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(138, 25);
            this.dateEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateEnd.TabIndex = 5;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // dateStart
            // 
            this.dateStart.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dateStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateStart.ButtonDropDown.Visible = true;
            this.dateStart.IsPopupCalendarOpen = false;
            this.dateStart.Location = new System.Drawing.Point(82, 12);
            // 
            // 
            // 
            this.dateStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dateStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateStart.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dateStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateStart.MonthCalendar.TodayButtonVisible = true;
            this.dateStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(138, 25);
            this.dateStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateStart.TabIndex = 3;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(19, 640);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 25);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "匯出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(807, 134);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(122, 25);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查詢";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToAddRows = false;
            this.grdResult.AllowUserToDeleteRows = false;
            this.grdResult.AllowUserToOrderColumns = true;
            this.grdResult.AllowUserToResizeRows = false;
            this.grdResult.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdResult.Location = new System.Drawing.Point(17, 180);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowTemplate.Height = 24;
            this.grdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResult.Size = new System.Drawing.Size(915, 451);
            this.grdResult.TabIndex = 5;
            // 
            // errStartTime
            // 
            this.errStartTime.ContainerControl = this;
            // 
            // errEndTime
            // 
            this.errEndTime.ContainerControl = this;
            // 
            // menuCalendar
            // 
            this.menuCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.停課ToolStripMenuItem,
            this.上課ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.修改節次ToolStripMenuItem,
            this.修改教師ToolStripMenuItem,
            this.修改場地ToolStripMenuItem,
            this.刪除ToolStripMenuItem});
            this.menuCalendar.Name = "menuCalendar";
            this.menuCalendar.Size = new System.Drawing.Size(119, 158);
            // 
            // 停課ToolStripMenuItem
            // 
            this.停課ToolStripMenuItem.Name = "停課ToolStripMenuItem";
            this.停課ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.停課ToolStripMenuItem.Text = "停課";
            // 
            // 上課ToolStripMenuItem
            // 
            this.上課ToolStripMenuItem.Name = "上課ToolStripMenuItem";
            this.上課ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.上課ToolStripMenuItem.Text = "上課";
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改ToolStripMenuItem.Text = "修改日期";
            // 
            // 修改節次ToolStripMenuItem
            // 
            this.修改節次ToolStripMenuItem.Name = "修改節次ToolStripMenuItem";
            this.修改節次ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改節次ToolStripMenuItem.Text = "修改節次";
            // 
            // 修改教師ToolStripMenuItem
            // 
            this.修改教師ToolStripMenuItem.Name = "修改教師ToolStripMenuItem";
            this.修改教師ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改教師ToolStripMenuItem.Text = "修改教師";
            // 
            // 修改場地ToolStripMenuItem
            // 
            this.修改場地ToolStripMenuItem.Name = "修改場地ToolStripMenuItem";
            this.修改場地ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改場地ToolStripMenuItem.Text = "修改場地";
            // 
            // 刪除ToolStripMenuItem
            // 
            this.刪除ToolStripMenuItem.Name = "刪除ToolStripMenuItem";
            this.刪除ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.刪除ToolStripMenuItem.Text = "刪除";
            // 
            // menuCancel
            // 
            this.menuCancel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuCancel.Name = "contextMenuStrip1";
            this.menuCancel.Size = new System.Drawing.Size(95, 26);
            this.menuCancel.Text = "取消";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "取消";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(849, 640);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "關閉";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkQueryByDate
            // 
            this.chkQueryByDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkQueryByDate.BackgroundStyle.Class = "";
            this.chkQueryByDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkQueryByDate.Location = new System.Drawing.Point(25, 11);
            this.chkQueryByDate.Name = "chkQueryByDate";
            this.chkQueryByDate.Size = new System.Drawing.Size(100, 23);
            this.chkQueryByDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkQueryByDate.TabIndex = 9;
            this.chkQueryByDate.Text = "依日期查詢";
            // 
            // chkQueryPeriod
            // 
            this.chkQueryPeriod.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkQueryPeriod.BackgroundStyle.Class = "";
            this.chkQueryPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkQueryPeriod.Location = new System.Drawing.Point(280, 12);
            this.chkQueryPeriod.Name = "chkQueryPeriod";
            this.chkQueryPeriod.Size = new System.Drawing.Size(100, 23);
            this.chkQueryPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkQueryPeriod.TabIndex = 13;
            this.chkQueryPeriod.Text = "依節次查詢";
            // 
            // pnlQueryPeriod
            // 
            this.pnlQueryPeriod.BackColor = System.Drawing.Color.Transparent;
            this.pnlQueryPeriod.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlQueryPeriod.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlQueryPeriod.DrawTitleBox = false;
            this.pnlQueryPeriod.Enabled = false;
            this.pnlQueryPeriod.Location = new System.Drawing.Point(272, 12);
            this.pnlQueryPeriod.Name = "pnlQueryPeriod";
            this.pnlQueryPeriod.Size = new System.Drawing.Size(198, 147);
            // 
            // 
            // 
            this.pnlQueryPeriod.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlQueryPeriod.Style.BackColorGradientAngle = 90;
            this.pnlQueryPeriod.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlQueryPeriod.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryPeriod.Style.BorderBottomWidth = 1;
            this.pnlQueryPeriod.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlQueryPeriod.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryPeriod.Style.BorderLeftWidth = 1;
            this.pnlQueryPeriod.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryPeriod.Style.BorderRightWidth = 1;
            this.pnlQueryPeriod.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryPeriod.Style.BorderTopWidth = 1;
            this.pnlQueryPeriod.Style.Class = "";
            this.pnlQueryPeriod.Style.CornerDiameter = 4;
            this.pnlQueryPeriod.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlQueryPeriod.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlQueryPeriod.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlQueryPeriod.StyleMouseDown.Class = "";
            this.pnlQueryPeriod.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlQueryPeriod.StyleMouseOver.Class = "";
            this.pnlQueryPeriod.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlQueryPeriod.TabIndex = 12;
            this.pnlQueryPeriod.Text = "資源";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.Class = "";
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.CheckValue = "Y";
            this.chkSelectAll.Location = new System.Drawing.Point(398, 12);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(54, 21);
            this.chkSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSelectAll.TabIndex = 14;
            this.chkSelectAll.Text = "全選";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // frmTeacherNoBusyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 675);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.chkQueryPeriod);
            this.Controls.Add(this.pnlQueryPeriod);
            this.Controls.Add(this.chkQueryByDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlQueryByDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(950, 700);
            this.MinimumSize = new System.Drawing.Size(950, 700);
            this.Name = "frmTeacherNoBusyQuery";
            this.Text = "";
            this.TitleText = "無課教師查詢";
            this.Load += new System.EventHandler(this.frmTeacherNoBusyQuery_Load);
            this.pnlQueryByDate.ResumeLayout(false);
            this.pnlQueryByDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).EndInit();
            this.menuCalendar.ResumeLayout(false);
            this.menuCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryByDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateStart;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateEnd;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdResult;
        private System.Windows.Forms.ErrorProvider errStartTime;
        private System.Windows.Forms.ErrorProvider errEndTime;
        private System.Windows.Forms.ContextMenuStrip menuCalendar;
        private System.Windows.Forms.ToolStripMenuItem 停課ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上課ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuCancel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryByDate;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刪除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改節次ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改教師ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改場地ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryPeriod;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryPeriod;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSelectAll;
    }
}