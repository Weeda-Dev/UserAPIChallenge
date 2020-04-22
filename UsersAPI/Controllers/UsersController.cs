using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace UsersAPI.Controllers
{
    public class UsersController : ApiController
    {
        public string usersDatajson = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/usersData.json"));

        // GET api/users
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(usersDatajson, Encoding.UTF8, "application/json"),
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
            var userListsob = JsonConvert.DeserializeObject<AllUsersModel>(usersDatajson);

            var userLists = userListsob.users;

            foreach(var user in userLists)
            {
                if (user.FirstName.ToLower().Equals(firstName.ToLower()) ||
                    user.LastName.ToLower().Equals(lastName.ToLower()))
                    return Json(user);
            }

            return Ok("No user found");
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
        }
    }
}
