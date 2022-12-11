

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.M;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;

namespace CJ.Win.Distribution
{
    public partial class frmOrderFromCustomer : Form
    {
        SalesOrder _oSalesOrder;
        Customer _oCustomer;
        CustomerDetail _oCustomerDetail;
        Employees _oEmployees;
        Warehouses _oWarehouses = new Warehouses();
        SalesPromotions _oSalesPromotions;
        ProvisionParam oProvisionParam;
        ProductDetail _oProductDetail;
        Users oUsers;
        WUIUtility _oWUIUtility;
        TELLib oLib;
        MOrder _oMOrder;

     
        int _nRowIndex = 0;
        double _nPriceOption;
        bool IsUpdate = false;
        bool bFlag = true;
        bool IsAlterMOQ = false;
        string _sFeildName;
        int nAndroidOrderID=0;
        string sStatusName="";
        int nChannelID = 0;
        int nWarehouseID = 0;

        public frmOrderFromCustomer()
        {
            InitializeComponent();
        }

        private void frmOrderFromCustomer_Load(object sender, EventArgs e)
        {
       
        }
        public void ShowDialog(SalesOrder oSalesOrder)
        {
            nAndroidOrderID = 0;
            sStatusName = "";
            this.Tag = oSalesOrder;
            if (Utility.CompanyInfo=="TML")
            {
                oSalesOrder.RefreshOrderfromCustomerItem(oSalesOrder.AndroidOrderID);
            }

            if (Utility.CompanyInfo=="BLL")
            {
                oSalesOrder.RefreshOrderfromCustomerItemBLL(oSalesOrder.AndroidOrderID);
            }

            nAndroidOrderID = oSalesOrder.AndroidOrderID;
            _oMOrder = new MOrder();
            _oMOrder.GetOrderStatusByOrderID(nAndroidOrderID);
            sStatusName = oSalesOrder.StatusName;

            if (sStatusName != "Submit")
            {
                dgvLineItem.Columns[5].ReadOnly = true;
                dgvLineItem.Columns[5].DefaultCellStyle.BackColor = Color.LightGray;
            }

            if (oSalesOrder.OrderTypeID == (int)Dictionary.OrderType.CASH)
                chkOrderType.Checked = true;
            else chkOrderType.Checked = false;
            _oCustomer = new Customer();
            _oCustomer.CustomerID = oSalesOrder.CustomerID;
            _oCustomer.refresh();
            ctlCustomer1.txtCode.Text = _oCustomer.CustomerCode;
            ctlCustomer1_ChangeSelection(null, null);

            txtRemarks.Text = oSalesOrder.Remarks;

            foreach (SalesOrderItem oSalesOrderItem in oSalesOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesOrderItem.ProductCode.ToString();
                oRow.Cells[2].Value = oSalesOrderItem.ProductName.ToString();
                oRow.Cells[3].Value = oSalesOrderItem.UnitPrice.ToString();
                oRow.Cells[4].Value = oSalesOrderItem.OrderQty.ToString();
                oRow.Cells[5].Value = oSalesOrderItem.RevOrderQty.ToString();
                oRow.Cells[6].Value = oSalesOrderItem.NOrderQty.ToString();

                if (_oMOrder.OrderStatus == "CustomerOrder")
                {
                    oRow.Cells[7].Value = oSalesOrderItem.OrderQty.ToString();
                    oRow.Cells[8].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.OrderQty).ToString();
                }
                else if (_oMOrder.OrderStatus == "AreaOrder")
                { 
                    oRow.Cells[7].Value = oSalesOrderItem.RevOrderQty.ToString();
                    oRow.Cells[8].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.RevOrderQty).ToString();
                }
                else if (_oMOrder.OrderStatus == "NationalOrder")
                {
                    oRow.Cells[7].Value = oSalesOrderItem.NOrderQty.ToString();
                    oRow.Cells[8].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.NOrderQty).ToString();
                }
                _oWUIUtility = new WUIUtility();

                nChannelID = 0;
                nWarehouseID = 0;
                if (_oCustomerDetail.ChannelID == Utility.SESChannel)
                {
                    nChannelID = Utility.SESChannel;
                    nWarehouseID = Utility.SESWarehouse;
                }
                else if (_oCustomerDetail.ChannelID == Utility.SMDPChannel)
                {
                    nChannelID = Utility.SMDPChannel;
                    nWarehouseID = Utility.SMDPWarehouse;
                }
                _oWUIUtility.GetCurrentStock(nChannelID, nWarehouseID, oSalesOrderItem.ProductID);
                oRow.Cells[9].Value = _oWUIUtility.CurrentStock.ToString();

                oRow.Cells[10].Value = oSalesOrderItem.ProductID.ToString();
                oRow.Cells[0].ReadOnly = true;
                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();
            this.Tag = oSalesOrder;

            this.ShowDialog();
        }

        public void SetUI(CustomerDetail _oCustomerDetail)
        {
            _oEmployees = new Employees();
            _oEmployees.GetSalesPerson();

            if (_oCustomerDetail.ChannelDescription != null)
                lblchannel.Text = _oCustomerDetail.ChannelDescription;
            else lblchannel.Text = "NA";

            if (_oCustomerDetail.CustomerTypeName != null)
                lblCustomerTypeDescription.Text = _oCustomerDetail.CustomerTypeName;
            else lblCustomerTypeDescription.Text = "NA";

            if (_oCustomerDetail.AreaName != null)
                lblArea.Text = _oCustomerDetail.AreaName;
            else lblArea.Text = "NA";

            if (_oCustomerDetail.TerritoryName != null)
                lblTerritory.Text = _oCustomerDetail.TerritoryName;
            else lblTerritory.Text = "NA";

            if (_oCustomerDetail.ParentCustomerName != null)
                lbBranchNmae.Text = _oCustomerDetail.ParentCustomerName;
            else lbBranchNmae.Text = "NA";

            if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
            {
                lblAPO.Text = "NSP";
                _sFeildName = "NSP";             
                _nPriceOption = (long)Dictionary.PriceOption.NSP;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.RSP)
            {
                lblAPO.Text = "RSP";
                _sFeildName = "RSP";             
                _nPriceOption = (long)Dictionary.PriceOption.RSP;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
            {
                lblAPO.Text = "Special Price";              
                _nPriceOption = (long)Dictionary.PriceOption.Special_Price;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Cost_Price)
            {
                lblAPO.Text = "Cost Price";             
                _nPriceOption = (long)Dictionary.PriceOption.Cost_Price;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Trade_Price)
            {
                lblAPO.Text = "Trade Price";              
                _nPriceOption = (long)Dictionary.PriceOption.Trade_Price;
            }
            if (_oCustomerDetail.DiscountPercent != 0)
            {
                lblDP.Text = _oCustomerDetail.DiscountPercent.ToString();
                lblDP.Visible = true;
            }
            else
            {
                lblDP.Text = "0";
                lblDP.Visible = true;
            }
            if (_oCustomerDetail.HaveAmountDisCount == (short)Dictionary.ActiveOrInActiveStatus.ACTIVE)
            {
                lblOD.Text = "Other Discount Applicable";              
            }
            else
            {
                lblOD.Text = "Other Discount Not Applicable";               
            }
            if (_oCustomerDetail.CurrentBalance != 0)
            {             
                lblCustomerBal.Text = _oCustomerDetail.CurrentBalance.ToString();
            }
            else
            {             
                lblCustomerBal.Text = "0.00";
            }
            if (_oCustomer.MinCreditLimit != 0)
            {
                lblCreditLimit.Text = _oCustomer.MinCreditLimit.ToString();
            }
            else
            {
                lblCreditLimit.Text = "0.00";
            }
            string sWarehouse = string.Empty;
            try
            {
                sWarehouse = Utility.POSWarehouse;
            }
            catch (Exception ex)
            {

            }
            _oWarehouses = new Warehouses();
            _oWarehouses.GetWarehouseName(_oCustomerDetail.ChannelID, sWarehouse, 0);
            _oSalesPromotions = new SalesPromotions();
            _oSalesPromotions.RefreshForSalesOrder(_oCustomerDetail.CustomerID);
            txtDeliveryAdd.Text = _oCustomerDetail.CustomerAddress;

        }
        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.SelectedCustomer != null && ctlCustomer1.txtCode.Text != "")
            {
                _oCustomerDetail = new CustomerDetail();
                _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oCustomerDetail.refresh();
                _oCustomer = new Customer();
                _oCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oCustomer.GetCustomerCreditLimit();
                SetUI(_oCustomerDetail);
            }

        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
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
                    else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.RSP)
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                    }
                    else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.SpecialPrice.ToString();
                    }
                    else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.MRP)
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.MRP.ToString();
                    }
                    oRow.Cells[4].Value = 0;
                    oRow.Cells[5].Value = 0;
                    oRow.Cells[6].Value = 0;
                    oRow.Cells[8].Value = 0;
                    oRow.Cells[10].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    nChannelID = 0;
                    nWarehouseID = 0;
                    if (_oCustomerDetail.ChannelID == Utility.SESChannel)
                    {
                        nChannelID = Utility.SESChannel;
                        nWarehouseID = Utility.SESWarehouse;
                    }
                    else if (_oCustomerDetail.ChannelID == Utility.SMDPChannel)
                    {
                        nChannelID = Utility.SMDPChannel;
                        nWarehouseID = Utility.SMDPWarehouse;
                    }
                    _oWUIUtility.GetCurrentStock(nChannelID, nWarehouseID, oForm._oProductDetail.ProductID);
                    if (_oWUIUtility.CurrentStock != 0)
                        oRow.Cells[9].Value = _oWUIUtility.CurrentStock.ToString();
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
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
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
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = (_oProductDetail.ProductID).ToString();

                        if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.NSP.ToString();
                        }
                        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.RSP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                        }
                        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.SpecialPrice.ToString();
                        }
                        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Trade_Price)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.TradePrice.ToString();
                        }
                        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Trade_Price)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.MRP.ToString();
                        }
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;

                        _oWUIUtility = new WUIUtility();
                        nChannelID = 0;
                        nWarehouseID = 0;
                        if (_oCustomerDetail.ChannelID == Utility.SESChannel)
                        {
                            nChannelID = Utility.SESChannel;
                            nWarehouseID = Utility.SESWarehouse;
                        }
                        else if (_oCustomerDetail.ChannelID == Utility.SMDPChannel)
                        {
                            nChannelID = Utility.SMDPChannel;
                            nWarehouseID = Utility.SMDPWarehouse;
                        }

                        _oWUIUtility.GetCurrentStock(nChannelID, nWarehouseID, _oProductDetail.ProductID);
                        if (_oWUIUtility.CurrentStock != 0)
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = _oWUIUtility.CurrentStock.ToString();
                        else
                        {
                            MessageBox.Show("Product Stock not avialable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
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
                    return;
                }
            }
            if (nColumnIndex == 7)
            {
                long nRem = 0;
                long nQuotient = 0;
                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
                {
                    dgvLineItem.Rows[nRowIndex].Cells[8].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[7].Value.ToString()));
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

        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            double _TotalAmount = 0;
            oLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[10].Value != null)
                {
                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())).ToString();
                    
                }
            }
            txtNetPay.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)).ToString();        
     
            
        }

        private bool validateUIInput()
        {
            #region Order Master Information Validation
            if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Invalid unit price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Invalid unit price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[7].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please input valid Order Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[7].Value) == 0)
                    {
                        MessageBox.Show("Please input valid Order Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[7].Value) > Convert.ToInt32(oItemRow.Cells[9].Value))
                    {
                        MessageBox.Show("Order quantity must be less than or equal Stock Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                   
                }
            }
            #endregion

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

             if (validateUIInput())
                {
                    Save();
                    this.Close();
                }           
           
        }

        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oSalesOrder = new SalesOrder();
                _oSalesOrder.Clear();
                _oSalesOrder = GetUIData(_oSalesOrder);
                _oSalesOrder.Insert(false);

                _oSalesOrder.ActualOrderID = _oSalesOrder.OrderID;
                _oSalesOrder.AndroidOrderID = nAndroidOrderID;
                _oSalesOrder.AndroidUpdate();


                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully receive Sales Order -" + _oSalesOrder.OrderNo.ToString(), "Receive", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SalesOrder GetUIData(SalesOrder _oSalesOrder)
        {

            _oSalesOrder.OrderDate = DateTime.Today.Date;
            if (chkOrderType.Checked == true)
            {
                _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CASH;
            }
            else
            {
                _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CREDIT;
            }

            _oSalesOrder.CustomerID = _oCustomerDetail.CustomerID;
            _oSalesOrder.DeliveryAddress = txtDeliveryAdd.Text;

            if (_oCustomerDetail.ChannelID == Utility.SESChannel)
            {
                _oSalesOrder.WarehouseID = Utility.SESWarehouse;
            }
            else if (_oCustomerDetail.ChannelID == Utility.SMDPChannel)
            {
                _oSalesOrder.WarehouseID = Utility.SMDPWarehouse;
            }

           _oSalesOrder.Remarks = txtRemarks.Text;

            try
            {
                _oSalesOrder.Discount = Convert.ToDouble(txtTradeDiscount.Text);

            }
            catch
            {
                _oSalesOrder.Discount = 0;
            }
            _oSalesOrder.CreateUserID = Utility.UserId;
            _oSalesOrder.UpdateUserID = Utility.UserId; 
            _oSalesOrder.UpdateDate = DateTime.Today.Date;

            // Product Details
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count -1)
                {
                    SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                    ProvisionParam _oProvisionParam = new ProvisionParam();

                    _oSalesOrderItem.ProductID = int.Parse(oItemRow.Cells[10].Value.ToString());
                 // _oSalesOrderItem.UnitPrice =int.Parse(oItemRow.Cells[3].Value.ToString());
                    _oSalesOrderItem.UnitPrice =double.Parse(oItemRow.Cells[3].Value.ToString());
                    _oSalesOrderItem.Quantity = int.Parse(oItemRow.Cells[7].Value.ToString());

                    _oSalesOrderItem.ConfirmQuantity = 0;
                    _oSalesOrderItem.AdjustedDPAmount = 0;
                    _oSalesOrderItem.AdjustedPWAmount = 0;
                    _oSalesOrderItem.AdjustedTPAmount = 0;
                    _oSalesOrderItem.PromotionalDiscount = 0;
                    _oSalesOrderItem.IsFreeProduct = 0;
                    _oSalesOrderItem.FreeQty = 0;

                    _oSalesOrder.Add(_oSalesOrderItem);

                }
            }

            return _oSalesOrder;
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

        private void txtTradeDiscount_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }

       
    }
}