namespace ischedulePlus
{
    partial class frmAbsenceConfirm
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
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbAbsenceName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtComment = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblAfterTeacher = new DevComponents.DotNetBar.LabelX();
            this.grdReplace = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdReplace)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOK.Location = new System.Drawing.Point(382, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "確認";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(471, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
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
            this.labelX3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX3.Location = new System.Drawing.Point(20, 235);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(41, 26);
            this.labelX3.TabIndex = 55;
            this.labelX3.Text = "註記";
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
            this.labelX4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX4.Location = new System.Drawing.Point(22, 293);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(41, 26);
            this.labelX4.TabIndex = 54;
            this.labelX4.Text = "假別";
            this.labelX4.Visible = false;
            // 
            // cmbAbsenceName
            // 
            this.cmbAbsenceName.DisplayMember = "Text";
            this.cmbAbsenceName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAbsenceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAbsenceName.FormattingEnabled = true;
            this.cmbAbsenceName.ItemHeight = 19;
            this.cmbAbsenceName.Location = new System.Drawing.Point(72, 294);
            this.cmbAbsenceName.Name = "cmbAbsenceName";
            this.cmbAbsenceName.Size = new System.Drawing.Size(77, 25);
            this.cmbAbsenceName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAbsenceName.TabIndex = 53;
            this.cmbAbsenceName.Visible = false;
            // 
            // txtComment
            // 
            // 
            // 
            // 
            this.txtComment.Border.Class = "TextBoxBorder";
            this.txtComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtComment.Location = new System.Drawing.Point(72, 223);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(474, 52);
            this.txtComment.TabIndex = 52;
            // 
            // lblAfterTeacher
            // 
            this.lblAfterTeacher.AutoSize = true;
            this.lblAfterTeacher.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblAfterTeacher.BackgroundStyle.Class = "";
            this.lblAfterTeacher.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAfterTeacher.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAfterTeacher.Location = new System.Drawing.Point(22, 12);
            this.lblAfterTeacher.Name = "lblAfterTeacher";
            this.lblAfterTeacher.Size = new System.Drawing.Size(87, 32);
            this.lblAfterTeacher.TabIndex = 58;
            this.lblAfterTeacher.Text = "缺課老師";
            // 
            // grdReplace
            // 
            this.grdReplace.AllowUserToAddRows = false;
            this.grdReplace.AllowUserToDeleteRows = false;
            this.grdReplace.BackgroundColor = System.Drawing.Color.White;
            this.grdReplace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReplace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdReplace.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdReplace.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdReplace.Location = new System.Drawing.Point(22, 54);
            this.grdReplace.Name = "grdReplace";
            this.grdReplace.ReadOnly = true;
            this.grdReplace.RowHeadersVisible = false;
            this.grdReplace.RowTemplate.Height = 24;
            this.grdReplace.Size = new System.Drawing.Size(524, 150);
            this.grdReplace.TabIndex = 59;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "缺課老師";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "日期";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "星期";
            this.Column3.MinimumWidth = 60;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "節次";
            this.Column4.MinimumWidth = 60;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "科目";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // frmAbsenceConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 332);
            this.Controls.Add(this.grdReplace);
            this.Controls.Add(this.lblAfterTeacher);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.cmbAbsenceName);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAbsenceConfirm";
            this.Text = "";
            this.TitleText = "代課確認";
            this.Load += new System.EventHandler(this.frmReplaceConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReplace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbAbsenceName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtComment;
        private DevComponents.DotNetBar.LabelX lblAfterTeacher;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdReplace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

    }
}