using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Aspose.Cells;
using FISCA.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 批次建立週課程分段
    /// </summary>
    public partial class frmFoxproCreateWeekCourseSection : FISCA.Presentation.Controls.BaseForm
    {
        private string OutputTimeString = "HH:mm";
        private OleDbConnection Sql_Conn = new OleDbConnection();
        private OleDbCommand Sql_Command = new OleDbCommand();
        private OleDbDataReader sdr;

        private List<SchoolYearSemesterDate> mSchoolSemesterDates;
        private SchoolYearSemesterDate mSelectSchoolYearSemester;
        private AccessHelper mUDTHelper = Utility.AccessHelper;
        private QueryHelper mQueryHelper = Utility.QueryHelper;
        private const int PackageSize = 500;

        private List<FoSysset> Syssets = new List<FoSysset>();

        /// <summary>
        /// 建構式
        /// </summary>
        public frmFoxproCreateWeekCourseSection()
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

        private string GetTime(string Time)
        {
            try
            {
                string[] Values = Time.Split(new char[] { '：' });

                if (Values.Length.Equals(2))
                {
                    DateTime vDateTime = new DateTime(1900, 1, 1, int.Parse(Values[0]), int.Parse(Values[1]), 0);

                    string result = vDateTime.ToString(OutputTimeString);

                    return result;
                }
            }
            catch
            {
                return "時間解析有誤！";
            }

            return "時間解析有誤！";
        }

        private Tuple<string, string> GetTime(string StartName,string EndName)
        {
            FoSysset foStart = Syssets.Find(x => x.Name.Equals(StartName));
            FoSysset foEnd = Syssets.Find(x => x.Name.Equals(EndName));

            if ((foStart != null) && (foEnd != null))
            {
                try
                {
                    foStart.Value.Split(new char[] { '：' });

                    string StartTime = GetTime(foStart.Value);
                    string EndTime = GetTime(foEnd.Value);

                    return new Tuple<string, string>(StartTime, EndTime);
                }
                catch
                {
                    return new Tuple<string, string>("時間解析有誤！", "時間解析有誤！");
                }
            }
            else
                return new Tuple<string, string>("時間解析有誤！", "時間解析有誤！");
        }

        public Tuple<string, string> GetPeriodStartEndTime(string Period)
        {
            string strStart = string.Empty;
            string strEnd = string.Empty;

            switch(Period)
            {
                case "1":
                    return GetTime("第一節起始時間", "第一節結束時間");
                case "2":
                    return GetTime("第二節起始時間", "第二節結束時間");
                case "3":
                    return GetTime("第三節起始時間", "第三節結束時間");
                case "4":
                    return GetTime("第四節起始時間", "第四節結束時間");
                case "5":
                    return GetTime("第五節起始時間", "第五節結束時間");
                case "6":
                    return GetTime("第六節起始時間", "第六節結束時間");
                case "7":
                    return GetTime("第七節起始時間", "第七節結束時間");
                case "8":
                    return GetTime("第八節起始時間", "第八節結束時間");
                case "9":
                    return GetTime("第九節起始時間", "第九節結束時間");
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
            #region 準備資料庫連線
            string SchoolYear = "" + cmbSchoolYear.SelectedItem;
            string MapSchoolYear = SchoolYear.Length > 2 ? SchoolYear.Substring(1, 2) : SchoolYear;

            string Semester = "" + cmbSemster.SelectedItem;

            //建立Sql連線
            if (!PreparConnection())
                return;

            if (Sql_Conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("資料庫連線未開啟!!請檢查連線資訊!!");
                Sql_Conn.Close();
                return;
            }
            #endregion

            #region 載入節次時間設定
            Syssets = new List<FoSysset>();

            Sql_Command.CommandText = "select * from sysset";
            sdr = Sql_Command.ExecuteReader();

            while (sdr.Read())
            {
                FoSysset Sysset = new FoSysset();
                Sysset.Name = ("" + sdr["Syscna"]).Trim();
                Sysset.Value = ("" + sdr["Sysval"]).Trim();

                Syssets.Add(Sysset);
            }

            sdr.Close();
            #endregion

            #region 載入科目
            List<FoSubject> Subjects = new List<FoSubject>();
            Sql_Command.CommandText = "select * from subject";
            sdr = Sql_Command.ExecuteReader();

            while (sdr.Read())
            {
                FoSubject Subject = new FoSubject();
                Subject.NO = "" + sdr["NO"];
                Subject.NAME = "" + sdr["NAME"];
                Subject.SNA = "" + sdr["SNA"];
                Subject.PNA = "" + sdr["PNA"];
                Subject.LK = "" + sdr["LK"];
                Subjects.Add(Subject);
            }

            sdr.Close();
            #endregion

            #region 載入班級
            List<FoClass> Classes = new List<FoClass>();
            Sql_Command.CommandText = "select * from cla where YR='"+ MapSchoolYear +"'";
            sdr = Sql_Command.ExecuteReader();

            while (sdr.Read())
            {
                

                FoClass Class = new FoClass();
                Class.DNO = ("" + sdr["DNO"]).Trim();
                Class.GRA = ("" + sdr["GRA"]).Trim();
                Class.CLA = ("" + sdr["CLA"]).Trim();
                Class.TNO = ("" + sdr["TNO"]).Trim();
                Class.GNO = ("" + sdr["GNO"]).Trim();
                Class.ClassName = ("" + sdr["CNA"]).Trim();
                Classes.Add(Class);
            }

            sdr.Close();
            #endregion

            #region 載入場地
            List<FoClassroom> Classrooms = new List<FoClassroom>();
            Sql_Command.CommandText ="select * from Room_pk where YRSM='" + MapSchoolYear + Semester + "'";
            sdr = Sql_Command.ExecuteReader();

            while (sdr.Read())
            {
                FoClassroom Classroom = new FoClassroom();
                Classroom.RNO = "" + sdr["RNO"];
                Classroom.Name = "" + sdr["NAME"];
                Classrooms.Add(Classroom);
            }

            sdr.Close();
            #endregion
            
            #region 查詢教師
            List<FoTeacher> Teachers = new List<FoTeacher>();

            string sql = "select * from tea_pk where YRSM='" + MapSchoolYear + Semester +  "'";

            if (sdr != null && !sdr.IsClosed)
                sdr.Close();

            Sql_Command.CommandText = sql;
            sdr = Sql_Command.ExecuteReader();
            #endregion

            Workbook book = new Workbook();

            book.Worksheets.Add();
            book.Worksheets.Add();
            book.Worksheets.Add();
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

            book.Worksheets[2].Name = "教師";
            book.Worksheets[2].Cells[0, 0].PutValue("教師姓名");
            book.Worksheets[2].Cells[0, 1].PutValue("教師暱稱");
            book.Worksheets[2].Cells[0, 2].PutValue("教師代碼");
            book.Worksheets[2].Cells[0, 3].PutValue("教學專長");
            book.Worksheets[2].Cells[0, 4].PutValue("註記");

            book.Worksheets[3].Name = "班級";
            book.Worksheets[3].Cells[0, 0].PutValue("班級名稱");
            book.Worksheets[3].Cells[0, 1].PutValue("班級年級");
            book.Worksheets[3].Cells[0, 2].PutValue("班級代碼");
            book.Worksheets[3].Cells[0, 3].PutValue("註記");

            book.Worksheets[4].Name = "班級不調代時段";
            book.Worksheets[4].Cells[0, 0].PutValue("學年度");
            book.Worksheets[4].Cells[0, 1].PutValue("學期");
            book.Worksheets[4].Cells[0, 2].PutValue("班級名稱");
            book.Worksheets[4].Cells[0, 3].PutValue("星期");
            book.Worksheets[4].Cells[0, 4].PutValue("節次");
            book.Worksheets[4].Cells[0, 5].PutValue("開始時間");
            book.Worksheets[4].Cells[0, 6].PutValue("結束時間");
            book.Worksheets[4].Cells[0, 7].PutValue("不調代描述");
            
            int RowIndex = 1;
            int TeacherBusyRowIndex = 1;
            int TeahcerIndex = 1;

            #region 假如有找到教師
            while (sdr.Read())
            {
                FoTeacher Teacher = new FoTeacher();

                string TeacherNo = ("" + sdr["TNO"]).Trim();
                string TeacherName = ("" + sdr["NAME"]).Trim();
                book.Worksheets[2].Cells[TeahcerIndex, 0].PutValue(TeacherName);
                book.Worksheets[2].Cells[TeahcerIndex, 2].PutValue(TeacherNo);

                Teacher.TNO = TeacherNo;
                Teacher.NAME = TeacherName;

                Teachers.Add(Teacher);

                TeahcerIndex++;

                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        string SubjectNo = ("" + sdr["C" + i + j]).Trim();
                        FoSubject vSubject = Subjects.Find(x => x.NO.Equals(SubjectNo));
                        string SubjectName = vSubject != null ? vSubject.NAME.Trim() : string.Empty;
                        string SubjectAliasName = vSubject != null ? vSubject.SNA.Trim() : string.Empty;

                        string ClassNo = ("" + sdr["S" + i + j]).Trim();
                        FoClass vClass = Classes.Find(x => x.ClassCode.Equals(ClassNo));
                        string ClassName = vClass != null ? vClass.ClassName.Trim() : string.Empty;
                        string ClassGradeYear = vClass != null ? vClass.GRA.Trim() : string.Empty;

                        string ClassroomNo = ("" + sdr["R" + i + j]).Trim();
                        FoClassroom vClassroom = Classrooms.Find(x => x.RNO.Equals(ClassroomNo));
                        string ClassroomName = vClassroom != null ? vClassroom.Name.Trim() : string.Empty;

                        Tuple<string,string> PeriodStartEndTime = GetPeriodStartEndTime(""+j);

                        string CourseName = SubjectName + " " + ClassName;

                        if (!string.IsNullOrEmpty(SubjectName))
                        {
                            if (string.IsNullOrWhiteSpace(ClassName) && 
                                string.IsNullOrWhiteSpace(ClassGradeYear))
                            {
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 0].PutValue(SchoolYear);
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 1].PutValue(Semester);

                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 2].PutValue(TeacherName);
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 3].PutValue(i);
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 4].PutValue(j);
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 5].PutValue(PeriodStartEndTime.Item1);
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 6].PutValue(PeriodStartEndTime.Item2);
                                book.Worksheets[1].Cells[TeacherBusyRowIndex, 7].PutValue(SubjectName);
                                TeacherBusyRowIndex++;
                            }
                            else
                            {
                                book.Worksheets[0].Cells[RowIndex, 0].PutValue(CourseName);
                                book.Worksheets[0].Cells[RowIndex, 1].PutValue(SchoolYear);
                                book.Worksheets[0].Cells[RowIndex, 2].PutValue(Semester);
                                book.Worksheets[0].Cells[RowIndex, 3].PutValue(SubjectName);
                                book.Worksheets[0].Cells[RowIndex, 4].PutValue(string.Empty);
                                book.Worksheets[0].Cells[RowIndex, 5].PutValue(SubjectAliasName);
                                
                                book.Worksheets[0].Cells[RowIndex, 6].PutValue(TeacherName);
                                book.Worksheets[0].Cells[RowIndex, 7].PutValue(TeacherNo);

                                book.Worksheets[0].Cells[RowIndex, 8].PutValue(string.Empty);
                                book.Worksheets[0].Cells[RowIndex, 9].PutValue(string.Empty);

                                book.Worksheets[0].Cells[RowIndex, 10].PutValue(string.Empty);
                                book.Worksheets[0].Cells[RowIndex, 11].PutValue(string.Empty);

                                book.Worksheets[0].Cells[RowIndex, 12].PutValue(ClassName);
                                book.Worksheets[0].Cells[RowIndex, 13].PutValue(ClassGradeYear);

                                book.Worksheets[0].Cells[RowIndex, 14].PutValue(ClassroomName);
                                book.Worksheets[0].Cells[RowIndex, 15].PutValue(i);
                                book.Worksheets[0].Cells[RowIndex, 16].PutValue(j);
                                book.Worksheets[0].Cells[RowIndex, 17].PutValue(PeriodStartEndTime.Item1);
                                book.Worksheets[0].Cells[RowIndex, 18].PutValue(PeriodStartEndTime.Item2);
                                book.Worksheets[0].Cells[RowIndex, 19].PutValue(string.Empty);
                                RowIndex++;
                            }
                        }
                    }
                }
            }

            sdr.Close();

            //找出班級不調代時段
            Sql_Command.CommandText = "select * from cla_pk where YRSM='" + MapSchoolYear + Semester +  "'";
            sdr = Sql_Command.ExecuteReader();

            int ClassBusyRowIndex = 1;

            while (sdr.Read())
            {
                string ClassName = ("" + sdr["NAME"]).Trim();

                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        string SubjectNo = ("" + sdr["C" + i + j]);

                        if (!string.IsNullOrWhiteSpace(SubjectNo))
                        {
                            SubjectNo = SubjectNo.Trim();
                            FoSubject vSubject = Subjects.Find(x => x.NO.Equals(SubjectNo));
                            string SubjectName = vSubject != null ? vSubject.NAME.Trim() : string.Empty;
                            string SubjectAliasName = vSubject != null ? vSubject.SNA.Trim() : string.Empty;

                            string TeacherNo = ("" + sdr["S" + i + j]).Trim();
                            //FoClass vClass = Classes.Find(x => x.ClassCode.Equals(ClassNo));
                            //string ClassName = vClass != null ? vClass.ClassName.Trim() : string.Empty;
                            //string ClassGradeYear = vClass != null ? vClass.GRA.Trim() : string.Empty;

                            string ClassroomNo = ("" + sdr["R" + i + j]).Trim();
                            FoClassroom vClassroom = Classrooms.Find(x => x.RNO.Equals(ClassroomNo));
                            string ClassroomName = vClassroom != null ? vClassroom.Name.Trim() : string.Empty;

                            Tuple<string, string> PeriodStartEndTime = GetPeriodStartEndTime("" + j);

                            string CourseName = SubjectName + " " + ClassName;

                            if (!string.IsNullOrEmpty(SubjectName))
                            {
                                if (string.IsNullOrWhiteSpace(TeacherNo))
                                {
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 0].PutValue(SchoolYear);
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 1].PutValue(Semester);

                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 2].PutValue(ClassName);
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 3].PutValue(i);
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 4].PutValue(j);
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 5].PutValue(PeriodStartEndTime.Item1);
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 6].PutValue(PeriodStartEndTime.Item2);
                                    book.Worksheets[4].Cells[ClassBusyRowIndex, 7].PutValue(SubjectName);
                                    ClassBusyRowIndex++;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 輸出班級
            for (int i = 0; i < Classes.Count; i++)
            {
                book.Worksheets[3].Cells[i + 1, 0].PutValue(Classes[i].ClassName);
                book.Worksheets[3].Cells[i + 1, 1].PutValue(Classes[i].GRA);
                book.Worksheets[3].Cells[i + 1, 2].PutValue(Classes[i].DNO + Classes[i].GRA + Classes[i].CLA);

                FoTeacher vTeacher = Teachers.Find(x => x.TNO.Equals(Classes[i].TNO));

                if (vTeacher != null)
                    book.Worksheets[3].Cells[i + 1, 3].PutValue(vTeacher.NAME);
            }
            #endregion

            book.Worksheets[0].AutoFitColumns();
            book.Worksheets[1].AutoFitColumns();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "新民排課週課表";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            book.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}