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

namespace CJ.Win.EPS
{
    public partial class frmEPSOrder : Form
    {
        ProductDetail _oProductDetail;
        CustomerDetail _oCustomerDetail;
        Warehouses _oWarehouses;
        Warehouses _oDeliveryWarehouses;
        SalesPromotions _oSalesPromotions;
        WUIUtility _oWUIUtility;

        EMICalculationDetail _oEMICalculationDetail;
        EPSSalesOrder _oEPSSalesOrder;
        SalesOrder _oSalesOrder;
        EPSCustomer _oEPSCustomer;
        Customer _oCustomer;

        DateTime dtStartDate;
        long nRem = 0;
        long nQuotient = 0;
        int nUIControl = 0;

        public frmEPSOrder(int _nUIControl)
        {
            InitializeComponent();
            nUIControl = _nUIControl;
        }
        private void frmEPSOrder_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add EPS Order";
                txtDiscount.Text = "0.00";
                txtDownPayment.Text = "0.00";
                Loadcmb();

                ctlEPSCustomer1.Enabled = false;
                txtCustomerCode.Enabled = true;
                txtDesignation.Enabled = true;
                txtEmAddress.Enabled = true;
                txtCustomerName.Enabled = true;
                txtPhoneNo.Enabled = true;
                txtEmail.Enabled = true;
            }
            else
            {
                if (nUIControl == 2)
                {
                    this.Text = "Update EPS Order";
                    btSave.Text = "&Save";

                    ctlEPSCustomer1.Enabled = true;
                    txtCustomerCode.Enabled = false;
                    txtDesignation.Enabled = false;
                    txtEmAddress.Enabled = false;
                    txtCustomerName.Enabled = false;
                    txtPhoneNo.Enabled = false;
                    txtEmail.Enabled = false;
                    rdbNew.Enabled = false;
                }
                else
                {
                    ctlEPSCustomer1.Enabled = true;
                    txtCustomerCode.Enabled = false;
                    txtDesignation.Enabled = false;
                    txtEmAddress.Enabled = false;
                    txtCustomerName.Enabled = false;
                    txtPhoneNo.Enabled = false;
                    txtEmail.Enabled = false;
                    rdbNew.Enabled = false;

                    this.Text = "Cofirm Order";
                    btSave.Text = "&Cofirm";
                }
            }
        }
        public void Loadcmb()
        {
            cmbWarehouse.Items.Clear();
            cmbDeliveryWarehouse.Items.Clear();

            _oDeliveryWarehouses = new Warehouses();
            _oDeliveryWarehouses.GetAllWarehouse();

            if (_oDeliveryWarehouses.Count > 0)
            {
                foreach (Warehouse oWarehouse in _oDeliveryWarehouses)
                {
                    cmbDeliveryWarehouse.Items.Add(oWarehouse.WarehouseName);
                }
                cmbDeliveryWarehouse.SelectedIndex = _oDeliveryWarehouses.Count - 1;

            }
            _oWarehouses = new Warehouses();
            _oWarehouses.GetEPSWarehouse();

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
        public void ShowDialog(EPSSalesOrder _oEPSSalesOrder)
        {
            Loadcmb();
            txtOrderNo.Text = _oEPSSalesOrder.SalesOrder.OrderNo.ToString();
            dtOrderDate.Value = Convert.ToDateTime(_oEPSSalesOrder.SalesOrder.OrderDate.ToString());
            ctlCustomer1.txtCode.Text = _oEPSSalesOrder.SalesOrder.Customer.CustomerCode;
            ctlEPSCustomer1.txtCode.Text = _oEPSSalesOrder.EPSCustomer.EPSCustomerCode;
            txtAddress.Text = _oEPSSalesOrder.SalesOrder.DeliveryAddress;
            cmbWarehouse.SelectedIndex = _oWarehouses.GetIndex(_oEPSSalesOrder.SalesOrder.WarehouseID);
            if (_oEPSSalesOrder.SalesOrder.SalesPromotionID != -1)
                cmbSalesPromotion.SelectedIndex = _oSalesPromotions.GetIndex(_oEPSSalesOrder.SalesOrder.SalesPromotionID);

            txtCustomerCode.Text = _oEPSSalesOrder.EPSCustomer.EmployeeCode;
            txtCustomerName.Text = _oEPSSalesOrder.EPSCustomer.EmployeeName;
            txtEmAddress.Text = _oEPSSalesOrder.EPSCustomer.EmployeeAddress;
            txtDesignation.Text = _oEPSSalesOrder.EPSCustomer.Designation;
            txtInstallmnetNo.Text=_oEPSSalesOrder.NoOfInstallment.ToString();
            txtInterestRate.Text = _oEPSSalesOrder.InterestRate.ToString();
            txtDownPayment.Text = _oEPSSalesOrder.DownPayment.ToString();
            txtDiscount.Text = _oEPSSalesOrder.SalesOrder.Discount.ToString();
            txtEmail.Text = _oEPSSalesOrder.EPSCustomer.Email;
            txtPhoneNo.Text = _oEPSSalesOrder.EPSCustomer.PhoneNo;
            //label17.Visible = true;
            //txtEPSCode.Visible = true;
            //txtEPSCode.Enabled = false;
            //txtEPSCode.Text = _oEPSSalesOrder.EPSCustomer.EPSCustomerCode;

            cmbDeliveryWarehouse.SelectedIndex = _oDeliveryWarehouses.GetIndex(_oEPSSalesOrder.DeliveryWHID);
            txtRemarks.Text = _oEPSSalesOrder.SalesOrder.Remarks;


            foreach (SalesOrderItem oSalesOrderItem in _oEPSSalesOrder.SalesOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesOrderItem.Product.ProductCode.ToString();
                oRow.Cells[2].Value = oSalesOrderItem.Product.ProductName.ToString();             
                oRow.Cells[3].Value = oSalesOrderItem.UnitPrice.ToString();
                oRow.Cells[4].Value = oSalesOrderItem.Quantity.ToString();

                _oWUIUtility = new WUIUtility();
                _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oSalesOrderItem.ProductID);
                oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();
                nQuotient = Math.DivRem((int)oSalesOrderItem.Quantity, (int)_oWUIUtility.UOMConversionFactor, out nRem);
                oRow.Cells[6].Value = nQuotient;
                oRow.Cells[5].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.Quantity).ToString();

                oRow.Cells[8].Value = oSalesOrderItem.ProductID.ToString();
                oRow.Cells[0].ReadOnly = true;
                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();
            rdbOld.Checked = true;
            this.Tag = _oEPSSalesOrder;
            this.ShowDialog();
        }
        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.SelectedCustomer != null)
            {
                _oCustomerDetail = new CustomerDetail();
                _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oCustomerDetail.refresh();
                ShowCustomerDetail(_oCustomerDetail);             
            }

        }
        public void ShowCustomerDetail(CustomerDetail _oCustomerDetail)
        {
            txtAddress.Text = _oCustomerDetail.CustomerAddress;           
            cmbSalesPromotion.Items.Clear();
         
            _oSalesPromotions = new SalesPromotions();
            _oSalesPromotions.RefreshForSalesOrder(_oCustomerDetail.CustomerID);

            if (_oSalesPromotions.Count > 0)
            {
                foreach (SalesPromotion oSalesPromotion in _oSalesPromotions)
                {
                    cmbSalesPromotion.Items.Add(oSalesPromotion.SalesPromotionName);
                }
                cmbSalesPromotion.SelectedIndex = 0;
            }
            else _oSalesPromotions = null;

        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                if (ctlCustomer1.SelectedCustomer == null)
                {
                    MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oForm._oProductDetail.ProductCode;
                    oRow.Cells[2].Value = oForm._oProductDetail.ProductName;

                    if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.NSP.ToString();
                    }
                    else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.MRP)
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.MRP.ToString();
                    }
                    else
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                    }

                    oRow.Cells[8].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);
                    if (_oWUIUtility.CurrentStock != 0)
                        oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();
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
                if (ctlCustomer1.SelectedCustomer == null)
                {
                    MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = (_oProductDetail.ProductID).ToString();

                        if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.NSP.ToString();
                        }
                        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.MRP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.MRP.ToString();
                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                        }

                        _oWUIUtility = new WUIUtility();
                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        if (_oWUIUtility.CurrentStock != 0)
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = _oWUIUtility.CurrentStock.ToString();
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

                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "" && _oWUIUtility.UOMConversionFactor != 0)
                {
                    nQuotient = Math.DivRem(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()), _oWUIUtility.UOMConversionFactor, out nRem);
                    if (nRem > 0)
                    {
                        MessageBox.Show("Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dgvLineItem.Rows[nRowIndex].Cells[2].Value.ToString() + "  is, " + _oWUIUtility.UOMConversionFactor.ToString());
                        return;

                    }
                    else
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = nQuotient.ToString();
                    }
                }

                if (dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString() != "" && dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString() != "" && dgvLineItem.Rows[nRowIndex].Cells[6].Value.ToString() != "")
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
                if (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString())> Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[7].Value.ToString()))
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
                if (this.Tag == null)
                    Save();
                else
                {
                    if (nUIControl == 2)
                        Edit();
                    else Confirm();
                }
                this.Close();
            }
         
        }
        private bool validateUIInput()
        {
            #region Order Master Information Validation


            if (rdbNew.Checked == true)
            {
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Deliver Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return false;
                }
                if (txtCustomerCode.Text == "")
                {
                    MessageBox.Show("Please enter Customer Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Focus();
                    return false;
                }
                if (txtCustomerName.Text == "")
                {
                    MessageBox.Show("Please enter Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerName.Focus();
                    return false;
                }
                if (txtEmAddress.Text == "")
                {
                    MessageBox.Show("Please enter Customer Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmAddress.Focus();
                    return false;
                }
                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please enter Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDesignation.Focus();
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
            }

            if (rdbOld.Checked == true)
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerCode = ctlCustomer1.txtCode.Text;
                _oCustomer.RefreshByCode();

                _oEPSCustomer = new EPSCustomer();
                _oEPSCustomer.EPSCustomerCode = ctlEPSCustomer1.txtCode.Text;
                _oEPSCustomer.RefreshByEPSCustomerCode();

                if (_oEPSCustomer.CustomerID != _oCustomer.CustomerID)
                {
                    MessageBox.Show("Please Check Company & EPS Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlEPSCustomer1.Focus();
                    return false;
                }

                if (ctlEPSCustomer1.SelectedEPSCustomer == null || ctlEPSCustomer1.txtDescription== null)
                {
                    MessageBox.Show("Please enter a EPS Customer Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlEPSCustomer1.Focus();
                    return false;
                }
            }
            try
            {
                double temp = Convert.ToDouble(txtInstallmnetNo.Text);
            }
            catch
            {
                MessageBox.Show("Please enter Installment No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallmnetNo.Focus();
                return false;
            }
            try
            {
                double temp = Convert.ToDouble(txtInterestRate.Text);
            }
            catch
            {
                MessageBox.Show("Please enter Interest Rate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInterestRate.Focus();
                return false;
            }
            if (ctlCustomer1.SelectedCustomer == null)
            {
                MessageBox.Show("Please enter a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();
                return false;
            }
            if (_oWarehouses == null)
            {
                MessageBox.Show("Please Select a Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return false;
            }
            if (cmbDeliveryWarehouse.Text == "<Select WarehouseName>")
            {
                MessageBox.Show("Please Select a Delivery Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDeliveryWarehouse.Focus();
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
                    if (oItemRow.Cells[8].Value == null)
                    {
                        return false;
                    }
                }
            }

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {

                if (oItemRow.Index < dgvLineItem.Rows.Count-1)
                {
                    int ProductID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                    long sum = 0;

                    foreach (DataGridViewRow oRow in dgvLineItem.Rows)
                    {
                        if (oRow.Index < dgvLineItem.Rows.Count-1)
                        {
                            if (Convert.ToInt32(oRow.Cells[8].Value.ToString().Trim()) == ProductID)
                            {
                                sum = sum + Convert.ToInt64(oItemRow.Cells[4].Value.ToString());
                            }
                        }
                    }
                    ProductStock oProductStock = new ProductStock();
                    oProductStock.ChannelID = Convert.ToInt32(ConfigurationManager.AppSettings["TDEPSEzeeBuy"].ToString());
                    oProductStock.WarehouseID = Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString());
                    oProductStock.ProductID = ProductID;


                    oProductStock.Refresh(oProductStock.ProductID,oProductStock.ChannelID, oProductStock.WarehouseID);


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
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oSalesOrder = new SalesOrder();
                _oEPSSalesOrder = new EPSSalesOrder();
                _oEMICalculationDetail = new EMICalculationDetail();
                _oEPSCustomer = new EPSCustomer();

                GetUIData(_oSalesOrder, _oEPSSalesOrder);
                _oSalesOrder.Insert(false);
                _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;


                _oCustomer = new Customer();
                _oCustomer.CustomerCode = ctlCustomer1.txtCode.Text;
                _oCustomer.RefreshByCode();
                _oEPSCustomer.CustomerID = _oCustomer.CustomerID;
                _oEPSCustomer.EmployeeCode = txtCustomerCode.Text;
                _oEPSCustomer.EmployeeName = txtCustomerName.Text;
                _oEPSCustomer.EmployeeAddress = txtEmAddress.Text;
                _oEPSCustomer.Designation = txtDesignation.Text;
                _oEPSCustomer.PhoneNo = txtPhoneNo.Text;
                _oEPSCustomer.Email = txtEmail.Text;


                if(rdbNew.Checked==true)
                {
                    _oEPSCustomer.InsertCustomer(true);
                }

                _oEPSSalesOrder.EPSCustomerID = _oEPSCustomer.EPSCustomerID;

                _oEPSSalesOrder.Insert();

                if (dtOrderDate.Value.Day > 15)
                    dtStartDate = dtOrderDate.Value.Date.AddMonths(1);
                else dtStartDate = dtOrderDate.Value.Date;

                _oEMICalculationDetail.Result(_oEPSSalesOrder.InterestRate, _oEPSSalesOrder.NoOfInstallment, Convert.ToDouble(txtTotal.Text), dtStartDate);

                foreach (EMICalculation oEMICalculation in _oEMICalculationDetail)
                {
                    oEMICalculation.OrderID = _oSalesOrder.OrderID;
                    oEMICalculation.IsDue = (int)Dictionary.EPSIsDue.Yes;
                    oEMICalculation.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
                    oEMICalculation.Insert();
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The EPS Order- " + _oSalesOrder.OrderNo.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppLogger.LogInfo("Win: Success fully Add EPS SalesOrder  =" + Utility.Username);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Win: Unsccessfull Add EPS SalesOrder  =" + ex);
                MessageBox.Show("You Have Unsccessfull Save The EPS Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Edit()
        {
            int nCount = 0;
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oEPSSalesOrder = (EPSSalesOrder)this.Tag;
                _oSalesOrder = _oEPSSalesOrder.SalesOrder;            
                _oEMICalculationDetail = new EMICalculationDetail();
                _oSalesOrder.Clear();

                GetUIData(_oSalesOrder, _oEPSSalesOrder);

                _oSalesOrder.Update();
                _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;
                //_oEPSCustomer.UpdateCustomer();

                _oEPSSalesOrder.Update();

                if (dtOrderDate.Value.Day > 15)
                    dtStartDate = dtOrderDate.Value.Date.AddMonths(1);
                else dtStartDate = dtOrderDate.Value.Date;

                _oEMICalculationDetail.Result(_oEPSSalesOrder.InterestRate, _oEPSSalesOrder.NoOfInstallment, Convert.ToDouble(txtPV.Text), dtStartDate);

                foreach (EMICalculation oEMICalculation in _oEMICalculationDetail)
                {                  
                    oEMICalculation.OrderID = _oSalesOrder.OrderID;
                    oEMICalculation.IsDue = (int)Dictionary.EPSIsDue.Yes;
                    oEMICalculation.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
                    if (nCount == 0)
                    {
                        oEMICalculation.Delete();
                        nCount++;
                    }
                    oEMICalculation.Insert();
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Update The Sales Order", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppLogger.LogInfo("Win: Success fully Update EPS SalesOrder  =" + Utility.Username);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Win: Unsccessfull Update EPS SalesOrder  =" + ex);
                MessageBox.Show("You Have Unsccessfull Update The Sales Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Confirm()
        {
            int nCount = 0;
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oEPSSalesOrder = (EPSSalesOrder)this.Tag;
                _oSalesOrder = _oEPSSalesOrder.SalesOrder;
                _oEMICalculationDetail = new EMICalculationDetail();
                _oSalesOrder.Clear();

                GetUIData(_oSalesOrder, _oEPSSalesOrder);
                _oSalesOrder.ConfirmDate = DateTime.Today.Date;
                _oSalesOrder.ConfirmUserID = Utility.UserId;
                _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Confirmed;
                _oSalesOrder.Edit();
                _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;
                //_oEPSCustomer.UpdateCustomer();
                _oEPSSalesOrder.Update();

                if (dtOrderDate.Value.Day > 15)
                    dtStartDate = dtOrderDate.Value.Date.AddMonths(1);
                else dtStartDate = dtOrderDate.Value.Date;

                _oEMICalculationDetail.Result(_oEPSSalesOrder.InterestRate, _oEPSSalesOrder.NoOfInstallment, Convert.ToDouble(txtPV.Text), dtStartDate);

                foreach (EMICalculation oEMICalculation in _oEMICalculationDetail)
                {
                    oEMICalculation.OrderID = _oSalesOrder.OrderID;
                    oEMICalculation.IsDue = (int)Dictionary.EPSIsDue.Yes;
                    oEMICalculation.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
                    if (nCount == 0)
                    {
                        oEMICalculation.Delete();
                        nCount++;
                    }
                    oEMICalculation.Insert();
                }
                ///
                // Update Product Satock
                ///
          

                foreach (SalesOrderItem _oSalesOrderItem in _oSalesOrder)
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.ProductID = _oSalesOrderItem.ProductID;
                    oProductStock.Quantity = _oSalesOrderItem.Quantity + _oSalesOrderItem.FreeQty;
                    oProductStock.WarehouseID = _oSalesOrder.WarehouseID;
                    oProductStock.ChannelID = _oCustomerDetail.ChannelID;

                    oProductStock.Edit();
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Confirm The Sales Order-" + _oSalesOrder.OrderNo.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppLogger.LogInfo("Win: Success fully Update EPS SalesOrder  =" + Utility.Username);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Win: Unsccessfull Confirm EPS SalesOrder  =" + ex);
                MessageBox.Show("You Have Unsccessfull Confirm The Sales Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void GetUIData(SalesOrder _oSalesOrder, EPSSalesOrder _oEPSSalesOrder)
        {
            ///
            // For Sales Order Class
            ///         

            _oSalesOrder.OrderDate = dtOrderDate.Value.Date;
            _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CREDIT;
            _oSalesOrder.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oSalesOrder.DeliveryAddress = txtAddress.Text;
            _oSalesOrder.SalesPersonID = -1;
            _oSalesOrder.WarehouseID = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;

            if (cmbSalesPromotion.Text != "" && _oSalesPromotions != null)
                _oSalesOrder.SalesPromotionID = _oSalesPromotions[cmbSalesPromotion.SelectedIndex].SalesPromotionID;
            else _oSalesOrder.SalesPromotionID = -1;

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

                    _oSalesOrderItem.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
                    _oSalesOrderItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    _oSalesOrderItem.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());

                    _oProvisionParam.GetProvisionParam(_oSalesOrderItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    if (nUIControl == 2)
                        _oSalesOrderItem.ConfirmQuantity = 0;
                    else _oSalesOrderItem.ConfirmQuantity = _oSalesOrderItem.Quantity;

                    _oSalesOrderItem.AdjustedDPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesOrderItem.AdjustedPWAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesOrderItem.AdjustedTPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.TP;
                    _oSalesOrderItem.PromotionalDiscount = 0;
                    _oSalesOrderItem.IsFreeProduct = 0;
                    _oSalesOrderItem.FreeQty = 0;

                    _oSalesOrder.Add(_oSalesOrderItem);
                }
            }
            if (_oSalesOrder.SalesPromotionID != -1)
            {
                foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
                {
                    ProvisionParam _oProvisionParam = new ProvisionParam();
                    if (_oProvisionParam.GetFreeProduct(oSalesOrderItem.ProductID, _oSalesOrder.SalesPromotionID))
                    {
                        if (IsOrderProduct(_oSalesOrder, _oProvisionParam.FreeProductID))
                        {
                            oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount;
                            oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;
                        }
                        else
                        {
                            SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                            _oSalesOrderItem.ProductID = _oProvisionParam.FreeProductID;
                            _oSalesOrderItem.UnitPrice = 0;
                            _oSalesOrderItem.Quantity = 0;
                            _oSalesOrderItem.ConfirmQuantity = 0;
                            _oSalesOrderItem.AdjustedDPAmount = 0;
                            _oSalesOrderItem.AdjustedPWAmount = 0;
                            _oSalesOrderItem.AdjustedTPAmount = 0;
                            _oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount;
                            _oSalesOrderItem.IsFreeProduct = 1;
                            _oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;

                            _oSalesOrder.Add(_oSalesOrderItem);
                        }
                    }
                }
            }
            ///
            // For Sales EPS sales class
            ///          


                _oCustomer = new Customer();
                _oCustomer.CustomerCode = ctlCustomer1.txtCode.Text;
                _oCustomer.RefreshByCode();

                _oEPSCustomer.CustomerID = _oCustomer.CustomerID;
                _oEPSCustomer.EmployeeCode = txtCustomerCode.Text;
                _oEPSCustomer.EmployeeName = txtCustomerName.Text;
                _oEPSCustomer.EmployeeAddress = txtEmAddress.Text;
                _oEPSCustomer.Designation = txtDesignation.Text;
                _oEPSCustomer.PhoneNo = txtPhoneNo.Text;
                _oEPSCustomer.Email = txtEmail.Text;

                        
            _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;

            _oEPSCustomer = new EPSCustomer();
            _oEPSCustomer.EPSCustomerCode = ctlEPSCustomer1.txtCode.Text;
            _oEPSCustomer.RefreshByEPSCustomerCode();

            _oEPSSalesOrder.EPSCustomerID = _oEPSCustomer.EPSCustomerID;

            _oEPSSalesOrder.NoOfInstallment = int.Parse(txtInstallmnetNo.Text);
            _oEPSSalesOrder.InterestRate = Convert.ToDouble(txtInterestRate.Text);
            try
            {
                 _oEPSSalesOrder.DownPayment = Convert.ToDouble(txtDownPayment.Text);
            }
            catch
            {
                _oEPSSalesOrder.DownPayment = 0;
            }
           
            _oEPSSalesOrder.DeliveryWHID = _oDeliveryWarehouses[cmbDeliveryWarehouse.SelectedIndex].WarehouseID;
            _oEPSSalesOrder.Status = (int)Dictionary.EPSStatus.Running;

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
                Downpayment = Convert.ToDouble(txtDownPayment.Text);
            }
            catch
            {
                Downpayment = 0;
            }
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
            txtPV.Text= Convert.ToDouble(Convert.ToDouble(txtTotal.Text)- Downpayment - Discount).ToString();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (rdbOld.Checked == true && txtCustomerCode.Text != "")
            {
                if (ctlCustomer1.SelectedCustomer == null)
                {
                    MessageBox.Show("Please select a company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _oEPSSalesOrder = new EPSSalesOrder();
                _oEPSSalesOrder.EPSCustomer.Customer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oEPSSalesOrder.EPSCustomer.EmployeeCode = txtCustomerCode.Text;

                if (_oEPSSalesOrder.EPSCustomer.RefreshEmployee())
                {
                    txtCustomerName.Text = _oEPSSalesOrder.EPSCustomer.EmployeeName;
                    txtDesignation.Text = _oEPSSalesOrder.EPSCustomer.Designation;
                    //label17.Visible = true;
                    //txtEPSCode.Visible = true;
                    //txtEPSCode.Enabled = false;
                    //txtEPSCode.Text = _oEPSSalesOrder.EPSCustomer.EPSCustomerCode;
                    txtEmAddress.Text = _oEPSSalesOrder.EPSCustomer.EmployeeAddress;
                    txtPhoneNo.Text = _oEPSSalesOrder.EPSCustomer.PhoneNo;
                    txtEmail.Text = _oEPSSalesOrder.EPSCustomer.Email;
                }
                else
                {
                    //label17.Visible = false;
                    //txtEPSCode.Visible = false;
                }

            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
        }

        private void ctlCustomer1_Load(object sender, EventArgs e)
        {

        }

        private void rdbNew_CheckedChanged(object sender, EventArgs e)
        {
            ctlEPSCustomer1.Enabled = false;
            txtCustomerCode.Enabled = true;
            txtDesignation.Enabled = true;
            txtEmAddress.Enabled = true;
            txtCustomerName.Enabled = true;
            txtPhoneNo.Enabled = true;
            txtEmail.Enabled = true;

        }

        private void rdbOld_CheckedChanged(object sender, EventArgs e)
        {

            ctlEPSCustomer1.Enabled = true;
            txtCustomerCode.Enabled = false;
            txtDesignation.Enabled = false;
            txtEmAddress.Enabled = false;
            txtCustomerName.Enabled = false;
            txtPhoneNo.Enabled = false;
            txtEmail.Enabled = false;
        }

        
    }

}