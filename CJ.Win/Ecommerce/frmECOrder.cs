using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using System.Text.RegularExpressions;

namespace CJ.Win.Ecommerce
{
    public partial class frmECOrder : Form
    {
        ProductDetail _oProductDetail;
        Warehouses oWarehouses;
        Utilities _oPaymentMode;
        Utilities _oDeliveryMode;

        public frmECOrder()
        {
            InitializeComponent();
        }

        private void frmECOrder_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCmb();
        }
        public void LoadCmb()
        {
            oWarehouses = new Warehouses();
            oWarehouses.GetAllShowroom();
            Warehouse _oWarehouse = new Warehouse();
            _oWarehouse.WarehouseID = 0;
            _oWarehouse.WarehouseName = "Select Outlet";
            oWarehouses.Add(_oWarehouse);

            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = oWarehouses.Count - 1;

            _oPaymentMode = new Utilities();
            cmbPayMentMode.Items.Clear();
            _oPaymentMode.GetECPaymentMode();
            foreach (Utility oUtility in _oPaymentMode)
            {
                cmbPayMentMode.Items.Add(oUtility.Satus);
            }
            cmbPayMentMode.SelectedIndex = 1;

            _oDeliveryMode = new Utilities();
            cmbDeliveryMode.Items.Clear();
            _oDeliveryMode.GetECDeliveryMode();
            foreach (Utility oUtility in _oDeliveryMode)
            {
                cmbDeliveryMode.Items.Add(oUtility.Satus);
            }
            cmbDeliveryMode.SelectedIndex = 0;
        }
        public void ShowDialog(ECOrder oECOrder)
        {
            this.Tag = oECOrder;
            oECOrder.RefreshHistoryByStatus();
            oECOrder.RefreshItem();
            LoadCmb();
            txtOrderNo.Text = oECOrder.OrderNo;
            txtOrderNo.Enabled = false;
            dtOrderDate.Value = oECOrder.OrderDate;
            txtCustomerName.Text = oECOrder.CustomerName;
            txtCustomerAdress.Text = oECOrder.CustomerAddress;
            txtMailID.Text=oECOrder.CustomerMailID;
            txtMobileNo.Text=oECOrder.CustomerMobileNo;
            txtAmount.Text = oECOrder.Amount.ToString();
            cmbPayMentMode.SelectedIndex=_oPaymentMode.GetIndexByID(oECOrder.PaymentMode);
            txtPaymentDes.Text = oECOrder.PaymentDes;
            dtPaymentDate.Value = oECOrder.DesiredPaymentDate;
            cmbDeliveryMode.SelectedIndex = _oDeliveryMode.GetIndexByID(oECOrder.DeliveryMode);
            txtDeliveryAddress.Text = oECOrder.DeliveryAddress;
            cmbWarehouse.SelectedIndex=oWarehouses.GetIndex(oECOrder.DeliveryWHID );
            dtDeliveryDate.Value = oECOrder.DesiredDeliveryDate;
            txtRemarks.Text = oECOrder.Remarks;

            foreach (ECOrderDetail oECOrderDetail in oECOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvProduct);

                oRow.Cells[0].Value = oECOrderDetail.ProductCode.ToString();
                oRow.Cells[2].Value = oECOrderDetail.ProductName.ToString();
                oRow.Cells[3].Value = oECOrderDetail.Qty.ToString();
                oRow.Cells[4].Value = oECOrderDetail.ProductID.ToString();

                oRow.Cells[0].ReadOnly = true;
                dgvProduct.Rows.Add(oRow);
            }
            
            this.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvProduct);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;
                    oRow.Cells[4].Value = oForm._oProductDetail.ProductID;
                 
                    if (oForm._oProductDetail.ProductCode != null)
                    {
                        nRowIndex = dgvProduct.Rows.Add(oRow);
                        if (checkDuplicateLineItem(dgvProduct.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            oRow.Cells[2].Value = "";
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvProduct.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvProduct.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        }
                    }
                }

            }

        }
        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {

                if (checkDuplicateLineItem(dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvProduct.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvProduct.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvProduct.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = (_oProductDetail.ProductID).ToString(); 
                        dgvProduct.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvProduct.Rows.RemoveAt(nRowIndex);
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
            foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
            {
                if (oItemRow.Index < dgvProduct.Rows.Count - 1)
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
        private bool validateUIInput()
        {
            #region Order Master Information Validation
            if (txtOrderNo.Text=="")
            {
                MessageBox.Show("Please Input Order No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNo.Focus();
                return false;
            }
            if (txtCustomerName.Text=="")
            {
                MessageBox.Show("Please Input Customer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtCustomerAdress.Text=="")
            {
                MessageBox.Show("Please Input Customer Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerAdress.Focus();
                return false;
            }
            if (txtMailID.Text == "")
            {
                MessageBox.Show("Please Input Customer Email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerAdress.Focus();
                return false;
            }
            if (txtMailID.Text != "")
            {
                Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match m = emailregex.Match(txtMailID.Text);
                if (!m.Success)
                {
                    MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMailID.Focus();
                    return false;
                }
            }
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please enter a consumer cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }
            else
            {
                if (txtMobileNo.Text.Length != 11)
                {
                    MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobileNo.Focus();
                    return false;
                }
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtMobileNo.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            try
            {
                double temp = Convert.ToDouble(txtAmount.Text);
            }
            catch
            {
                MessageBox.Show("Please Input Valid Amount","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPaymentDes.Text == "")
            {
                MessageBox.Show("Please enter payment address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentDes.Focus();
                return false;
            }
            if (txtDeliveryAddress.Text == "")
            {
                MessageBox.Show("Please enter delivery address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeliveryAddress.Focus();
                return false;
            }
            if (oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID == 0 || oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID==-1)
            {
                MessageBox.Show("Please enter delivery Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return false;
            }
          
            #endregion

            #region Order Details Information Validation
            if (dgvProduct.Rows.Count == 1)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
            {
                if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                {
                    if (oItemRow.Cells[4].Value == null)
                    {
                        return false;
                    }                   
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null)
                    {
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[3].Value.ToString());
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
        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (this.Tag == null)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        ECOrder oECOrder = new ECOrder();
                        oECOrder = GetData(oECOrder);
                        if (oECOrder.CheckOrder())
                        {
                            oECOrder.Insert();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Success fully Save  Order -" + oECOrder.OrderNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Duplicate Order No,Please Input Valied Order No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        ECOrder oECOrder = (ECOrder)(this.Tag);
                        oECOrder = GetData(oECOrder);
                        oECOrder.Update();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Success fully Update  Order -" + oECOrder.OrderNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                }
            }
        }
        public ECOrder GetData(ECOrder oECOrder)
        {
            oECOrder.OrderNo = txtOrderNo.Text;
            oECOrder.OrderDate = dtOrderDate.Value.Date;
            oECOrder.OrderStatus = (int)Dictionary.ECOrderStatus.Submitted;
            oECOrder.CustomerName = txtCustomerName.Text;
            oECOrder.CustomerAddress = txtCustomerAdress.Text;
            oECOrder.CustomerMailID = txtMailID.Text;
            oECOrder.CustomerMobileNo = txtMobileNo.Text;
            oECOrder.Amount = Convert.ToDouble(txtAmount.Text);
            oECOrder.PaymentMode = _oPaymentMode[cmbPayMentMode.SelectedIndex].SatusId;
            oECOrder.PaymentDes = txtPaymentDes.Text;
            oECOrder.DesiredPaymentDate = dtPaymentDate.Value.Date;
            oECOrder.DeliveryMode = _oDeliveryMode[cmbDeliveryMode.SelectedIndex].SatusId;
            oECOrder.DeliveryAddress = txtDeliveryAddress.Text;
            oECOrder.DeliveryWHID = oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;
            oECOrder.DesiredDeliveryDate = dtDeliveryDate.Value.Date;

            oECOrder.UserID = Utility.UserId;
            oECOrder.Date = DateTime.Now;
            oECOrder.Remarks = txtRemarks.Text;
            oECOrder.Clear();
            foreach (DataGridViewRow oItemRow in dgvProduct.Rows)
            {
                if (oItemRow.Index < dgvProduct.Rows.Count - 1)
                {
                    ECOrderDetail oECOrderDetail = new ECOrderDetail();
                    oECOrderDetail.ProductID = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                    oECOrderDetail.Qty = int.Parse(oItemRow.Cells[3].Value.ToString().Trim());
                    oECOrder.Add(oECOrderDetail);
                }
            }
            return oECOrder;
        }
    }
}