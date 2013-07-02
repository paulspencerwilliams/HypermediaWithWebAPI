using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi.Hal;

namespace RestfulApi.Models
{
    public class BlogPostsRepresentation : RepresentationList<BlogPostRepresentation>
    {

        public BlogPostsRepresentation() :base(new List<BlogPostRepresentation>())
        {
            
        }
        public BlogPostsRepresentation(IList<BlogPostRepresentation> blogPosts) : base(blogPosts)
        {
        }

        protected override void CreateHypermedia()
        {
            var httpContextWrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
            var urlHelper =
                new UrlHelper(new RequestContext(httpContextWrapper, RouteTable.Routes.GetRouteData(httpContextWrapper)));
            Href = urlHelper.RouteUrl("DefaultApi", new { Controller = "BlogPosts", Action="Get" });
            Rel = "blogPosts";
        }


    }
}