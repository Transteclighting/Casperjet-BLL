// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana- ISA
// Date: Oct 22, 2014
// Time : 10:19 AM
// Description: Class for ReplaceClaimItem.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class DMSReplaceClaimItem
    {
        private int _nTranID;
        private int _nReplaceClaimID;
        private string _sSubClaimNumber;
        private int _nProductID;
        private int _nClaimedQty;
        private int _nReplacedQty;
        private double _NSP;
        private int _nCurrentStock;
        private int _nSubClaimStatus;
        private DateTime _dValidationDate;
        
        private long _nTopSheetID;

        private string _sReplaceClaimNo;
        private string _sProductCode;
        private string _sProductName;
        private int _nUserID;
        private int _nStatus;
        private int _nIsPrinted;
        private DateTime _dDeliveryDate;

        private string _sCustomerCode;
        private string _sCustomerName;
        private DateTime _dClaimDate;


        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        // <summary>
        // Get set property for ReplaceClaimID
        // </summary>
        public int ReplaceClaimID
        {
            get { return _nReplaceClaimID; }
            set { _nReplaceClaimID = value; }
        }
        
        // <summary>
        // Get set property for SubClaimNumber
        // </summary>
        public string SubClaimNumber
        {
            get { return _sSubClaimNumber; }
            set { _sSubClaimNumber = value.Trim(); }
        }

        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for ClaimedQty
        // </summary>
        public int ClaimedQty
        {
            get { return _nClaimedQty; }
            set { _nClaimedQty = value; }
        }

        // <summary>
        // Get set property for ReplacedQty
        // </summary>
        public int ReplacedQty
        {
            get { return _nReplacedQty; }
            set { _nReplacedQty = value; }
        }

        // <summary>
        // Get set property for NSP
        // </summary>
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }

        // <summary>
        // Get set property for SubClaimStatus
        // </summary>
        public int SubClaimStatus
        {
            get { return _nSubClaimStatus; }
            set { _nSubClaimStatus = value; }
        }

        // <summary>
        // Get set property for ValidationDate
        // </summary>
        public DateTime ValidationDate
        {
            get { return _dValidationDate; }
            set { _dValidationDate = value; }
        }


        // <summary>
        // Get set property for TopSheetID
        // </summary>
        public long TopSheetID
        {
            get { return _nTopSheetID; }
            set { _nTopSheetID = value; }
        }

        // <summary>
        // Get set property for ReplaceClaimNumber
        // </summary>
        public string ReplaceClaimNo
        {
            get { return _sReplaceClaimNo; }
            set { _sReplaceClaimNo = value.Trim(); }
        }
       
      
        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int IsPrinted
        {
            get { return _nIsPrinted; }
            set { _nIsPrinted = value; }
        }
        public DateTime DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public DateTime ClaimDate
        {
            get { return _dClaimDate; }
            set { _dClaimDate = value; }
        }


        public void Add()
        {
            int nMaxReplaceClaimID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ReplaceClaimID]) FROM t_ReplaceClaimItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxReplaceClaimID = 1;
                }
                else
                {
                    nMaxReplaceClaimID = Convert.ToInt32(maxID) + 1;
                }
                _nReplaceClaimID = nMaxReplaceClaimID;
                sSql = "INSERT INTO t_ReplaceClaimItem (ReplaceClaimID, SubClaimNumber, ProductID, ClaimedQty, ReplacedQty, NSP, SubClaimStatus, ValidationDate, TopSheetID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.Parameters.AddWithValue("SubClaimNumber", _sSubClaimNumber);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ClaimedQty", _nClaimedQty);
                cmd.Parameters.AddWithValue("ReplacedQty", _nReplacedQty);
                cmd.Parameters.AddWithValue("NSP", _NSP);
                cmd.Parameters.AddWithValue("SubClaimStatus", _nSubClaimStatus);
                cmd.Parameters.AddWithValue("ValidationDate", _dValidationDate);
                cmd.Parameters.AddWithValue("TopSheetID", _nTopSheetID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ReplaceClaimItem SET SubClaimNumber = ?, ProductID = ?, ClaimedQty = ?, ReplacedQty = ?, NSP = ?, SubClaimStatus = ?, ValidationDate = ?, TopSheetID = ? WHERE ReplaceClaimID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SubClaimNumber", _sSubClaimNumber);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ClaimedQty", _nClaimedQty);
                cmd.Parameters.AddWithValue("ReplacedQty", _nReplacedQty);
                cmd.Parameters.AddWithValue("NSP", _NSP);
                cmd.Parameters.AddWithValue("SubClaimStatus", _nSubClaimStatus);
                cmd.Parameters.AddWithValue("ValidationDate", _dValidationDate);
                cmd.Parameters.AddWithValue("TopSheetID", _nTopSheetID);

                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CheckStatus(int nReplaceClaimID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " select *  from t_ReplaceClaimDeliveryItem where ReplaceClaimID = ? ";
                cmd.Parameters.AddWithValue("ReplaceClaimID", nReplaceClaimID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nStatus= Convert.ToInt32(reader["Status"]);
                    _nReplaceClaimID = (int)reader["ReplaceClaimID"];
                                       
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public void Update(int nReplaceClaimID,int nStatus,int nIsPrinted)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE [t_ReplaceClaimDeliveryItem] SET Status = ?, IsPrinted = ?, DeliveryDate= ?  WHERE ReplaceClaimID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", nStatus);
                cmd.Parameters.AddWithValue("IsPrinted", nIsPrinted);
                cmd.Parameters.AddWithValue("DeliveryDate",null);
                cmd.Parameters.AddWithValue("ReplaceClaimID", nReplaceClaimID);
              

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateDelivery(int nReplaceClaimID, int nStatus, int nIsPrinted)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE [t_ReplaceClaimDeliveryItem] SET Status = ?, IsPrinted = ?, DeliveryDate= ?  WHERE ReplaceClaimID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", nStatus);
                cmd.Parameters.AddWithValue("IsPrinted", nIsPrinted);
                cmd.Parameters.AddWithValue("DeliveryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ReplaceClaimID", nReplaceClaimID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_WSProductStock  SET CurrentStock = CurrentStock- ? WHERE ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

               
                
                cmd.Parameters.AddWithValue("CurrentStock", _nReplacedQty);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ReplaceClaimItem WHERE [ReplaceClaimID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_ReplaceClaimItem where ReplaceClaimID =?";
                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nReplaceClaimID = (int)reader["ReplaceClaimID"];
                    _sSubClaimNumber = (string)reader["SubClaimNumber"];
                    _nProductID = (int)reader["ProductID"];
                    _nClaimedQty = (int)reader["ClaimedQty"];
                    _nReplacedQty = (int)reader["ReplacedQty"];
                    _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    _nSubClaimStatus = (int)reader["SubClaimStatus"];
                    _dValidationDate = Convert.ToDateTime(reader["ValidationDate"].ToString());
                    _nTopSheetID = Convert.ToInt64(reader["TopSheetID"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Insert(int nReplaceClaimID,string   sReplaceClaimNo, string  sSubClaimNo, int nCartonQty,string sRemarks,DateTime dTranDate,int nConfirmedUserID,int nStatus,int nIsPrinted)
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "INSERT INTO t_ReplaceClaimDeliveryItem VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimID", nReplaceClaimID);
                cmd.Parameters.AddWithValue("ReplaceClaimNo", sReplaceClaimNo);
                cmd.Parameters.AddWithValue("SubClaimNumber", sSubClaimNo);
                cmd.Parameters.AddWithValue("CartonQty", nCartonQty);
                cmd.Parameters.AddWithValue("Remarks", sRemarks);
                cmd.Parameters.AddWithValue("TranDate", dTranDate);
                cmd.Parameters.AddWithValue("ConfirmedUserID", nConfirmedUserID);
                cmd.Parameters.AddWithValue("Status", nStatus);
                cmd.Parameters.AddWithValue("IsPrinted", nIsPrinted);
                cmd.Parameters.AddWithValue("DeliveryDate", null);
                
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DMSReplaceClaimItems : CollectionBase
    {
        public DMSReplaceClaimItem this[int i]
        {
            get { return (DMSReplaceClaimItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSReplaceClaimItem oDMSReplaceClaimItem)
        {
            InnerList.Add(oDMSReplaceClaimItem);
        }
        public int GetIndex(int nReplaceClaimID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ReplaceClaimID == nReplaceClaimID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int nReplaceClaimID, string sSubClaimNumber)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"SELECT * FROM t_ReplaceClaimItem  as r
                            inner join
                            (
                            select ProductId,ProductCode,ProductName,ASGName,BrandDesc,UOMConversionFactor from v_ProductDetails
                            )as Pro on r.ProductID=Pro.ProductID  
                            where ReplaceClaimID = '" + nReplaceClaimID + "' and SubClaimNumber='" + sSubClaimNumber + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaimItem oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaimItem.SubClaimNumber = (string)reader["SubClaimNumber"];
                    oDMSReplaceClaimItem.ProductID = (int)reader["ProductID"];
                    oDMSReplaceClaimItem.ClaimedQty = (int)reader["ClaimedQty"];
                    if (reader["ReplacedQty"] != DBNull.Value)
                    oDMSReplaceClaimItem.ReplacedQty = (int)reader["ReplacedQty"];
                else oDMSReplaceClaimItem.ReplacedQty = 0;
                   
                    
                    //oDMSReplaceClaimItem.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    oDMSReplaceClaimItem.SubClaimStatus = (int)reader["SubClaimStatus"];
                   // oDMSReplaceClaimItem.ValidationDate = Convert.ToDateTime(reader["ValidationDate"].ToString());
                   // oDMSReplaceClaimItem.TopSheetID = Convert.ToInt64(reader["TopSheetID"].ToString());
                    oDMSReplaceClaimItem.ProductCode = (string)reader["ProductCode"];
                    oDMSReplaceClaimItem.ProductName = (string)reader["ProductName"];
                    InnerList.Add(oDMSReplaceClaimItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(int nReplaceClaimID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"SELECT * FROM t_ReplaceClaimItem  as r
                            inner join
                            (
                            select ProductId,ProductCode,ProductName,ASGName,BrandDesc,UOMConversionFactor from v_ProductDetails
                            )as Pro on r.ProductID=Pro.ProductID  
                            where ReplaceClaimID = '" + nReplaceClaimID + "'  ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaimItem oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaimItem.SubClaimNumber = (string)reader["SubClaimNumber"];
                    oDMSReplaceClaimItem.ProductID = (int)reader["ProductID"];
                    oDMSReplaceClaimItem.ClaimedQty = (int)reader["ClaimedQty"];
                    if (reader["ReplacedQty"] != DBNull.Value)
                        oDMSReplaceClaimItem.ReplacedQty = (int)reader["ReplacedQty"];
                    else oDMSReplaceClaimItem.ReplacedQty = 0;


                    //oDMSReplaceClaimItem.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    oDMSReplaceClaimItem.SubClaimStatus = (int)reader["SubClaimStatus"];
                    // oDMSReplaceClaimItem.ValidationDate = Convert.ToDateTime(reader["ValidationDate"].ToString());
                    // oDMSReplaceClaimItem.TopSheetID = Convert.ToInt64(reader["TopSheetID"].ToString());
                    oDMSReplaceClaimItem.ProductCode = (string)reader["ProductCode"];
                    oDMSReplaceClaimItem.ProductName = (string)reader["ProductName"];
                    InnerList.Add(oDMSReplaceClaimItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refreshes(DateTime dFromDate, DateTime dToDate, int nCustomerID)
        {
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

          // string sSql = @" select * from t_ReplaceClaimDeliveryItem where TranDate between '" + dFromDate + "' and  '" + dToDate + "'  ";
            if (nCustomerID < 0 )
            {

                sSql = " select a.*, ClaimDate,CustomerCode,CustomerName from t_ReplaceClaimDeliveryItem a, t_ReplaceClaim b, t_Customer c where TranDate between  '" + dFromDate + "' and  '" + dToDate + "' " +
                              " and a.ReplaceClaimID=b.ReplaceClaimID and b.CustomerID=c.CustomerID  ";

                
            }
            else
            {
                sSql = " select a.*,ClaimDate, CustomerCode,CustomerName from t_ReplaceClaimDeliveryItem a, t_ReplaceClaim b, t_Customer c where TranDate between  '" + dFromDate + "' and  '" + dToDate + "' " +
                             " and a.ReplaceClaimID=b.ReplaceClaimID and b.CustomerID=c.CustomerID  and b.CustomerID = '" + nCustomerID + "' ";

               
            }
        
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaimItem oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.TranID = (int)reader["TranID"];
                    oDMSReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaimItem.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oDMSReplaceClaimItem.SubClaimNumber = (string)reader["SubClaimNumber"];
                    oDMSReplaceClaimItem.Status = (int)reader["Status"];

                    if ((reader["DeliveryDate"]) != DBNull.Value )
                    {
                        oDMSReplaceClaimItem.DeliveryDate =Convert.ToDateTime(reader["DeliveryDate"]);

                    }
                    else oDMSReplaceClaimItem.DeliveryDate = Convert.ToDateTime("01-Jan-1990");
                    
                    oDMSReplaceClaimItem.CustomerCode = (string)reader["CustomerCode"];
                    oDMSReplaceClaimItem.CustomerName = (string)reader["CustomerName"];
                    oDMSReplaceClaimItem.ClaimDate = Convert.ToDateTime(reader["ClaimDate"]);
                                       
                    InnerList.Add(oDMSReplaceClaimItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetClaimNo()
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ReplaceClaim where EntryDate > '1-jun-2014' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaimItem.ReplaceClaimNo = reader["ReplaceClaimNo"].ToString();
                    InnerList.Add(oDMSReplaceClaimItem);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetClaimNoAll(DateTime dFromDate,DateTime dToDate,int nCustomerID)
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem;
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"SELECT distinct item.ReplaceClaimID, ReplaceClaimNo
                            FROM       t_ReplaceClaim 
                            INNER JOIN
                            t_ReplaceClaimItem as item ON t_ReplaceClaim.ReplaceClaimID = item.ReplaceClaimID
                            where EntryDate  between  '" + dFromDate + "' and '" + dToDate + "' and EntryDate < '" + dToDate + "' and CustomerID=" + nCustomerID + " and item.SubClaimNumber not in(select SubClaimNumber from t_ReplaceClaimDeliveryItem) ";
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaimItem.ReplaceClaimNo = reader["ReplaceClaimNo"].ToString();
                    InnerList.Add(oDMSReplaceClaimItem);
                }

                reader.Close();
                
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetClaimNoPrint(DateTime dFromDate, DateTime dToDate, int nCustomerID)
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem;
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ReplaceClaim where EntryDate  between  '" + dFromDate + "' and '" + dToDate + "' and EntryDate < '" + dToDate + "' and CustomerID=" + nCustomerID + "  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaimItem.ReplaceClaimNo = reader["ReplaceClaimNo"].ToString();
                    InnerList.Add(oDMSReplaceClaimItem);
                }

                reader.Close();

                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSubClaimNo(int nReplaceClaimID)
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select distinct SubClaimNumber from t_ReplaceClaimItem where ReplaceClaimID='" + nReplaceClaimID + "' and SubClaimNumber not in(select SubClaimNumber from t_ReplaceClaimDeliveryItem )  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.SubClaimNumber = reader["SubClaimNumber"].ToString();
                    InnerList.Add(oDMSReplaceClaimItem);
                }

                reader.Close();
                oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                
                oDMSReplaceClaimItem.SubClaimNumber = "ALL";
                InnerList.Add(oDMSReplaceClaimItem);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStatus(int nReplaceClaimID)
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select Status,IsPrinted from t_ReplaceClaimDeliveryItem where ReplaceClaimID='" + nReplaceClaimID + "' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.Status = (int)reader["Status"];
                    oDMSReplaceClaimItem.IsPrinted = (int)reader["IsPrinted"];
                    InnerList.Add(oDMSReplaceClaimItem);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckStock(int nReplaceClaimID, string sSubClaimNumber)
        {
            DMSReplaceClaimItem oDMSReplaceClaimItem;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;

            //string sSql = "  select ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,Q1.ProductID, NSP, isnull(Qty,0)as Qty, isnull(CurrentStock,0)as CurrentStock "
            //              + " from "
            //              + "  ( "
            //              + "  select a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP, sum(ClaimedQty)as Qty "
            //              + "  from t_ReplaceClaim a, t_ReplaceClaimItem b "
            //              + "  where a.ReplaceClaimID= ?  and SubClaimNumber= ? and a.ReplaceClaimID=b.ReplaceClaimID "
            //              + "  group by a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP "
            //              + "  )as Q1  "
            //              + "  left outer join  "
            //              + "  ( "
            //              + "  select ProductID,CurrentStock from t_WSProductStock "
            //              + "  ) as Q2 on Q1.ProductID=Q2.ProductID ";


            string sSql = "  select ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,Q1.ProductID, NSP, isnull(Qty,0)as Qty, isnull(CurrentStock,0)as CurrentStock "
                          + " from "
                          + "  ( "
                          + "  select a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP, sum(ClaimedQty)as Qty "
                          + "  from t_ReplaceClaim a, t_ReplaceClaimItem b "
                          + "  where a.ReplaceClaimID= ?  and SubClaimNumber= ? and a.ReplaceClaimID=b.ReplaceClaimID "
                          + "  group by a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP "
                          + "  )as Q1  "
                          + "  left outer join  "
                          + "  ( "
                          + "  select ProductID,CurrentStock from t_ReplaceClaimStock "
                          + "  ) as Q2 on Q1.ProductID=Q2.ProductID ";




            cmd.Parameters.AddWithValue("ReplaceClaimID", nReplaceClaimID);
            cmd.Parameters.AddWithValue("SubClaimNumber", sSubClaimNumber);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    
                    
                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ReplaceClaimID = Convert.ToInt32(reader["ReplaceClaimID"]);
                    oDMSReplaceClaimItem.ReplaceClaimNo = Convert.ToString(reader["ReplaceClaimNo"]);
                    oDMSReplaceClaimItem.SubClaimNumber = Convert.ToString(reader["SubClaimNumber"]);
                    oDMSReplaceClaimItem.ProductID = Convert.ToInt32(reader["ProductID"]);
                    oDMSReplaceClaimItem.ReplacedQty = Convert.ToInt32(reader["Qty"]);
                    oDMSReplaceClaimItem.CurrentStock = Convert.ToInt32(reader["CurrentStock"]);
                               
                    
                   
                    if (oDMSReplaceClaimItem.CurrentStock < oDMSReplaceClaimItem.ReplacedQty)
                    {
                       nCount++;
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;


        }

        public void RefreshStock(int nReplaceClaimID, string sSubClaimNumber)
        {
            

            //DMSReplaceClaimItem oDMSReplaceClaimItem;

            DMSReplaceClaimItem oDMSReplaceClaimItem = new DMSReplaceClaimItem();

            ReplaceClaimTran oReplaceClaimTran= new ReplaceClaimTran();
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;

            //string sSql = "  select ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,Q1.ProductID, NSP, isnull(Qty,0)as Qty, isnull(CurrentStock,0)as CurrentStock "
            //              + " from "
            //              + "  ( "
            //              + "  select a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP, sum(ClaimedQty)as Qty "
            //              + "  from t_ReplaceClaim a, t_ReplaceClaimItem b "
            //              + "  where a.ReplaceClaimID= ?  and SubClaimNumber= ? and a.ReplaceClaimID=b.ReplaceClaimID "
            //              + "  group by a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP "
            //              + "  )as Q1  "
            //              + "  left outer join  "
            //              + "  ( "
            //              + "  select ProductID,CurrentStock from t_WSProductStock "
            //              + "  ) as Q2 on Q1.ProductID=Q2.ProductID ";

            string sSql = "  select ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,Q1.ProductID, NSP, isnull(Qty,0)as Qty, isnull(CurrentStock,0)as CurrentStock "
                        + " from "
                        + "  ( "
                        + "  select a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP, sum(ClaimedQty)as Qty "
                        + "  from t_ReplaceClaim a, t_ReplaceClaimItem b "
                        + "  where a.ReplaceClaimID= ?  and SubClaimNumber= ? and a.ReplaceClaimID=b.ReplaceClaimID "
                        + "  group by a.ReplaceClaimID,ReplaceClaimNo,SubClaimNumber,ProductID, NSP "
                        + "  )as Q1  "
                        + "  left outer join  "
                        + "  ( "
                        + "  select ProductID,CurrentStock from t_ReplaceClaimStock "
                        + "  ) as Q2 on Q1.ProductID=Q2.ProductID ";




            cmd.Parameters.AddWithValue("ReplaceClaimID", nReplaceClaimID);
            cmd.Parameters.AddWithValue("SubClaimNumber", sSubClaimNumber);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oDMSReplaceClaimItem = new DMSReplaceClaimItem();
                    oDMSReplaceClaimItem.ProductID = (int)reader["ProductID"];
                    oDMSReplaceClaimItem.ClaimedQty = (int)reader["Qty"];
                    InnerList.Add(oDMSReplaceClaimItem);
                    
                    //ReplaceClaimTranItem oItem = new ReplaceClaimTranItem();
                    //oItem.ProductID = Convert.ToInt32(reader["ProductID"]);
                    //oItem.Quantity = Convert.ToInt32(reader["Qty"]);
                    //oItem.FGQty = Convert.ToInt32(reader["Qty"]);
                    //oReplaceClaimTran.Add(oItem); 
                    
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            


        }

        
    }
}

