using Newtonsoft.Json;
using System.Collections.Generic;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    /// <summary>
    /// This class is to provide helper when getting users data
    /// </summary>
    public class GetUsersService : IGetUsersService
    {
        private readonly IJsonFileDataService _jsonHelper;
        private readonly IFilePathService _filePathService;

        public GetUsersService(IJsonFileDataService jsonHelper, IFilePathService filePathService)
        {
            _jsonHelper = jsonHelper;
            _filePathService = filePathService;
        }

        public AllUsersRootModel GetUserListRootObject()
        {
            return JsonConvert.DeserializeObject<AllUsersRootModel>(_jsonHelper.GetDataStringFromJsonFile(_filePathService.GetUsersDataJsonFilePath()));
        }

        public IEnumerable<UserModel> GetUserLists()
        {
            AllUsersRootModel userListsob = GetUserListRootObject();
            return userListsob.users;
        }
    }
}