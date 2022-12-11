using System.Web.Http;
using CJ.API.Models.Utility;
using System.Web.Http.Description;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            
            return Ok("Hello... :)");
        }
    }
}
