using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Class.Library;


namespace CJ.Win.CSD
{
    public partial class frmDailySalesCollection : Form
    {
        SPTrans _oSPTrans;
        TELLib _oTELLib;
        private JobLocations _jobLocations;
        public frmDailySalesCollection()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();       
        }
        private void Preview()
        {
            
            Cursor = Cursors.WaitCursor;
            int jobLocationId = -1;
            if (cmbServiceCenter.SelectedIndex > 0)
            {
                jobLocationId = _jobLocations[cmbServiceCenter.SelectedIndex - 1].JobLocationID;
            }

            _oTELLib = new TELLib();
            DBController.Instance.OpenNewConnection();

            
            CSDJobBills oCSDJobBills = new CSDJobBills();
            oCSDJobBills.RefreshByDate(dtFromDate.Value.Date, cmbBrandType.Text, jobLocationId);

            DsDailySalesCollection oDsDailySalesCollection = new DsDailySalesCollection();
            DsDailySalesCollection oJobBill = new DsDailySalesCollection();
            DsDailySalesCollection oSPCashSales = new DsDailySalesCollection();
            //DsDailySalesCollection oBillTotal = new DsDailySalesCollection();

            int count = 0;
            double directCash = 0;
            double directOther = 0;
            foreach (CSDJobBill oCSDJobBill in oCSDJobBills)
            {
                DsDailySalesCollection.JobBillRow oJobBillRow  = oJobBill.JobBill.NewJobBillRow();
                oJobBillRow.Sl = (++count).ToString();
                oJobBillRow.JobNo = oCSDJobBill.JobNo;
                oJobBillRow.ServiceCharge = oCSDJobBill.ActualSerCharge;
                oJobBillRow.MatarialChatge = oCSDJobBill.ActualMatCharge;
                oJobBillRow.InspectionCharge = oCSDJobBill.ActualInsCharge;
                oJobBillRow.TrasportationCharge = (oCSDJobBill.InTranportationCharge + oCSDJobBill.OutTranportationCharge);
                oJobBillRow.Other = oCSDJobBill.OtherCharge;
                oJobBillRow.NetCharge = oCSDJobBill.TotalBill;
                oJobBillRow.Discount = oCSDJobBill.TotalDiscount; //(oCSDJobBill.SCDiscount + oCSDJobBill.SPDiscount);
                oJobBillRow.ReceivedAmount = oCSDJobBill.ReceivedAmount;
                oJobBillRow.PreviousAmount = oCSDJobBill.PreviousReceiveAmount;
                //oJobBillRow.DueAmount = oCSDJobBill.TotalBill- (oCSDJobBill.PendingRecv + oCSDJobBill.PreviousReceiveAmount) - oCSDJobBill.TotalDiscount;
                oJobBillRow.DueAmount = oCSDJobBill.CurrentPayable - oCSDJobBill.AdjustAmount;
                oJobBillRow.Remarks = oCSDJobBill.Remarks;
                oJobBillRow.InstallationCharge = oCSDJobBill.ActualInstallationCharge;
                oJobBillRow.CurrentReceivable = oCSDJobBill.CurrentReceivable- oCSDJobBill.AdjustAmount;
                oJobBillRow.PendingRecv = oCSDJobBill.PendingRecv;
                oJobBillRow.TotalRecv = oCSDJobBill.PendingRecv+ oCSDJobBill.ReceivedAmount;
                if (oCSDJobBill.InstrumentType == 2)
                {
                    directCash += oCSDJobBill.ReceivedAmount;
                }
                else
                {
                    directOther += oCSDJobBill.ReceivedAmount;
                }
                oJobBillRow.AdvanceAmount = oCSDJobBill.AdvanceAmount;
                oJobBillRow.AdjustAmount = oCSDJobBill.AdjustAmount;
                oJobBill.JobBill.AddJobBillRow(oJobBillRow);
                oJobBill.AcceptChanges();
            }
            
            _oSPTrans = new SPTrans();
            _oSPTrans.GetSpSales(dtFromDate.Value.Date, jobLocationId);

             count = 0;
            double spareCash = 0;
            foreach (SPTran oSPTran in _oSPTrans)
            {
                spareCash += oSPTran.NetAmount;
                DsDailySalesCollection.SPCashSalesRow oSpCashSalesRow = oSPCashSales.SPCashSales.NewSPCashSalesRow();
                oSpCashSalesRow.SL = (++count).ToString();
                oSpCashSalesRow.CashMemo = oSPTran.CashMemoNo;
                oSpCashSalesRow.CustomerName = oSPTran.CustomerName;
                oSpCashSalesRow.Discount = oSPTran.DiscountAmt;
                oSpCashSalesRow.Remarks = oSPTran.Remarks;
                oSpCashSalesRow.NetCharge = oSPTran.NetAmount;
                oSpCashSalesRow.TotalSPCharge = oSPTran.TotalSpCharge;
                oSpCashSalesRow.OtherCharge = oSPTran.OtherCharge;
                oSPCashSales.SPCashSales.AddSPCashSalesRow(oSpCashSalesRow);
                oSPCashSales.AcceptChanges();
                
            }
            rptDailySalesCollection doc = new rptDailySalesCollection();
            oDsDailySalesCollection.Merge(oJobBill);
            oDsDailySalesCollection.Merge(oSPCashSales);
            oDsDailySalesCollection.AcceptChanges();
            doc.SetDataSource(oDsDailySalesCollection);

            //CSDJobBills oCSDJobBillTotals = new CSDJobBills();
            //oCSDJobBillTotals.GetTotalBill(dtFromDate.Value.Date, cmbBrandType.Text, jobLocationId);
            //double totalCash = 0; 
            //double totalOther = 0;
            //foreach(CSDJobBill oCSDJobBill in oCSDJobBillTotals)
            //{
            //    if (oCSDJobBill.PaymentType == "Spare")
            //    {
            //        //doc.SetParameterValue("SpareCash", oCSDJobBill.Cash);                    
            //    }
            //    else
            //    {
            //        //doc.SetParameterValue("DirectCash", oCSDJobBill.Cash);
            //        //doc.SetParameterValue("DirectOther", oCSDJobBill.Other);
            //        doc.SetParameterValue("TotalDirect", (oCSDJobBill.Cash + oCSDJobBill.Other));                    
            //    }
            //    totalCash += oCSDJobBill.Cash;
            //    totalOther += oCSDJobBill.Other;
            //}
            
            doc.SetParameterValue("SpareCash", spareCash);
            doc.SetParameterValue("DirectCash", directCash);
            doc.SetParameterValue("DirectOther", directOther);
            doc.SetParameterValue("TotalDirect", (directCash + directOther));

            doc.SetParameterValue("TotalCash", spareCash+ directCash);
            doc.SetParameterValue("TotalOther", directOther);
            doc.SetParameterValue("GrandTotal", (spareCash + directCash+ directOther));
            doc.SetParameterValue("TakaInWords", _oTELLib.TakaWords(spareCash + directCash + directOther));            
            doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToShortDateString());
            doc.SetParameterValue("PrintUser", Utility.Username);

            if(jobLocationId>0)
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = jobLocationId
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            else 
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "Banani HO, House-22, Road-4, Block-F,Dhaka - 1213");
            }
            

            var frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            Cursor = Cursors.Default;
        }

        private void frmDailySalesCollection_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            cmbBrandType.SelectedIndex = 0;

            _jobLocations = new JobLocations();
            _jobLocations.GetServiceCenters();
            cmbServiceCenter.Items.Clear();
            cmbServiceCenter.Items.Add("ALL");
            foreach (JobLocation aServiceCenter in _jobLocations)
            {
                cmbServiceCenter.Items.Add(aServiceCenter.JobLocationName);
            }
            cmbServiceCenter.SelectedIndex = 0;
        }
    }
}