using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.POS.TELWEBSERVER;


namespace CJ.POS.ISGM
{
    public partial class frmSendReceiveISGM : Form
    {
        DSISGM oDSISGM;
        DSDataRange oDSDataRange;
        DSPermission oDSPermission;
        Service oService;      
        DSProductTransaction oDSProductTransaction;

        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.Warehouse oWarehouse;
           
      
        int _nUIControl;
      
        public frmSendReceiveISGM(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void frmSendReceiveISGM_Load(object sender, EventArgs e)
        {            
            oService = new Service();
            oDSPermission = new DSPermission();
            try
            {
                oDSPermission = oService.GetAllPermission(oDSPermission, CJ.Class.Utility.UserId);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            LoadData();
            if (_nUIControl == (int)CJ.Class.Dictionary.ProductISGMStatus.Authorized)
            {
                btSend.Visible = true;
                btReceive.Visible = false;
            }
            else
            {
                btSend.Visible = false;
                btReceive.Visible = true;
            }
        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            oDSDataRange = new DSDataRange();
            oDSISGM = new DSISGM();
            oService = new Service();

            DSDataRange.DataRangeRow oDataRangeRow = oDSDataRange.DataRange.NewDataRangeRow();
            oDataRangeRow.FromDate = dtFromDate.Value.Date;
            oDataRangeRow.ToDate = dtToDate.Value.Date;
            oDataRangeRow.UserID = CJ.Class.Utility.UserId.ToString();
            oDSDataRange.DataRange.AddDataRangeRow(oDataRangeRow);
            oDSDataRange.AcceptChanges();
            CJ.Class.DBController.Instance.OpenNewConnection();
            oSystemInfo = new CJ.Class.POS.SystemInfo();
            oSystemInfo.Refresh();

            try
            {
                if (_nUIControl==(int)CJ.Class.Dictionary.ProductISGMStatus.Authorized)
                    oDSISGM = oService.ISGMRefreshForSendReceived(oDSISGM, oDSDataRange, txtISGMNo.Text, (int)CJ.Class.Dictionary.ProductISGMStatus.Authorized, oSystemInfo.WarehouseID);
                else oDSISGM = oService.ISGMRefreshForSendReceived(oDSISGM, oDSDataRange, txtISGMNo.Text, (int)CJ.Class.Dictionary.ProductISGMStatus.Send_By_FromWarehouse, oSystemInfo.WarehouseID);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lvwOrderList.Items.Clear();
            if (oDSISGM.ProductISGM.Count > 0)
            {
                foreach (DSISGM.ProductISGMRow oProductISGMRow in oDSISGM.ProductISGM)
                {
                    ListViewItem lstItem = lvwOrderList.Items.Add(oProductISGMRow.ISGMNo);
                    lstItem.SubItems.Add((Convert.ToDateTime(oProductISGMRow.ISGMDate)).ToString("dd-MMM-yyyy"));
                    oWarehouse = new CJ.Class.Warehouse();
                    oWarehouse.WarehouseID = oProductISGMRow.FromWHID;
                    oWarehouse.POSReresh();
                    lstItem.SubItems.Add(oWarehouse.WarehouseName);
                    oWarehouse = new CJ.Class.Warehouse();
                    oWarehouse.WarehouseID = oProductISGMRow.ToWHID;
                    oWarehouse.POSReresh();
                    lstItem.SubItems.Add(oWarehouse.WarehouseName);

                    if (oProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
                    {
                        lstItem.SubItems.Add("Submitted");
                    }
                    if (oProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Authorized)
                    {
                        lstItem.SubItems.Add("Authorized");
                    }
                    if (oProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Send_By_FromWarehouse)
                    {
                        lstItem.SubItems.Add("Send By From Warehouse");
                    }
                    if (oProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Received_By_ToWarehouse)
                    {
                        lstItem.SubItems.Add("Received By To Warehouse");
                    }
                    if (oProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Cancel)
                    {
                        lstItem.SubItems.Add("Cancel");
                    }
                    if (oProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.NotTransfer)
                    {
                        lstItem.SubItems.Add("Not Transfer");
                    }
                    if (oProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer)
                    {
                        lstItem.SubItems.Add("Submitted ISGM Transfer");
                    }
                    if (oProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Cancel_ISGM_Transfer)
                    {
                        lstItem.SubItems.Add("Cancel ISGM Transfer");
                    }
                    lstItem.SubItems.Add(oProductISGMRow.Remarks);

                    lstItem.Tag = oProductISGMRow;
                }
                this.Text = "ISGM" + "[" + oDSISGM.ProductISGM.Count + "]";
            }
            else this.Text = "ISGM" + "[" + 0 + "]";
            CJ.Class.DBController.Instance.CloseConnection();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSend_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;

            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Authorized)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer)
                {
                    try
                    {
                        oService = new Service();
                        oDSProductTransaction = new DSProductTransaction();
                        oDSProductTransaction = oService.GetISGMProductTransaction(oDSProductTransaction, oSelectProductISGMRow.StockTranID);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                  

                    try
                    {                      

                        CJ.Class.ProductTransaction oProductTransaction = new CJ.Class.ProductTransaction();

                        oProductTransaction.TranNo = oDSProductTransaction.ProductStockTran[0].TranNo;
                        oProductTransaction.TranDate = oDSProductTransaction.ProductStockTran[0].TranDate;
                        oProductTransaction.TranTypeID = oDSProductTransaction.ProductStockTran[0].TranTypeId;
                        oProductTransaction.CreateDate = oDSProductTransaction.ProductStockTran[0].TranDate;
                        oProductTransaction.LastUpdateDate = oDSProductTransaction.ProductStockTran[0].TranDate;
                        oProductTransaction.LastUpdateUserID = int.Parse(oDSProductTransaction.ProductStockTran[0].UserId.ToString());
                        oProductTransaction.ToWHID = int.Parse(oDSProductTransaction.ProductStockTran[0].ToWHId.ToString());
                        oProductTransaction.ToChannelID = int.Parse(oDSProductTransaction.ProductStockTran[0].ToChannelID.ToString());
                        oProductTransaction.FromWHID = int.Parse(oDSProductTransaction.ProductStockTran[0].FromWHId.ToString());
                        oProductTransaction.FromChannelID = int.Parse(oDSProductTransaction.ProductStockTran[0].FromChannelId.ToString());
                        oProductTransaction.UserID = int.Parse(oDSProductTransaction.ProductStockTran[0].UserId.ToString());
                        oProductTransaction.Remarks = oDSProductTransaction.ProductStockTran[0].Remarks;
                        oProductTransaction.Status = 1;

                        foreach (DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow in oDSProductTransaction.ProductStockTranItem)
                        {
                            CJ.Class.ProductTransactionDetail oItem = new CJ.Class.ProductTransactionDetail();

                            oItem.ProductID = int.Parse(oProductStockTranItemRow.ProductID.ToString());
                            oItem.Qty = oProductStockTranItemRow.Qty;
                            oItem.StockPrice = oProductStockTranItemRow.StockPrice;
                            oProductTransaction.Add(oItem);
                        }

                        CJ.Class.DBController.Instance.BeginNewTransaction();

                        oProductTransaction.InsertForISGMTransfer((int)CJ.Class.Dictionary.ProductISGMStatus.Authorized);

                        foreach (DSProductTransaction.BarcodeRow oBarcodeRow in oDSProductTransaction.Barcode)
                        {
                            CJ.Class.ProductBarcode oProductBarcode = new CJ.Class.ProductBarcode();

                            oProductBarcode.WarehouseID = oSelectProductISGMRow.FromWHID;
                            oProductBarcode.ProductId = oBarcodeRow.ProductID;
                            oProductBarcode.ProductSerialNo = oBarcodeRow.Barcode;                           

                            oProductBarcode.UpdatePOSBarcode();
                                
                        }

                        oService = new Service();
                        oDSISGM = new DSISGM();

                        DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                        oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                        oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                        oProductISGMRow.Status = (int)CJ.Class.Dictionary.ProductISGMStatus.Send_By_FromWarehouse;

                        oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                        oDSISGM.AcceptChanges();

                        oDSISGM = oService.UpdateISGMStatus(oDSISGM);

                        if (oDSISGM.ProductISGM[0].Result == "1")
                        {
                            CJ.Class.DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Send ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Send", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error..." + oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        CJ.Class.DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btReceive_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;

            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Send_By_FromWarehouse)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer)
                {
                    try
                    {
                        oService = new Service();
                        oDSProductTransaction = new DSProductTransaction();
                        oDSProductTransaction = oService.GetISGMProductTransaction(oDSProductTransaction, oSelectProductISGMRow.StockTranID);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {

                        CJ.Class.ProductTransaction oProductTransaction = new CJ.Class.ProductTransaction();

                        oProductTransaction.TranNo = oDSProductTransaction.ProductStockTran[0].TranNo;
                        oProductTransaction.TranDate = oDSProductTransaction.ProductStockTran[0].TranDate;
                        oProductTransaction.TranTypeID = oDSProductTransaction.ProductStockTran[0].TranTypeId;
                        oProductTransaction.CreateDate = oDSProductTransaction.ProductStockTran[0].TranDate;
                        oProductTransaction.LastUpdateDate = oDSProductTransaction.ProductStockTran[0].TranDate;
                        oProductTransaction.LastUpdateUserID = int.Parse(oDSProductTransaction.ProductStockTran[0].UserId.ToString());
                        oProductTransaction.ToWHID = int.Parse(oDSProductTransaction.ProductStockTran[0].ToWHId.ToString());
                        oProductTransaction.ToChannelID = int.Parse(oDSProductTransaction.ProductStockTran[0].ToChannelID.ToString());
                        oProductTransaction.FromWHID = int.Parse(oDSProductTransaction.ProductStockTran[0].FromWHId.ToString());
                        oProductTransaction.FromChannelID = int.Parse(oDSProductTransaction.ProductStockTran[0].FromChannelId.ToString());
                        oProductTransaction.UserID = int.Parse(oDSProductTransaction.ProductStockTran[0].UserId.ToString());
                        oProductTransaction.Remarks = oDSProductTransaction.ProductStockTran[0].Remarks;
                        oProductTransaction.Status = 1;

                        foreach (DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow in oDSProductTransaction.ProductStockTranItem)
                        {
                            CJ.Class.ProductTransactionDetail oItem = new CJ.Class.ProductTransactionDetail();

                            oItem.ProductID = int.Parse(oProductStockTranItemRow.ProductID.ToString());
                            oItem.Qty = oProductStockTranItemRow.Qty;
                            oItem.StockPrice = oProductStockTranItemRow.StockPrice;
                            oProductTransaction.Add(oItem);
                        }

                        CJ.Class.DBController.Instance.BeginNewTransaction();

                        oProductTransaction.InsertForISGMTransfer((int)CJ.Class.Dictionary.ProductISGMStatus.Send_By_FromWarehouse);

                        foreach (DSProductTransaction.BarcodeRow oBarcodeRow in oDSProductTransaction.Barcode)
                        {
                            CJ.Class.ProductBarcode oProductBarcode = new CJ.Class.ProductBarcode();

                            oProductBarcode.WarehouseID = oSelectProductISGMRow.ToWHID;
                            oProductBarcode.ProductId = oBarcodeRow.ProductID;
                            oProductBarcode.ProductSerialNo = oBarcodeRow.Barcode;

                            oProductBarcode.InsertISGBarcode();

                        }

                        oService = new Service();
                        oDSISGM = new DSISGM();

                        DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                        oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                        oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                        oProductISGMRow.Status = (int)CJ.Class.Dictionary.ProductISGMStatus.Received_By_ToWarehouse;

                        oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                        oDSISGM.AcceptChanges();

                        oDSISGM = oService.UpdateISGMStatus(oDSISGM);

                        if (oDSISGM.ProductISGM[0].Result == "1")
                        {
                            CJ.Class.DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Received this ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error..." + oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        CJ.Class.DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }    
       
    }
}