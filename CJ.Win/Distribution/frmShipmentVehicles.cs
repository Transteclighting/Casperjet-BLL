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
    public partial class frmShipmentVehicles : Form
    {

        ShipmentVehicles _oShipmentVehicles;
        Vehicles _oVehicles;
        ShipmentRoutes _oRoutes;
        GeoLocations _oGeoLocations;
        public frmShipmentVehicles()
        {
            InitializeComponent();
        }

        private void frmShipmentVehicles_Load(object sender, EventArgs e)
        {
            _oVehicles = new Vehicles();
            _oVehicles.RefreshAll(string.Empty, string.Empty, string.Empty, -1, -1, "<All>");
            cboCompany.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            LoadCombos();
            LoadData();
        }

        private void LoadCombos()
        {

            //Company
            _oRoutes = new ShipmentRoutes();
            _oRoutes.Refersh();
            cboRoute.Items.Clear();
            cboRoute.Items.Add("<All>");
            foreach (ShipmentRoute oRoute in _oRoutes)
            {
                cboRoute.Items.Add(oRoute.RouteID);
            }
            cboRoute.SelectedIndex = 0;

            cmbShipment.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(ShipmentType)))
            {
                cmbShipment.Items.Add(Enum.GetName(typeof(ShipmentType), GetEnum));
            }
            cmbShipment.SelectedIndex = 0;

            _oGeoLocations = new GeoLocations();
            _oGeoLocations.GetDistrict();

            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("<All>");
            cmbDistrict.Items.Add("NA");
            foreach (GeoLocation oGeoLocation in _oGeoLocations)
            {
                cmbDistrict.Items.Add(oGeoLocation.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

        }

        public void LoadData()
        {

            Vehicle oVehicle;

            //int nCompanyID = 0;
            //if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            DBController.Instance.OpenNewConnection();
            _oShipmentVehicles = new ShipmentVehicles();

            object dDeliveryDate=null;
            if (dtpDeliveryDate.Checked) dDeliveryDate = dtpDeliveryDate.Value.Date;

            _oShipmentVehicles.Refersh(dtFromDate.Value.Date, dtToDate.Value.Date.AddDays(1.0), cboCompany.Text, cboType.Text, cboStatus.Text, dDeliveryDate, cboRoute.Text, txtTranNo.Text, cmbShipment.SelectedIndex - 1, cmbDistrict.Text);

            lvwOrderList.Items.Clear();
            foreach (ShipmentVehicle oShipmentVehicle in _oShipmentVehicles)
            {
                ListViewItem lstItem = lvwOrderList.Items.Add(oShipmentVehicle.Company);
                lstItem.SubItems.Add(oShipmentVehicle.Channel);
                lstItem.SubItems.Add(oShipmentVehicle.TType);
                lstItem.SubItems.Add(oShipmentVehicle.TranNo);
                lstItem.SubItems.Add(oShipmentVehicle.TranDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oShipmentVehicle.Destination);
                lstItem.SubItems.Add(oShipmentVehicle.TranStatus);
                lstItem.SubItems.Add(oShipmentVehicle.TranAmount.ToString("0.00"));
                lstItem.SubItems.Add(oShipmentVehicle.CostAmount.ToString("0.00"));
                
                if(oShipmentVehicle.DeliveryDate.ToString("dd-MMM-yyyy")=="01-Jan-0001")
                    lstItem.SubItems.Add("");
                else
                    lstItem.SubItems.Add(oShipmentVehicle.DeliveryDate.ToString("dd-MMM-yyyy"));

                lstItem.SubItems.Add(Enum.GetName(typeof(ShipmentType), oShipmentVehicle.ShipmentType));
                lstItem.SubItems.Add(oShipmentVehicle.RouteID.ToString());
                lstItem.SubItems.Add(oShipmentVehicle.DistrictName.ToString());
                if (oShipmentVehicle.VehicleID != null)
                {
                    oVehicle=_oVehicles[_oVehicles.GetIndex((int)oShipmentVehicle.VehicleID)];
                    lstItem.SubItems.Add(oVehicle.RegistrationNo);
                }
                else
                    lstItem.SubItems.Add("");
                
                
                lstItem.Tag = oShipmentVehicle;

            }
            setListViewRowColour();
            setSummary();
            this.Text = "Shipments: " + "[" + _oShipmentVehicles.Count + "]";
        }

        private void setListViewRowColour()
        {
            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[10].Text == "None")
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        oItem.BackColor = Color.FromArgb(192, 192, 255);
                    }
                }
            }
        }

        private void setSummary()
        {
            double nTEL=0;
            double nTML=0;
            double nBLL=0;

            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[0].Text == "TEL")
                    {
                        nTEL = nTEL + Convert.ToDouble(oItem.SubItems[8].Text);
                    }
                    else if (oItem.SubItems[0].Text == "TML")
                    {
                        nTML = nTML + Convert.ToDouble(oItem.SubItems[8].Text);
                    }
                    else if (oItem.SubItems[0].Text == "BLL")
                    {
                        nBLL = nBLL + Convert.ToDouble(oItem.SubItems[8].Text);
                    }

                }
                lblSummary.Text = "Summary: TEL (" + nTEL.ToString("0.00") + ") TML (" + nTML.ToString("0.00") + ") BLL (" + nBLL.ToString("0.00") + ")"; 
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lvwOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lvwOrderList.SelectedItems.Count != 0)
            //{
            //    if (lvwOrderList.SelectedItems[0].SubItems[10].Text == "None")
            //        btnAdd.Text = "Attach Vehicle";
            //    else
            //        btnAdd.Text = "Undo Attach";
            //}
        }

        private void AttachVehicle()
        {

            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Delivery Shipment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShipmentVehicle oShipmentVehicle = (ShipmentVehicle)lvwOrderList.SelectedItems[0].Tag;

            if (lvwOrderList.SelectedItems[0].SubItems[10].Text == "None")
            {
                frmShipmentVehicle oForm = new frmShipmentVehicle();
                oForm.ShowDialog(oShipmentVehicle);
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Undo Assign?", "Confirm Undo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oShipmentVehicle.Delete();
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    
                }
            }

            LoadData();
        }

        private void lvwOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AttachVehicle(); 
            }
        }

        private void lvwOrderList_DoubleClick(object sender, EventArgs e)
        {
            AttachVehicle(); 
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ShipmentVehicle oShipmentVehicle;
            foreach (ListViewItem oItem in lvwOrderList.Items)
            {
                oShipmentVehicle = (ShipmentVehicle)oItem.Tag; 
                //oShipmentVehicle.
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}