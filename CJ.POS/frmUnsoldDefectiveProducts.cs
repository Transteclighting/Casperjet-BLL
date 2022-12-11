using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmUnsoldDefectiveProducts : Form
    {
        UnsoldDefectiveProduct _oUnsoldDefectiveProduct;
        UnsoldDefectiveProducts _oUnsoldDefectiveProducts;
        bool IsCheck = false;

        public frmUnsoldDefectiveProducts()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUnsoldDefectiveProduct oFrom = new frmUnsoldDefectiveProduct();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        private void SetListViewRowColour()
        {
            if (lvwUnsouldDefectiveProducts.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwUnsouldDefectiveProducts.Items)
                {
                    if (oItem.SubItems[8].Text == "Create")
                    {
                        oItem.BackColor = Color.MistyRose;
                    }
                    else if (oItem.SubItems[8].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.White;

                    }
                    else if (oItem.SubItems[8].Text == "Assessed")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[8].Text == "Discount_Approved")
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                    else if (oItem.SubItems[8].Text == "Reject")
                    {
                        oItem.BackColor = Color.Silver;

                    }
                    else
                    {
                        oItem.BackColor = Color.LightCyan;
                    }

                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }
        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsouldDefectiveProductStatus)))
            {
                cmbstatus.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), GetEnum));
            }
            cmbstatus.SelectedIndex = 0;

            cmbStockStatus.Items.Clear();
            cmbStockStatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductSerialStatus)))
            {
                cmbStockStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProductSerialStatus), GetEnum));
            }
            cmbStockStatus.SelectedIndex = 0;


            cmbDefectiveType.Items.Clear();
            cmbDefectiveType.Items.Add("<All>");
            //POSUnsoldDefectiveProductType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
            cmbDefectiveType.SelectedIndex = 0;

        }
        private void DataLoadControl()
        {
            _oUnsoldDefectiveProducts = new UnsoldDefectiveProducts();
            lvwUnsouldDefectiveProducts.Items.Clear();
            int nStatus = 0;
            if (cmbstatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else             
            {
                nStatus = cmbstatus.SelectedIndex - 1;
            }

            int nStockStatus = 0;
            if (cmbStockStatus.SelectedIndex == 0)
            {
                nStockStatus = -1;
            }
            else
            {
                nStockStatus = cmbStockStatus.SelectedIndex - 1;
            }
            DBController.Instance.OpenNewConnection();
            _oUnsoldDefectiveProducts.RefreshForPOSNew(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, txtBarcode.Text.Trim(), IsCheck, txtDefectiveNo.Text.Trim(), txtProductCode.Text.Trim(), txtProductName.Text.Trim(), nStockStatus, cmbDefectiveType.SelectedIndex);
            DBController.Instance.CloseConnection();
            TELLib oTELLib = new TELLib();
            foreach (UnsoldDefectiveProduct oUnsoldDefectiveProduct in _oUnsoldDefectiveProducts)
            {
                ListViewItem oItem = lvwUnsouldDefectiveProducts.Items.Add(oUnsoldDefectiveProduct.DefectiveNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), oUnsoldDefectiveProduct.DefectiveType));
                oItem.SubItems.Add(oUnsoldDefectiveProduct.ShowroomCode.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.ProductCode.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.ProductName.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.BarcodeSL.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.Fault.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oUnsoldDefectiveProduct.CreateDate).ToString("dd-MMM-yyyy"));
                // oItem.SubItems.Add(oUnsoldDefectiveProduct.StatusName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status));
                oItem.SubItems.Add(oUnsoldDefectiveProduct.JobNo.ToString());
                oItem.SubItems.Add(oTELLib.TakaFormat(Convert.ToDouble(oUnsoldDefectiveProduct.ApproveDicAmount)));
                oItem.SubItems.Add(oUnsoldDefectiveProduct.RefInvoiceNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductSerialStatus), oUnsoldDefectiveProduct.StockStatus));

                oItem.Tag = oUnsoldDefectiveProduct;
            }
            SetListViewRowColour();
            this.Text = "Unsold Defective Product List[" + _oUnsoldDefectiveProducts .Count+ "] ";
        }
        private void frmUnsoldDefectiveProducts_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            if (oUnsoldDefectiveProduct.Status == (int)Dictionary.UnsouldDefectiveProductStatus.Create)
            {
                frmUnsoldDefectiveProduct oForm = new frmUnsoldDefectiveProduct();
                oForm.ShowDialog(oUnsoldDefectiveProduct);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            frmUnsoldDefectiveProductList oForm = new frmUnsoldDefectiveProductList();
            oForm.ShowDialog();
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Please Select Data to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;

        //    if (oUnsoldDefectiveProduct.Status == (int)Dictionary.UnsouldDefectiveProductStatus.Create)
        //    {
        //        DialogResult oResult = MessageBox.Show("Are you sure you want to delete DefectiveProduct No: " + oUnsoldDefectiveProduct.DefectiveNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (oResult == DialogResult.Yes)
        //        {
        //            try
        //            {

        //                DBController.Instance.BeginNewTransaction();
        //                //Delete Tran/Tran Item
        //                oUnsoldDefectiveProduct.Delete();

        //                DBController.Instance.CommitTransaction();
        //                MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                DataLoadControl();
        //            }
        //            catch (Exception ex)
        //            {
        //                DBController.Instance.RollbackTransaction();
        //                MessageBox.Show(ex.Message, "Error!!!");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("You cannot delete Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        return;
        //    }
        //}

    }
}