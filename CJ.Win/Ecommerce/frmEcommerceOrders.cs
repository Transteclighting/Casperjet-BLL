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

namespace CJ.Win.Ecommerce
{
    public partial class frmEcommerceOrders : Form
    {
        SalesOrders _oSalesOrders;
        Utilities _oUtilites;
        CustomerTransaction _oCustomerTransaction;
        CustomerDetail _oCustomerDetail;
        ProvisionParam _oProvisionParam;
        ProductDetail _oProductDetail;
        ProductStock _oProductStock;
        double _InvoiceAmount = 0;

        public frmEcommerceOrders()
        {
            InitializeComponent();
        }

        private void frmEcommerceOrders_Load(object sender, EventArgs e)
        {
            Refresh();
            LoadCombos();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void LoadCombos()
        {
            // Order Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OrderStatus)))
            {
              cmbSatus.Items.Add(Enum.GetName(typeof(Dictionary.OrderStatus), GetEnum));
            }
            cmbSatus.SelectedIndex = 0;

        }
        private void Refresh()
        {
            DBController.Instance.OpenNewConnection();
            _oSalesOrders = new SalesOrders();
            _oSalesOrders.RefreshEcommerce(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text, txtCustomerName.Text, cmbSatus.SelectedIndex);
            lvwOrderList.Items.Clear();

            foreach (SalesOrder oSalesOrder in _oSalesOrders)
            {
                ListViewItem lstItem = lvwOrderList.Items.Add(oSalesOrder.OrderNo.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(oSalesOrder.OrderDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oSalesOrder.SundryCustomerName);
                lstItem.SubItems.Add(oSalesOrder.Address);
                lstItem.SubItems.Add(oSalesOrder.CellNo);
                lstItem.SubItems.Add(oSalesOrder.Email);
                lstItem.SubItems.Add(oSalesOrder.StatusName);

                lstItem.Tag = oSalesOrder;

            }
            this.Text = "Total Sales Order  " + "[" + _oSalesOrders.Count + "]";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEcommerceOrder ofrmECOrder = new frmEcommerceOrder();
            ofrmECOrder.ShowDialog();
            Refresh();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesOrder _oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;

            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                frmEcommerceOrder oform = new frmEcommerceOrder();
                oform.ShowDialog(_oSalesOrder);
                Refresh();
            }
            else
            {
                MessageBox.Show("Only receive status can be edited", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnPrintSalesOrder_Click(object sender, EventArgs e)
        //{
        //    if (lvwOrderList.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    ECOrder oECOrder = (ECOrder)lvwOrderList.SelectedItems[0].Tag;
        //    oECOrder.RefreshItem();

        //    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptECOrder));
        //    doc.SetDataSource(oECOrder);

        //    doc.SetParameterValue("CustomerName", oECOrder.CustomerName);
        //    doc.SetParameterValue("CustomerAddress", oECOrder.CustomerAddress);
        //    doc.SetParameterValue("Mail", oECOrder.CustomerMailID);
        //    doc.SetParameterValue("Mobile", oECOrder.CustomerMobileNo);
        //    doc.SetParameterValue("OrderNo", oECOrder.OrderNo);
        //    doc.SetParameterValue("OrderDate", oECOrder.OrderDate.ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("Amount", oECOrder.Amount);
        //    if (oECOrder.PaymentMode == (int)Dictionary.ECOPaymentMode.Cash)
        //        doc.SetParameterValue("PaymentMode", "Cash");
        //    else doc.SetParameterValue("PaymentMode", "Electronic");
        //    doc.SetParameterValue("PaymentDate", oECOrder.DesiredPaymentDate.ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("PaymentDes", oECOrder.PaymentDes);
        //    if (oECOrder.DeliveryMode == (int)Dictionary.ECDeliveryMode.Home_Delivery)
        //        doc.SetParameterValue("DeliveryMode", "Home Delivery");
        //    else doc.SetParameterValue("DeliveryMode", "Store Delivery");
        //    doc.SetParameterValue("DeliveryDate", oECOrder.DesiredDeliveryDate.ToString("dd-MMM-yyyy"));
        //    oWarehouse = new Warehouse();
        //    oWarehouse.WarehouseID = oECOrder.DeliveryWHID;
        //    oWarehouse.Reresh();
        //    doc.SetParameterValue("Outlet", oWarehouse.WarehouseName);
        //    doc.SetParameterValue("DeliveryAddress", oECOrder.DeliveryAddress);
        //    doc.SetParameterValue("User", Utility.Username);
        //    doc.SetParameterValue("Status", Enum.GetName(typeof(Dictionary.ECOrderStatus), oECOrder.OrderStatus));

        //    frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
        //    ofrmPrintPreview.ShowDialog(doc);
        //}
      
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesOrder _oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;

            if (_oSalesOrder.StatusName!="Received")

            {
                MessageBox.Show("Only received status can be deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ECOrder oECOrder = new ECOrder();

            try
            {
                if (MessageBox.Show("Do you want to Delete Order?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBController.Instance.BeginNewTransaction();
                    oECOrder.Delete(_oSalesOrder.OrderID);
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Success fully Delete  Order -" + oECOrder.OrderNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSendToInvo_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesOrder _oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;

            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to send the Order No: " + _oSalesOrder.OrderNo + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Invoiced;
                        _oSalesOrder.UpdateStatus();

                        SalesInvoice _oSalesInvoice;
                        _oSalesInvoice = new SalesInvoice();
                        _oProductStock = new ProductStock();
                        _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, _oSalesOrder);
                        _oSalesInvoice.InsertForEPS();

                        foreach (SalesOrderItem oItem in _oSalesOrder)
                        {
                            SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();
                            _oProductStock = new ProductStock();

                            int nBookingQty = Convert.ToInt32(oItem.ConfirmQuantity.ToString());

                            _oProductStock.UpdateBookingStock(true, nBookingQty, _oSalesInvoice.WarehouseID, oItem.ProductID);

                        }

                        ///
                        // Insert in Customer Transaction and Update Customer Account.
                        ///

                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oSalesInvoice, _oSalesOrder);
                        if (_oCustomerTransaction.CheckTranNo())
                            _oCustomerTransaction.AddTran(true);
                        else
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error...Tran no for customer transaction is invalied", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Send to Invoice.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        //MessageBox.Show("Successfully Send to Invoice.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Only receive status can be send to invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Refresh();
            }
        }

        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice, SalesOrder _oSalesOrder)
        {
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = _oSalesOrder.CustomerID;
            _oCustomerDetail.refresh();

            _oSalesInvoice.OrderNo = _oSalesOrder.OrderNo.ToString();
            _oSalesInvoice.CustomerID = _oSalesOrder.CustomerID;
            _oSalesInvoice.DeliveryAddress = _oSalesOrder.DeliveryAddress;
            _oSalesInvoice.SalesPersonID = _oSalesOrder.SalesPromotionID;
            _oSalesInvoice.WarehouseID = _oSalesOrder.WarehouseID;
            _oSalesInvoice.Remarks = _oSalesOrder.Remarks;
            _oSalesInvoice.OrderID = _oSalesOrder.OrderID;
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CASH;
            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
            _oSalesInvoice.SalesPromotionID = _oSalesOrder.SalesPromotionID;
            _oSalesInvoice.SundryCustomerID = _oSalesOrder.SundryCustomerID;

            _oSalesInvoice.Discount = _oSalesOrder.Discount;
            _oSalesInvoice.InvoiceAmount = GetInvoiceAmount(_oSalesOrder);

            foreach (SalesOrderItem oItem in _oSalesOrder)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oProvisionParam = new ProvisionParam();

                _oSalesInvoiceItem.ProductID = oItem.ProductID;
                _oSalesInvoiceItem.UnitPrice = oItem.UnitPrice;
                _oSalesInvoiceItem.Quantity = oItem.ConfirmQuantity;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                _oProductDetail.Refresh();
                _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                if (_oSalesInvoiceItem.UnitPrice == 0)
                    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);

                _oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                _oSalesInvoiceItem.AdjustedDPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.SC;
                _oSalesInvoiceItem.AdjustedPWAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.PW;
                _oSalesInvoiceItem.AdjustedTPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.TP;

                _oProvisionParam = new ProvisionParam();
                if (_oProvisionParam.GetFreeProduct(_oProductDetail.ProductID, _oSalesOrder.SalesPromotionID))
                {
                    _oSalesInvoiceItem.PromotionalDiscount = _oProvisionParam.Discount;
                }
                else _oSalesInvoiceItem.PromotionalDiscount = 0;

                _oSalesInvoiceItem.IsFreeProduct = 0;
                _oSalesInvoiceItem.FreeQty = 0;


                _oSalesInvoice.Add(_oSalesInvoiceItem);

            }
            return _oSalesInvoice;
        }
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice, SalesOrder _oSalesOrder)
        {
            _oCustomerTransaction.CustomerID = _oSalesOrder.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;

            //EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;

            //_oEMICalculation = new EMICalculation();
            //_oEMICalculation.RefreshByOrderID(_oEPSSalesOrder.OrderID);

            //_oSalesInvoice.InvoiceAmount = GetInvoiceAmount(_oSalesOrder);

            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesOrder.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;

            return _oCustomerTransaction;
        }
        public double GetInvoiceAmount(SalesOrder _oSalesOrder)
        {
            double _InvoiceAmount = 0;

            foreach (SalesOrderItem oItem in _oSalesOrder)
            {
                _InvoiceAmount = _InvoiceAmount + (oItem.UnitPrice * oItem.ConfirmQuantity);
            }
            _InvoiceAmount = _InvoiceAmount - _oSalesOrder.Discount;
            return _InvoiceAmount;
        }
    }
}
