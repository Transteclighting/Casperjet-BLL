// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sunadr Biswas
// Date: Sep 18;2011
// Time :  11:30 AM
// Description: Report.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;


namespace CJ.Class.Report
{
    [Serializable]
    public class rptInvoiceRegister
    {
        private long _SBUID;
        private long _ChannelID;
        private string _InvoiceNo;     
        private DateTime _InvoiceDate;     
        private double _InvoiceAmount;
        private double _Discount;   
        private string _CustomerCode;
        private string _CustomerName;         
        private string _DeliveredByName;
        private string _InvoiceByName;
        private string _OrderNo;
        private DateTime _OrderDate;
        private string _OrderConfirmedByName;
        private string _InvoiceStatusName;
        private string _ParentCustomerCode;
        private string _ParentCustomerName;
        private double _SalesProvission;
        private double _VatAmount;
        private string _ProductCode;
        private string _ProductDetail;
        private long _Qty;
        private double _UnitPrice;
        private double _InvoiceValue;
        private long _InvoiceID;
        
        private string _sSalesType;
        public string SalesType
        {
            get { return _sSalesType; }
            set { _sSalesType = value; }
        }
        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        public long ChannelID
        {
            get { return _ChannelID; }
            set { _ChannelID = value; }
        }
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }

        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public string DeliveredByName
        {
            get { return _DeliveredByName; }
            set { _DeliveredByName = value; }
        }
        public string InvoiceByName
        {
            get { return _InvoiceByName; }
            set { _InvoiceByName = value; }
        }
        public string OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; }
        }
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        public string OrderConfirmedByName
        {
            get { return _OrderConfirmedByName; }
            set { _OrderConfirmedByName = value; }
        }
        public string InvoiceStatusName
        {
            get { return _InvoiceStatusName; }
            set { _InvoiceStatusName = value; }
        }
        public string ParentCustomerCode
        {
            get { return _ParentCustomerCode; }
            set { _ParentCustomerCode = value; }
        }
        public string ParentCustomerName
        {
            get { return _ParentCustomerName; }
            set { _ParentCustomerName = value; }
        }       
        public double VatAmount
        {
            get { return _VatAmount; }
            set { _VatAmount = value; }
        }
        public double SalesProvission
        {
            get { return _SalesProvission; }
            set { _SalesProvission = value; }
        }
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        public string ProductDetail
        {
            get { return _ProductDetail; }
            set { _ProductDetail = value; }
        }
        public long Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public double InvoiceValue
        {
            get { return _InvoiceValue; }
            set { _InvoiceValue = value; }
        }
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        private string _sInvoiceTypeName;
        public string InvoiceTypeName
        {
            get { return _sInvoiceTypeName; }
            set { _sInvoiceTypeName = value; }
        }
        private double _NetAmount;
        public double NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }
        private double _GrossAmount;
        public double GrossAmount
        {
            get { return _GrossAmount; }
            set { _GrossAmount = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        private string _sBrandName;
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        private double _VAT11;
        public double VAT11
        {
            get { return _VAT11; }
            set { _VAT11 = value; }
        }
        private double _VAT11KA;
        public double VAT11KA
        {
            get { return _VAT11KA; }
            set { _VAT11KA = value; }
        }


        private double _TotalVat;
        public double TotalVat
        {
            get { return _TotalVat; }
            set { _TotalVat = value; }
        }

        private double _NetSales;
        public double NetSales
        {
            get { return _NetSales; }
            set { _NetSales = value; }
        }


        private double _ProductDisc;
        public double ProductDisc
        {
            get { return _ProductDisc; }
            set { _ProductDisc = value; }
        }
        private double _SpecialDisc;
        public double SpecialDisc
        {
            get { return _SpecialDisc; }
            set { _SpecialDisc = value; }
        }
        private double _Charge;
        public double Charge
        {
            get { return _Charge; }
            set { _Charge = value; }
        }
        private string _sEmployeeCode;
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }

        public int GetInvoiceQty(DateTime dFromDate, DateTime dToDate)
        {
            dToDate = dToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nInvoiceQty = 0;
            string sSql = "Select (crInvoQty-drInvoQty) as InvoiceQty from " +
                          "  ( " +
                          "  Select Sum(crInvoQty) as crInvoQty, Sum(drInvoQty) as drInvoQty " +
                          "  From " +
                          "  ( " +
                          "  select Count(InvoiceID) as crInvoQty, 0 as drInvoQty from t_SalesInvoice  " +
                          "  where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' and invoiceStatus = 2 " +
                          "  UNION ALL " +
                          "  select 0 as crInvoQty, Count(InvoiceID)as drInvoQty from t_SalesInvoice  " +
                          "  where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' and invoiceStatus = 4 " +
                          "  )a  " +
                          "  )x";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    nInvoiceQty = (int)reader["InvoiceQty"];

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nInvoiceQty;

        }
    }
    public class rptInvoiceRegisters : CollectionBaseCustom
    {

        public void Add(rptInvoiceRegister orptInvoiceRegister)
        {
            this.List.Add(orptInvoiceRegister);
        }
        public rptInvoiceRegister this[Int32 Index]
        {
            get
            {
                return (rptInvoiceRegister)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptInvoiceRegister))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        /// <summary>
        /// Invoice Register Report
        /// </summary>
       
        public void GetInvoiceRegister(DateTime dStartDate,DateTime dEndDate)
        {
            dEndDate = dEndDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandTimeout = 0;

            cmd.CommandText = " select qq1.*,qq2.UserName  AS DeliveredByName,qq3.EmployeeName as SalesPersonName,CustomerAddress, CustomerTelePhone,CustomerFax " +
                               " ,CellPhoneNo, ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,OrderNo, OrderDate, SBUID, SBUCode, SBUName, InvoiceTypeName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName " +
                               " , OrderReceivedByID, OrderConfirmedByID,  OrderReceivedByName, OrderConfirmedByName " +
                               " , isnull(qq4.ParentCustomerID, qq1.CustomerID) as ParentCustomerID,isnull(qq4.ParentCustomerCode, qq1.CustomerCode) as ParentCustomerCode,isnull(qq4.ParentCustomerName, qq1.CustomerName) as ParentCustomerName " +
                               " , qq7.UserName as UpdateUserName " +
                               " FROM  " +
                               " ( " +
                               " Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID,q2.CustomerName,q2.CustomerCode, WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName,IM.InvoiceDate, IM.VATChallanNo, IM.InvoiceTypeID, IT.InvoiceTypeName " +
                               " ,IM.InvoiceStatus,IM.OrderID,IM.SalesPersonID,IM.Remarks,IM.UpdateDate,IM.CreateDate,IM.InvoiceBy,IM.DeliveryAddress,IM.PriceOptionID,IM.DeliveredBy,IM.DeliveryDate " +
                               " ,IM.InvoicePrintCounter,IM.RefInvoiceID,IM.InvoicePrintByString,IM.DueAmount,IM.RefDetails,IM.UpdateUserID " +
                               " ,InvoiceAmount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE IM.Discount END, IM.OtherCharge " +
                               " ,WH.ChannelID,q5.ChannelCode, q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName  " +
                               " from t_SalesInvoice IM, t_InvoiceType IT, t_Warehouse WH,t_customer q2,t_User q4, t_Channel q5  " +
                               " where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ? " +
                               " and IM.WarehouseID = WH.WarehouseID AND q4.UserID = IM.InvoiceBy and WH.ChannelID = q5.ChannelID and IM.customerid = q2.customerid " +
                               " and IM.InvoiceTypeID in (?,?,?,?,?) and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID  " +
                               " UNION ALL  " +
                               " Select IM.InvoiceID, IM.Invoiceno, IM.CustomerID,q2.CustomerName,q2.CustomerCode,WH.WarehouseID, WH.WarehouseCode, WH.WarehouseName, IM.InvoiceDate, IM.VATChallanNo, IM.InvoiceTypeID, IT.InvoiceTypeName  " +
                               " ,IM.InvoiceStatus,IM.OrderID,IM.SalesPersonID,IM.Remarks,IM.UpdateDate,IM.CreateDate,IM.InvoiceBy,IM.DeliveryAddress,IM.PriceOptionID,IM.DeliveredBy,IM.DeliveryDate " +
                               " ,IM.InvoicePrintCounter,IM.RefInvoiceID,IM.InvoicePrintByString,IM.DueAmount,IM.RefDetails,IM.UpdateUserID " +
                               " ,InvoiceAmount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE -IM.InvoiceAmount END, Discount = CASE WHEN IM.InvoiceTypeID = ? THEN 0 ELSE -Abs(IM.Discount) END, IM.OtherCharge  " +
                               " ,WH.ChannelID,q5.ChannelCode, q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName " +
                               " from t_SalesInvoice IM, t_InvoiceType IT,  t_Warehouse WH, t_customer q2,t_User q4, t_Channel q5  " +
                               " where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ? " +
                               " and IM.WarehouseID = WH.WarehouseID AND q4.UserID = IM.InvoiceBy and WH.ChannelID = q5.ChannelID and IM.customerid = q2.customerid " +
                               " and IM.InvoiceTypeID in (?,?,?,?,?,?)  and InvoiceStatus not in (?) and IM.InvoiceTypeID = IT.InvoiceTypeID  " +
                               " ) " +
                               " as qq1 Left outer Join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as qq2 " +
                               " on qq1.DeliveredBy = qq2.UserID " +
                               " left outer join " +
                               " ( " +
                               " select AssignmentCode,JobTypeID,EmployeeName, q1.EmployeeID from t_EmployeeJobType q1, t_Employee q2  " +
                               " where q1.EmployeeID = q2.EmployeeID and  IsActive = ? and JobTypeID = ? " +
                               " ) " +
                               " as qq3 " +
                               " on qq1.SalesPersonID = qq3.EmployeeID " +
                               " left outer join " +
                               " ( " +
                               " select CustomerID, ParentCustomerID,ParentCustomerCode,ParentCustomerName, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, CustomerTypeCode, CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, SBUID, SBUCode, SBUName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName from v_customerDetails " +
                               " ) " +
                               " as qq4  " +
                               " on qq1.customerid = qq4.customerid " +
                               " Left outer join " +
                               " ( " +
                               " select q1.OrderID, q1.OrderNo, q1. OrderDate, q1.CreateUserID as OrderReceivedByID, q1.ConfirmUserID as OrderConfirmedByID,  q2.UserName as  OrderReceivedByName, q3.UserName as OrderConfirmedByName from " +
                               " ( " +
                               " select OrderID, OrderNo, OrderDate,CreateUserID, ConfirmUserID from t_salesOrder " +
                               " ) " +
                               " as q1 " +
                               " left outer join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as q2 " +
                               " on q1.CreateUserID = q2.UserID " +
                               " left outer join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as q3 " +
                               " on q1.ConfirmUserID = q3.UserID " +
                               " )  " +
                               " as qq5 " +
                               " on qq1.orderid = qq5.Orderid " +

                               " LEFT OUTER JOIN " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as qq7 " +
                               " on qq1.UpdateUserID = qq7.UserID ";



            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
            cmd.Parameters.AddWithValue("InvoiceDate", dStartDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);

            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);

            cmd.Parameters.AddWithValue("InvoiceDate", dStartDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);

            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);
            cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);


            GetInvoiceRegisterData(cmd);
        }
        private void GetInvoiceRegisterData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptInvoiceRegister oItem = new rptInvoiceRegister();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = 0;
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt64(reader["ChannelID"]);
                    else oItem.ChannelID = 0;
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oItem.InvoiceNo = reader["InvoiceNo"].ToString();
                    else oItem.InvoiceNo = "";
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                    else oItem.InvoiceDate = Convert.ToDateTime("01-01-2000");
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]);
                    else oItem.InvoiceAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oItem.Discount = Convert.ToDouble(reader["Discount"]);
                    else oItem.Discount = 0;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = reader["CustomerCode"].ToString();
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = reader["CustomerName"].ToString();
                    else oItem.CustomerName = "";
                    if (reader["DeliveredByName"] != DBNull.Value)
                        oItem.DeliveredByName = reader["DeliveredByName"].ToString();
                    else oItem.DeliveredByName = "";
                    if (reader["InvoiceByName"] != DBNull.Value)
                        oItem.InvoiceByName = reader["InvoiceByName"].ToString();
                    else oItem.InvoiceByName = "";
                    if (reader["OrderNo"] != DBNull.Value)
                        oItem.OrderNo = reader["OrderNo"].ToString();
                    else oItem.OrderNo = oItem.InvoiceNo;
                    if (reader["OrderDate"] != DBNull.Value)
                        oItem.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    else oItem.OrderDate = oItem.InvoiceDate;
                    if (reader["OrderConfirmedByName"] != DBNull.Value)
                        oItem.OrderConfirmedByName = reader["OrderConfirmedByName"].ToString();
                    else oItem.OrderConfirmedByName = "";
                    //if (reader["InvoiceStatusName"] != DBNull.Value)
                    //    oItem.InvoiceStatusName = reader["InvoiceStatusName"].ToString();
                    //else oItem.InvoiceStatusName = "";
                  
                    if ( int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.CANCEL)
                    {
                        oItem.InvoiceStatusName = "CANCEL";
                    }
                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.DELIVERED)
                    {
                        oItem.InvoiceStatusName = "DELIVERED";
                    }
                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.PENDING)
                    {
                        oItem.InvoiceStatusName = "PENDING";
                    }
                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
                    {
                        oItem.InvoiceStatusName = "PROCESSING DELIVERY";
                    }
                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
                    {
                        oItem.InvoiceStatusName = "PRODUCT RETURN";
                    }
                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.REVERSE)
                    {
                        oItem.InvoiceStatusName = "REVERSE"; ;
                    }
                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (int)Dictionary.InvoiceStatus.UNDELIVERED)
                    {
                        oItem.InvoiceStatusName = "UNDELIVERED";
                    }

                    if (int.Parse( reader["InvoiceStatus"].ToString()) == (short)Dictionary.InvoiceStatus.UNDELIVERED_DUE_TO_STOCK_LIMIT)
                    {
                        oItem.InvoiceStatusName = "UNDELIVERED DUE TO STOCK LIMIT";
                    }

                    if (reader["ParentCustomerCode"] != DBNull.Value)
                        oItem.ParentCustomerCode = reader["ParentCustomerCode"].ToString();
                    else oItem.ParentCustomerCode = "";
                    if (reader["ParentCustomerName"] != DBNull.Value)
                        oItem.ParentCustomerName = reader["ParentCustomerName"].ToString();
                    else oItem.ParentCustomerName = "";
                    //if (reader["SalesProvission"] != DBNull.Value)
                    //    oItem.SalesProvission = Convert.ToDouble(reader["SalesProvission"]);
                    //else oItem.SalesProvission = 0;                    
                    //if (reader["VatAmount"] != DBNull.Value)
                    //    oItem.VatAmount = Convert.ToDouble(reader["VatAmount"]);
                    //else oItem.VatAmount = 0;                   
                    //if (reader["ProductCode"] != DBNull.Value)
                    //    oItem.ProductCode = reader["ProductCode"].ToString();
                    //else oItem.ProductCode = "";
                    //if (reader["ProductDetail"] != DBNull.Value)
                    //    oItem.ProductDetail = reader["ProductDetail"].ToString();
                    //else oItem.ProductDetail = "";
                    //if (reader["Qty"] != DBNull.Value)
                    //    oItem.Qty = Convert.ToInt64(reader["Qty"]);
                    //else oItem.Qty = 0;
                    //if (reader["UnitPrice"] != DBNull.Value)
                    //    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    //else oItem.UnitPrice = 0;
                    //if (reader["InvoiceValue"] != DBNull.Value)
                    //    oItem.InvoiceValue = Convert.ToDouble(reader["InvoiceValue"]);
                    //else oItem.InvoiceValue = 0;
                    //if (reader["InvoiceID"] != DBNull.Value)
                    //    oItem.InvoiceID = Convert.ToInt64(reader["InvoiceID"]);
                    //else oItem.InvoiceID = 0;
                    oItem.VatAmount = 0;
                    oItem.SalesProvission = 0;
                    oItem.ProductCode = "";
                    oItem.ProductDetail = "";
                    oItem.Qty = 0;
                    oItem.UnitPrice = 0;
                    oItem.InvoiceValue = 0;
                    oItem.InvoiceID = 0;

                     Add(oItem);
                 }
               
                 reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetInvoiceRegister(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptInvoiceRegister oItem = new rptInvoiceRegister();

                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.ChannelID = Convert.ToInt64(oRow["ChannelID"]);
                    oItem.InvoiceNo = oRow["InvoiceNo"].ToString();
                    oItem.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"]);
                    oItem.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"]);
                    oItem.Discount = Convert.ToDouble(oRow["Discount"]);
                    oItem.CustomerCode = oRow["CustomerCode"].ToString();
                    oItem.CustomerName = oRow["CustomerName"].ToString();
                    oItem.DeliveredByName = oRow["DeliveredByName"].ToString();
                    oItem.InvoiceByName = oRow["InvoiceByName"].ToString();
                    oItem.OrderNo = oRow["OrderNo"].ToString();
                    oItem.OrderDate = Convert.ToDateTime(oRow["OrderDate"]);
                    oItem.OrderConfirmedByName = oRow["OrderConfirmedByName"].ToString();
                    oItem.InvoiceStatusName = oRow["InvoiceStatusName"].ToString();
                    oItem.ParentCustomerCode = oRow["ParentCustomerCode"].ToString();
                    oItem.ParentCustomerName = oRow["ParentCustomerName"].ToString();
                    oItem.SalesProvission = Convert.ToDouble(oRow["SalesProvission"]);
                    oItem.VatAmount = Convert.ToDouble(oRow["VatAmount"]);
                    oItem.ProductCode = oRow["ProductCode"].ToString();
                    oItem.ProductDetail = oRow["ProductDetail"].ToString();
                    oItem.Qty = Convert.ToInt64(oRow["Qty"]);
                    oItem.UnitPrice = Convert.ToDouble(oRow["UnitPrice"]);
                    oItem.InvoiceValue = Convert.ToDouble(oRow["InvoiceValue"]);
                    oItem.InvoiceID = Convert.ToInt64(oRow["InvoiceID"]);

                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Invoice Register Report
        /// </summary>

        public void GetInvoiceRegisterDetail(DateTime dStartDate, DateTime dEndDate)
        {
            dEndDate = dEndDate.AddDays(1);
            StringBuilder sQueryStringMaster = new StringBuilder();
            sQueryStringMaster.Append("Select * from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("SELECT   ");
            sQueryStringMaster.Append("IM.InvoiceId, IM.InvoiceDate as OrderDate, IM.InvoiceNo as SalesOrderNo ,IM.InvoiceNo, IM.InvoiceDate,IM.InvoiceAmount, IM.Discount   ");
            sQueryStringMaster.Append(",CD.CustomerCode, CD.CustomerName, CD.CustomerID,CD.ChannelId, CD.ChannelCode, CD.ChannelDescription as ChannelName,CD.SBUID,CD.SBUCode,CD.SBUName      ");
            sQueryStringMaster.Append(",vatamount as VatAmount,ID.Quantity as Qty,ID.UnitPrice as UnitPrice, (ID.Quantity * ID.UnitPrice) as InvoiceValue,PD.ProductCode, PD.ProductName as ProductDetail,PD.SmallUnitOfMeasure as UOM   ");
            sQueryStringMaster.Append("from t_SalesInvoice  IM, t_SalesInvoiceDetail ID, v_customerDetails CD, v_ProductDetails PD   ");
            sQueryStringMaster.Append("where IM.InvoiceID = ID.InvoiceID and ID.Productid = PD.Productid and IM.CustomerID = CD.CustomerId and invoicetypeid in (?,?,?,?)   ");
            sQueryStringMaster.Append("and IM.Invoicedate between ? and ? and IM.Invoicedate < ? and IM.InvoiceStatus not in (?)  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("SELECT   ");
            sQueryStringMaster.Append("IM.InvoiceId, IM.InvoiceDate as OrderDate, IM.InvoiceNo as SalesOrderNo ,IM.InvoiceNo, IM.InvoiceDate,-IM.InvoiceAmount as InvoiceAmount, -IM.Discount as Discount  ");
            sQueryStringMaster.Append(",CD.CustomerCode, CD.CustomerName, CD.CustomerID,CD.ChannelId, CD.ChannelCode, CD.ChannelDescription as ChannelName,CD.SBUID,CD.SBUCode,CD.SBUName      ");
            sQueryStringMaster.Append(",vatamount as VatAmount,-ID.Quantity as Qty,ID.UnitPrice as UnitPrice, -1*(ID.Quantity * ID.UnitPrice) as InvoiceValue,PD.ProductCode, PD.ProductName as ProductDetail,PD.SmallUnitOfMeasure as UOM   ");
            sQueryStringMaster.Append("from t_SalesInvoice  IM, t_SalesInvoiceDetail ID, v_customerDetails CD, v_ProductDetails PD   ");
            sQueryStringMaster.Append("where IM.InvoiceID = ID.InvoiceID and ID.Productid = PD.Productid and IM.CustomerID = CD.CustomerId and invoicetypeid in (?,?,?,?,?)   ");
            sQueryStringMaster.Append("and IM.Invoicedate between ? and ? and IM.Invoicedate < ? and IM.InvoiceStatus not in (?)  ");
            sQueryStringMaster.Append(") as Final    ");

            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);

            cmd.Parameters.AddWithValue("InvoiceDate", dStartDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);


            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);

            cmd.Parameters.AddWithValue("InvoiceDate", dStartDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dEndDate);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);


            GetInvoiceRegisterDetailData(cmd);
        }
        private void GetInvoiceRegisterDetailData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptInvoiceRegister oItem = new rptInvoiceRegister();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt64(reader["SBUID"]);
                    else oItem.SBUID = 0;
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt64(reader["ChannelID"]);
                    else oItem.ChannelID = 0;
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oItem.InvoiceNo = reader["InvoiceNo"].ToString();
                    else oItem.InvoiceNo = "";
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                    else oItem.InvoiceDate = Convert.ToDateTime("01-01-2000");
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]);
                    else oItem.InvoiceAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        oItem.Discount = Convert.ToDouble(reader["Discount"]);
                    else oItem.Discount = 0;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = reader["CustomerCode"].ToString();
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = reader["CustomerName"].ToString();
                    else oItem.CustomerName = "";

                    //if (reader["DeliveredByName"] != DBNull.Value)
                    //    oItem.DeliveredByName = reader["DeliveredByName"].ToString();
                    //else oItem.DeliveredByName = "";
                    //if (reader["InvoiceByName"] != DBNull.Value)
                    //    oItem.InvoiceByName = reader["InvoiceByName"].ToString();
                    //else oItem.InvoiceByName = "";
                    //if (reader["OrderNo"] != DBNull.Value)
                    //    oItem.OrderNo = reader["OrderNo"].ToString();
                    //else oItem.OrderNo = oItem.InvoiceNo;
                    //if (reader["OrderDate"] != DBNull.Value)
                    //    oItem.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    //else oItem.OrderDate = oItem.InvoiceDate;
                    //if (reader["OrderConfirmedByName"] != DBNull.Value)
                    //    oItem.OrderConfirmedByName = reader["OrderConfirmedByName"].ToString();
                    //else oItem.OrderConfirmedByName = "";
                    //oItem.InvoiceStatusName = "";     
                    //if (reader["ParentCustomerCode"] != DBNull.Value)
                    //    oItem.ParentCustomerCode = reader["ParentCustomerCode"].ToString();
                    //else oItem.ParentCustomerCode = "";
                    //if (reader["ParentCustomerName"] != DBNull.Value)
                    //    oItem.ParentCustomerName = reader["ParentCustomerName"].ToString();
                    //else oItem.ParentCustomerName = "";
                    //if (reader["SalesProvission"] != DBNull.Value)
                    //    oItem.SalesProvission = Convert.ToDouble(reader["SalesProvission"]);
                    //else oItem.SalesProvission = 0;

                    oItem.DeliveredByName = "";
                    oItem.InvoiceByName = "";
                    oItem.OrderNo = "";
                    oItem.OrderDate = oItem.InvoiceDate;
                    oItem.OrderConfirmedByName = "";
                    oItem.InvoiceStatusName = "";
                    oItem.ParentCustomerCode = "";
                    oItem.ParentCustomerName = "";
                    oItem.SalesProvission = 0.00;
                   
                   
                    if (reader["VatAmount"] != DBNull.Value)
                        oItem.VatAmount = Convert.ToDouble(reader["VatAmount"]);
                    else oItem.VatAmount = 0;
                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = reader["ProductCode"].ToString();
                    else oItem.ProductCode = "";
                    if (reader["ProductDetail"] != DBNull.Value)
                        oItem.ProductDetail = reader["ProductDetail"].ToString();
                    else oItem.ProductDetail = "";
                    if (reader["Qty"] != DBNull.Value)
                        oItem.Qty = Convert.ToInt64(reader["Qty"]);
                    else oItem.Qty = 0;
                    if (reader["UnitPrice"] != DBNull.Value)
                        oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    else oItem.UnitPrice = 0;
                    if (reader["InvoiceValue"] != DBNull.Value)
                        oItem.InvoiceValue = Convert.ToDouble(reader["InvoiceValue"]);
                    else oItem.InvoiceValue = 0;
                    if (reader["InvoiceID"] != DBNull.Value)
                        oItem.InvoiceID = Convert.ToInt64(reader["InvoiceID"]);
                    else oItem.InvoiceID = 0;
                   

                    Add(oItem);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetInvoiceRegisterDetail(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptInvoiceRegister oItem = new rptInvoiceRegister();

                    oItem.SBUID = Convert.ToInt64(oRow["SBUID"]);
                    oItem.ChannelID = Convert.ToInt64(oRow["ChannelID"]);
                    oItem.InvoiceNo = oRow["InvoiceNo"].ToString();
                    oItem.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"]);
                    oItem.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"]);
                    oItem.Discount = Convert.ToDouble(oRow["Discount"]);
                    oItem.CustomerCode = oRow["CustomerCode"].ToString();
                    oItem.CustomerName = oRow["CustomerName"].ToString();
                    oItem.DeliveredByName = oRow["DeliveredByName"].ToString();
                    oItem.InvoiceByName = oRow["InvoiceByName"].ToString();
                    oItem.OrderNo = oRow["OrderNo"].ToString();
                    oItem.OrderDate = Convert.ToDateTime(oRow["OrderDate"]);
                    oItem.OrderConfirmedByName = oRow["OrderConfirmedByName"].ToString();
                    oItem.InvoiceStatusName = oRow["InvoiceStatusName"].ToString();
                    oItem.ParentCustomerCode = oRow["ParentCustomerCode"].ToString();
                    oItem.ParentCustomerName = oRow["ParentCustomerName"].ToString();
                    oItem.SalesProvission = Convert.ToDouble(oRow["SalesProvission"]);
                    oItem.VatAmount = Convert.ToDouble(oRow["VatAmount"]);
                    oItem.ProductCode = oRow["ProductCode"].ToString();
                    oItem.ProductDetail = oRow["ProductDetail"].ToString();
                    oItem.Qty = Convert.ToInt64(oRow["Qty"]);
                    oItem.UnitPrice = Convert.ToDouble(oRow["UnitPrice"]);
                    oItem.InvoiceValue = Convert.ToDouble(oRow["InvoiceValue"]);
                    oItem.InvoiceID = Convert.ToInt64(oRow["InvoiceID"]);

                    InnerList.Add(oItem);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPOSInvoiceRegister(string sInvoiceNo, DateTime dFromDate, DateTime dToDate, string sSalesType)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            if (Utility.CompanyInfo == "TEL")
            {
                //sSql = "Select * From (  "+
                //                "select SalesType=case when SalesType=3 then 'B2B' when SalesType=5 then 'Dealer' else 'Retail' end,InvoiceNo,InvoiceDate,ConsumerName, ConsumerCode, VAT11, VAT11KA,SpecialDisc, ProductDisc,Charge, empl.EmployeeCode, EmployeeName, " +
                //                "IsNull(InvoiceTypeName,'') as InvoiceType,  " +
                //                "case when InvoiceStatus=1 then 'UNDELIVERED'  " +
                //                "when InvoiceStatus=2 then 'DELIVERED' when InvoiceStatus=3 then 'CANCEL'  " +
                //                "when InvoiceStatus=4 then 'REVERSE' when InvoiceStatus=5 then 'PENDING'  " +
                //                "when InvoiceStatus=6 then 'PROCESSING_DELIVERY' when InvoiceStatus=7 then 'PRODUCT_RETURN'  " +
                //                "when InvoiceStatus=8 then 'UNDELIVERED_DUE_TO_STOCK_LIMIT' else 'Other'  " +
                //                "end as InvoiceStatusName,InvoiceStatus,InvoiceAmount,Discount,   " +
                //                "(InvoiceAmount+Discount)as GrossSale, VATChallanNo from t_salesInvoice a  " +
                //                "Left Outer JOIN t_InvoiceType b ON a.InvoiceTypeID=b.InvoiceTypeID " +
                //                "INNER JOIN t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID " +
                //                "INNER JOIN " +
                //                "(Select DocumentNo, Sum(case ChallanTypeID when 1 then Amount  else 0 end) as VAT11, " +
                //                "Sum(case ChallanTypeID when 2 then Amount  else 0 end) as VAT11KA " +
                //                "from " +
                //                "(select DocumentNo, ChallanTypeID, Amount from t_DutyTranOutlet)a group by DocumentNo)VAT " +
                //                "ON a.InvoiceNo=VAT.DocumentNo " +
                //                "INNER JOIN  " +
                //                "(select InvoiceID,FaltAmount as SpecialDisc, SPDiscount as ProductDisc, (InstallationCharge + FreightCharge + OtherCharge) as Charge  from t_SalesInvoiceOtherInfo Where SPParcentage =0 " +
                //                "UNION ALL " +
                //                "select a.InvoiceID,(Amount * SPParcentage /100) as SpecialDisc, SPDiscount as ProductDisc, (InstallationCharge + FreightCharge + OtherCharge) as Charge  from t_SalesInvoiceOtherInfo a,  " +
                //                "(select InvoiceID, SUM(Quantity*UnitPrice) as Amount from t_SalesInvoiceDetail Group by InvoiceID)b Where a.InvoiceID=b.InvoiceID and SPParcentage <>0)Cha " +
                //                "ON a.InvoiceID=cha.InvoiceID INNER JOIN t_Employee empl ON a.SalesPersonID=empl.EmployeeID) Main  " +
                //                "Where InvoiceDate Between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ";

                sSql = "Select * From (Select * From (  " +
                                "select SalesType=case when SalesType=3 then 'B2B' when SalesType=5 then 'Dealer' else 'Retail' end,InvoiceNo,InvoiceDate,ConsumerName, ConsumerCode, VAT11, VAT11KA,SpecialDisc, ProductDisc,Charge, empl.EmployeeCode, EmployeeName, " +
                                "IsNull(InvoiceTypeName,'') as InvoiceType,  " +
                                "case when InvoiceStatus=1 then 'UNDELIVERED'  " +
                                "when InvoiceStatus=2 then 'DELIVERED' when InvoiceStatus=3 then 'CANCEL'  " +
                                "when InvoiceStatus=4 then 'REVERSE' when InvoiceStatus=5 then 'PENDING'  " +
                                "when InvoiceStatus=6 then 'PROCESSING_DELIVERY' when InvoiceStatus=7 then 'PRODUCT_RETURN'  " +
                                "when InvoiceStatus=8 then 'UNDELIVERED_DUE_TO_STOCK_LIMIT' else 'Other'  " +
                                "end as InvoiceStatusName,InvoiceStatus,InvoiceAmount,Discount,   " +
                                "(InvoiceAmount+Discount)as GrossSale, VATChallanNo from t_salesInvoice a  " +
                                "Left Outer JOIN t_InvoiceType b ON a.InvoiceTypeID=b.InvoiceTypeID " +
                                "INNER JOIN t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID " +
                                "INNER JOIN " +
                                "(Select DocumentNo, Sum(case ChallanTypeID when 1 then Amount  else 0 end) as VAT11, " +
                                "Sum(case ChallanTypeID when 2 then Amount  else 0 end) as VAT11KA " +
                                "from " +
                                "(select DocumentNo, ChallanTypeID, Amount from t_DutyTranOutlet)a group by DocumentNo)VAT " +
                                "ON a.InvoiceNo=VAT.DocumentNo " +
                                "INNER JOIN  " +
                                "(select InvoiceID,FaltAmount as SpecialDisc, SPDiscount as ProductDisc, (InstallationCharge + FreightCharge + OtherCharge) as Charge  from t_SalesInvoiceOtherInfo Where SPParcentage =0 " +
                                "UNION ALL " +
                                "select a.InvoiceID,(Amount * SPParcentage /100) as SpecialDisc, SPDiscount as ProductDisc, (InstallationCharge + FreightCharge + OtherCharge) as Charge  from t_SalesInvoiceOtherInfo a,  " +
                                "(select InvoiceID, SUM(Quantity*UnitPrice) as Amount from t_SalesInvoiceDetail Group by InvoiceID)b Where a.InvoiceID=b.InvoiceID and SPParcentage <>0)Cha " +
                                "ON a.InvoiceID=cha.InvoiceID INNER JOIN t_Employee empl ON a.SalesPersonID=empl.EmployeeID) Main  " +
                                "Where InvoiceDate Between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
                                "Union All " +
                                "Select SalesType,InvoiceNo,InvoiceDate,ConsumerName,ConsumerCode,  " +
                                "VAT11,VAT11KA,0 SpecialDisc,0 ProductDisc,Charge,EmployeeCode,EmployeeName, " +
                                "InvoiceType,InvoiceStatusName,InvoiceStatus,GrossSale InvoiceAmount, Discount, GrossSale, VATChallanNo  " +
                                "From   " +
                                "(  " +
                                "Select  SalesType =case when SalesType = 3 then 'B2B'  " +
                                "when SalesType = 5 then 'Dealer' else 'Retail' end,  " +
                                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode, d.Discount, d.Charge,  " +
                                "InvoiceAmount as GrossSale, VATChallanNo,  " +
                                "c.EmployeeCode, EmployeeName,  " +
                                "case when InvoiceStatus = 1 then 'UNDELIVERED'  when InvoiceStatus = 2 then 'DELIVERED'  " +
                                "when InvoiceStatus = 3 then 'CANCEL'  when InvoiceStatus = 4 then 'REVERSE'  " +
                                "when InvoiceStatus = 5 then 'PENDING'  when InvoiceStatus = 6 then 'PROCESSING_DELIVERY'  " +
                                "when InvoiceStatus = 7 then 'PRODUCT_RETURN'  when InvoiceStatus = 8  " +
                                "then 'UNDELIVERED_DUE_TO_STOCK_LIMIT' else 'Other'  end as InvoiceStatusName,  " +
                                "InvoiceStatus, InvoiceTypeName InvoiceType  " +
                                "From t_SalesInvoice a, t_RetailConsumer b, t_Employee c,  " +
                                "(Select InvoiceID, sum(Charges)Charge, sum(Discounts) Discount  " +
                                "From t_SalesInvoiceDetailNew group by InvoiceID) d,t_InvoiceType e  " +
                                "where a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID  " +
                                "and a.InvoiceID = d.InvoiceID and a.InvoiceTypeID = e.InvoiceTypeID and  " +
                                "InvoiceDate Between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                                ") a  " +
                                "INNER JOIN  " +
                                "(  " +
                                "Select DocumentNo,  " +
                                "Sum(case ChallanTypeID when 1 then Amount  else 0 end) as VAT11,  " +
                                "Sum(case ChallanTypeID when 2 then Amount  else 0 end) as VAT11KA  " +
                                "from  " +
                                "(  " +
                                "select DocumentNo, ChallanTypeID, Amount from t_DutyTranOutlet  " +
                                ")a  " +
                                "group by DocumentNo  " +
                                ") VAT " +
                                "ON a.InvoiceNo = VAT.DocumentNo) Main where 1=1";



                if (sInvoiceNo.Trim() != "")
                {
                    sSql = sSql + " and InvoiceNo='" + sInvoiceNo + "'";
                }
                if (sSalesType.Trim() != "<All>")
                {
                    sSql = sSql + " and SalesType='" + sSalesType + "'";
                }

                sSql = sSql + " order by InvoiceNo";
            }
            else
            {
                sSql = "Select * From (  "+
                                    "select SalesType=case when SalesType=3 then 'B2B' when SalesType=5 then 'Dealer' else 'Retail' end,InvoiceNo,InvoiceDate,ConsumerName, ConsumerCode, 0 as VAT11, 0 as VAT11KA,SpecialDisc, ProductDisc,Charge, empl.EmployeeCode, EmployeeName, " +
                                    "IsNull(InvoiceTypeName,'') as InvoiceType,  " +
                                    "case when InvoiceStatus=1 then 'UNDELIVERED'  " +
                                    "when InvoiceStatus=2 then 'DELIVERED' when InvoiceStatus=3 then 'CANCEL'  " +
                                    "when InvoiceStatus=4 then 'REVERSE' when InvoiceStatus=5 then 'PENDING'  " +
                                    "when InvoiceStatus=6 then 'PROCESSING_DELIVERY' when InvoiceStatus=7 then 'PRODUCT_RETURN'  " +
                                    "when InvoiceStatus=8 then 'UNDELIVERED_DUE_TO_STOCK_LIMIT' else 'Other'  " +
                                    "end as InvoiceStatusName,InvoiceStatus,InvoiceAmount,Discount,   " +
                                    "(InvoiceAmount+Discount)as GrossSale, VATChallanNo from t_salesInvoice a  " +
                                    "Left Outer JOIN t_InvoiceType b ON a.InvoiceTypeID=b.InvoiceTypeID " +
                                    "INNER JOIN t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID " +
                                    "INNER JOIN  " +
                                    "(select InvoiceID,FaltAmount as SpecialDisc, SPDiscount as ProductDisc, (InstallationCharge + FreightCharge + OtherCharge) as Charge  from t_SalesInvoiceOtherInfo Where SPParcentage =0 " +
                                    "UNION ALL " +
                                    "select a.InvoiceID,(Amount * SPParcentage /100) as SpecialDisc, SPDiscount as ProductDisc, (InstallationCharge + FreightCharge + OtherCharge) as Charge  from t_SalesInvoiceOtherInfo a,  " +
                                    "(select InvoiceID, SUM(Quantity*UnitPrice) as Amount from t_SalesInvoiceDetail Group by InvoiceID)b Where a.InvoiceID=b.InvoiceID and SPParcentage <>0)Cha " +
                                    "ON a.InvoiceID=cha.InvoiceID INNER JOIN t_Employee empl ON a.SalesPersonID=empl.EmployeeID) Main  " +
                                    "Where InvoiceDate Between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ";

                if (sInvoiceNo.Trim() != "")
                {
                    sSql = sSql + " and InvoiceNo='" + sInvoiceNo + "'";
                }
                if (sSalesType.Trim() != "<All>")
                {
                    sSql = sSql + " and SalesType='" + sSalesType + "'";
                }
                sSql = sSql + " order by InvoiceNo";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();
                    _orptInvoiceRegister.SalesType = reader["SalesType"].ToString(); 
                    _orptInvoiceRegister.InvoiceNo = reader["InvoiceNo"].ToString();
                    _orptInvoiceRegister.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _orptInvoiceRegister.InvoiceStatusName = reader["InvoiceStatusName"].ToString();
                    _orptInvoiceRegister.InvoiceTypeName = reader["InvoiceType"].ToString();
                    _orptInvoiceRegister.CustomerCode = (string)reader["ConsumerCode"];
                    _orptInvoiceRegister.CustomerName = (string)reader["ConsumerName"];
                    _orptInvoiceRegister.EmployeeCode = (string)reader["EmployeeCode"];
                    _orptInvoiceRegister.EmployeeName = (string)reader["EmployeeName"];
                    if (Convert.ToInt32(reader["InvoiceStatus"]) != (int)Dictionary.InvoiceStatus.REVERSE)
                    {
                        _orptInvoiceRegister.Discount = Convert.ToDouble(reader["Discount"].ToString());
                        _orptInvoiceRegister.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                        _orptInvoiceRegister.GrossAmount = Convert.ToDouble(reader["GrossSale"].ToString());
                        _orptInvoiceRegister.VAT11 = Convert.ToDouble(reader["VAT11"].ToString());
                        _orptInvoiceRegister.VAT11KA = Convert.ToDouble(reader["VAT11KA"].ToString());
                        _orptInvoiceRegister.SpecialDisc = Convert.ToDouble(reader["SpecialDisc"].ToString());
                        _orptInvoiceRegister.ProductDisc = Convert.ToDouble(reader["ProductDisc"].ToString());
                        _orptInvoiceRegister.Charge = Convert.ToDouble(reader["Charge"].ToString());
                    }
                    else
                    {
                        _orptInvoiceRegister.Discount = Convert.ToDouble(reader["Discount"]) * -1.00;
                        _orptInvoiceRegister.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]) * -1.00;
                        _orptInvoiceRegister.GrossAmount = Convert.ToDouble(reader["GrossSale"]) * -1.00;
                        _orptInvoiceRegister.VAT11 = Convert.ToDouble(reader["VAT11"].ToString()) * -1.00;
                        _orptInvoiceRegister.VAT11KA = Convert.ToDouble(reader["VAT11KA"].ToString()) * -1.00;
                        _orptInvoiceRegister.SpecialDisc = Convert.ToDouble(reader["SpecialDisc"].ToString()) * -1.00;
                        _orptInvoiceRegister.ProductDisc = Convert.ToDouble(reader["ProductDisc"].ToString()) * -1.00;
                        _orptInvoiceRegister.Charge = Convert.ToDouble(reader["Charge"].ToString()) * -1.00;
                    }
                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPOSSaleASG(DateTime dFromDate, DateTime dToDate)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ASGName,Brand,Sum(SalesQty) as SalesQty,Sum(GrossSales) as GrossSales,Sum(Discount) as Discount,Sum(OC) as OC, " +
                          "  Sum(VAT) as VAT,Sum(NetSales) as NetSales,Sum(COGS) as COGS  " +
                          "  from " +
                          "  ( " +
                          "  Select ASGName,BrandDesc as Brand, SalesQty,GrossSales,Discount,OC,sales.VAT,(GrossSales+OC-sales.VAT-Discount) as NetSales,COGS " +
                          "  from " +
                          "  ( " +
                          " Select ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                          "  isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                          "  From " +
                          "  ( " +
                          "  Select ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                          "  sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                          "  from " +
                          "  ( " +
                          "  Select a.InvoiceID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC, " +
                          "  (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                          "  from " +
                          "  ( " +
                          "  select sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity " +
                          "  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                          "  where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                          "  and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
                          "  )as a " +
                          "  left outer join " +
                          "  ( " +
                          "  select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC " +
                          "  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                          "  where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                          "  and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
                          "  group by sa.InvoiceID,Discount,OtherCharge " +
                          "  ) as b on a.invoiceid = b.invoiceid " +
                          "  ) as final " +
                          "  Group By ProductID " +
                          "  Union all " +
                          "  Select ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                          "  0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                          "  from " +
                          "  ( " +
                          "  Select a.InvoiceID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC, " +
                          "  (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                          "  from " +
                          "  ( " +
                          "  select sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity " +
                          "  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                          "  where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                          "  and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                          "  )as a " +
                          "  left outer join " +
                          "  ( " +
                          "  select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC " +
                          "  from t_salesinvoice sa, t_salesinvoicedetail sd " +
                          "  where sa.invoiceid = sd.invoiceid and invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                          "  and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                          "  group by sa.InvoiceID,Discount,OtherCharge " +
                          "  ) as b on a.invoiceid = b.invoiceid " +
                          "  ) as final " +
                          "  Group By ProductID " +
                          "  )as FinalQuery " +
                          "  Group by " +
                          "  ProductID " +
                          "  ) as sales " +
                          "  inner join " +
                          "  ( " +
                          "  Select ProductID, ASGID, ASGName, BrandID, BrandDesc from v_productdetails " +
                          "  ) as p on sales.productid = p.productid " +
                          "  ) as a " +
                          "  Group by ASGName,Brand Order by ASGName,Brand";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();

                    _orptInvoiceRegister.ASGName = (string)reader["ASGName"];
                    _orptInvoiceRegister.BrandName = (string)reader["Brand"];
                    _orptInvoiceRegister.Qty = Convert.ToInt64(reader["SalesQty"]);
                    _orptInvoiceRegister.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void RefreshPOSSaleASGRT(DateTime dFromDate, DateTime dToDate)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = String.Format(@"Select ASGName,Brand,Sum(SalesQty) as SalesQty,Sum(GrossSales)
                as GrossSales,Sum(Discount) as Discount,Sum(OC) as OC,   Sum(VAT) as VAT,Sum(NetSales) as NetSales,Sum(COGS) 
                as COGS    from   (   Select ASGName,BrandDesc as Brand, SalesQty,GrossSales,Discount,OC,sales.VAT,
                (GrossSales+OC-sales.VAT-Discount) as NetSales,COGS   from   (  Select ProductID, isnull((sum(crqty)- sum(drqty)),0)
                as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,   isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,
                isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0)
                as VAT   From   (   Select ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 
                0 as drGrossSales,   sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 
                0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT   from   (   Select a.InvoiceID,ProductID,Quantity,(Quantity*unitprice)
                as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   (Quantity*Costprice)as COGS,
                (Quantity*Tradeprice*vatamount)as VAT   from   (   select sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) 
                as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity   from t_salesinvoice sa,
                t_salesinvoicedetail sd   where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and invoicedate 
                between '{0}' and '{1}' and invoicedate < '{1}'  
                and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    )as a   left outer join   
                (   select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) 
                as AvgOC   from t_salesinvoice sa, t_salesinvoicedetail sd   where sa.invoiceid = sd.invoiceid  and 
                sa.WarehouseID={2} and invoicedate between '{0}' and '{1}' 
                and invoicedate < '{1}'   and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  
                group by sa.InvoiceID,Discount,OtherCharge   ) as b on a.invoiceid = b.invoiceid   ) as final 
                Group By ProductID   Union all   Select ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,
                sum(GrossSales) as drGrossSales,   0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,
                0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT   from   (   Select a.InvoiceID,ProductID,Quantity,
                (Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   (Quantity*Costprice)as 
                COGS,(Quantity*Tradeprice*vatamount)as VAT   from   (   select sa.InvoiceID,year(invoicedate) as TYear,
                month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity 
                from t_salesinvoice sa, t_salesinvoicedetail sd   where sa.invoiceid = sd.invoiceid  and sa.WarehouseID={2} 
                and invoicedate between '{0}' and '{1}' and invoicedate 
                < '{1}'   and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)    )as a  
                left outer join   (   select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull
                ((OtherCharge/sum(quantity)),0) as AvgOC   from t_salesinvoice sa, t_salesinvoicedetail sd  
                where sa.invoiceid = sd.invoiceid  and sa.WarehouseID={2} and invoicedate between '{0}'
                and '{1}' and invoicedate < '{1}'   and invoicetypeid in (6,7,9,10,12)
                and invoicestatus not in (3)    group by sa.InvoiceID,Discount,OtherCharge   ) as b on a.invoiceid = b.invoiceid  
                ) as final   Group By ProductID   )as FinalQuery   Group by   ProductID   ) as sales   inner join   
                (   Select ProductID, ASGID, ASGName, BrandID, BrandDesc from v_productdetails   ) as p on 
                sales.productid = p.productid   )
                as a   Group by ASGName,Brand Order by ASGName,Brand", dFromDate, dToDate,Utility.WarehouseID);



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();

                    _orptInvoiceRegister.ASGName = (string)reader["ASGName"];
                    _orptInvoiceRegister.BrandName = (string)reader["Brand"];
                    _orptInvoiceRegister.Qty = Convert.ToInt64(reader["SalesQty"]);
                    _orptInvoiceRegister.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPOSSaleASGNew(DateTime dFromDate, DateTime dToDate,int ReportKey)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sQueryString = "";
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer)
            {
                sQueryString = " and SalesType=" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer)
            {
                sQueryString = " and SalesType=" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                sQueryString = " and SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other)
            {
                sQueryString = " and SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
            }

            string sSql = "Select ASGName,Brand,sum(SalesQty) SalesQty,sum(GrossSales) GrossSales,  " +
                        "sum(Discount) Discount,sum(OC) OC,sum(VAT) VAT,sum(NetSales) NetSales,sum(COGS) COGS  " +
                        "From   " +
                        "(  " +
                        "Select ASGName,BrandDesc as Brand,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(Quantity),0)*-1 else isnull(sum(Quantity),0) end as SalesQty,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(UnitPrice*Quantity),0)*-1 else isnull(sum(UnitPrice*Quantity),0) end as GrossSales,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(b.Discounts),0)*-1 else isnull(sum(b.Discounts),0) end as Discount,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(b.Charges),0)*-1 else isnull(sum(b.Charges),0) end as OC,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(b.TradePrice*Quantity*b.VATAmount),0)*-1 else isnull(sum(b.TradePrice*Quantity*b.VATAmount),0) end as VAT,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum((UnitPrice*Quantity)+b.Charges-((b.TradePrice*Quantity*b.VATAmount)+b.Discounts)),0)*-1 else isnull(sum((UnitPrice*Quantity)+b.Charges-((b.TradePrice*Quantity*b.VATAmount)+b.Discounts)),0) end as NetSales,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(Quantity*b.CostPrice),0)*-1 else isnull(sum(Quantity*b.CostPrice),0) end as COGS  " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetailNew b,v_ProductDetails c,t_RetailConsumer d  " +
                        "where a.InvoiceID=b.InvoiceID and b.ProductID=c.ProductID and a.SundryCustomerID=d.ConsumerID  " +
                        "" + sQueryString + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "'  " +
                        "Group by ASGName,BrandDesc,InvoiceTypeID   " +
                        ") x where 1=1";

            sSql = sSql + " Group by ASGName,Brand Order by ASGName,Brand";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();

                    _orptInvoiceRegister.ASGName = (string)reader["ASGName"];
                    _orptInvoiceRegister.BrandName = (string)reader["Brand"];
                    _orptInvoiceRegister.Qty = Convert.ToInt64(reader["SalesQty"]);
                    _orptInvoiceRegister.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPOSSaleASGNewRT(DateTime dFromDate, DateTime dToDate, int ReportKey)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sQueryString = "";
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer)
            {
                sQueryString = " and SalesType=" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer)
            {
                sQueryString = " and SalesType=" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                sQueryString = " and SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other)
            {
                sQueryString = " and SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
            }

            string sSql = "Select ASGName,Brand,sum(SalesQty) SalesQty,sum(GrossSales) GrossSales,  " +
                        "sum(Discount) Discount,sum(OC) OC,sum(VAT) VAT,sum(NetSales) NetSales,sum(COGS) COGS  " +
                        "From   " +
                        "(  " +
                        "Select ASGName,BrandDesc as Brand,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(Quantity),0)*-1 else isnull(sum(Quantity),0) end as SalesQty,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(UnitPrice*Quantity),0)*-1 else isnull(sum(UnitPrice*Quantity),0) end as GrossSales,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(b.Discounts),0)*-1 else isnull(sum(b.Discounts),0) end as Discount,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(b.Charges),0)*-1 else isnull(sum(b.Charges),0) end as OC,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(b.TradePrice*Quantity*b.VATAmount),0)*-1 else isnull(sum(b.TradePrice*Quantity*b.VATAmount),0) end as VAT,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum((UnitPrice*Quantity)+b.Charges-((b.TradePrice*Quantity*b.VATAmount)+b.Discounts)),0)*-1 else isnull(sum((UnitPrice*Quantity)+b.Charges-((b.TradePrice*Quantity*b.VATAmount)+b.Discounts)),0) end as NetSales,  " +
                        "case when InvoiceTypeID in (6,7,8,9,10,11,12) then isnull(sum(Quantity*b.CostPrice),0)*-1 else isnull(sum(Quantity*b.CostPrice),0) end as COGS  " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetailNew b,v_ProductDetails c,t_RetailConsumer d  " +
                        "where a.WarehouseID=d.WarehouseID and a.WarehouseID="+Utility.WarehouseID+" and a.InvoiceID=b.InvoiceID and b.ProductID=c.ProductID and a.SundryCustomerID=d.ConsumerID  " +
                        "" + sQueryString + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "'  " +
                        "Group by ASGName,BrandDesc,InvoiceTypeID   " +
                        ") x where 1=1";

            sSql = sSql + " Group by ASGName,Brand Order by ASGName,Brand";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();

                    _orptInvoiceRegister.ASGName = (string)reader["ASGName"];
                    _orptInvoiceRegister.BrandName = (string)reader["Brand"];
                    _orptInvoiceRegister.Qty = Convert.ToInt64(reader["SalesQty"]);
                    _orptInvoiceRegister.NetAmount = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void RefreshPOSInvoiceRegisterNew(string sInvoiceNo, DateTime dFromDate, DateTime dToDate, string sSalesType)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            sSql = "Select * From  " +
                "(  " +
                //"----Old Invoice----  " +
                "Select a.InvoiceID, SalesType, InvoiceNo, InvoiceDate,  " +
                "ConsumerName, ConsumerCode, EmployeeCode, EmployeeName,  " +
                "InvoiceType, InvoiceTypeID, InvoiceStatus, InvoiceAmount,  " +
                "Case when InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1  " +
                "else Charges end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(TotalDiscount - SpecialDisc) * -1  " +
                "else (TotalDiscount - SpecialDisc) end as ProductDisc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1  " +
                "else SpecialDisc end as SpecialDisc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1  " +
                "else TotalDiscount end as TotalDiscount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1  " +
                "else VAT11 end as VAT11,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1  " +
                "else VAT11KA end as VAT11KA,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(VAT11 + VAT11KA) * -1  " +
                "else (VAT11 + VAT11KA) end as TotalVat,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then((GrossAmount + Charges) - (TotalDiscount + VAT11 + VAT11KA)) * -1  " +
                "else ((GrossAmount + Charges) - (TotalDiscount + VAT11 + VAT11KA)) end as NetSales  " +
                "From  " +
                "(  " +
                "Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B'  " +
                "when SalesType = 5 then 'Dealer' else 'Retail' end,  " +
                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,  " +
                "c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, a.InvoiceTypeID,  " +
                "InvoiceStatus, Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1  " +
                "else InvoiceAmount end as InvoiceAmount,Discount as TotalDiscount  " +
                "From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d  " +
                "where a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID  " +
                "and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)  " +
                "and InvoiceID not in (Select InvoiceID From t_SalesInvoiceDetailNew)   " +
                ") a,  " +
                "(  " +
                "Select  " +
                "InvoiceID, sum(GrossAmount)GrossAmount,sum(Charges) Charges,  " +
                "sum(SpecialDiscount) SpecialDisc,sum(VAT11) VAT11,sum(VAT11KA) VAT11KA  " +
                "from  " +
                "(  " +
                "Select InvoiceID, sum(UnitPrice * Quantity)  GrossAmount,  " +
                "0 Charges, 0 SpecialDiscount, 0 VAT11, 0 VAT11KA  " +
                "From t_SalesInvoiceDetail  group by InvoiceID  " +
                "Union All  " +
                "Select InvoiceID, sum(GrossPrice) GrossAmount, sum(Charges) Charges,  " +
                "sum(SpecialDiscount) SpecialDiscount, sum(VAT11KA) VAT11KA, sum(VAT11) VAT11 From  " +
                "(  " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "Sum(case SupplyType when 1 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  " +
                "Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11  " +
                "From t_SalesInvoiceDetail a, t_Product b  " +
                "where a.ProductID = b.ProductID and SupplyType = 1 group by InvoiceID  " +
                "Union All  " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "Sum(case SupplyType when 1 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  " +
                "Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11 From t_SalesInvoiceDetail a, t_Product b  " +
                "where a.ProductID = b.ProductID and SupplyType <> 1 group by InvoiceID  " +
                ") x where InvoiceID not in (Select InvoiceID from t_SalesInvoiceDetailNew)  " +
                "group by InvoiceID  " +
                "Union All  " +
                "select InvoiceID,0 as GrossAmount, (InstallationCharge + FreightCharge + OtherCharge) as Charge ,  " +
                "FaltAmount as SpecialDisc,0 VAT11,0 VAT11KA  " +
                "from t_SalesInvoiceOtherInfo Where SPParcentage = 0  " +
                "UNION ALL  " +
                "select a.InvoiceID, 0 as GrossAmount,  " +
                "(InstallationCharge + FreightCharge + OtherCharge) as Charge,  " +
                "(Amount * SPParcentage / 100) as SpecialDisc,  " +
                "0 VAT11,0 VAT11KA  " +
                "from t_SalesInvoiceOtherInfo a,  " +
                "(select InvoiceID, SUM(Quantity * UnitPrice) as Amount  " +
                "from t_SalesInvoiceDetail Group by InvoiceID)b  " +
                "Where a.InvoiceID = b.InvoiceID and SPParcentage <> 0  " +
                ") x group by InvoiceID  " +
                ") b  " +
                "where a.InvoiceID = b.InvoiceID  " +
                ///"----End Old Invoice----  " +
                "Union All  " +
                ///"----New Invoice  " +
                "Select a.*,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1    " +
                "else GrossAmount end as GrossAmount,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1    " +
                "else Charges end as Charges,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then ProductDisc*-1    " +
                "else ProductDisc end as ProductDisc,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1    " +
                "else SpecialDisc end as SpecialDisc,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1    " +
                "else TotalDiscount end as TotalDiscount,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1    " +
                "else VAT11 end as VAT11,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1    " +
                "else VAT11KA end as VAT11KA,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalVat*-1    " +
                "else TotalVat end as TotalVat,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1    " +
                "else NetSales end as NetSales    " +
                "From    " +
                "(    " +
                "Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B'    " +
                "when SalesType = 5 then 'Dealer' else 'Retail' end,    " +
                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,    " +
                "c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, a.InvoiceTypeID,    " +
                "InvoiceStatus, Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1    " +
                "else InvoiceAmount end as InvoiceAmount    " +
                "From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d    " +
                "where a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID    " +
                "and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)    " +
                ") a,    " +
                "(    " +
                "Select InvoiceID, sum(GrossPrice)GrossAmount,    " +
                "sum(Charges) Charges,isnull(sum(Discounts) - sum(SpecialDiscount), 0) as ProductDisc,    " +
                "sum(SpecialDiscount) SpecialDisc,sum(Discounts) TotalDiscount,    " +
                "sum(VAT11) VAT11,sum(VAT11KA) VAT11KA,isnull(sum(VAT11) + sum(VAT11KA), 0) as TotalVat,    " +
                "isnull((sum(GrossPrice) + sum(Charges)), 0) - (sum(Discounts) + isnull(sum(VAT11) + sum(VAT11KA), 0)) as NetSales    " +
                "From    " +
                "(    " +
                "Select InvoiceID,    " +
                "UnitPrice * Quantity as GrossPrice,    " +
                "Charges, 0 SpecialDiscount, Discounts, 0 VAT11, 0 VAT11KA    " +
                "From t_SalesInvoiceDetailNew a    " +
                "Union All    " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges,    " +
                "sum(Amount) SpecialDiscount, 0 Discounts, 0 VAT11, 0 VAT11KA    " +
                "From t_SalesInvoiceDiscount    " +
                "where DiscountTypeID = 7 group by InvoiceID    " +
                "Union All   " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "isnull(sum(Quantity * Tradeprice * vatamount),0)   as VAT11KA,  0 VAT11  " +
                "From t_SalesInvoiceDetailNew group by InvoiceID    " +
                ") InvDetail group by InvoiceID    " +
                ") b where a.InvoiceID = b.InvoiceID  " +
                ///"----End New Invoice  " +
                ") Main where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate< '" + dToDate + "'";


                if (sInvoiceNo.Trim() != "")
                {
                    sSql = sSql + " and InvoiceNo='" + sInvoiceNo + "'";
                }
                if (sSalesType.Trim() != "<All>")
                {
                    sSql = sSql + " and SalesType='" + sSalesType + "'";
                }

                sSql = sSql + " order by InvoiceNo";
            
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();
                    _orptInvoiceRegister.SalesType = reader["SalesType"].ToString();
                    _orptInvoiceRegister.InvoiceNo = reader["InvoiceNo"].ToString();
                    _orptInvoiceRegister.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _orptInvoiceRegister.CustomerCode = (string)reader["ConsumerCode"];
                    _orptInvoiceRegister.CustomerName = (string)reader["ConsumerName"];
                    _orptInvoiceRegister.EmployeeCode = (string)reader["EmployeeCode"];
                    _orptInvoiceRegister.EmployeeName = (string)reader["EmployeeName"];
                    _orptInvoiceRegister.InvoiceTypeName = reader["InvoiceType"].ToString();
                    _orptInvoiceRegister.InvoiceStatusName = Enum.GetName(typeof(Dictionary.InvoiceStatus), Convert.ToInt32(reader["InvoiceStatus"].ToString()));
                    _orptInvoiceRegister.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _orptInvoiceRegister.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _orptInvoiceRegister.Charge = Convert.ToDouble(reader["Charges"].ToString());
                    _orptInvoiceRegister.ProductDisc = Convert.ToDouble(reader["ProductDisc"].ToString());
                    _orptInvoiceRegister.SpecialDisc = Convert.ToDouble(reader["SpecialDisc"].ToString());
                    _orptInvoiceRegister.Discount = Convert.ToDouble(reader["TotalDiscount"].ToString());
                    _orptInvoiceRegister.VAT11 = Convert.ToDouble(reader["VAT11"].ToString());
                    _orptInvoiceRegister.VAT11KA = Convert.ToDouble(reader["VAT11KA"].ToString());
                    _orptInvoiceRegister.TotalVat = Convert.ToDouble(reader["TotalVat"].ToString());
                    _orptInvoiceRegister.NetSales = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshPOSInvoiceRegisterNewRT(string sInvoiceNo, DateTime dFromDate, DateTime dToDate, string sSalesType)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            sSql = @"
                    Select * From  (  Select a.InvoiceID, SalesType, InvoiceNo, InvoiceDate,  
                ConsumerName, ConsumerCode, EmployeeCode, EmployeeName,  InvoiceType, 
                InvoiceTypeID, InvoiceStatus, InvoiceAmount,  Case when InvoiceTypeID 
                in (6, 7, 8, 9, 10, 11, 12) then GrossAmount*-1  else GrossAmount end 
                as GrossAmount,  Case when InvoiceTypeID in (6,7,8,9,10,11,12) then 
                Charges*-1  else Charges end as Charges,  Case when InvoiceTypeID in 
                (6,7,8,9,10,11,12) then(TotalDiscount - SpecialDisc) * -1  else 
                (TotalDiscount - SpecialDisc) end as ProductDisc,  Case when InvoiceTypeID
                in (6,7,8,9,10,11,12) then SpecialDisc*-1  else SpecialDisc end as SpecialDisc,
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1  else
                TotalDiscount end as TotalDiscount,  Case when InvoiceTypeID in (6,7,8,9,10,11,12)
	            then VAT11*-1  else VAT11 end as VAT11,  Case when InvoiceTypeID in 
                (6,7,8,9,10,11,12) then VAT11KA*-1  else VAT11KA end as VAT11KA, 
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(VAT11 + VAT11KA) * -1 
                else (VAT11 + VAT11KA) end as TotalVat,  Case when InvoiceTypeID in
                (6,7,8,9,10,11,12) then((GrossAmount + Charges) - 
                (TotalDiscount + VAT11 + VAT11KA)) * -1  else ((GrossAmount + Charges) 
                - (TotalDiscount + VAT11 + VAT11KA)) end as NetSales  From 
                (  Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B' 
                when SalesType = 5 then 'Dealer' else 'Retail' end,  InvoiceNo, 
                InvoiceDate, ConsumerName, ConsumerCode,  c.EmployeeCode, EmployeeName,
                InvoiceTypeName as InvoiceType, a.InvoiceTypeID,  InvoiceStatus, 
                Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1  
                else InvoiceAmount end as InvoiceAmount,Discount as TotalDiscount  
                From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d 
                where a.WarehouseID=b.WarehouseID and a.WarehouseID="+Utility.WarehouseID+ @" and a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID
                and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)
                and InvoiceID not in (Select InvoiceID From t_SalesInvoiceDetailNew)  
                ) a,  (  Select  InvoiceID, sum(GrossAmount)GrossAmount,sum(Charges)
                Charges,  sum(SpecialDiscount) SpecialDisc,sum(VAT11) VAT11,
                sum(VAT11KA) VAT11KA  from  (  Select InvoiceID, sum(UnitPrice * Quantity) 
                GrossAmount,  0 Charges, 0 SpecialDiscount, 0 VAT11, 0 VAT11KA 
                From t_SalesInvoiceDetail  group by InvoiceID  Union All 
                Select InvoiceID, sum(GrossPrice) GrossAmount, sum(Charges) Charges,
                sum(SpecialDiscount) SpecialDiscount, sum(VAT11KA) VAT11KA,
                sum(VAT11) VAT11 From  (  Select InvoiceID, 0 GrossPrice,
                0 Charges, 0 SpecialDiscount, 0 Discounts, 
                Sum(case SupplyType when 1 then 
                Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  
                Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount
                else 0 end) as VAT11  From t_SalesInvoiceDetail a, t_Product b
                where a.ProductID = b.ProductID and SupplyType = 1 group by 
                InvoiceID  Union All  Select InvoiceID, 0 GrossPrice, 0 Charges,
                0 SpecialDiscount, 0 Discounts,  Sum(case SupplyType when 1 then 
                Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA, 
                Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end)
                as VAT11 From t_SalesInvoiceDetail a, t_Product b  where a.ProductID = b.ProductID
                and SupplyType <> 1 group by InvoiceID  ) x where InvoiceID not in
                (Select InvoiceID from t_SalesInvoiceDetailNew)  group by InvoiceID 
                Union All  select InvoiceID,0 as GrossAmount,
                (InstallationCharge + FreightCharge + OtherCharge) as Charge , 
                FaltAmount as SpecialDisc,0 VAT11,0 VAT11KA  from t_SalesInvoiceOtherInfo
                Where SPParcentage = 0  UNION ALL  select a.InvoiceID, 0 as GrossAmount, 
                (InstallationCharge + FreightCharge + OtherCharge) as Charge,
                (Amount * SPParcentage / 100) as SpecialDisc,  0 VAT11,0 VAT11KA
                from t_SalesInvoiceOtherInfo a,  (select InvoiceID, 
                SUM(Quantity * UnitPrice) as Amount  from t_SalesInvoiceDetail Group by InvoiceID)b
                Where a.InvoiceID = b.InvoiceID and SPParcentage <> 0  ) x group by InvoiceID  ) b
                where a.InvoiceID = b.InvoiceID  Union All  Select a.*,  
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1 
                else GrossAmount end as GrossAmount, 
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1 
                else Charges end as Charges,  
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then ProductDisc*-1  
                else ProductDisc end as ProductDisc,  
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1   
                 else SpecialDisc end as SpecialDisc,    Case when InvoiceTypeID in 
                (6,7,8,9,10,11,12) then TotalDiscount*-1    else TotalDiscount end as TotalDiscount, 
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1    else VAT11 end as VAT11, 
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1 
                else VAT11KA end as VAT11KA,    Case when InvoiceTypeID in (6,7,8,9,10,11,12) 
                then TotalVat*-1    else TotalVat end as TotalVat,   
                Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1 
                else NetSales end as NetSales    From    
                (    Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B' 
                when SalesType = 5 then 'Dealer' else 'Retail' end,  
                InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,   
                c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, 
                a.InvoiceTypeID,    InvoiceStatus, Case when a.InvoiceTypeID in 
                (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1    else InvoiceAmount
                end as InvoiceAmount    From t_SalesInvoice a,t_RetailConsumer B,
                t_Employee c,t_InvoiceType d    where a.WarehouseID=b.WarehouseID and a.WarehouseID=" + Utility.WarehouseID + @" and a.SundryCustomerID = b.ConsumerID 
                and a.SalesPersonID = c.EmployeeID    and a.InvoiceTypeID = d.InvoiceTypeID 
                and InvoiceStatus not in (3)    ) a,    (    Select InvoiceID, 
                sum(GrossPrice)GrossAmount,    sum(Charges) Charges,isnull(sum(Discounts) - 
                sum(SpecialDiscount), 0) as ProductDisc,    sum(SpecialDiscount) SpecialDisc,
                sum(Discounts) TotalDiscount,    sum(VAT11) VAT11,sum(VAT11KA) VAT11KA,isnull(sum(VAT11) 
                + sum(VAT11KA), 0) as TotalVat,    isnull((sum(GrossPrice) + sum(Charges)), 0) - (sum(Discounts) 
                + isnull(sum(VAT11) + sum(VAT11KA), 0)) as NetSales    From    (    Select InvoiceID,
                UnitPrice * Quantity as GrossPrice,    Charges, 0 SpecialDiscount, Discounts, 
                0 VAT11, 0 VAT11KA    From t_SalesInvoiceDetailNew a    Union All    
                Select InvoiceID, 0 GrossPrice, 0 Charges,    sum(Amount) SpecialDiscount, 
                0 Discounts, 0 VAT11, 0 VAT11KA    From t_SalesInvoiceDiscount   
                where DiscountTypeID = 7 group by InvoiceID    Union All  
                Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,
                isnull(sum(Quantity * Tradeprice * vatamount),0)   as VAT11KA,  0 VAT11  
                From t_SalesInvoiceDetailNew group by InvoiceID    ) InvDetail group by InvoiceID 
                ) b where a.InvoiceID = b.InvoiceID  ) Main where InvoiceDate 
                between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate< '" + dToDate + "'";


            if (sInvoiceNo.Trim() != "")
            {
                sSql = sSql + " and InvoiceNo='" + sInvoiceNo + "'";
            }
            if (sSalesType.Trim() != "<All>")
            {
                sSql = sSql + " and SalesType='" + sSalesType + "'";
            }

            sSql = sSql + " order by InvoiceNo";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();
                    _orptInvoiceRegister.SalesType = reader["SalesType"].ToString();
                    _orptInvoiceRegister.InvoiceNo = reader["InvoiceNo"].ToString();
                    _orptInvoiceRegister.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _orptInvoiceRegister.CustomerCode = (string)reader["ConsumerCode"];
                    _orptInvoiceRegister.CustomerName = (string)reader["ConsumerName"];
                    _orptInvoiceRegister.EmployeeCode = (string)reader["EmployeeCode"];
                    _orptInvoiceRegister.EmployeeName = (string)reader["EmployeeName"];
                    _orptInvoiceRegister.InvoiceTypeName = reader["InvoiceType"].ToString();
                    _orptInvoiceRegister.InvoiceStatusName = Enum.GetName(typeof(Dictionary.InvoiceStatus), Convert.ToInt32(reader["InvoiceStatus"].ToString()));
                    _orptInvoiceRegister.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _orptInvoiceRegister.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _orptInvoiceRegister.Charge = Convert.ToDouble(reader["Charges"].ToString());
                    _orptInvoiceRegister.ProductDisc = Convert.ToDouble(reader["ProductDisc"].ToString());
                    _orptInvoiceRegister.SpecialDisc = Convert.ToDouble(reader["SpecialDisc"].ToString());
                    _orptInvoiceRegister.Discount = Convert.ToDouble(reader["TotalDiscount"].ToString());
                    _orptInvoiceRegister.VAT11 = Convert.ToDouble(reader["VAT11"].ToString());
                    _orptInvoiceRegister.VAT11KA = Convert.ToDouble(reader["VAT11KA"].ToString());
                    _orptInvoiceRegister.TotalVat = Convert.ToDouble(reader["TotalVat"].ToString());
                    _orptInvoiceRegister.NetSales = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshPOSInvoiceRegisterFilter(string sInvoiceNo, DateTime dFromDate, DateTime dToDate, string sSalesType,int ReportKey)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            sSql = "Select * From  " +
                "(  " +
                //"----Old Invoice----  " +
                "Select a.InvoiceID, SalesType, InvoiceNo, InvoiceDate,  " +
                "ConsumerName, ConsumerCode, EmployeeCode, EmployeeName,  " +
                "InvoiceType, InvoiceTypeID, InvoiceStatus, InvoiceAmount,  " +
                "Case when InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1  " +
                "else Charges end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(TotalDiscount - SpecialDisc) * -1  " +
                "else (TotalDiscount - SpecialDisc) end as ProductDisc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1  " +
                "else SpecialDisc end as SpecialDisc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1  " +
                "else TotalDiscount end as TotalDiscount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1  " +
                "else VAT11 end as VAT11,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1  " +
                "else VAT11KA end as VAT11KA,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(VAT11 + VAT11KA) * -1  " +
                "else (VAT11 + VAT11KA) end as TotalVat,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then((GrossAmount + Charges) - (TotalDiscount + VAT11 + VAT11KA)) * -1  " +
                "else ((GrossAmount + Charges) - (TotalDiscount + VAT11 + VAT11KA)) end as NetSales  " +
                "From  " +
                "(  " +
                "Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B'  " +
                "when SalesType = 5 then 'Dealer' else 'Retail' end,  " +
                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,  " +
                "c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, a.InvoiceTypeID,  " +
                "InvoiceStatus, Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1  " +
                "else InvoiceAmount end as InvoiceAmount,Discount as TotalDiscount  " +
                "From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d  " +
                "where a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID  " +
                "and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)  " +
                "and InvoiceID not in (Select InvoiceID From t_SalesInvoiceDetailNew)   " +
                ") a,  " +
                "(  " +
                "Select  " +
                "InvoiceID, sum(GrossAmount)GrossAmount,sum(Charges) Charges,  " +
                "sum(SpecialDiscount) SpecialDisc,sum(VAT11) VAT11,sum(VAT11KA) VAT11KA  " +
                "from  " +
                "(  " +
                "Select InvoiceID, sum(UnitPrice * Quantity)  GrossAmount,  " +
                "0 Charges, 0 SpecialDiscount, 0 VAT11, 0 VAT11KA  " +
                "From t_SalesInvoiceDetail  group by InvoiceID  " +
                "Union All  " +
                "Select InvoiceID, sum(GrossPrice) GrossAmount, sum(Charges) Charges,  " +
                "sum(SpecialDiscount) SpecialDiscount, sum(VAT11KA) VAT11KA, sum(VAT11) VAT11 From  " +
                "(  " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "Sum(case SupplyType when 1 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  " +
                "Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11  " +
                "From t_SalesInvoiceDetail a, t_Product b  " +
                "where a.ProductID = b.ProductID and SupplyType = 1 group by InvoiceID  " +
                "Union All  " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "Sum(case SupplyType when 1 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  " +
                "Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11 From t_SalesInvoiceDetail a, t_Product b  " +
                "where a.ProductID = b.ProductID and SupplyType <> 1 group by InvoiceID  " +
                ") x where InvoiceID not in (Select InvoiceID from t_SalesInvoiceDetailNew)  " +
                "group by InvoiceID  " +
                "Union All  " +
                "select InvoiceID,0 as GrossAmount, (InstallationCharge + FreightCharge + OtherCharge) as Charge ,  " +
                "FaltAmount as SpecialDisc,0 VAT11,0 VAT11KA  " +
                "from t_SalesInvoiceOtherInfo Where SPParcentage = 0  " +
                "UNION ALL  " +
                "select a.InvoiceID, 0 as GrossAmount,  " +
                "(InstallationCharge + FreightCharge + OtherCharge) as Charge,  " +
                "(Amount * SPParcentage / 100) as SpecialDisc,  " +
                "0 VAT11,0 VAT11KA  " +
                "from t_SalesInvoiceOtherInfo a,  " +
                "(select InvoiceID, SUM(Quantity * UnitPrice) as Amount  " +
                "from t_SalesInvoiceDetail Group by InvoiceID)b  " +
                "Where a.InvoiceID = b.InvoiceID and SPParcentage <> 0  " +
                ") x group by InvoiceID  " +
                ") b  " +
                "where a.InvoiceID = b.InvoiceID  " +
                ///"----End Old Invoice----  " +
                "Union All  " +
                ///"----New Invoice  " +
                "Select a.*,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1    " +
                "else GrossAmount end as GrossAmount,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1    " +
                "else Charges end as Charges,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then ProductDisc*-1    " +
                "else ProductDisc end as ProductDisc,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1    " +
                "else SpecialDisc end as SpecialDisc,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1    " +
                "else TotalDiscount end as TotalDiscount,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1    " +
                "else VAT11 end as VAT11,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1    " +
                "else VAT11KA end as VAT11KA,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalVat*-1    " +
                "else TotalVat end as TotalVat,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1    " +
                "else NetSales end as NetSales    " +
                "From    " +
                "(    " +
                "Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B'    " +
                "when SalesType = 5 then 'Dealer' else 'Retail' end,    " +
                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,    " +
                "c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, a.InvoiceTypeID,    " +
                "InvoiceStatus, Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1    " +
                "else InvoiceAmount end as InvoiceAmount    " +
                "From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d    " +
                "where a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID    " +
                "and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)    " +
                ") a,    " +
                "(    " +
                "Select InvoiceID, sum(GrossPrice)GrossAmount,    " +
                "sum(Charges) Charges,isnull(sum(Discounts) - sum(SpecialDiscount), 0) as ProductDisc,    " +
                "sum(SpecialDiscount) SpecialDisc,sum(Discounts) TotalDiscount,    " +
                "sum(VAT11) VAT11,sum(VAT11KA) VAT11KA,isnull(sum(VAT11) + sum(VAT11KA), 0) as TotalVat,    " +
                "isnull((sum(GrossPrice) + sum(Charges)), 0) - (sum(Discounts) + isnull(sum(VAT11) + sum(VAT11KA), 0)) as NetSales    " +
                "From    " +
                "(    " +
                "Select InvoiceID,    " +
                "UnitPrice * Quantity as GrossPrice,    " +
                "Charges, 0 SpecialDiscount, Discounts, 0 VAT11, 0 VAT11KA    " +
                "From t_SalesInvoiceDetailNew a    " +
                "Union All    " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges,    " +
                "sum(Amount) SpecialDiscount, 0 Discounts, 0 VAT11, 0 VAT11KA    " +
                "From t_SalesInvoiceDiscount    " +
                "where DiscountTypeID = 7 group by InvoiceID    " +
                "Union All   " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "isnull(sum(Quantity * Tradeprice * vatamount),0)   as VAT11KA,  0 VAT11  " +
                "From t_SalesInvoiceDetailNew group by InvoiceID    " +
                ") InvDetail group by InvoiceID    " +
                ") b where a.InvoiceID = b.InvoiceID  " +
                ///"----End New Invoice  " +
                ") Main where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate< '" + dToDate + "'";

            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer)
            {
                sSql = sSql + " and SalesType='Dealer'";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer)
            {
                sSql = sSql + " and SalesType='Dealer'";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                sSql = sSql + " and SalesType<>'Dealer'";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other)
            {
                sSql = sSql + " and SalesType<>'Dealer'";
            }

            if (sInvoiceNo.Trim() != "")
            {
                sSql = sSql + " and InvoiceNo='" + sInvoiceNo + "'";
            }
            if (sSalesType.Trim() != "<All>")
            {
                sSql = sSql + " and SalesType='" + sSalesType + "'";
            }

            sSql = sSql + " order by InvoiceNo";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();
                    _orptInvoiceRegister.SalesType = reader["SalesType"].ToString();
                    _orptInvoiceRegister.InvoiceNo = reader["InvoiceNo"].ToString();
                    _orptInvoiceRegister.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _orptInvoiceRegister.CustomerCode = (string)reader["ConsumerCode"];
                    _orptInvoiceRegister.CustomerName = (string)reader["ConsumerName"];
                    _orptInvoiceRegister.EmployeeCode = (string)reader["EmployeeCode"];
                    _orptInvoiceRegister.EmployeeName = (string)reader["EmployeeName"];
                    _orptInvoiceRegister.InvoiceTypeName = reader["InvoiceType"].ToString();
                    _orptInvoiceRegister.InvoiceStatusName = Enum.GetName(typeof(Dictionary.InvoiceStatus), Convert.ToInt32(reader["InvoiceStatus"].ToString()));
                    _orptInvoiceRegister.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _orptInvoiceRegister.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _orptInvoiceRegister.Charge = Convert.ToDouble(reader["Charges"].ToString());
                    _orptInvoiceRegister.ProductDisc = Convert.ToDouble(reader["ProductDisc"].ToString());
                    _orptInvoiceRegister.SpecialDisc = Convert.ToDouble(reader["SpecialDisc"].ToString());
                    _orptInvoiceRegister.Discount = Convert.ToDouble(reader["TotalDiscount"].ToString());
                    _orptInvoiceRegister.VAT11 = Convert.ToDouble(reader["VAT11"].ToString());
                    _orptInvoiceRegister.VAT11KA = Convert.ToDouble(reader["VAT11KA"].ToString());
                    _orptInvoiceRegister.TotalVat = Convert.ToDouble(reader["TotalVat"].ToString());
                    _orptInvoiceRegister.NetSales = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPOSInvoiceRegisterFilterRT(string sInvoiceNo, DateTime dFromDate, DateTime dToDate, string sSalesType, int ReportKey)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            sSql = "Select * From  " +
                "(  " +
                //"----Old Invoice----  " +
                "Select a.InvoiceID, SalesType, InvoiceNo, InvoiceDate,  " +
                "ConsumerName, ConsumerCode, EmployeeCode, EmployeeName,  " +
                "InvoiceType, InvoiceTypeID, InvoiceStatus, InvoiceAmount,  " +
                "Case when InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then GrossAmount*-1  " +
                "else GrossAmount end as GrossAmount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1  " +
                "else Charges end as Charges,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(TotalDiscount - SpecialDisc) * -1  " +
                "else (TotalDiscount - SpecialDisc) end as ProductDisc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1  " +
                "else SpecialDisc end as SpecialDisc,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1  " +
                "else TotalDiscount end as TotalDiscount,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1  " +
                "else VAT11 end as VAT11,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1  " +
                "else VAT11KA end as VAT11KA,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then(VAT11 + VAT11KA) * -1  " +
                "else (VAT11 + VAT11KA) end as TotalVat,  " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then((GrossAmount + Charges) - (TotalDiscount + VAT11 + VAT11KA)) * -1  " +
                "else ((GrossAmount + Charges) - (TotalDiscount + VAT11 + VAT11KA)) end as NetSales  " +
                "From  " +
                "(  " +
                "Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B'  " +
                "when SalesType = 5 then 'Dealer' else 'Retail' end,  " +
                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,  " +
                "c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, a.InvoiceTypeID,  " +
                "InvoiceStatus, Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1  " +
                "else InvoiceAmount end as InvoiceAmount,Discount as TotalDiscount  " +
                "From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d  " +
                "where a.WarehouseID=b.WarehouseID and a.WarehouseID="+Utility.WarehouseID+" and a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID  " +
                "and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)  " +
                "and InvoiceID not in (Select InvoiceID From t_SalesInvoiceDetailNew)   " +
                ") a,  " +
                "(  " +
                "Select  " +
                "InvoiceID, sum(GrossAmount)GrossAmount,sum(Charges) Charges,  " +
                "sum(SpecialDiscount) SpecialDisc,sum(VAT11) VAT11,sum(VAT11KA) VAT11KA  " +
                "from  " +
                "(  " +
                "Select InvoiceID, sum(UnitPrice * Quantity)  GrossAmount,  " +
                "0 Charges, 0 SpecialDiscount, 0 VAT11, 0 VAT11KA  " +
                "From t_SalesInvoiceDetail  group by InvoiceID  " +
                "Union All  " +
                "Select InvoiceID, sum(GrossPrice) GrossAmount, sum(Charges) Charges,  " +
                "sum(SpecialDiscount) SpecialDiscount, sum(VAT11KA) VAT11KA, sum(VAT11) VAT11 From  " +
                "(  " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "Sum(case SupplyType when 1 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  " +
                "Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11  " +
                "From t_SalesInvoiceDetail a, t_Product b  " +
                "where a.ProductID = b.ProductID and SupplyType = 1 group by InvoiceID  " +
                "Union All  " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "Sum(case SupplyType when 1 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11KA,  " +
                "Sum(case SupplyType when 2 then Quantity * Tradeprice * vatamount  else 0 end) as VAT11 From t_SalesInvoiceDetail a, t_Product b  " +
                "where a.ProductID = b.ProductID and SupplyType <> 1 group by InvoiceID  " +
                ") x where InvoiceID not in (Select InvoiceID from t_SalesInvoiceDetailNew)  " +
                "group by InvoiceID  " +
                "Union All  " +
                "select InvoiceID,0 as GrossAmount, (InstallationCharge + FreightCharge + OtherCharge) as Charge ,  " +
                "FaltAmount as SpecialDisc,0 VAT11,0 VAT11KA  " +
                "from t_SalesInvoiceOtherInfo Where SPParcentage = 0  " +
                "UNION ALL  " +
                "select a.InvoiceID, 0 as GrossAmount,  " +
                "(InstallationCharge + FreightCharge + OtherCharge) as Charge,  " +
                "(Amount * SPParcentage / 100) as SpecialDisc,  " +
                "0 VAT11,0 VAT11KA  " +
                "from t_SalesInvoiceOtherInfo a,  " +
                "(select InvoiceID, SUM(Quantity * UnitPrice) as Amount  " +
                "from t_SalesInvoiceDetail Group by InvoiceID)b  " +
                "Where a.InvoiceID = b.InvoiceID and SPParcentage <> 0  " +
                ") x group by InvoiceID  " +
                ") b  " +
                "where a.InvoiceID = b.InvoiceID  " +
                ///"----End Old Invoice----  " +
                "Union All  " +
                ///"----New Invoice  " +
                "Select a.*,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then GrossAmount*-1    " +
                "else GrossAmount end as GrossAmount,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then Charges*-1    " +
                "else Charges end as Charges,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then ProductDisc*-1    " +
                "else ProductDisc end as ProductDisc,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then SpecialDisc*-1    " +
                "else SpecialDisc end as SpecialDisc,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalDiscount*-1    " +
                "else TotalDiscount end as TotalDiscount,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11*-1    " +
                "else VAT11 end as VAT11,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then VAT11KA*-1    " +
                "else VAT11KA end as VAT11KA,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then TotalVat*-1    " +
                "else TotalVat end as TotalVat,    " +
                "Case when InvoiceTypeID in (6,7,8,9,10,11,12) then NetSales*-1    " +
                "else NetSales end as NetSales    " +
                "From    " +
                "(    " +
                "Select InvoiceID, SalesType =case when SalesType = 3 then 'B2B'    " +
                "when SalesType = 5 then 'Dealer' else 'Retail' end,    " +
                "InvoiceNo, InvoiceDate, ConsumerName, ConsumerCode,    " +
                "c.EmployeeCode, EmployeeName, InvoiceTypeName as InvoiceType, a.InvoiceTypeID,    " +
                "InvoiceStatus, Case when a.InvoiceTypeID in (6, 7, 8, 9, 10, 11, 12) then InvoiceAmount*-1    " +
                "else InvoiceAmount end as InvoiceAmount    " +
                "From t_SalesInvoice a,t_RetailConsumer B, t_Employee c,t_InvoiceType d    " +
                "where a.WarehouseID=b.WarehouseID and a.WarehouseID="+Utility.WarehouseID+" and a.SundryCustomerID = b.ConsumerID and a.SalesPersonID = c.EmployeeID    " +
                "and a.InvoiceTypeID = d.InvoiceTypeID and InvoiceStatus not in (3)    " +
                ") a,    " +
                "(    " +
                "Select InvoiceID, sum(GrossPrice)GrossAmount,    " +
                "sum(Charges) Charges,isnull(sum(Discounts) - sum(SpecialDiscount), 0) as ProductDisc,    " +
                "sum(SpecialDiscount) SpecialDisc,sum(Discounts) TotalDiscount,    " +
                "sum(VAT11) VAT11,sum(VAT11KA) VAT11KA,isnull(sum(VAT11) + sum(VAT11KA), 0) as TotalVat,    " +
                "isnull((sum(GrossPrice) + sum(Charges)), 0) - (sum(Discounts) + isnull(sum(VAT11) + sum(VAT11KA), 0)) as NetSales    " +
                "From    " +
                "(    " +
                "Select InvoiceID,    " +
                "UnitPrice * Quantity as GrossPrice,    " +
                "Charges, 0 SpecialDiscount, Discounts, 0 VAT11, 0 VAT11KA    " +
                "From t_SalesInvoiceDetailNew a    " +
                "Union All    " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges,    " +
                "sum(Amount) SpecialDiscount, 0 Discounts, 0 VAT11, 0 VAT11KA    " +
                "From t_SalesInvoiceDiscount    " +
                "where DiscountTypeID = 7 group by InvoiceID    " +
                "Union All   " +
                "Select InvoiceID, 0 GrossPrice, 0 Charges, 0 SpecialDiscount, 0 Discounts,  " +
                "isnull(sum(Quantity * Tradeprice * vatamount),0)   as VAT11KA,  0 VAT11  " +
                "From t_SalesInvoiceDetailNew group by InvoiceID    " +
                ") InvDetail group by InvoiceID    " +
                ") b where a.InvoiceID = b.InvoiceID  " +
                ///"----End New Invoice  " +
                ") Main where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate< '" + dToDate + "'";

            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer)
            {
                sSql = sSql + " and SalesType='Dealer'";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer)
            {
                sSql = sSql + " and SalesType='Dealer'";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                sSql = sSql + " and SalesType<>'Dealer'";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other)
            {
                sSql = sSql + " and SalesType<>'Dealer'";
            }

            if (sInvoiceNo.Trim() != "")
            {
                sSql = sSql + " and InvoiceNo='" + sInvoiceNo + "'";
            }
            if (sSalesType.Trim() != "<All>")
            {
                sSql = sSql + " and SalesType='" + sSalesType + "'";
            }

            sSql = sSql + " order by InvoiceNo";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptInvoiceRegister _orptInvoiceRegister = new rptInvoiceRegister();
                    _orptInvoiceRegister.SalesType = reader["SalesType"].ToString();
                    _orptInvoiceRegister.InvoiceNo = reader["InvoiceNo"].ToString();
                    _orptInvoiceRegister.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _orptInvoiceRegister.CustomerCode = (string)reader["ConsumerCode"];
                    _orptInvoiceRegister.CustomerName = (string)reader["ConsumerName"];
                    _orptInvoiceRegister.EmployeeCode = (string)reader["EmployeeCode"];
                    _orptInvoiceRegister.EmployeeName = (string)reader["EmployeeName"];
                    _orptInvoiceRegister.InvoiceTypeName = reader["InvoiceType"].ToString();
                    _orptInvoiceRegister.InvoiceStatusName = Enum.GetName(typeof(Dictionary.InvoiceStatus), Convert.ToInt32(reader["InvoiceStatus"].ToString()));
                    _orptInvoiceRegister.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _orptInvoiceRegister.GrossAmount = Convert.ToDouble(reader["GrossAmount"].ToString());
                    _orptInvoiceRegister.Charge = Convert.ToDouble(reader["Charges"].ToString());
                    _orptInvoiceRegister.ProductDisc = Convert.ToDouble(reader["ProductDisc"].ToString());
                    _orptInvoiceRegister.SpecialDisc = Convert.ToDouble(reader["SpecialDisc"].ToString());
                    _orptInvoiceRegister.Discount = Convert.ToDouble(reader["TotalDiscount"].ToString());
                    _orptInvoiceRegister.VAT11 = Convert.ToDouble(reader["VAT11"].ToString());
                    _orptInvoiceRegister.VAT11KA = Convert.ToDouble(reader["VAT11KA"].ToString());
                    _orptInvoiceRegister.TotalVat = Convert.ToDouble(reader["TotalVat"].ToString());
                    _orptInvoiceRegister.NetSales = Convert.ToDouble(reader["NetSales"].ToString());

                    InnerList.Add(_orptInvoiceRegister);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


    }
}
