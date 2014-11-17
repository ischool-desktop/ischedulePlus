using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Campus.DocumentValidator;
using FISCA;
using FISCA.Authentication;
using FISCA.Data;
using FISCA.LogAgent;
using FISCA.Permission;
using FISCA.Presentation;
using FISCA.UDT;
using ischedulePlus.Properties;

namespace ischedulePlus
{
    public class Program
    {
        [FISCA.MainMethod()]
        public static void Main()
        {
            ServerModule.AutoManaged("http://module.ischool.com.tw/module/89/ischedulePlus/udm.xml");

            if (!(FISCA.Authentication.DSAServices.AccountType == AccountType.Greening))
                FISCA.Presentation.MotherForm.SetStatusBarMessage("調代課模組請使用ischool Account登入！");

            ContractService.InitialConnection();

            #region 自訂驗證規則
            FactoryProvider.FieldFactory.Add(new FieldValidatorFactory());
            FactoryProvider.RowFactory.Add(new RowValidatorFactory());
            #endregion

            #region 模組啟用先同步Schmea
            K12.Data.Configuration.ConfigData cd = K12.Data.School.Configuration["調代課UDT載入設定"];

            bool checkClubUDT = false;
            string name = "調代課UDT_20140717";

            //如果尚無設定值,預設為
            if (string.IsNullOrEmpty(cd[name]))
            {
                cd[name] = "false";
            }
            //檢查是否為布林
            bool.TryParse(cd[name], out checkClubUDT);

            if (!checkClubUDT)
            {
                SchemaManager Manager = new SchemaManager(FISCA.Authentication.DSAServices.DefaultConnection);

                Manager.SyncSchema(new SchoolYearSemesterDate());
                Manager.SyncSchema(new CourseCalendar());
                Manager.SyncSchema(new TeacherBusyDate());
                Manager.SyncSchema(new ClassBusyDate());
                Manager.SyncSchema(new Config());
                Manager.SyncSchema(new TeacherEx());
                Manager.SyncSchema(new ClassEx());
                Manager.SyncSchema(new CancelCourseCalendar());

                cd[name] = "true";
                cd.Save();
            }
            #endregion


            MotherForm.AddPanel(MainForm.Instance);

            #region 學期管理
            SchoolYearSemesterEditor vSchoolYearSemesterEditor = new SchoolYearSemesterEditor();

            SchoolYearSemesterPackageDataAccess SchoolYearSemesterDataAccess = new SchoolYearSemesterPackageDataAccess();

            winConfiguration<SchoolYearSemesterPackage> configSchoolYearSemster = new winConfiguration<SchoolYearSemesterPackage>(SchoolYearSemesterDataAccess, vSchoolYearSemesterEditor);

            MotherForm.RibbonBarItems["調代課", "設定"]["學期設定"].Image = Properties.Resources.x_office_calendar;
            MotherForm.RibbonBarItems["調代課", "設定"]["學期設定"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "設定"]["學期設定"].Enable = Permissions.學期設定權限;
            MotherForm.RibbonBarItems["調代課", "設定"]["學期設定"].Click += (sender, e) =>
            {
                vSchoolYearSemesterEditor.Prepare();
                configSchoolYearSemster.ShowDialog(700, 450);
                SchoolYearSemesterOption.Instance.LoadSchoolYearSemester();
            };
            #endregion

            #region 教師管理
            TeacherEditor vTeacherEditor = new TeacherEditor();
            TeacherPackageDataAccess vTeacherDataAccess = new TeacherPackageDataAccess();
            winConfiguration<TeacherPackage> configTeacher = new winConfiguration<TeacherPackage>(vTeacherDataAccess, vTeacherEditor);

            MotherForm.RibbonBarItems["調代課", "設定"]["教師"].Image = Resources.teacher_128;
            MotherForm.RibbonBarItems["調代課", "設定"]["教師"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "設定"]["教師"].Enable = Permissions.教師管理權限;

            MotherForm.RibbonBarItems["調代課", "設定"]["教師"]["調代課教師管理"].Click += delegate
            {
                vTeacherEditor.Prepare();
                configTeacher.ShowDialog();
            };

            MotherForm.RibbonBarItems["調代課", "設定"]["教師"]["產生教師不調代時段"].Enable = Permissions.產生教師不調代時段權限;
            MotherForm.RibbonBarItems["調代課", "設定"]["教師"]["產生教師不調代時段"].Click += (sender, e) => new frmCreateTeacherCalendar().ShowDialog();

            #endregion

            #region 班級管理
            ClassEditor vClassEditor = new ClassEditor();
            ClassPackageDataAccess vClassDataAccess = new ClassPackageDataAccess();
            winConfiguration<ClassPackage> configClass = new winConfiguration<ClassPackage>(vClassDataAccess, vClassEditor);

            MotherForm.RibbonBarItems["調代課", "設定"]["班級"].Image = Resources.classmate_128;
            MotherForm.RibbonBarItems["調代課", "設定"]["班級"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "設定"]["班級"].Enable = Permissions.班級管理權限;

            MotherForm.RibbonBarItems["調代課", "設定"]["班級"]["調代課班級管理"].Click += delegate
            {
                vClassEditor.Prepare();
                configClass.ShowDialog(460, 400);
                Calendar.Instance.RefresClassesAsync();
            };

            MotherForm.RibbonBarItems["調代課", "設定"]["班級"]["產生班級不調代時段"].Click += (sender, e) => new frmCreateClassBusyCalendar().ShowDialog();
            MotherForm.RibbonBarItems["調代課", "設定"]["班級"]["產生班級不調代時段"].Enable = Permissions.產生班級不調代時段權限;

            #endregion

            #region 行事曆
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"].Image = Properties.Resources._07_calendar;

            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["產生課程行事曆"].Click += (sender, e) => new frmCreateCourseCalendar().ShowDialog();
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["產生課程行事曆"].Enable = Permissions.產生課程行事曆權限;

            //MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["匯入課程行事曆"].Click += (sender, e) => new ImportCourseCalendar().Execute();
            //MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["匯入課程行事曆"].Enable = Permissions.匯入課程行事曆權限;

            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["ischedule排課課表匯出"].Click += (sender, e) => new frmScheduleExport().ShowDialog();
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["ischedule排課課表匯出"].Enable = Permissions.產生課程行事曆權限;

            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["新民排課課表匯出"].Enable = FISCA.Permission.UserAcl.Current["ischedulePlus.Ribbon0030"].Executable; ;
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["新民排課課表匯出"]["連線設定"].Image = Properties.Resources.設定;
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["新民排課課表匯出"]["連線設定"].Click += (sender, e) => new frmFoxproConnectionSetup().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["新民排課課表匯出"]["課表匯出"].Image = Properties.Resources.Export_Image;
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["新民排課課表匯出"]["課表匯出"].Click += (sender, e) => new frmFoxproCreateWeekCourseSection().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["欣河排課課表匯出"].Click += (sender, e) => new frmExportShinHer().ShowDialog();
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["欣河排課課表匯出"].Enable = Permissions.產生課程行事曆權限;

            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["行事曆設定"].Enable = Permissions.行事曆設定權限;
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["行事曆設定"]["教師"].Click += (sender, e) => new frmCalendarOption(CalendarOption.GetTeacherOption()).ShowDialog();
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["行事曆設定"]["班級"].Click += (sender, e) => new frmCalendarOption(CalendarOption.GetClassOption()).ShowDialog();
            MotherForm.RibbonBarItems["調代課", "設定"]["行事曆"]["行事曆設定"]["場地"].Click += (sender, e) => new frmCalendarOption(CalendarOption.GetClassroomOption()).ShowDialog();

            MotherForm.RibbonBarItems["調代課", "設定"]["假別"].Image = Resources.tablet_write_64;
            MotherForm.RibbonBarItems["調代課", "設定"]["假別"].Enable = Permissions.假別管理權限;
            MotherForm.RibbonBarItems["調代課", "設定"]["假別"].Click += (sender, e) => new frmAbsence().ShowDialog();

            #endregion

            //MotherForm.RibbonBarItems["調代課", "作業"]["連線學校"].Image = Properties.Resources.設定;
            //MotherForm.RibbonBarItems["調代課", "作業"]["連線學校"].Size = RibbonBarButton.MenuButtonSize.Medium;
            //MotherForm.RibbonBarItems["調代課", "作業"]["連線學校"].Enable = Permissions.連線學校權限;
            //MotherForm.RibbonBarItems["調代課", "作業"]["連線學校"].Click += (sender, e) =>
            //{
            //    if (!(FISCA.Authentication.DSAServices.AccountType == AccountType.Greening))
            //        MessageBox.Show("您非使用ischool Account登入，無法使用連線學校功能！");   
            //    else
            //        new frmTestConnection().ShowDialog();
            //};

            //MotherForm.RibbonBarItems["調代課", "作業"]["可存取電子郵件"].Image = Properties.Resources.設定;
            //MotherForm.RibbonBarItems["調代課", "作業"]["可存取電子郵件"].Size = RibbonBarButton.MenuButtonSize.Medium;
            //MotherForm.RibbonBarItems["調代課", "作業"]["可存取電子郵件"].Enable = Permissions.可存取電子郵件權限;
            //MotherForm.RibbonBarItems["調代課", "作業"]["可存取電子郵件"].Click += (sender, e) => new frmEMailList().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Image = Properties.Resources.代課查詢;
            MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Enable = false;
            MotherForm.RibbonBarItems["調代課", "調代課"]["代課"].Click += (sender, e) =>
            {
                List<CalendarRecord> vSelectedCalendars = new List<CalendarRecord>();

                if (MainForm.Instance.GetSelectedType().Equals("Teacher"))
                    vSelectedCalendars = MainForm.Instance.GetTeacherSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Class"))
                    vSelectedCalendars = MainForm.Instance.GetClassSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Classroom"))
                    vSelectedCalendars = MainForm.Instance.GetClassroomSelectedCalendar();

                if (!K12.Data.Utility.Utility.IsNullOrEmpty(vSelectedCalendars))
                {
                    frmReplaceQuery ReplaceQuery = new frmReplaceQuery(vSelectedCalendars);

                    ReplaceQuery.ShowDialog();
                }
            };

            MotherForm.RibbonBarItems["調代課", "調代課"]["缺課"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "調代課"]["缺課"].Image = Properties.Resources.代課查詢;
            MotherForm.RibbonBarItems["調代課", "調代課"]["缺課"].Enable = false;
            MotherForm.RibbonBarItems["調代課", "調代課"]["缺課"].Click += (sender, e) =>
            {
                List<CalendarRecord> vSelectedCalendars = new List<CalendarRecord>();

                if (MainForm.Instance.GetSelectedType().Equals("Teacher"))
                    vSelectedCalendars = MainForm.Instance.GetTeacherSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Class"))
                    vSelectedCalendars = MainForm.Instance.GetClassSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Classroom"))
                    vSelectedCalendars = MainForm.Instance.GetClassroomSelectedCalendar();

                if (!K12.Data.Utility.Utility.IsNullOrEmpty(vSelectedCalendars))
                {
                    frmAbsenceConfirm AbsenceConfirm = new frmAbsenceConfirm(vSelectedCalendars);

                    string Comment = AbsenceConfirm.Comment;

                    if (AbsenceConfirm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        List<CalendarRecord> vrecords = AbsenceConfirm.SelectedCalendars;

                        Tuple<bool, string> result = Calendar.Instance.Replace(vrecords, null, string.Empty, Comment);

                        if (!result.Item1)
                            MessageBox.Show(result.Item2);
                        else
                        {
                            StringBuilder strBuilder = new StringBuilder();

                            strBuilder.AppendLine("《缺課課程》");
                            foreach (CalendarRecord vCalendar in vrecords)
                                strBuilder.AppendLine(vCalendar.ToString());
                            strBuilder.AppendLine("《缺課註記》");
                            strBuilder.AppendLine(Comment);

                            ApplicationLog.Log(Logs.調代課, Logs.缺課作業, strBuilder.ToString());

                            CalendarEvents.RaiseReplaceEvent();

                            MotherForm.SetStatusBarMessage("已成功執行缺課！");
                        }
                    }
                }
            };

            MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Image = Properties.Resources.high_school_refresh_128;
            MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Enable = false;
            MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Click += (sender, e) =>
            {
                List<CalendarRecord> vSelectedCalendars = new List<CalendarRecord>();

                if (MainForm.Instance.GetSelectedType().Equals("Teacher"))
                    vSelectedCalendars = MainForm.Instance.GetTeacherSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Class"))
                    vSelectedCalendars = MainForm.Instance.GetClassSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Classroom"))
                    vSelectedCalendars = MainForm.Instance.GetClassroomSelectedCalendar();

                List<CalendarRecord> vCancelCalendars = new List<CalendarRecord>();

                foreach (CalendarRecord vCalendar in vSelectedCalendars)
                {
                    if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        vCancelCalendars.Add(vCalendar);
                }

                if (!K12.Data.Utility.Utility.IsNullOrEmpty(vCancelCalendars))
                {
                    if (MessageBox.Show("您是否要取消代課？", "確認取消代課", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    List<string> DeleteUIDs = new List<string>();      //要刪除的課程行事曆
                    List<string> UnCancelUIDs = new List<string>();    //要回復的課程行事曆

                    foreach (CalendarRecord vCalendar in vCancelCalendars)
                    {
                        if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        {
                            DeleteUIDs.Add(vCalendar.UID);
                            UnCancelUIDs.Add(vCalendar.ReplaceID);
                        }
                    }

                    #region 儲存取消的行事曆記錄
                    List<CancelCourseCalendar> CancelRecords = new List<CancelCourseCalendar>();

                    foreach (CalendarRecord record in vCancelCalendars)
                    {
                        CancelCourseCalendar CancelCalendar = new CancelCourseCalendar(record);

                        CancelRecords.Add(CancelCalendar);
                    }

                    //儲存取消的行事曆記錄
                    CancelRecords.SaveAll();
                    #endregion

                    //先將行事曆啟用
                    Calendar.Instance.Cancel(UnCancelUIDs, false);

                    //將行事曆刪除
                    Calendar.Instance.Delete(DeleteUIDs);

                    MotherForm.RibbonBarItems["調代課", "調代課"]["取消代課"].Enable = false;

                    MotherForm.SetStatusBarMessage("已成功執行取消代課！");

                    //發出事件，重新整理行事曆
                    CalendarEvents.RaiseExchangeEvent();
                }
            };

            MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Image = Properties.Resources.high_school_reload_128;
            MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Enable = false;
            MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Click += (sender, e) =>
            {
                List<CalendarRecord> vSelectedCalendars = new List<CalendarRecord>();

                if (MainForm.Instance.GetSelectedType().Equals("Teacher"))
                    vSelectedCalendars = MainForm.Instance.GetTeacherSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Class"))
                    vSelectedCalendars = MainForm.Instance.GetClassSelectedCalendar();
                else if (MainForm.Instance.GetSelectedType().Equals("Classroom"))
                    vSelectedCalendars = MainForm.Instance.GetClassroomSelectedCalendar();

                List<CalendarRecord> vCancelCalendars = new List<CalendarRecord>();

                foreach (CalendarRecord Calendar in vSelectedCalendars)
                {
                    if (!string.IsNullOrWhiteSpace(Calendar.ExchangeID))
                        vCancelCalendars.Add(Calendar);
                }

                if (!K12.Data.Utility.Utility.IsNullOrEmpty(vCancelCalendars))
                {
                    if (MessageBox.Show("您是否要取消調課？", "確認取消調課", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    List<string> DeleteUIDs = new List<string>();      //要刪除的課程行事曆
                    List<string> UnCancelUIDs = new List<string>();    //要回復的課程行事曆
                    List<string> FindExchangeIDs = new List<string>(); //尋找調課行事曆系統編號

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (vsender, ve) =>
                    {
                        #region 目前選取的行事曆都是要刪除的行事曆
                        foreach (CalendarRecord Calendar in vCancelCalendars)
                        {
                            if (!DeleteUIDs.Contains(Calendar.UID))
                                DeleteUIDs.Add(Calendar.UID);
                        }
                        #endregion

                        #region 尋找另一方調課記錄
                        if (DeleteUIDs.Count > 0)
                        {
                            QueryHelper mQueryHelper = Utility.QueryHelper;

                            //先根據使用者選取的課程行事曆編號找出
                            //uid,target_exchange_id,exchange_id
                            string strSQL = "select uid,target_exchange_id,exchange_id from $scheduler.course_calendar where uid in (" + string.Join(",", DeleteUIDs.ToArray()) + ")";

                            DataTable table = mQueryHelper.Select(strSQL);

                            if (table.Rows.Count > 0)
                            {
                                List<string> UIDs = new List<string>();
                                List<string> TargetExchangeIDs = new List<string>();

                                foreach (DataRow row in table.Rows)
                                {
                                    string UID = row.Field<string>("uid");
                                    string TargetExchangeID = row.Field<string>("target_exchange_id");
                                    string ExchangeID = row.Field<string>("exchange_id");

                                    #region 若是ExchangeID不為空白，則將之存儲起來，代表要回復的課程行事曆
                                    if (!string.IsNullOrWhiteSpace(ExchangeID))
                                        UnCancelUIDs.Add(ExchangeID);
                                    #endregion

                                    if (!string.IsNullOrWhiteSpace(TargetExchangeID))
                                    {
                                        //若是TargetExchangeID不為空白，則根據UID條件尋找
                                        UIDs.Add(TargetExchangeID);
                                        FindExchangeIDs.Add(TargetExchangeID);
                                    }
                                    else
                                    {
                                        //否則根據TargetExchagneID來尋找
                                        TargetExchangeIDs.Add(UID);
                                        FindExchangeIDs.Add(UID);
                                    }
                                }

                                #region 根據UID條件尋找出調課記錄，並且記錄要刪除及要回復的系統編號
                                if (!K12.Data.Utility.Utility.IsNullOrEmpty(UIDs))
                                {
                                    strSQL = "select uid,exchange_id from $scheduler.course_calendar where uid in (" + string.Join(",", UIDs.ToArray()) + ")";

                                    table = mQueryHelper.Select(strSQL);

                                    foreach (DataRow row in table.Rows)
                                    {
                                        string UID = row.Field<string>("uid");
                                        string ExchangeID = row.Field<string>("exchange_id");

                                        DeleteUIDs.Add(UID);
                                        UnCancelUIDs.Add(ExchangeID);
                                    }
                                }
                                #endregion

                                #region TargetExchangeIDs尋找出調課記錄，並且記錄要刪除及要回復的系統編號
                                if (!K12.Data.Utility.Utility.IsNullOrEmpty(TargetExchangeIDs))
                                {
                                    strSQL = "select uid,exchange_id from $scheduler.course_calendar where target_exchange_id in (" + string.Join(",", TargetExchangeIDs.ToArray()) + ")";

                                    table = mQueryHelper.Select(strSQL);

                                    foreach (DataRow row in table.Rows)
                                    {
                                        string UID = row.Field<string>("uid");
                                        string ExchangeID = row.Field<string>("exchange_id");

                                        DeleteUIDs.Add(UID);
                                        UnCancelUIDs.Add(ExchangeID);
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion
                    };

                    worker.RunWorkerCompleted += (vsender, ve) =>
                    {
                        #region 儲存取消的行事曆記錄
                        List<CalendarRecord> records = Calendar.Instance.FindExchangeRecords(FindExchangeIDs);

                        List<CancelCourseCalendar> CancelRecords = new List<CancelCourseCalendar>();

                        foreach (CalendarRecord record in records)
                        {
                            CancelCourseCalendar CancelCalendar = new CancelCourseCalendar(record);

                            CancelRecords.Add(CancelCalendar);
                        }

                        //儲存取消的行事曆記錄
                        CancelRecords.SaveAll();
                        #endregion

                        //先將行事曆啟用
                        Calendar.Instance.Cancel(UnCancelUIDs, false);

                        //將行事曆刪除
                        Calendar.Instance.Delete(DeleteUIDs);

                        MotherForm.RibbonBarItems["調代課", "調代課"]["取消調課"].Enable = false;

                        MotherForm.SetStatusBarMessage("已成功執行取消調課！");

                        //發出事件，重新整理行事曆
                        CalendarEvents.RaiseExchangeEvent();
                    };

                    worker.RunWorkerAsync();
                }
            };

            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課記錄"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課記錄"].Image = Properties.Resources.project_32;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課記錄"].Enable = Permissions.調代課批次查詢權限;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課記錄"].Click += (sender, e) => new frmExchangeReplaceQuery().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["行事曆"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["行事曆"].Image = Properties.Resources.schedule_search_128;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["行事曆"].Enable = Permissions.行事曆批次查詢權限;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["行事曆"].Click += (sender, e) => new frmCalendarQuery().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["無課教師"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["無課教師"].Image = Properties.Resources.teacher_clock_128;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["無課教師"].Enable = Permissions.行事曆批次查詢權限;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["無課教師"].Click += (sender, e) => new frmTeacherNoBusyQuery().ShowDialog();

            //MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課通知單"].Size = RibbonBarButton.MenuButtonSize.Medium;
            //MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課通知單"].Image = Properties.Resources.history_clock_32;
            //MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課通知單"].Enable = Permissions.調代課通知單列印權限;
            //MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["調代課通知單"].Click += (sender, e) => new frmExchangeReplaceReport().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課明細表"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課明細表"].Image = Properties.Resources.calc_32;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課明細表"].Enable = Permissions.請假代課明細表列印權限;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課明細表"].Click += (sender, e) => new frmExchangeReplaceMonthReport().ShowDialog();

            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課統計表"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課統計表"].Image = Properties.Resources.scientific_calculator_32;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課統計表"].Enable = Permissions.請假代課統計表列印權限;
            MotherForm.RibbonBarItems["調代課", "報表(查詢)"]["請假代課統計表"].Click += (sender, e) => new frmExchangeReplaceSatReport().ShowDialog();

            FISCA.Permission.Catalog AdminCatalog = FISCA.Permission.RoleAclSource.Instance["調代課作業"]["功能按鈕"];
            AdminCatalog.Add(new RibbonFeature(Permissions.教師管理, "教師管理"));
            AdminCatalog.Add(new RibbonFeature(Permissions.班級管理, "班級管理"));
            AdminCatalog.Add(new RibbonFeature(Permissions.學期設定, "學期設定"));
            AdminCatalog.Add(new RibbonFeature(Permissions.假別管理, "假別管理"));
            AdminCatalog.Add(new RibbonFeature(Permissions.行事曆設定, "行事曆設定"));

            AdminCatalog.Add(new RibbonFeature(Permissions.連線學校, "連線學校"));
            //AdminCatalog.Add(new RibbonFeature(Permissions.匯入課程行事曆, "匯入課程行事曆"));
            AdminCatalog.Add(new RibbonFeature(Permissions.產生課程行事曆, "產生課程行事曆"));
            AdminCatalog.Add(new RibbonFeature(Permissions.產生班級不調代時段, "產生班級不調代時段"));
            AdminCatalog.Add(new RibbonFeature(Permissions.產生教師不調代時段, "產生教師不調代時段"));

            AdminCatalog.Add(new RibbonFeature(Permissions.調代課批次查詢, "調代課批次查詢"));
            AdminCatalog.Add(new RibbonFeature(Permissions.行事曆批次查詢, "行事曆批次查詢"));
            AdminCatalog.Add(new RibbonFeature(Permissions.調代課通知單列印, "調代課通知單列印"));
            AdminCatalog.Add(new RibbonFeature(Permissions.請假代課明細表列印, "請假代課明細列印"));
            AdminCatalog.Add(new RibbonFeature(Permissions.請假代課統計表列印, "請假代課統計列印"));
            AdminCatalog.Add(new RibbonFeature(Permissions.可存取電子郵件, "可存取電子郵件"));
            AdminCatalog.Add(new RibbonFeature(Permissions.代課查詢, "代課查詢"));
            AdminCatalog.Add(new RibbonFeature(Permissions.取消代課, "取消代課"));
            AdminCatalog.Add(new RibbonFeature(Permissions.取消調課, "取消調課"));

            Calendar.Instance.RefresClassesAsync();
            Calendar.Instance.RefresTeacherAsync();
        }
    }
}