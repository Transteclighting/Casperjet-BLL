using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;


namespace CJ.Win.Inventory
{
    public partial class frmStockLedger : Form
    {
        SystemInfo oSystemInfo;
        RptStockLedgerDetails _oRptStockLedgerDetails;
        Warehouses oWarehouses;
        Warehouses oParentWarehouses;
        public frmStockLedger()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please Enter Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlProduct1.txtCode.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();

            Report();


            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {

            if (cmbWarehouse.SelectedIndex == 0)
            {
                return;
            }
            _oRptStockLedgerDetails = new RptStockLedgerDetails();
            int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForHO(dtFromDate.Value, ctlProduct1.SelectedSerarchProduct.ProductID, oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID);
            _oRptStockLedgerDetails = new RptStockLedgerDetails();
            _oRptStockLedgerDetails.ProductStockLedgerForHO(dtFromDate.Value, dtToDate.Value, ctlProduct1.SelectedSerarchProduct.ProductID, nOpeningStock, oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.POS.rptStockLedger));
            doc.SetDataSource(_oRptStockLedgerDetails);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", cmbWarehouseParent.Text + "[" + cmbWarehouse.Text + "]");
            doc.SetParameterValue("OpeningStock", nOpeningStock.ToString());
            doc.SetParameterValue("ReportName", "Stock Ledger");
            doc.SetParameterValue("ProductCode", ctlProduct1.SelectedSerarchProduct.ProductCode);
            doc.SetParameterValue("ProductName", ctlProduct1.SelectedSerarchProduct.ProductName);
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void frmStockLedger_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbWarehouseParent.Items.Clear();
            oParentWarehouses = new Warehouses();
            oParentWarehouses.GetWarehouseParents();
            cmbWarehouseParent.Items.Add("<All>");
            foreach (Warehouse oParentWarehouse in oParentWarehouses)
            {
                cmbWarehouseParent.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbWarehouseParent.SelectedIndex = 0;


            dtFromDate.Value = DateTime.Now.Date;
            dtToDate.Value = DateTime.Now.Date;
            DBController.Instance.CloseConnection();
        }

        private void LoadCombo(int nWarehouseParentID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetStockByParent(nWarehouseParentID);
            cmbWarehouse.Items.Add("<All>");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = 0;
        }
        private void cmbWarehouseParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbWarehouseParent.SelectedIndex == 0)
            {
                oWarehouses = null;
                cmbWarehouse.Items.Clear();
                cmbWarehouse.Items.Add("<All>");
                cmbWarehouse.SelectedIndex = 0;
                return;
            }
            else
            {
                LoadCombo(oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
            }
        }
    }
}