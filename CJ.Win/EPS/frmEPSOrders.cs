using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.Library;
using CJ.Class.Web.UI.Class;


namespace CJ.Win.EPS
{
    public partial class frmEPSOrders : Form
    {
        EPSSalesOrders _oEPSSalesOrders;
        CustomerDetail _oCustomerDetail;
        ProvisionParam oProvisionParam;
        ProvisionParam _oProvisionParam;
        ProductDetail _oProductDetail;
        CustomerTransaction _oCustomerTransaction;
        SalesInvoice _oSalesInvoice;
        SalesInvoice _SalesInvoice;
        rptSalesInvoice _orptSalesInvoice;
        Product oProduct;
        TELLib oTELLib;
        EMICalculationDetail _oEMICalculationDetail;
        SalesOrder _oSalesOrder;
        SalesOrderItem _oSalesOrderItem;
        EMICalculation _oEMICalculation;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        SalesInvoiceProductSerials _oSIPSs;
        string sProduct = "";
        string SL = "";
        bool IsSL = true;

        int nUIControl = 0;

        public frmEPSOrders(int _nUIControl)
        {
            InitializeComponent();
            nUIControl = _nUIControl;
        }
        private void LoadCombos()
        {
            // Status

            //cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OrderStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.OrderStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void frmEPSOrders_Load(object sender, EventArgs e)
        {
            LoadCombos();
            RefreshData();
            
            if (nUIControl == 1)
            {
                btnAdd.Visible = true;
                btnEditOrder.Visible = true;
                btndelete.Visible = true;
                btnOrderConfirm.Visible = false;
                btInvoice.Visible = false;
                btnRePrintInvoice.Visible = true;
                btnRePrintEMI.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                btnEditOrder.Visible = false;
                btndelete.Visible = false;
                btnOrderConfirm.Visible = true;
                btInvoice.Visible = true;
                btnRePrintInvoice.Visible = false;
                btnRePrintEMI.Visible = false;
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            RefreshData(); ;
        }
        public void RefreshData()
        {
            lvwOrderList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oEPSSalesOrders = new EPSSalesOrders();
            if (ctlCustomer1.SelectedCustomer != null)
            {
                if (All.Checked == false)
                {
                    _oEPSSalesOrders.Refresh(ctlCustomer1.SelectedCustomer.CustomerID, dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex, txtSalesOrderNo.Text, txtCustomerName.Text);
                }
                else
                {
                    _oEPSSalesOrders.RefreshAll(ctlCustomer1.SelectedCustomer.CustomerID, cmbStatus.SelectedIndex, txtSalesOrderNo.Text, txtCustomerName.Text);
                }

            }
            else
            {
                if (All.Checked == false)
                {
                    _oEPSSalesOrders.Refresh(-1, dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex, txtSalesOrderNo.Text, txtCustomerName.Text);
                }
                else
                {
                    _oEPSSalesOrders.RefreshAll(-1, cmbStatus.SelectedIndex, txtSalesOrderNo.Text, txtCustomerName.Text);

                }
            }

            foreach (EPSSalesOrder oEPSSalesOrder in _oEPSSalesOrders)
            {
                ListViewItem lstItem = lvwOrderList.Items.Add(oEPSSalesOrder.SalesOrder.OrderNo.ToString());
                lstItem.SubItems.Add(oEPSSalesOrder.SalesOrder.OrderDate.ToString());
                lstItem.SubItems.Add(oEPSSalesOrder.EPSCustomer.Customer.CustomerName);
                lstItem.SubItems.Add(oEPSSalesOrder.EPSCustomer.EmployeeName);

                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
                {
                    lstItem.SubItems.Add("Received");
                }
                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed)
                {
                    lstItem.SubItems.Add("Confirmed");
                }
                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Pending)
                {
                    lstItem.SubItems.Add("Pending");
                }
                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Canceled)
                {
                    lstItem.SubItems.Add("Canceled");
                }
                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Invoiced)
                {
                    lstItem.SubItems.Add("Invoiced");
                }
                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Reject_Due_To_Less_Credit)
                {
                    lstItem.SubItems.Add("Reject Due To Less Credit");
                }
                if (oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Cancle_Due_To_Less_Stock)
                {
                    lstItem.SubItems.Add("Cancle Due To Less Stock");
                }
                lstItem.Tag = oEPSSalesOrder;

            }
            this.Text = "EPS Order " + "[" + _oEPSSalesOrders.Count + "]";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEPSOrder oForm = new frmEPSOrder(1);        
            oForm.ShowDialog();
            RefreshData();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;
            if (_oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                frmEPSOrder oForm = new frmEPSOrder(2);
                oForm.ShowDialog(_oEPSSalesOrder);
            }
            else MessageBox.Show("This order is lock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            RefreshData();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;
            if (_oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to delete Order: " + _oEPSSalesOrder.SalesOrder.OrderNo + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oEPSSalesOrder.DeleteEPSSalesDetail();
                        _oEPSSalesOrder.DeleteEPSSales();

                        _oSalesOrderItem = new SalesOrderItem();
                        _oSalesOrderItem.Delete(_oEPSSalesOrder.OrderID);

                        _oSalesOrder = new SalesOrder();
                        _oSalesOrder.DeleteOrder(_oEPSSalesOrder.OrderID);
                        DBController.Instance.CommitTransaction();
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("This Order is not eligible to Detete", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrderConfirm_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;
            if (_oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                frmEPSOrder oForm = new frmEPSOrder(3);
                oForm.ShowDialog(_oEPSSalesOrder);
            }
            else MessageBox.Show("This order is lock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            RefreshData();
        }


        private void btInvoice_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;

            if (_oEPSSalesOrder.SalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to send the Order No: " + _oEPSSalesOrder.SalesOrder.OrderNo + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oEPSSalesOrder.SalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Invoiced;
                        _oEPSSalesOrder.SalesOrder.UpdateStatus();

                        SalesInvoice _oSalesInvoice;
                        _oSalesInvoice = new SalesInvoice();
                        _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, _oEPSSalesOrder.SalesOrder);
                        _oSalesInvoice.InsertForEPS();

                        ///
                        // Insert in Customer Transaction and Update Customer Account.
                        ///

                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oEPSSalesOrder.SalesOrder, _oSalesInvoice);
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
                        RefreshData();
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
                MessageBox.Show("This order is lock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshData();
            }
        }
        
        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
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
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.EPS;
            _oSalesInvoice.UserID = Utility.UserId;           
            _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
            _oSalesInvoice.SalesPromotionID = _oSalesOrder.SalesPromotionID;

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
            if (_oSalesInvoice.SalesPromotionID != -1)
            {
                foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                {
                    ProvisionParam _oProvisionParam = new ProvisionParam();
                    if (_oProvisionParam.GetFreeProduct(_oSalesInvoiceItem.ProductID, _oSalesInvoice.SalesPromotionID))
                    {
                        if (IsInvoiceProduct(_oSalesInvoice, _oProvisionParam.FreeProductID))
                        {
                            _oSalesInvoiceItem.PromotionalDiscount = _oProvisionParam.Discount;
                            _oSalesInvoiceItem.FreeQty = (int)(_oSalesInvoiceItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;
                        }
                        else
                        {
                            _oProvisionParam = new ProvisionParam();

                            _oSalesInvoiceItem.ProductID = _oProvisionParam.FreeProductID;
                            _oSalesInvoiceItem.UnitPrice = 0;
                            _oSalesInvoiceItem.Quantity = 0;

                            _oProductDetail = new ProductDetail();
                            _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                            _oProductDetail.Refresh();
                            _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                            _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                            if (_oSalesInvoiceItem.UnitPrice == 0)
                                _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                            else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);

                            _oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                            _oSalesInvoiceItem.AdjustedDPAmount = 0;
                            _oSalesInvoiceItem.AdjustedPWAmount = 0;
                            _oSalesInvoiceItem.AdjustedTPAmount = 0;
                            _oSalesInvoiceItem.PromotionalDiscount = _oProvisionParam.Discount;
                            _oSalesInvoiceItem.IsFreeProduct = 1;
                            _oSalesInvoiceItem.FreeQty = (int)(_oSalesInvoiceItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;

                            _oSalesInvoice.Add(_oSalesInvoiceItem);


                        }
                    }
                }
            }
           return _oSalesInvoice;
        }
        public bool IsInvoiceProduct(SalesInvoice _oSalesInvoice, int nProductID)
        {
            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                if (oSalesInvoiceItem.ProductID == nProductID)
                    return true;
            }
            return false;
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
        
        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesOrder _oSalesOrder, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.CustomerID = _oSalesOrder.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;

            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;

            _oEMICalculation = new EMICalculation();
            _oEMICalculation.RefreshByOrderID(_oEPSSalesOrder.OrderID);

            //_oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.Amount = _oEMICalculation.PrincipalPayable + _oEMICalculation.InterestPayable;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesOrder.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.EPS_INVOICE;

            return _oCustomerTransaction;
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }

        private void btnRePrintInvoice_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;

                _SalesInvoice = new SalesInvoice();
                _SalesInvoice.OrderID = _oEPSSalesOrder.OrderID;
                _SalesInvoice.RefreshForInvoiceID();

                if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.InvoiceID = _SalesInvoice.InvoiceID;
                    _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
                    InvoiceWiseBarcode();
                    PrintInvoiceEPS();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("This Order is not Eligible to Print/Re-Print Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            
        }

        private void btnRePrintEMI_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sProduct = "";
            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;

            _SalesInvoice = new SalesInvoice();
            _SalesInvoice.OrderID = _oEPSSalesOrder.OrderID;
            _SalesInvoice.RefreshForInvoiceID();

            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _SalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                {
                    StockTranItem oItem = new StockTranItem();
                    oItem.ProductID = oSalesInvoiceItem.ProductID;
                    oProduct = new Product();
                    oProduct.ProductID = oItem.ProductID;
                    oProduct.RefreshByProductID();

                    if (sProduct == "")
                        sProduct = oProduct.ProductCode + "   " + oProduct.ProductName;
                    else sProduct = sProduct + "\n" + oProduct.ProductCode + "   " + oProduct.ProductName;
                }


                PrintEMI();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("This Order is not Eligible to Print/Re-Print EMI", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void PrintInvoiceEPS()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();


            //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrintEPS));
            rptSalesInvoiceAutoPrintEPS doc = new rptSalesInvoiceAutoPrintEPS();

            doc.SetDataSource(_orptSalesInvoice);

            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
            doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
            doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            doc.SetParameterValue("Discount", _orptSalesInvoice.Discount.ToString());
            doc.SetParameterValue("InvoiceAmount", _orptSalesInvoice.InvoiceAmount.ToString());
            doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
            doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
            doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
            doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
            doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
            doc.SetParameterValue("IsSL",IsSL);
            doc.SetParameterValue("SL", SL);

            doc.SetParameterValue("EPSCustomerCode", _orptSalesInvoice.EPSCustomerCode.ToString());
            doc.SetParameterValue("EmployeeName", _orptSalesInvoice.EmployeeName.ToString());
            doc.SetParameterValue("EmployeeAddress", _orptSalesInvoice.EmployeeAddress.ToString());
            doc.SetParameterValue("EPSCustPhoneNo", _orptSalesInvoice.PhoneNo.ToString());
            doc.SetParameterValue("EPSDeliveryWHName", _orptSalesInvoice.EPSDeliveryWHName.ToString());

            if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
            {
                doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
            }
            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
            {
                doc.SetParameterValue("InvoiceTypeName", "EPS Reverse Invoice");
            }

            doc.SetParameterValue("InvoiceHeader", "Re-Print");

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);
            //doc.PrintToPrinter(1, true, 1, 1);

        }
        public void PrintEMI()
        {
            _oEMICalculationDetail = new EMICalculationDetail();
            _oEMICalculationDetail.Refresh(_oSalesInvoice.OrderID);

            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();

            //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptEPSEMIPrint));

            rptEPSEMIPrint doc = new rptEPSEMIPrint();

            doc.SetDataSource(_oEMICalculationDetail);

            doc.SetParameterValue("Commpany", _orptSalesInvoice.CustomerName.ToString());
            doc.SetParameterValue("EPSCustomerCode", _orptSalesInvoice.EPSCustomerCode.ToString());
            doc.SetParameterValue("EmployeeCode", _orptSalesInvoice.EmployeeCode.ToString());
            doc.SetParameterValue("EmployeeName", _orptSalesInvoice.EmployeeName.ToString());
            doc.SetParameterValue("Designation", _orptSalesInvoice.Designation.ToString());
            doc.SetParameterValue("EmployeeAddress", _orptSalesInvoice.EmployeeAddress.ToString());
            doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            doc.SetParameterValue("InvoceNo", _oSalesInvoice.InvoiceNo);
            doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("InvoiceAmount", _oSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("NoInstallment", _orptSalesInvoice.NoOfInstallment.ToString());
            doc.SetParameterValue("Product", sProduct);
            doc.SetParameterValue("User Name", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Report_Name", "Equal Monthly Installment [EMI]");
            doc.SetParameterValue("InvoiceHeader", "Re-Print");

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);
            //doc.PrintToPrinter(1, true, 1, 1);

        }

        public void InvoiceWiseBarcode()
        {
            SL = "";
            EPSSalesOrder _oEPSSalesOrder = (EPSSalesOrder)lvwOrderList.SelectedItems[0].Tag;

            _SalesInvoice = new SalesInvoice();
            _SalesInvoice.OrderID = _oEPSSalesOrder.OrderID;
            _SalesInvoice.RefreshForInvoiceID();

            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _SalesInvoice.InvoiceID;

            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(_oSalesInvoice.InvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {
                string PCode = "";
                IsSL = true;

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {
                    IsSL = false;
                    if (PCode == "")
                    {
                        PCode = "<" + SIPSs.ProductCode + ">";
                    }
                    else
                    {
                        PCode = " ";
                    }
                    if (SL != "")
                    {
                        SL = SL + ",";
                    }
                    SL = SL + PCode + SIPSs.ProductSerialNo;

                }

            }

        }
    }
}