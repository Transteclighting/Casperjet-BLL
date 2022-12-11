
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win.Control
{
    public partial class frmCSDJobSearchNew : Form
    {
        CSDJobs _oCSDJobs;
        public CSDJob _oCSDJob;
        
        public frmCSDJobSearchNew()
        {
            InitializeComponent();
        }

        private void frmJobSearch_Load(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oCSDJobs = new CSDJobs();
            lvwCSDJobs.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDJobs.RefreshForSparePartsAssign(txtJobNo.Text, txtCustomerName.Text, txtContactNo.Text);

            this.Text = "CSD Total Job = " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwCSDJobs.Items.Add(oCSDJob.JobNo);
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.MobileNo);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                oItem.Tag = oCSDJob;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        public bool ShowDialog(CSDJob oCSDJob)
        {
            _oCSDJob = oCSDJob;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void lvwCSDJobs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwCSDJobs_DoubleClick_1(object sender, EventArgs e)
        {
            _oCSDJob = new CSDJob();
            _oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            this.Close();
        }

    }

}