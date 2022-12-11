using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Class.Library;
using CJ.Class.Web.UI.Class;
using CJ.Class.POS;

namespace CJ.Win.Ecommerce
{
    public partial class frmLeadInvoices : Form
    {
        EcommerceOrders _oEcommerceOrders;
        EcommerceOrder _oEComOrder;
        bool IsCheck = false;
        string SL = "";
        CustomerDetail _oCustomerDetail;
        CustomerTransaction _oCustomerTransaction;
        ProductDetail _oProductDetail;
        RetailConsumer oRetailConsumer;
        SalesInvoice _oSalesInvoice;

        public frmLeadInvoices()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECommerceOrderStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            _oEcommerceOrders = new EcommerceOrders();
            lvwECommerceOrder.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oEcommerceOrders.RefreshforInvoice(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text.Trim(), txtConsumerName.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), nStatus, IsCheck);

            foreach (EcommerceOrder oEcommerceOrder in _oEcommerceOrders)
            {
                ListViewItem oItem = lvwECommerceOrder.Items.Add(oEcommerceOrder.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oEcommerceOrder.Outlet.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ConsumerName.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ContactNo.ToString());
                oItem.SubItems.Add(oEcommerceOrder.Addrress.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Amount).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Discount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommercePaymentType), oEcommerceOrder.PaymentType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), oEcommerceOrder.Status));

                oItem.Tag = oEcommerceOrder;
            }
            this.Cursor = Cursors.Default;
            this.Text = "Lead Assign List [" + _oEcommerceOrders.Count + "]";
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmLeadInvoices_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice, EcommerceOrder _oEcommerceOrder)
        {
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = 5364;
            _oCustomerDetail.RefreshForSalesOrder();

            _oSalesInvoice.OrderNo = _oEcommerceOrder.OrderNo.ToString();
            _oSalesInvoice.CustomerID = _oCustomerDetail.CustomerID;
            _oSalesInvoice.DeliveryAddress = _oEcommerceOrder.DeliveryAddress;
            _oSalesInvoice.SalesPersonID = _oEcommerceOrder.SalesPersonID;
            _oSalesInvoice.WarehouseID = 68;
            _oSalesInvoice.Remarks = _oEcommerceOrder.Remarks;
            _oSalesInvoice.OrderID = -1; //
            _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CREDIT;
            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.PriceOptionID = (int)Dictionary.PriceOption.MRP;
            _oSalesInvoice.SalesPromotionID = 0;
            _oSalesInvoice.SundryCustomerID = _oEcommerceOrder.ConsumerID;
            _oSalesInvoice.Discount = _oEcommerceOrder.Discount;
            _oSalesInvoice.InvoiceAmount = _oEcommerceOrder.Amount;
            EcommerceOrder oEcommerceOrderItem = new EcommerceOrder();
            oEcommerceOrderItem.GetItemForHO(_oEcommerceOrder.EComOrderID);
            foreach (EcommerceOrderDetail oItem in oEcommerceOrderItem)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oSalesInvoiceItem.ProductID = oItem.ProductID;
                _oSalesInvoiceItem.UnitPrice = oItem.UnitPrice;
                _oSalesInvoiceItem.Quantity = oItem.Quantity;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                _oProductDetail.Refresh();
                _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                if (Utility.CompanyInfo == "TEL")
                {

                    if (_oSalesInvoiceItem.UnitPrice == 0)
                    {
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    }
                    else
                    {
                        TPVATProduct _oTPVATProduct = new TPVATProduct();
                        if (_oTPVATProduct.IsProductExists(_oSalesInvoiceItem.ProductID))
                        {
                            _oSalesInvoiceItem.TradePrice = _oTPVATProduct.TradePrice;
                        }
                        else
                        {
                            _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);
                        }
                    }
                }
                else
                {
                    if (_oSalesInvoiceItem.UnitPrice == 0)
                    {
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    }
                    else
                    {
                        _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);
                    }
                }

                ProvisionParam oProvisionParam = new ProvisionParam();
                oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);
                _oSalesInvoiceItem.AdjustedDPAmount = _oSalesInvoiceItem.UnitPrice * oProvisionParam.SC;
                _oSalesInvoiceItem.AdjustedPWAmount = _oSalesInvoiceItem.UnitPrice * oProvisionParam.TP;
                _oSalesInvoiceItem.AdjustedTPAmount = _oSalesInvoiceItem.UnitPrice * oProvisionParam.PW;

                _oSalesInvoiceItem.PromotionalDiscount = 0;

                _oSalesInvoiceItem.IsFreeProduct = oItem.IsFreeQty;
                _oSalesInvoiceItem.FreeQty = 0;

                _oSalesInvoice.Add(_oSalesInvoiceItem);
            }

            return _oSalesInvoice;
        }

        private void btnProcessInvoice_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EcommerceOrder oEcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            if (oEcommerceOrder.Status == (int)Dictionary.ECommerceOrderStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to send the Lead No: " + oEcommerceOrder.OrderNo + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        #region EcommerceOrde Status Update
                        oEcommerceOrder.Status = (int)Dictionary.ECommerceOrderStatus.Invoiced;
                        oEcommerceOrder.UpdateLeadStatus();
                        #endregion

                        #region Sales Invoice
                        _oSalesInvoice = new SalesInvoice();
                        _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oEcommerceOrder);
                        _oSalesInvoice.InsertInvoiceForLead();
                        #endregion

                        #region Consumer Entry

                        oRetailConsumer = new RetailConsumer();
                        oRetailConsumer.ConsumerID = oEcommerceOrder.ConsumerID;
                        oRetailConsumer.ConsumerName = oEcommerceOrder.ConsumerName;
                        oRetailConsumer.Address = oEcommerceOrder.Addrress;
                        oRetailConsumer.ConsumerType = 0;
                        oRetailConsumer.Email = oEcommerceOrder.Email;
                        oRetailConsumer.CellNo = oEcommerceOrder.ContactNo;
                        oRetailConsumer.PhoneNo = "";
                        oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                        oRetailConsumer.ParentCustomerID = _oSalesInvoice.CustomerID;
                        oRetailConsumer.WarehouseID = _oSalesInvoice.WarehouseID;
                        oRetailConsumer.SalesType = (int)Dictionary.SalesType.eStore;

                        oRetailConsumer.AddforLead();

                        #endregion

                        #region Customer Transaction
                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oSalesInvoice);
                        if (_oCustomerTransaction.CheckTranNo())
                            _oCustomerTransaction.AddTran(true);
                        else
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error...Tran no for customer transaction is invalied", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        #endregion

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Send to Invoice.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        return;
                    }
                }


            }
            else
            {
                MessageBox.Show("Only Confirm Credit Order can be sent.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }

        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE;
            return _oCustomerTransaction;
        }
    }
}