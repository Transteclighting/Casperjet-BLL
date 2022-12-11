using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJ.API.Persistence.Repository
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
        public List<RootCampaign> GetCampaignList(int pageIndex, int pageSize)
        {
            List<RootCampaign> campaigns = new List<RootCampaign>();
            #region campaigns
            var query = @"Select ConsumerPromoID as CampaignId,ConsumerPromoNo as Name,DATEADD(second, DATEDIFF(second, GETDATE(), GETUTCDATE()), FromDate AT TIME ZONE 'UTC') as StartDateUTC,FromDate as StartDate,DATEADD(second, DATEDIFF(second, GETDATE(), GETUTCDATE()), ToDate AT TIME ZONE 'UTC') as EndDateUTC,ToDate as EndDate,
                        ProductID,ProductCode,ProductName,Discount From
                        (
                        Select x.ConsumerPromoID,ConsumerPromoNo,FromDate,ToDate,
                        ProductID,ProductCode,ProductName,RSP as PreviousPrice,
                        isnull(case when OfferType = 2 then RSP * Discount / 100 else Discount end,0) Discount,
                        RSP-isnull(case when OfferType = 2 then RSP * Discount / 100 else Discount end,0) as DiscountedPrice
                        From
                        (
                        Select a.ConsumerPromoID,ConsumerPromoNo,FromDate,ToDate,b.ProductID,ProductCode,ProductName,RSP
                        From t_PromoCP a,t_PromoCPProductFor b,t_Product c,
                        (Select ConsumerPromoID from t_PromoCPSalesType where SalesType=6) d,
                        t_FinishedGoodsPrice e
                        where c.ProductID=e.ProductID and a.ConsumerPromoID=b.ConsumerPromoID and b.ProductID=c.ProductID and a.ConsumerPromoID=d.ConsumerPromoID
                        and CAST(GETDATE() as date) between FromDate and ToDate and a.IsActive=1 and Status=1
                        and e.IsCurrent=1
                        and a.ConsumerPromoID in
                        (
                        --Single Product--
                        Select ConsumerPromoID 
                        From TELSYSDB.DBO.t_PromoCPProductFor group by ConsumerPromoID 
                        having count(ProductID) = 1
                        --END Single Product--
                        )
                        and a.ConsumerPromoID in
                        (
                        --Single Slab--
                        Select ConsumerPromoID From TELSYSDB.DBO.t_PromoCPSlab 
                        group by ConsumerPromoID having count(SlabID) = 1
                        --END Single Slab--
                        )
                        ) x
                        left outer join
                        (
                        --Min Offer--
                        Select ConsumerPromoID,OfferType,min(Discount) as Discount
                        From t_PromoCPOfferDetail where OfferType in (1,2)
                        group by ConsumerPromoID,OfferType
                        --End Min Offer--
                        ) y on x.ConsumerPromoID=y.ConsumerPromoID
                        where Discount is not null
                        ) Main  ORDER BY 1 ASC";
            var pagination = Class.Utility.ConvertToPaginationQuery(query, pageIndex, pageSize);
            campaigns = CasperJetContext.Database.SqlQuery<RootCampaign>(pagination).ToList();
            #endregion
            return campaigns;
        }

        //public List<CampaignProduct> GetProductCampaign(string sProductCode)
        //{
        //    List<Campaign> campaigns = new List<Campaign>();
        //    #region campaigns
        //    var querycampaigns = @"Select a.ConsumerPromoID as CampaignId,e.Discount as Price,d.Qty as ProductCount
        //                            From t_PromoCP a,t_PromoCPProductFor b,t_PromoCPSalesType c,t_PromoCPSlabRatio d,
        //                            t_PromoCPOfferDetail e,t_Product f
        //                            where a.ConsumerPromoID=b.ConsumerPromoID and cast(GETDATE() as Date) between FromDate and ToDate
        //                            and a.IsActive=1 and a.Status=1 and a.ConsumerPromoID=c.ConsumerPromoID and b.ProductID=f.ProductID
        //                            and SalesType=6 and GroupTypeID=1 and ProductCode={0} and a.ConsumerPromoID=d.ConsumerPromoID
        //                            and d.ConsumerPromoID=e.ConsumerPromoID and d.SlabID=e.SlabID and e.OfferType=1";

        //    querycampaigns = string.Format(querycampaigns, sProductCode);
        //    campaigns = CasperJetContext.Database.SqlQuery<Campaign>(querycampaigns).ToList();
        //    #endregion
        //    return campaigns;
        //}
        public List<CampaignProduct> GetCampaignProducts(string campId)
        {
            List<CampaignProduct> campaigns = new List<CampaignProduct>();
            #region campaigns
            var querycampaigns = @"Select ProductCode,ProductName,Discount From
                                (
                                Select x.ConsumerPromoID,ConsumerPromoNo,FromDate,ToDate,
                                ProductID,ProductCode,ProductName,RSP as PreviousPrice,
                                isnull(case when OfferType = 2 then RSP * Discount / 100 else Discount end,0) Discount,
                                RSP-isnull(case when OfferType = 2 then RSP * Discount / 100 else Discount end,0) as DiscountedPrice
                                From
                                (
                                Select a.ConsumerPromoID,ConsumerPromoNo,FromDate,ToDate,b.ProductID,ProductCode,ProductName,RSP
                                From t_PromoCP a,t_PromoCPProductFor b,t_Product c,
                                (Select ConsumerPromoID from t_PromoCPSalesType where SalesType=6) d,
                                t_FinishedGoodsPrice e
                                where c.ProductID=e.ProductID and a.ConsumerPromoID=b.ConsumerPromoID and b.ProductID=c.ProductID and a.ConsumerPromoID=d.ConsumerPromoID
                                and CAST(GETDATE() as date) between FromDate and ToDate and a.IsActive=1 and Status=1
                                and e.IsCurrent=1
                                and a.ConsumerPromoID in
                                (
                                --Single Product--
                                Select ConsumerPromoID 
                                From TELSYSDB.DBO.t_PromoCPProductFor group by ConsumerPromoID 
                                having count(ProductID) = 1
                                --END Single Product--
                                )
                                and a.ConsumerPromoID in
                                (
                                --Single Slab--
                                Select ConsumerPromoID From TELSYSDB.DBO.t_PromoCPSlab 
                                group by ConsumerPromoID having count(SlabID) = 1
                                --END Single Slab--
                                )
                                ) x
                                left outer join
                                (
                                --Min Offer--
                                Select ConsumerPromoID,OfferType,min(Discount) as Discount
                                From t_PromoCPOfferDetail where OfferType in (1,2)
                                group by ConsumerPromoID,OfferType
                                --End Min Offer--
                                ) y on x.ConsumerPromoID=y.ConsumerPromoID
                                where Discount is not null
                                ) Main where ConsumerPromoID={0}";

            querycampaigns = string.Format(querycampaigns, campId);
            campaigns = CasperJetContext.Database.SqlQuery<CampaignProduct>(querycampaigns).ToList();
            #endregion
            return campaigns;
        }
    }
}