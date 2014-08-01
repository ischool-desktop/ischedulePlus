using System.Collections.Generic;
using System.Data;

namespace ischedulePlus
{
    /// <summary>
    /// 缺代統計
    /// </summary>
    public class SatRecords : IEnumerable<SatRecord>
    {
        private SortedDictionary<string, SatRecord> mRecords = new SortedDictionary<string, SatRecord>();
        private List<string> mCommonPeriods;
        private List<string> mOtherPeriods;

        /// <summary>
        /// 一般節次統計
        /// </summary>
        /// <param name="Periods"></param>
        public SatRecords(List<string> CommonPeriods,List<string> OtherPeriods)
        {
            mCommonPeriods = CommonPeriods;
            mOtherPeriods = OtherPeriods;
        }

        /// <summary>
        /// 增加行事曆
        /// </summary>
        /// <param name="Record"></param>
        public void Add(CalendarRecord Record)
        {
            //若不是代課記錄則不新增
            if (string.IsNullOrEmpty(Record.ReplaceID))
                return;

            if (!mRecords.ContainsKey(Record.TeacherName))
                mRecords.Add(Record.TeacherName,new SatRecord(Record.TeacherName));

            if (!mRecords.ContainsKey(Record.AbsTeacherName))
                mRecords.Add(Record.AbsTeacherName, new SatRecord(Record.AbsTeacherName));

            if (mCommonPeriods.Contains(Record.Period))
            {
                mRecords[Record.TeacherName].ReplaceCount++;
                mRecords[Record.AbsTeacherName].AbsenceCount++;
            }
            else if (mOtherPeriods.Contains(Record.Period))
            {
                mRecords[Record.TeacherName].OtherReplaceCount++;
                mRecords[Record.AbsTeacherName].OtherAbsenceCount++;
            }
        }

        /// <summary>
        /// 輸出成明細
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            DataTable Table = new DataTable("明細");

            int CommonAbsence = 0;
            int CommonReplace = 0;
            int OtherAbsence = 0;
            int OtherReplace = 0;

            Table.Columns.Add("姓名");
            Table.Columns.Add("一般代課");
            Table.Columns.Add("一般請假");
            Table.Columns.Add("其他代課");
            Table.Columns.Add("其他請假");

            foreach(SatRecord record in this)
            {
                DataRow Row = Table.Rows.Add();

                Row.SetField<string>("姓名", record.TeacherName);
                Row.SetField<string>("一般代課", "" + record.ReplaceCount);
                Row.SetField<string>("一般請假", "" + record.AbsenceCount);
                Row.SetField<string>("其他代課", "" + record.OtherReplaceCount);
                Row.SetField<string>("其他請假", "" + record.OtherAbsenceCount);

                CommonAbsence += record.AbsenceCount;
                CommonReplace += record.ReplaceCount;
                OtherAbsence += record.OtherAbsenceCount;
                OtherReplace += record.OtherReplaceCount;
            }

            DataRow SumRow = Table.Rows.Add();

            SumRow.SetField<string>("姓名", "總計");
            SumRow.SetField<string>("一般代課", "" + CommonReplace);
            SumRow.SetField<string>("一般請假", "" + CommonAbsence);
            SumRow.SetField<string>("其他代課", "" + OtherReplace);
            SumRow.SetField<string>("其他請假", "" + OtherAbsence);

            return Table;
        }

        #region IEnumerable<SatRecord> 成員

        public IEnumerator<SatRecord> GetEnumerator()
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