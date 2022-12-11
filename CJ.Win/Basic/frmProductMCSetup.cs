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
    public partial class frmProductMCSetup : Form
    {
        public frmProductMCSetup()
        {
            InitializeComponent();
        }

        public void ShowDialog(Product oProduct)
        {
            this.Tag = oProduct;
            ctlProduct1.txtCode.Text = oProduct.ProductCode;
            this.ShowDialog();
        }

        private void frmProductMCSetup_Load(object sender, EventArgs e)
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

        private void CtlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
            {
                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;

                DBController.Instance.OpenNewConnection();
                oProductPrice.RefreshByProductIDMC();
                DBController.Instance.CloseConnection();

                txterpcode.Text = oProductPrice.ERPCode.ToString();
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
                //if (Utility.CompanyInfo == "BLL")
                //{
                //    txterpcode.Text = oProductPrice.ERPCode.ToString();
                //    txtcogs.Text = oProductPrice.COGS.ToString("0.00");
                //    txtmatrial.Text = oProductPrice.VCMaterial.ToString("0.00");
                //    txtfactory.Text = oProductPrice.VCVariableFactory.ToString("0.00");
                //    txtlabour.Text = oProductPrice.VCDirectLabor.ToString("0.00");
                //    txtfright.Text = Convert.ToString(oProductPrice.FreightCost * 100);
                //    txtreplacement.Text = Convert.ToString(oProductPrice.Replacement * 100);
                //    txtadv.Text = Convert.ToString(oProductPrice.Advertisement * 100);
                //    txtretail.Text = Convert.ToString(oProductPrice.TPRetailOffer * 100);
                //    txtdbinc.Text = Convert.ToString(oProductPrice.TPDBIncentive * 100);
                //    txttemainc.Text = Convert.ToString(oProductPrice.TPTeamIncentive * 100);
                //    txtyearinc.Text = Convert.ToString(oProductPrice.TPYearlyIncentive * 100);
                //    txtroyality.Text = Convert.ToString(oProductPrice.Royality * 100);
                //    txtdbtax.Text = Convert.ToString(oProductPrice.DistributorTax * 100);

                //}

                //else
                //{
                //    txterpcode.Enabled = false;
                //    txtcogs.Enabled = false;
                //    txtmatrial.Enabled = false;
                //    txtfactory.Enabled = false;
                //    txtlabour.Enabled = false;
                //    txtfright.Enabled = false;
                //    txtreplacement.Enabled = false;
                //    txtadv.Enabled = false;
                //    txtretail.Enabled = false;
                //    txtdbinc.Enabled = false;
                //    txttemainc.Enabled = false;
                //    txtyearinc.Enabled = false;
                //    txtroyality.Enabled = false;
                //    txtdbtax.Enabled = false;
                //}

                LoadMCList();
            }
        }

        private void LoadMCList()
        {
            ProductPrices oProductPrices = new ProductPrices();
            DBController.Instance.OpenNewConnection();

            oProductPrices.RefreshforBLL(ctlProduct1.SelectedSerarchProduct.ProductID);

            //if (Utility.CompanyInfo == "BLL")
            //{
            //    oProductPrices.RefreshforBLL(ctlProduct1.SelectedSerarchProduct.ProductID);

            //}
            //else
            //{
            //    oProductPrices.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID);

            //}

            //oProductPrices.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID);
            DBController.Instance.CloseConnection();

            lvwProductMC.Items.Clear();
            string sDateRange = " to Till Now";
            foreach (ProductPrice oProductPrice in oProductPrices)
            {
                sDateRange = oProductPrice.EffectiveDate.ToShortDateString() + sDateRange;
                ListViewItem oItem = lvwProductMC.Items.Add(sDateRange);
                sDateRange = " to " + oProductPrice.EffectiveDate.AddDays(-1).ToShortDateString();
                //oItem.SubItems.Add(oProductPrice.CostPrice.ToString("0.00"));
                //oItem.SubItems.Add(oProductPrice.TradePrice.ToString("0.00"));
                //oItem.SubItems.Add(oProductPrice.NSP.ToString("0.00"));
                //oItem.SubItems.Add(oProductPrice.RSP.ToString("0.00"));
                //oItem.SubItems.Add("");
                //oItem.SubItems.Add(oProductPrice.VAT.ToString("0.00"));
                //oItem.SubItems.Add(oProductPrice.SpecialPrice.ToString("0.00"));
                //oItem.SubItems.Add(oProductPrice.MC.ToString("0.00"));
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
                    oItem.ForeColor = Color.Blue;
                oItem.Tag = oProductPrice;
            }
        }

        //private void btnApply_Click(object sender, EventArgs e)
        //{


        //    Save();
        //    this.Close();

        //    //if (validateUIInput())
        //    //{
        //    //    if (Utility.CompanyInfo == "BLL")
        //    //    {
        //    //        SaveforBLL();
        //    //        this.Close();
        //    //    }
        //    //    else
        //    //    {
        //    //        Save();
        //    //        this.Close();
        //    //    }
        //    //    //    Save();
        //    //    //this.Close();
        //    //}
        //}

        private void Save()
        {
            DataSyncManager oDataSyncManager = new DataSyncManager();

            int nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            try
            {
                ProductPrices oProductPrices = new ProductPrices();

                ProductPrice oProductPrice = new ProductPrice();
                oProductPrice.ProductID = nProductID;
                //oProductPrice.CostPrice = Convert.ToDouble(txtCostPrice.Text);
                //oProductPrice.TradePrice = Convert.ToDouble(txtTradePrice.Text);
                //oProductPrice.NSP = Convert.ToDouble(txtNSP.Text);
                //oProductPrice.RSP = Convert.ToDouble(txtRSP.Text);
                ////oProductPrice.MRP = Convert.ToDouble(txtMRP.Text);
                //oProductPrice.VAT = Convert.ToDouble(txtVAT.Text);
                //oProductPrice.SpecialPrice = Convert.ToDouble(txtSpecialPrice.Text);

                //oProductPrice.EntryUserID = Utility.UserId;
                //oProductPrice.UploadDate = DateTime.Now;

                //oProductPrice.MC = Convert.ToDouble(txtMC.Text);

                oProductPrice.ERPCode = txterpcode.Text;
                oProductPrice.COGS = Convert.ToDouble(txtcogs.Text);
                oProductPrice.VCMaterial = Convert.ToDouble(txtmatrial.Text);
                oProductPrice.VCVariableFactory = Convert.ToDouble(txtfactory.Text);
                oProductPrice.VCDirectLabor = Convert.ToDouble(txtlabour.Text);

                //Convert.ToString(Math.Round((oDSDataRow.LMValue / oDSDataRow.LMTValue) * 100));

                //Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)).ToString();

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
                //oGetMaxPriceID.RefreshByProductID();
                oGetMaxPriceID.RefreshByProductIDMC();
                //if (oGetMaxPriceID.Flag == true)
                //{
                //    oDataSyncManager.SendProductPriceToShowroom(oGetMaxPriceID, Dictionary.DataTransferType.Add);
                //}
                oProductPrices.ResetIsCurrentMC(nProductID);
                //oProductPrice.Add();
                oProductPrice.AddMC();
                //oDataSyncManager.SendProductPriceToShowroom(oProductPrice, Dictionary.DataTransferType.Add);

                //#region Send Factory Data
                //JobLocations _oJobLocations = new JobLocations();
                //_oJobLocations.RefreshFactoryLocation();
                //foreach (JobLocation oJobLocation in _oJobLocations)
                //{
                //    DataTran oDataTran = new DataTran();
                //    oDataTran.TableName = "t_Product";
                //    oDataTran.DataID = nProductID;
                //    oDataTran.WarehouseID = oJobLocation.JobLocationID;
                //    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                //    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //    oDataTran.BatchNo = 0;
                //    if (oDataTran.CheckDataByLocationID() == false)
                //    {
                //        oDataTran.AddForFactory();
                //    }
                //}
                //#endregion

                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message.ToString());
            }

            this.Close();
        }

        //private void ctlProduct1_changeSelection(object sender, EventArgs e)
        //{
        //    if (ctlProduct1.SelectedSerarchProduct != null && ctlProduct1.txtCode.Text != "")
        //    {
        //        ProductPrice oProductPrice = new ProductPrice();
        //        oProductPrice.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;

        //        DBController.Instance.OpenNewConnection();
        //        oProductPrice.RefreshByProductIDMC();
        //        DBController.Instance.CloseConnection();

        //        txterpcode.Text = oProductPrice.ERPCode.ToString();
        //        txtcogs.Text = oProductPrice.COGS.ToString("0.00");
        //        txtmatrial.Text = oProductPrice.VCMaterial.ToString("0.00");
        //        txtfactory.Text = oProductPrice.VCVariableFactory.ToString("0.00");
        //        txtlabour.Text = oProductPrice.VCDirectLabor.ToString("0.00");
        //        txtfright.Text = Convert.ToString(oProductPrice.FreightCost * 100);
        //        txtreplacement.Text = Convert.ToString(oProductPrice.Replacement * 100);
        //        txtadv.Text = Convert.ToString(oProductPrice.Advertisement * 100);
        //        txtretail.Text = Convert.ToString(oProductPrice.TPRetailOffer * 100);
        //        txtdbinc.Text = Convert.ToString(oProductPrice.TPDBIncentive * 100);
        //        txttemainc.Text = Convert.ToString(oProductPrice.TPTeamIncentive * 100);
        //        txtyearinc.Text = Convert.ToString(oProductPrice.TPYearlyIncentive * 100);
        //        txtroyality.Text = Convert.ToString(oProductPrice.Royality * 100);
        //        txtdbtax.Text = Convert.ToString(oProductPrice.DistributorTax * 100);

        //        if (oProductPrice.Flag == true)
        //        {
        //            dtpEffectiveDate.Value = oProductPrice.EffectiveDate.Date;
        //        }
        //        //if (Utility.CompanyInfo == "BLL")
        //        //{
        //        //    txterpcode.Text = oProductPrice.ERPCode.ToString();
        //        //    txtcogs.Text = oProductPrice.COGS.ToString("0.00");
        //        //    txtmatrial.Text = oProductPrice.VCMaterial.ToString("0.00");
        //        //    txtfactory.Text = oProductPrice.VCVariableFactory.ToString("0.00");
        //        //    txtlabour.Text = oProductPrice.VCDirectLabor.ToString("0.00");
        //        //    txtfright.Text = Convert.ToString(oProductPrice.FreightCost * 100);
        //        //    txtreplacement.Text = Convert.ToString(oProductPrice.Replacement * 100);
        //        //    txtadv.Text = Convert.ToString(oProductPrice.Advertisement * 100);
        //        //    txtretail.Text = Convert.ToString(oProductPrice.TPRetailOffer * 100);
        //        //    txtdbinc.Text = Convert.ToString(oProductPrice.TPDBIncentive * 100);
        //        //    txttemainc.Text = Convert.ToString(oProductPrice.TPTeamIncentive * 100);
        //        //    txtyearinc.Text = Convert.ToString(oProductPrice.TPYearlyIncentive * 100);
        //        //    txtroyality.Text = Convert.ToString(oProductPrice.Royality * 100);
        //        //    txtdbtax.Text = Convert.ToString(oProductPrice.DistributorTax * 100);

        //        //}

        //        //else
        //        //{
        //        //    txterpcode.Enabled = false;
        //        //    txtcogs.Enabled = false;
        //        //    txtmatrial.Enabled = false;
        //        //    txtfactory.Enabled = false;
        //        //    txtlabour.Enabled = false;
        //        //    txtfright.Enabled = false;
        //        //    txtreplacement.Enabled = false;
        //        //    txtadv.Enabled = false;
        //        //    txtretail.Enabled = false;
        //        //    txtdbinc.Enabled = false;
        //        //    txttemainc.Enabled = false;
        //        //    txtyearinc.Enabled = false;
        //        //    txtroyality.Enabled = false;
        //        //    txtdbtax.Enabled = false;
        //        //}

        //        LoadMCList();
        //    }
        //}

        private void btnApply_Click_1(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void lvwProductMC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
