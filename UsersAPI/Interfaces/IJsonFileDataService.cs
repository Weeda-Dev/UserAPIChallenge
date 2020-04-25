namespace UsersAPI.Interfaces
{
    public interface IJsonFileDataService
    {
        string GetDataStringFromJsonFile(string JsonFilePath);
        void SerializedDataAndSavetoJsonFile(AllUsersRootModel userListsRootOb, string filePathToData);
    }
}