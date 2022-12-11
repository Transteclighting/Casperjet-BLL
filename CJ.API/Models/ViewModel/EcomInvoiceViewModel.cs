using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class InvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public List<InvoiceProducts> Products { get; set; }
        public List<InvoicePayments> Payments { get; set; }
        public List<InvoiceExchangeOffers> ExchangeOffers { get; set; }
    }
    public class Invoice
    {
        public long InvoiceID { get; set; }
        public string EComOrderId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Outlet { get; set; }
        public double Amount { get; set; }
        public double Charge { get; set; }
        public double Discount { get; set; }
        public string CopunNo { get; set; }
        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string Addrress { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
    }
    public class InvoiceProducts
    {
        public long InvoiceID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public long Quantity { get; set; }
        public int FreeQty { get; set; }
    }
    public class InvoicePayments
    {
        public long InvoiceID { get; set; }
        public string PaymentMode { get; set; }
        public double Amount { get; set; }
    }
    public class InvoiceExchangeOffers
    {
        public long InvoiceID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double ExchangeAmount { get; set; }
    }

    public class InvoiceExtraData
    {
        public string Remarks { get; set; }
        public string ProductBarcode { get; set; }
        public string SalesPerson { get; set; }
    }
}