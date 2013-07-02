using WebApi.Hal;

namespace RestfulApi.Models
{
    public class BlogPostRepresentation : Representation
    {
        public string Title { get; set; }
        protected override void CreateHypermedia()
        {
            Rel = "_self";
            Href = "http://bloglink?title=" + Title;
        }
    }
}