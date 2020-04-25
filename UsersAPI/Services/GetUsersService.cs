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

        /// <summary>
        /// Deserialize Json into a all users list
        /// </summary>
        /// <returns>A list of all users from the root level</returns>
        public AllUsersRootModel GetUserListRootObject()
        {
            return JsonConvert.DeserializeObject<AllUsersRootModel>(_jsonHelper.GetDataStringFromJsonFile(_filePathService.GetUsersDataJsonFilePath()));
        }

        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns>List of users</returns>
        public IEnumerable<UserModel> GetUserLists()
        {
            AllUsersRootModel userListsob = GetUserListRootObject();
            return userListsob.users;
        }
    }
}