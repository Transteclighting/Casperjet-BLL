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
using CJ.Class.Report;
using CJ.Class.Duty;
using CJ.Class.Web.UI.Class;

namespace CJ.Win.Process
{
    public partial class frmTDVATProcess : Form
    {
        SalesInvoices _oSalesInvoices;
        Warehouse oWarehouse;
        Customer oCustomer;
        TELLib oTELLib;
        rptSalesInvoice _orptSalesInvoice;
        DutyTran oDutyTran;
        TDOldStock oTDOldStock;
        ProductDetail _oProductDetail;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        DutyAccount oDutyAccount;

        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;
        int[] ProductIDList ={ 9,1823,2810,2935,2936,2937 };
        
        public frmTDVATProcess()
        {
            InitializeComponent();
        }

        private void frmTDVATProcess_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RefreshData();
            this.Cursor = Cursors.Default;
        }
        public void RefreshData()
        {
            lvwInvoice.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSalesInvoices = new SalesInvoices();

            if (rdbTD.Checked)
                _oSalesInvoices.RefreshForTDVatProcess(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text);
            else if (rdbHO.Checked)
                _oSalesInvoices.RefreshVatProcess(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text);
            else return;

            foreach (SalesInvoice _SalesInvoice in _oSalesInvoices)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(_SalesInvoice.InvoiceNo.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(_SalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
             
                oWarehouse = new Warehouse();
                oWarehouse.WarehouseID = _SalesInvoice.WarehouseID;
                oWarehouse.Reresh();
                lstItem.SubItems.Add(oWarehouse.WarehouseName);
               
                lstItem.Tag = _SalesInvoice;

            }
            this.Text = "Total Invoices [" + _oSalesInvoices.Count.ToString() + "]";
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_oSalesInvoices == null)
                return;
            if (_oSalesInvoices.Count > 0)
            {
                pbTransfer.Visible = true;
                pbTransfer.Minimum = 0;
                pbTransfer.Maximum = _oSalesInvoices.Count;
                pbTransfer.Step = 1;
                pbTransfer.Value = 0;
                foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        if (rdbTD.Checked)
                        {
                            _DutyImportBalance = 0;
                            _DutyLocalBalance = 0;

                            oDutyTranVAT11 = GetDataForTDVAT11(oDutyTranVAT11, oSalesInvoice);
                            oDutyTranVAT11KA = GetDataForTDVAT11KA(oDutyTranVAT11KA, oSalesInvoice);

                            if (oDutyTranVAT11.Amount > 0)
                            {
                                oDutyTranVAT11.InsertForTDVat();
                                oDutyAccount = new DutyAccount();
                                oDutyAccount.DutyAccountTypeID = oDutyTranVAT11.DutyAccountID;
                                oDutyAccount.Balance = _DutyImportBalance;
                                oDutyAccount.UpdateBalance(true);
                            }
                            if (oDutyTranVAT11KA.Amount > 0)
                            {
                                oDutyTranVAT11KA.InsertForTDVat();
                                oDutyAccount = new DutyAccount();
                                oDutyAccount.DutyAccountTypeID = oDutyTranVAT11KA.DutyAccountID;
                                oDutyAccount.Balance = _DutyLocalBalance;
                                oDutyAccount.UpdateBalance(true);
                            }
                            DBController.Instance.CommitTransaction();
                            pbTransfer.PerformStep();
                        }
                        if (rdbHO.Checked)
                        {
                            _DutyImportBalance = 0;
                            _DutyLocalBalance = 0;

                            oDutyTranVAT11 = GetDataForInvoiceVAT11(oDutyTranVAT11, oSalesInvoice);
                            oDutyTranVAT11KA = GetDataForInvoiceVAT11KA(oDutyTranVAT11KA, oSalesInvoice);

                            if (oDutyTranVAT11.Count > 0)
                            {
                                oDutyTranVAT11.InsertForInvoiceVat();
                                oDutyAccount = new DutyAccount();
                                oDutyAccount.DutyAccountTypeID = oDutyTranVAT11.DutyAccountID;
                                oDutyAccount.Balance = _DutyImportBalance;
                                if (oDutyTranVAT11.DutyTranTypeID == (int)Dictionary.DutyTranType.INVOICE)
                                    oDutyAccount.UpdateBalance(true);
                                else oDutyAccount.UpdateBalance(false);
                            }
                            if (oDutyTranVAT11KA.Count > 0)
                            {
                                oDutyTranVAT11KA.InsertForInvoiceVat();
                                oDutyAccount = new DutyAccount();
                                oDutyAccount.DutyAccountTypeID = oDutyTranVAT11KA.DutyAccountID;
                                oDutyAccount.Balance = _DutyLocalBalance;
                                if (oDutyTranVAT11KA.DutyTranTypeID == (int)Dictionary.DutyTranType.INVOICE)
                                    oDutyAccount.UpdateBalance(true);
                                else oDutyAccount.UpdateBalance(false);
                            }
                            DBController.Instance.CommitTransaction();
                            pbTransfer.PerformStep();
                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                        continue;
                    }                   
                }
            }
            MessageBox.Show("You Have Successfully Process", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pbTransfer.Visible = false;
            lvwInvoice.Items.Clear();

        }

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForTDVAT11KA(DutyTran oDutyTranVAT11KA, SalesInvoice oSalesInvoice)
        {
            oDutyTranVAT11KA = new DutyTran();

            oDutyTranVAT11KA.DutyTranNo = oSalesInvoice.VATChallanNo.ToString();
            oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
            oDutyTranVAT11KA.WHID = oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = (int)oSalesInvoice.InvoiceID;
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11KA.Remarks = oSalesInvoice.Remarks;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oTDOldStock = new TDOldStock();

                    oDutyTranDetail.ProductID = oItem.ProductID;

                    oTDOldStock.ProductID = oItem.ProductID;
                    oTDOldStock.WHID = oSalesInvoice.WarehouseID;
                    int nInvoiceQty = (int)oItem.Quantity + (int)oItem.FreeQty;
                    oDutyTranDetail.Qty = oTDOldStock.GetVatQuantity(nInvoiceQty);
                    oDutyTranDetail.DutyPrice = oItem.UnitPrice / (1 + oItem.VATAmount);
                    oDutyTranDetail.DutyRate = oItem.VATAmount;

                    _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForTDVAT11(DutyTran oDutyTranVAT11, SalesInvoice oSalesInvoice)
        {
            oDutyTranVAT11 = new DutyTran();

            oDutyTranVAT11.DutyTranNo = oSalesInvoice.VATChallanNo.ToString();
            oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
            oDutyTranVAT11.WHID = oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = (int)oSalesInvoice.InvoiceID;
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11.Remarks = oSalesInvoice.Remarks;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oTDOldStock = new TDOldStock();

                    oDutyTranDetail.ProductID = oItem.ProductID;

                    oTDOldStock.ProductID = oItem.ProductID;
                    oTDOldStock.WHID = oSalesInvoice.WarehouseID;
                    int nInvoiceQty = (int)oItem.Quantity + (int)oItem.FreeQty;
                    oDutyTranDetail.Qty = oTDOldStock.GetVatQuantity(nInvoiceQty);
                    oDutyTranDetail.DutyPrice = oItem.UnitPrice / (1 + oItem.VATAmount);
                    oDutyTranDetail.DutyRate = oItem.VATAmount;

                    _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForInvoiceVAT11KA(DutyTran oDutyTranVAT11KA, SalesInvoice oSalesInvoice)
        {
            oDutyTranVAT11KA = new DutyTran();

            if (oSalesInvoice.VATChallanNo != 0)
                oDutyTranVAT11KA.DutyTranNo = oSalesInvoice.VATChallanNo.ToString();
            else oDutyTranVAT11KA.DutyTranNo = "RE-" + oSalesInvoice.InvoiceNo.ToString();
        
            if (oSalesInvoice.DeliveryDate != null)
                oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(oSalesInvoice.DeliveryDate);
            else oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);      
            oDutyTranVAT11KA.WHID = oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = (int)oSalesInvoice.InvoiceID;
            oDutyTranVAT11KA.DutyTranTypeID = GetDutyTranType(oSalesInvoice);
            oDutyTranVAT11KA.Remarks = oSalesInvoice.Remarks;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
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
                            oCustomerDetail.CustomerID = oSalesInvoice.CustomerID;
                            oCustomerDetail.refresh();

                            if (oCustomerDetail.ChannelType==(int)Dictionary.ChannelType.DISTRIBUTION)
                            {
                                oDutyTranDetail.DutyPrice = _oProductDetail.NSP / (1 + oItem.VATAmount);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                            else
                            {
                                oDutyTranDetail.DutyPrice = _oProductDetail.RSP / (1 + oItem.VATAmount);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = oItem.UnitPrice / (1 + _oProductDetail.Vat);
                            oDutyTranDetail.DutyRate = _oProductDetail.Vat;
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
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForInvoiceVAT11(DutyTran oDutyTranVAT11, SalesInvoice oSalesInvoice)
        {
            oDutyTranVAT11 = new DutyTran();

            if (oSalesInvoice.VATChallanNo != 0)
                oDutyTranVAT11.DutyTranNo = oSalesInvoice.VATChallanNo.ToString();
            else oDutyTranVAT11.DutyTranNo = "RE-" + oSalesInvoice.InvoiceNo.ToString();

            if (oSalesInvoice.DeliveryDate != null)
                oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(oSalesInvoice.DeliveryDate);
            else oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);      
            oDutyTranVAT11.WHID = oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = (int)oSalesInvoice.InvoiceID;
            oDutyTranVAT11.DutyTranTypeID = GetDutyTranType(oSalesInvoice);          
            oDutyTranVAT11.Remarks = oSalesInvoice.Remarks;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
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
                            oCustomerDetail.CustomerID = oSalesInvoice.CustomerID;
                            oCustomerDetail.refresh();

                            if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                            {
                                oDutyTranDetail.DutyPrice = _oProductDetail.NSP / (1 + oItem.VATAmount);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                            else
                            {
                                oDutyTranDetail.DutyPrice = _oProductDetail.RSP / (1 + oItem.VATAmount);
                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = oItem.UnitPrice / (1 + _oProductDetail.Vat);
                            oDutyTranDetail.DutyRate = _oProductDetail.Vat;
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
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        private void rdbTD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTD.Checked)
                rdbHO.Checked = false;
            RefreshData();
        }

        private void rdbHO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbHO.Checked)
                rdbTD.Checked = false;
            RefreshData();
        }

        public int GetDutyTranType(SalesInvoice oSalesInvoice)
        {
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH_REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CREDIT)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CREDIT_REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EASY_BUY)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EASY_BUY_REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EPS_REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.IB_SERVICE_INVOICE)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.PRODUCT_RETURN)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.REPLACEMENT)
                return (int)Dictionary.DutyTranType.INVOICE;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.REPLACEMENT_REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            if (oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.REVERSE)
                return (int)Dictionary.DutyTranType.REVERSE_RETURN;
            return 0;
           
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

     

       
    }
}