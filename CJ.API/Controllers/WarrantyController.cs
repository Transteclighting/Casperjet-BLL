using CJ.API.Models.Utility;
using CJ.API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/warranty")]
    public class WarrantyController : ApiController
    {
        [HttpGet]
        [Route("detail")]
        [AllowAnonymous]
        public IHttpActionResult GetWarrantyDetail([FromUri] string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var stock = unitOfWork.Warranty.GetProductWarranty(productCode);
                if (stock == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Warranty not found for this product!", HttpStatusCode.BadRequest));
                }
                return Ok(stock);
            }
        }

        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetAllWarrantys([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var store = unitOfWork.Warranty.GetWarrantyList(pageIndex, pageSize);
                if (store == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Store not found!", HttpStatusCode.BadRequest));
                }
                return Ok(store);
            }
        }


        [HttpGet]
        [Route("order-data")]
        [AllowAnonymous]
        public IHttpActionResult GetOrderWarrantys([FromUri]string sOrderERPNo)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var store = unitOfWork.Warranty.GetOrderWarranty(sOrderERPNo);
                if (store == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Erp oder not found!", HttpStatusCode.BadRequest));
                }
                return Ok(store);
            }
        }
    }
}
