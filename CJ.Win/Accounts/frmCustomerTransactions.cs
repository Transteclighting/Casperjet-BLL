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
using CJ.Report;
using CJ.Class.Library;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerTransactions : Form
    {
        CustomerTranTypes _oCustomerTranTypes = new CustomerTranTypes();
        CustomerTranGroups _oCustomerTranGroups = new CustomerTranGroups();
        CustomerTransactions _oCustomerTransactions = new CustomerTransactions();
        CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

        bool IsCheck = false;

        TELLib oTELLib;
        InvoiceWisePayments _oInvoiceWisePayments;
        InvoiceWisePayment _oInvoiceWisePayment;
        public frmCustomerTransactions()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Status
            cmbInstrumnetStatus.Items.Clear();
            //cmbInstrumnetStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InstrumentStatus)))
            {
                cmbInstrumnetStatus.Items.Add(Enum.GetName(typeof(Dictionary.InstrumentStatus), GetEnum));
            }
            cmbInstrumnetStatus.SelectedIndex = 3;
        }

        private void frmCustomerTransactions_Load(object sender, EventArgs e)
        {
            LoadCombo();
            FillComboMainGroup();
            DataLoadControl();
        }

        private void FillComboMainGroup()
        {
            cmbMainGroup.Items.Clear();
            _oCustomerTranGroups = new CustomerTranGroups();
            _oCustomerTranGroups.Refresh();

            cmbMainGroup.Items.Add("<All>");
            foreach (CustomerTranGroup oCustomerTranGroup in _oCustomerTranGroups)
            {
                cmbMainGroup.Items.Add(oCustomerTranGroup.TranGroupName);
            }
            cmbMainGroup.SelectedIndex = 0;
        }

        private void FillComboCustomerTranType()
        {

            _oCustomerTranTypes = new CustomerTranTypes();
            if (cmbMainGroup.SelectedIndex == 0)
            {
                //_oCustomerTranTypes.Refresh();
                cmbCustomerTranType.Items.Add("<All>");
            }
            else
            {
                cmbCustomerTranType.Items.Add("<All>");
                _oCustomerTranTypes.RefreshByGroup(cmbMainGroup.SelectedIndex);

                foreach (CustomerTranType oCustomerTranType in _oCustomerTranTypes)
                {
                    cmbCustomerTranType.Items.Add(oCustomerTranType.TranTypeName);
                }
            }

            cmbCustomerTranType.SelectedIndex = 0;
        }

        private void cmbMainGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            cmbCustomerTranType.Items.Clear();
            cmbCustomerTranType.Enabled = true;
            FillComboCustomerTranType();
            DBController.Instance.CloseConnection();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oCustomerTransactions = new CustomerTransactions();
            lvwCustomerTransactions.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbInstrumnetStatus.SelectedIndex == 3)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbInstrumnetStatus.SelectedIndex;
            }            

            int nCustomerTranTypeID = 0;
            if (cmbCustomerTranType.SelectedIndex == 0 || cmbMainGroup.SelectedIndex == 0)
            {
                nCustomerTranTypeID = -1;
            }
            else
            {
                if (cmbCustomerTranType.SelectedIndex != 0)
                {
                    nCustomerTranTypeID = _oCustomerTranTypes[cmbCustomerTranType.SelectedIndex - 1].TranTypeID;
                }
            }

            int nCustomerTranTypeGroupID = 0;
            if (cmbMainGroup.SelectedIndex == 0)
            {
                nCustomerTranTypeGroupID = -1;
            }
            else
            {
                nCustomerTranTypeGroupID = cmbMainGroup.SelectedIndex;
            }

            int nCustomerID = 0;
            if(ctlCustomer1.SelectedCustomer==null)
            {
                nCustomerID = -1;
            }
            else
            {
                nCustomerID = Convert.ToInt32(ctlCustomer1.SelectedCustomer.CustomerID); //ctlCustomer1.SelectedCustomer.CustomerID;
            }
            int nParentCustomerID = 0;
            if (ctlCustomer2.SelectedCustomer == null)
            {
                nParentCustomerID = -1;
            }
            else 
            {
                nParentCustomerID = ctlCustomer2.SelectedCustomer.CustomerID;
            }

           

            DBController.Instance.OpenNewConnection();
            _oCustomerTransactions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtInstrumentNo.Text.Trim(), txtTransactionNo.Text.Trim(), nStatus, nCustomerID, nParentCustomerID, nCustomerTranTypeGroupID, nCustomerTranTypeID, IsCheck);
            foreach (CustomerTransaction oCustomerTransaction in _oCustomerTransactions)
            {
                ListViewItem oItem = lvwCustomerTransactions.Items.Add(oCustomerTransaction.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCustomerTransaction.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerTransaction.CustomerName.ToString());
                oItem.SubItems.Add(oCustomerTransaction.ParentCustomerName.ToString());
                oItem.SubItems.Add(oCustomerTransaction.TranTypeGroupName);
                oItem.SubItems.Add(oCustomerTransaction.TranTypeName);
                oItem.SubItems.Add(Convert.ToDouble(oCustomerTransaction.Amount).ToString());
                oItem.SubItems.Add((oCustomerTransaction.InstrumentNo).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.InstrumentStatus), oCustomerTransaction.InstrumentStatus));
                oItem.SubItems.Add((oCustomerTransaction.RowStatus).ToString());

                oItem.Tag = oCustomerTransaction;

            }
            setListViewRowColour();
            this.Cursor = Cursors.Default;
            this.Text = "Order List [" + _oCustomerTransactions.Count + "]";
        }

        private void setListViewRowColour()
        {
            if (lvwCustomerTransactions.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustomerTransactions.Items)
                {
                    if (Convert.ToInt32(oItem.SubItems[9].Text) == (int)Dictionary.RowStatus.CANCEL_AND_FREEZ)
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    if (oItem.SubItems[8].Text == Dictionary.InstrumentStatus.NONE.ToString())
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                }
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCustomerCreditCollection oForm=new frmCustomerCreditCollection((int)Dictionary.CustomerTranGroup.Collection);
            frmCustomerCreditCollection oForm1 =  new frmCustomerCreditCollection((int)Dictionary.CustomerTranGroup.Adjustment);
            CustomerTransaction oCustomerTransaction = (CustomerTransaction)lvwCustomerTransactions.SelectedItems[0].Tag;
            if (oCustomerTransaction.TranTypeGroupID == (int)Dictionary.CustomerTranGroup.Collection)
            {
                oForm.ShowDialog(oCustomerTransaction.CustomerCode, oCustomerTransaction.TranTypeName, Enum.GetName(typeof(Dictionary.InstrumentType), oCustomerTransaction.InstrumentType),oCustomerTransaction.BankName,oCustomerTransaction.BranchName,oCustomerTransaction.InstrumentNo, Convert.ToDateTime(oCustomerTransaction.InstrumentDate),oCustomerTransaction.Remarks,oCustomerTransaction.Amount, oCustomerTransaction.TranID);
            }
            else
            {
                oForm1.ShowDialog(oCustomerTransaction.CustomerCode, oCustomerTransaction.TranTypeName, Enum.GetName(typeof(Dictionary.InstrumentType), oCustomerTransaction.InstrumentType), oCustomerTransaction.BankName, oCustomerTransaction.BranchName, oCustomerTransaction.InstrumentNo, Convert.ToDateTime(oCustomerTransaction.InstrumentDate), oCustomerTransaction.Remarks,oCustomerTransaction.Amount, oCustomerTransaction.TranID);
            }
            DataLoadControl();
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            CustomerTransaction oCustomerTransaction = (CustomerTransaction)lvwCustomerTransactions.SelectedItems[0].Tag;
            PrintMR(oCustomerTransaction.TranID);
        }

        private void PrintMR(int nTranID)
        {
            CustomerTransaction oCustomerTransaction = (CustomerTransaction)lvwCustomerTransactions.SelectedItems[0].Tag;
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
            doc.SetParameterValue("TranNo", oCustomerTransaction.TranNo);
            doc.SetParameterValue("TranDate", _oInvoiceWisePayment.CreateDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerCode", oCustomerTransaction.CustomerCode);//ctlCustomer1.SelectedCustomer.CustomerCode);
            doc.SetParameterValue("CustomerName", oCustomerTransaction.CustomerName);//ctlCustomer1.SelectedCustomer.CustomerName);

            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            if (oCustomerTransaction.TranTypeGroupID == (int)Dictionary.CustomerTranGroup.Collection)
            {
                doc.SetParameterValue("InstrumentType", Enum.GetName(typeof(Dictionary.InstrumentType), oCustomerTransaction.InstrumentType));
                if (Enum.GetName(typeof(Dictionary.InstrumentStatus), oCustomerTransaction.InstrumentType) != "CASH")
                {
                    doc.SetParameterValue("InstrumentNo", oCustomerTransaction.InstrumentNo);
                    doc.SetParameterValue("Date", Convert.ToDateTime(oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("Bank", oCustomerTransaction.BankName);
                    if (oCustomerTransaction.BranchName != "")
                        doc.SetParameterValue("Branch", oCustomerTransaction.BranchName);
                    else doc.SetParameterValue("Branch", "");

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
            doc.SetParameterValue("Amount", oCustomerTransaction.Amount);
            doc.SetParameterValue("TK", oTELLib.TakaWords(Convert.ToDouble(oCustomerTransaction.Amount)));
            doc.SetParameterValue("Remarks", oCustomerTransaction.Remarks);

            //frmPrintPreview oForm = new frmPrintPreview();
            //oForm.ShowDialog(doc);
            doc.PrintToPrinter(1, true, 1, 1);
        }

        private void btnCancelTran_Click(object sender, EventArgs e)
        {
            if (lvwCustomerTransactions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Cancel", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerTransaction oCustomerTransaction = (CustomerTransaction)lvwCustomerTransactions.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to Cancel Transaction#: " + oCustomerTransaction.TranNo + " ? ", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerTransaction.UploadStatus = Convert.ToString((int)Dictionary.UploadStatus.Uploaded);
                    _oCustomerTransaction.RowStatus = (int)Dictionary.RowStatus.CANCEL_AND_FREEZ;
                    _oCustomerTransaction.TranNo = oCustomerTransaction.TranNo;

                    _oCustomerTransaction.CancelCustomerTransaction();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Cancelled Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            frmCustomerCreditCollection oForm = new frmCustomerCreditCollection((int)Dictionary.CustomerTranGroup.Collection);
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            frmCustomerCreditCollection oForm = new frmCustomerCreditCollection((int)Dictionary.CustomerTranGroup.Adjustment);
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwCustomerTransactions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Approve", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerTransaction oCustomerTransaction = (CustomerTransaction)lvwCustomerTransactions.SelectedItems[0].Tag;
            //DialogResult oResult = MessageBox.Show("Are you sure you want to Cancel Transaction#: " + oCustomerTransaction.TranNo + " ? ", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (oResult == DialogResult.Yes)
            //{

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCustomerTransaction.InstrumentStatus = (int)Dictionary.InstrumentStatus.APPROVED;
                    _oCustomerTransaction.TranNo = oCustomerTransaction.TranNo;

                    _oCustomerTransaction.ApproveCustomerTransaction();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Approved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            //}
        }
    }
}
