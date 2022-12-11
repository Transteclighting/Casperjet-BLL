using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmISVPartsRequisitionCancel : Form
    {

        public frmISVPartsRequisitionCancel()
        {
            InitializeComponent();
        }

        public void ShowDialog(SparePartsTransaction oSparePartsTransaction)
        {

            this.Tag = oSparePartsTransaction;

            lblReportNo.Text = oSparePartsTransaction.ReportNo.ToString();
            lblSerialNo.Text = oSparePartsTransaction.SerialNo.ToString();
            lblRequisitionID.Text = oSparePartsTransaction.ISVRequisitionID.ToString();
            lblInterService.Text = oSparePartsTransaction.InterService.Name.ToString();
            txtCancelReason.Text = oSparePartsTransaction.CancelReason.ToString();
            this.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtCancelReason.Text == "")
                {
                    MessageBox.Show("Please enter Cancel Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCancelReason.Focus();
                    return false;
                }

            #endregion

            return true;
        }
        private void Save()
        {
            SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)this.Tag;

            oSparePartsTransaction.CancelReason = txtCancelReason.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();

                oSparePartsTransaction.CancelStatus();
                
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Cancel Successfully", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}