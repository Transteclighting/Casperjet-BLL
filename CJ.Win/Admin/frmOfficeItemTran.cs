using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.Win.Admin
{
    public partial class frmOfficeItemTran : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private Employee  _oEmployee;
        OfficeItemTran _oOfficeItemTran;
        string sTranNo = "";
        OfficeItem _oOfficeItem;
        int nTranID = 0;
        int nWarehouseID = 0;
        int nTranType = 0;

        public frmOfficeItemTran()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombos()
        {
            //Department
            _oDepartments = new Departments();
            
            _oDepartments.Refresh();

            cmbDepartment.Items.Clear();
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            //Company
            _oCompanys = new Companys();
            //DBController.Instance.OpenNewConnection();
            _oCompanys.Refresh();

            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;


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

            if (dgvStationaryItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvStationaryItem.Rows)
            {
                if (oItemRow.Index < dgvStationaryItem.Rows.Count - 1)
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
        private void frmOfficeItemTran_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Transection";
                DBController.Instance.OpenNewConnection();
                LoadCombos();
            }
            else
            {
                this.Text = "Edit Transection";
            }

        }
        private void dgvStationaryItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void dgvStationaryItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmOfficeItemSarch oForm = new frmOfficeItemSarch();
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvStationaryItem);

                oRow.Cells[0].Value = oForm.sCode;
                oRow.Cells[2].Value = oForm.sArticlesName;
                oRow.Cells[4].Value = oForm.sId;

                if (oForm.sCode != null)
                {
                    int nRowIndex = dgvStationaryItem.Rows.Add(oRow);


                    //nRowIndex = dgvStationaryItem.Rows.Add(oRow);
                    if (checkDuplicateOfficeItem(dgvStationaryItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvStationaryItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvStationaryItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }

                    cmbCompany.Enabled = false;
                    cmbDepartment.Enabled = false;
                    cmbTranType.Enabled = false;

                }

            }
        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 0 && dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvStationaryItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sCode = dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oOfficeItem = new OfficeItem();
                    DBController.Instance.OpenNewConnection();
                    _oOfficeItem.Code = sCode;
                    _oOfficeItem.RefreshByCode();

                    if (_oOfficeItem.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvStationaryItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oOfficeItem.ArticlesName;
                    dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oOfficeItem.ID).ToString();

                    dgvStationaryItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    cmbCompany.Enabled = false;
                    cmbDepartment.Enabled = false;
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
            foreach (DataGridViewRow oItemRow in dgvStationaryItem.Rows)
            {
                if (oItemRow.Index < dgvStationaryItem.Rows.Count - 1)
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
                        _oOfficeItemTran.UpdateHo(nTranID);

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
                        _oOfficeItemTran.InsertOfficeTran(cmbTranType.SelectedIndex + 1);
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
        public void ShowDialog(OfficeItemTran oOfficeItemTran)
        {
            this.Tag = oOfficeItemTran;
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            
            nTranID = 0;
            nWarehouseID = 0;
            sTranNo = "";

            nTranID = oOfficeItemTran.TranID;
            sTranNo = oOfficeItemTran.TranNo;
            nWarehouseID = oOfficeItemTran.WarehouseID;
            sTranNo = oOfficeItemTran.TranNo;
            oOfficeItemTran.GetOfficeItem(oOfficeItemTran.TranID);
            ctlEmployee.txtCode.Text = oOfficeItemTran.EmployeeCode;
            nTranType = oOfficeItemTran.TranTypeID;
            cmbTranType.SelectedIndex = nTranType - 1;
  
            int nDepartmentIndex = 0;
            nDepartmentIndex = _oDepartments.GetIndex(oOfficeItemTran.DepartmentID);
            //nDepartmentIndex = oOfficeItemTran.DepartmentID;
            cmbDepartment.SelectedIndex = nDepartmentIndex ;
            int nCompanyIndex = 0;
            nCompanyIndex = _oCompanys.GetIndex(oOfficeItemTran.CompanyID);
            //nCompanyIndex = oOfficeItemTran.CompanyID;
            cmbCompany.SelectedIndex = nCompanyIndex ;
            cmbCompany.Enabled = false;
            cmbDepartment.Enabled = false;
            cmbTranType.Enabled = false;

            txtRemarks.Text = oOfficeItemTran.Remarks;

            foreach (OfficeItemTranDetail oOfficeItemTranDetail in oOfficeItemTran)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvStationaryItem);
                oRow.Cells[0].Value = oOfficeItemTranDetail.Code.ToString();
                oRow.Cells[2].Value = oOfficeItemTranDetail.ArticlesName.ToString();
                oRow.Cells[3].Value = oOfficeItemTranDetail.RequisitionQty.ToString();
                oRow.Cells[4].Value = oOfficeItemTranDetail.ID.ToString();
                dgvStationaryItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }
        public OfficeItemTran GetUIData(OfficeItemTran _oOfficeItemTran)
        {
            _oOfficeItemTran.TranTypeID = cmbTranType.SelectedIndex + 1;
            _oOfficeItemTran.DepartmentID = _oDepartments[cmbDepartment.SelectedIndex].DepartmentID;
            _oOfficeItemTran.CompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;            
            _oOfficeItemTran.EmployeeID = ctlEmployee.SelectedEmployee.EmployeeID;
            _oOfficeItemTran.WarehouseID = 0;
            _oOfficeItemTran.Remarks = txtRemarks.Text;
            _oOfficeItemTran.Terminal = (int)Dictionary.Terminal.Head_Office;


            // Item Details
            foreach (DataGridViewRow oItemRow in dgvStationaryItem.Rows)
            {
                if (oItemRow.Index < dgvStationaryItem.Rows.Count - 1)
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