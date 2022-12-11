using System.Net;
using System.Web.Http;
using CJ.API.Models.Utility;
using CJ.API.Persistence;


namespace CJ.API.Controllers
{

    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/product-price")]
    public class ProductPriceController : ApiController
    {
        [HttpGet]
        [Route("get-retail-sales-price")]
        public IHttpActionResult GetRsp([FromUri] string productCode)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                if (productCode == null)
                {
                  return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty",HttpStatusCode.BadRequest));
                }

                var price = unitOfWork.ProductPrices.GetRSP(productCode);
                if (price <= 0)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Not found.",HttpStatusCode.BadRequest));
                }
                return Ok(price);
            }
        }
    }
}
