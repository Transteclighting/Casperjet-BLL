using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.Duty;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.POS
{
    public partial class frmStockTransfer : Form
    {

        POSRequisition _oPOSRequisition;
        SystemInfo oSystemInfo;
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        Product _oProduct;
        StockTran _oStockTran;
        Warehouses _oWarehouses;
        Warehouse _oWarehouse;
        ProductBarcode _oProductBarcode;
        DutyTran oDutyTranVAT63;
        DutyTran oDutyTranVATExampled;
        DutyTran oDutyTranVAT65_15;
        DutyTran oDutyTranVAT65_5;

        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        DutyAccount oDutyAccount;
        private double _NewDutyBalance = 0;
        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;

        //SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        //SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        ProductTransferProductSerial _oProductTransferProductSerial;
        ProductTransferProductSerials _oProductTransferProductSerials;

        int nUIControl = 0;
        TELLib oTELLib;
        int nRequisitionID = 0;
        int nToWHID = 0;
        string sRequisitionNo = "";
        string sSplit = "";
        int InitializeCondition = 0;
        int nFromWHID = 0;


        public frmStockTransfer()
        {
            InitializeComponent();
        }

        public StockTran GetDataForProductStockTran(StockTran _oStockTran)
        {
            _oStockTran.TranNo = sRequisitionNo;
            _oStockTran.FromWHID = nToWHID;
            _oStockTran.LastUpdateDate = DateTime.Now;
            _oStockTran.CreateDate = DateTime.Now;
            _oStockTran.TranDate = DateTime.Now.Date;
            _oStockTran.FromChannelID = Utility.TDRetailChannelID;
            _oStockTran.ToWHID = nFromWHID;
            _oStockTran.ToChannelID = Utility.TDRetailChannelID;
            _oStockTran.Status = (int)Dictionary.StockTransactionStatus.COMPLETE;
            _oStockTran.UserID = Utility.UserId;
            _oStockTran.Remarks = txtRemarks.Text;


            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.GetPriceByProductID(int.Parse(oItemRow.Cells[5].Value.ToString()));

                    StockTranItem _oStockTranItem = new StockTranItem();

                    _oStockTranItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oStockTranItem.StockPrice = _oProductDetail.RSP;
                    _oStockTranItem.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());

                    _oStockTran.Add(_oStockTranItem);
                }
            }

            return _oStockTran;
        }
        private void btIMEIValid_Click(object sender, EventArgs e)
        {
            int IMEIQty = 0;
            if (txtIMEIList.Text.Trim() != "")
            {
                if (InitializeCondition == 0)
                {
                    _oProductTransferProductSerials = new ProductTransferProductSerials();
                }
                _oProductTransferProductSerial = new ProductTransferProductSerial();
                string value = txtIMEIList.Text;
                char[] delimiter = new char[] { '\r', '\n' };
                string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {

                    sSplit = parts[i].ToString();

                    _oProductTransferProductSerial = new ProductTransferProductSerial();
                    _oProductTransferProductSerial.ProductSerialNo = sSplit.Trim();
                    DBController.Instance.OpenNewConnection();
                    _oProductTransferProductSerial.WarehouseID = nToWHID;
                    _oProductTransferProductSerial.GetUnusedBarcodeHoNew();
                    DBController.Instance.CloseConnection();

                    if (dgvLineItem.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Cells[3].Value != null)
                            {
                                if ((oItemRow.Cells[0].Value.ToString().Trim()) == _oProductTransferProductSerial.ProductCode)
                                {

                                    if (oItemRow.Cells[4].Value == null)
                                    {
                                        IMEIQty = 0;
                                        if (IMEIQty <= Convert.ToInt32(oItemRow.Cells[3].Value))
                                        {
                                            oItemRow.Cells[4].Value = IMEIQty + 1;

                                            _oProductTransferProductSerial.ProductID = _oProductTransferProductSerial.ProductID;
                                            _oProductTransferProductSerial.ProductSerialNo = sSplit;
                                            _oProductTransferProductSerials.Add(_oProductTransferProductSerial);

                                            InitializeCondition = 1;
                                        }

                                    }
                                    else
                                    {

                                        if (IMEICheckFromCollection())
                                        {
                                            if (Convert.ToInt32(oItemRow.Cells[4].Value) < Convert.ToInt32(oItemRow.Cells[3].Value))
                                            {
                                                oItemRow.Cells[4].Value = Convert.ToInt32(oItemRow.Cells[4].Value) + 1;

                                                _oProductTransferProductSerial.ProductID = _oProductTransferProductSerial.ProductID;
                                                _oProductTransferProductSerial.ProductSerialNo = sSplit;
                                                _oProductTransferProductSerials.Add(_oProductTransferProductSerial);
                                            }


                                        }
                                        else
                                        {
                                        }
                                    }

                                }

                            }

                        }

                    }

                }
                txtIMEIList.Text = "";
            }
            else
            {
                MessageBox.Show("There is no Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool IMEICheckFromCollection()
        {
            foreach (ProductTransferProductSerial oSIPS in _oProductTransferProductSerials)
            {
                if (oSIPS.ProductSerialNo != sSplit)
                {
                    return true;
                }
            }

            return false;
        }

        private void SaveRT()
        {

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oPOSRequisition = new POSRequisition();

                _oStockTran = new StockTran();
                _oStockTran = GetDataForProductStockTran(_oStockTran);
                _oStockTran.TranTypeID = (int)Dictionary.ProductStockTranType.TRANSFER;
                //Insert t_ProductStockTran/t_ProductStockTranItem/Stock Add and Update/t_DataTransfer
                _oStockTran.InsertTranBranchRTTranferHO(true);

                _oPOSRequisition.StockTranID = _oStockTran.TranID;
                _oPOSRequisition.RequisitionID = nRequisitionID;
                //Update t_StockRequisition/StockTranID from t_ProductStockTran
                _oPOSRequisition.UpdateStockTranID_POS();
                
                //Update t_StockRequisition Status
                _oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Transfer_To_Branch;
                _oPOSRequisition.UpdateStatus();

                //Update t_StockRequisition Transfer
                _oPOSRequisition.TransferedBy = Utility.UserId;
                _oPOSRequisition.TransferDate = DateTime.Now;
                _oPOSRequisition.TransferRemarks = txtRemarks.Text;
                _oPOSRequisition.TransferUpdate();


                #region New Duty
                if (Utility.CompanyInfo == "TEL")
                {
                    InsertVAT65(_oStockTran.TranID, _oStockTran.TranNo, nRequisitionID);
                }
                #endregion

                if (_oProductTransferProductSerials != null)
                {
                    ProductBarcode _oMAXID = new ProductBarcode();
                    int nID = _oMAXID.GetMaxID();

                    foreach (ProductTransferProductSerial oPTPS in _oProductTransferProductSerials)
                    {
                        //Insert t_ProductTransferProductSerial
                        if (Utility.CompanyInfo == "TEL")
                        {
                            oPTPS.DeleteFromHO();
                            oPTPS.InsertTELHQ(_oStockTran.TranID);

                            SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                            oChkVatPaidProductSerial.ProductSerialNo = oPTPS.ProductSerialNo;
                            if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                            {

                                ProductBarcode _oProductBarcode = new ProductBarcode();
                                _oProductBarcode.VatPaidID = nID;
                                _oProductBarcode.ProductId = oPTPS.ProductID;
                                _oProductBarcode.WarehouseID = _oStockTran.ToWHID;
                                _oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                                _oProductBarcode.TranNo = _oStockTran.TranNo;
                                _oProductBarcode.TranDate = Convert.ToDateTime(_oStockTran.TranDate);
                                _oProductBarcode.Status = 1;
                                _oProductBarcode.InsertVatPaidProductSerial();

                                Product oProduct = new Product();
                                oProduct.ProductID = oPTPS.ProductID;
                                oProduct.RefreshByID();

                                ProductBarcode oProductBarcodeUpdate = new ProductBarcode();
                                oProductBarcodeUpdate.Status = (int)Dictionary.ProductSerialStatus.Send_from_HO_to_Outlet;
                                oProductBarcodeUpdate.ProductSerialNo = oPTPS.ProductSerialNo;
                                oProductBarcodeUpdate.UpdateVatPaidProductSerial(_oStockTran.FromWHID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.TRANSFER, _oStockTran.TranNo, Convert.ToDateTime(_oStockTran.TranDate));


                            }
                        }
                        else if (Utility.CompanyInfo == "TML")
                        {
                            oPTPS.InsertTML(_oStockTran.TranID);
                        }

                        _oProductBarcode = new ProductBarcode();

                        _oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_to_HO;
                        _oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                        _oProductBarcode.ProductId = oPTPS.ProductID;
                        _oProductBarcode.ProductStockTranID = _oStockTran.TranID;

                        _oProductBarcode.GetProductSerialID(oPTPS.ProductSerialNo);
                        if (_oProductBarcode.Found == false)
                        {
                            _oProductBarcode.InsertProductSerial();
                        }
                        else
                        {
                            _oProductBarcode.UpdateProductSerial();
                        }
                        _oProductBarcode.ToWHID = nFromWHID;
                        _oProductBarcode.CreateDate = DateTime.Now;
                        _oProductBarcode.FromWHID = nToWHID;
                        _oProductBarcode.InsertProductSerialHistory();

                    }
                }

                ProductStockTran oChkProductStockTran = new ProductStockTran();
                if (oChkProductStockTran.CheckStockTranItem(_oStockTran.TranID))
                {
                    if (oChkProductStockTran.CheckStockSerial(_oStockTran.TranID))
                    {
                        MessageBox.Show(@"Duplicate Product Serial", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(@"Product serial & tran qty not matched", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBController.Instance.CommitTran();
                MessageBox.Show(@"Success fully Transfer Stock against Requisition # " + sRequisitionNo, @"Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBoxWithDetails oErrorDetails = new MessageBoxWithDetails("An error occer in you appalication",
                    "Error", ex.ToString());
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (validateUIInput())
            {
                //Showroom oShowroom = new Showroom();
                //oShowroom.WarehouseID = nFromWHID;
                //if (oShowroom.RefreshForRT())
                //{
                //    SaveRT();
                //}
                //else
                //{
                    Save();
                //}
            }
        }
        private void Save()
        {

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oPOSRequisition = new POSRequisition();

                _oStockTran = new StockTran();
                _oStockTran = GetDataForProductStockTran(_oStockTran);

                _oStockTran.TranTypeID = (int)Dictionary.ProductStockTranType.TRANSFER;

                //Insert t_ProductStockTran/t_ProductStockTranItem/Stock Add and Update/t_DataTransfer

                _oStockTran.InsertTranBranch(true);

                _oPOSRequisition.StockTranID = _oStockTran.TranID;
                _oPOSRequisition.RequisitionID = nRequisitionID;
                //Update t_StockRequisition/StockTranID from t_ProductStockTran
                _oPOSRequisition.UpdateStockTranID_POS();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_StockRequisition";
                oDataTran.DataID = nRequisitionID;
                oDataTran.WarehouseID = nFromWHID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                if (oDataTran.CheckDataByType())
                {
                }
                else
                {
                    oDataTran.AddForTDPOS();
                }

                //Update t_StockRequisition Status
                _oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Transfer_To_Branch;
                _oPOSRequisition.UpdateStatus();

                //Update t_StockRequisition Transfer
                _oPOSRequisition.TransferedBy = Utility.UserId;
                _oPOSRequisition.TransferDate = DateTime.Now;
                _oPOSRequisition.TransferRemarks = txtRemarks.Text;
                _oPOSRequisition.TransferUpdate();


                #region New Duty
                if (Utility.CompanyInfo == "TEL")
                {

                    InsertVAT65(_oStockTran.TranID, _oStockTran.TranNo, nRequisitionID);
                    //SystemInfo oIsVatActive = new SystemInfo();
                    //oIsVatActive.NewVatActive();
                    //if (oIsVatActive.IsNewVat == 1 && Convert.ToDateTime(DateTime.Now).Date >= Convert.ToDateTime(oIsVatActive.NewVatActivationDate))
                    //{
                    //    InsertVAT65(_oStockTran.TranID, _oStockTran.TranNo, nRequisitionID);
                    //}
                    //else
                    //{
                    //    //DutyTran oDetail = new DutyTran();
                    //    //oDetail.GetDutyDetailNew("Transfer", Convert.ToInt32(_oStockTran.TranID));
                    //    //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DutyAccount)))
                    //    //{
                    //    //    if (GetEnum == (int)Dictionary.DutyAccount.MUSHAK_11)
                    //    //    {
                    //    //        double _TotalAmount = 0;
                    //    //        int countMUSHAK_11 = 0;
                    //    //        oDutyTranVAT11 = new DutyTran();
                    //    //        foreach (DutyTranDetail oDutyTranDetail in oDetail)
                    //    //        {
                    //    //            if (oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_15 || oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_15)
                    //    //            {
                    //    //                if (countMUSHAK_11 == 0)
                    //    //                {

                    //    //                    DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                    //    //                    DateTime time = DateTime.Now;
                    //    //                    DateTime combine = day.Add(time.TimeOfDay);
                    //    //                    oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(combine);
                    //    //                    oDutyTranVAT11.WHID = Utility.CentralRetailWarehouse;
                    //    //                    oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
                    //    //                    oDutyTranVAT11.DocumentNo = _oStockTran.TranNo;
                    //    //                    oDutyTranVAT11.RefID = int.Parse(_oStockTran.TranID.ToString());
                    //    //                    oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
                    //    //                    oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                    //    //                    oDutyTranVAT11.Remarks = txtRemarks.Text;
                    //    //                    oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;
                    //    //                    oDutyTranVAT11.Amount = 0;
                    //    //                    oDutyTranVAT11.InsertNewHOVAT();
                    //    //                    countMUSHAK_11++;
                    //    //                }

                    //    //                DutyTranDetail oItem = new DutyTranDetail();
                    //    //                oItem.DutyTranID = oDutyTranVAT11.DutyTranID;
                    //    //                oItem.ProductID = oDutyTranDetail.ProductID;
                    //    //                oItem.Qty = oDutyTranDetail.Qty;
                    //    //                oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                    //    //                oItem.DutyRate = oDutyTranDetail.DutyRate;
                    //    //                oItem.WHID = Utility.CentralRetailWarehouse;
                    //    //                oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    //    //                oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    //    //                oItem.VATType = oDutyTranDetail.VATType;
                    //    //                _TotalAmount = _TotalAmount + oItem.VAT;
                    //    //                oItem.InsertNewVATHO();

                    //    //            }

                    //    //        }
                    //    //        oDutyTranVAT11.Amount = _TotalAmount;
                    //    //        oDutyTranVAT11.UpdateToatlVATAmountHO();

                    //    //        oDutyAccount = new DutyAccount();
                    //    //        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                    //    //        oDutyAccount.Balance = _TotalAmount;
                    //    //        oDutyAccount.UpdateBalance(true);
                    //    //    }
                    //    //    else if (GetEnum == (int)Dictionary.DutyAccount.MUSHAK_11KA)
                    //    //    {
                    //    //        int countMUSHAK_11KA = 0;
                    //    //        double _TotalAmount = 0;
                    //    //        oDutyTranVAT11KA = new DutyTran();
                    //    //        foreach (DutyTranDetail oDutyTranDetail in oDetail)
                    //    //        {
                    //    //            if (oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_5)
                    //    //            {
                    //    //                if (countMUSHAK_11KA == 0)
                    //    //                {

                    //    //                    DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                    //    //                    DateTime time = DateTime.Now;
                    //    //                    DateTime combine = day.Add(time.TimeOfDay);
                    //    //                    oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(combine);
                    //    //                    oDutyTranVAT11KA.WHID = Utility.CentralRetailWarehouse;
                    //    //                    oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
                    //    //                    oDutyTranVAT11KA.DocumentNo = _oStockTran.TranNo;
                    //    //                    oDutyTranVAT11KA.RefID = int.Parse(_oStockTran.TranID.ToString());
                    //    //                    oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
                    //    //                    oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                    //    //                    oDutyTranVAT11KA.Remarks = txtRemarks.Text;
                    //    //                    oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;
                    //    //                    oDutyTranVAT11KA.Amount = 0;
                    //    //                    oDutyTranVAT11KA.InsertNewHOVAT();

                    //    //                    countMUSHAK_11KA++;
                    //    //                }
                    //    //                DutyTranDetail oItem = new DutyTranDetail();
                    //    //                oItem.DutyTranID = oDutyTranVAT11KA.DutyTranID;
                    //    //                oItem.ProductID = oDutyTranDetail.ProductID;
                    //    //                oItem.Qty = oDutyTranDetail.Qty;
                    //    //                oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                    //    //                oItem.DutyRate = oDutyTranDetail.DutyRate;
                    //    //                oItem.WHID = Utility.CentralRetailWarehouse;
                    //    //                oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    //    //                oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    //    //                oItem.VATType = oDutyTranDetail.VATType;
                    //    //                _TotalAmount = _TotalAmount + oItem.VAT;
                    //    //                oItem.InsertNewVATHO();
                    //    //            }

                    //    //        }
                    //    //        oDutyTranVAT11KA.Amount = _TotalAmount;
                    //    //        oDutyTranVAT11KA.UpdateToatlVATAmountHO();

                    //    //        oDutyAccount = new DutyAccount();
                    //    //        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                    //    //        oDutyAccount.Balance = _TotalAmount;
                    //    //        oDutyAccount.UpdateBalance(true);
                    //    //    }
                    //    //}
                    //}
                }
                #endregion

                #region Old Duty
                //SystemInfo oIsVatActive = new SystemInfo();
                //int nIsActive = oIsVatActive.IsNewVatActive();
                //if (nIsActive == 0)
                //{
                //    if (Utility.IsVATApplicable == true)
                //    {
                //        _DutyImportBalance = 0;
                //        _DutyLocalBalance = 0;
                //        oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11, _oStockTran.TranID);
                //        oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA, _oStockTran.TranID);

                //        if (oDutyTranVAT11.Count > 0)
                //        {
                //            if (oDutyTranVAT11.Amount > 0)
                //            {
                //                oDutyTranVAT11.Remarks = txtRemarks.Text;
                //                oDutyTranVAT11.Insert();
                //                oDutyAccount = new DutyAccount();
                //                oDutyAccount.DutyAccountTypeID = oDutyTranVAT11.DutyAccountID;
                //                oDutyAccount.Balance = _DutyImportBalance;
                //                oDutyAccount.UpdateBalance(true);
                //            }
                //        }
                //        if (oDutyTranVAT11KA.Count > 0)
                //        {
                //            if (oDutyTranVAT11KA.Amount > 0)
                //            {
                //                oDutyTranVAT11KA.Remarks = txtRemarks.Text;
                //                oDutyTranVAT11KA.Insert();
                //                oDutyAccount = new DutyAccount();
                //                oDutyAccount.DutyAccountTypeID = oDutyTranVAT11KA.DutyAccountID;
                //                oDutyAccount.Balance = _DutyLocalBalance;
                //                oDutyAccount.UpdateBalance(true);
                //            }
                //        }
                //    }

                //}
                #endregion


                if (_oProductTransferProductSerials != null)
                {
                    ProductBarcode _oMAXID = new ProductBarcode();
                    int nID = _oMAXID.GetMaxID();

                    foreach (ProductTransferProductSerial oPTPS in _oProductTransferProductSerials)
                    {
                        //Insert t_ProductTransferProductSerial
                        if (Utility.CompanyInfo == "TEL")
                        {
                            oPTPS.DeleteFromHO();
                            oPTPS.InsertTELHQ(_oStockTran.TranID);
                            

                            SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                            oChkVatPaidProductSerial.ProductSerialNo = oPTPS.ProductSerialNo;
                            if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                            {

                                ProductBarcode _oProductBarcode = new ProductBarcode();
                                _oProductBarcode.VatPaidID = nID;
                                _oProductBarcode.ProductId = oPTPS.ProductID;
                                _oProductBarcode.WarehouseID = _oStockTran.ToWHID;
                                _oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                                _oProductBarcode.TranNo = _oStockTran.TranNo;
                                _oProductBarcode.TranDate = Convert.ToDateTime(_oStockTran.TranDate);
                                _oProductBarcode.Status = 1;
                                _oProductBarcode.InsertVatPaidProductSerial();

                                Product oProduct = new Product();
                                oProduct.ProductID= oPTPS.ProductID;
                                oProduct.RefreshByID();

                                ProductBarcode oProductBarcodeUpdate = new ProductBarcode();
                                oProductBarcodeUpdate.Status = (int)Dictionary.ProductSerialStatus.Send_from_HO_to_Outlet;
                                oProductBarcodeUpdate.ProductSerialNo= oPTPS.ProductSerialNo;
                                oProductBarcodeUpdate.UpdateVatPaidProductSerial(_oStockTran.FromWHID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.TRANSFER, _oStockTran.TranNo, Convert.ToDateTime(_oStockTran.TranDate));


                            }


                        }
                        else if (Utility.CompanyInfo == "TML")
                        {
                            oPTPS.InsertTML(_oStockTran.TranID);
                        }

                        _oProductBarcode = new ProductBarcode();

                        _oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_to_HO;
                        _oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                        _oProductBarcode.ProductId = oPTPS.ProductID;
                        _oProductBarcode.ProductStockTranID = _oStockTran.TranID;

                        _oProductBarcode.GetProductSerialID(oPTPS.ProductSerialNo);
                        if (_oProductBarcode.Found == false)
                        {
                            _oProductBarcode.InsertProductSerial();
                        }
                        else
                        {
                            _oProductBarcode.UpdateProductSerial();
                        }
                        _oProductBarcode.ToWHID = nFromWHID;
                        _oProductBarcode.CreateDate = DateTime.Now;
                        _oProductBarcode.FromWHID = nToWHID;
                        _oProductBarcode.InsertProductSerialHistory();

                    }
                }

                ProductStockTran oChkProductStockTran = new ProductStockTran();
                if (oChkProductStockTran.CheckStockTranItem(_oStockTran.TranID))
                {
                    if (oChkProductStockTran.CheckStockSerial(_oStockTran.TranID))
                    {
                        MessageBox.Show(@"Duplicate Product Serial", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(@"Product serial & tran qty not matched", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBController.Instance.CommitTran();
                MessageBox.Show(@"Success fully Transfer Stock against Requisition # " + sRequisitionNo, @"Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                //MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBoxWithDetails oErrorDetails = new MessageBoxWithDetails("An error occer in you appalication",
                    "Error", ex.ToString());
            }
            
        }

        private void InsertVAT65(int nTranID,string sTranNo,int _nRequisitionID)
        {
            DutyAccounts oDetail = new DutyAccounts();
            oDetail.GetDutyDetailNew("Transfer", Convert.ToInt32(nTranID));

            double _TotalAmount_65_15 = 0;
            double _TotalAmount_65_5 = 0;
            int countMUSHAK_65_15 = 0;
            int countMUSHAK_65_5 = 0;
            int countMUSHAK_Exampled = 0;

            oDutyTranVAT65_15 = new DutyTran();
            oDutyTranVAT65_5 = new DutyTran();
            oDutyTranVATExampled = new DutyTran();

            foreach (DutyAccount oDutyTranDetail in oDetail)
            {
                if (oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_15 || oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_15)
                {
                    if (countMUSHAK_65_15 == 0)
                    {

                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVAT65_15.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVAT65_15.WHID = nToWHID;
                        oDutyTranVAT65_15.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_15.DocumentNo = sTranNo;
                        oDutyTranVAT65_15.RefID = nTranID;
                        oDutyTranVAT65_15.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVAT65_15.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                        oDutyTranVAT65_15.Remarks = txtRemarks.Text;
                        oDutyTranVAT65_15.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_15.Amount = 0;
                        oDutyTranVAT65_15.InsertNewHOVAT();
                        countMUSHAK_65_15++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVAT65_15.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    oItem.DutyPrice = oDutyTranDetail.VATCP;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = nToWHID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    oItem.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    _TotalAmount_65_15 = _TotalAmount_65_15 + oItem.VAT;
                    oItem.InsertNewVATHO63();


                    oItem.StockRequisitionID = _nRequisitionID;
                    oItem.DutyTranNo = oDutyTranVAT65_15.DutyTranNo;
                    oItem.TranID = nTranID;
                    oItem.UpdateVATNoStockRequisition();

                }
                else if (oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_5|| oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_5)
                {
                    if (countMUSHAK_65_5 == 0)
                    {

                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVAT65_5.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVAT65_5.WHID = nToWHID;
                        oDutyTranVAT65_5.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_5.DocumentNo = sTranNo;
                        oDutyTranVAT65_5.RefID = nTranID;
                        oDutyTranVAT65_5.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVAT65_5.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                        oDutyTranVAT65_5.Remarks = txtRemarks.Text;
                        oDutyTranVAT65_5.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVAT65_5.Amount = 0;
                        oDutyTranVAT65_5.InsertNewHOVAT();
                        countMUSHAK_65_5++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVAT65_5.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    oItem.DutyPrice = oDutyTranDetail.VATCP;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = nToWHID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    oItem.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    _TotalAmount_65_5 = _TotalAmount_65_5 + oItem.VAT;
                    oItem.InsertNewVATHO63();


                    oItem.StockRequisitionID = _nRequisitionID;
                    oItem.DutyTranNo = oDutyTranVAT65_5.DutyTranNo;
                    oItem.TranID = nTranID;
                    oItem.UpdateVATNoStockRequisition();

                }
                else
                {
                    if (countMUSHAK_Exampled == 0)
                    {

                        DateTime day = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVATExampled.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVATExampled.WHID = nToWHID;
                        oDutyTranVATExampled.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVATExampled.DocumentNo = sTranNo;
                        oDutyTranVATExampled.RefID = nTranID;
                        oDutyTranVATExampled.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVATExampled.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
                        oDutyTranVATExampled.Remarks = txtRemarks.Text;
                        oDutyTranVATExampled.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
                        oDutyTranVATExampled.Amount = 0;
                        oDutyTranVATExampled.InsertNewHOVAT();
                        countMUSHAK_Exampled++;
                    }
                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVATExampled.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    oItem.DutyPrice = oDutyTranDetail.VATCP;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = nToWHID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    oItem.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    oItem.InsertNewVATHO63();

                    oItem.StockRequisitionID = _nRequisitionID;
                    oItem.DutyTranNo = oDutyTranVATExampled.DutyTranNo;
                    oItem.TranID = nTranID;
                    oItem.UpdateVATNoStockRequisition();

                }

            }

            oDutyTranVAT65_15.Amount = _TotalAmount_65_15;
            oDutyTranVAT65_15.UpdateToatlVATAmountHO();

            oDutyTranVAT65_5.Amount = _TotalAmount_65_5;
            oDutyTranVAT65_5.UpdateToatlVATAmountHO();



            oDutyAccount = new DutyAccount();
            oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_5;
            oDutyAccount.Balance = _TotalAmount_65_15 + _TotalAmount_65_5;
            oDutyAccount.UpdateBalance(true);



        }


        public DutyTran GetDataForVAT63(DutyTran oDutyTranVAT63,string sTranNo,DateTime _dtTranDate,int nTranID)
        {
            oDutyTranVAT63 = new DutyTran();

            DateTime day = Convert.ToDateTime(_dtTranDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT63.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT63.WHID = Utility.CentralRetailWarehouse;
            oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
            oDutyTranVAT63.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT63.DocumentNo = sTranNo;
            oDutyTranVAT63.RefID = nTranID;
            oDutyTranVAT63.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT63.DutyAccountID = 3;

            DutyAccounts oDetail = new DutyAccounts();
            oDetail.GetDutyDetailNew("Transfer", Convert.ToInt32(nTranID));

            foreach (DutyAccount oItem in oDetail)
            {

                DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                oDutyTranDetail.ProductID = oItem.ProductID;
                oDutyTranDetail.Qty = oItem.Qty;
                oDutyTranDetail.DutyPrice = oItem.DutyPriceForRetail;
                oDutyTranDetail.DutyRate = oItem.DutyRate;
                oDutyTranDetail.WHID = oSystemInfo.WarehouseID;
                oDutyTranDetail.UnitPrice = oItem.UnitPrice;
                oDutyTranDetail.VAT = (oItem.DutyPriceForRetail * oItem.DutyRate) * oItem.Qty;
                oDutyTranDetail.VATType = oItem.VATType;
                _NewDutyBalance = _NewDutyBalance + oDutyTranDetail.VAT;
                oDutyTranVAT63.Add(oDutyTranDetail);


            }
            oDutyTranVAT63.Amount = _NewDutyBalance;

            return oDutyTranVAT63;
        }
        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA, int nStockTranID)
        {
            oDutyTranVAT11KA = new DutyTran();

            oDutyTranVAT11KA.DutyTranDate = DateTime.Now.Date;
            oDutyTranVAT11KA.WHID = Utility.CentralRetailWarehouse;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = sRequisitionNo;
            oDutyTranVAT11KA.RefID = nStockTranID;
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11KA.Remarks = "NA";
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;


            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oProductDetail.Refresh();
                    if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                        {
                            DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                            oDutyTranDetail.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                            oDutyTranDetail.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());

                            CustomerDetail oCustomerDetail = new CustomerDetail();
                            //oProductTransaction = new ProductTransaction();
                            oCustomerDetail.ChannelID = Utility.TDRetailChannelID;
                            oCustomerDetail.RefreshChannel(Utility.TDRetailChannelID);

                            if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                            {

                                oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                                oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                            }
                            else
                            {

                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oDutyTranDetail.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);

                                }
                                oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                            }

                            _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                            oDutyTranVAT11KA.Add(oDutyTranDetail);
                        }
                    }
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11, int nStockTranID)
        {
            oDutyTranVAT11 = new DutyTran();

            oDutyTranVAT11.DutyTranDate = DateTime.Now.Date;
            oDutyTranVAT11.WHID = Utility.CentralRetailWarehouse;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = sRequisitionNo;
            oDutyTranVAT11.RefID = nStockTranID;
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11.Remarks = "NA";
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oProductDetail.Refresh();
                    if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                        {
                            DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                            oDutyTranDetail.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                            oDutyTranDetail.Qty = int.Parse(oItemRow.Cells[3].Value.ToString());

                            CustomerDetail oCustomerDetail = new CustomerDetail();
                            //oProductTransaction = new ProductTransaction();
                            oCustomerDetail.ChannelID = Utility.TDRetailChannelID;
                            oCustomerDetail.RefreshChannel(Utility.TDRetailChannelID);

                            if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                            {
                                oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                                oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oDutyTranDetail.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);

                                }
                                oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                            }

                            _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                            oDutyTranVAT11.Add(oDutyTranDetail);
                        }
                    }
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        public void ShowDialog(POSRequisition oPOSRequisition)
        {
            this.Tag = oPOSRequisition;
            oTELLib = new TELLib();

            nRequisitionID = 0;
            nToWHID = 0;
            nFromWHID = 0;


            lblToWH.Text = oPOSRequisition.ToWHName;
            lblRequisitionNo.Text = oPOSRequisition.RequisitionNo;
            lblRequisitionDate.Text = oPOSRequisition.RequisitionDate.ToString("dd-MMM-yyyy");
            lblFromWH.Text = oPOSRequisition.FromWHName;
            nRequisitionID = oPOSRequisition.RequisitionID;
            nToWHID = oPOSRequisition.ToWHID;
            nFromWHID = oPOSRequisition.FromWHID;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);
            int nOutletIndex = 0;

            foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
            {
                if (oPOSRequisitionItem.AuthorizeQty > 0)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
                    oRow.Cells[1].Value = oPOSRequisitionItem.ProductName.ToString();

                    _oProductStock = new ProductStock();
                    //_oProductStock.GetProductStock(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID);
                    _oProductStock.GetProductStock(nToWHID, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID);

                    oRow.Cells[2].Value = _oProductStock.CurrentStock;
                    oRow.Cells[3].Value = oPOSRequisitionItem.AuthorizeQty.ToString();
                    oRow.Cells[5].Value = oPOSRequisitionItem.ProductID.ToString();

                    dgvLineItem.Rows.Add(oRow);
                }

            }

            GetTotalAmount();

            this.ShowDialog();
        }
        public void GetTotalAmount()
        {
            txtTotalQty.Text = "0";

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput()
        {
            if (dgvLineItem.Rows.Count > 0)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {

                    if (oItemRow.Cells[3].Value == null || oItemRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Authorized Qty must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[3].Value) > Convert.ToInt32(oItemRow.Cells[2].Value))
                    {
                        MessageBox.Show("Authorized Qty must be less or equal Current Stock Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value != null)
                    {
                        DBController.Instance.OpenNewConnection();
                        _oProduct = new Product();
                        _oProduct.ProductID = Convert.ToInt32(oItemRow.Cells[5].Value);
                        _oProduct.RefreshByProductID();
                        if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            if (Convert.ToInt32(oItemRow.Cells[3].Value) != Convert.ToInt32(oItemRow.Cells[4].Value))
                            {
                                MessageBox.Show("Please Provide Barcode Serial ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }


}