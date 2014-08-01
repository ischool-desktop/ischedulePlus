using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace ischedulePlus
{
    public partial class frmPeriodsSetting : FISCA.Presentation.Controls.BaseForm
    {
        private List<int> mPeriods = new List<int>();

        public frmPeriodsSetting(string vPeriods)
        {
            InitializeComponent();

            string[] Periods = vPeriods.Split(new char[] { ',' });

            for (int i = 0; i < Periods.Length; i++)
                mPeriods.Add(K12.Data.Int.Parse(Periods[i]));
        }

        public string Periods
        {
            get
            {
                List<string> lstPeriods = new List<string>();

                foreach (DataGridViewRow row in grdPeriod.Rows)
                {
                    string CellValue = "" + row.Cells[1].Value;

                    if (CellValue.Equals("True"))
                    {
                        lstPeriods.Add("" + row.Cells[0].Value);
                    }
                }

                string result = string.Join(",", lstPeriods.ToArray());

                if (lstPeriods.Count == 0)
                    return "整天";
                else
                    return result;
            }
        }

        private void frmPeriodsSetting_Load(object sender, EventArgs e)
        {
            //儲存星期節次設定
            List<string> Periods = Utility.GetPeriodList();

            List<int> intPeriods = new List<int>();

            for (int i = 0; i < Periods.Count; i++)
                intPeriods.Add(K12.Data.Int.Parse(Periods[i]));

            intPeriods.ForEach(x=>grdPeriod.Rows.Add(x,mPeriods.Contains(x)));
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in grdPeriod.Rows)
            {
                DataGridViewCheckBoxXCell Cell = Row.Cells[1] as DataGridViewCheckBoxXCell;

                Cell.Value = checkBoxX1.Checked;
            }
        }
    }
}