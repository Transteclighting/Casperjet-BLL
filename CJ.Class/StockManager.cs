// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 28, 2011
// Time :  12:00 PM
// Description: Class for Stock.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;


namespace CJ.Class
{
    /// <summary>
    /// Shahanoor 
    /// </summary>
    public class ProductStockTranItem
    {
        protected int _nTranID;
        protected string _sProductCode;
        protected long _nQty;
        protected int _nSRID;
        protected int _nProductID;
        protected int _nStatus;
        protected double _nStockPrice;
        private string _sProductName;
        public ProductStockTranItem()
        {
            _nTranID = 0;
            _sProductCode = string.Empty;
            _nQty = 0;
            _nSRID = 0;
        }
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        public int SRID
        {
            get { return _nSRID; }
            set { _nSRID = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private int _nIsBarcodeItem;
        public int IsBarcodeItem
        {
            get { return _nIsBarcodeItem; }
            set { _nIsBarcodeItem = value; }
        }
        public long Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public double StockPrice
        {
            get { return _nStockPrice; }
            set { _nStockPrice = value; }
        }


    }
    public class ProductStockTranItems : CollectionBase
    {
        public void Add(ProductStockTranItem oTranItem)
        {
            InnerList.Add(oTranItem);
        }
        public ProductStockTranItem this[int i]
        {
            get { return (ProductStockTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndex(int nTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranID == nTranID)
                {
                    return i;
                }
            }
            return -1;
        }


        public void GetMGTItem(string nTranNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select IsBarcodeItem,a.ProductID,ProductCode,ProductName,LoanQty-isnull(ReturnQty,0) as ReturnableQty From  " +
                                "(  " +
                                "Select a.TranID,TranNo,ProductID,FromWHID,ToWHID,sum(Qty) LoanQty   " +
                                "From t_ProductStockTran a,t_ProductStockTranItem b   " +
                                "where a.TranID=b.TranID group by a.TranID,TranNo,ProductID,FromWHID,ToWHID  " +
                                ") A  " +
                                "Left Outer join   " +
                                "(  " +
                                "Select b.RefTranID,ProductID,sum(Qty) ReturnQty   " +
                                "From t_ProductStockTran a,t_ProductStockTranItem b   " +
                                "where a.TranID=b.TranID group by b.RefTranID,ProductID  " +
                                ") B on a.TranID=b.RefTranID and a.ProductID=b.ProductID  " +
                                "inner Join   " +
                                "(  " +
                                "Select * From t_Product   " +
                                ") C on a.ProductID=c.ProductID  " +
                                "where LoanQty-isnull(ReturnQty,0)>0 and TranNo='"+ nTranNo + "'";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductStockTranItem oItem = new ProductStockTranItem();
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.Qty = int.Parse(reader["ReturnableQty"].ToString());
                    oItem.IsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());


                    InnerList.Add(oItem);
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
 
    public class StockTranItem
    {
        private int _nTranID;
        private int _nProductID;
        private long _Qty;
        private double _StockPrice;
        private int _nStatus;
        private int _nRefTranID;
        private double _LCProductQty;
        private double _LCShortQty;
        private double _LCDamagedQty;
        private double _LCMinorDefectiveQty;
        private string _sLCRemarks;
        private double _CostPrice;
        private double _SalesPrice;
        private string _sCACProductCode;
        private string _sCACProductName;
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        public double SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }

        private DateTime _dtDeliveryDate;
        public DateTime DeliveryDate
        {
            get { return _dtDeliveryDate; }
            set { _dtDeliveryDate = value; }
        }

        private Product _oProduct;

        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                    _oProduct.ProductID = _nProductID;
                }
                return _oProduct;
            }
        }
        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
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
        /// Get set property for Qty
        /// </summary>
        public long Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        private int _nIsFreeProduct;

        public int IsFreeProduct
        {
            get { return _nIsFreeProduct; }
            set { _nIsFreeProduct = value; }
        }
        /// <summary>
        /// Get set property for StockPrice
        /// </summary>
        public double StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for RefTranID
        /// </summary>
        public int RefTranID
        {
            get { return _nRefTranID; }
            set { _nRefTranID = value; }
        }

        /// <summary>
        /// Get set property for LCProductQty
        /// </summary>
        public double LCProductQty
        {
            get { return _LCProductQty; }
            set { _LCProductQty = value; }
        }

        /// <summary>
        /// Get set property for LCShortQty
        /// </summary>
        public double LCShortQty
        {
            get { return _LCShortQty; }
            set { _LCShortQty = value; }
        }

        /// <summary>
        /// Get set property for LCDamagedQty
        /// </summary>
        public double LCDamagedQty
        {
            get { return _LCDamagedQty; }
            set { _LCDamagedQty = value; }
        }

        /// <summary>
        /// Get set property for LCMinorDefectiveQty
        /// </summary>
        public double LCMinorDefectiveQty
        {
            get { return _LCMinorDefectiveQty; }
            set { _LCMinorDefectiveQty = value; }
        }

        /// <summary>
        /// Get set property for LCRemarks
        /// </summary>
        public string LCRemarks
        {
            get { return _sLCRemarks; }
            set { _sLCRemarks = value.Trim(); }
        }
        public string CACProductCode
        {
            get { return _sCACProductCode; }
            set { _sCACProductCode = value.Trim(); }
        }
        public string CACProductName
        {
            get { return _sCACProductName; }
            set { _sCACProductName = value.Trim(); }
        }

        public void Insert(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ProductStockTranItem (TranID,ProductID,Qty,StockPrice,Status,RefTranID,LCProductQty,LCShortQty,LCDamagedQty,LCMinorDefectiveQty,LCRemarks) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.TransactionItemType.ADD);
                cmd.Parameters.AddWithValue("RefTranID", null);
                cmd.Parameters.AddWithValue("LCProductQty", null);
                cmd.Parameters.AddWithValue("LCShortQty", null);
                cmd.Parameters.AddWithValue("LCDamagedQty", null);
                cmd.Parameters.AddWithValue("LCMinorDefectiveQty", null);
                cmd.Parameters.AddWithValue("LCRemarks", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertCAC(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_CACProductStockTranItem (TranID, ProductID, Qty, StockPrice, Remarks) VALUES (?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Remarks", _sLCRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertCACChallan(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_CACProductStockTranItem (TranID, ProductID, Qty, StockPrice, Remarks, DeliveryDate) VALUES (?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Remarks", _sLCRemarks);
                cmd.Parameters.AddWithValue("DeliveryDate", _dtDeliveryDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

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
        
        public void InsertTranItemForDMS(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSProductStockTranItem (TranID, ProductID, Qty, CostPrice, SalesPrice) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("SalesPrice", _SalesPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Delete(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ProductStockTranItem Where TranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public int IsFreeProductExist()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int IsFreeCount = 0;
            try
            {
                cmd.CommandText = "Select Count(ProductID) IsFreeCount From t_ProductStockTranItem where TranID=? and ProductID=?";

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFreeCount = Convert.ToInt32(reader["IsFreeCount"]);
                    return IsFreeCount;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return IsFreeCount;
        }
        public void UpdateIsFreeQty(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ProductStockTranItem SET Qty = Qty + ? WHERE TranID = " + nTranID + " and ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class StockTran : CollectionBase
    {
        private int _nTranID;
        private int _nLastUpdateUserID;
        private object _CreateDate;
        private object _LastUpdateDate;
        private int _nPOID;
        private string _sTranNo;
        private object _TranDate;
        private object _DeliveryDate;
        private object _nTranTypeID;
        private int _nFromWHID;
        private int _nToWHID;
        private int _nToChannelID;
        private int _nFromChannelID;
        private int _nUserID;
        private int _nStatus;
        private int _nProductID;
        private string _sCACProductCode;
        private string _sCACProductName;
        private string _sCACProductModel;
        private string _sCustomeraddress;
        private string _sCACCustomerName;
        private string _sRemarks;
        private int _nUploadStatus;
        private object _UploadDate;
        private object _DownloadDate;
        private int _nRowStatus;
        private int _nTerminal;
        private string _sLCNo;
        private object _LCDate;
        private string _sLCInvoiceNo;
        private object _LCInvoiceDate;
        private int _nTranside;
        private int _nFromCustomerID;
        private int _nToCustomerID;
        private int _nCustomerID;
        private int _nCACQty;
        private int _nOpeningStock;
        private int _nGRDQty;
        private int _nIssueQty;
        private int _nClosingStock;
        private int _nBalance;
        private double _nInvoiceAmount;
        private double _nDiscountAmount;




        public double InvoiceAmount
        {
            get { return _nInvoiceAmount; }
            set { _nInvoiceAmount = value; }
        }
        public double DiscountAmount
        {
            get { return _nDiscountAmount; }
            set { _nDiscountAmount = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        private string _sContactPerson;
        public string ContactPerson
        {
            get { return _sContactPerson; }
            set { _sContactPerson = value.Trim(); }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int Balance
        {
            get { return _nBalance; }
            set { _nBalance = value; }
        }
        public string Customeraddress
        {
            get { return _sCustomeraddress; }
            set { _sCustomeraddress = value.Trim(); }
        }
        public string CACCustomerName
        {
            get { return _sCACCustomerName; }
            set { _sCACCustomerName = value.Trim(); }
        }
        private string _sDeliveryAddress;
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }
        private string _sContactNo;
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }
        public int CACQty
        {
            get { return _nCACQty; }
            set { _nCACQty = value; }
        }
        public int OpeningStock
        {
            get { return _nOpeningStock; }
            set { _nOpeningStock = value; }
        }
        public int GRDQty
        {
            get { return _nGRDQty; }
            set { _nGRDQty = value; }
        }
        public int IssueQty
        {
            get { return _nIssueQty; }
            set { _nIssueQty = value; }
        }
        public int ClosingStock
        {
            get { return _nClosingStock; }
            set { _nClosingStock = value; }
        }
        private string _sRefNo;
        public string RefNo
        {
            get { return _sRefNo; }
            set { _sRefNo = value.Trim(); }
        }
        //private string _sLcNo;
        //public string LcNo
        //{
        //    get { return _sLcNo; }
        //    set { _sLcNo = value.Trim(); }
        //}

        public int Transide
        {
            get { return _nTranside; }
            set { _nTranside = value; }
        }

        public int FromCustomerID
        {
            get { return _nFromCustomerID; }
            set { _nFromCustomerID = value; }
        }

        public int ToCustomerID
        {
            get { return _nToCustomerID; }
            set { _nToCustomerID = value; }
        }
        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        /// <summary>
        /// Get set property for LastUpdateUserID
        /// </summary>
        public int LastUpdateUserID
        {
            get { return _nLastUpdateUserID; }
            set { _nLastUpdateUserID = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public object CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public object DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        /// <summary>
        /// Get set property for LastUpdateDate
        /// </summary>
        public object LastUpdateDate
        {
            get { return _LastUpdateDate; }
            set { _LastUpdateDate = value; }
        }

        /// <summary>
        /// Get set property for POID
        /// </summary>
        public int POID
        {
            get { return _nPOID; }
            set { _nPOID = value; }
        }

        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }

        public string CACProductCode
        {
            get { return _sCACProductCode; }
            set { _sCACProductCode = value.Trim(); }
        }
        public string CACProductName
        {
            get { return _sCACProductName; }
            set { _sCACProductName = value.Trim(); }
        }

        public string CACProductModel
        {
            get { return _sCACProductModel; }
            set { _sCACProductModel = value.Trim(); }
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
        public object TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }

        /// <summary>
        /// Get set property for FromWHID
        /// </summary>
        public int FromWHID
        {
            get { return _nFromWHID; }
            set { _nFromWHID = value; }
        }

        /// <summary>
        /// Get set property for ToWHID
        /// </summary>
        public int ToWHID
        {
            get { return _nToWHID; }
            set { _nToWHID = value; }
        }

        /// <summary>
        /// Get set property for ToChannelID
        /// </summary>
        public int ToChannelID
        {
            get { return _nToChannelID; }
            set { _nToChannelID = value; }
        }

        /// <summary>
        /// Get set property for FromChannelID
        /// </summary>
        public int FromChannelID
        {
            get { return _nFromChannelID; }
            set { _nFromChannelID = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        /// Get set property for UploadDate
        /// </summary>
        public object UploadDate
        {
            get { return _UploadDate; }
            set { _UploadDate = value; }
        }

        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public object DownloadDate
        {
            get { return _DownloadDate; }
            set { _DownloadDate = value; }
        }

        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }
        }

        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }

        /// <summary>
        /// Get set property for LCNo
        /// </summary>
        public string LCNo
        {
            get { return _sLCNo; }
            set { _sLCNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LCDate
        /// </summary>
        public object LCDate
        {
            get { return _LCDate; }
            set { _LCDate = value; }
        }

        /// <summary>
        /// Get set property for LCInvoiceNo
        /// </summary>
        public string LCInvoiceNo
        {
            get { return _sLCInvoiceNo; }
            set { _sLCInvoiceNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LCInvoiceDate
        /// </summary>
        public object LCInvoiceDate
        {
            get { return _LCInvoiceDate; }
            set { _LCInvoiceDate = value; }
        }


        int nProductID = 0;

        private int _nBranchDataID;
        public int BranchDataID
        {
            get { return _nBranchDataID; }
            set { _nBranchDataID = value; }
        }

        private StockTranItem oStockTranItem;
        public StockTranItem StockTranItem
        {
            get
            {
                if (oStockTranItem == null)
                {
                    oStockTranItem = new StockTranItem();
                }
                return oStockTranItem;
            }
        }

        public StockTranItem this[int i]
        {
            get { return (StockTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(StockTranItem oStockTranItem)
        {
            InnerList.Add(oStockTranItem);
        }

        public void Insert()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", Convert.ToInt16(Dictionary.ProductStockTranType.INVOICE));
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                //if (_nToWHID != 0)
                //    cmd.Parameters.AddWithValue("ToWHID", (long)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                //else cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                //if (_nToChannelID != 0)
                //    cmd.Parameters.AddWithValue("ToChannelID", (long)Dictionary.SystemChannel.SYS_CHANNEL);
                //else cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    StockTranItem oChkFreeProduct = new StockTranItem();
                    oChkFreeProduct.ProductID = oItem.ProductID;
                    oChkFreeProduct.TranID = _nTranID;
                    int nFreeItemCount = oChkFreeProduct.IsFreeProductExist();
                    if (nFreeItemCount == 0)
                    {
                        oItem.Insert(_nTranID);
                    }
                    else
                    {
                        oItem.UpdateIsFreeQty(_nTranID);
                    }


                    //oItem.Insert(_nTranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForInvoiceWeb()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", Convert.ToInt16(Dictionary.ProductStockTranType.INVOICE));
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertStockTranNew()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", Convert.ToInt16(Dictionary.ProductStockTranType.INVOICE));
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                if (_nToWHID != 0)
                    cmd.Parameters.AddWithValue("ToWHID", (long)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                else cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                if (_nToChannelID != 0)
                    cmd.Parameters.AddWithValue("ToChannelID", (long)Dictionary.SystemChannel.SYS_CHANNEL);
                else cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();



                foreach (StockTranItem oItem in this)
                {
                    //oItem.Insert(_nTranID);

                    StockTranItem oChkFreeProduct = new StockTranItem();
                    oChkFreeProduct.ProductID = oItem.ProductID;
                    oChkFreeProduct.TranID = _nTranID;
                    int nFreeItemCount = oChkFreeProduct.IsFreeProductExist();
                    if (nFreeItemCount == 0)
                    {
                        oItem.Insert(_nTranID);
                    }
                    else
                    {
                        oItem.UpdateIsFreeQty(_nTranID);
                    }


                }

               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertCACTran()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_CACProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;
                //_sTranNo = "GRD-" + DateTime.Now.Year.ToString() + "-" + nMaxTranID.ToString("00000");
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CACProductStockTran (TranID, TranNo, TranDate, TranSide, TranTypeID ,LCNo, Remarks, CreateDate, CreateUserID, Status) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranSide", _nTranside);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.InsertCAC(_nTranID);
                }

                foreach (StockTranItem oItem in this)
                {
                    ProductStock oProductStock = new ProductStock();
                    oProductStock.ProductID = oItem.ProductID;
                    oProductStock.CurrentStock = oItem.Qty;
                    oProductStock.BookingStock = 0;
                    if (oProductStock.CheckCACProductStock())
                    {
                        oProductStock.CurrentStock = oItem.Qty;
                        oProductStock.UpdateCACCurrentStock(true);
                    }
                    else
                    {
                        oProductStock.CurrentStock = oItem.Qty;
                        oProductStock.InsertCACStock();
                        oProductStock.UpdateCACCurrentStock(true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertCACChallan()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_CACProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;
                _sTranNo = "Challan-" + DateTime.Now.Year.ToString() + "-" + nMaxTranID.ToString("00000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CACProductStockTran (TranID, TranNo, TranDate, TranSide, TranTypeID, Remarks, " +
                                  "CreateDate, CreateUserID, RefNo, CustomerID,CustomerName, DeliveryAddress, ContactPerson, ContactNo, Status) " +
                                  "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranSide", _nTranside);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("RefNo", _sRefNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("CustomerName", _sCACCustomerName);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.InsertCACChallan(_nTranID);
                }

                foreach (StockTranItem oItem in this)
                {
                    ProductStock oProductStock = new ProductStock();
                    oProductStock.ProductID = oItem.ProductID;
                    oProductStock.CurrentStock = oItem.Qty;
                    oProductStock.UpdateCACCurrentStock(false);
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
        /// For DMS Stock Tran
        /// </summary>
        public void InsertDMSStockTran()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DMSProductStockTran (TranID, TranNo, TranDate, TranType, Transide, FromCustomerID, ToCustomerID, Remarks, CreateDate,InvoiceAmount,DiscountAmount) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranType", _nTranTypeID);
                cmd.Parameters.AddWithValue("Transide", _nTranside);
                cmd.Parameters.AddWithValue("FromCustomerID", _nFromCustomerID);
                cmd.Parameters.AddWithValue("ToCustomerID", _nToCustomerID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("InvoiceAmount",_nInvoiceAmount);
                cmd.Parameters.AddWithValue("DiscountAmount", _nDiscountAmount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.InsertTranItemForDMS(_nTranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Add()
        {
            // Add by  Mr. Hakim on 08-Jul-14 (10.20AM) 

            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", Convert.ToInt16(Dictionary.ProductStockTranType.INVOICE));
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                if (_nToWHID == 0)
                    cmd.Parameters.AddWithValue("ToWHID", (long)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                else cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                if (_nToChannelID == 0)
                    cmd.Parameters.AddWithValue("ToChannelID", (long)Dictionary.SystemChannel.SYS_CHANNEL);
                else cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPOS(int nWarehouseID, bool IsTrue)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID",_nTranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", (long)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                cmd.Parameters.AddWithValue("ToChannelID", (long)Dictionary.SystemChannel.SYS_CHANNEL);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);
                }
                if (IsTrue)
                {
                    MapBranchTran oMBT = new MapBranchTran();
                    oMBT.TableName = "t_ProductStockTran";
                    oMBT.HODataID = Convert.ToInt32(_nTranID);
                    oMBT.BranchDataID = _nBranchDataID;
                    oMBT.WHID = nWarehouseID;
                    oMBT.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTranBranch( bool IsTrue)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);

                    if (IsTrue)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.Quantity = oItem.Qty;
                        oProductStock.ProductID = oItem.ProductID;
                        nProductID = oProductStock.ProductID;
                        oProductStock.WarehouseID = _nFromWHID;
                        oProductStock.UpdateCurrentStock_POS(true);
                        oProductStock.UpdateBookingStock_POS(false);


                        oProductStock.WarehouseID = _nToWHID;
                        oProductStock.ChannelID = Utility.TDRetailChannelID;
                        if (oProductStock.CheckProductStockBy())
                        {
                            oProductStock.UpdateCurrentStock_POS(false);
                        }
                        else
                        {
                            oProductStock.Insert();
                            oProductStock.UpdateCurrentStock_POS(false);
                            
                        }
                    }
                }
                if (IsTrue)
                {

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ProductStockTran";
                    oDataTran.DataID = _nTranID;
                    oDataTran.WarehouseID = _nToWHID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    if (oDataTran.CheckDataByType())
                    {
                    }
                    else
                    {
                        oDataTran.AddForTDPOS();
                    }
                    //oDataTran.AddForTDPOS();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTranBranchRT(bool IsTrue)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);
                    ProductStock oProductStock = new ProductStock();
                    oProductStock.Quantity = oItem.Qty;
                    oProductStock.ProductID = oItem.ProductID;
                    nProductID = oProductStock.ProductID;
                    oProductStock.WarehouseID = _nFromWHID;
                    //oProductStock.UpdateCurrentStock_POS(IsTrue);
                   // oProductStock.UpdateBookingStock_POS(IsTrue);
                    oProductStock.UpdateTransitStock_POS(IsTrue);

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertTranBranchRTTranferHO(bool IsTrue)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _nToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _nFromChannelID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);
                    ProductStock oProductStock = new ProductStock();
                    oProductStock.Quantity = oItem.Qty;
                    oProductStock.ProductID = oItem.ProductID;
                    nProductID = oProductStock.ProductID;
                    oProductStock.WarehouseID = _nFromWHID;
                    //oProductStock.UpdateBookingStock_POS(false);
                    oProductStock.UpdateTransitStock_POS(IsTrue);

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForReverse()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _nUserID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", Convert.ToInt16(Dictionary.ProductStockTranType.INVOICE));
                cmd.Parameters.AddWithValue("FromWHID", (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("ToChannelID",_nToChannelID );
                cmd.Parameters.AddWithValue("FromChannelID", (int)Dictionary.SystemChannel.SYS_CHANNEL);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);
                             
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (StockTranItem oItem in this)
                {
                    oItem.Insert(_nTranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStockTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _sTranNo);
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
            if (nCount == 1) return true;
            else return false;


        }

        public int GetTranID(string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nTranID = 0;
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStockTran where TranNo=?";
            
            cmd.Parameters.AddWithValue("TranNo", sTranNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nTranID = Convert.ToInt32(reader["TranID"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nTranID;

        }

        public void GetProductTranItem(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " Select * from t_ProductStockTranItem Where TranID =" + nTranID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    StockTranItem oStockTranItem = new StockTranItem();

                    oStockTranItem.TranID = (int)reader["TranID"];
                    oStockTranItem.ProductID = (int)reader["ProductID"];
                    oStockTranItem.Qty = int.Parse(reader["Qty"].ToString());
                    oStockTranItem.StockPrice = Convert.ToDouble(reader["StockPrice"].ToString());

                    InnerList.Add(oStockTranItem);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteTran(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_ProductTransferProductSerial Where TranID IN ( "+
                                  "Select TranID from t_ProductStockTran Where TranID=" + nTranID + ") ";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_ProductStockTranItem Where TranID IN ( " +
                                    "Select TranID from t_ProductStockTran Where TranID=" + nTranID + ") ";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_ProductStockTran Where TranID=" + nTranID + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeleteProductStockTran(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_ProductStockTranItem Where TranID IN ( " +
                                    "Select TranID from t_ProductStockTran Where TranID=" + nTranID + ") ";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_ProductStockTran Where TranID=" + nTranID + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateProductTranStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_ProductStockTran Set Status = ?,TranDate = ? Where TranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranID", _nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetCentralRetailStock(int nProductID)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCurrentStock = 0;
            try
            {
                cmd.CommandText = " Select (CurrentStock-BookingStock)CurrentStock from t_ProductStock " +
                                  " Where WarehouseID=70 and productid=" + nProductID + " and ChannelID=4 and Status=1 ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCurrentStock;
        }

        public void DeleteTranForDMS(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_DMSProductStockTranItem Where TranID=" + nTranID + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_DMSProductStockTran Where TranID=" + nTranID + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_DMSProductStockSerial Where TranID=" + nTranID + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByCACProductCode()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Select * from t_CACProduct where ProductCode=?";
                cmd.Parameters.AddWithValue("ProductCode", _sCACProductCode);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = int.Parse(reader["ProductID"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class StockTrans : CollectionBase
    {
        public void Add(StockTran oStockTran)
        {
            InnerList.Add(oStockTran);
        }
        public StockTran this[int i]
        {
            get { return (StockTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetProductTran(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " Select a.* from t_ProductStockTran a, t_DataTransfer b " +
                                    "where a.TranID=b.DataID and  b.TableName='t_ProductStockTran' and " +
                                    "b.IsDownload=1 and WarehouseID = " + nWarehouseID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockTran oStockTran = new StockTran();

                    oStockTran.TranID = (int)reader["TranID"];
                    oStockTran.LastUpdateUserID = (int)reader["LastUpdateUserID"];
                    oStockTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oStockTran.LastUpdateDate = Convert.ToDateTime(reader["LastUpdateDate"].ToString());
                    oStockTran.TranNo = reader["TranNo"].ToString();
                    oStockTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oStockTran.FromWHID = (int)reader["FromWHID"];
                    oStockTran.FromChannelID = (int)reader["FromChannelID"];
                    oStockTran.UserID = (int)reader["UserID"];
                    oStockTran.Remarks = reader["Remarks"].ToString();


                    oStockTran.GetProductTranItem(oStockTran.TranID);

                    InnerList.Add(oStockTran);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForCAC(DateTime dFromDate, DateTime dToDate, int nType, string sTranNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select TranID,TranNo,TranDate,TranSide,TranTypeID,Remarks,Status,CASE WHEN (CustomerName IS NULL )THEN ACustomerName ELSE CustomerName END AS CustomerName " +
                        "from( " +
                        "(Select CustomerID, TranID, TranNo, TranDate, TranSide, TranTypeID, isnull(Remarks,'') Remarks, isnull(Status, 1) Status, CustomerName as ACustomerName " +
                        "From t_CACProductStockTran ) as A " +
                        "Left Outer join " +
                        "(select CustomerID, CustomerName from t_Customer) as B on A.CustomerID = B.CustomerID) where TranSide = " + nType + " And TranDate between '" + dFromDate + "' " +
                        "and '" + dToDate + "' and TranDate< '" + dToDate + "'";
                //sSql = " Select a.* from (  " +
                //        "Select TranID, TranNo, TranDate, TranSide, TranTypeID, isnull(Remarks,'') Remarks,isnull(Status, 1) Status,a.CustomerName " +
                //        "From t_CACProductStockTran a, t_Customer b where a.CustomerID = b.CustomerID " +

                //        "union all " +

                //        "Select TranID, TranNo, TranDate, TranSide, TranTypeID, isnull(Remarks,'') Remarks,isnull(Status, 1) Status ,'' as CustomerName " +
                //        "From t_CACProductStockTran a where TranSide != 2 ) A where TranSide = " + nType + " And TranDate between '" + dFromDate + "' " +
                //        "and '" + dToDate + "' and TranDate< '" + dToDate + "' ";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            sSql = sSql + " Order by TranNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockTran oProductStockTran = new StockTran();

                    oProductStockTran.TranID = int.Parse(reader["TranID"].ToString());
                    oProductStockTran.TranNo = (reader["TranNo"].ToString());
                    oProductStockTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oProductStockTran.Transide = int.Parse(reader["TranSide"].ToString());
                    oProductStockTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oProductStockTran.Remarks = (reader["Remarks"].ToString());
                    oProductStockTran.Status = int.Parse(reader["Status"].ToString());
                   if (reader["CustomerName"] != DBNull.Value)
                    oProductStockTran.CACCustomerName = (reader["CustomerName"].ToString());

                    InnerList.Add(oProductStockTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void PrintForCAC(int nTranId,int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //dToDate = dToDate.AddDays(1);
            string sSql = "";

            //if (nType == 2)
            //{
            //    sSql = " Select b.TranID,ProductCode,ProductName,Model,CONCAT(DeliveryAddress, ', Contact Person : ', b.ContactPerson,', Ph No: ', ContactNo) AS DeliveryAddress, " +
            //                 "b.ContactPerson,ContactNo,DeliveryDate,CONCAT(CustomerName, ', ', CustomerAddress,', Ph No: ', CellPhoneNumber) AS CustomerAddress,RefNo,TranNo,TranDate,Qty,c.Remarks,TranSide from t_CACProduct a,t_CACProductStockTran b, " +
            //                 "t_CACProductStockTranItem c,t_Customer d where a.ProductID = c.ProductID and b.TranID = c.TranID and b.CustomerID=d.CustomerID and Transide=" + nType + " and c.TranID = " + nTranId + "";
            //}

            //else
            //{
            //    sSql = "Select b.TranID,ProductCode,ProductName,Model,CONCAT(DeliveryAddress, ', Contact Person : ', " +
            //            "b.ContactPerson,', Ph No: ', ContactNo) AS DeliveryAddress, b.ContactPerson,ContactNo,DeliveryDate,'NULL' as CustomerAddress, " +
            //            "RefNo,TranNo,TranDate,Qty,c.Remarks,TranSide from t_CACProduct a, t_CACProductStockTran b, t_CACProductStockTranItem c " +
            //            "where a.ProductID = c.ProductID and b.TranID = c.TranID and Transide=" + nType + " and c.TranID = " + nTranId + "";
            //}

            sSql = "Select A.*,B.*,CASE WHEN (CustomerAddress IS NULL )THEN CustomerName ELSE CustomerAddress END AS CustomerAddress From " +
                    "( " +
                    "(Select TranID, ProductCode, ProductName, Model, DeliveryDate, Qty, Remarks from t_CACProduct a, t_CACProductStockTranItem c " +
                    "where a.ProductID = c.ProductID) as A " +
                    "left Outer Join " +
                    "(select CustomerID, TranID, CONCAT(DeliveryAddress, ', Contact Person : ', ContactPerson, ', Ph No: ', ContactNo) AS DeliveryAddress, " +
                    "ContactPerson, ContactNo, CustomerName, RefNo, LCNo, TranNo, TranDate, TranSide from t_CACProductStockTran) as B on A.TranID = B.TranID " +
                    "left Outer Join " +
                    "(select CustomerID, CONCAT(CustomerName, ', ', CustomerAddress, ', Ph No: ', CellPhoneNumber) AS CustomerAddress from t_Customer) " +
                    "as C on C.CustomerID = B.CustomerID) where Transide=" + nType + " and A.TranID = " + nTranId + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockTran oProductStockTran = new StockTran();

                    oProductStockTran.TranID = int.Parse(reader["TranID"].ToString());
                    oProductStockTran.CACProductCode = (reader["ProductCode"].ToString());
                    oProductStockTran.CACProductName = (reader["ProductName"].ToString());
                    oProductStockTran.CACProductModel = (reader["Model"].ToString());
                    oProductStockTran.DeliveryAddress = (reader["DeliveryAddress"].ToString());
                    oProductStockTran.ContactPerson= (reader["ContactPerson"].ToString());
                    oProductStockTran.ContactNo = (reader["ContactNo"].ToString());
                    if (reader["DeliveryDate"] != DBNull.Value)
                        oProductStockTran.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    //if (reader["Customeraddress"] != DBNull.Value)
                        oProductStockTran.Customeraddress = (reader["CustomerAddress"].ToString());
                    //if (reader["RefNo"] != DBNull.Value)
                        oProductStockTran.RefNo= (reader["RefNo"].ToString());
                    oProductStockTran.TranNo = (reader["TranNo"].ToString());
                    oProductStockTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oProductStockTran.Transide = int.Parse(reader["TranSide"].ToString());
                    oProductStockTran.CACQty = int.Parse(reader["Qty"].ToString());
                    oProductStockTran.Remarks = (reader["Remarks"].ToString());
                    oProductStockTran.CACCustomerName = (reader["CustomerName"].ToString());
                    oProductStockTran.LCNo = (reader["LCNo"].ToString());
                    //oProductStockTran.Status = int.Parse(reader["Status"].ToString());
                    InnerList.Add(oProductStockTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void PrintForCACStockPosition(int nProductID,DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            //string sSql = "";
            string sSubstring = string.Empty;
            if (nProductID != -1)
            {
                sSubstring = " AND ProductID = " + nProductID + " ";
            }

            string sSql = "Select ProductCode,ProductName,BrandDesc,CostPrice,OpeningStock,ReceiveQty,IssueQty,(OpeningStock+ReceiveQty-IssueQty) as ClosingStock, CurrentStock " +
                    "From( "+
                    "select ProductID, Sum(OpeningStock) as OpeningStock, Sum(GRDQty) as ReceiveQty, SUM(IssueQty) as IssueQty, Sum(CurrentStock) as CurrentStock "+
                    "from (" +
                    "Select a.ProductID, (CurrentStock - IsNull(GRDQty,0) + ISNULL(IssueQty,0))as OpeningStock, 0 as GRDQty, 0 as IssueQty, CurrentStock from t_CACProductStock a " +
                    "Left Outer JOIN " +
                    "( " +
                    "Select A.ProductID,Sum(GRDQty) as GRDQty, Sum(IssueQty) as IssueQty " +
                    "From( " +
                    "select ProductID,TranDate,GRDQty=0, b.Qty IssueQty from dbo.t_CACProductStockTran a " +
                    "INNER JOIN(select TranID,ProductID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem " +
                    "WHERE 1=1   Group BY TranID, ProductID) b " +
                    "ON a.TranID = b.TranID WHERE Trandate between '"+ dFromDate + "' and '01-Nov-2060' and TranSide=2 " +
                    "UNION ALL " +
                    "select ProductID,TranDate,b.Qty GRDQty, IssueQty=0 from dbo.t_CACProductStockTran a " +
                    "INNER JOIN (select TranID,ProductID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem " +
                    "WHERE 1=1   Group BY TranID,ProductID) b  ON a.TranID = b.TranID " +
                    "WHERE Trandate between '" + dFromDate + "' and '01-Nov-2060' and TranSide =1)as A Where 1=1 "+ sSubstring + "" +
                    "Group by ProductID)Trn ON Trn.ProductID = a.ProductID " +

                    "UNION ALL " +

                    "select ProductID,0 as OpeningStock, 0 as GRDQty,b.Qty IssueQty, 0 as CurrentStock from dbo.t_CACProductStockTran a " +
                    "INNER JOIN (select TranID,ProductID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem WHERE 1=1   Group BY TranID, ProductID) b " +
                    "ON a.TranID = b.TranID WHERE Trandate between '" + dFromDate + "' and '"+ dToDate + "' and Trandate < '" + dToDate + "' and TranSide=2 " +
                    "UNION ALL " +
                    "select ProductID,0 as OpeningStock,b.Qty as GRDQty, 0 as IssueQty, 0 as CurrentStock from dbo.t_CACProductStockTran a " +
                    "INNER JOIN (select TranID,ProductID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem " +
                    "WHERE 1=1   Group BY TranID,ProductID) b  ON a.TranID = b.TranID " +
                    "WHERE Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate <'" + dToDate + "' and TranSide =1 " +
                    ") as a Where 1=1 " + sSubstring + " Group by ProductID) As P " +
                    "Left Outer Join " +
                    "(Select a.ProductID,ProductCode,ProductName,CPBDT as CostPrice,BrandDesc " +
                    "from t_CACProduct a,t_CACFinishedGoodsPrice b,t_Brand c " +
                    "Where a.ProductID=b.ProductID and a.BrandID=c.BrandID and IsCurrent=1 " +
                    ") As Q On P.ProductID=Q.ProductID";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockTran oProductStockTran = new StockTran();

                    //oProductStockTran.TranID = int.Parse(reader["TranID"].ToString());
                    oProductStockTran.CACProductCode = (reader["ProductCode"].ToString());
                    oProductStockTran.CACProductName = (reader["ProductName"].ToString());
                    oProductStockTran.OpeningStock = int.Parse(reader["OpeningStock"].ToString());
                    oProductStockTran.GRDQty= int.Parse(reader["ReceiveQty"].ToString());
                    oProductStockTran.IssueQty= int.Parse(reader["IssueQty"].ToString());
                    oProductStockTran.ClosingStock= int.Parse(reader["ClosingStock"].ToString());
                    InnerList.Add(oProductStockTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int PrintForCACStockLedgerProductWise(int nProductID,DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";

            sSql = "select a.TranID,b.ProductID,ProductCode, ProductName,Case when TranTypeID=1 then 'GOODS_RECEIVE' when TranTypeID=3 then 'ISSUE_CHALLAN' end as TranTypeID,TranSide,TranNo,TranDate,b.Qty GRDQty,IssueQty=0 " +
                    "from dbo.t_CACProductStockTran a "+
                    "INNER JOIN(select TranID, ProductID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem where ProductID="+ nProductID + "" +
                     "Group BY TranID, ProductID) b ON a.TranID = b.TranID   Left Outer JOIN " +
                     "(Select ProductID, ProductCode, ProductName from t_CACProduct) c on b.ProductID = c.ProductID Where TranSide = 1 " +
                     "AND TranDate   BETWEEN '"+ dFromDate + "' AND '"+ dToDate + "' " +
                     "and TranDate < '" + dToDate + "' " +
                     "UNION ALL " +
                     "select a.TranID,b.ProductID,ProductCode, ProductName,Case when TranTypeID=1 then 'GOODS_RECEIVE' when TranTypeID=3 then 'ISSUE_CHALLAN' end as TranTypeID,TranSide,TranNo,TranDate,GRDQty = 0,b.Qty IssueQty " +
                     "from dbo.t_CACProductStockTran a " +
                     "INNER JOIN(select TranID, ProductID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem where ProductID=" + nProductID + "" +
                     "Group BY TranID, ProductID) b ON a.TranID = b.TranID   Left Outer JOIN " +
                     "(Select ProductID, ProductCode, ProductName from t_CACProduct) c on b.ProductID = c.ProductID where TranSide = 2 " +
                     "AND TranDate   BETWEEN '" + dFromDate + "' AND '" + dToDate + "' " +
                     "and TranDate < '" + dToDate + "'";

            int nCount = 0;
            int nCount1 = 0;
            int nBalance = 0;
            int nOpeningStock = 0;

            try
            {
                if (nCount == 0)
                {
                    nOpeningStock = GetOpeningSock(nProductID, dFromDate, dToDate);
                    nCount++;
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockTran oProductStockTran = new StockTran();
                    oProductStockTran.OpeningStock = nOpeningStock;
                    oProductStockTran.TranID = int.Parse(reader["TranID"].ToString());
                    oProductStockTran.ProductID = int.Parse(reader["ProductID"].ToString());
                    oProductStockTran.CACProductCode = (reader["ProductCode"].ToString());
                    oProductStockTran.CACProductName = (reader["ProductName"].ToString());
                    oProductStockTran.TranTypeID= (string)reader["TranTypeID"];
                    oProductStockTran.Transide = int.Parse(reader["Transide"].ToString());
                    oProductStockTran.TranNo = (reader["TranNo"].ToString());
                    oProductStockTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oProductStockTran.GRDQty = int.Parse(reader["GRDQty"].ToString());
                    oProductStockTran.IssueQty = int.Parse(reader["IssueQty"].ToString());
                    //oProductStockTran.ClosingStock = int.Parse(reader["ClosingStock"].ToString());

                    if (nCount1 == 0)
                    {
                        nBalance = oProductStockTran.OpeningStock;
                        nCount1++;
                    }
                    oProductStockTran.Balance = nBalance + oProductStockTran.GRDQty - oProductStockTran.IssueQty;
                    nBalance = oProductStockTran.Balance;
                    oProductStockTran.ClosingStock = oProductStockTran.Balance;
                    InnerList.Add(oProductStockTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }

        public int GetOpeningSock(int nProductID, DateTime dtFromDate, DateTime dtToDate)
        {
            string subQuery = string.Empty;
            //InnerList.Clear();
            dtToDate = dtToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (nProductID != -1)
            {
                subQuery = " AND ProductID =" + nProductID + " ";
            }
            string sSql = "select ((Sum(CurrentStock) +Sum(IssueQty))-Sum(GRDQty)) as OpeningStock " +
                        "from(select CurrentStock = 0, GRDQty = 0, b.Qty IssueQty from dbo.t_CACProductStockTran a " +
                        "INNER JOIN(select TranID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem WHERE 1 = 1 " +
                        "" + subQuery + "  Group BY TranID) b ON a.TranID = b.TranID " +
                        "WHERE TranDate BETWEEN '"+ dtFromDate + "' AND '" + dtToDate + "' " +
                        "and TranDate < '" + dtToDate + "' and TranSide = 2 " +
                        "UNION ALL " +
                        "select CurrentStock = 0, b.Qty GRDQty, IssueQty = 0 from dbo.t_CACProductStockTran a " +
                        "INNER JOIN(select TranID, SUM(Qty) Qty from dbo.t_CACProductStockTranItem WHERE 1 = 1 " +
                        "" + subQuery + "  Group BY TranID) b ON a.TranID = b.TranID " +
                        "WHERE TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' and TranDate < '" + dtToDate + "' and TranSide = 1" +
                        "UNION ALL " +
                        "Select CurrentStock, 0 as GRDQty, 0 as IssueQty from t_CACProductStock " +
                        "WHERE 1 = 1 " + subQuery + ") x";

            int nOpeningStock = 0;

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["OpeningStock"] != DBNull.Value)
                    {
                        nOpeningStock = int.Parse(reader["OpeningStock"].ToString());
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;

        }
    }
}
