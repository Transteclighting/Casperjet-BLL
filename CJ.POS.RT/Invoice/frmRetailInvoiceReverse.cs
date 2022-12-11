using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Class.Duty;

namespace CJ.POS.RT.Invoice
{
    public partial class frmRetailInvoiceReverse : Form
    {
        TELLib _oTELLib;
        RetailConsumer _oRetailConsumer;
        RetailSalesInvoice _oRetailSalesInvoice;
        RetailSalesInvoices _oRetailSalesInvoices;
        SalesInvoice _oSelectedSalesInvoice;
        SalesInvoice _oReversrSalesInvoice;
        StockTran _oStockTran;
        CustomerTransaction _oCustomerTransaction;
        ProductStock _oProductStock;
        PaymentMode _oPaymentMode;
        double _TotalRSP;
        long nInvoiceID;
        int nInvoiceTypeID = 0;
        int nWarehouseID = 0;
        public frmRetailInvoiceReverse()
        {
            InitializeComponent();
        }
        public void ShowDialog(SalesInvoice oSalesInvoice)
        {
            nWarehouseID = 0;
            nWarehouseID = oSalesInvoice.WarehouseID;
            nInvoiceID = 0;
            nInvoiceID = oSalesInvoice.InvoiceID;
            _oTELLib = new TELLib();
            lblInvoiceNo.Text = oSalesInvoice.InvoiceNo;
            lblInvoiceDate.Text = Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy");
            lblDiscount.Text = _oTELLib.TakaFormat(oSalesInvoice.Discount);

            _oRetailConsumer = new RetailConsumer();
            _oRetailConsumer.CustomerID = oSalesInvoice.CustomerID;
            _oRetailConsumer.ConsumerID = Convert.ToInt32(oSalesInvoice.SundryCustomerID);
            _oRetailConsumer.RefreshForPOS();

            lblConsumerName.Text = _oRetailConsumer.ConsumerName;
            lblConsumerAddress.Text = _oRetailConsumer.Address;
            lblMobile.Text = _oRetailConsumer.CellNo;
            lblEmail.Text = _oRetailConsumer.Email;

            double _Amt = 0;
            double _DisAmt = 0;
            double _Charge = 0;
            lblInvoiceAmount.Text = _oTELLib.TakaFormat(oSalesInvoice.InvoiceAmount);
            oSalesInvoice.RefreshReverseInvoiceItemNew();

            foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesInvoiceItem.ProductCode.ToString();
                oRow.Cells[1].Value = oSalesInvoiceItem.ProductName.ToString();
                oRow.Cells[2].Value = _oTELLib.TakaFormat(oSalesInvoiceItem.UnitPrice).ToString();
                oRow.Cells[3].Value = _oTELLib.TakaFormat(oSalesInvoiceItem.PromotionalDiscount).ToString();
                oRow.Cells[4].Value = oSalesInvoiceItem.Quantity.ToString();
                oRow.Cells[5].Value = oSalesInvoiceItem.FreeQty.ToString();
                oRow.Cells[6].Value = oSalesInvoiceItem.ProductID.ToString();
                oRow.Cells[7].Value = oSalesInvoiceItem.TotalCharge.ToString();
                oRow.Cells[8].Value = oSalesInvoiceItem.TotalDiscount.ToString();
                oRow.Cells[9].Value = oSalesInvoiceItem.CostPrice.ToString();
                oRow.Cells[10].Value = oSalesInvoiceItem.VATAmount.ToString();
                oRow.Cells[11].Value = oSalesInvoiceItem.TradePrice.ToString();

                dgvLineItem.Rows.Add(oRow);
                _Amt = _Amt + oSalesInvoiceItem.UnitPrice * oSalesInvoiceItem.Quantity;
                _Charge = _Charge + oSalesInvoiceItem.TotalCharge;
            }
            lblRetailSalesAmt.Text = _oTELLib.TakaFormat(_Amt);
            lbChange.Text = _oTELLib.TakaFormat(_Charge);

            this.Tag = oSalesInvoice;

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UIValidation()
        {
            if (txtReverseReason.Text.Trim() == "")
            {
                MessageBox.Show("Please input Reverse reason", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }
            return true;
        }

        private int AddSalesInvoiceConsumer(RetailConsumer oRetailConsumer)
        {
            RetailConsumer oSalesInvoiceConsumer = new RetailConsumer();
            oSalesInvoiceConsumer.InvoiceID = nInvoiceID;
            oSalesInvoiceConsumer.ConsumerCode = oRetailConsumer.ConsumerCode;
            oSalesInvoiceConsumer.ConsumerName = oRetailConsumer.ConsumerName;
            oSalesInvoiceConsumer.ConsumerType = oRetailConsumer.ConsumerType;

            oSalesInvoiceConsumer.CustomerID = oRetailConsumer.CustomerID;

            oSalesInvoiceConsumer.ParentCustomerID = oRetailConsumer.ParentCustomerID;
            oSalesInvoiceConsumer.Address = oRetailConsumer.Address;
            oSalesInvoiceConsumer.CellNo = oRetailConsumer.CellNo;
            oSalesInvoiceConsumer.PhoneNo = oRetailConsumer.PhoneNo;
            oSalesInvoiceConsumer.Email = oRetailConsumer.Email;
            oSalesInvoiceConsumer.EmployeeCode = oRetailConsumer.EmployeeCode;
            oSalesInvoiceConsumer.NationalID = oRetailConsumer.NationalID;

            oSalesInvoiceConsumer.DateofBirth = oRetailConsumer.DateofBirth;
            oSalesInvoiceConsumer.VatRegNo = oRetailConsumer.VatRegNo;
            oSalesInvoiceConsumer.SalesType = oRetailConsumer.SalesType;
            oSalesInvoiceConsumer.DeliveryAddress = oRetailConsumer.DeliveryAddress;
            oSalesInvoiceConsumer.IsVerifiedEmail = oRetailConsumer.IsVerifiedEmail;

            oSalesInvoiceConsumer.SecondaryConsumer = oRetailConsumer.SecondaryConsumer;
            oSalesInvoiceConsumer.SecondaryMobileNo = oRetailConsumer.SecondaryMobileNo;
            oSalesInvoiceConsumer.AddSalesInvoiceConsumer();
            return oSalesInvoiceConsumer.ConsumerID;
        }
        private void btReverse_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Reverse();
                this.Close();
            }
        }
        private void Reverse()
        {
            try
            {
                _oTELLib = new TELLib();
                DBController.Instance.BeginNewTransaction();
                double _DueAmount = 0;
                _oSelectedSalesInvoice = new SalesInvoice();
                _oSelectedSalesInvoice.InvoiceID = nInvoiceID;
                _oSelectedSalesInvoice.RefreshForReverseInvoice();
                _DueAmount = _oSelectedSalesInvoice.DueAmount;

                #region SalesInvoice and SalesInvoiceDetail
                _oReversrSalesInvoice = new SalesInvoice();
                _oReversrSalesInvoice = GetDataForSalesInvoice(_oReversrSalesInvoice, _oSelectedSalesInvoice);
                _oReversrSalesInvoice.UpdateDueAmount(_oSelectedSalesInvoice.InvoiceID);
                _oReversrSalesInvoice.InsertPOSInvoiceRT();

                
                RetailSalesInvoices oRetailSalesInvoices = new RetailSalesInvoices();
                oRetailSalesInvoices.GetInvoiceDiscountChargeAll(nInvoiceID);
                foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
                {

                    SalesInvoiceItem oDiscountCharge = new SalesInvoiceItem();
                    oDiscountCharge.InvoiceID = _oReversrSalesInvoice.InvoiceID;
                    oDiscountCharge.ProductID = oRetailSalesInvoice.ProductID;
                    oDiscountCharge.WarehouseID = _oReversrSalesInvoice.WarehouseID;
                    oDiscountCharge.DiscountTypeID = oRetailSalesInvoice.DiscountTypeID;
                    oDiscountCharge.Amount = oRetailSalesInvoice.Amount;
                    try
                    {
                        oDiscountCharge.InstrumentNo = oRetailSalesInvoice.InstrumentNo;
                    }
                    catch
                    {
                        oDiscountCharge.InstrumentNo = "";
                    }
                    try
                    {
                        oDiscountCharge.Description = oRetailSalesInvoice.Description;
                    }
                    catch
                    {
                        oDiscountCharge.Description = "";
                    }
                    if (oDiscountCharge.Amount > 0)
                        oDiscountCharge.AddDiscountCharge();

                }

                _oRetailSalesInvoices = new RetailSalesInvoices();
                _oRetailSalesInvoices.GetSaleInvoicePaymentMode(Convert.ToInt32(nInvoiceID));

                foreach (RetailSalesInvoice oRetailSalesInvoice in _oRetailSalesInvoices)
                {
                    oRetailSalesInvoice.InvoiceID = _oReversrSalesInvoice.InvoiceID;
                    oRetailSalesInvoice.InsertPayMode();
                    #region Approved Credit Data Update
                    if (oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                    {
                        CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                        oCustomerCreditApproval.ApprovalNo = oRetailSalesInvoice.InstrumentNo;
                        oCustomerCreditApproval.InvoicedAmount = oRetailSalesInvoice.Amount;
                        oCustomerCreditApproval.UpdateInvoicedAmount(false);
                    }
                    #endregion
                }


                _oRetailSalesInvoices = new RetailSalesInvoices();
                _oRetailSalesInvoices.GetSaleInvoicePaymentModeNew(Convert.ToInt32(nInvoiceID));

                foreach (RetailSalesInvoice oRetailSalesInvoice in _oRetailSalesInvoices)
                {
                    oRetailSalesInvoice.InvoiceID = _oReversrSalesInvoice.InvoiceID;
                    oRetailSalesInvoice.InsertPayModeNew();
                }

                #endregion

                #region Duty Reverse
                if (Utility.CompanyInfo == "TEL")
                {


                    DutyTranList oDutyTranList = new DutyTranList();
                    oDutyTranList.Refresh(Convert.ToInt32(nInvoiceID), Utility.WarehouseID);

                    foreach (DutyTran oDutyTran in oDutyTranList)
                    {
                        DateTime day = _oTELLib.ServerDateTime().Date; 
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);

                        DutyTran _oDutyTran = new DutyTran();

                        _oDutyTran.DutyTranDate = Convert.ToDateTime(combine);
                        _oDutyTran.WHID = oDutyTran.WHID;
                        _oDutyTran.ChallanTypeID = (int)Dictionary.ChallanType.VAT_6_7;
                        _oDutyTran.DocumentNo = _oReversrSalesInvoice.InvoiceNo;
                        _oDutyTran.RefID = Convert.ToInt32(_oReversrSalesInvoice.InvoiceID);
                        _oDutyTran.DutyTypeID = oDutyTran.DutyTypeID;
                        _oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.CREDIT_NOTE; 
                        _oDutyTran.Remarks = txtReverseReason.Text;
                        _oDutyTran.Amount = oDutyTran.Amount;
                        _oDutyTran.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_7;
                        _oDutyTran.VehicleDetail = oDutyTran.VehicleDetail;
                        _oDutyTran.InsertForPOSNew(Utility.WarehouseCode);
                        int nNewDutyTranID = 0;
                        nNewDutyTranID = _oDutyTran.DutyTranID;

                        _oDutyTran.DutyTranID = oDutyTran.DutyTranID;
                        _oDutyTran.RefreshDetailForNewVat();

                        foreach (DutyTranDetail oDutyTranDetail in _oDutyTran)
                        {
                            oDutyTranDetail.DutyTranID = nNewDutyTranID;
                            DutyTran oVatPaidData = new DutyTran();
                            oDutyTranDetail.VATPaidQty = oVatPaidData.GetVATPaidQty(oDutyTranDetail.ProductID, lblInvoiceNo.Text);

                            oDutyTranDetail.InsertForPOSNew();

                        }


                        DutyAccount oDutyAccount = new DutyAccount();
                        if (_oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                        {

                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                            oDutyAccount.Balance = _oDutyTran.Amount;
                            oDutyAccount.UpdateBalanceForPOS(false);
                        }
                        else if (_oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                        {

                            oDutyAccount.DutyAccountTypeID = 3;
                            oDutyAccount.Balance = _oDutyTran.Amount;
                            oDutyAccount.UpdateBalanceForPOS(false);
                        }
                        else if (_oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_6_7)
                        {

                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_7;
                            oDutyAccount.Balance = _oDutyTran.Amount;
                            oDutyAccount.UpdateBalanceForPOS(true);
                        }
                        else
                        {
                            oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                            oDutyAccount.Balance = _oDutyTran.Amount;
                            oDutyAccount.UpdateBalanceForPOS(false);
                        }
                    }

                }

                #endregion

                #region Update Product Stock Serial, Insert History and Delete Sales Invoice Product Serial

                foreach (SalesInvoiceProductSerial oSalesInvoiceProductSerial in _oSelectedSalesInvoice.SalesInvoiceProductSerials)
                {
                    ProductBarcode _oProductBarcode = new ProductBarcode();
                    _oProductBarcode.ProductSerialNo = oSalesInvoiceProductSerial.ProductSerialNo;
                    _oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                    _oProductBarcode.UpdateProductSerial();
                    
                    //update Vat Paid Data
                    Product oProduct = new Product();
                    oProduct.ProductID = oSalesInvoiceProductSerial.ProductID;
                    oProduct.RefreshByID();
                    _oProductBarcode.UpdateVatPaidProductSerial(Utility.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, _oReversrSalesInvoice.InvoiceNo, Convert.ToDateTime(_oReversrSalesInvoice.InvoiceDate));


                    //Insert Product Serial History
                    _oProductBarcode.GetProductSerialID(_oProductBarcode.ProductSerialNo);
                    _oProductBarcode.FromWHID = Utility.WarehouseID;
                    _oProductBarcode.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                    _oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                    _oProductBarcode.CreateDate = _oTELLib.ServerDateTime().Date; 
                    _oProductBarcode.InsertProductSerialHistory();
                }

                //Delete Barcode from t_SalesInvoiceProductSerial Table by InvoiceID
                SalesInvoiceProductSerial oSIPS = new SalesInvoiceProductSerial();
                oSIPS.InvoiceID = nInvoiceID;
                oSIPS.DeleteIMEI();

                #endregion

                #region Insert in Customer Transaction and Update Customer Account.
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

                #region Customer Transaction and Update Customer Account

                _oCustomerTransaction = new CustomerTransaction();
                _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oReversrSalesInvoice, _DueAmount);
                _oCustomerTransaction.RetailInsertForReverseRT(Utility.WarehouseID);

                #endregion

                #region Product Stock Transaction and Stock Update

                _oStockTran = new StockTran();
                _oStockTran = SetData(_oStockTran, _oReversrSalesInvoice);
                _oStockTran.UserID = Utility.UserId;
                _oStockTran.InsertForReverse();

                foreach (StockTranItem oItem in _oStockTran)
                {
                    _oProductStock = new ProductStock();
                    _oProductStock.ProductID = oItem.ProductID;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.WarehouseID = _oStockTran.ToWHID;
                    _oProductStock.ChannelID = _oStockTran.ToChannelID;

                    _oProductStock.UpdateCurrentStock(true);
                    if (_oProductStock.Flag == false)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("There is no Product in ProductStock table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                //_oRetailConsumer = new RetailConsumer();
                //_oRetailConsumer.ConsumerID = (int)_oReversrSalesInvoice.SundryCustomerID;
                //_oRetailConsumer.CustomerID = _oReversrSalesInvoice.CustomerID;
                //if (_oRetailConsumer.CheckCLPConsumer())
                //{

                //}
                //else
                //{
                //    //CalculateCLP(oReversrSalesInvoice);
                //}
                #endregion

                #region Reverse Apply Status Update
                InvoiceReverse oGetData= new InvoiceReverse();
                oGetData.GetApprovedInvoice(lblInvoiceNo.Text.Trim());
                if (oGetData.Count > 0)
                {
                    InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                    oInvoiceReverse.ReverseID = oGetData.ReverseID;
                    oInvoiceReverse.Status = (int)Dictionary.ReverseStatus.Reversed;
                    oInvoiceReverse.InvoiceNo = lblInvoiceNo.Text;
                    oInvoiceReverse.UpdateStatus();
                }               
                #endregion

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Reverse Successfully", "Reverse", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public SalesInvoice GetDataForSalesInvoice(SalesInvoice oReversrSalesInvoice, SalesInvoice oSelectedSalesInvoice)
        {
            nInvoiceTypeID = 0;
            _oTELLib = new TELLib();
            oReversrSalesInvoice.InvoiceDate = _oTELLib.ServerDateTime().Date;
            oReversrSalesInvoice.CustomerID = oSelectedSalesInvoice.CustomerID;
            oReversrSalesInvoice.DeliveryAddress = oSelectedSalesInvoice.DeliveryAddress;
            oReversrSalesInvoice.DeliveryDate = oSelectedSalesInvoice.DeliveryDate;
            oReversrSalesInvoice.SalesPersonID = oSelectedSalesInvoice.SalesPersonID;
            oReversrSalesInvoice.InvoiceStatus = (int)Dictionary.InvoiceStatus.REVERSE;
            oReversrSalesInvoice.WarehouseID = oSelectedSalesInvoice.WarehouseID;
            oReversrSalesInvoice.Discount = oSelectedSalesInvoice.Discount;
            oReversrSalesInvoice.Remarks = txtReverseReason.Text;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CASH_REVERSE;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CREDIT)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CREDIT_REVERSE;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EASY_BUY)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.EASY_BUY_REVERSE;
            if (oSelectedSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
                oReversrSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.EPS_REVERSE;
            nInvoiceTypeID = oReversrSalesInvoice.InvoiceTypeID;
            oReversrSalesInvoice.UserID = Utility.UserId;
            oReversrSalesInvoice.InvoiceAmount = oSelectedSalesInvoice.InvoiceAmount;
            oReversrSalesInvoice.PriceOptionID = oSelectedSalesInvoice.PriceOptionID;
            oReversrSalesInvoice.OtherCharge = oSelectedSalesInvoice.OtherCharge;
            oReversrSalesInvoice.SundryCustomerID = oSelectedSalesInvoice.SundryCustomerID;
            oReversrSalesInvoice.RefInvoiceID = oSelectedSalesInvoice.InvoiceID.ToString();
            oReversrSalesInvoice.CreateDate = _oTELLib.ServerDateTime().Date;
            oReversrSalesInvoice.DueAmount = oSelectedSalesInvoice.DueAmount;
            if (dgvLineItem.Rows.Count > 0)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count)
                    {
                        SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();
                        _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                        _oSalesInvoiceItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        _oSalesInvoiceItem.CostPrice = Convert.ToDouble(oItemRow.Cells[9].Value.ToString());
                        _oSalesInvoiceItem.VATAmount = Convert.ToDouble(oItemRow.Cells[10].Value.ToString());
                        _oSalesInvoiceItem.TradePrice = Convert.ToDouble(oItemRow.Cells[11].Value.ToString());
                        _oSalesInvoiceItem.AdjustedDPAmount = 0;
                        _oSalesInvoiceItem.AdjustedPWAmount = 0;
                        _oSalesInvoiceItem.AdjustedTPAmount = 0;
                        _oSalesInvoiceItem.PromotionalDiscount = 0;
                        _oSalesInvoiceItem.IsFreeProduct = 0;
                        _oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                        _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString());
                        _oSalesInvoiceItem.TotalCharge = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                        _oSalesInvoiceItem.TotalDiscount = Convert.ToDouble(oItemRow.Cells[8].Value.ToString());

                        if (_oSalesInvoiceItem.IsFreeProduct != 1)
                        {
                            _TotalRSP = _TotalRSP + _oSalesInvoiceItem.UnitPrice;
                        }
                        oReversrSalesInvoice.Add(_oSalesInvoiceItem);


                    }
                }
            }
            
            return oReversrSalesInvoice;
        }
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
        {
            _oTELLib = new TELLib();
            _oCustomerTransaction.CustomerID = _oReversrSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oReversrSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = _oTELLib.ServerDateTime().Date; 
            _oCustomerTransaction.Amount = _oReversrSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oReversrSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = (int)Dictionary.Terminal.Branch_Office;
            _oCustomerTransaction.Remarks = txtReverseReason.Text;
            _oCustomerTransaction.UserID = Utility.UserId;

            if (nInvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE_REVERSE;
            }
            else if (nInvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.EPS_INVOICE_REVERSE;
            }
            else
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE_REVERSE;
            }

            return _oCustomerTransaction;
        }
        public CustomerTransaction GetCustomerTranForCollection(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice,double _DueAmount)
        {
            _oTELLib = new TELLib();
            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranDate = _oTELLib.ServerDateTime().Date;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount - _DueAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
            _oCustomerTransaction.Remarks =txtReverseReason.Text;

            if (nInvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_RECEIVE_REVERSE;
            }
            else if (nInvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.EPS_INVOICE_REVERSE;
            }
            else
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE;
            }
            _oCustomerTransaction.EntryLocationID = Utility.LocationID;
            return _oCustomerTransaction;
        }
        public StockTran SetData(StockTran oStockTran, SalesInvoice _oSalesInvoice)
        {
            _oTELLib = new TELLib();
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.FromChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
            oStockTran.FromWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;

            oStockTran.ToChannelID = Utility.ChannelID;
            oStockTran.ToWHID = _oSalesInvoice.WarehouseID;

            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = _oTELLib.ServerDateTime().Date; 

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                oItem.Qty = oSalesInvoiceItem.FreeQty + oSalesInvoiceItem.Quantity;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }
    }
}