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
    public partial class frmTDDeliveryShipmentsHO : Form
    {
        Channels _oChannels;
        MarketGroups _oMarketGroupArea;
        MarketGroups _oMarketGroupTerritory;
        GeoLocations _oGeoLocationDistrict;
        GeoLocations _oGeoLocationsThana;
        Companys _oCompanys;
        Showrooms oShowrooms;

        bool IsCheck = false;

        TDDeliveryShipments _oTDDeliveryShipments;

        public frmTDDeliveryShipmentsHO()
        {
            InitializeComponent();
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oTDDeliveryShipments = new TDDeliveryShipments();
            lvwTDShipment.Items.Clear();
            int nSalesType = 0;
            if (cmbChannel.SelectedIndex == 0)
            {
                nSalesType = -1;
            }
            else
            {
                nSalesType = cmbChannel.SelectedIndex;
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

            int nArea = 0;
            if (cmbArea.SelectedIndex == 0)
            {
                nArea = -1;
            }
            else
            {
                nArea = _oMarketGroupArea[cmbArea.SelectedIndex - 1].MarketGroupID;
            }

            int IsHOShipment = 0;
            if (cmbIsHOShipment.SelectedIndex == 0)
            {
                IsHOShipment = -1;
            }
            else
            {
                IsHOShipment = cmbIsHOShipment.SelectedIndex - 1;
            }
            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            DBController.Instance.OpenNewConnection();
            _oTDDeliveryShipments.GetTDShipmentDataHo(dtFromDate.Value.Date, dtToDate.Value.Date, nSalesType, nThana, nDistrict, nTerritory, nArea, IsHOShipment, cmbShowroom.Text, nStatus, txtInvoiceNo.Text.Trim(), txtCustomerName.Text.Trim(), txtMobileNo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (TDDeliveryShipment oTDDeliveryShipment in _oTDDeliveryShipments)
            {
                ListViewItem oItem = lvwTDShipment.Items.Add(oTDDeliveryShipment.ShipmentID.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oTDDeliveryShipment.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), oTDDeliveryShipment.SalesType));
                oItem.SubItems.Add(oTDDeliveryShipment.InvoiceNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oTDDeliveryShipment.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oTDDeliveryShipment.ShowroomCode.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.ConsumerName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.CellNo.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.Address.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.ThanaName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.DistrictName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.TerritoryName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.AreaName.ToString());
                TELLib _oTELLib = new TELLib();
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.InvoiceAmount).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.Discount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TDDeliveryShipmentStatus), oTDDeliveryShipment.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oTDDeliveryShipment.IsHOShipment));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.FreightCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.LiftingCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.ApprovedFreightCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.ApprovedLiftingCost).ToString());
                oItem.Tag = oTDDeliveryShipment;
            }
            SetListViewRowColour();
            this.Text = "TD Delivery Shipment [" + _oTDDeliveryShipments.Count + "]";
            this.Cursor = Cursors.Default;

        }
        public void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;
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

            /*********Select Showroom***********/
            oShowrooms = new Showrooms();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            oShowrooms.GetAllShowroom();
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            /************Channel****************/
            cmbChannel.Items.Clear();
            cmbChannel.Items.Add("<All>");
            //Sales Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbChannel.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbChannel.SelectedIndex = 0;


            /************Status****************/
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.TDDeliveryShipmentStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.TDDeliveryShipmentStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


            /************IS HO Shipment****************/
            cmbIsHOShipment.Items.Clear();
            cmbIsHOShipment.Items.Add("<All>");
            //IsHOShipment
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsHOShipment.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsHOShipment.SelectedIndex = 0;

        }

        private void SetListViewRowColour()
        {
            if (lvwTDShipment.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwTDShipment.Items)
                {
                    if (oItem.SubItems[15].Text == "Undelivered")
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else if (oItem.SubItems[15].Text == "Processing_Delivery")
                    {
                        oItem.BackColor = Color.LightCyan;
                    }
                    else if (oItem.SubItems[15].Text == "Delivered")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
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

        private void btnGo_Click_1(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmTDDeliveryShipmentsHO_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddShipment_Click(object sender, EventArgs e)
        {
            if (lvwTDShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a invoice to processing delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TDDeliveryShipment oTDDeliveryShipment = (TDDeliveryShipment)lvwTDShipment.SelectedItems[0].Tag;
            if (oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Undelivered || oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery)
            {
                frmTDDeliveryShipmentHO oForm = new frmTDDeliveryShipmentHO((int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery);
                //oForm.MdiParent = this;
                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.WindowState = FormWindowState.Maximized;
                oForm.ShowDialog(oTDDeliveryShipment);




                if (oForm._ISLoad == true)
                {
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Only undelivered/processing delivery status can be processing delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDeliveryInvoice_Click(object sender, EventArgs e)
        {
            if (lvwTDShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a invoice to processing delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TDDeliveryShipment oTDDeliveryShipment = (TDDeliveryShipment)lvwTDShipment.SelectedItems[0].Tag;
            if (oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery|| oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Delivered)
            {
                frmTDDeliveryShipmentHO oForm = new frmTDDeliveryShipmentHO((int)Dictionary.TDDeliveryShipmentStatus.Delivered);
               // oForm.MdiParent = this;
                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.WindowState = FormWindowState.Maximized;
                oForm.ShowDialog(oTDDeliveryShipment);
                if (oForm._ISLoad == true)
                {
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Only processing delivery status can be delivered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnBillApprove_Click(object sender, EventArgs e)
        {
            if (lvwTDShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a invoice to processing delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TDDeliveryShipment oTDDeliveryShipment = (TDDeliveryShipment)lvwTDShipment.SelectedItems[0].Tag;
            if (oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Delivered)
            {
                frmTDDeliveryShipmentHO oForm = new frmTDDeliveryShipmentHO((int)Dictionary.TDDeliveryShipmentStatus.Bill_Approved);
               // oForm.MdiParent = this;
                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.WindowState = FormWindowState.Maximized;
                oForm.ShowDialog(oTDDeliveryShipment);
                if (oForm._ISLoad == true)
                {
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Only deliverded status can be bill approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmTDDeliveryShipmentHOBill ofrmTDDeliveryShipmentHOBill = new frmTDDeliveryShipmentHOBill();
            ofrmTDDeliveryShipmentHOBill.ShowDialog();
        }
    }
}
