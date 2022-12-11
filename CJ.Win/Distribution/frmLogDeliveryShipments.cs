using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.Distribution
{
    public partial class frmLogDeliveryShipments : Form
    {
        Channels _oChannels;
        MarketGroups _oMarketGroupArea;
        MarketGroups _oMarketGroupTerritory;
        GeoLocations _oGeoLocationDistrict;
        GeoLocations _oGeoLocationsThana;
        Companys _oCompanys;

        bool IsCheck = false;
        ShipmentVehicles _oShipmentVehicles;
        ShipmentVehicles _oLogShipmentVehicles;
        ShipmentVehicle _oShipmentVehicle;
        Vehicles _oVendors;
        public frmLogDeliveryShipments()
        {
            InitializeComponent();
        }

        public void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            cmbTranType.Items.Clear();
            cmbTranType.Items.Add("<All>");
            //Shipment Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DeliveryShipmentTranType)))
            {
                cmbTranType.Items.Add(Enum.GetName(typeof(Dictionary.DeliveryShipmentTranType), GetEnum));
            }
            cmbTranType.SelectedIndex = 0;

            /************Company****************/
            _oCompanys = new Companys();
            cmbCompany.Items.Clear();
            _oCompanys.RefreshByCompany(Utility.CompanyInfo);
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyCode);
            }
            cmbCompany.SelectedIndex = 0;

            //Delivery Mode
            cmbDeliveryMode.Items.Clear();
            cmbDeliveryMode.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LogDeliveryShipmentDeliveryMode)))
            {
                cmbDeliveryMode.Items.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), GetEnum));
            }
            cmbDeliveryMode.SelectedIndex = 0;


            LoadComboAll();

        }

        public void LoadComboAll()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            /*************Market Area***********/
            _oMarketGroupArea = new MarketGroups();
            cmbArea.Items.Clear();
            _oMarketGroupArea.Refresh((int)Dictionary.MarketGroupType.Area);
            cmbArea.Items.Add("<All>");
            foreach (MarketGroup oMarketGroup in _oMarketGroupArea)
            {
                cmbArea.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbArea.SelectedIndex = 0;

            /*************Market Territory***********/
            _oMarketGroupTerritory = new MarketGroups();
            cmbTerritory.Items.Clear();
            _oMarketGroupTerritory.Refresh((int)Dictionary.MarketGroupType.Territory);
            cmbTerritory.Items.Add("<All>");
            foreach (MarketGroup oMarketGroup in _oMarketGroupTerritory)
            {
                cmbTerritory.Items.Add(oMarketGroup.MarketGroupDesc);
            }
            cmbTerritory.SelectedIndex = 0;

            ///Thana
            _oGeoLocationsThana = new GeoLocations();
            _oGeoLocationsThana.Refresh((int)Dictionary.GeoLocationType.Thana);
            cmbThana.Items.Clear();
            cmbThana.Items.Add("<All>");
            foreach (GeoLocation oGeoLocation in _oGeoLocationsThana)
            {
                cmbThana.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbThana.SelectedIndex = 0;

            /*********Select District***********/
            _oGeoLocationDistrict = new GeoLocations();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("<All>");
            _oGeoLocationDistrict.Refresh((int)Dictionary.GeoLocationType.District);
            foreach (GeoLocation oGeoLocation in _oGeoLocationDistrict)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

            /************Channel****************/
            _oChannels = new Channels();
            cmbChannel.Items.Clear();
            _oChannels.Refresh();
            cmbChannel.Items.Add("<All>");
            foreach (Channel oChannel in _oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = 0;
        }

        private void frmLogDeliveryShipments_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oShipmentVehicles = new ShipmentVehicles();
            lvwDeliveryShipment.Items.Clear();
            
            
            int nVendor = 0;
            if (cmbVendor.SelectedIndex == 0)
            {
                nVendor = -1;
            }
            else
            {
                nVendor = _oVendors[cmbVendor.SelectedIndex - 1].VendorID;
            }
            int nArea = 0;
            if (cmbArea.SelectedIndex == 0)
            {
                nArea = -1;
            }
            else
            {
                nArea = _oMarketGroupArea[cmbArea.SelectedIndex - 1].MarketGroupID;
            }
            int nDistrict = 0;
            if (cmbDistrict.SelectedIndex == 0)
            {
                nDistrict = -1;
            }
            else
            {
                nDistrict = _oGeoLocationDistrict[cmbDistrict.SelectedIndex - 1].GeoLocationID;
            }

            int nTerritory = 0;
            if (cmbTerritory.SelectedIndex == 0)
            {
                nTerritory = -1;
            }
            else
            {
                nTerritory = _oMarketGroupTerritory[cmbTerritory.SelectedIndex - 1].MarketGroupID;
            }
            int nThana = 0;
            if (cmbThana.SelectedIndex == 0)
            {
                nThana = -1;
            }
            else
            {
                nThana = _oGeoLocationsThana[cmbThana.SelectedIndex - 1].GeoLocationID;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oShipmentVehicles.GetLogDeliveryShipmentData(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text.Trim(), txtVehicleNo.Text.Trim(), nVendor, txtCustomer.Text.Trim(), cmbTranType.Text.Trim(), cmbCompany.Text.Trim(), cmbChannel.Text.Trim(), nArea, nDistrict, nTerritory, nThana, IsCheck, cmbDeliveryMode.SelectedIndex,txtGatePassNo.Text);
            DBController.Instance.CloseConnection();

            foreach (ShipmentVehicle oShipmentVehicle in _oShipmentVehicles)
            {
                ListViewItem oItem = lvwDeliveryShipment.Items.Add(oShipmentVehicle.FromWHName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.TType.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), oShipmentVehicle.DeliveryMode));
                if (oShipmentVehicle.ParcelType == 0)
                {
                    oItem.SubItems.Add("N/A");
                }
                else
                {
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), oShipmentVehicle.ParcelType));
                }
                oItem.SubItems.Add(oShipmentVehicle.VendorName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.VehicleNo.ToString());
                oItem.SubItems.Add(oShipmentVehicle.VehicleCapacity.ToString());
                oItem.SubItems.Add(oShipmentVehicle.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oShipmentVehicle.CustomerCode.ToString());
                oItem.SubItems.Add(oShipmentVehicle.CustomerName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.AreaName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.TerritoryName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.ThanaName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.DistrictName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.Channel.ToString());
                TELLib _oTELLib = new TELLib();
                oItem.SubItems.Add(_oTELLib.TakaFormat(oShipmentVehicle.TranAmount).ToString());
                oItem.SubItems.Add(oShipmentVehicle.GatePassNo.ToString());
                oItem.Tag = oShipmentVehicle;
            }
            this.Text = "Log Delivery Shipments [" + _oShipmentVehicles.Count + "]";
            this.Cursor = Cursors.Default;
            ;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sGatePassNo = "";
            int nCount = 0;
            for (int i = 0; i < lvwDeliveryShipment.Items.Count; i++)
            {
                ListViewItem itm = lvwDeliveryShipment.Items[i];
                if (lvwDeliveryShipment.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Checked at least one Transaction", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                _oLogShipmentVehicles = new ShipmentVehicles();
                for (int i = 0; i < lvwDeliveryShipment.Items.Count; i++)
                {
                    if (lvwDeliveryShipment.Items[i].Checked == true)
                    {
                        _oShipmentVehicle = new ShipmentVehicle();
                        _oShipmentVehicle = (ShipmentVehicle)lvwDeliveryShipment.Items[i].Tag;
                        if (sGatePassNo == "")
                        {
                            sGatePassNo = _oShipmentVehicle.GatePassNo;
                        }
                        else
                        {
                            if (!sGatePassNo.Contains(_oShipmentVehicle.GatePassNo))
                                sGatePassNo = sGatePassNo + "," + _oShipmentVehicle.GatePassNo;
                        }
                        _oLogShipmentVehicles.Add(_oShipmentVehicle);
                    }
                }
                frmLogDeliveryShipment oForm = new frmLogDeliveryShipment(1);
                oForm.ShowDialog(_oLogShipmentVehicles, sGatePassNo);
                if (oForm._IsTrue == true)
                {
                    DataLoadControl();
                }
            }
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btSelectAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwDeliveryShipment.Items.Count; i++)
                {

                    ListViewItem itm = lvwDeliveryShipment.Items[i];
                    lvwDeliveryShipment.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwDeliveryShipment.Items.Count; i++)
                {
                    ListViewItem itm = lvwDeliveryShipment.Items[i];
                    lvwDeliveryShipment.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Checked All";
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmLogDeliveryShipmentList oForm = new frmLogDeliveryShipmentList();
            oForm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDeliveryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeliveryMode.SelectedIndex == 0)
            {
                //Vehicle
                cmbVendor.Items.Clear();
                cmbVendor.Items.Add("<All>");
                cmbVendor.SelectedIndex = 0;
            }
            else
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                //Vendor
                _oVendors = new Vehicles();
                _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Direct_Vendor, cmbDeliveryMode.SelectedIndex);
                cmbVendor.Items.Clear();
                cmbVendor.Items.Add("Select Vendor.....");
                foreach (Vehicle oVendor in _oVendors)
                {
                    cmbVendor.Items.Add(oVendor.VendorName);
                }
                cmbVendor.SelectedIndex = 0;

            }
        }

        private void btnReceiveDateUpdate_Click(object sender, EventArgs e)
        {
            frmLogDeliveryShipmentDateUpdate oFrom = new frmLogDeliveryShipmentDateUpdate();
            oFrom.ShowDialog();
        }
    }
}