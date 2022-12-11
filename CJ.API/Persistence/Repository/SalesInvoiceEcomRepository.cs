using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CJ.API.Models.ViewModel;

namespace CJ.API.Persistence.Repository
{
    public class SalesInvoiceEcomRepository : Repository<SalesInvoiceEcom>, ISalesInvoiceEcomRepository
    {
        public SalesInvoiceEcomRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
        public List<Invoice> GetInvoice(string number)
        {
            List<Invoice> queryInvoice = new List<Invoice>();
            #region Invoice
            //---SalesInvoiceEcom--
            var query = @"Select CAST(case when b.Company='TEL' then c.InvoiceID else d.InvoiceID end AS bigint) as InvoiceID,
            isnull(case when b.Company='TEL' then e.OrderNo else f.OrderNo end,'') as EcomOrderNo,
            TranNo as InvoiceNo,TranDate as InvoiceDate,
            b.WHCode as Outlet,Round(b.Amount, 0) as Amount,
            Round(isnull(case when b.Company='TEL' then c.OtherCharge else d.OtherCharge end,0), 0) as Charge,
            Round(isnull(case when b.Company='TEL' then c.Discount else d.Discount end,0), 0) as Discount,
            a.ConsumerID, a.ConsumerName,a.Address,
            isnull(case when b.Company='TEL' then c.DeliveryAddress else d.DeliveryAddress end,b.Address) as DeliveryAddress,
            a.MobileNo as ContactNo, a.Email,
            isnull(case when b.Company='TEL' then c.Remarks else d.Remarks end,'') as Remarks
            From TELSysDB.dbo.t_ConsumerDetail a
            inner join TELSysDB.dbo.t_ConsumerDetailTran b on a.ConsumerID=b.ConsumerID
            Left outer join (Select *,'TEL' as Company From TELSysdb.dbo.t_SalesInvoice) c on b.TranNo=c.InvoiceNo and b.Company=c.Company
            Left outer join (Select *,'TML' as Company From TMLSysdb.dbo.t_SalesInvoice) d on b.TranNo=d.InvoiceNo and b.Company=d.Company
            Left Outer join (Select *,'TEL' as Company From TELSysdb.dbo.t_SalesInvoiceEcommerce) e on b.TranNo=e.RefInvoiceNo and b.Company=e.Company
            Left Outer join (Select *,'TML' as Company From TMLSysDB.dbo.t_SalesInvoiceEcommerce) f on b.TranNo=f.RefInvoiceNo and b.Company=f.Company
            where TranType='Sales' and a.MobileNo='{0}'";
            query = string.Format(query, number);
            //---END SalesInvoiceEcom--
            queryInvoice = CasperJetContext.Database.SqlQuery<Invoice>(query).ToList();
            #endregion
            return queryInvoice;
        }
        public List<InvoiceProducts> GetInvoiceProduct(long id, string number)
        {
            List<InvoiceProducts> queryInvoice = new List<InvoiceProducts>();
            #region InvoiceProducts
            //---Products--
            var query = @"Select  CAST(c.InvoiceID AS bigint) as InvoiceID,b.ProductCode,b.ProductName, UnitPrice,
            c.Discount,  CAST(c.Quantity AS bigint) as Quantity, c.FreeQty
            From TELSysDB.dbo.t_ConsumerDetail a
            inner join TELSysDB.dbo.t_ConsumerDetailTran b on a.ConsumerID=b.ConsumerID
            Left outer join
            (
            Select 'TEL' as Company,a.InvoiceID,InvoiceNo,
            ProductCode,ProductName, b.UnitPrice, isnull(d.Discounts,a.Discount) Discount,
            b.Quantity, b.FreeQty From TELSysDB.dbo.t_SalesInvoice a
            inner join TELSysDB.dbo.t_SalesInvoiceDetail b on a.InvoiceID=b.InvoiceID
            inner join TELSysDB.dbo.t_Product c on b.ProductID=c.ProductID
            left outer join TELSysDB.dbo.t_SalesInvoiceDetailNew d on b.InvoiceID=d.InvoiceID and b.ProductID=d.ProductID
            Union All
            Select 'TML' as Company,a.InvoiceID,InvoiceNo,
            ProductCode,ProductName, b.UnitPrice, a.Discount Discount,
            b.Quantity, b.FreeQty From TMLSysDB.dbo.t_SalesInvoice a
            inner join TMLSysDB.dbo.t_SalesInvoiceDetail b on a.InvoiceID=b.InvoiceID
            inner join TMLSysDB.dbo.t_Product c on b.ProductID=c.ProductID
            ) c  on b.TranNo=c.InvoiceNo and b.Company=c.Company and b.ProductCode=c.ProductCode
            where TranType='Sales' and a.MobileNo='{0}' and InvoiceID={1}
            ";
            query = string.Format(query, number, id);
            //---END Products--
            queryInvoice = CasperJetContext.Database.SqlQuery<InvoiceProducts>(query).ToList();
            #endregion
            return queryInvoice;
        }
        public List<InvoicePayments> GetInvoicePayments(long id, string number)
        {
            List<InvoicePayments> queryInvoice = new List<InvoicePayments>();
            #region InvoicePayments
            //---Payments--
            var query = @"select InvoiceID,PaymentMode,Amount from (
            select CAST(InvoiceID AS bigint) as InvoiceID,PaymentMode,sum(Amount) as Amount  from(
            Select case when b.Company='TEL' then c.InvoiceID else d.InvoiceID end as InvoiceID,
            isnull(case when b.Company='TEL' then c.PaymentModeName else d.PaymentModeName end,'Cash') as PaymentMode,
            isnull(case when b.Company='TEL' then c.Amount else d.Amount end,b.Amount) as Amount
            From TELSysDB.dbo.t_ConsumerDetail a
            inner join TELSysDB.dbo.t_ConsumerDetailTran b on a.ConsumerID=b.ConsumerID
            Left outer join
            (
            Select InvoiceNo,a.InvoiceID,PaymentModeName,Amount,'TEL' as Company
            From TELSysDB.dbo.t_SalesInvoice a
            left outer join TELSysDB.dbo.t_SalesInvoicePaymentMode b on a.InvoiceID=b.InvoiceID
            left outer join TELSysDB.dbo.t_PaymentMode c on b.PaymentModeID=c.PaymentModeID
            ) c
            on b.TranNo=c.InvoiceNo and b.Company=c.Company
            Left outer join
            (
            Select InvoiceNo,a.InvoiceID,PaymentModeName,Amount,'TML' as Company
            From TMLSysDB.dbo.t_SalesInvoice a
            left outer join TMLSysDB.dbo.t_SalesInvoicePaymentMode b on a.InvoiceID=b.InvoiceID
            left outer join TMLSysDB.dbo.t_PaymentMode c on b.PaymentModeID=c.PaymentModeID
            ) d
            on b.TranNo=d.InvoiceNo and b.Company=d.Company
            where TranType='Sales' and a.MobileNo='{0}') x group by InvoiceID, PaymentMode
            ) y where InvoiceID={1}";
            query = string.Format(query, number, id);
            //---END Payments--
            queryInvoice = CasperJetContext.Database.SqlQuery<InvoicePayments>(query).ToList();
            #endregion
            return queryInvoice;
        }
        public List<InvoiceExchangeOffers> GetInvoiceExchangeOffers(long id, string number)
        {
            List<InvoiceExchangeOffers> queryInvoice = new List<InvoiceExchangeOffers>();
            #region InvoiceExchangeOffers
            //---ExchangeOffers--
            var query = @"
            Select CAST(InvoiceID AS bigint) as InvoiceID, b.ProductName, b.ProductCode,isnull( ExchangeAmount,0) ExchangeAmount
            From TELSysDB.dbo.t_ConsumerDetail a
            inner join TELSysDB.dbo.t_ConsumerDetailTran b on a.ConsumerID=b.ConsumerID
            Left outer join
            (
            Select a.InvoiceID,InvoiceNo,Company,ProductCode,ProductName,
            sum(Amount) as ExchangeAmount From
            (
            Select InvoiceID,ProductID,Amount,'TEL' as Company From TELSysdb.dbo.t_SalesInvoicePaymentModeNew where  PaymentModeID=11
            Union All
            Select InvoiceID,ProductID,Amount,'TEL' as Company From TELSysdb.dbo.t_SalesInvoiceDiscount where  DiscountTypeID=12
            ) a,TELSysDB.dbo.t_Product b,TELSysDB.dbo.t_SalesInvoice c where a.ProductID=b.ProductID and a.InvoiceID=c.InvoiceID
            group by a.InvoiceID,InvoiceNo,Company,ProductCode,ProductName
            ) c
            on b.TranNo=c.InvoiceNo and b.Company=c.Company and b.ProductCode=c.ProductCode
            where TranType='Sales' and a.MobileNo='{0}' and isnull( ExchangeAmount,0)>0 and InvoiceID={1}
            ";
            query = string.Format(query, number, id);
            //---END ExchangeOffers--
            queryInvoice = CasperJetContext.Database.SqlQuery<InvoiceExchangeOffers>(query).ToList();
            #endregion
            return queryInvoice;
        }
        public InvoiceExtraData GetInvoiceExtraData(string webOrderId)
        {
            #region Invoice
            //---SalesInvoiceEcom Extra data--
            var query = @"Select Remarks,ProductSerialNo as ProductBarcode,EmployeeName as SalesPerson
                        From t_SalesInvoice a,t_SalesInvoiceProductSerial b,t_Employee c
                        where a.InvoiceID=b.InvoiceID and a.SalesPersonID=c.EmployeeID
                        and InvoiceNo=(Select top 1 RefInvoiceNo from t_SalesInvoiceEcom
                        where EComOrderID='{0}')";
            query = string.Format(query, webOrderId);
            //---END SalesInvoiceEcom Extra data--
            List<InvoiceExtraData> queryInvoice = CasperJetContext.Database.SqlQuery<InvoiceExtraData>(query).ToList();
            InvoiceExtraData item = new InvoiceExtraData();
            List<string> val = new List<string>();
            foreach (var invoiceItem in queryInvoice)
            {
                val.Add(invoiceItem.ProductBarcode);
            }
            item.ProductBarcode = string.Join(",", val.ToArray());
            item.Remarks = queryInvoice[0].Remarks;
            item.SalesPerson = queryInvoice[0].SalesPerson;
            #endregion
            return item;
        }

    }
}