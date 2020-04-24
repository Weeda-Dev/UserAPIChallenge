using System.Collections.Generic;
using System.Linq;
using UsersAPI.Interfaces;

namespace UsersAPI.Utilities
{
    public class GetIdService : IGetIdService
    {
        public int GetNewUserId(IEnumerable<UserModel> allUsers)
        {
            var allUsersDesc = allUsers.OrderByDescending(x => x.Id);
            var id = allUsersDesc.FirstOrDefault().Id + 1;
            return id;
        }
    }
}