using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischedulePlus
{
    /// <summary>
    /// 電子郵件清單
    /// </summary>
    [FISCA.UDT.TableName("scheduler.email_list")]
    public class EMailList : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 電子郵件
        /// </summary>
        [FISCA.UDT.Field(Field = "email")]
        public string EMail { get; set; }
    }
}
