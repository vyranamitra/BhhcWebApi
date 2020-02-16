using BhhcWebApi.Models;
using BhhcWebApi.Utilities;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BhhcWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BhhcController : ApiController
    {
        private string authToken = "683202f0-d438-4b47-a426-813eb94f9d14";
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            HttpContext httpContext = HttpContext.Current;
            if (Request.Headers == null ||
                Request.Headers.Authorization == null ||
               string.IsNullOrEmpty(Request.Headers.Authorization.Parameter))
            {
                return Unauthorized();
            }

            //is this an authorized request
            string inputToken = Request.Headers.Authorization.Parameter;
            if (string.IsNullOrEmpty(inputToken))
            {
                return Unauthorized();
            }
            
            if (!Authentication.IsAuthorized(authToken, inputToken))
            {
                return Unauthorized();
            }

            using (BhhcDBContext db = new BhhcDBContext())
            {
                return Ok(db.Reasons);
            }
        }
    }
}
