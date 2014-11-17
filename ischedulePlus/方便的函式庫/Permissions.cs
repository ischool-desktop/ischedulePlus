using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischedulePlus
{
    class Permissions
    {
        public static string 取消代課 { get { return "9915d5ec-0fe4-460d-8094-dd84727de506"; } }

        public static bool 取消代課權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[取消代課].Executable;
            }
        }

        public static string 取消調課 { get { return "5f069ac2-be17-4936-a48c-20692961827f"; } }

        public static bool 取消調課查詢權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[取消調課].Executable;
            }
        }


        public static string 代課查詢 { get { return "f6a5c7fe-2db8-4ab6-a9bd-0c8a7bde1a80"; } }

        public static bool 代課查詢權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[代課查詢].Executable;
            }
        }

        public static string 班級管理 { get { return "de953993-0edd-4f1e-8d9c-978c13435171"; } }
        public static bool 班級管理權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[班級管理].Executable;
            }
        }

        public static string 教師管理 { get { return "ee72b61c-9ebb-42a5-aec9-909619e43cc3"; } }
        public static bool 教師管理權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[教師管理].Executable;
            }
        }

        public static string 連線學校 { get { return "ischedulePlus.Ribbon0010"; } }

        public static bool 連線學校權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[教師管理].Executable;
            }
        }

        public static string 可存取電子郵件 { get { return "ischedulePlus.Ribbon0110"; } }

        public static bool 可存取電子郵件權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[可存取電子郵件].Executable;
            }
        }

        public static string 學期設定 { get { return "ischedulePlus.Ribbon0070"; } }

        public static bool 學期設定權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[學期設定].Executable;
            }
        }

        public static string 匯入課程行事曆 { get { return "ischedulePlus.Ribbon0020"; } }

        public static bool 匯入課程行事曆權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[匯入課程行事曆].Executable;
            }
        }

        public static string 調代課批次查詢 { get { return "ischedulePlus.Ribbon0080"; } }

        public static bool 調代課批次查詢權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[調代課批次查詢].Executable;
            }
        }

        public static string 行事曆批次查詢 { get { return "1ae7303f-3be9-4dee-a94a-3b20a8c8ca79"; } }

        public static bool 行事曆批次查詢權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[行事曆批次查詢].Executable;
            }
        }

        public static string 調代課通知單列印 { get { return "ischedulePlus.Ribbon0090"; } }

        public static bool 調代課通知單列印權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[調代課通知單列印].Executable;
            }
        }

        public static string 請假代課明細表列印 { get { return "ischedulePlus.Ribbon0100"; } }

        public static bool 請假代課明細表列印權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[請假代課明細表列印].Executable;
            }
        }

        public static string 請假代課統計表列印 { get { return "ischedulePlus.Ribbon0120"; } }

        public static bool 請假代課統計表列印權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[請假代課統計表列印].Executable;
            }
        }

        public static string 產生課程行事曆 { get { return "446a5df8-6fcb-4482-be75-f2fd8287a4d3"; } }

        public static bool 產生課程行事曆權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[產生課程行事曆].Executable;
            }
        }

        public static string 產生教師不調代時段 { get { return "784b2e1c-ca08-4e46-9af4-b3c842c891e4"; } }

        public static bool 產生教師不調代時段權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[產生教師不調代時段].Executable;
            }
        }

        public static string 產生班級不調代時段 { get { return "18996eed-879e-44db-ae1e-dd4e9bad19f4"; } }

        public static bool 產生班級不調代時段權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[產生班級不調代時段].Executable;
            }
        }

        public static string 假別管理 { get { return "498EF770-AAE0-45BF-97D7-882C7ABBDD1A"; } }
        public static bool 假別管理權限
        {
            get { return FISCA.Permission.UserAcl.Current[假別管理].Executable; }
        }

        public static string 行事曆設定 { get { return "7D67ABE1-AA76-4854-8B15-3FEC394D938C"; } }
        public static bool 行事曆設定權限
        {
            get { return FISCA.Permission.UserAcl.Current[行事曆設定].Executable; }
        }
    }
}