using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using Newtonsoft.Json;


namespace CJ.API.Models.Utility
{
    public class CasperJetExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //string exceptionMessage = actionExecutedContext.Exception.InnerException?.Message ?? actionExecutedContext.Exception.Message;

            AppLogger.PrintException(actionExecutedContext.Exception);
            string errMsg = JsonConvert.SerializeObject(new
            {
                Message = "Internal Server Error. Please try again."
            });
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                //Content = new StringContent ("An unhandled exception was thrown by service."),  
                ReasonPhrase = "Internal Server Error.",
                Content = new StringContent(errMsg, Encoding.UTF8, "application/json")

            };
            actionExecutedContext.Response = response;
        }
    }
}