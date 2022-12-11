using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win
{
    public partial class frmSparePartsReceive : Form
    {
        SPTran oSPTran;
        SPTranDetail oSPTranDetail;
        SparePartsR _oSparePartsR;
        public SparePartsR oSparePartsR;
        Stores _Stores;

        PartsSuppliers _oPartsSuppliers;
        int nSelectedStoreID = 0;
        public frmSparePartsReceive()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Parts Supplier
            _oPartsSuppliers = new PartsSuppliers();
            _oPartsSuppliers.GetPartsSupplier();
            cmbSupplier.Items.Add("<Select Supplier>");
            foreach (PartsSupplier oPartsSupplier in _oPartsSuppliers)
            {
               cmbSupplier.Items.Add(oPartsSupplier.Name);
            }
            if (_oPartsSuppliers.Count > 0)
            {
                cmbSupplier.SelectedIndex = 0;
            }

            _Stores = new Stores();
            _Stores.RefreshChildStore();
            cmbStore.Items.Add("<Select Store>");
            foreach (Store oStore in _Stores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.ChildSotre;
                //item.Value = oStore.StoreID.ToString();
                //cmbStore.Items.Add(item);
                cmbStore.Items.Add(oStore.ChildSotre);
            }
            cmbStore.SelectedIndex = 0;

        }
        public void ShowDialog(SPTran _oSPTran)
        {
            this.Tag = _oSPTran;
            dtReceiveDate.Value=Convert.ToDateTime(_oSPTran.ReceiveDate.ToString());
            cmbSupplier.SelectedIndex = _oSPTran.SupplierID;///////////////////////////////
            txtVoucherNo.Text = _oSPTran.VoucherNo;
            txtRefReqNo.Text = _oSPTran.RefRequisitionNo;
            txtInvoiceNo.Text = _oSPTran.InvoiceNo;
            dtInvoiceDate.Value = Convert.ToDateTime(_oSPTran.InvoiceDate.ToString());

            foreach (SPTranDetail oSPTranDetail in _oSPTran)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSPReceiveItem);
                //oRow.Cells[0].Value = oSPTranDetail.SpareParts.Code.ToString();
                //oRow.Cells[2].Value = oSparePartsTransactionDetail.SpareParts.Name.ToString();
                //oRow.Cells[3].Value = oSparePartsTransactionDetail.SpareParts.SalePrice.ToString();
                //oRow.Cells[4].Value = oSparePartsTransactionDetail.ClaimQty.ToString();
                //oRow.Cells[5].Value = oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo.ToString();
                //oRow.Cells[7].Value = oSparePartsTransactionDetail.ReplaceJobFromCassandra.ProductName.ToString();
                //oRow.Cells[8].Value = oSparePartsTransactionDetail.SpareParts.ID.ToString();
                //oRow.Cells[9].Value = oSparePartsTransactionDetail.JobID.ToString();
                //oRow.Cells[10].Value = oSparePartsTransactionDetail.ISVRequisitionItemID.ToString();

                dgvSPReceiveItem.Rows.Add(oRow);

            }

            this.Tag = _oSPTran;
            this.ShowDialog();
        }
        private void dgvSPReceiveItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (cmbStore.SelectedIndex == 0) 
            {
                MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                //nSelectedStoreID = Convert.ToInt32((cmbStore.SelectedItem as ComboboxItem).Value.ToString());
                nSelectedStoreID = _Stores[cmbStore.SelectedIndex - 1].StoreID;
            }
            catch
            {
                nSelectedStoreID = 0;
            }
            if (e.ColumnIndex == 1)
            {
                frmSparePartSearchR oForm = new frmSparePartSearchR(nSelectedStoreID);
                oForm.ShowDialog();
                if (oForm._oSparePartsR != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvSPReceiveItem);
                    oRow.Cells[0].Value = oForm._oSparePartsR.Code;
                    oRow.Cells[2].Value = oForm._oSparePartsR.Name;
                    oRow.Cells[3].Value = oForm._oSparePartsR.CostPrice;
                    oRow.Cells[4].Value = oForm._oSparePartsR.SalePrice;
                    oRow.Cells[8].Value = oForm._oSparePartsR.SparePartID;

                    if (oForm._oSparePartsR != null)
                    {
                        int nRowIndex = dgvSPReceiveItem.Rows.Add(oRow);

                        if (checkDuplicateLineItem(dgvSPReceiveItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvSPReceiveItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvSPReceiveItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }
            }
            
        }

        private void dgvSPReceiveItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1)return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }

        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sSpareCode = "";

            if (nColumnIndex == 0 && dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (cmbStore.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStore.Focus();
                    dgvSPReceiveItem.Rows.RemoveAt(nRowIndex);
                    return;
                }

                if (checkDuplicateLineItem(dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvSPReceiveItem.Rows.RemoveAt(nRowIndex);
                    return;
                }

                try
                {
                    sSpareCode = dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oSparePartsR = new SparePartsR();
                    _oSparePartsR.Code = sSpareCode;
                    _oSparePartsR.CheckSpareByCode();

                    if (_oSparePartsR.Flag != false)
                    {
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSparePartsR.Name;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oSparePartsR.CostPrice;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oSparePartsR.SalePrice;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oSparePartsR.SparePartID).ToString();

                    }
                    else
                    {
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = 0;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = "";

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvSPReceiveItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvSPReceiveItem.Rows.RemoveAt(nRowIndex);
                }
            }
            else if (nColumnIndex == 5 || nColumnIndex == 4 || nColumnIndex == 3)
            {
                if (dgvSPReceiveItem.Rows[nRowIndex].Cells[3].Value.ToString() != "" && dgvSPReceiveItem.Rows[nRowIndex].Cells[3].Value.ToString() != null || dgvSPReceiveItem.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvSPReceiveItem.Rows[nRowIndex].Cells[4].Value.ToString() != null || dgvSPReceiveItem.Rows[nRowIndex].Cells[5].Value.ToString() != "" && dgvSPReceiveItem.Rows[nRowIndex].Cells[5].Value.ToString() != null)
                {
                    try
                    {
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[6].Value = (Convert.ToDouble(dgvSPReceiveItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvSPReceiveItem.Rows[nRowIndex].Cells[5].Value.ToString()));
                        dgvSPReceiveItem.Rows[nRowIndex].Cells[7].Value = (Convert.ToDouble(dgvSPReceiveItem.Rows[nRowIndex].Cells[4].Value.ToString()) * Convert.ToDouble(dgvSPReceiveItem.Rows[nRowIndex].Cells[5].Value.ToString()));

                    }
                    catch
                    {
                        //MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }
                GetTotal();
            }
            
        }

        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvSPReceiveItem.Rows)
            {
                if (oItemRow.Index < dgvSPReceiveItem.Rows.Count - 1)
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
        private void GetTotal()
        {
            TotalQty.Text = "0";
            TotalCostPrice.Text = "0.00";
            TotalSalePrice.Text = "0.00";
            
            foreach (DataGridViewRow oRow in dgvSPReceiveItem.Rows)
            {
                if (oRow.Cells[5].Value != null)
                {
                    TotalQty.Text = Convert.ToInt32(Convert.ToInt32(TotalQty.Text) + Convert.ToInt32(oRow.Cells[5].Value.ToString())).ToString();
                    TotalCostPrice.Text = Convert.ToDouble(Convert.ToDouble(TotalCostPrice.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString())).ToString();
                    TotalSalePrice.Text = Convert.ToDouble(Convert.ToDouble(TotalSalePrice.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();

                }
            }
            
        }
        private void Save()
        {

            if (validateUIInput())
            {
                if (this.Tag == null)
                {

                    oSPTran = new SPTran();
                    oSPTran = GetUISPTranData(oSPTran);
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        oSPTran.Add();
                        GetUISPStockData();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Save Successfully With Tran No- " + oSPTran.TranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
               
            }
        }
        private void GetUISPStockData()
        {

            foreach (DataGridViewRow oItemRow in dgvSPReceiveItem.Rows)
            {
                if (oItemRow.Index < dgvSPReceiveItem.Rows.Count - 1)
                {

                    SPStock oItem = new SPStock();

                    try
                    {
                        oItem.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[5].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.AddDeductStockQty = Convert.ToInt32(0);
                    }
                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                    oItem.StoreID = _Stores[cmbStore.SelectedIndex -1].StoreID ;

                    oItem.CheckStockBySpareID();

                    if (oItem.Flag != true)
                    {
                        oItem.Add();
                    }
                    else
                    {
                        oItem.UpdateStock(true);
                    }
                    

                }
            }

        }
        public SPTran GetUISPTranData(SPTran oSPTran)
        {
            oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.SparePartReceive_GRD;
            oSPTran.TranSide = (int)Dictionary.SparePartTranSide.IN;
            oSPTran.ReceiveDate = dtInvoiceDate.Value.Date;
            oSPTran.SupplierID = _oPartsSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;
            oSPTran.VoucherNo = txtVoucherNo.Text;
            oSPTran.RefRequisitionNo = txtRefReqNo.Text;
            oSPTran.InvoiceNo = txtInvoiceNo.Text; 
            oSPTran.InvoiceDate = dtInvoiceDate.Value.Date;
            oSPTran.Remarks = txtRemarks.Text;
            oSPTran.DiscountAmt = 0;
            oSPTran.NetAmount =Convert.ToDouble(TotalSalePrice.Text.ToString());
            oSPTran.FromStoreID = (int)Dictionary.Store.SystemStore;
            oSPTran.ToStoreID = _Stores[cmbStore.SelectedIndex - 1].StoreID;

            // Spare Parts Detail

            foreach (DataGridViewRow oItemRow in dgvSPReceiveItem.Rows)
            {
                if (oItemRow.Index < dgvSPReceiveItem.Rows.Count - 1)
                {

                    SPTranDetail oItem = new SPTranDetail();

                    try
                    {
                        oItem.Qty = Convert.ToInt64(oItemRow.Cells[5].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Qty = Convert.ToInt64(0);
                    }
                    oItem.CostPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    oItem.SalePrice = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                    oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());

                    oSPTran.Add(oItem);
                }
            }

            return oSPTran;
        }

        private void Clear()
        {
            DBController.Instance.OpenNewConnection();

            dtInvoiceDate.Value = DateTime.Today.Date;
            cmbSupplier.Text = "<Select Supplier>";
            txtVoucherNo.Text = "";
            txtRefReqNo.Text = "";
            txtInvoiceNo.Text = "";
            txtRemarks.Text = "";
            TotalQty.Text = "0";
            TotalCostPrice.Text = "0.00";
            TotalSalePrice.Text = "0.00";
            dtInvoiceDate.Value = DateTime.Today.Date;

            dgvSPReceiveItem.Rows.Clear();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

            if (cmbSupplier.Text == null || cmbSupplier.Text == "<Select Supplier>")
            {
                MessageBox.Show("Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }

            #endregion

            #region Transaction Details Information Validation

            if (dgvSPReceiveItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Spare Parts ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvSPReceiveItem.Rows)
            {
                if (oItemRow.Index < dgvSPReceiveItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[8].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Part code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Part Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null || int.Parse(oItemRow.Cells[3].Value.ToString()) < 0)
                    {
                        MessageBox.Show("Cost Price must be Inputed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[4].Value == null || int.Parse(oItemRow.Cells[4].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Sale Price must be grather than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[5].Value == null || int.Parse(oItemRow.Cells[5].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                Clear();

            }
        }

        private void frmSparePartsReceive_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            {
            }
        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbStore.SelectedIndex == 0)
            //{
            //    dgvSPReceiveItem.Enabled = false;
            //}
            //else
            //{
            //    dgvSPReceiveItem.Enabled = true;
            //}
        }

    }
}