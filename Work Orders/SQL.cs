using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Orders
{
    class SQL
    {
        private System.Data.SqlClient.SqlConnection SQLDatabaseConnection = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand SQLCommander = new System.Data.SqlClient.SqlCommand();
        private string _DatabaseServer, _DatabaseName, _UserName, _Password;
        public SQL(string DatabaseServer, string DatabaseName, string UserName, string Password)
        {
            _DatabaseServer = DatabaseServer;
            _DatabaseName = DatabaseName;
            _UserName = UserName;
            _Password = Password;
        }
        public DataTable SQLSelect(string SelectInfo)
        {
            int RetryTimes = 5;
            int onTimes = 0;
            try
            {
                if (SQLDatabaseConnection.State != System.Data.ConnectionState.Open)
                {
                    SQLDatabaseConnection.ConnectionString = "Data Source=" + _DatabaseServer.Trim() + ";Initial Catalog=" + _DatabaseName.Trim() + ";MultipleActiveResultSets=False;User ID=" + _UserName + ";Password=" + _Password;
                    SQLDatabaseConnection.Open();
                }
                while (onTimes < RetryTimes)
                {
                    System.Data.SqlClient.SqlDataAdapter SQLAdapter = new System.Data.SqlClient.SqlDataAdapter(SelectInfo, SQLDatabaseConnection);
                    SQLAdapter.SelectCommand.CommandTimeout = 120;
                    DataTable ReturnTable = new DataTable();
                    SQLAdapter.Fill(ReturnTable);
                    onTimes++;
                    return ReturnTable;
                }
            }
            catch
            {
            }
            finally
            {
                SQLDatabaseConnection.Close();
            }
            return null;
        }

        public void SQLSubmit(string SubmitInfo)
        {
            int RetryTimes = 5;
            int onTimes = 0;
            try
            {
                if (SQLDatabaseConnection.State != System.Data.ConnectionState.Open)
                {
                    SQLDatabaseConnection.ConnectionString = "Data Source=" + _DatabaseServer.Trim() + ";Initial Catalog=" + _DatabaseName.Trim() + ";MultipleActiveResultSets=False;User ID=" + _UserName + ";Password=" + _Password;
                    SQLDatabaseConnection.Open();
                }
                while (onTimes < RetryTimes)
                {
                    onTimes++;
                    SQLCommander.Connection = SQLDatabaseConnection;
                    SQLCommander.CommandType = System.Data.CommandType.Text;
                    SQLCommander.CommandTimeout = 0;
                    SQLCommander.CommandText = SubmitInfo;
                    SQLCommander.ExecuteNonQuery();
                    return;
                }
            }
            catch
            {
            }
            finally
            {
                SQLDatabaseConnection.Close();
            }
        }

    }
}
