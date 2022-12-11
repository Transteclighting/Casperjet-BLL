using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Report;
using CJ.Class.Web.UI.Class;
using System.Text.RegularExpressions;

namespace CJ.Win.Ecommerce
{
    public partial class frmEcommerceOrder : Form
    {

        ProductDetail _oProductDetail;
        CustomerDetail _oCustomerDetail;
        Warehouses _oWarehouses;
        Warehouses _oDeliveryWarehouses;
        SalesPromotions _oSalesPromotions;
        WUIUtility _oWUIUtility;

        EPSSalesOrder _oEPSSalesOrder;
        SalesOrder _oSalesOrder;
        EPSCustomer _oEPSCustomer;
        Customer _oCustomer;

        SundryCustomer _oSundryCustomer;
        EcommerceOrder _oEcommerceOrder;

        DateTime dtStartDate;
        long nRem = 0;
        long nQuotient = 0;
        int nUIControl = 0;

        int nWebStoreCustomerID = 0;
        int nChannelID = 0;
        int nWebStoreChannelID = 0;
        int nPriceOptionID = 0;
        int nCustTypeID = 0;
        int nOrderID = 0;
        int nSundryCustomerID = 0;
        string sOrderNo="";

        public frmEcommerceOrder()
        {
            InitializeComponent();
        }
        private void frmEcommerceOrder_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Ecommerce Order";
                txtDiscount.Text = "0.00";
                Loadcmb();
                GetCustomer();
            }
            //nChannelID = Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLChannel"].ToString());

            
        }
        public void Loadcmb()
        {

            _oWarehouses = new Warehouses();
            _oWarehouses.GetWebStore();

            if (_oWarehouses.Count > 0)
            {
                foreach (Warehouse oWarehouse in _oWarehouses)
                {
                    cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
                }
                cmbWarehouse.SelectedIndex = 0;

            }
            else _oWarehouses = null;

        }
        public void GetCustomer()
        {
            _oCustomer = new Customer();
            _oCustomer.GetWebStoreCustomer(Utility.WebStoreCustomer);
            nWebStoreCustomerID = _oCustomer.CustomerID;
            nChannelID = _oCustomer.ChannelID;
            nPriceOptionID = _oCustomer.PriceOptionID;
            nCustTypeID = _oCustomer.CustTypeID;
        }
        public void ShowDialog(SalesOrder _oSalesOrder)
        {
            Loadcmb();
            sOrderNo = _oSalesOrder.OrderNo.ToString();
            nOrderID = _oSalesOrder.OrderID;
            nChannelID = _oSalesOrder.ChannelID;
            nSundryCustomerID = _oSalesOrder.SundryCustomerID;
            dtOrderDate.Value = Convert.ToDateTime(_oSalesOrder.OrderDate.ToString());
            txtWebInvNo.Text = Convert.ToInt32(_oSalesOrder.WebInvoiceNo).ToString();
            nWebStoreCustomerID=_oSalesOrder.CustomerID;
            txtCustomerName.Text = _oSalesOrder.SundryCustomerName;
            txtMobileNo.Text = _oSalesOrder.CellNo;
            txtPhoneNo.Text = _oSalesOrder.PhoneNo;
            txtEmail.Text = _oSalesOrder.Email;
            txtDeliveryAddress.Text=_oSalesOrder.DeliveryAddress;

            //_oSalesOrder.WarehouseID = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;

            txtRemarks.Text=_oSalesOrder.Remarks;

            txtDiscount.Text = Convert.ToDouble(_oSalesOrder.Discount).ToString();


            foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesOrderItem.Product.ProductCode.ToString();
                oRow.Cells[2].Value = oSalesOrderItem.Product.ProductName.ToString();
                oRow.Cells[3].Value = oSalesOrderItem.UnitPrice.ToString();
                oRow.Cells[4].Value = oSalesOrderItem.Quantity.ToString();

                _oWUIUtility = new WUIUtility();
                _oWUIUtility.GetCurrentStock(_oSalesOrder.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oSalesOrderItem.ProductID);
                oRow.Cells[6].Value = _oWUIUtility.CurrentStock.ToString();
                oRow.Cells[5].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.Quantity).ToString();

                oRow.Cells[7].Value = oSalesOrderItem.ProductID.ToString();
                oRow.Cells[0].ReadOnly = true;
                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();

            this.Tag = _oSalesOrder;
            this.ShowDialog();
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

                    //if (nPriceOptionID == (short)Dictionary.PriceOption.NSP)
                    //{
                    //    oRow.Cells[3].Value = oForm._oProductDetail.NSP.ToString();
                    //}
                    //else if (nPriceOptionID == (short)Dictionary.PriceOption.MRP)
                    //{
                        oRow.Cells[3].Value = oForm._oProductDetail.MRP.ToString();
                    //}
                    //else
                    //{
                    //    oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                    //}

                    oRow.Cells[7].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(nChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);
                    if (_oWUIUtility.CurrentStock != 0)
                        oRow.Cells[6].Value = _oWUIUtility.CurrentStock.ToString();
                    else
                    {
                        MessageBox.Show("Product Stock not avialable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nRowIndex = dgvLineItem.Rows.Add(oRow);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

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
                    DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.Flag != false)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oProductDetail.ProductID).ToString();

                        //if (nPriceOptionID == (short)Dictionary.PriceOption.NSP)
                        //{
                        //    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.NSP.ToString();
                        //}
                        //else if (nPriceOptionID == (short)Dictionary.PriceOption.MRP)
                        //{
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.MRP.ToString();
                        //}
                        //else
                        //{
                        //    dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                        //}

                        _oWUIUtility = new WUIUtility();
                        _oWUIUtility.GetCurrentStock(nChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        if (_oWUIUtility.CurrentStock != 0)
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = _oWUIUtility.CurrentStock.ToString();
                        else
                        {
                            MessageBox.Show("Product Stock not avialable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                        }
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
            else if (nColumnIndex == 4)
            {

                if (dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString() != "" && dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvLineItem.Rows[nRowIndex].Cells[7].Value.ToString() != "")
                {
                    try
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[5].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString()));
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Product Quantity or Unit Price Should be Greater than Zero");

                    }
                }
                if (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString()) > Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[6].Value.ToString()))
                {
                    MessageBox.Show("Please Input Valid Product Quantity,Product Quantity must less or equal in Current Stock");
                    dgvLineItem.Rows[nRowIndex].Cells[4].Value = 0;
                }
                GetTotalAmount();
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
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private bool validateUIInput()
        {
            #region Order Master Information Validation

            if (txtWebInvNo.Text == "")
            {
                MessageBox.Show("Please enter Web Invoice No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWebInvNo.Focus();
                return false;
            }
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtDeliveryAddress.Text == "")
            {
                MessageBox.Show("Please enter Customer Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeliveryAddress.Focus();
                return false;
            }
            Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match m = emailregex.Match(txtEmail.Text);
            if (txtEmail.Text != "")
            {
                if (!m.Success)
                {
                    MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            if (_oWarehouses == null)
            {
                MessageBox.Show("Please Select a Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return false;
            }



            #endregion

            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[2].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[4].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[4].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[5].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[5].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[6].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[7].Value == null)
                    {
                        return false;
                    }

                }
            }

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {

                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    int ProductID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                    long sum = 0;

                    foreach (DataGridViewRow oRow in dgvLineItem.Rows)
                    {
                        if (oRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            if (Convert.ToInt32(oRow.Cells[7].Value.ToString().Trim()) == ProductID)
                            {
                                sum = sum + Convert.ToInt64(oItemRow.Cells[4].Value.ToString());
                            }
                        }
                    }
                    ProductStock oProductStock = new ProductStock();
                    //if (this.Tag == null)
                    //{
                        oProductStock.ChannelID = nChannelID;
                    //}
                    //else
                    //{
                    //    oProductStock.ChannelID = _oSalesOrder.ChannelID;
                    //}
                    oProductStock.WarehouseID = Utility.WebStore;
                    oProductStock.ProductID = ProductID;


                    oProductStock.Refresh(oProductStock.ProductID, oProductStock.ChannelID, oProductStock.WarehouseID);


                    if (sum > oProductStock.CurrentStock)
                    {
                        MessageBox.Show("Quantity must be less or equal Current Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                }
            }


            #endregion
            return true;
        }

        public void Save()
        {
            if (this.Tag == null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesOrder = new SalesOrder();
                    _oSundryCustomer = new SundryCustomer();
                    GetUIData(_oSalesOrder, _oSundryCustomer);
                    _oSalesOrder.Insert(false);

                    _oSundryCustomer.Add();

                    _oEcommerceOrder = new EcommerceOrder();
                    _oEcommerceOrder.OrderID = _oSalesOrder.OrderID;
                    _oEcommerceOrder.SundryCustID = _oSundryCustomer.SundryCustomerID;
                    _oEcommerceOrder.WebInvoiceNo = Convert.ToInt32(txtWebInvNo.Text);
                    _oEcommerceOrder.Add();


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Add Successfully with Order No- " + _oSalesOrder.OrderNo.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("You Have Unsccessfull Save The Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else 
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesOrder = new SalesOrder();
                    _oSundryCustomer = new SundryCustomer();
                    GetUIData(_oSalesOrder, _oSundryCustomer);
                    _oSalesOrder.OrderID = nOrderID;
                    _oSalesOrder.Update();

                    _oSundryCustomer.SundryCustomerID = nSundryCustomerID;
                    _oSundryCustomer.Edit();

                    _oEcommerceOrder = new EcommerceOrder();
                    _oEcommerceOrder.OrderID = _oSalesOrder.OrderID;
                    _oEcommerceOrder.SundryCustID = nSundryCustomerID;
                    _oEcommerceOrder.WebInvoiceNo = Convert.ToInt32(txtWebInvNo.Text);
                    _oEcommerceOrder.Edit();


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Update Successfully with Order No- " + sOrderNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("You Have Unsccessfull Save The Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }
        }


        public void GetUIData(SalesOrder _oSalesOrder, SundryCustomer _oSundryCustomer)
        {
            ///
            // For Sales Order Class
            ///         
            _oSalesOrder.OrderDate = dtOrderDate.Value.Date;
            _oSalesOrder.ConfirmDate = _oSalesOrder.OrderDate;
            _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CASH;
            _oSalesOrder.CustomerID = nWebStoreCustomerID;
            _oSalesOrder.DeliveryAddress = txtDeliveryAddress.Text;
            _oSalesOrder.SalesPersonID = -1;
            _oSalesOrder.WarehouseID = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;
            _oSalesOrder.DDDate = null;
            _oSalesOrder.DDDetails = "";
            _oSalesOrder.DDAmount = 0.0;
            _oSalesOrder.Remarks = txtRemarks.Text;
            try
            {
                _oSalesOrder.Discount = Convert.ToDouble(txtDiscount.Text);
            }
            catch
            {
                _oSalesOrder.Discount = 0;
            }

            _oSalesOrder.CreateUserID = Utility.UserId;

            // Product Details

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    SalesOrderItem _oSalesOrderItem = new SalesOrderItem();
                    ProvisionParam _oProvisionParam = new ProvisionParam();

                    _oSalesOrderItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString().Trim());
                    _oSalesOrderItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    _oSalesOrderItem.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());

                    _oProvisionParam.GetProvisionParam(_oSalesOrderItem.ProductID, nCustTypeID);
                    _oSalesOrderItem.ConfirmQuantity = _oSalesOrderItem.Quantity;
                    _oSalesOrderItem.AdjustedDPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesOrderItem.AdjustedPWAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesOrderItem.AdjustedTPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.TP;
                    _oSalesOrderItem.PromotionalDiscount = 0;
                    _oSalesOrderItem.IsFreeProduct = 0;
                    _oSalesOrderItem.FreeQty = 0;

                    _oSalesOrder.Add(_oSalesOrderItem);
                }
            }
            
            ///
            // For Sundry Customer class
            ///          

            _oSundryCustomer.SundryCustomerName = txtCustomerName.Text;
            _oSundryCustomer.Address = txtDeliveryAddress.Text;
            _oSundryCustomer.CellNo = txtMobileNo.Text;
            _oSundryCustomer.PhoneNo = txtPhoneNo.Text;
            _oSundryCustomer.Email = txtEmail.Text;
            _oSundryCustomer.SundryCustomerType = (int)Dictionary.SundryCustomerType.WebStoreCustomer;
            _oSundryCustomer.CustomerID = nWebStoreCustomerID;

        }
        public bool IsOrderProduct(SalesOrder _oSalesOrder, int nProductID)
        {
            foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
            {
                if (oSalesOrderItem.ProductID == nProductID)
                    return true;
            }
            return false;
        }
        private void GetTotalAmount()
        {
            txtTotal.Text = "0.00";
            double Discount = 0;
            double Downpayment = 0;

            try
            {
                Discount = Convert.ToDouble(txtDiscount.Text);
            }
            catch
            {
                Discount = 0;
            }
            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[5].Value != null)
                {
                    txtTotal.Text = Convert.ToDouble(Convert.ToDouble(txtTotal.Text) + Convert.ToDouble(oRow.Cells[5].Value.ToString())).ToString();

                }
            }
            txtPV.Text = Convert.ToDouble(Convert.ToDouble(txtTotal.Text) - Downpayment - Discount).ToString();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
        }

    }

}