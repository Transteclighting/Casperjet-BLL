using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.POS.TELWEBSERVER;

namespace CJ.POS.ISGM
{
    public partial class frmISGM : Form
    {
        Service oSerivce;
        DSBarcode oDSBarcode;
        DSISGM oDSISGM;
        DSISGM oSelectedDSISGM;
        DSWarehouse oDSFromWarehouse;
        DSWarehouse oDSToWarehouse;
        DSStock oDSStock;

        CJ.Class.Warehouses _oWarehouses;
        CJ.Class.ProductBarcodes oProductBarcodes;
        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.ProductDetail _oProductDetail;
        CJ.Class.Web.UI.Class.WUIUtility _oWUIUtility;

        bool _IsAuthorize = false;

        public frmISGM()
        {
            InitializeComponent();
        }

        private void frmISGM_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();

            }
            btAuthorize.Visible = false;
            btSave.Visible = false;
            dgvLineItem.Enabled = false;
            dgvBarcode.Enabled = false;

            if (_IsAuthorize)
            {
                btAuthorize.Visible = true;
                bCancel.Visible = true;
                btSave.Visible = false;
                dgvLineItem.Enabled = false;
                dgvBarcode.Enabled = false;
            }
            else
            {
                btAuthorize.Visible = false;
                bCancel.Visible = false;
                btSave.Visible = true;
                dgvLineItem.Enabled = true;
                dgvBarcode.Enabled = true;
            }

        }
        public void LoadCombo()
        {
            if (_IsAuthorize)
            {
                oDSFromWarehouse = new DSWarehouse();
                oDSToWarehouse = new DSWarehouse();
                oSerivce = new Service();
                try
                {
                    oDSFromWarehouse = oSerivce.GelAllWarehouse(oDSFromWarehouse);
                    oDSToWarehouse.Merge(oDSFromWarehouse);
                    oDSToWarehouse.AcceptChanges();
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmbFromWarehouse.ValueMember = "WarehouseID";
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.DataSource = oDSFromWarehouse.Warehouse;

                cmbToWarehouse.ValueMember = "WarehouseID";
                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.DataSource = oDSToWarehouse.Warehouse;


            }
            else
            {
                CJ.Class.DBController.Instance.OpenNewConnection();
                oSystemInfo = new CJ.Class.POS.SystemInfo();
                oSystemInfo.Refresh();

                if (oSystemInfo.OperationDate != null)
                    dtRequisitionDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate.ToString()).Date;
                else
                {
                    MessageBox.Show("Please Start Operation Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                cmbFromWarehouse.Items.Add(oSystemInfo.WarehouseName);
                cmbFromWarehouse.SelectedIndex = 0;

                _oWarehouses = new CJ.Class.Warehouses();
                _oWarehouses.GetAllWarehouse();
                cmbToWarehouse.Items.Clear();
                foreach (CJ.Class.Warehouse oWarehouse in _oWarehouses)
                {
                    cmbToWarehouse.Items.Add(oWarehouse.WarehouseName);
                }
                if (_oWarehouses.Count > 0)
                    cmbToWarehouse.SelectedIndex = _oWarehouses.Count - 1;
                CJ.Class.DBController.Instance.CloseConnection();

              
              
            }
        }
        public void ShowDialog(DSISGM.ProductISGMRow _oProductISGMRow,bool IsAuthorize)
        {
            _IsAuthorize = IsAuthorize;          
            this.Tag = _oProductISGMRow;

            LoadCombo();
        
            cmbFromWarehouse.Enabled = false;
            cmbToWarehouse.Enabled = false;
            txtISGMNo.Text = _oProductISGMRow.ISGMNo;
            dtRequisitionDate.Value = _oProductISGMRow.ISGMDate.Date;

            if (_IsAuthorize)
            {
                dtRequisitionDate.Enabled = false;
                cmbFromWarehouse.SelectedValue = _oProductISGMRow.FromWHID;
                cmbToWarehouse.SelectedValue = _oProductISGMRow.ToWHID;
              
            }
            else
            {
                cmbToWarehouse.SelectedIndex = _oWarehouses.GetIndex(_oProductISGMRow.ToWHID);
            }

            txtRemarks.Text = _oProductISGMRow.Remarks;
            try
            {
                oSerivce = new Service();
                oSelectedDSISGM = new DSISGM();
                oSelectedDSISGM = oSerivce.ISGMItemRefresh(oSelectedDSISGM, _oProductISGMRow.ISGMID, _oProductISGMRow.FromWHID);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DSISGM.ProductISGMItemRow oProductISGMItemRow in oSelectedDSISGM.ProductISGMItem)
            {
                CJ.Class.DBController.Instance.OpenNewConnection();
                

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                oRow.Cells[0].Value = oProductISGMItemRow.ProductCode;
                oRow.Cells[2].Value = oProductISGMItemRow.ProductName;
                oRow.Cells[4].Value = oProductISGMItemRow.Qty;
                oRow.Cells[5].Value = oProductISGMItemRow.ProductID;
             
                if (_IsAuthorize)
                {
                    oSerivce = new Service();
                    oDSStock = new DSStock();
                    try
                    {
                        oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbFromWarehouse.SelectedValue.ToString()), oProductISGMItemRow.ProductID, true);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    oRow.Cells[3].Value = oDSStock.Stock[0].CurrentStock;
                }
                else
                {
                    _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                    _oWUIUtility.GetPOSStock(oSystemInfo.WarehouseID, oProductISGMItemRow.ProductID);
                    oRow.Cells[3].Value = _oWUIUtility.CurrentStock;
                }
                dgvLineItem.Rows.Add(oRow);

                oProductBarcodes = new CJ.Class.ProductBarcodes();
                if (_IsAuthorize != true)
                {
                    oProductBarcodes.GetBarcodeForISGM(oProductISGMItemRow.ProductID, oSystemInfo.WarehouseID);
                }

                if (_IsAuthorize)
                {
                    foreach (DSISGM.BarcodeRow oBarcodeRow in oSelectedDSISGM.Barcode)
                    {
                        DataGridViewRow oRowItem = new DataGridViewRow();
                        oRowItem.CreateCells(dgvBarcode);
                        oRowItem.Cells[0].Value = true;
                        oRowItem.Cells[1].Value = oBarcodeRow.Barcode;
                        oRowItem.Cells[2].Value = oBarcodeRow.ProductID;
                        dgvBarcode.Rows.Add(oRowItem);
                    }
                }
                else
                {
                    foreach (CJ.Class.ProductBarcode oProductBarcode in oProductBarcodes)
                    {
                        DataGridViewRow oBaroceRow = new DataGridViewRow();
                        oBaroceRow.CreateCells(dgvBarcode);
                        oBaroceRow.Cells[1].Value = oProductBarcode.ProductSerialNo;
                        oBaroceRow.Cells[2].Value = oProductISGMItemRow.ProductID;
                        dgvBarcode.Rows.Add(oBaroceRow);
                    }
                    foreach (DataGridViewRow oItemRow in dgvBarcode.Rows)
                    {
                        if (oItemRow.Index < dgvBarcode.Rows.Count - 1)
                        {
                            foreach (DSISGM.BarcodeRow oBarcodeRow in oSelectedDSISGM.Barcode)
                            {
                                if ((oItemRow.Cells[1].Value.ToString()) == oBarcodeRow.Barcode)
                                {
                                    oItemRow.Cells[0].Value = true;
                                }
                            }
                        }
                    }
                }
                CJ.Class.DBController.Instance.CloseConnection();
            }
            this.ShowDialog();
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;         
            if (e.ColumnIndex == 1)
            {
                if (_oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID==-1)
                {
                    MessageBox.Show("Please select to warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmbFromWarehouse.Enabled = false;
                cmbToWarehouse.Enabled = false;

                frmProductSearch oForm = new frmProductSearch(oSystemInfo.WarehouseID);
                oForm.ShowDialog();
                if (oForm.oDSSelectedProduct != null)
                {
                    foreach (CJ.Class.POS.DSProduct.ProductRow oProductRow in oForm.oDSSelectedProduct.Product)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oProductRow.ProductCode;
                        oRow.Cells[2].Value = oProductRow.ProductName;
                        oRow.Cells[5].Value = oProductRow.ProductID;

                        try
                        {
                            _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oWUIUtility.GetPOSStock(oSystemInfo.WarehouseID, int.Parse(oProductRow.ProductID.ToString()));
                            CJ.Class.DBController.Instance.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        oRow.Cells[3].Value = _oWUIUtility.CurrentStock;                      

                        nRowIndex = dgvLineItem.Rows.Add(oRow);

                        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;

                        }
                        oProductBarcodes = new CJ.Class.ProductBarcodes();
                        CJ.Class.DBController.Instance.OpenNewConnection();
                        oProductBarcodes.GetBarcodeForISGM(int.Parse(oProductRow.ProductID.ToString()), oSystemInfo.WarehouseID);
                        CJ.Class.DBController.Instance.CloseConnection();
                     
                        foreach (CJ.Class.ProductBarcode oProductBarcode in oProductBarcodes)
                        {
                            DataGridViewRow oBaroceRow = new DataGridViewRow();
                            oBaroceRow.CreateCells(dgvBarcode);
                            oBaroceRow.Cells[1].Value = oProductBarcode.ProductSerialNo;
                            oBaroceRow.Cells[2].Value = oProductRow.ProductID;
                            dgvBarcode.Rows.Add(oBaroceRow);
                        }        
                    }
                }
            }          
        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                if (_oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID == -1)
                {
                    MessageBox.Show("Please select to warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmbFromWarehouse.Enabled = false;
                cmbToWarehouse.Enabled = false;
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";        

            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new CJ.Class.ProductDetail();
                    try
                    {                      
                        CJ.Class.DBController.Instance.OpenNewConnection();
                        _oProductDetail.ProductCode = sProductCode;
                        _oProductDetail.RefreshByCode();
                        CJ.Class.DBController.Instance.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_oProductDetail.Flag == true)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductDetail.ProductID;

                        try
                        {
                            _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oWUIUtility.GetPOSStock(oSystemInfo.WarehouseID, _oProductDetail.ProductID);
                            CJ.Class.DBController.Instance.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oWUIUtility.CurrentStock;

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                        oProductBarcodes = new CJ.Class.ProductBarcodes();
                        CJ.Class.DBController.Instance.OpenNewConnection();
                        oProductBarcodes.GetBarcodeForISGM(_oProductDetail.ProductID, oSystemInfo.WarehouseID);
                        CJ.Class.DBController.Instance.CloseConnection();

                        foreach (CJ.Class.ProductBarcode oProductBarcode in oProductBarcodes)
                        {
                            DataGridViewRow oBaroceRow = new DataGridViewRow();
                            oBaroceRow.CreateCells(dgvBarcode);
                            oBaroceRow.Cells[1].Value = oProductBarcode.ProductSerialNo;
                            oBaroceRow.Cells[2].Value = _oProductDetail.ProductID;
                            dgvBarcode.Rows.Add(oBaroceRow);
                        }        

                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public bool ValidateUIInput()
        {
            int nCount = 0;
            oDSBarcode = new DSBarcode();
            if (dgvBarcode.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product Barcode ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvBarcode.Rows)
            {
                if (oItemRow.Index < dgvBarcode.Rows.Count - 1)
                {
                    if (Convert.ToBoolean(oItemRow.Cells[0].Value) == true)
                    {
                        DSBarcode.BarcodeRow oBarcodeRow = oDSBarcode.Barcode.NewBarcodeRow();

                        oBarcodeRow.WarehouseID = oSystemInfo.WarehouseID;
                        oBarcodeRow.ProductID = int.Parse(oItemRow.Cells[2].Value.ToString());
                        oBarcodeRow.Barcode = oItemRow.Cells[1].Value.ToString();

                        oDSBarcode.Barcode.AddBarcodeRow(oBarcodeRow);
                        oDSBarcode.AcceptChanges();

                    }
                }
            }
            if (cmbFromWarehouse.Text=="")
            {
                MessageBox.Show("Please select from warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please select to warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Please Input Valied Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[5].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[5].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valied Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }                  
                    if (oDSBarcode.Barcode.Count <= 0)
                    {
                        MessageBox.Show("Please Input all Product Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    nCount = 0;
                    foreach (DSBarcode.BarcodeRow oBarcodeRow in oDSBarcode.Barcode)
                    {
                        if (oBarcodeRow.ProductID == int.Parse(oItemRow.Cells[5].Value.ToString()))
                        {
                            nCount++;
                        }
                    }
                    try
                    {
                        if (nCount != int.Parse(oItemRow.Cells[4].Value.ToString()))
                        {
                            MessageBox.Show("Number of Selected Product Barcode and ISGM Qty must be Same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please input valied ISGM Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (int.Parse(oItemRow.Cells[3].Value.ToString()) < int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Unavailable Stock Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                if (this.Tag != null)
                {
                    oDSISGM = new DSISGM();
                    DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)this.Tag;
                    DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                    oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                    oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                    oProductISGMRow.Remarks = txtRemarks.Text;

                    oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                    oDSISGM.AcceptChanges();

                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            DSISGM.ProductISGMItemRow oProductISGMItemRow = oDSISGM.ProductISGMItem.NewProductISGMItemRow();

                            oProductISGMItemRow.ISGMID = 0;
                            oProductISGMItemRow.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString().Trim());
                            oProductISGMItemRow.Qty = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());

                            oDSISGM.ProductISGMItem.AddProductISGMItemRow(oProductISGMItemRow);
                            oDSISGM.AcceptChanges();

                        }
                    }
                    oSerivce = new Service();
                    try
                    {
                        oDSISGM = oSerivce.UpdateISGM(oDSISGM, oDSBarcode, oSelectedDSISGM);

                        if (oDSISGM.ProductISGM[0].Result == "1")
                        {
                            MessageBox.Show("You Have Successfully Update ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show(oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    oDSISGM = new DSISGM();
                    DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                    oProductISGMRow.ISGMID = 0;
                    oProductISGMRow.ISGMDate = dtRequisitionDate.Value.Date;
                    oProductISGMRow.FromWHID = oSystemInfo.WarehouseID;
                    oProductISGMRow.ToWHID = _oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID;
                    oProductISGMRow.CreatedBy = CJ.Class.Utility.UserId;
                    oProductISGMRow.Remarks = txtRemarks.Text;

                    oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                    oDSISGM.AcceptChanges();

                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            DSISGM.ProductISGMItemRow oProductISGMItemRow = oDSISGM.ProductISGMItem.NewProductISGMItemRow();

                            oProductISGMItemRow.ISGMID = 0;
                            oProductISGMItemRow.ProductID =int.Parse(oItemRow.Cells[5].Value.ToString().Trim());
                            oProductISGMItemRow.Qty = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());                       

                            oDSISGM.ProductISGMItem.AddProductISGMItemRow(oProductISGMItemRow);
                            oDSISGM.AcceptChanges();

                        }
                    }
                    oSerivce = new Service();
                    try
                    {
                        oDSISGM = oSerivce.InsertISGM(oDSISGM,oDSBarcode);

                        if (oDSISGM.ProductISGM[0].Result == "1")
                        { 
                            MessageBox.Show("You Have Successfully Save ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                      
            }
        }

        private void btAuthorize_Click(object sender, EventArgs e)
        {
            oDSISGM = new DSISGM();
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)this.Tag;

            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
            {
                if (oSelectProductISGMRow.TransferStatus == (int)CJ.Class.Dictionary.ISGMTransferStatus.Submitted_ISGM_Transfer)
                {

                    DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                    oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                    oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                    oProductISGMRow.FromWHID = oSelectProductISGMRow.FromWHID;
                    oProductISGMRow.ToWHID = oSelectProductISGMRow.ToWHID;
                    oProductISGMRow.Remarks = txtRemarks.Text;

                    oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                    oDSISGM.AcceptChanges();
                  
                    oSerivce = new Service();
                    try
                    {
                        int nUserID=CJ.Class.Utility.UserId;
                        oDSISGM = oSerivce.ISGMAuthorize(oDSISGM, oSelectedDSISGM, nUserID);

                        if (oDSISGM.ProductISGM[0].Result == "1")
                        {
                            MessageBox.Show("You Have Successfully Authorize this ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Authorize", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show(oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            oDSISGM = new DSISGM();
            DSISGM.ProductISGMRow oSelectProductISGMRow = (DSISGM.ProductISGMRow)this.Tag;

            if (oSelectProductISGMRow.Status == (int)CJ.Class.Dictionary.ProductISGMStatus.Submitted)
            {


                DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                oProductISGMRow.ISGMID = oSelectProductISGMRow.ISGMID;
                oProductISGMRow.ISGMNo = oSelectProductISGMRow.ISGMNo;
                oProductISGMRow.FromWHID = oSelectProductISGMRow.FromWHID;
                oProductISGMRow.ToWHID = oSelectProductISGMRow.ToWHID;
                oProductISGMRow.Remarks = txtRemarks.Text;

                oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                oDSISGM.AcceptChanges();

                oSerivce = new Service();
                try
                {
                    int nUserID = CJ.Class.Utility.UserId;
                    oDSISGM = oSerivce.ISGMCancel(oDSISGM, oSelectedDSISGM, nUserID);

                    if (oDSISGM.ProductISGM[0].Result == "1")
                    {
                        MessageBox.Show("You Have Successfully Cancel this ISGM, ISGM No - " + oDSISGM.ProductISGM[0].ISGMNo, "Cacncel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show(oDSISGM.ProductISGM[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}