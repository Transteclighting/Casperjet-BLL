using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        List<Brand> GetBrandList(int pageIndex, int pageSize);
        Brand GetBrand(int brandId);
        List<BrandProduct> GetBrandProducts(int brandId);
    }
}
