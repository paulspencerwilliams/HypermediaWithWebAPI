using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    public class BlogPostsController : ApiController
    {

        public BlogPostsController()
        {
            var blogPost1 = new BlogPostRepresentation { title = "my first post", id = 1 };
            var blogPost2 = new BlogPostRepresentation { title = "the sql", id = 2 };
            _blogPosts = new List<BlogPostRepresentation>();
            _blogPosts.Add(blogPost1);
            _blogPosts.Add(blogPost2);
        }
        private List<BlogPostRepresentation> _blogPosts;

        public BlogPostsRepresentation Get()
        {
            string url = Url.Route("DefaultApi", new { controller = "BlogPosts" });
            return new BlogPostsRepresentation(_blogPosts.ToList());
        }


        public BlogPostRepresentation Get(int id)
        {
            foreach (BlogPostRepresentation blogPost in _blogPosts)
            {
                if (blogPost.id == id)
                {
                    return blogPost;
                }
            }
            return null;

        }
    }

}
