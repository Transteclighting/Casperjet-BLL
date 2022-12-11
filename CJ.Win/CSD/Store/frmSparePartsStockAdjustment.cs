using System;
using System.Windows.Forms;
using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSparePartsStockAdjustment : Form  
    {
        SPTran oSPTran;
        SPTranDetail oSPTranDetail; 
        SparePartsR _oSparePartsR;
        int nSelectedStoreID = 0;
        Stores _oStores;
        Store _oStore;
        SPStock oSPStock;

        public frmSparePartsStockAdjustment()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Parent Store
            _oStores = new Stores();
            _oStores.GetParentStore();

            foreach (Store oStore in _oStores)
            {
                cmbParentStore.Items.Add(oStore.StoreName);

            }
            cmbParentStore.Items.Add("Select.....");
            cmbParentStore.SelectedIndex = _oStores.Count; 
        }

        private void frmSparePartsStockAdjustment_Load(object sender, EventArgs e) 
        {
            LoadCombos();
            //Clear();
        }

        private void cmbParentStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParentStore.Text != "Select.....")
            {
                _oStores = new Stores();
                _oStores.GetParentStore();
                _oStores.GetLocationByParent(_oStores[cmbParentStore.SelectedIndex].StoreID);
                cmbChildStore.Items.Clear();
                cmbChildStore.Items.Add("Select.....");
                foreach (Store oStore in _oStores)
                {
                    cmbChildStore.Items.Add(oStore.StoreName);
                }
                cmbChildStore.SelectedIndex = 0;
                //cmbChildStore.Items.Add("Select.....");
                //cmbChildStore.SelectedIndex = _oStores.Count;
            }
            else
            {
                cmbChildStore.Items.Clear();
                //cmbChildStore.Items.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
       private void txtChildStore_TextChanged(object sender, EventArgs e)
        {
            //_oStore = new Store();

            //_oStore.GetChildStoreByCode(txtChildStore.Text);

            //if (_oStore.StoreID != 0)
            //{
            //    _oStores = new Stores();
            //    _oStores.RefreshChildStore(_oStore.StoreID);

            //    if (_oStores.GetIndex(_oStore.StoreID) != -1)
            //    {
            //        cmbChildStore.SelectedIndex = _oStores.GetIndex(_oStore.StoreID);
            //    }
            //    else
            //    {
            //        cmbChildStore.Items.Clear();
            //    }
            //}
            ////else
            ////{
            ////    cmbChildStore.SelectedIndex = _oStores.Count - 1;
            ////}
        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvPartAdjustment.Rows)
            {
                if (oItemRow.Index < dgvPartAdjustment.Rows.Count - 1)
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
        private bool ValidateUiInput()
        {
            #region Transaction Master Information Validation
            if (cmbParentStore.Text== "Select.....")
            {
                MessageBox.Show("Please Select Parent Store", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbParentStore.Focus();
                return false;
            }
            if (!rdoAddStock.Checked && !rdoDeductStock.Checked)
            {
                MessageBox.Show("Please select add or deduct stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rdoAddStock.Focus();
                return false;
            }

            #endregion

            #region Transaction Details Information Validation


            if (dgvPartAdjustment.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Spare Parts ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvPartAdjustment.Rows)
            {
                if (oItemRow.Index < dgvPartAdjustment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[7].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Part code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[7].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Part Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[4].Value == null || int.Parse(oItemRow.Cells[4].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    oSPStock = new SPStock();
                    oSPStock.SparePartID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    oSPStock.StoreID = _oStores[cmbChildStore.SelectedIndex - 1].StoreID;
                    oSPStock.CheckStockBySpareID();

                    if (rdoDeductStock.Checked && oSPStock.CurrentStockQty < int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Issue Qty must be less of equal current Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            if (txtRemarks.Text == "")
            {
                MessageBox.Show("Please Input Remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
                return false;
            }
            #endregion
            return true;
        }
        private void Clear()
        {
            TotalQty.Text = "0";
            TotalCostPrice.Text = "0.00";
            cmbParentStore.Text = "Select.....";
            cmbChildStore.Text = "Select.....";
            rdoAddStock.Checked = false;
            rdoDeductStock.Checked = false;
            dgvPartAdjustment.Rows.Clear();

        }

        private void GetTotal()
        {
            TotalQty.Text = "0";
            TotalCostPrice.Text = "0.00";
            

            foreach (DataGridViewRow oRow in dgvPartAdjustment.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {
                    TotalQty.Text = Convert.ToInt32(Convert.ToInt32(TotalQty.Text) + Convert.ToInt32(oRow.Cells[4].Value.ToString())).ToString();
                    TotalCostPrice.Text = Convert.ToDouble(Convert.ToDouble(TotalCostPrice.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString())).ToString();
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                Clear();               
            }
            //this.Close();
        }
        private void Save()
        {
            if (Tag == null)
            {
                oSPTran = new SPTran();
                oSPTran = GetUISPTranData(oSPTran);
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSPTran.Add();
                    if (rdoAddStock.Checked)
                    {
                        GetUISPStockData(true);
                    }
                    else if (rdoDeductStock.Checked)
                    {
                        GetUISPStockData(false);
                    }
                    
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
        private void GetUISPStockData(bool _bFlag)
        {

            foreach (DataGridViewRow oItemRow in dgvPartAdjustment.Rows)
            {
                if (oItemRow.Index < dgvPartAdjustment.Rows.Count - 1)
                {
                    //_Stores
                    int nStockQty = 0;

                    try
                    {
                        nStockQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        nStockQty = 0;
                    }

                    if (nStockQty > 0)
                    {
                        SPStock oItem = new SPStock();

                        try
                        {
                            oItem.AddDeductStockQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            oItem.AddDeductStockQty = Convert.ToInt32(0);
                        }
                        oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        oItem.StoreID = _oStores[cmbChildStore.SelectedIndex - 1].StoreID;

                        oItem.UpdateStock(_bFlag);
                    }
                }
            }
        }
        public SPTran GetUISPTranData(SPTran oSPTran)
        {
            if (rdoAddStock.Checked)
            {
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.AddStock;
            }
            else if (rdoDeductStock.Checked)
            {
                oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.DeductStock;
            }
            if (rdoAddStock.Checked)
            {
                oSPTran.FromStoreID = (int)Dictionary.Store.SystemStore;
                oSPTran.ToStoreID = _oStores[cmbChildStore.SelectedIndex - 1].StoreID;
            }

            else if (rdoDeductStock.Checked)
            {
                oSPTran.FromStoreID= _oStores[cmbChildStore.SelectedIndex - 1].StoreID;
                oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            }
            if (rdoAddStock.Checked)
            {
                oSPTran.TranSide = (int)Dictionary.SparePartTranSide.IN;
            }
            else if (rdoDeductStock.Checked)
            {
                oSPTran.TranSide = (int)Dictionary.SparePartTranSide.OUT;
            }
            oSPTran.Remarks = txtRemarks.Text;
            
            foreach (DataGridViewRow oItemRow in dgvPartAdjustment.Rows)
            {
                if (oItemRow.Index < dgvPartAdjustment.Rows.Count - 1)
                {
                    long nStockQty;
                    try
                    {
                        nStockQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch 
                    {
                        nStockQty = Convert.ToInt64(0);
                    }

                    if (nStockQty > 0)
                    {
                        SPTranDetail oItem = new SPTranDetail
                        {
                            Qty = nStockQty,
                            CostPrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim()),
                            SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim()),
                            SalePrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString().Trim())
                        };

                        oSPTran.Add(oItem);
                    }
                }
            }

            return oSPTran;
        }

        private void dgvPartAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbChildStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Child Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                nSelectedStoreID = _oStores[cmbChildStore.SelectedIndex - 1].StoreID;
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
                    oRow.CreateCells(dgvPartAdjustment);
                    oRow.Cells[0].Value = oForm._oSparePartsR.Code;
                    oRow.Cells[2].Value = oForm._oSparePartsR.Name;
                    oRow.Cells[3].Value = oForm._oSparePartsR.CurrentStock;
                    oRow.Cells[5].Value = oForm._oSparePartsR.CostPrice;
                    oRow.Cells[7].Value = oForm._oSparePartsR.SparePartID;
                    oRow.Cells[8].Value = oForm._oSparePartsR.SalePrice;

                    if (oForm._oSparePartsR != null)
                    {
                        int nRowIndex = dgvPartAdjustment.Rows.Add(oRow);

                        if (checkDuplicateLineItem(dgvPartAdjustment.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvPartAdjustment.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvPartAdjustment.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }
            }
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sSpareCode = "";

            if (nColumnIndex == 0 && dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (cmbChildStore.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Child Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbChildStore.Focus();
                    dgvPartAdjustment.Rows.RemoveAt(nRowIndex);
                    return;
                }
                if (checkDuplicateLineItem(dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Parts Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPartAdjustment.Rows.RemoveAt(nRowIndex);
                    return;
                }

                try
                {
                    sSpareCode = dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();
                    _oSparePartsR = new SparePartsR();
                    _oSparePartsR.Code = sSpareCode;
                    _oSparePartsR.CheckSpareByCode(_oStores[cmbChildStore.SelectedIndex - 1].StoreID);

                    if (_oSparePartsR.Flag != false)
                    {

                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSparePartsR.Name;
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = Convert.ToString(_oSparePartsR.CurrentStock);
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oSparePartsR.CostPrice;
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oSparePartsR.SparePartID).ToString();
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = _oSparePartsR.SalePrice;

                    }
                    else
                    {
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = "";
                        dgvPartAdjustment.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvPartAdjustment.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (nColumnIndex == 4)
            {
                if (dgvPartAdjustment.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvPartAdjustment.Rows[nRowIndex].Cells[4].Value != null)
                {
                    try
                    {
                        dgvPartAdjustment.Rows[nRowIndex].Cells[6].Value = (Convert.ToDouble(dgvPartAdjustment.Rows[nRowIndex].Cells[4].Value.ToString()) * Convert.ToDouble(dgvPartAdjustment.Rows[nRowIndex].Cells[5].Value.ToString()));

                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }

            }
            GetTotal();
        }

        private void dgvPartAdjustment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void cmbChildStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbChildStore.Text != "Select.....")
            //{
            //    //Child Store
            //    _oStores = new Stores();
            //    _oStores.GetParentStore();
            //    _oStores.GetChildStore(_oStores[cmbParentStore.SelectedIndex].StoreID);
            //    //_oStores.GetChildByParent(_oStores[cmbChildStore.SelectedIndex].StoreID);
            //    cmbChildStore.Items.Clear();
            //    foreach (Store oStore in _oStores)
            //    {
            //        cmbChildStore.Items.Add(oStore.StoreName);
            //    }
            //    if (_oStores.Count > 0) cmbChildStore.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbChildStore.Items.Clear();
            //}
        }

        private void dgvPartAdjustment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }
    }
}