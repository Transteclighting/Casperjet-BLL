using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Promotion;
using System.Collections.Generic;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Store
{
    public partial class frmCSDTechnicianTransportationApprove : Form
    {

        public bool _bActionSave = false;
        int _nStatus = 0;

        public frmCSDTechnicianTransportationApprove(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private bool validateUIInput()
        {
            if (txtPartialAmt.Text == "")
            {
                MessageBox.Show("Please enter partial amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartialAmt.Focus();
                return false;
            }

            if (Convert.ToDouble(lblFullAmt.Text.ToString()) < Convert.ToDouble(txtPartialAmt.Text.ToString()))
            {
                MessageBox.Show("Partial amount must be less than full amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartialAmt.Focus();
                return false;
            }

            return true;
        }


        private void Save()
        {
            CSDTechnicianTransportation oCSDTechnicianTransportation = (CSDTechnicianTransportation)this.Tag;

            oCSDTechnicianTransportation.PartialAmount = Convert.ToDouble(txtPartialAmt.Text.ToString());
            oCSDTechnicianTransportation.Status = (int)Dictionary.CSDTechnicianTransportationStatus.Approved;

            oCSDTechnicianTransportation.ApproveUserID = Utility.UserId;
            oCSDTechnicianTransportation.ApproveDate = DateTime.Now;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oCSDTechnicianTransportation.ApprovedCSDTechnicianTransportation();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You have successfully approved the transaction: " + oCSDTechnicianTransportation.TransportationID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(CSDTechnicianTransportation oCSDTechnicianTransportation)
        {
            this.Tag = oCSDTechnicianTransportation;

            lblTechnicianName.Text = oCSDTechnicianTransportation.TechnicianName;
            dtFromDate.Value = oCSDTechnicianTransportation.FromDate;
            dtToDate.Value = oCSDTechnicianTransportation.ToDate;
            lblFullAmt.Text = oCSDTechnicianTransportation.Amount.ToString();
            txtPartialAmt.Text = oCSDTechnicianTransportation.PartialAmount.ToString();

            lblTechnicianName.Enabled = false;
            dtFromDate.Enabled = false;
            dtToDate.Enabled = false;
            lblFullAmt.Enabled = false;

            this.ShowDialog();
        }

        private void rdFullAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFullAmount.Checked)
            {
                lblPartialAmt.Visible = false;
                txtPartialAmt.Visible = false;
            }
        }

        private void rdPartialAmt_CheckedChanged(object sender, EventArgs e)
        {
            lblPartialAmt.Visible = true;
            txtPartialAmt.Visible = true;
        }

        private void frmCSDTechnicianTransportationApprove_Load(object sender, EventArgs e)
        {
            lblPartialAmt.Visible = false;
            txtPartialAmt.Visible = false;
            rdFullAmount.Checked = true;
        }


        private void txtPartialAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
