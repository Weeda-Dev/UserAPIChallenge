namespace UsersAPI.Interfaces
{
    public interface IGetJsonFileDataService
    {
        string GetUsersDataFromJsonFile();
        string GetUsersDataJsonFilePath();
        void SerializedDataAndSavetoJsonFile(AllUsersModel userListsRootOb);
    }
}