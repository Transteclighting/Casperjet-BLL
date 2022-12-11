// <summary>
// Compamy: Transcom Electronics Limited
// Primary Author: Arif Khan
// Date: April 20, 2014
// Time :  5:45 PM
// Description: Forms for Add/Edit of Product Price.
// Modify Person And Date:
// </summary>

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
using CJ.Class.HR;

namespace CJ.Win.Basic
{
    public partial class frmProductPrice : Form
    {
        public frmProductPrice()
        {
            InitializeComponent();
        }

        public void ShowDialog(Product oProduct)
        {
            this.Tag = oProduct;
            ctlProduct.txtCode.Text = oProduct.ProductCode;
            txtRemarks.Text = oProduct.Remarks;
            this.ShowDialog();
        }

        private void frmProductPrice_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Product Price Change (Select a Product)";
            }
            else
            {
                this.Text = "Product Price Change (Selected Product)";
                ctlProduct.Enabled = false;
            }
        }

        private void ctlProduct_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct.SelectedSerarchProduct != null && ctlProduct.txtCode.Text != "")
            {
                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = ctlProduct.SelectedSerarchProduct.ProductID;

                DBController.Instance.OpenNewConnection();
                oProductPrice.RefreshByProductIDPrice();
                DBController.Instance.CloseConnection();

                txtCostPrice.Text = oProductPrice.CostPrice.ToString();
                txtTradePrice.Text = oProductPrice.TradePrice.ToString();
                txtNSP.Text = oProductPrice.NSP.ToString();
                txtRSP.Text = oProductPrice.RSP.ToString();
                txtSpecialPrice.Text = oProductPrice.SpecialPrice.ToString();
                txtVAT.Text = oProductPrice.VAT.ToString();
                txtMC.Text = oProductPrice.MC.ToString();
                txtVATCP.Text = oProductPrice.VATCP.ToString();
                if (oProductPrice.Flag == true)
                {
                    dtpEffectiveDate.Value = oProductPrice.EffectiveDate.Date;
                }

                LoadPriceList();
            }
        }

        private void LoadPriceList()
        {
            ProductPrices oProductPrices = new ProductPrices();
            DBController.Instance.OpenNewConnection();
            oProductPrices.Refresh(ctlProduct.SelectedSerarchProduct.ProductID);
            DBController.Instance.CloseConnection();

            lvwProductPrice.Items.Clear();
            string sDateRange = " to Till Now";
            foreach (ProductPrice oProductPrice in oProductPrices)
            {
                sDateRange = oProductPrice.EffectiveDate.ToShortDateString() + sDateRange;
                ListViewItem oItem = lvwProductPrice.Items.Add(sDateRange);
                sDateRange = " to " + oProductPrice.EffectiveDate.AddDays(-1).ToShortDateString();
                oItem.SubItems.Add(oProductPrice.CostPrice.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.TradePrice.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.NSP.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.RSP.ToString("0.00"));
                oItem.SubItems.Add("");
                oItem.SubItems.Add(oProductPrice.VAT.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.SpecialPrice.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.MC.ToString("0.00"));
                oItem.SubItems.Add(oProductPrice.VATCP.ToString("0.00"));
                if (oProductPrice.IsCurrent == (int)Dictionary.IsCurrent.Yes)
                    oItem.ForeColor = Color.Blue;
                oItem.Tag = oProductPrice;
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation
            //Validate Cost Price
            try
            {
                Double nCostPrice = Convert.ToDouble(txtCostPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid cost price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostPrice.Focus();
                return false;
            }

            //Validate Trade Price
            try
            {
                Double nTradePrice = Convert.ToDouble(txtTradePrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid Trade price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTradePrice.Focus();
                return false;
            }

            try
            {
                Double nNSP = Convert.ToDouble(txtNSP.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid NSP.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNSP.Focus();
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

            try
            {
                Double nVAT = Convert.ToDouble(txtVAT.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid VAT Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVAT.Focus();
                return false;
            }

            try
            {
                Double nSpecialPrice = Convert.ToDouble(txtSpecialPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please enter valid special price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecialPrice.Focus();
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                if (Utility.CompanyInfo == "BLL")
                {
                    DBController.Instance.OpenNewConnection();
                    ProductPrice oProductPrice = new ProductPrice();
                    oProductPrice.ProductID = ctlProduct.SelectedSerarchProduct.ProductID;
                    DBController.Instance.CloseConnection();

                    frmProductMCSet oForm = new frmProductMCSet();
                    oForm.ShowDialog();
                }
                this.Close();
            }
        }

        private void Save()
        {
            DataSyncManager oDataSyncManager = new DataSyncManager();

            int nProductID = ctlProduct.SelectedSerarchProduct.ProductID;
            try
            {
                ProductPrices oProductPrices = new ProductPrices();

                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = nProductID;
                oProductPrice.CostPrice = Convert.ToDouble(txtCostPrice.Text);
                oProductPrice.TradePrice = Convert.ToDouble(txtTradePrice.Text);
                oProductPrice.NSP = Convert.ToDouble(txtNSP.Text);
                oProductPrice.RSP = Convert.ToDouble(txtRSP.Text);
                //oProductPrice.MRP = Convert.ToDouble(txtMRP.Text);
                oProductPrice.VAT = Convert.ToDouble(txtVAT.Text);
                oProductPrice.SpecialPrice = Convert.ToDouble(txtSpecialPrice.Text);
                oProductPrice.EffectiveDate = dtpEffectiveDate.Value;
                oProductPrice.IsCurrent = (int)Dictionary.IsCurrent.Yes;
                oProductPrice.EntryUserID = Utility.UserId;
                oProductPrice.UploadDate = DateTime.Now;

                oProductPrice.MC = Convert.ToDouble(txtMC.Text);
                oProductPrice.VATCP = Convert.ToDouble(txtVATCP.Text);
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
                oGetMaxPriceID.RefreshByProductID();
                if (oGetMaxPriceID.Flag == true)
                {
                    oDataSyncManager.SendProductPriceToShowroom(oGetMaxPriceID, Dictionary.DataTransferType.Add);
                }
                oProductPrices.ResetIsCurrent(nProductID);
                oProductPrice.Add();
                oDataSyncManager.SendProductPriceToShowroom(oProductPrice, Dictionary.DataTransferType.Add);

                #region Send Factory Data
                JobLocations _oJobLocations = new JobLocations();
                _oJobLocations.RefreshFactoryLocation();
                foreach (JobLocation oJobLocation in _oJobLocations)
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_Product";
                    oDataTran.DataID = nProductID;
                    oDataTran.WarehouseID = oJobLocation.JobLocationID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByLocationID() == false)
                    {
                        oDataTran.AddForFactory();
                    }
                }
                #endregion

                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message.ToString());
            }

            this.Close();
        }

        private void txtCostPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtCostPrice.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtCostPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCostPrice.Text = "";
                }

            }
        }

        private void txtTradePrice_TextChanged(object sender, EventArgs e)
        {
            if (txtTradePrice.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtTradePrice.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTradePrice.Text = "";
                }

            }
        }

        private void txtNSP_TextChanged(object sender, EventArgs e)
        {
            if (txtNSP.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtNSP.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNSP.Text = "";
                }

            }
        }

        private void txtRSP_TextChanged(object sender, EventArgs e)
        {
            if (txtRSP.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtRSP.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRSP.Text = "";
                }

            }
        }

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
            if (txtMRP.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtMRP.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMRP.Text = "";
                }

            }
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            if (txtVAT.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtVAT.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVAT.Text = "";
                }

            }
        }

        private void txtSpecialPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSpecialPrice.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtSpecialPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpecialPrice.Text = "";
                }

            }
        }

        private void txtMC_TextChanged(object sender, EventArgs e)
        {
            if (txtMC.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtMC.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMC.Text = "";
                }

            }
        }

        private void txtVATCP_TextChanged(object sender, EventArgs e)
        {
            if (txtVATCP.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtVATCP.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVATCP.Text = "";
                }

            }
        }
    }
}