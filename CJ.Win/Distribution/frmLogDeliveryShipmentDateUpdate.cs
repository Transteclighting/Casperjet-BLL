using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.Distribution
{
    public partial class frmLogDeliveryShipmentDateUpdate : Form
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
        public bool _IsTrue = false;
        public frmLogDeliveryShipmentDateUpdate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private bool validateUIInput()
        {

            //foreach (DataGridViewRow oItemRow in dgvDeliveryShipment.Rows)
            //{
            //    if (oItemRow.Index < dgvDeliveryShipment.Rows.Count)
            //    {
            //        if (_nType == 1)
            //        {
            //            if (Convert.ToInt32(oItemRow.Cells[20].Value) == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
            //            {
            //                string sVendorP = "";
            //                try
            //                {
            //                    sVendorP = oItemRow.Cells[11].Value.ToString();
            //                }
            //                catch
            //                {
            //                    sVendorP = "";
            //                }
            //                if (sVendorP == "")
            //                {
            //                    MessageBox.Show("Please select parcel vendor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    dgvDeliveryShipment.Focus();
            //                    return false;
            //                }
            //            }

            //        }

            //    }
            //}

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    int nCount = 0;
                    foreach (DataGridViewRow oItemRow in dgvDeliveryShipment.Rows)
                    {
                        if (oItemRow.Index < dgvDeliveryShipment.Rows.Count)
                        {
                            LogDeliveryShipmentItem _oLogDeliveryShipmentItem = new LogDeliveryShipmentItem();
                            _oLogDeliveryShipmentItem.TranID = int.Parse(oItemRow.Cells[12].Value.ToString());
                            _oLogDeliveryShipmentItem.ShipmentID = int.Parse(oItemRow.Cells[13].Value.ToString());
                            if ((bool)oItemRow.Cells[9].Value == true)
                            {
                                _oLogDeliveryShipmentItem.ReceiveDate = Convert.ToDateTime(oItemRow.Cells[10].Value.ToString());
                                _oLogDeliveryShipmentItem.ReceiveTime = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString());
                                _oLogDeliveryShipmentItem.EditReceiveDate();
                                nCount++;
                            }
                           
                        }
                    }

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Update Log Shipment Data", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (nCount > 0)
                        DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;

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

            ShipmentVehicle oShipmentVehicle = new ShipmentVehicle();
            oShipmentVehicle.GetShipmentDataForDateEdit(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text.Trim(), txtVehicleNo.Text.Trim(), nVendor, txtCustomer.Text.Trim(), cmbTranType.Text.Trim(), cmbCompany.Text.Trim(), cmbChannel.Text.Trim(), nArea, nDistrict, nTerritory, nThana, cmbDeliveryMode.SelectedIndex);
            DBController.Instance.CloseConnection();


            dgvDeliveryShipment.Rows.Clear();
            foreach (LogDeliveryShipmentItem oItem in oShipmentVehicle)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDeliveryShipment);

                oRow.Cells[0].Value = oItem.CustomerName.ToString();
                oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), oItem.DeliveryMode);
                
                if (oItem.ParcelType == 0)
                {
                    oRow.Cells[2].Value = "N/A";
                }
                else
                {
                    oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), oItem.ParcelType);
                }
                oRow.Cells[3].Value = oItem.VendorName.ToString();
                oRow.Cells[4].Value = oItem.VehicleNo.ToString();
                oRow.Cells[5].Value = oItem.TranType.ToString();
                oRow.Cells[6].Value = oItem.TranNo;
                oRow.Cells[7].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                oRow.Cells[8].Value = oItem.ParcelVendorName;
                  if (oItem.ReceiveDate != null)
                {

                    oRow.Cells[9].Value = true;
                    oRow.Cells[10].Style.BackColor = Color.White;
                    oRow.Cells[11].Style.BackColor = Color.White;
                    oRow.Cells[10].ReadOnly = false;
                    oRow.Cells[11].ReadOnly = false;
                    oRow.Cells[10].Value = Convert.ToDateTime(oItem.ReceiveDate).ToString("dd-MMM-yyyy");
                    oRow.Cells[11].Value = Convert.ToDateTime(oItem.ReceiveTime).ToString("hh:mm tt");
                }
                else
                {
                    oRow.Cells[9].Value = false;
                    oRow.Cells[10].Style.BackColor = Color.LightGray;
                    oRow.Cells[11].Style.BackColor = Color.LightGray;
                    oRow.Cells[10].ReadOnly = true;
                    oRow.Cells[11].ReadOnly = true;
                    oRow.Cells[10].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                    oRow.Cells[11].Value = DateTime.Now.ToString("hh:mm tt");
                }

                oRow.Cells[12].Value = oItem.TranID.ToString();
                oRow.Cells[13].Value = oItem.ShipmentID.ToString();
                oRow.Cells[14].Value = oItem.ShipmentNo.ToString();

                dgvDeliveryShipment.Rows.Add(oRow);
            }

            this.Text = "Log Delivery Shipments [" + oShipmentVehicle.Count + "]";
            this.Cursor = Cursors.Default;
            
        }
        private void frmLogDeliveryShipmentDateUpdate_Load(object sender, EventArgs e)
        {
            LoadCombos();
            //DataLoadControl();
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

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvDeliveryShipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                this.dgvDeliveryShipment.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //Check the value of cell
                if ((bool)this.dgvDeliveryShipment.CurrentCell.Value == true)
                {
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[10].ReadOnly = false;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[11].ReadOnly = false;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.White;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.White;

                }
                else
                {
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[11].ReadOnly = true;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.LightGray;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.LightGray;

                }
            }
        }
    }
}
