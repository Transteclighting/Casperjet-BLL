using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.Library;


namespace CJ.POS.RT
{
    public partial class frmOutletAttendanceFilter : Form
    {
        OutletAttendanceInfos _oOutletAttendanceInfos;
        TELLib _oLib = new TELLib();

        public frmOutletAttendanceFilter()
        {
            InitializeComponent();
            dtFromDate.Value = _oLib.ServerDateTime().Date;
            dtToDate.Value = _oLib.ServerDateTime().Date;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            _oOutletAttendanceInfos = new OutletAttendanceInfos();
            DBController.Instance.OpenNewConnection();
            SystemInfo oInfo = new SystemInfo();
            oInfo.RefreshPOSRT();

            _oOutletAttendanceInfos.RefreshDataReportRT(txtCode.Text,txtName.Text,dtFromDate.Value.Date, dtToDate.Value.Date, oInfo.WarehouseID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptHRAttendanceOutlet));
            doc.SetDataSource(_oOutletAttendanceInfos);

            doc.SetParameterValue("Outlet", oInfo.WarehouseName);
            doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("User Name", Utility.Username);
            doc.SetParameterValue("PrintDate", DateTime.Now.ToString("dd-MMM-yyyy : hh:mm tt"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
    }
}