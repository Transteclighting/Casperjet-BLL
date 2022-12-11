using CJ.API.Models.Core;
using CJ.API.Models.Core.Repository;
using CJ.API.Persistence.Repository;

namespace CJ.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CasperJetContext _context;
        public ISmsApiCredentialRepository SmsApiCredentials { get; private set; }
        public IProductStockRepository ProductStocks { get; private set; }

        public IPromoCpRepository PromoCPs { get; private set; }

        public IProductPriceRepository ProductPrices { get; private set; }

        public ISalesInvoiceEcommerceRepository SalesInvoiceEcommerces { get; private set; }
        public ISalesInvoiceEcommerceDetailRepository InvoiceEcommerceDetails{ get; private set; }
        public IProductRepository Products { get; private set; }
        public IUserRepository Users { get; set; }
        public ISmsMessageInividualHistoryRepository SmsMessageInividualHistories { get; set; }

        public IProductDetailViewRepository ProductDetailViews { get; set; }

        public IStoreInventoryRepository StoreInventoryViews { get; set; }

        public IAllStoreInventoryRepository AllStoreInventoryViews { get; set; }

        public IConsumerDetailWebsiteRepository ConsumerDetailWebsite { get; private set; }
        public IWarrantyRepository Warranty { get; private set; }
        public IBankRepository Bank { get; private set; }
        public ICampaignRepository Campaign { get; private set; }
        public IEMIRepository EMI { get; private set; }
        public IBrandRepository Brand { get; private set; }

        // new invoice for ecommerces
        public ISalesInvoiceEcomRepository InvoiceEcom { get; private set; }
        public ISalesInvoiceEcomProductsRepository InvoiceEcomProducts { get; private set; }
        public ISalesInvoiceEcomPaymentsRepository InvoiceEcomPayments { get; private set; }
        public ISalesInvoiceEcomExchangeOffersRepository InvoiceEcomExchangeOffers { get; private set; }
        public IDataTransferRepository DataTransfer { get; private set; }

        // Ticketing
        public ITicketRepository Ticket { get; private set; }

        public UnitOfWork(CasperJetContext context)
        {
            _context = context;
            SmsApiCredentials = new SmsApiCredentialRepository(_context);
            ProductStocks = new ProductStockRepository(_context);
            PromoCPs = new PromoCpRepository(_context);
            ProductPrices = new ProductPriceRepository(_context);
            SalesInvoiceEcommerces = new SalesInvoiceEcommerceRepository(_context);
            InvoiceEcommerceDetails = new SalesInvoiceEcommerceDetailRepository(_context);
            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);
            SmsMessageInividualHistories = new SmsMessageInividualHistoryRepository(_context);
            ProductDetailViews = new ProductDetailViewRepository(_context);
            StoreInventoryViews = new StoreInventoryRepository(_context);
            AllStoreInventoryViews = new AllStoreInventoryRepository(_context);
            ConsumerDetailWebsite = new ConsumerDetailWebsiteRepository(_context);
            Warranty = new WarrantyRepository(_context);
            Bank = new BankRepository(_context);
            Campaign = new CampaignRepository(_context);
            EMI = new EMIRepository(_context);
            Brand = new BrandRepository(_context);
            // new invoice for ecommerces
            InvoiceEcom = new SalesInvoiceEcomRepository(_context);
            InvoiceEcomProducts = new SalesInvoiceEcomProductsRepository(_context);
            InvoiceEcomPayments = new SalesInvoiceEcomPaymentsRepository(_context);
            InvoiceEcomExchangeOffers = new SalesInvoiceEcomExchangeOffersRepository(_context);
            Ticket = new TicketRepository(_context);
            DataTransfer = new DataTransferRepository(_context);
        }
        public IDatabaseTransactionRepository BeginTransaction()
        {
            return new DatabaseTransactionRepository(_context);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}