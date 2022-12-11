using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Admin;

namespace CJ.Win
{
    public partial class frmVehicleUser : Form
    {
        public frmVehicleUser()
        {
            InitializeComponent();
        }


        public void ShowDialog(VehicleUser oVehicleUser)
        {
            this.Tag = oVehicleUser;

            txtName.Text = oVehicleUser.VehicleUserName;
            txtDesignation.Text = oVehicleUser.Designation;
            txtMaxFuelLimit.Text = oVehicleUser.MaxFuelLimit.ToString();
            txtMaxMaintenanceLimit.Text = oVehicleUser.MaxMaintenanceLimit.ToString();
            dateTimePiJoiningDate.Value = Convert.ToDateTime(oVehicleUser.JoiningDate);           
            this.ShowDialog();
        }

        private void frmVehicleUser_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) this.Text = "Add New VehicleUser";
            else this.Text = "Edit VehicleUser";
            
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name of VehicleUser", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtDesignation.Text == "")
            {
                MessageBox.Show("Please enter Designation of VehicleUser", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesignation.Focus();
                return false;
            }

            if (txtMaxFuelLimit.Text == "")
            {
                MessageBox.Show("Please enter Max Fuel Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxFuelLimit.Focus();
                return false;
            }

            if ( txtMaxMaintenanceLimit.Text == "")
            {
                MessageBox.Show("Please enter Max Maintenance Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxMaintenanceLimit.Focus();
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
                VehicleUser oVehicleUser = new VehicleUser();
                oVehicleUser.VehicleUserName = txtName.Text;
                oVehicleUser.Designation = txtDesignation.Text;
                oVehicleUser.MaxFuelLimit = Convert.ToDouble(txtMaxFuelLimit.Text);
                oVehicleUser.MaxMaintenanceLimit = Convert.ToDouble(txtMaxMaintenanceLimit.Text);
                oVehicleUser.JoiningDate = Convert.ToDateTime(dateTimePiJoiningDate.Value);
               
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleUser.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oVehicleUser.VehicleUserName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                VehicleUser oVehicleUser = (VehicleUser)this.Tag;

                oVehicleUser.VehicleUserName = txtName.Text;
                oVehicleUser.Designation = txtDesignation.Text;
                oVehicleUser.MaxFuelLimit = Convert.ToDouble(txtMaxFuelLimit.Text);
                oVehicleUser.MaxMaintenanceLimit = Convert.ToDouble(txtMaxMaintenanceLimit.Text);
                oVehicleUser.JoiningDate = Convert.ToDateTime(dateTimePiJoiningDate.Value);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleUser.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The VehicleUser : " + oVehicleUser.VehicleUserName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}