// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Sep 01, 2016
// Time : 02:49 PM
// Description: Class for ExchangeOfferMR.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class
{
    public class ExchangeOfferMR
    {
        private int _nMoneyReceiptID;
        private string _sMoneyReceiptNo;
        private int _nJobID;
        private int _nCreateWHID;
        private int _nTransferWHID;
        private int _nRedeemWHID;
        private double _Amount;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nTransferUserID;
        private DateTime _dTransferDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nStatus;
        private string _sJobNo;
        private string _sCreateWHName;
        private string _sTransferWHName;
        private string _sCustomerName;
        private string _sAddress;
        private string _sContactNo;
        private string _sEmail;

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateWHName
        // </summary>
        public string CreateWHName
        {
            get { return _sCreateWHName; }
            set { _sCreateWHName = value.Trim(); }
        }

        // <summary>
        // Get set property for TransferWHName
        // </summary>
        public string TransferWHName
        {
            get { return _sTransferWHName; }
            set { _sTransferWHName = value.Trim(); }
        }

        // <summary>
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }

        // <summary>
        // Get set property for MoneyReceiptID
        // </summary>
        public int MoneyReceiptID
        {
            get { return _nMoneyReceiptID; }
            set { _nMoneyReceiptID = value; }
        }

        // <summary>
        // Get set property for MoneyReceiptNo
        // </summary>
        public string MoneyReceiptNo
        {
            get { return _sMoneyReceiptNo; }
            set { _sMoneyReceiptNo = value.Trim(); }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for CreateWHID
        // </summary>
        public int CreateWHID
        {
            get { return _nCreateWHID; }
            set { _nCreateWHID = value; }
        }

        // <summary>
        // Get set property for TransferWHID
        // </summary>
        public int TransferWHID
        {
            get { return _nTransferWHID; }
            set { _nTransferWHID = value; }
        }

        // <summary>
        // Get set property for RedeemWHID
        // </summary>
        public int RedeemWHID
        {
            get { return _nRedeemWHID; }
            set { _nRedeemWHID = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for TransferUserID
        // </summary>
        public int TransferUserID
        {
            get { return _nTransferUserID; }
            set { _nTransferUserID = value; }
        }

        // <summary>
        // Get set property for TransferDate
        // </summary>
        public DateTime TransferDate
        {
            get { return _dTransferDate; }
            set { _dTransferDate = value; }
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
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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
            int nMaxMoneyReceiptID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MoneyReceiptID]) FROM t_ExchangeOfferMR";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMoneyReceiptID = 1;
                }
                else
                {
                    nMaxMoneyReceiptID = Convert.ToInt32(maxID) + 1;
                }
                _nMoneyReceiptID = nMaxMoneyReceiptID;


                string sShortCode = "";
                DateTime dOperationDate;

                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();
                sShortCode = oSystemInfo.Shortcode;



                string sMRNo = "";
                DateTime dToday = DateTime.Today;
                sMRNo = "MR-" + sShortCode + "-" + dToday.ToString("yy") + _nMoneyReceiptID.ToString("000");
                _sMoneyReceiptNo = sMRNo;


                sSql = "INSERT INTO t_ExchangeOfferMR (MoneyReceiptID, MoneyReceiptNo, JobID, CreateWHID, TransferWHID, RedeemWHID, Amount, Remarks, CreateUserID, CreateDate, TransferUserID, TransferDate, UpdateUserID, UpdateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CreateWHID", _nCreateWHID);
                cmd.Parameters.AddWithValue("TransferWHID", null);
                cmd.Parameters.AddWithValue("RedeemWHID", null);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TransferUserID", null);
                cmd.Parameters.AddWithValue("TransferDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForWeb()
        {
            int nMaxMoneyReceiptID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MoneyReceiptID]) FROM t_ExchangeOfferMR";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMoneyReceiptID = 1;
                }
                else
                {
                    nMaxMoneyReceiptID = Convert.ToInt32(maxID) + 1;
                }
                _nMoneyReceiptID = nMaxMoneyReceiptID;

                sSql = "INSERT INTO t_ExchangeOfferMR (MoneyReceiptID, MoneyReceiptNo, JobID, CreateWHID, TransferWHID, RedeemWHID, Amount, Remarks, CreateUserID, CreateDate, TransferUserID, TransferDate, UpdateUserID, UpdateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CreateWHID", _nCreateWHID);
                if (_nTransferWHID != null)
                {
                    cmd.Parameters.AddWithValue("TransferWHID", _nTransferWHID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TransferWHID", null);
                }
                if (_nRedeemWHID != null)
                {
                    cmd.Parameters.AddWithValue("RedeemWHID", _nRedeemWHID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RedeemWHID", null);
                }
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                if (_nTransferUserID != null)
                {
                    cmd.Parameters.AddWithValue("TransferUserID", _nTransferUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TransferUserID", null);
                }
                if (_dTransferDate != null)
                {
                    cmd.Parameters.AddWithValue("TransferDate", _dTransferDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TransferDate", null);
                }
                if (_nUpdateUserID != null)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForWebUpload()
        {
            int nMaxMoneyReceiptID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([MoneyReceiptID]) FROM t_ExchangeOfferMR";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMoneyReceiptID = 1;
                }
                else
                {
                    nMaxMoneyReceiptID = Convert.ToInt32(maxID) + 1;
                }
                _nMoneyReceiptID = nMaxMoneyReceiptID;

                sSql = "INSERT INTO t_ExchangeOfferMR (MoneyReceiptID, MoneyReceiptNo, JobID, CreateWHID, TransferWHID, RedeemWHID, Amount, Remarks, CreateUserID, CreateDate, TransferUserID, TransferDate, UpdateUserID, UpdateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CreateWHID", _nCreateWHID);
                cmd.Parameters.AddWithValue("TransferWHID", null);
                if (_nRedeemWHID != null)
                {
                    cmd.Parameters.AddWithValue("RedeemWHID", _nRedeemWHID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RedeemWHID", null);
                }
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TransferUserID", null);
                cmd.Parameters.AddWithValue("TransferDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

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
                sSql = "UPDATE t_ExchangeOfferMR SET Amount = ?, Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE MoneyReceiptID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateForPOSWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferMR SET Status = ?, RedeemWHID = ? WHERE MoneyReceiptNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RedeemWHID", _nRedeemWHID);

                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void TransferMR()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferMR SET TransferWHID = ?, TransferUserID = ?, TransferDate = ?, Status = ? WHERE MoneyReceiptID = ? and CreateWHID = ? and JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("TransferWHID", _nTransferWHID);
                cmd.Parameters.AddWithValue("TransferUserID", _nTransferUserID);
                cmd.Parameters.AddWithValue("TransferDate", _dTransferDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.Parameters.AddWithValue("CreateWHID", _nCreateWHID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdaetMRForWeb()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferMR SET TransferWHID = ?, TransferUserID = ?, TransferDate = ?, Status = ? WHERE MoneyReceiptNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("TransferWHID", _nTransferWHID);
                cmd.Parameters.AddWithValue("TransferUserID", _nTransferUserID);
                cmd.Parameters.AddWithValue("TransferDate", _dTransferDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferMR SET MoneyReceiptNo = ?, JobID = ?, CreateWHID = ?, TransferWHID = ?, RedeemWHID = ?, Amount = ?, Remarks = ?, CreateUserID = ?, CreateDate = ?, TransferUserID = ?, TransferDate = ?, UpdateUserID = ?, UpdateDate = ?, Status = ? WHERE MoneyReceiptID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CreateWHID", _nCreateWHID);
                cmd.Parameters.AddWithValue("TransferWHID", _nTransferWHID);
                cmd.Parameters.AddWithValue("RedeemWHID", _nRedeemWHID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TransferUserID", _nTransferUserID);
                cmd.Parameters.AddWithValue("TransferDate", _dTransferDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);

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
                sSql = "DELETE FROM t_ExchangeOfferMR WHERE [MoneyReceiptID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
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
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferMR where MoneyReceiptID =?";
                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMoneyReceiptID = (int)reader["MoneyReceiptID"];
                    _sMoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    _nJobID = (int)reader["JobID"];
                    _nCreateWHID = (int)reader["CreateWHID"];
                    _nTransferWHID = (int)reader["TransferWHID"];
                    _nRedeemWHID = (int)reader["RedeemWHID"];
                    _Amount = (double)reader["Amount"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nTransferUserID = (int)reader["TransferUserID"];
                    _dTransferDate = Convert.ToDateTime(reader["TransferDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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

        //public void GetExchengedItemForMR(int nJobID)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText = "Select JobID,ProductDetail,ProductType,  " +
        //                        "ProductTypeName=Case when ProductType=0 then 'CTV'  " +
        //                        "when ProductType=1 then 'HTV'  " +
        //                        "when ProductType=2 then 'Refrigerator'  " +
        //                        "when ProductType=3 then 'Freezer'  " +
        //                        "when ProductType=4 then 'AC_Split'  " +
        //                        "when ProductType=5 then 'AC_Window'  " +
        //                        "else 'Other' end,Quantity,ProductSize,BrandName,HaveRemortctrl,  " +
        //                        "HaveRemort=Case when HaveRemortctrl=0 then 'NA'  " +
        //                        "when ProductType=1 then 'No'  " +
        //                        "else 'Yes' end,  " +
        //                        "Condition,ConditionName=Case when Condition=0 then 'Fucnctional'  " +
        //                        "else 'Dead' end  " +
        //                        "From t_ExchangeOfferJobDetail where JobID = ?";

        //        cmd.Parameters.AddWithValue("JobID", nJobID);

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ExchangeOfferJobDetail oItem = new ExchangeOfferJobDetail();

        //            oItem.JobID = int.Parse(reader["JobID"].ToString());
        //            oItem.ProductDetail = (reader["ProductDetail"].ToString());
        //            oItem.ProductType = int.Parse(reader["ProductType"].ToString());
        //            oItem.ProductTypeName = (reader["ProductTypeName"].ToString());
        //            oItem.Quantity = int.Parse(reader["Quantity"].ToString());
        //            oItem.ProductSize = (reader["ProductSize"].ToString());
        //            oItem.BrandName = (reader["BrandName"].ToString());
        //            oItem.HaveRemortCtrl = int.Parse(reader["HaveRemortCtrl"].ToString());
        //            oItem.HaveRemort = (reader["HaveRemort"].ToString());
        //            oItem.Condition = int.Parse(reader["Condition"].ToString());
        //            oItem.ConditionName = (reader["ConditionName"].ToString());

        //            InnerList.Add(oItem);
        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void RefreshMRByMRNo(string sMoneyReceiptNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferMR where MoneyReceiptNo =?";
                cmd.Parameters.AddWithValue("MoneyReceiptNo", sMoneyReceiptNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMoneyReceiptID = (int)reader["MoneyReceiptID"];
                    _sMoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    _nJobID = (int)reader["JobID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMRAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From dbo.t_ExchangeOfferMR where MoneyReceiptNo= ? and Status=" + (int)Dictionary.ExchangeOfferMRStatus.Active + "";
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMoneyReceiptID = (int)reader["MoneyReceiptID"];
                    _sMoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    _nJobID = (int)reader["JobID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public double GetMRAmount()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "Select * From dbo.t_ExchangeOfferMR where MoneyReceiptNo= ? ";

        //        cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);

        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nMoneyReceiptID = (int)reader["MoneyReceiptID"];
        //            _nJobID = (int)reader["JobID"];
        //            _Amount = Convert.ToDouble(reader["Amount"].ToString());
        //        }

        //        cmd.Dispose();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return _Amount;

        //}

        //public void GETMRData()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_ExchangeOfferMR where MoneyReceiptNo =?";
        //        cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nMoneyReceiptID = (int)reader["MoneyReceiptID"];
        //            _sMoneyReceiptNo = (string)reader["MoneyReceiptNo"];
        //            _nJobID = (int)reader["JobID"];
        //            _nCreateWHID = (int)reader["CreateWHID"];
        //            _nTransferWHID = (int)reader["TransferWHID"];
        //            _nRedeemWHID = (int)reader["RedeemWHID"];
        //            _Amount = (double)reader["Amount"];
        //            _sRemarks = (string)reader["Remarks"];
        //            _nCreateUserID = (int)reader["CreateUserID"];
        //            _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
        //            _nTransferUserID = (int)reader["TransferUserID"];
        //            _dTransferDate = Convert.ToDateTime(reader["TransferDate"].ToString());
        //            _nUpdateUserID = (int)reader["UpdateUserID"];
        //            _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
        //            _nStatus = (int)reader["Status"];
        //            nCount++;
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferMR SET Status = ? WHERE MoneyReceiptNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateMoneyReceipt()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferMR SET Status = ?, RedeemWHID = ? WHERE MoneyReceiptNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RedeemWHID", _nRedeemWHID);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class ExchangeOfferMRs : CollectionBase
    {
        public ExchangeOfferMR this[int i]
        {
            get { return (ExchangeOfferMR)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferMR oExchangeOfferMR)
        {
            InnerList.Add(oExchangeOfferMR);
        }
        public int GetIndex(int nMoneyReceiptID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MoneyReceiptID == nMoneyReceiptID)
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
            string sSql = "SELECT * FROM t_ExchangeOfferMR";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferMR oExchangeOfferMR = new ExchangeOfferMR();
                    oExchangeOfferMR.MoneyReceiptID = (int)reader["MoneyReceiptID"];
                    oExchangeOfferMR.MoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    oExchangeOfferMR.JobID = (int)reader["JobID"];
                    oExchangeOfferMR.CreateWHID = (int)reader["CreateWHID"];
                    oExchangeOfferMR.TransferWHID = (int)reader["TransferWHID"];
                    oExchangeOfferMR.RedeemWHID = (int)reader["RedeemWHID"];
                    oExchangeOfferMR.Amount = (double)reader["Amount"];
                    oExchangeOfferMR.Remarks = (string)reader["Remarks"];
                    oExchangeOfferMR.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferMR.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferMR.TransferUserID = (int)reader["TransferUserID"];
                    oExchangeOfferMR.TransferDate = Convert.ToDateTime(reader["TransferDate"].ToString());
                    oExchangeOfferMR.UpdateUserID = (int)reader["UpdateUserID"];
                    oExchangeOfferMR.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oExchangeOfferMR.Status = (int)reader["Status"];
                    InnerList.Add(oExchangeOfferMR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMR(string sMRNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select * From  " +
                    " (Select MoneyReceiptID,MoneyReceiptNo,a.JobID,JobNo,CreateWHID,CreateWHName,  " +
                    " isnull(TransferWHID,0) TransferWHID,isnull(b.WarehouseName,'') as TransferWHName,  " +
                    " Amount,isnull(a.Remarks,'') as Remarks,a.CreateDate,a.CreateUserID,a.Status,  "+
                    " CustomerName,Address,ContactNo,Email From   " +
                    " (Select MoneyReceiptID,MoneyReceiptNo,JobID,CreateWHID,WarehouseName as CreateWHName,  " +
                    " isnull(TransferWHID,0) TransferWHID,Amount,Remarks,CreateDate,CreateUserID,Status   " +
                    " From t_ExchangeOfferMR a,t_Warehouse b where a.CreateWHID=b.WarehouseID) a  " +
                    " Left Outer Join   " +
                    " (Select * From t_Warehouse) b  " +
                    " on a.TransferWHID=b.WarehouseID  " +
                    " left Outer Join   " +
                    " (Select * From t_ExchangeOfferJob) c  " +
                    " on a.JobID=c.JobID) Main where 1=1";

            }


            if (sMRNo != "")
            {
                sSql = sSql + " AND MoneyReceiptNo like '%" + sMRNo + "%'";
            }
            sSql = sSql + " Order by MoneyReceiptID desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferMR oExchangeOfferMR = new ExchangeOfferMR();
                    oExchangeOfferMR.MoneyReceiptID = (int)reader["MoneyReceiptID"];
                    oExchangeOfferMR.MoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    oExchangeOfferMR.JobID = (int)reader["JobID"];
                    oExchangeOfferMR.JobNo = (string)reader["JobNo"];
                    oExchangeOfferMR.CreateWHID = (int)reader["CreateWHID"];
                    oExchangeOfferMR.CreateWHName = (string)reader["CreateWHName"];
                    oExchangeOfferMR.TransferWHID = (int)reader["TransferWHID"];
                    oExchangeOfferMR.TransferWHName = (string)reader["TransferWHName"];
                    //oExchangeOfferMR.RedeemWHID = (int)reader["RedeemWHID"];
                    oExchangeOfferMR.Amount = (double)reader["Amount"];
                    oExchangeOfferMR.Remarks = (string)reader["Remarks"];
                    oExchangeOfferMR.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferMR.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferMR.Status = (int)reader["Status"];
                    oExchangeOfferMR.CustomerName = (string)reader["CustomerName"];
                    oExchangeOfferMR.Address = (string)reader["Address"];
                    oExchangeOfferMR.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferMR.Email = (string)reader["Email"];
                    InnerList.Add(oExchangeOfferMR);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetMR(int nJobID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select * From  " +
                    " (Select MoneyReceiptID,MoneyReceiptNo,a.JobID,JobNo,CreateWHID,CreateWHName,  " +
                    " isnull(TransferWHID,0) TransferWHID,isnull(b.WarehouseName,'') as TransferWHName,  " +
                    " Amount,isnull(a.Remarks,'') as Remarks,a.CreateDate,a.CreateUserID,a.Status,  "+
                    " CustomerName,Address,ContactNo,Email From   " +
                    " (Select MoneyReceiptID,MoneyReceiptNo,JobID,CreateWHID,WarehouseName as CreateWHName,  " +
                    " isnull(TransferWHID,0) TransferWHID,Amount,Remarks,CreateDate,CreateUserID,Status   " +
                    " From t_ExchangeOfferMR a,t_Warehouse b where a.CreateWHID=b.WarehouseID) a  " +
                    " Left Outer Join   " +
                    " (Select * From t_Warehouse) b  " +
                    " on a.TransferWHID=b.WarehouseID  " +
                    " left Outer Join   " +
                    " (Select * From t_ExchangeOfferJob) c  " +
                    " on a.JobID=c.JobID) Main where JobID= " + nJobID + "";

            }
            sSql = sSql + " Order by MoneyReceiptID desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferMR oExchangeOfferMR = new ExchangeOfferMR();
                    oExchangeOfferMR.MoneyReceiptID = (int)reader["MoneyReceiptID"];
                    oExchangeOfferMR.MoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    oExchangeOfferMR.JobID = (int)reader["JobID"];
                    oExchangeOfferMR.JobNo = (string)reader["JobNo"];
                    oExchangeOfferMR.CreateWHID = (int)reader["CreateWHID"];
                    oExchangeOfferMR.CreateWHName = (string)reader["CreateWHName"];
                    oExchangeOfferMR.TransferWHID = (int)reader["TransferWHID"];
                    oExchangeOfferMR.TransferWHName = (string)reader["TransferWHName"];
                    //oExchangeOfferMR.RedeemWHID = (int)reader["RedeemWHID"];
                    oExchangeOfferMR.Amount = (double)reader["Amount"];
                    oExchangeOfferMR.Remarks = (string)reader["Remarks"];
                    oExchangeOfferMR.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferMR.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferMR.Status = (int)reader["Status"];
                    oExchangeOfferMR.CustomerName = (string)reader["CustomerName"];
                    oExchangeOfferMR.Address = (string)reader["Address"];
                    oExchangeOfferMR.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferMR.Email = (string)reader["Email"];
                    InnerList.Add(oExchangeOfferMR);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetMRforTransfer(DateTime dFromDate, DateTime dToDate, string sMRNo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    " (Select MoneyReceiptID,MoneyReceiptNo,a.JobID,JobNo,CreateWHID,CreateWHName,  " +
                    " isnull(TransferWHID,0) TransferWHID,isnull(b.WarehouseName,'') as TransferWHName,  " +
                    " Amount,isnull(a.Remarks,'') as Remarks,a.CreateDate,a.CreateUserID,a.Status  From   " +
                    " (Select MoneyReceiptID,MoneyReceiptNo,JobID,CreateWHID,WarehouseName as CreateWHName,  " +
                    " isnull(TransferWHID,0) TransferWHID,Amount,Remarks,CreateDate,CreateUserID,Status   " +
                    " From t_ExchangeOfferMR a,t_Warehouse b where a.CreateWHID=b.WarehouseID) a  " +
                    " Left Outer Join   " +
                    " (Select * From t_Warehouse) b  " +
                    " on a.TransferWHID=b.WarehouseID  " +
                    " left Outer Join   " +
                    " (Select * From t_ExchangeOfferJob) c  " +
                    " on a.JobID=c.JobID) Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sMRNo != "")
            {
                sSql = sSql + " AND MoneyReceiptNo like '%" + sMRNo + "%'";
            }
            sSql = sSql + " Order by CreateDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ExchangeOfferMR oExchangeOfferMR = new ExchangeOfferMR();
                    oExchangeOfferMR.MoneyReceiptID = (int)reader["MoneyReceiptID"];
                    oExchangeOfferMR.MoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    oExchangeOfferMR.JobID = (int)reader["JobID"];
                    oExchangeOfferMR.JobNo = (string)reader["JobNo"];
                    oExchangeOfferMR.CreateWHID = (int)reader["CreateWHID"];
                    oExchangeOfferMR.CreateWHName = (string)reader["CreateWHName"];
                    oExchangeOfferMR.TransferWHID = (int)reader["TransferWHID"];
                    oExchangeOfferMR.TransferWHName = (string)reader["TransferWHName"];
                    oExchangeOfferMR.Amount = (double)reader["Amount"];
                    oExchangeOfferMR.Remarks = (string)reader["Remarks"];
                    oExchangeOfferMR.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferMR.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferMR.Status = (int)reader["Status"];
                    InnerList.Add(oExchangeOfferMR);
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

