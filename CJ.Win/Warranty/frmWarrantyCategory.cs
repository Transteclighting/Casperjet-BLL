using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Warranty;
using System.Text.RegularExpressions;

namespace CJ.Win.Warranty
{
    public partial class frmWarrantyCategory : Form
    {
        WarrantyCategory oWarrantyCategory;

        public frmWarrantyCategory()
        {
            InitializeComponent();
        }

        public void ShowDialog(WarrantyCategory _oWarrantyCategory)
        {
            this.Tag = _oWarrantyCategory;

            txtName.Text = _oWarrantyCategory.Name;
            foreach (WarrantyParameter oWarrantyParameter in _oWarrantyCategory)
            {
                txtService.Text = oWarrantyParameter.ServiceValidity.ToString();
                txtSpare.Text = oWarrantyParameter.SpareValidity.ToString();
                txtSpecial.Text = oWarrantyParameter.SpecialPartValidity.ToString();
                dtFromDate.Value = oWarrantyParameter.EffectiveFrom;
            }
            foreach (WarrantyProduct oWarrantyProduct in _oWarrantyCategory.WarrantyProducts)
            {
                Product oProduct = new Product();
                DBController.Instance.OpenNewConnection();
                oProduct.ProductID = oWarrantyProduct.ProductID;
                oProduct.RefreshByID();

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oProduct.ProductName;
                oRow.Cells[2].Value = oProduct.ProductCode;
                oRow.Cells[3].Value = oProduct.ProductID.ToString();
         
                dgvLineItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }

        private void dgvLineItem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmProductSearchInCheck oForm = new frmProductSearchInCheck();
                oForm.ShowDialog();
                if (oForm._oProductDetails.Count >0)
                {
                    foreach (ProductDetail oProductDetail in oForm._oProductDetails)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oProductDetail.ProductCode;
                        oRow.Cells[2].Value = oProductDetail.ProductName;
                        oRow.Cells[3].Value = oProductDetail.ProductID;

                        int nRowIndex = dgvLineItem.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[0].Value = "";
                            oRow.Cells[2].Value = "";
                            oRow.Cells[3].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }
            }
        }
        private void dgvLineItem_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
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

                    Product oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();
                    if (oProduct.Flag != false)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = ((oProduct.ProductID).ToString());
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

        private void btSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Category Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Regex isnumber = new Regex("[0-9]");
            if (!isnumber.IsMatch(txtService.Text))
            {
                MessageBox.Show("Please enter a valid Service Validity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtService.Focus();
                return ;
            }
            if (!isnumber.IsMatch(txtSpare.Text))
            {
                MessageBox.Show("Please enter a valid Spare  Validity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtService.Focus();
                return;
            }
            if (!isnumber.IsMatch(txtSpecial.Text))
            {
                MessageBox.Show("Please enter a valid Special part Validity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtService.Focus();
                return;
            }

            if (this.Tag != null)
                oWarrantyCategory = (WarrantyCategory)this.Tag;
            else oWarrantyCategory = new WarrantyCategory();

            oWarrantyCategory.Name = txtName.Text;
            oWarrantyCategory.CreatedBy = Utility.UserId;
            oWarrantyCategory.CreatedDate = DateTime.Today.Date;
            oWarrantyCategory.DownloadStatus = 1;
            oWarrantyCategory.UploadStatus = 1;

            oWarrantyCategory.WarrantyProducts.Clear();
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count-1)
                {
                    WarrantyProduct oWarrantyProduct = new WarrantyProduct();

                    oWarrantyProduct.ProductID = Convert.ToInt16(oItemRow.Cells[3].Value.ToString().Trim());
                    oWarrantyCategory.WarrantyProducts.Add(oWarrantyProduct);
                
                }
            }
            oWarrantyCategory.Clear();
            WarrantyParameter oWarrantyParameter = new WarrantyParameter();

            oWarrantyParameter.ServiceValidity = int.Parse(txtService.Text);
            oWarrantyParameter.SpareValidity = int.Parse(txtSpare.Text);
            oWarrantyParameter.SpecialPartValidity = int.Parse(txtSpecial.Text);
            oWarrantyParameter.EffectiveFrom = dtFromDate.Value.Date;
            oWarrantyParameter.CreateDate = DateTime.Today.Date;
            oWarrantyParameter.CreatedBy = Utility.UserId;
            oWarrantyParameter.DownloadStatus = 1;
            oWarrantyParameter.UploadStatus = 1;

            oWarrantyCategory.Add(oWarrantyParameter);
            if (this.Tag != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oWarrantyCategory.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Warranty Category ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oWarrantyCategory.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Warranty Category ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}