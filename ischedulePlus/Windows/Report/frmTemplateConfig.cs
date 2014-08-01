using System;
using System.IO;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using ischedulePlus.Properties;
using K12.Data.Configuration;

namespace ischedulePlus
{
    /// <summary>
    /// 設定樣板
    /// </summary>
    public partial class frmTemplateConfig : FISCA.Presentation.Controls.BaseForm
    {
        private int _ExchangeUseTemplateNumber = 0;
        private byte[] _ExchangeBuffer = null;
        private string _ExchangeBase64string = null;
        private bool _ExchangeIsUpload = false;

        private int _ReplaceUseTemplateNumber = 0;
        private byte[] _ReplaceBuffer = null;
        private string _ReplaceBase64string = null;
        private bool _ReplaceIsUpload = false;

        /// <summary>
        /// 建構式
        /// </summary>
        public frmTemplateConfig(
            byte[] ExchangeBuffer,
            int ExchagneUseTemplateNumber,
            byte[] ReplaceBuffer,
            int ReplaceUseTemplateNumber)
        {
            InitializeComponent();

            _ExchangeBuffer = ExchangeBuffer;
            _ExchangeBase64string = Convert.ToBase64String(_ExchangeBuffer);
            _ExchangeUseTemplateNumber = ExchagneUseTemplateNumber;

            switch (_ExchangeUseTemplateNumber)
            {
                case 0:
                    chkExchangeDefault.Checked = true;
                    break;
                case 1:
                    chkExchangeCustom.Checked = true;
                    break;
                default:
                    break;
            }

            _ReplaceBuffer = ReplaceBuffer;
            _ReplaceBase64string = Convert.ToBase64String(_ReplaceBuffer);
            _ReplaceUseTemplateNumber = ReplaceUseTemplateNumber;

            switch (_ReplaceUseTemplateNumber)
            {
                case 0:
                    chkReplaceDefault.Checked = true;
                    break;
                case 1:
                    chkReplaceCustom.Checked = true;
                    break;
                default:
                    break;
            }
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
        private void chkExchangeDefault_CheckedChanged(object sender, EventArgs e)
        {
            _ExchangeUseTemplateNumber = 0;
        }

        /// <summary>
        /// 使用自訂範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkExchangeCustom_CheckedChanged(object sender, EventArgs e)
        {
            _ExchangeUseTemplateNumber = 1;
        }

        /// <summary>
        /// 使用預設範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkReplaceDefault_CheckedChanged(object sender, EventArgs e)
        {
            _ReplaceUseTemplateNumber = 0;
        }

        /// <summary>
        /// 使用自訂範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkReplaceCustom_CheckedChanged(object sender, EventArgs e)
        {
            _ReplaceUseTemplateNumber = 1;
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
            sfd.FileName = "調課通知單.xls";
            sfd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DownloadTemplate(sfd, Resources.調課通知單);
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
            sfd.FileName = "自訂調課通知單.xls";
            sfd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DownloadTemplate(sfd, _ExchangeBuffer);
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
            ofd.Title = "上傳自訂調課通知單";
            ofd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UploadTemplate(ofd.FileName, ref _ExchangeIsUpload, ref _ExchangeBase64string);
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
        private void lnkReplaceDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存新檔";
            sfd.FileName = "代課通知單.xls";
            sfd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DownloadTemplate(sfd, Resources.代課通知單);
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
        private void lnkReplaceCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存新檔";
            sfd.FileName = "自訂代課通知單.xls";
            sfd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DownloadTemplate(sfd, _ReplaceBuffer);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 上傳自訂代課通知單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReplaceUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "上傳自訂代課通知單";
            ofd.Filter = "相容於 Excel 2003 檔案 (*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UploadTemplate(ofd.FileName, ref _ReplaceIsUpload, ref _ReplaceBase64string);
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
            #region 儲存調課通知單
            ConfigData configExchagne = K12.Data.School.Configuration["調課通知單"];
            configExchagne["TemplateNumber"] = ""+ _ExchangeUseTemplateNumber;
            if (chkExchangeCustom.Checked)
                configExchagne["CustomizeTemplate"] = _ExchangeBase64string;
            configExchagne.SaveAsync();
            #endregion

            #region 儲存代課通知單
            ConfigData configReplace = K12.Data.School.Configuration["代課通知單"];
            configReplace["TemplateNumber"] = "" + _ReplaceUseTemplateNumber;
            if (chkReplaceCustom.Checked)
                configReplace["CustomizeTemplate"] = _ReplaceBase64string;
            configReplace.SaveAsync();
            #endregion

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
    }
}