// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 27, 2014
// Time : 03:00 PM
// Description: Retail Invoices
// Modify Person And Date:
// </summary>

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
using CJ.Class.Report;
using CJ.Class.POS;
using CJ.Class.DataTransfer;
using CJ.Class.CLP;
using CJ.Class.Warranty;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.Duty;

using ZAM.QRCode.Codec;
using ZAM.QRCode.Codec.Data;
using ZAM.QRCode.Codec.Util;
using System.IO;
using System.Net.Mail;
using CJ.Class.Process;


namespace CJ.POS.RT.Invoice
{
    public partial class frmRetailInvoices : Form
    {
        //Service oService;
        string sWarehouseAddress = "";
        RetailSalesInvoices _oRetailSalesInvoices;
        SalesInvoices _oSalesInvoices;
        RetailConsumer oRetailConsumer;
        DataTransfer oDataTransfer;
        SalesInvoice oSelectedSalesInvoice;
        SalesInvoice oReversrSalesInvoice;
        CustomerTransaction _oCustomerTransaction;
        StockTran _oStockTran;
        ProductStock _oProductStock;
        //SystemInfo oSystemInfo;
        RetailSalesInvoice oRetailSalesInvoice;
        rptSalesInvoice orptSalesInvoice;
        WarrantyProducts oWarrantyProducts;
        WarrantyParameter oWarrantyParameter;
        TELLib _oTELLib;
        DSSalesInvoiceDetail oDSSalesInvoiceProduct;
        DSSalesInvoiceDetail oDSFreeGiftProduct;
        DSSalesInvoiceDetail oDSSalesInvoiceDetail;
        DSSalesInvoiceDetail oDSCreditCard;
        CLPPoint oCLPPoint;
        CLPPointSlab oCLPPointSlab;
        CLPTran oCLPTran;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        int _nUIContorl = 0;
        string SL = "";
        SalesInvoiceProductSerials _oSIPSs;
        double _TotalRSP = 0;
        UserPermission _oUserPermission;
        bool IsCheck = false;
        Image iImage;
        SalesInvoice _oSalesInvoice;
        Outgoing _oOutgoing;
        public frmRetailInvoices(int nUIControl)
        {
            InitializeComponent();
            _nUIContorl = nUIControl;
        }
        public void LoadCombo()
        {
            cmbSalesType.Items.Clear();
            cmbSalesType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;

        }

        private void frmRetailInvoices_Load(object sender, EventArgs e)
        {
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oTELLib = new TELLib();
            //oSystemInfo.Refresh();

            //oSystemInfo.NewVatActive();
            

            sWarehouseAddress = Utility.WarehouseAddress;
            LoadCombo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = _oTELLib.ServerDateTime();
            dtToDate.Value = dtFromDate.Value;
            btnReverseInvoice.Visible = false;
            btnReverseInvoice.Enabled = false;

            RefreshData();
            _oUserPermission = new UserPermission();
            if (_nUIContorl == 0)
            {
                btnReverseInvoice.Visible = true;
                btnReverseInvoice.Enabled = false;

                btInvoicePrint.Visible = false;
                btVATPrint.Visible = false;
                btWarrantyPrint.Visible = false;
                //Reverse Button
                btnReverseInvoice.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.2.6.1"))
                {
                    btnReverseInvoice.Enabled = true;
                }
                btnGenerateWC.Visible = false;
                btnVAT11Ka.Visible = false;
                btnVat63Print.Visible = false;
                btnVat67Print.Visible = false;
                btnSendSMS.Visible = false;
            }
            else
            {
                btnReverseInvoice.Visible = false;
                

                btInvoicePrint.Visible = true;
                btVATPrint.Visible = true;
                btWarrantyPrint.Visible = true;
                //Invoice Print
                btInvoicePrint.Enabled = false;
                if (_oUserPermission.CheckPermission("M40.1.4.1.1"))
                {
                    btInvoicePrint.Enabled = true;
                }
                //Warranty Print
                btWarrantyPrint.Enabled = false;
                if (_oUserPermission.CheckPermission("M40.1.4.1.2"))
                {
                    btWarrantyPrint.Enabled = true;
                }
                //VAT Print
                btVATPrint.Enabled = false;
                if (_oUserPermission.CheckPermission("M40.1.4.1.3"))
                {
                    btVATPrint.Enabled = true;
                }
                btnGenerateWC.Visible = true;
                btnVAT11Ka.Visible = true;
            }

            //if (oSystemInfo.IsNewVat == 1)
            //{
            //    btnVat63Print.Enabled = true;
            //    btVATPrint.Enabled = false;
            //    btnVAT11Ka.Enabled = false;
            //}
            //else
            //{
            //    btnVat63Print.Enabled = false;
            //    btVATPrint.Enabled = true;
            //    btnVAT11Ka.Enabled = true;
            //}
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            lvwInvoice.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            
            _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.RefreshForRetailInvoiceRT(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text.Trim(), txtCustomerID.Text.Trim(), txtCustomerName.Text.Trim(), txtMobileNo.Text.Trim(), txtAddress.Text.Trim(), IsCheck, cmbSalesType.SelectedIndex);
            foreach (SalesInvoice _SalesInvoice in _oSalesInvoices)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(_SalesInvoice.InvoiceNo.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(_SalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(_SalesInvoice.InvoiceAmount.ToString());
                lstItem.SubItems.Add("[" + _SalesInvoice.ConsumerCode + "]" + _SalesInvoice.ConsumerName);
                lstItem.SubItems.Add(_SalesInvoice.MobileNo.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), _SalesInvoice.SalesType));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.InvoiceType), _SalesInvoice.InvoiceTypeID));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.InvoiceStatus), _SalesInvoice.InvoiceStatus));

                lstItem.Tag = _SalesInvoice;

            }
            this.Text = "Invoice" + "[" + _oSalesInvoices.Count + "]";
        }
        private void btReverce_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            oDataTransfer = new DataTransfer();
            oDataTransfer.TableName = "t_salesinvoice";
            oDataTransfer.DataID = (int)_SalesInvoice.InvoiceID;
            oDataTransfer.WarehouseID = _SalesInvoice.WarehouseID;
            oDataTransfer.TransferType = (int)Dictionary.DataTransferType.Add;
            oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;

            if (oDataTransfer.CheckData())
            {
                MessageBox.Show("This Invoice Already Transfered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    
                    oSelectedSalesInvoice = new SalesInvoice();
                    oSelectedSalesInvoice.InvoiceID = _SalesInvoice.InvoiceID;
                    oSelectedSalesInvoice.RefreshForReverseInvoice();

                    #region Create Invoice

                    ///
                    // Insert in SalesInvoice and SalesInvoiceDetail.
                    ///

                    oReversrSalesInvoice = new SalesInvoice();
                    oReversrSalesInvoice = GetDataForSalesInvoice(oReversrSalesInvoice, oSelectedSalesInvoice);
                    oReversrSalesInvoice.InsertPOSInvoice(true);

                    ///
                    // Update Product Becode Info
                    //

                    foreach (ProductBarcode oProductBarcode in oSelectedSalesInvoice.ProductBarcodes)
                    {
                        ProductBarcode _oProductBarcode = new ProductBarcode();

                        _oProductBarcode.WarehouseID = oSelectedSalesInvoice.WarehouseID;
                        _oProductBarcode.ProductId = oProductBarcode.ProductId;
                        _oProductBarcode.ProductSerialNo = oProductBarcode.ProductSerialNo;
                        _oProductBarcode.RefTranNo = oSelectedSalesInvoice.InvoiceNo;

                        _oProductBarcode.UpdateForReverseRetailInvoce();
                    }

                    ///
                    // Insert in Customer Transaction and Update Customer Account.
                    ///
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction);
                    if (_oCustomerTransaction.CheckTranNo())
                        _oCustomerTransaction.AddTran(false);
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error...Tran no for customer transaction is invalied", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    #endregion

                    ///
                    // Insert in Customer Transaction and Update Customer Account for Collection .
                    ///
                    #region Collection

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, oReversrSalesInvoice);
                    _oCustomerTransaction.RetailInsertForReverseRT(Utility.WarehouseID);

                    #endregion

                    ///
                    // Insert in Product Transaction.
                    ///
                    #region Product Transaction

                    _oStockTran = new StockTran();
                    _oStockTran = SetData(_oStockTran, oReversrSalesInvoice);
                    _oStockTran.UserID = Utility.UserId;
                    oReversrSalesInvoice.RetailDeliveryInvoice(oReversrSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.DELIVERED, oReversrSalesInvoice.WarehouseID);
                    _oStockTran.InsertForReverse();

                    foreach (StockTranItem oItem in _oStockTran)
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.WarehouseID = _oStockTran.ToWHID;
                        _oProductStock.ChannelID = _oStockTran.ToChannelID;

                        _oProductStock.UpdateCurrentStock(true);

                        _oProductStock = new ProductStock();
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.WarehouseID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                        _oProductStock.ChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;

                        _oProductStock.UpdateCurrentStock(false);
                    }

                    oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = (int)oReversrSalesInvoice.SundryCustomerID;
                    oRetailConsumer.CustomerID = oReversrSalesInvoice.CustomerID;
                    if (oRetailConsumer.CheckCLPConsumer())
                    {

                    }
                    else
                    {
                        CalculateCLP(oReversrSalesInvoice);
                    }
                    #endregion

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Reverse the Invoice", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice oReversrSalesInvoice, SalesInvoice oSelectedSalesInvoice)
        {
            _oTELLib = new TELLib();

            oReversrSalesInvoice.InvoiceDate = _oTELLib.ServerDateTime();
            oReversrSalesInvoice.CustomerID = oSelectedSalesInvoice.CustomerID;
            oReversrSalesInvoice.DeliveryAddress = oSelectedSalesInvoice.DeliveryAddress;
            oReversrSalesInvoice.DeliveryDate = oSelectedSalesInvoice.DeliveryDate;
            oReversrSalesInvoice.SalesPersonID = oSelectedSalesInvoice.SalesPersonID;
            oReversrSalesInvoice.InvoiceStatus = (int)Dictionary.InvoiceStatus.REVERSE;
            oReversrSalesInvoice.WarehouseID = oSelectedSalesInvoice.WarehouseID;
            oReversrSalesInvoice.Discount = oSelectedSalesInvoice.Discount;
            oReversrSalesInvoice.Remarks = "Ref Invoice No:" + oSelectedSalesInvoice.InvoiceNo;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CASH_REVERSE;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CREDIT)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CREDIT_REVERSE;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EASY_BUY)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.EASY_BUY_REVERSE;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.EPS_REVERSE;
            oReversrSalesInvoice.UserID = Utility.UserId;
            oReversrSalesInvoice.InvoiceAmount = oSelectedSalesInvoice.InvoiceAmount;
            oReversrSalesInvoice.PriceOptionID = oSelectedSalesInvoice.PriceOptionID;
            oReversrSalesInvoice.OtherCharge = oSelectedSalesInvoice.OtherCharge;
            oReversrSalesInvoice.SundryCustomerID = oSelectedSalesInvoice.SundryCustomerID;
            oReversrSalesInvoice.RefInvoiceID = "Ref Invoice ID:" + oSelectedSalesInvoice.InvoiceID;
            oReversrSalesInvoice.RefDetails = "Ref Invoice No:" + oSelectedSalesInvoice.InvoiceNo;

            foreach (SalesInvoiceItem oSalesInvoiceItem in oSelectedSalesInvoice)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oSalesInvoiceItem.ProductID = oSalesInvoiceItem.ProductID;
                _oSalesInvoiceItem.UnitPrice = oSalesInvoiceItem.UnitPrice;
                _oSalesInvoiceItem.CostPrice = oSalesInvoiceItem.CostPrice;
                _oSalesInvoiceItem.VATAmount = oSalesInvoiceItem.VATAmount;
                _oSalesInvoiceItem.TradePrice = oSalesInvoiceItem.TradePrice;
                _oSalesInvoiceItem.AdjustedDPAmount = oSalesInvoiceItem.AdjustedDPAmount;
                _oSalesInvoiceItem.AdjustedPWAmount = oSalesInvoiceItem.AdjustedPWAmount;
                _oSalesInvoiceItem.AdjustedTPAmount = oSalesInvoiceItem.AdjustedTPAmount;
                _oSalesInvoiceItem.PromotionalDiscount = oSalesInvoiceItem.PromotionalDiscount;
                _oSalesInvoiceItem.IsFreeProduct = oSalesInvoiceItem.IsFreeProduct;
                _oSalesInvoiceItem.FreeQty = oSalesInvoiceItem.FreeQty;
                _oSalesInvoiceItem.Quantity = oSalesInvoiceItem.Quantity;

                if (_oSalesInvoiceItem.IsFreeProduct != 1)
                {
                    _TotalRSP = _TotalRSP + _oSalesInvoiceItem.UnitPrice;
                }
                oReversrSalesInvoice.Add(_oSalesInvoiceItem);
            }
            return oReversrSalesInvoice;
        }
        ///
        // End  Customer Transaction.
        ///

        ///
        // Get Data for  Product Transaction.
        ///
        public StockTran SetData(StockTran oStockTran, SalesInvoice _oSalesInvoice)
        {
            _oTELLib = new TELLib();
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.ToChannelID = Utility.ChannelID;
            oStockTran.ToWHID = _oSalesInvoice.WarehouseID;

            oStockTran.ToChannelID = Utility.ChannelID;
            oStockTran.ToWHID = _oSalesInvoice.WarehouseID;

            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = _oTELLib.ServerDateTime();

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                if (oSalesInvoiceItem.IsFreeProduct == 0)
                    oItem.Qty = oSalesInvoiceItem.Quantity;
                else oItem.Qty = oSalesInvoiceItem.FreeQty;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }
        ///
        // End Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///

        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
        {
            _oTELLib = new TELLib();

            _oCustomerTransaction.CustomerID = oReversrSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = oReversrSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = Convert.ToDateTime(_oTELLib.ServerDateTime());
            _oCustomerTransaction.Amount = oReversrSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = oReversrSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = oReversrSalesInvoice.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE_REVERSE;

            return _oCustomerTransaction;
        }
        public CustomerTransaction GetCustomerTranForCollection(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            _oTELLib = new TELLib();

            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranDate = Convert.ToDateTime(_oTELLib.ServerDateTime());
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
            _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;
            _oCustomerTransaction.EntryLocationID = Utility.LocationID;

            return _oCustomerTransaction;
        }
        public void CalculateCLP(SalesInvoice _oSalesInvoice)
        {
            oCLPPoint = new CLPPoint();
            oCLPPointSlab = new CLPPointSlab();
            oCLPPoint.EffectDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            oCLPPoint.GetCLPPoint();
            oCLPPointSlab.PointID = oCLPPoint.PointID;
            oCLPPointSlab.Refresh();

            oCLPTran = new CLPTran();

            oCLPTran.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            oCLPTran.WarehouseID = _oSalesInvoice.WarehouseID;
            oCLPTran.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
            oCLPTran.CustomerID = Utility.CustomerID;
            oCLPTran.PreviousPoint = oRetailConsumer.CurrentCLP;
            double _CPonit = oRetailConsumer.CurrentCLP - _TotalRSP / oCLPPointSlab.SlabAmount;
            oCLPTran.CurrentPoint = (int)_CPonit;
            oCLPTran.EncashmentPoint = 0;
            oCLPTran.UserID = Utility.UserId;
            oCLPTran.TranTypeID = (int)Dictionary.CLPTranType.REVERSE_INVOICE;

            oCLPTran.Insert(false);
        }

        private void btInvoicePrint_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            InvoiceWiseBarcode(_SalesInvoice.InvoiceID);
            long nInvoiceID = 0;
            if (_SalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                nInvoiceID = Convert.ToInt32(_SalesInvoice.RefInvoiceID);
            }
            else
            {
                nInvoiceID = _SalesInvoice.InvoiceID;
            }
            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(nInvoiceID))
            {
                PrintRetailInvoice(_SalesInvoice.InvoiceID, false);
            }
            else
            {
                PrintRetailInvoiceOld(_SalesInvoice.InvoiceID, false);
            }
            this.Cursor = Cursors.Default;
        }

        private void btWarrantyPrint_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            oWarrantyParameter = new WarrantyParameter();
            if (oWarrantyParameter.CheckWarrantyCard(Convert.ToInt32(_SalesInvoice.InvoiceID)))
            {

            }
            else
            {
                MessageBox.Show("There is no warranty card in the invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed\nYou couldn't Print/Re-Print Warranty Card ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(_SalesInvoice.InvoiceID));

            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulk(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, _SalesInvoice, oWP.WarrantyParameterID, false, oWP.ExtendedWarrantyDescription);
            }
            this.Cursor = Cursors.Default;
        }

        private void btVATPrint_Click(object sender, EventArgs e)
        {

            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.ChallanType.VAT_11, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_11);
            this.Cursor = Cursors.Default;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.ChallanType.VAT_11_KA, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_11_KA);
            this.Cursor = Cursors.Default;
        }
        public void PrintVatChallan(SalesInvoice oSalesInvoice, int nType)
        {

            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshByInvoiceID();

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranIDPOS(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID, nType);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                double _TotalVatAmount = 0;
                rptSalesInvoice oSI = new rptSalesInvoice();
                oSI.GetInvoiceStatusByID(oSalesInvoice.InvoiceID);
                if (nType == (int)Dictionary.ChallanType.VAT_63)
                {
                    oDutyTran.GetVATReportPOSNewRT(oSI.InvoiceStatus);
                }
                else
                {
                    _TotalVatAmount = oDutyTran.GetVATReportPOS(oSI.InvoiceStatus);
                }

                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);


                    doc.SetParameterValue("WarehouseAddress", sWarehouseAddress.ToString());
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                    doc.SetParameterValue("TAXNo", _orptSalesInvoice.TaxNo.ToString());
                    //doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
                    //doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToShortTimeString());
                    //doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    //doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    //doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryDateInWord", DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", Utility.VATRegistrationNo);

                    DateTime dShipmentDate = Convert.ToDateTime(oDutyTran.DutyTranDate);
                    doc.SetParameterValue("ActualDeliveryDateTime", dShipmentDate);

                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord);
                    doc.SetParameterValue("VehicleNo", "");
                    doc.SetParameterValue("16(1)", "[ wewa-16 (1) `ªóe¨ ]");
                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }
                    /////

                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }
                    _oTELLib = new TELLib();
                    doc.SetParameterValue("TotalText", _oTELLib.changeNumericToWords(nTotal) + " Pcs");

                    doc.SetParameterValue("Copy", "cÖ_g Kwc");
                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("WarehouseAddress", sWarehouseAddress.ToString());
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanType", "Mushak-11(Ka)");
                    doc.SetParameterValue("VATRegistrationNo", Utility.VATRegistrationNo);
                    doc.SetParameterValue("Copy", "");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    //doc.SetParameterValue("Copy", "2nd Copy");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    //doc.SetParameterValue("Copy", "3rd Copy");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }

                    doc.SetParameterValue("VehicleNo", "");
                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    TPVATProducts oTPVATProducts = new TPVATProducts();
                    oTPVATProducts.GetCommentByDutyIDPOS(oDutyTran.DutyTranID, oDutyTran.WHID, (int)Dictionary.ChallanType.VAT_63);
                    string sSpProductCode = "";
                    string sSpComment = "";

                    foreach (TPVATProduct oTPVATProduct in oTPVATProducts)
                    {
                        if (sSpProductCode == "")
                        {
                            sSpProductCode = oTPVATProduct.ProductCode;
                        }
                        else
                        {
                            if (!sSpProductCode.Contains(oTPVATProduct.ProductCode))
                                sSpProductCode = sSpProductCode + "," + oTPVATProduct.ProductCode;
                        }

                        if (sSpComment == "")
                        {
                            sSpComment = oTPVATProduct.Comment;
                        }
                        else
                        {
                            if (!sSpComment.Contains(oTPVATProduct.Comment))
                                sSpComment = sSpComment + "," + oTPVATProduct.Comment;
                        }
                    }
                    
                    string sBarcode = "";
                    string sBENo = "";
                    bool IsVis = false;
                    if (Utility.CompanyInfo != "BLL")
                    {
                        DutyTran oChkIsVis = new DutyTran();
                        IsVis = oChkIsVis.CheckIsReadBENo(oDutyTran.DutyTranID);
                        if (IsVis)
                        {
                            sBarcode = InvoiceWiseBarcodeForVat(oSalesInvoice.InvoiceID);
                            sBENo = GetBENo(sBarcode);
                        }
                    }

                    DutyTran oIsVatExempted = new DutyTran();
                    if (oIsVatExempted.CheckVatExemptedTran(oDutyTran.DutyTranID, oDutyTran.WHID))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63_Exempted));
                        doc.SetDataSource(oDutyTran);

                        doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        doc.SetParameterValue("ChallanAddress", Utility.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;

                        if (oSI.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

                        if (Utility.CompanyInfo == "BLL")
                        {
                            doc.SetParameterValue("IsBLL", true);
                            doc.SetParameterValue("BENo", "");
                        }
                        else
                        {
                            doc.SetParameterValue("IsBLL", false);
                            if (IsVis)
                                doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                            else doc.SetParameterValue("BENo", "");
                        }
                        doc.SetParameterValue("Copy", "1st Copy");
                        //doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        frmPrintPreviewWithoutExport frmView;
                        frmView = new frmPrintPreviewWithoutExport();
                        frmView.ShowDialog(doc);
                    }
                    else
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63));
                        doc.SetDataSource(oDutyTran);

                        doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());

                        doc.SetParameterValue("ChallanAddress", Utility.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;
                        if (oSI.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

                        if (Utility.CompanyInfo == "BLL")
                        {
                            doc.SetParameterValue("IsBLL", true);
                            doc.SetParameterValue("BENo", "");
                        }
                        else
                        {
                            doc.SetParameterValue("IsBLL", false);
                            if (IsVis)
                                doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                            else doc.SetParameterValue("BENo", "");
                        }
                        doc.SetParameterValue("Copy", "1st Copy");

                        //doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");
                        frmPrintPreviewWithoutExport frmView;
                        frmView = new frmPrintPreviewWithoutExport();
                        frmView.ShowDialog(doc);
                    }

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_7)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVatReportMushak67));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("NationalID", _orptSalesInvoice.NationalID.ToString());
                    DutyTran oItemDetail = new DutyTran();
                    oItemDetail.GetRevVatData(Convert.ToInt32(_orptSalesInvoice.RefInvoiceID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("CustomerBINNo", _orptSalesInvoice.TaxNo.ToString());
                    //CustomerBINNo
                    doc.SetParameterValue("OldVatchalanNo", oItemDetail.DutyTranNo);
                    doc.SetParameterValue("OldDaliveryDate", oItemDetail.DutyTranDate.ToString("dd-MMM-yyyy"));


                    doc.SetParameterValue("WarehouseName", Utility.WarehouseName);
                    doc.SetParameterValue("BINNo", Utility.VATRegistrationNo);
                    doc.SetParameterValue("CRVatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ReturnRemarks", oItemDetail.Remarks);
                    doc.SetParameterValue("TotalVatAmount", _TotalVatAmount);
                    doc.SetParameterValue("Copy", "1st Copy");
                    //ReturnRemarks

                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }
            }

        }
        public void PrintVatChallanJuly20(SalesInvoice oSalesInvoice, int nType)
        {

            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshByInvoiceID();

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranIDPOSNew(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID, nType);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                double _TotalVatAmount = 0;
                rptSalesInvoice oSI = new rptSalesInvoice();
                oSI.GetInvoiceStatusByID(oSalesInvoice.InvoiceID);
                if (nType == (int)Dictionary.ChallanType.VAT_63)
                {
                    oDutyTran.GetVATReportPOSNewRT(oSI.InvoiceStatus);
                }
                //else
                //{
                //    _TotalVatAmount = oDutyTran.GetVATReportPOS(oSI.InvoiceStatus);
                //}

                
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    TPVATProducts oTPVATProducts = new TPVATProducts();
                    oTPVATProducts.GetCommentByDutyIDPOS(oDutyTran.DutyTranID, oDutyTran.WHID, (int)Dictionary.ChallanType.VAT_63);
                    string sSpProductCode = "";
                    string sSpComment = "";

                    foreach (TPVATProduct oTPVATProduct in oTPVATProducts)
                    {
                        if (sSpProductCode == "")
                        {
                            sSpProductCode = oTPVATProduct.ProductCode;
                        }
                        else
                        {
                            if (!sSpProductCode.Contains(oTPVATProduct.ProductCode))
                                sSpProductCode = sSpProductCode + "," + oTPVATProduct.ProductCode;
                        }

                        if (sSpComment == "")
                        {
                            sSpComment = oTPVATProduct.Comment;
                        }
                        else
                        {
                            if (!sSpComment.Contains(oTPVATProduct.Comment))
                                sSpComment = sSpComment + "," + oTPVATProduct.Comment;
                        }
                    }

                    string sBarcode = "";
                    string sBENo = "";
                    bool IsVis = false;
                    if (Utility.CompanyInfo != "BLL")
                    {
                        DutyTran oChkIsVis = new DutyTran();
                        IsVis = oChkIsVis.CheckIsReadBENo(oDutyTran.DutyTranID);
                        if (IsVis)
                        {
                            sBarcode = InvoiceWiseBarcodeForVat(oSalesInvoice.InvoiceID);
                            sBENo = GetBENo(sBarcode);
                        }
                    }

                    DutyTran oIsVatExempted = new DutyTran();
                    if (oIsVatExempted.CheckVatExemptedTran(oDutyTran.DutyTranID, oDutyTran.WHID))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63_Exempted));
                        doc.SetDataSource(oDutyTran);

                        doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        //SystemInfo oAddress = new SystemInfo();
                        //oAddress.RefreshForPOSNewRT(oDutyTran.DutyTranDate.Date);
                        doc.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", Utility.VATRegistrationNo);

                        doc.SetParameterValue("ChallanAddress", Utility.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;

                        if (oSI.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

                        if (Utility.CompanyInfo == "BLL")
                        {
                            doc.SetParameterValue("IsBLL", true);
                            doc.SetParameterValue("BENo", "");
                        }
                        else
                        {
                            doc.SetParameterValue("IsBLL", false);
                            if (IsVis)
                                doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                            else doc.SetParameterValue("BENo", "");
                        }
                        doc.SetParameterValue("Copy", "1st Copy");
                        //doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                        frmPrintPreviewWithoutExport frmView;
                        frmView = new frmPrintPreviewWithoutExport();
                        frmView.ShowDialog(doc);
                    }
                    else
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                        doc.SetDataSource(oDutyTran);
                        doc.SetParameterValue("RefJobNo", "");
                        doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        //SystemInfo oAddress = new SystemInfo();
                        //oAddress.RefreshForPOSNewRT(oDutyTran.DutyTranDate.Date);
                        doc.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", Utility.VATRegistrationNo);

                        doc.SetParameterValue("ChallanAddress", Utility.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;
                        if (oSI.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

                        if (Utility.CompanyInfo == "BLL")
                        {
                            doc.SetParameterValue("IsBLL", true);
                            doc.SetParameterValue("BENo", "");
                        }
                        else
                        {
                            doc.SetParameterValue("IsBLL", false);
                            if (IsVis)
                                doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                            else doc.SetParameterValue("BENo", "");
                        }
                        doc.SetParameterValue("Copy", "1st Copy");

                        //doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");


                        doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                        frmPrintPreviewWithoutExport frmView;
                        frmView = new frmPrintPreviewWithoutExport();
                        frmView.ShowDialog(doc);
                    }

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_7)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewVatReportMushak67));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("NationalID", _orptSalesInvoice.NationalID.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    //DutyTran oItemDetail = new DutyTran();
                    //oItemDetail.GetRevVatData(Convert.ToInt32(_orptSalesInvoice.RefInvoiceID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("CustomerBINNo", _orptSalesInvoice.TaxNo.ToString());
                    //CustomerBINNo
                    doc.SetParameterValue("OldVatchalanNo", "");
                    doc.SetParameterValue("OldDaliveryDate", "");

                    //SystemInfo oAddress = new SystemInfo();
                    //oAddress.RefreshForPOSNewRT(oDutyTran.DutyTranDate.Date);
                    doc.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                    doc.SetParameterValue("WarehouseAddress", Utility.WarehouseAddress);
                    doc.SetParameterValue("WarehouseName", Utility.WarehouseName);
                    doc.SetParameterValue("BINNo", Utility.VATRegistrationNo);
                    doc.SetParameterValue("CRVatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ReturnRemarks", "");
                    doc.SetParameterValue("TotalVatAmount", _TotalVatAmount);
                    doc.SetParameterValue("Copy", "1st Copy");
                    //ReturnRemarks

                    doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }
            }

        }

        public void PrintVatChallanThermal(SalesInvoice oSalesInvoice, int nType)
        {

            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshByInvoiceID();

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranIDPOSNew(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID, nType);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                double _TotalVatAmount = 0;
                rptSalesInvoice oSI = new rptSalesInvoice();
                oSI.GetInvoiceStatusByID(oSalesInvoice.InvoiceID);
                if (nType == (int)Dictionary.ChallanType.VAT_63)
                {
                    oDutyTran.GetVATReportPOSNewRT(oSI.InvoiceStatus);
                }


                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    TPVATProducts oTPVATProducts = new TPVATProducts();
                    oTPVATProducts.GetCommentByDutyIDPOS(oDutyTran.DutyTranID, oDutyTran.WHID, (int)Dictionary.ChallanType.VAT_63);
                    string sSpProductCode = "";
                    string sSpComment = "";

                    foreach (TPVATProduct oTPVATProduct in oTPVATProducts)
                    {
                        if (sSpProductCode == "")
                        {
                            sSpProductCode = oTPVATProduct.ProductCode;
                        }
                        else
                        {
                            if (!sSpProductCode.Contains(oTPVATProduct.ProductCode))
                                sSpProductCode = sSpProductCode + "," + oTPVATProduct.ProductCode;
                        }

                        if (sSpComment == "")
                        {
                            sSpComment = oTPVATProduct.Comment;
                        }
                        else
                        {
                            if (!sSpComment.Contains(oTPVATProduct.Comment))
                                sSpComment = sSpComment + "," + oTPVATProduct.Comment;
                        }
                    }

                    string sBarcode = "";
                    string sBENo = "";
                    bool IsVis = false;
                    if (Utility.CompanyInfo != "BLL")
                    {
                        DutyTran oChkIsVis = new DutyTran();
                        IsVis = oChkIsVis.CheckIsReadBENo(oDutyTran.DutyTranID);
                        if (IsVis)
                        {
                            sBarcode = InvoiceWiseBarcodeForVat(oSalesInvoice.InvoiceID);
                            sBENo = GetBENo(sBarcode);
                        }
                    }

                    DutyTran oIsVatExempted = new DutyTran();
                    if (oIsVatExempted.CheckVatExemptedTran(oDutyTran.DutyTranID, oDutyTran.WHID))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63_Exempted));
                        doc.SetDataSource(oDutyTran);

                        doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        doc.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", Utility.VATRegistrationNo);

                        doc.SetParameterValue("ChallanAddress", Utility.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;

                        if (oSI.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

                        if (Utility.CompanyInfo == "BLL")
                        {
                            doc.SetParameterValue("IsBLL", true);
                            doc.SetParameterValue("BENo", "");
                        }
                        else
                        {
                            doc.SetParameterValue("IsBLL", false);
                            if (IsVis)
                                doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                            else doc.SetParameterValue("BENo", "");
                        }
                        doc.SetParameterValue("Copy", "1st Copy");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                        frmPrintPreviewWithoutExport frmView;
                        frmView = new frmPrintPreviewWithoutExport();
                        frmView.ShowDialog(doc);
                    }
                    else
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63Thermal));
                        doc.SetDataSource(oDutyTran);
                        doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        //doc.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                        //doc.SetParameterValue("RegisteredpersonBIN", Utility.VATRegistrationNo);

                        doc.SetParameterValue("ChallanAddress", Utility.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;
                        if (oSI.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

                        if (Utility.CompanyInfo == "BLL")
                        {
                            doc.SetParameterValue("IsBLL", true);
                            doc.SetParameterValue("BENo", "");
                        }
                        else
                        {
                            doc.SetParameterValue("IsBLL", false);
                            if (IsVis)
                                doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                            else doc.SetParameterValue("BENo", "");
                        }
                        doc.SetParameterValue("Copy", "1st Copy");

                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                        frmPrintPreviewWithoutExport frmView;
                        frmView = new frmPrintPreviewWithoutExport();
                        frmView.ShowDialog(doc);
                    }

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_7)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewVatReportMushak67));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("NationalID", _orptSalesInvoice.NationalID.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    //DutyTran oItemDetail = new DutyTran();
                    //oItemDetail.GetRevVatData(Convert.ToInt32(_orptSalesInvoice.RefInvoiceID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("CustomerBINNo", _orptSalesInvoice.TaxNo.ToString());
                    //CustomerBINNo
                    doc.SetParameterValue("OldVatchalanNo", "");
                    doc.SetParameterValue("OldDaliveryDate", "");

                    //SystemInfo oAddress = new SystemInfo();
                    //oAddress.RefreshForPOSNewRT(oDutyTran.DutyTranDate.Date);
                    doc.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                    doc.SetParameterValue("WarehouseAddress", Utility.WarehouseAddress);
                    doc.SetParameterValue("WarehouseName", Utility.WarehouseName);
                    doc.SetParameterValue("BINNo", Utility.VATRegistrationNo);
                    doc.SetParameterValue("CRVatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ReturnRemarks", "");
                    doc.SetParameterValue("TotalVatAmount", _TotalVatAmount);
                    doc.SetParameterValue("Copy", "1st Copy");
                    //ReturnRemarks

                    doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }
            }

        }
        public void InvoiceWiseBarcode(long nInvoiceID)
        {
            SL = "";
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(nInvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {
                //IsSL = true;
                string PCode = "";

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {
                    //IsSL = false;
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
        public void PrintRetailInvoiceOld(long nInvoiceID, bool _bMakePDF)
        {
            _oRetailSalesInvoices = new RetailSalesInvoices();

            bool _bCreditCardVisible = false;
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            oDSCreditCard = new DSSalesInvoiceDetail();
            _oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            

            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                else if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    //oFreeGiftProductRow.Barcode = orptSalesInvoiceDetail.FreeProductBarcode;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }


            oRetailConsumer = new RetailConsumer();
            
            oRetailConsumer.RefreshForPOSRT(nInvoiceID);

            oRetailSalesInvoice = new RetailSalesInvoice();
            oRetailSalesInvoice.InvoiceID = nInvoiceID;
            oRetailSalesInvoice.RefreshInvoiceCharge();
            oRetailSalesInvoice.RefreshPaymentMode();
            oRetailSalesInvoice.RefreshSMSDiscoutn(orptSalesInvoice.InvoiceNo);
            //int nInvoiceID = 0;
            //int nInvoiceID = Convert.ToInt32(oRetailSalesInvoice.InvoiceID);


            //_oRetailSalesInvoices.RefreshCreditInfo(nInvoiceID);
            //int nCount = 0;
            //foreach (RetailSalesInvoice _oRetailSalesInvoice in _oRetailSalesInvoices)
            //{

            //    if (nCount == 0)
            //    {
            //        _bCreditCardVisible = true;
            //        nCount++;
            //    }

            //    DSSalesInvoiceDetail.CreditCardInfoRow oCreditCardInfoRow = oDSCreditCard.CreditCardInfo.NewCreditCardInfoRow();

            //    string sCardNo = "";

            //    if (_oRetailSalesInvoice.InstrumentNo != null)
            //    {
            //        sCardNo = _oRetailSalesInvoice.InstrumentNo;
            //    }
            //    else
            //    {
            //        sCardNo = "****************";
            //    }
            //    string subStr = sCardNo.Substring(sCardNo.Length - 4);
            //    subStr = "************" + subStr;
            //    oCreditCardInfoRow.BankName = _oRetailSalesInvoice.BankName;
            //    oCreditCardInfoRow.Amount = _oRetailSalesInvoice.Amount;
            //    oCreditCardInfoRow.CardType = _oRetailSalesInvoice.CardCategoryName;
            //    oCreditCardInfoRow.CardNo = sCardNo;
            //    oCreditCardInfoRow.IsEMI = _oRetailSalesInvoice.IsEMIName;
            //    oCreditCardInfoRow.InstallmentNo = _oRetailSalesInvoice.NoOfInstallment;
            //    oCreditCardInfoRow.POSMachine = _oRetailSalesInvoice.POSMachineName;

            //    oDSCreditCard.CreditCardInfo.AddCreditCardInfoRow(oCreditCardInfoRow);
            //    oDSCreditCard.AcceptChanges();

            //}

            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            // oDSSalesInvoiceDetail.Merge(oDSCreditCard);
            oDSSalesInvoiceDetail.AcceptChanges();

            rptRetailInvoice doc;
            doc = new rptRetailInvoice();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("IsVisibleCreditCard", _bCreditCardVisible);

            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("Address", Utility.WarehouseAddress + ", Outlet Phone No:" + Utility.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", Utility.WarehouseCellNo + ", e-mail:" + Utility.WarehouseEmail);
            doc.SetParameterValue("HC", Utility.HCMobileNo + ", e-mail:" + Utility.HCEmail);

            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);

            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");

            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");

            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailSalesInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailSalesInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailSalesInvoice.CheckSalesInvoice(Convert.ToString(nInvoiceID)))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailSalesInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + Utility.Shortcode + "]" + "-" + Utility.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);


            if (oRetailSalesInvoice.TotalDiscount != 0)
            {
                if (oRetailSalesInvoice.SPParcentage != 0)
                {
                    doc.SetParameterValue("IspercentDiscount?", true);
                }
                else
                {
                    doc.SetParameterValue("IspercentDiscount?", false);
                }
            }
            else
            {
                doc.SetParameterValue("IspercentDiscount?", false);
            }
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("SPDiscount", oRetailSalesInvoice.SPDiscount * -1);
                doc.SetParameterValue("SDiscount", oRetailSalesInvoice.TotalDiscount * -1);
                doc.SetParameterValue("Discount", orptSalesInvoice.Discount * -1);
                doc.SetParameterValue("smsDiscount", oRetailSalesInvoice.smsDiscount * -1);

                doc.SetParameterValue("FCharge", oRetailSalesInvoice.FreightCharge * -1);
                doc.SetParameterValue("ICharge", oRetailSalesInvoice.InstallationCharge * -1);
                doc.SetParameterValue("OCharge", oRetailSalesInvoice.OtherCharge * -1);
                doc.SetParameterValue("MCharge", oRetailSalesInvoice.MarkUpAmount * -1);
                doc.SetParameterValue("Charge", oRetailSalesInvoice.TotalCharge * -1);

                doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount * -1);
                doc.SetParameterValue("AmountInWord", _oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount * -1));

                doc.SetParameterValue("Cash", oRetailSalesInvoice.Cash * -1);
                doc.SetParameterValue("Credit", oRetailSalesInvoice.Credit * -1);
                doc.SetParameterValue("AdvanceAdjust", oRetailSalesInvoice.AdvanceAdjust * -1);
                doc.SetParameterValue("OthersPayment", oRetailSalesInvoice.Others * -1);
                doc.SetParameterValue("Payment", oRetailSalesInvoice.TotalAmount * -1);
            }
            else
            {
                doc.SetParameterValue("SPDiscount", oRetailSalesInvoice.SPDiscount);
                doc.SetParameterValue("SDiscount", oRetailSalesInvoice.TotalDiscount);
                doc.SetParameterValue("Discount", orptSalesInvoice.Discount);
                doc.SetParameterValue("smsDiscount", oRetailSalesInvoice.smsDiscount);

                doc.SetParameterValue("FCharge", oRetailSalesInvoice.FreightCharge);
                doc.SetParameterValue("ICharge", oRetailSalesInvoice.InstallationCharge);
                doc.SetParameterValue("OCharge", oRetailSalesInvoice.OtherCharge);
                doc.SetParameterValue("MCharge", oRetailSalesInvoice.MarkUpAmount);
                doc.SetParameterValue("Charge", oRetailSalesInvoice.TotalCharge);

                doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
                doc.SetParameterValue("AmountInWord", _oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

                doc.SetParameterValue("Cash", oRetailSalesInvoice.Cash);
                doc.SetParameterValue("Credit", oRetailSalesInvoice.Credit);
                doc.SetParameterValue("AdvanceAdjust", oRetailSalesInvoice.AdvanceAdjust);
                doc.SetParameterValue("OthersPayment", oRetailSalesInvoice.Others);
                doc.SetParameterValue("Payment", oRetailSalesInvoice.TotalAmount);
            }
            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }
            //if (sBarcode != null)
            //    doc.SetParameterValue("Barcode", sBarcode);
            //else doc.SetParameterValue("Barcode", "NA");

            doc.SetParameterValue("Barcode", SL);
            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            if (oRetailConsumer.CheckCLPConsumer())
            {
                doc.SetParameterValue("IsCLP", false);
                doc.SetParameterValue("PBalance", 0);
                doc.SetParameterValue("RBalance", 0);
                doc.SetParameterValue("CBalance", 0);
            }

            else
            {
                doc.SetParameterValue("IsCLP", true);
                oCLPTran = new CLPTran();
                oCLPTran.ConsumerID = (int)orptSalesInvoice.SundryCustomerID;
                oCLPTran.CustomerID = orptSalesInvoice.CustomerID;
                oCLPTran.Refresh();

                doc.SetParameterValue("PBalance", oCLPTran.PreviousPoint);
                doc.SetParameterValue("RBalance", oCLPTran.CurrentPoint - oCLPTran.PreviousPoint);
                doc.SetParameterValue("CBalance", oCLPTran.CurrentPoint);
            }
            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", "|" + oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString() + "");
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }

            if (_bMakePDF == true)
            {
                Outgoing _oOutgoing = new Outgoing();
                _oOutgoing.CreateInvoicePath();
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + orptSalesInvoice.InvoiceNo + ".pdf");
            }
            else
            {
                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                //frmPrintPreview frmView;
                //frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
        }
        public void PrintRetailInvoice(long nInvoiceID, bool _bMakePDF)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            _oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();

            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.RefreshForPOSRT(nInvoiceID);

            rptPOSInvoice doc;
            doc = new rptPOSInvoice();
            doc.SetDataSource(oDSSalesInvoiceDetail);

            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("Address", Utility.WarehouseAddress);
            doc.SetParameterValue("Mobile", Utility.WarehouseCellNo + ", e-mail:" + Utility.WarehouseEmail);
            doc.SetParameterValue("HC", Utility.HCMobileNo + ", e-mail:" + Utility.HCEmail);
            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");
            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address + ' ' + orptSalesInvoice.ThanaName);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("Email", oRetailConsumer.Email);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            RetailSalesInvoice oRetailInvoice = new RetailSalesInvoice();
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailInvoice.CheckSalesInvoice(nInvoiceID.ToString()))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }

            //doc.SetParameterValue("RefInvoice", "");
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", Utility.WarehouseName + "-" + "[" + Utility.Shortcode + "]");
            doc.SetParameterValue("DeliveryW/H", orptSalesInvoice.WarehouseName);

            RetailSalesInvoices oRetailDiscounCharges = new RetailSalesInvoices();
            oRetailDiscounCharges.GetRetailInvoiceDiscountCharge(nInvoiceID);
            string sCharge = "";
            string sDiscount = "";
            double _TotalDiscount = 0;
            double _TotalCharge = 0;
            foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailDiscounCharges)
            {
                if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Charge)
                {
                    if (sCharge == "")
                    {
                        sCharge = oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sCharge = sCharge + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalCharge = _TotalCharge + oRetailSalesInvoice.Amount;

                }
                else if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Discount)
                {
                    if (sDiscount == "")
                    {
                        sDiscount = oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sDiscount = sDiscount + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalDiscount = _TotalDiscount + oRetailSalesInvoice.Amount;
                }

            }
            doc.SetParameterValue("ChargeDetail", sCharge.ToString());
            doc.SetParameterValue("DiscountDetail", sDiscount.ToString());
            doc.SetParameterValue("TotalCharge", _oTELLib.TakaFormat(_TotalCharge));
            doc.SetParameterValue("TotalDiscount", _oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", _oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentByInvoice(nInvoiceID);
            string sPaymentDetail = "";
            double _TotalPayment = 0;
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                if (sPaymentDetail == "")
                {
                    sPaymentDetail = oPaymentMode.PaymentModeName + ':' + _oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                else
                {
                    sPaymentDetail = sPaymentDetail + ' ' + '|' + ' ' + oPaymentMode.PaymentModeName + ':' + _oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                _TotalPayment = _TotalPayment + oPaymentMode.Amount;

            }

            doc.SetParameterValue("PaymentModeDetail", sPaymentDetail.ToString());
            doc.SetParameterValue("TotalPayment", _oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.EmployeeDetail);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }



            PaymentModes oEMI = new PaymentModes();
            oEMI.GetEMiDetail(nInvoiceID);
            string sEMIDetail = "";
            foreach (PaymentMode oPaymentMode in oEMI)
            {
                if (sEMIDetail == "")
                {
                    sEMIDetail = oPaymentMode.EMIDetail;
                }
                else
                {
                    sEMIDetail = sEMIDetail + '\n' + oPaymentMode.EMIDetail;
                }
            }

            doc.SetParameterValue("EMIDetail", sEMIDetail.ToString());

            if (_bMakePDF == true)
            {
                Outgoing _oOutgoing = new Outgoing();
                _oOutgoing.CreateInvoicePath();
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + orptSalesInvoice.InvoiceNo + ".pdf");
            }
            else
            {
                //frmPrintPreviewWithoutExport frmView;
                //frmView = new frmPrintPreviewWithoutExport();

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
        }

        public void PrintRetailDeliveryChallan(long nInvoiceID, bool _bMakePDF)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            _oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();

            oRetailConsumer = new RetailConsumer();

            oRetailConsumer.RefreshForPOSRT(nInvoiceID);

            //rptRetailInvoiceNew doc;
            //doc = new rptRetailInvoiceNew();
            rptRetailDeliveryChallan doc;
            doc = new rptRetailDeliveryChallan();
            doc.SetDataSource(oDSSalesInvoiceDetail);

            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("Address", Utility.WarehouseAddress + ", Outlet Phone No:" + Utility.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", Utility.WarehouseCellNo + ", e-mail:" + Utility.WarehouseEmail);
            doc.SetParameterValue("HC", Utility.HCMobileNo + ", e-mail:" + Utility.HCEmail);
            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");
            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address + ' ' + orptSalesInvoice.ThanaName);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("Email", oRetailConsumer.Email);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");

            //doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            RetailSalesInvoice oRetailInvoice = new RetailSalesInvoice();
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailInvoice.CheckSalesInvoice(nInvoiceID.ToString()))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }

            //doc.SetParameterValue("RefInvoice", "");
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + Utility.Shortcode + "]" + "-" + Utility.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            RetailSalesInvoices oRetailDiscounCharges = new RetailSalesInvoices();
            oRetailDiscounCharges.GetRetailInvoiceDiscountCharge(nInvoiceID);
            string sCharge = "";
            string sDiscount = "";
            double _TotalDiscount = 0;
            double _TotalCharge = 0;
            foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailDiscounCharges)
            {
                if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Charge)
                {
                    if (sCharge == "")
                    {
                        sCharge = oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sCharge = sCharge + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalCharge = _TotalCharge + oRetailSalesInvoice.Amount;

                }
                else if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Discount)
                {
                    if (sDiscount == "")
                    {
                        sDiscount = oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sDiscount = sDiscount + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + _oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalDiscount = _TotalDiscount + oRetailSalesInvoice.Amount;
                }

            }
            doc.SetParameterValue("ChargeDetail", sCharge.ToString());
            doc.SetParameterValue("DiscountDetail", sDiscount.ToString());
            doc.SetParameterValue("TotalCharge", _oTELLib.TakaFormat(_TotalCharge));
            doc.SetParameterValue("TotalDiscount", _oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", _oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentByInvoice(nInvoiceID);
            string sPaymentDetail = "";
            double _TotalPayment = 0;
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                if (sPaymentDetail == "")
                {
                    sPaymentDetail = oPaymentMode.PaymentModeName + ':' + _oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                else
                {
                    sPaymentDetail = sPaymentDetail + ' ' + '|' + ' ' + oPaymentMode.PaymentModeName + ':' + _oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                _TotalPayment = _TotalPayment + oPaymentMode.Amount;

            }

            doc.SetParameterValue("PaymentModeDetail", sPaymentDetail.ToString());
            doc.SetParameterValue("TotalPayment", _oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }



            PaymentModes oEMI = new PaymentModes();
            oEMI.GetEMiDetail(nInvoiceID);
            string sEMIDetail = "";
            foreach (PaymentMode oPaymentMode in oEMI)
            {
                if (sEMIDetail == "")
                {
                    sEMIDetail = oPaymentMode.EMIDetail;
                }
                else
                {
                    sEMIDetail = sEMIDetail + '\n' + oPaymentMode.EMIDetail;
                }
            }

            doc.SetParameterValue("EMIDetail", sEMIDetail.ToString());

            if (_bMakePDF == true)
            {
                Outgoing _oOutgoing = new Outgoing();
                _oOutgoing.CreateInvoicePath();
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + orptSalesInvoice.InvoiceNo + ".pdf");
            }
            else
            {
                //frmPrintPreviewWithoutExport frmView;
                //frmView = new frmPrintPreviewWithoutExport();

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
        }
        public string PrintWarrantyCardForBulk(int nProductID, string sWarrantyCardNo, string sBarcode, SalesInvoice _oSalesInvoice, int nWarrantyParamID, bool _bMakePDF,string sExtendedWarrantyDescription)
        {
            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();
            WarrantyParam oWarrantyParam = new WarrantyParam();
            //if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            if (oWarrantyParam.GetWarrantyParamByID(nWarrantyParamID))
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.RefreshForPOSRT(_oSalesInvoice.InvoiceID);

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();
                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();
                doc.SetDataSource(oDSQRCode);
                doc.SetParameterValue("WarrantyCardNo", sWarrantyCardNo);
                if (sExtendedWarrantyDescription != "")
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended Warranty: " + sExtendedWarrantyDescription);
                }
                else
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended warranty not applicable");
                }

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }

                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + Utility.Shortcode + "]" + "-" + Utility.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }

                if (_bMakePDF == true)
                {
                    Outgoing _oOutgoing = new Outgoing();
                    _oOutgoing.CreateInvoicePath();
                    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + sWarrantyCardNo + ".pdf");
                }
                else
                {
                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();

                    //frmPrintPreview frmView;
                    //frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }

            return sWarrantyCardNo;
        }

        public string PrintWarrantyCardForBulkThermal(int nProductID, string sWarrantyCardNo, string sBarcode, SalesInvoice _oSalesInvoice, int nWarrantyParamID, bool _bMakePDF, string sExtendedWarrantyDescription)
        {
            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();
            WarrantyParam oWarrantyParam = new WarrantyParam();
            //if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            if (oWarrantyParam.GetWarrantyParamByID(nWarrantyParamID))
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.RefreshForPOSRT(_oSalesInvoice.InvoiceID);

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();
                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCardThermal doc;
                doc = new rptWarrantyCardThermal();
                doc.SetDataSource(oDSQRCode);
                doc.SetParameterValue("WarrantyCardNo", sWarrantyCardNo);
                if (sExtendedWarrantyDescription != "")
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended Warranty: " + sExtendedWarrantyDescription);
                }
                else
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended warranty not applicable");
                }

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }

                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + Utility.Shortcode + "]" + "-" + Utility.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }

                if (_bMakePDF == true)
                {
                    Outgoing _oOutgoing = new Outgoing();
                    _oOutgoing.CreateInvoicePath();
                    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + sWarrantyCardNo + ".pdf");
                }
                else
                {
                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();

                    //frmPrintPreview frmView;
                    //frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }

            return sWarrantyCardNo;
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

        private void btnReverseInvoice_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            if (_SalesInvoice.InvoiceStatus != (int)Dictionary.InvoiceStatus.DELIVERED)
            {
                MessageBox.Show("Only Delivered Invoice should reversed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmRetailInvoiceReverse oForm = new frmRetailInvoiceReverse();
            oForm.ShowDialog(_SalesInvoice);
            this.Cursor = Cursors.WaitCursor;
            RefreshData();
            this.Cursor = Cursors.Default;
        }

        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, SalesInvoice _oSalesInvoice, string sBarcode, string sProductCode, string sProductName)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                String data = oRetailConsumer.ConsumerCode +
                "\n" + _oSalesInvoice.InvoiceNo +
                "\n" + _oSalesInvoice.InvoiceDate.ToString();
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + "" +
                     "\n" + "" +
                     "\n" + "" +
                     "\n" + "";
                }
                else
                {
                    data = data + "\n" + oRetailConsumer.ConsumerName +
                    "\n" + oRetailConsumer.Address +
                    "\n" + oRetailConsumer.CellNo +
                    "\n" + oRetailConsumer.Email;
                }
                data = data + "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + oRetailConsumer.ParentCustomerID;
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + Convert.ToString(Utility.DealerChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2B || oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2C)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDCorporateChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.HPA)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDHPAChannelID);
                }
                else
                {
                    data = data + "\n" + Convert.ToString(Utility.RetailChannelID);
                }
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void btnGenerateWC_Click(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            int nCount = 0;
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            if (_SalesInvoice.InvoiceStatus != (int)Dictionary.InvoiceStatus.DELIVERED)
            {
                MessageBox.Show("Only Delivered Invoice Can Generate Warranty Card", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("Only Delivered Invoice Can Generate Warranty Card", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult oResult = MessageBox.Show("Are you sure you want to Generate Warranty Card? The Invoice#" + _SalesInvoice.InvoiceNo + " ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                SalesInvoice oSalesInvoice = new SalesInvoice();
                oSalesInvoice.InvoiceID = _SalesInvoice.InvoiceID;
                oSalesInvoice.RefreshSalesInvoiceItem();

                foreach (SalesInvoiceItem oItem in oSalesInvoice)
                {


                    WarrantyParameter oWarrantyParameter = new WarrantyParameter();
                    if (oWarrantyParameter.CheckWarrantyCard(_SalesInvoice.InvoiceID, oItem.ProductID))
                    {

                    }
                    else
                    {

                        WarrantyParam oWarrantyParam = new WarrantyParam();
                        if (oWarrantyParam.GetWarranty(oItem.ProductID, Convert.ToDateTime(_SalesInvoice.InvoiceDate)))
                        {
                            SalesInvoiceProductSerials oSIPSs = new SalesInvoiceProductSerials();
                            oSIPSs.GetBarcodeByInvoiceNProduct(_SalesInvoice.InvoiceID, oItem.ProductID);
                            foreach (SalesInvoiceProductSerial oSIPS in oSIPSs)
                            {
                                //oWarrantyParameter.GetNextWarrantyCardNo(Convert.ToInt32(_SalesInvoice.InvoiceID), _SalesInvoice.WarehouseID, oItem.ProductID, oWarrantyParam.WarrantyParamID, oSIPS.ProductSerialNo);


                                ConsumerPromotionEngine oWarrantyPromo = new ConsumerPromotionEngine();
                                string sExtendedWarranty = oWarrantyPromo.GetWarrantyPromo(Convert.ToDateTime(_SalesInvoice.InvoiceDate), oItem.ProductID);
                                oWarrantyParameter.InsertSalesInvoiceWarrantyCard(Convert.ToInt32(_SalesInvoice.InvoiceID), _SalesInvoice.WarehouseID, oItem.ProductID, oWarrantyParam.WarrantyParamID, oSIPS.ProductSerialNo, sExtendedWarranty, oWarrantyPromo.WarrantyID);

                                nCount++;
                               
                            }

                        }

                    }

                }
                this.Cursor = Cursors.Default;
                if (nCount > 0)
                {
                    MessageBox.Show("Successfully Generated #of Warranty Card: " + nCount.ToString() + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There is no Generated Item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefreshData();

            }


        }


        private void lvwInvoice_Click(object sender, EventArgs e)
        {
            if (_nUIContorl == 0)
            {
                SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
                InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                oInvoiceReverse.GetApprovedInvoice(oSalesInvoice.InvoiceNo);
                if (oInvoiceReverse.Count > 0)
                {
                    btnReverseInvoice.Enabled = true;
                }
                else
                {
                    btnReverseInvoice.Enabled = false;
                }
            }

        }

        private void lvwInvoice_KeyUp(object sender, KeyEventArgs e)
        {
            if (_nUIContorl == 0)
            {
                SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
                InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                oInvoiceReverse.GetApprovedInvoice(oSalesInvoice.InvoiceNo);
                if (oInvoiceReverse.Count > 0)
                {
                    btnReverseInvoice.Enabled = true;
                }
                else
                {
                    btnReverseInvoice.Enabled = false;
                }
            }
        }



        private string GetBENo(string sProductSerialNo)
        {
            string sBIENo = "";
            string sBINNo = "";
            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            sBINNo = _oSalesInvoiceProductSerials.GETBENoByBarcodeRT(sProductSerialNo);


            return sBIENo;
        }


        public string InvoiceWiseBarcodeForVat(long nInvoiceID)
        {
            SL = "";
            string PCode = "";

            _oSIPSs = new SalesInvoiceProductSerials();
            _oSIPSs.GETSerialByInvoiceID(nInvoiceID);

            foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
            {
                if (SL == "")
                {
                    SL = "'" + SIPSs.ProductSerialNo + "'";
                }
                else
                {
                    SL = SL + "," + "'" + SIPSs.ProductSerialNo + "'";
                }

            }
            return SL;

        }

        private void btnVat63Print_Click(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();

            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.ChallanType.VAT_63, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);


            SystemInfo oIsVatActive = new SystemInfo();
            oIsVatActive.NewVatActive();

            if (oIsVatActive.IsNewVat == 1 && Convert.ToDateTime(_oTELLib.ServerDateTime()).Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
            {
                PrintVatChallanJuly20(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_63);
            }
            else
            {
                PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_63);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnSendeMail_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
         
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed\nYou couldn't send Email ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(_SalesInvoice.InvoiceID));
            
            //make PDF Invoice

            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(_SalesInvoice.InvoiceID))
            {
                PrintRetailInvoice(_SalesInvoice.InvoiceID, true);
            }
            else
            {
                PrintRetailInvoiceOld(_SalesInvoice.InvoiceID, true);
            }
            
            //Make Warranty Card PDF
            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulk(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, _SalesInvoice, oWP.WarrantyParameterID, true, oWP.ExtendedWarrantyDescription);
            }
            _oOutgoing = new Outgoing();
            if (_oOutgoing.SendTDSalesEmail(_SalesInvoice.ConsumerName, Convert.ToInt32(_SalesInvoice.InvoiceID), _SalesInvoice.InvoiceNo, Convert.ToDateTime(_SalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"), _SalesInvoice.Email, _SalesInvoice.IsVerifiedEmail))
            {
                MessageBox.Show("Email Send Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error sending email!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
       
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed\nYou couldn't Send SMS ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            _oOutgoing = new Outgoing();
            if (_oOutgoing.SendTDSalesSMS(_SalesInvoice.MobileNo, _SalesInvoice.InvoiceNo, _SalesInvoice.Email, _SalesInvoice.IsVerifiedEmail))
            {
                MessageBox.Show("SMS Send Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error sending SMS!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnVat67Print_Click(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();

            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.DutyAccountNew.MUSHAK_6_7, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            SystemInfo oIsVatActive = new SystemInfo();
            oIsVatActive.NewVatActive();

            if (oIsVatActive.IsNewVat == 1 && Convert.ToDateTime(_oTELLib.ServerDateTime()).Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
            {
                PrintVatChallanJuly20(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
            }
            else
            {
                PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
            }

            //PrintVatChallanJuly20(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
            this.Cursor = Cursors.Default;
        }

        private void btnPrintDeliveryChallan_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            InvoiceWiseBarcode(_SalesInvoice.InvoiceID);
            long nInvoiceID = 0;
            if (_SalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                nInvoiceID = Convert.ToInt32(_SalesInvoice.RefInvoiceID);
            }
            else
            {
                nInvoiceID = _SalesInvoice.InvoiceID;
            }
            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(nInvoiceID))
            {
                PrintRetailDeliveryChallan(_SalesInvoice.InvoiceID, false);
            }
            else
            {
                //PrintRetailInvoiceOld(_SalesInvoice.InvoiceID, false);
            }
            this.Cursor = Cursors.Default;
        }


        private void btnMushak63Thermal_Click(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();

            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.ChallanType.VAT_63, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);



            PrintVatChallanThermal(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_63);

        }

        private void btnWarrantyCardThermal_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
            oWarrantyParameter = new WarrantyParameter();
            if (oWarrantyParameter.CheckWarrantyCard(Convert.ToInt32(_SalesInvoice.InvoiceID)))
            {

            }
            else
            {
                MessageBox.Show("There is no warranty card in the invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed\nYou couldn't Print/Re-Print Warranty Card ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(_SalesInvoice.InvoiceID));

            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulkThermal(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, _SalesInvoice, oWP.WarrantyParameterID, false, oWP.ExtendedWarrantyDescription);
            }
            this.Cursor = Cursors.Default;
        }
    }
}