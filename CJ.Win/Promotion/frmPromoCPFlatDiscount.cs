using CJ.Class;
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
    public partial class frmPromoCPFlatDiscount : Form
    {
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        private int _nCallCountUpSalesType = 0;
        private int _nCallCountDnSalesType = 0;
        private bool _bSuspendedSalesType;

        PromoDiscountContributors _oConsumerPromotionDiscountContributors;
        SalesPromotionTypes _oSalesPromotionTypes;
        DataTree _oDataTree;
        DataTree oDataTree;
        Users oUsers;
        DataTree _oDataTreeSalesType;
        DataTree oDataTreeSalesType;
        ConsumerPromotion oConsumerPromotion;
        DSPromotion oDSPromotion;
        EMITenures _oEMITenures;
        PromoCPSimple oPromoCPSimple;
        public frmPromoCPFlatDiscount()
        {
            InitializeComponent();
            oDSPromotion = new DSPromotion();
            oDSPromotion.Clear();
            //DisableForEcom.Checked = true;

        }
        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = dgData.CurrentCell.RowIndex;
                int iCol = dgData.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < dgData.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.dgData.ColumnCount)
                            {
                                oCell = dgData[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    if (oCell.Value.ToString() != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                        oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                        iFail++;//only traps a fail if the data has changed and you are pasting into a read only cell
                                }
                            }
                            else
                            { break; }
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    if (iFail > 0)
                        MessageBox.Show(string.Format("{0} updates failed due to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }
        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Code", typeof(string)) });

            string copiedContent = Clipboard.GetText();
            foreach (string row in copiedContent.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {

                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split('\t'))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }
            dgData.DataSource = dt;

            //dgData.DataBind();
            Clipboard.Clear();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oEMITenures = new EMITenures();
            _oEMITenures.Refresh();
            cmbFreeEMITenure.Items.Clear();
            cmbFreeEMITenure.Items.Add("Not Applicable");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbFreeEMITenure.Items.Add(oEMITenure.Tenure.ToString());
            }
            cmbFreeEMITenure.SelectedIndex = 0;


            _oConsumerPromotionDiscountContributors = new PromoDiscountContributors();
            _oConsumerPromotionDiscountContributors.Refresh();
            cmbContributor.Items.Clear();
            cmbContributor.Items.Add("-- Select Contributor--");
            foreach (PromoDiscountContributor oData in _oConsumerPromotionDiscountContributors)
            {
                cmbContributor.Items.Add(oData.DiscountContributorName);
            }
            cmbContributor.SelectedIndex = 0;

            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
            lvwPromotionType.Items.Clear();
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                ListViewItem oItem = lvwPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
                oItem.Tag = oSalesPromotionType;
            }

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
                    //oConsumerPromotion.SPChannels.Clear();
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
        private void frmPromoCPFlatDiscount_Load(object sender, EventArgs e)
        {
            LoadCombo();

            getdatatree();
            addTreeNodes(null);
            GettreeSales();
            AddSalesTypeTreeNodes(null);


        }

        private void txtContribution_TextChanged(object sender, EventArgs e)
        {
            if (txtContribution.Text.Trim() != "")
            {
                try
                {
                    decimal temp = Convert.ToDecimal(txtContribution.Text);

                }
                catch
                {
                    MessageBox.Show("Please input valid Qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContribution.Text = "0";
                }

            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Trim() != "")
            {
                try
                {
                    decimal temp = Convert.ToDecimal(txtDiscount.Text);

                }
                catch
                {
                    MessageBox.Show("Please input valid Qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Text = "0";
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validateUIInput()
        {

            int nCount = 0;
            if (this.Tag == null)
            {
                if (dtFromDate.Value.Date < DateTime.Today.Date)
                {
                    MessageBox.Show("Effect strat date must greater than System date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtFromDate.Focus();
                    return false;
                }
            }
            if (dtTodate.Value.Date < dtFromDate.Value.Date)
            {
                MessageBox.Show("Effect to date must greater than Effect strat date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtTodate.Focus();
                return false;
            }
            if (txtDescription.Text == "")
            {
                MessageBox.Show("Please enter Promotion Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }
            if (dgData.Rows.Count == 0)
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

            if (rdoNone.Checked == true && cmbFreeEMITenure.SelectedIndex == 0)
            {
                MessageBox.Show("Plese set offer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbContributor.SelectedIndex == 0)
            {
                MessageBox.Show("Plese select a contributor", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDouble(txtContribution.Text) > Convert.ToDouble(txtDiscount.Text))
            {
                MessageBox.Show("Contribution amount must be less then discount amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
                txtContribution.Focus();
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {

                oPromoCPSimple = new PromoCPSimple();
                oPromoCPSimple.CPSimpleName = txtDescription.Text;
                oPromoCPSimple.FromDate = dtFromDate.Value.Date;
                oPromoCPSimple.ToDate = dtTodate.Value.Date;
                oPromoCPSimple.CreateDate = DateTime.Now;
                oPromoCPSimple.CreateUserID = Utility.UserId;
                oPromoCPSimple.Remarks = txtRemarks.Text;
                oPromoCPSimple.IsActive = (int)Dictionary.IsActive.Active;
                string sProductCode = "";
                string sProductID = "";
                foreach (DataGridViewRow oItemRow in dgData.Rows)
                {
                    if (oItemRow.Index < dgData.Rows.Count)
                    {
                        if (sProductCode == "")
                        {
                            sProductCode = "'" + oItemRow.Cells[0].Value.ToString().Trim() + "'";
                        }
                        else
                        {
                            //if (!sProductCode.Contains("'" + oItemRow.Cells[0].Value.ToString().Trim() + "'"))
                                sProductCode = sProductCode + ',' + "'" + oItemRow.Cells[0].Value.ToString().Trim() + "'";
                        }

                    }
                }

                Products oProducts = new Products();
                sProductID = oProducts.RefreshProductIDByListCode(sProductCode);
                if (sProductID != "")
                    oPromoCPSimple.ProductID = sProductID;
                else return;

                
                if (rdoFlatAmt.Checked == true)
                {
                    oPromoCPSimple.DiscountType = (int)Dictionary.SalesPromOfferType.FlatAmount;
                    oPromoCPSimple.Amount = Convert.ToDouble(txtDiscount.Text);

                }
                else if (rdoDiscountPercent.Checked == true)
                {
                    oPromoCPSimple.DiscountType = (int)Dictionary.SalesPromOfferType.Parcent;
                    oPromoCPSimple.Amount = Convert.ToDouble(txtDiscount.Text);
                }

                // Warehouse
                string sWarehouse = "";
                addCheckedNode(tvwShowroom.Nodes);
                int nWarehouseSelect = 0;
                foreach (DSPromotion.PromoWarehouseRow oPromoWarehouseRow in oDSPromotion.PromoWarehouse)
                {

                    if (sWarehouse == "")
                    {
                        sWarehouse = oPromoWarehouseRow.WarehouseID.ToString();
                    }
                    else
                    {
                        //if (!sWarehouse.Contains(oPromoWarehouseRow.WarehouseID.ToString()))
                            sWarehouse = sWarehouse + ',' + oPromoWarehouseRow.WarehouseID.ToString();
                    }
                }
                oPromoCPSimple.Warehouse = sWarehouse.ToString();

                // Sales Type 
                string _sCustType = "";
                string _nSalesType = "";

                addCheckedNodeSalesType(tvwSalesType.Nodes);
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
                {
                    foreach (DSPromotion.PromoSalesTypeRow oPromoSalesTypeRow in oDSPromotion.PromoSalesType)
                    {
                        if (oPromoSalesTypeRow.SalesType == GetEnum)
                        {
                            if (_nSalesType == "")
                            {
                                _nSalesType = oPromoSalesTypeRow.SalesType.ToString();
                            }
                            else
                            {
                                if (!_nSalesType.Contains(oPromoSalesTypeRow.SalesType.ToString()))
                                    _nSalesType = _nSalesType + ',' + oPromoSalesTypeRow.SalesType.ToString();
                            }
                            if (_sCustType == "")
                            {
                                _sCustType = oPromoSalesTypeRow.CustomerType;
                            }
                            else
                            {
                                //if (!_sCustType.Contains(oPromoSalesTypeRow.CustomerType.ToString()))
                                    _sCustType = _sCustType + ',' + oPromoSalesTypeRow.CustomerType;
                            }
                        }
                    }
                }
                oPromoCPSimple.SalesType = _nSalesType.ToString();
                oPromoCPSimple.CustomerType = _sCustType.ToString();
                // Sale Promotion Type 
                string sCPSimpleTypeID = "";
                for (int i = 0; i < lvwPromotionType.Items.Count; i++)
                {
                    ListViewItem itm = lvwPromotionType.Items[i];
                    if (lvwPromotionType.Items[i].Checked == true)
                    {
                        SalesPromotionType oSalesPromotionType = (SalesPromotionType)lvwPromotionType.Items[i].Tag;
                        if (sCPSimpleTypeID == "")
                        {
                            sCPSimpleTypeID = oSalesPromotionType.SalesPromotionTypeID.ToString();
                        }
                        else
                        {
                            //if (!sCPSimpleTypeID.Contains(oSalesPromotionType.SalesPromotionTypeID.ToString()))
                                sCPSimpleTypeID = sCPSimpleTypeID + ',' + oSalesPromotionType.SalesPromotionTypeID.ToString();
                        }
                    }
                }
                oPromoCPSimple.CPSimpleTypeID = sCPSimpleTypeID.ToString();

                oPromoCPSimple.DiscountConrtibutorID = _oConsumerPromotionDiscountContributors[cmbContributor.SelectedIndex - 1].DiscountContributorID;
                oPromoCPSimple.ContributionAmount = Convert.ToDouble(txtContribution.Text);
                if (cmbFreeEMITenure.SelectedIndex != 0)
                    oPromoCPSimple.FreeEMITenureID = _oEMITenures[cmbFreeEMITenure.SelectedIndex - 1].EMITenureID;
                else
                    oPromoCPSimple.FreeEMITenureID = -1;
               string _sOfferDescription = "";
                string sDiscount = "";
                string sEMIDetail = "";
                if (rdoDiscountPercent.Checked)
                    sDiscount = "Discount:" + txtDiscount.Text + "%";
                else if (rdoFlatAmt.Checked)
                    sDiscount = "Flat Discount:" + txtDiscount.Text + " Taka";
                if (cmbFreeEMITenure.SelectedIndex != 0)
                    sEMIDetail += "Free EMI: " + cmbFreeEMITenure.Text;

                if (sDiscount != "")
                {
                    if (_sOfferDescription == "")
                    {
                        _sOfferDescription = sDiscount;
                    }
                    else
                    {
                        _sOfferDescription += sDiscount + " & ";
                    }

                }

                if (sEMIDetail != "")
                {
                    if (_sOfferDescription == "")
                    {
                        _sOfferDescription = sEMIDetail;
                    }
                    else
                    {
                        _sOfferDescription += " & " + sEMIDetail;
                    }
                }
                oPromoCPSimple.PromoDetail = _sOfferDescription;
                oPromoCPSimple.Status = (int)Dictionary.SalesPromStatus.Create;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPromoCPSimple.Add();

                    oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoNo = oPromoCPSimple.CPSimpleNo;
                    // For Promo disable for ecom Start Zahid
                    //if (DisableForEcom.Checked)
                    //{
                    //    oConsumerPromotion.AddPromoDisableFromOnline();
                    //}
                    //else
                    //{
                    //    oConsumerPromotion.DeleteDisablePromo();
                    //}
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
                this.Close();
            }
        }

        private void rdoNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNone.Checked == true)
            {
                lblDiscount.Visible = false;
                txtDiscount.Visible = false;
                lblDiscountType.Visible = false;
            }
            else if (rdoFlatAmt.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(Taka)";
            }
            else if (rdoDiscountPercent.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(%)";
            }
        }

        private void rdoFlatAmt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNone.Checked == true)
            {
                lblDiscount.Visible = false;
                txtDiscount.Visible = false;
                lblDiscountType.Visible = false;
            }
            else if (rdoFlatAmt.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(Taka)";
            }
            else if (rdoDiscountPercent.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(%)";
            }
        }

        private void rdoDiscountPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNone.Checked == true)
            {
                lblDiscount.Visible = false;
                txtDiscount.Visible = false;
                lblDiscountType.Visible = false;
            }
            else if (rdoFlatAmt.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(Taka)";
            }
            else if (rdoDiscountPercent.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(%)";
            }
        }

        private void txtDiscount_TextChanged_1(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtDiscount.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Discount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Text = "";
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

        //private void DisableForEcom_CheckedChanged(object sender, EventArgs e)
        //{

        //}
    }
}
