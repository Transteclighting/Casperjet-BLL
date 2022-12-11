using CJ.API.Models.Core.Domain;
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
    [RoutePrefix("api/v1/product")]
    public class ProductDetailController : ApiController
    {
        [HttpGet]
        [Route("detail")]
        [AllowAnonymous]
        public IHttpActionResult GetWarehouseStock([FromUri] string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var stock = unitOfWork.ProductDetailViews.GetSkuDetail(productCode);
                if (stock==null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Product not found!", HttpStatusCode.BadRequest));
                }
                return Ok(stock);
            }
        }
        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetProductList([FromUri]int pageIndex, [FromUri]int pageSize,[FromUri]DateTime? fromDate=null, [FromUri]DateTime? toDate= null)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var products = unitOfWork.ProductDetailViews.GetProductList(fromDate, toDate, pageIndex, pageSize);
                return Ok(products);
            }
        }
        [HttpGet]
        [Route("listNew")]
        [AllowAnonymous]
        public IHttpActionResult GetProductListNew([FromUri]int pageIndex, [FromUri]int pageSize, [FromUri]DateTime? fromDate = null, [FromUri]DateTime? toDate = null)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var products = unitOfWork.ProductDetailViews.GetProductListNew(fromDate, toDate, pageIndex, pageSize);
                return Ok(products);
            }
        }
    }
}
