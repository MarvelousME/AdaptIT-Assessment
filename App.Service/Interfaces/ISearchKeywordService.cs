using App.Data.Models;
using System.Collections.Generic;

namespace App.Service.Interface
{
    /// <summary>
    /// Interface for SearchKeywordService
    /// </summary>
    public interface ISearchKeywordService
    {
        List<SearchKeywordMatch> GetMatchedItems(string searchKeyword);
    }
}
