using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJ.API.Persistence.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

        public Brand GetBrand(int brandId)
        {
            #region Brands
            var query = @"select BrandID,BrandDesc as BrandName from t_Brand where BrandLevel=1 and IsActive=1 and BrandID=" + brandId;
            Brand queryBrands = CasperJetContext.Database.SqlQuery<Brand>(query).FirstOrDefault();
            #endregion
            return queryBrands;
        }
        public List<Brand> GetBrandList(int pageIndex, int pageSize)
        {
            List<Brand> queryBrands = new List<Brand>();
            #region Brands
            var query = @"select BrandID,BrandDesc as BrandName from t_Brand where BrandLevel=1 and IsActive=1 ORDER BY 1 ASC";
            //query = string.Format(query);
            var pagination = Class.Utility.ConvertToPaginationQuery(query, pageIndex, pageSize);
            queryBrands = CasperJetContext.Database.SqlQuery<Brand>(pagination).ToList();
            #endregion
            return queryBrands;
        }

        public List<BrandProduct> GetBrandProducts(int brandId)
        {
            #region Brands
            var query = @"select ProductCode from v_ProductDetails Where BrandID=" + brandId;
           List<BrandProduct> queryBrands = CasperJetContext.Database.SqlQuery<BrandProduct>(query).ToList();
            #endregion
            return queryBrands;
        }
    }
}