using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UsersAPI.Utilities;

namespace UsersAPI.Controllers
{
    public class UsersController : ApiController
    {
        GetJsonFileDataHelper _jsonHelper = new GetJsonFileDataHelper();
        GetUsersHelper _getUsersHelper = new GetUsersHelper();
        GetIdHelper _getIdHelper = new GetIdHelper();

        // GET api/users
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(_jsonHelper.GetUsersDataFromJsonFile(), Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET /api/users/get?firstName={firstName}&lastName={lastName}
        /// <summary>
        /// Get all users information by id/ firstname or last name
        /// </summary>
        /// <param name="firstName">first name of the user</param>
        /// <param name="lastName">first name of the user</param>
        /// <returns>all information of the user</returns>
        public IHttpActionResult Get(string firstName, string lastName)
        {
            IEnumerable<UserModel> userLists = _getUsersHelper.GetUserLists();
            List<UserModel> foundUsers = new List<UserModel>();
            var userListsRootOb = _getUsersHelper.GetUserListRootObject();

            foreach (var user in userLists)
            {
                if (user.FirstName.ToLower().Contains(firstName.ToLower()) ||
                    user.LastName.ToLower().Contains(lastName.ToLower()))
                {
                    foundUsers.Add(user);
                }
            }

            if(foundUsers.Count() > 0)
            {
                userListsRootOb.users = foundUsers;
                return Json(userListsRootOb);
            }

            return Ok("No user(s) found, please recheck that you have typed the correct name.");
        }

        // POST api/users
        public IHttpActionResult Post([FromBody]UserModel nUser)
        {
            var userListsRootOb = _getUsersHelper.GetUserListRootObject();
            var allUsersList = _getUsersHelper.GetUserLists().ToList();
            nUser.Id = _getIdHelper.GetNewUserId(allUsersList);

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
                _jsonHelper.SerializedDataAndSavetoJsonFile(userListsRootOb);
                return Ok($"New user id: {nUser.Id} has been successfully added");
            }
            return BadRequest("Invalid input.");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/id
        public IHttpActionResult Delete(int id)
        {
            var userListsRootOb = _getUsersHelper.GetUserListRootObject();
            var allUsers = _getUsersHelper.GetUserLists();
            var idExists = !allUsers.Where(x => x.Id.Equals(id)).ToList().Count().Equals(0);

            if (idExists)
            {
                allUsers = allUsers.Where(x => !(x.Id.Equals(id))).ToList();
                userListsRootOb.users = allUsers;
                _jsonHelper.SerializedDataAndSavetoJsonFile(userListsRootOb);
                return Ok($"User id: {id} has succuessfully been removed.");
            }

            return Ok($"This user id does not exists, not item has been removed.");
        }
    }
}
