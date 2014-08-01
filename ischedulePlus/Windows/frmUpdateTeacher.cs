using System;
using System.Collections.Generic;
using System.Data;
using FISCA.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 批次修改教師姓名
    /// </summary>
    public partial class frmUpdateTeacher : FISCA.Presentation.Controls.BaseForm
    {
        private List<CalendarRecord> records;
        private QueryHelper mQueryHelper = Utility.QueryHelper;

        /// <summary>
        /// 教師姓名
        /// </summary>
        public string TeacherName { get { return cmbTeacher.Text; } }

        public frmUpdateTeacher(List<CalendarRecord> records)
        {
            InitializeComponent();

            this.records = records;
        }

        private void frmUpdateTeacher_Load(object sender, EventArgs e)
        {
            cmbTeacher.Text = records[0].TeacherName;

            DataTable table = mQueryHelper.Select("select teacher_name,nickname from $scheduler.teacher_ex order by teacher_code,teacher_name");

            List<string> TeacherNames = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                string TeacherName = row.Field<string>("teacher_name");
                string Nickname = row.Field<string>("nickname");
                string FullTeacherName = string.IsNullOrWhiteSpace(Nickname) ? TeacherName : TeacherName + "(" + Nickname + ")";

                if (!TeacherNames.Contains(TeacherName))
                    TeacherNames.Add(FullTeacherName);
            }

            cmbTeacher.Items.AddRange(TeacherNames.ToArray());
        }
    }
}
