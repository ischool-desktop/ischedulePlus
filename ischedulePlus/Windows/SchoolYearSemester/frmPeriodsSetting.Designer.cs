namespace ischedulePlus
{
    partial class frmPeriodsSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdPeriod = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colPeriod = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.colCheck = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPeriod
            // 
            this.grdPeriod.AllowUserToAddRows = false;
            this.grdPeriod.AllowUserToDeleteRows = false;
            this.grdPeriod.BackgroundColor = System.Drawing.Color.White;
            this.grdPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeriod,
            this.colCheck});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPeriod.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPeriod.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdPeriod.Location = new System.Drawing.Point(19, 40);
            this.grdPeriod.Name = "grdPeriod";
            this.grdPeriod.RowHeadersVisible = false;
            this.grdPeriod.RowTemplate.Height = 24;
            this.grdPeriod.Size = new System.Drawing.Size(157, 233);
            this.grdPeriod.TabIndex = 0;
            // 
            // colPeriod
            // 
            this.colPeriod.HeaderText = "節次";
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.TextAlignment = System.Drawing.StringAlignment.Center;
            this.colPeriod.Width = 60;
            // 
            // colCheck
            // 
            this.colCheck.Checked = true;
            this.colCheck.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.colCheck.CheckValue = "N";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCheck.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCheck.HeaderText = "勾選";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 60;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(72, 285);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(47, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "確認";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(131, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.Class = "";
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(21, 11);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(54, 21);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 4;
            this.checkBoxX1.Text = "全選";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // frmPeriodsSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 323);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.grdPeriod);
            this.MaximumSize = new System.Drawing.Size(200, 350);
            this.MinimumSize = new System.Drawing.Size(200, 350);
            this.Name = "frmPeriodsSetting";
            this.Text = "";
            this.TitleText = "節次設定";
            this.Load += new System.EventHandler(this.frmPeriodsSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX grdPeriod;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn colPeriod;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn colCheck;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
    }
}