// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Sept 13, 2011
// Time" :  03:10 PM
// Descriptio: Pending Invoice Status 
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
    public class PendingInvoiceStatus
    {
        private long _SBUID;
        private string _sSBUName;
        private int _nChannelID;
        private string _sChannelName;
        private int _nAreaID;
        private string _sAreaName;
        private int _nTerritoryID;
        private string _sTerritoryName;        
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sInvoiceNo;
        private DateTime _dInvoicedate;
        private double _InvoiceAmount;

        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }

        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID  ; }
            set { _nChannelID = value; }
        }
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
                   
        }
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
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
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _dInvoicedate; }
            set { _dInvoicedate = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
                
        }
    }

        public class PendingInvoiceStatusDetails : CollectionBaseCustom
        {
            public void Add(PendingInvoiceStatus oPendingInvoiceStatus)
            {
                this.List.Add(oPendingInvoiceStatus);
            }
            public PendingInvoiceStatus this[Int32 Index]
            {
                get
                {
                    return (PendingInvoiceStatus)this.List[Index];
                }
                set
                {
                    if (!(value.GetType().Equals(typeof(PendingInvoiceStatus))))
                    {
                        throw new Exception("Type can't be converted");
                    }
                    this.List[Index] = value;
                }
            }


            public void PendingInvoice()
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();
                StringBuilder sQueryStringMaster;
                sQueryStringMaster = new StringBuilder();
                sQueryStringMaster.Append(" Select SBUID,SBUName,ChannelID,ChannelDescription as ChannelName, AreaID,AreaName,TerritoryID,TerritoryName,CustomerCode,CustomerName,InvoiceNo, InvoiceDate, InvoiceAmount ");
                sQueryStringMaster.Append(" from t_salesinvoice a, v_customerdetails b " );
                sQueryStringMaster.Append(" where a.customerid = b.customerid and invoicestatus in (1,5,6) and invoicedate>= '03-Mar-2008' ");
                
                OleDbCommand oCmd = DBController.Instance.GetCommand();
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sQueryStringMaster.ToString();
                GetPendingInvoice(oCmd);       
        
            }

            public void GetPendingInvoice(OleDbCommand cmd)
            { 
                try
               {
                   IDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                        PendingInvoiceStatus oItem = new PendingInvoiceStatus();

                       if (reader["SBUID"] != DBNull.Value)
                           oItem.SBUID = (long)reader["SBUID"];
                       else oItem.SBUID = -1;

                       if (reader["SBUName"] != DBNull.Value)
                           oItem.SBUName = (string)reader["SBUName"];
                       else oItem.SBUName = "";

                       if (reader["ChannelID"] != DBNull.Value)
                           oItem.ChannelID = (int)reader["ChannelID"];
                       else oItem.ChannelID = -1;
                       
                       if (reader["ChannelName"] != DBNull.Value)
                           oItem.ChannelName = (string)reader["ChannelName"];
                       else oItem.ChannelName = "";

                       if (reader["AreaID"] != DBNull.Value)
                           oItem.AreaID = (int)reader["AreaID"];
                       else oItem.AreaID = -1;
                       
                       if (reader["AreaName"] != DBNull.Value)
                           oItem.AreaName = (string)reader["AreaName"];
                       else oItem.AreaName = "";

                       if (reader["TerritoryID"] != DBNull.Value)
                           oItem.TerritoryID = (int)reader["TerritoryID"];
                       else oItem.TerritoryID = -1; 
                       
                       if (reader["TerritoryName"] != DBNull.Value)
                           oItem.TerritoryName = (string)reader["TerritoryName"];
                       else oItem.TerritoryName = "";

                       if (reader["CustomerCode"] != DBNull.Value)
                           oItem.CustomerCode = (string)reader["CustomerCode"];
                       else oItem.CustomerCode = "";

                       if (reader["CustomerName"] != DBNull.Value)
                           oItem.CustomerName = (string)reader["CustomerName"];
                       else oItem.CustomerName = "";

                       if (reader["InvoiceNo"] != DBNull.Value)
                           oItem.InvoiceNo = (string)reader["InvoiceNo"];
                       else oItem.InvoiceNo = "";

                       if (reader["InvoiceDate"] != DBNull.Value)
                           oItem.InvoiceDate = Convert.ToDateTime (reader["InvoiceDate"]);
                       else oItem.InvoiceDate = Convert.ToDateTime("01-Jan-1980");

                       if (reader["InvoiceAmount"] != DBNull.Value)
                           oItem.InvoiceAmount = (double)reader["InvoiceAmount"];
                       else oItem.InvoiceAmount = -1;

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

            public void FromDataSetPendingInvoice(DataSet oDS)
            { 
              InnerList.Clear();
              try
                {
                    foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                    {
                      PendingInvoiceStatus oPendingInvoiceStatus = new PendingInvoiceStatus();
                      //oChannelASGwiseProfitability.SBUID = Convert.ToInt32(oRow["SBUID"]); 
                      
                      oPendingInvoiceStatus.SBUID = Convert.ToInt32(oRow["SBUID"]);
                      oPendingInvoiceStatus.SBUName = (string)oRow["SBUName"];
                      oPendingInvoiceStatus.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                      oPendingInvoiceStatus.ChannelName = (string)oRow["ChannelName"];
                      oPendingInvoiceStatus.AreaID = Convert.ToInt32(oRow["AreaID"]);
                      oPendingInvoiceStatus.AreaName = (string)oRow["AreaName"];
                      oPendingInvoiceStatus.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                      oPendingInvoiceStatus.TerritoryName = (string)oRow["TerritoryName"];
                      oPendingInvoiceStatus.CustomerCode = (string)oRow["CustomerCode"];
                      oPendingInvoiceStatus.CustomerName = (string)oRow["CustomerName"];
                      oPendingInvoiceStatus.InvoiceNo = (string)oRow["InvoiceNo"];
                      oPendingInvoiceStatus.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"]);
                      oPendingInvoiceStatus.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"]);
                      
                      InnerList.Add(oPendingInvoiceStatus); 
                                                
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
