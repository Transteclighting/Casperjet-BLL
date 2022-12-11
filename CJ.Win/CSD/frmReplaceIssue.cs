

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
    public partial class frmReplaceIssue : Form
    {
        public ReplaceHistory oReplaceHistory;
        public Replace oReplace;

        public frmReplaceIssue()
        {
            InitializeComponent();
        }

        //private void frmReplaceIssue_Load(object sender, EventArgs e)
        //{
        //    LoadCombos();
        //}
        public void ShowDialog(Replace oReplace)
        {
            this.Tag = oReplace;
      
            lblReplaceID.Text = oReplace.ReplaceID.ToString();
            lblJobNo.Text = oReplace.ReplaceJobFromCassandra.JobNo;
            lblCustomerName.Text = oReplace.ReplaceJobFromCassandra.CustomerName;
            lblContactNo.Text = oReplace.ReplaceJobFromCassandra.Mobile;

            ctlProduct1.txtCode.Text = oReplace.Product.ProductCode.ToString();
            ctlProduct1.txtDescription.Text = oReplace.Product.ProductName;
            txtBarcodeSL.Text = oReplace.IssueProductBarcode.ToString();
            txtIssueRemarks.Text = oReplace.IssueRemarks.ToString();
            dtIssueDate.Value = Convert.ToDateTime(oReplace.IssueDate.ToString());

            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text == "")

            {
                MessageBox.Show("Please Select a Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.Focus();
                return false;
            }
            if (ctlProduct1.SelectedSerarchProduct == null)
            {
                MessageBox.Show("Please enter a Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtBarcodeSL.Text == "")
            {
                MessageBox.Show("Please enter Issue Product Barcode SL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            oReplace.IssueProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            oReplace.IssueDate = dtIssueDate.Value.Date;
            oReplace.Status = (int)Dictionary.ReplaceStatusCriteria.IssueFromLog;
            oReplace.IssueProductBarcode = txtBarcodeSL.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oReplace.IssueReplace();

                oReplaceHistory = new ReplaceHistory();
                oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.IssueFromLog;               

                if (oReplaceHistory.CheckReplace())
                {
                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Remarks = this.txtIssueRemarks.Text;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.IssueFromLog;
                    oReplaceHistory.UpdateReplaceHistoryRemarks();
                }
                else
                {
                    oReplaceHistory = new ReplaceHistory();
                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Remarks = this.txtIssueRemarks.Text;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.IssueFromLog;
                    oReplaceHistory.AddReplaceHistory();
                    
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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