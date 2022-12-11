using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Report;
using CJ.Class.Report;

namespace CJ.POS.Invoice
{
    public partial class frmDealerInvoice : Form
    {
        SalesInvoice _oSalesInvoice;
        rptSalesInvoice _orptSalesInvoice;
        ProductDetail _oProductDetail;
        Users oUsers;
        WUIUtility _oWUIUtility;
        TELLib oTELLib;
        Banks _oBanks;
        Branchs _oBranchs;
        Employees _oEmployees;
        string _sFeildName;
        double _nPriceOption;
        Customer _oCustomer;
        Warehouses _oWarehouses;
        CustomerDetail _oCustomerDetail;
        SalesPromotion _oSalesPromotion;
        SalesPromotions _oSalesPromotions;
        SystemInfo oSystemInfo;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        CustomerTransaction _oCustomerTransaction;
        SalesInvoiceProductSerials _oSIPSs;
        InvoiceWisePayments _oInvoiceWisePayments;
        InvoiceWisePayment _oInvoiceWisePayment;
        string sSplit = "";
        string SL = "";
        bool IsSL = true;
        StockTran _oStockTran;

        int InitializeCondition = 0;
        int nUIControl = 0;

        public frmDealerInvoice(int _nUIControl)
        {
            InitializeComponent();
            InitializeCondition = 0;
            nUIControl = _nUIControl;
        }
        private void frmDealerInvoice_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadInstrumentType();
            LoadAllBank();

            if (nUIControl == 2)
            {
                dgvLineItem.Columns[3].ReadOnly = false;
                dgvLineItem.Columns[3].DefaultCellStyle.BackColor = Color.White;
                this.Text = "Dealer Invoice (Editable Unit Price)";
            }
            else if (nUIControl == 3)
            {
                dgvLineItem.Columns[3].ReadOnly = false;
                dgvLineItem.Columns[8].Visible = false;
                groupBox2.Enabled = false;
                dgvLineItem.Columns[3].DefaultCellStyle.BackColor = Color.White;
                this.Text = "Dealer Invoice (Editable Unit Price & Without IMEI)";
                txtIMEIList.Enabled = false;
                btIMEIValid.Enabled = false;
            }

        }
        private void btSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
            this.Cursor = Cursors.Default;

        }
        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oSalesInvoice = new SalesInvoice();
                _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice);
                _oSalesInvoice.InsertDealerInvoice();

                ///
                // Update Product Stock.
                ///
                foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                    oProductStock.Quantity = _oSalesInvoiceItem.Quantity;
                    oProductStock.WarehouseID = oSystemInfo.WarehouseID;

                    oProductStock.UpdateCurrentStock_POS(true);
                }

                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                _oStockTran = new StockTran();
                _oStockTran = GetDataForProductStockTran(_oStockTran);
                _oStockTran.TranTypeID = (int)Dictionary.ProductStockTranType.INVOICE;
                _oStockTran.InsertPOS(oSystemInfo.WarehouseID, false);

                

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_ProductStockTran";
                oDataTran.DataID = _oStockTran.TranID;
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;

                oDataTran.Add();

                ///
                // Insert in Customer Transaction and Update Customer Account.
                ///

                _oCustomerTransaction = new CustomerTransaction();
                _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oSalesInvoice);

                _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
                _oCustomerTransaction.AddPOS(true);

                if (_oCustomerTransaction.ReceiveAmount > 0)
                {
                    if (_oCustomerTransaction.ReceiveAmount == _oCustomerTransaction.Amount)
                    {
                        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_RECEIVE;
                    }
                    else
                    {
                        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_RECEIVE;
                    }
                    _oCustomerTransaction.Amount = _oCustomerTransaction.ReceiveAmount;

                    _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
                    _oCustomerTransaction.InstrumentNo = txtInsNo.Text.Trim();
                    _oCustomerTransaction.AddPOSDealer(false);
                }


                ///
                // Insert IMEI.
                ///
                if (nUIControl != 3)
                {
                    int nCount = 0;
                    int nProductID = 0;
                    foreach (SalesInvoiceProductSerial oSIPS in _oSalesInvoiceProductSerials)
                    {

                        if (nProductID != oSIPS.ProductID)
                        {
                            nCount = 0;
                            oSIPS.InvoiceID = _oSalesInvoice.InvoiceID;
                            oSIPS.ProductID = oSIPS.ProductID;
                            oSIPS.SerialNo = nCount + 1;
                            oSIPS.ProductSerialNo = oSIPS.ProductSerialNo;

                            oSIPS.AddIMEI();
                            nProductID = oSIPS.ProductID;
                            nCount++;
                        }
                        else
                        {
                            oSIPS.InvoiceID = _oSalesInvoice.InvoiceID;
                            oSIPS.ProductID = oSIPS.ProductID;
                            oSIPS.SerialNo = nCount + 1;
                            oSIPS.ProductSerialNo = oSIPS.ProductSerialNo;

                            oSIPS.AddIMEI();
                            nProductID = oSIPS.ProductID;
                            nCount++;
                        }
                    }
                }
                
                PrintInvice();
                if (_oCustomerTransaction.ReceiveAmount > 0)
                {
                    PrintMR(_oCustomerTransaction.TranID);
                }
                MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                return;
            }
        
        }

        private void PrintMR(int nTranID)
        {
            string sInvoiceHistory = "";
            string sPadding = "";
            oTELLib = new TELLib();
            CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
            oCustomerTransactionReport.Refresh(nTranID);
            _oInvoiceWisePayments = new InvoiceWisePayments();
            _oInvoiceWisePayments.Refresh(nTranID);

            _oInvoiceWisePayment = new InvoiceWisePayment();
            _oInvoiceWisePayment.CheckAdvanceAmt(nTranID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollectionPOS));

            doc.SetDataSource(oCustomerTransactionReport);


            sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount (Tk)";
            sInvoiceHistory = sInvoiceHistory + "\n";
            //sInvoiceHistory = sInvoiceHistory + _oSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _oSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
            string sResult = "";
            foreach (InvoiceWisePayment oInvoiceWisePayment in _oInvoiceWisePayments)
            {
                if (sResult == "")
                {
                    sResult = sResult + oInvoiceWisePayment.InvoiceNo + sPadding.PadRight((20 - 9), ' ') + "\t\t\t\t" + oInvoiceWisePayment.Amount;
                }
                else
                {
                    sResult = sResult + "\n" + oInvoiceWisePayment.InvoiceNo + sPadding.PadRight((20 - 9), ' ') + "\t\t\t\t" + oInvoiceWisePayment.Amount;

                }

            }
            if (_oInvoiceWisePayments.Count > 0)
            {
                sInvoiceHistory = sInvoiceHistory + sResult;
            }
            if (_oInvoiceWisePayment.AdvanceAmt > 0)
            {
                sInvoiceHistory = sInvoiceHistory + "\n";
                sInvoiceHistory = sInvoiceHistory + "Advance" + sPadding.PadRight((20 - 9), ' ') + "\t\t\t\t" + _oInvoiceWisePayment.AdvanceAmt.ToString();
            }
            //oTELLib.TakaFormat();
            //if (oUser.EmployeeID != -1)
            //{
            //    _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
            //    _oCustomerTransaction.Employee.ReadDB = true;
            //    doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
            //}
            //else 
            doc.SetParameterValue("JobLocation", "Sadar Road, Mohakhali C/A, Dhaka- 1206, Bangladesh");
            doc.SetParameterValue("PrintBy", Utility.Username);
            doc.SetParameterValue("InvoiceList", sInvoiceHistory);
            doc.SetParameterValue("PrintStatus", "Print By");
            doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
            doc.SetParameterValue("TranDate", _oInvoiceWisePayment.CreateDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerCode", ctlCustomer1.SelectedCustomer.CustomerCode);
            doc.SetParameterValue("CustomerName", ctlCustomer1.SelectedCustomer.CustomerName);
            doc.SetParameterValue("InstrumentType", cmbInstrumentType.Text);
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            if (cmbInstrumentType.Text != "CASH")
            {
                doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("Bank", cmbBank.Text);
                if (txtBranch.Text != "")
                    doc.SetParameterValue("Branch", txtBranch.Text);
                else doc.SetParameterValue("Branch", cmbBranch.Text);

            }
            else
            {
                doc.SetParameterValue("InstrumentNo", "N/A");
                doc.SetParameterValue("Date", "N/A");
                doc.SetParameterValue("Bank", "N/A");
                doc.SetParameterValue("Branch", "N/A");
            }
            doc.SetParameterValue("Amount", txtReceiveAmount.Text);
            doc.SetParameterValue("TK", oTELLib.TakaWords(Convert.ToDouble(txtReceiveAmount.Text.ToString())));
            doc.SetParameterValue("Remarks", txtRemarks.Text);

            //doc.PrintToPrinter(1, true, 1, 1);
            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);

        }
        private bool validateUIInput()
        {
            #region Order Master Information Validation

            if (ctlCustomer1.SelectedCustomer == null)
            {
                MessageBox.Show("Please enter a customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;

            }

            if (txtDeliveryAdd.Text == "")
            {
                MessageBox.Show("Please enter Deliver Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeliveryAdd.Focus();
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
                        MessageBox.Show("Please enter Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[4].Value.ToString().Trim() == "" || oItemRow.Cells[4].Value.ToString().Trim() == null)
                    {
                        MessageBox.Show("Please enter Product quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToInt32(oItemRow.Cells[4].Value) > Convert.ToInt32(oItemRow.Cells[7].Value))
                    {
                        MessageBox.Show("Invoice quantity must be less or equal stock quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (nUIControl != 3)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[4].Value) != Convert.ToInt32(oItemRow.Cells[8].Value))
                        {
                            MessageBox.Show("Please enter IMEI", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                }
            }


            double RcvAmt = 0;
            double ConfAmt = 0;

            RcvAmt = Convert.ToDouble(txtReceiveAmount.Text.Trim().ToString());
            ConfAmt = Convert.ToDouble(txtComfirmAmount.Text.Trim().ToString());

            //if (RcvAmt == 0)
            //{
            //    MessageBox.Show("Please enter Receive Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtReceiveAmount.Focus();
            //    return false;
            //}
            //if (ConfAmt == 0)
            //{
            //    MessageBox.Show("Please enter Confirm Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtComfirmAmount.Focus();
            //    return false;
            //}
            if (RcvAmt != ConfAmt)
            {
                MessageBox.Show("Receive amount must be equal to Confirm Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComfirmAmount.Focus();
                return false;
            }
            if (RcvAmt > Convert.ToDouble(txtAmountToPay.Text))
            {
                MessageBox.Show("Receive amount must be equal or less than To pay amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceiveAmount.Focus();
                return false;
            }
            if (Convert.ToDouble(txtAmountToPay.Text) > (_oCustomerDetail.CurrentBalance + _oCustomer.MinCreditLimit + RcvAmt))
            {
                MessageBox.Show("There is no sufficient credit limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceiveAmount.Focus();
                return false;
            }
            if (RcvAmt > 0)
            {
                if (cmbInstrumentType.Text != "CASH")
                {
                    if (cmbBank.Text == "Select.....")
                    {
                        MessageBox.Show("Please select a bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (txtInsNo.Text == "")
                        {
                            MessageBox.Show("Please enter instrument number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }

                }
            }


            #endregion
            return true;
        }
        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
        {
            _oSalesInvoice.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oSalesInvoice.DeliveryAddress = txtDeliveryAdd.Text;
            _oSalesInvoice.SalesPersonID = _oEmployees[cmbSalesPerson.SelectedIndex].EmployeeID;
            _oSalesInvoice.WarehouseID = oSystemInfo.WarehouseID;
            _oSalesInvoice.Remarks = txtRemarks.Text;

            if (Convert.ToDouble(txtReceiveAmount.Text) == Convert.ToDouble(txtAmountToPay.Text))
            {
                _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CASH;
            }
            else
            {
                _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CREDIT;
            }

            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
            if (cmbPromotion.SelectedIndex != -1)
            {
                _oSalesInvoice.SalesPromotionID = _oSalesPromotions[cmbPromotion.SelectedIndex].SalesPromotionID;
            }
            else
            {
                _oSalesInvoice.SalesPromotionID = 0;
            }
            _oSalesInvoice.Discount = Convert.ToDouble(txtTradeDiscount.Text.ToString());
            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(txtAmountToPay.Text.ToString());

            if (Convert.ToDouble(txtReceiveAmount.Text) == Convert.ToDouble(txtAmountToPay.Text))
            {
                _oSalesInvoice.DueAmount = 0;
            }
            else if ((Convert.ToDouble(txtReceiveAmount.Text) + _oCustomerDetail.CurrentBalance) >= Convert.ToDouble(txtAmountToPay.Text))
            {
                _oSalesInvoice.DueAmount = 0;
            }
            else 
            {
                _oSalesInvoice.DueAmount = Convert.ToDouble(txtAmountToPay.Text) - Convert.ToDouble(txtReceiveAmount.Text);
            }

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                    _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString().Trim());
                    _oSalesInvoiceItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                    _oProductDetail.Refresh();
                    _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                    _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                    if (_oSalesInvoiceItem.UnitPrice == 0)
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);

                    _oSalesInvoiceItem.AdjustedDPAmount = 0;
                    _oSalesInvoiceItem.AdjustedPWAmount = 0;
                    _oSalesInvoiceItem.AdjustedTPAmount = 0;

                    _oSalesInvoiceItem.PromotionalDiscount = Convert.ToDouble(oItemRow.Cells[5].Value.ToString().Trim());

                    _oSalesInvoiceItem.IsFreeProduct = 0;
                    _oSalesInvoiceItem.FreeQty = 0;

                    _oSalesInvoice.Add(_oSalesInvoiceItem);
                }
            }
          
            return _oSalesInvoice;
        }
        ///
        // Get Data for  ProductStockTran and ProductStockTranItem.
        ///
        public StockTran GetDataForProductStockTran(StockTran _oStockTran)
        {
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            _oStockTran.LastUpdateDate = oSystemInfo.OperationDate;
            _oStockTran.CreateDate = oSystemInfo.OperationDate;
            _oStockTran.TranNo = _oSalesInvoice.RefDetails;
            _oStockTran.TranDate = oSystemInfo.OperationDate;
            _oStockTran.FromWHID = oSystemInfo.WarehouseID;
            _oStockTran.FromChannelID = Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLChannel"].ToString()); ;
            _oStockTran.UserID = Utility.UserId;
            _oStockTran.Remarks = txtRemarks.Text;


            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {

                    StockTranItem _oStockTranItem = new StockTranItem();

                    _oStockTranItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString().Trim());
                    _oStockTranItem.StockPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    _oStockTranItem.Qty = int.Parse(oItemRow.Cells[4].Value.ToString().Trim());

                    _oStockTran.Add(_oStockTranItem);
                }
            }

            return _oStockTran;
        }
        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            _oCustomerTransaction.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate =Convert.ToDateTime(oSystemInfo.OperationDate);

            _oCustomerTransaction.Amount = Convert.ToDouble(txtAmountToPay.Text.ToString());
            _oCustomerTransaction.BalanceAmount = Convert.ToDouble(txtAmountToPay.Text) - Convert.ToDouble(txtReceiveAmount.Text);
            
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.ReceiveAmount = Convert.ToDouble(txtReceiveAmount.Text.ToString());
            if (Convert.ToDouble(txtReceiveAmount.Text.Trim()) == Convert.ToDouble(txtAmountToPay.Text.Trim()))
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
            }
            else
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE;
            }
            if (Convert.ToDouble(txtReceiveAmount.Text) > 0)
            {
                _oCustomerTransaction.InstrumentType = cmbInstrumentType.SelectedIndex;
                if (cmbInstrumentType.Text != "CASH")
                {
                    Branch oBranch = _oBranchs[cmbBranch.SelectedIndex];
                    _oCustomerTransaction.InstrumentNo = txtInsNo.Text;
                    _oCustomerTransaction.BranchID = oBranch.BranchID;
                    if (txtBranch.Text != "")
                    {
                        _oCustomerTransaction.BranchName = txtBranch.Text;
                    }
                    else
                    {
                        _oCustomerTransaction.BranchName = cmbBranch.Text;
                    }
                    _oCustomerTransaction.InstrumentDate = dtInstrudate.Value.Date;
                }
                if (chkInsStatus.Checked == true)
                {
                    _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
                }
                else
                {
                    _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.NOT_APPROVED;
                }
            }
            else
            {
                _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            }

            return _oCustomerTransaction;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadInstrumentType()
        {
            foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(GetEnum);
            }
            cmbInstrumentType.SelectedIndex = 0;
        }
        public void LoadAllBank()
        {

            //DBController.Instance.OpenNewConnection();
            _oBanks = new Banks();
            _oBanks.Refresh();

            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            //
            //cmbBank.Text = "Select.....";
            cmbBank.Items.Add("Select.....");
            if (_oBanks.Count > 0)
            {
                cmbBank.SelectedIndex = _oBanks.Count;
            }
        }
        public void LoadBranchforBank()
        {
            
            if (cmbBank.Text != "Select.....")
            {
                //cmbBranch.Items.Clear();
                _oBranchs = new Branchs();
                DBController.Instance.OpenNewConnection();
                _oBanks = new Banks();
                _oBanks.Refresh();
                _oBranchs.Refresh(_oBanks[cmbBank.SelectedIndex].BankID);
                cmbBranch.Items.Clear();

                foreach (Branch oBranch in _oBranchs)
                {
                    cmbBranch.Items.Add(oBranch.Name);
                }
                if (_oBranchs.Count > 0)
                {
                    cmbBranch.SelectedIndex = 0;
                }
            }
            else 
            {
                cmbBranch.Items.Clear();
            }
        }
        protected void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBranchforBank();
        }
        protected void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.Text == "CASH")
            {
                txtInsNo.Text = "";
                txtInsNo.Enabled = false;

                cmbBank.Enabled = false;
                cmbBranch.Enabled = false;
                dtInstrudate.Enabled = false;

            }
            else
            {
                txtInsNo.Text = "";
                txtInsNo.Enabled = true;

                cmbBank.Enabled = true;
                cmbBranch.Enabled = true;
                dtInstrudate.Enabled = true;

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
            {

                lblchannel.Text = _oCustomerDetail.ChannelDescription;
                lblchannel.Visible = true;
            }
            else
            {
                lblchannel.Text = "NA";
                lblchannel.Visible = true;
            }

            if (_oCustomerDetail.CustomerTypeName != null)
            {
                lblCustomerTypeDescription.Text = _oCustomerDetail.CustomerTypeName;
                lblCustomerTypeDescription.Visible = true;
            }
            else
            {
                lblCustomerTypeDescription.Text = "NA";
                lblCustomerTypeDescription.Visible = true;
            }

            if (_oCustomerDetail.AreaName != null)
            {
                lblArea.Text = _oCustomerDetail.AreaName;
                lblArea.Visible = true;
            }
            else
            {
                lblArea.Text = "NA";
                lblArea.Visible = true;
            }

            if (_oCustomerDetail.TerritoryName != null)
            {
                lblTerritory.Text = _oCustomerDetail.TerritoryName;
                lblTerritory.Visible = true;
            }
            else
            {
                lblTerritory.Text = "NA";
                lblTerritory.Visible = true;
            }

            if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
            {
                lblAPO.Text = "NSP";
                _sFeildName = "NSP";
                _nPriceOption = (long)Dictionary.PriceOption.NSP;
                lblAPO.Visible = true;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.RSP)
            {
                lblAPO.Text = "RSP";
                _sFeildName = "RSP";
                _nPriceOption = (long)Dictionary.PriceOption.RSP;
                lblAPO.Visible = true;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
            {
                lblAPO.Text = "Special Price";
                _sFeildName = "Special Price";
                _nPriceOption = (long)Dictionary.PriceOption.Special_Price;
                lblAPO.Visible = true;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Cost_Price)
            {
                lblAPO.Text = "Cost Price";
                _nPriceOption = (long)Dictionary.PriceOption.Cost_Price;
                lblAPO.Visible = true;
            }
            else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Trade_Price)
            {
                lblAPO.Text = "Trade Price";
                _nPriceOption = (long)Dictionary.PriceOption.Trade_Price;
                lblAPO.Visible = true;
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
                lblOD.Visible = true;
            }
            else
            {
                lblOD.Text = "Other Discount Not Applicable";
                lblOD.Visible = true;
            }
            if (_oCustomerDetail.CurrentBalance != 0)
            {
                lblCustomerBal.Text = _oCustomerDetail.CurrentBalance.ToString();
                lblCustomerBal.Visible = true;
            }
            else
            {
                lblCustomerBal.Text = "0.00";
                lblCustomerBal.Visible = true;
            }
            if (_oCustomer.MinCreditLimit != 0)
            {
                lblCreditLimit.Text = _oCustomer.MinCreditLimit.ToString();
                lblCreditLimit.Visible = true;
            }
            else
            {
                lblCreditLimit.Text = "0.00";
                lblCreditLimit.Visible = true;
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

            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            cmbWarehouse.Items.Add(oSystemInfo.WarehouseName);
            cmbWarehouse.SelectedIndex = 0;

            _oSalesPromotions = new SalesPromotions();
            _oSalesPromotions.RefreshForSalesOrderPOS(_oCustomerDetail.CustomerID);

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
                    else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.SpecialPrice.ToString();
                    }
                    else
                    {
                        oRow.Cells[3].Value = oForm._oProductDetail.RSP.ToString();
                    }
                    oRow.Cells[9].Value = oForm._oProductDetail.ProductID;

                    _oWUIUtility = new WUIUtility();
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    _oWUIUtility.GetCurrentStock(oSystemInfo.ChannelID, oSystemInfo.WarehouseID, oForm._oProductDetail.ProductID);
                    if (_oWUIUtility.CurrentStock != 0)
                    {
                        oRow.Cells[7].Value = _oWUIUtility.CurrentStock.ToString();
                    }
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
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = (_oProductDetail.ProductID).ToString();


                        if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.NSP.ToString();
                        }
                        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.SpecialPrice.ToString();
                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP.ToString();
                        }

                        _oWUIUtility = new WUIUtility();
                        oSystemInfo = new SystemInfo();
                        oSystemInfo.Refresh();
                        _oWUIUtility.GetCurrentStock(oSystemInfo.ChannelID, oSystemInfo.WarehouseID, _oProductDetail.ProductID);
                        if (_oWUIUtility.CurrentStock != 0)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = _oWUIUtility.CurrentStock.ToString();
                        }
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
            //else if (nColumnIndex == 3)
            //{
            //    long nRem = 0;
            //    long nQuotient = 0;

            //    if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            //    {
            //        _oSalesPromotion = new SalesPromotion();

            //        _oSalesPromotion.RefreshByCustomerIDandProductIDPOS(_oCustomerDetail.CustomerID, Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[9].Value.ToString()));
            //        dgvLineItem.Rows[nRowIndex].Cells[5].Value = _oSalesPromotion.Discount * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString());
            //        dgvLineItem.Rows[nRowIndex].Cells[6].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString()) - Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[5].Value.ToString());
            //    }
            //    cmbWarehouse.Enabled = false;
            //    ctlCustomer1.Enabled = false;
            //    GetTotalAmount();
            //}
            else if (nColumnIndex == 4)
            {
                long nRem = 0;
                long nQuotient = 0;
                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
                {
                    _oSalesPromotion = new SalesPromotion();

                    _oSalesPromotion.RefreshByCustomerIDandProductIDPOS(_oCustomerDetail.CustomerID, Convert.ToInt32(dgvLineItem.Rows[nRowIndex].Cells[9].Value.ToString()));
                    dgvLineItem.Rows[nRowIndex].Cells[5].Value = _oSalesPromotion.Discount * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString());
                    dgvLineItem.Rows[nRowIndex].Cells[6].Value = Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[3].Value.ToString()) * Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[4].Value.ToString()) - Convert.ToDouble(dgvLineItem.Rows[nRowIndex].Cells[5].Value.ToString());
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
            oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[6].Value != null)
                {
                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString())).ToString();

                }
            }
            txtAmountToPay.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)).ToString();

        }
        private void txtTradeDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalAmount.Text.Trim() != "")
            {
                txtAmountToPay.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) - Convert.ToDouble(txtTradeDiscount.Text)).ToString();
            }
        }
        private void btIMEIValid_Click(object sender, EventArgs e)
        {
            int IMEIQty = 0;
            if (txtIMEIList.Text.Trim() != "")
            {
                if (InitializeCondition == 0)
                {
                    _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
                }
                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                string value = txtIMEIList.Text;
                char[] delimiter = new char[] { '\r', '\n' };
                string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {

                    sSplit = parts[i].ToString();

                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                    _oSalesInvoiceProductSerial.ProductSerialNo = sSplit.Trim();
                    DBController.Instance.OpenNewConnection();
                    _oSalesInvoiceProductSerial.GetProductIDByIMEI();

                    
                    if (dgvLineItem.Rows.Count > 1)
                    {

                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Cells[4].Value != null)
                            {
                                if ((oItemRow.Cells[0].Value.ToString().Trim()) == _oSalesInvoiceProductSerial.ProductCode)
                                {

                                    if (oItemRow.Cells[8].Value == null)
                                    {
                                        IMEIQty = 0;
                                        if (IMEIQty <= Convert.ToInt32(oItemRow.Cells[4].Value))
                                        {
                                            oItemRow.Cells[8].Value = IMEIQty + 1;

                                            _oSalesInvoiceProductSerial.ProductID = _oSalesInvoiceProductSerial.ProductID;
                                            _oSalesInvoiceProductSerial.ProductSerialNo = sSplit;
                                            _oSalesInvoiceProductSerials.Add(_oSalesInvoiceProductSerial);

                                            InitializeCondition = 1;
                                        }

                                    }
                                    else
                                    {

                                        if (IMEICheckFromCollection())
                                        {
                                            if (Convert.ToInt32(oItemRow.Cells[8].Value) < Convert.ToInt32(oItemRow.Cells[4].Value))
                                            {
                                                oItemRow.Cells[8].Value = Convert.ToInt32(oItemRow.Cells[8].Value) + 1;

                                                _oSalesInvoiceProductSerial.ProductID = _oSalesInvoiceProductSerial.ProductID;
                                                _oSalesInvoiceProductSerial.ProductSerialNo = sSplit;
                                                _oSalesInvoiceProductSerials.Add(_oSalesInvoiceProductSerial);
                                            }


                                        }
                                        else
                                        {
                                        }
                                    }

                                }

                            }

                        }

                    }

                }
                txtIMEIList.Text = "";
            }
            else
            {
                MessageBox.Show("There is no IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool IMEICheckFromCollection()
        {
            foreach (SalesInvoiceProductSerial oSIPS in _oSalesInvoiceProductSerials)
            {
                if (oSIPS.ProductSerialNo != sSplit)
                {
                    return true;
                }
            }

            return false;
        }
        public void InvoiceWiseBarcode()
        {
            SL = "";

            //SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(_oSalesInvoice.InvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {
                IsSL = true;
                string PCode = "";

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {
                    IsSL = false;
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
        public void PrintInvice()
        {
            InvoiceWiseBarcode();
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshPOSDealer();

            #region InvoicePrint

            if (Utility.CompanyInfo == "TML")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                doc.SetDataSource(_orptSalesInvoice);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
                doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
                doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
                doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                doc.SetParameterValue("OrderDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("OrderNo", _orptSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.DeliveredByName.ToString());
                doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
                doc.SetParameterValue("IsSL", IsSL);
                doc.SetParameterValue("SL", SL);
                doc.SetParameterValue("CompanyInfo", "TML");
                if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Delivery Breakage Replacement");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
                {
                    doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Product Return");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
                }
                else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                {
                    doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
                }

                doc.SetParameterValue("InvoiceHeader", "Customer Copy");
                //doc.PrintToPrinter(1, true, 1, 1);
                //doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
                //doc.PrintToPrinter(1, true, 1, 1);

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);

            }
            #endregion

            #region Print Customer Receive Copy

            if (Utility.CompanyInfo == "TML")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceive));
                docCus.SetDataSource(_orptSalesInvoice);

                docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                docCus.SetParameterValue("OrderDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                docCus.SetParameterValue("OrderNo", _orptSalesInvoice.InvoiceNo.ToString());
                docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                docCus.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                docCus.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                docCus.SetParameterValue("CompanyInfo", "TML");

                //docCus.PrintToPrinter(1, true, 1, 1);

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(docCus);
            }
            #endregion

        }
    }
}