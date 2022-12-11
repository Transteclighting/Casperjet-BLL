using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win
{
    public partial class frmWebMappingUpdate : Form
    {
        ProductDetail oProduct;
        int nProductID;
        int bIsEcomSync;

        public frmWebMappingUpdate()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            oProduct = new ProductDetail();
            oProduct.ProductID = nProductID;
            oProduct.IsEcomSync = checkBox1.Checked == true ? 1:0;
            DBController.Instance.BeginNewTransaction();
            oProduct.UpdateWebMapping();
            DBController.Instance.CommitTransaction();
            MessageBox.Show("You Have Successfully updated Product Web Mapping." + lblProductCode.Text, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        public void ShowDialog(ProductDetail oProductDetail)
        {
            lblProductCode.Text = oProductDetail.ProductCode;
            lblProductName.Text = oProductDetail.ProductName;
            nProductID = oProductDetail.ProductID;
            bIsEcomSync = oProductDetail.IsEcomSync;
            checkBox1.Checked = bIsEcomSync == 1 ? true : false;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
