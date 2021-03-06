﻿using Campus.DocumentValidator;

namespace ischedulePlus
{
    /// <summary>
    /// 用來產生排課系統所需的自訂驗證規則
    /// </summary>
    public class FieldValidatorFactory : IFieldValidatorFactory
    {
        #region IFieldValidatorFactory 成員

        /// <summary>
        /// 根據typeName建立對應的FieldValidator
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="validatorDescription"></param>
        /// <returns></returns>
        public IFieldValidator CreateFieldValidator(string typeName, System.Xml.XmlElement validatorDescription)
        {
            switch (typeName.ToUpper())
            {
                case "ICLASSNAMECHECK":
                    return new iClassNameCheck();
                case "ITIMEFORMATCHECK":
                    return new iTimeFormatCheck();
                case "ITEACHERNAMECHECK":
                    return new iTeacherNameFCheck();
                case "CLASSINCHECK":
                    return new ClassInCheck();
                default:
                    return null;
            }
        }

        #endregion
    }
}