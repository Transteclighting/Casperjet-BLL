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

namespace CJ.POS
{
    public partial class frmDCSs : Form
    {
        bool IsCheck;
        DCSs _oDCSs;
        DCS _oDCS;
        SystemInfo _oSystemInfo;
        TELLib _oTELLib;
        ConsumerBalanceTran _oConsumerBalanceTran;
        DCSDetail _oDCSDetail;
        SalesInvoice _oSalesInvoice;
        CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection;

        public frmDCSs()
        {
            InitializeComponent();
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

        private void frmDCSs_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();
            dtFromDate.Value = Convert.ToDateTime(_oSystemInfo.OperationDate);
            dtToDate.Value = Convert.ToDateTime(_oSystemInfo.OperationDate);
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            _oDCSs = new DCSs();
            lvwDCSs.Items.Clear();
            {
                _oDCSs.RefreshPOS(dtFromDate.Value.Date, dtToDate.Value.Date, txtDCSNo.Text, IsCheck);
            }

            this.Text = "Total DCS " + "[" + _oDCSs.Count + "]";
            foreach (DCS oDCS in _oDCSs)
            {
                ListViewItem oItem = lvwDCSs.Items.Add(oDCS.DCSNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oDCS.DCSDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDCS.CollectionAmount.ToString());
                oItem.SubItems.Add(oDCS.Remarks);
                oItem.SubItems.Add(Convert.ToDateTime(oDCS.CreateDate).ToString("dd-MMM-yyyy"));

                oItem.Tag = oDCS;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDCS oForm = new frmDCS();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lvwDCSs.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _oTELLib = new TELLib();
                _oConsumerBalanceTran = new ConsumerBalanceTran();
                _oDCS = new DCS();
                _oDCS = (DCS)lvwDCSs.SelectedItems[0].Tag;
                _oDCS.RefreshDCSDetail(1, _oDCS.DCSDate.Date);

                _oDCSs = new DCSs();
                _oDCSs.Refresh(Convert.ToDateTime(_oDCS.DCSDate.Date));

                DCS oDeposit = new DCS();
                oDeposit.GetDepositDetail(_oDCS.DCSID);

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
                    oInvoiceRow.AdvanceAdjusted = oDCSDetail.AdvanceAdjusted;
                    oInvoiceRow.B2BCredit = oDCSDetail.B2BCredit;
                    oInvoiceRow.CreditApprovalNo = oDCSDetail.InstrumentNo;
                    oInvoiceRow.CustomerBG = oDCSDetail.CustomerBG;
                    oInvoiceRow.Type = oDCSDetail.DCSTypeName;
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
                _oDCSDetail.GetAmountByType(_oDCS.DCSDate.Date);
                _oDCSDetail.GetCollectionAmount(_oDCS.DCSID);
                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();

                DCSDetail _oExtendedWarranty = new DCSDetail();
                _oExtendedWarranty.GetExtendedWarrantyAmount(_oDCS.DCSID);

                double _CreditCollection = _oDCSDetail.CreditCollection;

                PaymentMode oPaymentMode = new PaymentMode();
                oPaymentMode.GetInvoicePaymentMode(_oDCS.DCSDate.Date);

                double _AdvanceReceive = _oConsumerBalanceTran.GetAdvanceAmountByDate(_oDCS.DCSDate.Date);
                double _AdditionalAmtRcv = _oDCS.GetAdditionalAmtRcv(_oDCS.DCSDate.Date);
                double TotalReceive = (_AdvanceReceive + _AdditionalAmtRcv + _oDCSDetail.Cash + _oDCSDetail.CreditCard + _oDCSDetail.Others + _oDCSDetail.B2BCredit + _oDCSDetail.CustomerBG + _CreditCollection + oPaymentMode.AdvancePayment) + _oExtendedWarranty.Cash + _oExtendedWarranty.CreditCard;

                double _AdditionalAmtDeposit = _oDCS.GetAdditionalAmtDeposit(_oDCS.DCSDate.Date);

                DCS _oDCSPaymentDetail = new DCS();

                doc.SetParameterValue("PaymentDetail", _oDCSPaymentDetail.GetDcsPaymentDetail(_oDCS.DCSID));

                doc.SetParameterValue("OutletName", "[" + _oSystemInfo.Shortcode + "] " + _oSystemInfo.WarehouseName);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("DCSDate", _oDCS.DCSDate.Date.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("DCSNo", _oDCS.DCSNo);
                doc.SetParameterValue("ReportName", "Daily Collection Statement");
                doc.SetParameterValue("AdvanceReceive", _oTELLib.TakaFormat(_AdvanceReceive));
                doc.SetParameterValue("AdditionalAmtRcv", _oTELLib.TakaFormat(_AdditionalAmtRcv));
                doc.SetParameterValue("Cash", _oTELLib.TakaFormat(_oDCSDetail.Cash + _oExtendedWarranty.Cash));
                doc.SetParameterValue("CreditCard", _oTELLib.TakaFormat(_oDCSDetail.CreditCard + _oExtendedWarranty.CreditCard));
                doc.SetParameterValue("Others", _oTELLib.TakaFormat(_oDCSDetail.Others));
                doc.SetParameterValue("CreditCollection", _oTELLib.TakaFormat(_CreditCollection));
                doc.SetParameterValue("B2BCredit", _oTELLib.TakaFormat(_oDCSDetail.B2BCredit));
                doc.SetParameterValue("BG", _oTELLib.TakaFormat(_oDCSDetail.CustomerBG));
                doc.SetParameterValue("CashDeposit", _oTELLib.TakaFormat(_DepositAmount));
                doc.SetParameterValue("AdjustB2BCredit", _oTELLib.TakaFormat(_oDCSDetail.B2BCredit));
                PaymentMode _BG = new PaymentMode();
                double _BGAmount = _BG.GetRevInvBG(_oDCS.DCSDate.Date);
                double _AdjustBG = _oDCSDetail.CustomerBG - _BGAmount;
                doc.SetParameterValue("AdjustBG", _oTELLib.TakaFormat(_AdjustBG));

                double _CardRevAmt = _oDCSDetail.CreditCard + _oExtendedWarranty.CreditCard - oPaymentMode.GetRevInvCard(_oDCS.DCSDate.Date);
                doc.SetParameterValue("AdvanceAdjusted",_oTELLib.TakaFormat(oPaymentMode.AdvancePayment));
                _oSalesInvoice = new SalesInvoice();
                double _ReverseAmt = _oSalesInvoice.GetReverseInvoice(_oDCS.DCSDate.Date);
                doc.SetParameterValue("ReverseAmount", _oTELLib.TakaFormat(_ReverseAmt));
                doc.SetParameterValue("AdditionalDeduct", _oTELLib.TakaFormat(_AdditionalAmtDeposit));
                doc.SetParameterValue("CreditCardRev", _oTELLib.TakaFormat(_CardRevAmt));

                double _TotalDeposit = (_DepositAmount + oPaymentMode.AdvancePayment + _CardRevAmt + _AdditionalAmtDeposit + _ReverseAmt + _oDCSDetail.B2BCredit + _AdjustBG);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintThermal_Click(object sender, EventArgs e)
        {
            if (lvwDCSs.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _oTELLib = new TELLib();
                _oConsumerBalanceTran = new ConsumerBalanceTran();
                _oDCS = new DCS();
                _oDCS = (DCS)lvwDCSs.SelectedItems[0].Tag;
                //_oDCS.RefreshDCSDetailHO(1, _oDCS.DCSDate.Date, Utility.CustomerID);
                _oDCS.RefreshDCSDetail(1, _oDCS.DCSDate.Date);

                _oDCSs = new DCSs();
                //_oDCSs.RefreshHO1(_oDCS.DCSDate.Date, Utility.CustomerID);
                _oDCSs.Refresh(Convert.ToDateTime(_oDCS.DCSDate.Date));

                DCS oDeposit = new DCS();
                //oDeposit.GetDepositDetailHO(_oDCS.DCSID, Utility.CustomerID);
                oDeposit.GetDepositDetail(_oDCS.DCSID);

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
                    oInvoiceRow.AdvanceAdjusted = oDCSDetail.AdvanceAdjusted;
                    oInvoiceRow.B2BCredit = oDCSDetail.B2BCredit;
                    oInvoiceRow.CreditApprovalNo = oDCSDetail.InstrumentNo;
                    oInvoiceRow.CustomerBG = oDCSDetail.CustomerBG;
                    oInvoiceRow.Type = oDCSDetail.DCSTypeName;
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

                CJ.Report.POS.rptDCSThermal doc = new CJ.Report.POS.rptDCSThermal();
                doc.SetDataSource(oDSDCS);

                _oDCSDetail = new DCSDetail();
                _oDCSDetail.GetAmountByType(_oDCS.DCSDate.Date);
                _oDCSDetail.GetCollectionAmount(_oDCS.DCSID);


                DCSDetail _oExtendedWarranty = new DCSDetail();
                _oExtendedWarranty.GetExtendedWarrantyAmount(_oDCS.DCSID);

                double _CreditCollection = _oDCSDetail.CreditCollection;

                PaymentMode oPaymentMode = new PaymentMode();
                oPaymentMode.GetInvoicePaymentMode(_oDCS.DCSDate.Date);

                double _AdvanceReceive = _oConsumerBalanceTran.GetAdvanceAmountByDate(_oDCS.DCSDate.Date);
                //double _AdditionalAmtRcv = _oDCS.GetAdditionalAmtRcvHO(_oDCS.DCSDate.Date, Utility.CustomerID);
                double _AdditionalAmtRcv = _oDCS.GetAdditionalAmtRcv(_oDCS.DCSDate.Date);
                double TotalReceive = (_AdvanceReceive + _AdditionalAmtRcv + _oDCSDetail.Cash + _oDCSDetail.CreditCard + _oDCSDetail.Others + _oDCSDetail.B2BCredit + _oDCSDetail.CustomerBG + _CreditCollection + oPaymentMode.AdvancePayment) + _oExtendedWarranty.Cash + _oExtendedWarranty.CreditCard;

                //double _AdditionalAmtDeposit = _oDCS.GetAdditionalAmtDepositHO(_oDCS.DCSDate.Date, Utility.CustomerID);
                double _AdditionalAmtDeposit = _oDCS.GetAdditionalAmtDeposit(_oDCS.DCSDate.Date);

                DCS _oDCSPaymentDetail = new DCS();

                doc.SetParameterValue("PaymentDetail", _oDCSPaymentDetail.GetDcsPaymentDetail(_oDCS.DCSID));

                doc.SetParameterValue("OutletName", "[" + Utility.Shortcode + "] " + Utility.WarehouseName);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("DCSDate", _oDCS.DCSDate.Date.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("DCSNo", _oDCS.DCSNo);
                doc.SetParameterValue("ReportName", "Daily Collection Statement");
                doc.SetParameterValue("AdvanceReceive", _oTELLib.TakaFormatWithoutDesimal(_AdvanceReceive));
                doc.SetParameterValue("AdditionalAmtRcv", _oTELLib.TakaFormatWithoutDesimal(_AdditionalAmtRcv));
                doc.SetParameterValue("Cash", _oTELLib.TakaFormatWithoutDesimal(_oDCSDetail.Cash + _oExtendedWarranty.Cash));
                doc.SetParameterValue("CreditCard", _oTELLib.TakaFormatWithoutDesimal(_oDCSDetail.CreditCard + _oExtendedWarranty.CreditCard));
                doc.SetParameterValue("Others", _oTELLib.TakaFormatWithoutDesimal(_oDCSDetail.Others));
                doc.SetParameterValue("CreditCollection", _oTELLib.TakaFormatWithoutDesimal(_CreditCollection));
                doc.SetParameterValue("B2BCredit", _oTELLib.TakaFormatWithoutDesimal(_oDCSDetail.B2BCredit));
                doc.SetParameterValue("BG", _oTELLib.TakaFormatWithoutDesimal(_oDCSDetail.CustomerBG));
                doc.SetParameterValue("CashDeposit", _oTELLib.TakaFormatWithoutDesimal(_DepositAmount));
                doc.SetParameterValue("AdjustB2BCredit", _oTELLib.TakaFormatWithoutDesimal(_oDCSDetail.B2BCredit));
                PaymentMode _BG = new PaymentMode();
                double _BGAmount = _BG.GetRevInvBG(_oDCS.DCSDate.Date);
                double _AdjustBG = _oDCSDetail.CustomerBG - _BGAmount;
                doc.SetParameterValue("AdjustBG", _oTELLib.TakaFormatWithoutDesimal(_AdjustBG));

                double _CardRevAmt = _oDCSDetail.CreditCard + _oExtendedWarranty.CreditCard - oPaymentMode.GetRevInvCardRT(_oDCS.DCSDate.Date);
                doc.SetParameterValue("AdvanceAdjusted", _oTELLib.TakaFormatWithoutDesimal(oPaymentMode.AdvancePayment));
                _oSalesInvoice = new SalesInvoice();
                //double _ReverseAmt = _oSalesInvoice.GetReverseInvoiceHO(_oDCS.DCSDate.Date, Utility.CustomerID);
                double _ReverseAmt = _oSalesInvoice.GetReverseInvoice(_oDCS.DCSDate.Date);
                doc.SetParameterValue("ReverseAmount", _oTELLib.TakaFormatWithoutDesimal(_ReverseAmt));
                doc.SetParameterValue("AdditionalDeduct", _oTELLib.TakaFormatWithoutDesimal(_AdditionalAmtDeposit));
                doc.SetParameterValue("CreditCardRev", _oTELLib.TakaFormatWithoutDesimal(_CardRevAmt));

                double _TotalDeposit = (_DepositAmount + oPaymentMode.AdvancePayment + _CardRevAmt + _AdditionalAmtDeposit + _ReverseAmt + _oDCSDetail.B2BCredit + _AdjustBG);
                doc.SetParameterValue("TotalDeposit", _oTELLib.TakaFormatWithoutDesimal(_TotalDeposit));
                doc.SetParameterValue("Remarks", _oDCS.Remarks);
                doc.SetParameterValue("TotalReceive", _oTELLib.TakaFormatWithoutDesimal(TotalReceive));
                doc.SetParameterValue("Different", _oTELLib.TakaFormatWithoutDesimal(TotalReceive - _TotalDeposit));
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
    }
}