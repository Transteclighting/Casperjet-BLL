using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmCsdServiceCharges : Form
    {
        private CSDServiceChargeProducts _oCSDServiceChargeProducts;
        private CSDServiceChargeProduct _oCSDServiceChargeProduct;
        public frmCsdServiceCharges()
        {
            InitializeComponent();
        }

        private void frmCsdServiceCharges_Load(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void LoadData()
        {
            _oCSDServiceChargeProducts = new CSDServiceChargeProducts();

            lvwCSDServiceCharges.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nProductID = 0;
            if (ctlProducts1.txtCode.Text != string.Empty)
            {
                nProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
            }
            _oCSDServiceChargeProducts.RefreshByServiceCharge(nProductID);

            this.Text = "Serviceable Product/Item Groups (including Charges)" + "[" + _oCSDServiceChargeProducts.Count + "]";

            foreach (CSDServiceChargeProduct oCSDServiceChargeProduct in _oCSDServiceChargeProducts)
            {
                ListViewItem oItem = lvwCSDServiceCharges.Items.Add(oCSDServiceChargeProduct.ProductCode);
                oItem.SubItems.Add(oCSDServiceChargeProduct.ProductName);
                oItem.SubItems.Add( oCSDServiceChargeProduct.ServiceCharge.ToString());
                oItem.SubItems.Add( oCSDServiceChargeProduct.InspectionChatrge.ToString());
                oItem.SubItems.Add( oCSDServiceChargeProduct.InstallationCharge.ToString());
                oItem.SubItems.Add( oCSDServiceChargeProduct.ReInstallationCharge.ToString());
                oItem.SubItems.Add( oCSDServiceChargeProduct.DismantlingCharge.ToString());

                oItem.Tag = oCSDServiceChargeProduct;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCsdServiceCharge ofrmCsdServiceCharge = new frmCsdServiceCharge();
            ofrmCsdServiceCharge.ShowDialog();
            ofrmCsdServiceCharge.Tag = null;
            if (ofrmCsdServiceCharge._isAnyactivityDone)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCSDServiceCharges.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Servic Charge to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDServiceChargeProduct oCSDServiceChargeProduct = (CSDServiceChargeProduct)lvwCSDServiceCharges.SelectedItems[0].Tag;
            frmCsdServiceCharge ofrmCsdServiceCharge = new frmCsdServiceCharge();
            ofrmCsdServiceCharge.ShowDialog(oCSDServiceChargeProduct);
            if (ofrmCsdServiceCharge._isAnyactivityDone)
            {
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}