using System;
using System.Collections.Generic;
using System.Data;
using FISCA.Data;
using FISCA.Presentation.Controls;

namespace ischedulePlus
{
    /// <summary>
    /// 根據名稱產生新記錄的表單
    /// </summary>
    public partial class SchoolYearSemesterCreatorForm : FISCA.Presentation.Controls.BaseForm
    {
        private QueryHelper mHelper = Utility.QueryHelper;
        private string mTypeName = string.Empty;
        private SchoolYearSemesterPackageDataAccess mDataAccess;
        private List<string> mNames;

        /// <summary>
        /// 建構式，傳入NameCreatorForm所需要的資料存取物件
        /// </summary>
        /// <param name="vDataAccess">資料存取物件</param>
        public SchoolYearSemesterCreatorForm(SchoolYearSemesterPackageDataAccess vDataAccess)
        {
            InitializeComponent();

            mDataAccess = vDataAccess;
            mNames = mDataAccess.SelectKeys(); //取得現有名稱列表
            mTypeName = vDataAccess.DisplayName; //取得資料型態名稱

            this.Text = "新增" + mTypeName;

            int SchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);

            for (int i = SchoolYear - 3; i < SchoolYear + 4; i++)
                cmbSchoolYear.Items.Add(i);

            cmbSchoolYear.SelectedIndex = 3;

            cmbSemester.Items.Add("1");
            cmbSemester.Items.Add("2");
            cmbSemester.SelectedItem = K12.Data.School.DefaultSemester;

            dteStart.Value = DateTime.Now;
            dteEnd.Value = DateTime.Now;

            cmbSchoolYear.Focus();
        }

        /// <summary>
        /// 新的名稱
        /// </summary>
        public string NewName 
        {
            get 
            {
                return cmbSchoolYear.SelectedItem + "," + cmbSemester.Text;
            }
        }

        /// <summary>
        /// 要複製的名稱
        /// </summary>
        public string DuplicateName
        { 
            get 
            { 
                //return "" + cmbNames.SelectedItem;
                return string.Empty;
            }
        }

        /// <summary>
        /// 當選擇名稱改變時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //判斷名稱是否重覆
            if (mNames.Contains(NewName))
            {
                //errorNameDuplicate.SetError(cmbSchoolYear, "名稱不可重複。");
                //errorNameDuplicate.SetError(txtNickname, "名稱不可重複。");
            }
            else
                errorNameDuplicate.Clear();
        }

        /// <summary>
        /// 按下關閉按鈕時的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 當按下儲存按鈕時所觸發的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NewName))
            {
                if (string.IsNullOrWhiteSpace(cmbSemester.Text))
                {
                    MsgBox.Show("請輸入學期！");
                    return;
                }

                if (mNames.Contains(NewName))
                {
                    MsgBox.Show("名稱不可重複。");
                    return;
                }

                if (dteEnd.Value <= dteStart.Value)
                {
                    MsgBox.Show("結束日期必須大於開始日期");
                    return;
                }

                try
                {
                    string NewKey = NewName + "," + dteStart.Value.ToShortDateString() + "," + dteEnd.Value.ToShortDateString();

                    mDataAccess.Insert(NewKey ,string.Empty);
                }
                catch(Exception ex)
                {
                    SmartSchool.ErrorReporting.ReportingService.ReportException(ex);
                    MsgBox.Show("新增" + mTypeName + "時發生未預期之錯誤。\n系統已回報此錯誤內容。");
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MsgBox.Show("必需輸入" + mTypeName + "名稱。");
            }
        }

        /// <summary>
        /// 當選擇項目改變時的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TeacherNameCreatorForm_Load(object sender, EventArgs e)
        {

        }
    }
}