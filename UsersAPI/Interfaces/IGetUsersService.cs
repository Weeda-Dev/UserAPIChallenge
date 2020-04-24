using System.Collections.Generic;

namespace UsersAPI.Interfaces
{
    public interface IGetUsersService
    {
        AllUsersModel GetUserListRootObject();
        IEnumerable<UserModel> GetUserLists();
    }
}