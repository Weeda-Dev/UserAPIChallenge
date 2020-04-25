using Newtonsoft.Json;
using System.IO;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    /// <summary>
    /// This is a helper for getting data from Json File
    /// </summary>
    public class JsonFileDataService : IJsonFileDataService
    {
        private readonly IFilePathService _getFilePathService;

        public JsonFileDataService(IFilePathService getFilePathService)
        {
            _getFilePathService = getFilePathService;
        }

        /// <summary>
        /// Get users data from a Json file
        /// </summary>
        /// <returns>User(s) data</returns>
        public string GetUsersDataFromJsonFile(string JsonFilePath)
        {
            return File.ReadAllText(JsonFilePath);
        }

        /// <summary>
        /// Serialize data into Json format then save that data onto a Json File.
        /// </summary>
        /// <param name="userListsRootOb">All Users List from the root object level</param>
        public void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb)
        {
            var serializedUserLists = JsonConvert.SerializeObject(userListsRootOb, Formatting.Indented);
            File.WriteAllText(_getFilePathService.GetUsersDataJsonFilePath(), serializedUserLists);
        }
    }
}