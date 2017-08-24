using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Store.Controllers
{
    public class UserController : ApiController
    {

        [ResponseType(typeof(userlogged))]
        public IHttpActionResult Get()
        {
            var user = new userlogged();
            user.Name = User.Identity.Name;
            user.Logged = User.Identity.IsAuthenticated.ToString();

            return Ok(user);
        }

    }



}

internal class userlogged
{
    public string Name { get; set; }
    public string Logged { get; set; }
}

