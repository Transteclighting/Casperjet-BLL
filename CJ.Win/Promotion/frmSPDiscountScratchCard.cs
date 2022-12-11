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
using CJ.Report;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;


using CJ.Class.Promotion;
using CJ.Class.Library;
using CJ.Class.Promotion;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmSPDiscountScratchCard : Form
    {
        private int _nCallCountUpSalesType = 0;
        private int _nCallCountDnSalesType = 0;
        private bool _bSuspendedSalesType;

        ConsumerPromotion oConsumerPromotion;
        DSPromotion oDSPromotion;
        SPromotion oSPromotion;

        TreeNode _oParentNode;

        DataTree _oDataTreeSalesType;
        DataTree oDataTreeSalesType;

        DataTree _oDataTree;
        DataTree oDataTree;

        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;

        ProductStocks _ProductStocks;
        public string sProductCode;
        public string sProductName;
        public string sProductDesc;
        public string sProductModel;
        public int sProductId;
        public ProductDetail _oProductDetail;
        public ProductDetails _oProductDetails;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrand;
        private Showrooms _oShowrooms;
        private Warehouses oWarehouses;
        Utilities oItemCategory;
        Users oUsers;
        int nWarehouseSelect = 0;
        DSPromotionAllocate _oDSPromotionAllocate = new DSPromotionAllocate();////////

        int _nIUControl = 0;
        public bool _IsTrue = false;

        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        public frmSPDiscountScratchCard()
        {
            InitializeComponent();
            oDSPromotion = new DSPromotion();
            oDSPromotion.Clear();
            oConsumerPromotion= new ConsumerPromotion();

            cmbOfferType.Items.Clear();
            cmbOfferType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OfferTypeSC)))
            {
                cmbOfferType.Items.Add(Enum.GetName(typeof(Dictionary.OfferTypeSC), GetEnum));
            }
            cmbOfferType.SelectedIndex = 0;
        }

        bool _IsEdit = false;
        int nCount = 0;
        string sSplit = "";

        public void ShowDialog(ConsumerPromotion _oConsumerPromotion, bool IsEdit)
        {
            oConsumerPromotion = _oConsumerPromotion;
            dtStartDate.Value = _oConsumerPromotion.FromDate.Date;
            dtEndDate.Value = _oConsumerPromotion.ToDate.Date;
            txtDescription.Text = _oConsumerPromotion.ConsumerPromoName;
            txtRemarks.Text = _oConsumerPromotion.Remarks;
            lblSCPromoNo.Text= _oConsumerPromotion.ConsumerPromoNo;
            lblSCPromoNo.Visible = true;
            cmbOfferType.SelectedIndex = _oConsumerPromotion.OfferType;
            _IsEdit = IsEdit;

            ProductDetails oProductDetails = new ProductDetails();
            oProductDetails.RefreshForSCProduct(_oConsumerPromotion.ConsumerPromoID);
            int i = 0;
            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.Vat * 100).ToString() + '%');

                lvwProduct.Items[i].Checked = true;
                oItem.Tag = oProductDetail;
                i++;
            }

            SPChannels oSPChannels = new SPChannels();
            oSPChannels.GetScratchCardOfferSalesType(_oConsumerPromotion.ConsumerPromoID.ToString(), "t_ScratchCardOffer");

            string sCustType = "";
            foreach (SPChannel oSPChannel in oSPChannels)
            {
                //s = oSPChannel.CustType;
                sCustType = sCustType + "," + oSPChannel.CustType;
            }

            char[] delimiter = new char[] { '\r', '\n',',' };
            string[] part1 = sCustType.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            GettreeSales();
            AddSalesTypeTreeNodes(null, part1);


            SPWarehouses oSPWarehouses = new SPWarehouses();
            oSPWarehouses.GetScratchCardOfferWarehouse(_oConsumerPromotion.ConsumerPromoID);

            string sWareHouses = "";
            foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
            {
                //s = oSPChannel.CustType;
                sWareHouses = sWareHouses + "," + oSPWarehouse.WarehouseID.ToString();
            }

            string[] part2 = sWareHouses.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            getdatatree();
            addTreeNodes(null, part2);
            

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            txtRemarks.Enabled = false;

            lvwProduct.CheckBoxes = false;
            tvwSalesType.ExpandAll();
            tvwShowroom.ExpandAll();

            btnSave.Visible = false;
            btnApprove.Visible = true;

            this.ShowDialog();
        }

       
        

        private void LoadCombos()
        {
            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
           // cboPG.SelectedIndex = _oPG.Count - 1;

            ////MAG
            //_oMAG = new ProductGroups();
            //_oMAG.GETMAG();
            //cboMAG.Items.Clear();
            //foreach (ProductGroup oProductGroup in _oMAG)
            //{
            //    cboMAG.Items.Add(oProductGroup.PdtGroupName);
            //}
            //cboMAG.SelectedIndex = _oMAG.Count - 1;

            ////ASG
            //_oASG = new ProductGroups();
            //_oASG.GETASG();
            //cboASG.Items.Clear();
            //foreach (ProductGroup oProductGroup in _oASG)
            //{
            //    cboASG.Items.Add(oProductGroup.PdtGroupName);
            //}
            //cboASG.SelectedIndex = _oASG.Count - 1;

            ////AG
            //_oAG = new ProductGroups();
            //_oAG.GETAG();
            //cboAG.Items.Clear();
            //foreach (ProductGroup oProductGroup in _oAG)
            //{
            //    cboAG.Items.Add(oProductGroup.PdtGroupName);
            //}
            //cboAG.SelectedIndex = _oAG.Count - 1;

            //Brand
            _oBrand = new Brands();
            _oBrand.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cboBrand.Items.Clear();

            foreach (Brand oBrand in _oBrand)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.Items.Add("ALL");
            cboBrand.SelectedIndex = _oBrand.Count;

            //oItemCategory = new Utilities();
            //oItemCategory.GetItemCategory();
            //cmbItemCategory.Items.Clear();
            //foreach (Utility oUtility in oItemCategory)
            //{
            //    cmbItemCategory.Items.Add(oUtility.Satus);
            //}
            //cmbItemCategory.SelectedIndex = 0;


         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshListBySearch();
        }
        private void refreshListBySearch()
        {
            ProductDetails oProductDetails = new ProductDetails();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nPGID = 0;
            if (_oPG.Count == cboPG.SelectedIndex || cboPG.SelectedIndex == -1)
            {
                nPGID = -1;
            }
            else
            {
                nPGID = _oPG[cboPG.SelectedIndex].PdtGroupID;
            }

            int nMAGID = 0;
            if (_oMAG.Count == cboMAG.SelectedIndex || cboMAG.SelectedIndex == -1)
            {
                nMAGID = -1;
            }
            else
            {
                nMAGID = _oMAG[cboMAG.SelectedIndex].PdtGroupID;
            }

            int nBrandID = 0;
            if (_oBrand.Count == cboBrand.SelectedIndex)
            {
                nBrandID = -1;
            }
            else
            {
                nBrandID = _oBrand[cboBrand.SelectedIndex].BrandID;
            }

           
            string sProductCode = "";
            try
            {
                sProductCode = ctlProduct1.SelectedSerarchProduct.ProductCode;
            }
            catch
            {
                sProductCode = "";
            }

            string sProductName = "";
            try
            {
                sProductName = ctlProduct1.SelectedSerarchProduct.ProductName;
            }
            catch
            {
                sProductName = "";
            }
            int nWarehouseID = 0;
          
            oProductDetails.RefreshBySearch(nPGID, nMAGID, -1,-1, nBrandID, -1, Dictionary.GeneralStatus.All, sProductCode, sProductName, -1);

            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.Vat * 100).ToString() + '%');

                oItem.Tag = oProductDetail;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void lvwProduct_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (lvwProduct.Sorting == SortOrder.Ascending)
            {
                lvwProduct.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProduct.Sorting = SortOrder.Ascending;
            }
            lvwProduct.Sort();
        }

        private void frmSPDiscountScratchCard_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            if (!_IsEdit)
            {
                getdatatree();
                addTreeNodes(null, null);
                GettreeSales();
                AddSalesTypeTreeNodes(null, null);
            }
            DBController.Instance.CloseConnection();
        }

        public void GettreeSales()
        {
            _oDataTreeSalesType = new DataTree();
            _oDataTreeSalesType.GetSalesTypeTree();
        }
        public void getdatatree()
        {
            _oDataTree = new DataTree();
            _oDataTree.GetShowroomTree();
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btSelectAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {

                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Checked All";
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

        private void cboPG_SelectedIndexChanged(object sender, EventArgs e)
        {
                DBController.Instance.OpenNewConnection();
                //MAG
                cboMAG.Items.Clear();
                _oMAG = new ProductGroups();
                _oMAG.GETMAGagainstPG(_oPG[cboPG.SelectedIndex].PdtGroupID);//_oPG[cboPG.SelectedIndex].PdtGroupID
                cboMAG.Items.Clear();
                foreach (ProductGroup oProductGroup in _oMAG)
                {
                    cboMAG.Items.Add(oProductGroup.PdtGroupName);
                }
                cboMAG.SelectedIndex = _oMAG.Count - 1;
                DBController.Instance.CloseConnection();
            
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
            string sProductID = "";
            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {
                ListViewItem itm = lvwProduct.Items[i];
                if (lvwProduct.Items[i].Checked == true)
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    //oConsumerPromotionProductFor.ProductID = int.Parse(itm.SubItems[0].Text);
                    _oProductDetail = new ProductDetail();
                    _oProductDetail = (ProductDetail)lvwProduct.Items[i].Tag;
                    oConsumerPromotionProductFor.ProductID = _oProductDetail.ProductID;
                    nCount++;
                    oConsumerPromotion.ConsumerPromotionProductFors.Add(oConsumerPromotionProductFor);
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Checked at least one Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if(cmbOfferType.SelectedIndex==0)
            {
                MessageBox.Show("Please Select a OfferType", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
          
            
            return true;
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
            oConsumerPromotion.OfferType = cmbOfferType.SelectedIndex;


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
                        oConsumerPromotion.InsertSPScratchCardOffer();


                        SPWarehouses oShowrooms = new SPWarehouses();
                        oShowrooms.GetScratchCardOfferWarehouse(oConsumerPromotion.ConsumerPromoID);
                        foreach (SPWarehouse oShowroom in oShowrooms)
                        {
                            CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                            oDataTran.TableName = "t_ScratchCardOffer";
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

        private void AddSalesTypeTreeNodes(TreeNode oParentNodeSalesType, string[] sCustTypes)
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
                    if (sCustTypes != null)
                    {
                        for (int j = 0; j < sCustTypes.Length; j++)
                        {
                            nCount = 0;
                            sSplit = sCustTypes[j].ToString();

                            if (((DataTreeNode)oNode.Tag).DataID.ToString() == sSplit)
                            {
                                oNode.Checked = true;
                            }
                        }
                       
                    }
                }

                AddSalesTypeTreeNodes(oNode, sCustTypes);
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

        private void addTreeNodes(TreeNode oParentNode, String[] sWH)
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
                    if (sWH != null)
                    {
                        for (int j = 0; j < sWH.Length; j++)
                        {
                            nCount = 0;
                            sSplit = sWH[j].ToString();

                            if (((DataTreeNode)oNode.Tag).DataID.ToString() == sSplit)
                            {
                                oNode.Checked = true;
                            }
                        }

                    }
                }

                addTreeNodes(oNode,sWH);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to approved : " + lblSCPromoNo.Text + " ? ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    ConsumerPromotion _oConsumerPromotion = new ConsumerPromotion();
                    _oConsumerPromotion.ConsumerPromoID = oConsumerPromotion.ConsumerPromoID;
                    _oConsumerPromotion.Status = (int)Dictionary.SalesPromStatus.Approved;

                    _oConsumerPromotion.UpdateStatusSC("t_ScratchCardOffer");
                    SPWarehouses oShowrooms = new SPWarehouses();
                    oShowrooms.GetScratchCardOfferWarehouse(oConsumerPromotion.ConsumerPromoID);
                    foreach (SPWarehouse oShowroom in oShowrooms)
                    {
                        CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                        oDataTran.TableName = "t_ScratchCardOffer";
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
                    MessageBox.Show("You have successfully approved the Scratch Card Offer", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBController.Instance.CommitTransaction();
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void tvwSalesType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvwSalesType.SelectedNode = null;
        }
    }
}
