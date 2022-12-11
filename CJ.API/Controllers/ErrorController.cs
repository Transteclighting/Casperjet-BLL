using System.Net;
using System.Net.Http;
using System.Web.Http;
using CJ.API.Models.Utility;
using System.Web.Http.Description;

namespace CJ.API.Controllers
{
    [RoutePrefix("api/Error")]
    [ThirdPartyAuthorization]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ApiController
    {
        //[HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        //public HttpResponseMessage Handle404()
        //{
        //    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
        //    {
        //        ReasonPhrase = "The requested resource is not found"
        //    };
        //    return responseMessage;
        //}
        [Route("Handle404")]
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public IHttpActionResult Handle404()
        {

            return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid URL", HttpStatusCode.NotFound));
        }
    }
}
