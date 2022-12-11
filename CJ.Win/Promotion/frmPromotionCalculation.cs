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
    public partial class frmPromotionCalculation : Form
    {
        Channels oChannels;
        Warehouses oWarehouses;
        ProductDetail _oProductDetail;
        SPromotions oSPromotions;
        SPromotions oResultSPromotions;
        SPromotion oResultSPromotion;

        public frmPromotionCalculation()
        {
            InitializeComponent();
        }

        private void frmPromotionCalculation_Load(object sender, EventArgs e)
        {
            LoadCmb();
        }
        public void LoadCmb()
        {
            DBController.Instance.OpenNewConnection();
            oChannels = new Channels();
            oChannels.GetAllChannel();
            cmbChannel.Items.Clear();
            foreach (Channel oChannel in oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = oChannels.Count - 1;
            oWarehouses = new Warehouses();
            oWarehouses.GetAllWarehouse();
            cmbWarehouse.Items.Clear();
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = oWarehouses.Count - 1;
        }
        private void dgvFreeProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvProduct);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[4].Value = oForm._oProductDetail.ProductID;

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvProduct.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvProduct.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvProduct.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvProduct.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }

            }

        }
        private void dgvFreeProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvProduct.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvProduct.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvProduct.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oProductDetail.ProductID).ToString();
                        dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvProduct.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
            {
                if (oItemRow.Index < dgvProduct.Rows.Count - 1)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            bool _bFlag = true;
            int nCount = 0;
            int nRatioSet = 1;
            oResultSPromotions = new SPromotions();          

            oSPromotions = new SPromotions();
            oSPromotions.GetPromotionByActive(dtEndDate.Value.Date, -1);

            foreach (SPromotion oSPromotion in oSPromotions)
            {
                _bFlag = true;
                oResultSPromotion = new SPromotion();               
                ///
                // Check Channel
                ///
                nCount = 0;
                foreach (SPChannel oSPChannel in oSPromotion.SPChannels)
                {
                    if (oSPChannel.ChannelID == oChannels[cmbChannel.SelectedIndex].ChannelID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Warehouse
                ///
                nCount = 0;
                foreach (SPWarehouse oSPWarehouse in oSPromotion.SPWarehouses)
                {
                    if (oSPWarehouse.WarehouseID == oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                if (oSPromotion.SalesPromotionID == 16)
                {
                }
                ///
                // Check Promotional Product
                ///
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    //nRatioSet = oSalesPromotionSlab.RatioSet;
                }
               
                if (nRatioSet == 1)
                {
                    foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
                    {
                        nCount = 0;
                        foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
                        {
                            if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                            {
                                if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[4].Value.ToString()))
                                {
                                    nCount++;
                                }
                            }
                        }

                        if (nCount == 0)
                        {
                            _bFlag = false;
                            break;
                        }
                    }
                }
                else
                {
                    nCount = 0;
                    foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
                    {
                        foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
                        {
                            if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                            {
                                if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[4].Value.ToString()))
                                {
                                    nCount++;
                                    break;
                                }
                            }
                        }
                        if (nCount != 0)
                        {
                            break;
                        }
                    }

                    if (nCount == 0)
                    {
                        _bFlag = false;
                        continue; 
                    }
                }
                
                if (_bFlag == true)
                {
                    ///
                    // Slab Checking 
                    ///                 

                    bool _IsSlab = true;                  
                    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                    {                       
                        if (nRatioSet == 1)
                        {
                            foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                            {
                                foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
                                {
                                    if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                                    {
                                        if (oSPSlabRatio.ProductID == int.Parse(oItemRow.Cells[4].Value.ToString()))
                                        {
                                            if (oSPSlabRatio.Qty <= int.Parse(oItemRow.Cells[3].Value.ToString()))
                                            {
                                                _IsSlab = true;
                                            }
                                            else
                                            {
                                                _IsSlab = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (_IsSlab == false)
                                {
                                    break;
                                }
                            }
                            if (_IsSlab)
                            {
                                oResultSPromotion.Clear();
                                oResultSPromotion.Add(oSalesPromotionSlab);
                                oResultSPromotion.SalesPromotionID = oSPromotion.SalesPromotionID;
                                oResultSPromotion.SalesPromotionNo = oSPromotion.SalesPromotionNo;
                            }
                        }
                        else
                        {
                            oResultSPromotion.Clear();
                            oResultSPromotion.Add(oSalesPromotionSlab);
                            oResultSPromotion.SalesPromotionID = oSPromotion.SalesPromotionID;
                            oResultSPromotion.SalesPromotionNo = oSPromotion.SalesPromotionNo;
                        }
                    }
                    oResultSPromotions.Add(oResultSPromotion);
                }
                
            }
            ///
            // Result Display
            ///
            lvwDiscount.Items.Clear();
            lvwFlatAmount.Items.Clear();
            lvwFreeProduct.Items.Clear();
      
            if (oResultSPromotions.Count > 0)
            {                 
                foreach (SPromotion oSPromotion in oResultSPromotions)
                {

                    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                    {
                        //if (oSalesPromotionSlab.RatioSet == 1)
                        //{
                        //    nCount = NumberOfBonus(oSalesPromotionSlab);
                        //}
                        //else
                        //{
                        //    nCount = NumberOfBonus(oSalesPromotionSlab, oSPromotion);
                        //}

                        if (oSalesPromotionSlab.SPDiscountSlab.DiscountAmount > 0)
                        {
                            ListViewItem lstItemDiscount = lvwDiscount.Items.Add(oSPromotion.SalesPromotionNo.ToString());
                            lstItemDiscount.SubItems.Add(Convert.ToString(oSalesPromotionSlab.SPDiscountSlab.DiscountAmount * nCount));
                        }

                        if (oSalesPromotionSlab.SPFlatSlab.FlatAmount > 0)
                        {
                            ListViewItem lstItemAmount = lvwFlatAmount.Items.Add(oSPromotion.SalesPromotionNo.ToString());
                            lstItemAmount.SubItems.Add(Convert.ToString(oSalesPromotionSlab.SPFlatSlab.FlatAmount * nCount));
                        }

                        //foreach (SPFreeGift oSPFreeGift in oSalesPromotionSlab.SPFreeGifts)
                        //{
                        //    oSPFreeGift.Refresh();
                        //    ListViewItem lstItemGiftItem = lvwGiftItem.Items.Add(oSPFreeGift.ItemName);
                        //    lstItemGiftItem.SubItems.Add(Convert.ToString(oSPFreeGift.Qty * nCount));
                        //    lstItemGiftItem.SubItems.Add(oSPromotion.SalesPromotionNo.ToString());
                        //}

                        foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
                        {
                            _oProductDetail = new ProductDetail();
                            _oProductDetail.ProductID = oSPFreeProduct.ProductID;
                            _oProductDetail.Refresh();

                            ListViewItem lstItemFreeProduct = lvwFreeProduct.Items.Add(_oProductDetail.ProductName);
                            lstItemFreeProduct.SubItems.Add(Convert.ToString(oSPFreeProduct.Qty * nCount));
                            lstItemFreeProduct.SubItems.Add(oSPromotion.SalesPromotionNo.ToString());
                        }

                    }
                }
            }           
        }
        public int NumberOfBonus(SalesPromotionSlab oSalesPromotionSlab)
        {
            double[] NumberOfBonus = new double[10];
            int nTimesofBonus=1000;

            int i = 0;

            foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
            {
                foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
                {
                    if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                    {
                        if (oSPSlabRatio.ProductID == int.Parse(oItemRow.Cells[4].Value.ToString()))
                        {
                            NumberOfBonus[i] = int.Parse(oItemRow.Cells[3].Value.ToString()) / oSPSlabRatio.Qty;
                            i++;
                        }
                    }
                }               
            }
            for (int j = 0; j < i;j++ )
            {
                if (nTimesofBonus > NumberOfBonus[j])
                    nTimesofBonus = Convert.ToInt16( Math.Round( NumberOfBonus[j]));
            }
            return nTimesofBonus;
        }
        public int NumberOfBonus(SalesPromotionSlab oSalesPromotionSlab,SPromotion oSPromotion)
        {           
            int nTimesofBonus=0;
            oSPromotion.SPProducts.Refresh(oSPromotion.SalesPromotionID);
            foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
            {
                foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
                {
                    if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                    {
                        if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[4].Value.ToString()))
                        {
                            nTimesofBonus = int.Parse(oItemRow.Cells[3].Value.ToString()) + nTimesofBonus;                           

                        }
                    }
                }               
            }
         
            return nTimesofBonus;
        }

    }
}