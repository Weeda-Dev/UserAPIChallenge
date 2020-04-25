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
        private readonly IFilePathService _filePathService;

        /// <summary>
        /// Get data from a Json file
        /// </summary>
        /// <returns>Get from Json data</returns>
        public string GetDataStringFromJsonFile(string JsonFilePath)
        {
            return File.ReadAllText(JsonFilePath);
        }

        /// <summary>
        /// Serialize data into Json format then save that data onto a Json File.
        /// </summary>
        /// <param name="userListsRootOb">All Users List from the root object level</param>
        public void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb, string filePathToData)
        {
            var serializedUserLists = JsonConvert.SerializeObject(userListsRootOb, Formatting.Indented);
            File.WriteAllText(filePathToData, serializedUserLists);
        }
    }
}