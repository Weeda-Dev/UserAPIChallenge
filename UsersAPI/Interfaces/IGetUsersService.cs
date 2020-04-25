using System.Collections.Generic;

namespace UsersAPI.Interfaces
{
    public interface IGetUsersService
    {
        AllUsersRootModel GetUserListRootObject();
        IEnumerable<UserModel> GetUserLists();
    }
}