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

        public string GetUsersDataFromJsonFile()
        {
            return File.ReadAllText(_getFilePathService.GetUsersDataJsonFilePath());
        }

        public void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb)
        {
            var serializedUserLists = JsonConvert.SerializeObject(userListsRootOb, Formatting.Indented);
            File.WriteAllText(_getFilePathService.GetUsersDataJsonFilePath(), serializedUserLists);
        }
    }
}