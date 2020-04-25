namespace UsersAPI.Interfaces
{
    public interface IIdService
    {
        int GetNewUserId(int lastIdOnUsersList);
    }
}