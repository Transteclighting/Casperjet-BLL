using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CJ.API.Persistence;
using Newtonsoft.Json;

namespace CJ.API.Models.Utility
{
    public class ThirdPartyAuthorization : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = ErrorResponse.GetErrorResponse("Empty user credential.", HttpStatusCode.Unauthorized);
            }
            else
            {
                string userId;
                string password;
                try
                {
                    var authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                    authenticationToken = authenticationToken.Replace("Basic ", " ");
                    var decodeauthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                    var userPasswordArray = decodeauthenticationToken.Split(':');
                    userId = userPasswordArray[0];
                    password = userPasswordArray[1];
                }
                catch(Exception ex)
                {
                    actionContext.Response = ErrorResponse.GetErrorResponse("Invalid user credential", HttpStatusCode.Unauthorized);
                    return;
                }

                if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrEmpty(password))
                {
                    actionContext.Response = ErrorResponse.GetErrorResponse("Invalid user credential", HttpStatusCode.Unauthorized);
                }

                using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
                {

                    var apiCredential = unitOfWork.SmsApiCredentials.SingleOrDefault(a =>
                                                                a.UserId == userId
                                                                && a.IsActive == 1
                                                                && a.Password == password);

                    if (apiCredential == null)
                    {
                        actionContext.Response = ErrorResponse.GetErrorResponse("Invalid user credential", HttpStatusCode.Unauthorized);
                    }
                }
            }
        }
    }
}