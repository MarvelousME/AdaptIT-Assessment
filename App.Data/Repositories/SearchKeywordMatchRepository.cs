using App.Data.Models;
using App.Infrastructure.Utilities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace App.Data.Repositories
{
    /// <summary>
    /// SearchKeywordMatchRepository that will make calls and execute stored procedures in SQL against the SearchKeywordMatch table
    /// </summary>
    public class SearchKeywordMatchRepository :  IRepository<SearchKeywordMatch>
    {
        #region Field
        private IDbConnection dbConnection = null;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchKeywordMatchRepository()
        {
            dbConnection = new SqlConnection(ConfigReader.ConnectionString);
        }

        /// <summary>
        /// Get all the matched items for the keyword search
        /// </summary>
        /// <param name="keyword">keyword search</param>
        /// <returns>list of results for the executed stored procedure</returns>
        public List<SearchKeywordMatch> GetAllBySearchKeyword(string keyword)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchKeyword", keyword);

            string storedProcName = "GetSearchKeywordMatchedItems";

            var queryResult = dbConnection.Query<SearchKeywordMatch>(storedProcName, param: queryParameters, commandType: CommandType.StoredProcedure);

            return queryResult.ToList();
        }
    }
}
