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
    public partial class frmCACChallan : Form
    {
        StockTran _oStockTran;
        Product oProduct;
        public frmCACChallan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            if (txtRefNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Ref. No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefNo.Focus();
                return false;
            }
            if (rdoExistingCustomer.Checked == true)
            {
                if (ctlCustomer1.txtDescription.Text.Trim() == "")
                {
                    MessageBox.Show("Please Input valid customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer1.txtCode.Focus();
                    return false;
                }
            }
            else
            {
                if (txtNewCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Please Input valid customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewCustomer.Focus();
                    return false;
                }
            }
            if (txtDeliveryAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Delivery Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeliveryAddress.Focus();
                return false;
            }
            if (txtContactPerson.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Contact Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactPerson.Focus();
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Contact No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }

            #region Transaction Details Information Validation

            if (dgvCACChallanItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvCACChallanItem.Rows)
            {
                if (oItemRow.Index < dgvCACChallanItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[8].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[5].Value.ToString().Trim() == "")
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
                        _oStockTran.InsertCACChallan();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add Challan # " + _oStockTran.TranNo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            _oStockTran.TranDate = DateTime.Now.Date;
            _oStockTran.Transide = (int)Dictionary.TranSide.OUT;
            _oStockTran.TranTypeID = (int)Dictionary.CACProductStockTranType.ISSUE_CHALLAN;
            _oStockTran.Remarks = txtRemarks.Text;
            _oStockTran.RefNo = txtRefNo.Text;
            if (rdoExistingCustomer.Checked == true)
            {
                _oStockTran.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                //_oStockTran.CACCustomerName= ctlCustomer1.SelectedCustomer.CustomerName;
            }
            else
            {
                _oStockTran.CACCustomerName = txtNewCustomer.Text;

            }
            _oStockTran.ContactPerson = txtContactPerson.Text;
            _oStockTran.ContactNo = txtContactNo.Text;
            _oStockTran.DeliveryAddress = txtDeliveryAddress.Text;
            _oStockTran.Status = (int)Dictionary.CACProductStockTranStatus.Create;

            //Item Details
            foreach (DataGridViewRow oItemRow in dgvCACChallanItem.Rows)
            {
                if (oItemRow.Index < dgvCACChallanItem.Rows.Count - 1)
                {

                    StockTranItem _oStockTranItem = new StockTranItem();
                    _oStockTranItem.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oStockTranItem.StockPrice = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                    _oStockTranItem.Qty = int.Parse(oItemRow.Cells[5].Value.ToString());
                    _oStockTranItem.DeliveryDate = Convert.ToDateTime(oItemRow.Cells[6].Value.ToString());
                    try
                    {
                        _oStockTranItem.LCRemarks = (oItemRow.Cells[7].Value.ToString());
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



        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 0 && dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateOfficeItem(dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvCACChallanItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sCode = dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sCode;
                    oProduct.RefreshByCACCode();

                    if (oProduct.Flag == false)
                    {
                        MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvCACChallanItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                    dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = oProduct.CurrentStock.ToString();
                    dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = oProduct.CostPrice.ToString();
                    dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = Convert.ToDateTime(DateTime.Now.Date).ToString("dd-MMM-yyyy");
                    dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (oProduct.ProductID).ToString();
                    dgvCACChallanItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

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
            foreach (DataGridViewRow oItemRow in dgvCACChallanItem.Rows)
            {
                if (oItemRow.Index < dgvCACChallanItem.Rows.Count - 1)
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

        private void dgvCACChallanItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmCACItemSarch oForm = new frmCACItemSarch();
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvCACChallanItem);

                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[3].Value = oForm._nStockQty;
                oRow.Cells[4].Value = oForm._CostPrice;
                oRow.Cells[6].Value = Convert.ToDateTime(DateTime.Now.Date).ToString("dd-MMM-yyyy");//hh:mm tt
                oRow.Cells[8].Value = oForm.nProductId;
                

                if (oForm.sProductCode != null)
                {
                    int nRowIndex = dgvCACChallanItem.Rows.Add(oRow);

                    if (checkDuplicateOfficeItem(dgvCACChallanItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Item Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvCACChallanItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvCACChallanItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }

                }

            }
        }

        private void dgvCACChallanItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void frmCACChallan_Load(object sender, EventArgs e)
        {
            this.Text = "Add New Challan";
        }

        private void rdoNewCustomer_CheckedChanged(object sender, EventArgs e)
        {
            ctlCustomer1.Visible = false;
            txtNewCustomer.Visible = true;
        }

        private void rdoExistingCustomer_CheckedChanged(object sender, EventArgs e)
        {
            txtNewCustomer.Visible = false;
            ctlCustomer1.Visible = true;
        }
    }
}