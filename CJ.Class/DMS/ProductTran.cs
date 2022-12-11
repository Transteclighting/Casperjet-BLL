// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 24, 2011
// Time :  11:00 AM
// Description: Class for DMS Product transaction.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.DMS
{

    public class ProductTranItem
    {

        private long _TranID;
        private int _nProductID;
        private long _Quantity;
        private long _CurrentStock;
        private long _AdjustmentStock;
        private double _UnitPrice;
        private bool _bFlag;


        public long TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public long Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public long CurrentStock
        {
            get { return _CurrentStock; }
            set { _CurrentStock = value; }
        }
        public long AdjustmentStock
        {
            get { return _AdjustmentStock; }
            set { _AdjustmentStock = value; }
        }

        /// <summary>
        /// Get set property for UnitPrice
        /// </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void Add(int nTranID, int nTranTypeID, int nDistributorID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSProductTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                cmd = DBController.Instance.GetCommand();

                TranType _oTranType;
                _oTranType = new TranType();
                _oTranType.TranTypeID = nTranTypeID;
                _oTranType.Refresh();

                if (_oTranType.TranSide == 1)
                {
                    cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock+? where ProductID=? and DistributorID=?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("CurrentStock", _Quantity);

                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("DistributorID", nDistributorID);

                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        _bFlag = true;
                    }
                    else _bFlag = false;

                    cmd.Dispose();
                }
                else
                {
                    cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock-? where ProductID=? and DistributorID=? and CurrentStock >= ?";

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("CurrentStock", _Quantity);

                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
                    cmd.Parameters.AddWithValue("CurrentStock", _Quantity);

                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        _bFlag = true;
                    }
                    else _bFlag = false;

                    cmd.Dispose();
                }
              
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AdjustStock(int nTranID, int nTranTypeID,int nDistributorID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {                
                cmd.CommandText = "INSERT INTO t_DMSProductTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _AdjustmentStock);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (CheckProduct(nDistributorID))
                {
                    TranType _oTranType;
                    _oTranType = new TranType();
                    _oTranType.TranTypeID = nTranTypeID;
                    _oTranType.Refresh();

                    if (_oTranType.TranSide == 1)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "INSERT INTO t_DMSProductStock VALUES (?,?,?)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ProductID", _nProductID);
                        cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        _bFlag = true;
                    }
                    else _bFlag = false;
                }
                else
                {
                    TranType _oTranType;   
                    _oTranType = new TranType();
                    _oTranType.TranTypeID = nTranTypeID;
                    _oTranType.Refresh();

                    if (_oTranType.TranSide == 1)
                    {
                        cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock+? where ProductID=? and DistributorID=?";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        cmd.Parameters.AddWithValue("ProductID", _nProductID);
                        cmd.Parameters.AddWithValue("DistributorID", nDistributorID);

                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            _bFlag = true;
                        }
                        else _bFlag = false;

                        cmd.Dispose();
                    }
                    else
                    {
                        cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock-? where ProductID=? and DistributorID=? and CurrentStock >= ?";

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        cmd.Parameters.AddWithValue("ProductID", _nProductID);
                        cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            _bFlag = true;
                        }
                        else _bFlag = false;

                        cmd.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AdjustDefectiveStock(int nTranID, int nTranTypeID, int nDistributorID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSProductTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _AdjustmentStock);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (CheckProduct(nDistributorID))
                {
                    TranType _oTranType;
                    _oTranType = new TranType();
                    _oTranType.TranTypeID = nTranTypeID;
                    _oTranType.Refresh();

                    if (_oTranType.TranSide == 1)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "INSERT INTO t_DMSDefectiveStock VALUES (?,?,?)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ProductID", _nProductID);
                        cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        _bFlag = true;
                    }
                    else _bFlag = false;
                }
                else
                {
                    TranType _oTranType;
                    _oTranType = new TranType();
                    _oTranType.TranTypeID = nTranTypeID;
                    _oTranType.Refresh();

                    if (_oTranType.TranSide == 1)
                    {
                        cmd.CommandText = "update t_DMSDefectiveStock set CurrentStock=CurrentStock+? where ProductID=? and DistributorID=?";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        cmd.Parameters.AddWithValue("ProductID", _nProductID);
                        cmd.Parameters.AddWithValue("DistributorID", nDistributorID);

                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            _bFlag = true;
                        }
                        else _bFlag = false;

                        cmd.Dispose();
                    }
                    else
                    {
                        cmd.CommandText = "update t_DMSDefectiveStock set CurrentStock=CurrentStock-? where ProductID=? and DistributorID=? and CurrentStock >= ?";

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        cmd.Parameters.AddWithValue("ProductID", _nProductID);
                        cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
                        cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            _bFlag = true;
                        }
                        else _bFlag = false;

                        cmd.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Refresh(int nDistributorID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT DISTINCT  b.currentstock from t_DMSProductTranItem a inner join t_DMSProductStock b on "+
                    " a.productid=b.productid where a.productid=? and b.distributorid=? and a.unitprice !=0 ";

                cmd.Parameters.AddWithValue("productid", _nProductID);
                cmd.Parameters.AddWithValue("distributorid", nDistributorID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                  
                    _CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());                   

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;
        }

        public bool CheckProduct(int nDistributorID)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_DMSProductStock where ProductID=? and DistributorID=?";
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count == 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void MAdd(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSMProTranDetail1 VALUES (?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _Quantity);              

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class ProductTran : CollectionBase
    {
        public ProductTranItem this[int i]
        {
            get { return (ProductTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductTranItem oProductTranItem)
        {
            InnerList.Add(oProductTranItem);
        }

        private int _nTranID;      
        private string _TranNo;
        private string _sMemoNo;
        private object _TranDate;
        private int _nTranTypeID;
        private int _nDistributorID;
        private int _nOutletID;
        private string _sRemarks;
        private bool _bFlag;
        private int _nDSRID;
        public Outlet oOutlet;

        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value.Trim(); }
        }
        public string MemoNo
        {
            get { return _sMemoNo; }
            set { _sMemoNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public object TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }

        /// <summary>
        /// Get set property for DistributorID
        /// </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        /// <summary>
        /// Get set property for OutletID
        /// </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }
        public Outlet Outlet
        {
            get
            {
                if (oOutlet == null)
                {
                    oOutlet = new Outlet();
                    oOutlet.OutletID = _nOutletID;
                    oOutlet.RefreshBy();
                }

                return oOutlet;
            }
        }
        public void Add()
        {
            int nMaxTranID = 0;
            int nMaxTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductTran";
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select NextTranNo from t_DMSNextTranNo ";

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxTranNo = 1;
                }
                else
                {
                    nMaxTranNo = int.Parse(MaxTranNo.ToString());

                }

                _TranNo = "DMS-" + nMaxTranNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_DMSProductTran VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);               
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("MemoNo", _sMemoNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "Update  t_DMSNextTranNo Set NextTranNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("NextTranNo", nMaxTranNo+1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTranItem oItem in this)
                {
                    oItem.Add(_nTranID, _nTranTypeID, _nDistributorID);
                    if (oItem.Flag == false)
                    {
                        _bFlag = false;
                        break;
                    }
                    else _bFlag = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AdjustStock()
        {
            int nMaxTranID = 0;
            int nMaxTranNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductTran";
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select NextTranNo from t_DMSNextTranNo ";

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxTranNo = 1;
                }
                else
                {
                    nMaxTranNo = int.Parse(MaxTranNo.ToString()) + 1;

                }

                _TranNo = "DMS-" + nMaxTranNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "INSERT INTO t_DMSProductTran VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);            
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletID", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("MemoNo", null);
                cmd.Parameters.AddWithValue("Discount", null);
                cmd.Parameters.AddWithValue("NetAmount", null);                
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "Update  t_DMSNextTranNo Set NextTranNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("NextTranNo", nMaxTranNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTranItem oItem in this)
                {
                    oItem.AdjustStock(_nTranID, _nTranTypeID, _nDistributorID);
                   if (oItem.Flag == false)
                   {
                       _bFlag = false;
                       break;
                   }
                   else _bFlag = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AdjustDefectiveStock()
        {
            int nMaxTranID = 0;
            int nMaxTranNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductTran";
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select NextTranNo from t_DMSNextTranNo ";

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxTranNo = 1;
                }
                else
                {
                    nMaxTranNo = int.Parse(MaxTranNo.ToString()) + 1;

                }

                _TranNo = "DMS-" + nMaxTranNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "INSERT INTO t_DMSProductTran VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletID", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("MemoNo", null);
                cmd.Parameters.AddWithValue("Discount", null);
                cmd.Parameters.AddWithValue("NetAmount", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "Update  t_DMSNextTranNo Set NextTranNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("NextTranNo", nMaxTranNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTranItem oItem in this)
                {
                    oItem.AdjustDefectiveStock(_nTranID, _nTranTypeID, _nDistributorID);
                    if (oItem.Flag == false)
                    {
                        _bFlag = false;
                        break;
                    }
                    else _bFlag = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public long GetNextTranNo()
        {
            long nMaxTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT COUNT([TranNo]) FROM t_DMSProductTran where TranNo like 'DMS%' ";
                cmd.CommandText = sSql;
                object maxNo = cmd.ExecuteScalar();

                nMaxTranNo=Convert.ToInt32(maxNo.ToString());

                if (nMaxTranNo != 0)
                    nMaxTranNo = Convert.ToInt32(maxNo.ToString()) + 1;

                return nMaxTranNo;
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }
        public bool CheckCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT * FROM t_DMSProductTran where TranNo=? ";
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
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

            if (nCount == 0)
                return true;
            else return false;
        }

        /// <summary>
        /// DMS Mobile Version
        /// </summary>
        public void MAdd()
        {
            int nMaxTranID = 0;           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSMProductTran1";
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
               
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_DMSMProductTran1 VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID); 
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
            
                cmd.ExecuteNonQuery();
                cmd.Dispose();
             
                foreach (ProductTranItem oItem in this)
                {
                    oItem.MAdd(_nTranID);                  
                }
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
                sSql = "DELETE FROM t_DMSMProTranDetail1 WHERE TranID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);          

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "DELETE FROM t_DMSMProductTran1 WHERE TranID=?";

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
        public bool MCheckTranType( DateTime dTranDate )
        {         
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "Select * from t_DMSMProductTran1 where TranTypeID=? and TranDate=? and DSRID=? and OutletID=?";
                cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.DMSMTranType.Stock);
                cmd.Parameters.AddWithValue("TranDate", dTranDate.Date);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);

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
                if (nCount != 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Function for TEL 
        /// </summary>
        /// 
        public void AddForTEL()
        {
            int nMaxTranID = 0;
            int nMaxTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductTran";
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select NextTranNo from t_DMSNextTranNo ";

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == null)
                {
                    nMaxTranNo = 1;
                }
                else
                {
                    nMaxTranNo = int.Parse(MaxTranNo.ToString());

                }

                _TranNo = "DMS-" + nMaxTranNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_DMSProductTran VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletID", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("MemoNo", "");

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxTranNo = nMaxTranNo + 1;

                cmd = DBController.Instance.GetCommand();
                sSql = "Update  t_DMSNextTranNo Set NextTranNo=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("NextTranNo", nMaxTranNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTranItem oItem in this)
                {
                    oItem.Add(_nTranID, _nTranTypeID, _nDistributorID);
                    if (oItem.Flag == false)
                    {
                        _bFlag = false;
                        break;
                    }
                    else _bFlag = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
