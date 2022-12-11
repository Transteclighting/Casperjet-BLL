using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerBankGuarantee : Form
    {
        int nTRanID = 0;
        public frmCustomerBankGuarantee()
        {
            InitializeComponent();
        }

        private void frmCustomerBankGuarantee_Load(object sender, EventArgs e)
        {

        }

        private void dtEffectiveDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtBGAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtExpiryDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {

        }

        private void ctlCustomer1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
               
                this.Close();
            }
        }

        private bool UIValidation()
        {
            if (ctlCustomer1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (Convert.ToDouble(txtBGAmount.Text) <= 0)
            {
                MessageBox.Show("Please Enter Valid BG Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBGAmount.Focus();
                return false;
            }
            if (dtExpiryDate.Value < DateTime.Today.Date)
            {
                MessageBox.Show("Expire Date must be Grater than today", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtExpiryDate.Focus();
                return false;
            }

            return true;

        }

        private void Save()
        {
            if (this.Tag == null)
            {
                
                CustomerBankGuarantee oCustomerBankGuarantee = new CustomerBankGuarantee();

                oCustomerBankGuarantee.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oCustomerBankGuarantee.OpeningDate = dtEffectiveDate.Value.Date;
                oCustomerBankGuarantee.ExpiryDate = dtExpiryDate.Value.Date;
                oCustomerBankGuarantee.BGAmount = Convert.ToDouble(txtBGAmount.Text);


                if (chkIsActive.Checked == true)
                {
                    oCustomerBankGuarantee.IsActive = (int)Dictionary.IsActive.Active;

                }
                else
                {
                    oCustomerBankGuarantee.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomerBankGuarantee.Add();

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CustomerBankGuarantee oCustomerBankGuarantee = new CustomerBankGuarantee();


                oCustomerBankGuarantee.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;

                oCustomerBankGuarantee.OpeningDate = dtEffectiveDate.Value.Date;
                oCustomerBankGuarantee.ExpiryDate = dtExpiryDate.Value.Date;
                oCustomerBankGuarantee.BGAmount = Convert.ToDouble(txtBGAmount.Text);


                if (chkIsActive.Checked == true)
                {
                    oCustomerBankGuarantee.IsActive = (int)Dictionary.IsActive.Active;

                }
                else
                {
                    oCustomerBankGuarantee.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomerBankGuarantee.UpdateStatus(nTRanID);
                    
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Edit Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        public void ShowDialog(CustomerBankGuarantee oCustomerBankGuarantee)
        {

            this.Tag = oCustomerBankGuarantee;
            DBController.Instance.OpenNewConnection();

            nTRanID = oCustomerBankGuarantee.TRanID;
            ctlCustomer1.Enabled = false;
            txtBGAmount.Enabled = true;
            dtEffectiveDate.Enabled = true;
            dtExpiryDate.Enabled = true;

            ctlCustomer1.txtCode.Text = oCustomerBankGuarantee.CustomerCode;
            dtEffectiveDate.Value = oCustomerBankGuarantee.OpeningDate;
            dtExpiryDate.Value = oCustomerBankGuarantee.ExpiryDate;
            txtBGAmount.Text = oCustomerBankGuarantee.BGAmount.ToString();

            if (oCustomerBankGuarantee.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
