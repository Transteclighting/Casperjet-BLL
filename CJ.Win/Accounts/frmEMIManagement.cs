using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmEMIManagement : Form
    {
        RetailSalesInvoice _oRetailSalesInvoice;
        long nInvoiceID = 0;
        string sInvoiceNo = "";
        int nBankID = 0;

        public frmEMIManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(RetailSalesInvoice oEMIManagement)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oEMIManagement;
            sInvoiceNo = "";
            sInvoiceNo = oEMIManagement.InvoiceNo;
            lblShowroom.Text = oEMIManagement.ShowroomCode;
            lblInvoiceNo.Text = oEMIManagement.InvoiceNo;
            lblInvoiceDate.Text = Convert.ToDateTime(oEMIManagement.InvoiceDate).ToString("dd-MMM-yyyy");
            lblPaymentMode.Text = oEMIManagement.PaymentModeName;

            Bank oBank = new Bank();
            oBank.RefreshByName(oEMIManagement.BankName);
            nBankID = oBank.BankID;

            lblBank.Text = oEMIManagement.BankName;
            lblCardType.Text = oEMIManagement.CardTypeName;
            lblPosMachine.Text = oEMIManagement.POSMachineName;
            lblNoOfInstallment.Text = Convert.ToInt32(oEMIManagement.NoOfInstallment).ToString();
            lblInstrumentNo.Text = oEMIManagement.InstrumentNo;
            lblInstrumentDate.Text = Convert.ToDateTime(oEMIManagement.InstrumentDate).ToString("dd-MMM-yyyy");
            lblAmount.Text = Convert.ToDouble(oEMIManagement.Amount).ToString();
            lblCardCategory.Text = oEMIManagement.CardCategoryName;

            SalesInvoice oSalesInvoice = new SalesInvoice();
            nInvoiceID = oSalesInvoice.GetInvoiceIDByInvNo(sInvoiceNo);

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oRetailSalesInvoice = new RetailSalesInvoice();
                _oRetailSalesInvoice.BankID = nBankID;
                _oRetailSalesInvoice.InvoiceID = nInvoiceID;
                _oRetailSalesInvoice.Amount = Convert.ToDouble(lblAmount.Text);
                _oRetailSalesInvoice.Status = (int)Dictionary.EMIManagement.Send_To_Bank;
                _oRetailSalesInvoice.CreateDate = dtDate.Value.Date;
                _oRetailSalesInvoice.AddEMIData();
                DBController.Instance.CommitTran();

                MessageBox.Show("Successfully Update EMI Data. InvoiceNo # " + sInvoiceNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmEMIManagement_Load(object sender, EventArgs e)
        {
            dtDate.Value = DateTime.Today;
        }
    }
}