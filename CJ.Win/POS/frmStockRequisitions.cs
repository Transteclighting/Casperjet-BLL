using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.POS;
using CJ.Class;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Duty;

namespace CJ.Win.POS
{
    public partial class frmStockRequisitions : Form
    {
        POSRequisitions _oPOSRequisitions;
        POSRequisitions _oFromWH;
        POSRequisitions _oToWH;
        int _nUIControl = 0;
        string sTotal = "";
        bool IsCheck = false;
        int nStockRequisitionID = 0;
        int nFromWHID = 0;
        POSRequisition _oPOSRequisition;


        public frmStockRequisitions(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Authorized/Reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
               
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create ||
                oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Approve_By_HO)
            {
                //frmStockRequisitionAuthorization oForm = new frmStockRequisitionAuthorization((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive);
                frmStockRequisitionDeliveryWH oForm = new frmStockRequisitionDeliveryWH();
                oForm.ShowDialog(oPOSRequisition);
                DataLoadControl();
              
            }
            else
            {
                MessageBox.Show("Only Create & Approved status can be Authorized/Reject", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnAction_ISGM_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Authorized/Reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create)
            {
                frmStockRequisitionAuthorization oForm = new frmStockRequisitionAuthorization((int)Dictionary.StockRequisitionUIControl.ISGM_Receive);
                oForm.ShowDialog(oPOSRequisition);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Authorized/Reject", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void fromStockRequisitions_Load(object sender, EventArgs e)
        {

            if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create)
            {
                this.Text = "Create Requisition";

                btnAction.Visible = false;
                btnAction_ISGM.Visible = false;
                btnDefectiveReceive.Visible = false;
                btnReturnReceive.Visible = false;
                btnStockTransfer.Visible = false;
                btnAction_ReturnAuthorization.Visible = false;

            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Authorization)//Stock Requisition Authorization
            {
                this.Text = "Stock Requisition Authorization";

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnAction.Visible = true;
                btnAction_ISGM.Visible = false;
                btnDefectiveReceive.Visible = false;
                btnReturnReceive.Visible = false;
                btnStockTransfer.Visible = false;
                btnAction_ReturnAuthorization.Visible = false;
                chkAll.Checked = true;
                //chkAll.Enabled = false;
                IsCheck = true;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Authorization_at_HO)
            {
                this.Text = "ISGM Authorization";

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnAction.Visible = false;
                btnAction_ISGM.Visible = true;
                btnDefectiveReceive.Visible = false;
                btnReturnReceive.Visible = false;
                btnStockTransfer.Visible = false;
                btnAction_ReturnAuthorization.Visible = false;
                chkAll.Checked = true;
                IsCheck = true;

            }
            //else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Authorization)
            //{
            //    this.Text = "Defective Product Authorization";

            //    btnAdd.Visible = false;
            //    btnEdit.Visible = false;
            //    btnDelete.Visible = false;

            //    btnAction.Visible = false;
            //    btnAction_ISGM.Visible = true;
            //    btnDefectiveReceive.Visible = false;
            //    btnReturnReceive.Visible = false;
            //    btnStockTransfer.Visible = false;
            //}
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Product_Transfer_to_Outlet)
            {
                this.Text = "Stock Transfer to Outlet";

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnAction.Visible = false;
                btnAction_ISGM.Visible = false;
                btnDefectiveReceive.Visible = false;
                btnReturnReceive.Visible = false;
                btnStockTransfer.Visible = true;
                btnAction_ReturnAuthorization.Visible = false;
                chkAll.Checked = true;
                IsCheck = true;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Authorization)
            {
                this.Text = "Return Product Authorized";

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnAction.Visible = false;
                btnAction_ISGM.Visible = false;
                btnDefectiveReceive.Visible = false;
                btnReturnReceive.Visible = false;
                btnStockTransfer.Visible = false;
                btnAction_ReturnAuthorization.Visible = true;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Receive)
            {
                this.Text = "Return Product Receive from Outlet";

                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnAction.Visible = false;
                btnAction_ISGM.Visible = false;
                btnDefectiveReceive.Visible = false;
                btnReturnReceive.Visible = true;
                btnStockTransfer.Visible = false;
                btnAction_ReturnAuthorization.Visible = false;
            }
            //else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Receive_at_HO_from_CSD)
            //{
            //    this.Text = "Defective Product Receive from CSD";

            //    btnAdd.Visible = false;
            //    btnEdit.Visible = false;
            //    btnDelete.Visible = false;

            //    btnAction.Visible = false;
            //    btnAction_ISGM.Visible = false;
            //    btnDefectiveReceive.Visible = true;
            //    btnReturnReceive.Visible = false;
            //    btnStockTransfer.Visible = false;
            //}
            
            
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
            if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Authorization)
            {
                cmbStatus.SelectedIndex = 1;
                
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Authorization_at_HO)
            {
                cmbStatus.SelectedIndex = 1;
            }
            else if (_nUIControl == (int)Dictionary.StockRequisitionUIControl.Product_Transfer_to_Outlet)
            {
                cmbStatus.SelectedIndex = 3;
            }
            else
            {
                cmbStatus.SelectedIndex = 0;
            }

            _oFromWH = new POSRequisitions();
            _oFromWH.GetFromWHNToWH();

            cmbFromWH.Items.Clear();
            cmbFromWH.Items.Add("<All>");
            foreach (POSRequisition oPOSRequisition in _oFromWH)
            {
                cmbFromWH.Items.Add("[" + oPOSRequisition.FromWHCode + "]" + oPOSRequisition.FromWHName);
            }
            cmbFromWH.SelectedIndex = 0;

            _oToWH = new POSRequisitions();
            _oToWH.GetFromWHNToWH();

            cmbToWH.Items.Clear();
            cmbToWH.Items.Add("<All>");
            foreach (POSRequisition oPOSRequisition in _oToWH)
            {
                cmbToWH.Items.Add("[" + oPOSRequisition.FromWHCode + "]" + oPOSRequisition.FromWHName);
            }
            cmbToWH.SelectedIndex = 0;

        }
        private void DataLoadControl()
        {
            _oPOSRequisitions = new POSRequisitions();
            lvwItemList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nFromWHID = -1;
            int nToWHID = -1;
            if (cmbFromWH.SelectedIndex != 0)
            {
                nFromWHID = _oFromWH[cmbFromWH.SelectedIndex - 1].FromWHID;
            }
            if (cmbToWH.SelectedIndex != 0)
            {
                nToWHID = _oToWH[cmbToWH.SelectedIndex - 1].FromWHID;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oPOSRequisitions.RefreshForHO(dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex - 1, _nUIControl, txtRequisitionNo.Text.Trim(), IsCheck, nFromWHID, nToWHID);
            sTotal = "Total  " + "[" + _oPOSRequisitions.Count + "]";

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

        private void btnStockTransfer_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Approve_By_HO)
            {
                frmStockTransfer oForm = new frmStockTransfer(); 
                oForm.ShowDialog(oPOSRequisition);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnReturnReceive_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Receive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Approve_By_HO)
            {
                frmISGMReceive oForm = new frmISGMReceive();
                oForm.ShowDialog(oPOSRequisition);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Authorized/Approve status can be Received", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
            
        }
        private void btnAction_ReturnAuthorization_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Authorized/Reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            POSRequisition oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            if (oPOSRequisition.Status == (int)Dictionary.StockRequisitionStatus.Create)
            {
                frmStockRequisitionAuthorization oForm = new frmStockRequisitionAuthorization((int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create);
                
                oForm.ShowDialog(oPOSRequisition);
                DataLoadControl();
                

            }
            else
            {
                MessageBox.Show("Only Create status can be Authorized/Reject", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
        }

        private void btnDefectiveReceive_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStockRequisition oFrom = new frmStockRequisition();
            oFrom.ShowDialog();
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
                frmStockRequisition oForm = new frmStockRequisition();
                oForm.ShowDialog(oPOSRequisition);
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

                        DBController.Instance.BeginNewTransaction();
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

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

        private void PrintVat()
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();

            _oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetDutyTranHO(_oPOSRequisition.RequisitionNo, _oPOSRequisition.RequisitionType, "No");
            int nRequisitionType = _oPOSRequisition.RequisitionType;

            foreach (DutyTran oDutyTran in oDutyTranList)
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                DutyTran oIsVatExempted = new DutyTran();
                if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
                {
                    POSRequisition _oPOSRequisition = new POSRequisition();
                    _oPOSRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, _oPOSRequisition.RequisitionType, "HO", "No", oDutyTran.DutyTranNo);
                    if (oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(oSystemInfo.NewVatActivationDate))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65_Exempted));

                        oReport.SetDataSource(_oPOSRequisition);

                        oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                        oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail.ToString());
                        //oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                        this.Cursor = Cursors.Default;

                    }
                    else
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptMushak65_Exempted));
                        oReport.SetDataSource(_oPOSRequisition);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                        // oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                        this.Cursor = Cursors.Default;

                    }
                }
                else
                {
                    POSRequisition _oPOSRequisition = new POSRequisition();
                    _oPOSRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, _oPOSRequisition.RequisitionType, "HO", "No", oDutyTran.DutyTranNo);
                    if (oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(oSystemInfo.NewVatActivationDate))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65));
                        oReport.SetDataSource(_oPOSRequisition);
                        oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                        oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail.ToString());
                        //oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptMushak65));
                        oReport.SetDataSource(_oPOSRequisition);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                        //oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                       
                    }

                }
            }
            
        }

        private void btnVATPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PrintVat();
            this.Cursor = Cursors.Default;
            //if (lvwItemList.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //this.Cursor = Cursors.WaitCursor;
            //_oPOSRequisition = (POSRequisition)lvwItemList.SelectedItems[0].Tag;
            //DutyTranList oDutyTranList = new DutyTranList();
            //oDutyTranList.GetDutyTranHO(_oPOSRequisition.RequisitionNo, _oPOSRequisition.RequisitionType, "No");
            //int nRequisitionType = _oPOSRequisition.RequisitionType;
            //foreach (DutyTran oDutyTran in oDutyTranList)
            //{
            //    if (!DBController.Instance.CheckConnection())
            //    {
            //        DBController.Instance.OpenNewConnection();
            //    }

            //    DutyTran oIsVatExempted = new DutyTran();
            //    if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
            //    {
            //        _oPOSRequisition = new POSRequisition();
            //        _oPOSRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, nRequisitionType, "HO", "No", oDutyTran.DutyTranNo);
            //        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptMushak65_Exempted));
            //        oReport.SetDataSource(_oPOSRequisition);
            //       // oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
            //        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
            //        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
            //        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
            //        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
            //        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
            //        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
            //        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
            //        oReport.PrintToPrinter(1, true, 1, 1);
            //    }
            //    else
            //    {

            //        _oPOSRequisition = new POSRequisition();
            //        _oPOSRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, nRequisitionType, "HO", "No", oDutyTran.DutyTranNo);
            //        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptMushak65));
            //        oReport.SetDataSource(_oPOSRequisition);
            //        ///oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
            //        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
            //        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
            //        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
            //        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
            //        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
            //        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
            //        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
            //        oReport.PrintToPrinter(1, true, 1, 1);
            //    }
            //}
            //this.Cursor = Cursors.Default;



        }
    }
}