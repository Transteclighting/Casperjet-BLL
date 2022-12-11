using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHROverTimeEmployee : Form
    {
        public bool _Istrue = false;
        public bool Istrue = false;
        public Companys _oCompanys;
        Employees oEmployees;
        DSGetEmployee _oDSGetEmployee;
        int nTotalData = 0;
        int nLastColumnIndex = 0;
        HROverTimeEmployee _oHROverTimeEmployee;
        int nOverTimeID = 0;
        int _nStatus = 0;
        public frmHROverTimeEmployee(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(HROverTimeEmployee oHROverTimeEmployee)
        {
            this.Tag = oHROverTimeEmployee;
            nOverTimeID = oHROverTimeEmployee.OverTimeID;
            LoadCombos();
            dtAddDay.Value = oHROverTimeEmployee.OvertimeDate;
            //cmbCompany.SelectedIndex = _oCompanys.GetIndex(oHROverTimeEmployee.CompanyID) + 1;
            cmbCompany.Text = oHROverTimeEmployee.CompanyName;
            txtDescription.Text = oHROverTimeEmployee.Description;
            
            //Details
            HROverTimeEmployees oHROverTimeEmployees = new HROverTimeEmployees();
            oHROverTimeEmployees.RefreshByOverTimeEmployeedetails(nOverTimeID);
            foreach (HROverTimeEmployee oItem in oHROverTimeEmployees)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvItem);
                oRow.Cells[0].Value = oItem.EmployeeCode.ToString();
                oRow.Cells[1].Value = oItem.EmployeeName.ToString();
                oRow.Cells[2].Value = oItem.EmployeeID.ToString();
                dgvItem.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
        private void frmHROverTimeEmployee_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombos();
            }
            if (_nStatus == (int)Dictionary.HROverTimeEmployee.Create)
            {
                btnSave.Text = "Save";
            }
            else if (_nStatus == (int)Dictionary.HROverTimeEmployee.Approved)
            {
                btnSave.Text = "Approved";
            }
        }
        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Add("--Select--");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;
            //HRLoanType
            cmbType.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.PayrollType), GetEnum));
            }
            cmbType.SelectedIndex = 0;
        }
        private bool DataGetValidate()
        {
            int nSettingCount = 0;
            int nRowCount = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCompany.Focus();
                return false;
            }
            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbType.Focus();
                return false;
            }

            return true;
        }
        private void btnGetEmployee_Click(object sender, EventArgs e)
        {
            if (DataGetValidate())
            {
                cmbCompany.Enabled = false;
                frmPayrollGetEmployee oFrom = new frmPayrollGetEmployee(_oCompanys[cmbCompany.SelectedIndex - 1].CompanyID,cmbCompany.Text,cmbType.SelectedIndex, cmbType.Text);
                oFrom.ShowDialog();
                oEmployees = oFrom._oEmployees;
                FillDataSet(oFrom._oEmployees);
                //this.Text = "HR Payroll | Selected Employee: " + Convert.ToString(RowCount());
                //lblProgress.Text = "0/" + Convert.ToString(RowCount());
                //if (oEmployees != null)
                //{
                //    if (oEmployees.Count > 0)
                //    {
                //        btnSave.Enabled = false;
                //        btnProcess.Enabled = true;
                //    }
                //}
                //else
                //{
                //    btnSave.Enabled = false;
                //    btnProcess.Enabled = false;
                //}
            }
        }
        private void FillDataSet(Employees oEmployees)
        {
            _oDSGetEmployee = new DSGetEmployee();
            if (oEmployees == null)
            { oEmployees = new Employees(); }
            foreach (Employee oEmployee in oEmployees)
            {
                DSGetEmployee.EmployeeRow oRow = _oDSGetEmployee.Employee.NewEmployeeRow();

                oRow.EmployeeID = oEmployee.EmployeeID;
                oRow.EmployeeCode = oEmployee.EmployeeCode;
                oRow.EmployeeName = oEmployee.EmployeeName;

                _oDSGetEmployee.Employee.AddEmployeeRow(oRow);
                _oDSGetEmployee.AcceptChanges();
            }
            AppendToGrid(_oDSGetEmployee);
        }
        public void GetTotalEmployee()
        {
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    if (oItemRow.Cells[2].Value.ToString().Trim() != "")
                    {

                        try
                        {
                            nCount++;
                        }
                        catch
                        {

                        }
                    }

                }
            }

        }
        private void AppendToGrid(DSGetEmployee oDSEmployee)
        {
            int nIndex = 0;
            nTotalData = oDSEmployee.Employee.Count;
            //lblProgress.Text = "0/" + nTotalData.ToString();
            foreach (DSGetEmployee.EmployeeRow oDSRow in oDSEmployee.Employee)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvItem);
                oRow.Cells[0].Value = oDSRow.EmployeeCode;
                oRow.Cells[1].Value = oDSRow.EmployeeName;
                oRow.Cells[2].Value = oDSRow.EmployeeID;
                dgvItem.Rows.Add(oRow);               
                GetTotalEmployee();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            int nRowCount = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    nRowCount++;
                    break;
                }
            }
            if (nRowCount == 0)
            {
                MessageBox.Show("Please Get at least an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            double _Value = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    _Value = _Value + Convert.ToDouble(oItemRow.Cells[nLastColumnIndex].Value);
                }
            }
            if (_Value == 0)
            {
                MessageBox.Show("There is no value to process data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oHROverTimeEmployee = new HROverTimeEmployee();
                _oHROverTimeEmployee.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                _oHROverTimeEmployee.Description = txtDescription.Text;
                _oHROverTimeEmployee.OvertimeDate = dtAddDay.Value;
                _oHROverTimeEmployee.CreateUser = Utility.UserId;
                _oHROverTimeEmployee.CreateDate = DateTime.Now;
                //oHROverTimeEmployee.Status= (int)Dictionary.HROverTimeEmployee.Create;
                if (_nStatus == (int)Dictionary.HROverTimeEmployee.Create)
                {
                    _oHROverTimeEmployee.Status = (int)Dictionary.HROverTimeEmployee.Create;
                }
                else if (_nStatus == (int)Dictionary.HROverTimeEmployee.Approved)
                {
                    _oHROverTimeEmployee.Status = (int)Dictionary.HROverTimeEmployee.Approved;
                }

                // Details
                foreach (DataGridViewRow oItemRow in dgvItem.Rows)
                {
                    if (oItemRow.Index < dgvItem.Rows.Count)
                    {
                        HROverTimeEmployeedetails _oHROverTimeEmployeedetails = new HROverTimeEmployeedetails();
                        _oHROverTimeEmployeedetails.EmployeeID = int.Parse(oItemRow.Cells[2].Value.ToString());
                        _oHROverTimeEmployee.Add(_oHROverTimeEmployeedetails);

                    }
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHROverTimeEmployee.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add: " + _oHROverTimeEmployee.OverTimeID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                //_oHROverTimeEmployee= new HROverTimeEmployee();
                HROverTimeEmployee _oHROverTimeEmployee = (HROverTimeEmployee)this.Tag;
                _oHROverTimeEmployee.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                _oHROverTimeEmployee.Description = txtDescription.Text;
                _oHROverTimeEmployee.OvertimeDate = dtAddDay.Value;
                _oHROverTimeEmployee.ApprovedUser = Utility.UserId;
                _oHROverTimeEmployee.ApprovedDate = DateTime.Now;
                if (_nStatus == (int)Dictionary.HROverTimeEmployee.Create)
                {
                    _oHROverTimeEmployee.Status = (int)Dictionary.HROverTimeEmployee.Create;
                }
                else if (_nStatus == (int)Dictionary.HROverTimeEmployee.Approved)
                {
                    _oHROverTimeEmployee.Status = (int)Dictionary.HROverTimeEmployee.Approved;
                }
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (_nStatus == (int)Dictionary.HROverTimeEmployee.Create)
                    {
                        // Details
                        foreach (DataGridViewRow oItemRow in dgvItem.Rows)
                        {
                            if (oItemRow.Index < dgvItem.Rows.Count)
                            {
                                HROverTimeEmployeedetails _oHROverTimeEmployeedetails = new HROverTimeEmployeedetails();
                                _oHROverTimeEmployeedetails.DeleteByEmployeeOvertime(nOverTimeID);
                                _oHROverTimeEmployeedetails.EmployeeID = int.Parse(oItemRow.Cells[2].Value.ToString());
                                _oHROverTimeEmployee.Add(_oHROverTimeEmployeedetails);

                            }
                        }
                        _oHROverTimeEmployee.Edit();
                    }
                    else if (_nStatus == (int)Dictionary.HROverTimeEmployee.Approved)
                    {
                        _oHROverTimeEmployee.Approved();
                    }

                        DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit: " + _oHROverTimeEmployee.OverTimeID, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {              
                Save();
                _Istrue = true;
                this.Close();
            }
        }
    }
}
