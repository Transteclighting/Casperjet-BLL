using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Report;

namespace CJ.POS.RT
{
    public partial class frmCustomerPaymentReceives : Form
    {
        CustomerTransaction _oCustomerTransaction;
        CustomerTransactionReport _oCustomerTransactionReport;
        TELLib _oTELLib;
        InvoiceWisePayment _oInvoiceWisePayment;
        InvoiceWisePayments _oInvoiceWisePayments;
        UserPermission _oUserPermission;
        
        public frmCustomerPaymentReceives()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerPaymentReceive oForm = new frmCustomerPaymentReceive();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oTELLib = new TELLib();
            _oCustomerTransactionReport = new CustomerTransactionReport();
            lvwDealerTran.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            } 

            {
                _oCustomerTransactionReport.GetTransactionForPosRT(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text);
            }

            this.Text = "Total Transection " + "[" + _oCustomerTransactionReport.Count + "]";
            foreach (CustomerTransaction oCustomerTransaction in _oCustomerTransactionReport)
            {
                ListViewItem oItem = lvwDealerTran.Items.Add(oCustomerTransaction.TranNo.ToString());
                oItem.SubItems.Add(oCustomerTransaction.TranDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerTransaction.CustomerName);
                oItem.SubItems.Add(_oTELLib.TakaFormat(oCustomerTransaction.Amount));

                oItem.Tag = oCustomerTransaction;
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerPaymentReceives_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oTELLib = new TELLib();
            dtFromDate.Value = _oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;

            DataLoadControl();
            ButtonPermission();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnRePrintMoneyReceipt_Click(object sender, EventArgs e)
        {

            if (lvwDealerTran.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerTransaction _oCustomerTransaction = (CustomerTransaction)lvwDealerTran.SelectedItems[0].Tag;

            PrintMR(_oCustomerTransaction.TranID);

        }
        private void PrintMR(int nTranID)
        {
            string sInvoiceHistory = "";
            string sPadding = "";
            
            _oCustomerTransaction = new CustomerTransaction();
            _oCustomerTransaction.TranID = nTranID;
            _oCustomerTransaction.Refresh();

            _oInvoiceWisePayments = new InvoiceWisePayments();
            _oInvoiceWisePayments.Refresh(nTranID);

            _oInvoiceWisePayment = new InvoiceWisePayment();
            _oInvoiceWisePayment.CheckAdvanceAmt(nTranID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollection));

            doc.SetDataSource(_oCustomerTransaction);


            sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount (Tk)";
            sInvoiceHistory = sInvoiceHistory + "\n";
            string sResult = "";
            foreach (InvoiceWisePayment oInvoiceWisePayment in _oInvoiceWisePayments)
            {
                if (sResult == "")
                {
                    sResult = sResult + oInvoiceWisePayment.InvoiceNo + sPadding.PadRight((20 - 9), ' ') + "\t\t\t\t" + oInvoiceWisePayment.Amount;
                }
                else
                {
                    sResult = sResult + "\n" + oInvoiceWisePayment.InvoiceNo + sPadding.PadRight((20 - 9), ' ') + "\t\t\t\t" + oInvoiceWisePayment.Amount;

                }

            }
            if (_oInvoiceWisePayments.Count > 0)
            {
                sInvoiceHistory = sInvoiceHistory + sResult;
            }
            if (_oInvoiceWisePayment.AdvanceAmt > 0)
            {
                sInvoiceHistory = sInvoiceHistory + "\n";
                sInvoiceHistory = sInvoiceHistory + "Advance" + sPadding.PadRight((20 - 9), ' ') + "\t\t\t\t" + _oInvoiceWisePayment.AdvanceAmt.ToString();
            }
            doc.SetParameterValue("JobLocation", "Sadar Road, Mohakhali C/A, Dhaka- 1206, Bangladesh");
            doc.SetParameterValue("PrintBy", Utility.Username);
            doc.SetParameterValue("InvoiceList", sInvoiceHistory);
            doc.SetParameterValue("PrintStatus", "Print By");
            doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
            doc.SetParameterValue("TranDate", _oInvoiceWisePayment.CreateDate.ToString("dd-MMM-yyyy"));
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oTELLib = new TELLib();
            doc.SetParameterValue("PrintDate", _oTELLib.ServerDateTime().Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerCode", _oCustomerTransaction.CustomerCode);
            doc.SetParameterValue("CustomerName", _oCustomerTransaction.CustomerName);
            doc.SetParameterValue("InstrumentType", _oCustomerTransaction.InstrumentTypeName);
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            if (_oCustomerTransaction.InstrumentType != (int)Dictionary.InstrumentType.CASH)
            {
                doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("Bank", _oCustomerTransaction.BankName);
 
            }
            else
            {
                doc.SetParameterValue("InstrumentNo", "N/A");
                doc.SetParameterValue("Date", "N/A");
                doc.SetParameterValue("Bank", "N/A");
            }
            doc.SetParameterValue("Branch", _oCustomerTransaction.BranchName);
            _oTELLib=new TELLib();
            doc.SetParameterValue("Amount", _oTELLib.TakaFormat(_oCustomerTransaction.Amount));
            doc.SetParameterValue("TK", _oTELLib.TakaWords(_oCustomerTransaction.Amount).ToString());
            doc.SetParameterValue("Remarks", _oCustomerTransaction.Remarks);

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);

        }

        private void ButtonPermission()
        {
            _oUserPermission = new UserPermission();

            //Add
            btnAdd.Enabled = false;
            if (_oUserPermission.CheckPermission("M39.1.3.3.1"))
            {
                btnAdd.Enabled = true;
            }
            //Re-Print Money Receipt
            btnRePrintMoneyReceipt.Enabled = false;
            if (_oUserPermission.CheckPermission("M39.1.3.3.2"))
            {
                btnRePrintMoneyReceipt.Enabled = true;
            }
        
        }
    }
}

