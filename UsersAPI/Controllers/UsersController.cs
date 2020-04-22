using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace UsersAPI.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public HttpResponseMessage Get()
        {
            var json = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/usersData.json"));

            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET api/user/5
        /// <summary>
        /// Get all users information by id
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>all information of the user</returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
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
