namespace ischedulePlus
{
    partial class frmExchangeReplaceSatReport
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
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.errStartTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.errEndTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lnkPrintSetup = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(108, 86);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 24);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "列印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // errStartTime
            // 
            this.errStartTime.ContainerControl = this;
            // 
            // errEndTime
            // 
            this.errEndTime.ContainerControl = this;
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
            this.dateEnd.Location = new System.Drawing.Point(92, 44);
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
            this.dateEnd.Size = new System.Drawing.Size(135, 25);
            this.dateEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateEnd.TabIndex = 15;
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
            this.dateStart.Location = new System.Drawing.Point(92, 13);
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
            this.dateStart.Size = new System.Drawing.Size(135, 25);
            this.dateStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateStart.TabIndex = 14;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 16;
            this.labelX1.Text = "開始日期";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(16, 44);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 17;
            this.labelX2.Text = "結束日期";
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(170, 86);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 24);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lnkPrintSetup
            // 
            this.lnkPrintSetup.AutoSize = true;
            this.lnkPrintSetup.BackColor = System.Drawing.Color.Transparent;
            this.lnkPrintSetup.Location = new System.Drawing.Point(24, 93);
            this.lnkPrintSetup.Name = "lnkPrintSetup";
            this.lnkPrintSetup.Size = new System.Drawing.Size(60, 17);
            this.lnkPrintSetup.TabIndex = 19;
            this.lnkPrintSetup.TabStop = true;
            this.lnkPrintSetup.Text = "列印設定";
            // 
            // frmExchangeReplaceSatReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 124);
            this.Controls.Add(this.lnkPrintSetup);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmExchangeReplaceSatReport";
            this.Text = "";
            this.TitleText = "請假代課統計表";
            this.Load += new System.EventHandler(this.frmExchangeReplaceMonthReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnPrint;
        private System.Windows.Forms.ErrorProvider errStartTime;
        private System.Windows.Forms.ErrorProvider errEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateStart;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.LinkLabel lnkPrintSetup;

    }
}