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
using CJ.Class.Library;

namespace CJ.Win.EPS
{
    public partial class frmEPSTD : Form
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
        SalesInvoice _oSalesInvoice;
        SalesInvoiceItem _oSalesInvoiceItem;
        EPSCustomer _oEPSCustomer;
        Customer _oCustomer;

        DateTime dtStartDate;
        DateTime dInvoiceDate;
        double _invoiceAmt = 0;
        double _PV = 0;
        long _InvoiceID = 0;
        string _sInvoiceNo = "";
        long nRem = 0;
        long nQuotient = 0;
        int nUIControl = 0;
        TELLib _oTELLib;


        public frmEPSTD()
        {
            InitializeComponent();

        }
        private void frmEPSTD_Load(object sender, EventArgs e)
        {

        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.SelectedCustomer != null)
            {
                _oCustomerDetail = new CustomerDetail();
                _oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oCustomerDetail.refresh();
                //ShowCustomerDetail(_oCustomerDetail);
            }
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

            if (ctlCustomer1.SelectedCustomer == null)
            {
                MessageBox.Show("Please enter a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();
                return false;
            }
            if (txtInvoiceNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Invoice Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoiceNo.Focus();
                return false;
            }
            if (txtInstallmnetNo.Text.Trim() == "" || txtInstallmnetNo.Text.Trim() == "0")
            {
                MessageBox.Show("Please enter Installment No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallmnetNo.Focus();
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
            if (txtDesignation.Text == "")
            {
                MessageBox.Show("Please enter Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesignation.Focus();
                return false;
            }
            if (txtEmplAddress.Text == "")
            {
                MessageBox.Show("Please enter Employee Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmplAddress.Focus();
                return false;
            }

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

                #region
                _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Invoiced;
                _oSalesOrder.AddOrder(dInvoiceDate);
                _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;


                _oEPSCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oEPSCustomer.EmployeeCode = txtCustomerCode.Text;
                _oEPSCustomer.EmployeeName = txtCustomerName.Text;
                _oEPSCustomer.EmployeeAddress = txtEmplAddress.Text;
                _oEPSCustomer.Designation = txtDesignation.Text;
                _oEPSCustomer.PhoneNo = txtPhoneNo.Text;
                _oEPSCustomer.Email = txtEmail.Text;

                _oEPSCustomer.InsertCustomer(true);


                _oEPSSalesOrder.EPSCustomerID = _oEPSCustomer.EPSCustomerID;
                _oEPSSalesOrder.WebTrackingNo = txtWebSlNo.Text;
                _oEPSSalesOrder.Insert();
                dInvoiceDate = Convert.ToDateTime(_oSalesOrder.OrderDate);

                int day = 0;
                day = dInvoiceDate.Day;

                if (day > 15)
                {
                    dtStartDate = dInvoiceDate.AddMonths(1);
                }
                else
                {
                    dtStartDate = dInvoiceDate;
                }
                _PV = 0;
                _PV = _invoiceAmt - Convert.ToDouble(txtDownPayment.Text);

                _oEMICalculationDetail.Result(Convert.ToDouble(txtInterestRate.Text), Convert.ToInt32(txtInstallmnetNo.Text), _PV, dtStartDate);

                foreach (EMICalculation oEMICalculation in _oEMICalculationDetail)
                {
                    oEMICalculation.OrderID = _oSalesOrder.OrderID;
                    oEMICalculation.IsDue = (int)Dictionary.EPSIsDue.Yes;
                    oEMICalculation.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
                    oEMICalculation.Insert();
                }
                _oSalesOrder.UpdateOrderID(_oSalesOrder.OrderID, _InvoiceID);

                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The EPS Order- " + _oSalesOrder.OrderNo.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppLogger.LogInfo("Win: Success fully Add EPS SalesOrder  =" + Utility.Username);
                #endregion
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Win: Unsccessfull Add EPS SalesOrder  =" + ex);
                MessageBox.Show("Error Inserting Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Confirm()
        {
            //int nCount = 0;
            //try
            //{
            //    DBController.Instance.BeginNewTransaction();

            //    _oEPSSalesOrder = (EPSSalesOrder)this.Tag;
            //    _oSalesOrder = _oEPSSalesOrder.SalesOrder;
            //    _oEMICalculationDetail = new EMICalculationDetail();
            //    _oSalesOrder.Clear();

            //    GetUIData(_oSalesOrder, _oEPSSalesOrder);
            //    _oSalesOrder.ConfirmDate = DateTime.Today.Date;
            //    _oSalesOrder.ConfirmUserID = Utility.UserId;
            //    _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Confirmed;
            //    _oSalesOrder.Edit();
            //    _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;
            //    //_oEPSCustomer.UpdateCustomer();
            //    _oEPSSalesOrder.Update();

            //    if (dtOrderDate.Value.Day > 15)
            //        dtStartDate = dtOrderDate.Value.Date.AddMonths(1);
            //    else dtStartDate = dtOrderDate.Value.Date;

            //    _oEMICalculationDetail.Result(_oEPSSalesOrder.InterestRate, _oEPSSalesOrder.NoOfInstallment, Convert.ToDouble(txtPV.Text), dtStartDate);

            //    foreach (EMICalculation oEMICalculation in _oEMICalculationDetail)
            //    {
            //        oEMICalculation.OrderID = _oSalesOrder.OrderID;
            //        oEMICalculation.IsDue = (int)Dictionary.EPSIsDue.Yes;
            //        oEMICalculation.IsEarlyClose = (int)Dictionary.EPSIsEarlyClose.No;
            //        if (nCount == 0)
            //        {
            //            oEMICalculation.Delete();
            //            nCount++;
            //        }
            //        oEMICalculation.Insert();
            //    }
            //    ///
            //    // Update Product Satock
            //    ///


            //    foreach (SalesOrderItem _oSalesOrderItem in _oSalesOrder)
            //    {
            //        ProductStock oProductStock = new ProductStock();

            //        oProductStock.ProductID = _oSalesOrderItem.ProductID;
            //        oProductStock.Quantity = _oSalesOrderItem.Quantity + _oSalesOrderItem.FreeQty;
            //        oProductStock.WarehouseID = _oSalesOrder.WarehouseID;
            //        oProductStock.ChannelID = _oCustomerDetail.ChannelID;

            //        oProductStock.Edit();
            //    }
            //    DBController.Instance.CommitTransaction();
            //    MessageBox.Show("You Have Successfully Confirm The Sales Order-" + _oSalesOrder.OrderNo.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    AppLogger.LogInfo("Win: Success fully Update EPS SalesOrder  =" + Utility.Username);
            //}
            //catch (Exception ex)
            //{
            //    DBController.Instance.RollbackTransaction();
            //    AppLogger.LogError("Win: Unsccessfull Confirm EPS SalesOrder  =" + ex);
            //    MessageBox.Show("You Have Unsccessfull Confirm The Sales Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        public void GetUIData(SalesOrder _oSalesOrder, EPSSalesOrder _oEPSSalesOrder)
        {
            ///
            // For Sales Order Class
            ///         
            _invoiceAmt = 0;
            _InvoiceID = 0;
            _sInvoiceNo = "";
            _oSalesInvoice = new SalesInvoice();

            _oSalesInvoice.GetInvoiceID(txtInvoiceNo.Text);
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);
            _sInvoiceNo = _oSalesInvoice.InvoiceNo;
            _invoiceAmt = _oSalesInvoice.InvoiceAmount;
            dInvoiceDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
            _InvoiceID = _oSalesInvoice.InvoiceID;
            //_oSalesInvoice.GetCustomerIDByInvoiceNo(txtInvoiceNo.Text);
            //_oEPSCustomer = new EPSCustomer();
            //_oEPSCustomer.GetCassiopeiaCustomer(_oSalesInvoice.CassiopeiaCustID, _oSalesInvoice.ShowroomID);

            _oSalesOrder.OrderDate = _oSalesInvoice.InvoiceDate;
            _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CREDIT;
            _oSalesOrder.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;

            //_oEPSCustomer.CustomerID = _oSalesOrder.CustomerID;
            //_oEPSCustomer.EmployeeCode = "";
            //_oEPSCustomer.Designation = "";

            _oCustomer = new Customer();
            _oCustomer.GetCustomerAddressByID(_oSalesOrder.CustomerID);

            _oSalesOrder.DeliveryAddress = _oCustomer.CustomerAddress;
            _oSalesOrder.SalesPersonID = -1;
            _oSalesOrder.WarehouseID = _oSalesInvoice.WarehouseID;
            _oSalesOrder.SalesPromotionID = -1;

            _oSalesOrder.DDDate = null;
            _oSalesOrder.DDDetails = "";
            _oSalesOrder.DDAmount = 0.0;
            _oSalesOrder.Remarks = txtRemarks.Text;
            _oSalesOrder.Discount = _oSalesInvoice.Discount;

            _oSalesOrder.CreateUserID = Utility.UserId;

            // Product Details

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {

                SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                _oSalesOrderItem.ProductID = oSalesInvoiceItem.ProductID;
                _oSalesOrderItem.UnitPrice = oSalesInvoiceItem.UnitPrice;
                _oSalesOrderItem.Quantity = Convert.ToInt32(oSalesInvoiceItem.Quantity);
                _oSalesOrderItem.ConfirmQuantity = _oSalesOrderItem.Quantity;

                _oSalesOrderItem.AdjustedDPAmount = 0;
                _oSalesOrderItem.AdjustedPWAmount = 0;
                _oSalesOrderItem.AdjustedTPAmount = 0;
                _oSalesOrderItem.PromotionalDiscount = 0;
                _oSalesOrderItem.IsFreeProduct = 0;
                _oSalesOrderItem.FreeQty = 0;

                _oSalesOrder.Add(_oSalesOrderItem);
            }

            ///
            // For Sales EPS sales class
            ///          

            _oEPSSalesOrder.OrderID = _oSalesOrder.OrderID;
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

            _oEPSSalesOrder.DeliveryWHID = _oSalesOrder.WarehouseID;
            _oEPSSalesOrder.Status = (int)Dictionary.EPSStatus.Running;

        }
        public bool IsOrderProduct(SalesOrder _oSalesOrder, int nProductID)
        {
            //foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
            //{
            //    if (oSalesOrderItem.ProductID == nProductID)
            //        return true;
            //}
            return false;
        }
        private void GetTotalAmount()
        {
            _oTELLib = new TELLib();
            //txtInvoiceAmount.Text = "0.00";
            double Downpayment = 0;

            try
            {
                Downpayment = Convert.ToDouble(txtDownPayment.Text);
            }
            catch
            {
                //        Downpayment = 0;
            }

            //txtEMICalculatedAmt.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtInvoiceAmount.Text) - Downpayment));

        }
        private void txtDownPayment_TextChanged(object sender, EventArgs e)
        {
            GetTotalAmount();
        }
        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.GetInvoiceID(txtInvoiceNo.Text.Trim());

            if (_oSalesInvoice.Flag == true)
            {
                txtInvoiceAmount.Text = _oTELLib.TakaFormat(Convert.ToDouble(_oSalesInvoice.InvoiceAmount));
                lblInvoiceDate.Text = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy");
                txtInvoiceNo.Enabled = false;
            }
            GetTotalAmount();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}