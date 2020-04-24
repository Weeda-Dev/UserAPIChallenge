using System.Collections.Generic;
using System.Linq;
using UsersAPI.Interfaces;

namespace UsersAPI.Utilities
{
    public class GetIdService : IGetIdService
    {
        public int GetNewUserId(int lastIdOnUsersList)
        {
            var id = lastIdOnUsersList + 1;
            return id;
        }
    }
}