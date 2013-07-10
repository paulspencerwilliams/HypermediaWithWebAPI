using System.Web;
using System.Web.Mvc;
using WebApi.Hal;

namespace RestfulApi.Models
{
    public class BlogPostRepresentation : Representation
    {
        public int id { get; set; }
        public string title { get; set; }
        protected override void CreateHypermedia()
        {
            var urlHelper =
                new UrlHelper(HttpContext.Current.Request.RequestContext);
            Rel = "_self";
            Href = urlHelper.HttpRouteUrl("DefaultApi", new { controller = "blogposts", id = id });
        }

        
    }
}