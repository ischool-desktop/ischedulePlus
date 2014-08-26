using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using FISCA.Data;
using FISCA.LogAgent;
using FISCA.Presentation;
using ischedulePlus.Properties;
using K12.Data;
using K12.Data.Configuration;

namespace ischedulePlus
{
    /// <summary>
    /// Decorator for Scheduler, it is a wrapper class for panel that contains a scheduler.
    /// </summary>
    public class DecCalendar
    {
        private CalendarType mCalendarType = CalendarType.Teacher;

        private DevComponents.DotNetBar.PanelEx pnlContainer;

        private int colHeaderHeight = 30;
        private int rowHeaderWidth = 30;

        private Dictionary<string, DevComponents.DotNetBar.PanelEx> cells;  //所有的 panel
        private Dictionary<string, DecPeriod> decPeriods;   //所有的panel 的decorator
        private Dictionary<string, DevComponents.DotNetBar.PanelEx> headerCells;

        private List<CalendarRecord> dataSource;        //所有的課程分段
        private List<CalendarRecord> relatedDataSource;
        private List<TeacherBusy> relatedTeacherBusys;
        private List<CalendarRecord> selectedCalendars;
        //local variables
        private int weekday;
        private List<PeriodSetting> periods = new List<PeriodSetting>();
        private List<DecPeriod> SelectedPeriods = new List<DecPeriod>();
        private CalendarOption mOption = new CalendarOption();

        private LabelX lblName = new LabelX();
        private TextBoxX txtStartDate = new TextBoxX();
        private LabelX lblEndDate = new LabelX();
        private string mAssocID;

        private ButtonX btnPrevious = new ButtonX();
        private ButtonX btnNext = new ButtonX();
        private ButtonX btnCurrent = new ButtonX();

        private ButtonX CreateButton(Size vSize)
        {
            ButtonX btnX = new ButtonX();

            btnX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            btnX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            btnX.Size = vSize;
            btnX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;

            return btnX;
        }

        /// <summary>
        /// pnl : 整個課表的 container
        /// schType : 課表類型
        /// 
        /// </summary>
        /// <param name="pnl"></param>
        /// <param name="schType"></param>
        public DecCalendar(DevComponents.DotNetBar.PanelEx pnl)
        {
            pnl.Tag = this;

            #region 註冊事件
            CalendarEvents.ReplaceEvent += (sender, e) => UpdateContent();
            CalendarEvents.ExchangeEvent += (sender, e) =>
            {
                this.SelectedCalendars = new List<CalendarRecord>();
                UpdateContent();
            };
            CalendarEvents.WeekChangeEvent += (vsender, ve) =>
            {
                if (ve.Type.Equals(this.Type) && 
                    ve.AssocID.Equals(this.AssocID))
                {
                    this.SelectedCalendars = new List<CalendarRecord>();
                    this.UpdateContent();
                }
            };
            CalendarEvents.WeekdayPeriodChangeEvent += CalendarEvents_WeekdayPeriodChangeEvent;
            #endregion

            #region 建立元件
            pnl.Controls.Clear();

            PanelEx pnlCalendarControl = makePanel(string.Empty, string.Empty, new Point(), new Size(10,50));
            pnlCalendarControl.Dock = DockStyle.Top;

            btnPrevious = CreateButton(new Size(50, 25)); 
            btnNext = CreateButton(new Size(50, 25));

            btnPrevious.Text = "上週";
            btnPrevious.Location = new Point(10, 10);
            btnPrevious.Click += (sender, e) =>
            {
                SchoolYearSemesterOption.Instance.StartDate = SchoolYearSemesterOption.Instance.StartDate.AddDays(-7);
                SchoolYearSemesterOption.Instance.EndDate = SchoolYearSemesterOption.Instance.EndDate.AddDays(-7);
                CalendarEvents.RaiseWeekChangeEvent(this.Type,this.AssocID);
            };

            btnNext.Text = "下週";
            btnNext.Location = new Point(70, 10);
            btnNext.Click += (sender, e) =>
            {
                SchoolYearSemesterOption.Instance.StartDate = SchoolYearSemesterOption.Instance.StartDate.AddDays(7);
                SchoolYearSemesterOption.Instance.EndDate = SchoolYearSemesterOption.Instance.EndDate.AddDays(7);
                CalendarEvents.RaiseWeekChangeEvent(this.Type,this.AssocID);
            };

            btnCurrent = CreateButton(new Size(50, 25));
            btnCurrent.Text = "本週";
            btnCurrent.Location = new Point(130, 10);
            btnCurrent.Click += (sender,e)=>
            {
                SchoolYearSemesterOption.Instance.StartDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToDayStart();
                SchoolYearSemesterOption.Instance.EndDate = SchoolYearSemesterOption.Instance.StartDate.AddDays(6);
                CalendarEvents.RaiseWeekChangeEvent(this.Type,this.AssocID);
            };

            ButtonX btnPrint = CreateButton(new Size(50, 25));
            btnPrint.Location = new Point(190,10);
            btnPrint.Text = "列印";
            btnPrint.Click += (sender,e)=>
            {
                if (this.Type.Equals(CalendarType.Teacher))
                {                   
                    List<CalendarRecord> QueryResult = new List<CalendarRecord>();

                    DateTime dteStart = SchoolYearSemesterOption.Instance.StartDate;
                    DateTime dteEnd = SchoolYearSemesterOption.Instance.EndDate;
                    List<string> SelectedClassNames = new List<string>();
                    List<string> SelectedTeacherNames = new List<string>(){AssocID};

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (vsender, ve) =>
                    {
                        #region 找出調課記錄
                        List<CalendarRecord> ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null,
                        null, null, null, null, null);

                        List<CalendarRecord> ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null);

                        Dictionary<string, CalendarRecord> Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出代課記錄
                        List<CalendarRecord> RepRecords = Calendar.Instance.FindReplaceRecords(
                            SelectedTeacherNames, null, SelectedClassNames, null, dteStart, dteEnd);

                        List<CalendarRecord> AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, SelectedTeacherNames, SelectedClassNames, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);
                        #endregion

                        QueryResult.AddRange(Records.Values);

                        List<CalendarRecord> RelatedQueryResult = new List<CalendarRecord>();

                        List<string> RelatedClassNames = new List<string>();
                        List<string> RelatedTeacherNames = new List<string>();

                        foreach (CalendarRecord record in Records.Values)
                        {
                            if (!string.IsNullOrWhiteSpace(record.ReplaceID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.AbsTeacherName);
                            }

                            if (!string.IsNullOrWhiteSpace(record.ExchangeID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);

                                if (record.ExchangeCalendar!=null)
                                    RelatedTeacherNames.Add(record.ExchangeCalendar.TeacherName);
                            }
                        }

                        RelatedTeacherNames = RelatedTeacherNames.Distinct().ToList();
                        RelatedClassNames = RelatedClassNames.Distinct().ToList();
                        QueryResult.Clear();

                        #region 找出相關調課記錄
                        ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, RelatedTeacherNames, RelatedClassNames, null,
                        null, null, null, null, null);

                        ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, RelatedTeacherNames, RelatedClassNames, null);

                        Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出相關代課記錄
                        RepRecords = Calendar.Instance.FindReplaceRecords(
                            RelatedTeacherNames, null, RelatedClassNames, null, dteStart, dteEnd);

                        AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, RelatedTeacherNames, RelatedClassNames, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion
                    };

                    worker.RunWorkerCompleted += (vsender, ve) =>
                    {
                        ExchangeReplaceReport.Instance.Print(QueryResult, dteStart, dteEnd);
                        MotherForm.SetStatusBarMessage(string.Empty);
                        btnPrint.Enabled = true;
                    };

                    worker.RunWorkerAsync();
                    MotherForm.SetStatusBarMessage("取得報表資料中！");
                    btnPrint.Enabled = false;
                }
                else if (this.Type.Equals(CalendarType.Class))
                {
                    List<CalendarRecord> QueryResult = new List<CalendarRecord>();

                    DateTime dteStart = SchoolYearSemesterOption.Instance.StartDate;
                    DateTime dteEnd = SchoolYearSemesterOption.Instance.EndDate;
                    List<string> SelectedClassNames = new List<string>() { AssocID };
                    List<string> SelectedTeacherNames = new List<string>();

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (vsender, ve) =>
                    {
                        #region 找出調課記錄
                        List<CalendarRecord> ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null,
                        null, null, null, null, null);

                        List<CalendarRecord> ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null);

                        Dictionary<string, CalendarRecord> Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出代課記錄
                        List<CalendarRecord> RepRecords = Calendar.Instance.FindReplaceRecords(
                            SelectedTeacherNames, null, SelectedClassNames, null, dteStart, dteEnd);

                        List<CalendarRecord> AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, SelectedTeacherNames, SelectedClassNames, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);
                        #endregion

                        QueryResult.AddRange(Records.Values);

                        List<CalendarRecord> RelatedQueryResult = new List<CalendarRecord>();

                        List<string> RelatedClassNames = new List<string>();
                        List<string> RelatedTeacherNames = new List<string>();

                        foreach (CalendarRecord record in Records.Values)
                        {
                            if (!string.IsNullOrWhiteSpace(record.ReplaceID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.AbsTeacherName);
                            }

                            if (!string.IsNullOrWhiteSpace(record.ExchangeID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.ExchangeCalendar.TeacherName);
                            }
                        }

                        RelatedTeacherNames = RelatedTeacherNames.Distinct().ToList();
                        RelatedClassNames = RelatedClassNames.Distinct().ToList();
                        QueryResult.Clear();

                        #region 找出相關調課記錄
                        ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, RelatedTeacherNames, null, null,
                        null, null, null, null, null);

                        ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, RelatedTeacherNames, null, null);

                        Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出相關代課記錄
                        RepRecords = Calendar.Instance.FindReplaceRecords(
                            RelatedTeacherNames, null, null, null, dteStart, dteEnd);

                        AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, RelatedTeacherNames, null, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion
                    };

                    worker.RunWorkerCompleted += (vsender, ve) =>
                    {
                        ExchangeReplaceReport.Instance.Print(QueryResult, dteStart, dteEnd);
                        MotherForm.SetStatusBarMessage(string.Empty);
                        btnPrint.Enabled = true;
                    };

                    worker.RunWorkerAsync();
                    MotherForm.SetStatusBarMessage("取得報表資料中！");
                    btnPrint.Enabled = false;
                }
            };

            ButtonItem btnPrintAll = new ButtonItem("列印所有", "列印所有");

            btnPrintAll.Click += (sender, e) =>
            {
                if (this.Type.Equals(CalendarType.Teacher))
                {
                    List<CalendarRecord> QueryResult = new List<CalendarRecord>();

                    DateTime dteStart = SchoolYearSemesterOption.Instance.StartDate;
                    DateTime dteEnd = SchoolYearSemesterOption.Instance.EndDate;
                    List<string> SelectedClassNames = new List<string>();
                    List<string> SelectedTeacherNames = new List<string>();

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (vsender, ve) =>
                    {
                        #region 找出調課記錄
                        List<CalendarRecord> ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null,
                        null, null, null, null, null);

                        List<CalendarRecord> ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null);

                        Dictionary<string, CalendarRecord> Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出代課記錄
                        List<CalendarRecord> RepRecords = Calendar.Instance.FindReplaceRecords(
                            SelectedTeacherNames, null, SelectedClassNames, null, dteStart, dteEnd);

                        List<CalendarRecord> AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, SelectedTeacherNames, SelectedClassNames, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);
                        #endregion

                        QueryResult.AddRange(Records.Values);

                        List<CalendarRecord> RelatedQueryResult = new List<CalendarRecord>();

                        List<string> RelatedClassNames = new List<string>();
                        List<string> RelatedTeacherNames = new List<string>();

                        foreach (CalendarRecord record in Records.Values)
                        {
                            if (!string.IsNullOrWhiteSpace(record.ReplaceID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.AbsTeacherName);
                            }

                            if (!string.IsNullOrWhiteSpace(record.ExchangeID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.ExchangeCalendar.TeacherName);
                            }
                        }

                        RelatedTeacherNames = RelatedTeacherNames.Distinct().ToList();
                        RelatedClassNames = RelatedClassNames.Distinct().ToList();
                        QueryResult.Clear();

                        #region 找出相關調課記錄
                        ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, RelatedTeacherNames, RelatedClassNames, null,
                        null, null, null, null, null);

                        ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, RelatedTeacherNames, RelatedClassNames, null);

                        Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出相關代課記錄
                        RepRecords = Calendar.Instance.FindReplaceRecords(
                            RelatedTeacherNames, null, RelatedClassNames, null, dteStart, dteEnd);

                        AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, RelatedTeacherNames, RelatedClassNames, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion
                    };

                    worker.RunWorkerCompleted += (vsender, ve) =>
                    {
                        ExchangeReplaceReport.Instance.Print(QueryResult, dteStart, dteEnd);
                        MotherForm.SetStatusBarMessage(string.Empty);
                        btnPrint.Enabled = true;
                    };

                    worker.RunWorkerAsync();
                    MotherForm.SetStatusBarMessage("取得報表資料中！");
                    btnPrint.Enabled = false;
                }
                else if (this.Type.Equals(CalendarType.Class))
                {
                    List<CalendarRecord> QueryResult = new List<CalendarRecord>();

                    DateTime dteStart = SchoolYearSemesterOption.Instance.StartDate;
                    DateTime dteEnd = SchoolYearSemesterOption.Instance.EndDate;
                    List<string> SelectedClassNames = new List<string>();
                    List<string> SelectedTeacherNames = new List<string>();

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (vsender, ve) =>
                    {
                        #region 找出調課記錄
                        List<CalendarRecord> ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null,
                        null, null, null, null, null);

                        List<CalendarRecord> ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, SelectedTeacherNames, SelectedClassNames, null);

                        Dictionary<string, CalendarRecord> Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出代課記錄
                        List<CalendarRecord> RepRecords = Calendar.Instance.FindReplaceRecords(
                            SelectedTeacherNames, null, SelectedClassNames, null, dteStart, dteEnd);

                        List<CalendarRecord> AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, SelectedTeacherNames, SelectedClassNames, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);
                        #endregion

                        QueryResult.AddRange(Records.Values);

                        List<CalendarRecord> RelatedQueryResult = new List<CalendarRecord>();

                        List<string> RelatedClassNames = new List<string>();
                        List<string> RelatedTeacherNames = new List<string>();

                        foreach (CalendarRecord record in Records.Values)
                        {
                            if (!string.IsNullOrWhiteSpace(record.ReplaceID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.AbsTeacherName);
                            }

                            if (!string.IsNullOrWhiteSpace(record.ExchangeID))
                            {
                                RelatedClassNames.Add(record.ClassName);
                                RelatedTeacherNames.Add(record.TeacherName);
                                RelatedTeacherNames.Add(record.ExchangeCalendar.TeacherName);
                            }
                        }

                        RelatedTeacherNames = RelatedTeacherNames.Distinct().ToList();
                        RelatedClassNames = RelatedClassNames.Distinct().ToList();
                        QueryResult.Clear();

                        #region 找出相關調課記錄
                        ExchangeARecords = Calendar.Instance.FindExchangeRecords(
                        dteStart, dteEnd, RelatedTeacherNames, null, null,
                        null, null, null, null, null);

                        ExchangeBRecords = Calendar.Instance.FindExchangeRecords(
                        null, null, null, null, null,
                        dteStart, dteEnd, RelatedTeacherNames, null, null);

                        Records = new Dictionary<string, CalendarRecord>();

                        foreach (CalendarRecord ExchangeRecord in ExchangeARecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        foreach (CalendarRecord ExchangeRecord in ExchangeBRecords)
                            if (!Records.ContainsKey(ExchangeRecord.UID))
                                Records.Add(ExchangeRecord.UID, ExchangeRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion

                        #region 找出相關代課記錄
                        RepRecords = Calendar.Instance.FindReplaceRecords(
                            RelatedTeacherNames, null, null, null, dteStart, dteEnd);

                        AbsRecords = Calendar.Instance.FindReplaceRecords(
                            null, RelatedTeacherNames, null, null, dteStart, dteEnd);

                        foreach (CalendarRecord RepRecord in RepRecords)
                            if (!Records.ContainsKey(RepRecord.UID))
                                Records.Add(RepRecord.UID, RepRecord);

                        foreach (CalendarRecord AbsRecord in AbsRecords)
                            if (!Records.ContainsKey(AbsRecord.UID))
                                Records.Add(AbsRecord.UID, AbsRecord);

                        QueryResult.AddRange(Records.Values);
                        #endregion
                    };

                    worker.RunWorkerCompleted += (vsender, ve) =>
                    {
                        ExchangeReplaceReport.Instance.Print(QueryResult, dteStart, dteEnd);
                        MotherForm.SetStatusBarMessage(string.Empty);
                        btnPrint.Enabled = true;
                    };

                    worker.RunWorkerAsync();
                    MotherForm.SetStatusBarMessage("取得報表資料中！");
                    btnPrint.Enabled = false;
                }
            };

            btnPrint.SubItems.Add(btnPrintAll);

            ButtonItem btnSetting = new ButtonItem("設定", "設定");

            btnSetting.Click += (sender, e) =>
            {
                #region 讀取 Preference
                ConfigData configExchagne = K12.Data.School.Configuration["調代課通知單"];

                if (configExchagne != null)
                {
                    int _useTemplateNumber = 0;
                    int.TryParse(configExchagne["TemplateNumber"], out _useTemplateNumber);

                    string customize = configExchagne["CustomizeTemplate"];
                    byte[] _buffer = Resources.調代課通知單;

                    if (!string.IsNullOrEmpty(customize))
                        _buffer = Convert.FromBase64String(customize);
                    frmExchangeReplaceTemplateConfig frmConfig = new frmExchangeReplaceTemplateConfig(
                        _buffer,
                        _useTemplateNumber);

                    frmConfig.ShowDialog();
                }
                #endregion

                //switch (mCalendarType)
                //{
                //    case CalendarType.Teacher:
                //        new frmCalendarOption(CalendarOption.GetTeacherOption()).ShowDialog();
                //        break;
                //    case CalendarType.Class:
                //        new frmCalendarOption(CalendarOption.GetClassOption()).ShowDialog();
                //        break;
                //    case CalendarType.Classroom:
                //        new frmCalendarOption(CalendarOption.GetClassroomOption()).ShowDialog();
                //        break;
                //}
            };
            btnPrint.SubItems.Add(btnSetting);

            if (CalendarOption.PrintExtraButtons.Count > 0)
            {
                foreach (ButtonItem vButton in CalendarOption.PrintExtraButtons)
                    btnPrint.SubItems.Add(vButton);
            }

            ErrorProvider errProvier = new ErrorProvider();

            DateTime dt = new DateTime();

            lblName.Name = "lblTitle";
            lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            lblName.Font = new System.Drawing.Font("新細明體", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            lblName.Location = new Point(240, 13);
            lblName.AutoSize = true;

            txtStartDate.Font = new System.Drawing.Font("新細明體", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            txtStartDate.Location = new Point(380, 13);
            txtStartDate.Width = 40;
            txtStartDate.TextChanged += (sender, e) =>
            {
              string value = txtStartDate.Text;
                if (string.IsNullOrEmpty(value)) //沒有資料就不作任何檢查。
                    return;

                if (!DateTime.TryParse(value, out dt))
                {
                    errProvier.SetError(txtStartDate, "日期格式錯誤。");
                }
                else
                {
                    errProvier.Clear();
                }
            };
            txtStartDate.KeyPress += (sender, e) =>
            {
                if (e.KeyChar.Equals((char)Keys.Return))
                {
                    SchoolYearSemesterOption.Instance.StartDate = dt.StartOfWeek(DayOfWeek.Monday);
                    SchoolYearSemesterOption.Instance.EndDate = SchoolYearSemesterOption.Instance.StartDate.AddDays(6);
                    txtStartDate.Text = SchoolYearSemesterOption.Instance.StartDate.Month + "/" + SchoolYearSemesterOption.Instance.StartDate.Day;
                    CalendarEvents.RaiseWeekChangeEvent(this.Type,this.AssocID);
                }
            };

            lblEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            lblEndDate.Font = new System.Drawing.Font("新細明體", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            lblEndDate.Location = new Point(420, 13);
            lblEndDate.AutoSize = true;

            pnlCalendarControl.Controls.Add(btnPrint);
            pnlCalendarControl.Controls.Add(txtStartDate);
            pnlCalendarControl.Controls.Add(lblName);
            pnlCalendarControl.Controls.Add(lblEndDate);
            pnlCalendarControl.Controls.Add(btnPrevious);
            pnlCalendarControl.Controls.Add(btnCurrent);
            pnlCalendarControl.Controls.Add(btnNext);

            PanelEx pnlCalendarContent = new PanelEx();
            pnlCalendarContent.Dock = DockStyle.Fill;

            pnl.Controls.Add(pnlCalendarContent);
            pnl.Controls.Add(pnlCalendarControl);

            this.pnlContainer = pnlCalendarContent;
            this.pnlContainer.Resize += (sender, e) => Resize();
            this.cells = new Dictionary<string, DevComponents.DotNetBar.PanelEx>();
            this.decPeriods = new Dictionary<string, DecPeriod>();
            this.headerCells = new Dictionary<string, DevComponents.DotNetBar.PanelEx>();

            ContextMenu Menu = new ContextMenu();
            this.pnlContainer.ContextMenu = Menu;
            Menu.Popup += Menu_Popup;
            #endregion

            #region 星期節次
            Campus.Configuration.ConfigData config = Campus.Configuration.Config.User["CalendarOption"];

            string vWeekday = config["Weekday"];
            string vPeriods = config["PeriodList"];

            if (!string.IsNullOrWhiteSpace(vWeekday))
                this.weekday = K12.Data.Int.Parse(vWeekday);
            else
                this.weekday = 5;

            this.periods = Utility.GetPeriodList(vPeriods);
            this.RedrawGrid();
            #endregion
        }

        private void CalendarEvents_WeekdayPeriodChangeEvent(object sender, CalendarEvents.WeekdayPeriodEventArgs e)
        {
            this.weekday = e.Weekday;
            this.periods = e.Periods;

            this.RedrawGrid();
            this.UpdateContent();
        }

        private void Menu_Popup(object sender, EventArgs e)
        {
            ContextMenu Menu = this.pnlContainer.ContextMenu;

            Menu.MenuItems.Clear();

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(this.selectedCalendars))
            {
                MenuItem itemReplace = new MenuItem();
                itemReplace.Text = "代課";
                itemReplace.Click += itemSubject_Click;
                Menu.MenuItems.Add(itemReplace);

                //MenuItem itemDelete = new MenuItem();
                //itemDelete.Text = "刪除不調代時段";
                //itemDelete.Click += itemDelete_Click;
                //Menu.MenuItems.Add(itemDelete);
            }
        }

        private void itemDelete_Click(object sender, EventArgs e)
        {
            Control ctl = this.pnlContainer.GetChildAtPoint(this.pnlContainer.PointToClient(Control.MousePosition));

            if (ctl is PanelEx)
            {
                DecPeriod Period = ctl.Tag as DecPeriod;

                if (Period != null && 
                    Period.IsBusy)
                {
                    int vWeekday = Period.Weekday;
                    int vPeriod = Period.Period;

                    List<TeacherBusy> RemoveBusys = new List<TeacherBusy>();

                    foreach (TeacherBusy vTeacherBusy in this.TeacherBusys)
                    {
                        if (vTeacherBusy.Weekday.Equals(vWeekday))
                        {
                            PeriodSetting vPeriodSetting = periods.Find(x => x.Period.Equals(vPeriod));

                            if (vPeriodSetting != null)
                            {
                                if (vPeriodSetting.IsIntersect(vTeacherBusy))
                                {
                                    RemoveBusys.Add(vTeacherBusy);
                                } 
                            }
                        }
                    }

                    if (RemoveBusys.Count > 0)
                    {
 
                    }
                }
            }
        }

        private void itemSubject_Click(object sender, EventArgs e)
        {
            Control ctl = this.pnlContainer.GetChildAtPoint(this.pnlContainer.PointToClient(Control.MousePosition));

            if (ctl is PanelEx)
            {
                DecPeriod Period = ctl.Tag as DecPeriod;

                if (Period != null)
                {
                    List<CalendarRecord> Data = Period.Data as List<CalendarRecord>;

                    frmReplaceQuery ReplaceQuery = new frmReplaceQuery(Data);

                    if (!K12.Data.Utility.Utility.IsNullOrEmpty(Data))
                        ReplaceQuery.ShowDialog();
                }
            }
        }

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int BeepFreq, int BeepDuration);

        public bool IsCanMultipleExchange(List<CalendarRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return false;

            records = records
                .OrderBy(x => x.Weekday)
                .ThenBy(x=> x.Period)
                .ToList();

            string vWeeekday = records[0].Weekday;
            string vPeriod = records[0].Period;

            for (int i = 0; i < records.Count; i++)
            {
                if (!records[i].Weekday.Equals(vWeeekday))
                    return false;

                if (i >= 1)
                {
                    int PreviousPeriod = K12.Data.Int.Parse(records[i - 1].Period);
                    int CurrentPeriod = K12.Data.Int.Parse(records[i].Period);

                    if ((CurrentPeriod - 1) != PreviousPeriod)
                        return false;

                    if (!records[i].FullSubject.Equals(records[i - 1].FullSubject))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 當某一節次被按下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dec_OnPeriodClicked(object sender, PeriodEventArgs e)
        {
            if (sender is DecPeriod)
            {
                DecPeriod Period = (DecPeriod)sender;

                int WeekDay = e.Weekday;
                int PeriodNo = e.Period;

                //若是星期或節次小於或等於0則不繼續執行
                if (WeekDay <= 0 || PeriodNo <= 0) return;                

                #region 若為可調課顏色則進行調課
                if (Period.BackColor.Equals(SchedulerColor.lvSchedulableBackColor))
                {
                    List<CalendarRecord> vSrcCalendars = this.selectedCalendars;

                    List<CalendarRecord> vDesCalendars = new List<CalendarRecord>();

                    vDesCalendars.Add(Period.Data[0]);

                    #region 尋找相對應的行事曆
                    if (vSrcCalendars.Count > 1)
                    {
                        CalendarRecord vDesCalendar = Period.Data[0];

                        int intPeriod = K12.Data.Int.Parse(vDesCalendar.Period);

                        for (int i = 1; i < vSrcCalendars.Count; i++)
                        {
                            string NextPeriodKey = vDesCalendar.Weekday + "_" + (intPeriod + 1);  // +"_" + vDesCalendar.FullSubject + "_" + vDesCalendar.TeacherName;
                            string PrevPeriodKey = vDesCalendar.Weekday + "_" + (intPeriod - 1);  //+"_" + vDesCalendar.FullSubject + "_" + vDesCalendar.TeacherName;

                            if (decPeriods.ContainsKey(NextPeriodKey))
                            {
                                DecPeriod NextPeriod = decPeriods[NextPeriodKey];

                                CalendarRecord NextCalendar = NextPeriod.Data[0];

                                if (NextCalendar.FullSubject.Equals(vDesCalendar.FullSubject) &&
                                    NextCalendar.TeacherName.Equals(vDesCalendar.TeacherName))
                                {
                                    if (NextPeriod.BackColor == SchedulerColor.lvSchedulableBackColor)
                                        vDesCalendars.Add(NextPeriod.Data[0]);
                                }
                            }

                            if (decPeriods.ContainsKey(PrevPeriodKey))
                            {
                                DecPeriod PrevPeriod = decPeriods[PrevPeriodKey];

                                CalendarRecord PrevCalendar = PrevPeriod.Data[0];

                                if (PrevCalendar.FullSubject.Equals(vDesCalendar.FullSubject) &&
                                    PrevCalendar.TeacherName.Equals(vDesCalendar.TeacherName))
                                {

                                    if (PrevPeriod.BackColor == SchedulerColor.lvSchedulableBackColor)
                                        vDesCalendars.Add(PrevPeriod.Data[0]);
                                }
                            }
                        }
                    }
                    #endregion

                    //若來源事曆
                    if (vSrcCalendars.Count == vDesCalendars.Count)
                    {
                        frmExchangeConfirm ExchangeConfirm = new frmExchangeConfirm(vSrcCalendars, vDesCalendars);

                        if (ExchangeConfirm.ShowDialog() == DialogResult.OK)
                        {
                            List<ExchangeCalendarPair> Pairs = ExchangeConfirm.SelectedExchangeCalendarPairs;

                            List<string> NewSrcUIDs = new List<string>();

                            StringBuilder strBuilder = new StringBuilder();
                            StringBuilder strError = new StringBuilder();

                            foreach (ExchangeCalendarPair Pair in Pairs)
                            {
                                if (!K12.Data.Utility.Utility.IsNullOrEmpty(Pair.Calendar) &&
                                    !K12.Data.Utility.Utility.IsNullOrEmpty(Pair.ExchangeCalendar))
                                {
                                    string AbsenceName = ExchangeConfirm.AbsenceName;
                                    string Comment = ExchangeConfirm.Comment;
                                    bool NoRecord = ExchangeConfirm.NoRecord;

                                    Pair.Calendar = Pair.Calendar
                                        .OrderBy(x => x.Period)
                                        .ToList();

                                    Pair.ExchangeCalendar = Pair.ExchangeCalendar
                                        .OrderBy(x => x.Period)
                                        .ToList();

                                    try
                                    {
                                        for (int i = 0; i < Pair.Calendar.Count; i++)
                                        {
                                            Tuple<bool, string> result = Calendar.Instance.Exchange(
                                               Pair.Calendar[i],
                                               Pair.ExchangeCalendar[i],
                                               NoRecord,
                                               AbsenceName,
                                               Comment);

                                            if (!result.Item1)
                                                strError.AppendLine(result.Item2);
                                            else
                                            {
                                                strBuilder.AppendLine("《請假課程》");
                                                strBuilder.AppendLine(Pair.Calendar[i].ToString());
                                                strBuilder.AppendLine("《調課課程》");
                                                strBuilder.AppendLine(Pair.ExchangeCalendar[i].ToString());
                                                strBuilder.AppendLine("《假別註記》");
                                                strBuilder.AppendLine("假別：" + AbsenceName + ",註記：" + Comment);

                                                if (NoRecord)
                                                    strBuilder.AppendLine("*此筆調課為直接調課，未儲存調課記錄。");
                                            }
                                        }
                                    }
                                    catch (Exception ve)
                                    {
                                        MessageBox.Show("調課發生錯誤，詳細訊息如下。" + System.Environment.NewLine + ve.Message);
                                    }
                                }
                            }

                            if (strError.Length > 0)
                                MessageBox.Show(strError.ToString());

                            if (strBuilder.Length > 0)
                            {
                                FISCA.LogAgent.ApplicationLog.Log(Logs.調代課,Logs.調課作業, strBuilder.ToString());
                                MotherForm.SetStatusBarMessage("已成功執行調課！");
                                CalendarEvents.RaiseExchangeEvent();

                                List<string> SrcUIDs = new List<string>();

                                foreach (ExchangeCalendarPair Pair in Pairs)
                                {
                                    SrcUIDs.AddRange(Pair.Calendar.Select(x => x.UID));
                                }
                                
                                #region 是否列印調課單
                                if (ExchangeConfirm.IsPrint)
                                {

                                    QueryHelper vHelper = Utility.QueryHelper;

                                    string strSQL = "select uid from $scheduler.course_calendar where exchange_id in (" + string.Join(",", SrcUIDs.ToArray()) + ")";

                                    DataTable table = vHelper.Select(strSQL);

                                    if (table.Rows.Count > 0)
                                    {
                                        List<string> ExchangeIDs = new List<string>();

                                        foreach (DataRow row in table.Rows)
                                        {
                                            string ExchangeID = "" + row["uid"];

                                            ExchangeIDs.Add(ExchangeID);
                                        }

                                        List<CalendarRecord> records = Calendar.Instance.FindExchangeRecords(ExchangeIDs);

                                        Dictionary<string, List<CalendarRecord>> result = new Dictionary<string, List<CalendarRecord>>();

                                        foreach (CalendarRecord record in records)
                                        {
                                            string Key =
                                                record.StartDateTime.ToShortDateString() + "-" +
                                                record.FullSubject + "-" +
                                                record.TeacherName;

                                            if (!result.ContainsKey(Key))
                                                result.Add(Key, new List<CalendarRecord>());

                                            result[Key].Add(record);
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
                else if (
                    Period.IsBusy &&　
                    this.Type.Equals(CalendarType.Teacher))
                {
                    int vWeekday = Period.Weekday;
                    int vPeriod = Period.Period;

                    List<TeacherBusy> RemoveBusys = new List<TeacherBusy>();

                    if (!K12.Data.Utility.Utility.IsNullOrEmpty(this.TeacherBusys))
                    {
                        foreach (TeacherBusy vTeacherBusy in this.TeacherBusys)
                        {
                            int TeacherBusyWeekday = vTeacherBusy.StartDateTime.GetWeekday();

                            if (TeacherBusyWeekday.Equals(vWeekday))
                            {
                                PeriodSetting vPeriodSetting = periods.Find(x => x.Period.Equals(vPeriod));

                                if (vPeriodSetting != null)
                                {
                                    if (vPeriodSetting.IsIntersect(vTeacherBusy))
                                    {
                                        RemoveBusys.Add(vTeacherBusy);
                                    }
                                }
                            }
                        }
                    }

                    if (RemoveBusys.Count > 0)
                    {
                        StringBuilder strBuilder = new StringBuilder();
                        StringBuilder strSQL = new StringBuilder();
                        
                        strSQL.Append("select busy.uid,(CASE WHEN tea.nickname is null or tea.nickname='' THEN tea.teacher_name ELSE tea.teacher_name || '(' || tea.nickname || ')'  END) as teacher_name,begin_date_time,end_date_time from $scheduler.teacher_busy_date as busy inner join $scheduler.teacher_ex as tea on tea.uid=busy.ref_teacher_id where ");

                        foreach (TeacherBusy RemoveBusy in RemoveBusys)
                        {
                            strBuilder.AppendLine(RemoveBusy.ToString());
                            strSQL.Append("teacher_name='" + RemoveBusy.TeacherName + "' and begin_date_time='" + RemoveBusy.StartDateTime.GetDateTimeString() + "' and end_date_time='" + RemoveBusy.EndDateTime.GetDateTimeString() + "'");
                        }

                        if (MessageBox.Show("您是否要刪除以下的不調代時段（此動作將無法復原）？" + System.Environment.NewLine + 
                            strBuilder.ToString(), "刪除不調代時段提醒", MessageBoxButtons.YesNo) == 
                            DialogResult.Yes)
                        {
                            BackgroundWorker workder = new BackgroundWorker();

                            workder.DoWork += (vsender, ve) =>
                            {
                                QueryHelper mHelper = Utility.QueryHelper;

                                DataTable table = mHelper.Select(strSQL.ToString());

                                List<string> TeacherBusyIDs = new List<string>();

                                foreach (DataRow row in table.Rows)
                                {
                                    string UID = row.Field<string>("uid");
                                    TeacherBusyIDs.Add(UID);
                                }

                                UpdateHelper mUpdateHelper = new UpdateHelper();

                                StringBuilder strDelete = new StringBuilder();

                                strDelete.AppendLine("delete from $scheduler.teacher_busy_date where uid in (" + string.Join(",", TeacherBusyIDs.ToArray()) + ")");

                                int ExecuteCount = mUpdateHelper.Execute(strDelete.ToString());

                                ApplicationLog.Log(Logs.調代課 ,Logs.刪除不調代時段,strBuilder.ToString());
                            };

                            workder.RunWorkerCompleted += (vsender, ve) =>
                            {
                                if (ve.Error == null)
                                    CalendarEvents.RaiseWeekChangeEvent(this.Type,this.AssocID);
                                else
                                    MessageBox.Show(ve.Error.Message);
                            };

                            workder.RunWorkerAsync();
                        }
                    }
                }
                #endregion
                else
                {
                    #region 單選情況
                    List<CalendarRecord> CurrentSelectedCalendars = new List<CalendarRecord>();
                    CurrentSelectedCalendars.AddRange(e.Value);
                    #endregion

                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        foreach (string key in this.decPeriods.Keys)
                        {
                            if (this.decPeriods[key].IsSelected)
                                CurrentSelectedCalendars.AddRange(this.decPeriods[key].Data);
                        }
                    }

                    if (!IsCanMultipleExchange(CurrentSelectedCalendars))
                    {
                        CurrentSelectedCalendars.Clear();
                        CurrentSelectedCalendars.AddRange(e.Value);
                    }

                    this.SelectedCalendars = CurrentSelectedCalendars;
                    this.UpdateUI();

                    e.Value = CurrentSelectedCalendars;

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (vsender, ve) => CalendarEvents.RaisePeriodSelected(e);

                    worker.RunWorkerAsync();

                    //Cursor.Current = Cursors.WaitCursor;

                    //Cursor.Current = Cursors.Arrow;
                }
            }
            else if (sender is PictureBox)
            {
                PictureBox vPictureBox = sender as PictureBox;

                string strTag = "" + vPictureBox.Tag;

                int WeekDay = e.Weekday;
                int PeriodNo = e.Period;

                //若是星期或節次小於或等於0則不繼續執行
                if (WeekDay <= 0 || PeriodNo <= 0) return;

                if (strTag.Equals("delete"))
                {
                    //Cursor.Current = Cursors.WaitCursor;


                    //Cursor.Current = Cursors.Arrow;
                }
                else if (strTag.Equals("busy"))
                {

                }
                else
                {
                    //Cursor.Current = Cursors.WaitCursor;

                    //Cursor.Current = Cursors.Arrow;
                }
            }
            else if (sender is Label)
            {
                Label vLabel = sender as Label;

                string strTag = "" + vLabel.Tag;

                if (!string.IsNullOrEmpty(strTag))
                {
                    string[] strEvents = strTag.Split(new char[] { '：' });

                    if (strEvents.Length == 2)
                    {
                        string AssocType = strEvents[0];
                        string AssocID = strEvents[1];
                        string SelectedTab = MainForm.Instance.GetSelectedType();
                        List<CalendarRecord> CalendarRecords = new List<CalendarRecord>();

                        if (!string.IsNullOrEmpty(AssocType) && 
                            !string.IsNullOrEmpty(AssocID))
                        {
                            if (AssocType.Equals("Teacher"))
                            {
                                switch (SelectedTab)
                                {
                                    case "Teacher":
                                        MainForm.Instance.OpenTeacherCalendarContent(CalendarType.Teacher, AssocID, true);
                                        break;
                                    case "Class":
                                        MainForm.Instance.OpenClassCalendarContent(CalendarType.Teacher, AssocID, true);
                                        break;
                                    case "Classroom":
                                        MainForm.Instance.OpenClassroomCalendarContent(CalendarType.Teacher, AssocID, true);
                                        break;
                                }
                            }
                            else if (AssocType.Equals("Class"))
                            {
                                switch (SelectedTab)
                                {
                                    case "Teacher":
                                        MainForm.Instance.OpenTeacherCalendarContent(CalendarType.Class,AssocID,true);
                                        break;
                                    case "Class":
                                        MainForm.Instance.OpenClassCalendarContent(CalendarType.Class, AssocID, true);
                                        break;
                                    case "Classroom":
                                        MainForm.Instance.OpenClassroomCalendarContent(CalendarType.Class, AssocID, true);
                                        break;
                                }
                            }
                            else if (AssocType.Equals("Classroom"))
                            {
                                switch (SelectedTab)
                                {
                                    case "Teacher":
                                        MainForm.Instance.OpenTeacherCalendarContent(CalendarType.Classroom, AssocID, true);
                                        break;
                                    case "Class":
                                        MainForm.Instance.OpenClassCalendarContent(CalendarType.Classroom, AssocID, true);
                                        break;
                                    case "Classroom":
                                        MainForm.Instance.OpenClassroomCalendarContent(CalendarType.Classroom, AssocID, true);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        #region property
        /// <summary>
        /// 行事曆類別
        /// </summary>
        public CalendarType Type
        {
            get { return mCalendarType; }
            set
            {
                mCalendarType = value;

                if (mCalendarType == CalendarType.Teacher)
                    mOption = CalendarOption.GetTeacherOption();
                else if (mCalendarType == CalendarType.Class)
                    mOption = CalendarOption.GetClassOption();
                else if (mCalendarType == CalendarType.Classroom)
                    mOption = CalendarOption.GetClassroomOption();
            }
        }

        /// <summary>
        /// 資源名稱
        /// </summary>
        public string AssocID
        {
            set 
            {
                mAssocID = value;
            }
            get
            {
                //this.selectedCalendars = new List<CalendarRecord>();
                return mAssocID;
            }
        }

        /// <summary>
        /// 教師不調代時段
        /// </summary>
        public List<TeacherBusy> TeacherBusys { get; set; }

        /// <summary>
        /// 班級不調代時段
        /// </summary>
        public List<ClassBusy> ClassBusys { get; set; }

        /// <summary>
        /// 指定選取行事曆
        /// </summary>
        public List<CalendarRecord> SelectedCalendars
        {
            get { return this.selectedCalendars; }
            set
            {
                if (value == null)
                    return;
                this.selectedCalendars = value;
            }
        }
        #endregion

        #region ==== Methods ======
         
        /* 重新調整大小 */
        public void Resize()
        {
            this.RedrawGrid();
        }
        #endregion

        #region ======= private functions =======
        private DevComponents.DotNetBar.PanelEx makePanel(string name, string txt, Point location, Size size)
        {
            DevComponents.DotNetBar.PanelEx pnl = PanelPool.Instance.GetPanel();
            pnl.CanvasColor = System.Drawing.SystemColors.Control;
            pnl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            pnl.Location = location;
            pnl.Name = name;
            pnl.Size = size;
            pnl.Style.Alignment = System.Drawing.StringAlignment.Center;
            pnl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            pnl.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            pnl.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            pnl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            pnl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            pnl.Style.GradientAngle = 90;
            pnl.TabIndex = 1;
            pnl.Text = txt;

            if ((name.EndsWith("4") && !name.StartsWith("header")) ||
                name.Equals("header_4_0"))
            {
                Panel pnlBorder = new Panel();

                pnlBorder.Height = 3;
                pnlBorder.Dock = DockStyle.Bottom;
                pnlBorder.BackColor = Color.PowderBlue;

                pnl.Controls.Add(pnlBorder);
            }

            return pnl;
        }
        #endregion

        /// <summary>
        /// 根據TimeTable.Periods的MaxWeekDay來決定顯示的欄位
        /// </summary>
        private void RedrawGrid()
        {
            if (this.pnlContainer == null)
                return;

            Stopwatch mWatch = Stopwatch.StartNew();

            if (K12.Data.Utility.Utility.IsNullOrEmpty(this.periods))
                this.periods = Utility.GetPeriodList(string.Empty);

            //hide all Cells
            foreach (string key in this.cells.Keys)
                this.cells[key].Visible = false;

            this.pnlContainer.SuspendLayout();
            this.pnlContainer.Controls.Clear();

            int pnlWidth = (this.pnlContainer.Size.Width - this.rowHeaderWidth) / this.weekday;
            int pnlHeight = (this.pnlContainer.Size.Height - this.colHeaderHeight) / this.periods.Count;

            #region Create Headers
            //建立星期物件
            for (int i = 0; i < this.weekday; i++)
            {
                Point p = new Point(rowHeaderWidth + i * pnlWidth, 0);
                Size s = new Size(pnlWidth, colHeaderHeight);
                string name = string.Format("header_0_{0}", (i + 1).ToString());
                DevComponents.DotNetBar.PanelEx pnl = null;
                if (this.headerCells.ContainsKey(name))
                {
                    pnl = this.headerCells[name];
                    pnl.Location = p;
                    pnl.Size = s;
                    pnl.Visible = true;
                }
                else
                {
                    pnl = this.makePanel(name, (i + 1).ToString(), p, s);
                    this.headerCells.Add(name, pnl);
                }
                this.pnlContainer.Controls.Add(pnl);
            }

            //建立節次物件
            for (int j = 0; j < this.periods.Count; j++)
            {
                Point p = new Point(0, colHeaderHeight + j * pnlHeight);
                Size s = new Size(rowHeaderWidth, pnlHeight);
                string name = string.Format("header_{0}_0", "" + this.periods[j].Period);
                DevComponents.DotNetBar.PanelEx pnl = null;
                if (this.headerCells.ContainsKey(name))
                {
                    pnl = this.headerCells[name];
                    pnl.Location = p;
                    pnl.Size = s;
                    pnl.Visible = true;
                }
                else
                {
                    pnl = this.makePanel(name, "" + this.periods[j].Period, p, s);

                    string time = string.Format("{0} - {1}", new object[] { this.periods[j].StartTime.ToShortTimeString(), 
                    this.periods[j].StartTime.AddMinutes(this.periods[j].Duration).ToShortTimeString() });

                    System.Windows.Forms.ToolTip vTooltip = new System.Windows.Forms.ToolTip();
                    vTooltip.SetToolTip(pnl, time);

                    this.headerCells.Add(name, pnl);
                }
                this.pnlContainer.Controls.Add(pnl);
            }
            #endregion

            #region Originize Cells
            for (int i = 0; i < this.weekday; i++)
            {
                for (int j = 0; j <  this.periods.Count; j++)
                {
                    string name = string.Format("{0}_{1}", (i + 1).ToString(),this.periods[j].Period);
                    Point p = new Point(rowHeaderWidth + i * pnlWidth, colHeaderHeight + j * pnlHeight);
                    Size s = new Size(pnlWidth, pnlHeight);

                    DevComponents.DotNetBar.PanelEx pnl = null;
                    if (this.cells.ContainsKey(name))
                    {
                        pnl = this.cells[name];
                        pnl.Location = p;
                        pnl.Size = s;
                        pnl.Visible = true;
                    }
                    else
                    {
                        pnl = this.makePanel(name, "", p, s);
                        this.cells.Add(name, pnl);
                        DecPeriod dec = new DecPeriod(pnl, i + 1, this.periods[j].Period,Type);
                        dec.BackColor = Color.White;
                        this.decPeriods.Add(name, dec);
                        dec.OnPeriodClicked += new PeriodClickedHandler(dec_OnPeriodClicked);
                    }

                    this.pnlContainer.Controls.Add(pnl);
                }
            }
            #endregion

            this.pnlContainer.ResumeLayout();

            mWatch.Stop();
        }

        /// <summary>
        /// 確認行事曆間是否有交集
        /// </summary>
        /// <param name="SrcRecord"></param>
        /// <param name="DesRecords"></param>
        /// <returns></returns>
        private bool IsIntersect(CalendarRecord SrcRecord, List<CalendarRecord> DesRecords)
        {
            foreach (CalendarRecord record in DesRecords)
            {
                if (SrcRecord.IsIntersect(record))
                    return true; 
            }

            return false;
        }

        /// <summary>
        /// 確認行事曆與教師不調代時段是否有交集
        /// </summary>
        /// <param name="TeacherBusy"></param>
        /// <param name="DesRecords"></param>
        /// <returns></returns>
        private bool IsIntersect(TeacherBusy TeacherBusy, List<CalendarRecord> DesRecords)
        {
            foreach (CalendarRecord record in DesRecords)
            {
                if (record.IsIntersect(TeacherBusy))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 加強版，取得調課行事曆
        /// </summary>
        /// <param name="mSelectedCalendars"></param>
        /// <returns></returns>
        private List<CalendarRecord> GetExchangeRecords(List<CalendarRecord> mSelectedCalendars)
        {
            #region 進行空值檢查
            if (K12.Data.Utility.Utility.IsNullOrEmpty(mSelectedCalendars))
                return new List<CalendarRecord>();

            List<CalendarRecord> RemoveLockRecords = new List<CalendarRecord>();

            //特別注意兩節狀態，若有一節鎖定，就會沒辦法調課
            foreach (CalendarRecord vCalendar in mSelectedCalendars)
            {
                if (vCalendar.Lock.Trim().Equals("是"))
                    return new List<CalendarRecord>();
            }

            //RemoveLockRecords.ForEach(x => mSelectedCalendars.Remove(x));

            if (K12.Data.Utility.Utility.IsNullOrEmpty(mSelectedCalendars))
                return new List<CalendarRecord>();
            #endregion

            Stopwatch mWatch = Stopwatch.StartNew();

            //CalendarRecord vAbsenceCalendar = mSelectedCalendars[0];

            int StartWeekday = mSelectedCalendars[0].StartDateTime.GetWeekday();

            //針對在指定日期區間(由Client決定)內的這個班級的課程分段的所有教師和場地。
            DateTime ExchangeStartDate = mSelectedCalendars[0].StartDateTime.ToDayStart();
            DateTime ExchangeEndDate = mSelectedCalendars[0].StartDateTime.AddDays(7 - StartWeekday).ToDayEnd();

            //1.尋找請假班級在區間內所有行事曆
            List<CalendarRecord> RelatedRecords = this.relatedDataSource;

            List<TeacherBusy> AllTeacherBusys = this.relatedTeacherBusys;

            //取得班級行事曆
            List<CalendarRecord> ClassRecords = RelatedRecords
                .FindAll(x => x.ClassName.Equals(mSelectedCalendars[0].ClassName));

            #region 尋找班級行事曆中所有的教師及場地
            //3.尋找班級行事曆中所有的教師
            List<string> TeachersNames = ClassRecords
                .Select(x => x.TeacherName)
                .Distinct()
                .ToList();


            //4.尋找班級行事曆中所有的場地
            List<string> ClassroomNames = ClassRecords
                .Where(x => !string.IsNullOrEmpty(x.ClassroomName))
                .Select(x => x.ClassroomName)
                .Distinct()
                .ToList();
            #endregion

            //5.尋找選取行事曆有交集的行事曆
            List<CalendarRecord> IntersectRecords = RelatedRecords
                .FindAll(x => IsIntersect(x, mSelectedCalendars));

            //6.尋找有交集的教師系統編號
            List<string> IntersectTeacherNames = IntersectRecords
                .Select(x => x.TeacherName)
                .Distinct()
                .ToList();

            //7.尋找有交集的場地名稱
            List<string> IntersectClassrooms = IntersectRecords
                .Where(x => !string.IsNullOrEmpty(x.ClassroomName))
                .Select(x => x.ClassroomName)
                .Distinct()
                .ToList();

            //9.尋找在指定日期時間區間內，有教師不調代時段的老師

            #region 檢查選取行事曆，是否有教師不調代時段，有的話該老師就不能調過來
            List<TeacherBusy> TeacherBusys = new List<TeacherBusy>();

            foreach (CalendarRecord Calendar in mSelectedCalendars)
            {
    //            List<TeacherBusy> FindTeacherBusys = AllTeacherBusys
    //.FindAll(x => Calendar.IsIntersect(x) &&
    //    x.TeacherName.Equals(Calendar.TeacherName));

                List<TeacherBusy> FindTeacherBusys = AllTeacherBusys
                    .FindAll(x => Calendar.IsIntersect(x));

                TeacherBusys.AddRange(FindTeacherBusys);
            }

            IEnumerable<string> BusyTeacherNames = TeacherBusys.Select(x => x.TeacherName);
            #endregion

            //8.將教師及場地自行事曆中去除。
            List<CalendarRecord> RemoveRecords = ClassRecords.FindAll(x =>
                IntersectTeacherNames.Contains(x.TeacherName) ||
                IntersectClassrooms.Contains(x.ClassroomName) ||
                BusyTeacherNames.Contains(x.TeacherName));

            //10.將班級課表無法調課的行事曆移除，OK
            RemoveRecords.ForEach(x => ClassRecords.Remove(x));

            if (ClassRecords.Count > 0)
            {
                //檢查請假課程可否調到調課課程，在請假課程中的教師及場地有否衝突
                //關鍵在於IsIntersect(x,ClassRecords)
                List<CalendarRecord> TargetRecords = RelatedRecords
                    .FindAll(x=>
                        (
                            x.TeacherName.Equals(mSelectedCalendars[0].TeacherName)
                            || (!string.IsNullOrEmpty(x.ClassroomName) && x.ClassroomName.Equals(mSelectedCalendars[0].ClassroomName))
                        )
                        && IsIntersect(x,ClassRecords));

                //尋找請假課程教師，在調課課程中是否有不調代時段
                List<TeacherBusy> vTeacherBusys = AllTeacherBusys
                    .FindAll(x => IsIntersect(x, ClassRecords));

                List<CalendarRecord> RemoveTargetRecords = new List<CalendarRecord>();

                //針對每筆可能調課的行事曆
                foreach (CalendarRecord vCalendar in ClassRecords)
                {
                    foreach (CalendarRecord vTargetCalendar in TargetRecords)
                    {
                        if (vCalendar.IsIntersect(vTargetCalendar))
                        {
                            if (!RemoveTargetRecords.Contains(vCalendar))
                                RemoveTargetRecords.Add(vCalendar);
                        }
                    }

                    #region 針對不調代時段做檢查，檢查要調過去的課程行事曆（使用者選取的行事曆）；當中是否有來源教師（使用者選取的行事曆教師）的不調代時段在。
                    foreach (TeacherBusy vTeacherBusy in vTeacherBusys)
                    {
                        if (vCalendar.IsIntersect(vTeacherBusy))
                        {
                            if (mSelectedCalendars[0].TeacherName.Equals(vTeacherBusy.TeacherName))
                            {
                                if (!RemoveTargetRecords.Contains(vCalendar))
                                    RemoveTargetRecords.Add(vCalendar);
                            }
                        }
                    }
                    #endregion
                }

                RemoveTargetRecords.ForEach(x => ClassRecords.Remove(x));

                //針對多節調課做處理
                if (mSelectedCalendars.Count > 1)
                {
                    Dictionary<string, List<CalendarRecord>> GroupCalendars = new Dictionary<string, List<CalendarRecord>>();

                    foreach (CalendarRecord record in ClassRecords)
                    {
                        string CalendarKey = record.Weekday + "_" + record.FullSubject + "_" + record.TeacherName + "_" + record.ClassroomName;

                        if (!GroupCalendars.ContainsKey(CalendarKey))
                            GroupCalendars.Add(CalendarKey, new List<CalendarRecord>());

                        GroupCalendars[CalendarKey].Add(record);
                    }

                    List<CalendarRecord> RemoveCalendars = new List<CalendarRecord>();

                    foreach (string Key in GroupCalendars.Keys)
                    {
                        List<CalendarRecord> records = GroupCalendars[Key];

                        //改過這裡
                        if (records.Count != mSelectedCalendars.Count)
                            RemoveCalendars.AddRange(records);
                        else
                        {
                            records = records.OrderBy(x => x.Period).ToList();

                            bool IsContinue = true;

                            for (int i = 1; i < records.Count; i++)
                            {
                                int PrevPeriod = K12.Data.Int.Parse(records[i].Period) - 1;

                                if (!records[i - 1].Period.Equals("" + PrevPeriod))
                                    IsContinue = false;
                            }

                            if (!IsContinue)
                                records.ForEach(x => RemoveCalendars.Add(x));
                        }
                    }

                    RemoveCalendars.ForEach(x => ClassRecords.Remove(x));
                }
            }

            mWatch.Stop();

            //Console.WriteLine(mWatch.ElapsedMilliseconds);

            List<CalendarRecord> LockRecords = new List<CalendarRecord>();

            foreach (CalendarRecord Record in ClassRecords)
            {
                if (Record.Lock.Equals("是") ||
                    Record.Lock.ToUpper().Equals("Y") ||
                    Record.Lock.ToUpper().Equals("YES"))
                    LockRecords.Add(Record);                
            }

            LockRecords.ForEach(x => ClassRecords.Remove(x));

            return ClassRecords;
        }

        public void InitialUI()
        {
            lblName.Text = string.Empty;
            this.AssocID = string.Empty;

            #region 將所有節次先清空；注意，一開始設定為灰色；當時間表有在內容當中才設為白色
            foreach (DecPeriod Period in this.decPeriods.Values)
                Period.InitialContent(mOption);
            #endregion

            //清空教師及班級不調代時段
            this.TeacherBusys = new List<TeacherBusy>();
            this.ClassBusys = new List<ClassBusy>();
        }

        public void UpdateUI()
        {
            Stopwatch vStopwatch = Stopwatch.StartNew();

            if (this.dataSource == null)
                return;

            this.pnlContainer.SuspendLayout();

            try
            {

                DateTime NextDate = SchoolYearSemesterOption.Instance.EndDate.AddDays(7).ToDayStart();
                DateTime PreviousDate = SchoolYearSemesterOption.Instance.StartDate.AddDays(-7).ToDayStart();

                DateTime SchoolYearSemesterEndDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterEndDate.StartOfWeek(DayOfWeek.Monday).AddDays(6).ToDayStart();
                DateTime SchoolYearSemesterStartDate = SchoolYearSemesterOption.Instance.SchoolYearSemesterStartDate.StartOfWeek(DayOfWeek.Monday).ToDayStart();

                btnNext.Enabled = NextDate <= SchoolYearSemesterEndDate;
                btnPrevious.Enabled = PreviousDate >= SchoolYearSemesterStartDate;
                btnCurrent.Enabled = DateTime.Today >= SchoolYearSemesterStartDate && DateTime.Today <= SchoolYearSemesterEndDate;

                lblName.Text = Utility.GetAssocNote(this.mCalendarType, this.mAssocID);
                txtStartDate.Text = SchoolYearSemesterOption.Instance.StartDate.Month + "/" + SchoolYearSemesterOption.Instance.StartDate.Day;
                lblEndDate.Text = "~" + SchoolYearSemesterOption.Instance.EndDate.Month + "/" + SchoolYearSemesterOption.Instance.EndDate.Day;

                List<string> Weekdays = new List<string>() { "週一", "週二", "週三", "週四", "週五", "週六", "週日" };

                //建立星期物件
                for (int i = 0; i < this.weekday; i++)
                {
                    string name = string.Format("header_0_{0}", (i + 1).ToString());
                    if (this.headerCells.ContainsKey(name))
                    {
                        PanelEx pnl = this.headerCells[name];

                        DateTime CurrentDate = SchoolYearSemesterOption.Instance.StartDate.AddDays(i);
                        pnl.Text = CurrentDate.ToMonthDay() + "(" + Weekdays[i] + ")";
                    }
                }

                #region 將所有節次先清空；注意，一開始設定為灰色；當時間表有在內容當中才設為白色
                foreach (DecPeriod Period in this.decPeriods.Values)
                {
                    Period.InitialContent(mOption);

                    if (Period.IsSelected)
                        Period.RebindEvent();
                }
                #endregion

                #region 將所有資料來源填入，並處理點選狀態
                List<string> SelectedCalendarUIDs = new List<string>();

                if (this.selectedCalendars != null)
                    SelectedCalendarUIDs = this.selectedCalendars
                    .Select(x => x.UID)
                    .ToList();

                foreach (CalendarRecord vCalendar in this.dataSource)
                {
                    string name = vCalendar.Weekday + "_" + vCalendar.Period;

                    if (decPeriods.ContainsKey(name))
                    {
                        DecPeriod decPeriod = decPeriods[name];
                        decPeriod.Data = new List<CalendarRecord>() { vCalendar };
                        decPeriod.IsSelected = SelectedCalendarUIDs.Contains(vCalendar.UID);
                    }
                }
                #endregion

                #region 填入教師不調代時段
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(this.TeacherBusys))
                {
                    foreach (TeacherBusy vBusy in this.TeacherBusys)
                    {
                        foreach (PeriodSetting Period in this.periods)
                        {
                            if (Period.IsIntersect(vBusy))
                            {
                                string name = vBusy.Weekday + "_" + Period.Period;

                                if (decPeriods.ContainsKey(name))
                                {
                                    DecPeriod decPeriod = decPeriods[name];
                                    decPeriod.SetAsBusy(vBusy.Description);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 填入班級不調代時段
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(this.ClassBusys))
                {
                    foreach (ClassBusy vBusy in this.ClassBusys)
                    {
                        foreach (PeriodSetting Period in this.periods)
                        {
                            if (Period.IsIntersect(vBusy))
                            {
                                string name = vBusy.Weekday + "_" + Period.Period;

                                if (decPeriods.ContainsKey(name))
                                {
                                    DecPeriod decPeriod = decPeriods[name];
                                    decPeriod.SetAsBusy(vBusy.Description);
                                }
                            }
                        }
                    }
                }
                #endregion

                if (Type == CalendarType.Class)
                {
                    #region 取得調課行事曆
                    List<CalendarRecord> vExchangeRecords = GetExchangeRecords(this.SelectedCalendars);

                    foreach (CalendarRecord vCalendar in vExchangeRecords)
                    {
                        string name = vCalendar.Weekday + "_" + vCalendar.Period;

                        if (decPeriods.ContainsKey(name))
                        {
                            DecPeriod decPeriod = decPeriods[name];

                            if (!K12.Data.Utility.Utility.IsNullOrEmpty(decPeriod.Data))
                            {
                                //判斷行事曆是否相同才設為可排課
                                if (decPeriod.Data[0].ClassName.Equals(vCalendar.ClassName) &&
                                   decPeriod.Data[0].TeacherName.Equals(vCalendar.TeacherName) &&
                                   decPeriod.Data[0].ClassroomName.Equals(vCalendar.ClassroomName) &&
                                   decPeriod.Data[0].Subject.Equals(vCalendar.Subject))
                                {
                                    decPeriod.BackColor = SchedulerColor.lvSchedulableBackColor;
                                }
                            }
                        }
                    }
                    #endregion
                }

                vStopwatch.Stop();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            this.pnlContainer.ResumeLayout();

            //Console.WriteLine(vStopwatch.Elapsed.TotalMilliseconds); 
        }

        /// <summary>
        /// 進行更新內容
        /// </summary>
        public void UpdateContent()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, e) =>
            {
                Stopwatch mWatch = Stopwatch.StartNew();

                if (this.Type.Equals(CalendarType.Teacher))
                {
                    this.dataSource = Utility.GetTeacherCalendars(this.AssocID, SchoolYearSemesterOption.Instance.StartDate, SchoolYearSemesterOption.Instance.EndDate);

                    if (!string.IsNullOrWhiteSpace(AssocID))
                    {
                        TeacherBusys = Calendar.Instance.FindBusyTeacher(new List<string>(){this.AssocID}, SchoolYearSemesterOption.Instance.StartDate, SchoolYearSemesterOption.Instance.EndDate);
                    }
                }
                else if (this.Type.Equals(CalendarType.Class))
                {
                    List<CalendarRecord> ClassRelatedRecords = Calendar.Instance
                        .FindExchangeRelated(AssocID, SchoolYearSemesterOption.Instance.StartDate,
                        SchoolYearSemesterOption.Instance.EndDate);

                    List<CalendarRecord> BlankRecords = ClassRelatedRecords
                        .FindAll(x => x.TeacherName.Equals(string.Empty));

                    foreach (CalendarRecord vCalendar in ClassRelatedRecords)
                    {
                        if (!string.IsNullOrWhiteSpace(vCalendar.ReplaceID))
                        {
                            if (!string.IsNullOrWhiteSpace(vCalendar.TeacherName))
                                vCalendar.Status = "代課";
                            else
                                vCalendar.Status = "代課";
                        }
                        else if (!string.IsNullOrWhiteSpace(vCalendar.ExchangeID))
                            vCalendar.Status = "調課";
                    }

                    this.relatedDataSource = ClassRelatedRecords;

                    this.dataSource = ClassRelatedRecords
                        .FindAll(x => x.ClassName.Equals(AssocID));

                    this.ClassBusys = Calendar.Instance.FindBusyClass(
                        new List<string>(){AssocID}, 
                        SchoolYearSemesterOption.Instance.StartDate,
                        SchoolYearSemesterOption.Instance.EndDate);

                    List<string> TeacherNames = this.dataSource.Select(x=>x.TeacherName).Distinct().ToList();

                    this.relatedTeacherBusys = Calendar.Instance.FindBusyTeacher(
                        TeacherNames, 
                        SchoolYearSemesterOption.Instance.StartDate, 
                        SchoolYearSemesterOption.Instance.EndDate);

                    mWatch.Stop();
                }
                else if (this.Type.Equals(CalendarType.Classroom))
                {
                    this.dataSource = Utility.GetPlaceCalendars(this.AssocID, SchoolYearSemesterOption.Instance.StartDate, SchoolYearSemesterOption.Instance.EndDate); 
                }

                //FISCA.RTOut.WriteLine("資料時間：" + mWatch.ElapsedMilliseconds);
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                Stopwatch mWatch = Stopwatch.StartNew();

                UpdateUI();

                mWatch.Stop();

                //FISCA.RTOut.WriteLine("顯示時間：" + mWatch.ElapsedMilliseconds);
            };

            worker.RunWorkerAsync();
        }
    }
}