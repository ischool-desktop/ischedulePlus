namespace ischedulePlus
{
    partial class frmExportShinHer
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
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.txtFilename = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtSchoolYear = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSemester = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(201, 80);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "匯出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtFilename
            // 
            // 
            // 
            // 
            this.txtFilename.Border.Class = "TextBoxBorder";
            this.txtFilename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFilename.Location = new System.Drawing.Point(11, 41);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(347, 25);
            this.txtFilename.TabIndex = 17;
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
            this.btnOpen.TabIndex = 16;
            this.btnOpen.Text = "…";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
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
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(346, 21);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "選擇檔案（Excel格式），請確認匯入資料在第一個資料表";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(289, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "關閉";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.labelX2.Location = new System.Drawing.Point(15, 80);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 21);
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "學年度";
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
            this.labelX3.Location = new System.Drawing.Point(118, 80);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 20;
            this.labelX3.Text = "學期";
            // 
            // txtSchoolYear
            // 
            // 
            // 
            // 
            this.txtSchoolYear.Border.Class = "TextBoxBorder";
            this.txtSchoolYear.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchoolYear.Location = new System.Drawing.Point(67, 76);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(39, 25);
            this.txtSchoolYear.TabIndex = 21;
            // 
            // txtSemester
            // 
            // 
            // 
            // 
            this.txtSemester.Border.Class = "TextBoxBorder";
            this.txtSemester.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSemester.Location = new System.Drawing.Point(158, 77);
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(28, 25);
            this.txtSemester.TabIndex = 22;
            // 
            // frmExportShinHer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 114);
            this.Controls.Add(this.txtSemester);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Name = "frmExportShinHer";
            this.Text = "連線設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFilename;
        private DevComponents.DotNetBar.ButtonX btnOpen;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSchoolYear;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSemester;
    }
}