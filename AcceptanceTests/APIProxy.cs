using System;
using System.Json;
using System.Net.Http;

namespace AcceptanceTests
{
    public class ApiProxy
    {
        private readonly ApiFormat _format;
        private Resource _resource;
        private string _baseURI;

        public enum ApiFormat { Json, Xml}
        public ApiProxy(ApiFormat format)
        {
            _format = format;
            _baseURI = "http://localhost";
            _resource = PerformRequest(format,  "/api");
        }

        private Resource PerformRequest(ApiFormat format, string uri)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseURI + uri);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    var jsonValue = JsonValue.Parse(responseString);
                    return new Resource(jsonValue, format);
                }
                else
                {
                    string message = String.Format("Request failed with code ({0}) and message '{1}'",
                                                   new object[]
                                                       {(int) response.Result.StatusCode, response.Result.ReasonPhrase});
                    throw new Exception(message);
                }
            }
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

        public void FollowLink(string rel)
        {
            string uri = (string) _resource.JsonValue["_links"]["self"]["href"];
            _resource = PerformRequest(_format, uri );

        }

        public class Resource
        {
            private readonly JsonValue _jsonValue;
            private readonly ApiFormat _format;

            public Resource(JsonValue jsonValue, ApiFormat format)
            {
                _jsonValue = jsonValue;
                _format = format;
            }

            public ApiFormat Format
            {
                get { return _format; }
            }

            public JsonValue JsonValue
            {
                get { return _jsonValue; }
            }
        }
    }
}