using System;
using System.Collections.Generic;
using FISCA.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 修改行事曆
    /// </summary>
    public partial class frmUpdateDate : FISCA.Presentation.Controls.BaseForm
    {
        private List<CalendarRecord> records;
        private QueryHelper mQueryHelper = Utility.QueryHelper;

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get { return dteDate.Value; } }

        /// <summary>
        /// 星期
        /// </summary>
        public string Weekday 
        {
            get
            {
                return ""+Utility.GetIntWeekday(cmbWeekday.Text);
            }
        }

        /// <summary>
        /// 建構式，傳入課程行事曆
        /// </summary>
        /// <param name="records"></param>
        public frmUpdateDate(List<CalendarRecord> records)
        {
            InitializeComponent();

            this.records = records;
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUpdateCalendar_Load(object sender, EventArgs e)
        {
            #region 載入可能值
            cmbWeekday.Items.AddRange(Utility.GetChiWeekdayList().ToArray());
            #endregion

            bool IsDateUpdate = false;
            bool IsWeekdayUpdate = false;

            dteDate.ValueChanged += (vsender, ve) =>
            {
                IsDateUpdate = true;

                if (!IsWeekdayUpdate)
                {
                    string ChiWeekday = Utility.GetChiWeekday(dteDate.Value.GetWeekday());

                    cmbWeekday.Text = ChiWeekday;
                }

                IsDateUpdate = false;
            };

            cmbWeekday.TextChanged += (vsender, ve) =>
            {
                IsWeekdayUpdate = true;

                if (!IsDateUpdate)
                {
                    int CurrentWeekday = dteDate.Value.GetWeekday();

                    int SetWeekday = Utility.GetIntWeekday(cmbWeekday.Text);

                    dteDate.Value = dteDate.Value.AddDays(SetWeekday - CurrentWeekday);
                }

                IsWeekdayUpdate = false;
            };

            #region 初始化值
            dteDate.Value = records[0].StartDateTime;
            cmbWeekday.Text = records[0].DisplayWeekday;
            #endregion
        }
    }
}