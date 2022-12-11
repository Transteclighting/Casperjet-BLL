using System.Collections.Generic;
using CJ.API.Models.Core.Domain;

namespace CJ.API.Models.ViewModel
{
    public class EommerceInvoiceCreateViewModel
    {
        public SalesInvoiceEcommerce SalesInvoiceEcommerce { get; set; }
        public List<SalesInvoiceEcommerceDetail> SalesInvoiceEcommerceDetails { get; set; }

    }
}