using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Promotion;

namespace CJ.Win.Promotion
{
    public partial class frmSalesPromotionCentral : Form
    {
        Channels oChannels;
        CustomerTypies _oCustomerTypies;
        ProductDetail _oProductDetail;
        SPromotion _oSPromotion;
        SalesPromotionSlab _oSalesPromotionSlab;
        int nPromotionID = 0;

        public frmSalesPromotionCentral()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oChannels = new Channels();
            oChannels.RefreshForPromotion();
            lvwChannel.Items.Clear();
            foreach (Channel oChannel in oChannels)
            {
                ListViewItem oItem = lvwChannel.Items.Add(oChannel.ChannelCode);
                oItem.SubItems.Add(oChannel.ChannelDescription);
                oItem.Tag = oChannel;
            }

            _oCustomerTypies = new CustomerTypies();
            _oCustomerTypies.GetCustTypeChannel();
            lvwCustomerType.Items.Clear();
            foreach (CustomerType oCustomerType in _oCustomerTypies)
            {
                ListViewItem oItem = lvwCustomerType.Items.Add(oCustomerType.CustTypeDescription + "[" + oCustomerType.CustTypeCode + "]");
                oItem.SubItems.Add(oCustomerType.ChannelDescription);
                oItem.Tag = oCustomerType;
            }

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
            if (this.Tag == null)
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
            else
            {
                _oSPromotion = new SPromotion();
                _oSPromotion = GetUIData(_oSPromotion);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSPromotion.SalesPromotionID = nPromotionID;
                    _oSPromotion.ForQty = Convert.ToInt32(txtForQty.Text.Trim());
                    _oSPromotion.UpdateCentral();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Update Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
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
            oSPromotion.ForQty = Convert.ToInt32(txtForQty.Text.Trim());
            if (rdoPercente.Checked == true)
            {
                oSPromotion.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Percent;
                oSPromotion.DiscountPercent = Convert.ToDouble(txtDiscount.Text);
            }
            else if (rdoAmount.Checked == true)
            {
                oSPromotion.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Amount;
                oSPromotion.DiscountPercent = Convert.ToDouble(txtDiscount.Text);
            }
            else
            {
                oSPromotion.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Product;
                oSPromotion.DiscountPercent = 0;
            }

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
            
            // Sale Promotion Customer Type 
            oSPromotion.SPCustomerTypes.Clear();
            for (int i = 0; i < lvwCustomerType.Items.Count; i++)
            {
                ListViewItem itm = lvwCustomerType.Items[i];
                if (lvwCustomerType.Items[i].Checked == true)
                {
                    CustomerType oCustomerType = (CustomerType)lvwCustomerType.Items[i].Tag;
                    SPCustomerType oSPCustomerType = new SPCustomerType();

                    oSPCustomerType.CustTypeID = oCustomerType.CustTypeID;

                    oSPromotion.SPCustomerTypes.Add(oSPCustomerType);
                }
            }
            // Promo Product
            foreach (DataGridViewRow oItemRow in dgvPromoProduct.Rows)
            {
                if (oItemRow.Index < dgvPromoProduct.Rows.Count - 1)
                {
                   
                    ProductGroup _oProductGroup = new ProductGroup();
                    _oProductGroup.PdtGroupID = Convert.ToInt32(oItemRow.Cells[3].Value);
                    _oProductGroup.PdtGroupType = (int)Dictionary.ProductGroupType.Product;
                    oSPromotion.ProductGroups.Add(_oProductGroup);
                }
            }

            //Slab
            if (rdoProduct.Checked == true)
            {
                int nSlabName = 1;
                _oSalesPromotionSlab = new SalesPromotionSlab();
                _oSalesPromotionSlab.SlabNo = 1;
                _oSalesPromotionSlab.SlabName = nSlabName.ToString();
                _oSalesPromotionSlab.IsActive = (int)Dictionary.ActiveOrInActiveStatus.ACTIVE;
                if (rdoPercente.Checked == true)
                {
                    _oSalesPromotionSlab.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Percent;
                    _oSalesPromotionSlab.Discount = Convert.ToDouble(txtDiscount.Text);
                }
                else if (rdoAmount.Checked == true)
                {
                    _oSalesPromotionSlab.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Amount;
                    _oSalesPromotionSlab.Discount = Convert.ToDouble(txtDiscount.Text);
                }
                else
                {
                    _oSalesPromotionSlab.DiscountType = (int)Dictionary.SalesPromotionDiscountType.Product;
                    _oSalesPromotionSlab.Discount = 0;
                }


                // Offer Product 
                _oSalesPromotionSlab.SPFreeProducts.Clear();
                if (dgvOfferProduct.Rows.Count > 1)
                {
                    foreach (DataGridViewRow oItemRow in dgvOfferProduct.Rows)
                    {
                        if (oItemRow.Index < dgvOfferProduct.Rows.Count - 1)
                        {
                            SPFreeProduct oSPFreeProduct = new SPFreeProduct();

                            oSPFreeProduct.ProductID = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                            oSPFreeProduct.Qty = int.Parse(oItemRow.Cells[3].Value.ToString().Trim());

                            _oSalesPromotionSlab.SPFreeProducts.Add(oSPFreeProduct);
                        }
                    }
                }
                _oSPromotion.Add(_oSalesPromotionSlab);
            }
            return oSPromotion;
        }
        private bool UIValidation()
        {
            int nCount = 0;

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
            nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvPromoProduct.Rows)
            {
                if (oItemRow.Index < dgvPromoProduct.Rows.Count - 1)
                {
                    if (oItemRow.Cells[3].Value.ToString().Trim() != "")
                    {

                        nCount++;
                    }
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please enter Promotional Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            nCount = 0;
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
            for (int i = 0; i < lvwCustomerType.Items.Count; i++)
            {
                ListViewItem itm = lvwCustomerType.Items[i];
                if (lvwCustomerType.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least a Customer Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtForQty.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtForQty.Focus();
                return false;
            }
            else
            {
                try
                {
                    int temp = Convert.ToInt32(txtForQty.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Please enter valid Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtForQty.Focus();
                    return false;
                }
            }
            if (rdoPercente.Checked == true)
            {
                if (txtDiscount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Discount Percent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
                else
                {
                    try
                    {
                        double temp = Convert.ToDouble(txtDiscount.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("Please enter valid Discount Percent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDiscount.Focus();
                        return false;
                    }
                }
            }
            else if (rdoAmount.Checked == true)
            {
                if (txtDiscount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Discount Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
                else
                {
                    try
                    {
                        double temp = Convert.ToDouble(txtDiscount.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("Please enter valid Discount Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDiscount.Focus();
                        return false;
                    }
                }
            }
            else
            {

                nCount = 0;
                foreach (DataGridViewRow oItemRow in dgvOfferProduct.Rows)
                {
                    if (oItemRow.Index < dgvOfferProduct.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[4].Value.ToString().Trim() != "")
                        {
                            nCount++;
                        }
                    }
                }
                if (nCount == 0)
                {
                    MessageBox.Show("Please enter Offer Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    foreach (DataGridViewRow oItemRow in dgvOfferProduct.Rows)
                    {
                        if (oItemRow.Index < dgvOfferProduct.Rows.Count - 1)
                        {
                            if (oItemRow.Cells[3].Value != null && oItemRow.Cells[3].Value.ToString().Trim() != "")
                            {
                                try
                                {
                                    int temp = Convert.ToInt32(oItemRow.Cells[3].Value);
                                }
                                catch
                                {
                                    MessageBox.Show("Please enter valid Offer Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter Offer Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

            }

            
            
            return true;
        }
        private void frmSalesPromotionCentral_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadData();
                rdoProduct.Checked = true;
            }
        }
        private void rdoProduct_CheckedChanged(object sender, EventArgs e)
        {
            dgvOfferProduct.Enabled = true;
            txtDiscount.Enabled = false;
            lblPercent.Enabled = false;
        }
        private void rdoPercente_CheckedChanged(object sender, EventArgs e)
        {
            lblPercent.Text = "%";
            dgvOfferProduct.Enabled = false;
            txtDiscount.Enabled = true;
            lblPercent.Enabled = true;
        }
        private void rdoAmount_CheckedChanged(object sender, EventArgs e)
        {
            lblPercent.Text = "Amount";
            dgvOfferProduct.Enabled = false;
            txtDiscount.Enabled = true;
            lblPercent.Enabled = true;
        }
        private void dgvPromoProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {

                frmSearchProduct oForm = new frmSearchProduct(2);
                oForm.ShowDialog();
                if (oForm._oProductDetails != null)
                {
                        ProductDetails oProductDetails = new ProductDetails();
                        oProductDetails = oForm._oProductDetails;
                        if (oProductDetails.Count > 0)
                        {
                            foreach (ProductDetail oProductDetail in oProductDetails)
                            {
                                DataGridViewRow oRow = new DataGridViewRow();
                                oRow.CreateCells(dgvPromoProduct);
                                oRow.Cells[0].Value = oProductDetail.ProductCode;
                                oRow.Cells[2].Value = oProductDetail.ProductName;
                                oRow.Cells[3].Value = oProductDetail.ProductID;

                                if (oProductDetail.ProductCode != null)
                                {
                                    nRowIndex = dgvPromoProduct.Rows.Add(oRow);
                                    if (checkDuplicateLineItem(dgvPromoProduct.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                                    {
                                        oRow.Cells[2].Value = "";
                                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        dgvPromoProduct.Rows.RemoveAt(nRowIndex);
                                        return;
                                    }
                                    else
                                    {
                                        dgvPromoProduct.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                                    }
                                }
                            }
                        }
                }

            }
           
        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvPromoProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvPromoProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPromoProduct.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvPromoProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    dgvPromoProduct.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                    dgvPromoProduct.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = (_oProductDetail.ProductID).ToString();

                    dgvPromoProduct.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvPromoProduct.Rows)
            {
                if (oItemRow.Index < dgvPromoProduct.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }
        private int checkDuplicateOfferItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvOfferProduct.Rows)
            {
                if (oItemRow.Index < dgvOfferProduct.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }
        private void dgvPromoProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void dgvOfferProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRowOffer(e.RowIndex, e.ColumnIndex);
        }
        private void dgvOfferProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {

                frmSearchProduct oForm = new frmSearchProduct(2);
                oForm.ShowDialog();
                if (oForm._oProductDetails != null)
                {
                    ProductDetails oProductDetails = new ProductDetails();
                    oProductDetails = oForm._oProductDetails;
                    if (oProductDetails.Count > 0)
                    {
                        foreach (ProductDetail oProductDetail in oProductDetails)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvOfferProduct);
                            oRow.Cells[0].Value = oProductDetail.ProductCode;
                            oRow.Cells[2].Value = oProductDetail.ProductName;
                            oRow.Cells[4].Value = oProductDetail.ProductID;

                            if (oProductDetail.ProductCode != null)
                            {
                                nRowIndex = dgvOfferProduct.Rows.Add(oRow);
                                if (checkDuplicateOfferItem(dgvOfferProduct.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                                {
                                    oRow.Cells[2].Value = "";
                                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvOfferProduct.Rows.RemoveAt(nRowIndex);
                                    return;
                                }
                                else
                                {
                                    dgvOfferProduct.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                                }
                            }
                        }
                    }
                }

            }
        }
        private void RefreshRowOffer(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvOfferProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateOfferItem(dgvOfferProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvOfferProduct.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvOfferProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    dgvOfferProduct.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                    dgvOfferProduct.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oProductDetail.ProductID).ToString();

                    dgvOfferProduct.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
        public void ShowDialog(SPromotion _oSPromotion)
        {
            this.Tag = _oSPromotion;
            int nDiscountType = 0;
            int nCount = 0;
            double _Discount = 0;
            LoadData();
            txtPromotionNo.Text = _oSPromotion.SalesPromotionNo.ToString();
            txtDescription.Text = _oSPromotion.SalesPromotionName;
            dtStartDate.Value = _oSPromotion.FromDate.Date;
            dtEndDate.Value = _oSPromotion.ToDate.Date;

            //if (_oSPromotion.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            //{
            //    rdoActive.Checked = true;
            //}
            //else
            //{
            //    rdoActive.Checked = false;
            //}

            SPForQty oSPForQty = new SPForQty();
            oSPForQty.Refresh(_oSPromotion.SalesPromotionID);
            txtForQty.Text = oSPForQty.Qty.ToString();

            SPProductGroups oSPPGs = new SPProductGroups();
            oSPPGs.RefreshForSKU(_oSPromotion.SalesPromotionID);
            foreach (SPProductGroup oSPPG in oSPPGs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPromoProduct);
                oRow.Cells[0].Value = oSPPG.ProductCode;
                oRow.Cells[2].Value = oSPPG.ProductName;
                oRow.Cells[3].Value = oSPPG.ProductGroupID;

                dgvPromoProduct.Rows.Add(oRow);

                if (nCount == 0)
                {
                    nDiscountType = oSPPG.DiscountType;
                    _Discount = oSPPG.DiscountPercentage;
                    nCount++;
                }
            
            }

            if (nDiscountType == (int)Dictionary.SalesPromotionDiscountType.Product)
            {
                rdoProduct.Checked = true;

                SPromotion oSP = new SPromotion();
                SPFreeProducts oSPFreeProducts = new SPFreeProducts();
                oSPFreeProducts.Refresh(oSP.GetCPSID(_oSPromotion.SalesPromotionID));

                foreach (SPFreeProduct oSPFreeProduct in oSPFreeProducts)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvOfferProduct);
                    oRow.Cells[0].Value = oSPFreeProduct.ProductCode;
                    oRow.Cells[2].Value = oSPFreeProduct.ProductName;
                    oRow.Cells[3].Value = oSPFreeProduct.Qty;
                    oRow.Cells[4].Value = oSPFreeProduct.ProductID;

                    dgvOfferProduct.Rows.Add(oRow);
                }

            }
            else if (nDiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
            {
                rdoPercente.Checked = true;
                txtDiscount.Text = _Discount.ToString();

            }
            else
            {
                rdoAmount.Checked = true;
                txtDiscount.Text = _Discount.ToString();
            }


            for (int i = 0; i < lvwChannel.Items.Count; i++)
            {
                Channel oChannel = (Channel)lvwChannel.Items[i].Tag;
                foreach (SPChannel oSPChannel in _oSPromotion.SPChannels)
                {
                    if (oSPChannel.ChannelID == oChannel.ChannelID)
                    {
                        lvwChannel.Items[i].Checked = true;
                    }
                }
            }
            for (int i = 0; i < lvwCustomerType.Items.Count; i++)
            {
                CustomerType oCustomerType = (CustomerType)lvwCustomerType.Items[i].Tag;
                foreach (SPCustomerType oSPCustomerType in _oSPromotion.SPCustomerTypes)
                {
                    if (oSPCustomerType.CustTypeID == oCustomerType.CustTypeID)
                    {
                        lvwCustomerType.Items[i].Checked = true;
                    }
                }
            }
            nPromotionID = _oSPromotion.SalesPromotionID;
            this.ShowDialog();
        }
    }
}