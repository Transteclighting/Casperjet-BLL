using System;
using System.Threading;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Duty;
using CJ.Class.HR;
using CJ.Class.Library;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Report.POS;
using CJ.Class.POS;

namespace CJ.Win.CSD.Store
{
    public partial class frmSparePartCashSales : Form
    {
        SparePartsRs _oSparePartsRs;
        SparePartsR _oSparePartsR;
        int _nTranId = 0;
        public frmSparePartCashSales()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DataLoadControl()
        {
            SparePartsRs oSparePartsRs = new SparePartsRs();
            lvwCaseSales.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSparePartsRs.GetCashSale(dtFromDate.Value.Date, dtToDate.Value.Date);

            this.Text = "Parts Receive " + "[" + oSparePartsRs.Count + "]";
            foreach (SparePartsR oSparePartsR in oSparePartsRs)
            {
                ListViewItem oItem = lvwCaseSales.Items.Add(oSparePartsR.Tranno);
                oItem.SubItems.Add(oSparePartsR.TranDate.ToString());
                oItem.SubItems.Add(oSparePartsR.CashMemoNo);
                oItem.SubItems.Add(oSparePartsR.UserName);
                oItem.SubItems.Add(oSparePartsR.Remarks);

                oItem.Tag = oSparePartsR;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSparePartCashSale oForm = new frmSparePartCashSale();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmSparePartCashSales_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvwCaseSales.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select Item to Print", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cursor = Cursors.WaitCursor;
            SparePartsR oSparePartsR = (SparePartsR)lvwCaseSales.SelectedItems[0].Tag;
            SparePartsRs sparePartsRs = new SparePartsRs();
            sparePartsRs.PrintByCashSale(oSparePartsR.SPtranID);
            rptSparePartCashSales oReport = new rptSparePartCashSales();

            oReport.SetDataSource(sparePartsRs);
            oReport.SetParameterValue("TranNo", oSparePartsR.Tranno);
            oReport.SetParameterValue("TranDate", oSparePartsR.TranDate.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("CashMemoNo", oSparePartsR.CashMemoNo);
            oReport.SetParameterValue("Remarks", oSparePartsR.Remarks);
            oReport.SetParameterValue("CompanyName", Utility.CompanyName);
            oReport.SetParameterValue("PrintBy", Utility.UserFullname);
            try
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                oReport.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                oReport.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            catch
            {
                oReport.SetParameterValue("ServiceCenterName", "Customer Service Department");
                oReport.SetParameterValue("ServiceCenterAddress", "House:22, Road:4, Block:F, Banani, Dhaka-1213");
            }
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            Cursor = Cursors.Default;
        }

        private void btnVatPrint_Click(object sender, EventArgs e)
        {
            
            if (lvwCaseSales.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select Item to Print", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cursor = Cursors.WaitCursor;
            bool hasVat = PrintVatChallan();
            if (!hasVat)
            {
                MessageBox.Show(@"Do not have vat for this sale", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor = Cursors.Default;

        }
        
        private bool PrintVatChallan()
        {
            SparePartsR oSparePartsR = (SparePartsR)lvwCaseSales.SelectedItems[0].Tag;
            
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(oSparePartsR.SPtranID.ToString(), oSparePartsR.Tranno, (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
            SystemInfo _oSystemInfo = new SystemInfo();
            _oSystemInfo.RefreshHO();

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                oDutyTran.GetVATReportForService();

                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                    doc.SetDataSource(oDutyTran);
                    doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                    doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                    doc.SetParameterValue("VehicleNumber", "");
                    doc.SetParameterValue("BINNo", "");
                    doc.SetParameterValue("CustomerName", oSparePartsR.CustomerName);
                    doc.SetParameterValue("CustomerAddress", oSparePartsR.CustomerAddress);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanAddress", oSparePartsR.CustomerAddress);
                    TELLib oTakaFormet = new TELLib();
                    doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                    doc.SetParameterValue("Comment", "");
                    doc.SetParameterValue("IsBLL", false);
                    doc.SetParameterValue("BENo", "");
                    doc.SetParameterValue("RefJobNo", "Ref Tran#" + oSparePartsR.Tranno + ", Date" + oSparePartsR.TranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("Copy", "1st Copy");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    //doc.SetParameterValue("Copy", "2nd Copy");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    //doc.SetParameterValue("Copy", "3rd Copy");
                    //doc.PrintToPrinter(1, true, 1, 1);

                    frmPrintPreview oFrom = new frmPrintPreview();
                    oFrom.ShowDialog(doc);
                }
            }

            return oDutyTranList.Count>0;
        }

    }
}