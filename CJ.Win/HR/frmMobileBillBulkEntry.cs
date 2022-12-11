using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMobileBillBulkEntry : Form
    {
        MobileNumberAssigns _oMobileNumberAssigns;
        private Departments _oDepartments;
        private Companys _oCompanys;

        public frmMobileBillBulkEntry()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMobileBillBulkEntry_Load(object sender, EventArgs e)
        {
            DateTime _Date = Convert.ToDateTime("01-" + dtBillMonth.Value.Month + "-" + dtBillMonth.Value.Year);
            dtBillMonth.Value = _Date;
            LoadCombos();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            dgvMobileBillBulkEntry.Rows.Clear();

            int searchCompanyID;
            if (cmbCompany.SelectedIndex == 0)
            {
                searchCompanyID = -1;
            }
            else
            {
                searchCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            int searchDepartmentID;
            if (cmbDepartment.SelectedIndex == 0)
            {
                searchDepartmentID = -1;
            }
            else
            {
                searchDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            _oMobileNumberAssigns = new MobileNumberAssigns();
            DBController.Instance.OpenNewConnection();
            _oMobileNumberAssigns.GetData(searchDepartmentID, searchCompanyID);
            this.Text = "Mobile SIM Management | Total: " + "[" + _oMobileNumberAssigns.Count + "]";

            foreach (MobileNumberAssign oMobileNumberAssign in _oMobileNumberAssigns)
            {
                if (oMobileNumberAssign.UserName != "Unassign")
                {
                    int n = dgvMobileBillBulkEntry.Rows.Add();
                    dgvMobileBillBulkEntry.Rows[n].Cells["colAssignID"].Value = oMobileNumberAssign.ID;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colMobileNo"].Value = oMobileNumberAssign.MobileNumber;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colUser"].Value = oMobileNumberAssign.UserName;
                    dgvMobileBillBulkEntry.Rows[n].Cells["txtAmount"].Value = 0;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colMobileID"].Value = oMobileNumberAssign.MobileID;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colCreditLimitType"].Value = oMobileNumberAssign.CreditLimitType;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colCreditLimit"].Value = oMobileNumberAssign.CreditLimit;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colEdgePackageAmount"].Value = oMobileNumberAssign.EdgePackageAmount;
                    dgvMobileBillBulkEntry.Rows[n].Cells["colDatapacID"].Value = oMobileNumberAssign.DatapacID;
                    int nMobileID = int.Parse(dgvMobileBillBulkEntry.Rows[n].Cells["colMobileID"].Value.ToString());
                    if (!oMobileNumberAssign.IsMobileBillSavedForMonth(nMobileID, dtBillMonth.Value.Month, dtBillMonth.Value.Year))
                    {
                        dgvMobileBillBulkEntry.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 196);
                    }
                    dgvMobileBillBulkEntry.Rows[n].Tag = oMobileNumberAssign;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.WaitCursor;
                this.Close();
            }

        }
        private bool validateUIInput()
        {
            if (dgvMobileBillBulkEntry.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;


        }
        public void Save()
        {

            foreach (DataGridViewRow oItemRow in dgvMobileBillBulkEntry.Rows)
            {
                DBController.Instance.OpenNewConnection();
                if (oItemRow.Index < dgvMobileBillBulkEntry.Rows.Count)
                {
                    try
                    {
                        MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
                        oMobileNumberAssign.ID = int.Parse(oItemRow.Cells[3].Value.ToString());
                        oMobileNumberAssign.Refresh();
                        MobileBill oMobileBill = new MobileBill
                        {
                            AssignID = int.Parse(oItemRow.Cells[3].Value.ToString()),
                            BillAmount = double.Parse(oItemRow.Cells[2].Value.ToString()),
                            MobileID = int.Parse(oItemRow.Cells[4].Value.ToString()),
                            CreaditLimitType = int.Parse(oItemRow.Cells[5].Value.ToString()),
                            CreaditLimit = double.Parse(oItemRow.Cells[6].Value.ToString()),
                            DatapacID = int.Parse(oItemRow.Cells[8].Value.ToString())
                        };
                        //oMobileBill.DatapacLimit = int.Parse(oItemRow.Cells[7].Value.ToString());//flag

                        if (oMobileBill.DatapacID != null)
                        {
                            MobileDatapac _oMobileDatapac = new MobileDatapac();
                            _oMobileDatapac.DatapacID = oMobileBill.DatapacID;
                            _oMobileDatapac.Refresh();
                            oMobileBill.DatapacLimit = _oMobileDatapac.PackageAmount;
                        }

                        if (oMobileBill.CreaditLimitType == (int)Dictionary.MobileCreaditLimitType.Actual)
                        {
                            oMobileBill.DeductFromSalary = 0;
                            oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
                        }
                        else
                        {
                            if (oMobileBill.BillAmount > (oMobileBill.CreaditLimit + oMobileBill.DatapacLimit))
                            {
                                oMobileBill.DeductFromSalary = oMobileBill.BillAmount - (oMobileBill.CreaditLimit + oMobileBill.DatapacLimit);
                                oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Pending;
                            }
                            else
                            {
                                oMobileBill.DeductFromSalary = 0;
                                oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
                            }
                            
                        }
                        oMobileBill.TMonth = dtBillMonth.Value.Month;
                        oMobileBill.TYear = dtBillMonth.Value.Year;

                        string billMonth = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dtBillMonth.Value.Month - 1];

                        var anEmployee = new Employee
                        {
                            EmployeeID = oMobileNumberAssign.EmployeeID
                        };
                        anEmployee.Refresh();
                        oMobileBill.EmpLocationId = anEmployee.LocationID;

                        if (oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, oMobileBill.TMonth, oMobileBill.TYear))
                        {
                            DBController.Instance.BeginNewTransaction();
                            oMobileBill.Add();
                            DBController.Instance.CommitTransaction();
                        }

                        else
                        {
                            if (oItemRow.Index == dgvMobileBillBulkEntry.Rows.Count - 1)
                            {
                                MessageBox.Show("You Have Successfully Save The Bill ,Month of " + billMonth + " " + oMobileBill.TYear, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                            continue;
                        }
                        
                        if (oItemRow.Index == dgvMobileBillBulkEntry.Rows.Count - 1)
                        {
                            MessageBox.Show("You Have Successfully Save The Bill ,Month of " + billMonth + " " + oMobileBill.TYear, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }

            }

        }

        private void dtBillMonth_ValueChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}