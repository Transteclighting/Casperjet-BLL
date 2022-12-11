
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
    public partial class frmReplaceInform : Form
    {
        public ReplaceHistory oReplaceHistory;

        public frmReplaceInform()
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

            txtInformRemarks.Text = oReplace.InformedRemarks.ToString();
            dtExprectedDeliveryDate.Value = Convert.ToDateTime(oReplace.ApproxDeliveryDate.ToString());


            this.ShowDialog();
        }

        //private bool validateUIInput()
        //{
        //    #region Input Information Validation


        //    //if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text=="")
        //    //{
        //    //    MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    ctlEmployee1.Focus();
        //    //    return false;
        //    //}
        //    if (txtHappyDetails.Text == "")
        //    {
        //        MessageBox.Show("Please enter the Message", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtHappyDetails.Focus();
        //        return false;
        //    }


        //    #endregion

        //    return true;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            Replace oReplace = (Replace)this.Tag;
            oReplace.ApproxDeliveryDate = dtExprectedDeliveryDate.Value;          
            try
            {
                DBController.Instance.BeginNewTransaction();
                oReplace.InformToCustomerReplace();
                {
                    oReplaceHistory = new ReplaceHistory();
                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.InformToCustomer;
                    if (oReplaceHistory.CheckReplace())
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtInformRemarks.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.InformToCustomer;
                        oReplaceHistory.UpdateReplaceHistoryRemarks();
                    }
                    else
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtInformRemarks.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.InformToCustomer;
                        oReplaceHistory.AddReplaceHistory();
                    }
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

        private void frmReplaceInform_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}