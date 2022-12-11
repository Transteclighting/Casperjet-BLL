// <summary>
// Compamy: Bangladesh Lamps Limited
// Primary Author: Md. Humayun Rashid
// Date: Nov 28, 2021
// Time :  12:40 PM
// Description: Forms for Add/Edit of Product MC Set Up.
// Modify Person And Date:
// </summary>

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
using CJ.Class.BasicData;
using CJ.Class.POS;
using CJ.Class.HR;

namespace CJ.Win.Basic
{
    public partial class frmProductMCSet : Form
    {
        public frmProductMCSet()
        {
            InitializeComponent();
        }

        public void ShowDialog(Product oProduct)
        {
            this.Tag = oProduct;
            ctlProduct1.txtCode.Text = oProduct.ProductCode;
            this.ShowDialog();
        }

        private void frmProductMCSet_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Product MC Change (Select a Product)";
            }
            else
            {
                this.Text = "Product MC Change (Selected Product)";
                ctlProduct1.Enabled = false;
            }
        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
            {
                ProductPrice oProductPrice = new ProductPrice();
                ProductPrices oProductPrices = new ProductPrices();
                oProductPrice.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;

                DBController.Instance.OpenNewConnection();
                oProductPrice.RefreshByProductIDMC();
                DBController.Instance.CloseConnection();

                

                if (oProductPrice.Flag==false)
                {
                     txterpcode.Text = String.Format("", oProductPrice.ERPCode);
                }
                else
                {
                    txterpcode.Text = oProductPrice.ERPCode.ToString();
                }

                txtcogs.Text = oProductPrice.COGS.ToString("0.00");
                txtmatrial.Text = oProductPrice.VCMaterial.ToString("0.00");
                txtfactory.Text = oProductPrice.VCVariableFactory.ToString("0.00");
                txtlabour.Text = oProductPrice.VCDirectLabor.ToString("0.00");
                txtfright.Text = Convert.ToString(oProductPrice.FreightCost * 100);
                txtreplacement.Text = Convert.ToString(oProductPrice.Replacement * 100);
                txtadv.Text = Convert.ToString(oProductPrice.Advertisement * 100);
                txtretail.Text = Convert.ToString(oProductPrice.TPRetailOffer * 100);
                txtdbinc.Text = Convert.ToString(oProductPrice.TPDBIncentive * 100);
                txttemainc.Text = Convert.ToString(oProductPrice.TPTeamIncentive * 100);
                txtyearinc.Text = Convert.ToString(oProductPrice.TPYearlyIncentive * 100);
                txtroyality.Text = Convert.ToString(oProductPrice.Royality * 100);
                txtdbtax.Text = Convert.ToString(oProductPrice.DistributorTax * 100);

                if (oProductPrice.Flag == true)
                {
                    dtpEffectiveDate.Value = oProductPrice.EffectiveDate.Date;
                }


                LoadMCList();
            }

          

        }

        private void LoadMCList()
        {
            ProductPrices oProductPrices = new ProductPrices();
            DBController.Instance.OpenNewConnection();

            oProductPrices.RefreshforBLL(ctlProduct1.SelectedSerarchProduct.ProductID);

            DBController.Instance.CloseConnection();

            lvwProductMC.Items.Clear();
            string sDateRange = " to Till Now";
            foreach (ProductPrice oProductPrice in oProductPrices)
            {
                sDateRange = oProductPrice.EffectiveDate.ToShortDateString() + sDateRange;
                ListViewItem oItem = lvwProductMC.Items.Add(sDateRange);
                sDateRange = " to " + oProductPrice.EffectiveDate.AddDays(-1).ToShortDateString();

                oItem.SubItems.Add(oProductPrice.ERPCode.ToString());
                oItem.SubItems.Add(oProductPrice.COGS.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.VCMaterial.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.VCVariableFactory.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.VCDirectLabor.ToString("0.00"));

                oItem.SubItems.Add(Convert.ToString(oProductPrice.FreightCost * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.Replacement * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.Advertisement * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.TPRetailOffer * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.TPDBIncentive * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.TPTeamIncentive * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.TPYearlyIncentive * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.Royality * 100));
                oItem.SubItems.Add(Convert.ToString(oProductPrice.DistributorTax * 100));

                if (oProductPrice.IsCurrent == (int)Dictionary.IsCurrent.Yes)
                    oItem.ForeColor = Color.DarkGreen;
                oItem.Tag = oProductPrice;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            //Validate ERP Code


            if (txterpcode.Text == "")
            {
                MessageBox.Show("Please Write ERP Code...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txterpcode.Focus();
                return false;
            }
            else
            {
                if(txterpcode.Text != "")
                {
                    ProductPrice oProductPrice = new ProductPrice();
                    oProductPrice.ERPCodeCheck(Convert.ToString(txterpcode));
                    MessageBox.Show("ERP Code not match in MAP ERP Table...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txterpcode.Focus();
                    return false;
                }

            }

            //Validate Cost Price
            try
            {
                Double nCOGS = Convert.ToDouble(txtcogs.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid COGS.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcogs.Focus();
                return false;
            }

            //Validate Trade Price
            try
            {
                Double nFrightCost = Convert.ToDouble(txtfright.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid Fright Cost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtfright.Focus();
                return false;
            }

            //try
            //{
            //    Double nNSP = Convert.ToDouble(txtNSP.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please enter valid NSP.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtNSP.Focus();
            //    return false;
            //}

            //try
            //{
            //    Double nRSP = Convert.ToDouble(txtRSP.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please enter valid RSP.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtRSP.Focus();
            //    return false;
            //}

            //try
            //{
            //    Double nVAT = Convert.ToDouble(txtVAT.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please enter valid VAT Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtVAT.Focus();
            //    return false;
            //}

            //try
            //{
            //    Double nSpecialPrice = Convert.ToDouble(txtSpecialPrice.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("Please enter valid special price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSpecialPrice.Focus();
            //    return false;
            //}

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
            DataSyncManager oDataSyncManager = new DataSyncManager();

            int nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            try
            {
                ProductPrices oProductPrices = new ProductPrices();

                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = nProductID;

                oProductPrice.ERPCode = txterpcode.Text;
                oProductPrice.COGS = Convert.ToDouble(txtcogs.Text);
                oProductPrice.VCMaterial = Convert.ToDouble(txtmatrial.Text);
                oProductPrice.VCVariableFactory = Convert.ToDouble(txtfactory.Text);
                oProductPrice.VCDirectLabor = Convert.ToDouble(txtlabour.Text);

                oProductPrice.FreightCost = Convert.ToDouble(((txtfright.Text))) / 100;
                oProductPrice.Replacement = Convert.ToDouble(txtreplacement.Text) / 100;
                oProductPrice.Advertisement = Convert.ToDouble(txtadv.Text) / 100;
                oProductPrice.TPRetailOffer = Convert.ToDouble(txtretail.Text) / 100;
                oProductPrice.TPDBIncentive = Convert.ToDouble(txtdbinc.Text) / 100;
                oProductPrice.TPTeamIncentive = Convert.ToDouble(txttemainc.Text) / 100;
                oProductPrice.TPYearlyIncentive = Convert.ToDouble(txtyearinc.Text) / 100;
                oProductPrice.Royality = Convert.ToDouble(txtroyality.Text) / 100;
                oProductPrice.DistributorTax = Convert.ToDouble(txtdbtax.Text) / 100;

                oProductPrice.EffectiveDate = dtpEffectiveDate.Value;
                oProductPrice.IsCurrent = (int)Dictionary.IsCurrent.Yes;

                DBController.Instance.BeginNewTransaction();

                ProductPrice oGetMaxPriceID = new ProductPrice();
                oGetMaxPriceID.ProductID = nProductID;

                oGetMaxPriceID.RefreshByProductIDMC();
                oProductPrices.ResetIsCurrentMC(nProductID);

                oProductPrice.AddMC();

                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message.ToString());
            }

            this.Close();
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }
    }


}
