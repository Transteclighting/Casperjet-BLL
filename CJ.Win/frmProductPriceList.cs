using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CJ.Class;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.Win
{
    public partial class frmProductPriceList : Form
    {
        ProductDetail _oProductDetail;
        public ProductDetails _oProductDetails;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrand;
        Utilities oItemCategory;
        int nMAGID = 0;
        int nASGID = 0;
        int nAGID = 0;
        int nBrandID = 0;

        public frmProductPriceList()
        {
            InitializeComponent();
        }
        private void frmProductPriceList_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            //PG
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cboPG.Items.Clear();
            cboPG.Items.Add("All");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = 0;

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

            oItemCategory = new Utilities();
            oItemCategory.GetItemCategory();
            cmbItemCategory.Items.Clear();
            foreach (Utility oUtility in oItemCategory)
            {
                cmbItemCategory.Items.Add(oUtility.Satus);
            }
            cmbItemCategory.SelectedIndex = 0;
            _oProductDetails = new ProductDetails();
        }


        private void refreshListBySearch()
        {
            _oProductDetails = new ProductDetails();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nPGID = 0;
            int nMAGID = 0;
            int nASGID = 0;
            int nAGID = 0;
            int nBrandID = 0;

            if (cboPG.SelectedIndex != 0)
            {
                nPGID = _oPG[cboPG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nPGID = -1;
            }
            if (cboMAG.SelectedIndex != 0)
            {
                nMAGID = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nMAGID = -1;
            }
            if (cboASG.SelectedIndex != 0)
            {
                nASGID = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nASGID = -1;
            }
            if (cboAG.SelectedIndex != 0)
            {
                nAGID = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nAGID = -1;
            }
            if (cboBrand.SelectedIndex != 0)
            {
                nBrandID = _oBrand[cboBrand.SelectedIndex - 1].BrandID;
            }
            else
            {
                nBrandID = -1;
            }
            _oProductDetails.Refresh(nPGID, nMAGID, nASGID, nAGID, nBrandID, txtCode.Text, txtName.Text, oItemCategory[cmbItemCategory.SelectedIndex].SatusId);

            foreach (ProductDetail oProductDetail in _oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.ASGName).ToString());
                oItem.SubItems.Add((oProductDetail.MAGName).ToString());
                oItem.SubItems.Add((oProductDetail.PGName).ToString());
                oItem.SubItems.Add((oProductDetail.RSP).ToString());
                oItem.Tag = oProductDetail;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshListBySearch();
        }

        private void returnSelectedProduct()
        {
            _oProductDetails = new ProductDetails();
            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {
                if (lvwProduct.Items[i].Checked == true)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail = (ProductDetail)lvwProduct.Items[i].Tag;
                    _oProductDetails.Add(_oProductDetail);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            //ProductDetails oProductDetails = new ProductDetails();

            if (_oProductDetails.Count == 0)
            {
                MessageBox.Show("Data not found");
                return;
            }

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


            if (lvwProduct.SelectedItems.Count == 0)
            {
                rptProductPriceList doc = new rptProductPriceList();
                doc.SetDataSource(_oProductDetails);
                doc.SetParameterValue("UserName", Utility.UserFullname);
                doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
                doc.SetParameterValue("ReportName", "Official Price List");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("AGName", cboAG.Text);
                doc.SetParameterValue("BrandName", cboBrand.Text);
                doc.SetParameterValue("ProductCode", txtCode.Text);
                doc.SetParameterValue("ProductName", txtName.Text);


                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            else
            {
                rptProductPriceList doc = new rptProductPriceList();
                doc.SetDataSource(_oProductDetails);
                doc.SetParameterValue("UserName", Utility.UserFullname);
                doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
                doc.SetParameterValue("ReportName", "Official Price List");
                doc.SetParameterValue("MAGName", cboMAG.Text);
                doc.SetParameterValue("ASGName", cboASG.Text);
                doc.SetParameterValue("AGName", cboAG.Text);
                doc.SetParameterValue("BrandName", cboBrand.Text);
                doc.SetParameterValue("ProductCode", txtCode.Text);
                doc.SetParameterValue("ProductName", txtName.Text);


                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
        }


    }
}
