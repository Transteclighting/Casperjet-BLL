using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmCustomerCreditApprovalHistory : Form
    {
        CustomerCreditApproval _oCustomerCreditApproval;
        SalesInvoices _oSalesInvoices;
        CustomerCreditApprovalCollections _oCustomerCreditApprovalCollections;
        TELLib _oTELLib;

        public frmCustomerCreditApprovalHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(CustomerCreditApproval oCustomerCreditApproval)
        {

            this.Tag = oCustomerCreditApproval;
            _oTELLib = new TELLib();
            lblCreditApprovalNo.Text = oCustomerCreditApproval.ApprovalNo;
            lblCustomer.Text = "[" + oCustomerCreditApproval.CustomerCode + "] " + oCustomerCreditApproval.CustomerName;
            lblCreditPeriod.Text = Convert.ToInt32(oCustomerCreditApproval.CreditPeriod).ToString();
            lblCreateDate.Text = Convert.ToDateTime(oCustomerCreditApproval.CreateDate).ToString("dd-MMM-yyyy");
            lblProduct.Text = oCustomerCreditApproval.ProductOrService;

            lblCreditAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CreditAmount);
            lblInvoicedAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount);
            lblBalance.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CreditAmount - oCustomerCreditApproval.InvoicedAmount);
            lblCollectedAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CollectedAmount);
            lblDue.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount - oCustomerCreditApproval.CollectedAmount);

            DBController.Instance.OpenNewConnection();

            _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.RefreshInvoiceForCreditApproval(oCustomerCreditApproval.ApprovalNo);

            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                ListViewItem oItem = lvwInvoice.Items.Add(oSalesInvoice.InvoiceNo);
                oItem.SubItems.Add(Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oSalesInvoice.InvoiceAmount));
                oItem.SubItems.Add(Convert.ToDateTime(oSalesInvoice.CreditExpiredDate).ToString("dd-MMM-yyyy"));

                oItem.Tag = oSalesInvoice;
            }

            _oCustomerCreditApprovalCollections = new CustomerCreditApprovalCollections();
            _oCustomerCreditApprovalCollections.RefreshCollectionAmount(oCustomerCreditApproval.ApprovalNo);
            foreach (CustomerCreditApprovalCollection oCustomerCreditApprovalCollection in _oCustomerCreditApprovalCollections)
            {
                ListViewItem oItem = lvwCollection.Items.Add(Convert.ToDateTime(oCustomerCreditApprovalCollection.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oCustomerCreditApprovalCollection.Amount));
                //oItem.SubItems.Add(oCustomerCreditApprovalCollection.CreditApprovalCollectionID).ToString();

                oItem.Tag = oCustomerCreditApprovalCollection;
            }

            this.ShowDialog();

        }
    }
}