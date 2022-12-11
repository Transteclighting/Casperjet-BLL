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
    public partial class frmPaidJobForInterServiceWIP : Form
    {

        public PaidJobForInterServiceHistory oPaidJobForInterServiceHistory;
        public PaidJobForInterService oPaidJobForInterService;

        public frmPaidJobForInterServiceWIP()
        {
            InitializeComponent();
        }
        //private void LoadCombos()
        //{

        //    //HappyStatus
        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainHappyCall)))
        //    {
        //        cmbHappyStatus.Items.Add(Enum.GetName(typeof(Dictionary.ComplainHappyCall), GetEnum));
        //    }
        //    cmbHappyStatus.SelectedIndex = (int)Dictionary.ComplainHappyCall.Satisfy;
        //}

        public void ShowDialog(PaidJobForInterService oPaidJobForInterService)
        {
            this.Tag = oPaidJobForInterService;

            lblContactNo.Text = oPaidJobForInterService.ContactNo.ToString();
            lblCustomerName.Text = oPaidJobForInterService.CustomerName;
            lblAddress.Text = oPaidJobForInterService.Address;
            lblPaidJobID.Text = oPaidJobForInterService.PaidJobID.ToString();

            txtRemarks.Text = oPaidJobForInterService.WIPRemarks.ToString();
            
            this.ShowDialog();
        }

        //private bool validateUIInput()
        //{
        //    #region Input Information Validation



        //    if (txtJobNo.Text == "")
        //    {
        //        MessageBox.Show("Please enter the Actual Soluation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtJobNo.Focus();
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
            PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)this.Tag;

            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPaidJobForInterService.WorkInProgress();

                    oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();

                    oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                    oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.WorkInProgress;

                    if (oPaidJobForInterServiceHistory.CheckJobHistory())
                    {
                        oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                        oPaidJobForInterServiceHistory.Remarks =this.txtRemarks.Text;
                        oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.WorkInProgress;
                        //oPaidJobForInterServiceHistory.Dates = this.dtExpectedDeliveryDate.Value.Date;
                        oPaidJobForInterServiceHistory.UpdateHistoryRemarks();
                    }
                    else
                    {
                        oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                        oPaidJobForInterServiceHistory.Remarks = this.txtRemarks.Text;
                        oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.WorkInProgress;
                        //oPaidJobForInterServiceHistory.Dates = this.dtExpectedDeliveryDate.Value.Date;
                        oPaidJobForInterServiceHistory.AddPaidJobHistory();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                this.Refresh();
            }

        }

     }
}