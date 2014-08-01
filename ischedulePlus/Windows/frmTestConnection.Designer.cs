namespace ischedulePlus
{
    partial class frmTestConnection
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
            this.cmbFirstSchool = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbSecondSchool = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
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
            this.labelX1.Location = new System.Drawing.Point(5, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(74, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "連線學校一";
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
            this.labelX2.Location = new System.Drawing.Point(5, 47);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 21);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "連線學校二";
            // 
            // cmbFirstSchool
            // 
            this.cmbFirstSchool.DisplayMember = "Text";
            this.cmbFirstSchool.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFirstSchool.FormattingEnabled = true;
            this.cmbFirstSchool.ItemHeight = 19;
            this.cmbFirstSchool.Location = new System.Drawing.Point(90, 12);
            this.cmbFirstSchool.Name = "cmbFirstSchool";
            this.cmbFirstSchool.Size = new System.Drawing.Size(172, 25);
            this.cmbFirstSchool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbFirstSchool.TabIndex = 2;
            // 
            // cmbSecondSchool
            // 
            this.cmbSecondSchool.DisplayMember = "Text";
            this.cmbSecondSchool.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSecondSchool.FormattingEnabled = true;
            this.cmbSecondSchool.ItemHeight = 19;
            this.cmbSecondSchool.Location = new System.Drawing.Point(90, 43);
            this.cmbSecondSchool.Name = "cmbSecondSchool";
            this.cmbSecondSchool.Size = new System.Drawing.Size(172, 25);
            this.cmbSecondSchool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSecondSchool.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(104, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "設定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(185, 79);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmTestConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 115);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbSecondSchool);
            this.Controls.Add(this.cmbFirstSchool);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "frmTestConnection";
            this.Text = "";
            this.TitleText = "設定連線資訊";
            this.Load += new System.EventHandler(this.frmTestConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbFirstSchool;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSecondSchool;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnExit;
    }
}