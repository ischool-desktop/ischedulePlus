using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using FISCA.Authentication;
using FISCA.DSAClient;

namespace ischedulePlus
{
    /// <summary>
    /// 直接存取Contract服務
    /// </summary>
    public class ContractService
    {
        private static string DefaultContractName = "CalendarService";
        private static Dictionary<string, Connection> mConnections = null;
        private static List<Timer> mTimers = null;

        /// <summary>
        /// 關閉所有連線，OK
        /// </summary>
        public static void CloseConnection()
        {
            mConnections = null;
            mTimers = null;
        }

        /// <summary>
        /// 初始化連線，OK
        /// </summary>
        public static void InitialConnection()
        {
            GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            GetConnection(DSAServices.GreeningAccessPoint, "user");
        }

        /// <summary>
        /// 用Passport連線至AccessPoint，並傳回對應的連線資訊。OK
        /// </summary>
        /// <param name="AccessPoint"></param>
        /// <returns></returns>
        public static Tuple<Connection, string> GetConnection(string AccessPoint)
        {
            return GetConnection(AccessPoint, DefaultContractName);
        }

        /// <summary>
        /// 用Passport連線至AccessPoint，並傳回對應的連線資訊；並且會放到連線區中，之後可重覆使用。OK
        /// </summary>
        /// <param name="AccessPoint"></param>
        /// <returns></returns>
        public static Tuple<Connection, string> GetConnection(string AccessPoint, string ContractName)
        {
            if (mConnections == null)
                mConnections = new Dictionary<string, Connection>();

            if (mTimers == null)
                mTimers = new List<Timer>();

            if (mConnections.ContainsKey(AccessPoint))
                return new Tuple<Connection, string>(mConnections[AccessPoint], string.Empty);

            try
            {
                #region Connection一開始會用Passport連線，之後強制使用Session連線，並定期送Request確保Session不會過期
                Connection vConnection = new Connection();
                vConnection.EnableSession = true;
                vConnection.Connect(AccessPoint, ContractName, FISCA.Authentication.DSAServices.PassportToken);

                //Timer mTimer = new Timer(x =>
                //{
                //    vConnection.SendRequest("DS.Base.Connect", new Envelope());
                //}, null, 9000 * 60, 9000 * 60);

                //mTimers.Add(mTimer);

                mConnections.Add(AccessPoint, vConnection);
                #endregion

                return new Tuple<Connection, string>(vConnection, string.Empty);
            }
            catch (Exception ve)
            {
                return new Tuple<Connection, string>(null, "無法連線至『" + AccessPoint + "』主機" + System.Environment.NewLine + "訊息：『" + ve.Message + "』");
            }
        }

        /// <summary>
        /// 送出文件，OK
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="ServiceName"></param>
        /// <param name="RequestElement"></param>
        /// <returns></returns>
        private static XElement SendRequest(Connection Conn, string ServiceName, XElement RequestElement)
        {
            try
            {
                Envelope Request = new Envelope();

                Request.Body = new XmlStringHolder(RequestElement.ToString());

                Envelope Response = Conn.CallService(ServiceName, Request);

                XElement Element = XElement.Load(new StringReader(Response.Body.XmlString));

                return Element;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 取得節次清單，OK
        /// </summary>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public static XElement PeriodList(Connection Connection)
        {
            try
            {
                XElement Request = new XElement("Request");

                XElement Response = SendRequest(Connection, "_.GetPeriodList", Request);

                return Response;
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        /// <summary>
        /// 取得假別清單，OK
        /// </summary>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public static XElement AbsenceList(Connection Connection)
        {
            try
            {
                XElement Request = new XElement("Request");

                XElement Response = SendRequest(Connection, "_.GetAbsenceList", Request);

                return Response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// 取得教師教授科目列表
        /// </summary>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public static XElement GetTeacherSubject(Connection Connection,DateTime StartDate,DateTime EndDate)
        {
            #region XML
            //<Request>
            //    <Condition>
            //        <!--以下為非必要條件-->
            //        <StartDate>2012/11/10</StartDate>
            //        <EndDate>2012/12/10</EndDate>
            //    </Condition>
            //    <!--<Pagination><StartPage>1</StartPage><PageSize>0</PageSize></Pagination>-->
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");
            Condition.Add(new XElement("StartDate",StartDate.ToShortDateString()));
            Condition.Add(new XElement("EndDate",EndDate.ToShortDateString()));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetTeacherSubjectNew", Request);

            return Response;
        }

        /// <summary>
        /// 取得時間交集的XElement
        /// </summary>
        /// <param name="StartElementName"></param>
        /// <param name="EndElementName"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        private static XElement GetIntersetcXElement(string StartElementName,string EndElementName,DateTime StartDateTime,DateTime EndDateTime)
        {
            XElement Element = new XElement("And");
            Element.Add(new XElement(StartElementName,StartDateTime.GetDateTimeString()));
            Element.Add(new XElement(EndElementName, EndDateTime.GetDateTimeString()));

            return Element;
        }

        /// <summary>
        /// 根據多筆行事曆尋找資料庫中有交集的行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Records"></param>
        /// <returns></returns>
        public static XElement GetIntersectCalendar(
            Connection Connection,
            List<string> TeacherNames,
            List<string> ClassroomNames,
            List<CalendarRecord> Records)
        {
            #region XML範例
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <Or>
            //            <Or>
            //                <And>
            //                    <ST1>2012/7/24 9:00</ST1>
            //                    <ET1>2012/7/24 18:00</ET1>
            //                </And>
            //                <And>
            //                    <ST2>2012/7/24 9:00</ST2>
            //                    <ET2>2012/7/24 18:00</ET2>
            //                </And>
            //                <And>
            //                    <ST3>2012/7/24 9:00</ST3>
            //                    <ET3>2012/7/24 18:00</ET3>
            //                </And>
            //                <And>
            //                    <ST4>2012/7/24 9:00</ST4>
            //                    <ET4>2012/7/24 18:00</ET4>
            //                </And>
            //            </Or>
            //            <Or>
            //                <And>
            //                    <ST1>2012/7/25 10:00</ST1>
            //                    <ET1>2012/7/25 11:00</ET1>
            //                </And>
            //                <And>
            //                    <ST2>2012/7/25 10:00</ST2>
            //                    <ET2>2012/7/25 11:00</ET2>
            //                </And>
            //                <And>
            //                    <ST3>2012/7/25 10:00</ST3>
            //                    <ET3>2012/7/25 11:00</ET3>
            //                </And>
            //                <And>
            //                    <ST4>2012/7/25 10:00</ST4>
            //                    <ET4>2012/7/25 11:00</ET4>
            //                </And>
            //            </Or>
            //        </Or>
            //    </Condition>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");
            XElement Condition = new XElement("Condition");
            XElement TeacherClassroomCondition = new XElement("Or");
            XElement OrRoot = new XElement("Or");
            Condition.Add(TeacherClassroomCondition);
            Condition.Add(OrRoot);
            Request.Add(Condition);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
            {
                foreach (string TeacherName in TeacherNames)
                {
                    if (!string.IsNullOrEmpty(TeacherName))
                    {
                        TeacherClassroomCondition.Add(new XElement("TeacherName", TeacherName));
                    }
                }
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassroomNames))
            {
                foreach (string ClassroomName in ClassroomNames)
                {
                    if (!string.IsNullOrEmpty(ClassroomName))
                    {
                        TeacherClassroomCondition.Add(new XElement("ClassromName", ClassroomName));
                    }
                }
            }

            foreach (CalendarRecord record in Records)
            {
                XElement OrCondition = new XElement("Or");

                OrCondition.Add(GetIntersetcXElement("ST1","ET1",record.StartDateTime,record.EndDateTime));
                OrCondition.Add(GetIntersetcXElement("ST2","ET2",record.StartDateTime,record.EndDateTime));
                OrCondition.Add(GetIntersetcXElement("ST3","ET3",record.StartDateTime,record.EndDateTime));
                OrCondition.Add(GetIntersetcXElement("ST4","ET4",record.StartDateTime,record.EndDateTime));

                OrRoot.Add(OrCondition);
            }

            XElement Response = SendRequest(Connection, "_.GetInetrsectCalendarNew", Request);

            return Response;
        }

        /// <summary>
        /// 取得交集班級忙碌時段
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="ClassNames"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static XElement GetIntersectClassBusy(
            Connection Connection,
            List<string> ClassNames,
            DateTime StartDate,
            DateTime EndDate)
        {
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <ClassName>資一甲</ClassName>
            //        <ClassName>資二丙</ClassName>
            //        <ST1>2013/8/1</ST1>
            //        <ET1>2013/8/30</ET1>
            //    </Condition>
            //</Request>

            XElement Request = new XElement("Request");
            XElement Condition = new XElement("Condition");

            Request.Add(Condition);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassNames))
            {
                foreach (string ClassName in ClassNames)
                {
                    if (!string.IsNullOrEmpty(ClassName))
                    {
                        Condition.Add(new XElement("ClassName", ClassName));
                    }
                }
            }

            Condition.Add(new XElement("ST1", StartDate.ToShortDateString()));
            Condition.Add(new XElement("ET1", EndDate.ToShortDateString()));

            XElement Response = SendRequest(Connection, "_.GetIntersectClassBusyDateNew", Request);

            return Response;
        }

        /// <summary>
        /// 取得交集教師忙碌時段
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="TeacherNames"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static XElement GetIntersectTeacherBusy(
            Connection Connection,
            List<string> TeacherNames,
            DateTime StartDate,
            DateTime EndDate)
        {
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <TeacherName>陳淑玲</TeacherName>
            //        <TeacherName>李麗娟</TeacherName>
            //        <ST1>2013/8/1</ST1>
            //        <ET1>2013/8/30</ET1>
            //    </Condition>
            //</Request>

            XElement Request = new XElement("Request");
            XElement Condition = new XElement("Condition");

            Request.Add(Condition);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
            {
                foreach (string TeacherName in TeacherNames)
                {
                    if (!string.IsNullOrEmpty(TeacherName))
                    {
                        Condition.Add(new XElement("TeacherName", TeacherName));
                    }
                }
            }

            Condition.Add(new XElement("ST1", StartDate.ToShortDateString()));
            Condition.Add(new XElement("ET1", EndDate.ToShortDateString()));

            XElement Response = SendRequest(Connection, "_.GetIntersectTeacherBusyDateNew", Request);

            return Response; 
        }

        /// <summary>
        /// 根據多筆行事曆尋找資料庫中有交集的教師不調代教師
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Records"></param>
        /// <returns></returns>
        public static XElement GetIntersectTeacherBusy(
            Connection Connection,
            List<string> TeacherNames, 
            List<CalendarRecord> Records)
        {
            #region XML範例
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <Or>
            //            <Or>
            //                <And>
            //                    <ST1>2012/7/24 9:00</ST1>
            //                    <ET1>2012/7/24 18:00</ET1>
            //                </And>
            //                <And>
            //                    <ST2>2012/7/24 9:00</ST2>
            //                    <ET2>2012/7/24 18:00</ET2>
            //                </And>
            //                <And>
            //                    <ST3>2012/7/24 9:00</ST3>
            //                    <ET3>2012/7/24 18:00</ET3>
            //                </And>
            //                <And>
            //                    <ST4>2012/7/24 9:00</ST4>
            //                    <ET4>2012/7/24 18:00</ET4>
            //                </And>
            //            </Or>
            //            <Or>
            //                <And>
            //                    <ST1>2012/7/25 10:00</ST1>
            //                    <ET1>2012/7/25 11:00</ET1>
            //                </And>
            //                <And>
            //                    <ST2>2012/7/25 10:00</ST2>
            //                    <ET2>2012/7/25 11:00</ET2>
            //                </And>
            //                <And>
            //                    <ST3>2012/7/25 10:00</ST3>
            //                    <ET3>2012/7/25 11:00</ET3>
            //                </And>
            //                <And>
            //                    <ST4>2012/7/25 10:00</ST4>
            //                    <ET4>2012/7/25 11:00</ET4>
            //                </And>
            //            </Or>
            //        </Or>
            //    </Condition>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");
            XElement Condition = new XElement("Condition");
            XElement OrRoot = new XElement("Or");
            XElement TeacherCondition = new XElement("Or");

            Condition.Add(OrRoot);
            Request.Add(Condition);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
            {
                foreach (string TeacherName in TeacherNames)
                {
                    if (!string.IsNullOrEmpty(TeacherName))
                    {
                        TeacherCondition.Add(new XElement("TeacherName", TeacherName));
                    }
                }
                Condition.Add(TeacherCondition);
            }

            foreach (CalendarRecord record in Records)
            {
                XElement OrCondition = new XElement("Or");

                OrCondition.Add(GetIntersetcXElement("ST1", "ET1", record.StartDateTime, record.EndDateTime));
                OrCondition.Add(GetIntersetcXElement("ST2", "ET2", record.StartDateTime, record.EndDateTime));
                OrCondition.Add(GetIntersetcXElement("ST3", "ET3", record.StartDateTime, record.EndDateTime));
                OrCondition.Add(GetIntersetcXElement("ST4", "ET4", record.StartDateTime, record.EndDateTime));

                OrRoot.Add(OrCondition);
            }

            XElement Response = SendRequest(Connection, "_.GetIntersectTeacherBusyDateNew", Request);

            return Response;
        }

        /// <summary>
        /// 根據教師名稱及多筆日期取得行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="TeacherName"></param>
        /// <param name="Dates"></param>
        /// <returns></returns>
        public static XElement GetCalendarByTeacherNameAndDates(Connection Connection, string TeacherName, List<DateTime> Dates)
        {
            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            foreach (DateTime Date in Dates)
                Condition.Add(new XElement("Date", Date.ToShortDateString()));

            if (!string.IsNullOrEmpty(TeacherName))
                Condition.Add(new XElement("TeacherName", TeacherName));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetCalendarNew", Request);

            return Response; 
        }

        /// <summary>
        /// 根據多筆日期取得行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Dates"></param>
        /// <returns></returns>
        public static XElement GetCalendar(Connection Connection,List<DateTime> Dates)
        {
            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            foreach (DateTime Date in Dates)
                Condition.Add(new XElement("Date", Date.ToShortDateString()));

            Condition.Add(new XElement("Cancel", "false"));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetCalendarNew", Request);

            return Response;
        }


        /// <summary>
        /// 根據多筆日期取得行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Dates"></param>
        /// <returns></returns>
        public static XElement GetCalendar(Connection Connection,string ClassName,List<DateTime> Dates)
        {
            #region 範例
            //根據教師系統編號、開始日期及結束日期取得約會
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <StartDate>2012/1/1</StartDate>
            //        <EndDate>2012/12/1</EndDate>
            //    </Condition>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            foreach (DateTime Date in Dates)
                Condition.Add(new XElement("Date", Date.ToShortDateString()));

            if (!string.IsNullOrEmpty(ClassName))
                Condition.Add(new XElement("ClassName", ClassName));

            Request.Add(Condition); 

            XElement Response = SendRequest(Connection, "_.GetCalendarNew", Request);

            return Response; 
        }

        /// <summary>
        /// 取得調課記錄
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <param name="TeacherNames"></param>
        /// <param name="ClassNames"></param>
        /// <param name="ExStartDateTime"></param>
        /// <param name="ExEndDateTime"></param>
        /// <param name="ExTeacherNames"></param>
        /// <param name="ExClassNames"></param>
        /// <returns></returns>
        public static XElement GetExchange(
            Connection Connection,
            List<string> TargetExchangeIDs)
        {
            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TargetExchangeIDs))
                foreach (string TargetExchagneID in TargetExchangeIDs)
                    if (!string.IsNullOrEmpty(TargetExchagneID))
                        Condition.Add(new XElement("TargetExchangeID", TargetExchagneID));
            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetExchangeCalendarNew", Request);

            return Response;
        }

      
        /// <summary>
        /// 取得調課記錄
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="StartDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <param name="TeacherNames"></param>
        /// <param name="ClassNames"></param>
        /// <param name="ExStartDateTime"></param>
        /// <param name="ExEndDateTime"></param>
        /// <param name="ExTeacherNames"></param>
        /// <param name="ExClassNames"></param>
        /// <returns></returns>
        public static XElement GetExchange(Connection Connection,
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
            #region 範例
            //<Response>
            //    <Calendar>
            //        <Uid>491478</Uid>
            //        <CourseID>12554</CourseID>
            //        <Subject>英文</Subject>
            //        <Level>1</Level>
            //        <TeacherID>9207</TeacherID>
            //        <TeacherName>Gene</TeacherName>
            //        <ClassID>1487</ClassID>
            //        <ClassName>普一乙</ClassName>
            //        <ClassroomName/>
            //        <StartDateTime>2012-08-15 09:00:00</StartDateTime>
            //        <EndDateTime>2012-08-15 09:50:00</EndDateTime>
            //        <Weekday>1</Weekday>
            //        <Period>2</Period>
            //        <AbsenceName>病假</AbsenceName>
            //        <Comment/>
            //        <ScheduleComment/>
            //        <ReplaceId/>
            //        <ExchangeId>491479</ExchangeId>
            //        <Cancel>f</Cancel>
            //        <ExUid>491479</ExUid>
            //        <ExCourseID>12559</ExCourseID>
            //        <ExSubject>國文</ExSubject>
            //        <ExLevel>1</ExLevel>
            //        <ExTeacherID>9197</ExTeacherID>
            //        <ExTeacherName>張騉翔</ExTeacherName>
            //        <ExClassID>1487</ExClassID>
            //        <ExClassName>普一乙</ExClassName>
            //        <ExClassroomName/>
            //        <ExStartDateTime>2012-08-15 15:00:00</ExStartDateTime>
            //        <ExEndDateTime>2012-08-15 15:50:00</ExEndDateTime>
            //        <ExWeekday>1</ExWeekday>
            //        <ExPeriod>7</ExPeriod>
            //        <ExAbsenceName/>
            //        <ExComment/>
            //        <ExScheduleComment/>
            //        <ExReplaceId/>
            //        <ExExchangeId/>
            //        <ExCancel>f</ExCancel>
            //    </Calendar>
            //</Response>
            #endregion

            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            if (StartDateTime != null)
                Condition.Add(new XElement("StartDateTime", StartDateTime.Value.GetDateTimeString()));

            if (EndDateTime != null)
                Condition.Add(new XElement("EndDateTime", EndDateTime.Value.GetDateTimeString()));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
                foreach (string TeacherName in TeacherNames)
                    if (!string.IsNullOrEmpty(TeacherName))
                        Condition.Add(new XElement("TeacherName", TeacherName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassNames))
                foreach (string ClassName in ClassNames)
                    if (!string.IsNullOrEmpty(ClassName))
                        Condition.Add(new XElement("ClassName", ClassName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassroomNames))
                foreach (string Classroom in ClassroomNames)
                    if (!string.IsNullOrEmpty(Classroom))
                        Condition.Add(new XElement("ClassroomName", Classroom));


            if (ExStartDateTime != null)
                Condition.Add(new XElement("ExStartDateTime", ExStartDateTime.Value.GetDateTimeString()));

            if (ExEndDateTime != null)
                Condition.Add(new XElement("ExEndDateTime", ExEndDateTime.Value.GetDateTimeString()));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ExTeacherNames))
                foreach (string ExTeacherName in ExTeacherNames)
                    if (!string.IsNullOrEmpty(ExTeacherName))
                        Condition.Add(new XElement("ExTeacherName", ExTeacherName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ExClassNames))
                foreach (string ExClassName in ExClassNames)
                    if (!string.IsNullOrEmpty(ExClassName))
                        Condition.Add(new XElement("ExClassName", ExClassName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ExClassroomNames))
                foreach (string ExClassroomName in ExClassroomNames)
                    if (!string.IsNullOrEmpty(ExClassroomName))
                        Condition.Add(new XElement("ExClassroomName", ExClassroomName));


            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetExchangeCalendarNew", Request);

            return Response;
        }

        /// <summary>
        /// 取得代課教師，依照系統編號
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="ReplaceIDs"></param>
        /// <returns></returns>
        public static XElement GetReplace(
            Connection Connection,
            List<string> ReplaceIDs)
        {
            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ReplaceIDs))
                foreach (string ReplaceID in ReplaceIDs)
                    if (!string.IsNullOrEmpty(ReplaceID))
                        Condition.Add(new XElement("ReplaceID", ReplaceID));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetReplaceCalendarNew", Request);

            return Response; 
        }

        /// <summary>
        /// 取得代課教師
        /// </summary>
        /// <param name="Connection">連線物件</param>
        /// <param name="TeacherIDs">教師系統編號列表</param>
        /// <param name="ClassNames">班級系統編號列表</param>
        /// <param name="StartDateTime">開始日期時間</param>
        /// <param name="EndDateTime">結束日期時間</param>
        /// <returns></returns>
        public static XElement GetReplace(
            Connection Connection, 
            List<string> RepTeacherNames, 
            List<string> AbsTeacherNames, 
            List<string> ClassNames,
            List<string> ClassroomNames, 
            DateTime StartDateTime, 
            DateTime EndDateTime)
        {
            #region 範例
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <!--以下為非必要條件-->
            //        <Uid></Uid>
            //        <StartDateTime></StartDateTime>
            //        <EndDateTime></EndDateTime>
            //        <RepTeacherID></RepTeacherID>
            //        <AbsTeacherID></AbsTeacherID>
            //        <ClassID></ClassID>
            //    </Condition>
            //    <!--<Pagination><StartPage>1</StartPage><PageSize>0</PageSize></Pagination>-->
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(RepTeacherNames))
                foreach (string RepTeacherName in RepTeacherNames)
                    if (!string.IsNullOrEmpty(RepTeacherName))
                        Condition.Add(new XElement("TeacherName", RepTeacherName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(AbsTeacherNames))
                foreach(string AbsTeacherName in AbsTeacherNames)
                    if (!string.IsNullOrEmpty(AbsTeacherName))
                        Condition.Add(new XElement("AbsTeacherName", AbsTeacherName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassNames))
                foreach (string ClassName in ClassNames)
                    if (!string.IsNullOrEmpty(ClassName))
                        Condition.Add(new XElement("ClassName", ClassName));

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassroomNames))
                foreach (string ClassroomName in ClassroomNames)
                    if (!string.IsNullOrEmpty(ClassroomName))
                        Condition.Add(new XElement("ClassroomName", ClassroomName));

            Condition.Add(new XElement("StartDateTime", StartDateTime.GetDateTimeString()));
            Condition.Add(new XElement("EndDateTime", EndDateTime.GetDateTimeString()));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetReplaceCalendarNew", Request);

            return Response;
        }

        /// <summary>
        /// 取得行事曆
        /// </summary>
        /// <param name="Connection">連線物件</param>
        /// <param name="TeacherID">教師</param>
        /// <param name="StartDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns></returns>
        public static XElement GetExchangeRelatedCalendar(Connection Connection,
            string ClassName,
            DateTime StartDate,
            DateTime EndDate)
        {
            #region 範例
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <ExCondition>
            //        <StartDate>2013/07/29 00:00:00</StartDate>
            //        <EndDate>2013/08/04 23:59:59</EndDate>
            //        <ClassName>商一甲</ClassName>
            //    </ExCondition>
            //    <Condition>
            //        <StartDate>2013/07/29 00:00:00</StartDate>
            //        <EndDate>2013/08/04 23:59:59</EndDate>
            //    </Condition>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            XElement ExCondition = new XElement("ExCondition");

            if (!string.IsNullOrWhiteSpace(ClassName))
                ExCondition.Add(new XElement("ClassName", ClassName));
            ExCondition.Add(new XElement("StartDate", StartDate.ToDayStart().GetDateTimeString()));
            ExCondition.Add(new XElement("EndDate", EndDate.ToDayEnd().GetDateTimeString()));
            Request.Add(ExCondition);

            XElement Condition = new XElement("Condition");
            Condition.Add(new XElement("StartDate", StartDate.ToDayStart().GetDateTimeString()));
            Condition.Add(new XElement("EndDate", EndDate.ToDayEnd().GetDateTimeString()));
            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetExchagneRelatedCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 取得行事曆
        /// </summary>
        /// <param name="Connection">連線物件</param>
        /// <param name="TeacherID">教師</param>
        /// <param name="StartDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns></returns>
        public static XElement GetCalendar(Connection Connection, 
            List<string> TeacherNames,
            List<string> ClassNames,
            List<string> ClassroomNames,
            DateTime StartDate,
            DateTime EndDate,
            bool? Cancel)
        {
            #region 範例
            //根據教師系統編號、開始日期及結束日期取得約會
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <StartDate>2012/1/1</StartDate>
            //        <EndDate>2012/12/1</EndDate>
            //    </Condition>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
                foreach(string TeacherName in TeacherNames)
                    if (!string.IsNullOrEmpty(TeacherName))
                        Condition.Add(new XElement("TeacherName", TeacherName));
            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassNames))
                foreach(string ClassName in ClassNames)
                    if (!string.IsNullOrEmpty(ClassName))
                        Condition.Add(new XElement("ClassName", ClassName));
            if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassroomNames))
                foreach (string ClassroomName in ClassroomNames)
                    if (!string.IsNullOrEmpty(ClassroomName))
                        Condition.Add(new XElement("ClassroomName", ClassroomName));

            Condition.Add(new XElement("StartDate", StartDate.GetDateTimeString()));
            Condition.Add(new XElement("EndDate", EndDate.GetDateTimeString()));

            if (Cancel!=null)
                Condition.Add(new XElement("Cancel",Cancel.Equals(true)?"T":"F"));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetCalendarNew", Request);

            return Response;
        }

        /// <summary>
        /// 取得行事曆
        /// </summary>
        /// <param name="Connection">連線物件</param>
        /// <param name="TeacherID">教師</param>
        /// <param name="StartDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns></returns>
        public static XElement GetCrossCalendar(Connection Connection,
            List<string> TeacherNames,
            DateTime StartDate,
            DateTime EndDate,
            bool? Cancel)
        {
            #region 範例
            //根據教師系統編號、開始日期及結束日期取得約會
            //<Request>
            //    <Field>
            //        <All></All>
            //    </Field>
            //    <Condition>
            //        <StartDate>2012/1/1</StartDate>
            //        <EndDate>2012/12/1</EndDate>
            //    </Condition>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            XElement Condition = new XElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(TeacherNames))
                foreach (string TeacherName in TeacherNames)
                    if (!string.IsNullOrEmpty(TeacherName))
                        Condition.Add(new XElement("TeacherName", TeacherName));

            Condition.Add(new XElement("StartDate", StartDate.GetDateTimeString()));
            Condition.Add(new XElement("EndDate", EndDate.GetDateTimeString()));

            if (Cancel != null)
                Condition.Add(new XElement("Cancel", Cancel.Equals(true) ? "T" : "F"));

            Request.Add(Condition);

            XElement Response = SendRequest(Connection, "_.GetCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 鎖定或解除鎖定行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static XElement LockCalendar(Connection Connection,
            List<CalendarRecord> Calendars,
            bool vLock)
        {
            #region 範例
            //<Request>
            //    <Calendar>
            //        <Field>
            //            <!--以下為非必要欄位-->
            //            <Lock></Lock>
            //        </Field>
            //        <Condition>
            //            <!--以下為非必要條件-->
            //            <Uid></Uid>
            //        </Condition>
            //    </Calendar>
            //</Request>
            #endregion

            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return null;

            XElement Request = new XElement("Request");
            XElement Calendar = new XElement("Calendar");
            XElement Field = new XElement("Field");
            XElement Lock = new XElement("Lock", vLock ? "是" : "");
            XElement Condition = new XElement("Condition");

            Request.Add(Calendar);
            Calendar.Add(Field);
            Field.Add(Lock);
            Calendar.Add(Condition);

            foreach (CalendarRecord vCalendar in Calendars)
                Condition.Add(new XElement("Uid", vCalendar.UID));

            XElement Response = SendRequest(Connection, "_.UpdateCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 取消或啟用行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static XElement CancelCalendar(Connection Connection,
            List<CalendarRecord> Calendars,
            bool vCancel)
        {
            #region 範例
            //<Request>
            //    <Calendar>
            //        <Field>
            //            <!--以下為非必要欄位-->
            //            <Cancel></Cancel>
            //        </Field>
            //        <Condition>
            //            <!--以下為非必要條件-->
            //            <Uid></Uid>
            //        </Condition>
            //    </Calendar>
            //</Request>
            #endregion

            if (K12.Data.Utility.Utility.IsNullOrEmpty(Calendars))
                return null;

            XElement Request = new XElement("Request");
            XElement Calendar = new XElement("Calendar");
            XElement Field = new XElement("Field");
            XElement Cancel = new XElement("Cancel",vCancel?"t":"f");
            XElement Condition = new XElement("Condition");

            Request.Add(Calendar);
            Calendar.Add(Field);
            Field.Add(Cancel);
            Calendar.Add(Condition);

            foreach (CalendarRecord vCalendar in Calendars)
                Condition.Add(new XElement("Uid",vCalendar.UID));

            XElement Response = SendRequest(Connection, "_.UpdateCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 取消或啟用行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static XElement UpdteCalendarEMailLog(Connection Connection,
            Dictionary<string,string> EMailLogs)
        {
            #region 範例
            //<Request>
            //    <Calendar>
            //        <Field>
            //            <!--以下為非必要欄位-->
            //            <Cancel></Cancel>
            //        </Field>
            //        <Condition>
            //            <!--以下為非必要條件-->
            //            <Uid></Uid>
            //        </Condition>
            //    </Calendar>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            foreach (string Key in EMailLogs.Keys)
            {
                XElement Calendar = new XElement("Calendar");
                XElement Field = new XElement("Field");
                XElement Log = new XElement("EMailLog",EMailLogs[Key]);
                XElement Condition = new XElement("Condition");

                Request.Add(Calendar);
                Calendar.Add(Field);
                Field.Add(Log);
                Calendar.Add(Condition);
                Condition.Add(new XElement("Uid", Key)); 
            }

            XElement Response = SendRequest(Connection, "_.UpdateCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 取消或啟用行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static XElement CancelCalendar(Connection Connection,
            List<string> UIDs,
            bool vCancel)
        {
            #region 範例
            //<Request>
            //    <Calendar>
            //        <Field>
            //            <!--以下為非必要欄位-->
            //            <Cancel></Cancel>
            //        </Field>
            //        <Condition>
            //            <!--以下為非必要條件-->
            //            <Uid></Uid>
            //        </Condition>
            //    </Calendar>
            //</Request>
            #endregion

            if (K12.Data.Utility.Utility.IsNullOrEmpty(UIDs))
                return null;

            XElement Request = new XElement("Request");
            XElement Calendar = new XElement("Calendar");
            XElement Field = new XElement("Field");
            XElement Cancel = new XElement("Cancel", vCancel ? "t" : "f");
            XElement Condition = new XElement("Condition");

            Request.Add(Calendar);
            Calendar.Add(Field);
            Field.Add(Cancel);
            Calendar.Add(Condition);

            foreach (string UID in UIDs)
                if (!string.IsNullOrEmpty(UID))
                    Condition.Add(new XElement("Uid", UID));

            XElement Response = SendRequest(Connection, "_.UpdateCalendar", Request);

            return Response;
        }


        /// <summary>
        /// 刪除行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="UIDs"></param>
        /// <param name="vCancel"></param>
        /// <returns></returns>
        public static XElement DeleteCalendar(Connection Connection,List<string> UIDs)
        {
            #region 範例
            //<Request>
            //    <Condition>
            //        <!--以下為非必要條件-->
            //        <Uid></Uid>
            //    </Condition>
            //</Request>
            #endregion

            if (K12.Data.Utility.Utility.IsNullOrEmpty(UIDs))
                return null;

            XElement Request = new XElement("Request");
            XElement Calendar = new XElement("Calendar");
            XElement Condition = new XElement("Condition");

            Request.Add(Calendar);
            Calendar.Add(Condition);

            foreach (string UID in UIDs)
                if (!string.IsNullOrEmpty(UID))
                    Condition.Add(new XElement("Uid",UID));

            XElement Response = SendRequest(Connection, "_.DeleteCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 更新目標調課系統編號
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="UID"></param>
        /// <param name="TargetExchangeID"></param>
        /// <returns></returns>
        public static XElement UpdateCalendarTargetID(Connection Connection,string UID,string TargetExchangeID)
        {
            #region 範例
            //<Request>
            //    <Calendar>
            //        <Field>
            //            <!--以下為非必要欄位-->
            //            <Cancel></Cancel>
            //        </Field>
            //        <Condition>
            //            <!--以下為非必要條件-->
            //            <Uid></Uid>
            //        </Condition>
            //    </Calendar>
            //</Request>
            #endregion

            if (string.IsNullOrEmpty(UID) || string.IsNullOrEmpty(TargetExchangeID))
                return null;

            XElement Request = new XElement("Request");
            XElement Calendar = new XElement("Calendar");
            XElement Field = new XElement("Field");
            XElement Cancel = new XElement("TargetExchangeID", TargetExchangeID); ;
            XElement Condition = new XElement("Condition");

            Request.Add(Calendar);
            Calendar.Add(Field);
            Field.Add(Cancel);
            Calendar.Add(Condition);
            Condition.Add(new XElement("Uid", UID));

            XElement Response = SendRequest(Connection, "_.UpdateCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 新增行事曆
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Calendars"></param>
        /// <returns></returns>
        public static XElement InsertCalendar(Connection Connection, List<CalendarRecord> Calendars)
        {
            #region 範例
            //<Request>
            //    <Calendar>
            //        <Field>
            //            <!--以下為非必要欄位-->
            //            <AbsenceName></AbsenceName>
            //            <ClassroomName></ClassroomName>
            //            <Comment></Comment>
            //            <EndDateTime></EndDateTime>
            //            <ExchangeId></ExchangeId>
            //            <Level></Level>
            //            <Period></Period>
            //            <RefClassId></RefClassId>
            //            <RefCourseId></RefCourseId>
            //            <RefTeacherId></RefTeacherId>
            //            <ReplaceId></ReplaceId>
            //            <ScheduleComment></ScheduleComment>
            //            <StartDateTime></StartDateTime>
            //            <Subject></Subject>
            //            <Weekday></Weekday>
            //        </Field>
            //    </Calendar>
            //</Request>
            #endregion

            XElement Request = new XElement("Request");

            foreach (CalendarRecord vCalendar in Calendars)
            {
                XElement Calendar = new XElement("Calendar");
                XElement Field = new XElement("Field");
                Calendar.Add(Field);
                Field.Add(new XElement("AbsenceName", vCalendar.AbsenceName));
                Field.Add(new XElement("ClassroomName", vCalendar.ClassroomName));
                Field.Add(new XElement("Comment", vCalendar.Comment));
                Field.Add(new XElement("StartDateTime", vCalendar.StartDateTime.GetDateTimeString()));
                Field.Add(new XElement("EndDateTime",vCalendar.EndDateTime.GetDateTimeString()));
                Field.Add(new XElement("ExchangeID", vCalendar.ExchangeID));
                Field.Add(new XElement("Level", vCalendar.Level));
                Field.Add(new XElement("Period", vCalendar.Period));
                Field.Add(new XElement("ClassName", vCalendar.ClassName));
                Field.Add(new XElement("RefClassID", vCalendar.ClassID));
                Field.Add(new XElement("RefCourseID", vCalendar.CourseID));
                Field.Add(new XElement("TeacherName", vCalendar.TeacherName));
                //教師系統編號目前先為空白，之後要改回來
                Field.Add(new XElement("RefTeacherID", string.Empty));
                Field.Add(new XElement("ReplaceID", vCalendar.ReplaceID));
                Field.Add(new XElement("ScheduleComment", vCalendar.ScheduleComment));
                Field.Add(new XElement("Weekday", vCalendar.Weekday));
                Field.Add(new XElement("Subject", vCalendar.Subject));
                Field.Add(new XElement("Cancel", vCalendar.Cancel ? "t" : "f"));
                Request.Add(Calendar);
            }

            XElement Response = SendRequest(Connection, "_.InsertCalendar", Request);

            return Response;
        }

        /// <summary>
        /// 取得在Greening上可連線的DSNS
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAvailDSNSNames()
        {
            List<string> Names = new List<string>();

            try
            {
                //Connection Connection =  new Connection();

                //Connection.Connect(DSAServices.GreeningAccessPoint, "user", DSAServices.PassportToken);

                Tuple<Connection, string> result = GetConnection(DSAServices.GreeningAccessPoint, "user");

                if (!string.IsNullOrEmpty(result.Item2))
                    throw new Exception(result.Item2);

                Envelope Response = result.Item1.CallService("GetMyDomainInfo", new Envelope());

                XElement Element = XElement.Load(new StringReader(Response.Body.XmlString));

                foreach (XElement SubElement in Element
                    .Element("APUrl")
                    .Elements("url"))
                    Names.Add(SubElement.Value);
            }
            catch (Exception ve)
            {
                throw ve;
            }

            return Names;
        }

        /// <summary>
        /// 設定DSNS
        /// </summary>
        /// <returns></returns>
        public static void SetDSNSConfig(string Name, string Value)
        {
            #region 範例
            //<Request>
            //    <Config>
            //        <!--以下為非必要欄位-->
            //        <LastUpdate></LastUpdate>
            //        <Name></Name>
            //        <Value></Value>
            //    </Config>
            //</Request>
            #endregion

            Tuple<Connection, string> result = GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            XElement RequestElement = new XElement("Request");
            XElement ConfigElement = new XElement("Config");
            ConfigElement.Add(new XElement("Name", Name));
            ConfigElement.Add(new XElement("Value", Value));

            RequestElement.Add(ConfigElement);
            SendRequest(result.Item1, "_.SetConfig", RequestElement);
        }

        /// <summary>
        /// 取得DSNS設定
        /// </summary>
        /// <returns></returns>
        public static string GetDSNSConfig()
        {
            #region 範例
            //<Request>
            //    <Field>
            //        <Value/>
            //    </Field>
            //    <Condition>
            //        <Name>DSNS</Name>
            //    </Condition>
            //</Request>

            //<Response>
            //    <Config>
            //        <Uid>364014</Uid>
            //        <LastUpdate>2012-03-29 15:36:35.27266</LastUpdate>
            //        <Name>DSNS</Name>
            //        <Value>http://test.iteacher.tw/cs4/test_jh_hs</Value>
            //    </Config>
            //</Response>
            #endregion

            XElement RequestElement = XElement
                .Load(new StringReader("<Request><Field><Value/></Field><Condition><Name>DSNSPlus</Name></Condition></Request>"));

            Tuple<Connection, string> result = GetConnection(FISCA.Authentication.DSAServices.AccessPoint);

            try
            {
                XElement ResponseElement = SendRequest(result.Item1, "_.GetConfig", RequestElement)
                    .Element("Config")
                    .Element("Value");

                return ResponseElement.Value;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}