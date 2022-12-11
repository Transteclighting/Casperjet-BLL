using System;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Dealer
{
    public partial class frmStockAdjustment : Form
    {
        DMSProductStockTran _DMSProductStockTran;
        DealerOutlets _oDOs;

        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        public frmStockAdjustment()
        {
            InitializeComponent();

            LoadCombo();
        }


        public void LoadCombo()
        {

            User oUser = new User();
            int nUserID = Utility.UserId;
            DBController.Instance.OpenNewConnection();

            _oDOs = new DealerOutlets();
            _oDOs.Refresh();
            cmbOutlet.Items.Clear();
            foreach (DealerOutlet oDO in _oDOs)
            {
                cmbOutlet.Items.Add(oDO.OutletName);

            }
            cmbOutlet.SelectedIndex = 0;
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DBController.Instance.OpenNewConnection();

            #region Get Product

            if (e.ColumnIndex == 1)
            {

                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[6].Value = oForm._CP;
                oRow.Cells[7].Value = oForm._NSP;
                oRow.Cells[8].Value = oForm.sProductId;
                dgvLineItem.Rows.Add(oRow);
                
                if (oForm.sProductCode != null)
                {
                    if (checkDuplicateLineItem(dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                }
            }
            #endregion

            #region Get Barcode

            else if (e.ColumnIndex == 5)
            {
                
                frmSetBarcodes ofrmSetBarcodes =
                new frmSetBarcodes();
            ofrmSetBarcodes.ShowDialog();


                if (ofrmSetBarcodes._Qty > 0)
                {
                    dgvLineItem.Rows[e.RowIndex].Cells[4].Value = ofrmSetBarcodes._sBarcode;
                    dgvLineItem.Rows[e.RowIndex].Cells[3].Value = ofrmSetBarcodes._Qty;

                }
            }
            #endregion

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                Close();
            }
        }

        private void Save()
        {
            if(ValidateUiInput())
            {
                _DMSProductStockTran = new DMSProductStockTran
                {
                    ToCustomerID = _oDOs[cmbOutlet.SelectedIndex].CustomerID,
                    TranDate = dtTranDate.Value,
                    Remarks = txtRemarks.Text,
                    TranNo = txtTranNo.Text
                };
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    #region Plan Detail
                    // Details
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count-1)
                        {

                            DMSProductStockTranItem oDMSProductStockTranItem = new DMSProductStockTranItem();


                            oDMSProductStockTranItem.ProductID= Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                            oDMSProductStockTranItem.Qty = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                            oDMSProductStockTranItem.CostPrice = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                            oDMSProductStockTranItem.SalesPrice = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                            
                            char[] splitchar = { ',' };
                            string sProductBarcode = oItemRow.Cells[4].Value.ToString();
                            sProductBarcodeArr = sProductBarcode.Split(splitchar);
                            nArrayLen = sProductBarcodeArr.Length;

                            for (int i = 0; i < nArrayLen; i++)
                            {
                                DMSProductStockSerial oDMSProductStockSerial = new DMSProductStockSerial
                                {
                                    ProductID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString()),
                                    ProductSerial = sProductBarcodeArr[i].Trim()
                                };

                                oDMSProductStockTranItem.Add(oDMSProductStockSerial);
                            }

                            _DMSProductStockTran.Add(oDMSProductStockTranItem);

                        }
                    }

                    _DMSProductStockTran.Insert();

                    #endregion

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }
    private bool ValidateUiInput()
        {
            //if (txtUserName.Text == string.Empty)
            //{
            //    MessageBox.Show(@"Please Enter User Name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtUserName.Focus();
            //    return false;
            //}
            
            return true;
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
                    MessageBox.Show(@"Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    Product oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();

                    if (oProduct.Flag != true)
                    {
                        
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (oProduct.CostPrice).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (oProduct.NSP).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (oProduct.ProductID).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                        
                    }
                    else
                    {
                        MessageBox.Show(@"Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Invalid Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
           


        }
    }
}
