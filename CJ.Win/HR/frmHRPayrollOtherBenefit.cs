using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using CJ.Class.Library;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRPayrollOtherBenefit : Form
    {
        public bool _Istrue = false;
        private bool _ISVerify = false;
        HRPayrollOtherBenefitPaymentTypes _oHRPayrollOtherBenefitPaymentTypes;
        HRPayrollOtherBenefitPaymentTypes _oHRPayrollOtherBenefitPaymentTypeName;
        private DataTable _oDT;
        int nCount = 0;
        public frmHRPayrollOtherBenefit()
        {
            InitializeComponent();
        }

        private void frmHRPayrollOtherBenefit_Load(object sender, EventArgs e)
        {
            pbHRBenifit.Visible = false;
            lblColumnHead.Text = "Excel Field: EmployeeCode, WorkStation, Amount";
            lblColumnHead.Refresh();
            LoadType();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtBrowseData.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
            }

            LoadSheets();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtBrowseData.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Raw$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);

            _oDT.Columns.Add(new DataColumn("colStatus", typeof(int)));
            _oDT.Columns.Add(new DataColumn("colEmployeeID", typeof(int)));

            this.dgvData.DataSource = _oDT.DefaultView;
            this.dgvData.Columns["colStatus"].Visible = false;
            this.dgvData.Columns["colEmployeeID"].Visible = false;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private bool UIValidation()
        {            
            if (cmbType.Text == "-- Select --")
            {
                MessageBox.Show("Please Select Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                return false;
            }
            //if (cmbType.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Please Select Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cmbType.Focus();
            //    return false;
            //}
            if (cmbPaymentName.Text == "-- Select --")
            {
                MessageBox.Show("Please Select Payment Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentName.Focus();
                return false;
            }
            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_ISVerify == false)
            {
                MessageBox.Show("Please Verify First");
            }
            else
            {
                if (UIValidation())
                {
                    Save();
                    this.Close();
                }
            }
        }
        private void Save()
        {
            if (!Validation())
            {
                MessageBox.Show("Please Input Valid EmployeeID");
                return;
            }
            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;
            pbHRBenifit.Maximum = _oDT.Rows.Count;
            DBController.Instance.BeginNewTransaction();
            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {
                    pbHRBenifit.Visible = true;
                    string sEmployeeCode = oRow[0].ToString();
                    int nEmployeeID = Convert.ToInt32(oRow[4].ToString());
                    string sWorkStation = Convert.ToString(oRow[1]);
                    int nAmount = Convert.ToInt32(oRow[2]);
                    int nYear = dtYear.Value.Year;
                    int nMonth = dtMonth.Value.Month;

                        HRPayrollOtherBenefit oHRPayrollOtherBenefit = new HRPayrollOtherBenefit();                   
                        oHRPayrollOtherBenefit.TYear = nYear;
                        oHRPayrollOtherBenefit.TMonth = nMonth;
                        oHRPayrollOtherBenefit.EmployeeID = nEmployeeID;
                        oHRPayrollOtherBenefit.PaymentType = cmbType.Text;
                        oHRPayrollOtherBenefit.Amount = nAmount;
                        oHRPayrollOtherBenefit.WorkStation = sWorkStation;
                        oHRPayrollOtherBenefit.PaymentTypeName = cmbPaymentName.Text;

                        oHRPayrollOtherBenefit.Add();
                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                        nCount++;

                        oDGVRow = dgvData.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;

                        dgvData.Refresh();

                        i = i + 1;
                        pbHRBenifit.Value = i;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                btnSave.Visible = false;
            }
            DBController.Instance.CommitTransaction();
            MessageBox.Show(" Data save successfully \n Total Inserted Data " + nCount + "");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oHRPayrollOtherBenefitPaymentTypes = new HRPayrollOtherBenefitPaymentTypes();
            _oHRPayrollOtherBenefitPaymentTypes.RefreshByPaymentType();
            //cmbType.Items.Clear();
            foreach (HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentTypes in _oHRPayrollOtherBenefitPaymentTypes)
            {
                cmbType.Items.Add(oHRPayrollOtherBenefitPaymentTypes.PaymentTypeName);
            }
            cmbType.Items.Add("-- Select --");
            cmbType.SelectedIndex = _oHRPayrollOtherBenefitPaymentTypes.Count;   
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            frmHRPayrollOtherBenefitPaymentType ofrmHRPayrollOtherBenefitPaymentType = new frmHRPayrollOtherBenefitPaymentType();
            ofrmHRPayrollOtherBenefitPaymentType.ShowDialog();
            if (ofrmHRPayrollOtherBenefitPaymentType._Istrue == true)
            {
                LoadType();
            }
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            _ISVerify = true;
            int i = 0;
            string sSql = "";
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            Employees _oEmployees = new Employees();
            _oEmployees.Refresh();
            DSGetEmployee _oDSGetEmployee = new DSGetEmployee();
            DSGetEmployee _oDSGetEmployeeFilter;

            foreach (Employee oEmployee in _oEmployees)
            {
                DSGetEmployee.EmployeeRow oRow = _oDSGetEmployee.Employee.NewEmployeeRow();
                oRow.EmployeeID = oEmployee.EmployeeID;
                oRow.EmployeeCode = oEmployee.EmployeeCode;

                _oDSGetEmployee.Employee.AddEmployeeRow(oRow);
                _oDSGetEmployee.AcceptChanges();
            }
            DataGridViewRow oDGVRow;
            int nCount = 0;

            try
            {
                foreach (DataRow oRow in _oDT.Rows)
                {
                    string sEmployeeCode = oRow[0].ToString();
                    int nEmployeeID = 0;
                    string sWorkStation = Convert.ToString(oRow[1]);
                    int nAmount = Convert.ToInt32(oRow[2]);

                    _oDSGetEmployeeFilter = new DSGetEmployee();
                    DataRow[] ds = _oDSGetEmployee.Employee.Select("EmployeeCode='" + sEmployeeCode + "'");
                    _oDSGetEmployeeFilter.Merge(ds);
                    _oDSGetEmployeeFilter.AcceptChanges();



                    if (_oDSGetEmployeeFilter.Employee.Count > 0)
                    {
                        foreach (DSGetEmployee.EmployeeRow oData in _oDSGetEmployeeFilter.Employee)
                        {
                            nEmployeeID = oData.EmployeeID;

                            dgvData.Rows[nCount].Cells["colStatus"].Value = 1;
                            dgvData.Rows[nCount].Cells["colEmployeeID"].Value = oData.EmployeeID;
                            dgvData.Rows[nCount].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    else
                    {
                        dgvData.Rows[nCount].Cells["colStatus"].Value = 0;
                        dgvData.Rows[nCount].Cells["colEmployeeID"].Value = 0;
                        dgvData.Rows[nCount].DefaultCellStyle.BackColor = Color.Red;
                    }
                    nCount++;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inserting Data: " + ex + "");
                throw (ex);
            }
        }

        private bool Validation()
        {
            bool _bFlag = false;
            foreach (DataRow oRow in _oDT.Rows)
            {

                if (Convert.ToInt32(oRow[3].ToString()) == 0)
                {
                    _bFlag = false;
                    break;
                }
                else
                {
                    _bFlag = true;
                }

            }
            return _bFlag;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex < 0 || cmbType.SelectedIndex > _oHRPayrollOtherBenefitPaymentTypes.Count - 1)
            {
                return;
            }

            int nParentID = _oHRPayrollOtherBenefitPaymentTypes[cmbType.SelectedIndex].ID ;

            _oHRPayrollOtherBenefitPaymentTypeName = new HRPayrollOtherBenefitPaymentTypes();
            _oHRPayrollOtherBenefitPaymentTypeName.RefreshByPaymentName(nParentID);
            cmbPaymentName.Items.Clear();
            foreach (HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType in _oHRPayrollOtherBenefitPaymentTypeName)
            {
                cmbPaymentName.Items.Add(oHRPayrollOtherBenefitPaymentType.PaymentTypeName);
            }
            cmbPaymentName.Items.Add("-- Select --");
            cmbPaymentName.SelectedIndex = _oHRPayrollOtherBenefitPaymentTypeName.Count;           
        }
    }
}
