using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Win.Security;

namespace CJ.Win.Inventory
{
    public partial class frmStockAdjustments : Form
    {
        StockTrans oStockTrans;
        Warehouses oWarehouses;
        public frmStockAdjustments()
        {
            InitializeComponent();
        }

        private void frmStockAdjustments_Load(object sender, EventArgs e)
        {
            UpdateSecurity();
            LoadCombos();
        }
        private void LoadCombos()
        {
            oWarehouses = new Warehouses();
            oWarehouses.GetAllWarehouse();
            cmbFromWarehouse.Items.Clear();
            //cmbFromWarehouse.Items.Add("--ALL--");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbFromWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbFromWarehouse.SelectedIndex = 0;

            cmbAdjustmentType.Items.Clear();
            cmbAdjustmentType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductStockTranType)))
            {
                cmbAdjustmentType.Items.Add(Enum.GetName(typeof(Dictionary.ProductStockTranType), GetEnum));
            }
            cmbAdjustmentType.SelectedIndex = 0;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStockAdjustment ofrmStockAdjustment;
            ofrmStockAdjustment = new frmStockAdjustment();
            ofrmStockAdjustment.FormBorderStyle = FormBorderStyle.FixedDialog;
            ofrmStockAdjustment.MaximizeBox = false;
            ofrmStockAdjustment.ShowDialog();
            //DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmStockAdjustment ofrmStockAdjustment;
            ofrmStockAdjustment = new frmStockAdjustment();

            ofrmStockAdjustment.FormBorderStyle = FormBorderStyle.FixedDialog;
            ofrmStockAdjustment.MaximizeBox = false;
            if (lvwStockList.SelectedItems.Count > 0)
            {
                ofrmStockAdjustment.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Please Select a Transaction.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //MessageBox.Show("Under Constraction.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M4.9.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M4.9.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M4.9.3" == sPermissionKey)
                    {
                        btnDelete.Enabled = true;
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (lvwStockList.SelectedItems.Count > 0)
            //{
            //    this.cancelTransaction();
            //    this.refreshList();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count > 0)
            {
                DialogResult oResult = MessageBox.Show("Are you sure to delete this Transaction.", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (oResult == DialogResult.Yes)
                {
                    //deleteTransaction();
                    //DataLoadControl();
                }
                else
                {
                    lvwStockList.SelectedItems.Clear();
                    return;

                }
            }
            else
            {
                MessageBox.Show("Please Select a Transaction.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        
        private void btnPrintTransaction_Click(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoCP_CheckedChanged(object sender, EventArgs e)
        {
            this.lvwStockList_SelectedIndexChanged(sender, e);
        }

        private void rdoNSP_CheckedChanged(object sender, EventArgs e)
        {
            this.lvwStockList_SelectedIndexChanged(sender, e);
        }

        private void rdoRSP_CheckedChanged(object sender, EventArgs e)
        {
            this.lvwStockList_SelectedIndexChanged(sender, e);
        }

        private void rdoNP_CheckedChanged(object sender, EventArgs e)
        {
            this.lvwStockList_SelectedIndexChanged(sender, e);
        }

        private void lvwStockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
