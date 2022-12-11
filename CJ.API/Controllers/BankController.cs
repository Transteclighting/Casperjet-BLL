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
    [RoutePrefix("api/v1/Bank")]
    public class BankController : ApiController
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetAllBanks([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var bank = unitOfWork.Bank.GetBankList(pageIndex, pageSize);
                if (bank == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Bank not found!", HttpStatusCode.BadRequest));
                }
                return Ok(bank);
            }
        }
    }
}
