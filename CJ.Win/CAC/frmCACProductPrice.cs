using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACProductPrice : Form
    {
        int nProductID = 0;
        public frmCACProductPrice()
        {
            InitializeComponent();
        }
        
        public void ShowDialog(ProductDetail oProduct)
        {
            this.Tag = oProduct;
            this.Text = "Add New Price";
            nProductID = oProduct.ProductID;
            lblProduct.Text = "[" + oProduct.ProductCode + "]" + " " + oProduct.ProductName;
            
            ProductPrices oProductPrices = new ProductPrices();
            DBController.Instance.OpenNewConnection();
            oProductPrices.RefreshCACPrice(nProductID);
            DBController.Instance.CloseConnection();
            lvwProductPrice.Items.Clear();
            string sDateRange = " to Till Now";
            foreach (ProductPrice oProductPrice in oProductPrices)
            {
                sDateRange = oProductPrice.EffectiveDate.ToShortDateString() + sDateRange;
                ListViewItem oItem = lvwProductPrice.Items.Add(sDateRange);
                sDateRange = " to " + oProductPrice.EffectiveDate.AddDays(-1).ToShortDateString();
                oItem.SubItems.Add(oProductPrice.CPBDT.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.CPUSD.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.RSP.ToString("0.00"));
                if (oProductPrice.IsCurrent == (int)Dictionary.IsCurrent.Yes)
                    oItem.ForeColor = Color.Blue;
                oItem.Tag = oProductPrice;
            }
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation
            try
            {
                Double nCostUSD = Convert.ToDouble(txtCPUSD.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid cost price (USD).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPUSD.Focus();
                return false;
            }

            try
            {
                Double nCostPrice = Convert.ToDouble(txtCostPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid cost price (BDT).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostPrice.Focus();
                return false;
            }

            try
            {
                Double nRSP = Convert.ToDouble(txtRSP.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid RSP.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRSP.Focus();
                return false;
            }

            if (dtpEffectiveDate.Value < DateTime.Today)
            {
                MessageBox.Show("Effective date must be Same or more than Current Date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEffectiveDate.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            try
            {
                ProductPrices oProductPrices = new ProductPrices();

                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = nProductID;
                oProductPrice.CPUSD = Convert.ToDouble(txtCPUSD.Text);
                oProductPrice.CPBDT = Convert.ToDouble(txtCostPrice.Text);
                oProductPrice.RSP = Convert.ToDouble(txtRSP.Text);
                oProductPrice.EffectiveDate = dtpEffectiveDate.Value;
                oProductPrice.IsCurrent = (int)Dictionary.IsCurrent.Yes;
                DBController.Instance.BeginNewTransaction();
                oProductPrices.ResetCACIsCurrent(nProductID);
                oProductPrice.AddCACPrice();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Price. Product# " + lblProduct.Text, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message.ToString());
            }

            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCACProductPrice_Load(object sender, EventArgs e)
        {

        }
    }
}