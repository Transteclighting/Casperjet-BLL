// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Jun 14, 2011
// Description: Customer Wise Outstanding Ageing Report[815] & Customer Outstanding [801] 
// Modify Person And Date: Dipak K. Chakraborty, Date: July 07, 2011 
// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    [Serializable]
   public class rptOutstandingPositionReport
    {
       public int _nCustomerID;
       public string _sCustomerName;
       public string _sCustomerCode;
       public int _nAreaID;
       public int _nAreaCode;
       public string _sAreaName;
       public int _nTerritoryID;
       public int _nTerritoryCode;
       public string _sTerritoryName;
       public int _nCustomertypeID;    
       public string _sCustomerTypeName;
       public int _nChannelID;
       public int _nChannelCode;
       public string _sChannelDescription;
       public double _OpeningOS;
       public double _ClosingOS;
       public double _InvoiceAmount;
       public double _dueAmount;
       public double _CurrentBalance;
       public double _Outstanding; 
       public DateTime _dPendingSince;
       public DateTime _dDeliveryDate;
       public DateTime _dMonths;
       public DateTime _dFromdate;
       public DateTime _dTodate;
       public int _Status;
       public int _nIsactive;
       public DateTime _dOpeningOutstandingDate;
       public DateTime _dClosingOutstandingDate;
       public double _nNewBalance;

       public int CustomerID
        {
           get { return _nCustomerID; }
           set { _nCustomerID = value; }
        }
       public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
       public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }

        }
       public int AreaID
       {
           get { return _nAreaID; }
           set { _nAreaID = value; }
       }
       public int AreaCode
       {
           get { return _nAreaCode; }
           set { _nAreaCode = value; }
       }
       public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
       public int TerritoryID
       {
           get { return _nTerritoryID; }
           set { _nTerritoryID = value; }
       }
       public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
       public int TerritoryCode
        {
            get { return _nTerritoryCode; }
            set { _nTerritoryCode = value; }
        }
       public int CustomerTypeID
       {
           get { return _nCustomertypeID; }
           set { _nCustomertypeID = value; }
       }
       public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value; }
        }
       public string ChannelDescription
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value; }
        }
       public int ChannelCode
        {
            get { return _nChannelCode; }
            set { _nChannelCode = value; }
        }
       public int ChannelID
       {
           get { return _nChannelID ; }
           set { _nChannelID = value; }
       }
       public double OpeningOS
       {
           get { return _OpeningOS; }
           set { _OpeningOS = value; }
       }
       public double ClosingOS
       {
           get { return _ClosingOS; }
           set { _ClosingOS = value; }
       }
       public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
       public double DueAmount
        {
            get { return _dueAmount; }
            set { _dueAmount = value; }
        }
       public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }
       public double Outstanding
       {
           get { return _Outstanding; }
           set { _Outstanding = value; }
       }
       public DateTime PendingSince
        {
            get { return _dPendingSince; }
            set { _dPendingSince = value; }
        }
       public DateTime DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }
       public DateTime Months
        {
            get { return _dMonths; }
            set { _dMonths = value; }
        }
       public DateTime Fromdate
        {
            get { return _dFromdate; }
            set { _dFromdate = value; }
        }
       public DateTime Todate
        {
            get { return _dTodate; }
            set { _dTodate = value; }
        }
       public int Status
       {
            get { return _Status; }
            set { _Status = value; }
        }
       public int IsActive
       {
           get { return _nIsactive; }
           set { _nIsactive = value; }
       }
       public DateTime OpeningOutstandingDate
        {
            get { return _dOpeningOutstandingDate; }
            set { _dOpeningOutstandingDate = value; }
        }
       public DateTime ClosingOutstandingDate
        {
            get { return _dClosingOutstandingDate; }
            set { _dClosingOutstandingDate = value; }
        }

       public double NewBalance
       {
           get { return _nNewBalance; }
           set { _nNewBalance = value; }
       }

     
    }

    public class rptOutstandingPositionReportDetail : CollectionBaseCustom
    {
       
        public void Add(rptOutstandingPositionReport orptOutstandingPositionReport)
        {
          this.List.Add(orptOutstandingPositionReport);
        }
        public rptOutstandingPositionReport this[Int32 Index]
        {
            get
            {
                return (rptOutstandingPositionReport)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptOutstandingPositionReport))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void Refresh(int nChannelID,int nAreaID, string sCustomerCode, DateTime _dTodate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = " select a.CustomerCode, a.CustomerName, a.ChannelDescription, sum(b.InvoiceAmount)as InvoiceAmount,sum (b.DueAmount)as DueAmount, min(b.InvoiceDate) as PendingSince from  v_CustomerDetails as a, t_SalesInvoice as b where DueAmount > 0 and b.InvoiceDate <= '" + _dTodate + "' and a.CustomerID=b.CustomerID and b.deliverydate is not NULL and invoicestatus not in (3)";


            if (nChannelID > -1)
            {

                sSql = sSql + " and channelID='"+nChannelID+"' ";

            }
            if (nAreaID > -1)
            {
                sSql = sSql + " and Areaid= '"+nAreaID+"' ";

            }
            if (sCustomerCode != "")
            {
                sSql = sSql + "and CustomerCode='"+sCustomerCode+"'";
            
            }

            sSql = sSql + "group by a.CustomerCode, a.CustomerName, a.ChannelDescription order by PendingSince asc";

            try
            {
                cmd.CommandText = sSql;               
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {

                    rptOutstandingPositionReport orptOutstandingPosition = new rptOutstandingPositionReport();

                    orptOutstandingPosition.CustomerCode = (string)reader["CustomerCode"];
                    orptOutstandingPosition.CustomerName = (string)reader["CustomerName"];
                    orptOutstandingPosition.ChannelDescription = (string)reader["ChannelDescription"];
                    orptOutstandingPosition.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]);
                    orptOutstandingPosition.DueAmount = Convert.ToDouble(reader["DueAmount"]);
                    orptOutstandingPosition.PendingSince = Convert.ToDateTime(reader["PendingSince"]);
                    InnerList.Add(orptOutstandingPosition);                   

                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            //return this;

        }

        public void CustomerOutstanding()
        {
            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = " select a.CustomerID, a.CustomerCode, a.CustomerName, a.ChannelDescription, a.ChannelCode, a.ChannelID, a.AreaName, a.AreaCode,a.AreaID, a.TerritoryName, a.TerritoryCode,a.TerritoryID, a.CustomertypeName,Isactive, (sum (b.CurrentBalance)*-1) as Outstanding  from  v_CustomerDetails as a, t_CustomerAccount as b  where a.CustomerID=b.CustomerID " +
                   " Group by a.CustomerID, a.CustomerCode, a.CustomerName, a.ChannelDescription, a.ChannelCode, a.ChannelID, a.AreaName, a.AreaCode,a.AreaID, a.TerritoryName, a.TerritoryCode,a.TerritoryID, a.CustomertypeName,Isactive ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    rptOutstandingPositionReport orptOutstandingPosition = new rptOutstandingPositionReport();

                    orptOutstandingPosition.CustomerCode = (string)reader["CustomerCode"];
                    orptOutstandingPosition.CustomerName = (string)reader["CustomerName"];
                    orptOutstandingPosition.CustomerID = Convert.ToInt16(reader["CustomerID"]);

                    orptOutstandingPosition.ChannelDescription = (string)reader["ChannelDescription"];
                    orptOutstandingPosition.ChannelCode = Convert.ToInt16(reader["ChannelCode"]);
                    orptOutstandingPosition.ChannelID = Convert.ToInt16(reader["ChannelID"]);

                    orptOutstandingPosition.AreaName = (string)reader["AreaName"];
                    orptOutstandingPosition.AreaCode = Convert.ToInt16(reader["AreaCode"]);
                    orptOutstandingPosition.AreaID = Convert.ToInt16(reader["AreaID"]);

                    orptOutstandingPosition.TerritoryName = (string)reader["TerritoryName"];
                    orptOutstandingPosition.TerritoryCode = Convert.ToInt16(reader["TerritoryCode"]);
                    orptOutstandingPosition.TerritoryID = Convert.ToInt16(reader["TerritoryID"]);

                    orptOutstandingPosition.CustomerTypeName = (string)reader["CustomertypeName"];
                    orptOutstandingPosition.CurrentBalance = Convert.ToDouble(reader["Outstanding"]);
                    orptOutstandingPosition.NewBalance = Convert.ToDouble(reader["Outstanding"]);
                    orptOutstandingPosition.Status=Convert.ToInt16(reader["IsActive"]);
                    orptOutstandingPosition.Outstanding = -1;
                    orptOutstandingPosition.InvoiceAmount = -1;
                    orptOutstandingPosition.DueAmount = -1;
                    orptOutstandingPosition.PendingSince = Convert.ToDateTime("01-Jan-2011");
                    orptOutstandingPosition.DeliveryDate =Convert.ToDateTime("01-Jan-2011");
                    orptOutstandingPosition.Months = Convert.ToDateTime("01-Jan-2011");
                    orptOutstandingPosition.Fromdate =Convert.ToDateTime("01-Jan-2011");
                    orptOutstandingPosition.Todate =Convert.ToDateTime("01-Jan-2011");
                    orptOutstandingPosition.OpeningOutstandingDate =Convert.ToDateTime( "01-Jan-2011");
                    orptOutstandingPosition.ClosingOutstandingDate =Convert.ToDateTime("01-Jan-2011");
                    InnerList.Add(orptOutstandingPosition);
                     
                   }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
              
       
        }
        public void FromDataSetForCustomerOutstanding(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptOutstandingPositionReport orptOutstandingPosition = new rptOutstandingPositionReport();

                    orptOutstandingPosition.CustomerCode = (string)oRow["CustomerCode"];
                    orptOutstandingPosition.CustomerName = (string)oRow["CustomerName"];
                    orptOutstandingPosition.ChannelDescription = (string)oRow["ChannelDescription"];
                    orptOutstandingPosition.ChannelCode = Convert.ToInt16(oRow["ChannelCode"]);
                    orptOutstandingPosition.AreaName = (string)oRow["AreaName"];
                    orptOutstandingPosition.AreaCode = Convert.ToInt16(oRow["AreaCode"]);
                    orptOutstandingPosition.TerritoryName = (string)oRow["TerritoryName"];
                    orptOutstandingPosition.TerritoryCode = Convert.ToInt16(oRow["TerritoryCode"]);
                    orptOutstandingPosition.CustomerTypeName = (string)oRow["CustomertypeName"];
                    orptOutstandingPosition.CurrentBalance = Convert.ToDouble(oRow["CurrentBalance"]);
                    orptOutstandingPosition.NewBalance = Convert.ToDouble(oRow["CurrentBalance"]);
                    InnerList.Add(orptOutstandingPosition);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CustomerOpeningOutstanding(DateTime dYFromDate, DateTime dYToDate)
        {
            DateTime dCurrentDate = new DateTime();                       
           
            OleDbCommand cmd = DBController.Instance.GetCommand();            
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
             
            sQueryStringMaster.Append("select q5.CustomerID, q5.CustomerCode, q5.CustomerName, q5.ChannelDescription, q5.ChannelCode, q5.ChannelID, q5.AreaName, q5.AreaCode,q5.AreaID, q5.TerritoryName, q5.TerritoryCode,q5.TerritoryID, q5.CustomertypeName, q5.CustomertypeID,q5.IsActive, (((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append(" select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select Customerid,CustomerCode, CustomerName, ChannelDescription, ChannelCode,ChannelID, AreaName, AreaCode,AreaID, TerritoryName, TerritoryCode,TerritoryID, CustomertypeName,CustomertypeID,IsActive ");
            sQueryStringMaster.Append("from v_CustomerDetails ");
            sQueryStringMaster.Append("group by Customerid,CustomerCode, CustomerName, ChannelDescription, ChannelCode,ChannelID, AreaName, AreaCode,AreaID, TerritoryName, TerritoryCode,TerritoryID, CustomertypeName,CustomertypeID,IsActive ");
            sQueryStringMaster.Append(")as q5 ");
            sQueryStringMaster.Append("on q1.CustomerID= q5.CustomerID ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate >= ? ");
            sQueryStringMaster.Append(" group by customerid  ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q2 ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate >= ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") as q3 ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid ");

            
          
            //Command time out
             cmd.CommandTimeout = 0;
             cmd.CommandText = sQueryStringMaster.ToString();

             cmd.Parameters.AddWithValue("ct.TranDate", dYFromDate);
             //cmd.Parameters.AddWithValue("ct.TranDate", dYToDate.AddDays(1));

             cmd.Parameters.AddWithValue("ct.TranDate", dYFromDate);
             //cmd.Parameters.AddWithValue("ct.TranDate", dYToDate.AddDays(1));

             getOpeningOutstandingdata(cmd); 

        }

        public void getOpeningOutstandingdata(OleDbCommand cmd)
        {
            try
            {  
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptOutstandingPositionReport oItem = new rptOutstandingPositionReport();
                                        
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"]; 
                    else oItem.CustomerName = "";
                    if (reader["CustomerId"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt32(reader["CustomerId"]);
                    else oItem.CustomerID = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";
                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID =Convert.ToInt32(reader["AreaID"]);
                    else oItem.AreaID = -1;
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = Convert.ToInt16(reader["AreaCode"]);
                    else oItem.AreaCode = Convert.ToInt16("");
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";
                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = Convert.ToInt16(reader["TerritoryID"]);
                    else oItem.TerritoryID = Convert.ToInt16("");
                    
                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = Convert.ToInt16(reader["TerritoryCode"]);
                    else oItem.TerritoryCode = Convert.ToInt16("");
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";
                   
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt16(reader["ChannelID"]);
                    else oItem.ChannelID = Convert.ToInt16("");
                    
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = Convert.ToInt16(reader["ChannelCode"]);
                    else oItem.ChannelCode = Convert.ToInt16("");
                    if (reader["ChannelDescription"] != DBNull.Value)
                        oItem.ChannelDescription = (string)reader["ChannelDescription"];
                    else oItem.ChannelDescription = "";
                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = Convert.ToInt16(reader["CustomerTypeID"]);
                    else oItem.CustomerTypeID = Convert.ToInt16("");
                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";
                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive = Convert.ToInt16(reader["IsActive"]);
                    else oItem.IsActive = Convert.ToInt16("");

                    if (reader["OpeningOS"] != DBNull.Value)
                        oItem.OpeningOS = Convert.ToDouble(reader["OpeningOS"]);
                    else oItem.OpeningOS = Convert.ToInt16("");
                                                            
                    Add(oItem);

                 
                }
                reader.Close();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
       
        }

        public void FromDataSetOpeningOutstanding(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptOutstandingPositionReport orptOutstandingPositionReport = new rptOutstandingPositionReport();

                    orptOutstandingPositionReport.CustomerID = Convert.ToInt16(oRow["CustomerId"]);
                    orptOutstandingPositionReport.CustomerCode = (string) oRow["CustomerCode"];
                    orptOutstandingPositionReport.CustomerName = (string)oRow["CustomerName"];
                    orptOutstandingPositionReport.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    orptOutstandingPositionReport.AreaCode = Convert.ToInt16(oRow["AreaCode"]);
                    orptOutstandingPositionReport.AreaName = (string)oRow["AreaName"];
                    orptOutstandingPositionReport.TerritoryID = Convert.ToInt16(oRow["TerritoryID"]);
                    orptOutstandingPositionReport.TerritoryCode = Convert.ToInt16(oRow["TerritoryCode"]);
                    orptOutstandingPositionReport.TerritoryName = (string)oRow["TerritoryName"];
                    orptOutstandingPositionReport.ChannelID = Convert.ToInt16(oRow["ChannelID"]);
                    orptOutstandingPositionReport.ChannelCode = Convert.ToInt16(oRow["ChannelCode"]);
                    orptOutstandingPositionReport.ChannelDescription = (string)oRow["ChannelDescription"];
                    orptOutstandingPositionReport.CustomerTypeID = Convert.ToInt16(oRow["CustomerTypeID"]);
                    orptOutstandingPositionReport.CustomerTypeName = (string)oRow["CustomerTypeName"];
                    orptOutstandingPositionReport.CurrentBalance = Convert.ToDouble(oRow["OpeningOS"]);
                    orptOutstandingPositionReport.IsActive= Convert.ToInt16( oRow["IsActive"]);
                    
                    InnerList.Add(orptOutstandingPositionReport);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void CustomerOpeningOutstanding(DataSet _oDS)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void CustomerClosingOutstanding(DateTime dYFromDate, DateTime dYToDate)
        {

            DateTime dCurrentDate = new DateTime();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();
            
            sQueryStringMaster.Append("select q5.CustomerID, q5.CustomerCode, q5.CustomerName, q5.ChannelDescription, q5.ChannelCode, q5.ChannelID, q5.AreaName, q5.AreaCode,q5.AreaID, q5.TerritoryName, q5.TerritoryCode,q5.TerritoryID, q5.CustomertypeName, q5.CustomertypeID,q5.IsActive, (((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as ClosingOS from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append(" select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select Customerid,CustomerCode, CustomerName, ChannelDescription, ChannelCode,ChannelID, AreaName, AreaCode,AreaID, TerritoryName, TerritoryCode,TerritoryID, CustomertypeName,CustomertypeID,IsActive ");
            sQueryStringMaster.Append("from v_CustomerDetails ");
            sQueryStringMaster.Append("group by Customerid,CustomerCode, CustomerName, ChannelDescription, ChannelCode,ChannelID, AreaName, AreaCode,AreaID, TerritoryName, TerritoryCode,TerritoryID, CustomertypeName,CustomertypeID,IsActive ");
            sQueryStringMaster.Append(")as q5 ");
            sQueryStringMaster.Append("on q1.CustomerID= q5.CustomerID ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate >= ? ");
            sQueryStringMaster.Append(" group by customerid  ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q2 ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate >= ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") as q3 ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid ");

            //Command time out
            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.AddDays(1));
            //cmd.Parameters.AddWithValue("ct.TranDate", dYToDate.AddDays(1));

            cmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.AddDays(1));
            //cmd.Parameters.AddWithValue("ct.TranDate", dYToDate.AddDays(1));
                       
            GetClosingOutstandingData(cmd);

        }

        public void GetClosingOutstandingData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptOutstandingPositionReport oItem = new rptOutstandingPositionReport();
                    
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";
                    if (reader["CustomerId"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt32(reader["CustomerId"]);
                    else oItem.CustomerID = -1;
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = Convert.ToInt32(reader["AreaID"]);
                    else oItem.AreaID = -1;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = Convert.ToInt16(reader["AreaCode"]);
                    else oItem.AreaCode = Convert.ToInt16("");

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = Convert.ToInt16(reader["TerritoryID"]);
                    else oItem.TerritoryID = Convert.ToInt16("");

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = Convert.ToInt16(reader["TerritoryCode"]);
                    else oItem.TerritoryCode = Convert.ToInt16("");
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt16(reader["ChannelID"]);
                    else oItem.ChannelID = Convert.ToInt16("");

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = Convert.ToInt16(reader["ChannelCode"]);
                    else oItem.ChannelCode = Convert.ToInt16("");
                    if (reader["ChannelDescription"] != DBNull.Value)
                        oItem.ChannelDescription = (string)reader["ChannelDescription"];
                    else oItem.ChannelDescription = "";
                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = Convert.ToInt16(reader["CustomerTypeID"]);
                    else oItem.CustomerTypeID = Convert.ToInt16("");

                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";

                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive = Convert.ToInt16(reader["IsActive"]);
                    else oItem.IsActive = Convert.ToInt16("");

                    if (reader["ClosingOS"] != DBNull.Value)
                        oItem.ClosingOS = Convert.ToDouble(reader["ClosingOS"]);
                    else oItem.ClosingOS = Convert.ToInt16("");
                    
                    Add(oItem);
                                       
                }
                reader.Close();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        
        }

        public void FromDataSetClosingOutstanding(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptOutstandingPositionReport orptOutstandingPositionReport = new rptOutstandingPositionReport();

                    orptOutstandingPositionReport.CustomerID = Convert.ToInt16(oRow["CustomerId"]);
                    orptOutstandingPositionReport.CustomerCode = (string)oRow["CustomerCode"];
                    orptOutstandingPositionReport.CustomerName = (string)oRow["CustomerName"];
                    orptOutstandingPositionReport.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    orptOutstandingPositionReport.AreaCode = Convert.ToInt16(oRow["AreaCode"]);
                    orptOutstandingPositionReport.AreaName = (string)oRow["AreaName"];
                    orptOutstandingPositionReport.TerritoryID = Convert.ToInt16(oRow["TerritoryID"]);
                    orptOutstandingPositionReport.TerritoryCode = Convert.ToInt16(oRow["TerritoryCode"]);
                    orptOutstandingPositionReport.TerritoryName = (string)oRow["TerritoryName"];
                    orptOutstandingPositionReport.ChannelID = Convert.ToInt16(oRow["ChannelID"]);
                    orptOutstandingPositionReport.ChannelCode = Convert.ToInt16(oRow["ChannelCode"]);
                    orptOutstandingPositionReport.ChannelDescription = (string)oRow["ChannelDescription"];
                    orptOutstandingPositionReport.CustomerTypeID = Convert.ToInt16(oRow["CustomerTypeID"]);
                    orptOutstandingPositionReport.CustomerTypeName = (string)oRow["CustomerTypeName"];
                    orptOutstandingPositionReport.CurrentBalance = Convert.ToDouble(oRow["ClosingOS"]);
                    orptOutstandingPositionReport.IsActive = Convert.ToInt16(oRow["IsActive"]);

                    InnerList.Add(orptOutstandingPositionReport);
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
