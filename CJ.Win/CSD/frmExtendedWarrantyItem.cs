using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.BasicData;
using CJ.Class.POS;

namespace CJ.Win.CSD
{
    public partial class frmExtendedWarrantyItem : Form
    {
        public frmExtendedWarrantyItem()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExtendedWarrantyItem_Load(object sender, EventArgs e)
        {

        }
        private bool validateUIInput()
        {
            #region Input Information Validation
            if (cmbTenure.SelectedIndex == 0)
            {
                MessageBox.Show("Please select valid smart warranty tenure.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenure.Focus();
                return false;
            }
            try
            {
                Double nNetPrice = Convert.ToDouble(txtNetPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid net price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNetPrice.Focus();
                return false;
            }

            try
            {
                Double ncommission = Convert.ToDouble(txtCommission.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid commission amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCommission.Focus();
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
            DataSyncManager oDataSyncManager = new DataSyncManager();

            int nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            try
            {
                ProductPrices oProductPrices = new ProductPrices();

                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = nProductID;
                oProductPrice.SmartWarrantyTenure = Convert.ToInt32(cmbTenure.Text);
                oProductPrice.NetPrice = Convert.ToDouble(txtNetPrice.Text);
                oProductPrice.Commission = Convert.ToDouble(txtCommission.Text);
                oProductPrice.EffectiveDate = dtpEffectiveDate.Value;
                oProductPrice.IsCurrent = (int)Dictionary.IsCurrent.Yes;
                oProductPrice.EntryUserID = Utility.UserId;

                try
                {
                    oProductPrice.Remarks = txtRemarks.Text;
                }
                catch
                {
                    oProductPrice.Remarks = "";
                }

                DBController.Instance.BeginNewTransaction();

                ProductPrice oGetMaxPriceID = new ProductPrice();
                oGetMaxPriceID.ProductID = nProductID;
                oGetMaxPriceID.RefreshSmartWarrantyItem();
                if (oGetMaxPriceID.Flag == true)
                {
                    oDataSyncManager.SendSmartWarrantyItem(oGetMaxPriceID, Dictionary.DataTransferType.Add);
                }
                oProductPrices.ResetIsCurrentSmartWarranty(nProductID, Convert.ToInt32(cmbTenure.Text));
                oProductPrice.AddSmartWarrantyItem();
                oDataSyncManager.SendSmartWarrantyItem(oProductPrice, Dictionary.DataTransferType.Add);
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message.ToString());
            }

            this.Close();
        }



        private void LoadPriceList()
        {
            ProductPrices oProductPrices = new ProductPrices();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oProductPrices.RefreshSmartWarrantyItem(ctlProduct1.SelectedSerarchProduct.ProductID, Convert.ToInt32(cmbTenure.Text));
            DBController.Instance.CloseConnection();

            lvwProductPrice.Items.Clear();
            string sDateRange = " to Till Now";
            foreach (ProductPrice oProductPrice in oProductPrices)
            {
                sDateRange = oProductPrice.EffectiveDate.ToShortDateString() + sDateRange;
                ListViewItem oItem = lvwProductPrice.Items.Add(sDateRange);
                sDateRange = " to " + oProductPrice.EffectiveDate.AddDays(-1).ToShortDateString();
                oItem.SubItems.Add(oProductPrice.NetPrice.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.Commission.ToString("0.00"));
                if (oProductPrice.IsCurrent == (int)Dictionary.IsCurrent.Yes)
                    oItem.ForeColor = Color.Blue;
                oItem.Tag = oProductPrice;
            }
        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "" && cmbTenure.SelectedIndex != 0)
            {
                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oProductPrice.SmartWarrantyTenure = Convert.ToInt32(cmbTenure.Text);
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oProductPrice.RefreshSmartWarrantyItem();
                DBController.Instance.CloseConnection();

                txtNetPrice.Text = oProductPrice.NetPrice.ToString();
                txtCommission.Text = oProductPrice.Commission.ToString();

                if (oProductPrice.Flag == true)
                {
                    dtpEffectiveDate.Value = oProductPrice.EffectiveDate.Date;
                }

                LoadPriceList();
            }
        }

        private void cmbTenure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "" && cmbTenure.SelectedIndex != 0)
            {
                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oProductPrice.SmartWarrantyTenure = Convert.ToInt32(cmbTenure.Text);
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oProductPrice.RefreshSmartWarrantyItem();
                DBController.Instance.CloseConnection();
                txtNetPrice.Text = oProductPrice.NetPrice.ToString();
                txtCommission.Text = oProductPrice.Commission.ToString();

                if (oProductPrice.Flag == true)
                {
                    dtpEffectiveDate.Value = oProductPrice.EffectiveDate.Date;
                }

                LoadPriceList();
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

        private void frmExtendedWarrantyItem_Load_1(object sender, EventArgs e)
        {
            cmbTenure.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
