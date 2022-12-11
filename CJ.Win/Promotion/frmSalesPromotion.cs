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
    public partial class frmSalesPromotion : Form
    {
        Channels oChannels;
        Warehouses oWarehouses;
        SalesPromotionTypes _oSalesPromotionTypes;
        ProductDetail _oProductDetail;
        SPromotion oSPromotion;
        int _nCount = 0;      
        string sRatio;


        public frmSalesPromotion()
        {
            InitializeComponent();
        }

        private void frmSalesPromotion_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                Loadlvw();
                oSPromotion = new SPromotion();
            }
            else dgvLineItem.Enabled = false;

        }
        public void Loadlvw()
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

            oWarehouses = new Warehouses();
            oWarehouses.GetWarehouseForPromotion();
            lvwWarehouse.Items.Clear();
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                ListViewItem oItem = lvwWarehouse.Items.Add(oWarehouse.Shortcode);
                oItem.SubItems.Add(oWarehouse.WarehouseName);
                oItem.Tag = oWarehouse;
            }

            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh();
            lvwPromotionType.Items.Clear();
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                ListViewItem oItem = lvwPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
                oItem.Tag = oSalesPromotionType;
            }

        }
        public void ShowDialog(SPromotion _oSPromotion)
        {
            Loadlvw();
            this.Tag = _oSPromotion;

            txtPromotionNo.Text = _oSPromotion.SalesPromotionNo.ToString();
            dtStartDate.Value = _oSPromotion.FromDate.Date;
            dtEndDate.Value = _oSPromotion.ToDate.Date;
            txtDescription.Text = _oSPromotion.SalesPromotionName;

            foreach (SPProduct oSPProduct in _oSPromotion.SPProducts)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                oRow.Cells[3].Value = oSPProduct.ProductID;               
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oSPProduct.ProductID;   
                _oProductDetail.Refresh();
                oRow.Cells[0].Value = _oProductDetail.ProductCode;
                oRow.Cells[2].Value = _oProductDetail.ProductName;

                dgvLineItem.Rows.Add(oRow);
            }         
            for (int i = 0; i < lvwChannel.Items.Count; i++)
            {              
                Channel _oChannel = (Channel)lvwChannel.Items[i].Tag;
                foreach (SPChannel oSPChannel in _oSPromotion.SPChannels)
                {
                    if (oSPChannel.ChannelID == _oChannel.ChannelID)
                    {
                        lvwChannel.Items[i].Checked = true;
                    }
                }
            }
            for (int i = 0; i < lvwWarehouse.Items.Count; i++)
            {               
                Warehouse _oWarehouse = (Warehouse)lvwWarehouse.Items[i].Tag;
                ListViewItem itm = lvwWarehouse.Items[i];
                foreach (SPWarehouse oSPWarehouse in _oSPromotion.SPWarehouses)
                {
                    if (oSPWarehouse.WarehouseID == _oWarehouse.WarehouseID)
                    {
                        lvwWarehouse.Items[i].Checked = true;
                    }
                }
            }
            _oSPromotion.RefreshSlab();

            if (_oSPromotion.Count > 0)
            {
                lvwSlab.Items.Clear();
                foreach (SalesPromotionSlab oSalesPromotionSlab in _oSPromotion)
                {
                    sRatio = "";
                    ListViewItem lstItem = lvwSlab.Items.Add(oSalesPromotionSlab.SlabNo.ToString());
                    lstItem.SubItems.Add(oSalesPromotionSlab.SlabName.ToString());

                    foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                    {
                        if (sRatio == "")
                        {
                            sRatio = oSPSlabRatio.Qty.ToString();
                        }
                        else
                        {
                            sRatio = sRatio + ":" + sRatio;
                        }
                    }
                    //if (oSalesPromotionSlab.RatioSet == 1)
                    //    lstItem.SubItems.Add(sRatio);
                    //else lstItem.SubItems.Add("Not Set");
                    lstItem.Tag = oSalesPromotionSlab;
                }
                llbDeleteSlab.Enabled = false;
            }
            if (_oSPromotion.FromDate.Date < DateTime.Today.Date)
            {
                dtStartDate.Enabled = false;
                txtDescription.Enabled = false;
                lvwChannel.Enabled = false;               
                lvwWarehouse.Enabled = false;
                llbAddSlab.Enabled = false;
                llbDeleteSlab.Enabled = false;
                llbEdit.Enabled = false;
            }
            this.ShowDialog();         

        }
        private void chkbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbAll.Checked == true)
            {
                for (int i = 0; i < lvwWarehouse.Items.Count; i++)
                {
                    ListViewItem itm = lvwWarehouse.Items[i];
                    lvwWarehouse.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lvwWarehouse.Items.Count; i++)
                {
                    ListViewItem itm = lvwWarehouse.Items[i];
                    lvwWarehouse.Items[i].Checked = false;

                }
            }
        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {                
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;               
                    oRow.Cells[3].Value = oForm._oProductDetail.ProductID;                   

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvLineItem.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }

            }

        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {             

                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();                   
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = (_oProductDetail.ProductID).ToString();                    
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
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
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
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

        private void llbAddSlab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Promotional Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_nCount == 0)
            {
                if(this.Tag !=null)
                {
                    oSPromotion = (SPromotion)this.Tag;
                    oSPromotion.SPProducts.Clear();
                }
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        SPProduct oSPProduct = new SPProduct();
                        oSPProduct.ProductID = int.Parse(oItemRow.Cells[3].Value.ToString());

                        oSPromotion.SPProducts.Add(oSPProduct);
                    }
                }
                _nCount++;
            }
            frmSlab ofrmSlab = new frmSlab(0);
            ofrmSlab.ShowDialog(oSPromotion,null);
            oSPromotion = ofrmSlab._oSPromotion;

            if (oSPromotion.Count > 0)
            {               
                lvwSlab.Items.Clear();
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    sRatio = "";
                    ListViewItem lstItem = lvwSlab.Items.Add(oSalesPromotionSlab.SlabNo.ToString());
                    lstItem.SubItems.Add(oSalesPromotionSlab.SlabName.ToString());

                    foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                    {                        
                        if (sRatio == "")
                        {
                            sRatio = oSPSlabRatio.Qty.ToString();
                        }
                        else
                        {
                            sRatio = sRatio + ":" + oSPSlabRatio.Qty.ToString(); 
                        }
                    }
                    if (ofrmSlab._bRatioNotSet == true)
                    {
                        lstItem.SubItems.Add("Not Set");
                    }
                    else lstItem.SubItems.Add(sRatio);

                    lstItem.Tag = oSalesPromotionSlab;
                }
                if (ofrmSlab._bIsComboOffer == true)
                {
                    llbAddSlab.Enabled = false;
                }
               
            }
            else lvwSlab.Items.Clear();
        }
        private void llbEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvwSlab.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesPromotionSlab _oSalesPromotionSlab = (SalesPromotionSlab)lvwSlab.SelectedItems[0].Tag;

            if (this.Tag !=null)
            oSPromotion = (SPromotion)this.Tag;

            frmSlab ofrmSlab = new frmSlab(1);     
            ofrmSlab.ShowDialog(oSPromotion, _oSalesPromotionSlab);
            oSPromotion = ofrmSlab._oSPromotion;

            if (this.Tag != null)
                this.Tag = oSPromotion;

            if (oSPromotion.Count > 0)
            {
                lvwSlab.Items.Clear();
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    sRatio = "";
                    ListViewItem lstItem = lvwSlab.Items.Add(oSalesPromotionSlab.SlabNo.ToString());
                    lstItem.SubItems.Add(oSalesPromotionSlab.SlabName.ToString());

                    foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                    {
                        if (sRatio == "")
                        {
                            sRatio = oSPSlabRatio.Qty.ToString();
                        }
                        else
                        {
                            sRatio = sRatio + ":" + oSPSlabRatio.Qty.ToString(); 
                        }
                    }
                    lstItem.SubItems.Add(sRatio);
                    lstItem.Tag = oSalesPromotionSlab;
                }
              
            }
            else lvwSlab.Items.Clear();
          
        }
        private void llbDeleteSlab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvwSlab.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesPromotionSlab _oSalesPromotionSlab = (SalesPromotionSlab)lvwSlab.SelectedItems[0].Tag;          
            
            if (oSPromotion.Count > 0)
            {
                int i = 0;
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    if (oSalesPromotionSlab.SlabNo > _oSalesPromotionSlab.SlabNo)
                    {
                        MessageBox.Show("Please Maintain Slab No Order for delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    if (oSalesPromotionSlab.SlabNo == _oSalesPromotionSlab.SlabNo)
                    { 
                        oSPromotion.RemoveAt(i);
                        break;
                    }
                    i++;
                }
            }          

            if (oSPromotion.Count > 0)
            {
                lvwSlab.Items.Clear();
                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    sRatio = "";
                    ListViewItem lstItem = lvwSlab.Items.Add(oSalesPromotionSlab.SlabNo.ToString());
                    lstItem.SubItems.Add(oSalesPromotionSlab.SlabName.ToString());

                    //foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                    //{
                    //    if (sRatio == "")
                    //    {
                    //        sRatio = oSPSlabRatio.Qty.ToString();
                    //    }
                    //    else
                    //    {
                    //        sRatio = sRatio + ":" + sRatio;
                    //    }
                    //}
                    //lstItem.SubItems.Add(sRatio);
                    lstItem.Tag = oSalesPromotionSlab;
                }
            }
            else lvwSlab.Items.Clear();
        } 

        public bool validateUIInput()
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
            if (txtDescription.Text == "")
            {
                MessageBox.Show("Please enter Promotion Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please enter Promotional Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
                MessageBox.Show("Please Select at least one Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            nCount = 0;
            for (int i = 0; i < lvwWarehouse.Items.Count; i++)
            {
                ListViewItem itm = lvwWarehouse.Items[i];
                if (lvwWarehouse.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Select at least one Showroom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (lvwSlab.Items.Count == 0)
            {
                MessageBox.Show("Please Enter at least one Slab ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (validateUIInput())
                {
                    oSPromotion = GetUIData(oSPromotion);

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSPromotion.Insert();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Add The Promotion", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                oSPromotion = (SPromotion)this.Tag;
                if (validateUIInput())
                {
                    oSPromotion = GetUIData(oSPromotion);

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSPromotion.Update();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Promotion", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
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
            // Warehouse
            oSPromotion.SPWarehouses.Clear();
            for (int i = 0; i < lvwWarehouse.Items.Count; i++)
            {
                ListViewItem itm = lvwWarehouse.Items[i];
                if (lvwWarehouse.Items[i].Checked == true)
                {
                    Warehouse oWarehouse = (Warehouse)lvwWarehouse.Items[i].Tag;
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseID = oWarehouse.WarehouseID;

                    oSPromotion.SPWarehouses.Add(oSPWarehouse);
                }
            }
            return oSPromotion;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            }
            else
            {
                for (int i = 0; i < lvwPromotionType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPromotionType.Items[i];
                    lvwPromotionType.Items[i].Checked = false;

                }
            }
        }
             
    }
}