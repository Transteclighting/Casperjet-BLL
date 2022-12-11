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
    public partial class frmLogDeliveryShipmentList : Form
    {
        ShipmentVehicles _oShipmentVehicles;
        Vehicles _oVehicles;
        bool IsCheck = false;
        ShipmentVehicle _oShipmentVehicle;

        public frmLogDeliveryShipmentList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataLoadControl()
        {
            _oShipmentVehicles = new ShipmentVehicles();
            lvwDeliveryShipmentList.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oShipmentVehicles.GetLogDeliveryShipmentList(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text.Trim(), txtGatePass.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ShipmentVehicle oShipmentVehicle in _oShipmentVehicles)
            {
                ListViewItem oItem = lvwDeliveryShipmentList.Items.Add(oShipmentVehicle.ShipmentNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oShipmentVehicle.ShipmentDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oShipmentVehicle.GatePassNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oShipmentVehicle.CreateDate).ToString("dd-MMM-yyyy"));
                TELLib _oTELLib = new TELLib();
                oItem.SubItems.Add(_oTELLib.TakaFormat(oShipmentVehicle.FreightCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oShipmentVehicle.LocalDeliveryCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oShipmentVehicle.ParcelCost).ToString());

                oItem.Tag = oShipmentVehicle;
            }
            this.Text = "Log Delivery Shipment List [" + _oShipmentVehicles.Count + "]";
        }

        //public void LoadCombos()
        //{
        //    DBController.Instance.OpenNewConnection();
        //    dtFromDate.Value = DateTime.Today;
        //    dtToDate.Value = DateTime.Today;

        //    //Vendor
        //    cmbVendor.Items.Clear();
        //    cmbVendor.Items.Add("<All>");
        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DeliveryShipmentVendor)))
        //    {
        //        cmbVendor.Items.Add(Enum.GetName(typeof(Dictionary.DeliveryShipmentVendor), GetEnum));
        //    }
        //    cmbVendor.SelectedIndex = 0;

        //    //Vehicle
        //    _oVehicles = new Vehicles();
        //    cmbVehicle.Items.Clear();
        //    cmbVehicle.Items.Add("<All>");
        //    _oVehicles.GetVehicle(82972);
        //    foreach (Vehicle oVehicle in _oVehicles)
        //    {
        //        cmbVehicle.Items.Add(oVehicle.VehicleName);
        //    }
        //    cmbVehicle.SelectedIndex = 0;
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwDeliveryShipmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShipmentVehicle oSV = (ShipmentVehicle)lvwDeliveryShipmentList.SelectedItems[0].Tag;
            frmLogDeliveryShipment oForm = new frmLogDeliveryShipment(2);
            oForm.ShowDialog(oSV);
            if (oForm._IsTrue == true)
            {
                DataLoadControl();
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmLogDeliveryShipmentList_Load(object sender, EventArgs e)
        {
            //LoadCombos();
            DataLoadControl();
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

    }
}