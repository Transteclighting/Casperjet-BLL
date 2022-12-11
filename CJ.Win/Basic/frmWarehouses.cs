// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: Apr 25, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouses.
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
    public partial class frmWarehouses : Form
    {
        Warehouse _oWarehouse;
        Warehouses _oWarehouses;
        public frmWarehouses()
        {
            _oWarehouse = new Warehouse();
            _oWarehouses = new Warehouses();
            InitializeComponent();
        }

        private void frmWarehouses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lvwWarehouses.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oWarehouses.Refresh(txtCode.Text, txtFind.Text);

            foreach (Warehouse oWarehouse in _oWarehouses)
            {
                ListViewItem oItem = lvwWarehouses.Items.Add(oWarehouse.WarehouseCode);
                oItem.SubItems.Add(oWarehouse.WarehouseName);
                oItem.SubItems.Add(oWarehouse.ParentWarehouse.WarehouseParentName);
                if (oWarehouse.StockType == (int)Dictionary.WareHouseStockType.SOUND)
                {
                    oItem.SubItems.Add("SOUND");
                }
                else if (oWarehouse.StockType == (int)Dictionary.WareHouseStockType.DAMAGE)
                {
                    oItem.SubItems.Add("DAMAGE");
                }
                else
                {
                    oItem.SubItems.Add("FULLY_DAMAGE");
                }


                if (oWarehouse.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                {
                    oItem.SubItems.Add("Active");
                }
                else
                {
                    oItem.SubItems.Add("InActive");
                }

                oItem.SubItems.Add(oWarehouse.ChnnelDesc.ChannelDescription);


                if (oWarehouse.WarehouseType == (int)Dictionary.WarehouseType.CHANNEL)
                {
                    oItem.SubItems.Add("CHANNEL");
                }
                else if (oWarehouse.WarehouseType == (int)Dictionary.WarehouseType.DISTRIBUTION)
                {
                    oItem.SubItems.Add("DISTRIBUTION");
                }
                else if (oWarehouse.WarehouseType == (int)Dictionary.WarehouseType.SHOWROOM)
                {
                    oItem.SubItems.Add("SHOWROOM");
                }
                else
                {
                    oItem.SubItems.Add("SYSTEM");
                }
                oItem.Tag = oWarehouse;
            }
            this.Text = "Warehouses" + "[" + _oWarehouses.Count + "]";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwWarehouses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Channel to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oWarehouse = (Warehouse)lvwWarehouses.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Market: " + _oWarehouse.WarehouseCode + " ? ", "Confirm MarketGroup Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oWarehouse.Delete();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmWarehouse oForm = new frmWarehouse();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwWarehouses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Warehouse Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oWarehouse = (Warehouse)lvwWarehouses.SelectedItems[0].Tag;
            frmWarehouse oForm = new frmWarehouse();
            oForm.ShowDialog(_oWarehouse);
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}