using System;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 行事曆記錄物件
    /// </summary>
    public class CalendarRecord : ICloneable
    {
        /// <summary>
        /// 無參數建構式
        /// </summary>
        public CalendarRecord()
        {
            this.Delete = string.Empty;
        }

        public CalendarRecord(CourseCalendar vRecord)
        {
            this.UID = vRecord.UID;
            this.Weekday = "" + vRecord.WeekDay;
            this.AbsenceName = vRecord.AbsenceName;
            this.Cancel = vRecord.Cancel;
            this.ClassID = K12.Data.Int.GetString(vRecord.ClassID);
            this.ClassName = vRecord.ClassName;
            this.ClassroomName = vRecord.ClassroomName;
            this.Comment = vRecord.Comment;
            this.StartDateTime = vRecord.StartDateTime;
            this.EndDateTime = vRecord.EndDateTime;
            this.ReplaceID = K12.Data.Int.GetString(vRecord.ReplaceID);
            this.ExchangeID = K12.Data.Int.GetString(vRecord.ExchangeID);
            this.Level = K12.Data.Int.GetString(vRecord.Level);
            this.Period = "" + vRecord.Period;
            this.Subject = vRecord.Subject;
            this.SubjectAlias = vRecord.SubjectAlias;
            this.TeacherID = K12.Data.Int.GetString(vRecord.TeacherID);
            this.TeacherName = vRecord.TeacherName;
            this.CourseID = K12.Data.Int.GetString(vRecord.CourseID);
            this.Lock = vRecord.Lock;
            this.ScheduleComment = vRecord.ScheduleComment;
            this.Delete = string.Empty;
        }

        /// <summary>
        /// 建構式，傳入行事曆
        /// </summary>
        /// <param name="vRecord"></param>
        public CalendarRecord(CalendarRecord vRecord)
        {
            this.AbsenceName = vRecord.AbsenceName;
            this.Cancel = vRecord.Cancel;
            this.ClassID = vRecord.ClassID;
            this.ClassName = vRecord.ClassName;
            this.ClassroomName = vRecord.ClassroomName;
            this.Comment = vRecord.Comment;
            this.EndDateTime = vRecord.EndDateTime;
            this.StartDateTime = vRecord.StartDateTime;
            this.ExchangeID = vRecord.ExchangeID;
            this.Level = vRecord.Level;
            this.Period = vRecord.Period;
            this.ReplaceID = vRecord.ReplaceID;
            this.Subject = vRecord.Subject;
            this.TeacherID = vRecord.TeacherID;
            this.TeacherName = vRecord.TeacherName;
            this.Weekday = vRecord.Weekday;
            this.CourseID = vRecord.CourseID;
            this.ScheduleComment = vRecord.ScheduleComment;
            this.Lock = vRecord.Lock;
            this.Delete = vRecord.Delete;
        }

        public CalendarRecord(XElement Element) : this(Element,false)
        {
            
        }

        public override string ToString()
        {
            return "日期：" + StartDateTime.ToShortDateString() +
                   "星期：" + Weekday +
                   "節次：" + Period +
                   "教師：" + TeacherName +
                   "班級：" + ClassName +
                   "科目：" + FullSubject;
        }

        /// <summary>
        /// 輸出成Xml
        /// </summary>
        /// <returns></returns>
        public XElement ToXml()
        {
            XElement Element = new XElement("Calendar");

            Element.Add(new XElement("Uid",UID));
            Element.Add(new XElement("CourseID", CourseID));
            Element.Add(new XElement("TeacherID", TeacherID));
            Element.Add(new XElement("TeacherName", TeacherName));
            Element.Add(new XElement("AbsTeacherID", AbsTeacherID));
            Element.Add(new XElement("AbsTeacherName", AbsTeacherName));
            Element.Add(new XElement("ClassID", ClassID));
            Element.Add(new XElement("ClassName", ClassName));
            Element.Add(new XElement("ClassroomName", ClassroomName));
            Element.Add(new XElement("Subject", Subject));
            Element.Add(new XElement("Level", Level));
            Element.Add(new XElement("AbsenceName", AbsTeacherName));
            Element.Add(new XElement("Comment", Comment));
            Element.Add(new XElement("ScheduleComment", ScheduleComment));
            Element.Add(new XElement("Weekday", Weekday));
            Element.Add(new XElement("Period", Period));
            Element.Add(new XElement("StartDateTime",K12.Data.DateTimeHelper.ToDisplayString(StartDateTime)));
            Element.Add(new XElement("EndDateTime",K12.Data.DateTimeHelper.ToDisplayString(EndDateTime)));
            Element.Add(new XElement("ExchangeID",ExchangeID));
            Element.Add(new XElement("ReplaceID",ReplaceID));
            Element.Add(new XElement("EMailLog",EMailLog));
            Element.Add(new XElement("Lock", Lock));
            Element.Add(new XElement("Cancel",Cancel?"t":"f"));

            if (ExchangeCalendar!=null)
            {
                Element.Add(new XElement("ExUid", ExchangeCalendar.UID));
                Element.Add(new XElement("ExCourseID", ExchangeCalendar.CourseID));
                Element.Add(new XElement("ExTeacherID", ExchangeCalendar.TeacherID));
                Element.Add(new XElement("ExTeacherName", ExchangeCalendar.TeacherName));
                Element.Add(new XElement("ExClassID", ExchangeCalendar.ClassID));
                Element.Add(new XElement("ExClassName", ExchangeCalendar.ClassName));
                Element.Add(new XElement("ExClassroomName", ExchangeCalendar.ClassroomName));
                Element.Add(new XElement("ExSubject", ExchangeCalendar.Subject));
                Element.Add(new XElement("ExLevel", ExchangeCalendar.Level));
                Element.Add(new XElement("ExAbsenceName", ExchangeCalendar.AbsenceName));
                Element.Add(new XElement("ExComment", ExchangeCalendar.Comment));
                Element.Add(new XElement("ExScheduleComment", ExchangeCalendar.ScheduleComment));
                Element.Add(new XElement("ExWeekday", ExchangeCalendar.Weekday));
                Element.Add(new XElement("ExPeriod", ExchangeCalendar.Period));
                Element.Add(new XElement("ExStartDateTime", K12.Data.DateTimeHelper.ToDisplayString(StartDateTime)));
                Element.Add(new XElement("ExEndDateTime", K12.Data.DateTimeHelper.ToDisplayString(EndDateTime)));
                Element.Add(new XElement("ExExchangeID", ExchangeCalendar.ExchangeID));
                Element.Add(new XElement("ExReplaceID", ExchangeCalendar.ReplaceID));
                Element.Add(new XElement("EMailLog", ExchangeCalendar.EMailLog));
                Element.Add(new XElement("ExLock", ExchangeCalendar.Lock));
                Element.Add(new XElement("ExCancel", ExchangeCalendar.Cancel ? "t" : "f"));
            }

            return Element; 
        }

        /// <summary>
        /// 建構式，傳入XElement做為參數
        /// </summary>
        /// <param name="Element"></param>
        public CalendarRecord(XElement Element,bool ContainsExchange)
        {
            UID = Element.Element("Uid").Value;

            CourseID = Element.Element("CourseID").Value;
            TeacherID = Element.Element("TeacherID").Value;
            TeacherName = Element.Element("TeacherName").Value;

            AbsTeacherID = Element.ElementText("AbsTeacherID");
            AbsTeacherName = Element.ElementText("AbsTeacherName");

            ClassID = Element.Element("ClassID").Value;
            ClassName = Element.Element("ClassName").Value;

            ClassroomName = Element.Element("ClassroomName").Value;

            Subject = Element.Element("Subject").Value;
            Level = Element.Element("Level").Value;

            AbsenceName = Element.Element("AbsenceName").Value;
            Lock = Element.Element("Lock").Value;
            Comment = Element.Element("Comment").Value;
            ScheduleComment = Element.Element("ScheduleComment").Value;

            Weekday = Element.Element("Weekday").Value;
            Period = Element.Element("Period").Value;

            StartDateTime = K12.Data.DateTimeHelper.ParseDirect(Element.Element("StartDateTime").Value);
            EndDateTime = K12.Data.DateTimeHelper.ParseDirect(Element.Element("EndDateTime").Value);

            ExchangeID = Element.Element("ExchangeID").Value;
            ReplaceID = Element.Element("ReplaceID").Value;

            EMailLog = Element.ElementText("EMailLog");

            Cancel = Element.Element("Cancel").Value.Equals("t") ? true : false;
            ExchangeCalendar = null;
            Delete = string.Empty;

            LastUpdate = K12.Data.DateTimeHelper.Parse(Element.ElementText("LastUpdate"));

            if (ContainsExchange)
            {
                ExchangeCalendar = new CalendarRecord();

                ExchangeCalendar.UID = Element.Element("ExUid").Value;

                ExchangeCalendar.CourseID = Element.Element("ExCourseID").Value;
                ExchangeCalendar.TeacherID = Element.Element("ExTeacherID").Value;
                ExchangeCalendar.TeacherName = Element.Element("ExTeacherName").Value;

                //AbsTeacherID = Element.ElementText("AbsTeacherID");
                //AbsTeacherName = Element.ElementText("AbsTeacherName");

                ExchangeCalendar.ClassID = Element.Element("ExClassID").Value;
                ExchangeCalendar.ClassName = Element.Element("ExClassName").Value;

                ExchangeCalendar.ClassroomName = Element.Element("ExClassroomName").Value;

                ExchangeCalendar.Subject = Element.Element("ExSubject").Value;
                ExchangeCalendar.Level = Element.Element("ExLevel").Value;

                ExchangeCalendar.AbsenceName = Element.Element("ExAbsenceName").Value;
                ExchangeCalendar.Lock = Element.Element("ExLock").Value;
                ExchangeCalendar.Comment = Element.Element("ExComment").Value;
                ExchangeCalendar.ScheduleComment = Element.Element("ExScheduleComment").Value;

                ExchangeCalendar.Weekday = Element.Element("ExWeekday").Value;
                ExchangeCalendar.Period = Element.Element("ExPeriod").Value;

                ExchangeCalendar.StartDateTime = K12.Data.DateTimeHelper.ParseDirect(Element.Element("ExStartDateTime").Value);
                ExchangeCalendar.EndDateTime = K12.Data.DateTimeHelper.ParseDirect(Element.Element("ExEndDateTime").Value);

                ExchangeCalendar.ExchangeID = Element.Element("ExExchangeID").Value;
                ExchangeCalendar.ReplaceID = Element.Element("ExReplaceID").Value;
                ExchangeCalendar.EMailLog = Element.ElementText("EMailLog");

                ExchangeCalendar.Cancel = Element.Element("ExCancel").Value.Equals("t") ? true : false;

                ExchangeCalendar.LastUpdate = K12.Data.DateTimeHelper.Parse(Element.ElementText("ExLastUpdate"));
            }
        }

        /// <summary>
        /// 調課行事曆
        /// </summary>
        public CalendarRecord ExchangeCalendar { get; set; }

        /// <summary>
        /// 系統紀錄編號
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// 課程系統編號
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// 教師系統編號
        /// </summary>
        public string TeacherID { get; set; }

        /// <summary>
        /// 教師姓名
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// 請假教師系統編號
        /// </summary>
        public string AbsTeacherID { get; set; }

        /// <summary>
        /// 請假教師姓名
        /// </summary>
        public string AbsTeacherName { get; set; }

        /// <summary>
        /// 班級系統編號
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 班級名稱
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 場地名稱
        /// </summary>
        public string ClassroomName { get; set; }

        /// <summary>
        /// 科目名稱
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 科目別名
        /// </summary>
        public string SubjectAlias { get; set; }

        /// <summary>
        /// 科目級別
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 科目全名
        /// </summary>
        public string FullSubject
        {
            get
            {
                switch(Level)
                {
                   case "1":return Subject +" Ⅰ";
                   case "2": return Subject + " Ⅱ";
                   case "3": return Subject + " Ⅲ";
                   case "4": return Subject + " Ⅳ";
                   case "5": return Subject + " Ⅴ";
                   case "6": return Subject + " Ⅵ";
                   case "7": return Subject + " Ⅶ";
                   case "8": return Subject + " Ⅷ";
                   case "9": return Subject + " Ⅸ";
                   case "10": return Subject + " Ⅹ";
                   default: return Subject + " " + Level;
                }
            }
        }

        /// <summary>
        /// 假別名稱
        /// </summary>
        public string AbsenceName { get; set; }

        /// <summary>
        /// 註解
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 排課註解
        /// </summary>
        public string ScheduleComment { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string Weekday { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string DisplayWeekday
        {
            get
            {
                switch (Weekday)
                {
                    case "1": return "一";
                    case "2": return "二";
                    case "3": return "三";
                    case "4": return "四";
                    case "5": return "五";
                    case "6": return "六";
                    case "7": return "日";
                    default: return this.Weekday;
                }
            }
        }

        /// <summary>
        /// 節次
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date
        {
            get { return StartDateTime.ToShortDateString(); }
        }

        /// <summary>
        /// 月日顯示
        /// </summary>
        public string MonthDay
        {
            get { return StartDateTime.ToString("M/d"); }
        }

        /// <summary>
        /// 開始日期時間
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 結束日期時間
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? LastUpdate { get; set; }

        /// <summary>
        /// 持續分鐘
        /// </summary>
        public int Duration 
        {
            get
            {
                TimeSpan ts = EndDateTime.Subtract(StartDateTime);
                return (int)ts.TotalMinutes;
            }
        }

        /// <summary>
        /// 調課系統編號
        /// </summary>
        public string ExchangeID { get; set; }

        /// <summary>
        /// 代課系統編號
        /// </summary>
        public string ReplaceID { get; set; }

        /// <summary>
        /// 電子郵件發送記錄
        /// </summary>
        public string EMailLog { get; set; }

        /// <summary>
        /// 鎖定
        /// </summary>
        public string Lock { get; set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// 是否為刪除的記錄
        /// </summary>
        public string Delete { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string Status { get; set; }

        #region ICloneable 成員
        public object Clone()
        {
            CalendarRecord record = new CalendarRecord(this);

            return record;
        }
        #endregion
    }
}