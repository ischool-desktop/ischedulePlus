namespace ischedulePlus
{
    partial class SchoolYearSemesterCreatorForm
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cmbSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dteEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dteStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmbSchoolYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.errorNameDuplicate = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNameDuplicate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.cmbSemester);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.dteEnd);
            this.panelEx1.Controls.Add(this.dteStart);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.cmbSchoolYear);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnSave);
            this.panelEx1.Controls.Add(this.lblName);
            this.panelEx1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panelEx1.Location = new System.Drawing.Point(3, 3);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(245, 177);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // cmbSemester
            // 
            this.cmbSemester.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSemester.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemester.DisplayMember = "Text";
            this.cmbSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.ItemHeight = 19;
            this.cmbSemester.Location = new System.Drawing.Point(86, 45);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(145, 25);
            this.cmbSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSemester.TabIndex = 10;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(11, 107);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "結束日期";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(11, 76);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "開始日期";
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
            this.dteEnd.Location = new System.Drawing.Point(86, 107);
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
            this.dteEnd.MonthCalendar.DisplayMonth = new System.DateTime(2013, 7, 1, 0, 0, 0, 0);
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
            this.dteEnd.Size = new System.Drawing.Size(145, 25);
            this.dteEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteEnd.TabIndex = 7;
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
            this.dteStart.Location = new System.Drawing.Point(86, 76);
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
            this.dteStart.MonthCalendar.DisplayMonth = new System.DateTime(2013, 7, 1, 0, 0, 0, 0);
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
            this.dteStart.Size = new System.Drawing.Size(145, 25);
            this.dteStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteStart.TabIndex = 6;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(37, 45);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "學期";
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSchoolYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSchoolYear.DisplayMember = "Text";
            this.cmbSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.ItemHeight = 19;
            this.cmbSchoolYear.Location = new System.Drawing.Point(86, 12);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(145, 25);
            this.cmbSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSchoolYear.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(176, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnClose);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(111, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            // 
            // 
            // 
            this.lblName.BackgroundStyle.Class = "";
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Location = new System.Drawing.Point(24, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "學年度";
            // 
            // errorNameDuplicate
            // 
            this.errorNameDuplicate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorNameDuplicate.ContainerControl = this;
            // 
            // SchoolYearSemesterCreatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(251, 184);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SchoolYearSemesterCreatorForm";
            this.Text = "";
            this.Load += new System.EventHandler(this.TeacherNameCreatorForm_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNameDuplicate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.ErrorProvider errorNameDuplicate;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteStart;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSemester;
    }
}