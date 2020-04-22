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
        internal IEnumerable<UserModel> GetUserLists()
        {
            var userListsob = JsonConvert.DeserializeObject<AllUsersModel>(jsonHelper.GetUsersDataJsonFile());
            return userListsob.users;
        }
    }
}