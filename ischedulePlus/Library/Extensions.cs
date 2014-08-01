using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    public static class Extensions
    {
        private static QueryHelper mQueryHelper = Utility.QueryHelper;
        private static AccessHelper mAccessHelper = Utility.AccessHelper;

        /// <summary>
        /// 轉換為ReportHelper資料結果
        /// </summary>
        /// <param name="HTMLReports"></param>
        /// <returns></returns>
        public static Dictionary<string,List<DataSet>> ToReportHelper(this Dictionary<string, HTMLReport> HTMLReports)
         {
             Dictionary<string, List<DataSet>> result = new Dictionary<string, List<DataSet>>();

             foreach (string Key in HTMLReports.Keys)
             {
                 string ResourceName = HTMLReports[Key].ResourceName;

                 if (!result.ContainsKey(ResourceName))
                     result.Add(ResourceName, new List<DataSet>());

                 result[ResourceName].Add(HTMLReports[Key].ToDataSet());
             }

             return result;
         }

        /// <summary>
        /// 取得日期星期幾
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        //public static int GetWeekday(this DateTime Date)
        //{
        //    int y = Date.Year;
        //    int m = Date.Month;
        //    int d = Date.Day;

        //    if (m == 1) m = 13;

        //    if (m == 2) m = 14;

        //    int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7 + 1;

        //    return week;
        //}

        /// <summary>
        /// 取得日期星期幾
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static int GetWeekday(this DateTime Date)
        {
            switch (Date.DayOfWeek)
            {
                case DayOfWeek.Monday: return 1;
                case DayOfWeek.Tuesday: return 2;
                case DayOfWeek.Wednesday: return 3;
                case DayOfWeek.Thursday: return 4;
                case DayOfWeek.Friday: return 5;
                case DayOfWeek.Saturday: return 6;
                case DayOfWeek.Sunday: return 7;
                default: return 0;
            }
        }


        /// <summary>
        /// 從DataGrid取得行事曆
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <returns></returns>
        public static List<CalendarRecord> GetCalendars(this DataGridViewX DataGrid)
        {
            List<CalendarRecord> Calendars = new List<CalendarRecord>();

            foreach (DataGridViewRow Row in DataGrid.Rows)
            {
                CalendarRecord Calendar = Row.Tag as CalendarRecord;
                if (Calendar != null)
                    Calendars.Add(Calendar);
            }

            return Calendars;
        }

        /// <summary>
        /// 取得日期
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="Time"></param>
        /// <param name="TimeError"></param>
        /// <param name="DefaultHour"></param>
        /// <param name="DefaultMinute"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(
            this DateTimeInput Input,
            string Time,
            string TimeError,
            int DefaultHour,
            int DefaultMinute)
        {
            if (!string.IsNullOrEmpty(TimeError) || string.IsNullOrEmpty(Time))
            {
                DateTime result = new DateTime(
                    Input.Value.Year,
                    Input.Value.Month, 
                    Input.Value.Day,
                    DefaultHour, 
                    DefaultMinute, 0);

                return result;
            }
            else
            {
                string[] times = TimeError.Split(new char[] { ',' });

                DateTime result = new DateTime(
                    Input.Value.Year, 
                    Input.Value.Month, 
                    Input.Value.Day, 
                    int.Parse(times[0]), 
                    int.Parse(times[1]), 0);

                return result;
            } 
        }

        /// <summary>
        /// 取得教師系統編號
        /// </summary>
        /// <param name="cmbTeacher"></param>
        /// <returns></returns>
        public static List<string> GetTeacherNames(this ComboBoxEx cmbTeacher)
        {
            List<string> Result = new List<string>();

            dynamic SelectItem = cmbTeacher.SelectedItem;
            string SelectName = string.Empty;
            if (SelectItem != null)
                SelectName = SelectItem.name;

            if (SelectName.Equals("所有教師"))
                return new List<string>();

            if (!string.IsNullOrEmpty(SelectName))
                Result.Add(SelectName);

            return Result;
        }

        /// <summary>
        /// 取得班級系統編號
        /// </summary>
        /// <param name="cmbClass"></param>
        /// <returns></returns>
        public static List<string> GetClassNames(this ListBox lstClass)
        {
            List<string> Result = new List<string>();

            foreach (dynamic SelectItem in lstClass.SelectedItems)
            {
                string SelectName = string.Empty;
                if (SelectItem != null)
                    SelectName = SelectItem.name;

                if (SelectName.Equals("所有班級"))
                {
                    if (SelectName.Equals("所有班級"))
                        return new List<string>();
                }
                else if (SelectName.Equals("一年級"))
                {
                    foreach (dynamic Item in lstClass.Items)
                        if (Item.gradeyear.Equals("1"))
                        {
                            Result.Add(Item.name);
                        }
                }
                else if (SelectName.Equals("二年級"))
                {
                    foreach (dynamic Item in lstClass.Items)
                        if (Item.gradeyear.Equals("2"))
                        {
                            Result.Add(Item.name);
                        }
                }
                else if (SelectName.Equals("三年級"))
                {
                    foreach (dynamic Item in lstClass.Items)
                        if (Item.gradeyear.Equals("3"))
                        {
                            Result.Add(Item.name);
                        }
                }
                else if (!string.IsNullOrEmpty(SelectName))
                    Result.Add(SelectName);
            }

            return Result;
        }

        /// <summary>
        /// 取得班級系統編號
        /// </summary>
        /// <param name="cmbClass"></param>
        /// <returns></returns>
        public static List<string> GetClassNames(this ComboBoxEx cmbClass)
        {
            List<string> Result = new List<string>();

            dynamic SelectItem = cmbClass.SelectedItem;
            string SelectName = string.Empty;
            if (SelectItem != null)
                SelectName = SelectItem.name;

            if (SelectName.Equals("所有班級"))
            {
                if (SelectName.Equals("所有班級"))
                    return new List<string>();
            }
            else if (SelectName.Equals("一年級"))
            {
                foreach (dynamic Item in cmbClass.Items)
                    if (Item.gradeyear.Equals("1"))
                    {
                        Result.Add(Item.name);
                    }
            }
            else if (SelectName.Equals("二年級"))
            {
                foreach (dynamic Item in cmbClass.Items)
                    if (Item.gradeyear.Equals("2"))
                    {
                        Result.Add(Item.name);
                    } 
            }
            else if (SelectName.Equals("三年級"))
            {
                foreach (dynamic Item in cmbClass.Items)
                    if (Item.gradeyear.Equals("3"))
                    {
                        Result.Add(Item.name);
                    }
            }
            else if (!string.IsNullOrEmpty(SelectName))
                Result.Add(SelectName);

            return Result; 
        }


        /// <summary>
        /// 取得場地名稱列表
        /// </summary>
        /// <param name="cmbClassroom"></param>
        /// <returns></returns>
        public static List<string> GetClassroomNames(this ComboBoxEx cmbClassroom)
        {
            List<string> Result = new List<string>();

            dynamic SelectItem = cmbClassroom.SelectedItem;
            string SelectName = string.Empty;
            if (SelectItem != null)
                SelectName = SelectItem.name;

            if (SelectName.Equals("所有場地"))
                return new List<string>();

            if (!string.IsNullOrEmpty(SelectName))
                Result.Add(SelectName);

            return Result;
        }

        /// <summary>
        /// 將Combox填入場地清單
        /// </summary>
        /// <param name="cmbClassroom"></param>
        public static void FillClassroom(this ComboBoxEx cmbClassroom)
        {
            BackgroundWorker worker = new BackgroundWorker();

            DataTable tblClassroom = new DataTable();

            worker.DoWork += (sender, e) =>
            {
                tblClassroom = mQueryHelper.Select("select distinct $scheduler.course_calendar.classroom_name from $scheduler.course_calendar where $scheduler.course_calendar.classroom_name is not null order by $scheduler.course_calendar.classroom_name");
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                cmbClassroom.Items.Add(new { name = "所有場地" });

                #region 新增場地清單
                foreach (DataRow row in tblClassroom.Rows)
                    cmbClassroom.Items.Add(new
                    {
                        name = row.Field<string>("classroom_name")
                    });
                #endregion 

                cmbClassroom.SelectedIndex = 0;
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 將Combox填入班級清單
        /// </summary>
        /// <param name="ComboxBox"></param>
        public static void FillClass(this ListBox lstClass)
        {
            BackgroundWorker worker = new BackgroundWorker();

            AccessHelper mHelper = Utility.AccessHelper;

            List<ClassEx> Classes = new List<ClassEx>();

            worker.DoWork += (sender, e) =>
            {
                Classes = mHelper.Select<ClassEx>();
                Classes = Classes.SortByCode();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                #region 新增班級清單
                lstClass.Items.Add(new { id = "0", name = "所有班級", gradeyear = "" });
                lstClass.Items.Add(new { id = "-1", name = "一年級", gradeyear = "" });
                lstClass.Items.Add(new { id = "-2", name = "二年級", gradeyear = "" });
                lstClass.Items.Add(new { id = "-3", name = "三年級", gradeyear = "" });

                foreach (ClassEx Class in Classes)
                {
                    lstClass.Items.Add(new
                    {
                        name = Class.ClassName,
                        gradeyear = K12.Data.Int.GetString(Class.GradeYear)
                    });
                }
                #endregion

                lstClass.SelectedIndex = 0;
            };

            worker.RunWorkerAsync();
        }


        /// <summary>
        /// 將Combox填入班級清單
        /// </summary>
        /// <param name="ComboxBox"></param>
        public static void FillClass(this ComboBoxEx cmbClass)
        {
            BackgroundWorker worker = new BackgroundWorker();

            List<ClassEx> Classes = new List<ClassEx>();

            worker.DoWork += (sender, e) =>
            {
                Classes = mAccessHelper.Select<ClassEx>();
                Classes = Classes.SortByCode();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                #region 新增班級清單
                cmbClass.Items.Add(new { id = "0", name = "所有班級", gradeyear = "" });
                cmbClass.Items.Add(new { id = "-1", name = "一年級", gradeyear = "" });
                cmbClass.Items.Add(new { id = "-2", name = "二年級", gradeyear = "" });
                cmbClass.Items.Add(new { id = "-3", name = "三年級", gradeyear = "" });

                foreach (ClassEx Class in Classes)
                {
                    cmbClass.Items.Add(new
                    {
                        name = Class.ClassName,
                        gradeyear = K12.Data.Int.GetString(Class.GradeYear)
                    });
                }
                #endregion

                cmbClass.SelectedIndex = 0;
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 將ComboxBox填入教師清單
        /// </summary>
        /// <param name="cmbTeacher"></param>
        public static void FillTeacher(this ComboBoxEx cmbTeacher)
        {
            BackgroundWorker worker = new BackgroundWorker();

            List<TeacherEx> Teachers = new List<TeacherEx>();

            worker.DoWork += (sender, e) =>
            {
                Teachers = mAccessHelper.Select<TeacherEx>();
                Teachers = Teachers.SortByCode();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                cmbTeacher.Items.Add(new { name = "所有教師" });

                #region 新增教師清單
                foreach (TeacherEx Teacher in Teachers)
                {
                    cmbTeacher.Items.Add(new
                    {
                        name = Teacher.FullTeacherName
                    }); 
                }
                #endregion

                cmbTeacher.SelectedIndex = 0;
            };

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 檢查節次設定與教師不調代時段是否有交集
        /// </summary>
        /// <param name="vPeriodSetting"></param>
        /// <param name="vTeacherBusy"></param>
        /// <returns></returns>
        public static bool IsIntersect(
            this PeriodSetting vPeriodSetting,
            ClassBusy vClassBusy)
        {
            //將TestTime的年、月、日及秒設為與Appointment一致，以確保只是單純針對小時及分來做時間差的運算
            DateTime BeginTime = new DateTime(1900, 1, 1,
                vPeriodSetting.StartTime.Hour,
                vPeriodSetting.StartTime.Minute, 0);

            DateTime TestTime = new DateTime(1900, 1, 1,
                vClassBusy.StartDateTime.Hour,
                vClassBusy.StartDateTime.Minute, 0);

            //將Appointment的NewBeginTime減去NewTestTime
            int nTimeDif = (int)BeginTime.Subtract(TestTime).TotalMinutes;

            //狀況一：假設nTimeDif為正，並且大於NewTestTime，代表兩者沒有交集，傳回false。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為50。
            if (nTimeDif >= vClassBusy.Duration)
                return false;

            //狀況二：假設nTimeDiff為正，並且小於TestDuration，代表兩者有交集，傳回true。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為80。
            if (nTimeDif >= 0)
                return true;
            //狀況三：假設nTimeDiff為負值，將nTimeDiff成為正值，若是-nTimeDiff小於Appointment.Duration；
            //代表NewBeginTime在NewTestTime之前，並且NewBegin與NewTestTime的絕對差值小於Appointment.Duration的時間
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：30，其Duration為20。
            else if (-nTimeDif < vClassBusy.Duration)
                return true;

            //其他狀況傳回沒有交集
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：50，其Duration為20。
            return false;
        }
        
        /// <summary>
        /// 檢查節次設定與教師不調代時段是否有交集
        /// </summary>
        /// <param name="vPeriodSetting"></param>
        /// <param name="vTeacherBusy"></param>
        /// <returns></returns>
        public static bool IsIntersect(
            this PeriodSetting vPeriodSetting,
            TeacherBusy vTeacherBusy)
        {
            //將TestTime的年、月、日及秒設為與Appointment一致，以確保只是單純針對小時及分來做時間差的運算
            DateTime BeginTime = new DateTime(1900, 1, 1,
                vPeriodSetting.StartTime.Hour,
                vPeriodSetting.StartTime.Minute, 0);

            DateTime TestTime = new DateTime(1900, 1, 1,
                vTeacherBusy.StartDateTime.Hour,
                vTeacherBusy.StartDateTime.Minute, 0);

            //將Appointment的NewBeginTime減去NewTestTime
            int nTimeDif = (int)BeginTime.Subtract(TestTime).TotalMinutes;

            //狀況一：假設nTimeDif為正，並且大於NewTestTime，代表兩者沒有交集，傳回false。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為50。
            if (nTimeDif >= vTeacherBusy.Duration)
                return false;

            //狀況二：假設nTimeDiff為正，並且小於TestDuration，代表兩者有交集，傳回true。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為80。
            if (nTimeDif >= 0)
                return true;
            //狀況三：假設nTimeDiff為負值，將nTimeDiff成為正值，若是-nTimeDiff小於Appointment.Duration；
            //代表NewBeginTime在NewTestTime之前，並且NewBegin與NewTestTime的絕對差值小於Appointment.Duration的時間
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：30，其Duration為20。
            else if (-nTimeDif < vTeacherBusy.Duration)
                return true;

            //其他狀況傳回沒有交集
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：50，其Duration為20。
            return false;            
        }

        /// <summary>
        /// 檢查兩個行事曆之間是否有交集
        /// </summary>
        /// <param name="vCalendar"></param>
        /// <param name="vTestCalenar"></param>
        /// <returns></returns>
        public static bool IsIntersect(this CalendarRecord vCalendar,CalendarRecord vTestCalenar)
        {
            //若星期不相同則不會相衝
            if (!DateTime.Equals(vCalendar.StartDateTime.Date,
                vTestCalenar.StartDateTime.Date))
                return false;

            //將TestTime的年、月、日及秒設為與Appointment一致，以確保只是單純針對小時及分來做時間差的運算
            DateTime BeginTime = new DateTime(1900, 1, 1,
                vCalendar.StartDateTime.Hour,
                vCalendar.StartDateTime.Minute, 0);

            DateTime TestTime = new DateTime(1900, 1, 1,
                vTestCalenar.StartDateTime.Hour,
                vTestCalenar.StartDateTime.Minute, 0);

            //將Appointment的NewBeginTime減去NewTestTime
            int nTimeDif = (int)BeginTime.Subtract(TestTime).TotalMinutes;

            //狀況一：假設nTimeDif為正，並且大於NewTestTime，代表兩者沒有交集，傳回false。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為50。
            if (nTimeDif >= vTestCalenar.Duration)
                return false;

            //狀況二：假設nTimeDiff為正，並且小於TestDuration，代表兩者有交集，傳回true。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為80。
            if (nTimeDif >= 0)
                return true;
            //狀況三：假設nTimeDiff為負值，將nTimeDiff成為正值，若是-nTimeDiff小於Appointment.Duration；
            //代表NewBeginTime在NewTestTime之前，並且NewBegin與NewTestTime的絕對差值小於Appointment.Duration的時間
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：30，其Duration為20。
            else if (-nTimeDif <vTestCalenar.Duration)
                return true;

            //其他狀況傳回沒有交集
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：50，其Duration為20。
            return false;
        }

        /// <summary>
        /// 檢查兩個行事曆之間是否有交集
        /// </summary>
        /// <param name="vCalendar"></param>
        /// <param name="vTestCalenar"></param>
        /// <returns></returns>
        public static bool IsIntersect(this CalendarRecord vCalendar, 
            TeacherBusy vWhoBusy)
        {
            //若星期不相同則不會相衝
            if (!DateTime.Equals(vCalendar.StartDateTime.Date,
                vWhoBusy.StartDateTime.Date))
                return false;

            //將TestTime的年、月、日及秒設為與Appointment一致，以確保只是單純針對小時及分來做時間差的運算
            DateTime BeginTime = new DateTime(1900, 1, 1,
                vCalendar.StartDateTime.Hour,
                vCalendar.StartDateTime.Minute, 0);

            DateTime TestTime = new DateTime(1900, 1, 1,
                vWhoBusy.StartDateTime.Hour,
                vWhoBusy.StartDateTime.Minute, 0);

            //將Appointment的NewBeginTime減去NewTestTime
            int nTimeDif = (int)BeginTime.Subtract(TestTime).TotalMinutes;

            //狀況一：假設nTimeDif為正，並且大於NewTestTime，代表兩者沒有交集，傳回false。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為50。
            if (nTimeDif >= vWhoBusy.Duration)
                return false;

            //狀況二：假設nTimeDiff為正，並且小於TestDuration，代表兩者有交集，傳回true。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為80。
            if (nTimeDif >= 0)
                return true;
            //狀況三：假設nTimeDiff為負值，將nTimeDiff成為正值，若是-nTimeDiff小於Appointment.Duration；
            //代表NewBeginTime在NewTestTime之前，並且NewBegin與NewTestTime的絕對差值小於Appointment.Duration的時間
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：30，其Duration為20。
            else if (-nTimeDif < vWhoBusy.Duration)
                return true;

            //其他狀況傳回沒有交集
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：50，其Duration為20。
            return false;
        }

        /// <summary>
        /// 根據行事曆改變資料列背景顏色
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Calendar"></param>
        public static void FillColor(this DataGridViewRow Row, CalendarRecord Calendar)
        {
            if (Calendar.Cancel == true)
            {
                Row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                foreach (DataGridViewCell Cell in Row.Cells)
                    Cell.ToolTipText = "停課行事曆";                       
            }
            else if (!string.IsNullOrEmpty(Calendar.ExchangeID))
            {
                Row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                foreach (DataGridViewCell Cell in Row.Cells)
                    Cell.ToolTipText = "調課行事曆";
            }
            else if (!string.IsNullOrEmpty(Calendar.ReplaceID))
            {
                Row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                foreach (DataGridViewCell Cell in Row.Cells)
                    Cell.ToolTipText = "代課行事曆";
            }
        }

        /// <summary>
        /// 轉成月日格式輸出
        /// </summary>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public static string ToMonthDay(this DateTime DateTime) 
        {
            return DateTime.ToString("MM/dd");
        }

        /// <summary>
        /// 轉成小時分鐘輸出
        /// </summary>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public static string ToHourMinute(this DateTime DateTime)
        {
            return DateTime.ToString("H:mm");
        }

        /// <summary>
        /// 將日期時間轉為當日的開始
        /// </summary>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public static DateTime ToDayStart(this DateTime DateTime)
        {
            return new DateTime(DateTime.Year,DateTime.Month,DateTime.Day,01,01,01);
        }

        /// <summary>
        /// 將日期時間轉為當日的結束
        /// </summary>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public static DateTime ToDayEnd(this DateTime DateTime)
        {
            return new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 23, 59, 59); 
        }

        /// 建立欄位
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Text"></param>
        /// <param name="Width"></param>
        /// <returns></returns>
        public static DataGridViewColumn CreateColumn(string Name,string Text,int Width,float FontSize)
        {
            DataGridViewColumn Column = new DataGridViewTextBoxColumn();
            Column.Name = Name;
            Column.HeaderText = Text;
            DataGridViewCellStyle Style = new DataGridViewCellStyle();
            Style.Font = new System.Drawing.Font("微軟正黑體",FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            Column.DefaultCellStyle = Style;
            Column.Width = Width;
            Column.MinimumWidth = Width;
            return Column;
        }

        /// <summary>
        /// 將教師列表顯示在畫面上
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <param name="Calendars"></param>
        public static void BindTeacher(this DataGridViewX DataGrid, List<Teacher> Teachers)
        {
            DataGrid.Columns.Clear();

            DataGridViewColumn TeacherNameColumn = Extensions.CreateColumn("TeacherName", "教師名稱", 200, 12F);
            DataGridViewColumn TeacherCodeColumn = Extensions.CreateColumn("TeacherCode", "教師代碼", 100, 12F);
            DataGridViewColumn TeacherCommentColumn = Extensions.CreateColumn("TeacherComment", "教師專長", 300, 12F);

            DataGrid.Columns.Add(TeacherNameColumn);
            DataGrid.Columns.Add(TeacherCodeColumn);
            DataGrid.Columns.Add(TeacherCommentColumn);

            TeacherCodeColumn.Visible = false;

            DataGrid.Rows.Clear();

            foreach (Teacher vTeacher in Teachers)
            {
                int AddRowIndex = DataGrid.Rows.Add();
                DataGridViewRow Row = DataGrid.Rows[AddRowIndex];
                Row.Tag = vTeacher;
                DataGrid.Rows[AddRowIndex].SetValues(
                    vTeacher.Name ,
                    vTeacher.Code, 
                    vTeacher.Comment);
            }
        }

        /// <summary>
        /// 將行事曆記錄顯示在畫面上
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <param name="Calendars"></param>
        public static void BindCalendar(this DataGridViewX DataGrid, List<CalendarRecord> Calendars)
        {
            DataGrid.Columns.Clear();

            DataGridViewColumn colCancel = Extensions.CreateColumn("colCancel", "停課", 20, 9.75F);
            DataGridViewColumn colDate = Extensions.CreateColumn("colExDate", "日期", 85, 9.75F);
            DataGridViewColumn colWeekday = Extensions.CreateColumn("colExWeekday", "星期", 20, 9.75F);
            DataGridViewColumn colPeriod = Extensions.CreateColumn("colExPeriod", "節次", 20, 9.75F);
            DataGridViewColumn colTeacherCode = Extensions.CreateColumn("colTeacherCode", "教師代碼", 60, 9.75F);
            DataGridViewColumn colTeacher = Extensions.CreateColumn("colTeacher", "教師名稱", 60, 9.75F);
            DataGridViewColumn colClassCode = Extensions.CreateColumn("colClassCode", "班級代碼", 60, 9.75F);
            DataGridViewColumn colClass = Extensions.CreateColumn("colExClass", "班級名稱", 60, 9.75F);
            DataGridViewColumn colSubject = Extensions.CreateColumn("colExSubject", "科目名稱", 120, 9.75F);
            DataGridViewColumn colClassroom = Extensions.CreateColumn("colClassroom", "場地名稱", 120, 9.75F);
            DataGridViewColumn colLock = Extensions.CreateColumn("colLock", "鎖定",60,9.75F);
            DataGridViewColumn colComment = Extensions.CreateColumn("colComment", "說明", 60, 9.75F);
            colComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colClassCode.Visible = false;
            colTeacherCode.Visible = false;

            DataGrid.Columns.Add(colCancel);
            DataGrid.Columns.Add(colDate);
            DataGrid.Columns.Add(colWeekday);
            DataGrid.Columns.Add(colPeriod);
            DataGrid.Columns.Add(colTeacherCode);
            DataGrid.Columns.Add(colTeacher);
            DataGrid.Columns.Add(colClassCode);
            DataGrid.Columns.Add(colClass);
            DataGrid.Columns.Add(colSubject);
            DataGrid.Columns.Add(colClassroom);
            DataGrid.Columns.Add(colLock);
            DataGrid.Columns.Add(colComment);

            AccessHelper mHelper = Utility.AccessHelper;

            List<TeacherEx> Teachers = mHelper.Select<TeacherEx>();
            List<ClassEx> Classes = mHelper.Select<ClassEx>();

            Dictionary<string,TeacherEx> TeacherDics = new Dictionary<string,TeacherEx>();

            foreach(TeacherEx Teacher in Teachers)
            {
                if (!TeacherDics.ContainsKey(Teacher.TeacherName))
                    TeacherDics.Add(Teacher.TeacherName,Teacher);
            }

            Dictionary<string, ClassEx> ClassDics = new Dictionary<string, ClassEx>();

            foreach (ClassEx Class in Classes)
            {
                if (!ClassDics.ContainsKey(Class.ClassName))
                    ClassDics.Add(Class.ClassName, Class);
            }

            DataGrid.Rows.Clear();

            //日期 星期 節次 班級 科目 場地
            foreach (CalendarRecord vCalendar in Calendars)
            {
                string TeacherCode = TeacherDics.ContainsKey(vCalendar.TeacherName) ? TeacherDics[vCalendar.TeacherName].TeacherCode : string.Empty;
                string ClassCode = ClassDics.ContainsKey(vCalendar.ClassName) ? ClassDics[vCalendar.ClassName].ClassCode : string.Empty;

                int AddRowIndex = DataGrid.Rows.Add();
                DataGridViewRow Row = DataGrid.Rows[AddRowIndex];
                Row.Tag = vCalendar;
                Row.FillColor(vCalendar);
                DataGrid.Rows[AddRowIndex].SetValues(
                    vCalendar.Cancel?"是":string.Empty,
                    K12.Data.DateTimeHelper.ToDisplayString(vCalendar.StartDateTime),
                    vCalendar.DisplayWeekday,
                    vCalendar.Period,
                    TeacherCode,
                    vCalendar.TeacherName,
                    ClassCode,
                    vCalendar.ClassName,
                    vCalendar.FullSubject,
                    vCalendar.ClassroomName,
                    vCalendar.Lock,
                    vCalendar.Comment);
            }
        }

        /// <summary>
        /// 將異動記錄顯示在畫面上
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <param name="Calendars"></param>
        public static void BindExchangeCalendar(this DataGridViewX DataGrid, List<CalendarRecord> Calendars)
        {
            DataGrid.Columns.Clear();

            DataGridViewColumn colDelete = Extensions.CreateColumn("colDelete", "取消", 25, 9.75F);
            DataGridViewColumn colType = Extensions.CreateColumn("colType", "調代", 25, 9.75F);
            DataGridViewColumn colDate = Extensions.CreateColumn("colExDate", "日期", 85, 9.75F);
            DataGridViewColumn colWeekday = Extensions.CreateColumn("colExWeekday", "星期", 25, 9.75F);
            DataGridViewColumn colPeriod = Extensions.CreateColumn("colExPeriod", "節次", 20, 9.75F);
            DataGridViewColumn colTeacher = Extensions.CreateColumn("colTeacher", "教師", 60, 9.75F);
            DataGridViewColumn colClass = Extensions.CreateColumn("colExClass", "班級", 60, 9.75F);
            DataGridViewColumn colSubject = Extensions.CreateColumn("colExSubject", "科目", 120, 9.75F);
            DataGridViewColumn colERComment = Extensions.CreateColumn("colERComment", "調代說明", 60, 9.75F);
            DataGridViewColumn colAbsence = Extensions.CreateColumn("colAbsence","假別",60,9.75F);
            DataGridViewColumn colComment = Extensions.CreateColumn("colComment", "註記", 60, 9.75F);
            DataGridViewColumn colClassroom = Extensions.CreateColumn("colExClassroom", "場地", 60, 9.75F);
            colERComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGrid.Columns.Add(colDelete);
            DataGrid.Columns.Add(colType);
            DataGrid.Columns.Add(colDate);
            DataGrid.Columns.Add(colWeekday);
            DataGrid.Columns.Add(colPeriod);
            DataGrid.Columns.Add(colTeacher);
            DataGrid.Columns.Add(colClass);
            DataGrid.Columns.Add(colSubject);
            DataGrid.Columns.Add(colERComment);
            DataGrid.Columns.Add(colAbsence);
            DataGrid.Columns.Add(colComment);
            DataGrid.Columns.Add(colClassroom);
            DataGrid.Rows.Clear();

            //日期 星期 節次 班級 科目 場地
            foreach (CalendarRecord vCalendar in Calendars)
            {
                if (vCalendar.ExchangeCalendar!=null)
                {
                    CalendarRecord vExCalendar = vCalendar.ExchangeCalendar;

                    string CommentA = vCalendar.TeacherName + "(調課)" +
                                     "星期" + vCalendar.DisplayWeekday +
                                     " 第" + vCalendar.Period + "節 "
                                     + vCalendar.FullSubject;

                    string CommentB = vExCalendar.TeacherName + "(調課)" +
                                     "星期" + vExCalendar.DisplayWeekday +
                                     " 第" + vExCalendar.Period + "節 "
                                     + vExCalendar.FullSubject;

                    int AddRowIndex = DataGrid.Rows.Add();
                    DataGridViewRow Row = DataGrid.Rows[AddRowIndex];
                    Row.Tag = vCalendar;
                    DataGrid.Rows[AddRowIndex].SetValues(
                        vExCalendar.Delete,
                        "調",
                        K12.Data.DateTimeHelper.ToDisplayString(vExCalendar.StartDateTime),
                        vExCalendar.DisplayWeekday,
                        vExCalendar.Period,
                        vExCalendar.TeacherName,
                        vExCalendar.ClassName,
                        vExCalendar.FullSubject,
                        CommentA,
                        vCalendar.AbsenceName,
                        vCalendar.Comment ,
                        vCalendar.ClassroomName);

                    AddRowIndex = DataGrid.Rows.Add();

                    Row = DataGrid.Rows[AddRowIndex];
                    Row.Tag = vCalendar;
                    DataGrid.Rows[AddRowIndex].SetValues(
                        vCalendar.Delete,
                        "調",
                        K12.Data.DateTimeHelper.ToDisplayString(vCalendar.StartDateTime),
                        vCalendar.DisplayWeekday,
                        vCalendar.Period,
                        vCalendar.TeacherName,
                        vCalendar.ClassName,
                        vCalendar.FullSubject,
                        CommentB,
                        vCalendar.AbsenceName,
                        vCalendar.Comment,
                        vExCalendar.ClassroomName);
                 }else 
                 {
                    string Comment = vCalendar.TeacherName + "(代課)";

                    int AddRowIndex = DataGrid.Rows.Add();
                    DataGridViewRow Row = DataGrid.Rows[AddRowIndex];
                    Row.Tag = vCalendar;
                    DataGrid.Rows[AddRowIndex].SetValues(
                        vCalendar.Delete,
                        "代",
                        K12.Data.DateTimeHelper.ToDisplayString(vCalendar.StartDateTime),
                        vCalendar.DisplayWeekday,
                        vCalendar.Period,
                        vCalendar.AbsTeacherName,
                        vCalendar.ClassName,
                        vCalendar.FullSubject,
                        Comment,
                        vCalendar.AbsenceName,
                        vCalendar.Comment,
                        vCalendar.ClassroomName);
                 }
            }

            DataGrid.Sort(colDate, ListSortDirection.Ascending);
        }

        /// <summary>
        /// 將請假記錄顯示在畫面上
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <param name="Calendars"></param>
        public static void BindAbsenceCalendar(this DataGridViewX DataGrid, List<CalendarRecord> Calendars)
        {
            DataGrid.Columns.Clear();

            DataGridViewColumn colType = Extensions.CreateColumn("colType", "調代", 25, 9.75F);
            DataGridViewColumn colDate = Extensions.CreateColumn("colExDate", "日期", 85, 9.75F);
            DataGridViewColumn colWeekday = Extensions.CreateColumn("colExWeekday", "星期", 25, 9.75F);
            DataGridViewColumn colPeriod = Extensions.CreateColumn("colExPeriod", "節次", 20, 9.75F);
            DataGridViewColumn colTeacher = Extensions.CreateColumn("colTeacher", "教師", 60, 9.75F);
            DataGridViewColumn colClass = Extensions.CreateColumn("colExClass", "班級", 60, 9.75F);
            DataGridViewColumn colSubject = Extensions.CreateColumn("colExSubject", "科目", 120, 9.75F);
            DataGridViewColumn colERComment = Extensions.CreateColumn("colComment", "調代說明", 60, 9.75F);
            DataGridViewColumn colAbsence = Extensions.CreateColumn("colAbsence", "假別", 60, 9.75F);
            DataGridViewColumn colComment = Extensions.CreateColumn("colComment", "註記", 60, 9.75F);
            DataGridViewColumn colClassroom = Extensions.CreateColumn("colExClassroom", "場地", 60, 9.75F);
            colERComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGrid.Columns.Add(colType);
            DataGrid.Columns.Add(colDate);
            DataGrid.Columns.Add(colWeekday);
            DataGrid.Columns.Add(colPeriod);
            DataGrid.Columns.Add(colTeacher);
            DataGrid.Columns.Add(colClass);
            DataGrid.Columns.Add(colSubject);
            DataGrid.Columns.Add(colERComment);
            DataGrid.Columns.Add(colAbsence);
            DataGrid.Columns.Add(colComment);
            DataGrid.Columns.Add(colClassroom);

            DataGrid.Rows.Clear();

            //日期 星期 節次 班級 科目 場地
            foreach (CalendarRecord vCalendar in Calendars)
            {
                if (vCalendar.ExchangeCalendar == null)
                {
                    string Comment = vCalendar.TeacherName + "(代課)";

                    int AddRowIndex = DataGrid.Rows.Add();
                    DataGridViewRow Row = DataGrid.Rows[AddRowIndex];
                    Row.Tag = vCalendar;
                    DataGrid.Rows[AddRowIndex].SetValues(
                        "代",
                        K12.Data.DateTimeHelper.ToDisplayString(vCalendar.StartDateTime),
                        vCalendar.DisplayWeekday,
                        vCalendar.Period,
                        vCalendar.AbsTeacherName,
                        vCalendar.ClassName,
                        vCalendar.FullSubject,
                        Comment,
                        vCalendar.AbsenceName,
                        vCalendar.Comment);
                }
            }
        }

        /// <summary>
        /// 判斷是否為合法日期格式
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static Tuple<bool, string> IsValidateTime(this string Time)
        {
            string[] Times = Time.Split(new char[] { ':' });

            if (Times.Length != 2)
                return new Tuple<bool, string>(false, "時間以「:」分隔，例「8:10」。");

            int Hour;

            if (!int.TryParse(Times[0], out Hour))
                return new Tuple<bool, string>(false, "小時須為數字。");

            if (!(Hour >= 0 && Hour <= 23))
                return new Tuple<bool, string>(false, "小時須介於0到23之間。");

            int Minute;

            if (!int.TryParse(Times[1], out Minute))
                return new Tuple<bool, string>(false, "分鐘須為數字。");

            if (!(Minute >= 0 && Minute <= 59))
                return new Tuple<bool, string>(false, "分鐘須介於0到59");

            return new Tuple<bool, string>(true, string.Empty);
        }


        /// <summary>
        /// 取得行事曆集合中的科目集合
        /// </summary>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static Subjects GetCalendarSubjects(this List<CalendarRecord> Calendars)
        {
            Subjects result = new Subjects();

            foreach(CalendarRecord Calendar in Calendars)
            {
                What vWhat = new What(Calendar.Subject,Calendar.Level);
                result.Add(vWhat);
            }

            return result;
        }

        /// <summary>
        /// 取得選取的行事曆物件
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <returns></returns>
        public static List<CalendarRecord> GetSelectedCalendars(this DataGridViewX DataGrid)
        {
            List<CalendarRecord> result = new List<CalendarRecord>();

            #region 將使用者選取的行事曆找出來
            foreach (DataGridViewRow row in DataGrid.SelectedRows)
            {
                if (row.Tag is CalendarRecord)
                {
                    CalendarRecord record = row.Tag as CalendarRecord;
                    result.Add(record);
                }
            }

            result = result
                .OrderBy(x => x.Period)
                .ToList();
            #endregion

            return result;
        }

        /// <summary>
        /// 判斷是否為代課或調課相同類別
        /// </summary>
        /// <param name="SrcRecord"></param>
        /// <param name="DesRecord"></param>
        /// <returns></returns>
        private static bool IsSameType(CalendarRecord SrcRecord,CalendarRecord DesRecord)
        {
            if (!string.IsNullOrWhiteSpace(SrcRecord.ExchangeID))
            {
                if (!string.IsNullOrWhiteSpace(DesRecord.ExchangeID))
                    return SrcRecord.Delete.Equals(DesRecord.Delete);
                else
                    return false;
            } else if (!string.IsNullOrWhiteSpace(SrcRecord.ReplaceID))
            {
                if (!string.IsNullOrWhiteSpace(DesRecord.ReplaceID))
                    return SrcRecord.Delete.Equals(DesRecord.Delete);
                else
                    return false;
            }

            return false;
        }

        /// <summary>
        /// 取得選取的行事曆物件
        /// </summary>
        /// <param name="DataGrid"></param>
        /// <returns></returns>
        public static Dictionary<string,List<CalendarRecord>> GetSelectedGroupCalendars(
            this DataGridViewX DataGrid
            ,List<CalendarRecord> QueryResult)
        {
            Dictionary<string, List<CalendarRecord>> result = new Dictionary<string, List<CalendarRecord>>();

            //鍵值：相同日期、科目、教師

            #region 將使用者選取的行事曆找出來
            foreach (DataGridViewRow row in DataGrid.SelectedRows)
            {
                if (row.Tag is CalendarRecord)
                {
                    CalendarRecord record = row.Tag as CalendarRecord;

                    string Key = 
                        record.StartDateTime.ToShortDateString() + "-" + 
                        record.FullSubject + "-" + 
                        record.TeacherName;

                    if (!result.ContainsKey(Key))
                    {
                        result.Add(Key, new List<CalendarRecord>());
                        result[Key].Add(record);

                        int vPeriod = K12.Data.Int.Parse(record.Period);

                        #region 往上尋找（較少的節次）
                        for (int i = 1; i< int.MaxValue; i++)
                        {
                            CalendarRecord vRecord = QueryResult.Find(x =>
                                x.Date.Equals(record.Date) &&
                                x.FullSubject.Equals(record.FullSubject) &&
                                x.TeacherName.Equals(record.TeacherName) &&
                                x.Period.Equals(""+(vPeriod-i)));

                            if ((vRecord != null) && 
                                (IsSameType(record,vRecord)))
                                result[Key].Add(vRecord);
                            else
                                break;
                        }
                        #endregion 

                        #region 往下尋找（較多的節次）
                        for (int i = 1; i < int.MaxValue; i++)
                        {
                            CalendarRecord vRecord = QueryResult.Find(x =>
                                x.Date.Equals(record.Date) &&
                                x.FullSubject.Equals(record.FullSubject) &&
                                x.TeacherName.Equals(record.TeacherName) &&
                                x.Period.Equals("" + (vPeriod + i)));

                            if ((vRecord != null) && IsSameType(record, vRecord))
                               result[Key].Add(vRecord);
                            else
                               break;
                        }
                        #endregion

                        result[Key] = result[Key]
                            .OrderBy(x => x.Period)
                            .ToList();
                    }
                }
            }
            #endregion

            return result;
        }


        /// <summary>
        /// 將行事曆物件轉為顯示行事曆物件
        /// </summary>
        /// <param name="records"></param>
        /// <param name="DisplayFields"></param>
        /// <returns></returns>
        public static SortedDictionary<int,DisplayCalendarRecord> ToDisplay(this List<CalendarRecord> records,List<string> DisplayFields,int MaxPeriod)
        {
            SortedDictionary<int, DisplayCalendarRecord> Result = new SortedDictionary<int, DisplayCalendarRecord>();

            for (int i = 1; i <= MaxPeriod; i++)
            {
                if (!Result.ContainsKey(i))
                {
                    DisplayCalendarRecord vDisplay = new DisplayCalendarRecord();
                    vDisplay.PeriodNo = i;
                    Result.Add(i, vDisplay);
                }
            }

            foreach (CalendarRecord record in records)
            {
                if (!Result.ContainsKey(K12.Data.Int.Parse(record.Period)))
                {
                    DisplayCalendarRecord vDisplay = new DisplayCalendarRecord();
                    vDisplay.PeriodNo = K12.Data.Int.Parse(record.Period);
                    Result.Add(K12.Data.Int.Parse(record.Period), vDisplay);
                }

                string Text = string.Empty;

                if (DisplayFields.Contains("Subject"))
                    Text += record.Subject + System.Environment.NewLine;

                if (DisplayFields.Contains("Teacher"))
                    Text += record.TeacherName + System.Environment.NewLine;

                if (DisplayFields.Contains("Class"))
                    Text += record.ClassName + System.Environment.NewLine;

                if (DisplayFields.Contains("Classroom"))
                    Text += record.ClassroomName + System.Environment.NewLine;

                Result[K12.Data.Int.Parse(record.Period)].SetWeekDayText(K12.Data.Int.Parse(record.Weekday), Text, string.Empty, string.Empty, string.Empty);
            }

            return Result;
        }

        /// <summary>
        /// 教師是否包含指定的科目
        /// </summary>
        /// <param name="vWho"></param>
        /// <param name="vWhat"></param>
        /// <returns></returns>
        public static bool ContainsWhat(this Teacher vWho,What vWhat)
        {
            foreach (What What in vWho.Whats)
            {
                if (What.FullSubject.Equals(vWhat.FullSubject))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 教師是否包含指定科目
        /// </summary>
        /// <param name="vWho"></param>
        /// <param name="vWhat"></param>
        /// <returns></returns>
        public static bool ContainsSubject(this Teacher vWho,What vWhat)
        {
            foreach (What What in vWho.Whats)
            {
                if (What.Subject.Equals(vWhat.Subject))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 將教師依照科目、級別排序
        /// </summary>
        /// <param name="Whos"></param>
        /// <param name="Whats"></param>
        /// <returns></returns>
        public static List<Teacher> Sort(this List<Teacher> Whos,List<What> Whats)
        {
            List<Teacher> vWhos = new List<Teacher>();

            //針對每個科目級別，判斷教師是否有包含相同的科目級別
            foreach (What vWhat in Whats.OrderBy(x=>x.FullSubject))
            {
                List<Teacher> Removes = new List<Teacher>();

                foreach (Teacher vWho in Whos)
                {
                    if (vWho.ContainsWhat(vWhat))
                        Removes.Add(vWho);
                }

                foreach (Teacher vRemove in Removes)
                {
                    Whos.Remove(vRemove);
                    vWhos.Add(vRemove);
                }
            }

            //針對每個科目級別，判斷教師是否有包含相同的科目
            foreach (What vWhat in Whats.OrderBy(x=>x.Subject))
            {
                List<Teacher> Removes = new List<Teacher>();

                foreach (Teacher vWho in Whos)
                {
                    if (vWho.ContainsSubject(vWhat))
                        Removes.Add(vWho);
                }

                foreach (Teacher vRemove in Removes)
                {
                    Whos.Remove(vRemove);
                    vWhos.Add(vRemove);
                }
            }

            //將最後的教師加入到清單中
            foreach (Teacher vWho in Whos.OrderBy(x => x.Name))
                vWhos.Add(vWho);

            return vWhos;
        }

        /// <summary>
        /// 取得完整日期時間字串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetDateTimeString(this DateTime dt)
        {
            string result = dt.ToString("yyyy/MM/dd HH:mm");

            return result;
        }

        /// <summary>
        /// 根據日期找出該週的開始日期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        } 
    }
}