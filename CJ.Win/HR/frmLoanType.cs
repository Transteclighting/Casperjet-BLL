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
    public partial class frmLoanType : Form
    {
        int nID = 0;
        public frmLoanType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        public void ShowDialog(LoanType oLoanType)
        {
            this.Tag = oLoanType;
            nID = oLoanType.LoanTypeID;
            txtTypeName.Text = oLoanType.LoanTypeName;
            if (oLoanType.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInactive.Checked = true;
            }

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput()
        {
            if (txtTypeName.Text == "")
            {
                MessageBox.Show("Please Loan Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTypeName.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {
            LoanType oLoanType = new LoanType();

            oLoanType.LoanTypeName = txtTypeName.Text.Trim();

            if (rdoActive.Checked == true)
            {
                oLoanType.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oLoanType.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }

            oLoanType.CreateUserID = Utility.UserId;
            oLoanType.CreateDate = DateTime.Now;
            oLoanType.UpdateUserID = Utility.UserId;
            oLoanType.UpdateDate = DateTime.Now;

            if (this.Tag == null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oLoanType.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Data Save Successfully, ID: " + oLoanType.LoanTypeID.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oLoanType.LoanTypeID = nID;
                    oLoanType.Edit();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Data Save Successfully, ID: " + oLoanType.LoanTypeID.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void frmLoanType_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Loan Type";
                rdoActive.Checked = true;
            }
            else
            {
                this.Text = "Edit Loan Type";
            }
        }
    }
}