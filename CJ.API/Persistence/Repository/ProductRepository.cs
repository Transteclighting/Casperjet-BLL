using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}