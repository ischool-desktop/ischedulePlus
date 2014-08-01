using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Aspose.Cells;
using Campus.Report;
using FISCA.UDT;
using K12.Data.Configuration;
using ReportHelper;

namespace ischedulePlus
{
    /// <summary>
    /// 調課及代課報表
    /// </summary>
    public class ExchangeReplaceReport
    {
        private static List<string> PeriodList = new List<string>();
        private static int Weekday = 5;
        private static ExchangeReplaceReport mReport = null;
        private static List<SchoolYearSemesterDate> mSchoolYearSemesterDates = new List<SchoolYearSemesterDate>();
        private static Dictionary<string, Tuple<DateTime, DateTime>> mSchoolYearSemesterStartEndDates = new Dictionary<string, Tuple<DateTime, DateTime>>();
        private static AccessHelper mAccessHelper = Utility.AccessHelper;

        public static ExchangeReplaceReport Instance
        {
            get 
            {
                if (mReport == null)
                    mReport = new ExchangeReplaceReport();

                return mReport;
            }
        }

        /// <summary>
        /// 載入學年度學期
        /// </summary>
        private void LoadSchoolYearSemester()
        {
            mSchoolYearSemesterDates = mAccessHelper.Select<SchoolYearSemesterDate>();
            mSchoolYearSemesterStartEndDates.Clear();

            foreach (SchoolYearSemesterDate vSchoolYearSemester in mSchoolYearSemesterDates)
            {
                string SchoolYear = vSchoolYearSemester.SchoolYear;
                string Semester = vSchoolYearSemester.Semester;
                string SchoolYearSemester = SchoolYear + "," + Semester;

                Tuple<DateTime, DateTime> StartEndDate = vSchoolYearSemester.GetStartEndDate();

                if (!mSchoolYearSemesterStartEndDates.ContainsKey(SchoolYearSemester))
                    mSchoolYearSemesterStartEndDates.Add(SchoolYearSemester, StartEndDate);
            }
        }

        private Tuple<string, string> GetSchoolYearSemester(DateTime Date)
        {
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

        private DataTable GetExchangeReplaceDetail(
            CalendarType CalendarType, 
            string AssocID,
            List<CalendarRecord> records,
            bool IsDisplayExchangeHistory,
            bool IsDisplayExchangeOriginal,
            bool IsDisplayDate,
            DateTime dteStart,
            DateTime dteEnd)
        {
            DataTable tblResult = new DataTable("調代明細");

            DateTime WeekStartDate = DateTime.Today.StartOfWeek(DayOfWeek.Monday);
            
            if (records.Count >0)
                WeekStartDate = records[0].StartDateTime.StartOfWeek(DayOfWeek.Monday);

            DataRow rowTitle = tblResult.Rows.Add();

            List<string> Weekdays = new List<string>() { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };

            for (int i = 0; i < Weekday; i++)
            {
                DataColumn Column = new DataColumn("" + (i + 1));
                tblResult.Columns.Add(Column);
                string strWeekday = Weekdays[i];

                rowTitle.SetField<string>("" + (i + 1), strWeekday);
                WeekStartDate = WeekStartDate.AddDays(1);
            }

            //針對跨週調課做處理，最後判斷若是沒有進行顯示才顯示，避免多角調課問題
            Dictionary<string, string> CrossWeekMessage = new Dictionary<string, string>();

            for (int i = 0; i < PeriodList.Count; i++)
            {
                DataRow Row = tblResult.Rows.Add();

                string strPeriod = PeriodList[i];

                records = records
                    .OrderBy(x => x.LastUpdate)
                    .ToList();

                foreach (CalendarRecord vCalendar in records)
                {
                    if (!string.IsNullOrWhiteSpace(vCalendar.ExchangeID) && 
                        vCalendar.ExchangeCalendar!=null)
                    {
                        if (vCalendar.Period.Equals(strPeriod))
                        {
                            if (CalendarType.Equals(ischedulePlus.CalendarType.Teacher))
                            {
                                if (!vCalendar.TeacherName.Equals(AssocID))
                                {                                    
                                    string strResult = string.Empty;

                                    if (IsDisplayExchangeHistory)
                                    {
                                        strResult =
                                            (IsDisplayDate?vCalendar.MonthDay:"") + "(" + vCalendar.DisplayWeekday + ")" + vCalendar.Period + System.Environment.NewLine +
                                        vCalendar.ClassName + System.Environment.NewLine +
                                        "調至>>" + System.Environment.NewLine +
                                        (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(" + vCalendar.ExchangeCalendar.DisplayWeekday + ")" + vCalendar.ExchangeCalendar.Period;
                                    }
                                    else
                                    {
                                        //strResult = (IsDisplayDate?vCalendar.MonthDay:"") + " " + vCalendar.ClassName + System.Environment.NewLine +
                                        //vCalendar.FullSubject + System.Environment.NewLine + vCalendar.TeacherName + System.Environment.NewLine + "原" + (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(" + vCalendar.ExchangeCalendar.DisplayWeekday + ")" + vCalendar.ExchangeCalendar.Period;
                                    }

                                    if (vCalendar.StartDateTime >= dteStart &&
                                        vCalendar.StartDateTime <= dteEnd)
                                    {
                                        Row.SetField<string>(vCalendar.Weekday, strResult);
                                    }
                                    else
                                    {
                                        string Weekday = vCalendar.Weekday;
                                        string Period = vCalendar.Period;
                                        string Key = Weekday + "-" + Period;

                                        if (!CrossWeekMessage.ContainsKey(Key))
                                            CrossWeekMessage.Add(Key, strResult);
                                    }
                                }
                                else if (vCalendar.Cancel.Equals(false))
                                {
                                    string strResult =
                                    (IsDisplayDate?vCalendar.MonthDay:"") + "(調課)" + System.Environment.NewLine +
                                    vCalendar.ClassName + System.Environment.NewLine +
                                    vCalendar.FullSubject + System.Environment.NewLine +
                                    vCalendar.TeacherName;

                                    if (!string.IsNullOrEmpty(vCalendar.AbsenceName))
                                    {
                                        if (!vCalendar.AbsenceName.Equals("無"))
                                            strResult += "(" + vCalendar.AbsenceName + ")";
                                    }
                                    else
                                        strResult += "(請假)";

                                    //2014/3/26 新增，顯示原調課
                                    if (IsDisplayExchangeOriginal)
                                        strResult += System.Environment.NewLine + "原" + (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(" + vCalendar.ExchangeCalendar.DisplayWeekday + ")" + vCalendar.ExchangeCalendar.Period;

                                    if (vCalendar.StartDateTime >= dteStart &&
                                        vCalendar.StartDateTime <= dteEnd)
                                    {
                                        Row.SetField<string>(vCalendar.Weekday, strResult);
                                    }
                                    else
                                    {
                                        string Weekday = vCalendar.Weekday;
                                        string Period = vCalendar.Period;
                                        string Key = Weekday + "-" + Period;

                                        if (!CrossWeekMessage.ContainsKey(Key))
                                            CrossWeekMessage.Add(Key, strResult); 
                                    }
                                }
                            }
                            else if (CalendarType.Equals(ischedulePlus.CalendarType.Class))
                            {
                                if (vCalendar.Cancel.Equals(false))
                                {
                                    string strResult =
                                    (IsDisplayDate?vCalendar.MonthDay:"") + "(調課)" + System.Environment.NewLine +
                                    vCalendar.FullSubject + System.Environment.NewLine +
                                    vCalendar.TeacherName;

                                    if (IsDisplayExchangeOriginal)
                                        strResult += System.Environment.NewLine + "原" + (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(" + vCalendar.ExchangeCalendar.DisplayWeekday + ")" + vCalendar.ExchangeCalendar.Period;

                                    if (vCalendar.StartDateTime >= dteStart &&
                                        vCalendar.StartDateTime <= dteEnd)
                                    {
                                        Row.SetField<string>(vCalendar.Weekday, strResult);
                                    }
                                    else
                                    {
                                        string Weekday = vCalendar.Weekday;
                                        string Period = vCalendar.Period;
                                        string Key = Weekday + "-" + Period;

                                        if (!CrossWeekMessage.ContainsKey(Key))
                                            CrossWeekMessage.Add(Key, strResult);  
                                    }
                                }
                            }
                            else
                            {
                                string strResult =
                                (IsDisplayDate?vCalendar.MonthDay:"") + "(調課)" + System.Environment.NewLine +
                                vCalendar.ClassName + System.Environment.NewLine +
                                vCalendar.FullSubject + System.Environment.NewLine +
                                vCalendar.TeacherName;

                                if (IsDisplayExchangeOriginal)
                                    strResult += System.Environment.NewLine + "原" + (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(" + vCalendar.ExchangeCalendar.DisplayWeekday + ")" + vCalendar.ExchangeCalendar.Period;

                                Row.SetField<string>(vCalendar.Weekday, strResult);
                            }
                        }

                        if (vCalendar.ExchangeCalendar.Period.Equals(strPeriod))
                        {
                            if (CalendarType.Equals(ischedulePlus.CalendarType.Teacher))
                            {
                                if (!vCalendar.ExchangeCalendar.TeacherName.Equals(AssocID))
                                {
                                    string strResult = string.Empty;

                                    if (IsDisplayExchangeHistory)
                                    {
                                        strResult =
                                       (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(" + vCalendar.ExchangeCalendar.DisplayWeekday + ")" + vCalendar.ExchangeCalendar.Period + System.Environment.NewLine +
                                       vCalendar.ClassName + System.Environment.NewLine +
                                       "調至>>" + System.Environment.NewLine +
                                       ((IsDisplayDate?vCalendar.MonthDay:"") )+ "(" + vCalendar.DisplayWeekday + ")" + vCalendar.Period;
                                    }
                                    else
                                    {
                                        //strResult = (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + " " + vCalendar.ExchangeCalendar.ClassName + System.Environment.NewLine +
                                        //vCalendar.ExchangeCalendar.FullSubject + System.Environment.NewLine + vCalendar.ExchangeCalendar.TeacherName + System.Environment.NewLine + "原" + (IsDisplayDate?vCalendar.MonthDay:"") + "(" + vCalendar.DisplayWeekday + ")" + vCalendar.Period;
                                    }

                                    if (vCalendar.ExchangeCalendar.StartDateTime >= dteStart &&
                                       vCalendar.ExchangeCalendar.EndDateTime <= dteEnd)
                                    {
                                        Row.SetField<string>(vCalendar.ExchangeCalendar.Weekday, strResult);
                                    }
                                    else
                                    {
                                        string Weekday = vCalendar.ExchangeCalendar.Weekday;
                                        string Period = vCalendar.ExchangeCalendar.Period;
                                        string Key = Weekday + "-" + Period;

                                        if (!CrossWeekMessage.ContainsKey(Key))
                                            CrossWeekMessage.Add(Key, strResult);  
                                    }
                                }
                                else if (vCalendar.ExchangeCalendar.Cancel.Equals(false))
                                {
                                    string strResult =
                                    (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(調課)" + System.Environment.NewLine +
                                    vCalendar.ExchangeCalendar.ClassName + System.Environment.NewLine +
                                    vCalendar.ExchangeCalendar.FullSubject + System.Environment.NewLine +
                                    vCalendar.ExchangeCalendar.TeacherName;

                                    //2014/3/26 新增，顯示原調課
                                    if (IsDisplayExchangeOriginal)
                                        strResult += System.Environment.NewLine + "原" + ((IsDisplayDate?vCalendar.MonthDay:"")) + "(" + vCalendar.DisplayWeekday + ")" + vCalendar.Period;

                                    if (vCalendar.ExchangeCalendar.StartDateTime >= dteStart &&
                                       vCalendar.ExchangeCalendar.EndDateTime <= dteEnd)
                                    {
                                        Row.SetField<string>(vCalendar.ExchangeCalendar.Weekday, strResult);
                                    }
                                    else
                                    {
                                        string Weekday = vCalendar.ExchangeCalendar.Weekday;
                                        string Period = vCalendar.ExchangeCalendar.Period;
                                        string Key = Weekday + "-" + Period;

                                        if (!CrossWeekMessage.ContainsKey(Key))
                                            CrossWeekMessage.Add(Key, strResult);   
                                    }
                                }
                            }
                            else if (CalendarType.Equals(ischedulePlus.CalendarType.Class))
                            {
                                if (vCalendar.ExchangeCalendar.Cancel.Equals(false))
                                {
                                    string strResult =
                                    (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(調課)" + System.Environment.NewLine +
                                    vCalendar.ExchangeCalendar.FullSubject + System.Environment.NewLine +
                                    vCalendar.ExchangeCalendar.TeacherName;

                                    if (IsDisplayExchangeOriginal)
                                        strResult += System.Environment.NewLine + "原" + ((IsDisplayDate?vCalendar.MonthDay:"")) + "(" + vCalendar.DisplayWeekday + ")" + vCalendar.Period;

                                    if (vCalendar.ExchangeCalendar.StartDateTime >= dteStart &&
                                        vCalendar.ExchangeCalendar.EndDateTime <= dteEnd)
                                    {
                                        Row.SetField<string>(vCalendar.ExchangeCalendar.Weekday, strResult);
                                    }
                                    else
                                    {
                                        string Weekday = vCalendar.ExchangeCalendar.Weekday;
                                        string Period = vCalendar.ExchangeCalendar.Period;
                                        string Key = Weekday + "-" + Period;

                                        if (!CrossWeekMessage.ContainsKey(Key))
                                            CrossWeekMessage.Add(Key, strResult);    
                                    }
                                }
                            }
                            else
                            {
                                string strResult =
                                (IsDisplayDate?vCalendar.ExchangeCalendar.MonthDay:"" ) + "(調課)" + System.Environment.NewLine +
                                vCalendar.ExchangeCalendar.ClassName + System.Environment.NewLine +
                                vCalendar.ExchangeCalendar.FullSubject + System.Environment.NewLine +
                                vCalendar.ExchangeCalendar.TeacherName;

                                if (IsDisplayExchangeOriginal)
                                    strResult += System.Environment.NewLine + "原" + ((IsDisplayDate?vCalendar.MonthDay:"")) + "(" + vCalendar.DisplayWeekday + ")" + vCalendar.Period;

                                Row.SetField<string>(vCalendar.ExchangeCalendar.Weekday, strResult); 
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                    {
                        if (vCalendar.Period.Equals(strPeriod))
                        {
                            if (CalendarType.Equals(CalendarType.Teacher))
                            {
                                string strResult = string.Empty;


                                   if (vCalendar.TeacherName.Equals(AssocID))
                                   {
                                       strResult = (IsDisplayDate?vCalendar.MonthDay:"") + " " + vCalendar.ClassName + "(代課)" + System.Environment.NewLine +
                                         vCalendar.FullSubject + System.Environment.NewLine;

                                       strResult += vCalendar.AbsTeacherName + (!string.IsNullOrWhiteSpace(vCalendar.AbsenceName) ? "(" + vCalendar.AbsenceName + ")" : "(請假)");
                                   }
                                   else
                                   {
                                       strResult = (IsDisplayDate?vCalendar.MonthDay:"") + " " +
                                        vCalendar.ClassName + System.Environment.NewLine +
                                        vCalendar.FullSubject + System.Environment.NewLine;

                                       if (!string.IsNullOrWhiteSpace(vCalendar.TeacherName))
                                           strResult += vCalendar.TeacherName + "(代課)";
                                       else
                                           strResult += "(缺課)";
                                   }

                                Row.SetField<string>(vCalendar.Weekday, strResult);

                                string Weekday = vCalendar.Weekday;
                                string Period = vCalendar.Period;
                                string Key = Weekday + "-" + Period;

                                if (!CrossWeekMessage.ContainsKey(Key))
                                    CrossWeekMessage.Add(Key, strResult);    
                            }
                            else if (CalendarType.Equals(CalendarType.Class))
                            {
                                string strResult =
                                   (IsDisplayDate?vCalendar.MonthDay:"") + " " + System.Environment.NewLine +
                                   vCalendar.FullSubject + System.Environment.NewLine;

                                if (!string.IsNullOrWhiteSpace(vCalendar.TeacherName))
                                    strResult += vCalendar.TeacherName + "(代課)";
                                else
                                    strResult += "(缺課)";

                                Row.SetField<string>(vCalendar.Weekday, strResult);

                                string Weekday = vCalendar.Weekday;
                                string Period = vCalendar.Period;
                                string Key = Weekday + "-" + Period;

                                if (!CrossWeekMessage.ContainsKey(Key))
                                    CrossWeekMessage.Add(Key, strResult);    
                            }
                            else
                            {
 
                            }
                        }
                    }
                }
            }

            foreach (string Key in CrossWeekMessage.Keys)
            {
                string[] Keys = Key.Split(new char[] { '-' });

                string Weekday = Keys[0];
                string Period = Keys[1];

                int PeriodIndex = K12.Data.Int.Parse(Period);

                string Value = tblResult.Rows[PeriodIndex].Field<string>(Weekday);

                if (string.IsNullOrWhiteSpace(Value))
                    tblResult.Rows[PeriodIndex].SetField<string>(Weekday , CrossWeekMessage[Key]);
            }

            return tblResult;
        }

        public void Print(List<CalendarRecord> records,DateTime dteStart,DateTime dteEnd)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return;

            List<TeacherEx> Teachers = mAccessHelper.Select<TeacherEx>();
            List<ClassEx> Classes = mAccessHelper.Select<ClassEx>();

            SortedDictionary<string, CalendarPrintRecord> CalendarSources = new SortedDictionary<string, CalendarPrintRecord>();

            foreach(CalendarRecord record in records)
            {
                if (!string.IsNullOrWhiteSpace(record.ReplaceID))
                {
                    string AbsTeacherKey = "Teacher," + record.AbsTeacherName;
                    string TeacherKey = "Teacher," + record.TeacherName;
                    string ClassKey = "Class," + record.ClassName;

                    if (!CalendarSources.ContainsKey(AbsTeacherKey))
                        CalendarSources.Add(AbsTeacherKey, new CalendarPrintRecord(CalendarType.Teacher,record.AbsTeacherName));

                    CalendarSources[AbsTeacherKey].records.Add(record);

                    if (!CalendarSources.ContainsKey(TeacherKey))
                        CalendarSources.Add(TeacherKey, new CalendarPrintRecord(CalendarType.Teacher, record.TeacherName));

                    CalendarSources[TeacherKey].records.Add(record);

                    if (!CalendarSources.ContainsKey(ClassKey))
                        CalendarSources.Add(ClassKey, new CalendarPrintRecord(CalendarType.Class, record.ClassName));

                    CalendarSources[ClassKey].records.Add(record);
                }

                if (!string.IsNullOrWhiteSpace(record.ExchangeID))
                {
                    string TeacherKey = "Teacher,";

                    if (!string.IsNullOrWhiteSpace(record.TeacherName))
                        TeacherKey += record.TeacherName;

                    string ExchangeTeacherKey = "Teacher,";

                    if (record.ExchangeCalendar!=null && 
                        !string.IsNullOrWhiteSpace(record.ExchangeCalendar.TeacherName))
                        ExchangeTeacherKey += record.ExchangeCalendar.TeacherName;

                    string ClassKey = "Class," + record.ClassName;

                    if (!CalendarSources.ContainsKey(TeacherKey))
                        CalendarSources.Add(TeacherKey, new CalendarPrintRecord(CalendarType.Teacher, record.TeacherName));

                    CalendarSources[TeacherKey].records.Add(record);

                    if (!CalendarSources.ContainsKey(ExchangeTeacherKey))
                        CalendarSources.Add(ExchangeTeacherKey, new CalendarPrintRecord(CalendarType.Teacher, record.ExchangeCalendar.TeacherName));

                    CalendarSources[ExchangeTeacherKey].records.Add(record);

                    if (!CalendarSources.ContainsKey(ClassKey))
                        CalendarSources.Add(ClassKey, new CalendarPrintRecord(CalendarType.Class, record.ClassName));

                    CalendarSources[ClassKey].records.Add(record);
                }
            }

            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return;

            frmExchangeReplaceSelector Selector = new frmExchangeReplaceSelector(CalendarSources.Keys.ToList());

            if (Selector.ShowDialog() == DialogResult.Cancel)
                return;

            foreach (string Value in Selector.Result)
                if (CalendarSources.ContainsKey(Value))
                    CalendarSources.Remove(Value);

            Weekday = K12.Data.Int.Parse(Utility.GetWeekday());

            PeriodList = Utility.GetPeriodList();

            LoadSchoolYearSemester();

            Dictionary<string, List<DataSet>> result = new Dictionary<string, List<DataSet>>();

            foreach (CalendarPrintRecord record in CalendarSources.Values)
            {
                #region 若只印今日，先進行過濾，發覺沒有的資源就跳過不產生
                if (Selector.IsPrintDate)
                {
                    record.records = record
                        .records.FindAll(x => x.LastUpdate.Value.ToShortDateString().Equals(DateTime.Today.ToShortDateString()));

                    if (record.records.Count == 0)
                        continue;
                }
                #endregion

                DataSet DataSet = new DataSet("DataSection");

                Tuple<string, string> SchoolYearSemester = GetSchoolYearSemester(records[0].StartDateTime);

                DataSet.Tables.Add(K12.Data.School.ChineseName.ToDataTable("學校名稱", "學校名稱"));
                DataSet.Tables.Add(SchoolYearSemester.Item1.ToDataTable("學年度", "學年度"));
                DataSet.Tables.Add(SchoolYearSemester.Item2.ToDataTable("學期", "學期"));
                DataSet.Tables.Add("調代課通知單".ToDataTable("通知單", "通知單"));

                string DisplayName = record.AssocID;

                if (record.CalendarType.Equals(CalendarType.Teacher))
                {
                    DisplayName += " 老師";

                    TeacherEx Teacher = Teachers
                        .Find(x => x.FullTeacherName.Equals(record.AssocID));

                    if (Teacher != null)
                        DataSet.Tables.Add(Teacher.Note.ToDataTable("註記", "註記"));
                }
                else if (record.CalendarType.Equals(CalendarType.Class))
                {
                    ClassEx Class = Classes.
                        Find(x => x.ClassName.Equals(record.AssocID));

                    if (Class != null)
                        DataSet.Tables.Add(Class.Note.ToDataTable("註記", "註記"));
                }

                DataSet.Tables.Add(DisplayName.ToDataTable("名稱", "名稱"));

                DataSet.Tables.Add();
                DataTable tblExchangeReplace = GetExchangeReplaceDetail(
                    record.CalendarType,
                    record.AssocID,
                    record.records,
                    Selector.IsDisplayExchangeHistory,
                    Selector.IsDisplayExchangeOriginal,
                    Selector.IsDisplayDate,
                    dteStart,
                    dteEnd);

                DataSet.Tables.Add(tblExchangeReplace);

                if (!string.IsNullOrWhiteSpace(record.AssocID))
                    result.Add(record.AssocID, new List<System.Data.DataSet>() { DataSet });
            }

            try
            {
                string mSaveFilePath = string.Empty;

                if (records.Count > 0)
                {
                    #region 產生調課通知單
                    byte[] ByteExchange = Properties.Resources.調代課通知單;

                    #region 判斷是否用自訂範本，以及自訂範本是否有內容才套用
                    ConfigData config = K12.Data.School.Configuration["調代課通知單"];
                    int _useTemplateNumber = 0;
                    int.TryParse(config["TemplateNumber"], out _useTemplateNumber);
                    string customize = config["CustomizeTemplate"];
                    if (!string.IsNullOrEmpty(customize) && _useTemplateNumber == 1)
                        ByteExchange = Convert.FromBase64String(customize);
                    #endregion

                    MemoryStream StreamExchange = new MemoryStream(ByteExchange);

                    Workbook wbExchange = ReportHelper.Report.Produce(result, StreamExchange);

                    foreach (Worksheet sheet in wbExchange.Worksheets)
                        sheet.PageSetup.CenterHorizontally = true;

                    mSaveFilePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Reports\\調代課通知單.xls";

                    ReportSaver.SaveWorkbook(wbExchange, mSaveFilePath);
                    #endregion
                }
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.Message);
                SmartSchool.ErrorReporting.ReportingService.ReportException(ve);
            }

            FISCA.Presentation.MotherForm.SetStatusBarMessage("調代課通知單產生完成");
        }
    }

    public class CalendarPrintRecord
    {
        public CalendarType CalendarType { get; set; }
        
        public string AssocID { get; set; }

        public List<CalendarRecord> records { get; set; }

        public CalendarPrintRecord(CalendarType Type, string AssocID)
        {
            this.CalendarType = Type;
            this.AssocID = AssocID;
            records = new List<CalendarRecord>();
        }
    }
}