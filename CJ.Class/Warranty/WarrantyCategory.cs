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
    public class WarrantyParameter
    {
        private int _nWarrantyParameterID;
        private int _nWarrantyCategoryID;
        private int _nServiceValidity;
        private int _nSpareValidity;
        private int _nSpecialPartValidity;
        private DateTime _dEffectiveFrom;
        private int _nCreatedBy;
        private DateTime _dCreatedDate;
        private int _nUploadStatus;
        private int _nDownloadStatus;
        private string _sWarrantyCardNo;

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
        /// Get set property for WarrantyParameterID
        /// </summary>
        public int WarrantyParameterID
        {
            get { return _nWarrantyParameterID; }
            set { _nWarrantyParameterID = value; }
        }

        /// <summary>
        /// Get set property for WarrantyCategoryID
        /// </summary>
        public int WarrantyCategoryID
        {
            get { return _nWarrantyCategoryID; }
            set { _nWarrantyCategoryID = value; }
        }

        /// <summary>
        /// Get set property for ServiceValidity
        /// </summary>
        public int ServiceValidity
        {
            get { return _nServiceValidity; }
            set { _nServiceValidity = value; }
        }

        /// <summary>
        /// Get set property for SpareValidity
        /// </summary>
        public int SpareValidity
        {
            get { return _nSpareValidity; }
            set { _nSpareValidity = value; }
        }

        /// <summary>
        /// Get set property for SpecialPartValidity
        /// </summary>
        public int SpecialPartValidity
        {
            get { return _nSpecialPartValidity; }
            set { _nSpecialPartValidity = value; }
        }

        /// <summary>
        /// Get set property for EffectiveFrom
        /// </summary>
        public DateTime EffectiveFrom
        {
            get { return _dEffectiveFrom; }
            set { _dEffectiveFrom = value; }
        }

        /// <summary>
        /// Get set property for CreatedBy
        /// </summary>
        public int CreatedBy
        {
            get { return _nCreatedBy; }
            set { _nCreatedBy = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreatedDate; }
            set { _dCreatedDate = value; }
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
        public string WarrantyCardNo
        {
            get { return _sWarrantyCardNo; }
            set { _sWarrantyCardNo = value; }
        }


        private string _sExtendedWarrantyDescription;
        public string ExtendedWarrantyDescription
        {
            get { return _sExtendedWarrantyDescription; }
            set { _sExtendedWarrantyDescription = value; }
        }

        private int _nInvoiceID;
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        private int _nProductID;
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private string _sProductSerialNo;
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value; }
        }
        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        private int _nEComOrderID;
        public int EComOrderID
        {
            get { return _nEComOrderID; }
            set { _nEComOrderID = value; }
        }


        public void Add()
        {
            int nWarrantyParameterID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WarrantyParameterID]) FROM t_WarrantyParameter";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nWarrantyParameterID = 1;
                }
                else
                {
                    nWarrantyParameterID = Convert.ToInt32(maxID) + 1;
                }
                _nWarrantyParameterID = nWarrantyParameterID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();


                sSql = "INSERT INTO t_WarrantyParameter VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyParameterID", _nWarrantyParameterID);
                cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);
                cmd.Parameters.AddWithValue("ServiceValidity", _nServiceValidity);
                cmd.Parameters.AddWithValue("SpareValidity", _nSpareValidity);
                cmd.Parameters.AddWithValue("SpecialPartValidity", _nSpecialPartValidity);
                cmd.Parameters.AddWithValue("EffectiveFrom", _dEffectiveFrom);
                cmd.Parameters.AddWithValue("CreatedBy", _nCreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _dCreatedDate);
                cmd.Parameters.AddWithValue("UploadStatus", _nUploadStatus);
                cmd.Parameters.AddWithValue("DownloadStatus", _nDownloadStatus);

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

                sSql = "Delete t_WarrantyParameter WHERE WarrantyCategoryID=?";
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
        public void GetWarrantyPerameter()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyParameter "
                          + " where WarrantyCategoryID=? and EffectiveFrom <= ? ";
            cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);
            cmd.Parameters.AddWithValue("EffectiveFrom", _dEffectiveFrom);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _nServiceValidity = int.Parse(reader["ServiceValidity"].ToString());
                    _nSpareValidity = int.Parse(reader["SpareValidity"].ToString());
                    _nSpecialPartValidity = int.Parse(reader["SpecialPartValidity"].ToString());

                }

                reader.Close();

            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetNextWarrantyCardNo(int nInvoiceID, int nWarehouseID,int nProductID, int nWarrantyParamID,string sBarcode)
        {

            
            try
            {
                int nWarrentCardNo = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "SELECT MAX([NextWarrantyCardNo]) FROM t_NextDocumentNo ";
                cmd.CommandText = sSql;
                object MaxWarrantyCardNo = cmd.ExecuteScalar();
                if (MaxWarrantyCardNo == DBNull.Value)
                {
                    nWarrentCardNo = 1;
                }
                else
                {
                    nWarrentCardNo = int.Parse(MaxWarrantyCardNo.ToString());
                }
                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();
                DateTime dt = Convert.ToDateTime(oSystemInfo.OperationDate);
                string sYear = dt.Year.ToString();

                _sWarrantyCardNo = oSystemInfo.Shortcode + "-" + sYear.Substring(2, 2) + "-" + nWarrentCardNo.ToString("000000");

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SalesInvoiceWarrantyCardNo (OutletID,InvoiceID,ProductID,WarrantyCardNo,ProductSerialNo,WarrantyParameterID) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletID", oSystemInfo.WarehouseID);
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("WarrantyCardNo", _sWarrantyCardNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", sBarcode);
                cmd.Parameters.AddWithValue("WarrantyParameterID", nWarrantyParamID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();            
                             
                nWarrentCardNo = nWarrentCardNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextWarrantyCardNo='" + nWarrentCardNo + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertSalesInvoiceWarrantyCard(int nInvoiceID, int nWarehouseID, int nProductID, int nWarrantyParamID, string sBarcode,string sExtendedWarranty,int nWarrantyID)
        {


            try
            {
                int nWarrentCardNo = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "SELECT MAX([NextWarrantyCardNo]) FROM t_NextDocumentNo ";
                cmd.CommandText = sSql;
                object MaxWarrantyCardNo = cmd.ExecuteScalar();
                if (MaxWarrantyCardNo == DBNull.Value)
                {
                    nWarrentCardNo = 1;
                }
                else
                {
                    nWarrentCardNo = int.Parse(MaxWarrantyCardNo.ToString());
                }
                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();
                DateTime dt = Convert.ToDateTime(oSystemInfo.OperationDate);
                string sYear = dt.Year.ToString();

                _sWarrantyCardNo = oSystemInfo.Shortcode + "-" + sYear.Substring(2, 2) + "-" + nWarrentCardNo.ToString("000000");

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SalesInvoiceWarrantyCardNo (OutletID,InvoiceID,ProductID,WarrantyCardNo,ProductSerialNo,WarrantyParameterID,ExtendedWarrantyDescription,ExtendedWarrantyID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletID", oSystemInfo.WarehouseID);
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("WarrantyCardNo", _sWarrantyCardNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", sBarcode);
                cmd.Parameters.AddWithValue("WarrantyParameterID", nWarrantyParamID);
                cmd.Parameters.AddWithValue("ExtendedWarrantyDescription", sExtendedWarranty);
                cmd.Parameters.AddWithValue("ExtendedWarrantyID", nWarrantyID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nWarrentCardNo = nWarrentCardNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextWarrantyCardNo='" + nWarrentCardNo + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertSalesInvoiceWarrantyCardRT(int nInvoiceID, int nWarehouseID, int nProductID, int nWarrantyParamID, string sBarcode, string sExtendedWarranty, int nWarrantyID)
        {


            try
            {
                int nWarrentCardNo = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "SELECT NextWarrantyCardNo FROM t_Showroom where WarehouseID=" + nWarehouseID + " ";
                cmd.CommandText = sSql;
                object MaxWarrantyCardNo = cmd.ExecuteScalar();
                if (MaxWarrantyCardNo == DBNull.Value)
                {
                    nWarrentCardNo = 1;
                }
                else
                {
                    nWarrentCardNo = int.Parse(MaxWarrantyCardNo.ToString());
                }

                _sWarrantyCardNo = Utility.Shortcode + "-" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + nWarrentCardNo.ToString("000000");

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SalesInvoiceWarrantyCardNo (OutletID,InvoiceID,ProductID,WarrantyCardNo,ProductSerialNo,WarrantyParameterID,ExtendedWarrantyDescription,ExtendedWarrantyID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletID", nWarehouseID);
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("WarrantyCardNo", _sWarrantyCardNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", sBarcode);
                cmd.Parameters.AddWithValue("WarrantyParameterID", nWarrantyParamID);
                cmd.Parameters.AddWithValue("ExtendedWarrantyDescription", sExtendedWarranty);
                cmd.Parameters.AddWithValue("ExtendedWarrantyID", nWarrantyID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nWarrentCardNo = nWarrentCardNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_Showroom set NextWarrantyCardNo='" + nWarrentCardNo + "' where WarehouseID=" + nWarehouseID + " ";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetWarrantyCardNo(int nInvoiceID, int nProductID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo "
                          + " where InvoiceID=? and ProductID = ? ";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _sWarrantyCardNo = (string)reader["WarrantyCardNo"];               

                }
                reader.Close();

            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckWarrantyCard(int nInvoiceID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo where InvoiceID=? ";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            int nCount = 0;
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
            if (nCount == 0)
                return false;
            else return true;
        }
        public bool CheckWarrantyCard(long nInvoiceID, int nProductID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo where InvoiceID=? and ProductID=? ";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            int nCount = 0;
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
            if (nCount == 0)
                return false;
            else return true;
        }

        public bool CheckWarrantyCardBySerial(int nInvoiceID,string sProductSerialNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo where InvoiceID=? and ProductSerialNo=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.Parameters.AddWithValue("ProductSerialNo", sProductSerialNo);
            int nCount = 0;
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
            if (nCount == 0)
                return false;
            else return true;
        }
    }
    public class WarrantyCategory : CollectionBase
    {
        public WarrantyParameter this[int i]
        {
            get { return (WarrantyParameter)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(WarrantyParameter oWarrantyParameter)
        {
            InnerList.Add(oWarrantyParameter);
        }

        private int _nWarrantyCategoryID;
        private string _sName;
        private int _nCreatedBy;
        private DateTime _dCreatedDate;
        private int _nUploadStatus;
        private int _nDownloadStatus;
        private int _nTransferType;

        /// <summary>
        /// Get set property for WarrantyCategoryID
        /// </summary>
        public int WarrantyCategoryID
        {
            get { return _nWarrantyCategoryID; }
            set { _nWarrantyCategoryID = value; }
        }

        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CreatedBy
        /// </summary>
        public int CreatedBy
        {
            get { return _nCreatedBy; }
            set { _nCreatedBy = value; }
        }

        /// <summary>
        /// Get set property for CreatedDate
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _dCreatedDate; }
            set { _dCreatedDate = value; }
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
        public int TransferType
        {
            get { return _nTransferType; }
            set { _nTransferType = value; }
        }
        WarrantyProducts oWarrantyProducts;
        public WarrantyProducts WarrantyProducts
        {
            get
            {
                if (oWarrantyProducts == null)
                {
                    oWarrantyProducts = new WarrantyProducts();
                }
                return oWarrantyProducts;
            }
        }

        public void Add()
        {
            int nMaxWarrantyCategoryID = 0;          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WarrantyCategoryID]) FROM t_WarrantyCategory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWarrantyCategoryID = 1;
                }
                else
                {
                    nMaxWarrantyCategoryID = Convert.ToInt32(maxID) + 1;
                }
                _nWarrantyCategoryID = nMaxWarrantyCategoryID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();


                sSql = "INSERT INTO t_WarrantyCategory VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("CreatedBy", _nCreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _dCreatedDate);
                cmd.Parameters.AddWithValue("UploadStatus", _nUploadStatus);
                cmd.Parameters.AddWithValue("DownloadStatus", _nDownloadStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach ( WarrantyParameter oWarrantyParameter in this)
                {
                    oWarrantyParameter.WarrantyCategoryID = _nWarrantyCategoryID;
                    oWarrantyParameter.Add();
                }
                foreach (WarrantyProduct oWarrantyProduct in oWarrantyProducts)
                {
                    oWarrantyProduct.WarrantyCategoryID = _nWarrantyCategoryID;
                    oWarrantyProduct.Add();
                }
               
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
            int nCount = 0;
            try
            {                           

                sSql = "UPDATE t_WarrantyCategory SET Name=? WHERE WarrantyCategoryID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (WarrantyParameter oWarrantyParameter in this)
                {
                    oWarrantyParameter.WarrantyCategoryID = _nWarrantyCategoryID;

                    if (nCount == 0)
                    {
                        oWarrantyParameter.Delete();
                        nCount++;
                    }
                    oWarrantyParameter.Add();
                }
                nCount = 0;
                foreach (WarrantyProduct oWarrantyProduct in oWarrantyProducts)
                {
                    oWarrantyProduct.WarrantyCategoryID = _nWarrantyCategoryID;
                    if (nCount == 0)
                    {
                        oWarrantyProduct.Delete();
                        nCount++;
                    }
                    oWarrantyProduct.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WarrantyParameter oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oWarrantyParameter.ProductID = int.Parse(reader["ProductID"].ToString());
                    oWarrantyParameter.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oWarrantyParameter.WarrantyCardNo = (string)reader["WarrantyCardNo"];
                    oWarrantyParameter.WarrantyParameterID = (int)reader["WarrantyParameterID"];
                    oWarrantyParameter.WarehouseID = (int)reader["OutletID"];


                    if (reader["ExtendedWarrantyDescription"] != DBNull.Value)
                        oWarrantyParameter.ExtendedWarrantyDescription = reader["ExtendedWarrantyDescription"].ToString();
                    else oWarrantyParameter.ExtendedWarrantyDescription = "";

                    

                    

                    InnerList.Add(oWarrantyParameter);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByProductSerialNo(int nInvoiceID,string sProductSerialNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo where InvoiceID=? and ProductSerialNo=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.Parameters.AddWithValue("ProductSerialNo", sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WarrantyParameter oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oWarrantyParameter.ProductID = int.Parse(reader["ProductID"].ToString());
                    oWarrantyParameter.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oWarrantyParameter.WarrantyCardNo = (string)reader["WarrantyCardNo"];
                    oWarrantyParameter.WarrantyParameterID = (int)reader["WarrantyParameterID"];
                    oWarrantyParameter.WarehouseID = (int)reader["OutletID"];


                    if (reader["ExtendedWarrantyDescription"] != DBNull.Value)
                        oWarrantyParameter.ExtendedWarrantyDescription = reader["ExtendedWarrantyDescription"].ToString();
                    else oWarrantyParameter.ExtendedWarrantyDescription = "";





                    InnerList.Add(oWarrantyParameter);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDataForEcmOrder(int nOrderID, int WHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select " + WHID + " as OutletID,a.EcomOrderID,a.ProductID, " +
                        " Outlet +'-'+ OrderNo+'-'+'000'+ CONVERT(varchar(10), SerialNo) as WarrantyCardNo, "+
                        " ProductSerialNo,WarrantyParamID "+
                        " from dbo.t_SalesInvoiceEcommerceProductSerial a,t_WarrantyParam b, "+
                        " t_SalesInvoiceEcommerce c " +
                        " where a.ProductID=b.ProductID and a.EcomOrderID=c.EcomOrderID and a.EcomOrderID = " + nOrderID + "";
            
            
            //cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WarrantyParameter oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.WarehouseID = (int)reader["OutletID"];
                    oWarrantyParameter.EComOrderID = int.Parse(reader["EcomOrderID"].ToString());
                    oWarrantyParameter.ProductID = int.Parse(reader["ProductID"].ToString());
                    oWarrantyParameter.WarrantyCardNo = (string)reader["WarrantyCardNo"];
                    oWarrantyParameter.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oWarrantyParameter.WarrantyParameterID = (int)reader["WarrantyParamID"];

                    InnerList.Add(oWarrantyParameter);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetMaxID()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select Max(ID) as ID from t_SalesInvoiceWarrantyCardNo";
            int nMaxID = 0;

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nMaxID = int.Parse(reader["ID"].ToString());
                }

                reader.Close();

            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return nMaxID;
        }
        public void RefreshWarrantyPerameter()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyParameter "
                          + " where WarrantyCategoryID=? ";
            cmd.Parameters.AddWithValue("WarrantyCategoryID", _nWarrantyCategoryID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WarrantyParameter oWarrantyParameter = new WarrantyParameter();

                    oWarrantyParameter.WarrantyParameterID = int.Parse(reader["WarrantyParameterID"].ToString());
                    oWarrantyParameter.WarrantyCategoryID = int.Parse(reader["WarrantyCategoryID"].ToString());
                    oWarrantyParameter.ServiceValidity = int.Parse(reader["ServiceValidity"].ToString());
                    oWarrantyParameter.SpareValidity = int.Parse(reader["SpareValidity"].ToString());
                    oWarrantyParameter.SpecialPartValidity = int.Parse(reader["SpecialPartValidity"].ToString());
                    oWarrantyParameter.EffectiveFrom = Convert.ToDateTime(reader["EffectiveFrom"].ToString());

                    InnerList.Add(oWarrantyParameter);
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
    public class Warranties : CollectionBase
    {
        public WarrantyCategory this[int i]
        {
            get { return (WarrantyCategory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(WarrantyCategory oWarrantyCategory)
        {
            InnerList.Add(oWarrantyCategory);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyCategory";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WarrantyCategory oWarrantyCategory = new WarrantyCategory();

                    oWarrantyCategory.WarrantyCategoryID = int.Parse(reader["WarrantyCategoryID"].ToString());
                    oWarrantyCategory.Name = reader["Name"].ToString();
                    oWarrantyCategory.RefreshWarrantyPerameter();
                    oWarrantyCategory.WarrantyProducts.Refresh(oWarrantyCategory.WarrantyCategoryID);

                    InnerList.Add(oWarrantyCategory);
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
