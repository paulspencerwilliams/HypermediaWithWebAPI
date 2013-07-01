using System;
using System.Json;
using System.Net.Http;

namespace AcceptanceTests
{
    public class ApiProxy
    {
        private Resource _resource;

        public enum ApiFormat { Json, Xml}
        public ApiProxy(ApiFormat format)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost/api");
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    var jsonValue = JsonValue.Parse(responseString);
                    _resource = new Resource(jsonValue, format);
                }
                else
                {
                    throw new HttpRequestException("Request failed with " + response.ToString());
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