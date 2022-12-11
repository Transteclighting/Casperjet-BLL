// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 10, 2012
// Time :  08:37 PM
// Description: Class for Product.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class
{
    public class SerarchProduct
    {
        private int _nProductID;
        private int _nBrandID;
        private string _sProductCode;
        private string _sProductName;
        private string _sASGName;
        private string _sMAGName;
        private string _sBrandDesc;
        private double _VAT;
        private string _sProductModel;
        private int _nAGID;
        private int _nMAGID;
        private double _RSP;

        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }

        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        /// <summary>
        /// Get set property for ASGName
        /// </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        /// <summary>
        /// Get set property for Contact MAGName
        /// </summary>
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }

        /// <summary>
        /// Get set property for BrandDesc
        /// </summary>
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        public void RefreshByProductCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ProductID,BrandID,ProductCode,ProductName,isnull(ProductModel,'') ProductModel,ASGName,MAGName,BrandDesc,isnull(VAT,0) VAT,MAGID,AGID,isnull(RSP,0) RSP from v_productdetails Where ProductCode=?";//PGCode IN ('PG01','PG04', 'PG05') AND
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _nBrandID = (int)reader["BrandID"];
                    _nMAGID = (int)reader["MAGID"];
                    _nAGID = (int)reader["AGID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductModel = (string)reader["ProductModel"];
                    _sASGName = (string)reader["ASGName"];
                    _sMAGName = (string)reader["MAGName"];
                    _sBrandDesc = (string)reader["BrandDesc"];
                    _VAT = (double)reader["VAT"];
                    _RSP = (double)reader["RSP"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByProductCodeFactory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ProductID,BrandID,ProductCode,ProductName,isnull(ProductModel,'') ProductModel,ASGName,MAGName,BrandDesc,isnull(VAT,0) VAT,MAGID,isnull(RSP,0) RSP from t_product Where ProductCode=?";
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _nBrandID = (int)reader["BrandID"];
                    _nMAGID = (int)reader["MAGID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductModel = (string)reader["ProductModel"];
                    _sASGName = (string)reader["ASGName"];
                    _sMAGName = (string)reader["MAGName"];
                    _sBrandDesc = (string)reader["BrandDesc"];
                    _VAT = (double)reader["VAT"];
                    _RSP = (double)reader["RSP"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByProductID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from v_productdetails Where PGCode IN ('PG01','PG04', 'PG05') AND ProductID=?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //_nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sASGName = (string)reader["ASGName"];
                    _sMAGName = (string)reader["MAGName"];
                    _sBrandDesc = (string)reader["BrandDesc"];

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

    public class SerarchProducts : CollectionBase
    {
        public SerarchProduct this[int i]
        {
            get { return (SerarchProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SerarchProduct oSerarchProduct)
        {
            InnerList.Add(oSerarchProduct);
        }

        //public void Refresh(int nJobID)
        //    {
        //        //dtToDate = dtToDate.Date.AddDays(1);
        //        InnerList.Clear();
        //        OleDbCommand cmd = DBController.Instance.GetCommand();

        //        string sSql = "Select * from TELServiceDB.dbo.Job where JobStatus=15 AND IsDelivered=0 AND JobID=?";


        //        //if (txtJobNo != "")
        //        //{
        //        //    txtJobNo = "%" + txtJobNo + "%";
        //        //    sSql = sSql + " AND JobID LIKE '" + txtJobNo + "'";
        //        //}
        //        //if (nStatus > -1)
        //        //{
        //        //    sSql = sSql + "AND Status ='" + nStatus + "'";
        //        //}

        //        try
        //        {
        //            cmd.CommandText = sSql;
        //            cmd.CommandType = CommandType.Text;
        //            IDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ReplaceJobFromCassandra oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
        //                oReplaceJobFromCassandra.JobID = (int)reader["JobID"];
        //                oReplaceJobFromCassandra.JobNo=(string)reader["JobNo"];
        //                oReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
        //                oReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
        //                oReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
        //                oReplaceJobFromCassandra.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());

        //               InnerList.Add(oReplaceJobFromCassandra);
        //            }
        //            reader.Close();
        //            InnerList.TrimToSize();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw (ex);
        //        }
        //    }

        public void Refresh(String txtProductCode, String txtProductName)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from v_productdetails Where PGCode IN ('PG01','PG04', 'PG05')";


            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND ProductCode LIKE '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SerarchProduct oSerarchProduct = new SerarchProduct();
                    oSerarchProduct.ProductID = (int)reader["ProductID"];
                    oSerarchProduct.ProductCode = (string)reader["ProductCode"];
                    oSerarchProduct.ProductName = (string)reader["ProductName"];
                    oSerarchProduct.ASGName = (string)reader["ASGName"];
                    oSerarchProduct.MAGName = (string)reader["MAGName"];
                    oSerarchProduct.BrandDesc = (string)reader["BrandDesc"];

                    InnerList.Add(oSerarchProduct);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, String txtProductCode, String txtProductName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from v_productdetails Where 1=1";


            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND ProductCode Like '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }
            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SerarchProduct oSerarchProduct = new SerarchProduct();
                    oSerarchProduct.ProductID = (int)reader["ProductID"];
                    oSerarchProduct.ProductCode = (string)reader["ProductCode"];
                    oSerarchProduct.ProductName = (string)reader["ProductName"];
                    oSerarchProduct.MAGID = (int)reader["MAGID"];
                    oSerarchProduct.BrandID = (int)reader["BrandID"];
                    if (reader["ASGName"] != DBNull.Value)
                        oSerarchProduct.ASGName = (string)reader["ASGName"];
                    else oSerarchProduct.ASGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oSerarchProduct.MAGName = (string)reader["MAGName"];
                    else oSerarchProduct.MAGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oSerarchProduct.BrandDesc = (string)reader["BrandDesc"];
                    else oSerarchProduct.BrandDesc = "";
                    if (reader["ProductModel"] != DBNull.Value)
                        oSerarchProduct.ProductModel = (string)reader["ProductModel"];
                    else oSerarchProduct.ProductModel = "";

                    if (reader["RSP"] != DBNull.Value)
                        oSerarchProduct.RSP = (double)reader["RSP"];
                    else oSerarchProduct.RSP = 0;

                    if (reader["VAT"] != DBNull.Value)
                        oSerarchProduct.VAT = (double)reader["VAT"];
                    else oSerarchProduct.VAT = 0;

                    InnerList.Add(oSerarchProduct);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void RefreshFactory(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, String txtProductCode, String txtProductName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_Product Where 1=1";


            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND ProductCode Like '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }
            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SerarchProduct oSerarchProduct = new SerarchProduct();
                    oSerarchProduct.ProductID = (int)reader["ProductID"];
                    oSerarchProduct.ProductCode = (string)reader["ProductCode"];
                    oSerarchProduct.ProductName = (string)reader["ProductName"];
                    oSerarchProduct.MAGID = (int)reader["MAGID"];
                    oSerarchProduct.BrandID = (int)reader["BrandID"];
                    if (reader["ASGName"] != DBNull.Value)
                        oSerarchProduct.ASGName = (string)reader["ASGName"];
                    else oSerarchProduct.ASGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oSerarchProduct.MAGName = (string)reader["MAGName"];
                    else oSerarchProduct.MAGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oSerarchProduct.BrandDesc = (string)reader["BrandDesc"];
                    else oSerarchProduct.BrandDesc = "";
                    if (reader["ProductModel"] != DBNull.Value)
                        oSerarchProduct.ProductModel = (string)reader["ProductModel"];
                    else oSerarchProduct.ProductModel = "";

                    if (reader["RSP"] != DBNull.Value)
                        oSerarchProduct.RSP = (double)reader["RSP"];
                    else oSerarchProduct.RSP = 0;

                    if (reader["VAT"] != DBNull.Value)
                        oSerarchProduct.VAT = (double)reader["VAT"];
                    else oSerarchProduct.VAT = 0;

                    InnerList.Add(oSerarchProduct);
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
