// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: April 1, 2011
// Time : 10:00 AM
// Description: Form for printing Stock Position Report
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

namespace CJ.Class
{
    public class ProductDetail
    {
        private double _CPBDT;
        public double CPBDT
        {
            get { return _CPBDT; }
            set { _CPBDT = value; }
        }
        private double _CPUSD;
        public double CPUSD
        {
            get { return _CPUSD; }
            set { _CPUSD = value; }
        }

        private int _nQuantity;

        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }
        private double _UnitPrice;

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
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

        private double _DP;
        public double DP
        {
            get { return _DP; }
            set { _DP = value; }
        }
        private double _TP;
        public double TP
        {
            get { return _TP; }
            set { _TP = value; }
        }
        private double _PW;
        public double PW
        {
            get { return _PW; }
            set { _PW = value; }
        }

        private int _bIsEcomSync;
        public int IsEcomSync
        {
            get { return _bIsEcomSync; }
            set { _bIsEcomSync = value; }
        }


        private double _nCalculativeTradePrice;

        public double CalculativeTradePrice
        {
            get { return _nCalculativeTradePrice; }
            set { _nCalculativeTradePrice = value; }
        }

        private double _VATLowerLimit;
        public double VATLowerLimit
        {
            get { return _VATLowerLimit; }
            set { _VATLowerLimit = value; }
        }

        private double _VATUpperLimit;
        public double VATUpperLimit
        {
            get { return _VATUpperLimit; }
            set { _VATUpperLimit = value; }
        }

        private int _nIsVatApplicableonNetPrice;
        //Modified by: Uttam 13-Apr-2014
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sProductDesc;
        private string _sProductModel;
        private string _sSmallUnitOfMeasure;
        private string _sLargeUnitOfMeasure;
        private int _nUOMConversionFactor;
        private int _nInventoryCategory;
        private int _nItemCategory;
        private string _sMidUnitOfMeasure;
        private int _nMSRatio;
        private int _nLSRatio;
        private DateTime _dEntryDate;
        private DateTime _dLastUpdateDate;
        private int _nProductType;
        private int _nAGID;
        private int _nSubBrandID;
        private int _bIsActive;
        private int _SupplyType;
        //HSCodeID
        private int _nHSCodeID;
        private int _nVATApplicable;
        private string _sAGCode;
        private string _sAGName;
        private int _nASGID;
        private string _sASGCode;
        private string _sASGName;
        private int _nMAGID;
        private string _sMAGCode;
        private string _sMAGName;
        private int _nPGID;
        private string _sPGCode;
        private string _sPGName;
        private int _nBrandID;
        private string _sBrandCode;
        private string _sBrandDesc;
        private string _sSubBrandCode;
        private string _sSubBrandName;
        //SupplierID
        private int _nSupplierID;
        //SupplierCode
        private string _sSupplierCode;
        //SupplierName
        private string _sSupplierName;
        private double _CostPrice;
        private double _NSP;
        private double _RSP;
        private double _Vat;
        private double _TradePrice;
        private double _SpecialPrice;
        //PriceEffectFrom
        private DateTime _dPriceEffectFrom;
        //Upload Status
        private int _nUploadStatus;
        //UploadDate
        private DateTime _dUploadDate;
        //DownloadStatus
        private DateTime _dDownloadDate;
        //HSCode
        private string _sHSCode;
        //HSCodeName
        private string _sHSCodeName;
        private int _nPriceID;
        private int _nCPProductID;               
        private double _MRP;      
        private bool _bFlag;
        private int _StockByWarehouse;
        private int _nIsBarcodeItem;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private int _nShadowPriceID;

        private int _nCurrentStock;
        private string _sPriceRemarks;
        public string PriceRemarks
        {
            get { return _sPriceRemarks; }
            set { _sPriceRemarks = value; }
        }
        public int IsVatApplicableonNetPrice
        {
            get { return _nIsVatApplicableonNetPrice; }
            set { _nIsVatApplicableonNetPrice = value; }
        }
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        public int ShadowPriceID
        {
            get { return _nShadowPriceID; }
            set { _nShadowPriceID = value; }
        }

        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        //Modified by: Arif Khan 13-Apr-2014
        private Product _oProduct;
        private string _sPetName;
        public string PetName
        {
            get { return _sPetName; }
            set { _sPetName = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private int _nVATType;
        public int VATType
        {
            get { return _nVATType; }
            set { _nVATType = value; }
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
        public string ProductDesc
        {
            get { return _sProductDesc; }
            set { _sProductDesc = value; }
        }
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }
        public string SmallUnitOfMeasure
        {
            get { return _sSmallUnitOfMeasure; }
            set { _sSmallUnitOfMeasure = value; }
        }
        public string LargeUnitOfMeasure
        {
            get { return _sLargeUnitOfMeasure; }
            set { _sLargeUnitOfMeasure = value; }
        }
        public int UOMConversionFactor
        {
            get { return _nUOMConversionFactor; }
            set { _nUOMConversionFactor = value; }
        }
        public int InventoryCategory
        {
            get { return _nInventoryCategory; }
            set { _nInventoryCategory = value; }
        }
        public int ItemCategory
        {
            get { return _nItemCategory; }
            set { _nItemCategory = value; }
        }
        public string MidUnitOfMeasure
        {
            get { return _sMidUnitOfMeasure; }
            set { _sMidUnitOfMeasure = value; }
        }
        public int MSRatio
        {
            get { return _nMSRatio; }
            set { _nMSRatio = value; }
        }
        public int LSRatio
        {
            get { return _nLSRatio; }
            set { _nLSRatio = value; }
        }
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        public DateTime LastUpdateDate
        {
            get { return _dLastUpdateDate; }
            set { _dLastUpdateDate = value; }
        }
        public int ProductType
        {
            get { return _nProductType; }
            set { _nProductType = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        public int IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
        }
        public int VATApplicable
        {
            get { return _nVATApplicable; }
            set { _nVATApplicable = value; }
        }
        public int SupplyType
        {
            get { return _SupplyType; }
            set { _SupplyType = value; }
        }
        //_nHSCodeID
        public int HSCodeID
        {
            get { return _nHSCodeID; }
            set { _nHSCodeID = value; }
        }        
        public string AGCode
        {
            get { return _sAGCode; }
            set { _sAGCode = value; }
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
        public string ASGCode
        {
            get { return _sASGCode; }
            set { _sASGCode = value; }
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
        public string MAGCode
        {
            get { return _sMAGCode; }
            set { _sMAGCode = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        public string PGCode
        {
            get { return _sPGCode; }
            set { _sPGCode = value; }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }
        public int SubBrandID
        {
            get { return _nSubBrandID; }
            set { _nSubBrandID = value; }
        }
        public string SubBrandCode
        {
            get { return _sSubBrandCode; }
            set { _sSubBrandCode = value; }
        }
        public string SubBrandName
        {
            get { return _sSubBrandName; }
            set { _sSubBrandName = value; }
        }
        //SupplierID
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }
        //SupplierCode
        public string SupplierCode
        {
            get { return _sSupplierCode; }
            set { _sSupplierCode = value; }
        }
        //SupplierName
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value; }
        }
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        private double _VATCP;
        public double VATCP
        {
            get { return _VATCP; }
            set { _VATCP = value; }
        }
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        public double Vat
        {
            get { return _Vat; }
            set { _Vat = value; }
        }
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        public double SpecialPrice
        {
            get { return _SpecialPrice;}
            set { _SpecialPrice = value; }
        }
        //PriceEffectFrom
        public DateTime PriceEffectFrom
        {
            get { return _dPriceEffectFrom; }
            set { _dPriceEffectFrom = value; }
        }
        //UploadStatus
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }
        }
        //_dUploadDate
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }
        //_dDownloadDate
        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }
        //_sHSCode
        public string HSCode
        {
            get { return _sHSCode; }
            set { _sHSCode = value; }
        }
        //HSCodeName
        public string HSCodeName
        {
            get { return _sHSCodeName; }
            set { _sHSCodeName = value; }
        }
        public int StockByWarehouse
        {
            get { return _StockByWarehouse; }
            set { _StockByWarehouse = value; }
        }
        
        public int PriceID
        {
            get { return _nPriceID; }
            set { _nPriceID = value; }
        }
        public double MRP
        {
            get { return _MRP; }
            set { _MRP = value; }
        }
        public int CPProductID
        {
            get { return _nCPProductID; }
            set { _nCPProductID = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public int IsBarcodeItem
        {
            get { return _nIsBarcodeItem; }
            set { _nIsBarcodeItem = value; }
        }
        //Modified by: Arif Khan 13-Apr-2014
        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                    _oProduct.ProductID = _nProductID;
                    _oProduct.RefreshByID();
                }

                return _oProduct;
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();          
           
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    if (reader["ProductModel"] != DBNull.Value)
                        _sProductModel = (string)reader["ProductModel"]; 
                    _sSmallUnitOfMeasure = (string)reader["SmallUnitOfMeasure"];
                    _sLargeUnitOfMeasure = (string)reader["LargeUnitOfMeasure"];
                    _nUOMConversionFactor = Convert.ToInt32(reader["UOMConversionFactor"].ToString());

                    if (reader["InventoryCategory"] != DBNull.Value)
                        _nInventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else _nInventoryCategory = 1;

                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 1;

                    if (reader["MidUnitOfMeasure"] != DBNull.Value)
                        _sMidUnitOfMeasure = (string)reader["MidUnitOfMeasure"];

                    if (reader["MSRatio"] != DBNull.Value)
                        _nMSRatio = Convert.ToInt32(reader["MSRatio"].ToString());
                    else
                        _nMSRatio = 0;

                    if (reader["LSRatio"] != DBNull.Value)
                        _nLSRatio = Convert.ToInt32(reader["LSRatio"].ToString());
                    else
                        _nLSRatio = 0;

                    _nProductType = Convert.ToInt32(reader["ProductType"].ToString());
                    _nAGID = Convert.ToInt32(reader["AGID"].ToString());
                    _nSubBrandID = Convert.ToInt32(reader["SubBrandID"].ToString());

                    if (reader["IsActive"] != DBNull.Value)
                        _bIsActive = Convert.ToInt32(reader["IsActive"].ToString());
                    else
                        _bIsActive = 0;

                    if (reader["HSCodeID"] != DBNull.Value)
                        _nHSCodeID = Convert.ToInt32(reader["HSCodeID"].ToString());
                    else
                        _nHSCodeID = 0;

                    if (reader["VATApplicable"] != DBNull.Value)
                        _nVATApplicable = Convert.ToInt32(reader["VATApplicable"].ToString());
                    else _nVATApplicable = 1;

                    _SupplyType = (int)reader["SupplyType"];
                    _sAGCode = (string)reader["AGCode"];
                    _sAGName = reader["AGName"].ToString();

                    _nASGID = Convert.ToInt32(reader["ASGID"].ToString());
                    _sASGCode = (string)reader["ASGCode"];
                    _sASGName = (string)reader["ASGName"];

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    else
                        _nMAGID = 0;

                    _sMAGCode = (string)reader["MAGName"];
                    _sMAGName = (string)reader["MAGName"];

                    if (reader["PGID"] != DBNull.Value)
                        _nPGID = Convert.ToInt32(reader["PGID"].ToString());
                    else
                        _nPGID = 0;
                    _sPGCode = (string)reader["PGCode"];
                    _sPGName = (string)reader["PGName"];

                    if (reader["BrandID"] != DBNull.Value)
                        _nBrandID = Convert.ToInt32(reader["BrandID"].ToString());
                    else
                        _nBrandID = 0;
                    _sBrandCode = (string)reader["BrandCode"];
                    _sBrandDesc = reader["BrandDesc"].ToString();

                    _sSubBrandCode = (string)reader["SubBrandCode"];
                    _sSubBrandName = (string)reader["SubBrandName"];

                    try
                    {
                        if (Utility.CompanyInfo != "TML")
                        {

                            if (reader["SupplierID"] != DBNull.Value)
                            {
                                _nSupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                                _sSupplierCode = (string)reader["SupplierCode"];
                                _sSupplierName = (string)reader["SupplierName"];
                            }
                            else
                                _nSupplierID = 0;

                        }
                    }
                    catch
                    {
                        _nSupplierID = 0;
                    }

                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _CostPrice = 0;

                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;

                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;
                   
                    if (reader["VAT"] != DBNull.Value)
                        _Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else _Vat = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _TradePrice = 0;

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _SpecialPrice = 0;
                                        
                    
                    _sProductModel = reader["ProductModel"].ToString();

                    //_sBrandDesc = (string)reader["BrandDesc"];
                    try
                    {
                        if (Utility.CompanyInfo != "TML")
                        {
                            if (reader["UploadStatus"] != DBNull.Value)
                                _nUploadStatus = Convert.ToInt32(reader["UploadStatus"].ToString());
                            else
                                _nUploadStatus = 0;
                        }
                    }
                    catch
                    {
                        _nUploadStatus = 0;
                    }
                    //_sHSCode = (string)reader["HSCode"];
                    //_sHSCodeName = (string)reader["HSCodeName"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }            
        }

        public void GetProductWithProvision(int nProductID, int nCustomerTypeID) 
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Select a.*,isnull(DP,0)*NSP DP,isnull(TP,0)*NSP TP,isnull(PW,0)*NSP PW From  " +
                                "(Select * From v_ProductDetails where ProductID= " + nProductID + ") a  " +
                                "Left Outer Join   " +
                                "(Select ProductGroupID,BrandID,ProvisionPercent as DP From t_ProvisionParam   " +
                                "where IsActive=1 and ProvisionType=1 and CustomerTypeID=" + nCustomerTypeID + ") DP  " +
                                "on a.ASGID=DP.ProductGroupID and a.BrandID=DP.BrandID  " +
                                "Left Outer Join   " +
                                "(Select ProductGroupID,BrandID,ProvisionPercent as TP From t_ProvisionParam   " +
                                "where IsActive=1 and ProvisionType=3 and CustomerTypeID=" + nCustomerTypeID + ") TP  " +
                                "on a.ASGID=TP.ProductGroupID and a.BrandID=TP.BrandID  " +
                                "Left Outer Join   " +
                                "(Select ProductGroupID,BrandID,ProvisionPercent as PW From t_ProvisionParam   " +
                                "where IsActive=1 and ProvisionType=5 and CustomerTypeID=" + nCustomerTypeID + ") PW  " +
                                "on a.ASGID=PW.ProductGroupID and a.BrandID=PW.BrandID";

                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    if (reader["ProductModel"] != DBNull.Value)
                        _sProductModel = (string)reader["ProductModel"];
                    _sSmallUnitOfMeasure = (string)reader["SmallUnitOfMeasure"];
                    _sLargeUnitOfMeasure = (string)reader["LargeUnitOfMeasure"];
                    _nUOMConversionFactor = Convert.ToInt32(reader["UOMConversionFactor"].ToString());

                    if (reader["InventoryCategory"] != DBNull.Value)
                        _nInventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else _nInventoryCategory = 1;

                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 1;

                    if (reader["MidUnitOfMeasure"] != DBNull.Value)
                        _sMidUnitOfMeasure = (string)reader["MidUnitOfMeasure"];

                    if (reader["MSRatio"] != DBNull.Value)
                        _nMSRatio = Convert.ToInt32(reader["MSRatio"].ToString());
                    else
                        _nMSRatio = 0;

                    if (reader["LSRatio"] != DBNull.Value)
                        _nLSRatio = Convert.ToInt32(reader["LSRatio"].ToString());
                    else
                        _nLSRatio = 0;

                    _nProductType = Convert.ToInt32(reader["ProductType"].ToString());
                    _nAGID = Convert.ToInt32(reader["AGID"].ToString());
                    _nSubBrandID = Convert.ToInt32(reader["SubBrandID"].ToString());

                    if (reader["IsActive"] != DBNull.Value)
                        _bIsActive = Convert.ToInt32(reader["IsActive"].ToString());
                    else
                        _bIsActive = 0;

                    if (reader["HSCodeID"] != DBNull.Value)
                        _nHSCodeID = Convert.ToInt32(reader["HSCodeID"].ToString());
                    else
                        _nHSCodeID = 0;

                    if (reader["VATApplicable"] != DBNull.Value)
                        _nVATApplicable = Convert.ToInt32(reader["VATApplicable"].ToString());
                    else _nVATApplicable = 1;

                    _SupplyType = (int)reader["SupplyType"];
                    _sAGCode = (string)reader["AGCode"];
                    _sAGName = reader["AGName"].ToString();

                    _nASGID = Convert.ToInt32(reader["ASGID"].ToString());
                    _sASGCode = (string)reader["ASGCode"];
                    _sASGName = (string)reader["ASGName"];

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    else
                        _nMAGID = 0;

                    _sMAGCode = (string)reader["MAGName"];
                    _sMAGName = (string)reader["MAGName"];

                    if (reader["PGID"] != DBNull.Value)
                        _nPGID = Convert.ToInt32(reader["PGID"].ToString());
                    else
                        _nPGID = 0;
                    _sPGCode = (string)reader["PGCode"];
                    _sPGName = (string)reader["PGName"];

                    if (reader["BrandID"] != DBNull.Value)
                        _nBrandID = Convert.ToInt32(reader["BrandID"].ToString());
                    else
                        _nBrandID = 0;
                    _sBrandCode = (string)reader["BrandCode"];
                    _sBrandDesc = reader["BrandDesc"].ToString();

                    _sSubBrandCode = (string)reader["SubBrandCode"];
                    _sSubBrandName = (string)reader["SubBrandName"];

                    if (Utility.CompanyInfo != "TML")
                    {
                        if (reader["SupplierID"] != DBNull.Value)
                        {
                            _nSupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                            _sSupplierCode = (string)reader["SupplierCode"];
                            _sSupplierName = (string)reader["SupplierName"];
                        }
                        else
                            _nSupplierID = 0;

                    }
                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _CostPrice = 0;

                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;

                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;

                    if (reader["VAT"] != DBNull.Value)
                        _Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else _Vat = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _TradePrice = 0;

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _SpecialPrice = 0;
                    _sProductModel = reader["ProductModel"].ToString();
                    if (Utility.CompanyInfo != "TML")
                    {
                        if (reader["UploadStatus"] != DBNull.Value)
                            _nUploadStatus = Convert.ToInt32(reader["UploadStatus"].ToString());
                        else
                            _nUploadStatus = 0;
                    }
                    if (reader["DP"] != DBNull.Value)
                        _DP = Convert.ToDouble(reader["DP"].ToString());
                    else _DP = 0;

                    if (reader["TP"] != DBNull.Value)
                        _TP = Convert.ToDouble(reader["TP"].ToString());
                    else _TP = 0;

                    if (reader["PW"] != DBNull.Value)
                        _PW = Convert.ToDouble(reader["PW"].ToString());
                    else _PW = 0;


                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForPos()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    
                    _nProductType = Convert.ToInt32(reader["ProductType"].ToString());
                    _nAGID = Convert.ToInt32(reader["AGID"].ToString());
                    
                    _sAGCode = (string)reader["AGCode"];
                    _sAGName = reader["AGName"].ToString();

                    _nASGID = Convert.ToInt32(reader["ASGID"].ToString());
                    _sASGCode = (string)reader["ASGCode"];
                    _sASGName = (string)reader["ASGName"];

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    else
                        _nMAGID = 0;

                    _sMAGCode = (string)reader["MAGName"];
                    _sMAGName = (string)reader["MAGName"];

                    if (reader["PGID"] != DBNull.Value)
                        _nPGID = Convert.ToInt32(reader["PGID"].ToString());
                    else
                        _nPGID = 0;
                    _sPGCode = (string)reader["PGCode"];
                    _sPGName = (string)reader["PGName"];

                    if (reader["BrandID"] != DBNull.Value)
                        _nBrandID = Convert.ToInt32(reader["BrandID"].ToString());
                    else
                        _nBrandID = 0;
                    _sBrandCode = (string)reader["BrandCode"];
                    _sBrandDesc = reader["BrandDesc"].ToString();
                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _CostPrice = 0;

                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;

                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _TradePrice = 0;

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _SpecialPrice = 0;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForDefectiveProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    if (reader["ProductModel"] != DBNull.Value)
                        _sProductModel = (string)reader["ProductModel"];
                    _sSmallUnitOfMeasure = (string)reader["SmallUnitOfMeasure"];
                    _sLargeUnitOfMeasure = (string)reader["LargeUnitOfMeasure"];
                    _nUOMConversionFactor = Convert.ToInt32(reader["UOMConversionFactor"].ToString());

                    if (reader["InventoryCategory"] != DBNull.Value)
                        _nInventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else _nInventoryCategory = 1;

                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 1;

                    if (reader["MidUnitOfMeasure"] != DBNull.Value)
                        _sMidUnitOfMeasure = (string)reader["MidUnitOfMeasure"];

                    if (reader["MSRatio"] != DBNull.Value)
                        _nMSRatio = Convert.ToInt32(reader["MSRatio"].ToString());
                    else
                        _nMSRatio = 0;

                    if (reader["LSRatio"] != DBNull.Value)
                        _nLSRatio = Convert.ToInt32(reader["LSRatio"].ToString());
                    else
                        _nLSRatio = 0;

                    _nProductType = Convert.ToInt32(reader["ProductType"].ToString());
                    _nAGID = Convert.ToInt32(reader["AGID"].ToString());
                    _nSubBrandID = Convert.ToInt32(reader["SubBrandID"].ToString());

                    if (reader["IsActive"] != DBNull.Value)
                        _bIsActive = Convert.ToInt32(reader["IsActive"].ToString());
                    else
                        _bIsActive = 0;

                    if (reader["HSCodeID"] != DBNull.Value)
                        _nHSCodeID = Convert.ToInt32(reader["HSCodeID"].ToString());
                    else
                        _nHSCodeID = 0;

                    if (reader["VATApplicable"] != DBNull.Value)
                        _nVATApplicable = Convert.ToInt32(reader["VATApplicable"].ToString());
                    else _nVATApplicable = 1;

                    _SupplyType = (int)reader["SupplyType"];
                    _sAGCode = (string)reader["AGCode"];
                    _sAGName = reader["AGName"].ToString();

                    _nASGID = Convert.ToInt32(reader["ASGID"].ToString());
                    _sASGCode = (string)reader["ASGCode"];
                    _sASGName = (string)reader["ASGName"];

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    else
                        _nMAGID = 0;

                    _sMAGCode = (string)reader["MAGName"];
                    _sMAGName = (string)reader["MAGName"];

                    if (reader["PGID"] != DBNull.Value)
                        _nPGID = Convert.ToInt32(reader["PGID"].ToString());
                    else
                        _nPGID = 0;
                    _sPGCode = (string)reader["PGCode"];
                    _sPGName = (string)reader["PGName"];

                    if (reader["BrandID"] != DBNull.Value)
                        _nBrandID = Convert.ToInt32(reader["BrandID"].ToString());
                    else
                        _nBrandID = 0;
                    _sBrandCode = (string)reader["BrandCode"];
                    _sBrandDesc = reader["BrandDesc"].ToString();

                    _sSubBrandCode = (string)reader["SubBrandCode"];
                    _sSubBrandName = (string)reader["SubBrandName"];

                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _CostPrice = 0;

                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;

                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;

                    if (reader["VAT"] != DBNull.Value)
                        _Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else _Vat = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _TradePrice = 0;

                    if (reader["SpecialPrice"] != DBNull.Value)
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else _SpecialPrice = 0;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sBrandDesc = reader["BrandDesc"].ToString();
                    if (reader["VATApplicable"] != DBNull.Value)
                        _nVATApplicable = (int)reader["VATApplicable"];
                    else _nVATApplicable = 1;

                    if (reader["AGID"] != DBNull.Value)
                        _nAGID = Convert.ToInt32(reader["AGID"].ToString());
                   else _nAGID = 0;

                    if (reader["ASGID"] != DBNull.Value)
                        _nASGID = Convert.ToInt32(reader["ASGID"].ToString());
                    else _nASGID = 0;

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    else _nMAGID = 0;
                       
                    if (reader["PGID"] != DBNull.Value)
                        _nPGID = Convert.ToInt32(reader["PGID"].ToString());
                    else _nPGID = 0;
                    if (reader["NSP"] != DBNull.Value)
                       _NSP = Convert.ToDouble(reader["NSP"].ToString());
                   else _NSP = 0;
                   if (reader["RSP"] != DBNull.Value)
                       _RSP = Convert.ToDouble(reader["RSP"].ToString());
                   else _RSP = 0;
                   _SupplyType = int.Parse(reader["SupplyType"].ToString());
                   if (reader["VAT"] != DBNull.Value)
                       _Vat = Convert.ToDouble(reader["VAT"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public void RefreshForFactory(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_Product where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sBrandDesc = reader["BrandDesc"].ToString();
                    if (reader["VATApplicable"] != DBNull.Value)
                        _nVATApplicable = (int)reader["VATApplicable"];
                    else _nVATApplicable = 1;

                    if (reader["AGID"] != DBNull.Value)
                        _nAGID = Convert.ToInt32(reader["AGID"].ToString());
                    else _nAGID = 0;

                    if (reader["ASGID"] != DBNull.Value)
                        _nASGID = Convert.ToInt32(reader["ASGID"].ToString());
                    else _nASGID = 0;

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    else _nMAGID = 0;

                    if (reader["PGID"] != DBNull.Value)
                        _nPGID = Convert.ToInt32(reader["PGID"].ToString());
                    else _nPGID = 0;
                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;
                    _SupplyType = int.Parse(reader["SupplyType"].ToString());
                    if (reader["VAT"] != DBNull.Value)
                        _Vat = Convert.ToDouble(reader["VAT"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public void RefreshForSalesOrder(string sUnitPriceType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];

                    if (sUnitPriceType == "NSP")
                    {
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    }
                    else if (sUnitPriceType == "Special Price")
                    {
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    }
                    else
                    {
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    }
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else Flag = false;
        }
        public void RefreshForSalesOrderByCode(string sUnitPriceType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductCode =?";
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];

                    if (sUnitPriceType == "NSP")
                    {
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    }
                    if (sUnitPriceType == "Special Price")
                    {
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    }
                    else
                    {
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    }

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else Flag = false;
        }
      
        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From " +
                                "( " +
                                "Select a.*,b.VATType,b.IsVatApplicableonNetPrice,b.PetName,isnull(c.VATCP,0) VATCP From    " +
                                "(SELECT * FROM v_productdetails) a  " +
                                "Left outer Join  " +
                                "(Select * From t_Product) b   " +
                                "on a.ProductID = b.ProductID  " +
                                "left outer join  " +
                                "(  " +
                                "Select ProductID, max(isnull(VATCP, CostPrice)) VATCP  " +
                                "From t_FinishedGoodsPrice where IsCurrent = 1  " +
                                "group by ProductID  " +
                                ") c on a.ProductID = c.ProductID  " +
                                ") a where ProductCode = ?";

                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _nBrandID = (int)reader["BrandID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    _sASGName = (string)reader["ASGName"];
                    _sAGName = (string)reader["AGName"];
                    _sMAGName = (string)reader["MAGName"];
                    _sPGName = (string)reader["PGName"];
                    _VATCP = Convert.ToDouble(reader["VATCP"].ToString());

                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    if (Utility.CompanyInfo == "TML")
                    {
                        if (reader["MRP"] != DBNull.Value)
                        {
                            _MRP = Convert.ToDouble(reader["MRP"].ToString());
                        }
                        else
                        {
                            _MRP = 0;
                        }
                    }
                    else
                    {
                        _MRP = 0;
                    }
                    if (reader["SpecialPrice"] != DBNull.Value)
                        _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    if (reader["VAT"] != DBNull.Value)
                        _Vat = Convert.ToDouble(reader["VAT"].ToString());
                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 1;
                    if (reader["InventoryCategory"] != DBNull.Value)
                        _nInventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else _nInventoryCategory = 1;
                    if (reader["SupplyType"] != DBNull.Value)
                        _SupplyType = Convert.ToInt32(reader["SupplyType"].ToString());
                    else _SupplyType = 1;

                    if (reader["VATType"] != DBNull.Value)
                        _nVATType = Convert.ToInt32(reader["VATType"].ToString());
                    else _nVATType = 1;

                    if (reader["VATApplicable"] != DBNull.Value)
                        _nVATApplicable = Convert.ToInt32(reader["VATApplicable"].ToString());
                    else _nVATApplicable = 0;

                    if (reader["IsBarcodeItem"] != DBNull.Value)
                        _nIsBarcodeItem = Convert.ToInt32(reader["IsBarcodeItem"].ToString());
                    else _nIsBarcodeItem = 0;

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else Flag = false;
        }

        public void RefreshBySalesFactory(string sCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();           
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductCode ='"+ sCode + "'";
                //cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());                
                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }



        public void RefreshGiftProdutByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductCode =? and ItemCategory=?";
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ItemCategory", (short)Dictionary.ItemCategory.Gift_Item);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];                 

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else Flag = false;
        }
        public void RefreshGiftProdutBy()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();           
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesPromGiftProduct where GiftItemID =?";
                cmd.Parameters.AddWithValue("GiftItemID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["GiftItemID"];
                    _sProductCode = (string)reader["Code"];
                    _sProductName = (string)reader["Name"];                  
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }            
        }
        ///
        // Get Product ID from Cassiopeia
        ///

        public void GetCPProductID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM Cassiopeia_HO.dbo.Product  where Code =?";
                cmd.Parameters.AddWithValue("Code", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCPProductID = (int)reader["ProductID"];

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetPriceByProductID(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select * from t_finishedGoodsPrice Where ProductID=? and IsCurrent=1";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _RSP = Convert.ToDouble(reader["RSP"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetPriceConsideringEffectiveDate(DateTime dOperationDate, int nProductID)//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select a.PriceID,ProductID,EffectiveDate,IsNull(CostPrice,0)CostPrice, IsNull(TradePrice,0) as TradePrice, " +
                                   " IsNull(NSP,0) as NSP, IsNull(RSP,0) as RSP, IsNull(SpecialPrice,0) as SpecialPrice, " +
                                   " IsNull(DistributorPrice,0) as DistributorPrice, IsNull(VAT,0) as VAT, IsCurrent from t_finishedgoodsprice a, " +
                                   " (select Max(PriceID)as PriceID from t_finishedgoodsprice where EffectiveDate <='" + dOperationDate + "' and ProductID = ?)b " +
                                   " where a.PriceID=b.PriceID ";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriceID = int.Parse(reader["PriceID"].ToString());
                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    _Vat = Convert.ToDouble(reader["VAT"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetPriceConsideringEffectiveDateRT(DateTime dOperationDate, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select a.PriceID,ProductID,EffectiveDate,IsNull(CostPrice,0)CostPrice, IsNull(TradePrice,0) as TradePrice, " +
                                   " IsNull(NSP,0) as NSP, IsNull(RSP,0) as RSP, IsNull(SpecialPrice,0) as SpecialPrice, " +
                                   " IsNull(DistributorPrice,0) as DistributorPrice, IsNull(VAT,0) as VAT, IsCurrent from t_finishedgoodsprice a, " +
                                   " (select Max(PriceID)as PriceID from t_finishedgoodsprice where EffectiveDate <='" + dOperationDate + "' and ProductID = ?)b " +
                                   " where a.PriceID=b.PriceID ";
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriceID = int.Parse(reader["PriceID"].ToString());
                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    _Vat = Convert.ToDouble(reader["VAT"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetMRPByProductCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductCode =?";
                cmd.Parameters.AddWithValue("Code", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    _MRP = Convert.ToDouble(reader["MRP"].ToString());

                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else Flag = false;

        }

        public void MRefresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select NSP,RSP,SpecialPrice, productid,productcode, substring (productname,16,23)as productname  from v_productdetails  Where ProductID=? order by ProductName";

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;
                    if (reader["SpecialPrice"] != DBNull.Value)
                      _SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                  else _SpecialPrice = 0;


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

        public DSProduct POSGetProductDetail (DSProduct oDSProduct, string sProductCode)
        {
            _sProductCode = sProductCode;
            RefreshByCode();

            oDSProduct = new DSProduct();
            DSProduct.ProductRow oProductRow= oDSProduct.Product.NewProductRow();

                oProductRow.ProductName = _sProductName;
                oProductRow.ProductID = _nProductID;
                if (_bFlag)
                    oProductRow.Flag = "1";
                else oProductRow.Flag = "0";

                oDSProduct.Product.AddProductRow(oProductRow);
                oDSProduct.AcceptChanges();        

            return oDSProduct;
        }

        #endregion

        public void RefreshByASGID()//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ASGID, ASGName from v_ProductDetails Where ASGID=? Group By ASGID, ASGName Order by ASGName ";
                cmd.Parameters.AddWithValue("ASGID",_nASGID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nASGID = (int)reader["ASGID"];
                    _sASGName = (string)reader["ASGName"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshASGByProductType(int nProductType)//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ASGID, ASGName from v_ProductDetails Where ProductType=? Group By ASGID, ASGName Order by ASGName ";
                cmd.Parameters.AddWithValue("ProductType", nProductType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nASGID = (int)reader["ASGID"];
                    _sASGName = (string)reader["ASGName"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByBrandID()//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select BrandID, BrandDesc from v_ProductDetails Where BrandID=? Group By BrandID, BrandDesc Order by BrandDesc ";
                cmd.Parameters.AddWithValue("BrandID",_nBrandID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBrandID = (int)reader["BrandID"];
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

        public int GetMaxPriceID(int nProductID)//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nPriceID = 0;
            try
            {
                cmd.CommandText = "select MAX(PriceID) as PriceID from t_FinishedGoodsPrice Where ProductID = " + nProductID + " ";
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nPriceID = (int)reader["PriceID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nPriceID;
        }
        public int GetMaxSmartWarrantyID(int nProductID, int nSmartWarrantyTenure)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nSmartWarrantyID = 0;
            try
            {
                cmd.CommandText = "select MAX(SmartWarrantyID) as SmartWarrantyID from t_ExtendedWarrantyItem Where ProductID = " + nProductID + " and SmartWarrantyTenure = "+ nSmartWarrantyTenure + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nSmartWarrantyID = (int)reader["SmartWarrantyID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nSmartWarrantyID;
        }
        public bool CheckShadowProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * From t_SCMShadowPrice a,v_ProductDetails b where a.ProductID=b.ProductID and ProductCode= ?";
            cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
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
        public void UpdateWebMapping()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_Product SET IsEcomSync=? WHERE ProductID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsEcomSync", _bIsEcomSync);
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



    public class ProductDetails : CollectionBase
    {
        public ProductDetail this[int i]
        {
            get { return (ProductDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductDetail oProductDetail)
        {
            InnerList.Add(oProductDetail);
        }

        public int GetIndexAG(int nAGID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AGID == nAGID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexASG(int nASGID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ASGID == nASGID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexMAG(int nMAGID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MAGID == nMAGID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexPG(int nPGID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PGID == nPGID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshASG()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ASGID, ASGName from v_ProductDetails Group By ASGID, ASGName Order by ASGName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();

                    oProductDetail.ASGID = (int)reader["ASGID"];
                    oProductDetail.ASGName = (string)reader["ASGName"];

                    InnerList.Add(oProductDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetIndexBrand(int nBrandID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BrandID == nBrandID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RefreshBrand()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select BrandID, BrandDesc from v_ProductDetails Group By BrandID, BrandDesc Order by BrandDesc ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();

                    oProductDetail.BrandID = (int)reader["BrandID"];
                    oProductDetail.BrandDesc = (string)reader["BrandDesc"];

                    InnerList.Add(oProductDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public ProductDetails GetBrandName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select SubBrandName from v_ProductDetails group by SubBrandName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.SubBrandName = (string)reader["SubBrandName"];
                    InnerList.Add(oProductDetail);
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

        public ProductDetails GetPGName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select PGName from v_ProductDetails group by PGName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.PGName = (string)reader["PGName"];
                    InnerList.Add(oProductDetail);
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
        
        public ProductDetails GetMAGName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select MAGName from V_Productdetails group by MAGName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.MAGName = (string)reader["MAGName"];
                    InnerList.Add(oProductDetail);
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
        public ProductDetails GetASG(int nProductType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ASGID, ASGName from V_Productdetails Where ProductType=? group by ASGID, ASGName";

            cmd.Parameters.AddWithValue("ProductType", nProductType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ASGID = (int)reader["ASGID"];
                    oProductDetail.ASGName = (string)reader["ASGName"];
                    InnerList.Add(oProductDetail);
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

        public ProductDetails GetASGName(string sMAGName)
        {
            int CarryMAGID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select MAGID from V_Productdetails where MAGName='" + sMAGName + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oMAGID = new ProductDetail();
                    CarryMAGID = (int)reader["MAGID"];

                }
                reader.Close();
                sSql = "select ASGName from V_Productdetails where MAGID='" + CarryMAGID + "'group by ASGName";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    ProductDetail oASGName = new ProductDetail();
                    oASGName.ASGName = (string)reader1["ASGName"];
                    InnerList.Add(oASGName);
                }
                reader1.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

        public void GetPGNameForSalesPlan()
        {
            string sSql = "";
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (Utility.CompanyInfo == "TEL")
            {
                sSql = "select Distinct PGID, PGName from v_productDetails Where PGID IN (4,1,6) Order by PGName ASC ";
            }

            if (Utility.CompanyInfo == "BLL")
            {
                sSql = "select Distinct PGID, PGName from v_productDetails Where PGID IN (8) and ASGID in (125,126) Order by PGName ASC ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();

                    oProductDetail.PGID = (int)reader["PGID"];
                    oProductDetail.PGName = (string)reader["PGName"];

                    InnerList.Add(oProductDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMAGByPG()
        {
            string sSql = "";
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSql = "select Distinct MAGID, MAGName from v_productDetails ";

            ProductDetail oProductDetail;

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductDetail = new ProductDetail();

                    oProductDetail.MAGID = (int)reader["MAGID"];
                    oProductDetail.MAGName = (string)reader["MAGName"];

                    InnerList.Add(oProductDetail);
                }
                reader.Close();

                oProductDetail = new ProductDetail();
                oProductDetail.MAGID = -1;
                oProductDetail.MAGName = "ALL";
                InnerList.Add(oProductDetail);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetASGAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select Distinct ASGID, ASGName from V_Productdetails";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oASG = new ProductDetail();
                    oASG.ASGID = (int)reader["ASGID"];
                    oASG.ASGName = (string)reader["ASGName"];

                    InnerList.Add(oASG);
                }
                reader.Close();
                ProductDetail _oASG = new ProductDetail();
                _oASG.ASGID = -1;
                _oASG.ASGName = "ALL";
                InnerList.Add(_oASG);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
  
        }

        public void GetAGByASG(int nASGId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select Distinct AGID, AGName from V_Productdetails where ASGID=" + nASGId + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oAG = new ProductDetail();
                    oAG.AGName = (string)reader["AGName"];
                    oAG.AGID = (int)reader["AGID"];

                    InnerList.Add(oAG);
                }
                reader.Close();
                ProductDetail _oAG = new ProductDetail();
                _oAG.AGName = "ALL";
                _oAG.AGID = -1;
                
                InnerList.Add(_oAG);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetAGAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select Distinct AGID, AGName from V_Productdetails";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oAG = new ProductDetail();
                    oAG.AGName = (string)reader["AGName"];
                    oAG.AGID = (int)reader["AGID"];
                    InnerList.Add(oAG);
                }
                reader.Close();
                ProductDetail _oAG = new ProductDetail();
                _oAG.AGName = "ALL";
                _oAG.AGID = -1;
                InnerList.Add(_oAG);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetMAGAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select MAGID, MAGName, MAGSort from (select Distinct MAGID, MAGName, MAGSort from V_Productdetails) a where MAGID IS NOT Null order by MAGSort";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oMAG = new ProductDetail();
                    oMAG.MAGID = (int)reader["MAGID"];
                    oMAG.MAGName = (string)reader["MAGName"];

                    InnerList.Add(oMAG);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetASGByMAG(int nMAGID)
        {
            string sSql = "";
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSql = "select Distinct ASGID, ASGName from v_productDetails where MAGID=" + nMAGID + " ";

            ProductDetail oProductDetail;

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProductDetail = new ProductDetail();

                    oProductDetail.ASGID = (int)reader["ASGID"];
                    oProductDetail.ASGName = (string)reader["ASGName"];

                    InnerList.Add(oProductDetail);
                }
                reader.Close();

                oProductDetail = new ProductDetail();
                oProductDetail.ASGID = -1;
                oProductDetail.ASGName = "ALL";
                InnerList.Add(oProductDetail);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //Modified by: Arif Khan 13-Apr-2014
        //
        //Modified by: Arif Khan 13-Apr-2014
        //
        public void RefreshBySearch(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nSubBrandID, Dictionary.GeneralStatus nStatus, string sCode, string sName, int nItemCetagory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From (Select * From " +
                        "( " +
                        "Select a.*,b.VATType,b.IsVatApplicableonNetPrice,b.PetName,isnull(c.VATCP,0) VATCP From    " +
                        "(SELECT * FROM v_productdetails) a  " +
                        "Left outer Join  " +
                        "(Select * From t_Product) b   " +
                        "on a.ProductID = b.ProductID  " +
                        "left outer join  " +
                        "(  " +
                        "Select ProductID, max(isnull(VATCP, CostPrice)) VATCP  " +
                        "From t_FinishedGoodsPrice where IsCurrent = 1  " +
                        "group by ProductID  " +
                        ") c on a.ProductID = c.ProductID  " +
                        ") a) main ";

            string sClause = ""; // = " Where ItemCategory='" + nItemCetagory + "' ";

            if (nPGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where PGID =? ";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }
                else
                {
                    sClause = sClause + " AND PGID = ? ";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }
            }
            if (nMAGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where MAGID =? ";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }
                else
                {
                    sClause = sClause + " AND MAGID = ? ";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }
            }

            if (nASGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ASGID =? ";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }
                else
                {
                    sClause = sClause + " AND ASGID = ? ";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }
            }

            if (nAGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where AGID =? ";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }
                else
                {
                    sClause = sClause + " AND AGID = ? ";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }
            }

            if (nBrandID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where BrandID =? ";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }
                else
                {
                    sClause = sClause + " AND BrandID = ? ";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }
            }

            if (nSubBrandID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where SubBrandID =? ";
                    cmd.Parameters.AddWithValue("SubBrandID", nSubBrandID);
                }
                else
                {
                    sClause = sClause + " AND SubBrandID = ? ";
                    cmd.Parameters.AddWithValue("SubBrandID", nSubBrandID);
                }
            }

            if (nStatus != Dictionary.GeneralStatus.All)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where IsActive=? ";
                    cmd.Parameters.AddWithValue("IsActive", 2 - nStatus);
                }
                else
                {
                    sClause = sClause + " AND IsActive = ? ";
                    cmd.Parameters.AddWithValue("IsActive", 2 - nStatus);
                }
            }

            if (sCode != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ProductCode = ? ";
                    cmd.Parameters.AddWithValue("ProductCode", sCode);
                }
                else
                {
                    sClause = sClause + " AND ProductCode =? ";
                    cmd.Parameters.AddWithValue("ProductCode", sCode);
                }
            }

            if (sName != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ProductName Like ? ";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sName + "%");
                }
                else
                {
                    sClause = sClause + " AND ProductName Like ? ";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sName + "%");
                }
            }
            sClause = sClause + " Order by ProductCode";
            try
            {
                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();

                    if (reader["IsVatApplicableonNetPrice"] != DBNull.Value)
                        oProductDetail.IsVatApplicableonNetPrice = Convert.ToInt32(reader["IsVatApplicableonNetPrice"].ToString());
                    else oProductDetail.IsVatApplicableonNetPrice = 0;


                    if (reader["VATType"] != DBNull.Value)
                        oProductDetail.VATType = Convert.ToInt32(reader["VATType"].ToString());
                    else oProductDetail.VATType = 0;


                    if (reader["SupplyType"] != DBNull.Value)
                        oProductDetail.SupplyType = Convert.ToInt32(reader["SupplyType"].ToString());
                    else oProductDetail.SupplyType = 1;

                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.ProductDesc = (string)reader["ProductDesc"];
                    try
                    {
                        oProductDetail.IsEcomSync = Convert.ToInt32(reader["IsEcomSync"].ToString());
                    }
                    catch
                    {
                        oProductDetail.IsEcomSync = 0;
                    }


                    if (reader["PetName"] != DBNull.Value)
                    {
                        oProductDetail.PetName = (string)reader["PetName"];
                    }
                    else
                    {
                        oProductDetail.PetName = "";
                    }

                    if (reader["ProductModel"] != DBNull.Value)
                    {
                        oProductDetail.ProductModel = (string)reader["ProductModel"];
                    }
                    else
                    {
                        oProductDetail.ProductModel = "";
                    }
                    if (reader["PGName"] != DBNull.Value)
                        oProductDetail.PGName = (string)reader["PGName"];
                    else oProductDetail.PGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oProductDetail.MAGName = (string)reader["MAGName"];
                    else oProductDetail.MAGName = "";
                    if (reader["ASGName"] != DBNull.Value)
                        oProductDetail.ASGName = (string)reader["ASGName"];
                    else oProductDetail.ASGName = "";
                    if (reader["AGName"] != DBNull.Value)
                        oProductDetail.AGName = (string)reader["AGName"];
                    else oProductDetail.AGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oProductDetail.BrandDesc = (string)reader["BrandDesc"];
                    else oProductDetail.BrandDesc = "";
                    if (reader["SubBrandName"] != DBNull.Value)
                        oProductDetail.SubBrandName = (string)reader["SubBrandName"];
                    else oProductDetail.SubBrandName = "";
                    oProductDetail.IsActive = Convert.ToInt32(reader["IsActive"]);
                    if (reader["ProductModel"] != DBNull.Value)
                        oProductDetail.ProductModel = reader["ProductModel"].ToString();
                    else oProductDetail.ProductModel = "";
                    if (reader["NSP"] != DBNull.Value)
                        oProductDetail.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else oProductDetail.NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;

                    if (reader["VATCP"] != DBNull.Value)
                        oProductDetail.VATCP = Convert.ToDouble(reader["VATCP"].ToString());
                    else oProductDetail.VATCP = 0;


                    //if (reader["PriceRemarks"] != DBNull.Value)
                    //    oProductDetail.PriceRemarks = (string)reader["PriceRemarks"];
                    //else oProductDetail.PriceRemarks = "";
                    //if (Utility.CompanyInfo == "TML")
                    //{
                    //    if (reader["MRP"] != DBNull.Value)
                    //        oProductDetail.MRP = Convert.ToDouble(reader["MRP"].ToString());
                    //    else oProductDetail.MRP = 0;
                    //}
                    if (reader["CostPrice"] != DBNull.Value)
                        oProductDetail.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else oProductDetail.CostPrice = 0;
                    if (reader["VAT"] != DBNull.Value)
                        oProductDetail.Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else oProductDetail.Vat = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                        oProductDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oProductDetail.TradePrice = 0;
                    if (reader["SpecialPrice"] != DBNull.Value)
                        oProductDetail.SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else oProductDetail.SpecialPrice = 0;
                    if (reader["ItemCategory"] != DBNull.Value)
                        oProductDetail.ItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else oProductDetail.ItemCategory = 1;
                    if (reader["IsBarcodeItem"] != DBNull.Value)
                        oProductDetail.IsBarcodeItem = Convert.ToInt32(reader["IsBarcodeItem"].ToString());
                    else oProductDetail.IsBarcodeItem = 1;

                    if (reader["InventoryCategory"] != DBNull.Value)
                        oProductDetail.InventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else oProductDetail.InventoryCategory = -1;

                    if (reader["VATApplicable"] != DBNull.Value)
                        oProductDetail.VATApplicable = Convert.ToInt32(reader["VATApplicable"].ToString());
                    else oProductDetail.VATApplicable = 0;


                    if (reader["IsActive"] != DBNull.Value)
                        oProductDetail.IsActive = Convert.ToInt32(reader["IsActive"].ToString());
                    else oProductDetail.IsActive = 0;


                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySearchRT(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nSubBrandID, Dictionary.GeneralStatus nStatus, string sCode, string sName, int nItemCetagory,int nWHID,string sCurrentStock)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from (SELECT a.*,b.VATType,b.IsVatApplicableonNetPrice,b.PetName,isnull((CurrentStock-isnull(TransitStock,0)),0) as CurrentStock,,isnull(c.VATCP,0) VATCP  " +
                        "FROM v_productdetails a  " +
                        "left outer join t_Product b on a.ProductID = b.ProductID  " +
                        "left outer join  " +
                        "(  " +
                        "Select ProductID, max(isnull(VATCP, CostPrice)) VATCP  " +
                        "From t_FinishedGoodsPrice where IsCurrent = 1  " +
                        "group by ProductID  " +
                        ") d on a.ProductID = d.ProductID  " +
                        "Left Outer Join t_ProductStock c on a.ProductID = c.ProductID where WarehouseID = " + nWHID + ") main  ";


            string sClause = ""; // = " Where ItemCategory='" + nItemCetagory + "' ";
            if (sCurrentStock != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = " Where  CurrentStock" + sCurrentStock + " ";

                }
                else
                {
                    sClause = sClause + " AND CurrentStock" + sCurrentStock + " ";

                }
            }


            if (nPGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = " Where  PGID =? ";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }
                else
                {
                    sClause = sClause + " AND PGID = ? ";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }
            }
            if (nMAGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where MAGID =? ";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }
                else
                {
                    sClause = sClause + " AND MAGID = ? ";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }
            }

            if (nASGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ASGID =? ";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }
                else
                {
                    sClause = sClause + " AND ASGID = ? ";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }
            }

            if (nAGID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where AGID =? ";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }
                else
                {
                    sClause = sClause + " AND AGID = ? ";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }
            }

            if (nBrandID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where BrandID =? ";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }
                else
                {
                    sClause = sClause + " AND BrandID = ? ";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }
            }

            if (nSubBrandID != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where SubBrandID =? ";
                    cmd.Parameters.AddWithValue("SubBrandID", nSubBrandID);
                }
                else
                {
                    sClause = sClause + " AND SubBrandID = ? ";
                    cmd.Parameters.AddWithValue("SubBrandID", nSubBrandID);
                }
            }

            if (nStatus != Dictionary.GeneralStatus.All)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where IsActive=? ";
                    cmd.Parameters.AddWithValue("IsActive", 2 - nStatus);
                }
                else
                {
                    sClause = sClause + " AND IsActive = ? ";
                    cmd.Parameters.AddWithValue("IsActive", 2 - nStatus);
                }
            }

            if (sCode != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ProductCode = ? ";
                    cmd.Parameters.AddWithValue("ProductCode", sCode);
                }
                else
                {
                    sClause = sClause + " AND ProductCode =? ";
                    cmd.Parameters.AddWithValue("ProductCode", sCode);
                }
            }

            if (sName != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ProductName Like ? ";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sName + "%");
                }
                else
                {
                    sClause = sClause + " AND ProductName Like ? ";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sName + "%");
                }
            }
            sClause = sClause + " Order by ProductCode";
            try
            {
                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    //oProductDetail.VATType = (int)reader["VATType"];
                    if (reader["CurrentStock"] != DBNull.Value)
                        oProductDetail.CurrentStock = Convert.ToInt32(reader["CurrentStock"].ToString());
                    else oProductDetail.CurrentStock = 0;

                    if (reader["IsVatApplicableonNetPrice"] != DBNull.Value)
                        oProductDetail.IsVatApplicableonNetPrice = Convert.ToInt32(reader["IsVatApplicableonNetPrice"].ToString());
                    else oProductDetail.IsVatApplicableonNetPrice = 0;


                    if (reader["VATType"] != DBNull.Value)
                        oProductDetail.VATType = Convert.ToInt32(reader["VATType"].ToString());
                    else oProductDetail.VATType = 0;


                    if (reader["SupplyType"] != DBNull.Value)
                        oProductDetail.SupplyType = Convert.ToInt32(reader["SupplyType"].ToString());
                    else oProductDetail.SupplyType = 1;

                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.ProductDesc = (string)reader["ProductDesc"];

                    if (reader["PetName"] != DBNull.Value)
                    {
                        oProductDetail.PetName = (string)reader["PetName"];
                    }
                    else
                    {
                        oProductDetail.PetName = "";
                    }

                    if (reader["ProductModel"] != DBNull.Value)
                    {
                        oProductDetail.ProductModel = (string)reader["ProductModel"];
                    }
                    else
                    {
                        oProductDetail.ProductModel = "";
                    }
                    if (reader["PGName"] != DBNull.Value)
                        oProductDetail.PGName = (string)reader["PGName"];
                    else oProductDetail.PGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oProductDetail.MAGName = (string)reader["MAGName"];
                    else oProductDetail.MAGName = "";
                    if (reader["ASGName"] != DBNull.Value)
                        oProductDetail.ASGName = (string)reader["ASGName"];
                    else oProductDetail.ASGName = "";
                    if (reader["AGName"] != DBNull.Value)
                        oProductDetail.AGName = (string)reader["AGName"];
                    else oProductDetail.AGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oProductDetail.BrandDesc = (string)reader["BrandDesc"];
                    else oProductDetail.BrandDesc = "";
                    if (reader["SubBrandName"] != DBNull.Value)
                        oProductDetail.SubBrandName = (string)reader["SubBrandName"];
                    else oProductDetail.SubBrandName = "";
                    oProductDetail.IsActive = Convert.ToInt32(reader["IsActive"]);
                    if (reader["ProductModel"] != DBNull.Value)
                        oProductDetail.ProductModel = reader["ProductModel"].ToString();
                    else oProductDetail.ProductModel = "";
                    if (reader["NSP"] != DBNull.Value)
                        oProductDetail.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else oProductDetail.NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;
                    //if (reader["PriceRemarks"] != DBNull.Value)
                    //    oProductDetail.PriceRemarks = (string)reader["PriceRemarks"];
                    //else oProductDetail.PriceRemarks = "";
                    //if (Utility.CompanyInfo == "TML")
                    //{
                    //    if (reader["MRP"] != DBNull.Value)
                    //        oProductDetail.MRP = Convert.ToDouble(reader["MRP"].ToString());
                    //    else oProductDetail.MRP = 0;
                    //}

                    if (reader["VATCP"] != DBNull.Value)
                        oProductDetail.VATCP = Convert.ToDouble(reader["VATCP"].ToString());
                    else oProductDetail.VATCP = 0;

                    if (reader["CostPrice"] != DBNull.Value)
                        oProductDetail.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else oProductDetail.CostPrice = 0;
                    if (reader["VAT"] != DBNull.Value)
                        oProductDetail.Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else oProductDetail.Vat = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                        oProductDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oProductDetail.TradePrice = 0;
                    if (reader["SpecialPrice"] != DBNull.Value)
                        oProductDetail.SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else oProductDetail.SpecialPrice = 0;
                    if (reader["ItemCategory"] != DBNull.Value)
                        oProductDetail.ItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else oProductDetail.ItemCategory = 1;
                    if (reader["IsBarcodeItem"] != DBNull.Value)
                        oProductDetail.IsBarcodeItem = Convert.ToInt32(reader["IsBarcodeItem"].ToString());
                    else oProductDetail.IsBarcodeItem = 1;

                    if (reader["InventoryCategory"] != DBNull.Value)
                        oProductDetail.InventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else oProductDetail.InventoryCategory = -1;

                    if (reader["VATApplicable"] != DBNull.Value)
                        oProductDetail.VATApplicable = Convert.ToInt32(reader["VATApplicable"].ToString());
                    else oProductDetail.VATApplicable = 0;


                    if (reader["IsActive"] != DBNull.Value)
                        oProductDetail.IsActive = Convert.ToInt32(reader["IsActive"].ToString());
                    else oProductDetail.IsActive = 0;


                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySearchPrice(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nSubBrandID, Dictionary.GeneralStatus nStatus, string sCode, string sName, int nItemCetagory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM v_productdetails where 1=1";



            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID = " + nPGID + " ";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID = " + nMAGID + " ";
            }
            
            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID = " + nASGID + " ";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID = " + nAGID + " ";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID = " + nBrandID + " ";
            }

            if (nSubBrandID != -1)
            {
                sSql = sSql + " AND SubBrandID = " + nSubBrandID + " ";
            }

            if (nStatus != Dictionary.GeneralStatus.All)
            {
                sSql = sSql + " AND IsActive = " + (2 - nStatus) + " ";
            }

            if (sCode != "")
            {
                sSql = sSql + " AND ProductCode = '" + sCode + "' ";
            }

            if (sName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sName + "%' ";
            }


            sSql = sSql + " order by ProductCode ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.ProductDesc = (string)reader["ProductDesc"];
                    if (reader["ProductModel"] != DBNull.Value)
                    {
                        oProductDetail.ProductModel = (string)reader["ProductModel"];
                    }
                    else
                    {
                        oProductDetail.ProductModel = "";
                    }
                    if (reader["PGName"] != DBNull.Value)
                        oProductDetail.PGName = (string)reader["PGName"];
                    else oProductDetail.PGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oProductDetail.MAGName = (string)reader["MAGName"];
                    else oProductDetail.MAGName = "";
                    if (reader["ASGName"] != DBNull.Value)
                        oProductDetail.ASGName = (string)reader["ASGName"];
                    else oProductDetail.ASGName = "";
                    if (reader["AGName"] != DBNull.Value)
                        oProductDetail.AGName = (string)reader["AGName"];
                    else oProductDetail.AGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oProductDetail.BrandDesc = (string)reader["BrandDesc"];
                    else oProductDetail.BrandDesc = "";
                    if (reader["SubBrandName"] != DBNull.Value)
                        oProductDetail.SubBrandName = (string)reader["SubBrandName"];
                    else oProductDetail.SubBrandName = "";
                    oProductDetail.IsActive = Convert.ToInt32(reader["IsActive"]);
                    if (reader["ProductModel"] != DBNull.Value)
                        oProductDetail.ProductModel = reader["ProductModel"].ToString();
                    else oProductDetail.ProductModel = "";
                    if (reader["NSP"] != DBNull.Value)
                        oProductDetail.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else oProductDetail.NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;
                    if (reader["PriceRemarks"] != DBNull.Value)
                        oProductDetail.PriceRemarks = (string)reader["PriceRemarks"];
                    else oProductDetail.PriceRemarks = "";
                    //if (Utility.CompanyInfo == "TML")
                    //{
                    //    if (reader["MRP"] != DBNull.Value)
                    //        oProductDetail.MRP = Convert.ToDouble(reader["MRP"].ToString());
                    //    else oProductDetail.MRP = 0;
                    //}
                    if (reader["CostPrice"] != DBNull.Value)
                        oProductDetail.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else oProductDetail.CostPrice = 0;
                    if (reader["VAT"] != DBNull.Value)
                        oProductDetail.Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else oProductDetail.Vat = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                        oProductDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oProductDetail.TradePrice = 0;
                    if (reader["SpecialPrice"] != DBNull.Value)
                        oProductDetail.SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else oProductDetail.SpecialPrice = 0;
                    if (reader["ItemCategory"] != DBNull.Value)
                        oProductDetail.ItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else oProductDetail.ItemCategory = 1;
                    if (reader["IsBarcodeItem"] != DBNull.Value)
                        oProductDetail.IsBarcodeItem = Convert.ToInt32(reader["IsBarcodeItem"].ToString());
                    else oProductDetail.IsBarcodeItem = 1;

                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, string sCode, string sName, int nItemCetagory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "SELECT * FROM v_productdetails Where 1=1 ";
            
            if (nPGID != -1)
            {
                sSql = sSql + " and PGID =" + nPGID + " ";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " and MAGID=" + nMAGID + " ";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " and ASGID =" + nASGID + " ";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " and AGID =" + nAGID + " ";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " and BrandID =" + nBrandID + " ";
            }

           

            if (sCode != "")
            {
                sSql = sSql + " and ProductCode = '" + sCode + "' ";
            }

            if (sName != "")
            {
                sSql = sSql + " and ProductName Like '%" + sName + "%' ";
            }
            sSql = sSql + " Order by RSP DESC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    if (reader["ProductModel"] != DBNull.Value)
                    {
                        oProductDetail.ProductModel = (string)reader["ProductModel"];
                    }
                    else
                    {
                        oProductDetail.ProductModel = "";
                    }
                    if (reader["PGName"] != DBNull.Value)
                        oProductDetail.PGName = (string)reader["PGName"];
                    else oProductDetail.PGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oProductDetail.MAGName = (string)reader["MAGName"];
                    else oProductDetail.MAGName = "";
                    if (reader["ASGName"] != DBNull.Value)
                        oProductDetail.ASGName = (string)reader["ASGName"];
                    else oProductDetail.ASGName = "";
                    if (reader["AGName"] != DBNull.Value)
                        oProductDetail.AGName = (string)reader["AGName"];
                    else oProductDetail.AGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oProductDetail.BrandDesc = (string)reader["BrandDesc"];
                    else oProductDetail.BrandDesc = "";
                    if (reader["ProductModel"] != DBNull.Value)
                        oProductDetail.ProductModel = reader["ProductModel"].ToString();
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;
                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPOSSearch()
        {
         
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM v_productdetails ";        
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();                
                    oProductDetail.PriceID = (int)reader["PriceID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.ProductDesc = (string)reader["ProductDesc"];
                    if (reader["NSP"] != DBNull.Value)
                        oProductDetail.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else oProductDetail.NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;
                    if (reader["CostPrice"] != DBNull.Value)
                        oProductDetail.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else oProductDetail.CostPrice = 0;
                    if (reader["VAT"] != DBNull.Value)
                        oProductDetail.Vat = Convert.ToDouble(reader["VAT"].ToString());
                    else oProductDetail.Vat = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                        oProductDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else oProductDetail.TradePrice = 0;
                    if (reader["SpecialPrice"] != DBNull.Value)
                        oProductDetail.SpecialPrice = Convert.ToDouble(reader["SpecialPrice"].ToString());
                    else oProductDetail.SpecialPrice = 0;

                    oProductDetail.PGID = (int)reader["PGID"];
                    oProductDetail.MAGID = (int)reader["MAGID"];
                    oProductDetail.AGID = (int)reader["AGID"];
                    oProductDetail.ASGID = (int)reader["ASGID"];
                    oProductDetail.BrandID = (int)reader["BrandID"];

                  
                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPriceInfo()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_FinishedGoodsPrice ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.PriceID = (int)reader["PriceID"];
                   
                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshShadowPrice(string sCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select ShadowPriceID,a.ProductID,ProductCode,ProductName,BrandDesc, " +
                   "AGName,ASGName,MAGName,PGName,ShadowPrice,CreateDate,CreateUserID " +
                   "From t_SCMShadowPrice a,v_ProductDetails b where a.ProductID=b.ProductID";

            
            if (sCode != "")
            {
                sSql = sSql + " and ProductCode = '" + sCode + "' ";
            }

            sSql = sSql + " Order by a.ProductID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ShadowPriceID = (int)reader["ShadowPriceID"];
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    
                    if (reader["PGName"] != DBNull.Value)
                        oProductDetail.PGName = (string)reader["PGName"];
                    else oProductDetail.PGName = "";
                    if (reader["MAGName"] != DBNull.Value)
                        oProductDetail.MAGName = (string)reader["MAGName"];
                    else oProductDetail.MAGName = "";
                    if (reader["ASGName"] != DBNull.Value)
                        oProductDetail.ASGName = (string)reader["ASGName"];
                    else oProductDetail.ASGName = "";
                    if (reader["AGName"] != DBNull.Value)
                        oProductDetail.AGName = (string)reader["AGName"];
                    else oProductDetail.AGName = "";
                    if (reader["BrandDesc"] != DBNull.Value)
                        oProductDetail.BrandDesc = (string)reader["BrandDesc"];
                    else oProductDetail.BrandDesc = "";

                    if (reader["ShadowPrice"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["ShadowPrice"].ToString());
                    else oProductDetail.RSP = 0;
                    oProductDetail.CreateDate = (DateTime)reader["CreateDate"];
                    oProductDetail.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshCACProduct(int nBrandID, string sCode, string sName)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(    " +
                    "Select a.*,isnull(CPUSD,0) CPUSD,isnull(CPBDT,0) CPBDT,isnull(RSP,0) RSP,  " +
                    "isnull(isnull(CurrentStock,0)-isnull(BookingStock,0),0) as CurrentStock From     " +
                    "(    " +
                    "Select * From     " +
                    "(    " +
                    "Select ProductID,ProductCode,ProductName,Description,Model,    " +
                    "a.BrandID,BrandDesc as BrandName,AGID,AG.PDTGroupName as AG,    " +
                    "ASG.PdtGroupID as ASGID,ASG.PDTGroupName as ASG,    " +
                    "MAG.PdtGroupID as MAGID,MAG.PDTGroupName as MAG,    " +
                    "PG.PdtGroupID as PGID,PG.PDTGroupName as PG,    " +
                    "a.CreateDate,a.CreateUserID,a.IsActive    " +
                    "From t_CACProduct a,t_Brand b,t_ProductGroup AG,t_ProductGroup ASG,    " +
                    "t_ProductGroup MAG,t_ProductGroup PG  where a.BrandID=b.BrandID     " +
                    "and a.AGID=AG.PdtGroupID and AG.ParentID=ASG.PdtGroupID and     " +
                    "ASG.ParentID=MAG.PdtGroupID and  MAG.ParentID=PG.PdtGroupID     " +
                    ") x    " +
                    ") a    " +
                    "Left Outer Join     " +
                    "(    " +
                    "Select * From t_CACFinishedGoodsPrice where IsCurrent=1    " +
                    ") b    " +
                    "on a.ProductID=b.ProductID    " +
                    "Left Outer Join     " +
                    "(    " +
                    "Select * From t_CACProductStock   " +
                    ") c    " +
                    "on a.ProductID=c.ProductID   " +
                    ") Main where 1=1";

            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sCode + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sName + "%'";
            }
            sSql = sSql + " Order by ProductID Desc";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.IsActive = (int)reader["IsActive"];
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.ProductDesc = (string)reader["Description"];
                    if (reader["Model"] != DBNull.Value)
                    {
                        oProductDetail.ProductModel = (string)reader["Model"];
                    }
                    else
                    {
                        oProductDetail.ProductModel = "";
                    }
                    oProductDetail.BrandID = (int)reader["BrandID"];
                    if (reader["BrandName"] != DBNull.Value)
                        oProductDetail.BrandDesc = (string)reader["BrandName"];
                    else oProductDetail.BrandDesc = "";
                    oProductDetail.PGID = (int)reader["PGID"];
                    if (reader["PG"] != DBNull.Value)
                        oProductDetail.PGName = (string)reader["PG"];
                    else oProductDetail.PGName = "";
                    oProductDetail.MAGID = (int)reader["MAGID"];
                    if (reader["MAG"] != DBNull.Value)
                        oProductDetail.MAGName = (string)reader["MAG"];
                    else oProductDetail.MAGName = "";
                    oProductDetail.ASGID = (int)reader["ASGID"];
                    if (reader["ASG"] != DBNull.Value)
                        oProductDetail.ASGName = (string)reader["ASG"];
                    else oProductDetail.ASGName = "";
                    oProductDetail.AGID = (int)reader["AGID"];
                    if (reader["AG"] != DBNull.Value)
                        oProductDetail.AGName = (string)reader["AG"];
                    oProductDetail.IsActive = Convert.ToInt32(reader["IsActive"]);
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;
                    if (reader["CPBDT"] != DBNull.Value)
                        oProductDetail.CPBDT = Convert.ToDouble(reader["CPBDT"].ToString());
                    else oProductDetail.CPBDT = 0;
                    if (reader["CPUSD"] != DBNull.Value)
                        oProductDetail.CPUSD = Convert.ToDouble(reader["CPUSD"].ToString());
                    else oProductDetail.CPUSD = 0;

                    if (reader["CurrentStock"] != DBNull.Value)
                        oProductDetail.CurrentStock = Convert.ToInt32(reader["CurrentStock"].ToString());
                    else oProductDetail.CurrentStock = 0;
           
                    InnerList.Add(oProductDetail);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #region DMS
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (Utility.Module == "DMS")
                sSql = "SELECT * FROM v_ProductDetails Where ProductID not in ('" + Utility.DMSProProductID + "') and NSP>0 and ProductCode not in (14051,14048,14049,14050,14056,14057,14019,14021,14059,14061,14064,14071,14072,14079,14080,14081) order by ASGID,BrandID,ProductID,ProductName ";
            else sSql = "SELECT * FROM v_ProductDetails order by ProductName";
            try
            {
                cmd.CommandText = sSql;
              
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.ProductDesc = reader["ProductDesc"].ToString();                    
                    if (reader["NSP"] != DBNull.Value)
                        oProductDetail.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else oProductDetail.NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;


                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void MRefresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select Costprice,NSP,RSP,productid,productcode, substring (productname,16,23)as productname" 
                    + " from v_productdetails  where ProductType=1 order by ProductName";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    if (reader["CostPrice"] != DBNull.Value)
                        oProductDetail.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    if (reader["NSP"] != DBNull.Value)
                        oProductDetail.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else oProductDetail.NSP = 0;
                    if (reader["RSP"] != DBNull.Value)
                        oProductDetail.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else oProductDetail.RSP = 0;

                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       
        #endregion

        public void RefreshGiftProduct(string sCode,string sName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM v_productdetails WHERE IsActive=1 and ItemCategory=? ";
            cmd.Parameters.AddWithValue("ItemCategory", (short)Dictionary.ItemCategory.Gift_Item);
            if (sCode != "")
            {
                sCode = "%" + sCode + "%";
                sSql = sSql + "AND ProductCode LIKE '" + sCode + "'";
            }
            if (sName != "")
            {
                sName = "%" + sName + "%";
                sSql = sSql + " AND ProductName LIKE '" + sName + "'";
            }
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"]; 

                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #region
        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public void GetPSIMAGByID(int _nPSIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select distinct MAGID,BrandID From t_SCMPSIItem a,v_ProductDetails b where PSIID = " + _nPSIID + " and a.ProductID = b.ProductID";
            
           

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.MAGID = (int)reader["MAGID"];
                    oProductDetail.BrandID = (int)reader["BrandID"];

                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSProduct POSGetProductDetail(DSProduct oDSProduct)
        {
            RefreshPOSSearch();

            oDSProduct = new DSProduct();
            foreach (ProductDetail oProductDetail in this)
            {
                DSProduct.ProductRow oProductRow = oDSProduct.Product.NewProductRow();

                oProductRow.ProductName = oProductDetail.ProductName;
                oProductRow.ProductCode = oProductDetail.ProductCode;
                oProductRow.ProductDesc = oProductDetail.ProductDesc;
                oProductRow.ProductID = oProductDetail.ProductID;
                oProductRow.StockQty = oProductDetail.StockByWarehouse;
                oProductRow.PGID = oProductDetail.PGID;
                oProductRow.MAGID = oProductDetail.MAGID;
                oProductRow.AGID = oProductDetail.AGID;
                oProductRow.ASGID = oProductDetail.ASGID;
                oProductRow.BrandID = oProductDetail.BrandID;

                oDSProduct.Product.AddProductRow(oProductRow);
                oDSProduct.AcceptChanges();
            }

            return oDSProduct;
        }

        #endregion

        public void RefreshVatProduct(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = "Select a.ProductID,Quantity,((UnitPrice+Charge)-Discount) as UnitPrice,DutyPrice,0.15 as DutyRate,  " +
                "(UnitPrice+Charge-Discount)-DutyPrice as Vat From   " +
                "(  " +
                "Select ProductID,isnull(UnitPrice,0) UnitPrice,   " +
                "isnull(sum(Quantity),0) Quantity,isnull(sum(Discount),0) Discount,  " +
                "isnull(sum(Charge),0) Charge,((isnull(UnitPrice,0)+isnull(sum(Charge),0))- isnull(sum(Discount),0))/1.15 as DutyPrice  From   " +
                "(  " +
                "Select ProductID,UnitPrice,Quantity,   " +
                "TotalDiscount,InvoiceAmount,   " +
                "(TotalDiscount/InvoiceAmount)*UnitPrice as Discount,(TotalCharge/InvoiceAmount)*UnitPrice as Charge From    " +
                "(   " +
                "Select a.InvoiceID,ProductID,Quantity,UnitPrice,Discount as TotalDiscount   " +
                "From t_SalesInvoiceDetail a,t_SalesInvoice b   " +
                "where a.InvoiceID=b.InvoiceID and a.invoiceID= " + nInvoiceID + " and IsFreeProduct=0   " +
                ") a   " +
                "Left Outer Join    " +
                "(Select InvoiceID,sum(Quantity*UnitPrice) InvoiceAmount   " +
                "From t_SalesInvoiceDetail where invoiceID= " + nInvoiceID + " and IsFreeProduct=0   " +
                "group by InvoiceID) b   " +
                "on a.invoiceID=b.InvoiceID  " +
                "left outer join  " +
                "(Select InvoiceID, sum(InstallationCharge+FreightCharge+otherCharge) as TotalCharge   " +
                "From t_SalesInvoiceOtherInfo where InvoiceID=" + nInvoiceID + "  " +
                "group by invoiceID) c   " +
                "on a.invoiceID=c.InvoiceID  " +
                "Union All   " +
                "Select ProductID,0 UnitPrice,FreeQty as Quantity,0 TotalDiscount,0 InvoiceAmount,0 Discount, 0 Charge  " +
                "From t_SalesInvoiceDetail where invoiceID= " + nInvoiceID + " and IsFreeProduct=1   " +
                ") Main  group by ProductID,UnitPrice   " +
                ") a";
            
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    if (reader["UnitPrice"] != DBNull.Value)
                        oProductDetail.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    else oProductDetail.UnitPrice = 0;
                    if (reader["DutyPrice"] != DBNull.Value)
                        oProductDetail.DutyPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    else oProductDetail.DutyPrice = 0;
                    oProductDetail.DutyRate = Convert.ToDouble(reader["DutyRate"].ToString());
                    oProductDetail.Vat = Convert.ToDouble(reader["Vat"].ToString());

                    InnerList.Add(oProductDetail);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshForSCMPSI(string sBrandDesc,string sMAGName,int nIc)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select isnull(CostPrice,0) CostPrice,InventoryCategory,ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,BrandDesc  " +
                        "From v_ProductDetails where BrandDesc='" + sBrandDesc + "' and MAGName='" + sMAGName + "'";

            if (nIc != -1)
            {
                sSql = sSql + " and InventoryCategory=" + nIc + "";
            }

            if (nIc != -1)
            {
                sSql = sSql + " and InventoryCategory NOT IN (" + (int)Dictionary.InventoryCate.Discontinue + "," + (int)Dictionary.InventoryCate.Aged + ")";
            }

            sSql = sSql + "  order by InventoryCategory,AGName,ProductCode";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();

                    oProductDetail.ProductID = (int)reader["ProductID"];
                    oProductDetail.ProductCode = (string)reader["ProductCode"];
                    oProductDetail.ProductName = (string)reader["ProductName"];
                    oProductDetail.AGName = (string)reader["AGName"];
                    oProductDetail.ASGName = (string)reader["ASGName"];
                    oProductDetail.MAGName = (string)reader["MAGName"];
                    oProductDetail.PGName = (string)reader["PGName"];
                    oProductDetail.BrandDesc = (string)reader["BrandDesc"];

                    oProductDetail.InventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    oProductDetail.CostPrice = (double)reader["CostPrice"];
                    InnerList.Add(oProductDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForSCProduct(int nOfferID)
        {
            InnerList.Clear();
            string sSql = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                sSql = " select * from t_ScratchCardOfferProductFor A, v_ProductDetails B where A.ProductID=B.ProductID ";

                //if (sProductID != "")
                //{
                //    sSql = sSql + " and A.ProductID in (" + sProductID + ")";
                //}

                sSql= sSql+" and ScratchCardOfferID="+ nOfferID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDetail oProductDetail = new ProductDetail();

                    oProductDetail.ProductCode = reader["ProductCode"].ToString();
                    oProductDetail.ProductName = reader["ProductName"].ToString();

                    if (reader["Vat"] != DBNull.Value)
                        oProductDetail.Vat = Convert.ToDouble(reader["Vat"].ToString());
                    else oProductDetail.Vat = 0;

                    InnerList.Add(oProductDetail);

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
