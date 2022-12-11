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
    [RoutePrefix("api/v1/consumer")]
    public class CustomerController : ApiController
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
                try
                {
                    unitOfWork.ConsumerDetailWebsite.Add(oConsumerDetailWebsite);
                    unitOfWork.Save();
                    transaction.Commit();
                    return Ok("Consumer detail saved successfully");
                }
                catch
                {
                    transaction.Rollback();
                    throw;
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
        [Route("consumer-detail")]
        [AllowAnonymous]
        public IHttpActionResult Getconsumerdetailwebsite([FromUri] string phoneNo)
        {
            if (string.IsNullOrWhiteSpace(phoneNo))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("phoneNo can not be empty", HttpStatusCode.BadRequest));
            }

            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var consumer = unitOfWork.ConsumerDetailWebsite.SingleOrDefault(a => a.Phone == phoneNo.Trim());
                if (consumer == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid phoneNo", HttpStatusCode.BadRequest));
                }

                var consumerdetail = unitOfWork.ConsumerDetailWebsite.GetConsumerDetailWebsite(phoneNo);
                return Ok(consumerdetail);
            }
        }

        [HttpGet]
        [Route("consumer-detail-list")]
        [AllowAnonymous]
        public IHttpActionResult Getconsumerdetaillistwebsite([FromUri] DateTime createdate)
        {
            if (string.IsNullOrEmpty(createdate.ToString()))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("create date can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var consumerdetaillist = unitOfWork.ConsumerDetailWebsite.GetConsumerDetaillistWebsite(createdate);
                return Ok(consumerdetaillist);
            }
        }
        


    }
}
