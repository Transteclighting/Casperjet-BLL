using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmPotentialCustomerFollowup : Form
    {
        public bool IsTrue = false;
        string sMobileNo = "";
        PotentialCustomer _oPotentialCustomer;
        int nOutboundCallID = 0;


        public frmPotentialCustomerFollowup()
        {
            InitializeComponent();
        }

        public void ShowDialog(PotentialCustomer oPotentialCustomer)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oPotentialCustomer;

            sMobileNo = oPotentialCustomer.MobileNo;
            txtName.Text = oPotentialCustomer.Name;
            dtNextFollowUpdate.Value = DateTime.Now.Date;
            txtMobile.Text = oPotentialCustomer.MobileNo;
            txtEmail.Text = oPotentialCustomer.Email;
            txtAddress.Text = oPotentialCustomer.Address;
            PotentialCustomers oPotentialCustomers = new PotentialCustomers();
            oPotentialCustomers.GetTransactionalHistory(sMobileNo);
            foreach (PotentialCustomer oItem in oPotentialCustomers)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvTransctionalHistory);
                oRow.Cells[0].Value = oItem.ShowroomCode.ToString();
                oRow.Cells[1].Value = oItem.CreateDate.ToString("dd-MMM-yyyy");
                oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.PotentialCustomerSource), oItem.Source);
                oRow.Cells[3].Value = oItem.ProductName.ToString();
                oRow.Cells[4].Value = oItem.Qty.ToString();
                oRow.Cells[5].Value = oItem.Value.ToString();
                dgvTransctionalHistory.Rows.Add(oRow);

            }

            this.ShowDialog();
        }

        private bool UIValidation()
        {
            #region ValidInput
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtMobile.Text.Trim() == "")
            {
                MessageBox.Show("Please enter customer mobile no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobile.Focus();
                return false;
            }

            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter customer email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please enter customer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            #endregion
            return true;

        }

        private void LoadCombo()
        {
            dtNextFollowUpdate.Value = DateTime.Today;

            //Source
            cmbStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutboundStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.OutboundStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


        }
        private void frmPotentialCustomerFollowup_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            IsTrue = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oPotentialCustomer = new PotentialCustomer();
                    _oPotentialCustomer.Name = txtName.Text;
                    _oPotentialCustomer.Address = txtAddress.Text;
                    _oPotentialCustomer.MobileNo = txtMobile.Text;
                    _oPotentialCustomer.Email = txtEmail.Text;
                    _oPotentialCustomer.NextFollowupDate = dtNextFollowUpdate.Value.Date;
                    _oPotentialCustomer.Status = cmbStatus.SelectedIndex + 1;
                    _oPotentialCustomer.Remarks = txtRemarks.Text;
                    _oPotentialCustomer.CreateDate = DateTime.Now.Date;
                    _oPotentialCustomer.CreateUserID = Utility.UserId;
                    _oPotentialCustomer.AddOutboundCall();
                    _oPotentialCustomer.AddOutboundCallHistory();
                    IsTrue = true;
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Add. ID# " + _oPotentialCustomer.OutboundCallID.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}