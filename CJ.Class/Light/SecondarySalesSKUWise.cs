// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Apr 12, 2012
// Time :  11:00 AM
// Description: Secondary Sales Collection
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Light
{
    public class SecondarySalesSKUWise
    {

        private int _nTranID;
        private int _nProductID;
        private int _nSaleQty;
        private double _NSP;
        private bool _bFlag;


        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int SalesQty
        {
            get { return _nSaleQty; }
            set { _nSaleQty = value; }
        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void Add(int nTranID, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                
                string sSql = "";
                sSql = "INSERT INTO t_SecondarySalesDetails VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SalesQty", _nSaleQty);
                cmd.Parameters.AddWithValue("NSP", _NSP);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

               
                //TranType _oTranType;
                //_oTranType = new TranType();
                //_oTranType.TranTypeID = nTranTypeID;
                //_oTranType.Refresh();

                               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " select * from t_SecondarySales ";                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                              

                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0) return true;
            else return false;
            
        }

        public void MAdd(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SecondarySalesDetails VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SalesQty", _nSaleQty);
                cmd.Parameters.AddWithValue("NSP", _NSP);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class SecondarySale : CollectionBase
    {
        public SecondarySalesSKUWise this[int i]
        {
            get { return (SecondarySalesSKUWise)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SecondarySalesSKUWise oSecondarySalesSKUWise)
        {
            InnerList.Add(oSecondarySalesSKUWise);
        }

        private int _nTranID;
        private DateTime _dTrandate;
        private int _nCustomerID;
        private int _nUserID;
        private bool _bFlag;

        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        public DateTime TranDate
        {
            get { return _dTrandate; }
            set { _dTrandate = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void Add()
        {
            int nMaxTranID = 0;            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_SecondarySales";
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

                sSql = "INSERT INTO t_SecondarySales VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);     
                cmd.Parameters.AddWithValue("TranDate", _dTrandate);
                cmd.Parameters.AddWithValue("UserID", _nUserID);               

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SecondarySalesSKUWise oItem in this)
                {
                    oItem.Add(_nTranID,  _nCustomerID);
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
