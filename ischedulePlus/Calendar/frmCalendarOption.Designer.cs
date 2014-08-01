namespace ischedulePlus
{
    partial class frmCalendarOption
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkSubjectAlias = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSubject = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkClassroom = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkClass = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkTeacher = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSetting = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtPeriod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grdPeriod = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intWeekday = new DevComponents.Editors.IntegerInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intWeekday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chkSubjectAlias);
            this.groupPanel1.Controls.Add(this.chkSubject);
            this.groupPanel1.Controls.Add(this.chkClassroom);
            this.groupPanel1.Controls.Add(this.chkClass);
            this.groupPanel1.Controls.Add(this.chkTeacher);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(363, 106);
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "顯示設定";
            // 
            // chkSubjectAlias
            // 
            this.chkSubjectAlias.AutoSize = true;
            this.chkSubjectAlias.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSubjectAlias.BackgroundStyle.Class = "";
            this.chkSubjectAlias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSubjectAlias.Location = new System.Drawing.Point(102, 48);
            this.chkSubjectAlias.Name = "chkSubjectAlias";
            this.chkSubjectAlias.Size = new System.Drawing.Size(107, 21);
            this.chkSubjectAlias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSubjectAlias.TabIndex = 9;
            this.chkSubjectAlias.Text = "顯示科目簡稱";
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSubject.BackgroundStyle.Class = "";
            this.chkSubject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSubject.Location = new System.Drawing.Point(16, 48);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(80, 21);
            this.chkSubject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSubject.TabIndex = 8;
            this.chkSubject.Text = "顯示科目";
            // 
            // chkClassroom
            // 
            this.chkClassroom.AutoSize = true;
            this.chkClassroom.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkClassroom.BackgroundStyle.Class = "";
            this.chkClassroom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkClassroom.Location = new System.Drawing.Point(207, 12);
            this.chkClassroom.Name = "chkClassroom";
            this.chkClassroom.Size = new System.Drawing.Size(80, 21);
            this.chkClassroom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkClassroom.TabIndex = 7;
            this.chkClassroom.Text = "顯示場地";
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkClass.BackgroundStyle.Class = "";
            this.chkClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkClass.Location = new System.Drawing.Point(102, 12);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(80, 21);
            this.chkClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkClass.TabIndex = 6;
            this.chkClass.Text = "顯示班級";
            // 
            // chkTeacher
            // 
            this.chkTeacher.AutoSize = true;
            this.chkTeacher.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkTeacher.BackgroundStyle.Class = "";
            this.chkTeacher.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkTeacher.Location = new System.Drawing.Point(16, 12);
            this.chkTeacher.Name = "chkTeacher";
            this.chkTeacher.Size = new System.Drawing.Size(80, 21);
            this.chkTeacher.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkTeacher.TabIndex = 5;
            this.chkTeacher.Text = "顯示教師";
            // 
            // btnSetting
            // 
            this.btnSetting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetting.Location = new System.Drawing.Point(219, 537);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(71, 25);
            this.btnSetting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "設定";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(299, 536);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 26);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtPeriod);
            this.groupPanel2.Controls.Add(this.grdPeriod);
            this.groupPanel2.Controls.Add(this.intWeekday);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(12, 133);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(363, 392);
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
            this.groupPanel2.TabIndex = 9;
            this.groupPanel2.Text = "星期節次設定";
            // 
            // txtPeriod
            // 
            // 
            // 
            // 
            this.txtPeriod.Border.Class = "TextBoxBorder";
            this.txtPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPeriod.Location = new System.Drawing.Point(168, 13);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(100, 25);
            this.txtPeriod.TabIndex = 7;
            this.txtPeriod.Visible = false;
            // 
            // grdPeriod
            // 
            this.grdPeriod.BackgroundColor = System.Drawing.Color.White;
            this.grdPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeriod,
            this.colStartTime,
            this.colEndTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPeriod.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdPeriod.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdPeriod.Location = new System.Drawing.Point(22, 57);
            this.grdPeriod.Name = "grdPeriod";
            this.grdPeriod.RowTemplate.Height = 24;
            this.grdPeriod.Size = new System.Drawing.Size(318, 293);
            this.grdPeriod.TabIndex = 6;
            this.grdPeriod.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPeriod_CellEndEdit);
            this.grdPeriod.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdPeriod_CellValidating);
            this.grdPeriod.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPeriod_CellValueChanged);
            // 
            // colPeriod
            // 
            this.colPeriod.HeaderText = "節次";
            this.colPeriod.MinimumWidth = 60;
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.Width = 60;
            // 
            // colStartTime
            // 
            this.colStartTime.HeaderText = "開始時間";
            this.colStartTime.MinimumWidth = 90;
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Width = 90;
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "結束時間";
            this.colEndTime.MinimumWidth = 90;
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Width = 90;
            // 
            // intWeekday
            // 
            // 
            // 
            // 
            this.intWeekday.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intWeekday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intWeekday.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intWeekday.Location = new System.Drawing.Point(65, 13);
            this.intWeekday.MaxValue = 7;
            this.intWeekday.MinValue = 1;
            this.intWeekday.Name = "intWeekday";
            this.intWeekday.ShowUpDown = true;
            this.intWeekday.Size = new System.Drawing.Size(61, 25);
            this.intWeekday.TabIndex = 5;
            this.intWeekday.Value = 5;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "星期";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCalendarOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 573);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.groupPanel1);
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "frmCalendarOption";
            this.Text = "";
            this.TitleText = "行事曆設定";
            this.Load += new System.EventHandler(this.frmCalendarOption_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intWeekday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSubjectAlias;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSubject;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkClassroom;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkClass;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkTeacher;
        private DevComponents.DotNetBar.ButtonX btnSetting;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput intWeekday;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPeriod;
    }
}