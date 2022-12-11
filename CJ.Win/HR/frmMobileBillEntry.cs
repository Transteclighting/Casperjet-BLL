using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMobileBillSingleEntry : Form
    {

        public frmMobileBillSingleEntry()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            this.Tag = oMobileNumberAssign;
            lblUserName.Text = oMobileNumberAssign.UserName;
            lblMobileNumber.Text = oMobileNumberAssign.MobileNumber;
            lblBillMonth.Text = Enum.GetName(typeof(Dictionary.MonthShortName), oMobileNumberAssign.TMonth) + ", " + oMobileNumberAssign.TYear;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtAmount.Text == String.Empty)
            {
                MessageBox.Show("Please Enter The Amount Of Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            #endregion
            return true;
        }

        private void Save()
        {
            if (this.Tag != null)
            {
                MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)this.Tag;
                MobileBill oMobileBill = new MobileBill();
                           
                try
                {
                    DBController.Instance.OpenNewConnection();
                    if (oMobileNumberAssign.DatapacID != null)
                    {
                        MobileDatapac _oMobileDatapac = new MobileDatapac();
                        _oMobileDatapac.DatapacID = oMobileNumberAssign.DatapacID;
                        _oMobileDatapac.Refresh();                        
                        oMobileBill.DatapacID = oMobileNumberAssign.DatapacID;
                        oMobileBill.DatapacLimit = _oMobileDatapac.PackageAmount;
                    }
                    var anEmployee = new Employee
                    {
                        EmployeeID = oMobileNumberAssign.EmployeeID
                    };
                    anEmployee.Refresh();
                    oMobileBill.EmpLocationId = anEmployee.LocationID;


                    oMobileBill.MobileID = oMobileNumberAssign.MobileID;
                    oMobileBill.AssignID = oMobileNumberAssign.ID;               
                    oMobileBill.BillAmount = Convert.ToDouble(txtAmount.Text);
                    oMobileBill.OperatorInvoiceNumber = txtInvoiceNo.Text.Trim();
                    oMobileBill.CreaditLimitType = oMobileNumberAssign.CreditLimitType;
                    oMobileBill.CreaditLimit = oMobileNumberAssign.CreditLimit;                    
                    oMobileBill.TMonth = oMobileNumberAssign.TMonth;
                    oMobileBill.TYear = oMobileNumberAssign.TYear;
                    if (oMobileBill.CreaditLimitType == (int)Dictionary.MobileCreaditLimitType.Actual)
                    {
                        oMobileBill.DeductFromSalary = 0;
                        oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
                    }
                    else
                    {
                        if ((oMobileBill.CreaditLimit + oMobileBill.DatapacLimit) < oMobileBill.BillAmount)
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
                    
                    string billMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oMobileBill.TMonth) + ", " + oMobileBill.TYear;

                    if (oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, oMobileBill.TMonth, oMobileBill.TYear))
                    {
                        DBController.Instance.BeginNewTransaction();
                        oMobileBill.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Save The Bill For Mobile No: " + oMobileNumberAssign.MobileNumber + ", Month of " + billMonth, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Bill Already Saved Againts This Mobile Number For The Month Of " + billMonth + " ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                   
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        
        private void frmMobileBillSingleEntry_Load(object sender, EventArgs e)
        {

        }
    }
}