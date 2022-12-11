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
    [RoutePrefix("api/v1/consumer")]
    public class ConsumerController : ApiController
    {

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add([FromBody] ConsumerDetailWebsite oConsumerDetailWebsite)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            using (var transaction = unitOfWork.BeginTransaction())
            {
                var consumerdetaillist = unitOfWork.ConsumerDetailWebsite.GetConsumerDetailWebsite(oConsumerDetailWebsite.Phone);
                if (consumerdetaillist == null)
                {
                   try
                   {
                        unitOfWork.ConsumerDetailWebsite.Add(oConsumerDetailWebsite);
                        unitOfWork.Save();
                        transaction.Commit();
                        return Ok("Consumer detail saved successfully. Id=" + oConsumerDetailWebsite.Id);
                   }
                   catch(Exception x)
                   {
                        transaction.Rollback();
                        throw(x);
                   }
                }
                else
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Phone number already exists!", HttpStatusCode.BadRequest));
                }
            }
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update([FromBody] ConsumerDetailWebsite oConsumerDetailWebsite)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            var customerId = (int)oConsumerDetailWebsite.Id;
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var consumer = unitOfWork.ConsumerDetailWebsite.Get(customerId);
                //var consumer = unitOfWork.ConsumerDetailWebsite.SingleOrDefault(a => a.Phone == phoneNo.Trim());

                if (consumer == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid Consumer", HttpStatusCode.BadRequest));
                }
                using (var transaction = unitOfWork.BeginTransaction())
                {
                    try
                    {
                        consumer.FirstName = oConsumerDetailWebsite.FirstName;
                        consumer.MiddleName = oConsumerDetailWebsite.MiddleName;
                        consumer.LastName = oConsumerDetailWebsite.LastName;
                        consumer.Phone = oConsumerDetailWebsite.Phone;
                        consumer.Region = oConsumerDetailWebsite.Region;
                        consumer.Zip = oConsumerDetailWebsite.Zip;
                        consumer.Address = oConsumerDetailWebsite.Address;
                        consumer.Area = oConsumerDetailWebsite.Area;
                        consumer.City = oConsumerDetailWebsite.City;
                        consumer.Date = oConsumerDetailWebsite.Date;
                        consumer.Email = oConsumerDetailWebsite.Email;

                        unitOfWork.Save();
                        transaction.Commit();
                        return Ok("Consumer detail updated successfully");
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        [HttpGet]
        [Route("detail")]
        [AllowAnonymous]
        public IHttpActionResult Getconsumerdetailwebsite([FromUri] string phoneNo)
        {
            if (string.IsNullOrWhiteSpace(phoneNo))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("phoneNo can not be empty", HttpStatusCode.BadRequest));
            }

            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var consumer = unitOfWork.ConsumerDetailWebsite.GetConsumerDetailWebsite(phoneNo);
                if (consumer == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid phoneNo", HttpStatusCode.BadRequest));
                }
               //var consumerdetail = unitOfWork.ConsumerDetailWebsite.GetConsumerDetailWebsite(phoneNo);
                return Ok(consumer);
            }
        }

        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult Getconsumerdetaillistwebsite([FromUri]int pageIndex, [FromUri]int pageSize, [FromUri]DateTime? fromDate = null, [FromUri]DateTime? toDate = null)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var consumerdetaillist = unitOfWork.ConsumerDetailWebsite.GetConsumerDetaillistWebsite(fromDate, toDate, pageIndex, pageSize);
                if (consumerdetaillist == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Consumer not found!", HttpStatusCode.BadRequest));
                }
                return Ok(consumerdetaillist);
            }
        }
    }
}
