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

namespace CJ.Win.Ecommerce
{
    public partial class frmProductFeature : Form
    {

        ProductFeature oProductFeature;
        public bool _bActionSave = false;
        private string checkDuplicateValue;

        int nID = 0;

        public frmProductFeature()
        {
            InitializeComponent();
        }

        private void frmProductFeature_Load(object sender, EventArgs e)
        {

        }


        public void ShowDialog(ProductFeature oProductFeature)
        {
            this.Tag = oProductFeature;
            nID = oProductFeature.Id;
            ctlProduct1.txtCode.Text = oProductFeature.ProductCode;
            ctlProduct1.txtDescription.Text = oProductFeature.ProductName;
            txtURL.Text = oProductFeature.Url;

            this.ShowDialog();
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                ProductFeature oProductFeature = new ProductFeature();

                oProductFeature.ProductId = ctlProduct1.SelectedSerarchProduct.ProductID;
                oProductFeature.Url = txtURL.Text;

                oProductFeature.CreateDate = DateTime.Now.Date;
                oProductFeature.CreateUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductFeature.Add();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                ProductFeature oProductFeature = (ProductFeature)this.Tag;
                oProductFeature.Id = nID;

                oProductFeature.ProductId = ctlProduct1.SelectedSerarchProduct.ProductID;
                oProductFeature.Url = txtURL.Text;

                oProductFeature.UpdateDate = DateTime.Now.Date;
                oProductFeature.UpdateUserID = Utility.UserId;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductFeature.Edit();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }


        private bool UIValidation()
        {
            if (string.IsNullOrEmpty(ctlProduct1.txtCode.Text))
            {
                MessageBox.Show("Please Select A Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("Please Insert An URL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtURL.Focus();
                return false;
            }

            ProductFeature oProductFeature = new ProductFeature();

            oProductFeature.ProductId = ctlProduct1.SelectedSerarchProduct.ProductID;
            oProductFeature.Url = txtURL.Text;

            checkDuplicateValue = oProductFeature.CheckDuplicateData();


            if (checkDuplicateValue == "Yes")
            {
                MessageBox.Show("Product already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }

            return true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _bActionSave = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }
    }
}
