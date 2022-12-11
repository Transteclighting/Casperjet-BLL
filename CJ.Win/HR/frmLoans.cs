// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 14, 2016
// Time : 10:37 AM
// Description: Module for HRLoan.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Report;



namespace CJ.Win.HR
{
    public partial class frmLoans : Form
    {

        HRLoans _oHRLoans;
        TELLib oTELLib;
        Companys _oCompanys;
        HRLoan _oHRLoan;
        LoanTypes _oLoanTypes;

        public frmLoans()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            if (_oCompanys.Count > 1)
            {
                cmbCompany.Items.Add("<All>");
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
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRLoanStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.HRLoanStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //HRLoanType
            _oLoanTypes = new LoanTypes();
            _oLoanTypes.Refresh();
            cmbLoanType.Items.Add("All");
            foreach (LoanType oLoanType in _oLoanTypes)
            {
                cmbLoanType.Items.Add(oLoanType.LoanTypeName);
            }
            cmbLoanType.SelectedIndex = 0;


            //HRLoanArticle
            cmbArticleType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRLoanArticle)))
            {
                cmbArticleType.Items.Add(Enum.GetName(typeof(Dictionary.HRLoanArticle), GetEnum));
            }
            cmbArticleType.SelectedIndex = 0;

        }

        private void frmLoans_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oHRLoans = new HRLoans();
            lvwLoans.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nEmployeeID = 0;
            int nCompanyID = 0;
            int nLoanTypeID = 0;

            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }

            nCompanyID = GetCompanyID(_oCompanys);
            
            if (cmbLoanType.SelectedIndex != 0)
            {
                nLoanTypeID = _oLoanTypes[cmbLoanType.SelectedIndex - 1].LoanTypeID;
            }
            _oHRLoans.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtLoanNo.Text, nEmployeeID, cmbStatus.SelectedIndex, nLoanTypeID, cmbArticleType.SelectedIndex, nCompanyID, chkAll.Checked);

            this.Text = "Employee Loan | Total: " + "[" + _oHRLoans.Count + "]";
            foreach (HRLoan oHRLoan in _oHRLoans)
            {
                oTELLib = new TELLib();
                ListViewItem oItem = lvwLoans.Items.Add(oHRLoan.LoanNo.ToString());
                oItem.SubItems.Add(oHRLoan.DisburseDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHRLoan.LoanTypeName);
                if (oHRLoan.LoanTypeID == (int)Dictionary.HRLoanType.Article)
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRLoanArticle), oHRLoan.ArticleType));
                else oItem.SubItems.Add("N/A");
                oItem.SubItems.Add(oTELLib.TakaFormat(oHRLoan.AllocatedAmount));
                oItem.SubItems.Add(oHRLoan.NoOfInstallment.ToString());
                oItem.SubItems.Add(oHRLoan.InterestRate.ToString());
                oItem.SubItems.Add(oTELLib.TakaFormat(oHRLoan.PrincipalPayable));
                oItem.SubItems.Add(oTELLib.TakaFormat(oHRLoan.InterestPayable));
                oItem.SubItems.Add(oTELLib.TakaFormat(oHRLoan.TotalPayable));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRLoanStatus), oHRLoan.Status));
                oItem.SubItems.Add("[" + oHRLoan.EmployeeCode + "] " + oHRLoan.EmployeeName);
                oItem.SubItems.Add(oHRLoan.UserName);

                if (oHRLoan.Status == (int)Dictionary.HRLoanStatus.Running)
                {
                    oItem.BackColor = Color.Wheat;
                }
                else
                {
                    oItem.BackColor = Color.White;
                }
                oItem.Tag = oHRLoan;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmComplain oForm = new frmComplain();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void setListViewRowColour()
        {
            //if (lvwComplains.Items.Count > 0)
            //{
            //    foreach (ListViewItem oItem in lvwComplains.Items)
            //    {
            //        if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Receive.ToString())
            //        {
            //            oItem.BackColor = Color.Red;
            //        }
            //        else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Assign.ToString())
            //        {
            //            oItem.BackColor = Color.LightSalmon;
            //        }
            //        else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Solved.ToString())
            //        {
            //            oItem.BackColor = Color.Plum;
            //        }
            //        else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.UnderProcess.ToString())
            //        {
            //            oItem.BackColor = Color.SteelBlue;
            //        }
            //        else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.MgtActionReq.ToString())
            //        {
            //            oItem.BackColor = Color.PowderBlue;
            //        }
            //        else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.HappyCall.ToString())
            //        {
            //            oItem.BackColor = Color.DarkSeaGreen;
            //        }
            //        else
            //        {
            //            oItem.BackColor = Color.DarkGray;

            //        }
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HRLoan oHRLoan = (HRLoan)lvwLoans.SelectedItems[0].Tag;
            HRLoanDetail _oLoanDetail = new HRLoanDetail();
            _oLoanDetail.LoanID = oHRLoan.LoanID;
            if (_oLoanDetail.CheckEMI())
            {
                MessageBox.Show("You couldn't Delete the Running/Closed loan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult oResult = MessageBox.Show("Are you sure You want to delete the Loan: " + oHRLoan.LoanNo + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRLoan.Delete();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(" Successfully Delete The Loan No : " + oHRLoan.LoanNo, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoanType.SelectedIndex == (int)Dictionary.HRLoanType.Article)
            {
                cmbArticleType.Enabled = true;
                lblArticleType.Enabled = true;
            }
            else
            {
                cmbArticleType.Enabled = false;
                lblArticleType.Enabled = false;
                if (cmbArticleType.Text != "")
                {
                    cmbArticleType.SelectedIndex = 0;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLoan oLoan = new frmLoan();
            oLoan.ShowDialog();
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HRLoan oHRLoan = (HRLoan)lvwLoans.SelectedItems[0].Tag;


            this.Cursor = Cursors.WaitCursor;

            PrintEMI(oHRLoan.LoanID);

            this.Cursor = Cursors.Default;
        }

        public void PrintEMI(int nLoanID)
        {
            _oHRLoan = new HRLoan();
            _oHRLoan.LoanID = nLoanID;
            _oHRLoan.Refresh();

            Company oCompany = new Company();
            oCompany.CompanyID = _oHRLoan.CompanyID;
            oCompany.Refresh();

            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = _oHRLoan.EmployeeID;
            oEmployee.RefreshDetail();

            oTELLib = new TELLib();

            rptLoanEMIPrint doc = new rptLoanEMIPrint();

            doc.SetDataSource(_oHRLoan);

            doc.SetParameterValue("CompanyName", oCompany.CompanyName);
            doc.SetParameterValue("EmployeeCode", oEmployee.EmployeeCode);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName);
            doc.SetParameterValue("Designation", oEmployee.DesignationName);
            doc.SetParameterValue("Designation", oEmployee.DesignationName);
            doc.SetParameterValue("Department", oEmployee.DepartmentName);

            doc.SetParameterValue("LoanType", _oHRLoan.LoanTypeName);
            string sLoanSubType = "";
            if (_oHRLoan.LoanTypeID == (int)Dictionary.HRLoanType.Article)
            {
                sLoanSubType = " - " + Enum.GetName(typeof(Dictionary.HRLoanArticle), _oHRLoan.ArticleType);
            }
            doc.SetParameterValue("LoanSubType", sLoanSubType);
            doc.SetParameterValue("LoanStatus", _oHRLoan.LoanStatusName);
            doc.SetParameterValue("LoanNo", _oHRLoan.LoanNo);
            doc.SetParameterValue("DisburseDate", Convert.ToDateTime(_oHRLoan.DisburseDate).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("AllocatedAmount", oTELLib.TakaFormat(_oHRLoan.AllocatedAmount));
            doc.SetParameterValue("Downpayment", oTELLib.TakaFormat(_oHRLoan.DownPayment));
            doc.SetParameterValue("InterestRate", oTELLib.TakaFormat(_oHRLoan.InterestRate) + "%");
            doc.SetParameterValue("NoOfInstallment", _oHRLoan.NoOfInstallment.ToString());
            doc.SetParameterValue("User Name", Utility.Username);


            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);
            //doc.PrintToPrinter(1, true, 1, 1);
        }

        private void btnEarlySettle_Click(object sender, EventArgs e)
        {
            
            if (lvwLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HRLoan oHRLoan = (HRLoan)lvwLoans.SelectedItems[0].Tag;
            if (oHRLoan.Status == (int)Dictionary.HRLoanStatus.Closed)
            {
                MessageBox.Show("Only running loan could be early settled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmLoanEarlySettle oform = new frmLoanEarlySettle();
            oform.ShowDialog(oHRLoan);
            if (oform.IsExecute)
            {
                DataLoadControl();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmPFReport _oFrom = new frmPFReport();
            _oFrom.ShowDialog();
        }     
    }

}

