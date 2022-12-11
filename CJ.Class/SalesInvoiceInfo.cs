// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Agu 01, 2012
// Time :  10:00 AM
// Description: Class for Sales Invoice.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;


namespace CJ.Class
{
    public class SalesInvoiceInfo
    {
        private long _InvoiceID;
        private string _sInvoiceNo;
        private object _InvoiceDate;
        private int _nInvoiceStatus;
        private int _nCustomerID;
        private int _nWarehouseID;
        private double _InvoiceAmount;
        private string _sRemarks;
        private int _nOrderID;
        private string _sInvoiceByName;
        private string _sDeliveredByName;  
        private string _sOrderNo;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nInvoiceTypeID;
        private int _nRefInvoiceID;

        private SalesInvoice _oSalesInvoice;

        public SalesInvoice SalesInvoice
        {
            get
            {
                if (_oSalesInvoice == null)
                {
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.RefreshByInvoiceID(_InvoiceID);
                }
                return _oSalesInvoice;
            }
        }



        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public object InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        private string _sSalesPersonName;
        public string SalesPersonName
        {
            get { return _sSalesPersonName; }
            set { _sSalesPersonName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InvoiceStatus
        /// </summary>
        public int InvoiceStatus
        {
            get { return _nInvoiceStatus; }
            set { _nInvoiceStatus = value; }
        }
        private int _nSundryCustomerID;
        public int SundryCustomerID
        {
            get { return _nSundryCustomerID; }
            set { _nSundryCustomerID = value; }
        }
        public int InvoiceTypeID
        {
            get { return _nInvoiceTypeID; }
            set { _nInvoiceTypeID = value; }
        }

        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceAmount
        /// </summary>
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        /// <summary>
        /// Get set property for InvoiceBy
        /// </summary>
        public string InvoiceByName
        {
            get { return _sInvoiceByName; }
            set { _sInvoiceByName = value; }
        }
        /// <summary>
        /// Get set property for DeliveredBy
        /// </summary>
        public string DeliveredByName
        {
            get { return _sDeliveredByName; }
            set { _sDeliveredByName = value; }
        }
      
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }
        public int RefInvoiceID
        {
            get { return _nRefInvoiceID; }
            set { _nRefInvoiceID = value; }
        }

        public void GetRefInvoiceID(int nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select a.RefInvoiceID,b.InvoiceNo as RefInvoiceNo From t_SalesInvoice a  " +
                "Left Outer Join  " +
                "t_SalesInvoice b  " +
                "on a.RefInvoiceID = b.InvoiceID  " +
                "where a.InvoiceID = " + nInvoiceID + "";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["RefInvoiceID"] != DBNull.Value)
                    _nRefInvoiceID = Convert.ToInt32(reader["RefInvoiceID"].ToString());
                else _nRefInvoiceID = 0;

                _sInvoiceNo = reader["RefInvoiceNo"].ToString();
            }
            
        }
    }
    public class SalesInvoiceDetails : CollectionBaseCustom
    {

        public void Add(SalesInvoiceInfo oSalesInvoiceInfo)
        {
            this.List.Add(oSalesInvoiceInfo);
        }
        public SalesInvoiceInfo this[Int32 Index]
        {
            get
            {
                return (SalesInvoiceInfo)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(SalesInvoiceInfo))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        //public List<SalesInvoiceInfo> Refresh(DateTime dFromDate, DateTime dToDate,bool IsReplace)
        //{
        //    InnerList.Clear();
        //    List<SalesInvoiceInfo> list = new List<SalesInvoiceInfo>();
        //    dToDate = dToDate.AddDays(1);
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    if (IsReplace == false)
        //    {
        //        sSql = " select qq1.*,qq2.UserName  AS DeliveredByName,isnull(qq3.EmployeeName,'') as SalesPersonName,CustomerAddress, CustomerTelePhone,CustomerFax " +
        //                        " ,CellPhoneNo, ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,OrderNo, OrderDate, SBUID, SBUCode, SBUName, InvoiceTypeName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName " +
        //                        " , OrderReceivedByID, OrderConfirmedByID,  OrderReceivedByName, OrderConfirmedByName " +
        //                        " , qq7.UserName as UpdateUserName, qq8.SundryCustomerName, qq8.Address as SCAddress, qq8.PhoneNo as SCPhoneNo , qq8.CellNo as SCCellNo, qq8.Email as SCEmail ,qq6.InvoiceTypeID" +
        //                        " FROM  " +
        //                        " ( " +
        //                        " SELECT q1.*,q2.CustomerName,q2.CustomerCode,q3.WarehouseCode, q3.WarehouseName, q3.ChannelID,q5.ChannelCode, q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName  FROM t_SalesInvoice q1,t_customer q2, t_warehouse q3, t_User q4, t_Channel q5 " +
        //                        " WHERE q1.customerid = q2.customerid and q1.warehouseid = q3.warehouseid AND InvoiceDate between ? AND ? and InvoiceDate < ? and q4.UserID = q1.InvoiceBy and q3.ChannelID = q5.ChannelID " +
        //                        " ) " +
        //                        " as qq1 Left outer Join " +
        //                        " ( " +
        //                        " select UserID, UserName from t_User " +
        //                        " ) " +
        //                        " as qq2 " +
        //                        " on qq1.DeliveredBy = qq2.UserID " +
        //                        " left outer join " +
        //                        " ( " +
        //                        " select AssignmentCode,JobTypeID,EmployeeName, q1.EmployeeID from t_EmployeeJobType q1, t_Employee q2  " +
        //                        " where q1.EmployeeID = q2.EmployeeID and  IsActive = ? and JobTypeID = ? " +
        //                        " ) " +
        //                        " as qq3 " +
        //                        " on qq1.SalesPersonID = qq3.EmployeeID " +
        //                        " left outer join " +
        //                        " ( " +
        //                        " select CustomerID, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, CustomerTypeCode, CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, SBUID, SBUCode, SBUName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName from v_customerDetails " +
        //                        " ) " +
        //                        " as qq4  " +
        //                        " on qq1.customerid = qq4.customerid " +
        //                        " Left outer join " +
        //                        " ( " +
        //                        " select q1.OrderID, q1.OrderNo, q1. OrderDate, q1.CreateUserID as OrderReceivedByID, q1.ConfirmUserID as OrderConfirmedByID,  q2.UserName as  OrderReceivedByName, q3.UserName as OrderConfirmedByName from " +
        //                        " ( " +
        //                        " select OrderID, OrderNo, OrderDate,CreateUserID, ConfirmUserID from t_salesOrder " +
        //                        " ) " +
        //                        " as q1 " +
        //                        " left outer join " +
        //                        " ( " +
        //                        " select UserID, UserName from t_User " +
        //                        " ) " +
        //                        " as q2 " +
        //                        " on q1.CreateUserID = q2.UserID " +
        //                        " left outer join " +
        //                        " ( " +
        //                        " select UserID, UserName from t_User " +
        //                        " ) " +
        //                        " as q3 " +
        //                        " on q1.ConfirmUserID = q3.UserID " +
        //                        " )  " +
        //                        " as qq5 " +
        //                        " on qq1.orderid = qq5.Orderid " +
        //                        " LEFT OUTER JOIN " +
        //                        " ( " +
        //                        " select InvoiceTypeID, InvoiceTypeName from t_invoicetype " +
        //                        " ) " +
        //                        " as qq6 " +
        //                        " on qq1.InvoiceTypeID = qq6.InvoiceTypeID " +
        //                        " LEFT OUTER JOIN " +
        //                        " ( " +
        //                        " select UserID, UserName from t_User " +
        //                        " ) " +
        //                        " as qq7 " +
        //                        " on qq1.UpdateUserID = qq7.UserID " +
        //                        " LEFT OUTER JOIN " +
        //                        " ( " +
        //                        " SELECT     SundryCustomerID, SundryCustomerName, Address, PhoneNo, CellNo, Email FROM         t_SundryCustomer " +
        //                        " ) " +
        //                        " as qq8 " +
        //                        " on qq1.SundryCustomerID = qq8.SundryCustomerID";

        //    }
        //    else
        //    {
        //        sSql = " select qq1.*,qq2.UserName  AS DeliveredByName,isnull(qq3.EmployeeName,'') as SalesPersonName,CustomerAddress, CustomerTelePhone,CustomerFax " +
        //                       " ,CellPhoneNo, ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,OrderNo, OrderDate, SBUID, SBUCode, SBUName, InvoiceTypeName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName " +
        //                       " , OrderReceivedByID, OrderConfirmedByID,  OrderReceivedByName, OrderConfirmedByName " +
        //                       " , qq7.UserName as UpdateUserName, qq8.SundryCustomerName, qq8.Address as SCAddress, qq8.PhoneNo as SCPhoneNo , qq8.CellNo as SCCellNo, qq8.Email as SCEmail ,qq6.InvoiceTypeID" +
        //                       " FROM  " +
        //                       " ( " +
        //                       " SELECT q1.*,q2.CustomerName,q2.CustomerCode,q3.WarehouseCode, q3.WarehouseName, q3.ChannelID,q5.ChannelCode, q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName  FROM t_SalesInvoice q1,t_customer q2, t_warehouse q3, t_User q4, t_Channel q5 " +
        //                       " WHERE q1.customerid = q2.customerid and q1.warehouseid = q3.warehouseid AND InvoiceDate between ? AND ? and InvoiceDate < ? and q4.UserID = q1.InvoiceBy and q3.ChannelID = q5.ChannelID and q1.InvoiceTypeID in (3,17)" +
        //                       " ) " +
        //                       " as qq1 Left outer Join " +
        //                       " ( " +
        //                       " select UserID, UserName from t_User " +
        //                       " ) " +
        //                       " as qq2 " +
        //                       " on qq1.DeliveredBy = qq2.UserID " +
        //                       " left outer join " +
        //                       " ( " +
        //                       " select AssignmentCode,JobTypeID,EmployeeName, q1.EmployeeID from t_EmployeeJobType q1, t_Employee q2  " +
        //                       " where q1.EmployeeID = q2.EmployeeID and  IsActive = ? and JobTypeID = ? " +
        //                       " ) " +
        //                       " as qq3 " +
        //                       " on qq1.SalesPersonID = qq3.EmployeeID " +
        //                       " left outer join " +
        //                       " ( " +
        //                       " select CustomerID, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, CustomerTypeCode, CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, SBUID, SBUCode, SBUName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName from v_customerDetails " +
        //                       " ) " +
        //                       " as qq4  " +
        //                       " on qq1.customerid = qq4.customerid " +
        //                       " Left outer join " +
        //                       " ( " +
        //                       " select q1.OrderID, q1.OrderNo, q1. OrderDate, q1.CreateUserID as OrderReceivedByID, q1.ConfirmUserID as OrderConfirmedByID,  q2.UserName as  OrderReceivedByName, q3.UserName as OrderConfirmedByName from " +
        //                       " ( " +
        //                       " select OrderID, OrderNo, OrderDate,CreateUserID, ConfirmUserID from t_salesOrder " +
        //                       " ) " +
        //                       " as q1 " +
        //                       " left outer join " +
        //                       " ( " +
        //                       " select UserID, UserName from t_User " +
        //                       " ) " +
        //                       " as q2 " +
        //                       " on q1.CreateUserID = q2.UserID " +
        //                       " left outer join " +
        //                       " ( " +
        //                       " select UserID, UserName from t_User " +
        //                       " ) " +
        //                       " as q3 " +
        //                       " on q1.ConfirmUserID = q3.UserID " +
        //                       " )  " +
        //                       " as qq5 " +
        //                       " on qq1.orderid = qq5.Orderid " +
        //                       " LEFT OUTER JOIN " +
        //                       " ( " +
        //                       " select InvoiceTypeID, InvoiceTypeName from t_invoicetype " +
        //                       " ) " +
        //                       " as qq6 " +
        //                       " on qq1.InvoiceTypeID = qq6.InvoiceTypeID " +
        //                       " LEFT OUTER JOIN " +
        //                       " ( " +
        //                       " select UserID, UserName from t_User " +
        //                       " ) " +
        //                       " as qq7 " +
        //                       " on qq1.UpdateUserID = qq7.UserID " +
        //                       " LEFT OUTER JOIN " +
        //                       " ( " +
        //                       " SELECT     SundryCustomerID, SundryCustomerName, Address, PhoneNo, CellNo, Email FROM         t_SundryCustomer " +
        //                       " ) " +
        //                       " as qq8 " +
        //                       " on qq1.SundryCustomerID = qq8.SundryCustomerID";
        //    }

        //    cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
        //    cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
        //    cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
        //    cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);
        //    cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            SalesInvoiceInfo oSalesInvoiceInfo = new  SalesInvoiceInfo();

        //            oSalesInvoiceInfo.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
        //            oSalesInvoiceInfo.CustomerID = int.Parse(reader["CustomerID"].ToString());
        //            oSalesInvoiceInfo.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
        //            if (reader["OrderID"] != DBNull.Value)
        //                oSalesInvoiceInfo.OrderID = int.Parse(reader["OrderID"].ToString());
        //            else oSalesInvoiceInfo.OrderID = 0;
        //            oSalesInvoiceInfo.InvoiceNo = reader["InvoiceNo"].ToString();
        //            oSalesInvoiceInfo.InvoiceDate = (object)reader["InvoiceDate"];                                      
        //            if (reader["InvoiceAmount"] != DBNull.Value)
        //                oSalesInvoiceInfo.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
        //            else oSalesInvoiceInfo.InvoiceAmount = 0;
        //            oSalesInvoiceInfo.InvoiceByName = reader["InvoiceByName"].ToString();
        //            oSalesInvoiceInfo.DeliveredByName = reader["DeliveredByName"].ToString();                  
        //            oSalesInvoiceInfo.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
        //            oSalesInvoiceInfo.Remarks = reader["Remarks"].ToString();
        //            oSalesInvoiceInfo.CustomerCode = reader["CustomerCode"].ToString();
        //            oSalesInvoiceInfo.CustomerName = reader["CustomerName"].ToString();
        //            oSalesInvoiceInfo.OrderNo = reader["OrderNo"].ToString();
        //            oSalesInvoiceInfo.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());

        //            if (reader["SundryCustomerID"] != DBNull.Value)
        //                oSalesInvoiceInfo.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
        //            else oSalesInvoiceInfo.SundryCustomerID = 0;
        //            oSalesInvoiceInfo.SalesPersonName = reader["SalesPersonName"].ToString();

        //            InnerList.Add(oSalesInvoiceInfo);
        //            list.Add(oSalesInvoiceInfo);

        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return list;
        //}
        public void Refresh(DateTime dFromDate, DateTime dToDate, bool IsReplace)
        {
            InnerList.Clear();
            //List<SalesInvoiceInfo> list = new List<SalesInvoiceInfo>();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

                sSql = "Select InvoiceID,a.CustomerID,a.WarehouseID,isnull(a.OrderID,0) OrderID,InvoiceNo,InvoiceDate, " +
                    "InvoiceAmount,a.Discount,OtherCharge,isnull(d.UserName, '') InvoiceByName, " +
                    "isnull(e.UserName, '') DeliveredByName,InvoiceStatus,a.Remarks,CustomerCode,CustomerName, " +
                    "isnull(OrderNo, '') OrderNo,InvoiceTypeID,SundryCustomerID,isnull(f.EmployeeName, '') as SalesPersonName " +
                    "From t_SalesInvoice a " +
                    "inner join t_Customer b on a.CustomerID = b.CustomerID " +
                    "left outer join t_SalesOrder c on a.OrderID = c.OrderID " +
                    "left outer join t_User d on a.InvoiceBy = d.UserID " +
                    "left outer join t_User e on a.InvoiceBy = e.UserID " +
                    "left outer join t_Employee f on a.SalesPersonID = f.EmployeeID " +
                    "where InvoiceDate between ? AND ? and InvoiceDate < ?";
                if (IsReplace == true)
                {
                    sSql = sSql + " and InvoiceTypeID in (3,17)";
                }
              
            
            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoiceInfo oSalesInvoiceInfo = new SalesInvoiceInfo();

                    oSalesInvoiceInfo.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oSalesInvoiceInfo.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oSalesInvoiceInfo.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    if (reader["OrderID"] != DBNull.Value)
                        oSalesInvoiceInfo.OrderID = int.Parse(reader["OrderID"].ToString());
                    else oSalesInvoiceInfo.OrderID = 0;
                    oSalesInvoiceInfo.InvoiceNo = reader["InvoiceNo"].ToString();
                    oSalesInvoiceInfo.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oSalesInvoiceInfo.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else oSalesInvoiceInfo.InvoiceAmount = 0;
                    oSalesInvoiceInfo.InvoiceByName = reader["InvoiceByName"].ToString();
                    oSalesInvoiceInfo.DeliveredByName = reader["DeliveredByName"].ToString();
                    oSalesInvoiceInfo.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    oSalesInvoiceInfo.Remarks = reader["Remarks"].ToString();
                    oSalesInvoiceInfo.CustomerCode = reader["CustomerCode"].ToString();
                    oSalesInvoiceInfo.CustomerName = reader["CustomerName"].ToString();
                    oSalesInvoiceInfo.OrderNo = reader["OrderNo"].ToString();
                    oSalesInvoiceInfo.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());

                    if (reader["SundryCustomerID"] != DBNull.Value)
                        oSalesInvoiceInfo.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    else oSalesInvoiceInfo.SundryCustomerID = 0;
                    oSalesInvoiceInfo.SalesPersonName = reader["SalesPersonName"].ToString();

                    InnerList.Add(oSalesInvoiceInfo);
                   // list.Add(oSalesInvoiceInfo);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           // return list;
        }


        public void FromDataSetToClass(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    SalesInvoiceInfo oSalesInvoiceInfo = new SalesInvoiceInfo();

                    oSalesInvoiceInfo.InvoiceID = int.Parse(oRow["InvoiceID"].ToString());
                    oSalesInvoiceInfo.CustomerID = int.Parse(oRow["CustomerID"].ToString());
                    oSalesInvoiceInfo.WarehouseID = int.Parse(oRow["WarehouseID"].ToString());
                    if (oRow["OrderID"] != DBNull.Value)
                        oSalesInvoiceInfo.OrderID = int.Parse(oRow["OrderID"].ToString());
                    else oSalesInvoiceInfo.OrderID = 0;
                    oSalesInvoiceInfo.InvoiceNo = oRow["InvoiceNo"].ToString();
                    oSalesInvoiceInfo.InvoiceDate = (object)oRow["InvoiceDate"];
                    if (oRow["InvoiceAmount"] != DBNull.Value)
                        oSalesInvoiceInfo.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"].ToString());
                    else oSalesInvoiceInfo.InvoiceAmount = 0;
                    oSalesInvoiceInfo.InvoiceByName = oRow["InvoiceByName"].ToString();
                    oSalesInvoiceInfo.DeliveredByName = oRow["DeliveredByName"].ToString();
                    oSalesInvoiceInfo.InvoiceStatus = int.Parse(oRow["InvoiceStatus"].ToString());
                    oSalesInvoiceInfo.Remarks = oRow["Remarks"].ToString();
                    oSalesInvoiceInfo.CustomerCode = oRow["CustomerCode"].ToString();
                    oSalesInvoiceInfo.CustomerName = oRow["CustomerName"].ToString();
                    oSalesInvoiceInfo.OrderNo = oRow["OrderNo"].ToString();

                    InnerList.Add(oSalesInvoiceInfo);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
