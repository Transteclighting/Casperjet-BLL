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
    [RoutePrefix("api/v1/store")]
    public class StoreController : ApiController
    {
        [HttpGet]
        [Route("detail")]
        [AllowAnonymous]
        public IHttpActionResult GetStoreDetail([FromUri] string shortcode)
        {
            if (string.IsNullOrWhiteSpace(shortcode))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Short code can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var store = unitOfWork.StoreInventoryViews.GetStoreDetail(shortcode);
                if (store==null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Store not found!", HttpStatusCode.BadRequest));
                }
                return Ok(store);
            }
        }

        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetAllStoreDetail()
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var store = unitOfWork.AllStoreInventoryViews.GetAllStoreDetail();
                return Ok(store);
            }
        }
    }
}
