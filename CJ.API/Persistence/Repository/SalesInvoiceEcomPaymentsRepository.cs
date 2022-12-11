using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJ.API.Persistence.Repository
{
    public class SalesInvoiceEcomPaymentsRepository : Repository<SalesInvoiceEcomPayments>, ISalesInvoiceEcomPaymentsRepository
    {
        public SalesInvoiceEcomPaymentsRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

    }
}