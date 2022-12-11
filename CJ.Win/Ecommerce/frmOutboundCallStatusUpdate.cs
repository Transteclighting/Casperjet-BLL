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
    public partial class frmOutboundCallStatusUpdate : Form
    {
        int nOutboundCallID = 0;
        PotentialCustomer _oPotentialCustomer;

        public frmOutboundCallStatusUpdate()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            //Source
            cmbStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutboundStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.OutboundStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        public void ShowDialog(PotentialCustomer oPotentialCustomer)
        {
            DBController.Instance.OpenNewConnection();

            this.Tag = oPotentialCustomer;
            LoadCombo();
            nOutboundCallID = 0;
            nOutboundCallID = oPotentialCustomer.OutboundCallID;
            txtName.Text = oPotentialCustomer.Name;
            txtAddress.Text = oPotentialCustomer.Address;
            txtContact.Text = oPotentialCustomer.MobileNo;
            txtEmail.Text = oPotentialCustomer.Email;
            dtFollowUpdate.Value = oPotentialCustomer.NextFollowupDate;
            txtRemarks.Text = oPotentialCustomer.Remarks;
            int nStatus = oPotentialCustomer.Status;
            cmbStatus.SelectedIndex = nStatus - 1;

            PotentialCustomers oPotentialCustomers = new PotentialCustomers();
            oPotentialCustomers.GetCallHistory(oPotentialCustomer.MobileNo);
            foreach (PotentialCustomer oItem in oPotentialCustomers)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dsvCallHistory);
                oRow.Cells[0].Value = oItem.CreateDate.ToString("dd-MMM-yyyy");
                oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.OutboundStatus), oItem.Status);
                oRow.Cells[2].Value = oItem.Remarks.ToString();
                dsvCallHistory.Rows.Add(oRow);

            }

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oPotentialCustomer = new PotentialCustomer();
                _oPotentialCustomer.OutboundCallID = nOutboundCallID;
                _oPotentialCustomer.Name = txtName.Text;
                _oPotentialCustomer.Address = txtAddress.Text;
                _oPotentialCustomer.MobileNo = txtContact.Text;
                _oPotentialCustomer.Email = txtEmail.Text;
                _oPotentialCustomer.NextFollowupDate = dtFollowUpdate.Value.Date;
                _oPotentialCustomer.Remarks = txtRemarks.Text;
                _oPotentialCustomer.Status = cmbStatus.SelectedIndex + 1;

                _oPotentialCustomer.UpdateOutboundCall();
                _oPotentialCustomer.AddOutboundCallHistory();

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void frmOutboundCallStatusUpdate_Load(object sender, EventArgs e)
        {
            this.Text = "Outbound Call Status Update";
        }
    }
}