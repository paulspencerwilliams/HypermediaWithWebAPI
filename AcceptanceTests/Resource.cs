
using System.Net;
using Newtonsoft.Json.Linq;

namespace AcceptanceTests
{
    public class Resource
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _errorMessage;
        private readonly JObject _jsonValue;
        private readonly ApiProxy.ApiFormat _format;

        public Resource(JObject jsonValue, ApiProxy.ApiFormat format)
        {
            _jsonValue = jsonValue;
            _format = format;
        }

        public Resource(HttpStatusCode statusCode, string errorMessage)
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
    }
}