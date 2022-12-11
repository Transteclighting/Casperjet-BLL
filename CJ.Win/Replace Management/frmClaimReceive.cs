using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Replace_Management
{
    public partial class frmClaimReceive : Form
    {
        ReplaceClaims _ReplaceClaims;
        ReplaceClaim _ReplaceClaim;
        ProductDetail _oProductDetail;
        int nReplaceClaimID = 0;
        public frmClaimReceive()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            _ReplaceClaims = new ReplaceClaims();
            _ReplaceClaims.GetSubClaim(txtClaimNo.Text.Trim());
            cmbSubClaim.Items.Clear();
            cmbSubClaim.Items.Add("<ALL>");
            foreach (ReplaceClaim oReplaceClaim in _ReplaceClaims)
            {
                cmbSubClaim.Items.Add(oReplaceClaim.SubClaimNo);
            }
            cmbSubClaim.SelectedIndex = 0;

            if (_ReplaceClaims.Count > 0)
            {
                txtClaimNo.Enabled = false;

                ReplaceClaim oReplaceClaim = new ReplaceClaim();
                oReplaceClaim.ReplaceClaimNo = txtClaimNo.Text.Trim();
                oReplaceClaim.RefreshByClaimNo();
                if (oReplaceClaim.ReplaceClaimID != null)
                {
                    nReplaceClaimID = oReplaceClaim.ReplaceClaimID;
                    Customer oCustomer = new Customer();
                    oCustomer.RefreshByID(oReplaceClaim.CustomerID);
                    if (oCustomer.CustomerCode != null)
                    {
                        ctlCustomer1.txtCode.Text = "";
                        ctlCustomer1.txtCode.Text = oCustomer.CustomerCode;
                        ctlCustomer1.Enabled = false;
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput()
        {

            if (txtClaimNo.Text == "")
            {
                MessageBox.Show("Please Enter Claim No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaimNo.Focus();
                return false;
            }
            if (cmbSubClaim.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select SubClaim No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSubClaim.Focus();
                return false;
            }
            if (ctlCustomer1.txtDescription.Text == "")
            {
                MessageBox.Show("Please Select Valid Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtDescription.Focus();
                return false;
            }

            #region Transaction Details Information Validation

            if (dgvClaimItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvClaimItem.Rows)
            {
                if (oItemRow.Index < dgvClaimItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[5].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[4].Value) == null)
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion

            return true;
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
                        _ReplaceClaim = new ReplaceClaim();
                        _ReplaceClaim = GetUIData(_ReplaceClaim);
                        //_ReplaceClaim.UpdateHo(nTranID);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update ClaimNo # " + _ReplaceClaim.ReplaceClaimNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        _ReplaceClaim = new ReplaceClaim();
                        _ReplaceClaim = GetUIData(_ReplaceClaim);
                        _ReplaceClaim.AddReplaceClaim(nReplaceClaimID);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add # " + _ReplaceClaim.ReplaceClaimNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public ReplaceClaim GetUIData(ReplaceClaim _oReplaceClaim)
        {
            _oReplaceClaim.ReplaceClaimNo = txtClaimNo.Text;
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName(dtClaimMonth.Value.Month).ToString();
            _oReplaceClaim.ClaimedMonth = strMonthName;
            _oReplaceClaim.ClaimYear = dtClaimMonth.Value.Year;
            _oReplaceClaim.ClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE;
            _oReplaceClaim.EntryUserID = Utility.UserId;
            _oReplaceClaim.EntryDate = DateTime.Now.Date;
            _oReplaceClaim.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oReplaceClaim.ClaimDate = dtClaimDate.Value.Date;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvClaimItem.Rows)
            {
                if (oItemRow.Index < dgvClaimItem.Rows.Count - 1)
                {
                    ReplaceClaimItem _oItem = new ReplaceClaimItem();
                    _oItem.SubClaimNumber = cmbSubClaim.Text.ToString();
                    _oItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oItem.ClaimedQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oItem.NSP = Convert.ToDouble(oItemRow.Cells[3].Value);
                    _oItem.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE;
                    _ReplaceClaim.Add(_oItem);

                }
            }

            return _ReplaceClaim;
        }

        private void txtClaimNo_TextChanged(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void dgvClaimItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvClaimItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[3].Value = Convert.ToDouble(oForm._oProductDetail.NSP).ToString();
                    oRow.Cells[5].Value = oForm._oProductDetail.ProductID;

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvClaimItem.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvClaimItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvClaimItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvClaimItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }

            }
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvClaimItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = (_oProductDetail.NSP).ToString();
                        dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = (_oProductDetail.ProductID).ToString();
                        dgvClaimItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvClaimItem.Rows.RemoveAt(nRowIndex);
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
            foreach (DataGridViewRow oItemRow in dgvClaimItem.Rows)
            {
                if (oItemRow.Index < dgvClaimItem.Rows.Count - 1)
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

        private void dgvClaimItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
    }
}