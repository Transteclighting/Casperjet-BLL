using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;
using CJ.Class.Library;

namespace CJ.Win.BEIL
{
    public partial class frmProductionLot : Form
    {
        ProductDetail _oProductDetail;
        TELLib _oTELLib;
        ProductionLot _oProductionLot;
        int nLotID = 0;
        string sLotNo = "";
        ProductionLots _oProductionLots;
        int nRefLotID = 0;

        public frmProductionLot()
        {
            InitializeComponent();
        }

        private void frmProductionLot_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Lot";
                LoadCombos();
                cmbRfLotNo.Visible = false;
                lblRfNo.Visible = false;
            }
            else
            {
                this.Text = "Edit Lot";
            }
        }
        private void LoadCombos()
        {
            //Lot Type
            cmbLotType.Items.Clear();
            cmbLotType.Items.Add("--Select Lot Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionLotType)))
            {
                cmbLotType.Items.Add(Enum.GetName(typeof(Dictionary.ProductionLotType), GetEnum));
            }
            cmbLotType.SelectedIndex = 0;

            //Work Type
            cmbWorkType.Items.Clear();
            cmbWorkType.Items.Add("--Select Work Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionWorkType)))
            {
                cmbWorkType.Items.Add(Enum.GetName(typeof(Dictionary.ProductionWorkType), GetEnum));
            }
            cmbWorkType.SelectedIndex = 0;
        }
        public void ShowDialog(ProductionLot oProductionLot)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oProductionLot;
            LoadCombos();
            nLotID = 0;
            nLotID = oProductionLot.LotID;
            sLotNo = "";
            sLotNo = oProductionLot.LotNo;
            nRefLotID = oProductionLot.RefLotID;
            oProductionLot.GetLotItem(nLotID);
            cmbLotType.SelectedIndex = oProductionLot.LotType;
            cmbWorkType.SelectedIndex = oProductionLot.WorkType;
            if (cmbWorkType.Text == "Rework")
            {
                cmbRfLotNo.Visible = true;
                lblRfNo.Visible = true;
                txtRefNo.Enabled = false;
                dgvLotItem.Enabled = false;
                cmbRfLotNo.SelectedIndex = _oProductionLots.GetIndex(nRefLotID) + 1; //_oProductionLots.GetIndex[nRefLotID];
                cmbRfLotNo.Enabled = false;
                cmbWorkType.Enabled = false;
            }
            else
            {
                cmbRfLotNo.Visible = false;
                lblRfNo.Visible = false;
                txtRefNo.Enabled = true;
                cmbWorkType.Enabled = true;
            }

            txtRefNo.Text = oProductionLot.RefNo;
            dtReceiveDate.Value = oProductionLot.ReceiveDate.Date;
            txtRemarks.Text = oProductionLot.Remarks;


            foreach (ProductionLotItem oProductionLotItem in oProductionLot)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLotItem);
                oRow.Cells[0].Value = oProductionLotItem.ProductCode.ToString();
                oRow.Cells[2].Value = oProductionLotItem.ProductName.ToString();
                oRow.Cells[3].Value = oProductionLotItem.ReceiveQty.ToString();
                oRow.Cells[4].Value = oProductionLotItem.ProductID.ToString();

                dgvLotItem.Rows.Add(oRow);
            }
            GetTotalPOQty();


            this.ShowDialog();
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

                        _oProductionLot = new ProductionLot();
                        _oProductionLot = GetUIData(_oProductionLot);
                        _oProductionLot.Edit(nLotID);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update Production Lot. Lot # " + sLotNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        _oProductionLot = new ProductionLot();
                        _oProductionLot = GetUIData(_oProductionLot);
                        _oProductionLot.Add();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Lot # " + _oProductionLot.LotNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvLotItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLotItem);

                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[4].Value = oForm.sProductId;

                if (oForm.sProductCode != null)
                {
                    int nRowIndex = dgvLotItem.Rows.Add(oRow);

                    if (checkDuplicateOfficeItem(dgvLotItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLotItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvLotItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }
                    GetTotalPOQty();


                }

            }
        }

        private void dgvLotItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
            GetTotalPOQty();
        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLotItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvLotItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLotItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLotItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLotItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvLotItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                    dgvLotItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oProductDetail.ProductID).ToString();

                    dgvLotItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    cmbLotType.Enabled = false;
                    cmbWorkType.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Produt Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


        }
        private int checkDuplicateOfficeItem(string ProductCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLotItem.Rows)
            {
                if (oItemRow.Index < dgvLotItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ProductCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void dgvLotItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalPOQty();

        }

        public void GetTotalPOQty()
        {
            txtTotalQty.Text = "0";
            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLotItem.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
            }

        }
        private bool UIValidation()
        {
            #region ValidInput

            if (cmbLotType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Lot Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLotType.Focus();
                return false;
            }

            if (cmbWorkType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Work Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWorkType.Focus();
                return false;
            }
            if (txtRefNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Ref. No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return false;
            }
            if (cmbWorkType.Text == "Rework")
            {
                if (cmbRfLotNo.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Ref. LotNo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRfLotNo.Focus();
                    return false;
                }
            }

            #endregion

            #region Transaction Details Information Validation

            if (dgvLotItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLotItem.Rows)
            {
                if (oItemRow.Index < dgvLotItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[4].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[4].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please Input Lot Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Lot Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;

        }

        public ProductionLot GetUIData(ProductionLot _oProductionLot)
        {
            _oProductionLot.LotType = cmbLotType.SelectedIndex;
            _oProductionLot.WorkType = cmbWorkType.SelectedIndex;
            _oProductionLot.RefNo = txtRefNo.Text;
            _oProductionLot.ReceiveDate = dtReceiveDate.Value.Date;
            _oProductionLot.Remarks = txtRemarks.Text;
            _oProductionLot.CreateDate = DateTime.Now.Date;
            _oProductionLot.CreateUserID = Utility.UserId;
            _oProductionLot.Status = (int)Dictionary.ProductionStatus.Create;
            if (cmbWorkType.Text == "Rework")
            {
                _oProductionLot.RefLotID = _oProductionLots[cmbRfLotNo.SelectedIndex - 1].LotID;
            }
            else
            {
                _oProductionLot.RefLotID = 0;
            }

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvLotItem.Rows)
            {
                if (oItemRow.Index < dgvLotItem.Rows.Count - 1)
                {

                    ProductionLotItem _oProductionLotItem = new ProductionLotItem();

                    _oProductionLotItem.ProductID = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oProductionLotItem.ReceiveQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                    _oProductionLot.Add(_oProductionLotItem);

                }
            }

            return _oProductionLot;
        }

        private void cmbWorkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                if (cmbWorkType.Text == "Rework")
                {
                    cmbRfLotNo.Visible = true;
                    lblRfNo.Visible = true;
                    txtRefNo.Enabled = false;
                    dgvLotItem.Enabled = false;
                    _oProductionLots = new ProductionLots();
                    _oProductionLots.GetLotForRework();
                    cmbRfLotNo.Items.Clear();
                    cmbRfLotNo.Items.Add("<All>");
                    foreach (ProductionLot oProductionLot in _oProductionLots)
                    {
                        cmbRfLotNo.Items.Add(oProductionLot.LotNo);
                    }
                    cmbRfLotNo.SelectedIndex = 0;
                }
                else
                {
                    cmbRfLotNo.Visible = false;
                    lblRfNo.Visible = false;
                    txtRefNo.Enabled = true;
                    dgvLotItem.Enabled = true;
                }
            }
            else
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                if (cmbWorkType.Text == "Rework")
                {
                    cmbRfLotNo.Visible = true;
                    lblRfNo.Visible = true;
                    txtRefNo.Enabled = false;

                    _oProductionLots = new ProductionLots();
                    _oProductionLots.GetLotForReworkEdit(nRefLotID);
                    cmbRfLotNo.Items.Clear();
                    cmbRfLotNo.Items.Add("<All>");
                    foreach (ProductionLot oProductionLot in _oProductionLots)
                    {
                        cmbRfLotNo.Items.Add(oProductionLot.LotNo);
                    }
                    cmbRfLotNo.SelectedIndex = 0;
                }
                else
                {
                    cmbRfLotNo.Visible = false;
                    lblRfNo.Visible = false;
                    txtRefNo.Enabled = true;
                }

            }
        }

        private void cmbRfLotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                dgvLotItem.Rows.Clear();
                txtRefNo.Text = "";
                if (cmbRfLotNo.SelectedIndex != 0)
                {
                    _oProductionLot = new ProductionLot();
                    _oProductionLot.GetLotItemForRework(_oProductionLots[cmbRfLotNo.SelectedIndex - 1].LotID);
                    txtRefNo.Text = _oProductionLots[cmbRfLotNo.SelectedIndex - 1].RefNo;

                    foreach (ProductionLotItem oProductionLotItem in _oProductionLot)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLotItem);
                        oRow.Cells[0].Value = oProductionLotItem.ProductCode.ToString();
                        oRow.Cells[2].Value = oProductionLotItem.ProductName.ToString();
                        oRow.Cells[3].Value = oProductionLotItem.QCFailQty.ToString();
                        oRow.Cells[4].Value = oProductionLotItem.ProductID.ToString();
                        dgvLotItem.Rows.Add(oRow);
                    }
                    GetTotalPOQty();
                }
            }

        }

    }
}