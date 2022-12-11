// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jul 13, 2016
// Time : 11:52 AM
// Description: Class for TPVATProduct.
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
    public class TPVATProduct
    {
        private int _nProductID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nStatus;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _nProductCode;
        private string _nProductName;
        private string _nMAGName;
        private string _nCreateUserName;
        private string _sComment;

        public string Comment
        {
            get { return _sComment; }
            set { _sComment = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _nProductCode; }
            set { _nProductCode = value; }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _nProductName; }
            set { _nProductName = value; }
        }
        // <summary>
        // Get set property for MAGName
        // </summary>
        public string MAGName
        {
            get { return _nMAGName; }
            set { _nMAGName = value; }
        }
        // <summary>
        // Get set property for MAGName
        // </summary>
        public string CreateUserName
        {
            get { return _nCreateUserName; }
            set { _nCreateUserName = value; }
        }
        private double _TradePrice;
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_TPVATProduct (ProductID, CreateUserID, CreateDate, Status, UpdateUserID, UpdateDate ) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_TPVATProduct SET CreateUserID = ?, CreateDate = ?, Status = ?, UpdateUserID = ?, UpdateDate = ? WHERE ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateProductStatus(int nProductID,int Status,int nUpdateUserID, DateTime nUpdateDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_TPVATProduct SET Status = ?, UpdateUserID = ?, UpdateDate = ? WHERE ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

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
                sSql = "DELETE FROM t_TPVATProduct WHERE [ProductID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
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
                cmd.CommandText = "SELECT ProductID,CreateDate,CreateUserID,Status,isnull(Comment,'') Comment FROM t_TPVATProduct where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sComment = (string)reader["Comment"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsProductExists(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT a.*, TradePrice FROM t_TPVATProduct a, v_PRoductDetails b  where a.ProductID=b.ProductID and a.ProductID =" + nProductID + "";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _TradePrice = Convert.ToDouble(reader["TradePrice"]);
                    return true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return false;
        }

    }
    public class TPVATProducts : CollectionBase
    {
        public TPVATProduct this[int i]
        {
            get { return (TPVATProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(TPVATProduct oTPVATProduct)
        {
            InnerList.Add(oTPVATProduct);
        }
        public int GetIndex(int nProductID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductID == nProductID)
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
            string sSql = "SELECT * FROM t_TPVATProduct";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TPVATProduct oTPVATProduct = new TPVATProduct();
                    oTPVATProduct.ProductID = (int)reader["ProductID"];
                    oTPVATProduct.CreateUserID = (int)reader["CreateUserID"];
                    oTPVATProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTPVATProduct.Status = (int)reader["Status"];
                    oTPVATProduct.UpdateUserID = (int)reader["UpdateUserID"];
                    oTPVATProduct.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oTPVATProduct);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshProducts(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.ProductID,b.ProductCode,b.ProductName,b.MAGName,a.Status, c.UserFullName as CreateUserName, "
                            + "CreateDate FROM t_TPVATProduct a "
                            + "INNER JOIN  v_ProductDetails b "
                            + "ON a.ProductID = b.ProductID "
                            + "INNER JOIN t_User c "
                            + "ON a.CreateUserID=c.UserID "
                            + "Where 1=1 ";
            if (nProductID != -1)
            {
                sSql += "AND a.ProductID= " + nProductID + " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TPVATProduct oTPVATProduct = new TPVATProduct();
                    oTPVATProduct.ProductID = (int)reader["ProductID"];
                    oTPVATProduct.ProductCode = (string)reader["ProductCode"];
                    oTPVATProduct.ProductName = (string)reader["ProductName"];
                    oTPVATProduct.MAGName = (string)reader["MAGName"];
                    oTPVATProduct.Status = (int)reader["Status"];
                    oTPVATProduct.CreateUserName = (string)reader["CreateUserName"];
                    oTPVATProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());                 
                    InnerList.Add(oTPVATProduct);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetCommentByDutyIDPOS(int nDutyTranID,int nWHID,int nChallanType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nChallanType == (int)Dictionary.ChallanType.VAT_63)
            {
                sSql = "Select ProductCode,isnull(Comment,'') Comment From t_DutyTranOutletDetail a,t_TPVatProduct b,t_Product c " +
                            "where a.ProductID = b.ProductID and a.ProductID = c.ProductID and DutyTranID = " + nDutyTranID + " and WHID = " + nWHID + "";
            }
            else
            {
                sSql = "Select ProductCode,isnull(Comment,'') Comment From t_DutyTranOutletDetailISGM a,t_TPVatProduct b,t_Product c " +
                       "where a.ProductID = b.ProductID and a.ProductID = c.ProductID and DutyTranID = " + nDutyTranID + " and WHID = " + nWHID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TPVATProduct oTPVATProduct = new TPVATProduct();
                    oTPVATProduct.ProductCode = (string)reader["ProductCode"];
                    oTPVATProduct.Comment = (string)reader["Comment"];
                    
                    InnerList.Add(oTPVATProduct);
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

