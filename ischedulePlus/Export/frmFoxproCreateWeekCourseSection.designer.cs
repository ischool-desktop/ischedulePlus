namespace ischedulePlus
{
    partial class frmFoxproCreateWeekCourseSection
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
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbSemster = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbSchoolYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(142, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(23, 89);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "匯出排課結果";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(8, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 21);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = "學年度";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(21, 50);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 13;
            this.labelX4.Text = "學期";
            // 
            // cmbSemster
            // 
            this.cmbSemster.DisplayMember = "Text";
            this.cmbSemster.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSemster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemster.FormattingEnabled = true;
            this.cmbSemster.ItemHeight = 19;
            this.cmbSemster.Location = new System.Drawing.Point(75, 50);
            this.cmbSemster.Name = "cmbSemster";
            this.cmbSemster.Size = new System.Drawing.Size(121, 25);
            this.cmbSemster.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSemster.TabIndex = 16;
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.DisplayMember = "Text";
            this.cmbSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.ItemHeight = 19;
            this.cmbSchoolYear.Location = new System.Drawing.Point(75, 10);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(121, 25);
            this.cmbSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSchoolYear.TabIndex = 17;
            // 
            // frmFoxproCreateWeekCourseSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 128);
            this.Controls.Add(this.cmbSchoolYear);
            this.Controls.Add(this.cmbSemster);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(215, 150);
            this.MinimumSize = new System.Drawing.Size(215, 150);
            this.Name = "frmFoxproCreateWeekCourseSection";
            this.Text = "";
            this.TitleText = "新民排課資料匯出";
            this.Load += new System.EventHandler(this.frmCreateWeekCourseSection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSemster;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSchoolYear;
    }
}