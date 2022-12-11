// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Feb 24, 2012
// Time :  12:00 PM
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
    public class InvoiceWisePaymentRegister
    {
        private long _CustomerID;
        private string _CustomerCode;
        private string _CustomerName;
        private long _InvoiceNo;
        private DateTime _TDate;
        private double _Amount;
        private string _TransactionType;
        private double _DueAmount;
        private string _RefNo;
        private string _UserName;
        private string _SundryCustomerCode;
        private string _SundryCustomerName;
        private double _CurrentBalance;
        private long _SBUID;
        private int _ChannelId;
        private int _AreaId;
        private int _TerritoryId;

        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        public int ChannelId
        {
            get { return _ChannelId; }
            set { _ChannelId = value; }
        }
        public int AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; }
        }
        public int TerritoryId
        {
            get { return _TerritoryId; }
            set { _TerritoryId = value; }
        }      
        public long CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }
        public long InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        public DateTime TDate
        {
            get { return _TDate; }
            set { _TDate = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public string TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }
        public double DueAmount
        {
            get { return _DueAmount; }
            set { _DueAmount = value; }
        }
        public string RefNo
        {
            get { return _RefNo; }
            set { _RefNo = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string SundryCustomerCode
        {
            get { return _SundryCustomerCode; }
            set { _SundryCustomerCode = value; }
        }
        public string SundryCustomerName
        {
            get { return _SundryCustomerName; }
            set { _SundryCustomerName = value; }
        }
        public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }
    }
    public class InvoiceWisePaymentRegisterReport : CollectionBaseCustom
    {

        public void Add(InvoiceWisePaymentRegister oInvoiceWisePaymentRegister)
        {
            this.List.Add(oInvoiceWisePaymentRegister);
        }
        public InvoiceWisePaymentRegister this[Int32 Index]
        {
            get
            {
                return (InvoiceWisePaymentRegister)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(InvoiceWisePaymentRegister))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
     
        public void GetInvoiceWisePaymentRegister(int nInvoiceSelectionCriteria,int nCustomerId, DateTime _dStartDate, DateTime _dEndDate)
        {
         
            // InnerList.Clear();
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
            _dEndDate = _dEndDate.AddDays(1);

            if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.BY_CUSTOMER_ID)
            {
                sQueryStringMaster.Append(" select   ");
                sQueryStringMaster.Append(" qq1.InvoiceNo, qq1.TDate, qq1.Amount, qq1.TransactionType, qq1.DueAmount, qq1.RefNo, qq1.UserName  ");
                sQueryStringMaster.Append(" ,qq2.SundryCustomerCode, qq2.SundryCustomerName  ");
                sQueryStringMaster.Append(" ,qq3.*  ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select  Invoiceno as InvoiceNo,q1.CustomerID,invoicedate as TDate, invoiceamount as Amount, 'Invoice' as TransactionType, DueAmount, cast( isnull(orderno, InvoiceNo)as varchar(20)) as RefNo, UserName  ");
                sQueryStringMaster.Append(" from   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice  where dueAmount > 0 and customerid = ? and invoicestatus not in (3)  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1   ");
                sQueryStringMaster.Append(" left outer join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select OrderID, OrderNo from t_salesOrder  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q2  ");
                sQueryStringMaster.Append(" on q1.Orderid = q2.Orderid  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3  ");
                sQueryStringMaster.Append(" on q1.InvoiceBy = q3.UserID  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select Invoiceno as InvoiceNo,q1.CustomerID,q3.TranDate as TDate, - q1.Amount as Amount, 'Payment' as TransactionType, 0 as DueAmount, TranNo as RefNo, UserName  ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_InvoiceWisePayment where CreateDate between ? and ?   and customerid = ? ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice where invoicestatus not in (3)  ");
                sQueryStringMaster.Append(" )   ");
                sQueryStringMaster.Append(" as q2   ");
                sQueryStringMaster.Append(" on q1.InvoiceID = q2.INvoiceID   ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_customerTran   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3   ");
                sQueryStringMaster.Append(" on q1.CustomerTranID  = q3.TranID  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q4  ");
                sQueryStringMaster.Append(" on q1.CreateUserID = q4.UserID  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select distinct Invoiceno as InvoiceNo, q1.CustomerID,invoicedate as TDate, q2.InvoiceAmount as Amount, 'Invoice' as TransactionType, 0 as DueAmount, cast( isnull(q5.orderno, q2.InvoiceNo)as varchar(20)) as RefNo, UserName  ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select P1.* from t_InvoiceWisePayment P1, t_SalesInvoice P2 where P1.CreateDate between ? and ? and P1.InvoiceID = P2.InvoiceID and P2.DueAmount = 0 and P1.customerid = ? and invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice where invoicestatus not in (3)  ");
                sQueryStringMaster.Append(" )   ");
                sQueryStringMaster.Append(" as q2   ");
                sQueryStringMaster.Append(" on q1.InvoiceID = q2.INvoiceID   ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_customerTran   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3   ");
                sQueryStringMaster.Append(" on q1.CustomerTranID  = q3.TranID  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q4  ");
                sQueryStringMaster.Append(" on q1.CreateUserID = q4.UserID  ");
                sQueryStringMaster.Append(" left outer join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select OrderID, OrderNo from t_salesOrder  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q5  ");
                sQueryStringMaster.Append(" on q2.Orderid = q5.Orderid  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select  Invoiceno as InvoiceNo,q1.CustomerID,q4.CreateDate as TDate, - q4.amount as Amount, 'Payment' as TransactionType, DueAmount, TranNo as RefNo, UserName  ");
                sQueryStringMaster.Append(" from   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice  where dueAmount > 0 and customerid = ?  and invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1   ");
                sQueryStringMaster.Append(" left outer join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select OrderID, OrderNo from t_salesOrder  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q2  ");
                sQueryStringMaster.Append(" on q1.Orderid = q2.Orderid  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3  ");
                sQueryStringMaster.Append(" on q1.InvoiceBy = q3.UserID  ");
                sQueryStringMaster.Append(" inner join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_InvoiceWisePayment where CreateDate < ? and customerid = ?  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q4  ");
                sQueryStringMaster.Append(" on q1.InvoiceID = q4.InvoiceID   ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_customerTran   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q5  ");
                sQueryStringMaster.Append(" on q4.CustomerTranID  = q5.TranID  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as qq1  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select  oh.invoiceno, sc.CustomerID as  SundryCustomerCode, sc.CustomerName as SundryCustomerName   ");
                sQueryStringMaster.Append(" from orderhistory oh, SundryCustomerAddress sc    ");
                sQueryStringMaster.Append(" where oh.SundryCustomerID = sc.customerid   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as qq2  ");
                sQueryStringMaster.Append(" on qq1.InvoiceNo = qq2.InvoiceNo  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from v_CustomerDetails  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as qq3  ");
                sQueryStringMaster.Append(" on qq1.CustomerID = qq3.CustomerID  ");


                oCmd.CommandText = sQueryStringMaster.ToString();

                oCmd.Parameters.AddWithValue("CustomerID", nCustomerId);
                oCmd.Parameters.AddWithValue("FromDate", _dStartDate);
                oCmd.Parameters.AddWithValue("ToDate", _dEndDate);
                oCmd.Parameters.AddWithValue("CustomerID", nCustomerId);
                oCmd.Parameters.AddWithValue("FromDate", _dStartDate);
                oCmd.Parameters.AddWithValue("ToDate", _dEndDate);
                oCmd.Parameters.AddWithValue("CustomerID", nCustomerId);
                oCmd.Parameters.AddWithValue("CustomerID", nCustomerId);
                oCmd.Parameters.AddWithValue("FromDate", _dStartDate);
                oCmd.Parameters.AddWithValue("CustomerID", nCustomerId);

             
            }
            else if (nInvoiceSelectionCriteria == (long)Dictionary.InvoiceSelectionCriteria.ALL)
            {
                sQueryStringMaster.Append(" select   ");
                sQueryStringMaster.Append(" qq1.InvoiceNo, qq1.TDate, qq1.Amount, qq1.TransactionType, qq1.DueAmount, qq1.RefNo, qq1.UserName  ");
                sQueryStringMaster.Append(" ,qq2.SundryCustomerCode, qq2.SundryCustomerName  ");
                sQueryStringMaster.Append(" ,qq3.*  ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select  Invoiceno as InvoiceNo,q1.CustomerID,invoicedate as TDate, invoiceamount as Amount, 'Invoice' as TransactionType, DueAmount, cast( isnull(orderno, InvoiceNo)as varchar(20)) as RefNo, UserName  ");
                sQueryStringMaster.Append(" from   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice  where dueAmount > 0 and invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1   ");
                sQueryStringMaster.Append(" left outer join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select OrderID, OrderNo from t_salesOrder  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q2  ");
                sQueryStringMaster.Append(" on q1.Orderid = q2.Orderid  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3  ");
                sQueryStringMaster.Append(" on q1.InvoiceBy = q3.UserID  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select Invoiceno as InvoiceNo,q1.CustomerID,q3.TranDate as TDate, - q1.Amount as Amount, 'Payment' as TransactionType, 0 as DueAmount, TranNo as RefNo, UserName  ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_InvoiceWisePayment where CreateDate between ? and ?  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice  where invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )   ");
                sQueryStringMaster.Append(" as q2   ");
                sQueryStringMaster.Append(" on q1.InvoiceID = q2.INvoiceID   ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_customerTran   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3   ");
                sQueryStringMaster.Append(" on q1.CustomerTranID  = q3.TranID  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q4  ");
                sQueryStringMaster.Append(" on q1.CreateUserID = q4.UserID  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select distinct Invoiceno as InvoiceNo, q1.CustomerID,invoicedate as TDate, q2.InvoiceAmount as Amount, 'Invoice' as TransactionType, 0 as DueAmount, cast( isnull(q5.orderno, q2.InvoiceNo)as varchar(20)) as RefNo, UserName  ");
                sQueryStringMaster.Append(" from  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select P1.* from t_InvoiceWisePayment P1, t_SalesInvoice P2 where P1.CreateDate between ? and ? and P1.InvoiceID = P2.InvoiceID and P2.DueAmount = 0 and invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice  where invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )   ");
                sQueryStringMaster.Append(" as q2   ");
                sQueryStringMaster.Append(" on q1.InvoiceID = q2.INvoiceID   ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_customerTran   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3   ");
                sQueryStringMaster.Append(" on q1.CustomerTranID  = q3.TranID  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q4  ");
                sQueryStringMaster.Append(" on q1.CreateUserID = q4.UserID  ");
                sQueryStringMaster.Append(" left outer join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select OrderID, OrderNo from t_salesOrder  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q5  ");
                sQueryStringMaster.Append(" on q2.Orderid = q5.Orderid  ");
                sQueryStringMaster.Append(" union all  ");
                sQueryStringMaster.Append(" select  Invoiceno as InvoiceNo,q1.CustomerID,q4.CreateDate as TDate, - q4.amount as Amount, 'Payment' as TransactionType, DueAmount, TranNo as RefNo, UserName  ");
                sQueryStringMaster.Append(" from   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_salesInvoice  where dueAmount > 0  and invoicestatus not in (3) ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q1   ");
                sQueryStringMaster.Append(" left outer join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select OrderID, OrderNo from t_salesOrder  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q2  ");
                sQueryStringMaster.Append(" on q1.Orderid = q2.Orderid  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_user  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q3  ");
                sQueryStringMaster.Append(" on q1.InvoiceBy = q3.UserID  ");
                sQueryStringMaster.Append(" inner join   ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_InvoiceWisePayment where CreateDate < ?  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q4  ");
                sQueryStringMaster.Append(" on q1.InvoiceID = q4.InvoiceID   ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from t_customerTran   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as q5  ");
                sQueryStringMaster.Append(" on q4.CustomerTranID  = q5.TranID  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as qq1  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select  oh.invoiceno, sc.CustomerID as  SundryCustomerCode, sc.CustomerName as SundryCustomerName   ");
                sQueryStringMaster.Append(" from orderhistory oh, SundryCustomerAddress sc    ");
                sQueryStringMaster.Append(" where oh.SundryCustomerID = sc.customerid   ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as qq2  ");
                sQueryStringMaster.Append(" on qq1.InvoiceNo = qq2.InvoiceNo  ");
                sQueryStringMaster.Append(" left outer join  ");
                sQueryStringMaster.Append(" (  ");
                sQueryStringMaster.Append(" select * from v_CustomerDetails  ");
                sQueryStringMaster.Append(" )  ");
                sQueryStringMaster.Append(" as qq3  ");
                sQueryStringMaster.Append(" on qq1.CustomerID = qq3.CustomerID  ");

                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sQueryStringMaster.ToString();

                oCmd.Parameters.AddWithValue("FromDate", _dStartDate);
                oCmd.Parameters.AddWithValue("ToDate", _dEndDate);
                oCmd.Parameters.AddWithValue("FromDate", _dStartDate);
                oCmd.Parameters.AddWithValue("ToDate", _dEndDate);
                oCmd.Parameters.AddWithValue("FromDate", _dStartDate);

            }
            try
            {
                InvoiceWisePaymentRegisterDetail(oCmd);
            }
            catch
            {
            }

        }
        private void InvoiceWisePaymentRegisterDetail(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceWisePaymentRegister oItem = new InvoiceWisePaymentRegister();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;           
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;
                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = (int)reader["AreaId"];
                    else oItem.AreaId = -1;
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = (int)reader["TerritoryId"];
                    else oItem.TerritoryId = -1;
                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oItem.InvoiceNo =Convert.ToInt64( reader["InvoiceNo"]);
                    else oItem.InvoiceNo = 0;
                    if (reader["TDate"] != DBNull.Value)
                        oItem.TDate = Convert.ToDateTime(reader["TDate"]);
                    else oItem.TDate = DateTime.Today.Date;
                    if (reader["Amount"] != DBNull.Value)
                        oItem.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else oItem.Amount = 0;
                    if (reader["TransactionType"] != DBNull.Value)
                        oItem.TransactionType = (string)reader["TransactionType"];
                    else oItem.TransactionType = "";
                    if (reader["DueAmount"] != DBNull.Value)
                        oItem.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else oItem.DueAmount = 0;
                    if (reader["RefNo"] != DBNull.Value)
                        oItem.RefNo = (string)reader["RefNo"];
                    else oItem.RefNo = "";
                    if (reader["UserName"] != DBNull.Value)
                        oItem.UserName = (string)reader["UserName"];
                    else oItem.UserName = "";
                    if (reader["CurrentBalance"] != DBNull.Value)
                        oItem.CurrentBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    else oItem.CurrentBalance = 0;
                    if (reader["SundryCustomerCode"] != DBNull.Value)
                        oItem.SundryCustomerCode = (string)reader["SundryCustomerCode"];
                    else oItem.SundryCustomerCode = "";
                    if (reader["SundryCustomerName"] != DBNull.Value)
                        oItem.SundryCustomerName = (string)reader["SundryCustomerName"];
                    else oItem.SundryCustomerName = "";

                    Add(oItem);

                    //InnerList.Add(oItem);
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetForInvoiceWisePaymentRegister(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    InvoiceWisePaymentRegister oInvoiceWisePaymentRegister = new InvoiceWisePaymentRegister();

                    oInvoiceWisePaymentRegister.SBUID = Convert.ToInt32(oRow["SBUID"]);              
                    oInvoiceWisePaymentRegister.ChannelId = (int)oRow["ChannelID"];
                    oInvoiceWisePaymentRegister.AreaId = (int)oRow["AreaId"];
                    oInvoiceWisePaymentRegister.TerritoryId = (int)oRow["TerritoryId"];
                    oInvoiceWisePaymentRegister.CustomerID =Convert.ToInt32( oRow["CustomerID"]);
                    oInvoiceWisePaymentRegister.CustomerCode = (string)oRow["CustomerCode"];
                    oInvoiceWisePaymentRegister.CustomerName = (string)oRow["CustomerName"];
                    oInvoiceWisePaymentRegister.Amount = Convert.ToDouble(oRow["Amount"].ToString());
                    oInvoiceWisePaymentRegister.DueAmount = Convert.ToDouble(oRow["DueAmount"].ToString());
                    oInvoiceWisePaymentRegister.InvoiceNo =Convert.ToInt64( oRow["InvoiceNo"]);
                    oInvoiceWisePaymentRegister.TDate = Convert.ToDateTime(oRow["TDate"]);
                    oInvoiceWisePaymentRegister.TransactionType = (string)(oRow["TransactionType"].ToString());
                    oInvoiceWisePaymentRegister.RefNo = (oRow["RefNo"].ToString());
                    oInvoiceWisePaymentRegister.UserName = (oRow["UserName"].ToString());
                    oInvoiceWisePaymentRegister.SundryCustomerCode = (oRow["SundryCustomerCode"].ToString());
                    oInvoiceWisePaymentRegister.SundryCustomerName = (oRow["SundryCustomerName"].ToString());
                    oInvoiceWisePaymentRegister.CurrentBalance = Convert.ToDouble(oRow["CurrentBalance"].ToString());

                    InnerList.Add(oInvoiceWisePaymentRegister);
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
