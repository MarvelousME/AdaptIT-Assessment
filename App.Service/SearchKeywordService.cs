using App.Data.Models;
using App.Data.Repositories;
using App.Service.Interface;
using System.Collections.Generic;

namespace App.Service
{
    /// <summary>
    /// Service that will get to result of the keyword search from the database and pass it to the application
    /// </summary>
    public class SearchKeywordService : ISearchKeywordService
    {
        #region Field
        IRepository<SearchKeywordMatch> searchKeywordMatchRepository = null;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchKeywordService()
        {
            searchKeywordMatchRepository = new SearchKeywordMatchRepository();
        }
        /// <summary>
        /// Service layer method implemented in class based on Interface to query and return
        /// list of results
        /// </summary>
        /// <param name="searchKeyword">Keyword search</param>
        /// <returns>list of results</returns>
        public List<SearchKeywordMatch> GetMatchedItems(string searchKeyword)
        {
            return searchKeywordMatchRepository.GetAllBySearchKeyword(searchKeyword);
        }
    }
}
