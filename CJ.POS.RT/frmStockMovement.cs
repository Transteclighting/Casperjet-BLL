// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 12, 2015
// Time : 07:34 PM
// Description: Stock Movement Report for POS
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;


namespace CJ.POS.RT
{
    public partial class frmStockMovement : Form
    {
        StockMovements _oStockMovements;
        //SystemInfo oSystemInfo;
        TELLib _oTELLib;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        Brands _oBrand;
        int nMAGID = 0;
        int nASGID = 0;
        int nAGID = 0;
        int nBrandID = 0;



        public frmStockMovement()
        {
            InitializeComponent();
        }

        private void frmStockMovement_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            LoadCombos();
            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();
            _oTELLib = new TELLib();
            dtFromDate.Value = Convert.ToDateTime(_oTELLib.ServerDateTime()).Date;
            dtToDate.Value = Convert.ToDateTime(_oTELLib.ServerDateTime()).Date;
            DBController.Instance.CloseConnection();
        }
        private void LoadCombos()
        {

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.Refresh(Dictionary.ProductGroupType.MAG);
            cboMAG.Items.Clear();
            cboMAG.Items.Add("All");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = 0;

            //ASG
            _oASG = new ProductGroups();
            _oASG.Refresh(Dictionary.ProductGroupType.ASG);
            cboASG.Items.Clear();
            cboASG.Items.Add("All");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = 0;

            //AG
            _oAG = new ProductGroups();
            _oAG.Refresh(Dictionary.ProductGroupType.AG);
            cboAG.Items.Clear();
            cboAG.Items.Add("All");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = 0;

            //Brand
            _oBrand = new Brands();
            _oBrand.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cboBrand.Items.Clear();
            cboBrand.Items.Add("All");
            foreach (Brand oBrand in _oBrand)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.SelectedIndex = 0;

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            Report();
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {
            _oTELLib = new TELLib();

            nMAGID = 0;
            nASGID = 0;
            nAGID = 0;
            nBrandID = 0;

            if (cboMAG.SelectedIndex != 0)
                nMAGID = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;

            if (cboASG.SelectedIndex != 0)
                nASGID = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;

            if (cboAG.SelectedIndex != 0)
                nAGID = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;

            if (cboBrand.SelectedIndex != 0)
                nBrandID = _oBrand[cboBrand.SelectedIndex - 1].BrandID;

            _oStockMovements = new StockMovements();

            _oStockMovements.ProductStockMovementForPOSRT(dtFromDate.Value, dtToDate.Value, Utility.WarehouseID, nAGID, nASGID, nMAGID, 0, nBrandID, txtProductCode.Text.Trim(), txtProductName.Text.Trim());

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.POS.rptStockMovement));
            doc.SetDataSource(_oStockMovements);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName + "[" + Utility.WarehouseCode + "]");
            doc.SetParameterValue("MAGName", cboMAG.Text);
            doc.SetParameterValue("ASGName", cboASG.Text);
            doc.SetParameterValue("AGName", cboAG.Text);
            doc.SetParameterValue("Brand", cboBrand.Text);
            doc.SetParameterValue("ProductCode",txtProductCode.Text.Trim());
            doc.SetParameterValue("ProductName", txtProductName.Text.Trim());
            doc.SetParameterValue("ReportName", "Stock Movement Report");
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime().Date).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
    }
}