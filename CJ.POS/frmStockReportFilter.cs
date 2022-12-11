// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: April 27, 2014
// Time : 03:00 PM
// Description: Stock Position Report for POS
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
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.POS
{
    public partial class frmStockReportFilter : Form
    {
        CJ.POS.TELWEBSERVER.Service oSerivce;
        ProductStocks oProductStocks;
        SystemInfo oSystemInfo;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        Brands _oBrand;
        int nMAGID = 0;
        int nASGID = 0;
        int nAGID = 0;
        int nBrandID = 0;
        UserPermission _oUserPermission;

        CJ.POS.TELWEBSERVER.DSStock oDSStock;
        CJ.Class.POS.DSStock _oDSStock;

        int _nUIControl = 0;

        public frmStockReportFilter(int nIUControl)
        {
            InitializeComponent();
            _nUIControl = nIUControl;
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool IsProdCheck = false;
            this.Cursor = Cursors.WaitCursor;
            if (_nUIControl == 1)
            {
                if (rdoOwnStock.Checked == true)
                {
                    if (rdoProductWise.Checked == true)
                    {
                        IsProdCheck = true;
                    }
                    else
                    {
                        IsProdCheck = false;
                    }
                    Report(IsProdCheck);
                }
                else if (rdoCentralStock.Checked == true)
                {
                    int Desc;
                    if (Utility.InternetGetConnectedState(out Desc, 0))
                    // if (CheckInternet())
                    {
                        WSReport(oSystemInfo.WarehouseID, Utility.CentralRetailWarehouse);
                    }
                    else
                    {
                        MessageBox.Show("Please Check Internet Connection\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                else
                {
                    int Desc;
                    if (Utility.InternetGetConnectedState(out Desc, 0))
                    // if (CheckInternet())
                    {
                        WSReport(oSystemInfo.WarehouseID, 0);
                    }
                    else
                    {
                        MessageBox.Show("Please Check Internet Connection\nSystem Date: " + Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }


            }
            else
            {
                BarcodeReport();

            }
            this.Cursor = Cursors.Default;

        }
        private void WSReport(int nWHID, int nCentralWHID)
        {

            oProductStocks = new ProductStocks();

            DBController.Instance.OpenNewConnection();
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
            
            _oDSStock = new CJ.Class.POS.DSStock();
            oSerivce = new CJ.POS.TELWEBSERVER.Service();
            oDSStock = new CJ.POS.TELWEBSERVER.DSStock();
            oDSStock = oSerivce.DownloadDSStock(oDSStock, nWHID, nCentralWHID, nAGID, nASGID, nMAGID, nBrandID, txtProductCode.Text.Trim(), txtProductName.Text.Trim());

            _oDSStock.Merge(oDSStock);
            _oDSStock.AcceptChanges();


            oProductStocks.GetWSStock(_oDSStock);
            if (nCentralWHID == 0)
            {
                rptPOSStockPositionOutlet doc = new rptPOSStockPositionOutlet();
                doc.SetDataSource(oProductStocks);
                doc.SetParameterValue("User Name", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", "All Outlets Other than " + oSystemInfo.Shortcode + "");
                doc.SetParameterValue("Report_Name", "Current Stock Position");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("Quantity", cmbQuantity.Text);
                doc.SetParameterValue("AGName", cboAG.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("ProductCode", txtProductCode.Text);
                doc.SetParameterValue("ProductName", txtProductName.Text);
                doc.SetParameterValue("PrintDate", oSystemInfo.OperationDate.ToString());

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            else
            {
                rptPOSStockPosition doc = new rptPOSStockPosition();
                doc.SetDataSource(oProductStocks);
                doc.SetParameterValue("User Name", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", "Central Warehouse");
                doc.SetParameterValue("Report_Name", "Current Stock Position");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("Quantity", cmbQuantity.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("AGName", cboAG.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("ProductCode", txtProductCode.Text);
                doc.SetParameterValue("ProductName", txtProductName.Text);
                doc.SetParameterValue("PrintDate", oSystemInfo.OperationDate.ToString());

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            

        }
        private void Report(bool IsProdCheck)
        {
            oProductStocks = new ProductStocks();
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
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

            oSystemInfo.Refresh();
            //oProductStocks.GetCurrentStock(cmbQuantity.SelectedIndex, IsProdCheck,oSystemInfo.WarehouseID, nMAGID, nASGID, nAGID, nBrandID, txtProductCode.Text.Trim(), txtProductName.Text.Trim());
            oProductStocks.GetCurrentStockNew(cmbQuantity.SelectedIndex, IsProdCheck, oSystemInfo.WarehouseID, nMAGID, nASGID, nAGID, nBrandID, txtProductCode.Text.Trim(), txtProductName.Text.Trim());
            if (IsProdCheck == true)
            {
                rptPOSStockPosition doc;
                doc = new rptPOSStockPosition();
                doc.SetDataSource(oProductStocks);
                doc.SetParameterValue("User Name", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
                doc.SetParameterValue("Report_Name", "Current Stock Position (Product Wise)");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("Quantity", cmbQuantity.Text);
                doc.SetParameterValue("AGName", cboAG.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("ProductCode", txtProductCode.Text);
                doc.SetParameterValue("ProductName", txtProductName.Text);
                doc.SetParameterValue("PrintDate", oSystemInfo.OperationDate.ToString());

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            else
            {
                rptPOSStockPositionASG doc;
                doc = new rptPOSStockPositionASG();
                doc.SetDataSource(oProductStocks);
                doc.SetParameterValue("User Name", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
                doc.SetParameterValue("Report_Name", "Current Stock Position (ASG Wise)");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("Quantity", cmbQuantity.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("PrintDate", oSystemInfo.OperationDate.ToString());

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
        }
        private void BarcodeReport()
        {
            ProductBarcodes oProductBarcodes = new ProductBarcodes();

            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            nMAGID = 0;
            nASGID = 0;
            nAGID = 0;
            nBrandID = 0;
            int nType = 0;


            if (cboMAG.SelectedIndex != 0)
                nMAGID = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;

            if (cboASG.SelectedIndex != 0)
                nASGID = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;

            if (cboAG.SelectedIndex != 0)
                nAGID = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;

            if (cboBrand.SelectedIndex != 0)
                nBrandID = _oBrand[cboBrand.SelectedIndex - 1].BrandID;

            if (rdoUnsold.Checked == true)
            {
                nType = 1;
            }
            else if (rdoTransit.Checked == true)
            {
                nType = 2;
            }
            else if (rdoSold.Checked == true)
            {
                nType = 3;
            }
            else if (rdoAll.Checked == true)
            {
                nType = -1;
            }

            oSystemInfo.Refresh();
            oProductBarcodes.GetProductSerial(nType, nMAGID, nASGID, nAGID, nBrandID, txtProductCode.Text.Trim(), txtProductName.Text.Trim(), txtBarcode.Text.Trim());

            if (oProductBarcodes.Count > 0)
            {
                rptProductBarcode doc;
                doc = new rptProductBarcode();
                doc.SetDataSource(oProductBarcodes);
                doc.SetParameterValue("User Name", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
                doc.SetParameterValue("Report_Name", "Product Barcode Serial");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("AGName", cboAG.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("Brand", cboBrand.Text);
                doc.SetParameterValue("ProductCode", txtProductCode.Text);
                doc.SetParameterValue("ProductName", txtProductName.Text);
                doc.SetParameterValue("PrintDate", oSystemInfo.OperationDate.ToString());

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            else
            {
                MessageBox.Show("There is no Data");
            }
        }
        private void frmStockReportFilter_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            _oUserPermission = new UserPermission();
            cmbQuantity.SelectedIndex = 0;
            if (_oUserPermission.CheckPermission("M40.1.1.1.1", Utility.UserId))
            {
                rdoCentralStock.Enabled = true;
            }
            else
            {
                rdoCentralStock.Enabled = false;
            }
            if (_oUserPermission.CheckPermission("M40.1.1.1.2", Utility.UserId))
            {
                rdoOtherOutletsStock.Enabled = true;
            }
            else
            {
                rdoOtherOutletsStock.Enabled = false;
            }

            DBController.Instance.CloseConnection();

            if (_nUIControl == 1)
            {
                groupBox2.Visible = false;
                lblBarcode.Visible = false;
                txtBarcode.Visible = false;
                rdoProductWise.Checked = true;
                rdoOwnStock.Checked = true;
                rdoOwnStock.Text = oSystemInfo.Shortcode + " Stock";
                this.Text = "Stock Report";
            }
            else
            {
                groupBox1.Visible = false;
                rdoUnsold.Checked = true;
                groupBox3.Visible = false;
                lblQty.Visible = false;
                cmbQuantity.Visible = false;
                this.Text = "Product Barcode Report";
            }


        }
        private bool CheckInternet()
        {
            try
            {
                if (Utility.CheckInternetConnection())
                {
                    if (Utility.CheckTELWEBServer())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("HO Server down!!! \n\nPlease try again later or contact concern person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch
            {
                return false;
            }
            //return true;
        }

        private void rdoCentralStock_CheckedChanged(object sender, EventArgs e)
        {
            rdoASGWise.Enabled = false;
            cmbQuantity.SelectedIndex = 2;
            cmbQuantity.Enabled = false;
            if (rdoProductWise.Checked == false)
            {
                rdoProductWise.Checked = true;
            }
        }

        private void rdoOtherOutletsStock_CheckedChanged(object sender, EventArgs e)
        {
            rdoASGWise.Enabled = false;
            cmbQuantity.SelectedIndex = 2;
            cmbQuantity.Enabled = false;
            if (rdoProductWise.Checked == false)
            {
                rdoProductWise.Checked = true;
            } 
        }

        private void rdoASGWise_CheckedChanged(object sender, EventArgs e)
        {
            cboAG.SelectedIndex = 0;
            cboAG.Enabled = false;
            txtProductCode.Text = "";
            txtProductName.Text = "";
            txtProductCode.Enabled = false;
            txtProductName.Enabled = false;
        }

        private void rdoProductWise_CheckedChanged(object sender, EventArgs e)
        {
            cboAG.Enabled = true;
            txtProductCode.Enabled = true;
            txtProductName.Enabled = true;
        }

        private void rdoOwnStock_CheckedChanged(object sender, EventArgs e)
        {
            lblQty.Visible = true;
            cmbQuantity.Visible = true;
            rdoASGWise.Enabled = true;
            cmbQuantity.Enabled = true;
        }


    }
}