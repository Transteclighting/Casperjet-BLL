using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class SmsMessageInividualHistoryRepository : Repository<SmsMessageInividualHistory>, ISmsMessageInividualHistoryRepository
    {
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

        public SmsMessageInividualHistoryRepository(DbContext context) : base(context)
        {
         
        }

        public bool SendSms(string mobileNo, string smsText)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            
            {
                var tdCredential = unitOfWork.SmsApiCredentials.SingleOrDefault(a => a.Id == 1);

                string htmlResult;

                string param = "user={0}&pass={1}&sms[0][0]={2}&sms[0][1]={3}&sms[0][2]={4}&sid={5}";
                param = string.Format(param, tdCredential.UserName, tdCredential.Password, mobileNo,
                                HttpUtility.UrlEncode(smsText.Trim()), 1, tdCredential.UserId);
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        htmlResult = wc.UploadString(tdCredential.Uri, param);
                    }
                }
                catch
                {
                    return false;
                }
                var smsApiResponseRefferenceIdXml = XDocument.Parse(htmlResult);
                var sReferenceId = smsApiResponseRefferenceIdXml.Descendants("REFERENCEID").FirstOrDefault() == null
                    ? string.Empty : smsApiResponseRefferenceIdXml.Descendants("REFERENCEID").First().Value;

                return sReferenceId != string.Empty;
            }

            
        }
    }
}