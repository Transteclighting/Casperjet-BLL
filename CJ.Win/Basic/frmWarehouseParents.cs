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
    public partial class frmWarehouseParents : Form
    {
        ParentWarehouse _oParentWarehouse;
        ParentWarehouses _oParentWarehouses;
        public frmWarehouseParents()
        {
            _oParentWarehouse = new ParentWarehouse();
            _oParentWarehouses = new ParentWarehouses();
            InitializeComponent();
        }

        private void frmWarehouseParents_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            lvwParentWarehouses.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oParentWarehouses.Refresh();

            foreach (ParentWarehouse oParentWarehouse in _oParentWarehouses)
            {
                ListViewItem oItem = lvwParentWarehouses.Items.Add(oParentWarehouse.WarehouseParentCode);
                oItem.SubItems.Add(oParentWarehouse.WarehouseParentName);
                oItem.Tag = oParentWarehouse;
            }
            this.Text = "Parent Warehouses" + "[" + _oParentWarehouses.Count + "]";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmWarehouseParent oForm = new frmWarehouseParent();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwParentWarehouses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Channel to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oParentWarehouse = (ParentWarehouse)lvwParentWarehouses.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Market: " + _oParentWarehouse.WarehouseParentCode + " ? ", "Confirm MarketGroup Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oParentWarehouse.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwParentWarehouses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Channel Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oParentWarehouse = (ParentWarehouse)lvwParentWarehouses.SelectedItems[0].Tag;
            frmWarehouseParent oForm = new frmWarehouseParent();
            oForm.ShowDialog(_oParentWarehouse);
            LoadData();
        }
    }
}