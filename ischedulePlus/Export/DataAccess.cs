using System;
using System.Data;
using System.Data.OleDb;
using Campus.Configuration;

namespace ischedulePlus
{
    public class DataAccess
    {
        public static bool HasFoxproConnectionString(ConfigData cdApp)
        {
            return (!string.IsNullOrEmpty(cdApp["Directory"]));
        }

        public static bool HasConnectionString(ConfigData cdApp)
        {
            if (!string.IsNullOrEmpty(cdApp["Server"]) &&
                !string.IsNullOrEmpty(cdApp["Database"]) &&
                !string.IsNullOrEmpty(cdApp["User"]) &&
                !string.IsNullOrEmpty(cdApp["Password"])
                )
                return true;
            else
                return false;
        }

        public static string GetFoxproConnectionString(ConfigData cpApp)
        {
            return "Provider=vfpoledb;Data Source=" + cpApp["Directory"] + ";Collating Sequence=machine;";
        }

        public static string GetConnectionString(ConfigData cdApp)
        {
            return "Provider=SQLOLEDB;Password=" + cdApp["Password"] + ";Persist Security Info=True;User ID=" + cdApp["User"] + ";Initial Catalog=" + cdApp["Database"] + ";Data Source=" + cdApp["Server"] + ";Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False";
        }

        public Tuple<bool, string> ExecuteSQL(OleDbCommand SQLCommand, string SQL)
        {
            bool IsSuccess = false;
            string ErrorMessage = string.Empty;

            try
            {
                SQLCommand.CommandText = SQL;
                SQLCommand.ExecuteNonQuery();
                IsSuccess = true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                IsSuccess = false;
            }
            return new Tuple<bool, string>(IsSuccess, ErrorMessage);
        }

        public Tuple<bool, DataTable, string> ExecuteSQLtb(OleDbCommand SQLCommand, string SQL)
        {
            bool IsSuccess = false;
            string ErrorMessage = string.Empty;
            DataTable rtable = new DataTable();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                SQLCommand.CommandText = SQL;
                oda.SelectCommand = SQLCommand;
                oda.Fill(ds);
                rtable = ds.Tables[0];
                IsSuccess = true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                IsSuccess = false;
            }

            return new Tuple<bool, DataTable, string>(IsSuccess, rtable, ErrorMessage);
        }

    }
}