using CJ.Class;
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

namespace CJ.Win.Duty
{
    public partial class frmStockPositionVAT : Form
    {
        string _sFilteringDetails;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        Brands _oBrands;
        Warehouses oWarehouses;
        Warehouses oParentWarehouses;
        public frmStockPositionVAT()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbReportType.SelectedIndex = 0;

            //cmbWarehouse.Items.Clear();
            //cmbWarehouse.Items.Add("<All>");

            cmbWarehouseParent.Items.Clear();
            oParentWarehouses = new Warehouses();
            oParentWarehouses.GetWarehouseParents();
            cmbWarehouseParent.Items.Add("<All>");
            foreach (Warehouse oParentWarehouse in oParentWarehouses)
            {
                cmbWarehouseParent.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbWarehouseParent.SelectedIndex = 0;

            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            //Removing the [ALL] in the Brand Object ??!!
            _oBrands.RemoveAt(_oBrands.Count - 1);
            //
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

        }
        private void LoadCombo(int nWarehouseParentID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetStockReqDeliveryWH(nWarehouseParentID);
            cmbWarehouse.Items.Add("<All>");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = 0;
        }

        private void makeClause()
        {
            _sFilteringDetails = "";
            _sFilteringDetails = _sFilteringDetails + " Report Type: " + cmbReportType.SelectedItem.ToString().Trim() + ";";
            if (cmbWarehouseParent.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Parent Warehouse: " + cmbWarehouseParent.SelectedItem.ToString().Trim() + ";";
            }
            if (cmbWarehouse.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Warehouse: " + cmbWarehouse.SelectedItem.ToString().Trim() + ";";
            }
            if (cmbBrand.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Brand: " + cmbBrand.SelectedItem.ToString().Trim() + ";";
            }
            if (cmbPG.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Product Group: " + cmbPG.SelectedItem.ToString().Trim() + ";";
            }
            if (cmbMAG.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Main Article Group: " + cmbMAG.SelectedItem.ToString().Trim() + ";";
            }
            if (cmbASG.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Article Sup Group: " + cmbASG.SelectedItem.ToString().Trim() + ";";
            }

            if (cmbAG.SelectedIndex > 0)
            {
                _sFilteringDetails = _sFilteringDetails + " Article Group: " + cmbAG.SelectedItem.ToString().Trim() + ";";
            }
            if (ctlProduct1.txtDescription.Text.Trim() != "")
            {
                _sFilteringDetails = _sFilteringDetails + " Product Code: " + ctlProduct1.txtDescription.Text.Trim() + ";";
            }
        }


        private void Report()
        {
            int nWarehouseParentID = -1;
            if (cmbWarehouseParent.SelectedIndex != 0)
            {
                nWarehouseParentID = oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID;
            }
            int nWarehouseID = -1;
            if (cmbWarehouse.SelectedIndex != 0)
            {
                nWarehouseID = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            }
            int nPGID = -1;
            if (cmbPG.SelectedIndex > 0) nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;

            int nMAGID = -1;
            if (cmbMAG.SelectedIndex > 0) nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;

            int nASGID = -1;
            if (cmbASG.SelectedIndex > 0) nASGID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;

            int nAGID = -1;
            if (cmbAG.SelectedIndex > 0) nAGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;

            int nBrandID = -1;
            if (cmbBrand.SelectedIndex > 0)
            {
                nBrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }
            int nProductID = 0;
            if (ctlProduct1.txtCode.Text == "")
            {
                nProductID = -1;
            }
            else
            {
                nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            }
            makeClause();
            UnsoldDefectiveProducts _oUDPs = new UnsoldDefectiveProducts();
            try
            {

                DBController.Instance.OpenNewConnection();
                _oUDPs.GetStockPositionForVAT(dtFromDate.Value.Date, dtToDate.Value.Date, nWarehouseParentID, nWarehouseID, nPGID, nMAGID, nASGID, nAGID, nBrandID, nProductID, cmbReportType.SelectedItem.ToString());
                DBController.Instance.CloseConnection();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Web: Barcode Based Goods Movement Summary Report" + ex);
            }



            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptStockPositionForVAT));
            doc.SetDataSource(_oUDPs);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("StDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("EndDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Report_Name", "Stock Position Report");
            doc.SetParameterValue("FilteringDetails", _sFilteringDetails);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
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

        private void frmStockPositionVAT_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Now.Date;
            dtToDate.Value = DateTime.Now.Date;
            LoadCombo();

        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbPG.SelectedIndex == 0)
            {
                _oMAG = null;
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("<All>");
                cmbMAG.SelectedIndex = 0;
                return;
            }
            int nParentID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
            //Load MAG in combo
            _oMAG = new ProductGroups();
            _oMAG.Refresh(nParentID);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbMAG.SelectedIndex == 0)
            {
                _oASG = null;
                cmbASG.Items.Clear();
                cmbASG.Items.Add("<All>");
                cmbASG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            //Load ASG in combo
            _oASG = new ProductGroups();
            _oASG.Refresh(nParentID);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }

            cmbASG.SelectedIndex = 0;
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbASG.SelectedIndex == 0)
            {
                _oAG = null;
                cmbAG.Items.Clear();
                cmbAG.Items.Add("<All>");
                cmbAG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;
            //Load AG in combo
            _oAG = new ProductGroups();
            _oAG.Refresh(nParentID);
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;
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
