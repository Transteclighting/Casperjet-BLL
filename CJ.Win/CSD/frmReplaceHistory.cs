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
    public partial class frmReplaceHistory : Form
    {
        public Replace _oReplace;
        ReplaceHistorys oReplaceHistorys;
        Utilities _oUtilitys;
        public frmReplaceHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(Replace oReplace)
        {
            this.Tag = oReplace;
            //LoadCombos();

            lblReplaceID.Text = oReplace.ReplaceID.ToString();
            lblJobNo.Text = oReplace.ReplaceJobFromCassandra.JobNo;
            lblCustomerName.Text = oReplace.ReplaceJobFromCassandra.CustomerName.ToString();
            lblContactNo.Text = oReplace.ReplaceJobFromCassandra.Mobile.ToString();

            DataLoadControl();
            //ctlProduct1.txtCode.Text = oReplace.IssueProductID;

            this.ShowDialog();
        }

        //private bool validateUIInput()
        //{
        //    #region Input Information Validation


        //    if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text == "")
        //    {
        //        MessageBox.Show("Please Select a Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        ctlProduct1.Focus();
        //        return false;
        //    }
        //    if (ctlProduct1.SelectedSerarchProduct == null)
        //    {
        //        MessageBox.Show("Please enter a Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }


        //    #endregion

        //    return true;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            //Utility oUtility = _oUtilitys[cmbStatus.SelectedIndex];
            //_nStatus = oUtility.SatusId;
            //Replaces oReplaces = new Replaces();
            _oReplace = (Replace)this.Tag;
            oReplaceHistorys = new ReplaceHistorys();
            oReplaceHistorys.RefreshByID(_oReplace.ReplaceID);

            lvwReplaceHistroy.Items.Clear();

            foreach (ReplaceHistory oReplaceHistory in oReplaceHistorys)
            {
                ListViewItem oItem = lvwReplaceHistroy.Items.Add(oReplaceHistory.StatusDate.ToString());

                if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.Approve)
                {
                    oItem.SubItems.Add("Approve");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.Cancel)
                {
                    oItem.SubItems.Add("Cancel");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.Delivered)
                {
                    oItem.SubItems.Add("Delivered");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.DepositToLog)
                {
                    oItem.SubItems.Add("DepositToLog");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.HappyCall)
                {
                    oItem.SubItems.Add("HappyCall");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.InformToCustomer)
                {
                    oItem.SubItems.Add("InformToCustomer");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.IssueFromLog)
                {
                    oItem.SubItems.Add("IssueFromLog");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.Raise)
                {
                    oItem.SubItems.Add("Raise");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.PaperAcknowledge)
                {
                    oItem.SubItems.Add("PaperAcknowledge");
                }
                else if (oReplaceHistory.Status == (int)Dictionary.ReplaceStatusCriteria.ReceiveAtCSD)
                {
                    oItem.SubItems.Add("ReceiveAtCSD");
                }
                else
                {
                    oItem.SubItems.Add("SentToCSD");
                }
                
                oItem.SubItems.Add(oReplaceHistory.User.Username.ToString());
                oItem.SubItems.Add(oReplaceHistory.Remarks.ToString());
                oItem.Tag = oReplaceHistory;
            }
            //setListViewRowColour();
        }

        private void frmReplaceHistory_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReplaceHistoryPrint_Click(object sender, EventArgs e)
        {

            _oReplace = (Replace)this.Tag;
            oReplaceHistorys = new ReplaceHistorys();
            oReplaceHistorys.RefreshByID(_oReplace.ReplaceID);

            //lvwReplaceHistroy.Items.Clear();


            //Replace oReplace = (Replace)lvwReplaceHistroy.SelectedItems[0].Tag;
            //Replace oReplace = new Replace();
            
            rptReplaceHistory oReport = new rptReplaceHistory();
            oReport.SetDataSource(oReplaceHistorys);
            oReport.SetParameterValue("RepID", _oReplace.ReplaceID);
            oReport.SetParameterValue("Name", _oReplace.ReplaceJobFromCassandra.CustomerName);
            oReport.SetParameterValue("Address", _oReplace.ReplaceJobFromCassandra.FirstAddress);
            //oITRequisition.Employee.ReadDB = true;
            oReport.SetParameterValue("ContactNo", _oReplace.ReplaceJobFromCassandra.Mobile);
            oReport.SetParameterValue("JobNo", _oReplace.ReplaceJobFromCassandra.JobNo);
            //oReport.SetParameterValue("RaiseDate", oReplace.CreateDate.ToString());
            oReport.SetParameterValue("Serial", _oReplace.ReplaceJobFromCassandra.SerialNo.ToString());
            oReport.SetParameterValue("PNamee", _oReplace.ReplaceJobFromCassandra.ProductName);
            oReport.SetParameterValue("PCodee", _oReplace.ReplaceJobFromCassandra.ProductCode);
            //oReport.SetParameterValue("CusComplain", oReplace.FaultDescription);
            oReport.SetParameterValue("InvoiceNo", _oReplace.InvoiceCashMemo.ToString());
            oReport.SetParameterValue("DOP", _oReplace.DateOfPurchase.ToString());
            oReport.SetParameterValue("JCD", _oReplace.ReplaceJobFromCassandra.JobCreationDate.ToString());
            oReport.SetParameterValue("PC", _oReplace.Product.ProductCode);
            oReport.SetParameterValue("PN", _oReplace.Product.ProductName);
            oReport.SetParameterValue("CusComplain", _oReplace.FaultDescription);
            oReport.SetParameterValue("RPBarcode", _oReplace.IssueProductBarcode.ToString());
            oReport.SetParameterValue("WarrantyPeriod", _oReplace.FullWarrantyPeriod.ToString());
            oReport.SetParameterValue("ActualFault", _oReplace.RemarksAcutalFault.ToString());
            oReport.SetParameterValue("Sources", _oReplace.Source.ToString());
            oReport.SetParameterValue("SourcesName", _oReplace.SourceName.ToString());
            oReport.SetParameterValue("RIssueDate", _oReplace.IssueDate.ToString());
            oReport.SetParameterValue("EDD", _oReplace.ApproxDeliveryDate.ToString());
            oReport.SetParameterValue("ADD", _oReplace.DeliveryDate.ToString());
            oReport.SetParameterValue("DelFrom", _oReplace.DeliveredFromWHName.ToString());
            oReport.SetParameterValue("MOD", _oReplace.ModeofDeliveryName.ToString());
            oReport.SetParameterValue("Courier", _oReplace.CourierFromCassandra.CourierServiceName.ToString());
            oReport.SetParameterValue("Consign#", _oReplace.ConsignmentNo.ToString());
            oReport.SetParameterValue("DeliverBy", _oReplace.Deliveredby.ToString());
            //doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());
            oReport.SetParameterValue("REDD", _oReplace.EDD1.ToString());

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
        }
    }
}