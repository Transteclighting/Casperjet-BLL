using CJ.API.Models.Core.Domain;

namespace CJ.API.Models.Core.Repository
{
    public interface ISmsMessageInividualHistoryRepository : IRepository<SmsMessageInividualHistory>
    {
        bool SendSms(string mobileNo, string smsText);
    }
}
