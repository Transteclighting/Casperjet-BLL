using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Class.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Promotion
{
    public partial class frmAddExchangeOffer : Form
    {
        string sProductID = "";
        public bool _IsTrue = false;
        DataTree _oDataTree;
        DataTree oDataTree;
        Users oUsers;
        User oUser;
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        //product
        private int _nProductCallCountUp = 0;
        private int _nProductCallCountDn = 0;
        private bool _bProductSuspended;
        TreeNode _oParentNode;

        DSPromotion oDSPromotion;
        Brands _oBrands;
        ProductGroups _oProductGroups;
        Channels oChannels;
        Warehouses oWarehouses;
        SalesPromotionTypes _oSalesPromotionTypes;
        ProductDetail _oProductDetail;
        SPromotion oSPromotion;
        TELLib _oTELLib;
        int _nCount = 0;
        string sRatio;
        DSPromotionContribution _oDSPromotionContribution = new DSPromotionContribution();
        // Exchange Offers 
        Class.Promotion.ExchangeOffers oExchangeOffers;
        //List<Class.Promotion.ExchangeOfferDetails> oExchangeOffersDetailsList;
        // Brand Tree
        DataTree _oBrandDataTree;
        DataTree oBrandDataTree;
        DataTree _oProductDataTree;
        DataTree oProductDataTree;
        frmSearchProduct oSP;

        public frmAddExchangeOffer()
        {
            InitializeComponent();
            //this.Location = new Point(50, 50);
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                //save data
                oExchangeOffers = new Class.Promotion.ExchangeOffers();
                oExchangeOffers = GetUIData(oExchangeOffers);
                oExchangeOffers.Add();
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
                this.Close();
                MessageBox.Show("successfully saved. \nOffer Code= "+ oExchangeOffers.OfferCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public bool UIValidation()
        {
            //if (string.IsNullOrWhiteSpace(tExchangeCode.Text))
            //{
            //    MessageBox.Show("Please enter Exchange Code!", "Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    tExchangeCode.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(tDescription.Text))
            {
                MessageBox.Show("Please enter Description!", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tDescription.Focus();
                return false;
            }
            if (dateTimefrom.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Effect from Date can not be less then today", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimefrom.Focus();
                return false;
            }
            if (dateTimeTo.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Effect to date can not be less then today", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimeTo.Focus();
                return false;
            }
            oExchangeOffers = new Class.Promotion.ExchangeOffers();
            oExchangeOffers = addProductCheckedNode(tvProduct.Nodes);
            if (oExchangeOffers.Count <= 0)
            {
                MessageBox.Show("Please select one product", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            oExchangeOffers = new Class.Promotion.ExchangeOffers();
            oExchangeOffers = addOutletCheckedNode(tvwShowroom.Nodes);
            if (oExchangeOffers.Count <= 0)
            {
                MessageBox.Show("Please select one outlet", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            oExchangeOffers = new Class.Promotion.ExchangeOffers();
            oExchangeOffers = addBrandCheckedNode(tvBrand.Nodes);
            if (oExchangeOffers.Count <= 0)
            {
                MessageBox.Show("Please select one brand!", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public Class.Promotion.ExchangeOffers GetUIData(Class.Promotion.ExchangeOffers oExchangeOffers)
        {
            oExchangeOffers.OfferCode = "EX-" + oExchangeOffers.GetMaxOfferId().ToString("00000");
            oExchangeOffers.Description = tDescription.Text;
            oExchangeOffers.FromDate = dateTimefrom.Value.Date;
            oExchangeOffers.ToDate = dateTimeTo.Value.Date;
            oExchangeOffers.Status = (int)Dictionary.ExchangeOfeerStatus.Create;
            oExchangeOffers.IsActive = true;
            oExchangeOffers.CreateUserId = Utility.UserId;
            oExchangeOffers.CreateDate = DateTime.Now;
            oExchangeOffers = addOutletCheckedNode(tvwShowroom.Nodes);
            oExchangeOffers = addBrandCheckedNode(tvBrand.Nodes);
            oExchangeOffers = addProductCheckedNode(tvProduct.Nodes);
            //Chk Outlet
            return oExchangeOffers;
        }
        private Class.Promotion.ExchangeOffers addOutletCheckedNode(TreeNodeCollection oNodes)
        {

            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    if (((DataTreeNode)oNode.Tag).DataType == "Outlet")
                    {
                        Class.Promotion.ExchangeOfferDetail oExchangeOffersDetail = new Class.Promotion.ExchangeOfferDetail();
                        oExchangeOffersDetail.DataType = (int)Dictionary.ExchangeOfferDataType.Outlet;
                        oExchangeOffersDetail.DataId = ((DataTreeNode)oNode.Tag).DataID;
                        oExchangeOffers.Add(oExchangeOffersDetail);
                    }
                    addOutletCheckedNode(oNode.Nodes);
                }
            }
            return oExchangeOffers;
        }
        private Class.Promotion.ExchangeOffers addBrandCheckedNode(TreeNodeCollection oNodes)
        {

            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                        Class.Promotion.ExchangeOfferDetail oExchangeOffersDetail = new Class.Promotion.ExchangeOfferDetail();
                        oExchangeOffersDetail.DataType = (int)Dictionary.ExchangeOfferDataType.Brand;
                        oExchangeOffersDetail.DataId = ((DataTreeNode)oNode.Tag).DataID;
                        oExchangeOffers.Add(oExchangeOffersDetail);
                        addBrandCheckedNode(oNode.Nodes);
                }
            }
            return oExchangeOffers;
        }

        private Class.Promotion.ExchangeOffers addProductCheckedNode(TreeNodeCollection oNodes)
        {

            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    if (((DataTreeNode)oNode.Tag).DataType == "AG")
                    {
                        Class.Promotion.ExchangeOfferDetail oExchangeOffersDetail = new Class.Promotion.ExchangeOfferDetail();
                        oExchangeOffersDetail.DataType = (int)Dictionary.ExchangeOfferDataType.ProductGroup;
                        oExchangeOffersDetail.DataId = ((DataTreeNode)oNode.Tag).DataID;
                        oExchangeOffers.Add(oExchangeOffersDetail);
                    }
                    addProductCheckedNode(oNode.Nodes);
                }
            }
            return oExchangeOffers;
        }
        public void getdatatree()
        {
            _oDataTree = new DataTree();
            _oDataTree.GetShowroomTree();
            _oBrandDataTree = new DataTree();
            _oBrandDataTree.GetBrandTree();
            _oProductDataTree = new DataTree();
            _oProductDataTree.GetProductTree();
            //loadProductGroup();
        }
        private void addTreeNodes(TreeNode oParentNode)
        {
            object oParentID = null;
            object oParentDataType = null;
            oDataTree = new DataTree();

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

        private void addBrandTreeNodes(TreeNode oParentNode)
        {
            object oParentID = null;
            object oParentDataType = null;
            oBrandDataTree = new DataTree();
            if (oParentNode == null)
                oBrandDataTree = _oBrandDataTree.getSubDataTree(oParentID, oParentDataType);
            else
            {
                oBrandDataTree = _oBrandDataTree.getSubDataTree(((DataTreeNode)oParentNode.Tag).DataID, ((DataTreeNode)oParentNode.Tag).DataType);
            }

            foreach (DataTreeNode oDataTreeNode in oBrandDataTree)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oDataTreeNode.DataName;
                oNode.Tag = oDataTreeNode;
                if (oParentNode == null)
                {
                    tvBrand.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addBrandTreeNodes(oNode);
            }

        }

        private void addProductTreeNodes(TreeNode oParentNode)
        {
            object oParentID = null;
            object oParentDataType = null;
            oProductDataTree = new DataTree();
            if (oParentNode == null)
                oProductDataTree = _oProductDataTree.getSubDataTree(oParentID, oParentDataType);
            else
            {
                oProductDataTree = _oProductDataTree.getSubDataTree(((DataTreeNode)oParentNode.Tag).DataID, ((DataTreeNode)oParentNode.Tag).DataType);
            }

            foreach (DataTreeNode oDataTreeNode in oProductDataTree)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oDataTreeNode.DataName;
                oNode.Tag = oDataTreeNode;
                if (oParentNode == null)
                {
                    tvProduct.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addProductTreeNodes(oNode);
            }

        }


        private void addCheckedNodex(TreeNodeCollection oNodes)
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
                    addCheckedNodex(oNode.Nodes);
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

        private void frmAddExchangeOffer_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                getdatatree();
                addTreeNodes(null);
                addBrandTreeNodes(null);
                addProductTreeNodes(null);
            }
        }

        private void tvBrand_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void lvwProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public void loadProductGroup()
        //{
        //    lvwProductGroup.Items.Clear();
        //    _oProductGroups.Refresh(Dictionary.ProductGroupType.AG);
        //    foreach (ProductGroup oProductGroup in _oProductGroups)
        //    {
        //        ListViewItem oItem = lvwProductGroup.Items.Add(oProductGroup.PdtGroupCode);
        //        oItem.SubItems.Add(oProductGroup.PdtGroupName);
        //        oItem.Tag = oProductGroup;
        //    }
        //}
        //private void chkProductGroup_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (chkProductGroup.Checked == true)
        //    {
        //        for (int i = 0; i < lvwProductGroup.Items.Count; i++)
        //        {
        //            ListViewItem itm = lvwProductGroup.Items[i];
        //            lvwProductGroup.Items[i].Checked = true;
        //        }
        //        chkProductGroup.Text = "Uncheck All";
        //    }
        //    else
        //    {
        //        for (int i = 0; i < lvwProductGroup.Items.Count; i++)
        //        {
        //            ListViewItem itm = lvwProductGroup.Items[i];
        //            lvwProductGroup.Items[i].Checked = false;

        //        }
        //        chkProductGroup.Text = "Check All";
        //    }
        //}
        //private void cmbProductGroupType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //     bool nIsSKU = false;
        //        _oProductGroups.Refresh(Dictionary.ProductGroupType.AG);
        //        chkProductGroup.Text = "Check All";
        //        chkProductGroup.Checked = false;
           
        //    if (nIsSKU)
        //    {
        //        ProductDetails oPDs = new ProductDetails();
        //        oPDs = oSP._oProductDetails;
        //        if (oPDs != null)
        //        {
        //            lvwProductGroup.Items.Clear();
        //            foreach (ProductDetail oProductDetail in oPDs)
        //            {
        //                ListViewItem oItem = lvwProductGroup.Items.Add(oProductDetail.ProductCode);
        //                oItem.SubItems.Add(oProductDetail.ProductName);
        //                oItem.Tag = oProductDetail;
        //            }
        //            for (int i = 0; i < lvwProductGroup.Items.Count; i++)
        //            {
        //                ListViewItem itm = lvwProductGroup.Items[i];
        //                lvwProductGroup.Items[i].Checked = true;
        //            }
        //            chkProductGroup.Text = "Uncheck All";
        //            chkProductGroup.Checked = true;
        //        }
        //    }
        //    else
        //    {
        //        lvwProductGroup.Items.Clear();
        //        foreach (ProductGroup oProductGroup in _oProductGroups)
        //        {
        //            ListViewItem oItem = lvwProductGroup.Items.Add(oProductGroup.PdtGroupCode);
        //            oItem.SubItems.Add(oProductGroup.PdtGroupName);
        //            oItem.Tag = oProductGroup;
        //        }
        //    }
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tvwShowroom_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void tvProduct_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void tvProduct_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int i;
            //If suspended
            if (_bProductSuspended)
                return;

            //Check/UnCheck child
            if (_nProductCallCountUp == 0)
            {
                for (i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    _nProductCallCountDn++;
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                    _nProductCallCountDn--;
                }
            }

            bool bAnyChecked = false;
            //Check/UnCheck Parent
            if (_nProductCallCountDn == 0)
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

                    _nProductCallCountUp++;
                    e.Node.Parent.Checked = bAnyChecked;
                    _nProductCallCountUp--;

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
