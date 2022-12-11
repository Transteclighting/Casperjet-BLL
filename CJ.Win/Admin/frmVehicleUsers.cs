using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Admin;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmVehicleUsers : Form
    {
        public frmVehicleUsers()
        {
            InitializeComponent();
        }

        private void frmVehicleUsers_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            VehicleUsers oVehicleUsers = new VehicleUsers();
            lvwVehicleUsers.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oVehicleUsers.Refresh();
            this.Text = "VehicleUser " + "[" + oVehicleUsers.Count + "]";
            foreach (VehicleUser oVehicleUser in oVehicleUsers)
            {
                ListViewItem oItem = lvwVehicleUsers.Items.Add(oVehicleUser.VehicleUserName);
                oItem.SubItems.Add(oVehicleUser.Designation);
                oItem.SubItems.Add(oVehicleUser.MaxFuelLimit.ToString());
                oItem.SubItems.Add(oVehicleUser.MaxMaintenanceLimit.ToString());
                oItem.Tag = oVehicleUser;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVehicleUser oForm = new frmVehicleUser();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwVehicleUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an VehicleUser to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleUser oVehicleUser = (VehicleUser)lvwVehicleUsers.SelectedItems[0].Tag;
            frmVehicleUser oForm = new frmVehicleUser();
            oForm.ShowDialog(oVehicleUser);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //VehicleUsers oVehicleUsers = new VehicleUsers();
            //oVehicleUsers.Refresh();
            //rptVehicleUsers oReport = new rptVehicleUsers();
            //oReport.SetDataSource(oVehicleUsers);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwVehicleUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an VehicleUser to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleUser oVehicleUser = (VehicleUser)lvwVehicleUsers.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete VehicleUser: " + oVehicleUser.VehicleUserName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleUser.Delete();
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

        private void lvwVehicleUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}