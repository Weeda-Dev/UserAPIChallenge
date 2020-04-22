using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UsersAPI.Utilities;

namespace UsersAPI.Controllers
{
    public class UsersController : ApiController
    {
        GetJsonFileDataHelper jsonHelper = new GetJsonFileDataHelper();
        GetUsersHelper getUsersHelper = new GetUsersHelper();

        // GET api/users
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonHelper.GetUsersDataJsonFile(), Encoding.UTF8, "application/json"),
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
            IEnumerable<UserModel> userLists = getUsersHelper.GetUserLists();

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

        // DELETE api/values/5
        public void Delete(int id)
        {
            //var user = _getUsersHelper.GetUserLists();
            //var userToDelete = _jsonHelper.GetUsersDataJsonFile().FirstOrDefault(obj => obj["id"].Value<int>() == id);

            //experiencesArrary.Remove(companyToDeleted);
        }
    }
}
