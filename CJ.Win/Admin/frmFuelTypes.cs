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
    public partial class frmFuelTypes : Form
    {
        public frmFuelTypes()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            VehicleFuelTypes oVehicleFuelTypes = new VehicleFuelTypes();
            lvwFuelType.Items.Clear();          
            DBController.Instance.OpenNewConnection();
            oVehicleFuelTypes.Refresh();
            this.Text = " VehicleFuelTypes " + "[" + oVehicleFuelTypes.Count + "]";
            foreach (VehicleFuelType oVehicleFuelType in oVehicleFuelTypes)
            {
                ListViewItem oItem = lvwFuelType.Items.Add(oVehicleFuelType.FuelTypeName);
                oItem.SubItems.Add(oVehicleFuelType.UnitPrice.ToString("#,##,##,##.00"));
                oItem.SubItems.Add(oVehicleFuelType.UnitName);
                oItem.Tag = oVehicleFuelType;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFuelType oFrom = new frmFuelType();          
            oFrom.ShowDialog();
            DataLoadControl();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            
            if (lvwFuelType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Fuel Type Name to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleFuelType oVehicleFuelType = (VehicleFuelType)lvwFuelType.SelectedItems[0].Tag;
            frmFuelType oForm = new frmFuelType();
            oForm.ShowDialog(oVehicleFuelType);
            DataLoadControl();  
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwFuelType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an  Fuel type Name to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            VehicleFuelType oVehicleFuelType = (VehicleFuelType)lvwFuelType.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to Delete Fuel Type Name: " + oVehicleFuelType.FuelTypeName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleFuelType.Delete();
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

        private void frmFuelTypes_Load(object sender, EventArgs e)
        {
            DataLoadControl();

        }
    }
}