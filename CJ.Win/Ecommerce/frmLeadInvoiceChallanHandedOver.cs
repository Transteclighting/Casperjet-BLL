using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmLeadInvoiceChallanHandedOver : Form
    {
        int nChallanID = 0;
        public frmLeadInvoiceChallanHandedOver()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan)
        {
            this.Tag = oSalesInvoiceEcommerceLeadChallan;
            DBController.Instance.OpenNewConnection();
            nChallanID = 0;
            nChallanID = oSalesInvoiceEcommerceLeadChallan.ChallanID;
            lblChallanNo.Text = oSalesInvoiceEcommerceLeadChallan.ChallanNo;
            lblChallanDate.Text = Convert.ToDateTime(oSalesInvoiceEcommerceLeadChallan.ChallanDate).ToString("dd-MMM-yyyy");
            
            this.Text = "Challan Handover";

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}