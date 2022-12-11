using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;

namespace CJ.POS
{
    public partial class frmUnsoldDefectiveProductList : Form
    {

        UnsoldDefectiveProduct _oUnsoldDefectiveProduct;
        UnsoldDefectiveProducts _oUnsoldDefectiveProducts;
        SystemInfo oSystemInfo;
        public frmUnsoldDefectiveProductList()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e) 
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            ReportDataLoad();
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }

        private void Report()
        {
            //_oDailySalesReports = new DailySalesReports();

            //_oDailySalesReports.RefreshPOSSaleQtyNValue(dtFromDate.Value, dtToDate.Value, txtProductCode.Text.Trim(), txtProductName.Text.Trim());

            //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSSaleQtyNValue));
            //doc.SetDataSource(_oDailySalesReports);

            //doc.SetParameterValue("UserName", Utility.Username);
            //doc.SetParameterValue("CompanyName", Utility.CompanyName);
            //doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            //doc.SetParameterValue("ReportName", "Product Wise Sales Quantity and Value");
            //if (txtProductCode.Text.Trim() != "")
            //{
            //    doc.SetParameterValue("sProductCode", txtProductCode.Text.ToString());
            //}
            //else
            //{
            //    doc.SetParameterValue("sProductCode", "");
            //}
            //if (txtProductName.Text.Trim() != "")
            //{
            //    doc.SetParameterValue("sProductName", txtProductName.Text.ToString());
            //}
            //else
            //{
            //    doc.SetParameterValue("sProductName", "");
            //}
            //doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            //doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            //doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            //frmPrintPreview frmView;
            //frmView = new frmPrintPreview();
            //frmView.ShowDialog(doc);
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            cmbDefectiveType.Items.Clear();
            cmbDefectiveType.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
            cmbDefectiveType.SelectedIndex = 0;

            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.UnsouldDefectiveProductStatus)))
            {
                cmbstatus.Items.Add(Enum.GetName(typeof(Dictionary.UnsouldDefectiveProductStatus), GetEnum));
            }
            cmbstatus.SelectedIndex = 0;

            cmbStockStatus.Items.Clear();
            cmbStockStatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductSerialStatus)))
            {
                cmbStockStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProductSerialStatus), GetEnum));
            }
            cmbStockStatus.SelectedIndex = 0;

        }

        private void ReportDataLoad()
        {
            _oUnsoldDefectiveProducts = new UnsoldDefectiveProducts();

            int nStatus = 0;
            if (cmbstatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbstatus.SelectedIndex;
            }

            int nStockStatus = 0;
            if (cmbStockStatus.SelectedIndex == 0)
            {
                nStockStatus = -1;
            }
            else
            {
                nStockStatus = cmbStockStatus.SelectedIndex - 1;
            }
            bool IsCurrentDefective = false;
            if (chkIsCurrentDefective.Checked == true)
            {
                IsCurrentDefective = true;
            }
            else
            {
                IsCurrentDefective = false;
            }
            _oUnsoldDefectiveProducts.LoadDataForReport(txtDefectiveNo.Text.Trim(), txtProductSerial.Text.Trim(), nStatus, nStockStatus, cmbDefectiveType.SelectedIndex, IsCurrentDefective);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptUnsoldDefectiveProductList));
            doc.SetDataSource(_oUnsoldDefectiveProducts);

            doc.SetParameterValue("ReportName", "Unsold Defective Product List");
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUnsoldDefectiveProductList_Load(object sender, EventArgs e)
        {
            LoadCombos();

        }

        private void chkIsCurrentDefective_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
