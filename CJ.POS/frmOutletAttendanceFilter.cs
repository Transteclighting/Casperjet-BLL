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


namespace CJ.POS
{
    public partial class frmOutletAttendanceFilter : Form
    {
        OutletAttendanceInfos _oOutletAttendanceInfos;

        public frmOutletAttendanceFilter()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            _oOutletAttendanceInfos = new OutletAttendanceInfos();
            DBController.Instance.OpenNewConnection();
            SystemInfo oInfo = new SystemInfo();
            oInfo.Refresh();

            _oOutletAttendanceInfos.RefreshDataReport(txtCode.Text,txtName.Text,dtFromDate.Value.Date, dtToDate.Value.Date);

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