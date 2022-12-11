using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win.CSD.CallCenter
{
    public partial class frmJobDetail : Form
    {
        SparePartsRs _oSparePartsRs;
        CSDJob _oCSDJob;
        GeoLocation _oGeoLocation;

        CSDServiceCharge _oCSDServiceCharge;
        CSDServiceChargeCustomers _oCSDServiceChargeCustomers;
        CSDServiceChargeProduct _oCSDServiceChargeProduct;
        CSDJobBill _oCSDJobBill;

        CSDServiceChargeCustomer _oCSDServiceChargeCustomer;
        CSDEstimatedSparePartses _oCSDEstimatedSparePartses;

        CSDPendingSparePartss _oCSDPendingSparePartses;


        int _nProactiveCallID;

        double _nTotalMaterialCost = 0;

        public frmJobDetail()
        {
            DBController.Instance.OpenNewConnection();
            InitializeComponent();
        }

        public void ShowDialog(string sJobNo, int nProactiveCallID)
        {
            if (sJobNo != "")
            {
                _nProactiveCallID = nProactiveCallID;
                ctlCSDJob1.txtCode.Text = sJobNo;
                ctlCSDJob1.Enabled = false;
            }
            this.ShowDialog();
        }
        private void ctlCSDJob1_ChangeSelection(object sender, EventArgs e)
        {
            ResetTextBox();
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                LoadAllTextBoxes();
                LoadIssuedSpareParts();
                this.Cursor = Cursors.Default;
            }
        }
        private void LoadAllTextBoxes()
        {
            _oCSDJob = ctlCSDJob1.SelectedJob;
            //Load Job Info
            txtJobStatus.Text = Enum.GetName(typeof(Dictionary.JobStatus), _oCSDJob.Status);
            txtServiceType.Text = Enum.GetName(typeof(Dictionary.ServiceType), _oCSDJob.ServiceType);
            txtJobType.Text = Enum.GetName(typeof(Dictionary.CSDJobType), _oCSDJob.JobType);
            if (_oCSDJob.InvoiceDate != null)
            {
                txtPurchaseDate.Text = Convert.ToDateTime(_oCSDJob.InvoiceDate).ToShortDateString();
            }
            txtSubStatus.Text = _oCSDJob.SubStatusName;
            txtStatusReason.Text = _oCSDJob.StatusReason;
            txtBarcodeSl.Text = _oCSDJob.ProductSerialNo;
            txtCreateDate.Text = _oCSDJob.CreateDate.ToShortDateString();
            txtFeedbackDate.Text = _oCSDJob.LastFeedBackDate.ToShortDateString();
            txtRemarks.Text = _oCSDJob.Remarks;
            txtHaveBackup.Text = Enum.GetName(typeof(Dictionary.HaveBackupset),_oCSDJob.HaveBackupset); 
            txtInvoiceNo.Text = _oCSDJob.InvoiceNo;
            txtGspnJob.Text = _oCSDJob.GSPNJobNo;
            
            //Load Customer Info
            txtCustomerName.Text = _oCSDJob.CustomerName;
            txtMobileNo.Text = _oCSDJob.MobileNo;
            txtTelephone.Text = _oCSDJob.TelePhone;
            txtAddress.Text = _oCSDJob.CustomerAddress;
            txtEmail.Text = _oCSDJob.Email;
            _oGeoLocation = new GeoLocation();
            _oGeoLocation.RefreshByGeoLocationID(_oCSDJob.ThanaID);
            txtThana.Text = _oGeoLocation.ThanaName;
            txtDistrict.Text = _oGeoLocation.DistrictName;

            txtMaterialTotalCharge.Text = _nTotalMaterialCost.ToString();
            txtMatChargePayable.Text = _nTotalMaterialCost.ToString();
            _oCSDJobBill = new CSDJobBill();
            _oCSDJobBill.JobID = _oCSDJob.JobID;
            if (_oCSDJobBill.RefreshByJobID() > 0)
            {
                LoadExistictCharge();
            }
            else
            {
                LoadCurrentCharge();
            }

            Technician oTechnician = new Technician();
            oTechnician.TechnicianID = _oCSDJob.AssignTo;
            oTechnician.RefreshByTechnicianID();

            if (oTechnician != null)
            {
                txtAssignTo.Text = oTechnician.Name + '[' + oTechnician.Code + ']';
                txtTechnicianMobile.Text = oTechnician.MobileNo;
            }

            InterServiceR oInterServiceR = new InterServiceR();
            oInterServiceR.InterServiceID = oTechnician.ThirdPartyID;
            oInterServiceR.RefreshByInterServiceID();

            txtThirdPartyName.Text = oInterServiceR.Name;
            txtThirdPartyMobile.Text = oInterServiceR.Mobile;

            TechnicalSupervisor oTechnicalSupervisor = new TechnicalSupervisor();
            oTechnicalSupervisor.SupervisorID = oTechnician.SupervisorID;
            oTechnicalSupervisor.Refresh();
            txtSupervisorName.Text = oTechnicalSupervisor.EmployeeName;
            txtSUpervisorMobile.Text = Convert.ToString(oTechnicalSupervisor.MobileNoSup);

            if (_oCSDJob.VisitingDate != null && _oCSDJob.VisitingTimeFrom != null && _oCSDJob.VisitingTimeTo != null)
            {
                txtVisitingDate.Text = Convert.ToDateTime(_oCSDJob.VisitingDate).ToString("dd-MMM-yyyy");
                txtVisitingTimeFrom.Text = Convert.ToDateTime(_oCSDJob.VisitingTimeFrom).ToString("h:mm tt");
                txtVisitingTimeTo.Text = Convert.ToDateTime(_oCSDJob.VisitingTimeTo).ToString("h:mm tt");
            }
            txtProductLcation.Text = Enum.GetName(typeof(Dictionary.ProductLocation), _oCSDJob.ProductLocation);
            txtProductPhysicalLocation.Text = Enum.GetName(typeof(Dictionary.ProductPhysicalLocation), _oCSDJob.ProductPhysicalLocation);

            ProductFault _oProductFault = new ProductFault();
            if (_oCSDJob.ActualFaultID == 0)
            {
                _oProductFault.FaultID = _oProductFault.GetFaultParentID(_oCSDJob.PrimaryFaultID);
                _oProductFault.RefreshByID();

                txtProductFault.Text = _oProductFault.FaultDescription;

                _oProductFault.FaultID = _oCSDJob.PrimaryFaultID;
                _oProductFault.RefreshByID();
                txtProductFault.Text += " | " + _oProductFault.FaultDescription;
            }
            else if (_oCSDJob.ActualFaultID > 0)
            {
                _oProductFault.FaultID = _oProductFault.GetFaultParentID(_oCSDJob.ActualFaultID);
                _oProductFault.RefreshByID();

                txtProductFault.Text = _oProductFault.FaultDescription;

                _oProductFault.FaultID = _oCSDJob.ActualFaultID;
                _oProductFault.RefreshByID();
                txtProductFault.Text += " | " + _oProductFault.FaultDescription;
            }
            User oUser = new User();
            oUser.UserId = _oCSDJob.CreateUserID;
            oUser.RefreshByUserID();
            txtCreatedBy.Text = oUser.Username;

            if (_oCSDJob.JobType == (int)Dictionary.CSDJobType.Paid || _oCSDJob.JobType == (int)Dictionary.CSDJobType.ComponentWarranty)
            {
                rdoServiceCharge.Checked = true;
            }
            else
            {
                //rdoServiceCharge.Enabled = false;
                //rdoInspectionCharge.Enabled = false;
                //rdoInstallationCharge.Enabled = false;
            }
        }

        private void LoadCurrentCharge()
        {
            //Load Charges
            _oCSDServiceCharge = new CSDServiceCharge();
            _oCSDServiceChargeProduct = new CSDServiceChargeProduct();
            _oCSDServiceCharge.ServiceChargeID = _oCSDServiceChargeProduct.GetServiceChargeID(_oCSDJob.ProductID);

            _oCSDServiceChargeCustomers = new CSDServiceChargeCustomers();
            _oCSDServiceChargeCustomers.RefreshBySCID(_oCSDServiceCharge.ServiceChargeID);
            foreach (CSDServiceChargeCustomer oCSDServiceChargeCustomer in _oCSDServiceChargeCustomers)
            {
                if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Service_Charge)
                {
                    txtServiceTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
                else if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Inspection_Charge)
                {
                    txtInspectionTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
                else if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Installation_Charge)
                {
                    txtInstallationTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
            }
            
        }
        private void LoadExistictCharge()
        {
            txtMaterialTotalCharge.Text = _oCSDJobBill.MaterialCharge.ToString();
            txtMatChargePayable.Text = _oCSDJobBill.ActualMatCharge.ToString();
            txtServiceTotalCharge.Text = _oCSDJobBill.ServiceCharge.ToString();
            txtSCPayable.Text = _oCSDJobBill.ActualSerCharge.ToString();
            txtInspectionTotalCharge.Text = _oCSDJobBill.InspectionCharge.ToString();
            txtICPayable.Text = _oCSDJobBill.ActualInsCharge.ToString();
            txtInstallationTotalCharge.Text = _oCSDJobBill.InstallationCharge.ToString();
            txtInstallationChargePayable.Text = _oCSDJobBill.ActualInstallationCharge.ToString();
            txtOthrChrge.Text = _oCSDJobBill.OtherCharge.ToString();
            if (ctlCSDJob1.SelectedJob.ReceivingTransportationMode == (int)Dictionary.JobTransportation.Courier)
            {
                txtInCourierCost.Text = ctlCSDJob1.SelectedJob.ReceivingCost.ToString();
            }
            else if (ctlCSDJob1.SelectedJob.ReceivingTransportationMode == (int)Dictionary.JobTransportation.TELVehicle)
            {
                txtIncomingTELTransCost.Text = ctlCSDJob1.SelectedJob.ReceivingCost.ToString();
            }
            txtTotalBill.Text = _oCSDJobBill.TotalBill.ToString();
            SPDiscount.Text = _oCSDJobBill.SPDiscount.ToString();
            SCDiscount.Text = _oCSDJobBill.SCDiscount.ToString();
            txtNetPayable.Text = (Convert.ToDouble(_oCSDJobBill.TotalBill) - (Convert.ToDouble(_oCSDJobBill.SPDiscount) + Convert.ToDouble(_oCSDJobBill.SCDiscount))).ToString();
            //txtReceiveAmount.Text = _oCSDJobBill.ReceivedAmount.ToString();
        }
        private void LoadIssuedSpareParts()
        {
            _oSparePartsRs = new SparePartsRs();
            _oSparePartsRs.GetPartsIssueAgaintsJob(ctlCSDJob1.SelectedJob.JobID);
            dgvIssuedSpareParts.Rows.Clear();
            double _payable_mat_cost = 0;
            foreach (SparePartsR oSparePartsR in _oSparePartsRs)
            {
                if (oSparePartsR.SPTranSide != 1)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvIssuedSpareParts);
                    oRow.Cells[1].Value = oSparePartsR.Code;
                    oRow.Cells[2].Value = oSparePartsR.Name;
                    oRow.Cells[3].Value = oSparePartsR.Qty;
                    oRow.Cells[4].Value = oSparePartsR.TotalPrice;
                    oRow.Cells[5].Value = oSparePartsR.SPtranID.ToString();
                    dgvIssuedSpareParts.Rows.Add(oRow);
                    if (oSparePartsR.IsWarantyValid == "Yes")
                    {
                        oRow.Cells[0].Value = true;
                        oRow.Cells[0].ReadOnly = true;
                        _payable_mat_cost += Convert.ToDouble(oSparePartsR.TotalPrice);
                    }
                    else
                    {
                        oRow.Cells[0].Value = false;
                        oRow.Cells[0].ReadOnly = false;
                    }
                    _nTotalMaterialCost += Convert.ToDouble(oSparePartsR.TotalPrice);
                }

            }
            txtMatChargePayable.Text = (_nTotalMaterialCost-_payable_mat_cost).ToString();
            txtMaterialTotalCharge.Text = _nTotalMaterialCost.ToString();
        }

        private void dgvIssuedSpareParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ctlCSDJob1.SelectedJob != null)
            {
                double nFreeMatAmt = 0;
                double nFinalMatAmt = 0;

                if (e.ColumnIndex == 0)
                {
                    dgvIssuedSpareParts.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow oItemRow in dgvIssuedSpareParts.Rows)
                    {
                        bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                        if (isSelect)
                        {
                            nFreeMatAmt += Convert.ToDouble(oItemRow.Cells[4].Value);
                        }
                    }
                }
                nFinalMatAmt = (_nTotalMaterialCost - nFreeMatAmt);
                txtMatChargePayable.Text = nFinalMatAmt.ToString();
            }
        }

        private void rdoServiceCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoServiceCharge.Checked)
            {
                txtICPayable.Text = "0.00";
                txtInstallationChargePayable.Text = "0.00";
                if (ctlCSDJob1.txtDescription.Text != string.Empty)
                {
                    if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty || ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.ServiceWarranty)
                    {
                        txtSCPayable.Text = txtServiceTotalCharge.Text;
                    }
                }

            }
        }

        private void rdoInspectionCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInspectionCharge.Checked)
            {
                txtSCPayable.Text = "0.00";
                txtInstallationChargePayable.Text = "0.00";

                if (ctlCSDJob1.txtDescription.Text != string.Empty)
                {
                    if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        txtICPayable.Text = txtInspectionTotalCharge.Text;
                    }
                }
            }
        }

        private void rdoInstallationCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInstallationCharge.Checked)
            {
                txtICPayable.Text = "0.00";
                txtSCPayable.Text = "0.00";

                if (ctlCSDJob1.txtDescription.Text != string.Empty)
                {
                    if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        txtInstallationChargePayable.Text = txtInstallationTotalCharge.Text;
                    }
                }
            }
        }
        private void GetCharges()
        {
            double nMatChargePayable = Convert.ToDouble(txtMatChargePayable.Text);
            double nSCPayable = Convert.ToDouble(txtSCPayable.Text);
            double nICPayable = Convert.ToDouble(txtICPayable.Text);
            double nInstallationChargePayable = Convert.ToDouble(txtInstallationChargePayable.Text);
            double nOthrChrge = Convert.ToDouble(txtOthrChrge.Text);
            double nInCourierCost = Convert.ToDouble(txtInCourierCost.Text);
            double nIncomingTELTransCost = Convert.ToDouble(txtIncomingTELTransCost.Text);
            double nSCDiscount = Convert.ToDouble(SCDiscount.Text);
            double nSPDiscount = Convert.ToDouble(SPDiscount.Text);

            double nTotalBill = nMatChargePayable + nSCPayable + nICPayable + nInstallationChargePayable + nOthrChrge + nInCourierCost + nIncomingTELTransCost;
            txtTotalBill.Text = nTotalBill.ToString();
            txtNetPayable.Text = (nTotalBill - (nSCDiscount + nSPDiscount)).ToString();
        }
       

        private void txtSCPayable_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtICPayable_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtInstallationChargePayable_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtOthrChrge_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtInCourierCost_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtIncomingTELTransCost_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtTotalBill_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void SCDiscount_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void SPDiscount_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void txtNetPayable_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void btnCommunication_Click(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select a Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmCommunication oForm = new frmCommunication();
            oForm.ShowDialog(ctlCSDJob1.SelectedJob.JobID, _nProactiveCallID);
        }

        private void btnJobHistroy_Click(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select a Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmCSDJobHistory oForm = new frmCSDJobHistory();
            oForm.ShowDialog(_oCSDJob);
        }

        private void btnPendingParts_Click(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select A Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PrintRepairingEstimte(1);
        }

        private void btnEstimate_Click(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Select A Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PrintRepairingEstimte(2);
        }
        private void PrintRepairingEstimte(int nReportType)
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            rptJobRepairingEstimate doc = new rptJobRepairingEstimate();
            CSDJob oCSDJob = ctlCSDJob1.SelectedJob;
            _oCSDServiceChargeCustomer = new CSDServiceChargeCustomer();
            _oCSDServiceChargeCustomer.ProductID = oCSDJob.ProductID;
            _oCSDServiceChargeCustomer.ChargeType = (int)Dictionary.CSDServiceChargeType.Service_Charge;
            _oCSDServiceChargeCustomer.GetCharge();

            double nTotalMaterialCost = 0;
            if (nReportType == 2) //2=EstimatedSpareParts 
            {
                _oCSDEstimatedSparePartses = new CSDEstimatedSparePartses();
                _oCSDEstimatedSparePartses.GetEstimtedPartsAgaintsJob(oCSDJob.JobID);

                List<CSDEstimatedSpareParts> oCSDEstimatedSpareParts = new List<CSDEstimatedSpareParts>();

                foreach (CSDEstimatedSpareParts aCSDEstimatedSpareParts in _oCSDEstimatedSparePartses)
                {
                    oCSDEstimatedSpareParts.Add(aCSDEstimatedSpareParts);
                    nTotalMaterialCost += Convert.ToDouble(aCSDEstimatedSpareParts.TotalPrice);
                }

                for (int i = oCSDEstimatedSpareParts.Count; i < 9; i++)
                {
                    CSDEstimatedSpareParts aCSDEstimatedSpareParts = new CSDEstimatedSpareParts();
                    oCSDEstimatedSpareParts.Add(aCSDEstimatedSpareParts);
                }
                doc.SetDataSource(oCSDEstimatedSpareParts);
                doc.SetParameterValue("ReportName", "Repairing Estimate");
            }
            else if (nReportType == 1) //1=PendingSparePartses
            {
                _oCSDPendingSparePartses = new CSDPendingSparePartss();
                _oCSDPendingSparePartses.GetPendingPartsAgaintsJob(oCSDJob.JobID);

                List<CSDPendingSpareParts> oCSDPendingSparePartses = new List<CSDPendingSpareParts>();

                foreach (CSDPendingSpareParts aCSDPendingSpareParts in _oCSDPendingSparePartses)
                {
                    oCSDPendingSparePartses.Add(aCSDPendingSpareParts);
                    nTotalMaterialCost += Convert.ToDouble(aCSDPendingSpareParts.TotalPrice);
                }

                for (int i = oCSDPendingSparePartses.Count; i < 9; i++)
                {
                    CSDPendingSpareParts aCSDPendingSpareParts = new CSDPendingSpareParts();
                    oCSDPendingSparePartses.Add(aCSDPendingSpareParts);
                }
                doc.SetDataSource(oCSDPendingSparePartses);
                doc.SetParameterValue("ReportName", "Pending Parts");
            }



            doc.SetParameterValue("JobNo", oCSDJob.JobNo);
            doc.SetParameterValue("JobType", Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));

            doc.SetParameterValue("JobStatus", Enum.GetName(typeof(Dictionary.JobStatus), oCSDJob.Status));
            doc.SetParameterValue("CreationDate", oCSDJob.CreateDate);
            doc.SetParameterValue("TransportIn", Enum.GetName(typeof(Dictionary.JobTransportation), oCSDJob.ReceivingTransportationMode));
            if (oCSDJob.DeliveryTransportationMode != 0)
            {
                doc.SetParameterValue("TransportOut", Enum.GetName(typeof(Dictionary.JobTransportation), oCSDJob.DeliveryTransportationMode));
            }
            else
            {
                doc.SetParameterValue("TransportOut", string.Empty);
            }
            doc.SetParameterValue("ReferenceJob", oCSDJob.ReferenceJobNo);
            doc.SetParameterValue("Remarks", oCSDJob.Remarks);
            doc.SetParameterValue("ExpFeedbackDate", oCSDJob.LastFeedBackDate);
            if (oCSDJob.HaveBackupset == (int)Dictionary.YesOrNoStatus.YES)
            {
                doc.SetParameterValue("BackupSet", "Yes");
            }
            else
            {
                doc.SetParameterValue("BackupSet", "No");
            }

            doc.SetParameterValue("CustomerName", oCSDJob.CustomerName);
            doc.SetParameterValue("CustomerAddress", oCSDJob.CustomerAddress);
            doc.SetParameterValue("CustomerEmail", oCSDJob.Email);
            doc.SetParameterValue("CustomerPhoneNo", oCSDJob.TelePhone);
            doc.SetParameterValue("CustomerMobileNo", oCSDJob.MobileNo);
            doc.SetParameterValue("CustomerNationalID", oCSDJob.NationalID);
            doc.SetParameterValue("CustomerRefChannel", string.Empty);
            doc.SetParameterValue("CustomerID", string.Empty);
            doc.SetParameterValue("ProductName", oCSDJob.ProductName);
            doc.SetParameterValue("ProductSerialNo", oCSDJob.ProductSerialNo);
            doc.SetParameterValue("ProductBrand", oCSDJob.BrandName);

            CSDProductFault oCsdProductFault = new CSDProductFault();

            if (oCSDJob.PrimaryFaultID > 0)
            {
                oCsdProductFault.FaultID = oCSDJob.PrimaryFaultID;
                oCsdProductFault.Refresh();
                doc.SetParameterValue("PrimaryFault", oCsdProductFault.FaultDescription);
            }
            else
            {
                doc.SetParameterValue("PrimaryFault", string.Empty);
            }

            doc.SetParameterValue("ProductModelNo", oCSDJob.ProductModel);
            doc.SetParameterValue("InvoiceNo", oCSDJob.InvoiceNo);
            doc.SetParameterValue("PrintUser", Utility.Username);
            doc.SetParameterValue("ReceivingCost", oCSDJob.ReceivingCost);
            doc.SetParameterValue("TotalMaterialCost", nTotalMaterialCost);
            doc.SetParameterValue("ServiceCharge", _oCSDServiceChargeCustomer.Amount);
            doc.SetParameterValue("GrandTotal", _oCSDServiceChargeCustomer.Amount + nTotalMaterialCost + oCSDJob.ReceivingCost);
            try
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            catch
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "House:22, Road:4, Block:F, Banani, Dhaka-1213");
            }
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }

        private void btnFeedbackDate_Click(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                frmFeedbackDateChange ofrom = new frmFeedbackDateChange();
                ofrom.ShowDialog(ctlCSDJob1.txtCode.Text);
            }
            else
            {
                MessageBox.Show("Please select a Job", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReplaceHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction!!");
        }

        private void frmJobDetail_Load(object sender, EventArgs e)
        {
            //rdoServiceCharge.Checked = true;
        }
        private void ResetTextBox()
        {
            rdoServiceCharge.Checked = false;
            rdoInstallationCharge.Checked = false;
            rdoInspectionCharge.Checked = false;

            dgvIssuedSpareParts.Rows.Clear();
            txtBarcodeSl.Text = String.Empty;
            txtServiceType.Text = String.Empty;
            txtJobType.Text = string.Empty;

            txtCreateDate.Text = string.Empty;
            txtPurchaseDate.Text = string.Empty;
            txtJobStatus.Text = string.Empty;
            txtSubStatus.Text = string.Empty;
            txtVisitingDate.Text = string.Empty;

            txtVisitingTimeFrom.Text = string.Empty;
            txtVisitingTimeTo.Text = string.Empty;
            txtStatusReason.Text = string.Empty;
            txtFeedbackDate.Text = string.Empty;
            txtThirdPartyName.Text = string.Empty;
                        
            txtThirdPartyMobile.Text = string.Empty;
            txtAssignTo.Text = string.Empty;
            txtTechnicianMobile.Text = string.Empty;
            txtSupervisorName.Text = string.Empty;
            txtSUpervisorMobile.Text = string.Empty;
            txtProductFault.Text = string.Empty;
            txtCreatedBy.Text = string.Empty;
            txtProductLcation.Text = string.Empty;
            txtProductPhysicalLocation.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtInvoiceNo.Text = string.Empty;

            txtJobSource.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtThana.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            //txtHaveBackup = string.Empty;


            txtServiceTotalCharge.Text = "0.00";
            txtSCPayable.Text = "0.00";
            txtInspectionTotalCharge.Text = "0.00";
            txtICPayable.Text = "0.00";

            txtInstallationTotalCharge.Text = "0.00";
            txtInstallationChargePayable.Text = "0.00";
            txtOthrChrge.Text = "0.00";

            txtInCourierCost.Text = "0.00";
            txtIncomingTELTransCost.Text = "0.00";
            SPDiscount.Text = "0.00";
            txtTotalBill.Text = "0.00";
            SCDiscount.Text = "0.00";
            txtNetPayable.Text = "0.00";
            txtMaterialTotalCharge.Text = "0.00";
            txtMatChargePayable.Text = "0.00";
            _nTotalMaterialCost = 0;
            
        }
        private void btnLocation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtMatChargePayable_TextChanged(object sender, EventArgs e)
        {
            GetCharges();
        }

       

       
    }
}