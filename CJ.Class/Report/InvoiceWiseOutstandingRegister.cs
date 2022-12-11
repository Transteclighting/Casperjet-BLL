// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Feb 22, 2012
// Time :  04:40 PM
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
    public class InvoiceWiseOutstandingRegister
    {
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private double _DueAmount;
        private double _InvoiceAmount;
        private string _sSundryCustomerName;
        private string _sTerritoryCode;
        private string _sTerritoryName;
        private string _sChannelCode;
        private string _sChannelName;
        private string _sAreaCode;
        private string _sAreaName;
        public int _nSBUID;
        public int _nChannelId;
        public int _nAreaId;
        public int _nTerritoryId;

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
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }

        }
        public string SundryCustomerName
        {
            get { return _sSundryCustomerName; }
            set { _sSundryCustomerName = value; }
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
        public string ChannelCode
        {
            get { return _sChannelCode; }
            set { _sChannelCode = value; }
        }
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
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
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }

        }
        public double DueAmount
        {
            get { return _DueAmount; }
            set { _DueAmount = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        public int ChannelId
        {
            get { return _nChannelId; }
            set { _nChannelId = value; }
        }
        public int AreaId
        {
            get { return _nAreaId; }
            set { _nAreaId = value; }
        }
        public int TerritoryId
        {
            get { return _nTerritoryId; }
            set { _nTerritoryId = value; }
        }
    }
    public class InvoiceWiseOutstandingRegisterReport : CollectionBaseCustom
    {

        public void Add(InvoiceWiseOutstandingRegister oInvoiceWiseOutstandingRegister)
        {
            this.List.Add(oInvoiceWiseOutstandingRegister);
        }
        public InvoiceWiseOutstandingRegister this[Int32 Index]
        {
            get
            {
                return (InvoiceWiseOutstandingRegister)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(InvoiceWiseOutstandingRegister))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>   
        public void InvoiceWiseOutstandingRegister()
        {
           
            // InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd.CommandText = " select " +
                            " q1.*,q2.SundryCustomerName   from " +
                            " ( " +
                            " select p1.*, p2.CustomerCode, p2.CustomerName, p2.ParentCustomerCode, P2.ParentCustomerName,P2.SBUID, P2.SBUCode, P2.SBUName, P2.ChannelID, P2.ChannelCode, P2.ChannelDescription as ChannelName,P2.AreaID, P2.AreaCode, P2.AreaName, P2.TerritoryID, P2.TerritoryCode, P2.TerritoryName from t_salesInvoice p1,  v_CustomerDetails p2 where p1.CustomerID = p2.CustomerID and  InvoiceTypeID in (?,?,?,?) and DueAmount > 0 and InvoiceStatus not in (?) " +
                            " ) " +
                            " as q1 " +
                            " left outer join " +
                            " ( " +
                            " select  oh.invoiceno, sc.CustomerName as SundryCustomerName " +
                            " from orderhistory oh, SundryCustomerAddress sc  " +
                            " where oh.SundryCustomerID = sc.customerid " +
                            " UNION ALL " +
                            " select  oh.invoiceno, sc.CustomerName as SundryCustomerName " +
                            " from [order] oh, SundryCustomerAddress sc  " +
                            " where oh.SundryCustomerID = sc.customerid " +
                            " ) " +
                            " as q2 " +
                            " on q1.Invoiceno = q2.invoiceno " +
                            " order by q1.InvoiceDate ";



            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);

            cmd.Parameters.AddWithValue("InvoiceStaus", (short)Dictionary.InvoiceStatus.CANCEL);


            GetInvoiceWiseOutstandingRegister(cmd);

        }
        private void GetInvoiceWiseOutstandingRegister(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceWiseOutstandingRegister oItem = new InvoiceWiseOutstandingRegister();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;
                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = (int)reader["ChannelID"];
                    else oItem.ChannelId = -1;
                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";  
                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";
                    if (reader["AreaId"] != DBNull.Value)
                        oItem.AreaId = (int)reader["AreaId"];
                    else oItem.AreaId = -1;
                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";      
                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";
                    if (reader["TerritoryId"] != DBNull.Value)
                        oItem.TerritoryId = (int)reader["TerritoryId"];
                    else oItem.TerritoryId = -1;
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";  
                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";                  
                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";
                    if (reader["SundryCustomerName"] != DBNull.Value)
                        oItem.SundryCustomerName = (string)reader["SundryCustomerName"];
                    else oItem.SundryCustomerName = "No Sundry Customer Information";
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else oItem.InvoiceAmount = 0;
                    if (reader["DueAmount"] != DBNull.Value)
                        oItem.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else oItem.DueAmount = 0;
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oItem.InvoiceNo = (string)reader["InvoiceNo"];
                    else oItem.InvoiceNo = "";
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = Convert.ToDateTime( reader["InvoiceDate"]);
                    else oItem.InvoiceDate = DateTime.Today.Date;


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
        public void FromDataSetForInvoiceWiseOutstandingRegister(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    InvoiceWiseOutstandingRegister oInvoiceWiseOutstandingRegister = new InvoiceWiseOutstandingRegister();

                    oInvoiceWiseOutstandingRegister.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oInvoiceWiseOutstandingRegister.ChannelId = (int)oRow["ChannelID"];
                    oInvoiceWiseOutstandingRegister.AreaId = (int)oRow["TerritoryId"];
                    oInvoiceWiseOutstandingRegister.TerritoryId = (int)oRow["AreaId"];
                    oInvoiceWiseOutstandingRegister.ChannelName = (string)oRow["ChannelName"];
                    oInvoiceWiseOutstandingRegister.ChannelCode = (string)oRow["ChannelCode"];
                    oInvoiceWiseOutstandingRegister.AreaName = (string)oRow["AreaName"];
                    oInvoiceWiseOutstandingRegister.AreaCode = (string)oRow["AreaCode"];
                    oInvoiceWiseOutstandingRegister.TerritoryName = (string)oRow["TerritoryName"];
                    oInvoiceWiseOutstandingRegister.TerritoryCode = (string)oRow["TerritoryCode"];
                    oInvoiceWiseOutstandingRegister.CustomerCode = (string)oRow["CustomerCode"];
                    oInvoiceWiseOutstandingRegister.CustomerName = (string)oRow["CustomerName"];
                    oInvoiceWiseOutstandingRegister.SundryCustomerName = (string)oRow["SundryCustomerName"];
                    oInvoiceWiseOutstandingRegister.InvoiceNo = (string)oRow["InvoiceNo"];
                    oInvoiceWiseOutstandingRegister.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"]);
                    oInvoiceWiseOutstandingRegister.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"]);
                    oInvoiceWiseOutstandingRegister.DueAmount = Convert.ToDouble(oRow["DueAmount"]);

                    InnerList.Add(oInvoiceWiseOutstandingRegister);
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
