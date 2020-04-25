using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UsersAPI.Interfaces;

namespace UsersAPI.Controllers.API
{
    /// <summary>
    /// API to manage users
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IJsonFileDataService _jsonHelper;
        private readonly IGetUsersService _getUsersHelper;
        private readonly IIdService _getIdHelper;
        private readonly IGetValidInputService _validInputHelper;
        private readonly IFilePathService _filePathService;

        public UsersController(IJsonFileDataService jsonHelper, IGetUsersService getUsersHelper,
            IIdService getIdHelper, IGetValidInputService validInputHelper, IFilePathService filePathService)
        {
            _jsonHelper = jsonHelper;
            _getUsersHelper = getUsersHelper;
            _getIdHelper = getIdHelper;
            _validInputHelper = validInputHelper;
            _filePathService = filePathService;
        }

        /// <summary>
        /// GET api/users
        /// </summary>
        /// <returns>All users and http status code</returns>
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(_jsonHelper.GetDataStringFromJsonFile(_filePathService.GetUsersDataJsonFilePath()),
                Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// GET /api/users/get?firstName={firstName}&lastName={lastName}
        /// </summary>
        /// <param name="firstName">first name of the user</param>
        /// <param name="lastName">first name of the user</param>
        /// <returns>Information of the searched user and http status code</returns>
        public IHttpActionResult Get(string firstName, string lastName)
        {
            IEnumerable<UserModel> userLists = _getUsersHelper.GetUserLists();
            List<UserModel> foundUsers = new List<UserModel>();
            var userListsRootOb = _getUsersHelper.GetUserListRootObject();

            _validInputHelper.TurnNullToEmptyString(ref firstName, ref lastName);

            foreach (var user in userLists)
            {

                if (user.FirstName.ToLower().Contains(firstName.ToLower()) ||
                    user.LastName.ToLower().Contains(lastName.ToLower()))
                {
                    foundUsers.Add(user);
                }
            }

            if (foundUsers.Count() > 0)
            {
                userListsRootOb.users = foundUsers;
                return Json(userListsRootOb);
            }

            return Ok("No user(s) found, please recheck that you have typed the correct name.");
        }



        /// <summary>
        /// POST api/users
        /// - Create a new user
        /// </summary>
        /// <param name="nUser">Details for the user to be created</param>
        /// <returns>Http status code with a status message</returns>
        public IHttpActionResult Post([FromBody]UserModel nUser)
        {
            var userListsRootOb = _getUsersHelper.GetUserListRootObject();
            var allUsersList = _getUsersHelper.GetUserLists().ToList();

            var lastIdOnUsersList = allUsersList.OrderByDescending(x => x.Id).First().Id;
            nUser.Id = _getIdHelper.GetNewUserId(lastIdOnUsersList);

            if (ModelState.IsValid)
            {
                var newUser = new UserModel
                {
                    Id = nUser.Id,
                    Title = nUser.Title,
                    FirstName = nUser.FirstName,
                    LastName = nUser.LastName,
                    Email = nUser.Email,
                    Birthday = nUser.Birthday,
                    MobileNumber = nUser.MobileNumber,
                    ProfileImageLarge = nUser.ProfileImageLarge,
                    ProfileImageThumbnail = nUser.ProfileImageThumbnail
                };

                allUsersList.Add(newUser);
                userListsRootOb.users = allUsersList;
                _jsonHelper.SerializedDataAndSavetoJsonFile(userListsRootOb, _filePathService.GetUsersDataJsonFilePath());
                return Ok($"New user id: {nUser.Id} has been successfully added");
            }
            return BadRequest("Invalid input.");
        }

        /// <summary>
        /// PUT api/users/5
        /// Update a user
        /// </summary>
        /// <param name="id">id of the user to be updated</param>
        /// <param name="nUser">all details of the user to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]UserModel nUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }

            var userListsRootOb = _getUsersHelper.GetUserListRootObject();
            var allUsersList = _getUsersHelper.GetUserLists();
            var updateUser = allUsersList.Where(x => (x.Id.Equals(id)));

            if(updateUser.Count() == 0)
            {
                return Content(HttpStatusCode.NotFound,"User not found, please check this user id exists");
            }

            allUsersList.Where(x => x.Id.Equals(id))
                    .Select(x => {
                        x.Title = nUser.Title;
                        x.FirstName = nUser.FirstName;
                        x.LastName = nUser.LastName;
                        x.Email = nUser.Email;
                        x.Birthday = nUser.Birthday;
                        x.MobileNumber = nUser.MobileNumber;
                        x.ProfileImageLarge = nUser.ProfileImageLarge;
                        x.ProfileImageThumbnail = nUser.ProfileImageThumbnail;
                        return x;
                    }).ToList();

            userListsRootOb.users = allUsersList;
                _jsonHelper.SerializedDataAndSavetoJsonFile(userListsRootOb, _filePathService.GetUsersDataJsonFilePath());
                return Ok($"User id: {id} has been successfully updated");
        }

        /// <summary>
        /// DELETE api/values/id
        /// </summary>
        /// <param name="id">id of the user that will deleted</param>
        /// <returns>Status code with information</returns>
        public IHttpActionResult Delete(int id)
        {
            var userListsRootOb = _getUsersHelper.GetUserListRootObject();
            var allUsers = _getUsersHelper.GetUserLists();
            var idExists = !allUsers.Where(x => x.Id.Equals(id)).ToList().Count().Equals(0);

            if (idExists)
            {
                allUsers = allUsers.Where(x => !(x.Id.Equals(id))).ToList();
                userListsRootOb.users = allUsers;
                _jsonHelper.SerializedDataAndSavetoJsonFile(userListsRootOb, _filePathService.GetUsersDataJsonFilePath());
                return Ok($"User id: {id} has succuessfully been removed.");
            }

            return Ok($"This user id does not exists, no user has been removed.");
        }
    }
}
