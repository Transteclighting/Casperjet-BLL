using CJ.API.Models.Core.Domain;

namespace CJ.API.Models.Core.Repository
{
    public interface IProductPriceRepository : IRepository<ProductPrice>
    {
        double GetRSP(string sProductCode);
    }
   
}
