using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win
{
    public partial class frmSPReturnToSuplieres : Form
    {
        SPTrans _oSPTrans;
        //int nSPTranID = 0;
        public frmSPReturnToSuplieres()
        {
            InitializeComponent();
        }

        private void frmSPReturnToSuplieres_Load(object sender, EventArgs e)
        {

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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

            _oSPTrans.RefreshForRTS(dtFrom, dtTo, txtRTSNo.Text.Trim(), 0);
            this.Text = "Spare Parts Return To Supplier | Total: " + "[" + _oSPTrans.Count + "]";
            lvwGRDList.Items.Clear();
            foreach (SPTran oSPTran in _oSPTrans)
            {
                ListViewItem oItem = lvwGRDList.Items.Add(oSPTran.TranNo);
                oItem.SubItems.Add(oSPTran.FromStoreName);
                oItem.SubItems.Add(oSPTran.SupplierName);
                oItem.SubItems.Add(oSPTran.CreateDate.ToShortDateString() + " " + oSPTran.CreateDate.ToShortTimeString());
                oItem.SubItems.Add(oSPTran.UserName);
                oItem.SubItems.Add(oSPTran.Remarks);
                oItem.Tag = oSPTran;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSPReturnToSuplier oForm = new frmSPReturnToSuplier();
            oForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReturnToSupplier();
        }
        private void PrintReturnToSupplier()
        {
            if (lvwGRDList.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select Item to Print","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            Cursor = Cursors.WaitCursor;
            SPTran oSPTran = (SPTran)lvwGRDList.SelectedItems[0].Tag;
            SPTrans oSPTrans = new SPTrans();
            oSPTrans.GetSpReturnToSupplier(oSPTran.SPTranID);
            rptReturnToSupplier oReport = new rptReturnToSupplier();

            List<CsdReturnToSupplier> aList = new List<CsdReturnToSupplier>();

            foreach (SPTran aSpTran in oSPTrans)
            {
                var aTran = new CsdReturnToSupplier
                {
                    Code = aSpTran.Code,
                    Name = aSpTran.Name,
                    Qty = aSpTran.Qty,
                    CostPrice = aSpTran.CostPrice,
                    SalePrice = aSpTran.SalePrice
                };
                aList.Add(aTran);
            }
            oReport.SetDataSource(aList);

            //oReport.SetDataSource(oSPTrans);
            oReport.SetParameterValue("ReturnDate", oSPTran.CreateDate.ToShortDateString());
            oReport.SetParameterValue("FromStore", oSPTran.FromStoreName);
            oReport.SetParameterValue("Supplier", oSPTran.SupplierName);
            oReport.SetParameterValue("RTSNo", oSPTran.TranNo);
            oReport.SetParameterValue("Remarks", oSPTran.Remarks);
            oReport.SetParameterValue("UserName", Utility.Username);
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
    }
}