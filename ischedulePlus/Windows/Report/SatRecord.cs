
namespace ischedulePlus
{
    /// <summary>
    /// 缺代統計
    /// </summary>
    public class SatRecord
    {
        /// <summary>
        /// 建構式，傳入教師名稱
        /// </summary>
        /// <param name="TeacherName"></param>
        public SatRecord(string TeacherName)
        {
            this.TeacherName = TeacherName;
        }

        /// <summary>
        /// 教師姓名
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// 請假節數
        /// </summary>
        public int AbsenceCount { get; set; }

        /// <summary>
        /// 其他請假節數
        /// </summary>
        public int OtherAbsenceCount { get; set; }

        /// <summary>
        /// 代課節數
        /// </summary>
        public int ReplaceCount { get; set; }

        /// <summary>
        /// 其他代課節數
        /// </summary>
        public int OtherReplaceCount { get; set; }
    }
}