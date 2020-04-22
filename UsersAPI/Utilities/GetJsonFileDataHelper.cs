using System.IO;
using System.Web;
using UsersAPI.Constants;

namespace UsersAPI.Utilities
{
    /// <summary>
    /// This is a helper for getting data from Json File
    /// </summary>
    public class GetJsonFileDataHelper
    {
        public string GetUsersDataJsonFile()
        {
            return File.ReadAllText(HttpContext.Current.Server.MapPath($@"{FilePathConstants.USERS_DATA_JSON_FILE_PATH}"));
        }
    }
}