using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report.BEIL;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.Win.BEIL
{
    public partial class frmProductionSummaryFilter : Form
    {
        ProductionLots _oProductionLots;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        ProductGroups _oPG;
        Brands _oBrands;

        public frmProductionSummaryFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Report();
        }
        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

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
            _oBrands = new Brands();
            _oBrands.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cboBrand.Items.Clear();
            cboBrand.Items.Add("All");
            foreach (Brand oBrand in _oBrands)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.SelectedIndex = 0;

        }

        private void Report()
        {
            _oProductionLots = new ProductionLots();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }



            int nAGID = 0;
            if (cboAG.SelectedIndex == 0)
            {
                nAGID = -1;
            }
            else
            {
                nAGID = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;
            }
            int nASGID = 0;
            if (cboASG.SelectedIndex == 0)
            {
                nASGID = -1;
            }
            else
            {
                nASGID = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAGID = 0;
            if (cboMAG.SelectedIndex == 0)
            {
                nMAGID = -1;
            }
            else
            {
                nMAGID = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;
            }
            int nBrandID = 0;
            if (cboBrand.SelectedIndex == 0)
            {
                nBrandID = -1;
            }
            else
            {
                nBrandID = _oBrands[cboBrand.SelectedIndex - 1].BrandID;
            }

            _oProductionLots.GetSummary(dtFromDate.Value.Date, dtToDate.Value.Date, nAGID, nASGID, nMAGID, nBrandID, txtProductCode.Text.Trim(), txtProductName.Text.Trim());
            
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.BEIL.rptProductionSummary));
            doc.SetDataSource(_oProductionLots);

            doc.SetParameterValue("ProductCode", txtProductCode.Text);
            doc.SetParameterValue("ProductName", txtProductName.Text);
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("ReportName", "Product Wise Production Summary");
            doc.SetParameterValue("MAGName", cboMAG.Text);
            doc.SetParameterValue("ASGName", cboASG.Text);
            doc.SetParameterValue("AGName", cboAG.Text);
            doc.SetParameterValue("Brand", cboBrand.Text);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

        }

        private void frmProductionSummaryFilter_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
    }
}