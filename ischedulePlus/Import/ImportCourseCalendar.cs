using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Campus.DocumentValidator;
using Campus.Import;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    public class ImportCourseCalendar : ImportWizard
    {
        private const string constCourseName = "課程名稱";
        private const string constSchoolYear = "學年度";
        private const string constSemester = "學期";
        private const string constSubject = "科目名稱";
        private const string constLevel = "科目級別";
        private const string constTeacherName = "教師名稱";
        private const string constClassName = "班級名稱";
        private const string constClassroomName = "場地名稱";
        private const string constStartDate ="開始日期";
        private const string constStartTime ="開始時間";
        //private const string constEndDate="結束日期";
        private const string constEndTime ="結束時間";
        //private const string constWeekday = "星期";
        private const string constPeriod = "節次";
        private const string constComment = "註記";
        private const string constScheduleComment = "排課註記";
        private const string constAbsenceName = "假別";

        private ImportOption mOption;
        private AccessHelper mHelper;
        private Dictionary<string, string> mTeacherNameIDs = new Dictionary<string, string>();
        private Dictionary<string, string> mCourseNameIDs = new Dictionary<string, string>();
        private Dictionary<string, string> mClassNameIDs = new Dictionary<string, string>(); 
        private StringBuilder mstrLog = new StringBuilder();
        private Task mTask;

        /// <summary>
        /// 建構式
        /// </summary>
        public ImportCourseCalendar()
        {
            //this.CustomValidate += (Rows, Messages) => new TeacherBusyTimeConflictHelper(Rows, Messages).CheckTimeConflict();
        }

        /// <summary>
        /// 取得驗證規則
        /// </summary>
        /// <returns></returns>
        public override string GetValidateRule()
        {
            return Properties.Resources.CourseSchedule;
        }

        /// <summary>
        /// 取得支援的匯入動作
        /// </summary>
        /// <returns></returns>
        public override ImportAction GetSupportActions()
        {
            return ImportAction.InsertOrUpdate | ImportAction.Delete;
        }

        /// <summary>
        /// 準備匯入
        /// </summary>
        /// <param name="Option"></param>
        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
            mHelper = Utility.AccessHelper;

            mCourseNameIDs = new Dictionary<string, string>();
            mTask = Task.Factory.StartNew
            (() =>
            {
                QueryHelper Helper = Utility.QueryHelper;

                DataTable Table = Helper.Select("select id,course_name,school_year,semester from course");

                foreach (DataRow Row in Table.Rows)
                {
                    string CourseID = Row.Field<string>("id");
                    string CourseName = Row.Field<string>("course_name");
                    string SchoolYear = Row.Field<string>("school_year");
                    string Semester = Row.Field<string>("semester");
                    string CourseKey = CourseName + "," + SchoolYear + "," + Semester;

                    if (!mCourseNameIDs.ContainsKey(CourseKey))
                        mCourseNameIDs.Add(CourseKey, CourseID);
                }

                Table = Helper.Select("select id,teacher_name,nickname from teacher");

                foreach (DataRow Row in Table.Rows)
                {
                    string TeacherID = Row.Field<string>("id");
                    string TeacherName = Row.Field<string>("teacher_name");
                    string TeacherNickname = Row.Field<string>("nickname");
                    string TeacherKey = string.IsNullOrWhiteSpace(TeacherNickname) ? TeacherName : TeacherName + "(" + TeacherNickname + ")";

                    if (!mTeacherNameIDs.ContainsKey(TeacherKey))
                        mTeacherNameIDs.Add(TeacherKey, TeacherID);
                }

                Table = Helper.Select("select id,class_name from class");

                foreach (DataRow Row in Table.Rows)
                {
                    string ClassID = Row.Field<string>("id");
                    string ClassName = Row.Field<string>("class_name");

                    if (!mClassNameIDs.ContainsKey(ClassName))
                        mClassNameIDs.Add(ClassName, ClassID);
                }
            }
            );
        }

        /// <summary>
        /// 分批執行匯入
        /// </summary>
        /// <param name="Rows">IRowStream物件列表</param>
        /// <returns>分批匯入完成訊息</returns>
        public override string Import(List<IRowStream> Rows)
        {
            mstrLog.Clear();
            mTask.Wait();

            if (mOption.SelectedKeyFields.Count == 3 && 
                mOption.SelectedKeyFields.Contains(constTeacherName) && 
                mOption.SelectedKeyFields.Contains(constStartDate) && 
                mOption.SelectedKeyFields.Contains(constStartTime))
            {
                if (mOption.Action == ImportAction.InsertOrUpdate)
                {
                    #region Step2:針對每筆匯入資料檢查，轉換成對應的TeacherBusy，並且組合成查詢條件
                    List<string> CourseCalendarConditions = new List<string>();
                    Dictionary<CourseCalendar, IRowStream> CourseScheduleRowStreams = new Dictionary<CourseCalendar, IRowStream>();

                    foreach (IRowStream Row in Rows)
                    {
                        #region 嘗試取得課程系統編號，課程名稱、學年度及學期為必填欄位，但是允許空白
                        string CourseName = Row.GetValue(constCourseName);
                        string SchoolYear = Row.GetValue(constSchoolYear);
                        string Semester = Row.GetValue(constSemester);
                        string CourseKey = CourseName + "," + SchoolYear + "," + Semester;
                        string CourseID = mCourseNameIDs.ContainsKey(CourseKey) ? mCourseNameIDs[CourseKey] : string.Empty;
                        #endregion

                        #region 嘗試取得教系統編號，教師姓名為必填欄位，若要加上暱稱可用左右括號
                        string TeacherName = Row.GetValue(constTeacherName);
                        string TeacherID = mTeacherNameIDs.ContainsKey(TeacherName) ? mTeacherNameIDs[TeacherName] : string.Empty;
                        #endregion

                        #region 嘗試取得班級系統編號，班級名稱為必填，但是允許空白
                        string ClassName = Row.GetValue(constClassName);
                        string ClassID = mClassNameIDs.ContainsKey(ClassName) ? mClassNameIDs[ClassName] : string.Empty;
                        #endregion


                        #region 取得開始日期時間及結束日期時間
                        string StartDate = Row.GetValue(constStartDate);
                        string StartTime = Row.GetValue(constStartTime);
                        string EndDate = Row.GetValue(constStartDate);
                        string EndTime = Row.GetValue(constEndTime);
                        DateTime StartDateTime = new DateTime();
                        DateTime EndDateTime = new DateTime();

                        DateTime.TryParse(StartDate + " " + StartTime, out StartDateTime);
                        DateTime.TryParse(EndDate + " " + EndTime, out EndDateTime);
                        #endregion

                        string Subject = Row.GetValue(constSubject);             //取得科目名稱
                        string Level = Row.GetValue(constLevel);                 //取得科目級別
                        string ClassroomName = Row.GetValue(constClassroomName); //取得場地名稱
                        string Weekday = ""+StartDateTime.GetWeekday();          //取得星期
                        string Period = Row.GetValue(constPeriod);               //取得節次

                        //若有找到『教師』才可匯入
                        if (!string.IsNullOrEmpty(TeacherName))
                        {
                            //根據『教師系統編號』、『星期』及『開始時間』
                            //to_char(start_date_time,'YYYY/MM/DD HH24:MI')='2012/07/26 09:00'
                            string CourseCalendarCondition = "(teacher_name='" + TeacherName + "' and to_char(start_date_time,'YYYY/MM/DD HH24:MI')='" + StartDateTime.GetDateTimeString() + "')";
                            CourseCalendarConditions.Add(CourseCalendarCondition);

                            CourseCalendar vCourseSchedule = new CourseCalendar();
                            vCourseSchedule.CourseID = K12.Data.Int.ParseAllowNull(CourseID);
                            vCourseSchedule.TeacherName = TeacherName;
                            vCourseSchedule.TeacherID = K12.Data.Int.Parse(TeacherID);
                            vCourseSchedule.ClassID = K12.Data.Int.ParseAllowNull(ClassID);
                            vCourseSchedule.ClassName = ClassName;
                            vCourseSchedule.ClassroomName = ClassroomName;

                            vCourseSchedule.StartDateTime = StartDateTime;
                            vCourseSchedule.EndDateTime = EndDateTime;

                            vCourseSchedule.Subject = Subject;
                            vCourseSchedule.Level = K12.Data.Int.ParseAllowNull(Level);
                            vCourseSchedule.WeekDay = K12.Data.Int.Parse(Weekday);
                            vCourseSchedule.Period = K12.Data.Int.Parse(Period);

                            //if (mOption.SelectedFields.Contains(constComment))
                            //{
                            //    string Comment = Row.GetValue(constComment);
                            //    vCourseSchedule.Comment = Comment;
                            //}

                            //if (mOption.SelectedFields.Contains(constAbsenceName))
                            //{
                            //    string AbsenceName = Row.GetValue(constAbsenceName);
                            //    vCourseSchedule.AbsenceName = AbsenceName;
                            //}

                            //if (mOption.SelectedFields.Contains(constScheduleComment))
                            //{
                            //    string ScheduleComment = Row.GetValue(constScheduleComment);
                            //    vCourseSchedule.ScheduleComment = ScheduleComment;
                            //}

                            CourseScheduleRowStreams.Add(vCourseSchedule, Row);
                        }
                    }
                    #endregion

                    #region Step3:組合查詢條件，並選出系統中已存在的課程行事曆
                    List<CourseCalendar> ExistCourseSchedules = new List<CourseCalendar>();
                    
                    string strCondition = string.Join(" or ", CourseCalendarConditions.ToArray());

                    string strUDTCondition = Utility.SelectIDCondition("$scheduler.course_calendar", strCondition);

                    ExistCourseSchedules = new List<CourseCalendar>();
                    
                    if (!string.IsNullOrWhiteSpace(strUDTCondition))
                        ExistCourseSchedules = mHelper.Select<CourseCalendar>(strUDTCondition);
                    #endregion

                    #region Step4:根據轉換的結構及已選出的系統資料決定新增及更新的記錄
                    List<CourseCalendar> InsertRecords = new List<CourseCalendar>();
                    List<CourseCalendar> UpdateRecords = new List<CourseCalendar>();

                    foreach (CourseCalendar CourseSchedule in CourseScheduleRowStreams.Keys)
                    {
                        CourseCalendar ExistCourseSchedule = ExistCourseSchedules.Find(x => 
                            x.TeacherID.Equals(CourseSchedule.TeacherID) && 
                            DateTime.Equals(x.StartDateTime,CourseSchedule.StartDateTime));

                        if (ExistCourseSchedule != null)
                        {
                            ExistCourseSchedule.CourseID = CourseSchedule.CourseID;
                            ExistCourseSchedule.EndDateTime = CourseSchedule.EndDateTime;
                            ExistCourseSchedule.ClassName = CourseSchedule.ClassName;
                            ExistCourseSchedule.ClassID = CourseSchedule.ClassID;
                            ExistCourseSchedule.ClassroomName = CourseSchedule.ClassroomName;
                            ExistCourseSchedule.WeekDay = CourseSchedule.WeekDay;
                            ExistCourseSchedule.Period = CourseSchedule.Period;
                            ExistCourseSchedule.Subject = CourseSchedule.Subject;
                            ExistCourseSchedule.Level = CourseSchedule.Level;

                            UpdateRecords.Add(ExistCourseSchedule);
                        }
                        else
                            InsertRecords.Add(CourseSchedule);
                    }
                    #endregion

                    #region Step5:將資料實際新增到資料庫，並且做Log
                    if (InsertRecords.Count > 0)
                    {
                        mHelper.InsertValues(InsertRecords);
                        mstrLog.AppendLine("已成功新增"+InsertRecords.Count+"筆課程行事曆");
                    }
                    if (UpdateRecords.Count > 0)
                    {
                        mHelper.UpdateValues(UpdateRecords);
                        mstrLog.AppendLine("已成功更新"+UpdateRecords.Count +"筆課程行事曆");
                    }
                    #endregion
                }
                else if (mOption.Action == ImportAction.Delete)
                {
                    #region Step1:針對每筆匯入資料轉換成鍵值條件。
                    List<string> CourseScheduleConditions = new List<string>();

                    foreach (IRowStream Row in Rows)
                    {
                        string TeacherName = Row.GetValue(constTeacherName);

                        string StartDate = Row.GetValue(constStartDate);
                        string StartTime = Row.GetValue(constStartTime);
                        string TeacherID = mTeacherNameIDs.ContainsKey(TeacherName) ? mTeacherNameIDs[TeacherName] : string.Empty;

                        //若有找到『教師』才可匯入
                        if (!string.IsNullOrEmpty(TeacherID))
                        {
                            string CourseScheduleCondition = "(teacher_name=" + TeacherName + " and start_date_time='" + StartDate + " " + StartTime + "')";
                            CourseScheduleConditions.Add(CourseScheduleCondition);
                        }
                    }
                    #endregion

                    #region Step2:組合查詢條件
                    string strCondition = string.Join(" or ", CourseScheduleConditions.ToArray());

                    string strUDTCondition = Utility.SelectIDCondition("$scheduler.course_schedule", strCondition);

                    List<CourseCalendar> ExistCourseSchedules = new List<CourseCalendar>();

                    if (!string.IsNullOrWhiteSpace(strUDTCondition))
                        ExistCourseSchedules = mHelper.Select<CourseCalendar>(strUDTCondition);
                    #endregion

                    #region Step3:若有找出的記錄，則加以刪除並記錄
                    if (ExistCourseSchedules.Count > 0)
                    {
                        mHelper.DeletedValues(ExistCourseSchedules);
                        mstrLog.AppendLine("已成功刪除" + ExistCourseSchedules.Count + "筆課程行事曆。");
                    }
                    #endregion
                }
            }

            return mstrLog.ToString();
        } 
    }
}