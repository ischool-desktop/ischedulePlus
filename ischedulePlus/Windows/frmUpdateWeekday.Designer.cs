namespace ischedulePlus
{
    partial class frmUpdateDate
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dteDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cmbWeekday = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate)).BeginInit();
            this.SuspendLayout();
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
            this.labelX1.Location = new System.Drawing.Point(9, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "日期";
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
            this.labelX2.Location = new System.Drawing.Point(12, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "星期";
            // 
            // dteDate
            // 
            this.dteDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dteDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dteDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dteDate.ButtonDropDown.Visible = true;
            this.dteDate.IsPopupCalendarOpen = false;
            this.dteDate.Location = new System.Drawing.Point(59, 16);
            // 
            // 
            // 
            this.dteDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dteDate.MonthCalendar.BackgroundStyle.Class = "";
            this.dteDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dteDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 9, 1, 0, 0, 0, 0);
            this.dteDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dteDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dteDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dteDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dteDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dteDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteDate.MonthCalendar.TodayButtonVisible = true;
            this.dteDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(130, 25);
            this.dteDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteDate.TabIndex = 4;
            // 
            // cmbWeekday
            // 
            this.cmbWeekday.DisplayMember = "Text";
            this.cmbWeekday.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWeekday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeekday.FormattingEnabled = true;
            this.cmbWeekday.ItemHeight = 19;
            this.cmbWeekday.Location = new System.Drawing.Point(59, 63);
            this.cmbWeekday.Name = "cmbWeekday";
            this.cmbWeekday.Size = new System.Drawing.Size(130, 25);
            this.cmbWeekday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbWeekday.TabIndex = 5;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(22, 103);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "確認";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            // 
            // frmUpdateDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 138);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbWeekday);
            this.Controls.Add(this.dteDate);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.MaximumSize = new System.Drawing.Size(210, 165);
            this.MinimumSize = new System.Drawing.Size(210, 165);
            this.Name = "frmUpdateDate";
            this.Text = "";
            this.TitleText = "批次修改日期";
            this.Load += new System.EventHandler(this.frmUpdateCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dteDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteDate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbWeekday;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}