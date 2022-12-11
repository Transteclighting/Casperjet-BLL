// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam Kar 
// Date: 22-May-2014
// Time : 2:00 PM
// Description: Customer entry form.
// Modify Person And Date:
// </summary>

using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win
{
    public partial class frmCustomer : Form
    {
        CustomerType _oCustomerType;
        Channels _oChannels;
        MarketGroups _oMarketGroups;
        MarketGroups _oMarketGroupsTarritory;
        Districts _oDistricts;
        Customers _oCustomers;
        CustomerTypies _oCustomerTypies;
        GeoLocations _oGeoLocations;
        GeoLocations _oGeoLocationsThana;
        Customer _oCustomer;
        Customer _oTempCustomer;
        DataSyncManager _oDataSyncManager;
        int nCustomerID;
        Showroom oShowroom;
        int _nUIControl = 0;
        Customer oMaxCustomerCode;
        int nWarehouseID = 0;


        public frmCustomer(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            btnApproved.Visible = false;
            btnSave.Visible = false;

            if (_nUIControl == 3)
            {
                Text = "Approved Temp Customer";
                btnApproved.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                if (Tag == null)
                {
                    Text = "Add New Customer";
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    LoadCombos();
                }
                else Text = "Edit Customer";

                btnApproved.Visible = false;
                btnSave.Visible = true;
            }

        }
        public void LoadArea()
        {
            /*************Market Area***********/
            _oMarketGroups = new MarketGroups();
            cmbArea.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oMarketGroups.RefreshMarketGroupByChannelID((int)Dictionary.MarketGroupType.Area, _oChannels[cmbChannel.SelectedIndex - 1].ChannelID);
            cmbArea.Items.Add("---Select Area---");
            foreach (MarketGroup oMarketGroup in _oMarketGroups)
            {
                cmbArea.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbArea.SelectedIndex = 0;
        }
        public void LoadCustomerType()
        {

            /************Customer Type****************/
            _oCustomerTypies = new CustomerTypies();
            cmbCustType.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oCustomerTypies.GetCustTypeChannelWise(_oChannels[cmbChannel.SelectedIndex - 1].ChannelID);
            cmbCustType.Items.Add("--Select CustomerType--");
            foreach (CustomerType oCustomerType in _oCustomerTypies)
            {
                cmbCustType.Items.Add(oCustomerType.CustTypeDescription);
            }
            cmbCustType.SelectedIndex = 0;
        }

        public void LoadCombos()
        {

            ///************Customer Type****************/
            //_oCustomerTypies = new CustomerTypies();
            //cmbCustType.Items.Clear();
            //if (!DBController.Instance.CheckConnection())
            //{
            //    DBController.Instance.OpenNewConnection();
            //}
            //_oCustomerTypies.Refresh();
            //cmbCustType.Items.Add("--Select CustomerType--");
            //foreach (CustomerType oCustomerType in _oCustomerTypies)
            //{
            //    cmbCustType.Items.Add(oCustomerType.CustTypeDescription);
            //}
            //cmbCustType.SelectedIndex = 0;
            /************Channel****************/
            _oChannels = new Channels();
            cmbChannel.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oChannels.Refresh();
            cmbChannel.Items.Add("--Select Channel---");
            foreach (Channel oChannel in _oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = 0;

            ///*************Market Area***********/
            //_oMarketGroups = new MarketGroups();
            //cmbArea.Items.Clear();
            //if (!DBController.Instance.CheckConnection())
            //{
            //    DBController.Instance.OpenNewConnection();
            //}
            //_oMarketGroups.Refresh((int)Dictionary.MarketGroupType.Area);
            //cmbArea.Items.Add("---Select Area---");
            //foreach (MarketGroup oMarketGroup in _oMarketGroups)
            //{
            //    cmbArea.Items.Add(oMarketGroup.MarketGroupDesc);
            //}
            //cmbArea.SelectedIndex = 0;


            /*********Select District***********/
            _oGeoLocations = new GeoLocations();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("---Select District---");
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oGeoLocations.GetAllDistrict();
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThana();
        }

        private void LoadThana()
        {
            var nDistrictId = cmbDistrict.SelectedIndex != 0 ? _oGeoLocations[cmbDistrict.SelectedIndex - 1].GeoLocationID : 0;
            cmbThana.Items.Clear();

            _oGeoLocationsThana = new GeoLocations();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oGeoLocationsThana.GetThana(nDistrictId);

            cmbThana.Items.Add("---Select Thana---");
            foreach (GeoLocation oGeoLocation in _oGeoLocationsThana)
            {
                cmbThana.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbThana.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidUi())
            {
                Save();
                
            }
        }

        private bool IsValidUi()
        {
            if (txtCustomerCode.Text == "")
            {
                MessageBox.Show("Please enter Customer Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                return false;
            }
            if (txtCustShortName.Text == "")
            {
                MessageBox.Show("Please enter Customer Short Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustShortName.Focus();
                return false;
            }
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter Customer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (cmbCustType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustType.Focus();
                return false;
            }
            if (cmbCustType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustType.Focus();
                return false;
            }
            if (cmbTerritory.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Territory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTerritory.Focus();
                return false;
            }
            if (cmbThana.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {

            if (this.Tag == null)
            {
                _oCustomer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text,
                    CustomerShortName = txtCustShortName.Text,
                    TaxNumber = txtTaxNo.Text,
                    CustomerName = txtCustomerName.Text,
                    CustomerAddress = txtCustomerAddress.Text,
                    CustomerTelephone = txtCustomerTelephone.Text,
                    CustomerFax = txtCustomerFax.Text,
                    CellPhoneNo = txtCellPhoneNumber.Text,
                    ContactPerson = txtContactPerson.Text,
                    ContactDesignation = txtContactDesignation.Text
                };
                if (chkActive.Checked)
                {
                    _oCustomer.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oCustomer.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                if (ctlCustomer.SelectedCustomer != null)
                {
                    _oCustomer.ParentCustomerID = ctlCustomer.SelectedCustomer.CustomerID;
                }
                else
                {
                    _oCustomer.ParentCustomerID = 0;
                }
                _oCustomer.CustTypeID = _oCustomerTypies[cmbCustType.SelectedIndex - 1].CustTypeID;
                _oCustomer.MarketGroupID = _oMarketGroupsTarritory[cmbTerritory.SelectedIndex - 1].MarketGroupID;
                _oCustomer.GeoLocationID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oCustomer.EmailAddress = txtEmail.Text;
                _oCustomer.EnrollmentDate = dtEnrollment.Value.Date;

                try
                {
                    _oDataSyncManager = new DataSyncManager();
                    DBController.Instance.BeginNewTransaction();
                    _oCustomer.InsertCustomer();
                    int WHDID = 0;
                    if (ctlCustomer.SelectedCustomer != null)
                    {
                        oShowroom = new Showroom();
                        oShowroom.GetShowroomByCustomerID(_oCustomer.ParentCustomerID);
                        if (ctlCustomer.SelectedCustomer.CustomerID == oShowroom.CustomerID) ;
                        {
                            WHDID = oShowroom.WarehouseID;
                            _oDataSyncManager.SendCustomerToShowroom(_oCustomer, Dictionary.DataTransferType.Add, oShowroom.WarehouseID);
                        }
                    }


                    #region Insert Customer Data for Super Outlet
                    Customer oCustomerData = new Customer();
                    oCustomerData.CustomerBalanceDataCreation(_oCustomer.CustomerID, WHDID, "t_Customer", _oCustomer.CustomerID);
                    #endregion

                    //_oDataSyncManager.SendCustomerToShowroom(_oCustomer, Dictionary.DataTransferType.Add);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oCustomer.CustomerCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }


            else
            {
                //_oCustomer = (Customer)this.Tag;
                _oCustomer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text,
                    CustomerShortName = txtCustShortName.Text,
                    TaxNumber = txtTaxNo.Text,
                    CustomerName = txtCustomerName.Text,
                    CustomerAddress = txtCustomerAddress.Text,
                    CustomerTelephone = txtCustomerTelephone.Text,
                    CustomerFax = txtCustomerFax.Text,
                    CellPhoneNo = txtCellPhoneNumber.Text,
                    ContactPerson = txtContactPerson.Text,
                    ContactDesignation = txtContactDesignation.Text
                };
                if (chkActive.Checked)
                {
                    _oCustomer.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oCustomer.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                _oCustomer.ParentCustomerID = ctlCustomer.SelectedCustomer?.CustomerID ?? 0;
                _oCustomer.CustTypeID = _oCustomerTypies[cmbCustType.SelectedIndex - 1].CustTypeID;
                _oCustomer.MarketGroupID = _oMarketGroupsTarritory[cmbTerritory.SelectedIndex - 1].MarketGroupID;
                _oCustomer.GeoLocationID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oCustomer.EmailAddress = txtEmail.Text;
                _oCustomer.EnrollmentDate = dtEnrollment.Value.Date;

                try
                {

                    _oDataSyncManager = new DataSyncManager();
                    DBController.Instance.BeginNewTransaction();
                    _oCustomer.CustomerID = nCustomerID;
                    _oCustomer.Edit();
                    int WHDID = 0;
                    if (ctlCustomer.SelectedCustomer != null)
                    {
                        oShowroom = new Showroom();
                        oShowroom.GetShowroomByCustomerID(_oCustomer.ParentCustomerID);
                        if (ctlCustomer.SelectedCustomer.CustomerID == oShowroom.CustomerID) ;
                        {
                            WHDID = oShowroom.WarehouseID;
                            _oDataSyncManager.SendCustomerToShowroom(_oCustomer, Dictionary.DataTransferType.Add, oShowroom.WarehouseID);
                        }
                    }

                    #region Insert Customer Data for Super Outlet
                    Customer oCustomerData = new Customer();
                    oCustomerData.CustomerBalanceDataCreation(_oCustomer.CustomerID, WHDID, "t_Customer", _oCustomer.CustomerID);
                    #endregion

                    //_oDataSyncManager.SendCustomerToShowroom(_oCustomer, Dictionary.DataTransferType.Edit); 
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oCustomer.CustomerCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            LoadTerritory();

        }

        private void LoadTerritory()
        {
            var nAreaId = cmbArea.SelectedIndex != 0 ? _oMarketGroups[cmbArea.SelectedIndex - 1].MarketGroupID : 0;
            cmbTerritory.Items.Clear();
            _oMarketGroupsTarritory = new MarketGroups();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oMarketGroupsTarritory.GetAreaWiseTerritory(nAreaId);
            cmbTerritory.Items.Add("---Select Territory---");
            foreach (MarketGroup oMarketGroup in _oMarketGroupsTarritory)
            {
                cmbTerritory.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbTerritory.SelectedIndex = 0;
        }

        public void ShowDialog(Customer oCustomer)
        {
            btnApproved.Visible = false;
            btnSave.Visible = false;

            _oCustomerTypies = new CustomerTypies();
            _oMarketGroupsTarritory = new MarketGroups();
            _oGeoLocationsThana = new GeoLocations();
            _oGeoLocations = new GeoLocations();
            _oMarketGroups = new MarketGroups();
            this.Tag = oCustomer;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            LoadCombos();
            LoadTerritory();
            LoadThana();
            nCustomerID = oCustomer.CustomerID;

            btnApproved.Visible = false;
            btnSave.Visible = false;
            chkActive.Checked = oCustomer.IsActive == (int)Dictionary.YesOrNoStatus.YES;
            if (_nUIControl == 3)
            {
                oMaxCustomerCode = new Customer();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oMaxCustomerCode.GetMaxCustomerCode();
                txtCustomerCode.Text = oMaxCustomerCode.CustomerCode;
                btnApproved.Visible = true;
                btnSave.Visible = false;
                nWarehouseID = oCustomer.WarehouseID;
                txtCustomerCode.Enabled = false;
                ctlCustomer.Enabled = false;
            }
            else
            {
                txtCustomerCode.Text = oCustomer.CustomerCode;
                btnApproved.Visible = false;
                btnSave.Visible = true;
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oCustomer.GetParentCustomer(nCustomerID);
            }
            txtCustShortName.Text = oCustomer.CustomerShortName;
            txtEmail.Text = oCustomer.EmailAddress;
            txtCustomerName.Text = oCustomer.CustomerName;
            txtCustomerAddress.Text = oCustomer.CustomerAddress;
            txtCustomerTelephone.Text = oCustomer.CustomerTelephone;
            txtCustomerFax.Text = oCustomer.CustomerFax;
            txtCellPhoneNumber.Text = oCustomer.CellPhoneNo;
            txtContactPerson.Text = oCustomer.ContactPerson;
            txtContactDesignation.Text = oCustomer.ContactDesignation;
            ctlCustomer.txtCode.Text = oCustomer.ParentCustomerCode;
            //dtEnrollment.Value = oCustomer.EnrollmentDate.Date;

            cmbChannel.SelectedIndex = _oChannels.GetIndex(oCustomer.ChannelID) + 1;
            cmbCustType.SelectedIndex = _oCustomerTypies.GetIndex(oCustomer.CustTypeID) + 1;
            cmbArea.SelectedIndex = _oMarketGroups.GetIndex(oCustomer.AreaID) + 1;
            cmbTerritory.SelectedIndex = _oMarketGroupsTarritory.GetIndex(oCustomer.MarketGroupID) + 1;
            cmbDistrict.SelectedIndex = _oGeoLocations.GetIndexByID(oCustomer.DistrictID) + 1;
            cmbThana.SelectedIndex = _oGeoLocationsThana.GetIndexByID(oCustomer.GeoLocationID) + 1;
            txtTaxNo.Text = oCustomer.TaxNumber;
            this.ShowDialog();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (IsValidUi())
            {
                _oCustomer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text,
                    CustomerShortName = txtCustShortName.Text,
                    CustomerName = txtCustomerName.Text,
                    CustomerAddress = txtCustomerAddress.Text,
                    CustomerTelephone = txtCustomerTelephone.Text,
                    CustomerFax = txtCustomerFax.Text,
                    CellPhoneNo = txtCellPhoneNumber.Text,
                    ContactPerson = txtContactPerson.Text,
                    ContactDesignation = txtContactDesignation.Text
                };
                if (chkActive.Checked == true)
                {
                    _oCustomer.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oCustomer.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                _oCustomer.ParentCustomerID = ctlCustomer.SelectedCustomer?.CustomerID ?? 0;
                _oCustomer.CustTypeID = _oCustomerTypies[cmbCustType.SelectedIndex - 1].CustTypeID;
                _oCustomer.MarketGroupID = _oMarketGroupsTarritory[cmbTerritory.SelectedIndex - 1].MarketGroupID;
                _oCustomer.GeoLocationID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oCustomer.EmailAddress = txtEmail.Text;
                _oCustomer.EnrollmentDate = dtEnrollment.Value.Date;

                try
                {
                    _oDataSyncManager = new DataSyncManager();
                    DBController.Instance.BeginNewTransaction();
                    _oCustomer.InsertCustomer();
                    _oCustomer.CreateAccount(_oCustomer.CustomerID);
                    if (ctlCustomer.SelectedCustomer != null)
                    {
                        oShowroom = new Showroom();
                        oShowroom.GetShowroomByCustomerID(_oCustomer.ParentCustomerID);
                        if (ctlCustomer.SelectedCustomer.CustomerID == oShowroom.CustomerID) ;
                        {
                            _oTempCustomer = new Customer();
                            _oTempCustomer.CustomerID = nCustomerID;
                            _oTempCustomer.WarehouseID = nWarehouseID;
                            _oTempCustomer.CustomerCode = _oCustomer.CustomerCode;
                            _oTempCustomer.Status = (int)Dictionary.B2BCustomerStatus.Approve_By_HO;
                            _oTempCustomer.UpdateTempCustomerStatus();
                            _oDataSyncManager.SendCustomerToShowroom(_oCustomer, Dictionary.DataTransferType.Add, oShowroom.WarehouseID);

                            DataTran oDataTran = new DataTran
                            {
                                TableName = "t_CustomerTemp",
                                DataID = Convert.ToInt32(nCustomerID),
                                WarehouseID = nWarehouseID,
                                TransferType = (int) Dictionary.DataTransferType.Edit,
                                IsDownload = (int) Dictionary.IsDownload.No,
                                BatchNo = 0
                            };

                            if (oDataTran.CheckData() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }

                        }

                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oCustomer.CustomerCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                this.Close();
            }

        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChannel.SelectedIndex == 0)
            {
                cmbCustType.Items.Clear();
                cmbCustType.Items.Add("--Select CustomerType--");
                cmbCustType.SelectedIndex = 0;

                cmbArea.Items.Clear();
                cmbArea.Items.Add("---Select Area---");
                cmbArea.SelectedIndex = 0;
            }
            else
            {
                LoadCustomerType();
                LoadArea();
            }
        }


    }
}