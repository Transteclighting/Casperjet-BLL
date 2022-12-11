// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jul 18, 2016
// Time : 03:50 PM
// Description: Class for InvoiceReverse.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.EnterpriseServices.Internal;
using CJ.Class;

namespace CJ.Class
{
    public class InvoiceReverseDetail
    {
        private int _nID;
        private int _nWarehouseID;
        private int _nProductID;
        private string _sProductSerial;
        private int _nStockType;
        private int _nDefectiveType;
        private string _sFaultDesc;
        private string _sFaultRemarks;
        private string _sReason;
        private string _sJobNo;

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        // <summary>
        private int _nReverseID;

        public int ReverseID
        {
            get { return _nReverseID; }
            set { _nReverseID = value; }
        }

        // <summary>
        // Get set property for QuotationID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for MAGName
        // </summary>
        public string ProductSerial
        {
            get { return _sProductSerial; }
            set { _sProductSerial = value.Trim(); }
        }
        public int StockType
        {
            get { return _nStockType; }
            set { _nStockType = value; }
        }

        // <summary>
        // Get set property for Model
        // </summary>
        public int DefectiveType
        {
            get { return _nDefectiveType; }
            set { _nDefectiveType = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public string FaultDesc
        {
            get { return _sFaultDesc; }
            set { _sFaultDesc = value; }
        }

        // <summary>
        // Get set property for Ton
        // </summary>
        public string FaultRemarks
        {
            get { return _sFaultRemarks; }
            set { _sFaultRemarks = value; }
        }
        // <summary>
        // Get set property for Qty
        // </summary>
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value; }
        }

        // <summary>
        // Get set property for Ton
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }

        public void Add(int _nInvoiceReverseID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_InvoiceReverseDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_InvoiceReverseDetail (ID, ReverseID, WarehouseID, ProductID, ProductSerial, StockType, DefectiveType, FaultDescription,FaultRemarks, Reason, JobNo) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ReverseID", _nInvoiceReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                cmd.Parameters.AddWithValue("StockType", _nStockType);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("FaultDescription", _sFaultDesc);
                cmd.Parameters.AddWithValue("FaultRemarks", _sFaultRemarks);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class InvoiceReverse:CollectionBase
    {

        public InvoiceReverseDetail this[int i]
        {
            get { return (InvoiceReverseDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(InvoiceReverseDetail oInvoiceReverseDetail)
        {
            InnerList.Add(oInvoiceReverseDetail);
        }

        public string ActualReason
        {
            get { return _sActualReason; }
            set { _sActualReason = value; }
        }


        private int _nReverseID;
        private int _nWarehouseID;
        private string _sInvoiceNo;
        private string _sReason;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private Nullable<DateTime> _dUpdateDate;
        private int _nUpdateUserID;
        private string _sRecommend;
        private DateTime _dRecommendDate;
        private int _nRecommendBy;
        private string _sApprovedCommand;
        private DateTime _dApprovedDate;
        private int _nApprovedUserID;
        private int _nStatus;

        private long _nInvoiceID;
        private DateTime _dInvoiceDate;
        private string _sConsumerName;
        private string _sConsumerAddress;
        private string _sMobileNo;
        private string _sEmail;
        private double _InvoiceAmount;
        private int _nCount;
        private string _sShowroomCode;
        private string _sActualReason;
        private Double _OtherCharge;

        public Double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }

        private Double _Discount;

        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        // <summary>
        // Get set property for Count
        // </summary>
        public int Count
        {
            get { return _nCount; }
            set { _nCount = value; }
        }

        // <summary>
        // Get set property for InvoiceAmount
        // </summary>
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        // <summary>
        // Get set property for _dInvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        // <summary>
        // Get set property for sConsumerName
        // </summary>
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }
        // <summary>
        // Get set property for _sConsumerAddress
        // </summary>
        public string ConsumerAddress
        {
            get { return _sConsumerAddress; }
            set { _sConsumerAddress = value.Trim(); }
        }
        // <summary>
        // Get set property for _sMobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        // <summary>
        // Get set property for _sEmail
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }

        }


        // <summary>
        // Get set property for ReverseID
        // </summary>
        public int ReverseID
        {
            get { return _nReverseID; }
            set { _nReverseID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        // <summary>
        // Get set property for Reason
        // </summary>
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public Nullable<DateTime> UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for Recommend
        // </summary>
        public string Recommend
        {
            get { return _sRecommend; }
            set { _sRecommend = value.Trim(); }
        }

        // <summary>
        // Get set property for RecommendDate
        // </summary>
        public DateTime RecommendDate
        {
            get { return _dRecommendDate; }
            set { _dRecommendDate = value; }
        }

        // <summary>
        // Get set property for RecommendBy
        // </summary>
        public int RecommendBy
        {
            get { return _nRecommendBy; }
            set { _nRecommendBy = value; }
        }

        // <summary>
        // Get set property for ApprovedCommand
        // </summary>
        public string ApprovedCommand
        {
            get { return _sApprovedCommand; }
            set { _sApprovedCommand = value.Trim(); }
        }

        // <summary>
        // Get set property for ApprovedDate
        // </summary>
        public DateTime ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxReverseID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ReverseID]) FROM t_InvoiceReverse";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxReverseID = 1;
                }
                else
                {
                    nMaxReverseID = Convert.ToInt32(maxID) + 1;
                }
                _nReverseID = nMaxReverseID;
                sSql = "INSERT INTO t_InvoiceReverse (ReverseID, WarehouseID, InvoiceNo, Reason, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Recommend, RecommendDate, RecommendBy, ApprovedCommand, ApprovedDate, ApprovedUserID, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Recommend", null);
                cmd.Parameters.AddWithValue("RecommendDate", null);
                cmd.Parameters.AddWithValue("RecommendBy", null);
                cmd.Parameters.AddWithValue("ApprovedCommand", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (InvoiceReverseDetail oInvoiceReverseDetail in this)
                {
                    oInvoiceReverseDetail.Add(_nReverseID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForWeb()
        {
            int nMaxReverseID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_InvoiceReverse (ReverseID, WarehouseID, InvoiceNo, Reason, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Recommend, RecommendDate, RecommendBy, ApprovedCommand, ApprovedDate, ApprovedUserID, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }

                if (_nUpdateUserID != null)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                cmd.Parameters.AddWithValue("Recommend", null);
                cmd.Parameters.AddWithValue("RecommendDate", null);
                cmd.Parameters.AddWithValue("RecommendBy", null);
                cmd.Parameters.AddWithValue("ApprovedCommand", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (InvoiceReverseDetail oItem in this)
                {
                    oItem.Add(_nReverseID);
                }
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
                sSql = "UPDATE t_InvoiceReverse SET InvoiceNo = ?, Reason = ?, UpdateDate = ?, UpdateUserID = ?, Status = ? WHERE ReverseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                OleDbCommand cmd1 = DBController.Instance.GetCommand();
                string sSql1 = "";

                sSql1 = "Delete from t_InvoiceReverseDetail where ReverseID = ?";
                cmd1.CommandText = sSql1;
                cmd1.CommandType = CommandType.Text;

                cmd1.Parameters.AddWithValue("ReverseID", _nReverseID);

                cmd1.ExecuteNonQuery();
                cmd1.Dispose();

                foreach (InvoiceReverseDetail oInvoiceReverseDetail in this)
                {
                    oInvoiceReverseDetail.Add(_nReverseID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_InvoiceReverse SET UpdateDate = ?, Status = ? WHERE ReverseID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateInvoiceReverseStatusWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_InvoiceReverse SET Status = ?, Recommend = ?, RecommendDate = ?, RecommendBy = ?, ApprovedCommand = ?, ApprovedDate = ?, ApprovedUserID = ?  WHERE ReverseID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Recommend", _sRecommend);

                if (_dRecommendDate != null)
                {
                    cmd.Parameters.AddWithValue("RecommendDate", _dRecommendDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RecommendDate", DateTime.Now.Date);
                }
                if (_nRecommendBy != null)
                {
                    cmd.Parameters.AddWithValue("RecommendBy", _nRecommendBy);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RecommendBy", -1);
                }
                cmd.Parameters.AddWithValue("ApprovedCommand", _sApprovedCommand);

                if (_dApprovedDate != null)
                {
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                }

                if (_nApprovedUserID != null)
                {
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApprovedUserID", -1);
                }

                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_InvoiceReverse SET Status = ? WHERE InvoiceNo = ? and ReverseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRecommendStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_InvoiceReverse SET Status = ?,Recommend = ?,RecommendBy = ?, RecommendDate= ? WHERE InvoiceNo = ? and ReverseID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Recommend", _sRecommend);
                cmd.Parameters.AddWithValue("RecommendBy", _nRecommendBy);
                cmd.Parameters.AddWithValue("RecommendDate", _dRecommendDate);

                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateApprovedStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_InvoiceReverse SET Status = ?,ApprovedCommand = ?,ApprovedUserID = ?, ApprovedDate = ? WHERE InvoiceNo = ? and ReverseID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedCommand", _sApprovedCommand);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateReason()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                var sSql = "UPDATE t_InvoiceReverse set Reason=?,ReasonUpdateUserID=?,ReasonUpdateDate=?,ActualReason=? WHERE ReverseID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ReasonUpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ReasonUpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ActualReason", _sActualReason);
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRejectStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_InvoiceReverse SET Status = ?, Recommend = ?,RecommendBy = ?, RecommendDate =?,ApprovedCommand = ?,ApprovedDate = ?,ApprovedUserID = ?  WHERE InvoiceNo = ? and ReverseID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("Recommend", "");
                cmd.Parameters.AddWithValue("RecommendBy", Utility.UserId);
                cmd.Parameters.AddWithValue("RecommendDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("ApprovedCommand", "");
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                sSql = "DELETE FROM t_InvoiceReverse WHERE [ReverseID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_InvoiceReverse WHERE [ReverseID]=? and WarehouseID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteDetailRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_InvoiceReverseDetail WHERE [ReverseID]=? and WarehouseID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
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
                cmd.CommandText = "SELECT * FROM t_InvoiceReverse where ReverseID =?";
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nReverseID = (int)reader["ReverseID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _sReason = (string)reader["Reason"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _sRecommend = (string)reader["Recommend"];
                    _dRecommendDate = Convert.ToDateTime(reader["RecommendDate"].ToString());
                    _nRecommendBy = (int)reader["RecommendBy"];
                    _sApprovedCommand = (string)reader["ApprovedCommand"];
                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    _nApprovedUserID = (int)reader["ApprovedUserID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDuplicateInvoice(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT Count(InvoiceNo) As Count FROM t_InvoiceReverse where InvoiceNo = ? and Status not in (" + (int)Dictionary.ReverseStatus.Reject + ")";
                cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCount = (int)reader["Count"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetApprovedInvoice(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT ReverseID,Count(InvoiceNo) As Count FROM t_InvoiceReverse "+
                                  "where InvoiceNo = ? and Status=" + (int)Dictionary.ReverseStatus.Approved + " "+
                                  "Group by ReverseID";

                cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nReverseID = (int)reader["ReverseID"];
                    _nCount = (int)reader["Count"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByInvoiceNo(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT InvoiceID,InvoiceNo,InvoiceDate,InvoiceAmount,isnull(Consumername,'') ConsumerName, " +
                                " isnull(Address,'') as ConsumerAddress,isnull(CellNo,'') MobileNo,isnull(Email,'') Email  " +
                                " FROM t_SalesInvoice a,t_Retailconsumer b " +
                                " where a.SundryCustomerID=b.ConsumerID and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                                " and InvoiceNo = ? ";

                cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInvoiceID = (int)reader["InvoiceID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _sConsumerName = (string)reader["ConsumerName"];
                    _sConsumerAddress = (string)reader["ConsumerAddress"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sEmail = (string)reader["Email"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public void RefreshByInvoiceNoHO(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT InvoiceID,InvoiceNo,InvoiceDate,InvoiceAmount,isnull(Consumername,'') ConsumerName, " +
                                " isnull(Address,'') as ConsumerAddress,isnull(CellNo,'') MobileNo,isnull(Email,'') Email,isnull(a.Discount,0) Discount,isnull(a.OtherCharge,0) OtherCharge  " +
                                " FROM t_SalesInvoice a,t_Retailconsumer b " +
                                " where a.SundryCustomerID=b.ConsumerID and a.WarehouseID=b.WarehouseID and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                                " and InvoiceNo = '" + sInvoiceNo + "'";

                //cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());


                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _sConsumerName = (string)reader["ConsumerName"];
                    _sConsumerAddress = (string)reader["ConsumerAddress"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sEmail = (string)reader["Email"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshReverseDetailForDataSending()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_InvoiceReverseDetail where ReverseID=? ";
                cmd.Parameters.AddWithValue("ReverseID", _nReverseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceReverseDetail oItem = new InvoiceReverseDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString()); ;
                    oItem.ReverseID = int.Parse(reader["ReverseID"].ToString()); ;
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductSerial = (string)reader["ProductSerial"];
                    oItem.StockType = (int)reader["StockType"];
                    oItem.DefectiveType = (int)reader["DefectiveType"];

                    if (reader["FaultDescription"] != DBNull.Value)
                    {
                        oItem.FaultDesc = reader["FaultDescription"].ToString();
                    }
                    else oItem.FaultDesc = "";
                    if (reader["FaultRemarks"] != DBNull.Value)
                    {
                        oItem.FaultRemarks = reader["FaultRemarks"].ToString();
                    }
                    else oItem.FaultRemarks = "";
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oItem.Reason = reader["Reason"].ToString();
                    }
                    else oItem.Reason = "";

                    if (reader["JobNo"] != DBNull.Value)
                    {
                        oItem.JobNo = reader["JobNo"].ToString();
                    }
                    else oItem.JobNo = "";

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
    }
    public class InvoiceReverses : CollectionBase
    {
        public InvoiceReverse this[int i]
        {
            get { return (InvoiceReverse)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(InvoiceReverse oInvoiceReverse)
        {
            InnerList.Add(oInvoiceReverse);
        }
        public int GetIndex(int nReverseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ReverseID == nReverseID)
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
            string sSql = "SELECT * FROM t_InvoiceReverse";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                    oInvoiceReverse.ReverseID = (int)reader["ReverseID"];
                    oInvoiceReverse.WarehouseID = (int)reader["WarehouseID"];
                    oInvoiceReverse.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvoiceReverse.Reason = (string)reader["Reason"];
                    oInvoiceReverse.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInvoiceReverse.CreateUserID = (int)reader["CreateUserID"];
                    oInvoiceReverse.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oInvoiceReverse.UpdateUserID = (int)reader["UpdateUserID"];
                    oInvoiceReverse.Recommend = (string)reader["Recommend"];
                    oInvoiceReverse.RecommendDate = Convert.ToDateTime(reader["RecommendDate"].ToString());
                    oInvoiceReverse.RecommendBy = (int)reader["RecommendBy"];
                    oInvoiceReverse.ApprovedCommand = (string)reader["ApprovedCommand"];
                    oInvoiceReverse.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    oInvoiceReverse.ApprovedUserID = (int)reader["ApprovedUserID"];
                    oInvoiceReverse.Status = (int)reader["Status"];
                    InnerList.Add(oInvoiceReverse);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetReverseAppalication(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select * From t_InvoiceReverse where 1=1";

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
            sSql = sSql + " Order by ReverseID Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                    oInvoiceReverse.ReverseID = (int)reader["ReverseID"];
                    oInvoiceReverse.WarehouseID = (int)reader["WarehouseID"];
                    oInvoiceReverse.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvoiceReverse.Reason = (string)reader["Reason"];
                    oInvoiceReverse.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInvoiceReverse.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Recommend"] != DBNull.Value)
                        oInvoiceReverse.Recommend = (string)reader["Recommend"];
                    else oInvoiceReverse.Recommend = "";
                    if (reader["ApprovedCommand"] != DBNull.Value)
                        oInvoiceReverse.ApprovedCommand = (string)reader["ApprovedCommand"];
                    else oInvoiceReverse.ApprovedCommand = "";
                    oInvoiceReverse.Status = (int)reader["Status"];
                    InnerList.Add(oInvoiceReverse);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetReverseAppalicationRT(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select * From t_InvoiceReverse where WarehouseID=" + Utility.WarehouseID + "";

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " and InvoiceNo = '" + sInvoiceNo + "'";
            }
            sSql = sSql + " Order by ReverseID Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                    oInvoiceReverse.ReverseID = (int)reader["ReverseID"];
                    oInvoiceReverse.WarehouseID = (int)reader["WarehouseID"];
                    oInvoiceReverse.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvoiceReverse.Reason = (string)reader["Reason"];
                    oInvoiceReverse.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInvoiceReverse.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Recommend"] != DBNull.Value)
                        oInvoiceReverse.Recommend = (string)reader["Recommend"];
                    else oInvoiceReverse.Recommend = "";
                    if (reader["ApprovedCommand"] != DBNull.Value)
                        oInvoiceReverse.ApprovedCommand = (string)reader["ApprovedCommand"];
                    else oInvoiceReverse.ApprovedCommand = "";
                    oInvoiceReverse.Status = (int)reader["Status"];
                    InnerList.Add(oInvoiceReverse);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetReverseAppalicationHO(DateTime dFromDate, DateTime dToDate, string sInvoiceNo,int nWarehouseID,int nStatus, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select ReverseID,a.WarehouseID,ShowroomCode,InvoiceNo,Reason,CreateDate,CreateUserID, " +
                   "isnull(Recommend,'') Recommend,isnull(ApprovedCommand,'') ApprovedCommand, a.Status " +
                   "From t_InvoiceReverse a,t_Showroom b where a.WarehouseID=b.WarehouseID and 1=1 ";

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + "and a.Status = " + nStatus + "";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + "and a.WarehouseID = " + nWarehouseID + "";
            }
            sSql = sSql + " Order by ReverseID Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    InvoiceReverse oInvoiceReverse = new InvoiceReverse();
                    oInvoiceReverse.ReverseID = (int)reader["ReverseID"];
                    oInvoiceReverse.WarehouseID = (int)reader["WarehouseID"];
                    oInvoiceReverse.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvoiceReverse.ShowroomCode = (string)reader["ShowroomCode"];
                    oInvoiceReverse.Reason = (string)reader["Reason"];
                    oInvoiceReverse.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInvoiceReverse.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Recommend"] != DBNull.Value)
                        oInvoiceReverse.Recommend = (string)reader["Recommend"];
                    else oInvoiceReverse.Recommend = "";
                    if (reader["ApprovedCommand"] != DBNull.Value)
                        oInvoiceReverse.ApprovedCommand = (string)reader["ApprovedCommand"];
                    else oInvoiceReverse.ApprovedCommand = "";
                    oInvoiceReverse.Status = (int)reader["Status"];
                    InnerList.Add(oInvoiceReverse);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForDataSendingTD(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_InvoiceReverse a inner join t_DataTransfer b on b.DataID=a.ReverseID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

            cmd.Parameters.AddWithValue("TableName", "t_InvoiceReverse");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    InvoiceReverse _oInvoiceReverse = new InvoiceReverse();

                    _oInvoiceReverse.ReverseID = Convert.ToInt32(reader["ReverseID"]);
                    _oInvoiceReverse.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    _oInvoiceReverse.InvoiceNo = (string)reader["InvoiceNo"];
                    _oInvoiceReverse.Reason = (string)reader["Reason"];
                    _oInvoiceReverse.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    _oInvoiceReverse.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
                    if (reader["UpdateDate"] != DBNull.Value)
                        _oInvoiceReverse.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    else
                        _oInvoiceReverse.UpdateDate=null;
                    if (reader["UpdateUserID"] != DBNull.Value)
                        _oInvoiceReverse.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"]);
                    _oInvoiceReverse.Status = Convert.ToInt32(reader["Status"]);


                   _oInvoiceReverse.RefreshReverseDetailForDataSending();

                    InnerList.Add(_oInvoiceReverse);

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

