using System;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.POS.RT
{
    public partial class frmPOSOfficeItemTran : Form
    {
        OfficeItemTran _oOfficeItemTran;
        string sTranNo = "";
        OfficeItem _oOfficeItem;
        int nTranID = 0;
        int nWarehouseID = 0;
        int nTranType = 0;
        public frmPOSOfficeItemTran()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombos()
        {

            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.StationaryTranType)))
            {
                cmbTranType.Items.Add(Enum.GetName(typeof(Dictionary.StationaryTranType), GetEnum));
            }
            cmbTranType.SelectedIndex = 0;

        }
        private bool validateUIInput()
        {
            #region Transaction Details Information Validation

            if (dgvOfficeItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvOfficeItem.Rows)
            {
                if (oItemRow.Index < dgvOfficeItem.Rows.Count - 1)
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

                        _oOfficeItemTran = new OfficeItemTran();
                        _oOfficeItemTran = GetUIData(_oOfficeItemTran);
                        _oOfficeItemTran.UpdatePOS(nTranID);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update Stock Requisition # " + sTranNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        _oOfficeItemTran = new OfficeItemTran();
                        _oOfficeItemTran = GetUIData(_oOfficeItemTran);
                        _oOfficeItemTran.InsertOfficeTranRT(cmbTranType.SelectedIndex + 1);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Office Item # " + _oOfficeItemTran.TranNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void frmPOSOfficeItemTran_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Transection";
                LoadCombos();
            }
            else
            {
                this.Text = "Edit Transection";
            }
        }
        private void dgvOfficeItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void dgvOfficeItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmOfficeItemSarch oForm = new frmOfficeItemSarch();
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOfficeItem);

                oRow.Cells[0].Value = oForm.sCode;
                oRow.Cells[2].Value = oForm.sArticlesName;
                oRow.Cells[4].Value = oForm.sId;

                if (oForm.sCode != null)
                {
                    int nRowIndex = dgvOfficeItem.Rows.Add(oRow);

                    if (checkDuplicateOfficeItem(dgvOfficeItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvOfficeItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvOfficeItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }

                    cmbTranType.Enabled = false;

                }

            }
        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 0 && dgvOfficeItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvOfficeItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvOfficeItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sCode = dgvOfficeItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oOfficeItem = new OfficeItem();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    _oOfficeItem.Code = sCode;
                    _oOfficeItem.RefreshByCode();

                    if (_oOfficeItem.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvOfficeItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvOfficeItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oOfficeItem.ArticlesName;
                    dgvOfficeItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oOfficeItem.ID).ToString();

                    dgvOfficeItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                    cmbTranType.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


        }
        private int checkDuplicateOfficeItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvOfficeItem.Rows)
            {
                if (oItemRow.Index < dgvOfficeItem.Rows.Count - 1)
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
        public void ShowDialog(OfficeItemTran oOfficeItemTran)
        {
            this.Tag = oOfficeItemTran;
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            nTranID = 0;
            nWarehouseID = 0;
            nTranID = oOfficeItemTran.TranID;
            nWarehouseID = oOfficeItemTran.WarehouseID;
            sTranNo = oOfficeItemTran.TranNo;
            oOfficeItemTran.GetOfficeItem(oOfficeItemTran.TranID);
            nTranType = oOfficeItemTran.TranTypeID;
            cmbTranType.SelectedIndex = nTranType-1;
            cmbTranType.Enabled = false;
            txtRemarks.Text = oOfficeItemTran.Remarks;

            foreach (OfficeItemTranDetail oOfficeItemTranDetail in oOfficeItemTran)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOfficeItem);
                oRow.Cells[0].Value = oOfficeItemTranDetail.Code.ToString();
                oRow.Cells[2].Value = oOfficeItemTranDetail.ArticlesName.ToString();
                oRow.Cells[3].Value = oOfficeItemTranDetail.RequisitionQty.ToString();
                oRow.Cells[4].Value = oOfficeItemTranDetail.ID.ToString();
                dgvOfficeItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }
        public OfficeItemTran GetUIData(OfficeItemTran _oOfficeItemTran)
        {
            _oOfficeItemTran.TranTypeID = cmbTranType.SelectedIndex + 1;
            _oOfficeItemTran.DepartmentID = 82975;
            if (Utility.CompanyInfo == "TEL")
            {
                _oOfficeItemTran.CompanyID = 82941;
            }
            else
            {
                _oOfficeItemTran.CompanyID = 82944;
            }
            _oOfficeItemTran.EmployeeID = 0;
            _oOfficeItemTran.WarehouseID = Utility.WarehouseID;
            _oOfficeItemTran.Remarks = txtRemarks.Text;
            _oOfficeItemTran.Terminal = (int)Dictionary.Terminal.Branch_Office;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvOfficeItem.Rows)
            {
                if (oItemRow.Index < dgvOfficeItem.Rows.Count - 1)
                {

                    OfficeItemTranDetail _oOfficeItemTranDetail = new OfficeItemTranDetail();

                    _oOfficeItemTranDetail.ID = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oOfficeItemTranDetail.RequisitionQty = int.Parse(oItemRow.Cells[3].Value.ToString());

                    _oOfficeItemTran.Add(_oOfficeItemTranDetail);

                }
            }

            return _oOfficeItemTran;
        }
    }
}