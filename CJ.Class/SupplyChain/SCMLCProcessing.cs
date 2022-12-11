// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Aug 31, 2015
// Time : 01:01 PM
// Description: Class for SCMLCItem.
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
    public class SCMLCItem
    {
        private int _nOrderID;
        private int _nProductID;
        private int _nPIQty;
        private int _nLCProcessingQty;
        private int _nLCQty;
        private int _nPreviousLCProcessingQty;
        private int _nPSIID;
        private string _sProductCode;
        private string _sProductName;


        //private int _nOrderID;
        //private int _nProductID;
        private int _nOrderQty;
        //private int _nPIQty;
        //private int _nLCQty;


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



        // <summary>
        // Get set property for PSIID
        // </summary>
        public int PSIID
        {
            get { return _nPSIID; }
            set { _nPSIID = value; }
        }


        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
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
        // Get set property for OrderID
        // </summary>
        public int PIQty
        {
            get { return _nPIQty; }
            set { _nPIQty = value; }
        }

        // <summary>
        // Get set property for LCProcessingQty
        // </summary>
        public int LCProcessingQty
        {
            get { return _nLCProcessingQty; }
            set { _nLCProcessingQty = value; }
        }


        // <summary>
        // Get set property for PreviousLCProcessingQty
        // </summary>
        public int PreviousLCProcessingQty
        {
            get { return _nPreviousLCProcessingQty; }
            set { _nPreviousLCProcessingQty = value; }
        }

        // <summary>
        // Get set property for LCQty
        // </summary>
        public int LCQty
        {
            get { return _nLCQty; }
            set { _nLCQty = value; }
        }

        public void Add(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SCMLCItem (OrderID, ProductID, LCProcessingQty, LCQty) VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("LCProcessingQty", _nLCProcessingQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddLCQty(int nOrderID, int nExpectedGRDWeek, int nExpectedGRDYear, string sRemarks)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SCMLCItem (OrderID, ProductID, LCProcessingQty, LCQty) VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("LCProcessingQty", _nLCProcessingQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMLC";
                oSCMProcessHistory.DateID = Convert.ToInt32(_nOrderID);
                //oSCMProcessHistory.StatusID = (int)Dictionary.SCMStatus.LCOpening;
                oSCMProcessHistory.ExpectedGRDWeek = nExpectedGRDWeek;
                oSCMProcessHistory.ExpectedGRDYear = nExpectedGRDYear;
                oSCMProcessHistory.Remarks = sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oSCMProcessHistory.Add();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update(int nOrderID,int nLCQty)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SCMLCItem SET LCProcessingQty=LCProcessingQty + " + nLCQty + " where OrderID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                //cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("LCProcessingQty", _nLCProcessingQty);

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
                sSql = "UPDATE t_SCMLCItem SET ProductID = ?, LCProcessingQty = ?, LCQty = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("LCProcessingQty", _nLCProcessingQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

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
                sSql = "DELETE FROM t_SCMLCItem WHERE [OrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
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
                cmd.CommandText = "SELECT * FROM t_SCMLCItem where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nProductID = (int)reader["ProductID"];
                    _nLCProcessingQty = (int)reader["LCProcessingQty"];
                    _nLCQty = (int)reader["LCQty"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckLCProcessingItem(int nPSIID, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * from t_SCMPSI a,t_SCMLC b,t_SCMLCITem c  "+                         
                          "where a.PSIID=b.PSIID and b.OrderID=c.OrderID and a.PSIID=? and ProductID= ?";

            cmd.Parameters.AddWithValue("PSIID", nPSIID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);

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

    }
    public class SCMLC : CollectionBase
    {
        public SCMLCItem this[int i]
        {
            get { return (SCMLCItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMLCItem oSCMLCItem)
        {
            InnerList.Add(oSCMLCItem);
        }

        private int _nOrderID;
        private int _nPSIID;
        private DateTime _dOrderPlaceDate;
        private string _sLCNo;
        private object _dLCDate;
        private int _nCurrency;
        private double _LCValue;
        private int _nConcernBankID;
        private string _sHSCode;
        private string _sPreShipmentInspNo;
        private DateTime _dPreShipmentInspDate;
        private int _nStatus;
        private int _nIsLC;

        private int _nExpectedGRDWeek;
        private int _nExpectedGRDYear;
        private string _sRemarks;
        private string _sRefNo;
        private DateTime _dtPODate;
        private int _nCompanyID;
        private string _sCompanyName;
        private int _nSupplierID;
        private string _sSupplierName;
        private string _sPINo;
        private DateTime _dtPIReceiveDate;
        private string _sStatusName;
        private int _nPendingStatus;


        // <summary>
        // Get set property for IsLC
        // </summary>
        public int IsLC
        {
            get { return _nIsLC; }
            set { _nIsLC = value; }
        }
        


        // <summary>
        // Get set property for PendingStatus
        // </summary>
        public int PendingStatus
        {
            get { return _nPendingStatus; }
            set { _nPendingStatus = value; }
        }
        

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }


        // <summary>
        // Get set property for PINo
        // </summary>
        public string PINo
        {
            get { return _sPINo; }
            set { _sPINo = value.Trim(); }
        }

        // <summary>
        // Get set property for PIReceiveDate
        // </summary>
        public DateTime PIReceiveDate
        {
            get { return _dtPIReceiveDate; }
            set { _dtPIReceiveDate = value; }
        }



        // <summary>
        // Get set property for SupplierID
        // </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }



        // <summary>
        // Get set property for SupplierName
        // </summary>
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }

        

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }



        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }

        // <summary>
        // Get set property for PODate
        // </summary>
        public DateTime PODate
        {
            get { return _dtPODate; }
            set { _dtPODate = value; }
        }



        // <summary>
        // Get set property for RefNo
        // </summary>
        public string RefNo
        {
            get { return _sRefNo; }
            set { _sRefNo = value.Trim(); }
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
        // Get set property for ExpectedGRDWeek
        // </summary>
        public int ExpectedGRDWeek
        {
            get { return _nExpectedGRDWeek; }
            set { _nExpectedGRDWeek = value; }
        }
        // <summary>
        // Get set property for ExpectedGRDYear
        // </summary>
        public int ExpectedGRDYear
        {
            get { return _nExpectedGRDYear; }
            set { _nExpectedGRDYear = value; }
        }


        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for PSIID
        // </summary>
        public int PSIID
        {
            get { return _nPSIID; }
            set { _nPSIID = value; }
        }

        // <summary>
        // Get set property for OrderPlaceDate
        // </summary>
        public DateTime OrderPlaceDate
        {
            get { return _dOrderPlaceDate; }
            set { _dOrderPlaceDate = value; }
        }

        // <summary>
        // Get set property for LCNo
        // </summary>
        public string LCNo
        {
            get { return _sLCNo; }
            set { _sLCNo = value.Trim(); }
        }

        // <summary>
        // Get set property for LCDate
        // </summary>
        public object LCDate
        {
            get { return _dLCDate; }
            set { _dLCDate = value; }
        }

        // <summary>
        // Get set property for Currency
        // </summary>
        public int Currency
        {
            get { return _nCurrency; }
            set { _nCurrency = value; }
        }

        // <summary>
        // Get set property for LCValue
        // </summary>
        public double LCValue
        {
            get { return _LCValue; }
            set { _LCValue = value; }
        }

        // <summary>
        // Get set property for ConcernBankID
        // </summary>
        public int ConcernBankID
        {
            get { return _nConcernBankID; }
            set { _nConcernBankID = value; }
        }

        // <summary>
        // Get set property for HSCode
        // </summary>
        public string HSCode
        {
            get { return _sHSCode; }
            set { _sHSCode = value.Trim(); }
        }

        // <summary>
        // Get set property for PreShipmentInspNo
        // </summary>
        public string PreShipmentInspNo
        {
            get { return _sPreShipmentInspNo; }
            set { _sPreShipmentInspNo = value.Trim(); }
        }

        // <summary>
        // Get set property for PreShipmentInspDate
        // </summary>
        public DateTime PreShipmentInspDate
        {
            get { return _dPreShipmentInspDate; }
            set { _dPreShipmentInspDate = value; }
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
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SCMLC";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderID = nMaxOrderID;
                sSql = "INSERT INTO t_SCMLC (OrderID, PSIID, OrderPlaceDate, LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status , IsLC) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("Currency", null);
                cmd.Parameters.AddWithValue("LCValue", null);
                cmd.Parameters.AddWithValue("ConcernBankID", null);
                cmd.Parameters.AddWithValue("HSCode", null);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", null);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", (int)Dictionary.IsLC.LC);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SCMLCItem oItem in this)
                {

                    oItem.Add(_nOrderID);
                }


                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMLC";
                oSCMProcessHistory.DateID = Convert.ToInt32(_nOrderID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedGRDWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedGRDYear);
                oSCMProcessHistory.Remarks = _sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oSCMProcessHistory.Add();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddNONLC()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SCMLC";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderID = nMaxOrderID;
                sSql = "INSERT INTO t_SCMLC (OrderID, PSIID, OrderPlaceDate, LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status ,IsLC) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("OrderPlaceDate", DateTime.Now);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("Currency", null);
                cmd.Parameters.AddWithValue("LCValue", null);
                cmd.Parameters.AddWithValue("ConcernBankID", null);
                cmd.Parameters.AddWithValue("HSCode", null);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", null);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", (int)Dictionary.IsLC.NONLC);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SCMLCItem oItem in this)
                {

                    oItem.Add(_nOrderID);
                }


                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMLC";
                oSCMProcessHistory.DateID = Convert.ToInt32(_nOrderID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedGRDWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedGRDYear);
                oSCMProcessHistory.Remarks = _sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oSCMProcessHistory.Add();
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
                sSql = "UPDATE t_SCMLC SET PSIID = ?, OrderPlaceDate = ?, LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ? , IsLC = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("LCValue", _LCValue);
                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", _nIsLC);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

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
                sSql = "DELETE FROM t_SCMLC WHERE [OrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
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
                cmd.CommandText = "SELECT * FROM t_SCMLC where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nPSIID = (int)reader["PSIID"];
                    _dOrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    _sLCNo = (string)reader["LCNo"];
                    _dLCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    _nCurrency = (int)reader["Currency"];
                    _LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    _nConcernBankID = (int)reader["ConcernBankID"];
                    _sHSCode = (string)reader["HSCode"];
                    _sPreShipmentInspNo = (string)reader["PreShipmentInspNo"];
                    _dPreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _nIsLC = (int)reader["IsLC"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusPO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMPSI Set Status = ? Where PSIID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusLC()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMLC Set Status = ? Where OrderID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateLCInfo(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMLC SET LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("LCValue", _LCValue);
                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLCItem(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select PSIID,OrderID,ProductID,ProductCode,ProductName,Quantity, " +
                                " sum (LCProcessingQty) as LCProcessingQty,sum (LCQty) as LCQty From  " +
                                "(Select a.PSIID,OrderID,LCDate,a.ProductID,ProductCode,ProductName,Quantity,  " +
                                "isnull (LCProcessingQty,0)LCProcessingQty ,isnull (LCQty,0) LCQty From    " +
                                "(Select * From    " +
                                "(Select a.PSIID,b.ProductID,ProductCode,ProductName,Quantity   " +
                                "from t_SCMPSI a, t_SCMPSIItem b,v_ProductDetails c   " +
                                "where a.PSIID=b.PSIID and b.ProductID=c.ProductID) x) a    " +
                                "Left Outer Join    " +
                                "(Select a.OrderID,LCDate,PSIID,ProductID,LCProcessingQty,LCQty From t_SCMLC a,t_SCMLCITem b    " +
                                "where a.OrderID=b.OrderID) b   " +
                                "on a.PSIID=b.PSIID and a.ProductID=b.ProductID ) a where OrderID= ? " +
                                "group by PSIID,OrderID,ProductID,ProductCode,ProductName,Quantity ";


                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMLCItem oItem = new SCMLCItem();

                    oItem.PSIID = int.Parse(reader["PSIID"].ToString());
                    oItem.OrderID = int.Parse(reader["OrderID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.PIQty = int.Parse(reader["Quantity"].ToString());
                    oItem.LCProcessingQty = int.Parse(reader["LCProcessingQty"].ToString());
                    oItem.LCQty = int.Parse(reader["LCQty"].ToString());
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
        //public void OrderPlaceUpdate()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    try
        //    {
        //        cmd.CommandText = "Update t_SCMPSI set OrderPlaceDate = ? where PSIID=? ";
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);

        //        cmd.Parameters.AddWithValue("PSIID", _nPSIID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();


        //        cmd = DBController.Instance.GetCommand();
        //        SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
        //        oSCMProcessHistory.TableName = "t_SCMPSI";
        //        oSCMProcessHistory.DateID = Convert.ToInt32(_nPSIID);
        //        oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
        //        oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedHOArrivalWeek);
        //        oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedHOArrivalYear);
        //        oSCMProcessHistory.Remarks = _sRemarks;
        //        oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

        //        oSCMProcessHistory.Add();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public void RefreshPendingStatus(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSIID,PendingStatus From  " +
                                "(Select PSIID,LCPRocessingStatus,LCOpenStatus,(LCPRocessingStatus-LCOpenStatus) as PendingStatus From   " +
                                "(Select a.PSIID,LCPRocessingStatus,isnull (LCOpenStatus,0) LCOpenStatus From   " +
                                "(Select PSIID,Count(isnull(Status,0)) LCPRocessingStatus From t_SCMLC  group by PSIID) a  " +
                                "left Outer join   " +
                                "(Select PSIID, Count(isnull(Status,0)) LCOpenStatus From t_SCMLC where Status=5  " +
                                "group by PSIID) b  " +
                                "on a.PSIID=b.PSIID) x) xx where PSIID=? ";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nPendingStatus = (int)reader["PendingStatus"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SCMLCs : CollectionBase
    {
        public SCMLC this[int i]
        {
            get { return (SCMLC)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMLC oSCMLC)
        {
            InnerList.Add(oSCMLC);
        }
        public int GetIndex(int nOrderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OrderID == nOrderID)
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
            string sSql = "SELECT * FROM t_SCMLC";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMLC oSCMLC = new SCMLC();
                    oSCMLC.OrderID = (int)reader["OrderID"];
                    oSCMLC.PSIID = (int)reader["PSIID"];
                    oSCMLC.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    oSCMLC.LCNo = (string)reader["LCNo"];
                    oSCMLC.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMLC.Currency = (int)reader["Currency"];
                    oSCMLC.LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    oSCMLC.ConcernBankID = (int)reader["ConcernBankID"];
                    oSCMLC.HSCode = (string)reader["HSCode"];
                    oSCMLC.PreShipmentInspNo = (string)reader["PreShipmentInspNo"];
                    oSCMLC.PreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
                    oSCMLC.Status = (int)reader["Status"];
                    oSCMLC.IsLC = (int)reader["IsLC"];
                    InnerList.Add(oSCMLC);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshLC(int nPSIID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {
                sSql = " Select a.PSIID,RefNo,OrderID,OrderPlaceDate,LCNo,LCDate,Currency,  " +
                       " ConcernBankID,HSCode,PreShipmentInspNo,CreateDate,ExpectedHOArrivalWeek,ExpectedHOArrivalYear, " +
                       " Company,CompanyName,a.SupplierID,SupplierName,PINo,PIReceiveDate,d.Status,  "+
                       " StatusName=CASE When d.Status=1 then 'PSI' When d.Status=2 then 'OrderPlace'  " +
                       " When d.Status=3 then 'PIReceive' When d.Status=4 then 'LCProcessing'   " +
                       " When d.Status=5 then 'LCOpening' When d.Status=6 then 'Shipment'  " +
                       " When d.Status=7 then 'CustomerClearance' When d.Status=8 then 'Release'  " +
                       " When d.Status=9 then 'ReadyForGRD' When d.Status=10 then 'Billing'   " +
                       " else 'Others' end From t_SCMPSI a,t_Company b,t_Supplier c ,t_SCMLC d "+
                       " where a.Company=b.CompanyID and a.SupplierID=c.SupplierID and a.PSIID=d.PSIID and 1=1 ";

            }
            if (nPSIID != -1)
            {
                sSql = sSql + " AND a.PSIID =" + nPSIID + "";
            }
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMLC oSCMLC = new SCMLC();

                    oSCMLC.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMLC.RefNo = (reader["RefNo"].ToString());
                    oSCMLC.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMLC.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());

                    if (reader["LCNo"] != DBNull.Value)
                        oSCMLC.LCNo = reader["LCNo"].ToString();
                    else oSCMLC.LCNo = "";
                    oSCMLC.LCDate = (object)reader["PIReceiveDate"].ToString();
                    if (reader["Currency"] != DBNull.Value)
                        oSCMLC.Currency = int.Parse(reader["Currency"].ToString());
                    else oSCMLC.Currency = -1;

                    //oSCMLC.LCValue =Convert.ToDouble(reader["LCValue"].ToString());

                    if (reader["ConcernBankID"] != DBNull.Value)
                        oSCMLC.ConcernBankID = int.Parse(reader["ConcernBankID"].ToString());
                    else oSCMLC.ConcernBankID = -1;

                    if (reader["HSCode"] != DBNull.Value)
                        oSCMLC.HSCode = reader["HSCode"].ToString();
                    else oSCMLC.HSCode = "";

                    if (reader["PreShipmentInspNo"] != DBNull.Value)
                    oSCMLC.PreShipmentInspNo = reader["PreShipmentInspNo"].ToString();
                    else oSCMLC.PreShipmentInspNo = "";

                    oSCMLC.PODate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSCMLC.ExpectedGRDWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMLC.ExpectedGRDYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMLC.CompanyID = int.Parse(reader["Company"].ToString());
                    oSCMLC.CompanyName = (reader["CompanyName"].ToString());
                    oSCMLC.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSCMLC.SupplierName = (reader["SupplierName"].ToString());
                    oSCMLC.PINo = (reader["PINo"].ToString());
                    oSCMLC.PIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    oSCMLC.Status = int.Parse(reader["Status"].ToString());
                    oSCMLC.StatusName = (reader["StatusName"].ToString());

                    InnerList.Add(oSCMLC);

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





