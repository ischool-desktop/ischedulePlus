using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using FISCA.Data;
using FISCA.Presentation.Controls;
using FISCA.UDT;

namespace ischedulePlus
{
    public class SchoolYearSemesterPackageDataAccess : IConfigurationDataAccess<SchoolYearSemesterPackage>
    {
        private AccessHelper mAccessHelper;
        private QueryHelper mQueryHelper;

        #region IConfigurationDataAccess<SchoolYearSemesterPackage> 成員
        /// <summary>
        /// 無參數建構式
        /// </summary>
        public SchoolYearSemesterPackageDataAccess()
        {
            mAccessHelper = Utility.AccessHelper;
            mQueryHelper = Utility.QueryHelper;
        }

        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName
        {
            get { return "學期設定"; }
        }

        /// <summary>
        /// 選出學年度學期列表
        /// </summary>
        /// <returns></returns>
        public List<string> SelectKeys()
        {
            DataTable table = mQueryHelper.Select("select schoolyear,semester from $scheduler.schoolyear_semester_date order by schoolyear desc,semester desc");

            List<string> Result = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                string SchoolYear = row.Field<string>("schoolyear");
                string Semester = row.Field<string>("semester");
                 
                Result.Add(SchoolYear + "學年度 " + Semester + "學期");
            }

            return Result;
        }

        /// <summary>
        /// 根據學年度搜尋
        /// </summary>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public List<string> Search(string SearchText)
        {
            DataTable table = mQueryHelper.Select("select schoolyear,semester from $scheduler.schoolyear_semester_date where schoolyear like '%" + SearchText + "%' order by schoolyear desc,semester desc");

            List<string> Result = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                string SchoolYear = row.Field<string>("schoolyear");
                string Semester = row.Field<string>("semester");
                Result.Add(SchoolYear + " " + Semester);
            }

            return Result;
        }

        public string Insert(string NewKey, string CopyKey)
        {
            #region 根據鍵值取得教師
            if (string.IsNullOrEmpty(NewKey))
                return "要新增的學年度學期不能為空白!";

            string[] Keys = NewKey.Split(new char[]{','});

            if (Keys.Length!=4)
                return "學年度學期資料不完整「" + Keys[0] +" " + Keys[1] +"」";

            string SchoolYear = Keys[0];
            string Semester = Keys[1];
            string strCondition = "schoolyear='" + SchoolYear + "' and semester='" + Semester + "'";

            List<SchoolYearSemesterDate> SchoolYearSemesters = mAccessHelper.Select<SchoolYearSemesterDate>(strCondition);

            if (SchoolYearSemesters.Find(x => (x.SchoolYear + " " +x.Semester).Equals(NewKey)) != null)
                return "要新增的學年度學期已存在，無法新增!";
            #endregion

            #region 新增學年度學期
            SchoolYearSemesterDate SchoolYearSemester = new SchoolYearSemesterDate();
            SchoolYearSemester.SchoolYear = SchoolYear;
            SchoolYearSemester.Semester = Semester;
            SchoolYearSemester.StartDate = K12.Data.DateTimeHelper.ParseDirect(Keys[2]);
            SchoolYearSemester.EndDate = K12.Data.DateTimeHelper.ParseDirect(Keys[3]);

            XElement elmGradeYears = new XElement("GradeYears");

            DataTable table = mQueryHelper.Select("select distinct grade_year from class order by grade_year");

            foreach (DataRow row in table.Rows)
            {
                string GradeYear = row.Field<string>("grade_year");

                if (!string.IsNullOrEmpty(GradeYear))
                {
                    XElement elmGradeYear = new XElement("GradeYear");

                    elmGradeYear.SetAttributeValue("GradeYear", GradeYear);
                    elmGradeYear.SetAttributeValue("StartDate", Keys[2]);
                    elmGradeYear.SetAttributeValue("EndDate", Keys[3]);
                    elmGradeYears.Add(elmGradeYear);
                }
            }

            SchoolYearSemester.GradeYearStartEndDate = elmGradeYears.ToString();
            SchoolYearSemester.Save();
            #endregion

            return string.Empty;
        }

        public string Update(string Key, string NewKey)
        {
            return string.Empty;
        }

        public string Delete(string Key)
        {
            #region 根據鍵值取得教師
            if (string.IsNullOrEmpty(Key))
                return "要新增的學年度學期不能為空白!";

            string[] Keys = Key.Split(new char[]{' '});

            if (Keys.Length!=2)
                return "學年度學期資料不完整「" + Keys[0] +" " + Keys[1] +"」";

            string SchoolYear = Keys[0].Replace("學年度", "");
            string Semester = Keys[1].Replace("學期", "");
            string strCondition = "schoolyear='" + SchoolYear + "' and semester='" + Semester + "'";

            List<SchoolYearSemesterDate> SchoolYearSemesters = mAccessHelper.Select<SchoolYearSemesterDate>(strCondition);

            if (SchoolYearSemesters.Count == 1)
            {
                SchoolYearSemesters[0].Deleted = true;
                SchoolYearSemesters[0].Save();
            }

            return string.Empty;
            #endregion
        }

        public SchoolYearSemesterPackage Select(string Key)
        {
            SchoolYearSemesterPackage result = new SchoolYearSemesterPackage();

           string[] Keys = Key.Split(new char[]{' '});

           if (Keys.Length == 2)
           {
               string SchoolYear = Keys[0];

               int iSchoolYear = SchoolYear.IndexOf("學年度");

               SchoolYear = SchoolYear.Substring(0, iSchoolYear);

               string Semester = Keys[1];

               int iSemester = Semester.IndexOf("學期");

               Semester = Semester.Substring(0, iSemester);

               List<SchoolYearSemesterDate> records = mAccessHelper.Select<SchoolYearSemesterDate>("schoolyear='"+ SchoolYear +"' and semester='"+ Semester +"'");

               if (records.Count == 1)
                   result.SchoolYearSemesterDate = records[0];
               else
                   return result;
           }

           return result;
        }

        public string Save(SchoolYearSemesterPackage Value)
        {
            if (Value.SchoolYearSemesterDate != null)
            {
                Value.SchoolYearSemesterDate.Save();

                List<Holiday> Holidays = new List<Holiday>();

                XElement elmHolidays = XElement.Load(new StringReader(Value.SchoolYearSemesterDate.Holidays));

                foreach (XElement elmHoliday in elmHolidays.Elements("Holiday"))
                {
                    Holiday vHoliday = new Holiday(elmHoliday);
                    Holidays.Add(vHoliday);
                }

                List<CalendarRecord> Calendars = Calendar.Instance.Find(Holidays.Select(x => x.Date).ToList());

                foreach (Holiday vHoliday in Holidays)
                {
                    if (vHoliday.Periods.Count > 0)
                    {
                        List<CalendarRecord> SelectedCalendars = Calendars.FindAll(x => x.Date.Equals(vHoliday.Date.ToShortDateString()) && !vHoliday.Periods.Contains(x.Period));
                        SelectedCalendars.ForEach(x => Calendars.Remove(x));
                    }
                }

                if (Calendars.Count > 0)
                {
                    if (MsgBox.Show("共有" + Calendars.Count + "筆課程行事曆，在假日設定中，您是否要停用？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Calendar.Instance.Cancel(Calendars, true);
                    }
                }
             }

            return string.Empty;
        }

        public List<ICommand> ExtraCommands
        {
            get 
            {
                return new List<ICommand>();
            }
        }
        #endregion
    }

    /// <summary>
    /// 假日
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 節次列表
        /// </summary>
        public List<string> Periods { get; set; }

        public Holiday(XElement element)
        {
            string strHoliday = element.Value;
            string strPeriod = element.AttributeText("Periods");

            Date = K12.Data.DateTimeHelper.ParseDirect(strHoliday);

            Periods = new List<string>();

            if (!(string.IsNullOrWhiteSpace(strPeriod) || strPeriod.Equals("整天")))
            {
                string[] strPeriods = strPeriod.Split(new char[] { ',' });

                for (int i = 0; i < strPeriods.Length; i++)
                    Periods.Add(strPeriods[i]);
            }
        }
    }
}