using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Report;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerCreditCollection : Form
    {
        Banks _oBanks;
        Branchs _oBranchs;
        CustomerTransaction _oCustomerTransaction;
        SalesInvoices _oSalesInvoices;
        double _nPaymentAmount = 0;
        TELLib oTELLib;
        InvoiceWisePayment _oInvoiceWisePayment;
        InvoiceWisePayments _oInvoiceWisePayments;
        int _nCustomerTranGroup = 0;
        CustomerTranTypes oCustomerTranTypes;
        string _sTranTypeName = "";
        string _sInstrumentType = "";
        string _sBankName = "";
        string _sBranchName = "";
        string _sInstrumentNo = "";
        public frmCustomerCreditCollection(int nCustomerTranGroup)
        {
            InitializeComponent();
            _nCustomerTranGroup = nCustomerTranGroup;
        }

        public void ShowDialog(string sCustomerCode, string sTranTypeName, string sInstrumentType, string sBankName, string sBranchName, string sInstrumentNo, DateTime sInstrumentDate, string sRemarks, double fAmount, int nTranID)
        {
            ctlCustomer1.txtCode.Text = sCustomerCode;
            _sTranTypeName = sTranTypeName;
            _sInstrumentType = sInstrumentType;
            _sBankName = sBankName;
            _sInstrumentNo = sInstrumentNo;
            dtInstrudate.Value = sInstrumentDate;
            txtRemarks.Text = sRemarks;
            txtReceiveAmount.Text = fAmount.ToString();
            txtComfirmAmount.Text = fAmount.ToString();

            cmbTranType.Enabled = false;
            ctlCustomer1.Enabled = false;
            rdoAutomatic.Enabled = false;
            rdoManual.Enabled = false;
            GetGridLineItem(nTranID);
            this.ShowDialog();
        }

        private void GetGridLineItem(int nTranID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.dgvLineItem.Rows.Clear();
            dgvLineItem.Refresh();
            _oSalesInvoices = new SalesInvoices();

            _oSalesInvoices.GetGridLineItem(nTranID);

            if(_oSalesInvoices.Count>0)
            {
                chkAdvanceColl.Checked = false;
            }
            else
            {
                chkAdvanceColl.Checked = true;
            }

            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesInvoice.InvoiceNo;
                oRow.Cells[1].Value = oSalesInvoice.InvoiceDate;
                oRow.Cells[2].Value = oSalesInvoice.InvoiceAmount;
                oRow.Cells[3].Value = oSalesInvoice.DueAmount; 
                oRow.Cells[4].Value = oSalesInvoice.ReceiveAmount;
                oRow.Cells[5].Value = oSalesInvoice.InvoiceID;
                oRow.Cells[6].Value = Convert.ToDouble(oRow.Cells[2].Value) - Convert.ToDouble(oRow.Cells[4].Value);
                dgvLineItem.Rows.Add(oRow);
            }
            GetTotalAmount();

        }

        private void ctlCustomer1_Leave(object sender, EventArgs e)
        {
            //if (ctlCustomer1.txtDescription.Text.Trim() != "")
            //{
            //    if (chkAdvanceColl.Checked == true)
            //    {
            //        this.dgvLineItem.Rows.Clear();
            //        GetTotalAmount();
            //    }
            //    else
            //    {
            //        _oCustomerTransaction = new CustomerTransaction();
            //        _oCustomerTransaction.CheckCustomerAccount(ctlCustomer1.SelectedCustomer.CustomerID);
            //        txtCurrentBalance.Text = Convert.ToDouble(_oCustomerTransaction.BalanceAmount).ToString();

            //        addToList(ctlCustomer1.SelectedCustomer.CustomerID);
            //    }
            //}
        }
        public void LoadCustomerTranType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oCustomerTranTypes = new CustomerTranTypes();
            oCustomerTranTypes.RefreshByGroup(_nCustomerTranGroup);
            cmbTranType.Items.Add("Select.....");
            foreach (CustomerTranType oCustomerTranType in oCustomerTranTypes)
            {
                cmbTranType.Items.Add(oCustomerTranType.TranTypeName);
            }
            if (_sTranTypeName == "")
            {
                cmbTranType.SelectedIndex = 0;
            }
            else
            {
                cmbTranType.SelectedIndex = cmbTranType.Items.IndexOf(_sTranTypeName);
            }
        }
        public void LoadInstrumentType()
        {
            foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(GetEnum);
            }
            if (_sInstrumentType == "")
            {
                cmbInstrumentType.SelectedIndex = 0;
            }
            else
            {
                cmbInstrumentType.SelectedIndex= cmbInstrumentType.FindStringExact(_sInstrumentType);
            }
        }
        public void LoadAllBank()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oBanks = new Banks();
            _oBanks.Refresh();
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.Items.Add("Select.....");
            if (_sBankName == "")
            {
                if (_oBanks.Count > 0)
                {
                    cmbBank.SelectedIndex = _oBanks.Count;
                }
            }
            else
            {
                cmbBank.SelectedIndex = cmbBank.FindStringExact(_sBankName);
            }
        }
        public void LoadBranchforBank()
        {
            if (cmbBank.Text != "Select.....")
            {
                _oBranchs = new Branchs();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                _oBanks = new Banks();
                _oBanks.Refresh();
                _oBranchs.Refresh(_oBanks[cmbBank.SelectedIndex].BankID);
                cmbBranch.Items.Clear();

                foreach (Branch oBranch in _oBranchs)
                {
                    cmbBranch.Items.Add(oBranch.Name);
                }

                if (_sBranchName == "")
                {
                    if (_oBranchs.Count > 0)
                    {
                        cmbBranch.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbBranch.SelectedIndex = cmbBranch.FindStringExact(_sBranchName);
                }
            }
            else
            {
                cmbBranch.Items.Clear();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCustomerCreditCollection_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            LoadCustomerTranType();
            LoadInstrumentType();
            LoadAllBank();
            if (_nCustomerTranGroup == (int)Dictionary.CustomerTranGroup.Collection)
            {
                gbInstrument.Enabled = true;
            }
            else
            {
                gbInstrument.Enabled = false;
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

            if(_sInstrumentNo!="")
            {
                txtInsNo.Text = _sInstrumentNo;
            }
        }
        private void addToList(int nCustomerID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.dgvLineItem.Rows.Clear();
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
                oRow.Cells[4].Value = 0;
                oRow.Cells[5].Value = oSalesInvoice.InvoiceID;
                oRow.Cells[6].Value = Convert.ToDouble(oRow.Cells[3].Value) - Convert.ToDouble(oRow.Cells[4].Value);
                dgvLineItem.Rows.Add(oRow);
            }
            GetTotalAmount();

        }
        private void txtReceiveAmount_Leave(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (chkAdvanceColl.Checked == true)
            {
                this.dgvLineItem.Rows.Clear();
                GetTotalAmount();
            }
            else
            {
                _nPaymentAmount = Convert.ToDouble(this.txtReceiveAmount.Text);

                if (ctlCustomer1.txtDescription.Text.Trim() != "")
                {
                    automaticSelection(ctlCustomer1.SelectedCustomer.CustomerID);
                    GetTotalAmount();
                }
            }
        }
        private void automaticSelection(int nCustomerID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
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
                    oRow.Cells[4].ReadOnly = true;
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
        private void ManualSelection(int nCustomerID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
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
                    oRow.Cells[4].ReadOnly = false;
                    oRow.Cells[4].Value = 0;
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
                txtInvoiceAmtTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtInvoiceAmtTotal.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString()))).ToString();
                txtPaymentDueTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtPaymentDueTotal.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString()))).ToString();
                txtReceiveAmtTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtReceiveAmtTotal.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString()))).ToString();
                txtCurrentDueTotal.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtCurrentDueTotal.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString()))).ToString();
            }
            txtAdvance.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtReceiveAmount.Text) - Convert.ToDouble(txtReceiveAmtTotal.Text))).ToString();

        }
        private void txtComfirmAmount_Leave(object sender, EventArgs e)
        {
            //oTELLib = new TELLib();
            //lblTakaInWord.Text = "Amount (In word) : " + oTELLib.TakaWords(Convert.ToDouble(txtReceiveAmount.Text));
        }
        private bool validateUIInput()
        {
            if (ctlCustomer1.SelectedCustomer == null)
            {
                MessageBox.Show("Please enter a customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }
            if (cmbTranType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Transaction Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTranType.Focus();
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
                if (_nCustomerTranGroup == (int)Dictionary.CustomerTranGroup.Collection)
                {
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
            }
            else
            {
                MessageBox.Show("Please input receive amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceiveAmount.Focus();
                return false;
            }
            return true;
        }
        private void PrintMR(int nTranID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            string sInvoiceHistory = "";
            string sPadding = "";
            oTELLib = new TELLib();
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
            doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerCode", ctlCustomer1.SelectedCustomer.CustomerCode);
            doc.SetParameterValue("CustomerName", ctlCustomer1.SelectedCustomer.CustomerName);
            
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            if (_nCustomerTranGroup == (int)Dictionary.CustomerTranGroup.Collection)
            {
                doc.SetParameterValue("InstrumentType", cmbInstrumentType.Text);
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
            }
            else
            {
                doc.SetParameterValue("InstrumentType", "N/A");
                doc.SetParameterValue("InstrumentNo", "N/A");
                doc.SetParameterValue("Date", "N/A");
                doc.SetParameterValue("Bank", "N/A");
                doc.SetParameterValue("Branch", "N/A");
            }
            doc.SetParameterValue("Amount", txtReceiveAmount.Text);
            doc.SetParameterValue("TK", oTELLib.TakaWords(Convert.ToDouble(txtReceiveAmount.Text.ToString())));
            doc.SetParameterValue("Remarks", txtRemarks.Text);


            doc.PrintToPrinter(1, true, 1, 1);
            //if (Utility.CompanyInfo == "BLL")
            //{
            //    doc.PrintToPrinter(1, true, 1, 1);
            //}
            //else
            //{
            //    frmPrintPreview oForm = new frmPrintPreview();
            //    oForm.ShowDialog(doc);
            //}
           

        }
        public CustomerTransaction GetDataForCustomerTransaction(CustomerTransaction _oCustomerTransaction)
        {
            _oCustomerTransaction.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oCustomerTransaction.TranDate = dtTranDate.Value.Date;
            _oCustomerTransaction.TranTypeID = oCustomerTranTypes[cmbTranType.SelectedIndex - 1].TranTypeID;
            _oCustomerTransaction.Amount = (Convert.ToDouble(txtReceiveAmount.Text));
            _oCustomerTransaction.UnAdjustedAmount = Convert.ToDouble(txtAdvance.Text);
            if (_nCustomerTranGroup == (int)Dictionary.CustomerTranGroup.Collection)
            {
                if (cmbInstrumentType.SelectedIndex == (int)Dictionary.InstrumentType.CASH)
                {
                    _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;

                }
                else
                {
                    _oCustomerTransaction.InstrumentType = cmbInstrumentType.SelectedIndex;
                    _oCustomerTransaction.InstrumentNo = txtInsNo.Text;
                    _oCustomerTransaction.InstrumentDate = dtInstrudate.Value.Date;
                    try
                    {
                        _oCustomerTransaction.BranchID = _oBranchs[cmbBranch.SelectedIndex].BranchID;
                    }
                    catch
                    {
                        _oCustomerTransaction.BranchID = -1;
                    }
                    _oCustomerTransaction.BranchName = txtBranch.Text;

                }
            }
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            if (chkInsStatus.Checked == true)
            {
                _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.APPROVED;
            }
            else
            {
                _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.NONE;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {

                    if (Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim()) > 0)
                    {
                        InvoiceWisePayment _oInvoiceWisePayment = new InvoiceWisePayment();
                        _oInvoiceWisePayment.InvoiceID = int.Parse(oItemRow.Cells[5].Value.ToString().Trim());
                        _oInvoiceWisePayment.CustomerID = _oCustomerTransaction.CustomerID;
                        _oInvoiceWisePayment.Amount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                        _oCustomerTransaction.Add(_oInvoiceWisePayment);
                    }
                }
            }
            return _oCustomerTransaction;
        }
        private void txtReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            oTELLib = new TELLib();
            lblTakaInWord.Text = "Amount (In word) : " + oTELLib.TakaWords(Convert.ToDouble(txtReceiveAmount.Text));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerTransaction = new CustomerTransaction();
                    Showroom oShowroom = new Showroom();
                    int WHDID = 0;
                    if (Utility.CompanyInfo != "BLL")
                    {
                        WHDID = oShowroom.GetWarehouseIDByCustomer(ctlCustomer1.SelectedCustomer.CustomerID);
                    }
                    else
                    {
                        WHDID = 0;
                    }
                    _oCustomerTransaction = GetDataForCustomerTransaction(_oCustomerTransaction);
                    bool _bTRanSide = false;
                    if (oCustomerTranTypes[cmbTranType.SelectedIndex - 1].TranSide == (int)Dictionary.TransectionSide.CREDIT)
                    {
                        _bTRanSide = true;
                    }
                    else
                    {
                        _bTRanSide = false;
                    }
                    _oCustomerTransaction.InsertForHOCollection(WHDID, _nCustomerTranGroup, _bTRanSide);

                    if (_nCustomerTranGroup != (int)Dictionary.CustomerTranGroup.Adjustment)
                    {
                        PrintMR(_oCustomerTransaction.TranID);
                    }


                    #region Insert Customer Account Data
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerBalanceDataCreation(ctlCustomer1.SelectedCustomer.CustomerID, WHDID, "t_CustomerAccount", ctlCustomer1.SelectedCustomer.CustomerID);


                    //Customer oCustomer = new Customer();
                    //oCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    //DataTran _oDataTran = new DataTran();
                    //if (oCustomer.CheckDistributionCustomer())
                    //{
                    //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                    //    {
                    //        if (GetEnum == WHDID)
                    //        {
                    //            _oDataTran.WarehouseID = WHDID;
                    //            _oDataTran.DataID = oCustomer.CustomerID;
                    //            if (_oDataTran.CheckDataByWHID() == false)
                    //            {
                    //                oCustomer.InsertCustomerBalanceData(oCustomer.CustomerID, WHDID);
                    //            }

                    //        }
                    //        else
                    //        {
                    //            _oDataTran.WarehouseID = GetEnum;
                    //            _oDataTran.DataID = oCustomer.CustomerID;
                    //            if (_oDataTran.CheckDataByWHID() == false)
                    //            {
                    //                oCustomer.InsertCustomerBalanceData(oCustomer.CustomerID, GetEnum);
                    //            }
                    //        }


                    //    }
                    //}
                    #endregion


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully. Tran# " + _oCustomerTransaction.TranNo + "", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlCustomer1.txtCode.Text = "";
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                    return;
                }
            }
        }
        private void rdoAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAutomatic.Checked == true)
            {
                _nPaymentAmount = Convert.ToDouble(this.txtReceiveAmount.Text);
                if (ctlCustomer1.txtDescription.Text.Trim() != "")
                {
                    automaticSelection(ctlCustomer1.SelectedCustomer.CustomerID);
                    GetTotalAmount();
                }
            }
        }
        private void rdoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoManual.Checked == true)
            {
                _nPaymentAmount = Convert.ToDouble(this.txtReceiveAmount.Text);
                if (ctlCustomer1.txtDescription.Text.Trim() != "")
                {
                    ManualSelection(ctlCustomer1.SelectedCustomer.CustomerID);
                    GetTotalAmount();
                }
            }
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            if (nColumnIndex == 4)
            {
                GetTotalAmount();
            }
        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void chkAdvanceColl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdvanceColl.Checked == true)
            {
                this.dgvLineItem.Rows.Clear();
                GetTotalAmount();
            }
            else
            {
                rdoAutomatic.Checked = false;
                rdoAutomatic.Checked = true;
            }
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.txtDescription.Text.Trim() != "")
            {
                if (chkAdvanceColl.Checked == true)
                {
                    this.dgvLineItem.Rows.Clear();
                    GetTotalAmount();
                }
                else
                {
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.CheckCustomerAccount(ctlCustomer1.SelectedCustomer.CustomerID);
                    txtCurrentBalance.Text = Convert.ToDouble(_oCustomerTransaction.BalanceAmount).ToString();

                    addToList(ctlCustomer1.SelectedCustomer.CustomerID);
                }
            }
            else
            {
                txtCurrentBalance.Text = "0.00";
                this.dgvLineItem.Rows.Clear();
                GetTotalAmount();
            }
        }
    }
}
