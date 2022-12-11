using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;

namespace CJ.Win.POS
{
    public partial class frmStockCasperCassiopeia : Form
    {
        Brands _oBrand;
        ProductGroups oPGroup;
        Warehouses _oShowroom;

        public frmStockCasperCassiopeia()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            StockCasperCassiopeias oStockCasperCassiopeias = new StockCasperCassiopeias();
            lvwStockList.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oStockCasperCassiopeias.GETData(cmbShowroom.SelectedItem.ToString(), cmbMAG.SelectedItem.ToString(), cmbASG.SelectedItem.ToString(), cmbBrand.SelectedItem.ToString());


            foreach (StockCasperCassiopeia oStockCasperCassiopeia in oStockCasperCassiopeias)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oStockCasperCassiopeia.ProductCode);
                lstItem.SubItems.Add(oStockCasperCassiopeia.ProductName);
                lstItem.SubItems.Add(oStockCasperCassiopeia.CasperStock.ToString());
                lstItem.SubItems.Add(oStockCasperCassiopeia.CassiopeiaStock.ToString());
                lstItem.SubItems.Add(oStockCasperCassiopeia.StockDifference.ToString());

            }
        }

        private void frmStockCasperCassiopeia_Load(object sender, EventArgs e)
        {
            LoadALLCombo();
        }

        private void LoadALLCombo()
        {
            _oShowroom = new Warehouses();
            _oShowroom.GetAllShowroom();
            cmbShowroom.Items.Clear();
            foreach (Warehouse oShowroom in _oShowroom)
            {
                cmbShowroom.Items.Add(oShowroom.WarehouseName);
            }

            if (_oShowroom.Count > 0)
                cmbShowroom.SelectedIndex = _oShowroom.Count - 1;

            _oBrand = new Brands();
            _oBrand.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            foreach (Brand oBrand in _oBrand)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            if (_oBrand.Count > 0)
                cmbBrand.SelectedIndex = _oBrand.Count - 1;

            oPGroup = new ProductGroups();
            oPGroup.GETMAG();
            cmbMAG.Items.Clear();
            foreach (ProductGroup oMAG in oPGroup)
            {
                cmbMAG.Items.Add(oMAG.PdtGroupName);
            }
            if (oPGroup.Count > 0)
                cmbMAG.SelectedIndex = oPGroup.Count - 1;

            oPGroup = new ProductGroups();
            oPGroup.GETASG();
            cmbASG.Items.Clear();
            foreach (ProductGroup oASG in oPGroup)
            {
                cmbASG.Items.Add(oASG.PdtGroupName);
            }
            if (oPGroup.Count > 0)
                cmbASG.SelectedIndex = oPGroup.Count - 1;

        }
    }
}