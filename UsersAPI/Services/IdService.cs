using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    public class IdService : IIdService
    {
        public int GetNewUserId(int lastIdOnUsersList)
        {
            var id = lastIdOnUsersList + 1;
            return id;
        }
    }
}