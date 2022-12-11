using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Caching;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.ServiceModel.Channels;

namespace CJ.API.Models.Utility
{
    public class RequestCacheAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public int Seconds { get; set; }
        public string Message { get; set; }
        private string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper) request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }

            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                var prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }

            return null;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var key = string.Concat(Name, "-", GetClientIp(actionContext.Request));
            var allowExecute = false;

            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key,
                    true, 
                    null, 
                    DateTime.Now.AddSeconds(Seconds), 
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null);
                allowExecute = true;
            }

            if (!allowExecute)
            {
                if (string.IsNullOrEmpty(Message))
                {
                    Message = "You may only perform this action every {n} seconds.";
                }

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Conflict,
                    Message.Replace("{n}", Seconds.ToString())
                );
            }
        }
        
    }
}