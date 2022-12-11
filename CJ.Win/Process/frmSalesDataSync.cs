using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Process;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.Process
{
    public partial class frmSalesDataSync : Form
    {
        SalesDataSync _oSalesDataSync;
        SalesDataSyncs _oSalesDataSyncs;
        SalesInvoices _oSalesInvoices;
        SalesInvoice _oSalesInvoice;
        CustomerTransaction _oCustomerTransaction;
        ProductStock _oProductStock;
        ProductTransaction _oProductTransaction;
        ProductTransactionDetail _oProductTransactionDetail;
        Customer _oCustomer;
        TELLib _oTELLib;
        public frmSalesDataSync()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataLoadControl();
            if (_oSalesDataSyncs.Count > 0)
            {
                btnUpload.Visible = true;
            }

        }
        private void DataLoadControl()
        {

            _oSalesDataSyncs = new SalesDataSyncs();

            lvwData.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {
                _oSalesDataSyncs.Refresh();
            }
            this.Text = "Total " + "[" + _oSalesDataSyncs.Count + "]";
            double _TotalAmount = 0;
            _oTELLib = new TELLib();
            foreach (SalesDataSync oSalesDataSync in _oSalesDataSyncs)
            {
                ListViewItem oItem = lvwData.Items.Add(oSalesDataSync.InvoiceID.ToString());
                oItem.SubItems.Add(oSalesDataSync.InvoiceNo.ToString());
                oItem.SubItems.Add(oSalesDataSync.InvoiceDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSalesDataSync.Customer.ToString());
                oItem.SubItems.Add(oSalesDataSync.Warehouse.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oSalesDataSync.InvoiceAmount).ToString());
                oItem.SubItems.Add("");
                _TotalAmount = _TotalAmount + oSalesDataSync.InvoiceAmount;
                oItem.Tag = oSalesDataSync;
            }
            txtTotalAmount.Text = _oTELLib.TakaFormat(_TotalAmount).ToString();

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DataUpLoadControl();
            btnUpload.Visible = false;
        }
        private void DataUpLoadControl()
        {
            int nIndex = -1;
            int nTotalSuccess = 0;
            int nTotalUnSuccess = 0;

            foreach (SalesDataSync oSalesDataSync in _oSalesDataSyncs)
            {
                nIndex++;
                
                _oSalesInvoice = new SalesInvoice();
                _oCustomerTransaction = new CustomerTransaction();
                _oSalesInvoice.GetWSSalesInvoice(oSalesDataSync.InvoiceID);

                if (_oSalesInvoice.CheckInvoiceNo(_oSalesInvoice.InvoiceNo))
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oSalesInvoice.InsertInvoiceRetail();

                        _oCustomerTransaction.TranNo = _oSalesInvoice.InvoiceNo + "WH:" + _oSalesInvoice.WarehouseID;
                        _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
                        _oCustomerTransaction.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate.ToString());
                        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
                        _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
                        _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;

                        _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
                        _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;
                        _oCustomerTransaction.Terminal = (int)Dictionary.Terminal.Branch_Office;
                        _oCustomerTransaction.EntryDate = DateTime.Now;
                        _oCustomerTransaction.EntryUserID = _oSalesInvoice.UserID;
                        _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
                        _oCustomerTransaction.UserID = _oSalesInvoice.InvoiceBy;

                        _oProductTransaction = new ProductTransaction();
                        _oProductTransaction.TranNo = _oCustomerTransaction.TranNo;//doya kore noraban na bhai.

                        _oCustomerTransaction.AddTran(true);


                        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_RECEIVE;
                        _oCustomerTransaction.AddForRetailInvoice(true);


                        _oProductTransaction.TranDate = _oCustomerTransaction.TranDate;
                        _oProductTransaction.FromWHID = _oSalesInvoice.WarehouseID;
                        _oCustomer = new Customer();
                        _oCustomer.GetCustomerAddressByID(_oSalesInvoice.CustomerID);
                        _oProductTransaction.FromChannelID = _oCustomer.ChannelID;
                        _oProductTransaction.UserID = _oCustomerTransaction.UserID;
                        _oProductTransaction.Remarks = _oSalesInvoice.Remarks;
                        _oProductTransaction.Terminal = (int)Dictionary.Terminal.Branch_Office;

                        _oProductTransaction.InsertWSStockTran();

                        int nItemCount = 0;
                        int nSuccessItemCount = 0;

                        foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                        {
                            nItemCount++;

                            _oProductStock = new ProductStock();
                            _oProductStock.ProductID = oSalesInvoiceItem.ProductID;
                            _oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                            _oProductStock.ChannelID = Utility.SESChannel;
                            _oProductStock.Quantity = oSalesInvoiceItem.Quantity;

                            if (_oProductStock.CheckProductStockBy())
                            {
                                
                                if ((_oProductStock.CurrentStock - _oProductStock.BookingStock) >= _oProductStock.Quantity)
                                {
                                    nSuccessItemCount++;
                                    _oProductStock.UpdateCurrentStock(false);

                                    _oProductTransactionDetail = new ProductTransactionDetail();
                                    _oProductTransactionDetail.ProductID = oSalesInvoiceItem.ProductID;
                                    _oProductTransactionDetail.Qty = oSalesInvoiceItem.Quantity;
                                    _oProductTransactionDetail.StockPrice = oSalesInvoiceItem.CostPrice;

                                    _oProductTransactionDetail.Insert(_oProductTransaction.TranID);

                                    lvwData.Items[nIndex].SubItems[6].Text = "Successed";
                                    lvwData.Items[nIndex].ForeColor = Color.Green;
                                    lvwData.Refresh();
                                    nTotalSuccess++;
                                }
                                else
                                {
                                    DBController.Instance.RollbackTransaction();
                                    DBController.Instance.OpenNewConnection();
                                    lvwData.Items[nIndex].SubItems[6].Text = "Insufficient Stock";
                                    lvwData.Items[nIndex].ForeColor = Color.Red;
                                    lvwData.Refresh();
                                    nTotalUnSuccess++;
                                }

                            }
                            else
                            {
                                DBController.Instance.RollbackTransaction();
                                DBController.Instance.OpenNewConnection();
                                lvwData.Items[nIndex].SubItems[6].Text = "Invalid Product";
                                lvwData.Items[nIndex].ForeColor = Color.Red;
                                lvwData.Refresh();
                                nTotalUnSuccess++;
                            }

                        }
                        if (nItemCount == nSuccessItemCount)
                        {
                            oSalesDataSync.DeleteWSSalesInvoice(oSalesDataSync.InvoiceID);
                        }
                        DBController.Instance.CommitTran();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();

                        lvwData.Items[nIndex].SubItems[6].Text = "" + ex + "";
                        lvwData.Items[nIndex].ForeColor = Color.Red;
                        lvwData.Refresh();
                        nTotalUnSuccess++;
                    }

                }
                else
                { 
                    lvwData.Items[nIndex].SubItems[6].Text = "Duplicate Invoice";
                    lvwData.Items[nIndex].ForeColor = Color.Red;
                    lvwData.Refresh();
                    nTotalUnSuccess++;
                
                }

            }

            MessageBox.Show("Upload Status... \n Success=" + nTotalSuccess + "\n Unsuccess=" + nTotalUnSuccess + "\n Total=" + _oSalesDataSyncs.Count + "", "Upload Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmSalesDataSync_Load(object sender, EventArgs e)
        {
            btnUpload.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to View Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesDataSync oSalesDataSync = (SalesDataSync)lvwData.SelectedItems[0].Tag;

            frmSalesDataSyncItem oForm = new frmSalesDataSyncItem();
            oForm.ShowDialog(oSalesDataSync);
            DataLoadControl();
        }

        private void lvwData_DoubleClick(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to View Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesDataSync oSalesDataSync = (SalesDataSync)lvwData.SelectedItems[0].Tag;

            frmSalesDataSyncItem oForm = new frmSalesDataSyncItem();
            oForm.ShowDialog(oSalesDataSync);
            DataLoadControl();
        }
    }
}