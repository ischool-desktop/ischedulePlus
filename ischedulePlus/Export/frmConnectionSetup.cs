using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Campus.Configuration;
using FISCA.Presentation;

namespace ischedulePlus
{
    public partial class frmConnectionSetup : FISCA.Presentation.Controls.BaseForm
    {
        public frmConnectionSetup()
        {
            InitializeComponent();
        }

        private void frmConnectionSetup_Load(object sender, EventArgs e)
        {
            //取得目前的ICIS連線設定
            ConfigData cdApp = Campus.Configuration.Config.App["ICIS_Setup"];//學校SQL連線的設定值

            if (!string.IsNullOrEmpty(cdApp["Server"]))
               txtServer.Text = cdApp["Server"];

            if (!string.IsNullOrEmpty(cdApp["Database"]))
                txtDatabase.Text = cdApp["Database"];

            if (!string.IsNullOrEmpty(cdApp["User"]))
                txtUser.Text = cdApp["User"];

            if (!string.IsNullOrEmpty(cdApp["Password"]))
                txtPassword.Text = cdApp["Password"];

            //if (!string.IsNullOrEmpty(cdApp["SqlConnStrRD"]))
            //    tbConnectionStrRD.Text = cdApp["SqlConnStrRD"];
 
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //Provider=SQLOLEDB.1;Password=ischool;Persist Security Info=True;User ID=sa;Initial Catalog=SQL_Ecampus20121016;Data Source=localhost;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False

            //MSDASC.DataLinks mydlg = new MSDASC.DataLinks();
            OleDbConnection ADOcon = new OleDbConnection();

            //Cast the generic object that PromptNew returns to an ADODB._Connection.
            //ADOcon = (ADODB._Connection)mydlg.PromptNew();

            ADOcon.ConnectionString = "Provider=SQLOLEDB;Password=" + txtPassword.Text + ";Persist Security Info=True;User ID=" + txtUser.Text + ";Initial Catalog=" + txtDatabase.Text + ";Data Source="+ txtServer.Text +";Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False";

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
                    }else
                        MessageBox.Show("連線失敗!!");
                }
                catch
                {
                    MessageBox.Show("連線失敗!!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //取得目前的ICIS連線設定
            ConfigData cdApp = Campus.Configuration.Config.App["ICIS_Setup"];//學校SQL連線的設定值

            cdApp["Server"] = txtServer.Text;
            cdApp["Database"] = txtDatabase.Text;
            cdApp["User"] = txtUser.Text;
            cdApp["Password"] = txtPassword.Text;

            //cdApp["SqlConnStr"] = tbConnectionStr.Text;
            cdApp.Save();

            MessageBox.Show("儲存成功!");
        }

        private void btnConnSetupRD_Click(object sender, EventArgs e)
        {
            //MSDASC.DataLinks mydlg = new MSDASC.DataLinks();
            //ADODB._Connection ADOcon;

            ////Cast the generic object that PromptNew returns to an ADODB._Connection.
            //ADOcon = (ADODB._Connection)mydlg.PromptNew();

            //if (ADOcon != null && !string.IsNullOrEmpty(ADOcon.ConnectionString))
            //{
            //    ADOcon.Open("", "", "", 0);

            //    if (ADOcon.State == 1)
            //    {
            //        tbConnectionStrRD.Text = ADOcon.ConnectionString;
            //        MessageBox.Show("連線成功!!");
            //        ADOcon.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("連線失敗!!");

            //    }
            //}
        }

        private void btnSaveRD_Click(object sender, EventArgs e)
        {
            //取得目前的ICIS SCHRD連線設定
            //ConfigData cdApp = Config.App["ICIS_Setup"];//學校SQL連線的設定值

            //cdApp["SqlConnStrRD"] = tbConnectionStrRD.Text;
            //cdApp.Save();

            //MotherForm.SetStatusBarMessage("儲存成功!!");
        }
    }
}
