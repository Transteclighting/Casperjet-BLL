using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmCustomerTemp : Form
    {
        GeoLocation _oGeoLocation;
        GeoLocations _oGeoLocations;
        GeoLocations _oGeoLocationsThana;
        Customer _oCustomer;
        SystemInfo oSystemInfo;
        int nCustomerID = 0;
        int nWarehouseID = 0;


        public frmCustomerTemp()
        {
            InitializeComponent();
        }

        public void ShowDialog(Customer oCustomer)
        {
            _oGeoLocationsThana = new GeoLocations();
            _oGeoLocations = new GeoLocations();

            this.Tag = oCustomer;
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            //LoadThana();
            nCustomerID = oCustomer.CustomerID;
            nWarehouseID = oCustomer.WarehouseID;
            txtCustShortName.Text = oCustomer.CustomerShortName;
            txtCustomerName.Text = oCustomer.CustomerName;
            txtCustomerAddress.Text = oCustomer.CustomerAddress;
            txtCustomerTelephone.Text = oCustomer.CustomerTelephone;
            txtCustomerFax.Text = oCustomer.CustomerFax;
            txtCellPhoneNumber.Text = oCustomer.CellPhoneNo;
            txtContactPerson.Text = oCustomer.ContactPerson;
            txtContactDesignation.Text = oCustomer.ContactDesignation;
            txtTAXNo.Text = oCustomer.TaxNumber;
            _oGeoLocation = new GeoLocation();
            _oGeoLocation.RefreshByGeoLocationID(oCustomer.GeoLocationID);

            cmbDistrict.SelectedIndex = _oGeoLocations.GetIndexByID(_oGeoLocation.DistrictID) + 1;
            cmbThana.SelectedIndex = _oGeoLocationsThana.GetIndexByID(oCustomer.GeoLocationID) + 1;
            txtEmail.Text = oCustomer.EmailAddress;
            dtEnrollment.Value = oCustomer.EnrollmentDate.Date;

            this.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();

            /*********Select District***********/
            _oGeoLocations = new GeoLocations();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("---Select District---");
            _oGeoLocations.GetAllDistrict();
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;
        }

        private void LoadThana()
        {
            int nDistrictID = 0;
            if (cmbDistrict.SelectedIndex != 0)
            {
                nDistrictID = _oGeoLocations[cmbDistrict.SelectedIndex - 1].GeoLocationID;
            }
            else
            {
                nDistrictID = 0;
            }
            cmbThana.Items.Clear();

            _oGeoLocationsThana = new GeoLocations();
            _oGeoLocationsThana.GetThana(nDistrictID);
            cmbThana.Items.Add("---Select Thana---");
            foreach (GeoLocation oGeoLocation in _oGeoLocationsThana)
            {
                cmbThana.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbThana.SelectedIndex = 0;
        }

        private bool UIValidation()
        {
            if (txtCustShortName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Short Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustShortName.Focus();
                return false;
            }
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtCustomerAddress.Text == "")
            {
                MessageBox.Show("Please Enter Customer Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerAddress.Focus();
                return false;
            }
            if (txtCellPhoneNumber.Text == "")
            {
                MessageBox.Show("Please Enter Cell Phone Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCellPhoneNumber.Focus();
                return false;
            }
            if (txtContactPerson.Text == "")
            {
                MessageBox.Show("Please Enter Contact Person Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactPerson.Focus();
                return false;
            }
            if (txtContactDesignation.Text == "")
            {
                MessageBox.Show("Please Enter Contact Designation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactDesignation.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Enter Email Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }       
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerShortName = txtCustShortName.Text;
                _oCustomer.CustomerName = txtCustomerName.Text;
                _oCustomer.CustomerAddress = txtCustomerAddress.Text;
                _oCustomer.CustomerTelephone = txtCustomerTelephone.Text;
                _oCustomer.CustomerFax = txtCustomerFax.Text;
                _oCustomer.CellPhoneNo = txtCellPhoneNumber.Text;
                _oCustomer.ContactPerson = txtContactPerson.Text;
                _oCustomer.ContactDesignation = txtContactDesignation.Text;
                _oCustomer.IsActive = (int)Dictionary.YesNAStatus.Yes;
                _oCustomer.CustTypeID = Utility.CustomerType_TDCorporate;
                _oCustomer.MarketGroupID = Utility.B2B_Market_GroupID; ///B2B
                _oCustomer.GeoLocationID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oCustomer.EmailAddress = txtEmail.Text;
                _oCustomer.EnrollmentDate = dtEnrollment.Value.Date;
                _oCustomer.Terminal = (int)Dictionary.Terminal.Branch_Office;
                _oCustomer.Status = (int)Dictionary.B2BCustomerStatus.Create;
                _oCustomer.TaxNumber = txtTAXNo.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomer.AddTempCustomer();


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add New Customer. CustomerName: " + _oCustomer.CustomerName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                _oCustomer = (Customer)this.Tag;
                _oCustomer.CustomerID = nCustomerID;
                _oCustomer.WarehouseID = nWarehouseID;
                _oCustomer.CustomerShortName = txtCustShortName.Text;
                _oCustomer.CustomerName = txtCustomerName.Text;
                _oCustomer.CustomerAddress = txtCustomerAddress.Text;
                _oCustomer.CustomerTelephone = txtCustomerTelephone.Text;
                _oCustomer.CustomerFax = txtCustomerFax.Text;
                _oCustomer.CellPhoneNo = txtCellPhoneNumber.Text;
                _oCustomer.ContactPerson = txtContactPerson.Text;
                _oCustomer.ContactDesignation = txtContactDesignation.Text;
                _oCustomer.IsActive = (int)Dictionary.YesNAStatus.Yes;
                _oCustomer.CustTypeID = Utility.CustomerType_TDCorporate;
                _oCustomer.MarketGroupID = Utility.B2B_Market_GroupID; ///B2B
                _oCustomer.GeoLocationID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oCustomer.EmailAddress = txtEmail.Text;
                _oCustomer.EnrollmentDate = dtEnrollment.Value.Date;
                _oCustomer.Terminal = (int)Dictionary.Terminal.Branch_Office;
                _oCustomer.Status = (int)Dictionary.B2BCustomerStatus.Create;
                _oCustomer.UpdateDate = DateTime.Now.Date;
                _oCustomer.UpdateUserID = Utility.UserId;
                _oCustomer.TaxNumber = txtTAXNo.Text;

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    _oCustomer.EditTempCustomer();

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_CustomerTemp";
                    oDataTran.DataID = Convert.ToInt32(_oCustomer.CustomerID);
                    oDataTran.WarehouseID = nWarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update. CustomerName: " + _oCustomer.CustomerName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadThana();
        }

        private void frmCustomerTemp_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New B2B Customer";
                DBController.Instance.OpenNewConnection();
                LoadCombos();
            }
            else this.Text = "Edit B2B Customer";
        }
    }
}