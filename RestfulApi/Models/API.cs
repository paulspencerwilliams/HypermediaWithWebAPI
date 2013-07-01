using WebApi.Hal;

namespace RestfulApi.Models
{
    public class API : Representation
    {
        protected override void CreateHypermedia()
        {
            Links.Add(new Link("blogPosts", "/api/blogposts"));
        }
    }
}