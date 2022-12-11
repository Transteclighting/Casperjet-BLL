// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: February 20, 2011
// Time : 10:00 AM
// Description: Form for Generate Barcode Mamualy
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class; 

namespace CJ.Win
{
    public partial class frmBarcodeManualy : Form
    {
        public frmBarcodeManualy()
        {
            InitializeComponent();
        }      

        private void frmManualBarcode_Load(object sender, EventArgs e)
        {
           
        }       
        private void btGenaretBarcode_Click(object sender, EventArgs e)
        {
            int nCheck = 1; string sManualTranNo = "";
            ProductBarcodes oProductBarcodes = new ProductBarcodes();
            

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].ReadOnly != true || oItemRow.Cells[3].Value == null)
                    {
                        nCheck = 0;
                        break;
                    }
                    if (oItemRow.Cells[3].Value != null)
                    {
                        try
                        {
                            long lTemp = Convert.ToInt64(oItemRow.Cells[3].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            nCheck = 0;
                            break;
                        }
                       
                    }
                }
            }
            if (nCheck == 1)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                sManualTranNo = oProductBarcodes.GetTranNo();                

                if (dgvLineItem.Rows.Count > 1)
                {

                    DBController.Instance.BeginNewTransaction();
                    try
                    {
                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {

                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                ProductBarcode oProductBarcode = new ProductBarcode();
                                oProductBarcode.TranNo = sManualTranNo;
                                oProductBarcode.ProductCode = oItemRow.Cells[0].Value.ToString();
                                oProductBarcode.ProductId = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                                oProductBarcode.Qty = Convert.ToInt64(oItemRow.Cells[3].Value.ToString());
                                oProductBarcode.InvoiceNo = oItemRow.Cells[5].Value.ToString();
                                oProductBarcode.InvoiceDate = Convert.ToDateTime(oItemRow.Cells[6].Value.ToString());

                                oProductBarcode.BENo = oItemRow.Cells[7].Value.ToString();
                                oProductBarcode.BEDate = Convert.ToDateTime(oItemRow.Cells[8].Value.ToString());

                                ProductDetail oProductDetails = new ProductDetail();
                                oProductDetails.ProductID = oProductBarcode.ProductId;
                                oProductDetails.Refresh();
                                oProductBarcode.PGID = oProductDetails.PGID;

                                if (Utility.CompanyInfo == "TML")
                                {
                                    oProductBarcode.AddTML(0);
                                }
                                else
                                {
                                    oProductBarcode.Add(0);
                                }
                            }

                        }
                        DBController.Instance.CommitTran();
                        MessageBox.Show("You Have Successfully Save The Data. This Transaction No : " + sManualTranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message);
                       
                    }

                }

                else
                {
                    MessageBox.Show("Please Enter Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Please Check Your Iput.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }                      
        }           
        private void dgvLineItem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);                
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;                
                oRow.Cells[4].Value = oForm.sProductId;
                oRow.Cells[6].Value = DateTime.Now.Date;
                oRow.Cells[8].Value = DateTime.Now.Date;

                if (oForm.sProductCode != null)
                {
                    int nRowIndex = dgvLineItem.Rows.Add(oRow);
                    if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";                       
                        oRow.Cells[4].Value = "";                        
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
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();
                    if (oProduct.Flag != false)
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }
                    else
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = ((oProduct.ProductID).ToString());
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                        dgvLineItem.Rows[nRowIndex].Cells[6].Value = DateTime.Now;

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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }            

    }
}