using Newtonsoft.Json;
using System.Collections.Generic;
using UsersAPI.Interfaces;

namespace UsersAPI.Utilities
{
    /// <summary>
    /// This class is to provide helper when getting users data
    /// </summary>
    public class GetUsersService : IGetUsersService
    {
        private readonly IGetJsonFileDataService _jsonHelper;

        public GetUsersService(IGetJsonFileDataService jsonHelper)
        {
            _jsonHelper = jsonHelper;
        }

        public AllUsersModel GetUserListRootObject()
        {
            return JsonConvert.DeserializeObject<AllUsersModel>(_jsonHelper.GetUsersDataFromJsonFile());
        }

        public IEnumerable<UserModel> GetUserLists()
        {
            AllUsersModel userListsob = GetUserListRootObject();
            return userListsob.users;
        }
    }
}