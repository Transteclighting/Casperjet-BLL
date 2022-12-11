using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.CAC
{
    public partial class frmCACProducStockTran : Form
    {
        int _nType = 0;
        Product oProduct;
        StockTran _oStockTran;

        public frmCACProducStockTran(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private bool validateUIInput()
        {
            #region Transaction Details Information Validation
            
            if (dgvCACItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvCACItem.Rows)
            {
                if (oItemRow.Index < dgvCACItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[4].Value == null)
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[4].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oStockTran = new StockTran();
                        _oStockTran = GetUIData(_oStockTran);
                        //_oStockTran.UpdatePOS(nTranID);

                        DBController.Instance.CommitTran();
                        //MessageBox.Show("Success fully Update Stock Requisition # " + sTranNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oStockTran = new StockTran();
                        _oStockTran = GetUIData(_oStockTran);
                        _oStockTran.InsertCACTran();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add GRD # " + _oStockTran.TranNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        public StockTran GetUIData(StockTran _oStockTran)
        {

            _oStockTran.TranNo = txtTransationRef.Text;
            _oStockTran.LCNo = txtLCNo.Text;
            _oStockTran.TranDate = DateTime.Now.Date;

            _oStockTran.Transide = (int)Dictionary.TranSide.IN;
            _oStockTran.TranTypeID = (int)Dictionary.CACProductStockTranType.GOODS_RECEIVE;
            _oStockTran.Remarks = txtRemarks.Text;
            _oStockTran.Status = (int)Dictionary.CACProductStockTranStatus.Approved;
            //Item Details
            foreach (DataGridViewRow oItemRow in dgvCACItem.Rows)
            {
                if (oItemRow.Index < dgvCACItem.Rows.Count - 1)
                {

                    StockTranItem _oStockTranItem = new StockTranItem();
                    _oStockTranItem.ProductID = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oStockTranItem.StockPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    _oStockTranItem.Qty = int.Parse(oItemRow.Cells[4].Value.ToString());
                    try
                    {
                        _oStockTranItem.LCRemarks = (oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        _oStockTranItem.LCRemarks = "";
                    }
                    _oStockTran.Add(_oStockTranItem);

                }
            }

            return _oStockTran;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 0 && dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvCACItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sCode = dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sCode;
                    oProduct.RefreshByCACCode();

                    if (oProduct.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvCACItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                    dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = oProduct.CostPrice.ToString();
                    dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (oProduct.ProductID).ToString();
                    dgvCACItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


        }

        private int checkDuplicateOfficeItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvCACItem.Rows)
            {
                if (oItemRow.Index < dgvCACItem.Rows.Count - 1)
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

        private void dgvCACItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmCACItemSarch oForm = new frmCACItemSarch();
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvCACItem);

                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[3].Value = oForm._CostPrice;
                oRow.Cells[6].Value = oForm.nProductId;

                if (oForm.sProductCode != null)
                {
                    int nRowIndex = dgvCACItem.Rows.Add(oRow);

                    if (checkDuplicateOfficeItem(dgvCACItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvCACItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvCACItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }

                }

            }
        }

        private void dgvCACItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void frmCACProducStockTran_Load(object sender, EventArgs e)
        {
            this.Text = "Add GRD";
        }
    }
}