using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CSD.CallCenter
{
    public partial class frmConsumerHistory : Form
    {
        int nConsumerID = 0;

        public frmConsumerHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(Customer oConsumerDetail)
        {
            this.Tag = oConsumerDetail;
            this.Cursor = Cursors.Default;
            DBController.Instance.OpenNewConnection();
            nConsumerID = oConsumerDetail.CustomerID;
            txtMobileNo.Text = oConsumerDetail.MobileNo;
            txtAlternativeCellNo.Text = oConsumerDetail.AlternativeCellNo;
            txtConsumerCode.Text = oConsumerDetail.CustomerCode;
            txtConsumerName.Text = oConsumerDetail.CustomerName;
            txtAddress.Text = oConsumerDetail.CustomerAddress;
            txtEmail.Text = oConsumerDetail.EmailAddress;
            txtTelephoneNo.Text = oConsumerDetail.CustomerTelephone;
            if (oConsumerDetail.IsVerified == 1)
            {
                chkVerified.Checked = true;
            }
            else
            {
                chkVerified.Checked = false;
            }

            Customers oConsumerDetails = new Customers();
            oConsumerDetails.GetConsumerHistory(nConsumerID);

            foreach (Customer oCustomerDetail in oConsumerDetails)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oCustomerDetail.Company.ToString();
                oRow.Cells[1].Value = oCustomerDetail.TranType.ToString();
                oRow.Cells[2].Value = oCustomerDetail.ShowroomCode.ToString();
                oRow.Cells[3].Value = oCustomerDetail.SalesType.ToString();
                oRow.Cells[4].Value = oCustomerDetail.TranNo.ToString();
                oRow.Cells[5].Value = Convert.ToDateTime(oCustomerDetail.TranDate).ToString("dd-MMM-yyyy");
                oRow.Cells[6].Value = oCustomerDetail.ProductCode.ToString();
                oRow.Cells[7].Value = oCustomerDetail.ProductName.ToString();
                oRow.Cells[8].Value = oCustomerDetail.Qty.ToString();
                oRow.Cells[9].Value = oCustomerDetail.Amount.ToString();

                dgvLineItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput()
        {
            if (txtConsumerCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Consumer Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsumerCode.Focus();
                return false;
            }
            if (txtConsumerName.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Consumer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsumerName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Email Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Customer oCunsumerDetail = new Customer();
                oCunsumerDetail.CustomerID = nConsumerID;
                oCunsumerDetail.CustomerCode = txtConsumerCode.Text;
                oCunsumerDetail.CustomerName = txtConsumerName.Text;
                oCunsumerDetail.AlternativeCellNo = txtAlternativeCellNo.Text;
                oCunsumerDetail.CustomerAddress = txtAddress.Text;
                oCunsumerDetail.EmailAddress = txtEmail.Text;
                oCunsumerDetail.CustomerTelephone = txtTelephoneNo.Text;
                if (chkVerified.Checked == true)
                {
                    oCunsumerDetail.IsVerified = 1;
                }
                else
                {
                    oCunsumerDetail.IsVerified = 0;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCunsumerDetail.UpdateConsumerDetail();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
    }
}