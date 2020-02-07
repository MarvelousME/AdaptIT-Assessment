using System.Collections.Generic;

namespace App.Data.Repositories
{
    /// <summary>
    /// Generic Repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        List<T> GetAllBySearchKeyword(string keyword);
    }
}
