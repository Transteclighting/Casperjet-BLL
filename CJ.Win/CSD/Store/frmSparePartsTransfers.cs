using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.Duty;
using CJ.Class.HR;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Report.POS;

namespace CJ.Win.CSD.Store
{
    public partial class frmSparePartsTransfers : Form
    {
        private SPTrans _oSPTrans;

        public frmSparePartsTransfers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSparePartsTransfers_Load(object sender, EventArgs e)
        {

        }

        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oSPTrans = new SPTrans();
            DBController.Instance.OpenNewConnection();
            DateTime dtFrom = dtFromDate.Value.Date;
            DateTime dtTo = dtToDate.Value.Date;
            if (chkDateRange.Checked)
            {
                dtFrom = Convert.ToDateTime("01-01-1990");
                dtTo = DateTime.Now;
            }

            _oSPTrans.RefreshForSPT(dtFrom, dtTo, txtRTSNo.Text.Trim(), 0);
            this.Text = "Spare Parts Transfer | Total: " + "[" + _oSPTrans.Count + "]";
            lvwGRDList.Items.Clear();
            foreach (SPTran oSPTran in _oSPTrans)
            {
                ListViewItem oItem = lvwGRDList.Items.Add(oSPTran.TranNo);
                oItem.SubItems.Add(oSPTran.FromStoreName);
                oItem.SubItems.Add(oSPTran.ToStoreName);
                oItem.SubItems.Add(oSPTran.CreateDate.ToShortDateString() + " " + oSPTran.CreateDate.ToShortTimeString());
                oItem.SubItems.Add(oSPTran.UserName);
                oItem.SubItems.Add(oSPTran.Remarks);
                oItem.Tag = oSPTran;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSparePartsTransfer oForm = new frmSparePartsTransfer();
            oForm.ShowDialog();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void PrintSparePartsTransfer()
        {
            if (lvwGRDList.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select Item to Print", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            SPTran oSpTran = (SPTran) lvwGRDList.SelectedItems[0].Tag;
            SPTrans oSpTrans = new SPTrans();
            oSpTrans.GetSpReturnToSupplier(oSpTran.SPTranID);
            rptSparePartsTransfer oReport = new rptSparePartsTransfer();

            List<CsdReturnToSupplier> aList = (
                from SPTran aSpTran in oSpTrans
                select new CsdReturnToSupplier
                {
                    Code = aSpTran.Code,
                    Name = aSpTran.Name,
                    Qty = aSpTran.Qty,
                    CostPrice = aSpTran.CostPrice,
                    SalePrice = aSpTran.SalePrice
                }).ToList();

            oReport.SetDataSource(aList);
            //oReport.SetDataSource(oSPTrans);
            oReport.SetParameterValue("FromStore", oSpTran.FromStoreName);
            oReport.SetParameterValue("ToStore", oSpTran.ToStoreName);
            oReport.SetParameterValue("UserName", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oReport.SetParameterValue("SPTNo", oSpTran.TranNo);
            oReport.SetParameterValue("Remarks", oSpTran.Remarks);
            oReport.SetParameterValue("TransferDate", oSpTran.CreateDate.ToShortDateString());
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
            oFrom.ShowDialog(oReport);
            Cursor = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintSparePartsTransfer();
        }


        private void chkDateRange_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDateRange.Checked)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }

        private void btnVATPrint_Click(object sender, EventArgs e)
        {
            if (lvwGRDList.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select Item to Print", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            PrintVat63();
           
        }

        private void PrintVat63()
        {
            SPTran oSpTran = (SPTran)lvwGRDList.SelectedItems[0].Tag;

            

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(oSpTran.SPTranID.ToString(), oSpTran.TranNo, oSpTran.FromStoreID);
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();

            if (oDutyTranList.Count <= 0)
            {
                MessageBox.Show(@"Do not have vat for this transfer", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                POSRequisition _oPosRequisition = new POSRequisition();
                _oPosRequisition.RefreshForCsd(oSpTran.SPTranID, oDutyTran.DutyTranID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65));
                oReport.SetDataSource(_oPosRequisition);
                oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());

                oReport.SetParameterValue("FromWHName", _oPosRequisition.FromWHName);
                oReport.SetParameterValue("FromWHAddress", _oPosRequisition.FromWHAddress);
                oReport.SetParameterValue("ToWHName", _oPosRequisition.ToWHName);
                oReport.SetParameterValue("ToWHAddress", _oPosRequisition.ToWHAddress);
                oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail??string.Empty);
                frmPrintPreview oFrom = new frmPrintPreview();
                oFrom.ShowDialog(oReport);
            }
                
                Cursor = Cursors.Default;
            
        }
    }
}
