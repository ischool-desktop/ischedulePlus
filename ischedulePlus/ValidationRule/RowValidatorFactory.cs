using Campus.DocumentValidator;

namespace ischedulePlus
{
    /// <summary>
    /// 用來產生排課系統所需的自訂驗證規則
    /// </summary>
    public class RowValidatorFactory : IRowValidatorFactory
    {
        #region IRowValidatorFactory 成員

        /// <summary>
        /// 根據typeName建立對應的RowValidator
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="validatorDescription"></param>
        /// <returns></returns>
        public IRowVaildator CreateRowValidator(string typeName, System.Xml.XmlElement validatorDescription)
        {
            switch (typeName.ToUpper())
            {
                case "ICOURSENAMECHECK":
                    return new iCourseNameCheck();
                case "ITIMERANGECHECK":
                    return new iTimeRangeCheck();
                case "IDATERANGECHECK":
                    return new iDateRangeCheck();
                case "ITEACHERNAMECHECK":
                    return new iTeacherNameCheck();
                case "TEACHERNAMECHECK_NEW":
                    return new TeacherNameCheck_New();
                default:
                    return null;
            }
        }

        #endregion
    }
}