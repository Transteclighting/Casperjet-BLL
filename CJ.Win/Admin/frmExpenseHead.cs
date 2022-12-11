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
    public partial class frmExpenseHead : Form
    {
        public frmExpenseHead()
        {
            InitializeComponent();
        }

        public void ShowDialog(VehicleExpenseHead oVehicleExpenseHead)
        {
            this.Tag = oVehicleExpenseHead;
            txtCode.Text = oVehicleExpenseHead.ExpenseHeadCode ;
            txtName.Text = oVehicleExpenseHead.ExpenseHeadName;
            this.ShowDialog();
        }

        private void frmExpenseHead_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) this.Text = "Add New Name";
            else this.Text = "Edit Nane";

        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Expanse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name of Expanse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
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

                VehicleExpenseHead oVehicleExpenseHead = new VehicleExpenseHead();
                oVehicleExpenseHead.ExpenseHeadCode = txtCode.Text;
                oVehicleExpenseHead.ExpenseHeadName = txtName.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleExpenseHead.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oVehicleExpenseHead.ExpenseHeadCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {

                VehicleExpenseHead oVehicleExpenseHead = (VehicleExpenseHead)this.Tag;
                oVehicleExpenseHead.ExpenseHeadCode = txtCode.Text;
                oVehicleExpenseHead.ExpenseHeadName = txtName.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleExpenseHead.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Name : " + oVehicleExpenseHead.ExpenseHeadCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}