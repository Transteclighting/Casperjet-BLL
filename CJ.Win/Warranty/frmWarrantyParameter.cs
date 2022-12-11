using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Warranty;

namespace CJ.Win.Warranty
{
    public partial class frmWarrantyParameter : Form
    {
        ProductDetails _oProductDetailsASG;
        ProductDetails _oProductDetailsBrand;
        WarrantyParams oWarrantyParams;
        public frmWarrantyParameter()
        {
            InitializeComponent();
        }
        private void frmWarrantyParameter_Load(object sender, EventArgs e)
        {
            LoadCombos();
            //DataLoadControl();
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void LoadCombos()
        {
            //cmbProductType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductType)))
            {
                cmbProductType.Items.Add(Enum.GetName(typeof(Dictionary.ProductType), GetEnum));
            }
            cmbProductType.SelectedIndex = 0;

            // GetASG
            _oProductDetailsASG = new ProductDetails();
            _oProductDetailsASG.RefreshASG();
            cmbASG.Items.Add("All");
            foreach (ProductDetail oProductDetail in _oProductDetailsASG)
            {
                cmbASG.Items.Add(oProductDetail.ASGName);
            }
            if (_oProductDetailsASG.Count > 0)
            {
                cmbASG.SelectedIndex = 0;
            }

            // GetBrand
            _oProductDetailsBrand = new ProductDetails();
            _oProductDetailsBrand.RefreshBrand();
            cmbBrand.Items.Add("All");
            foreach (ProductDetail oProductDetail in _oProductDetailsBrand)
            {
                cmbBrand.Items.Add(oProductDetail.BrandDesc);
            }
            if (_oProductDetailsBrand.Count > 0)
            {
                cmbBrand.SelectedIndex = 0;
            }

        }

        private void DataLoadControl()
        {
            WarrantyParams oWarrantyParams = new WarrantyParams();

            lvwWarrantyParams.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nASGID = 0;
            if (cmbASG.SelectedIndex > 0)
            {
                nASGID = _oProductDetailsASG[cmbASG.SelectedIndex - 1].ASGID;
            }
            int nBrandID = 0;
            if (cmbBrand.SelectedIndex > 0)
            {
                nBrandID = _oProductDetailsBrand[cmbBrand.SelectedIndex - 1].BrandID;
            }

            oWarrantyParams.Refresh(cmbProductType.SelectedIndex + 1, txtProductCode.Text, txtProductName.Text, nASGID, nBrandID);

            this.Text = "Total " + "[" + oWarrantyParams.Count + "]";
            foreach (WarrantyParam oWarrantyParam in oWarrantyParams)
            {
                ListViewItem oItem = lvwWarrantyParams.Items.Add(oWarrantyParam.ProductCode);
                oItem.SubItems.Add(oWarrantyParam.ProductName);
                oItem.SubItems.Add(oWarrantyParam.ASGName);
                oItem.SubItems.Add(oWarrantyParam.BrandName);
                oItem.SubItems.Add(oWarrantyParam.ProductTypeName);
                oItem.SubItems.Add(oWarrantyParam.ServiceWarranty.ToString());
                oItem.SubItems.Add(oWarrantyParam.PartsWarranty.ToString());
                oItem.SubItems.Add(oWarrantyParam.SpecialComponentWarranty.ToString());
                oItem.SubItems.Add(oWarrantyParam.IsPrintWarrantyCard.ToString());
                oItem.SubItems.Add(oWarrantyParam.IsStoreBarcode.ToString());
                oItem.SubItems.Add(oWarrantyParam.Status.ToString());

                oItem.Tag = oWarrantyParam;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwWarrantyParams.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwWarrantyParams.Items)
                {
                    if (oItem.SubItems[10].Text == "0")
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        oItem.BackColor = Color.White;

                    }
                }
            }
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            WarrantyParams oWarrantyParams;
            WarrantyParam oWarrantyParam;

            if (lvwWarrantyParams.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
                oWarrantyParams = new WarrantyParams();

                foreach (ListViewItem oItem in lvwWarrantyParams.SelectedItems)
                {

                    oWarrantyParam = (WarrantyParam)oItem.Tag;
                    oWarrantyParams.Add(oWarrantyParam);

                }
                frmWarrantyParam oForm = new frmWarrantyParam();
                oForm.ShowDialog(oWarrantyParams);
                if (oForm._IsTrue == true) DataLoadControl();



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}































    