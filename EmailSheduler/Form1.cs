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
using CJ.Class.Process;
using ZAM.QRCode.Codec;
using ZAM.QRCode.Codec.Data;
using ZAM.QRCode.Codec.Util;
using System.IO;
using System.Data.OleDb;

//using CJ.QRCode.Codec;
//using CJ.QRCode.Codec.Data;
//using CJ.QRCode.Codec.Util;
//using System.IO;
//using CJ.Win.Duty;

namespace EmailSheduler
{
    public partial class Form1 : Form
    {
        string _sArg;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        RetailSalesInvoice oRetailSalesInvoice;
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

        public Form1(string sArg)
        {
            this.Text = "Data Processing Engine for Email Sent (Version # 1)";
            _sArg = sArg;
            InitializeComponent();
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


            doc.SetParameterValue("Barcode", SL);
            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            doc.SetParameterValue("IsCLP", false);
            doc.SetParameterValue("PBalance", 0);
            doc.SetParameterValue("RBalance", 0);
            doc.SetParameterValue("CBalance", 0);

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
            frmView.ShowDialog(doc);
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
        public void PrintRetailInvoice(long nInvoiceID,bool _bMakePDF)
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


            CJ.Report.POS.rptRetailInvoiceNew doc;
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

            if (_bMakePDF == true)
            {
                Outgoing _oOutgoing = new Outgoing();
                _oOutgoing.CreateInvoicePath();
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + orptSalesInvoice.InvoiceNo + ".pdf");
            }
            else
            {
                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }
        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, rptSalesInvoice _oSalesInvoice, string sBarcode, string sProductCode, string sProductName)
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
                    data = data + "\n" + 3;
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2B || oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2C)
                {
                    data = data + "\n" + 13;
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.HPA)
                {
                    data = data + "\n" + 244;
                }
                else
                {
                    data = data + "\n" + 4;
                }
                //if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                //{
                //    data = data + "\n" + Convert.ToString(Utility.DealerChannelID);
                //}
                //else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2B || oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2C)
                //{
                //    data = data + "\n" + Convert.ToString(Utility.TDCorporateChannelID);
                //}
                //else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.HPA)
                //{
                //    data = data + "\n" + Convert.ToString(Utility.TDHPAChannelID);
                //}
                //else
                //{
                //    data = data + "\n" + Convert.ToString(Utility.RetailChannelID);
                //}
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public string PrintWarrantyCardForBulk(int nInvoiceID,int nProductID, string sWarrantyCardNo, string sBarcode,  int nWarrantyParamID, bool _bMakePDF)
        {
            rptSalesInvoice oSalesInvoice = new rptSalesInvoice();
            oSalesInvoice.InvoiceID = nInvoiceID;
            oSalesInvoice.RefreshByInvoiceIDHONew();

            WarrantyParam oWarrantyParam = new WarrantyParam();
            //if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            if (oWarrantyParam.GetWarrantyParamByID(nWarrantyParamID))
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = oSalesInvoice.CustomerID;
                oRetailConsumer.WarehouseID = Convert.ToInt32(oSalesInvoice.WarehouseID);
                oRetailConsumer.Refresh();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID =Convert.ToInt32( oSalesInvoice.SalesPersonID);
                oEmployee.RefreshForPOS();
                QRCodeGen(oWarrantyParam, oRetailConsumer, oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();
                doc.SetDataSource(oDSQRCode);
                doc.SetParameterValue("WarrantyCardNo", sWarrantyCardNo);

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
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }

                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + oSalesInvoice.ShowRoomCode + "]" + "-" + oSalesInvoice.ShowRoomName);
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

                if (_bMakePDF == true)
                {
                    Outgoing _oOutgoing = new Outgoing();
                    _oOutgoing.CreateInvoicePath();
                    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + sWarrantyCardNo + ".pdf");
                }
                else
                {
                    frmPrintPreviewWithoutExport frmView;
                    frmView = new frmPrintPreviewWithoutExport();
                    frmView.ShowDialog(doc);
                }
            }

            return sWarrantyCardNo;
        }
        private void MakeInvoicePdf(int nInvoiceID)
        {

            rptRequisitionAuthorize pr = new rptRequisitionAuthorize();
            this.Cursor = Cursors.WaitCursor;
            InvoiceWiseBarcode(nInvoiceID);
            SalesInvoiceItem oDetail = new SalesInvoiceItem();
            if (oDetail.IsNewInvoice(nInvoiceID))
            {
                PrintRetailInvoice(nInvoiceID,true);
            }
            else
            {
                PrintRetailInvoiceOld(nInvoiceID);
            }
            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(nInvoiceID));
            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulk(nInvoiceID,oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, oWP.WarrantyParameterID, true);
            }
            this.Cursor = Cursors.Default;
        }

        public void UpdateInvoiceData(int nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SalesInvoice Set IsSentEmil=1,EmailSentDate='" + DateTime.Now + "' Where InvoiceID=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateProcessTime(string sString)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update DWDB.DBO.t_DataUpdateDate Set LastUpdateDate='" + DateTime.Now + "' Where CompanyName='" + sString + "'";
                cmd.CommandType = CommandType.Text;


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GetLastUpdateTime()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string _LastUpdateDate = "";
            string sSql = "  Select LastUpdateDate From DWDB.DBO.t_DataUpdateDate where CompanyName='Sales Invoice Email'";

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _LastUpdateDate = Convert.ToString(reader["LastUpdateDate"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _LastUpdateDate;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lblDataProcess.Text = "Data Preparing. Please wait...";
            lblDataProcess.Refresh();
            string sSuccessData = "";

            try
            {
                RetailSalesInvoices oInvoice = new RetailSalesInvoices();
                DBController.Instance.OpenNewConnection();
                oInvoice.RefreshInvoiceForEmail(dtFromDate.Value.Date, dtToDate.Value.Date);
                DBController.Instance.CloseConnection();
                int nTotalSend = 0;
                foreach (RetailSalesInvoice oItemRows in oInvoice)
                {
                    DBController.Instance.OpenNewConnection();
                    MakeInvoicePdf(Convert.ToInt32(oItemRows.InvoiceID));
                    DBController.Instance.CloseConnection();
                }

                foreach (RetailSalesInvoice oItemRow in oInvoice)
                {
                    //DBController.Instance.OpenNewConnection();
                    //MakeInvoicePdf(Convert.ToInt32(oItemRow.InvoiceID));
                    //DBController.Instance.CloseConnection();

                    Outgoing oOutgoing = new Outgoing();
                    bool _isSendEmail = false;
                    _isSendEmail = oOutgoing.SendTDSalesEmail(oItemRow.ConsumerName, Convert.ToInt32(oItemRow.InvoiceID), oItemRow.InvoiceNo, Convert.ToDateTime(oItemRow.InvoiceDate).ToString("dd-MMM-yyyy"), oItemRow.Email.Trim(), 1);
                    if (_isSendEmail == true)
                    {
                        try
                        {
                            UpdateInvoiceData(Convert.ToInt32(oItemRow.InvoiceID));
                            UpdateProcessTime("Sales Invoice Email");
                            nTotalSend++;

                        }
                        catch (Exception ex)
                        {
                            lblDataProcess.Text = "Data Update failed!!!";
                            lblDataProcess.Refresh();
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }

                    }
                    DBController.Instance.OpenNewConnection();
                    string sfile = @"D:\ExportedInvoice\" + oItemRow.InvoiceNo + ".pdf";
                    System.IO.File.Delete(sfile);
                    WarrantyCategory oWarrantyCategory = new WarrantyCategory();
                    oWarrantyCategory.Refresh(Convert.ToInt32(oItemRow.InvoiceID));
                    foreach (WarrantyParameter oWarrantyParameter in oWarrantyCategory)
                    {
                        string _WarrantyNo = @"D:\ExportedInvoice\" + oWarrantyParameter.WarrantyCardNo + ".pdf";
                        System.IO.File.Delete(_WarrantyNo);
                    }
                    DBController.Instance.CloseConnection();
                }
                lblDataProcess.Text = "Data Update Successfully.Total Invoice=" + oInvoice.Count + " and Total Sent=" + nTotalSend + "";
                lblDataProcess.Refresh();

                if (_sArg == "")
                {
                    MessageBox.Show("Data Update Successfully: " + sSuccessData + "");
                }
            }
            catch (Exception ex)
            {
                if (_sArg == "")
                {
                    MessageBox.Show("Error Inserting Data:" + ex + " ");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DBController.Instance.OpenNewConnection();
            //lastDate.Text = "Last Update DateTime: " + GetLastUpdateTime();
            dtFromDate.Value = DateTime.Now.AddDays(-3);
            this.Text = "Data Processing Engine for Email Sent (Version # 1)";
            DBController.Instance.CloseConnection();
            if (_sArg == "Auto")
            {
                btnExecute_Click(sender, e);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTargetPdf oFrm = new frmTargetPdf();
            oFrm.ShowDialog();
        }
    }
}
