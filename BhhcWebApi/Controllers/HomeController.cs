using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BhhcWebApi.Controllers
{
    public class HomeController : ApiController
    {
        // GET: Home
        public IHttpActionResult Index()
        {
            HttpContext httpContext = HttpContext.Current;
            return Ok("Hello World!!");
        }
    }
}