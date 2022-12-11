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
    [RoutePrefix("api/v1/Brand")]
    public class BrandController : ApiController
    {
        [HttpGet]
        [Route("detail")]
        [AllowAnonymous]
        public IHttpActionResult GetBrandDetail([FromUri] int brandId)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var brand = unitOfWork.Brand.GetBrand(brandId);
                if (brand == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("brand not found!", HttpStatusCode.BadRequest));
                }
                return Ok(brand);
            }
        }
        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetAllBrands([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var brand = unitOfWork.Brand.GetBrandList(pageIndex, pageSize);
                if (brand == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("No brand found!", HttpStatusCode.BadRequest));
                }
                return Ok(brand);
            }
        }
        [HttpGet]
        [Route("products")]
        [AllowAnonymous]
        public IHttpActionResult GetBrandbrands([FromUri] int brandId)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var products = unitOfWork.Brand.GetBrandProducts(brandId);
                if (products == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Products not found for this brand!", HttpStatusCode.BadRequest));
                }
                return Ok(products);
            }
        }
    }
}
