using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;


namespace CJ.Win.CSD
{
    public partial class frmTechnicianWiseFeedBackDates : Form
    {
        CSDFeedbackDateHistorys _oCSDFeedbackDateHistorys;
        CSDFeedbackDateHistory oCSDFeedbackDateHistory;

        public frmTechnicianWiseFeedBackDates()
        {
            InitializeComponent();
        }

        private void TechnicianWiseFeedBackDates_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDFeedbackDateHistorys = new CSDFeedbackDateHistorys();
            DBController.Instance.OpenNewConnection();

            _oCSDFeedbackDateHistorys.RefreshByFeedBackDate(dtFromDate.Value.Date, dtToDate.Value.Date, txtName.Text);
            this.Text = "Spare Parts Transfer | Total: " + "[" + _oCSDFeedbackDateHistorys.Count + "]";
            lvwCSDFeedBackDate.Items.Clear();
            foreach (CSDFeedbackDateHistory oCSDFeedbackDateHistory in _oCSDFeedbackDateHistorys)
            {
                ListViewItem oItem = lvwCSDFeedBackDate.Items.Add(oCSDFeedbackDateHistory.Code);
                oItem.SubItems.Add(oCSDFeedbackDateHistory.Name);
                oItem.SubItems.Add(oCSDFeedbackDateHistory.FeedbackDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDFeedbackDateHistory.JobCount.ToString());
                oItem.Tag = oCSDFeedbackDateHistory;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwCSDFeedBackDate.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select Item to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            CSDFeedbackDateHistory oCSDFeedbackDateHistory = (CSDFeedbackDateHistory)lvwCSDFeedBackDate.SelectedItems[0].Tag;
            CSDFeedbackDateHistorys oCSDFeedbackDateHistorys = new CSDFeedbackDateHistorys();
            oCSDFeedbackDateHistorys.PrintByFeedBackDate(dtFromDate.Value.Date,dtToDate.Value.Date,oCSDFeedbackDateHistory.TechnicianID);
            rptTechnicianWisefeedBackDate oReport = new rptTechnicianWisefeedBackDate();

            oReport.SetDataSource(oCSDFeedbackDateHistorys);
            oReport.SetParameterValue("UserName", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}