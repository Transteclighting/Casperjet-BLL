// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 23, 2014
// Time :  01:44 PM
// Description: Form for ConsumerBalanceTran.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Report;
using CJ.Report.POS;
using TEL.Common;
using Dictionary = CJ.Class.Dictionary;
using ReportFactory = CJ.Report.ReportFactory;

namespace CJ.POS
{
    public partial class frmAdvancePayments : Form
    {
        ConsumerBalanceTrans _oConsumerBalanceTrans;
        TELLib _oTELLib;
        SystemInfo _oSystemInfo;
        public frmAdvancePayments()
        {
            InitializeComponent();
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdvancePayment oForm = new frmAdvancePayment();
            oForm.ShowDialog();
            DataLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwConsumerBalance.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Transaction to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)lvwConsumerTran.SelectedItems[0].Tag;
            if (oConsumerBalanceTran.TranType == Dictionary.ConsumerAdvancePaymentTranType.Adjust)
            {
                MessageBox.Show("You can update only Advance Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oConsumerBalanceTran.IsUpload == (int)Dictionary.YesOrNoStatus.YES)
            {
                MessageBox.Show("You can update only Create Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmAdvancePayment oForm = new frmAdvancePayment();
            oForm.ShowDialog(oConsumerBalanceTran);
            DataLoad();
            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lvwConsumerBalance.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select Transaction to Print.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oTELLib = new TELLib();
            _oSystemInfo=new SystemInfo();
            _oSystemInfo.Refresh();
            _oConsumerBalanceTrans = new ConsumerBalanceTrans();
            //DBController.Instance.OpenNewConnection();
            ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            _oConsumerBalanceTrans.RefreshTran(oConsumerBalanceTran.ConsumerID, oConsumerBalanceTran.CustomerID);

            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptConsumerAccountBalance));
            oReport.SetDataSource(_oConsumerBalanceTrans);

            oReport.SetParameterValue("Balance", _oTELLib.TakaFormat(oConsumerBalanceTran.Amount));
            oReport.SetParameterValue("Date", Convert.ToDateTime(_oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("Outlet", _oSystemInfo.Shortcode);
            oReport.SetParameterValue("OutletName", _oSystemInfo.WarehouseName);
            oReport.SetParameterValue("OutletAddress", _oSystemInfo.WarehouseAddress);
            oReport.SetParameterValue("OutletMobileNo", _oSystemInfo.WarehouseCellNo);

            oReport.SetParameterValue("CompanyInfo", Utility.CompanyName);
            oReport.SetParameterValue("ReportName", "Consumer Account Balance");
            oReport.SetParameterValue("BalanceInWord", _oTELLib.TakaWords(oConsumerBalanceTran.Amount));

            oReport.SetParameterValue("ConsumerName", oConsumerBalanceTran.ConsumerName);
            oReport.SetParameterValue("ConsumerCode", oConsumerBalanceTran.ConsumerCode);
            oReport.SetParameterValue("Address", oConsumerBalanceTran.Address);
            oReport.SetParameterValue("ContactNo", oConsumerBalanceTran.ContactNo);
            oReport.SetParameterValue("PrintBy", Utility.UserFullname);

            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void frmAdvancePayments_Load(object sender, EventArgs e)
        {
            DataLoad();
            ComboLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoad()
        {
            _oTELLib = new TELLib();
            _oConsumerBalanceTrans = new ConsumerBalanceTrans();
            lvwConsumerBalance.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oConsumerBalanceTrans.Refresh(txtCode.Text.Trim(), txtCustomerName.Text.Trim(),txtContactNo.Text.Trim(), cmbBalance.SelectedIndex);
            this.Text = "Total  " + "[" + _oConsumerBalanceTrans.Count + "]";

            foreach (ConsumerBalanceTran oConsumerBalanceTran in _oConsumerBalanceTrans)
            {
                ListViewItem oItem = lvwConsumerBalance.Items.Add(oConsumerBalanceTran.ConsumerCode);
                
                oItem.SubItems.Add(oConsumerBalanceTran.ConsumerName);
                oItem.SubItems.Add(oConsumerBalanceTran.ContactNo);
                oItem.SubItems.Add(_oTELLib.TakaFormat(oConsumerBalanceTran.Amount).ToString());
                oItem.SubItems.Add(oConsumerBalanceTran.Address);

                oItem.Tag = oConsumerBalanceTran;
            }
        }
        private void DataLoadTran(int nConsumerID, int nCustomerID)
        {
            _oTELLib = new TELLib();
            _oConsumerBalanceTrans = new ConsumerBalanceTrans();
            lvwConsumerTran.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oConsumerBalanceTrans.RefreshTran(nConsumerID, nCustomerID);
            this.Text = "Total  " + "[" + _oConsumerBalanceTrans.Count + "]";

            foreach (ConsumerBalanceTran oConsumerBalanceTranDetail in _oConsumerBalanceTrans)
            {
                ListViewItem oItem = lvwConsumerTran.Items.Add(Convert.ToDateTime(oConsumerBalanceTranDetail.CreateDate).ToString("dd-MMM-yyyy"));

                oItem.SubItems.Add(oConsumerBalanceTranDetail.TranType.ToString());
                oItem.SubItems.Add(oConsumerBalanceTranDetail.AdvancePaymentNo);
                oItem.SubItems.Add(oConsumerBalanceTranDetail.InvoiceNo);
                oItem.SubItems.Add(_oTELLib.TakaFormat(oConsumerBalanceTranDetail.Amount).ToString());
                oItem.SubItems.Add(oConsumerBalanceTranDetail.TranSide.ToString());
                oItem.SubItems.Add(oConsumerBalanceTranDetail.PaymentModeName.ToString());
                oItem.SubItems.Add(oConsumerBalanceTranDetail.ProductName);

                oItem.Tag = oConsumerBalanceTranDetail;
            }
        }
        private void ComboLoad()
        {
            cmbBalance.Items.Clear();
            cmbBalance.Items.Add("<All>");
            cmbBalance.Items.Add(">0.00");
            cmbBalance.Items.Add("0.00");
            cmbBalance.SelectedIndex = 1;
        }

        private void lvwConsumerBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }
        private void lvwConsumerBalance_KeyDown(object sender, KeyEventArgs e)
        {
            ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }
        private void lvwConsumerBalance_KeyUp(object sender, KeyEventArgs e)
        {
            ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }
        private void lvwConsumerBalance_MouseClick(object sender, MouseEventArgs e)
        {
            ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }

        private void btnPrintThermal_Click(object sender, EventArgs e)
        {
            if (lvwConsumerBalance.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select Transaction to Print.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oTELLib = new TELLib();
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();
            _oConsumerBalanceTrans = new ConsumerBalanceTrans();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            _oConsumerBalanceTrans.RefreshTran(oConsumerBalanceTran.ConsumerID, oConsumerBalanceTran.CustomerID);

            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptConsumerAccountBalanceThermal));
            oReport.SetDataSource(_oConsumerBalanceTrans);

            oReport.SetParameterValue("Balance", _oTELLib.TakaFormat(oConsumerBalanceTran.Amount));
            oReport.SetParameterValue("Date", _oTELLib.ServerDateTime().Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("Outlet", _oSystemInfo.Shortcode);
            oReport.SetParameterValue("OutletName", _oSystemInfo.WarehouseName);
            oReport.SetParameterValue("OutletAddress", _oSystemInfo.WarehouseAddress);
            oReport.SetParameterValue("OutletMobileNo", _oSystemInfo.WarehouseCellNo);


            oReport.SetParameterValue("CompanyInfo", Utility.CompanyName);
            oReport.SetParameterValue("ReportName", "Consumer Account Balance");
            oReport.SetParameterValue("BalanceInWord", _oTELLib.TakaWords(oConsumerBalanceTran.Amount));

            oReport.SetParameterValue("ConsumerName", oConsumerBalanceTran.ConsumerName);
            oReport.SetParameterValue("ConsumerCode", oConsumerBalanceTran.ConsumerCode);
            oReport.SetParameterValue("Address", oConsumerBalanceTran.Address);
            oReport.SetParameterValue("ContactNo", oConsumerBalanceTran.ContactNo);
            oReport.SetParameterValue("PrintBy", Utility.UserFullname);

            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }
    }
}