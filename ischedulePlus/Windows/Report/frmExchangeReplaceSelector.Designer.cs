namespace ischedulePlus
{
    partial class frmExchangeReplaceSelector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdExchangeReplace = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.chkSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkDisplayExchangeHistory = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblHelp = new System.Windows.Forms.LinkLabel();
            this.chkDisplayExchangeBefore = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkDisplayDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkPrintToday = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.grdExchangeReplace)).BeginInit();
            this.SuspendLayout();
            // 
            // grdExchangeReplace
            // 
            this.grdExchangeReplace.AllowUserToAddRows = false;
            this.grdExchangeReplace.AllowUserToDeleteRows = false;
            this.grdExchangeReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExchangeReplace.BackgroundColor = System.Drawing.Color.White;
            this.grdExchangeReplace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExchangeReplace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colCheck});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdExchangeReplace.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdExchangeReplace.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdExchangeReplace.Location = new System.Drawing.Point(16, 44);
            this.grdExchangeReplace.Name = "grdExchangeReplace";
            this.grdExchangeReplace.RowHeadersVisible = false;
            this.grdExchangeReplace.RowTemplate.Height = 24;
            this.grdExchangeReplace.Size = new System.Drawing.Size(206, 278);
            this.grdExchangeReplace.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.HeaderText = "資源";
            this.colName.Name = "colName";
            this.colName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "列印";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.Width = 70;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.BackColor = System.Drawing.Color.Transparent;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonX1.Location = new System.Drawing.Point(57, 339);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "列印";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.BackColor = System.Drawing.Color.Transparent;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX2.Location = new System.Drawing.Point(145, 339);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "離開";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.Class = "";
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.CheckValue = "Y";
            this.chkSelectAll.Location = new System.Drawing.Point(15, 12);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(54, 21);
            this.chkSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "全選";
            // 
            // chkDisplayExchangeHistory
            // 
            this.chkDisplayExchangeHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDisplayExchangeHistory.AutoSize = true;
            this.chkDisplayExchangeHistory.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkDisplayExchangeHistory.BackgroundStyle.Class = "";
            this.chkDisplayExchangeHistory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDisplayExchangeHistory.Checked = true;
            this.chkDisplayExchangeHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayExchangeHistory.CheckValue = "Y";
            this.chkDisplayExchangeHistory.Location = new System.Drawing.Point(5, 376);
            this.chkDisplayExchangeHistory.Name = "chkDisplayExchangeHistory";
            this.chkDisplayExchangeHistory.Size = new System.Drawing.Size(134, 21);
            this.chkDisplayExchangeHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDisplayExchangeHistory.TabIndex = 6;
            this.chkDisplayExchangeHistory.Text = "顯示教師調課歷程";
            // 
            // lblHelp
            // 
            this.lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp.Location = new System.Drawing.Point(13, 339);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(34, 17);
            this.lblHelp.TabIndex = 7;
            this.lblHelp.TabStop = true;
            this.lblHelp.Text = "說明";
            this.lblHelp.Visible = false;
            // 
            // chkDisplayExchangeBefore
            // 
            this.chkDisplayExchangeBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDisplayExchangeBefore.AutoSize = true;
            this.chkDisplayExchangeBefore.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkDisplayExchangeBefore.BackgroundStyle.Class = "";
            this.chkDisplayExchangeBefore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDisplayExchangeBefore.Location = new System.Drawing.Point(6, 403);
            this.chkDisplayExchangeBefore.Name = "chkDisplayExchangeBefore";
            this.chkDisplayExchangeBefore.Size = new System.Drawing.Size(147, 21);
            this.chkDisplayExchangeBefore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDisplayExchangeBefore.TabIndex = 8;
            this.chkDisplayExchangeBefore.Text = "顯示教師調課原課程";
            // 
            // chkDisplayDate
            // 
            this.chkDisplayDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDisplayDate.AutoSize = true;
            this.chkDisplayDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkDisplayDate.BackgroundStyle.Class = "";
            this.chkDisplayDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDisplayDate.Checked = true;
            this.chkDisplayDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayDate.CheckValue = "Y";
            this.chkDisplayDate.Location = new System.Drawing.Point(145, 376);
            this.chkDisplayDate.Name = "chkDisplayDate";
            this.chkDisplayDate.Size = new System.Drawing.Size(80, 21);
            this.chkDisplayDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDisplayDate.TabIndex = 9;
            this.chkDisplayDate.Text = "顯示日期";
            // 
            // chkPrintToday
            // 
            this.chkPrintToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrintToday.AutoSize = true;
            this.chkPrintToday.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkPrintToday.BackgroundStyle.Class = "";
            this.chkPrintToday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkPrintToday.Location = new System.Drawing.Point(145, 403);
            this.chkPrintToday.Name = "chkPrintToday";
            this.chkPrintToday.Size = new System.Drawing.Size(80, 21);
            this.chkPrintToday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkPrintToday.TabIndex = 10;
            this.chkPrintToday.Text = "只印今日";
            // 
            // frmExchangeReplaceSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 431);
            this.Controls.Add(this.chkPrintToday);
            this.Controls.Add(this.chkDisplayDate);
            this.Controls.Add(this.chkDisplayExchangeBefore);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.chkDisplayExchangeHistory);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.grdExchangeReplace);
            this.Name = "frmExchangeReplaceSelector";
            this.Text = "     ";
            this.TitleText = "請選擇要列印的相關報表";
            this.Load += new System.EventHandler(this.frmExchangeReplaceSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdExchangeReplace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX grdExchangeReplace;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSelectAll;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkDisplayExchangeHistory;
        private System.Windows.Forms.LinkLabel lblHelp;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkDisplayExchangeBefore;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkDisplayDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkPrintToday;
    }
}