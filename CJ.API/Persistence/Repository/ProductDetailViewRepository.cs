using System;
using System.Linq;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System.Collections.Generic;

namespace CJ.API.Persistence.Repository
{
    public interface IProductDetailViewRepository : IRepository<ProductView>
    {
        ProductView GetSkuDetail(string sProductCode);
        ProductView GetProductEmi(string sProductCode);

        List<ProductView> GetProductList(DateTime? dFromDate, DateTime? dToDate, int pageIndex, int pageSize);
        List<ProductViewModel> GetProductListNew(DateTime? dFromDate, DateTime? dToDate, int pageIndex, int pageSize);

    }
    public class ProductDetailViewRepository : Repository<ProductView>, IProductDetailViewRepository
    {
        //New
        public List<ProductViewModel> GetSkuDetailList(List<int> idList)
        {
            var productIdList = string.Join(",", idList);
            List<ProductViewModel> oProductListView = new List<ProductViewModel>();

            #region ProductBasic
            var query = @"Select ProductCode as Id,ProductName as Sku, a.ProductID,
            CAST(isnull(RSP,0) AS float) as Price,CAST(0 AS float) as PreviousPrice,
            CAST(isnull(b.DisAmount,0) AS float) as Discount 
            From v_ProductDetails a
            left outer join 
            (
            Select ProductID,min(DisAmount) DisAmount
            From
            (
            Select A.ConsumerPromoID, A.SlabID, ProductCode,ProductName, RSP, c.ProductID,
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
            group by ProductID
            ) b on  a.ProductID=b.ProductID
            where a.ProductID in  ({0})
            ";
            query = string.Format(query, productIdList);
            var product = CasperJetContext.Database.SqlQuery<ProductBasicViewModel>(query).ToList();
            //oProductView = product;
            #endregion

            #region Inventory
            var queryinventory = @"Select a.WarehouseID as StoreID,sum(CurrentStock)-sum(DefDisplayStock) as ProductCount, ProductID 
            From 
            (
            Select WarehouseID,ProductID,CurrentStock,0 as DefDisplayStock 
            From t_ProductStock 
            Union All
            Select a.WarehouseID,a.ProductID,0 as CurrentStock,count(a.ProductSerialNo) as DefDisplayStock 
            From 
            (
            Select distinct a.ProductID,a.WarehouseID,a.ProductSerialNo  From 
            (
            Select ProductID,WarehouseID,BarcodeSL as ProductSerialNo 
            From t_UnsoldDefectiveProduct where Status in (1,2,3,4)
            Union All
            Select ProductID,WHID,ProductSerialNo From t_OutletDisplayPosition
            where Status=1 and ProductSerialNo is not null and ProductSerialNo<>''
            ) a 
            ) a
            left outer join t_ProductStockSerialOutlet b 
            on a.ProductID=b.ProductID and a.WarehouseID=b.WarehouseID
            and a.ProductSerialNo=b.ProductSerialNo
            where b.ProductSerialNo is not null
            group by a.WarehouseID,a.ProductID
            ) a,t_Showroom b where a.WarehouseID=b.WarehouseID and IsPosActive=1 and ProductID in ({0})
            group by a.WarehouseID,ProductID";
            queryinventory = string.Format(queryinventory, productIdList);
            var inventory = CasperJetContext.Database.SqlQuery<InventoryViewModel>(queryinventory).ToList();
            //oProductView.Inventory = inventory;
            #endregion

            #region warranties
            var querywarranties = @"select WarrantyParamID as WarrantyTypeID,
            'Service-'+cast(ServiceWarranty as nvarchar)+'M, Parts-'+cast(PartsWarranty as nvarchar)+'M'
            + (case when DurationInMonths>0 then ', '+ case when C.SpecialComponentName is null then 'Special Component' else C.SpecialComponentName end+'-'
            + cast(DurationInMonths as nvarchar)+'M' else '' end) as WarrantyName,
            Price,IsDetfault,DurationInMonths,a.ProductID
            from
            (
            Select WarrantyParamID,cast('3'+cast(SpecialComponentWarranty as varchar) as int)as WarrantyTypeID,
            0 as Price,1 as IsDetfault,SpecialComponentWarranty as DurationInMonths,ProductID, PartsWarranty,ServiceWarranty
            From t_WarrantyParam where WarrantyParamID in (
            select Max(WarrantyParamID) WarrantyParamID
            from t_WarrantyParam where EffectDate <=GETDATE() and IsCurrent=1
            group by ProductID)
            and ProductID in ({0})
            ) A, v_ProductDetails B
            left outer join t_SpecialComponent C on C.MAGID=B.MAGID
            where A.ProductID=B.ProductID";
            querywarranties = string.Format(querywarranties, productIdList);
            var warranties = CasperJetContext.Database.SqlQuery<WarrantyViewModel>(querywarranties).ToList();
            //oProductView.Warranties = warranties;
            #endregion

            #region Emi
            var queryemi = @"Select 0 as BankID,'' as BankName, '' as OptionName, CAST(max(0) as float) as InterestRate,ProductID,max(b.Tenure) Duration From 
            (
            Select ProductID,EMITenureID From t_PromoDiscountASGBrandEMI a,v_ProductDetails b
            where a.IsActive=1 and Status=2 and EffectiveDate <=GETDATE() and a.AGID=b.AGID and a.BrandID=b.BrandID
            Union All
            Select ProductID,EMITenureID From t_PromoCPOfferDetail a,t_PromoCPSlabRatio b,t_PromoCP c,t_PromoCPSalesType d
            where OfferType=3 and a.ConsumerPromoID=b.ConsumerPromoID and a.SlabID=b.SlabID and a.ConsumerPromoID=d.ConsumerPromoID
            and b.Qty=1 and a.ConsumerPromoID=c.ConsumerPromoID and cast(GETDATE() as Date) between FromDate and ToDate
            and c.IsActive=1 and c.Status=1
            and SalesType=6 
            ) a,t_EMITenure b where a.EMITenureID=b.EMITenureID
            group by ProductID
            ";
            queryemi = string.Format(queryemi, productIdList);
            var emiList = CasperJetContext.Database.SqlQuery<EmiNewViewModel>(queryemi).ToList();
            //oProductView.Emi = emi;
            #endregion

            #region campaigns
            var querycampaigns = @"Select a.ConsumerPromoID as CampaignId,e.Discount as Price,d.Qty as ProductCount, ProductCode
                                    From t_PromoCP a,t_PromoCPProductFor b,t_PromoCPSalesType c,t_PromoCPSlabRatio d,
                                    t_PromoCPOfferDetail e,t_Product f
                                    where a.ConsumerPromoID=b.ConsumerPromoID and cast(GETDATE() as Date) between FromDate and ToDate
                                    and a.IsActive=1 and a.Status=1 and a.ConsumerPromoID=c.ConsumerPromoID and b.ProductID=f.ProductID
                                    and SalesType=6 and GroupTypeID=1 and b.ProductID  in ({0}) and a.ConsumerPromoID=d.ConsumerPromoID
                                    and d.ConsumerPromoID=e.ConsumerPromoID and d.SlabID=e.SlabID and e.OfferType=1";
            querycampaigns = string.Format(querycampaigns, productIdList);
            var campaigns = CasperJetContext.Database.SqlQuery<CampaignViewModel>(querycampaigns).ToList();
            //oProductView.Campaigns = campaigns;
            #endregion

            foreach (var id in idList)
            {
                ProductViewModel oProductView = new ProductViewModel();
                var ProductBasicList = product.Where(c=>c.ProductID== Convert.ToInt32(id)).FirstOrDefault();
                oProductView.Id = ProductBasicList.Id;
                oProductView.Sku = ProductBasicList.Sku;
                if (ProductBasicList.Price == ProductBasicList.PreviousPrice)
                {
                    oProductView.PreviousPrice = 0;
                }
                else
                {
                    oProductView.PreviousPrice = ProductBasicList.PreviousPrice;
                }
                oProductView.Price = ProductBasicList.Price;
                oProductView.Discount = ProductBasicList.Discount;
                oProductView.Inventory = inventory.Where(c => c.ProductID == Convert.ToInt32(id)).ToList();
                oProductView.Warranties = warranties.Where(c => c.ProductID == Convert.ToInt32(id)).ToList();
                oProductView.Emi = emiList.Where(c => c.ProductID == Convert.ToInt32(id)).ToList();
                oProductView.Campaigns = campaigns.Where(c => c.ProductID == Convert.ToInt32(id)).ToList();
                oProductListView.Add(oProductView);
            }
            return oProductListView;
        }
        public List<ProductViewModel> GetProductListNew(DateTime? dFromDate, DateTime? dToDate, int pageIndex, int pageSize)
        {
            List<ProductViewModel> oProductViewList = new List<ProductViewModel>();
            var query = @"Select ProductId From v_ProductDetails where IsActive=1 and IsEcomSync=1  and RSP IS NOT NULL ORDER BY ProductId";
            if (dFromDate != null && dToDate != null)
            {
                query = @"Select ProductId From v_ProductDetails where IsActive=1 and IsEcomSync=1  and RSP IS NOT NULL and date between '{0}' and '{1}' and date<'{1} ORDER BY ProductId";
                query = string.Format(query, dFromDate, dToDate);
            }
            var pagination = @"DECLARE @PageNumber AS INT DECLARE @RowsOfPage AS INT SET @PageNumber={0} SET @RowsOfPage={1} " + query + " OFFSET (@PageNumber-1)*@RowsOfPage ROWS FETCH NEXT @RowsOfPage ROWS ONLY";
            pagination = string.Format(pagination, pageIndex, pageSize);
            var idList = CasperJetContext.Database.SqlQuery<int>(pagination).DefaultIfEmpty().ToList();
            if (idList != null)
            {
                oProductViewList = GetSkuDetailList(idList);
            }
            return oProductViewList;
        }

        // old
        public ProductView GetSkuDetail(string sProductCode)
        {
            try
            {
                ProductView oProductView = new ProductView();
                #region ProductBasic
                var query = @"Select ProductCode as Id,ProductName as Sku,
                CAST(isnull(RSP-isnull(b.DisAmount,0),0) AS float) as Price,
                CAST(isnull(RSP,0) AS float) as PreviousPrice 
                From v_ProductDetails a
                left outer join 
                (
                Select ProductID,sum(DisAmount) DisAmount From 
                (
                Select ProductID,TPID,Amount as DisAmount From t_PromoTPECom 
                where IsActive=1 and cast(GETDATE() as date) between fromdate and todate
                Union All
                Select ProductID,ConsumerPromoID,min(DisAmount) DisAmount
                From
                (
                Select A.ConsumerPromoID, A.SlabID, ProductCode,ProductName, RSP, c.ProductID,
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
                group by ProductID,ConsumerPromoID
                ) x group by ProductID
                ) b on  a.ProductID=b.ProductID
                where ProductCode='{0}'
                ";
                query = string.Format(query, sProductCode);
                var stock = CasperJetContext.Database.SqlQuery<ProductBasic>(query).FirstOrDefault();

                oProductView.Id = stock.Id;
                oProductView.Sku = stock.Sku;
                if (stock.Price == stock.PreviousPrice)
                {
                    oProductView.PreviousPrice = 0;
                }
                else
                {
                    oProductView.PreviousPrice = stock.PreviousPrice;
                }
                oProductView.Price = stock.Price;


                #endregion

                #region Inventory
                var queryinventory = @"Select a.WarehouseID as StoreID,sum(CurrentStock)-sum(DefDisplayStock) as ProductCount 
                From 
                (
                Select WarehouseID,ProductID,CurrentStock,0 as DefDisplayStock 
                From t_ProductStock 
                Union All
                Select a.WarehouseID,a.ProductID,0 as CurrentStock,count(a.ProductSerialNo) as DefDisplayStock 
                From 
                (
                Select distinct a.ProductID,a.WarehouseID,a.ProductSerialNo  From 
                (
                Select ProductID,WarehouseID,BarcodeSL as ProductSerialNo 
                From t_UnsoldDefectiveProduct where Status in (1,2,3,4)
                Union All
                Select ProductID,WHID,ProductSerialNo From t_OutletDisplayPosition
                where Status=1 and ProductSerialNo is not null and ProductSerialNo<>''
                ) a 
                ) a
                left outer join t_ProductStockSerialOutlet b 
                on a.ProductID=b.ProductID and a.WarehouseID=b.WarehouseID
                and a.ProductSerialNo=b.ProductSerialNo
                where b.ProductSerialNo is not null
                group by a.WarehouseID,a.ProductID
                ) a,t_Showroom b where a.WarehouseID=b.WarehouseID and IsPosActive=1 and ProductID=(Select ProductID from t_Product where ProductCode='{0}')
                group by a.WarehouseID";
                queryinventory = string.Format(queryinventory, sProductCode);
                var inventory = CasperJetContext.Database.SqlQuery<Inventory>(queryinventory).ToList();
                oProductView.Inventory = inventory;
                #endregion

                #region warranties
                var querywarranties = @"select WarrantyParamID as WarrantyTypeID,
                'Service-'+cast(ServiceWarranty as nvarchar)+'M, Parts-'+cast(PartsWarranty as nvarchar)+'M, '
                +case when C.SpecialComponentName is null then 'Special Component' else C.SpecialComponentName end+'-'
                +cast(DurationInMonths as nvarchar)+'M' as WarrantyName,
                Price,IsDetfault,DurationInMonths  from
                (
                Select WarrantyParamID,cast('3'+cast(SpecialComponentWarranty as varchar) as int)as WarrantyTypeID,
                0 as Price,1 as IsDetfault,SpecialComponentWarranty as DurationInMonths,ProductID, PartsWarranty,ServiceWarranty
                From t_WarrantyParam where WarrantyParamID=(
                select Max(WarrantyParamID) WarrantyParamID
                from t_WarrantyParam where
                EffectDate <=GETDATE() and 
                ProductID=(Select ProductID from t_Product where ProductCode={0})
                and IsCurrent=1)
                ) A
                inner join v_ProductDetails B on A.ProductID=B.ProductID 
                left outer join t_SpecialComponent C on C.MAGID=B.MAGID";
                querywarranties = string.Format(querywarranties, sProductCode);
                var warranties = CasperJetContext.Database.SqlQuery<Warranty>(querywarranties).ToList();

                oProductView.Warranties = warranties;
                #endregion

                #region Emi
                var queryemi = @"Select BankID,BankName,Tenure as Duration,'' as OptionName,
                            case when FreeTenure is null then 1 else 0 end as IsExtended,isnull(InterestRate,0) InterestRate From 
                            (
                            Select a.BankID,a.Name as BankName,b.EMITenureID,d.Tenure,c.Tenure as FreeTenure,ChargePercent as InterestRate
                            From t_Bank a
                            inner join t_EMIBankMapping b on a.BankID=b.BankID
                            left outer join 
                            (
                            Select distinct b.EMITenureID,b.Tenure From 
                            (
                            Select ProductID,EMITenureID From t_PromoDiscountASGBrandEMI a,v_ProductDetails b
                            where a.IsActive=1 and Status=2 and EffectiveDate <=GETDATE() and a.AGID=b.AGID and a.BrandID=b.BrandID
                            Union All
                            Select ProductID,EMITenureID From t_PromoCPOfferDetail a,t_PromoCPSlabRatio b,t_PromoCP c,t_PromoCPSalesType d
                            where OfferType=3 and a.ConsumerPromoID=b.ConsumerPromoID and a.SlabID=b.SlabID and a.ConsumerPromoID=d.ConsumerPromoID
                            and b.Qty=1 and a.ConsumerPromoID=c.ConsumerPromoID and cast(GETDATE() as Date) between FromDate and ToDate
                            and c.IsActive=1 and c.Status=1
                            and SalesType=6 
                            ) a,t_EMITenure b,t_Product c where a.ProductID=c.ProductID and 
                            c.ProductCode={0} and b.EMITenureID<=a.EMITenureID
                            ) c on b.EMITenureID=c.EMITenureID
                            inner join t_EMITenure d on b.EMITenureID=d.EMITenureID
                            left outer join t_EMIExtendedCharge e on b.EMITenureID=e.EMITenureID
                            where IsEMI=1 and e.BankID is null
                            ) Main order By BankID,Tenure";
                queryemi = string.Format(queryemi, sProductCode);
                var emiView = CasperJetContext.Database.SqlQuery<Emi>(queryemi).ToList();
                List<Emi> emiList = new List<Emi>();
                var emiBanksGroup = emiView.GroupBy(c => c.BankID);
                foreach (var bankWiseEmiItems in emiBanksGroup)
                {
                    var freeEmi = bankWiseEmiItems.Where(c => c.IsExtended == 0).OrderByDescending(x => x.Duration).FirstOrDefault();
                    foreach (var item in bankWiseEmiItems)
                    {
                        Emi finalEmi = new Emi();
                        finalEmi.BankName = item.BankName;
                        finalEmi.IsExtended = item.IsExtended;
                        finalEmi.OptionName = item.OptionName;
                        finalEmi.BankID = item.BankID;
                        finalEmi.Duration = item.Duration;
                        if (item.IsExtended == 1)
                        {
                            if (freeEmi != null)
                            {
                                finalEmi.InterestRate = item.InterestRate - freeEmi.InterestRate;
                            }
                            else
                            {
                                finalEmi.InterestRate = item.InterestRate;
                            }

                        }
                        else
                        {
                            finalEmi.InterestRate = 0;
                        }
                        emiList.Add(finalEmi);
                        finalEmi = null;
                    }
                    freeEmi = null;
                }
                oProductView.Emi = emiList;
                #endregion

                #region campaigns
                var querycampaigns = @"Select a.ConsumerPromoID as CampaignId,e.Discount as Price,d.Qty as ProductCount
                                    From t_PromoCP a,t_PromoCPProductFor b,t_PromoCPSalesType c,t_PromoCPSlabRatio d,
                                    t_PromoCPOfferDetail e,t_Product f
                                    where a.ConsumerPromoID=b.ConsumerPromoID and cast(GETDATE() as Date) between FromDate and ToDate
                                    and a.IsActive=1 and a.Status=1 and a.ConsumerPromoID=c.ConsumerPromoID and b.ProductID=f.ProductID
                                    and SalesType=6 and GroupTypeID=1 and ProductCode={0} and a.ConsumerPromoID=d.ConsumerPromoID
                                    and d.ConsumerPromoID=e.ConsumerPromoID and d.SlabID=e.SlabID and e.OfferType=1";

                querycampaigns = string.Format(querycampaigns, sProductCode);
                var campaigns = CasperJetContext.Database.SqlQuery<Campaign>(querycampaigns).ToList();
                oProductView.Campaigns = campaigns;
                #endregion

                return oProductView;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProductView> GetProductList(DateTime? dFromDate, DateTime? dToDate, int pageIndex, int pageSize)
        {
            List<ProductView> oProductViewList = new List<ProductView>();
            var query = @"Select ProductCode as Id,ProductName as Sku,CAST(isnull(RSP,0) AS float) as Price, CAST(0 AS float) as PreviousPrice From v_ProductDetails where IsActive=1 and IsEcomSync=1 and RSP IS NOT NULL ORDER BY Id";
            if (dFromDate != null && dToDate != null)
            {
                query = @"Select ProductCode as Id,ProductName as Sku,CAST(isnull(RSP,0) AS float) as Price, CAST(0 AS float) as PreviousPrice From v_ProductDetails where IsActive=1 and IsEcomSync=1 and RSP IS NOT NULL and date between '{0}' and '{1}' and date<'{1} ORDER BY Id";
                query = string.Format(query, dFromDate, dToDate);
            }
            var pagination = @"DECLARE @PageNumber AS INT DECLARE @RowsOfPage AS INT SET @PageNumber={0} SET @RowsOfPage={1} " + query + " OFFSET (@PageNumber-1)*@RowsOfPage ROWS FETCH NEXT @RowsOfPage ROWS ONLY";
            pagination = string.Format(pagination, pageIndex, pageSize);
            var stocks = CasperJetContext.Database.SqlQuery<ProductView>(pagination).DefaultIfEmpty().ToList();
            foreach (var stock in stocks)
            {
                if (stock != null)
                {
                    string sProductCode = stock.Id;
                    ProductView oProuctview = GetSkuDetail(sProductCode);
                    oProductViewList.Add(oProuctview);
                }
            }
            return oProductViewList;
        }
        public ProductDetailViewRepository(CasperJetContext context): base(context)
        {

        }
        public ProductView GetProductEmi(string sProductCode)
        {
            try
            {
                ProductView oProductView = new ProductView();
                #region Emi
                var queryemi = @"Select BankID,BankName,Tenure as Duration,'' as OptionName,
                            case when FreeTenure is null then 1 else 0 end as IsExtended,isnull(InterestRate,0) InterestRate From 
                            (
                            Select a.BankID,a.Name as BankName,b.EMITenureID,d.Tenure,c.Tenure as FreeTenure,ChargePercent as InterestRate
                            From t_Bank a
                            inner join t_EMIBankMapping b on a.BankID=b.BankID
                            left outer join 
                            (
                            Select distinct b.EMITenureID,b.Tenure From 
                            (
                            Select ProductID,EMITenureID From t_PromoDiscountASGBrandEMI a,v_ProductDetails b
                            where a.IsActive=1 and Status=2 and EffectiveDate <=GETDATE() and a.AGID=b.AGID and a.BrandID=b.BrandID
                            Union All
                            Select ProductID,EMITenureID From t_PromoCPOfferDetail a,t_PromoCPSlabRatio b,t_PromoCP c,t_PromoCPSalesType d
                            where OfferType=3 and a.ConsumerPromoID=b.ConsumerPromoID and a.SlabID=b.SlabID and a.ConsumerPromoID=d.ConsumerPromoID
                            and b.Qty=1 and a.ConsumerPromoID=c.ConsumerPromoID and cast(GETDATE() as Date) between FromDate and ToDate
                            and c.IsActive=1 and c.Status=1
                            and SalesType=6 
                            ) a,t_EMITenure b,t_Product c where a.ProductID=c.ProductID and 
                            c.ProductCode={0} and b.EMITenureID<=a.EMITenureID
                            ) c on b.EMITenureID=c.EMITenureID
                            inner join t_EMITenure d on b.EMITenureID=d.EMITenureID
                            left outer join t_EMIExtendedCharge e on b.EMITenureID=e.EMITenureID
                            where IsEMI=1 and e.BankID is null
                            ) Main order By BankID,Tenure";
                queryemi = string.Format(queryemi, sProductCode);
                var emi = CasperJetContext.Database.SqlQuery<Emi>(queryemi).ToList();
                oProductView.Emi = emi;
                #endregion
                return oProductView;
            }
            catch
            {
                return null;
            }


        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}