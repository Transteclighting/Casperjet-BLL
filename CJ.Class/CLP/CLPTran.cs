// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 05, 2012
// Time :  03:00 PM
// Description: Class for CLP Ponit Tran .
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class.CLP
{
    public class CLPTran
    {
        private int _TranID;
        private string _TranNo;
        private DateTime _TranDate;
        private int _WarehouseID;
        private int _CustomerID;
        private int _ConsumerID;
        private int _PreviousPoint;
        private int _CurrentPoint;
        private int _EncashmentPoint;
        private int _UserID;
        private int _TranTypeID;

        DataTran _oDataTran;

        private Warehouse _oWarehouse;
        public Warehouse Warehouse
        {
            get
            {
                if (_oWarehouse == null)
                {
                    _oWarehouse = new Warehouse();

                }
                return _oWarehouse;
            }
        }

        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }

        /// <summary>
        /// Get set property for ConsumerID
        /// </summary>
        public int ConsumerID
        {
            get { return _ConsumerID; }
            set { _ConsumerID = value; }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        /// <summary>
        /// Get set property for PreviousPoint
        /// </summary>
        public int PreviousPoint
        {
            get { return _PreviousPoint; }
            set { _PreviousPoint = value; }
        }

        /// <summary>
        /// Get set property for CurrentPoint
        /// </summary>
        public int CurrentPoint
        {
            get { return _CurrentPoint; }
            set { _CurrentPoint = value; }
        }

        /// <summary>
        /// Get set property for EncashmentPoint
        /// </summary>
        public int EncashmentPoint
        {
            get { return _EncashmentPoint; }
            set { _EncashmentPoint = value; }
        }

        public int TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public void Insert(bool IsTrue)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_CLPTran";
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
                _TranID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextCLPTranNo]) FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object maxTanNo = cmd.ExecuteScalar();
                if (maxTanNo == DBNull.Value)
                {
                    nNextTranNo = 1;
                }
                else
                {
                    nNextTranNo = Convert.ToInt32(maxTanNo);
                }
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _WarehouseID;
                _oWarehouse.POSReresh();

                _TranNo = _oWarehouse.Shortcode + "-" + nNextTranNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_CLPTran VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("PreviousPoint", _PreviousPoint);
                cmd.Parameters.AddWithValue("CurrentPoint", _CurrentPoint);
                cmd.Parameters.AddWithValue("EncashmentPoint", _EncashmentPoint);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextTranNo = nNextTranNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextCLPTranNo='" + nNextTranNo + "'  where WarehouseID='" + _WarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_RetailConsumer set CurrentCLP='" + _CurrentPoint + "'  where ConsumerID='" + _ConsumerID + "' and CustomerID= '" + _CustomerID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                
                if (IsTrue == true)
                {
                    _oDataTran = new DataTran();
                    _oDataTran.TableName = "t_RetailConsumer";
                    _oDataTran.DataID = _ConsumerID;
                    _oDataTran.WarehouseID = _WarehouseID;
                    _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTran.BatchNo = 0;

                    _oDataTran.AddForTDPOS();

                }

                _oDataTran = new DataTran();
                _oDataTran.TableName = "t_CLPTran";
                _oDataTran.DataID = _TranID;
                _oDataTran.WarehouseID = _WarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;

                _oDataTran.AddForTDPOS();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
                    
            string sSql = "SELECT * FROM t_CLPTran where ConsumerID=? and CustomerID=?";
            cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
            cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _PreviousPoint = int.Parse(reader["PreviousPoint"].ToString());
                    _EncashmentPoint = int.Parse(reader["EncashmentPoint"].ToString());
                    _CurrentPoint = int.Parse(reader["CurrentPoint"].ToString());              
                                      
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
    }
    public class CLPTranList : CollectionBase
    {
        public CLPTran this[int i]
        {
            get { return (CLPTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CLPTran oCLPTran)
        {
            InnerList.Add(oCLPTran);
        }

  
    }
}
