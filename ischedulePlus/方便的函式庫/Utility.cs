using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Aspose.Cells;
using Campus.Report;
using DevComponents.DotNetBar;
using FISCA.Data;
using FISCA.LogAgent;
using FISCA.UDT;
using K12.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 常用工具
    /// </summary>
    public static class Utility
    {
        private static AccessHelper mAccessHelper = new AccessHelper();
        private static QueryHelper mQueryHelper = new QueryHelper();

        /// <summary>
        /// 取得QueryHelper
        /// </summary>
        public static QueryHelper QueryHelper
        {
            get
            {
                return mQueryHelper;
            }
        }

        /// <summary>
        /// 取得Access Helper
        /// </summary>
        public static AccessHelper AccessHelper
        {
            get
            {
                return mAccessHelper;
            }
        }

        /// <summary>
        /// 根據日期取得學年度學期
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Tuple<string, string> GetSchoolYearSemester(DateTime Date)
        {
            List<SchoolYearSemesterDate> mSchoolYearSemesterDates = new List<SchoolYearSemesterDate>();
            Dictionary<string, Tuple<DateTime, DateTime>> mSchoolYearSemesterStartEndDates = new Dictionary<string, Tuple<DateTime, DateTime>>();

            mSchoolYearSemesterDates = mAccessHelper.Select<SchoolYearSemesterDate>();
            mSchoolYearSemesterStartEndDates.Clear();

            foreach (SchoolYearSemesterDate vSchoolYearSemester in mSchoolYearSemesterDates)
            {
                string SchoolYearSemester =  vSchoolYearSemester.SchoolYear + "," + vSchoolYearSemester.Semester;

                Tuple<DateTime, DateTime> StartEndDate = vSchoolYearSemester.GetStartEndDate();

                if (!mSchoolYearSemesterStartEndDates.ContainsKey(SchoolYearSemester))
                    mSchoolYearSemesterStartEndDates.Add(SchoolYearSemester, StartEndDate);
            }

            string SchoolYear = K12.Data.School.DefaultSchoolYear;
            string Semester = K12.Data.School.DefaultSemester;

            foreach (string vKey in mSchoolYearSemesterStartEndDates.Keys)
            {
                Tuple<DateTime, DateTime> StartEndDate = mSchoolYearSemesterStartEndDates[vKey];

                if (Date >= StartEndDate.Item1 &&
                    Date <= StartEndDate.Item2)
                {
                    string[] Keys = vKey.Split(new char[] { ',' });

                    if (Keys.Length == 2)
                    {
                        SchoolYear = Keys[0];
                        Semester = Keys[1];
                    }
                }
            }

            return new Tuple<string, string>(SchoolYear, Semester);
        }

        /// <summary>
        /// 根據班級代碼排序
        /// </summary>
        /// <param name="Classes"></param>
        /// <returns></returns>
        public static List<ClassEx> SortByCode(this List<ClassEx> Classes)
        {
            List<ClassEx> result = new List<ClassEx>();

            if (K12.Data.Utility.Utility.IsNullOrEmpty(Classes))
                return result;

            List<ClassEx> HasCodeClasses = Classes
                .FindAll(x => !string.IsNullOrWhiteSpace(x.ClassCode));

            List<ClassEx> NoCodeClasses = Classes
                .FindAll(x => string.IsNullOrWhiteSpace(x.ClassCode));

            HasCodeClasses = HasCodeClasses
                .OrderBy(x => x.ClassCode)
                .ThenBy(x => x.ClassName)
                .ToList();

            result.AddRange(HasCodeClasses);

            result.AddRange(NoCodeClasses.OrderBy(x => x.ClassName));

            return result;
        }

        /// <summary>
        /// 根據教師代碼排序
        /// </summary>
        /// <param name="Teachers"></param>
        /// <returns></returns>
        public static List<Teacher> SortByCode(this List<Teacher> Teachers)
        {
            List<Teacher> result = new List<Teacher>();

            if (K12.Data.Utility.Utility.IsNullOrEmpty(Teachers))
                return result;

            List<Teacher> HasCodeTeachers = Teachers.FindAll(x => !string.IsNullOrWhiteSpace(x.Code));

            List<Teacher> NoCodeTeachers = Teachers.FindAll(x => string.IsNullOrWhiteSpace(x.Code));

            HasCodeTeachers = HasCodeTeachers
                .OrderBy(x => x.Code)
                .ThenBy(x => x.Name)
                .ToList();

            result.AddRange(HasCodeTeachers);

            result.AddRange(NoCodeTeachers.OrderBy(x => x.Name));

            return result;
        }

        /// <summary>
        /// 根據教師代碼排序
        /// </summary>
        /// <param name="Teachers"></param>
        /// <returns></returns>
        public static List<TeacherEx> SortByCode(this List<TeacherEx> Teachers)
        {
            List<TeacherEx> result = new List<TeacherEx>();

            if (K12.Data.Utility.Utility.IsNullOrEmpty(Teachers))
                return result;

            List<TeacherEx> HasCodeTeachers = Teachers.FindAll(x => !string.IsNullOrWhiteSpace(x.TeacherCode));

            List<TeacherEx> NoCodeTeachers = Teachers.FindAll(x => string.IsNullOrWhiteSpace(x.TeacherCode));

            HasCodeTeachers = HasCodeTeachers
                .OrderBy(x => x.TeacherCode)
                .ThenBy(x=> x.TeacherName)
                .ToList();

            result.AddRange(HasCodeTeachers);

            result.AddRange(NoCodeTeachers.OrderBy(x => x.FullTeacherName));

            return result;
        }

        /// <summary>
        /// 更新日期
        /// </summary>
        /// <param name="records"></param>
        public static void UpdateDate(List<CalendarRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return;

            frmUpdateDate UpdateCalendar = new frmUpdateDate(records);

            if (UpdateCalendar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder strBuilder = new StringBuilder();

                string StartDateTime = UpdateCalendar.Date.ToString("yyyy/MM/dd HH:mm:ss");
                string EndDatetime = UpdateCalendar.Date.AddMinutes(records[0].Duration).ToString("yyyy/MM/dd HH:mm:ss");
                string Weekday = UpdateCalendar.Weekday;

                string strCondition = string.Join(",", records.Select(x => x.UID).ToArray());

                strBuilder.Append("update $scheduler.course_calendar set ");
                strBuilder.Append("start_date_time='" + StartDateTime + "',");
                strBuilder.Append("end_date_time='" + EndDatetime + "',");
                strBuilder.Append("weekday=" + Weekday);
                strBuilder.Append(" where uid in (" + strCondition + ")");

                try
                {
                    UpdateHelper update = new UpdateHelper();

                    string strSQL = strBuilder.ToString();

                    update.Execute(strSQL);

                    StringBuilder strUpdateBuilder = new StringBuilder();

                    strUpdateBuilder.AppendLine("以下課程行事曆將日期（星期）改為『" + UpdateCalendar.Date.ToShortDateString() + "(" + Weekday + ")』");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToString()));

                    strUpdateBuilder.AppendLine("原始資料：");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToXml().ToString()));

                    ApplicationLog.Log(Logs.調代課,Logs.修改課程行事曆日期, strUpdateBuilder.ToString());

                    //CalendarEvents.RaiseWeekChangeEvent();
                }
                catch (Exception ve)
                {
                    MessageBox.Show(ve.Message);
                }
            }
        }

        /// <summary>
        /// 更新節次
        /// </summary>
        /// <param name="records"></param>
        public static void UpdatePeriod(List<CalendarRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return;

            frmUpdatePeriod UpdateCalendar = new frmUpdatePeriod(records);

            if (UpdateCalendar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string UpdatePeriod = UpdateCalendar.Period;
                string UpdateStartTime = string.Empty;
                string UpdateEndTime = string.Empty;

                //weekday period teacher_name  
                //2013/03/08 13:10:00 2013/03/08 14:00:00
                #region 取得節次
                Campus.Configuration.ConfigData config = Campus.Configuration.Config.App["CalendarOption"];

                string strPeriodList = config["PeriodList"];

                if (!string.IsNullOrWhiteSpace(strPeriodList))
                {
                    XElement elmPeriodList = XElement.Load(new StringReader(strPeriodList));

                    foreach (XElement elmPeriod in elmPeriodList.Elements("Period"))
                    {
                        string strPeriod = elmPeriod.Value;
                        string strStartTime = elmPeriod.AttributeText("StartTime");
                        string strEndTime = elmPeriod.AttributeText("EndTime");

                        if (!string.IsNullOrWhiteSpace(strPeriod))
                            if (strPeriod.Equals(UpdatePeriod))
                            {
                                UpdateStartTime = strStartTime;
                                UpdateEndTime = strEndTime;
                                break;
                            }
                    }
                }

                //若節次時間為空白，則回傳錯誤
                if (string.IsNullOrWhiteSpace(UpdateStartTime) ||
                   string.IsNullOrWhiteSpace(UpdateEndTime))
                {
                    MessageBox.Show("節次「"+ UpdatePeriod + "」未設定時間，無法進行節次變更！");
                    return;
                }

                Tuple<DateTime,int> result = GetStorageTime(UpdateStartTime,UpdateEndTime);
                DateTime dteStartTime = result.Item1;
                DateTime dteEndTime = result.Item1.AddMinutes(result.Item2);
                #endregion

                StringBuilder strBuilder = new StringBuilder();

                try
                {
                    List<string> Commands = new List<string>();

                    foreach (CalendarRecord record in records)
                    {
                        DateTime NewSartDateTime = new DateTime(
                            record.StartDateTime.Year,record.StartDateTime.Month ,record.StartDateTime.Day,
                            dteStartTime.Hour,dteStartTime.Minute,0);

                        DateTime NewEndDateTime = new DateTime(
                            record.StartDateTime.Year,record.StartDateTime.Month ,record.StartDateTime.Day,
                            dteEndTime.Hour,dteEndTime.Minute,0);

                        string strSQL = "update $scheduler.course_calendar set period=" + UpdatePeriod + ",start_date_time='" + NewSartDateTime.GetDateTimeString() + "',end_date_time='" + NewEndDateTime.GetDateTimeString() + "' where uid=" + record.UID;

                        strBuilder.AppendLine(strSQL);

                        Commands.Add(strSQL);
                    }

                    UpdateHelper update = new UpdateHelper();

                    update.Execute(Commands);

                    StringBuilder strUpdateBuilder = new StringBuilder();

                    strUpdateBuilder.AppendLine("以下課程行事曆將節次改為『" + UpdatePeriod + "』");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToString()));

                    strUpdateBuilder.AppendLine("原始資料：");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToXml().ToString()));

                    ApplicationLog.Log(Logs.調代課, Logs.修改課程行事曆節次, strUpdateBuilder.ToString());

                    //CalendarEvents.RaiseWeekChangeEvent();
                }
                catch (Exception ve)
                {
                    MessageBox.Show("錯誤訊息如下『" + ve.Message + "』" + System.Environment.NewLine + strBuilder.ToString());
                }
            }
        }

        /// <summary>
        /// 更新教師姓名
        /// </summary>
        /// <param name="records"></param>
        public static void UpdateTeacherName(List<CalendarRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return;

            frmUpdateTeacher UpdateCalendar = new frmUpdateTeacher(records);

            if (UpdateCalendar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder strBuilder = new StringBuilder();

                string TeacherName = UpdateCalendar.TeacherName;

                string strCondition = string.Join(",", records.Select(x => x.UID).ToArray());

                strBuilder.Append("update $scheduler.course_calendar set ");
                strBuilder.Append("teacher_name='" + TeacherName + "'");
                strBuilder.Append(" where uid in (" + strCondition + ")");

                try
                {
                    UpdateHelper update = new UpdateHelper();

                    string strSQL = strBuilder.ToString();

                    update.Execute(strSQL);

                    StringBuilder strUpdateBuilder = new StringBuilder();

                    strUpdateBuilder.AppendLine("以下課程行事曆將教師姓名改為『" + TeacherName + "』");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToString()));

                    strUpdateBuilder.AppendLine("原始資料：");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToXml().ToString()));

                    ApplicationLog.Log(Logs.調代課 , Logs.修改課程行事曆教師姓名, strUpdateBuilder.ToString());

                    //CalendarEvents.RaiseWeekChangeEvent();
                }
                catch (Exception ve)
                {
                    MessageBox.Show(ve.Message);
                }
            }
        }
        
        /// <summary>
        /// 更新場地
        /// </summary>
        /// <param name="records"></param>
        public static void UpdateClassroom(List<CalendarRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return;

            frmUpdateClassroom UpdateCalendar = new frmUpdateClassroom(records);

            if (UpdateCalendar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder strBuilder = new StringBuilder();

                string ClassroomName = UpdateCalendar.ClassroomName;

                string strCondition = string.Join(",", records.Select(x => x.UID).ToArray());

                strBuilder.Append("update $scheduler.course_calendar set ");
                strBuilder.Append("classroom_name='" + ClassroomName + "'");
                strBuilder.Append(" where uid in (" + strCondition + ")");

                try
                {
                    UpdateHelper update = new UpdateHelper();

                    string strSQL = strBuilder.ToString();

                    update.Execute(strSQL);

                    StringBuilder strUpdateBuilder = new StringBuilder();

                    strUpdateBuilder.AppendLine("以下課程行事曆將場地名稱改為『" + ClassroomName + "』");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToString()));

                    strUpdateBuilder.AppendLine("原始資料：");

                    records.ForEach(x => strUpdateBuilder.AppendLine(x.ToXml().ToString()));

                    ApplicationLog.Log(Logs.調代課, Logs.修改課程行事曆場地名稱, strUpdateBuilder.ToString());

                    //CalendarEvents.RaiseWeekChangeEvent();
                }
                catch (Exception ve)
                {
                    MessageBox.Show(ve.Message);
                }
            }
        }

        /// <summary>
        /// 刪除行事曆
        /// </summary>
        public static void DeleteCalendar(List<CalendarRecord> records)
        {
            if (!K12.Data.Utility.Utility.IsNullOrEmpty(records))
            {
                StringBuilder strDeleteBuilder = new StringBuilder();

                strDeleteBuilder.AppendLine("您是否要刪除課程行事曆共" + records.Count + "筆（此功能將無法復原）？");
                strDeleteBuilder.AppendLine("提示：必須非代課或調課記錄才可刪除。");

                if (MessageBox.Show(strDeleteBuilder.ToString(), "刪除提醒", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    string strCondition = string.Join(",", records.Select(x => x.UID).ToArray());

                    try
                    {
                        UpdateHelper update = new UpdateHelper();

                        string strSQL = "delete from $scheduler.course_calendar where uid in (" + strCondition + ")";

                        update.Execute(strSQL);

                        StringBuilder strBuilder = new StringBuilder();

                        records.ForEach(x => strBuilder.AppendLine(x.ToString()));

                        strBuilder.AppendLine("原始資料：");

                        records.ForEach(x => strBuilder.AppendLine(x.ToXml().ToString()));

                        ApplicationLog.Log(Logs.調代課,Logs.刪除課程行事曆, strBuilder.ToString());

                        //CalendarEvents.RaiseWeekChangeEvent();
                    }
                    catch (Exception ve)
                    {
                        MessageBox.Show(ve.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 取消行事曆
        /// </summary>
        /// <param name="records"></param>
        public static void LockCalendar(List<CalendarRecord> records,bool Lock)
        {
            try
            {
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(records))
                {
                    StringBuilder strDeleteBuilder = new StringBuilder();

                    strDeleteBuilder.AppendLine("您是否要" + (Lock?"鎖定":"解除鎖定") + "課程行事曆共" + records.Count + "筆？");

                    if (MessageBox.Show(strDeleteBuilder.ToString(), "鎖定提醒", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        Calendar.Instance.Lock(records,Lock);

                        StringBuilder strUpdateBuilder = new StringBuilder();

                        strUpdateBuilder.AppendLine("將以下課程行事曆" + (Lock?"鎖定":"解除鎖定") + "：");

                        records.ForEach(x => strUpdateBuilder.AppendLine(x.ToString()));

                        strUpdateBuilder.AppendLine("原始資料：");

                        records.ForEach(x => strUpdateBuilder.AppendLine(x.ToXml().ToString()));

                        ApplicationLog.Log(Logs.調代課, (Lock ? Logs.鎖定課程行事曆 : Logs.解除鎖定課程行事曆 ), strUpdateBuilder.ToString());

                        //CalendarEvents.RaiseWeekChangeEvent();
                    }
                }
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
            }
        }

        /// <summary>
        /// 取消行事曆
        /// </summary>
        /// <param name="records"></param>
        public static void CancelCalendar(List<CalendarRecord> records)
        {
            try
            {
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(records))
                {
                    StringBuilder strDeleteBuilder = new StringBuilder();

                    strDeleteBuilder.AppendLine("您是否要停用課程行事曆共" + records.Count + "筆？");
                    strDeleteBuilder.AppendLine("提示：");
                    strDeleteBuilder.AppendLine("1.必須非代課或調課記錄才可停用。");
                    strDeleteBuilder.AppendLine("2.停用後可至調代課記錄中查詢行事曆再按右鍵選單啟用。");

                    if (MessageBox.Show(strDeleteBuilder.ToString(), "停用提醒", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {

                        Calendar.Instance.Cancel(records, true);

                        StringBuilder strUpdateBuilder = new StringBuilder();

                        strUpdateBuilder.AppendLine("將以下課程行事曆停用：");

                        records.ForEach(x => strUpdateBuilder.AppendLine(x.ToString()));

                        strUpdateBuilder.AppendLine("原始資料：");

                        records.ForEach(x => strUpdateBuilder.AppendLine(x.ToXml().ToString()));

                        ApplicationLog.Log(Logs.調代課,Logs.停用課程行事曆, strUpdateBuilder.ToString());

                        //CalendarEvents.RaiseWeekChangeEvent();
                    }
                }
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
            }
        }

        /// <summary>
        /// 取得星期
        /// </summary>
        /// <returns></returns>
        public static string GetWeekday()
        {
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.App["CalendarOption"];

            string Weekday = config["Weekday"];

            if (!string.IsNullOrWhiteSpace(Weekday))
                return Weekday;
            else
                return "5";
        }

        /// <summary>
        /// 取得節次列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPeriodList()
        {
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.App["CalendarOption"];

            List<string> Periods = new List<string>();

            #region 設定節次（三欄式）
            string strPeriodList = config["PeriodList"];

            if (!string.IsNullOrWhiteSpace(strPeriodList))
            {
                XElement elmPeriodList = XElement.Load(new StringReader(strPeriodList));

                foreach (XElement elmPeriod in elmPeriodList.Elements("Period"))
                {
                    string strPeriod = elmPeriod.Value;
                    string strStartTime = elmPeriod.AttributeText("StartTime");
                    string strEndTime = elmPeriod.AttributeText("EndTime");

                    if (!string.IsNullOrWhiteSpace(strPeriod))
                        Periods.Add(strPeriod);
                }
            }
            #endregion

            if (Periods.Count == 0)
            {
                Periods.Add("1");
                Periods.Add("2");
                Periods.Add("3");
                Periods.Add("4");
                Periods.Add("5");
                Periods.Add("6");
                Periods.Add("7");
                Periods.Add("8");
            }

            return Periods;
        }

        /// <summary>
        /// 取得假別列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAbsenceList()
        {
            List<string> result = new List<string>();

            K12.Data.Configuration.ConfigData cd = K12.Data.School.Configuration["調代課假別設定"];

            string AbsenceList = cd["假別設定"];

            if (!string.IsNullOrWhiteSpace(AbsenceList))
            {
                XElement Elm = XElement.Load(new StringReader(AbsenceList));

                foreach (XElement SubElement in Elm.Elements("Absence"))
                {
                    string Absence = SubElement.Value;

                    if (!string.IsNullOrWhiteSpace(Absence))
                        result.Add(Absence);
                }
            }

            return result;
        }

        /// <summary>
        /// 判斷是否為合法日期格式
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static Tuple<bool, string> IsValidateTime(string Time)
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
        /// 是否能取消代課
        /// </summary>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static bool CanCancelReplace(this List<CalendarRecord> Calendars)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return false;

            foreach (CalendarRecord Calendar in Calendars)
                if (!string.IsNullOrWhiteSpace(Calendar.ReplaceID))
                    return true;

            return false; 
        }
        
        /// <summary>
        /// 是否能取消調課
        /// </summary>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static bool CanCancelExchange(this List<CalendarRecord> Calendars)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return false;

            foreach (CalendarRecord Calendar in Calendars)
                if (!string.IsNullOrWhiteSpace(Calendar.ExchangeID))
                    return true;

            return false;
        }

        /// <summary>
        /// 是否能查詢代課
        /// </summary>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static bool CanQueryReplace(this List<CalendarRecord> Calendars)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return false;

            //判斷若沒有代課即可進行代課
            foreach (CalendarRecord Calendar in Calendars)
                if (!string.IsNullOrWhiteSpace(Calendar.Status))
                    if (Calendar.Status.Equals("請假") || Calendar.Equals("代課"))
                        return false;

            return true;
        }

        /// <summary>
        /// 取得節次列表
        /// </summary>
        /// <param name="strPeriodList"></param>
        /// <returns></returns>
        public static List<PeriodSetting> GetPeriodList(string strPeriodList)
        {
            //1	8:10	9:00
            //2	9:10	10:00
            //3	10:10	11:00
            //4	11:10	12:00
            //5	13:10	14:00
            //6	14:10	15:00
            //7	15:10	16:00
            //8	16:10	17:00

            List<PeriodSetting> Periods = new List<PeriodSetting>();

            if (!string.IsNullOrWhiteSpace(strPeriodList))
            {
                XElement elmPeriodList = XElement.Load(new StringReader(strPeriodList));

                foreach (XElement elmPeriod in elmPeriodList.Elements("Period"))
                {
                    PeriodSetting Period = new PeriodSetting(elmPeriod);

                    Periods.Add(Period);
                }
            }
            else
            {
                Periods.Add(new PeriodSetting(1, 8,10,50));
                Periods.Add(new PeriodSetting(2, 9, 10, 50));
                Periods.Add(new PeriodSetting(3, 10, 10, 50));
                Periods.Add(new PeriodSetting(4, 11, 10, 50));

                Periods.Add(new PeriodSetting(5, 13, 10, 50));
                Periods.Add(new PeriodSetting(6, 14, 10, 50));
                Periods.Add(new PeriodSetting(7, 15, 10, 50));
                Periods.Add(new PeriodSetting(8, 16, 10, 50));
            }

            return Periods;
        }

        /// <summary>
        /// 取得節次列表
        /// </summary>
        /// <param name="strPeriod"></param>
        /// <returns></returns>
        public static List<int> GetPeriods(string strPeriod)
        {
            string[] Periods = strPeriod.Split(new char[] { ',' });

            List<int> intPeriods = new List<int>();

            for (int i = 0; i < Periods.Length; i++)
                intPeriods.Add(K12.Data.Int.Parse(Periods[i]));

            return intPeriods;
        }

        /// <summary>
        /// 關閉功課表頁籤
        /// </summary>
        /// <param name="vTabControl"></param>
        public static void CloseCalendarView(DevComponents.DotNetBar.TabControl vTabControl)
        {
            List<TabItem> Items = new List<TabItem>();

            for (int i = 1; i < vTabControl.Tabs.Count; i++)
                Items.Add(vTabControl.Tabs[i]);

            Items.ForEach(x => vTabControl.Tabs.Remove(x));

            vTabControl.Tabs[0].AttachedControl.Controls.Clear();
            vTabControl.Tabs[0].AttachedControl.Tag = null;
            vTabControl.Tabs[0].Text = "行事曆";
        }

        /// <summary>
        /// 是否為合法的節次列表
        /// </summary>
        /// <param name="strPeriod"></param>
        /// <returns></returns>
        public static bool IsValidatePeriodList(string strPeriod)
        {
            if (string.IsNullOrWhiteSpace(strPeriod))
                return false;

            string[] strPeriods = strPeriod.Split(new char[] { ',' });
            int intPeriod;

            for (int i = 0; i < strPeriods.Length; i++)
                if (!int.TryParse(strPeriods[i],out intPeriod))
                    return false;

            return true;
        }

        /// <summary>
        /// 解析節次列表
        /// </summary>
        /// <param name="strPeriod"></param>
        /// <returns></returns>
        public static List<int> ParsePeriodList(string strPeriod)
        {
            List<int> Periods = new List<int>();

            string[] strPeriods = strPeriod.Split(new char[] { ',' });

            for (int i = 0; i < strPeriods.Length; i++)
                Periods.Add(K12.Data.Int.Parse(strPeriods[i]));

            return Periods;
        }

        /// <summary>
        /// 取得註解，目前只適用於班級上
        /// </summary>
        /// <param name="AssocType"></param>
        /// <param name="AssocID"></param>
        /// <returns></returns>
        public static string GetAssocNote(CalendarType AssocType,string AssocID)
        {
            if (AssocType.Equals(CalendarType.Class))
            {
                if (!string.IsNullOrEmpty(AssocID))
                {
                    if (Calendar.Instance.Classes.ContainsKey(AssocID))
                        return AssocID + "(" + Calendar.Instance.Classes[AssocID].Note + ")";
                    else
                        return AssocID;
                }
                else
                    return AssocID;
            }
            else
            {
                return AssocID;
            }
        }

        /// <summary>
        /// 取得教師不調代日期
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static List<TeacherBusyDate> GetTeacherBusyDates(string TeacherID,DateTime StartDate,DateTime EndDate)
        {
            AccessHelper mAccessHelper = Utility.AccessHelper;

            List<TeacherBusyDate> BusyDates = new List<TeacherBusyDate>();

            if (!string.IsNullOrWhiteSpace(TeacherID))
            {
                string strBusySQL = "ref_teacher_id=" + TeacherID + " and begin_date_time>=" + SchoolYearSemesterOption.Instance.StartDate.ToShortDateString() + " and end_date_time<=" + SchoolYearSemesterOption.Instance.EndDate.ToShortDateString();

                BusyDates = mAccessHelper.Select<TeacherBusyDate>(strBusySQL);
            }

            return BusyDates;
        }

        /// <summary>
        /// 取得班級行事曆
        /// </summary>
        /// <param name="AssocID"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static List<CalendarRecord> GetClassCalendars(string AssocID, DateTime StartDate, DateTime EndDate)
        {
            AccessHelper mAccessHelper = Utility.AccessHelper;

            List<CourseCalendar> CourseCalendars = mAccessHelper
                .Select<CourseCalendar>("class_name='" + AssocID + "' and cancel=false and start_date_time>=" + StartDate.ToShortDateString() + " and end_date_time<=" + EndDate.ToShortDateString())
                .OrderBy(x => x.StartDateTime).ToList();

            List<CalendarRecord> CalendarRecords = new List<CalendarRecord>();

            foreach (CourseCalendar vCourseCalendar in CourseCalendars)
            {
                if (!vCourseCalendar.Cancel)
                {
                    CalendarRecord vCalendar = new CalendarRecord(vCourseCalendar);

                    if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        vCalendar.Status = "代課";
                    else if (!string.IsNullOrWhiteSpace(vCalendar.ExchangeID))
                        vCalendar.Status = "調課";
                    CalendarRecords.Add(vCalendar);
                }
            }

            return CalendarRecords;
        }

        /// <summary>
        /// 取得場地行事曆
        /// </summary>
        /// <param name="AssocID"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static List<CalendarRecord> GetPlaceCalendars(string AssocID, DateTime StartDate, DateTime EndDate)
        {
            AccessHelper mAccessHelper = Utility.AccessHelper;

            List<CourseCalendar> CourseCalendars = mAccessHelper
                .Select<CourseCalendar>("classroom_name='" + AssocID + "' and cancel=false and start_date_time>=" + StartDate.ToShortDateString() + " and end_date_time<=" + EndDate.ToShortDateString())
                .OrderBy(x => x.StartDateTime).ToList();

            List<CalendarRecord> CalendarRecords = new List<CalendarRecord>();

            foreach (CourseCalendar vCourseCalendar in CourseCalendars)
            {
                if (!vCourseCalendar.Cancel)
                {
                    CalendarRecord vCalendar = new CalendarRecord(vCourseCalendar);

                    if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        vCalendar.Status = "代課";
                    else if (!string.IsNullOrWhiteSpace(vCalendar.ExchangeID))
                        vCalendar.Status = "調課";
                    CalendarRecords.Add(vCalendar);
                }
            }

            return CalendarRecords;
        }

        /// <summary>
        /// 取得教師行事曆
        /// </summary>
        /// <param name="AssocID"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static List<CalendarRecord> GetTeacherCalendars(
            string AssocID,
            DateTime StartDate,
            DateTime EndDate)
        {
            AccessHelper mAccessHelper = Utility.AccessHelper;
            QueryHelper mQueryHelper = Utility.QueryHelper;

            List<CalendarRecord> CalendarRecords = new List<CalendarRecord>();

            //將教師所有課程行事曆找出來
            List<CourseCalendar> CourseCalendars = mAccessHelper
                .Select<CourseCalendar>("teacher_name='" + AssocID + "' and start_date_time>=" + StartDate.ToShortDateString() + " and end_date_time<=" + EndDate.ToShortDateString())
                .OrderBy(x => x.StartDateTime).ToList();

            List<string> ReplaceIDs = new List<string>();
            List<string> AbsenceIDs = new List<string>();

            #region 找出是被代課的系統編號
            if (CourseCalendars.Count > 0)
            {
                string strReplaceSQL = "select replace_id,teacher_name from $scheduler.course_calendar where replace_id in (" + string.Join(",", CourseCalendars.Select(x => x.UID).ToArray()) + ")";

                DataTable table = mQueryHelper.Select(strReplaceSQL);

                foreach (DataRow row in table.Rows)
                {
                    string TeacherID = row.Field<string>("teacher_name");
                    string ReplaceID = row.Field<string>("replace_id");

                    if (!string.IsNullOrWhiteSpace(TeacherID))
                        ReplaceIDs.Add(ReplaceID);
                    else
                        AbsenceIDs.Add(ReplaceID);
                }
            }
            #endregion

            foreach (CourseCalendar vCourseCalendar in CourseCalendars)
            {
                if (!vCourseCalendar.Cancel)
                {
                    CalendarRecord vCalendar = new CalendarRecord(vCourseCalendar);

                    if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        vCalendar.Status = "代課";
                    else if (!string.IsNullOrWhiteSpace(vCalendar.ExchangeID))
                        vCalendar.Status = "調課";
                    CalendarRecords.Add(vCalendar);
                }
                else if (ReplaceIDs.Contains(vCourseCalendar.UID))
                {
                    CalendarRecord vCalendar = new CalendarRecord(vCourseCalendar);
                    vCalendar.Status = "請假";
                    CalendarRecords.Add(vCalendar);
                }
                else if (AbsenceIDs.Contains(vCourseCalendar.UID))
                {
                    CalendarRecord vCalendar = new CalendarRecord(vCourseCalendar);
                    vCalendar.Status = "缺課";
                    CalendarRecords.Add(vCalendar); 
                }
            }

            return CalendarRecords;
        }

        /// <summary>
        /// Export DataGridView Contents
        /// </summary>
        /// <param name="dgv">DataGridView Control</param>
        /// <param name="name">Export Report Name</param>
        internal static void Export(this DataGridView dgv, string name)
        {
            Workbook book = new Workbook();
            book.Worksheets.Clear();
            Worksheet ws = book.Worksheets[book.Worksheets.Add()];
            ws.Name = name;

            int index = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();

            #region 建立標題
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                DataGridViewColumn col = dgv.Columns[i];
                ws.Cells[index, i].PutValue(col.HeaderText);
                map.Add(col.HeaderText, i);
            }
            index++;
            #endregion

            #region 填入內容
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    int column = map[cell.OwningColumn.HeaderText];
                    ws.Cells[index, column].PutValue("" + cell.Value);
                }
                index++;
            }
            #endregion

            book.Worksheets[0].AutoFitColumns();

            ReportSaver.SaveWorkbook(book, name);
        }

        /// <summary>
        /// 檢查兩個時間表時段是否有衝突
        /// </summary>
        /// <param name="BeginPeriod"></param>
        /// <param name="TestPeriod"></param>
        /// <returns></returns>
        public static bool IsTimeIntersectsWith(this Period BeginPeriod, Period TestPeriod)
        {
            //若星期不相同則不會相衝
            if (!DateTime.Equals(BeginPeriod.Date.Date, TestPeriod.Date.Date))
                return false;

            //將TestTime的年、月、日及秒設為與Appointment一致，以確保只是單純針對小時及分來做時間差的運算
            DateTime BeginTime = new DateTime(1900, 1, 1, BeginPeriod.Hour, BeginPeriod.Minute, 0);

            DateTime TestTime = new DateTime(1900, 1, 1, TestPeriod.Hour, TestPeriod.Minute, 0);

            //將Appointment的NewBeginTime減去NewTestTime
            int nTimeDif = (int)BeginTime.Subtract(TestTime).TotalMinutes;

            //狀況一：假設nTimeDif為正，並且大於NewTestTime，代表兩者沒有交集，傳回false。
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為9：00，其Duration為50。
            if (nTimeDif >= TestPeriod.Duration)
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
            else if (-nTimeDif < BeginPeriod.Duration)
                return true;

            //其他狀況傳回沒有交集
            //舉例：
            //Appointment.BeginTime為10：00，其Duration為40。
            //TestTime為10：50，其Duration為20。
            return false;
        }

        /// <summary>
        /// 取得課程名稱列表
        /// </summary>
        /// <param name="CourseIDs"></param>
        /// <returns></returns>
        public static string GetCourseNames(IEnumerable<string> CourseIDs)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(CourseIDs))
                return string.Empty;

            QueryHelper helper = Utility.QueryHelper;

            string strSQL = "select ('「' || school_year || ' ' || semester || ' ' || course_name || '」') as coursename from course where id in (" + string.Join(",", CourseIDs.Select(x => "'" + x + "'").ToArray()) + ") order by school_year,semester,course_name";

            DataTable tblCourseName = helper.Select(strSQL);

            List<string> CourseNames = new List<string>();

            foreach (DataRow Row in tblCourseName.Rows)
            {
                string CourseName = Row.Field<string>("coursename");

                if (!CourseNames.Contains(CourseName))
                    CourseNames.Add(CourseName);
            }

            return string.Join("、", CourseNames);
        }

        /// <summary>
        /// 檢查是否為合法的命名規則
        /// </summary>
        /// <param name="namingRule">班級命名規則</param>
        /// <returns></returns>
        private static bool ValidateNamingRule(string namingRule)
        {
            return namingRule.IndexOf('{') < namingRule.IndexOf('}');
        }

        /// <summary>
        /// 根據班級命名規則及年級解析出班級名稱
        /// </summary>
        /// <param name="namingRule">班級命名規則</param>
        /// <param name="gradeYear">年級</param>
        /// <returns></returns>
        public static string ParseClassName(this string namingRule, int gradeYear)
        {
            if (gradeYear >= 6)
                gradeYear -= 6;
            gradeYear--;
            if (!ValidateNamingRule(namingRule))
                return namingRule;
            string classlist_firstname = "", classlist_lastname = "";
            if (namingRule.Length == 0) return "{" + (gradeYear + 1) + "}";

            string tmp_convert = namingRule;

            // 找出"{"之前文字 並放入 classlist_firstname , 並除去"{"
            if (tmp_convert.IndexOf('{') > 0)
            {
                classlist_firstname = tmp_convert.Substring(0, tmp_convert.IndexOf('{'));
                tmp_convert = tmp_convert.Substring(tmp_convert.IndexOf('{') + 1, tmp_convert.Length - (tmp_convert.IndexOf('{') + 1));
            }
            else tmp_convert = tmp_convert.TrimStart('{');

            // 找出 } 之後文字 classlist_lastname , 並除去"}"
            if (tmp_convert.IndexOf('}') > 0 && tmp_convert.IndexOf('}') < tmp_convert.Length - 1)
            {
                classlist_lastname = tmp_convert.Substring(tmp_convert.IndexOf('}') + 1, tmp_convert.Length - (tmp_convert.IndexOf('}') + 1));
                tmp_convert = tmp_convert.Substring(0, tmp_convert.IndexOf('}'));
            }
            else tmp_convert = tmp_convert.TrimEnd('}');

            // , 存入 array
            string[] listArray = new string[tmp_convert.Split(',').Length];
            listArray = tmp_convert.Split(',');

            // 檢查是否在清單範圍
            if (gradeYear >= 0 && gradeYear < listArray.Length)
            {
                tmp_convert = classlist_firstname + listArray[gradeYear] + classlist_lastname;
            }
            else
            {
                tmp_convert = classlist_firstname + "{" + (gradeYear + 1) + "}" + classlist_lastname;
            }
            return tmp_convert;
        }


        /// <summary>
        /// 取得級別對應阿拉伯數字
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetNumberString(string p)
        {
            string levelNumber;
            switch (p.Trim())
            {
                #region 對應levelNumber
                case "1":
                    levelNumber = "Ⅰ";
                    break;
                case "2":
                    levelNumber = "Ⅱ";
                    break;
                case "3":
                    levelNumber = "Ⅲ";
                    break;
                case "4":
                    levelNumber = "Ⅳ";
                    break;
                case "5":
                    levelNumber = "Ⅴ";
                    break;
                case "6":
                    levelNumber = "Ⅵ";
                    break;
                case "7":
                    levelNumber = "Ⅶ";
                    break;
                case "8":
                    levelNumber = "Ⅷ";
                    break;
                case "9":
                    levelNumber = "Ⅸ";
                    break;
                case "10":
                    levelNumber = "Ⅹ";
                    break;
                default:
                    levelNumber = p;
                    break;
                #endregion
            }
            return levelNumber;

            ////switch (p)
            ////{
            ////    #region 對應levelNumber
            ////    case 1:
            ////        levelNumber = "I";
            ////        break;
            ////    case 2:
            ////        levelNumber = "II";
            ////        break;
            ////    case 3:
            ////        levelNumber = "III";
            ////        break;
            ////    case 4:
            ////        levelNumber = "IV";
            ////        break;
            ////    case 5:
            ////        levelNumber = "V";
            ////        break;
            ////    case 6:
            ////        levelNumber = "VI";
            ////        break;
            ////    case 7:
            ////        levelNumber = "VII";
            ////        break;
            ////    case 8:
            ////        levelNumber = "VIII";
            ////        break;
            ////    case 9:
            ////        levelNumber = "IX";
            ////        break;
            ////    case 10:
            ////        levelNumber = "X";
            ////        break;
            ////    default:
            ////        levelNumber = "" + (p);
            ////        break;
            ////    #endregion
            ////}

        }

        public static string SelectIDCondition(string TableName, string Condition)
        {
            QueryHelper helper = Utility.QueryHelper;

            DataTable Table = helper.Select("select uid from " + TableName + " where " + Condition);

            List<string> IDs = new List<string>();

            foreach (DataRow Row in Table.Rows)
                IDs.Add(Row.Field<string>("uid"));

            string strUDTCondition = string.Join(",", IDs.Select(x => "'" + x + "'"));

            return string.IsNullOrWhiteSpace(strUDTCondition) ? string.Empty : "uid in (" + strUDTCondition + ")";
        }

        /// <summary>
        /// 取得顯示時間
        /// </summary>
        /// <param name="BeginTime">開始時間</param>
        /// <param name="Duration">持續分鐘</param>
        /// <returns>回傳「開始時間」及「結束時間」的字串</returns>
        public static Tuple<string, string> GetDisplayTime(DateTime BeginTime, int Duration)
        {
            //組合結束時間
            DateTime EndTime = BeginTime.AddMinutes(Duration);

            //回傳顯示時間
            return new Tuple<string, string>(BeginTime.Hour.ToString("00") + ":" + BeginTime.Minute.ToString("00"), EndTime.Hour.ToString("00") + ":" + EndTime.Minute.ToString("00"));
        }

        /// <summary>
        /// 取得實際儲存時間
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <returns></returns>
        public static Tuple<DateTime, int> GetStorageTime(string strStartTime, string strEndTime)
        {
            if (IsValidateTime(strStartTime).Item1 && IsValidateTime(strEndTime).Item1)
            {
                string[] strStartTimes = strStartTime.Split(new char[] { ':' });
                string[] strEndTimes = strEndTime.Split(new char[] { ':' });

                DateTime StartTime = new DateTime(1900, 1, 1, int.Parse(strStartTimes[0]), int.Parse(strStartTimes[1]), 0);
                DateTime EndTime = new DateTime(1900, 1, 1, int.Parse(strEndTimes[0]), int.Parse(strEndTimes[1]), 0);

                TimeSpan Span = EndTime.Subtract(StartTime);

                return new Tuple<DateTime, int>(StartTime, Convert.ToInt32(Span.TotalMinutes));
            }

            return new Tuple<DateTime, int>(new DateTime(), 0);
        }

        /// <summary>
        /// 根據單雙週數字取得文字
        /// </summary>
        /// <param name="WeekFlag"></param>
        /// <returns></returns>
        public static string GetWeekFlagStr(this int WeekFlag)
        {
            switch (WeekFlag)
            {
                case 1: return "單";
                case 2: return "雙";
                case 3: return "單雙";
                default: return "單雙";
            }
        }

        /// <summary>
        /// 根據單雙週文字取得數字
        /// </summary>
        /// <param name="WeekFlag"></param>
        /// <returns></returns>
        public static int GetWeekFlagInt(this string WeekFlag)
        {
            switch (WeekFlag)
            {
                case "單": return 1;
                case "雙": return 2;
                case "單雙": return 3;
                default: return 3;
            }
        }

        /// <summary>
        /// 根據星期幾取得對應的中文名稱
        /// </summary>
        /// <param name="Weekday"></param>
        /// <returns></returns>
        public static string GetChiWeekday(int Weekday)
        {
            List<string> WeekdayList = GetChiWeekdayList();

            if (Weekday >= 1 && Weekday <= 6)
                return WeekdayList[Weekday - 1];
            else
                return string.Empty;
        }

        /// <summary>
        /// 根據中文星期幾取得對應的星期數字
        /// </summary>
        /// <param name="Weekday"></param>
        /// <returns></returns>
        public static int GetIntWeekday(string Weekday)
        {
            switch (Weekday)
            {
                case "一": return 1;
                case "二": return 2;
                case "三": return 3;
                case "四": return 4;
                case "五": return 5;
                case "六": return 6;
                case "七": return 7;
                default: return 0;
            }
        }

        /// <summary>
        /// 取得中文星期列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetChiWeekdayList()
        {
            return new List<string>() { "一", "二", "三", "四", "五", "六" };
        }
    }
}