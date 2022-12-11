using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJ.API.Persistence.Repository
{
    public class SalesInvoiceEcomExchangeOffersRepository : Repository<SalesInvoiceEcomExchangeOffers>, ISalesInvoiceEcomExchangeOffersRepository
    {
        public SalesInvoiceEcomExchangeOffersRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

    }
}