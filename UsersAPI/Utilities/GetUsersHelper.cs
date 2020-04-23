using Newtonsoft.Json;
using System.Collections.Generic;

namespace UsersAPI.Utilities
{
    /// <summary>
    /// This class is to provide helper when getting users data
    /// </summary>
    public class GetUsersHelper
    {
        GetJsonFileDataHelper jsonHelper = new GetJsonFileDataHelper();

        internal AllUsersModel GetUserListRootObject()
        {
            return JsonConvert.DeserializeObject<AllUsersModel>(jsonHelper.GetUsersDataFromJsonFile());
        }

        internal IEnumerable<UserModel> GetUserLists()
        {
            AllUsersModel userListsob = GetUserListRootObject();
            return userListsob.users;
        }
    }
}