namespace ischedulePlus
{
    partial class frmExchangeReplaceReport
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
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlQueryByDate = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dateEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.btnReportOption = new DevComponents.DotNetBar.ButtonItem();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnEMail = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbTeacher = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.pnlQueryByResource = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.errStartTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.errEndTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkReplace = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkExchange = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkExchangeReplace = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkQueryByRole = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkQueryByDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnWeekday = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.pnlQueryByDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).BeginInit();
            this.pnlQueryByResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(750, 58);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(119, 25);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 10;
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
            this.grdResult.Location = new System.Drawing.Point(21, 146);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowTemplate.Height = 24;
            this.grdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResult.Size = new System.Drawing.Size(848, 379);
            this.grdResult.TabIndex = 9;
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
            this.pnlQueryByDate.Location = new System.Drawing.Point(21, 12);
            this.pnlQueryByDate.Name = "pnlQueryByDate";
            this.pnlQueryByDate.Size = new System.Drawing.Size(238, 113);
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
            this.pnlQueryByDate.TabIndex = 7;
            this.pnlQueryByDate.Text = "日期時間";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(14, 51);
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
            this.labelX1.Location = new System.Drawing.Point(14, 7);
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
            this.dateEnd.Location = new System.Drawing.Point(89, 47);
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
            this.dateEnd.Size = new System.Drawing.Size(119, 25);
            this.dateEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateEnd.TabIndex = 5;
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
            this.dateStart.Location = new System.Drawing.Point(89, 4);
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
            this.dateStart.Size = new System.Drawing.Size(119, 25);
            this.dateStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateStart.TabIndex = 3;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Location = new System.Drawing.Point(750, 93);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(119, 25);
            this.btnReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReport.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnWeekday,
            this.btnReportOption});
            this.btnReport.TabIndex = 11;
            this.btnReport.Text = "列印";
            this.btnReport.Click += new System.EventHandler(this.btnPrintNew_Click);
            // 
            // btnReportOption
            // 
            this.btnReportOption.GlobalItem = false;
            this.btnReportOption.Name = "btnReportOption";
            this.btnReportOption.Text = "列印設定";
            this.btnReportOption.Click += new System.EventHandler(this.btnReportOption_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(21, 539);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 25);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "匯出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEMail
            // 
            this.btnEMail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEMail.BackColor = System.Drawing.Color.Transparent;
            this.btnEMail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEMail.Enabled = false;
            this.btnEMail.Location = new System.Drawing.Point(853, 12);
            this.btnEMail.Name = "btnEMail";
            this.btnEMail.Size = new System.Drawing.Size(75, 41);
            this.btnEMail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEMail.TabIndex = 12;
            this.btnEMail.Text = "寄發EMail";
            this.btnEMail.Visible = false;
            this.btnEMail.Click += new System.EventHandler(this.btnEMail_Click);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(20, 7);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "教師";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(19, 47);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "班級";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTeacher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTeacher.DisplayMember = "name";
            this.cmbTeacher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.ItemHeight = 19;
            this.cmbTeacher.Location = new System.Drawing.Point(67, 4);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(121, 25);
            this.cmbTeacher.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTeacher.TabIndex = 5;
            this.cmbTeacher.ValueMember = "id";
            // 
            // cmbClass
            // 
            this.cmbClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClass.DisplayMember = "Name";
            this.cmbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.ItemHeight = 19;
            this.cmbClass.Location = new System.Drawing.Point(67, 47);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 25);
            this.cmbClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbClass.TabIndex = 6;
            this.cmbClass.ValueMember = "id";
            // 
            // pnlQueryByResource
            // 
            this.pnlQueryByResource.BackColor = System.Drawing.Color.Transparent;
            this.pnlQueryByResource.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlQueryByResource.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlQueryByResource.Controls.Add(this.cmbClass);
            this.pnlQueryByResource.Controls.Add(this.cmbTeacher);
            this.pnlQueryByResource.Controls.Add(this.labelX3);
            this.pnlQueryByResource.Controls.Add(this.labelX4);
            this.pnlQueryByResource.DrawTitleBox = false;
            this.pnlQueryByResource.Enabled = false;
            this.pnlQueryByResource.Location = new System.Drawing.Point(282, 12);
            this.pnlQueryByResource.Name = "pnlQueryByResource";
            this.pnlQueryByResource.Size = new System.Drawing.Size(224, 113);
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
            this.pnlQueryByResource.TabIndex = 8;
            this.pnlQueryByResource.Text = "選擇教師或班級";
            // 
            // errStartTime
            // 
            this.errStartTime.ContainerControl = this;
            // 
            // errEndTime
            // 
            this.errEndTime.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(789, 539);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.chkReplace);
            this.groupPanel2.Controls.Add(this.chkExchange);
            this.groupPanel2.Controls.Add(this.chkExchangeReplace);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(526, 11);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(201, 113);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 15;
            this.groupPanel2.Text = "查詢項目";
            // 
            // chkReplace
            // 
            // 
            // 
            // 
            this.chkReplace.BackgroundStyle.Class = "";
            this.chkReplace.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkReplace.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkReplace.Location = new System.Drawing.Point(18, 57);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(100, 23);
            this.chkReplace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkReplace.TabIndex = 2;
            this.chkReplace.Text = "只出現代課";
            // 
            // chkExchange
            // 
            // 
            // 
            // 
            this.chkExchange.BackgroundStyle.Class = "";
            this.chkExchange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkExchange.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkExchange.Location = new System.Drawing.Point(18, 28);
            this.chkExchange.Name = "chkExchange";
            this.chkExchange.Size = new System.Drawing.Size(100, 23);
            this.chkExchange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkExchange.TabIndex = 1;
            this.chkExchange.Text = "只出現調課";
            // 
            // chkExchangeReplace
            // 
            this.chkExchangeReplace.AutoSize = true;
            // 
            // 
            // 
            this.chkExchangeReplace.BackgroundStyle.Class = "";
            this.chkExchangeReplace.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkExchangeReplace.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkExchangeReplace.Checked = true;
            this.chkExchangeReplace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExchangeReplace.CheckValue = "Y";
            this.chkExchangeReplace.Location = new System.Drawing.Point(18, -1);
            this.chkExchangeReplace.Name = "chkExchangeReplace";
            this.chkExchangeReplace.Size = new System.Drawing.Size(147, 21);
            this.chkExchangeReplace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkExchangeReplace.TabIndex = 0;
            this.chkExchangeReplace.Text = "同時出現調課及代課";
            // 
            // chkQueryByRole
            // 
            this.chkQueryByRole.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkQueryByRole.BackgroundStyle.Class = "";
            this.chkQueryByRole.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkQueryByRole.Location = new System.Drawing.Point(291, 7);
            this.chkQueryByRole.Name = "chkQueryByRole";
            this.chkQueryByRole.Size = new System.Drawing.Size(100, 23);
            this.chkQueryByRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkQueryByRole.TabIndex = 17;
            this.chkQueryByRole.Text = "依對象查詢";
            // 
            // chkQueryByDate
            // 
            this.chkQueryByDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkQueryByDate.BackgroundStyle.Class = "";
            this.chkQueryByDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkQueryByDate.Location = new System.Drawing.Point(30, 9);
            this.chkQueryByDate.Name = "chkQueryByDate";
            this.chkQueryByDate.Size = new System.Drawing.Size(100, 23);
            this.chkQueryByDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkQueryByDate.TabIndex = 8;
            this.chkQueryByDate.Text = "依日期查詢";
            // 
            // btnWeekday
            // 
            this.btnWeekday.GlobalItem = false;
            this.btnWeekday.Name = "btnWeekday";
            this.btnWeekday.Text = "週代課單";
            // 
            // frmExchangeReplaceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 575);
            this.Controls.Add(this.chkQueryByRole);
            this.Controls.Add(this.chkQueryByDate);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnEMail);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.pnlQueryByResource);
            this.Controls.Add(this.pnlQueryByDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmExchangeReplaceReport";
            this.Text = "";
            this.TitleText = "調代課通知單";
            this.Load += new System.EventHandler(this.frmExchangeReplaceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.pnlQueryByDate.ResumeLayout(false);
            this.pnlQueryByDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).EndInit();
            this.pnlQueryByResource.ResumeLayout(false);
            this.pnlQueryByResource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdResult;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryByDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateStart;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnEMail;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTeacher;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbClass;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlQueryByResource;
        private System.Windows.Forms.ErrorProvider errStartTime;
        private System.Windows.Forms.ErrorProvider errEndTime;
        private DevComponents.DotNetBar.ButtonItem btnReportOption;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkReplace;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkExchange;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkExchangeReplace;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryByRole;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkQueryByDate;
        private DevComponents.DotNetBar.ButtonItem btnWeekday;

    }
}