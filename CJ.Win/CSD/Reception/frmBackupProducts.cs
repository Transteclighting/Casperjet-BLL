using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmBackupProducts : Form
    {
        private CSDBackupProducts _oCSDBackupProducts;
        private CSDBackupProduct _oCSDBackupProduct;
        
        public frmBackupProducts()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            _oCSDBackupProducts = new CSDBackupProducts();

            lvwBackupProducts.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDBackupProducts.RefreshByBackupProduct();
            this.Text = "Total: " + "[" + _oCSDBackupProducts.Count + "]";

            foreach (CSDBackupProduct oCSDBackupProduct in _oCSDBackupProducts)
            {
                ListViewItem oItem = lvwBackupProducts.Items.Add(oCSDBackupProduct.ProductCode);
                oItem.SubItems.Add(oCSDBackupProduct.ProductName);
                oItem.SubItems.Add(oCSDBackupProduct.BackupProductSerial);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oCSDBackupProduct.IsActive));
                
                oItem.Tag = oCSDBackupProduct;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBackupProduct ofrmBackupProduct = new frmBackupProduct();
            ofrmBackupProduct.ShowDialog();
            LoadData();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBackupProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDBackupProduct oCSDBackupProduct = (CSDBackupProduct)lvwBackupProducts.SelectedItems[0].Tag;
            frmBackupProduct ofrmBackupProduct = new frmBackupProduct();
            ofrmBackupProduct.ShowDialog(oCSDBackupProduct);
            LoadData();
        }

        private void frmBackupProducts_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}