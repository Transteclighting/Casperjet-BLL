using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Report;

public partial class frmReprintInvoice : System.Web.UI.Page
{

    SalesInvoice _oSalesInvoice;
    rptSalesInvoice _orptSalesInvoice; 
    CustomerTransaction _oCustomerTransaction;
    Bank _oBank;
    TELLib oTELLib;
    long InvoiceID;
    int nSBUID;
    bool _bIsReprint = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btGo_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        _oSalesInvoice = new SalesInvoice();
        DBController.Instance.OpenNewConnection();
        _oSalesInvoice.GetInvoiceID(txtInvoiceNo.Text);
        if (_oSalesInvoice.Flag == true)
        {
            InvoiceID = _oSalesInvoice.InvoiceID;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.RefreshByInvoiceID(InvoiceID);
            nSBUID = _oSalesInvoice.CustomerDetail.SBUID;
            SetUI();
            Session.Add("InvoiceID", InvoiceID);
            Session.Add("SBUID", nSBUID);
            Session.Add("SalesInvoice", _oSalesInvoice);
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Invoice Not Found";
            AppLogger.LogWarning("Web: Invoice Not Found  =" + Utility.Username);
            return;
        }
        DBController.Instance.CloseConnection();

    }
    public void SetUI()
    {
        DateTime _dDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);

        lbOrderNo.Text = _oSalesInvoice.SalesOrder.OrderNo.ToString();
        lbCustomerCode.Text = _oSalesInvoice.SalesOrder.Customer.CustomerCode;
        lbCustomerName.Text = _oSalesInvoice.SalesOrder.Customer.CustomerName;
        lbInvoiceDate.Text = _dDate.ToString("dd-MMM-yyyy");
        lbInvoiceAmount.Text = _oSalesInvoice.InvoiceAmount.ToString();

        if (_oSalesInvoice.DeliveryUser.Username != "")
            lbDeliveredBy.Text = _oSalesInvoice.DeliveryUser.Username;
        else lbDeliveredBy.Text = "NA";
        if (_oSalesInvoice.InvoiceUser.Username != "")
            lbInvoiceBy.Text = _oSalesInvoice.InvoiceUser.Username;
        else lbInvoiceBy.Text = "NA";

        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.CANCEL)
        {
            lbInvoiceStatus.Text = "CANCEL";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
        {
            lbInvoiceStatus.Text = "DELIVERED";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = true;
            btReprintMoneyCollection.Visible = true;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PENDING)
        {
            lbInvoiceStatus.Text = "PENDING";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
        {
            lbInvoiceStatus.Text = "PROCESSING DELIVERY";
          
            btProcessDelivery.Visible = true;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = true;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
        {
            lbInvoiceStatus.Text = "PRODUCT RETURN";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = true;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE)
        {
            lbInvoiceStatus.Text = "REVERSE";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = true;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED)
        {
            lbInvoiceStatus.Text = "UNDELIVERED";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = true;
          
        }

        if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.UNDELIVERED_DUE_TO_STOCK_LIMIT)
        {
            lbInvoiceStatus.Text = "UNDELIVERED DUE TO STOCK LIMIT";
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btReprintMoneyCollection.Visible = true;
        }



    }

    protected void btProcessDelivery_Click(object sender, EventArgs e)
    {
         _bIsReprint = true;
         Session.Add("IsReprint", _bIsReprint);
        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];
        InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        lblMessage.Visible = false;

        if (_oSalesInvoice != null)
        {
            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
            {
                try
                {
                    _oSalesInvoice = new SalesInvoice();
                    DBController.Instance.OpenNewConnection();                   
                    PrintDeliveryDoc();
                    DBController.Instance.CloseConnection();
                    AppLogger.LogInfo("Web: Success fully reprint Invoice system Processing (Process Delivery) =" + Utility.Username);
                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Web: error in reprint Invoice system Processing (Process Delivery) =" + ex);                  
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is an error in reprint Invoice Processing";
                }

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invoice have been Locked.You do have enough permission to Delivery this Invoice";
                return;
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Find Invoice No";
            return;
        }
    }
    public void PrintDeliveryDoc()
    {
        long InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        string sCompanyName = Utility.CompanyName;
        User oUser = (User)Session["User"];

        _orptSalesInvoice = new rptSalesInvoice();
        _orptSalesInvoice.InvoiceID = InvoiceID;
        _orptSalesInvoice.Refresh();
        bool bIsPartial = _orptSalesInvoice.IsPartial();

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptDeliveryNote));

        doc.SetDataSource(_orptSalesInvoice);

        doc.SetParameterValue("PrintBy", oUser.Username);
        doc.SetParameterValue("IsPartial", bIsPartial);

        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
        doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.CustomerAddress);
        doc.SetParameterValue("WarehouseName", _orptSalesInvoice.WarehouseName + " [" + _orptSalesInvoice.WarehouseCode + "]");
        doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
        doc.SetParameterValue("InvvoiceDate", Convert.ToDateTime(_orptSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));

        doc.SetParameterValue("OrderConfirmedBy", _orptSalesInvoice.OrderConfirmedBy);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks);
        doc.SetParameterValue("IsEPSDeliWH", false);
        doc.SetParameterValue("EPSDeliveryWHName", _orptSalesInvoice.EPSDeliveryWHName);

        if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
        {
            doc.SetParameterValue("InvoiceType", "Product Replacement");
            doc.SetParameterValue("IsVisibleInvoiceType", true);
            doc.SetParameterValue("SalesOrderNo", _orptSalesInvoice.RefDetails);
        }
        else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.BREAKAGE_REPLACEMENT)
        {
            doc.SetParameterValue("InvoiceType", "Breakage Replacement");
            doc.SetParameterValue("IsVisibleInvoiceType", true);
            doc.SetParameterValue("SalesOrderNo", _orptSalesInvoice.RefDetails);
        }
        else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
        {
            doc.SetParameterValue("InvoiceType", "Issue Sales Promotion");
            doc.SetParameterValue("IsVisibleInvoiceType", true);
        }
        else
        {
            doc.SetParameterValue("InvoiceType", "Normal");
            doc.SetParameterValue("IsVisibleInvoiceType", false);
            doc.SetParameterValue("SalesOrderNo", _orptSalesInvoice.OrderNo);
        }

        Session["ReportName"] = "Invoice System(Delivery Note) [DN]";
        Session.Remove("Doc");
        Session.Add("Doc", doc);

    }

    protected void btDeliveryInvoice_Click(object sender, EventArgs e)
    {
        _bIsReprint = true;
        Session.Add("IsReprint", _bIsReprint);
       

        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];
        InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        lblMessage.Visible = false;

        if (_oSalesInvoice != null)
        {
            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.DELIVERED)
            {
                try
                {
                    _oSalesInvoice = new SalesInvoice();
                    DBController.Instance.OpenNewConnection();                
                    PrintInvoice();
                    PrintVatChallan();                   
                    DBController.Instance.CloseConnection();
                    AppLogger.LogInfo("Web: Success fully reprint Invoice system Processing (Delivery Invoice)  =" + Utility.Username);
                    Response.Redirect("~/frmDeliveryInvoicePrintOptions.aspx");

                }
                catch (Exception ex)
                {                   
                    AppLogger.LogError("Web: error in reprint Invoice system Processing (Delivery Invoice) =" + ex);
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is an error in reprint Invoice Delivery";
                }

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invoice have been Locked.You do have enough permission to Delivery this Invoice";
                return;
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select Invoice No";
            return;
        }
    }  
    public void PrintInvoice()
    {
        string SL = "";
        bool IsSL = true;

        long InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        oTELLib = new TELLib();
        User oUser = (User)Session["User"];

        _orptSalesInvoice = new rptSalesInvoice();
        _orptSalesInvoice.InvoiceID = InvoiceID;
        _orptSalesInvoice.Refresh();

        if (_orptSalesInvoice.SundryCustomerID != -1)
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceRetailAutoPrint));

            doc.SetDataSource(_orptSalesInvoice);

            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + oUser.Username);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
            doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
            doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            doc.SetParameterValue("SCCustomerName", _orptSalesInvoice.SundryCustomerName.ToString());
            doc.SetParameterValue("SCAddress", _orptSalesInvoice.SCAddress.ToString());
            doc.SetParameterValue("SCCellNo", _orptSalesInvoice.SCCellNo.ToString());
            doc.SetParameterValue("SCPhoneNo", _orptSalesInvoice.SCPhoneNo.ToString());
            doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
            doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
            doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
            doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
            doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
            doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
            doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());

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

            Session.Remove("InvoiceDoc");
            Session.Add("InvoiceDoc", doc);
        }
        else
        {
            if (Utility.CompanyInfo == "TEL")
            {
                IsSL = false;
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                doc.SetDataSource(_orptSalesInvoice);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + oUser.Username);
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
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
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
                Session.Remove("InvoiceDoc");
                Session.Add("InvoiceDoc", doc);
            }
            else if (Utility.CompanyInfo == "BLL")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrintBLL));
                doc.SetDataSource(_orptSalesInvoice);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + oUser.Username);
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
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
                doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());

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
                Session.Remove("InvoiceDoc");
                Session.Add("InvoiceDoc", doc);
            }
            else if (Utility.CompanyInfo == "TML")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                doc.SetDataSource(_orptSalesInvoice);

                doc.SetParameterValue("FooterPrintCaption", "Printed By : " + oUser.Username);
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
                doc.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
                doc.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
                doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
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
                Session.Remove("InvoiceDoc");
                Session.Add("InvoiceDoc", doc);
            }
        }

        ///
        //Customer Copy
        ///

        if (Utility.CompanyInfo == "TEL")
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceive));
            docCus.SetDataSource(_orptSalesInvoice);

            docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
            docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
            docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            docCus.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
            docCus.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
            docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
            docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks);
            docCus.SetParameterValue("CompanyInfo", "TEL");

            Session.Remove("InvoicedocCus");
            Session.Add("InvoicedocCus", docCus);
        }
        else if (Utility.CompanyInfo == "BLL")
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceiveBLL));
            docCus.SetDataSource(_orptSalesInvoice);

            docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
            docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
            docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");


            Session.Remove("InvoicedocCus");
            Session.Add("InvoicedocCus", docCus);
        }
        else if (Utility.CompanyInfo == "TML")
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass docCus = ReportFactory.GetReport(typeof(rptCustomerGoodsReceive));
            docCus.SetDataSource(_orptSalesInvoice);

            docCus.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
            docCus.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
            docCus.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
            docCus.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
            docCus.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
            docCus.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
            docCus.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
            docCus.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
            docCus.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
            docCus.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
            docCus.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
            docCus.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
            docCus.SetParameterValue("Discount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
            docCus.SetParameterValue("InvoiceAmount", oTELLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
            docCus.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
            docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks);
            docCus.SetParameterValue("CompanyInfo", "TML");

            Session.Remove("InvoicedocCus");
            Session.Add("InvoicedocCus", docCus);
        }


    }

    public void PrintVatChallan()
    {
        long InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        oTELLib = new TELLib();


        _orptSalesInvoice = new rptSalesInvoice();
        _orptSalesInvoice.InvoiceID = InvoiceID;
        _orptSalesInvoice.Refresh();

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVatChallan));
        doc.SetDataSource(_orptSalesInvoice);

        doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
        doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
        doc.SetParameterValue("VatchalanNo", _orptSalesInvoice.VATChallanNo.ToString());
        doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
        doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToLongTimeString());

        Session.Remove("VatChallanDoc");
        Session.Add("VatChallanDoc", doc);


    }
    protected void btReprintMoneyCollection_Click(object sender, EventArgs e)
    {
        string sInvoiceHistory = "";
        string sPadding = "";
        long InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        oTELLib = new TELLib();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        _orptSalesInvoice = new rptSalesInvoice();
        _orptSalesInvoice.InvoiceID = InvoiceID;
        _orptSalesInvoice.Refresh();

        _oCustomerTransaction = new CustomerTransaction();
        _oCustomerTransaction.InvoiceID = InvoiceID;
        _oCustomerTransaction.GetTranID();
        _oCustomerTransaction.Refresh();
        
         if (Utility.CompanyInfo == "TEL")
            {

                try
                {
                    CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
                    oCustomerTransactionReport.Refresh(_oCustomerTransaction.TranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollection));
                    doc.SetDataSource(oCustomerTransactionReport);

                    sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount";
                    sInvoiceHistory = sInvoiceHistory + "\n\n";
                    sInvoiceHistory = sInvoiceHistory + _orptSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _orptSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
                    if (Utility.EmployeeID != -1)
                    {
                        _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
                        _oCustomerTransaction.Employee.ReadDB = true;
                        doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
                    }
                    else doc.SetParameterValue("JobLocation", "Sadar Road,Mohakhali C/A, Dhaka- 1206, Bangladesh");
                    doc.SetParameterValue("PrintBy", oUser.Username);
                    doc.SetParameterValue("InvoiceList", sInvoiceHistory);
                    doc.SetParameterValue("PrintStatus", "Re Print By");
                    doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
                    doc.SetParameterValue("TranDate", _oCustomerTransaction.TranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode);
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
                    doc.SetParameterValue("InstrumentType", Enum.GetName(typeof(Dictionary.InstrumentType), _oCustomerTransaction.InstrumentType));
                    doc.SetParameterValue("CompanyInfo", "TEL");
                    doc.SetParameterValue("CompanyName", Utility.CompanyName);
                    if (_oCustomerTransaction.InstrumentType != 2)
                    {
                        doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                        doc.SetParameterValue("Date",Convert.ToDateTime( _oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("Branch", _oCustomerTransaction.Branch.Name);
                        _oBank = new Bank();
                        _oBank.BankID = _oCustomerTransaction.Branch.BankID;
                        _oBank.Refresh();
                        doc.SetParameterValue("Bank", _oBank.Name);  
                    }
                    else
                    {
                        doc.SetParameterValue("InstrumentNo", "N/A");
                        doc.SetParameterValue("Date", "N/A");
                        doc.SetParameterValue("Bank", "N/A");
                        doc.SetParameterValue("Branch", "N/A");
                    }
                    doc.SetParameterValue("Amount", _oCustomerTransaction.Amount.ToString());
                    doc.SetParameterValue("TK", oTELLib.TakaWords(_oCustomerTransaction.Amount));
                    doc.SetParameterValue("Remarks", _oCustomerTransaction.Remarks);

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Invoice System(Customer Transaction Recevied) [CTR]";
                    DBController.Instance.CloseConnection();

                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch
                {                 
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......Please check your input and save again ";
                }

            }
            else if (Utility.CompanyInfo == "BLL")
            {

                try
                {
                    CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
                    oCustomerTransactionReport.Refresh(_oCustomerTransaction.TranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollectionBLL));
                    doc.SetDataSource(oCustomerTransactionReport);

                    sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount";
                    sInvoiceHistory = sInvoiceHistory + "\n\n";
                    sInvoiceHistory = sInvoiceHistory + _orptSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _orptSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
                    if (Utility.EmployeeID != -1)
                    {
                        _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
                        _oCustomerTransaction.Employee.ReadDB = true;
                        doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
                    }
                    else doc.SetParameterValue("JobLocation", "Sadar Road,Mohakhali C/A, Dhaka- 1206, Bangladesh");
                    doc.SetParameterValue("PrintBy", oUser.Username);
                    doc.SetParameterValue("InvoiceList", sInvoiceHistory);
                    doc.SetParameterValue("PrintStatus", "RePrint By");
                    doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
                    doc.SetParameterValue("TranDate", _oCustomerTransaction.TranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode);
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
                    doc.SetParameterValue("InstrumentType", Enum.GetName(typeof(Dictionary.InstrumentType), _oCustomerTransaction.InstrumentType));
                    if (_oCustomerTransaction.InstrumentType != 2)
                    {
                        doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                        doc.SetParameterValue("Date",Convert.ToDateTime( _oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("Branch", _oCustomerTransaction.Branch.Name);
                        _oBank = new Bank();
                        _oBank.BankID = _oCustomerTransaction.Branch.BankID;
                        _oBank.Refresh();
                        doc.SetParameterValue("Bank", _oBank.Name);  
                    }
                    else
                    {
                        doc.SetParameterValue("InstrumentNo", "N/A");
                        doc.SetParameterValue("Date", "N/A");
                        doc.SetParameterValue("Bank", "N/A");
                        doc.SetParameterValue("Branch", "N/A");
                    }
                    doc.SetParameterValue("Amount", _oCustomerTransaction.Amount.ToString());
                    doc.SetParameterValue("TK", oTELLib.TakaWords(_oCustomerTransaction.Amount));
                    doc.SetParameterValue("Remarks", _oCustomerTransaction.Remarks);

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Invoice System(Customer Transaction Recevied) [CTR]";
                    DBController.Instance.CloseConnection();

                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch
                {                 
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......Please check your input and save again ";
                }
            }
            else if (Utility.CompanyInfo == "TML")
            {

                try
                {
                    CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
                    oCustomerTransactionReport.Refresh(_oCustomerTransaction.TranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollection));
                    doc.SetDataSource(oCustomerTransactionReport);

                    sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount";
                    sInvoiceHistory = sInvoiceHistory + "\n\n";
                    sInvoiceHistory = sInvoiceHistory + _orptSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _orptSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
                    if (Utility.EmployeeID != -1)
                    {
                        _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
                        _oCustomerTransaction.Employee.ReadDB = true;
                        doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
                    }
                    else doc.SetParameterValue("JobLocation", "Sadar Road,Mohakhali C/A, Dhaka- 1206, Bangladesh");
                    doc.SetParameterValue("PrintBy", oUser.Username);
                    doc.SetParameterValue("InvoiceList", sInvoiceHistory);
                    doc.SetParameterValue("PrintStatus", "Re Print By");
                    doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
                    doc.SetParameterValue("TranDate", _oCustomerTransaction.TranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode);
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
                    doc.SetParameterValue("InstrumentType", Enum.GetName(typeof(Dictionary.InstrumentType), _oCustomerTransaction.InstrumentType));
                    doc.SetParameterValue("CompanyInfo", "TML");
                    doc.SetParameterValue("CompanyName", Utility.CompanyName);
                    if (_oCustomerTransaction.InstrumentType != 2)
                    {
                        doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                        doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("Branch", _oCustomerTransaction.Branch.Name);
                        _oBank = new Bank();
                        _oBank.BankID = _oCustomerTransaction.Branch.BankID;
                        _oBank.Refresh();
                        doc.SetParameterValue("Bank", _oBank.Name);
                    }
                    else
                    {
                        doc.SetParameterValue("InstrumentNo", "N/A");
                        doc.SetParameterValue("Date", "N/A");
                        doc.SetParameterValue("Bank", "N/A");
                        doc.SetParameterValue("Branch", "N/A");
                    }
                    doc.SetParameterValue("Amount", _oCustomerTransaction.Amount.ToString());
                    doc.SetParameterValue("TK", oTELLib.TakaWords(_oCustomerTransaction.Amount));
                    doc.SetParameterValue("Remarks", _oCustomerTransaction.Remarks);

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Invoice System(Customer Transaction Recevied) [CTR]";
                    DBController.Instance.CloseConnection();

                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......Please check your input and save again ";
                }

            }  

    }
}
