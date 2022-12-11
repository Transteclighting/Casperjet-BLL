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

public partial class frmInvoiceDelivery : System.Web.UI.Page
{
    SalesInvoice _oSalesInvoice;
    rptSalesInvoice _orptSalesInvoice;
    StockTran _oStockTran;
    ProductStock _oProductStock;
    TELLib oTELLib;
    long InvoiceID;
    int WarehouseID;
    int nSBUID;
    int nUserID;
    bool _bIsReprint = false;

    string SL = "";
    bool IsSL = true;

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
            WarehouseID = _oSalesInvoice.WarehouseID;
            _oSalesInvoice = new SalesInvoice();
            _oSalesInvoice.RefreshByInvoiceID(InvoiceID);
            nSBUID = _oSalesInvoice.CustomerDetail.SBUID;
            WarehouseID = _oSalesInvoice.WarehouseID;
            SetUI();
            Session.Add("InvoiceID", InvoiceID);
            Session.Add("SBUID", nSBUID);
            Session.Add("WarehouseID", WarehouseID);
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
            btPayment.Visible = false;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
        {
            lbInvoiceStatus.Text = "DELIVERED";
            btPayment.Visible = false;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PENDING)
        {
            lbInvoiceStatus.Text = "PENDING";
            btPayment.Visible = true;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
        {
            lbInvoiceStatus.Text = "PROCESSING DELIVERY";

            btPayment.Visible = false;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = true;
            if (Utility.CompanyInfo == "TML")
            {
                btIMEIPreserve.Visible = true;
            }
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
        {
            lbInvoiceStatus.Text = "PRODUCT RETURN";
            btPayment.Visible = false;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE)
        {
            lbInvoiceStatus.Text = "REVERSE";
            btPayment.Visible = false;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }
        if (_oSalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED)
        {
            lbInvoiceStatus.Text = "UNDELIVERED";

            btPayment.Visible = false;
            btProcessDelivery.Visible = true;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }

        if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.UNDELIVERED_DUE_TO_STOCK_LIMIT)
        {
            lbInvoiceStatus.Text = "UNDELIVERED DUE TO STOCK LIMIT";
            btPayment.Visible = false;
            btProcessDelivery.Visible = false;
            btDeliveryInvoice.Visible = false;
            btIMEIPreserve.Visible = false;
        }

    }

    protected void btProcessDelivery_Click(object sender, EventArgs e)
    {
        _bIsReprint = false;
        Session.Add("IsReprint", _bIsReprint);
        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];
        InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        nUserID = int.Parse(Session["UserID"].ToString());
        lblMessage.Visible = false;

        if (_oSalesInvoice != null)
        {
            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.UNDELIVERED)
            {
                try
                {
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.UserID = nUserID;
                    DBController.Instance.BeginNewTransaction();
                    _oSalesInvoice.UpadteInvoiceStatus(InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                    PrintDeliveryDoc();
                    DBController.Instance.CommitTran();
                    AppLogger.LogInfo("Web: Success fully Invoice system Processing (Process Delivery) =" + Utility.Username);
                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Web: error in Invoice system Processing (Process Delivery) =" + ex);
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is an error in Invoice Processing";
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
        _bIsReprint = false;
        Session.Add("IsReprint", _bIsReprint);

        InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        WarehouseID = Convert.ToInt32(Session["WarehouseID"].ToString());
        nSBUID = Convert.ToInt16(Session["SBUID"].ToString());
        nUserID = int.Parse(Session["UserID"].ToString());
        _oStockTran = new StockTran();
        _oProductStock = new ProductStock();
        DBController.Instance.OpenNewConnection();
        _oStockTran = SetData(_oStockTran);
        DBController.Instance.CloseConnection();
        lblMessage.Visible = false;

        if (_oSalesInvoice != null)
        {
            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
            {
                try
                {
                    _oSalesInvoice = new SalesInvoice();
                    DBController.Instance.BeginNewTransaction();
                    _oSalesInvoice.UserID = nUserID;
                    _oSalesInvoice.DeliveryInvoice(InvoiceID, (short)Dictionary.InvoiceStatus.DELIVERED, WarehouseID);
                    _oStockTran.UserID = nUserID;
                    _oStockTran.Insert();

                    if (_oStockTran.CheckTranNo() == false)
                    {
                        DBController.Instance.RollbackTransaction();
                        lblMessage.Visible = true;
                        AppLogger.LogError("Web: duplicate tran no");
                        lblMessage.Text = " Erorr...Duplicate tran no";
                        return;
                    }

                    foreach (StockTranItem oItem in _oStockTran)
                    {
                        _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                        if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            lblMessage.Visible = true;
                            AppLogger.LogError("Web: Stock Erorr...Stock can not be negative");
                            lblMessage.Text = "Stock Erorr...Stock can not be negative ";
                            return;
                        }
                        if ((_oProductStock.BookingStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            lblMessage.Visible = true;
                            AppLogger.LogError("Web: Stock Erorr...Stock can not be negative");
                            lblMessage.Text = "Stock Erorr...Stock can not be negative ";
                            return;
                        }

                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.Update(oItem.StockPrice);

                        if (_oProductStock.Flag == false)
                        {
                            DBController.Instance.RollbackTransaction();
                            lblMessage.Visible = true;
                            AppLogger.LogError("Web: Stock Erorr...Stock can not be negative");
                            lblMessage.Text = "Stock Erorr...Stock can not be negative ";
                            return;
                        }
                        PrintInvoice();
                        if (Utility.CompanyInfo == "TEL")
                        {
                            PrintVatChallan();
                        }

                    }
                    DBController.Instance.CommitTran();
                    AppLogger.LogInfo("Web: Successfully Invoice system Processing (Delivery Invoice)  =" + Utility.Username);
                    Response.Redirect("~/frmDeliveryInvoicePrintOptions.aspx");

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Web: error in Invoice system Processing (Delivery Invoice) =" + ex);
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is an error in Update Invoice Delivery";
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
    public StockTran SetData(StockTran oStockTran)
    {
        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];

        oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
        oStockTran.FromChannelID = _oSalesInvoice.CustomerDetail.ChannelID;
        oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
        oStockTran.ToChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
        oStockTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
        oStockTran.Remarks = _oSalesInvoice.Remarks;
        oStockTran.TranDate = DateTime.Today.Date;

        foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
        {
            StockTranItem oItem = new StockTranItem();
            oItem.ProductID = oSalesInvoiceItem.ProductID;
            oItem.Qty = oSalesInvoiceItem.Quantity + oSalesInvoiceItem.FreeQty;
            oItem.StockPrice = oSalesInvoiceItem.CostPrice;
            oStockTran.Add(oItem);
        }

        return oStockTran;
    }
    public void PrintInvoice()
    {
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
            docCus.SetParameterValue("Remarks", _orptSalesInvoice.Remarks);


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
            docCus.SetParameterValue("CompanyInfo", "TEL");

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

    protected void btPayment_Click(object sender, EventArgs e)
    {
        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];
        InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        User oUser = (User)Session["User"];
        lblMessage.Visible = false;

        if (_oSalesInvoice != null)
        {
            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.PENDING)
            {
                try
                {
                    _orptSalesInvoice = new rptSalesInvoice();
                    _orptSalesInvoice.InvoiceID = InvoiceID;
                    DBController.Instance.OpenNewConnection();
                    _orptSalesInvoice.Refresh();
                    DBController.Instance.CloseConnection();

                    Session.Add("SalesInvoice", _orptSalesInvoice);
                    AppLogger.LogInfo("Web: Success fully Invoice system Processing(Payment) =" + oUser.Username);
                    Response.Redirect("~/frmCustTranReceive.aspx");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Web: error in Invoice system Processing (Payment) =" + ex);
                    lblMessage.Visible = true;
                    lblMessage.Text = "There is an error in Invoice Processing";
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
    protected void btbtIMEIPreserve_Click(object sender, EventArgs e)
    {

        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];
        InvoiceID = Convert.ToInt64(Session["InvoiceID"].ToString());
        User oUser = (User)Session["User"];
        lblMessage.Visible = false;

        if (_oSalesInvoice != null)
        {
            if (_oSalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
            {
                Session.Remove("IMEI");

                Session.Add("IMEI", _oSalesInvoice);

                Response.Redirect("frmIMEIPreserve.aspx");

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
}

