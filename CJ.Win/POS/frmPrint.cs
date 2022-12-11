using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.Warranty;
using CJ.Class.Report;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.Duty;

using CJ.QRCode.Codec;
using CJ.QRCode.Codec.Data;
using CJ.QRCode.Codec.Util;
using System.IO;
using CJ.Win.Duty;

namespace CJ.Win.POS
{
    public partial class frmPrint : Form
    {
        bool IsCheck = false;
        SalesInvoice _oSalesInvoice;
        SalesInvoices _oSalesInvoices;
        RetailConsumer _oRetailConsumer;
        TELLib _oTELLib;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        WarrantyCategory oWarrantyCategory;
        RetailSalesInvoice oRetailSalesInvoice;
        WarrantyParameter oWarrantyParameter;
        RetailConsumer oRetailConsumer;
        Image iImage;
        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        SalesInvoiceProductSerials _oSIPSs;
        DSSalesInvoiceDetail oDSSalesInvoiceProduct;
        string SL = "";
        DSSalesInvoiceDetail oDSFreeGiftProduct;
        DSSalesInvoiceDetail oDSSalesInvoiceDetail;
        TELLib oTELLib;
        rptSalesInvoice orptSalesInvoice;
        Showroom oShowroom;
        SalesInvoiceItem _oSalesInvoiceItem;
        long nInvoiceID = 0;
        

        public frmPrint()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RefreshData();
            this.Cursor = Cursors.Default;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            btVATPrint.Visible = false;
            btnVAT11Ka.Visible = false;
            RefreshData();
        }
        public void RefreshData()
        {
            lvwItemList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oTELLib = new TELLib();
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
            _oSalesInvoices = new SalesInvoices();
            _oSalesInvoiceItem = new SalesInvoiceItem();

            if (txtBarcode.Text.Trim() != "")
            {
                _oSalesInvoiceProductSerial.ProductSerialNo = txtBarcode.Text.Trim();
                _oSalesInvoiceProductSerial.CheckProductSerialforPrint();

                nInvoiceID = _oSalesInvoiceProductSerial.InvoiceID;
                if (_oSalesInvoiceProductSerial.IsCount == 0)
                {
                    MessageBox.Show("There is no Invoice in the Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            _oSalesInvoices.RefreshRetailInvoice(dtFromDate.Value.Date, dtToDate.Value.Date, txtInvoiceNo.Text.Trim(), txtConsumerName.Text.Trim(), txtMobileNo.Text.Trim(), nInvoiceID, txtShowroomCode.Text.Trim(), IsCheck);

            foreach (SalesInvoice _SalesInvoice in _oSalesInvoices)
            {
                ListViewItem lstItem = lvwItemList.Items.Add(_SalesInvoice.InvoiceNo.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(_SalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(_oTELLib.TakaFormat(_SalesInvoice.InvoiceAmount));
                lstItem.SubItems.Add(_SalesInvoice.ShowroomCode);
                _oRetailConsumer = new RetailConsumer();
                _oRetailConsumer.ConsumerID = int.Parse(_SalesInvoice.SundryCustomerID.ToString());
                _oRetailConsumer.WarehouseID = _SalesInvoice.WarehouseID;
                _oRetailConsumer.Refresh();
                lstItem.SubItems.Add(_oRetailConsumer.ConsumerName);
                lstItem.SubItems.Add(_oRetailConsumer.CellNo);
                lstItem.SubItems.Add(_oRetailConsumer.Address);

                if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    lstItem.SubItems.Add("DELIVERED");
                }
                else if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PENDING)
                {
                    lstItem.SubItems.Add("PENDING");
                }
                else if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
                {
                    lstItem.SubItems.Add("PROCESSING_DELIVERY");
                }
                else if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
                {
                    lstItem.SubItems.Add("PRODUCT_RETURN");
                }
                else if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE)
                {
                    lstItem.SubItems.Add("REVERSE");
                }
                else if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED)
                {
                    lstItem.SubItems.Add("UNDELIVERED");
                }
                else if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED_DUE_TO_STOCK_LIMIT)
                {
                    lstItem.SubItems.Add("UNDELIVERED_DUE_TO_STOCK_LIMIT");
                }
                else
                {
                    lstItem.SubItems.Add("CENCEL");
                }
                lstItem.SubItems.Add(_SalesInvoice.Remarks);
                lstItem.Tag = _SalesInvoice;

            }
            this.Text = "Invoice" + "[" + _oSalesInvoices.Count + "]";
        }


        
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;
            InvoiceWiseBarcode(_SalesInvoice.InvoiceID);
            ////PrintRetailInvoice(_SalesInvoice.InvoiceID);
            //PrintRetailInvoiceOld(_SalesInvoice.InvoiceID);

            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(_SalesInvoice.InvoiceID))
            {
                PrintRetailInvoice(_SalesInvoice.InvoiceID);
            }
            else
            {
                PrintRetailInvoiceOld(_SalesInvoice.InvoiceID);
            }
            this.Cursor = Cursors.Default;
        }
        public void InvoiceWiseBarcode(long nInvoiceID)
        {
            SL = "";
            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(nInvoiceID);

            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {
                //IsSL = true;
                string PCode = "";

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {
                    //IsSL = false;
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


        public void PrintRetailInvoice(long nInvoiceID)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
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
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();

            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
            oRetailConsumer.WarehouseID = int.Parse(orptSalesInvoice.WarehouseID.ToString());
            oRetailConsumer.Refresh();

            oShowroom = new Showroom();
            oShowroom.WarehouseID = Convert.ToInt32(orptSalesInvoice.WarehouseID);
            oShowroom.GetShowroomID();
            oShowroom.Refresh();

            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();






            rptRetailInvoiceNew doc;
            doc = new rptRetailInvoiceNew();
            doc.SetDataSource(oDSSalesInvoiceDetail);

            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }
            doc.SetParameterValue("Outlet", oShowroom.ShowroomName);
            doc.SetParameterValue("Address", oShowroom.ShowroomAddress + ", Outlet Phone No:" + oShowroom.Telephone);
            doc.SetParameterValue("Mobile", oShowroom.MobileNo + ", e-mail:" + oShowroom.Email);
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
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address + ' ' + orptSalesInvoice.ThanaName);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("Email", oRetailConsumer.Email);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");

            //doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            RetailSalesInvoice oRetailInvoice = new RetailSalesInvoice();
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailInvoice.CheckSalesInvoice(nInvoiceID.ToString()))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }
            
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oShowroom.ShowroomCode + "]" + "-" + oShowroom.ShowroomName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            RetailSalesInvoices oRetailDiscounCharges = new RetailSalesInvoices();
            oRetailDiscounCharges.GetRetailInvoiceDiscountCharge(nInvoiceID);
            string sCharge = "";
            string sDiscount = "";
            double _TotalDiscount = 0;
            double _TotalCharge = 0;
            foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailDiscounCharges)
            {
                if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Charge)
                {
                    if (sCharge == "")
                    {
                        sCharge = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sCharge = sCharge + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalCharge = _TotalCharge + oRetailSalesInvoice.Amount;

                }
                else if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Discount)
                {
                    if (sDiscount == "")
                    {
                        sDiscount = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sDiscount = sDiscount + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalDiscount = _TotalDiscount + oRetailSalesInvoice.Amount;
                }

            }
            doc.SetParameterValue("ChargeDetail", sCharge.ToString());
            doc.SetParameterValue("DiscountDetail", sDiscount.ToString());
            doc.SetParameterValue("TotalCharge", oTELLib.TakaFormat(_TotalCharge));
            doc.SetParameterValue("TotalDiscount", oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentByInvoice(nInvoiceID);
            string sPaymentDetail = "";
            double _TotalPayment = 0;
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                if (sPaymentDetail == "")
                {
                    sPaymentDetail = oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                else
                {
                    sPaymentDetail = sPaymentDetail + ' ' + '|' + ' ' + oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                _TotalPayment = _TotalPayment + oPaymentMode.Amount;

            }

            doc.SetParameterValue("PaymentModeDetail", sPaymentDetail.ToString());
            doc.SetParameterValue("TotalPayment", oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

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



            PaymentModes oEMI = new PaymentModes();
            oEMI.GetEMiDetail(nInvoiceID);
            string sEMIDetail = "";
            foreach (PaymentMode oPaymentMode in oEMI)
            {
                if (sEMIDetail == "")
                {
                    sEMIDetail = oPaymentMode.EMIDetail;
                }
                else
                {
                    sEMIDetail = sEMIDetail + '\n' + oPaymentMode.EMIDetail;
                }
            }

            doc.SetParameterValue("EMIDetail", sEMIDetail.ToString());

            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            frmView.ShowDialog(doc);
        }

        public void PrintRetailInvoiceThermal(long nInvoiceID, int nIsDirect)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
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
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();

            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
            oRetailConsumer.WarehouseID = int.Parse(orptSalesInvoice.WarehouseID.ToString());
            oRetailConsumer.Refresh();

            oShowroom = new Showroom();
            oShowroom.WarehouseID = Convert.ToInt32(orptSalesInvoice.WarehouseID);
            oShowroom.GetShowroomID();
            oShowroom.Refresh();

            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();






            rptRetailInvoiceThermal doc;
            doc = new rptRetailInvoiceThermal();
            doc.SetDataSource(oDSSalesInvoiceDetail);

            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }
            doc.SetParameterValue("Outlet", oShowroom.ShowroomName);
            doc.SetParameterValue("Address", oShowroom.ShowroomAddress + ", Outlet Phone No:" + oShowroom.Telephone);
            doc.SetParameterValue("Mobile", oShowroom.MobileNo + ", e-mail:" + oShowroom.Email);
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
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address + ' ' + orptSalesInvoice.ThanaName);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("Email", oRetailConsumer.Email);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");

            //doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            RetailSalesInvoice oRetailInvoice = new RetailSalesInvoice();
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailInvoice.CheckSalesInvoice(nInvoiceID.ToString()))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }

            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oShowroom.ShowroomCode + "]" + "-" + oShowroom.ShowroomName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            doc.SetParameterValue("VATRegistrationNo", "000002186-0101");
            RetailSalesInvoices oRetailDiscounCharges = new RetailSalesInvoices();
            oRetailDiscounCharges.GetRetailInvoiceDiscountCharge(nInvoiceID);
            string sCharge = "";
            string sDiscount = "";
            double _TotalDiscount = 0;
            double _TotalCharge = 0;
            foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailDiscounCharges)
            {
                if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Charge)
                {
                    if (sCharge == "")
                    {
                        sCharge = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sCharge = sCharge + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalCharge = _TotalCharge + oRetailSalesInvoice.Amount;

                }
                else if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Discount)
                {
                    if (sDiscount == "")
                    {
                        sDiscount = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sDiscount = sDiscount + ' ' + '|' + ' ' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalDiscount = _TotalDiscount + oRetailSalesInvoice.Amount;
                }

            }
            doc.SetParameterValue("ChargeDetail", sCharge.ToString());
            doc.SetParameterValue("DiscountDetail", sDiscount.ToString());
            doc.SetParameterValue("TotalCharge", oTELLib.TakaFormat(_TotalCharge));
            doc.SetParameterValue("TotalDiscount", oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentByInvoice(nInvoiceID);
            string sPaymentDetail = "";
            double _TotalPayment = 0;
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                if (sPaymentDetail == "")
                {
                    sPaymentDetail = oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                else
                {
                    sPaymentDetail = sPaymentDetail + ' ' + '|' + ' ' + oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                _TotalPayment = _TotalPayment + oPaymentMode.Amount;

            }

            doc.SetParameterValue("PaymentModeDetail", sPaymentDetail.ToString());
            doc.SetParameterValue("TotalPayment", oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

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



            PaymentModes oEMI = new PaymentModes();
            oEMI.GetEMiDetail(nInvoiceID);
            string sEMIDetail = "";
            foreach (PaymentMode oPaymentMode in oEMI)
            {
                if (sEMIDetail == "")
                {
                    sEMIDetail = oPaymentMode.EMIDetail;
                }
                else
                {
                    sEMIDetail = sEMIDetail + '\n' + oPaymentMode.EMIDetail;
                }
            }

            doc.SetParameterValue("EMIDetail", sEMIDetail.ToString());

            if (nIsDirect == 0)
            {
                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
            else
            {
                doc.PrintToPrinter(1, true, 1, 1);
            }
        }
        
        public void PrintRetailInvoicexxxxx(long nInvoiceID)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
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
                    
                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();

            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
            oRetailConsumer.WarehouseID = int.Parse(orptSalesInvoice.WarehouseID.ToString());

            oRetailConsumer.Refresh();

            oShowroom = new Showroom();
            oShowroom.WarehouseID = Convert.ToInt32(orptSalesInvoice.WarehouseID);
            oShowroom.GetShowroomID();
            oShowroom.Refresh();

            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();

            oRetailSalesInvoice = new RetailSalesInvoice();
            oRetailSalesInvoice.InvoiceID = nInvoiceID;
            oRetailSalesInvoice.RefreshInvoiceCharge();
            oRetailSalesInvoice.RefreshPaymentMode();
            oRetailSalesInvoice.RefreshSMSDiscoutn(orptSalesInvoice.InvoiceNo);

            rptRetailInvoice doc;
            doc = new rptRetailInvoice();
            doc.SetDataSource(oDSSalesInvoiceDetail);



            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }

            doc.SetParameterValue("Outlet", oShowroom.ShowroomName);
            doc.SetParameterValue("Address", oShowroom.ShowroomAddress + ", Outlet Phone No:" + oShowroom.Telephone);
            doc.SetParameterValue("Mobile", oShowroom.MobileNo + ", e-mail:" + oShowroom.Email);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);

            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailSalesInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailSalesInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailSalesInvoice.CheckSalesInvoice(Convert.ToString(nInvoiceID)))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailSalesInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oShowroom.ShowroomCode + "]" + "-" + oShowroom.ShowroomName);
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

            doc.SetParameterValue("Barcode", SL);
            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            if (oRetailConsumer.CheckCLPConsumer())
            {
                doc.SetParameterValue("IsCLP", false);
                doc.SetParameterValue("PBalance", 0);
                doc.SetParameterValue("RBalance", 0);
                doc.SetParameterValue("CBalance", 0);
            }

            else
            {
                doc.SetParameterValue("IsCLP", true);
            }

            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            frmView.ShowDialog(doc);
        }

        public void PrintRetailInvoiceOld(long nInvoiceID)
        {
            RetailSalesInvoices _oRetailSalesInvoices = new RetailSalesInvoices();

            bool _bCreditCardVisible = false;
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            DSSalesInvoiceDetail oDSCreditCard = new DSSalesInvoiceDetail();
            oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();


            oShowroom = new Showroom();
            oShowroom.WarehouseID = Convert.ToInt32(orptSalesInvoice.WarehouseID);
            oShowroom.GetShowroomID();
            oShowroom.Refresh();

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


            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.CustomerID = int.Parse(orptSalesInvoice.CustomerID.ToString());
            oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
            oRetailConsumer.WarehouseID = int.Parse(orptSalesInvoice.WarehouseID.ToString());
            oRetailConsumer.Refresh();

            oRetailSalesInvoice = new RetailSalesInvoice();
            oRetailSalesInvoice.InvoiceID = nInvoiceID;
            oRetailSalesInvoice.RefreshInvoiceCharge();
            oRetailSalesInvoice.RefreshPaymentMode();
            oRetailSalesInvoice.RefreshSMSDiscoutn(orptSalesInvoice.InvoiceNo);
            

            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();

            rptRetailInvoice doc;
            doc = new rptRetailInvoice();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("IsVisibleCreditCard", _bCreditCardVisible);




            doc.SetParameterValue("Outlet", oShowroom.ShowroomName);
            doc.SetParameterValue("Address", oShowroom.ShowroomAddress + ", Outlet Phone No:" + oShowroom.Telephone);
            doc.SetParameterValue("Mobile", oShowroom.MobileNo + ", e-mail:" + oShowroom.Email);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);

            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);

            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");

            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");

            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("InvoiceTitle", "Reverse Invoice (" + oRetailConsumer.SalesTypeName + ")");

                oRetailSalesInvoice.GetInvoicNo(Convert.ToInt64(orptSalesInvoice.RefInvoiceID));
                doc.SetParameterValue("RefInvoice", "Ref Invoice#: " + oRetailSalesInvoice.InvoiceNo);

            }
            else
            {
                doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");

                if (oRetailSalesInvoice.CheckSalesInvoice(Convert.ToString(nInvoiceID)))
                {
                    doc.SetParameterValue("RefInvoice", "Reverse Invoice#: " + oRetailSalesInvoice.InvoiceNo);
                }
                else
                {
                    doc.SetParameterValue("RefInvoice", "");
                }

            }
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);


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
            if (orptSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
            {
                doc.SetParameterValue("SPDiscount", oRetailSalesInvoice.SPDiscount * -1);
                doc.SetParameterValue("SDiscount", oRetailSalesInvoice.TotalDiscount * -1);
                doc.SetParameterValue("Discount", orptSalesInvoice.Discount * -1);
                doc.SetParameterValue("smsDiscount", oRetailSalesInvoice.smsDiscount * -1);

                doc.SetParameterValue("FCharge", oRetailSalesInvoice.FreightCharge * -1);
                doc.SetParameterValue("ICharge", oRetailSalesInvoice.InstallationCharge * -1);
                doc.SetParameterValue("OCharge", oRetailSalesInvoice.OtherCharge * -1);
                doc.SetParameterValue("MCharge", oRetailSalesInvoice.MarkUpAmount * -1);
                doc.SetParameterValue("Charge", oRetailSalesInvoice.TotalCharge * -1);

                doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount * -1);
                doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount * -1));

                doc.SetParameterValue("Cash", oRetailSalesInvoice.Cash * -1);
                doc.SetParameterValue("Credit", oRetailSalesInvoice.Credit * -1);
                doc.SetParameterValue("AdvanceAdjust", oRetailSalesInvoice.AdvanceAdjust * -1);
                doc.SetParameterValue("OthersPayment", oRetailSalesInvoice.Others * -1);
                doc.SetParameterValue("Payment", oRetailSalesInvoice.TotalAmount * -1);
            }
            else
            {
                doc.SetParameterValue("SPDiscount", oRetailSalesInvoice.SPDiscount);
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
            }
            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }
            //if (sBarcode != null)
            //    doc.SetParameterValue("Barcode", sBarcode);
            //else doc.SetParameterValue("Barcode", "NA");

            doc.SetParameterValue("Barcode", SL);
            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            //if (oRetailConsumer.CheckCLPConsumer())
            //{
                doc.SetParameterValue("IsCLP", false);
                doc.SetParameterValue("PBalance", 0);
                doc.SetParameterValue("RBalance", 0);
                doc.SetParameterValue("CBalance", 0);
            //}

            //else
            //{
            //    doc.SetParameterValue("IsCLP", true);
            //    oCLPTran = new CLPTran();
            //    oCLPTran.ConsumerID = (int)orptSalesInvoice.SundryCustomerID;
            //    oCLPTran.CustomerID = orptSalesInvoice.CustomerID;
            //    oCLPTran.Refresh();

            //    doc.SetParameterValue("PBalance", oCLPTran.PreviousPoint);
            //    doc.SetParameterValue("RBalance", oCLPTran.CurrentPoint - oCLPTran.PreviousPoint);
            //    doc.SetParameterValue("CBalance", oCLPTran.CurrentPoint);
            //}
            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", "|" + oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString() + "");
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }

            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            //frmPrintPreview frmView;
            //frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        private void btnWarranty_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;
            oWarrantyParameter = new WarrantyParameter();
            if (oWarrantyParameter.CheckWarrantyCard(Convert.ToInt32(_SalesInvoice.InvoiceID)))
            {

            }
            else
            {
                MessageBox.Show("There is no warranty card in the invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed\nYou couldn't Print/Re-Print Warranty Card ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(_SalesInvoice.InvoiceID));

            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulk(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, oWP.WarehouseID, oWP.WarrantyParameterID, _SalesInvoice, false, oWP.ExtendedWarrantyDescription);
            }
            this.Cursor = Cursors.Default;
        }
        public void PrintWarrantyCardForBulk(int nProductID, string sWarrantyCardNo, string sBarcode, int nWarehouseID,int nWarrantyParameterID, SalesInvoice _oSalesInvoice, bool IsDealer,string sExtendedWarrantyDescription)
        {

            WarrantyParam oWarrantyParam = new WarrantyParam();
            if (oWarrantyParam.GetWarrantyParamByID(nWarrantyParameterID))
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                //oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.WarehouseID = nWarehouseID;
                oRetailConsumer.Refresh();

                ProductDetail oProductDetail = new ProductDetail();
                //oProductDetail.ProductID = nProductID;
                oProductDetail.Refresh(nProductID);

                Showroom oshowroom = new Showroom();
                oshowroom.WarehouseID = nWarehouseID;
                oshowroom.GetShowroomID();

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();
                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName, oshowroom.ChannelID);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();


                rptWarrantyCard doc;
                doc = new rptWarrantyCard();
                doc.SetDataSource(oDSQRCode);
                doc.SetParameterValue("WarrantyCardNo", sWarrantyCardNo);
                doc.SetParameterValue("ExtendedWarranty", sExtendedWarrantyDescription);
                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                if (IsDealer == false)
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
                //doc.SetParameterValue("AG", oProductDetail.AGName);
                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                //doc.SetParameterValue("ModelName", oProductDetail.ProductModel);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                
                doc.SetParameterValue("OutletName", "[" + oshowroom.ShowroomCode + "]" + "-" + oshowroom.ShowroomName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }

                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, SalesInvoice _oSalesInvoice, string sBarcode, string sProductCode, string sProductName, int nChannelID)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                String data = oRetailConsumer.ConsumerCode +
                "\n" + _oSalesInvoice.InvoiceNo +
                "\n" + _oSalesInvoice.InvoiceDate.ToString() +
                "\n" + oRetailConsumer.ConsumerName +
                "\n" + oRetailConsumer.Address +
                "\n" + oRetailConsumer.CellNo +
                "\n" + oRetailConsumer.Email +
                "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + oRetailConsumer.ParentCustomerID +
                "\n" + Convert.ToString(nChannelID);
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void btnDealerWarranty_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;
            oWarrantyParameter = new WarrantyParameter();
            if (oWarrantyParameter.CheckWarrantyCard(Convert.ToInt32(_SalesInvoice.InvoiceID)))
            {

            }
            else
            {
                MessageBox.Show("There is no warranty card in the invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oRetailSalesInvoice = new RetailSalesInvoice();
            if (oRetailSalesInvoice.CheckSalesInvoice(_SalesInvoice.InvoiceID.ToString()))
            {
                MessageBox.Show("The Invoice already reversed\nYou couldn't Print/Re-Print Warranty Card ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oRetailSalesInvoice.CheckInvoiceByDiscountReason(_SalesInvoice.InvoiceID, 5))//5=Dealer Discount (Source t_DiscountReason)
            {
                MessageBox.Show("Please Select Dealser Invoice", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(_SalesInvoice.InvoiceID));

            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulk(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, oWP.WarehouseID, oWP.WarrantyParameterID, _SalesInvoice, true, oWP.ExtendedWarrantyDescription);
            }
            this.Cursor = Cursors.Default;
        }

        private void btVATPrint_Click(object sender, EventArgs e)
        {

            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.ChallanType.VAT_11, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            PrintVatChallan(_oSalesInvoice,(int)Dictionary.ChallanType.VAT_11);
            this.Cursor = Cursors.Default;
        }

        private void btnVAT11Ka_Click(object sender, EventArgs e)
        {

            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoice oSalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;

            DutyTran oDutyTran = new DutyTran();
            if (oDutyTran.CheckDutyTran((int)Dictionary.ChallanType.VAT_11_KA, oSalesInvoice.InvoiceID))
            {
                MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _oSalesInvoice.RefreshByInvoiceID(_oSalesInvoice.InvoiceID);

            PrintVatChallan(_oSalesInvoice, (int)Dictionary.ChallanType.VAT_11);
            this.Cursor = Cursors.Default;
        }

        public void PrintVatChallan(SalesInvoice oSalesInvoice, int nType)
        {

            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
            _orptSalesInvoice.RefreshByInvoiceIDHO();


            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranIDPOS(oSalesInvoice.InvoiceID.ToString(), oSalesInvoice.InvoiceNo, oSalesInvoice.WarehouseID, nType);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                rptSalesInvoice oSI = new rptSalesInvoice();
                oSI.GetInvoiceStatusByID(oSalesInvoice.InvoiceID);

                oDutyTran.GetVATReportPOS(oSI.InvoiceStatus);////Correction
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("VATRegistrationNo", 18111020510);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());

                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }
                    oTELLib = new TELLib();
                    doc.SetParameterValue("TotalText", oTELLib.changeNumericToWords(nTotal) + " Pcs");

                    doc.SetParameterValue("Copy", "c÷_g Kwc");
                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanType", "Mushak-11(Ka)");
                    doc.SetParameterValue("VATRegistrationNo", 18111020510);
                    doc.SetParameterValue("Copy", "");

                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }

            }

        }

        private void btnThermalPrint_Click(object sender, EventArgs e)
        {
            int nIsDirect = 0;
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;
            InvoiceWiseBarcode(_SalesInvoice.InvoiceID);
            ////PrintRetailInvoice(_SalesInvoice.InvoiceID);
            //PrintRetailInvoiceOld(_SalesInvoice.InvoiceID);

            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(_SalesInvoice.InvoiceID))
            {
                PrintRetailInvoiceThermal(_SalesInvoice.InvoiceID, nIsDirect);
            }
            else
            {
                //PrintRetailInvoiceOld(_SalesInvoice.InvoiceID);
                
            }
            this.Cursor = Cursors.Default;
        }

        private void btnDirectPrint_Click(object sender, EventArgs e)
        {
            int nIsDirect = 1;
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            SalesInvoice _SalesInvoice = (SalesInvoice)lvwItemList.SelectedItems[0].Tag;
            InvoiceWiseBarcode(_SalesInvoice.InvoiceID);


            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(_SalesInvoice.InvoiceID))
            {
                PrintRetailInvoiceThermal(_SalesInvoice.InvoiceID, nIsDirect);
            }
            else
            {
                //PrintRetailInvoiceOld(_SalesInvoice.InvoiceID);
                //doc.PrintToPrinter(1, true, 1, 1);
            }
            this.Cursor = Cursors.Default;
        }
    }
}