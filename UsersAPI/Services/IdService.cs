using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    /// <summary>
    /// Help with anything related to Ids
    /// </summary>
    public class IdService : IIdService
    {
        /// <summary>
        /// Get new user's id
        /// </summary>
        /// <param name="lastIdOnUsersList">The last id on all users list</param>
        /// <returns>New user's id</returns>
        public int GetNewUserId(int lastIdOnUsersList)
        {
            var id = lastIdOnUsersList + 1;
            return id;
        }
    }
}