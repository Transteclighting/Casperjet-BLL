using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.Win.POS
{
    public partial class frmStockRequisitionDeliveryWH : Form
    {
        Warehouses oWarehouses;
        Warehouses oParentWarehouses;
        POSRequisition _POSRequisition;
        int nMappedWH = 0;
        public frmStockRequisitionDeliveryWH()
        {
            InitializeComponent();
        }
        public void ShowDialog(POSRequisition oPOSRequisition)
        {
            this.Tag = oPOSRequisition;
            _POSRequisition = new POSRequisition();
            _POSRequisition = oPOSRequisition;
            lblRequisitionNo.Text = oPOSRequisition.RequisitionNo;
            lblOutlet.Text = oPOSRequisition.FromWHName + "[" + oPOSRequisition.FromWHCode + "]";
            lblRequisitionData.Text = oPOSRequisition.RequisitionDate.ToString("dd-MMM-yyyy");
            LoadComboForParentWH();

            //LoadComboNew(oPOSRequisition.FromWHID);

            if (nMappedWH != 0)
            {
                int nWarehouseParentIndex = 0;
                nWarehouseParentIndex = oWarehouses.GetIndex(nMappedWH);
                cmbWarehouse.SelectedIndex = nWarehouseParentIndex + 1;
            }


            //int nOutletIndex = 0;
            //nOutletIndex = oWarehouses.GetIndex(Utility.StockTransferWHID);
            //cmbWarehouse.SelectedIndex = nOutletIndex + 1;


            this.ShowDialog();
        }
        private void LoadComboNew(int nWHID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetMappedWHForShowroom(nWHID);
            cmbWarehouse.Items.Add("-- Select --");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
                nMappedWH = oWarehouse.WarehouseID;
            }
            cmbWarehouse.SelectedIndex = 0;
        }
        private void LoadComboForParentWH()
        {
            cmbWarehouseParent.Items.Clear();
            oParentWarehouses = new Warehouses();
            oParentWarehouses.GetWarehouseParents();
            cmbWarehouseParent.Items.Add("-- Select --");
            foreach (Warehouse oParentWarehouse in oParentWarehouses)
            {
                cmbWarehouseParent.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbWarehouseParent.SelectedIndex = 8;
        }
        private void LoadCombo(int nWarehouseParentID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetStockReqDeliveryWH(nWarehouseParentID);
            cmbWarehouse.Items.Add("-- Select --");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            if (nWarehouseParentID == 10)
            {
                cmbWarehouse.SelectedIndex = 15;
            }
            else
            {
                cmbWarehouse.SelectedIndex = 0;
            }
        }
        private void frmStockRequisitionDeliveryWH_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Validation
            if (cmbWarehouse.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    POSRequisition oRequisition = new POSRequisition();
                    _POSRequisition.ToWHID = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID;
                    _POSRequisition.ToWHName = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseName;
                    _POSRequisition.ToWHCode = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseCode;
                    oRequisition.UpdateDeliveryWH(_POSRequisition.RequisitionID, oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID);
                    DBController.Instance.CommitTran();
                    //MessageBox.Show("Success fully Update Stock Requisition # " + sRequisitionNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                    
                    frmStockRequisitionAuthorization oForm = new frmStockRequisitionAuthorization((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive);
                    oForm.ShowDialog(_POSRequisition);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void cmbWarehouseParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWarehouseParent.SelectedIndex != 0)
            {
                LoadCombo(oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
            }
            else
            {
                cmbWarehouse.Items.Clear();
                cmbWarehouse.Items.Add("-- Select --");
            }
        }
    }
}
