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

namespace CJ.Win
{
    public partial class frmDealerorderMonitoring : Form
    {
        SalesInvoices _oSalesInvoices;
        Warehouse oWarehouse;
        Customer oCustomer;
        TELLib oTELLib;
        rptSalesInvoice _orptSalesInvoice;

        public frmDealerorderMonitoring()
        {
            InitializeComponent();
        }

        private void frmDealerorderMonitoring_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            lvwInvoice.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSalesInvoices = new SalesInvoices();

            _oSalesInvoices.RefreshForDealerorderMonitoring(dtFromDate.Value.Date, dtToDate.Value.Date,txtInvoiceNo.Text);

            foreach (SalesInvoice _SalesInvoice in _oSalesInvoices)
            {
                ListViewItem lstItem = lvwInvoice.Items.Add(_SalesInvoice.InvoiceNo.ToString());
                lstItem.SubItems.Add( Convert.ToDateTime(_SalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                oCustomer = new Customer();
                oCustomer.CustomerID = _SalesInvoice.CustomerDetail.ParentCustomerID;
                oCustomer.refresh();
                lstItem.SubItems.Add(oCustomer.CustomerName);
                oWarehouse = new Warehouse();
                oWarehouse.WarehouseID = _SalesInvoice.WarehouseID;
                oWarehouse.Reresh();
                lstItem.SubItems.Add(oWarehouse.WarehouseName);
              
                if (_SalesInvoice.IsCheck == 1)
                {
                    lstItem.SubItems.Add("Check");
                }
                else 
                {
                    lstItem.SubItems.Add("Not Check");
                }               
                lstItem.Tag = _SalesInvoice;

            }
          
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwInvoice.Items.Count; i++)
            {
                ListViewItem itm = lvwInvoice.Items[i];
                if (lvwInvoice.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please check a invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < lvwInvoice.Items.Count; i++)
            {
                ListViewItem itm = lvwInvoice.Items[i];
                if (lvwInvoice.Items[i].Checked == true )
                {
                    SalesInvoice _oSalesInvoice = (SalesInvoice)lvwInvoice.Items[i].Tag;
                    if (_oSalesInvoice.IsCheck != 1)
                    {
                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            _oSalesInvoice.IsCheck = 1;
                            _oSalesInvoice.UpadteDealerOrder();
                            DBController.Instance.CommitTransaction();                            

                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("You Have Successfully Update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshData();
        }
        public void PrintInvoice(long InvoiceID)
        {
            string SL = "";
            bool IsSL = true;
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = InvoiceID;
            _orptSalesInvoice.Refresh();


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
            doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            doc.SetParameterValue("Discount", _orptSalesInvoice.Discount.ToString());
            doc.SetParameterValue("InvoiceAmount", _orptSalesInvoice.InvoiceAmount.ToString());
            doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
            doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
            doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
            doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
            doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());

            doc.SetParameterValue("IsSL", IsSL);
            doc.SetParameterValue("SL", SL);
            doc.SetParameterValue("CompanyInfo", "TEL");

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
            doc.SetParameterValue("InvoiceHeader", "Dealer Order");
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(doc);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (lvwInvoice.SelectedItems.Count != 0)
            {
                SalesInvoice _oSalesInvoice = (SalesInvoice)lvwInvoice.SelectedItems[0].Tag;
                PrintInvoice(_oSalesInvoice.InvoiceID);
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        
    }
}