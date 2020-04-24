using System.Collections.Generic;

namespace UsersAPI.Interfaces
{
    public interface IGetIdService
    {
        int GetNewUserId(IEnumerable<UserModel> allUsers);
    }
}