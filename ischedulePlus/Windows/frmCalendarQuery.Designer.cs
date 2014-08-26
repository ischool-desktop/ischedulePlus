namespace ischedulePlus
{
    partial class frmCalendarQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlQueryByDate = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dateEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.pnlQueryByResource = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbClassroom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmbTeacher = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.errStartTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.errEndTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.鎖定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解除鎖定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.chkQueryByRole = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkQueryPeriod = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pnlQueryPeriod = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkQueryByClass = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pnlClass = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lstClass = new System.Windows.Forms.ListBox();
            this.btnCheckDuplicate = new DevComponents.DotNetBar.ButtonItem();
            this.pnlQueryByDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).BeginInit();
            this.pnlQueryByResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).BeginInit();
            this.menuCalendar.SuspendLayout();
            this.menuCancel.SuspendLayout();
            this.pnlClass.SuspendLayout();
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
            // pnlQueryByResource
            // 
            this.pnlQueryByResource.BackColor = System.Drawing.Color.Transparent;
            this.pnlQueryByResource.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlQueryByResource.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlQueryByResource.Controls.Add(this.cmbClassroom);
            this.pnlQueryByResource.Controls.Add(this.labelX5);
            this.pnlQueryByResource.Controls.Add(this.cmbTeacher);
            this.pnlQueryByResource.Controls.Add(this.labelX4);
            this.pnlQueryByResource.DrawTitleBox = false;
            this.pnlQueryByResource.Enabled = false;
            this.pnlQueryByResource.Location = new System.Drawing.Point(485, 12);
            this.pnlQueryByResource.Name = "pnlQueryByResource";
            this.pnlQueryByResource.Size = new System.Drawing.Size(213, 147);
            // 
            // 
            // 
            this.pnlQueryByResource.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlQueryByResource.Style.BackColorGradientAngle = 90;
            this.pnlQueryByResource.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlQueryByResource.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByResource.Style.BorderBottomWidth = 1;
            this.pnlQueryByResource.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlQueryByResource.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByResource.Style.BorderLeftWidth = 1;
            this.pnlQueryByResource.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByResource.Style.BorderRightWidth = 1;
            this.pnlQueryByResource.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlQueryByResource.Style.BorderTopWidth = 1;
            this.pnlQueryByResource.Style.Class = "";
            this.pnlQueryByResource.Style.CornerDiameter = 4;
            this.pnlQueryByResource.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlQueryByResource.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlQueryByResource.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlQueryByResource.StyleMouseDown.Class = "";
            this.pnlQueryByResource.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlQueryByResource.StyleMouseOver.Class = "";
            this.pnlQueryByResource.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlQueryByResource.TabIndex = 2;
            this.pnlQueryByResource.Text = "資源";
            // 
            // cmbClassroom
            // 
            this.cmbClassroom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClassroom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClassroom.DisplayMember = "Name";
            this.cmbClassroom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClassroom.FormattingEnabled = true;
            this.cmbClassroom.ItemHeight = 19;
            this.cmbClassroom.Location = new System.Drawing.Point(63, 48);
            this.cmbClassroom.Name = "cmbClassroom";
            this.cmbClassroom.Size = new System.Drawing.Size(121, 25);
            this.cmbClassroom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbClassroom.TabIndex = 8;
            this.cmbClassroom.ValueMember = "id";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(13, 48);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(34, 21);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "場地";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTeacher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTeacher.DisplayMember = "name";
            this.cmbTeacher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.ItemHeight = 19;
            this.cmbTeacher.Location = new System.Drawing.Point(63, 12);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(120, 25);
            this.cmbTeacher.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTeacher.TabIndex = 5;
            this.cmbTeacher.ValueMember = "id";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(13, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "教師";
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
            this.btnQuery.Location = new System.Drawing.Point(716, 169);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(212, 25);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCheckDuplicate});
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdResult.Location = new System.Drawing.Point(17, 206);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowTemplate.Height = 24;
            this.grdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResult.Size = new System.Drawing.Size(915, 425);
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
            this.鎖定ToolStripMenuItem,
            this.解除鎖定ToolStripMenuItem,
            this.停課ToolStripMenuItem,
            this.上課ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.修改節次ToolStripMenuItem,
            this.修改教師ToolStripMenuItem,
            this.修改場地ToolStripMenuItem,
            this.刪除ToolStripMenuItem});
            this.menuCalendar.Name = "menuCalendar";
            this.menuCalendar.Size = new System.Drawing.Size(119, 202);
            // 
            // 鎖定ToolStripMenuItem
            // 
            this.鎖定ToolStripMenuItem.Name = "鎖定ToolStripMenuItem";
            this.鎖定ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.鎖定ToolStripMenuItem.Text = "鎖定";
            this.鎖定ToolStripMenuItem.Click += new System.EventHandler(this.鎖定ToolStripMenuItem_Click);
            // 
            // 解除鎖定ToolStripMenuItem
            // 
            this.解除鎖定ToolStripMenuItem.Name = "解除鎖定ToolStripMenuItem";
            this.解除鎖定ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.解除鎖定ToolStripMenuItem.Text = "解除鎖定";
            this.解除鎖定ToolStripMenuItem.Click += new System.EventHandler(this.解除鎖定ToolStripMenuItem_Click);
            // 
            // 停課ToolStripMenuItem
            // 
            this.停課ToolStripMenuItem.Name = "停課ToolStripMenuItem";
            this.停課ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.停課ToolStripMenuItem.Text = "停課";
            this.停課ToolStripMenuItem.Click += new System.EventHandler(this.停課ToolStripMenuItem_Click);
            // 
            // 上課ToolStripMenuItem
            // 
            this.上課ToolStripMenuItem.Name = "上課ToolStripMenuItem";
            this.上課ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.上課ToolStripMenuItem.Text = "上課";
            this.上課ToolStripMenuItem.Click += new System.EventHandler(this.上課ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改ToolStripMenuItem.Text = "修改日期";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改日期ToolStripMenuItem_Click);
            // 
            // 修改節次ToolStripMenuItem
            // 
            this.修改節次ToolStripMenuItem.Name = "修改節次ToolStripMenuItem";
            this.修改節次ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改節次ToolStripMenuItem.Text = "修改節次";
            this.修改節次ToolStripMenuItem.Click += new System.EventHandler(this.修改節次ToolStripMenuItem_Click);
            // 
            // 修改教師ToolStripMenuItem
            // 
            this.修改教師ToolStripMenuItem.Name = "修改教師ToolStripMenuItem";
            this.修改教師ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改教師ToolStripMenuItem.Text = "修改教師";
            this.修改教師ToolStripMenuItem.Click += new System.EventHandler(this.修改教師ToolStripMenuItem_Click);
            // 
            // 修改場地ToolStripMenuItem
            // 
            this.修改場地ToolStripMenuItem.Name = "修改場地ToolStripMenuItem";
            this.修改場地ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改場地ToolStripMenuItem.Text = "修改場地";
            this.修改場地ToolStripMenuItem.Click += new System.EventHandler(this.修改場地ToolStripMenuItem_Click);
            // 
            // 刪除ToolStripMenuItem
            // 
            this.刪除ToolStripMenuItem.Name = "刪除ToolStripMenuItem";
            this.刪除ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.刪除ToolStripMenuItem.Text = "刪除";
            this.刪除ToolStripMenuItem.Click += new System.EventHandler(this.刪除ToolStripMenuItem_Click);
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
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            // chkQueryByRole
            // 
            this.chkQueryByRole.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkQueryByRole.BackgroundStyle.Class = "";
            this.chkQueryByRole.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkQueryByRole.Location = new System.Drawing.Point(495, 12);
            this.chkQueryByRole.Name = "chkQueryByRole";
            this.chkQueryByRole.Size = new System.Drawing.Size(134, 23);
            this.chkQueryByRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkQueryByRole.TabIndex = 11;
            this.chkQueryByRole.Text = "依教師及場地查詢";
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
            // chkQueryByClass
            // 
            this.chkQueryByClass.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkQueryByClass.BackgroundStyle.Class = "";
            this.chkQueryByClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkQueryByClass.Location = new System.Drawing.Point(726, 12);
            this.chkQueryByClass.Name = "chkQueryByClass";
            this.chkQueryByClass.Size = new System.Drawing.Size(100, 23);
            this.chkQueryByClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkQueryByClass.TabIndex = 16;
            this.chkQueryByClass.Text = "依班級查詢";
            // 
            // pnlClass
            // 
            this.pnlClass.BackColor = System.Drawing.Color.Transparent;
            this.pnlClass.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlClass.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlClass.Controls.Add(this.lstClass);
            this.pnlClass.DrawTitleBox = false;
            this.pnlClass.Enabled = false;
            this.pnlClass.Location = new System.Drawing.Point(716, 12);
            this.pnlClass.Name = "pnlClass";
            this.pnlClass.Size = new System.Drawing.Size(213, 147);
            // 
            // 
            // 
            this.pnlClass.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlClass.Style.BackColorGradientAngle = 90;
            this.pnlClass.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlClass.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlClass.Style.BorderBottomWidth = 1;
            this.pnlClass.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlClass.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlClass.Style.BorderLeftWidth = 1;
            this.pnlClass.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlClass.Style.BorderRightWidth = 1;
            this.pnlClass.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlClass.Style.BorderTopWidth = 1;
            this.pnlClass.Style.Class = "";
            this.pnlClass.Style.CornerDiameter = 4;
            this.pnlClass.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlClass.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlClass.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlClass.StyleMouseDown.Class = "";
            this.pnlClass.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlClass.StyleMouseOver.Class = "";
            this.pnlClass.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlClass.TabIndex = 15;
            this.pnlClass.Text = "資源";
            // 
            // lstClass
            // 
            this.lstClass.DisplayMember = "name";
            this.lstClass.FormattingEnabled = true;
            this.lstClass.ItemHeight = 17;
            this.lstClass.Location = new System.Drawing.Point(17, 5);
            this.lstClass.Name = "lstClass";
            this.lstClass.Size = new System.Drawing.Size(176, 106);
            this.lstClass.TabIndex = 0;
            // 
            // btnCheckDuplicate
            // 
            this.btnCheckDuplicate.GlobalItem = false;
            this.btnCheckDuplicate.Name = "btnCheckDuplicate";
            this.btnCheckDuplicate.Text = "查詢重覆";
            this.btnCheckDuplicate.Click += new System.EventHandler(this.btnCheckDuplicate_Click);
            // 
            // frmCalendarQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 675);
            this.Controls.Add(this.chkQueryByClass);
            this.Controls.Add(this.pnlClass);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.chkQueryPeriod);
            this.Controls.Add(this.pnlQueryPeriod);
            this.Controls.Add(this.chkQueryByRole);
            this.Controls.Add(this.chkQueryByDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlQueryByResource);
            this.Controls.Add(this.pnlQueryByDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(950, 700);
            this.MinimumSize = new System.Drawing.Size(950, 700);
            this.Name = "frmCalendarQuery";
            this.Text = "";
            this.TitleText = "行事曆查詢";
            this.Load += new System.EventHandler(this.frmExchangeReplaceQuery_Load);
            this.pnlQueryByDate.ResumeLayout(false);
            this.pnlQueryByDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).EndInit();
            this.pnlQueryByResource.ResumeLayout(false);
            this.pnlQueryByResource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).EndInit();
            this.menuCalendar.ResumeLayout(false);
            this.menuCancel.ResumeLayout(false);
            this.pnlClass.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryByDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateStart;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateEnd;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryByResource;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTeacher;
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
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbClassroom;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryByDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryByRole;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刪除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改節次ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改教師ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改場地ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryPeriod;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryPeriod;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSelectAll;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryByClass;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlClass;
        private System.Windows.Forms.ListBox lstClass;
        private System.Windows.Forms.ToolStripMenuItem 鎖定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解除鎖定ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonItem btnCheckDuplicate;
    }
}