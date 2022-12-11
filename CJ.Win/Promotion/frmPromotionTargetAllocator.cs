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

    public partial class frmPromotionTargetAllocator : Form
    {
        //PromoDiscountContributors _oConsumerPromotionDiscountContributors;
        public int _TargetQtyTotal = 0;
        public double _TargetValTotal = 0;
        public double _ProCostValTotal = 0;
        public double _NetValTotal = 0;
        public int _RegSalesQtyTotal = 0;
        public double _TargetMCTotal = 0;
        public int _nProductID;

        TELLib _oTELLib = new TELLib();
        public DSPromotionAllocate _oDSPromotionAllocate;
        public frmPromotionTargetAllocator(int nProductID)
        {
            InitializeComponent();
            _nProductID = nProductID;
        }

        private void frmPromotionTargetAllocator_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            cmbSalesType.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;

        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvTargetAllocator);

                oRow.Cells[0].Value = cmbSalesType.Text;
                oRow.Cells[1].Value = txtTargetQty1.Text;
                oRow.Cells[2].Value = txtTargetVal1.Text;
                oRow.Cells[3].Value = txtPromoCostVal1.Text;
                oRow.Cells[4].Value = txtNetSalesVal1.Text;
                oRow.Cells[5].Value = txtRegSalesQty1.Text;
                oRow.Cells[6].Value = txtTargetMC1.Text;
                oRow.Cells[7].Value = cmbSalesType.SelectedIndex;//(int)Dictionary.SalesType.Dealer;
              
                dgvTargetAllocator.Rows.Add(oRow);


                
                if (checkDuplicateLineItem(dgvTargetAllocator.Rows[dgvTargetAllocator.Rows.Count-1].Cells[0].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Sales Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvTargetAllocator.Rows.RemoveAt(dgvTargetAllocator.Rows.Count-1);
                    return;
                }
                

                TotalAmount();
            }
        }

        private bool UIValidation()
        {
            if (cmbSalesType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Sales Type","Info" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTargetQty1.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Target Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTargetQty1.Focus();
                return false;
            }
            else
            {
                try
                {
                    int x = Convert.ToInt32(txtTargetQty1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Target Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtTargetVal1.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Target Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTargetVal1.Focus();
                return false;
            }
            else
            {
                try
                {
                    double x = Convert.ToDouble(txtTargetVal1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Target Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtPromoCostVal1.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Promo Cost Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPromoCostVal1.Focus();
                return false;
            }
            else
            {
                try
                {
                    double x = Convert.ToDouble(txtPromoCostVal1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Promo Cost Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtNetSalesVal1.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Net Sales Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNetSalesVal1.Focus(); 
                return false;
            }
            else
            {
                try
                {
                    double x = Convert.ToDouble(txtNetSalesVal1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Net Sales Value", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtRegSalesQty1.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Regular Sales Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegSalesQty1.Focus();
                return false;
            }
            else
            {
                try
                {
                    int x = Convert.ToInt32(txtRegSalesQty1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Regular Sales Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtTargetMC1.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Target MC", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegSalesQty1.Focus();
                return false;
            }
            else
            {
                try
                {
                    double x = Convert.ToDouble(txtTargetMC1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Input Correct Target MC", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


            return true;
        }

        private void TotalAmount()
        {
            _oDSPromotionAllocate = new DSPromotionAllocate();
            int _TotalTargetQty = 0;
            double _TotalTargetVal = 0;
            double _TotalPromoCostVal = 0;
            double _TotalNetVal = 0;
            int _TotalRegularSalesQty = 0;
            double _TotalTargetMC = 0;

            foreach (DataGridViewRow oItemRow in dgvTargetAllocator.Rows)
            {
                if (oItemRow.Index < dgvTargetAllocator.Rows.Count)
                {
                    if (oItemRow.Cells[1].Value.ToString().Trim() != "")
                    {
                        DSPromotionAllocate.PromotionAllocateRow oDSRow = _oDSPromotionAllocate.PromotionAllocate.NewPromotionAllocateRow();

                        oDSRow.SalesTypeID = Convert.ToInt32(oItemRow.Cells[7].Value);
                        oDSRow.TargetQty = Convert.ToInt32(oItemRow.Cells[1].Value);
                        oDSRow.TargetValue = Convert.ToDouble(oItemRow.Cells[2].Value);
                        oDSRow.PromoCostVal = Convert.ToDouble(oItemRow.Cells[3].Value);
                        oDSRow.NetSalesVal = Convert.ToDouble(oItemRow.Cells[4].Value);
                        oDSRow.RegularSalesQty = Convert.ToInt32(oItemRow.Cells[5].Value);
                        oDSRow.TargetMC = Convert.ToDouble(oItemRow.Cells[6].Value);
                        oDSRow.ProductID = _nProductID;


                        _oDSPromotionAllocate.PromotionAllocate.AddPromotionAllocateRow(oDSRow);
                        _oDSPromotionAllocate.AcceptChanges();

                        _TotalTargetQty += Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                        _TotalTargetVal += Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        _TotalPromoCostVal += Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                        _TotalNetVal += Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                        _TotalRegularSalesQty += Convert.ToInt32(oItemRow.Cells[5].Value.ToString());
                        _TotalTargetMC += Convert.ToDouble(oItemRow.Cells[6].Value.ToString());

                    }
                }
            }
            txtTotTargetQty.Text = _TotalTargetQty.ToString();
            txtTotTargetVal.Text = _oTELLib.TakaFormat(_TotalTargetVal);
            txtTotProCostVal.Text = _oTELLib.TakaFormat(_TotalPromoCostVal);
            txtTotalNetVal.Text = _oTELLib.TakaFormat(_TotalNetVal);
            txtTotRegSalesQty.Text = _TotalRegularSalesQty.ToString();
            txtTotalTargetMC.Text = _oTELLib.TakaFormat(_TotalTargetMC);

            _TargetQtyTotal = _TotalTargetQty;
            _TargetValTotal = Convert.ToDouble(txtTotTargetVal.Text);
            _ProCostValTotal = Convert.ToDouble(txtTotProCostVal.Text);
            _NetValTotal = Convert.ToDouble(txtTotalNetVal.Text);
            _RegSalesQtyTotal = _TotalRegularSalesQty;
            _TargetMCTotal = Convert.ToDouble(txtTotalTargetMC.Text);
        }


       

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (dgvTargetAllocator.Rows.Count != 0)
            {
                this.Close();
            }
        }

        private void dgvTargetAllocator_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TotalAmount();
        }

        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvTargetAllocator.Rows)
            {
                if (oItemRow.Index < dgvTargetAllocator.Rows.Count)
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
    }
}
