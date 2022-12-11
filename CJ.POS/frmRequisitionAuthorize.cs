using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.POS.TELWEBSERVER;
using CJ.Class;


namespace CJ.POS
{
    public partial class frmRequisitionAuthorize : Form
    {
        Service oSerivce;
        DSWarehouse oDSFromWarehouse;
        DSWarehouse oDSToWarehouse;      
        DSStock oDSStock;
        DSRequisition oDSRequisition;
        DSRequisition oDSRequisitionItem;

        public frmRequisitionAuthorize()
        {
            InitializeComponent();
        }
        public void Loadcmb()
        {
            cmbFromWarehouse.Items.Clear();
            oDSFromWarehouse = new DSWarehouse();
            oSerivce = new Service();
            DSWarehouse.WarehouseRow oWarehouseRow = oDSFromWarehouse.Warehouse.NewWarehouseRow();
            //oWarehouseRow.UserID = Utility.UserId.ToString();
            oDSFromWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
            oDSFromWarehouse.AcceptChanges();

            oDSFromWarehouse = oSerivce.FromWarehouse(oDSFromWarehouse);

            if (oDSFromWarehouse != null)
            {
                cmbFromWarehouse.ValueMember = "WarehouseID";
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.DataSource = oDSFromWarehouse.Warehouse;

            }
        }
        public void ShowDialog(DSRequisition oDSRequisition)
        {
            int nRequisitionID = 0;
            cmbFromWarehouse.Enabled = false;
            cmbToWarehouse.Enabled = false;
            try
            {
                Loadcmb();
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtRequisitionDate.Value = Convert.ToDateTime(oDSRequisition.Requisition[0].RequisitionDate);
            cmbFromWarehouse.SelectedValue = int.Parse(oDSRequisition.Requisition[0].FromWHID);
            cmbToWarehouse.SelectedValue = int.Parse(oDSRequisition.Requisition[0].ToWHID);
            txtRemarks.Text = oDSRequisition.Requisition[0].Remarks;

            nRequisitionID = int.Parse(oDSRequisition.Requisition[0].RequisitionID);

            this.Tag = oDSRequisition;

            oDSRequisitionItem = new DSRequisition();
            oSerivce = new Service();
            try
            {
                oDSRequisitionItem = oSerivce.RequisitionRefreshItem(oDSRequisitionItem, nRequisitionID);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisitionItem.RequisitionItem)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                oRow.Cells[0].Value = oRequisitionItemRow.ProductCode;
                oRow.Cells[1].Value = oRequisitionItemRow.ProductName;               

                oRow.Cells[5].Value = oRequisitionItemRow.RequisitingQty;
                oRow.Cells[6].Value = oRequisitionItemRow.RequisitingQty * Convert.ToDouble(oRequisitionItemRow.RSP);
                oSerivce = new Service();
                oRow.Cells[7].Value = oSerivce.GetYTDSalesQty(int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID));
                oRow.Cells[8].Value = oRequisitionItemRow.ProductID;

                oDSStock = new DSStock();
                try
                {
                    oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID),true);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                if (oDSStock.Stock.Count > 0)
                {
                    oRow.Cells[3].Value = oDSStock.Stock[0].CurrentStock;
                    oRow.Cells[4].Value = oDSStock.Stock[0].TransitStock;
                }
                else
                {
                    oRow.Cells[3].Value = 0;
                    oRow.Cells[4].Value = 0;
                }

                oDSStock = new DSStock();
                try
                {
                    oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID),true);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (oDSStock.Stock.Count > 0)
                {
                    oRow.Cells[2].Value = oDSStock.Stock[0].CurrentStock;
                }
                else oRow.Cells[2].Value = 0;



                oRow.Cells[0].ReadOnly = true;
                dgvLineItem.Rows.Add(oRow);
            }

            this.ShowDialog();
        }
        private void cmbFromWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

            oDSToWarehouse = new DSWarehouse();
            oSerivce = new Service();
            try
            {
                oDSToWarehouse = oSerivce.ToWarehouse(oDSToWarehouse, cmbFromWarehouse.SelectedValue.ToString());
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (oDSToWarehouse != null)
            {
                cmbToWarehouse.ValueMember = "WarehouseID";
                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.DataSource = oDSToWarehouse.Warehouse;

            }
        }

        //private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int nRowIndex = 0;
        //    oSerivce = new Service();
        //    if (e.ColumnIndex == 1)
        //    {
        //        if (cmbFromWarehouse.SelectedValue == null)
        //        {
        //            MessageBox.Show("Please select from warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (cmbToWarehouse.SelectedValue == null)
        //        {
        //            MessageBox.Show("Please select requiest warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        cmbFromWarehouse.Enabled = false;
        //        cmbToWarehouse.Enabled = false;

        //        frmProductSearch oForm = new frmProductSearch();
        //        oForm.ShowDialog();
        //        if (oForm.oDSSelectedProduct != null)
        //        {
        //            DataGridViewRow oRow = new DataGridViewRow();
        //            oRow.CreateCells(dgvLineItem);
        //            oRow.Cells[0].Value = oForm.oDSSelectedProduct.Product[0].ProductCode;
        //            oRow.Cells[2].Value = oForm.oDSSelectedProduct.Product[0].ProductName;
        //            oRow.Cells[6].Value = oForm.oDSSelectedProduct.Product[0].ProductID;

        //            oDSStock = new DSStock();
        //            try
        //            {
        //                oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oRow.Cells[6].Value.ToString()));
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            if (oDSStock.Stock.Count > 0)
        //            {
        //                oRow.Cells[3].Value = oDSStock.Stock[0].CurrentStock;
        //            }
        //            else oRow.Cells[3].Value = 0;

        //            oDSStock = new DSStock();
        //            try
        //            {
        //                oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oRow.Cells[6].Value.ToString()));
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            if (oDSStock.Stock.Count > 0)
        //            {
        //                oRow.Cells[4].Value = oDSStock.Stock[0].CurrentStock;
        //            }
        //            else oRow.Cells[4].Value = 0;
        //            oRow.Cells[0].ReadOnly = true;
        //            nRowIndex = dgvLineItem.Rows.Add(oRow);

        //            if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
        //            {
        //                MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dgvLineItem.Rows.RemoveAt(nRowIndex);
        //                return;
        //            }
        //            else
        //            {
        //                dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
        //                return;
        //            }

        //        }

        //    }

        //}

        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            if (e.ColumnIndex == 9)
            {
                foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisitionItem.RequisitionItem)
                {
                    if (dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString() == oRequisitionItemRow.ProductCode)
                    {
                        try
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[10].Value = Convert.ToString(Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString()) * Convert.ToDouble(oRequisitionItemRow.RSP));
                        }
                        catch
                        {
                            MessageBox.Show("Please Cheak Authorize Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows[e.RowIndex].Cells[10].Value = 0;

                        }
                    }
                }
            }
        }
        //private void refreshRow(int nRowIndex, int nColumnIndex)
        //{
        //    string sProductCode = "";
        //    oSerivce = new Service();

        //    if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
        //    {
        //        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
        //        {
        //            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            dgvLineItem.Rows.RemoveAt(nRowIndex);
        //            return;
        //        }
        //        try
        //        {
        //            sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

        //            oDSProduct = new DSProduct();
        //            try
        //            {
        //                oDSProduct = oSerivce.GetProductDetail(oDSProduct, sProductCode);
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            if (oDSProduct.Product[0].Flag == "1")
        //            {
        //                dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oDSProduct.Product[0].ProductName;
        //                dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = oDSProduct.Product[0].ProductID;

        //                oDSStock = new DSStock();
        //                try
        //                {
        //                    oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oDSProduct.Product[0].ProductID.ToString()));
        //                }
        //                catch
        //                {
        //                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }
        //                if (oDSStock.Stock.Count > 0)
        //                {
        //                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = oDSStock.Stock[0].CurrentStock;
        //                }
        //                else dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;

        //                oDSStock = new DSStock();
        //                try
        //                {
        //                    oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oDSProduct.Product[0].ProductID.ToString()));
        //                }
        //                catch
        //                {
        //                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;

        //                }

        //                if (oDSStock.Stock.Count > 0)
        //                {
        //                    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = oDSStock.Stock[0].CurrentStock;
        //                }
        //                else dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = 0;
        //                dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

        //            }
        //            else
        //            {
        //                MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dgvLineItem.Rows.RemoveAt(nRowIndex);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //    }

        //}
        //private int checkDuplicateLineItem(string ItemCode)
        //{
        //    int ItemCounter = 0;
        //    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
        //    {
        //        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //        {
        //            if (oItemRow.Cells[0].Value == null)
        //            {
        //                continue;
        //            }
        //            if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
        //            {
        //                ItemCounter++;
        //            }
        //        }
        //    }
        //    return ItemCounter;
        //}

        private bool validateUIInput()
        {
            #region Master Information Validation

            if (cmbFromWarehouse.SelectedValue == null)
            {
                return false;
            }
            if (cmbToWarehouse.SelectedValue == null)
            {
                return false;
            }

            #endregion

            #region Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[6].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[7].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[7].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    try
                    {
                        double temp = Convert.ToDouble(oItemRow.Cells[9].Value.ToString());

                        if (Convert.ToDouble(oItemRow.Cells[2].Value) < temp)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
            #endregion
            return true;
        }
        public void Save(int nStatus)
        {
            if (this.Tag == null)
            {
               
            }
            else
            {
                oDSRequisition = (DSRequisition)this.Tag;
                oDSRequisition.Requisition[0].Status = nStatus.ToString();
                oDSRequisition.Requisition[0].Remarks = txtRemarks.Text;
                oDSRequisition.RequisitionItem.Clear();

                if ((int)Dictionary.ProductRequisitionStatus.Cancel != nStatus)
                {
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            DSRequisition.RequisitionItemRow oRequisitionItemRow = oDSRequisition.RequisitionItem.NewRequisitionItemRow();

                            oRequisitionItemRow.RequisitionID = "-1";
                            oRequisitionItemRow.ProductID = oItemRow.Cells[8].Value.ToString().Trim();
                            try
                            {
                                oRequisitionItemRow.RequisitingQty = int.Parse( oItemRow.Cells[5].Value.ToString().Trim());
                            }
                            catch
                            {
                                oRequisitionItemRow.RequisitingQty = 0;
                            }
                            oRequisitionItemRow.AuthorizeQty =int.Parse( oItemRow.Cells[9].Value.ToString().Trim());

                            oDSRequisition.RequisitionItem.AddRequisitionItemRow(oRequisitionItemRow);
                            oDSRequisition.AcceptChanges();
                        }
                    }
                }
                oSerivce = new Service();
                try
                {
                    oDSRequisition = oSerivce.RequisitionAuthorize(oDSRequisition, Utility.UserId);

                    if (oDSRequisition.Requisition[0].Result == "1")
                    {
                        if ((int)Dictionary.ProductRequisitionStatus.Authorized == nStatus)
                            MessageBox.Show("You Have Successfully Confirm This Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("You Have Successfully Cancel This Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save((int)Dictionary.ProductRequisitionStatus.Authorized);
                this.Close();
            }
            else MessageBox.Show("Please cheak input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {           
            Save((int)Dictionary.ProductRequisitionStatus.Cancel);
            this.Close();          
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}