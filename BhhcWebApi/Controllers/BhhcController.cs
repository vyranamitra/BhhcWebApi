using BhhcWebApi.Models;
using System;
using System.Web;
using System.Web.Http;

namespace BhhcWebApi.Controllers
{
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
            string authToken = Request.Headers.Authorization.Parameter;
            int index = authToken.IndexOf("Basic ");
            authToken = authToken.Substring("basic ".Length + 1, authToken.Length - index);
            if (!IsAuthorized(authToken))
            {
                return Unauthorized();
            }

            using (BhhcDBContext db = new BhhcDBContext())
            {
                return Ok(db.Reasons);
            }
        }

        /// <summary>
        /// Returns true if the decoded token matches the value of authToken
        /// otherwise returns false
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool IsAuthorized(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }
            string decodedToken = Utilities.Authentication.DecodeToken(token);
            return (authToken.Equals(decodedToken) ? true : false);
        }
    }
}
