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
    public partial class frmLeadInvoiceChallans : Form
    {
        SalesInvoiceEcommerceLeadChallans _oSalesInvoiceEcommerceLeadChallans;
        bool IsCheck = false;
        public frmLeadInvoiceChallans()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLeadInvoiceChallan oForm = new frmLeadInvoiceChallan();
            oForm.ShowDialog();
            
        }
        private void DataLoadControl()
        {
            _oSalesInvoiceEcommerceLeadChallans = new SalesInvoiceEcommerceLeadChallans();
            lvwLeadChallan1.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }
            DBController.Instance.OpenNewConnection();
            _oSalesInvoiceEcommerceLeadChallans.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtChallanNo.Text.Trim(), nStatus, IsCheck);

            foreach (SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan in _oSalesInvoiceEcommerceLeadChallans)
            {
                ListViewItem oItem = lvwLeadChallan1.Items.Add(oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSalesInvoiceEcommerceLeadChallan.ChallanDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSalesInvoiceEcommerceLeadChallan.HandedOverTo.ToString());
                oItem.SubItems.Add(oSalesInvoiceEcommerceLeadChallan.ContactNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommerceChallanStatus), oSalesInvoiceEcommerceLeadChallan.Status));

                oItem.Tag = oSalesInvoiceEcommerceLeadChallan;
            }
            this.Cursor = Cursors.Default;
            this.Text = "Lead Assign List [" + _oSalesInvoiceEcommerceLeadChallans.Count + "]";
        }

        private void btnGetDate_Click(object sender, EventArgs e)
        {

        }

        private void btnHandedover_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}