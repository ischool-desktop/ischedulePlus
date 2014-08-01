namespace ischedulePlus
{
    partial class frmConnectionSetup
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
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnConnSetup = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(175, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "儲存設定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConnSetup
            // 
            this.btnConnSetup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnSetup.BackColor = System.Drawing.Color.Transparent;
            this.btnConnSetup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnSetup.Location = new System.Drawing.Point(94, 150);
            this.btnConnSetup.Name = "btnConnSetup";
            this.btnConnSetup.Size = new System.Drawing.Size(75, 23);
            this.btnConnSetup.TabIndex = 5;
            this.btnConnSetup.Text = "測試連線";
            this.btnConnSetup.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(24, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "連線主機";
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
            this.labelX2.Location = new System.Drawing.Point(12, 45);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 21);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "連線資料庫";
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
            this.labelX3.Location = new System.Drawing.Point(52, 77);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "帳號";
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
            this.labelX4.Location = new System.Drawing.Point(52, 111);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "密碼";
            // 
            // txtServer
            // 
            // 
            // 
            // 
            this.txtServer.Border.Class = "TextBoxBorder";
            this.txtServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServer.Location = new System.Drawing.Point(94, 11);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(148, 25);
            this.txtServer.TabIndex = 11;
            // 
            // txtDatabase
            // 
            // 
            // 
            // 
            this.txtDatabase.Border.Class = "TextBoxBorder";
            this.txtDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDatabase.Location = new System.Drawing.Point(94, 45);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(148, 25);
            this.txtDatabase.TabIndex = 12;
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Location = new System.Drawing.Point(94, 78);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(148, 25);
            this.txtUser.TabIndex = 13;
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Location = new System.Drawing.Point(94, 112);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 25);
            this.txtPassword.TabIndex = 14;
            // 
            // frmConnectionSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 185);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnConnSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(270, 210);
            this.MinimumSize = new System.Drawing.Size(270, 210);
            this.Name = "frmConnectionSetup";
            this.Text = "連線設定";
            this.Load += new System.EventHandler(this.frmConnectionSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnConnSetup;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServer;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDatabase;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;

    }
}