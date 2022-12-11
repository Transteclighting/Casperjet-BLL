using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRLoanType : Form
    {
        HRLoanType oHRLoanType;
        int nID = 0;

        public frmHRLoanType()
        {
            InitializeComponent();
        }

        public void ShowDialog(HRLoanType oHRLoanType)
        {
            this.Tag = oHRLoanType;
            nID = 0;
            nID = oHRLoanType.ID;
            txtLoanName.Text = oHRLoanType.LoanName;
            txtMaxAmount.Text = Convert.ToDouble(oHRLoanType.MaxAmount).ToString();
            txtMaxNoofIns.Text = Convert.ToInt32(oHRLoanType.MaxNoofInstallment).ToString();
            if (oHRLoanType.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;

            }
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtLoanName.Text == "")
            {
                MessageBox.Show("Please Enter Loan Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoanName.Focus();
                return false;
            }

            if (txtMaxAmount.Text == "")
            {
                MessageBox.Show("Please Enter Maximum Loan Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxAmount.Focus();
                return false;
            }

            if (txtMaxNoofIns.Text == "")
            {
                MessageBox.Show("Please Enter Maximum No of Installment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxNoofIns.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                oHRLoanType = new HRLoanType();
                oHRLoanType.LoanName = txtLoanName.Text;
                oHRLoanType.MaxAmount = Convert.ToDouble(txtMaxAmount.Text);
                oHRLoanType.MaxNoofInstallment = Convert.ToInt32(txtMaxNoofIns.Text);
                if (chkIsActive.Checked == true)
                {
                    oHRLoanType.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oHRLoanType.IsActive = (int)Dictionary.IsActive.InActive;
                }
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRLoanType.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Loan : " + oHRLoanType.LoanName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                oHRLoanType = new HRLoanType();
                oHRLoanType.ID = nID;
                oHRLoanType.LoanName = txtLoanName.Text;
                oHRLoanType.MaxAmount = Convert.ToDouble(txtMaxAmount.Text);
                oHRLoanType.MaxNoofInstallment = Convert.ToInt32(txtMaxNoofIns.Text);
                if (chkIsActive.Checked == true)
                {
                    oHRLoanType.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oHRLoanType.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRLoanType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Loan : " + oHRLoanType.LoanName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void frmHRLoanType_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) this.Text = "Add New Loan Type";
            else this.Text = "Edit Loan Type";
        }

    }
}