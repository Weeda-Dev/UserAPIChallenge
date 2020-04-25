﻿using Newtonsoft.Json;
using System.IO;
using System.Web;
using UsersAPI.Constants;
using UsersAPI.Interfaces;

namespace UsersAPI.Utilities
{
    /// <summary>
    /// This is a helper for getting data from Json File
    /// </summary>
    public class GetJsonFileDataService : IGetJsonFileDataService
    {
        public string GetUsersDataFromJsonFile()
        {
            return File.ReadAllText(GetUsersDataJsonFilePath());
        }

        public string GetUsersDataJsonFilePath()
        {
            return HttpContext.Current.Server.MapPath($@"{FilePathConstants.USERS_DATA_JSON_FILE_PATH}");
        }

        public void SerializedDataAndSavetoJsonFile(AllUsersModel userListsRootOb)
        {
            var serializedUserLists = JsonConvert.SerializeObject(userListsRootOb, Formatting.Indented);
            File.WriteAllText(GetUsersDataJsonFilePath(), serializedUserLists);
        }
    }
}