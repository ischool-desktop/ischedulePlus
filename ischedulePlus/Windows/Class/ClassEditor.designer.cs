namespace ischedulePlus
{
    partial class ClassEditor
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuBusy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBusyDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFree = new System.Windows.Forms.ToolStripMenuItem();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.contextMenuStripDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.errGradeYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtClassCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtGradeYear = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblClassroomDesc = new DevComponents.DotNetBar.LabelX();
            this.contextMenuBusy.SuspendLayout();
            this.contextMenuStripDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGradeYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuBusy
            // 
            this.contextMenuBusy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBusy,
            this.menuBusyDesc,
            this.menuFree});
            this.contextMenuBusy.Name = "contextMenuStrip1";
            this.contextMenuBusy.ShowImageMargin = false;
            this.contextMenuBusy.Size = new System.Drawing.Size(186, 70);
            // 
            // menuBusy
            // 
            this.menuBusy.Name = "menuBusy";
            this.menuBusy.Size = new System.Drawing.Size(185, 22);
            this.menuBusy.Text = "設定不排課時段";
            // 
            // menuBusyDesc
            // 
            this.menuBusyDesc.Name = "menuBusyDesc";
            this.menuBusyDesc.Size = new System.Drawing.Size(185, 22);
            this.menuBusyDesc.Text = "設定不排課時段(指定描述)";
            // 
            // menuFree
            // 
            this.menuFree.Name = "menuFree";
            this.menuFree.Size = new System.Drawing.Size(185, 22);
            this.menuFree.Text = "取消設定";
            // 
            // tabItem2
            // 
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "tabItem2";
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "tabItem1";
            // 
            // contextMenuStripDelete
            // 
            this.contextMenuStripDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStripDelete.Name = "contextMenuStrip1";
            this.contextMenuStripDelete.ShowImageMargin = false;
            this.contextMenuStripDelete.Size = new System.Drawing.Size(70, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(69, 22);
            this.toolStripMenuItem2.Text = "刪除";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // errGradeYear
            // 
            this.errGradeYear.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "星期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.ToolTipText = "只能輸入1到7";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "開始時間";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = "結束時間";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "不排課描述";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.HeaderText = "星期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.ToolTipText = "只能輸入1到7";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.HeaderText = "開始時間";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn7.HeaderText = "結束時間";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "不排課描述";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // colSubject
            // 
            this.colSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSubject.HeaderText = "科目";
            this.colSubject.Name = "colSubject";
            // 
            // colLevel
            // 
            this.colLevel.HeaderText = "級別";
            this.colLevel.Name = "colLevel";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.lblName);
            this.panelEx1.Controls.Add(this.txtNote);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.txtClassCode);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtGradeYear);
            this.panelEx1.Controls.Add(this.lblClassroomDesc);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(640, 428);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            // 
            // 
            // 
            this.lblName.BackgroundStyle.Class = "";
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblName.Location = new System.Drawing.Point(13, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 32);
            this.lblName.TabIndex = 29;
            this.lblName.Text = "班級名稱";
            // 
            // txtNote
            // 
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.Location = new System.Drawing.Point(60, 139);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(211, 202);
            this.txtNote.TabIndex = 28;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(14, 139);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(34, 21);
            this.labelX6.TabIndex = 27;
            this.labelX6.Text = "註記";
            // 
            // txtClassCode
            // 
            // 
            // 
            // 
            this.txtClassCode.Border.Class = "TextBoxBorder";
            this.txtClassCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClassCode.Location = new System.Drawing.Point(59, 93);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(107, 25);
            this.txtClassCode.TabIndex = 26;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(14, 92);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(34, 21);
            this.labelX5.TabIndex = 25;
            this.labelX5.Text = "代碼";
            // 
            // txtGradeYear
            // 
            // 
            // 
            // 
            this.txtGradeYear.Border.Class = "TextBoxBorder";
            this.txtGradeYear.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGradeYear.Location = new System.Drawing.Point(59, 50);
            this.txtGradeYear.Name = "txtGradeYear";
            this.txtGradeYear.Size = new System.Drawing.Size(107, 25);
            this.txtGradeYear.TabIndex = 24;
            // 
            // lblClassroomDesc
            // 
            this.lblClassroomDesc.AutoSize = true;
            // 
            // 
            // 
            this.lblClassroomDesc.BackgroundStyle.Class = "";
            this.lblClassroomDesc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblClassroomDesc.Location = new System.Drawing.Point(14, 52);
            this.lblClassroomDesc.Name = "lblClassroomDesc";
            this.lblClassroomDesc.Size = new System.Drawing.Size(34, 21);
            this.lblClassroomDesc.TabIndex = 23;
            this.lblClassroomDesc.Text = "年級";
            // 
            // ClassEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "ClassEditor";
            this.Size = new System.Drawing.Size(640, 428);
            this.contextMenuBusy.ResumeLayout(false);
            this.contextMenuStripDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errGradeYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ErrorProvider errGradeYear;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuBusy;
        private System.Windows.Forms.ToolStripMenuItem menuBusy;
        private System.Windows.Forms.ToolStripMenuItem menuFree;
        private System.Windows.Forms.ToolStripMenuItem menuBusyDesc;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClassCode;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGradeYear;
        private DevComponents.DotNetBar.LabelX lblClassroomDesc;
    }
}
