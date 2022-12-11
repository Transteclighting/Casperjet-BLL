using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmConsumerDetail : Form
    {
        public frmConsumerDetail()
        {
            InitializeComponent();
        }
        public void ShowDialog(RetailConsumer oRetailConsumer)
        {
            this.Tag = oRetailConsumer;

            lblConsumeCode.Text = oRetailConsumer.ConsumerCode;
            lblConsumerName.Text = oRetailConsumer.ConsumerName;
            lblAddress.Text = oRetailConsumer.Address;
            lblEmail.Text = oRetailConsumer.Email;
            lblCellNo.Text = oRetailConsumer.CellNo;
            lblPhoneNo.Text = oRetailConsumer.PhoneNo;

            lblInvoiceNo.Text = oRetailConsumer.InvoiceNo;
            lblInvoiceDate.Text = Convert.ToDateTime(oRetailConsumer.InvoiceDate).ToString("dd-MMM-yyyy");
            lblSalesType.Text = oRetailConsumer.SalesTypeName;
            lblCustomerCode.Text = oRetailConsumer.CustomerCode;
            lblCustomerName.Text = oRetailConsumer.CustomerName;
            lblProductCode.Text = oRetailConsumer.ProductCode ;
            lblProductName.Text = oRetailConsumer.ProductName;
            lblQty.Text = oRetailConsumer.SalesQty.ToString();
            lblInvAmount.Text = Convert.ToDouble(oRetailConsumer.Amount).ToString();
            lblAG.Text = oRetailConsumer.AGName;
            lblASG.Text = oRetailConsumer.ASGName;
            lblMAG.Text = oRetailConsumer.MAGName;
            lblPG.Text = oRetailConsumer.PGName;

            this.ShowDialog();
        }

        private void frmConsumerDetail_Load(object sender, EventArgs e)
        {

        }
    }
}