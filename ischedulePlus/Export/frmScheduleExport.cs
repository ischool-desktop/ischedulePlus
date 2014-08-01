using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 批次建立週課程分段
    /// </summary>
    public partial class frmScheduleExport : FISCA.Presentation.Controls.BaseForm
    {
        private string OutputTimeString = "HH:mm";
        private OleDbConnection Sql_Conn = new OleDbConnection();
        private OleDbCommand Sql_Command = new OleDbCommand();
        private OleDbDataReader sdr;

        private AccessHelper mUDTHelper = Utility.AccessHelper;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private const int PackageSize = 500;

        /// <summary>
        /// 建構式
        /// </summary>
        public frmScheduleExport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 準備連線
        /// </summary>
        private bool PreparConnection()
        {
            //取得目前的ICIS連線以及轉檔相關設定
            //學校SQL連線的設定值
            Campus.Configuration.ConfigData cdApp = Campus.Configuration.Config.App["Foxpro_Setup"];

            if (!DataAccess.HasFoxproConnectionString(cdApp))
            {
                MessageBox.Show("尚未設定Foxpro資料庫連線資訊!!請先設定連線資訊!! ");
                return false;
            }

            string Sql_ConnString = DataAccess.GetFoxproConnectionString(cdApp);

            Sql_Conn.Close();

            // 建立資料庫連結
            Sql_Conn.ConnectionString = Sql_ConnString;
            // 建立命令物件
            Sql_Command.Connection = Sql_Conn;

            try
            {
                // 開啟連結
                Sql_Conn.Open();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("連線失敗!! " + e.Message);

                return false;
            }
        }


        /// <summary>
        /// 表單載入資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCreateWeekCourseSection_Load(object sender, EventArgs e)
        {
            int SchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);

            for (int i = SchoolYear - 3; i < SchoolYear +4 ; i++)
                cmbSchoolYear.Items.Add(i);

            cmbSchoolYear.SelectedIndex = 3;

            cmbSemster.Items.Add("1");
            cmbSemster.Items.Add("2");

            cmbSemster.SelectedItem = K12.Data.School.DefaultSemester;
        }

        public string GetNumberToChinese(string ClassName)
        {
            if (ClassName.EndsWith("1"))
                return ClassName.Replace("1", "甲");
            else if (ClassName.EndsWith("１"))
                return ClassName.Replace("１", "甲");
            else if (ClassName.EndsWith("2"))
                return ClassName.Replace("2", "乙");
            else if (ClassName.EndsWith("２"))
                return ClassName.Replace("２", "乙");
            else if (ClassName.EndsWith("3"))
                return ClassName.Replace("3", "丙");
            else if (ClassName.EndsWith("３"))
                return ClassName.Replace("３", "丙");
            else if (ClassName.EndsWith("4"))
                return ClassName.Replace("4", "丁");
            else if (ClassName.EndsWith("４"))
                return ClassName.Replace("４", "丁");
            else
                return ClassName;
        }

        public Tuple<string, string> GetPeriodStartEndTime(string Period)
        {
            switch(Period)
            {
                case "1":
                    return new Tuple<string,string>("08:10","09:00");
                case "2":
                    return new Tuple<string,string>("09:10","10:00");
                case "3":
                    return new Tuple<string,string>("10:10","11:00");
                case "4":
                    return new Tuple<string,string>("11:10","12:00");
                case "5":
                    return new Tuple<string,string>("13:10","14:00");
                case "6":
                    return new Tuple<string,string>("14:10","15:00");
                case "7":
                    return new Tuple<string,string>("15:10","16:00");
                case "8":
                    return new Tuple<string,string>("16:10","16:55");
                case "9":
                    return new Tuple<string, string>("17:00", "17:45");
                default:
                    return new Tuple<string,string>(string.Empty,string.Empty);
            }	 	 	 	
        }

        /// <summary>
        /// 匯出已產生的課程分段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            #region 建立空白表格
            Workbook book = new Workbook();

            book.Worksheets.Add();

            book.Worksheets[0].Name = "週課表";
            book.Worksheets[0].Cells[0, 0].PutValue("課程名稱");
            book.Worksheets[0].Cells[0, 1].PutValue("學年度");
            book.Worksheets[0].Cells[0, 2].PutValue("學期");
            book.Worksheets[0].Cells[0, 3].PutValue("科目名稱");
            book.Worksheets[0].Cells[0, 4].PutValue("科目級別");
            book.Worksheets[0].Cells[0, 5].PutValue("科目簡稱");

            book.Worksheets[0].Cells[0, 6].PutValue("授課教師一");
            book.Worksheets[0].Cells[0, 7].PutValue("授課教師一代碼");

            book.Worksheets[0].Cells[0, 8].PutValue("授課教師二");
            book.Worksheets[0].Cells[0, 9].PutValue("授課教師二代碼");

            book.Worksheets[0].Cells[0, 10].PutValue("授課教師三");
            book.Worksheets[0].Cells[0, 11].PutValue("授課教師三代碼");

            book.Worksheets[0].Cells[0, 12].PutValue("所屬班級");
            book.Worksheets[0].Cells[0, 13].PutValue("班級年級");
            book.Worksheets[0].Cells[0, 14].PutValue("場地");
            book.Worksheets[0].Cells[0, 15].PutValue("星期");
            book.Worksheets[0].Cells[0, 16].PutValue("節次");
            book.Worksheets[0].Cells[0, 17].PutValue("開始時間");
            book.Worksheets[0].Cells[0, 18].PutValue("結束時間");
            book.Worksheets[0].Cells[0, 19].PutValue("鎖定");
            book.Worksheets[0].Cells[0, 20].PutValue("註記");

            book.Worksheets[1].Name = "教師不調代時段";
            book.Worksheets[1].Cells[0, 0].PutValue("學年度");
            book.Worksheets[1].Cells[0, 1].PutValue("學期");
            book.Worksheets[1].Cells[0, 2].PutValue("教師姓名");
            book.Worksheets[1].Cells[0, 3].PutValue("星期");
            book.Worksheets[1].Cells[0, 4].PutValue("節次");
            book.Worksheets[1].Cells[0, 5].PutValue("開始時間");
            book.Worksheets[1].Cells[0, 6].PutValue("結束時間");
            book.Worksheets[1].Cells[0, 7].PutValue("不調代描述");

            book.Worksheets[0].AutoFitColumns();
            book.Worksheets[1].AutoFitColumns();
            #endregion 

            #region 組合成SQL指令
            string SchoolYear = "" + cmbSchoolYear.Text;
            string Semester = "" + cmbSemster.Text;

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("select course.course_name AS 課程名稱,course.school_year as 學年度,course.semester as 學期,course.subject as 科目名稱,course.level AS 科目級別,course.subject_alias_name AS 科目簡稱, cs.teacher_name_1 AS 授課教師一, cs.teacher_name_2 AS 授課教師二, cs.teacher_name_3 AS 授課教師三, course.class_name AS 所屬班級, $scheduler.classroom.name AS 場地, cs.weekday AS 星期, cs.period AS 節次, cs.length AS 節數, course.ref_timetable_id AS 時間表系統編號, $scheduler.timetable.name AS 時間表名稱, cs.comment AS 註記 from $scheduler.scheduler_course_section as cs ");
            strBuilder.Append(" inner join $scheduler.scheduler_course_extension as course on course.uid=cs.ref_course_id inner join $scheduler.timetable on $scheduler.timetable.uid=course.ref_timetable_id left outer join $scheduler.classroom on $scheduler.classroom.uid=cs.ref_classroom_id ");
            strBuilder.Append(" where course.subject!='' and (course.school_year='" + SchoolYear + "'  AND course.semester='" + Semester + "' ) and cs.weekday!=0");
            strBuilder.Append(" order by course.course_name,course.school_year,course.semester");
            #endregion

            #region 取得所有班級清單
            List<ClassEx> Classes = mUDTHelper.Select<ClassEx>();

            List<TeacherEx> Teachers = mUDTHelper.Select<TeacherEx>();

            List<TeacherExBusy> TeacherBusys = mUDTHelper.Select<TeacherExBusy>();

            List<TimeTableSec> TimeTableSecs = mUDTHelper.Select<TimeTableSec>();

            DataTable table = mQueryHelper.Select(strBuilder.ToString());
            #endregion

            #region 填入教師不排課時段
            for (int i = 0; i < TeacherBusys.Count; i++)
            {
                TeacherEx vTeacher = Teachers.Find(x => x.UID.Equals("" + TeacherBusys[i].TeacherID));

                if (vTeacher != null)
                {
                    //學年度	學期	教師姓名	星期	節次	開始時間	結束時間	不調代描述
                    book.Worksheets[1].Cells[i + 1, 0].PutValue(SchoolYear);
                    book.Worksheets[1].Cells[i + 1, 1].PutValue(Semester);
                    book.Worksheets[1].Cells[i + 1, 2].PutValue(vTeacher.FullTeacherName);
                    book.Worksheets[1].Cells[i + 1, 3].PutValue(TeacherBusys[i].WeekDay);
                    book.Worksheets[1].Cells[i + 1, 4].PutValue("");

                    string StartTime = TeacherBusys[i].BeginTime.ToString(OutputTimeString);
                    string EndTime = TeacherBusys[i].BeginTime.AddMinutes(TeacherBusys[i].Duration).ToString(OutputTimeString);

                    book.Worksheets[1].Cells[i + 1, 5].PutValue(StartTime);
                    book.Worksheets[1].Cells[i + 1, 6].PutValue(EndTime);
                    book.Worksheets[1].Cells[i + 1, 7].PutValue(TeacherBusys[i].BusyDesc);
                }
            }
            #endregion 

            #region 填入課程分段
            int RowIndex = 1;

            foreach (DataRow row in table.Rows)
            {
                int Len = K12.Data.Int.Parse(row.Field<string>("節數"));

                string ClassName = row.Field<string>("所屬班級");
                string ClassGradeYear = string.Empty;
                int TimeTableID = K12.Data.Int.Parse(row.Field<string>("時間表系統編號"));
                int Weekday = K12.Data.Int.Parse(row.Field<string>("星期"));
                int Period = K12.Data.Int.Parse(row.Field<string>("節次"));

                ClassEx Class = Classes.Find(x => x.ClassName.Equals(ClassName));

                if (Class != null)
                    ClassGradeYear = K12.Data.Int.GetString(Class.GradeYear);

                for (int i = 0; i < Len; i++)
                {
                    TimeTableSec vTimeTableSec = TimeTableSecs
                        .Find(x => x.WeekDay.Equals(Weekday)
                        && x.Period.Equals(Period)
                        && x.TimeTableID.Equals(TimeTableID));

                    if (vTimeTableSec != null)
                    {
                        string StartTime = vTimeTableSec.BeginTime.ToString(OutputTimeString);
                        string EndTime = vTimeTableSec.BeginTime.AddMinutes(vTimeTableSec.Duration).ToString(OutputTimeString);

                        book.Worksheets[0].Cells[RowIndex, 0].PutValue(row.Field<string>("課程名稱"));
                        book.Worksheets[0].Cells[RowIndex, 1].PutValue(row.Field<string>("學年度"));
                        book.Worksheets[0].Cells[RowIndex, 2].PutValue(row.Field<string>("學期"));
                        book.Worksheets[0].Cells[RowIndex, 3].PutValue(row.Field<string>("科目名稱"));
                        book.Worksheets[0].Cells[RowIndex, 4].PutValue(row.Field<string>("科目級別"));
                        book.Worksheets[0].Cells[RowIndex, 5].PutValue(row.Field<string>("科目簡稱"));

                        book.Worksheets[0].Cells[RowIndex, 6].PutValue(row.Field<string>("授課教師一"));
                        book.Worksheets[0].Cells[RowIndex, 7].PutValue(string.Empty);

                        book.Worksheets[0].Cells[RowIndex, 8].PutValue(row.Field<string>("授課教師二"));
                        book.Worksheets[0].Cells[RowIndex, 9].PutValue(string.Empty);

                        book.Worksheets[0].Cells[RowIndex, 10].PutValue(row.Field<string>("授課教師三"));
                        book.Worksheets[0].Cells[RowIndex, 11].PutValue(string.Empty);

                        book.Worksheets[0].Cells[RowIndex, 12].PutValue(row.Field<string>("所屬班級"));
                        book.Worksheets[0].Cells[RowIndex, 13].PutValue(ClassGradeYear);
                        book.Worksheets[0].Cells[RowIndex, 14].PutValue(row.Field<string>("場地"));
                        book.Worksheets[0].Cells[RowIndex, 15].PutValue(row.Field<string>("星期"));
                        book.Worksheets[0].Cells[RowIndex, 16].PutValue(Period);
                        book.Worksheets[0].Cells[RowIndex, 17].PutValue(StartTime);
                        book.Worksheets[0].Cells[RowIndex, 18].PutValue(EndTime);
                        book.Worksheets[0].Cells[RowIndex, 19].PutValue(row.Field<string>("註記"));

                        RowIndex++;
                    }

                    Period++;
                }
            }
            #endregion

            #region 儲存檔案
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "排課週課表";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            book.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            #endregion

            //#region 準備資料庫連線

            ////建立Sql連線
            //if (!PreparConnection())
            //    return;

            //if (Sql_Conn.State == ConnectionState.Closed)
            //{
            //    MessageBox.Show("資料庫連線未開啟!!請檢查連線資訊!!");
            //    Sql_Conn.Close();
            //    return;
            //}
            //#endregion

            //#region 載入科目
            //List<FoSubject> Subjects = new List<FoSubject>();
            //Sql_Command.CommandText = "select * from subject";
            //sdr = Sql_Command.ExecuteReader();

            //while (sdr.Read())
            //{
            //    FoSubject Subject = new FoSubject();
            //    Subject.NO = "" + sdr["NO"];
            //    Subject.NAME = "" + sdr["NAME"];
            //    Subject.SNA = "" + sdr["SNA"];
            //    Subject.PNA = "" + sdr["PNA"];
            //    Subject.LK = "" + sdr["LK"];
            //    Subjects.Add(Subject);
            //}

            //sdr.Close();
            //#endregion

            //#region 載入班級
            //List<FoClass> Classes = new List<FoClass>();
            //Sql_Command.CommandText = "select * from cla where YR='"+ MapSchoolYear +"'";
            //sdr = Sql_Command.ExecuteReader();

            //while (sdr.Read())
            //{
            //    FoClass Class = new FoClass();
            //    Class.DNO = ("" + sdr["DNO"]).Trim();
            //    Class.GRA = ("" + sdr["GRA"]).Trim();
            //    Class.CLA = ("" + sdr["CLA"]).Trim();
            //    Class.TNO = ("" + sdr["TNO"]).Trim();
            //    Class.GNO = ("" + sdr["GNO"]).Trim();
            //    Class.ClassName = ("" + sdr["CNA"]).Trim();
            //    Classes.Add(Class);
            //}

            //sdr.Close();
            //#endregion

            //#region 載入場地
            //List<FoClassroom> Classrooms = new List<FoClassroom>();
            //Sql_Command.CommandText ="select * from Room_pk where YRSM='" + MapSchoolYear + Semester + "'";
            //sdr = Sql_Command.ExecuteReader();

            //while (sdr.Read())
            //{
            //    FoClassroom Classroom = new FoClassroom();
            //    Classroom.RNO = "" + sdr["RNO"];
            //    Classroom.Name = "" + sdr["NAME"];
            //    Classrooms.Add(Classroom);
            //}

            //sdr.Close();
            //#endregion
            
            //#region 查詢教師
            //List<FoTeacher> Teachers = new List<FoTeacher>();

            //string sql = "select * from tea_pk where YRSM='" + MapSchoolYear + Semester +  "'";

            //if (sdr != null && !sdr.IsClosed)
            //    sdr.Close();

            //Sql_Command.CommandText = sql;
            //sdr = Sql_Command.ExecuteReader();
            //#endregion

            //Workbook book = new Workbook();

            //book.Worksheets.Add();
            //book.Worksheets.Add();
            //book.Worksheets.Add();

            //book.Worksheets[0].Name = "週課表";
            //book.Worksheets[0].Cells[0, 0].PutValue("課程名稱");
            //book.Worksheets[0].Cells[0, 1].PutValue("學年度");
            //book.Worksheets[0].Cells[0, 2].PutValue("學期");
            //book.Worksheets[0].Cells[0, 3].PutValue("科目名稱");
            //book.Worksheets[0].Cells[0, 4].PutValue("科目級別");
            //book.Worksheets[0].Cells[0, 5].PutValue("科目簡稱");

            //book.Worksheets[0].Cells[0, 6].PutValue("授課教師一");
            //book.Worksheets[0].Cells[0, 7].PutValue("授課教師一代碼");

            //book.Worksheets[0].Cells[0, 8].PutValue("授課教師二");
            //book.Worksheets[0].Cells[0, 9].PutValue("授課教師二代碼");

            //book.Worksheets[0].Cells[0, 10].PutValue("授課教師三");
            //book.Worksheets[0].Cells[0, 11].PutValue("授課教師三代碼");

            //book.Worksheets[0].Cells[0, 12].PutValue("所屬班級");
            //book.Worksheets[0].Cells[0, 13].PutValue("班級年級");
            //book.Worksheets[0].Cells[0, 14].PutValue("場地");
            //book.Worksheets[0].Cells[0, 15].PutValue("星期");
            //book.Worksheets[0].Cells[0, 16].PutValue("節次");
            //book.Worksheets[0].Cells[0, 17].PutValue("開始時間");
            //book.Worksheets[0].Cells[0, 18].PutValue("結束時間");
            //book.Worksheets[0].Cells[0, 19].PutValue("註記");

            //book.Worksheets[1].Name = "教師不調代時段";
            //book.Worksheets[1].Cells[0, 0].PutValue("學年度");
            //book.Worksheets[1].Cells[0, 1].PutValue("學期");
            //book.Worksheets[1].Cells[0, 2].PutValue("教師姓名");
            //book.Worksheets[1].Cells[0, 3].PutValue("星期");
            //book.Worksheets[1].Cells[0, 4].PutValue("節次");
            //book.Worksheets[1].Cells[0, 5].PutValue("開始時間");
            //book.Worksheets[1].Cells[0, 6].PutValue("結束時間");
            //book.Worksheets[1].Cells[0, 7].PutValue("不調代描述");

            //book.Worksheets[2].Name = "教師";
            //book.Worksheets[2].Cells[0, 0].PutValue("教師姓名");
            //book.Worksheets[2].Cells[0, 1].PutValue("教師暱稱");
            //book.Worksheets[2].Cells[0, 2].PutValue("教師代碼");
            //book.Worksheets[2].Cells[0, 3].PutValue("教學專長");
            //book.Worksheets[2].Cells[0, 4].PutValue("註記");

            //book.Worksheets[3].Name = "班級";
            //book.Worksheets[3].Cells[0, 0].PutValue("班級名稱");
            //book.Worksheets[3].Cells[0, 1].PutValue("班級年級");
            //book.Worksheets[3].Cells[0, 2].PutValue("班級代碼");
            //book.Worksheets[3].Cells[0, 3].PutValue("導師姓名");
            
            //int RowIndex = 1;
            //int TeacherBusyRowIndex = 1;
            //int TeahcerIndex = 1;

            //#region 假如有找到教師
            //while (sdr.Read())
            //{
            //    FoTeacher Teacher = new FoTeacher();

            //    string TeacherNo = ("" + sdr["TNO"]).Trim();
            //    string TeacherName = ("" + sdr["NAME"]).Trim();
            //    book.Worksheets[2].Cells[TeahcerIndex, 0].PutValue(TeacherName);
            //    book.Worksheets[2].Cells[TeahcerIndex, 2].PutValue(TeacherNo);

            //    Teacher.TNO = TeacherNo;
            //    Teacher.NAME = TeacherName;

            //    Teachers.Add(Teacher);

            //    TeahcerIndex++;

            //    for (int i = 1; i <= 6; i++)
            //    {
            //        for (int j = 1; j <= 9; j++)
            //        {
            //            string SubjectNo = ("" + sdr["C" + i + j]).Trim();
            //            FoSubject vSubject = Subjects.Find(x => x.NO.Equals(SubjectNo));
            //            string SubjectName = vSubject != null ? vSubject.NAME.Trim() : string.Empty;
            //            string SubjectAliasName = vSubject != null ? vSubject.SNA.Trim() : string.Empty;

            //            string ClassNo = ("" + sdr["S" + i + j]).Trim();
            //            FoClass vClass = Classes.Find(x => x.ClassCode.Equals(ClassNo));
            //            string ClassName = vClass != null ? vClass.ClassName.Trim() : string.Empty;
            //            string ClassGradeYear = vClass != null ? vClass.GRA.Trim() : string.Empty;

            //            string ClassroomNo = ("" + sdr["R" + i + j]).Trim();
            //            FoClassroom vClassroom = Classrooms.Find(x => x.RNO.Equals(ClassroomNo));
            //            string ClassroomName = vClassroom != null ? vClassroom.Name.Trim() : string.Empty;

            //            Tuple<string,string> PeriodStartEndTime = GetPeriodStartEndTime(""+j);

            //            string CourseName = SubjectName + " " + ClassName;

            //            if (!string.IsNullOrEmpty(SubjectName))
            //            {
            //                if (SubjectName.Equals("導師開會") || SubjectName.Equals("不排課"))
            //                {
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 0].PutValue(SchoolYear);
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 1].PutValue(Semester);

            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 2].PutValue(TeacherName);
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 3].PutValue(i);
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 4].PutValue(j);
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 5].PutValue(PeriodStartEndTime.Item1);
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 6].PutValue(PeriodStartEndTime.Item2);
            //                    book.Worksheets[1].Cells[TeacherBusyRowIndex, 7].PutValue(SubjectName);
            //                    TeacherBusyRowIndex++;
            //                }
            //                else
            //                {
            //                    book.Worksheets[0].Cells[RowIndex, 0].PutValue(CourseName);
            //                    book.Worksheets[0].Cells[RowIndex, 1].PutValue(SchoolYear);
            //                    book.Worksheets[0].Cells[RowIndex, 2].PutValue(Semester);
            //                    book.Worksheets[0].Cells[RowIndex, 3].PutValue(SubjectName);
            //                    book.Worksheets[0].Cells[RowIndex, 4].PutValue(string.Empty);
            //                    book.Worksheets[0].Cells[RowIndex, 5].PutValue(SubjectAliasName);
                                
            //                    book.Worksheets[0].Cells[RowIndex, 6].PutValue(TeacherName);
            //                    book.Worksheets[0].Cells[RowIndex, 7].PutValue(TeacherNo);

            //                    book.Worksheets[0].Cells[RowIndex, 8].PutValue(string.Empty);
            //                    book.Worksheets[0].Cells[RowIndex, 9].PutValue(string.Empty);

            //                    book.Worksheets[0].Cells[RowIndex, 10].PutValue(string.Empty);
            //                    book.Worksheets[0].Cells[RowIndex, 11].PutValue(string.Empty);

            //                    book.Worksheets[0].Cells[RowIndex, 12].PutValue(ClassName);
            //                    book.Worksheets[0].Cells[RowIndex, 13].PutValue(ClassGradeYear);

            //                    book.Worksheets[0].Cells[RowIndex, 14].PutValue(ClassroomName);
            //                    book.Worksheets[0].Cells[RowIndex, 15].PutValue(i);
            //                    book.Worksheets[0].Cells[RowIndex, 16].PutValue(j);
            //                    book.Worksheets[0].Cells[RowIndex, 17].PutValue(PeriodStartEndTime.Item1);
            //                    book.Worksheets[0].Cells[RowIndex, 18].PutValue(PeriodStartEndTime.Item2);
            //                    book.Worksheets[0].Cells[RowIndex, 19].PutValue(string.Empty);
            //                    RowIndex++;
            //                }
            //            }
            //        }
            //    }
            //}
            //#endregion

            //#region 輸出班級
            //for (int i = 0; i < Classes.Count; i++)
            //{
            //    book.Worksheets[3].Cells[i + 1, 0].PutValue(Classes[i].ClassName);
            //    book.Worksheets[3].Cells[i + 1, 1].PutValue(Classes[i].GRA);
            //    book.Worksheets[3].Cells[i + 1, 2].PutValue(Classes[i].GNO);

            //    FoTeacher vTeacher = Teachers.Find(x => x.TNO.Equals(Classes[i].TNO));

            //    if (vTeacher != null)
            //        book.Worksheets[3].Cells[i + 1, 3].PutValue(vTeacher.NAME);
            //}
            //#endregion

            //book.Worksheets[0].AutoFitColumns();
            //book.Worksheets[1].AutoFitColumns();

            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.FileName = "新民排課週課表";
            //saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            //if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            //book.Save(saveFileDialog1.FileName);

            //if (new CompleteForm().ShowDialog() == DialogResult.Yes)
            //    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}