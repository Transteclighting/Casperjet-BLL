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
    public partial class frmPaidJobForInterServiceAssign : Form
    {
        public PaidJobForInterServiceHistory oPaidJobForInterServiceHistory;
        public PaidJobForInterService oPaidJobForInterService;
        //public InterService oInterService;

        public frmPaidJobForInterServiceAssign()
        {
            InitializeComponent();
        }
        public void ShowDialog(PaidJobForInterService oPaidJobForInterService)
        {
            this.Tag = oPaidJobForInterService;
            //LoadCombos();

            ctlInterService1.txtCode.Text = oPaidJobForInterService.InterService.Code;
            ctlInterService1.txtDescription.Text = oPaidJobForInterService.InterService.Name;
            dtExprectedVisitingDate.Value = Convert.ToDateTime(oPaidJobForInterService.ScheduleDate.ToString());
            txtRemarks.Text = oPaidJobForInterService.ScheduleRemarks.ToString();

            lblContactNo.Text = oPaidJobForInterService.ContactNo.ToString();
            lblCustomerName.Text = oPaidJobForInterService.CustomerName;
            lblAddress.Text = oPaidJobForInterService.Address;
            lblPaidJobID.Text = oPaidJobForInterService.PaidJobID.ToString();

            this.ShowDialog();
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlInterService1.SelectedInterService == null || ctlInterService1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Inter Service", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlInterService1.Focus();
                return false;
            }
            //if (txtComplainerName.Text == "")
            //{
            //    MessageBox.Show("Please enter Complainer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtComplainerName.Focus();
            //    return false;
            //}


            #endregion

            return true;
        }

        private void Save()
        {

            PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)this.Tag;
            oPaidJobForInterService.AssignInterServiceID = ctlInterService1.SelectedInterService.InterServiceID;
            oPaidJobForInterService.ScheduleDate = dtExprectedVisitingDate.Value;
            //oPaidJobForInterService. = this.txtRemarks;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oPaidJobForInterService.Assign();

                oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();
                oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Assign;

                if (oPaidJobForInterServiceHistory.CheckJobHistory())
                {
                    oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                    oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Assign;
                    //oPaidJobForInterServiceHistory.Dates = "";
                    oPaidJobForInterServiceHistory.Remarks = this.txtRemarks.Text;
                    oPaidJobForInterServiceHistory.UpdateHistoryRemarks();
                }
                else
                {
                    oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                    oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Assign;
                    //oPaidJobForInterServiceHistory.Dates = "";
                    oPaidJobForInterServiceHistory.Remarks = this.txtRemarks.Text;
                    oPaidJobForInterServiceHistory.AddPaidJobHistory();
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Assign Successfully", "Assign", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Refresh();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void frmPaidJobForInterServiceAssign_Load(object sender, EventArgs e)
        {

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

    }
}