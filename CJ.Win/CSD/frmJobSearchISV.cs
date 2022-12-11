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


namespace CJ.Win
{
    public partial class frmJobSearchISV : Form
    {
        public int nJobID;
        public string sJobNo;
        public string sProductName;
        int _nUIControl = 0;

        //Jobs _oJobs;

        //public ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        public Job _oJob;

        public frmJobSearchISV(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void frmJobSearchISV_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            Jobs _oJobs = new Jobs();

            lvwJobSearchISV.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oJobs.RefreshJob(txtJobNo.Text, txtCustomerName.Text, txtContactNo.Text, txtProductCode.Text, txtProductName.Text);

            this.Text = "Total Job = " + "[" + _oJobs.Count + "]";
            foreach (Job oJob in _oJobs)
            {
                ListViewItem oItem = lvwJobSearchISV.Items.Add(oJob.JobNo.ToString());
                oItem.SubItems.Add(oJob.ProductName);
                oItem.SubItems.Add(oJob.CustomerName);
                oItem.SubItems.Add(oJob.Mobile);
                oItem.SubItems.Add(oJob.FirstAddress);
                oItem.SubItems.Add(oJob.ProductCode);

                oItem.Tag = oJob;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lvwJobSearch_DoubleClick(object sender, EventArgs e)
        {
            if (_nUIControl == 1)
            {
                Job oJob = (Job)lvwJobSearchISV.SelectedItems[0].Tag;
                _oJob.JobNo = oJob.JobNo;
                _oJob.CustomerName = oJob.CustomerName;
                _oJob.ProductName = oJob.ProductName;
                this.Close();

            }
            else
            {
                //if (e.KeyChar == (char)Keys.Return)
                returnSelectedJob();
                this.Close();
            }

        }
        private void lvwJobSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_nUIControl == 1)
            {
                Job oJob = (Job)lvwJobSearchISV.SelectedItems[0].Tag;
                _oJob.JobNo = oJob.JobNo;
                _oJob.CustomerName = oJob.CustomerName;
                _oJob.ProductName = oJob.ProductName;
                this.Close();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    returnSelectedJob();
                    this.Close();
                }
            }
        }
        
        private void returnSelectedJob()
        {
            foreach (ListViewItem oItem in lvwJobSearchISV.SelectedItems)
            {

                _oJob = (Job)lvwJobSearchISV.SelectedItems[0].Tag;

                nJobID = _oJob.JobID;
                sJobNo = _oJob.JobNo;
                sProductName = _oJob.ProductName;
            }

        }
        private void lvwSPSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedJob();
                this.Close();
            }
        }

        public bool ShowDialog(Job oJob)
        {
            _oJob = oJob;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }

}