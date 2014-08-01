namespace ischedulePlus
{
    partial class frmCreateCourseCalendarConfirm
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
            this.btnConfirmInsert = new DevComponents.DotNetBar.ButtonX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnConfirmInsert
            // 
            this.btnConfirmInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirmInsert.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirmInsert.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfirmInsert.Location = new System.Drawing.Point(198, 51);
            this.btnConfirmInsert.Name = "btnConfirmInsert";
            this.btnConfirmInsert.Size = new System.Drawing.Size(87, 31);
            this.btnConfirmInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirmInsert.TabIndex = 11;
            this.btnConfirmInsert.Text = "確認匯入";
            this.btnConfirmInsert.Tooltip = "將依開始日期時間及教師名稱做為鍵值更新";
            this.btnConfirmInsert.Click += new System.EventHandler(this.btnConfirmInsert_Click);
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
            this.progressBarX1.Location = new System.Drawing.Point(0, 90);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(292, 23);
            this.progressBarX1.TabIndex = 13;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCount.BackgroundStyle.Class = "";
            this.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCount.Location = new System.Drawing.Point(18, 11);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 0);
            this.lblCount.TabIndex = 14;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.Transparent;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonX1.Location = new System.Drawing.Point(103, 51);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(81, 31);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 15;
            this.buttonX1.Text = "檢視報告";
            this.buttonX1.Tooltip = "將依開始日期時間及教師名稱做為鍵值更新";
            this.buttonX1.Click += new System.EventHandler(this.lblViewReport_Click);
            // 
            // frmCreateCourseCalendarConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 113);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.btnConfirmInsert);
            this.MaximumSize = new System.Drawing.Size(300, 140);
            this.MinimumSize = new System.Drawing.Size(300, 140);
            this.Name = "frmCreateCourseCalendarConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleText = "產生課程行事曆確認";
            this.Load += new System.EventHandler(this.frmCreateCourseCalendarConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnConfirmInsert;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private DevComponents.DotNetBar.LabelX lblCount;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}