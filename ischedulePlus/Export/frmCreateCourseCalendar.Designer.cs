namespace ischedulePlus
{
    partial class frmCreateCourseCalendar
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
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblSchoolYearSemester = new DevComponents.DotNetBar.LabelX();
            this.txtFilename = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblViewFormat = new DevComponents.DotNetBar.LabelX();
            this.btnCreateCourseCalendar = new DevComponents.DotNetBar.ButtonX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpen.Location = new System.Drawing.Point(368, 43);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(27, 23);
            this.btnOpen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "…";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(340, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSchoolYearSemester
            // 
            this.lblSchoolYearSemester.AutoSize = true;
            this.lblSchoolYearSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSchoolYearSemester.BackgroundStyle.Class = "";
            this.lblSchoolYearSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSchoolYearSemester.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSchoolYearSemester.Location = new System.Drawing.Point(2, 92);
            this.lblSchoolYearSemester.Name = "lblSchoolYearSemester";
            this.lblSchoolYearSemester.Size = new System.Drawing.Size(87, 21);
            this.lblSchoolYearSemester.TabIndex = 4;
            this.lblSchoolYearSemester.Text = "查詢學期設定";
            this.lblSchoolYearSemester.Click += new System.EventHandler(this.lblSchoolYearSemester_Click);
            // 
            // txtFilename
            // 
            // 
            // 
            // 
            this.txtFilename.Border.Class = "TextBoxBorder";
            this.txtFilename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFilename.Location = new System.Drawing.Point(15, 41);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(347, 25);
            this.txtFilename.TabIndex = 5;
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
            this.labelX1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelX1.Location = new System.Drawing.Point(15, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(346, 21);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "選擇檔案（Excel格式），請確認匯入資料在第一個資料表";
            // 
            // lblViewFormat
            // 
            this.lblViewFormat.AutoSize = true;
            this.lblViewFormat.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblViewFormat.BackgroundStyle.Class = "";
            this.lblViewFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblViewFormat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblViewFormat.Location = new System.Drawing.Point(95, 92);
            this.lblViewFormat.Name = "lblViewFormat";
            this.lblViewFormat.Size = new System.Drawing.Size(114, 21);
            this.lblViewFormat.TabIndex = 7;
            this.lblViewFormat.Text = "學期課表匯入格式";
            this.lblViewFormat.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // btnCreateCourseCalendar
            // 
            this.btnCreateCourseCalendar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreateCourseCalendar.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateCourseCalendar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCreateCourseCalendar.Location = new System.Drawing.Point(215, 90);
            this.btnCreateCourseCalendar.Name = "btnCreateCourseCalendar";
            this.btnCreateCourseCalendar.Size = new System.Drawing.Size(111, 23);
            this.btnCreateCourseCalendar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCreateCourseCalendar.TabIndex = 8;
            this.btnCreateCourseCalendar.Text = "產生課程行事曆";
            this.btnCreateCourseCalendar.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // progressBarX1
            // 
            this.progressBarX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.Class = "";
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarX1.Location = new System.Drawing.Point(0, 140);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(412, 23);
            this.progressBarX1.TabIndex = 10;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // frmCreateCourseCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 163);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.btnCreateCourseCalendar);
            this.Controls.Add(this.lblViewFormat);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lblSchoolYearSemester);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.MaximumSize = new System.Drawing.Size(420, 190);
            this.MinimumSize = new System.Drawing.Size(420, 190);
            this.Name = "frmCreateCourseCalendar";
            this.Text = "";
            this.TitleText = "產生課程行事曆";
            this.Load += new System.EventHandler(this.frmCreateCourseCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOpen;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.LabelX lblSchoolYearSemester;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFilename;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblViewFormat;
        private DevComponents.DotNetBar.ButtonX btnCreateCourseCalendar;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
    }
}