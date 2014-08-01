using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Campus.Configuration;

namespace ischedulePlus
{
    public partial class frmFoxproConnectionSetup : FISCA.Presentation.Controls.BaseForm
    {
        public frmFoxproConnectionSetup()
        {
            InitializeComponent();
        }

        private void frmFoxproConnectionSetup_Load(object sender, EventArgs e)
        {
            ConfigData cdApp = Campus.Configuration.Config.App["Foxpro_Setup"];//學校SQL連線的設定值

            if (!string.IsNullOrEmpty(cdApp["Directory"]))
                txtDirectory.Text = cdApp["Directory"];
        }

        private void btnConnSetup_Click(object sender, EventArgs e)
        {
            //Provider=SQLOLEDB.1;Password=ischool;Persist Security Info=True;User ID=sa;Initial Catalog=SQL_Ecampus20121016;Data Source=localhost;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False

            //MSDASC.DataLinks mydlg = new MSDASC.DataLinks();
            OleDbConnection ADOcon = new OleDbConnection();

            //Cast the generic object that PromptNew returns to an ADODB._Connection.
            //ADOcon = (ADODB._Connection)mydlg.PromptNew();

            ADOcon.ConnectionString = "Provider=vfpoledb;Data Source=" + txtDirectory.Text + ";Collating Sequence=machine;";

            //ADOcon.ConnectionString = "Provider=vfpoledb;Data Source=C:\\Users\\ChangKH\\Desktop\\新民排課資料庫\\tea_pk.dbf;Collating Sequence=machine;";

            if (ADOcon != null && !string.IsNullOrEmpty(ADOcon.ConnectionString))
            {
                try
                {
                    ADOcon.Open();

                    if (ADOcon.State == ConnectionState.Open)
                    {
                        //tbConnectionStr.Text = ADOcon.ConnectionString;
                        MessageBox.Show("連線成功!!");
                        ADOcon.Close();
                    }
                    else
                        MessageBox.Show("連線失敗!!");
                }
                catch
                {
                    MessageBox.Show("連線失敗!!");
                }
            }
        }

        /// <summary>
        /// 儲存連線設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //取得目前的ICIS連線設定
            ConfigData cdApp = Campus.Configuration.Config.App["Foxpro_Setup"];//學校SQL連線的設定值

            cdApp["Directory"] = txtDirectory.Text;

            cdApp.Save();

            MessageBox.Show("儲存成功!");
        }
    }
}