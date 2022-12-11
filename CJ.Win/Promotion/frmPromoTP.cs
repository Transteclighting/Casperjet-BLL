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

namespace CJ.Win.Promotion
{
    public partial class frmPromoTP : Form
    {

        DataTree _oDataTreeSalesType;
        DataTree oDataTreeSalesType;
        private int _nCallCountUpSalesType = 0;
        private int _nCallCountDnSalesType = 0;
        private bool _bSuspendedSalesType;


        string sProductID = "";
        public bool _IsTrue = false;
        DataTree _oDataTree;
        DataTree oDataTree;
        Users oUsers;
        User oUser;
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        TreeNode _oParentNode;

        DSPromotion oDSPromotion;
        Brands _oBrands;
        ProductGroups _oProductGroups;
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
        public frmPromoTP()
        {
            InitializeComponent();
            oDSPromotion = new DSPromotion();
            oDSPromotion.Clear();
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
            //oDSPromotion.PromoWarehouse.Clear();
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

        public void Loadlvw()
        {
            //lvwSalesType.Items.Clear();
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            //{
            //    //if (GetEnum == 5)
            //    //{
            //    ListViewItem oItem = lvwSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            //    //}
            //}

            //oWarehouses = new Warehouses();
            //oWarehouses.GetWarehouseForPromotion();
            //lvwWarehouse.Items.Clear();
            //foreach (Warehouse oWarehouse in oWarehouses)
            //{
            //    ListViewItem oItem = lvwWarehouse.Items.Add(oWarehouse.Shortcode);
            //    oItem.SubItems.Add(oWarehouse.WarehouseName);
            //    oItem.Tag = oWarehouse;
            //}

            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
            lvwPromotionType.Items.Clear();
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                ListViewItem oItem = lvwPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
                oItem.Tag = oSalesPromotionType;
            }

            _oProductGroups = new ProductGroups();
            _oProductGroups.GetProductGroup((int)Dictionary.ProductGroupType.MAG);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("-- Select MAG--");
            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;

            _oBrands = new Brands();
            _oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("-- Select Brand--");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
        }
        public void ShowDialog(SPromotion _oSPromotion)
        {
            Loadlvw();
            this.Tag = _oSPromotion;

            dtStartDate.Value = _oSPromotion.FromDate.Date;
            dtEndDate.Value = _oSPromotion.ToDate.Date;
            txtDescription.Text = _oSPromotion.SalesPromotionName;

            //foreach (SPProduct oSPProduct in _oSPromotion.SPProducts)
            //{
            //    DataGridViewRow oRow = new DataGridViewRow();
            //    oRow.CreateCells(dgvLineItems);

            //    oRow.Cells[3].Value = oSPProduct.ProductID;
            //    _oProductDetail = new ProductDetail();
            //    _oProductDetail.ProductID = oSPProduct.ProductID;
            //    _oProductDetail.Refresh();
            //    oRow.Cells[0].Value = _oProductDetail.ProductCode;
            //    oRow.Cells[2].Value = _oProductDetail.ProductName;

            //    dgvLineItems.Rows.Add(oRow);
            //}
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
                tvwShowroom.Enabled = false;
                llbAddSlab.Enabled = false;
                llbDeleteSlab.Enabled = false;
                llbEdit.Enabled = false;
            }
            this.ShowDialog();

        }
        //private void chkbAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkbAll.Checked == true)
        //    {
        //        for (int i = 0; i < lvwWarehouse.Items.Count; i++)
        //        {
        //            ListViewItem itm = lvwWarehouse.Items[i];
        //            lvwWarehouse.Items[i].Checked = true;
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < lvwWarehouse.Items.Count; i++)
        //        {
        //            ListViewItem itm = lvwWarehouse.Items[i];
        //            lvwWarehouse.Items[i].Checked = false;

        //        }
        //    }
        //}
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
            {
                if (oItemRow.Index < dgvLineItems.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value.ToString().Trim() + oItemRow.Cells[1].Value.ToString().Trim() == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() + oItemRow.Cells[1].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }
        private void llbAddSlab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvLineItems.Rows.Count == 0)
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
                    if (oItemRow.Index < dgvLineItems.Rows.Count)
                    {
                        ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();

                        oConsumerPromotionProductFor.MAG = oItemRow.Cells[0].Value.ToString();
                        oConsumerPromotionProductFor.BrandDesc = oItemRow.Cells[1].Value.ToString();
                        try
                        {
                            oConsumerPromotionProductFor.TGTQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.TGTQty = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.TargetValue = int.Parse(oItemRow.Cells[3].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.TargetValue = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.PromoCostVal = int.Parse(oItemRow.Cells[4].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.PromoCostVal = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.NetSalesVal = int.Parse(oItemRow.Cells[5].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.NetSalesVal = 0;
                        }
                        try
                        {
                            oConsumerPromotionProductFor.RegularSalesQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                        }
                        catch
                        {
                            oConsumerPromotionProductFor.RegularSalesQty = 0;
                        }
                        oConsumerPromotionProductFor.ProductGroupID = int.Parse(oItemRow.Cells[7].Value.ToString());
                        oConsumerPromotionProductFor.BrandID = int.Parse(oItemRow.Cells[8].Value.ToString());
                        oConsumerPromotionProductFor.GroupTypeID = int.Parse(oItemRow.Cells[9].Value.ToString());
                        oConsumerPromotionProductFor.DiscountRatio = 0;
                        oConsumerPromotionProductFor.ApplicableProductID = oItemRow.Cells[10].Value.ToString();
                        oConsumerPromotionProductFor.IsApplicableOnAllSKU = int.Parse(oItemRow.Cells[11].Value.ToString());
                        oConsumerPromotion.ConsumerPromotionProductFors.Add(oConsumerPromotionProductFor);
                    }
                }
                _nCount++;
            }
            frmPromoTPOffers ofrmSalesPromoOffers = new frmPromoTPOffers();
            ofrmSalesPromoOffers.ShowDialog(oConsumerPromotion, null);
            oConsumerPromotion = ofrmSalesPromoOffers._oConsumerPromotion;
            if (ofrmSalesPromoOffers._IsTrue == true)
            {
                btnAddtolist.Enabled = false;
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
            if (dgvLineItems.Rows.Count == 0)
            {
                MessageBox.Show("Please enter Promotional Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            ///Warehouse
            nCount = 0;
            foreach (TreeNode oNode in tvwShowroom.Nodes)
            {
                if (oNode.Checked == true)
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
                    oConsumerPromotion = GetUIData(oConsumerPromotion);
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oConsumerPromotion.InsertTradePromotion(_oDSPromotionContribution);

                        SPWarehouses oShowrooms = new SPWarehouses();
                        oShowrooms.GetTPWarehouse(oConsumerPromotion.ConsumerPromoID);
                        foreach (SPWarehouse oShowroom in oShowrooms)
                        {
                            CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                            oDataTran.TableName = "t_PromoTP";
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
            oDSPromotion.PromoSalesType.Clear();
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
            oDSPromotion.PromoWarehouse.Clear();
            addCheckedNode(tvwShowroom.Nodes);
            oConsumerPromotion.SPWarehouses.Clear();
            int nWarehouseSelect = 0;
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
        private void frmPromoTP_Load_1(object sender, EventArgs e)
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
            else dgvLineItems.Enabled = false;

        }
        private void lblContribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConsumerPromotionDiscountContribution oForm = new frmConsumerPromotionDiscountContribution();
            oForm.ShowDialog();
            _oDSPromotionContribution = oForm._oDSPromotionContribution;
            _oTELLib = new TELLib();
            txtContribution.Text = _oTELLib.TakaFormat(oForm._ContributionTotal);
        }
        private bool UIValidation()
        {
            if (chkIsApplicableOnAllSKU.Checked == true)
            {
            }
            else
            {
                if (sProductID == "")
                {
                    MessageBox.Show("Please select specific product list first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (cmbMAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a mag", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a brand", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (checkDuplicateLineItem(cmbMAG.Text.Trim() + cmbBrand.Text.Trim()) > 0)
            {
                MessageBox.Show("Duplicate Item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTGTQty.Text.Trim() == "")
            {
                MessageBox.Show("Please input target qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTGTQty.Focus();
                return false;
            }
            else
            {
                try
                {
                    int x = Convert.ToInt32(txtTGTQty.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid target qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtRequlerSale.Text.Trim() == "")
            {
                MessageBox.Show("Please input regular Sale qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRequlerSale.Focus();
                return false;
            }
            else
            {
                try
                {
                    int x = Convert.ToInt32(txtRequlerSale.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid requler sale qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


            return true;
        }
        private void btnAddtolist_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItems);

                oRow.Cells[0].Value = cmbMAG.Text;
                oRow.Cells[1].Value = cmbBrand.Text;
                oRow.Cells[2].Value = txtTGTQty.Text;
                oRow.Cells[3].Value = "";
                oRow.Cells[4].Value = "";
                oRow.Cells[5].Value = "";
                oRow.Cells[6].Value = txtRequlerSale.Text;
                oRow.Cells[7].Value = _oProductGroups[cmbMAG.SelectedIndex - 1].PdtGroupID;
                oRow.Cells[8].Value = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                oRow.Cells[9].Value = (int)Dictionary.ConsumerPromotionProductGroupType.MAG;
                ///oRow.Cells[7].Value = txtDisRatio.Text;
                if (chkIsApplicableOnAllSKU.Checked == true)
                {
                    oRow.Cells[10].Value = "";
                    oRow.Cells[11].Value = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oRow.Cells[10].Value = sProductID.ToString();
                    oRow.Cells[11].Value = (int)Dictionary.YesOrNoStatus.NO;
                }
                
                dgvLineItems.Rows.Add(oRow);

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

        private void chkIsApplicableOnAllSKU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsApplicableOnAllSKU.Checked == true)
            {
                sProductID = "";
            }
            else
            {
                CJ.Control.frmSearchProduct oFrom = new CJ.Control.frmSearchProduct(2);
                oFrom.ShowDialog();
                sProductID = oFrom.sProductID;
            }
            
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            sProductID = "";
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            sProductID = "";
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
            //oDSPromotion.PromoSalesType.Clear();
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

        private void dgvLineItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chkbAll_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}