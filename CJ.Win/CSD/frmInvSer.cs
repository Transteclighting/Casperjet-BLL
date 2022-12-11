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
    public partial class frmInvSer : Form
    {
        InvSer _oInvSer;
        public frmInvSer()
        {
            InitializeComponent();
        }

        private void frmInvSer_Load(object sender, EventArgs e)
        {

            //DataLoadControl();

        }

        private void DataLoadControl()
        {
            //Utility oUtility = _oUtilitys[cmbComplainStatus.SelectedIndex];
            //_nComplainStatus = oUtility.SatusId;


            InvSers oInvSers = new InvSers();
            lvwInvoiceSearches.Items.Clear();
            DBController.Instance.OpenNewConnection();

            if (All.Checked == false)
            {

                oInvSers.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtBarcode.Text, txtContactNo.Text, txtProductName.Text, txtCustomer.Text, txtAddress.Text, txtInvoiceNo.Text, txtProductCode.Text, txtOutletcode.Text);

            }

            else
            {
                oInvSers.RefreshAll(txtBarcode.Text, txtContactNo.Text, txtProductName.Text, txtCustomer.Text, txtAddress.Text, txtInvoiceNo.Text, txtProductCode.Text, txtOutletcode.Text);


                MessageBox.Show("You Have Successfully Process Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //AppLogger.LogInfo("Win:You Have Successfully Process Data" + Utility.UserId);

            }



            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "InvoiceNo " + "[" + oInvSers.Count + "]";
            foreach (InvSer oInvSer in oInvSers)
            {
                ListViewItem oItem = lvwInvoiceSearches.Items.Add(oInvSer.InvoiceNo);
                oItem.SubItems.Add(oInvSer.InvoiceDate.ToString());
                oItem.SubItems.Add(oInvSer.OutletCode);
                oItem.SubItems.Add(oInvSer.ProductCode);
                oItem.SubItems.Add(oInvSer.ProductName);
                oItem.SubItems.Add(oInvSer.BarCodeSL.ToString());
                oItem.SubItems.Add(oInvSer.CustomerName.ToString());
                oItem.SubItems.Add(oInvSer.Address.ToString());
                oItem.SubItems.Add(oInvSer.MobileNo.ToString());


                oItem.Tag = oInvSer;


            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Arrow;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtBarcode.Text= "";
            txtContactNo.Text= "";
            txtProductName.Text= "";
            txtCustomer.Text= "";
            txtAddress.Text= "";
            txtInvoiceNo.Text= "";
            txtProductCode.Text= "";
            txtOutletcode.Text = "";
        }

    }

}