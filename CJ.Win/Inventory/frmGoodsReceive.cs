using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;

namespace CJ.Win.Inventory
{
    public partial class frmGoodsReceive : Form
    {
        Channels _oChannels;
        Warehouses _oWarehouses;
        CommercialInvoices _oCommercialInvoices;
        CommercialInvoice _oCommercialInvoice;
        PurchaseRequisition _oPurchaseRequisition;       
        ProductTransaction _oProductTransaction;
        rptProductTransactionReport _orptProductTransactionReport;    
        ProductStock _oProductStock;
        Product oProduct;

        public frmGoodsReceive()
        {
            InitializeComponent();
        }

        private void frmGoodsReceive_Load(object sender, EventArgs e)
        {
            ckbIsOthers_CheckedChanged(null, null);
            if (this.Tag == null)
            {
                LoadCmb();
            }
            else
            {

            }
        }
        public void LoadCmb()
        {
            _oChannels = new Channels();
            _oChannels.GetAllChannel();
            cmbToChannel.Items.Clear();
            foreach (Channel oChannel in _oChannels)
            {
                cmbToChannel.Items.Add(oChannel.ChannelDescription + "[" + oChannel.ChannelCode + "]");
            }
            if (_oChannels.Count > 0)
                cmbToChannel.SelectedIndex = _oChannels.Count - 1;

            _oCommercialInvoices = new CommercialInvoices();
            _oCommercialInvoices.RefreshFOrGRD();

            foreach (CommercialInvoice oCommercialInvoice in _oCommercialInvoices)
            {
                cmbCINo.Items.Add(oCommercialInvoice.CINo);
            }
            if (_oCommercialInvoices.Count > 0)
                cmbCINo.SelectedIndex = _oCommercialInvoices.Count-1;
        }

        private void cmbToChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _oWarehouses = new Warehouses();
            _oWarehouses.GetWarehousByChannel(_oChannels[cmbToChannel.SelectedIndex].ChannelID);
            cmbToWarehouse.Items.Clear();
            foreach (Warehouse oWarehouse in _oWarehouses)
            {
                cmbToWarehouse.Items.Add(oWarehouse.WarehouseName + "[" + oWarehouse.WarehouseCode + "]");
            }
            if (_oWarehouses.Count > 0)
                cmbToWarehouse.SelectedIndex = _oWarehouses.Count-1;
         
        }

        private void cmbCINo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_oCommercialInvoices[cmbCINo.SelectedIndex].CIID != -1)
            {
                dgvLineItem.Rows.Clear();
             
                _oPurchaseRequisition = new PurchaseRequisition();             
                _oPurchaseRequisition.RefreshForGRD(_oCommercialInvoices[cmbCINo.SelectedIndex].POID);
                

                _oCommercialInvoice = new CommercialInvoice();
                _oCommercialInvoice.CIID = _oCommercialInvoices[cmbCINo.SelectedIndex].CIID;
                _oCommercialInvoice.POID = _oCommercialInvoices[cmbCINo.SelectedIndex].POID;
                _oCommercialInvoice.RefreshItem();
               
                txtSupplyer.Text = _oPurchaseRequisition.Supplier.SupplierName;
                txtLCNo.Text = _oPurchaseRequisition.LCNo;
                txtPINo.Text = _oPurchaseRequisition.PINo;
                dtpLCDate.Value = Convert.ToDateTime(_oPurchaseRequisition.LCDate);
                dtpLCInvoiceDate.Value = Convert.ToDateTime(_oCommercialInvoices[cmbCINo.SelectedIndex].CIDate);

                _orptProductTransactionReport = new rptProductTransactionReport();
                _orptProductTransactionReport.GetDataForCIMsg(_oCommercialInvoices[cmbCINo.SelectedIndex].CIID);

                foreach (CommercialInvoiceItem oCommercialInvoiceItem in _oCommercialInvoice)
                {
                    if (oCommercialInvoiceItem.Qty != 0)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oCommercialInvoiceItem.ProductDetail.ProductCode;
                        oRow.Cells[2].Value = oCommercialInvoiceItem.ProductDetail.ProductName.ToString();
                        oRow.Cells[3].Value = oCommercialInvoiceItem.ProductDetail.CostPrice.ToString();
                        oRow.Cells[4].Value = oCommercialInvoiceItem.Qty.ToString();
                        foreach (rptProductTransaction orptProductTransaction in _orptProductTransactionReport)
                        {
                            if (orptProductTransaction.ProductID == oCommercialInvoiceItem.ProductID)
                                oRow.Cells[5].Value = orptProductTransaction.Qty;
                        }
                       
                        oRow.Cells[6].Value = 0;
                        oRow.Cells[11].Value = oCommercialInvoiceItem.ProductID.ToString();
                        oRow.Cells[0].ReadOnly = true;
                        dgvLineItem.Rows.Add(oRow);
                    }
                }              
            }
        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[3].Value = oForm._oProductDetail.CostPrice;
                    oRow.Cells[4].Value = 0;
                    oRow.Cells[5].Value = 0;
                    oRow.Cells[6].Value = 0;
                    oRow.Cells[11].Value = oForm._oProductDetail.ProductID;

                    if (oForm.sProductCode != null)
                    {
                        int nRowIndex = dgvLineItem.Rows.Add(oRow);
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
            if (nColumnIndex == 0)
            {
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

                        ProductDetail oProductDtail = new ProductDetail();
                        oProductDtail.ProductCode = sProductCode;
                        oProductDtail.RefreshByCode();

                        if (oProductDtail.Flag != false)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProductDtail.ProductName;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = oProductDtail.CostPrice;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = (oProductDtail.ProductID).ToString();

                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
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
        private void ckbIsOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIsOthers.Checked == true)
            {
                dgvLineItem.Rows.Clear();
                txtLCNo.Text = "";
                txtPINo.Text = "";
                txtSupplyer.Text = "";
                dtpLCDate.Value = DateTime.Today.Date;
                dtpLCInvoiceDate.Value = DateTime.Today.Date;
                groupBox1.Visible = false;
                lbOther.Visible = true;
                txtOther.Visible = true;
                if (_oCommercialInvoices.Count > 0)
                    cmbCINo.SelectedIndex = _oCommercialInvoices.Count - 1;
               
            }
            else
            {
                dgvLineItem.Rows.Clear();
                groupBox1.Visible = true;
                lbOther.Visible = false;
                txtOther.Visible = false;
               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    // Insert Product Transaction and Update Current Stock 

                    _oProductTransaction = new ProductTransaction();
                    _oProductTransaction = GetUIProductTransactionData(_oProductTransaction);

                    bool IsSuccess = _oProductTransaction.InsertForGRD();
                    if (IsSuccess == false)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error!!...Stock Problem!");
                        return;
                    }
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oProductTransaction.TranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ckbIsOthers.Checked != true)
                    {

                        frmMsgCIQty frmMsgCIQty = new frmMsgCIQty(_oCommercialInvoices[cmbCINo.SelectedIndex]);
                        DialogResult oResult = frmMsgCIQty.ShowDialog();
                        if (oResult == DialogResult.OK)
                        {
                            _oCommercialInvoice = new CommercialInvoice();
                            _oCommercialInvoice.CIID = _oCommercialInvoices[cmbCINo.SelectedIndex].CIID;
                            _oCommercialInvoice.POID = _oCommercialInvoices[cmbCINo.SelectedIndex].POID;
                            _oCommercialInvoice.Status = (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_FULLY;
                            _oCommercialInvoice.UpdateStatus();
                        }
                        else
                        {
                            _oCommercialInvoice = new CommercialInvoice();
                            _oCommercialInvoice.CIID = _oCommercialInvoices[cmbCINo.SelectedIndex].CIID;
                            _oCommercialInvoice.POID = _oCommercialInvoices[cmbCINo.SelectedIndex].POID;
                            _oCommercialInvoice.Status = (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_PARTIAL;
                            _oCommercialInvoice.UpdateStatus();
                        }

                        _oPurchaseRequisition = new PurchaseRequisition();
                        _oPurchaseRequisition.POID = _oCommercialInvoices[cmbCINo.SelectedIndex].POID;
                        _oPurchaseRequisition.Refresh();
                        _orptProductTransactionReport = new rptProductTransactionReport();
                        _orptProductTransactionReport.GetDataForPIMsg(_oPurchaseRequisition.POID);

                        foreach (rptProductTransaction orptProductTransaction in _orptProductTransactionReport)
                        {
                            oProduct = new Product();
                            oProduct.ProductID = orptProductTransaction.ProductID;
                            oProduct.RefreshByID();
                            orptProductTransaction.ProductCode = oProduct.ProductCode;
                            orptProductTransaction.ProductName = oProduct.ProductName;
                        }
                        frmMsgPIQty frmMsgPIQty = new frmMsgPIQty(_oPurchaseRequisition.PINo, _orptProductTransactionReport);
                        DialogResult oOK = frmMsgPIQty.ShowDialog();
                        if (oOK == DialogResult.OK)
                        {
                            _oPurchaseRequisition = new PurchaseRequisition();
                            _oPurchaseRequisition.POID = _oCommercialInvoices[cmbCINo.SelectedIndex].POID;
                            _oPurchaseRequisition.Status = (int)Dictionary.PurchaseRequisitionStatus.RECEIVED;
                            _oPurchaseRequisition.UpdateStatus();
                        }
                        else
                        {

                        }
                    }

                    DBController.Instance.CommitTransaction();
                    Clear();
                    LoadCmb();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            DBController.Instance.OpenNewConnection();
            txtTransationRef.Text = "";
            dtTransactionDate.Value = DateTime.Today.Date;
            cmbToChannel.SelectedIndex = _oChannels.Count - 1;
            cmbToWarehouse.Items.Clear();
            txtRemarks.Text = "";
            cmbCINo.SelectedIndex = _oCommercialInvoices.Count - 1;
            txtLCNo.Text = "";
            txtPINo.Text = "";
            txtSupplyer.Text = "";
            dtpLCDate.Value = DateTime.Today.Date;
            dtpLCInvoiceDate.Value = DateTime.Today.Date;

            dgvLineItem.Rows.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

            if (txtTransationRef.Text != "")
            {
                _oProductTransaction = new ProductTransaction();
                _oProductTransaction.TranNo = txtTransationRef.Text;               
                if (!_oProductTransaction.CheckProductStockTranNo())
                {
                    MessageBox.Show("Please input valied Tran No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTransationRef.Focus();
                 
                    return false;
                }
             
            }
            else
            {
                MessageBox.Show("Please input valied Tran No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTransationRef.Focus();
                return false;
            }

            if (_oChannels[cmbToChannel.SelectedIndex].ChannelID == -1)
            {
                MessageBox.Show("Please Select a Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToChannel.Focus();
                return false;
            }

            if (_oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID == -1)
            {
                MessageBox.Show("Please Select a Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToWarehouse.Focus();
                return false;
            }

            if (ckbIsOthers.Checked == true)
            {
                if (txtOther.Text == "")
                {
                    MessageBox.Show("Please input a number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOther.Focus();
                    return false;
                }
            }
            else
            {
                if (_oCommercialInvoices[cmbCINo.SelectedIndex].CIID == -1)
                {
                    MessageBox.Show("Please Select a CI Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCINo.Focus();
                    return false;
                }
            }

            #endregion

            #region Transaction Details Information Validation

            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[11].Value == null)
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[11].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Please Input Receive Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Receive Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Receive Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if(int.Parse(oItemRow.Cells[6].Value.ToString())>int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Receive Quntity Must Less or equal CI Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;
        }
        public ProductTransaction GetUIProductTransactionData(ProductTransaction oProductTransaction)
        {
            oProductTransaction.TranNo = txtTransationRef.Text;
            oProductTransaction.TranDate = DateTime.Today.Date;
            if (ckbIsOthers.Checked == false)
                oProductTransaction.POID = _oCommercialInvoices[cmbCINo.SelectedIndex].CIID;
            else
            {
                oProductTransaction.POID = -1;
                oProductTransaction.LCNo = txtOther.Text;
            }
            oProductTransaction.ToWHID = _oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID;
            oProductTransaction.ToChannelID = _oChannels[cmbToChannel.SelectedIndex].ChannelID;
            oProductTransaction.Remarks = txtRemarks.Text;
            oProductTransaction.UserID = Utility.UserId;
            oProductTransaction.Terminal = 1;

            // Product Detail

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();

                    try
                    {
                        oItem.Qty = Convert.ToInt64(oItemRow.Cells[6].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Qty = Convert.ToInt64(0);
                    }
                    try
                    {
                        oItem.LCShortQty = Convert.ToInt64(oItemRow.Cells[7].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.LCShortQty = Convert.ToInt64(0);
                    }
                    try
                    {
                        oItem.LCDamagedQty = Convert.ToInt64(oItemRow.Cells[8].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.LCDamagedQty = Convert.ToInt64(0);
                    }
                    try
                    {
                        oItem.LCMinorDefectiveQty = Convert.ToInt64(oItemRow.Cells[9].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.LCMinorDefectiveQty = Convert.ToInt64(0);
                    }
                    try
                    {
                        oItem.LCRemarks = oItemRow.Cells[10].Value.ToString();   
                    }
                    catch (Exception ex)
                    {
                        oItem.LCRemarks = "";   
                    }
                         
                    oItem.ProductID = Convert.ToInt16(oItemRow.Cells[11].Value.ToString().Trim());

                    oItem.StockPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    if (oItem.Qty != 0)
                        oProductTransaction.Add(oItem);
                }
            }

            return oProductTransaction;
        }
    }
}