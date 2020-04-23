using Newtonsoft.Json.Linq;
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

            foreach (var user in userLists)
            {
                if (user.FirstName.ToLower().Equals(firstName.ToLower()) ||
                    user.LastName.ToLower().Equals(lastName.ToLower()))
                    return Json(user);
            }

            return Ok("No user found, please recheck that you have typed the correct name.");
        }

        // POST api/values
        public void Post([FromBody]JToken postData, HttpRequestMessage request)
        {
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
