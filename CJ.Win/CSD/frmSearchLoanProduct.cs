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
    public partial class frmSearchLoanProduct : Form
    {
        public int nLoanID;
        public string sLoanNo;
        public string sProductName;

        public ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        public LoanProductCassandra _oLoanProductCassandra;

        public frmSearchLoanProduct()
        {
            InitializeComponent();
        }

        private void lvwLoanProductSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            LoanProductCassandras oLoanProductCassandras = new LoanProductCassandras();

            lvwLoanProductSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oLoanProductCassandras.Refresh(txtLoanProductNo.Text, txtProductCode.Text, txtProductName.Text, txtBarcodeSerial.Text);

            this.Text = "Total Job = " + "[" + oLoanProductCassandras.Count + "]";
            foreach (LoanProductCassandra oLoanProductCassandra in oLoanProductCassandras)
            {
                ListViewItem oItem = lvwLoanProductSearch.Items.Add(oLoanProductCassandra.JobCardNo.ToString());
                oItem.SubItems.Add(oLoanProductCassandra.ReplaceJobFromCassandra.ProductCode);
                oItem.SubItems.Add(oLoanProductCassandra.ReplaceJobFromCassandra.ProductName);
                oItem.SubItems.Add(oLoanProductCassandra.SerialNo);
                oItem.SubItems.Add(oLoanProductCassandra.DamageWarehouseCode);

                oItem.Tag = oLoanProductCassandra;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lvwLoanProductSearch_DoubleClick(object sender, EventArgs e)
        {

            //if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedLoanNo();
                this.Close();
            }
        }

        private void lvwLoanProductSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedLoanNo();
                this.Close();
            }
        }

        
        private void returnSelectedLoanNo()
        {
            foreach (ListViewItem oItem in lvwLoanProductSearch.SelectedItems)
            {
                _oLoanProductCassandra = (LoanProductCassandra)lvwLoanProductSearch.SelectedItems[0].Tag;

                nLoanID = _oLoanProductCassandra.ID;
                sLoanNo = _oLoanProductCassandra.JobCardNo;
                sProductName = _oLoanProductCassandra.ReplaceJobFromCassandra.ProductName;
            }

        }


        public bool ShowDialog(LoanProductCassandra oLoanProductCassandra)
        {
            _oLoanProductCassandra = oLoanProductCassandra;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }

}