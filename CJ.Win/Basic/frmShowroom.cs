// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: May 7, 2014
// Description: Forms for Add/Edit of District/Thana.
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CJ.Class;
using CJ.Class.POS;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.Basic
{
    public partial class frmShowroom : Form
    {
        Showroom _oShowroom;
        Showrooms _oShowrooms;
        private int _nShowroom;
        Channels _oChannels;
        ParentWarehouses _oParentWarehouses;
        GeoLocations _oGeoLocations;
        GeoLocations _oGeoLocationsThana;
        JobLocations _oJobLocations;
        int nReceivableDataCategory = 0;
        int nReceivableDataType = 0;
        public frmShowroom()
        {
            _oShowroom = new Showroom();
            _oShowrooms = new Showrooms();
            InitializeComponent();
        }

        private void frmShowroom_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Showroom";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Showroom";
            }
        }

        private void lblTelephone_Click(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //this.Close();
            }
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbShowroomType.Items.Add("--Select Showroom Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ShowRoomType)))
            {
                cmbShowroomType.Items.Add(Enum.GetName(typeof(Dictionary.ShowRoomType), GetEnum));
            }
            cmbShowroomType.SelectedIndex = 0;

            cmbDistance.Items.Add("--Select Distance Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DistanceType)))
            {
                cmbDistance.Items.Add(Enum.GetName(typeof(Dictionary.DistanceType), GetEnum));
            }
            cmbDistance.SelectedIndex = 0;

            /********Load Channel********************/
            _oChannels = new Channels();
            _oChannels.Refresh();
            cmbChannel.Items.Add("--Select Channel--");
            foreach (Channel oChannel in _oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = 0;
            /************Load Parent Warehouse************/
            _oParentWarehouses = new ParentWarehouses();
            _oParentWarehouses.RefreshByWarehouse();
            cmbWarehouse.Items.Add("--Select Parent Warehouse--");
            foreach (ParentWarehouse oParentWarehouse in _oParentWarehouses)
            {
                cmbWarehouse.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbWarehouse.SelectedIndex = 0;
            /************Load District************/
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
            /************Load Location************/
            _oJobLocations = new JobLocations();
            _oJobLocations.Refresh();
            cmbLocation.Items.Add("--Select Location-");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbLocation.Items.Add(oJobLocation.JobLocationName);
            }
            cmbLocation.SelectedIndex = 0;
        }
        private void Save()
        {

            Showroom oShowroom;
          
            if (this.Tag == null)
            {
                oShowroom = new Showroom();
                oShowroom.ShowroomCode = txtCode.Text;
                oShowroom.ShowroomName = txtName.Text;
                oShowroom.ShowroomType = cmbShowroomType.SelectedIndex;
                oShowroom.ShowroomAddress = txtAdress.Text;
                oShowroom.Telephone = txtCustomerTelephone.Text;
                oShowroom.Email = txtEmail.Text;
                oShowroom.WarehouseID = _oParentWarehouses[cmbWarehouse.SelectedIndex -1].WarehouseParentID;
                oShowroom.LocationID = _oJobLocations[cmbLocation.SelectedIndex - 1].JobLocationID;
                oShowroom.ThanaID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                oShowroom.ManagerID =-1;
                oShowroom.IsActive = chkActive.Checked;
                oShowroom.DistanceType = cmbDistance.SelectedIndex;
                oShowroom.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                //oShowroom.ChannelID = cmbChannel.SelectedIndex;
                oShowroom.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;
                oShowroom.MobileNo = txtCellPhoneNumber.Text;
                oShowroom.IsPOSActive = Convert.ToInt32(chkIsPOSActive.Checked);
                oShowroom.ReceivableDataCategory = (int)Dictionary.ReceivableDataCategory.None;
                oShowroom.ReceivableDataType = (int)Dictionary.ReceivableDataType.None;

                DBController.Instance.BeginNewTransaction();
                oShowroom.Add();
                //Showrooms oShowrooms = new Showrooms();
                //oShowrooms.Refresh();
                //foreach (Showroom _oShowroom in oShowrooms)
                //{
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_Showroom";
                    oDataTran.DataID = Convert.ToInt32(oShowroom.ShowroomID);
                    oDataTran.WarehouseID = oShowroom.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByWHID() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }
                //}
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Success fully Add # " + oShowroom.ShowroomCode.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                oShowroom = (Showroom)this.Tag;
                oShowroom.ShowroomCode = txtCode.Text;
                oShowroom.ShowroomName = txtName.Text;
                oShowroom.ShowroomType = cmbShowroomType.SelectedIndex;
                oShowroom.ShowroomAddress = txtAdress.Text;
                oShowroom.Telephone = txtCustomerTelephone.Text;
                oShowroom.Email = txtEmail.Text;
                oShowroom.WarehouseID = _oParentWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseParentID;
                oShowroom.ThanaID = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
                oShowroom.LocationID = _oJobLocations[cmbLocation.SelectedIndex - 1].JobLocationID;
                oShowroom.ManagerID = -1;
                oShowroom.IsActive = chkActive.Checked;
                oShowroom.DistanceType = cmbDistance.SelectedIndex;
                oShowroom.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oShowroom.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;
                oShowroom.MobileNo = txtCellPhoneNumber.Text;
                oShowroom.IsPOSActive = Convert.ToInt32(chkIsPOSActive.Checked);
                oShowroom.ReceivableDataCategory = (int)Dictionary.ReceivableDataCategory.None;
                oShowroom.ReceivableDataType = (int)Dictionary.ReceivableDataType.None;

                DBController.Instance.BeginNewTransaction();
                oShowroom.Edit();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Success fully Update # " + oShowroom.ShowroomCode.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }

        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match m = emailregex.Match(txtEmail.Text);

            Regex isnumber = new Regex("[0-9]");

            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            //if (cmbShowroomType.SelectedIndex == 0 || cmbShowroomType.SelectedIndex == cmbShowroomType.Items.Count - 1)
            if (cmbShowroomType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Showroom Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbShowroomType.Focus();
                return false;
            }

            if (txtAdress.Text == "")
            {
                MessageBox.Show("Please enter Adress of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdress.Focus();
                return false;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            else if (!m.Success)
            {
                MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (txtCustomerTelephone.Text == "")
            {
                MessageBox.Show("Please enter Telephone no. of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerTelephone.Focus();
                return false;
            }
            if (txtCellPhoneNumber.Text == "")
            {
                MessageBox.Show("Please enter Telephone no. of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCellPhoneNumber.Focus();
                return false;
            }

            if (cmbWarehouse.SelectedIndex == 0 )
            {
                MessageBox.Show("Please Select a Warehouse of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return false;
            }
            if (cmbDistance.SelectedIndex == 0 )
            {
                MessageBox.Show("Please Select a Distance Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDistance.Focus();
                return false;
            }
            if (cmbThana.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }
            if (ctlCustomer1.txtCode.Text== "")
            {
                MessageBox.Show("Please enter Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (cmbChannel.SelectedIndex == 0 )
            {
                MessageBox.Show("Please Select a Channel of the Showroom.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbChannel.Focus();
                return false;
            }

          

            #endregion

            return true;
        }
        public void ShowDialog(Showroom oShowroom)
        {
            _oChannels = new Channels();
            _oParentWarehouses = new ParentWarehouses();
            this.Tag = oShowroom;
            LoadCombo();
            int nShowroomType = oShowroom.ShowroomType;
            txtCode.Text = oShowroom.ShowroomCode;
            txtName.Text = oShowroom.ShowroomName;
            cmbShowroomType.SelectedIndex = oShowroom.ShowroomType;            
            txtAdress.Text = oShowroom.ShowroomAddress;
            txtCustomerTelephone.Text = oShowroom.Telephone;
            txtEmail.Text = oShowroom.Email;
            cmbWarehouse.SelectedIndex = _oParentWarehouses.GetIndex(oShowroom.WarehouseID) + 1;
            cmbDistrict.Text = oShowroom.District;
            cmbThana.Text = oShowroom.Thana;
            cmbLocation.Text= oShowroom.LocationName;
            if (oShowroom.IsActive == true)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;

            }
            cmbDistance.SelectedIndex = oShowroom.DistanceType;
            Customer oCustomer = new Customer();
            oCustomer.CustomerID = oShowroom.CustomerID;
            oCustomer.refresh();
            ctlCustomer1.txtCode.Text = oCustomer.CustomerCode.ToString();
            cmbChannel.SelectedIndex = _oChannels.GetIndex(oShowroom.ChannelID) + 1;
            txtCellPhoneNumber.Text = oShowroom.MobileNo;
            if (oShowroom.IsPOSActive == 1)
            {
                chkIsPOSActive.Checked = true;
            }
            else
            {
                chkIsPOSActive.Checked = false;

            }

            this.ShowDialog();
        }
        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCustomer1_Load(object sender, EventArgs e)
        {

        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
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
            DBController.Instance.BeginNewTransaction();
            _oGeoLocationsThana.GetThana(nDistrictID);
            DBController.Instance.CommitTransaction();
            cmbThana.Items.Add("---Select Thana---");
            foreach (GeoLocation oGeoLocation in _oGeoLocationsThana)
            {
                cmbThana.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbThana.SelectedIndex = 0;
        }
    }
}