using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.Common.DBConnect.SqlServer
{
    public static class SqlDbHepler
    {
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection sqlConnection;

            try
            {
                string contrs = System.Configuration.ConfigurationManager.ConnectionStrings["BE_072024_ConnectionString"].ConnectionString.ToString();
                sqlConnection = new SqlConnection(contrs);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return sqlConnection;
        }
    }
}
