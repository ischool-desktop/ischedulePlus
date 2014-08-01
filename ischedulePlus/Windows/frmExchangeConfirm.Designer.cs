namespace ischedulePlus
{
    partial class frmExchangeConfirm
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
            this.txtComment = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.chkNoRecord = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmbAbsenceName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbAfterDate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbBeforeDate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblBeforeDate = new DevComponents.DotNetBar.LabelX();
            this.lblBeforeCourseName = new DevComponents.DotNetBar.LabelX();
            this.lblBeforeClassroom = new DevComponents.DotNetBar.LabelX();
            this.lblBeforeWeekdayPeriod = new DevComponents.DotNetBar.LabelX();
            this.lblBeforeTeacher = new DevComponents.DotNetBar.LabelX();
            this.lblAfterTeacher = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblAfterCourseName = new DevComponents.DotNetBar.LabelX();
            this.lblAfterClassroom = new DevComponents.DotNetBar.LabelX();
            this.lblAfterWeekdayPeriod = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.chkMultiExchagne = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.intMultiExchange = new DevComponents.Editors.IntegerInput();
            this.chkPrintReport = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intMultiExchange)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            // 
            // 
            // 
            this.txtComment.Border.Class = "TextBoxBorder";
            this.txtComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtComment.Location = new System.Drawing.Point(64, 285);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(371, 52);
            this.txtComment.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(356, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfirm.Location = new System.Drawing.Point(268, 351);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // chkNoRecord
            // 
            this.chkNoRecord.AutoSize = true;
            this.chkNoRecord.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkNoRecord.BackgroundStyle.Class = "";
            this.chkNoRecord.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkNoRecord.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkNoRecord.Location = new System.Drawing.Point(156, 210);
            this.chkNoRecord.Name = "chkNoRecord";
            this.chkNoRecord.Size = new System.Drawing.Size(242, 26);
            this.chkNoRecord.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkNoRecord.TabIndex = 16;
            this.chkNoRecord.Text = "直接調課，不儲存調課記錄。";
            // 
            // cmbAbsenceName
            // 
            this.cmbAbsenceName.DisplayMember = "Text";
            this.cmbAbsenceName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAbsenceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAbsenceName.FormattingEnabled = true;
            this.cmbAbsenceName.ItemHeight = 19;
            this.cmbAbsenceName.Location = new System.Drawing.Point(64, 208);
            this.cmbAbsenceName.Name = "cmbAbsenceName";
            this.cmbAbsenceName.Size = new System.Drawing.Size(77, 25);
            this.cmbAbsenceName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAbsenceName.TabIndex = 17;
            // 
            // cmbAfterDate
            // 
            this.cmbAfterDate.DisplayMember = "ExchangeDate";
            this.cmbAfterDate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAfterDate.FormattingEnabled = true;
            this.cmbAfterDate.ItemHeight = 19;
            this.cmbAfterDate.Location = new System.Drawing.Point(13, 13);
            this.cmbAfterDate.Name = "cmbAfterDate";
            this.cmbAfterDate.Size = new System.Drawing.Size(121, 25);
            this.cmbAfterDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAfterDate.TabIndex = 44;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cmbBeforeDate);
            this.groupPanel1.Controls.Add(this.lblBeforeDate);
            this.groupPanel1.Controls.Add(this.lblBeforeCourseName);
            this.groupPanel1.Controls.Add(this.lblBeforeClassroom);
            this.groupPanel1.Controls.Add(this.lblBeforeWeekdayPeriod);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(14, 26);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(205, 163);
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
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
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
            this.groupPanel1.TabIndex = 45;
            // 
            // cmbBeforeDate
            // 
            this.cmbBeforeDate.DisplayMember = "ExchangeDate";
            this.cmbBeforeDate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBeforeDate.FormattingEnabled = true;
            this.cmbBeforeDate.ItemHeight = 19;
            this.cmbBeforeDate.Location = new System.Drawing.Point(13, 13);
            this.cmbBeforeDate.Name = "cmbBeforeDate";
            this.cmbBeforeDate.Size = new System.Drawing.Size(121, 25);
            this.cmbBeforeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbBeforeDate.TabIndex = 45;
            // 
            // lblBeforeDate
            // 
            this.lblBeforeDate.AutoSize = true;
            this.lblBeforeDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblBeforeDate.BackgroundStyle.Class = "";
            this.lblBeforeDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBeforeDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBeforeDate.Location = new System.Drawing.Point(13, 15);
            this.lblBeforeDate.Name = "lblBeforeDate";
            this.lblBeforeDate.Size = new System.Drawing.Size(79, 26);
            this.lblBeforeDate.TabIndex = 44;
            this.lblBeforeDate.Text = "2013/8/1";
            this.lblBeforeDate.Visible = false;
            // 
            // lblBeforeCourseName
            // 
            this.lblBeforeCourseName.AutoSize = true;
            this.lblBeforeCourseName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblBeforeCourseName.BackgroundStyle.Class = "";
            this.lblBeforeCourseName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBeforeCourseName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBeforeCourseName.Location = new System.Drawing.Point(13, 82);
            this.lblBeforeCourseName.Name = "lblBeforeCourseName";
            this.lblBeforeCourseName.Size = new System.Drawing.Size(94, 26);
            this.lblBeforeCourseName.TabIndex = 43;
            this.lblBeforeCourseName.Text = "資一甲 英文";
            // 
            // lblBeforeClassroom
            // 
            this.lblBeforeClassroom.AutoSize = true;
            this.lblBeforeClassroom.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblBeforeClassroom.BackgroundStyle.Class = "";
            this.lblBeforeClassroom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBeforeClassroom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBeforeClassroom.Location = new System.Drawing.Point(13, 116);
            this.lblBeforeClassroom.Name = "lblBeforeClassroom";
            this.lblBeforeClassroom.Size = new System.Drawing.Size(74, 26);
            this.lblBeforeClassroom.TabIndex = 42;
            this.lblBeforeClassroom.Text = "電腦教室";
            // 
            // lblBeforeWeekdayPeriod
            // 
            this.lblBeforeWeekdayPeriod.AutoSize = true;
            this.lblBeforeWeekdayPeriod.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblBeforeWeekdayPeriod.BackgroundStyle.Class = "";
            this.lblBeforeWeekdayPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBeforeWeekdayPeriod.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBeforeWeekdayPeriod.Location = new System.Drawing.Point(13, 49);
            this.lblBeforeWeekdayPeriod.Name = "lblBeforeWeekdayPeriod";
            this.lblBeforeWeekdayPeriod.Size = new System.Drawing.Size(104, 26);
            this.lblBeforeWeekdayPeriod.TabIndex = 41;
            this.lblBeforeWeekdayPeriod.Text = "星期一 第1節";
            // 
            // lblBeforeTeacher
            // 
            this.lblBeforeTeacher.AutoSize = true;
            this.lblBeforeTeacher.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblBeforeTeacher.BackgroundStyle.Class = "";
            this.lblBeforeTeacher.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBeforeTeacher.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBeforeTeacher.Location = new System.Drawing.Point(30, 10);
            this.lblBeforeTeacher.Name = "lblBeforeTeacher";
            this.lblBeforeTeacher.Size = new System.Drawing.Size(94, 26);
            this.lblBeforeTeacher.TabIndex = 46;
            this.lblBeforeTeacher.Text = "張佳煜 老師";
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
            this.lblAfterTeacher.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAfterTeacher.Location = new System.Drawing.Point(251, 10);
            this.lblAfterTeacher.Name = "lblAfterTeacher";
            this.lblAfterTeacher.Size = new System.Drawing.Size(94, 26);
            this.lblAfterTeacher.TabIndex = 48;
            this.lblAfterTeacher.Text = "尤弘志 老師";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.lblAfterCourseName);
            this.groupPanel2.Controls.Add(this.lblAfterClassroom);
            this.groupPanel2.Controls.Add(this.lblAfterWeekdayPeriod);
            this.groupPanel2.Controls.Add(this.cmbAfterDate);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(235, 26);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(205, 163);
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
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
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
            this.groupPanel2.TabIndex = 47;
            // 
            // lblAfterCourseName
            // 
            this.lblAfterCourseName.AutoSize = true;
            this.lblAfterCourseName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblAfterCourseName.BackgroundStyle.Class = "";
            this.lblAfterCourseName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAfterCourseName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAfterCourseName.Location = new System.Drawing.Point(13, 82);
            this.lblAfterCourseName.Name = "lblAfterCourseName";
            this.lblAfterCourseName.Size = new System.Drawing.Size(94, 26);
            this.lblAfterCourseName.TabIndex = 43;
            this.lblAfterCourseName.Text = "資一甲 英文";
            // 
            // lblAfterClassroom
            // 
            this.lblAfterClassroom.AutoSize = true;
            this.lblAfterClassroom.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblAfterClassroom.BackgroundStyle.Class = "";
            this.lblAfterClassroom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAfterClassroom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAfterClassroom.Location = new System.Drawing.Point(13, 116);
            this.lblAfterClassroom.Name = "lblAfterClassroom";
            this.lblAfterClassroom.Size = new System.Drawing.Size(74, 26);
            this.lblAfterClassroom.TabIndex = 42;
            this.lblAfterClassroom.Text = "電腦教室";
            // 
            // lblAfterWeekdayPeriod
            // 
            this.lblAfterWeekdayPeriod.AutoSize = true;
            this.lblAfterWeekdayPeriod.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblAfterWeekdayPeriod.BackgroundStyle.Class = "";
            this.lblAfterWeekdayPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAfterWeekdayPeriod.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAfterWeekdayPeriod.Location = new System.Drawing.Point(13, 49);
            this.lblAfterWeekdayPeriod.Name = "lblAfterWeekdayPeriod";
            this.lblAfterWeekdayPeriod.Size = new System.Drawing.Size(104, 26);
            this.lblAfterWeekdayPeriod.TabIndex = 41;
            this.lblAfterWeekdayPeriod.Text = "星期一 第1節";
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
            this.labelX2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX2.Location = new System.Drawing.Point(14, 207);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(41, 26);
            this.labelX2.TabIndex = 49;
            this.labelX2.Text = "假別";
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
            this.labelX3.Location = new System.Drawing.Point(12, 296);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(41, 26);
            this.labelX3.TabIndex = 50;
            this.labelX3.Text = "註記";
            // 
            // chkMultiExchagne
            // 
            this.chkMultiExchagne.AutoSize = true;
            this.chkMultiExchagne.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkMultiExchagne.BackgroundStyle.Class = "";
            this.chkMultiExchagne.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkMultiExchagne.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkMultiExchagne.Location = new System.Drawing.Point(23, 248);
            this.chkMultiExchagne.Name = "chkMultiExchagne";
            this.chkMultiExchagne.Size = new System.Drawing.Size(300, 26);
            this.chkMultiExchagne.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkMultiExchagne.TabIndex = 51;
            this.chkMultiExchagne.Text = "多週調課，重覆調課                      週。";
            this.chkMultiExchagne.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // intMultiExchange
            // 
            this.intMultiExchange.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intMultiExchange.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intMultiExchange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intMultiExchange.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intMultiExchange.Enabled = false;
            this.intMultiExchange.Location = new System.Drawing.Point(200, 248);
            this.intMultiExchange.MaxValue = 20;
            this.intMultiExchange.MinValue = 1;
            this.intMultiExchange.Name = "intMultiExchange";
            this.intMultiExchange.ShowUpDown = true;
            this.intMultiExchange.Size = new System.Drawing.Size(62, 25);
            this.intMultiExchange.TabIndex = 52;
            this.intMultiExchange.Value = 1;
            // 
            // chkPrintReport
            // 
            this.chkPrintReport.AutoSize = true;
            this.chkPrintReport.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkPrintReport.BackgroundStyle.Class = "";
            this.chkPrintReport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkPrintReport.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkPrintReport.Location = new System.Drawing.Point(12, 351);
            this.chkPrintReport.Name = "chkPrintReport";
            this.chkPrintReport.Size = new System.Drawing.Size(176, 26);
            this.chkPrintReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkPrintReport.TabIndex = 53;
            this.chkPrintReport.Text = "同時列印調課確認單";
            this.chkPrintReport.Visible = false;
            // 
            // frmExchangeConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 395);
            this.Controls.Add(this.chkPrintReport);
            this.Controls.Add(this.intMultiExchange);
            this.Controls.Add(this.chkMultiExchagne);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lblAfterTeacher);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.lblBeforeTeacher);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.cmbAbsenceName);
            this.Controls.Add(this.chkNoRecord);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmExchangeConfirm";
            this.Text = "";
            this.TitleText = "調課確認";
            this.Load += new System.EventHandler(this.frmExchangeConfirm_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intMultiExchange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtComment;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkNoRecord;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbAbsenceName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbAfterDate;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX lblBeforeDate;
        private DevComponents.DotNetBar.LabelX lblBeforeCourseName;
        private DevComponents.DotNetBar.LabelX lblBeforeClassroom;
        private DevComponents.DotNetBar.LabelX lblBeforeWeekdayPeriod;
        private DevComponents.DotNetBar.LabelX lblBeforeTeacher;
        private DevComponents.DotNetBar.LabelX lblAfterTeacher;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX lblAfterCourseName;
        private DevComponents.DotNetBar.LabelX lblAfterClassroom;
        private DevComponents.DotNetBar.LabelX lblAfterWeekdayPeriod;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkMultiExchagne;
        private DevComponents.Editors.IntegerInput intMultiExchange;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkPrintReport;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbBeforeDate;
    }
}