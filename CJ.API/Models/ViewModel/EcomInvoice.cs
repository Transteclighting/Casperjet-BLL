using CJ.API.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class EcomInvoice
    {
        public SalesInvoiceEcom SalesInvoiceEcom { get; set; }
        public List<SalesInvoiceEcomProducts> Products { get; set; }
        public List<SalesInvoiceEcomPayments> Payments { get; set; }
        public List<SalesInvoiceEcomExchangeOffers> ExchangeOffers { get; set; }
    }
}