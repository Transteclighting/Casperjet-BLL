using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMobileBillEdit : Form
    {
        public frmMobileBillEdit()
        {
            InitializeComponent();
        }
        bool isBillSaved;
        bool isBillDelete;

        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            MobileBill oMobileBill = new MobileBill();
            this.Tag = oMobileNumberAssign;
            lblUserName.Text = oMobileNumberAssign.UserName;
            lblMobileNumber.Text = oMobileNumberAssign.MobileNumber;
            lblBillMonth.Text =  Enum.GetName(typeof(Dictionary.MonthShortName),oMobileNumberAssign.TMonth) + ", " + oMobileNumberAssign.TYear;  
            double _BillAmount = oMobileBill.GetBillByTmonthTyear(oMobileNumberAssign.MobileID, oMobileNumberAssign.TMonth, oMobileNumberAssign.TYear);
            txtBillAmount.Text = _BillAmount.ToString();
            this.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (rdoEditBill.Checked)
                {
                    EditMobileBill();
                    if (isBillSaved == true)
                    {
                        this.Close();
                    }

                }
                else if(rdoDeleteBill.Checked)
                {
                    DeleteMobileBill();
                    if (isBillDelete)
                    {
                        this.Close();
                    }
                }
                

            }
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (rdoEditBill.Checked && txtBillAmount.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Edit Amount Of Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBillAmount.Focus();
                return false;
            }
            else if(!rdoEditBill.Checked && !rdoDeleteBill.Checked)
            {
                MessageBox.Show("Please Checked Bill Edit / Delete Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion
            return true;
        }

        public void EditMobileBill()
        {
            DBController.Instance.OpenNewConnection();
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)this.Tag;
            MobileBill oMobileBill = new MobileBill();
            double _billAmount = Convert.ToDouble(txtBillAmount.Text);
            oMobileBill.MobileID = oMobileNumberAssign.MobileID;
            oMobileBill.BillAmount = _billAmount;
            if (oMobileBill.CreaditLimitType != (int)Dictionary.MobileCreaditLimitType.Actual)
            {
                if ((oMobileBill.BillAmount > (oMobileNumberAssign.CreditLimit + oMobileNumberAssign.EdgePackageAmount)))
                {
                    oMobileBill.DeductFromSalary = oMobileBill.BillAmount - (oMobileNumberAssign.CreditLimit + oMobileNumberAssign.EdgePackageAmount);
                    oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Pending;
                }
                else if ((oMobileBill.BillAmount <= (oMobileNumberAssign.CreditLimit + oMobileNumberAssign.EdgePackageAmount)))
                {
                    oMobileBill.DeductFromSalary = 0;
                    oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
                }
            }
            else {
                oMobileBill.DeductFromSalary = 0;
                oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
            }
            
            oMobileBill.TMonth = oMobileNumberAssign.TMonth;
            oMobileBill.TYear = oMobileNumberAssign.TYear;
            string billMonth = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[oMobileNumberAssign.TMonth - 1];

            try
            {
                if (!oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, oMobileBill.TMonth, oMobileBill.TYear))
                {
                    DBController.Instance.BeginNewTransaction();
                    oMobileBill.EditMobileBill();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit Mobile Bill", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isBillSaved = true;
                }
                else
                {
                    MessageBox.Show("Bill is't saved yet of month, " + billMonth + " " + oMobileNumberAssign.TYear, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isBillSaved = false;
                    
                }               

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void DeleteMobileBill()
        {
            DBController.Instance.OpenNewConnection();
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)this.Tag;
            MobileBill oMobileBill = new MobileBill();            
            oMobileBill.MobileID = oMobileNumberAssign.MobileID;
            oMobileBill.TMonth = oMobileNumberAssign.TMonth;
            oMobileBill.TYear = oMobileNumberAssign.TYear;
            string billMonth = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[oMobileNumberAssign.TMonth - 1];

            DialogResult oResult = MessageBox.Show("Are You Sure to Delete Mobile Bill?", "Delete Mobile Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    if (!oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, oMobileBill.TMonth, oMobileBill.TYear))
                    {
                        DBController.Instance.BeginNewTransaction();
                        oMobileBill.DeleteBillByMobileID();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Delete Mobile Bill", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isBillDelete = true;
                    }
                    else
                    {
                        MessageBox.Show("Bill Is't Saved Yet of Month, " + billMonth + " " + oMobileNumberAssign.TYear, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isBillDelete = false;
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            

        }

        private void frmMobileBillEdit_Load(object sender, EventArgs e)
        {
            lblAmount.Enabled = false;
            txtBillAmount.Enabled = false;
        }


        private void rdoEditBill_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEditBill.Checked)
            {
                lblAmount.Enabled = true;
                txtBillAmount.Enabled = true;
            }
            else
            {
                lblAmount.Enabled = false;
                txtBillAmount.Enabled = false;
            }
        }

        private void rdoDeleteBill_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoDeleteBill.Checked)
            {
                lblAmount.Enabled = true;
                txtBillAmount.Enabled = true;
            }
            else
            {
                lblAmount.Enabled = false;
                txtBillAmount.Enabled = false;
            }
        }
       
    }
}