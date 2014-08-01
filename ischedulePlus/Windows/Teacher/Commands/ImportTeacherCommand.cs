
namespace ischedulePlus
{
    public class ImportTeacherCommand : ICommand
    {

        #region ICommand 成員

        public string Text
        {
            get { return "匯入教師清單"; }
        }

        public string Name
        {
            get { return "ImportTeacher"; }
        }

        public bool IsChangeData
        {
            get { return true; }
        }

        public string Execute(object Context)
        {
            (new ImportTeacherEx()).Execute();

            return string.Empty;
        }

        #endregion
    }
}