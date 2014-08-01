
namespace ischedulePlus
{
    class GetischoolClassList : ICommand
    {
        public string Text
        {
            get { return "從ischool複製班級清單"; }
        }

        public string Name
        {
            get { return "Get_ischool_ClassList"; }
        }

        public bool IsChangeData
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Execute(object Context)
        {
            GetClassListForm gclf = new GetClassListForm();
            gclf.ShowDialog();

            return string.Empty;
        }
    }
}
