namespace UsersAPI.Interfaces
{
    public interface IJsonFileDataService
    {
        string GetUsersDataFromJsonFile(string JsonFilePath);
        void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb);
    }
}