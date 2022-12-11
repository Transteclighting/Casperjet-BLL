using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Promotion;
using CJ.Win.Security;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmMAGBrandWiseDiscounts : Form
    {

        private PromoDiscountMAGBrand oPromoDiscountMAGBrand;
        private PromoDiscountMAGBrands _oPromoDiscountMAGBrands;



        Brands oBrands;
        ProductGroups _oPG;
        ProductGroups _oMAG;

        public frmMAGBrandWiseDiscounts()
        {
            InitializeComponent();
        }

        private void frmMAGBrandWiseDiscounts_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
        }

        private void LoadCombos()
        {
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("ALL");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            //Load MAG
            _oMAG = new ProductGroups();
            _oMAG.GetMAG();
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("ALL");

            foreach (ProductGroup oMAG in _oMAG)
            {
                cmbMAG.Items.Add(oMAG.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;


            oBrands = new Brands();
            oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("ALL");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            //cmbStatus.Items.Clear();
            //cmbStatus.Items.Add("--ALL--");
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.BankDiscountStatus)))
            //{
            //    cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), GetEnum));
            //}
            //cmbStatus.SelectedIndex = 0;

            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("ALL");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;

            cmbSalesType.Items.Clear();
            cmbSalesType.Items.Add("ALL");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                if (GetEnum == (int)Dictionary.SalesType.B2C || GetEnum == (int)Dictionary.SalesType.Dealer)
                {
                    cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
                }
            }
            cmbSalesType.SelectedIndex = 0;
        }

        private void LoadData()
        {
            _oPromoDiscountMAGBrands = new PromoDiscountMAGBrands();
            lvwMAGBrandWiseDiscount.Items.Clear();
            int nPGID = 0;
            if (cmbPG.SelectedIndex == 0)
            {
                nPGID = -1;
            }
            else
            {
                nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAGID = 0;
            if (cmbMAG.SelectedIndex == 0)
            {
                nMAGID = -1;
            }
            else
            {
                nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nBarndID = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBarndID = -1;
            }
            else
            {
                nBarndID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int nSalesType = 0;

            if (cmbSalesType.SelectedIndex == 0)
            {
                nSalesType = -1;
            }
            else
            {
                nSalesType = (int)Enum.Parse(typeof(Dictionary.SalesType), cmbSalesType.SelectedItem.ToString());
            }

            //int nStatus = -1;
            //if (cmbStatus.SelectedIndex != 0)
            //{
            //    nStatus = cmbStatus.SelectedIndex;
            //}

            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }


            DBController.Instance.OpenNewConnection();
            _oPromoDiscountMAGBrands.RefreshForMagBrandWiseDiscount(nPGID, nMAGID,  nBarndID, nSalesType, nIsActive);
            this.Text = "MAG Brand Wise Discount List" + "[" + _oPromoDiscountMAGBrands.Count + "]";

            foreach (PromoDiscountMAGBrand oPromoDiscountMAGBrand in _oPromoDiscountMAGBrands)
            {
                ListViewItem oItem = lvwMAGBrandWiseDiscount.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), oPromoDiscountMAGBrand.SalesType));
                oItem.SubItems.Add(oPromoDiscountMAGBrand.PGName);
                oItem.SubItems.Add(oPromoDiscountMAGBrand.MAGName);
                oItem.SubItems.Add(oPromoDiscountMAGBrand.Brand);
                oItem.SubItems.Add(oPromoDiscountMAGBrand.DiscountPercent.ToString());
                oItem.SubItems.Add(oPromoDiscountMAGBrand.EffectiveDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPromoDiscountMAGBrand.CreateUserName);
                oItem.SubItems.Add(oPromoDiscountMAGBrand.CreateDate.ToString("dd-MMM-yyyy"));
                if (oPromoDiscountMAGBrand.ApproveUserName != "null")
                    oItem.SubItems.Add(oPromoDiscountMAGBrand.ApproveUserName.ToString());
                else oItem.SubItems.Add("N/A");
                if (oPromoDiscountMAGBrand.ApproveDate != "null")
                    oItem.SubItems.Add(oPromoDiscountMAGBrand.ApproveDate.ToString());
                else oItem.SubItems.Add("N/A");
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MAGBrandWiseDiscount), oPromoDiscountMAGBrand.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPromoDiscountMAGBrand.IsActive));
                oItem.SubItems.Add(oPromoDiscountMAGBrand.Remarks.ToString());
                oItem.Tag = oPromoDiscountMAGBrand;
            }
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwMAGBrandWiseDiscount.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwMAGBrandWiseDiscount.Items)
                {
                    if (oItem.SubItems[10].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[10].Text == "Create")
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMAGBrandWiseDiscount ofrmMAGBrandWiseDiscount = new frmMAGBrandWiseDiscount((int)Dictionary.MAGBrandWiseDiscount.Create);
            ofrmMAGBrandWiseDiscount.ShowDialog();
            if (ofrmMAGBrandWiseDiscount._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwMAGBrandWiseDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwMAGBrandWiseDiscount.SelectedItems[0].SubItems[10].Text == "Approved")
            {
                MessageBox.Show("Can't edit as it already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountMAGBrand _oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;
            string currentForm = "Edit";
            frmMAGBrandWiseDiscountEDIT ofrmMAGBrandWiseDiscountEDIT = new frmMAGBrandWiseDiscountEDIT((int)Dictionary.MAGBrandWiseDiscount.Create, currentForm);
           
            ofrmMAGBrandWiseDiscountEDIT.ShowDialog(_oPromoDiscountMAGBrand);
            if (ofrmMAGBrandWiseDiscountEDIT._bActionSave)
                LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwMAGBrandWiseDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwMAGBrandWiseDiscount.SelectedItems[0].SubItems[10].Text == "Approved")
            {
                MessageBox.Show("Can't edit as it already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountMAGBrand _oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;
            string currentForm = "Edit";
            frmMAGBrandWiseDiscountEDIT ofrmMAGBrandWiseDiscountEDIT = new frmMAGBrandWiseDiscountEDIT((int)Dictionary.MAGBrandWiseDiscount.Create, currentForm);

            ofrmMAGBrandWiseDiscountEDIT.ShowDialog(_oPromoDiscountMAGBrand);
            if (ofrmMAGBrandWiseDiscountEDIT._bActionSave)
                LoadData();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {

            if (lvwMAGBrandWiseDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwMAGBrandWiseDiscount.SelectedItems[0].SubItems[10].Text == "Approved")
            {
                MessageBox.Show("Can't edit as it already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;
            //if (oPromoDiscountMAGBrand.Status == ((int)Dictionary.MAGBrandWiseDiscount.Create))
            //{
            //    LoadData();
            //}
            //else
            //{
            //    MessageBox.Show("Approved Status Can't Be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            PromoDiscountMAGBrand _oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;
            string currentForm = "Approve";
            frmMAGBrandWiseDiscountEDIT ofrmMAGBrandWiseDiscountEDIT = new frmMAGBrandWiseDiscountEDIT((int)Dictionary.MAGBrandWiseDiscount.Approved, currentForm);
            ofrmMAGBrandWiseDiscountEDIT.ShowDialog(_oPromoDiscountMAGBrand);
            LoadData();


            //if (lvwMAGBrandWiseDiscount.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a Row to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;
            //if (oPromoDiscountMAGBrand.Status == ((int)Dictionary.MAGBrandWiseDiscount.Create))
            //{
            //    LoadData();
            //}
            //else
            //{
            //    MessageBox.Show("Approved Status Can't Be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //DialogResult oResult = MessageBox.Show("Are you sure you want to Approved : " + oPromoDiscountMAGBrand.DiscountID + " ? ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (oResult == DialogResult.Yes)
            //{
            //    try
            //    {
            //        DBController.Instance.BeginNewTransaction();
            //        oPromoDiscountMAGBrand.ApprovedBank();
            //        DBController.Instance.CommitTransaction();
            //        LoadData();
            //    }
            //    catch (Exception ex)
            //    {
            //        DBController.Instance.RollbackTransaction();
            //        MessageBox.Show(ex.Message, "Error!!!");
            //    }
            //}
        }

        private void lvwMAGBrandWiseDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwMAGBrandWiseDiscount.SelectedItems.Count == 0)
            {
                return;
            }
            PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;
            try
            {
                if (oPromoDiscountMAGBrand.IsActive==(int)Dictionary.IsActive.InActive)
                {
                    btnIsActive.Text = "Active";
                }
                else
                {
                    btnIsActive.Text = "InActive";
                }
                
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwMAGBrandWiseDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)lvwMAGBrandWiseDiscount.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure to perform this action", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();


                    int IsActive = 1;

                    if (btnIsActive.Text != "Active")
                    {
                        IsActive = 0;
                    }

                    oPromoDiscountMAGBrand.ChangeIsActiveStatus(IsActive);
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PromoDiscountMAGBrand";
                        oDataTran.DataID = Convert.ToInt32(oPromoDiscountMAGBrand.DiscountID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
    }
}
