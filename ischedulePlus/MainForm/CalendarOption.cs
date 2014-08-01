using System.Collections.Generic;
using DevComponents.DotNetBar;

namespace ischedulePlus
{

    /// <summary>
    /// 行事曆選項
    /// </summary>
    public class CalendarOption
    {
        private static List<ButtonItem> mExtraButtons = null;

        public static List<ButtonItem> PrintExtraButtons
        {
            get
            {
                if (mExtraButtons == null)
                    mExtraButtons = new List<ButtonItem>();

                return mExtraButtons;
            }
        }

        /// <summary>
        /// 行事曆類別
        /// </summary>
        public CalendarType Type { get; set; }

        /// <summary>
        /// 出現教師
        /// </summary>
        public bool IsTeacher { get; set; }

        /// <summary>
        /// 出現場地
        /// </summary>
        public bool IsClassroom { get; set; }

        /// <summary>
        /// 出現班級
        /// </summary>
        public bool IsClass { get; set; }

        /// <summary>
        /// 出現科目
        /// </summary>
        public bool IsSubject { get; set; }

        /// <summary>
        /// 出現科目簡稱
        /// </summary>
        public bool IsSubjectAlias { get; set; }

        #region 教師、班級及場地選項獨立且為唯一，不需要運用事件進行同步
        /// <summary>
        /// 教師選項
        /// </summary>
        private static CalendarOption vTeacherOption = null;

        /// <summary>
        /// 班級選項
        /// </summary>
        private static CalendarOption vClassOption = null;

        /// <summary>
        /// 場地選項
        /// </summary>
        private static CalendarOption vClassroomOption = null;
        #endregion

        /// <summary>
        /// 儲存
        /// </summary>
        public void Save()
        {
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User[ Type + "Option"];
            config["DisplayTeacher"] = "" + IsTeacher;
            config["DisplayClass"] = "" + IsClass;
            config["DisplayClassroom"] = "" + IsClassroom;
            config["DisplaySubject"] = "" + IsSubject;
            config["DisplaySubjectAlias"] = "" + IsSubjectAlias;
            config.SaveAsync();
        }

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public CalendarOption()
        {
            IsTeacher = false;
            IsClassroom = false;
            IsClass = false;
            IsSubject = false;
            IsSubjectAlias = false;
        }

        /// <summary>
        /// 取得場地設定
        /// </summary>
        /// <returns></returns>
        public static CalendarOption GetClassroomOption()
        {
            if (vClassroomOption == null)
                vClassroomOption = new CalendarOption();

            vClassroomOption.Type = CalendarType.Classroom;
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["ClassroomOption"];
            string DisplayTeacher = config["DisplayTeacher"];
            string DisplayClass = config["DisplayClass"];
            string DisplayClassroom = config["DisplayClassroom"];
            string DisplaySubject = config["DisplaySubject"];
            string DisplaySubjectAlias = config["DisplaySubjectAlias"];

            if (string.IsNullOrWhiteSpace(DisplayTeacher))
                vClassroomOption.IsTeacher = false;
            else
                vClassroomOption.IsTeacher = DisplayTeacher.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplayClass))
                vClassroomOption.IsClass = true;
            else
                vClassroomOption.IsClass = DisplayClass.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplayClassroom))
                vClassroomOption.IsClassroom = false;
            else
                vClassroomOption.IsClassroom = DisplayClassroom.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplaySubject))
                vClassroomOption.IsSubject = true;
            else
                vClassroomOption.IsSubject = DisplaySubject.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplaySubjectAlias))
                vClassroomOption.IsSubjectAlias = false;
            else
                vClassroomOption.IsSubjectAlias = DisplaySubjectAlias.ToLower().Equals("false") ? false : true;

            return vClassroomOption;
        }

        /// <summary>
        /// 取得班級設定
        /// </summary>
        /// <returns></returns>
        public static CalendarOption GetClassOption()
        {
            if (vClassOption == null)
                vClassOption = new CalendarOption();

            vClassOption.Type = CalendarType.Class;
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["ClassOption"];
            string DisplayTeacher = config["DisplayTeacher"];
            string DisplayClass = config["DisplayClass"];
            string DisplayClassroom = config["DisplayClassroom"];
            string DisplaySubject = config["DisplaySubject"];
            string DisplaySubjectAlias = config["DisplaySubjectAlias"];

            if (string.IsNullOrWhiteSpace(DisplayTeacher))
                vClassOption.IsTeacher = true;
            else
                vClassOption.IsTeacher = DisplayTeacher.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplayClass))
                vClassOption.IsClass = false;
            else
                vClassOption.IsClass = DisplayClass.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplayClassroom))
                vClassOption.IsClassroom = false;
            else
                vClassOption.IsClassroom = DisplayClassroom.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplaySubject))
                vClassOption.IsSubject = true;
            else
                vClassOption.IsSubject = DisplaySubject.ToLower().Equals("false") ? false : true;

            if (string.IsNullOrWhiteSpace(DisplaySubjectAlias))
                vClassOption.IsSubjectAlias = false;
            else
                vClassOption.IsSubjectAlias = DisplaySubjectAlias.ToLower().Equals("false") ? false : true;

            return vClassOption;
        }

        /// <summary>
        /// 取得教師設定
        /// </summary>
        /// <returns></returns>
        public static CalendarOption GetTeacherOption()
        {
            if (vTeacherOption == null)
                vTeacherOption = new CalendarOption();

            vTeacherOption.Type = CalendarType.Teacher;
                Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["TeacherOption"];
                string DisplayTeacher = config["DisplayTeacher"];
                string DisplayClass = config["DisplayClass"];
                string DisplayClassroom = config["DisplayClassroom"]; 
                string DisplaySubject = config["DisplaySubject"]; 
                string DisplaySubjectAlias = config["DisplaySubjectAlias"];

                if (string.IsNullOrWhiteSpace(DisplayTeacher))
                    vTeacherOption.IsTeacher = false;
                else
                    vTeacherOption.IsTeacher = DisplayTeacher.ToLower().Equals("false") ? false : true;

                if (string.IsNullOrWhiteSpace(DisplayClass))
                    vTeacherOption.IsClass = true;
                else
                    vTeacherOption.IsClass = DisplayClass.ToLower().Equals("false") ? false : true;

                if (string.IsNullOrWhiteSpace(DisplayClassroom))
                    vTeacherOption.IsClassroom = false;
                else
                    vTeacherOption.IsClassroom = DisplayClassroom.ToLower().Equals("false") ? false : true;

                if (string.IsNullOrWhiteSpace(DisplaySubject))
                    vTeacherOption.IsSubject = true;
                else
                    vTeacherOption.IsSubject = DisplaySubject.ToLower().Equals("false") ? false : true;

                if (string.IsNullOrWhiteSpace(DisplaySubjectAlias))
                    vTeacherOption.IsSubjectAlias = false;
                else
                    vTeacherOption.IsSubjectAlias = DisplaySubjectAlias.ToLower().Equals("false") ? false : true;

                return vTeacherOption;
        }          
    }
}