using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win.CSD.Store
{
    public partial class frmPartsIssueToJobs : Form
    {
        SparePartsRs oSparePartsRs;
        public frmPartsIssueToJobs()
        {
            InitializeComponent();
        }
        private void DataLoadControl()
        {

            SparePartsRs oSparePartsRs = new SparePartsRs();
            lvwIssueParts.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oSparePartsRs.GetIssueParts(dtFromDate.Value.Date, dtToDate.Value.Date);

            this.Text = "Parts Receive " + "[" + oSparePartsRs.Count + "]";
            foreach (SparePartsR oSparePartsR in oSparePartsRs)
            {
                ListViewItem oItem = lvwIssueParts.Items.Add(oSparePartsR.Tranno.ToString());
                oItem.SubItems.Add(oSparePartsR.TranDate.ToString());
                oItem.SubItems.Add(oSparePartsR.JobNo.ToString());
                oItem.SubItems.Add(oSparePartsR.UserName.ToString());
                oItem.SubItems.Add(oSparePartsR.Remarks.ToString());

                oItem.Tag = oSparePartsR;
            }
        }


        private void btnPartsIssue_Click(object sender, EventArgs e)
        {
            frmPartsIssueToJob oForm = new frmPartsIssueToJob(1);
            oForm.ShowDialog();
            DataLoadControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmPartsIssueToJobs_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}