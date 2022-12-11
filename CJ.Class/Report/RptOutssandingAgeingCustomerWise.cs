// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Feb 26, 2012
// Time" :  10:00 AM
// Descriptio: Outstanding Ageing Customer wise [815]
// Modify Person And Date:
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
   public class RptOutssandingAgeingCustomerWise
    {
        private long _SBUID;
        private string _sSBUCode;
        private string _sSBUName;
        private int _nChannelID;
        private string _sChannelCode;
        private string _sChannelDescription;
        private int _nAreaID;
        private string _sAreaCode;
        private string _sAreaName;
        private int _nTerritoryID;
        private string _sTerritoryCode;
        private string _sTerritoryName;

        private int _nCustomerTypeID;
        private string _sCustomerTypeName;
        private int _nIsActive;

        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private double _ClosingBalance;
        private double _Month01;
        private double _Month02;
        private double _Month03;
        private double _Month04;
        private double _Month05;
        private double _Month06;
        private double _Month07;
        private double _Month08;
        private double _Month09;
        private double _Month10;
        private double _Month11;
        private double _Month12;
        private double _MonthGT12;


        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
       public string SBUCode
       {
           get { return _sSBUCode; }
           set { _sSBUCode = value; }
       }
        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
       public string ChannelCode
       {
           get { return _sChannelCode; }
           set { _sChannelCode = value; }

       }
        public string ChannelName
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value; }

        }
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
       public string AreaCode
       {
           get { return _sAreaCode; }
           set { _sAreaCode = value; }
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
       public string TerritoryCode 
       {
           get { return _sTerritoryCode; }
           set { _sTerritoryCode = value; }
       }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }

       public int CustomerTypeID
       {
           get { return _nCustomerTypeID; }
           set { _nCustomerTypeID = value; }
       }
       public string CustomerTypeName
       {
           get { return _sCustomerTypeName; }
           set { _sCustomerTypeName = value; }
       }
       public int IsActive
       {
           get { return _nIsActive; }
           set { _nIsActive = value; }
       }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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

       public double ClosingBalance
       {
           get { return _ClosingBalance; }
           set { _ClosingBalance = value; }
       }

       public double Month01
       {
           get { return _Month01; }
           set { _Month01 = value; }
       }
       public double Month02
       {
           get { return _Month02; }
           set { _Month02 = value; }
       }
       public double Month03
       {
           get { return _Month03; }
           set { _Month03 = value; }
       }
       public double Month04
       {
           get { return _Month04; }
           set { _Month04 = value; }
       }
       public double Month05
       {
           get { return _Month05; }
           set { _Month05 = value; }
       }
       public double Month06
       {
           get { return _Month06; }
           set { _Month06 = value; }
       }
       public double Month07
       {
           get { return _Month07; }
           set { _Month07 = value; }
       }
       public double Month08
       {
           get { return _Month08; }
           set { _Month08 = value; }
       }
       public double Month09
       {
           get { return _Month09; }
           set { _Month09 = value; }
       }
       public double Month10
       {
           get { return _Month10; }
           set { _Month10 = value; }
       }
       public double Month11
       {
           get { return _Month11; }
           set { _Month11 = value; }
       }
       public double Month12
       {
           get { return _Month12; }
           set { _Month12 = value; }
       }
       public double MonthGT12
       {
           get { return _MonthGT12; }
           set { _MonthGT12 = value; }
       }
                   
    }

    public class RptOutssandingAgeingCustomerWiseDetauls : CollectionBaseCustom
    {
        public void Add(RptOutssandingAgeingCustomerWise oProductSalesQtyandValueCustomerWise)
        {
            this.List.Add(oProductSalesQtyandValueCustomerWise);
        }
        public RptOutssandingAgeingCustomerWise this[Int32 Index]
        {
            get
            {
                return (RptOutssandingAgeingCustomerWise)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptOutssandingAgeingCustomerWise))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void OutstandingAgeingCustomer(DateTime dYFromDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("Set dateformat dmy ");
            sQueryStringMaster.Append("select   ");
            sQueryStringMaster.Append("SBUID, SBUCode, SBUName  ");
            sQueryStringMaster.Append(",ChannelID, ChannelCode, ChannelDescription as ChannelName  ");
            sQueryStringMaster.Append(",AreaID, AreaCode, AreaName  ");
            sQueryStringMaster.Append(",TerritoryID, TerritoryCode, TerritoryName ,CustomerTypeID, CustomerTypeName, IsActive  ");
            sQueryStringMaster.Append(",CustomerID, CustomerCode, CustomerName  ");
            sQueryStringMaster.Append(",sum(ClosingBalance) as ClosingBalance  ");
            sQueryStringMaster.Append(",sum(Month01) as Month01   ");
            sQueryStringMaster.Append(",sum(Month02) as Month02   ");
            sQueryStringMaster.Append(",sum(Month03) as Month03   ");
            sQueryStringMaster.Append(",sum(Month04) as Month04   ");
            sQueryStringMaster.Append(",sum(Month05) as Month05  ");
            sQueryStringMaster.Append(",sum(Month06) as Month06   ");
            sQueryStringMaster.Append(",sum(Month07) as Month07  ");
            sQueryStringMaster.Append(",sum(Month08) as Month08   ");
            sQueryStringMaster.Append(",sum(Month09) as Month09   ");
            sQueryStringMaster.Append(",sum(Month10) as Month10  ");
            sQueryStringMaster.Append(",sum(Month11) as Month11  ");
            sQueryStringMaster.Append(",sum(Month12) as Month12   ");
            sQueryStringMaster.Append(",sum(MonthGT12) as MonthGT12   ");
            sQueryStringMaster.Append(" FROM  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select qq3.*,isnull(ClosingBalance,0) as ClosingBalance  ");
            sQueryStringMaster.Append(",isnull(Month01,0) as Month01  ");
            sQueryStringMaster.Append(",isnull(Month02,0) as Month02  ");
            sQueryStringMaster.Append(",isnull(Month03,0) as Month03  ");
            sQueryStringMaster.Append(",isnull(Month04,0) as Month04  ");
            sQueryStringMaster.Append(",isnull(Month05,0) as Month05  ");
            sQueryStringMaster.Append(",isnull(Month06,0) as Month06  ");
            sQueryStringMaster.Append(",isnull(Month07,0) as Month07  ");
            sQueryStringMaster.Append(",isnull(Month08,0) as Month08    ");
            sQueryStringMaster.Append(",isnull(Month09,0) as Month09  ");
            sQueryStringMaster.Append(",isnull(Month10,0) as Month10  ");
            sQueryStringMaster.Append(",isnull(Month11,0) as Month11    ");
            sQueryStringMaster.Append(",isnull(Month12,0) as Month12    ");
            sQueryStringMaster.Append(",isnull(MonthGT12,0) as MonthGT12  ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  -((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as ClosingBalance  ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(") as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(") as q2 on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(") as q3 on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append(") as qq1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select CustomerID, ");
            sQueryStringMaster.Append("sum(case When DayNo<= 30 then DueAmount else 0 end) as Month01, ");
            sQueryStringMaster.Append("sum(case When DayNo between 31 and 60 then DueAmount else 0 end) as Month02, ");
            sQueryStringMaster.Append("sum(case When DayNo between 61 and 90 then DueAmount else 0 end) as Month03, ");
            sQueryStringMaster.Append("sum(case When DayNo between 91 and 120 then DueAmount else 0 end) as Month04, ");
            sQueryStringMaster.Append("sum(case When DayNo between 121 and 150 then DueAmount else 0 end) as Month05, ");
            sQueryStringMaster.Append("sum(case When DayNo between 151 and 180 then DueAmount else 0 end) as Month06, ");
            sQueryStringMaster.Append("sum(case When DayNo between 181 and 210 then DueAmount else 0 end) as Month07, ");
            sQueryStringMaster.Append("sum(case When DayNo between 211 and 240 then DueAmount else 0 end) as Month08, ");
            sQueryStringMaster.Append("sum(case When DayNo between 241 and 270 then DueAmount else 0 end) as Month09, ");
            sQueryStringMaster.Append("sum(case When DayNo between 271 and 300 then DueAmount else 0 end) as Month10, ");
            sQueryStringMaster.Append("sum(case When DayNo between 301 and 330 then DueAmount else 0 end) as Month11, ");
            sQueryStringMaster.Append("sum(case When DayNo between 331 and 360 then DueAmount else 0 end) as Month12, ");
            sQueryStringMaster.Append("sum(case When DayNo >360 then DueAmount else 0 end) as MonthGT12  ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select customerid,InvoiceNO,invoicedate,convert(int,? -cast(convert(nvarchar(12),invoicedate,105)as DateTime)) as dayno,DueAmount ");
            sQueryStringMaster.Append("from t_salesInvoice   ");
            sQueryStringMaster.Append("where Invoicetypeid in (?,?,?,?) and invoicestatus not in (?) and DueAmount > 0 and invoicedate<= ? ");
            sQueryStringMaster.Append(") as a ");
            sQueryStringMaster.Append("Group By CustomerID ");
            sQueryStringMaster.Append(")as qq2 on qq1.Customerid = qq2.Customerid  ");
            sQueryStringMaster.Append("inner join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_CustomerDetails  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as qq3 on qq1.Customerid = qq3.CustomerID  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as FinalQuery   ");            
            sQueryStringMaster.Append("GROUP BY  ");
            sQueryStringMaster.Append("SBUID, SBUCode, SBUName  ");
            sQueryStringMaster.Append(",ChannelID, ChannelCode, ChannelDescription  ");
            sQueryStringMaster.Append(",AreaID, AreaCode, AreaName  ");
            sQueryStringMaster.Append(",TerritoryID, TerritoryCode, TerritoryName,CustomerTypeID, CustomerTypeName, IsActive  ");
            sQueryStringMaster.Append(",CustomerID, CustomerCode, CustomerName  ");
            sQueryStringMaster.Append("order by CustomerName ");

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.TransectionSide.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.TransectionSide.DEBIT);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));


            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            GetOutstandingAgeingCustomerWise(oCmd);

        }

        public void GetOutstandingAgeingCustomerWise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptOutssandingAgeingCustomerWise oItem = new RptOutssandingAgeingCustomerWise();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = (long)reader["SBUID"];
                    else oItem.SBUID = -1;

                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = -1;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = (int)reader["TerritoryID"];
                    else oItem.TerritoryID = -1;

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";

                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = (int)reader["CustomerTypeID"];
                    else oItem.CustomerTypeID = 0;

                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";

                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive = (int)reader["IsActive"];
                    else oItem.IsActive = 0;


                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["ClosingBalance"] != DBNull.Value)
                        oItem.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"]);
                    else oItem.ClosingBalance = 0;

                    if (reader["Month01"] != DBNull.Value)
                        oItem.Month01 = Convert.ToDouble(reader["Month01"]);
                    else oItem.Month01 = 0;

                    if (reader["Month02"] != DBNull.Value)
                        oItem.Month02 = Convert.ToDouble(reader["Month02"]);
                    else oItem.Month02 = 0;

                    if (reader["Month03"] != DBNull.Value)
                        oItem.Month03 = Convert.ToDouble(reader["Month03"]);
                    else oItem.Month03 = 0;

                    if (reader["Month04"] != DBNull.Value)
                        oItem.Month04 = Convert.ToDouble(reader["Month04"]);
                    else oItem.Month04 = 0;

                    if (reader["Month05"] != DBNull.Value)
                        oItem.Month05 = Convert.ToDouble(reader["Month05"]);
                    else oItem.Month05 = 0;

                    if (reader["Month06"] != DBNull.Value)
                        oItem.Month06 = Convert.ToDouble(reader["Month06"]);
                    else oItem.Month06 = 0;

                    if (reader["Month07"] != DBNull.Value)
                        oItem.Month07 = Convert.ToDouble(reader["Month07"]);
                    else oItem.Month07 = 0;

                    if (reader["Month08"] != DBNull.Value)
                        oItem.Month08 = Convert.ToDouble(reader["Month08"]);
                    else oItem.Month08 = 0;

                    if (reader["Month09"] != DBNull.Value)
                        oItem.Month09 = Convert.ToDouble(reader["Month09"]);
                    else oItem.Month09 = 0;

                    if (reader["Month10"] != DBNull.Value)
                        oItem.Month10 = Convert.ToDouble(reader["Month10"]);
                    else oItem.Month10 = 0;

                    if (reader["Month11"] != DBNull.Value)
                        oItem.Month11 = Convert.ToDouble(reader["Month11"]);
                    else oItem.Month11 = 0;

                    if (reader["Month12"] != DBNull.Value)
                        oItem.Month12 = Convert.ToDouble(reader["Month12"]);
                    else oItem.Month12 = 0;

                    if (reader["MonthGT12"] != DBNull.Value)
                        oItem.MonthGT12 = Convert.ToDouble(reader["MonthGT12"]);
                    else oItem.MonthGT12 = 0;                 
                    
                    InnerList.Add(oItem);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void FromDataSetOutstandingAgeingCust(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptOutssandingAgeingCustomerWise oRptOutssandingAgeingCustomerWise = new RptOutssandingAgeingCustomerWise();

                    oRptOutssandingAgeingCustomerWise.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oRptOutssandingAgeingCustomerWise.SBUCode = (string)oRow["SBUCode"];
                    oRptOutssandingAgeingCustomerWise.SBUName = (string)oRow["SBUName"];

                    oRptOutssandingAgeingCustomerWise.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oRptOutssandingAgeingCustomerWise.ChannelCode = (string)oRow["ChannelCode"];
                    oRptOutssandingAgeingCustomerWise.ChannelName = (string)oRow["ChannelName"];

                    oRptOutssandingAgeingCustomerWise.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oRptOutssandingAgeingCustomerWise.AreaCode = (string)oRow["AreaCode"];
                    oRptOutssandingAgeingCustomerWise.AreaName = (string)oRow["AreaName"];

                    oRptOutssandingAgeingCustomerWise.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oRptOutssandingAgeingCustomerWise.TerritoryCode = (string)oRow["TerritoryCode"];
                    oRptOutssandingAgeingCustomerWise.TerritoryName = (string)oRow["TerritoryName"];

                    oRptOutssandingAgeingCustomerWise.CustomerTypeID = Convert.ToInt32(oRow["CustomerTypeID"]);
                    oRptOutssandingAgeingCustomerWise.CustomerTypeName = (string)oRow["CustomerTypeName"];
                    oRptOutssandingAgeingCustomerWise.IsActive = Convert.ToInt32(oRow["IsActive"]);

                    oRptOutssandingAgeingCustomerWise.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oRptOutssandingAgeingCustomerWise.CustomerCode = (string)oRow["CustomerCode"];
                    oRptOutssandingAgeingCustomerWise.CustomerName = (string)oRow["CustomerName"];
                    
                    oRptOutssandingAgeingCustomerWise.ClosingBalance = Convert.ToDouble(oRow["ClosingBalance"]);
                    oRptOutssandingAgeingCustomerWise.Month01 = Convert.ToDouble(oRow["Month01"]);
                    oRptOutssandingAgeingCustomerWise.Month02 = Convert.ToDouble(oRow["Month02"]);
                    oRptOutssandingAgeingCustomerWise.Month03 = Convert.ToDouble(oRow["Month03"]);
                    oRptOutssandingAgeingCustomerWise.Month04 = Convert.ToDouble(oRow["Month04"]);
                    oRptOutssandingAgeingCustomerWise.Month05 = Convert.ToDouble(oRow["Month05"]);
                    oRptOutssandingAgeingCustomerWise.Month06 = Convert.ToDouble(oRow["Month06"]);
                    oRptOutssandingAgeingCustomerWise.Month07 = Convert.ToDouble(oRow["Month07"]);
                    oRptOutssandingAgeingCustomerWise.Month08 = Convert.ToDouble(oRow["Month08"]);
                    oRptOutssandingAgeingCustomerWise.Month09 = Convert.ToDouble(oRow["Month09"]);
                    oRptOutssandingAgeingCustomerWise.Month10 = Convert.ToDouble(oRow["Month10"]);
                    oRptOutssandingAgeingCustomerWise.Month11 = Convert.ToDouble(oRow["Month11"]);
                    oRptOutssandingAgeingCustomerWise.Month12 = Convert.ToDouble(oRow["Month12"]);
                    oRptOutssandingAgeingCustomerWise.MonthGT12 = Convert.ToDouble(oRow["MonthGT12"]);
                    
                    InnerList.Add(oRptOutssandingAgeingCustomerWise);
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
