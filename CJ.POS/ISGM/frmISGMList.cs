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
    public partial class frmISGMList : Form
    {
        DSISGM oDSISGM;
        DSDataRange oDSDataRange;
        DSPermission oDSPermission;
        Service oService;
        DSISGM oSelectedDSISGM;
        DSProductTransaction oDSProductTransaction;

        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.Warehouse oWarehouse;

        CJ.Class.POS.DSISGM _oDSISGM;

        bool _IsAdmin = false;
        int _nUIControl;

        public frmISGMList(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void frmISGMList_Load(object sender, EventArgs e)
        {
            foreach (int GetEnum in Enum.GetValues(typeof(CJ.Class.Dictionary.ProductISGMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(CJ.Class.Dictionary.ProductISGMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 1;
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

            if (_nUIControl == (int)CJ.Class.Dictionary.ProductISGMStatus.Authorized)
            {
                btAdd.Visible = false;
                btDelete.Visible = false;
                btEdit.Visible = false;
                btSynch.Visible = false;
                btAuthorize.Visible = false;
                btAuthorizeCancel.Visible = false;
                btPrint.Visible = true;

                foreach (DSPermission.PermissionRow oPermissionRow in oDSPermission.Permission)
                {
                    if (oPermissionRow.PermissionKey == "M1.61")
                    {                       
                        btAuthorize.Visible = true;
                        btAuthorizeCancel.Visible = true;
                        _IsAdmin = true;
                        break;
                    }
                }
            }
            else
            {
                btAdd.Visible = true;
                btDelete.Visible = true;
                btEdit.Visible = true;
                btSynch.Visible = true;
                btAuthorize.Visible = false;
                btAuthorizeCancel.Visible = false;
                btPrint.Visible = false;
                foreach (DSPermission.PermissionRow oPermissionRow in oDSPermission.Permission)
                {
                    if (oPermissionRow.PermissionKey == "M1.61")
                    {
                        btAdd.Visible = false;
                        btDelete.Visible = false;
                        btEdit.Visible = false;
                        btSynch.Visible = false;
                        btAuthorize.Visible = false;
                        btAuthorizeCancel.Visible = false;
                        btPrint.Visible = false;
                        _IsAdmin = true;
                        break;
                    }
                }

            }
            LoadData();
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
                if (cmbStatus.Text == "ALL")
                    oDSISGM = oService.ISGMRefresh(oDSISGM, oDSDataRange, txtISGMNo.Text, -1, oSystemInfo.WarehouseID, _IsAdmin);
                else oDSISGM = oService.ISGMRefresh(oDSISGM, oDSDataRange, txtISGMNo.Text, cmbStatus.SelectedIndex, oSystemInfo.WarehouseID, _IsAdmin);

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

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmISGM ofrmISGM = new frmISGM();
            ofrmISGM.ShowDialog();
            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;
            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.NotTransfer)
                {
                    frmISGM oFrom = new frmISGM();
                    oFrom.ShowDialog(oSelectProductISGMRow,false);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Only Not Transfered ISGM can be Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Only Submitted ISGM can be Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;
            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.NotTransfer)
                {
                    try
                    {
                        oService = new Service();
                        oSelectedDSISGM = new DSISGM();
                        oSelectedDSISGM = oService.ISGMItemRefresh(oSelectedDSISGM, oSelectProductISGMRow.ISGMID, oSelectProductISGMRow.FromWHID);
                        oDSISGM = new DSISGM();

                        DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                        oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                        oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;

                        oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                        oDSISGM.AcceptChanges();

                        oDSISGM = oService.DeleteISGM(oDSISGM, oSelectedDSISGM);

                        if (oDSISGM.ProductISGM[0].Result == "1")
                        {
                            MessageBox.Show("You Have Successfully Delete ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                            MessageBox.Show(oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Only Not Transfered ISGM can be Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Only Submitted ISGM can be Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btSynch_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;

            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.NotTransfer)
                {
                    try
                    {
                        oService = new Service();
                        oSelectedDSISGM = new DSISGM();
                        oSelectedDSISGM = oService.ISGMItemRefresh(oSelectedDSISGM, oSelectProductISGMRow.ISGMID, oSelectProductISGMRow.FromWHID);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _oDSISGM = new CJ.Class.POS.DSISGM();
                    _oDSISGM.Merge(oSelectedDSISGM);
                    _oDSISGM.AcceptChanges();

                    try
                    {
                        CJ.Class.DBController.Instance.BeginNewTransaction();
                        foreach (DSISGM.BarcodeRow oBarcodeRow in oSelectedDSISGM.Barcode)
                        {
                            CJ.Class.ProductBarcode oProductBarcode = new CJ.Class.ProductBarcode();

                            oProductBarcode.WarehouseID = oBarcodeRow.WarehouseID;
                            oProductBarcode.ProductId = oBarcodeRow.ProductID;
                            oProductBarcode.ProductSerialNo = oBarcodeRow.Barcode;
                            oProductBarcode.RefTranNo = oSelectProductISGMRow.ISGMNo;

                            oProductBarcode.UpdateForISGMSSynch((int)CJ.Class.Dictionary.BarcodeIsActive.Lock);
                        }
                        oService = new Service();
                        oDSISGM = new DSISGM();
                        DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                        oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                        oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                        oProductISGMRow.TransferStatus = (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer;

                        oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                        oDSISGM.AcceptChanges();

                        oSelectedDSISGM = oService.UpdateISGMTransferStatus(oDSISGM, oSelectedDSISGM);
                                             

                        if (oSelectedDSISGM.ProductISGM[0].Result == "1")
                        {
                            CJ.Class.DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Synch ISGM, ISGM No - " + oSelectedDSISGM.ProductISGM[0].ISGMNo, "Synch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error..." + oSelectedDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        CJ.Class.DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Cancel)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer)
                {
                    try
                    {
                        oService = new Service();
                        oSelectedDSISGM = new DSISGM();
                        oSelectedDSISGM = oService.ISGMItemRefresh(oSelectedDSISGM, oSelectProductISGMRow.ISGMID, oSelectProductISGMRow.FromWHID);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _oDSISGM = new CJ.Class.POS.DSISGM();
                    _oDSISGM.Merge(oSelectedDSISGM);
                    _oDSISGM.AcceptChanges();

                    try
                    {
                        CJ.Class.DBController.Instance.BeginNewTransaction();

                        CJ.Class.ProductBarcode oProductBarcode = new CJ.Class.ProductBarcode();
                        oProductBarcode.RefTranNo = oSelectProductISGMRow.ISGMNo;
                        oProductBarcode.UpdateForISGMSSynch((int)CJ.Class.Dictionary.BarcodeIsActive.Active);


                        oService = new Service();
                        oDSISGM = new DSISGM();
                        DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                        oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                        oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                        oProductISGMRow.TransferStatus = (int)CJ.Class.Dictionary.ISGMTransferStatus.Cancel_ISGM_Transfer;

                        oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                        oDSISGM.AcceptChanges();

                        oSelectedDSISGM = oService.UpdateISGMTransferStatus(oDSISGM, oSelectedDSISGM);

                        if (oSelectedDSISGM.ProductISGM[0].Result == "1")
                        {
                            CJ.Class.DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Synch ISGM, ISGM No - " + oSelectedDSISGM.ProductISGM[0].ISGMNo, "Synch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            CJ.Class.DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error..." + oSelectedDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Only Submitted and Cancel ISGM can be Synch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
        }
        private void btAuthorize_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;
            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer)
                {
                    frmISGM oFrom = new frmISGM();
                    oFrom.ShowDialog(oSelectProductISGMRow, true);
                    LoadData();
                }
            }
            
        }

        private void btAuthorizeCancel_Click(object sender, EventArgs e)
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
                        oService = new Service();
                        oDSISGM = new DSISGM();
                        DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                        oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                        oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                        oProductISGMRow.Status = (int)CJ.Class.Dictionary.ProductISGMStatus.Cancel;

                        oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                        oDSISGM.AcceptChanges();

                        oDSISGM = oService.CancelAuthorizeISGM(oDSProductTransaction, oDSISGM, CJ.Class.Utility.UserId);

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

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)lvwOrderList.SelectedItems[0].Tag;

            try
            {
                oService = new Service();
                oDSISGM = new DSISGM();
                oDSISGM = oService.ISGMPrint(oDSISGM, oSelectProductISGMRow.ISGMID, oSelectProductISGMRow.Status);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CJ.Report.POS.rptISGM doc;
            CJ.Report.frmPrintPreview frmView; 

            doc = new CJ.Report.POS.rptISGM();
            frmView = new CJ.Report.frmPrintPreview();

            doc.SetDataSource(oDSISGM);
            frmView.ShowDialog(doc);
        }
        

       
    }
}