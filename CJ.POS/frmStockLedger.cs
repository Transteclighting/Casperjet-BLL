using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;


namespace CJ.POS
{
    public partial class frmStockLedger : Form
    {
        SystemInfo oSystemInfo;
        RptStockLedgerDetails _oRptStockLedgerDetails;
        int _nType = 0;
        public frmStockLedger(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (ctlProduct1.txtDescription.Text=="")
            {
                MessageBox.Show("Please Enter Product", "Info", MessageBoxButtons.OK,  MessageBoxIcon.Information);
                ctlProduct1.txtCode.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            if (_nType == 0)
            {
                Report();
            }
            else
            {
                ReportNewVat();
            }
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {

            _oRptStockLedgerDetails = new RptStockLedgerDetails();
            int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForPOS(dtFromDate.Value, ctlProduct1.SelectedSerarchProduct.ProductID, oSystemInfo.WarehouseID);

            _oRptStockLedgerDetails = new RptStockLedgerDetails();

            _oRptStockLedgerDetails.ProductStockLedgerForPOS(dtFromDate.Value, dtToDate.Value, ctlProduct1.SelectedSerarchProduct.ProductID, nOpeningStock, oSystemInfo.WarehouseID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.POS.rptStockLedger));
            doc.SetDataSource(_oRptStockLedgerDetails);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName + "[" + oSystemInfo.WarehouseCode + "]");
            doc.SetParameterValue("OpeningStock", nOpeningStock.ToString());
            doc.SetParameterValue("ReportName", "Stock Ledger");
            doc.SetParameterValue("ProductCode", ctlProduct1.SelectedSerarchProduct.ProductCode);
            doc.SetParameterValue("ProductName", ctlProduct1.SelectedSerarchProduct.ProductName);
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        private void ReportNewVat()
        {

            _oRptStockLedgerDetails = new RptStockLedgerDetails();
            int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForPOS(dtFromDate.Value, ctlProduct1.SelectedSerarchProduct.ProductID, oSystemInfo.WarehouseID);

            _oRptStockLedgerDetails = new RptStockLedgerDetails();

            _oRptStockLedgerDetails.ProductStockLedgerForPOSNewVat(dtFromDate.Value, dtToDate.Value, ctlProduct1.SelectedSerarchProduct.ProductID, nOpeningStock, oSystemInfo.WarehouseID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.POS.rptStockLedgerforNewVat));
            doc.SetDataSource(_oRptStockLedgerDetails);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName + "[" + oSystemInfo.WarehouseCode + "]");
            doc.SetParameterValue("OpeningStock", nOpeningStock.ToString());
            doc.SetParameterValue("ReportName", "Stock Ledger");
            doc.SetParameterValue("ProductCode", ctlProduct1.SelectedSerarchProduct.ProductCode);
            doc.SetParameterValue("ProductName", ctlProduct1.SelectedSerarchProduct.ProductName);
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void frmStockLedger_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            dtFromDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            dtToDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            DBController.Instance.CloseConnection();
        }

    }
}