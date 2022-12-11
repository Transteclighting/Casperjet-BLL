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
    public partial class frmDealerInvoices : Form
    {
        SystemInfo oSystemInfo;
        CustomerTransaction oCustomerTransaction;
        rptSalesInvoice _orptSalesInvoice;
        TELLib oTELLib;
        string SL = "";
        bool IsSL = true;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        SalesInvoiceProductSerials _oSIPSs;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;

        public frmDealerInvoices()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDealerInvoice oForm = new frmDealerInvoice(1);
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            SalesInvoices oSalesInvoices = new SalesInvoices();

            lvwDealerInvoice.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {
                oSalesInvoices.RefreshDealerInvoicePOS(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text);
            }

            this.Text = "Total Invoice " + "[" + oSalesInvoices.Count + "]";
            foreach (SalesInvoice oSalesInvoice in oSalesInvoices)
            {
                ListViewItem oItem = lvwDealerInvoice.Items.Add(oSalesInvoice.InvoiceID.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSalesInvoice.InvoiceAmount.ToString());
                oItem.SubItems.Add(oSalesInvoice.CustomerName);
                oItem.SubItems.Add(oSalesInvoice.InvoiceStatusName.ToString());

                oItem.Tag = oSalesInvoice;
            }

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void frmDealerInvoices_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {

            //if (lvwDealerInvoice.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a row to Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //SalesInvoice _oSalesInvoice = (SalesInvoice)lvwDealerInvoice.SelectedItems[0].Tag;
            //if (_oSalesInvoice.IsDownload != (int)Dictionary.IsDownload.Yes)
            //{
            //    DialogResult oResult = MessageBox.Show("Are you sure you want to cancel Invoice: " + _oSalesInvoice.InvoiceNo + " ? ", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (oResult == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            DBController.Instance.BeginNewTransaction();


            //            oSystemInfo = new SystemInfo();
            //            oSystemInfo.Refresh();

            //            //Update Invoice Status
            //            _oSalesInvoice.UserID = Utility.UserId;
            //            _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID,(int)Dictionary.InvoiceStatus.CANCEL);

            //            // Update Customer Account
            //            OleDbCommand cmd = DBController.Instance.GetCommand();

            //            cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance + ? where CustomerID = ?";
            //            cmd.Parameters.AddWithValue("CurrentBalance", _oSalesInvoice.InvoiceAmount);
            //            cmd.Parameters.AddWithValue("CustomerID", _oSalesInvoice.CustomerID);
            //            cmd.CommandType = CommandType.Text;

            //            cmd.ExecuteNonQuery();
            //            cmd.Dispose();

            //            ///
            //            // Update Product Stock.
            //            ///
            //            foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
            //            {
            //                ProductStock oProductStock = new ProductStock();

            //                oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
            //                oProductStock.Quantity = _oSalesInvoiceItem.Quantity;
            //                oProductStock.WarehouseID = oSystemInfo.WarehouseID;

            //                oProductStock.UpdateCurrentStock_POS(false);
            //            }

            //            SalesInvoiceProductSerial oSIPS = new SalesInvoiceProductSerial();
            //            oSIPS.InvoiceID = _oSalesInvoice.InvoiceID;
            //            oSIPS.DeleteIMEI();
                        
            //            oCustomerTransaction = new CustomerTransaction();
            //            oCustomerTransaction.InstrumentNo = _oSalesInvoice.InstrumentNo;
            //            oCustomerTransaction.DeleteTranByInstrument();


            //            // Delete t_InvoiceWisePayment by InvoiceID (if any)
            //            // Update/delete t_CustomerTran by t_InvoiceWisePayment.Amont if Amount is same then delete or Update (only deduct said invoice amount by foreach loop)
            //            // Delete t_Datatransfer

            //            DBController.Instance.CommitTransaction();
            //            //RefreshData();
            //        }
            //        catch (Exception ex)
            //        {
            //            DBController.Instance.RollbackTransaction();
            //            MessageBox.Show(ex.Message, "Error!!!");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("This Invoice already sent to HQ \n Sothat not eligible to cancel", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

        }

        private void btnMoneyReceiptPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoicePrint_Click(object sender, EventArgs e)
        {
            if (lvwDealerInvoice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoice _oSI = (SalesInvoice)lvwDealerInvoice.SelectedItems[0].Tag;

            PrintInvice(_oSI.InvoiceID);
        }
        public void PrintInvice(long nInvoiceID)
        {
            InvoiceWiseBarcode(nInvoiceID);
            oTELLib = new TELLib();
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = nInvoiceID;
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
        public void InvoiceWiseBarcode(long nInvoiceID)
        {
            SL = "";

            //SalesInvoiceInfo _oSalesInvoiceInfo = (SalesInvoiceInfo)lvwOrderList.SelectedItems[0].Tag;
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(nInvoiceID);

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
    }
}