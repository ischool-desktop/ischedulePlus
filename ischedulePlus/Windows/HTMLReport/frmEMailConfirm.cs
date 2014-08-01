using System;
using Campus.Configuration;

namespace ischedulePlus
{
    /// <summary>
    /// 電子郵件確認
    /// </summary>
    public partial class frmEMailConfirm : FISCA.Presentation.Controls.BaseForm
    {
        /// <summary>
        /// 寄件者電子郵件
        /// </summary>
        public string SenderEMail { get { return this.txtEMail.Text;} }

        /// <summary>
        /// 寄件者密碼
        /// </summary>
        public string SenderPasssword { get { return this.txtPassword.Text; } }

        /// <summary>
        /// 寄件副本
        /// </summary>
        public string MailCC { get { return this.txtEMailCC.Text; } }

        private ConfigData mConfigData = null;

        public frmEMailConfirm()
        {
            InitializeComponent();
        }

        private void frmEMailConfirm_Load(object sender, EventArgs e)
        {
            mConfigData = Campus.Configuration.Config.User["ischedulePlus.EMailOption"];

            txtEMail.Text = mConfigData["EMail"];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mConfigData != null)
            {
                mConfigData["EMail"] = txtEMail.Text;
                mConfigData.SaveAsync();
            }
        }
    }
}