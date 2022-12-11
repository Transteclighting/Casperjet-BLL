// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: Apr 26, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouse Parent.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmWarehouseParent : Form
    {
        ParentWarehouse _oParentWarehouse;
        ParentWarehouses _oParentWarehouses;
        public frmWarehouseParent()
        {
            _oParentWarehouse = new ParentWarehouse();
            _oParentWarehouses = new ParentWarehouses();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Save();
                this.Close();
            }
        }

        private bool IsValidate()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                _oParentWarehouse.WarehouseParentCode = txtCode.Text;
                _oParentWarehouse.WarehouseParentName = txtName.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oParentWarehouse.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oParentWarehouse.WarehouseParentName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                _oParentWarehouse = (ParentWarehouse)this.Tag;
                _oParentWarehouse.WarehouseParentCode = txtCode.Text;
                _oParentWarehouse.WarehouseParentName = txtName.Text;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oParentWarehouse.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + _oParentWarehouse.WarehouseParentCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                DBController.Instance.BeginNewTransaction();
                _oParentWarehouses.Refresh();
                DBController.Instance.CommitTransaction();
            }
        }

        public void ShowDialog(ParentWarehouse oParentWarehouse)
        {
            this.Tag = oParentWarehouse;

            txtCode.Text = oParentWarehouse.WarehouseParentCode;
            txtName.Text = oParentWarehouse.WarehouseParentName;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWarehouseParent_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Warehouse";
            }
            else
            {
                this.Text = "Edit Warehouse";
            }
        }
    }
}