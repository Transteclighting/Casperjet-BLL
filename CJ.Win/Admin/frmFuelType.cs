using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Admin;

namespace CJ.Win.Admin
{
    public partial class frmFuelType : Form
    {
        public frmFuelType()
        {
            InitializeComponent();
        }

        public void ShowDialog(VehicleFuelType oVehicleFuelType)
        {
            this.Tag = oVehicleFuelType;
            txtName.Text = oVehicleFuelType.FuelTypeName;
            txtPrice.Text =Convert.ToDouble(oVehicleFuelType.UnitPrice).ToString();
            txtUnitName.Text = oVehicleFuelType.UnitName;                     
            this.ShowDialog();
        }

       
        private void frmFuelType_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) this.Text = "Add New Name";
            else this.Text = "Edit Nane";

        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtName.Text== "")
            {
                MessageBox.Show("Please enter Name of Fuel Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtPrice.Text== "")
            {
                MessageBox.Show("Please enter Unit Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            if ( txtUnitName.Text== "")
            {
                MessageBox.Show("Please enter Unit Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return false;
            }

            #endregion
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                VehicleFuelType oVehicleFuelType = new VehicleFuelType();
                oVehicleFuelType.FuelTypeName = txtName.Text;
                oVehicleFuelType.UnitPrice = Convert.ToDouble(txtPrice.Text);
                oVehicleFuelType.UnitName =txtUnitName.Text;                 
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleFuelType.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oVehicleFuelType.FuelTypeName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                VehicleFuelType oVehicleFuelType = (VehicleFuelType)this.Tag;
                oVehicleFuelType.FuelTypeName = txtName.Text;
                oVehicleFuelType.UnitPrice = Convert.ToDouble(txtPrice.Text);
                oVehicleFuelType.UnitName = txtUnitName.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleFuelType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Name : " + oVehicleFuelType.FuelTypeName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}