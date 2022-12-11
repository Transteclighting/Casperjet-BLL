using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Win.CSD.CallCenter; 

namespace CJ.Win.CSD.Workshop
{
    public partial class frmJobUpdate : Form
    {
        int _UIControl = 0;
        CSDJob _oCSDJob;
        JobHistory _oJobHistory;
        ProactiveCall _oProactiveCall;
        SpareParts _oSpareParts;
        CSDJobSubStatuss _oCSDJobSubStatuss;
        bool _bIsCallCenter = false;
        //public bool _IsAction = false;
        CSDServiceCharge _oCSDServiceCharge;
        CSDServiceChargeProduct _oCSDServiceChargeProduct;
        CSDServiceChargeCustomers _oCSDServiceChargeCustomers;
        public bool _bIsAnyActivityDone = false;
        double _nTotalSpCharge = 0;

        public frmJobUpdate(int nIUControl, CSDJob oCSDJob, bool bIsCallCenter)
        {
            InitializeComponent();
            _oCSDJob = new CSDJob();
            _oCSDJob = oCSDJob;
            _UIControl = nIUControl;
            _bIsCallCenter = bIsCallCenter;
            if (_bIsCallCenter == true)
            {
                btnJobHistory.Text = "Job Detail";
                btnCommunication.Visible = true;
            }
            else
            {
                btnJobHistory.Text = "Job History";
                btnCommunication.Visible = false;
            }
            if (oCSDJob.VisitingDate != null && oCSDJob.VisitingTimeFrom != null && oCSDJob.VisitingTimeTo != null)
            {
                dtVisitingDate.Value = Convert.ToDateTime(oCSDJob.VisitingDate.ToString());
                dtVisitingTimeFrom.Value = Convert.ToDateTime(oCSDJob.VisitingTimeFrom.ToString());
                dtVisitingTimeTo.Value = Convert.ToDateTime(oCSDJob.VisitingTimeTo.ToString());
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput()
        {

            if (_UIControl == (int)Dictionary.JobStatus.Pending || _UIControl == (int)Dictionary.JobStatus.Estimated)
            {
                if (txtEstimatedRemarks.Text.Trim() == "")
                {
                    MessageBox.Show("Please Input Remarks", "Input Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtEstimatedRemarks.Focus();
                    return false;
                }
                if (_UIControl == (int)Dictionary.JobStatus.Pending)
                {
                    if (cmbSubStatus.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select sub-status", "Input Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbSubStatus.Focus();
                        return false;
                    }
                }

            }
            else
            {
                if (_UIControl == (int)Dictionary.JobStatus.Return || _UIControl == (int)Dictionary.JobStatus.Replace)
                {
                    if (txtRemarks.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Input Remarks", "Input Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtRemarks.Focus();
                        return false;
                    }
                }
            }
            if (chkEDD.Checked == true)
            {
                DateTime _dToday = DateTime.Now.Date;
                if (_dToday > dtEDDExten.Value.Date)
                {
                    MessageBox.Show("Propose feedback date must be greater or equal Today ", "Input Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtRemarks.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bIsAnyActivityDone = true;
                this.Close();
            }
        }

        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                if (_UIControl == (int)Dictionary.JobStatus.Estimated)
                {
                    foreach (DataGridViewRow oItemRow in dgvParts.Rows)
                    {
                        if (oItemRow.Index < dgvParts.Rows.Count - 1)
                        {

                            SpareParts _oSpareParts = new SpareParts();

                            _oSpareParts.JobID = _oCSDJob.JobID;
                            _oSpareParts.PartsID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            _oSpareParts.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            _oSpareParts.Qty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            _oSpareParts.AddEstimatedSpareParts();

                        }
                    }

                    _oCSDJob.Status = _UIControl;
                    _oCSDJob.SubStatus = 0;
                    _oCSDJob.UpdateUserID = Utility.UserId;
                    _oCSDJob.UpdateDate = DateTime.Now;
                    _oCSDJob.UpdateJobStatus();
                    AddJobHistory(null);
                }
                else if (_UIControl == (int)Dictionary.JobStatus.Pending)
                {
                    foreach (DataGridViewRow oItemRow in dgvParts.Rows)
                    {
                        if (oItemRow.Index < dgvParts.Rows.Count - 1)
                        {
                            CSDPendingSpareParts _oCSDPendingSpareParts = new CSDPendingSpareParts();

                            _oCSDPendingSpareParts.JobID = _oCSDJob.JobID;
                            _oCSDPendingSpareParts.PartsID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            _oCSDPendingSpareParts.UnitPrice = Convert.ToString(oItemRow.Cells[3].Value.ToString());
                            _oCSDPendingSpareParts.Qty = Convert.ToString(oItemRow.Cells[4].Value.ToString());
                            _oCSDPendingSpareParts.CreateUserID = Utility.UserId;
                            _oCSDPendingSpareParts.CreateDate = DateTime.Now;
                            _oCSDPendingSpareParts.Add();
                        }
                    }

                    _oCSDJob.Status = _UIControl;
                    _oCSDJob.SubStatus = _oCSDJobSubStatuss[cmbSubStatus.SelectedIndex - 1].SubStatusID;
                    _oCSDJob.UpdateUserID = Utility.UserId;
                    _oCSDJob.UpdateDate = DateTime.Now;
                    _oCSDJob.UpdateJobStatus();
                    AddJobHistory(_oCSDJob.SubStatus);
                    CSDJobScheduleHistory();


                }
                else if (_UIControl == (int)Dictionary.JobStatus.ServiceProvided || _UIControl == (int)Dictionary.JobStatus.Repaired)
                {
                    if (_oCSDJob.ServiceType != (int)Dictionary.ServiceType.Walkin)
                    {
                        CSDJob _GetTechType = new CSDJob();
                        int nTechType = _GetTechType.GetTechTypeByJob(_oCSDJob.JobID);

                        if (nTechType == (int)Dictionary.CSDTechnicianType.ThirdParty)
                        {
                            _oCSDJob.Status = _UIControl;
                            _oCSDJob.SubStatus = 0;
                            _oCSDJob.UpdateUserID = Utility.UserId;
                            _oCSDJob.UpdateDate = DateTime.Now;
                            _oCSDJob.UpdateJobStatus();
                            AddJobHistory(null);

                            if (_UIControl == (int)Dictionary.JobStatus.ServiceProvided)
                            {
                                _GetTechType.JobID = _oCSDJob.JobID;
                                _GetTechType.IsDelivered = (int)Dictionary.YesOrNoStatus.YES;
                                _GetTechType.DeliveryDate = DateTime.Now;
                                _GetTechType.UpdateDeliveryStatus();
                            }

                        }
                        else
                        {

                            _oCSDJob.Status = _UIControl;
                            _oCSDJob.SubStatus = 0;
                            _oCSDJob.UpdateUserID = Utility.UserId;
                            _oCSDJob.UpdateDate = DateTime.Now;
                            _oCSDJob.UpdateJobStatus();
                            AddJobHistory(null);
                        }
                    }

                    if (_oCSDJob.OwnOrOtherTechnician == (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician && _UIControl == (int)Dictionary.JobStatus.ServiceProvided)
                    {
                        if (txtTpMatCharge.Text.Trim() != string.Empty)
                        {
                            _oCSDJob.TPMatCharge = Convert.ToDouble(txtTpMatCharge.Text.Trim());
                        }
                        if (txtTpGasCharge.Text.Trim() != string.Empty)
                        {
                            _oCSDJob.TPGasCharge = Convert.ToDouble(txtTpGasCharge.Text.Trim());
                        }
                        if (txtTpOtherCharge.Text.Trim() != string.Empty)
                        {
                            _oCSDJob.TPOtherCharge = Convert.ToDouble(txtTpOtherCharge.Text.Trim());
                        }
                        _oCSDJob.UpdateTpCharge();
                        if (_oCSDJob.ServiceType == (int)Dictionary.ServiceType.Walkin)
                        {
                            if (_bIsCallCenter)
                            {
                                _oCSDJob.Status = (int)Dictionary.JobStatus.Delivered;
                            }
                            else
                            {
                                _oCSDJob.Status = _UIControl;
                            }
                            _oCSDJob.SubStatus = 0;
                            _oCSDJob.UpdateUserID = Utility.UserId;
                            _oCSDJob.UpdateDate = DateTime.Now;
                            _oCSDJob.UpdateJobStatus();
                            AddJobHistory(null);
                        }
                    }
                }
                else
                {
                    if (_oCSDJob.ServiceType == (int)Dictionary.ServiceType.Walkin && _bIsCallCenter)
                    {
                        _oCSDJob.Status = (int)Dictionary.JobStatus.Delivered;
                    }
                    else
                    {
                        _oCSDJob.Status = _UIControl;
                    }
                    _oCSDJob.SubStatus = 0;
                    _oCSDJob.UpdateUserID = Utility.UserId;
                    _oCSDJob.UpdateDate = DateTime.Now;
                    _oCSDJob.UpdateJobStatus();
                    AddJobHistory(null);
                }

                //Critical, Suspended, Return, Replace, Estimated
                if (chkEDD.Checked == true)
                {
                    AddProactiveCall();
                }
                else
                {
                    if (_UIControl == (int)Dictionary.JobStatus.Return || _UIControl == (int)Dictionary.JobStatus.Replace || _UIControl == (int)Dictionary.JobStatus.Estimated)
                    {
                        AddProactiveCall();
                    }
                    else if (_UIControl == (int)Dictionary.JobStatus.Pending)
                    {
                        if (_oCSDJob.SubStatus != 6)//Reshedule
                        {
                            AddProactiveCall();
                        }

                    }
                }
                if (_UIControl == (int)Dictionary.JobStatus.Pending || _UIControl == (int)Dictionary.JobStatus.Estimated)
                {
                    if (_UIControl == (int)Dictionary.JobStatus.Estimated)
                    {
                        _oCSDJob.EstScAmount = Convert.ToDouble(txtServiceCharge.Text.Trim());
                        if (txtTotalSpareCharge.Text != string.Empty)
                        {
                            _oCSDJob.EstSpAmount = Convert.ToDouble(txtTotalSpareCharge.Text.Trim());
                        }
                        _oCSDJob.UpdateEstimatedCharge();
                    }
                    else if (_UIControl == (int)Dictionary.JobStatus.Pending)
                    {
                        if (txtTotalSpareCharge.Text != string.Empty)
                        {
                            _oCSDJob.EstSpAmount = Convert.ToDouble(txtTotalSpareCharge.Text.Trim());
                        }
                        _oCSDJob.UpdateEstimatedCharge();
                    }


                }
                DBController.Instance.CommitTran();

                DBController.Instance.BeginNewTransaction();
                SMSMaker _oSMSMaker;
                _oSMSMaker = new SMSMaker();
                if (_UIControl == (int)Dictionary.JobStatus.Pending)
                {
                    if (_oCSDJob.SubStatus == (int)Dictionary.JobStatusSub.Re_Scheduled)
                    {
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_Assign_Re_Schedule_Customer, _oCSDJob.JobID);
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Technician, _oCSDJob.JobID);
                        if (_oCSDJob.OwnOrOtherTechnician == (int)Dictionary.CSDTechnicianType.ThirdParty)
                        {
                            _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_TPManager, _oCSDJob.JobID);
                            _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_TPTech_Job, _oCSDJob.JobID);
                        }
                        else
                        {
                            _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_OwnTech_Job, _oCSDJob.JobID);
                        }
                    }
                    else if (_oCSDJob.SubStatus == (int)Dictionary.JobStatusSub.Pending_for_Local_Parts || _oCSDJob.SubStatus == (int)Dictionary.JobStatusSub.Pending_for_Foreign_Parts)
                    {
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_HCall_EDD_ExtentionForParts_Customer_Source, _oCSDJob.JobID);
                    }

                }
                else if (_UIControl == (int)Dictionary.JobStatus.Estimated)
                {
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_HCall_Estimate_Confirmation_Customer, _oCSDJob.JobID);
                }
                _oCSDJob.UpdateProductLocation();
                DBController.Instance.CommitTran();
               
                MessageBox.Show("Job Update Successfully", "Status Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Updating Job: " + ex, "Error Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssuePartsAgaintsJob(int nJobID)
        {
            SPTrans _oSPTrans = new SPTrans();

            lvwSPIssues.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSPTrans.GetIssuePartsByJobID(nJobID);
            foreach (SPTran oSPTran in _oSPTrans)
            {
                ListViewItem oItem = lvwSPIssues.Items.Add(oSPTran.PartCode.ToString());
                oItem.SubItems.Add(oSPTran.PartName);
                oItem.SubItems.Add(oSPTran.Qty.ToString());
                oItem.SubItems.Add(oSPTran.TotalPrice.ToString());
                oItem.SubItems.Add(oSPTran.TranDate.ToShortDateString());
                //oItem.Tag = oSPTran;

            }

        }

        private void LoadCombo(int nStatusID, int nServiceType)
        {
            _oCSDJobSubStatuss = new CSDJobSubStatuss();
            DBController.Instance.OpenNewConnection();
            _oCSDJobSubStatuss.RefreshByStatusID(nStatusID, nServiceType);
            cmbSubStatus.Items.Clear();
            cmbSubStatus.Items.Add("--Select--");
            foreach (CSDJobSubStatus oCSDJobSubStatus in _oCSDJobSubStatuss)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oCSDJobSubStatus.Name;
                //item.Value = oCSDJobSubStatus.SubStatusID.ToString();
                //cmbSubStatus.Items.Add(item);

                cmbSubStatus.Items.Add(oCSDJobSubStatus.Name);
            }
            cmbSubStatus.SelectedIndex = 0;

        }

        private void frmJobUpdate_Load(object sender, EventArgs e)
        {
            if (_UIControl == (int)Dictionary.JobStatus.Pending)
            {
                txtTotalSpareCharge.ReadOnly = true;
                LoadCombo((int)Dictionary.JobStatus.Pending, _oCSDJob.ServiceType);
            }
            dtEDDExten.Enabled = false;
            txtRemarks.Visible = true;
            dgvParts.Visible = false;
            lblEstimatedRemarks.Visible = false;
            txtEstimatedRemarks.Visible = false;

            lblSubStatus.Visible = false;
            cmbSubStatus.Visible = false;

            lblJobNo.Text = _oCSDJob.JobNo;
            lblJobCreateDate.Text = _oCSDJob.CreateDate.ToString("dd-MMM-yyyy");
            lblJobType.Text = _oCSDJob.JobTypeDes;
            lblFeedbackDate.Text = _oCSDJob.LastFeedBackDate.ToString("dd-MMM-yyyy");
            lblCustomer.Text = _oCSDJob.CustomerName;
            lblCurrentStatus.Text = _oCSDJob.StatusName;
            lblProduct.Text = "[" + _oCSDJob.ProductCode + "] " + _oCSDJob.ProductName;
            lblRemarks.Text = _oCSDJob.Remarks;

            if (_UIControl == (int)Dictionary.JobStatus.Untouched)
            {
                this.Text = " Job Status: Untouched";
                InstructionHide();
            }
            else if (_UIControl == (int)Dictionary.JobStatus.WorkInProgress)
            {
                this.Text = " Job Status: Work-in-Progress";
                InstructionHide();
            }
            else if (_UIControl == (int)Dictionary.JobStatus.Critical)
            {
                this.Text = " Job Status: Critical";
            }
            else if (_UIControl == (int)Dictionary.JobStatus.Pending)
            {
                this.Text = " Job Status: Pending";
                label.Text = "Pending Parts";
                lblSubStatus.Visible = true;
                cmbSubStatus.Visible = true;

                txtRemarks.Visible = false;
                dgvParts.Visible = true;
                lblEstimatedRemarks.Visible = true;
                txtEstimatedRemarks.Visible = true;
            }
            else if (_UIControl == (int)Dictionary.JobStatus.Return)
            {
                this.Text = " Job Status: Return";
            }
            else if (_UIControl == (int)Dictionary.JobStatus.Replace)
            {
                this.Text = " Job Status: Replace";
            }
            else if (_UIControl == (int)Dictionary.JobStatus.Estimated)
            {
                this.Text = " Job Status: Estimated";
                label.Text = "Estimated Parts";
                txtRemarks.Visible = false;
                dgvParts.Visible = true;
                lblEstimatedRemarks.Visible = true;
                txtEstimatedRemarks.Visible = true;
                lblServiceCharge.Visible = true;
                txtServiceCharge.Visible = true;
                lblTotalSpareCharge.Visible = true;
                txtTotalSpareCharge.Visible = true;
                ViewCharges();
            }
            else if (_UIControl == (int)Dictionary.JobStatus.ReadyForTest)
            {
                this.Text = " Job Status: Ready for Test";
                InstructionHide();
            }
            else if (_UIControl == (int)Dictionary.JobStatus.Repaired)
            {
                if (_oCSDJob.ServiceType == (int)Dictionary.ServiceType.Installation)
                {
                    this.Text = " Job Status: Installed";
                }
                else
                {
                    this.Text = " Job Status: Repaired";
                }
            }
            else if (_UIControl == (int)Dictionary.JobStatus.ReadyForDelivery)
            {
                this.Text = " Job Status: Ready for Delivery";
            }

            IssuePartsAgaintsJob(_oCSDJob.JobID);
            txtTotalSpareCharge.Text = "0.00";

            if (_oCSDJob.OwnOrOtherTechnician == (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician && _UIControl == (int)Dictionary.JobStatus.ServiceProvided)
            {
                grbTpCharge.Visible = true;
            }

        }

        private void AddJobHistory(object nSubStatusID)
        {
            _oJobHistory = new JobHistory();

            _oJobHistory.JobID = _oCSDJob.JobID;
            //if (_bIsCallCenter)
            //{
            //    //_oJobHistory.StatusID = (int)Dictionary.JobStatus.Delivered;
            //}
            //else
            //{
                _oJobHistory.StatusID = _UIControl;
            //}
            _oJobHistory.CreateUserID = Utility.UserId;
            _oJobHistory.CreateDate = DateTime.Now;
            if (_UIControl == (int)Dictionary.JobStatus.Pending || _UIControl == (int)Dictionary.JobStatus.Estimated)
            {
                _oJobHistory.Remarks = txtEstimatedRemarks.Text;
            }
            else
            {
                _oJobHistory.Remarks = txtRemarks.Text;
            }

            _oJobHistory.Add(nSubStatusID);
            _oCSDJob.StatusReason = _oJobHistory.Remarks;
            _oCSDJob.UpdateStatusReason();
        }

        private void InstructionHide()
        {
            //lblInstruction.Visible = false;
            //txtInstruction.Visible = false;
        }

        private void AddProactiveCall()
        {
            _oProactiveCall = new ProactiveCall();

            _oProactiveCall.JobID = _oCSDJob.JobID;
            _oProactiveCall.NextFollowUpDate = DateTime.Today.Date;
            if (chkEDD.Checked == true)
            {
                _oProactiveCall.ProposeFollowupDate = dtEDDExten.Value.Date;
            }
            else
            {
                _oProactiveCall.ProposeFollowupDate = null;
            }
            _oProactiveCall.Remarks = txtRemarks.Text;
            _oProactiveCall.LastCommunication = "";
            _oProactiveCall.CreateUserID = Utility.UserId;
            _oProactiveCall.CreateDate = DateTime.Now;
            _oProactiveCall.IsBanForever = (int)Dictionary.YesOrNoStatus.NO;

            _oProactiveCall.Add();
        }

        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 0 && dgvParts.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvParts.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvParts.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sCode = dgvParts.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oSpareParts = new SpareParts();
                    DBController.Instance.OpenNewConnection();
                    _oSpareParts.Code = sCode;
                    _oSpareParts.RefreshByCode();

                    if (_oSpareParts.Flag == false)
                    {
                        MessageBox.Show("Invalied Spare Parts Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvParts.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvParts.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSpareParts.Name;
                    dgvParts.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oSpareParts.SalePrice.ToString();
                    dgvParts.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (_oSpareParts.ID).ToString();

                    dgvParts.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (nColumnIndex == 4)
            {
                dgvParts.Rows[nRowIndex].Cells[5].Value = Convert.ToDouble(dgvParts.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvParts.Rows[nRowIndex].Cells[4].Value.ToString());
                _nTotalSpCharge += Convert.ToDouble(dgvParts.Rows[nRowIndex].Cells[5].Value);
            }
            txtTotalSpareCharge.Text = _nTotalSpCharge.ToString();
        }

        private int checkDuplicateOfficeItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvParts.Rows)
            {
                if (oItemRow.Index < dgvParts.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void dgvParts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmSparePartSearch oForm = new frmSparePartSearch();
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvParts);

                oRow.Cells[0].Value = oForm.sSPCode;
                oRow.Cells[2].Value = oForm.sSPName;
                oRow.Cells[3].Value = oForm.sSalePrice;
                oRow.Cells[6].Value = oForm.nSPId;


                if (oForm.sSPCode != null)
                {
                    int nRowIndex = dgvParts.Rows.Add(oRow);

                    if (checkDuplicateOfficeItem(dgvParts.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvParts.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvParts.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }


                }

            }
        }

        private void btnJobHistory_Click(object sender, EventArgs e)
        {
            if (_bIsCallCenter == true)
            {
                frmJobDetail ofrom = new frmJobDetail();
                ofrom.ShowDialog(_oCSDJob.JobNo, 0);
            }
            else
            {
                frmCSDJobHistory oForm = new frmCSDJobHistory();
                oForm.ShowDialog(_oCSDJob);
            }
        }

        private void chkEDD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEDD.Checked == true)
            {
                dtEDDExten.Enabled = true;
            }
            else
            {
                dtEDDExten.Enabled = false;
            }
        }

        private void cmbSubStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubStatus.SelectedIndex != 0)
            {
                int nSubStatus = _oCSDJobSubStatuss[cmbSubStatus.SelectedIndex - 1].SubStatusID;
                if (nSubStatus == 6) //SubStatus, 6 = Reschedule
                {
                    lblVisitingDate.Visible = true;
                    dtVisitingDate.Visible = true;
                    lblVisitingTimeFrom.Visible = true;
                    dtVisitingTimeFrom.Visible = true;
                    lblVisitingTimeTo.Visible = true;
                    dtVisitingTimeTo.Visible = true;
                }
                else
                {
                    lblVisitingDate.Visible = false;
                    dtVisitingDate.Visible = false;
                    lblVisitingTimeFrom.Visible = false;
                    dtVisitingTimeFrom.Visible = false;
                    lblVisitingTimeTo.Visible = false;
                    dtVisitingTimeTo.Visible = false;
                }

                if (nSubStatus == 1 || nSubStatus == 2) //1=pending for local sp, 2 = pending for foreign sp
                {
                    lblTotalSpareCharge.Visible = true;
                    txtTotalSpareCharge.Visible = true;
                }
                else
                {
                    lblTotalSpareCharge.Visible = false;
                    txtTotalSpareCharge.Visible = false;
                }

            }
        }

        private void CSDJobScheduleHistory()
        {
            //Add CSDJobScheduleHistory
            CSDJobScheduleHistory oCSDJobScheduleHistory = new CSDJobScheduleHistory();
            oCSDJobScheduleHistory.JobID = _oCSDJob.JobID;
            oCSDJobScheduleHistory.VisitingDate = dtVisitingDate.Value.Date;
            oCSDJobScheduleHistory.VisitingTimeFrom = dtVisitingTimeFrom.Value.TimeOfDay;
            oCSDJobScheduleHistory.VisitingTimeTo = dtVisitingTimeTo.Value.TimeOfDay;
            oCSDJobScheduleHistory.Type = 2;
            oCSDJobScheduleHistory.CreateUserID = Utility.UserId;
            oCSDJobScheduleHistory.CreateDate = DateTime.Now;
            oCSDJobScheduleHistory.Add();

            //Update CSDJob
            CSDJob oCSDJob = new CSDJob();
            oCSDJob.JobID = _oCSDJob.JobID;
            oCSDJob.VisitingDate = dtVisitingDate.Value.Date;
            oCSDJob.VisitingTimeFrom = dtVisitingTimeFrom.Value.TimeOfDay;
            oCSDJob.VisitingTimeTo = dtVisitingTimeTo.Value.TimeOfDay;
            oCSDJob.UpdateVisitingTime();

        }

        private void btnCommunication_Click(object sender, EventArgs e)
        {
            frmCommunication oform = new frmCommunication();
            oform.ShowDialog(_oCSDJob.JobID, 0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ViewCharges()
        {
            _oCSDServiceCharge = new CSDServiceCharge();
            _oCSDServiceChargeProduct = new CSDServiceChargeProduct();
            _oCSDServiceCharge.ServiceChargeID = _oCSDServiceChargeProduct.GetServiceChargeID(_oCSDJob.ProductID);
            _oCSDServiceCharge.Refresh();


            _oCSDServiceChargeCustomers = new CSDServiceChargeCustomers();
            _oCSDServiceChargeCustomers.RefreshBySCID(_oCSDServiceCharge.ServiceChargeID);
            foreach (CSDServiceChargeCustomer oCSDServiceChargeCustomer in _oCSDServiceChargeCustomers)
            {
                if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Service_Charge)
                {
                    txtServiceCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
            }

        }

    }
}