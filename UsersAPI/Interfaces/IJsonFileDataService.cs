namespace UsersAPI.Interfaces
{
    public interface IJsonFileDataService
    {
        string GetUsersDataFromJsonFile();
        void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb);
    }
}