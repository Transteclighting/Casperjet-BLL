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
    public partial class frmPaidJobForInterServiceHistory : Form
    {
        public PaidJobForInterService _oPaidJobForInterService;
        PaidJobForInterServiceHistorys oPaidJobForInterServiceHistorys;
        Utilities _oUtilitys;
        public frmPaidJobForInterServiceHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(PaidJobForInterService oPaidJobForInterService)
        {
            this.Tag = oPaidJobForInterService;
            //LoadCombos();

            lblContactNo.Text = oPaidJobForInterService.ContactNo.ToString();
            lblCustomerName.Text = oPaidJobForInterService.CustomerName;
            lblAddress.Text = oPaidJobForInterService.Address;
            lblPaidJobID.Text = oPaidJobForInterService.PaidJobID.ToString();

            DataLoadControl();
            //ctlProduct1.txtCode.Text = oReplace.IssueProductID;

            this.ShowDialog();
        }

     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            _oPaidJobForInterService = (PaidJobForInterService)this.Tag;
            oPaidJobForInterServiceHistorys = new PaidJobForInterServiceHistorys();
            oPaidJobForInterServiceHistorys.RefreshByID(_oPaidJobForInterService.PaidJobID);

            lvwPaidJobHistroy.Items.Clear();

            foreach (PaidJobForInterServiceHistory oPaidJobForInterServiceHistory in oPaidJobForInterServiceHistorys)
            {
                ListViewItem oItem = lvwPaidJobHistroy.Items.Add(oPaidJobForInterServiceHistory.StatusDate.ToString());

                if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.Assign)
                {
                    oItem.SubItems.Add("Assign");
                }
                else if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.Cancel)
                {
                    oItem.SubItems.Add("Cancel");
                }
                else if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.ConvertToCSDJob)
                {
                    oItem.SubItems.Add("ConvertToCSDJob");
                }
                else if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.ServiceProvided)
                {
                    oItem.SubItems.Add("ServiceProvided");
                }
                else if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.Pending)
                {
                    oItem.SubItems.Add("Pending");
                }
                else if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.Receive)
                {
                    oItem.SubItems.Add("Receive");
                }
                else if (oPaidJobForInterServiceHistory.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress)
                {
                    oItem.SubItems.Add("WorkInProgress");
                }
                else 
                {
                    oItem.SubItems.Add("Communication");
                }


                oItem.SubItems.Add(oPaidJobForInterServiceHistory.User.Username.ToString());
                oItem.SubItems.Add(oPaidJobForInterServiceHistory.Remarks.ToString());
                oItem.Tag = oPaidJobForInterServiceHistory;
            }
            //setListViewRowColour();
        }

        private void frmReplaceHistory_Load(object sender, EventArgs e)
        {
            
        }

        //private void btnReplaceHistoryPrint_Click(object sender, EventArgs e)
        //{

        //    _oReplace = (Replace)this.Tag;
        //    oReplaceHistorys = new ReplaceHistorys();
        //    oReplaceHistorys.RefreshByID(_oReplace.ReplaceID);

        //    //lvwReplaceHistroy.Items.Clear();


        //    //Replace oReplace = (Replace)lvwReplaceHistroy.SelectedItems[0].Tag;
        //    //Replace oReplace = new Replace();
            
        //    rptReplaceHistory oReport = new rptReplaceHistory();
        //    oReport.SetDataSource(oReplaceHistorys);
        //    oReport.SetParameterValue("RepID", _oReplace.ReplaceID);
        //    oReport.SetParameterValue("Name", _oReplace.ReplaceJobFromCassandra.CustomerName);
        //    oReport.SetParameterValue("Address", _oReplace.ReplaceJobFromCassandra.FirstAddress);
        //    //oITRequisition.Employee.ReadDB = true;
        //    oReport.SetParameterValue("ContactNo", _oReplace.ReplaceJobFromCassandra.Mobile);
        //    oReport.SetParameterValue("JobNo", _oReplace.ReplaceJobFromCassandra.JobNo);
        //    //oReport.SetParameterValue("RaiseDate", oReplace.CreateDate.ToString());
        //    oReport.SetParameterValue("Serial", _oReplace.ReplaceJobFromCassandra.SerialNo.ToString());
        //    oReport.SetParameterValue("PNamee", _oReplace.ReplaceJobFromCassandra.ProductName);
        //    oReport.SetParameterValue("PCodee", _oReplace.ReplaceJobFromCassandra.ProductCode);
        //    //oReport.SetParameterValue("CusComplain", oReplace.FaultDescription);
        //    oReport.SetParameterValue("InvoiceNo", _oReplace.InvoiceCashMemo.ToString());
        //    oReport.SetParameterValue("DOP", _oReplace.DateOfPurchase.ToString());
        //    oReport.SetParameterValue("JCD", _oReplace.ReplaceJobFromCassandra.JobCreationDate.ToString());
        //    oReport.SetParameterValue("PC", _oReplace.Product.ProductCode);
        //    oReport.SetParameterValue("PN", _oReplace.Product.ProductName);
        //    oReport.SetParameterValue("CusComplain", _oReplace.FaultDescription);
        //    oReport.SetParameterValue("RPBarcode", _oReplace.IssueProductBarcode.ToString());
        //    oReport.SetParameterValue("WarrantyPeriod", _oReplace.FullWarrantyPeriod.ToString());
        //    oReport.SetParameterValue("ActualFault", _oReplace.RemarksAcutalFault.ToString());
        //    oReport.SetParameterValue("Sources", _oReplace.Source.ToString());
        //    oReport.SetParameterValue("SourcesName", _oReplace.SourceName.ToString());
        //    oReport.SetParameterValue("RIssueDate", _oReplace.IssueDate.ToString());
        //    oReport.SetParameterValue("EDD", _oReplace.ApproxDeliveryDate.ToString());
        //    oReport.SetParameterValue("ADD", _oReplace.DeliveryDate.ToString());
        //    oReport.SetParameterValue("DelFrom", _oReplace.DeliveredFromWHName.ToString());
        //    oReport.SetParameterValue("MOD", _oReplace.ModeofDeliveryName.ToString());
        //    oReport.SetParameterValue("Courier", _oReplace.CourierFromCassandra.CourierServiceName.ToString());
        //    oReport.SetParameterValue("Consign#", _oReplace.ConsignmentNo.ToString());
        //    oReport.SetParameterValue("DeliverBy", _oReplace.Deliveredby.ToString());
        //    //doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
        //    oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());

        //    frmPrintPreview oForm = new frmPrintPreview();
        //    oForm.ShowDialog(oReport);
        //}
    }
}