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
    public partial class frmPromoTPOffers : Form
    {
        public ConsumerPromotion _oConsumerPromotion;
        ConsumerPromotionSlab _oConsumerPromotionSlab;
        ConsumerPromotionOffer _oConsumerPromotionOffer;
        ProductDetail _oProductDetail;
        string sRatio;
        bool _bFlag = false;
        bool _bIsComboOffer = false;
        public bool _IsTrue = false;
        public frmPromoTPOffers()
        {
            InitializeComponent();
        }


        public bool validateUIInput(int nType)
        {
            bool _bError = false;

            if (txtMinInvoiceQty.Text == "")
            {
                MessageBox.Show("Please enter minimum invoice qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow oItemRow in dgvRatio.Rows)
            {
                if (oItemRow.Index < dgvRatio.Rows.Count)
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
                MessageBox.Show("Please enter a valid ratio", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nType == 1)
            {
                if (lvwPromoOffers.Items.Count == 0)
                {
                    MessageBox.Show("Please enter at least one offer ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        public void ShowDialog(ConsumerPromotion oConsumerPromotion, ConsumerPromotionSlab oConsumerPromotionSlab)
        {
            _oConsumerPromotion = oConsumerPromotion;
            if (oConsumerPromotionSlab != null)
            {
                _oConsumerPromotionSlab = oConsumerPromotionSlab;
                txtName.Text = oConsumerPromotionSlab.SlabName.ToString();
                foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oConsumerPromotionSlab.ConsumerPromotionSlabRatios)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRatio);

                    //oRow.Cells[3].Value = oConsumerPromotionSlabRatio.ProductID;
                    //oRow.Cells[2].Value = oConsumerPromotionSlabRatio.Qty.ToString();
                    //_oProductDetail = new ProductDetail();
                    //_oProductDetail.ProductID = oConsumerPromotionSlabRatio.ProductID;
                    //_oProductDetail.Refresh();
                    //oRow.Cells[0].Value = _oProductDetail.ProductCode;
                    //oRow.Cells[1].Value = _oProductDetail.ProductName;
                    dgvRatio.Rows.Add(oRow);
                }
                _bFlag = false;
            }
            else
            {
                foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotion.ConsumerPromotionProductFors)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvRatio);
                    oRow.Cells[0].Value = oConsumerPromotionProductFor.MAG;
                    oRow.Cells[1].Value = oConsumerPromotionProductFor.BrandDesc;
                    oRow.Cells[2].Value = "";
                    oRow.Cells[3].Value = oConsumerPromotionProductFor.ProductGroupID;
                    oRow.Cells[4].Value = oConsumerPromotionProductFor.BrandID;
                    oRow.Cells[5].Value = oConsumerPromotionProductFor.GroupTypeID;
                    dgvRatio.Rows.Add(oRow);
                }
                if (_oConsumerPromotion.Count == 0)
                {
                    txtName.Text = "Slab-01";
                    _bFlag = false;
                }
                else
                {
                    txtName.Text = "Slab-0" + Convert.ToString(_oConsumerPromotion.Count + 1) + "";
                    _bFlag = true;
                }
                _oConsumerPromotionSlab = new ConsumerPromotionSlab();
            }
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validateUIInput(1))
            {

                _oConsumerPromotionSlab.SlabName = txtName.Text;
                _oConsumerPromotionSlab.IsActive = (int)Dictionary.ActiveOrInActiveStatus.ACTIVE;
                _oConsumerPromotionSlab.MinInvoiceQty = Convert.ToInt32(txtMinInvoiceQty.Text);
                int nCount = 0;
                // Promotion Ratio
                _oConsumerPromotionSlab.ConsumerPromotionSlabRatios.Clear();
                foreach (DataGridViewRow oItemRow in dgvRatio.Rows)
                {
                    if (oItemRow.Index < dgvRatio.Rows.Count)
                    {
                        ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                        oConsumerPromotionSlabRatio.Qty = int.Parse(oItemRow.Cells[2].Value.ToString().Trim());
                        oConsumerPromotionSlabRatio.ProductGroupID = int.Parse(oItemRow.Cells[3].Value.ToString().Trim());
                        oConsumerPromotionSlabRatio.BrandID = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                        oConsumerPromotionSlabRatio.GroupTypeID = int.Parse(oItemRow.Cells[5].Value.ToString().Trim());
                        _oConsumerPromotionSlab.ConsumerPromotionSlabRatios.Add(oConsumerPromotionSlabRatio);
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
                _oConsumerPromotion.Add(_oConsumerPromotionSlab);
                _IsTrue = true;
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (validateUIInput(-1))
            {
                frmPromoTPOffer oFrom = new frmPromoTPOffer();
                oFrom.ShowDialog(_oConsumerPromotionSlab, null);
                _oConsumerPromotionSlab = oFrom._oConsumerPromotionSlab;

                if (_oConsumerPromotionSlab.ConsumerPromotionOffers.Count > 0)
                {
                    lvwPromoOffers.Items.Clear();
                    foreach (ConsumerPromotionOffer oConsumerPromotionOffer in _oConsumerPromotionSlab.ConsumerPromotionOffers)
                    {
                        sRatio = "";
                        ListViewItem lstItem = lvwPromoOffers.Items.Add(oConsumerPromotionOffer.OfferName.ToString());
                        lstItem.SubItems.Add(oConsumerPromotionOffer.OfferDetails.ToString());

                        lstItem.Tag = oConsumerPromotionOffer;
                    }
                }
                else lvwPromoOffers.Items.Clear();
            }
        }

        private void txtMinInvoiceQty_TextChanged(object sender, EventArgs e)
        {
            if (txtMinInvoiceQty.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtMinInvoiceQty.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMinInvoiceQty.Text = "";
                }

            }
        }
    }
}