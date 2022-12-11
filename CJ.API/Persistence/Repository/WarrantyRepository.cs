using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CJ.API.Models.ViewModel;
using CJ.Class;

namespace CJ.API.Persistence.Repository
{
    public class WarrantyRepository : Repository<Warranty>, IWarrantyRepository
    {
        public WarrantyRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
        public Warranty GetWarranty(int id)
        {
            #region Warranty from database
            var query = @"Select * From t_WarrantyParam where WarrantyParamID='{0}'";
            query = string.Format(query, id);
            var oWarranty = CasperJetContext.Database.SqlQuery<Warranty>(query).FirstOrDefault();
            #endregion
            return oWarranty;
        }
        public List<Warranty> GetWarrantyList(int pageIndex,int pageSize)
        {
            List<Warranty> oWarranties = new List<Warranty>();
            #region warranties
            var querywarranties = @"select WarrantyParamID  as WarrantyTypeID,
            'Service-'+cast(ServiceWarranty as nvarchar)+'M, Parts-'+cast(PartsWarranty as nvarchar)+'M, '
            +case when C.SpecialComponentName is null then 'Special Component' else C.SpecialComponentName end+'-'
            +cast(DurationInMonths as nvarchar)+'M' as WarrantyName,
            Price,IsDetfault,DurationInMonths  from
            (
            Select WarrantyParamID,cast('3'+cast(SpecialComponentWarranty as varchar) as int)as WarrantyTypeID,
            0 as Price,1 as IsDetfault,SpecialComponentWarranty as DurationInMonths,ProductID, PartsWarranty,ServiceWarranty
            From t_WarrantyParam where WarrantyParamID in (
            select Max(WarrantyParamID) WarrantyParamID 
            from t_WarrantyParam where EffectDate <=GETDATE() and IsCurrent=1
            Group by ProductID)
            ) A
			inner join v_ProductDetails B on A.ProductID=B.ProductID 
			left outer join t_SpecialComponent C on C.MAGID=B.MAGID  ORDER BY WarrantyTypeID ";
            var pagination = Utility.ConvertToPaginationQuery(querywarranties, pageIndex, pageSize);
            oWarranties = CasperJetContext.Database.SqlQuery<Warranty>(pagination).ToList();
            #endregion
            return oWarranties;
        }
        public List<Warranty> GetProductWarranty(string sProductCode)
        {
            try
            {
                List<Warranty> oWarranties = new List<Warranty>();
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
                from t_WarrantyParam where EffectDate <=GETDATE() and ProductID=(Select ProductID from t_Product where ProductCode={0}) and IsCurrent=1)

                ) A, v_ProductDetails B, t_SpecialComponent C 
                where A.ProductID=B.ProductID and C.MAGID=B.MAGID";
                querywarranties = string.Format(querywarranties, sProductCode);
                oWarranties = CasperJetContext.Database.SqlQuery<Warranty>(querywarranties).ToList();
                #endregion

                return oWarranties;
            }
            catch
            {
                return null;
            }


        }

        public WarrantyCardViewModel GetOrderWarranty(string sOrderERPId)
        {
            WarrantyCardViewModel oWarranties = new WarrantyCardViewModel();
            #region warranties
            var querywarranties = @"select
            wcn.WarrantyCardNo,
            rc.ConsumerName,rc.Address,rc.CellNo,
            rc.Email,si.InvoiceNo,si.InvoiceDate,
            wh.ShortCode as WarehouseCode,wh.WarehouseName,emp.EmployeeName,
            p.ProductCode,p.ProductName,b.BrandDesc, wcn.ProductSerialNo,rc.ConsumerCode+'\n'+si.InvoiceNo+'\n'+ convert(varchar, si.InvoiceDate,25)+'\n'+rc.ConsumerName+'\n'+rc.Address+'\n'+rc.CellNo+'\n'+p.ProductCode+'\n'+p.ProductName+'\n'+wcn.ProductSerialNo+'\n'+cast(wp.ServiceWarranty as varchar)+'\n'+cast(wp.PartsWarranty as varchar)+'\n'+cast(wp.SpecialComponentWarranty as varchar)+'\n'+ cast(rc.ParentCustomerID as varchar)+'\n'+'4' as QRCodeParam
            from
            (select * from t_SalesInvoice where InvoiceNo='{0}') as si
            inner join
            t_RetailConsumer as rc on si.SundryCustomerID=rc.ConsumerID and si.WarehouseID=rc.WarehouseID
            inner join
            t_SalesInvoiceWarrantyCardNo as wcn on si.InvoiceID=wcn.InvoiceID
            inner join
            t_Warehouse as wh on wh.WarehouseID=si.WarehouseID
            inner join
            t_Employee as emp on emp.EmployeeID=si.SalesPersonID
            inner join
            t_Product as p on p.ProductID=wcn.ProductID
            inner join
            t_Brand as b on b.BrandID=p.BrandID
            inner join
            t_WarrantyParam as wp on wp.ProductID=p.ProductID and wcn.WarrantyParameterID=wp.WarrantyParamID
            ";
            querywarranties = string.Format(querywarranties, sOrderERPId);
            oWarranties = CasperJetContext.Database.SqlQuery<WarrantyCardViewModel>(querywarranties).FirstOrDefault();
            #endregion
            return oWarranties;
        }
    }
}