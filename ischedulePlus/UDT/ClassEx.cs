
namespace ischedulePlus
{
    /// <summary>
    /// 排課專屬班級清單
    /// </summary>
    [FISCA.UDT.TableName("scheduler.class_ex")]
    public class ClassEx : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 班級名稱
        /// </summary>
        [FISCA.UDT.Field(Field = "class_name")]
        public string ClassName { get; set; }

        /// <summary>
        /// 班級年級
        /// </summary>
        [FISCA.UDT.Field(Field = "grade_year")]
        public int? GradeYear { get; set; }

        /// <summary>
        /// 班級代碼
        /// </summary>
        [FISCA.UDT.Field(Field = "class_code")]
        public string ClassCode { get; set; }

        /// <summary>
        /// 註記，目前用來填班導師
        /// </summary>
        [FISCA.UDT.Field(Field = "note")]
        public string Note { get; set; }
    }
}