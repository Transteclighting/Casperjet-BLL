using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Win.CSD.Reception;
using System.Text.RegularExpressions;

namespace CJ.Win.CSD.Reception
{
    public partial class frmJob : Form
    {
        ProductFaults _oProductFaults;
        ProductFaults _oProductActualFaults;
        ProductAccessories _oProductAccessories;
        CourierServices _oCourierServices;
        CSDJob _oCSDJob;
        JobHistory _oJobHistory;
        JobFeedbackDate _oJobFeedbackDate;
        SMSMaker _oSMSMaker;
        Customer _oCustomer;
        InterServiceR _oInterServiceR;
        GeoLocations _oGeoLocations;
        GeoLocations _oGeoLocationsThanas;
        CSDServiceChargeProduct _oCSDServiceChargeProduct;
        CSDServiceCharge _oCSDServiceCharge;
        CSDProductCheckLists _oCSDProductCheckLists;
        CSDJobCheckLists _oCSDJobCheckLists;
        CSDAssignTechHistory _oCSDAssignTechHistory;
        CSDCompanys _oCSDCompanys;
        Departments _oDepartments;
        bool _bIsConvert = false;
        int _nCallFrom = 0;

 
        public bool _bIsAnyActivityDone = false;

        int _nUIControl = 0;

        public frmJob(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJob_Load(object sender, EventArgs e)
        {
            lblAssignTechID.Text = string.Empty;
            lblAssignTechType.Text = string.Empty;
            if (this.Tag == null || this.Tag == " ")
            {
                SrouceEnable();
                //GetInfoEnable();                
                LoadCombo();
            }

            if (_nUIControl == (int)Dictionary.ServiceType.HomeCall || _nUIControl == (int)Dictionary.ServiceType.Installation)
            {
                cmbProductAccessories.Enabled = false;
            }
            if (_nCallFrom == 1)
            {
                //_nCallFrom = 1 =call From call center
                rdoCentralService.Enabled = false;
                rdoOuterService.Checked = true;
            }

        }

        private void rdoCustomerHimself_CheckedChanged(object sender, EventArgs e)
        {
            ctlInterService1.Visible = false;
            ctlsrcCustomer.Visible = true;
            ctlsrcCustomer.Enabled = false;
            txtownset.Enabled = false;
            rdoUnsoldProduct.Checked = false;
            rdoCustomersProduct.Checked = false;
            rdoUnsoldProduct.Enabled = false;
            rdoCustomersProduct.Enabled = false;
            lblSourceCode.Enabled = false;
            lblProductOwner.Enabled = false;
            cmbDepartment.Visible = false;

        }

        private void rdosrcTranscomDigital_CheckedChanged(object sender, EventArgs e)
        {
            ctlInterService1.Visible = false;
            ctlsrcCustomer.Visible = true;
            ctlsrcCustomer.Enabled = true;
            txtownset.Enabled = true;
            //rdoUnsoldProduct.Checked = false;
            rdoUnsoldProduct.Enabled = true;
            rdoCustomersProduct.Enabled = true;
            lblSourceCode.Enabled = true;
            lblProductOwner.Enabled = true;
            cmbDepartment.Visible = false;

            if (this.Tag == null)
            {
                rdoCustomersProduct.Checked = true;
            }
        }

        private void rdosrcDealer_CheckedChanged(object sender, EventArgs e)
        {
            ctlInterService1.Visible = false;
            ctlsrcCustomer.Visible = true;
            ctlsrcCustomer.Enabled = true;
            txtownset.Enabled = true;
            //rdoUnsoldProduct.Checked = false;
            rdoUnsoldProduct.Enabled = true;
            rdoCustomersProduct.Enabled = true;
            lblSourceCode.Enabled = true;
            lblProductOwner.Enabled = true;
            cmbDepartment.Visible = false;

            if (this.Tag == null)
            {
                rdoCustomersProduct.Checked = true;
            }
        }

        private void rdosrcCorporate_CheckedChanged(object sender, EventArgs e)
        {
            ctlInterService1.Visible = false;
            ctlsrcCustomer.Visible = true;
            ctlsrcCustomer.Enabled = true;
            txtownset.Enabled = true;
            //rdoUnsoldProduct.Checked = false;
            rdoUnsoldProduct.Enabled = true;
            rdoCustomersProduct.Enabled = true;
            lblSourceCode.Enabled = true;
            lblProductOwner.Enabled = true;
            cmbDepartment.Visible = false;

            if (this.Tag == null)
            {
                rdoCustomersProduct.Checked = true;
            }
        }

        private void rdoThirdParty_CheckedChanged(object sender, EventArgs e)
        {
            ctlsrcCustomer.Visible = false;
            ctlInterService1.Visible = true;
            //txtownset.Enabled = true;
            rdoUnsoldProduct.Enabled = false;
            rdoCustomersProduct.Enabled = true;
            rdoCustomersProduct.Checked = true;
            lblSourceCode.Enabled = true;
            lblProductOwner.Enabled = true;
            cmbDepartment.Visible = false;
            if (this.Tag == null)
            {
                rdoCustomersProduct.Checked = true;
            }
        }

        private void SrouceEnable()
        {

            rdoGetInvoice.Checked = true;
            lblPath.Text = "Invoice No";
            lblPath.Enabled = true;
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
            btnGetData.Enabled = true;

            rdoTranscomDigital.Checked = true;
            rdoCustomerHimself.Checked = true;
            lblSourceCode.Enabled = false;
            lblProductOwner.Enabled = false;
            ctlsrcCustomer.Enabled = false;
            txtownset.Enabled = false;
            rdoUnsoldProduct.Checked = false;
            rdoCustomersProduct.Checked = false;
            rdoUnsoldProduct.Enabled = false;
            rdoCustomersProduct.Enabled = false;
            gbTransportation.Enabled = false;

            ctlInterService1.Visible = false;

            lblFeedbackDate.Visible = true;
            dtFeedbackDate.Visible = true;

            txtAssignTech.Visible = false;
            btnAssign.Visible = false;
            rdoCentralService.Checked = true;

            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                Transportation();
                this.Text = "Walk In Job Creation";
                gbTransportation.Enabled = true;


                chkDelivered_SvrProvided.Visible = false;
                gbVisitingDate.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.HomeCall)
            {
                this.Text = "Home Call Job Creation";


                gbTransportation.Enabled = false;
                btnMove.Visible = false;
                rdoTransportOwn.Enabled = false;
                rdoTransportTEL.Enabled = false;
                rdoTransportCourier.Enabled = false;

                txtCost.Enabled = false;
                txtInstrument.Enabled = false;
                cmbCourier.Enabled = false;
                rdoCentralService.Visible = false;
                rdoOuterService.Visible = false;
                //btnAssign.Enabled = false;

                chkDelivered_SvrProvided.Visible = false;
                gbVisitingDate.Visible = true;
                dtVisitingDate.Visible = true;
                lblVisitingDate.Visible = true;
                dtVisitingTimeFrom.Visible = true;
                dtVisitingTimeTo.Visible = true;
                lblVisitingTime.Visible = true;

                lblFeedbackDate.Visible = false;
                dtFeedbackDate.Visible = false;
                gbProductCheckList.Visible = true;

                gbProductPhysicalLocation.Enabled = true;
                rdoOuterService.Checked = true;
                gbProductPhysicalLocation.Text = "Assign to Technician";
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.Installation)
            {
                this.Text = "Installation Job Creation";

                gbTransportation.Enabled = false;
                btnMove.Visible = false;
                rdoTransportOwn.Enabled = false;
                rdoTransportTEL.Enabled = false;
                rdoTransportCourier.Enabled = false;

                txtCost.Enabled = false;
                txtInstrument.Enabled = false;
                cmbCourier.Enabled = false;
                rdoCentralService.Visible = false;
                rdoOuterService.Visible = false;
                //btnAssign.Enabled = false;

                chkDelivered_SvrProvided.Visible = false;
                gbVisitingDate.Visible = true;
                dtVisitingDate.Visible = true;
                lblVisitingDate.Visible = true;
                dtVisitingTimeFrom.Visible = true;
                dtVisitingTimeTo.Visible = true;
                lblVisitingTime.Visible = true;

                lblFeedbackDate.Visible = false;
                dtFeedbackDate.Visible = false;
                gbProductCheckList.Visible = true;

                gbProductPhysicalLocation.Enabled = true;
                rdoOuterService.Checked = true;
                gbProductPhysicalLocation.Text = "Assign to Technician";
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            bool IsCheck = false;
            if (rdoGetOldJob.Checked == true)
            {
                frmGetJobInfo oform = new frmGetJobInfo(txtPath.Text);
                oform.ShowDialog();
                txtPath.Text = oform._sJobNo;
                if (txtPath.Text.Trim() != "")
                {
                    btnGetData_Click(null, null);
                }
            }
            else if (rdoGetInvoice.Checked == true)
            {
                frmGetInvoiceInfo oform = new frmGetInvoiceInfo(txtPath.Text);
                oform.ShowDialog();
                if (oform.bIsExecuite)
                {
                    ctlProduct1.txtCode.Text = oform.sProductCode;
                    txtBarcodeSL.Text = oform.sProductSL;
                    txtInvoiceNo.Text = oform.sInvoiceNo;
                    dtInvoiceDate.Value = oform.dInvoiceDate;
                   
                    dtInvoiceDate.Checked = true;

                    if (oform.bIsCassiopeia == true)
                    {
                        _oCustomer = new Customer();
                        _oCustomer.CustomerCode = oform.sSalesPointCode;
                        _oCustomer.RefreshByCode();
                    }
                    else
                    {
                        _oCustomer = new Customer();
                        _oCustomer.CustomerID = oform.nSalesPoint;
                        _oCustomer.refresh();
                    }
                    if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Retail)
                    {
                        rdoTranscomDigital.Checked = true;
                    }
                    else if (_oCustomer.ChannelID == (int)Dictionary.Channel.EnA_Distribution)
                    {
                        rdoDealer.Checked = true;
                    }
                    else if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate)
                    {
                        rdoCorporate.Checked = true;
                    }
                    else
                    {
                        rdoOthers.Checked = true;
                    }


                    ctlCustomer1.txtCode.Text = _oCustomer.CustomerCode;
                    txtCustomerName.Text = oform.sCustomerName;
                    txtAddress.Text = oform.sAddress;
                    txtMobileNo.Text = oform.sContactNo;
                    txtTelePhone.Text = oform.sTelephone;
                    txtEmail.Text = oform.sEmail;
                    txtNationalID.Text = oform.sNationalID;

                    cmbCSDCompany.SelectedIndex = 1;
                    cmbCSDCompany.Enabled = false;
                    if (txtInvoiceNo.Text != "")
                    {
                        txtInvoiceNo.Enabled = false;
                        dtInvoiceDate.Enabled = false;
                    }
                    else
                    {
                        txtInvoiceNo.Enabled = true;
                        dtInvoiceDate.Enabled = true;
                    }
                }

            }
        }

        private void rdoGetInvoice_CheckedChanged(object sender, EventArgs e)
        {
            lblPath.Text = "Invoice No";
            lblPath.Enabled = true;
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
            btnGetData.Enabled = true;
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                gbProductCheckList.Text = "Product Check List";
                dgvCheckList.Visible = true;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.HomeCall)
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.Installation)
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
        }

        private void rdoGetOldJob_CheckedChanged(object sender, EventArgs e)
        {
            lblPath.Text = "Old Job";
            lblPath.Enabled = true;
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
            btnGetData.Enabled = true;
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                gbProductCheckList.Text = "Product Check List";
                dgvCheckList.Visible = true;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.HomeCall)
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.Installation)
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
        }

        private void rdoGetCassandraJob_CheckedChanged(object sender, EventArgs e)
        {
            lblPath.Text = "Cassandra Job";
            lblPath.Enabled = true;
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
            btnGetData.Enabled = true;
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                gbProductCheckList.Text = "Product Check List";
                dgvCheckList.Visible = true;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.HomeCall)
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.Installation)
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
            else
            {
                gbProductCheckList.Text = "Other Info";
                dgvCheckList.Visible = false;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
        }

        private void rdoGetQRScan_CheckedChanged(object sender, EventArgs e)
        {
            lblPath.Enabled = false;
            txtPath.Enabled = false;
            btnBrowse.Enabled = false;
            btnGetData.Enabled = false;
            gbProductCheckList.Text = "Other Info";
            dgvCheckList.Visible = false;
            txtQRCodeScan.Visible = true;
            btnMove.Visible = true;
            gbVisitingDate.Visible = false;
        }

        private void rdoQRSoft_CheckedChanged(object sender, EventArgs e)
        {
            lblPath.Text = "Path";
            lblPath.Enabled = true;
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
            btnGetData.Enabled = true;
            gbProductCheckList.Text = "QR Code Info";
            dgvCheckList.Visible = false;
            txtQRCodeScan.Visible = true;
            btnMove.Visible = true;
            gbVisitingDate.Visible = false;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            rdoGetInvoice.Checked = true;
            lblPath.Text = "Invoice No";
            lblPath.Enabled = true;
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                gbProductCheckList.Text = "Product Check List";
                dgvCheckList.Visible = true;
                txtQRCodeScan.Visible = false;
                btnMove.Visible = false;
            }
        }

        private void rdoTransportOwn_CheckedChanged(object sender, EventArgs e)
        {
            lblCost.Enabled = false;
            txtCost.Enabled = false;
            txtCost.Text = "0.00";
            txtInstrument.Text = "";
            txtInstrument.Enabled = false;
            lblInsturment.Enabled = false;
            lblCourier.Enabled = false;
            cmbCourier.Enabled = false;
        }

        private void rdoTransportTEL_CheckedChanged(object sender, EventArgs e)
        {
            lblCost.Enabled = true;
            txtCost.Enabled = true;
            txtCost.Text = "0.00";
            txtInstrument.Text = "";
            txtInstrument.Enabled = true;
            lblInsturment.Enabled = true;
            lblCourier.Enabled = false;
            cmbCourier.Enabled = false;
        }

        private void rdoTransportCourier_CheckedChanged(object sender, EventArgs e)
        {
            lblCost.Enabled = true;
            txtCost.Enabled = true;
            txtCost.Text = "0.00";
            txtInstrument.Text = "";
            txtInstrument.Enabled = true;
            lblInsturment.Enabled = true;
            lblCourier.Enabled = true;
            cmbCourier.Enabled = true;
        }

        private void Transportation()
        {
            rdoTransportOwn.Checked = true;
            lblCost.Enabled = false;
            txtCost.Enabled = false;
            txtCost.Text = "0.00";
            txtInstrument.Text = "";
            txtInstrument.Enabled = false;
            lblInsturment.Enabled = false;
            lblCourier.Enabled = false;
            cmbCourier.Enabled = false;
        }

        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            //JobType
            cmbJobType.Items.Clear();
            cmbJobType.Items.Add("-- Select --");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDJobType)))
            {
                cmbJobType.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), GetEnum));
            }
            cmbJobType.SelectedIndex = 0;

            //JobPriority
            cmbJobPriority.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.JobPriority)))
            {
                cmbJobPriority.Items.Add(Enum.GetName(typeof(Dictionary.JobPriority), GetEnum));
            }
            cmbJobPriority.SelectedIndex = 0;

            //Combo Product Fault Type
            _oProductFaults = new ProductFaults();
            _oProductFaults.GetData(-1);
            cmbProductFault.Items.Clear();
            cmbProductFault.Items.Add("-- Select --");
            foreach (ProductFault oProductFault in _oProductFaults)
            {
                cmbProductFault.Items.Add(oProductFault.FaultDescription);
            }
            cmbProductFault.SelectedIndex = 0;

            //Combo Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("-- Select --");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            //Combo Company
            _oCSDCompanys = new CSDCompanys();
            _oCSDCompanys.Refresh();
            cmbCSDCompany.Items.Clear();
            cmbCSDCompany.Items.Add("-- Select --");
            foreach (CSDCompany oCSDCompany in _oCSDCompanys)
            {
                cmbCSDCompany.Items.Add(oCSDCompany.Name);
            }
            cmbCSDCompany.SelectedIndex = 0;


            // Combo product Accessories

            _oProductAccessories = new ProductAccessories();
            _oProductAccessories.Refresh();
            cmbProductAccessories.Items.Clear();
            cmbProductAccessories.Items.Add("-- Not Applicable --");
            foreach (ProductAccessory oProductAccessory in _oProductAccessories)
            {
                cmbProductAccessories.Items.Add(oProductAccessory.Name);
            }
            cmbProductAccessories.SelectedIndex = 0;

            // Combo product Courier Service
            _oCourierServices = new CourierServices();
            _oCourierServices.Refresh();
            cmbCourier.Items.Clear();
            cmbCourier.Items.Add("-- Select --");
            foreach (CourierService oCourierService in _oCourierServices)
            {
                cmbCourier.Items.Add(oCourierService.Name);
            }
            cmbCourier.SelectedIndex = 0;

            //Combo District
            _oGeoLocations = new GeoLocations();
            _oGeoLocations.RefreshDistrict();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("--Select --");
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

            //Combo Thana
            cmbThana.Items.Add("--Select --");
            cmbThana.SelectedIndex = 0;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                _bIsAnyActivityDone = true;
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == " " || this.Tag == null)
            {
                _oCSDJob = new CSDJob();
                DBController.Instance.OpenNewConnection();
                _oCSDJob = GetData(_oCSDJob);
                int nMaxJobNo = 0;
                _oCSDJob.JobCreateLocation = Utility.JobLocation;

                DateTime _nYear = DateTime.Today;

                if (_oCSDJob.GetNextJobNo(Convert.ToInt32(_nYear.Year), _nUIControl))
                {

                }
                else
                {
                    _oCSDJob.InsertNextJobNo(_nUIControl, Convert.ToInt32(_nYear.Year));
                }

                try
                {
                    if (_oCSDJob.GetNextJobNo(Convert.ToInt32(_nYear.Year), _nUIControl))
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSMSMaker = new SMSMaker();
                        int nJobID = _oCSDJob.Add(_nUIControl);

                        if (dgvCheckList.Rows.Count > 0)
                        {
                            AddCSDJobCheckList(nJobID);
                        }

                        if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
                        {
                            AddJobHistory(_oCSDJob, (int)Dictionary.JobStatus.WalkinJobCreated);
                        }
                        else if (_nUIControl == (int)Dictionary.ServiceType.HomeCall)
                        {
                            AddJobHistory(_oCSDJob, (int)Dictionary.JobStatus.HomecallJobCreated);
                        }
                        else
                        {
                            AddJobHistory(_oCSDJob, (int)Dictionary.JobStatus.InstallationJobCreated);
                        }
                        if (lblAssignTechType.Text != string.Empty && lblAssignTechID.Text != string.Empty)
                        {
                            AddJobHistory(_oCSDJob, (int)Dictionary.JobStatus.AssignedToTechnician);
                        }
                        if (lblAssignTechID.Text != string.Empty && lblAssignTechID.Text != null)
                        {
                            AddAssignTechHistory(_oCSDJob);//???????????
                        }
                        AddCSDFeedbackDateHistory(_oCSDJob);


                        DBController.Instance.CommitTran();

                        if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
                        {
                            if (ctlProduct1.SelectedSerarchProduct.BrandID != 19)//Brand Samsung
                                _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_CreateJob_Customer_Source, nJobID);
                            if (rdoOuterService.Checked == true)
                            {
                                if (lblAssignTechType.Text != string.Empty && lblAssignTechID.Text != string.Empty)
                                {
                                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_Assign_Only_Outer_Service_Technician, nJobID);
                                    if (Convert.ToInt32(lblAssignTechType.Text) == (int)Dictionary.CSDTechnicianType.ThirdParty)
                                    {
                                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_Assign_Only_Outer_Service_TPManager, nJobID);
                                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_Assign_Only_Outer_Service_Supervisor, nJobID);
                                    }
                                    else
                                    {
                                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_Assign_Only_Outer_Service_Supervisor, nJobID);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (lblAssignTechType.Text != string.Empty && lblAssignTechID.Text != string.Empty)
                            {
                                _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Technician, nJobID);
                                _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Customer, nJobID);
                                if (rdoCustomerHimself.Checked != true)
                                {
                                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Source, nJobID);
                                }
                                if (Convert.ToInt32(lblAssignTechType.Text) == (int)Dictionary.CSDTechnicianType.ThirdParty)
                                {
                                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_TPManager, nJobID);
                                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_TPTech_Job, nJobID);
                                }
                                else
                                {
                                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_OwnTech_Job, nJobID);
                                }
                            }
                            else
                            {
                                _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_CreateJob_Customer, nJobID);
                            }
                        }
                        frmJobNoSave oFrom = new frmJobNoSave();
                        oFrom.ShowDialog(_oCSDJob.JobNo);
                       // MessageBox.Show("Save Successfully. Job# " + _oCSDJob.JobNo + "", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CSDJob oCSDJob = (CSDJob)this.Tag;

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();

                    CSDJobCheckList oCSDJobCheckList = new CSDJobCheckList();
                    oCSDJobCheckList.JobID = oCSDJob.JobID;
                    oCSDJobCheckList.Delete();

                    if (dgvCheckList.Rows.Count > 0)
                    {
                        AddCSDJobCheckList(oCSDJob.JobID);
                    }

                    oCSDJob = GetData(oCSDJob);
                    oCSDJob.Edit();

                    if (_bIsConvert)
                    {
                        oCSDJob.Status = (int)Dictionary.JobStatus.ConvertedFromHomeCall;
                        oCSDJob.UpdateUserID = Utility.UserId;
                        oCSDJob.UpdateDate = DateTime.Now;
                        oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_FrontDesk;
                        oCSDJob.ProductPhysicalLocation = (int)Dictionary.ProductPhysicalLocation.CentralService;
                        oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.None;
                        oCSDJob.ServiceType = (int)Dictionary.ServiceType.Walkin;
                        oCSDJob.ConvertHomeCallJob();
                        AddJobHistory(oCSDJob, (int)Dictionary.JobStatus.ConvertedFromHomeCall);
                    }

                    //status update
                    _oJobFeedbackDate = new JobFeedbackDate();
                    if (_oJobFeedbackDate.CheckFeedbackDate(oCSDJob.JobID, oCSDJob.LastFeedBackDate))
                    {

                    }
                    else
                    {
                        _oJobFeedbackDate.JobID = oCSDJob.JobID;
                        _oJobFeedbackDate.StatusID = oCSDJob.Status;
                        _oJobFeedbackDate.FeedbackDate = oCSDJob.LastFeedBackDate;
                        _oJobFeedbackDate.CreateUserID = Utility.UserId;
                        _oJobFeedbackDate.CreateDate = DateTime.Now;
                        _oJobFeedbackDate.Add();

                    }
                    DBController.Instance.CommitTran();
                    _oSMSMaker = new SMSMaker();
                    if (!_bIsConvert)
                    {
                        _oSMSMaker.EDDExtention(oCSDJob.JobID, oCSDJob.JobNo, oCSDJob.MobileNo, oCSDJob.LastFeedBackDate);
                    }
                    else
                    {
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_CreateJob_Customer_Source, oCSDJob.JobID);

                    }
                    frmJobNoSave oFrom = new frmJobNoSave();
                    oFrom.ShowDialog(oCSDJob.JobNo);
                    //MessageBox.Show("Update Successfully. Job# " + oCSDJob.JobNo + "", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void AddAssignTechHistory(CSDJob oCSDJob)
        {
            _oCSDAssignTechHistory = new CSDAssignTechHistory();
            _oCSDAssignTechHistory.JobID = oCSDJob.JobID;
            _oCSDAssignTechHistory.Status = oCSDJob.Status;
            _oCSDAssignTechHistory.AssignTo = Convert.ToInt32(lblAssignTechID.Text);
            _oCSDAssignTechHistory.ServiceType = _nUIControl;
            _oCSDAssignTechHistory.CreateUserID = Utility.UserId;
            _oCSDAssignTechHistory.CreateDate = DateTime.Now;
            _oCSDAssignTechHistory.Add();
        }

        private void AddCSDFeedbackDateHistory(CSDJob oCSDJob)
        {
            _oJobFeedbackDate = new JobFeedbackDate();
            _oJobFeedbackDate.JobID = oCSDJob.JobID;
            _oJobFeedbackDate.StatusID = _oJobHistory.StatusID;
            if (lblAssignTechID.Text != string.Empty)
            {
                _oJobFeedbackDate.TechnicianID = Convert.ToInt32(lblAssignTechID.Text);
            }
            _oJobFeedbackDate.FeedbackDate = oCSDJob.LastFeedBackDate;
            _oJobFeedbackDate.VisitingTimeFrom = oCSDJob.VisitingTimeFrom;
            _oJobFeedbackDate.VisitingTimeTo = oCSDJob.VisitingTimeTo;
            _oJobFeedbackDate.CreateUserID = Utility.UserId;
            _oJobFeedbackDate.CreateDate = DateTime.Now;
            _oJobFeedbackDate.Add();
        }

        private void AddCSDJobCheckList(int nJobID)
        {
            foreach (DataGridViewRow oItemRow in dgvCheckList.Rows)
            {
                if (oItemRow.Index < dgvCheckList.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    if (isSelect)
                    {
                        CSDJobCheckList oCSDJobCheckList = new CSDJobCheckList();
                        oCSDJobCheckList.JobID = nJobID;
                        oCSDJobCheckList.CreateDate = DateTime.Now;
                        oCSDJobCheckList.CreateUserID = Utility.UserId;
                        oCSDJobCheckList.CreateStage = 1;
                        oCSDJobCheckList.Description = Convert.ToString(oItemRow.Cells[2].Value.ToString());
                        oCSDJobCheckList.ProductCheckListID = int.Parse(oItemRow.Cells[3].Value.ToString());
                        oCSDJobCheckList.Add();
                    }
                }
            }

        }

        private void AddJobHistory(CSDJob _oCSDJob, int nJobStatus)
        {
            _oJobHistory = new JobHistory();
            _oJobHistory.JobID = _oCSDJob.JobID;
            _oJobHistory.CreateUserID = _oCSDJob.CreateUserID;
            _oJobHistory.CreateDate = _oCSDJob.CreateDate;
            _oJobHistory.StatusID = nJobStatus;
            _oJobHistory.Remarks = txtRemarks.Text.Trim();
            _oJobHistory.ServiceType = _oCSDJob.ServiceType;
            _oJobHistory.Add(null);
        }

        private CSDJob GetData(CSDJob _oCSDJob)
        {
            _oCSDJob.ProductSerialNo = txtBarcodeSL.Text;
            _oCSDJob.InvoiceNo = txtInvoiceNo.Text;
            if (dtInvoiceDate.Checked == true)
                _oCSDJob.InvoiceDate = Convert.ToDateTime(dtInvoiceDate.Value.Date);
            else _oCSDJob.InvoiceDate = null;

            if (rdoTranscomDigital.Checked == true)
            {
                _oCSDJob.SalesChannelID = (int)Dictionary.Channel.TD_Retail;
            }
            else if (rdoDealer.Checked == true)
            {
                _oCSDJob.SalesChannelID = (int)Dictionary.Channel.EnA_Distribution;
            }
            else if (rdoCorporate.Checked == true)
            {
                _oCSDJob.SalesChannelID = (int)Dictionary.Channel.TD_Corporate;
            }
            else _oCSDJob.SalesChannelID = (int)Dictionary.Channel.Others;
            {
                if (ctlCustomer1.txtDescription.Text != "")
                {
                    _oCSDJob.SalesPointID = ctlCustomer1.SelectedCustomer.CustomerID;
                }
                else
                {
                    _oCSDJob.SalesPointID = -1;
                }
            }
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                _oCSDJob.ServiceType = (int)Dictionary.ServiceType.Walkin;
                _oCSDJob.Status = (int)Dictionary.JobStatus.WalkinJobCreated;
                _oCSDJob.VisitingDate = null;
                _oCSDJob.VisitingTimeFrom = null;
                _oCSDJob.VisitingTimeTo = null;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.HomeCall)
            {
                _oCSDJob.ServiceType = (int)Dictionary.ServiceType.HomeCall;
                _oCSDJob.Status = (int)Dictionary.JobStatus.HomecallJobCreated;
                _oCSDJob.VisitingDate = dtVisitingDate.Value.Date;
                _oCSDJob.VisitingTimeFrom = dtVisitingTimeFrom.Value.TimeOfDay;
                _oCSDJob.VisitingTimeTo = dtVisitingTimeTo.Value.TimeOfDay;
            }
            else if (_nUIControl == (int)Dictionary.ServiceType.Installation)
            {
                _oCSDJob.ServiceType = (int)Dictionary.ServiceType.Installation;
                _oCSDJob.Status = (int)Dictionary.JobStatus.InstallationJobCreated;
                _oCSDJob.VisitingDate = dtVisitingDate.Value.Date;
                _oCSDJob.VisitingTimeFrom = dtVisitingTimeFrom.Value.TimeOfDay;
                _oCSDJob.VisitingTimeTo = dtVisitingTimeTo.Value.TimeOfDay;
            }


            _oCSDJob.JobType = cmbJobType.SelectedIndex;
            //_oCSDJob.WorkshopID=??
            _oCSDJob.ReferenceJobNo = txtReferenceJob.Text;
            _oCSDJob.Priority = cmbJobPriority.SelectedIndex + 1;
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                _oCSDJob.LastFeedBackDate = Convert.ToDateTime(dtFeedbackDate.Value.Date);
            }
            else
            {
                _oCSDJob.LastFeedBackDate = Convert.ToDateTime(dtVisitingDate.Value.Date);
            }
            if (chkDelivered_SvrProvided.Checked == true)
            {
                {
                    _oCSDJob.DeliveryDate = Convert.ToDateTime(dtVisitingDate.Value.Date);
                }
            }
            else
            {
                _oCSDJob.DeliveryDate = null;
            }
            _oCSDJob.Remarks = txtRemarks.Text;
            _oCSDJob.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            if (cmbProductAccessories.SelectedIndex == 0)
            {
                _oCSDJob.FullOrAccessories = (int)Dictionary.FullProductOrAccessory.FullProduct;
            }
            else
            {
                _oCSDJob.FullOrAccessories = (int)Dictionary.FullProductOrAccessory.Accessory;
            }
            if (cmbProductAccessories.SelectedIndex != 0)
            {
                _oCSDJob.AccessoryID = _oProductAccessories[cmbProductAccessories.SelectedIndex - 1].AccessoriesID;
            }
            else
            {
                _oCSDJob.AccessoryID = -1;
            }
            _oCSDJob.PrimaryFaultID = _oProductActualFaults[cmbActualFault.SelectedIndex - 1].FaultID;
            if (rdoUnsoldProduct.Checked == true)
            {
                _oCSDJob.OwnOrCustomerSet = (int)Dictionary.UnsoldOrCustomersProduct.Unsold_Product;
            }
            else
            {
                _oCSDJob.OwnOrCustomerSet = (int)Dictionary.UnsoldOrCustomersProduct.Customers_Product;
            }

            if (rdosrcTranscomDigital.Checked == true)
            {
                _oCSDJob.RefChannelID = (int)Dictionary.Channel.TD_Retail;
            }
            else if (rdosrcDealer.Checked == true)
            {
                _oCSDJob.RefChannelID = (int)Dictionary.Channel.EnA_Distribution;
            }
            else if (rdosrcCorporate.Checked == true)
            {
                _oCSDJob.RefChannelID = (int)Dictionary.Channel.TD_Corporate;
            }
            else if (rdoHeadOffice.Checked == true)
            {
                _oCSDJob.RefChannelID = (int)Dictionary.Channel.Head_Office;
            }
            else
            {
                _oCSDJob.RefChannelID = (int)Dictionary.Channel.Others;
            }

            if (_oCSDJob.RefChannelID != (int)Dictionary.Channel.Others && _oCSDJob.RefChannelID != (int)Dictionary.Channel.Head_Office)
            {
                _oCSDJob.RefSalesPointID = ctlsrcCustomer.SelectedCustomer.CustomerID;
            }
            else
            {
                _oCSDJob.RefSalesPointID = -1;
            }
            //if (_oCSDJob.RefChannelID != (int)Dictionary.Channel.Head_Office)
            //{
            //    _oCSDJob.RefSalesPointID = ctlsrcCustomer.SelectedCustomer.CustomerID;
            //}
            //else
            //{
            //    _oCSDJob.RefSalesPointID = -1;
            //}
            _oCSDJob.CustomerName = txtCustomerName.Text;
            _oCSDJob.CustomerAddress = txtAddress.Text;
            _oCSDJob.MobileNo = txtMobileNo.Text;
            _oCSDJob.TelePhone = txtTelePhone.Text;
            _oCSDJob.Email = txtEmail.Text;
            _oCSDJob.NationalID = txtNationalID.Text;

            _oCSDJob.StatusReason = "";
            _oCSDJob.CreateUserID = Utility.UserId;
            _oCSDJob.CreateDate = DateTime.Now;
            _oCSDJob.UpdateUserID = Utility.UserId;
            _oCSDJob.UpdateDate = DateTime.Now;

            if (lblAssignTechType.Text != string.Empty && lblAssignTechID.Text != string.Empty)
            {
                _oCSDJob.AssignTo = Convert.ToInt32(lblAssignTechID.Text);
                _oCSDJob.OwnOrOtherTechnician = Convert.ToInt32(lblAssignTechType.Text);
                _oCSDJob.Status = (int)Dictionary.JobStatus.AssignedToTechnician;
            }
            else
            {
                _oCSDJob.AssignTo = 0;
                _oCSDJob.OwnOrOtherTechnician = -1;
            }

            if (rdoTransportOwn.Checked == true)
            {
                _oCSDJob.ReceivingTransportationMode = (int)Dictionary.JobTransportation.CustomerOwn;
                _oCSDJob.ReceivingCost = 0;
                _oCSDJob.ReceivingInstrumentNo = "";
                _oCSDJob.ReceivingCourierID = -1;
            }
            else if (rdoTransportTEL.Checked == true)
            {
                _oCSDJob.ReceivingTransportationMode = (int)Dictionary.JobTransportation.TELVehicle;
                _oCSDJob.ReceivingCost = Convert.ToDouble(txtCost.Text);
                _oCSDJob.ReceivingInstrumentNo = txtInstrument.Text;
                _oCSDJob.ReceivingCourierID = -1;
            }
            else
            {
                _oCSDJob.ReceivingTransportationMode = (int)Dictionary.JobTransportation.Courier;
                _oCSDJob.ReceivingCost = Convert.ToDouble(txtCost.Text);
                _oCSDJob.ReceivingInstrumentNo = txtInstrument.Text;
                if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
                    _oCSDJob.ReceivingCourierID = _oCourierServices[cmbCourier.SelectedIndex - 1].CourierServiceID;
            }
            _oCSDJob.DeliveryTransportationMode = -1;
            _oCSDJob.DeliveryCost = 0;
            _oCSDJob.DeliveryInstrumentNo = "";
            _oCSDJob.DeliveryCourierID = -1;

            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                _oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_FrontDesk;
            }
            else
            {
                _oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.Customers_House;
            }

            _oCSDJob.SparePartsUsed = (int)Dictionary.YesOrNoStatus.NO;
            _oCSDJob.ActualFaultID = -1;
            {
                _oCSDJob.InterSerJobType = -1;
            }
            if (chkDelivered_SvrProvided.Checked == true)
            {
                _oCSDJob.IsDelivered = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                _oCSDJob.IsDelivered = (int)Dictionary.YesOrNoStatus.NO;
            }
            _oCSDJob.IsReplacement = (int)Dictionary.YesOrNoStatus.NO;

            _oCSDJob.AssignLeadMinute = _oCSDJob.GetAssignLeadTime(_oCSDJob.ServiceType);
            if (rdoCentralService.Checked)
            {
                _oCSDJob.ProductPhysicalLocation = (int)Dictionary.ProductPhysicalLocation.CentralService;
                if (this.Tag != " " || this.Tag == null)
                    _oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_FrontDesk;
            }
            else if (rdoOuterService.Checked)
            {
                if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
                {
                    _oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_Workshop;
                }
                _oCSDJob.ProductPhysicalLocation = (int)Dictionary.ProductPhysicalLocation.OuterService;
            }
            _oCSDJob.IsHappyCall = (int)Dictionary.IsHappyCall.No;
            _oCSDJob.HaveBackupset = (int)Dictionary.HaveBackupset.No;
            if (cmbThana.SelectedIndex != 0)
            {
                _oCSDJob.ThanaID = _oGeoLocationsThanas[cmbThana.SelectedIndex - 1].GeoLocationID;
            }
            _oCSDJob.OriginalProductSerialNo = txtProductOriginalSL.Text;
            _oCSDJob.GSPNJobNo = txtGSPNJob.Text;

            return _oCSDJob;

        }

        public void ShowDialog(CSDJob oCSDJob, bool bIsConvert)
        {
            lblCreatedBy.Visible = true;
            txtCreatedBy.Visible = true;
            lblJobNo.Visible = true;
            txtJobNo.Visible = true;
            txtJobNo.Text = oCSDJob.JobNo;
            txtCreatedBy.Text = oCSDJob.CreateUserName;

            _bIsConvert = bIsConvert;
            this.Tag = oCSDJob;
            _nUIControl = oCSDJob.ServiceType;
            gbGetInfo.Enabled = false;
            LoadCombo();
            chkDelivered_SvrProvided.Visible = false;
            if (oCSDJob.ProductPhysicalLocation == (int)Dictionary.ProductPhysicalLocation.CentralService)
            {
                rdoCentralService.Checked = true;
            }
            else if (oCSDJob.ProductPhysicalLocation == (int)Dictionary.ProductPhysicalLocation.OuterService)
            {
                rdoOuterService.Checked = true;
            }
            if (bIsConvert)
            {
                rdoCentralService.Checked = true;
            }
            if (oCSDJob.ServiceType == (int)Dictionary.ServiceType.Walkin)
            {
                this.Text = "Edit Job (Walk-in)";
                gbVisitingDate.Visible = false;
                chkDelivered_SvrProvided.Visible = false;
            }
            else if (oCSDJob.ServiceType == (int)Dictionary.ServiceType.HomeCall)
            {
                this.Text = "Edit Job (Home Call)";
                gbTransportation.Enabled = false;
                gbVisitingDate.Visible = true;
                chkDelivered_SvrProvided.Visible = false;
                lblFeedbackDate.Visible = false;
                dtFeedbackDate.Visible = false;

                txtQRCodeScan.Visible = false;
                dgvCheckList.Visible = false;
                btnMove.Visible = false;
                gbProductCheckList.Text = "Other Info";

                if (oCSDJob.VisitingDate != DBNull.Value)
                {
                    dtVisitingDate.Value = Convert.ToDateTime(oCSDJob.VisitingDate);
                }
                if (oCSDJob.VisitingTimeFrom != DBNull.Value)
                {
                    dtVisitingTimeFrom.Value = Convert.ToDateTime(oCSDJob.VisitingTimeFrom);
                }
                if (oCSDJob.VisitingTimeTo != DBNull.Value)
                {
                    dtVisitingTimeTo.Value = Convert.ToDateTime(oCSDJob.VisitingTimeTo);
                }
                //ctlInterService1.Enabled = false;
            }
            else if (oCSDJob.ServiceType == (int)Dictionary.ServiceType.Installation)
            {
                this.Text = "Edit Job (Installation)";
                gbTransportation.Enabled = false;
                gbVisitingDate.Visible = true;
                chkDelivered_SvrProvided.Visible = false;
                lblFeedbackDate.Visible = false;
                dtFeedbackDate.Visible = false;

                txtQRCodeScan.Visible = false;
                dgvCheckList.Visible = false;
                btnMove.Visible = false;
                gbProductCheckList.Text = "Other Info";

                if (oCSDJob.VisitingDate != DBNull.Value)
                {
                    dtVisitingDate.Value = Convert.ToDateTime(oCSDJob.VisitingDate);
                }
                if (oCSDJob.VisitingTimeFrom != DBNull.Value)
                {
                    dtVisitingTimeFrom.Value = Convert.ToDateTime(oCSDJob.VisitingTimeFrom);
                }
                if (oCSDJob.VisitingTimeTo != DBNull.Value)
                {
                    dtVisitingTimeTo.Value = Convert.ToDateTime(oCSDJob.VisitingTimeTo);
                }
                //ctlInterService1.Enabled = false;

            }
            else
            {
                this.Text = "Edit Job (Inter Service)";

                _oInterServiceR = new InterServiceR();
                _oInterServiceR.InterServiceID = oCSDJob.AssignTo;
                _oInterServiceR.Refresh();
                ctlInterService1.txtCode.Text = _oInterServiceR.Code;
                //if (oCSDJob.InterSerJobType == (int)Dictionary.ServiceType.Walkin)
                //{
                //    rdoWalkin.Checked = true;
                //}
                //else if (oCSDJob.InterSerJobType == (int)Dictionary.ServiceType.HomeCall)
                //{
                //    rdoHomeCall.Checked = true;
                //}
                //else
                //{
                //    rdoInstallation.Checked = true;
                //}
                gbTransportation.Enabled = false;
                txtQRCodeScan.Visible = false;
                dgvCheckList.Visible = false;
                btnMove.Visible = false;
                gbProductCheckList.Text = "Other Info";


                if (oCSDJob.IsDelivered == (int)Dictionary.YesOrNoStatus.YES)
                {
                    chkDelivered_SvrProvided.Visible = true;
                    chkDelivered_SvrProvided.Checked = true;
                }
                else
                {
                    chkDelivered_SvrProvided.Visible = true;
                }

                //if (rdoWalkin.Checked == true)
                //{
                //    gbVisitingDate.Visible = false;
                //    lblFeedbackDate.Visible = true;
                //    dtFeedbackDate.Visible = true;
                //}
                //else
                {
                    gbVisitingDate.Visible = true;
                    lblFeedbackDate.Visible = false;
                    dtFeedbackDate.Visible = false;
                }
            }
            rdoGetInvoice.Checked = true;
            ctlProduct1.txtCode.Text = oCSDJob.ProductCode;
            //Fault Setting
            ProductFault _PF = new ProductFault();
            int nFaultTypeID = _PF.GetFaultParentID(oCSDJob.PrimaryFaultID);
            int nFaultTypeIndexID = _oProductFaults.GetIndex(nFaultTypeID);
            cmbProductFault.SelectedIndex = nFaultTypeIndexID + 1;
            int nFaultIndexID = _oProductActualFaults.GetIndex(oCSDJob.PrimaryFaultID);
            cmbActualFault.SelectedIndex = nFaultIndexID + 1;

            GeoLocation _GL = new GeoLocation();
            int nDistID = _GL.GetParentID(oCSDJob.ThanaID);
            int nDistIndexID = _oGeoLocations.GetIndexByID(nDistID);
            cmbDistrict.SelectedIndex = nDistIndexID + 1;
            int nThanaIndexID = _oGeoLocationsThanas.GetIndexByID(oCSDJob.ThanaID);
            cmbThana.SelectedIndex = nThanaIndexID + 1;
            txtGSPNJob.Text = oCSDJob.GSPNJobNo;

            if (oCSDJob.AccessoryID != 0)
            {
                int nAccessoryID = _oProductAccessories.GetIndex(oCSDJob.AccessoryID);
                cmbProductAccessories.SelectedIndex = nAccessoryID + 1;
            }
            else
            {
                cmbProductAccessories.SelectedIndex = 0;
            }
            txtBarcodeSL.Text = oCSDJob.ProductSerialNo;
            txtProductOriginalSL.Text = oCSDJob.OriginalProductSerialNo;
            txtInvoiceNo.Text = oCSDJob.InvoiceNo;
            //if (oCSDJob.InvoiceDate != DBNull.Value)
            if (oCSDJob.InvoiceDate != null && oCSDJob.InvoiceDate != DBNull.Value)
            {
                dtInvoiceDate.Value = Convert.ToDateTime(oCSDJob.InvoiceDate);
                dtInvoiceDate.Checked = true;
            }
            else
            {
                dtInvoiceDate.Value = DateTime.Today;
                dtInvoiceDate.Checked = false;
            }
            _oCustomer = new Customer();
            _oCustomer.CustomerID = oCSDJob.SalesPointID;
            _oCustomer.refresh();
            if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Retail)
            {
                rdoTranscomDigital.Checked = true;
            }
            else if (_oCustomer.ChannelID == (int)Dictionary.Channel.EnA_Distribution)
            {
                rdoDealer.Checked = true;
            }
            else if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate)
            {
                rdoCorporate.Checked = true;
            }
            else
            {
                rdoOthers.Checked = true;
            }
            ctlCustomer1.txtCode.Text = _oCustomer.CustomerCode;

            cmbJobType.SelectedIndex = oCSDJob.JobType;
            cmbJobPriority.SelectedIndex = oCSDJob.Priority - 1;
            txtReferenceJob.Text = oCSDJob.ReferenceJobNo;
            //===============================================================
            if (oCSDJob.RefSalesPointID != 0)
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerID = oCSDJob.RefSalesPointID;
                _oCustomer.refresh();
                if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Retail)
                {
                    rdosrcTranscomDigital.Checked = true;
                }
                else if (_oCustomer.ChannelID == (int)Dictionary.Channel.EnA_Distribution)
                {
                    rdosrcDealer.Checked = true;
                }
                else if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate)
                {
                    rdosrcCorporate.Checked = true;
                }
                //else if (_oCustomer.ChannelID == (int)Dictionary.Channel.Head_Office)
                //{
                //    rdoHeadOffice.Checked = true;
                //}
                else
                {
                    rdoCustomerHimself.Checked = true;
                }
                if (_oCustomer.ChannelID != (int)Dictionary.Channel.Others)
                {
                    ctlsrcCustomer.txtCode.Text = _oCustomer.CustomerCode;
                }
                if (oCSDJob.OwnOrCustomerSet == (int)Dictionary.UnsoldOrCustomersProduct.Unsold_Product)
                {
                    rdoUnsoldProduct.Checked = true;
                }
                else
                {
                    rdoCustomersProduct.Checked = true;
                }
            }
            else
            {
                rdoCustomerHimself.Checked = true;
            }

            txtCustomerName.Text = oCSDJob.CustomerName;
            txtAddress.Text = oCSDJob.CustomerAddress;
            txtMobileNo.Text = oCSDJob.MobileNo;
            txtTelePhone.Text = oCSDJob.TelePhone;
            txtEmail.Text = oCSDJob.Email;
            txtNationalID.Text = oCSDJob.NationalID;
            txtRemarks.Text = oCSDJob.Remarks;

            if (oCSDJob.ReceivingTransportationMode == (int)Dictionary.JobTransportation.Courier)
            {
                rdoTransportCourier.Checked = true;
                int nCourierID = _oCourierServices.GetIndex(oCSDJob.ReceivingCourierID);
                cmbCourier.SelectedIndex = nCourierID + 1;
            }
            else if (oCSDJob.ReceivingTransportationMode == (int)Dictionary.JobTransportation.TELVehicle)
            {
                rdoTransportTEL.Checked = true;
            }
            else
            {
                rdoTransportOwn.Checked = true;
            }
            if (oCSDJob.ReceivingTransportationMode != (int)Dictionary.JobTransportation.CustomerOwn)
            {
                txtCost.Text = oCSDJob.ReceivingCost.ToString();
                txtInstrument.Text = oCSDJob.ReceivingInstrumentNo;
            }

            dtFeedbackDate.Value = oCSDJob.LastFeedBackDate;

            if (dgvCheckList.Rows.Count > 0)
            {
                CheckCSDJobCheckList(oCSDJob.JobID);
            }

            this.ShowDialog();
        }
        public void ShowDialog(int nCallFrom)
        {
            //nCallFrom = 1 =call From call center
            _nCallFrom = nCallFrom;
            this.ShowDialog();
        }

        private void CheckCSDJobCheckList(int nJobID)
        {
            _oCSDJobCheckLists = new CSDJobCheckLists();
            _oCSDJobCheckLists.Refresh(nJobID);

            foreach (DataGridViewRow oItemRow in dgvCheckList.Rows)
            {
                if (oItemRow.Index < dgvCheckList.Rows.Count)
                {
                    foreach (CSDJobCheckList oCSDJobCheckList in _oCSDJobCheckLists)
                    {
                        if (oCSDJobCheckList.ProductCheckListID == int.Parse(oItemRow.Cells[3].Value.ToString()))
                        {
                            oItemRow.Cells[0].Value = true;
                            oItemRow.Cells[2].Value = oCSDJobCheckList.Description;
                        }
                    }
                }
            }

        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please Input a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }
            if (cmbProductFault.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Product Fault", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProductFault.Focus();
                return false;
            }
            if (cmbActualFault.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Actual Product Fault", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbActualFault.Focus();
                return false;
            }
            if (cmbJobType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Job Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbJobType.Focus();
                return false;
            }

            if (ctlCustomer1.txtDescription.Text == "" && rdoOthers.Checked == false)
            {
                MessageBox.Show("Please Input Sales Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            else
            {
                _oCustomer = new Customer();
                if (ctlCustomer1.txtDescription.Text != "")
                {
                    _oCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    _oCustomer.refresh();
                }
                if (rdoTranscomDigital.Checked == true)
                {
                    if (_oCustomer.ChannelID != (int)Dictionary.Channel.TD_Retail)
                    {
                        MessageBox.Show("Please Input TD Sales Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Focus();
                        return false;
                    }
                }
                else if (rdoDealer.Checked == true)
                {
                    if (_oCustomer.ChannelID != (int)Dictionary.Channel.EnA_Distribution)
                    {
                        MessageBox.Show("Please Input Dealer Sales Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Focus();
                        return false;
                    }
                }
                else if (rdoCorporate.Checked == true)
                {
                    if (_oCustomer.ChannelID != (int)Dictionary.Channel.TD_Corporate)
                    {
                        MessageBox.Show("Please Input Corporate Sales Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCustomer1.txtCode.Focus();
                        return false;
                    }
                }
                //else
                //{
                //    if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Retail || _oCustomer.ChannelID == (int)Dictionary.Channel.EnA_Distribution || _oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate)
                //    {
                //        MessageBox.Show("Please Input Except TD/Dealer/Corporate Sales Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        ctlCustomer1.txtCode.Focus();
                //        return false;
                //    }
                //}
            }
            if (rdoCustomerHimself.Checked != true && rdoThirdParty.Checked != true &&rdoHeadOffice.Checked!=true)
            {
                if (ctlsrcCustomer.txtDescription.Text == "")
                {
                    MessageBox.Show("Please Input Soruce Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlsrcCustomer.txtCode.Focus();
                    return false;
                }
                else
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = ctlsrcCustomer.SelectedCustomer.CustomerID;
                    _oCustomer.refresh();
                    if (rdosrcTranscomDigital.Checked == true)
                    {
                        if (_oCustomer.ChannelID != (int)Dictionary.Channel.TD_Retail)
                        {
                            MessageBox.Show("Please Input TD Soruce Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlsrcCustomer.txtCode.Focus();
                            return false;
                        }
                    }
                    else if (rdosrcDealer.Checked == true)
                    {
                        if (_oCustomer.ChannelID != (int)Dictionary.Channel.EnA_Distribution)
                        {
                            MessageBox.Show("Please Input Dealer Soruce Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlsrcCustomer.txtCode.Focus();
                            return false;
                        }
                    }
                    else if (rdosrcCorporate.Checked == true)
                    {
                        if (_oCustomer.ChannelID != (int)Dictionary.Channel.TD_Corporate)
                        {
                            MessageBox.Show("Please Input Corporate Soruce Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlsrcCustomer.txtCode.Focus();
                            return false;
                        }
                    }

                }
            }
            else if (rdoThirdParty.Checked == true && ctlInterService1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Third Party Soruce Point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlInterService1.txtCode.Focus();
                return false;
            }
            else if (rdoHeadOffice.Checked == true)
            {
                if (cmbDepartment.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDepartment.Focus();
                    return false;
                }
            }
            //if (_nUIControl == (int)Dictionary.ServiceType.InterService)
            //{
            //    if (ctlInterService1.txtDescription.Text == "")
            //    {
            //        MessageBox.Show("Please Input a Inter Service", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        ctlInterService1.txtCode.Focus();
            //        return false;
            //    }
            //}
            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtMobileNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }
            else
            {
                if (txtMobileNo.Text.Trim().Length != 11)
                {
                    MessageBox.Show("Please enter a valid Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobileNo.Focus();
                    return false;
                }
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtMobileNo.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Mobile No ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobileNo.Focus();
                    return false;
                }
            }
            if (txtEmail.Text.Trim() != "")
            {
                Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match m = emailregex.Match(txtEmail.Text);
                if (!m.Success)
                {
                    MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
                //System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9] [\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                //if (txtEmail.Text.Length > 0)
                //{

                //    if (!rEmail.IsMatch(txtEmail.Text))
                //    {

                //        MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        txtEmail.SelectAll();
                //        return false;
                //    }

                //}

            }
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                if (rdoTransportCourier.Checked == true)
                {
                    if (cmbCourier.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select Courier Service Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbCourier.Focus();
                        return false;
                    }
                }
                if (dtFeedbackDate.Value.Date < DateTime.Today.Date && this.Tag == null)
                {
                    MessageBox.Show("Feedback Date Must be Grather or Equal system Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtFeedbackDate.Focus();
                    return false;
                }
            }


            foreach (DataGridViewRow oItemRow in dgvCheckList.Rows)
            {
                if (oItemRow.Index < dgvCheckList.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    if (isSelect && oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Enter Description of Selected Product Checklist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            if (cmbDistrict.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Customer District", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDistrict.Focus();
                return false;
            }
            if (cmbThana.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Customer Thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }
            return true;
            #endregion
        }

        private void rdoWalkin_CheckedChanged(object sender, EventArgs e)
        {
            chkDelivered_SvrProvided.Visible = true;
            gbVisitingDate.Visible = false;

            lblFeedbackDate.Visible = true;
            dtFeedbackDate.Visible = true;
        }

        private void rdoHomeCall_CheckedChanged(object sender, EventArgs e)
        {
            chkDelivered_SvrProvided.Visible = true;
            gbVisitingDate.Visible = true;

            lblFeedbackDate.Visible = false;
            dtFeedbackDate.Visible = false;
        }

        private void rdoInstallation_CheckedChanged(object sender, EventArgs e)
        {
            chkDelivered_SvrProvided.Visible = true;
            gbVisitingDate.Visible = true;

            lblFeedbackDate.Visible = false;
            dtFeedbackDate.Visible = false;
        }

        private void rdoCustomersProduct_CheckedChanged(object sender, EventArgs e)
        {
            //txtCustomerName.Text = "";
            //txtAddress.Text = "";
            //txtMobileNo.Text = "";
            //txtTelePhone.Text = "";
            //txtEmail.Text = "";
            //txtNationalID.Text = "";
        }

        private void rdoUnsoldProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCustomerHimself.Checked != true)
            {
                if (ctlsrcCustomer.txtDescription.Text != "")
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = ctlsrcCustomer.SelectedCustomer.CustomerID;
                    _oCustomer.refresh();

                    txtCustomerName.Text = _oCustomer.CustomerName;
                    txtAddress.Text = _oCustomer.CustomerAddress;
                    txtMobileNo.Text = _oCustomer.CellPhoneNo;
                    txtTelePhone.Text = _oCustomer.CustomerTelephone;
                    txtEmail.Text = _oCustomer.EmailAddress;
                    txtNationalID.Text = "";
                }
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bool bFlag = false;
            if (rdoGetOldJob.Checked == true)
            {

                if (txtPath.Text.Trim() != "")
                {
                    _oCSDJob = new CSDJob();
                    if (_oCSDJob.GetJobByJobNo(txtPath.Text.Trim()))
                    {
                        OldJobInfo(_oCSDJob, true);
                        bFlag = true;
                    }
                    else
                    {
                        if (_oCSDJob.GetCassandraJobByJobNo(txtPath.Text.Trim()))
                        {
                            OldJobInfo(_oCSDJob, false);
                            bFlag = true;
                        }
                    }

                    if (bFlag)
                    {
                        cmbCSDCompany.SelectedIndex = 1;
                        cmbCSDCompany.Enabled = false;
                        if (txtInvoiceNo.Text != "")
                        {
                            txtInvoiceNo.Enabled = false;
                            dtInvoiceDate.Enabled = false;
                        }
                        else
                        {
                            txtInvoiceNo.Enabled = true;
                            dtInvoiceDate.Enabled = true;
                        }
                        bFlag = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Please Input a Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Focus();
                }
            }
            else if (rdoGetInvoice.Checked == true)
            {
                bool _Flag = false;
                if (txtPath.Text.Trim() != "")
                {
                    _oCSDJob = new CSDJob();
                    if (_oCSDJob.GetInvoice(txtPath.Text.Trim()))
                    {
                        _Flag = true;
                        GetInvoiceInfo(_oCSDJob, false);
                    }
                    else
                    {
                        if (_oCSDJob.GetCassiopeiaInvoice(txtPath.Text.Trim()))
                        {
                            _Flag = true;
                            GetInvoiceInfo(_oCSDJob, true);
                        }
                    }

                    

                    if (!_Flag)
                    {
                        MessageBox.Show("Invalid Invoice Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cmbCSDCompany.SelectedIndex = 1;
                        cmbCSDCompany.Enabled = false;
                        if (txtInvoiceNo.Text != "")
                        {
                            txtInvoiceNo.Enabled = false;
                            dtInvoiceDate.Enabled = false;
                        }
                        else
                        {
                            txtInvoiceNo.Enabled = true;
                            dtInvoiceDate.Enabled = true;
                        }
                        bFlag = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please Input a Invoice Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Focus();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void GetInvoiceInfo(CSDJob oCSDJob, bool _bFlag)
        {
            ctlProduct1.txtCode.Text = oCSDJob.ProductCode;
            txtBarcodeSL.Text = oCSDJob.ProductSerialNo;
            txtInvoiceNo.Text = oCSDJob.InvoiceNo;
            dtInvoiceDate.Value = Convert.ToDateTime(oCSDJob.InvoiceDate);
            dtInvoiceDate.Checked = true;

            if (_bFlag)
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerCode = oCSDJob.CustomerCode;
                _oCustomer.RefreshByCode();
            }
            else
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerID = oCSDJob.SalesPointID;
                _oCustomer.refresh();
            }
            if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Retail)
            {
                rdoTranscomDigital.Checked = true;
            }
            else if (_oCustomer.ChannelID == (int)Dictionary.Channel.EnA_Distribution)
            {
                rdoDealer.Checked = true;
            }
            else if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate || _oCustomer.ChannelID == (int)Dictionary.Channel.B2B)
            {
                //rdoCorporate.Checked = true; Considering B2B Customer
                rdoTranscomDigital.Checked = true;
            }
            else
            {
                rdoOthers.Checked = true;
            }
            Customer _oCustomerx = new Customer();
            if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate || _oCustomer.ChannelID == (int)Dictionary.Channel.B2B)
            {
                _oCustomerx.CustomerID = _oCustomer.ParentCustomerID;
                _oCustomerx.refresh();
            }
            ctlCustomer1.txtCode.Text = _oCustomerx.CustomerCode;
            txtCustomerName.Text = oCSDJob.CustomerName;
            txtAddress.Text = oCSDJob.CustomerAddress;
            txtMobileNo.Text = oCSDJob.MobileNo;
            txtTelePhone.Text = oCSDJob.TelePhone;
            txtEmail.Text = oCSDJob.Email;
            txtNationalID.Text = oCSDJob.NationalID;
            txtRemarks.Text = oCSDJob.Remarks;
        }

        private void OldJobInfo(CSDJob _oCSDJob, bool IsTrue)
        {
            ctlProduct1.txtCode.Text = _oCSDJob.ProductCode;

            txtBarcodeSL.Text = _oCSDJob.ProductSerialNo;
            txtInvoiceNo.Text = _oCSDJob.InvoiceNo;
            if (IsTrue)
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerID = _oCSDJob.SalesPointID;
                _oCustomer.refresh();
                ctlCustomer1.txtCode.Text = _oCustomer.CustomerCode;


                if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Retail)
                {
                    rdoTranscomDigital.Checked = true;
                }
                else if (_oCustomer.ChannelID == (int)Dictionary.Channel.EnA_Distribution)
                {
                    rdoDealer.Checked = true;
                }
                else if (_oCustomer.ChannelID == (int)Dictionary.Channel.TD_Corporate)
                {
                    rdoCorporate.Checked = true;
                }
                else
                {
                    rdoOthers.Checked = true;
                }
            }
            else
            {
                rdoTranscomDigital.Checked = true;
            }
            if (_oCSDJob.InvoiceDate != DBNull.Value && _oCSDJob.InvoiceDate != null)
            {
                dtInvoiceDate.Value = Convert.ToDateTime(_oCSDJob.InvoiceDate.ToString());
                dtInvoiceDate.Checked = true;
            }

            if (_oCSDJob.ReferenceJobNo == "")
            {
                txtReferenceJob.Text = _oCSDJob.JobNo;
            }
            else
            {
                txtReferenceJob.Text = _oCSDJob.JobNo + ", " + _oCSDJob.ReferenceJobNo;
            }

            txtCustomerName.Text = _oCSDJob.CustomerName;
            txtAddress.Text = _oCSDJob.CustomerAddress;
            txtMobileNo.Text = _oCSDJob.MobileNo;
            txtTelePhone.Text = _oCSDJob.TelePhone;
            txtEmail.Text = _oCSDJob.Email;
            txtNationalID.Text = _oCSDJob.NationalID;
            txtRemarks.Text = _oCSDJob.Remarks;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load Thana Combo 
            if (cmbDistrict.SelectedIndex != 0)
            {
                _oGeoLocationsThanas = new GeoLocations();
                int nDistrictId = _oGeoLocations[cmbDistrict.SelectedIndex - 1].GeoLocationID;
                cmbThana.Items.Clear();
                cmbThana.Items.Add("--Select --");
                cmbThana.SelectedIndex = 0;
                _oGeoLocationsThanas.GetThana(nDistrictId);
                foreach (GeoLocation oGeoLocation in _oGeoLocationsThanas)
                {
                    cmbThana.Items.Add(oGeoLocation.GeoLocationName);
                }
            }
            if (cmbDistrict.SelectedIndex == 0 || cmbThana.SelectedIndex == 0)
            {
                btnAssign.Enabled = false;
            }
            else if (this.Tag == null || this.Tag == " ")
            {
                btnAssign.Enabled = true;
            }


        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            DateTime _date;
            if (_nUIControl == (int)Dictionary.ServiceType.Walkin)
            {
                _date = DateTime.Today.Date;
            }
            else
            {
                _date = dtVisitingDate.Value.Date;
            }

            int nThanaID = _oGeoLocationsThanas[cmbThana.SelectedIndex - 1].GeoLocationID;
            frmCSDJobAssign oForm = new frmCSDJobAssign(_date);
            oForm.ShowDialog(nThanaID);
            if (oForm._oCSDTechnician != null)
            {
                txtAssignTech.Text = oForm._oCSDTechnician.Name + " [" + oForm._oCSDTechnician.Code + "]";
                lblAssignTechID.Text = oForm._oCSDTechnician.TechnicianID.ToString();
                lblAssignTechType.Text = oForm._oCSDTechnician.Type.ToString();
            }

        }

        private void rdoCentralService_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCentralService.Checked)
            {
                btnAssign.Visible = false;
                txtAssignTech.Visible = false;
            }
        }

        private void rdoOuterService_CheckedChanged(object sender, EventArgs e)
        {
            btnAssign.Visible = true;
            txtAssignTech.Visible = true;
            if (cmbDistrict.SelectedIndex != 0 && cmbThana.SelectedIndex != 0 && rdoOuterService.Checked && this.Tag == null)
            {
                btnAssign.Enabled = true;
            }
            else
            {
                btnAssign.Enabled = false;
            }
        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.txtDescription.Text != "")
            {
                _oCSDServiceChargeProduct = new CSDServiceChargeProduct();
                _oCSDServiceCharge = new CSDServiceCharge();
                _oCSDServiceCharge.ServiceChargeID = _oCSDServiceChargeProduct.GetServiceChargeID(ctlProduct1.SelectedSerarchProduct.ProductID);
                if (_oCSDServiceCharge.ServiceChargeID != 0)
                {
                    _oCSDServiceCharge.Refresh();
                    if (cmbProductAccessories.SelectedIndex == 0)
                    {
                        lblProductCategory.Text = _oCSDServiceCharge.ServiceChargeName;
                    }
                    LoadChecklist(_oCSDServiceCharge.ProductTypeID);
                }
                else
                {
                    MessageBox.Show("Please map the product with service charge category.\nProduct Code: " + ctlProduct1.txtCode.Text + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctlProduct1.txtCode.Text = "";
                }
                if (ctlProduct1.SelectedSerarchProduct.BrandID != 19)
                {
                    cmbCSDCompany.SelectedIndex = 1;
                    cmbCSDCompany.Enabled = false;
                }
                else
                {
                    cmbCSDCompany.SelectedIndex = 0;
                    cmbCSDCompany.Enabled = true;
                }
            }
        }

        private void LoadChecklist(int nProductTypeID)
        {
            _oCSDProductCheckLists = new CSDProductCheckLists();
            _oCSDProductCheckLists.GetProductCheckList(nProductTypeID);
            dgvCheckList.Rows.Clear();
            foreach (CSDProductCheckList oCSDProductCheckList in _oCSDProductCheckLists)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvCheckList);

                oRow.Cells[1].Value = oCSDProductCheckList.Description;
                oRow.Cells[3].Value = oCSDProductCheckList.ProductCheckListID;
                dgvCheckList.Rows.Add(oRow);
            }

        }

        private void ctlProduct1_Load(object sender, EventArgs e)
        {

        }

        private void cmbThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrict.SelectedIndex == 0 || cmbThana.SelectedIndex == 0)
            {
                btnAssign.Enabled = false;
            }
            else if (this.Tag == null || this.Tag == " ")
            {
                btnAssign.Enabled = true;
            }
        }

        private void cmbProductFault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductFault.SelectedIndex != 0)
            {
                _oProductActualFaults = new ProductFaults();
                int nParentID = _oProductFaults[cmbProductFault.SelectedIndex - 1].FaultID;
                cmbActualFault.Items.Clear();
                cmbActualFault.Items.Add("--Select --");
                cmbActualFault.SelectedIndex = 0;
                _oProductActualFaults.GetData(nParentID);
                foreach (ProductFault oProductFault in _oProductActualFaults)
                {
                    cmbActualFault.Items.Add(oProductFault.FaultDescription);
                }
            }
            else
            {
                cmbActualFault.Items.Clear();
                cmbActualFault.Items.Add("--Select --");
                cmbActualFault.SelectedIndex = 0;
            }
        }

        private void rdoTranscomDigital_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoDealer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoOthers_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoOthers.Checked)
            //{
            //    ctlCustomer1.Enabled = false;
            ctlCustomer1.txtCode.Text = string.Empty;
            //}
            //else
            //{
            //    ctlCustomer1.Enabled = true;
            //}
        }

        private void lblProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbProductAccessories.SelectedIndex == 0)
            {
                if (ctlProduct1.txtDescription.Text != string.Empty)
                {
                    frmViewServiceCharge oForm = new frmViewServiceCharge();
                    oForm.ShowDialog(ctlProduct1.SelectedSerarchProduct.ProductID);
                }
            }
            else
            {
                ProductAccessory oProductAccessory = new ProductAccessory();
                oProductAccessory.AccessoriesID = _oProductAccessories[cmbProductAccessories.SelectedIndex - 1].AccessoriesID;
                oProductAccessory.RefreshByID();
                frmAccessoryServiceChargeView oForm = new frmAccessoryServiceChargeView();
                oForm.ShowDialog(oProductAccessory);

            }
        }

        private void cmbProductAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductAccessories.SelectedIndex != 0)
            {
                lblProductCategory.Text = cmbProductAccessories.Text;
            }
            else
            {
                if (ctlProduct1.txtDescription.Text != "")
                {
                    _oCSDServiceChargeProduct = new CSDServiceChargeProduct();
                    _oCSDServiceCharge = new CSDServiceCharge();
                    _oCSDServiceCharge.ServiceChargeID = _oCSDServiceChargeProduct.GetServiceChargeID(ctlProduct1.SelectedSerarchProduct.ProductID);
                    if (_oCSDServiceCharge.ServiceChargeID != 0)
                    {
                        _oCSDServiceCharge.Refresh();
                        lblProductCategory.Text = _oCSDServiceCharge.ServiceChargeName;
                    }
                }
                else
                {
                    lblProductCategory.Text = "?";
                }
            }
        }

        private void rdoHeadOffice_CheckedChanged(object sender, EventArgs e)
        {
            ctlsrcCustomer.Visible = false;
            ctlInterService1.Visible = false;
            //txtownset.Enabled = true;
            rdoUnsoldProduct.Enabled = true;
            rdoCustomersProduct.Enabled = false;
            rdoCustomersProduct.Checked = false;
            lblSourceCode.Enabled = true;
            lblProductOwner.Enabled = false;
            cmbDepartment.Visible = true;
        }

    }
}