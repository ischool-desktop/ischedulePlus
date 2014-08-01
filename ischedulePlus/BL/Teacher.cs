using System.Collections.Generic;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 教師列表
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// 無參數建構式
        /// </summary>
        public Teacher()
        {
            Whats = new List<What>();
        }

        /// <summary>
        /// 系統編號
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 教師名稱（教師姓名+教師暱稱）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 註記
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 教授課目列表
        /// </summary>
        public List<What> Whats;
    }
}