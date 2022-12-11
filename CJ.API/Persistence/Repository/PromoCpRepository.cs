using System.Linq;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class PromoCpRepository : Repository<PromoCp>, IPromoCpRepository
    {
        public double GetPromoDiscount(string productCode)
        {
            string query = @"Select isnull(sum(DisAmount),0) DisAmount 
            From
            (
            Select ProductCode, min(RSP) - ISNULL(min(DisAmount), 0) DisAmount
            From
            (
            Select A.ConsumerPromoID, A.SlabID, ProductCode, RSP, c.ProductID,
            case when OfferType = 2 then RSP * Discount / 100 else Discount end DisAmount
            From TELSYSDB.DBO.t_PromoCPOfferDetail a,
            (
            Select a.ConsumerPromoID, SlabID, a.ProductID
            From TELSYSDB.DBO.t_PromoCPProductFor a, TELSYSDB.DBO.t_PromoCPSlabRatio b
            where a.ConsumerPromoID = b.ConsumerPromoID and a.ProductID = b.ProductID and Qty = 1
            and a.ConsumerPromoID in  
            --Single Product--
            (
            Select ConsumerPromoID
            From TELSYSDB.DBO.t_PromoCPProductFor group by ConsumerPromoID
            having count(ProductID) = 1)
            --Single Slab--
            and a.ConsumerPromoID in (Select ConsumerPromoID From TELSYSDB.DBO.t_PromoCPSlab
            group by ConsumerPromoID having count(SlabID) = 1)
            ) B,TELSYSDB.DBO.v_ProductDetails c, TELSYSDB.DBO.t_PromoCP d, TELSYSDB.DBO.t_PromoCPSalesType e
            where OfferType in (1, 2)  
            AND a.ConsumerPromoID = b.ConsumerPromoID and a.SlabID = b.SlabID
            and b.ProductID = c.ProductID and a.ConsumerPromoID = d.ConsumerPromoID
            and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate
            and d.IsActive = 1 and a.ConsumerPromoID = e.ConsumerPromoID and SalesType in (1, 6)  
            and ConsumerPromoNo not in (Select SalesPromotionNo From[TELAddDB].dbo.[t_SalesPromoDisableforEcommerce] where Company = 'TEL')  and d.Status = 1
            ) xx
            group by ConsumerPromoID, SlabID, ProductCode, ProductID
            ) Main where ProductCode= '" + productCode + "'";


            var promoAmount = CasperJetContext.Database.SqlQuery<double>(query).FirstOrDefault();
            return promoAmount;

        }


        public PromoCpRepository(CasperJetContext context) : base(context)
        {

        }

        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }



}