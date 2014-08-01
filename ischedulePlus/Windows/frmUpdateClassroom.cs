using System;
using System.Collections.Generic;
using System.Data;
using FISCA.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 批次修改場地名稱
    /// </summary>
    public partial class frmUpdateClassroom : FISCA.Presentation.Controls.BaseForm
    {
        private List<CalendarRecord> records;
        private QueryHelper mQueryHelper = Utility.QueryHelper;

        /// <summary>
        /// 場地名稱
        /// </summary>
        public string ClassroomName { get { return cmbClassroom.Text; } }

        public frmUpdateClassroom(List<CalendarRecord> records)
        {
            InitializeComponent();

            this.records = records;
        }

        /// <summary>
        /// 載入場地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUpdateClassroom_Load(object sender, EventArgs e)
        {
            cmbClassroom.Text = records[0].ClassroomName;

            DataTable table = mQueryHelper.Select("select name from $scheduler.classroom order by name");

            List<string> ClassroomNames = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                string ClassroomName = row.Field<string>("name");

                if (!ClassroomNames.Contains(ClassroomName))
                    ClassroomNames.Add(ClassroomName);
            }

            cmbClassroom.Items.AddRange(ClassroomNames.ToArray());
        }
    }
}