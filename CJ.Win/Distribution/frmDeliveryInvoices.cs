using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Class.Distribution;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Report;
using CJ.Class.Duty;
using CJ.Win.Security;
using CJ.Class.Web.UI.Class;
using CJ.Win.Claim;
using CJ.Class.POS;
using CJ.Win.Inventory;
using CJ.Report.POS;

namespace CJ.Win.Distribution
{
    public partial class frmDeliveryInvoices : Form
    {
        SalesInvoiceDetails oSalesInvoiceDetails;
        SalesInvoice _oSalesInvoice;
        Utilities _oUtilitys;
        rptSalesInvoice _orptSalesInvoice;
        StockTran _oStockTran;
        ProductStock _oProductStock;
        TELLib oTELLib;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        ProductDetail _oProductDetail;
        DutyAccount oDutyAccount;
        Warehouse oWarehouse;
        DutyTranList oDutyTranList;
        TELLib oLib;
        EMICalculationDetail _oEMICalculationDetail;
        EPSSalesOrder oEPSSalesOrder;
        Product oProduct;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        SalesInvoiceProductSerials _oSIPSs;
        SystemInfo _oSystemInfo;
        DSOrderItem oDSOrderItem;
        DSOrderItem oDSFreeQty;
        string sProduct = "";
        string SL = "";
        int CustInfo = 0;
        bool IsSL = true;
        private double _NewDutyBalance = 0;
        private DutyTran oDutyTranVAT63;
        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;
        int[] ProductIDList ={ 9, 1823, 2810, 2935, 2936, 2937 };

        int nFromParentWarehouse;
        int nToParentWarehouse;
        int _nUIControl = 0;
        bool IsTrue = false;
        //public static List<SalesInvoiceInfo> localList = new List<SalesInvoiceInfo>();
        public frmDeliveryInvoices(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void frmDeliveryInvoices_Load(object sender, EventArgs e)
        {
            if (Utility.CompanyInfo == "TML")
            {
                btnBarcode.Text = "IMEI";
            }
            else
            {
                btnBarcode.Text = "Barcode";
            }
            _oUtilitys = new Utilities();
            cmbInvoiceStatus.Items.Clear();
            _oUtilitys.GetInvoiceStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                cmbInvoiceStatus.Items.Add(oUtility.Satus);
            }
            cmbInvoiceStatus.SelectedIndex = cmbInvoiceStatus.Items.Count - 1;
            RefreshData();
            updateSecurity();

            if (_nUIControl == 1)
            {
                btClaimInvoice.Visible = false;
                btMakeInvoice.Visible = false;
                btViewInvoice.Visible = false;

                btProcessDelivery.Visible = true;
                btDeliveryNote.Visible = true;
                btnDelivery.Visible = true;
                btPrintInvoice.Visible = true;
                btPrintVAT.Visible = true;
                //btPrintVAT.Visible = false;
                btnBarcode.Visible = true;
                btnWarrantyCard.Visible = true;
                btnWarrantyCardAuto.Visible = true;
                btnCreditNote.Visible = true;
            }
            if (_nUIControl == 2)
            {
                btClaimInvoice.Visible = false;
                btMakeInvoice.Visible = true;
                btViewInvoice.Visible = true;

                btProcessDelivery.Visible = false;
                btDeliveryNote.Visible = false;
                btnDelivery.Visible = false;
                btPrintInvoice.Visible = false;
                btPrintVAT.Visible = false;
                btnBarcode.Visible = false;
                btnWarrantyCard.Visible = false;
                btnWarrantyCardAuto.Visible = false;
            }
            if (_nUIControl == 3)
            {
                btClaimInvoice.Visible = true;
                btMakeInvoice.Visible = false;
                btViewInvoice.Visible = false;

                btProcessDelivery.Visible = false;
                btDeliveryNote.Visible = false;
                btnDelivery.Visible = false;
                btPrintInvoice.Visible = false;
                
                btPrintVAT.Visible = false;
                btnBarcode.Visible = false;
                btnWarrantyCard.Visible = false;
                btnWarrantyCardAuto.Visible = false;
            }
        }
        public void RefreshData()
        {
            DBController.Instance.OpenNewConnection();
            oSalesInvoiceDetails = new SalesInvoiceDetails();
            //if (_nUIControl == 1)
            //    localList = oSalesInvoiceDetails.Refresh(dtFromDate.Value.Date, dtpToDate.Value.Date, false);
            //else localList = oSalesInvoiceDetails.Refresh(dtFromDate.Value.Date, dtpToDate.Value.Date, true);

            if (_nUIControl == 1)
                oSalesInvoiceDetails.Refresh(dtFromDate.Value.Date, dtpToDate.Value.Date, false);
            else oSalesInvoiceDetails.Refresh(dtFromDate.Value.Date, dtpToDate.Value.Date, true);

            FillRecord(oSalesInvoiceDetails);

        }
        public void FillRecord(SalesInvoiceDetails oSalesInvoiceDetails)
        {
            lvwOrderList.Items.Clear();
            foreach (SalesInvoiceInfo oSalesInvoiceInfo in oSalesInvoiceDetails)
            {
                ListViewItem lstItem = lvwOrderList.Items.Add(oSalesInvoiceInfo.InvoiceNo);

                if (oSalesInvoiceInfo.OrderID != 0)
                {
                    lstItem.SubItems.Add(oSalesInvoiceInfo.OrderNo.ToString());
                }
                else
                {
                    lstItem.SubItems.Add(oSalesInvoiceInfo.SalesInvoice.RefDetails);

                }
                lstItem.SubItems.Add(oSalesInvoiceInfo.CustomerCode);
                lstItem.SubItems.Add(oSalesInvoiceInfo.CustomerName);
                lstItem.SubItems.Add(Convert.ToDateTime(oSalesInvoiceInfo.InvoiceDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oSalesInvoiceInfo.InvoiceAmount.ToString());
                lstItem.SubItems.Add(oSalesInvoiceInfo.InvoiceByName);
                lstItem.SubItems.Add(oSalesInvoiceInfo.DeliveredByName);
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.InvoiceStatus), oSalesInvoiceInfo.InvoiceStatus));

                if (oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    lstItem.BackColor = Color.FromArgb(255, 255, 255);
                }
                else if (oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED)
                {
                    lstItem.BackColor = Color.FromArgb(192, 192, 255);
                }
                else if (oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
                {
                    lstItem.BackColor = Color.FromArgb(192, 255, 255);
                }
                else if (oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.PENDING)
                {
                    lstItem.BackColor = Color.FromArgb(255, 255, 192);
                }
                else if (oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.CANCEL)
                {
                    lstItem.BackColor = Color.FromArgb(255, 192, 192);
                }
                else
                {
                    lstItem.BackColor = Color.FromArgb(128, 255, 128);
                }
                lstItem.Tag = oSalesInvoiceInfo;

                this.Text = "Total Invoice  " + "[" + oSalesInvoiceDetails.Count + "]";
                //setListViewRowColour();

            }
        }
        private void setListViewRowColour()
        {
            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[8].Text == Dictionary.InvoiceStatus.DELIVERED.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    else if (oItem.SubItems[8].Text == Dictionary.InvoiceStatus.UNDELIVERED.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 192, 255);
                    }
                    else if (oItem.SubItems[8].Text == Dictionary.InvoiceStatus.PROCESSING_DELIVERY.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 255);
                    }
                    else if (oItem.SubItems[8].Text == Dictionary.InvoiceStatus.PENDING.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    else if (oItem.SubItems[8].Text == Dictionary.InvoiceStatus.CANCEL.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    else
                    {
                        oItem.BackColor = Color.FromArgb(128, 255, 128);
                    }
                }
            }
        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RefreshData();
            this.Cursor = Cursors.Default;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            filterRecord();
            this.Cursor = Cursors.Default;
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            DeliveryInvoice();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput(SalesInvoice oSalesInvoice)
        {
            #region Confirm Qty
            CustomerDetail oChkDetail = new CustomerDetail();
            oChkDetail.CustomerID = oSalesInvoice.CustomerID;
            oChkDetail.refresh();
            int nWHID = oSalesInvoice.WarehouseID;
            foreach (SalesInvoiceItem oChkItem in oSalesInvoice)
            {
                WUIUtility _oWUIUtility = new WUIUtility();
                _oWUIUtility.GetCurrentStock(oChkDetail.ChannelID, nWHID, oChkItem.ProductID);
                if (oChkItem.Quantity > Convert.ToInt32(_oWUIUtility.OpennigStock))
                {
                    MessageBox.Show("Insufficient Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
            }
            #endregion
            return true;
        }
        public DutyTran GetDataForVAT63(DutyTran oDutyTranVAT63)
        {
            oDutyTranVAT63 = new DutyTran();

            DateTime day = Convert.ToDateTime(DateTime.Now.Date);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT63.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT63.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
            oDutyTranVAT63.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT63.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT63.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT63.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT63.DutyAccountID = 3;

            DutyAccounts oDetail = new DutyAccounts();
            oDetail.GetDutyDetailNew("Invoice", Convert.ToInt32(_oSalesInvoice.InvoiceID));

            foreach (DutyAccount oItem in oDetail)
            {

                DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                oDutyTranDetail.ProductID = oItem.ProductID;
                oDutyTranDetail.Qty = oItem.Qty;

                // Old Code

                

                if (Utility.CompanyInfo == "BLL")
                {
                    // Old Code
                    //    oDutyTranDetail.DutyPrice = oItem.TPFromPrice;
                    //    oDutyTranDetail.VAT = (oItem.TPFromPrice * oItem.DutyRate) * oItem.Qty;

                    // New Code by Humayun

                    oDutyTranDetail.DutyPrice = oItem.TradePrice;
                    oDutyTranDetail.VAT = (oItem.TradePrice * oItem.DutyRate) * oItem.Qty;
                }               

                else
                {
                    oDutyTranDetail.DutyPrice = oItem.DutyPriceForRetail;
                    oDutyTranDetail.VAT = (oItem.DutyPriceForRetail * oItem.DutyRate) * oItem.Qty;
                }
                oDutyTranDetail.DutyRate = oItem.DutyRate;
                oDutyTranDetail.WHID = _oSalesInvoice.WarehouseID;
                oDutyTranDetail.UnitPrice = oItem.UnitPrice;
                //oDutyTranDetail.VAT = (oItem.DutyPriceForRetail * oItem.DutyRate) * oItem.Qty;
                oDutyTranDetail.VATType = oItem.VATType;
                _NewDutyBalance = _NewDutyBalance + oDutyTranDetail.VAT;
                oDutyTranVAT63.Add(oDutyTranDetail);


            }
            oDutyTranVAT63.Amount = _NewDutyBalance;

            return oDutyTranVAT63;
        }
        private void NewVat()
        {
            SystemInfo oIsVatActive = new SystemInfo();
            oIsVatActive.NewVatActive();

            if (oIsVatActive.IsNewVat == 1 && DateTime.Now.Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
            {
                oDutyTranVAT63 = GetDataForVAT63(oDutyTranVAT63);
                if (oDutyTranVAT63.Count > 0)
                {
                    if (oDutyTranVAT63.Amount > 0)
                    {
                        oDutyTranVAT63.Remarks = _oSalesInvoice.Remarks;
                        //oDutyTranVAT63.InsertForPOSNew(oSystemInfo.WarehouseCode);
                        oDutyTranVAT63.InsertNewHOVAT();
                    }
                }
                oDutyAccount = new DutyAccount();
                oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccount.MUSHAK_6_3;
                oDutyAccount.Balance = _NewDutyBalance;
                //oDutyAccount.UpdateBalanceForPOS(true);
                oDutyAccount.UpdateBalance(true);
            }
        }
        public void DeliveryInvoice()
        {

            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
            if (validateUIInput(_oSalesInvoice))
            {
                _oStockTran = new StockTran();
                _oProductStock = new ProductStock();
                _oStockTran = SetData(_oStockTran);

                if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
                {
                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
                    if (Utility.CompanyInfo == "TEL")
                    {
                        _oSalesInvoiceProductSerial.MatchProduct();
                    }
                    else
                    {

                    }

                    if (_oSalesInvoiceProductSerial.MatchProductQty == 0)
                    {
                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            _oSalesInvoice.UserID = Utility.UserId;
                            _oSalesInvoice.UpadteInvoiceForDelivery((short)Dictionary.InvoiceStatus.DELIVERED);
                            _oStockTran.UserID = Utility.UserId;
                            _oStockTran.Add();

                            if (_oStockTran.CheckTranNo() == false)
                            {
                                DBController.Instance.RollbackTransaction();
                                MessageBox.Show("duplicate tran no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            foreach (StockTranItem oItem in _oStockTran)
                            {
                                _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                                if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                                {
                                    DBController.Instance.RollbackTransaction();
                                    MessageBox.Show("Stock Erorr...Stock can not be negative.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if ((_oProductStock.BookingStock - oItem.Qty) < 0)
                                {
                                    DBController.Instance.RollbackTransaction();
                                    MessageBox.Show("Stock Erorr...Stock can not be negative.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                _oProductStock.Quantity = oItem.Qty;
                                _oProductStock.Update(oItem.StockPrice);

                                if (_oProductStock.Flag == false)
                                {
                                    DBController.Instance.RollbackTransaction();
                                    MessageBox.Show("Stock Erorr...Stock can not be negative.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    return;
                                }
                            }

                            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                            {
                                StockTranItem oItem = new StockTranItem();
                                oItem.ProductID = oSalesInvoiceItem.ProductID;
                                oItem.Qty = oSalesInvoiceItem.Quantity;
                                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                                _oStockTran.Add(oItem);
                                oProduct = new Product();
                                oProduct.ProductID = oItem.ProductID;
                                oProduct.RefreshByProductID();

                                if (sProduct == "")
                                    sProduct = oProduct.ProductCode + "   " + oProduct.ProductName;
                                else sProduct = sProduct + "\n" + oProduct.ProductCode + "   " + oProduct.ProductName;
                            }

                            //IsTrue = true;
                            ////InvoiceWiseBarcode();
                            ////if (Utility.CompanyInfo != "BLL")
                            ////{
                            ////    if (_oSalesInvoiceInfo.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()))
                            ////    {
                            ////        PrintEMI();
                            ////        PrintInvoiceEPS();
                            ////    }
                            ////    else if (_oSalesInvoiceInfo.WarehouseID == Utility.WebStore)
                            ////    {
                            ////        PrintInvoiceEcommerce();
                            ////    }
                            ////    else
                            ////    {
                            ////        PrintInvoice();
                            ////    }
                            ////}
                            ////else
                            ////{
                            ////    PrintInvoice();
                            ////}

                            #region VAT OLD
                            //if (Utility.CompanyInfo == "TEL")
                            //{
                            //    _DutyLocalBalance = 0;
                            //    _DutyImportBalance = 0;
                            //    oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11);
                            //    oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA);

                            //    if (oDutyTranVAT11.Count > 0)
                            //    {
                            //        oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                            //        oDutyTranVAT11.Insert();
                            //    }
                            //    if (oDutyTranVAT11KA.Count > 0)
                            //    {
                            //        oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                            //        oDutyTranVAT11KA.Insert();
                            //    }

                            //    oDutyAccount = new DutyAccount();
                            //    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                            //    oDutyAccount.Balance = _DutyLocalBalance;
                            //    oDutyAccount.UpdateBalance(true);

                            //    oDutyAccount = new DutyAccount();
                            //    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                            //    oDutyAccount.Balance = _DutyImportBalance;
                            //    oDutyAccount.UpdateBalance(true);

                            //    //PrintVatChallan(_oSalesInvoice);
                            //}

                            //if (Utility.CompanyInfo == "BLL")
                            //{
                            //    _DutyLocalBalance = 0;
                            //    _DutyImportBalance = 0;
                            //    oDutyTranVAT11 = GetDataForVAT11BLL(oDutyTranVAT11);
                            //    oDutyTranVAT11KA = GetDataForVAT11KABLL(oDutyTranVAT11KA);
                            //    if (oDutyTranVAT11.Count > 0)
                            //    {
                            //        oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                            //        oDutyTranVAT11.Insert();
                            //    }
                            //    if (oDutyTranVAT11KA.Count > 0)
                            //    {
                            //        oDutyTranVAT11KA.Remarks = _oSalesInvoice.Remarks;
                            //        oDutyTranVAT11KA.Insert();
                            //    }


                            //    oDutyAccount = new DutyAccount();
                            //    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                            //    oDutyAccount.Balance = _DutyLocalBalance;
                            //    oDutyAccount.UpdateBalance(true);

                            //    oDutyAccount = new DutyAccount();
                            //    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                            //    oDutyAccount.Balance = _DutyImportBalance;
                            //    oDutyAccount.UpdateBalance(true);

                            //    //PrintVatChallan(_oSalesInvoice);
                            //}

                            #endregion

                            #region New Duty
      

                           SystemInfo oIsVatActive = new SystemInfo();
                           oIsVatActive.NewVatActive();

                            if (oIsVatActive.IsNewVat == 1 && DateTime.Now.Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
                            {
                                oDutyTranVAT63 = GetDataForVAT63(oDutyTranVAT63);
                                if (oDutyTranVAT63.Count > 0)
                                {
                                    if (oDutyTranVAT63.Amount > 0)
                                    {
                                        oDutyTranVAT63.Remarks = _oSalesInvoice.Remarks;
                                        oDutyTranVAT63.InsertNewHOVAT63();
                                    }
                                }
                                oDutyAccount = new DutyAccount();
                                oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccount.MUSHAK_6_3;
                                oDutyAccount.Balance = _NewDutyBalance;
                                //oDutyAccount.UpdateBalanceForPOS(true);
                                oDutyAccount.UpdateBalance(true);
                            }
                            else
                            {
                                if (Utility.CompanyInfo == "TEL")
                                {
                                    DutyTran oDetail = new DutyTran();
                                    oDetail.GetDutyDetailNew("Invoice", int.Parse(_oSalesInvoice.InvoiceID.ToString()));
                                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DutyAccount)))
                                    {
                                        if (GetEnum == (int)Dictionary.DutyAccount.MUSHAK_11)
                                        {
                                            double _TotalAmount = 0;
                                            int countMUSHAK_11 = 0;
                                            oDutyTranVAT11 = new DutyTran();
                                            foreach (DutyTranDetail oDutyTranDetail in oDetail)
                                            {
                                                if (oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_15 || oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_15)
                                                {
                                                    if (countMUSHAK_11 == 0)
                                                    {

                                                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                                                        DateTime time = DateTime.Now;
                                                        DateTime combine = day.Add(time.TimeOfDay);
                                                        oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(combine);
                                                        oDutyTranVAT11.WHID = _oSalesInvoice.WarehouseID;
                                                        oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
                                                        oDutyTranVAT11.DocumentNo = _oSalesInvoice.InvoiceNo;
                                                        oDutyTranVAT11.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                                        oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
                                                        oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
                                                        try
                                                        {
                                                            oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                                                        }
                                                        catch
                                                        {
                                                            oDutyTranVAT11.Remarks = "";
                                                        }
                                                        oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;
                                                        oDutyTranVAT11.Amount = 0;
                                                        oDutyTranVAT11.InsertNewHOVAT();
                                                        countMUSHAK_11++;
                                                    }

                                                    DutyTranDetail oItem = new DutyTranDetail();
                                                    oItem.DutyTranID = oDutyTranVAT11.DutyTranID;
                                                    oItem.ProductID = oDutyTranDetail.ProductID;
                                                    oItem.Qty = oDutyTranDetail.Qty;
                                                    oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                                                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                                                    oItem.WHID = _oSalesInvoice.WarehouseID;
                                                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                                                    oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                                                    oItem.VATType = oDutyTranDetail.VATType;
                                                    _TotalAmount = _TotalAmount + oItem.VAT;
                                                    oItem.InsertNewVATHO();

                                                }

                                            }
                                            oDutyTranVAT11.Amount = _TotalAmount;
                                            oDutyTranVAT11.UpdateToatlVATAmountHO();

                                            oDutyAccount = new DutyAccount();
                                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                                            oDutyAccount.Balance = _TotalAmount;
                                            oDutyAccount.UpdateBalance(true);
                                        }
                                        else if (GetEnum == (int)Dictionary.DutyAccount.MUSHAK_11KA)
                                        {
                                            int countMUSHAK_11KA = 0;
                                            double _TotalAmount = 0;
                                            oDutyTranVAT11KA = new DutyTran();
                                            foreach (DutyTranDetail oDutyTranDetail in oDetail)
                                            {
                                                if (oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_5)
                                                {
                                                    if (countMUSHAK_11KA == 0)
                                                    {

                                                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                                                        DateTime time = DateTime.Now;
                                                        DateTime combine = day.Add(time.TimeOfDay);
                                                        oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(combine);
                                                        oDutyTranVAT11KA.WHID = _oSalesInvoice.WarehouseID;
                                                        oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
                                                        oDutyTranVAT11KA.DocumentNo = _oSalesInvoice.InvoiceNo;
                                                        oDutyTranVAT11KA.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                                        oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
                                                        oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
                                                        try
                                                        {
                                                            oDutyTranVAT11KA.Remarks = _oSalesInvoice.Remarks;
                                                        }
                                                        catch
                                                        {
                                                            oDutyTranVAT11KA.Remarks = "";
                                                        }
                                                        oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;
                                                        oDutyTranVAT11KA.Amount = 0;
                                                        oDutyTranVAT11KA.InsertNewHOVAT();

                                                        countMUSHAK_11KA++;
                                                    }
                                                    DutyTranDetail oItem = new DutyTranDetail();
                                                    oItem.DutyTranID = oDutyTranVAT11KA.DutyTranID;
                                                    oItem.ProductID = oDutyTranDetail.ProductID;
                                                    oItem.Qty = oDutyTranDetail.Qty;
                                                    oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                                                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                                                    oItem.WHID = _oSalesInvoice.WarehouseID;
                                                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                                                    oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                                                    oItem.VATType = oDutyTranDetail.VATType;
                                                    _TotalAmount = _TotalAmount + oItem.VAT;
                                                    oItem.InsertNewVATHO();
                                                }

                                            }
                                            oDutyTranVAT11KA.Amount = _TotalAmount;
                                            oDutyTranVAT11KA.UpdateToatlVATAmountHO();

                                            oDutyAccount = new DutyAccount();
                                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                                            oDutyAccount.Balance = _TotalAmount;
                                            oDutyAccount.UpdateBalance(true);
                                        }
                                    }
                                }
                                else if (Utility.CompanyInfo == "BLL")
                                {
                                    _DutyLocalBalance = 0;
                                    _DutyImportBalance = 0;
                                    oDutyTranVAT11 = GetDataForVAT11BLL(oDutyTranVAT11);
                                    oDutyTranVAT11KA = GetDataForVAT11KABLL(oDutyTranVAT11KA);
                                    if (oDutyTranVAT11.Count > 0)
                                    {
                                        oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                                        oDutyTranVAT11.Insert();
                                    }
                                    if (oDutyTranVAT11KA.Count > 0)
                                    {
                                        oDutyTranVAT11KA.Remarks = _oSalesInvoice.Remarks;
                                        oDutyTranVAT11KA.Insert();
                                    }


                                    oDutyAccount = new DutyAccount();
                                    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                                    oDutyAccount.Balance = _DutyLocalBalance;
                                    oDutyAccount.UpdateBalance(true);

                                    oDutyAccount = new DutyAccount();
                                    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                                    oDutyAccount.Balance = _DutyImportBalance;
                                    oDutyAccount.UpdateBalance(true);

                                    //PrintVatChallan(_oSalesInvoice);
                                }

                            }


                            #endregion


                            DBController.Instance.CommitTran();

                            InvoiceWiseBarcode();
                            if (Utility.CompanyInfo != "BLL")
                            {
                                if (_oSalesInvoiceInfo.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()))
                                {
                                    PrintEMI();
                                    PrintInvoiceEPS();
                                }
                                else if (_oSalesInvoiceInfo.WarehouseID == Utility.WebStore)
                                {
                                    PrintInvoiceEcommerce();
                                }
                                else
                                {
                                    PrintInvoice();
                                }
                            }
                            else
                            {
                                PrintInvoice();
                            }

                            MessageBox.Show("Successfully Invoice system Processing (Delivery Invoice).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("error in Invoice system Processing (Delivery Invoice) =" + ex, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter barcode serial before Deliverey", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Only Processing Delivered Invoice Can Be Delivered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

        }
        public StockTran SetData(StockTran oStockTran)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.FromChannelID = _oSalesInvoice.CustomerDetail.ChannelID;
            oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = DateTime.Today.Date;

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                oItem.Qty = oSalesInvoiceItem.Quantity + oSalesInvoiceItem.FreeQty;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }

            return oStockTran;
        }
        public void PrintInvoice()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            if (_oSalesInvoice.WarehouseID == 68 && Utility.CompanyInfo == "TEL")
            {
                _orptSalesInvoice.RefreshForLead();
            }
            else
            {
                _orptSalesInvoice.Refresh();
                _orptSalesInvoice.RefreshAgingForBLL(_orptSalesInvoice.CustomerID);
            }

            oDSOrderItem = new DSOrderItem();
            oDSFreeQty = new DSOrderItem();
            long nRem = 0;
            long nQuotient = 0;
            rptSalesInvoice _orptSI = new rptSalesInvoice();
            _orptSI.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSI.RefreshInvoiceItemByID(false);

            foreach (rptSalesInvoiceDetail oSID in _orptSI)
            {
                DSOrderItem.OrderItemRow oOrderItemRow = oDSOrderItem.OrderItem.NewOrderItemRow();

                oOrderItemRow.ProductCode = oSID.ProductCode;
                oOrderItemRow.ProductName = oSID.ProductName;
                oOrderItemRow.UOM = oSID.SUOM;
                oOrderItemRow.UnitPrice = oSID.UnitPrice;
                oOrderItemRow.ConfirmQty = (int)oSID.Quantity;
                oOrderItemRow.GrossAmt = oSID.GrossAmount;
                oOrderItemRow.NetAmt = oSID.NetAmount;

                //_NetAmountTotal = _NetAmountTotal + oOrderItemRow.NetAmt;
                //nQuotient = Math.DivRem((int)oSID.Quantity, (int)oSID.UOMConversionFactor, out nRem);

                nQuotient = Math.DivRem((int)oSID.TotalQty, (int)oSID.LSRatio, out nRem);
                oOrderItemRow.PackQty =(int) nQuotient;



                oOrderItemRow.DP = oSID.AdjustedDPAmount * oSID.Quantity;
                oOrderItemRow.TP = oSID.AdjustedTPAmount * oSID.Quantity;
                oOrderItemRow.PW = oSID.AdjustedPWAmount * oSID.Quantity;

                oDSOrderItem.OrderItem.AddOrderItemRow(oOrderItemRow);
                oDSOrderItem.AcceptChanges();

            }

            //free Qty

            rptSalesInvoice _orptSIFreeQty = new rptSalesInvoice();
            _orptSIFreeQty.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSIFreeQty.RefreshInvoiceItemByID(true);
            bool IsFree = false;
            foreach (rptSalesInvoiceDetail oSID in _orptSIFreeQty)
            {
                DSOrderItem.FreeQtyRow oFreeQtyRow = oDSFreeQty.FreeQty.NewFreeQtyRow();

                oFreeQtyRow.ProductCode = oSID.ProductCode;
                oFreeQtyRow.ProductName = oSID.ProductName;
                oFreeQtyRow.FreeQty = oSID.FreeQty;

                oDSFreeQty.FreeQty.AddFreeQtyRow(oFreeQtyRow);
                oDSFreeQty.AcceptChanges();
                IsFree = true;
            }

            oDSOrderItem.Merge(oDSFreeQty);
            oDSOrderItem.AcceptChanges();



            //if (_orptSalesInvoice.SundryCustomerID != -1)
            //{

            //    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceRetailAutoPrint));


            //    doc.SetDataSource(_orptSalesInvoice);

            //    doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
            //    doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
            //    doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
            //    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            //    doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            //    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            //    doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            //    doc.SetParameterValue("SCCustomerName", _orptSalesInvoice.SundryCustomerName.ToString());
            //    doc.SetParameterValue("SCAddress", _orptSalesInvoice.SCAddress.ToString());
            //    doc.SetParameterValue("SCCellNo", _orptSalesInvoice.SCCellNo.ToString());
            //    doc.SetParameterValue("SCPhoneNo", _orptSalesInvoice.SCPhoneNo.ToString());
            //    doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            //    doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            //    doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            //    doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            //    doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            //    doc.SetParameterValue("Thana", _orptSalesInvoice.ThanaName.ToString());
            //    doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            //    doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
            //    doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
            //    doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
            //    doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
            //    doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
            //    doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
            //    doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
            //    doc.SetParameterValue("SL", "10101010");
            //    //IsSL = true;
            //    doc.SetParameterValue("IsSL", true);

            //    doc.SetParameterValue("CompanyInfo", "TEL");
            //    if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Product Return");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
            //    }
            //    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
            //    {
            //        doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
            //    }

            //    doc.SetParameterValue("InvoiceHeader", "Customer Copy");
            //    doc.PrintToPrinter(1, true, 1, 1);
            //    doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
            //    doc.PrintToPrinter(1, true, 1, 1);
            //    doc.SetParameterValue("InvoiceHeader", "Gate Pass Copy");
            //    doc.PrintToPrinter(1, true, 1, 1);


            //}
            //else
            //{
            if (Utility.CompanyInfo == "TEL")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                doc.SetDataSource(_orptSalesInvoice);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
                doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
                doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
                doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
                doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("IsSL", IsSL);
                doc.SetParameterValue("SL", SL);
                doc.SetParameterValue("CompanyInfo", "TEL");
                if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Delivery Breakage Replacement");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
                {
                    doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Return");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
                }

                doc.SetParameterValue("InvoiceHeader", "Customer Copy");
                doc.PrintToPrinter(1, true, 1, 1);
                doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
                doc.PrintToPrinter(1, true, 1, 1);
                doc.SetParameterValue("InvoiceHeader", "Gate Pass Copy");
                doc.PrintToPrinter(1, true, 1, 1);

            }
            else if (Utility.CompanyInfo == "BLL")
            {
                //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrintBLL));
                //doc.SetDataSource(_orptSalesInvoice);

                rptSalesInvoiceAutoPrintBLL doc = new rptSalesInvoiceAutoPrintBLL();
                doc.SetDataSource(oDSOrderItem);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
                doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
                doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
                doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                doc.SetParameterValue("Thana", _orptSalesInvoice.ThanaName.ToString());
                doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
                doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("Receivable", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Receivable)));
                doc.SetParameterValue("Age30", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Age30)));
                doc.SetParameterValue("Age60", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Age60)));
                doc.SetParameterValue("Above60Day", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Above60Day)));

                if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Delivery Breakage Replacement");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
                {
                    doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Return");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
                }


                doc.SetParameterValue("IsFree", IsFree);

                doc.SetParameterValue("InvoiceHeader", "Customer Copy");
                doc.PrintToPrinter(1, true, 1, 2);
                doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
                doc.PrintToPrinter(1, true, 1, 2);
                doc.SetParameterValue("InvoiceHeader", "Gate Pass Copy");
                doc.PrintToPrinter(1, true, 1, 2);
                doc.SetParameterValue("InvoiceHeader", " VAT Section Copy");
                doc.PrintToPrinter(1, true, 1, 2);


                //frmPrintPreview frmView;
                //frmView = new frmPrintPreview();
                //frmView.ShowDialog(doc);
            }
            else if (Utility.CompanyInfo == "TML")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                doc.SetDataSource(_orptSalesInvoice);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
                doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
                doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
                doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
                doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("IsSL", IsSL);
                doc.SetParameterValue("SL", SL);
                doc.SetParameterValue("CompanyInfo", "TML");
                if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Delivery Breakage Replacement");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
                {
                    doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Return");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
                }

                doc.SetParameterValue("InvoiceHeader", "Customer Copy");
                doc.PrintToPrinter(1, true, 1, 1);
                doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
                doc.PrintToPrinter(1, true, 1, 1);
                doc.SetParameterValue("InvoiceHeader", "Gate Pass Copy");
                doc.PrintToPrinter(1, true, 1, 1);

            }
            //}
        }
        public void PrintGoodsReceive()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            if (_oSalesInvoice.WarehouseID == 68 && Utility.CompanyInfo == "TEL")
            {
                _orptSalesInvoice.RefreshForLead();

            }
            else
            {

                _orptSalesInvoice.Refresh();
            }

            ///
            //Customer Copy
            ///

            if (Utility.CompanyInfo == "TEL")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceive));
                docCus.SetDataSource(_orptSalesInvoice);

                docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());                
                docCus.SetParameterValue("Thana", _orptSalesInvoice.ThanaName.ToString());
                docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                docCus.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                docCus.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                docCus.SetParameterValue("CompanyInfo", "TEL");

                docCus.PrintToPrinter(1, true, 1, 1);


            }
            else if (Utility.CompanyInfo == "BLL")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceiveBLL));
                docCus.SetDataSource(_orptSalesInvoice);


                docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                docCus.SetParameterValue("Thana", _orptSalesInvoice.ThanaName.ToString());
                //docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());

                docCus.PrintToPrinter(2, true, 1, 2);

            }
            else if (Utility.CompanyInfo == "TML")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceive));
                docCus.SetDataSource(_orptSalesInvoice);

                docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                docCus.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                docCus.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                docCus.SetParameterValue("CompanyInfo", "TML");
                docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks);
                docCus.PrintToPrinter(1, true, 1, 1);

            }

        }

        public void PrintProductReturn()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();

            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;

            long InvoiceID = _orptSalesInvoice.InvoiceID;
                    
           _orptSalesInvoice.RefreshforProductReturn(InvoiceID);


            rptProductReturnBLL oReports = new rptProductReturnBLL();
            List<rptProductReturn> aList = new List<rptProductReturn>();
            foreach (rptSalesInvoice orptSalesInvoice in _orptSalesInvoice)
            {
                var aTran = new rptProductReturn
            {
                    InvoiceID = orptSalesInvoice.InvoiceID,
                    ProductCode = orptSalesInvoice.ProductCode,
                    ProductName = orptSalesInvoice.ProductName,
                    UOM = orptSalesInvoice.UOM,
                    UnitPrice = orptSalesInvoice.UnitPrice,
                    Quantity = orptSalesInvoice.Quantity,
                    PackQty = orptSalesInvoice.PackQty,
                    Discount = orptSalesInvoice.Discount,
                    InvoiceAmount = orptSalesInvoice.InvoiceAmount,
                    QtyAmount = orptSalesInvoice.QtyAmount,
                    InvoiceNo = orptSalesInvoice.InvoiceNo,
                    InvoiceDate = orptSalesInvoice.InvoiceDate,
                    Remarks = orptSalesInvoice.Remarks,
                    RefInvoiceNo = orptSalesInvoice.RefInvoiceNo,
                    RefDate = orptSalesInvoice.RefDate,
                    CustomerCode = orptSalesInvoice.CustomerCode,
                    CustomerName = orptSalesInvoice.CustomerName,
                    CustomerAddress = orptSalesInvoice.CustomerAddress,
                    ThanaName = orptSalesInvoice.ThanaName,
                    DistrictName = orptSalesInvoice.DistrictName,
                    CustomerTelephone = orptSalesInvoice.CustomerTelephone,
                    CustomerTypeName = orptSalesInvoice.CustomerTypeName,
                    AreaName = orptSalesInvoice.AreaName,
                    TerritoryName = orptSalesInvoice.TerritoryName,
                    ProRecUser=orptSalesInvoice.ProRecUser
                };
                aList.Add(aTran);
            }

            oReports.SetDataSource(aList);
            oReports.SetParameterValue("PrintUser", Utility.Username);
            oReports.SetParameterValue("CompanyName", Utility.CompanyName);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);


           
            

        }
        public void PrintInvoiceEPS()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();


            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrintEPS));


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

            doc.SetParameterValue("EPSCustomerCode", _orptSalesInvoice.EPSCustomerCode.ToString());
            doc.SetParameterValue("EmployeeName", _orptSalesInvoice.EmployeeName.ToString());
            doc.SetParameterValue("EmployeeAddress", _orptSalesInvoice.EmployeeAddress.ToString());
            doc.SetParameterValue("EPSCustPhoneNo", _orptSalesInvoice.PhoneNo.ToString());
            doc.SetParameterValue("EPSDeliveryWHName", _orptSalesInvoice.EPSDeliveryWHName.ToString());
            doc.SetParameterValue("IsSL", IsSL);
            doc.SetParameterValue("SL", SL);

            if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
            {
                doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
            }
            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
            {
                doc.SetParameterValue("InvoiceTypeName", "EPS Reverse Invoice");
            }

            doc.SetParameterValue("InvoiceHeader", "Customer Copy");
            doc.PrintToPrinter(1, true, 1, 1);
            doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
            doc.PrintToPrinter(1, true, 1, 1);
            doc.SetParameterValue("InvoiceHeader", "Gate Pass Copy");
            doc.PrintToPrinter(1, true, 1, 1);


        }
        public void PrintInvoiceEcommerce()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshForEcommerce();

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrintECommerce));


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
            doc.SetParameterValue("Discount",oTELLib.TakaFormat(_orptSalesInvoice.Discount));
            doc.SetParameterValue("InvoiceAmount",oTELLib.TakaFormat(_orptSalesInvoice.InvoiceAmount));
            doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
            if (_orptSalesInvoice.OrderConfirmeddByName != null)
            {
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
            }
            else
            {
                doc.SetParameterValue("OrderConfirmBy", "");
            }
            doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
            doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString());
            doc.SetParameterValue("CompanyName", Utility.CompanyName);

            doc.SetParameterValue("SundryCustName", _orptSalesInvoice.SundryCustomerName.ToString());
            doc.SetParameterValue("SundryCustAddress", _orptSalesInvoice.SCAddress.ToString());
            doc.SetParameterValue("CellNo", _orptSalesInvoice.SCCellNo.ToString());
            doc.SetParameterValue("Email", _orptSalesInvoice.SCEmail.ToString());
            doc.SetParameterValue("WebInvoiceNo", _orptSalesInvoice.WebInvoiceNo.ToString());

            doc.SetParameterValue("InvoiceTypeName", "Ecommerce Invoice");

            doc.SetParameterValue("InvoiceHeader", "Customer Copy");
            doc.PrintToPrinter(1, true, 1, 1);
            doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
            doc.PrintToPrinter(1, true, 1, 1);
            doc.SetParameterValue("InvoiceHeader", "Gate Pass Copy");
            doc.PrintToPrinter(1, true, 1, 1);

            //frmPrintPreview oForm = new frmPrintPreview();
            //oForm.ShowDialog(doc);


        }
        public void PrintGoodsReceiveEPS()
        {
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();


            CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceiveEPS));
            docCus.SetDataSource(_orptSalesInvoice);

            docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");

            docCus.SetParameterValue("EPSCustomerCode", _orptSalesInvoice.EPSCustomerCode.ToString());
            docCus.SetParameterValue("EmployeeName", _orptSalesInvoice.EmployeeName.ToString());
            docCus.SetParameterValue("EmployeeAddress", _orptSalesInvoice.EmployeeAddress.ToString());
            docCus.SetParameterValue("EPSCustPhoneNo", _orptSalesInvoice.PhoneNo.ToString());
            docCus.SetParameterValue("EPSDeliveryWHName", _orptSalesInvoice.EPSDeliveryWHName.ToString());
            docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());

            docCus.PrintToPrinter(1, true, 1, 1);

        }
        public void PrintEMI()
        {
            _oEMICalculationDetail = new EMICalculationDetail();
            _oEMICalculationDetail.Refresh(_oSalesInvoice.OrderID);

            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptEPSEMIPrint));
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
            doc.SetParameterValue("InvoiceHeader", "Customer Copy");


            doc.PrintToPrinter(1, true, 1, 1);

        }
        public void PrintVatChallan(SalesInvoice oSalesInvoice)
        {

            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.RefreshHONew(_orptSalesInvoice.DeliveryDate);
            oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID);
            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;

                oDutyTran.GetVATReport();////oSalesInvoice.InvoiceStatus
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                    doc.SetParameterValue("TAXNo", _orptSalesInvoice.TaxNo.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToShortTimeString());
                    doc.SetParameterValue("DaliveryDateInWord", DateTimeConversion.DateTimeToText(_orptSalesInvoice.DeliveryDate, true, false));
                    doc.SetParameterValue("VATRegistrationNo", _oSystemInfo.VATRegistrationNo);

                    doc.SetParameterValue("ActualDeliveryDateTime", oDutyTran.DutyTranDate);
                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord.ToString());


                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(Convert.ToInt32(oSalesInvoice.InvoiceID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);
                    doc.SetParameterValue("16(1)", "[ wewa-16 (1) `ªóe¨ ]");


                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }
                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }
                    oLib = new TELLib();
                    doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

                    doc.SetParameterValue("Copy", "cÖ_g Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "wØZxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "Z…Zxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    //frmPrintPreview oFrom = new frmPrintPreview();
                    //oFrom.ShowDialog(doc);

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanType", "Mushak-11(Ka)");
                    doc.SetParameterValue("VATRegistrationNo", _oSystemInfo.VATRegistrationNo);
                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }
                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(Convert.ToInt32(oSalesInvoice.InvoiceID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);

                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    string sBarcode = "";
                    string sBENo = "";
                    bool IsVis = false;
                    if (Utility.CompanyInfo != "BLL")
                    {
                        DutyTran oChkIsVis = new DutyTran();
                        IsVis = oChkIsVis.CheckIsReadBENoHO(oDutyTran.DutyTranID);
                        if (IsVis)
                        {
                            DutyTran oGetBENo = new DutyTran();
                            sBENo = oGetBENo.GetBENobyInvID(Convert.ToInt32(_orptSalesInvoice.InvoiceID));
                        }
                    }
                    DutyTran oIsVatExempted = new DutyTran();
                    if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
                    {
                        if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63_Exempted));
                            doc.SetDataSource(oDutyTran);
                            

                            ShipmentVehicle oVehicle = new ShipmentVehicle();
                            oVehicle.GetVehicleNo(Convert.ToInt32(oSalesInvoice.InvoiceID), oDutyTran.DutyTranID);
                            doc.SetParameterValue("VehicleNumber", oVehicle.VehicleNo);

                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
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

                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {

                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);

                            }
                        }
                        else
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63_Exempted));
                            doc.SetDataSource(oDutyTran);
                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
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

                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {

                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);

                            }
                        }
                    }
                    else
                    {
                        if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                            doc.SetDataSource(oDutyTran);


                            ShipmentVehicle oVehicle = new ShipmentVehicle();
                            oVehicle.GetVehicleNo(Convert.ToInt32(oSalesInvoice.InvoiceID), oDutyTran.DutyTranID);
                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                            doc.SetParameterValue("VehicleNumber", oVehicle.VehicleNo);
                            doc.SetParameterValue("RefJobNo", "");
                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
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
                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                        }
                        else
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63));
                            doc.SetDataSource(oDutyTran);
                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
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
                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                        }
                    }
                }

            }

        }
        ///
        //  For VAT 11
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11)
        {
            oDutyTranVAT11 = new DutyTran();

            oDutyTranVAT11.DutyTranDate = DateTime.Now;
            oDutyTranVAT11.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                    //if (CheckProductID(oDutyTranDetail.ProductID))
                    //{
                        if (oItem.UnitPrice == 0)
                        {
                            CustomerDetail oCustomerDetail = new CustomerDetail();
                            oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                            oCustomerDetail.refresh();

                            if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                            else
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            TPVATProduct _oTPVATProduct = new TPVATProduct();
                            double _Price = 0;
                            if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                            {
                                oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                            }
                            else
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                            }

                            oDutyTranDetail.DutyRate = oItem.VATAmount;
                        }
                    //}
                    //else
                    //{
                    //    oDutyTranDetail.DutyPrice = 0;
                    //    oDutyTranDetail.DutyRate = 0;
                    //}

                    _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA)
        {
            oDutyTranVAT11KA = new DutyTran();

            oDutyTranVAT11KA.DutyTranDate = DateTime.Now;
            oDutyTranVAT11KA.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                    //if (CheckProductID(oDutyTranDetail.ProductID))
                    //{
                        if (oItem.UnitPrice == 0)
                        {
                            CustomerDetail oCustomerDetail = new CustomerDetail();
                            oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                            oCustomerDetail.refresh();

                            if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                            else
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            TPVATProduct _oTPVATProduct = new TPVATProduct();
                            double _Price = 0;
                            if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                            {
                                oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                            }
                            else
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                            }

                            oDutyTranDetail.DutyRate = oItem.VATAmount;
                        }
                    //}
                    //else
                    //{
                    //    oDutyTranDetail.DutyPrice = 0;
                    //    oDutyTranDetail.DutyRate = 0;
                    //}

                    _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        public DutyTran GetDataForVAT11KABLL(DutyTran oDutyTranVAT11KA)
        {
            oDutyTranVAT11KA = new DutyTran();

            oDutyTranVAT11KA.DutyTranDate = DateTime.Now;
            oDutyTranVAT11KA.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);

                    oDutyTranDetail.DutyPrice = _oProductDetail.TradePrice;
                    oDutyTranDetail.DutyRate = _oProductDetail.Vat;


                    _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        public DutyTran GetDataForVAT11BLL(DutyTran oDutyTranVAT11)
        {
            oDutyTranVAT11 = new DutyTran();

            oDutyTranVAT11.DutyTranDate = DateTime.Now;
            oDutyTranVAT11.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);

                    oDutyTranDetail.DutyPrice = _oProductDetail.TradePrice;
                    oDutyTranDetail.DutyRate = _oProductDetail.Vat;


                    _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }
        //public DutyTran GetDataForVAT63(DutyTran oDutyTranVAT63)
        //{

        //   oDutyTranVAT63 = new DutyTran();
        //    oDutyTranVAT63.DutyTranDate = DateTime.Now;
        //    oDutyTranVAT63.WHID = _oSalesInvoice.WarehouseID;
        //    oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
        //    oDutyTranVAT63.DutyTypeID = (int)Dictionary.DutyType.VAT;
        //    oDutyTranVAT63.DocumentNo = _oSalesInvoice.InvoiceNo;
        //    oDutyTranVAT63.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
        //    oDutyTranVAT63.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
        //    oDutyTranVAT63.DutyAccountID = 3;




        //    ProductDetails oVatProductItem = new ProductDetails();
        //    oVatProductItem.RefreshVatProduct(_oSalesInvoice.InvoiceID);
        //    foreach (ProductDetail oItem in oVatProductItem)
        //    {

        //        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

        //        oDutyTranDetail.ProductID = oItem.ProductID;
        //        oDutyTranDetail.Qty = oItem.Quantity;
        //        oDutyTranDetail.DutyPrice = oItem.DutyPrice;
        //        oDutyTranDetail.DutyRate = oItem.DutyRate;
        //        oDutyTranDetail.WHID = oSystemInfo.WarehouseID;
        //        oDutyTranDetail.UnitPrice = oItem.UnitPrice;
        //        oDutyTranDetail.VAT = oItem.Vat;

        //        _NewDutyBalance = _NewDutyBalance + oDutyTranDetail.VAT;

        //        oDutyTranVAT63.Add(oDutyTranDetail);


        //    }
        //    oDutyTranVAT63.Amount = _NewDutyBalance;

        //    return oDutyTranVAT63;
        //}

        private void btPrintVAT_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            ShipmentVehicle oShipmentVehicle = new ShipmentVehicle();
            bool _IsVehicleAssign = oShipmentVehicle.IsVehicleAssign(Convert.ToInt32(_oSalesInvoiceInfo.InvoiceID), "Invoice");
            if (_IsVehicleAssign != true)
            {
                MessageBox.Show("Please assign vehicle first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            PrintVatChallan(_oSalesInvoice);
        }

        private void btPrintInvoice_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
            //IsTrue = true;
            InvoiceWiseBarcode();
            if (_oSalesInvoiceInfo.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()))
            {
                PrintInvoiceEPS();
            }
            else if (_oSalesInvoiceInfo.WarehouseID == Utility.WebStore)
            {
                PrintInvoiceEcommerce();
            }
            else
            {
                PrintInvoice();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btProcessDelivery_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.UNDELIVERED)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesInvoice.UserID = Utility.UserId;

                    if (Utility.CompanyInfo == "BLL") // For BLL
                    {
                        if (_oSalesInvoice.InvoiceTypeID == 2) //  Trade Price check for Cash Invoice
                        {

                            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
                            {
                                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                                _oSalesInvoiceItem.ProductID = oItem.ProductID;
                                _oSalesInvoiceItem.UnitPrice = oItem.UnitPrice;
                                _oSalesInvoiceItem.Quantity = oItem.Quantity;

                                _oProductDetail = new ProductDetail();
                                _oProductDetail.ProductID = oItem.ProductID;
                                _oSalesInvoice.RefreshSalesInvoiceItem();

                                oItem.CalculativeTradePrice = Math.Round(((oItem.UnitPrice - oItem.AdjustedDPAmount) / ((oItem.VATAmount * 100) + 100)) * 100, 4);
                                oItem.VATLowerLimit = Math.Round(oItem.TradePrice - (oItem.TradePrice * 0.075), 4);
                                oItem.VATUpperLimit = Math.Round(oItem.TradePrice + (oItem.TradePrice * 0.075), 4);

                                if (oItem.CalculativeTradePrice <= oItem.VATLowerLimit)
                                {
                                    _oSalesInvoiceItem.TradePrice = oItem.VATLowerLimit;
                                    _oSalesInvoice.UpdateStatus(_oSalesInvoice.InvoiceID, _oSalesInvoiceItem.ProductID, _oSalesInvoiceItem.TradePrice);
                                    _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);

                                    IsTrue = false;
                                    InvoiceWiseBarcode();

                                    PrintGoodsReceive();

                                    DBController.Instance.CommitTran();
                                    MessageBox.Show("Successfully Invoice system Processing (Process Invoice).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                if (oItem.CalculativeTradePrice >= oItem.VATLowerLimit && oItem.CalculativeTradePrice <= oItem.VATUpperLimit)
                                {
                                    _oSalesInvoiceItem.TradePrice = oItem.CalculativeTradePrice;
                                    _oSalesInvoice.UpdateStatus(_oSalesInvoice.InvoiceID, _oSalesInvoiceItem.ProductID, _oSalesInvoiceItem.TradePrice);
                                    _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);

                                    IsTrue = false;
                                    InvoiceWiseBarcode();

                                    PrintGoodsReceive();

                                    DBController.Instance.CommitTran();
                                    MessageBox.Show("Successfully Invoice system Processing (Process Invoice).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                if (oItem.CalculativeTradePrice > oItem.VATLowerLimit && Utility.UserId==445)
                                {
                                    _oSalesInvoiceItem.TradePrice = oItem.CalculativeTradePrice;
                                    _oSalesInvoice.UpdateStatus(_oSalesInvoice.InvoiceID, _oSalesInvoiceItem.ProductID, _oSalesInvoiceItem.TradePrice);
                                    _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);

                                    IsTrue = false;
                                    InvoiceWiseBarcode();

                                    PrintGoodsReceive();

                                    DBController.Instance.CommitTran();
                                    MessageBox.Show("Successfully Invoice system Processing (Process Invoice).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                else

                                {
                                    DBController.Instance.CommitTran();
                                    MessageBox.Show("This Invoice is out of VAT approved limit. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }

                        }

                        else
                        {
                            _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);

                            IsTrue = false;
                            InvoiceWiseBarcode();

                            PrintGoodsReceive();

                            DBController.Instance.CommitTran();
                            MessageBox.Show("Successfully Invoice system Processing (Process Invoice).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    else // For TEL
                    {
                        _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                        //PrintDeliveryDoc();
                        IsTrue = false;
                        InvoiceWiseBarcode();

                            if (_oSalesInvoiceInfo.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()))
                            {
                                //PrintInvoiceEPS();
                                PrintGoodsReceiveEPS();
                            }
                            else if (_oSalesInvoiceInfo.WarehouseID == Utility.WebStore)
                            {
                                //Print something;
                            }
                            else
                            {
                                //PrintInvoice();
                                PrintGoodsReceive();
                            }

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Invoice system Processing (Process Invoice).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("error in Invoice system Processing (Delivery Invoice) =" + ex, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Invoice have been Locked.You do have enough permission to Process this Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public void PrintDeliveryDoc()
        {

            string sCompanyName = Utility.CompanyName;
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.Refresh();

            bool bIsPartial = _orptSalesInvoice.IsPartial();

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptDeliveryNote));

            doc.SetDataSource(_orptSalesInvoice);

            doc.SetParameterValue("PrintBy", Utility.Username);
            doc.SetParameterValue("IsPartial", bIsPartial);

            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
            doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.CustomerAddress);
            doc.SetParameterValue("WarehouseName", _orptSalesInvoice.WarehouseName + " [" + _orptSalesInvoice.WarehouseCode + "]");
            doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
            doc.SetParameterValue("InvvoiceDate", Convert.ToDateTime(_orptSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));

            doc.SetParameterValue("EPSDeliveryWHName", _orptSalesInvoice.EPSDeliveryWHName);

            doc.SetParameterValue("OrderConfirmedBy", _orptSalesInvoice.OrderConfirmedBy);
            doc.SetParameterValue("CompanyName", sCompanyName);
            doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks);

            if (_orptSalesInvoice.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()))
            {
                doc.SetParameterValue("IsEPSDeliWH", true);
            }
            else doc.SetParameterValue("IsEPSDeliWH", false);


            if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
            {
                doc.SetParameterValue("InvoiceType", "Product Replacement");
                doc.SetParameterValue("IsVisibleInvoiceType", true);
                doc.SetParameterValue("SalesOrderNo", _orptSalesInvoice.RefDetails);
            }
            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
            {
                doc.SetParameterValue("InvoiceType", "Breakage Replacement");
                doc.SetParameterValue("IsVisibleInvoiceType", true);
                doc.SetParameterValue("SalesOrderNo", _orptSalesInvoice.RefDetails);
            }
            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
            {
                doc.SetParameterValue("InvoiceType", "Issue Sales Promotion");
                doc.SetParameterValue("IsVisibleInvoiceType", true);
            }
            else
            {
                doc.SetParameterValue("InvoiceType", "Normal");
                doc.SetParameterValue("IsVisibleInvoiceType", false);
                doc.SetParameterValue("SalesOrderNo", _orptSalesInvoice.OrderNo);
            }
            if (bIsPartial == true)
            {
                doc.PrintToPrinter(1, true, 1, 2);
                doc.PrintToPrinter(1, true, 1, 2);

            }
            else
            {
                doc.PrintToPrinter(1, true, 1, 1);
                doc.PrintToPrinter(1, true, 1, 1);
            }
        }

        private void updateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {

                    if ("M1.8" == sPermissionKey)
                    {
                        btPrintInvoice.Enabled = true;
                    }
                    if ("M1.9" == sPermissionKey)
                    {
                        btPrintVAT.Enabled = true;
                    }
                    if ("M1.66" == sPermissionKey)
                    {
                        btProcessDelivery.Enabled = true;
                    }
                    if ("M1.67" == sPermissionKey)
                    {
                        btnDelivery.Enabled = true;
                    }
                }
            }

        }

        private void btDeliveryNote_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oSalesInvoice = new SalesInvoice();

            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
            //PrintDeliveryDoc();
            //IsTrue = false;
            InvoiceWiseBarcode();
            if (_oSalesInvoiceInfo.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()))
            {
                //PrintInvoiceEPS();
                PrintGoodsReceiveEPS();
                
            }
            else
            {
                //PrintInvoice();
                PrintGoodsReceive();
            }

        }

        public bool CheckProductID(int nProductID)
        {
            int nCount = 0;
            foreach (int PID in ProductIDList)
            {
                if (PID == nProductID)
                    nCount++;
            }
            if (nCount == 0)
                return true;
            else return false;

        }

        private void filterRecord()
        {
            string sExpr;
            lvwOrderList.Items.Clear();
            if (oSalesInvoiceDetails == null)
                return;
            if (oSalesInvoiceDetails.Count <= 0)
                return;
            SalesInvoiceDetails _oSalesInvoiceDetails = oSalesInvoiceDetails;

            DataSet oDS = new DataSet();
            oDS = _oSalesInvoiceDetails.ToDataSet();

            sExpr = "CustomerName like '%" + txtCustomerName.Text.Trim() + "%'";
            sExpr = sExpr + " AND CustomerCode like '%" + txtCustomerCode.Text.Trim() + "%'";
            sExpr = sExpr + " AND OrderNo like '%" + txtOrderNo.Text.Trim() + "%'";
            sExpr = sExpr + " AND InvoiceNo like '%" + txtInvoiceNo.Text.Trim() + "%'";

            if (_oUtilitys[cmbInvoiceStatus.SelectedIndex].SatusId != -1)
            {
                sExpr = sExpr + " AND InvoiceStatus = '" + _oUtilitys[cmbInvoiceStatus.SelectedIndex].SatusId + "'";
            }

            DataRow[] oDR = oDS.Tables[0].Select(sExpr);

            DataSet _oDS = new DataSet();
            _oDS.Merge(oDR);
            _oDS.AcceptChanges();
            if (_oDS.Tables.Count > 0)
            {
                _oSalesInvoiceDetails.FromDataSetToClass(_oDS);
                FillRecord(_oSalesInvoiceDetails);
            }
            else return;

        }

        private void btMakeInvoice_Click(object sender, EventArgs e)
        {
            frmReplaceInvoice ofrmReplaceInvoice = new frmReplaceInvoice();
            ofrmReplaceInvoice.ShowDialog();
            RefreshData();
        }

        private void btViewInvoice_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
            frmReplaceInvoice ofrmReplaceInvoice = new frmReplaceInvoice();
            ofrmReplaceInvoice.ShowDialog(_oSalesInvoice);

        }

        private void btClaimInvoice_Click(object sender, EventArgs e)
        {
            frmClaimImvoice ofrmClaimImvoice = new frmClaimImvoice();
            ofrmClaimImvoice.ShowDialog();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count != 0)
            {
                SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;

                //if (_oSalesInvoiceInfo.InvoiceStatus == (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
                //{
                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                    oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
                    oSalesInvoiceProductSerial.RefreshByInvoiceID(_oSalesInvoiceInfo.InvoiceID);

                    frmSalesInvoiceProductSerial oForm = new frmSalesInvoiceProductSerial();

                    oForm.ShowDialog(oSalesInvoiceProductSerial);
                //}
                //else
                //{
                //    MessageBox.Show("Only Processing Delivery status is eligible for barcode preserving", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnWarrantyCard_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                PrintWarrantyCard();
                this.Cursor = Cursors.Default;

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void PrintWarrantyCard()
        {
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;

            rptWarrantyCardPrints _orptWarrantyCardPrints = new rptWarrantyCardPrints();

            WarrantyCardPrintParam(_oSalesInvoiceInfo.InvoiceID);

            _orptWarrantyCardPrints.RefreshWarrantyCardRePrint(_oSalesInvoiceInfo.InvoiceID, CustInfo);

            foreach (rptWarrantyCardPrint orptWarrantyCardPrint in _orptWarrantyCardPrints)
            {
                rptWarrantyCard_Dealer doc = new rptWarrantyCard_Dealer();
                //doc.SetDataSource(orptWarrantyCardPrint);
                string dateformat = "";
                dateformat = orptWarrantyCardPrint.InvoiceDate.ToString("ddMMyy");
                doc.SetParameterValue("CustomerName", orptWarrantyCardPrint.CustomerName.ToString());
                doc.SetParameterValue("Address", orptWarrantyCardPrint.Address.ToString());
                doc.SetParameterValue("Telephone", orptWarrantyCardPrint.Telephone.ToString());
                doc.SetParameterValue("MobileNo", orptWarrantyCardPrint.MobileNo.ToString());
                doc.SetParameterValue("Email", orptWarrantyCardPrint.Email.ToString());

                if (CustInfo != (int)Dictionary.WarratnyCardCustInfo.NoCustomer)
                {
                    doc.SetParameterValue("D1", dateformat.Substring(0, 1));
                    doc.SetParameterValue("D2", dateformat.Substring(1, 1));
                    doc.SetParameterValue("M1", dateformat.Substring(2, 1));
                    doc.SetParameterValue("M2", dateformat.Substring(3, 1));
                    doc.SetParameterValue("Y1", dateformat.Substring(4, 1));
                    doc.SetParameterValue("Y2", dateformat.Substring(5, 1));
                    doc.SetParameterValue("InvoiceNo1", orptWarrantyCardPrint.InvoiceNo.ToString());

                }
                else
                {
                    doc.SetParameterValue("D1", "");
                    doc.SetParameterValue("D2", "");
                    doc.SetParameterValue("M1", "");
                    doc.SetParameterValue("M2", "");
                    doc.SetParameterValue("Y1", "");
                    doc.SetParameterValue("Y2", "");
                    doc.SetParameterValue("InvoiceNo1", "");
                }               

                doc.SetParameterValue("ProductCode", orptWarrantyCardPrint.ProductCode.ToString());
                doc.SetParameterValue("ProductName", orptWarrantyCardPrint.ProductName.ToString());
                doc.SetParameterValue("DealerName", orptWarrantyCardPrint.DealerName.ToString());
                doc.SetParameterValue("InvoiceNo", orptWarrantyCardPrint.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", orptWarrantyCardPrint.InvoiceDate.ToString("yyyyMMdd"));
                doc.SetParameterValue("Barcode", orptWarrantyCardPrint.Barcode.ToString());
                doc.SetParameterValue("Service", orptWarrantyCardPrint.ServiceWarranty.ToString());
                doc.SetParameterValue("Spare", orptWarrantyCardPrint.PartsWarranty.ToString());
                doc.SetParameterValue("Special", orptWarrantyCardPrint.SpecialComponentWarranty.ToString());
                doc.SetParameterValue("BrandName", orptWarrantyCardPrint.BrandName.ToString());

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);

            }

        }
        private void WarrantyCardPrintParam(long nInvoiceID)
        {
            string sCommaSplit = "";
            int ChannelID = 0;
            string value = ConfigurationManager.AppSettings["WithSundryCustInfo"];
            char[] delimiter = new char[] { ',' };
            string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                sCommaSplit = parts[i].ToString();
                ChannelID = Convert.ToInt32(sCommaSplit.Trim());
                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                _oSalesInvoiceProductSerial.GetChannelByInvoiceID(nInvoiceID);
                if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
                {
                    CustInfo = (int)Dictionary.WarratnyCardCustInfo.SundryCustomer;
                }
            }
            string value1 = ConfigurationManager.AppSettings["WithCustInfo"];
            char[] delimiter1 = new char[] { ',' };
            string[] parts1 = value1.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts1.Length; i++)
            {
                sCommaSplit = parts1[i].ToString();
                ChannelID = Convert.ToInt32(sCommaSplit.Trim());
                if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
                {
                    CustInfo = (int)Dictionary.WarratnyCardCustInfo.PrimaryCustomer;
                }
            }

            string value2 = ConfigurationManager.AppSettings["BlankCustInfo"];
            char[] delimiter2 = new char[] { ',' };
            string[] parts2 = value2.Split(delimiter2, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts2.Length; i++)
            {
                sCommaSplit = parts2[i].ToString();
                ChannelID = Convert.ToInt32(sCommaSplit.Trim());
                if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
                {
                    CustInfo = (int)Dictionary.WarratnyCardCustInfo.NoCustomer;
                }
            }

        }

        public void InvoiceWiseBarcode()
        {
            SL = "";
           
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(_oSalesInvoiceInfo.InvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {
                IsSL = true;
                string PCode = "";

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

        private void btnWarrantyCardAuto_Click(object sender, EventArgs e)
        {
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;

            rptWarrantyCardPrints _orptWarrantyCardPrints = new rptWarrantyCardPrints();

            WarrantyCardPrintParam(_oSalesInvoiceInfo.InvoiceID);

            _orptWarrantyCardPrints.RefreshWarrantyCardRePrint(_oSalesInvoiceInfo.InvoiceID, CustInfo);

            foreach (rptWarrantyCardPrint orptWarrantyCardPrint in _orptWarrantyCardPrints)
            {
                rptWarrantyCard_Dealer doc = new rptWarrantyCard_Dealer();
                //doc.SetDataSource(orptWarrantyCardPrint);
                string dateformat = "";
                dateformat = orptWarrantyCardPrint.InvoiceDate.ToString("ddMMyy");
                doc.SetParameterValue("CustomerName", orptWarrantyCardPrint.CustomerName.ToString());
                doc.SetParameterValue("Address", orptWarrantyCardPrint.Address.ToString());
                doc.SetParameterValue("Telephone", orptWarrantyCardPrint.Telephone.ToString());
                doc.SetParameterValue("MobileNo", orptWarrantyCardPrint.MobileNo.ToString());
                doc.SetParameterValue("Email", orptWarrantyCardPrint.Email.ToString());

                if (CustInfo != (int)Dictionary.WarratnyCardCustInfo.NoCustomer)
                {
                    doc.SetParameterValue("D1", dateformat.Substring(0, 1));
                    doc.SetParameterValue("D2", dateformat.Substring(1, 1));
                    doc.SetParameterValue("M1", dateformat.Substring(2, 1));
                    doc.SetParameterValue("M2", dateformat.Substring(3, 1));
                    doc.SetParameterValue("Y1", dateformat.Substring(4, 1));
                    doc.SetParameterValue("Y2", dateformat.Substring(5, 1));
                    doc.SetParameterValue("InvoiceNo1", orptWarrantyCardPrint.InvoiceNo.ToString());

                }
                else
                {
                    doc.SetParameterValue("D1", "");
                    doc.SetParameterValue("D2", "");
                    doc.SetParameterValue("M1", "");
                    doc.SetParameterValue("M2", "");
                    doc.SetParameterValue("Y1", "");
                    doc.SetParameterValue("Y2", "");
                    doc.SetParameterValue("InvoiceNo1", "");
                }

                doc.SetParameterValue("ProductCode", orptWarrantyCardPrint.ProductCode.ToString());
                doc.SetParameterValue("ProductName", orptWarrantyCardPrint.ProductName.ToString());
                doc.SetParameterValue("DealerName", orptWarrantyCardPrint.DealerName.ToString());
                doc.SetParameterValue("InvoiceNo", orptWarrantyCardPrint.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", orptWarrantyCardPrint.InvoiceDate.ToString("yyyyMMdd"));
                doc.SetParameterValue("Barcode", orptWarrantyCardPrint.Barcode.ToString());
                doc.SetParameterValue("Service", orptWarrantyCardPrint.ServiceWarranty.ToString());
                doc.SetParameterValue("Spare", orptWarrantyCardPrint.PartsWarranty.ToString());
                doc.SetParameterValue("Special", orptWarrantyCardPrint.SpecialComponentWarranty.ToString());
                doc.SetParameterValue("BrandName", orptWarrantyCardPrint.BrandName.ToString());

                doc.PrintToPrinter(1, true, 1, 1);

            }
        }

        //private void btnDPCorrection_Click(object sender, EventArgs e)
        //{
        //    //frmDPCorrection oFrom = new frmDPCorrection();
        //    //oFrom.Show();
        //}

        private void btnReturnNote_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
           // int InvoiceTypeID = frmDeliveryInvoices.localList.Find(a => a.InvoiceID == _oSalesInvoiceInfo.InvoiceID).InvoiceTypeID;
            try
            {
                if (_oSalesInvoiceInfo.InvoiceTypeID == 12 || _oSalesInvoiceInfo.InvoiceTypeID == 8)
                {
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
                    PrintProductReturn();
                }
                else
                {
                    throw new Exception("It is applicable for product return status");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }
        public void PrintVatChallan(SalesInvoice oSalesInvoice, int nType)
        {

            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshByInvoiceIDHOReport();

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranIDForHO(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID, nType);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                double _TotalVatAmount = 0;
                rptSalesInvoice oSI = new rptSalesInvoice();
                oSI.GetInvoiceStatusByID(oSalesInvoice.InvoiceID);
                //if (nType == (int)Dictionary.ChallanType.VAT_63)
                //{
                //    oDutyTran.GetVATReportPOSNew(oSI.InvoiceStatus);
                //}
                //else
                //{
                _TotalVatAmount = oDutyTran.GetVATReportHO(oSI.InvoiceStatus);
                //}

                if (oDutyTran.ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_7)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVatReportMushak67));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("NationalID", _orptSalesInvoice.NationalID.ToString());
                    DutyTran oItemDetail = new DutyTran();
                    oItemDetail.GetRevVatDataforDI(Convert.ToInt32(_orptSalesInvoice.RefInvoiceID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("CustomerBINNo", _orptSalesInvoice.TaxNo.ToString());
                    //CustomerBINNo
                    doc.SetParameterValue("OldVatchalanNo", oItemDetail.DutyTranNo);
                    doc.SetParameterValue("OldDaliveryDate", oItemDetail.DutyTranDate.ToString("dd-MMM-yyyy"));

                    //SystemInfo oAddress = new SystemInfo();
                    //oAddress.Refresh();

                    doc.SetParameterValue("WarehouseName", "Central Warehouse");
                    doc.SetParameterValue("BINNo", "000002186");
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

        public void PrintVatChallanNew(SalesInvoice oSalesInvoice, int nType)
        {

            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshByInvoiceIDHOReport();

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranIDForHO(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID, nType);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                double _TotalVatAmount = 0;
                rptSalesInvoice oSI = new rptSalesInvoice();
                oSI.GetInvoiceStatusByID(oSalesInvoice.InvoiceID);

               // _TotalVatAmount = oDutyTran.GetVATReportHO(oSI.InvoiceStatus);

                if (oDutyTran.ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_7)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewVatReportMushak67));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("NationalID", _orptSalesInvoice.NationalID.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("CustomerBINNo", _orptSalesInvoice.TaxNo.ToString());
                    doc.SetParameterValue("OldVatchalanNo", "");
                    doc.SetParameterValue("OldDaliveryDate", "");

                    SystemInfo oAddress = new SystemInfo();
                    oAddress.RefreshHOWithWH(oSalesInvoice.WarehouseID);
                    doc.SetParameterValue("WarehouseAddress", oAddress.WarehouseAddress);
                    doc.SetParameterValue("WarehouseName", oAddress.WarehouseName);
                    doc.SetParameterValue("BINNo", oAddress.VATRegistrationNo);
                    doc.SetParameterValue("CRVatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ReturnRemarks", "");
                    doc.SetParameterValue("TotalVatAmount", _TotalVatAmount);
                    doc.SetParameterValue("Copy", "1st Copy");
                    //ReturnRemarks

                    doc.SetParameterValue("VehicleNumber", "");

                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }
                
            }

        }
        private void btnCreditNote_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            if (_oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE || _oSalesInvoiceInfo.InvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
            {

                DutyTran oDutyTran = new DutyTran();

                SalesInvoiceInfo oSI = new SalesInvoiceInfo();
                oSI.GetRefInvoiceID(Convert.ToInt32(_oSalesInvoiceInfo.InvoiceID));

                if (oDutyTran.CheckDutyHOTran((int)Dictionary.DutyAccountNew.MUSHAK_6_7, Convert.ToInt32(_oSalesInvoiceInfo.InvoiceID)))
                {
                    //MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                    this.Cursor = Cursors.WaitCursor;

                    #region Duty Reverse
                    if (Utility.CompanyInfo == "TEL")
                    {

                        DutyTranList oDutyTranList = new DutyTranList();
                        oDutyTranList.RefreshForHo(Convert.ToInt32(oSI.RefInvoiceID), oSI.InvoiceNo);
                        foreach (DutyTran oDutyTrans in oDutyTranList)
                        {
                            DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                            DateTime time = DateTime.Now;
                            DateTime combine = day.Add(time.TimeOfDay);
                            DutyTran _oDutyTran = new DutyTran();

                            _oDutyTran.DutyTranDate = Convert.ToDateTime(combine);
                            _oDutyTran.WHID = oDutyTrans.WHID;
                            _oDutyTran.ChallanTypeID = (int)Dictionary.ChallanType.VAT_6_7;
                            _oDutyTran.DocumentNo = _oSalesInvoiceInfo.InvoiceNo;
                            _oDutyTran.RefID = Convert.ToInt32(_oSalesInvoiceInfo.InvoiceID);
                            _oDutyTran.DutyTypeID = oDutyTrans.DutyTypeID;
                            _oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.CREDIT_NOTE;
                            _oDutyTran.Remarks = _oSalesInvoiceInfo.Remarks;
                            _oDutyTran.Amount = oDutyTrans.Amount;
                            _oDutyTran.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_7;

                            _oDutyTran.InsertHOCreditNote();
                            int nNewDutyTranID = 0;
                            nNewDutyTranID = _oDutyTran.DutyTranID;

                            _oDutyTran.DutyTranID = oDutyTrans.DutyTranID;
                            _oDutyTran.RefreshDetailForHOVatNew(_oSalesInvoiceInfo.InvoiceID);
                            double _TotalVat = 0;
                            foreach (DutyTranDetail oDutyTranDetail in _oDutyTran)
                            {
                                oDutyTranDetail.DutyTranID = nNewDutyTranID;
                                oDutyTranDetail.InsertNewVATHO();
                                _TotalVat = _TotalVat + oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate * oDutyTranDetail.Qty;
                            }

                            _oDutyTran.Amount = _TotalVat;
                            _oDutyTran.UpdateToatlVATAmountHO();
                            DutyAccount oDutyAccount = new DutyAccount();
                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_7;
                            oDutyAccount.Balance = _oDutyTran.Amount;
                            oDutyAccount.UpdateBalanceForPOS(false);
                        }

                    }

                    #endregion

                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
                    _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
                    SystemInfo oIsVatActive = new SystemInfo();
                    oIsVatActive.NewVatActive();

                    if (oIsVatActive.IsNewVat == 1 && DateTime.Now.Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
                    {
                        PrintVatChallanNew(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    SystemInfo oIsVatActive = new SystemInfo();
                    oIsVatActive.NewVatActive();

                    this.Cursor = Cursors.WaitCursor;
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.InvoiceID = _oSalesInvoiceInfo.InvoiceID;
                    _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
                    if (oIsVatActive.IsNewVat == 1 && DateTime.Now.Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
                    {
                        PrintVatChallanNew(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
                        this.Cursor = Cursors.Default;
                    }
                    //PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_6_7);
                    //this.Cursor = Cursors.Default;
                }


            }
            else
            {
                MessageBox.Show("Please Select a reverse invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrintWarrantyCard_Click(object sender, EventArgs e)
        {

            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;

            RetailConsumer oRetailConsumer = new RetailConsumer();
            if (_oSalesInvoiceInfo.SundryCustomerID != 0)
            {
                oRetailConsumer.ConsumerID = _oSalesInvoiceInfo.SundryCustomerID;
                oRetailConsumer.WarehouseID = _oSalesInvoiceInfo.WarehouseID;
                oRetailConsumer.Refresh();
            }
            frmPrintWarrantyCard ofrmPrintWarrantyCard = new frmPrintWarrantyCard(_oSalesInvoiceInfo, oRetailConsumer);
            ofrmPrintWarrantyCard.ShowDialog();
        }
    }
}