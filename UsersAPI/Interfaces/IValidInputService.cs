namespace UsersAPI.Interfaces
{
    public interface IValidInputService
    {
        void TurnNullToEmptyString(ref string firstName, ref string lastName);
    }
}