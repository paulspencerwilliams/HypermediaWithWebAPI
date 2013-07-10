
using Newtonsoft.Json.Linq;

namespace AcceptanceTests
{
    public class Resource
    {
        private readonly JObject _jsonValue;
        private readonly ApiProxy.ApiFormat _format;

        public Resource(JObject jsonValue, ApiProxy.ApiFormat format)
        {
            _jsonValue = jsonValue;
            _format = format;
        }

        public ApiProxy.ApiFormat Format
        {
            get { return _format; }
        }

        public JObject JsonValue
        {
            get { return _jsonValue; }
        }
    }
}