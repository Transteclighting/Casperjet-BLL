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
using CJ.Report.CSD;
using CJ.Class.CSD;
using CJ.Report;

using Dictionary = CJ.Class.Dictionary;
using ReportFactory = CJ.Report.ReportFactory;

namespace CJ.Win.CSD.Reception
{
    public partial class frmAdvancePayments : Form
    {
        CSDJob _oCSDJob;
        ProductDetail _oProductDetail;
        JobHistory _oJobHistory;
        JobHistorys _oJobHistorys;
        ConsumerBalanceTrans _oConsumerBalanceTrans = new ConsumerBalanceTrans();
        TELLib _oTELLib = new TELLib();

        UserPermissions _oUserPermissions = new UserPermissions();
        
        public frmAdvancePayments()
        {
            InitializeComponent();
            _oUserPermissions = _oUserPermissions.Refresh(_oUserPermissions, Utility.UserId);
        }


        public void ShowDialog(CSDJob oCSDJob)
        {
            this.Tag = oCSDJob;
            _oProductDetail = new ProductDetail();
            _oProductDetail.ProductID = oCSDJob.ProductID;
            _oProductDetail.Refresh();

            txtAdvanceNo.Text = _oProductDetail.ProductName + " [" + _oProductDetail.ProductCode + "]";
            txtJobNumber.Text = oCSDJob.JobNo;
            txtContactNo.Text = oCSDJob.MobileNo;
            txtCustomerName.Text = oCSDJob.CustomerName;
            txtCustomerName.Text = oCSDJob.CustomerCode;
            this.ShowDialog();
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
            //ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)lvwConsumerTran.SelectedItems[0].Tag;
            //if (oConsumerBalanceTran.TranType == Dictionary.ConsumerAdvancePaymentTranType.Adjust)
            //{
            //    MessageBox.Show("You can update only Advance Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (oConsumerBalanceTran.IsUpload == (int)Dictionary.YesOrNoStatus.YES)
            //{
            //    MessageBox.Show("You can update only Create Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //frmAdvancePayment oForm = new frmAdvancePayment();
            //oForm.ShowDialog(oConsumerBalanceTran);
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
            //_oTELLib = new TELLib();
            //_oSystemInfo=new SystemInfo();
            //_oSystemInfo.Refresh();
            _oConsumerBalanceTrans = new ConsumerBalanceTrans();
            ////DBController.Instance.OpenNewConnection();
            ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            _oConsumerBalanceTrans.RefreshTranCSD(oConsumerBalanceTran.AdvancePaymentNo);

            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptAdvancePayment));
            oReport.SetDataSource(_oConsumerBalanceTrans);

            //oReport.SetParameterValue("Date", Convert.ToDateTime(_oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
            //oReport.SetParameterValue("Outlet", _oSystemInfo.Shortcode);
            //oReport.SetParameterValue("OutletName", _oSystemInfo.WarehouseName);
            //oReport.SetParameterValue("OutletAddress", _oSystemInfo.WarehouseAddress);
            //oReport.SetParameterValue("OutletMobileNo", _oSystemInfo.WarehouseCellNo);

            oReport.SetParameterValue("CompanyInfo", Utility.CompanyName);
            oReport.SetParameterValue("ReportName", "Customer Advance");
            oReport.SetParameterValue("Balance", _oTELLib.TakaFormat(oConsumerBalanceTran.Balance));
            oReport.SetParameterValue("BalanceInWord", _oTELLib.TakaWords(oConsumerBalanceTran.Balance));

            oReport.SetParameterValue("ConsumerName", oConsumerBalanceTran.ConsumerName);
            oReport.SetParameterValue("AdvanceStatus", oConsumerBalanceTran.AdvanceStatus);
            oReport.SetParameterValue("Address", oConsumerBalanceTran.Address);
            oReport.SetParameterValue("ContactNo", oConsumerBalanceTran.ContactNo);
            oReport.SetParameterValue("PrintBy", Utility.UserFullname);

            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void frmAdvancePayments_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbBrandType.SelectedIndex = 0;

            int nCount = 0;
            cmbBrandType.Enabled = false;
            foreach (UserPermission oUserPermission in _oUserPermissions)
            {
                if (oUserPermission.UserPermissions == "M34.28.1")
                {
                    cmbBrandType.SelectedIndex = 1;
                    nCount = nCount + 1;
                }
                if (oUserPermission.UserPermissions == "M34.28.2")
                {
                    cmbBrandType.SelectedIndex = 2;
                    nCount = nCount + 1;
                }
                if(nCount>1)
                {
                    cmbBrandType.SelectedIndex = 0;
                    cmbBrandType.Enabled = true;
                    nCount = 0;
                }
            }
                //DataLoad();
                //ComboLoad();
            }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoad()
        {
            bool isCreateDateRangeChecked = false;
            if (chkEnableDisableCreateDateRange.Checked)
            {
                isCreateDateRangeChecked = true;

                dtCreateFromDate.Value= dtCreateFromDate.Value.AddDays(1);
            }

            _oTELLib = new TELLib();
            _oConsumerBalanceTrans = new ConsumerBalanceTrans();
            lvwConsumerBalance.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oConsumerBalanceTrans.RefreshCSD(cmbBrandType.Text,isCreateDateRangeChecked, dtCreateFromDate.Value.Date, dtCreateToDate.Value.AddDays(1).Date,txtJobNumber.Text.Trim(), txtAdvanceNo.Text.Trim(), txtCustomerName.Text.Trim(),txtContactNo.Text.Trim());
            //this.Text = "Total  " + "[" + _oConsumerBalanceTrans.Count + "]";

            foreach (ConsumerBalanceTran oConsumerBalanceTran in _oConsumerBalanceTrans)
            {
                ListViewItem oItem = lvwConsumerBalance.Items.Add(oConsumerBalanceTran.JobNo);
                oItem.SubItems.Add(oConsumerBalanceTran.AdvancePaymentNo);
                oItem.SubItems.Add(oConsumerBalanceTran.ConsumerName);
                oItem.SubItems.Add(oConsumerBalanceTran.ContactNo);
                oItem.SubItems.Add(oConsumerBalanceTran.Address);
                oItem.SubItems.Add(oConsumerBalanceTran.PaymentModeName);
                oItem.SubItems.Add(_oTELLib.TakaFormat(oConsumerBalanceTran.ReceiveAmount).ToString());
                oItem.SubItems.Add(oConsumerBalanceTran.InstrumentDate.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oConsumerBalanceTran.AdjustAmount).ToString());
                if (oConsumerBalanceTran.AdvanceStatus == "Adjust")
                {
                    oItem.SubItems.Add(oConsumerBalanceTran.UpdateDate.ToString());
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(oConsumerBalanceTran.AdvanceStatus.ToString());
                //oItem.SubItems.Add(oConsumerBalanceTran.ProductName);

                oItem.Tag = oConsumerBalanceTran;
            }
        }
        private void DataLoadTran(int nConsumerID, int nCustomerID)
        {
            //_oTELLib = new TELLib();
            //_oConsumerBalanceTrans = new ConsumerBalanceTrans();
            //lvwConsumerTran.Items.Clear();
            //DBController.Instance.OpenNewConnection();
            //_oConsumerBalanceTrans.RefreshTran(nConsumerID, nCustomerID);
            //this.Text = "Total  " + "[" + _oConsumerBalanceTrans.Count + "]";

            //foreach (ConsumerBalanceTran oConsumerBalanceTranDetail in _oConsumerBalanceTrans)
            //{
            //    ListViewItem oItem = lvwConsumerTran.Items.Add(Convert.ToDateTime(oConsumerBalanceTranDetail.CreateDate).ToString("dd-MMM-yyyy"));

            //    oItem.SubItems.Add(oConsumerBalanceTranDetail.TranType.ToString());
            //    oItem.SubItems.Add(oConsumerBalanceTranDetail.AdvancePaymentNo);
            //    oItem.SubItems.Add(oConsumerBalanceTranDetail.InvoiceNo);
            //    oItem.SubItems.Add(_oTELLib.TakaFormat(oConsumerBalanceTranDetail.Amount).ToString());
            //    oItem.SubItems.Add(oConsumerBalanceTranDetail.TranSide.ToString());
            //    oItem.SubItems.Add(oConsumerBalanceTranDetail.PaymentModeName.ToString());
            //    oItem.SubItems.Add(oConsumerBalanceTranDetail.ProductName);

            //    oItem.Tag = oConsumerBalanceTranDetail;
            //}
        }


        private void lvwConsumerBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            //DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }
        private void lvwConsumerBalance_KeyDown(object sender, KeyEventArgs e)
        {
            //ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            //DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }
        private void lvwConsumerBalance_KeyUp(object sender, KeyEventArgs e)
        {
            //ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            //DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }
        private void lvwConsumerBalance_MouseClick(object sender, MouseEventArgs e)
        {
            //ConsumerBalanceTran oConsumerBalanceTranDetail = (ConsumerBalanceTran)lvwConsumerBalance.SelectedItems[0].Tag;
            //DataLoadTran(oConsumerBalanceTranDetail.ConsumerID, oConsumerBalanceTranDetail.CustomerID);
        }

        private void chkEnableDisableCreateDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableCreateDateRange.Checked)
            {
                lblCreateDate.Enabled = false;
                dtCreateFromDate.Enabled = false;
                dtCreateToDate.Enabled = false;
            }
            else
            {
                lblCreateDate.Enabled = true;
                dtCreateFromDate.Enabled = true;
                dtCreateToDate.Enabled = true;
            }
        }
    }
}