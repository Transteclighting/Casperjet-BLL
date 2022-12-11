// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 25, 2014
// Time : 03:00 PM
// Description: Stock Requisition
// Modify Person And Date:
// </summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.Duty;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmProductRequisitions : Form
    {
        int nRequisitionType = 0;
        POSRequisitions _oPOSRequisitions;
        POSRequisition _oPOSRequisition;
        StockTran _oStockTran;
        UserPermission _oUserPermission;
        string sWarehouseAddress = "";
        TELLib _oTELLib;
        int _nUIControl = 0;
        string sTotal = "";
        bool IsCheck = false;
        int nStockRequisitionID = 0;
        int nFromWHID = 0;

        public frmProductRequisitions(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductRequisition oForm = new frmProductRequisition((int)Dictionary.StockRequisitionType.Requisition);
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void btnAddReturnToHO_Click(object sender, EventArgs e)
        {
            frmProductTransfer oForm = new frmProductTransfer((int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create);
            oForm.ShowDialog();
            DataLoadControl();

        }
        private void btnAddOtherOutlet_Click(object sender, EventArgs e)
        {
            frmProductTransfer oForm = new frmProductTransfer((int)Dictionary.StockRequisitionUIControl.ISGM_Create);
            oForm.ShowDialog();
            if (oForm._IsTrue)
                DataLoadControl();
        }
        private void btnAddSendToCSD_Click(object sender, EventArgs e)
        {
            frmProductTransfer oForm = new frmProductTransfer((int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create);
            oForm.ShowDialog();
            if (oForm._IsTrue)
                DataLoadControl();
        }
        private void frmProductRequisitions_Load(object sender, EventArgs e)
        {

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            btnVatChallan.Enabled = true;


            _oTELLib = new TELLib();
            dtFromDate.Value = _oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;
            sWarehouseAddress = Utility.WarehouseAddress;
            IsCheck = false;
            _oUserPermission = new UserPermission();
            if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create)
            {
                nRequisitionType = (int)Dictionary.StockRequisitionType.Requisition;
                this.Text = "Stock Requisition [" + sTotal + "]";
                btnAdd.Visible = true;
                btnAddReturnToHO.Visible = false;
                btnAddOtherOutlet.Visible = false;
                btnAddSendToCSD.Visible = false;
                btnEdit.Visible = true;
                btnISGMRcv.Visible = false;
                btnRequisitionRcv.Visible = false;
                btnDelete.Visible = true;
                //Add Button
                btnAdd.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.1.1"))
                {
                    btnAdd.Enabled = true;
                }
                //Edit Button
                btnEdit.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.1.2"))
                {
                    btnEdit.Enabled = true;
                }
                //Delete Button
                btnDelete.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.1.3"))
                {
                    btnDelete.Enabled = true;
                }

            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
            {
                nRequisitionType = (int)Dictionary.StockRequisitionType.Return_To_HO;

                this.Text = "Return to HO [" + sTotal + "]";
                btnAdd.Visible = false;
                btnAddReturnToHO.Visible = true;
                btnAddOtherOutlet.Visible = false;
                btnAddSendToCSD.Visible = false;
                btnEdit.Visible = false;
                btnISGMRcv.Visible = false;
                btnRequisitionRcv.Visible = false;
                btnDelete.Visible = false;
                //Add Button (Return to HO)
                btnAddReturnToHO.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.2.1"))
                {
                    btnAddReturnToHO.Enabled = true;
                }
                
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                nRequisitionType = (int)Dictionary.StockRequisitionType.ISGM;
                this.Text = "ISGM to others Outlet [" + sTotal + "]";
                btnAdd.Visible = false;
                btnAddReturnToHO.Visible = false;
                btnAddOtherOutlet.Visible = true;
                btnAddSendToCSD.Visible = false;
                btnEdit.Visible = false;
                btnISGMRcv.Visible = false;
                btnRequisitionRcv.Visible = false;
                btnDelete.Visible = false;
                //Add Button (ISGM to Other Outlet)
                btnAddOtherOutlet.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.3.1"))
                {
                    btnAddOtherOutlet.Enabled = true;
                }
                //btnVAT11Ka.Visible = true;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create)
            {
                nRequisitionType = (int)Dictionary.StockRequisitionType.Send_To_CSD;
                this.Text = "Send to CSD [" + sTotal + "]";
                btnAdd.Visible = false;
                btnAddReturnToHO.Visible = false;
                btnAddOtherOutlet.Visible = false;
                btnAddSendToCSD.Visible = true;
                btnEdit.Visible = false;
                btnISGMRcv.Visible = false;
                btnRequisitionRcv.Visible = false;
                btnDelete.Visible = false;
                //btnVAT11Ka.Visible = true;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive)
            {
                nRequisitionType = (int)Dictionary.StockRequisitionType.Requisition;
                this.Text = "Goods Receive against Requisition [" + sTotal + "]";
                btnAdd.Visible = false;
                btnAddReturnToHO.Visible = false;
                btnAddOtherOutlet.Visible = false;
                btnAddSendToCSD.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnISGMRcv.Visible = false;
                btnRequisitionRcv.Visible = true;
                //Receive Button (Requisition Receive)
                btnRequisitionRcv.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.4.1"))
                {
                    btnRequisitionRcv.Enabled = true;
                }


                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
                IsCheck = true;
                //btnVAT11Ka.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Receive)
            {
                nRequisitionType = (int)Dictionary.StockRequisitionType.ISGM;
                this.Text = "Goods Receive from Other Outlet [" + sTotal + "]";
                btnAdd.Visible = false;
                btnAddReturnToHO.Visible = false;
                btnAddOtherOutlet.Visible = false;
                btnAddSendToCSD.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnISGMRcv.Visible = true;
                btnRequisitionRcv.Visible = false;

                //Receive Button (ISGM Receive)
                btnISGMRcv.Enabled = false;
                if (_oUserPermission.CheckPermission("M39.1.1.5.1"))
                {
                    btnISGMRcv.Enabled = true;
                }

                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                chkAll.Checked = true;
                chkAll.Enabled = false;
                IsCheck = true;
            }
            DBController.Instance.CloseConnection();
            LoadCombos();
            DataLoadControl();
            
        }
        private void LoadCombos()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            //Stock Requisition Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.StockRequisitionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.StockRequisitionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0; 
        }
        private void DataLoadControl()
        {
            _oPOSRequisitions = new POSRequisitions();
            lvwItemList.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Cursor = Cursors.WaitCursor;
            _oPOSRequisitions.RefreshForPOSRT(dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex - 1, _nUIControl, txtRequisitionNo.Text.Trim(), IsCheck, Utility.WarehouseID);
            sTotal = "Total  " + "[" + _oPOSRequisitions.Count + "]";
            if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create)
            {
                this.Text = "Stock Requisition [" + sTotal + "]";
             
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
            {
                this.Text = "Return to HO [" + sTotal + "]";
                
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                
                this.Text = "ISGM to others Outlet [" + sTotal + "]";
                
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Create)
            {
                
                this.Text = "Send to CSD [" + sTotal + "]";
                
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive)
            {
                
                this.Text = "Goods Receive against Requisition [" + sTotal + "]";
                
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Receive)
            {
                this.Text = "Goods Receive from Other Outlet [" + sTotal + "]";

            }


            foreach (POSRequisition oPOSRequisition in _oPOSRequisitions)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oPOSRequisition.RequisitionNo);
                //oItem.SubItems.Add(oPOSRequisition.RequisitionNo);
                oItem.SubItems.Add(oPOSRequisition.RequisitionDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPOSRequisition.FromWHName);
                oItem.SubItems.Add(oPOSRequisition.ToWHName);
                oItem.SubItems.Add(oPOSRequisition.StatusName);
                oItem.SubItems.Add(oPOSRequisition.Remarks);
                oItem.SubItems.Add(oPOSRequisition.AuthorizeRemarks);
                oItem.SubItems.Add(oPOSRequisition.TransferRemarks);
                oItem.SubItems.Add(oPOSRequisition.ReceiveRemarks);

                oItem.Tag = oPOSRequisition;
            }
            setListViewRowColour();
            this.Cursor = Cursors.Default;
        }
        private void setListViewRowColour()
        {
            if (lvwItemList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwItemList.Items)
                {
                    if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[4].Text == "Send to HO")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[4].Text == "Approved by HO")
                    {
                        oItem.BackColor = Color.Thistle;
                    }
                    else if (oItem.SubItems[4].Text == "Transfer to Branch")
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[4].Text == "Rejected by HO")
                    {
                        oItem.BackColor = Color.Salmon;
                    }
                    else if (oItem.SubItems[4].Text == "Receive at Branch")
                    {
                        oItem.BackColor = Color.CadetBlue;
                    }
                    else if (oItem.SubItems[4].Text == "Received at Logistics")
                    {
                        oItem.BackColor = Color.LightSteelBlue;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;
                    }

                }
            }
        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create)
            {
                frmProductRequisition oForm = new frmProductRequisition((int)Dictionary.StockRequisitionType.Requisition);
                oForm.ShowDialog(oPOSRequisition);
                if (oForm._IsTrue)
                    DataLoadControl();
                
            }
            else
            {
                MessageBox.Show("Only Create status can be edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to delete Requisition No: " + oPOSRequisition.RequisitionNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        ProductBarcode oProductBarcode;
                        _oStockTran = new StockTran();
                        ProductStock oProductStock = new ProductStock();
                        ProductTransferProductSerials oPTPSs = new ProductTransferProductSerials();
                        
                        DBController.Instance.BeginNewTransaction();

                        if (oPOSRequisition.RequisitionType != (int)Dictionary.StockRequisitionType.Requisition)
                        {

                            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);
                            oPOSRequisition.GetStockRequisitionByID(oPOSRequisition.RequisitionID);
                            oPTPSs.GetProductByRequisition(oPOSRequisition.RequisitionID);
                            //Update Stock
                            foreach (POSRequisitionItem oItem in oPOSRequisition)
                            {
                                oProductStock.ProductID = oItem.ProductID;
                                oProductStock.WarehouseID = Utility.WarehouseID;
                                oProductStock.Quantity = oItem.RequisitionQty;
                                oProductStock.UpdateCurrentStock_POS(false);
                            }
                            //Update Product Serial status
                            foreach (ProductTransferProductSerial oPTPS in oPTPSs)
                            {
                                oProductBarcode = new ProductBarcode();
                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                                oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                                oProductBarcode.WarehouseID = Utility.WarehouseID;
                                oProductBarcode.UpdateProductSerialRT();

                                //Delete Product Stock History
                                oProductBarcode.GetProductSerialIDRT(oPTPS.ProductSerialNo);
                                oProductBarcode.GetProductSerialHitoryID(oProductBarcode.ProductStockSerialID);
                                oProductBarcode.DeleteProductSerialHistory(oProductBarcode.ProductStockSerialHistoryID);
                            }
                            // Delete Product Stock Tran/Tran Item/ ProductTranProductSerial
                            _oStockTran.DeleteTran(oPOSRequisition.StockTranID);
                        }

                        //Delete Requisition/Requisistion Item
                        oPOSRequisition.DeleteRequisitionPOS_HQ(oPOSRequisition.RequisitionID);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
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
                MessageBox.Show("You cannot delete Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
        private void lvwItemList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create)
            {
                frmProductRequisition oForm = new frmProductRequisition((int)Dictionary.StockRequisitionType.Requisition);
                oForm.ShowDialog(oPOSRequisition);
                if (oForm._IsTrue)
                    DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create status can be edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnRequisitionRcv_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to Receive ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Transfer_To_Branch)
            {
                frmProductReceive oForm = new frmProductReceive(1);
                oForm.ShowDialog(oPOSRequisition);
                if (oForm._IsTrue)
                    DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only 'Transfer to Branch' status clould be received", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnISGMRcv_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to Receive ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Approve_By_HO)
            {
                frmProductReceive oForm = new frmProductReceive(2);
                oForm.ShowDialog(oPOSRequisition);
                if (oForm._IsTrue)
                    DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only 'Approved by HO' status clould be received", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                nStockRequisitionID = 0;
                nFromWHID = 0;
                _oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
                nStockRequisitionID = _oPOSRequisition.RequisitionID;
                nFromWHID = _oPOSRequisition.FromWHID;
                _oPOSRequisition = new POSRequisition();
                _oPOSRequisition.RefreshStockRequisition(nStockRequisitionID, nFromWHID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptStockRequisitionView));
                oReport.SetDataSource(_oPOSRequisition);
                string sReportName = "";
                string sRequisitionNo = "";
                string sType = "";
                string sTypes = "";

                if (_oPOSRequisition.RequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                {
                    sReportName = "Requisition";
                    sRequisitionNo = "Requisition No: " + _oPOSRequisition.RequisitionNo;
                    sType = "Requisition Date: ";
                    sTypes = "Requisition Remarks: ";
                }
                else if (_oPOSRequisition.RequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                {
                    sReportName = "ISGM";
                    sRequisitionNo = "ISGM No:" + _oPOSRequisition.RequisitionNo;
                    sType = "ISGM Date: ";
                    sTypes = "ISGM Remarks: ";
                }
                else if (_oPOSRequisition.RequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                {
                    sReportName = "Return to HO";
                    sRequisitionNo = "Return No:" + _oPOSRequisition.RequisitionNo;
                    sType = "Return Date: ";
                    sTypes = "Return Remarks: ";
                }
                else if (_oPOSRequisition.RequisitionType == (int)Dictionary.StockRequisitionType.Send_To_CSD)
                {
                    sReportName = "Send to CSD";
                    sRequisitionNo = "Return No:" + _oPOSRequisition.RequisitionNo;
                    sType = "Return Date: ";
                    sTypes = "Return Remarks: ";
                }
                
                oReport.SetParameterValue("ReportName", sReportName);
                oReport.SetParameterValue("RequisitionNo", sRequisitionNo);
                oReport.SetParameterValue("RequisitionDate", sType + _oPOSRequisition.RequisitionDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("FromWH", _oPOSRequisition.FromWHName);
                oReport.SetParameterValue("ToWH", _oPOSRequisition.ToWHName);
                oReport.SetParameterValue("Remarks", sTypes + _oPOSRequisition.Remarks);
                oReport.SetParameterValue("AuthorizedRemarks", _oPOSRequisition.AuthorizeRemarks);
                oReport.SetParameterValue("Status", _oPOSRequisition.StatusName);
                oReport.SetParameterValue("TransferRemarks", _oPOSRequisition.TransferRemarks);
                oReport.SetParameterValue("ReceiveRemarks", _oPOSRequisition.ReceiveRemarks);

                if (_oPOSRequisition.AuthorizedBy != 0)
                {
                    oReport.SetParameterValue("AuthorizedBy", _oPOSRequisition.AuthorizedUser);
                }
                else
                {
                    oReport.SetParameterValue("AuthorizedBy", "NA");
                }
                if (_oPOSRequisition.AuthorizedUser == "NA")
                {
                    oReport.SetParameterValue("AuthorizedDate", "NA");
                }
                else 
                {
                    oReport.SetParameterValue("AuthorizedDate", _oPOSRequisition.AuthorizeDate.ToString());
                }
                if (_oPOSRequisition.Barcode != null)
                {
                    oReport.SetParameterValue("Barcode", _oPOSRequisition.Barcode.ToString());
                }
                else
                {
                    oReport.SetParameterValue("Barcode", "");
                }
                if (Utility.CompanyInfo == "TML")
                {
                    oReport.SetParameterValue("IsTML", true);
                }
                else
                {
                    oReport.SetParameterValue("IsTML", false);
                }
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnVatChallan_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a requisition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Reject_By_HO)
            {

                MessageBox.Show("This requisition already rejected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create|| oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Send_To_HO)
            {
                MessageBox.Show("Requisition must be approved for printing VAT challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrintVatChallanJuly20(oPOSRequisition.RequisitionType);

        }

        private void PrintVatChallanJuly20(int nRequisitionType)
        {

            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetDutyTranHO(_oPOSRequisition.RequisitionNo, nRequisitionType, "Yes");
            string sPosHOReq = "";
            if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
            {
                sPosHOReq = "Yes";
            }
            else
            {
                sPosHOReq = "No";
            }

            foreach (DutyTran oDutyTran in oDutyTranList)
            {

                DutyTran oIsVatExempted = new DutyTran();
                if (oIsVatExempted.CheckVatExemptedISGMTran(oDutyTran.DutyTranID, oDutyTran.WHID, nRequisitionType, oDutyTran.DutyTranNo))
                {

                    _oPOSRequisition = new POSRequisition();

                    _oPOSRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, nRequisitionType, "POS", sPosHOReq, oDutyTran.DutyTranNo);

                    CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65_Exempted));
                    oReport.SetDataSource(_oPOSRequisition);


                    oReport.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                    oReport.SetParameterValue("RegisteredpersonBIN", Utility.VATRegistrationNo);
                    oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                    oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                    oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                    oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                    oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                    //oReport.PrintToPrinter(1, true, 1, 1);
                    oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                    frmPrintPreview oFrom = new frmPrintPreview();
                    oFrom.ShowDialog(oReport);
                }
                else
                {
                    _oPOSRequisition = new POSRequisition();
                    _oPOSRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, nRequisitionType, "POS", sPosHOReq, oDutyTran.DutyTranNo);

                    CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65));
                    oReport.SetDataSource(_oPOSRequisition);

                    oReport.SetParameterValue("CentralRegisteredPersonAddress", Utility.CentralRegisteredPersonAddress);
                    oReport.SetParameterValue("RegisteredpersonBIN", Utility.VATRegistrationNo);
                    oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                    oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                    oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                    oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                    oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                    //oReport.PrintToPrinter(1, true, 1, 1);
                    oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);

                    frmPrintPreview oFrom = new frmPrintPreview();
                    oFrom.ShowDialog(oReport);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnUpdateVehicleNo_Click(object sender, EventArgs e)
        {
            _oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetDutyTranHO(_oPOSRequisition.RequisitionNo, nRequisitionType, "Yes");
            if (oDutyTranList[0].VehicleDetail == "")
            {
                frmProductTransfer oForm = new frmProductTransfer((int)Dictionary.StockRequisitionUIControl.ISGM_Create);
                oForm.ShowDialog(_oPOSRequisition, oDutyTranList[0].DutyTranID);
            }
            DataLoadControl();
        }
    }
}
