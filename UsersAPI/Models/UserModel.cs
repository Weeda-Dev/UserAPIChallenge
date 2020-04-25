using System.Collections.Generic;

public class UserModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Birthday { get; set; }
    public string MobileNumber { get; set; }
    public string ProfileImageLarge { get; set; }
    public string ProfileImageThumbnail { get; set; }
}

public class AllUsersRootModel
{
    public IEnumerable<UserModel> users { get; set; }
}