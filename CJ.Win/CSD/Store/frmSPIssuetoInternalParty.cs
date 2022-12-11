using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;


namespace CJ.Win.CSD.Store
{
    public partial class frmSPIssuetoInternalParty : Form
    {
        Stores _oStores;
        Stores _oInternalPartys;
        SPStock oSPStock;
        int nSelectedStoreID = 0;
        SparePartsR _oSparePartsR;
        SPTran oSPTran;

        public frmSPIssuetoInternalParty()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Stores
            _oStores = new Stores();
            _oStores.RefreshChildStore();
            cmbStore.Items.Clear();
            cmbStore.Items.Add("<Select Store>");
            foreach (CJ.Class.Store oStore1 in _oStores)
            {
                cmbStore.Items.Add(oStore1.ChildSotre);
            }
            cmbStore.SelectedIndex = 0;

            //Internal Partys
            _oInternalPartys = new Stores();
            _oInternalPartys.RefreshInternalParty();
            cmbPartyName.Items.Clear();
            cmbPartyName.Items.Add("<Select Internal Party>");
            foreach (CJ.Class.Store oStore in _oInternalPartys)
            {
                cmbPartyName.Items.Add(oStore.InternalPartyName);
            }
            cmbPartyName.SelectedIndex = 0;

        }

        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
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

        private void dgvIssuePart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                nSelectedStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
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
                    oRow.CreateCells(dgvIssuePart);
                    oRow.Cells[0].Value = oForm._oSparePartsR.Code;
                    oRow.Cells[2].Value = oForm._oSparePartsR.Name;
                    oRow.Cells[3].Value = oForm._oSparePartsR.CurrentStock;
                    oRow.Cells[5].Value = oForm._oSparePartsR.SalePrice;
                    oRow.Cells[7].Value = oForm._oSparePartsR.SparePartID;
                    oRow.Cells[8].Value = oForm._oSparePartsR.CostPrice;

                    if (oForm._oSparePartsR != null)
                    {
                        int nRowIndex = dgvIssuePart.Rows.Add(oRow);

                        if (checkDuplicateLineItem(dgvIssuePart.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvIssuePart.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvIssuePart.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }
            }
        }

        private void dgvIssuePart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }

        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sSpareCode = "";


            if (nColumnIndex == 0 && dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (cmbStore.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStore.Focus();
                    dgvIssuePart.Rows.RemoveAt(nRowIndex);
                    return;
                }
                if (checkDuplicateLineItem(dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Parts Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvIssuePart.Rows.RemoveAt(nRowIndex);
                    return;
                }

                try
                {
                    sSpareCode = dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oSparePartsR = new SparePartsR();
                    _oSparePartsR.Code = sSpareCode;
                    _oSparePartsR.CheckSpareByCode(_oStores[cmbStore.SelectedIndex - 1].StoreID);

                    if (_oSparePartsR.Flag != false)
                    {

                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oSparePartsR.Name;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = Convert.ToString(_oSparePartsR.CurrentStock);
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oSparePartsR.SalePrice;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oSparePartsR.SparePartID).ToString();
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = _oSparePartsR.CostPrice;

                    }
                    else
                    {
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = "";
                        dgvIssuePart.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;

                        MessageBox.Show("Spare Part Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvIssuePart.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Part Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (nColumnIndex == 4)
            {
                if (dgvIssuePart.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvIssuePart.Rows[nRowIndex].Cells[4].Value != null)
                {
                    try
                    {
                        dgvIssuePart.Rows[nRowIndex].Cells[6].Value = (Convert.ToDouble(dgvIssuePart.Rows[nRowIndex].Cells[4].Value.ToString()) * Convert.ToDouble(dgvIssuePart.Rows[nRowIndex].Cells[5].Value.ToString()));

                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Part Quantity or Unit Price Should be Greater/Equal Zero");

                    }
                }

            }

        }

        private bool validateUIInput()
        {
            #region Transaction Master Information Validation
            if (cmbPartyName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Technician", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPartyName.Focus();
                return false;
            }
            #endregion

            #region Transaction Details Information Validation

            if (dgvIssuePart.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Spare Parts ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
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
                    oSPStock.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
                    oSPStock.CheckStockBySpareID();

                    if (oSPStock.CurrentStockQty < int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Issue Qty must be less of equal current Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                oSPTran = new SPTran();
                oSPTran = GetUISPTranData(oSPTran);
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSPTran.Add();
                    GetUISPStockData(false);
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

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
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
                        oItem.StoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;

                        oItem.UpdateStock(_bFlag);
                    }
                }
            }
        }

        public SPTran GetUISPTranData(SPTran oSPTran)
        {
            oSPTran.TranTypeID = (int)Dictionary.SparePartTranType.IssueToInternalParty;
            oSPTran.FromStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;
            oSPTran.ToStoreID = (int)Dictionary.Store.SystemStore;
            oSPTran.TranSide = (int)Dictionary.SparePartTranSide.OUT;
            oSPTran.Remarks = txtRemarks.Text;
            oSPTran.Status = (int)Dictionary.SparePartTranStatus.Create;
            oSPTran.InternalPartyID = _oInternalPartys[cmbPartyName.SelectedIndex - 1].InternalPartyID;

            foreach (DataGridViewRow oItemRow in dgvIssuePart.Rows)
            {
                if (oItemRow.Index < dgvIssuePart.Rows.Count - 1)
                {
                    long nStockQty = 0;
                    try
                    {
                        nStockQty = Convert.ToInt64(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        nStockQty = Convert.ToInt64(0);
                    }

                    if (nStockQty > 0)
                    {
                        SPTranDetail oItem = new SPTranDetail();

                        oItem.Qty = nStockQty;
                        oItem.SalePrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());
                        oItem.SparePartID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        oItem.CostPrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString().Trim());
                        oSPTran.Add(oItem);
                    }
                }
            }

            return oSPTran;
        }

        private void frmSPIssuetoInternalParty_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}