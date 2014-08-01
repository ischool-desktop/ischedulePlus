using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using K12.Data.Configuration;

namespace ischedulePlus
{
    public partial class frmCalendarOption : FISCA.Presentation.Controls.BaseForm
    {
        private string mWeekday;
        private string mPeriods;
        private CalendarOption mOption;

        public frmCalendarOption(CalendarOption Option)
        {
            InitializeComponent();

            mOption = Option;
            chkTeacher.Checked = Option.IsTeacher;
            chkClass.Checked = Option.IsClass;
            chkClassroom.Checked = Option.IsClassroom;
            chkSubject.Checked = Option.IsSubject;
            chkSubjectAlias.Checked = Option.IsSubjectAlias;
        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(errorProvider1.GetError(txtPeriod)))
            {
                MessageBox.Show("節次格式有誤，請調整後再設定！");
                return;
            }

            foreach (DataGridViewRow Row in grdPeriod.Rows)
            {
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    if (!string.IsNullOrWhiteSpace(Cell.ErrorText))
                    {
                        MessageBox.Show("節次設定有誤，請調整後再決定！");

                        return;
                    }
                }
            }

            //儲存顯示設定
            mOption.IsTeacher = chkTeacher.Checked;
            mOption.IsClass = chkClass.Checked;
            mOption.IsClassroom = chkClassroom.Checked;
            mOption.IsSubject = chkSubject.Checked;
            mOption.IsSubjectAlias = chkSubjectAlias.Checked;
            mOption.Save();

            //儲存星期節次設定
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.App["CalendarOption"];

            mWeekday = "" + intWeekday.Value;
            mPeriods = txtPeriod.Text;

            XElement elmPeriodList = new XElement("PeriodList");

            List<PeriodSetting> Periods = new List<PeriodSetting>();

            foreach (DataGridViewRow row in grdPeriod.Rows)
            {
                string strPeriod = "" + row.Cells[colPeriod.Index].Value;
                string strStartTime = ""+row.Cells[colStartTime.Index].Value;
                string strEndTime = "" + row.Cells[colEndTime.Index].Value;

                if (!string.IsNullOrWhiteSpace(strPeriod) &&
                   !string.IsNullOrWhiteSpace(strStartTime) &&
                   !string.IsNullOrWhiteSpace(strEndTime))
                {
                    XElement elmPeriod = new XElement("Period");
                    elmPeriod.Value = strPeriod;
                    elmPeriod.SetAttributeValue("StartTime", strStartTime);
                    elmPeriod.SetAttributeValue("EndTime", strEndTime);
                    elmPeriodList.Add(elmPeriod);

                    Periods.Add(new PeriodSetting(elmPeriod));
                }
            }

            config["Weekday"] = mWeekday;
            config["PeriodList"] = elmPeriodList.ToString();
            config["Period"] = mPeriods;

            this.Close();

            config.SaveAsync();

            CalendarEvents.RaiseWeekdayPeriodChangeEvent(K12.Data.Int.Parse(mWeekday),Periods);              
        }

        private void frmCalendarOption_Load(object sender, EventArgs e)
        {
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.App["CalendarOption"];

            #region 設定星期
            string strWeekday = config["Weekday"];
            //若還沒有設定，預設為週一到週五
            if (string.IsNullOrWhiteSpace(strWeekday))
                mWeekday = "5";
            else
                mWeekday = strWeekday;

            intWeekday.Value = K12.Data.Int.Parse(mWeekday);
            #endregion

            #region 設定節次（三欄式）
            string strPeriodList = config["PeriodList"];

            if (!string.IsNullOrWhiteSpace(strPeriodList))
            {
                XElement elmPeriodList = XElement.Load(new StringReader(strPeriodList));

                grdPeriod.Rows.Clear();

                foreach (XElement elmPeriod in elmPeriodList.Elements("Period"))
                {
                    string strvPeriod = elmPeriod.Value;
                    string strStartTime = elmPeriod.AttributeText("StartTime");
                    string strEndTime = elmPeriod.AttributeText("EndTime");

                    if (!string.IsNullOrWhiteSpace(strvPeriod) &&
                       !string.IsNullOrWhiteSpace(strStartTime) &&
                       !string.IsNullOrWhiteSpace(strEndTime))
                    {
                        int RowIndex = grdPeriod.Rows.Add();
                        grdPeriod.Rows[RowIndex].SetValues(strvPeriod,strStartTime,strEndTime);
                    }
                }
            }
            #endregion

            #region 設定節次（簡單列表）
            string strPeriod = config["Period"];

            //若還沒有設定，預設為1到8節
            if (string.IsNullOrWhiteSpace(strPeriod))
                mPeriods = "1,2,3,4,5,6,7,8";
            else
                mPeriods = strPeriod;

            txtPeriod.Text = mPeriods;
            #endregion
        }

        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidatePeriodList(txtPeriod.Text))
                errorProvider1.SetError(txtPeriod, string.Empty);
            else
                errorProvider1.SetError(txtPeriod, "節次格式錯誤！");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdPeriod_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == colStartTime.Index ||
            //    e.ColumnIndex == colEndTime.Index)
            //{
            //    string CellValue = "" + grdPeriod.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            //    Tuple<bool, string> result = Utility.IsValidateTime(""+CellValue);

            //    if (result.Item1)
            //        grdPeriod.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = result.Item2;
            //    else
            //        grdPeriod.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
            //}
        }

        private void grdPeriod_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 檢查時間表所有時段是否有衝突
        /// </summary>
        /// <returns></returns>
        private bool IsTimeTableSecConflict()
        {
            List<Period> Periods = new List<Period>();

            foreach (DataGridViewRow row in grdPeriod.Rows)
            {
                if (row.IsNewRow) continue;

                Period NewPeriod = new Period();

                Tuple<DateTime, int> StorageTime = Utility.GetStorageTime("" + row.Cells[colStartTime.Index].Value, "" + row.Cells[colEndTime.Index].Value);

                NewPeriod.Weekday = 1;
                NewPeriod.Hour = StorageTime.Item1.Hour;
                NewPeriod.Minute = StorageTime.Item1.Minute;
                NewPeriod.Duration = StorageTime.Item2;

                if (Periods.Count > 0)
                    foreach (Period Period in Periods)
                        if (Period.IsTimeIntersectsWith(NewPeriod))
                            return true;

                Periods.Add(NewPeriod);
            }
            return false;
        }

        /// <summary>
        /// 檢查節次是否重覆
        /// </summary>
        /// <returns></returns>
        private bool IsPeriodRepeat()
        {
            List<string> Periods = new List<string>();

            foreach (DataGridViewRow row in grdPeriod.Rows)
            {
                if (row.IsNewRow) continue;

                string CellValue = "" + row.Cells[colPeriod.Index].Value;

                if (Periods.Contains(CellValue))
                    return true;
                else
                    Periods.Add(CellValue);
            }

            return false; 
        }

        private void grdPeriod_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = grdPeriod.CurrentCell;

            #region 檢查合法時間
            if ((e.ColumnIndex == colStartTime.Index) ||
                (e.ColumnIndex == colEndTime.Index))
            {
                

                string strStartTime = "" + grdPeriod[e.ColumnIndex, e.RowIndex].Value;
                string strEndTime = "" + grdPeriod[e.ColumnIndex, e.RowIndex].Value;
                Tuple<bool, string> Result = Utility.IsValidateTime("" + cell.Value);

                if (!Result.Item1)
                    cell.ErrorText = Result.Item2;
                else if (IsTimeTableSecConflict())
                    cell.ErrorText = "不允許開始時間、結束時間有重疊";
                else if (!string.IsNullOrWhiteSpace(strStartTime) && 
                    !string.IsNullOrWhiteSpace(strEndTime))
                {
                    Tuple<DateTime, int> StorageTime = Utility.GetStorageTime("" + grdPeriod[colStartTime.Index, cell.RowIndex].Value, "" + grdPeriod[colEndTime.Index, cell.RowIndex].Value);

                    if (StorageTime.Item2 <= 0)
                    {
                        grdPeriod.Rows[e.RowIndex].Cells[colStartTime.Index].ErrorText = "結束時間要大於開始時間！";
                        grdPeriod.Rows[e.RowIndex].Cells[colEndTime.Index].ErrorText = "結束時間要大於開始時間！";
                    }
                    else
                    {
                        grdPeriod.Rows[e.RowIndex].Cells[colStartTime.Index].ErrorText = string.Empty;
                        grdPeriod.Rows[e.RowIndex].Cells[colEndTime.Index].ErrorText = string.Empty;
                    }
                }
                else
                    cell.ErrorText = string.Empty;
            }
            else if (e.ColumnIndex == colPeriod.Index)
            {
                if (IsPeriodRepeat())
                    cell.ErrorText = "節次重覆！";
                else
                    cell.ErrorText = string.Empty;
            }
            #endregion
        }
    }
}