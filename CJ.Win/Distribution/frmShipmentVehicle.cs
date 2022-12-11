using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Admin;

namespace CJ.Win.Distribution
{
    public partial class frmShipmentVehicle : Form
    {
        Vehicles _oVehicles;

        public frmShipmentVehicle()
        {
            InitializeComponent();
        }

        public void ShowDialog(ShipmentVehicle oShipmentVehicle)
        {
            this.Tag = oShipmentVehicle;
            this.ShowDialog();
        }

        private void frmShipmentVehicle_Load(object sender, EventArgs e)
        {
            _oVehicles = new Vehicles();
            _oVehicles.Refresh();

            foreach (Vehicle oVehicle in _oVehicles)
            {
                cmbVehicle.Items.Add(oVehicle.RegistrationNo);

            }
            if (_oVehicles.Count > 0)
            {
                cmbVehicle.SelectedIndex = _oVehicles.Count - 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                ShipmentVehicle oShipmentVehicle = (ShipmentVehicle)this.Tag;
                
                if (rdoLog.Checked)
                {
                    oShipmentVehicle.ShipmentType = ShipmentType.LogVehicle;
                    oShipmentVehicle.VehicleID = _oVehicles[cmbVehicle.SelectedIndex].VehicleID;
                }
                else if (rdoParcel.Checked)
                    oShipmentVehicle.ShipmentType = ShipmentType.Parcel;
                else if (rdoRent.Checked)
                    oShipmentVehicle.ShipmentType = ShipmentType.RentVehicle;
                else if (rdoSelf.Checked)
                    oShipmentVehicle.ShipmentType = ShipmentType.Self;

                oShipmentVehicle.EntryDate = DateTime.Today;
                //oShipmentVehicle.
                

                try
                {
                    if (oShipmentVehicle.RouteID != 0)
                    {
                        DBController.Instance.BeginNewTransaction();
                        oShipmentVehicle.Insert(); 
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Vehicle : ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please set Route map", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoParcel_CheckedChanged(object sender, EventArgs e)
        {
            RadioSetting();
        }

        private void rdoLog_CheckedChanged(object sender, EventArgs e)
        {
            RadioSetting();
        }

        private void rdoRent_CheckedChanged(object sender, EventArgs e)
        {
            RadioSetting();
        }

        private void rdoSelf_CheckedChanged(object sender, EventArgs e)
        {
            RadioSetting();
        }

        private void RadioSetting()
        {
            cmbVehicle.Enabled = rdoLog.Checked;
        }
    }
}