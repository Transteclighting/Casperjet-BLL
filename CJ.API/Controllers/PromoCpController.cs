using System.Net;
using System.Web.Http;
using CJ.API.Models.Utility;
using CJ.API.Persistence;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/consumer-promotion")]
    public class PromoCpController : ApiController
    {
        [HttpGet]
        [Route("get-product-promotion")]
        public IHttpActionResult GetPromoDiscount([FromUri] string productCode)
        {
            if (productCode == null)
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Product code cannot be empty",  HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var product = unitOfWork.Products.SingleOrDefault(a=>a.ProductCode == productCode.Trim());
                if (product == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid product code",  HttpStatusCode.BadRequest));
                }

                var discount = unitOfWork.PromoCPs.GetPromoDiscount(productCode);

                return Ok(discount);
            }
        }
    }
}
