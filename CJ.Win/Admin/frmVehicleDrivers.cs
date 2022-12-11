using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using CJ.Class.Admin;

namespace CJ.Win.Admin
{
    public partial class frmVehicleDrivers : Form
    {
        public frmVehicleDrivers()
        {
            InitializeComponent();
        }

       

        private void DataLoadControl()
        {
            VehicleDrivers oVehicleDrivers = new VehicleDrivers();
            lvwVehicleDriver.Items.Clear();                   
            DBController.Instance.OpenNewConnection();
            oVehicleDrivers.Refresh(txtCode.Text.Trim(),txtName.Text.Trim(), txtMobileNo.Text.Trim());
            this.Text = " VehicleDriver " + "[" + oVehicleDrivers.Count + "]";
            foreach (VehicleDriver oVehicleDriver in oVehicleDrivers)
            {
                ListViewItem oItem = lvwVehicleDriver.Items.Add(oVehicleDriver.VehicleDriverCode);
                oItem.SubItems.Add(oVehicleDriver.VehicleDriverName);
                oItem.SubItems.Add(oVehicleDriver.MobileNo);
                oItem.Tag = oVehicleDriver;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVehicleDriver oForm = new frmVehicleDriver();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwVehicleDriver.SelectedItems.Count==0)
            {
                MessageBox.Show("Please Select an Driver Name to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleDriver oVehicleDriver = (VehicleDriver)lvwVehicleDriver.SelectedItems[0].Tag;
            frmVehicleDriver oForm = new frmVehicleDriver();
            oForm.ShowDialog(oVehicleDriver);                  
            DataLoadControl();         
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwVehicleDriver.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an  Driver Name to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleDriver oVehicleDriver = (VehicleDriver)lvwVehicleDriver.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to Delete Driver Name: " + oVehicleDriver.VehicleDriverCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleDriver.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
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

        private void frmVehicleDrivers_Load(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
        
        
}