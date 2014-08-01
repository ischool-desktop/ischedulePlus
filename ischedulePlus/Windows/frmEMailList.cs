using System;
using System.Windows.Forms;

namespace ischedulePlus
{
    /// <summary>
    /// 電子郵件列表
    /// </summary>
    public partial class frmEMailList : FISCA.Presentation.Controls.BaseForm
    {
        private UDTGridViewHelper<EMailList> GridViewHelper = null;

        public frmEMailList()
        {
            InitializeComponent();
        }

        private void frmEMailList_Load(object sender, EventArgs e)
        {
            //寫在 Form_Load 事件中請一定要處理 Exception。
            try
            {
                //指定 Helper 所要管理的 DataGridView 控制項。
                GridViewHelper = new UDTGridViewHelper<EMailList>(dgvMultiValues);

                //設定不允許重複的欄位清單。
                GridViewHelper.SetUniqueFields(new string[] { "EMail"});

                //GridViewHelper.AddBinding(textBoxX1, "Name");

                //呼叫 Helper 載入資料，此方法是同步執行。
                GridViewHelper.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //呼叫儲存資料，並檢查回傳值是否儲存成功。
                if (GridViewHelper.SaveData())
                    Close(); //儲存成功關閉畫面。
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 關閉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}