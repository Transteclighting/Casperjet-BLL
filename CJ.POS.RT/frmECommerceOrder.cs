using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Promotion;
using CJ.Class.POS;
using System.Text.RegularExpressions;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;
using CJ.Class.Warranty;
using CJ.Class.CLP;
using CJ.Class.Duty;

namespace CJ.POS.RT
{
    public partial class frmECommerceOrder : Form
    {
        int _nType = 0;
        int nEComOrderID = 0;
        TELLib _oTELLib;
        Employees oEmployees;
        int nWHID = 0;
        private string[] sProductBarcodeArr = null;
        private int nArrayLen = 0;
        EcommerceOrder _oEcommerceOrder;
        SystemInfo oSystemInfo;
        RetailConsumer oRetailConsumer;
        SalesInvoice _oSalesInvoice;
        ProductDetail _oProductDetail;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        SalesInvoiceProductSerials _oSIPSs;
        CustomerTransaction _oCustomerTransaction;
        StockTran _oStockTran;
        ProductStock _oProductStock;
        RetailSalesInvoice oRetailSalesInvoice;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        DutyAccount oDutyAccount;
        DSSalesInvoiceDetail oDSSalesInvoiceProduct;
        DSSalesInvoiceDetail oDSFreeGiftProduct;
        DSSalesInvoiceDetail oDSSalesInvoiceDetail;
        TELLib oTELLib;
        rptSalesInvoice orptSalesInvoice;
        WarrantyParameter oWarrantyParameter;
        PaymentModes _oPaymentModes;

        string sInvoiceNo = "";
        double _dPaymentTotal = 0;
        double _dDueAmount = 0;
        Image iImage;
        string SL = "";
        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;

        int nCustomerID = 0;

        int nSalesPersonID = 0;
        double _TotalDiscount = 0;
        double _InvoiceAmount = 0;

        double _DeliveryCharge = 0;
        int[] ProductIDList ={ 9, 1823, 2810, 2935, 2936, 2937 };

        public frmECommerceOrder(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }
        public void ShowDialog(EcommerceOrder oEcommerceOrder)
        {
            this.Tag = oEcommerceOrder;
            DBController.Instance.OpenNewConnection();
            _oTELLib = new TELLib();
            //LoadCombos();
            nEComOrderID = 0;
            nEComOrderID = oEcommerceOrder.EComOrderID;
            lblOrderNo.Text = oEcommerceOrder.OrderNo;
            lblOrderDate.Text = Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy");
            lblPaymentType.Text = Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), oEcommerceOrder.PaymentType);
            lblAmount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Amount);
            lblDiscount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Discount);
            lblDeliveryCharge.Text = _oTELLib.TakaFormat(oEcommerceOrder.DeliveryCharge);
            lblCopunNo.Text = oEcommerceOrder.CopunNo;
            lblConsumerName.Text = oEcommerceOrder.ConsumerName;
            lblAddress.Text = oEcommerceOrder.Addrress;
            lblDeliveryAddress.Text = oEcommerceOrder.DeliveryAddress;
            lblContactNo.Text = oEcommerceOrder.ContactNo;
            lblEmail.Text = oEcommerceOrder.Email;
            lblOutletName.Text = oEcommerceOrder.Outlet;
            txtRemarks.Text = oEcommerceOrder.Remarks;
            lbkCardType.Text = oEcommerceOrder.CardType;
            lblCardCategory.Text = oEcommerceOrder.CardCategory;
            lblIsEMI.Text = oEcommerceOrder.IsEMI.ToString();
            lblNoOfIns.Text = oEcommerceOrder.NoOfInstallment.ToString();
            lblApprovalNo.Text = oEcommerceOrder.ApprovalNo;
            lblInstrumentNo.Text = oEcommerceOrder.InstrumentNo;
            lblBankName.Text = oEcommerceOrder.BankName;
            lblOrderType.Text = "WEB Order";
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            nWHID = oSystemInfo.WarehouseID;
            nSalesPersonID = oEcommerceOrder.SalesPersonID;
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = nSalesPersonID;
            oEmployee.RefreshForPOS();
            lblSalesPerson.Text = oEmployee.EmployeeName;
            _TotalDiscount = oEcommerceOrder.Discount;
            _InvoiceAmount = oEcommerceOrder.Amount;
            _DeliveryCharge = oEcommerceOrder.DeliveryCharge;
            sInvoiceNo = oEcommerceOrder.RefInvoiceNo;
            
            
            txtPayable.Text = _oTELLib.TakaFormat((_InvoiceAmount + _DeliveryCharge) - _TotalDiscount);

            double _DueAmt = _InvoiceAmount - Convert.ToDouble(txtdue.Text);
            txtdue.Text = _oTELLib.TakaFormat(_DueAmt);
            txtdue.ForeColor = Color.Red;
            oEcommerceOrder.GetItem(oSystemInfo.WarehouseID, oEcommerceOrder.EComOrderID);
            this.Text = "E-Commerce Order";

            foreach (EcommerceOrderDetail oEcommerceOrderDetail in oEcommerceOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oEcommerceOrderDetail.ProductCode.ToString();
                oRow.Cells[1].Value = oEcommerceOrderDetail.ProductName.ToString();
                oRow.Cells[2].Value = oEcommerceOrderDetail.IsFreeQtyName.ToString();
                oRow.Cells[3].Value = oEcommerceOrderDetail.UnitPrice.ToString();
                oRow.Cells[4].Value = oEcommerceOrderDetail.DiscountAmount.ToString();
                oRow.Cells[5].Value = oEcommerceOrderDetail.CurrentStock.ToString();
                oRow.Cells[6].Value = oEcommerceOrderDetail.Quantity.ToString();
                oRow.Cells[9].Value = oEcommerceOrderDetail.ProductID.ToString();
                oRow.Cells[10].Value = oEcommerceOrderDetail.IsBarcodeItem.ToString();
                oRow.Cells[11].Value = oEcommerceOrderDetail.IsFreeQty.ToString();

                dgvLineItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }

        //public void LoadCombos()
        //{
        //    oEmployees = new Employees();
        //    cmbEmpoyee.Items.Clear();
        //    oEmployees.GetShowroomSalesPerson();
        //    cmbEmpoyee.Items.Add("<Select Sales Person>");
        //    foreach (Employee oEmployee in oEmployees)
        //    {
        //        cmbEmpoyee.Items.Add(oEmployee.EmployeeName);
        //    }
        //    if (oEmployees.Count > 0)
        //        cmbEmpoyee.SelectedIndex = 0;
        //}

        public void LoadUI()
        {

            DBController.Instance.OpenNewConnection();
            _oPaymentModes = new PaymentModes();
            _oPaymentModes.Refresh();

            Banks oBanks = new Banks();
            oBanks.Refresh();

            ShowroomAssets oShowroomAssets = new ShowroomAssets();
            oShowroomAssets.Refresh(Dictionary.ShowroomAssetType.POSMachine);

            Utilities oIsEMI = new Utilities();
            oIsEMI.GetIsEMI();

            DataGridViewComboBoxColumn ColumnPaymentMode = new DataGridViewComboBoxColumn();
            ColumnPaymentMode.DataPropertyName = "PaymentMode";
            ColumnPaymentMode.HeaderText = "Payment Mode";
            ColumnPaymentMode.Width = 120;
            ColumnPaymentMode.DataSource = _oPaymentModes;
            ColumnPaymentMode.ValueMember = "PaymentModeID";
            ColumnPaymentMode.DisplayMember = "PaymentModeName";
            dgvPayment.Columns.Add(ColumnPaymentMode);

            DataGridViewTextBoxColumn txtAmount = new DataGridViewTextBoxColumn();
            txtAmount.HeaderText = "Amount";
            txtAmount.Width = 90;
            dgvPayment.Columns.Add(txtAmount);

            DataGridViewComboBoxColumn ColumnItem = new DataGridViewComboBoxColumn();
            ColumnItem.DataPropertyName = "Bank";
            ColumnItem.HeaderText = "Bank";
            ColumnItem.Width = 120;
            ColumnItem.DataSource = oBanks;
            ColumnItem.ValueMember = "BankID";
            ColumnItem.DisplayMember = "Name";
            dgvPayment.Columns.Add(ColumnItem);

            Utilities oCreditCardType = new Utilities();
            oCreditCardType.GetCreditCardType();

            DataGridViewComboBoxColumn ColumnItem3 = new DataGridViewComboBoxColumn();
            ColumnItem3.DataPropertyName = "CreditCardType";
            ColumnItem3.HeaderText = "Card Type";
            ColumnItem3.Width = 80;
            ColumnItem3.DataSource = oCreditCardType;
            ColumnItem3.ValueMember = "SatusId";
            ColumnItem3.DisplayMember = "Satus";
            dgvPayment.Columns.Add(ColumnItem3);

            DataGridViewComboBoxColumn ColumnItem1 = new DataGridViewComboBoxColumn();
            ColumnItem1.DataPropertyName = "POSMachine";
            ColumnItem1.HeaderText = "POS Machine";
            ColumnItem1.Width = 120;
            ColumnItem1.DataSource = oShowroomAssets;
            ColumnItem1.ValueMember = "AssetID";
            ColumnItem1.DisplayMember = "AssetName";
            dgvPayment.Columns.Add(ColumnItem1);

            Utilities oCreditCardCategory = new Utilities();
            oCreditCardCategory.GetCreditCardCategory();

            DataGridViewComboBoxColumn ColumnItem4 = new DataGridViewComboBoxColumn();
            ColumnItem4.DataPropertyName = "Category";
            ColumnItem4.HeaderText = "Category";
            ColumnItem4.Width = 120;
            ColumnItem4.DataSource = oCreditCardCategory;
            ColumnItem4.ValueMember = "SatusId";
            ColumnItem4.DisplayMember = "Satus";
            dgvPayment.Columns.Add(ColumnItem4);

            DataGridViewTextBoxColumn txtApprovalNo = new DataGridViewTextBoxColumn();

            txtApprovalNo.HeaderText = "ApprovalNo";
            txtApprovalNo.Width = 80;
            dgvPayment.Columns.Add(txtApprovalNo);

            DataGridViewComboBoxColumn ColumnItem2 = new DataGridViewComboBoxColumn();
            ColumnItem2.DataPropertyName = "IsEMI";
            ColumnItem2.HeaderText = "Is EMI";
            ColumnItem2.Width = 50;
            ColumnItem2.DataSource = oIsEMI;
            ColumnItem2.ValueMember = "SatusId";
            ColumnItem2.DisplayMember = "Satus";
            dgvPayment.Columns.Add(ColumnItem2);

            DataGridViewTextBoxColumn txtInstallmentNo = new DataGridViewTextBoxColumn();

            txtInstallmentNo.HeaderText = "# of Installment";
            txtInstallmentNo.Width = 60;
            dgvPayment.Columns.Add(txtInstallmentNo);

            DataGridViewTextBoxColumn txtInstrumentNo = new DataGridViewTextBoxColumn();

            txtInstrumentNo.HeaderText = "Instrument No";
            txtInstrumentNo.Width = 80;
            dgvPayment.Columns.Add(txtInstrumentNo);

            DataGridViewTextBoxColumn txtInstrumentDate = new DataGridViewTextBoxColumn();

            txtInstrumentDate.HeaderText = "Instrument Date";
            txtInstrumentDate.Width = 90;
            dgvPayment.Columns.Add(txtInstrumentDate);

        }
        private bool validateUIInput()
        {
            //if (cmbEmpoyee.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select a Sales Person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbEmpoyee.Focus();
            //    return false;
            //}
            if (_nType == 2)
            {
                #region Payment Collection Validation
                if (dgvPayment.Rows.Count - 1 == 0)
                {
                    MessageBox.Show("Please Input Payment Collection ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
                {
                    if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[0].Value == null)
                        {
                            MessageBox.Show("Please Input Valid Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            if (oItemRow.Cells[1].Value != null)
                            {
                                try
                                {
                                    double tmp = Convert.ToDouble(oItemRow.Cells[1].Value);
                                }
                                catch
                                {
                                    MessageBox.Show("Please Input valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        if (int.Parse(oItemRow.Cells[0].Value.ToString()) == (int)Dictionary.PaymentMode.Credit_Card)
                        {
                            if (oItemRow.Cells[2].Value == null)
                            {
                                MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            if (oItemRow.Cells[3].Value == null)
                            {
                                MessageBox.Show("Please Select Card Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            if (oItemRow.Cells[4].Value == null)
                            {
                                MessageBox.Show("Please Select POS Machine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            if (oItemRow.Cells[5].Value == null)
                            {
                                MessageBox.Show("Please Select Card Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            if (oItemRow.Cells[6].Value == null)
                            {
                                {

                                    MessageBox.Show("Please input Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                                if (oItemRow.Cells[6].Value != null)
                                {
                                    try
                                    {
                                        int tem = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Please input valid Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }

                                }

                            }


                            if (oItemRow.Cells[7].Value != null)
                            {
                                if (Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim()) == (int)Dictionary.YesOrNoStatus.YES)
                                {
                                    if (oItemRow.Cells[8].Value != null)
                                    {
                                        try
                                        {
                                            int tem = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Please input valid Installment Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please input #of Installment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }

                                }
                            }

                            if (oItemRow.Cells[10].Value != null)
                            {
                                try
                                {
                                    DateTime tmp = Convert.ToDateTime(oItemRow.Cells[10].Value);
                                }
                                catch
                                {
                                    MessageBox.Show("Please input valid Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }

                        }
                    }
                }

                #endregion
            }

            return true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //if (validateUIInput())
            //{
            //_oEcommerceOrder = new EcommerceOrder();
            //_oEcommerceOrder.EComOrderID = nEComOrderID;
            //_oEcommerceOrder.Status = (int)Dictionary.ECommerceOrderStatus.Send_To_Customer;
            //_oEcommerceOrder.SalesPersonID = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;


            //try
            //{
            //    DBController.Instance.BeginNewTransaction();
            //    _oEcommerceOrder.UpdateStatus();

            //    int _nCount = 1;
            //    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            //    {
            //        if (oItemRow.Index < dgvLineItem.Rows.Count)
            //        {
            //            if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
            //            {
            //                char[] splitchar = { ',' };
            //                string sProductBarcode = oItemRow.Cells[7].Value.ToString();
            //                sProductBarcodeArr = sProductBarcode.Split(splitchar);
            //                nArrayLen = sProductBarcodeArr.Length;

            //                for (int i = 0; i < nArrayLen; i++)
            //                {
            //                    EcommerceOrderDetail _oEcommerceOrderDetail = new EcommerceOrderDetail();

            //                    _oEcommerceOrderDetail.EcomOrderID = nEComOrderID;
            //                    _oEcommerceOrderDetail.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
            //                    _oEcommerceOrderDetail.SerialNo = _nCount;
            //                    _oEcommerceOrderDetail.ProductSerialNo = sProductBarcodeArr[i];
            //                    _oEcommerceOrderDetail.InsertProductSerial();
            //                    _nCount++;

            //                }

            //            }
            //        }
            //    }
            //    DBController.Instance.CommitTransaction();
            //    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    DBController.Instance.RollbackTransaction();
            //    MessageBox.Show(ex.Message, "Error!!!");
            //}
            Save();

            //}

        }
        private void Save()
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();

                    #region Consumer Entry

                    oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerName = lblConsumerName.Text;
                    oRetailConsumer.Address = lblDeliveryAddress.Text;
                    oRetailConsumer.ConsumerType = 1;
                    oRetailConsumer.Email = lblEmail.Text;
                    oRetailConsumer.NationalID = "";
                    oRetailConsumer.CellNo = lblContactNo.Text;
                    oRetailConsumer.PhoneNo = "";
                    oRetailConsumer.VatRegNo = "";
                    oRetailConsumer.EmployeeCode = "";
                    oRetailConsumer.CustomerID = oSystemInfo.CustomerID;
                    oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                    nCustomerID = oRetailConsumer.CustomerID;
                    oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                    oRetailConsumer.SalesType = (int)Dictionary.SalesType.eStore;

                    oRetailConsumer.Add();


                    #endregion

                    #region Insert in SalesInvoice and SalesInvoiceDetail
                    ///
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oRetailConsumer);
                    _oSalesInvoice.InsertPOSInvoice(true);
                    #endregion

                    #region Insert Promotional Effect in Invoice
                    //if (oResultSPromotions != null)
                    //{
                    //    foreach (SPromotion oSelectSPromotion in oResultSPromotions)
                    //    {
                    //        _oSalesInvoice.SalesPromotionID = oSelectSPromotion.SalesPromotionID;

                    //        _oSalesInvoice.InsertSalesInvoicePromo();
                    //    }
                    //}
                    #endregion

                    #region barcode from Invoice Item
                    int _nCount = 1;
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[7].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {
                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                    oProductBarcode.UpdateProductSerial();

                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];
                                    _oSalesInvoiceProductSerial.Insert();

                                    _nCount++;

                                }

                            }
                        }
                    }








                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[7].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {

                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                    oProductBarcode.UpdateProductSerial();

                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];

                                    _oSalesInvoiceProductSerial.Insert();
                                    _nCount++;

                                }

                            }
                        }
                    }
                    #endregion

                    #region Insert in Customer Transaction and Update Customer Account.
                    ///
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction);
                    if (_oCustomerTransaction.CheckTranNo())
                        _oCustomerTransaction.AddTran(true);
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Duplicate Customer Transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    #endregion

                    #region Update Product Satock
                    foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                        oProductStock.Quantity = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                        oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                        oProductStock.ChannelID = oSystemInfo.ChannelID;

                        oProductStock.Edit();
                    }
                    #endregion

                    #region Customer Tran(Collection){CustomerTran/Invoice wise payment/CustomerAccount (+)}

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oSalesInvoice);
                    _oCustomerTransaction.InsertForPOSRT(oSystemInfo.WarehouseID, Convert.ToDateTime(oSystemInfo.OperationDate));

                    #endregion

                    #region PROCESSING Delivery
                    _oSalesInvoice.UpdateDate = oSystemInfo.OperationDate;
                    _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                    #endregion

                    #region Delivery Invoice & ProductStock Tran

                    _oStockTran = new StockTran();
                    _oStockTran = SetData(_oStockTran, _oSalesInvoice);
                    _oSalesInvoice.UserID = Utility.UserId;
                    _oSalesInvoice.DeliveryDate = oSystemInfo.OperationDate;
                    _oSalesInvoice.RetailDeliveryInvoice(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.DELIVERED, _oSalesInvoice.WarehouseID);
                    _oStockTran.UserID = Utility.UserId;
                    _oStockTran.InsertForInvoiceWeb();

                    foreach (StockTranItem oItem in _oStockTran)
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                        if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if ((_oProductStock.BookingStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.Update(oItem.StockPrice);

                        if (_oProductStock.Flag == false)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        _oProductStock = new ProductStock();
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.WarehouseID = _oStockTran.ToWHID;
                        _oProductStock.Quantity = _oStockTran.ToChannelID;

                        _oProductStock.UpdateCurrentStock(true);

                    }

                    #endregion

                    #region Insert Retail Invoice Extra & Payment Mode

                    oRetailSalesInvoice = new RetailSalesInvoice();

                    oRetailSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
                    oRetailSalesInvoice.SPParcentage = 0;
                    oRetailSalesInvoice.FaltAmount = 0;
                    oRetailSalesInvoice.SPDiscount = 0;
                    oRetailSalesInvoice.InstallationCharge = 0;
                    oRetailSalesInvoice.FreightCharge = 0;
                    oRetailSalesInvoice.OtherCharge = _DeliveryCharge;
                    oRetailSalesInvoice.MarkUpAmount = 0;
                    oRetailSalesInvoice.DiscountReasonID = 0;
                    oRetailSalesInvoice.SalesPromotionType = 1;
                    oRetailSalesInvoice.InsertCharge();


                    oRetailSalesInvoice.PaymentModeID = (int)Dictionary.PaymentMode.ECommerce;
                    oRetailSalesInvoice.Amount = _oSalesInvoice.InvoiceAmount;
                    oRetailSalesInvoice.BankID = -1;
                    oRetailSalesInvoice.CardType = -1;
                    oRetailSalesInvoice.POSMachineID = -1;
                    oRetailSalesInvoice.CardCategory = -1;
                    oRetailSalesInvoice.ApprovalNo = "";
                    oRetailSalesInvoice.IsEMI = -1;
                    oRetailSalesInvoice.NoOfInstallment = -1;
                    oRetailSalesInvoice.InstrumentNo = "";
                    oRetailSalesInvoice.InstrumentDate = null;
                    oRetailSalesInvoice.InsertPayMode();

                    #endregion

                    #region Duty
                    if (Utility.CompanyInfo == "TEL")
                    {
                        _DutyLocalBalance = 0;
                        _DutyImportBalance = 0;
                        oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11);
                        oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA);

                        if (oDutyTranVAT11.Count > 0)
                        {
                            if (oDutyTranVAT11.Amount > 0)
                            {
                                oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                                oDutyTranVAT11.InsertForPOS(oSystemInfo.WarehouseCode);
                            }
                        }
                        if (oDutyTranVAT11KA.Count > 0)
                        {
                            if (oDutyTranVAT11KA.Amount > 0)
                            {
                                oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                                oDutyTranVAT11KA.InsertForPOS(oSystemInfo.WarehouseCode);
                            }
                        }

                        oDutyAccount = new DutyAccount();
                        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                        oDutyAccount.Balance = _DutyLocalBalance;
                        oDutyAccount.UpdateBalanceForPOS(true);

                        oDutyAccount = new DutyAccount();
                        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                        oDutyAccount.Balance = _DutyImportBalance;
                        oDutyAccount.UpdateBalanceForPOS(true);

                        //PrintVatChallan(_oSalesInvoice);
                    }

                    #endregion

                    #region E-Commerce Data Update

                    _oEcommerceOrder = new EcommerceOrder();
                    _oEcommerceOrder.EComOrderID = nEComOrderID;
                    _oEcommerceOrder.RefInvoiceNo = _oSalesInvoice.InvoiceNo;
                    _oEcommerceOrder.Status = (int)Dictionary.ECommerceOrderStatus.Invoiced;
                    _oEcommerceOrder.UpdateLeadInvoiceStatus();

                    DataTran _oDataTran = new DataTran();
                    _oDataTran.TableName = "t_SalesInvoiceEcommerce";
                    _oDataTran.DataID = nEComOrderID;
                    _oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                    _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTran.BatchNo = 0;
                    _oDataTran.CreateDate = DateTime.Now.Date;
                    if (_oDataTran.CheckData())
                    {

                    }
                    else
                    {
                        _oDataTran.AddForTDPOS();
                    }
                    #endregion


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btSave.Enabled = false;
                    DBController.Instance.OpenNewConnection();
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        InvoiceWiseBarcode();
                        PrintRetailInvoice(_oSalesInvoice.InvoiceID, false);
                        if (Utility.CompanyInfo == "TEL")
                        {
                            PrintWarrantyCard(_oSalesInvoice);
                        }
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice, RetailConsumer oRetailConsumer)
        {

            double Charge = 0;

            _oSalesInvoice.InvoiceDate = DateTime.Now.Date;
            _oSalesInvoice.CustomerID = nCustomerID;
            _oSalesInvoice.DeliveryAddress = oSystemInfo.WarehouseAddress;
            _oSalesInvoice.DeliveryDate = DateTime.Now.Date;
            _oSalesInvoice.SalesPersonID = nSalesPersonID;
            _oSalesInvoice.WarehouseID = oSystemInfo.WarehouseID;
            _oSalesInvoice.InvoiceStatus = (int)Dictionary.InvoiceStatus.DELIVERED;
            _oSalesInvoice.CreateDate = DateTime.Now.Date;
            try
            {
                _oSalesInvoice.Discount = _TotalDiscount;
            }
            catch
            {
                _oSalesInvoice.Discount = 0;
            }
            _oSalesInvoice.Remarks = txtRemarks.Text;
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CREDIT;

            _oSalesInvoice.UserID = Utility.UserId;
            try
            {
                _oSalesInvoice.InvoiceAmount = (_InvoiceAmount + _DeliveryCharge) - _TotalDiscount;
            }
            catch
            {
                _oSalesInvoice.InvoiceAmount = 0;
            }
            _oSalesInvoice.PriceOptionID = (int)Dictionary.PriceOption.RSP;


            _oSalesInvoice.OtherCharge = _DeliveryCharge;
            _oSalesInvoice.SundryCustomerID = oRetailConsumer.ConsumerID;

            #region Get Line Item

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                    _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                    _oSalesInvoiceItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate), _oSalesInvoiceItem.ProductID);

                    _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                    _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

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
                            _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                        }

                    }

                    _oSalesInvoiceItem.AdjustedDPAmount = 0;
                    _oSalesInvoiceItem.AdjustedPWAmount = 0;
                    _oSalesInvoiceItem.AdjustedTPAmount = 0;
                    _oSalesInvoiceItem.PromotionalDiscount = 0;
                    _oSalesInvoiceItem.IsFreeProduct = int.Parse(oItemRow.Cells[11].Value.ToString());
                    if (_oSalesInvoiceItem.IsFreeProduct == 1)
                    {
                        _oSalesInvoiceItem.Quantity = 0;
                        _oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                    }
                    else
                    {
                        _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[6].Value.ToString());
                        _oSalesInvoiceItem.FreeQty = 0;
                    }
                    _oSalesInvoice.Add(_oSalesInvoiceItem);
                }
            }
            #endregion

            return _oSalesInvoice;
        }
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;

            return _oCustomerTransaction;
        }
        public CustomerTransaction GetCustomerTranForCollection(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.TranDate = DateTime.Today.Date;
            _oCustomerTransaction.Amount = Convert.ToDouble(_oSalesInvoice.InvoiceAmount);
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
            _oCustomerTransaction.EntryLocationID = Utility.LocationID;
            return _oCustomerTransaction;
        }
        public StockTran SetData(StockTran oStockTran, SalesInvoice _oSalesInvoice)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.FromChannelID = oSystemInfo.ChannelID;
            oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
            oStockTran.ToChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
            oStockTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;

            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = Convert.ToDateTime(oSystemInfo.OperationDate);

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                oItem.Qty = oSalesInvoiceItem.Quantity + oSalesInvoiceItem.FreeQty;

                //if (oSalesInvoiceItem.IsFreeProduct == 0)
                //    oItem.Qty = oSalesInvoiceItem.Quantity;
                //else oItem.Qty = oSalesInvoiceItem.FreeQty;

                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }
        ///
        //  For VAT 11
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11)
        {
            oDutyTranVAT11 = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT11.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.Refresh(oItem.ProductID);
                if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                    {
                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                        oDutyTranDetail.ProductID = oItem.ProductID;
                        oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                        if (CheckProductID(oDutyTranDetail.ProductID))
                        {
                            if (oItem.UnitPrice == 0)
                            {
                                CustomerDetail oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                                oCustomerDetail.refresh();

                                if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                }


                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = 0;
                            oDutyTranDetail.DutyRate = 0;
                        }

                        _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                        oDutyTranVAT11.Add(oDutyTranDetail);
                    }
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }
        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA)
        {
            oDutyTranVAT11KA = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);


            oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT11KA.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                //_oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh(oItem.ProductID);
                if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                    {
                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                        oDutyTranDetail.ProductID = oItem.ProductID;
                        oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                        if (CheckProductID(oDutyTranDetail.ProductID))
                        {
                            if (oItem.UnitPrice == 0)
                            {
                                CustomerDetail oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                                oCustomerDetail.refresh();

                                if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                }

                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = 0;
                            oDutyTranDetail.DutyRate = 0;
                        }

                        _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                        oDutyTranVAT11KA.Add(oDutyTranDetail);
                    }
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }
        public void InvoiceWiseBarcode()
        {
            SL = "";
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(_oSalesInvoice.InvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {

                string PCode = "";

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {

                    if (PCode == "")
                    {
                        PCode = "<" + SIPSs.ProductCode + ">";
                    }
                    else
                    {
                        PCode = " ";
                    }
                    if (SL != "")
                    {
                        SL = SL + ",";
                    }
                    SL = SL + PCode + SIPSs.ProductSerialNo;
                }
            }
        }
        public bool CheckProductID(int nProductID)
        {
            int nCount = 0;
            foreach (int PID in ProductIDList)
            {
                if (PID == nProductID)
                    nCount++;
            }
            if (nCount == 0)
                return true;
            else return false;

        }
        public void PrintRetailInvoice(long nInvoiceID, bool IsCLP)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            bool _bCreditCardVisible = false;
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                else if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    //oFreeGiftProductRow.Barcode = orptSalesInvoiceDetail.FreeProductBarcode;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();
            //if (ctlRetailConsumer1.SelectedCustomer == null)
            //{
            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
            oRetailConsumer.CustomerID = int.Parse(orptSalesInvoice.CustomerID.ToString());
            //}
            oRetailConsumer.RefreshForPOS();

            oRetailSalesInvoice = new RetailSalesInvoice();
            oRetailSalesInvoice.InvoiceID = nInvoiceID;
            oRetailSalesInvoice.RefreshInvoiceCharge();
            oRetailSalesInvoice.RefreshPaymentMode();
            oRetailSalesInvoice.RefreshSMSDiscoutn(orptSalesInvoice.InvoiceNo);
            rptRetailInvoice doc;
            doc = new rptRetailInvoice();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("Address", oSystemInfo.WarehouseAddress + ", Outlet Phone No:" + oSystemInfo.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", oSystemInfo.WarehouseCellNo + ", e-mail:" + oSystemInfo.WarehouseEmail);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);

            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");

            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            doc.SetParameterValue("RefInvoice", "");
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            doc.SetParameterValue("SPDiscount", oRetailSalesInvoice.SPDiscount);
            if (oRetailSalesInvoice.TotalDiscount != 0)
            {
                if (oRetailSalesInvoice.SPParcentage != 0)
                {
                    doc.SetParameterValue("IspercentDiscount?", true);
                }
                else
                {
                    doc.SetParameterValue("IspercentDiscount?", false);
                }
            }
            else
            {
                doc.SetParameterValue("IspercentDiscount?", false);
            }
            doc.SetParameterValue("SDiscount", oRetailSalesInvoice.TotalDiscount);
            doc.SetParameterValue("Discount", orptSalesInvoice.Discount);
            doc.SetParameterValue("smsDiscount", oRetailSalesInvoice.smsDiscount);

            doc.SetParameterValue("FCharge", oRetailSalesInvoice.FreightCharge);
            doc.SetParameterValue("ICharge", oRetailSalesInvoice.InstallationCharge);
            doc.SetParameterValue("OCharge", oRetailSalesInvoice.OtherCharge);
            doc.SetParameterValue("MCharge", oRetailSalesInvoice.MarkUpAmount);
            doc.SetParameterValue("Charge", oRetailSalesInvoice.TotalCharge);

            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            doc.SetParameterValue("Cash", oRetailSalesInvoice.Cash);
            doc.SetParameterValue("Credit", oRetailSalesInvoice.Credit);
            doc.SetParameterValue("AdvanceAdjust", oRetailSalesInvoice.AdvanceAdjust);
            doc.SetParameterValue("OthersPayment", oRetailSalesInvoice.Others);
            doc.SetParameterValue("Payment", oRetailSalesInvoice.TotalAmount);

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            //doc.SetParameterValue("Barcode", sBarcode);

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);
            doc.SetParameterValue("IsVisibleCreditCard", _bCreditCardVisible);

            doc.SetParameterValue("IsCLP", IsCLP);
            doc.SetParameterValue("PBalance", 0);
            doc.SetParameterValue("RBalance", 0);
            doc.SetParameterValue("CBalance", 0);

            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }

            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            frmView.ShowDialog(doc);
        }
        private void PrintWarrantyCard(SalesInvoice _oSalesInvoice)
        {
            try
            {
                foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                {

                    Product oProduct = new Product();
                    oProduct.ProductID = oSalesInvoiceItem.ProductID;
                    oProduct.RefreshByID();
                    {
                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                        _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                        _oSalesInvoiceProductSerial.ProductID = oProduct.ProductID;
                        _oSalesInvoiceProductSerial.GetBarcode();


                        char[] splitchar = { ',' };
                        if (_oSalesInvoiceProductSerial.ProductSerialNo != null)
                        {
                            string sProductBarcode = _oSalesInvoiceProductSerial.ProductSerialNo;
                            sProductBarcodeArr = sProductBarcode.Split(splitchar);
                            nArrayLen = sProductBarcodeArr.Length;
                            for (int i = 0; i < nArrayLen; i++)
                            {
                                PrintWarrantyCard(oSalesInvoiceItem.ProductID, _oSalesInvoice, sProductBarcodeArr[i]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
                //DBController.Instance.RollbackTransaction();
                //MessageBox.Show("Error...Printing Warranty Card ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

        }
        public void PrintWarrantyCard(int nProductID, SalesInvoice _oSalesInvoice, string sBarcode)
        {

            //oWarrantyProducts = new WarrantyProducts();
            WarrantyParam oWarrantyParam = new WarrantyParam();

            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {

                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.RefreshForPOS();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();

                try
                {
                    oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.GetNextWarrantyCardNo(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, sBarcode);

                }
                catch (Exception ex)
                {
                    int Tem = int.Parse("");
                }

                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();

                doc.SetDataSource(oDSQRCode);

                doc.SetParameterValue("WarrantyCardNo", oWarrantyParameter.WarrantyCardNo);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);
                if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }
                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);


                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }
        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, SalesInvoice _oSalesInvoice, string sBarcode, string sProductCode, string sProductName)
        {
            ZAM.QRCode.Codec.QRCodeEncoder qrCodeEncoder = new ZAM.QRCode.Codec.QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = ZAM.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = ZAM.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M;

                String data = oRetailConsumer.ConsumerCode +
                                "\n" + _oSalesInvoice.InvoiceNo +
                                "\n" + _oSalesInvoice.InvoiceDate.ToString();
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + "" +
                     "\n" + "" +
                     "\n" + "" +
                     "\n" + "";
                }
                else
                {
                    data = data + "\n" + oRetailConsumer.ConsumerName +
                    "\n" + oRetailConsumer.Address +
                    "\n" + oRetailConsumer.CellNo +
                    "\n" + oRetailConsumer.Email;
                }
                data = data + "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + oRetailConsumer.ParentCustomerID;
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + Convert.ToString(Utility.DealerChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2B || oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2C)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDCorporateChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.HPA)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDHPAChannelID);
                }
                else
                {
                    data = data + "\n" + Convert.ToString(Utility.RetailChannelID);
                }
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();

        }
        public void PrintWarrantyCardForBulk(int nProductID, SalesInvoice _oSalesInvoice)
        {
            WarrantyParam oWarrantyParam = new WarrantyParam();

            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {

                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.RefreshForPOS();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();


                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                _oSalesInvoiceProductSerial.ProductID = nProductID;
                _oSalesInvoiceProductSerial.GetBarcode();

                try
                {
                    oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.GetNextWarrantyCardNo(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, _oSalesInvoiceProductSerial.ProductSerialNo);

                }
                catch (Exception ex)
                {
                    int Tem = int.Parse("");
                }

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();

                doc.SetParameterValue("WarrantyCardNo", oWarrantyParameter.WarrantyCardNo);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                doc.SetParameterValue("Address", oRetailConsumer.Address);
                doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                doc.SetParameterValue("Email", oRetailConsumer.Email);

                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", _oSalesInvoiceProductSerial.ProductSerialNo);


                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString()), nWHID, "",0);
                ofrmAvailableBarcode.ShowDialog();
                if (int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (ofrmAvailableBarcode._nCount == int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[6].Value.ToString()))
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[7].Value = ofrmAvailableBarcode._sBarcode;
                    }
                    else
                    {
                        MessageBox.Show("Selected Barcode Qty must be equal of Order Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmECommerceOrder_Load(object sender, EventArgs e)
        {
            if (_nType == 1)
            {
                tabControl1.TabPages.Remove(tabPayment);
                btnAddPayment.Visible = false;
                btSave.Visible = true;
                this.Text = "Prepared Lead Invoice";
            }
            else if (_nType == 2)
            {
                tabControl1.TabPages.Remove(tabProductDetail);
                btnAddPayment.Visible = true;
                btSave.Visible = false;
                this.Text = "Add Payment";
                LoadUI();
            }


        }

        private void dgvPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _dPaymentTotal = 0;
            _dDueAmount = 0;
            txtCollection.Text = "0.00";
            txtdue.Text = "0.00";

            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (Convert.ToInt32(oItemRow.Cells[0].Value) == (int)Dictionary.PaymentMode.Cash)
                    {
                        oItemRow.Cells[1].ReadOnly = false;
                        oItemRow.Cells[1].Style.BackColor = Color.Transparent;
                        oItemRow.Cells[2].ReadOnly = true;
                        oItemRow.Cells[2].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[3].ReadOnly = true;
                        oItemRow.Cells[3].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[4].ReadOnly = true;
                        oItemRow.Cells[4].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[5].ReadOnly = true;
                        oItemRow.Cells[5].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[6].ReadOnly = true;
                        oItemRow.Cells[6].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[7].ReadOnly = true;
                        oItemRow.Cells[7].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[8].ReadOnly = true;
                        oItemRow.Cells[8].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[9].ReadOnly = true;
                        oItemRow.Cells[9].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[10].ReadOnly = true;
                        oItemRow.Cells[10].Style.BackColor = Color.LightGray;
                        oItemRow.Cells[0].ReadOnly = true;
                    }
                }
            }
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[2].Value != null)
                    {
                        Bank oBank = new Bank();
                        int nBankID = int.Parse(oItemRow.Cells[2].Value.ToString());
                        oBank.BankID = nBankID;
                        DBController.Instance.OpenNewConnection();
                        oBank.Refresh();
                        if (oBank.IsEMI == (int)Dictionary.IsEMI.Yes)
                        {
                            oItemRow.Cells[7].ReadOnly = false;
                            oItemRow.Cells[7].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[8].ReadOnly = false;
                            oItemRow.Cells[8].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[9].ReadOnly = false;
                            oItemRow.Cells[9].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[10].ReadOnly = false;
                            oItemRow.Cells[10].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[2].ReadOnly = true;
                        }
                        else
                        {
                            oItemRow.Cells[7].ReadOnly = true;
                            oItemRow.Cells[7].Value = 0;
                            oItemRow.Cells[7].Style.BackColor = Color.LightGray;
                            oItemRow.Cells[8].ReadOnly = true;
                            oItemRow.Cells[8].Style.BackColor = Color.LightGray;
                            oItemRow.Cells[9].ReadOnly = false;
                            oItemRow.Cells[9].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[10].ReadOnly = false;
                            oItemRow.Cells[10].Style.BackColor = Color.Transparent;
                            oItemRow.Cells[2].ReadOnly = true;
                        }
                    }

                }
            }

            _dPaymentTotal = 0;
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {

                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                                _dPaymentTotal = _dPaymentTotal + tmp;
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }
                }
            }
            Collection(_dPaymentTotal);
        }

        private void Collection(double _Amount)
        {
            TELLib oTELLib = new TELLib();


            txtCollection.Text = oTELLib.TakaFormat(_Amount);
            txtdue.Text = oTELLib.TakaFormat((Convert.ToDouble(txtPayable.Text) - Convert.ToDouble(txtCollection.Text)));

            if (Convert.ToDouble(txtdue.Text) != 0)
                txtdue.ForeColor = Color.Red;
            else txtdue.ForeColor = Color.Green;
        }

        private void dgvPayment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _dPaymentTotal = 0;
            foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
            {
                if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {
                                //    txtCollectionAmount.Text = "0.00";
                                //    txtDueAmount.Text = "0.00";
                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                                _dPaymentTotal = _dPaymentTotal + tmp;
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }
                }
            }
            Collection(_dPaymentTotal);
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    #region Insert Retail Invoice Extra & Payment Mode
                    SalesInvoice oSalesInvoice = new SalesInvoice();
                    oSalesInvoice.GetIDByInvoiceNo(sInvoiceNo);
                    oRetailSalesInvoice = new RetailSalesInvoice();
                    oRetailSalesInvoice.DeletePayment(oSalesInvoice.InvoiceID);
                    oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
                    foreach (DataGridViewRow oItemRow in dgvPayment.Rows)
                    {
                        int nPaymentModeID = 0;
                        if (oItemRow.Index < dgvPayment.Rows.Count - 1)
                        {
                            oRetailSalesInvoice.PaymentModeID = int.Parse(oItemRow.Cells[0].Value.ToString());
                            nPaymentModeID = oRetailSalesInvoice.PaymentModeID;
                            oRetailSalesInvoice.Amount = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                            try
                            {
                                oRetailSalesInvoice.BankID = int.Parse(oItemRow.Cells[2].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.BankID = -1;

                            }
                            try
                            {
                                oRetailSalesInvoice.CardType = int.Parse(oItemRow.Cells[3].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.CardType = -1;
                            }
                            try
                            {
                                oRetailSalesInvoice.POSMachineID = int.Parse(oItemRow.Cells[4].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.POSMachineID = -1;

                            }

                            try
                            {
                                oRetailSalesInvoice.CardCategory = int.Parse(oItemRow.Cells[5].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.CardCategory = -1;

                            }


                            try
                            {
                                oRetailSalesInvoice.ApprovalNo = oItemRow.Cells[6].Value.ToString().Trim();
                            }
                            catch
                            {
                                oRetailSalesInvoice.ApprovalNo = "";

                            }

                            try
                            {
                                oRetailSalesInvoice.IsEMI = int.Parse(oItemRow.Cells[7].Value.ToString());
                            }
                            catch
                            {
                                oRetailSalesInvoice.IsEMI = -1;

                            }
                            try
                            {
                                oRetailSalesInvoice.NoOfInstallment = int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
                            }
                            catch
                            {
                                oRetailSalesInvoice.NoOfInstallment = -1;

                            }
                            try
                            {
                                oRetailSalesInvoice.InstrumentNo = oItemRow.Cells[9].Value.ToString().Trim();
                            }
                            catch
                            {
                                oRetailSalesInvoice.InstrumentNo = "";

                            }

                            try
                            {
                                oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oItemRow.Cells[10].Value.ToString().Trim());
                            }
                            catch
                            {
                                oRetailSalesInvoice.InstrumentDate = null;

                            }
                            oRetailSalesInvoice.InsertPayMode();

                        }

                    }

                    #endregion

                    #region E-Commerce Data Update

                    DataTran _oDataTran = new DataTran();
                    _oDataTran.TableName = "t_SalesInvoicePaymentMode";
                    _oDataTran.DataID = Convert.ToInt32(oSalesInvoice.InvoiceID);
                    _oDataTran.WarehouseID = oSalesInvoice.WarehouseID;
                    _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTran.BatchNo = 0;
                    _oDataTran.CreateDate = DateTime.Now.Date;
                    if (_oDataTran.CheckData())
                    {

                    }
                    else
                    {
                        _oDataTran.AddForTDPOS();
                    }
                    #endregion

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}