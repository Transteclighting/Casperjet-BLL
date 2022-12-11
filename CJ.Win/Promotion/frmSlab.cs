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
using System.Text.RegularExpressions;

namespace CJ.Win.Promotion
{
    public partial class frmSlab : Form
    {
        ProductDetail _oProductDetail;
        public SPromotion _oSPromotion;
        SalesPromotionSlab _oSalesPromotionSlab;
        int _nCount = 0;
        bool _bFlag = false;
        public bool _bRatioNotSet = false;
        public bool _bIsComboOffer = false;
        int _nUIControl = 0;

        public frmSlab(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
          
        }

        private void frmSlab_Load(object sender, EventArgs e)
        {
            if (_nUIControl == 0)
            {
                rdoNone.Checked = true;
                lblDiscount.Visible = false;
                txtDiscount.Visible = false;
                lblDiscountType.Visible = false;
            }
        }
        public void ShowDialog(SPromotion oSPromotion, SalesPromotionSlab oSalesPromotionSlab)
        {
            _oSPromotion = oSPromotion;

            if (oSalesPromotionSlab != null)
            {
                _oSalesPromotionSlab = oSalesPromotionSlab;
                txtSlabNo.Text = oSalesPromotionSlab.SlabNo.ToString();
                txtName.Text = oSalesPromotionSlab.SlabName.ToString();

                if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.None)
                {
                    rdoNone.Checked = true;
                    rdoFlatAmt.Checked = false;
                    rdoDiscountPercent.Checked = false;

                    lblDiscount.Visible = false;
                    txtDiscount.Visible = false;
                    lblDiscountType.Visible = false;

                }
                else if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
                {
                    rdoNone.Checked = false;
                    rdoFlatAmt.Checked = true;
                    rdoDiscountPercent.Checked = false;
                    
                    lblDiscount.Visible = true;
                    lblDiscountType.Visible = true;
                    lblDiscountType.Text = "(Amount)";
                    txtDiscount.Visible = true;
                    txtDiscount.Text = oSalesPromotionSlab.Discount.ToString();
                }
                else if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.Parcent)
                {
                    rdoNone.Checked = false;
                    rdoFlatAmt.Checked = false;
                    rdoDiscountPercent.Checked = true;

                    lblDiscount.Visible = true;
                    lblDiscountType.Visible = true;
                    lblDiscountType.Text = "(%)";
                    txtDiscount.Visible = true;
                    txtDiscount.Text = oSalesPromotionSlab.Discount.ToString();
                }


                //txtSlabQty.Text = oSalesPromotionSlab.SlabAmount.ToString();
                if (oSalesPromotionSlab.IsActive != 1)
                {
                    //chkbActive.Checked = true;
                }
                foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRatio);

                    oRow.Cells[3].Value = oSPSlabRatio.ProductID;
                    oRow.Cells[2].Value = oSPSlabRatio.Qty.ToString();
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = oSPSlabRatio.ProductID;
                    _oProductDetail.Refresh();
                    oRow.Cells[0].Value = _oProductDetail.ProductCode;
                    oRow.Cells[1].Value = _oProductDetail.ProductName;
                    dgvRatio.Rows.Add(oRow);
                }
               
                _nCount = 0;
                if (oSalesPromotionSlab.SPFreeProducts.Count > 0)
                {
                    foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvFreeProduct);

                        oRow.Cells[4].Value = oSPFreeProduct.ProductID;
                        oRow.Cells[3].Value = oSPFreeProduct.Qty.ToString();
                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductID = oSPFreeProduct.ProductID;
                        _oProductDetail.Refresh();
                        oRow.Cells[0].Value = _oProductDetail.ProductCode;
                        oRow.Cells[2].Value = _oProductDetail.ProductName;

                        dgvFreeProduct.Rows.Add(oRow);

                        
                    }
                }
                if (oSalesPromotionSlab.SPDiscountSlab.DiscountAmount != 0)
                {
                    txtDiscount.Text = oSalesPromotionSlab.SPDiscountSlab.DiscountAmount.ToString();
                    //ckbDiscount.Checked = true;

                    txtName.Text = oSalesPromotionSlab.SPDiscountSlab.GroupName;
                    if (oSalesPromotionSlab.SPDiscountSlab.MarkUp != 0)
                    {                    
                        //ckbMarkup.Checked = true;
                        //txtMarkUp.Text = oSalesPromotionSlab.SPDiscountSlab.MarkUp.ToString();
                    }
                }
                if (oSalesPromotionSlab.SPFlatSlab.FlatAmount != 0)
                {
                    //txtFlatAmount.Text = oSalesPromotionSlab.SPFlatSlab.FlatAmount.ToString();
                    //ckbFlatAmount.Checked = true;

                    txtName.Text = oSalesPromotionSlab.SPFlatSlab.GroupName;
                    if (oSalesPromotionSlab.SPFlatSlab.MarkUp != 0)
                    {                       
                        //ckbMarkup.Checked = true;
                        //txtMarkUp.Text = oSalesPromotionSlab.SPFlatSlab.MarkUp.ToString();
                    }
                }
                //txtSlabQty.Enabled = false;
                //txtName.Enabled = false;
                //chkbActive.Enabled = false;
                //txtPerUnit.Enabled = false;

                _bFlag = false;
            }
            else
            {                
                foreach (SPProduct oSPProduct in _oSPromotion.SPProducts)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRatio);

                    oRow.Cells[3].Value = oSPProduct.ProductID;
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = oSPProduct.ProductID;
                    _oProductDetail.Refresh();
                    oRow.Cells[0].Value = _oProductDetail.ProductCode;
                    oRow.Cells[1].Value = _oProductDetail.ProductName;
                    dgvRatio.Rows.Add(oRow);
                }
                if (_oSPromotion.Count == 0)
                {
                    txtSlabNo.Text = "1";
                    _bFlag = false;
                }
                else
                {
                    txtSlabNo.Text = Convert.ToString(_oSPromotion.Count + 1);
                    _bFlag = true;
                }
                _oSalesPromotionSlab = new SalesPromotionSlab();
            }
            this.ShowDialog();
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
                    oRow.CreateCells(dgvFreeProduct);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[4].Value = oForm._oProductDetail.ProductID;
                    

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvFreeProduct.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvFreeProduct.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvFreeProduct.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvFreeProduct.Rows[e.RowIndex].Cells[0].ReadOnly = true;
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
            if (nColumnIndex == 0 && dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvFreeProduct.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oProductDetail.ProductID).ToString();
                        dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = (_oProductDetail.ItemCategory).ToString();
                        dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvFreeProduct.Rows.RemoveAt(nRowIndex);
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
            foreach (DataGridViewRow oItemRow in dgvFreeProduct.Rows)
            {
                if (oItemRow.Index < dgvFreeProduct.Rows.Count - 1)
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

        private void ckbMarkup_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbMarkup.Checked == true)
            //{
            //    txtMarkUp.Enabled=true;
            //}
            //else txtMarkUp.Enabled = false;
        }
        private void ckbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbDiscount.Checked == true)
                //txtDiscount.Enabled = true;
            //else txtDiscount.Enabled = false;

        }
        private void ckbFlatAmount_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckbFlatAmount.Checked == true)
            //    txtFlatAmount.Enabled = true;
            //else txtFlatAmount.Enabled = false;
        }

        public bool validateUIInput()
        {
            bool _bError = false;
         
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Slab Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (rdoDiscountPercent.Checked == true)
            {
                try
                {
                    double Tem = Convert.ToDouble(txtDiscount.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a Valid Discount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
            }
            if (rdoFlatAmt.Checked == true)
            {
                try
                {
                    double Tem = Convert.ToDouble(txtDiscount.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a Valid Flat Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
            }
           
            foreach (DataGridViewRow oItemRow in dgvRatio.Rows)
            {
                if (oItemRow.Index < dgvRatio.Rows.Count )
                {
                    if (oItemRow.Cells[2].Value != null)
                    {
                        try
                        {
                            int temp = int.Parse(oItemRow.Cells[2].Value.ToString());
                        }
                        catch
                        {
                            _bError = true;
                            break;
                        }
                    }
                    else 
                    {
                        _bError = true;
                        break;
                    }
                }
            }
            if (_bError == true)
            {
                MessageBox.Show("Please enter a Valid Ratio", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvRatio.Rows)
            {
                if (oItemRow.Index < dgvRatio.Rows.Count)
                {
                    if (oItemRow.Cells[2].Value != null)
                    {
                        _bRatioNotSet = false;
                        break;
                    }
                    else _bRatioNotSet = true;
                }
            }
            int nCount = 0;
            if (dgvFreeProduct.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvFreeProduct.Rows)
                {
                    if (oItemRow.Index < dgvFreeProduct.Rows.Count - 1)
                    {
                        try
                        {
                            int temp = int.Parse(oItemRow.Cells[3].Value.ToString());
                            nCount++;
                        }
                        catch
                        {
                            _bError = true;
                            break;
                        }
                    }
                }
                if (_bError == true)
                {
                    MessageBox.Show("Please enter a Valid Free Product Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (nCount > 1)
                {
                    MessageBox.Show("You can enter only one free product under a slab", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (rdoNone.Checked == true && nCount == 0)
            {
                MessageBox.Show("You have to define either free product or discount under a slab", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_bRatioNotSet==false)
            {
                if (_bFlag)
                {
                    if (_oSPromotion.Count > 0)
                    {

                        foreach (SalesPromotionSlab oSalesPromotionSlab in _oSPromotion)
                        {
                            foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                            {
                                foreach (DataGridViewRow oItemRow in dgvRatio.Rows)
                                {
                                    if (oItemRow.Index < dgvRatio.Rows.Count)
                                    {
                                        if (oSPSlabRatio.ProductID == int.Parse(oItemRow.Cells[3].Value.ToString()))
                                        {
                                            if (int.Parse(oItemRow.Cells[2].Value.ToString()) <= oSPSlabRatio.Qty)
                                            {
                                                MessageBox.Show("Slab Ratio Quantity Must Greater Than Previous Ratio  Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                return false;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            
            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_oSPromotion.Count > 0)
            {
                int i = 0;
                foreach (SalesPromotionSlab oSalesPromotionSlab in _oSPromotion)
                {
                    if (oSalesPromotionSlab.SlabNo == int.Parse(txtSlabNo.Text))
                    {
                        _oSPromotion.RemoveAt(i);

                        break;
                    }
                    i++;
                }
            }
            if (validateUIInput())
            {               

                _oSalesPromotionSlab.SlabNo = int.Parse(txtSlabNo.Text);
                _oSalesPromotionSlab.SlabName = txtName.Text;
                _oSalesPromotionSlab.IsActive = (int)Dictionary.ActiveOrInActiveStatus.ACTIVE;

                if (rdoNone.Checked == true)
                {
                    _oSalesPromotionSlab.DiscountType = (int)Dictionary.SalesPromSlabDiscountType.None;
                    _oSalesPromotionSlab.Discount = 0;
                }
                else if (rdoFlatAmt.Checked == true)
                {
                    _oSalesPromotionSlab.DiscountType = (int)Dictionary.SalesPromSlabDiscountType.FlatAmount;
                    _oSalesPromotionSlab.Discount = Convert.ToDouble(txtDiscount.Text.ToString());
                }
                else if (rdoDiscountPercent.Checked == true)
                {
                    _oSalesPromotionSlab.DiscountType = (int)Dictionary.SalesPromSlabDiscountType.Parcent;
                    _oSalesPromotionSlab.Discount = Convert.ToDouble(txtDiscount.Text.ToString());
                }
                int nCount = 0;
                 // Promotion Ratio
                _oSalesPromotionSlab.SPSlabAllRatio.Clear();
                foreach (DataGridViewRow oItemRow in dgvRatio.Rows)
                {
                    if (oItemRow.Index < dgvRatio.Rows.Count)
                    {
                        
                        SPSlabRatio oSPSlabRatio = new SPSlabRatio();

                        oSPSlabRatio.ProductID = int.Parse(oItemRow.Cells[3].Value.ToString().Trim());
                        //if (_bRatioNotSet)
                          //  oSPSlabRatio.Qty = 1;
                        //else
                        oSPSlabRatio.Qty = int.Parse(oItemRow.Cells[2].Value.ToString().Trim());

                        _oSalesPromotionSlab.SPSlabAllRatio.Add(oSPSlabRatio);
                        nCount++;
                    }
                }
                if (nCount > 1)
                {
                    _bIsComboOffer = true;
                }
                else
                {
                    _bIsComboOffer = false;
                }
                
                // Free Product 
                _oSalesPromotionSlab.SPFreeProducts.Clear();
                if (dgvFreeProduct.Rows.Count > 1)
                {
                    foreach (DataGridViewRow oItemRow in dgvFreeProduct.Rows)
                    {
                        if (oItemRow.Index < dgvFreeProduct.Rows.Count - 1)
                        {
                            SPFreeProduct oSPFreeProduct = new SPFreeProduct();

                            oSPFreeProduct.ProductID = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                            oSPFreeProduct.Qty = int.Parse(oItemRow.Cells[3].Value.ToString().Trim());

                            _oSalesPromotionSlab.SPFreeProducts.Add(oSPFreeProduct);
                        }
                    }
                }              
                _oSPromotion.Add(_oSalesPromotionSlab);
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
                lblDiscountType.Text = "(Amount)";
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
                lblDiscountType.Text = "(Amount)";
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
                lblDiscountType.Text = "(Amount)";
            }
            else if (rdoDiscountPercent.Checked == true)
            {
                lblDiscount.Visible = true;
                txtDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(%)";
            }
        }
       
    }
}