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
    public partial class frmMobileBillDeductionApproval : Form
    {
        public frmMobileBillDeductionApproval()
        {
            InitializeComponent();
        }
        TELLib _oTELLib;
        MobileNumberAssign _oMobileNumberAssign;
        public bool _bActivityDone = false;
        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            _oTELLib = new TELLib();
            txtMobileNo.Text = oMobileNumberAssign.MobileNumber;
            txtBillMonth.Text = Enum.GetName(typeof(Dictionary.MonthShortName), oMobileNumberAssign.TMonth) + " ," + oMobileNumberAssign.TYear.ToString();
            txtTotalLimit.Text = oMobileNumberAssign.TotalLimit.ToString();
            txtDeductAmount.Text = oMobileNumberAssign.DeductFromSalary.ToString();
            txtBillAmount.Text = _oTELLib.TakaFormat(oMobileNumberAssign.BillAmount);
            _oMobileNumberAssign = oMobileNumberAssign;
            this.ShowDialog();
        }
        private void frmMobileBillDeductionApproval_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateUIInput()
        {
            if (txtApproveAmount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Approve Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (Convert.ToDouble(txtApproveAmount.Text.Trim()) > Convert.ToDouble(txtDeductAmount.Text.Trim()))
                {
                    MessageBox.Show("Approve amount must be less than or equal to deduct amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Convert.ToDouble(txtApproveAmount.Text.Trim()) < 0 || Convert.ToDouble(txtApproveAmount.Text.Trim()) == 0)
                {
                    MessageBox.Show("Approve amount must be greater than 0 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void chkFullApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullApprove.Checked)
            {
                txtApproveAmount.ReadOnly = true;
                txtApproveAmount.Text = txtDeductAmount.Text;
            }
            else
            {
                txtApproveAmount.ReadOnly = false;
                txtApproveAmount.Text = string.Empty;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                Approve();
                this.Close();
            }
        }
        private void Approve()
        {
            DialogResult oResult = MessageBox.Show("Do You Want To Approve Deduct Bill \nFor Mobile No. " + _oMobileNumberAssign.MobileNumber+" ?", "Confirm Approve Deduct Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                MobileBillDeductHistory _oMobileBillDeductHistory = new MobileBillDeductHistory();
                MobileBill _oMobileBill = new MobileBill();
                _oMobileBillDeductHistory.AprovalUserID = Utility.UserId;
                _oMobileBillDeductHistory.CreateDate = DateTime.Now;
                _oMobileBillDeductHistory.BillID = _oMobileNumberAssign.BillID;               
                _oMobileBillDeductHistory.DeductAmount = (Convert.ToDouble(txtDeductAmount.Text.Trim()) - Convert.ToDouble(txtApproveAmount.Text.Trim()));
                _oMobileBillDeductHistory.ApproveAmount = Convert.ToDouble(txtApproveAmount.Text.Trim());
                if (Convert.ToDouble(txtDeductAmount.Text.Trim()) == Convert.ToDouble(txtApproveAmount.Text.Trim()))
                {
                    _oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Approved;
                }
                else
                {
                    _oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Partial;
                }
                _oMobileBill.ApproveAmount =_oMobileNumberAssign.ApproveAmount+Convert.ToDouble(txtApproveAmount.Text);
                _oMobileBill.DeductFromSalary = _oMobileBillDeductHistory.DeductAmount;
                _oMobileBill.BillID = _oMobileNumberAssign.BillID;

                try
                {
                    _oMobileBillDeductHistory.Add();
                    _oMobileBill.ApproveDeductBill();
                    DBController.Instance.CommitTransaction();
                    _bActivityDone = true;
                    MessageBox.Show("Successfully Approved Deduct Bill", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtApproveAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtDeductAmount.Text.Trim());
                double b = Convert.ToDouble(txtApproveAmount.Text.Trim());
                txtDeductAfterApproval.Text = (a - b).ToString();
            }
            catch
            {
                txtDeductAfterApproval.Text = "0";
            }
        }
    }
}