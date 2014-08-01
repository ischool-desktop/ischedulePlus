using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 批次修改節次
    /// </summary>
    public partial class frmUpdatePeriod : FISCA.Presentation.Controls.BaseForm
    {
        private List<CalendarRecord> records;

        /// <summary>
        /// 節次
        /// </summary>
        public string Period { get { return cmbPeriod.Text; } }

        public frmUpdatePeriod(List<CalendarRecord> records)
        {
            InitializeComponent();

            this.records = records;
        }

        private void frmUpdatePeriod_Load(object sender, EventArgs e)
        {
            cmbPeriod.Text = records[0].Period;

            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["CalendarOption"];

            #region 讀取節次
            string strPeriodList = config["PeriodList"];

            if (!string.IsNullOrWhiteSpace(strPeriodList))
            {
                XElement elmPeriodList = XElement.Load(new StringReader(strPeriodList));

                foreach (XElement elmPeriod in elmPeriodList.Elements("Period"))
                {
                    string strvPeriod = elmPeriod.Value;
                    cmbPeriod.Items.Add(strvPeriod);
                }
            }

            if (cmbPeriod.Items.Count == 0)
                for (int i = 1; i <= 9; i++)
                    cmbPeriod.Items.Add(i);
            #endregion 
        }
    }
}
