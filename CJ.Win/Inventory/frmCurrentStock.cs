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
using CJ.Report;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.Inventory
{
    public partial class frmCurrentStock : Form
    {
        ProductStocks _ProductStocks;
        public string sProductCode;
        public string sProductName;
        public string sProductDesc;
        public string sProductModel;
        public int sProductId;
        public ProductDetail _oProductDetail;
        public ProductDetails _oProductDetails;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrand;
        private Showrooms _oShowrooms;
        private Warehouses oWarehouses;
        Utilities oItemCategory;

        int _nIUControl = 0;

        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        public frmCurrentStock()
        {
            InitializeComponent();
        }



        private void LoadCombos()
        {

            //Warehouse HO
            oWarehouses = new Warehouses();
            oWarehouses.GetStockReqDeliveryWH(6);
            cmbWarehouse.Items.Add("-- All --");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = 0;

            //Showroom 
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = _oPG.Count - 1;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GETMAG();
            cboMAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = _oMAG.Count - 1;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GETASG();
            cboASG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = _oASG.Count - 1;

            //AG
            _oAG = new ProductGroups();
            _oAG.GETAG();
            cboAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = _oAG.Count - 1;

            //Brand
            _oBrand = new Brands();
            _oBrand.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cboBrand.Items.Clear();

            foreach (Brand oBrand in _oBrand)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.Items.Add("ALL");
            cboBrand.SelectedIndex = _oBrand.Count;

            oItemCategory = new Utilities();
            oItemCategory.GetItemCategory();
            cmbItemCategory.Items.Clear();
            foreach (Utility oUtility in oItemCategory)
            {
                cmbItemCategory.Items.Add(oUtility.Satus);
            }
            cmbItemCategory.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void Report(string sProductID)
        {

            _ProductStocks = new ProductStocks();
            string nWarehouseID = "";

            if (rbOutlet.Checked == true)
            {
                if (cmbShowroom.SelectedIndex == 0)
                {
                    //nWarehouseID = "-1";
                    for (int i = 0; i <= _oShowrooms.Count-1; i++)
                    {
                        if (i == 0)
                        {
                            nWarehouseID = _oShowrooms[i].WarehouseID.ToString();
                        }
                        else
                        {
                            nWarehouseID = nWarehouseID + "," + _oShowrooms[i].WarehouseID.ToString();
                        }
                    }
                }

                else
                {
                    nWarehouseID = _oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID.ToString();
                }
            }

            if (rbHO.Checked == true)
            {
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    //nWarehouseID = "-1";
                    for (int i = 0; i <= oWarehouses.Count-1; i++)
                    {
                        if (i == 0)
                        {
                            nWarehouseID = oWarehouses[i].WarehouseID.ToString();
                        }
                        else
                        {
                            nWarehouseID = nWarehouseID + "," + oWarehouses[i].WarehouseID.ToString();
                        }
                    }
                }

                else
                {
                    nWarehouseID = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID.ToString();
                }
            }

            
            _ProductStocks.RefreshForCurrentStock(sProductID, nWarehouseID, rbHO.Checked);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.POS.rptCurrentStockNew));
            doc.SetDataSource(_ProductStocks);
            if (cmbShowroom.SelectedIndex!= 0 && rbOutlet.Checked)
            {
                doc.SetParameterValue("sWarehouse", _oShowrooms[cmbShowroom.SelectedIndex - 1].ShowroomName + "[" + _oShowrooms[cmbShowroom.SelectedIndex - 1].ShowroomCode + "]");
            }
            else if(cmbWarehouse.SelectedIndex != 0 && rbHO.Checked)
            {
                doc.SetParameterValue("sWarehouse", oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseName + "[" + oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseCode + "]");

            }
            else if(cmbShowroom.SelectedIndex == 0 && rbOutlet.Checked)
            {
                doc.SetParameterValue("sWarehouse", "All Outlet");
            }
            else
            {
                doc.SetParameterValue("sWarehouse", "HO Warehouses");
            }
            //doc.SetParameterValue("CompanyName", Utility.CompanyName);
            //doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName + "[" + oSystemInfo.WarehouseCode + "]");
            //doc.SetParameterValue("OpeningStock", nOpeningStock.ToString());
            //doc.SetParameterValue("ReportName", "Stock Ledger");
            //doc.SetParameterValue("ProductCode", ctlProduct1.SelectedSerarchProduct.ProductCode);
            //doc.SetParameterValue("ProductName", ctlProduct1.SelectedSerarchProduct.ProductName);
            //doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            //doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            //doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
            int nCount = 0;
            string sProductID = "";
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    ListViewItem itm = lvwProduct.Items[i];
                    if (lvwProduct.Items[i].Checked == true)
                    {
                        nCount++;
                    }
                }
                if (nCount == 0)
                {
                    MessageBox.Show("Please Checked at least one Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    _oProductDetails = new ProductDetails();
                    for (int i = 0; i < lvwProduct.Items.Count; i++)
                    {
                        if (lvwProduct.Items[i].Checked == true)
                        {
                            _oProductDetail = new ProductDetail();
                            _oProductDetail = (ProductDetail)lvwProduct.Items[i].Tag;
                            _oProductDetails.Add(_oProductDetail);
                            if (nCount > 0)
                            {
                                sProductID = _oProductDetail.ProductID.ToString();
                                nCount = 0;
                            }
                            else
                            {
                                sProductID = sProductID + "," + _oProductDetail.ProductID.ToString();
                            }
                        }
                    }
                }
            



            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
           
            Report(sProductID);
           
            
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshListBySearch();
        }

        private void refreshListBySearch()
        {
            ProductDetails oProductDetails = new ProductDetails();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nBrandID = 0;
            if (_oBrand.Count == cboBrand.SelectedIndex)
            {
                nBrandID = -1;
            }
            else
            {
                nBrandID = _oBrand[cboBrand.SelectedIndex].BrandID;
            }
            string sProductCode="";
            try
            {
                sProductCode = ctlProduct1.SelectedSerarchProduct.ProductCode;
            }
            catch
            {
                sProductCode = "";
            }

            string sProductName = "";
            try
            {
                sProductName = ctlProduct1.SelectedSerarchProduct.ProductName;
            }
            catch
            {
                sProductName = "";
            }
            int nWarehouseID = 0;
            //if (cmbShowroom.SelectedIndex == 0)
            //{
            //    nWarehouseID = -1;
            //}

            //else
            //{
            //    nWarehouseID = _oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID;
            //}
            oProductDetails.RefreshBySearch(_oPG[cboPG.SelectedIndex].PdtGroupID, _oMAG[cboMAG.SelectedIndex].PdtGroupID, _oASG[cboASG.SelectedIndex].PdtGroupID, _oAG[cboAG.SelectedIndex].PdtGroupID, nBrandID, -1, Dictionary.GeneralStatus.All, sProductCode, sProductName, oItemCategory[cmbItemCategory.SelectedIndex].SatusId);

            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.Vat * 100).ToString() + '%');

                //WUIUtility oWUIUtility = new WUIUtility();
                
                //oWUIUtility.GetRetailStock(14, oProductDetail.ProductID);

                //oItem.SubItems.Add(oWUIUtility.CurrentStock.ToString());

                oItem.Tag = oProductDetail;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void lvwProduct_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwProduct.Sorting == SortOrder.Ascending)
            {
                lvwProduct.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProduct.Sorting = SortOrder.Ascending;
            }
            lvwProduct.Sort();
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            if (_nIUControl == 2)
            {
                MessageBox.Show("Please Checked Product and Click Get Button", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            returnSelectedProduct();
            this.Close();
        }

        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                _oProductDetail = (ProductDetail)lvwProduct.SelectedItems[0].Tag;

                sProductId = _oProductDetail.ProductID;
                sProductCode = _oProductDetail.ProductCode;
                sProductDesc = _oProductDetail.ProductDesc;
                sProductName = _oProductDetail.ProductName;
                sProductModel = _oProductDetail.ProductModel;

            }

        }

        private void lvwProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btSelectAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {

                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Checked All";
                }
            }
        }

        private void frmCurrentStock_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            //UIControl();
            DBController.Instance.CloseConnection();
        }
    }
}
