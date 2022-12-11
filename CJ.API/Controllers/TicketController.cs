using CJ.API.Models.Utility;
using CJ.API.Models.ViewModel;
using CJ.API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/ticket")]
    public class TicketController : ApiController
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetTicket([FromUri] List<int> webTicketId)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var ticket = unitOfWork.Ticket.GetTecketList(webTicketId);
                return Ok(ticket);
            }
        }
        [HttpGet]
        [Route("Customer-detail")]
        public IHttpActionResult GetCustomerTecket([FromUri] string phoneNo, [FromUri]int pageIndex, [FromUri]int pageSize)
        {
            if (string.IsNullOrWhiteSpace(phoneNo))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Phone number can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var ticket = unitOfWork.Ticket.GetCustomerTecket(phoneNo, pageIndex, pageSize);
                return Ok(ticket);
            }
        }
    }
}
