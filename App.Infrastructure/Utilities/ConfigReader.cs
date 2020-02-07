using System.Configuration;

namespace App.Infrastructure.Utilities
{
    /// <summary>
    /// Utility class to read config
    /// </summary>
    public class ConfigReader
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["default"].ToString(); 
            }
        }
    }
}
