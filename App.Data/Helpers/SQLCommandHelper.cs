using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Helpers
{
    public class SQLCommandHelper
    {
        public static DataSet ExecuteStoredProc(SqlConnection sqlConnection, string storedProc, List<SqlParameter> sqlParameters)
        {
            if(sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlCommand sqlCommand = new SqlCommand(storedProc, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.SelectCommand = sqlCommand;

            DataSet matchedItems = new DataSet();
            adapter.Fill(matchedItems, "MatchedItems");

            return matchedItems;
        }
    }
}
