using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
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
            var urlHelper =
                new UrlHelper(HttpContext.Current.Request.RequestContext);
            Href = urlHelper.HttpRouteUrl("DefaultApi", new { controller = "blogposts" });
            Rel = "blogposts";
        }


    }
}