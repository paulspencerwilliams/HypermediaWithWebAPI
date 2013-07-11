
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace AcceptanceTests
{
    public class Representation
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _errorMessage;
        private readonly JObject _jsonValue;
        private readonly ApiProxy.ApiFormat _format;

        public Representation(JObject jsonValue, ApiProxy.ApiFormat format)
        {
            _jsonValue = jsonValue;
            _format = format;
        }

        public Representation(HttpStatusCode statusCode, string errorMessage)
        {
            _statusCode = statusCode;
            _errorMessage = errorMessage;
        }

        public ApiProxy.ApiFormat Format
        {
            get { return _format; }
        }

        public JObject JsonValue
        {
            get { return _jsonValue; }
        }


        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
        }


        public JObject FindBlogPostRepresentation(string blogPostTitle)
        {
            var blogPosts = (JArray)JsonValue["_embedded"]["blogposts"];
            return (JObject) blogPosts.Where(blogPost => (string) blogPost["title"] == blogPostTitle).FirstOrDefault();
        }
    }
}