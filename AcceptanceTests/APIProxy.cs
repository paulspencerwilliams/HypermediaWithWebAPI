using System;
using System.Linq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace AcceptanceTests
{
    public class ApiProxy
    {
        public enum ApiFormat
        {
            Json,
            Xml
        }

        private Representation _representation;
        private readonly ResourceRequester _resourceRequester;

        public ApiProxy(ApiFormat format)
        {
            _resourceRequester = new ResourceRequester(format, "http://localhost");
            _representation = ResourceRequester.PerformRequest("/api");
        }


        public Representation CurrentRepresentation
        {
            get
            {
                if (_representation == null)
                {
                    throw new NullReferenceException("CurrentResource hasn't been set yet, please navigate somewhere!");
                }
                return _representation;
            }
        }

        public ResourceRequester ResourceRequester
        {
            get { return _resourceRequester; }
        }

        public void FollowLink()
        {
            var link = _representation.JsonValue["_links"]["blogPosts"];
            _representation = ResourceRequester.PerformRequest(link.Value<string>("href"));
        }

        public void FollowLink(JObject resource)
        {
            _representation = ResourceRequester.PerformRequest(resource["_links"]["self"].Value<string>("href"));
        }

        public void FollowLink(String uri)
        {
            _representation = ResourceRequester.PerformRequest(uri);
        }

        
    }
}