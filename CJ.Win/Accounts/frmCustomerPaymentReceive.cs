using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Report;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerPaymentReceive : Form
    {
        Banks _oBanks;
        Branchs _oBranchs;
        CustomerTransaction _oCustomerTransaction;
        SalesInvoices _oSalesInvoices;
        double _nPaymentAmount = 0;
        TELLib oTELLib;
        InvoiceWisePayment _oInvoiceWisePayment;
        InvoiceWisePayments _oInvoiceWisePayments;
        public frmCustomerPaymentReceive()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCustomerPaymentReceive_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadInstrumentType();
            LoadAllBank(); 
        }
        public void LoadInstrumentType()
        {
            foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(GetEnum);
            }
            cmbInstrumentType.SelectedIndex = 0;
        }
        public void LoadAllBank()
        {

            //DBController.Instance.OpenNewConnection();
            _oBanks = new Banks();
            _oBanks.Refresh();

            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            //
            //cmbBank.Text = "Select.....";
            cmbBank.Items.Add("Select.....");
            if (_oBanks.Count > 0)
            {
                cmbBank.SelectedIndex = _oBanks.Count;
            }
        }
        public void LoadBranchforBank()
        {

            if (cmbBank.Text != "Select.....")
            {
                //cmbBranch.Items.Clear();
                _oBranchs = new Branchs();
                DBController.Instance.OpenNewConnection();
                _oBanks = new Banks();
                _oBanks.Refresh();
                _oBranchs.Refresh(_oBanks[cmbBank.SelectedIndex].BankID);
                cmbBranch.Items.Clear();

                foreach (Branch oBranch in _oBranchs)
                {
                    cmbBranch.Items.Add(oBranch.Name);
                }
                if (_oBranchs.Count > 0)
                {
                    cmbBranch.SelectedIndex = 0;
                }
            }
            else
            {
                cmbBranch.Items.Clear();
            }
        }
        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBranchforBank();
        }
        private void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.Text == "CASH")
            {
                txtInsNo.Text = "";
                txtInsNo.Enabled = false;

                cmbBank.Enabled = false;
                cmbBranch.Enabled = false;
                dtInstrudate.Enabled = false;
                txtBranch.Enabled = false;

            }
            else
            {
                txtInsNo.Text = "";
                txtInsNo.Enabled = true;

                cmbBank.Enabled = true;
                cmbBranch.Enabled = true;
                dtInstrudate.Enabled = true;
                txtBranch.Enabled = true;

            }
        }

        private void ctlCustomer1_Leave(object sender, EventArgs e)
        {
            //if (ctlCustomer1.txtCode.Text.Trim() != "")
            //{
                if (ctlCustomer1.txtDescription.Text.Trim() != "")
                {
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.CheckCustomerAccount(ctlCustomer1.SelectedCustomer.CustomerID);
                    txtCurrentBalance.Text = Convert.ToDouble(_oCustomerTransaction.BalanceAmount).ToString();
                    addToList(ctlCustomer1.SelectedCustomer.CustomerID);
                }
           //}
        }

        private void addToList(int nCustomerID)
        {

            this.dgvLineItem.Rows.Clear();
            dgvLineItem.Refresh();
            _oSalesInvoices=new SalesInvoices();

            _oSalesInvoices.GetDueAmountByCustomerID(nCustomerID);

            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesInvoice.InvoiceNo;
                oRow.Cells[1].Value = oSalesInvoice.InvoiceDate;
                oRow.Cells[2].Value = oSalesInvoice.InvoiceAmount;
                oRow.Cells[3].Value = oSalesInvoice.DueAmount;
                oRow.Cells[4].Value = 0;
                oRow.Cells[5].Value = oSalesInvoice.InvoiceID;
                oRow.Cells[6].Value = Convert.ToDouble(oRow.Cells[3].Value) - Convert.ToDouble(oRow.Cells[4].Value);
                dgvLineItem.Rows.Add(oRow);
            }
            GetTotalAmount();

        }

        private void txtReceiveAmount_Leave(object sender, EventArgs e)
        {
            _nPaymentAmount = Convert.ToDouble(this.txtReceiveAmount.Text);
            //if (ctlCustomer1.txtCode.Text.Trim() != "")
            //{
                if (ctlCustomer1.txtDescription.Text.Trim() != "")
                {
                    automaticSelection(ctlCustomer1.SelectedCustomer.CustomerID);
                    GetTotalAmount();
                }
            //}
        }
        private void automaticSelection(int nCustomerID)
        {
            this.dgvLineItem.Rows.Clear();

            if (_nPaymentAmount > 0)
            {
                dgvLineItem.Refresh();

                _oSalesInvoices = new SalesInvoices();
                _oSalesInvoices.GetDueAmountByCustomerID(nCustomerID);

                foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);

                    oRow.Cells[0].Value = oSalesInvoice.InvoiceNo;
                    oRow.Cells[1].Value = oSalesInvoice.InvoiceDate;
                    oRow.Cells[2].Value = oSalesInvoice.InvoiceAmount;
                    oRow.Cells[3].Value = oSalesInvoice.DueAmount;
                    if (oSalesInvoice.DueAmount > _nPaymentAmount)
                    {
                        oRow.Cells[4].Value = _nPaymentAmount;
                        _nPaymentAmount = 0;
                    }
                    else
                    {
                        oRow.Cells[4].Value = oSalesInvoice.DueAmount;
                        _nPaymentAmount = _nPaymentAmount - oSalesInvoice.DueAmount;
                    }
                    oRow.Cells[5].Value = oSalesInvoice.InvoiceID;
                    oRow.Cells[6].Value = Convert.ToDouble(oRow.Cells[3].Value) - Convert.ToDouble(oRow.Cells[4].Value);
                    dgvLineItem.Rows.Add(oRow);
                }
            }
        }
        public void GetTotalAmount()
        {
            txtInvoiceAmtTotal.Text = "0.00";
            txtPaymentDueTotal.Text = "0.00";
            txtReceiveAmtTotal.Text = "0.00";
            txtCurrentDueTotal.Text = "0.00";
            txtAdvance.Text = "0.00";

            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                //if (oRow.Cells[4].Value != null)
                //{
                txtInvoiceAmtTotal.Text =oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtInvoiceAmtTotal.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString()))).ToString();
                txtPaymentDueTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtPaymentDueTotal.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString()))).ToString();
                txtReceiveAmtTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtReceiveAmtTotal.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString()))).ToString();
                txtCurrentDueTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtCurrentDueTotal.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString()))).ToString();

                //}
            }
            txtAdvance.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtReceiveAmount.Text) - Convert.ToDouble(txtReceiveAmtTotal.Text))).ToString();

        }

        private void txtReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            oTELLib = new TELLib();
            lblTakaInWord.Text = "Amount (In word) : " + oTELLib.TakaWords(Convert.ToDouble(txtReceiveAmount.Text));
            
        }
        private bool validateUIInput()
        {
            if (ctlCustomer1.SelectedCustomer == null)
            {
                MessageBox.Show("Please enter a customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            double RcvAmt = 0;
            double ConfAmt = 0;

            RcvAmt = Convert.ToDouble(txtReceiveAmount.Text.Trim().ToString());
            ConfAmt = Convert.ToDouble(txtComfirmAmount.Text.Trim().ToString());

            if (RcvAmt > 0)
            {

                if (RcvAmt != ConfAmt)
                {
                    MessageBox.Show("Receive amount must be equal to Confirm Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComfirmAmount.Focus();
                    return false;
                }
                if (cmbInstrumentType.Text != "CASH")
                {
                    if (cmbBank.Text == "Select.....")
                    {
                        MessageBox.Show("Please select a bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (txtInsNo.Text == "")
                        {
                            MessageBox.Show("Please enter instrument number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Please input receive amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceiveAmount.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();


                    _oCustomerTransaction = new CustomerTransaction();
                    SystemInfo _oSystemInfo = new SystemInfo();
                    _oSystemInfo.Refresh();
                    _oCustomerTransaction = GetDataForCustomerTransaction(_oCustomerTransaction);
                    _oCustomerTransaction.InsertForHOCollection(_oSystemInfo.WarehouseID, Convert.ToDateTime(_oSystemInfo.OperationDate));

                    //PrintMR(_oCustomerTransaction.TranID);

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                    return;
                }
            }

        }

        private void PrintMR(int nTranID)
        {
            string sInvoiceHistory = "";
            string sPadding = "";
            oTELLib=new TELLib();
            CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
            oCustomerTransactionReport.Refresh(nTranID);
            _oInvoiceWisePayments = new InvoiceWisePayments();
            _oInvoiceWisePayments.Refresh(nTranID);

            _oInvoiceWisePayment = new InvoiceWisePayment();
            _oInvoiceWisePayment.CheckAdvanceAmt(nTranID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollectionPOS));

            doc.SetDataSource(oCustomerTransactionReport);
            

            sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount (Tk)";
            sInvoiceHistory = sInvoiceHistory + "\n";
            //sInvoiceHistory = sInvoiceHistory + _oSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _oSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
            string sResult = "";
            foreach(InvoiceWisePayment oInvoiceWisePayment in _oInvoiceWisePayments)
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
            doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerCode", ctlCustomer1.SelectedCustomer.CustomerCode);
            doc.SetParameterValue("CustomerName", ctlCustomer1.SelectedCustomer.CustomerName);
            doc.SetParameterValue("InstrumentType",cmbInstrumentType.Text);
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            if (cmbInstrumentType.Text != "CASH")
            {
                doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("Bank", cmbBank.Text);
                if (txtBranch.Text != "")
                    doc.SetParameterValue("Branch", txtBranch.Text);
                else doc.SetParameterValue("Branch", cmbBranch.Text);

            }
            else
            {
                doc.SetParameterValue("InstrumentNo", "N/A");
                doc.SetParameterValue("Date", "N/A");
                doc.SetParameterValue("Bank", "N/A");
                doc.SetParameterValue("Branch", "N/A");
            }
            doc.SetParameterValue("Amount", txtReceiveAmount.Text);
            doc.SetParameterValue("TK", oTELLib.TakaWords(Convert.ToDouble(txtReceiveAmount.Text.ToString())));
            doc.SetParameterValue("Remarks", txtRemarks.Text);

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);

        }
        public CustomerTransaction GetDataForCustomerTransaction(CustomerTransaction _oCustomerTransaction)
        {
            _oCustomerTransaction.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oCustomerTransaction.TranTypeID = (short)Dictionary.TransectionType.CREDIT_RECEIVE;
            _oCustomerTransaction.Amount = (Convert.ToDouble(txtReceiveAmount.Text));

            if (cmbInstrumentType.SelectedIndex == (int)Dictionary.InstrumentType.CASH)
            {
                _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;

            }
            else
            {
                _oCustomerTransaction.InstrumentType = cmbInstrumentType.SelectedIndex;
                _oCustomerTransaction.InstrumentNo = txtInsNo.Text;
                _oCustomerTransaction.InstrumentDate = dtInstrudate.Value.Date;
                _oCustomerTransaction.BranchID = _oBranchs[cmbInstrumentType.SelectedIndex].BranchID;
                _oCustomerTransaction.BranchName = txtBranch.Text;
            
            }
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.APPROVED;
            _oCustomerTransaction.EntryLocationID = (int)Dictionary.JobLocation.HO;
            //if (chkInsStatus.Checked == true)
            //{
            //    _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.APPROVED;
            //}
            //else
            //{
            //    _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.NOT_APPROVED;
            //}

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {

                    if (int.Parse(oItemRow.Cells[4].Value.ToString().Trim()) > 0)
                    {
                        InvoiceWisePayment _oInvoiceWisePayment = new InvoiceWisePayment();

                        _oInvoiceWisePayment.InvoiceID = int.Parse(oItemRow.Cells[5].Value.ToString().Trim());
                        _oInvoiceWisePayment.CustomerID = _oCustomerTransaction.CustomerID;
                        _oInvoiceWisePayment.Amount = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                        _oCustomerTransaction.Add(_oInvoiceWisePayment);
                    }
                }
            }

            return _oCustomerTransaction;
        }
    }
}