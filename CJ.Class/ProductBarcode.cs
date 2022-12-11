// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: February 20, 2011
// Time :  10:00 AM
// Description: Class for Generat Produnct Barcode
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class
{
    public class ProductBarcode
    {
        private string _sTranNo;
        private DateTime _dTranDate;
        private string _sFromDate;
        private string _sToDate;
        private int _nTranId;
        private int _nProdunctId;
        private int _nIsBarcodeCount;
        private int _nWarehouseID;
        private long _nQty;
        private long _nInitialBarcode;
        private string _sTranNoStatus;
        private string _sProductCode;
        private string _sProductName;     
        private bool _bFound;
        private int _nIsActive;
        private int _nIsDownload;
        private int _nPGID;

        private int _TranID;     
        private int _SerialNo;
        private string _ProductSerialNo;
        private DateTime _EntryDate;
        private int _EntryUserID;
        private DateTime _UpdateDate;
        private int _UpdateUserID;
        private int _nStatus;
        private int _nIsTransitStock;
        private string _sRefTranNo;
        private string _sCompany;

        private int _nIsTranNoCount;
        private string _sInvoiceNo;
        private object _dtInvoiceDate;
        private string _sBENo;
        private object _dBEDate;
        private string _SaleAfter;
        public int IsTransitStock
        {
            get { return _nIsTransitStock; }
            set { _nIsTransitStock = value; }
        }
        public string SaleAfter
        {
            get { return _SaleAfter; }
            set { _SaleAfter = value; }
        }
        public string BENo
        {
            get { return _sBENo; }
            set { _sBENo = value; }
        }
        public object BEDate
        {
            get { return _dBEDate; }
            set { _dBEDate = value; }
        }
        public object InvoiceDate
        {
            get { return _dtInvoiceDate; }
            set { _dtInvoiceDate = value; }
        }

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        /// <summary>
        /// Get set property for IsTranNoCount
        /// </summary>
        public int IsTranNoCount
        {
            get { return _nIsTranNoCount; }
            set { _nIsTranNoCount = value; }
        }

        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }

        /// <summary>
        /// Get set property for IsDownload
        /// </summary>
        public int IsDownload
        {
            get { return _nIsDownload; }
            set { _nIsDownload = value; }
        }


        /// <summary>
        /// Get set property for IsBarcodeCount
        /// </summary>
        public int IsBarcodeCount
        {
            get { return _nIsBarcodeCount; }
            set { _nIsBarcodeCount = value; }
        }


        /// <summary>
        /// Get set property for Company
        /// </summary>
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
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


        private object _TP;
        public object TP
        {
            get { return _TP; }
            set { _TP = value; }
        }

        private object _VAT;
        public object VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        private object _TranType;
        public object TranType
        {
            get { return _TranType; }
            set { _TranType = value; }
        }
        private object _RefTranNo;
        public object sRefTranNo
        {
            get { return _RefTranNo; }
            set { _RefTranNo = value; }
        }
        private object _RefTranDate;
        public object RefTranDate
        {
            get { return _RefTranDate; }
            set { _RefTranDate = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        public string FromDate
        {
            get { return _sFromDate; }
            set { _sFromDate = value; }
        }
        public string ToDate
        {
            get { return _sToDate; }
            set { _sToDate = value; }
        }
        public int TranId
        {
            get { return _nTranId; }
            set { _nTranId = value; }
        }
        private int _IsVatPaidProduct;
        public int IsVatPaidProduct
        {
            get { return _IsVatPaidProduct; }
            set { _IsVatPaidProduct = value; }
        }

        private int _nPrintCount;
        public int PrintCount
        {
            get { return _nPrintCount; }
            set { _nPrintCount = value; }
        }
        public int ProductId
        {
            get { return _nProdunctId; }
            set { _nProdunctId = value; }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public long Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public long InitialBarcode
        {
            get { return _nInitialBarcode; }
            set { _nInitialBarcode = value; }
        }
        public string TranNoStatus
        {
            get { return _sTranNoStatus; }
            set { _sTranNoStatus = value; }
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
        public bool Found
        {
            get { return _bFound; }
            set { _bFound = value; }
        }
        public string RefTranNo
        {
            get { return _sRefTranNo; }
            set { _sRefTranNo = value; }
        }
        private int _nVatPaidID;
        public int VatPaidID
        {
            get { return _nVatPaidID; }
            set { _nVatPaidID = value; }
        }

        private int _nProductStockSerialHistoryID;
        public int ProductStockSerialHistoryID
        {
            get { return _nProductStockSerialHistoryID; }
            set { _nProductStockSerialHistoryID = value; }
        }
        private int _nProductStockSerialID;
        public int ProductStockSerialID
        {
            get { return _nProductStockSerialID; }
            set { _nProductStockSerialID = value; }
        }
        private int _nFromWHID;
        public int FromWHID
        {
            get { return _nFromWHID; }
            set { _nFromWHID = value; }
        }
        private int _nToWHID;
        public int ToWHID
        {
            get { return _nToWHID; }
            set { _nToWHID = value; }
        }

        private int _nInitialBarcodeAC;
        public int InitialBarcodeAC
        {
            get { return _nInitialBarcodeAC; }
            set { _nInitialBarcodeAC = value; }
        }

        private DateTime _dCreateDate;
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        private int _nProductStockTranID;
        public int ProductStockTranID
        {
            get { return _nProductStockTranID; }
            set { _nProductStockTranID = value; }
        }

        private int _nAGID;
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        private string _sAGName;
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }

        private int _nASGID;
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        private int _nBrandID;
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        private string _sBrandName;
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }

        private string _sType;
        public string Type
        {
            get { return _sType; }
            set { _sType = value; }
        }
        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }

        private int _nIsDefective;

        public int IsDefective
        {
            get { return _nIsDefective; }
            set { _nIsDefective = value; }
        }

        public void Add(int IsSystem)
        {
            int nInitialBarcode = 0;
            int nTranID = 0;
            int nInitialBarcodeAC = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InitialBarcode]) FROM t_ProductBarcode";
                cmd.CommandText = sSql;
                object maxBarcode = cmd.ExecuteScalar();
                if (maxBarcode == DBNull.Value)
                {
                    nInitialBarcode = 10666641;
                }
                else
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    nInitialBarcode = Convert.ToInt32(maxBarcode);
                    sSql = "SELECT [Qty] FROM t_ProductBarcode where InitialBarcode = '" + nInitialBarcode + "'";
                    cmd.CommandText = sSql;
                    object Qty = cmd.ExecuteScalar();
                    nInitialBarcode = nInitialBarcode + Convert.ToInt32(Qty);

                }
                _nInitialBarcode = nInitialBarcode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_ProductBarcode VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("InitialBarcode", _nInitialBarcode);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today);
                cmd.Parameters.AddWithValue("IsSystem", IsSystem);
                cmd.Parameters.AddWithValue("PrintDate", null);
                if (_sInvoiceNo != null)
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", null);
                }
                if (_dtInvoiceDate != null)
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }
                cmd.ExecuteNonQuery();

                for (long i = 0; i < _nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductSerialNo VALUES(?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ReferenceNo", _sTranNo);
                    cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                    cmd.Parameters.AddWithValue("WarrantyCardNo", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("ProductTransactionDate", DateTime.Today);

                    cmd.ExecuteNonQuery();
                }
                for (long i = 0; i < _nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductBarCodeDetail (WarehouseID, ProductID, Barcode, Status, IsActive, IsDownload,BENo,BEDate,Company,RefTranNo) VALUES(?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("WarehouseID", Utility.CentralRetailWarehouse);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("Barcode", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Create);
                    cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.BarcodeIsActive.Active);
                    cmd.Parameters.AddWithValue("IsDownload", 1);

                    cmd.Parameters.AddWithValue("BENo", _sBENo);
                    cmd.Parameters.AddWithValue("BEDate", _dBEDate);


                    cmd.Parameters.AddWithValue("Company", Utility.CompanyInfo);
                    try
                    {
                        cmd.Parameters.AddWithValue("RefTranNo", _sTranNo);
                    }
                    catch
                    {
                        cmd.Parameters.AddWithValue("RefTranNo", "");
                    }



                    cmd.ExecuteNonQuery();



                    if (_nPGID == 782)
                    {
                        sSql = "Select Right(Max(Barcode),6) From t_ProductBarcodeDetailAC";
                        cmd.CommandText = sSql;
                        object maxACBarcode = cmd.ExecuteScalar();
                        if (maxACBarcode == DBNull.Value)
                        {
                            nInitialBarcodeAC = 1;
                        }
                        else
                        {
                            nInitialBarcodeAC = Convert.ToInt32(maxACBarcode) + 1;
                        }
                        string sInitialBarcodeAC = "";
                        sInitialBarcodeAC = DateTime.Now.Year.ToString() + nInitialBarcodeAC.ToString("000000");

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();
                        sSql = "INSERT INTO t_ProductBarcodeDetailAC (CreateYear,TranNo,CreateDate,IsSystem,WarehouseID,ProductID, Barcode) VALUES(?,?,?,?,?,?,?)";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("CreateYear", DateTime.Now.Year);
                        cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                        cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("IsSystem", IsSystem);
                        cmd.Parameters.AddWithValue("WarehouseID", Utility.CentralRetailWarehouse);
                        cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                        cmd.Parameters.AddWithValue("Barcode", sInitialBarcodeAC);
                        
                        cmd.ExecuteNonQuery();
                    }



                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([TranID]) FROM t_ProductBarcodeTran";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nTranID = 1;
                    }
                    else
                    {
                        nTranID = Convert.ToInt32(maxID) + 1;
                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductBarcodeTran VALUES(?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("TranID", nTranID);
                    cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("FromWarehouse", (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                    cmd.Parameters.AddWithValue("ToWarehouse", Utility.CentralRetailWarehouse);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("Barcode", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("TranType", (int)Dictionary.BarcodeTranType.Create);
                    cmd.Parameters.AddWithValue("RefTranNo", null);                   


                    cmd.ExecuteNonQuery();
                }
                for (long i = 0; i < _nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO Cassiopeia_HO.dbo.ProdSerialLookup VALUES(?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("ReferenceNo", _sTranNo);
                    cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                    cmd.Parameters.AddWithValue("WarrantyCardNo", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("IsUsed", 0);
                    //cmd.Parameters.AddWithValue("ProductTransactionDate", DateTime.Today);

                    cmd.ExecuteNonQuery();
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddinGRD(int IsSystem,int _nStockTranID,int nTranWHID,string sStockTranNo)
        {
            int nInitialBarcode = 0;
            int nTranID = 0;
            int nInitialBarcodeAC = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InitialBarcode]) FROM t_ProductBarcode";
                cmd.CommandText = sSql;
                object maxBarcode = cmd.ExecuteScalar();
                if (maxBarcode == DBNull.Value)
                {
                    nInitialBarcode = 10666641;
                }
                else
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    nInitialBarcode = Convert.ToInt32(maxBarcode);
                    sSql = "SELECT [Qty] FROM t_ProductBarcode where InitialBarcode = '" + nInitialBarcode + "'";
                    cmd.CommandText = sSql;
                    object Qty = cmd.ExecuteScalar();
                    nInitialBarcode = nInitialBarcode + Convert.ToInt32(Qty);

                }
                _nInitialBarcode = nInitialBarcode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_ProductBarcode VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("InitialBarcode", _nInitialBarcode);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today);
                cmd.Parameters.AddWithValue("IsSystem", IsSystem);
                cmd.Parameters.AddWithValue("PrintDate", null);
                if (_sInvoiceNo != null)
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", null);
                }
                if (_dtInvoiceDate != null)
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }
                cmd.ExecuteNonQuery();

                for (long i = 0; i < _nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductSerialNo VALUES(?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ReferenceNo", _sTranNo);
                    cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                    cmd.Parameters.AddWithValue("WarrantyCardNo", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("ProductTransactionDate", DateTime.Today);

                    cmd.ExecuteNonQuery();
                }
                for (long i = 0; i < _nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductBarCodeDetail (WarehouseID, ProductID, Barcode, Status, IsActive, IsDownload,BENo,BEDate,Company,RefTranNo) VALUES(?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("WarehouseID", nTranWHID);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("Barcode", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Create);
                    cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.BarcodeIsActive.Active);
                    cmd.Parameters.AddWithValue("IsDownload", 1);

                    cmd.Parameters.AddWithValue("BENo", _sBENo);
                    cmd.Parameters.AddWithValue("BEDate", _dBEDate);


                    cmd.Parameters.AddWithValue("Company", Utility.CompanyInfo);
                    try
                    {
                        cmd.Parameters.AddWithValue("RefTranNo", sStockTranNo);
                    }
                    catch
                    {
                        cmd.Parameters.AddWithValue("RefTranNo", "");
                    }



                    cmd.ExecuteNonQuery();



                    ///// t_ProductTransferProductSerial
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "INSERT INTO t_ProductTransferProductSerial VALUES(?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("TranID", _nStockTranID);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("SerialNo", i);
                    cmd.Parameters.AddWithValue("ProductSerialNo", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                    cmd.Parameters.AddWithValue("WarehouseID", nTranWHID);
                    cmd.Parameters.AddWithValue("Status", null);

                    cmd.ExecuteNonQuery();
                    string sPreBarcode = "";
                    sPreBarcode = (nInitialBarcode + i).ToString(); ;

                    ////Delete t_ProductStockSerialHO
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Delete from  t_ProductStockSerialHO Where ProductSerialNo=? ";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ProductSerialNo", sPreBarcode);
                    cmd.ExecuteNonQuery();
                    
                    /////Add t_ProductStockSerialHO
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Insert Into t_ProductStockSerialHO (ProductStockTranID,WHID,ProductID,ProductSerialNo) values (?,?,?,?)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ProductStockTranID", _nStockTranID);
                    cmd.Parameters.AddWithValue("WHID", nTranWHID);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("ProductSerialNo", sPreBarcode);
                    cmd.ExecuteNonQuery();


                    if (_nPGID == 782)
                    {
                        sSql = "Select Right(Max(Barcode),6) From t_ProductBarcodeDetailAC";
                        cmd.CommandText = sSql;
                        object maxACBarcode = cmd.ExecuteScalar();
                        if (maxACBarcode == DBNull.Value)
                        {
                            nInitialBarcodeAC = 1;
                        }
                        else
                        {
                            nInitialBarcodeAC = Convert.ToInt32(maxACBarcode) + 1;
                        }
                        string sInitialBarcodeAC = "";
                        sInitialBarcodeAC = DateTime.Now.Year.ToString() + nInitialBarcodeAC.ToString("000000");

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();
                        sSql = "INSERT INTO t_ProductBarcodeDetailAC (CreateYear,TranNo,CreateDate,IsSystem,WarehouseID,ProductID, Barcode) VALUES(?,?,?,?,?,?,?)";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("CreateYear", DateTime.Now.Year);
                        cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                        cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("IsSystem", IsSystem);
                        cmd.Parameters.AddWithValue("WarehouseID", nTranWHID);
                        cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                        cmd.Parameters.AddWithValue("Barcode", sInitialBarcodeAC);

                        cmd.ExecuteNonQuery();
                    }



                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([TranID]) FROM t_ProductBarcodeTran";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nTranID = 1;
                    }
                    else
                    {
                        nTranID = Convert.ToInt32(maxID) + 1;
                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductBarcodeTran VALUES(?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("TranID", nTranID);
                    cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("FromWarehouse", (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                    cmd.Parameters.AddWithValue("ToWarehouse", nTranWHID);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("Barcode", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("TranType", (int)Dictionary.BarcodeTranType.Create);
                    cmd.Parameters.AddWithValue("RefTranNo", null);


                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddTML(int IsSystem)
        {
            int nInitialBarcode = 0;
            int nTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InitialBarcode]) FROM t_ProductBarcode";
                cmd.CommandText = sSql;
                object maxBarcode = cmd.ExecuteScalar();
                if (maxBarcode == DBNull.Value)
                {
                    nInitialBarcode = 1000000001;
                }
                else
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    nInitialBarcode = Convert.ToInt32(maxBarcode);
                    sSql = "SELECT [Qty] FROM t_ProductBarcode where InitialBarcode = '" + nInitialBarcode + "'";
                    cmd.CommandText = sSql;
                    object Qty = cmd.ExecuteScalar();
                    nInitialBarcode = nInitialBarcode + Convert.ToInt32(Qty);

                }
                _nInitialBarcode = nInitialBarcode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_ProductBarcode VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("InitialBarcode", _nInitialBarcode);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today);
                cmd.Parameters.AddWithValue("IsSystem", IsSystem);
                cmd.Parameters.AddWithValue("PrintDate", null);

                cmd.ExecuteNonQuery();


                for (long i = 0; i < _nQty; i++)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    sSql = "INSERT INTO t_ProductBarCodeDetail (WarehouseID, ProductID, Barcode, Status, IsActive, IsDownload) VALUES(?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("WarehouseID", Utility.CentralTMLWarehouse);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("Barcode", nInitialBarcode + i);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Create);
                    cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.BarcodeIsActive.Active);
                    cmd.Parameters.AddWithValue("IsDownload", 1);
                    
                    cmd.ExecuteNonQuery();

                }
                

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertTranferProductSerial(int nSatus,int nFromWarehouseID)
        {
            int nTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
          
            try
            {
                cmd.CommandText = "INSERT INTO  t_ProductTransferProductSerial VALUES(?,?,?,?,?,?,?,?,?,?)";              
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);
                cmd.Parameters.AddWithValue("SerialNo", null);
                cmd.Parameters.AddWithValue("ProductSerialNo",_ProductSerialNo);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("EntryUserID", _EntryUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", nSatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_ProductBarCodeDetail Set WarehouseID=?,Status=?,IsActive=? Where ProductID=? and Barcode=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", nSatus);
                cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.BarcodeIsActive.Active);
              
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

                cmd.ExecuteNonQuery();        


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();          
                cmd.CommandText = "SELECT MAX([TranID]) FROM t_ProductBarcodeTran"; 
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nTranID = 1;
                }
                else
                {
                    nTranID = Convert.ToInt32(maxID) + 1;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();     
                cmd.CommandText = "INSERT INTO t_ProductBarcodeTran VALUES(?,?,?,?,?,?,?,?)"; 
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("FromWarehouse", nFromWarehouseID);
                cmd.Parameters.AddWithValue("ToWarehouse", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                if (nSatus == (int)Dictionary.BarcodeStatus.ISGM)
                    cmd.Parameters.AddWithValue("TranType", (int)Dictionary.BarcodeTranType.ISGM);
                else cmd.Parameters.AddWithValue("TranType", (int)Dictionary.BarcodeTranType.Transfer);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);

                cmd.ExecuteNonQuery();    
                              
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertSalesInvoiceProductSerial()
        {
           OleDbCommand cmd = DBController.Instance.GetCommand();
           int nTranID = 0;
            try
            {
                cmd.CommandText = "INSERT INTO  t_SalesInvoiceProductSerial VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _TranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("SerialNo", null);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("EntryUserID", _EntryUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);             

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_ProductBarCodeDetail Set Status=? Where ProductID=? and Barcode=? and WarehouseID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Sale);

                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
               
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "SELECT MAX([TranID]) FROM t_ProductBarcodeTran";
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nTranID = 1;
                }
                else
                {
                    nTranID = Convert.ToInt32(maxID) + 1;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_ProductBarcodeTran VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("FromWarehouse", _nWarehouseID);
                cmd.Parameters.AddWithValue("ToWarehouse",(int)Dictionary.SystemWarehouse.SYS_WAREHOUSE);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                cmd.Parameters.AddWithValue("TranType", (int)Dictionary.BarcodeTranType.Sale);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertISGBarcode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "INSERT INTO t_ProductBarcode VALUES(?,?,?,?,?,?)";                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.ISGM);
                cmd.Parameters.AddWithValue("RefTranID", null);
                cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.BarcodeIsActive.Active);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public string GetProductCodeByBarcode(string sBarcode)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * from t_ProductSerialNo where WarrantyCardNo = ?";
            cmd.Parameters.AddWithValue("WarrantyCardNo", sBarcode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];
                    nCount++;
                }
                reader.Close();
                             
            }
            catch (Exception ex)
            {
                throw (ex);

            }

            if (nCount != 0) _bFound = true;
            else _bFound = false;

            return _sProductCode;

        }
        public void GetReatilBarcode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * from t_ProductBarcode where WarehouseID = ? and ProductID=? and Status=? and RefTranNo=?";

            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
            cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
            cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Sale);
            cmd.Parameters.AddWithValue("RefTranNo", _sTranNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (nCount == 0)
                        _ProductSerialNo = (string)reader["Barcode"];
                    else _ProductSerialNo = _ProductSerialNo + "," + (string)reader["Barcode"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);

            }           

        }
        public bool CheckBarcode(string sBarcode)
        {
            int nCount = 0;
            bool _bFlag=false;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * from Cassiopeia_HO.dbo.ProductSerial where Status= 2 and OutRefTranID is not null and OutRefTranItemID is not null and ShowroomID= 1 "
                          + " and SerialNo= ?";
            cmd.Parameters.AddWithValue("SerialNo", sBarcode);

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

            if (nCount != 0)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT * from Cassiopeia_HO.dbo.ProductSerial where Status= 1 and OutRefTranID is  null and OutRefTranItemID is  null and ShowroomID= 1 "
                              + " and SerialNo= ?";
                cmd.Parameters.AddWithValue("SerialNo", sBarcode);

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       _bFlag=true;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);

                }
                if (_bFlag)
                {
                    _bFlag = false;
                    return true;
                }
                else return false;
            }
            else return true;

           

        }
        public void DeleteProductSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "DELETE FROM t_ProductTransferProductSerial WHERE TranID=? AND ProductId=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);
            

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteProductSerialRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "DELETE FROM t_ProductStockSerialRT WHERE ProductSerialNo=? AND ProductId=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteVatPaidProductSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "DELETE FROM t_ProductStockSerialVatPaid WHERE ID=? AND WHID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nVatPaidID);
                cmd.Parameters.AddWithValue("WHID", _nWarehouseID);


                cmd.ExecuteNonQuery();
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
            try
            {
                cmd.CommandText = "Update t_ProductBarcode set RefTranNo=?,Status=?  where WarehouseID = ? and ProductID=? and  Barcode=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RefTranNo", _sTranNo);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Sale);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }

        public void UpdatePrintCount(string sBarcode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductBarcodeDetail set PrintCount=isnull(PrintCount,0)+1 where Barcode='" + sBarcode + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                OleDbCommand cmds = DBController.Instance.GetCommand();

                cmds.CommandText = "Update t_ProductBarcodeDetailAC set PrintCount=isnull(PrintCount,0)+1 where Barcode='" + sBarcode + "'";
                cmds.CommandType = CommandType.Text;

                cmds.ExecuteNonQuery();
                cmds.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void UpdateForReverseRetailInvoce()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductBarcode set Status=?  where WarehouseID = ? and ProductID=? and  Barcode=? and RefTranNo=?";
                cmd.CommandType = CommandType.Text;
             
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Transfer);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                cmd.Parameters.AddWithValue("RefTranNo",_sRefTranNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void EditForReverseRetailInvoce()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductBarcode set Status=?  where WarehouseID = ? and ProductID=? and  Barcode=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Transfer);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void UpdatePOSBarcode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductBarcode set IsActive=?  where WarehouseID = ? and ProductID=? and  Barcode=?";
                cmd.CommandType = CommandType.Text;
             
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeIsActive.NotActive);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
                
            }

        }
        public void UpdateForISGMS(int nActive)
        {
         
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductBarCodeDetail set IsActive=?  where WarehouseID = ? and ProductID=? and  Barcode=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsActive", nActive);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "SELECT MAX([TranID]) FROM t_ProductBarcodeTran";                
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nTranID = 1;
                //}
                //else
                //{
                //    nTranID = Convert.ToInt32(maxID) + 1;
                //}

                //cmd.Dispose();
                //cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "INSERT INTO t_ProductBarcodeTran VALUES(?,?,?,?,?,?,?,?)";                
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("TranID", nTranID);
                //cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                //cmd.Parameters.AddWithValue("FromWarehouse", nFromWHID);
                //cmd.Parameters.AddWithValue("ToWarehouse", nToWHID);
                //cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                //cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);
                //cmd.Parameters.AddWithValue("TranType", (int)Dictionary.BarcodeTranType.Request_For_ISGM);
                //cmd.Parameters.AddWithValue("RefTranNo", sTranNo);

                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void UpdateForISGMSSynch(int nActive)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                if (nActive == (int)Dictionary.BarcodeIsActive.Lock)
                {
                    cmd.CommandText = "Update t_ProductBarCode set IsActive=?,RefTranNo=? where WarehouseID = ? and ProductID=? and  Barcode=?";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsActive", nActive);
                    cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);

                    cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                    cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                    cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd.CommandText = "Update t_ProductBarCode set IsActive=? where RefTranNo=?";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsActive", nActive);

                    cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);                 

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void DeleteTranferProductSerial(int nSatus, int nFromWarehouseID)
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_ProductTransferProductSerial where TranID=? and ProductId=? and ProductSerialNo=? and WarehouseID=? and Status= ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("ProductId", _nProdunctId);          
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);          
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", nSatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_ProductBarCodeDetail Set WarehouseID=?,Status=?,IsActive=? Where ProductID=? and Barcode=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", nFromWarehouseID);
                cmd.Parameters.AddWithValue("Status", nSatus);
                cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.BarcodeIsActive.Active);

                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

                cmd.ExecuteNonQuery();
               
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_ProductBarcodeTran Where RefTranNo=?";
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertCassiopiaToCasperTranferProductSerial()
        {
         
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO TELSysDB.dbo.t_ProductTransferProductSerial ( TranID, ProductID, SerialNo, ProductSerialNo, EntryDate,EntryUserID,UpdateDate,UpdateUserID )   " +
                        "VALUES (?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("SerialNo", null);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("EntryDate", null);
                cmd.Parameters.AddWithValue("EntryUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertProductSerial()
        {
            int nMaxProductSerialID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([ProductSerialID]) FROM t_ProductStockSerial";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductSerialID = 1;
                }
                else
                {
                    nMaxProductSerialID = Convert.ToInt32(maxID) + 1;
                }
                _nProductStockSerialID = nMaxProductSerialID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockSerial (ProductSerialID,ProductStockTranID,ProductID,ProductSerialNo,Status) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductSerialID", _nProductStockSerialID);
                cmd.Parameters.AddWithValue("ProductStockTranID", _nProductStockTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void InsertProductSerialNewVatData()
        {
            int nMaxProductSerialID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([ProductSerialID]) FROM t_ProductStockSerial";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductSerialID = 1;
                }
                else
                {
                    nMaxProductSerialID = Convert.ToInt32(maxID) + 1;
                }
                _nProductStockSerialID = nMaxProductSerialID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockSerial (ProductSerialID,ProductStockTranID,ProductID,ProductSerialNo,Status,IsVatPaidProduct) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductSerialID", _nProductStockSerialID);
                cmd.Parameters.AddWithValue("ProductStockTranID", _nProductStockTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsVatPaidProduct", _IsVatPaidProduct);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }

        public void InsertProductSerialWithVatData()
        {
            int nMaxProductSerialID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([ProductSerialID]) FROM t_ProductStockSerial";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductSerialID = 1;
                }
                else
                {
                    nMaxProductSerialID = Convert.ToInt32(maxID) + 1;
                }
                _nProductStockSerialID = nMaxProductSerialID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockSerial (ProductSerialID,ProductStockTranID,ProductID,ProductSerialNo,Status,IsVatPaidProduct) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductSerialID", _nProductStockSerialID);
                cmd.Parameters.AddWithValue("ProductStockTranID", _nProductStockTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsVatPaidProduct", _IsVatPaidProduct);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        
        public void InsertProductSerialRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {               
                cmd.CommandText = "INSERT INTO t_ProductStockSerialRT (ProductStockTranID,ProductID,ProductSerialNo,Status,IsTransitStock) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductStockTranID", _nProductStockTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsTransitStock", _nIsTransitStock);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public bool UpdateProductSerial()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductStockSerial SET Status=? Where ProductSerialNo=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public bool UpdateProductSerialRT()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductStockSerialRT SET Status=?,IsTransitStock=? Where ProductSerialNo=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsTransitStock", _nIsTransitStock);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public bool UpdateProductSerialWithVatData()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductStockSerial SET Status=? Where ProductSerialNo=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }
        public void UpdateVatPaidProductSerial(int nWHID,double nTP,double nVAT,int nTranType,string sRefTranNo,DateTime _dtRefTranDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductStockSerialVatPaid set Status=?, TP =?, VAT=?, TranType=?, RefTranNo=?, RefTranDate = ? where ProductSerialNo=? and WHID=" + nWHID + " and ID=(Select max(ID) ID From t_ProductStockSerialVatPaid where ProductSerialNo='" + _ProductSerialNo + "' and WHID = " + nWHID + ")";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TP", nTP);
                cmd.Parameters.AddWithValue("VAT", nVAT);
                cmd.Parameters.AddWithValue("TranType", nTranType);
                cmd.Parameters.AddWithValue("RefTranNo", sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dtRefTranDate);

                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }

        public void UpdateVatPaidProductSerialForReq(int nStatus,string sTranNo, DateTime _dTranDate,int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductStockSerialVatPaid set Status=?, TP =?, TranNo=?, TranDate = ? where ProductSerialNo=? and WHID=" + nWHID + "";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", nStatus);
                cmd.Parameters.AddWithValue("TranNo", sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);

                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        


        public void GetProductSerialID(string sProductSerialNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ProductSerialID from t_ProductStockSerial Where ProductSerialNo=?";
            cmd.Parameters.AddWithValue("ProductSerialNo", sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductStockSerialID = int.Parse(reader["ProductSerialID"].ToString());
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
                _bFound = true;
            }
            else
            {
                _bFound = false;
            }
        }

        public void GetProductSerialIDRT(string sProductSerialNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ProductSerialID from t_ProductStockSerialRT Where ProductSerialNo=?";
            cmd.Parameters.AddWithValue("ProductSerialNo", sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductStockSerialID = int.Parse(reader["ProductSerialID"].ToString());
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
                _bFound = true;
            }
            else
            {
                _bFound = false;
            }
        }
        public void GetProductSerialHitoryID(int nProductStockSerialID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select MAX (ProductStockSerialHistoryID) as ProductStockSerialHistoryID from t_ProductStockSerialHistory Where ProductStockSerialID=?";
            cmd.Parameters.AddWithValue("ProductStockSerialID", nProductStockSerialID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductStockSerialHistoryID = int.Parse(reader["ProductStockSerialHistoryID"].ToString());
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void InsertProductSerialHistory()
        {
            int nMaxStockHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ProductStockSerialHistoryID]) FROM t_ProductStockSerialHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxStockHistoryID = 1;
                }
                else
                {
                    nMaxStockHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nProductStockSerialHistoryID = nMaxStockHistoryID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductStockSerialHistory (ProductStockSerialHistoryID,ProductStockSerialID,FromWHID,ToWHID,Status,CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductStockSerialHistoryID", _nProductStockSerialHistoryID);
                cmd.Parameters.AddWithValue("ProductStockSerialID", _nProductStockSerialID);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void DeleteProductSerialHistory(int nProductStockSerialID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "DELETE FROM t_ProductStockSerialHistory WHERE ProductStockSerialID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductStockSerialID", nProductStockSerialID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteProductSerialHistoryByID(int nProductStockSerialHistoryID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "DELETE FROM t_ProductStockSerialHistory WHERE ProductStockSerialHistoryID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductStockSerialHistoryID", nProductStockSerialHistoryID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(string sProductBarcode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select TranNo,TranDate From t_ProductStockSerial a,t_PRoductStockTran b " +
                                  " where a.ProductStockTranID=b.TranID and ProductSerialNo = ? ";

                cmd.Parameters.AddWithValue("ProductSerialNo", sProductBarcode);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshforRT(string sProductBarcode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select TranNo,TranDate From t_ProductStockSerialRT a,t_ProductStockTran b " +
                                  " where a.ProductStockTranID=b.TranID and ProductSerialNo = ? ";

                cmd.Parameters.AddWithValue("ProductSerialNo", sProductBarcode);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshForDefective()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            try
            {
                cmd.CommandText = " Select a.ProductID,a.ProductSerialNo,isnull(IsDefective,0) IsDefective From  " +
                                   " ( Select * From t_ProductStockSerial where Status=1 ) a Left Outer Join  " +
                                    " ( Select *,1 as IsDefective From t_UnsoldDefectiveProduct where Status in (" + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Assessed + "," + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Discount_Approved + ")) b " +
                                    " on a.ProductID=b.ProductID and a.ProductSerialNo=b.BarcodeSL where ProductSerialNo=? and a.ProductID=?";

                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _nProdunctId);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nIsDefective = Convert.ToInt32(reader["IsDefective"].ToString());

                }
                reader.Close();
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

        public void InsertTELHQ(long nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_ProductTransferProductSerial VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
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

        public void InsertHOStockSerial(long nTranID, int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "insert into t_ProductStockSerialHO (ProductStockTranID,WHID,ProductID,ProductSerialNo) values (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductStockTranID", nTranID);
                cmd.Parameters.AddWithValue("WHID", nWHID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Shuvo 05-Dec-2015
        /// </summary>
        public void AddPSL(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (IsTrue)
                {
                    sSql = "INSERT INTO t_ProductBarCodeDetail (WarehouseID, ProductID, Barcode, Status, IsActive, IsDownload, Company, RefTranNo,BENo,BEDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                 cmd.Parameters.AddWithValue("WarehouseID",  _nWarehouseID);
                 cmd.Parameters.AddWithValue("ProductID",  _nProdunctId);
                 cmd.Parameters.AddWithValue("Barcode",  _ProductSerialNo);
                 cmd.Parameters.AddWithValue("Status",  _nStatus);
                 cmd.Parameters.AddWithValue("IsActive",  _nIsActive);
                 cmd.Parameters.AddWithValue("IsDownload",  _nIsDownload);
                 cmd.Parameters.AddWithValue("Company",  _sCompany);
                 cmd.Parameters.AddWithValue("RefTranNo",  _sRefTranNo);


                cmd.Parameters.AddWithValue("BENo", _sBENo);
                cmd.Parameters.AddWithValue("BEDate", _dBEDate);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdatePSL(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (IsTrue)
                {
                    sSql = "Update t_ProductBarCodeDetail set  WarehouseID=?, ProductID=?, Company=?, RefTranNo=? where Barcode =?";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddProductSerial(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (IsTrue)
                {
                    sSql = "INSERT INTO t_ProductTransferProductSerial (TranID, ProductID, SerialNo, ProductSerialNo, EntryDate, EntryUserID,  UpdateDate, UpdateUserID, WarehouseID,Status) VALUES(?,?,?,?,?,?,?,?,?,?)";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranId);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("SerialNo", null);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("WarehouseID", null);
                cmd.Parameters.AddWithValue("Status", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckProductSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select Count(Barcode) as IsBarcodeCount  From t_ProductBarcodeDetail where Barcode = ? ";

            //cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
            cmd.Parameters.AddWithValue("Barcode", _ProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_ProductSerialNo = (string)reader["Barcode"];
                    _nIsBarcodeCount = int.Parse(reader["IsBarcodeCount"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void CheckTranNo(string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " Select TranID,Count(TranNo) as IsTranNoCount From t_ProductStockTran where TranNo = ? "+
                          " group by TranID";

            cmd.Parameters.AddWithValue("TranNo", sTranNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nTranId = int.Parse(reader["TranID"].ToString());
                    _nIsTranNoCount = int.Parse(reader["IsTranNoCount"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void CheckProductSerialByTranID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select Count(ProductSerialNo) as IsBarcodeCount  From t_ProductTransferProductSerial  "+
                          " where ProductSerialNo = ? and TranID = ? ";

            cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
            cmd.Parameters.AddWithValue("TranID", _nTranId);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nIsBarcodeCount = int.Parse(reader["IsBarcodeCount"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int GetMaxID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nID = 0;
            string sSql = "Select isnull(MAX(ID),0)+1 ID From [t_ProductStockSerialVatPaid]";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nID = int.Parse(reader["ID"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;

        }

        #region Web Service Functions

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public DSBarcodeDetail POSBarcodeValidation(DSBarcodeDetail oDSBarcodeDetail)
        {
            int i = 0;          
            bool _bError = false;
            string sErrorMsg = "";
            foreach (DSBarcodeDetail.BarcodeDetailRow oBarcodeDetailRow in oDSBarcodeDetail.BarcodeDetail)
            {
                try
                {
                    oDSBarcodeDetail.BarcodeDetail[i].ProductCode = GetProductCodeByBarcode(oDSBarcodeDetail.BarcodeDetail[i].Barcode);
                    if (CheckBarcode(oDSBarcodeDetail.BarcodeDetail[i].Barcode))
                    {
                    }
                    else
                    {
                        if (sErrorMsg == "")
                            sErrorMsg = oDSBarcodeDetail.BarcodeDetail[i].Barcode;
                        else sErrorMsg = "," + oDSBarcodeDetail.BarcodeDetail[i].Barcode;
                        _bError = true;
                    }
                }
                catch(Exception ex)
                {
                    oDSBarcodeDetail.BarcodeDetail[i].Result = ex.Message;
                    return oDSBarcodeDetail;
                }
                oBarcodeDetailRow.Check = "0";

                if (_bFound == false)
                {
                    if (sErrorMsg == "")
                        sErrorMsg = oDSBarcodeDetail.BarcodeDetail[i].Barcode;
                    else sErrorMsg = "," + oDSBarcodeDetail.BarcodeDetail[i].Barcode;
                    _bError = true;
                }
                if (_bError == true)
                {
                    oDSBarcodeDetail.BarcodeDetail[i].Result = sErrorMsg;

                    _bError = false;
                  
                }
                else oDSBarcodeDetail.BarcodeDetail[i].Result = "1";

                i++;

            }
           

            return oDSBarcodeDetail;
        }
        #endregion


        public void InsertVatPaidProductSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "INSERT INTO t_ProductStockSerialVatPaid (ID,ProductID,WHID,ProductSerialNo,TranNo,TranDate,Status,TP,VAT,TranType,RefTranNo,RefTranDate) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nVatPaidID);
                cmd.Parameters.AddWithValue("ProductID", _nProdunctId);
                cmd.Parameters.AddWithValue("WHID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _ProductSerialNo);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);


                if (_TP != null)
                {
                    cmd.Parameters.AddWithValue("TP", _TP);
                }
                {
                    cmd.Parameters.AddWithValue("TP", null);
                }

                if (_VAT != null)
                {
                    cmd.Parameters.AddWithValue("VAT", _VAT);
                }
                {
                    cmd.Parameters.AddWithValue("VAT", null);
                }


                if (_TranType != null)
                {
                    cmd.Parameters.AddWithValue("TranType", _TranType);
                }
                {
                    cmd.Parameters.AddWithValue("TranType", null);
                }


                if (_RefTranNo != null)
                {
                    cmd.Parameters.AddWithValue("RefTranNo", _RefTranNo);
                }
                {
                    cmd.Parameters.AddWithValue("RefTranNo", null);
                }

                if (_RefTranDate != null)
                {
                    cmd.Parameters.AddWithValue("RefTranDate", _RefTranDate);
                }
                {
                    cmd.Parameters.AddWithValue("RefTranDate", null);
                }



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public int GetVatPaidBarcode(string sBarcode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nIsVatPaidProduct = 0;
            string sSql = "Select count(ProductSerialNo) IsVatPaidProduct  " +
                        "From(  " +
                        "Select distinct ProductSerialNo From t_ProductStockSerialVatPaid) A  " +
                        "where ProductSerialNo in ('" + sBarcode + "')";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nIsVatPaidProduct = int.Parse(reader["IsVatPaidProduct"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nIsVatPaidProduct;

        }


    }
    public class ProductBarcodes : CollectionBase
    {

        public int GetIndex(int nProductStockSerialID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductStockSerialID == nProductStockSerialID)
                {
                    return i;
                }
            }
            return -1;
        }


        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public ProductBarcode this[int i]
        {
            get { return (ProductBarcode)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductBarcode oProductBarcode)
        {
            InnerList.Add(oProductBarcode);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ProductStockSerial ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductId = (int)reader["ProductID"];
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }



        }
        public ProductBarcodes GetData(DateTime sFromDate, DateTime sToDate,string sTranno)
        {
            int flag = 0;
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();           

            string sSql = "SELECT * FROM t_ProductStockTran where TranTypeID=1 And TranDate between '" + sFromDate + "' and '" + sToDate + "' and TranNo not like '%PSL%'";

            if (sTranno != "")            
            {
                sTranno = "%" + sTranno + "%";
                sSql =  sSql + "and TranNo like '" + sTranno + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.TranId = (int)reader["TranID"];
                    oProductBarcode.TranNo = (string)reader["TranNo"];
                    oProductBarcode.TranDate = (DateTime)reader["TranDate"];

                    sSql = "SELECT InitialBarcode FROM t_ProductBarcode WHERE TranNo='" + (string)reader["TranNo"] + "'";
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader testreader = cmd.ExecuteReader();
                    while (testreader.Read())
                    {
                        flag++;
                    }
                    if (flag == 0)
                    {
                        oProductBarcode.TranNoStatus = "Not Generate";
                    }
                    else
                    {
                        oProductBarcode.TranNoStatus = "Generate";
                        flag = 0;
                    }
                    testreader.Close();
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }
        public ProductBarcodes GetProductInfo(int nTranId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ProductID,ProductCode,ProductName,PGID,Qty,ToWHID  " +
                        "From t_ProductStockTranItem a,v_ProductDetails b,t_ProductStockTran c   " +
                        "where a.ProductID=b.ProductID and a.TranID=c.TranID and a.TranID=" + nTranId + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductId = (int)reader["ProductID"];
                    oProductBarcode.ProductCode = (string)reader["ProductCode"];
                    oProductBarcode.Qty = long.Parse(reader["Qty"].ToString());
                    oProductBarcode.PGID = (int)reader["PGID"];
                    oProductBarcode.ToWHID = (int)reader["ToWHID"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }
        public ProductBarcodes CheckTranNo(string nTranNo)
        {
            int nflag = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            ProductBarcode oProductBarcode = new ProductBarcode();
            string sSql = "SELECT * FROM t_ProductBarcode where TranNo = '" + nTranNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nflag++;
                }
                if (nflag == 0)
                {

                    _bFlag = true;
                }
                else
                {
                    _bFlag = false;
                    nflag = 0;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }       
        public string GetTranNo()
        {
            long nManualStartingTranNo = 0;
            string sManualTranNo = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {   
                sSql = "select count(p.test) from (select distinct TranNo as test from dbo.t_ProductBarcode where TranNo like 'EX%'and IsSystem='0') as p";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                object noCount = cmd.ExecuteScalar();
                if (Convert.ToInt32(noCount) == 0)
                {
                    nManualStartingTranNo = 100001;
                }
                else
                {
                    nManualStartingTranNo = Convert.ToInt32(noCount) + 100001;

                }
                sManualTranNo = "EX" + nManualStartingTranNo;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sManualTranNo;
        }
        public ProductBarcodes GetRefNos(DateTime dtformdate, DateTime dttodate, int cbbarcodetype, string txtrefno, bool IsChecked)
        {
            DateTime FromDate = dtformdate.Date;
            DateTime ToDate = dttodate.Date.AddDays(1);
            string sTranNo = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (IsChecked == true)
            {
                sSql = "SELECT Distinct TranNo,EntryDate FROM t_ProductBarcode where TranNo <> '0' ";
            }
            else
            {
                sSql = "SELECT Distinct TranNo,EntryDate FROM t_ProductBarcode where EntryDate between ? and ? and EntryDate < ? ";
            }
            //string sSql = "SELECT Distinct TranNo,EntryDate FROM t_ProductBarcode where EntryDate between '" + dtformdate + "'and '" + dttodate + "'  ";

            cmd.Parameters.AddWithValue("EntryDate", FromDate);
            cmd.Parameters.AddWithValue("EntryDate", ToDate);
            cmd.Parameters.AddWithValue("EntryDate", ToDate);

            if (txtrefno != "")
            {
                sTranNo = "%" + txtrefno + "%";
                sSql = sSql + " and TranNo like '" + sTranNo + "'  ";
            }            
            if (cbbarcodetype > -1)
            {
                sSql = sSql + " and IsSystem='" + cbbarcodetype + "'" ;
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.TranNo = (string)reader["TranNo"];
                    oProductBarcode.TranDate = (DateTime)reader["EntryDate"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
                
            }
            return this;
        }
        public ProductBarcodes GetBarcodeInfo(string TranNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT t_ProductBarcode.TranNo,t_ProductBarcode.ProductID, t_ProductBarcode.Qty,t_ProductBarcode.InitialBarcode,t_Product.ProductCode,t_Product.ProductName FROM t_ProductBarcode inner join t_Product on t_Product.ProductID=t_ProductBarcode.ProductID and t_ProductBarcode.TranNo= '" + TranNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.TranNo = (string)reader["TranNo"];
                    oProductBarcode.ProductId = (int)reader["ProductId"];
                    oProductBarcode.Qty = long.Parse(reader["Qty"].ToString());
                    oProductBarcode.InitialBarcode = long.Parse(reader["InitialBarcode"].ToString());   
                    oProductBarcode.ProductCode = (string)reader["ProductCode"];
                    oProductBarcode.ProductName = (string)reader["ProductName"];
                                     
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return this;
        }


        public void GetAllBarcodeByGRD(string sTranNo,string sProductCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select TranNo,a.ProductID,ProductCode,ProductName,Barcode,PrintCount From  " +
                           "(  " +
                           "select SL,TranNo,b.ProductID,Barcode,isnull(PrintCount,0) PrintCount from   " +
                           "(  " +
                           "select 1 as SL,TranNo,productID,Qty,InitialBarcode as StartBarcode,  " +
                           "(InitialBarcode+Qty-1) as EndBarcode from dbo.t_ProductBarcode  " +
                           ") a,t_ProductBarCodeDetail b   " +
                           "Where cast(b.Barcode as varchar) between cast(a.StartBarcode as varchar) and cast(a.EndBarcode as varchar) and a.ProductID=b.ProductID  " +
                           "and TranNo='" + sTranNo + "'  " +
                           "Union All  " +
                           "Select 2 as SL,TranNo,ProductID,Barcode,isnull(PrintCount,0) PrintCount From t_ProductBarcodeDetailAC where TranNo='" + sTranNo + "'  " +
                           ") a,t_Product b  " +
                           "where a.ProductID=b.ProductID";
                           
            }

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }
            sSql = sSql + " order by SL,a.ProductID,Barcode";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.TranNo = (string)reader["TranNo"];
                    oProductBarcode.ProductId = (int)reader["ProductID"];
                    oProductBarcode.ProductCode = (string)reader["ProductCode"];
                    oProductBarcode.ProductName = (string)reader["ProductName"];
                    oProductBarcode.ProductSerialNo = (string)reader["Barcode"];
                    oProductBarcode.PrintCount = (int)reader["PrintCount"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        public void GetBarcodeForPOS(int nTranID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT * FROM  t_ProductTransferProductSerial WHERE TranID =? and ProductId=?";
            cmd.Parameters.AddWithValue("TranID", nTranID);
            cmd.Parameters.AddWithValue("ProductId", nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];                 

                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
           
        }
        public void GetProductBarcode(int nProductID, int nWarehouseID)
        {
            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "select A.ProductID,A.ProductSerialNo,A.Status,isnull(IsVatPaidProduct,0) IsVatPaidProduct,B.SaleAfter from t_ProductStockSerial A left join t_OutletDisplayPosition B on A.ProductID=B.ProductID and A.ProductSerialNo=B.ProductSerialNo and B.IsActive=1 where A.Status=? and A.ProductID = ?";
            string sSql = "select A.ProductID,A.ProductSerialNo,A.Status,  " +
                        "(case when IsVatPaidProduct is null then 0 else IsVatPaidProduct end) IsVatPaidProduct,B.SaleAfter,  " +
                        "(case when C.IsDefective is null then 0 else C.IsDefective end) IsDefective  " +
                        "from t_ProductStockSerial A   " +
                        "left outer join   " +
                        "t_OutletDisplayPosition B   " +
                        "on A.ProductID=B.ProductID and A.ProductSerialNo=B.ProductSerialNo and B.IsActive=1   " +
                        "left outer join   " +
                        "(  " +
                        "Select *,1 as IsDefective From t_UnsoldDefectiveProduct where Status in (" + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Assessed + "," + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Discount_Approved + ")  " +
                        ") c  " +
                        "on A.ProductID=c.ProductID and A.ProductSerialNo=c.BarcodeSL  " +
                        "where A.Status=? and A.ProductID = ?";

            cmd.Parameters.AddWithValue("Status", (int)Dictionary.ProductSerialStatus.Received_at_Outlet);
            cmd.Parameters.AddWithValue("ProductID", nProductID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    oProductBarcode.IsVatPaidProduct = (int)reader["IsVatPaidProduct"];
                    if (reader["SaleAfter"] != DBNull.Value)
                    {
                        oProductBarcode.SaleAfter = Convert.ToDateTime(reader["SaleAfter"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oProductBarcode.SaleAfter = "";
                    }

                    oProductBarcode.IsDefective = (int)reader["IsDefective"];

                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        public void GetProductBarcodeRT(int nProductID, int nWarehouseID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select A.ProductID,A.ProductSerialNo,A.Status,isnull(a.IsTransitStock,0) IsTransitStock, " +
                        "(case when IsVatPaidProduct is null then 0 else IsVatPaidProduct end) IsVatPaidProduct,c.SaleAfter,  " +
                        "(case when d.IsDefective is null then 0 else d.IsDefective end) IsDefective  From t_ProductStockSerialRT a  " +
                        "inner join t_ProductStockTran b on a.ProductStockTranID=b.TranID  " +
                        "left outer join (Select * From t_OutletDisplayPosition where IsActive=1 and WHID=" + nWarehouseID + ") c on a.ProductID=c.ProductID and a.ProductSerialNo=c.ProductSerialNo " +
                        "left outer join   " +
                        "(  " +
                        "Select *,1 as IsDefective From t_UnsoldDefectiveProduct where WarehouseID=" + nWarehouseID + " " +
                        "and Status in (" + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Assessed + "," + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Discount_Approved + ")  " +
                        ") d  " +
                        "on a.ProductID=d.ProductID and A.ProductSerialNo=d.BarcodeSL  " +
                        "where b.ToWHID=" + nWarehouseID + " and A.Status=" + (int)Dictionary.ProductSerialStatus.Received_at_Outlet 
                        + " and A.ProductID = " + nProductID + "";
            


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    oProductBarcode.IsVatPaidProduct = (int)reader["IsVatPaidProduct"];
                    if (reader["SaleAfter"] != DBNull.Value)
                    {
                        oProductBarcode.SaleAfter = Convert.ToDateTime(reader["SaleAfter"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oProductBarcode.SaleAfter = "";
                    }

                    oProductBarcode.IsDefective = (int)reader["IsDefective"];
                    oProductBarcode.IsTransitStock = (int)reader["IsTransitStock"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        public void GetProductBarcodeforUDMRT(int nProductID, int nWarehouseID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select A.ProductID,A.ProductSerialNo,A.Status, " +
                        "(case when IsVatPaidProduct is null then 0 else IsVatPaidProduct end) IsVatPaidProduct,c.SaleAfter,  " +
                        "(case when d.IsDefective is null then 0 else d.IsDefective end) IsDefective  From t_ProductStockSerialRT a  " +
                        "inner join t_ProductStockTran b on a.ProductStockTranID=b.TranID  " +
                        "left outer join (Select * From t_OutletDisplayPosition where IsActive=1 and WHID=" + nWarehouseID + ") c on a.ProductID=c.ProductID and a.ProductSerialNo=c.ProductSerialNo " +
                        "left outer join   " +
                        "(  " +
                        "Select *,1 as IsDefective From t_UnsoldDefectiveProduct where WarehouseID=" + nWarehouseID + " " +
                        "and Status in (" + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Assessed + "," + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Discount_Approved + ")  " +
                        ") d  " +
                        "on a.ProductID=d.ProductID and A.ProductSerialNo=d.BarcodeSL  " +
                        "where b.ToWHID=" + nWarehouseID + " and a.IsTransitStock=0 and A.ProductID = " + nProductID + "  " +
                        "and a.ProductSerialNo not in (Select BarcodeSL From t_UnsoldDefectiveProduct where Status in (2,3,4,6,7) and WarehouseID=" + nWarehouseID + ")";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    oProductBarcode.IsVatPaidProduct = (int)reader["IsVatPaidProduct"];
                    if (reader["SaleAfter"] != DBNull.Value)
                    {
                        oProductBarcode.SaleAfter = Convert.ToDateTime(reader["SaleAfter"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oProductBarcode.SaleAfter = "";
                    }

                    oProductBarcode.IsDefective = (int)reader["IsDefective"];

                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }


        public void GetProductBarcodeByProductID(int nProductID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ProductSerialID,ProductID,ProductSerialNo,Status from t_ProductStockSerial where  " +
                          " ProductSerialNo not in (Select BarcodeSL From t_UnsoldDefectiveProduct where Status in (2,3,4,6,7)) and  "+
                          " Status= ? and ProductID = ? ";

            cmd.Parameters.AddWithValue("Status", (int)Dictionary.ProductSerialStatus.Received_at_Outlet);
            cmd.Parameters.AddWithValue("ProductID", nProductID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductStockSerialID = (int)reader["ProductSerialID"];
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        public void GetRefNoByProductBarcode(string sProductBarcode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TranNo,TranDate From t_ProductStockSerial a,t_PRoductStockTran b " +
                          " where a.ProductStockTranID=b.TranID and ProductSerialNo = ? ";

            cmd.Parameters.AddWithValue("ProductSerialNo", sProductBarcode);
            //cmd.Parameters.AddWithValue("ProductID", sProductBarcode);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.TranNo = (string)reader["TranNo"];
                    oProductBarcode.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        public void GetBarcodeForISGM(int nProductID, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * from t_ProductBarcode where WarehouseID = ? and ProductID=? and Status in(?,?) and IsActive in (?,?)";

            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.Transfer);
            cmd.Parameters.AddWithValue("Status", (int)Dictionary.BarcodeStatus.ISGM);
            cmd.Parameters.AddWithValue("IsActive", ((int)Dictionary.BarcodeIsActive.Lock));
            cmd.Parameters.AddWithValue("IsActive", ((int)Dictionary.BarcodeIsActive.Active));
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductSerialNo = (string)reader["Barcode"];
                    oProductBarcode.Status = (int)reader["Status"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void GetISGMSubmittedBarcode(int nProductID, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * from t_ProductBarCodeDetail where WarehouseID = ? and ProductID=? and IsActive =? ";

            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            cmd.Parameters.AddWithValue("IsActive", ((int)Dictionary.BarcodeIsActive.Lock));         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductSerialNo = (string)reader["Barcode"];                
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }



        }

        public void GetBarcodeForDisplayPosition(int nProductID,int nDisplayPositionID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select ProductSerialID,ProductID,ProductSerialNo,Status from t_ProductStockSerial where   " +
            //              "Status= " + (int)Dictionary.ProductSerialStatus.Received_at_Outlet + " and ProductID = " + nProductID + " ";

            string sSql= "Select ProductSerialID,ProductID,ProductSerialNo,Status from t_ProductStockSerial where cast(ProductID as varchar)+ProductSerialNo not in ( " +
                          "Select cast(ProductID as varchar)+ProductSerialNo From t_OutletDisplayPosition where ProductSerialNo is not null " +
                          "and DisplayPositionID<> " + nDisplayPositionID + ") and " +
                          "Status= " + (int)Dictionary.ProductSerialStatus.Received_at_Outlet + " and ProductID = " + nProductID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductStockSerialID = (int)reader["ProductSerialID"];
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        public void GetBarcodeForDisplayPositionRT(int nProductID, int nDisplayPositionID, int nWarehouseID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();



            string sSql = "Select ProductSerialID,ProductID,ProductSerialNo,a.Status from t_ProductStockSerialRT a,t_ProductStockTran b where a.ProductStockTranID = b.TranID and cast(ProductID as varchar)+ProductSerialNo not in ( " +
                          "Select cast(ProductID as varchar)+ProductSerialNo From t_OutletDisplayPosition where ProductSerialNo is not null " +
                          "and DisplayPositionID<> " + nDisplayPositionID + ") and " +
                          "a.Status=" + (int)Dictionary.ProductSerialStatus.Received_at_Outlet 
                          + " and ProductID = " + nProductID + " and b.ToWHID="+nWarehouseID+"";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductStockSerialID = (int)reader["ProductSerialID"];
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    InnerList.Add(oProductBarcode);
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
        // Get Barcode for sending from outlet to HO 
        ///
        public void GetProductBarcodeForDataSending(int nWarehouseID,long nInvoiceID,string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * from t_ProductBarcode where WarehouseID = ? and RefTranNo=?";

            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            cmd.Parameters.AddWithValue("RefTranNo", sInvoiceNo);           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode(); 
                    oProductBarcode.TranId = int.Parse(nInvoiceID.ToString());
                    oProductBarcode.ProductId = (int)reader["ProductID"];
                    oProductBarcode.ProductSerialNo = (string)reader["Barcode"];                  
                    InnerList.Add(oProductBarcode);
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
        // Get Barcoder from Cassiopeia for transaction transfer
        ///
        public void GetBarcodeFromCassiopeia(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select TranID,ProductID,a.ProductCode,SerialNo as ProductSerialNo " +
                                "from " +
                                "( " +
                                "SELECT inreftranid AS TranID, b.Code AS ProductCode, SerialNo " +
                                "FROM Cassiopeia_HO.dbo.ProductSerial  a ,Cassiopeia_HO.dbo.Product b    " +
                                "WHERE a.ProductID = b.ProductID and inreftranid =  ?  AND ShowroomID = 1 " +
                                ") as a " +
                                "inner join " +
                                "( " +
                                "select * from telsysdb.dbo.t_product " +
                                ") as b on a.productCode = b.ProductCode";

            cmd.Parameters.AddWithValue("inreftranid", nTranID);
        

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.TranID = (int)reader["TranID"];
                    oProductBarcode.ProductId = (int)reader["ProductID"];
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];

                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }
        public void GetProductSerial(int nType, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductName, string sBarcode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select a.ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID, " +
                   " BrandName,ProductSerialNo,Status,  " +
                   " Type=CASE When Status = 9 then 'Sold' " +
                   " When Status IN (0,2,4,5,7) then 'Transit' " +
                   " When Status =1 then 'Un Sold'else 'Other' end, " +
                   " StatusName = CASE When Status =0 then 'Send_from_HO_to_Outlet' " +
                   " When Status =1 then 'Received_at_Outlet' When Status =2 then 'Send_from_Outlet_to_HO' " +
                   " When Status =3 then 'Received_at_HO' When Status =4 then 'Send_from_Outlet_to_Outlet' " +
                   " When Status =5 then 'Send_from_Outlet_CSD' When Status =6 then 'Receive_at_CSD' " +
                   " When Status =7 then 'Send_from_CSD_to_Outlet' When Status =8 then 'Send_from_CSD_to_HO' " +
                   " When Status =9 then 'Sold' When Status =10 then 'Defective' " +
                   " When Status =11 then 'Reject_tran_by_Management' else 'Other' end " +
                   " from t_productStockSerial a, (Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
                   " ASGName, MAGID, MAGName, BrandID, BrandDesc as BrandName from v_ProductDetails)b  " +
                   " Where a.ProductID=b.ProductID ";


            if (nType != -1)
            {
                if (nType == 1)
                {
                    sSql = sSql + " and Status IN (1) ";
                }
                else if (nType == 2)
                {
                    sSql = sSql + " and Status IN (0,2,4,5,7) ";
                }
                else 
                {
                    sSql = sSql + " and Status IN (9) ";
                }

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
            if (sBarcode != "")
            {
                sSql = sSql + " and ProductSerialNo='" + sBarcode + "'";
            }
            //and ProductCode='52022'




            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.ProductId = (int)reader["ProductId"];
                    oProductBarcode.ProductCode = (string)reader["ProductCode"];
                    oProductBarcode.ProductName = (string)reader["ProductName"];

                    oProductBarcode.AGID = (int)reader["AGID"];
                    oProductBarcode.AGName = (string)reader["AGName"];

                    oProductBarcode.ASGID = (int)reader["ASGID"];
                    oProductBarcode.ASGName = (string)reader["ASGName"];

                    oProductBarcode.MAGID = (int)reader["MAGID"];
                    oProductBarcode.MAGName = (string)reader["MAGName"];

                    oProductBarcode.BrandID = (int)reader["BrandID"];
                    oProductBarcode.BrandName = (string)reader["BrandName"];

                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    oProductBarcode.StatusName = (string)reader["StatusName"];
                    oProductBarcode.Type = (string)reader["Type"];

                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }

        public void GetProductSerialRT(int nType, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductName, string sBarcode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select a.ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID, " +
                   " BrandName,ProductSerialNo,a.Status,  " +
                   " Type=CASE When a.Status = 9 then 'Sold' " +
                   " When a.Status IN (0,2,4,5,7) then 'Transit' " +
                   " When a.Status =1 then 'Un Sold' else 'Other' end, " +
                   " StatusName = CASE When a.Status =0 then 'Send_from_HO_to_Outlet' " +
                   " When a.Status =1 then 'Received_at_Outlet' When a.Status =2 then 'Send_from_Outlet_to_HO' " +
                   " When a.Status =3 then 'Received_at_HO' When a.Status =4 then 'Send_from_Outlet_to_Outlet' " +
                   " When a.Status =5 then 'Send_from_Outlet_CSD' When a.Status =6 then 'Receive_at_CSD' " +
                   " When a.Status =7 then 'Send_from_CSD_to_Outlet' When a.Status =8 then 'Send_from_CSD_to_HO' " +
                   " When a.Status =9 then 'Sold' When a.Status =10 then 'Defective' " +
                   " When a.Status =11 then 'Reject_tran_by_Management' else 'Other' end " +
                   " from t_productStockSerialRT a, (Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
                   " ASGName, MAGID, MAGName, BrandID, BrandDesc as BrandName from v_ProductDetails)b, t_ProductStockTran c  " +
                   " Where a.ProductID=b.ProductID  and a.ProductStockTranID=c.TranID and ToWHID=" + Utility.WarehouseID + "";


            if (nType != -1)
            {
                if (nType == 1)
                {
                    sSql = sSql + " and Status IN (1) ";
                }
                else if (nType == 2)
                {
                    sSql = sSql + " and Status IN (0,2,4,5,7) ";
                }
                else
                {
                    sSql = sSql + " and Status IN (9) ";
                }

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
            if (sBarcode != "")
            {
                sSql = sSql + " and ProductSerialNo='" + sBarcode + "'";
            }
            //and ProductCode='52022'




            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.ProductId = (int)reader["ProductId"];
                    oProductBarcode.ProductCode = (string)reader["ProductCode"];
                    oProductBarcode.ProductName = (string)reader["ProductName"];

                    oProductBarcode.AGID = (int)reader["AGID"];
                    oProductBarcode.AGName = (string)reader["AGName"];

                    oProductBarcode.ASGID = (int)reader["ASGID"];
                    oProductBarcode.ASGName = (string)reader["ASGName"];

                    oProductBarcode.MAGID = (int)reader["MAGID"];
                    oProductBarcode.MAGName = (string)reader["MAGName"];

                    oProductBarcode.BrandID = (int)reader["BrandID"];
                    oProductBarcode.BrandName = (string)reader["BrandName"];

                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.Status = (int)reader["Status"];
                    oProductBarcode.StatusName = (string)reader["StatusName"];
                    oProductBarcode.Type = (string)reader["Type"];

                    InnerList.Add(oProductBarcode);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);

            }

        }


        //public void GetProductSerialRT(int nType, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductName, string sBarcode)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    sSql = "select a.ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, BrandID, " +
        //           " BrandName,ProductSerialNo,Status,  " +
        //           " Type=CASE When Status = 9 then 'Sold' " +
        //           " When Status IN (0,2,4,5,7) then 'Transit' " +
        //           " When Status =1 then 'Un Sold'else 'Other' end, " +
        //           " StatusName = CASE When Status =0 then 'Send_from_HO_to_Outlet' " +
        //           " When Status =1 then 'Received_at_Outlet' When Status =2 then 'Send_from_Outlet_to_HO' " +
        //           " When Status =3 then 'Received_at_HO' When Status =4 then 'Send_from_Outlet_to_Outlet' " +
        //           " When Status =5 then 'Send_from_Outlet_CSD' When Status =6 then 'Receive_at_CSD' " +
        //           " When Status =7 then 'Send_from_CSD_to_Outlet' When Status =8 then 'Send_from_CSD_to_HO' " +
        //           " When Status =9 then 'Sold' When Status =10 then 'Defective' " +
        //           " When Status =11 then 'Reject_tran_by_Management' else 'Other' end " +
        //           " from t_productStockSerial a, (Select ProductID, ProductCode, ProductName, AGID, AGName, ASGID,  " +
        //           " ASGName, MAGID, MAGName, BrandID, BrandDesc as BrandName from v_ProductDetails)b  " +
        //           " Where a.ProductID=b.ProductID ";


        //    if (nType != -1)
        //    {
        //        if (nType == 1)
        //        {
        //            sSql = sSql + " and Status IN (1) ";
        //        }
        //        else if (nType == 2)
        //        {
        //            sSql = sSql + " and Status IN (0,2,4,5,7) ";
        //        }
        //        else
        //        {
        //            sSql = sSql + " and Status IN (9) ";
        //        }

        //    }
        //    if (nMAGID != 0)
        //    {
        //        sSql = sSql + " and MAGID=" + nMAGID + "";
        //    }
        //    if (nASGID != 0)
        //    {
        //        sSql = sSql + " and ASGID=" + nASGID + "";
        //    }
        //    if (nAGID != 0)
        //    {
        //        sSql = sSql + " and AGID=" + nAGID + "";
        //    }
        //    if (nBrandID != 0)
        //    {
        //        sSql = sSql + " and BrandID=" + nBrandID + "";
        //    }
        //    if (sProductCode != "")
        //    {
        //        sSql = sSql + " and ProductCode='" + sProductCode + "'";
        //    }
        //    if (sProductName != "")
        //    {
        //        sSql = sSql + " and ProductName like '%" + sProductName + "%'";
        //    }
        //    if (sBarcode != "")
        //    {
        //        sSql = sSql + " and ProductSerialNo='" + sBarcode + "'";
        //    }
        //    //and ProductCode='52022'




        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ProductBarcode oProductBarcode = new ProductBarcode();

        //            oProductBarcode.ProductId = (int)reader["ProductId"];
        //            oProductBarcode.ProductCode = (string)reader["ProductCode"];
        //            oProductBarcode.ProductName = (string)reader["ProductName"];

        //            oProductBarcode.AGID = (int)reader["AGID"];
        //            oProductBarcode.AGName = (string)reader["AGName"];

        //            oProductBarcode.ASGID = (int)reader["ASGID"];
        //            oProductBarcode.ASGName = (string)reader["ASGName"];

        //            oProductBarcode.MAGID = (int)reader["MAGID"];
        //            oProductBarcode.MAGName = (string)reader["MAGName"];

        //            oProductBarcode.BrandID = (int)reader["BrandID"];
        //            oProductBarcode.BrandName = (string)reader["BrandName"];

        //            oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
        //            oProductBarcode.Status = (int)reader["Status"];
        //            oProductBarcode.StatusName = (string)reader["StatusName"];
        //            oProductBarcode.Type = (string)reader["Type"];

        //            InnerList.Add(oProductBarcode);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);

        //    }

        //}

        public void GetStockSerial(int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select a.ProductID," + nWHID + " as WarehouseID,  " +
                "isnull(ProductSerialNo, '') ProductSerialNo,isnull(TranNo, '') TranNo,   " +
                "isnull(TranDate, getdate()) TranDate,1 as Status  " +
                "From t_ProductStockSerial a  " +
                "left outer join  " +
                "t_ProductStockTran b  " +
                "on a.ProductStockTranID = b.TranID  " +
                "join v_ProductDetails c  " +
                "on a.ProductID = c.ProductID  " +
                "where a.Status = 1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();
                    oProductBarcode.ProductId = (int)reader["ProductID"];
                    oProductBarcode.WarehouseID = (int)reader["WarehouseID"];
                    oProductBarcode.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oProductBarcode.TranNo = (string)reader["TranNo"];
                    oProductBarcode.TranDate = (DateTime)reader["TranDate"];

                    InnerList.Add(oProductBarcode);
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



 
