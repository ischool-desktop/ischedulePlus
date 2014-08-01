
namespace ischedulePlus
{
    /// <summary>
    /// 完整科目
    /// </summary>
    public class What
    {
        /// <summary>
        /// 建構式，傳入科目名稱及級別
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Level"></param>
        public What(string Subject,string Level)
        {
            this.Subject = Subject;
            this.Level = Level;
        }

        /// <summary>
        /// 科目名稱
        /// </summary>
        public string Subject{  get;  set; }

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
                switch (Level)
                {
                    case "1": return Subject + " Ⅰ";
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
    }
}