// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Feb 16, 2012
// Time :  4:00 PM
// Description: Class for Warranty .
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.POS;
using CJ.Class.Warranty;

namespace CJ.Class.Warranty
{
    public class WarrantyProduct
    {
        private int _nWarrantyCategoryID;
        private int _nProductID;
        private int _nUploadStatus;
        private int _nDownloadStatus;




        /// <summary>
        /// Get set property for WarrantyCategoryID
        /// </summary>
        public int WarrantyCategoryID
        {
            get { return _nWarrantyCategoryID; }
            set { _nWarrantyCategoryID = value; }
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
        /// Get set property for UploadStatus
        /// </summary>
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }
        }

        /// <summary>
        /// Get set property for DownloadStatus
        /// </summary>
        public int DownloadStatus
        {
            get { return _nDownloadStatus; }
            set { _nDownloadStatus = value; }
        }
        public void Add()
        {
           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_WarrantyCategoryProduct VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);               
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("DownloadStatus", 1);

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

                sSql = "Delete t_WarrantyCategoryProduct WHERE WarrantyCategoryID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }
    public class WarrantyProducts : CollectionBase
    {
        public WarrantyProduct this[int i]
        {
            get { return (WarrantyProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(WarrantyProduct oWarrantyProduct)
        {
            InnerList.Add(oWarrantyProduct);
        }
        public void Refresh(int nWarrantyCategoryID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyCategoryProduct "
                          + " where WarrantyCategoryID=?  ";

            cmd.Parameters.AddWithValue("WarrantyCategoryID", nWarrantyCategoryID);          

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WarrantyProduct oWarrantyProduct = new WarrantyProduct();
                    oWarrantyProduct.WarrantyCategoryID = int.Parse(reader["WarrantyCategoryID"].ToString());
                    oWarrantyProduct.ProductID = int.Parse(reader["ProductID"].ToString());

                    InnerList.Add(oWarrantyProduct);
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
