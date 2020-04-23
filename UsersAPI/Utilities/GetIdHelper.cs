using System.Collections.Generic;
using System.Linq;

namespace UsersAPI.Utilities
{
    public class GetIdHelper
    {
        internal int GetNewUserId(IEnumerable<UserModel> allUsers)
        {
            var allUsersDesc = allUsers.OrderByDescending(x => x.Id);
            var id = allUsersDesc.FirstOrDefault().Id + 1;
            return id;
        }
    }
}