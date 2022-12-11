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

namespace CJ.Win.Distribution
{
    public partial class frmReplaceInvoice : Form
    {
        Customer _oCustomer;
        Product oProduct;
        CustomerDetail _oCustomerDetail;
        Employees _oEmployees;
        Warehouses _oWarehouses = new Warehouses();
        SalesPromotions _oSalesPromotions;
        ProvisionParam oProvisionParam;
        ProductDetail _oProductDetail;
        Users oUsers;
        WUIUtility _oWUIUtility;
        TELLib oLib;
        CustomerTransaction _oCustomerTransaction;
        ProvisionParam _oProvisionParam;



        int _nRowIndex = 0;
        double _nPriceOption;
        bool IsUpdate = false;
        bool bFlag = true;
        bool IsAlterMOQ = false;
        string _sFeildName;
        
        
        

        public frmReplaceInvoice()
        {
            InitializeComponent();
        }

        public void ShowDialog(SalesInvoice oSalesInvoice)
        {
            oSalesInvoice.RefreshSalesInvoiceItem();
            txtOrderNo.Text = oSalesInvoice.RefDetails;
            dtInvoiceDate.Value = Convert.ToDateTime(oSalesInvoice.InvoiceDate).Date;
            ctlCustomer1.txtCode.Text = oSalesInvoice.Customer.CustomerCode;
            cmbWarehouse.SelectedIndex = _oWarehouses.GetIndex(oSalesInvoice.WarehouseID);
            txtRemarks.Text = oSalesInvoice.Remarks;
            
            if (oSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
            {
                rdbClaim.Checked = true;
            }
            else if (oSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
            {
                rdbBreakage.Checked = true;
            }
            else rdoTradePromotion.Checked = true;

            foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                oRow.Cells[0].Value = oSalesInvoiceItem.Product.ProductCode;
                oRow.Cells[2].Value = oSalesInvoiceItem.Product.ProductName;
                oRow.Cells[3].Value = oSalesInvoiceItem.UnitPrice;
                oRow.Cells[4].Value = oSalesInvoiceItem.Quantity;
                oRow.Cells[5].Value = Convert.ToDouble(oSalesInvoiceItem.UnitPrice * oSalesInvoiceItem.Quantity).ToString();

                _oWUIUtility = new WUIUtility();
                _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oSalesInvoiceItem.ProductID);
                oRow.Cells[6].Value = _oWUIUtility.CurrentStock.ToString();

                oRow.Cells[7].Value = oSalesInvoiceItem.ProductID.ToString();
                oRow.Cells[0].ReadOnly = true;
                dgvLineItem.Rows.Add(oRow);

            }
            CalculateTotal();
            btSave.Visible = false;
            this.ShowDialog();
        }

        private void frmReplaceInvoice_Load(object sender, EventArgs e)
        {

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

           
            txtDeliveryAdd.Text = _oCustomerDetail.CustomerAddress;

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
                    oRow.Cells[3].Value = 0;     
                   
                    // oRow.Cells[3].Value = oForm._oProductDetail.NSP;    
          
                    oRow.Cells[7].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, oForm._oProductDetail.ProductID);
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
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (_oProductDetail.ProductID).ToString();
                        //  dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = 0;  // Old code 
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = (_oProductDetail.NSP).ToString();  // New Code by Dipak
                       

                        _oWUIUtility = new WUIUtility();
                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        if (_oWUIUtility.CurrentStock != 0)
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = _oWUIUtility.CurrentStock.ToString();
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
            else if (nColumnIndex == 4)
            {

             dgvLineItem.Rows[nRowIndex].Cells[5].Value = (Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString()));
            
             // New Code by Dipak

             CalculateTotal();          
             
            }

        }

        private void CalculateTotal()
        {           
            Double nTotalTaka = 0;
            Double nDBCom = 0;
            int nProductID = 0;
            oProvisionParam = new ProvisionParam();

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    nTotalTaka = nTotalTaka + (Convert.ToDouble(oItemRow.Cells[5].Value.ToString()));
                   // nProductID = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                    oProvisionParam.GetProvisionParam(Convert.ToInt32(oItemRow.Cells[7].Value.ToString()), _oCustomerDetail.CustomerTypeID);
                    nDBCom = nDBCom+((Convert.ToDouble(oItemRow.Cells[5].Value.ToString())) * (oProvisionParam.SC));

                }     
            }
            txtTotalTk.Text = (nTotalTaka).ToString();
            txtDBComm.Text = nDBCom.ToString();
            txtNetAmount.Text =Convert.ToString(nTotalTaka - nDBCom);
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

        private bool validateUIInput()
        {
            #region Invoice Master Information Validation

            if (txtOrderNo.Text.Trim() == "")
            {
                txtOrderNo.Focus();
                return false;
            }           
            if (ctlCustomer1.SelectedCustomer == null)
            {
                ctlCustomer1.Focus();
                return false;
            }
            if (_oWarehouses == null)
            {
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
                        int temp = int.Parse(oItemRow.Cells[7].Value.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                    if (oItemRow.Cells[2].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[7].Value.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[4].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valied Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        if (int.Parse(oItemRow.Cells[4].Value.ToString()) > int.Parse(oItemRow.Cells[6].Value.ToString()))
                        {
                            MessageBox.Show("Invoice quantity must equal or less than current stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valied Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    SalesInvoice _oSalesInvoice;
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice);
                    _oSalesInvoice.InsertForReplace();

                    ///
                    // Insert in Customer Transaction and Update Customer Account.
                    ///

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oSalesInvoice);
                    if (_oCustomerTransaction.CheckTranNo())
                        _oCustomerTransaction.AddTran(true);
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error...Tran no for customer transaction is invalied", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                        oProductStock.Quantity = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                        oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                        oProductStock.ChannelID = _oCustomerDetail.ChannelID;

                        oProductStock.Edit();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Make Invoice.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
        {
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oCustomerDetail.refresh();

            _oSalesInvoice.RefDetails = txtOrderNo.Text;
            _oSalesInvoice.InvoiceDate = dtInvoiceDate.Value.Date;
            _oSalesInvoice.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oSalesInvoice.DeliveryAddress = txtDeliveryAdd.Text;
            if (_oEmployees[cmbSalesPerson.SelectedIndex].EmployeeID != 0)
                _oSalesInvoice.SalesPersonID = _oEmployees[cmbSalesPerson.SelectedIndex].EmployeeID;
            else _oSalesInvoice.SalesPersonID = 0;
            _oSalesInvoice.WarehouseID = _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID;
            _oSalesInvoice.Remarks = txtRemarks.Text;

            if (rdbClaim.Checked == true)
            {
                _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.REPLACEMENT;
            }
            
            else if (rdbBreakage.Checked == true)
            {
             _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT;
            }

            else 
            {
                //(rdoTradePromotion.Checked = true)
                _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION;
            }

            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
            _oSalesInvoice.SalesPromotionID = -1;
            _oSalesInvoice.Discount = 0;
            _oSalesInvoice.InvoiceAmount = 0;

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                    _oProvisionParam = new ProvisionParam();

                    _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                    _oSalesInvoiceItem.UnitPrice = 0;
                    _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString());
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                    _oProductDetail.Refresh();
                    _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                    _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                    if (_oSalesInvoiceItem.UnitPrice == 0)
                        if(Utility.CompanyInfo=="BLL")
                        {
                            _oSalesInvoiceItem.TradePrice = Math.Round(_oProductDetail.TradePrice - (_oProductDetail.TradePrice * 0.075), 4); // For Zero Value Invoice- Code Modified by Hrashid 09-Apr-2022
                        }
                       /* _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice; */// Edit

                    else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);


                    _oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    _oSalesInvoiceItem.AdjustedDPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesInvoiceItem.AdjustedPWAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesInvoiceItem.AdjustedTPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.TP;                                 

                    _oSalesInvoiceItem.IsFreeProduct = 0;
                    _oSalesInvoiceItem.FreeQty = 0;

                    _oSalesInvoice.Add(_oSalesInvoiceItem);
                }
            }        
            
            return _oSalesInvoice;
        }    
        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE;

            return _oCustomerTransaction;
        }

        private void rdbClaim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbClaim.Checked == true)
            {
                rdbBreakage.Checked = false;
                rdoTradePromotion.Checked = false;
            }
        }

        private void rdbBreakage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBreakage.Checked == true)
            {
                rdbClaim.Checked = false;
                rdoTradePromotion.Checked = false;
            }
        }

        private void rdoTradePromotion_CheckedChanged(object sender, EventArgs e)
        {
            rdbClaim.Checked = false;
            rdbBreakage.Checked = false;
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();

        }
        
       
  
    }
}