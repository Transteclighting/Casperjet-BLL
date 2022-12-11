using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.BEIL
{
    public partial class frmBEILMaterialRequisition : Form
    {
        BEILMaterialRequisition _oBEILMaterialRequisition;
        int nRequisitionID = 0;
        string sRequisitionNo = "";
        int _nType = 0;
        int nProductID = 0;

        public frmBEILMaterialRequisition(int nType)
        {
            _nType = nType;
            InitializeComponent();
        }

        public void ShowDialog(BEILMaterialRequisition oBEILMaterialRequisition)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oBEILMaterialRequisition;

            nRequisitionID = oBEILMaterialRequisition.RequisitionID;
            sRequisitionNo = oBEILMaterialRequisition.RequisitionNo;

            BEILMaterialRequisitionItem oBEILMaterialRequisitionItem = new BEILMaterialRequisitionItem();
            oBEILMaterialRequisitionItem.RequisitionID = nRequisitionID;
            oBEILMaterialRequisitionItem.GetProductCode();
            txtRemarks.Enabled = false;
            txtRemarks.Text = oBEILMaterialRequisition.Remarks;
            ctlProduct1.Enabled = false;
            ctlProduct1.txtCode.Text = oBEILMaterialRequisitionItem.ProductCode;

            oBEILMaterialRequisition.GetItem(nRequisitionID);

            if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
            {

                dgvRequisitionItem.Columns[3].Visible = false;
                dgvRequisitionItem.Columns[4].Visible = false;
                dgvRequisitionItem.Columns[5].Visible = false;
                dgvRequisitionItem.Columns[6].Visible = false;
                
                dgvRequisitionItem.Rows.Clear();
                foreach (BEILMaterialRequisitionItem oItem in oBEILMaterialRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oItem.BOMDescription.ToString();
                    oRow.Cells[1].Value = oItem.CurrentStock.ToString();
                    oRow.Cells[2].Value = oItem.RequisitionQty.ToString();
                    oRow.Cells[7].Value = oItem.ProductID.ToString();
                    oRow.Cells[8].Value = oItem.BOMID.ToString();
                    dgvRequisitionItem.Rows.Add(oRow);
                }

            }
            else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Authorised)
            {
                btnSave.Text = "Authorised";

                dgvRequisitionItem.Columns[2].ReadOnly = true;
                dgvRequisitionItem.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

                dgvRequisitionItem.Columns[3].Visible = true;
                dgvRequisitionItem.Columns[4].Visible = false;
                dgvRequisitionItem.Columns[5].Visible = false;
                dgvRequisitionItem.Columns[6].Visible = false;




                dgvRequisitionItem.Rows.Clear();
                foreach (BEILMaterialRequisitionItem oAuthorisedItem in oBEILMaterialRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oAuthorisedItem.BOMDescription.ToString();
                    oRow.Cells[1].Value = oAuthorisedItem.CurrentStock.ToString();
                    oRow.Cells[2].Value = oAuthorisedItem.RequisitionQty.ToString();
                    oRow.Cells[3].Value = oAuthorisedItem.RequisitionQty.ToString();
                    oRow.Cells[7].Value = oAuthorisedItem.ProductID.ToString();
                    oRow.Cells[8].Value = oAuthorisedItem.BOMID.ToString();
                    dgvRequisitionItem.Rows.Add(oRow);
                }
            }
            else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Approved)
            {
                btnSave.Text = "Approved";
                dgvRequisitionItem.Columns[2].ReadOnly = true;
                dgvRequisitionItem.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[3].ReadOnly = true;
                dgvRequisitionItem.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[4].Visible = true;
                dgvRequisitionItem.Columns[5].Visible = false;
                dgvRequisitionItem.Columns[6].Visible = false;

                dgvRequisitionItem.Rows.Clear();
                foreach (BEILMaterialRequisitionItem oApprovedItem in oBEILMaterialRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oApprovedItem.BOMDescription.ToString();
                    oRow.Cells[1].Value = oApprovedItem.CurrentStock.ToString();
                    oRow.Cells[2].Value = oApprovedItem.RequisitionQty.ToString();
                    oRow.Cells[3].Value = oApprovedItem.AuthorisedQty.ToString();
                    oRow.Cells[4].Value = oApprovedItem.AuthorisedQty.ToString();
                    oRow.Cells[7].Value = oApprovedItem.ProductID.ToString();
                    oRow.Cells[8].Value = oApprovedItem.BOMID.ToString();
                    dgvRequisitionItem.Rows.Add(oRow);
                }
            }
            else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
            {
                btnSave.Text = "Issued";
                dgvRequisitionItem.Columns[2].ReadOnly = true;
                dgvRequisitionItem.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[3].ReadOnly = true;
                dgvRequisitionItem.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[4].ReadOnly = true;
                dgvRequisitionItem.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[5].Visible = true;
                dgvRequisitionItem.Columns[6].Visible = false;

                dgvRequisitionItem.Rows.Clear();
                foreach (BEILMaterialRequisitionItem oIssuedItem in oBEILMaterialRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oIssuedItem.BOMDescription.ToString();
                    oRow.Cells[1].Value = oIssuedItem.CurrentStock.ToString();
                    oRow.Cells[2].Value = oIssuedItem.RequisitionQty.ToString();
                    oRow.Cells[3].Value = oIssuedItem.AuthorisedQty.ToString();
                    oRow.Cells[4].Value = oIssuedItem.ApprovedQty.ToString();
                    oRow.Cells[5].Value = oIssuedItem.ApprovedQty.ToString();
                    oRow.Cells[7].Value = oIssuedItem.ProductID.ToString();
                    oRow.Cells[8].Value = oIssuedItem.BOMID.ToString();
                    dgvRequisitionItem.Rows.Add(oRow);
                }
            }
            else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Received)
            {
                btnSave.Text = "Received";
                dgvRequisitionItem.Columns[2].ReadOnly = true;
                dgvRequisitionItem.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[3].ReadOnly = true;
                dgvRequisitionItem.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[4].ReadOnly = true;
                dgvRequisitionItem.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[5].ReadOnly = true;
                dgvRequisitionItem.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                dgvRequisitionItem.Columns[6].Visible = true;

                dgvRequisitionItem.Rows.Clear();
                foreach (BEILMaterialRequisitionItem oReceivedItem in oBEILMaterialRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oReceivedItem.BOMDescription.ToString();
                    oRow.Cells[1].Value = oReceivedItem.CurrentStock.ToString();
                    oRow.Cells[2].Value = oReceivedItem.RequisitionQty.ToString();
                    oRow.Cells[3].Value = oReceivedItem.AuthorisedQty.ToString();
                    oRow.Cells[4].Value = oReceivedItem.ApprovedQty.ToString();
                    oRow.Cells[5].Value = oReceivedItem.IssuedQty.ToString();
                    oRow.Cells[6].Value = oReceivedItem.IssuedQty.ToString();
                    oRow.Cells[7].Value = oReceivedItem.ProductID.ToString();
                    oRow.Cells[8].Value = oReceivedItem.BOMID.ToString();
                    dgvRequisitionItem.Rows.Add(oRow);
                }
            }

            this.ShowDialog();
        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                _oBEILMaterialRequisition = new BEILMaterialRequisition();
                _oBEILMaterialRequisition.GetBOMList(ctlProduct1.SelectedSerarchProduct.ProductID);
                dgvRequisitionItem.Columns[3].Visible = false;
                dgvRequisitionItem.Columns[4].Visible = false;
                dgvRequisitionItem.Columns[5].Visible = false;
                dgvRequisitionItem.Columns[6].Visible = false;

                dgvRequisitionItem.Rows.Clear();

                foreach (BEILMaterialRequisitionItem oBEILMaterialRequisitionItem in _oBEILMaterialRequisition)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRequisitionItem);
                    oRow.Cells[0].Value = oBEILMaterialRequisitionItem.BOMDescription.ToString();
                    oRow.Cells[1].Value = oBEILMaterialRequisitionItem.CurrentStock.ToString();
                    oRow.Cells[7].Value = oBEILMaterialRequisitionItem.ProductID.ToString();
                    oRow.Cells[8].Value = oBEILMaterialRequisitionItem.BOMID.ToString();
                    dgvRequisitionItem.Rows.Add(oRow);
                }
            }

        }

        private void frmBEILMaterialRequisition_Load(object sender, EventArgs e)
        {

        }

        public BEILMaterialRequisition GetUIData(BEILMaterialRequisition _oBEILMaterialRequisition)
        {
            _oBEILMaterialRequisition.RequisitionDate = DateTime.Now.Date;
            _oBEILMaterialRequisition.FromLocation = (int)Dictionary.SCMBOMStockLocation.BEIL_Production_Floor;
            _oBEILMaterialRequisition.ToLocation = (int)Dictionary.SCMBOMStockLocation.BEIL_Logistics;
            _oBEILMaterialRequisition.CreateUserID = Utility.UserId;
            _oBEILMaterialRequisition.CreateDate = DateTime.Now.Date;
            _oBEILMaterialRequisition.Remarks = txtRemarks.Text;
            _oBEILMaterialRequisition.Status = (int)Dictionary.BEILMaterialRequisitionStatus.Create;


            foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
            {
                if (oItemRow.Index < dgvRequisitionItem.Rows.Count)
                {
                    BEILMaterialRequisitionItem _oBEILMaterialRequisitionItem = new BEILMaterialRequisitionItem();

                    _oBEILMaterialRequisitionItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    _oBEILMaterialRequisitionItem.BOMID = int.Parse(oItemRow.Cells[8].Value.ToString());
                    if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
                    {
                        _oBEILMaterialRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                    }
                    else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Authorised)
                    {
                        _oBEILMaterialRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                        _oBEILMaterialRequisitionItem.AuthorisedQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Approved)
                    {
                        _oBEILMaterialRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                        _oBEILMaterialRequisitionItem.AuthorisedQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                        _oBEILMaterialRequisitionItem.ApprovedQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
                    {
                        _oBEILMaterialRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                        _oBEILMaterialRequisitionItem.AuthorisedQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                        _oBEILMaterialRequisitionItem.ApprovedQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                        _oBEILMaterialRequisitionItem.IssuedQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    else if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Received)
                    {
                        _oBEILMaterialRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                        _oBEILMaterialRequisitionItem.AuthorisedQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                        _oBEILMaterialRequisitionItem.ApprovedQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                        _oBEILMaterialRequisitionItem.IssuedQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                        _oBEILMaterialRequisitionItem.ReceivedQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    _oBEILMaterialRequisition.Add(_oBEILMaterialRequisitionItem);

                }
            }

            return _oBEILMaterialRequisition;
        }

        private bool UIValidation()
        {
            #region ValidInput

            if (ctlProduct1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }


            #endregion

            #region ProductDetail
            if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
            {
                #region ProductDetail
                foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
                {
                    if (oItemRow.Index < dgvRequisitionItem.Rows.Count)
                    {
                        int nApprovedQty = 0;
                        int nIssuedQty = 0;
                        int nCurrentStock = 0;

                        if (oItemRow.Cells[1].Value != null || oItemRow.Cells[1].Value.ToString().Trim() != "")
                        {
                            nCurrentStock = int.Parse(oItemRow.Cells[1].Value.ToString());
                        }

                        if (oItemRow.Cells[4].Value != null || oItemRow.Cells[4].Value != "")
                        {
                            nApprovedQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                        }

                        if (oItemRow.Cells[5].Value != null || oItemRow.Cells[5].Value.ToString().Trim() != "")
                        {
                            nIssuedQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                        }

                        if (nCurrentStock >= nIssuedQty)
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            MessageBox.Show("IssuedQty must be less or equal CurrentStock", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (nApprovedQty >= nIssuedQty)
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                            MessageBox.Show("IssuedQty must be less or equal ApprovedQty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                #endregion
            }
            #endregion

            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oBEILMaterialRequisition = new BEILMaterialRequisition();

                        _oBEILMaterialRequisition = GetUIData(_oBEILMaterialRequisition);
                        _oBEILMaterialRequisition.Edit(nRequisitionID, _nType);

                        if (_nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
                        {
                            // Update Stock BEIL Logistics

                            foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
                            {
                                if (oItemRow.Index < dgvRequisitionItem.Rows.Count)
                                {

                                    SCMBOMStock oItem = new SCMBOMStock();

                                    oItem.LocationID = (int)Dictionary.SCMBOMStockLocation.BEIL_Logistics;
                                    oItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                    oItem.BOMID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                    oItem.GRDQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                                    oItem.UpdateCurrentStock_GRD(false);
                                }
                            }

                            // Add Stock BEIL Production Floor
                            foreach (DataGridViewRow oItemRow in dgvRequisitionItem.Rows)
                            {
                                if (oItemRow.Index < dgvRequisitionItem.Rows.Count)
                                {

                                    SCMBOMStock oItem = new SCMBOMStock();

                                    oItem.LocationID = (int)Dictionary.SCMBOMStockLocation.BEIL_Production_Floor;
                                    oItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                    oItem.BOMID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                    oItem.GRDQty = int.Parse(oItemRow.Cells[5].Value.ToString());

                                    if (oItem.CheckBOMStock())
                                        oItem.UpdateCurrentStock_GRD(true);
                                    else
                                    {
                                        oItem.Add();
                                        oItem.UpdateCurrentStock_GRD(true);
                                    }
                                }
                            }
                        }

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update Requisition. RequisitionNo # " + sRequisitionNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oBEILMaterialRequisition = new BEILMaterialRequisition();

                        _oBEILMaterialRequisition = GetUIData(_oBEILMaterialRequisition);
                        _oBEILMaterialRequisition.Add();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update Requisition. RequisitionNo # " + _oBEILMaterialRequisition.RequisitionNo.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}