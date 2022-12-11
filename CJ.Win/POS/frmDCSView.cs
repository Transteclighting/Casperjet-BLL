using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Report;
using CJ.Class.Library;

namespace CJ.Win.POS
{
    public partial class frmDCSView : Form
    {
        bool IsCheck;
        Showrooms _oShowrooms;
        DCSs _oDCSs;
        TELLib _oTELLib;
        ConsumerBalanceTran _oConsumerBalanceTran;
        DCS _oDCS;
        DCSDetail _oDCSDetail;
        SalesInvoice _oSalesInvoice;


        public frmDCSView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {

            _oDCSs = new DCSs();
            lvwDCSs.Items.Clear();

            int nCustomerID = 0;
            if (cmbOutlet.SelectedIndex == 0)
            {
                nCustomerID = -1;
            }
            else
            {
                nCustomerID = _oShowrooms[cmbOutlet.SelectedIndex - 1].CustomerID;
            }
            DBController.Instance.OpenNewConnection();
            _oDCSs.RefreshForHO(dtFromDate.Value.Date, dtToDate.Value.Date, txtDCSNo.Text, nCustomerID, IsCheck);
            DBController.Instance.CloseConnection();
            this.Text = "Total DCS " + "[" + _oDCSs.Count + "]";
            foreach (DCS oDCS in _oDCSs)
            {
                ListViewItem oItem = lvwDCSs.Items.Add(oDCS.DCSNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oDCS.DCSDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDCS.ShowroomCode.ToString());
                oItem.SubItems.Add(oDCS.CollectionAmount.ToString());
                oItem.SubItems.Add(oDCS.Remarks);
                oItem.SubItems.Add(Convert.ToDateTime(oDCS.CreateDate).ToString("dd-MMM-yyyy"));

                oItem.Tag = oDCS;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lvwDCSs.SelectedItems.Count != 0)
            {
                DBController.Instance.OpenNewConnection();
                this.Cursor = Cursors.WaitCursor;
                _oTELLib = new TELLib();
                _oConsumerBalanceTran = new ConsumerBalanceTran();
                _oDCS = new DCS();
                _oDCS = (DCS)lvwDCSs.SelectedItems[0].Tag;
                _oDCS.RefreshDCSDetailHO(1, dtFromDate.Value.Date, _oDCS.CustomerID);

                _oDCSs = new DCSs();
                _oDCSs.RefreshHO1(Convert.ToDateTime(_oDCS.DCSDate.Date), _oDCS.CustomerID);

                DCS oDeposit = new DCS();
                oDeposit.GetDepositDetailHO(_oDCS.DCSID, _oDCS.CustomerID);

                DSDCS oDSDCS = new DSDCS();
                DSDCS oDSInvoice = new DSDCS();
                DSDCS oDSCreditCard = new DSDCS();
                DSDCS oDSDeposit = new DSDCS();
                double _DepositAmount = 0;
                foreach (DCSDetail oDCSDetail in _oDCS)
                {
                    DSDCS.InvoiceRow oInvoiceRow = oDSInvoice.Invoice.NewInvoiceRow();

                    oInvoiceRow.InvoiceNo = oDCSDetail.InvoiceNo;
                    oInvoiceRow.Cash = oDCSDetail.Cash;
                    oInvoiceRow.CreditCard = oDCSDetail.CreditCard;
                    oInvoiceRow.Others = oDCSDetail.Others;
                    oInvoiceRow.CustomerBG = oDCSDetail.CustomerBG;
                    oInvoiceRow.AdvanceAdjusted = oDCSDetail.AdvanceAdjusted;
                    oInvoiceRow.B2BCredit = oDCSDetail.B2BCredit;
                    oInvoiceRow.CreditApprovalNo = oDCSDetail.InstrumentNo;

                    oDSInvoice.Invoice.AddInvoiceRow(oInvoiceRow);
                    oDSInvoice.AcceptChanges();

                }
                foreach (DCS oDCS in _oDCSs)
                {
                    DSDCS.CreditCardDetailRow oCreditCardDetailRow = oDSCreditCard.CreditCardDetail.NewCreditCardDetailRow();

                    oCreditCardDetailRow.CardType = oDCS.CreditCardType;
                    oCreditCardDetailRow.Amount = oDCS.CreditCardAmount;
                    oCreditCardDetailRow.BankName = oDCS.BankName;
                    oCreditCardDetailRow.AssetName = oDCS.AssetName;
                    oCreditCardDetailRow.InstallmentNo = oDCS.InstallmentNo;
                    oCreditCardDetailRow.Instrument = oDCS.Instrument;

                    oDSCreditCard.CreditCardDetail.AddCreditCardDetailRow(oCreditCardDetailRow);
                    oDSCreditCard.AcceptChanges();
                }
                foreach (DCSDetail oDCSDetail in oDeposit)
                {
                    DSDCS.DepositDetailRow oDepositDetailRow = oDSDeposit.DepositDetail.NewDepositDetailRow();
                    oDepositDetailRow.InstrumentName = oDCSDetail.InstrumentName;
                    oDepositDetailRow.Amount = oDCSDetail.Amount;
                    oDepositDetailRow.Account = oDCSDetail.BankAccount;
                    oDepositDetailRow.DepositedBranch = oDCSDetail.BankBranch;
                    oDepositDetailRow.InstrumentNo = oDCSDetail.InstrumentNo;
                    oDepositDetailRow.InstrumentDate = Convert.ToDateTime(oDCSDetail.InstrumentDate);
                    oDepositDetailRow.Remarks = oDCSDetail.Remarks;

                    oDSDeposit.DepositDetail.AddDepositDetailRow(oDepositDetailRow);
                    oDSDeposit.AcceptChanges();

                    _DepositAmount = _DepositAmount + oDCSDetail.Amount;

                }
                oDSDCS.Merge(oDSInvoice);
                oDSDCS.Merge(oDSCreditCard);
                oDSDCS.Merge(oDSDeposit);
                oDSDCS.AcceptChanges();

                CJ.Report.POS.rptDCS doc = new CJ.Report.POS.rptDCS();
                doc.SetDataSource(oDSDCS);

                _oDCSDetail = new DCSDetail();
                _oDCSDetail.GetAmountByTypeHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);
                _oDCSDetail.GetCollectionAmountHO(_oDCS.DCSID, _oDCS.CustomerID);
                Showroom _oShowroom = new Showroom();
                _oShowroom.GetShowroomByCustID(_oDCS.CustomerID);


                double _CreditCollection = _oDCSDetail.CreditCollection;

                PaymentMode oPaymentMode = new PaymentMode();
                oPaymentMode.GetInvoicePaymentModeHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);

                double _AdvanceReceive = _oConsumerBalanceTran.GetAdvanceAmountByDateHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);
                double _AdditionalAmtRcv = _oDCS.GetAdditionalAmtRcvHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);
                double TotalReceive = (_AdvanceReceive + _AdditionalAmtRcv + _oDCSDetail.Cash + _oDCSDetail.CreditCard + _oDCSDetail.Others + _oDCSDetail.B2BCredit + _CreditCollection + oPaymentMode.AdvancePayment);

                double _AdditionalAmtDeposit = _oDCS.GetAdditionalAmtDepositHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);

                doc.SetParameterValue("OutletName", "[" + _oShowroom.ShowroomCode + "] " + _oShowroom.ShowroomName);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("DCSDate", _oDCS.DCSDate.Date.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("DCSNo", _oDCS.DCSNo);
                doc.SetParameterValue("ReportName", "Daily Collection Statement");
                doc.SetParameterValue("AdvanceReceive", _oTELLib.TakaFormat(_AdvanceReceive));
                doc.SetParameterValue("AdditionalAmtRcv", _oTELLib.TakaFormat(_AdditionalAmtRcv));
                doc.SetParameterValue("Cash", _oTELLib.TakaFormat(_oDCSDetail.Cash));
                doc.SetParameterValue("CreditCard", _oTELLib.TakaFormat(_oDCSDetail.CreditCard));
                doc.SetParameterValue("BG", _oTELLib.TakaFormat(_oDCSDetail.CustomerBG));
                doc.SetParameterValue("Others", _oTELLib.TakaFormat(_oDCSDetail.Others));
                doc.SetParameterValue("CreditCollection", _oTELLib.TakaFormat(_CreditCollection));
                doc.SetParameterValue("B2BCredit", _oTELLib.TakaFormat(_oDCSDetail.B2BCredit));
                doc.SetParameterValue("CashDeposit", _oTELLib.TakaFormat(_DepositAmount));
                doc.SetParameterValue("AdjustB2BCredit", _oTELLib.TakaFormat(_oDCSDetail.B2BCredit));

                PaymentMode _BG = new PaymentMode();
                double _BGAmount = _BG.GetRevInvBG(_oDCS.DCSDate.Date);
                double _AdjustBG = _oDCSDetail.CustomerBG - _BGAmount;
                doc.SetParameterValue("AdjustBG", _oTELLib.TakaFormat(_AdjustBG));

                double _CardRevAmt = _oDCSDetail.CreditCard - oPaymentMode.GetRevInvCardHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);
                doc.SetParameterValue("AdvanceAdjusted", _oTELLib.TakaFormat(oPaymentMode.AdvancePayment));
                _oSalesInvoice = new SalesInvoice();
                double _ReverseAmt = _oSalesInvoice.GetReverseInvoiceHO(_oDCS.DCSDate.Date, _oDCS.CustomerID);
                doc.SetParameterValue("ReverseAmount", _oTELLib.TakaFormat(_ReverseAmt));
                doc.SetParameterValue("AdditionalDeduct", _oTELLib.TakaFormat(_AdditionalAmtDeposit));
                doc.SetParameterValue("CreditCardRev", _oTELLib.TakaFormat(_CardRevAmt));

                double _TotalDeposit = (_DepositAmount + oPaymentMode.AdvancePayment + _CardRevAmt + _AdditionalAmtDeposit + _ReverseAmt + _oDCSDetail.B2BCredit);
                doc.SetParameterValue("TotalDeposit", _oTELLib.TakaFormat(_TotalDeposit));
                doc.SetParameterValue("Remarks", _oDCS.Remarks);
                doc.SetParameterValue("TotalReceive", _oTELLib.TakaFormat(TotalReceive));
                doc.SetParameterValue("Different", _oTELLib.TakaFormat(TotalReceive - _TotalDeposit));
                doc.SetParameterValue("User", Utility.UserFullname);

                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(doc);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmDCSView_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
    }
}