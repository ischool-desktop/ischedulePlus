namespace ischedulePlus
{
    partial class frmTemplateConfig
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
            this.btnSet = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkReplaceUpload = new System.Windows.Forms.LinkLabel();
            this.chkReplaceCustom = new System.Windows.Forms.RadioButton();
            this.chkReplaceDefault = new System.Windows.Forms.RadioButton();
            this.lnkReplaceDefault = new System.Windows.Forms.LinkLabel();
            this.lnkReplaceCustom = new System.Windows.Forms.LinkLabel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkExchangeUpload = new System.Windows.Forms.LinkLabel();
            this.chkExchangeCustom = new System.Windows.Forms.RadioButton();
            this.chkExchangeDefault = new System.Windows.Forms.RadioButton();
            this.lnkExchangeDefault = new System.Windows.Forms.LinkLabel();
            this.lnkExchagneCustom = new System.Windows.Forms.LinkLabel();
            this.groupPanel4.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet.Location = new System.Drawing.Point(68, 290);
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
            this.btnExit.Location = new System.Drawing.Point(149, 290);
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
            this.groupPanel4.Controls.Add(this.groupPanel1);
            this.groupPanel4.Controls.Add(this.groupPanel2);
            this.groupPanel4.Location = new System.Drawing.Point(7, 3);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(221, 273);
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
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lnkReplaceUpload);
            this.groupPanel1.Controls.Add(this.chkReplaceCustom);
            this.groupPanel1.Controls.Add(this.chkReplaceDefault);
            this.groupPanel1.Controls.Add(this.lnkReplaceDefault);
            this.groupPanel1.Controls.Add(this.lnkReplaceCustom);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(10, 129);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(195, 98);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "代課通知單";
            // 
            // lnkReplaceUpload
            // 
            this.lnkReplaceUpload.AutoSize = true;
            this.lnkReplaceUpload.BackColor = System.Drawing.Color.Transparent;
            this.lnkReplaceUpload.Location = new System.Drawing.Point(141, 40);
            this.lnkReplaceUpload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkReplaceUpload.Name = "lnkReplaceUpload";
            this.lnkReplaceUpload.Size = new System.Drawing.Size(34, 17);
            this.lnkReplaceUpload.TabIndex = 23;
            this.lnkReplaceUpload.TabStop = true;
            this.lnkReplaceUpload.Text = "上傳";
            this.lnkReplaceUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReplaceUpload_LinkClicked);
            // 
            // chkReplaceCustom
            // 
            this.chkReplaceCustom.AutoSize = true;
            this.chkReplaceCustom.BackColor = System.Drawing.Color.Transparent;
            this.chkReplaceCustom.ForeColor = System.Drawing.Color.Blue;
            this.chkReplaceCustom.Location = new System.Drawing.Point(15, 38);
            this.chkReplaceCustom.Name = "chkReplaceCustom";
            this.chkReplaceCustom.Size = new System.Drawing.Size(78, 21);
            this.chkReplaceCustom.TabIndex = 22;
            this.chkReplaceCustom.Text = "自訂範本";
            this.chkReplaceCustom.UseVisualStyleBackColor = false;
            this.chkReplaceCustom.CheckedChanged += new System.EventHandler(this.chkReplaceCustom_CheckedChanged);
            // 
            // chkReplaceDefault
            // 
            this.chkReplaceDefault.AutoSize = true;
            this.chkReplaceDefault.BackColor = System.Drawing.Color.Transparent;
            this.chkReplaceDefault.ForeColor = System.Drawing.Color.Blue;
            this.chkReplaceDefault.Location = new System.Drawing.Point(15, 9);
            this.chkReplaceDefault.Name = "chkReplaceDefault";
            this.chkReplaceDefault.Size = new System.Drawing.Size(78, 21);
            this.chkReplaceDefault.TabIndex = 21;
            this.chkReplaceDefault.Text = "預設範本";
            this.chkReplaceDefault.UseVisualStyleBackColor = false;
            this.chkReplaceDefault.CheckedChanged += new System.EventHandler(this.chkReplaceDefault_CheckedChanged);
            // 
            // lnkReplaceDefault
            // 
            this.lnkReplaceDefault.AutoSize = true;
            this.lnkReplaceDefault.Location = new System.Drawing.Point(100, 11);
            this.lnkReplaceDefault.Name = "lnkReplaceDefault";
            this.lnkReplaceDefault.Size = new System.Drawing.Size(34, 17);
            this.lnkReplaceDefault.TabIndex = 2;
            this.lnkReplaceDefault.TabStop = true;
            this.lnkReplaceDefault.Text = "檢視";
            this.lnkReplaceDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReplaceDefault_LinkClicked);
            // 
            // lnkReplaceCustom
            // 
            this.lnkReplaceCustom.AutoSize = true;
            this.lnkReplaceCustom.Location = new System.Drawing.Point(100, 40);
            this.lnkReplaceCustom.Name = "lnkReplaceCustom";
            this.lnkReplaceCustom.Size = new System.Drawing.Size(34, 17);
            this.lnkReplaceCustom.TabIndex = 4;
            this.lnkReplaceCustom.TabStop = true;
            this.lnkReplaceCustom.Text = "檢視";
            this.lnkReplaceCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReplaceCustom_LinkClicked);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.lnkExchangeUpload);
            this.groupPanel2.Controls.Add(this.chkExchangeCustom);
            this.groupPanel2.Controls.Add(this.chkExchangeDefault);
            this.groupPanel2.Controls.Add(this.lnkExchangeDefault);
            this.groupPanel2.Controls.Add(this.lnkExchagneCustom);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(10, 14);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(195, 98);
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
            this.groupPanel2.Text = "調課通知單";
            // 
            // lnkExchangeUpload
            // 
            this.lnkExchangeUpload.AutoSize = true;
            this.lnkExchangeUpload.BackColor = System.Drawing.Color.Transparent;
            this.lnkExchangeUpload.Location = new System.Drawing.Point(141, 40);
            this.lnkExchangeUpload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkExchangeUpload.Name = "lnkExchangeUpload";
            this.lnkExchangeUpload.Size = new System.Drawing.Size(34, 17);
            this.lnkExchangeUpload.TabIndex = 23;
            this.lnkExchangeUpload.TabStop = true;
            this.lnkExchangeUpload.Text = "上傳";
            this.lnkExchangeUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpload);
            // 
            // chkExchangeCustom
            // 
            this.chkExchangeCustom.AutoSize = true;
            this.chkExchangeCustom.BackColor = System.Drawing.Color.Transparent;
            this.chkExchangeCustom.ForeColor = System.Drawing.Color.Blue;
            this.chkExchangeCustom.Location = new System.Drawing.Point(15, 38);
            this.chkExchangeCustom.Name = "chkExchangeCustom";
            this.chkExchangeCustom.Size = new System.Drawing.Size(78, 21);
            this.chkExchangeCustom.TabIndex = 22;
            this.chkExchangeCustom.Text = "自訂範本";
            this.chkExchangeCustom.UseVisualStyleBackColor = false;
            this.chkExchangeCustom.CheckedChanged += new System.EventHandler(this.chkExchangeCustom_CheckedChanged);
            // 
            // chkExchangeDefault
            // 
            this.chkExchangeDefault.AutoSize = true;
            this.chkExchangeDefault.BackColor = System.Drawing.Color.Transparent;
            this.chkExchangeDefault.ForeColor = System.Drawing.Color.Blue;
            this.chkExchangeDefault.Location = new System.Drawing.Point(15, 9);
            this.chkExchangeDefault.Name = "chkExchangeDefault";
            this.chkExchangeDefault.Size = new System.Drawing.Size(78, 21);
            this.chkExchangeDefault.TabIndex = 21;
            this.chkExchangeDefault.Text = "預設範本";
            this.chkExchangeDefault.UseVisualStyleBackColor = false;
            this.chkExchangeDefault.CheckedChanged += new System.EventHandler(this.chkExchangeDefault_CheckedChanged);
            // 
            // lnkExchangeDefault
            // 
            this.lnkExchangeDefault.AutoSize = true;
            this.lnkExchangeDefault.Location = new System.Drawing.Point(100, 11);
            this.lnkExchangeDefault.Name = "lnkExchangeDefault";
            this.lnkExchangeDefault.Size = new System.Drawing.Size(34, 17);
            this.lnkExchangeDefault.TabIndex = 2;
            this.lnkExchangeDefault.TabStop = true;
            this.lnkExchangeDefault.Text = "檢視";
            this.lnkExchangeDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefault_LinkClicked);
            // 
            // lnkExchagneCustom
            // 
            this.lnkExchagneCustom.AutoSize = true;
            this.lnkExchagneCustom.Location = new System.Drawing.Point(100, 40);
            this.lnkExchagneCustom.Name = "lnkExchagneCustom";
            this.lnkExchagneCustom.Size = new System.Drawing.Size(34, 17);
            this.lnkExchagneCustom.TabIndex = 4;
            this.lnkExchagneCustom.TabStop = true;
            this.lnkExchagneCustom.Text = "檢視";
            this.lnkExchagneCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustom_LinkClicked);
            // 
            // frmTemplateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 322);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSet);
            this.Name = "frmTemplateConfig";
            this.Text = "";
            this.TitleText = "調代課通知單變更設定";
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSet;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.RadioButton chkExchangeCustom;
        private System.Windows.Forms.RadioButton chkExchangeDefault;
        private System.Windows.Forms.LinkLabel lnkExchangeDefault;
        private System.Windows.Forms.LinkLabel lnkExchagneCustom;
        private System.Windows.Forms.LinkLabel lnkExchangeUpload;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.LinkLabel lnkReplaceUpload;
        private System.Windows.Forms.RadioButton chkReplaceCustom;
        private System.Windows.Forms.RadioButton chkReplaceDefault;
        private System.Windows.Forms.LinkLabel lnkReplaceDefault;
        private System.Windows.Forms.LinkLabel lnkReplaceCustom;
    }
}