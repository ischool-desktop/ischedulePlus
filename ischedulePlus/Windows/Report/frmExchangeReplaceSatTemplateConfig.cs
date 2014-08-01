using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using FISCA.Presentation.Controls;
using ischedulePlus.Properties;
using K12.Data.Configuration;

namespace ischedulePlus
{
    /// <summary>
    /// 設定樣板
    /// </summary>
    public partial class frmExchangeReplaceSatTemplateConfig : FISCA.Presentation.Controls.BaseForm
    {
        private int _useTemplateNumber = 0;
        private byte[] _buffer = null;
        private string _base64string = null;
        private bool _isUpload = false;

        /// <summary>
        /// 建構式
        /// </summary>
        public frmExchangeReplaceSatTemplateConfig()
        {
            InitializeComponent();
        }

        #region private function
        /// <summary>
        /// 下載
        /// </summary>
        /// <param name="sfd"></param>
        /// <param name="fileData"></param>
        private void DownloadTemplate(SaveFileDialog sfd, byte[] fileData)
        {
            if ((fileData == null) || (fileData.Length == 0))
            {
                throw new Exception("檔案不存在，無法檢視。");
            }

            try
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);

                fs.Write(fileData, 0, fileData.Length);
                fs.Close();
                System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch
            {
                throw new Exception("指定路徑無法存取。");
            }
        }

        /// <summary>
        /// 上傳
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uploadIndex"></param>
        /// <param name="uploadData"></param>
        private void UploadTemplate(string fileName, ref bool uploadIndex, ref string uploadData)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);

            byte[] tempBuffer = new byte[fs.Length];
            fs.Read(tempBuffer, 0, tempBuffer.Length);

            MemoryStream ms = new MemoryStream(tempBuffer);

            try
            {
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();

                wb.Open(ms, Aspose.Cells.FileFormatType.Excel2003);
                wb = null;
            }
            catch
            {
                throw new Exception("此範本限用相容於 Excel 2003 檔案。");
            }

            try
            {
                uploadData = Convert.ToBase64String(tempBuffer);
                uploadIndex = true;

                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 使用預設範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            _useTemplateNumber = 0;
        }

        /// <summary>
        /// 使用自訂範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCustom_CheckedChanged(object sender, EventArgs e)
        {
            _useTemplateNumber = 1;
        }

        /// <summary>
        /// 檢視預設範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存新檔";
            sfd.FileName = "請假代課統計表.xls";
            sfd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DownloadTemplate(sfd, Resources.請假代課統計表);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 檢視自訂範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存新檔";
            sfd.FileName = "自訂請假代課統計表.xls";
            sfd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DownloadTemplate(sfd, _buffer);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 上傳自訂範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpload(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "上傳自訂請假代課統計表";
            ofd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UploadTemplate(ofd.FileName, ref _isUpload, ref _base64string);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["請假代課統計表"];

            #region 儲存樣版
            config["TemplateNumber"] = ""+ _useTemplateNumber;

            if (chkCustom.Checked)
                config["CustomizeTemplate"] = _base64string;
            #endregion

            #region 儲存節次設定
            XElement elmConfig = new XElement("PeriodOptions");

            foreach (DataGridViewRow row in grdPeriod.Rows)
            {
                XElement elmPeriod = new XElement("PeriodOption");

                DataGridViewCheckBoxCell cellChecked = row.Cells[0] as DataGridViewCheckBoxCell;

                elmPeriod.SetAttributeValue("Checked", "" + cellChecked.Value);
                elmPeriod.SetAttributeValue("Period", "" + row.Cells[1].Value);
                elmPeriod.SetAttributeValue("Type", "" + row.Cells[2].Value);

                elmConfig.Add(elmPeriod);
            }

            config["PeriodOption"] = elmConfig.ToString();
            #endregion

            config.SaveAsync();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 離開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void frmExchangeReplaceSatTemplateConfig_Load(object sender, EventArgs e)
        {
            //取得設定
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["請假代課統計表"];

            if (config != null)
            {
                #region 取得樣版，及是否使用自訂樣版
                int _useTemplateNumber = 0;
                int.TryParse(config["TemplateNumber"], out _useTemplateNumber);

                string customize = config["CustomizeTemplate"];
                _buffer = Resources.請假代課統計表;

                if (!string.IsNullOrEmpty(customize))
                    _buffer = Convert.FromBase64String(customize);

                _base64string = Convert.ToBase64String(_buffer);

                switch (_useTemplateNumber)
                {
                    case 0:
                        chkDefault.Checked = true;
                        break;
                    case 1:
                        chkCustom.Checked = true;
                        break;
                    default:
                        break;
                }
                #endregion

                #region 取得節次設定
                List<string> PeriodList = Calendar.Instance.GetPeriodList();

                SortedDictionary<string, PeriodOption> PeriodOptions = new SortedDictionary<string, PeriodOption>();

                string PeriodOption = config["PeriodOption"];

                if (!string.IsNullOrWhiteSpace(PeriodOption))
                {
                    XElement Element = XElement.Load(new StringReader(PeriodOption));

                    foreach (XElement elmPeriodOption in Element.Elements("PeriodOption"))
                    {
                        PeriodOption vPeriodOption = new PeriodOption(elmPeriodOption);

                        PeriodOptions.Add(vPeriodOption.Period, vPeriodOption);
                    }
                }

                foreach (string Period in PeriodList)
                {
                    if (!PeriodOptions.ContainsKey(Period))
                    {
                        PeriodOption Option = new PeriodOption();
                        Option.Checked = false;
                        Option.Period = Period;
                        Option.Type = "一般";
                        PeriodOptions.Add(Option.Period, Option);
                    }
                }

                foreach (PeriodOption vPeriodOption in PeriodOptions.Values)
                {
                    int RowIndex = grdPeriod.Rows.Add();

                    grdPeriod.Rows[RowIndex].SetValues(vPeriodOption.Checked, vPeriodOption.Period, vPeriodOption.Type);
                }
                #endregion
            }
        }
    }
}