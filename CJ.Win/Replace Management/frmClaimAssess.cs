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
    public partial class frmClaimAssess : Form
    {
        int nReplaceClaimID = 0;
        int nColCount = 0;
        string sMAGName = "";
        public frmClaimAssess()
        {
            InitializeComponent();
        }
        public void ShowDialog(ReplaceClaim oReplaceClaim)
        {
            this.Tag = oReplaceClaim;
            DBController.Instance.OpenNewConnection();
            this.Text = "Replacement Claim Assess";
            nReplaceClaimID = oReplaceClaim.ReplaceClaimID;
            txtClaimNo.Text = oReplaceClaim.ReplaceClaimNo;
            txtSubClaimNo.Text = oReplaceClaim.SubClaimNo;
            txtClaimMonth.Text = oReplaceClaim.ClaimedMonth;
            txtClaimDate.Text = oReplaceClaim.ClaimDate.ToString("dd-MMM-yyyy");
            txtCustomer.Text = oReplaceClaim.CustomerName;
            oReplaceClaim.GetClaimMAG(oReplaceClaim.SubClaimNo.ToString());
            sMAGName = oReplaceClaim.MAGName;
            LoadData(oReplaceClaim.MAGName);
            oReplaceClaim.RefreshClaimItem(oReplaceClaim.SubClaimNo);


            foreach (ReplaceClaimItem oItem in oReplaceClaim)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvClaimAssess);

                oRow.Cells[0].Value = oItem.ReplaceClaimID.ToString();
                oRow.Cells[1].Value = oItem.SubClaimNumber.ToString();
                oRow.Cells[2].Value = oItem.ProductID.ToString();
                oRow.Cells[3].Value = oItem.ProductCode.ToString();
                oRow.Cells[4].Value = oItem.ProductName.ToString();
                oRow.Cells[5].Value = oItem.ClaimedQty.ToString();

                dgvClaimAssess.Rows.Add(oRow);

            }
            this.ShowDialog();
        }
        public void LoadData(string sMAGName)
        {

            DataGridViewTextBoxColumn txtReplaceClaimID = new DataGridViewTextBoxColumn();
            txtReplaceClaimID.HeaderText = "ReplaceClaimID";
            txtReplaceClaimID.Width = 80;
            txtReplaceClaimID.Visible = false;
            dgvClaimAssess.Columns.Add(txtReplaceClaimID);

            DataGridViewTextBoxColumn txtSubClaimNo = new DataGridViewTextBoxColumn();
            txtSubClaimNo.HeaderText = "SubClaimNo";
            txtSubClaimNo.Width = 80;
            txtSubClaimNo.Visible = false;
            dgvClaimAssess.Columns.Add(txtSubClaimNo);

            DataGridViewTextBoxColumn txtProductID = new DataGridViewTextBoxColumn();
            txtProductID.HeaderText = "ProductID";
            txtProductID.Width = 80;
            txtProductID.Visible = false;
            dgvClaimAssess.Columns.Add(txtProductID);


            DataGridViewTextBoxColumn txtProductCode = new DataGridViewTextBoxColumn();
            txtProductCode.HeaderText = "Product Code";
            txtProductCode.Width = 70;
            dgvClaimAssess.Columns.Add(txtProductCode);

            DataGridViewTextBoxColumn txtProductName = new DataGridViewTextBoxColumn();
            txtProductName.HeaderText = "Product Name";
            txtProductName.Width = 140;
            dgvClaimAssess.Columns.Add(txtProductName);

            DataGridViewTextBoxColumn txtClaimQty = new DataGridViewTextBoxColumn();
            txtClaimQty.HeaderText = "Claim Qty";
            txtClaimQty.Width = 70;
            dgvClaimAssess.Columns.Add(txtClaimQty);


            ProductGroups _oProductGroups = new ProductGroups();
            _oProductGroups.GetReplaceFaultType(sMAGName.ToString());
            foreach (ProductGroup ProductGroup in _oProductGroups)
            {
                //string sObject = "txt" + ProductGroup.FaultTypeName;
                DataGridViewTextBoxColumn sObject = new DataGridViewTextBoxColumn();
                sObject.HeaderText = ProductGroup.FaultTypeName;
                sObject.Width = 80;
                dgvClaimAssess.Columns.Add(sObject);

            }
            nColCount = _oProductGroups.Count;
        }

        private void frmClaimAssess_Load(object sender, EventArgs e)
        {

        }

        private bool UIValidation()
        {
            #region ValidInput

            if (txtSubClaimNo.Text == "")
            {
                MessageBox.Show("Please select valid sub-claim number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubClaimNo.Focus();
                return false;
            }
            #endregion

            #region ProductDetail
            //foreach (DataGridViewRow oItemRow in dgvClaimAssess.Rows)
            //{
            //    if (oItemRow.Index < dgvClaimAssess.Rows.Count)
            //    {
            //        if (oItemRow.Cells[7].Value != null || oItemRow.Cells[7].Value != null)
            //        {
            //            if (oItemRow.Cells[2].Value == null)
            //            {
            //                MessageBox.Show("Please Input Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //            if (oItemRow.Cells[2].Value == "")
            //            {
            //                MessageBox.Show("Please Input Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }

            //    }
            //}
            #endregion

            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvClaimAssess.Rows)
                    {
                        if (oItemRow.Index < dgvClaimAssess.Rows.Count)
                        {
                            ReplaceClaimItem _oItem = new ReplaceClaimItem();
                            _oItem.ReplaceClaimID = int.Parse(oItemRow.Cells[0].Value.ToString());
                            _oItem.SubClaimNumber = oItemRow.Cells[1].Value.ToString();
                            _oItem.ProductID = int.Parse(oItemRow.Cells[2].Value.ToString());

                            int nCount = 6;
                            for (int i = 1; i <= nColCount; i++)
                            {
                                string sFaultType = dgvClaimAssess.Columns[nCount].HeaderText;
                                ProductGroup _oProductGroup = new ProductGroup();
                                _oItem.FaultTypeID = _oProductGroup.GetFaultTypeID(sFaultType, sMAGName);
                                try
                                {
                                    _oItem.ClaimedQty = int.Parse(oItemRow.Cells[nCount].Value.ToString());
                                }
                                catch
                                {
                                    _oItem.ClaimedQty = 0;
                                }
                                if (_oItem.ClaimedQty > 0)
                                {
                                    _oItem.AddClaimAssessQuantity();
                                }
                                nCount++;
                            }
                        }
                    }
                    ReplaceClaim oReplaceClaim = new ReplaceClaim();
                    oReplaceClaim.SubClaimStatus = (int)Dictionary.ReplacementStatus.REPLACEMENT_CLAIM_ASSESSMENT_COMPLETE;
                    oReplaceClaim.SubClaimNo = txtSubClaimNo.Text;
                    oReplaceClaim.UpdateClaimItemStatus();
                    oReplaceClaim.UpdateClaimNoStatusStatus();
                    oReplaceClaim.ValidationDate = Convert.ToDateTime(dtValidationDate.Value.Date);
                    oReplaceClaim.UpdateClaimItem();
                    DBController.Instance.CommitTran();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}