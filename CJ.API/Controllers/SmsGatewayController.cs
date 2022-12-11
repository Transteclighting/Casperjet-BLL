using System.Linq;
using System.Net;
using System.Web.Http;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Utility;
using CJ.API.Persistence;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/transcom-digital-sms-gateway")]
    public class SmsGatewayController : ApiController
    {
        [HttpPost]
        [Route("send-message")]
        public IHttpActionResult SendMessage([FromBody] SmsMessageInividualHistory aSmsMessageInividualHistory)
        {
            if (aSmsMessageInividualHistory.MobileNo.Trim().Length != 11 
                || !aSmsMessageInividualHistory.MobileNo.Trim().StartsWith("01"))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Invalid mobile number",  HttpStatusCode.BadRequest));
            }
           
            if (string.IsNullOrWhiteSpace(aSmsMessageInividualHistory.Message))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Message cannot be empty", HttpStatusCode.BadRequest));
            }

            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                bool isSuccess  =  unitOfWork.SmsMessageInividualHistories.SendSms(aSmsMessageInividualHistory.MobileNo, aSmsMessageInividualHistory.Message);
                if (isSuccess)
                {
                    try
                    {
                        aSmsMessageInividualHistory.Id = unitOfWork.SmsMessageInividualHistories.GetAll()
                                                        .DefaultIfEmpty()
                                                        .Max(a => a?.Id + 1 ?? 1);
                        aSmsMessageInividualHistory.SendBy = 1666;
                        unitOfWork.SmsMessageInividualHistories.Add(aSmsMessageInividualHistory);
                        unitOfWork.Save();
                    }
                    catch
                    {
                        //Nothing to do here
                    }
                    return Ok("Your message has been sent");
                }
                return ResponseMessage(ErrorResponse.GetErrorResponse("Internal server error. Please try again.", HttpStatusCode.InternalServerError));

            }
        }
    }
}
