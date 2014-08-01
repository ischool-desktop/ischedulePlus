namespace ischedulePlus
{
    partial class frmExchangeReplaceSatTemplateConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSet = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.chkCustom = new System.Windows.Forms.RadioButton();
            this.chkDefault = new System.Windows.Forms.RadioButton();
            this.lnkDefault = new System.Windows.Forms.LinkLabel();
            this.lnkCustom = new System.Windows.Forms.LinkLabel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grdPeriod = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupPanel4.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSet.Location = new System.Drawing.Point(95, 500);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet.TabIndex = 24;
            this.btnSet.Text = "確認";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(184, 500);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.groupPanel2);
            this.groupPanel4.Location = new System.Drawing.Point(14, 9);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(249, 138);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.Class = "";
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.Class = "";
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.Class = "";
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 27;
            this.groupPanel4.Text = "範本設定";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.linkLabel3);
            this.groupPanel2.Controls.Add(this.chkCustom);
            this.groupPanel2.Controls.Add(this.chkDefault);
            this.groupPanel2.Controls.Add(this.lnkDefault);
            this.groupPanel2.Controls.Add(this.lnkCustom);
            this.groupPanel2.Location = new System.Drawing.Point(10, 17);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(222, 76);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(141, 40);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(34, 17);
            this.linkLabel3.TabIndex = 23;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "上傳";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpload);
            // 
            // chkCustom
            // 
            this.chkCustom.AutoSize = true;
            this.chkCustom.BackColor = System.Drawing.Color.Transparent;
            this.chkCustom.ForeColor = System.Drawing.Color.Blue;
            this.chkCustom.Location = new System.Drawing.Point(15, 38);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(78, 21);
            this.chkCustom.TabIndex = 22;
            this.chkCustom.Text = "自訂範本";
            this.chkCustom.UseVisualStyleBackColor = false;
            this.chkCustom.CheckedChanged += new System.EventHandler(this.chkCustom_CheckedChanged);
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.BackColor = System.Drawing.Color.Transparent;
            this.chkDefault.ForeColor = System.Drawing.Color.Blue;
            this.chkDefault.Location = new System.Drawing.Point(15, 9);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(78, 21);
            this.chkDefault.TabIndex = 21;
            this.chkDefault.Text = "預設範本";
            this.chkDefault.UseVisualStyleBackColor = false;
            this.chkDefault.CheckedChanged += new System.EventHandler(this.chkDefault_CheckedChanged);
            // 
            // lnkDefault
            // 
            this.lnkDefault.AutoSize = true;
            this.lnkDefault.Location = new System.Drawing.Point(100, 11);
            this.lnkDefault.Name = "lnkDefault";
            this.lnkDefault.Size = new System.Drawing.Size(34, 17);
            this.lnkDefault.TabIndex = 2;
            this.lnkDefault.TabStop = true;
            this.lnkDefault.Text = "檢視";
            this.lnkDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefault_LinkClicked);
            // 
            // lnkCustom
            // 
            this.lnkCustom.AutoSize = true;
            this.lnkCustom.Location = new System.Drawing.Point(100, 40);
            this.lnkCustom.Name = "lnkCustom";
            this.lnkCustom.Size = new System.Drawing.Size(34, 17);
            this.lnkCustom.TabIndex = 4;
            this.lnkCustom.TabStop = true;
            this.lnkCustom.Text = "檢視";
            this.lnkCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustom_LinkClicked);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.grdPeriod);
            this.groupPanel1.Location = new System.Drawing.Point(14, 170);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(249, 319);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 28;
            this.groupPanel1.Text = "節次設定";
            // 
            // grdPeriod
            // 
            this.grdPeriod.AllowUserToAddRows = false;
            this.grdPeriod.AllowUserToDeleteRows = false;
            this.grdPeriod.AllowUserToResizeColumns = false;
            this.grdPeriod.AllowUserToResizeRows = false;
            this.grdPeriod.BackgroundColor = System.Drawing.Color.White;
            this.grdPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colPeriod,
            this.colType});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPeriod.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdPeriod.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdPeriod.Location = new System.Drawing.Point(11, 16);
            this.grdPeriod.Name = "grdPeriod";
            this.grdPeriod.RowHeadersVisible = false;
            this.grdPeriod.RowTemplate.Height = 24;
            this.grdPeriod.Size = new System.Drawing.Size(221, 264);
            this.grdPeriod.TabIndex = 1;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "選取";
            this.colCheck.MinimumWidth = 60;
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 60;
            // 
            // colPeriod
            // 
            this.colPeriod.HeaderText = "節次";
            this.colPeriod.MinimumWidth = 60;
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.Width = 60;
            // 
            // colType
            // 
            this.colType.HeaderText = "類別";
            this.colType.Items.AddRange(new object[] {
            "一般",
            "其他"});
            this.colType.MinimumWidth = 75;
            this.colType.Name = "colType";
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colType.Width = 75;
            // 
            // frmExchangeReplaceSatTemplateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 533);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSet);
            this.MaximumSize = new System.Drawing.Size(280, 560);
            this.MinimumSize = new System.Drawing.Size(280, 560);
            this.Name = "frmExchangeReplaceSatTemplateConfig";
            this.Text = "";
            this.TitleText = "請假代課統計報表變更設定";
            this.Load += new System.EventHandler(this.frmExchangeReplaceSatTemplateConfig_Load);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSet;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.RadioButton chkCustom;
        private System.Windows.Forms.RadioButton chkDefault;
        private System.Windows.Forms.LinkLabel lnkDefault;
        private System.Windows.Forms.LinkLabel lnkCustom;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdPeriod;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
    }
}