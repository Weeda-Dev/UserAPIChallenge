using Newtonsoft.Json;
using System.IO;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    /// <summary>
    /// Helper for getting data from Json File
    /// </summary>
    public class JsonFileDataService : IJsonFileDataService
    {
        /// <summary>
        /// Get data from a Json file
        /// </summary>
        /// <param name="JsonFilePath">File path to get the Json file</param>
        /// <returns>Get data from Json file</returns>
        public string GetDataStringFromJsonFile(string JsonFilePath)
        {
            return File.ReadAllText(JsonFilePath);
        }

        /// <summary>
        /// Serialize data into Json format then save that data onto a Json File.
        /// </summary>
        /// <param name="userListsRootOb">All Users List from the root object level</param>
        /// <param name="filePathToData">File path to get the Json file providing user data</param>
        public void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb, string filePathToData)
        {
            var serializedUserLists = JsonConvert.SerializeObject(userListsRootOb, Formatting.Indented);
            File.WriteAllText(filePathToData, serializedUserLists);
        }
    }
}