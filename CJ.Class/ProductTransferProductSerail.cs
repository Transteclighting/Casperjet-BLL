// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Shahnoor Saeed
// Date: May 14, 2011
// Time :  9:33 AM
// Description: Class for Product Transfer Product Serial
// Modify Person And Date: Md. Abdul Hakim (23-Sep-2013 : 11:48 AM)
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
    public class ProductTransferProductSerial
    {
        private int _TranID;
        private int _ProductID;
        private int _SerialNo;
        private string _ProductSerialNo;
        private DateTime _EntryDate;
        private int _EntryUserID;
        private DateTime _UpdateDate;
        private int _UpdateUserID;
        private int _nWarehouseID;

        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public int SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        /// <summary>
        /// Get set property for ProductSerialNo
        /// </summary>
        /// 

        private double _TradePrice;
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        private int _IsVATPaidProduct;
        public int IsVATPaidProduct
        {
            get { return _IsVATPaidProduct; }
            set { _IsVATPaidProduct = value; }
        }

        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        public string ProductSerialNo
        {
            get { return _ProductSerialNo; }
            set { _ProductSerialNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
        /// <summary>
        /// Get set property for EntryUserID
        /// </summary>
        public int EntryUserID
        {
            get { return _EntryUserID; }
            set { _EntryUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _UpdateUserID; }
            set { _UpdateUserID = value; }
        }

        private string _sTranNo;
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }

        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        private int _nQty;
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        private string _sFromWHName;
        public string FromWHName
        {
            get { return _sFromWHName; }
            set { _sFromWHName = value; }
        }

        private string _sToWHName;
        public string ToWHName
        {
            get { return _sToWHName; }
            set { _sToWHName = value; }
        }


        public void Insert(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_ProductTransferProductSerial (TranID,ProductID,SerialNo,ProductSerialNo) VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("SerialNo", _SerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);

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
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("SerialNo", _SerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
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

        public void InsertHOStockSerial(long nTranID,int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "insert into t_ProductStockSerialHO (ProductStockTranID,WHID,ProductID,ProductSerialNo) values (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductStockTranID", nTranID);
                cmd.Parameters.AddWithValue("WHID", nWHID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertTML(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_ProductTransferProductSerial VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("SerialNo", _SerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Status", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByTranID(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select PST.TranID, TranNo,PSTI.ProductID,P.ProductCode, P.ProductName,Qty, (FW.WarehouseName +' [' + FW.WarehouseCode + ']') FromWarehouse, " +
                        "(TW.WarehouseName +' [' + TW.WarehouseCode + ']') ToWarehouse from t_ProductStockTran PST, t_ProductStockTranItem PSTI,t_Product P, t_Warehouse FW,t_Warehouse TW " +
                        "Where PST.TranID=? and PST.TranID=PSTI.TranID and P.ProductID=PSTI.ProductID and FW.WarehouseID=PST.FromWHID " +
                        "and TW.WarehouseID=ToWHID";

            cmd.Parameters.AddWithValue("TranID", nTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {



                    _TranID = Convert.ToInt32(reader["TranID"].ToString());
                    _sTranNo = (string)reader["TranNo"];
                    _ProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _nQty = Convert.ToInt32(reader["Qty"].ToString());
                    _sFromWHName = (string)reader["FromWarehouse"];
                    _sToWHName = (string)reader["ToWarehouse"];

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

            string sSql = "Select a.ProductID,ProductCode, Barcode from t_ProductBarCodeDetail a, t_Product b " +
                            "Where a.ProductID=b.ProductID AND Barcode=? and Barcode NOT IN  " +
                            "(Select ProductSerialNo from t_productTransferProductSerial)";
            cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _ProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetUnusedBarcode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode, Barcode from t_ProductBarCodeDetail a, t_Product b " +
                        "Where a.ProductID=b.ProductID AND Barcode = ? and Barcode NOT IN   " +
                        "(Select ProductSerialNo from t_productTransferProductSerial where ProductSerialNo Not IN ( " +
                        "Select ProductSerialNo from t_productTransferProductSerial a, t_ProductStockTran b  " +
                        "Where a.TranID=b.TranID and ToWHID = ? and b.Status = ?))";
            cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
            cmd.Parameters.AddWithValue("ToWHID", Utility.CentralRetailWarehouse);
            cmd.Parameters.AddWithValue("Status", (int)Dictionary.StockTransactionStatus.COMPLETE);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _ProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetUnusedBarcodeHo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode,Barcode From t_ProductBarCodeDetail a,t_Product b where a.ProductID = b.ProductID and Barcode = ?";
            cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _ProductID = (int)reader["ProductID"];
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
            cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
            cmd.Parameters.AddWithValue("WHID", _nWarehouseID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _ProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void GetUnusedBarcodeHoAddStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode,Barcode From t_ProductBarCodeDetail a,t_Product b where a.ProductID = b.ProductID and Barcode = ? ";
            cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _ProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetProductIDByBarcodePOS(int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.ProductID, ProductCode from t_ProductStockSerial a, t_product b " +
                            "Where a.ProductID=b.ProductID and Status=? and ProductSerialNo=?";
            cmd.Parameters.AddWithValue("Status", nStatus);
            cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _ProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];

                }
                reader.Close();

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

            string sSql = "SELECT * FROM t_productTransferProductSerial where ProductSerialNo=?";
            cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);

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
        public bool CheckIMEI()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_ProductBarCodeDetail Where ProductID=? AND Barcode=? ";

            cmd.Parameters.AddWithValue("ProductID", _ProductID);
            cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ProductTransferProductSerial Where TranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DeleteFromHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ProductStockSerialHO Where ProductSerialNo=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class ProductTransferProductSerials : CollectionBase
    {
        public ProductTransferProductSerial this[int i]
        {
            get { return (ProductTransferProductSerial)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductTransferProductSerial oProductTransferProductSerial)
        {
            InnerList.Add(oProductTransferProductSerial);
        }
        public void GetProductTransferProductSerial(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,isnull(b.TradePrice,0) TradePrice,isnull(b.VAT,0) VAT, " +
                        "isnull(IsVATPaidProduct,0) IsVATPaidProduct     " +
                        "From  " +
                        "( " +
                        "Select * from t_ProductTransferProductSerial " +
                        ")  a  " +
                        "Left Outer Join  " +
                        "( " +
                        "Select * From t_FinishedGoodsPrice b where IsCurrent=1 " +
                        ") b " +
                        "on a.ProductID=b.ProductID  " +
                        "Left Outer Join  " +
                        "( " +
                        "Select distinct ProductID,ProductSerialNo,1 as IsVATPaidProduct From t_ProductStockSerialVatPaid " +
                        ") c " +
                        "on a.ProductID=c.ProductID and a.ProductSerialNo=c.ProductSerialNo " +
                        "where TranID=? ";

            cmd.Parameters.AddWithValue("TranID", nTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    ProductTransferProductSerial oPTPS = new ProductTransferProductSerial();

                    oPTPS.TranID = (int)reader["TranID"];
                    oPTPS.ProductID = (int)reader["ProductID"];
                    oPTPS.SerialNo = (int)reader["SerialNo"];
                    oPTPS.ProductSerialNo = reader["ProductSerialNo"].ToString();

                    oPTPS.TradePrice = (double)reader["TradePrice"];
                    oPTPS.VAT = (double)reader["VAT"];
                    oPTPS.IsVATPaidProduct = (int)reader["IsVATPaidProduct"];

                    InnerList.Add(oPTPS);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProductByRequisition(int nRequisitionID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.* from t_ProductTransferProductSerial a, t_StockRequisition b " +
                            "where b.StockTranID=a.TranID and StockRequisitionID=?";

            cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransferProductSerial oPTPS = new ProductTransferProductSerial();
                    oPTPS.TranID = int.Parse(reader["TranID"].ToString());
                    oPTPS.ProductID = int.Parse(reader["ProductID"].ToString());
                    oPTPS.ProductSerialNo = (string)reader["ProductSerialNo"];

                    InnerList.Add(oPTPS);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nTranID)
        {
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSql = "Select PST.TranID, TranNo,PSTI.ProductID,P.ProductCode, P.ProductName,Qty, (FW.WarehouseName +' [' + FW.WarehouseCode + ']') FromWarehouse, " +
                        "(TW.WarehouseName +' [' + TW.WarehouseCode + ']') ToWarehouse from t_ProductStockTran PST, t_ProductStockTranItem PSTI,t_Product P, t_Warehouse FW,t_Warehouse TW " +
                        "Where PST.TranID=? and PST.TranID=PSTI.TranID and P.ProductID=PSTI.ProductID and FW.WarehouseID=PST.FromWHID " +
                        "and TW.WarehouseID=ToWHID";

            cmd.Parameters.AddWithValue("TranID", nTranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductTransferProductSerial oProductTransferProductSerial = new ProductTransferProductSerial();

                    oProductTransferProductSerial.TranID = Convert.ToInt32(reader["TranID"].ToString());
                    oProductTransferProductSerial.TranNo = (string)reader["TranNo"];
                    oProductTransferProductSerial.ProductID = (int)reader["ProductID"];
                    oProductTransferProductSerial.ProductCode = (string)reader["ProductCode"];
                    oProductTransferProductSerial.ProductName = (string)reader["ProductName"];
                    oProductTransferProductSerial.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oProductTransferProductSerial.FromWHName = (string)reader["FromWarehouse"];
                    oProductTransferProductSerial.ToWHName = (string)reader["ToWarehouse"];

                    InnerList.Add(oProductTransferProductSerial);
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
