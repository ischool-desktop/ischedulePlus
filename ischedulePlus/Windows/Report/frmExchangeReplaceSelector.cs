using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ischedulePlus
{
    public partial class frmExchangeReplaceSelector : FISCA.Presentation.Controls.BaseForm
    {

        public bool IsDisplayExchangeHistory { get { return chkDisplayExchangeHistory.Checked; } }

        public bool IsDisplayExchangeOriginal { get { return chkDisplayExchangeBefore.Checked; } }

        public bool IsDisplayDate { get { return chkDisplayDate.Checked; } }

        public bool IsPrintDate { get { return chkPrintToday.Checked; } }

        public List<string> Result
        {
            get
            {
                List<string> vResult = new List<string>();

                foreach (DataGridViewRow row in grdExchangeReplace.Rows)
                {
                    DataGridViewCheckBoxCell Cell = row.Cells[colCheck.Index] as DataGridViewCheckBoxCell;

                    if (("" + Cell.Value).ToLower().Equals("false"))
                        vResult.Add("" + row.Tag);
                }

                return vResult;
            }
        }

        public frmExchangeReplaceSelector(List<string> Resources)
        {
            InitializeComponent();

            foreach (string Resource in Resources)
            {
                string[] Values = Resource.Split(new char[]{','});

                if (Values.Length.Equals(2) 
                    && !string.IsNullOrWhiteSpace(Values[1]))
                {
                    int RowIndex = grdExchangeReplace.Rows.Add();

                    grdExchangeReplace.Rows[RowIndex].SetValues(Values[1], true);

                    grdExchangeReplace.Rows[RowIndex].Tag = Resource;
                }
            }
        }

        private void frmExchangeReplaceSelector_Load(object sender, EventArgs e)
        {
            chkSelectAll.CheckedChanged += (vsender, ve) =>
            {
                foreach (DataGridViewRow row in grdExchangeReplace.Rows)
                {
                    row.Cells[colCheck.Index].Value = ""+chkSelectAll.Checked;
                }
            };

            lblHelp.Click += (vsender, ve) =>
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.AppendLine("「行政留存」若打勾將於教師調代課通知單出現如下：");
                strBuilder.AppendLine("2013/9/23 資二丙");
                strBuilder.AppendLine("國文");
                strBuilder.AppendLine("簡春月");
                strBuilder.AppendLine("原2013/9/27(五)5");
                strBuilder.AppendLine("「行政留存」若未打勾將於教師調代課通知單出現如下：");
                strBuilder.AppendLine("2013/9/23 (一)4");
                strBuilder.AppendLine("資二丙");
                strBuilder.AppendLine("調至>>");
                strBuilder.AppendLine("2013/9/27 (五)6");

                MessageBox.Show(strBuilder.ToString());

            };
        }
    }
}