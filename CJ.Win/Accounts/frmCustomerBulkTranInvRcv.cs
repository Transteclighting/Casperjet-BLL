using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerBulkTranInvRcv : Form
    {
        string _sCustomer = "";
        double _Amount = 0;
        TELLib _oTELLib;
        DSInvoiceWisePayment _oDSInvoiceWisePayment;
        public frmCustomerBulkTranInvRcv(string sCustomer, double Amount, DSInvoiceWisePayment oDSInvoiceWisePayment)
        {
            InitializeComponent();
            _sCustomer = sCustomer;
            _Amount = Amount;
            _oDSInvoiceWisePayment = new DSInvoiceWisePayment();
            _oDSInvoiceWisePayment = oDSInvoiceWisePayment;
        }

        private void frmCustomerBulkTranInvRcv_Load(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            lblCustomer.Text = _sCustomer;
            lblAmount.Text = _oTELLib.TakaFormat(_Amount);
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            _oTELLib = new TELLib();
            foreach (DSInvoiceWisePayment.InvoiceWisePaymentRow oIWPR in _oDSInvoiceWisePayment.InvoiceWisePayment)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                oRow.Cells[0].Value = oIWPR.InvoiceNo;
                oRow.Cells[1].Value = oIWPR.InvoiceDate.ToString("dd-MMM-yyyy");
                oRow.Cells[2].Value = _oTELLib.TakaFormat(oIWPR.InvoiceAmount);
                oRow.Cells[3].Value = _oTELLib.TakaFormat(oIWPR.DueAmount);
                oRow.Cells[4].Value = _oTELLib.TakaFormat(oIWPR.ReceivedAmount);
                oRow.Cells[5].Value = _oTELLib.TakaFormat(oIWPR.CurrentDue);

                dgvLineItem.Rows.Add(oRow);
            }
            GetTotalAmount();
        }
        public void GetTotalAmount()
        {
            txtInvoiceAmtTotal.Text = "0.00";
            txtPaymentDueTotal.Text = "0.00";
            txtReceiveAmtTotal.Text = "0.00";
            txtCurrentDueTotal.Text = "0.00";

            _oTELLib = new TELLib();

            double _InvAmt = 0;
            double _PayDueAmt = 0;
            double _RcvAmt = 0;
            double _CurrDueAmt = 0;

            foreach (DSInvoiceWisePayment.InvoiceWisePaymentRow oIWPR in _oDSInvoiceWisePayment.InvoiceWisePayment)
            {

                _InvAmt = _InvAmt + oIWPR.InvoiceAmount;
                _PayDueAmt = _PayDueAmt + oIWPR.DueAmount;
                _RcvAmt = _RcvAmt + oIWPR.ReceivedAmount;
                _CurrDueAmt = _CurrDueAmt + oIWPR.CurrentDue;

            }
            txtInvoiceAmtTotal.Text = _oTELLib.TakaFormat(_InvAmt);
            txtPaymentDueTotal.Text = _oTELLib.TakaFormat(_PayDueAmt);
            txtReceiveAmtTotal.Text = _oTELLib.TakaFormat(_RcvAmt);
            txtCurrentDueTotal.Text = _oTELLib.TakaFormat(_CurrDueAmt);

        }
    }
}