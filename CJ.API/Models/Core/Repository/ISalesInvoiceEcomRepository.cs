using CJ.API.Models.Core.Domain;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface ISalesInvoiceEcomRepository : IRepository<SalesInvoiceEcom>
    {
        List<Invoice> GetInvoice(string number);
        List<InvoiceProducts> GetInvoiceProduct(long id, string number);
        List<InvoicePayments> GetInvoicePayments(long id, string number);
        List<InvoiceExchangeOffers> GetInvoiceExchangeOffers(long id, string number);
        InvoiceExtraData GetInvoiceExtraData(string webOrderId);
    }
}
