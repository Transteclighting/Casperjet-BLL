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
    public partial class frmSalesPromoOffer : Form
    {
        public ConsumerPromotionSlab _oConsumerPromotionSlab;
        ConsumerPromotionOffer _oConsumerPromotionOffer;
        ConsumerPromotionOfferDetail oConsumerPromotionOfferDetail;
        ProductDetail _oProductDetail;
        public string _sOfferDetails = "";
        EMITenures _oEMITenures;

        string sDiscount = "";

        string sFreeProduct = "";
        string sEMIDetail = "";

        public void ShowDialog(ConsumerPromotionSlab oConsumerPromotionSlab, ConsumerPromotionOffer oConsumerPromotionOffer)
        {
            _oConsumerPromotionSlab = oConsumerPromotionSlab;
            if (_oConsumerPromotionSlab.ConsumerPromotionOffers.Count == 0)
            {
                txtOfferName.Text = "Offer-01";
            }
            else
            {
                txtOfferName.Text = "Offer-0" + Convert.ToString(_oConsumerPromotionSlab.ConsumerPromotionOffers.Count + 1) + "";
            }
            _oConsumerPromotionOffer = new ConsumerPromotionOffer();

            this.ShowDialog();
        }

        private void LoadCombos()
        {
            _oEMITenures = new EMITenures();
            _oEMITenures.Refresh();
            cmbFreeEMITenure.Items.Clear();
            cmbFreeEMITenure.Items.Add("Not Applicable");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbFreeEMITenure.Items.Add(oEMITenure.Tenure.ToString());
            }
            cmbFreeEMITenure.SelectedIndex = 0;
        }

        public frmSalesPromoOffer()
        {
            InitializeComponent();
        }

        public bool validateUIInput()
        {
            bool _bError = false;
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
                //if (nCount > 1)
                //{
                //    MessageBox.Show("You can enter only one free product under a slab", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}

            }
            if (rdoNone.Checked == true && nCount == 0 && cmbFreeEMITenure.SelectedIndex == 0)
            {
               // MessageBox.Show("You have to define either free product or discount under a offer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Plese set offer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (validateUIInput())
            {
                string _sOfferDescription = "";
                sDiscount = "";
                sFreeProduct = "";
                sEMIDetail = "";

                
                if (rdoNone.Checked != true)
                {
                    oConsumerPromotionOfferDetail = new ConsumerPromotionOfferDetail();
                    if (rdoFlatAmt.Checked == true)
                    {
                        oConsumerPromotionOfferDetail.OfferType = (int)Dictionary.SalesPromOfferType.FlatAmount;
                        oConsumerPromotionOfferDetail.Discount = Convert.ToDouble(txtDiscount.Text);
                        oConsumerPromotionOfferDetail.OfferDetail = "Flat Discount:" + txtDiscount.Text + " Taka";
                    }
                    else if (rdoDiscountPercent.Checked == true)
                    {
                        oConsumerPromotionOfferDetail.OfferType = (int)Dictionary.SalesPromOfferType.Parcent;
                        oConsumerPromotionOfferDetail.Discount = Convert.ToDouble(txtDiscount.Text);
                        oConsumerPromotionOfferDetail.OfferDetail = "Discount:" + txtDiscount.Text + "%";
                    }
                    oConsumerPromotionOfferDetail.OfferProductID = -1;
                    oConsumerPromotionOfferDetail.OfferQty = 0;
                    oConsumerPromotionOfferDetail.EMITenureID = -1;
                    sDiscount = oConsumerPromotionOfferDetail.OfferDetail;
                    _oConsumerPromotionOffer.Add(oConsumerPromotionOfferDetail);

                }
                // Free Product 
                if (dgvFreeProduct.Rows.Count > 1)
                {
                    foreach (DataGridViewRow oItemRow in dgvFreeProduct.Rows)
                    {
                        if (oItemRow.Index < dgvFreeProduct.Rows.Count - 1)
                        {
                            oConsumerPromotionOfferDetail = new ConsumerPromotionOfferDetail();
                            oConsumerPromotionOfferDetail.OfferType = (int)Dictionary.SalesPromOfferType.Product;
                            oConsumerPromotionOfferDetail.OfferProductID = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                            oConsumerPromotionOfferDetail.OfferQty = int.Parse(oItemRow.Cells[3].Value.ToString().Trim());
                            oConsumerPromotionOfferDetail.Discount = 0;
                            if (sFreeProduct != "")
                            {
                                sFreeProduct = sFreeProduct + " " + "& ";
                            }
                            sFreeProduct = sFreeProduct + "Free Product:" + oItemRow.Cells[2].Value.ToString().Trim() + "";
                            oConsumerPromotionOfferDetail.OfferDetail = sFreeProduct;
                            oConsumerPromotionOfferDetail.EMITenureID = -1;
                            _oConsumerPromotionOffer.Add(oConsumerPromotionOfferDetail);
                        }
                    }
                }
                //EMI Detail
                if (cmbFreeEMITenure.SelectedIndex != 0)
                {
                    oConsumerPromotionOfferDetail = new ConsumerPromotionOfferDetail();
                    oConsumerPromotionOfferDetail.OfferType = (int)Dictionary.SalesPromOfferType.EMI;
                    oConsumerPromotionOfferDetail.OfferProductID = -1;
                    oConsumerPromotionOfferDetail.OfferQty = 0;
                    oConsumerPromotionOfferDetail.Discount = 0;
                    oConsumerPromotionOfferDetail.EMITenureID = _oEMITenures[cmbFreeEMITenure.SelectedIndex - 1].EMITenureID;
                    sEMIDetail += "Free EMI: " + cmbFreeEMITenure.Text;
                    oConsumerPromotionOfferDetail.OfferDetail = sEMIDetail;
                    _oConsumerPromotionOffer.Add(oConsumerPromotionOfferDetail);
                }

                _oConsumerPromotionOffer.OfferName = txtOfferName.Text;
                _oConsumerPromotionOffer.CreateDate = DateTime.Now.Date;
                _oConsumerPromotionOffer.CreateUserID = Utility.UserId;
                _oConsumerPromotionOffer.IsActive = (int)Dictionary.IsActive.Active;


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
                if (sFreeProduct != "")
                {
                    if (_sOfferDescription == "")
                    {
                        _sOfferDescription = sFreeProduct;
                    }
                    else
                    {
                        _sOfferDescription += " & " + sFreeProduct;
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
                _oConsumerPromotionOffer.OfferDetails = _sOfferDescription;
                _oConsumerPromotionSlab.ConsumerPromotionOffers.Add(_oConsumerPromotionOffer);
                this.Close();
            }
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
                        //dgvFreeProduct.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = (_oProductDetail.ItemCategory).ToString();
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

        private void frmSalesPromoOffer_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}