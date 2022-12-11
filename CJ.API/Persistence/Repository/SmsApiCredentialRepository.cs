using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class SmsApiCredentialRepository : Repository<SmsApiCredential>, ISmsApiCredentialRepository
    {
        public SmsApiCredentialRepository(CasperJetContext context): base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}