using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace CJ.API.Models.Utility
{
    public class ErrorResponse
    {
        public static HttpResponseMessage GetErrorResponse(string msg,string reason,HttpStatusCode status)
        {
            var err = JsonConvert.SerializeObject(
                       new
                       {
                           Message = msg
                       });
            return new HttpResponseMessage(status)
            {
                ReasonPhrase = reason,
                Content = new StringContent(err, Encoding.UTF8, "application/json")
            };
        }
        public static HttpResponseMessage GetErrorResponse(string msg,  HttpStatusCode status)
        {
            var err = JsonConvert.SerializeObject(
                       new
                       {
                           Message = msg
                       });
            return new HttpResponseMessage(status)
            {
                Content = new StringContent(err, Encoding.UTF8, "application/json")
            };
        }
    }
}