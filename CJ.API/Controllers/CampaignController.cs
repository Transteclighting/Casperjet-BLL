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
    [RoutePrefix("api/v1/Campaign")]
    public class CampaignController : ApiController
    {
        //[HttpGet]
        //[Route("detail")]
        //[AllowAnonymous]
        //public IHttpActionResult GetCampaignDetail([FromUri] string productCode)
        //{
        //    if (string.IsNullOrWhiteSpace(productCode))
        //    {
        //        return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty", HttpStatusCode.BadRequest));
        //    }
        //    using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
        //    {
        //        var campaign = unitOfWork.Campaign.GetProductCampaign(productCode);
        //        if (campaign == null)
        //        {
        //            return ResponseMessage(ErrorResponse.GetErrorResponse("Campaign not found for this product!", HttpStatusCode.BadRequest));
        //        }
        //        return Ok(campaign);
        //    }
        //}
        [HttpGet]
        [Route("products")]
        [AllowAnonymous]
        public IHttpActionResult GetCampaignProduct([FromUri] string campaignId)
        {
            if (string.IsNullOrWhiteSpace(campaignId))
            {
                return ResponseMessage(ErrorResponse.GetErrorResponse("Product code can not be empty", HttpStatusCode.BadRequest));
            }
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var campaign = unitOfWork.Campaign.GetCampaignProducts(campaignId);
                if (campaign == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Campaign not found for this product!", HttpStatusCode.BadRequest));
                }
                return Ok(campaign);
            }
        }

        [HttpGet]
        [Route("list")]
        [AllowAnonymous]
        public IHttpActionResult GetAllCampaigns([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                var campaign = unitOfWork.Campaign.GetCampaignList(pageIndex, pageSize);
                if (campaign == null)
                {
                    return ResponseMessage(ErrorResponse.GetErrorResponse("Product not found!", HttpStatusCode.BadRequest));
                }
                return Ok(campaign);
            }
        }
    }
}
