using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using CJ.Class.Web.UI.Class;
using CJ.Class.Report;
using CJ.Class.Library;

namespace CJ.Win.EPS
{
    public partial class frmEPSAdjustment : Form
    {
        SalesOrder oSalesOrder;
        SalesInvoices oSalesInvoices;
        SalesInvoice oSalesInvoice;
        SalesInvoice oSalesInvoiceCancel;
        rptSalesInvoice _orptSalesInvoice;
        StockTran _oStockTran;
        ProductStock _oProductStock;
        CustomerDetail _oCustomerDetail;
        EMICalculationDetail _oEMICalculationDetail;
        EPSSalesOrder oEPSSalesOrder;
        CustomerTransaction _oCustomerTransaction;
        ProductTransaction _oProductTransaction;
        Warehouse _oWarehouse;
        TELLib oTELLib;
        Product oProduct;
        string sProduct = "";


        int nUIControl = 0;

        public frmEPSAdjustment(int _nUIControl)
        {
            InitializeComponent();
            nUIControl = _nUIControl;
        }

        private void frmEPSInvoiceDelivery_Load(object sender, EventArgs e)
        {
           

            if (nUIControl == 1)
            {
                btPayment.Visible = true;
                btnEarlyClosing.Visible = false;
                btnReverseInvoice.Visible = false;
                this.Text = "Advance Payment";
            }
            else if (nUIControl == 2)
            {
                btPayment.Visible = false;
                btnEarlyClosing.Visible = true;
                btnReverseInvoice.Visible = false;
                this.Text = "Early Closing";
            }
            else if (nUIControl == 3)
            {
                btPayment.Visible = false;
                btnEarlyClosing.Visible = false;
                btnReverseInvoice.Visible = true;
                this.Text = "Invoice Reverse";
            }
            RefreshData();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            oSalesInvoices = new SalesInvoices();
            DBController.Instance.OpenNewConnection();
            int IsCheck = 0;
            if (All.Checked == true)
            {
                IsCheck = 1;
            }
            else
            {
                IsCheck = 0;
            }
            oSalesInvoices.RefreshForEPSInvoiceDelivery(dtFromDate.Value.Date, dtpToDate.Value.Date, txtInvoiceNo.Text, IsCheck);
            lvwInvoiceList.Items.Clear();

            foreach (SalesInvoice oSalesInvoice in oSalesInvoices)
            {
                ListViewItem lstItem = lvwInvoiceList.Items.Add(oSalesInvoice.InvoiceNo);
                lstItem.SubItems.Add(oSalesInvoice.SalesOrder.OrderNo.ToString());
                lstItem.SubItems.Add(oSalesInvoice.SalesOrder.Customer.CustomerCode);
                lstItem.SubItems.Add(oSalesInvoice.SalesOrder.Customer.CustomerName);
                lstItem.SubItems.Add(Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oSalesInvoice.InvoiceAmount.ToString());              

                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.CANCEL)
                {
                    lstItem.SubItems.Add("CANCEL");   
                   
                }
                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    lstItem.SubItems.Add("DELIVERED");   
                 
                }
                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PENDING)
                {
                    lstItem.SubItems.Add("PENDING");   
                
                }
                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
                {
                    lstItem.SubItems.Add("PROCESSING DELIVERY");   
                  
                }
                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
                {
                    lstItem.SubItems.Add("PRODUCT RETURN"); 
                 
                }
                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE)
                {
                    lstItem.SubItems.Add("REVERSE"); 
                   
                }
                if (oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED)
                {
                    lstItem.SubItems.Add("UNDELIVERED"); 
                  
                }

                if (oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.UNDELIVERED_DUE_TO_STOCK_LIMIT)
                {
                    lstItem.SubItems.Add("UNDELIVERED DUE TO STOCK LIMIT"); 
                   
                }
                lstItem.Tag = oSalesInvoice;
            }
        }

     
        public StockTran SetData(StockTran oStockTran,SalesInvoice _oSalesInvoice)
        {       
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerDetail.RefreshForSalesOrder();
            _oSalesInvoice.RefreshSalesInvoiceItem();

            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.TranDate = DateTime.Now;
            oStockTran.FromChannelID = _oCustomerDetail.ChannelID;
            oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
            oStockTran.Remarks = _oSalesInvoice.Remarks;

            foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                oItem.Qty = oSalesInvoiceItem.Quantity;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
                oProduct = new Product();
                oProduct.ProductID = oItem.ProductID;
                oProduct.RefreshByProductID();

                if (sProduct == "")
                    sProduct = oProduct.ProductCode + "   " + oProduct.ProductName;
                else sProduct = sProduct + "\n" + oProduct.ProductCode + "   " + oProduct.ProductName;
            }

            return oStockTran;
        }
       

        private void btnInvoiceReverse_Click(object sender, EventArgs e)
        {
            if (lvwInvoiceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oSalesInvoice = (SalesInvoice)lvwInvoiceList.SelectedItems[0].Tag;
            if (oSalesInvoice != null)
            {
                if (oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.DELIVERED)
                {

                    oSalesInvoice.RefreshSalesInvoiceItem();

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        ///
                        // Insert in SalesInvoice and SalesInvoiceDetail.
                        ///

                        oSalesInvoiceCancel = new SalesInvoice();
                        oSalesInvoiceCancel = GetDataForSalesInvoice(oSalesInvoiceCancel, oSalesInvoice);
                        oSalesInvoiceCancel.Insert(true);

                        ///
                        // Insert in Customer Transaction and Update Customer Account.
                        ///
                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, oSalesInvoiceCancel);
                        _oCustomerTransaction.AddTran(false);

                        ///
                        // Insert in Product Transaction and Product transaction detail.
                        ///
                        _oProductTransaction = new ProductTransaction();
                        _oProductTransaction = GetDataForProductTran(_oProductTransaction, oSalesInvoiceCancel);
                        _oProductTransaction.Insert();

                        ///
                        // Update Product Satock
                        ///        
                        foreach (SalesInvoiceItem _oSalesInvoiceItem in oSalesInvoiceCancel)
                        {
                            ProductStock oProductStock = new ProductStock();

                            oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                            oProductStock.Quantity = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                            oProductStock.WarehouseID = oSalesInvoiceCancel.WarehouseID;
                            oProductStock.ChannelID = _oProductTransaction.FromChannelID;

                            oProductStock.UpdateCurrentStock(true);
                        }
                        ///
                        // Update Previous Sales Invoice 
                        ///    
                        oSalesInvoice.UserID = Utility.UserId;
                        oSalesInvoice.UpadteInvoiceStatus(oSalesInvoice.InvoiceID, (int)Dictionary.InvoiceStatus.REVERSE);

                        ///
                        // Update Previous Sales Order 
                        ///    
                        oSalesOrder = new SalesOrder();
                        oSalesOrder.OrderID = oSalesInvoice.OrderID;
                        oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Canceled;
                        oSalesOrder.UpdateStatus();

                        ///
                        // Delete EPS Sales Detail
                        ///  
                        oEPSSalesOrder = new EPSSalesOrder();
                        oEPSSalesOrder.OrderID = oSalesInvoice.OrderID;
                        oEPSSalesOrder.DeleteEPSSalesDetail();
                        oEPSSalesOrder.DeleteEPSSales();

                        DBController.Instance.CommitTran();
                        AppLogger.LogInfo("Web: Success fully Reverse the Invoice =" + Utility.Username);
                        MessageBox.Show("You Have Successfully Reverse the Invoice", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Web: error in Invoice Cancel =" + ex);
                        MessageBox.Show("Error.." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Only Delivered Invoice Can Be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public SalesInvoice GetDataForSalesInvoice(SalesInvoice oSalesInvoiceCancel, SalesInvoice oSalesInvoice)
        {            

            oSalesInvoiceCancel.CustomerID = oSalesInvoice.CustomerID;
            oSalesInvoiceCancel.DeliveryAddress = oSalesInvoice.DeliveryAddress;
            oSalesInvoiceCancel.SalesPersonID = 0;
            oSalesInvoiceCancel.WarehouseID = oSalesInvoice.WarehouseID;
            oSalesInvoiceCancel.Discount = oSalesInvoice.Discount;
            oSalesInvoiceCancel.Remarks = "Reference InvoiceNo : " + oSalesInvoice.InvoiceNo.ToString() + " , Date : " + oSalesInvoice.InvoiceDate.ToString();
            oSalesInvoiceCancel.InvoiceTypeID = (int)Dictionary.InvoiceType.CREDIT_REVERSE;
            oSalesInvoiceCancel.InvoiceAmount = oSalesInvoice.InvoiceAmount;
            oSalesInvoiceCancel.PriceOptionID = oSalesInvoice.PriceOptionID;
            oSalesInvoiceCancel.DueAmount = 0;
            oSalesInvoiceCancel.RefDetails = "REV_" + oSalesInvoice.RefDetails;
            oSalesInvoiceCancel.Terminal = 1;
            oSalesInvoiceCancel.SalesPromotionID = oSalesInvoice.SalesPromotionID;
            oSalesInvoiceCancel.UserID = Utility.UserId;

            foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
            {
                SalesInvoiceItem _oItem = new SalesInvoiceItem();

                _oItem.ProductID = oSalesInvoiceItem.ProductID;
                _oItem.UnitPrice = oSalesInvoiceItem.UnitPrice;
                _oItem.Quantity = oSalesInvoiceItem.Quantity;
                _oItem.CostPrice = oSalesInvoiceItem.CostPrice;
                _oItem.VATAmount = oSalesInvoiceItem.VATAmount;
                _oItem.TradePrice = oSalesInvoiceItem.TradePrice;
                _oItem.AdjustedDPAmount = 0;
                _oItem.AdjustedPWAmount = 0;
                _oItem.AdjustedTPAmount = 0;
                _oItem.PromotionalDiscount = 0;
                _oItem.IsFreeProduct = 0;
                _oItem.FreeQty = 0;
                oSalesInvoiceCancel.Add(_oItem);
            }
            return oSalesInvoiceCancel;
        }
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice oSalesInvoiceCancel)
        {

            _oCustomerTransaction.CustomerID = oSalesInvoiceCancel.CustomerID;
            _oCustomerTransaction.TranNo = oSalesInvoiceCancel.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = oSalesInvoiceCancel.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = oSalesInvoiceCancel.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = oSalesInvoiceCancel.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE_REVERSE;

            return _oCustomerTransaction;
        }
        public ProductTransaction GetDataForProductTran(ProductTransaction _oProductTransaction, SalesInvoice oSalesInvoiceCancel)
        {
          
            _oProductTransaction.TranNo = oSalesInvoiceCancel.RefDetails;
            _oProductTransaction.TranDate = DateTime.Now;
            _oWarehouse = new Warehouse();
            _oWarehouse.WarehouseID = oSalesInvoiceCancel.WarehouseID;
            _oWarehouse.Reresh();
            _oProductTransaction.FromWHID = oSalesInvoiceCancel.WarehouseID;
            _oProductTransaction.FromChannelID = _oWarehouse.ChannelID;
            _oProductTransaction.UserID = Utility.UserId;
            _oProductTransaction.Remarks = oSalesInvoiceCancel.Remarks;
            _oProductTransaction.Terminal = 1;

            // Product Detail
            foreach (SalesInvoiceItem _oSalesInvoiceItem in oSalesInvoiceCancel)
            {
                ProductTransactionDetail _oProductTransactionDetail = new ProductTransactionDetail();

                _oProductTransactionDetail.ProductID = _oSalesInvoiceItem.ProductID;
                _oProductTransactionDetail.StockPrice = _oSalesInvoiceItem.CostPrice;
                _oProductTransactionDetail.Qty = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                _oProductTransaction.Add(_oProductTransactionDetail);
            }
            return _oProductTransaction;
        }

        private void btnAdvancePayment_Click(object sender, EventArgs e)
        {
            if (lvwInvoiceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oSalesInvoice = (SalesInvoice)lvwInvoiceList.SelectedItems[0].Tag;

            frmEPSCollection ofrmEPSCollection = new frmEPSCollection(0);
            ofrmEPSCollection.ShowDialog(oSalesInvoice);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEarlyClosing_Click(object sender, EventArgs e)
        {
            if (lvwInvoiceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oSalesInvoice = (SalesInvoice)lvwInvoiceList.SelectedItems[0].Tag;

            frmEPSCollection ofrmEPSCollection = new frmEPSCollection(2);
            ofrmEPSCollection.ShowDialog(oSalesInvoice);
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
        }

    }
}