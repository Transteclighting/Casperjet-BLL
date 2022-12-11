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
using CJ.Class.Library;
using CJ.Class.Promotion;
using CJ.Class.POS;
using System.Windows.Forms.VisualStyles;

namespace CJ.Win.Promotion
{
    public partial class frmTDSalesPromotion : Form
    {
        DSPromotion oDSPromotion;

        DataTree _oDataTree;
        DataTree oDataTree;


        DataTree _oDataTreeSalesType;
        DataTree oDataTreeSalesType;

        Users oUsers;
        User oUser;
        int _nUserID = 0;
        int nWarehouseSelect = 0;
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;


        private int _nCallCountUpSalesType = 0;
        private int _nCallCountDnSalesType = 0;
        private bool _bSuspendedSalesType;

        TreeNode _oParentNode;

        public bool _IsTrue = false;
        Channels oChannels;
        Warehouses oWarehouses;
        SalesPromotionTypes _oSalesPromotionTypes;
        ProductDetail _oProductDetail;
        SPromotion oSPromotion;
        ConsumerPromotion oConsumerPromotion;
        TELLib _oTELLib;
        int _nCount = 0;      
        string sRatio;
        DSPromotionContribution _oDSPromotionContribution = new DSPromotionContribution();
        DSPromotionAllocate _oDSPromotionAllocate = new DSPromotionAllocate();

        public frmTDSalesPromotion()
        {
            InitializeComponent();
            oDSPromotion = new DSPromotion();
            oDSPromotion.Clear();
            DisableForEcom.Checked = true;
        }

        public void Loadlvw()
        {
            //lvwSalesType.Items.Clear();
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            //{
            //    ListViewItem oItem = lvwSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            //}

            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
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

            dtStartDate.Value = _oSPromotion.FromDate.Date;
            dtEndDate.Value = _oSPromotion.ToDate.Date;
            txtDescription.Text = _oSPromotion.SalesPromotionName;

            foreach (SPProduct oSPProduct in _oSPromotion.SPProducts)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItems);

                oRow.Cells[3].Value = oSPProduct.ProductID;               
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oSPProduct.ProductID;   
                _oProductDetail.Refresh();
                oRow.Cells[0].Value = _oProductDetail.ProductCode;
                oRow.Cells[2].Value = _oProductDetail.ProductName;

                dgvLineItems.Rows.Add(oRow);
            }         
            //for (int i = 0; i < lvwSalesType.Items.Count; i++)
            //{              
            //    Channel _oChannel = (Channel)lvwSalesType.Items[i].Tag;
            //    foreach (SPChannel oSPChannel in _oSPromotion.SPChannels)
            //    {
            //        if (oSPChannel.ChannelID == _oChannel.ChannelID)
            //        {
            //            lvwSalesType.Items[i].Checked = true;
            //        }
            //    }
            //}
            //for (int i = 0; i < lvwWarehouse.Items.Count; i++)
            //{               
            //    Warehouse _oWarehouse = (Warehouse)lvwWarehouse.Items[i].Tag;
            //    ListViewItem itm = lvwWarehouse.Items[i];
            //    foreach (SPWarehouse oSPWarehouse in _oSPromotion.SPWarehouses)
            //    {
            //        if (oSPWarehouse.WarehouseID == _oWarehouse.WarehouseID)
            //        {
            //            lvwWarehouse.Items[i].Checked = true;
            //        }
            //    }
            //}
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
                    lstItem.Tag = oSalesPromotionSlab;
                }
                llbDeleteSlab.Enabled = false;
            }
            if (_oSPromotion.FromDate.Date < DateTime.Today.Date)
            {
                dtStartDate.Enabled = false;
                txtDescription.Enabled = false;
                //lvwSalesType.Enabled = false;               
                //lvwWarehouse.Enabled = false;
                llbAddSlab.Enabled = false;
                llbDeleteSlab.Enabled = false;
                llbEdit.Enabled = false;
            }
            this.ShowDialog();         

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItems.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {             

                if (checkDuplicateLineItem(dgvLineItems.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItems.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItems.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();                   
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvLineItems.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItems.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = (_oProductDetail.ProductID).ToString();                    
                        dgvLineItems.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItems.Rows.RemoveAt(nRowIndex);
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
            foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
            {
                if (oItemRow.Index < dgvLineItems.Rows.Count - 1)
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
            if (dgvLineItems.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Promotional Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_nCount == 0)
            {
                if (this.Tag != null)
                {
                    oConsumerPromotion = (ConsumerPromotion)this.Tag;
                    oConsumerPromotion.ConsumerPromotionProductFors.Clear();
                }
                foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
                {
                    if (oItemRow.Index < dgvLineItems.Rows.Count - 1)
                    {
                        ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                        oConsumerPromotionProductFor.ProductID = int.Parse(oItemRow.Cells[3].Value.ToString());
                        oConsumerPromotionProductFor.GroupTypeID = (int)Dictionary.ConsumerPromotionProductGroupType.Product;
                        try
                        {
                            oConsumerPromotionProductFor.TGTQty = int.Parse(oItemRow.Cells[5].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.TGTQty = 0;
                        }


                        /////////////////////////////////////
                        try
                        {
                            oConsumerPromotionProductFor.TargetValue = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.TargetValue = 0;
                        }
                                                
                        try
                        {
                            oConsumerPromotionProductFor.PromoCostVal = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.PromoCostVal = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.NetSalesVal = Convert.ToDouble(oItemRow.Cells[8].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.NetSalesVal = 0;
                        }
                        /////////////////////////////////////////////

                        try
                        {
                            oConsumerPromotionProductFor.RegularSalesQty = int.Parse(oItemRow.Cells[9].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.RegularSalesQty = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.DiscountRatio = Convert.ToDouble(oItemRow.Cells[10].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.DiscountRatio = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.TargetMC = Convert.ToDouble(oItemRow.Cells[11].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.TargetMC = 0;
                        }
                        oConsumerPromotion.ConsumerPromotionProductFors.Add(oConsumerPromotionProductFor);
                    }
                }
                _nCount++;
            }
            frmSalesPromoOffers ofrmSalesPromoOffers = new frmSalesPromoOffers();
            ofrmSalesPromoOffers.ShowDialog(oConsumerPromotion, null);
            oConsumerPromotion = ofrmSalesPromoOffers._oConsumerPromotion;
            if (ofrmSalesPromoOffers._IsTrue == true)
            {
                dgvLineItems.Enabled = false;
                //llbAddSlab.Enabled = false;
            }
            if (oConsumerPromotion.Count > 0)
            {
                lvwSlab.Items.Clear();
                foreach (ConsumerPromotionSlab oConsumerPromotionSlab in oConsumerPromotion)
                {
                    sRatio = "";
                    ListViewItem lstItem = lvwSlab.Items.Add(oConsumerPromotionSlab.SlabName.ToString());
                    lstItem.Tag = oConsumerPromotionSlab;
                }

            }
            else lvwSlab.Items.Clear();

        }
        private void llbEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (lvwSlab.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //SalesPromotionSlab _oSalesPromotionSlab = (SalesPromotionSlab)lvwSlab.SelectedItems[0].Tag;

            //if (this.Tag !=null)
            //oSPromotion = (SPromotion)this.Tag;

            //frmSlab ofrmSlab = new frmSlab(1);     
            //ofrmSlab.ShowDialog(oSPromotion, _oSalesPromotionSlab);
            //oSPromotion = ofrmSlab._oSPromotion;

            //if (this.Tag != null)
            //    this.Tag = oSPromotion;

            //if (oSPromotion.Count > 0)
            //{
            //    lvwSlab.Items.Clear();
            //    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
            //    {
            //        sRatio = "";
            //        ListViewItem lstItem = lvwSlab.Items.Add(oSalesPromotionSlab.SlabNo.ToString());
            //        lstItem.SubItems.Add(oSalesPromotionSlab.SlabName.ToString());

            //        foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
            //        {
            //            if (sRatio == "")
            //            {
            //                sRatio = oSPSlabRatio.Qty.ToString();
            //            }
            //            else
            //            {
            //                sRatio = sRatio + ":" + oSPSlabRatio.Qty.ToString(); 
            //            }
            //        }
            //        lstItem.SubItems.Add(sRatio);
            //        lstItem.Tag = oSalesPromotionSlab;
            //    }
              
            //}
            //else lvwSlab.Items.Clear();
          
        }
        private void llbDeleteSlab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (lvwSlab.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //SalesPromotionSlab _oSalesPromotionSlab = (SalesPromotionSlab)lvwSlab.SelectedItems[0].Tag;          
            
            //if (oSPromotion.Count > 0)
            //{
            //    int i = 0;
            //    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
            //    {
            //        if (oSalesPromotionSlab.SlabNo > _oSalesPromotionSlab.SlabNo)
            //        {
            //            MessageBox.Show("Please Maintain Slab No Order for delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }
            //    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
            //    {
            //        if (oSalesPromotionSlab.SlabNo == _oSalesPromotionSlab.SlabNo)
            //        { 
            //            oSPromotion.RemoveAt(i);
            //            break;
            //        }
            //        i++;
            //    }
            //}          

            //if (oSPromotion.Count > 0)
            //{
            //    lvwSlab.Items.Clear();
            //    foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
            //    {
            //        sRatio = "";
            //        ListViewItem lstItem = lvwSlab.Items.Add(oSalesPromotionSlab.SlabNo.ToString());
            //        lstItem.SubItems.Add(oSalesPromotionSlab.SlabName.ToString());

            //        //foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
            //        //{
            //        //    if (sRatio == "")
            //        //    {
            //        //        sRatio = oSPSlabRatio.Qty.ToString();
            //        //    }
            //        //    else
            //        //    {
            //        //        sRatio = sRatio + ":" + sRatio;
            //        //    }
            //        //}
            //        //lstItem.SubItems.Add(sRatio);
            //        lstItem.Tag = oSalesPromotionSlab;
            //    }
            //}
            //else lvwSlab.Items.Clear();
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
            //Line Item Chk
            if (dgvLineItems.Rows.Count == 1)
            {
                MessageBox.Show("Please enter Promotional Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            double _DiscountRatio = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
            {
                if (oItemRow.Index < dgvLineItems.Rows.Count - 1)
                {

                    try
                    {
                        int nTemp = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please input valid target qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    ///////////////////////////////////////////
                    try
                    {
                        int nTemp = int.Parse(oItemRow.Cells[9].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please input valid regular sale qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        double nTempRatio = Convert.ToDouble(oItemRow.Cells[10].Value.ToString());
                        _DiscountRatio = _DiscountRatio + Convert.ToDouble(oItemRow.Cells[10].Value);
                    }
                    catch
                    {
                        _DiscountRatio = 0;
                        MessageBox.Show("Please input valid discount ratio", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    ////////////////////////////////
                }
            }
            if (_DiscountRatio == 100)
            {

            }
            else if (_DiscountRatio < 100)
            {
                MessageBox.Show("Discount must be 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_DiscountRatio > 100)
            {
                MessageBox.Show("Discount must be 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Sales Type Chk
            int nSalesTypeSelect = 0;
            foreach (TreeNode oNode in tvwSalesType.Nodes)
            {
                if (oNode.Checked == true)
                {
                    nSalesTypeSelect++;
                }
            }
            if (nSalesTypeSelect == 0)
            {
                MessageBox.Show("Please Select at least one Channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            //Chk Warehouse
            nWarehouseSelect = 0;
            foreach (TreeNode oNode in tvwShowroom.Nodes)
            {
                if (oNode.Checked == true)
                {
                    nWarehouseSelect++;
                }
            }
            if (nWarehouseSelect == 0)
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
                    oConsumerPromotion = GetUIData(oConsumerPromotion);

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oConsumerPromotion.InsertConsumerPromotion(_oDSPromotionContribution, _oDSPromotionAllocate);
                        //oConsumerPromotion.InsertConsumerPromotion(_oDSPromotionContribution);

                        SPWarehouses oShowrooms = new SPWarehouses();
                        oShowrooms.GetPromoWarehouse(oConsumerPromotion.ConsumerPromoID);
                        foreach (SPWarehouse oShowroom in oShowrooms)
                        {
                            CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                            oDataTran.TableName = "t_PromoCP";
                            oDataTran.DataID = Convert.ToInt32(oConsumerPromotion.ConsumerPromoID);
                            oDataTran.WarehouseID = oShowroom.WarehouseID;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckDataByWHID() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }
                        }
                        _IsTrue = true;
                        // For Promo disable for ecom Start Zahid
                        if (DisableForEcom.Checked)
                        {
                            oConsumerPromotion.AddPromoDisableFromOnline();
                        }
                        else
                        {
                            oConsumerPromotion.DeleteDisablePromo();
                        }
                        // For Promo disable for ecom End

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
                    oConsumerPromotion = GetUIData(oConsumerPromotion);

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        //oSPromotion.Update();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Promotion", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _IsTrue = true;
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
        public ConsumerPromotion GetUIData(ConsumerPromotion oConsumerPromotion)
        {

            oConsumerPromotion.ConsumerPromoName = txtDescription.Text;
            oConsumerPromotion.FromDate = dtStartDate.Value.Date;
            oConsumerPromotion.ToDate = dtEndDate.Value.Date;
            oConsumerPromotion.CreateDate = DateTime.Today.Date;
            oConsumerPromotion.CreateUserID = Utility.UserId;
            oConsumerPromotion.Remarks = txtRemarks.Text;
            oConsumerPromotion.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            oConsumerPromotion.Status = (int)Dictionary.SalesPromStatus.Create;
            if (chkIsApplicableOnOfferPrice.Checked == true)
            {
                oConsumerPromotion.IsApplicableOnOfferPrice = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oConsumerPromotion.IsApplicableOnOfferPrice = (int)Dictionary.YesOrNoStatus.NO;
            }

            // Sales Type 
            addCheckedNodeSalesType(tvwSalesType.Nodes);
            oConsumerPromotion.SPChannels.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                string _sCustType = "";
                int nSalesType = 0;
                SPChannel oSPChannel = new SPChannel();
                int nCount = 0;

                foreach (DSPromotion.PromoSalesTypeRow oPromoSalesTypeRow in oDSPromotion.PromoSalesType)
                {
                    if (oPromoSalesTypeRow.SalesType == GetEnum)
                    {
                        nSalesType = oPromoSalesTypeRow.SalesType;
                        if (_sCustType == "")
                            _sCustType = oPromoSalesTypeRow.CustomerType;
                        else _sCustType = _sCustType + ',' + oPromoSalesTypeRow.CustomerType;
                        nCount++;
                    }
                }
                if (nCount > 0)
                {
                    oSPChannel.ChannelID = nSalesType;
                    oSPChannel.CustType = _sCustType;
                    oConsumerPromotion.SPChannels.Add(oSPChannel);
                }
            }

            // Sale Promotion Type 
            oConsumerPromotion.SPTypes.Clear();
            for (int i = 0; i < lvwPromotionType.Items.Count; i++)
            {
                ListViewItem itm = lvwPromotionType.Items[i];
                if (lvwPromotionType.Items[i].Checked == true)
                {
                    SalesPromotionType oSalesPromotionType = (SalesPromotionType)lvwPromotionType.Items[i].Tag;
                    SPType oSPType = new SPType();

                    oSPType.SalesPromotionTypeID = oSalesPromotionType.SalesPromotionTypeID;

                    oConsumerPromotion.SPTypes.Add(oSPType);
                }
            }
            // Warehouse
            addCheckedNode(tvwShowroom.Nodes);
            oConsumerPromotion.SPWarehouses.Clear();
            nWarehouseSelect = 0;
            foreach (DSPromotion.PromoWarehouseRow oPromoWarehouseRow in oDSPromotion.PromoWarehouse)
            {
                SPWarehouse oSPWarehouse = new SPWarehouse();
                oSPWarehouse.WarehouseID = oPromoWarehouseRow.WarehouseID;
                oConsumerPromotion.SPWarehouses.Add(oSPWarehouse);
                nWarehouseSelect++;
            }


            return oConsumerPromotion;
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

        private void frmTDSalesPromotion_Load_1(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                getdatatree();
                addTreeNodes(null);
                GettreeSales();
                AddSalesTypeTreeNodes(null);
                Loadlvw();
                oConsumerPromotion = new ConsumerPromotion();
            }
        }

        private void dgvLineItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItems);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[3].Value = oForm._oProductDetail.ProductID;

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvLineItems.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvLineItems.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItems.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItems.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }

            }

            if(e.ColumnIndex==4 && dgvLineItems.Rows[e.RowIndex].Cells[5].Value==null)
            {
                if (Convert.ToInt32(dgvLineItems.Rows[e.RowIndex].Cells[3].Value) > 0)
                {
                    frmPromotionTargetAllocator oForm = new frmPromotionTargetAllocator(Convert.ToInt32(dgvLineItems.Rows[e.RowIndex].Cells[3].Value));
                    oForm.ShowDialog();
                    _oDSPromotionAllocate.Merge(oForm._oDSPromotionAllocate);
                    _oTELLib = new TELLib();
                    dgvLineItems.Rows[e.RowIndex].Cells[5].Value = oForm._TargetQtyTotal;
                    dgvLineItems.Rows[e.RowIndex].Cells[6].Value = _oTELLib.TakaFormat(oForm._TargetValTotal);
                    dgvLineItems.Rows[e.RowIndex].Cells[7].Value = _oTELLib.TakaFormat(oForm._ProCostValTotal);
                    dgvLineItems.Rows[e.RowIndex].Cells[8].Value = _oTELLib.TakaFormat(oForm._NetValTotal);
                    dgvLineItems.Rows[e.RowIndex].Cells[9].Value = oForm._RegSalesQtyTotal;
                    dgvLineItems.Rows[e.RowIndex].Cells[11].Value = oForm._TargetMCTotal;

                    //dgvLineItems.Rows[e.RowIndex].Cells[10].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }
            }
        }

        private void dgvLineItems_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }


        private void lblContribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConsumerPromotionDiscountContribution oForm = new frmConsumerPromotionDiscountContribution();
            oForm.ShowDialog();
            _oDSPromotionContribution = oForm._oDSPromotionContribution;
            _oTELLib = new TELLib();
            txtContribution.Text = _oTELLib.TakaFormat(oForm._ContributionTotal);
        }

        public void getdatatree()
        {
            _oDataTree = new DataTree();
            _oDataTree.GetShowroomTree();
        }
        private void addTreeNodes(TreeNode oParentNode)
        {
            object oParentID = null;
            object oParentDataType = null;
            oDataTree = new DataTree();
            oUsers = new Users();

            if (oParentNode == null)
                oDataTree = _oDataTree.getSubDataTree(oParentID, oParentDataType);
            else
            {
                oDataTree = _oDataTree.getSubDataTree(((DataTreeNode)oParentNode.Tag).DataID, ((DataTreeNode)oParentNode.Tag).DataType);
            }

            foreach (DataTreeNode oDataTreeNode in oDataTree)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oDataTreeNode.DataName;
                oNode.Tag = oDataTreeNode;

                //oNode.Checked = oUsers.checkdataPermission(oDataTreeNode.DataID, oDataTreeNode.DataType, _nUserID);

                if (oParentNode == null)
                {
                    tvwShowroom.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addTreeNodes(oNode);
            }
            
        }

        private void addCheckedNode(TreeNodeCollection oNodes)
        {

            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    if (((DataTreeNode)oNode.Tag).DataType == "Outlet")
                    {
                        DSPromotion.PromoWarehouseRow oPromoWarehouseRow = oDSPromotion.PromoWarehouse.NewPromoWarehouseRow();
                        oPromoWarehouseRow.WarehouseID = ((DataTreeNode)oNode.Tag).DataID;
                        oDSPromotion.PromoWarehouse.AddPromoWarehouseRow(oPromoWarehouseRow);
                        oDSPromotion.AcceptChanges();

                    }
                    addCheckedNode(oNode.Nodes);
                }
            }
        }

        private void tvwShowroom_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int i;
            //If suspended
            if (_bSuspended)
                return;

            //Check/UnCheck child
            if (_nCallCountUp == 0)
            {
                for (i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    _nCallCountDn++;
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                    _nCallCountDn--;
                }
            }

            bool bAnyChecked = false;
            //Check/UnCheck Parent
            if (_nCallCountDn == 0)
            {
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode iNode in e.Node.Parent.Nodes)
                    {
                        if (iNode.Checked == true)
                        {
                            bAnyChecked = true;
                            break;
                        }
                    }

                    _nCallCountUp++;
                    e.Node.Parent.Checked = bAnyChecked;
                    _nCallCountUp--;

                }
            }
        }

        public void GettreeSales()
        {
            _oDataTreeSalesType = new DataTree();
            _oDataTreeSalesType.GetSalesTypeTree();
        }
        private void AddSalesTypeTreeNodes(TreeNode oParentNodeSalesType)
        {
            object oParentID = null;
            object oParentDataType = null;
            oDataTreeSalesType = new DataTree();
            oUsers = new Users();

            if (oParentNodeSalesType == null)
                oDataTreeSalesType = _oDataTreeSalesType.getSubDataTree(oParentID, oParentDataType);
            else
            {
                oDataTreeSalesType = _oDataTreeSalesType.getSubDataTree(((DataTreeNode)oParentNodeSalesType.Tag).DataID, ((DataTreeNode)oParentNodeSalesType.Tag).DataType);
            }

            foreach (DataTreeNode oDataTreeNodeSalesType in oDataTreeSalesType)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oDataTreeNodeSalesType.DataName;
                oNode.Tag = oDataTreeNodeSalesType;

                //oNode.Checked = oUsers.checkdataPermission(oDataTreeNode.DataID, oDataTreeNode.DataType, _nUserID);

                if (oParentNodeSalesType == null)
                {
                    tvwSalesType.Nodes.Add(oNode);
                }
                else
                {
                    oParentNodeSalesType.Nodes.Add(oNode);
                }

                AddSalesTypeTreeNodes(oNode);
            }

        }

        private void addCheckedNodeSalesType(TreeNodeCollection oNodes)
        {

            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    oConsumerPromotion.SPChannels.Clear();
                    if (((DataTreeNode)oNode.Tag).DataType == "Customer Type")
                    {
                        DSPromotion.PromoSalesTypeRow oPromoSalesTypeRow = oDSPromotion.PromoSalesType.NewPromoSalesTypeRow();
                        oPromoSalesTypeRow.SalesType = Convert.ToInt32(((DataTreeNode)oNode.Tag).ParentID);
                        oPromoSalesTypeRow.CustomerType = ((DataTreeNode)oNode.Tag).DataID.ToString();

                        oDSPromotion.PromoSalesType.AddPromoSalesTypeRow(oPromoSalesTypeRow);
                        oDSPromotion.AcceptChanges();

                    }
                    addCheckedNodeSalesType(oNode.Nodes);
                }
            }

        }

        private void tvwSalesType_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int i;
            //If suspended
            if (_bSuspendedSalesType)
                return;

            //Check/UnCheck child
            if (_nCallCountUpSalesType == 0)
            {
                for (i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    _nCallCountDnSalesType++;
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                    _nCallCountDnSalesType--;
                }
            }

            bool bAnyChecked = false;
            //Check/UnCheck Parent
            if (_nCallCountDnSalesType == 0)
            {
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode iNode in e.Node.Parent.Nodes)
                    {
                        if (iNode.Checked == true)
                        {
                            bAnyChecked = true;
                            break;
                        }
                    }

                    _nCallCountUpSalesType++;
                    e.Node.Parent.Checked = bAnyChecked;
                    _nCallCountUpSalesType--;

                }
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void dgvLineItems_Leave(object sender, EventArgs e)
        {
            if(dgvLineItems.Rows[0].Cells[10].Value==null)
            {
                MessageBox.Show("Please select Discount Ratio");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DisableForEcom_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}