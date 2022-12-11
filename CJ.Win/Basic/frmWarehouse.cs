// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: Apr 25, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouse.
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Class.POS;

namespace CJ.Win.Basic
{
    public partial class frmWarehouse : Form
    {
        Warehouse _oWarehouse;
        Warehouses _oWarehouses;
        ParentWarehouses _oParentWarehouses;
        GeoLocations _oGeoLocations;
        JobLocations _oJobLocations;
        Channels _oChannels;

        public frmWarehouse()
        {
            _oWarehouses = new Warehouses();
            _oWarehouse = new Warehouse();

            InitializeComponent();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Warehouse";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Warehouse";
            }
            //rdbtnActive.Visible = false;
        }

        private void LoadThana()
        {
            int nDistrictID = Convert.ToInt32(cmbDistrict.SelectedIndex);
            _oGeoLocations = new GeoLocations();
            cmbThana.Items.Clear();
            _oGeoLocations.GetThana(nDistrictID);
            cmbThana.Items.Add("--Select Thana--");
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbThana.Items.Add(oGeoLocation.GeoLocationName);
            }
        }

        private void LoadCombo()
        {
            /************Load WarehouseType************/
            cmbType.Items.Add("--Select Warehouse Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.WarehouseType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.WarehouseType), GetEnum));
            }
            cmbType.SelectedIndex = 0;

            /********Load Channel********************/
            _oChannels = new Channels();
            _oChannels.Refresh();
            cmbChannel.Items.Add("--Select Channel--");
            foreach (Channel oChannel in _oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = 0;

            /*********Load Stock********************/
            cmbStockType.Items.Add("--Select Stock Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.WareHouseStockType)))
            {
                cmbStockType.Items.Add(Enum.GetName(typeof(Dictionary.WareHouseStockType), GetEnum));
            }
            cmbStockType.SelectedIndex = 0;

            /************Load Parent Warehouse************/
            _oParentWarehouses = new ParentWarehouses();
            _oParentWarehouses.Refresh();
            cmbParent.Items.Add("--Select Parent Warehouse--");
            foreach (ParentWarehouse oParentWarehouse in _oParentWarehouses)
            {
                cmbParent.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbParent.SelectedIndex = 0;

            /*********Load District************************/
            _oGeoLocations = new GeoLocations();
            _oGeoLocations.Refresh((int)Dictionary.GeoLocationType.District);
            cmbDistrict.Items.Add("--Select Geo Location--");
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

            /***********Load Location****************/
            _oJobLocations = new JobLocations();
            _oJobLocations.Refresh();
            cmbLocation.Items.Add("--Select Job Location--");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbLocation.Items.Add(oJobLocation.JobLocationName);
            }
            cmbLocation.SelectedIndex = 0;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThana();
            //cmbThana.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                _oWarehouse.WarehouseCode = txtCode.Text;
                _oWarehouse.WarehouseName = txtName.Text;
                _oWarehouse.WarehouseParentID = _oParentWarehouses[cmbParent.SelectedIndex - 1].WarehouseParentID;
                _oWarehouse.StockType = cmbStockType.SelectedIndex;
                if (chkActive.Checked == true)
                {
                    _oWarehouse.IsActive = 1;
                }
                else
                {
                    _oWarehouse.IsActive = 0;
                }
                //_oWarehouse.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                _oWarehouse.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;
                _oWarehouse.WarehouseType = cmbType.SelectedIndex;
                _oWarehouse.ThanaID = _oGeoLocations[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oWarehouse.ViewPosition = Convert.ToInt32(txtViewPosition.Text);
                _oWarehouse.Remark = txtRemark.Text.Trim();
                _oWarehouse.LocationID = _oJobLocations[cmbLocation.SelectedIndex - 1].JobLocationID;
                _oWarehouse.Shortcode = txtSortCode.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oWarehouse.Add();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_Warehouse";
                        oDataTran.DataID = Convert.ToInt32(_oWarehouse.WarehouseID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oWarehouse.WarehouseCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                int nIsActive = 0;
                _oWarehouse = (Warehouse)this.Tag;
                _oWarehouse.WarehouseCode = txtCode.Text;
                _oWarehouse.WarehouseName = txtName.Text;
                _oWarehouse.WarehouseParentID = _oParentWarehouses[cmbParent.SelectedIndex - 1].WarehouseParentID;
                _oWarehouse.StockType = cmbStockType.SelectedIndex;
                if (nIsActive == (int)Dictionary.YesOrNoStatus.NO)
                {
                    _oWarehouse.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                else
                {
                    _oWarehouse.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                _oWarehouse.ChannelID = _oChannels[cmbChannel.SelectedIndex - 1].ChannelID;
                _oWarehouse.WarehouseType = cmbType.SelectedIndex;
                _oWarehouse.ThanaID = _oGeoLocations[cmbThana.SelectedIndex - 1].GeoLocationID;
                _oWarehouse.ViewPosition = Convert.ToInt32(txtViewPosition.Text);
                _oWarehouse.Remark = txtRemark.Text.Trim();
                _oWarehouse.LocationID = _oJobLocations[cmbLocation.SelectedIndex - 1].JobLocationID;
                _oWarehouse.Shortcode = txtSortCode.Text.Trim();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oWarehouse.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oWarehouse.WarehouseCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateUI()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Code of Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Name of Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (cmbThana.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Thana Name for Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }

            return true;
        }

        public void ShowDialog(Warehouse oWarehouse)
        {
            _oChannels = new Channels();
            _oJobLocations = new JobLocations();
            _oGeoLocations = new GeoLocations();
            _oParentWarehouses = new ParentWarehouses();
            this.Tag = oWarehouse;
            LoadCombo();
            txtCode.Text = oWarehouse.WarehouseCode;
            txtName.Text = oWarehouse.WarehouseName;
            cmbParent.SelectedIndex = _oParentWarehouses.GetIndex(oWarehouse.WarehouseParentID) + 1;
            cmbStockType.SelectedIndex = oWarehouse.StockType;
            if (oWarehouse.IsActive == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
            cmbChannel.SelectedIndex = _oChannels.GetIndex(oWarehouse.ChannelID) + 1;
            cmbType.SelectedIndex = oWarehouse.WarehouseType + 1;
            cmbThana.SelectedIndex = _oGeoLocations.GetIndexByID(oWarehouse.ThanaID) + 1;
            txtRemark.Text = oWarehouse.Remark;
            cmbLocation.SelectedIndex = _oJobLocations.GetIndex(oWarehouse.LocationID) + 1;
            txtSortCode.Text = oWarehouse.Shortcode;
            txtViewPosition.Text = oWarehouse.ViewPosition.ToString();
            this.ShowDialog();
        }
    }
}