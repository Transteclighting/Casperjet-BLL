using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{

    public class SalesInvoiceEcommerceRepository : Repository<SalesInvoiceEcommerce>, ISalesInvoiceEcommerceRepository
    {
        public SalesInvoiceEcommerceRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }

}