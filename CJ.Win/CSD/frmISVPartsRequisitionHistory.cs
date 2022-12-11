using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmISVPartsRequisitionHistory : Form
    {
        SparePartsTransaction _oSparePartsTransaction;
        SparePartsTransactions oSparePartsTransactions;
        SparePartsSends oSparePartsSends;
        ISVSpareCommunications oISVSpareCommunications;

        public frmISVPartsRequisitionHistory()
        {
            InitializeComponent();
        }
        private void DataLoadControlSend()
        {
            _oSparePartsTransaction = (SparePartsTransaction)this.Tag;

            oSparePartsSends = new SparePartsSends();
            oSparePartsSends.Refresh(_oSparePartsTransaction.ISVRequisitionID);
            lvwSend.Items.Clear();

            foreach (SparePartsSend oSparePartsSend in oSparePartsSends)
            {
                ListViewItem oItem = lvwSend.Items.Add(oSparePartsSend.BookingDate.ToString());
                if (oSparePartsSend.ModeOfSend == (int)Dictionary.ISVRequisitionDeliveryMode.ByCourier)
                {
                    oItem.SubItems.Add("By Courier");
                }
                else if (oSparePartsSend.ModeOfSend == (int)Dictionary.ISVRequisitionDeliveryMode.HandToHand)
                {
                    oItem.SubItems.Add("Hand-to-hand");
                }
                oItem.SubItems.Add(oSparePartsSend.CourierFromCassandra.CourierServiceName.ToString());
                oItem.SubItems.Add(oSparePartsSend.ConsignmentNo.ToString());
                oItem.SubItems.Add(oSparePartsSend.ReceiveBy.ToString());
                oItem.SubItems.Add(oSparePartsSend.Remarks.ToString());
                
                oItem.Tag = _oSparePartsTransaction;
            }
            //setListViewRowColour();
        }
        private void DataLoadControlIssue()
            
        {
            _oSparePartsTransaction = (SparePartsTransaction)this.Tag;

            oSparePartsTransactions = new SparePartsTransactions();
            oSparePartsTransactions.RefreshByRequisitionIDView(_oSparePartsTransaction.ISVRequisitionID);
            lvwIssue.Items.Clear();

            foreach (SparePartsTransactionDetail _oSparePartsTransactionDetail in oSparePartsTransactions)
            {
                ListViewItem oItem = lvwIssue.Items.Add(_oSparePartsTransactionDetail.SpareParts.Code.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SpareParts.Name.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.ClaimQty.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SerarchProduct.ProductName.ToString());
                if (_oSparePartsTransactionDetail.SubStatus == (int)Dictionary.ISVRequisitionSubStatus.FromStock)
                {
                    oItem.SubItems.Add("FromStock");
                }
                else if (_oSparePartsTransactionDetail.SubStatus == (int)Dictionary.ISVRequisitionSubStatus.FromLoanSet)
                {
                    oItem.SubItems.Add("FromLoanSet");
                }
                oItem.SubItems.Add(_oSparePartsTransactionDetail.LoanCode.ToString());

                oItem.Tag = _oSparePartsTransaction;
            }
            //setListViewRowColour();
        }
        private void DataLoadControlCommu()
        {
            _oSparePartsTransaction = (SparePartsTransaction)this.Tag;

            oISVSpareCommunications = new ISVSpareCommunications();
            oISVSpareCommunications.RefreshByISVReqID(_oSparePartsTransaction.ISVRequisitionID);
            lvwCommu.Items.Clear();

            foreach (ISVSpareCommunication oISVSpareCommunication in oISVSpareCommunications)
            {
                ListViewItem oItem = lvwCommu.Items.Add(oISVSpareCommunication.EDD.ToString());

                oItem.SubItems.Add(oISVSpareCommunication.User.UserFullName.ToString());

                oItem.Tag = _oSparePartsTransaction;
            }
            //setListViewRowColour();
        }
        public void ShowDialog(SparePartsTransaction _oSparePartsTransaction)
        {
            this.Tag = _oSparePartsTransaction;
            lblRequisitionID.Text = _oSparePartsTransaction.ISVRequisitionID.ToString();
            lblReportNo.Text = _oSparePartsTransaction.ReportNo.ToString();
            lblSerialNo.Text = _oSparePartsTransaction.SerialNo.ToString();
            lblReceiveDate.Text = _oSparePartsTransaction.ReceiveDate.Date.ToString("dd-MMM-yyyy");
            lblPrepareDate.Text = _oSparePartsTransaction.PrepareDate.Date.ToString("dd-MMM-yyyy");
            lblInterService.Text = _oSparePartsTransaction.InterService.Code + " / " + _oSparePartsTransaction.InterService.Name;

            _oSparePartsTransaction.RefreshByRequisitionID();

            foreach (SparePartsTransactionDetail _oSparePartsTransactionDetail in _oSparePartsTransaction)
            {

                ListViewItem oItem = lvwPending.Items.Add(_oSparePartsTransactionDetail.SpareParts.Code.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SpareParts.Name.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.ClaimQty.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SerarchProduct.ProductName.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.SubStatusName.ToString());
                oItem.SubItems.Add(_oSparePartsTransactionDetail.EDD.ToString());


                oItem.Tag = _oSparePartsTransaction;
            }

            //this.Tag = _oSparePartsTransaction;

            this.ShowDialog();
        }

        private void frmISVPartsRequisitionHistory_Load(object sender, EventArgs e)
        {
            DataLoadControlIssue();
            DataLoadControlSend();
            DataLoadControlCommu();
        }
    }
}