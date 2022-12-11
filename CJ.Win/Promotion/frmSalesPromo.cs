// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: MAY 12, 2014
// Time : 05:40 PM
// Description: Sales Promotion for TD Corporate Customer
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
using CJ.Class.Promotion;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.Promotion
{
    public partial class frmSalesPromo : Form
    {
        Channels _oChannels;
        Showrooms _oShowrooms;
        ProductDetail _oProductDetail;
        SPromotion _oSPromotion;
        ProductGroups _oProductGroups;
        SalesPromotionTypes _oSalesPromotionTypes;
        int _nCount = 0;
        frmSearchProduct oSP;

        public frmSalesPromo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            _oSPromotion = new SPromotion();
            _oSPromotion = GetUIData(_oSPromotion);

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oSPromotion.Insert();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Data Save Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        
        }
        public SPromotion GetUIData(SPromotion oSPromotion)
        {
            oSPromotion.SalesPromotionName = txtDescription.Text;
            oSPromotion.CreateDate = DateTime.Today.Date;
            oSPromotion.FromDate = dtStartDate.Value.Date;
            oSPromotion.ToDate = dtEndDate.Value.Date;
            oSPromotion.EntryUserID = Utility.UserId;
            oSPromotion.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            if (rdoPercente.Checked == true)
            {
                oSPromotion.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Percent;
            }
            else if (rdoAmount.Checked == true)
            {
                oSPromotion.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Amount;
            }
            oSPromotion.DiscountPercent = Convert.ToDouble(txtDiscount.Text);

            // Channel 
            oSPromotion.SPChannels.Clear();
            for (int i = 0; i < lvwChannel.Items.Count; i++)
            {
                ListViewItem itm = lvwChannel.Items[i];
                if (lvwChannel.Items[i].Checked == true)
                {
                    Channel oChannel = (Channel)lvwChannel.Items[i].Tag;
                    SPChannel oSPChannel = new SPChannel();

                    oSPChannel.ChannelID = oChannel.ChannelID;

                    oSPromotion.SPChannels.Add(oSPChannel);
                }
            }
            // Showroom
            oSPromotion.Showrooms.Clear();
            for (int i = 0; i < lvwOutlet.Items.Count; i++)
            {
                ListViewItem itm = lvwOutlet.Items[i];
                if (lvwOutlet.Items[i].Checked == true)
                {
                    Showroom oShowroom = (Showroom)lvwOutlet.Items[i].Tag;
                    Showroom _oShowroom = new Showroom();
                    _oShowroom.WarehouseID = oShowroom.WarehouseID;

                    oSPromotion.Showrooms.Add(_oShowroom);
                }
            }
            // Sale Promotion Type 
            oSPromotion.SPTypes.Clear();
            for (int i = 0; i < lvwPromotionType.Items.Count; i++)
            {
                ListViewItem itm = lvwPromotionType.Items[i];
                if (lvwPromotionType.Items[i].Checked == true)
                {
                    SalesPromotionType oSalesPromotionType = (SalesPromotionType)lvwPromotionType.Items[i].Tag;
                    SPType oSPType = new SPType();

                    oSPType.SalesPromotionTypeID = oSalesPromotionType.SalesPromotionTypeID;

                    oSPromotion.SPTypes.Add(oSPType);
                }
            }
            // Product Group
            oSPromotion.ProductGroups.Clear();
            for (int i = 0; i < lvwProductGroup.Items.Count; i++)
            {
                ListViewItem itm = lvwProductGroup.Items[i];
                if (lvwProductGroup.Items[i].Checked == true)
                {
                    if ((int)Dictionary.ProductGroupType.Product == cmbProductGroupType.SelectedIndex + 1)
                    {
                        ProductDetail oProductDetail = (ProductDetail)lvwProductGroup.Items[i].Tag;
                        ProductGroup _oProductGroup = new ProductGroup();
                        _oProductGroup.PdtGroupID = oProductDetail.ProductID;
                        _oProductGroup.PdtGroupType = (int)Dictionary.ProductGroupType.Product;
                        oSPromotion.ProductGroups.Add(_oProductGroup);
                    }
                    else
                    {
                        ProductGroup oProductGroup = (ProductGroup)lvwProductGroup.Items[i].Tag;
                        ProductGroup _oProductGroup = new ProductGroup();
                        _oProductGroup.PdtGroupID = oProductGroup.PdtGroupID;
                        _oProductGroup.PdtGroupType = oProductGroup.PdtGroupType;
                        oSPromotion.ProductGroups.Add(_oProductGroup);
                    }

                }
            }
            return oSPromotion;
        }
        private bool UIValidation()
        {
            int nCount = 0;
            //if (txtPromotionNo.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Input Promotion Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPromotionNo.Focus();
            //    return false;
            //}
            if (this.Tag == null)
            {
                if (dtStartDate.Value < DateTime.Today.Date)
                {
                    MessageBox.Show("Effect strat date must greater than System date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtStartDate.Focus();
                    return false;
                }
            }
            if (dtEndDate.Value < dtStartDate.Value)
            {
                MessageBox.Show("Effect to date must greater than Effect strat date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEndDate.Focus();
                return false;
            }
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Promotion Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }
            if (rdoPercente.Checked == true)
            {
                if (txtDiscount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Discount Percent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
            }
            else
            {
                if (txtDiscount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Discount Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
            }

            for (int i = 0; i < lvwChannel.Items.Count; i++)
            {
                ListViewItem itm = lvwChannel.Items[i];
                if (lvwChannel.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least a Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            nCount = 0;
            for (int i = 0; i < lvwOutlet.Items.Count; i++)
            {
                ListViewItem itm = lvwOutlet.Items[i];
                if (lvwOutlet.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least an Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            nCount = 0;
            for (int i = 0; i < lvwProductGroup.Items.Count; i++)
            {
                ListViewItem itm = lvwProductGroup.Items[i];
                if (lvwProductGroup.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least a Product Group", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            nCount = 0;
            for (int i = 0; i < lvwPromotionType.Items.Count; i++)
            {
                ListViewItem itm = lvwPromotionType.Items[i];
                if (lvwPromotionType.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least one Promotion Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesPromo_Load(object sender, EventArgs e)
        {
            rdoPercente.Checked = true;
            Loadlvw();
        }
        public void Loadlvw()
        {
            DBController.Instance.OpenNewConnection();
            _oChannels = new Channels();
            _oChannels.RefreshForPromotion();
            lvwChannel.Items.Clear();
            foreach (Channel oChannel in _oChannels)
            {
                ListViewItem oItem = lvwChannel.Items.Add(oChannel.ChannelCode);
                oItem.SubItems.Add(oChannel.ChannelDescription);
                oItem.Tag = oChannel;
            }
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            lvwOutlet.Items.Clear();
            foreach (Showroom oShowroom in _oShowrooms)
            {
                ListViewItem oItem = lvwOutlet.Items.Add(oShowroom.ShowroomCode);
                oItem.SubItems.Add(oShowroom.ShowroomName);
                oItem.Tag = oShowroom;
            }
            cmbProductGroupType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductGroupType)))
            {
                cmbProductGroupType.Items.Add(Enum.GetName(typeof(Dictionary.ProductGroupType), GetEnum));
            }
            cmbProductGroupType.SelectedIndex = 0;

            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh();
            lvwPromotionType.Items.Clear();
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                ListViewItem oItem = lvwPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
                oItem.Tag = oSalesPromotionType;
            }

            _oProductGroups = new ProductGroups();
            _oProductGroups.Refresh(Dictionary.ProductGroupType.ProductGroup);
            lvwProductGroup.Items.Clear();
            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                ListViewItem oItem = lvwProductGroup.Items.Add(oProductGroup.PdtGroupCode);
                oItem.SubItems.Add(oProductGroup.PdtGroupName);
                oItem.Tag = oProductGroup;
            }
        }

        private void cmbProductGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool nIsSKU = false;
            _oProductGroups = new ProductGroups();
            if ((int)Dictionary.ProductGroupType.ProductGroup == cmbProductGroupType.SelectedIndex + 1)
            {
                nIsSKU = false;
                _oProductGroups.Refresh(Dictionary.ProductGroupType.ProductGroup);
                chkProductGroup.Text = "Check All";
                chkProductGroup.Checked = false;
            }
            else if ((int)Dictionary.ProductGroupType.MAG == cmbProductGroupType.SelectedIndex + 1)
            {
                nIsSKU = false;
                _oProductGroups.Refresh(Dictionary.ProductGroupType.MAG);
                chkProductGroup.Text = "Check All";
                chkProductGroup.Checked = false;
            }
            else if ((int)Dictionary.ProductGroupType.ASG == cmbProductGroupType.SelectedIndex + 1)
            {
                nIsSKU = false;
                _oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
                chkProductGroup.Text = "Check All";
                chkProductGroup.Checked = false;
            }
            else if ((int)Dictionary.ProductGroupType.AG == cmbProductGroupType.SelectedIndex + 1)
            {
                nIsSKU = false;
                _oProductGroups.Refresh(Dictionary.ProductGroupType.AG);
                chkProductGroup.Text = "Check All";
                chkProductGroup.Checked = false;
            }
            else if ((int)Dictionary.ProductGroupType.Product == cmbProductGroupType.SelectedIndex + 1)
            {
                nIsSKU = true;
                oSP = new frmSearchProduct(2);
                oSP.ShowDialog();
            }
            
            if (nIsSKU)
            {
                ProductDetails oPDs = new ProductDetails();
                oPDs = oSP._oProductDetails;
                if (oPDs != null)
                {
                    lvwProductGroup.Items.Clear();
                    foreach (ProductDetail oProductDetail in oPDs)
                    {
                        ListViewItem oItem = lvwProductGroup.Items.Add(oProductDetail.ProductCode);
                        oItem.SubItems.Add(oProductDetail.ProductName);
                        oItem.Tag = oProductDetail;
                    }
                    for (int i = 0; i < lvwProductGroup.Items.Count; i++)
                    {
                        ListViewItem itm = lvwProductGroup.Items[i];
                        lvwProductGroup.Items[i].Checked = true;
                    }
                    chkProductGroup.Text = "Uncheck All";
                    chkProductGroup.Checked = true;
                }
            }
            else
            {
                lvwProductGroup.Items.Clear();
                foreach (ProductGroup oProductGroup in _oProductGroups)
                {
                    ListViewItem oItem = lvwProductGroup.Items.Add(oProductGroup.PdtGroupCode);
                    oItem.SubItems.Add(oProductGroup.PdtGroupName);
                    oItem.Tag = oProductGroup;
                }
            }
        }

        private void chkOutlet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOutlet.Checked == true)
            {
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];
                    lvwOutlet.Items[i].Checked = true;
                }
                chkOutlet.Text = "Uncheck All";
            }
            else
            {
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];
                    lvwOutlet.Items[i].Checked = false;

                }
                chkOutlet.Text = "Check All";
            }
        }

        private void chkProductGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProductGroup.Checked == true)
            {
                for (int i = 0; i <lvwProductGroup.Items.Count; i++)
                {
                    ListViewItem itm = lvwProductGroup.Items[i];
                    lvwProductGroup.Items[i].Checked = true;
                }
                chkProductGroup.Text = "Uncheck All";
            }
            else
            {
                for (int i = 0; i < lvwProductGroup.Items.Count; i++)
                {
                    ListViewItem itm = lvwProductGroup.Items[i];
                    lvwProductGroup.Items[i].Checked = false;

                }
                chkProductGroup.Text = "Check All";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Trim() != "")
            {
                try
                {
                    double tmp = Convert.ToDouble(txtDiscount.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Please enter valid Discount Percent", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiscount.Focus();
                }
            }
        }

        private void chkPromoTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPromoTypeAll.Checked == true)
            {
                for (int i = 0; i < lvwPromotionType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPromotionType.Items[i];
                    lvwPromotionType.Items[i].Checked = true;
                }
                chkPromoTypeAll.Text = "Uncheck All";
            }
            else
            {
                for (int i = 0; i < lvwPromotionType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPromotionType.Items[i];
                    lvwPromotionType.Items[i].Checked = false;

                }
                chkPromoTypeAll.Text = "Check All";
            }
        }

        private void rdoPercente_CheckedChanged(object sender, EventArgs e)
        {
            lblPercent.Text = "%";
        }

        private void rdoAmount_CheckedChanged(object sender, EventArgs e)
        {
            lblPercent.Text = "Amount";
        }

    }
}