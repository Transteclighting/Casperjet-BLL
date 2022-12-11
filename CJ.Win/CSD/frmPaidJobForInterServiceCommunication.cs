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
    public partial class frmPaidJobForInterServiceCommunication : Form
    {

        public PaidJobForInterServiceHistory oPaidJobForInterServiceHistory;
        public PaidJobForInterService oPaidJobForInterService;

        public frmPaidJobForInterServiceCommunication()
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

            txtRemarks.Text = oPaidJobForInterService.CommuRemarks.ToString();
            
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation



            if (txtRemarks.Text == "")
            {
                MessageBox.Show("Please enter the Communication Remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
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
            PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)this.Tag;

            oPaidJobForInterService.CommuRemarks = this.txtRemarks.Text;

            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPaidJobForInterService.Communication();

                    oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();

                    oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                    oPaidJobForInterServiceHistory.Status = -9;

                    if (oPaidJobForInterServiceHistory.CheckJobHistory())
                    {
                        oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                        oPaidJobForInterServiceHistory.Remarks = this.txtRemarks.Text;
                        oPaidJobForInterServiceHistory.Status = -9;//Status Not change for Communication
                        //oPaidJobForInterServiceHistory.Dates = "";
                        oPaidJobForInterServiceHistory.UpdateHistoryRemarks();
                    }
                    else
                    {
                        oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                        oPaidJobForInterServiceHistory.Remarks = this.txtRemarks.Text;
                        oPaidJobForInterServiceHistory.Status = -9;//Status Not change for Communication
                        //oPaidJobForInterServiceHistory.Dates = "";
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