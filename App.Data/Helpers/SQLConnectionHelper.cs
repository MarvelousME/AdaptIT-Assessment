using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Core.Helpers
{
    public class SQLConnectionHelper
    {
        public static string GetConnectionString()
        {
             var connectionString = ConfigurationManager.ConnectionStrings["default"].ToString();

            return connectionString;
        }

        private static bool IsConnectionOpen(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                return true;
            }

            return false;
        }

        public static SqlConnection GetConnection()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                if(!IsConnectionOpen(connection))
                {
                    connection.Open();

                    return connection;
                }
            }

            return null;
        }
    }
}
