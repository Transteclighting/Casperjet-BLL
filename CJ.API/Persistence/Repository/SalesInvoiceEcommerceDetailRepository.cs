using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class SalesInvoiceEcommerceDetailRepository : Repository<SalesInvoiceEcommerceDetail>, ISalesInvoiceEcommerceDetailRepository
    {
        public SalesInvoiceEcommerceDetailRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}