using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.POS.RT
{
    public partial class frmExchangeOfferMoneyReceipts : Form
    {
        ExchangeOfferJobs _oExchangeOfferJobs;
        ExchangeOfferVenders _oExchangeOfferVenders;
        bool IsCheck = false;
        ExchangeOfferMRs _oExchangeOfferMRs;
        TELLib _oTELLib;
        
        public frmExchangeOfferMoneyReceipts()
        {
            InitializeComponent();
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
            _oExchangeOfferJobs.GetJobs(dtFromDate.Value.Date, dtToDate.Value.Date, nVenderID, txtJobNo.Text.Trim(), txtContactNo.Text.Trim(), txtCustomerName.Text.Trim(), IsCheck);
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
                oItem.SubItems.Add(Convert.ToDouble(oExchangeOfferJob.Balance).ToString());
                oItem.SubItems.Add(oExchangeOfferJob.StatusName.ToString());
                oItem.SubItems.Add(oExchangeOfferJob.TerminalName.ToString());
                

                oItem.Tag = oExchangeOfferJob;
            }
            this.Text = "Exchange Offer Job List[" + _oExchangeOfferJobs.Count + "]";
        }
        public void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            /************Vender****************/
            _oExchangeOfferVenders = new ExchangeOfferVenders();
            _oExchangeOfferVenders.RefreshforComboPOS();
            cmbVenderName.Items.Clear();
            cmbVenderName.Items.Add("--Select Vender Name--");
            foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
            {
                cmbVenderName.Items.Add(oExchangeOfferVender.Name);
            }
            cmbVenderName.SelectedIndex = 0;

        }

        private void frmExchangeOfferMoneyReceipts_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void GetMR()
        {
            _oExchangeOfferMRs = new ExchangeOfferMRs();
            lvwMR.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oExchangeOfferMRs.GetMR(txtMRNo.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (ExchangeOfferMR oExchangeOfferMR in _oExchangeOfferMRs)
            {
                ListViewItem oItem = lvwMR.Items.Add(oExchangeOfferMR.MoneyReceiptNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oExchangeOfferMR.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExchangeOfferMR.JobNo.ToString());
                oItem.SubItems.Add(oExchangeOfferMR.CreateWHName.ToString());
                oItem.SubItems.Add(oExchangeOfferMR.TransferWHName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oExchangeOfferMR.Amount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ExchangeOfferMRStatus), oExchangeOfferMR.Status));
                
                //oItem.SubItems.Add(oExchangeOfferMR.StatusName.ToString());


                oItem.Tag = oExchangeOfferMR;
            }
            this.Text = "Money Receipts [" + _oExchangeOfferMRs.Count + "]";
        }

        private void GetMRByID(int nJobID)
        {
            _oExchangeOfferMRs = new ExchangeOfferMRs();
            lvwMR.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oExchangeOfferMRs.GetMR(nJobID);
            DBController.Instance.CloseConnection();

            foreach (ExchangeOfferMR oExchangeOfferMR in _oExchangeOfferMRs)
            {
                ListViewItem oItem = lvwMR.Items.Add(oExchangeOfferMR.MoneyReceiptNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oExchangeOfferMR.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExchangeOfferMR.JobNo.ToString());
                oItem.SubItems.Add(oExchangeOfferMR.CreateWHName.ToString());
                oItem.SubItems.Add(oExchangeOfferMR.TransferWHName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oExchangeOfferMR.Amount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ExchangeOfferMRStatus), oExchangeOfferMR.Status));

                //oItem.SubItems.Add(oExchangeOfferMR.StatusName.ToString());


                oItem.Tag = oExchangeOfferMR;
            }
        }
        private void btnGetMR_Click(object sender, EventArgs e)
        {
            GetMR();
        }

        private void lvwExchangeOfferJob_KeyDown(object sender, KeyEventArgs e)
        {
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            GetMRByID(oExchangeOfferJob.JobID);
        }

        private void lvwExchangeOfferJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            GetMRByID(oExchangeOfferJob.JobID);
        }

        private void lvwExchangeOfferJob_KeyUp(object sender, KeyEventArgs e)
        {
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            GetMRByID(oExchangeOfferJob.JobID);
        }

        private void lvwExchangeOfferJob_MouseClick(object sender, MouseEventArgs e)
        {
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            GetMRByID(oExchangeOfferJob.JobID);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (lvwExchangeOfferJob.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExchangeOfferJob oExchangeOfferJob = (ExchangeOfferJob)lvwExchangeOfferJob.SelectedItems[0].Tag;
            if (oExchangeOfferJob.Status == (int)Dictionary.ExchangeOfferStatus.Assign)
            {
                frmExchangeOfferMoneyReceipt oForm = new frmExchangeOfferMoneyReceipt();
                oForm.ShowDialog(oExchangeOfferJob);
                DataLoadControl();
                GetMRByID(oExchangeOfferJob.JobID);

            }
            else
            {
                MessageBox.Show("Only Assign status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwMR.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                int nMRID = 0;
                int nJobID = 0;

                ExchangeOfferMR _oExchangeOfferMR = (ExchangeOfferMR)lvwMR.SelectedItems[0].Tag;
                nMRID = _oExchangeOfferMR.MoneyReceiptID;
                nJobID = _oExchangeOfferMR.JobID;

                ExchangeOfferJob oExchangeOfferJob = new ExchangeOfferJob();
                _oTELLib = new TELLib();
                SystemInfo oSystemInfo = new SystemInfo();

                DBController.Instance.OpenNewConnection();
                oExchangeOfferJob.GetExchengedItem(nJobID);
                oSystemInfo.Refresh();

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptExchangeOfferMR));
                oReport.SetDataSource(oExchangeOfferJob);

                oReport.SetParameterValue("MRNo", _oExchangeOfferMR.MoneyReceiptNo);
                oReport.SetParameterValue("CreateDate", _oExchangeOfferMR.CreateDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("JobNo", _oExchangeOfferMR.JobNo);
                oReport.SetParameterValue("Showroom", oSystemInfo.Shortcode);
                oReport.SetParameterValue("Amount", _oTELLib.TakaFormat(_oExchangeOfferMR.Amount).ToString());
                oReport.SetParameterValue("Amountinword", _oTELLib.TakaWords(_oExchangeOfferMR.Amount));
                oReport.SetParameterValue("Remarks", _oExchangeOfferMR.Remarks);
                oReport.SetParameterValue("CustomerName", _oExchangeOfferMR.CustomerName);
                oReport.SetParameterValue("Address", _oExchangeOfferMR.Address);
                oReport.SetParameterValue("ContactNo", _oExchangeOfferMR.ContactNo);
                oReport.SetParameterValue("Email", _oExchangeOfferMR.Email);
                oReport.SetParameterValue("PrintBy", Utility.Username);

                frmPrintPreview oFrom = new frmPrintPreview();
                oFrom.ShowDialog(oReport);

                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

    }
}