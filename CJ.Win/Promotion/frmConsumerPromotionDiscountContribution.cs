using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Library;
using CJ.Class;

using CJ.Class.Promotion;

namespace CJ.Win.Promotion
{

    public partial class frmConsumerPromotionDiscountContribution : Form
    {
        PromoDiscountContributors _oConsumerPromotionDiscountContributors;
        public double _ContributionTotal = 0;
        TELLib _oTELLib = new TELLib();
        public DSPromotionContribution _oDSPromotionContribution;
        public frmConsumerPromotionDiscountContribution()
        {
            InitializeComponent();
            
        }

        private void frmConsumerPromotionDiscountContribution_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            _oConsumerPromotionDiscountContributors = new PromoDiscountContributors();
            _oConsumerPromotionDiscountContributors.Refresh();
            cmbContributor.Items.Clear();
            cmbContributor.Items.Add("-- Select Contributor--");
            foreach (PromoDiscountContributor oData in _oConsumerPromotionDiscountContributors)
            {
                cmbContributor.Items.Add(oData.DiscountContributorName);
            }
            cmbContributor.SelectedIndex = 0;

        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvContribution);

                oRow.Cells[0].Value = cmbContributor.Text;
                oRow.Cells[1].Value = txtContributionAmount.Text;
                oRow.Cells[2].Value = _oConsumerPromotionDiscountContributors[cmbContributor.SelectedIndex - 1].DiscountContributorID;
                if (rdoDiscountPercent.Checked == true)
                {
                    oRow.Cells[3].Value = (int)Dictionary.PromoContributionType.Parcent;
                }
                else if (rdoFlatAmt.Checked == true)
                {
                    oRow.Cells[3].Value = (int)Dictionary.PromoContributionType.Amount;
                }
                dgvContribution.Rows.Add(oRow);

                TotalAmount();
            }
        }

        private bool UIValidation()
        {
            if (cmbContributor.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Contributor","Info" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtContributionAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Contribution Amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContributionAmount.Focus(); 
                return false;
            }
            else
            {
                try
                {
                    double x = Convert.ToDouble(txtContributionAmount.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void TotalAmount()
        {
            _oDSPromotionContribution = new DSPromotionContribution();
            double _TotalAmount = 0;
            foreach (DataGridViewRow oItemRow in dgvContribution.Rows)
            {
                if (oItemRow.Index < dgvContribution.Rows.Count)
                {
                    if (oItemRow.Cells[1].Value.ToString().Trim() != "")
                    {
                        DSPromotionContribution.PromotionContributionRow oDSRow = _oDSPromotionContribution.PromotionContribution.NewPromotionContributionRow();

                        oDSRow.DiscountContributorID = Convert.ToInt32(oItemRow.Cells[2].Value);
                        oDSRow.Amount = Convert.ToDouble(oItemRow.Cells[1].Value);
                        oDSRow.ContributorName = Convert.ToString(oItemRow.Cells[0].Value);
                        oDSRow.Type = Convert.ToInt32(oItemRow.Cells[3].Value);


                        _oDSPromotionContribution.PromotionContribution.AddPromotionContributionRow(oDSRow);
                        _oDSPromotionContribution.AcceptChanges();

                        _TotalAmount += Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                    }
                }
            }
            txtTotalAmount.Text = _oTELLib.TakaFormat(_TotalAmount);
            _ContributionTotal = Convert.ToDouble(txtTotalAmount.Text);
        }


        private void dgvContribution_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TotalAmount();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoFlatAmt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFlatAmt.Checked == true)
            {
                lblDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(Amount)";
            }
            else if (rdoDiscountPercent.Checked == true)
            {
                lblDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(%)";
            }
        }

        private void rdoDiscountPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFlatAmt.Checked == true)
            {
                lblDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(Amount)";
            }
            else if (rdoDiscountPercent.Checked == true)
            {
                lblDiscount.Visible = true;
                lblDiscountType.Visible = true;
                lblDiscountType.Text = "(%)";
            }
        }
    }
}
