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
            var blogPost1 = new BlogPostRepresentation{Title = "my first post"};
            var blogPost2 = new BlogPostRepresentation{Title = "the sql"};
            List<BlogPostRepresentation> blogPosts = new List<BlogPostRepresentation>();
            blogPosts.Add(blogPost1);
            blogPosts.Add(blogPost2);

            return new BlogPostsRepresentation(blogPosts.ToList());
        }
    }

}
