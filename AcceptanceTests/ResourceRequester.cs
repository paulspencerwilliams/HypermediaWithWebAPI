using System;
using System.Json;
using System.Net.Http;


namespace AcceptanceTests
{
    public class ResourceRequester
    {
        private readonly ApiProxy.ApiFormat _format;
        private string _baseURI;

        public ResourceRequester(ApiProxy.ApiFormat format, string baseUri)
        {
            _format = format;
            _baseURI = baseUri;
        }

        public Resource PerformRequest(string uri)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseURI + uri);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    var jsonValue = JsonValue.Parse(responseString);
                    return new Resource(jsonValue, _format);
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
    }
}