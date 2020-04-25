﻿using System.Web;
using UsersAPI.Constants;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    public class GetFilePathService : IGetFilePathService
    {
        public string GetUsersDataJsonFilePath()
        {
            return HttpContext.Current.Server.MapPath($@"{FilePathConstants.USERS_DATA_JSON_FILE_PATH}");
        }
    }
}