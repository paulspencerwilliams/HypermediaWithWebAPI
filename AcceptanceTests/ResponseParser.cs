using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AcceptanceTests
{
    public class ResponseParser
    {


        public Representation Parse(Task<HttpResponseMessage> response, ApiProxy.ApiFormat format)
        {   
            if (response.Result.IsSuccessStatusCode)
            {
                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                var jsonValue = JObject.Parse(responseString);
                return new Representation(jsonValue, format);                
            }
            return ParseException(response);
        }

        private Representation ParseException(Task<HttpResponseMessage> response)
        {
            string message = String.Format("Request failed with code ({0}) and message '{1}'",
                                           new object[] { (int)response.Result.StatusCode, response.Result.ReasonPhrase });
            return new Representation(response.Result.StatusCode, message);            
        }
    }
}