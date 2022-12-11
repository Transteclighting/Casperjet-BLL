using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJ.API.Persistence.Repository
{
    public class EMIRepository : Repository<Emi>, IEMIRepository
    {
        public EMIRepository(DbContext context) : base(context)
        {
        }

        public List<Emi> GetEmiList(int pageIndex, int pageSize)
        { 
            List<Emi> emis = new List<Emi>();
            #region Emi
            var query = @"Select a.BankID,a.BankName,b.Tenure as Duration,'' as OptionName,
            1 as IsExtended,a.ChargePercent as InterestRate From 
            (
            Select a.BankID,a.Name as BankName,b.EMITenureID,ChargePercent 
            From t_Bank a,t_EMIExtendedCharge b,t_EMIBankMapping c
            where a.BankID=b.BankID and b.BankID is not null and a.BankID=c.BankID and 
            b.EMITenureID=c.EMITenureID
            Union All
            Select a.BankID,a.Name as BankName,b.EMITenureID,ChargePercent  
            From t_Bank a,t_EMIExtendedCharge b,t_EMIBankMapping c
            where b.BankID is null and a.BankID not in (Select BankID from t_EMIExtendedCharge
            where BankID is not null) and a.BankID=c.BankID and b.EMITenureID=c.EMITenureID
            ) a,t_EMITenure b where a.EMITenureID=b.EMITenureID
            order by BankID";
            var pagination = Class.Utility.ConvertToPaginationQuery(query, pageIndex, pageSize);
            emis = CasperJetContext.Database.SqlQuery<Emi>(pagination).ToList();
            #endregion
            return emis;

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

        public List<Emi> GetProductEmi(string sProductCode)
        {
            List<Emi> emis = new List<Emi>();
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
            emis = CasperJetContext.Database.SqlQuery<Emi>(queryemi).ToList();
            #endregion
            return emis;
        }
    }
}