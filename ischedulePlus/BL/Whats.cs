using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischedulePlus
{
    /// <summary>
    /// 科目集合物件
    /// </summary>
    public class Subjects : IEnumerable<What>
    {
        private Dictionary<string, What> mWhats;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public Subjects()
        {
            mWhats = new Dictionary<string, What>(); 
        }

        /// <summary>
        /// 是否包含指定科目
        /// </summary>
        /// <param name="FullSubject"></param>
        /// <returns></returns>
        public bool Contains(string FullSubject)
        {
            return mWhats.ContainsKey(FullSubject);
        }

        /// <summary>
        /// 新增科目
        /// </summary>
        /// <param name="vWhat"></param>
        /// <returns></returns>
        public bool Add(What vWhat)
        {
            if (!mWhats.ContainsKey(vWhat.FullSubject))
            {
                mWhats.Add(vWhat.FullSubject, vWhat);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 轉換成列表
        /// </summary>
        /// <returns></returns>
        public List<What> ToList()
        {
            return mWhats.Values.ToList();
        }

        #region IEnumerable<What> 成員

        public IEnumerator<What> GetEnumerator()
        {
            return mWhats.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成員

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mWhats.Values.GetEnumerator();
        }

        #endregion
    }
}
