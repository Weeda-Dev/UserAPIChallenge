using System.Web;
using UsersAPI.Constants;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    /// <summary>
    /// Help providing file path
    /// </summary>
    public class FilePathService : IFilePathService
    {
        /// <summary>
        /// Gets the json file path for getting the user data
        /// </summary>
        /// <returns>file path</returns>
        public string GetUsersDataJsonFilePath()
        {
            return HttpContext.Current.Server.MapPath($@"{FilePathConstants.USERS_DATA_JSON_FILE_PATH}");
        }
    }
}