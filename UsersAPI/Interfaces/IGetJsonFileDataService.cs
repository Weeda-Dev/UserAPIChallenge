namespace UsersAPI.Interfaces
{
    public interface IGetJsonFileDataService
    {
        string GetUsersDataFromJsonFile();
        void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb);
    }
}