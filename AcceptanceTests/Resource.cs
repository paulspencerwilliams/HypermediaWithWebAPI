using System.Json;

namespace AcceptanceTests
{
    public class Resource
    {
        private readonly JsonValue _jsonValue;
        private readonly ApiProxy.ApiFormat _format;

        public Resource(JsonValue jsonValue, ApiProxy.ApiFormat format)
        {
            _jsonValue = jsonValue;
            _format = format;
        }

        public ApiProxy.ApiFormat Format
        {
            get { return _format; }
        }

        public JsonValue JsonValue
        {
            get { return _jsonValue; }
        }
    }
}