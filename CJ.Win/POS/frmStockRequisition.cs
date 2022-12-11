using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.Win.POS
{
    public partial class frmStockRequisition : Form
    {
        POSRequisition _oPOSRequisition;
        SystemInfo oSystemInfo;
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        int nUIControl = 0;
        TELLib oTELLib;
        int nRequisitionID = 0;
        int nToWHID = 0;
        string sRequisitionNo = "";
        Warehouse _oWarehouse;
        Warehouses _oWarehouses;
        Showrooms _oShowrooms;
        Warehouses oWarehouses;
        Warehouses oParentWarehouses;
        public frmStockRequisition()
        {
            InitializeComponent();
        }
        private void frmProductRequisition_Load(object sender, EventArgs e)
        {

            if (this.Tag == null)
            {

                this.Text = "Add Stock Requisition";
                LoadCombo();

                int nWarehouseParentIndex = 0;
                nWarehouseParentIndex = oParentWarehouses.GetIndexParentWarehouse(Utility.WarehouseParentID);
                cmbWarehouseParent.SelectedIndex = nWarehouseParentIndex + 1;


                int nOutletIndex = 0;
                nOutletIndex = oWarehouses.GetIndex(Utility.StockTransferWHID);
                cmbWarehouse.SelectedIndex = nOutletIndex + 1;

            }
            else
            {

                this.Text = "Edit Stock Requisition";
            }

        }
        private void LoadComboWH(int nWarehouseParentID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetStockReqDeliveryWH(nWarehouseParentID);
            cmbWarehouse.Items.Add("-- Select --");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
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
            cmbWarehouseParent.SelectedIndex = 0;
        }
        private void LoadCombo()
        {
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
            LoadComboForParentWH();


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                if (cmbOutlet.Text == "-- Select --")
                {
                    MessageBox.Show("Please Select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[5].Value = oForm._oProductDetail.RSP.ToString();
                    oRow.Cells[10].Value = oForm._oProductDetail.ProductID;

                    _oProductStock = new ProductStock();

                    //_oProductStock.GetProductStockWithMTD_YTD(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID,_oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                    if (this.Tag == null)
                    {
                        _oProductStock.GetProductStockWithMTD_YTD(oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID, _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                    }
                    else
                    {
                        _oProductStock.GetProductStockWithMTD_YTD(nToWHID, (int)Dictionary.WareHouseStockType.SOUND, oForm._oProductDetail.ProductID, _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                    }           

                    oRow.Cells[3].Value = _oProductStock.YTDSaleQty.ToString();
                    oRow.Cells[4].Value = _oProductStock.MTDSaleQty.ToString();
                    oRow.Cells[6].Value = (_oProductStock.CurrentStock - _oProductStock.BookingStock);
                    oRow.Cells[7].Value = (_oProductStock.OutletCurrentStock - _oProductStock.OutletBookingStock);

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvLineItem.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }

                        cmbOutlet.Enabled = false;
                        cmbWarehouseParent.Enabled = false;
                        cmbWarehouse.Enabled = false;
                    }
                }

            }

        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (cmbOutlet.Text == "-- Select --")
                {
                    MessageBox.Show("Please Select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }

                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = (_oProductDetail.ProductID).ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductDetail.RSP.ToString();
  
                    _oProductStock = new ProductStock();
                    //_oProductStock.GetProductStockWithMTD_YTD(Utility.CentralRetailWarehouse, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                    if (this.Tag == null)
                    {
                        _oProductStock.GetProductStockWithMTD_YTD(oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                    }
                    else
                    {
                        _oProductStock.GetProductStockWithMTD_YTD(nToWHID, (int)Dictionary.WareHouseStockType.SOUND, _oProductDetail.ProductID, _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                    }

                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductStock.YTDSaleQty.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oProductStock.MTDSaleQty.ToString();
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (_oProductStock.CurrentStock - _oProductStock.BookingStock);
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oProductStock.OutletCurrentStock - _oProductStock.OutletBookingStock);
                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    cmbOutlet.Enabled = false;
                    cmbWarehouseParent.Enabled = false;
                    cmbWarehouse.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (nColumnIndex == 8)
            {
                oTELLib = new TELLib();

                if (dgvLineItem.Rows[nRowIndex].Cells[8].Value != null || Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[8].Value) != 0)
                {
                    dgvLineItem.Rows[nRowIndex].Cells[9].Value = oTELLib.TakaFormat(Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[5].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[8].Value.ToString()));
                }
                GetTotalAmount();
            }
            
        }
        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            txtTotalQty.Text = "0";
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[8].Value != null)
                {
                    oTELLib = new TELLib();

                    txtTotalAmount.Text = oTELLib.TakaFormat(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[9].Value.ToString()));
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())).ToString();
                }
            }

        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oPOSRequisition = new POSRequisition();
                        _oPOSRequisition = GetUIData(_oPOSRequisition);
                        _oPOSRequisition.Edit(nRequisitionID, Utility.CentralRetailWarehouse);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Stock Requisition # " + sRequisitionNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oPOSRequisition = new POSRequisition();
                        _oPOSRequisition = GetUIData(_oPOSRequisition);

                        _oPOSRequisition.InsertStockRequisition((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Stock Requisition # " + _oPOSRequisition.RequisitionNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        public POSRequisition GetUIData(POSRequisition _oPOSRequisition)
        {

            _oPOSRequisition.FromWHID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
            //_oPOSRequisition.ToWHID = Utility.CentralRetailWarehouse;

            _oPOSRequisition.ToWHID = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            _oPOSRequisition.Remarks = txtRemarks.Text;
            _oPOSRequisition.Terminal = (int)Dictionary.Terminal.Head_Office;


            // Product Details
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    POSRequisitionItem _oPOSRequisitionItem = new POSRequisitionItem();

                    _oPOSRequisitionItem.ProductID = int.Parse(oItemRow.Cells[10].Value.ToString());
                    _oPOSRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oPOSRequisitionItem.AuthorizeQty = 0;

                    _oPOSRequisition.Add(_oPOSRequisitionItem);

                }
            }

            return _oPOSRequisition;
        }
        private bool validateUIInput()
        {
            #region Order Master Information Validation
            if (cmbOutlet.Text == "-- Select --")
            {
                MessageBox.Show("Please Select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion

            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[8].Value == null)
                    {
                        MessageBox.Show("Please Input Requisition Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[8].Value) == 0)
                    {
                        MessageBox.Show("Requisition Quantity Must be > 0 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[8].Value) > Convert.ToInt32(oItemRow.Cells[6].Value))
                    {
                        MessageBox.Show("Requisition Quantity Must be equal or less than sound stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    
                }
            }
            #endregion

            return true;
        }
        public void ShowDialog(POSRequisition oPOSRequisition)
        {
            this.Tag = oPOSRequisition;
            oTELLib = new TELLib();
            LoadCombo();


            int nWarehouseParentIndex = 0;
            nWarehouseParentIndex = oParentWarehouses.GetIndexParentWarehouse(oPOSRequisition.ToWarehouseParentID);
            cmbWarehouseParent.SelectedIndex = nWarehouseParentIndex + 1;


            int nWarehousseIndex = 0;
            nWarehousseIndex = oWarehouses.GetIndex(oPOSRequisition.ToWHID);
            cmbWarehouse.SelectedIndex = nWarehousseIndex + 1;



            nRequisitionID = 0;
            nToWHID = 0;
            nRequisitionID = oPOSRequisition.RequisitionID;
            nToWHID = oPOSRequisition.ToWHID;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);
            int nOutletIndex = 0;
            nOutletIndex = _oShowrooms.GetIndexWHID(oPOSRequisition.FromWHID);
            cmbOutlet.SelectedIndex = nOutletIndex + 1;
            cmbOutlet.Enabled = false;
            cmbWarehouseParent.Enabled = false;
            cmbWarehouse.Enabled = false;
            txtRemarks.Text = oPOSRequisition.Remarks;

            foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
                oRow.Cells[2].Value = oPOSRequisitionItem.ProductName.ToString();

                _oProductStock = new ProductStock();
                _oProductStock.GetProductStockWithMTD_YTD(nToWHID, (int)Dictionary.WareHouseStockType.SOUND, oPOSRequisitionItem.ProductID, oPOSRequisition.FromWHID);
                oRow.Cells[3].Value = _oProductStock.YTDSaleQty.ToString();
                oRow.Cells[4].Value = _oProductStock.MTDSaleQty.ToString();
                oRow.Cells[5].Value = oPOSRequisitionItem.RSP.ToString();
                oRow.Cells[6].Value = (_oProductStock.CurrentStock - _oProductStock.BookingStock);
                oRow.Cells[7].Value = (_oProductStock.OutletCurrentStock - _oProductStock.OutletBookingStock);

                oRow.Cells[8].Value = oPOSRequisitionItem.RequisitionQty.ToString();
                oRow.Cells[9].Value = oTELLib.TakaFormat(Convert.ToDouble((oPOSRequisitionItem.RequisitionQty * oPOSRequisitionItem.RSP).ToString()));
                oRow.Cells[10].Value = oPOSRequisitionItem.ProductID.ToString();

                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();
            

            this.ShowDialog();
        }
        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }

        private void cmbWarehouseParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWarehouseParent.SelectedIndex != 0)
            {
                LoadComboWH(oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
            }
            else
            {
                cmbWarehouse.Items.Clear();
                cmbWarehouse.Items.Add("-- Select --");
            }
        }
    }
}