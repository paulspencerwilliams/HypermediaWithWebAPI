using System;
using System.Json;
using System.Linq;
using System.Net.Http;

namespace AcceptanceTests
{
    public class ApiProxy
    {
        private Resource _resource;
        private readonly ResourceRequester _resourceRequester;

        public enum ApiFormat { Json, Xml}
        public ApiProxy(ApiFormat format)
        {
            _resourceRequester = new ResourceRequester(format, "http://localhost");
            _resource = ResourceRequester.PerformRequest( "/api");
        }


        public Resource CurrentResource
        {
            get 
            { 
                if (_resource == null)
                {
                    throw new NullReferenceException("CurrentResource hasn't been set yet, please navigate somewhere!");
                }
                return _resource;
            }
        }

        public ResourceRequester ResourceRequester
        {
            get { return _resourceRequester; }
        }

        public void FollowLink(string rel)
        {
            var links = (JsonArray) _resource.JsonValue["_links"];
            foreach (JsonObject link in links)
            {
                if ((string) link.GetValue("Rel") == "blogPosts")
                {
                    ResourceRequester.PerformRequest((string) link.GetValue("Href"));
                }
            }

        }
    }
}