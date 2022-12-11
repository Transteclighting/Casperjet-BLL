using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.Claim
{
    public partial class frmReengineeredStockTran : Form
    {
        ProductDetail _oProductDetail;
        ProductTransaction oProductTransaction;
        ReplaceClaimStock oReplaceClaimStock;
       

        public frmReengineeredStockTran()
        {
            InitializeComponent();
        }

        private void frmReengineeredStockTran_Load(object sender, EventArgs e)
        {

        }     

        private void rdbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPLS.Checked)
                rdbRSL.Checked = false;
        }

        private void rdbDeduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRSL.Checked)
                rdbPLS.Checked = false;
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
              
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[6].Value = oForm._oProductDetail.ProductID;

                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvLineItem.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                        oReplaceClaimStock = new ReplaceClaimStock();
                       // oReplaceClaimStock.GetCurrentStock(Utility.ClaimWHID, _oProductDetail.ProductID);
                        oReplaceClaimStock.GetCurrentStock((int)Dictionary.ReplaceWareHouse.ReplaceCentralWH, _oProductDetail.ProductID);
                        oRow.Cells[4].Value = oReplaceClaimStock.CurrentStock;
                     
                    }
                }
            }


        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {          

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (_oProductDetail.ProductID).ToString();
                        oReplaceClaimStock = new ReplaceClaimStock();
                        //oReplaceClaimStock.GetCurrentStock(Utility.ClaimWHID, _oProductDetail.ProductID);
                        oReplaceClaimStock.GetCurrentStock((int)Dictionary.ReplaceWareHouse.ReplaceCentralWH, _oProductDetail.ProductID);
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = oReplaceClaimStock.CurrentStock; ;

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                      

                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (nColumnIndex == 3)
            {
                long nRem = 0;
                long nQuotient = 0;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[6].Value);
                _oProductDetail.Refresh();
                
                //if (_oProductDetail.UOMConversionFactor != 0)
                //{
                //    try
                //    {
                //        nQuotient = Math.DivRem(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[3].Value), _oProductDetail.UOMConversionFactor, out nRem);

                //        if (nRem > 0)
                //        {
                //            MessageBox.Show("Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString() + "  is, " + _oProductDetail.UOMConversionFactor.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            dgvLineItem.Rows[nRowIndex].Cells[5].Value = "";
                //            return;

                //        }
                //        else
                //        {
                //            dgvLineItem.Rows[nRowIndex].Cells[5].Value = nQuotient;
                //        }

                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("Please Enter Valied Product Quantity ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        dgvLineItem.Rows[nRowIndex].Cells[5].Value = "";
                //        return;
                //    }
                //}
            }

        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
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
        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

            if (txtTransationNo.Text == "")
            {
                MessageBox.Show("Please input tranno.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTransationNo.Focus();
                return false;
            }      
           
            #endregion

            #region Transaction Details Information Validation

            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valied Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[3].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    //if (int.Parse(oItemRow.Cells[3].Value.ToString()) > int.Parse(oItemRow.Cells[4].Value.ToString()))
                    //{
                    //    MessageBox.Show("Quntity Must Less or equal Current stock Quntity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}

                }
            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    ReplaceClaimTran oReplaceClaimTran;
                    oReplaceClaimTran = new ReplaceClaimTran();

                    oReplaceClaimTran = GetUIProductTransactionData(oReplaceClaimTran);
                    if (oReplaceClaimTran.CheckTranNo())
                    {
                        oReplaceClaimTran.Insert();

                        foreach (ReplaceClaimTranItem oReplaceClaimTranItem in oReplaceClaimTran)
                        {
                            ReplaceClaimStock oReplaceClaimStock = new ReplaceClaimStock();

                            oReplaceClaimStock.ProductID = oReplaceClaimTranItem.ProductID;
                            oReplaceClaimStock.Qty = oReplaceClaimTranItem.Quantity;
                            oReplaceClaimStock.WarehouseID = oReplaceClaimTran.ToWHID;

                            if (oReplaceClaimStock.CheckProductStock())
                            {
                                oReplaceClaimStock.UpdateCurrentStock(true);
                            }
                            else
                            {
                                oReplaceClaimStock.Insert();
                                oReplaceClaimStock.UpdateRepStock(true);
                            }

                            oReplaceClaimStock.WarehouseID = oReplaceClaimTran.FromWHID;
                            //oReplaceClaimStock.UpdateCurrentStock(false);

                            if (oReplaceClaimStock.Flag == false)
                            {
                                DBController.Instance.RollbackTransaction();
                                MessageBox.Show("Stock can not be negative", "Error!!!");
                            }
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();                    
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public ReplaceClaimTran GetUIProductTransactionData(ReplaceClaimTran oReplaceClaimTran)
        {
            oReplaceClaimTran.TranNo = txtTransationNo.Text;
            oReplaceClaimTran.TranDate = dtTransactionDate.Value;
            oReplaceClaimTran.UserID = Utility.UserId;
            
            if (rdbPLS.Checked)
            {
                oReplaceClaimTran.TranTypeID = (int)Dictionary.ReplaceClaimStockTranType.GOODS_RECEIVE;
                oReplaceClaimTran.FromWHID = (int)Dictionary.ReplaceWareHouse.ProductionWH;
                oReplaceClaimTran.ToWHID = (int)Dictionary.ReplaceWareHouse.ReplaceCentralWH;

            }
            else
            {

                oReplaceClaimTran.TranTypeID = (int)Dictionary.ReplaceClaimStockTranType.REENGINNER_GOODS_RECEIVE;
                oReplaceClaimTran.ToWHID = (int)Dictionary.ReplaceWareHouse.ReplaceCentralWH;
                oReplaceClaimTran.FromWHID = (int)Dictionary.ReplaceWareHouse.ReengineeredWH;

               
            }
            oReplaceClaimTran.RefClaimID = 0;
            oReplaceClaimTran.RefInvoiceID = 0;
            oReplaceClaimTran.BatchNo = txtBatchNo.Text;           
            oReplaceClaimTran.Remarks = txtRemarks.Text;

            // Product Detail

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    ReplaceClaimTranItem oItem = new ReplaceClaimTranItem();

                    try
                    {
                        oItem.Quantity = Convert.ToInt16(oItemRow.Cells[3].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Quantity = 0;
                    }
                    oItem.ProductID = Convert.ToInt16(oItemRow.Cells[6].Value.ToString().Trim());

                    oReplaceClaimTran.Add(oItem);
                }
            }

            return oReplaceClaimTran;
        }     


    }
}