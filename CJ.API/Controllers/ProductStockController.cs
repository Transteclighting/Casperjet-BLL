using System.Net;
using System.Web.Http;
using CJ.API.Models.Utility;
using CJ.API.Persistence;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/product-stock")]
    public class ProductStockController : ApiController
    {
        [HttpGet]
        [Route("get-warehouse-stock")]
        public IHttpActionResult GetWarehouseStock([FromUri] string warehouseCode,
                                                    [FromUri] string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty",  HttpStatusCode.BadRequest));
            }
            if (string.IsNullOrWhiteSpace(warehouseCode))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Warehouse code can not be empty",  HttpStatusCode.BadRequest));
            }


            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var product = unitOfWork.Products.SingleOrDefault(a => a.ProductCode == productCode.Trim());
                if (product == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid product code", HttpStatusCode.BadRequest));
                }

                var stock = unitOfWork.ProductStocks.WarehouseWiseStock(warehouseCode, productCode);
                return Ok(stock);
            }
        }
    }
}
