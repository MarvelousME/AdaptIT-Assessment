using App.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Helpers
{
    public class SQLHelper
    {
         
        public static List<MatchedItem> ExecuteStoreProc(string storedProcedure, string searchKeyword)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionHelper.GetConnectionString());

            //SQLConnection = SQLConnectionHelper.GetConnection();

            List<MatchedItem> items = new List<MatchedItem>();

            var paramList = new List<System.Data.SqlClient.SqlParameter>();
            paramList.Add(new System.Data.SqlClient.SqlParameter("@SearchKeyword", searchKeyword));


            var result = SQLCommandHelper.ExecuteStoredProc(SQLConnection, storedProcedure, paramList);

            foreach(DataRow item in result.Tables[0].Rows)
            {
                items.Add(new MatchedItem() { Name = item["MatchedItem"].ToString() });
            }

            return items;
        }
    }
}
