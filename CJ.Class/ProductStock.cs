using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class
{
    public class ProductStock
    {
        protected int _nProductID;
        protected string _sProductCode;
        protected string _sProductName;
        protected int _nFromWarehouseID;
        protected int _nToWarehouseID;
        protected int _nWarehouseID;
        protected int _nStockType;
        protected long _nCurrentStock;
        protected long _nHOCurrentStock;
        protected double _nStockValue;
        protected double _nCurrentStockValue;
        protected int _nBookingStock;
        protected int _nTransitStock;
        protected int _nChannelID;
        protected int _nStatus;
        protected long _nQty;
        private bool _bFlag;
        private int _nMTDSaleQty;
        private int _nYTDSaleQty;
        private int _nDistributorID;
        private int _nALLShowroomStock;
        private int _nAllDepotStock;

        public long HOCurrentStock
        {
            get { return _nHOCurrentStock; }
            set { _nHOCurrentStock = value; }
        }
        public int ALLShowroomStock
        {
            get { return _nALLShowroomStock; }
            set { _nALLShowroomStock = value; }
        }
        public int AllDepotStock
        {
            get { return _nAllDepotStock; }
            set { _nAllDepotStock = value; }
        }
        public ProductStock()
        {
            _nProductID = 0;
            _sProductCode = string.Empty;
            _sProductName = string.Empty;
            _nFromWarehouseID = 0;
            _nToWarehouseID = 0;
            _nStockType = 0;
            _nCurrentStock = 0;
            _nCurrentStockValue = 0;
            _nBookingStock = 0;
            _nTransitStock = 0;
            _nChannelID = 0;
            _nStatus = 0;
        }


        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public int FromWarehouseID
        {
            get { return _nFromWarehouseID; }
            set { _nFromWarehouseID = value; }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public int ToWarehouseID
        {
            get { return _nToWarehouseID; }
            set { _nToWarehouseID = value; }
        }
        public int StockType
        {
            get { return _nStockType; }
            set { _nStockType = value; }
        }
        private long _nStockQty;
        public long StockQty
        {
            get { return _nStockQty; }
            set { _nStockQty = value; }
        }
        private long _nDefectiveStk;
        public long DefectiveStk
        {
            get { return _nDefectiveStk; }
            set { _nDefectiveStk = value; }
        }
        public long CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }
        public double StockValue
        {
            get { return _nStockValue; }
            set { _nStockValue = value; }
        }
        public double CurrentStockValue
        {
            get { return _nCurrentStockValue; }
            set { _nCurrentStockValue = value; }
        }
        public int BookingStock
        {
            get { return _nBookingStock; }
            set { _nBookingStock = value; }
        }
        public int TransitStock
        {
            get { return _nTransitStock; }
            set { _nTransitStock = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public long Quantity
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public int MTDSaleQty
        {
            get { return _nMTDSaleQty; }
            set { _nMTDSaleQty = value; }
        }
        public int YTDSaleQty
        {
            get { return _nYTDSaleQty; }
            set { _nYTDSaleQty = value; }
        }

        private string _sShortCode;
        public string ShortCode
        {
            get { return _sShortCode; }
            set { _sShortCode = value; }
        }

        protected long _nOutletCurrentStock;
        public long OutletCurrentStock
        {
            get { return _nOutletCurrentStock; }
            set { _nOutletCurrentStock = value; }
        }
        protected int _nOutletBookingStock;
        public int OutletBookingStock
        {
            get { return _nOutletBookingStock; }
            set { _nOutletBookingStock = value; }
        }


        private int _nAGID;
        private string _sAGName;
        private int _nASGID;
        private string _sASGName;
        private int _nMAGID;
        private string _sMAGName;
        private int _nBrandID;
        private string _sBrandDesc;

        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ProductStock VALUES (?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("StockType", (int)Dictionary.WareHouseStockType.SOUND);
                cmd.Parameters.AddWithValue("CurrentStock", _nCurrentStock);
                cmd.Parameters.AddWithValue("CurrentStockValue", 0);
                cmd.Parameters.AddWithValue("BookingStock", 0);
                cmd.Parameters.AddWithValue("TransitStock", 0);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("Status", 1);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = @"INSERT INTO t_ProductStock (ProductID,WarehouseID,StockType,CurrentStock,
                                   CurrentStockValue,BookingStock,TransitStock,ChannelID,Status) VALUES (?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("StockType", (int)Dictionary.WareHouseStockType.SOUND);
                cmd.Parameters.AddWithValue("CurrentStock", 0);
                cmd.Parameters.AddWithValue("CurrentStockValue", 0);
                cmd.Parameters.AddWithValue("BookingStock", 0);
                cmd.Parameters.AddWithValue("TransitStock", 0);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("Status", 1);           


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertCACStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_CACProductStock VALUES (?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("CurrentStock", 0);
                cmd.Parameters.AddWithValue("BookingStock", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update(double StockPrice)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "update t_ProductStock set CurrentStock=CurrentStock-?,CurrentStockValue=CurrentStockValue-?,BookingStock=BookingStock-? where  ChannelID = ? AND WarehouseID = ? AND ProductID = ? ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                cmd.Parameters.AddWithValue("CurrentStockValue", _nQty * StockPrice);
                cmd.Parameters.AddWithValue("BookingStock", _nQty);

                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() != 0)
                    _bFlag = true;
                else _bFlag = false;

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public void Update()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "update t_ProductStock set CurrentStock = ?, CurrentStockValue = ?, BookingStock = ? where  ChannelID = ? AND WarehouseID = ? AND ProductID = ? ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                cmd.Parameters.AddWithValue("CurrentStockValue", _nCurrentStockValue);
                cmd.Parameters.AddWithValue("BookingStock", _nBookingStock);

                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() != 0)
                    _bFlag = true;
                else _bFlag = false;

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

            string sSql = "update t_ProductStock set BookingStock=BookingStock+? where  ChannelID = ? AND WarehouseID = ? AND ProductID = ? ";

            try
            {
                cmd.CommandText = sSql;               
                cmd.Parameters.AddWithValue("BookingStock", _nQty);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);              
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() != 0)
                    _bFlag = true;
                else _bFlag = false;

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

            string sSql = "Delete from t_ProductStock where  ChannelID = ? AND WarehouseID = ? ";

            try
            {
                cmd.CommandText = sSql;

                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public void UpdateCurrentStock(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            if (IsTrue)
                sSql = "update t_ProductStock set CurrentStock=CurrentStock + ? where WarehouseID = ? AND ProductID = ? AND ChannelID = ?";
            else sSql = "update t_ProductStock set CurrentStock=CurrentStock - ? where WarehouseID = ? AND ProductID = ? AND ChannelID = ?";

            try
            {
                cmd.CommandText = "SELECT CurrentStock FROM t_ProductStock where WarehouseID = ? AND ProductID = ? AND ChannelID = ?";
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
               
                object CurrentStock = cmd.ExecuteScalar();

                if (IsTrue)
                {
                    _bFlag = true;
                }
                else
                {
                    if (int.Parse(CurrentStock.ToString()) < _nQty)
                    {
                        _bFlag = false;
                    }
                    else
                    {
                        _bFlag = true;
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.CommandType = CommandType.Text;

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (nCount == 0)
                {
                    _bFlag = false;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// Shuvo 
        /// Date-19-Dec-2016
        /// </summary>
        
        public void UpdateDMSCurrentStock(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            if (IsTrue)
                sSql = "update t_DMSProductStock set CurrentStock=CurrentStock + ? where DistributorID = ? AND ProductID = ?";
            else sSql = "update t_DMSProductStock set CurrentStock=CurrentStock - ? where DistributorID = ? AND ProductID = ?";

            try
            {
                cmd.CommandText = "SELECT CurrentStock FROM t_DMSProductStock where DistributorID = ? AND ProductID = ?";
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                object CurrentStock = cmd.ExecuteScalar();

                if (IsTrue)
                {
                    _bFlag = true;
                }
                else
                {
                    if (int.Parse(CurrentStock.ToString()) < _nQty)
                    {
                        _bFlag = false;
                    }
                    else
                    {
                        _bFlag = true;
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
  
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (nCount == 0)
                {
                    _bFlag = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void InsertDMSStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSProductStock VALUES (?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCurrentStock_POS(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql="";
            if (IsTrue)
                sSql = "update t_ProductStock set CurrentStock=CurrentStock - ? where   WarehouseID = ? AND ProductID = ? ";
            else sSql = "update t_ProductStock set CurrentStock=CurrentStock + ? where   WarehouseID = ? AND ProductID = ?";

            try
            {
                cmd.CommandText = "SELECT CurrentStock FROM t_ProductStock where WarehouseID = ? AND ProductID = ?";              
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                object CurrentStock = cmd.ExecuteScalar();
                if (int.Parse(CurrentStock.ToString()) < _nQty)
                {
                    _bFlag = false;
                }
                else
                {
                    _bFlag = true;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);            
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Update Product Stock");

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Updating Product Stock /" + ex.Message);
                throw (ex);
            }


        }
        public void UpdateBookingStock_POS(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (IsTrue)
                sSql = "update t_ProductStock set BookingStock=BookingStock + ? where  WarehouseID = ? AND ProductID = ?";
            else sSql = "update t_ProductStock set BookingStock=BookingStock - ? where WarehouseID = ? AND ProductID = ?";

            try
            {

                cmd.CommandText = "SELECT BookingStock FROM t_ProductStock where WarehouseID = ? AND ProductID = ?";             
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                object BookingStock = cmd.ExecuteScalar();
                if (int.Parse(BookingStock.ToString()) < _nQty)
                {
                    _bFlag = false;
                }
                else
                {
                    _bFlag = true;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("BookingStock", _nQty);           
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Update Booking Stock");

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Updating Booking Stock /" + ex.Message);
                throw (ex);
            }


        }
        public void UpdateTransitStock_POS(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (IsTrue)
                sSql = "update t_ProductStock set TransitStock=TransitStock + ? where  WarehouseID = ? AND ProductID = ?";
            else sSql = "update t_ProductStock set TransitStock=TransitStock -? where  WarehouseID = ? AND ProductID = ?";

            try
            {
                cmd.CommandText = "SELECT TransitStock FROM t_ProductStock where  WarehouseID = ? AND ProductID = ?";            
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                object TransitStock = cmd.ExecuteScalar();
                if (int.Parse(TransitStock.ToString()) < _nQty)
                {
                    _bFlag = false;
                }
                else
                {
                    _bFlag = true;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("TransitStock", _nQty);              
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateCurrentStock_GRD(bool IsAdd)
        {
            string sSql = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (IsAdd)
                sSql = "update t_ProductStock set CurrentStock=CurrentStock + ? where  ChannelID = ? AND WarehouseID = ? AND ProductID = ?";
            else sSql = "update t_ProductStock set CurrentStock=CurrentStock - ? where  ChannelID = ? AND WarehouseID = ? AND ProductID = ?";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() != 0)
                    _bFlag = true;
                else _bFlag = false;

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public void UpdateCACCurrentStock(bool IsAdd)
        {
            string sSql = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (IsAdd)
                sSql = "update t_CACProductStock set CurrentStock=CurrentStock + ? where ProductID = ?";
            else sSql = "update t_CACProductStock set CurrentStock=CurrentStock - ? where ProductID = ?";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nCurrentStock);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() != 0)
                    _bFlag = true;
                else _bFlag = false;

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public bool CheckProductStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStock where WarehouseID = ? AND ProductID = ?";
            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetProductStock(int nWarehouseID, int nStockType, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStock where WarehouseID = ? and StockType = ? AND ProductID = ? ";
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            cmd.Parameters.AddWithValue("StockType", nStockType);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductStockRT(int nWarehouseID, int nStockType, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select ProductID,isnull((CurrentStock-isnull(TransitStock,0)),0) as CurrentStock From t_ProductStock where WarehouseID = ? and StockType = ? AND ProductID = ? ";
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            cmd.Parameters.AddWithValue("StockType", nStockType);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProductStockWithMTD_YTD(int nWarehouseID, int nStockType, int nProductID, int nReqWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT Stk.ProductID, Stk.CurrentStock,Stk.BookingStock,IsNull(OutletStk.CurrentStock,0) as OutletCurrentStock, "+
            "IsNull(OutletStk.BookingStock,0) as OutletBookingStock,IsNull(MTDQty,0)MTDQty,IsNull(YTDQty,0)YTDQty FROM t_ProductStock Stk  "+
            "Left Outer JOIN (Select * from t_ProductStock Where WarehouseID=" + nReqWHID + ") OutletStk ON Stk.ProductID=OutletStk.ProductID " +
            "Left Outer JOIN " +
            "(Select ProductID, Sum(MTDQty) as MTDQty, Sum(YTDQty) as YTDQty from  " +
            "( " +
            "SELECT ProductID, 0 as MTDQty, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS YTDQty  " +
            "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty  " +
            "FROM (Select * from t_SalesInvoice Where WarehouseID=" + nReqWHID + ") AS im INNER JOIN  " +
            "t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID  " +
            "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND  " +
            "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3))  " +
            "GROUP BY cd.ProductID  " +
            "UNION ALL  " +
            "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty  " +
            "FROM (Select * from t_SalesInvoice Where WarehouseID=" + nReqWHID + ") AS im INNER JOIN  " +
            "t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID  " +
            "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND  " +
            "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3))  " +
            "GROUP BY cd.ProductID) AS p2  " +
            "GROUP BY ProductID " +
            "UNION ALL " +
            "SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS MTDQty, 0 as YTDQty  " +
            "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty  " +
            "FROM (Select * from t_SalesInvoice Where WarehouseID=" + nReqWHID + ") AS im INNER JOIN  " +
            "t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID  " +
            "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
            "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
            "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3))  " +
            "GROUP BY cd.ProductID  " +
            "UNION ALL  " +
            "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty  " +
            "FROM (Select * from t_SalesInvoice Where WarehouseID=" + nReqWHID + ") AS im INNER JOIN  " +
            "t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID  " +
            "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
            "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
            "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3))  " +
            "GROUP BY cd.ProductID) AS p2  " +
            "GROUP BY ProductID " +
            ") as a where productID=" + nProductID + " Group by ProductID )Sale " +
            "ON Stk.ProductID=Sale.ProductID " +
            "where Stk.WarehouseID = ? and Stk.StockType = ? AND Stk.ProductID = ? ";

            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            cmd.Parameters.AddWithValue("StockType", nStockType);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
                    _nOutletCurrentStock = int.Parse(reader["OutletCurrentStock"].ToString());
                    _nOutletBookingStock = int.Parse(reader["OutletBookingStock"].ToString());
                    _nMTDSaleQty = int.Parse(reader["MTDQty"].ToString());
                    _nYTDSaleQty = int.Parse(reader["YTDQty"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductStockWithMTD_YTDRT(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select ProductID, sum(HOCurrentStock) HOCurrentStock,sum(OutletCurrentStock) OutletCurrentStock, " +
                        "sum(MTDQty) MTDQty,sum(YTDQty) YTDQty From  " +
                        "( " +
                        "Select ProductID, 0 as HOCurrentStock,0 as OutletCurrentStock,SalesQty as MTDQty,0 as YTDQty From dwdb.dbo.t_SalesDataCustomerProduct where CompanyName='TEL' " +
                        "and month(InvoiceDate)=month(GETDATE()) and year(InvoiceDate)=year(GETDATE()) " +
                        "and WarehouseID=" + Utility.WarehouseID + " " +
                        "Union All " +
                        "Select ProductID, 0 as HOCurrentStock,0 as OutletCurrentStock,0 as MTDQty,SalesQty as YTDQty  " +
                        "From dwdb.dbo.t_SalesDataCustomerProduct where CompanyName='TEL' " +
                        "and year(InvoiceDate)=year(GETDATE()) " +
                        "and WarehouseID=" + Utility.WarehouseID + " " +
                        "Union All " +
                        "Select ProductID, 0 as HOCurrentStock,isnull((CurrentStock-isnull(TransitStock,0)),0) as OutletCurrentStock,0 as MTDQty,0 as YTDQty  " +
                        "From t_ProductStock where WarehouseID=" + Utility.WarehouseID + " " +
                        "Union All " +
                        "Select ProductID, isnull((CurrentStock-isnull(TransitStock,0)),0) as HOCurrentStock,0 as OutletCurrentStock,0 as MTDQty,0 as YTDQty  " +
                        "From t_ProductStock where WarehouseID=(Select MappedWarehouseID from t_Showroom where WarehouseID=" + Utility.WarehouseID + ") " +
                        ") Main where ProductID=" + nProductID + " group by ProductID";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nHOCurrentStock = int.Parse(reader["HOCurrentStock"].ToString());
                    _nOutletCurrentStock = int.Parse(reader["OutletCurrentStock"].ToString());
                    _nMTDSaleQty = int.Parse(reader["MTDQty"].ToString());
                    _nYTDSaleQty = int.Parse(reader["YTDQty"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProductStockWithMTD_YTDNew(int nWarehouseID, int nProductID, int nReqWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDB = "";

            if (Utility.CompanyInfo == "TEL")
            {
                sDB = "TELSYSDB";
            }
            else if (Utility.CompanyInfo == "TML")
            {
                sDB = "TMLSYSDB";
            }
            else
            {
                sDB = "BLLSYSDB";
            }

            int nCount = 0;
            string sSql = "Select * From " +
                        "( " +
                        "Select a.ProductID,isnull(MTDQty,0) MTDQty,isnull(YTDQty,0) YTDQty, " +
                        "isnull(CurrentStock,0) CurrentStock,isnull(BookingStock,0) BookingStock, " +
                        "isnull(OutletCurrentStock,0) OutletCurrentStock,isnull(OutletBookingStock,0) OutletBookingStock, " +
                        "isnull(ALLShowroomStock,0) ALLShowroomStock   " +
                        "From  " +
                        "( " +
                        "Select * From " + sDB + ".DBO.t_Product " +
                        ") a " +
                        "Left Outer Join  " +
                        "( " +
                        "Select ProductID,sum(SalesQty+FreeQty) as MTDQty  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct where CompanyName='" + Utility.CompanyInfo + "' " +
                        "and year(InvoiceDate)=year(getdate()) and month(InvoiceDate)=Month(getdate())  " +
                        "and WarehouseID=" + nReqWHID + " group by ProductID " +
                        ") b " +
                        "on a.ProductID=b.ProductID " +
                        "left Outer Join  " +
                        "( " +
                        "Select ProductID,sum(SalesQty+FreeQty) as YTDQty  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct where CompanyName='" + Utility.CompanyInfo + "' " +
                        "and year(InvoiceDate)=year(getdate()) " +
                        "and WarehouseID=" + nReqWHID + " group by ProductID " +
                        ") c " +
                        "on a.ProductID=c.ProductID " +
                        "left outer join  " +
                        "( " +
                        "Select ProductID,CurrentStock as OutletCurrentStock,BookingStock as OutletBookingStock  " +
                        "from " + sDB + ".dbo.t_ProductStock Where WarehouseID=" + nReqWHID + " and StockType=1 and CurrentStock>0 " +
                        ") d " +
                        "on a.ProductID=d.ProductID " +
                        "left Outer Join  " +
                        "( " +
                        "Select ProductID,CurrentStock,BookingStock  " +
                        "from " + sDB + ".dbo.t_ProductStock Where WarehouseID=" + nWarehouseID + " and StockType=1 and CurrentStock>0 " +
                        ") e " +
                        "on a.ProductID=e.ProductID " +
                        "left Outer Join " +
                        "( " +
                        "Select ProductID,sum(CurrentStock) ALLShowroomStock  " +
                        "from " + sDB + ".dbo.t_ProductStock a,  " +
                        "" + sDB + ".dbo.t_Warehouse b Where a.WarehouseID=b.WarehouseID  " +
                        "and WarehouseParentID=7 and a.StockType=1 and CurrentStock>0  group by ProductID " +
                        ") f " +
                        "on a.ProductID=f.ProductID " +
                        ") Main where ProductID=" + nProductID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
                    _nOutletCurrentStock = int.Parse(reader["OutletCurrentStock"].ToString());
                    _nOutletBookingStock = int.Parse(reader["OutletBookingStock"].ToString());
                    _nMTDSaleQty = int.Parse(reader["MTDQty"].ToString());
                    _nYTDSaleQty = int.Parse(reader["YTDQty"].ToString());
                    _nALLShowroomStock = int.Parse(reader["ALLShowroomStock"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckProductStockBy()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStock where WarehouseID = ? AND ProductID = ? AND ChannelID=?";
            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
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
        public bool CheckCACProductStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_CACProductStock where ProductID = ?";
            cmd.Parameters.AddWithValue("ProductID", _nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
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
        public void UpdateBookingStock(bool IsTrue, int nQty, int nWarehouseID, int nProductID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (IsTrue)
                sSql = "update t_ProductStock set BookingStock=BookingStock + ? where  WarehouseID = ? AND ProductID = ?";
            else sSql = "update t_ProductStock set BookingStock=BookingStock - ? where WarehouseID = ? AND ProductID = ?";

            try
            {

                cmd.CommandText = "SELECT BookingStock FROM t_ProductStock where WarehouseID = ? AND ProductID = ?";
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);

                object BookingStock = cmd.ExecuteScalar();

                int nBStock = 0;
                try
                {
                    nBStock = int.Parse(BookingStock.ToString());
                }
                catch
                {
                    nBStock = 0;
                }

                if (nBStock < nQty)
                {
                    _bFlag = false;
                }
                else
                {
                    _bFlag = true;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("BookingStock", nQty);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        /// <summary>
        /// Get Cassiopeia Stock
        /// </summary>
        /// <param name="IsTrue"></param>
        public int GetCassiopeisStock(int nShowroomID, int nProductID)
        {
            int nSoundStock = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();           
            try
            {
                cmd.CommandText = "SELECT * FROM Cassiopeia_HO.dbo.SRStock where ShowroomID=? and  ProductID =?";
                cmd.Parameters.AddWithValue("ShowroomID", nShowroomID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nSoundStock = (int)reader["SoundStock"];                 

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nSoundStock;
        }
        public int GetTDStock(int nProductID)
        {
            int nCurrentStock = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select Sum(CurrentStock)as CurrentStock " +
                                   " from (select CurrentStock from t_ProductStock a,  " +
                                   " t_Warehouse b Where a.WarehouseID=b.WarehouseID " +
                                   " and WarehouseParentID=7 and b.WarehouseID Not IN (119,81,79,118) " +
                                   " and a.StockType=1 and ProductID=? )a ";

                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["CurrentStock"] != DBNull.Value)
                    {
                        nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    }
                    else
                    {
                        nCurrentStock = 0;
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nCurrentStock;
        }
        public void Refresh(int nProductId, int nChannelId, int nWarehouseId)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_ProductStock where  ChannelID = ? AND WarehouseID = ? AND ProductID = ?";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ChannelID", nChannelId);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseId);
                cmd.Parameters.AddWithValue("ProductID", nProductId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                  

                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    _nCurrentStock = Convert.ToInt64(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());

                    nCount++;
                
                }

                reader.Close();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }

        public void RefreshDMSStock(int nDistributorID, int nProductId)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_DMSProductStock where DistributorID = ? AND ProductID = ?";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
                cmd.Parameters.AddWithValue("ProductID", nProductId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    _nCurrentStock = Convert.ToInt64(reader["CurrentStock"].ToString());
                    _nDistributorID = int.Parse(reader["DistributorID"].ToString());

                    nCount++;

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }

        //public void GetProductStockWithMTD_YTDNewDepot(int nWarehouseID, int nProductID, int nReqWHID)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sDB = "";

        //    if (Utility.CompanyInfo == "TEL")
        //    {
        //        sDB = "TELSYSDB";
        //    }
        //    else if (Utility.CompanyInfo == "TML")
        //    {
        //        sDB = "TMLSYSDB";
        //    }
        //    else
        //    {
        //        sDB = "BLLSYSDB";
        //    }

        //    int nCount = 0;
        //    string sSql = "Select * From " +
        //                "( " +
        //                "Select a.ProductID,isnull(MTDQty,0) MTDQty,isnull(YTDQty,0) YTDQty, " +
        //                "isnull(CurrentStock,0) CurrentStock,isnull(BookingStock,0) BookingStock, " +
        //                "isnull(OutletCurrentStock,0) OutletCurrentStock,isnull(OutletBookingStock,0) OutletBookingStock, " +
        //                "isnull(ALLShowroomStock,0) ALLShowroomStock, isnull(ALLDepotStock,0) ALLDepotStock   " +
        //                "From  " +
        //                "( " +
        //                "Select * From " + sDB + ".DBO.t_Product " +
        //                ") a " +
        //                "Left Outer Join  " +
        //                "( " +
        //                "Select ProductID,sum(SalesQty+FreeQty) as MTDQty  " +
        //                "From DWDB.DBO.t_SalesDataCustomerProduct where CompanyName='" + Utility.CompanyInfo + "' " +
        //                "and year(InvoiceDate)=year(getdate()) and month(InvoiceDate)=Month(getdate())  " +
        //                "and WarehouseID=" + nReqWHID + " group by ProductID " +
        //                ") b " +
        //                "on a.ProductID=b.ProductID " +
        //                "left Outer Join  " +
        //                "( " +
        //                "Select ProductID,sum(SalesQty+FreeQty) as YTDQty  " +
        //                "From DWDB.DBO.t_SalesDataCustomerProduct where CompanyName='" + Utility.CompanyInfo + "' " +
        //                "and year(InvoiceDate)=year(getdate()) " +
        //                "and WarehouseID=" + nReqWHID + " group by ProductID " +
        //                ") c " +
        //                "on a.ProductID=c.ProductID " +
        //                "left outer join  " +
        //                "( " +
        //                "Select ProductID,CurrentStock as OutletCurrentStock,BookingStock as OutletBookingStock  " +
        //                "from " + sDB + ".dbo.t_ProductStock Where WarehouseID=" + nReqWHID + " and StockType=1 and CurrentStock>0 " +
        //                ") d " +
        //                "on a.ProductID=d.ProductID " +
        //                "left Outer Join  " +
        //                "( " +
        //                "Select ProductID,CurrentStock,BookingStock  " +
        //                "from " + sDB + ".dbo.t_ProductStock Where WarehouseID=" + nWarehouseID + " and StockType=1 and CurrentStock>0 " +
        //                ") e " +
        //                "on a.ProductID=e.ProductID " +
        //                 "left Outer Join " +
        //                "( " +
        //                "Select ProductID,sum(CurrentStock) ALLShowroomStock  " +
        //                "from " + sDB + ".dbo.t_ProductStock a,  " +
        //                "" + sDB + ".dbo.t_Warehouse b Where a.WarehouseID=b.WarehouseID  " +
        //                "and WarehouseParentID=7 and a.StockType=1 and CurrentStock>0 and b.WarehouseID not in (select WarehouseID from t_Showroom where  isnull(IsDepot,0)=1) group by ProductID " +
        //                ") f " +
        //                "on a.ProductID=f.ProductID " +
        //                 "left Outer Join " +
        //                "( " +
        //                "Select ProductID,SUM(isnull(CurrentStock,0)) as ALLDepotStock From t_ProductStock a,t_Showroom b "+
        //                "where a.WarehouseID = b.WarehouseID and isnull(IsDepot,0)= 1  and IsActive=1  GROUP BY ProductID" +
        //                ") g " +
        //                "on a.ProductID=g.ProductID " +
        //                ") Main where ProductID=" + nProductID + "";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
        //            _nBookingStock = int.Parse(reader["BookingStock"].ToString());
        //            _nOutletCurrentStock = int.Parse(reader["OutletCurrentStock"].ToString());
        //            _nOutletBookingStock = int.Parse(reader["OutletBookingStock"].ToString());
        //            _nMTDSaleQty = int.Parse(reader["MTDQty"].ToString());
        //            _nYTDSaleQty = int.Parse(reader["YTDQty"].ToString());
        //            _nALLShowroomStock = int.Parse(reader["ALLShowroomStock"].ToString());
        //            _nAllDepotStock = int.Parse(reader["ALLDepotStock"].ToString());
        //            nCount++;
        //        }

        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void GetProductStockWithMTD_YTDNewDepot(int nWarehouseID, int nProductID, int nReqWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            
            int nCount = 0;
            string sSql = "Select * From " +
                        "( " +
                        "Select a.ProductID,isnull(MTDQty,0) MTDQty,isnull(YTDQty,0) YTDQty, " +
                        "isnull(CurrentStock,0) CurrentStock,isnull(BookingStock,0) BookingStock, " +
                        "isnull(OutletCurrentStock,0) OutletCurrentStock,isnull(OutletBookingStock,0) OutletBookingStock, " +
                        "isnull(ALLShowroomStock,0) ALLShowroomStock, isnull(ALLDepotStock,0) ALLDepotStock   " +
                        "From  " +
                        "( " +
                        "Select * From DBO.t_Product " +
                        ") a " +
                        "Left Outer Join  " +
                        "( " +
                        "Select ProductID,sum(SalesQty+FreeQty) as MTDQty  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct where CompanyName='" + Utility.CompanyInfo + "' " +
                        "and year(InvoiceDate)=year(getdate()) and month(InvoiceDate)=Month(getdate())  " +
                        "and WarehouseID=" + nReqWHID + " group by ProductID " +
                        ") b " +
                        "on a.ProductID=b.ProductID " +
                        "left Outer Join  " +
                        "( " +
                        "Select ProductID,sum(SalesQty+FreeQty) as YTDQty  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct where CompanyName='" + Utility.CompanyInfo + "' " +
                        "and year(InvoiceDate)=year(getdate()) " +
                        "and WarehouseID=" + nReqWHID + " group by ProductID " +
                        ") c " +
                        "on a.ProductID=c.ProductID " +
                        "left outer join  " +
                        "( " +
                        "Select ProductID,CurrentStock as OutletCurrentStock,BookingStock as OutletBookingStock  " +
                        "from dbo.t_ProductStock Where WarehouseID=" + nReqWHID + " and StockType=1 and CurrentStock>0 " +
                        ") d " +
                        "on a.ProductID=d.ProductID " +
                        "left Outer Join  " +
                        "( " +
                        "Select ProductID,CurrentStock,BookingStock  " +
                        "from dbo.t_ProductStock Where WarehouseID=" + nWarehouseID + " and StockType=1 and CurrentStock>0 " +
                        ") e " +
                        "on a.ProductID=e.ProductID " +
                         "left Outer Join " +
                        "( " +
                        "Select ProductID,sum(CurrentStock) ALLShowroomStock  " +
                        "from dbo.t_ProductStock a,  " +
                        "dbo.t_Warehouse b Where a.WarehouseID=b.WarehouseID  " +
                        "and WarehouseParentID=7 and a.StockType=1 and CurrentStock>0 and b.WarehouseID not in (select WarehouseID from t_Showroom where  isnull(IsDepot,0)=1) group by ProductID " +
                        ") f " +
                        "on a.ProductID=f.ProductID " +
                         "left Outer Join " +
                        "( " +
                        "Select ProductID,SUM(isnull(CurrentStock,0)) as ALLDepotStock From t_ProductStock a,t_Showroom b " +
                        "where a.WarehouseID = b.WarehouseID and isnull(IsDepot,0)= 1  and IsActive=1  GROUP BY ProductID" +
                        ") g " +
                        "on a.ProductID=g.ProductID " +
                        ") Main where ProductID=" + nProductID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    _nBookingStock = int.Parse(reader["BookingStock"].ToString());
                    _nOutletCurrentStock = int.Parse(reader["OutletCurrentStock"].ToString());
                    _nOutletBookingStock = int.Parse(reader["OutletBookingStock"].ToString());
                    _nMTDSaleQty = int.Parse(reader["MTDQty"].ToString());
                    _nYTDSaleQty = int.Parse(reader["YTDQty"].ToString());
                    _nALLShowroomStock = int.Parse(reader["ALLShowroomStock"].ToString());
                    _nAllDepotStock = int.Parse(reader["ALLDepotStock"].ToString());
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

    public class ProductStocks : CollectionBase
    {
        public void Add(ProductStock oProductStock)
        {
            InnerList.Add(oProductStock);
        }
        public ProductStock this[int i]
        {
            get { return (ProductStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetDepotWiseStock(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            int nCount = 0;
            string sSql = "Select ShowroomCode,ShowroomName,a.WarehouseID,ProductID,SUM(isnull(CurrentStock,0)) as DepotStock From t_ProductStock a,t_Showroom b " +
                        "where a.WarehouseID=b.WarehouseID and isnull(IsDepot,0)=1 and IsActive=1 and ProductID=" + nProductID + "" +
                        " GROUP BY ShowroomCode,ShowroomName,a.WarehouseID,ProductID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.ShortCode = reader["ShowroomCode"].ToString();
                    oProductStock.BrandDesc = reader["ShowroomName"].ToString();
                    oProductStock.OutletCurrentStock = int.Parse(reader["DepotStock"].ToString());
                    nCount++;
                    InnerList.Add(oProductStock);
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
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                sSql = " select * from t_ProductStock ";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.ProductID = (int)reader["ProductID"];
                    oProductStock.CurrentStock = Convert.ToInt64(reader["CurrentStock"].ToString());
                    InnerList.Add(oProductStock);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetCurrentStock(int nQty, bool IsProdWise, int nWarehouseId, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductName)
        {
            InnerList.Clear();
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (IsProdWise)
                {
                    sSql = " select ProductCode,ProductName,AGID,AGName,ASGID,ASGName,MAGID,MAGName,BrandID, " +
                           "BrandDesc,(Currentstock - BookingStock) as SelableStock from t_productstock a " +
                           "inner join  v_productdetails b on a.productid=b.productid where a.Warehouseid=? ";
                }
                else
                {
                    sSql = " select ASGID,ASGName,MAGID,MAGName,BrandID, " +
                            "BrandDesc,SUM(Currentstock - BookingStock) as SelableStock from t_productstock a  " +
                            "inner join  v_productdetails b on a.productid=b.productid where a.Warehouseid=? ";
                           
                }
                cmd.Parameters.AddWithValue("WarehouseId", nWarehouseId);

                if (nMAGID != 0)
                {
                    sSql = sSql + " and MAGID=" + nMAGID + "";
                }
                if (nASGID != 0)
                {
                    sSql = sSql + " and ASGID=" + nASGID + "";
                }
                if (nBrandID != 0)
                {
                    sSql = sSql + " and BrandID=" + nBrandID + "";
                }
                if (IsProdWise)
                {
                    if (nAGID != 0)
                    {
                        sSql = sSql + " and AGID=" + nAGID + "";
                    }
                    if (sProductCode != "")
                    {
                        sSql = sSql + " and ProductCode='" + sProductCode + "'";
                    }
                    if (sProductName != "")
                    {
                        sSql = sSql + " and ProductName like '%" + sProductName + "%'";
                    }
                    if (nQty != 0)
                    {
                        if (nQty == 1)
                        {
                            sSql = sSql + " and (Currentstock - BookingStock) = 0";
                        }
                        else
                        {
                            sSql = sSql + " and (Currentstock - BookingStock) > 0";
                        }
                    }
                }
                else
                {
                    if (nQty != 0)
                    {
                        if (nQty == 1)
                        {
                            sSql = sSql + " and (Currentstock - BookingStock) = 0";
                        }
                        else
                        {
                            sSql = sSql + " and (Currentstock - BookingStock) > 0";
                        }
                    }
                    sSql = sSql + " group by ASGID,ASGName,MAGID,MAGName,BrandID, BrandDesc";

                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStock oProductStock = new ProductStock();

                    if (IsProdWise)
                    {
                        oProductStock.AGID = (int)reader["AGID"];
                        oProductStock.AGName = (string)reader["AGName"];
                        oProductStock.ProductCode = (string)reader["productcode"];
                        oProductStock.ProductName = (string)reader["productname"];
                    } 
                    oProductStock.ASGID = (int)reader["ASGID"];
                    oProductStock.ASGName = (string)reader["ASGName"];
                    oProductStock.MAGID = (int)reader["MAGID"];
                    oProductStock.MAGName = (string)reader["MAGName"];
                    oProductStock.BrandID = (int)reader["BrandID"];
                    oProductStock.BrandDesc = (string)reader["BrandDesc"];

                    oProductStock.CurrentStock = Convert.ToInt64(reader["SelableStock"].ToString());

                    InnerList.Add(oProductStock);
                 
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCurrentStockNew(int nQty, bool IsProdWise, int nWarehouseId, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductName)
        {
            InnerList.Clear();
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (IsProdWise)
                {
                    sSql = "Select * From  " +
                        "(  " +
                        "Select ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc, sum(SelableStock) SelableStock, sum(DefectiveStk) DefectiveStk,sum(SelableStock)-sum(DefectiveStk) as StockQty From  " +
                        "(  " +
                        "Select ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc, 0 as SelableStock, count(BarcodeSL) as DefectiveStk  " +
                        "From t_UnsoldDefectiveProduct a, t_ProductStockSerial b, v_ProductDetails c  " +
                        "where a.ProductID = b.ProductID and a.BarcodeSL = b.ProductSerialNo  " +
                        "and a.ProductID = c.ProductID and b.Status = 1  " +
                        "group by a.ProductID, ProductCode, ProductName, AGID, AGName,  " +
                        "ASGID, ASGName, MAGID, MAGName, BrandID, BrandDesc  " +
                        "Union All  " +
                        "Select ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc, Currentstock as SelableStock, 0 as DefectiveStk  " +
                        "from t_ProductStock a, v_productdetails b where a.productid = b.productid and a.Warehouseid = " + nWarehouseId + "  " +
                        ") Main group by ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc  " +
                        ") x where DefectiveStk + SelableStock > 0";
                }
                else
                {
                    sSql = " select ASGID,ASGName,MAGID,MAGName,BrandID, " +
                            "BrandDesc,SUM(Currentstock - BookingStock) as SelableStock,0 DefectiveStk,SUM(Currentstock - BookingStock) as StockQty from t_productstock a  " +
                            "inner join  v_productdetails b on a.productid=b.productid where a.Warehouseid=" + nWarehouseId + " ";

                }

                if (nMAGID != 0)
                {
                    sSql = sSql + " and MAGID=" + nMAGID + "";
                }
                if (nASGID != 0)
                {
                    sSql = sSql + " and ASGID=" + nASGID + "";
                }
                if (nBrandID != 0)
                {
                    sSql = sSql + " and BrandID=" + nBrandID + "";
                }
                if (IsProdWise)
                {
                    if (nAGID != 0)
                    {
                        sSql = sSql + " and AGID=" + nAGID + "";
                    }
                    if (sProductCode != "")
                    {
                        sSql = sSql + " and ProductCode='" + sProductCode + "'";
                    }
                    if (sProductName != "")
                    {
                        sSql = sSql + " and ProductName like '%" + sProductName + "%'";
                    }
                    if (nQty != 0)
                    {
                        if (nQty == 1)
                        {
                            sSql = sSql + " and StockQty = 0";
                        }
                        else
                        {
                            sSql = sSql + " and StockQty > 0";
                        }
                    }
                }
                else
                {
                    if (nQty != 0)
                    {
                        if (nQty == 1)
                        {
                            sSql = sSql + " and StockQty = 0";
                        }
                        else
                        {
                            sSql = sSql + " and StockQty > 0";
                        }
                    }
                    sSql = sSql + " group by ASGID,ASGName,MAGID,MAGName,BrandID, BrandDesc";

                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStock oProductStock = new ProductStock();

                    if (IsProdWise)
                    {
                        oProductStock.AGID = (int)reader["AGID"];
                        oProductStock.AGName = (string)reader["AGName"];
                        oProductStock.ProductCode = (string)reader["productcode"];
                        oProductStock.ProductName = (string)reader["productname"];
                    }
                    oProductStock.ASGID = (int)reader["ASGID"];
                    oProductStock.ASGName = (string)reader["ASGName"];
                    oProductStock.MAGID = (int)reader["MAGID"];
                    oProductStock.MAGName = (string)reader["MAGName"];
                    oProductStock.BrandID = (int)reader["BrandID"];
                    oProductStock.BrandDesc = (string)reader["BrandDesc"];

                    oProductStock.CurrentStock = Convert.ToInt64(reader["SelableStock"].ToString());
                    oProductStock.DefectiveStk = Convert.ToInt64(reader["DefectiveStk"].ToString());
                    oProductStock.StockQty = Convert.ToInt64(reader["StockQty"].ToString());

                    InnerList.Add(oProductStock);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCurrentStockNewRT(int nQty, bool IsProdWise, int nWarehouseId, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductName)
        {
            InnerList.Clear();
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (IsProdWise)
                {
                    sSql = "Select * From  " +
                        "(  " +
                        "Select ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc, sum(SelableStock) SelableStock,sum(TransitStock) TransitStock, sum(DefectiveStk) DefectiveStk,sum(SelableStock)-sum(TransitStock) as StockQty From  " +
                        "(  " +
                        "Select ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc, 0 as SelableStock,0 as TransitStock, count(BarcodeSL) as DefectiveStk  " +
                        "From t_UnsoldDefectiveProduct a, t_ProductStockSerialRT b, v_ProductDetails c  " +
                        "where a.ProductID = b.ProductID and a.BarcodeSL = b.ProductSerialNo  " +
                        "and a.ProductID = c.ProductID and b.Status = 1   and a.Warehouseid = " + nWarehouseId + "  " +
                        "group by a.ProductID, ProductCode, ProductName, AGID, AGName,  " +
                        "ASGID, ASGName, MAGID, MAGName, BrandID, BrandDesc  " +
                        "Union All  " +
                        "Select ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc, Currentstock as SelableStock,TransitStock, 0 as DefectiveStk  " +
                        "from t_ProductStock a, v_productdetails b where a.productid = b.productid and a.Warehouseid = " + nWarehouseId + "  " +
                        ") Main group by ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID,  " +
                        "BrandDesc  " +
                        ") x where SelableStock > 0";
                }
                else
                {
                    sSql = " select ASGID,ASGName,MAGID,MAGName,BrandID, " +
                            "BrandDesc,isnull((CurrentStock-isnull(TransitStock,0)),0) as SelableStock,0 DefectiveStk,isnull((CurrentStock-isnull(TransitStock,0)),0) as StockQty from t_productstock a  " +
                            "inner join  v_productdetails b on a.productid=b.productid where a.Warehouseid=" + nWarehouseId + " ";

                }

                if (nMAGID != 0)
                {
                    sSql = sSql + " and MAGID=" + nMAGID + "";
                }
                if (nASGID != 0)
                {
                    sSql = sSql + " and ASGID=" + nASGID + "";
                }
                if (nBrandID != 0)
                {
                    sSql = sSql + " and BrandID=" + nBrandID + "";
                }
                if (IsProdWise)
                {
                    if (nAGID != 0)
                    {
                        sSql = sSql + " and AGID=" + nAGID + "";
                    }
                    if (sProductCode != "")
                    {
                        sSql = sSql + " and ProductCode='" + sProductCode + "'";
                    }
                    if (sProductName != "")
                    {
                        sSql = sSql + " and ProductName like '%" + sProductName + "%'";
                    }
                    if (nQty != 0)
                    {
                        if (nQty == 1)
                        {
                            sSql = sSql + " and StockQty = 0";
                        }
                        else
                        {
                            sSql = sSql + " and StockQty > 0";
                        }
                    }
                }
                else
                {
                    if (nQty != 0)
                    {
                        if (nQty == 1)
                        {
                            sSql = sSql + " and StockQty = 0";
                        }
                        else
                        {
                            sSql = sSql + " and StockQty > 0";
                        }
                    }
                    sSql = sSql + " group by ASGID,ASGName,MAGID,MAGName,BrandID, BrandDesc";

                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStock oProductStock = new ProductStock();

                    if (IsProdWise)
                    {
                        oProductStock.AGID = (int)reader["AGID"];
                        oProductStock.AGName = (string)reader["AGName"];
                        oProductStock.ProductCode = (string)reader["productcode"];
                        oProductStock.ProductName = (string)reader["productname"];
                    }
                    oProductStock.ASGID = (int)reader["ASGID"];
                    oProductStock.ASGName = (string)reader["ASGName"];
                    oProductStock.MAGID = (int)reader["MAGID"];
                    oProductStock.MAGName = (string)reader["MAGName"];
                    oProductStock.BrandID = (int)reader["BrandID"];
                    oProductStock.BrandDesc = (string)reader["BrandDesc"];

                    oProductStock.CurrentStock = Convert.ToInt64(reader["SelableStock"].ToString());
                    oProductStock.TransitStock = Convert.ToInt32(reader["TransitStock"].ToString());
                    oProductStock.DefectiveStk = Convert.ToInt64(reader["DefectiveStk"].ToString());
                    oProductStock.StockQty = Convert.ToInt64(reader["StockQty"].ToString());

                    InnerList.Add(oProductStock);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWSStock(DSStock oDSStock)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                foreach (DSStock.ProdStockRow oProdStockRow in oDSStock.ProdStock)
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.AGID = oProdStockRow.AGID;
                    oProductStock.AGName = oProdStockRow.AGName;
                    oProductStock.ASGID = oProdStockRow.ASGID;
                    oProductStock.ASGName = oProdStockRow.ASGName;
                    oProductStock.MAGID = oProdStockRow.MAGID;
                    oProductStock.MAGName = oProdStockRow.MAGName;
                    oProductStock.BrandID = oProdStockRow.BrandID;
                    oProductStock.BrandDesc = oProdStockRow.BrandDesc;
                    oProductStock.ProductCode = oProdStockRow.ProductCode;
                    oProductStock.ProductName = oProdStockRow.ProductName;
                    oProductStock.CurrentStock = Convert.ToInt64(oProdStockRow.SelableStock);
                    oProductStock.WarehouseID = oProdStockRow.WarehouseID;
                    oProductStock.ShortCode = oProdStockRow.ShortCode;

                    InnerList.Add(oProductStock);

                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetWSStockRT(int nWHID, int nCentralWHID, int nAGID, int nASGID, int nMAGID, int nBrandID, string sProductCode, string sProductName)
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            string sSql = "";
            try
            {
                if (Utility.CentralRetailWarehouse == nCentralWHID)
                {

                    //sSql = " select ProductCode,ProductName,AGID,AGName,ASGID,ASGName,MAGID,MAGName,BrandID, " +
                    //       "BrandDesc,(Currentstock - BookingStock) as SelableStock, a.WarehouseID,IsNull(ShortCode,'') as ShortCode from t_productstock a " +
                    //       "inner join  v_productdetails b on a.productid=b.productid INNER JOIN t_Warehouse c on a.WarehouseID=c.WarehouseID where StockVisibleFromOutlet=1 ";//a.Warehouseid=" + nCentralWHID + " 


                    sSql = "Select * From (select ProductCode,ProductName,AGID,AGName,ASGID,ASGName,MAGID,MAGName,BrandID,  " +
                            "BrandDesc,sum((Currentstock - BookingStock)) as SelableStock,-1 as WarehouseID,'HO' as ShortCode   " +
                            "from t_productstock a   " +
                            "inner join  v_productdetails b on a.productid=b.productid   " +
                            "INNER JOIN t_Warehouse c on a.WarehouseID=c.WarehouseID   " +
                            "where StockVisibleFromOutlet=1   " +
                            "group by ProductCode,ProductName,AGID,AGName,ASGID,ASGName,MAGID,MAGName,BrandID,   " +
                            "BrandDesc ) Main where 1=1";
                }
                else
                {
                    sSql = " select ProductCode,ProductName,AGID,AGName,ASGID,ASGName,MAGID,MAGName,BrandID, " +
                           "BrandDesc,(Currentstock - BookingStock) as SelableStock, a.WarehouseID, IsNull(ShortCode,'') as ShortCode from t_productstock a " +
                           "inner join  v_productdetails b on a.productid=b.productid INNER JOIN t_Warehouse c on a.WarehouseID=c.WarehouseID where a.Warehouseid IN (select WarehouseID from t_Showroom Where WarehouseID <> " + nWHID + ") ";

                }

                if (nMAGID != 0)
                {
                    sSql = sSql + " and MAGID=" + nMAGID + "";
                }
                if (nASGID != 0)
                {
                    sSql = sSql + " and ASGID=" + nASGID + "";
                }
                if (nAGID != 0)
                {
                    sSql = sSql + " and AGID=" + nAGID + "";
                }
                if (nBrandID != 0)
                {
                    sSql = sSql + " and BrandID=" + nBrandID + "";
                }
                if (sProductCode != "")
                {
                    sSql = sSql + " and ProductCode='" + sProductCode + "'";
                }
                if (sProductName != "")
                {
                    sSql = sSql + " and ProductName like '%" + sProductName + "%'";
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["SelableStock"]) > 0)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.AGID = (int)reader["AGID"];
                        oProductStock.AGName = (string)reader["AGName"];
                        oProductStock.ASGID = (int)reader["ASGID"];
                        oProductStock.ASGName = (string)reader["ASGName"];
                        oProductStock.MAGID = (int)reader["MAGID"];
                        oProductStock.MAGName = (string)reader["MAGName"];
                        oProductStock.BrandID = (int)reader["BrandID"];
                        oProductStock.BrandDesc = (string)reader["BrandDesc"];
                        oProductStock.ProductCode = (string)reader["productcode"];
                        oProductStock.ProductName = (string)reader["productname"];
                        oProductStock.CurrentStock = Convert.ToInt32(reader["SelableStock"].ToString());
                        oProductStock.WarehouseID = (int)reader["WarehouseID"];
                        oProductStock.ShortCode = (string)reader["ShortCode"];

                        InnerList.Add(oProductStock);
                    }
                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get Product Stock");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Product Stock/" + ex.Message);
                throw (ex);
            }

        }

        public void RefreshForCurrentStock(string sProductID, string nWarehouseID, bool bIsHO)
        {
            InnerList.Clear();
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                sSql = " select * from t_ProductStock A, v_ProductDetails B, t_Warehouse C where A.ProductID=B.ProductID and A.WarehouseID=C.WarehouseID and CurrentStock > 0 ";

                if(sProductID !="")
                {
                    sSql=sSql+" and A.ProductID in ("+ sProductID + ")";
                }
                
                sSql = sSql + " and A.WarehouseID in (" + nWarehouseID + ")";
                
                //else if(bIsHO==true)
                //{
                //    sSql = sSql + " and A.WarehouseID in (Select string_AGG( WarehouseID,',') From v_WarehouseDetails where WarehouseGroupName='Saleable' and WarehouseParentID=6)";
                //}
                //else
                //{
                //    sSql = sSql + " and A.WarehouseID in (select string_AGG( WarehouseID,',') from t_Showroom Where IsActive=1 and IsPOSActive=1)";
                //}


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.ProductCode = reader["ProductCode"].ToString();
                    oProductStock.ProductName = reader["ProductName"].ToString();
                    oProductStock.CurrentStock = Convert.ToInt64(reader["CurrentStock"].ToString());
                    oProductStock.WarehouseID = (int)reader["WarehouseID"];
                    oProductStock.ShortCode = reader["ShortCode"].ToString();
                    InnerList.Add(oProductStock);

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

