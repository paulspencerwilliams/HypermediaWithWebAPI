using System;
using System.Json;

namespace AcceptanceTests
{
    public class ApiProxy
    {
        public enum ApiFormat
        {
            Json,
            Xml
        }

        private Resource _resource;
        private readonly ResourceRequester _resourceRequester;

        public ApiProxy(ApiFormat format)
        {
            _resourceRequester = new ResourceRequester(format, "http://localhost");
            _resource = ResourceRequester.PerformRequest("/api");
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
            JsonValue link = _resource.JsonValue["_links"]["blogPosts"];
            _resource = ResourceRequester.PerformRequest((string) link.GetValue("href"));
        }
    }
}