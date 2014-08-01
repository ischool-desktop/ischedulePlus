using System;
using System.Collections.Generic;
using System.Data;
using FISCA.UDT;

namespace ischedulePlus
{
    /// <summary>
    /// 請假記錄集合
    /// </summary>
    public class AbsenceRecords : IEnumerable<AbsenceRecord>
    {
        private SortedDictionary<string, AbsenceRecord> mRecords = new SortedDictionary<string, AbsenceRecord>();

        /// <summary>
        /// 加入行事曆
        /// </summary>
        /// <param name="Calendar"></param>
        public void Add(CalendarRecord Calendar)
        {
            //必需要是代課記錄才可新增
            if (string.IsNullOrEmpty(Calendar.ReplaceID))
                return;

            //取得請假教師姓名
            string AbsTeacherName = Calendar.AbsTeacherName;

            //請得假別
            string AbsName = Calendar.AbsenceName;

            //取得請假日期
            DateTime Date = Calendar.StartDateTime.ToDayStart();

            string AbsKey = Date.ToString("MM/dd") + "," + AbsTeacherName; 
            
            #region 以請假教師為主新增記錄
            if (!mRecords.ContainsKey(AbsKey))
            {
                AbsenceRecord vAbsenceRecord = new AbsenceRecord();
                vAbsenceRecord.TeacherName = Calendar.AbsTeacherName;
                mRecords.Add(AbsKey, vAbsenceRecord);
            }
            #endregion

            //新增請假日期
            if (!mRecords[AbsKey].Dates.Contains(Date))
                mRecords[AbsKey].Dates.Add(Date);

            if (!string.IsNullOrWhiteSpace(AbsName))
                if (!mRecords[AbsKey].AbsenceNames.Contains(AbsName))
                {
                    mRecords[AbsKey].AbsenceNames.Add(AbsName);
                }

            //新增請假節數
            mRecords[AbsKey].AbsenceCount++;
            //新增代課教師
            if (!mRecords[AbsKey].Replaces.ContainsKey(Calendar.TeacherName))
                mRecords[AbsKey].Replaces.Add(Calendar.TeacherName, 0);
            //新增代課教師節數
            mRecords[AbsKey].Replaces[Calendar.TeacherName]++;
        }

        /// <summary>
        /// 輸出成明細
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            AccessHelper mHelper = Utility.AccessHelper;

            List<TeacherEx> Teachers =  mHelper.Select<TeacherEx>();

            Dictionary<string, TeacherEx> TeacherDics = new Dictionary<string, TeacherEx>();

            foreach (TeacherEx Teacher in Teachers)
            {
                if (!TeacherDics.ContainsKey(Teacher.TeacherName))
                    TeacherDics.Add(Teacher.TeacherName, Teacher);
            }

            DataTable Table = new DataTable("明細");

            Table.Columns.Add("日期");
            Table.Columns.Add("教師代碼");
            Table.Columns.Add("教師姓名");
            Table.Columns.Add(new DataColumn("請假", System.Type.GetType("System.Int32")));
            Table.Columns.Add(new DataColumn("代課", System.Type.GetType("System.Int32")));
            Table.Columns.Add("備註");

            #region 先輸出請假明細，再輸出代課明細
            foreach (AbsenceRecord record in this)
            {
                DataRow Row = Table.Rows.Add();

                string TeacherCode = TeacherDics.ContainsKey(record.TeacherName) ?
                    TeacherDics[record.TeacherName].TeacherCode : string.Empty;

                Row.SetField<string>("日期", record.DatesString);
                Row.SetField<string>("教師代碼", TeacherCode);
                Row.SetField<string>("教師姓名",record.TeacherName);
                Row.SetField<int>("請假",record.AbsenceCount);
                //Row.SetField<string>("代課", "");
                Row.SetField<string>("備註",string.Join(",",record.AbsenceNames.ToArray()));

                foreach (string Key in record.Replaces.Keys)
                {
                    DataRow SubRow = Table.Rows.Add();

                    string AbsTeacherCode = TeacherDics.ContainsKey(Key) ?
                        TeacherDics[Key].TeacherCode : string.Empty;

                    SubRow.SetField<string>("日期", string.Empty);
                    SubRow.SetField<string>("教師代碼", AbsTeacherCode);
                    SubRow.SetField<string>("教師姓名", Key);
                    //SubRow.SetField<string>("請假", string.Empty);
                    SubRow.SetField<int>("代課", record.Replaces[Key]);
                    SubRow.SetField<string>("備註", string.Empty);
                }
            }
            #endregion

            return Table;
        }

        #region IEnumerable<AbsenceRecord> 成員

        public IEnumerator<AbsenceRecord> GetEnumerator()
        {
            return mRecords.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成員

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mRecords.Values.GetEnumerator();
        }

        #endregion
    }
}