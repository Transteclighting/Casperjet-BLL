// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jan 12, 2015
// Time :  10:00 AM
// Description: Sales Order Module.
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
using CJ.Report;
using CJ.Class.Library;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.Distribution
{


    public partial class frmOrders : Form
    {

        public int Pricecheck=0;

        SalesOrders oSalesOrders;
        Utilities _oUtilitys;
        DSOrderItem oDSOrderItem;
        DSOrderItem oDSFreeQty;
        TELLib _oTELLib;
        int _nUIControl = 0;
        CustomerTransaction _oCustomerTransaction;
        ProvisionParam _oProvisionParam;
        ProductDetail _oProductDetail;
        CustomerDetail _oCustomerDetail; 

        public frmOrders(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            if (_nUIControl == 1)
            {
                this.Text = "Sales Orders";
                btnConfirmOrder.Visible = false;
                btnSendToInvoice.Visible = false;
            }
            else if (_nUIControl == 2)
            {
                this.Text = "Confirm Orders";
                btnConfirmOrder.Visible = true;
                btnAdd.Visible = false;
                btnEditOrder.Visible = false;
                btndelete.Visible = false;
                btnSendToInvoice.Visible = false;
            }
            else
            {
                this.Text = "Credit Invoice Control";
                btnConfirmOrder.Visible = false;
                btnAdd.Visible = false;
                btnEditOrder.Visible = false;
                btndelete.Visible = false;
                btnSendToInvoice.Visible = true;
            }

            _oUtilitys = new Utilities();
            cmbSatus.Items.Clear();
            _oUtilitys.GetOrderStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                cmbSatus.Items.Add(oUtility.Satus);
            }
            cmbSatus.SelectedIndex = 0;
            Refresh();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Refresh();
            this.Cursor = Cursors.Default;
        }
        private void Refresh()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSalesOrders = new SalesOrders();
            oSalesOrders.GetAllData(dtFromDate.Value.Date, dtToDate.Value.Date,txtOrderNo.Text, _oUtilitys[cmbSatus.SelectedIndex].SatusId,txtCustomerCode.Text,txtCustomerName.Text);
            lvwOrderList.Items.Clear();

            foreach (SalesOrder oSalesOrder in oSalesOrders)
            {
                if (oSalesOrder.Customer.CustomerCode != null)
                {
                    ListViewItem lstItem = lvwOrderList.Items.Add(oSalesOrder.OrderNo.ToString());
                    lstItem.SubItems.Add(oSalesOrder.CustomerDetail.CustomerCode);
                    lstItem.SubItems.Add(oSalesOrder.CustomerDetail.CustomerName);
                    lstItem.SubItems.Add(oSalesOrder.CustomerDetail.ParentCustomerName);
                    lstItem.SubItems.Add(Convert.ToDateTime(oSalesOrder.OrderDate).ToString("dd-MMM-yyyy"));
                    lstItem.SubItems.Add(oSalesOrder.CreateUser.Username);
                    lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.OrderStatus), oSalesOrder.OrderStatus));
                    lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.OrderType), oSalesOrder.OrderTypeID));
                    lstItem.Tag = oSalesOrder;
                }
            }
            this.Text = "Total Sales Order  " + "[" + oSalesOrders.Count + "]";
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[6].Text == Dictionary.OrderStatus.Received.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.OrderStatus.Confirmed.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 255);
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.OrderStatus.Invoiced.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.OrderStatus.Canceled.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    else
                    {
                        oItem.BackColor = Color.SeaGreen;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOrder ofrmOrder = new frmOrder(1);
            ofrmOrder.ShowDialog();
            Refresh();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrder oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;
            if (oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                frmOrder ofrmOrder = new frmOrder(1);
                ofrmOrder.ShowDialog(oSalesOrder);
                Refresh();
            }
            else
            {
                MessageBox.Show("Only Received order can be Edited ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrder oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;
            if (oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                frmOrder ofrmOrder = new frmOrder(2);
                ofrmOrder.ShowDialog(oSalesOrder);
                Refresh();
            }
            else
            {
                MessageBox.Show("Only Received order can be Confirmed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrintSalesOrder_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrder oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;
            oDSOrderItem = new DSOrderItem();
            oDSFreeQty = new DSOrderItem();
            SalesOrder _oSalesOrder = new SalesOrder();
            _oSalesOrder.Refresh(oSalesOrder.OrderID);

            SalesOrder oSO = new SalesOrder();
            oSO.OrderID = oSalesOrder.OrderID;
            oSO.RefreshOrderItem(oSalesOrder.OrderStatus);
            double _NetAmountTotal = 0;
            _oTELLib = new TELLib();

            string CreateUser = "";
            string ConfirmUser = "";
            long nRem = 0;
            long nQuotient = 0;

            User oUser = new User();
            if (_oSalesOrder.CreateUserID != null)
            {
                oUser.UserId = _oSalesOrder.CreateUserID;
                oUser.RefreshByUserID();
                CreateUser = oUser.Username;
            }
            if (_oSalesOrder.ConfirmUserID != null)
            {
                oUser.UserId = _oSalesOrder.ConfirmUserID;
                oUser.RefreshByUserID();
                ConfirmUser = oUser.Username;
            }

            foreach (SalesOrderItem oSalesOrderItem in oSO)
            {

                DSOrderItem.OrderItemRow oOrderItemRow = oDSOrderItem.OrderItem.NewOrderItemRow();

                oOrderItemRow.ProductCode = oSalesOrderItem.Product.ProductCode;
                oOrderItemRow.ProductName = oSalesOrderItem.Product.ProductName;
                oOrderItemRow.UOM = oSalesOrderItem.Product.SmallUnitOfMeasure;
                oOrderItemRow.UnitPrice = oSalesOrderItem.UnitPrice;
                oOrderItemRow.OrderQty = oSalesOrderItem.Quantity;
                oOrderItemRow.ConfirmQty = oSalesOrderItem.ConfirmQuantity;
                oOrderItemRow.GrossAmt = oSalesOrderItem.GrossAmount;

                nQuotient = Math.DivRem((int)oSalesOrderItem.Quantity, (int)oSalesOrderItem.Product.UOMConversionFactor, out nRem);
                oOrderItemRow.PackQty = (int)nQuotient;

                ProvisionParam oProvisionParam = new ProvisionParam();
                oProvisionParam.GetProvisionParam(oSalesOrderItem.Product.ProductID, _oSalesOrder.CustomerDetail.CustomerTypeID);

                if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed || _oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Invoiced)
                {
                    oOrderItemRow.DP = oSalesOrderItem.UnitPrice * oProvisionParam.SC * oSalesOrderItem.ConfirmQuantity;
                    oOrderItemRow.TP = oSalesOrderItem.UnitPrice * oProvisionParam.TP * oSalesOrderItem.ConfirmQuantity;
                    oOrderItemRow.PW = oSalesOrderItem.UnitPrice * oProvisionParam.PW * oSalesOrderItem.ConfirmQuantity;
                }
                else
                {
                    oOrderItemRow.DP = oSalesOrderItem.UnitPrice * oProvisionParam.SC * oSalesOrderItem.Quantity;
                    oOrderItemRow.TP = oSalesOrderItem.UnitPrice * oProvisionParam.TP * oSalesOrderItem.Quantity;
                    oOrderItemRow.PW = oSalesOrderItem.UnitPrice * oProvisionParam.PW * oSalesOrderItem.Quantity;
                }
                oOrderItemRow.NetAmt = oOrderItemRow.GrossAmt - (oOrderItemRow.DP + oOrderItemRow.TP + oOrderItemRow.PW);
                _NetAmountTotal = _NetAmountTotal + oOrderItemRow.NetAmt;

                oDSOrderItem.OrderItem.AddOrderItemRow(oOrderItemRow);
                oDSOrderItem.AcceptChanges();
            
            }

            //free Qty

            SalesOrder oSOFree = new SalesOrder();
            oSOFree.OrderID = oSalesOrder.OrderID;
            oSOFree.RefreshFreeQty();
            bool IsFree = false;
            foreach (SalesOrderItem oSalesOrderItem in oSOFree)
            {
                DSOrderItem.FreeQtyRow oFreeQtyRow = oDSFreeQty.FreeQty.NewFreeQtyRow();

                oFreeQtyRow.ProductCode = oSalesOrderItem.Product.ProductCode;
                oFreeQtyRow.ProductName = oSalesOrderItem.Product.ProductName;
                oFreeQtyRow.FreeQty = oSalesOrderItem.FreeQty;

                oDSFreeQty.FreeQty.AddFreeQtyRow(oFreeQtyRow);
                oDSFreeQty.AcceptChanges();
                IsFree = true;
            }

            oDSOrderItem.Merge(oDSFreeQty);
            oDSOrderItem.AcceptChanges();

            rptSalesOrderAutoPrintBLL doc = new rptSalesOrderAutoPrintBLL();
            doc.SetDataSource(oDSOrderItem);
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed)
            {
                doc.SetParameterValue("OrderStatus", "Confirmed Order");
            }
            else if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Invoiced)
            {
                doc.SetParameterValue("OrderStatus", "Invoiced Order");
            }
            else if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Pending)
            {
                doc.SetParameterValue("OrderStatus", "Pending Order");
            }
            else if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                doc.SetParameterValue("OrderStatus", "Received Order");
            }
            else if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Reject_Due_To_Less_Credit)
            {
                doc.SetParameterValue("OrderStatus", "Rejected Order");
            }
            else
            {
                doc.SetParameterValue("OrderStatus", "Cancelled Order");
            }
            doc.SetParameterValue("OrderNo", _oSalesOrder.OrderNo);
            if (_oSalesOrder.OrderTypeID == (int)Dictionary.OrderType.CASH)
            {
                doc.SetParameterValue("OrderType", "CASH ORDER");
            }
            else
            {
                doc.SetParameterValue("OrderType", "CREDIT ORDER");
            }

            doc.SetParameterValue("CustomerCode", _oSalesOrder.CustomerDetail.CustomerCode);
            doc.SetParameterValue("CustomerName", _oSalesOrder.CustomerDetail.CustomerName);
            doc.SetParameterValue("CustomerAddress", _oSalesOrder.CustomerDetail.CustomerAddress);
            doc.SetParameterValue("CustomerPhoneNo", _oSalesOrder.CustomerDetail.CustomerPhoneNo);

            doc.SetParameterValue("OrderDate", Convert.ToDateTime(_oSalesOrder.OrderDate).ToString("dd-MMM-yyyy"));
            if (_oSalesOrder.ConfirmDate != null)
                doc.SetParameterValue("ConfirmOrderDate", Convert.ToDateTime(_oSalesOrder.ConfirmDate).ToString("dd-MMM-yyyy"));
            else doc.SetParameterValue("ConfirmOrderDate", "");
            doc.SetParameterValue("CategoryName", _oSalesOrder.CustomerDetail.CustomerTypeName);
            doc.SetParameterValue("Area", _oSalesOrder.CustomerDetail.AreaName);
            doc.SetParameterValue("Territory", _oSalesOrder.CustomerDetail.TerritoryName);
            doc.SetParameterValue("Thana", _oSalesOrder.CustomerDetail.ThanaName);
            doc.SetParameterValue("District", _oSalesOrder.CustomerDetail.DistrictName);

            doc.SetParameterValue("WarehouseCode", _oSalesOrder.Warehouse.WarehouseName + "[" + _oSalesOrder.Warehouse.WarehouseCode + "]");
            doc.SetParameterValue("Discount", _oTELLib.TakaFormat(_oSalesOrder.Discount));
            doc.SetParameterValue("OrderAmount", _oTELLib.TakaFormat(_NetAmountTotal - _oSalesOrder.Discount));
            doc.SetParameterValue("AmountInWord", _oTELLib.TakaWords(_NetAmountTotal - _oSalesOrder.Discount));
            doc.SetParameterValue("Remarks", _oSalesOrder.Remarks);
            doc.SetParameterValue("DDAmount", _oTELLib.TakaFormat(_oSalesOrder.DDAmount));
            if (_oSalesOrder.DDDate != DBNull.Value)
                doc.SetParameterValue("DDDate", Convert.ToDateTime(_oSalesOrder.DDDate).ToString("dd-MMM-yyyy"));
            else doc.SetParameterValue("DDDate", "");
            doc.SetParameterValue("DDDetails", _oSalesOrder.DDDetails);
            doc.SetParameterValue("OrderBy", CreateUser);
            doc.SetParameterValue("OrderConfirmBy", ConfirmUser);
            doc.SetParameterValue("IsFree", IsFree);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }

        private void btnSendToInvoice_Click(object sender, EventArgs e)
        {

            if (lvwOrderList.SelectedItems.Count == 0)

            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // new Code by Humayun
            SalesOrder oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;
          
             
            if (oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed && oSalesOrder.OrderTypeID == (int)Dictionary.OrderType.CREDIT)
            {
                if (oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed)
                {
                    DialogResult oResult = MessageBox.Show("Are you sure you want to send the Order No: " + oSalesOrder.OrderNo + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oResult == DialogResult.Yes)
                    {
                        SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();
                        SalesInvoice _oSalesInvoice;
                        _oSalesInvoice = new SalesInvoice();
                        _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oSalesOrder);



                        try
                        {
                            if (Utility.CompanyInfo == "BLL")
                            {
                               _oSalesInvoiceItem = new SalesInvoiceItem();
                                if (Pricecheck==0)
                                {
                                    MessageBox.Show("Code=" + _oProductDetail.ProductCode + " & Product Name=" + _oProductDetail.ProductName + " \nThis Product Price is out of VAT approved limit. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                else
                                {

                                    if (CheckReleasePermission(oSalesOrder.CustomerID, oSalesOrder.OrderID, _oSalesInvoice.InvoiceAmount))  // New code by Dipak date: 29-Jun-16
                                    {


                                            DBController.Instance.BeginNewTransaction();
                                            oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Invoiced;
                                            oSalesOrder.UpdateStatus();
                                            _oSalesInvoice.InsertInvoice();
                                            _oCustomerTransaction = new CustomerTransaction();
                                            _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, oSalesOrder, _oSalesInvoice);

                                            if (_oCustomerTransaction.CheckTranNo())
                                                _oCustomerTransaction.AddTran(true);
                                            else
                                            {
                                                DBController.Instance.RollbackTransaction();
                                                MessageBox.Show("Error...Tran no for customer transaction is invalied", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }

                                            DBController.Instance.CommitTransaction();
                                            MessageBox.Show("Successfully Send to Invoice.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Refresh();


                                    }
                                    else
                                    {
                                        MessageBox.Show(" You Have not Enough Limit to Release the Order  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                            }

                            else
                            {

                                if (CheckReleasePermission(oSalesOrder.CustomerID, oSalesOrder.OrderID, _oSalesInvoice.InvoiceAmount))  // New code by Dipak date: 29-Jun-16
                                {
                                    DBController.Instance.BeginNewTransaction();
                                    oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Invoiced;
                                    oSalesOrder.UpdateStatus();
                                    _oSalesInvoice.InsertInvoice();
                                    _oCustomerTransaction = new CustomerTransaction();
                                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, oSalesOrder, _oSalesInvoice);



                                    if (_oCustomerTransaction.CheckTranNo())
                                        _oCustomerTransaction.AddTran(true);
                                    else
                                    {
                                        DBController.Instance.RollbackTransaction();
                                        MessageBox.Show("Error...Tran no for customer transaction is invalied", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    DBController.Instance.CommitTransaction();
                                    MessageBox.Show("Successfully Send to Invoice.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Refresh();
                                }
                                else
                                {
                                    MessageBox.Show(" You Have not Enough Limit to Release the Order  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                        }



                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            return;
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Only Confirm Credit Order can be sent.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private bool CheckReleasePermission(int nCustID, int nOrderID,double _Invoiceamount)
        {
            _oCustomerTransaction = new CustomerTransaction();         
            CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();

            oCustomerCreditLimit.GetReleaseLimit(Utility.UserId);
            oCustomerCreditLimit.GetCurrentBalance(nCustID);

            

            if ((oCustomerCreditLimit.Currentbalance + _Invoiceamount) <= (oCustomerCreditLimit.MaxCreditLimit+ oCustomerCreditLimit.BGAmount))
            {
                return true;
            }

            else if ((oCustomerCreditLimit.Currentbalance + _Invoiceamount) <= oCustomerCreditLimit.UserLimitAm)
            {
                return true;
            }
            else
            {                
                return false;
            }
                     

            return false;
               
        }

        //private bool CheckVATUpperLimit(SalesOrder _oSalesOrder, int nCustID, int nOrderID, double _Invoiceamount)
        //{
        //    _oCustomerTransaction = new CustomerTransaction();
        //    CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();

        //    oCustomerCreditLimit.GetReleaseLimit(Utility.UserId);
        //    oCustomerCreditLimit.GetCurrentBalance(nCustID);

        //    SalesInvoice _oSalesInvoice;
        //    _oSalesInvoice = new SalesInvoice();

        //    _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, _oSalesOrder);

        //    foreach (SalesInvoice oItem in _oSalesInvoice)
        //    {
        //        SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

        //        int nCustomerTypeID = _oCustomerDetail.CustomerTypeID;
        //        oCustomerCreditLimit.GetReleaseLimit(Utility.UserId);

    

        //        _oProductDetail = new ProductDetail();
        //        _oProductDetail.ProductID = oItem.ProductID;
        //        _oProductDetail.GetProductWithProvision(oItem.ProductID, nCustomerTypeID);
        //        _oSalesInvoiceItem.CalculativeTradePrice = oItem.TradePrice;
        //        //_oSalesInvoiceItem.VATUpperLimit = oItem.VATUpperLimit;
        //        //_oSalesInvoiceItem.VATLowerLimit = oItem.VATLowerLimit;




        //        //Double CalTP = Math.Round(((oItem.UnitPrice - _oProductDetail.DP) / ((_oProductDetail.Vat * 100) + 100)) * 100, 4);
        //        //Double CalLL = Math.Round(_oProductDetail.TradePrice - (_oProductDetail.TradePrice * 0.075), 4);
        //        //Double CalUL = Math.Round(_oProductDetail.TradePrice + (_oProductDetail.TradePrice * 0.075), 4);

        //        if(_oSalesInvoiceItem.CalculativeTradePrice > _oSalesInvoiceItem.VATUpperLimit && (oCustomerCreditLimit.Currentbalance + _Invoiceamount) <= (oCustomerCreditLimit.MaxCreditLimit + oCustomerCreditLimit.BGAmount))
        //        {
        //            return true;
        //        }

        //        else if (_oSalesInvoiceItem.CalculativeTradePrice > _oSalesInvoiceItem.VATUpperLimit && (oCustomerCreditLimit.Currentbalance + _Invoiceamount) <= oCustomerCreditLimit.UserLimitAm)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }


              

        //        //if (CalTP > CalUL && Utility.UserId != 445)
        //        //{
        //        //    //MessageBox.Show("Unit Price is more than VAT Approval  .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //    return false;
        //        //}

        //        //else 
        //        //{
        //        //    return true;
        //        //}


        //    }

        //       return false; ;

        //}

        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice, SalesOrder _oSalesOrder)
        {
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = _oSalesOrder.CustomerID;
            _oCustomerDetail.refresh();
            int nCustomerTypeID = _oCustomerDetail.CustomerTypeID;

            _oSalesInvoice.OrderNo = _oSalesOrder.OrderNo.ToString();
            _oSalesInvoice.CustomerID = _oSalesOrder.CustomerID;
            _oSalesInvoice.DeliveryAddress = _oSalesOrder.DeliveryAddress;
            _oSalesInvoice.SalesPersonID = _oSalesOrder.SalesPromotionID;
            _oSalesInvoice.WarehouseID = _oSalesOrder.WarehouseID;
            _oSalesInvoice.Remarks = _oSalesOrder.Remarks;
            _oSalesInvoice.OrderID = _oSalesOrder.OrderID;
            if (_oSalesOrder.OrderTypeID == (int)Dictionary.OrderType.CASH)
            {
                _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CASH;
            }
            else
            {
                _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CREDIT;
            }
            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
            _oSalesInvoice.SalesPromotionID = _oSalesOrder.SalesPromotionID;

            _oSalesInvoice.Discount = _oSalesOrder.Discount;
            _oSalesOrder.RefreshItem();
            _oSalesInvoice.InvoiceAmount = GetInvoiceAmount(_oSalesOrder, nCustomerTypeID);


            _oCustomerTransaction = new CustomerTransaction();
            CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();

            oCustomerCreditLimit.GetReleaseLimit(Utility.UserId);
            //oCustomerCreditLimit.GetCurrentBalance(nCustID);

            foreach (SalesOrderItem oItem in _oSalesOrder)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oSalesInvoiceItem.ProductID = oItem.ProductID;
                _oSalesInvoiceItem.UnitPrice = oItem.UnitPrice;
                _oSalesInvoiceItem.Quantity = oItem.ConfirmQuantity;
              
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                _oProductDetail.GetProductWithProvision(_oSalesInvoiceItem.ProductID, nCustomerTypeID);
                _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;


                if (Utility.CompanyInfo == "TEL")
                {

                    if (_oSalesInvoiceItem.UnitPrice == 0)
                    {
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    }
                    else
                    {
                        TPVATProduct _oTPVATProduct = new TPVATProduct();
                        if (_oTPVATProduct.IsProductExists(_oSalesInvoiceItem.ProductID))
                        {
                            _oSalesInvoiceItem.TradePrice = _oTPVATProduct.TradePrice;
                            

                        }
                        else
                        {
                            _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);
                        }
                    }
                }
                else
                {  // For BLL Code modified by Humayun

                    if (_oSalesInvoiceItem.UnitPrice == 0) // for Zero Value invoice
                    {
                       // _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;                         
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice - (_oProductDetail.TradePrice * 0.075); // New Add 04-apr-2022 by Hrashid
                    }
                    else
                    {
                        // New Code  by Humayun
                        
                        _oSalesInvoiceItem.CalculativeTradePrice = Math.Round(((_oSalesInvoiceItem.UnitPrice- _oProductDetail.DP)/ ((_oProductDetail.Vat * 100) + 100))*100,4);
                        _oSalesInvoiceItem.VATLowerLimit = Math.Round(_oProductDetail.TradePrice - (_oProductDetail.TradePrice * 0.075),4);
                        _oSalesInvoiceItem.VATUpperLimit = Math.Round(_oProductDetail.TradePrice + (_oProductDetail.TradePrice * 0.075),4);

                        if (_oSalesInvoiceItem.CalculativeTradePrice <= _oSalesInvoiceItem.VATLowerLimit)
                        {
                            _oSalesInvoiceItem.TradePrice = _oSalesInvoiceItem.VATLowerLimit;
                            Pricecheck = 1;
                        }
                        if (_oSalesInvoiceItem.CalculativeTradePrice >= _oSalesInvoiceItem.VATLowerLimit && _oSalesInvoiceItem.CalculativeTradePrice <= _oSalesInvoiceItem.VATUpperLimit)
                        {
                            _oSalesInvoiceItem.TradePrice = _oSalesInvoiceItem.CalculativeTradePrice;
                            Pricecheck = 1;
                        }

                        if (_oSalesInvoiceItem.CalculativeTradePrice > _oSalesInvoiceItem.VATUpperLimit && Utility.UserId==445)
                        {
                            _oSalesInvoiceItem.TradePrice = _oSalesInvoiceItem.CalculativeTradePrice;
                            Pricecheck = 1;
                        }

                        //else
                        //{
                        //    MessageBox.Show("Code=" + _oProductDetail.ProductCode + " & Product Name=" + _oProductDetail.ProductName + " \nThis Product Price is out of VAT approved limit. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    break;
                            
                        //}


                        // Old Code modified on 4 Apr 22
                        // _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);
                    }
                }

                _oSalesInvoiceItem.AdjustedDPAmount = _oProductDetail.DP;
                _oSalesInvoiceItem.AdjustedPWAmount = _oProductDetail.PW;
                _oSalesInvoiceItem.AdjustedTPAmount = _oProductDetail.TP;

                _oSalesInvoiceItem.PromotionalDiscount = oItem.PromotionalDiscount;

                _oSalesInvoiceItem.IsFreeProduct = oItem.IsFreeProduct;
                _oSalesInvoiceItem.FreeQty = oItem.FreeQty;

            

                _oSalesInvoice.Add(_oSalesInvoiceItem);
            }
            
            return _oSalesInvoice;
        }
        public double GetInvoiceAmount(SalesOrder _oSalesOrder, int nCustomerTypeID)
        {
            double _InvoiceAmount = 0;
            double _AdjustedDPAmount = 0;
            double _AdjustedPWAmount = 0;
            double _AdjustedTPAmount = 0;

            foreach (SalesOrderItem oItem in _oSalesOrder)
            {
                ProductDetail oChkProductDetail = new ProductDetail();
                oChkProductDetail.GetProductWithProvision(oItem.ProductID, nCustomerTypeID);

                _InvoiceAmount = _InvoiceAmount + (oItem.UnitPrice * oItem.ConfirmQuantity);
                //_AdjustedDPAmount = _AdjustedDPAmount + (oItem.AdjustedDPAmount * oItem.ConfirmQuantity);
                //_AdjustedPWAmount = _AdjustedPWAmount + (oItem.AdjustedPWAmount * oItem.ConfirmQuantity);
                //_AdjustedTPAmount = _AdjustedTPAmount + (oItem.AdjustedTPAmount * oItem.ConfirmQuantity);
                _AdjustedDPAmount = _AdjustedDPAmount + (oChkProductDetail.DP * oItem.ConfirmQuantity);
                _AdjustedPWAmount = _AdjustedPWAmount + (oChkProductDetail.PW * oItem.ConfirmQuantity);
                _AdjustedTPAmount = _AdjustedTPAmount + (oChkProductDetail.TP * oItem.ConfirmQuantity);
            }
            //_InvoiceAmount = _InvoiceAmount - (_oSalesOrder.Discount + _AdjustedDPAmount + _AdjustedPWAmount + _AdjustedTPAmount);
            _InvoiceAmount = Math.Round(_InvoiceAmount - (_oSalesOrder.Discount + _AdjustedDPAmount + _AdjustedPWAmount + _AdjustedTPAmount),2);

            return _InvoiceAmount;
        }
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesOrder _oSalesOrder, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.CustomerID = _oSalesOrder.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesOrder.Remarks;
            _oCustomerTransaction.UserID = Utility.UserId;
            if (_oSalesOrder.OrderTypeID == (int)Dictionary.OrderType.CASH)
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
            }
            else
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE;
            }

            return _oCustomerTransaction;
        }

        private void btnOrderControl_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrder oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;
            if (oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                //FrmOrderControl oFrmOrderControl = new FrmOrderControl();
                //oFrmOrderControl.ShowDialog(oSalesOrder);  
                //oFrmOrderControl.Show();
                
                Refresh();
            }
            else
            {
                MessageBox.Show("Only Received order can be Edited ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
    }
}