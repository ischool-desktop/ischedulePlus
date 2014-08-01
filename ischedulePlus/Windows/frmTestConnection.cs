using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.DSAClient;

namespace ischedulePlus
{
    public partial class frmTestConnection : FISCA.Presentation.Controls.BaseForm
    {
        #region public property
        /// <summary>
        /// DSNS名稱列表
        /// </summary>
        public List<string> DSNSNames
        {
            get
            {
                List<string> Names = new List<string>();

                if (!string.IsNullOrWhiteSpace(cmbFirstSchool.Text))
                    Names.Add(cmbFirstSchool.Text);

                if (!string.IsNullOrWhiteSpace(cmbSecondSchool.Text))
                    Names.Add(cmbSecondSchool.Text);

                return Names;
            }
        }

        /// <summary>
        /// 所有連線資訊
        /// </summary>
        public List<Connection> Connections { get; private set; }

        /// <summary>
        /// 可取得的DSNS
        /// </summary>
        private List<string> AvailDSNSNames;

        private IPreferenceProvider mPreferenceProvider = new CloudPreferenceProvider();
        #endregion

        /// <summary>
        /// 測試連線
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> TestConnections()
        {
            bool IsConnect = true;
            StringBuilder strBuilder = new StringBuilder();
            Connections = new List<Connection>();

            var DuplicateDSNSNames = DSNSNames
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            if (DuplicateDSNSNames.Count() > 0)
            {
                strBuilder.AppendLine("重覆的連線名稱!");
                foreach (string DuplicateDSNSName in DuplicateDSNSNames)
                    strBuilder.AppendLine(DuplicateDSNSName);
                IsConnect = false;
            }
            else if (DSNSNames.Count == 0)
            {
                strBuilder.AppendLine("請設定連線資訊!");
                IsConnect = false;
            }
            else
            {
                DSNSNames.ForEach
                (x =>
                {
                    if (!string.IsNullOrWhiteSpace(x))
                    {
                        Tuple<Connection, string> Connection = ContractService.GetConnection(x);
                        if (!string.IsNullOrWhiteSpace(Connection.Item2))
                        {
                            IsConnect = false;
                            strBuilder.AppendLine(Connection.Item2);
                        }
                        else
                            Connections.Add(Connection.Item1);
                    }
                }
                );
            }

            return new Tuple<bool, string>(IsConnect, strBuilder.ToString());
        }

        public frmTestConnection()
        {
            InitializeComponent();
        }

        private void frmTestConnection_Load(object sender, EventArgs e)
        {
            try
            {
                AvailDSNSNames = ContractService.GetAvailDSNSNames();
            }
            catch (Exception ve)
            {
                FISCA.ErrorBox.Show("取得可連線學校列表錯誤：" + ve.Message, ve);
            }

            InitialAvailDSNSNames();
        }

        /// <summary>
        /// 初始化DSNS
        /// </summary>
        private void InitialAvailDSNSNames()
        {
            AvailDSNSNames.ForEach(x =>
            {
                cmbFirstSchool.Items.Add(x);
                cmbSecondSchool.Items.Add(x);
            });

            List<string> DSNS = mPreferenceProvider.LoadPreference();

            if (DSNS.Count > 0)
                cmbFirstSchool.Text = DSNS[0];

            if (DSNS.Count > 1)
                cmbSecondSchool.Text = DSNS[1];
        }

        public interface IPreferenceProvider
        {
            List<string> LoadPreference();

            void SavePreference(List<string> Names);
        }

        /// <summary>
        /// 雲端偏好
        /// </summary>
        public class CloudPreferenceProvider : IPreferenceProvider
        {
            #region IPreferenceProvider 成員

            /// <summary>
            /// 載入設定
            /// </summary>
            /// <returns></returns>
            public List<string> LoadPreference()
            {
                List<string> DSNS = new List<string>();

                try
                {
                    string Config = ContractService.GetDSNSConfig();
                    DSNS.AddRange(Config.Split(new char[] { ',' }));
                }
                catch (Exception e)
                {
                    FISCA.ErrorBox.Show("載入連線設定錯誤：" + e.Message, e);
                }

                return DSNS;
            }

            /// <summary>
            /// 儲存設定
            /// </summary>
            /// <param name="Names"></param>
            public void SavePreference(List<string> Names)
            {
                try
                {
                    ContractService.SetDSNSConfig("DSNSPlus", string.Join(",", Names.ToArray()));
                }
                catch (Exception e)
                {
                    string DetailError = FISCA.ErrorReport.Generate(e);

                    FISCA.ErrorBox.Show("《儲存連線設定錯誤》" + System.Environment.NewLine + DetailError, e);
                }
            }
            #endregion
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> TestConnectionResult = TestConnections();

            if (TestConnectionResult.Item1)
                MessageBox.Show("測試連線成功!");
            else
                MessageBox.Show(TestConnectionResult.Item2);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> TestResult = TestConnections();

            if (TestResult.Item1)
            {
                List<string> DSNS = new List<string>();

                for (int i = 0; i < Connections.Count; i++)
                    DSNS.Add(Connections[i].AccessPoint.Name);

                mPreferenceProvider.SavePreference(DSNS);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show(TestResult.Item2);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
