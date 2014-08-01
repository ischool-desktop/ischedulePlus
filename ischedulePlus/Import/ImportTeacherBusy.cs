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
    /// <summary>
    /// 匯入教師不排課時段
    /// </summary>
    public class ImportTeacherBusy : ImportWizard
    {
        private const string constTeacehrName = "教師姓名";
        private const string constTeacherNickName = "教師暱稱";
        private const string constDate = "日期";
        private const string constStartTime = "開始時間";
        private const string constEndTime = "結束時間";
        private const string constBusyDesc = "不調代描述";

        private ImportOption mOption;
        private AccessHelper mHelper;
        private Dictionary<string, string> mTeacherNameIDs = new Dictionary<string, string>();
        private StringBuilder mstrLog = new StringBuilder();
        private Task mTask;

        /// <summary>
        /// 建構式
        /// </summary>
        public ImportTeacherBusy()
        {
            this.CustomValidate += (Rows, Messages) => new TeacherBusyTimeConflictHelper(Rows, Messages).CheckTimeConflict();
        }

        /// <summary>
        /// 取得驗證規則
        /// </summary>
        /// <returns></returns>
        public override string GetValidateRule()
        {
            return "http://sites.google.com/a/kunhsiang.com/sunset/home/yan-zheng-gui-ze/TeacherBusyDate.xml";
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
            mTask = Task.Factory.StartNew
            (() =>
            {
                QueryHelper Helper = Utility.QueryHelper;

                DataTable Table = Helper.Select("select id,teacher_name,nickname from teacher");

                foreach (DataRow Row in Table.Rows)
                {
                    string TeacherID = Row.Field<string>("id");
                    string TeacherName = Row.Field<string>("teacher_name");
                    string TeacherNickname = Row.Field<string>("nickname");
                    string TeacherKey = TeacherName +","+TeacherNickname;

                    if (!mTeacherNameIDs.ContainsKey(TeacherKey))
                        mTeacherNameIDs.Add(TeacherKey,TeacherID);
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

            if (mOption.SelectedKeyFields.Count == 4 && 
                mOption.SelectedKeyFields.Contains(constTeacehrName) && 
                mOption.SelectedKeyFields.Contains(constTeacherNickName) && 
                mOption.SelectedKeyFields.Contains(constDate) && 
                mOption.SelectedKeyFields.Contains(constStartTime))
            {
                if (mOption.Action == ImportAction.InsertOrUpdate)
                {
                    #region Step2:針對每筆匯入資料檢查，轉換成對應的TeacherBusy，並且組合成查詢條件
                    List<string> TeacherBusyConditions = new List<string>();
                    Dictionary<TeacherBusyDate,IRowStream> TeachyBusyRowStreams = new Dictionary<TeacherBusyDate,IRowStream>();

                    foreach (IRowStream Row in Rows)
                    {
                        string TeacherName = Row.GetValue(constTeacehrName);
                        string TeacherNickName = Row.GetValue(constTeacherNickName);
                        DateTime Date = K12.Data.DateTimeHelper.ParseDirect(Row.GetValue(constDate));
                        string StartTime = Row.GetValue(constStartTime);
                        string EndTime = Row.GetValue(constEndTime);

                        Tuple<DateTime, int> StorageTime = Utility.GetStorageTime(StartTime,EndTime);

                        //取得完整的開始日期時間
                        DateTime BeginDatetime = new DateTime(
                            Date.Year, Date.Month, Date.Day, 
                            StorageTime.Item1.Hour, StorageTime.Item1.Minute, 0);
                        int Duration = StorageTime.Item2;

                        //根據『教師姓名』及『教師暱稱』尋找是否有對應的『教師』
                        string TeacherKey = TeacherName + "," + TeacherNickName;
                        string TeacherID = mTeacherNameIDs.ContainsKey(TeacherKey) ? mTeacherNameIDs[TeacherKey] : string.Empty;

                        //若有找到『教師』才可匯入
                        if (!string.IsNullOrEmpty(TeacherID))
                        {
                            //根據『教師系統編號』、『星期』及『開始時間』
                            string TeacherBusyCondition = "(ref_teacher_id="+TeacherID+" and begin_date_time='"+BeginDatetime.GetDateTimeString()+"')";                             
                            TeacherBusyConditions.Add(TeacherBusyCondition);

                            TeacherBusyDate vTeacherBusy = new TeacherBusyDate();
                            vTeacherBusy.TeacherID = K12.Data.Int.Parse(TeacherID);
                            vTeacherBusy.BeginDateTime = BeginDatetime;
                            vTeacherBusy.EndDateTime = BeginDatetime.AddMinutes(Duration);
                            vTeacherBusy.BusyDesc = string.Empty;

                            if (mOption.SelectedFields.Contains(constBusyDesc))
                            {
                                string TeacherBusyDesc = Row.GetValue(constBusyDesc);
                                vTeacherBusy.BusyDesc = TeacherBusyDesc;
                            }

                            if (!TeachyBusyRowStreams.ContainsKey(vTeacherBusy))
                                TeachyBusyRowStreams.Add(vTeacherBusy,Row);
                        }
                    }
                    #endregion

                    #region Step3:組合查詢條件，並選出系統中已存在的教師不排課時段
                    List<TeacherBusyDate> ExistTeacherBusys = new List<TeacherBusyDate>();
                    
                    string strCondition = string.Join(" or ", TeacherBusyConditions.ToArray());

                    string strUDTCondition = Utility.SelectIDCondition("$scheduler.teacher_busy_date", strCondition);

                    ExistTeacherBusys = new List<TeacherBusyDate>();
                    
                    if (!string.IsNullOrWhiteSpace(strUDTCondition))
                        ExistTeacherBusys = mHelper.Select<TeacherBusyDate>(strUDTCondition);
                    #endregion

                    #region Step4:根據轉換的結構及已選出的系統資料決定新增及更新的記錄
                    List<TeacherBusyDate> InsertRecords = new List<TeacherBusyDate>();
                    List<TeacherBusyDate> UpdateRecords = new List<TeacherBusyDate>();

                    foreach (TeacherBusyDate TeacherBusy in TeachyBusyRowStreams.Keys)
                    {
                        TeacherBusyDate ExistTeacherBusy = ExistTeacherBusys.Find(x => 
                            x.TeacherID.Equals(TeacherBusy.TeacherID) && 
                            DateTime.Equals(x.BeginDateTime,TeacherBusy.BeginDateTime));

                        if (ExistTeacherBusy != null)
                        {
                            ExistTeacherBusy.EndDateTime = TeacherBusy.EndDateTime;

                            if (mOption.SelectedFields.Contains(constBusyDesc))
                                ExistTeacherBusy.BusyDesc = TeacherBusy.BusyDesc;

                            UpdateRecords.Add(ExistTeacherBusy);
                        }
                        else
                            InsertRecords.Add(TeacherBusy);
                    }
                    #endregion

                    #region Step5:將資料實際新增到資料庫，並且做Log
                    if (InsertRecords.Count > 0)
                    {
                        mHelper.InsertValues(InsertRecords);
                        mstrLog.AppendLine("已成功新增"+InsertRecords.Count+"筆教師不調代時段");
                    }
                    if (UpdateRecords.Count > 0)
                    {
                        mHelper.UpdateValues(UpdateRecords);
                        mstrLog.AppendLine("已成功更新"+UpdateRecords.Count +"筆教師不調代時段");
                    }
                    #endregion
                }
                else if (mOption.Action == ImportAction.Delete)
                {
                    //#region Step1:針對每筆匯入資料轉換成鍵值條件。
                    //List<string> TeacherBusyConditions = new List<string>();

                    //foreach (IRowStream Row in Rows)
                    //{
                    //    string TeacherName = Row.GetValue(constTeacehrName);
                    //    string TeacherNickName = Row.GetValue(constTeacherNickName);
                    //    DateTime Date = K12.Data.DateTimeHelper.ParseDirect(Row.GetValue(constDate));
                    //    int StartHour = K12.Data.Int.Parse(Row.GetValue(constStartTime));
                    //    int StartMinute = K12.Data.Int.Parse(Row.GetValue(constEndTime));
                    //    DateTime BeginDatetime = new DateTime(1900, 1, 1, StartHour, StartMinute, 0); //將小時及分鐘轉成實際的DateTime

                    //    //根據『教師姓名』及『教師暱稱』尋找是否有對應的『教師』
                    //    string TeacherKey = TeacherName + "," + TeacherNickName;
                    //    string TeacherID = mTeacherNameIDs.ContainsKey(TeacherKey) ? mTeacherNameIDs[TeacherKey] : string.Empty;

                    //    //若有找到『教師』才可匯入
                    //    if (!string.IsNullOrEmpty(TeacherID))
                    //    {
                    //        //根據『教師系統編號』、『星期』及『開始時間』
                    //        string TeacherBusyCondition = "(ref_teacher_id=" + TeacherID
                    //            + " and date='" + K12.Data.DateTimeHelper.ToDisplayString(Date)
                    //            + "' and begin_time='1900/1/1 " + StartHour + ":" + StartMinute + "')";
                    //        TeacherBusyConditions.Add(TeacherBusyCondition);
                    //    }
                    //}
                    //#endregion

                    //#region Step2:組合查詢條件，並選出系統中已存在的教師不排課時段
                    //string strCondition = string.Join(" or ", TeacherBusyConditions.ToArray());

                    //List<TeacherBusyDate> ExistTeacherBusys = mHelper.Select<TeacherBusyDate>(strCondition);
                    //#endregion

                    //#region Step3:若有找出的記錄，則加以刪除並記錄
                    //if (ExistTeacherBusys.Count > 0)
                    //{
                    //    mHelper.DeletedValues(ExistTeacherBusys);
                    //    mstrLog.AppendLine("已成功刪除"+ExistTeacherBusys.Count+"筆教師不排課時段。");
                    //}
                    //#endregion
                }
            }

            return mstrLog.ToString();
        }        
    }
}