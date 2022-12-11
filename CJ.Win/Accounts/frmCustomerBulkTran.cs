using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Accounts;


namespace CJ.Win.Accounts
{
    public partial class frmCustomerBulkTran : Form
    {
        CustomerTranTypes _oCustomerTranTypes;
        private DataTable _oDT;
        Customer oCustomer;
        TELLib _oTELLib;
        int nErrorCount = 0;
        int nCount = 0;
        DSInvoiceWisePayment _oDSInvoiceWisePayment;
        CustomerTransaction _oCustomerTransaction;

        public frmCustomerBulkTran()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            bool IsSelected = false;
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            //this.openFileDialogData.Filter = "Text File(*.txt;)|*.txt;| File(*.TXT;)|*.TXT;|All Files(*.*;)|*.*";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
                IsSelected = true;
            }
            if (IsSelected)
            {
                LoadSheets();
                btnProcess.Enabled = true;
                btnSave.Enabled = false;
                pbInvoice.Value = 0;
                cmbCustTranType.Enabled = true;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (cmbCustTranType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Tran Type ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddColumnsProgrammatically();
            Process();
            btnProcess.Enabled = false;
        }

        private void Save()
        {
            int i = 0;
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                try
                {
                    int nCustomerID = Convert.ToInt32(oItemRow.Cells[4].Value);
                    double _Amount = Convert.ToDouble(oItemRow.Cells[2].Value);

                    DBController.Instance.BeginNewTransaction();

                    _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction = GetDataForCustomerTransaction(_oCustomerTransaction, nCustomerID, _Amount);
                    _oCustomerTransaction.InsertBulkTran(_oCustomerTranTypes[cmbCustTranType.SelectedIndex - 1].TranSide);

                    DBController.Instance.CommitTransaction();

                    i = i + 1;
                    pbInvoice.Value = i;
                    nCount++;

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
            btnSave.Enabled = false;
            MessageBox.Show(" Data save successfully\n Total Inserted Data " + nCount + "");
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerBulkTran_Load(object sender, EventArgs e)
        {
            btnProcess.Enabled = false;
            btnSave.Enabled = false;
            DBController.Instance.OpenNewConnection();
            LoadCombo();
        }

        private int AutomaticSelection(int nCustomerID, double _Amount)
        {
            int nCount = 0;
            SalesInvoices _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.GetDueAmountByCustomerID(nCustomerID);

            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                if (_Amount > 0)
                {
                    if (oSalesInvoice.DueAmount > _Amount)
                    {
                        _Amount = 0;
                        nCount++;
                    }
                    else
                    {
                        _Amount = _Amount - oSalesInvoice.DueAmount;
                        nCount++;
                    }
                }
            }
            return nCount;
        }

        private DSInvoiceWisePayment AutomaticSelectionByCust(int nCustomerID, double _Amount)
        {
            int nCount = 0;
            double _CurrentDue = 0;
            SalesInvoices _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.GetDueAmountByCustomerID(nCustomerID);

            _oDSInvoiceWisePayment = new DSInvoiceWisePayment();

            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {

                if (_Amount > 0)
                {
                    if (oSalesInvoice.DueAmount > _Amount)
                    {
                        DSInvoiceWisePayment.InvoiceWisePaymentRow oIWPR = _oDSInvoiceWisePayment.InvoiceWisePayment.NewInvoiceWisePaymentRow();

                        oIWPR.InvoiceID = oSalesInvoice.InvoiceID;
                        oIWPR.InvoiceNo = oSalesInvoice.InvoiceNo;
                        oIWPR.InvoiceDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
                        oIWPR.InvoiceAmount = oSalesInvoice.InvoiceAmount;
                        oIWPR.DueAmount = oSalesInvoice.DueAmount;
                        oIWPR.ReceivedAmount = _Amount;
                        _CurrentDue = oSalesInvoice.DueAmount - _Amount;
                        oIWPR.CurrentDue = _CurrentDue;

                        _oDSInvoiceWisePayment.InvoiceWisePayment.AddInvoiceWisePaymentRow(oIWPR);
                        _oDSInvoiceWisePayment.AcceptChanges();

                        _Amount = 0;
                        nCount++;
                    }
                    else
                    {
                        DSInvoiceWisePayment.InvoiceWisePaymentRow oIWPR = _oDSInvoiceWisePayment.InvoiceWisePayment.NewInvoiceWisePaymentRow();

                        oIWPR.InvoiceID = oSalesInvoice.InvoiceID;
                        oIWPR.InvoiceNo = oSalesInvoice.InvoiceNo;
                        oIWPR.InvoiceDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
                        oIWPR.InvoiceAmount = oSalesInvoice.InvoiceAmount;
                        oIWPR.DueAmount = oSalesInvoice.DueAmount;
                        oIWPR.ReceivedAmount = oSalesInvoice.DueAmount;
                        _CurrentDue = oSalesInvoice.DueAmount - oIWPR.ReceivedAmount;
                        oIWPR.CurrentDue = _CurrentDue;

                        _oDSInvoiceWisePayment.InvoiceWisePayment.AddInvoiceWisePaymentRow(oIWPR);
                        _oDSInvoiceWisePayment.AcceptChanges();

                        _Amount = _Amount - oSalesInvoice.DueAmount;
                        nCount++;
                    }
                }
            }
            return _oDSInvoiceWisePayment;
        }

        public void LoadCombo()
        {
            _oCustomerTranTypes = new CustomerTranTypes();
            _oCustomerTranTypes.Refresh();
            cmbCustTranType.Items.Add("-- Select --");
            foreach (CustomerTranType oCustomerTranType in _oCustomerTranTypes)
            {
                cmbCustTranType.Items.Add(oCustomerTranType.TranTypeName + "[" + oCustomerTranType.TranTypeCode + "] [" + oCustomerTranType.TranSideName + "]");
            }
            cmbCustTranType.SelectedIndex = 0;
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            //OleDbConnection oConn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
            oConn.Open();

            RemoveColumn();

            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);

            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);

            dgvLineItem.DataSource = _oDT.DefaultView;
            pbInvoice.Maximum = _oDT.Rows.Count;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";
            //dgvLineItem.Columns["CompanyName"].ReadOnly = true;
            GetTotalAmount();
        }

        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            TELLib oTELLib = new TELLib();
            double _Amount = 0;
            lblAmountInWord.Text = "";
            DataGridViewRow oDGVRow;

            int i = 0;

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {

                if (oRow.Cells[2].Value != null)
                {
                    oTELLib = new TELLib();
                    double _Amt;
                    try
                    {
                        _Amt = Convert.ToDouble(oRow.Cells[2].Value.ToString());
                    }
                    catch
                    {
                        _Amt = 0;

                        oDGVRow = dgvLineItem.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.Red;
                    }
                    _Amount = _Amount + _Amt;

                    i++;
                    dgvLineItem.Refresh();
                }
            }
            txtTotalAmount.Text = oTELLib.TakaFormat(_Amount);
            lblAmountInWord.Text = oTELLib.TakaWords(_Amount);
        }

        private void AddColumnsProgrammatically()
        {
            try
            {
                dgvLineItem.Columns.RemoveAt(4);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(3);
            }
            catch
            {
            }

            DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();

            col3.HeaderText = "Affected Invoices";
            col3.Name = "btnAffectedInvoices";

            col4.HeaderText = "Customer ID";
            col4.Name = "CustomerID";

            col5.HeaderText = "Remarks";
            col5.Name = "Remarks";

            //dgvLineItem.Columns.AddRange(new DataGridViewColumn[] { col3});
            //dgvLineItem.Columns.AddRange(new DataGridViewColumn[] { col3 });
            //dgvLineItem.Columns.AddRange(new DataGridViewColumn[] { col4 });

            dgvLineItem.Columns.Add(col3);
            dgvLineItem.Columns.Add(col4);
            dgvLineItem.Columns.Add(col5);

            dgvLineItem.Columns["CustomerID"].Visible = false;
            //dvgProduct.Rows[e.RowIndex].Cells[5].Value
        }

        private void RemoveColumn()
        {
            try
            {
                dgvLineItem.Columns.RemoveAt(5);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(4);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(3);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(2);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(1);
            }
            catch
            {
            }
            try
            {
                dgvLineItem.Columns.RemoveAt(0);
            }
            catch
            {
            }

        }

        private void Process()
        {
            nErrorCount = 0;
            int i = 0;
            DataGridViewRow oDGVRow;
            double _TotalAmount = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                string sCustCode = "";
                sCustCode = oItemRow.Cells[0].Value.ToString();

                oCustomer = new Customer();
                oCustomer.CustomerCode = sCustCode;
                oCustomer.RefreshByCode();

                oItemRow.Cells[4].Value = oCustomer.CustomerID.ToString();

                oDGVRow = dgvLineItem.Rows[i];
                if (oCustomer.CustomerID != 0)
                {
                    oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    oItemRow.Cells[5].Value = "Ok";

                    double _Amt;
                    try
                    {
                        _Amt = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        oItemRow.Cells[5].Value = "Ok";
                        int nTranSide = 0;
                        nTranSide = _oCustomerTranTypes[cmbCustTranType.SelectedIndex - 1].TranSide;
                        if (nTranSide == (int)Dictionary.TransectionSide.CREDIT)
                        {
                            oItemRow.Cells[3].Value = Convert.ToString(AutomaticSelection(oCustomer.CustomerID, _Amt));
                        }
                        else
                        {
                            oItemRow.Cells[3].Value = "N/A";
                        }
                    }
                    catch
                    {
                        _Amt = 0;

                        oDGVRow = dgvLineItem.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.Red;
                        oItemRow.Cells[5].Value = "Amount Not in a Correct Format!!";
                        oItemRow.Cells[3].Value = "0";
                        oItemRow.Cells[4].Value = "0";
                        nErrorCount++;
                    }
                    _TotalAmount = _TotalAmount + _Amt;
                }
                else
                {
                    oDGVRow.DefaultCellStyle.BackColor = Color.Red;
                    oItemRow.Cells[5].Value = "Customer Code Error!!";
                    oItemRow.Cells[3].Value = "0";
                    nErrorCount++;
                }

                dgvLineItem.Refresh();

                i = i + 1;
                pbInvoice.Value = i;

            }
            _oTELLib = new TELLib();
            txtTotalAmount.Text = "0.00";
            txtTotalAmount.Text = _oTELLib.TakaFormat(_TotalAmount);
            lblAmountInWord.Text = _oTELLib.TakaWords(_TotalAmount);
            if (nErrorCount == 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("Total: " + nErrorCount + " No(s): Error Founded!!\nPlease Check before save ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbCustTranType.Enabled = false;
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string sCustCode = dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sCustName = dgvLineItem.Rows[e.RowIndex].Cells[1].Value.ToString();
                double _Amount = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[2].Value);
                int nCustomerID = Convert.ToInt32(dgvLineItem.Rows[e.RowIndex].Cells[4].Value);
                int nAffectedInv = 0;
                try
                {
                    nAffectedInv = Convert.ToInt32(dgvLineItem.Rows[e.RowIndex].Cells[3].Value);
                }
                catch
                {
                    nAffectedInv = 0;
                }


                if (nAffectedInv > 0)
                {
                    _oDSInvoiceWisePayment = new DSInvoiceWisePayment();
                    _oDSInvoiceWisePayment = AutomaticSelectionByCust(nCustomerID, _Amount);
                    frmCustomerBulkTranInvRcv oForm = new frmCustomerBulkTranInvRcv("[" + sCustCode + "] " + sCustName, _Amount, _oDSInvoiceWisePayment);
                    oForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no affected Invoices", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public CustomerTransaction GetDataForCustomerTransaction(CustomerTransaction _oCustomerTransaction, int nCustomerID, double _Amount)
        {
            _oCustomerTransaction.CustomerID = nCustomerID;
            _oCustomerTransaction.TranTypeID = _oCustomerTranTypes[cmbCustTranType.SelectedIndex - 1].TranTypeID;
            int nTranSide = 0;
            nTranSide = _oCustomerTranTypes[cmbCustTranType.SelectedIndex - 1].TranSide;
            _oCustomerTransaction.TranDate = dtInstrudate.Value.Date;
            _oCustomerTransaction.Amount = _Amount;
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.InstrumentNo = "";
            _oCustomerTransaction.InstrumentDate = dtInstrudate.Value.Date;
            _oCustomerTransaction.BranchID = -1;
            _oCustomerTransaction.BranchName = "";
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.APPROVED;

            if (nTranSide == (int)Dictionary.TransectionSide.CREDIT)
            {
                _oDSInvoiceWisePayment = new DSInvoiceWisePayment();
                _oDSInvoiceWisePayment = AutomaticSelectionByCust(nCustomerID, _Amount);


                foreach (DSInvoiceWisePayment.InvoiceWisePaymentRow oIWPR in _oDSInvoiceWisePayment.InvoiceWisePayment)
                {

                    InvoiceWisePayment _oInvoiceWisePayment = new InvoiceWisePayment();

                    _oInvoiceWisePayment.InvoiceID = oIWPR.InvoiceID;
                    _oInvoiceWisePayment.CustomerID = nCustomerID;
                    _oInvoiceWisePayment.Amount = oIWPR.ReceivedAmount;

                    _oCustomerTransaction.Add(_oInvoiceWisePayment);
                }
            }
            return _oCustomerTransaction;
        }
    }
}