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
    public partial class frmVehicleDriver : Form
    {
        public frmVehicleDriver()
        {
            InitializeComponent();
        }


        public void ShowDialog(VehicleDriver oVehicleDriver)
        {
            this.Tag = oVehicleDriver;

            txtCode.Text = oVehicleDriver.VehicleDriverCode;
            txtName.Text = oVehicleDriver.VehicleDriverName ;
            if (!string.IsNullOrWhiteSpace(oVehicleDriver.MobileNo))
            {
                txtMobileNo.Text = oVehicleDriver.MobileNo;
            }
            
            this.ShowDialog();
        }

        private void frmVehicleDriver_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) this.Text = "Add New Name";
            else this.Text = "Edit Nane";
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Code of Driver", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Name of Driver", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtMobileNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter mobile no. of Driver", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
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
                VehicleDriver oVehicleDriver = new VehicleDriver();

                oVehicleDriver.VehicleDriverCode = txtCode.Text;
                oVehicleDriver.VehicleDriverName = txtName.Text;
                oVehicleDriver.MobileNo = txtMobileNo.Text;
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleDriver.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " +  oVehicleDriver.VehicleDriverCode , "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                VehicleDriver oVehicleDriver = (VehicleDriver)this.Tag;

                oVehicleDriver.VehicleDriverCode = txtCode.Text;
                oVehicleDriver.VehicleDriverName = txtName.Text;
                oVehicleDriver.MobileNo = txtMobileNo.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleDriver.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Name : " + oVehicleDriver.VehicleDriverCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Close();
        }

        
    }
}