using System.Collections.Generic;

namespace UsersAPI.Interfaces
{
    public interface IGetIdService
    {
        int GetNewUserId(int lastIdOnUsersList);
    }
}