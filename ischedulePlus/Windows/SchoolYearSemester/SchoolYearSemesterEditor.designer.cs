namespace ischedulePlus
{
    partial class SchoolYearSemesterEditor
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dteEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dteStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.grdHoliday = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.grdGradeYear = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colGradeYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.contextMenuBusy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBusyDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFree = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoliday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.panelEx1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGradeYear)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuBusy.SuspendLayout();
            this.contextMenuStripDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.panel2);
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(530, 434);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dteEnd);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.dteStart);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Controls.Add(this.grdHoliday);
            this.panel2.Controls.Add(this.grdGradeYear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 400);
            this.panel2.TabIndex = 4;
            // 
            // dteEnd
            // 
            // 
            // 
            // 
            this.dteEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dteEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dteEnd.ButtonDropDown.Visible = true;
            this.dteEnd.IsPopupCalendarOpen = false;
            this.dteEnd.Location = new System.Drawing.Point(367, 18);
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dteEnd.MonthCalendar.BackgroundStyle.Class = "";
            this.dteEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.MonthCalendar.DisplayMonth = new System.DateTime(2013, 8, 1, 0, 0, 0, 0);
            this.dteEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dteEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.MonthCalendar.TodayButtonVisible = true;
            this.dteEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(120, 25);
            this.dteEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteEnd.TabIndex = 5;
            this.dteEnd.ValueChanged += new System.EventHandler(this.dteEnd_ValueChanged);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(270, 22);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(101, 21);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "預設結束日期：";
            // 
            // dteStart
            // 
            // 
            // 
            // 
            this.dteStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dteStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dteStart.ButtonDropDown.Visible = true;
            this.dteStart.IsPopupCalendarOpen = false;
            this.dteStart.Location = new System.Drawing.Point(128, 18);
            // 
            // 
            // 
            this.dteStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dteStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dteStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.MonthCalendar.DisplayMonth = new System.DateTime(2013, 8, 1, 0, 0, 0, 0);
            this.dteStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dteStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.MonthCalendar.TodayButtonVisible = true;
            this.dteStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(120, 25);
            this.dteStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteStart.TabIndex = 3;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(101, 21);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "預設開始日期：";
            // 
            // grdHoliday
            // 
            this.grdHoliday.BackgroundColor = System.Drawing.Color.White;
            this.grdHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHoliday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoliday,
            this.colPeriod});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdHoliday.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdHoliday.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdHoliday.Location = new System.Drawing.Point(31, 233);
            this.grdHoliday.Name = "grdHoliday";
            this.grdHoliday.Size = new System.Drawing.Size(469, 133);
            this.grdHoliday.TabIndex = 1;
            this.grdHoliday.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHoliday_CellContentClick);
            this.grdHoliday.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHoliday_CellEndEdit);
            this.grdHoliday.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdHoliday_CellValidating);
            // 
            // grdGradeYear
            // 
            this.grdGradeYear.BackgroundColor = System.Drawing.Color.White;
            this.grdGradeYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGradeYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGradeYear,
            this.colStartDate,
            this.colEndDate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGradeYear.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdGradeYear.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdGradeYear.Location = new System.Drawing.Point(31, 61);
            this.grdGradeYear.Name = "grdGradeYear";
            this.grdGradeYear.RowTemplate.Height = 24;
            this.grdGradeYear.Size = new System.Drawing.Size(469, 150);
            this.grdGradeYear.TabIndex = 0;
            this.grdGradeYear.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGradeYear_CellEndEdit);
            // 
            // colGradeYear
            // 
            this.colGradeYear.HeaderText = "年級";
            this.colGradeYear.Name = "colGradeYear";
            // 
            // colStartDate
            // 
            this.colStartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStartDate.HeaderText = "開始日期";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEndDate
            // 
            this.colEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEndDate.HeaderText = "結束日期";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 34);
            this.panel1.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            // 
            // 
            // 
            this.lblName.BackgroundStyle.Class = "";
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblName.Location = new System.Drawing.Point(3, 1);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(107, 32);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "學年度學期";
            // 
            // contextMenuBusy
            // 
            this.contextMenuBusy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBusy,
            this.menuBusyDesc,
            this.menuFree});
            this.contextMenuBusy.Name = "contextMenuStrip1";
            this.contextMenuBusy.ShowImageMargin = false;
            this.contextMenuBusy.Size = new System.Drawing.Size(186, 70);
            // 
            // menuBusy
            // 
            this.menuBusy.Name = "menuBusy";
            this.menuBusy.Size = new System.Drawing.Size(185, 22);
            this.menuBusy.Text = "設定不排課時段";
            // 
            // menuBusyDesc
            // 
            this.menuBusyDesc.Name = "menuBusyDesc";
            this.menuBusyDesc.Size = new System.Drawing.Size(185, 22);
            this.menuBusyDesc.Text = "設定不排課時段(指定描述)";
            // 
            // menuFree
            // 
            this.menuFree.Name = "menuFree";
            this.menuFree.Size = new System.Drawing.Size(185, 22);
            this.menuFree.Text = "取消設定";
            // 
            // contextMenuStripDelete
            // 
            this.contextMenuStripDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStripDelete.Name = "contextMenuStrip1";
            this.contextMenuStripDelete.ShowImageMargin = false;
            this.contextMenuStripDelete.Size = new System.Drawing.Size(70, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(69, 22);
            this.toolStripMenuItem2.Text = "刪除";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "星期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.ToolTipText = "只能輸入1到7";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "開始時間";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = "結束時間";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "不排課描述";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // colSubject
            // 
            this.colSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSubject.HeaderText = "科目";
            this.colSubject.Name = "colSubject";
            // 
            // colLevel
            // 
            this.colLevel.HeaderText = "級別";
            this.colLevel.Name = "colLevel";
            // 
            // colHoliday
            // 
            this.colHoliday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colHoliday.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHoliday.HeaderText = "假日";
            this.colHoliday.MinimumWidth = 100;
            this.colHoliday.Name = "colHoliday";
            this.colHoliday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colPeriod
            // 
            this.colPeriod.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            this.colPeriod.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPeriod.HeaderText = "節次設定";
            this.colPeriod.MinimumWidth = 200;
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colPeriod.Text = null;
            this.colPeriod.Width = 200;
            // 
            // SchoolYearSemesterEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "SchoolYearSemesterEditor";
            this.Size = new System.Drawing.Size(530, 434);
            this.panelEx1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGradeYear)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuBusy.ResumeLayout(false);
            this.contextMenuStripDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ContextMenuStrip contextMenuBusy;
        private System.Windows.Forms.ToolStripMenuItem menuBusy;
        private System.Windows.Forms.ToolStripMenuItem menuFree;
        private System.Windows.Forms.ToolStripMenuItem menuBusyDesc;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdHoliday;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdGradeYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGradeYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteStart;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteEnd;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoliday;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colPeriod;
    }
}
