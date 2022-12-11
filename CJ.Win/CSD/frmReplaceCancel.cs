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
    public partial class frmReplaceCancel : Form
    {
        public ReplaceHistory oReplaceHistory;
        public frmReplaceCancel()
        {
            InitializeComponent();
        }

    
        public void ShowDialog(Replace oReplace)
        {
            this.Tag = oReplace;

            lblReplaceID.Text = oReplace.ReplaceID.ToString();
            lblJobNo.Text = oReplace.ReplaceJobFromCassandra.JobNo;
            lblCustomerName.Text = oReplace.ReplaceJobFromCassandra.CustomerName;
            lblContactNo.Text = oReplace.ReplaceJobFromCassandra.Mobile;
            txtCancelReason.Text = oReplace.CancelRemarks.ToString();


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation



            if (txtCancelReason.Text == "")
            {
                MessageBox.Show("Please enter the Cancel Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCancelReason.Focus();
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
            Replace oReplace = (Replace)this.Tag;

            try
            {
                DBController.Instance.BeginNewTransaction();

                oReplace.CancelReplace();
             
                    oReplaceHistory = new ReplaceHistory();
                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Cancel;
                    if (oReplaceHistory.CheckReplace())
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtCancelReason.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Cancel;
                        oReplaceHistory.UpdateReplaceHistoryRemarks();
                    }
                    else
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtCancelReason.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Cancel;
                        oReplaceHistory.AddReplaceHistory();
                    }
                
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