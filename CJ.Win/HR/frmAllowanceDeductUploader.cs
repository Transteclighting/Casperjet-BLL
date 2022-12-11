using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmAllowanceDeductUploader : Form
    {
        private AllowanceDeductions _oAllowanceDeductions;
        private DataTable _oDT;
        private System.Windows.Forms.OpenFileDialog _openFileDialogData;
        private HRPayrollAddDeduct _oHRPayrollAddDeduct;
        public frmAllowanceDeductUploader()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Allowance Deductions
            _oAllowanceDeductions = new AllowanceDeductions();
            _oAllowanceDeductions.Refresh();
            cmbAD.Items.Clear();
            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {
                cmbAD.Items.Add("[" + oAllowanceDeduction.Code + "]" + oAllowanceDeduction.Name);
            }
            cmbAD.SelectedIndex = 0;


            //Status
            cmbStatus.Items.Clear();
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.PayrollAddDeductStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.PayrollAddDeductStatus), getEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            bool isSelected = false;
            this._openFileDialogData = new OpenFileDialog();
            this._openFileDialogData.FileName = "";
            this._openFileDialogData.Multiselect = false;
            this._openFileDialogData.Filter = "";
            this._openFileDialogData.Filter = @"Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            if (this._openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtBrowseData.Text = this._openFileDialogData.FileName.ToString();
                this.Text = this._openFileDialogData.DefaultExt.ToString();
                isSelected = true;
            }

            if (isSelected)
            {
                LoadSheets();
            }
            
        }
        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtBrowseData.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            this.dgvData.DataSource = _oDT.DefaultView;
            this.Text = @"Load From XL [" + _oDT.Rows.Count + "]";

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UiValidation()
        {
            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show(@"There is no Data", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtRemarks.Text == "")
            {
                MessageBox.Show(@"Please input remarks", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UiValidation())
                Save();
            //_oAllowanceDeduction.ID = _oAllowanceDeductions[cmbAD.SelectedIndex].ID;
        }
        private void Save()
        {
            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DataGridViewRow oDgvRow;
            pbAddDeduct.Maximum = _oDT.Rows.Count;
            DBController.Instance.BeginNewTransaction();
            int nCount = 0;
            var totalreceive = _oDT.Rows.Count;
            foreach (DataRow oRow in _oDT.Rows)
            {
                try
                {
                    pbAddDeduct.Visible = true;
                    Employee oEmployee = new Employee
                    {
                        EmployeeCode = oRow[0].ToString()
                    };
                    oEmployee.RefreshByCode();

                    int nEmpId = 0;
                    try
                    {
                        nEmpId = oEmployee.EmployeeID;
                    }
                    catch
                    {
                        nEmpId = 0;
                    }

                    if (nEmpId == 0)
                    {
                        MessageBox.Show(@"Wrong employee code", @"Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        oDgvRow = dgvData.Rows[i];
                        oDgvRow.DefaultCellStyle.BackColor = Color.Red;
                        return;
                    }

                    _oHRPayrollAddDeduct = new HRPayrollAddDeduct
                    {
                        CompanyID = oEmployee.CompanyID,
                        EmployeeID = oEmployee.EmployeeID,
                        Month = dtYearMonth.Value.Month,
                        Year = dtYearMonth.Value.Year,
                        AllowanceID = _oAllowanceDeductions[cmbAD.SelectedIndex].ID,
                        Amount = Convert.ToDouble(oRow[2].ToString()),
                        Type = _oAllowanceDeductions[cmbAD.SelectedIndex].Type,
                        Remarks = txtRemarks.Text,
                        Status = cmbStatus.SelectedIndex + 1,
                        CreateUserID = Utility.UserId,
                        CreateDate = DateTime.Now.Date,
                        

                    };
                    _oHRPayrollAddDeduct.AddForBulk();
                    oDgvRow = dgvData.Rows[i];
                    oDgvRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    nCount++;

                    oDgvRow = dgvData.Rows[i];
                    oDgvRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    dgvData.Refresh();

                    i = i + 1;
                    double receive = Convert.ToDouble(i);
                    double percent = receive / totalreceive * 100;
                    lblProgress.Refresh();
                    lblProgress.Text = $@"Progress{string.Format("{0:0.##}", percent)}%";
                    //lblProgress.Text = $@"Progress{$"{percent:0.##}"}%";
                    pbAddDeduct.Value = i;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                btnSave.Visible = false;
            }
            DBController.Instance.CommitTransaction();
            MessageBox.Show(@" Data save successfully \n Total Inserted Data " + nCount + "");
            this.Close();
        }
        private void frmAllowanceDeductUploader_Load(object sender, EventArgs e)
        {
            this.Text = @"HR Payroll Add Deduct Bulk Upload";
            lblColumnHead.Text = @"Excel Field: Employee Code, Employee Name, Amount";
            LoadCombos();
        }
    }
}
