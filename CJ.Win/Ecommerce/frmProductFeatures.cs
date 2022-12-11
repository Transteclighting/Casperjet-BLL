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
using CJ.Win.Security;

namespace CJ.Win.Ecommerce
{
    public partial class frmProductFeatures : Form
    {

        ProductFeatures oProductFeatures;
        private ProductFeatures _oProductFeatures;

        public frmProductFeatures()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmProductFeature ofrmProductFeature = new frmProductFeature();
            ofrmProductFeature.ShowDialog();
            if (ofrmProductFeature._bActionSave)
                LoadData();
        }


        private void LoadData()
        {
            oProductFeatures = new ProductFeatures();
            lvwProductFeatures.Items.Clear();

            DBController.Instance.OpenNewConnection();

            oProductFeatures.GetProductFeature(txtProductCode.Text);

            foreach (ProductFeature ooProductFeature in oProductFeatures)
            {
                ListViewItem oItem = lvwProductFeatures.Items.Add(ooProductFeature.ProductCode.ToString());
                oItem.SubItems.Add(ooProductFeature.ProductName.ToString());
                oItem.SubItems.Add(ooProductFeature.UserFullName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(ooProductFeature.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(ooProductFeature.Url.ToString());
                oItem.SubItems.Add(ooProductFeature.Id.ToString());

                oItem.Tag = ooProductFeature;
            }
            this.Text = "No of Product Feature Records-" + oProductFeatures.Count + "";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductFeatures.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductFeature oProductFeature = (ProductFeature)lvwProductFeatures.SelectedItems[0].Tag;

            frmProductFeature ofrmProductFeature = new frmProductFeature();
            ofrmProductFeature.ShowDialog(oProductFeature);
            if (ofrmProductFeature._bActionSave)
                LoadData();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmProductFeatures_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
