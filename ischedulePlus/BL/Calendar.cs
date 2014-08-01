using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FISCA.Data;
using FISCA.DSAClient;
using FISCA.UDT;
using K12.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 行事曆
    /// </summary>
    public class Calendar
    {
        private static Calendar mCalendar = null;
        private static AccessHelper mAccessHelper = null;
        private static QueryHelper mQueryHelper = Utility.QueryHelper;
        private static Dictionary<string, Teacher> mTeachers = null;
        private static Dictionary<string, ClassEx> mClasses = null;

        /// <summary>
        /// 取得行事曆物件
        /// </summary>
        public static Calendar Instance
        {
            get
            {
                if (mCalendar == null)
                    mCalendar = new Calendar();

                if (mAccessHelper == null)
                    mAccessHelper = Utility.AccessHelper;

                if (mTeachers == null)
                    mTeachers = new Dictionary<string, Teacher>();

                if (mClasses == null)
                    mClasses = new Dictionary<string, ClassEx>();

                return mCalendar;
            }
        }

        /// <summary>
        /// 教師清單
        /// </summary>
        public Dictionary<string, Teacher> Teachers
        {
            get { return mTeachers; }
        }

        /// <summary>
        /// 班級清單
        /// </summary>
        public Dictionary<string, ClassEx> Classes
        {
            get { return mClasses; }
        }

        /// <summary>
        /// 在背景取得班級清單
        /// </summary>
        public void RefresClassesAsync()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, e) => RefreshClasses();

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 取得班級清單
        /// </summary>
        public void RefreshClasses()
        {
            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                mClasses = new Dictionary<string, ClassEx>();

                List<ClassEx> Classes = mAccessHelper
                    .Select<ClassEx>()
                    .SortByCode();

                foreach (ClassEx vClass in Classes)
                {
                    if (!mClasses.ContainsKey(vClass.ClassName))
                    {
                        mClasses.Add(vClass.ClassName, vClass);
                    }
                }
            }
        }

        /// <summary>
        /// 在背景取得教師清單
        /// </summary>
        public void RefresTeacherAsync()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, e) => RefreshTeachers();

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 取得教師清單
        /// </summary>
        public void RefreshTeachers()
        {
            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //重新初始化教師列表
                mTeachers = new Dictionary<string, Teacher>();

                List<TeacherEx> Teachers = mAccessHelper
                    .Select<TeacherEx>()
                    .SortByCode();

                foreach (TeacherEx Teacher in Teachers)
                {
                    if (!mTeachers.ContainsKey(Teacher.FullTeacherName))
                    {
                        Teacher vTeacher = new Teacher();
                        vTeacher.ID = Teacher.UID;
                        vTeacher.Name = Teacher.FullTeacherName;
                        vTeacher.Comment = Teacher.TeachingExpertise;
                        vTeacher.Code = Teacher.TeacherCode;

                        mTeachers.Add(Teacher.FullTeacherName, vTeacher);
                    }
                }
           }
        }

        /// <summary>
        /// 取得節次列表
        /// </summary>
        /// <returns></returns>
        public  List<string> GetPeriodList()
        {
            List<string> Names = new List<string>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.PeriodList(Connection.Item1);

                foreach (XElement SubElement in Element.Elements("Period"))
                    Names.Add(SubElement.ElementText("Name"));
            }

            return Names;
        }

        /// <summary>
        /// 取得假別列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetAbsenceList()
        {
            List<string> Names = new List<string>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.AbsenceList(Connection.Item1);

                foreach (XElement SubElement in Element.Elements("Absence"))
                    Names.Add(SubElement.ElementText("Name"));
            }

            return Names;
        }

        /// <summary>
        /// 根據多筆行事曆尋找有交集的行事曆
        /// </summary>
        /// <param name="Records"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindIntersect(List<string> TeacherIDs,List<string> ClassroomNames,List<CalendarRecord> Records)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetIntersectCalendar(Connection.Item1, TeacherIDs, ClassroomNames, Records);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result;  
        }

        /// <summary>
        /// 根據多筆日期尋找行事曆
        /// </summary>
        /// <param name="Dates"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindByTeacherNameAndDates(string TeacherName, List<DateTime> Dates)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetCalendarByTeacherNameAndDates(Connection.Item1,TeacherName, Dates);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result;
        }

        /// <summary>
        /// 根據多個日期尋找行事曆
        /// </summary>
        /// <param name="Dates"></param>
        /// <returns></returns>
        public List<CalendarRecord> Find(List<DateTime> Dates)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetCalendar(Connection.Item1,Dates);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result;  
        }

        /// <summary>
        /// 根據多筆日期尋找行事曆
        /// </summary>
        /// <param name="Dates"></param>
        /// <returns></returns>
        public List<CalendarRecord> Find(string ClassName,List<DateTime> Dates)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetCalendar(Connection.Item1,ClassName,Dates);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result; 
        }

        /// <summary>
        /// 尋找調課記錄
        /// </summary>
        /// <param name="ExTeacherNames"></param>
        /// <param name="AbsTeacherIDs"></param>
        /// <param name="ClassNames"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindExchangeRecords(List<string> TargetExchangeIDs)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetExchange(Connection.Item1,TargetExchangeIDs);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement, true);
                    Result.Add(App);
                }
            }

            return Result;
        }

        /// <summary>
        /// 尋找取消調課記錄
        /// </summary>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <param name="TeacherNames"></param>
        /// <param name="ClassNames"></param>
        /// <param name="ClassroomNames"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindCancelExchangeRecords(   
            DateTime? StartDateTime,
            DateTime? EndDateTime,
            List<string> TeacherNames,
            List<string> ClassNames,
            List<string> ClassroomNames)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            QueryHelper helper = Utility.QueryHelper;

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("select uid from $scheduler.cancel_course_calendar where type='調課' ");

            List<string> strConditions = new List<string>();

            if (StartDateTime != null)
                strConditions.Add("( to_char(start_date, 'YYYY/MM/DD')>='" + StartDateTime.Value.ToString("yyyy/MM/dd") +"' or to_char(ex_start_date, 'YYYY/MM/DD')>='" + StartDateTime.Value.ToString("yyyy/MM/dd") +"')");

            if (EndDateTime != null)
                strConditions.Add("( to_char(start_date, 'YYYY/MM/DD')<='" + EndDateTime.Value.ToString("yyyy/MM/dd") + "' or to_char(ex_start_date, 'YYYY/MM/DD')<='" + EndDateTime.Value.ToString("yyyy/MM/dd") + "')");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
            {
                string strTeachers = string.Join(",", TeacherNames.Select(x=>"'"+x+"'").ToArray());

                strConditions.Add("(teacher_name in (" + strTeachers + ") or ex_teacher_name in (" + strTeachers + "))");
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassNames))
            {
                string strClass = string.Join(",", ClassNames.Select(x => "'" + x + "'").ToArray());

                strConditions.Add("ex_class_name in (" + strClass + ")");
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassroomNames))
            {
                string strClassroom = string.Join(",", ClassroomNames.Select(x => "'" + x + "'").ToArray());

                strConditions.Add("(classroom_name in (" + strClassroom + ") or ex_classroom_name in (" + strClassroom + "))");
            }

            if (strConditions.Count > 0)
            {
                string strCondition = string.Join(" and ",strConditions.ToArray());
                strBuilder.Append(" and " + strCondition);
            }

            DataTable table = helper.Select(strBuilder.ToString());

            if (table.Rows.Count > 0)
            {
                List<string> UIDs = new List<string>();

                foreach (DataRow Row in table.Rows)
                {
                    string UID = Row.Field<string>("uid");
                    UIDs.Add(UID);
                }

                List<CancelCourseCalendar> Calendars = mAccessHelper.Select<CancelCourseCalendar>("uid in (" + string.Join(",",UIDs.ToArray()) + ")");

                if (Calendars.Count > 0)
                {
                    foreach (CancelCourseCalendar Calendar in Calendars)
                    {
                        XElement elmCalendar = XElement.Load(new StringReader(Calendar.Content));

                        CalendarRecord vRecord = new CalendarRecord(elmCalendar,Calendar.Type.Equals("調課"));

                        vRecord.Delete = "是";
                        vRecord.ExchangeCalendar.Delete = "是";

                        Result.Add(vRecord);
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// 尋找調課記錄
        /// </summary>
        /// <param name="ExTeacherNames"></param>
        /// <param name="AbsTeacherIDs"></param>
        /// <param name="ClassNames"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindExchangeRecords(
            DateTime? StartDateTime,
            DateTime? EndDateTime,
            List<string> TeacherNames,
            List<string> ClassNames,
            List<string> ClassroomNames,
            DateTime? ExStartDateTime,
            DateTime? ExEndDateTime,
            List<string> ExTeacherNames,
            List<string> ExClassNames,
            List<string> ExClassroomNames)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetExchange(Connection.Item1,
                    StartDateTime,
                    EndDateTime,
                    TeacherNames, 
                    ClassNames, 
                    ClassroomNames,
                    ExStartDateTime, 
                    ExEndDateTime,
                    ExTeacherNames,
                    ExClassNames,
                    ExClassroomNames);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement,true);
                    Result.Add(App);
                }
            }

            return Result;
        }

        /// <summary>
        /// 尋找代課記錄
        /// </summary>
        /// <param name="ReplaceIDs">代課系統編號</param>
        /// <returns></returns>
        public List<CalendarRecord> FindReplaceRecords(List<string> ReplaceIDs)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetReplace(Connection.Item1,ReplaceIDs);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result;
        }

        /// <summary>
        /// 尋找取消代課記錄
        /// </summary>
        /// <param name="TeacherNames"></param>
        /// <param name="ClassNames"></param>
        /// <param name="ClassroomNames"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindCancelReplaceRecords(
            List<string> TeacherNames,
            List<string> ClassNames,
            List<string> ClassroomNames,
            DateTime StartDateTime,
            DateTime EndDateTime)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            QueryHelper helper = Utility.QueryHelper;

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("select uid from $scheduler.cancel_course_calendar where type='代課' ");

            List<string> strConditions = new List<string>();

            strConditions.Add("to_char(start_date, 'YYYY/MM/DD')>='" + StartDateTime.ToString("yyyy/MM/dd") + "'");
            strConditions.Add("to_char(start_date, 'YYYY/MM/DD')<='" + EndDateTime.ToString("yyyy/MM/dd") + "'");
            
            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
            {
                string strTeachers = string.Join(",", TeacherNames.Select(x => "'" + x + "'").ToArray());
                strConditions.Add("(teacher_name in (" + strTeachers + ") or absence_teacher_name in (" + strTeachers + "))");
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassNames))
            {
                string strClass = string.Join(",", ClassNames.Select(x => "'" + x + "'").ToArray());
                strConditions.Add("ex_class_name in (" + strClass + ")");
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassroomNames))
            {
                string strClassroom = string.Join(",", ClassroomNames.Select(x => "'" + x + "'").ToArray());
                strConditions.Add("classroom_name in (" + strClassroom + ")");
            }

            if (strConditions.Count > 0)
            {
                string strCondition = string.Join(" and ", strConditions.ToArray());
                strBuilder.Append(" and " + strCondition);
            }

            DataTable table = helper.Select(strBuilder.ToString());

            if (table.Rows.Count > 0)
            {
                List<string> UIDs = new List<string>();

                foreach (DataRow Row in table.Rows)
                {
                    string UID = Row.Field<string>("uid");
                    UIDs.Add(UID);
                }

                List<CancelCourseCalendar> Calendars = mAccessHelper.Select<CancelCourseCalendar>("uid in (" + string.Join(",", UIDs.ToArray()) + ")");

                if (Calendars.Count > 0)
                {
                    foreach (CancelCourseCalendar Calendar in Calendars)
                    {
                        XElement elmCalendar = XElement.Load(new StringReader(Calendar.Content));

                        CalendarRecord vRecord = new CalendarRecord(elmCalendar, Calendar.Type.Equals("調課"));

                        vRecord.Delete = "是";

                        Result.Add(vRecord);
                    }
                }
            }

            return Result; 
        }

        /// <summary>
        /// 尋找代課記錄
        /// </summary>
        /// <returns></returns>
        public List<CalendarRecord> FindReplaceRecords(
            List<string> RepTeacherNames,
            List<string> AbsTeacherNames,
            List<string> ClassNames,
            List<string> ClassroomNames,
            DateTime StartDateTime,
            DateTime EndDateTime)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetReplace(Connection.Item1,RepTeacherNames,AbsTeacherNames,ClassNames,ClassroomNames,StartDateTime,EndDateTime);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result;
        }

        /// <summary>
        /// 取得班級調課相關的教師及場地課程行事曆
        /// </summary>
        /// <param name="ClassName"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindExchangeRelated(
            string ClassName,
            DateTime StartDateTime,
            DateTime EndDateTime)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetExchangeRelatedCalendar(Connection.Item1,
                    ClassName,
                    StartDateTime,
                    EndDateTime);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result; 
        }

        /// <summary>
        /// 尋找教師行事曆
        /// </summary>
        /// <param name="TeacherID">教師系統編號</param>
        /// <param name="ClassID">班級系統編號</param>
        /// <param name="StartDateTime">開始日期時間</param>
        /// <param name="EndDateTime">結束日期時間</param>
        /// <returns>行事曆列表</returns>
        public List<CalendarRecord> Find(
            List<string> TeacherNames,
            List<string> ClassNames,
            List<string> ClassroomNames,
            DateTime StartDateTime,
            DateTime EndDateTime,
            bool? Cancel)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            Tuple<Connection,string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetCalendar(Connection.Item1 , 
                    TeacherNames,
                    ClassNames, 
                    ClassroomNames,
                    StartDateTime, 
                    EndDateTime,
                    Cancel);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    CalendarRecord App = new CalendarRecord(SubElement);
                    Result.Add(App);
                }
            }

            return Result;
        }

        /// <summary>
        /// 載入設定
        /// </summary>
        /// <returns></returns>
        private List<string> LoadPreference()
        {
            List<string> DSNS = new List<string>();

            try
            {
                string Config = ContractService.GetDSNSConfig();
                DSNS.AddRange(Config.Split(new char[] { ',' }));
            }
            catch (Exception e)
            {
                throw e;
            }

            return DSNS;
        }

        /// <summary>
        /// 尋找教師行事曆
        /// </summary>
        /// <param name="TeacherID">教師系統編號</param>
        /// <param name="ClassID">班級系統編號</param>
        /// <param name="StartDateTime">開始日期時間</param>
        /// <param name="EndDateTime">結束日期時間</param>
        /// <returns>行事曆列表</returns>
        public List<CalendarRecord> FindCross(
            List<string> TeacherNames,
            DateTime StartDateTime,
            DateTime EndDateTime,
            bool? Cancel)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();

            try
            {
                List<string> DSNSList = LoadPreference();

                foreach (string DSNS in DSNSList)
                {
                    if (!string.IsNullOrWhiteSpace(DSNS))
                    {
                        Tuple<Connection, string> Connection = ContractService
                            .GetConnection(DSNS, "QueryCalendar");

                        if (string.IsNullOrEmpty(Connection.Item2))
                        {
                            XElement Element = ContractService.GetCrossCalendar(Connection.Item1,
                                TeacherNames,
                               StartDateTime,
                                EndDateTime,
                                Cancel);

                            foreach (XElement SubElement in Element.Elements("Calendar"))
                            {
                                CalendarRecord App = new CalendarRecord(SubElement);
                                Result.Add(App);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
 
            }

            return Result;
        }

        /// <summary>
        /// 尋找指定時段內的班級忙碌時段
        /// </summary>
        /// <param name="ClassNames"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public List<ClassBusy> FindBusyClass(
            List<string> ClassNames,
            DateTime StartDate,
            DateTime EndDate)
        {
            List<ClassBusy> ClassBusys = new List<ClassBusy>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetIntersectClassBusy(
                    Connection.Item1,
                    ClassNames,
                    StartDate,
                    EndDate);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    ClassBusy TeacherBusy = new ClassBusy(SubElement);
                    ClassBusys.Add(TeacherBusy);
                }
            }

            return ClassBusys;
        }        

        /// <summary>
        /// 尋找指定時段內的教師忙碌時段
        /// </summary>
        /// <param name="TeacherNames"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public List<TeacherBusy> FindBusyTeacher(
            List<string> TeacherNames,
            DateTime StartDate,
            DateTime EndDate)
        {
            List<TeacherBusy> TeacherBusys = new List<TeacherBusy>();

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetIntersectTeacherBusy(
                    Connection.Item1,
                    TeacherNames,
                    StartDate,
                    EndDate);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    TeacherBusy TeacherBusy = new TeacherBusy(SubElement);
                    TeacherBusys.Add(TeacherBusy);
                }
            }

            return TeacherBusys; 
        }

        /// <summary>
        /// 尋找多個指定時段內忙碌的教師
        /// </summary>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public List<TeacherBusy> FindBusyTeacher(
            List<string> TeacherNames,
            List<CalendarRecord> Calendars)
        {
            List<TeacherBusy> TeacherBusys = new List<TeacherBusy>();

            Tuple<Connection,string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                XElement Element = ContractService.GetIntersectTeacherBusy(
                    Connection.Item1,
                    TeacherNames,
                    Calendars);

                foreach (XElement SubElement in Element.Elements("Calendar"))
                {
                    TeacherBusy TeacherBusy = new TeacherBusy(SubElement);
                    TeacherBusys.Add(TeacherBusy);
                }
            }

            return TeacherBusys;
        }

        /// <summary>
        /// 尋找可代課教師
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="Subject"></param>
        /// <param name="Levelt"></param>
        public List<Teacher> FindReplace(List<CalendarRecord> Apps, string Subject, int? Levelt)
        {
            List<Teacher> Result = new List<Teacher>();

            foreach(Teacher mWho in mTeachers.Values)
            {
                Result.Add(mWho);
            }

            return Result; 
        }

        /// <summary>
        /// 尋找可調課行事曆
        /// </summary>
        /// <param name="CourseCalendar"></param>
        /// <returns></returns>
        public List<CalendarRecord> FindExchange(CalendarRecord Calendar,DateTime StartDate,DateTime EndDate)
        {
            List<CalendarRecord> Result = new List<CalendarRecord>();


            return Result; 
        }

        /// <summary>
        /// 鎖定或解除鎖定行事曆
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="Lock"></param>
        public void Lock(List<CalendarRecord> Calendars, bool Lock)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return;

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //將行事曆取消，只更新Cancel欄位
                XElement Element = ContractService.LockCalendar(Connection.Item1,
                    Calendars,
                    Lock);
            }
        }

        /// <summary>
        /// 取消或啟用行事曆
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="Cancel"></param>
        public void Cancel(List<CalendarRecord> Calendars, bool Cancel)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return;

            Tuple<Connection,string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //將行事曆取消，只更新Cancel欄位
                XElement Element = ContractService.CancelCalendar(Connection.Item1, 
                    Calendars, 
                    Cancel);
            }
        }

        /// <summary>
        /// 取消或啟用行事曆
        /// </summary>
        /// <param name="UIDs"></param>
        /// <param name="Cancel"></param>
        public void Cancel(List<string> UIDs, bool Cancel)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(UIDs))
                return;

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //將行事曆取消，只更新Cancel欄位
                XElement Element = ContractService.CancelCalendar(Connection.Item1,
                    UIDs,
                    Cancel);
            }
        }

        /// <summary>
        /// 刪除行事曆
        /// </summary>
        /// <param name="UIDs"></param>
        public void Delete(List<string> UIDs)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(UIDs))
                return;

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //將行事曆取消，只更新Cancel欄位
                XElement Element = ContractService.DeleteCalendar(Connection.Item1,UIDs);
            }
        }

        /// <summary>
        /// 代課作業
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="Teacher"></param>
        /// <returns></returns>
        public Tuple<bool,string> Replace(List<CalendarRecord> Calendars,Teacher Teacher,string Absence,string Comment)
        {
            Tuple<Connection,string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //將行事曆取消，只更新Cancel欄位
                XElement Element = ContractService.CancelCalendar(Connection.Item1, Calendars,true);

                #region 建立代課行事曆
                List<CalendarRecord> NewCalendars = new List<CalendarRecord>();

                foreach (CalendarRecord Calendar in Calendars)
                {
                    CalendarRecord NewCalendar = new CalendarRecord(Calendar);
                    NewCalendar.ExchangeID = string.Empty;
                    NewCalendar.ReplaceID = Calendar.UID;

                    if (Teacher != null)
                    {
                        NewCalendar.TeacherID = Teacher.ID;
                        NewCalendar.TeacherName = Teacher.Name;
                    }
                    else
                    {
                        NewCalendar.TeacherID = string.Empty;
                        NewCalendar.TeacherName = string.Empty;
                    }

                    NewCalendar.AbsenceName = Absence;
                    NewCalendar.Comment = Comment;
                    NewCalendars.Add(NewCalendar);
                }
                #endregion

                //新增代課行事曆
                XElement InsertElement = ContractService.InsertCalendar(Connection.Item1, NewCalendars);

                return new Tuple<bool, string>(true, string.Empty);
            }

            return new Tuple<bool,string>(false,"連線錯誤");
        }

        /// <summary>
        /// 調課作業
        /// </summary>
        /// <param name="Src"></param>
        /// <param name="Des"></param>
        /// <returns></returns>
        public Tuple<bool,string> Exchange(
            CalendarRecord Src, 
            CalendarRecord Des,
            bool NoRecord,
            string AbsenceName,
            string Comment)
        {
            if (NoRecord)
            {
                try
                {
                    UpdateHelper updateHelper = new UpdateHelper();

                    List<string> Commands = new List<string>();

                    Commands.Add("update $scheduler.course_calendar set weekday=" + Src.Weekday +",period=" + Src.Period +",start_date_time='" + Src.StartDateTime.GetDateTimeString() +"',end_date_time='" + Src.EndDateTime.GetDateTimeString() + "' where uid=" + Des.UID);
                    Commands.Add("update $scheduler.course_calendar set weekday=" + Des.Weekday + ",period=" + Des.Period + ",start_date_time='" + Des.StartDateTime.GetDateTimeString() + "',end_date_time='" + Des.EndDateTime.GetDateTimeString() + "' where uid=" + Src.UID);

                    updateHelper.Execute(Commands);
                }catch(Exception e)
                {
                    return new Tuple<bool,string>(false,e.Message);
                }
            }
            else
            {
                Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

                if (string.IsNullOrEmpty(Connection.Item2))
                {
                    //將行事曆取消，只更新Cancel欄位
                    XElement Element = ContractService.CancelCalendar(Connection.Item1,
                        new List<CalendarRecord>() { Src, Des }, true);

                    #region 建立調課行事曆
                    List<CalendarRecord> NewCalendars = new List<CalendarRecord>();

                    CalendarRecord NewSrc = new CalendarRecord(Des);
                    NewSrc.ExchangeID = Src.UID;
                    NewSrc.StartDateTime = Src.StartDateTime;
                    NewSrc.EndDateTime = Src.EndDateTime;
                    NewSrc.Weekday = Src.Weekday;
                    NewSrc.Period = Src.Period;
                    NewSrc.Comment = Comment;
                    NewSrc.AbsenceName = string.Empty;

                    CalendarRecord NewDes = new CalendarRecord(Src);
                    NewDes.ExchangeID = Des.UID;
                    NewDes.StartDateTime = Des.StartDateTime;
                    NewDes.EndDateTime = Des.EndDateTime;
                    NewDes.Weekday = Des.Weekday;
                    NewDes.Period = Des.Period;
                    NewDes.Comment = Comment;
                    NewDes.AbsenceName = AbsenceName;

                    NewCalendars.Add(NewSrc);
                    NewCalendars.Add(NewDes);
                    #endregion

                    //新增代課行事曆
                    XElement InsertElement = ContractService.InsertCalendar(Connection.Item1, NewCalendars);

                    QueryHelper helper = Utility.QueryHelper;
                    DataTable table = helper.Select("select * from $scheduler.course_calendar order by last_update desc limit 2");

                    string UpdateUID = string.Empty;
                    string UpdateTargetExchangeUID = string.Empty;

                    DateTime FirstDateTime = K12.Data.DateTimeHelper.ParseDirect(table.Rows[0].Field<string>("start_date_time"));
                    DateTime SecondDateTime = K12.Data.DateTimeHelper.ParseDirect(table.Rows[1].Field<string>("start_date_time"));

                    if (FirstDateTime.GetDateTimeString().Equals(NewDes.StartDateTime.GetDateTimeString()))
                    {
                        UpdateUID = table.Rows[0].Field<string>("uid");
                        UpdateTargetExchangeUID = table.Rows[1].Field<string>("uid");
                    }
                    else if (SecondDateTime.GetDateTimeString().Equals(NewDes.StartDateTime.GetDateTimeString()))
                    {
                        UpdateUID = table.Rows[1].Field<string>("uid");
                        UpdateTargetExchangeUID = table.Rows[0].Field<string>("uid");
                    }

                    if (!string.IsNullOrEmpty(UpdateUID) && !string.IsNullOrEmpty(UpdateTargetExchangeUID))
                    {
                        XElement UpdateElement = ContractService.UpdateCalendarTargetID(Connection.Item1,
                            UpdateUID
                            , UpdateTargetExchangeUID);
                    }
                    return new Tuple<bool, string>(true, string.Empty);
                }
            }

            return new Tuple<bool, string>(true, string.Empty); 
        }

        /// <summary>
        /// 建立新的EMail寄發記錄
        /// </summary>
        /// <param name="EMailLog"></param>
        /// <param name="EMails"></param>
        private string CreateNewEMailLog(string EMailLog,List<string> EMails)
        {
            StringReader strReader = new StringReader(string.IsNullOrEmpty(EMailLog) ? "<EMailLog/>" : EMailLog);

            XElement elmEMailLog = XElement.Load(strReader);

            foreach (string EMail in EMails)
            {
                XElement elmLog = new XElement("Log");
                elmLog.SetAttributeValue("EMail",EMail);
                elmLog.SetAttributeValue("DateTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                elmEMailLog.Add(elmLog);
            }

            return elmEMailLog.ToString();
        }

        /// <summary>
        /// 記錄電子郵件
        /// </summary>
        /// <param name="Calendars"></param>
        /// <param name="Teachers"></param>
        public Tuple<bool, string> LogEMail(List<CalendarRecord> Calendars, List<TeacherRecord> Teachers)
        {
            Dictionary<string, string> vLogMail = new Dictionary<string, string>();

            foreach (CalendarRecord Calendar in Calendars)
            {
                //調課記錄
                if (Calendar.ExchangeCalendar != null)
                {
                    TeacherRecord CalendarTeacher = Teachers.Find(x => x.ID.Equals(Calendar.TeacherID));
                    TeacherRecord ExchangeCalendarTeacher = Teachers.Find(x=>x.ID.Equals(Calendar.ExchangeCalendar.TeacherID));

                    List<string> EMails = new List<string>();

                    if (!string.IsNullOrEmpty(CalendarTeacher.Email))
                        EMails.Add(CalendarTeacher.Email);
                    if (!string.IsNullOrEmpty(ExchangeCalendarTeacher.Email))
                        EMails.Add(ExchangeCalendarTeacher.Email);

                    string NewEMailLog = CreateNewEMailLog(Calendar.EMailLog,EMails);

                     vLogMail.Add(Calendar.UID,NewEMailLog);
                     vLogMail.Add(Calendar.ExchangeCalendar.UID,NewEMailLog);
                }
                //代課記錄
                else 
                {
                    TeacherRecord ReplaceTeacher = Teachers.Find(x=>x.ID.Equals(Calendar.TeacherID));
                    TeacherRecord AbsenceTeacher = Teachers.Find(x=>x.ID.Equals(Calendar.AbsTeacherID));

                    List<string> EMails = new List<string>();

                    if (!string.IsNullOrEmpty(ReplaceTeacher.Email))
                        EMails.Add(ReplaceTeacher.Email);
                    if (!string.IsNullOrEmpty(AbsenceTeacher.Email))
                        EMails.Add(AbsenceTeacher.Email);

                    string NewEMailLog = CreateNewEMailLog(Calendar.EMailLog, EMails);

                    vLogMail.Add(Calendar.UID, NewEMailLog);
                }
            }

            Tuple<Connection, string> Connection = ContractService.GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            if (string.IsNullOrEmpty(Connection.Item2))
            {
                //將行事曆取消，只更新Cancel欄位
                XElement Element = ContractService.UpdteCalendarEMailLog(Connection.Item1,vLogMail);
                return new Tuple<bool, string>(true, string.Empty);
            }

            return new Tuple<bool, string>(false, "連線錯誤");

        }
    }
}