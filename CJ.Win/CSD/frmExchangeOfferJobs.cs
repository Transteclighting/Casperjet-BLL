using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferJobs : Form
    {
        ExchangeOfferJobs _oExchangeOfferJobs;
        ExchangeOfferVenders _oExchangeOfferVenders;
        bool IsCheck = false;


        public frmExchangeOfferJobs()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExchangeOfferJob oForm = new frmExchangeOfferJob();
            oForm.Show();
            DataLoadControl();
        }
        public void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            /************Vender****************/
            _oExchangeOfferVenders = new ExchangeOfferVenders();
            _oExchangeOfferVenders.RefreshforCombo();
            cmbVenderName.Items.Clear();
            cmbVenderName.Items.Add("--Select Vender Name--");
            foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
            {
                cmbVenderName.Items.Add(oExchangeOfferVender.Name);
            }
            cmbVenderName.SelectedIndex = 0;

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

            if (lvwExchangeOfferJob.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Assign.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            if (oExchangeOfferJob.Status == (int)Dictionary.ExchangeOfferStatus.Create)
            {
                frmExchangeOfferJobAssign oForm = new frmExchangeOfferJobAssign((int)Dictionary.ExchangeOfferStatus.Assign);
                oForm.ShowDialog(oExchangeOfferJob);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Assigned", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }
        private void DataLoadControl()
        {
            _oExchangeOfferJobs = new ExchangeOfferJobs();
            lvwExchangeOfferJob.Items.Clear();


            int nVenderID = 0;
            if (cmbVenderName.SelectedIndex == 0)
            {
                nVenderID = -1;
            }
            else
            {
                nVenderID = _oExchangeOfferVenders[cmbVenderName.SelectedIndex - 1].VenderID;
            }


            DBController.Instance.OpenNewConnection();
            _oExchangeOfferJobs.GetJobs(dtFromDate.Value.Date, dtToDate.Value.Date, nVenderID, txtJobNo.Text.Trim(),txtContactNo.Text.Trim(),txtCustomerName.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ExchangeOfferJob oExchangeOfferJob in _oExchangeOfferJobs)
            {
                ListViewItem oItem = lvwExchangeOfferJob.Items.Add(oExchangeOfferJob.JobNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oExchangeOfferJob.ContactDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExchangeOfferJob.CustomerName.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.Address.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.ContactNo.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.Email.ToString());
                //oItem.SubItems.Add(oExchangeOfferJob.Email.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.VenderName.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.ParentCustomerName.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.StatusName.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.TerminalName.ToString());

                oItem.Tag = oExchangeOfferJob;
            }
            this.Text = "Exchange Offer Job List[" + _oExchangeOfferJobs.Count + "]";
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmExchangeOfferJobs_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwExchangeOfferJob.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            if (oExchangeOfferJob.Status == (int)Dictionary.ExchangeOfferStatus.Assign)
            {
                frmExchangeOfferJobAssign oForm = new frmExchangeOfferJobAssign((int)Dictionary.ExchangeOfferStatus.Cancel);
                oForm.ShowDialog(oExchangeOfferJob);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Assign status can be Canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }
}