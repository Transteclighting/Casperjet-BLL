using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Report;

namespace CJ.Win.Claim
{
    public partial class frmClaimImvoice : Form
    {
        ReplaceClaim oReplaceClaim;
        Customer _oCustomer;
        CustomerDetail _oCustomerDetail;
        Employees _oEmployees;
        ReplaceClaimStock oReplaceClaimStock;
        CustomerTransaction _oCustomerTransaction;
        ProvisionParam _oProvisionParam;
        ProvisionParam oProvisionParam;
        ProductDetail _oProductDetail;
        WUIUtility _oWUIUtility;
        ProductTransaction oProductTransaction;
        ReplaceClaimTran oReplaceClaimTran;

        public frmClaimImvoice()
        {
            InitializeComponent();
        }

        private void frmClaimImvoice_Load(object sender, EventArgs e)
        {

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
               
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.RSP)
            {
                lblAPO.Text = "RSP";
             
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
            {
                lblAPO.Text = "Special Price";
               
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Cost_Price)
            {
                lblAPO.Text = "Cost Price";
              
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Trade_Price)
            {
                lblAPO.Text = "Trade Price";
                
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
            txtDeliveryAdd.Text = _oCustomerDetail.CustomerAddress;

        }
        private void ctlClaims1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlClaims1.SelectedClaim != null && ctlClaims1.txtCode.Text != "")
            {
                _oCustomerDetail = new CustomerDetail();
                _oCustomerDetail.CustomerID = ctlClaims1.SelectedClaim.CustomerID;
                _oCustomerDetail.refresh();
                _oCustomer = new Customer();
                _oCustomer.CustomerID = ctlClaims1.SelectedClaim.CustomerID;
                _oCustomer.GetCustomerCreditLimit();
                SetUI(_oCustomerDetail);
                oReplaceClaim = new ReplaceClaim();
                oReplaceClaim=ctlClaims1.SelectedClaim;
                oReplaceClaim.ReplaceClaimID = ctlClaims1.SelectedClaim.ReplaceClaimID;
                oReplaceClaim.RefreshItem();

                foreach (ReplaceClaimItem oReplaceClaimItem in oReplaceClaim)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLineItem);
                    oRow.Cells[0].Value = oReplaceClaimItem.Product.ProductCode;
                    oRow.Cells[1].Value = oReplaceClaimItem.Product.ProductName;
                    oRow.Cells[2].Value = 0;
                    oRow.Cells[3].Value = oReplaceClaimItem.ClaimedQty;

                    oReplaceClaimStock = new ReplaceClaimStock();
                    oReplaceClaimStock.GetCurrentStock(Utility.ReengineeredWHID, oReplaceClaimItem.ProductID);
                    oRow.Cells[5].Value = oReplaceClaimStock.CurrentStock;

                    _oWUIUtility = new WUIUtility();
                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, Utility.ReplaceWHID, oReplaceClaimItem.ProductID);
                    oRow.Cells[7].Value = _oWUIUtility.CurrentStock;
                                    
                    oRow.Cells[8].Value = oReplaceClaimItem.ProductID.ToString();        
           
                    dgvLineItem.Rows.Add(oRow);
                }                
            
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Invoice Master Information Validation

            if (txtRefNo.Text == "")
            {
                txtRefNo.Focus();
                return false;
            }        

            #endregion

            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 0)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {                  
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[8].Value.ToString());
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
                        MessageBox.Show("Please Input Valied Reengineerd Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                        return false;
                    }
                    try
                    {
                        int temp = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valied Fresh Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    try
                    {
                        if (int.Parse(oItemRow.Cells[4].Value.ToString()) > int.Parse(oItemRow.Cells[5].Value.ToString()))
                        {
                            MessageBox.Show("Invoice quantity must equal or less than reengineerd stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valied Reengineerd Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) > int.Parse(oItemRow.Cells[7].Value.ToString()))
                        {
                            MessageBox.Show("Invoice quantity must equal or less than fresh stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valied Fresh Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    try
                    {
                        if (  (int.Parse(oItemRow.Cells[3].Value.ToString())) != (int.Parse(oItemRow.Cells[4].Value.ToString())+int.Parse(oItemRow.Cells[6].Value.ToString())))
                        {
                            MessageBox.Show("Invoice quantity must equal Claim stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (_oSalesInvoice.Count > 0)
                    {
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
                    }
                    oReplaceClaimTran = new ReplaceClaimTran();
                    oReplaceClaimTran = GetUIProductTransactionData(oReplaceClaimTran, _oSalesInvoice);

                    if (oReplaceClaimTran.CheckTranNo())
                    {
                        oReplaceClaimTran.Insert();

                        foreach (ReplaceClaimTranItem oReplaceClaimTranItem in oReplaceClaimTran)
                        {
                            if (oReplaceClaimTranItem.Quantity != 0)
                            {
                                ReplaceClaimStock oReplaceClaimStock = new ReplaceClaimStock();

                                oReplaceClaimStock.ProductID = oReplaceClaimTranItem.ProductID;
                                oReplaceClaimStock.Qty = oReplaceClaimTranItem.Quantity;
                                oReplaceClaimStock.WarehouseID = oReplaceClaimTran.FromWHID;
                                oReplaceClaimStock.UpdateCurrentStock(false);

                                if (oReplaceClaimStock.Flag == false)
                                {
                                    DBController.Instance.RollbackTransaction();
                                    MessageBox.Show("Stock can not be negative", "Error!!!");
                                    return;
                                }
                            }
                        }

                    }
                    PrintClaimInvoice(oReplaceClaim.ReplaceClaimID);
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
        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
        {
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = oReplaceClaim.CustomerID;
            _oCustomerDetail.refresh();

            _oSalesInvoice.RefDetails = txtRefNo.Text;
            _oSalesInvoice.InvoiceDate = dtInvoiceDate.Value.Date;
            _oSalesInvoice.CustomerID = oReplaceClaim.CustomerID;
            _oSalesInvoice.DeliveryAddress = txtDeliveryAdd.Text;
            if (_oEmployees[cmbSalesPerson.SelectedIndex].EmployeeID != 0)
                _oSalesInvoice.SalesPersonID = _oEmployees[cmbSalesPerson.SelectedIndex].EmployeeID;
            else _oSalesInvoice.SalesPersonID = 0;
            _oSalesInvoice.WarehouseID = Utility.ReplaceWHID;
            _oSalesInvoice.Remarks = txtRemarks.Text;
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.REPLACEMENT;
            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
            _oSalesInvoice.SalesPromotionID = -1;
            _oSalesInvoice.Discount = 0;
            _oSalesInvoice.InvoiceAmount = 0;

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                    _oProvisionParam = new ProvisionParam();

                    _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oSalesInvoiceItem.UnitPrice = 0;
                    _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[6].Value.ToString());
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                    _oProductDetail.Refresh();
                    _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                    _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                    if (_oSalesInvoiceItem.UnitPrice == 0)
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);

                    _oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    _oSalesInvoiceItem.AdjustedDPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesInvoiceItem.AdjustedPWAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesInvoiceItem.AdjustedTPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.TP;

                    _oSalesInvoiceItem.IsFreeProduct = 0;
                    _oSalesInvoiceItem.FreeQty = 0;

                    if (_oSalesInvoiceItem.Quantity != 0)
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
        public ReplaceClaimTran GetUIProductTransactionData(ReplaceClaimTran oReplaceClaimTran, SalesInvoice _oSalesInvoice)
        {
            oReplaceClaimTran.TranNo = _oSalesInvoice.RefDetails;
            oReplaceClaimTran.TranDate = dtInvoiceDate.Value.Date;
            oReplaceClaimTran.UserID = Utility.UserId;

            oReplaceClaimTran.TranTypeID = (int)Dictionary.ReplaceClaimStockTranType.INVOICE;
            oReplaceClaimTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            oReplaceClaimTran.FromWHID = Utility.ReengineeredWHID;

            oReplaceClaimTran.RefClaimID = oReplaceClaim.ReplaceClaimID;

            oReplaceClaimTran.RefInvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());

            oReplaceClaimTran.BatchNo = "";
            oReplaceClaimTran.Remarks = txtRemarks.Text;

            // Product Detail

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    ReplaceClaimTranItem oItem = new ReplaceClaimTranItem();

                    try
                    {
                        oItem.Quantity = Convert.ToInt16(oItemRow.Cells[4].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.Quantity = 0;
                    }
                    try
                    {
                        oItem.FGQty = Convert.ToInt16(oItemRow.Cells[6].Value.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        oItem.FGQty = 0;
                    }
                    oItem.ProductID = Convert.ToInt16(oItemRow.Cells[8].Value.ToString().Trim());


                    oReplaceClaimTran.Add(oItem);
                }
            }

            return oReplaceClaimTran;
        }
        public void PrintClaimInvoice(int nReplaceClaimID)
        {
            oReplaceClaim = new ReplaceClaim();
            oReplaceClaim.ReplaceClaimID = nReplaceClaimID;
            //oReplaceClaim.Refresh();

            oReplaceClaimTran = new ReplaceClaimTran();
            oReplaceClaimTran.RefClaimID = oReplaceClaim.ReplaceClaimID;
            oReplaceClaimTran.RefreshByClaim();
            oReplaceClaimTran.RefreshItem();

            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = oReplaceClaim.CustomerID;
            _oCustomerDetail.refresh();

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptReplaceClaimInvoice));

            doc.SetDataSource(oReplaceClaimTran);

            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
            doc.SetParameterValue("InvoiceNo", oReplaceClaim.ReplaceClaimNo);
            doc.SetParameterValue("InvoiceDate", oReplaceClaimTran.TranDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("InvoiceHeader", "Customer Copy");
            doc.SetParameterValue("CustomerName", _oCustomerDetail.CustomerName.ToString());
            doc.SetParameterValue("CustomerCode", _oCustomerDetail.CustomerCode.ToString());
            doc.SetParameterValue("CustomerAddress", _oCustomerDetail.CustomerAddress.ToString());
            doc.SetParameterValue("CustomerPhoneNo", _oCustomerDetail.CustomerPhoneNo.ToString());        
            doc.SetParameterValue("InvoiceAmount", "0");
            doc.SetParameterValue("Remarks", oReplaceClaimTran.Remarks);

            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(doc);


        }
    }
}