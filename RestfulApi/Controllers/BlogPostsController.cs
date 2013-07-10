using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    public class BlogPostsController : ApiController
    {
        public BlogPostsRepresentation Get()
        {
            var blogPost1 = new BlogPostRepresentation{title = "my first post", id = 1};
            var blogPost2 = new BlogPostRepresentation{title = "the sql", id = 2};
            List<BlogPostRepresentation> blogPosts = new List<BlogPostRepresentation>();
            blogPosts.Add(blogPost1);
            blogPosts.Add(blogPost2);

            string url = Url.Route("DefaultApi", new { controller = "BlogPosts" });


            return new BlogPostsRepresentation(blogPosts.ToList());
        }
    }

}
