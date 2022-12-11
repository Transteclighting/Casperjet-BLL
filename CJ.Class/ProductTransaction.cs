// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 20, 2011
// Time : 12.00 PM
// Description: Class for Customer Transaction.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;
using CJ.Class.HR;


namespace CJ.Class
{
    public class ProductTransactionDetail
    {
        private int _TranID;
        private int _ProductID;
        private long _Qty;
        private double _StockPrice;
        private int _Status;
        private int _RefTranID;
        private long _LCProductQty;
        private long _LCShortQty;
        private long _LCDamagedQty;
        private long _LCMinorDefectiveQty;
        private string _LCRemarks;

        private Product _oProduct;

        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                  

                }
                return _oProduct;
            }
        }

        private string _ProductCode;
        private string _ProductDescription;
        private long _MOQ;
        private int _PrintID;
        private string _PrintHeader;
        private double _TradePrice;
        private double _VAT;
        private int _LoanQty;
        private int _ReturnQty;      
        private double _NSP;
        private double _RSP;
        private long _LSRatio;
        private long _MSRatio;

        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        public string ProductDescription
        {
            get { return _ProductDescription; }
            set { _ProductDescription = value; }
        }
        public long MOQ
        {
            get { return _MOQ; }
            set { _MOQ = value; }
        }
        public int PrintID
        {
            get { return _PrintID; }
            set { _PrintID = value; }
        }
        public string PrintHeader
        {
            get { return _PrintHeader; }
            set { _PrintHeader = value; }
        }
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        public int LoanQty
        {
            get { return _LoanQty; }
            set { _LoanQty = value; }
        }
        public int ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        public long LSRatio
        {
            get { return _LSRatio; }
            set { _LSRatio = value; }
        }
        public long MSRatio
        {
            get { return _MSRatio; }
            set { _MSRatio = value; }
        }
        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }
        private string _DutyTranNo;
        public string DutyTranNo
        {
            get { return _DutyTranNo; }
            set { _DutyTranNo = value; }
        }

        private double _DutyPrice;
        public double DutyPrice
        {
            get { return _DutyPrice; }
            set { _DutyPrice = value; }
        }

        private double _DutyRate;
        public double DutyRate
        {
            get { return _DutyRate; }
            set { _DutyRate = value; }
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
        /// Get set property for Qty
        /// </summary>
        public long Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
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
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Get set property for RefTranID
        /// </summary>
        public int RefTranID
        {
            get { return _RefTranID; }
            set { _RefTranID = value; }
        }

        /// <summary>
        /// Get set property for LCProductQty
        /// </summary>
        public long LCProductQty
        {
            get { return _LCProductQty; }
            set { _LCProductQty = value; }
        }

        /// <summary>
        /// Get set property for LCShortQty
        /// </summary>
        public long LCShortQty
        {
            get { return _LCShortQty; }
            set { _LCShortQty = value; }
        }

        /// <summary>
        /// Get set property for LCDamagedQty
        /// </summary>
        public long LCDamagedQty
        {
            get { return _LCDamagedQty; }
            set { _LCDamagedQty = value; }
        }

        /// <summary>
        /// Get set property for LCMinorDefectiveQty
        /// </summary>
        public long LCMinorDefectiveQty
        {
            get { return _LCMinorDefectiveQty; }
            set { _LCMinorDefectiveQty = value; }
        }

        /// <summary>
        /// Get set property for LCRemarks
        /// </summary>
        public string LCRemarks
        {
            get { return _LCRemarks; }
            set { _LCRemarks = value.Trim(); }
        }
        public void Insert(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ProductStockTranItem (TranID,ProductID,Qty,StockPrice,Status,RefTranID,LCProductQty,LCShortQty,LCDamagedQty,LCMinorDefectiveQty,LCRemarks) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("RefTranID",null);
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

        public void InsertNewWithRefTran(long nTranID,long _nRefTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ProductStockTranItem (TranID,ProductID,Qty,StockPrice,Status,RefTranID,LCProductQty,LCShortQty,LCDamagedQty,LCMinorDefectiveQty,LCRemarks) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("RefTranID", _nRefTranID);
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

        public void InsertForWeb(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ProductStockTranItem (TranID,ProductID,Qty,StockPrice,Status,RefTranID,LCProductQty,LCShortQty,LCDamagedQty,LCMinorDefectiveQty,LCRemarks,DutyTranNo,DutyPrice,DutyRate) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("RefTranID", null);
                cmd.Parameters.AddWithValue("LCProductQty", null);
                cmd.Parameters.AddWithValue("LCShortQty", null);
                cmd.Parameters.AddWithValue("LCDamagedQty", null);
                cmd.Parameters.AddWithValue("LCMinorDefectiveQty", null);
                cmd.Parameters.AddWithValue("LCRemarks", null);

                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);




                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForGRD(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ProductStockTranItem (TranID,ProductID,Qty,StockPrice,Status,RefTranID,LCProductQty,LCShortQty,LCDamagedQty,LCMinorDefectiveQty,LCRemarks) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("RefTranID", null);
                cmd.Parameters.AddWithValue("LCProductQty", null);
                cmd.Parameters.AddWithValue("LCShortQty", _LCShortQty);
                cmd.Parameters.AddWithValue("LCDamagedQty", _LCDamagedQty);
                cmd.Parameters.AddWithValue("LCMinorDefectiveQty", _LCMinorDefectiveQty);
                cmd.Parameters.AddWithValue("LCRemarks", _LCRemarks);

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

            try
            {
                cmd.CommandText = "Delete from  t_ProductStockTranItem Where TranID=? ";
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


    }
    public class ProductTransaction : CollectionBase
    {
        public ProductTransactionDetail this[int i]
        {
            get { return (ProductTransactionDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductTransactionDetail oProductTransactionDetail)
        {
            InnerList.Add(oProductTransactionDetail);
        }

        private string _sBarcode;
        public string Barcode
        {
            get { return _sBarcode; }
            set { _sBarcode = value; }
        }

        private int _TranID;
        private int _LastUpdateUserID;
        private DateTime _CreateDate;
        private DateTime _LastUpdateDate;
        private int _POID;
        private string _TranNo;
        private string _sDeliveryPerson;
        private string _sVehicleNo;
        private string _sDeliveryPersonContactNo;
        private DateTime _TranDate;
        private int _TranTypeID;
        private int _FromWHID;
        private int _ToWHID;
        private int _ToChannelID;
        private int _FromChannelID;
        private int _UserID;
        private int _Status;
        private string _Remarks;
        private int _UploadStatus;
        private DateTime _UploadDate;
        private DateTime _DownloadDate;
        private int _RowStatus;
        private int _Terminal;
        private string _LCNo;
        private DateTime _LCDate;
        private string _LCInvoiceNo;
        private DateTime _LCInvoiceDate;
        private bool _bFlag;
        private string _TranTypeName;
        private int _nShipmentID;
        private int _nChallanID;
        private int _nIsEqual;
        private int _nGRDID;


        // <summary>
        // Get set property for ChallanID
        // </summary>
        public int ChallanID
        {
            get { return _nChallanID; }
            set { _nChallanID = value; }
        }


        // <summary>
        // Get set property for _nGRDID
        // </summary>
        public int GRDID
        {
            get { return _nGRDID; }
            set { _nGRDID = value; }
        }



        // <summary>
        // Get set property for IsEqual
        // </summary>
        public int IsEqual
        {
            get { return _nIsEqual; }
            set { _nIsEqual = value; }
        }
        public string VehicleNo
        {
            get { return _sVehicleNo; }
            set { _sVehicleNo = value; }
        }
        public string DeliveryPersonContactNo
        {
            get { return _sDeliveryPersonContactNo; }
            set { _sDeliveryPersonContactNo = value; }
        }
        public string DeliveryPerson
        {
            get { return _sDeliveryPerson; }
            set { _sDeliveryPerson = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        private string _sTransactionSide;
        public string TransactionSide
        {
            get { return _sTransactionSide; }
            set { _sTransactionSide = value; }
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

        public string TranTypeName
        {
            get { return _TranTypeName; }
            set { _TranTypeName = value; }
        }    


        private Employee _oEmployee;

    
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

        private ProductDetail _oProductDetail;
        public ProductDetail oProductDetail
        {
            get
            {
                if (_oProductDetail == null)
                {
                    _oProductDetail = new ProductDetail();

                }
                return _oProductDetail;
            }
        }

        private ProductStock _oProductStock;
        public ProductStock oProductStock
        {
            get
            {
                if (_oProductStock == null)
                {
                    _oProductStock = new ProductStock();

                }
                return _oProductStock;
            }
        }

        private POSRequisition _oPOSRequisition;
        public POSRequisition oPOSRequisition
        {
            get
            {
                if (_oPOSRequisition == null)
                {
                    _oPOSRequisition = new POSRequisition();

                }
                return _oPOSRequisition;
            }
        }

        private Channel _oChannel;
        public Channel Channel
        {
            get
            {
                if (_oChannel == null)
                {
                    _oChannel = new Channel();

                }
                return _oChannel;
            }
        }

        private ProductBarcodes _oProductBarcodes;
        public ProductBarcodes ProductBarcodes
        {
            get
            {
                if (_oProductBarcodes == null)
                {
                    _oProductBarcodes = new ProductBarcodes();

                }
                return _oProductBarcodes;
            }
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
        /// Get set property for LastUpdateUserID
        /// </summary>
        public int LastUpdateUserID
        {
            get { return _LastUpdateUserID; }
            set { _LastUpdateUserID = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        /// <summary>
        /// Get set property for LastUpdateDate
        /// </summary>
        public DateTime LastUpdateDate
        {
            get { return _LastUpdateDate; }
            set { _LastUpdateDate = value; }
        }

        /// <summary>
        /// Get set property for POID
        /// </summary>
        public int POID
        {
            get { return _POID; }
            set { _POID = value; }
        }

        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }

        /// <summary>
        /// Get set property for FromWHID
        /// </summary>
        public int FromWHID
        {
            get { return _FromWHID; }
            set { _FromWHID = value; }
        }

        /// <summary>
        /// Get set property for ToWHID
        /// </summary>
        public int ToWHID
        {
            get { return _ToWHID; }
            set { _ToWHID = value; }
        }

        /// <summary>
        /// Get set property for ToChannelID
        /// </summary>
        public int ToChannelID
        {
            get { return _ToChannelID; }
            set { _ToChannelID = value; }
        }

        /// <summary>
        /// Get set property for FromChannelID
        /// </summary>
        public int FromChannelID
        {
            get { return _FromChannelID; }
            set { _FromChannelID = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for UploadStatus
        /// </summary>
        public int UploadStatus
        {
            get { return _UploadStatus; }
            set { _UploadStatus = value; }
        }

        /// <summary>
        /// Get set property for UploadDate
        /// </summary>
        public DateTime UploadDate
        {
            get { return _UploadDate; }
            set { _UploadDate = value; }
        }

        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public DateTime DownloadDate
        {
            get { return _DownloadDate; }
            set { _DownloadDate = value; }
        }

        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public int RowStatus
        {
            get { return _RowStatus; }
            set { _RowStatus = value; }
        }

        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public int Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }

        /// <summary>
        /// Get set property for LCNo
        /// </summary>
        public string LCNo
        {
            get { return _LCNo; }
            set { _LCNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LCDate
        /// </summary>
        public DateTime LCDate
        {
            get { return _LCDate; }
            set { _LCDate = value; }
        }

        /// <summary>
        /// Get set property for LCInvoiceNo
        /// </summary>
        public string LCInvoiceNo
        {
            get { return _LCInvoiceNo; }
            set { _LCInvoiceNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LCInvoiceDate
        /// </summary>
        public DateTime LCInvoiceDate
        {
            get { return _LCInvoiceDate; }
            set { _LCInvoiceDate = value; }
        }

        
        // <summary>
        // Get set property for ShipmentID
        // </summary>
        public int ShipmentID
         { 
               get { return  _nShipmentID; }
               set { _nShipmentID = value; }
         } 

        private int _nHOTranID;
        public int HOTranID
        {
            get { return _nHOTranID;}
            set { _nHOTranID = value;}
        }

        public void Add()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_ProductStockTran";
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
                _TranID = nMaxTranID;
                sSql = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.ProductStockTranType.GOODS_RECEIVE);
                cmd.Parameters.AddWithValue("FromWHID", (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", (int)Dictionary.SystemChannel.SYS_CHANNEL);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.StockTransactionStatus.COMPLETE);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("LCNo", _LCNo);
                cmd.Parameters.AddWithValue("LCDate", _LCDate);
                cmd.Parameters.AddWithValue("LCInvoiceNo", _LCInvoiceNo);
                cmd.Parameters.AddWithValue("LCInvoiceDate", _LCInvoiceDate);
                //cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //foreach (ProductTransactionDetail oItem in this)
                //{
                //    oItem.InsertForGRD(_TranID);

                //    _oProductStock = new ProductStock();
                //    _oProductStock.WarehouseID = _ToWHID;
                //    _oProductStock.ChannelID = _ToChannelID;
                //    _oProductStock.Quantity = oItem.Qty;
                //    _oProductStock.ProductID = oItem.ProductID;
                //    if (_oProductStock.CheckProductStockBy())
                //        _oProductStock.UpdateCurrentStock_GRD(true);
                //    else
                //    {
                //        _oProductStock.Insert();
                //        _oProductStock.UpdateCurrentStock_GRD(true);
                //    }

                //    //if (_oProductStock.Flag == true)
                //    //    continue;
                //    //else return false;
                //}

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddSCMGRDData()
        {
            int nMaxGRDID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([GRDID]) FROM t_SCMGRD";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxGRDID = 1;
                }
                else
                {
                    nMaxGRDID = Convert.ToInt32(maxID) + 1;
                }
                _nGRDID = nMaxGRDID;
                sSql = "INSERT INTO t_SCMGRD (GRDID, TranID, ShipmentID, ChallanID) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("GRDID", _nGRDID);
                cmd.Parameters.AddWithValue("TranID", _TranID);
                if (_nShipmentID != null)
                {
                    cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ShipmentID", null);
                }

                if (_nChallanID != null)
                {
                    cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ChallanID", null);
                }
                

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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate, ShipmentID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.ProductStockTranType.INVOICE);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", (int)Dictionary.WarehouseType.SYSTEM);
                cmd.Parameters.AddWithValue("ToChannelID", (int)Dictionary.ChannelType.SYSTEM);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);
                cmd.Parameters.AddWithValue("ShipmentID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertWSStockTran()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.ProductStockTranType.INVOICE);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", (int)Dictionary.WarehouseType.SYSTEM);
                cmd.Parameters.AddWithValue("ToChannelID", (int)Dictionary.ChannelType.SYSTEM);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOS()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.ProductStockTranType.TRANSFER);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
              
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool InsertForTransferWithIMEI(bool IsTrue,int _nType,int _nRefMGTTranID)
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.InsertNewWithRefTran(_TranID, _nRefMGTTranID);
                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;

                    if (_nType == 1)
                    {
                        if (_oProductStock.CheckProductStockBy())
                        {
                            _oProductStock.UpdateCurrentStock(true);

                            if (IsTrue)
                            {
                                _oProductStock.WarehouseID = _FromWHID;
                                _oProductStock.ChannelID = _FromChannelID;
                                _oProductStock.UpdateCurrentStock(false);
                            }
                        }
                        else
                        {
                            _oProductStock.Insert();
                            _oProductStock.UpdateCurrentStock(true);
                            if (IsTrue)
                            {
                                _oProductStock.WarehouseID = _FromWHID;
                                _oProductStock.ChannelID = _FromChannelID;
                                _oProductStock.UpdateCurrentStock(false);
                            }
                        }
                    }

                    else if (_nType == 3)
                    {
                        if (_oProductStock.CheckProductStockBy())
                        {
                            _oProductStock.UpdateCurrentStock(true);

                            if (IsTrue)
                            {
                                _oProductStock.WarehouseID = _FromWHID;
                                _oProductStock.ChannelID = _FromChannelID;
                                _oProductStock.UpdateCurrentStock(false);
                            }
                        }
                        else
                        {
                            _oProductStock.Insert();
                            _oProductStock.UpdateCurrentStock(true);
                            if (IsTrue)
                            {
                                _oProductStock.WarehouseID = _FromWHID;
                                _oProductStock.ChannelID = _FromChannelID;
                                _oProductStock.UpdateCurrentStock(false);
                            }
                        }
                    }
                    else if (_nType == 2)
                    {
                        if (IsTrue)
                        {
                            _oProductStock.WarehouseID = _ToWHID;
                            _oProductStock.ChannelID = _ToChannelID;
                            _oProductStock.Quantity = oItem.Qty;
                            _oProductStock.ProductID = oItem.ProductID;
                            if (_oProductStock.CheckProductStockBy())
                            {
                                _oProductStock.UpdateCurrentStock(true);
                            }
                            else
                            {
                                _oProductStock.Insert();
                                _oProductStock.UpdateCurrentStock(true);
                            }
                        }
                        else
                        {
                            _oProductStock.WarehouseID = _FromWHID;
                            _oProductStock.ChannelID = _FromChannelID;
                            _oProductStock.Quantity = oItem.Qty;
                            _oProductStock.ProductID = oItem.ProductID;
                            _oProductStock.UpdateCurrentStock(false);
                        }
                    }
                    if (_oProductStock.Flag == true)
                        continue;
                    else return false;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        public bool InsertForTransferWithIMEI_POS(bool IsTrue)
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                try
                {
                    MapHOTran oMHT = new MapHOTran();
                    oMHT.TableName = "t_ProductStockTran";
                    oMHT.HODataID = _nHOTranID;
                    oMHT.BranchDataID = Convert.ToInt32(_TranID);
                    oMHT.Add();

                    AppLogger.LogInfo("Successfully Uploaded Map HO tran");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Uploading Map HO tran /" + ex.Message);
                    throw (ex);
                }

                int nTransactionSide = 0;
                try
                {
                    cmd = DBController.Instance.GetCommand();
                    string sSqlTran = "";
                    sSqlTran = "select TransactionSide from t_productStockTranType Where TranTypeID=" + _TranTypeID + "";
                    cmd.CommandText = sSqlTran;
                    object TransactionSide = cmd.ExecuteScalar();
                    if (TransactionSide != DBNull.Value)
                    {
                        nTransactionSide = int.Parse(TransactionSide.ToString());
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }


                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);
                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;
                    if (_oProductStock.CheckProductStockBy())
                    {
                        if (nTransactionSide == (int)Dictionary.TransectionSide.DEBIT)
                        {
                            _oProductStock.UpdateCurrentStock(true);
                        }
                        else if (nTransactionSide == (int)Dictionary.TransectionSide.CREDIT)
                        {
                            _oProductStock.UpdateCurrentStock(false);
                        }

                        if (IsTrue)
                        {
                            _oProductStock.WarehouseID = _FromWHID;
                            _oProductStock.ChannelID = _FromChannelID;
                            _oProductStock.UpdateCurrentStock(false);
                        }
                    }
                    else
                    {
                        _oProductStock.Insert();

                        if (nTransactionSide == (int)Dictionary.TransectionSide.DEBIT)
                        {
                            _oProductStock.UpdateCurrentStock(true);
                        }
                        else if (nTransactionSide == (int)Dictionary.TransectionSide.CREDIT)
                        {
                            _oProductStock.UpdateCurrentStock(false);
                        }

                        if (IsTrue)
                        {
                            _oProductStock.WarehouseID = _FromWHID;
                            _oProductStock.ChannelID = _FromChannelID;
                            _oProductStock.UpdateCurrentStock(false);
                        }
                    }
                    if (_oProductStock.Flag == true)
                        continue;
                    else return false;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public void ProdSL(ProductTransferProductSerials oPTPSs)
        {
            foreach (ProductTransferProductSerial oPTPS in oPTPSs)
            {
                oPTPS.Insert(_TranID);
            }  

        }
        public bool InsertForGRD()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Today.Date);
                if (_POID != -1)
                    cmd.Parameters.AddWithValue("POID", _POID);
                else cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.ProductStockTranType.GOODS_RECEIVE);
                cmd.Parameters.AddWithValue("FromWHID", (int)Dictionary.WarehouseType.SYSTEM);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID",_ToChannelID );
                cmd.Parameters.AddWithValue("FromChannelID", (int)Dictionary.ChannelType.SYSTEM);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                if (_POID != -1)
                    cmd.Parameters.AddWithValue("LCNo", null);
                else cmd.Parameters.AddWithValue("LCNo", _LCNo);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.InsertForGRD(_TranID);

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;
                    if (_oProductStock.CheckProductStockBy())
                        _oProductStock.UpdateCurrentStock_GRD(true);
                    else
                    {
                        _oProductStock.Insert();
                        _oProductStock.UpdateCurrentStock_GRD(true);
                    }

                    if (_oProductStock.Flag == true)
                        continue;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        public void InsertForTransfer()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }
        public bool InsertProductTran()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public bool InsertProductTranWithVATData()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.InsertForWeb(_TranID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        public bool InsertForStockTransfer()
        {
            int nMaxTranID = 0;
            int nMaxTranNo = 0;
            DateTime todate = DateTime.Today.Date;
            DateTime fromdate = todate.AddDays(1);

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
                _TranID = nMaxTranID;

                //cmd.Dispose();
                //cmd = DBController.Instance.GetCommand();

                //sSql = "select max( convert(int, (right(tranno,2)),1)) as MaxTranNo from t_Productstocktran "
                //       +" where trandate between ? and ? and trandate < ? and len(tranno)=12";
                //cmd.Parameters.AddWithValue("orderdate", todate);
                //cmd.Parameters.AddWithValue("orderdate", fromdate);
                //cmd.Parameters.AddWithValue("orderdate", fromdate);

                //cmd.CommandText = sSql;
                //object MaxTranNo = cmd.ExecuteScalar();
                //if (MaxTranNo == DBNull.Value)
                //{
                //    nMaxTranNo = 1;
                //}
                //else
                //{
                //    nMaxTranNo = int.Parse(MaxTranNo.ToString()) + 1;

                //}

                //_TranNo = "T" + DateTime.Today.Date.ToString("yyyy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + "-" + nMaxTranNo.ToString("00");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _UserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _TranDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _FromWHID;
                    _oProductStock.ChannelID = _FromChannelID;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;
                    _oProductStock.UpdateCurrentStock(false);
                    
                    if (_oProductStock.Flag == false)
                        return false;

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;
                    if (_oProductStock.CheckProductStockBy())
                        _oProductStock.UpdateCurrentStock(true);
                    else
                    {
                        _oProductStock.Insert();
                        _oProductStock.UpdateCurrentStock(true);
                    }
                    if (_oProductStock.Flag == true)
                        continue;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        public bool InsertForISGMTransfer(int nISGMStatus)
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran (TranID, LastUpdateUserID, CreateDate, LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal, LCNo, LCDate, LCInvoiceNo, LCInvoiceDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("POID", null);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", _ToChannelID);
                cmd.Parameters.AddWithValue("FromChannelID", _FromChannelID);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("LCInvoiceNo", null);
                cmd.Parameters.AddWithValue("LCInvoiceDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);

                    if (nISGMStatus == (int)Dictionary.ProductISGMStatus.Send_By_FromWarehouse)
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _ToWHID;
                        _oProductStock.ChannelID = _ToChannelID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.ProductID = oItem.ProductID;
                        if (_oProductStock.CheckProductStockBy())
                            _oProductStock.UpdateCurrentStock(true);
                        else
                        {
                            _oProductStock.Insert();
                            _oProductStock.UpdateCurrentStock(true);
                        }
                        if (_oProductStock.Flag == true)
                            continue;
                        else return false;
                    }
                    else
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _FromWHID;
                        _oProductStock.ChannelID = _FromChannelID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.ProductID = oItem.ProductID;

                        _oProductStock.UpdateCurrentStock(false);

                        if (_oProductStock.Flag == true)
                            continue;
                        else return false;

                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        public bool CheckTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStockTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _TranNo);
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
            if (nCount == 0) return true;
            else return false;


        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ProductStockTran Where TranID=? ";
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
        public void UpdateSupplierID(int nSupplierID,string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_ProductBarCodeDetail set SupplierID=" + nSupplierID + " where RefTranNo='" + sTranNo + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCurrentStock_GRD()
        {
            InnerList.Clear();        
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ProductStockTranItem where TranID=?";
            cmd.Parameters.AddWithValue("TranID", _TranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransactionDetail _oProductTransactionDetail = new ProductTransactionDetail();

                    _oProductTransactionDetail.ProductID = int.Parse(reader["ProductID"].ToString());
                    _oProductTransactionDetail.Qty = Convert.ToInt32( reader["Qty"].ToString());

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.Quantity = _oProductTransactionDetail.Qty;
                    _oProductStock.ProductID = _oProductTransactionDetail.ProductID;
                    _oProductStock.UpdateCurrentStock_GRD(false);

                    InnerList.Add(_oProductTransactionDetail);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckProductStockTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStockTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _TranNo);
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
            if (nCount == 0) return true;
            else return false;


        }
        public bool InsertForCassiopiaToCasperTransfer()
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
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockTran ( TranID, LastUpdateUserID, CreateDate, " +
                    "LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, " +
                    "UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal,LCNo,LCDate,LCInvoiceNo,LCInvoiceDate )   " +
                    "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("LastUpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("LastUpdateDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("POID", Convert.DBNull);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("TranDate", System.DateTime.Now.Date);
                cmd.Parameters.AddWithValue("TranTypeID", Dictionary.ProductTransaction.TRANSFER);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("ToChannelID", 4);
                cmd.Parameters.AddWithValue("FromChannelID", 4);
                cmd.Parameters.AddWithValue("UserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UploadStatus", Convert.DBNull);
                cmd.Parameters.AddWithValue("UploadDate", Convert.DBNull);
                cmd.Parameters.AddWithValue("DownloadDate", Convert.DBNull);
                cmd.Parameters.AddWithValue("RowStatus", Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", Dictionary.Terminal.Head_Office);
                cmd.Parameters.AddWithValue("LCNo", Convert.DBNull);
                cmd.Parameters.AddWithValue("LCDate", Convert.DBNull);
                cmd.Parameters.AddWithValue("LCInvoiceNo", Convert.DBNull);
                cmd.Parameters.AddWithValue("LCInvoiceDate", Convert.DBNull);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductTransactionDetail oItem in this)
                {
                    oItem.Insert(_TranID);

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _FromWHID;
                    _oProductStock.ChannelID = 4;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;
                    _oProductStock.UpdateCurrentStock(false);

                    if (_oProductStock.Flag == false)
                        return false;

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = 4;
                    _oProductStock.Quantity = oItem.Qty;
                    _oProductStock.ProductID = oItem.ProductID;
                    if (_oProductStock.CheckProductStockBy())
                        _oProductStock.UpdateCurrentStock(true);
                    else
                    {
                        _oProductStock.Insert();
                        _oProductStock.UpdateCurrentStock(true);
                    }
                    if (_oProductStock.Flag == true)
                        continue;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ProductStockTran where POID =?";
            cmd.Parameters.AddWithValue("POID", _POID);
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
            if (nCount != 0) _bFlag=true;
            else _bFlag = false;

        }

        public string GetBarcode(int nTranId)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ProductTransferProductSerial a,t_Product b  " +
                          "where TranID = " + nTranId + " and a.ProductID = b.ProductID order by a.ProductID";
            string sProductSerialNo = "";
            string sBarcode = "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    if (sBarcode != reader["ProductCode"].ToString())
                    {
                        sProductSerialNo = sProductSerialNo + "<" + reader["ProductCode"].ToString() + ">";
                        sBarcode = reader["ProductCode"].ToString();
                        sProductSerialNo = sProductSerialNo + reader["ProductSerialNo"].ToString();
                    }
                    else
                    {
                        sProductSerialNo = sProductSerialNo + "," + reader["ProductSerialNo"].ToString();
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sProductSerialNo;

        }

        public void RefershByID()
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,isnull(VehicleNo, '') VehicleNo, " +
                          "isnull(DeliveryPerson, '') DeliveryPerson,isnull(DeliveryPersonContactNo, '') DeliveryPersonContactNo From " +
                          "( " +
                          "Select a.*,TranTypeName,TransactionSide From t_ProductStockTran a,t_ProductStockTranType b where a.TranTypeID=b.TranTypeID " +
                          ") a " +
                          "Left Outer Join " +
                          "( " +
                          "Select a.* From t_DutyVehicle a, (Select TranID, max(ID)ID From t_DutyVehicle " +
                          "group by TranID) b where a.ID = b.ID " +
                          ") b on a.TranID = b.TranID where a.TranID = ? ";

            cmd.Parameters.AddWithValue("TranID", _TranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                    if (reader["POID"] != DBNull.Value)
                    {
                        _POID = int.Parse(reader["POID"].ToString());
                    }
                    else _POID = -1;
                    _TranID= int.Parse(reader["TranID"].ToString());
                    _TranNo = reader["TranNo"].ToString();
                    _TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _ToChannelID = int.Parse(reader["ToChannelID"].ToString());
                    _FromChannelID = int.Parse(reader["FromChannelID"].ToString());
                    _UserID = int.Parse(reader["UserID"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _Remarks = reader["Remarks"].ToString();
                    }
                    else _Remarks = "";
                    _sBarcode = GetBarcode(_TranID);

                    _sDeliveryPerson = reader["DeliveryPerson"].ToString();
                    _sDeliveryPersonContactNo = reader["DeliveryPersonContactNo"].ToString();
                    _sVehicleNo = reader["VehicleNo"].ToString();

                    _TranTypeName = reader["TranTypeName"].ToString();

                }
                reader.Close();               

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefershByTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ProductStockTran where TranNo = ? ";
            cmd.Parameters.AddWithValue("TranNo", _TranNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranID = (int)reader["TranID"];
                    _TranNo = reader["TranNo"].ToString();
                    _TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _ToChannelID = int.Parse(reader["ToChannelID"].ToString());
                    _FromChannelID = int.Parse(reader["FromChannelID"].ToString());
                    _UserID = int.Parse(reader["UserID"].ToString());
                    _Remarks = reader["Remarks"].ToString();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT TranID,ProductID,Qty,isnull(StockPrice,0) StockPrice FROM t_ProductStockTranItem where TranID= '" + _TranID + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.StockPrice = Convert.ToDouble(reader["StockPrice"].ToString());

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
        public void RefreshItemForUpload()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT isnull(DutyTranNo,'') DutyTranNo,isnull(DutyPrice,0) DutyPrice,isnull(DutyRate,0) DutyRate,TranID,ProductID,Qty,isnull(StockPrice,0) StockPrice FROM t_ProductStockTranItem where TranID= '" + _TranID + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.StockPrice = Convert.ToDouble(reader["StockPrice"].ToString());

                    oItem.DutyTranNo = (reader["DutyTranNo"].ToString());
                    oItem.DutyPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oItem.DutyRate = Convert.ToDouble(reader["DutyRate"].ToString());

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
        public void RefreshItemForDownload()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,isnull(b.DutyTranNo,'') DutyTranNo,isnull(b.DutyPrice,0) DutyPrice, " +
                                "isnull(b.DutyRate,0) DutyRate From  " +
                                "( " +
                                "SELECT TranID,a.ProductID,Qty,StockPrice  " +
                                "FROM t_ProductStockTranItem a " +
                                "where TranID= " + _TranID + " " +
                                ") a " +
                                "Left Outer Join  " +
                                "( " +
                                "Select StockTranID,ProductID, " +
                                "isnull(DutyTranNo,'') DutyTranNo,isnull(DutyPrice,0) DutyPrice, " +
                                "isnull(DutyRate,0) DutyRate From t_StockRequisitionItem a,t_StockRequisition b " +
                                "where a.StockRequisitionID=b.StockRequisitionID  " +
                                "and StockTranID =" + _TranID + " " +
                                ") b on a.TranID=b.StockTranID and a.ProductID=b.ProductID";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.StockPrice = Convert.ToDouble(reader["StockPrice"].ToString());

                    oItem.DutyTranNo = (reader["DutyTranNo"].ToString());
                    oItem.DutyPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oItem.DutyRate = Convert.ToDouble(reader["DutyRate"].ToString());

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
        public void RefreshItemDetail()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select q1.*,q2.productcode as ProductCode, q2.productName as ProductDescription,UOMConversionfactor as MOQ,TradePrice,VAT,LSRatio,MSRatio,isnull(RSP,0) as RSP from t_ProductStockTranItem q1, v_productdetails q2 where q1.productid = q2.productid and q1.TranID = ? order by q2.ProductID ASC";
                cmd.Parameters.AddWithValue("TranID", _TranID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.StockPrice = Convert.ToDouble(reader["StockPrice"].ToString());

                    oItem.ProductCode = reader["ProductCode"].ToString();
                    oItem.ProductDescription = reader["ProductDescription"].ToString();
                    oItem.MOQ = Convert.ToInt64(reader["MOQ"].ToString());
                    oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oItem.LSRatio = Convert.ToInt64(reader["LSRatio"].ToString());
                    oItem.MSRatio = Convert.ToInt64(reader["MSRatio"].ToString());
                    oItem.RSP = Convert.ToDouble(reader["RSP"].ToString());

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
        public void UpdateStockTranStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_productstocktran SET Status=? Where TranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("TranID", _TranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateLastUser()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_productstocktran SET LastUpdateUserID=?, LastUpdateDate=? Where TranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LastUpdateUserID", _LastUpdateUserID);
                cmd.Parameters.AddWithValue("LastUpdateDate", _LastUpdateDate);
                cmd.Parameters.AddWithValue("TranID", _TranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Transfer detail from Cassiopeia
        /// </summary>
        public void RefreshItemDetailFromCassiopeia()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.SRTranID AS TranID, b.Code AS ProductCode, " +
                               "Quantity AS Qty, CostPrice AS StockPrice  " +
                               "FROM Cassiopeia_HO.dbo.SRTranItem  a   " +
                               "INNER JOIN Cassiopeia_HO.dbo.Product b   " +
                               "ON a.ProductID = b.ProductID  WHERE SRTranID = ? AND ShowroomID = 1 ";

                cmd.Parameters.AddWithValue("SRTranID", _TranID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransactionDetail oItem = new ProductTransactionDetail();
                                    

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.ProductCode = reader["ProductCode"].ToString();

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = oItem.ProductCode;
                    _oProductDetail.RefreshByCode();

                    oItem.ProductID = _oProductDetail.ProductID;
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.StockPrice = Convert.ToDouble(reader["StockPrice"].ToString());

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

        public DSProductTransaction ProductStockTransferReport(DSProductTransaction oDSProductTransaction)
        {                 
            try
            {
                RefershByID();
                RefreshItemDetail();

                for (int i = 0; i < 4; i++)
                {
                    _oWarehouse = new Warehouse();

                    DSProductTransaction.ProductStockTranRow oProductStockTranRow = oDSProductTransaction.ProductStockTran.NewProductStockTranRow();

                    oProductStockTranRow.TranNo = _TranNo;
                    oProductStockTranRow.TranDate = _TranDate;
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _FromWHID;
                    _oWarehouse.Reresh();
                    oProductStockTranRow.FromWHName = _oWarehouse.WarehouseName + "[" + _oWarehouse.WarehouseCode + "]";
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _ToWHID;
                    _oWarehouse.Reresh();
                    oProductStockTranRow.ToWHName = _oWarehouse.WarehouseName + "[" + _oWarehouse.WarehouseCode + "]";
                    oProductStockTranRow.Remarks = _Remarks;
                    oProductStockTranRow.UserName = "Sadar Road,Mohakhali,Dhaka-1206.";
                    oProductStockTranRow.ProductSerialNo = _sBarcode;
                    oProductStockTranRow.DeliveryPerson = _sDeliveryPerson;
                    oProductStockTranRow.DeliveryPersonContactNo = _sDeliveryPersonContactNo;
                    oProductStockTranRow.VehicleNo = _sVehicleNo;
                    oProductStockTranRow.TranTypeName = _TranTypeName;

                    oProductStockTranRow.PrintID = i + 1;
                    if (i == 0)
                    {
                        oProductStockTranRow.PrintHeader = "Warehouse Copy";
                    }
                    else if (i == 1)
                    {
                        oProductStockTranRow.PrintHeader = "Customer Copy";
                    }
                    else if (i == 2)
                    {
                        oProductStockTranRow.PrintHeader = "Gate Pass Copy";
                    }
                    else if (i == 3)
                    {
                        oProductStockTranRow.PrintHeader = "Customer Receipt Copy";
                    }

                    oDSProductTransaction.ProductStockTran.AddProductStockTranRow(oProductStockTranRow);
                }
                foreach (ProductTransactionDetail oProductTransactionDetail in this)
                {
                    DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow = oDSProductTransaction.ProductStockTranItem.NewProductStockTranItemRow();

                    oProductStockTranItemRow.ProductCode = oProductTransactionDetail.ProductCode;
                    oProductStockTranItemRow.ProductDescription = oProductTransactionDetail.ProductDescription;
                    oProductStockTranItemRow.Qty = oProductTransactionDetail.Qty;
                    oProductStockTranItemRow.MOQ = oProductTransactionDetail.MOQ;
                    oProductStockTranItemRow.TradePrice = oProductTransactionDetail.TradePrice;
                    oProductStockTranItemRow.VAT = oProductTransactionDetail.VAT;
                    oProductStockTranItemRow.LSRatio = oProductTransactionDetail.LSRatio;
                    oProductStockTranItemRow.MSRatio = oProductTransactionDetail.MSRatio;
                    oProductStockTranItemRow.WH = _oWarehouse.WarehouseName + "[" + _oWarehouse.WarehouseCode + "]";
                    oProductStockTranItemRow.Barcode = "";
                    oProductStockTranItemRow.TranNo = _TranNo;
                    oProductStockTranItemRow.RSP = oProductTransactionDetail.RSP;

                    oDSProductTransaction.ProductStockTranItem.AddProductStockTranItemRow(oProductStockTranItemRow);
                }

                oDSProductTransaction.AcceptChanges();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSProductTransaction;
        }

        public void RefreshIsShipmentQtyEqual(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ShipmentID,IsEqual From  "+
                               " (Select ShipmentID,ShipmentQty,GRDQty,(ShipmentQty-GRDQty) IsEqual From   "+
                               " (Select x.ShipmentID,ShipmentQty,isnull (GRDQty,0) GRDQty From   "+
                               " (Select ShipmentID,sum (ShipmentQty) ShipmentQty From t_SCMShipmentItem   "+
                               " group by ShipmentID) x   "+
                               " Left Outer Join    "+
                               " (Select ShipmentID,sum (Qty) GRDQty From t_SCMGRD a,t_ProductStockTranItem b   " +
                               " where a.TranID=b.TranID group by ShipmentID) y  " +
                               " on x.ShipmentID=y.ShipmentID) x ) xx where ShipmentID = ? ";

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = Convert.ToInt32(reader["ShipmentID"]);
                    _nIsEqual = Convert.ToInt32(reader["IsEqual"]);
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshIsChallanQtyEqual(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ChallanID,IsEqual From  "+
                                " (Select ChallanID,ChallanQty,GRDQty,(ChallanQty-GRDQty) IsEqual From    "+
                                " (Select x.ChallanID,ChallanQty,isnull (GRDQty,0) GRDQty From    "+
                                " (Select ID as ChallanID,sum (ChallanQty) ChallanQty From t_ProductionLotDeliveryItem    "+
                                " group by ID) x    "+
                                " Left Outer Join     "+
                                " (Select ChallanID,sum (Qty) GRDQty From t_SCMGRD a,t_ProductStockTranItem b    "+
                                " where a.TranID=b.TranID  and ChallanID is not null group by ChallanID) y    " +
                                " on x.ChallanID=y.ChallanID) x ) xx where ChallanID = ? ";

                cmd.Parameters.AddWithValue("ChallanID", nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = Convert.ToInt32(reader["ChallanID"]);
                    _nIsEqual = Convert.ToInt32(reader["IsEqual"]);
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #region Web Service Functions

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public DSRequisition POSTransferOut(DSRequisition oDSRequisition, DSRequisition oDSRequisitionItem, DSBarcodeDetail oDSBarcodeDetail, int nUserID, bool IsProductSerialSkip)
        {
            DBController.Instance.BeginNewTransaction();
            int _nRequisitionID = 0;
            try
            {
                _nRequisitionID = Convert.ToInt16(oDSRequisition.Requisition[0].RequisitionID);  
                _TranNo = oDSRequisition.Requisition[0].RequisitionNo;

                if (CheckProductStockTranNo())
                {
                    _FromWHID = Convert.ToInt16(oDSRequisition.Requisition[0].ToWHID);
                    _ToWHID = Convert.ToInt16(oDSRequisition.Requisition[0].FromWHID);

                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _FromWHID;
                    _oWarehouse.Reresh();
                    _FromChannelID = _oWarehouse.ChannelID;

                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _ToWHID;
                    _oWarehouse.Reresh();
                    _ToChannelID = _oWarehouse.ChannelID;

                    _UserID = nUserID;
                    _Remarks = oDSRequisition.Requisition[0].Remarks;
                    _Terminal = 1; 

                    InsertForPOS();

                    foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisitionItem.RequisitionItem)
                    {
                        ProductTransactionDetail oProductTransactionDetail = new ProductTransactionDetail();

                        oProductTransactionDetail.TranID = _TranID;
                        oProductTransactionDetail.ProductID = int.Parse(oRequisitionItemRow.ProductID);
                        oProductTransactionDetail.Qty = int.Parse(oRequisitionItemRow.TransferQty);

                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                        _oProductDetail.Refresh();

                        oProductTransactionDetail.StockPrice = _oProductDetail.CostPrice;

                        oProductTransactionDetail.Insert(_TranID);

                        Add(oProductTransactionDetail);

                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _FromWHID;                   
                        _oProductStock.ProductID = _oProductDetail.ProductID;
                        _oProductStock.Quantity = int.Parse(oRequisitionItemRow.TransferQty);
                        _oProductStock.UpdateCurrentStock_POS(true);

                        if (_oProductStock.Flag == false)
                        {
                            int tepm = int.Parse("Create Exceptions");
                        }

                        _oProductStock.Quantity = oRequisitionItemRow.AuthorizeQty;
                        _oProductStock.UpdateBookingStock_POS(false);

                        if (_oProductStock.Flag == false)
                        {
                            int tepm = int.Parse("Create Exceptions");
                        }
                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _ToWHID;
                        _oProductStock.ChannelID = _ToChannelID;
                        _oProductStock.ProductID = _oProductDetail.ProductID;
                        _oProductStock.Quantity = int.Parse(oRequisitionItemRow.TransferQty);
                        if (_oProductStock.CheckProductStock())
                        {
                            _oProductStock.UpdateTransitStock_POS(true);
                        }
                        else
                        {
                            _oProductStock.Insert();
                            _oProductStock.UpdateTransitStock_POS(true);
                        }

                    }
                    if (IsProductSerialSkip !=true)
                    {
                        foreach (DSBarcodeDetail.BarcodeDetailRow oBarcodeDetailRow in oDSBarcodeDetail.BarcodeDetail)
                        {
                            ProductBarcode oProductBarcode = new ProductBarcode();

                            oProductBarcode.TranID = _TranID;
                            oProductBarcode.ProductId = int.Parse(oBarcodeDetailRow.ProductID);
                            oProductBarcode.ProductSerialNo = oBarcodeDetailRow.Barcode;
                            oProductBarcode.EntryUserID = nUserID;
                            oProductBarcode.WarehouseID = _ToWHID;
                            oProductBarcode.RefTranNo = _TranNo;

                            oProductBarcode.InsertTranferProductSerial((int)Dictionary.BarcodeStatus.Transfer,Utility.CentralRetailWarehouse);

                        }
                    }
                    ///
                    // Duty Calculation
                    ///
                    double _DutyImportBalance = 0;
                    double _DutyLocalBalance = 0;
                    DutyTran oDutyTranVAT11;
                    DutyTran oDutyTranVAT11KA;
                    DutyAccount oDutyAccount;

                    oDutyTranVAT11 = new DutyTran();
                    oDutyTranVAT11KA = new DutyTran();

                    oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA, _DutyLocalBalance);
                    oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11, _DutyImportBalance);

                    if (oDutyTranVAT11.Count > 0)
                    {
                        oDutyTranVAT11.Remarks = _Remarks;
                        oDutyTranVAT11.Insert();
                    }
                    if (oDutyTranVAT11KA.Count > 0)
                    {
                        oDutyTranVAT11KA.Remarks = _Remarks;
                        oDutyTranVAT11KA.Insert();
                    }
                    oDutyAccount = new  DutyAccount();
                    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                    oDutyAccount.Balance = _DutyLocalBalance;
                    oDutyAccount.UpdateBalance(true);

                    oDutyAccount = new DutyAccount();
                    oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                    oDutyAccount.Balance = _DutyImportBalance;
                    oDutyAccount.UpdateBalance(true);

                    _oPOSRequisition = new POSRequisition();
                    _oPOSRequisition.RequisitionID = _nRequisitionID;
                    _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Out;
                    _oPOSRequisition.StockTranID = _TranID;
                    _oPOSRequisition.UpdateStatus();
                    _oPOSRequisition.UpdateStockTranId();
                 
                    oDSRequisition = new DSRequisition();
                    DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                    oRequisitionRow.RequisitionID = "1";
                    oRequisitionRow.Result = "1";
                    oRequisitionRow.RequisitionNo = _TranNo;
                    oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                    oDSRequisition.AcceptChanges();

                    DBController.Instance.CommitTransaction();

                }
                else
                {
                    oDSRequisition = new DSRequisition();
                    DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                    oRequisitionRow.RequisitionID = "-1";
                    oRequisitionRow.Result = "0";
                    oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                    oDSRequisition.AcceptChanges();
                }
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();


            }
            return oDSRequisition;
        }
        public DSRequisition POSGoodsReceived(DSRequisition oDSRequisition, DSRequisition oDSRequisitionItem, int nUserID)
        {
            int _nRequisitionID = 0;
            DBController.Instance.BeginNewTransaction();
            try
            {
                _nRequisitionID = Convert.ToInt16(oDSRequisition.Requisition[0].RequisitionID);
                _TranNo = oDSRequisition.Requisition[0].RequisitionNo;
                _FromWHID = Convert.ToInt16(oDSRequisition.Requisition[0].FromWHID);
                _ToWHID = Convert.ToInt16(oDSRequisition.Requisition[0].ToWHID);

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _FromWHID;
                _oWarehouse.Reresh();
                _FromChannelID = _oWarehouse.ChannelID;

                _UserID = nUserID;
                _Remarks = oDSRequisition.Requisition[0].Remarks;
                _TranID = int.Parse(oDSRequisition.Requisition[0].StockTranID);
                _Terminal = 1;
                RefreshItem();

                foreach (ProductTransactionDetail oProductTransactionDetail in this)
                {
                   
                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _FromWHID;
                    _oProductStock.ChannelID = _FromChannelID;
                    _oProductStock.ProductID = oProductTransactionDetail.ProductID;
                    _oProductStock.Quantity = oProductTransactionDetail.Qty;
                    _oProductStock.UpdateCurrentStock_POS(false);
                    _oProductStock.UpdateTransitStock_POS(false);

                    if (_oProductStock.Flag == false)
                    {
                        int tepm = int.Parse("Create Exceptions");
                    }                    

                }
               
                OleDbCommand cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_DataTransfer VALUES(?,?,?,?,?)";;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", "t_ProductStockTran");
                cmd.Parameters.AddWithValue("DataID", _TranID);
                cmd.Parameters.AddWithValue("WarehouseID", _FromWHID);
                cmd.Parameters.AddWithValue("TransferType", 1);
                cmd.Parameters.AddWithValue("IsDownload", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                _oPOSRequisition = new POSRequisition();
                _oPOSRequisition.RequisitionID = _nRequisitionID;
                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Transfer_Received;
                _oPOSRequisition.UpdateStatus();

                DBController.Instance.CommitTransaction();

                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "1";
                oRequisitionRow.Result = "1";
                oRequisitionRow.RequisitionNo = _TranNo;
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();

                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }

            return oDSRequisition;
        }
        public DSRequisition POSGoodsRetrun(DSRequisition oDSRequisition)
        {
            int _nRequisitionID = 0;
            int _nRequisitionStatus = 0;
            DBController.Instance.BeginNewTransaction();
            try
            {
                _nRequisitionID = Convert.ToInt16(oDSRequisition.Requisition[0].RequisitionID);
                _TranNo = oDSRequisition.Requisition[0].RequisitionNo;
                _TranID = int.Parse(oDSRequisition.Requisition[0].StockTranID);
                _FromWHID = Convert.ToInt16(oDSRequisition.Requisition[0].ToWHID);
                _ToWHID = Convert.ToInt16(oDSRequisition.Requisition[0].FromWHID);
                _nRequisitionStatus = Convert.ToInt16(oDSRequisition.Requisition[0].Status);

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _FromWHID;
                _oWarehouse.Reresh();
                _FromChannelID = _oWarehouse.ChannelID;

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _ToWHID;
                _oWarehouse.Reresh();
                _ToChannelID = _oWarehouse.ChannelID;

                RefreshItem();

                foreach (ProductTransactionDetail oProductTransactionDetail in this)
                {
                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _FromWHID;
                    _oProductStock.ChannelID = _FromChannelID;
                    _oProductStock.ProductID = oProductTransactionDetail.ProductID;
                    _oProductStock.Quantity = oProductTransactionDetail.Qty;
                    _oProductStock.UpdateCurrentStock_POS(false);

                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.ProductID = oProductTransactionDetail.ProductID;
                    _oProductStock.Quantity = oProductTransactionDetail.Qty;

                    if ((int)Dictionary.ProductRequisitionStatus.Transfer_Received == _nRequisitionStatus)
                        _oProductStock.UpdateCurrentStock_POS(true);
                    else _oProductStock.UpdateTransitStock_POS(false);

                    if (_oProductStock.Flag == false)
                    {
                        int tepm = int.Parse("Create Exceptions");
                    }      

                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.TranID = _TranID;
                    oProductBarcode.ProductId = oProductTransactionDetail.ProductID;
                    oProductBarcode.DeleteProductSerial();

                }

                ProductTransactionDetail _oProductTransactionDetail = new ProductTransactionDetail();
                _oProductTransactionDetail.TranID = _TranID;
                _oProductTransactionDetail.Delete();
                Delete();

                _oPOSRequisition = new POSRequisition();
                _oPOSRequisition.RequisitionID = _nRequisitionID;
                _oPOSRequisition.Status = (int)Dictionary.ProductRequisitionStatus.Submitted;              
                _oPOSRequisition.UpdateStatus();

                DBController.Instance.CommitTransaction();

                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "1";
                oRequisitionRow.Result = "1";
                oRequisitionRow.RequisitionNo = _TranNo;
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();

               

            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();

                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }
            return oDSRequisition;
        }
        public DSProductTransaction POSGetProductTransactionReport(DSProductTransaction oDSProductTransaction, int nTranID,int nEmployeeId)
        {            
            _TranID = nTranID;
            string _BarcodeList = "";
            try
            {
                RefershByID();
                RefreshItemDetail();

                for (int i = 0; i < 4; i++)
                {
                    _oWarehouse = new Warehouse();

                    DSProductTransaction.ProductStockTranRow oProductStockTranRow = oDSProductTransaction.ProductStockTran.NewProductStockTranRow();

                    oProductStockTranRow.TranNo = _TranNo;
                    oProductStockTranRow.TranDate = _TranDate;
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _FromWHID;
                    _oWarehouse.Reresh();
                    oProductStockTranRow.FromWHName = _oWarehouse.WarehouseName + "[" + _oWarehouse.WarehouseCode + "]";
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _ToWHID;
                    _oWarehouse.Reresh();
                    oProductStockTranRow.ToWHName = _oWarehouse.WarehouseName + "[" + _oWarehouse.WarehouseCode + "]";
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = nEmployeeId;
                    _oEmployee.Refresh();
                    _oEmployee.ReadDB = true;
                    oProductStockTranRow.UserName = _oEmployee.JobLocation.Description;

                    oProductStockTranRow.PrintID = i + 1;
                    if (i == 0)
                    {
                        oProductStockTranRow.PrintHeader = "Warehouse Copy";
                    }
                    else if (i == 1)
                    {
                        oProductStockTranRow.PrintHeader = "Customer Copy";
                    }
                    else if (i == 2)
                    {
                        oProductStockTranRow.PrintHeader = "Gate Pass Copy";
                    }
                    else if (i == 3)
                    {
                        oProductStockTranRow.PrintHeader = "Customer Receipt Copy";
                    }

                    oDSProductTransaction.ProductStockTran.AddProductStockTranRow(oProductStockTranRow);
                }
                foreach (ProductTransactionDetail oProductTransactionDetail in this)
                {
                    DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow = oDSProductTransaction.ProductStockTranItem.NewProductStockTranItemRow();

                    oProductStockTranItemRow.ProductCode = oProductTransactionDetail.ProductCode;
                    oProductStockTranItemRow.ProductDescription = oProductTransactionDetail.ProductDescription;
                    oProductStockTranItemRow.Qty = oProductTransactionDetail.Qty;
                    oProductStockTranItemRow.MOQ = oProductTransactionDetail.MOQ;
                    oProductStockTranItemRow.TradePrice = oProductTransactionDetail.TradePrice;
                    oProductStockTranItemRow.VAT = oProductTransactionDetail.VAT;
                    oProductStockTranItemRow.LSRatio = oProductTransactionDetail.LSRatio;
                    oProductStockTranItemRow.MSRatio = oProductTransactionDetail.MSRatio;
                    oProductStockTranItemRow.WH = _oWarehouse.WarehouseName + "[" + _oWarehouse.WarehouseCode + "]";

                    ProductBarcodes oProductBarcodes = new ProductBarcodes();
                    oProductBarcodes.GetBarcodeForPOS(_TranID, oProductTransactionDetail.ProductID);
                    _BarcodeList = "";

                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                    {
                        if (_BarcodeList == "")
                            _BarcodeList = oProductBarcode.ProductSerialNo;
                        else _BarcodeList = _BarcodeList + ", " + oProductBarcode.ProductSerialNo;
                    }
                    oProductStockTranItemRow.Barcode = _BarcodeList;
                    oProductStockTranItemRow.TranNo = _TranNo;
                    oProductStockTranItemRow.RSP = oProductTransactionDetail.RSP;
                    oDSProductTransaction.ProductStockTranItem.AddProductStockTranItemRow(oProductStockTranItemRow);
                }
                oDSProductTransaction.AcceptChanges();

                DutyTranList oDutyTranList;
                oDutyTranList = new DutyTranList();
                oDutyTranList.GetTranID(_TranID.ToString(), _TranNo, _FromWHID);

                foreach (DutyTran oDutyTran in oDutyTranList)
                {
                    oDutyTran.GetVATReport();

                    DSProductTransaction.DutyTranRow oDutyTranRow = oDSProductTransaction.DutyTran.NewDutyTranRow();

                    oDutyTranRow.DutyTranID = oDutyTran.DutyTranID;
                    oDutyTranRow.DutyTranNo = oDutyTran.DutyTranNo;
                    oDutyTranRow.DutyTranDate = oDutyTran.DutyTranDate;
                    oDutyTranRow.ChallanTypeID = oDutyTran.ChallanTypeID;
                    oDutyTranRow.WHID = oDutyTran.WHID;

                    Warehouse oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = oDutyTranRow.WHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();

                    oDutyTranRow.WarehouseName = oWarehouse.WarehouseName;
                    oDutyTranRow.WarehouseAddress = oJobLocation.Description;

                    oDSProductTransaction.DutyTran.AddDutyTranRow(oDutyTranRow);
                    oDSProductTransaction.AcceptChanges();

                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        DSProductTransaction.DutyTranDetailRow oDutyTranDetailRow = oDSProductTransaction.DutyTranDetail.NewDutyTranDetailRow();

                        oDutyTranDetailRow.DutyTranID = oDutyTran.DutyTranID;
                        oDutyTranDetailRow.ProductID = oDutyTranDetail.ProductID;
                        oDutyTranDetailRow.ProductName = oDutyTranDetail.ProductName;
                        oDutyTranDetailRow.Qty = oDutyTranDetail.Qty;
                        oDutyTranDetailRow.DutyPrice = oDutyTranDetail.DutyPrice;
                        oDutyTranDetailRow.DutyRate = oDutyTranDetail.DutyRate;

                        oDSProductTransaction.DutyTranDetail.AddDutyTranDetailRow(oDutyTranDetailRow);
                        oDSProductTransaction.AcceptChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSProductTransaction;
        }
        public DSISGM POSISGMAuthorize(DSISGM oDSISGM,DSISGM oDSISGMItem, int nUserID)
        {
            DBController.Instance.BeginNewTransaction();          
            try
            {
                _TranNo = oDSISGM.ProductISGM[0].ISGMNo;

                if (CheckProductStockTranNo())
                {
                    _FromWHID = oDSISGM.ProductISGM[0].FromWHID;
                    _ToWHID = oDSISGM.ProductISGM[0].ToWHID;

                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _FromWHID;
                    _oWarehouse.Reresh();
                    _FromChannelID = _oWarehouse.ChannelID;

                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _ToWHID;
                    _oWarehouse.Reresh();
                    _ToChannelID = _oWarehouse.ChannelID;

                    _UserID = nUserID;
                    _Remarks = oDSISGM.ProductISGM[0].Remarks;
                    _Terminal = 1;

                    InsertForPOS();

                    foreach (DSISGM.ProductISGMItemRow oProductISGMItemRow in oDSISGMItem.ProductISGMItem)
                    {
                        ProductTransactionDetail oProductTransactionDetail = new ProductTransactionDetail();

                        oProductTransactionDetail.TranID = _TranID;
                        oProductTransactionDetail.ProductID = oProductISGMItemRow.ProductID;
                        oProductTransactionDetail.Qty = oProductISGMItemRow.Qty;

                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                        _oProductDetail.Refresh();

                        oProductTransactionDetail.StockPrice = _oProductDetail.CostPrice;

                        oProductTransactionDetail.Insert(_TranID);

                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _FromWHID;
                        _oProductStock.ChannelID = _FromChannelID;
                        _oProductStock.ProductID = _oProductDetail.ProductID;
                        _oProductStock.Quantity = oProductISGMItemRow.Qty;
                        _oProductStock.UpdateCurrentStock(false);

                        if (_oProductStock.Flag == false)
                        {
                            int tepm = int.Parse("Create Exceptions");
                        }
                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _ToWHID;
                        _oProductStock.ChannelID = _ToChannelID;
                        _oProductStock.ProductID = _oProductDetail.ProductID;
                        _oProductStock.Quantity = oProductISGMItemRow.Qty;
                        _oProductStock.UpdateCurrentStock(true);

                        if (_oProductStock.Flag == false)
                        {
                            int tepm = int.Parse("Create Exceptions");
                        }

                    }
                    foreach (DSISGM.BarcodeRow oSelectedBarcodeRow in oDSISGMItem.Barcode)
                    {
                        ProductBarcode oProductBarcode = new ProductBarcode();

                        oProductBarcode.TranID = _TranID;
                        oProductBarcode.ProductId = oSelectedBarcodeRow.ProductID;
                        oProductBarcode.ProductSerialNo = oSelectedBarcodeRow.Barcode;
                        oProductBarcode.EntryUserID = nUserID;
                        oProductBarcode.WarehouseID = _ToWHID;
                        oProductBarcode.RefTranNo = _TranNo;

                        oProductBarcode.InsertTranferProductSerial((int)Dictionary.BarcodeStatus.ISGM, _FromWHID);

                    }
                    ProductISGM oProductISGM = new ProductISGM();
                    oProductISGM.ISGMID = oDSISGM.ProductISGM[0].ISGMID;
                    oProductISGM.Status = (int)Dictionary.ProductISGMStatus.Authorized;
                    oProductISGM.AuthorizeBy = nUserID;
                    oProductISGM.AuthorizeDate = DateTime.Today.Date;
                    oProductISGM.StockTranID = _TranID;

                    oProductISGM.AuthorizeUpdate();

                    DBController.Instance.CommitTransaction();
                    oDSISGM.ProductISGM[0].Result = "1";
                    oDSISGM.ProductISGM[0].ISGMNo = _TranNo;

                }
                else
                {
                    DBController.Instance.RollbackTransaction();
                    oDSISGM.ProductISGM[0].Result = "Dublicate Tran no";
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();


            }
            return oDSISGM;
        }
        public DSProductTransaction POSGetISGMProductTransaction(DSProductTransaction oDSProductTransaction, int nTranID)
        {
            _TranID = nTranID;
          
            try
            {
                RefershByID();
                RefreshItemDetail();

                DSProductTransaction.ProductStockTranRow oProductStockTranRow = oDSProductTransaction.ProductStockTran.NewProductStockTranRow();

                oProductStockTranRow.TranNo = _TranNo;
                oProductStockTranRow.TranDate = _TranDate;
                oProductStockTranRow.TranTypeId = _TranTypeID;
                oProductStockTranRow.ToWHId = _ToWHID;
                oProductStockTranRow.ToChannelID = _ToChannelID;
                oProductStockTranRow.FromWHId = _FromWHID;
                oProductStockTranRow.FromChannelId = _FromChannelID;
                oProductStockTranRow.UserId = _UserID;
                oProductStockTranRow.Remarks = _Remarks;

                oDSProductTransaction.ProductStockTran.AddProductStockTranRow(oProductStockTranRow);

                foreach (ProductTransactionDetail oProductTransactionDetail in this)
                {
                    DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow = oDSProductTransaction.ProductStockTranItem.NewProductStockTranItemRow();

                    oProductStockTranItemRow.ProductID = oProductTransactionDetail.ProductID;
                    oProductStockTranItemRow.Qty = oProductTransactionDetail.Qty;
                    oProductStockTranItemRow.StockPrice = oProductTransactionDetail.StockPrice;
                    oProductStockTranItemRow.RSP = oProductTransactionDetail.RSP;

                    oDSProductTransaction.ProductStockTranItem.AddProductStockTranItemRow(oProductStockTranItemRow);

                    ProductBarcodes oProductBarcodes = new ProductBarcodes();
                    oProductBarcodes.GetBarcodeForPOS(_TranID, oProductTransactionDetail.ProductID);               

                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                    {
                        DSProductTransaction.BarcodeRow oBarcodeRow = oDSProductTransaction.Barcode.NewBarcodeRow();

                        oBarcodeRow.WarehouseID = _ToWHID;
                        oBarcodeRow.ProductID = oProductTransactionDetail.ProductID;
                        oBarcodeRow.Barcode = oProductBarcode.ProductSerialNo;

                        oDSProductTransaction.Barcode.AddBarcodeRow(oBarcodeRow);                       
                    }          
                   
                }
                oDSProductTransaction.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSProductTransaction;
        }
        public DSISGM POSCancelAuthorizeISGM(DSProductTransaction oDSProductTransaction,DSISGM oDSISGM, int nTranID)
        {
          
            try
            {
                DBController.Instance.BeginNewTransaction();

                _TranID = nTranID;
                ProductTransactionDetail oProductTransactionDetail = new ProductTransactionDetail();
                oProductTransactionDetail.TranID = _TranID;
                oProductTransactionDetail.Delete();
                Delete();

                _TranNo = oDSProductTransaction.ProductStockTran[0].TranNo;
                _ToWHID = int.Parse(oDSProductTransaction.ProductStockTran[0].ToWHId.ToString());
                _ToChannelID = int.Parse(oDSProductTransaction.ProductStockTran[0].ToChannelID.ToString());
                _FromWHID = int.Parse(oDSProductTransaction.ProductStockTran[0].FromWHId.ToString());
                _FromChannelID = int.Parse(oDSProductTransaction.ProductStockTran[0].FromChannelId.ToString());

                foreach (DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow in oDSProductTransaction.ProductStockTranItem)
                {
                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _FromWHID;
                    _oProductStock.ChannelID = _FromChannelID;
                    _oProductStock.ProductID = int.Parse(oProductStockTranItemRow.ProductID.ToString());
                    _oProductStock.Quantity = oProductStockTranItemRow.Qty;
                    _oProductStock.UpdateCurrentStock(true);

                    if (_oProductStock.Flag == false)
                    {
                        int tepm = int.Parse("Create Exceptions");
                    }
                    _oProductStock = new ProductStock();
                    _oProductStock.WarehouseID = _ToWHID;
                    _oProductStock.ChannelID = _ToChannelID;
                    _oProductStock.ProductID = int.Parse(oProductStockTranItemRow.ProductID.ToString());
                    _oProductStock.Quantity = oProductStockTranItemRow.Qty;
                    _oProductStock.UpdateCurrentStock(false);

                    if (_oProductStock.Flag == false)
                    {
                        int tepm = int.Parse("Create Exceptions");
                    }
                }
                foreach (DSProductTransaction.BarcodeRow oBarcodeRow in oDSProductTransaction.Barcode)
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.TranID = _TranID;
                    oProductBarcode.ProductId = oBarcodeRow.ProductID;
                    oProductBarcode.ProductSerialNo = oBarcodeRow.Barcode;                  
                    oProductBarcode.WarehouseID = _ToWHID;
                    oProductBarcode.RefTranNo = _TranNo;      

                    oProductBarcode.DeleteTranferProductSerial((int)Dictionary.BarcodeStatus.ISGM, _FromWHID);
                }

                ProductISGM oProductISGM = new ProductISGM();

                oProductISGM.ISGMID = oDSISGM.ProductISGM[0].ISGMID;
                oProductISGM.ISGMNo = oDSISGM.ProductISGM[0].ISGMNo;
                oProductISGM.Status = oDSISGM.ProductISGM[0].Status;

                oProductISGM.StatusUpdate();          
                
                DBController.Instance.CommitTransaction();

                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _TranNo;
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();
            }

            return oDSISGM;
        }
    
        #endregion

        #region Duty Calculation

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA, double _DutyLocalBalance)
        {
            oDutyTranVAT11KA = new DutyTran();

            oDutyTranVAT11KA.DutyTranDate = DateTime.Now;
            oDutyTranVAT11KA.WHID = _ToWHID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = _TranNo;
            oDutyTranVAT11KA.RefID = _TranID;
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11KA.Remarks = "";
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (ProductTransactionDetail oProductTransactionDetail in this)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oProductTransactionDetail.ProductID;
                    oDutyTranDetail.Qty = (int)oProductTransactionDetail.Qty;
                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                    oDutyTranDetail.DutyRate = _oProductDetail.Vat;

                    _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11,double _DutyImportBalance)
        {
            oDutyTranVAT11 = new DutyTran();

            oDutyTranVAT11.DutyTranDate = DateTime.Now;
            oDutyTranVAT11.WHID = _ToWHID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo =_TranNo;
            oDutyTranVAT11.RefID = _TranID;
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11.Remarks = "";
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED; 

            foreach (ProductTransactionDetail oProductTransactionDetail in this)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oProductTransactionDetail.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oProductTransactionDetail.ProductID;
                    oDutyTranDetail.Qty = (int)oProductTransactionDetail.Qty;
                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2, MidpointRounding.AwayFromZero);
                    oDutyTranDetail.DutyRate = _oProductDetail.Vat;

                    _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;
            return oDutyTranVAT11;
        }

        #endregion
    }

    public class ProductTransactions : CollectionBase
    {
        public ProductTransaction this[int i]
        {
            get { return (ProductTransaction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductTransaction oProductTransaction)
        {
            InnerList.Add(oProductTransaction);
        }

        public void Refersh(DateTime dtFromDate,DateTime dtTodate,string sTranNo,int WarehouseId,int nTarnTypeId)
        {
            InnerList.Clear();
            dtTodate = dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ProductStockTran where TranDate  between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and TranTypeID='" + nTarnTypeId + "' ";

            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " and TranNo like '" + sTranNo + "'";
            }
            if (WarehouseId != -1)
            {

                sSql = sSql + " and ToWHID = '" + WarehouseId + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;               
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransaction _oProductTransaction = new ProductTransaction();

                    _oProductTransaction.TranID = int.Parse(reader["TranID"].ToString());
                    if (reader["POID"] != DBNull.Value)
                    {
                        _oProductTransaction.POID = int.Parse(reader["POID"].ToString());
                    }
                    else _oProductTransaction.POID = -1;

                    _oProductTransaction.TranNo = reader["TranNo"].ToString();
                    _oProductTransaction.TranDate = Convert.ToDateTime( reader["TranDate"]);
                    _oProductTransaction.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oProductTransaction.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _oProductTransaction.ToChannelID = int.Parse(reader["ToChannelID"].ToString());
                    _oProductTransaction.Channel.ChannelID = _oProductTransaction.ToChannelID;
                    _oProductTransaction.Channel.Refresh();
                    _oProductTransaction.Remarks = reader["Remarks"].ToString();
                    _oProductTransaction.Warehouse.WarehouseID = _oProductTransaction.ToWHID;
                    _oProductTransaction.Warehouse.Reresh();
                    
                    InnerList.Add(_oProductTransaction);
                    
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetTransaction(DateTime dtFromDate, DateTime dtTodate, string sTranNo, int nFromWarehouseId, int nToWarehouseId,int nType,int nTranTypeID,int nTranSide)
        {
            InnerList.Clear();
            dtTodate = dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == 1)
            {
                sSql = "Select a.*,TranTypeName,TransactionSide,c.WarehouseName+' ['+c.WarehouseCode+']' as FromWHName,d.WarehouseName+' ['+d.WarehouseCode+']' as ToWHName  " +
                    "From t_ProductStockTran a,t_ProductStockTranType b,t_Warehouse c,t_Warehouse d where a.TranTypeID=b.TranTypeID and a.FromWHID=c.WarehouseID and a.ToWHID=d.WarehouseID  " +
                    "and TranDate  between '"+ dtFromDate + "' and '"+ dtTodate + "' and TranDate < '"+ dtTodate + "' and a.TranTypeID='" + (int)Dictionary.ProductTransaction.TRANSFER + "' and FromWHID<>90";
            }
            else if (nType == 2)
            {
                sSql = "Select a.*,TranTypeName,TransactionSide,c.WarehouseName+' ['+c.WarehouseCode+']' as FromWHName,d.WarehouseName+' ['+d.WarehouseCode+']' as ToWHName  " +
                        "From t_ProductStockTran a,t_ProductStockTranType b,t_Warehouse c,t_Warehouse d where a.TranTypeID=b.TranTypeID and a.FromWHID=c.WarehouseID and a.ToWHID=d.WarehouseID  " +
                        "and TranDate  between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and a.TranTypeID not in (1,3,5)";
            }
            if (nType == 3)
            {
                sSql = "Select a.*,TranTypeName,TransactionSide,c.WarehouseName+' ['+c.WarehouseCode+']' as FromWHName,d.WarehouseName+' ['+d.WarehouseCode+']' as ToWHName  " +
                    "From t_ProductStockTran a,t_ProductStockTranType b,t_Warehouse c,t_Warehouse d where a.TranTypeID=b.TranTypeID and a.FromWHID=c.WarehouseID and a.ToWHID=d.WarehouseID  " +
                    "and TranDate  between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and a.TranTypeID='" + (int)Dictionary.ProductTransaction.TRANSFER + "' and FromWHID=90";
            }

            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " and TranNo like '" + sTranNo + "'";
            }
            if (nFromWarehouseId != -1)
            {

                sSql = sSql + " and FromWHID = '" + nFromWarehouseId + "'";
            }

            if (nTranTypeID != -1)
            {

                sSql = sSql + " and a.TranTypeID = '" + nTranTypeID + "'";
            }

            if (nToWarehouseId != -1)
            {

                sSql = sSql + " and ToWHID = '" + nToWarehouseId + "'";
            }

            if (nTranSide != -1)
            {

                sSql = sSql + " and TransactionSide = '" + nTranSide + "'";
            }

            //string sSql = "Set DateFormat dmy select * from t_productstocktran where TranDate  between '12-Aug-2012' and '26-Aug-2012' and fromwhid=70 and towhid in ( select warehouseid from t_warehouse where warehouseparentid=7)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransaction _oProductTransaction = new ProductTransaction();

                    _oProductTransaction.TranID = int.Parse(reader["TranID"].ToString());
                    if (reader["POID"] != DBNull.Value)
                    {
                        _oProductTransaction.POID = int.Parse(reader["POID"].ToString());
                    }
                    else _oProductTransaction.POID = -1;

                    _oProductTransaction.TranNo = reader["TranNo"].ToString();
                    _oProductTransaction.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _oProductTransaction.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oProductTransaction.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _oProductTransaction.ToChannelID = int.Parse(reader["ToChannelID"].ToString());
                    _oProductTransaction.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _oProductTransaction.FromChannelID = int.Parse(reader["FromChannelID"].ToString());
                    _oProductTransaction.Remarks = reader["Remarks"].ToString();
                    _oProductTransaction.TranTypeName = reader["TranTypeName"].ToString();
                    _oProductTransaction.TransactionSide = Enum.GetName(typeof(Dictionary.TranSide), int.Parse(reader["TransactionSide"].ToString()));
                    _oProductTransaction.FromWHName = reader["FromWHName"].ToString();
                    _oProductTransaction.ToWHName = reader["ToWHName"].ToString();

                    InnerList.Add(_oProductTransaction);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }      

        ///
        // Get Data from Cassiopeia for product transaction transfer (requisition in Cassiopeia)
        ///
        public void GetTransactionFromCassiopeia(DateTime dtpFrom, DateTime dtpTo)
        {
            InnerList.Clear();         
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sCmdString = string.Empty;
            string sFilterString = string.Empty;         

            sCmdString = "Select srTranID,Tranno,TranDate,Fromwhcode,ToWHCode,a.Remark,TranName,b.warehouseid as FromWHID,c.warehouseid as TOWHID   " +
                        "from   " +
                        "(   " +
                        "select srTranID,RefNo as Tranno,TranDate, '14' as Fromwhcode, srr.warehouseid as ToWHCode,(Tranno+';'+isnull(remark,'')) as remark, tt.name as tranname    " +
                        "from    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.srtran where trandate between  " +
                        "'" + dtpFrom.ToShortDateString() + "' and '" + dtpTo.AddDays(1).ToShortDateString() + "' and trandate < '" + dtpTo.AddDays(1).ToShortDateString() + "'  and trantypeid in (5)     " +
                        ") as st   " +
                        "left outer join    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.showroom    " +
                        ") as sr on st.showroomid = sr.showroomid    " +
                        "left outer join    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.showroom    " +
                        ") as srr on st.refshowroomid = srr.showroomid    " +
                        "left outer join    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.srtrantype    " +
                        ") as tt on st.trantypeid = tt.trantypeid   " +
                        ") as a   " +
                        "inner join   " +
                        "(   " +
                        "Select * from telsysdb.dbo.t_warehouse   " +
                        ") as b on a.Fromwhcode = b.warehousecode   " +
                        "inner join   " +
                        "(   " +
                        "Select * from telsysdb.dbo.t_warehouse   " +
                        ") as c on a.ToWHCode = c.warehousecode ";

            //"where tranno not in (Select tranno from telsysdb.dbo.t_productstocktran)";

            sFilterString = " order by srTranID";

            sCmdString = sCmdString + sFilterString;

            try
            {
                cmd.CommandText = sCmdString;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransaction oProductTransaction = new ProductTransaction();

                    oProductTransaction.TranID = (int)reader["SRTranID"];
                    oProductTransaction.TranNo = (string)reader["TranNo"];
                    oProductTransaction.TranDate = (DateTime)reader["TranDate"];
                    oProductTransaction.FromWHID = (int)reader["FromWHID"];
                    oProductTransaction.ToWHID = (int)reader["ToWHID"];
                    oProductTransaction.TranTypeName = (string)reader["tranname"];
                    if (reader["Remark"].ToString() != "")
                    {
                        oProductTransaction.Remarks = (string)reader["Remark"];
                    }
                    else
                    {
                        oProductTransaction.Remarks = "N/A";
                    }
                    oProductTransaction.RefreshItemDetailFromCassiopeia();

                    oProductTransaction.ProductBarcodes.GetBarcodeFromCassiopeia(oProductTransaction.TranID);

                    InnerList.Add(oProductTransaction);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetTransactionByTranID(int nTranID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ProductStockTran Where TranID=? ";
            cmd.Parameters.AddWithValue("TranID", nTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductTransaction _oProductTransaction = new ProductTransaction();

                    _oProductTransaction.TranID = int.Parse(reader["TranID"].ToString());
                    _oProductTransaction.TranNo = reader["TranNo"].ToString();
                    _oProductTransaction.TranDate = Convert.ToDateTime(reader["TranDate"]);

                    _oProductTransaction.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    _oProductTransaction.LastUpdateDate = Convert.ToDateTime(reader["LastUpdateDate"]);

                    _oProductTransaction.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oProductTransaction.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _oProductTransaction.ToChannelID = int.Parse(reader["ToChannelID"].ToString());
                    _oProductTransaction.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _oProductTransaction.FromChannelID = int.Parse(reader["FromChannelID"].ToString());
                    _oProductTransaction.UserID = int.Parse(reader["UserID"].ToString());
                    _oProductTransaction.Remarks = reader["Remarks"].ToString();

                    //_oProductTransaction.RefreshItem();

                    InnerList.Add(_oProductTransaction);

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
