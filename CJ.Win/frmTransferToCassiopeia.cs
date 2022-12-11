using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class.POS;
using CJ.Class;
using CJ.Win.Security;
//using System.ServiceModel;
using RSMS.Objects;
using Ease.Core.Framework;


namespace CJ.Win
{
    public partial class frmTransferToCassiopeia : Form
    {
        POSRequisitions _oPOSRequisitions;
        POSRequisition _oPOSRequisition;
        ProductTransaction _oProductTransaction;
        ProductTransaction _ProductTransactionItem;
        ProductBarcodes oProductBarcodes;
        Warehouse oWarehouse;
        ProductStock oProductStock;
        CJ.Class.ProductDetail oProductDetail;
        int _nFromParentWarehouseId;
        int _nToParentWarehouseId;
      
        public frmTransferToCassiopeia()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            _oPOSRequisitions = new POSRequisitions();
            lvwRequisitionList.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oPOSRequisitions.RefreshBy(dtFromDate.Value,dtToDate.Value);

            foreach (POSRequisition oPOSRequisition in _oPOSRequisitions)
            {
                ListViewItem oItem = lvwRequisitionList.Items.Add(oPOSRequisition.RequisitionNo);
                oItem.SubItems.Add(Convert.ToDateTime( oPOSRequisition.RequisitionDate).ToString("dd-MMM-yyyy"));
                oPOSRequisition.Warehouse.WarehouseID=oPOSRequisition.ToWHID;
                oPOSRequisition.Warehouse.Reresh();
                oItem.SubItems.Add(oPOSRequisition.Warehouse.WarehouseName);
                oPOSRequisition.Warehouse.WarehouseID = oPOSRequisition.FromWHID;
                oPOSRequisition.Warehouse.Reresh();
                oItem.SubItems.Add(oPOSRequisition.Warehouse.WarehouseName);

                if (oPOSRequisition.CheckRequisitionNoInCassiopeia())
                    oItem.SubItems.Add("Not Process");
                else oItem.SubItems.Add("Process");

                oItem.SubItems.Add(oPOSRequisition.Remarks);

                if (oPOSRequisition.TransferStatus==(int)Dictionary.TransferStatus.RequisitionTransfer)
                    oItem.BackColor = Color.FromArgb(255, 255, 192);
                else if (oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.StockTransfer)
                    oItem.BackColor = Color.FromArgb(192, 255, 255);
                else if (oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.Transfer)
                    oItem.BackColor = Color.FromArgb(192, 255, 192);
                else oItem.BackColor = Color.White;

                oItem.Tag = oPOSRequisition;
            }
            this.Text = "Total Requisition " + "[" + _oPOSRequisitions.Count + "]";

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            double _StockValue = 0;
            double _RequisitionValue = 0;         

            if (lvwRequisitionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oPOSRequisition = (POSRequisition)lvwRequisitionList.SelectedItems[0].Tag;
            _oPOSRequisition.GetTransferStatus();

            if (_oPOSRequisition.CheckRequisitionNoInCassiopeia())
            {  
                oWarehouse = new Warehouse();
                oWarehouse.WarehouseID = _oPOSRequisition.FromWHID;
                oWarehouse.GetParentWarehouseByID();
                _nToParentWarehouseId = oWarehouse.WarehouseParentID;
                oWarehouse = new Warehouse();
                oWarehouse.WarehouseID = _oPOSRequisition.ToWHID;
                oWarehouse.GetParentWarehouseByID();
                _nFromParentWarehouseId = oWarehouse.WarehouseParentID;

                if (_nToParentWarehouseId == Utility.TDOID)
                {
                    #region If stock transfer from HO

                    if (_nFromParentWarehouseId == Utility.HOID)
                    {
                        _oPOSRequisition.RefreshRequisitionItem();

                        _oProductTransaction = new ProductTransaction();
                        _oProductTransaction.TranID = _oPOSRequisition.StockTranID;
                        _oProductTransaction.RefershByID();

                        _ProductTransactionItem = new ProductTransaction();
                        _ProductTransactionItem.TranID = _oPOSRequisition.StockTranID;
                        _ProductTransactionItem.RefreshItem();

                        #region If data not transfer

                        if (_oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.NotTransfer)
                        {
                            Requisition oRequisition = new Requisition();

                            try
                            {

                                // Create  Requisition in Cassiopeia

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                oWarehouse = new Warehouse();
                                oWarehouse.WarehouseID = _oPOSRequisition.FromWHID;
                                oWarehouse.Reresh();
                                oWarehouse.GetShowroomID();
                                oRequisition.RaisedByID = RSMS.Objects.User.CurrentUser.ID;
                                oRequisition.ReceiptDate = DateTime.Today.Date;
                                oRequisition.ShowroomID = ID.FromInteger(oWarehouse.ShowroomID);
                                oRequisition.RequisitionDate = Convert.ToDateTime(_oPOSRequisition.RequisitionDate);
                                oRequisition.CreditLimit = Convert.ToDecimal(oWarehouse.CPCreditLimit);
                                oRequisition.RequisitionRemarks = _oPOSRequisition.RequisitionNo;
                                oRequisition.ReceiptMode = ReceivedMode.Manual;
                                oRequisition.Status = RequisitionStatus.Authorized;
                                oRequisition.AuthorizedByID = RSMS.Objects.User.CurrentUser.ID;
                                oRequisition.AuthorizedDate = DateTime.Today.Date; ;
                                //Need Authorised date & by

                                foreach (POSRequisitionItem oPOSRequisitionItem in _oPOSRequisition)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oPOSRequisitionItem.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    RequisitionItem oRequisitionItem = new RequisitionItem();
                                    oProductStock = new ProductStock();

                                    oRequisitionItem.HOStockQty = oProductStock.GetCassiopeisStock(1, oProductDetail.CPProductID);
                                    oRequisitionItem.StockQty = oProductStock.GetCassiopeisStock(oWarehouse.ShowroomID, oProductDetail.CPProductID);
                                    oRequisitionItem.StockValue = Convert.ToDecimal(oRequisitionItem.StockQty * oProductDetail.CostPrice);
                                    oRequisitionItem.RequisitionQty = oPOSRequisitionItem.RequisitionQty;
                                    oRequisitionItem.RequisitionValue = Convert.ToDecimal(oProductDetail.RSP * oPOSRequisitionItem.RequisitionQty);
                                    oRequisitionItem.AuthorizedQty = oPOSRequisitionItem.AuthorizeQty;
                                    oRequisitionItem.ProductID = ID.FromInteger(oProductDetail.CPProductID);

                                    _StockValue = _StockValue + Convert.ToDouble(oRequisitionItem.StockValue);
                                    _RequisitionValue = _RequisitionValue + Convert.ToDouble(oRequisitionItem.RequisitionValue);

                                    oRequisition.Items.Add(oRequisitionItem);
                                }
                                oRequisition.StockValue = Convert.ToDecimal(_StockValue);
                                oRequisition.RequisitionValue = Convert.ToDecimal(_RequisitionValue);
                                oRequisition.AuthorizedValue = oRequisition.RequisitionValue;
                                
                                oRequisition.Save();
                                pbStockIn.PerformStep();
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.RequisitionTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.NotTransfer;
                                _oPOSRequisition.UpdateTransferStatus();

                                return;
                            }

                            // Requisition End         

                            try
                            {
                                ///
                                // Create Product Transaction and Transfer in Cassiopeia
                                ///

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTranType type = new SRTranType().Get(BasicTranType.IssueToShowroomFromRCW);
                                SRTran oSRTran = new SRTran();
                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.RefNo = oRequisition.RequisitionNo;
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                oSRTran.RequisitionID = oRequisition.ID;
                                oSRTran.TranTypeID = type.ID;
                                oSRTran.TranSide = type.Side;
                                oSRTran.EffectOnStock = type.EffectOn;
                                oSRTran.ShowroomID = ThisSystem.Default.ID;
                                oSRTran.RefShowroomID = oRequisition.ShowroomID;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.SRTranItems.Add(item2);
                                    item2.ProductSerials = new ProductSerials();

                                    oProductBarcodes = new ProductBarcodes();
                                    oProductBarcodes.GetBarcodeForPOS(_oPOSRequisition.StockTranID, oProductTransactionDetail.ProductID);
                                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                                    {
                                        ProductSerial serial2;

                                        serial2 = new ProductSerial();
                                        serial2.ManufacturingSlNo = oProductBarcode.ProductSerialNo;
                                        serial2.ProductID = item2.ProductID;
                                        serial2.SerialNo = serial2.ManufacturingSlNo;
                                        serial2.ShowroomID = oSRTran.ShowroomID;
                                        serial2.Status = ProductSerialStatus.SerialOut;

                                        item2.ProductSerials.Add(serial2);
                                    }

                                }
                                oRequisition.Status = RequisitionStatus.Sent;
                                ID tranID = oSRTran.Save(oRequisition, true);

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductStock = new ProductStock();
                                    oProductStock.WarehouseID = _oPOSRequisition.FromWHID;

                                    oWarehouse = new Warehouse();
                                    oWarehouse.WarehouseID = oProductStock.WarehouseID;
                                    oWarehouse.Reresh();
                                    oProductStock.ChannelID = oWarehouse.ChannelID;

                                    oProductStock.ProductID = oProductTransactionDetail.ProductID;
                                    oProductStock.Quantity = oProductTransactionDetail.Qty;
                                    oProductStock.UpdateCurrentStock_POS(false);
                                    oProductStock.UpdateTransitStock_POS(false);

                                    if (oProductStock.Flag == false)
                                    {
                                        int tepm = int.Parse("Create Exceptions");
                                    }

                                }
                                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Received;
                                _oPOSRequisition.UpdateStatus();
                                pbStockIn.PerformStep();
                                MessageBox.Show("You Have Successfully Transfer Data. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.Transfer;
                                _oPOSRequisition.UpdateTransferStatus();

                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.RequisitionTransfer;
                                _oPOSRequisition.UpdateTransferStatus();

                                return;

                            }
                        }

                        #endregion

                        #region If Requisition Transfer
                        else if (_oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.RequisitionTransfer)
                        {

                            try
                            {
                                ///
                                // Create Product Transaction and Transfer in Cassiopeia
                                ///
                                oWarehouse = new Warehouse();
                                oWarehouse.WarehouseID = _oPOSRequisition.FromWHID;
                                oWarehouse.Reresh();
                                oWarehouse.GetShowroomID();

                                Requisition oRequisition = new Requisition();
                                oRequisition.Get(ID.FromInteger(_oPOSRequisition.CPRequisitionID), ID.FromInteger(oWarehouse.ShowroomID), ReceivedMode.Manual);

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTranType type = new SRTranType().Get(BasicTranType.IssueToShowroomFromRCW);
                                SRTran oSRTran = new SRTran();
                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.RefNo = oRequisition.RequisitionNo;
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                oSRTran.RequisitionID = oRequisition.ID;
                                oSRTran.TranTypeID = type.ID;
                                oSRTran.TranSide = type.Side;
                                oSRTran.EffectOnStock = type.EffectOn;
                                oSRTran.ShowroomID = ThisSystem.Default.ID;
                                oSRTran.RefShowroomID = oRequisition.ShowroomID;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.SRTranItems.Add(item2);
                                    item2.ProductSerials = new ProductSerials();

                                    oProductBarcodes = new ProductBarcodes();
                                    oProductBarcodes.GetBarcodeForPOS(_oPOSRequisition.StockTranID, oProductTransactionDetail.ProductID);
                                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                                    {
                                        ProductSerial serial2;

                                        serial2 = new ProductSerial();
                                        serial2.ManufacturingSlNo = oProductBarcode.ProductSerialNo;
                                        serial2.ProductID = item2.ProductID;
                                        serial2.SerialNo = serial2.ManufacturingSlNo;
                                        serial2.ShowroomID = oSRTran.ShowroomID;
                                        serial2.Status = ProductSerialStatus.SerialOut;

                                        item2.ProductSerials.Add(serial2);
                                    }

                                }
                                oRequisition.Status = RequisitionStatus.Sent;
                                ID tranID = oSRTran.Save(oRequisition, true);

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductStock = new ProductStock();
                                    oProductStock.WarehouseID = _oPOSRequisition.FromWHID;

                                    oWarehouse = new Warehouse();
                                    oWarehouse.WarehouseID = oProductStock.WarehouseID;
                                    oWarehouse.Reresh();
                                    oProductStock.ChannelID = oWarehouse.ChannelID;

                                    oProductStock.ProductID = oProductTransactionDetail.ProductID;
                                    oProductStock.Quantity = oProductTransactionDetail.Qty;
                                    oProductStock.UpdateCurrentStock_POS(false);
                                    oProductStock.UpdateTransitStock_POS(false);

                                    if (oProductStock.Flag == false)
                                    {
                                        int tepm = int.Parse("Create Exceptions");
                                    }

                                }
                                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Received;
                                _oPOSRequisition.UpdateStatus();
                                pbStockIn.PerformStep();

                                MessageBox.Show("You Have Successfully Transfer Data. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.Transfer;
                                _oPOSRequisition.UpdateTransferStatus();

                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.RequisitionTransfer;
                                _oPOSRequisition.UpdateTransferStatus();

                                return;

                            }
                        }
                        #endregion


                    }
                    #endregion

                    #region If stock transfer from Depot

                    else
                    {
                        _oPOSRequisition.RefreshRequisitionItem();

                        _oProductTransaction = new ProductTransaction();
                        _oProductTransaction.TranID = _oPOSRequisition.StockTranID;
                        _oProductTransaction.RefershByID();

                        _ProductTransactionItem = new ProductTransaction();
                        _ProductTransactionItem.TranID = _oPOSRequisition.StockTranID;
                        _ProductTransactionItem.RefreshItem();

                        #region If data not transfer

                        if (_oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.NotTransfer)
                        {
                            Requisition oRequisition = new Requisition();

                            try
                            {
                                // Create  Requisition in Cassiopeia

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                oWarehouse = new Warehouse();
                                oWarehouse.WarehouseID = _oPOSRequisition.FromWHID;
                                oWarehouse.Reresh();
                                oWarehouse.GetShowroomID();
                                oRequisition.RaisedByID = RSMS.Objects.User.CurrentUser.ID;
                                oRequisition.ReceiptDate = DateTime.Today.Date;
                                oRequisition.ShowroomID = ID.FromInteger(oWarehouse.ShowroomID);
                                oRequisition.RequisitionDate = Convert.ToDateTime(_oPOSRequisition.RequisitionDate);
                                oRequisition.CreditLimit = Convert.ToDecimal(oWarehouse.CPCreditLimit);
                                oRequisition.RequisitionRemarks = _oPOSRequisition.RequisitionNo;
                                oRequisition.ReceiptMode = ReceivedMode.Manual;
                                oRequisition.Status = RequisitionStatus.Authorized;
                                oRequisition.AuthorizedByID = RSMS.Objects.User.CurrentUser.ID;
                                oRequisition.AuthorizedDate = DateTime.Today.Date; ;

                                foreach (POSRequisitionItem oPOSRequisitionItem in _oPOSRequisition)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oPOSRequisitionItem.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    RequisitionItem oRequisitionItem = new RequisitionItem();
                                    oProductStock = new ProductStock();

                                    oRequisitionItem.HOStockQty = oProductStock.GetCassiopeisStock(1, oProductDetail.CPProductID);
                                    oRequisitionItem.StockQty = oProductStock.GetCassiopeisStock(oWarehouse.ShowroomID, oProductDetail.CPProductID);
                                    oRequisitionItem.StockValue = Convert.ToDecimal(oRequisitionItem.StockQty * oProductDetail.CostPrice);
                                    oRequisitionItem.RequisitionQty = oPOSRequisitionItem.RequisitionQty;
                                    oRequisitionItem.RequisitionValue = Convert.ToDecimal(oProductDetail.RSP * oPOSRequisitionItem.RequisitionQty);
                                    oRequisitionItem.AuthorizedValue = Convert.ToDecimal(oProductDetail.RSP * oPOSRequisitionItem.RequisitionQty);
                                    oRequisitionItem.AuthorizedQty = oPOSRequisitionItem.AuthorizeQty;
                                    oRequisitionItem.ProductID = ID.FromInteger(oProductDetail.CPProductID);

                                    _StockValue = _StockValue + Convert.ToDouble(oRequisitionItem.StockValue);
                                    _RequisitionValue = _RequisitionValue + Convert.ToDouble(oRequisitionItem.RequisitionValue);
                                 

                                    oRequisition.Items.Add(oRequisitionItem);
                                }
                                oRequisition.StockValue = Convert.ToDecimal(_StockValue);
                                oRequisition.RequisitionValue = Convert.ToDecimal(_RequisitionValue);
                                oRequisition.AuthorizedValue = oRequisition.RequisitionValue;

                                oRequisition.Save();
                                pbStockIn.PerformStep();
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.RequisitionTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.NotTransfer;
                                _oPOSRequisition.UpdateTransferStatus();

                                return;
                            }

                            // Requisition End        

                            try
                            {
                                // Stock Add in Central Showroom in Cassiopeia

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTran oSRTran = new SRTran();

                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;
                                oSRTran.ProductSerialStatus = ProductSerialStatus.SerialIn;
                                oSRTran.TranTypeID = BasicTranType.ReceivedAtRCW;
                                oSRTran.TranSide = TranSide.Increase;
                                oSRTran.EffectOnStock = EffectOnStock.SoundStock;
                                oSRTran.ConfirmDate = DateTime.Today.Date;                                
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                
                                oSRTran.ThirdPartyID = ID.FromInteger(0);

                                oSRTran.ShowroomID = ThisSystem.Default.ID;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.ItemsSerial.CreateItems(item2, item2.Quantity);
                                    oSRTran.SRTranItems.Add(item2);

                                }
                                oSRTran.Save(true);
                                pbStockIn.PerformStep();
                                pbStockIn.Visible = true;
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.StockTransfer;
                                _oPOSRequisition.UpdateTransferStatus();

                                // End Stock Add in Central Showroom in Cassiopeia
                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.RequisitionTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                                return;
                            }
                           
                            try
                            {
                                ///
                                // Create Product Transaction and Transfer in Cassiopeia
                                ///

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTranType type = new SRTranType().Get(BasicTranType.IssueToShowroomFromRCW);
                                SRTran oSRTran = new SRTran();
                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.RefNo = oRequisition.RequisitionNo;
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                oSRTran.RequisitionID = oRequisition.ID;
                                oSRTran.TranTypeID = type.ID;
                                oSRTran.TranSide = type.Side;
                                oSRTran.EffectOnStock = type.EffectOn;
                                oSRTran.ShowroomID = ThisSystem.Default.ID;
                                oSRTran.RefShowroomID = oRequisition.ShowroomID;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.SRTranItems.Add(item2);
                                    item2.ProductSerials = new ProductSerials();

                                    oProductBarcodes = new ProductBarcodes();
                                    oProductBarcodes.GetBarcodeForPOS(_oPOSRequisition.StockTranID, oProductTransactionDetail.ProductID);
                                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                                    {
                                        ProductSerial serial2;

                                        serial2 = new ProductSerial();
                                        serial2.ManufacturingSlNo = oProductBarcode.ProductSerialNo;
                                        serial2.ProductID = item2.ProductID;
                                        serial2.SerialNo = serial2.ManufacturingSlNo;
                                        serial2.ShowroomID = oSRTran.ShowroomID;
                                        serial2.Status = ProductSerialStatus.SerialOut;

                                        item2.ProductSerials.Add(serial2);
                                    }

                                }
                                oRequisition.Status = RequisitionStatus.Sent;
                                ID tranID = oSRTran.Save(oRequisition,true);

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductStock = new ProductStock();
                                    oProductStock.WarehouseID = _oPOSRequisition.FromWHID;

                                    oWarehouse = new Warehouse();
                                    oWarehouse.WarehouseID = oProductStock.WarehouseID;
                                    oWarehouse.Reresh();
                                    oProductStock.ChannelID = oWarehouse.ChannelID;

                                    oProductStock.ProductID = oProductTransactionDetail.ProductID;
                                    oProductStock.Quantity = oProductTransactionDetail.Qty;
                                    oProductStock.UpdateCurrentStock_POS(false);
                                    oProductStock.UpdateTransitStock_POS(false);

                                    if (oProductStock.Flag == false)
                                    {
                                        int tepm = int.Parse("Create Exceptions");
                                    }

                                }

                                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Received;
                                _oPOSRequisition.UpdateStatus();
                                pbStockIn.PerformStep();
                                MessageBox.Show("You Have Successfully Transfer Data. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.Transfer;
                                _oPOSRequisition.UpdateTransferStatus();

                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.StockTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                                return;
                            }
                        }

                        #endregion

                        #region If Requisition transfer

                        else if (_oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.RequisitionTransfer)
                        {
                            oWarehouse = new Warehouse();
                            oWarehouse.WarehouseID = _oPOSRequisition.FromWHID;
                            oWarehouse.Reresh();
                            oWarehouse.GetShowroomID();

                            Requisition oRequisition = new Requisition();
                            oRequisition.Get(ID.FromInteger(_oPOSRequisition.CPRequisitionID), ID.FromInteger(oWarehouse.ShowroomID), ReceivedMode.Manual);

                           
                            try
                            {
                                // Stock Add in Central Showroom in Cassiopeia
                            
                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTran oSRTran = new SRTran();

                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;
                                oSRTran.ProductSerialStatus = ProductSerialStatus.SerialIn;
                                oSRTran.TranTypeID = BasicTranType.ReceivedAtRCW;
                                oSRTran.TranSide = TranSide.Increase;
                                oSRTran.EffectOnStock = EffectOnStock.SoundStock;
                                oSRTran.ConfirmDate = DateTime.Today.Date;
                                oSRTran.RefNo = oRequisition.RequisitionNo;
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                //No need third party
                                //oSRTran.ThirdPartyID = ID.FromInteger(0);
                                oSRTran.ShowroomID = ThisSystem.Default.ID;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.ItemsSerial.CreateItems(item2, item2.Quantity);
                                    oSRTran.SRTranItems.Add(item2);

                                }
                                oSRTran.Save(true);
                                pbStockIn.PerformStep();
                                pbStockIn.Visible = true;
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.StockTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                                // End Stock Add in Central Showroom in Cassiopeia
                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.RequisitionTransfer;
                                _oPOSRequisition.UpdateTransferStatus();

                                return;
                            }

                            try
                            {
                                ///
                                // Create Product Transaction and Transfer in Cassiopeia
                                ///

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTranType type = new SRTranType().Get(BasicTranType.IssueToShowroomFromRCW);
                                SRTran oSRTran = new SRTran();
                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.RefNo = oRequisition.RequisitionNo;
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                oSRTran.RequisitionID = oRequisition.ID;
                                oSRTran.TranTypeID = type.ID;
                                oSRTran.TranSide = type.Side;
                                oSRTran.EffectOnStock = type.EffectOn;
                                oSRTran.ShowroomID = ThisSystem.Default.ID;
                                oSRTran.RefShowroomID = oRequisition.ShowroomID;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.SRTranItems.Add(item2);
                                    item2.ProductSerials = new ProductSerials();

                                    oProductBarcodes = new ProductBarcodes();
                                    oProductBarcodes.GetBarcodeForPOS(_oPOSRequisition.StockTranID, oProductTransactionDetail.ProductID);
                                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                                    {
                                        ProductSerial serial2;

                                        serial2 = new ProductSerial();
                                        serial2.ManufacturingSlNo = oProductBarcode.ProductSerialNo;
                                        serial2.ProductID = item2.ProductID;
                                        serial2.SerialNo = serial2.ManufacturingSlNo;
                                        serial2.ShowroomID = oSRTran.ShowroomID;
                                        serial2.Status = ProductSerialStatus.SerialOut;

                                        item2.ProductSerials.Add(serial2);
                                    }

                                }
                                oRequisition.Status = RequisitionStatus.Sent;
                                ID tranID = oSRTran.Save(oRequisition, true);

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductStock = new ProductStock();
                                    oProductStock.WarehouseID = _oPOSRequisition.FromWHID;

                                    oWarehouse = new Warehouse();
                                    oWarehouse.WarehouseID = oProductStock.WarehouseID;
                                    oWarehouse.Reresh();
                                    oProductStock.ChannelID = oWarehouse.ChannelID;

                                    oProductStock.ProductID = oProductTransactionDetail.ProductID;
                                    oProductStock.Quantity = oProductTransactionDetail.Qty;
                                    oProductStock.UpdateCurrentStock_POS(false);
                                    oProductStock.UpdateTransitStock_POS(false);

                                    if (oProductStock.Flag == false)
                                    {
                                        int tepm = int.Parse("Create Exceptions");
                                    }

                                }
                                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Received;
                                _oPOSRequisition.UpdateStatus();
                                pbStockIn.PerformStep();
                                MessageBox.Show("You Have Successfully Transfer Data. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.Transfer;
                                _oPOSRequisition.UpdateTransferStatus();

                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.StockTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                                return;
                            }
                        }

                        #endregion

                        #region If Stock Transfer

                        else if (_oPOSRequisition.TransferStatus == (int)Dictionary.TransferStatus.StockTransfer)
                        {
                           
                                // Stock Add in Central Showroom in Cassiopeia

                                oWarehouse = new Warehouse();
                                oWarehouse.WarehouseID = _oPOSRequisition.FromWHID;
                                oWarehouse.Reresh();
                                oWarehouse.GetShowroomID();

                                Requisition oRequisition = new Requisition();
                                oRequisition.Get(ID.FromInteger(_oPOSRequisition.CPRequisitionID), ID.FromInteger(oWarehouse.ShowroomID), ReceivedMode.Manual);
                            
                               
                            try
                            {
                                ///
                                // Create Product Transaction and Transfer in Cassiopeia
                                ///

                                pbStockIn.Visible = true;
                                pbStockIn.Minimum = 0;
                                pbStockIn.Maximum = 1;
                                pbStockIn.Step = 1;
                                pbStockIn.Value = 0;

                                SRTranType type = new SRTranType().Get(BasicTranType.IssueToShowroomFromRCW);
                                SRTran oSRTran = new SRTran();
                                oSRTran.TranDate = DateTime.Today.Date;
                                oSRTran.RefNo = oRequisition.RequisitionNo;
                                oSRTran.RefDate = oRequisition.RequisitionDate;
                                oSRTran.RequisitionID = oRequisition.ID;
                                oSRTran.TranTypeID = type.ID;
                                oSRTran.TranSide = type.Side;
                                oSRTran.EffectOnStock = type.EffectOn;
                                oSRTran.ShowroomID = ThisSystem.Default.ID;
                                oSRTran.RefShowroomID = oRequisition.ShowroomID;
                                oSRTran.Remarks = _oPOSRequisition.RequisitionNo;

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductDetail = new ProductDetail();
                                    oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                                    oProductDetail.Refresh();
                                    oProductDetail.GetCPProductID();

                                    SRTranItem item2 = new SRTranItem();
                                    item2.ProductID = ID.FromInteger(oProductDetail.CPProductID);
                                    item2.Quantity = int.Parse(oProductTransactionDetail.Qty.ToString());

                                    oSRTran.SRTranItems.Add(item2);
                                    item2.ProductSerials = new ProductSerials();

                                    oProductBarcodes = new ProductBarcodes();
                                    oProductBarcodes.GetBarcodeForPOS(_oPOSRequisition.StockTranID, oProductTransactionDetail.ProductID);
                                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                                    {
                                        ProductSerial serial2;

                                        serial2 = new ProductSerial();
                                        serial2.ManufacturingSlNo = oProductBarcode.ProductSerialNo;
                                        serial2.ProductID = item2.ProductID;
                                        serial2.SerialNo = serial2.ManufacturingSlNo;
                                        serial2.ShowroomID = oSRTran.ShowroomID;
                                        serial2.Status = ProductSerialStatus.SerialOut;

                                        item2.ProductSerials.Add(serial2);
                                    }

                                }
                                oRequisition.Status = RequisitionStatus.Sent;
                                ID tranID = oSRTran.Save(oRequisition, true);

                                foreach (ProductTransactionDetail oProductTransactionDetail in _ProductTransactionItem)
                                {
                                    oProductStock = new ProductStock();
                                    oProductStock.WarehouseID = _oPOSRequisition.FromWHID;

                                    oWarehouse = new Warehouse();
                                    oWarehouse.WarehouseID = oProductStock.WarehouseID;
                                    oWarehouse.Reresh();
                                    oProductStock.ChannelID = oWarehouse.ChannelID;

                                    oProductStock.ProductID = oProductTransactionDetail.ProductID;
                                    oProductStock.Quantity = oProductTransactionDetail.Qty;
                                    oProductStock.UpdateCurrentStock_POS(false);
                                    oProductStock.UpdateTransitStock_POS(false);

                                    if (oProductStock.Flag == false)
                                    {
                                        int tepm = int.Parse("Create Exceptions");
                                    }

                                }
                                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Received;
                                _oPOSRequisition.UpdateStatus();
                                pbStockIn.PerformStep();
                                MessageBox.Show("You Have Successfully Transfer Data. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pbStockIn.Visible = false;

                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.Transfer;
                                _oPOSRequisition.UpdateTransferStatus();

                            }
                            catch
                            {
                                _oPOSRequisition.TransferStatus = (int)Dictionary.TransferStatus.StockTransfer;
                                _oPOSRequisition.UpdateTransferStatus();
                                return;
                            }
                        }

                        #endregion
                       
                    }
                    #endregion

                }

            }
            else MessageBox.Show("This Requisition Already Process", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        }

        private void frmTransferToCassiopeia_Load(object sender, EventArgs e)
        {
            frmCassiopeiaLogIn frmLogin = new frmCassiopeiaLogIn();
            DialogResult oResult = frmLogin.ShowDialog();
            if (oResult != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}