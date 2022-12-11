
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
    public partial class frmJobSearch : Form
    {
        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;

        public frmJobSearch()
        {
            InitializeComponent();
        }

        private void frmJobSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            ReplaceJobFromCassandras oReplaceJobFromCassandras = new ReplaceJobFromCassandras();

            lvwJobSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oReplaceJobFromCassandras.RefreshReplaceJob(txtJobNo.Text, txtCustomerName.Text, txtContactNo.Text);

            this.Text = "Total Job = " + "[" + oReplaceJobFromCassandras.Count + "]";
            foreach (ReplaceJobFromCassandra oReplaceJobFromCassandra in oReplaceJobFromCassandras)
            {
                ListViewItem oItem = lvwJobSearch.Items.Add(oReplaceJobFromCassandra.JobNo.ToString());
                oItem.SubItems.Add(oReplaceJobFromCassandra.CustomerName);
                oItem.SubItems.Add(oReplaceJobFromCassandra.Mobile);
                oItem.SubItems.Add(oReplaceJobFromCassandra.FirstAddress);

                oItem.Tag = oReplaceJobFromCassandra;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtJobNo.Text = "";
            txtCustomerName.Text = "";
            txtContactNo.Text = "";
            DataLoadControl();
        }
    
        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void lvwJobSearch_DoubleClick(object sender, EventArgs e)
        {

            ReplaceJobFromCassandra oReplaceJobFromCassandra = (ReplaceJobFromCassandra)lvwJobSearch.SelectedItems[0].Tag;

            _oReplaceJobFromCassandra.JobNo = oReplaceJobFromCassandra.JobNo;
            _oReplaceJobFromCassandra.CustomerName = oReplaceJobFromCassandra.CustomerName;
            _oReplaceJobFromCassandra.Mobile = oReplaceJobFromCassandra.Mobile;
            this.Close();
        }

        private void lvwJobSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            ReplaceJobFromCassandra oReplaceJobFromCassandra = (ReplaceJobFromCassandra)lvwJobSearch.SelectedItems[0].Tag;

            _oReplaceJobFromCassandra.JobNo = oReplaceJobFromCassandra.JobNo;
            _oReplaceJobFromCassandra.CustomerName = oReplaceJobFromCassandra.CustomerName;
            _oReplaceJobFromCassandra.Mobile = oReplaceJobFromCassandra.Mobile;
            this.Close();
        }

        public bool ShowDialog(ReplaceJobFromCassandra oReplaceJobFromCassandra)
        {
            _oReplaceJobFromCassandra = oReplaceJobFromCassandra;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

    }

}