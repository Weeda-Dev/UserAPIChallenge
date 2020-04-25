namespace UsersAPI.Interfaces
{
    public interface IGetValidInputService
    {
        void TurnNullToEmptyString(ref string firstName, ref string lastName);
    }
}