// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Sep 09, 2015
// Time : 01:47 PM
// Description: Class for SCMOrder.
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
    public class SCMOrderItem
    {
        private int _nOrderID;
        private int _nProductID;
        private int _nOrderQty;
        private int _nPIQty;
        private int _nLCQty;
        private string _sProductCode;
        private string _sProductName;
        private int _nShipmentQty;

        // <summary>
        // Get set property for ShipmentQty
        // </summary>
        public int ShipmentQty
        {
            get { return _nShipmentQty; }
            set { _nShipmentQty = value; }
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
        // Get set property for OrderQty
        // </summary>
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }

        // <summary>
        // Get set property for PIQty
        // </summary>
        public int PIQty
        {
            get { return _nPIQty; }
            set { _nPIQty = value; }
        }

        // <summary>
        // Get set property for LCQty
        // </summary>
        public int LCQty
        {
            get { return _nLCQty; }
            set { _nLCQty = value; }
        }

        public void Add()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SCMOrderItem";
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
                sSql = "INSERT INTO t_SCMOrderItem (OrderID, ProductID, OrderQty, PIQty, LCQty) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddOrder(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_SCMOrderItem (OrderID, ProductID, OrderQty) VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                //cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                //cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddPIQty(int nOrderID, int nExpectedGRDWeek, int nExpectedGRDYear, string sRemarks)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SCMOrderItem (OrderID, ProductID, OrderQty, PIQty, LCQty) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMOrder";
                oSCMProcessHistory.DateID = Convert.ToInt32(nOrderID);
                oSCMProcessHistory.StatusID = (int)Dictionary.SCMStatus.PIReceive;
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
        public void AddLCQty(int nOrderID, int nExpectedGRDWeek, int nExpectedGRDYear, string sRemarks)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SCMOrderItem (OrderID, ProductID, OrderQty, PIQty, LCQty) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMOrder";
                oSCMProcessHistory.DateID = Convert.ToInt32(nOrderID);
                oSCMProcessHistory.StatusID = (int)Dictionary.SCMStatus.LCOpening;
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMOrderItem SET ProductID = ?, OrderQty = ?, PIQty = ?, LCQty = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
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
                sSql = "DELETE FROM t_SCMOrderItem WHERE [OrderID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SCMOrderItem where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nProductID = (int)reader["ProductID"];
                    _nOrderQty = (int)reader["OrderQty"];
                    _nPIQty = (int)reader["PIQty"];
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
    }
    public class SCMOrder : CollectionBase
    {
        public SCMOrderItem this[int i]
        {
            get { return (SCMOrderItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMOrderItem oSCMOrderItem)
        {
            InnerList.Add(oSCMOrderItem);
        }

        private int _nOrderID;
        private string _sOrderNo;
        private DateTime _dOrderPlaceDate;
        private int _nSupplierID;
        private string _sPINo;
        private DateTime _dPIReceiveDate;
        private int _nPSIID;
        private DateTime _dLCProcessingDate;
        private string _sLCNo;
        private DateTime _dLCDate;
        private int _nCurrency;
        private double _LCValue;
        private int _nConcernBankID;
        private string _sHSCode;
        private string _sPreShipmentInspNo;
        private DateTime _dPreShipmentInspDate;
        private int _nStatus;
        private int _nIsLC;



        private string _sRemarks;
        private int _nExpectedGRDWeek;
        private int _nExpectedGRDYear;
        private int _nPendingStatus;
        private int _nIsEqual;
        private string _sPSINo;
        private int _nCompanyID;
        private string _sCompanyName;
        private string _sSupplierName;
        private string _sStatusName;
        private object _dSLCDate;

        // <summary>
        // Get set property for SLCDate
        // </summary>
        public object SLCDate
        {
            get { return _dSLCDate; }
            set { _dSLCDate = value; }
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
        // Get set property for SupplierName
        // </summary>
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }


        // <summary>
        // Get set property for IsEqual
        // </summary>
        public int IsEqual
        {
            get { return _nIsEqual; }
            set { _nIsEqual = value; }
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
        // Get set property for _sPSINo
        // </summary>
        public string PSINo
        {
            get { return _sPSINo; }
            set { _sPSINo = value.Trim(); }
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
        // Get set property for ExpectedGRDYear
        // </summary>
        public int ExpectedGRDYear
        {
            get { return _nExpectedGRDYear; }
            set { _nExpectedGRDYear = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
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
        // Get set property for SupplierID
        // </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
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
            get { return _dPIReceiveDate; }
            set { _dPIReceiveDate = value; }
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
        // Get set property for LCProcessingDate
        // </summary>
        public DateTime LCProcessingDate
        {
            get { return _dLCProcessingDate; }
            set { _dLCProcessingDate = value; }
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
        public DateTime LCDate
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

        // <summary>
        // Get set property for IsLC
        // </summary>
        public int IsLC
        {
            get { return _nIsLC; }
            set { _nIsLC = value; }
        }

        public void Add()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SCMOrder";
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
                sSql = "INSERT INTO t_SCMOrder (OrderID, OrderNo, OrderPlaceDate, SupplierID, PINo, PIReceiveDate, PSIID, LCProcessingDate , LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status, IsLC) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("PINo", _sPINo);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("LCProcessingDate", _dLCProcessingDate);
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

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertOrder()
        {
            int nMaxOrderID = 0;
            int nNextOrderNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SCMOrder";
                cmd.CommandText = sSql;
                object MaxOrderID = cmd.ExecuteScalar();
                if (MaxOrderID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = int.Parse(MaxOrderID.ToString()) + 1;

                }
                _nOrderID = nMaxOrderID;

                string sShortCode = "";
                DateTime dOperationDate;

                sShortCode = "Order";
                dOperationDate = DateTime.Today.Date;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " select NextOrderNo from t_NextSCMPONo ";
                cmd.CommandText = sSql;

                object MaxOrderNo = cmd.ExecuteScalar();
                if (MaxOrderNo == DBNull.Value)
                {
                    nNextOrderNo = 1;
                }
                else
                {
                    nNextOrderNo = int.Parse(MaxOrderNo.ToString());

                }

                _sOrderNo = sShortCode + "-" + dOperationDate.Year.ToString() + "-" + nNextOrderNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SCMOrder (OrderID, OrderNo, OrderPlaceDate, SupplierID, PSIID, Status) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                //cmd.Parameters.AddWithValue("PINo", null);
                //cmd.Parameters.AddWithValue("PIReceiveDate", null);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                //cmd.Parameters.AddWithValue("LCProcessingDate", null);
                //cmd.Parameters.AddWithValue("LCNo", null);
                //cmd.Parameters.AddWithValue("LCDate", null);
                //cmd.Parameters.AddWithValue("Currency", null);
                //cmd.Parameters.AddWithValue("LCValue", null);
                //cmd.Parameters.AddWithValue("ConcernBankID", null);
                //cmd.Parameters.AddWithValue("HSCode", null);
                //cmd.Parameters.AddWithValue("PreShipmentInspNo", null);
                //cmd.Parameters.AddWithValue("PreShipmentInspDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                //cmd.Parameters.AddWithValue("IsLC", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_NextSCMPONo Set NextOrderNo = ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextOrderNo", nNextOrderNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SCMOrderItem oItem in this)
                {
                    oItem.AddOrder(_nOrderID);
                }

                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMOrder";
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
                sSql = "UPDATE t_SCMOrder SET OrderNo = ?, OrderPlaceDate = ?, SupplierID = ?, PINo = ?, PIReceiveDate = ?, PSIID = ?, LCProcessingDate = ?, LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ?, IsLC = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("PINo", _sPINo);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("LCProcessingDate", _dLCProcessingDate);
                
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
                sSql = "DELETE FROM t_SCMOrder WHERE [OrderID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SCMOrder where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    _nSupplierID = (int)reader["SupplierID"];
                    _sPINo = (string)reader["PINo"];
                    _dPIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    _nPSIID = (int)reader["PSIID"];
                    _dLCProcessingDate = Convert.ToDateTime(reader["LCProcessingDate"].ToString());
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
        public void RefreshIsPSIQtyEqual(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSIID,IsEqual From "+
                                " (Select PSIID,PSIQty,OrderQty,(PSIQty-OrderQty) IsEqual From "+
                                " (Select x.PSIID,PSIQty,isnull (OrderQty,0) OrderQty From "+
                                " (Select PSIID,sum (PSIQty) PSIQty From t_SCMPSIItem "+
                                " group by PSIID) x "+
                                " Left Outer Join  "+
                                " (Select PSIID,sum (OrderQty) OrderQty From t_SCMOrder a,t_SCMOrderItem b  "+
                                " where a.OrderID=b.OrderID group by PSIID) y " +
                                " on x.PSIID=y.PSIID) x ) xx where PSIID = ?";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nIsEqual = (int)reader["IsEqual"];
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
        public void RefreshPendingOrderStatus(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSIID,PendingStatus from  "+
                                "(Select PSIID,(AllStatus-PIStatus) PendingStatus From  "+
                                "(Select x.PSIID,AllStatus,isnull (PIStatus,0) PIStatus From   "+
                                "(Select PSIID,count(Status) as AllStatus From t_SCMOrder where Status in (1,2,3)    " +
                                "group by PSIID) x  "+
                                "Left Outer Join   "+
                                "(Select PSIID,count(Status) as PIStatus From t_SCMOrder where Status=3  "+
                                "group by PSIID) y  " +
                                "on x.PSIID=y.PSIID) xxx ) yyy where PSIID= ? ";

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
        public void RefreshPSI(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT PSIID,Status FROM t_SCMPSI where PSIID =?";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
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
        //public void GetOrderItem(int nOrderID)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText = " Select a.OrderId,b.ProductID,ProductCode,ProductName,OrderQty,PIQty,LCQty "+
        //                          " From t_SCMOrder a,t_SCMOrderItem b,v_PRoductDetails c " +
        //                          " where a.OrderID=b.OrderID and b.ProductID=c.ProductID and a.OrderID = ? ";

        //        cmd.Parameters.AddWithValue("OrderId", nOrderID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            SCMOrderItem oItem = new SCMOrderItem();

        //            oItem.OrderID = int.Parse(reader["OrderID"].ToString());
        //            oItem.ProductID = int.Parse(reader["ProductID"].ToString());
        //            oItem.ProductCode = (reader["ProductCode"].ToString());
        //            oItem.ProductName = (reader["ProductName"].ToString());
        //            oItem.OrderQty = int.Parse(reader["OrderQty"].ToString());
        //            oItem.PIQty = int.Parse(reader["PIQty"].ToString());
        //            oItem.LCQty = int.Parse(reader["LCQty"].ToString());
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




        public void GetOrderItem(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select OrderID,ProductID,ProductCode,ProductName,OrderQty, " +
                                  "  sum (PIQty) as PIQty From       " +
                                  " (Select a.OrderId,a.ProductID,ProductCode,ProductName,       " +
                                  " OrderQty,isnull (PIQty,0) PIQty From         " +
                                  " (Select * From  " +
                                  " (Select a.OrderId,b.ProductID,ProductCode,ProductName,OrderQty " +
                                  " From t_SCMOrder a,t_SCMOrderItem b,v_PRoductDetails c  " +
                                  " where a.OrderID=b.OrderID and b.ProductID=c.ProductID) x) a       " +
                                  " Left Outer Join      " +
                                  " (Select OrderID,ProductID,isnull (PIQty,0) PIQty,isnull (LCQty,0) LCQty From t_SCMPI a,t_SCMPIItem b       " +
                                  " where a.PIID=b.PIID) b       " +
                                  " on a.OrderID=b.OrderID and a.ProductID=b.ProductID ) a where OrderQty<>PIQty and OrderID = ?     " +
                                  " group by OrderID,ProductID,ProductCode,ProductName,OrderQty ";

                cmd.Parameters.AddWithValue("OrderId", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMOrderItem oItem = new SCMOrderItem();

                    oItem.OrderID = int.Parse(reader["OrderID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.OrderQty = int.Parse(reader["OrderQty"].ToString());
                    oItem.PIQty = int.Parse(reader["PIQty"].ToString());
                    //oItem.LCQty = int.Parse(reader["LCQty"].ToString());
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
        //public void GetShipmentItem(int nOrderID)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText = "Select OrderId,ProductID,ProductCode,ProductName,OrderQty,PIQty,LCQty,sum(ShipmentQty) ShipmentQty  From  "+
        //                       " (Select a.*,isnull (ShipmentQty,0) ShipmentQty From   "+
        //                       " (Select * From  "+
        //                       " (Select a.OrderId,b.ProductID,ProductCode,ProductName,OrderQty,PIQty,LCQty   "+
        //                       " From t_SCMOrder a,t_SCMOrderItem b,v_PRoductDetails c  "+
        //                       " where a.OrderID=b.OrderID and b.ProductID=c.ProductID ) a) a  "+
        //                       " Left Outer Join   "+
        //                       " (Select OrderID,ProductID,ShipmentQty From t_SCMShipment a,t_SCMShipmentItem b where   "+
        //                       " a.ShipmentID=b.ShipmentID) b  "+
        //                       " on a.OrderID=b.OrderID and a.ProductID=b.ProductID  "+
        //                       " ) x where LCQty<>ShipmentQty  and OrderID=?   " +
        //                       " Group  by OrderId,ProductID,ProductCode,ProductName,OrderQty,PIQty,LCQty";

        //        cmd.Parameters.AddWithValue("OrderId", nOrderID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            SCMOrderItem oItem = new SCMOrderItem();

        //            oItem.OrderID = int.Parse(reader["OrderID"].ToString());
        //            oItem.ProductID = int.Parse(reader["ProductID"].ToString());
        //            oItem.ProductCode = (reader["ProductCode"].ToString());
        //            oItem.ProductName = (reader["ProductName"].ToString());
        //            oItem.OrderQty = int.Parse(reader["OrderQty"].ToString());
        //            oItem.PIQty = int.Parse(reader["PIQty"].ToString());
        //            oItem.LCQty = int.Parse(reader["LCQty"].ToString());
        //            oItem.ShipmentQty = int.Parse(reader["ShipmentQty"].ToString());
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


        public void UpdatePIInfo(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMOrder SET PINo = ?, PIReceiveDate = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PINo", _sPINo);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusOrder()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMOrder Set Status = ? Where OrderID=? ";
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
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMOrder Set Status = ? Where OrderID=? ";
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
        public void UpdateStatusPSI(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMPSI Set Status = ? Where PSIID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.SCMStatus.PIReceive);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void UpdateLCProcessingDate(int nOrderID, int nExpectedGRDWeek, int nExpectedGRDYear, string sRemarks)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText  = "UPDATE t_SCMOrder SET LCProcessingDate = ?, Status = ? WHERE OrderID = ?";
        //        cmd.CommandType = CommandType.Text;


        //        cmd.Parameters.AddWithValue("LCProcessingDate", _dLCProcessingDate);
        //        cmd.Parameters.AddWithValue("Status", _nStatus);

        //        cmd.Parameters.AddWithValue("OrderID", nOrderID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();


        //        cmd = DBController.Instance.GetCommand();

        //        SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
        //        oSCMProcessHistory.TableName = "t_SCMOrder";
        //        oSCMProcessHistory.DateID = Convert.ToInt32(nOrderID);
        //        oSCMProcessHistory.StatusID = _nStatus;
        //        oSCMProcessHistory.ExpectedGRDWeek = nExpectedGRDWeek;
        //        oSCMProcessHistory.ExpectedGRDYear = nExpectedGRDYear;
        //        oSCMProcessHistory.Remarks = sRemarks;
        //        oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

        //        oSCMProcessHistory.Add();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public void UpdateLCInfo(int nOrderID)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "UPDATE t_SCMOrder SET LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ? , IsLC = ? WHERE OrderID = ?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("LCNo", _sLCNo);
        //        cmd.Parameters.AddWithValue("LCDate", _dLCDate);
        //        cmd.Parameters.AddWithValue("Currency", _nCurrency);
        //        cmd.Parameters.AddWithValue("LCValue", _LCValue);
        //        cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
        //        cmd.Parameters.AddWithValue("HSCode", _sHSCode);
        //        cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
        //        cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
        //        cmd.Parameters.AddWithValue("Status", _nStatus);
        //        cmd.Parameters.AddWithValue("IsLC", (int)Dictionary.IsLC.LC);

        //        cmd.Parameters.AddWithValue("OrderID", nOrderID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //public void UpdateNONLCInfo(int nOrderID)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "UPDATE t_SCMOrder SET Status = ? , IsLC = ? WHERE OrderID = ?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;


        //        cmd.Parameters.AddWithValue("Status", _nStatus);
        //        cmd.Parameters.AddWithValue("IsLC", (int)Dictionary.IsLC.NOLC);

        //        cmd.Parameters.AddWithValue("OrderID", nOrderID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
    public class SCMOrders : CollectionBase
    {
        public SCMOrder this[int i]
        {
            get { return (SCMOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMOrder oSCMOrder)
        {
            InnerList.Add(oSCMOrder);
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
            string sSql = "SELECT * FROM t_SCMOrder";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMOrder oSCMOrder = new SCMOrder();
                    oSCMOrder.OrderID = (int)reader["OrderID"];
                    oSCMOrder.OrderNo = (string)reader["OrderNo"];
                    oSCMOrder.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    oSCMOrder.SupplierID = (int)reader["SupplierID"];
                    oSCMOrder.PINo = (string)reader["PINo"];
                    oSCMOrder.PIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    oSCMOrder.PSIID = (int)reader["PSIID"];
                    oSCMOrder.LCNo = (string)reader["LCNo"];
                    oSCMOrder.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMOrder.Currency = (int)reader["Currency"];
                    oSCMOrder.LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    oSCMOrder.ConcernBankID = (int)reader["ConcernBankID"];
                    oSCMOrder.HSCode = (string)reader["HSCode"];
                    oSCMOrder.PreShipmentInspNo = (string)reader["PreShipmentInspNo"];
                    oSCMOrder.PreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
                    oSCMOrder.Status = (int)reader["Status"];
                    oSCMOrder.IsLC = (int)reader["IsLC"];
                    InnerList.Add(oSCMOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOrder(DateTime dFromDate, DateTime dToDate, int nStatus, int nCompany, string sPSINo, bool IsCheck, int nSupplier, string sOrderNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select a.PSIID,PSINo,ExpectedHOArrivalWeek,ExpectedHOArrivalYear,OrderID,OrderNo,OrderPlaceDate,b.Company,CompanyName,a.SupplierID,SupplierName,a.Status, " +
                       " StatusName=CASE When a.Status=1 then 'PSI' When a.Status=2 then 'OrderPlace'      "+
                       " When a.Status=3 then 'PIReceive' When a.Status=4 then 'LCProcessing'   "+
                       " When a.Status=5 then 'LCOpening' When a.Status=6 then 'Shipment'  "+
                       " When a.Status=7 then 'CustomerClearance' When a.Status=8 then 'Release'     "+
                       " When a.Status=9 then 'ReadyForGRD' When a.Status=10 then 'Billing'   "+
                       " else 'Others' end From t_SCMOrder a,t_SCMPSI b,t_Company c,t_Supplier d  " +
                       " where a.PSIID=b.PSIID and b.Company=c.CompanyID and a.SupplierID=d.SupplierID and 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND OrderPlaceDate between '" + dFromDate + "' and '" + dToDate + "' and OrderPlaceDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (sPSINo != "")
            {
                sSql = sSql + " AND PSINo like '%" + sPSINo + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND b.Company=" + nCompany + "";
            }
            if (nSupplier != -1)
            {
                sSql = sSql + " AND a.SupplierID=" + nSupplier + "";
            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }

            sSql = sSql + " Order by OrderNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMOrder oSCMOrder = new SCMOrder();

                    oSCMOrder.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMOrder.PSINo = (reader["PSINo"].ToString());
                    oSCMOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMOrder.OrderNo = (reader["OrderNo"].ToString());
                    oSCMOrder.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    oSCMOrder.CompanyID = int.Parse(reader["Company"].ToString());
                    oSCMOrder.CompanyName = (reader["CompanyName"].ToString());
                    oSCMOrder.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSCMOrder.SupplierName = (reader["SupplierName"].ToString());
                    oSCMOrder.Status = int.Parse(reader["Status"].ToString());
                    oSCMOrder.StatusName = (reader["StatusName"].ToString());
                    oSCMOrder.ExpectedGRDWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMOrder.ExpectedGRDYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    //if (reader["PINo"] != DBNull.Value)
                    //    oSCMOrder.PINo = reader["PINo"].ToString();
                    //else oSCMOrder.PINo = "";

                    InnerList.Add(oSCMOrder);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetShipmentableLC(DateTime dFromDate, DateTime dToDate, string sPINO, string sOrderNO, string sLCNO,string sPSINO,int nCompany, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select isnull (LCNo,'NonLC') LCNo,isnull (LCDate, PIReceiveDate) LCDate,PIID,PINo, "+
                       " a.OrderID,OrderNo,OrderPlaceDate,c.PSIID,PSINo,ExpectedHOArrivalWeek,ExpectedHOArrivalYear, CompanyID,CompanyName, "+
                       " a.Status,StatusName=CASE When c.Status=1 then 'PSI' When c.Status=2 then 'OrderPlace'       "+
                       " When c.Status=3 then 'PIReceive' When c.Status=4 then 'LCProcessing'   "+
                       " When c.Status=5 then 'LCOpening' When c.Status=6 then 'Shipment'   "+
                       " When c.Status=7 then 'CustomerClearance' When c.Status=8 then 'Release'   "+
                       " When c.Status=9 then 'ReadyForGRD' When c.Status=10 then 'Billing'   "+
                       " else 'Others' end From t_SCMPI a,t_SCMOrder b,t_SCMPSI c,t_Company d " +
                       " where a.OrderID=b.OrderiD and b.PSIID=c.PSIID and c.Company=d.CompanyID ";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND LCDate between '" + dFromDate + "' and '" + dToDate + "' and LCDate<'" + dToDate + "' ";
            }

            if (sPINO != "")
            {
                sSql = sSql + " AND PINO like '%" + sPINO + "%'";
            }
            if (sOrderNO != "")
            {
                sSql = sSql + " AND OrderNO like '%" + sOrderNO + "%'";
            }
            if (sLCNO != "")
            {
                sSql = sSql + " AND LCNo like '%" + sLCNO + "%'";
            }
            if (sPSINO != "")
            {
                sSql = sSql + " AND PSINO like '%" + sPSINO + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID=" + nCompany + "";
            }
            sSql = sSql + " Order by PIID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMOrder oSCMOrder = new SCMOrder();

                    oSCMOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMOrder.OrderNo = (reader["OrderNo"].ToString());
                    oSCMOrder.PINo = (reader["PINo"].ToString());
                    oSCMOrder.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    if (reader["LCNo"] != DBNull.Value)
                        oSCMOrder.LCNo = (reader["LCNo"].ToString());
                    else oSCMOrder.LCNo = "'NonLC'";
                    oSCMOrder.SLCDate = (object)reader["LCDate"].ToString();
                    oSCMOrder.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMOrder.PSINo = (reader["PSINo"].ToString());
                    oSCMOrder.ExpectedGRDWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMOrder.ExpectedGRDYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMOrder.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    oSCMOrder.CompanyName = (reader["CompanyName"].ToString());
                    oSCMOrder.Status = int.Parse(reader["Status"].ToString());
                    oSCMOrder.StatusName = (reader["StatusName"].ToString());

                    InnerList.Add(oSCMOrder);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshOrderForPI(DateTime dFromDate, DateTime dToDate,int nCompany, string sPSINo, bool IsCheck, int nSupplier, string sOrderNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select a.PSIID,PSINo,ExpectedHOArrivalWeek,ExpectedHOArrivalYear,OrderID,OrderNo,OrderPlaceDate,b.Company,CompanyName,a.SupplierID,SupplierName,a.Status, " +
                       " StatusName=CASE When a.Status=1 then 'PSI' When a.Status=2 then 'OrderPlace'      " +
                       " When a.Status=3 then 'PIReceive' When a.Status=4 then 'LCProcessing'   " +
                       " When a.Status=5 then 'LCOpening' When a.Status=6 then 'Shipment'  " +
                       " When a.Status=7 then 'CustomerClearance' When a.Status=8 then 'Release'     " +
                       " When a.Status=9 then 'ReadyForGRD' When a.Status=10 then 'Billing'   " +
                       " else 'Others' end From t_SCMOrder a,t_SCMPSI b,t_Company c,t_Supplier d  " +
                       " where a.PSIID=b.PSIID and b.Company=c.CompanyID and a.SupplierID=d.SupplierID and a.Status=2 and 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND OrderPlaceDate between '" + dFromDate + "' and '" + dToDate + "' and OrderPlaceDate<'" + dToDate + "' ";
            }

            //if (nStatus != -1)
            //{
            //    sSql = sSql + " AND a.Status=" + nStatus + "";
            //}
            if (sPSINo != "")
            {
                sSql = sSql + " AND PSINo like '%" + sPSINo + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND b.Company=" + nCompany + "";
            }
            if (nSupplier != -1)
            {
                sSql = sSql + " AND a.SupplierID=" + nSupplier + "";
            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }

            sSql = sSql + " Order by OrderNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMOrder oSCMOrder = new SCMOrder();

                    oSCMOrder.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMOrder.PSINo = (reader["PSINo"].ToString());
                    oSCMOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMOrder.OrderNo = (reader["OrderNo"].ToString());
                    oSCMOrder.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    oSCMOrder.CompanyID = int.Parse(reader["Company"].ToString());
                    oSCMOrder.CompanyName = (reader["CompanyName"].ToString());
                    oSCMOrder.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSCMOrder.SupplierName = (reader["SupplierName"].ToString());
                    oSCMOrder.Status = int.Parse(reader["Status"].ToString());
                    oSCMOrder.StatusName = (reader["StatusName"].ToString());
                    oSCMOrder.ExpectedGRDWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMOrder.ExpectedGRDYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    //if (reader["PINo"] != DBNull.Value)
                    //    oSCMOrder.PINo = reader["PINo"].ToString();
                    //else oSCMOrder.PINo = "";

                    InnerList.Add(oSCMOrder);

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