using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.HR;
using CJ.Report.HR;

namespace CJ.Win.HR
{
    public partial class frmPayrolls : Form
    {
        Companys _oCompanys;
        HRPayrolls _oHRPayrolls;
        TELLib _oTELLib;
        UserPermission _oUserPermission;
        
        public frmPayrolls()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPayroll oFrom = new frmPayroll();
            oFrom.ShowDialog();
            DataLoadControl();
            
        }

        private void ButtonPermission()
        {
            _oUserPermission = new UserPermission();

            string _sAdd = "M16.10.2.1";
            if (!_oUserPermission.CheckPermission(_sAdd, Utility.UserId))
            {
                btnAdd.Enabled = false;
            }
            string _sEdit = "M16.10.2.2";
            if (!_oUserPermission.CheckPermission(_sEdit, Utility.UserId))
            {
                btnEdit.Enabled = false;
            }
            string _sPrint = "M16.10.2.3";
            if (!_oUserPermission.CheckPermission(_sPrint, Utility.UserId))
            {
                btnPrint.Enabled = false;
            }
            string _sVerify = "M16.10.2.4";
            if (!_oUserPermission.CheckPermission(_sVerify, Utility.UserId))
            {
                btnVerify.Enabled = false;
            }
            string _sApprove = "M16.10.2.5";
            if (!_oUserPermission.CheckPermission(_sApprove, Utility.UserId))
            {
                btnApprove.Enabled = false;
            }
            string _sCompareReport = "M16.10.2.6";
            if (!_oUserPermission.CheckPermission(_sCompareReport, Utility.UserId))
            {
                btnCompareReport.Enabled = false;
            }
            string _sDelete = "M16.10.2.7";
            if (!_oUserPermission.CheckPermission(_sDelete, Utility.UserId))
            {
                btnDelete.Enabled = false;
            }
            string _sSendToAccpac = "M16.10.2.8";
            if (!_oUserPermission.CheckPermission(_sSendToAccpac, Utility.UserId))
            {
                btnSendtoAccpac.Enabled = false;
            }
        }

        private void frmPayrolls_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
            ButtonPermission();

            int nYear = DateTime.Today.Year;
            int nMonth = DateTime.Today.Month;
            DateTime _date = Convert.ToDateTime(nYear.ToString() + "-" + nMonth.ToString() + "-01");
            dtSalaryMonth.Value = _date;
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            if (_oCompanys.Count > 1)
            {
                cmbCompany.Items.Add("All");
            }
            if (_oCompanys.Count == 0)
            {
                cmbCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.PayrollStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //HRLoanType
            cmbType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.PayrollType), GetEnum));
            }
            cmbType.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {
            _oHRPayrolls = new HRPayrolls();
            _oTELLib = new TELLib();
            
            DBController.Instance.OpenNewConnection();
            UpdateAccpacPostData();
            DateTime _Date = Convert.ToDateTime(dtSalaryMonth.Value);
            int nMonth = _Date.Month;
            int nYear = _Date.Year;

            int nCompanyID = 0;
            nCompanyID = GetCompanyID(_oCompanys);
            lvwList.Items.Clear();
            _oHRPayrolls.RefreshData(nCompanyID, cmbStatus.SelectedIndex, nMonth, nYear, cmbType.SelectedIndex, txtCode.Text.Trim());
            
            this.Text = "HR Payroll | Filtered Data: " + "[" + _oHRPayrolls.Count + "]";
            foreach (HRPayroll oHRPayroll in _oHRPayrolls)
            {

                ListViewItem oItem = lvwList.Items.Add(oHRPayroll.Code);
                oItem.SubItems.Add(oHRPayroll.CompanyCode);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth));
                oItem.SubItems.Add(oHRPayroll.TYear.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type));
                oItem.SubItems.Add(oHRPayroll.Description);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PayrollStatus), oHRPayroll.Status));
                oItem.SubItems.Add(oHRPayroll.NoOfEmpl.ToString());
                oItem.SubItems.Add(ExcludeDecimal(_oTELLib.TakaFormat(oHRPayroll.GrossSalary)));
                oItem.SubItems.Add(ExcludeDecimal(_oTELLib.TakaFormat(oHRPayroll.Deduct)));
                oItem.SubItems.Add(ExcludeDecimal(_oTELLib.TakaFormat(oHRPayroll.NetSalary)));
                oItem.SubItems.Add(ExcludeDecimal(_oTELLib.TakaFormat(oHRPayroll.Expense)));
                oItem.SubItems.Add(ExcludeDecimal(_oTELLib.TakaFormat(oHRPayroll.Subsidy)));
                oItem.SubItems.Add(ExcludeDecimal(_oTELLib.TakaFormat(oHRPayroll.TotalSalary)));
                oItem.SubItems.Add(oHRPayroll.UserName);
                oItem.SubItems.Add(oHRPayroll.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHRPayroll.VerifiedUserName);
                oItem.SubItems.Add(oHRPayroll.VerifiedDate.ToString());
                oItem.SubItems.Add(oHRPayroll.ApproveUserName);
                oItem.SubItems.Add(oHRPayroll.ApproveDate.ToString());

                oItem.Tag = oHRPayroll;
            }

            setListViewRowColour();
        }

        private int GetCompanyID(Companys oCompanys)
        {
            int nCompanyID;
            if (_oCompanys.Count == 1)
            {
                nCompanyID = oCompanys[cmbCompany.SelectedIndex].CompanyID; // Only one company
            }
            else if (_oCompanys.Count > 1)
            {
                try
                {
                    nCompanyID = oCompanys[cmbCompany.SelectedIndex - 1].CompanyID; // Specific company from all 
                }
                catch
                {
                    nCompanyID = 0; // All Selection
                }
            }
            else
            {
                nCompanyID = -1; // No Permission
            }

            return nCompanyID;
        }

        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            if (oHRPayroll.Status != (int)Dictionary.PayrollStatus.Create && oHRPayroll.Status != (int)Dictionary.PayrollStatus.Verify)
            {
                MessageBox.Show("Create or Verify Payroll can be Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            frmPayroll oFrom = new frmPayroll();
            oFrom.ShowDialog(oHRPayroll);
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            frmPayrollPrint _oForm = new frmPayrollPrint();
            _oForm.ShowDialog(oHRPayroll);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            if (oHRPayroll.Status != (int)Dictionary.PayrollStatus.Create && oHRPayroll.Status != (int)Dictionary.PayrollStatus.Verify)
            {
                MessageBox.Show("Approve Payroll can'nt be Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete the Payroll#: " + oHRPayroll.Code + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayroll.Delete();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Data Deleted Successfully.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwList_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Approve", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            if (oHRPayroll.Status != (int)Dictionary.PayrollStatus.Verify)
            {
                MessageBox.Show("Only Verified status can be Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approve the Payroll#: " + oHRPayroll.Code + " ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayroll.Status = (int)Dictionary.PayrollStatus.Approve;
                    oHRPayroll.ApproveBy = Utility.UserId;
                    oHRPayroll.ApproveDate = DateTime.Now;
                    oHRPayroll.Approve();
                    UpdateOtherSource(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Approved Successfully.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void UpdateOtherSource(int nPayrollID, int nTMonth, int nTYear)
        {
            HRPayroll oHRPayroll = new HRPayroll();
            oHRPayroll.PayrollID = nPayrollID;
            oHRPayroll.GetEmployeeByPayrollID();
            foreach (HRPayrollItem oItem in oHRPayroll)
            {
                HRLoans _oHRLoans = new HRLoans();
                _oHRLoans.GetLoanListByEmployee(oItem.EmployeeID);

                foreach (HRLoan oHRLoan in _oHRLoans)
                {
                    HRLoanDetail _oHRLoanDetail = new HRLoanDetail();
                    _oHRLoanDetail.GetLoanDetail(oHRLoan.LoanID, nTMonth, nTYear);

                    _oHRLoanDetail.UpdateEMI(_oHRLoanDetail.LoanDetailID);

                    HRLoan _oHRLoan = new HRLoan();
                    _oHRLoan.UpdateCurrentBalance(false, _oHRLoanDetail.PrincipalPayable, oHRLoan.LoanID);

                    if (_oHRLoanDetail.CheckDue(oHRLoan.LoanID))
                    {
                        _oHRLoan.UpdateStatus(oHRLoan.LoanID,(int)Dictionary.HRLoanStatus.Closed);
                    }
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Verify", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            if (oHRPayroll.Status != (int)Dictionary.PayrollStatus.Create)
            {
                MessageBox.Show("Only Create status can be Verified", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Verify the Payroll#: " + oHRPayroll.Code + " ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayroll.Status = (int)Dictionary.PayrollStatus.Verify;
                    oHRPayroll.VerifiedBy = Utility.UserId;
                    oHRPayroll.VerifiedDate = DateTime.Now;
                    oHRPayroll.Verify();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Verified Successfully.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void setListViewRowColour()
        {
            if (lvwList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwList.Items)
                {
                    if (oItem.SubItems[6].Text == Dictionary.PayrollStatus.Create.ToString())
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.PayrollStatus.Verify.ToString())
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.PayrollStatus.Approve.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.PayrollStatus.Send_to_Accpac.ToString())
                    {
                        oItem.BackColor = Color.Thistle;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.PayrollStatus.Post_at_Accpac.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnCompareReport_Click(object sender, EventArgs e)
        {
            frmPayrollCompareReport _ofrom = new frmPayrollCompareReport();
            _ofrom.ShowDialog();
        }

        private void btnPayslipPrint_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            
        }

        private void btnStaffTopSheet_Click(object sender, EventArgs e)
        {
            frmPayrollStaffTopSheet _oform = new frmPayrollStaffTopSheet();
            _oform.ShowDialog();
        }

        private void btnSendtoAccpac_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Send", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayroll oHRPayroll = (HRPayroll)lvwList.SelectedItems[0].Tag;
            if (oHRPayroll.Status != (int)Dictionary.PayrollStatus.Approve && oHRPayroll.Status != (int)Dictionary.PayrollStatus.Send_to_Accpac)
            {

                MessageBox.Show("Only Approved/Send-to-Accpac status can be Send/Resend to Accpac", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _oHRPayrolls = new HRPayrolls();
            if (_oHRPayrolls.GetUnmapEmployee(oHRPayroll.PayrollID, oHRPayroll.CompanyID))
            {
                frmHRPayrollUnmapEmpl _oform = new frmHRPayrollUnmapEmpl(oHRPayroll.PayrollID, oHRPayroll.CompanyID);
                _oform.ShowDialog();
                return;
            }

            DialogResult oResult = MessageBox.Show("Are you sure you want to Send/Resend the Payroll#: " + oHRPayroll.Code + " to Accpac? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DBController.Instance.BeginNewTransaction();

                    if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BLL)
                    {
                        oHRPayroll.RefreshPayrollforAccpac(oHRPayroll.CompanyID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.PayrollID);
                    }
                    else if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
                    { 
                        oHRPayroll.RefreshPayrollforAccpacBEIL(oHRPayroll.CompanyID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.PayrollID);
                    }

                    HRPayrollItem obj = new HRPayrollItem();
                    obj.PayrollID = oHRPayroll.PayrollID;
                    obj.DeleteMapERPPayroll();

                    foreach (HRPayrollItem oItem in oHRPayroll)
                    {
                        oItem.PayrollDes = oHRPayroll.Description;
                        oItem.Status = 0;
                        oItem.AddtoAccpac(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear);
                    }
                    oHRPayroll.Status = (int)Dictionary.PayrollStatus.Send_to_Accpac;
                    oHRPayroll.StatusUpdate();
                    
                    DBController.Instance.CommitTran();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Send/Resend to Accpac Successfully.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void UpdateAccpacPostData()
        {
            _oHRPayrolls = new HRPayrolls();
            _oHRPayrolls.GetPostPayrollID();
            DBController.Instance.BeginNewTransaction();
            foreach (HRPayroll oPayroll in _oHRPayrolls)
            {
                oPayroll.Status = (int)Dictionary.PayrollStatus.Post_at_Accpac;
                oPayroll.StatusUpdate();
            }
            DBController.Instance.CommitTran();
        }


    }
}