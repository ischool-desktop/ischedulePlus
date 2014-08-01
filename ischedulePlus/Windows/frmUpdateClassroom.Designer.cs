namespace ischedulePlus
{
    partial class frmUpdateClassroom
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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.cmbClassroom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(115, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(25, 54);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "確認";
            // 
            // cmbClassroom
            // 
            this.cmbClassroom.DisplayMember = "Text";
            this.cmbClassroom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClassroom.FormattingEnabled = true;
            this.cmbClassroom.ItemHeight = 19;
            this.cmbClassroom.Location = new System.Drawing.Point(61, 12);
            this.cmbClassroom.Name = "cmbClassroom";
            this.cmbClassroom.Size = new System.Drawing.Size(130, 25);
            this.cmbClassroom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbClassroom.TabIndex = 17;
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
            this.labelX4.Location = new System.Drawing.Point(14, 13);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 16;
            this.labelX4.Text = "場地";
            // 
            // frmUpdateClassroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 93);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbClassroom);
            this.Controls.Add(this.labelX4);
            this.Name = "frmUpdateClassroom";
            this.Text = "";
            this.TitleText = "批次修改場地";
            this.Load += new System.EventHandler(this.frmUpdateClassroom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbClassroom;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}