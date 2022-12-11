using System.Data.Entity;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.ViewModel;

namespace CJ.API.Persistence
{
    public class CasperJetContext : DbContext
    {
        public CasperJetContext() : base("name=CJAPIConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SmsApiCredential> SmsApiCredentials { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<PromoCp> PromoCps { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesInvoiceEcommerce> SalesInvoiceEcommerces { get; set; }
        public DbSet<SalesInvoiceEcommerceDetail> SalesInvoiceEcommerceDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SmsMessageInividualHistory> SmsMessageInividualHistories { get; set; }

        public DbSet<ConsumerDetailWebsite> ConsumerDetailWebsites { get; set; }

        public DbSet<SalesInvoiceEcom> InvoiceEcom { get; set; }
        public DbSet<SalesInvoiceEcomProducts> InvoiceEcomProducts { get; set; }
        public DbSet<SalesInvoiceEcomPayments> InvoiceEcomPayments { get; set; }
        public DbSet<SalesInvoiceEcomExchangeOffers> InvoiceEcomExchangeOffers { get; set; }


    }
}