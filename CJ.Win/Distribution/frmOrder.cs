using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.Promotion;

namespace CJ.Win.Distribution
{
    public partial class frmOrder : Form
    {
        string sDeliveryAddress = "";
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
        SPromotions oResultSPromotions;
        SPromotions oSPromotions;
        SPromotion oResultSPromotion;
        CustomerCreditLimit oCustomerCreditLimit;

        int _nRowIndex = 0;
        double _nPriceOption;
        bool IsUpdate = false;
        bool bFlag = true;
        bool IsAlterMOQ = false;
        string _sFeildName;
        int _nUIControl = 0;
        int nOrderID = 0;
        int sOrderNo = 0;
        object dOrderDate;
        int nCustTypeID = 0;
        public frmOrder(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            if (Utility.CompanyInfo == "BLL")
            {

                if (_nUIControl == 1)
                {
                    this.Text = "Order";
                    tabControl1.TabPages.Remove(tabPage2);
                    dgvLineItem.Columns[9].Visible = false;
                    dgvLineItem.Columns[4].Visible = false;
                    dgvLineItem.Columns[5].Visible = false;
                    dgvLineItem.Columns[6].Visible = false;
                    //dgvLineItem.Columns[20].Visible = false;
                }
                else
                {
                    this.Text = "Confirm Order";
                    btnSave.Enabled = false;
                    dgvLineItem.Columns[8].ReadOnly = true;
                    dgvLineItem.Columns[20].Visible = true;
                    dgvLineItem.Columns[21].Visible = true;
                    dgvLineItem.Columns[22].Visible = true;
                    dgvLineItem.Columns[23].Visible = true;
                    dgvLineItem.Columns[24].Visible = true;


                    Utilities oOverStkReasonBLL = new Utilities();
                    oOverStkReasonBLL.GetOverStkReasonBLL();
                    DataGridViewComboBoxColumn ColumnItem3 = new DataGridViewComboBoxColumn();
                    ColumnItem3.DataPropertyName = "OverStockReason";
                    ColumnItem3.HeaderText = "OverStk Reason";
                    ColumnItem3.Width = 80;
                    ColumnItem3.DataSource = oOverStkReasonBLL;
                    ColumnItem3.ValueMember = "SatusId";
                    ColumnItem3.DisplayMember = "Satus";
                    dgvLineItem.Columns.Add(ColumnItem3);

                }
            }
            else
            {

                if (_nUIControl == 1)
                {
                    this.Text = "Order";
                    tabControl1.TabPages.Remove(tabPage2);
                    dgvLineItem.Columns[9].Visible = false;
                    dgvLineItem.Columns[4].Visible = false;
                    dgvLineItem.Columns[5].Visible = false;
                    dgvLineItem.Columns[6].Visible = false;
                    //dgvLineItem.Columns[20].Visible = false;
                }
                else
                {
                    this.Text = "Confirm Order";
                    btnSave.Enabled = false;
                    dgvLineItem.Columns[8].ReadOnly = true;
                    dgvLineItem.Columns[4].Visible = false;
                    dgvLineItem.Columns[5].Visible = false;
                    dgvLineItem.Columns[6].Visible = false;
                    //dgvLineItem.Columns[20].Visible = false;
                }
            }
        }
        public void ShowDialog(SalesOrder oSalesOrder)
        {
            oLib = new TELLib();
            long nRem = 0;
            long nQuotient = 0;
            ctlCustomer1.Enabled = false;
            cmbWarehouse.Enabled = false;
            nOrderID = oSalesOrder.OrderID;
            sOrderNo = oSalesOrder.OrderNo;
            dOrderDate = oSalesOrder.OrderDate;
            this.Tag = oSalesOrder;
            if (Utility.CompanyInfo == "BLL")
            {
                oSalesOrder.RefreshSalesOrderItemForBLL(oSalesOrder.CustomerID, nOrderID);

            }
            else
            {
                oSalesOrder.RefreshSalesOrderItem();
            }
            txtOrderNo.Text = oSalesOrder.OrderNo.ToString();
            txtDeliveryAdd.Text = oSalesOrder.DeliveryAddress;
            sDeliveryAddress = oSalesOrder.DeliveryAddress;
            if (oSalesOrder.OrderTypeID == (int)Dictionary.OrderType.CASH)
                chkOrderType.Checked = true;
            else chkOrderType.Checked = false;
            _oCustomer = new Customer();
            _oCustomer.CustomerID = oSalesOrder.CustomerID;
            _oCustomer.refresh();
            nCustTypeID = _oCustomer.CustTypeID;
            ctlCustomer1.txtCode.Text = _oCustomer.CustomerCode;
            cmbSalesPerson.SelectedIndex = _oEmployees.GetIndex(oSalesOrder.SalesPersonID);
            cmbWarehouse.SelectedIndex = _oWarehouses.GetIndex(oSalesOrder.WarehouseID);
            if (oSalesOrder.SalesPromotionID != -1)
                cmbPromotion.SelectedIndex = _oSalesPromotions.GetIndex(oSalesOrder.SalesPromotionID);
            txtDDAmount.Text = oSalesOrder.DDAmount.ToString("0.00");
            if (oSalesOrder.DDDate != DBNull.Value)
                dtDDDate.Value = Convert.ToDateTime(oSalesOrder.DDDate);
            txtDDDetails.Text = oSalesOrder.DDDetails;
            txtRemarks.Text = oSalesOrder.Remarks;
            txtTradeDiscount.Text = oLib.TakaFormat(oSalesOrder.Discount);

            if (Utility.CompanyInfo == "BLL")
            {
                foreach (SalesOrderItem oSalesOrderItem in oSalesOrder)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oSalesOrderItem.Product.ProductCode.ToString();
                    oRow.Cells[2].Value = oSalesOrderItem.Product.ProductName.ToString();
                    oRow.Cells[3].Value = oSalesOrderItem.UnitPrice.ToString();

                    oRow.Cells[4].Value = oSalesOrderItem.DBStock.ToString();
                    oRow.Cells[5].Value = oSalesOrderItem.StockNorm.ToString();
                    oRow.Cells[6].Value = (oSalesOrderItem.StockNorm - oSalesOrderItem.DBStock).ToString();
                    oRow.Cells[8].Value = oSalesOrderItem.Quantity.ToString();
                    oRow.Cells[9].Value = oSalesOrderItem.Quantity.ToString();
                    oRow.Cells[10].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.Quantity).ToString();
                    ProvisionParam oProvisionParam = new ProvisionParam();
                    oProvisionParam.GetProvisionParam(oSalesOrderItem.Product.ProductID, nCustTypeID);
                    double SC = (oSalesOrderItem.UnitPrice * oProvisionParam.SC * oSalesOrderItem.Quantity);
                    double TP = (oSalesOrderItem.UnitPrice * oProvisionParam.TP * oSalesOrderItem.Quantity);
                    double PW = (oSalesOrderItem.UnitPrice * oProvisionParam.PW * oSalesOrderItem.Quantity);

                    oRow.Cells[11].Value = SC.ToString();
                    oRow.Cells[12].Value = TP.ToString();
                    oRow.Cells[13].Value = PW.ToString();

                    //oRow.Cells[11].Value = (oSalesOrderItem.AdjustedDPAmount * oSalesOrderItem.Quantity).ToString();
                    //oRow.Cells[12].Value = (oSalesOrderItem.AdjustedTPAmount * oSalesOrderItem.Quantity).ToString();
                    //oRow.Cells[13].Value = (oSalesOrderItem.AdjustedPWAmount * oSalesOrderItem.Quantity).ToString();

                    //double TotalProvision = (Convert.ToDouble(oSalesOrderItem.AdjustedDPAmount * oSalesOrderItem.Quantity) + Convert.ToDouble(oSalesOrderItem.AdjustedTPAmount * oSalesOrderItem.Quantity) + Convert.ToDouble(oSalesOrderItem.AdjustedPWAmount * oSalesOrderItem.Quantity));
                    double TotalProvision = SC + TP + PW;
                    oRow.Cells[14].Value = (oSalesOrderItem.UnitPrice * oSalesOrderItem.Quantity) - TotalProvision;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oSalesOrderItem.ProductID);
                    oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();

                    nQuotient = Math.DivRem((int)oSalesOrderItem.Quantity, (int)_oWUIUtility.UOMConversionFactor, out nRem);
                    oRow.Cells[15].Value = nQuotient;

                    oRow.Cells[16].Value = oSalesOrderItem.ProductID.ToString();

                    oRow.Cells[0].ReadOnly = true;
                    if (_nUIControl == 1)
                    {
                        oRow.Cells[8].ReadOnly = false;
                        oRow.Cells[9].ReadOnly = true;
                    }
                    else
                    {
                        oRow.Cells[8].ReadOnly = true;
                        oRow.Cells[9].ReadOnly = false;
                    }

                    double AdjustedSC = (oSalesOrderItem.UnitPrice * oProvisionParam.SC);
                    double AdjustedTP = (oSalesOrderItem.UnitPrice * oProvisionParam.TP);
                    double AdjustedPW = (oSalesOrderItem.UnitPrice * oProvisionParam.PW);

                    oRow.Cells[17].Value = AdjustedSC.ToString();
                    oRow.Cells[18].Value = AdjustedTP.ToString();
                    oRow.Cells[19].Value = AdjustedPW.ToString();

                    oRow.Cells[20].Value = Enum.GetName(typeof(Dictionary.ProductMovingType), oSalesOrderItem.MStatus);
                    oRow.Cells[21].Value = oSalesOrderItem.LWSec.ToString();
                    oRow.Cells[22].Value = oSalesOrderItem.LWReq.ToString();
                    oRow.Cells[23].Value = oSalesOrderItem.MTDSec.ToString();
                    oRow.Cells[24].Value = oSalesOrderItem.MTDReq.ToString();

                    dgvLineItem.Rows.Add(oRow);

                }

            }
            else
            {
                foreach (SalesOrderItem oSalesOrderItem in oSalesOrder)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oSalesOrderItem.Product.ProductCode.ToString();
                    oRow.Cells[2].Value = oSalesOrderItem.Product.ProductName.ToString();
                    oRow.Cells[3].Value = oSalesOrderItem.UnitPrice.ToString();

                    oRow.Cells[4].Value = 0;
                    oRow.Cells[5].Value = 0;
                    oRow.Cells[6].Value = 0;


                    oRow.Cells[8].Value = oSalesOrderItem.Quantity.ToString();
                    oRow.Cells[9].Value = oSalesOrderItem.Quantity.ToString();
                    oRow.Cells[10].Value = Convert.ToDouble(oSalesOrderItem.UnitPrice * oSalesOrderItem.Quantity).ToString();
                    oRow.Cells[11].Value = (oSalesOrderItem.AdjustedDPAmount * oSalesOrderItem.Quantity).ToString();
                    oRow.Cells[12].Value = (oSalesOrderItem.AdjustedTPAmount * oSalesOrderItem.Quantity).ToString();
                    oRow.Cells[13].Value = (oSalesOrderItem.AdjustedPWAmount * oSalesOrderItem.Quantity).ToString();

                    double TotalProvision = (Convert.ToDouble(oSalesOrderItem.AdjustedDPAmount * oSalesOrderItem.Quantity) + Convert.ToDouble(oSalesOrderItem.AdjustedTPAmount * oSalesOrderItem.Quantity) + Convert.ToDouble(oSalesOrderItem.AdjustedPWAmount * oSalesOrderItem.Quantity));
                    oRow.Cells[14].Value = (oSalesOrderItem.UnitPrice * oSalesOrderItem.Quantity) - TotalProvision;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oSalesOrderItem.ProductID);
                    oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();

                    if (_oWUIUtility.UOMConversionFactor == 0)
                    {
                        _oWUIUtility.GetMOUByProductID(oSalesOrderItem.ProductID);
                    }
                    nQuotient = Math.DivRem((int)oSalesOrderItem.Quantity, (int)_oWUIUtility.UOMConversionFactor, out nRem);
                    oRow.Cells[15].Value = nQuotient;

                    oRow.Cells[16].Value = oSalesOrderItem.ProductID.ToString();

                    oRow.Cells[0].ReadOnly = true;
                    if (_nUIControl == 1)
                    {
                        oRow.Cells[8].ReadOnly = false;
                        oRow.Cells[9].ReadOnly = true;
                    }
                    else
                    {
                        oRow.Cells[8].ReadOnly = true;
                        oRow.Cells[9].ReadOnly = false;
                    }

                    oRow.Cells[17].Value = oSalesOrderItem.AdjustedDPAmount.ToString();
                    oRow.Cells[18].Value = oSalesOrderItem.AdjustedTPAmount.ToString();
                    oRow.Cells[19].Value = oSalesOrderItem.AdjustedPWAmount.ToString();
                    dgvLineItem.Rows.Add(oRow);

                }
            }

            GetTotalAmount();
            //rdbOld.Checked = true;
            //this.Tag = _oEPSSalesOrder;

            this.ShowDialog();
        }
        public void SetUI(CustomerDetail _oCustomerDetail)
        {
            _oEmployees = new Employees();
            _oEmployees.GetSalesPerson();
            cmbSalesPerson.Items.Clear();
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbSalesPerson.Items.Add(oEmployee.EmployeeName);
            }
            cmbSalesPerson.SelectedIndex = 0;

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

            if (_oWarehouses.Count > 0)
            {
                cmbWarehouse.Items.Clear();
                foreach (Warehouse oWarehouse in _oWarehouses)
                {
                    cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
                }
                cmbWarehouse.SelectedIndex = 0;
            }
            else _oWarehouses = null;     

            _oSalesPromotions = new SalesPromotions();
            _oSalesPromotions.RefreshForSalesOrder(_oCustomerDetail.CustomerID);

            if (_oSalesPromotions.Count > 0)
            {
                cmbPromotion.Items.Clear();
                foreach (SalesPromotion oSalesPromotion in _oSalesPromotions)
                {
                    cmbPromotion.Items.Add(oSalesPromotion.SalesPromotionName);
                }
                cmbPromotion.SelectedIndex = 0;
            }
            else _oSalesPromotions = null;

            if (sDeliveryAddress == "")
                txtDeliveryAdd.Text = _oCustomerDetail.CustomerAddress;
            else txtDeliveryAdd.Text = sDeliveryAddress.ToString();

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
                        oRow.Cells[3].Value = oForm._oProductDetail.NSP.ToString();
                    else oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                    oRow.Cells[16].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);

                    oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();
                    
                    if (_nUIControl == 1)
                    {
                        oRow.Cells[9].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[9].ReadOnly = true;
                    }
                    else
                    {
                        oRow.Cells[8].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[8].ReadOnly = true;
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
            int nIndex = 0;
            if (_nUIControl == 1)
            {
                nIndex = 8;
            }
            else
            {
                nIndex = 9;
            }
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
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = (_oProductDetail.ProductID).ToString();

                        if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.NSP.ToString();
                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                        }

                        _oWUIUtility = new WUIUtility();
                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, _oProductDetail.ProductID);

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = _oWUIUtility.CurrentStock.ToString();

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                        if (nIndex == 8)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].ReadOnly = true;

                        }
                        else if (nIndex == 9)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].Value = 0;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 8].ReadOnly = true;
                        }
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
            else if (nColumnIndex == nIndex)
            {
                long nRem = 0;
                long nQuotient = 0;
                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "" && _oWUIUtility.UOMConversionFactor != 0)
                {
                    int nProductID = Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[16].Value);
                    WUIUtility oWUIUtility = new WUIUtility();
                    oWUIUtility.GetMOUByProductID(nProductID);
                    nQuotient = Math.DivRem(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()), oWUIUtility.UOMConversionFactor, out nRem);
                    if (nRem > 0)
                    {
                        MessageBox.Show("Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dgvLineItem.Rows[nRowIndex].Cells[2].Value.ToString() + "  is, " + _oWUIUtility.UOMConversionFactor.ToString());
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[10].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[11].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[12].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[13].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[14].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[15].Value = 0;

                        return;
                    }
                    else
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[15].Value = nQuotient.ToString();
                    }
                    oProvisionParam = new ProvisionParam();
                    if (_oProductDetail == null)
                    {
                        _oProductDetail = new ProductDetail();
                        oProvisionParam.GetProvisionParam(Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[16].Value), _oCustomerDetail.CustomerTypeID);
                        _oProductDetail = null;
                    }
                    else
                    {
                        oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                    }
                    dgvLineItem.Rows[nRowIndex].Cells[11].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.SC * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString());
                    dgvLineItem.Rows[nRowIndex].Cells[12].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.TP * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString());
                    dgvLineItem.Rows[nRowIndex].Cells[13].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.PW * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString());

                    double TotalProvision = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[11].Value.ToString())) + (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[12].Value.ToString())) + (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[13].Value.ToString()));
                    dgvLineItem.Rows[nRowIndex].Cells[10].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString()));
                    dgvLineItem.Rows[nRowIndex].Cells[14].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[nIndex].Value.ToString())) - TotalProvision;

                    dgvLineItem.Rows[nRowIndex].Cells[17].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.SC;
                    dgvLineItem.Rows[nRowIndex].Cells[18].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.TP;
                    dgvLineItem.Rows[nRowIndex].Cells[19].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * oProvisionParam.PW;

                }
                cmbWarehouse.Enabled = false;
                ctlCustomer1.Enabled = false;
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
                if (oRow.Cells[14].Value != null)
                {
                    //txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[14].Value.ToString())).ToString();
                    txtTotalAmount.Text = Math.Round(Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[14].Value.ToString())),2).ToString();

                }
            }
            txtNetPay.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)).ToString();        
            //txtNetPay.Text = Math.Round(Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)),2).ToString();
            oLib = new TELLib();
            lblAmountInWord.Visible = true;
            lblAmountInWord.Text = oLib.TakaWords(Convert.ToDouble(txtNetPay.Text));       
            
        }
        public void GetFreeProductTotal()
        {
            txtSPTotalQty.Text = "0";
            int nSum = 0;
            foreach (DataGridViewRow oRow in dvgFreeProduct.Rows)
            {
                if (dvgFreeProduct.Rows.Count > 0)
                {
                    if (oRow.Cells[3].Value != null)
                    {
                        nSum = nSum + Convert.ToInt32(oRow.Cells[3].Value);

                    }
                }
            }
            txtSPTotalQty.Text = nSum.ToString();

        }
        private void NetTotal()
        {
            txtNetPay.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)).ToString();
            oLib = new TELLib();
            lblAmountInWord.Visible = true;
            lblAmountInWord.Text = oLib.TakaWords(Convert.ToDouble(txtNetPay.Text));
        }
        private bool validateUIInput()
        {
            ///// New Code added 
            CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();
            //oCustomerCreditLimit.GetStockReleaseLimit(Utility.UserId);
            //// End

            #region Order Master Information Validation
            if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }
            if (_oWarehouses == null)
            {
                MessageBox.Show("Please Input Valid Warehouse Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID==-1)
            {
                MessageBox.Show("Please Input Valid Warehouse Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
                return false;
            }           

            #endregion

            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                return false;
            }
            if(_nUIControl==2)
            {
                if (dgvLineItem.Rows.Count > 26)
                {
                    MessageBox.Show(" More then 25 SKU is not allowed in a single Invoice ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        double temp = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Check Unit Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (_nUIControl == 1)
                    {
                        try
                        {
                            int temp = int.Parse(oItemRow.Cells[8].Value.ToString());
                            if (temp <= 0)
                            {
                                MessageBox.Show("Order Qty Must be greater then Zero (0)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Please input Only number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        try
                        {
                            /// New Code Start added for Mr. Akib
                            int CurrentStk = int.Parse(oItemRow.Cells[7].Value.ToString());
                            int ConfirmedQty = int.Parse(oItemRow.Cells[9].Value.ToString());

                         
                            int ProductCodeTab1 = Int32.Parse(oItemRow.Cells[0].Value.ToString());
                            int TotalQty = 0;

                            /// New Code for Over Stock- Mr. Hrashid
                            string ProductNameTab3 = oItemRow.Cells[2].Value.ToString();
                            int DBStock = 0;
                            int StockNorm = 0;

                            oCustomerCreditLimit = new CustomerCreditLimit();
                            oCustomerCreditLimit.GetDBStock(ProductCodeTab1, _oCustomerDetail.CustomerID);
                            oCustomerCreditLimit.GetCustomerStatus(_oCustomerDetail.CustomerID);

                            //if ( oCustomerCreditLimit.AreaID != 288)
                            //{
                            //    oCustomerCreditLimit.GetMAGStatus(ProductCodeTab1);
                            //    if (oCustomerCreditLimit.MAGID == 709)
                                    
                            //    {
                            //        MessageBox.Show("CFL Only For WholeSales Channel " +
                            //            ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return false;
                            //    }
                            //}


                            foreach (DataGridViewRow oItemRowfree in dvgFreeProduct.Rows)
                            {
                                int ProductCode = Int32.Parse(oItemRowfree.Cells[1].Value.ToString());
                                if (ProductCodeTab1 == ProductCode)
                                {
                                    if (oItemRowfree.Cells[3].Value != null)
                                        TotalQty = ConfirmedQty + Int32.Parse(oItemRowfree.Cells[3].Value.ToString());
                                    else
                                        TotalQty = ConfirmedQty;

                                    if (TotalQty > CurrentStk)
                                    {
                                        MessageBox.Show("Insufficient Stock P.Code= " +
                                            ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                            }

                            if (ConfirmedQty> CurrentStk)
                            {
                               MessageBox.Show("Insufficient Stock P.Code= " +
                                            ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + " ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            // Validation check for BD's Over Stock Situation by Harshid on 01-Jan-2020

                            /// New Code added 
 
                            oCustomerCreditLimit.GetStockReleaseLimit(Utility.UserId);
                            // End

                            if (oCustomerCreditLimit.StockPermission == 0)
                            {
                                _oSalesOrder = new SalesOrder();
                                oCustomerCreditLimit.GetCustomerStatus(_oCustomerDetail.CustomerID);
                                //if (oCustomerCreditLimit.CustomerTypeID == 229 && oCustomerCreditLimit.AreaID != 288)
                                if (oCustomerCreditLimit.AreaID != 288)
                                {
                                    oCustomerCreditLimit.GetProductStatus(ProductCodeTab1, _oCustomerDetail.CustomerID);

                                    if (oCustomerCreditLimit.CategoryID == 4)
                                    {
                                        MessageBox.Show(
                                            " There is a Product in Red Category. Can't Confirm P.Code= " +
                                            ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + " ", "Warning",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;

                                    }

                                    if (oCustomerCreditLimit.StockNorm != 0)
                                    {

                                        if (oCustomerCreditLimit.DBStock > oCustomerCreditLimit.StockNorm)
                                        {
                                            MessageBox.Show(
                                                " DB Stock is Already Over than Standard Stock P.Code = " +
                                                ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "", "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return false;
                                        }
                                        else if ((oCustomerCreditLimit.DBStock + ConfirmedQty) > oCustomerCreditLimit.StockNorm)

                                        {
                                            MessageBox.Show(
                                                " Confirm Qty will exceed the DB Standard Stock P.Code = " +
                                                ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "",
                                                "Warning",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return false;
                                        }
                                    }

                                    else if (oCustomerCreditLimit.DBStock + oCustomerCreditLimit.StockNorm != 0)
                                    {
                                         if (oCustomerCreditLimit.DBStock <= oCustomerCreditLimit.StockNorm)
                                        {
                                            if (oCustomerCreditLimit.DBStock + ConfirmedQty > oCustomerCreditLimit.StockNorm)
                                            {
                                                int OStock = ConfirmedQty +
                                                             (oCustomerCreditLimit.DBStock - oCustomerCreditLimit.StockNorm);
                                                MessageBox.Show(" Pls. reduce the confirm Qty in" + OStock + " for the Product Code = " +
                                                        ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "", "Warning",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return false;
                                            }

                                        }

                                    }

                                    //else if (oCustomerCreditLimit.DBStock <= oCustomerCreditLimit.StockNorm)
                                    //{
                                    //    if (oCustomerCreditLimit.DBStock + ConfirmedQty > oCustomerCreditLimit.StockNorm)
                                    //    {
                                    //        int OStock = ConfirmedQty +
                                    //                     (oCustomerCreditLimit.DBStock - oCustomerCreditLimit.StockNorm);
                                    //        MessageBox.Show(" Pls. reduce the confirm Qty in" + OStock + " for the Product Code = " +
                                    //                ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "", "Warning",
                                    //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //        return false;
                                    //    }

                                    //}

                                    //if (StockNorm != 0)
                                    //{

                                    //    if (DBStock > StockNorm)
                                    //    {
                                    //        MessageBox.Show(
                                    //            " DB Stock is Already Over than Standard Stock P.Code = " +
                                    //            ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "", "Warning",
                                    //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //        return false;
                                    //    }
                                    //    else if ((DBStock + ConfirmedQty) > StockNorm)

                                    //    {
                                    //        MessageBox.Show(
                                    //            " Confirm Qty will exceed the DB Standard Stock P.Code = " +
                                    //            ProductCodeTab1 + " & P.Name:  " + ProductNameTab3 + "",
                                    //            "Warning",
                                    //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //        return false;
                                    //    }
                                    //}
                                }

                            }                            

                        }

                        catch
                        {
                            MessageBox.Show("Please input Only number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[16].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

          


                #endregion

                #region Confirm Qty
                if (Utility.CompanyInfo == "BLL")
            {
                if (_nUIControl == 2)
                {
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {

                            int nConfirmQty = 0;
                            int nReqQty = 0;

                            /// New Code - Mr. Hrashid
                            if (oItemRow.Cells[6].Value == null || oItemRow.Cells[6].Value.ToString().Trim() == "")
                            {
                                nReqQty = 0;
                            }

                            else
                            {
                                nReqQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                            }

                            if (oItemRow.Cells[9].Value == null || oItemRow.Cells[9].Value.ToString().Trim() == "")
                            {
                                nConfirmQty = 0;
                            }

                            else
                            {
                                nConfirmQty = int.Parse(oItemRow.Cells[9].Value.ToString());
                            }

                            //if (oItemRow.Cells[6].Value != null || oItemRow.Cells[6].Value.ToString().Trim() != "")
                            //{
                            //    nReqQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                            //}

                            //else
                            //{
                            //    nReqQty = 0;

                            //}

                            //if (oItemRow.Cells[9].Value != null || oItemRow.Cells[9].Value.ToString().Trim() != "")
                            //{
                            //    nConfirmQty = int.Parse(oItemRow.Cells[9].Value.ToString());
                            //}


                            if (nConfirmQty > nReqQty)
                            {
                                oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                                DialogResult oResult = MessageBox.Show("Are you sure  Confirm This Order: " + sOrderNo + "? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (oResult == DialogResult.Yes)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                        }
                    }
                }
            }
            #endregion

            //#region Payment Collection Validation

            //foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            //{
            //    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
            //    {
                    
            //    }
            //}
            //#endregion

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        _oSalesOrder = new SalesOrder();
                        _oSalesOrder.Clear();
                        _oSalesOrder.OrderID = nOrderID;
                        _oSalesOrder = GetUIData(_oSalesOrder);
                        _oSalesOrder.Update();

                        if (_nUIControl == 2)
                        {

                            _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Confirmed;
                            _oSalesOrder.ConfirmUserID = Utility.UserId;
                            _oSalesOrder.ConfirmDate = DateTime.Today.Date;
                            _oSalesOrder.ConfirmStatus();

                            UpdateBookingStock(_oSalesOrder);
                            InsertSalesOrderPromo(_oSalesOrder.OrderID);
                        }




                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update Sales Order # " + sOrderNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _oSalesOrder = new SalesOrder();

                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oSalesOrder = new SalesOrder();
                        _oSalesOrder = GetUIData(_oSalesOrder);
                        _oSalesOrder.Insert(false);
                        _oSalesOrder.CheckOrderNo(_oSalesOrder.OrderNo);
                        if (_oSalesOrder.Flag != true)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Duplicate order no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            DBController.Instance.CommitTran();
                            MessageBox.Show("Successfully Add Sales Order # " + _oSalesOrder.OrderNo.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        private void UpdateBookingStock(SalesOrder oSalesOrder)
        {
            foreach (SalesOrderItem oSOI in oSalesOrder)
            {
                int nQty = oSOI.ConfirmQuantity + oSOI.FreeQty;

                ProductStock oProductStock = new ProductStock();
                oProductStock.UpdateBookingStock(true, nQty, oSalesOrder.WarehouseID, oSOI.ProductID);

            }
        }
        private void InsertSalesOrderPromo(int nOrderID)
        {
            foreach (DataGridViewRow oItemProdRow in dvgFreeProduct.Rows)
            {
                if (dvgFreeProduct.Rows.Count > 0)
                {
                    if (oItemProdRow.Index < dvgFreeProduct.Rows.Count)
                    {
                        SalesOrderPromotion oSOP = new SalesOrderPromotion();
                        oSOP.OrderID = nOrderID;
                        oSOP.SalesPromotionID = int.Parse(oItemProdRow.Cells[5].Value.ToString());
                        oSOP.SlabID = int.Parse(oItemProdRow.Cells[6].Value.ToString());
                        oSOP.Type = (int)Dictionary.ProductOrAmountStatus.Product;
                        oSOP.DiscountAmount = 0;
                        oSOP.FreeProductID = int.Parse(oItemProdRow.Cells[4].Value.ToString());
                        oSOP.FreeQty = int.Parse(oItemProdRow.Cells[3].Value.ToString());
                        oSOP.Add();
                    }
                }
            }
        }
        public SalesOrder GetUIData(SalesOrder _oSalesOrder)
        {
            if (this.Tag == null)
            {
                _oSalesOrder.OrderDate = DateTime.Today;
            }
            else
            {
                _oSalesOrder.OrderDate = dOrderDate;
            }
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

            if (cmbSalesPerson.SelectedIndex != -1)
            {
                _oSalesOrder.SalesPersonID = _oEmployees[cmbSalesPerson.SelectedIndex].EmployeeID;
            }
            else _oSalesOrder.SalesPersonID = -1;

            _oSalesOrder.WarehouseID = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;
            if (cmbPromotion.Text != "" && _oSalesPromotions != null)
                _oSalesOrder.SalesPromotionID = _oSalesPromotions[cmbPromotion.SelectedIndex].SalesPromotionID;
            else _oSalesOrder.SalesPromotionID = -1;

            if (dtDDDate.Checked)
            {
                _oSalesOrder.DDDate = dtDDDate.Value.Date;
            }
            else
            {
                _oSalesOrder.DDDate = null;
            }
            _oSalesOrder.DDDetails = txtDDDetails.Text;
            _oSalesOrder.DDAmount = Convert.ToDouble(txtDDAmount.Text);
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
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                    ProvisionParam _oProvisionParam = new ProvisionParam();

                    _oSalesOrderItem.ProductID = int.Parse(oItemRow.Cells[16].Value.ToString());
                   // _oSalesOrderItem.UnitPrice = int.Parse(oItemRow.Cells[3].Value.ToString());
                    _oSalesOrderItem.UnitPrice =Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    _oSalesOrderItem.Quantity = int.Parse(oItemRow.Cells[8].Value.ToString());

                    //_oProvisionParam.GetProvisionParam(_oSalesOrderItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    if (_nUIControl == 1)
                    {
                        _oSalesOrderItem.ConfirmQuantity = 0;
                    }
                    else
                    {
                        if (oItemRow.Cells[9].Value != null)
                        {
                            _oSalesOrderItem.ConfirmQuantity = int.Parse(oItemRow.Cells[9].Value.ToString());
                        }
                        else
                        {
                            _oSalesOrderItem.ConfirmQuantity = 0;
                        }
                    }

                    _oSalesOrderItem.AdjustedDPAmount = Convert.ToDouble(oItemRow.Cells[17].Value);
                    _oSalesOrderItem.AdjustedTPAmount = Convert.ToDouble(oItemRow.Cells[18].Value);
                    _oSalesOrderItem.AdjustedPWAmount = Convert.ToDouble(oItemRow.Cells[19].Value);
                    ///Reson Info
                    try
                    {
                        _oSalesOrderItem.Reason = int.Parse(oItemRow.Cells[25].Value.ToString());
                    }
                    catch
                    {
                        _oSalesOrderItem.Reason = -1;
                    }
                    ///End Reson Info

                    _oSalesOrderItem.PromotionalDiscount = 0;


                    int nIsFreeProduct = 0;
                    int nFreeQty = 0;
                    if (_nUIControl != 1)
                    {
                        foreach (DataGridViewRow oItemProdRow in dvgFreeProduct.Rows)
                        {
                            if (oItemProdRow.Index < dvgFreeProduct.Rows.Count)
                            {
                                if (_oSalesOrderItem.ProductID == int.Parse(oItemProdRow.Cells[4].Value.ToString()))
                                {
                                    nIsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                    nFreeQty = nFreeQty + int.Parse(oItemProdRow.Cells[3].Value.ToString());
                                }

                            }
                        }
                    }
                    _oSalesOrderItem.IsFreeProduct = nIsFreeProduct;
                    _oSalesOrderItem.FreeQty = nFreeQty;


                    _oSalesOrder.Add(_oSalesOrderItem);

                }
            }

            #region Get Free/Promotional Product
            if (_nUIControl != 1)
            {
                if (dvgFreeProduct.Rows.Count > 0)
                {
                    
                    foreach (DataGridViewRow oItemRow in dvgFreeProduct.Rows)
                    {
                        int nCount = 0;

                        if (oItemRow.Index < dvgFreeProduct.Rows.Count)
                        {
                            foreach (DataGridViewRow oItemLineRow in dgvLineItem.Rows)
                            {
                                if (oItemLineRow.Index < dgvLineItem.Rows.Count - 1)
                                {
                                    if (int.Parse(oItemRow.Cells[4].Value.ToString()) == int.Parse(oItemLineRow.Cells[16].Value.ToString()))
                                    {
                                        nCount++;
                                    }

                                }
                            }
                            if (nCount == 0)
                            {

                                SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                                _oSalesOrderItem.ProductID = int.Parse(oItemRow.Cells[4].Value.ToString());


                                string sProductCode = oItemRow.Cells[1].Value.ToString();

                                _oProductDetail = new ProductDetail();
                                _oProductDetail.ProductCode = sProductCode;
                                _oProductDetail.RefreshByCode();

                                if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                                {
                                    _oSalesOrderItem.UnitPrice = Convert.ToDouble(_oProductDetail.NSP);
                                }
                                else
                                {
                                    _oSalesOrderItem.UnitPrice = Convert.ToDouble(_oProductDetail.RSP);
                                }

                                _oSalesOrderItem.Quantity = 0;

                                _oSalesOrderItem.ConfirmQuantity = 0;

                                _oSalesOrderItem.AdjustedDPAmount = 0;
                                _oSalesOrderItem.AdjustedTPAmount = 0;
                                _oSalesOrderItem.AdjustedPWAmount = 0;


                                _oSalesOrderItem.PromotionalDiscount = 0;


                                _oSalesOrderItem.IsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                _oSalesOrderItem.FreeQty = int.Parse(oItemRow.Cells[3].Value.ToString());


                                _oSalesOrder.Add(_oSalesOrderItem);


                            }
                        }

                    }
                }
            }
            #endregion

            //if (_oSalesOrder.SalesPromotionID != -1)
            //{
            //    foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
            //    {
            //        ProvisionParam _oProvisionParam = new ProvisionParam();
            //        if (_oProvisionParam.GetFreeProduct(oSalesOrderItem.ProductID, _oSalesOrder.SalesPromotionID))
            //        {
            //            if (IsOrderProduct(_oSalesOrder, _oProvisionParam.FreeProductID))
            //            {
            //                oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount * oSalesOrderItem.Quantity;
            //                oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;
            //            }
            //            else
            //            {
            //                SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

            //                _oSalesOrderItem.ProductID = _oProvisionParam.FreeProductID;
            //                _oSalesOrderItem.UnitPrice = 0;
            //                _oSalesOrderItem.Quantity = 0;
            //                _oSalesOrderItem.ConfirmQuantity = 0;
            //                _oSalesOrderItem.AdjustedDPAmount = 0;
            //                _oSalesOrderItem.AdjustedPWAmount = 0;
            //                _oSalesOrderItem.AdjustedTPAmount = 0;
            //                _oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount * oSalesOrderItem.Quantity;
            //                _oSalesOrderItem.IsFreeProduct = 1;
            //                _oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;

            //                _oSalesOrder.Add(_oSalesOrderItem);
            //            }
            //        }
            //    }
            //}

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
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;

                oLib = new TELLib();
                txtSPDiscountTotal.Text = "0.00";
                txtSPTotalQty.Text = "0";

                dvgFreeProduct.Rows.Clear();
                dgvSPDiscount.Rows.Clear();

                CalculatePromotionNonSlab(_oCustomerDetail.ChannelID, _oCustomerDetail.CustomerTypeID);
                GetFreeProductTotal();

            }

        }
        public void CalculatePromotionNonSlab(int nChannelID, int nCustomerTypeID)
        {
            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[16].Value == null)
                    {
                        MessageBox.Show("Please Input Valied Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (oItemRow.Cells[16].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[16].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input Valied Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (oItemRow.Cells[16].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[9].Value.ToString().Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please Input valid Confirm Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (dgvLineItem.Rows.Count == 1)
            {
                dvgFreeProduct.Rows.Clear();
                dgvSPDiscount.Rows.Clear();
                return;
            }
            DBController.Instance.OpenNewConnection();
            oResultSPromotions = new SPromotions();
            oResultSPromotions = GetNonSlabPromotionResult(oResultSPromotions, nChannelID, nCustomerTypeID);

        }
        public SPromotions GetNonSlabPromotionResult(SPromotions oResultSPromotions, int nChannelID, int nCustomerTypeID)
        {
            bool _bFlag = true;
            int nCount = 0;
            int nRatioSet = 1;
            double _Amt = 0;
            double _TotalAmt = 0;
            int nOrderQty = 0;
            DBController.Instance.OpenNewConnection();
            oSPromotions = new SPromotions();
            oSPromotions.GetPromotion(DateTime.Today.Date);

            foreach (SPromotion oSPromotion in oSPromotions)
            {
                _bFlag = true;
                oResultSPromotion = new SPromotion();
                ///
                // Check Channel
                ///
                nCount = 0;
                foreach (SPChannel oSPChannel in oSPromotion.SPChannels)
                {
                    if (oSPChannel.ChannelID == nChannelID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Customer Type
                ///
                nCount = 0;
                foreach (SPCustomerType oSPCustomerType in oSPromotion.SPCustomerTypes)
                {
                    if (oSPCustomerType.CustTypeID == nCustomerTypeID)
                    {
                        nCount++;
                        break;
                    }
                }
                if (nCount == 0)
                {
                    _bFlag = false;
                    continue;
                }
                ///
                // Check Promotional Product
                ///

                nCount = 0;
                _Amt = 0;
                nOrderQty = 0;
                if (_bFlag == true)
                {
                    foreach (SPProductGroup oSPProductGroup in oSPromotion.SPProductGroups)
                    {
                        if (oSPromotion.SalesPromotionID == oSPProductGroup.SalesPromotionID)
                        {

                            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                            {
                                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                {
                                    int nProductID = 0;
                                    int nQty = 0;
                                    double _Amount = 0;


                                    nQty = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    //_Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                    nProductID = int.Parse(oItemRow.Cells[16].Value.ToString());
                                    _oProductDetail = new ProductDetail();
                                    _oProductDetail.Refresh(nProductID);

                                    if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.Product)
                                    {

                                        if (oSPProductGroup.ProductGroupID == int.Parse(oItemRow.Cells[16].Value.ToString()))
                                        {
                                            if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Product)
                                            {
                                                nOrderQty = nOrderQty + int.Parse(oItemRow.Cells[9].Value.ToString());
                                            }
                                            else
                                            {
                                                //_Amt = nQty * oSPProductGroup.DiscountPercentage;
                                            }
                                        }
                                    }
                                    //else
                                    //{
                                    //    if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.ProductGroup)
                                    //    {
                                    //        if (_oProductDetail.PGID == oSPProductGroup.ProductGroupID)
                                    //        {
                                    //            if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                    //            {
                                    //                _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                    //            }
                                    //            else
                                    //            {
                                    //                _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                    //            }
                                    //        }
                                    //    }
                                    //    else if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.MAG)
                                    //    {
                                    //        if (_oProductDetail.MAGID == oSPProductGroup.ProductGroupID)
                                    //        {
                                    //            if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                    //            {
                                    //                _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                    //            }
                                    //            else
                                    //            {
                                    //                _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                    //            }
                                    //        }
                                    //    }
                                    //    else if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.ASG)
                                    //    {
                                    //        if (_oProductDetail.ASGID == oSPProductGroup.ProductGroupID)
                                    //        {
                                    //            if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                    //            {
                                    //                _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                    //            }
                                    //            else
                                    //            {
                                    //                _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                    //            }
                                    //        }
                                    //    }
                                    //    else if (oSPProductGroup.ProductGroupType == (int)Dictionary.ProductGroupType.AG)
                                    //    {
                                    //        if (_oProductDetail.AGID == oSPProductGroup.ProductGroupID)
                                    //        {
                                    //            if (oSPProductGroup.DiscountType == (int)Dictionary.SalesPromotionDiscountType.Percent)
                                    //            {
                                    //                _Amt = _Amt + (((nQty * _Amount) / 100) * oSPProductGroup.DiscountPercentage);
                                    //            }
                                    //            else
                                    //            {
                                    //                _Amt = nQty * oSPProductGroup.DiscountPercentage;
                                    //            }
                                    //        }
                                    //    }
                                    //}

                                    nCount++;
                                }

                            }
                        }


                    }
                }

                if (nOrderQty > 0)
                {

                    SPForQty oSPForQty = new SPForQty();
                    oSPForQty.Refresh(oSPromotion.SalesPromotionID);

                    int nRatio = Convert.ToInt32(nOrderQty / oSPForQty.Qty);
                    SPromotion oSP = new SPromotion();

                    SPFreeProducts oSPFPs = new SPFreeProducts();
                    int nCPSID = oSP.GetCPSID(oSPromotion.SalesPromotionID);
                    oSPFPs.Refresh(nCPSID);

                    foreach (SPFreeProduct oSPFP in oSPFPs)
                    {
                        int nFreeQty = 0;
                        nFreeQty = oSPFP.Qty * nRatio;
                        InsertFreeProduct(oSPromotion.SalesPromotionNo, oSPFP.ProductCode, oSPFP.ProductName, nFreeQty, oSPFP.ProductID, oSPromotion.SalesPromotionID, nCPSID);
                    }

                }

                _TotalAmt = _TotalAmt + _Amt;
                if (_Amt > 0)
                {
                    //InsertDiscount(oSPromotion.SalesPromotionNo, oSPromotion.SalesPromotionID);
                }

            }
            //txtTotalDisount.Text = _TotalAmt.ToString();
            //GetNetAmount();
            return oResultSPromotions;
        }
        public void InsertFreeProduct(int nSPNo, string ProdCode, string ProdName,int ProdID, int Qty,int nSalesPromotionID, int nSalbID)
        {
            //oTELLib = new TELLib();
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dvgFreeProduct);
            oRow.Cells[0].Value = nSPNo;
            oRow.Cells[1].Value = ProdCode;
            oRow.Cells[2].Value = ProdName;
            oRow.Cells[3].Value = ProdID;
            oRow.Cells[4].Value = Qty;
            oRow.Cells[5].Value = nSalesPromotionID;
            oRow.Cells[6].Value = nSalbID;
            dvgFreeProduct.Rows.Add(oRow);
        }
        public void InsertDiscount(int nSalesPromotionID, int nSlabNo, double _Amount)
        {
            //oTELLib = new TELLib();
            //DataGridViewRow oRow = new DataGridViewRow();
            //oRow.CreateCells(dgvDiscount);
            //oRow.Cells[0].Value = nSalesPromotionID;
            //oRow.Cells[1].Value = nSlabNo;
            //oRow.Cells[2].Value = oTELLib.TakaFormat(_Amount);
            //dgvDiscount.Rows.Add(oRow);
        }
        public void DispalyPromotionResult(SPromotions oResultSPromotions)
        {
        //    ///
        //    // Result Display
        //    ///     
        //    int nCount = 0;
        //    int nGetComboSlabQty = 0;
        //    int nRatioSet = 1;
        //    double _Amount = 0;
        //    double _TotalAmt = 0;
        //    //dvgProduct.Rows.Clear();
        //    //dgvDiscount.Rows.Clear();
        //    //dgvPromoProduct.Rows.Clear();
        //    bool _bFlag = false;

        //    if (oResultSPromotions.Count > 0)
        //    {
        //        foreach (SPromotion oSPromotion in oResultSPromotions)
        //        {

        //            SPProduct _oSPProduct = new SPProduct();
        //            _oSPProduct.SalesPromotionID = oSPromotion.SalesPromotionID;


        //            foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
        //            {
        //                _oSPProduct.Refresh();
        //                _bFlag = _oSPProduct.Flag;

        //                if (_oSPProduct.Flag == true)
        //                {
        //                    nCount = NumberOfBonus(oSalesPromotionSlab);
        //                }
        //                else
        //                {
        //                    nCount = NumberOfBonus(oSalesPromotionSlab, oSPromotion);
        //                    //nGetComboSlabQty = GetComboSlabQty(oSPromotion.SalesPromotionID);
        //                }


        //                //if (oSalesPromotionSlab.SPFlatSlab.FlatAmount > 0)
        //                {
        //                    //ListViewItem lstItemAmount = lvwFlatAmount.Items.Add(oSPromotion.SalesPromotionNo.ToString());
        //                    //lstItemAmount.SubItems.Add(Convert.ToString(oSalesPromotionSlab.SPFlatSlab.FlatAmount * nCount));

        //                    //foreach (SalesPromotionSlab _oSalesPromotionSlab in oSPromotion)
        //                    //{
        //                    //    //nRatioSet = _oSalesPromotionSlab.RatioSet;

        //                    //}
        //                    if (_oSPProduct.Flag == true)
        //                    {
        //                        if (oSalesPromotionSlab.DiscountType != (int)Dictionary.SalesPromSlabDiscountType.None)
        //                        {
        //                            oTELLib = new TELLib();


        //                            oSPProducts = new SPProducts();
        //                            oSPProducts.Refresh(oSPromotion.SalesPromotionID);
        //                            int _nCount = 0;


        //                            foreach (SPProduct oSPProduct in oSPProducts)
        //                            {
        //                                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
        //                                {
        //                                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //                                    {
        //                                        if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
        //                                        {
        //                                            _nCount++;
        //                                            _TotalAmt = _TotalAmt + int.Parse(oItemRow.Cells[3].Value.ToString());


        //                                        }

        //                                    }
        //                                }

        //                            }
        //                            if (_nCount == oSPProducts.Count)
        //                            {
        //                                if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
        //                                {
        //                                    _Amount = _Amount + ((oSalesPromotionSlab.Discount) * nCount);
        //                                    InsertDiscount(oSPromotion.SalesPromotionID, 1, _Amount);
        //                                }
        //                                else if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.Parcent)
        //                                {
        //                                    _Amount = _Amount + ((oSalesPromotionSlab.Discount * _TotalAmt / 100) * nCount);
        //                                    InsertDiscount(oSPromotion.SalesPromotionID, 1, _Amount);
        //                                }
        //                            }
        //                            //txtTotalDisount.Text = oTELLib.TakaFormat(_Amount);
        //                            //txtPromoDiscount.Text = oTELLib.TakaFormat(_Amount);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (oSalesPromotionSlab.DiscountType != (int)Dictionary.SalesPromSlabDiscountType.None)
        //                        {
        //                            oSPProducts = new SPProducts();
        //                            oSPProducts.Refresh(oSPromotion.SalesPromotionID);

        //                            oTELLib = new TELLib();
        //                            foreach (SPProduct oSPProduct in oSPProducts)
        //                            {
        //                                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
        //                                {
        //                                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //                                    {
        //                                        if (oSPProduct.ProductID == int.Parse(oItemRow.Cells[9].Value.ToString()))
        //                                        {
        //                                            _oSPSlabAllRatio = new SPSlabAllRatio();
        //                                            _oSPSlabAllRatio.GetProductRatio(oSPromotion.SalesPromotionID, oSPProduct.ProductID, Convert.ToInt32(oItemRow.Cells[6].Value.ToString()));
        //                                            int nQty = int.Parse(oItemRow.Cells[6].Value.ToString());
        //                                            foreach (SPSlabRatio oSPSlabRatio in _oSPSlabAllRatio)
        //                                            {
        //                                                for (int i = nQty; oSPSlabRatio.Qty <= nQty; )
        //                                                {
        //                                                    if (oSPSlabRatio.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
        //                                                    {
        //                                                        _Amount = 0;
        //                                                        _Amount = _Amount + (oSPSlabRatio.Discount);
        //                                                        InsertDiscount(oSPromotion.SalesPromotionID, oSPSlabRatio.SlabNo, _Amount);
        //                                                    }
        //                                                    else if (oSPSlabRatio.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.Parcent)
        //                                                    {
        //                                                        _Amount = 0;
        //                                                        double nTotalAmount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) * oSPSlabRatio.Qty;
        //                                                        _Amount = _Amount + (oSPSlabRatio.Discount * nTotalAmount / 100);
        //                                                        InsertDiscount(oSPromotion.SalesPromotionID, oSPSlabRatio.SlabNo, _Amount);
        //                                                    }
        //                                                    nQty = nQty - oSPSlabRatio.Qty;
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            //if (_Amount > 0)
        //                            //{
        //                            //    txtTotalDisount.Text = oTELLib.TakaFormat(_Amount);
        //                            //    txtPromoDiscount.Text = oTELLib.TakaFormat(_Amount);
        //                            //}
        //                            if (dgvLineItem.Rows.Count == 1)
        //                            {
        //                                txtTotalDisount.Text = "0.00";
        //                                txtPromoDiscount.Text = "0.00";
        //                            }
        //                        }
        //                    }
        //                }
        //                foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
        //                {

        //                    _oProduct = new Product();
        //                    _oProduct.ProductID = oSPFreeProduct.ProductID;
        //                    _oProduct.RefreshByProductID();

        //                    DataGridViewRow oRow = new DataGridViewRow();
        //                    oRow.CreateCells(dvgProduct);
        //                    oRow.Cells[1].Value = oSPromotion.SalesPromotionNo;
        //                    oRow.Cells[2].Value = _oProduct.ProductCode;
        //                    oRow.Cells[3].Value = _oProduct.ProductName;

        //                    if (_oSPProduct.Flag == true)
        //                    {
        //                        oRow.Cells[4].Value = oSPFreeProduct.Qty * nCount;
        //                    }
        //                    else
        //                    {
        //                        int nQty = GetComboSlabQty(oSPromotion.SalesPromotionID, oSPFreeProduct.ProductID, oSalesPromotionSlab.SPFreeProducts);
        //                        oRow.Cells[4].Value = nQty * nCount;
        //                    }

        //                    oRow.Cells[7].Value = oSPFreeProduct.ProductID;
        //                    oRow.Cells[8].Value = _oProduct.ItemCategory;
        //                    oRow.Cells[9].Value = oSPromotion.SalesPromotionID;
        //                    oRow.Cells[10].Value = oSPFreeProduct.SlabNo;
        //                    oRow.Cells[11].Value = _oProduct.IsBarcodeItem;

        //                    int nRowIndex = dvgProduct.Rows.Add(oRow);

        //                }
        //                DispalyPromoProduct(oSPromotion.SalesPromotionID, oSPromotion.SalesPromotionNo.ToString(), nCount, _bFlag);

        //            }

        //        }



        //        if (nCount == 0)
        //        {
        //            dvgProduct.Rows.Clear();
        //            dgvDiscount.Rows.Clear();
        //            dgvPromoProduct.Rows.Clear();
        //        }
        //    }
        }
        private void txtTradeDiscount_TextChanged(object sender, EventArgs e)
        {
            NetTotal();
        }
        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalAmount();
        }

    }
}