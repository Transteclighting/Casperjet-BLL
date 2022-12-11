// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Sep 12, 2012
// Time : 11.00 AM
// Description: Class for Replace Claim 
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;

namespace CJ.Class
{
    public class ReplaceClaimItem
    {
        private int _ReplaceClaimID;
        private string _SubClaimNumber;
        private int _ProductID;
        private int _ClaimedQty;
        private int _ReplacedQty;
        private double _NSP;
        private int _SubClaimStatus;
        private DateTime _ValidationDate;
        private DateTime _TopSheetID;
        private string _sProductCode;
        private string _sProductName;
        private int _nFaultTypeID;
        public int FaultTypeID
        {
            get { return _nFaultTypeID; }
            set { _nFaultTypeID = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        private Product _oProduct;

        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                    _oProduct.ProductID = _ProductID;
                    _oProduct.RefreshByID();
                }
                return _oProduct;
            }
        }

        /// <summary>
        /// Get set property for ReplaceClaimID
        /// </summary>
        public int ReplaceClaimID
        {
            get { return _ReplaceClaimID; }
            set { _ReplaceClaimID = value; }
        }

        /// <summary>
        /// Get set property for SubClaimNumber
        /// </summary>
        public string SubClaimNumber
        {
            get { return _SubClaimNumber; }
            set { _SubClaimNumber = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        /// <summary>
        /// Get set property for ClaimedQty
        /// </summary>
        public int ClaimedQty
        {
            get { return _ClaimedQty; }
            set { _ClaimedQty = value; }
        }

        /// <summary>
        /// Get set property for ReplacedQty
        /// </summary>
        public int ReplacedQty
        {
            get { return _ReplacedQty; }
            set { _ReplacedQty = value; }
        }

        /// <summary>
        /// Get set property for NSP
        /// </summary>
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }

        /// <summary>
        /// Get set property for SubClaimStatus
        /// </summary>
        public int SubClaimStatus
        {
            get { return _SubClaimStatus; }
            set { _SubClaimStatus = value; }
        }

        /// <summary>
        /// Get set property for ValidationDate
        /// </summary>
        public DateTime ValidationDate
        {
            get { return _ValidationDate; }
            set { _ValidationDate = value; }
        }

        /// <summary>
        /// Get set property for TopSheetID
        /// </summary>
        public DateTime TopSheetID
        {
            get { return _TopSheetID; }
            set { _TopSheetID = value; }
        }

        public void InsertItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_ReplaceClaimItem (ReplaceClaimID, SubClaimNumber, ProductID, ClaimedQty, ReplacedQty, NSP, SubClaimStatus, ValidationDate, TopSheetID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimID", _ReplaceClaimID);
                cmd.Parameters.AddWithValue("SubClaimNumber", _SubClaimNumber);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("ClaimedQty", _ClaimedQty);
                cmd.Parameters.AddWithValue("ReplacedQty", null);
                cmd.Parameters.AddWithValue("NSP", _NSP);
                cmd.Parameters.AddWithValue("SubClaimStatus", _SubClaimStatus);
                cmd.Parameters.AddWithValue("ValidationDate", null);
                cmd.Parameters.AddWithValue("TopSheetID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddClaimAssessQuantity()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_ReplaceClaimAssessQuantity (ReplaceClaimID, SubClaimNumber, ProductID, FaultTypeID, Quantity) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimID", _ReplaceClaimID);
                cmd.Parameters.AddWithValue("SubClaimNumber", _SubClaimNumber);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("FaultTypeID", _nFaultTypeID);
                cmd.Parameters.AddWithValue("Quantity", _ClaimedQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class ReplaceClaim : CollectionBase
    {

        public ReplaceClaimItem this[int i]
        {
            get { return (ReplaceClaimItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ReplaceClaimItem oReplaceClaimItem)
        {
            InnerList.Add(oReplaceClaimItem);
        }

        private int _ReplaceClaimID;
        private string _ReplaceClaimNo;
        private string _ClaimedMonth;
        private object _ValidationDate;
        private DateTime _ReplacedDate;
        private int _ClaimStatus;
        private int _EntryUserID;
        private DateTime _EntryDate;
        private int _CustomerID;
        private int _ClaimPercentage;
        private int _TotalQtyForMonth;
        private int _ClaimYear;
        private int _TotalClaimQty;
        private DateTime _LastUpdateDate;
        private int _ApprovalTopSheetNo;
        private DateTime _ClaimDate;
        private string _sCustomerName;
        private int _nSubClaimStatus;
        private string _sUserName;
        private string _sMAGName;


        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }

        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public int SubClaimStatus
        {
            get { return _nSubClaimStatus; }
            set { _nSubClaimStatus = value; }
        }
        /// <summary>
        /// Get set property for ReplaceClaimID
        /// </summary>
        public int ReplaceClaimID
        {
            get { return _ReplaceClaimID; }
            set { _ReplaceClaimID = value; }
        }

        /// <summary>
        /// Get set property for ReplaceClaimNo
        /// </summary>
        public string ReplaceClaimNo
        {
            get { return _ReplaceClaimNo; }
            set { _ReplaceClaimNo = value.Trim(); }
        }
        private string _sSubClaimNo;
        public string SubClaimNo
        {
            get { return _sSubClaimNo; }
            set { _sSubClaimNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ClaimedMonth
        /// </summary>
        public string ClaimedMonth
        {
            get { return _ClaimedMonth; }
            set { _ClaimedMonth = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ValidationDate
        /// </summary>
        public object ValidationDate
        {
            get { return _ValidationDate; }
            set { _ValidationDate = value; }
        }

        /// <summary>
        /// Get set property for ReplacedDate
        /// </summary>
        public DateTime ReplacedDate
        {
            get { return _ReplacedDate; }
            set { _ReplacedDate = value; }
        }

        /// <summary>
        /// Get set property for ClaimStatus
        /// </summary>
        public int ClaimStatus
        {
            get { return _ClaimStatus; }
            set { _ClaimStatus = value; }
        }

        /// <summary>
        /// Get set property for EntryUserID
        /// </summary>
        public int EntryUserID
        {
            get { return _EntryUserID; }
            set { _EntryUserID = value; }
        }

        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        /// <summary>
        /// Get set property for ClaimPercentage
        /// </summary>
        public int ClaimPercentage
        {
            get { return _ClaimPercentage; }
            set { _ClaimPercentage = value; }
        }

        /// <summary>
        /// Get set property for TotalQtyForMonth
        /// </summary>
        public int TotalQtyForMonth
        {
            get { return _TotalQtyForMonth; }
            set { _TotalQtyForMonth = value; }
        }

        /// <summary>
        /// Get set property for ClaimYear
        /// </summary>
        public int ClaimYear
        {
            get { return _ClaimYear; }
            set { _ClaimYear = value; }
        }

        /// <summary>
        /// Get set property for TotalClaimQty
        /// </summary>
        public int TotalClaimQty
        {
            get { return _TotalClaimQty; }
            set { _TotalClaimQty = value; }
        }

        /// <summary>
        /// Get set property for LastUpdateDate
        /// </summary>
        public DateTime LastUpdateDate
        {
            get { return _LastUpdateDate; }
            set { _LastUpdateDate = value; }
        }

        /// <summary>
        /// Get set property for ApprovalTopSheetNo
        /// </summary>
        public int ApprovalTopSheetNo
        {
            get { return _ApprovalTopSheetNo; }
            set { _ApprovalTopSheetNo = value; }
        }

        /// <summary>
        /// Get set property for ClaimDate
        /// </summary>
        /// 

        public void InsertClaim()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_ReplaceClaimNoGenerator (ReplaceClaimNo, SubClaimNumber, ClaimNoStatus) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimNo", _ReplaceClaimNo);
                cmd.Parameters.AddWithValue("SubClaimNumber", _sSubClaimNo);
                cmd.Parameters.AddWithValue("ClaimNoStatus", _ClaimStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DateTime ClaimDate
        {
            get { return _ClaimDate; }
            set { _ClaimDate = value; }
        }

        public void RefreshItem()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_replaceclaimItem where ReplaceClaimID=? ";
            cmd.Parameters.AddWithValue("ReplaceClaimID", _ReplaceClaimID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaimItem oReplaceClaimItem = new ReplaceClaimItem();

                    oReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplaceClaimItem.ClaimedQty = (int)reader["ClaimedQty"];
                    oReplaceClaimItem.ProductID = (int)reader["ProductID"];

                    InnerList.Add(oReplaceClaimItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_replaceclaim where ReplaceClaimID=?";

            cmd.Parameters.AddWithValue("ReplaceClaimID", _ReplaceClaimID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    _CustomerID = (int)reader["CustomerID"];
                    _ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    _ClaimDate = (DateTime)reader["ClaimDate"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByClaimNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_replaceclaim where ReplaceClaimNo=?";

            cmd.Parameters.AddWithValue("ReplaceClaimNo", _ReplaceClaimNo);
         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    _CustomerID = (int)reader["CustomerID"];
                    _ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    _ClaimDate = (DateTime)reader["ClaimDate"];
                  
                }
                reader.Close();           
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckClaimIsInvoice()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ReplaceClaimTran where RefClaimID=? and TranTypeID=?";
            cmd.Parameters.AddWithValue("RefClaimID", _ReplaceClaimID);
            cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.ReplaceClaimStockTranType.INVOICE);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
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
        public void AddReplaceClaim(int MaxReplaceClaimID)
        {
            int nMaxReplaceClaimID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (MaxReplaceClaimID == 0)
                {
                    sSql = "SELECT MAX([ReplaceClaimID]) FROM t_ReplaceClaim";
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
                    _ReplaceClaimID = nMaxReplaceClaimID;



                    sSql = "INSERT INTO t_ReplaceClaim (ReplaceClaimID, ReplaceClaimNo, ClaimedMonth, ValidationDate, ReplacedDate, ClaimStatus, EntryUserID, EntryDate, CustomerID, ClaimPercentage, TotalQtyForMonth, ClaimYear, TotalClaimQty, LastUpdateDate, ApprovalTopSheetNo, ClaimDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ReplaceClaimID", _ReplaceClaimID);
                    cmd.Parameters.AddWithValue("ReplaceClaimNo", _ReplaceClaimNo);
                    cmd.Parameters.AddWithValue("ClaimedMonth", _ClaimedMonth);
                    cmd.Parameters.AddWithValue("ValidationDate", null);
                    cmd.Parameters.AddWithValue("ReplacedDate", null);
                    cmd.Parameters.AddWithValue("ClaimStatus", _ClaimStatus);
                    cmd.Parameters.AddWithValue("EntryUserID", _EntryUserID);
                    cmd.Parameters.AddWithValue("EntryDate", _EntryDate);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("ClaimPercentage", null);
                    cmd.Parameters.AddWithValue("TotalQtyForMonth", null);
                    cmd.Parameters.AddWithValue("ClaimYear", _ClaimYear);
                    cmd.Parameters.AddWithValue("TotalClaimQty", null);
                    cmd.Parameters.AddWithValue("LastUpdateDate", null);
                    cmd.Parameters.AddWithValue("ApprovalTopSheetNo", null);
                    cmd.Parameters.AddWithValue("ClaimDate", _ClaimDate);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                else
                {
                    _ReplaceClaimID = MaxReplaceClaimID;
                }
                foreach (ReplaceClaimItem oItem in this)
                {
                    oItem.ReplaceClaimID = _ReplaceClaimID;
                    oItem.InsertItem();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetClaimMAG(string sSubClaimNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT Right('" + sSubClaimNo + "', lEN('" + sSubClaimNo + "')-CHARINDEX('_','" + sSubClaimNo + "')) as MAGName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sMAGName = (string)reader["MAGName"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshClaimItem(string sSubClaimNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ReplaceClaimID,SubClaimNumber,a.ProductID, " +
                        "ProductCode,ProductName,ClaimedQty  " +
                        "From t_ReplaceClaimItem a,t_Product b " +
                        "where a.ProductID=b.ProductID and SubClaimNumber='" + sSubClaimNo + "'";

            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaimItem oReplaceClaimItem = new ReplaceClaimItem();

                    oReplaceClaimItem.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplaceClaimItem.SubClaimNumber = (string)reader["SubClaimNumber"];
                    oReplaceClaimItem.ProductID = (int)reader["ProductID"];
                    oReplaceClaimItem.ProductCode = (string)reader["ProductCode"];
                    oReplaceClaimItem.ProductName = (string)reader["ProductName"];
                    oReplaceClaimItem.ClaimedQty = (int)reader["ClaimedQty"];
                    

                    InnerList.Add(oReplaceClaimItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateClaimItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ReplaceClaimItem SET ValidationDate = ? WHERE SubClaimNumber = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ValidationDate", _ValidationDate);
                cmd.Parameters.AddWithValue("SubClaimNumber", _sSubClaimNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateClaimItemStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ReplaceClaimItem SET SubClaimStatus = ? WHERE SubClaimNumber = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SubClaimStatus", _nSubClaimStatus);
                cmd.Parameters.AddWithValue("SubClaimNumber", _sSubClaimNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateClaimNoStatusStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ReplaceClaimNoGenerator SET ClaimNoStatus = ? WHERE SubClaimNumber = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ClaimNoStatus", _nSubClaimStatus);
                cmd.Parameters.AddWithValue("SubClaimNumber", _sSubClaimNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class ReplaceClaims : CollectionBase
    {

        public ReplaceClaim this[int i]
        {
            get { return (ReplaceClaim)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ReplaceClaim oReplaceClaim)
        {
            InnerList.Add(oReplaceClaim);
        }

        public void RefreshForClaimTransfer(DateTime dtFromDate, DateTime dtToDate)
        {
            InnerList.Clear();
            dtToDate = dtToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_replaceclaim where claimdate between ? and ? and  claimdate < ? "
                          + " and replaceclaimid not in ( select RefClaimID from t_replaceclaimtran )";

            cmd.Parameters.AddWithValue("claimdate", dtFromDate);
            cmd.Parameters.AddWithValue("claimdate", dtToDate);
            cmd.Parameters.AddWithValue("claimdate", dtToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaim oReplaceClaim = new ReplaceClaim();

                    oReplaceClaim.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplaceClaim.CustomerID = (int)reader["CustomerID"];
                    oReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oReplaceClaim.ClaimDate = (DateTime)reader["ClaimDate"];
                    oReplaceClaim.RefreshItem();

                    InnerList.Add(oReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dtFromDate, DateTime dtToDate,string sClaimNo)
        {
            InnerList.Clear();
            dtToDate = dtToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_replaceclaim where claimdate between '"+dtFromDate+"' and '"+dtToDate+"' and  claimdate < '"+dtToDate+"' ";

            if (sClaimNo != "")
            {
                sSql = sSql + " and ReplaceClaimNo='" + sClaimNo + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaim oReplaceClaim = new ReplaceClaim();

                    oReplaceClaim.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplaceClaim.CustomerID = (int)reader["CustomerID"];
                    oReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oReplaceClaim.ClaimDate = (DateTime)reader["ClaimDate"];
                    oReplaceClaim.RefreshItem();

                    InnerList.Add(oReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSubClaim(string sClaimNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ReplaceClaimNoGenerator where ReplaceClaimNo='" + sClaimNo + "' and SubClaimNumber not in (Select SubClaimNumber From t_ReplaceClaimItem)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaim oReplaceClaim = new ReplaceClaim();

                    oReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oReplaceClaim.SubClaimNo = (string)reader["SubClaimNumber"];
                    InnerList.Add(oReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetSubClaimforCombo(string sClaimNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ReplaceClaimNoGenerator where ReplaceClaimNo like '%" + sClaimNo + "%'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaim oReplaceClaim = new ReplaceClaim();

                    oReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oReplaceClaim.SubClaimNo = (string)reader["SubClaimNumber"];
                    InnerList.Add(oReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshSubClaim(DateTime dFromDate, DateTime dToDate, string sClaimNo, string sSubClaimNo, string sCustomerCode, bool IsCheck, int nStatus)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select distinct a.ReplaceClaimID,ReplaceClaimNo,isnull(ClaimedMonth,'') ClaimedMonth, " +
                    "SubClaimNumber,ClaimDate,a.EntryDate,EntryUserID,a.CustomerID, " +
                    "'['+CustomerCode+']'+' '+CustomerName as CustomerName, " +
                    "b.ValidationDate,SubClaimStatus,UserName " +
                    "From t_ReplaceClaim a,t_ReplaceClaimItem b,v_CustomerDetails c,t_User d " +
                    "where a.ReplaceClaimID=b.ReplaceClaimID and a.CustomerID=c.CustomerID and a.EntryUserID=d.UserID ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and ClaimDate between '" + dFromDate + "' and '" + dToDate + "' and ClaimDate<'" + dToDate + "'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND SubClaimStatus=" + nStatus + "";
            }
            if (sClaimNo != "")
            {
                sSql = sSql + " AND ReplaceClaimNo like '%" + sClaimNo + "%'";
            }
            if (sSubClaimNo != "")
            {
                sSql = sSql + " AND SubClaimNumber like '%" + sSubClaimNo + "%'";
            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            sSql = sSql + " Order by a.ReplaceClaimID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaim oReplaceClaim = new ReplaceClaim();

                    oReplaceClaim.ReplaceClaimID = int.Parse(reader["ReplaceClaimID"].ToString());
                    oReplaceClaim.ReplaceClaimNo = (reader["ReplaceClaimNo"].ToString());
                    oReplaceClaim.SubClaimNo = (reader["SubClaimNumber"].ToString());
                    oReplaceClaim.ClaimedMonth = (reader["ClaimedMonth"].ToString());
                    oReplaceClaim.ClaimDate = Convert.ToDateTime(reader["ClaimDate"].ToString());
                    oReplaceClaim.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oReplaceClaim.EntryUserID = int.Parse(reader["EntryUserID"].ToString());
                    oReplaceClaim.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oReplaceClaim.CustomerName = (reader["CustomerName"].ToString());
                    if (reader["ValidationDate"] != DBNull.Value)
                        oReplaceClaim.ValidationDate = Convert.ToDateTime(reader["ValidationDate"].ToString());
                    else oReplaceClaim.ValidationDate = "";
                    oReplaceClaim.SubClaimStatus = int.Parse(reader["SubClaimStatus"].ToString());
                    oReplaceClaim.UserName = (reader["UserName"].ToString());



                    InnerList.Add(oReplaceClaim);

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


