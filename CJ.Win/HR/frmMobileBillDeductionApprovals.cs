using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Library;




namespace CJ.Win.HR
{
    public partial class frmMobileBillDeductionApprovals : Form
    {
        Companys _oCompanys = new Companys();
        Departments _oDepartments = new Departments();
        MobileNumberAssigns _oMobileNumberAssigns;
        TELLib _oTELLib;
        public frmMobileBillDeductionApprovals()
        {
            InitializeComponent();
        }

        private void frmMobileBillDeductionApprovals_Load(object sender, EventArgs e)
        {
            DateTime _Date = Convert.ToDateTime("01-" + dtBillMonth.Value.Month + "-" + dtBillMonth.Value.Year);
            dtBillMonth.Value = _Date;
            LoadCombos();
            DataLoadControl();
            lblApproved.BackColor = Color.FromArgb(0, 128, 0);
            lblPending.BackColor = Color.FromArgb(255, 250, 205);
            lblReject.BackColor = Color.FromArgb(240,128,128);
            lblPartialApproved.BackColor = Color.FromArgb(0,255,127); 
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

            //Approve Status
            cmbApproveStatus.Items.Clear();
            cmbApproveStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileDeductApproveStatus)))
            {
                cmbApproveStatus.Items.Add(Enum.GetName(typeof(Dictionary.MobileDeductApproveStatus), GetEnum));
            }
            cmbApproveStatus.SelectedIndex = 0;           
            

        }
        public void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oMobileNumberAssigns = new MobileNumberAssigns();
            string _sMobileNumber = string.Empty;
            if(txtMobileNo.Text != string.Empty)
            {
                _sMobileNumber = txtMobileNo.Text.Trim();
            }
            int nApproveStatus = -1;
            if (cmbApproveStatus.SelectedIndex != 0)
            {
                nApproveStatus = cmbApproveStatus.SelectedIndex-1;
            }
            int nEmployeeID = -1;
            if (ctlEmployee2.txtDescription.Text != string.Empty)
            {
                nEmployeeID = ctlEmployee2.SelectedEmployee.EmployeeID;
            }
            int nTMonth = dtBillMonth.Value.Month;
            int nTYear = dtBillMonth.Value.Year;
            int nCompanyID = GetCompanyID(_oCompanys);

            int nDepartmentID = -1; ;
            if (cmbDepartment.SelectedIndex != 0)
            {
                nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }          

            lvwDeductBills.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oMobileNumberAssigns.GetAllDeductBill(_sMobileNumber,nCompanyID, nDepartmentID, nApproveStatus, nEmployeeID, nTMonth, nTYear);
            _oTELLib = new TELLib();
            this.Text = "Total Deduction Mobile Number: " + "[" + _oMobileNumberAssigns.Count + "]";
            foreach (MobileNumberAssign oMobileNumberAssign in _oMobileNumberAssigns)
            {
                ListViewItem oItem = lvwDeductBills.Items.Add(oMobileNumberAssign.MobileNumber);
                oItem.SubItems.Add(oMobileNumberAssign.UserTypeName);
                oItem.SubItems.Add(oMobileNumberAssign.UserName);
                oItem.SubItems.Add(oMobileNumberAssign.EmployeeCode);
                oItem.SubItems.Add(oMobileNumberAssign.DesignationName);
                oItem.SubItems.Add(oMobileNumberAssign.CompanyName);
                oItem.SubItems.Add(oMobileNumberAssign.DepartmentName);
                oItem.SubItems.Add(oMobileNumberAssign.CreditLimitTypeName);
                oItem.SubItems.Add(oMobileNumberAssign.CreditLimit.ToString());
                oItem.SubItems.Add(oMobileNumberAssign.EdgePackage);
                oItem.SubItems.Add(oMobileNumberAssign.EdgePackageAmount.ToString());
                oItem.SubItems.Add(oMobileNumberAssign.TotalLimit.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MonthShortName), oMobileNumberAssign.TMonth));
                oItem.SubItems.Add(oMobileNumberAssign.TYear.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oMobileNumberAssign.BillAmount));
                oItem.SubItems.Add(oMobileNumberAssign.DeductFromSalary.ToString());


                lblApproved.BackColor = Color.FromArgb(0, 128, 0);
                lblPending.BackColor = Color.FromArgb(255, 250, 205);
                lblReject.BackColor = Color.FromArgb(240, 128, 128);
                lblPartialApproved.BackColor = Color.FromArgb(0, 255, 127); 

                switch (oMobileNumberAssign.ApproveStatus)
                {
                    case 1:
                        oItem.BackColor = Color.FromArgb(255, 250, 205);
                        break;
                    case 2:
                        oItem.BackColor = Color.FromArgb(0, 128, 0);
                        break;
                    case 3:
                        oItem.BackColor = Color.FromArgb(240, 128, 128);
                        break;
                    case 4:
                        oItem.BackColor = Color.FromArgb(0, 255, 127);
                        break;
                    default:
                        break;
                }
                oItem.Tag = oMobileNumberAssign;
            }

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

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                ApproveDeductBill();
            }
       }
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                RejectDeductBill();
                DataLoadControl();
            }
        }
        private bool ValidateUIInput()
        {
            if (lvwDeductBills.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ApproveDeductBill()
        {            
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwDeductBills.SelectedItems[0].Tag;
            if (oMobileNumberAssign.ApproveStatus == (int)Dictionary.MobileDeductApproveStatus.Approved)
            {
                MessageBox.Show("This Number Alredy Approved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (oMobileNumberAssign.ApproveStatus == (int)Dictionary.MobileDeductApproveStatus.Rejected)
            {
                MessageBox.Show("You Can't Approve this Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmMobileBillDeductionApproval oFrom = new frmMobileBillDeductionApproval();
            oFrom.ShowDialog(oMobileNumberAssign);
            if (oFrom._bActivityDone)
            {
                DataLoadControl();
            }

            //MobileBill _oMobileBill = new MobileBill();
            //DialogResult oResult = MessageBox.Show("Do You Want To Approve Deduct Bill? " + oMobileNumberAssign.MobileNumber + " ? ", "Confirm Approve Deduct Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (oResult == DialogResult.Yes)
            //{
            //    MobileBillDeductHistory _oMobileBillDeductHistory = new MobileBillDeductHistory();
            //    _oMobileBillDeductHistory.AprovalUserID = Utility.UserId;
            //    _oMobileBillDeductHistory.CreateDate = DateTime.Now;
            //    _oMobileBillDeductHistory.BillID = oMobileNumberAssign.BillID;
            //    _oMobileBillDeductHistory.DeductAmount = oMobileNumberAssign.DeductFromSalary;

            //    _oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Approved;
            //    _oMobileBill.BillID = oMobileNumberAssign.BillID;

            //    try
            //    {
            //        _oMobileBillDeductHistory.Add();
            //        _oMobileBill.ApproveDeductBill();
            //        DBController.Instance.CommitTransaction();
            //        MessageBox.Show("Successfully Approved Deduct Bill", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        DBController.Instance.RollbackTransaction();
            //        MessageBox.Show(ex.Message, "Error!!!");
            //    }
            //}
        }


        private void RejectDeductBill()
        {
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwDeductBills.SelectedItems[0].Tag;
            MobileBill _oMobileBill = new MobileBill();
             DialogResult oResult = MessageBox.Show("Do You Want To Reject Deduct Bill? " + oMobileNumberAssign.MobileNumber + " ? ", "Confirm Approve Deduct Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (oResult == DialogResult.Yes)
             {
                 _oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Rejected;
                 _oMobileBill.BillID = oMobileNumberAssign.BillID;
                 try
                 {
                     if (oMobileNumberAssign.BillAmount > oMobileNumberAssign.TotalLimit)
                     {
                         _oMobileBill.DeductFromSalary = oMobileNumberAssign.BillAmount - oMobileNumberAssign.TotalLimit;
                     }                  

                     _oMobileBill.RejectDeductBill();
                     DBController.Instance.CommitTransaction();
                     MessageBox.Show("Successfully Reject Deduct Bill", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
      

    }
}