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
    [RoutePrefix("api/v1/EMI")]
    public class EMIController : ApiController
    {
        [HttpGet]
        [Route("detail")]
        [AllowAnonymous]
        public IHttpActionResult GetEMIDetail([FromUri] string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var emi = unitOfWork.EMI.GetProductEmi(productCode);
                if (emi == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("EMI not found for this product!", HttpStatusCode.BadRequest));
                }
                return Ok(emi);
            }
        }

        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetAllEMIs([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var emi = unitOfWork.EMI.GetEmiList(pageIndex, pageSize);
                if (emi == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("EMI not found!", HttpStatusCode.BadRequest));
                }
                return Ok(emi);
            }
        }
    }
}
