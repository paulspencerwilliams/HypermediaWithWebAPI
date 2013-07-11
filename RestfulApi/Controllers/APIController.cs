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
