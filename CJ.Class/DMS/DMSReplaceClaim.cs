// <summary>
// Company: Transcom Electronics Limited
// Author: Akif Ahmed
// Date: Apr 04, 2019
// Time : 05:49 PM
// Description: Class for DMSReplaceClaim.
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
    public class DMSReplaceClaim
    {
        private int _nReplaceClaimID;
        private string _sReplaceClaimNo;
        private DateTime _dClaimedForMonth;
        private int _nClaimStatus;
        private DateTime _dEntryDate;
        private int _nCustomerID;
        private bool _bIsApproved;
        private int _nApproverID;


        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private string _sCustomerCode;
        private string _sCustomerName;
        private double _ClaimAmount;


        private int _nTranID;
        private DateTime _dClaimMonth;
        private double _Amount;
        private double _EligibleAmount;
        private DateTime _dLogisticRecDate;
        private int _nLogisticUserID;
        private DateTime _dReplacementRecDate;
        private int _nReplacementUserID;
        private DateTime _dApprovalDate;
        private int _nApprovedUserID;
        private DateTime _dDeliveryDate;
        private int _nDeliveryUserID;


        private string _sStatus;


        private string _sLogisticDate;
        private string _sReplacementDate;
        private string _sApproveDate;
        private string _sDeliverDate;
        private string _sClaimDate;


        private int _nClaimedQty;
        private double _ClaimedValue;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private int _nMAGID;
        private string _sMAGName;
        private int _nASGID;
        private string _sASGName;
        private double _NSP;
        private int _nElligibleQty;
        private double _ElligibleValue;
        private string _sIsAssessed;
        private int _nEligibleTotal;
        private int _nOtherBrand;
        private int _nOKLamp;
        private int _nLifeOver;
        private int _nBrokenLamp;
        private int _nNoCarton;
        private int _nTempLamp;
        private int _nExpireWarranty;
        private int _nGoodCondition;
        private int _nNotEligibleTotal;
        private double _EligibleTotalValue;
        private double _NotEligibleTotalValue;





        // <summary>
        // Get set property for ReplaceClaimID
        // </summary>
        public int ReplaceClaimID
        {
            get { return _nReplaceClaimID; }
            set { _nReplaceClaimID = value; }
        }

        // <summary>
        // Get set property for ReplaceClaimNo
        // </summary>
        public string ReplaceClaimNo
        {
            get { return _sReplaceClaimNo; }
            set { _sReplaceClaimNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ClaimedForMonth
        // </summary>
        public DateTime ClaimedForMonth
        {
            get { return _dClaimedForMonth; }
            set { _dClaimedForMonth = value; }
        }

        // <summary>
        // Get set property for ClaimStatus
        // </summary>
        public int ClaimStatus
        {
            get { return _nClaimStatus; }
            set { _nClaimStatus = value; }
        }

        // <summary>
        // Get set property for EntryDate
        // </summary>
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for IsApproved
        // </summary>
        public bool IsApproved
        {
            get { return _bIsApproved; }
            set { _bIsApproved = value; }
        }

        // <summary>
        // Get set property for ApproverID
        // </summary>
        public int ApproverID
        {
            get { return _nApproverID; }
            set { _nApproverID = value; }
        }

        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        // <summary>
        // Get set property for ClaimMonth
        // </summary>
        public DateTime ClaimMonth
        {
            get { return _dClaimMonth; }
            set { _dClaimMonth = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for EligibleAmount
        // </summary>
        public double EligibleAmount
        {
            get { return _EligibleAmount; }
            set { _EligibleAmount = value; }
        }

        // <summary>
        // Get set property for LogisticRecDate
        // </summary>
        public DateTime LogisticRecDate
        {
            get { return _dLogisticRecDate; }
            set { _dLogisticRecDate = value; }
        }

        // <summary>
        // Get set property for LogisticUserID
        // </summary>
        public int LogisticUserID
        {
            get { return _nLogisticUserID; }
            set { _nLogisticUserID = value; }
        }

        // <summary>
        // Get set property for ReplacementRecDate
        // </summary>
        public DateTime ReplacementRecDate
        {
            get { return _dReplacementRecDate; }
            set { _dReplacementRecDate = value; }
        }

        // <summary>
        // Get set property for ReplacementUserID
        // </summary>
        public int ReplacementUserID
        {
            get { return _nReplacementUserID; }
            set { _nReplacementUserID = value; }
        }

        // <summary>
        // Get set property for ApprovalDate
        // </summary>
        public DateTime ApprovalDate
        {
            get { return _dApprovalDate; }
            set { _dApprovalDate = value; }
        }

        // <summary>
        // Get set property for ApprovedUserID
        // </summary>
        public int ApprovedUserID
        {
            get { return _nApprovedUserID; }
            set { _nApprovedUserID = value; }
        }

        // <summary>
        // Get set property for DeliveryDate
        // </summary>
        public DateTime DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }

        // <summary>
        // Get set property for DeliveryUserID
        // </summary>
        public int DeliveryUserID
        {
            get { return _nDeliveryUserID; }
            set { _nDeliveryUserID = value; }
        }




        public string RegionName
        {
            get { return _sRegionName; }
            set { _sRegionName = value.Trim(); }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
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
        public double ClaimAmount
        {
            get { return _ClaimAmount; }
            set { _ClaimAmount = value; }

        }
        // <summary>
        // Get set property for Status
        // </summary>
        public string Status
        {
            get { return _sStatus; }
            set { _sStatus = value.Trim(); }
        }



        public string LogisticDate
        {
            get { return _sLogisticDate; }
            set { _sLogisticDate = value.Trim(); }
        }
        public string ReplacementDate
        {
            get { return _sReplacementDate; }
            set { _sReplacementDate = value.Trim(); }
        }
        public string ApproveDate
        {
            get { return _sApproveDate; }
            set { _sApproveDate = value.Trim(); }
        }
        public string DeliverDate
        {
            get { return _sDeliverDate; }
            set { _sDeliverDate = value.Trim(); }
        }
        public string ClaimDate
        {
            get { return _sClaimDate; }
            set { _sClaimDate = value.Trim(); }
        }
        public double ClaimedValue
        {
            get { return _ClaimedValue; }
            set { _ClaimedValue = value; }

        }
        public int ClaimedQty
        {
            get { return _nClaimedQty; }
            set { _nClaimedQty = value; }

        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }

        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }

        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }

        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }

        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }

        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }

        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }

        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }

        }
        public int ElligibleQty
        {
            get { return _nElligibleQty; }
            set { _nElligibleQty = value; }

        }
        public double ElligibleValue
        {
            get { return _ElligibleValue; }
            set { _ElligibleValue = value; }

        }
        public string IsAssessed
        {
            get { return _sIsAssessed; }
            set { _sIsAssessed = value; }

        }
        
        public int EligibleTotal
        {
            get { return _nEligibleTotal; }
            set { _nEligibleTotal = value; }

        }
        public int OtherBrand
        {
            get { return _nOtherBrand; }
            set { _nOtherBrand = value; }

        }
        public int OKLamp
        {
            get { return _nOKLamp; }
            set { _nOKLamp = value; }

        }
        public int LifeOver
        {
            get { return _nLifeOver; }
            set { _nLifeOver = value; }

        }
        public int BrokenLamp
        {
            get { return _nBrokenLamp; }
            set { _nBrokenLamp = value; }

        }
        public int NoCarton
        {
            get { return _nNoCarton; }
            set { _nNoCarton = value; }

        }
        public int TempLamp
        {
            get { return _nTempLamp; }
            set { _nTempLamp = value; }

        }
        public int ExpireWarranty
        {
            get { return _nExpireWarranty; }
            set { _nExpireWarranty = value; }

        }
        public int GoodCondition
        {
            get { return _nGoodCondition; }
            set { _nGoodCondition = value; }

        }
        public int NotEligibleTotal
        {
            get { return _nNotEligibleTotal; }
            set { _nNotEligibleTotal = value; }

        }
        public double EligibleTotalValue
        {
            get { return _EligibleTotalValue; }
            set { _EligibleTotalValue = value; }
        }
        public double NotEligibleTotalValue
        {
            get { return _NotEligibleTotalValue; }
            set { _NotEligibleTotalValue = value; }
        }
        public void Add()
        {
            int nMaxReplaceClaimID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ReplaceClaimID]) FROM t_DMSReplaceClaim";
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
                sSql = "INSERT INTO t_DMSReplaceClaim (ReplaceClaimID, ReplaceClaimNo, ClaimedForMonth, ClaimStatus, EntryDate, CustomerID, IsApproved, ApproverID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.Parameters.AddWithValue("ReplaceClaimNo", _sReplaceClaimNo);
                cmd.Parameters.AddWithValue("ClaimedForMonth", _dClaimedForMonth);
                cmd.Parameters.AddWithValue("ClaimStatus", _nClaimStatus);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("IsApproved", _bIsApproved);
                cmd.Parameters.AddWithValue("ApproverID", _nApproverID);

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
                sSql = "UPDATE t_DMSReplaceClaim SET ReplaceClaimNo = ?, ClaimedForMonth = ?, ClaimStatus = ?, EntryDate = ?, CustomerID = ?, IsApproved = ?, ApproverID = ? WHERE ReplaceClaimID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimNo", _sReplaceClaimNo);
                cmd.Parameters.AddWithValue("ClaimedForMonth", _dClaimedForMonth);
                cmd.Parameters.AddWithValue("ClaimStatus", _nClaimStatus);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("IsApproved", _bIsApproved);
                cmd.Parameters.AddWithValue("ApproverID", _nApproverID);

                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);

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
                sSql = "DELETE FROM t_DMSReplaceClaim WHERE [ReplaceClaimID]=?";
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
                cmd.CommandText = "SELECT * FROM t_DMSReplaceClaim where ReplaceClaimID =?";
                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nReplaceClaimID = (int)reader["ReplaceClaimID"];
                    _sReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    _dClaimedForMonth = Convert.ToDateTime(reader["ClaimedForMonth"].ToString());
                    _nClaimStatus = (int)reader["ClaimStatus"];
                    _dEntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    _nCustomerID = (int)reader["CustomerID"];
                    _bIsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    _nApproverID = (int)reader["ApproverID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddToStatus()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ReplacementStatus";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;
                //sSql = "INSERT INTO t_ReplacementStatus (TranID, ReplaceClaimID, CustomerID, ClaimMonth, Amount, EligibleAmount, LogisticRecDate, LogisticUserID, ReplacementRecDate, ReplacementUserID, ApprovalDate, ApprovedUserID, DeliveryDate, DeliveryUserID) VALUES("+TranID+","+ReplaceClaimID+","+ CustomerID + ",'"+ClaimMonth+"',"+ Amount + ","+ EligibleAmount + ",'"+ LogisticRecDate + "',"+ LogisticUserID + ",'"+ ReplacementRecDate + "',"+ ReplacementUserID + ",'"+ ApprovalDate + "',"+ ApprovedUserID + ",'"+ DeliveryDate + "'y,"+ DeliveryUserID + ")";
                sSql = "INSERT INTO t_ReplacementStatus (TranID, ReplaceClaimID, CustomerID, ClaimMonth, Amount, EligibleAmount, LogisticRecDate, LogisticUserID, ReplacementRecDate, ReplacementUserID, ApprovalDate, ApprovedUserID, DeliveryDate, DeliveryUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ClaimMonth", _dClaimMonth);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("EligibleAmount", _EligibleAmount);
                if (!(_dLogisticRecDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("LogisticRecDate", _dLogisticRecDate);
                else
                {
                    cmd.Parameters.AddWithValue("LogisticRecDate", null);
                }
                cmd.Parameters.AddWithValue("LogisticUserID", _nLogisticUserID);
                if (!(_dReplacementRecDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("ReplacementRecDate", _dReplacementRecDate);
                else
                {
                    cmd.Parameters.AddWithValue("ReplacementRecDate", null);
                }
                cmd.Parameters.AddWithValue("ReplacementUserID", _nReplacementUserID);
                if (!(_dApprovalDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("ApprovalDate", _dApprovalDate);
                else
                {
                    cmd.Parameters.AddWithValue("ApprovalDate", null);
                }
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                if (!(_dDeliveryDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                else
                {
                    cmd.Parameters.AddWithValue("DeliveryDate", null);
                }
                cmd.Parameters.AddWithValue("DeliveryUserID", _nDeliveryUserID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditToStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ReplacementStatus SET ReplaceClaimID = ?, CustomerID = ?, ClaimMonth = ?, Amount = ?, EligibleAmount = ?, LogisticRecDate = ?, LogisticUserID = ?, ReplacementRecDate = ?, ReplacementUserID = ?, ApprovalDate = ?, ApprovedUserID = ?, DeliveryDate = ?, DeliveryUserID = ? WHERE TranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ClaimMonth", _dClaimMonth);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("EligibleAmount", _EligibleAmount);
                if (!(_dLogisticRecDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("LogisticRecDate", _dLogisticRecDate);
                else
                    cmd.Parameters.AddWithValue("LogisticRecDate", null);
                cmd.Parameters.AddWithValue("LogisticUserID", _nLogisticUserID);
                if (!(_dReplacementRecDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("ReplacementRecDate", _dReplacementRecDate);
                else
                    cmd.Parameters.AddWithValue("ReplacementRecDate", null);
                cmd.Parameters.AddWithValue("ReplacementUserID", _nReplacementUserID);
                if (!(_dApprovalDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("ApprovalDate", _dApprovalDate);
                else
                    cmd.Parameters.AddWithValue("ApprovalDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                if (!(_dDeliveryDate == default(DateTime)))
                    cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                else
                    cmd.Parameters.AddWithValue("DeliveryDate", null);
                cmd.Parameters.AddWithValue("DeliveryUserID", _nDeliveryUserID);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteToStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ReplacementStatus WHERE [TranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshToStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_ReplacementStatus where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _nReplaceClaimID = (int)reader["ReplaceClaimID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _dClaimMonth = Convert.ToDateTime(reader["ClaimMonth"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _EligibleAmount = Convert.ToDouble(reader["EligibleAmount"].ToString());
                    _dLogisticRecDate = Convert.ToDateTime(reader["LogisticRecDate"].ToString());
                    _nLogisticUserID = (int)reader["LogisticUserID"];
                    _dReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                    _nReplacementUserID = (int)reader["ReplacementUserID"];
                    _dApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                    _nApprovedUserID = (int)reader["ApprovedUserID"];
                    _dDeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    _nDeliveryUserID = (int)reader["DeliveryUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void editDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DMSReplaceClaim SET ClaimedForMonth = ? WHERE ReplaceClaimID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ClaimedForMonth", _dClaimedForMonth);

                cmd.Parameters.AddWithValue("ReplaceClaimID", _nReplaceClaimID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DMSReplaceClaim getStatusByReplaceClaimID(int ReplaceClaimID)
        {
            List<DMSReplaceClaim> list = new List<DMSReplaceClaim>();
            if(!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_ReplacementStatus where ReplaceClaimID ="+ReplaceClaimID;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaim oReplacementStatus = new DMSReplaceClaim();
                    oReplacementStatus.TranID = (int)reader["TranID"];
                    oReplacementStatus.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplacementStatus.CustomerID = (int)reader["CustomerID"];
                    if (!reader.IsDBNull(3))
                        oReplacementStatus.ClaimMonth = Convert.ToDateTime(reader["ClaimMonth"].ToString());
                    else
                        oReplacementStatus.ClaimMonth = default(DateTime);
                    if (!reader.IsDBNull(4))
                        oReplacementStatus.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else
                        oReplacementStatus.Amount = 0;
                    if (!reader.IsDBNull(5))
                        oReplacementStatus.EligibleAmount = Convert.ToDouble(reader["EligibleAmount"].ToString());
                    else
                        oReplacementStatus.EligibleAmount = 0;
                    if (!reader.IsDBNull(6))
                        oReplacementStatus.LogisticRecDate = Convert.ToDateTime(reader["LogisticRecDate"].ToString());
                    else
                        oReplacementStatus.LogisticRecDate = default(DateTime);
                    if (!reader.IsDBNull(7))
                        oReplacementStatus.LogisticUserID = (int)reader["LogisticUserID"];
                    else
                        oReplacementStatus.LogisticUserID = 0;
                    if (!reader.IsDBNull(8))
                        oReplacementStatus.ReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                    else
                        oReplacementStatus.ReplacementRecDate = default(DateTime);
                    if (!reader.IsDBNull(9))
                        oReplacementStatus.ReplacementUserID = (int)reader["ReplacementUserID"];
                    else
                        oReplacementStatus.ReplacementUserID = 0;
                    if (!reader.IsDBNull(10))
                        oReplacementStatus.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                    else
                        oReplacementStatus.ApprovalDate = default(DateTime);
                    if (!reader.IsDBNull(11))
                        oReplacementStatus.ApprovedUserID = (int)reader["ApprovedUserID"];
                    else
                        oReplacementStatus.ApprovedUserID = 0;
                    if (!reader.IsDBNull(12))
                        oReplacementStatus.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else
                        oReplacementStatus.DeliveryDate = default(DateTime);
                    if (!reader.IsDBNull(13))
                        oReplacementStatus.DeliveryUserID = (int)reader["DeliveryUserID"];
                    else
                        oReplacementStatus.DeliveryUserID = 0;
                    list.Add(oReplacementStatus);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if(list.Count>0)
                return list[0];
            else
                return null;
        }
    }
    public class DMSReplaceClaims : CollectionBase
    {
        public DMSReplaceClaim this[int i]
        {
            get { return (DMSReplaceClaim)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSReplaceClaim oDMSReplaceClaim)
        {
            InnerList.Add(oDMSReplaceClaim);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DMSReplaceClaim";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
                    oDMSReplaceClaim.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oDMSReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oDMSReplaceClaim.ClaimedForMonth = Convert.ToDateTime(reader["ClaimedForMonth"].ToString());
                    oDMSReplaceClaim.ClaimStatus = (int)reader["ClaimStatus"];
                    oDMSReplaceClaim.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oDMSReplaceClaim.CustomerID = (int)reader["CustomerID"];
                    oDMSReplaceClaim.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    oDMSReplaceClaim.ApproverID = (int)reader["ApproverID"];
                    InnerList.Add(oDMSReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<DMSReplaceClaim> RefreshReplacementMonitoring(int CustomerID, DateTime fromDate, DateTime toDate)
        {
            var list = new List<DMSReplaceClaim>();
            InnerList.Clear();
            if(!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"select RegionName,AreaName,TerritoryName,total.CustomerID,CustomerCode,CustomerName,total.ReplaceClaimID,ClaimedForMonth,total.EntryDate,IsApproved,ClaimAmount,LogisticRecDate,ReplacementRecDate,ApprovalDate,DeliveryDate,ReplaceClaimNo 
                            from
                            (
                            select RegionName,AreaName,TerritoryName,main.CustomerID,CustomerCode,CustomerName,main.ReplaceClaimID,ReplaceClaimNo,ClaimedForMonth,main.EntryDate,IsApproved,ClaimAmount
                            from
                            (select  RegionName,AreaShortName as AreaName,a.ReplaceClaimNo, TerritoryShortName as TerritoryName, a.CustomerID, CustomerCode, CustomerName, ReplaceClaimID, ClaimedForMonth, a.EntryDate, IsApproved
                            from t_DMSReplaceClaim a, v_CustomerDetails b
                            where a.CustomerID = b.CustomerID   {0}
                            ) as main
                            left outer join
                            (
                            select ReplaceClaimID, sum(ClaimAmount) as ClaimAmount
                            from
                            (
                            select ReplaceClaimID, ProductID, (ClaimedQty * UnitPrice) as ClaimAmount
                            from[t_DMSReplaceClaimItem]
                            ) as RPAmt group by ReplaceClaimID
                            ) as claimItem on main.ReplaceClaimID = claimItem.ReplaceClaimID
                            )as total 
                            left outer join
                            (
                            select ReplaceClaimID,LogisticRecDate,ReplacementRecDate,ApprovalDate,DeliveryDate  from [t_ReplacementStatus]
                            )as stat on stat.ReplaceClaimID = total.ReplaceClaimID
                            ";
            string str="";
            if (CustomerID == -1)
            {
                str = "and ClaimedForMonth between '" + fromDate + "' and '" + toDate + "'";
                
            }
            else
            {
                str = "and a.CustomerID = "+CustomerID+ " and ClaimedForMonth between '" + fromDate + "' and '" + toDate + "'";
            }
            
            sSql = string.Format(sSql,str);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
                    oDMSReplaceClaim.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    //oDMSReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    oDMSReplaceClaim.ClaimedForMonth = Convert.ToDateTime(reader["ClaimedForMonth"].ToString());
                    oDMSReplaceClaim.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    oDMSReplaceClaim.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oDMSReplaceClaim.CustomerID = (int)reader["CustomerID"];
                    //oDMSReplaceClaim.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    //oDMSReplaceClaim.ApproverID = (int)reader["ApproverID"];
                    oDMSReplaceClaim.RegionName = (string)reader["RegionName"];
                    oDMSReplaceClaim.AreaName = (string)reader["AreaName"];
                    oDMSReplaceClaim.TerritoryName = (string)reader["TerritoryName"];
                    oDMSReplaceClaim.CustomerCode = (string)reader["CustomerCode"];
                    oDMSReplaceClaim.CustomerName = (string)reader["CustomerName"];
                    oDMSReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    if (!reader.IsDBNull(10))
                        oDMSReplaceClaim.ClaimAmount = Double.Parse(reader["ClaimAmount"].ToString());
                    else
                        oDMSReplaceClaim.ClaimAmount = 0;
                    if (!reader.IsDBNull(11))
                        oDMSReplaceClaim.LogisticRecDate = Convert.ToDateTime(reader["LogisticRecDate"].ToString());
                    else
                        oDMSReplaceClaim.LogisticRecDate = default(DateTime);
                    if (!reader.IsDBNull(12))
                        oDMSReplaceClaim.ReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                    else
                        oDMSReplaceClaim.ReplacementRecDate = default(DateTime);
                    if (!reader.IsDBNull(13))
                        oDMSReplaceClaim.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                    else
                        oDMSReplaceClaim.ApprovalDate = default(DateTime);
                    if (!reader.IsDBNull(14))
                        oDMSReplaceClaim.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else
                        oDMSReplaceClaim.DeliveryDate = default(DateTime);
                    InnerList.Add(oDMSReplaceClaim);
                    list.Add(oDMSReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        public List<DMSReplaceClaim> SKUWiseReport(int ReplacementClaimID, DateTime claimedForMonth)
        {
            var list = new List<DMSReplaceClaim>();
            InnerList.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"select MAGID,MAGName,ASGID,ASGName,MyTotal.CustomerID,CustomerCode,CustomerName,MyTotal.ProductID,ProductCode,ProductName,MyTotal.ReplaceClaimID,ClaimedForMonth,
                            ClaimedQty,ClaimedQty*NSP as ClaimedValue,EligibleTotal,EligibleTotal*NSP as EliTotalValue,OtherBrand,  OKLamp,  LifeOver,
                            BrokenLamp, NoCarton,  TempLamp, ExpireWarranty, GoodCondition,NotEligibleTotal,NotEligibleTotal*NSP as notEliTotValue,ReplaceClaimNo,RegionName,AreaShortName,TerritoryShortName
                            from
                            (
                            select MAGID,MAGName,ASGID,ASGName,MyMain.CustomerID,CustomerCode,CustomerName,MyMain.ProductID,ProductCode,ProductName,MyMain.ReplaceClaimID,ClaimedForMonth,
                            ClaimedQty,EligibleTotal,OtherBrand,  OKLamp,  LifeOver,
                            BrokenLamp, NoCarton,  TempLamp, ExpireWarranty, GoodCondition,NotEligibleTotal,ReplaceClaimNo,RegionName,AreaShortName,TerritoryShortName
                            from
                            ( 
                            select MAGID,MAGName,ASGID,ASGName,CustomerID,ft.ProductID,ProductCode,ProductName,ft.ReplaceClaimID,ClaimedForMonth,
                            ClaimedQty,ISNULL(EligibleTotal,0) as EligibleTotal,ISNULL(OtherBrand,0) as OtherBrand, ISNULL(OKLamp,0) as OKLamp, ISNULL(LifeOver,0) as LifeOver,
                            ISNULL(BrokenLamp,0) as BrokenLamp, ISNULL(NoCarton,0) as NoCarton, ISNULL(TempLamp,0) as TempLamp, ISNULL(ExpireWarranty,0) as ExpireWarranty,ISNULL(GoodCondition,0) as GoodCondition,
                            ISNULL (OtherBrand+OKLamp+ LifeOver + BrokenLamp+ NoCarton+TempLamp+ExpireWarranty+GoodCondition , 0) as NotEligibleTotal,ReplaceClaimNo
                            from
                            (
                            select  MAGID,MAGName,ASGID,ASGName,CustomerID,ProductID,ProductCode,ProductName,ReplaceClaimID,ReplaceClaimNo,ClaimedForMonth,
                            ClaimedQty
                            from
                            (
                            select Main.ReplaceClaimID,ReplaceClaimNo,ClaimedForMonth,Main.CustomerID,Main.ClaimedQty,ElligibleQty,Main.ProductID,ProductCode,ProductName,MAGID,MAGName,ASGID,ASGName,NSP
                            from
                            (
                            select a.ReplaceClaimID,b.ReplaceClaimNo,CustomerID,b.ClaimedForMonth,a.ClaimedQty,a.ProductID,
                            ProductCode,ProductName,MAGID,MAGName,ASGID,ASGName,NSP
                            from t_DMSReplaceClaimItem a, t_DMSReplaceClaim b,  v_ProductDetails c
                            where a.ReplaceClaimID = b.ReplaceClaimID and a.ProductID = c.ProductID
                            )as Main
                            left outer join
                            (
                            select c.ReplaceClaimID,ProductID, ClaimedQty as ElligibleQty,CustomerID
                            from t_ReplaceClaimItem c, t_ReplaceClaim d 
                            where c.ReplaceClaimID = d.ReplaceClaimID 
                            )as RepCl
                            on Main.ReplaceClaimID = RepCl.ReplaceClaimID and Main.ProductID = RepCl.ProductID
                            )as Total
                            where Total.ReplaceClaimID = "+ ReplacementClaimID + @"
                            )as ft
                            left outer join
                            (
                            select ProductID,ReplaceClaimID, 
                            EligibleTotal, OtherBrand, OKLamp, LifeOver,
                            BrokenLamp, NoCarton, TempLamp, ExpireWarranty,GoodCondition

                            from
                            (
                            select notEl.ProductID,notEl.ReplaceClaimID, EligibleTotal, OtherBrand, OKLamp, LifeOver,
                            BrokenLamp, NoCarton, TempLamp, ExpireWarranty,GoodCondition
                            from
                            (
                            select a.ReplaceClaimID, a.ProductID, sum(a.Quantity) as EligibleTotal
                            from t_ReplaceClaimAssessQuantity a
                            where FaultTypeID in(select FaultTypeID from t_ReplaceClaimFaultType where IsEligible = 1)
                            group by a.ReplaceClaimID, a.ProductID
                            )as el
                            left outer join
                            (
                            select ReplaceClaimID, ProductID,
                            Sum(case when FaultTypeID = 7 then Quantity 
                            else 0 end)as OtherBrand,
                            Sum(case when FaultTypeID = 8 then Quantity 
                            else 0 end)as OKLamp,
                            Sum(case when FaultTypeID = 9 then Quantity 
                            else 0 end)as LifeOver,
                            Sum(case when FaultTypeID = 10 then Quantity 
                            else 0 end)as BrokenLamp,
                            Sum(case when FaultTypeID = 11 then Quantity 
                            else 0 end)as NoCarton,
                            Sum(case when FaultTypeID = 16 then Quantity 
                            else 0 end)as TempLamp,
                            Sum(case when FaultTypeID = 18 then Quantity 
                            else 0 end)as ExpireWarranty,
                            Sum(case when FaultTypeID = 19 then Quantity 
                            else 0 end)as GoodCondition
                            from
                            (
                            select ReplaceClaimID, ProductID,FaultTypeID, Quantity 
                            from t_ReplaceClaimAssessQuantity
                            where FaultTypeID in(select FaultTypeID from t_ReplaceClaimFaultType where IsEligible = 0)
                            )as qtyNEl
                            Group by ReplaceClaimID, ProductID
                            )as notEl on el.ReplaceClaimID = notEl.ReplaceClaimID and el.ProductID = notEl.ProductID
                            )as ha where ReplaceClaimID="+ ReplacementClaimID + @"
                            )as lt
                            on ft.ReplaceClaimID = lt.ReplaceClaimID and ft.ProductID = lt.ProductID
                            )as MyMain
                            left outer join 
                            (
                            select CustomerID,CustomerCode,CustomerName,RegionName,AreaShortName,TerritoryShortName
                            from v_CustomerDetails
                            )as cust
                            on MyMain.CustomerID = cust.CustomerID
                            )as MyTotal
                            left outer join
                            (
                            select  distinct  qq.ProductID,EffectiveDate,NSP
	                            from 
	                            (
	                            select productID, MAX(PriceID)as PriceID from t_FinishedGoodsPrice where EffectiveDate <= '"+ claimedForMonth + @"' group by ProductID
	                            ) QQ
	                            left outer join
	                            ( select ProductID,NSP,EffectiveDate,PriceID from t_FinishedGoodsPrice ) as QQ1 on QQ.ProductID=QQ1.ProductID and qq.PriceID=qq1.PriceID
                            )as NSPvalue
                            on MyTotal.ProductID = NSPvalue.ProductID";
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
                    if (!reader.IsDBNull(10))
                        oDMSReplaceClaim.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    else
                        oDMSReplaceClaim.ReplaceClaimID = 0;
                    if (!reader.IsDBNull(11))
                    {
                        oDMSReplaceClaim.ClaimedForMonth = Convert.ToDateTime(reader["ClaimedForMonth"].ToString());
                        oDMSReplaceClaim.ClaimDate = oDMSReplaceClaim.ClaimedForMonth.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oDMSReplaceClaim.ClaimedForMonth = default(DateTime);
                        oDMSReplaceClaim.ClaimDate = "No Data";
                    }
                    if (!reader.IsDBNull(12))
                        oDMSReplaceClaim.ClaimedQty = (int)reader["ClaimedQty"];
                    else
                        oDMSReplaceClaim.ClaimedQty = 0;
                    if (!reader.IsDBNull(13))
                        oDMSReplaceClaim.ClaimedValue = Double.Parse(reader["ClaimedValue"].ToString());
                    else
                        oDMSReplaceClaim.ClaimedValue = 0;
                    if (!reader.IsDBNull(7))
                        oDMSReplaceClaim.ProductID = (int)reader["ProductID"];
                    else
                        oDMSReplaceClaim.ProductID = 0;
                    if (!reader.IsDBNull(8))
                        oDMSReplaceClaim.ProductCode = (string)reader["ProductCode"];
                    else
                        oDMSReplaceClaim.ProductCode = "-";
                    if (!reader.IsDBNull(9))
                        oDMSReplaceClaim.ProductName = (string)reader["ProductName"];
                    else
                        oDMSReplaceClaim.ProductName = "-";
                    if (!reader.IsDBNull(0))
                        oDMSReplaceClaim.MAGID = (int)reader["MAGID"];
                    else
                        oDMSReplaceClaim.MAGID = 0;
                    if (!reader.IsDBNull(1))
                        oDMSReplaceClaim.MAGName = (string)reader["MAGName"];
                    else
                        oDMSReplaceClaim.MAGName = "-";
                    if (!reader.IsDBNull(2))
                        oDMSReplaceClaim.ASGID = (int)reader["ASGID"];
                    else
                        oDMSReplaceClaim.ASGID = 0;
                    if (!reader.IsDBNull(3))
                        oDMSReplaceClaim.ASGName = (string)reader["ASGName"];
                    else
                        oDMSReplaceClaim.MAGName = "-";
                    if (!reader.IsDBNull(14))
                    {
                        oDMSReplaceClaim.EligibleTotal = (int)reader["EligibleTotal"];
                        oDMSReplaceClaim.IsAssessed = "Yes";
                    }   
                    else
                    {
                        oDMSReplaceClaim.EligibleTotal = 0;
                        oDMSReplaceClaim.IsAssessed = "No";
                    }
                    if (!reader.IsDBNull(15))
                    {
                        oDMSReplaceClaim.EligibleTotalValue = Double.Parse(reader["EliTotalValue"].ToString());
                       
                    }
                    else
                    {
                        oDMSReplaceClaim.EligibleTotalValue = 0;

                    }

                    if (!reader.IsDBNull(4))
                        oDMSReplaceClaim.CustomerID = (int)reader["CustomerID"];
                    else
                        oDMSReplaceClaim.CustomerID = 0;
                    if (!reader.IsDBNull(5))
                        oDMSReplaceClaim.CustomerCode = (string)reader["CustomerCode"];
                    else
                        oDMSReplaceClaim.CustomerCode = "-";
                    if (!reader.IsDBNull(6))
                        oDMSReplaceClaim.CustomerName = (string)reader["CustomerName"];
                    else
                        oDMSReplaceClaim.CustomerName = "-";
                    if (!reader.IsDBNull(16))
                        oDMSReplaceClaim.OtherBrand = (int)reader["OtherBrand"];
                    else
                        oDMSReplaceClaim.OtherBrand = 0;
                    if (!reader.IsDBNull(17))
                        oDMSReplaceClaim.OKLamp = (int)reader["OKLamp"];
                    else
                        oDMSReplaceClaim.OKLamp = 0;
                    if (!reader.IsDBNull(18))
                        oDMSReplaceClaim.LifeOver = (int)reader["LifeOver"];
                    else
                        oDMSReplaceClaim.LifeOver = 0;
                    if (!reader.IsDBNull(19))
                        oDMSReplaceClaim.BrokenLamp = (int)reader["BrokenLamp"];
                    else
                        oDMSReplaceClaim.BrokenLamp = 0;
                    if (!reader.IsDBNull(20))
                        oDMSReplaceClaim.NoCarton = (int)reader["NoCarton"];
                    else
                        oDMSReplaceClaim.NoCarton = 0;
                    if (!reader.IsDBNull(21))
                        oDMSReplaceClaim.TempLamp = (int)reader["TempLamp"];
                    else
                        oDMSReplaceClaim.TempLamp = 0;
                    if (!reader.IsDBNull(22))
                        oDMSReplaceClaim.ExpireWarranty = (int)reader["ExpireWarranty"];
                    else
                        oDMSReplaceClaim.ExpireWarranty = 0;
                    if (!reader.IsDBNull(23))
                        oDMSReplaceClaim.GoodCondition = (int)reader["GoodCondition"];
                    else
                        oDMSReplaceClaim.GoodCondition = 0;
                    if (!reader.IsDBNull(24))
                        oDMSReplaceClaim.NotEligibleTotal = (int)reader["NotEligibleTotal"];
                    else
                        oDMSReplaceClaim.NotEligibleTotal = 0;
                    if (!reader.IsDBNull(25))
                        oDMSReplaceClaim.NotEligibleTotalValue = Double.Parse(reader["notEliTotValue"].ToString());
                    else
                        oDMSReplaceClaim.NotEligibleTotalValue = 0;
                    if (!reader.IsDBNull(26))
                        oDMSReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    else
                        oDMSReplaceClaim.ReplaceClaimNo = "-";
                    if (!reader.IsDBNull(27))
                        oDMSReplaceClaim.RegionName = (string)reader["RegionName"];
                    else
                        oDMSReplaceClaim.RegionName = "-";
                    if (!reader.IsDBNull(28))
                        oDMSReplaceClaim.AreaName = (string)reader["AreaShortName"];
                    else
                        oDMSReplaceClaim.AreaName = "-";
                    if (!reader.IsDBNull(29))
                        oDMSReplaceClaim.TerritoryName = (string)reader["TerritoryShortName"];
                    else
                        oDMSReplaceClaim.TerritoryName = "-";
                    InnerList.Add(oDMSReplaceClaim);
                    list.Add(oDMSReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;

        }
        public List<DMSReplaceClaim> MakeReport(int CustomerID, DateTime fromDate, DateTime toDate)
        {
            var list = new List<DMSReplaceClaim>();
            InnerList.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            //string sSql = @"select RegionName, AreaName, TerritoryName, CustomerCode, CustomerName, ClaimedForMonth, LogisticRecDate,ReplacementRecDate,ApprovalDate,DeliveryDate,
            //                Status = case 
            //                when LogisticRecDate is null then 'NotRecByLog'
            //                when ReplacementRecDate is null then 'NotSentToRep'
            //                when ApprovalDate is null then 'NotApproved'
            //                when DeliveryDate is null then 'NotDelivered'		
            //                else 'Finish' end
            //                from
            //                (
            //                select  RegionName, AreaShortName as AreaName, TerritoryShortName as TerritoryName, a.CustomerID, CustomerCode, CustomerName, ReplaceClaimID, ClaimedForMonth, a.EntryDate
            //                from t_DMSReplaceClaim a, v_CustomerDetails b
            //                where a.CustomerID = b.CustomerID  {0}
            //                )as main 
            //                left outer join 
            //                (
            //                select ReplaceClaimID,LogisticRecDate,ReplacementRecDate,ApprovalDate,DeliveryDate  from [t_ReplacementStatus]
            //                )as stat on stat.ReplaceClaimID = main.ReplaceClaimID       
            //                                            ";
            //string str = "";
            //if (CustomerID == -1)
            //{
            //    str = "and ClaimedForMonth between '" + fromDate + "' and '" + toDate + "'";

            //}
            //else
            //{
            //    str = "and a.CustomerID = " + CustomerID + " and ClaimedForMonth between '" + fromDate + "' and '" + toDate + "'";
            //}

            //sSql = string.Format(sSql, str);
            string sSql = @"select ReplaceClaimID, RegionName, AreaName, TerritoryName, CustomerID, CustomerCode, CustomerName, ClaimedForMonth, LogisticRecDate, ReplacementRecDate, ApprovalDate, DeliveryDate,ReplaceClaimNo,
                            Status = case 
                            when LogisticRecDate is null then 'Not Rec By Log'
                            when ReplacementRecDate is null then 'Assessment not processed'
                            when ApprovalDate is null then 'Not Approved'
                            when DeliveryDate is null then 'Not Delivered'
                            else 'Finish' end
                            from
                            (
                            select RegionName, AreaName, TerritoryName, CustomerCode, Main.CustomerID, CustomerName, ClaimedForMonth, ReplaceClaimID,ReplaceClaimNo, LogisticRecDate, ReplacementRecDate, ApprovalDate, DeliveryDate
                            from
                            (
                            select RegionName, AreaShortName as AreaName, TerritoryShortName as TerritoryName, a.CustomerID, CustomerCode, CustomerName
                            from v_CustomerDetails a, t_DMSUser b
                            where a.CustomerID = b.DistributorID and b.IsActive = 1
                            )as Main
                            left outer join
                            (
                            select  c.CustomerID, c.ReplaceClaimID,c.ReplaceClaimNo, ClaimedForMonth, EntryDate, LogisticRecDate, ReplacementRecDate, ApprovalDate, DeliveryDate
                            from t_DMSReplaceClaim c, t_ReplacementStatus d
                            where c.ReplaceClaimID = d.ReplaceClaimID {0}
                            ) as claim  on Main.CustomerID = claim.CustomerID
                            )as tot_table {1}";

            string str1 = "";
            string str2 = "";
            if (CustomerID == -1)
            {
                str1 = "and ClaimedForMonth between '" + fromDate + "' and '" + toDate + "'";

            }
            else
            {
                str1 = "and ClaimedForMonth between '" + fromDate + "' and '" + toDate + "'";
                str2 = "where CustomerID = "+CustomerID;
            }
            sSql = string.Format(sSql, str1,str2);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaim oDMSReplaceClaim = new DMSReplaceClaim();
                    if (!reader.IsDBNull(0))
                        oDMSReplaceClaim.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    else
                        oDMSReplaceClaim.ReplaceClaimID = 0;
                    oDMSReplaceClaim.CustomerID = (int)reader["CustomerID"];
                    if (!reader.IsDBNull(7))
                    {
                        oDMSReplaceClaim.ClaimedForMonth = Convert.ToDateTime(reader["ClaimedForMonth"].ToString());
                        oDMSReplaceClaim.ClaimDate = oDMSReplaceClaim.ClaimedForMonth.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oDMSReplaceClaim.ClaimedForMonth = default(DateTime);
                        oDMSReplaceClaim.ClaimDate = "No Data";
                    }

                    oDMSReplaceClaim.RegionName = (string)reader["RegionName"];
                    oDMSReplaceClaim.AreaName = (string)reader["AreaName"];
                    oDMSReplaceClaim.TerritoryName = (string)reader["TerritoryName"];
                    oDMSReplaceClaim.CustomerCode = (string)reader["CustomerCode"];
                    oDMSReplaceClaim.CustomerName = (string)reader["CustomerName"];
                    if (!reader.IsDBNull(8))
                    {
                        oDMSReplaceClaim.LogisticRecDate = Convert.ToDateTime(reader["LogisticRecDate"].ToString());
                        oDMSReplaceClaim.LogisticDate = oDMSReplaceClaim.LogisticRecDate.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oDMSReplaceClaim.LogisticRecDate = default(DateTime);
                        oDMSReplaceClaim.LogisticDate = "No";
                    }
                    if (!reader.IsDBNull(9))
                    {
                        oDMSReplaceClaim.ReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                        oDMSReplaceClaim.ReplacementDate = oDMSReplaceClaim.ReplacementRecDate.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oDMSReplaceClaim.ReplacementRecDate = default(DateTime);
                        oDMSReplaceClaim.ReplacementDate = "No";
                    }
                    if (!reader.IsDBNull(10))
                    {
                        oDMSReplaceClaim.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                        oDMSReplaceClaim.ApproveDate = oDMSReplaceClaim.ApprovalDate.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oDMSReplaceClaim.ApprovalDate = default(DateTime);
                        oDMSReplaceClaim.ApproveDate = "No";
                    }
                    if (!reader.IsDBNull(11))
                    {
                        oDMSReplaceClaim.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                        oDMSReplaceClaim.DeliverDate = oDMSReplaceClaim.DeliveryDate.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oDMSReplaceClaim.DeliveryDate = default(DateTime);
                        oDMSReplaceClaim.DeliverDate = "No";
                    }
                    if (!reader.IsDBNull(12))
                        oDMSReplaceClaim.ReplaceClaimNo = (string)reader["ReplaceClaimNo"];
                    else
                        oDMSReplaceClaim.ReplaceClaimNo = "0";
                    oDMSReplaceClaim.Status = (string)reader["Status"];
                    InnerList.Add(oDMSReplaceClaim);
                    list.Add(oDMSReplaceClaim);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        public List<DMSReplaceClaim> RefreshToStatus()
        {
            var list = new List<DMSReplaceClaim>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_ReplacementStatus";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaim oReplacementStatus = new DMSReplaceClaim();
                    oReplacementStatus.TranID = (int)reader["TranID"];
                    oReplacementStatus.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplacementStatus.CustomerID = (int)reader["CustomerID"];
                    oReplacementStatus.ClaimMonth = Convert.ToDateTime(reader["ClaimMonth"].ToString());
                    oReplacementStatus.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oReplacementStatus.EligibleAmount = Convert.ToDouble(reader["EligibleAmount"].ToString());
                    oReplacementStatus.LogisticRecDate = Convert.ToDateTime(reader["LogisticRecDate"].ToString());
                    oReplacementStatus.LogisticUserID = (int)reader["LogisticUserID"];
                    oReplacementStatus.ReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                    oReplacementStatus.ReplacementUserID = (int)reader["ReplacementUserID"];
                    oReplacementStatus.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                    oReplacementStatus.ApprovedUserID = (int)reader["ApprovedUserID"];
                    oReplacementStatus.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    oReplacementStatus.DeliveryUserID = (int)reader["DeliveryUserID"];
                    InnerList.Add(oReplacementStatus);
                    list.Add(oReplacementStatus);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        public List<DMSReplaceClaim> RefreshToStatus(int ReplacementClaimID)
        {
            var list = new List<DMSReplaceClaim>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_ReplacementStatus where ReplaceClaimID = " + ReplacementClaimID;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSReplaceClaim oReplacementStatus = new DMSReplaceClaim();
                    oReplacementStatus.TranID = (int)reader["TranID"];
                    oReplacementStatus.ReplaceClaimID = (int)reader["ReplaceClaimID"];
                    oReplacementStatus.CustomerID = (int)reader["CustomerID"];
                    if (!reader.IsDBNull(3))
                        oReplacementStatus.ClaimMonth = Convert.ToDateTime(reader["ClaimMonth"].ToString());
                    else
                        oReplacementStatus.ClaimMonth = default(DateTime);
                    if (!reader.IsDBNull(4))
                        oReplacementStatus.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else
                        oReplacementStatus.Amount = 0;
                    if (!reader.IsDBNull(5))
                        oReplacementStatus.EligibleAmount = Convert.ToDouble(reader["EligibleAmount"].ToString());
                    else
                        oReplacementStatus.EligibleAmount = 0;
                    if (!reader.IsDBNull(6))
                        oReplacementStatus.LogisticRecDate = Convert.ToDateTime(reader["LogisticRecDate"].ToString());
                    else
                        oReplacementStatus.LogisticRecDate = default(DateTime);
                    if (!reader.IsDBNull(7))
                        oReplacementStatus.LogisticUserID = (int)reader["LogisticUserID"];
                    else
                        oReplacementStatus.LogisticUserID = 0;
                    if (!reader.IsDBNull(8))
                        oReplacementStatus.ReplacementRecDate = Convert.ToDateTime(reader["ReplacementRecDate"].ToString());
                    else
                        oReplacementStatus.ReplacementRecDate = default(DateTime);
                    if (!reader.IsDBNull(9))
                        oReplacementStatus.ReplacementUserID = (int)reader["ReplacementUserID"];
                    else
                        oReplacementStatus.ReplacementUserID = 0;
                    if (!reader.IsDBNull(10))
                        oReplacementStatus.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"].ToString());
                    else
                        oReplacementStatus.ApprovalDate = default(DateTime);
                    if (!reader.IsDBNull(11))
                        oReplacementStatus.ApprovedUserID = (int)reader["ApprovedUserID"];
                    else
                        oReplacementStatus.ApprovedUserID = 0;
                    if (!reader.IsDBNull(12))
                        oReplacementStatus.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else
                        oReplacementStatus.DeliveryDate = default(DateTime);
                    if (!reader.IsDBNull(13))
                        oReplacementStatus.DeliveryUserID = (int)reader["DeliveryUserID"];
                    else
                        oReplacementStatus.DeliveryUserID = 0;
                    InnerList.Add(oReplacementStatus);
                    list.Add(oReplacementStatus);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
    }
}














