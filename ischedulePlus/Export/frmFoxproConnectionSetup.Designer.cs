namespace ischedulePlus
{
    partial class frmFoxproConnectionSetup
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
            this.txtDirectory = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnConnSetup = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtDirectory
            // 
            // 
            // 
            // 
            this.txtDirectory.Border.Class = "TextBoxBorder";
            this.txtDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDirectory.Location = new System.Drawing.Point(77, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(265, 25);
            this.txtDirectory.TabIndex = 13;
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
            this.labelX1.Location = new System.Drawing.Point(7, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "連線目錄";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(274, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "儲存設定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConnSetup
            // 
            this.btnConnSetup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnSetup.BackColor = System.Drawing.Color.Transparent;
            this.btnConnSetup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnSetup.Location = new System.Drawing.Point(193, 50);
            this.btnConnSetup.Name = "btnConnSetup";
            this.btnConnSetup.Size = new System.Drawing.Size(75, 23);
            this.btnConnSetup.TabIndex = 14;
            this.btnConnSetup.Text = "測試連線";
            this.btnConnSetup.Click += new System.EventHandler(this.btnConnSetup_Click);
            // 
            // frmFoxproConnectionSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 83);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnConnSetup);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.labelX1);
            this.MaximumSize = new System.Drawing.Size(360, 110);
            this.MinimumSize = new System.Drawing.Size(360, 110);
            this.Name = "frmFoxproConnectionSetup";
            this.Text = "連線設定";
            this.Load += new System.EventHandler(this.frmFoxproConnectionSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtDirectory;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnConnSetup;
    }
}