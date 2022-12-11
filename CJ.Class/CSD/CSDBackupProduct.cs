// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jan 18, 2017
// Time : 12:18 PM
// Description: Class for CSDBackupProduct.
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
    public class CSDBackupProduct
    {
        private int _nBackUpProductID;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sProductModel;
        private string _sBackupProductSerial;
        private string _sBrandDesc;
        private int _nJobID;
        private string _sJobNo;
        private int _nIsActive;


        // <summary>
        // Get set property for BrandDesc
        // </summary>
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        // <summary>
        // Get set property for ProductModel
        // </summary>
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }

        // <summary>
        // Get set property for BackupProductSerial
        // </summary>
        public string BackupProductSerial
        {
            get { return _sBackupProductSerial; }
            set { _sBackupProductSerial = value; }
        }

        // <summary>
        // Get set property for BackUpProductID
        // </summary>
        public int BackUpProductID
        {
            get { return _nBackUpProductID; }
            set { _nBackUpProductID = value; }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
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
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        
        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public void Add()
        {
            int nMaxBackUpProductID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BackUpProductID]) FROM t_CSDBackupProduct";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBackUpProductID = 1;
                }
                else
                {
                    nMaxBackUpProductID = Convert.ToInt32(maxID) + 1;
                }
                _nBackUpProductID = nMaxBackUpProductID;
                sSql = "INSERT INTO t_CSDBackupProduct (BackUpProductID, ProductID,BackupProductSerial,IsActive) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BackUpProductID", _nBackUpProductID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BackupProductSerial", _sBackupProductSerial);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_CSDBackupProduct SET ProductID = ?, BackupProductSerial = ?,IsActive= ? WHERE BackUpProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BackupProductSerial", _sBackupProductSerial);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("BackUpProductID", _nBackUpProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AssignCSDBackupProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDBackupProduct SET JobID = ? WHERE BackUpProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("BackUpProductID", _nBackUpProductID);

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
                sSql = "DELETE FROM t_CSDBackupProduct WHERE [BackUpProductID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BackUpProductID", _nBackUpProductID);
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
                cmd.CommandText = "SELECT * FROM t_CSDBackupProduct where BackUpProductID =?";
                cmd.Parameters.AddWithValue("BackUpProductID", _nBackUpProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBackUpProductID = (int)reader["BackUpProductID"];
                    _nProductID = (int)reader["ProductID"];
                    _nJobID = (int)reader["JobID"];
                    _nIsActive = (int)reader["IsActive"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public bool IsAvailable()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    bool bIsAvailable= false;
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_CSDBackupProduct where BackUpProductID =? AND JobId=0 AND Isactive = "+(int)Dictionary.IsActive.Active+" ";
        //        cmd.Parameters.AddWithValue("BackUpProductID", _nBackUpProductID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            bIsAvailable = true;
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return bIsAvailable;
        //}
    }
    public class CSDBackupProducts : CollectionBase
    {
        public CSDBackupProduct this[int i]
        {
            get { return (CSDBackupProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDBackupProduct oCSDBackupProduct)
        {
            InnerList.Add(oCSDBackupProduct);
        }
        public int GetIndex(int nBackUpProductID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BackUpProductID == nBackUpProductID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GetData(int nProductID, int nJobID,bool bUassignProduct)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql ="SELECT x.*,a.ProductCode,ProductName,ISNULL(ProductModel,'')ProductModel,BrandDesc FROM ( "
            //            +"SELECT a.*,b.JobNo from t_CSDBackupProduct a "
            //            +"INNER JOIN t_CSDJob b ON a.JobID = b.JobID "
            //            +"UNION ALL "
            //            +"SELECT a.*,JobNo='Unassign' from t_CSDBackupProduct a "
            //            +"WHERE a.JobID = 0 AND IsActive = " + (int)Dictionary.IsActive.Active + ")x "
            //            +"Inner JOIN v_ProductDetails a on x.ProductID = a.ProductID WHERE 1=1 ";

            string sSql = @"SELECT BackUpProductID,BackupProductSerial,a.ProductID,ProductCode,
                           ProductName,ISNULL(ProductModel,'')ProductModel,BrandDesc,ISNULL(a.JobID,0) JobID,
                           JobNo = CASE WHEN c.JobNo IS NULL THEN 'Not Issued' ELSE c.JobNo end
                           FROM t_CSDBackupProduct a
                           INNER JOIN v_ProductDetails b ON a.ProductID = b.ProductID
                           LEFT JOIN t_CSDJob c ON c.JobID = a.JobID
                           Where a.IsActive = 1 ";

            if (nProductID != -1)
            {
                sSql += " AND a.ProductID = " + nProductID + " "; 
            }

            if (nJobID != -1)
            {
                sSql += " AND JobID=  " + nJobID + " ";
            }
            if (bUassignProduct)
            {
                sSql += " AND JobId =0";
            }

            sSql += " ORDER BY a.ProductID,BackUpProductID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDBackupProduct oCSDBackupProduct = new CSDBackupProduct();
                    oCSDBackupProduct.BackUpProductID = (int)reader["BackUpProductID"];
                    oCSDBackupProduct.ProductID = (int)reader["ProductID"];
                    oCSDBackupProduct.ProductCode = (string)reader["ProductCode"];
                    oCSDBackupProduct.ProductName = (string)reader["ProductName"];
                    oCSDBackupProduct.ProductModel = (string)reader["ProductModel"];
                    oCSDBackupProduct.BrandDesc = (string)reader["BrandDesc"];
                    oCSDBackupProduct.JobID = (int)reader["JobID"];
                    oCSDBackupProduct.JobNo = (string)reader["JobNo"];
                    oCSDBackupProduct.BackupProductSerial = (string)reader["BackupProductSerial"];
                    InnerList.Add(oCSDBackupProduct);
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
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDBackupProduct";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDBackupProduct oCSDBackupProduct = new CSDBackupProduct();
                    oCSDBackupProduct.BackUpProductID = (int)reader["BackUpProductID"];
                    oCSDBackupProduct.ProductID = (int)reader["ProductID"];
                    oCSDBackupProduct.JobID = (int)reader["JobID"];
                    InnerList.Add(oCSDBackupProduct);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByBackupProduct()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select BackUpProductID,ProductCode,ProductName,BackupProductSerial,b.Isactive " +
                          "from t_CSDBackupProduct a,t_Product b where a.productid=b.productid";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDBackupProduct oCSDBackupProduct = new CSDBackupProduct();
                    oCSDBackupProduct.BackUpProductID = (int)reader["BackUpProductID"];
                    oCSDBackupProduct.ProductCode = (string)reader["ProductCode"];
                    oCSDBackupProduct.ProductName = (string)reader["ProductName"];
                    oCSDBackupProduct.BackupProductSerial = (string)reader["BackupProductSerial"];
                    if (reader["IsActive"] != DBNull.Value)
                    oCSDBackupProduct.IsActive = Convert.ToInt32(reader["IsActive"]);
                    InnerList.Add(oCSDBackupProduct);
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

