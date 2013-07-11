using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace AcceptanceTests
{
    public class ResourceRequester
    {
        private readonly ApiProxy.ApiFormat _format;
        private string _baseURI;
        private readonly ResponseParser _responseParser;

        public ResourceRequester(ApiProxy.ApiFormat format, string baseUri)
        {
            _format = format;
            _baseURI = baseUri;
            _responseParser = new ResponseParser();
        }

        public Representation PerformRequest(string uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                var response = client.GetAsync(_baseURI + uri);
                return _responseParser.Parse(response, _format);
            }
        }
    }
}