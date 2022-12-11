using CJ.API.Models.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CJ.API.Models.Core.Domain;

namespace CJ.API.Persistence.Repository
{
    public class SalesInvoiceEcomProductsRepository : Repository<SalesInvoiceEcomProducts>, ISalesInvoiceEcomProductsRepository
    {
        public SalesInvoiceEcomProductsRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

        public List<SalesInvoiceEcomProducts> GetInvoiceProduct(int id, string number)
        {
            throw new NotImplementedException();
        }
    }
}