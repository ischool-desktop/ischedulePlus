using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ischedulePlus
{
    /// <summary>
    /// 節次選項
    /// </summary>
    public class PeriodOption
    {
        /// <summary>
        /// 是否選取
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 節次
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// 類別，一般或其他
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public PeriodOption()
        {
            Checked = false;
            Period = string.Empty;
            Type = "一般";
        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="Element"></param>
        public PeriodOption(XElement Element)
        {
            string strChecked = Element.AttributeText("Checked");
            Checked = strChecked.ToUpper().Equals("TRUE") ? true : false;

            Period = Element.AttributeText("Period");

            Type = Element.AttributeText("Type");
        }

        /// <summary>
        /// 輸出成XML Element
        /// </summary>
        /// <returns></returns>
        public XElement ToElement()
        {
            XElement Element = new XElement("PeriodOption");

            Element.SetAttributeValue("Checked", Checked ? "true" : "false");
            Element.SetAttributeValue("Period", Period);
            Element.SetAttributeValue("Type", Type);

            return Element;
        }
    }
}