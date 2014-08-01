using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ischedulePlus
{
    public partial class frmAbsence : FISCA.Presentation.Controls.BaseForm
    {
        private K12.Data.Configuration.ConfigData cd = null; 


        public frmAbsence()
        {
            InitializeComponent();
        }

        private void frmAbsence_Load(object sender, EventArgs e)
        {
            cd = K12.Data.School.Configuration["調代課假別設定"];

            string AbsenceList = cd["假別設定"];

            if (!string.IsNullOrWhiteSpace(AbsenceList))
            {
                XElement Elm = XElement.Load(new StringReader(AbsenceList));

                foreach (XElement SubElement in Elm.Elements("Absence"))
                {
                    string Absence = SubElement.Value;

                    if (!string.IsNullOrWhiteSpace(Absence))
                        grdAbsence.Rows.Add(Absence);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            XElement elm = new XElement("AbsenceList");

            foreach (DataGridViewRow row in grdAbsence.Rows)
            {
                string CellValue = "" + row.Cells[0].Value;

                if (!string.IsNullOrWhiteSpace(CellValue))
                    elm.Add(new XElement("Absence", CellValue));
            }

            cd["假別設定"] = elm.ToString();
            Task.Factory.StartNew(() => cd.Save());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}