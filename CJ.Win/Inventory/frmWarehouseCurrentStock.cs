using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Report;
using CJ.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Inventory
{
    public partial class frmWarehouseCurrentStock : Form
    {
        SystemInfo oSystemInfo;
        rptWarehouseCurrentStocks _oRptWarehouseStockReport;
        Warehouses oWarehouses;
        Warehouses oParentWarehouses;
        public frmWarehouseCurrentStock()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbWarehouseParent.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a parent warehouse", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbWarehouseParent.Focus();
                return;
            }
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
            _oRptWarehouseStockReport = new rptWarehouseCurrentStocks();

            int whParentId = oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID;
            int? whId=null;
            if (cmbWarehouse.SelectedIndex > 0)
            {
                whId = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            }
            int productId = ctlProduct1.SelectedSerarchProduct.ProductID;
            _oRptWarehouseStockReport.Refresh(productId, whParentId, whId);
            //, cmbWarehouseParent , ,
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.POS.rptWarehouseCurrentStock));
            doc.SetDataSource(_oRptWarehouseStockReport);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", cmbWarehouseParent.Text);
            doc.SetParameterValue("ReportName", "Current Stock (Wherehouse wise)");
            doc.SetParameterValue("ProductCode", ctlProduct1.SelectedSerarchProduct.ProductCode);
            doc.SetParameterValue("ProductName", ctlProduct1.SelectedSerarchProduct.ProductName);
            doc.SetParameterValue("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void LoadCombo(int nWarehouseParentID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetStockByParent(nWarehouseParentID);
            cmbWarehouse.Items.Add("--All--");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = 0;
        }
        private void cmbWarehouseParent_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbWarehouseParent.SelectedIndex == 0)
            {
                oWarehouses = null;
                cmbWarehouse.Items.Clear();
                cmbWarehouse.Items.Add("--All--");
                cmbWarehouse.SelectedIndex = 0;
                return;
            }
            else
            {
                LoadCombo(oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
            }
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmWarehouseCurrentStock_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbWarehouseParent.Items.Clear();
            oParentWarehouses = new Warehouses();
            oParentWarehouses.GetWarehouseParents();
            cmbWarehouseParent.Items.Add("--Select--");
            foreach (Warehouse oParentWarehouse in oParentWarehouses)
            {
                cmbWarehouseParent.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbWarehouseParent.SelectedIndex = 0;
            DBController.Instance.CloseConnection();
        }
    }
}
