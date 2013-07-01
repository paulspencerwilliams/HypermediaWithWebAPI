using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    public class APIController : ApiController
    {
        // GET api/api
        public API Get()
        {
            return new API();
        }


    }
}
