// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 05, 2012
// Time :  09:56 AM
// Description: Class for Sales Invoice Product Serial Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class;

namespace CJ.Class
{
    public class SalesInvoiceProductSerial
    {
        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        private long _nInvoiceID;
        private int _nProductID;
        private int _nSerialNo;
        private string _sProductSerialNo;
        private DateTime _dEntryDate;
        private int _nEntryUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;

        private string _sInvoiceNo;
        private string _sProductCode;
        private string _sProductName;
        private long _nQuantity;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nMatchProductQty;
        private int _nChannelID;
        private int _nTranID;
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private int _nIsCount;
        /// <summary>
        /// Get set property for IsCount
        /// </summary>
        public int IsCount
        {
            get { return _nIsCount; }
            set { _nIsCount = value; }
        }

        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private int _nIsExistingProduct;
        public int IsExistingProduct
        {
            get { return _nIsExistingProduct; }
            set { _nIsExistingProduct = value; }
        }

        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public int SerialNo
        {
            get { return _nSerialNo; }
            set { _nSerialNo = value; }
        }
        /// <summary>
        /// Get set property for ProductSerialNo
        /// </summary>
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value; }
        }
        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        /// <summary>
        /// Get set property for EntryUserID
        /// </summary>
        public int EntryUserID
        {
            get { return _nEntryUserID; }
            set { _nEntryUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
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
        /// Get set property for Quantity
        /// </summary>
        public long Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }
        /// <summary>
        /// Get set property for CustomerCode
        /// </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for MatchProductQty
        /// </summary>
        public int MatchProductQty
        {
            get { return _nMatchProductQty; }
            set { _nMatchProductQty = value; }
        }
        /// <summary>
        /// Get set property for ChannelID
        /// </summary>
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        public void DeleteFromHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ProductStockSerialHO Where ProductSerialNo=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void InsertTELHQ(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_ProductTransferProductSerial VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SerialNo", 0);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("WarehouseID", null);
                cmd.Parameters.AddWithValue("Status", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertHOStockSerial(long nTranID, int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "insert into t_ProductStockSerialHO (ProductStockTranID,WHID,ProductID,ProductSerialNo) values (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductStockTranID", nTranID);
                cmd.Parameters.AddWithValue("WHID", nWHID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_SalesInvoiceProductSerial (InvoiceID,ProductID,SerialNo,ProductSerialNo) " +
                " VALUES (?,?,?,?)";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

                //cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                //cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// DMS Product Serial 
        /// Shuvo
        /// Date-19-Dec-2016
        /// </summary>

        public void AddDMSStockSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_DMSProductStockSerial (TranID, ProductID, ProductSerial, Status) VALUES (?,?,?,?)";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddIMEI()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_SalesInvoiceProductSerial (InvoiceID,ProductID,SerialNo,ProductSerialNo) " +
                " VALUES (?,?,?,?)";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                AppLogger.LogInfo("Successfully Upload IMEI");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Uploading IMEI /" + ex.Message);
                throw (ex);
            }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_SalesInvoiceProductSerial (InvoiceID,ProductID,SerialNo,ProductSerialNo) " +
                " VALUES (?,?,?,?)";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckProductSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_SalesInvoiceProductSerial where ProductSerialNo=?";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nInvoiceID = Convert.ToInt64(reader["InvoiceID"]);
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
        public bool CheckProductSerialforPrint()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,count(InvoiceID) as IsCount From t_SalesinvoiceProductSerial  " +
                          "where ProductSerialNo = ? group by InvoiceID";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nInvoiceID = Convert.ToInt64(reader["InvoiceID"]);
                    _nIsCount = Convert.ToInt32(reader["IsCount"]);
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

        public bool CheckGeneratedBarcode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductSerialNo Where ProductCode=? AND WarrantyCardNo=?";

            cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
            cmd.Parameters.AddWithValue("WarrantyCardNo", _sProductSerialNo);

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
                return true;
            else return false;
        }
        public bool CheckIMEI()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductID, ProductSerialNo from t_productTransferProductSerial Where ProductID=? AND ProductSerialNo=? ";

            cmd.Parameters.AddWithValue("ProductID",_nProductID);
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

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
                return true;
            else return false;
        }
        public bool CheckIMEIfromGRD()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductID, IMEINo from t_IMEISource2 Where ProductID=? AND IMEINo=? ";

            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            cmd.Parameters.AddWithValue("IMEINo", _sProductSerialNo);

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
                return true;
            else return false;
        }
        public void GetChannelByInvoiceID(long nInvoID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ChannelID from t_SalesInvoice SI INNER JOIN t_Customer C ON C.CustomerID=SI.CustomerID "+
                            "INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID Where InvoiceID=?";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nChannelID = (int)reader[ChannelID]; 
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetProductCodeByBarcode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ProductSerialNo where WarrantyCardNo=?";
            cmd.Parameters.AddWithValue("WarrantyCardNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }
        public void GetUnusedBarcodeHoNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode,ProductSerialNo From t_ProductStockSerialHO a,t_Product b where a.ProductID = b.ProductID and ProductSerialNo = ? and WHID=?";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
            cmd.Parameters.AddWithValue("WHID", _nWarehouseID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetCodeByBarcode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ProductBarCodeDetail a,t_Product b where a.ProductID = b.ProductID and Barcode = ?";
            cmd.Parameters.AddWithValue("Barcode", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetProductIDByIMEI()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode, ProductSerialNo from t_productTransferProductSerial a, t_Product b Where a.ProductID=b.ProductID "+
                            "AND ProductSerialNo=? and ProductSerialNo NOT IN (Select ProductSerialNo from t_SalesInvoiceProductSerial)";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetProductIDByIMEIFromGRDData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode, IMEINO as ProductSerialNo from t_IMEISource2 a, t_Product b Where a.ProductID=b.ProductID "+
                "AND IMEINO= ? and IMEINO NOT IN (Select ProductSerialNo from t_SalesInvoiceProductSerial)";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        //public void MatchProduct()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "Select InvoiceID,Count (ProductID)as Qty from (Select InvoiceID,ProductID,EligibleQty,EntryQty from ( "+
        //                    "Select SID.InvoiceID, SID.ProductID,Quantity as EligibleQty, IsNull(EntryQty,0) as EntryQty  from "+
        //                    "t_SalesInvoiceDetail SID INNER JOIN (Select * from t_WarrantyParam Where IsStoreBarcode=1) WP ON SID.ProductID=WP.ProductID Left Outer JOIN " + 
        //                    "(Select InvoiceID,ProductID, Count(ProductID) as EntryQty from t_SalesInvoiceProductSerial Group by InvoiceID,ProductID)A "+
        //                    "ON A.InvoiceID=SID.InvoiceID AND A.ProductID=SID.ProductID)F Where EligibleQty <> EntryQty AND InvoiceID=? "+
        //                    ")Final Group by InvoiceID";

        //    cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            _nMatchProductQty = (int)reader["Qty"];   
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}
        public void MatchProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,Count (ProductID)as Qty " +
                        "from ( " +
                        "Select InvoiceID,ProductID,EligibleQty,EntryQty from  " +
                        "( " +
                        "Select SID.InvoiceID, SID.ProductID,Quantity as EligibleQty, IsNull(EntryQty,0) as EntryQty  from  " +
                        "t_SalesInvoiceDetail SID  " +
                        //"INNER JOIN  " +
                        //"( " +
                        //"Select * from t_WarrantyParam Where IsStoreBarcode=1) WP ON SID.ProductID=WP.ProductID  " +
                        "Left Outer JOIN  " +
                        "( " +
                        "Select InvoiceID,ProductID,sum(EntryQty) EntryQty From  " +
                        "(Select InvoiceID,a.ProductID, Count(a.ProductID) as EntryQty from t_SalesInvoiceProductSerial a,t_Product b  " +
                        "where a.ProductID=b.ProductID and isbarcodeItem=1 Group by InvoiceID,a.ProductID " +
                        "union all " +
                        "Select InvoiceID,a.ProductID, sum(Quantity) as EntryQty from t_SalesInvoiceDetail a,t_Product b " +
                        "where a.ProductID=b.ProductID and isbarcodeItem=0 " +
                        "Group by InvoiceID,a.ProductID) a group by InvoiceID,ProductID " +
                        ")A " +
                        "ON A.InvoiceID=SID.InvoiceID AND A.ProductID=SID.ProductID)F Where EligibleQty <> EntryQty AND InvoiceID = ? " +
                        ")Final  " +
                        "Group by InvoiceID";

            cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nMatchProductQty = (int)reader["Qty"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByInvoiceID(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select SI.InvoiceID,SI.WarehouseID, InvoiceNo,SID.ProductID,P.ProductCode, P.ProductName,Quantity,CustomerCode, customerName  "+
                            "from t_SalesInvoice SI INNER JOIN t_SalesInvoiceDetail SID ON SI.InvoiceID=SID.InvoiceID INNER JOIN t_Product P "+
                            "ON P.ProductID=SID.ProductID INNER JOIN t_Customer C ON C.CustomerID=SI.CustomerID Where SI.InvoiceID=?";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    _nInvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _nWarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _nQuantity = Convert.ToInt64(reader["Quantity"].ToString());
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBarcode()
        {

            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from dbo.t_SalesInvoiceProductSerial where InvoiceID=? and ProductID=?";

            cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (nCount == 0)
                        _sProductSerialNo = (string)reader["ProductSerialNo"];
                    else _sProductSerialNo = _sProductSerialNo + "," + (string)reader["ProductSerialNo"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void DeleteIMEI()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                Complain oItem = new Complain();

                cmd.CommandText = "DELETE FROM t_SalesInvoiceProductSerial WHERE [InvoiceID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void UpdateSerial(string sProductSerialNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                Complain oItem = new Complain();

                cmd.CommandText = "Update t_SalesInvoiceProductSerial SET ProductSerialNo='" + sProductSerialNo + "' WHERE ProductSerialNo=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public bool CheckVatPaidProductSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ProductStockSerialVatPaid where ProductSerialNo= ?";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
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

        public bool CheckVatPaidProductSerialByWH(int WHID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ProductStockSerialVatPaid where ProductSerialNo= ? and WHID=" + WHID + "";
            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
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
    public class SalesInvoiceProductSerials : CollectionBase
    {
        public SalesInvoiceProductSerial this[int i]
        {
            get { return (SalesInvoiceProductSerial)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoiceProductSerial oSalesInvoiceProductSerial)
        {
            InnerList.Add(oSalesInvoiceProductSerial);
        }

        public void Refresh(long nInvoiceID)
        {
            string sSql="";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (Utility.CompanyInfo == "TEL")
            {
                        sSql = "Select SI.InvoiceID, InvoiceNo,SID.ProductID,P.ProductCode, P.ProductName,Quantity,CustomerCode, customerName " +
                                "from t_SalesInvoice SI INNER JOIN t_SalesInvoiceDetail SID ON SI.InvoiceID=SID.InvoiceID INNER JOIN t_Product P " +
                                "ON P.ProductID=SID.ProductID INNER JOIN t_Customer C ON C.CustomerID=SI.CustomerID "+
                                //"INNER JOIN " +
                                //"(Select * from t_WarrantyParam Where IsStoreBarcode=1 AND IsCurrent=1) WP " +
                                //"ON WP.ProductID=SID.ProductID "+
                                "Left Outer JOIN t_SalesInvoiceProductSerial SIPS " +
                                "ON SIPS.InvoiceID=SID.InvoiceID AND SIPS.ProductID=SID.ProductID " +
                                "Where SIPS.InvoiceID Is Null AND IsBarcodeItem=1 and  SI.InvoiceID=?";
            }
            else if (Utility.CompanyInfo == "TML")
            {
                sSql = "Select SI.InvoiceID, InvoiceNo,SID.ProductID,P.ProductCode, P.ProductName,Quantity,CustomerCode, customerName " +
                        "from t_SalesInvoice SI INNER JOIN t_SalesInvoiceDetail SID ON SI.InvoiceID=SID.InvoiceID INNER JOIN v_ProductDetails P " +
                        "ON P.ProductID=SID.ProductID INNER JOIN t_Customer C ON C.CustomerID=SI.CustomerID "+ 
                        "Left Outer JOIN t_SalesInvoiceProductSerial SIPS " +
                        "ON SIPS.InvoiceID=SID.InvoiceID AND SIPS.ProductID=SID.ProductID " +
                        "Where SIPS.InvoiceID Is Null AND SI.InvoiceID=?";
            }

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                    oSalesInvoiceProductSerial.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oSalesInvoiceProductSerial.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesInvoiceProductSerial.ProductID = (int)reader["ProductID"];
                    oSalesInvoiceProductSerial.ProductCode = (string)reader["ProductCode"];
                    oSalesInvoiceProductSerial.ProductName = (string)reader["ProductName"];
                    oSalesInvoiceProductSerial.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                    oSalesInvoiceProductSerial.CustomerCode = (string)reader["CustomerCode"];
                    oSalesInvoiceProductSerial.CustomerName = (string)reader["CustomerName"];

                    InnerList.Add(oSalesInvoiceProductSerial);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByInvoiceID(long nInvoiceID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT SI.InvoiceID,Quantity, SID.ProductID, ProductCode, ProductName " +
                            "FROM t_SalesInvoice SI, t_SalesInvoiceDetail SID, t_Product P " +
                            "Where SI.InvoiceID=SID.InvoiceID AND SID.ProductID=P.ProductID AND SI.InvoiceID=? " +
                            "AND SI.InvoiceID Not IN (Select InvoiceID from t_SalesInvoiceProductSerial Where InvoiceID=?)";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                    oSalesInvoiceProductSerial.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oSalesInvoiceProductSerial.ProductID = (int)reader["ProductID"];
                    oSalesInvoiceProductSerial.ProductCode = (string)reader["ProductCode"];
                    oSalesInvoiceProductSerial.ProductName = (string)reader["ProductName"];
                    oSalesInvoiceProductSerial.Quantity = Convert.ToInt64(reader["Quantity"].ToString());

                    InnerList.Add(oSalesInvoiceProductSerial);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GETSerialByInvoiceID(long nInvoiceID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_SalesInvoiceProductSerial Where InvoiceID=? Order by ProductID ASC ";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                    oSalesInvoiceProductSerial.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oSalesInvoiceProductSerial.ProductID = (int)reader["ProductID"];
                    oSalesInvoiceProductSerial.SerialNo = (int)reader["SerialNo"];
                    oSalesInvoiceProductSerial.ProductSerialNo = (string)reader["ProductSerialNo"];

                    InnerList.Add(oSalesInvoiceProductSerial);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GETBENoByInvoiceID(long nInvoiceID)
        {
            string sBIENo = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select distinct ISNULL(BENo,'') BENo, " +
                        "isnull(CONVERT(varchar, BEDate, 6), '') BEDate from t_SalesInvoiceProductSerial A " +
                        "LEFT OUTER JOIN " +
                        "t_ProductBarCodeDetail B " +
                        "ON A.ProductSerialNo = B.Barcode AND A.ProductID = B.ProductID " +
                        "WHERE invoiceID = " + nInvoiceID + " and BeNo is not null";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sBIENo == "")
                    {
                        if ((string)reader["BENo"] != "")
                        {
                            sBIENo = "[" + (string)reader["BENo"] + "]" + (string)reader["BEDate"];
                        }
                        else
                        {
                            sBIENo = "";
                        }
                    }
                    else
                    {
                            sBIENo = sBIENo + "," + "[" + (string)reader["BENo"] + "]" + (string)reader["BEDate"];
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sBIENo;
        }

        public string GETBENoByBarcodeRT(string sBarcode)
        {
            string sBIENo = "";
            string sBEDate = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select isnull(BENo,'') BENo,BEDate From t_ProductBarCodeDetail where Barcode in (" + sBarcode + ")";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["BEDate"] != DBNull.Value)
                    {
                        sBEDate = Convert.ToDateTime(reader["BEDate"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        sBEDate = "";
                    }

                    if (sBIENo == "")
                    {
                        if ((string)reader["BENo"] != "")
                        {
                            sBIENo = "[" + (string)reader["BENo"] + "]" + sBEDate;
                        }
                        else
                        {
                            sBIENo = "";
                        }
                    }
                    else
                    {
                        sBIENo = sBIENo + "," + "[" + (string)reader["BENo"] + "]" + sBEDate;
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sBIENo;
        }
        public void GetBarcodeByInvoiceNProduct(long nInvoID, int ProdID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,SIPS.ProductID,ProductSerialNo, ProductCode from t_SalesInvoiceProductSerial SIPS "+
                            "INNER JOIN t_Product P ON SIPS.ProductID=P.ProductID Where InvoiceID=? AND SIPS.ProductID=?";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoID);
            cmd.Parameters.AddWithValue("ProductID", ProdID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                    oSalesInvoiceProductSerial.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oSalesInvoiceProductSerial.ProductID = (int)reader["ProductID"];
                    oSalesInvoiceProductSerial.ProductCode = (string)reader["ProductCode"];
                    oSalesInvoiceProductSerial.ProductSerialNo = (string)reader["ProductSerialNo"];

                    InnerList.Add(oSalesInvoiceProductSerial);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetProductByInvoice(long nInvoID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,SID.ProductID,ProductCode from t_SalesInvoiceDetail SID INNER JOIN t_Product P " +
                            "ON P.ProductID=SID.ProductID Where InvoiceID=?";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                    oSalesInvoiceProductSerial.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oSalesInvoiceProductSerial.ProductID = (int)reader["ProductID"];
                    oSalesInvoiceProductSerial.ProductCode = (string)reader["ProductCode"];

                    InnerList.Add(oSalesInvoiceProductSerial);
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
