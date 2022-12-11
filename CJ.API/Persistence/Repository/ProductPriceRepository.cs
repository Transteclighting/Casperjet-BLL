using System;
using System.Linq;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class ProductPriceRepository : Repository<ProductPrice>, IProductPriceRepository
    {

        public double GetRSP(string sProductCode)
        {
            string query = @"Select isnull(RSP,0) as RSP From  
                            (Select ProductCode,isnull(RSP,0) RSP From TELSysDB.DBO.v_productDetails  
                            Union All  
                            Select ProductCode,isnull(RSP,0) RSP From TMLSysDB.DBO.v_productDetails  
                            Union All  
                            Select ProductCode,isnull(RSP,0) RSP From BLLDBSERVER01.bllsysdb.dbo.v_ProductDetails) a 
                            where ProductCode= '"+ sProductCode +"'";


            var price = CasperJetContext.Database.SqlQuery<double>(query).FirstOrDefault();
            return price;

        }

        public ProductPriceRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}