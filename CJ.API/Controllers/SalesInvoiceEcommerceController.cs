using System;
using CJ.API.Persistence;
using System.Web.Http;
using CJ.API.Models.Utility;
using CJ.API.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using CJ.API.Models.Core.Domain;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.API.Controllers
{
    [ThirdPartyAuthorization]
    [RoutePrefix("api/v1/ecommerce-sales-invoice")]
    public class SalesInvoiceEcommerceController : ApiController
    {
        [HttpPost]
        [Route("add-invoice")]
        //[RequestCache(Name = "SalesInvoiceEcommerceAdd",Seconds = 60)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Add([FromBody] EommerceInvoiceCreateViewModel oSalesInvoiceEcommerce)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    unitOfWork.SalesInvoiceEcommerces.Add(oSalesInvoiceEcommerce.SalesInvoiceEcommerce);
                    unitOfWork.Save();

                    oSalesInvoiceEcommerce.SalesInvoiceEcommerceDetails.ForEach(a =>
                    {
                        a.EcomOrderId = oSalesInvoiceEcommerce.SalesInvoiceEcommerce.EComOrderId;
                    });
                    unitOfWork.InvoiceEcommerceDetails.AddRange(oSalesInvoiceEcommerce.SalesInvoiceEcommerceDetails);
                    unitOfWork.Save();

                    transaction.Commit();
                    return Ok("Successfully saved");
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] EcomInvoice oEcomInvoice)
        {
            if (!ModelState.IsValid)
            {
                var errors = new Hashtable();
                foreach (var pair in ModelState)
                {
                    if (pair.Value.Errors.Count > 0)
                    {
                        errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                    }
                }
                var json = new JavaScriptSerializer().Serialize(errors);
                return BadRequest(json);

                //.return Json(ModelState);
            }
               // return BadRequest("Invalid data.");

            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    if (oEcomInvoice!=null && oEcomInvoice.SalesInvoiceEcom != null && oEcomInvoice.SalesInvoiceEcom.ContactNo != null)
                    {
                        oEcomInvoice.SalesInvoiceEcom.ContactNo=oEcomInvoice.SalesInvoiceEcom.ContactNo.Replace("+88", "");
                    }
                    unitOfWork.InvoiceEcom.Add(oEcomInvoice.SalesInvoiceEcom);
                    unitOfWork.Save();


                    //products
                    unitOfWork.InvoiceEcomProducts.AddRange(oEcomInvoice.Products);
                    unitOfWork.Save();
                    //Payments
                    unitOfWork.InvoiceEcomPayments.AddRange(oEcomInvoice.Payments);
                    unitOfWork.Save();
                    //ExchangeOffers
                    unitOfWork.InvoiceEcomExchangeOffers.AddRange(oEcomInvoice.ExchangeOffers);
                    unitOfWork.Save();
                   
                    //create data in old table 
                    var maxId =unitOfWork.SalesInvoiceEcommerces.GetAll().OrderByDescending(u => u.Id).Select(u => u.Id).FirstOrDefault() + 1000001;
                    var oSalesInvoiceEcommerce = ConvertNewInvoiceToOldInvoice(oEcomInvoice, maxId);
                    unitOfWork.SalesInvoiceEcommerces.Add(oSalesInvoiceEcommerce.SalesInvoiceEcommerce);
                    unitOfWork.Save();
                    unitOfWork.InvoiceEcommerceDetails.AddRange(oSalesInvoiceEcommerce.SalesInvoiceEcommerceDetails);
                    unitOfWork.Save();
                    var whID = unitOfWork.StoreInventoryViews.GetStoreId(oSalesInvoiceEcommerce.SalesInvoiceEcommerce.Outlet);
                    unitOfWork.DataTransfer.CreateDataTransfer("t_SalesInvoiceEcommerce", maxId , whID,(int)Dictionary.DataTransferType.Add,(int)Dictionary.IsDownload.No, 0);
                    unitOfWork.Save();

                    transaction.Commit();
                    return Ok(oEcomInvoice.SalesInvoiceEcom.Id);
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest("Invalid request.");
                }
            }
        }
        private EommerceInvoiceCreateViewModel ConvertNewInvoiceToOldInvoice(EcomInvoice oEcomInvoice,int maxId)
        {
            EommerceInvoiceCreateViewModel oSalesInvoiceEcomOld = new EommerceInvoiceCreateViewModel();
            SalesInvoiceEcommerce oSalesInvoiceEcommerceOld = new SalesInvoiceEcommerce();
            List<SalesInvoiceEcommerceDetail> oSalesInvoiceEcommerceDetailsOld = new List<SalesInvoiceEcommerceDetail>();

            //convert new SalesInvoiceEcom to old SalesInvoiceEcommerce
            oSalesInvoiceEcommerceOld.Addrress = oEcomInvoice.SalesInvoiceEcom.Addrress;
            oSalesInvoiceEcommerceOld.Amount = oEcomInvoice.SalesInvoiceEcom.Amount;
            oSalesInvoiceEcommerceOld.ConsumerId = oEcomInvoice.SalesInvoiceEcom.ConsumerId;
            oSalesInvoiceEcommerceOld.ConsumerName = oEcomInvoice.SalesInvoiceEcom.ConsumerName;
            oSalesInvoiceEcommerceOld.ContactNo = oEcomInvoice.SalesInvoiceEcom.ContactNo;
            oSalesInvoiceEcommerceOld.CopunNo = oEcomInvoice.SalesInvoiceEcom.CopunNo;
            oSalesInvoiceEcommerceOld.DeliveryAddress = oEcomInvoice.SalesInvoiceEcom.DeliveryAddress;
            oSalesInvoiceEcommerceOld.DeliveryCharge = oEcomInvoice.SalesInvoiceEcom.DeliveryCharge;
            oSalesInvoiceEcommerceOld.Discount = oEcomInvoice.SalesInvoiceEcom.Discount;
            oSalesInvoiceEcommerceOld.Email = oEcomInvoice.SalesInvoiceEcom.Email;
            oSalesInvoiceEcommerceOld.RefInvoiceNo = oEcomInvoice.SalesInvoiceEcom.RefInvoiceNo;
            oSalesInvoiceEcommerceOld.Remarks = oEcomInvoice.SalesInvoiceEcom.Remarks;
            oSalesInvoiceEcommerceOld.OrderDate = oEcomInvoice.SalesInvoiceEcom.OrderDate;
            oSalesInvoiceEcommerceOld.OrderNo = oEcomInvoice.SalesInvoiceEcom.OrderNo;
            oSalesInvoiceEcommerceOld.Outlet = oEcomInvoice.SalesInvoiceEcom.Outlet;
            oSalesInvoiceEcommerceOld.LeadType = 1;
            oSalesInvoiceEcommerceOld.Status = (int)Dictionary.ECommerceOrderStatus.Assigned;
            oSalesInvoiceEcommerceOld.IsEmi = oEcomInvoice.SalesInvoiceEcom.IsEmi;


            //string to int?
            //oSalesInvoiceEcommerceOld.EComOrderId = oEcomInvoice.SalesInvoiceEcom.EComOrderId;
            //oSalesInvoiceEcommerceOld.Id = oEcomInvoice.SalesInvoiceEcom.Id;
            //oSalesInvoiceEcommerceOld.SalesPersonId = oEcomInvoice.SalesInvoiceEcom.SalesPersonId;
            oSalesInvoiceEcommerceOld.EComOrderId = maxId;
            oSalesInvoiceEcommerceOld.Id = maxId;
            oSalesInvoiceEcommerceOld.SalesPersonId = maxId;

            oSalesInvoiceEcommerceOld.ApprovalNo = "";
            oSalesInvoiceEcommerceOld.BankId = null;
            oSalesInvoiceEcommerceOld.BankName = "";
            oSalesInvoiceEcommerceOld.CardCategory = "";
            oSalesInvoiceEcommerceOld.CardCategoryId = null;
            oSalesInvoiceEcommerceOld.CardType = null;
            oSalesInvoiceEcommerceOld.CardTypeId = null;
            oSalesInvoiceEcommerceOld.InstrumentDate = null;
            oSalesInvoiceEcommerceOld.InstrumentNo = "";
            oSalesInvoiceEcommerceOld.NoOfInstallment = null;
            oSalesInvoiceEcommerceOld.PaymentType = 0;

            //var BankName = "";
            //var InstrumentNo = "";
            //var NoOfInstallment = 0;
            //foreach (var item in oEcomInvoice.Payments)
            //{
            //    NoOfInstallment += 1;
            //    BankName += ", " + item.GatewayId;
            //    InstrumentNo += ", " + item.TransactionId;
            //    oSalesInvoiceEcommerceOld.InstrumentDate = item.PaidAtUtc;
            //}
            //oSalesInvoiceEcommerceOld.NoOfInstallment = NoOfInstallment;
            //oSalesInvoiceEcommerceOld.BankName = BankName;
            //oSalesInvoiceEcommerceOld.NoOfInstallment = NoOfInstallment;

            //convert new SalesInvoiceEcomProduct to old SalesInvoiceEcommercedetails
            foreach (var item in oEcomInvoice.Products)
            {
                SalesInvoiceEcommerceDetail oInvoiceEcomDetailsOld = new SalesInvoiceEcommerceDetail();
                oInvoiceEcomDetailsOld.DiscountAmount = item.DiscountAmount;
                oInvoiceEcomDetailsOld.IsFreeQty = item.IsFreeQty;
                oInvoiceEcomDetailsOld.ProductCode = item.ProductCode;
                oInvoiceEcomDetailsOld.ProductName = item.ProductName;
                oInvoiceEcomDetailsOld.Quantity = item.Quantity;
                oInvoiceEcomDetailsOld.UnitPrice = item.UnitPrice;
                oInvoiceEcomDetailsOld.EcomOrderId = maxId;
                oSalesInvoiceEcommerceDetailsOld.Add(oInvoiceEcomDetailsOld);
            }

            oSalesInvoiceEcomOld.SalesInvoiceEcommerce = oSalesInvoiceEcommerceOld;
            oSalesInvoiceEcomOld.SalesInvoiceEcommerceDetails = oSalesInvoiceEcommerceDetailsOld;
            return oSalesInvoiceEcomOld;
        }
        [HttpGet]
        [Route("list")]
        public IHttpActionResult List([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                try
                {
                    List<EcomInvoice> dataList = new List<EcomInvoice>();
                    var invoiceList =  unitOfWork.InvoiceEcom.GetAll().OrderBy(c=>c.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    foreach (var invoice in invoiceList)
                    {
                        EcomInvoice data = new EcomInvoice();
                        data.SalesInvoiceEcom = invoice;
                        //products
                        var products = unitOfWork.InvoiceEcomProducts.Find(c=>c.EcomOrderID== invoice.EComOrderId).ToList();
                        data.Products = products;
                        //Payments
                        var payments = unitOfWork.InvoiceEcomPayments.Find(c => c.EcomOrderID == invoice.EComOrderId).ToList();
                        data.Payments = payments;
                        //ExchangeOffers
                        var exchangeOffers = unitOfWork.InvoiceEcomExchangeOffers.Find(c => c.EcomOrderID == invoice.EComOrderId).ToList();
                        data.ExchangeOffers = exchangeOffers;
                        dataList.Add(data);
                    }
                    return Ok(dataList);
                }
                catch
                {
                    return BadRequest("Invalid request.");
                }
            }
        }

        [HttpGet]
        [Route("invoice-by-phoneNo")]
        public IHttpActionResult Details([FromUri]string phoneNo)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                try
                {
                    List<InvoiceViewModel> dataList = new List<InvoiceViewModel>();
                    var invoiceList = unitOfWork.InvoiceEcom.GetInvoice(phoneNo);

                    foreach (var invoice in invoiceList)
                    {
                        InvoiceViewModel data = new InvoiceViewModel();
                        data.Invoice = invoice;
                        //products
                        var products = unitOfWork.InvoiceEcom.GetInvoiceProduct(invoice.InvoiceID, phoneNo).ToList();
                        data.Products = products;
                        //Payments
                        var payments = unitOfWork.InvoiceEcom.GetInvoicePayments(invoice.InvoiceID, phoneNo).ToList();
                        data.Payments = payments;
                        //ExchangeOffers
                        var exchangeOffers = unitOfWork.InvoiceEcom.GetInvoiceExchangeOffers(invoice.InvoiceID, phoneNo).ToList();
                        data.ExchangeOffers = exchangeOffers;
                        dataList.Add(data);
                    }
                    return Ok(dataList);
                }
                catch
                {
                    return BadRequest("Invalid request.");
                }
            }
        }


        [HttpGet]
        [Route("invoice-extra-data")]
        public IHttpActionResult GetInvoiceExtraData([FromUri]string webOrderId)
        {
            using (var unitOfWork = new UnitOfWork(new CasperJetContext()))
            {
                try
                {
                    InvoiceExtraData dataList = unitOfWork.InvoiceEcom.GetInvoiceExtraData(webOrderId);
                    return Ok(dataList);
                }
                catch
                {
                    return BadRequest("Invalid request.");
                }
            }
        }
    }
}
