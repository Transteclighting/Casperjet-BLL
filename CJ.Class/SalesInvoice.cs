// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 19, 2011
// Time :  10:00 AM
// Description: Class for Sales Invoice.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;
using CJ.Class.POS;
using System.Net;
using System.Xml;

namespace CJ.Class
{
    public class SalesInvoiceItem
    {
        private long _InvoiceID;

        private int _nProductID;
        private long _Quantity;
        private double _UnitPrice;
        private double _CostPrice;
        private double _TradePrice;
        private double _VATAmount;
        private double _ProductDiscount;
        private double _SalesPersonBonus;
        private double _CustomerProfitMargin;
        private double _CustomerSellingExpense;
        private double _TradePromotion;
        private double _Advertisement;
        private double _RetailCommission;
        private double _ProductWarrenty;
        private double _PrimaryFreightCost;
        private double _OtherProvission;
        private double _AdjustedDPAmount;
        private double _AdjustedPWAmount;
        private double _AdjustedTPAmount;
        private double _PromotionalDiscount;
        private int _nIsFreeProduct;
        private int _nFreeQty;
        private string _sInvoiceNo;
        private string _sProductSerial;


        private int _nStockType;
        private int _nDefectiveType;
        private string _sFaultDescription;
        private string _sFaultRemarks;
        private string _sReason;
        private string _sJobNo;
        private double _VATLowerLimit;
        private double _VATUpperLimit;

        public int PriceCheck=0;
        public int StockType
        {
            get { return _nStockType; }
            set { _nStockType = value; }
        }
        public int DefectiveType
        {
            get { return _nDefectiveType; }
            set { _nDefectiveType = value; }
        }        
        public string FaultDescription
        {
            get { return _sFaultDescription; }
            set { _sFaultDescription = value; }
        }
        public string FaultRemarks
        {
            get { return _sFaultRemarks; }
            set { _sFaultRemarks = value; }
        }

        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value; }
        }
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        private int _SundryCustomerID;
        public int SundryCustomerID
        {
            get { return _SundryCustomerID; }
            set { _SundryCustomerID = value; }
        }

        private int _SpecialComponentWarranty;
        public int SpecialComponentWarranty
        {
            get { return _SpecialComponentWarranty; }
            set { _SpecialComponentWarranty = value; }
        }

        private DateTime _dWarrantyExpiryDate;
        public DateTime WarrantyExpiryDate
        {
            get { return _dWarrantyExpiryDate; }
            set { _dWarrantyExpiryDate = value; }
        }
        public string ProductSerial
        {
            get { return _sProductSerial; }
            set { _sProductSerial = value; }
        }

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        private int _nDataID;
        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value; }
        }
        private int _nSlabID;
        public int SlabID
        {
            get { return _nSlabID; }
            set { _nSlabID = value; }
        }
        private int _nOfferID;
        public int OfferID
        {
            get { return _nOfferID; }
            set { _nOfferID = value; }
        }
        private string _sTableName;
        public string TableName
        {
            get { return _sTableName; }
            set { _sTableName = value; }
        }
        private int _nIsTableData;
        public int IsTableData
        {
            get { return _nIsTableData; }
            set { _nIsTableData = value; }
        }
        private int _nFreeProductID;
        public int FreeProductID
        {
            get { return _nFreeProductID; }
            set { _nFreeProductID = value; }
        }
        private int _nIsScratchCardFreeProduct;
        public int IsScratchCardFreeProduct
        {
            get { return _nIsScratchCardFreeProduct; }
            set { _nIsScratchCardFreeProduct = value; }
        }
        private int _nPromoEMITenureID;
        public int PromoEMITenureID
        {
            get { return _nPromoEMITenureID; }
            set { _nPromoEMITenureID = value; }
        }

        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        private int _nDiscountTypeID;
        public int DiscountTypeID
        {
            get { return _nDiscountTypeID; }
            set { _nDiscountTypeID = value; }
        }
        private double _nAmount;
        public double Amount
        {
            get { return _nAmount; }
            set { _nAmount = value; }
        }
        private string _sInstrumentNo;
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }
        private string _sDescription;
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }


        private double _ScratchCardDiscount;
        public double ScratchCardDiscount
        {
            get { return _ScratchCardDiscount; }
            set { _ScratchCardDiscount = value; }
        }
        private string _sFlatAmtScratchCardNo;
        public string FlatAmtScratchCardNo
        {
            get { return _sFlatAmtScratchCardNo; }
            set { _sFlatAmtScratchCardNo = value; }
        }
        private string _sFlatAmtScratchCardDescription;
        public string FlatAmtScratchCardDescription
        {
            get { return _sFlatAmtScratchCardDescription; }
            set { _sFlatAmtScratchCardDescription = value; }
        }
        private string _sFreeQtyScratchCardNo;
        public string FreeQtyScratchCardNo
        {
            get { return _sFreeQtyScratchCardNo; }
            set { _sFreeQtyScratchCardNo = value; }
        }
        private string _sFreeQtyScratchCardDescription;
        public string FreeQtyScratchCardDescription
        {
            get { return _sFreeQtyScratchCardDescription; }
            set { _sFreeQtyScratchCardDescription = value; }
        }

        private double _SPParcentage;
        public double SPParcentage
        {
            get { return _SPParcentage; }
            set { _SPParcentage = value; }
        }
        private double _FaltAmount;
        public double FaltAmount
        {
            get { return _FaltAmount; }
            set { _FaltAmount = value; }
        }
        private double _SPDiscount;
        public double SPDiscount
        {
            get { return _SPDiscount; }
            set { _SPDiscount = value; }
        }
        private double _InstallationCharge;
        public double InstallationCharge
        {
            get { return _InstallationCharge; }
            set { _InstallationCharge = value; }
        }
        private double _FreightCharge;
        public double FreightCharge
        {
            get { return _FreightCharge; }
            set { _FreightCharge = value; }
        }

        private double _TotalCharge;
        public double TotalCharge
        {
            get { return _TotalCharge; }
            set { _TotalCharge = value; }
        }

        private double _AdditionalDiscount;
        public double AdditionalDiscount
        {
            get { return _AdditionalDiscount; }
            set { _AdditionalDiscount = value; }
        }

        private double _TotalDiscount;
        public double TotalDiscount
        {
            get { return _TotalDiscount; }
            set { _TotalDiscount = value; }
        }

        private double _OtherCharge;
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }
        private double _MarkUpAmount;
        public double MarkUpAmount
        {
            get { return _MarkUpAmount; }
            set { _MarkUpAmount = value; }
        }
        private int _nDiscountReasonID;
        public int DiscountReasonID
        {
            get { return _nDiscountReasonID; }
            set { _nDiscountReasonID = value; }
        }
        private int _nPromotionType;
        public int PromotionType
        {
            get { return _nPromotionType; }
            set { _nPromotionType = value; }
        }

        public double VATLowerLimit
        {
            get { return _VATLowerLimit; }
            set { _VATLowerLimit = value; }
        }

        public double VATUpperLimit
        {
            get { return _VATUpperLimit; }
            set { _VATUpperLimit = value; }
        }
        private double _nCalculativeTradePrice;

        public double CalculativeTradePrice
        {
            get { return _nCalculativeTradePrice; }
            set { _nCalculativeTradePrice = value; }
        }

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
        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
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
        /// Get set property for Quantity
        /// </summary>
        public long Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        /// <summary>
        /// Get set property for UnitPrice
        /// </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }


        /// <summary>
        /// Get set property for TradePrice
        /// </summary>
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }

        /// <summary>
        /// Get set property for VATAmount
        /// </summary>
        public double VATAmount
        {
            get { return _VATAmount; }
            set { _VATAmount = value; }
        }


        /// <summary>
        /// Get set property for ProductDiscount
        /// </summary>
        public double ProductDiscount
        {
            get { return _ProductDiscount; }
            set { _ProductDiscount = value; }
        }

        /// <summary>
        /// Get set property for SalesPersonBonus
        /// </summary>
        public double SalesPersonBonus
        {
            get { return _SalesPersonBonus; }
            set { _SalesPersonBonus = value; }
        }

        /// <summary>
        /// Get set property for CustomerProfitMargin
        /// </summary>
        public double CustomerProfitMargin
        {
            get { return _CustomerProfitMargin; }
            set { _CustomerProfitMargin = value; }
        }

        /// <summary>
        /// Get set property for CustomerSellingExpense
        /// </summary>
        public double CustomerSellingExpense
        {
            get { return _CustomerSellingExpense; }
            set { _CustomerSellingExpense = value; }
        }

        /// <summary>
        /// Get set property for TradePromotion
        /// </summary>
        public double TradePromotion
        {
            get { return _TradePromotion; }
            set { _TradePromotion = value; }
        }

        /// <summary>
        /// Get set property for Advertisement
        /// </summary>
        public double Advertisement
        {
            get { return _Advertisement; }
            set { _Advertisement = value; }
        }

        /// <summary>
        /// Get set property for RetailCommission
        /// </summary>
        public double RetailCommission
        {
            get { return _RetailCommission; }
            set { _RetailCommission = value; }
        }

        /// <summary>
        /// Get set property for ProductWarrenty
        /// </summary>
        public double ProductWarrenty
        {
            get { return _ProductWarrenty; }
            set { _ProductWarrenty = value; }
        }

        /// <summary>
        /// Get set property for PrimaryFreightCost
        /// </summary>
        public double PrimaryFreightCost
        {
            get { return _PrimaryFreightCost; }
            set { _PrimaryFreightCost = value; }
        }

        /// <summary>
        /// Get set property for OtherProvission
        /// </summary>
        public double OtherProvission
        {
            get { return _OtherProvission; }
            set { _OtherProvission = value; }
        }

        /// <summary>
        /// Get set property for AdjustedDPAmount
        /// </summary>
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }

        /// <summary>
        /// Get set property for AdjustedPWAmount
        /// </summary>
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }

        /// <summary>
        /// Get set property for AdjustedTPAmount
        /// </summary>
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }

        /// <summary>
        /// Get set property for PromotionalDiscount
        /// </summary>
        public double PromotionalDiscount
        {
            get { return _PromotionalDiscount; }
            set { _PromotionalDiscount = value; }
        }

        private double _PayableAmount;
        public double PayableAmount
        {
            get { return _PayableAmount; }
            set { _PayableAmount = value; }
        }


        /// <summary>
        /// Get set property for IsFreeProduct
        /// </summary>
        public int IsFreeProduct
        {
            get { return _nIsFreeProduct; }
            set { _nIsFreeProduct = value; }
        }

        /// <summary>
        /// Get set property for FreeQty
        /// </summary>
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
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
        private int _nID;
        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }


        public void Insert(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //double _CalculatedTradePrice = GetTP(_nProductID, _UnitPrice, _VATAmount);
            try
            {
                cmd.CommandText = " INSERT INTO t_SalesInvoiceDetail( "
                                 + " InvoiceID,ProductID,Quantity,UnitPrice,CostPrice,TradePrice,VATAmount,ProductDiscount, "
                                 + " SalesPersonBonus, CustomerProfitMargin, CustomerSellingExpense, TradePromotion,Advertisement, "
                                 + " RetailCommission, ProductWarrenty, PrimaryFreightCost, OtherProvission, AdjustedDPAmount, "
                                 + " AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty )"
                                 + " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("TradePrice", _TradePrice);
                //cmd.Parameters.AddWithValue("TradePrice", _CalculatedTradePrice);
                cmd.Parameters.AddWithValue("VATAmount", _VATAmount);
                cmd.Parameters.AddWithValue("ProductDiscount", 0);
                cmd.Parameters.AddWithValue("SalesPersonBonus", 0);
                cmd.Parameters.AddWithValue("CustomerProfitMargin", 0);
                cmd.Parameters.AddWithValue("CustomerSellingExpense", 0);
                cmd.Parameters.AddWithValue("TradePromotion", 0);
                cmd.Parameters.AddWithValue("Advertisement", 0);
                cmd.Parameters.AddWithValue("RetailCommission", 0);
                cmd.Parameters.AddWithValue("ProductWarrenty", 0);
                cmd.Parameters.AddWithValue("PrimaryFreightCost", 0);
                cmd.Parameters.AddWithValue("OtherProvission", 0);
                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertNewForPOS(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            
            try
            {
                cmd.CommandText = " INSERT INTO t_SalesInvoiceDetail( "
                                 + " InvoiceID,ProductID,Quantity,UnitPrice,CostPrice,TradePrice,VATAmount,ProductDiscount, "
                                 + " SalesPersonBonus, CustomerProfitMargin, CustomerSellingExpense, TradePromotion,Advertisement, "
                                 + " RetailCommission, ProductWarrenty, PrimaryFreightCost, OtherProvission, AdjustedDPAmount, "
                                 + " AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty )"
                                 + " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("TradePrice",_TradePrice);
                cmd.Parameters.AddWithValue("VATAmount", _VATAmount);
                cmd.Parameters.AddWithValue("ProductDiscount", 0);
                cmd.Parameters.AddWithValue("SalesPersonBonus", 0);
                cmd.Parameters.AddWithValue("CustomerProfitMargin", 0);
                cmd.Parameters.AddWithValue("CustomerSellingExpense", 0);
                cmd.Parameters.AddWithValue("TradePromotion", 0);
                cmd.Parameters.AddWithValue("Advertisement", 0);
                cmd.Parameters.AddWithValue("RetailCommission", 0);
                cmd.Parameters.AddWithValue("ProductWarrenty", 0);
                cmd.Parameters.AddWithValue("PrimaryFreightCost", 0);
                cmd.Parameters.AddWithValue("OtherProvission", 0);
                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddNewInvoiceItem(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            //double _CalculatedTradePrice = GetTP(_nProductID, _UnitPrice, _VATAmount);
            try
            {

                sSql = "INSERT INTO t_SalesInvoiceDetailNew (InvoiceID, ProductID, Quantity, UnitPrice, CostPrice, TradePrice, VATAmount, IsFreeProduct, FreeQty, Charges, Discounts) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("TradePrice", _TradePrice);
                cmd.Parameters.AddWithValue("VATAmount", _VATAmount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                cmd.Parameters.AddWithValue("Charges", _TotalCharge);
                cmd.Parameters.AddWithValue("Discounts", _TotalDiscount);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddNewInvoiceItemForPOS(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            
            try
            {

                sSql = "INSERT INTO t_SalesInvoiceDetailNew (InvoiceID, ProductID, Quantity, UnitPrice, CostPrice, TradePrice, VATAmount, IsFreeProduct, FreeQty, Charges, Discounts) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("TradePrice", _TradePrice);
                cmd.Parameters.AddWithValue("VATAmount", _VATAmount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                cmd.Parameters.AddWithValue("Charges", _TotalCharge);
                cmd.Parameters.AddWithValue("Discounts", _TotalDiscount);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddDiscountCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_SalesInvoiceDiscount (InvoiceID,ProductID,WHID,DiscountTypeID,Amount,InstrumentNo,Description) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("WHID", _nWarehouseID);
                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);
                cmd.Parameters.AddWithValue("Amount", _nAmount);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddDiscountChargeMap()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SalesInvoiceDiscountChargeMap";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_SalesInvoiceDiscountChargeMap (ID, InvoiceNo, DiscountTypeID, DataID, SlabID, OfferID, TableName, IsTableData, Amount, FreeProductID, FreeQty, IsScratchCardFreeProduct, PromoEMITenureID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                //if (_nDiscountTypeID != -1)
                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);
                //cmd.Parameters.AddWithValue("DiscountTypeID", null);
                if (_nDataID != -1)
                    cmd.Parameters.AddWithValue("DataID", _nDataID);
                else cmd.Parameters.AddWithValue("DataID", null);
                if (_nSlabID != -1)
                    cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                else cmd.Parameters.AddWithValue("SlabID", null);
                if (_nOfferID != -1)
                    cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                else cmd.Parameters.AddWithValue("OfferID", null);
                if (_sTableName != "")
                    cmd.Parameters.AddWithValue("TableName", _sTableName);
                else cmd.Parameters.AddWithValue("TableName", null);
                cmd.Parameters.AddWithValue("IsTableData", _nIsTableData);
                cmd.Parameters.AddWithValue("Amount", _nAmount);
                if (_nFreeProductID != -1)
                    cmd.Parameters.AddWithValue("FreeProductID", _nFreeProductID);
                else cmd.Parameters.AddWithValue("FreeProductID", null);
                if (_nFreeQty != -1)
                    cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                else cmd.Parameters.AddWithValue("FreeQty", null);
                if (_nIsScratchCardFreeProduct != -1)
                    cmd.Parameters.AddWithValue("IsScratchCardFreeProduct", _nIsScratchCardFreeProduct);
                else cmd.Parameters.AddWithValue("IsScratchCardFreeProduct", null);

                if (_nPromoEMITenureID != -1)
                    cmd.Parameters.AddWithValue("PromoEMITenureID", _nPromoEMITenureID);
                else cmd.Parameters.AddWithValue("PromoEMITenureID", null);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddDiscountChargeMapProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_SalesInvoiceDiscountChargeMapProduct (ID, ProductID) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateDPAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceDetail SET AdjustedDPAmount = ? WHERE InvoiceID = ? and ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private double GetTP(int nProductID, double _UnitPrice, double _VATAmount)
        {
            double _Amount = 0;

            TPVATProduct _oTPVATProduct = new TPVATProduct();
            if (_oTPVATProduct.IsProductExists(nProductID))
            {

                _Amount = _oTPVATProduct.TradePrice;
            }
            else
            {
                _Amount = Math.Round(_UnitPrice / (1 + _VATAmount), 2, MidpointRounding.AwayFromZero);
            }

            return _Amount;

        }

        public int IsFreeProductExist()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int IsFreeCount = 0;
            try
            {
                cmd.CommandText = "Select Count(ProductID) IsFreeCount From t_SalesInvoiceDetail where InvoiceID=? and IsFreeProduct=1 and ProductID=?";

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
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

        public void UpdateIsFreeQty(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceDetail SET FreeQty = FreeQty + ? WHERE InvoiceID = " + nInvoiceID + " and ProductID = ? and IsFreeProduct=1";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIsFreeQtyNewInvoice(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceDetailNew SET FreeQty = FreeQty + ? WHERE InvoiceID = " + nInvoiceID + " and ProductID = ? and IsFreeProduct=1";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsNewInvoice(long nInvoiceID)
        {
            long nInvID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceDetailNew where InvoiceID =?";
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nInvID = Convert.ToInt64(reader["InvoiceID"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nInvID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


    }
    public class SalesInvoice : CollectionBase
    {
        private int _NoOfLineItem;
        public int NoOfLineItem
        {
            get { return _NoOfLineItem; }
            set { _NoOfLineItem = value; }
        }
        private int _NoOfPromo;
        public int NoOfPromo
        {
            get { return _NoOfPromo; }
            set { _NoOfPromo = value; }
        }
        private int _NoOfPaymentMode;
        public int NoOfPaymentMode
        {
            get { return _NoOfPaymentMode; }
            set { _NoOfPaymentMode = value; }
        }
        private double _NetSales;
        public double NetSales
        {
            get { return _NetSales; }
            set { _NetSales = value; }
        }
        private double _TotalVat;
        public double TotalVat
        {
            get { return _TotalVat; }
            set { _TotalVat = value; }
        }


        private long _InvoiceID;
        private string _sInvoiceNo;
        private object _InvoiceDate;
        private int _nInvoiceStatus;
        private int _nCustomerID;
        private int _nWarehouseID;
        private double _InvoiceAmount;
        private double _CurrentBalance;
        private double _Discount;
        private string _sRemarks;
        private int _nOrderID;
        private int _nSalesPersonID;
        private int _nUpdateUserID;
        private object _UpdateDate;
        private object _CreateDate;
        private int _nVATChallanNo;
        private int _nInvoiceTypeID;
        private int _nInvoiceBy;
        private string _sDeliveryAddress;
        private int _nPriceOptionID;
        private int _nDeliveredBy;
        private object _DeliveryDate;
        private int _nInvoicePrintCounter;
        private string _sRefInvoiceID;
        private string _sInvoicePrintByString;
        private double _DueAmount;
        private string _sRefDetails;
        private double _OtherCharge;
        private int _nUploadStatus;
        private object _UploadDate;
        private object _DownloadDate;
        private int _nRowStatus;
        private int _nTerminal;
        private long _SundryCustomerID;
        private int _nSalesPromotionID;
        private string _sOrderNo;
        private CustomerDetail _oCustomerDetail;
        public Customer _oCustomer;
        private SalesOrder _oSalesOrder;
        private User _oDeliveryUser;
        private User _oInvoiceUser;
        private string _sCustomerCode;
        private string _sCustomerName;
        private bool _bFlag;
        private int _nUserID;
        private int _nIsCheck;
        private DateTime _dCreditExpiredDate;
        private int _nProductID;
        private double _ReceiveAmount;

        private double _nTradePrice;

        public double TradePrice
        {
            get { return _nTradePrice; }
            set { _nTradePrice = value; }
        }

        private double _RetailSalesValue;
        public double RetailSalesValue
        {
            get { return _RetailSalesValue; }
            set { _RetailSalesValue = value; }
        }
        private double _B2BSalesValue;
        public double B2BSalesValue
        {
            get { return _B2BSalesValue; }
            set { _B2BSalesValue = value; }
        }
        private double _DealerSalesValue;
        public double DealerSalesValue
        {
            get { return _DealerSalesValue; }
            set { _DealerSalesValue = value; }
        }
        private double _OtherSalesValue;
        public double OtherSalesValue
        {
            get { return _OtherSalesValue; }
            set { _OtherSalesValue = value; }
        }

        private int _RetailSalesQty;
        public int RetailSalesQty
        {
            get { return _RetailSalesQty; }
            set { _RetailSalesQty = value; }
        }
        private int _B2BSalesQty;
        public int B2BSalesQty
        {
            get { return _B2BSalesQty; }
            set { _B2BSalesQty = value; }
        }
        private int _DealerSalesQty;
        public int DealerSalesQty
        {
            get { return _DealerSalesQty; }
            set { _DealerSalesQty = value; }
        }
        private int _OtherSalesQty;
        public int OtherSalesQty
        {
            get { return _OtherSalesQty; }
            set { _OtherSalesQty = value; }
        }

        public double ReceiveAmount
        {
            get { return _ReceiveAmount; }
            set { _ReceiveAmount = value; }
        }

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        private double _PromoDiscount;
        public double PromoDiscount
        {
            get { return _PromoDiscount; }
            set { _PromoDiscount = value; }
        }
        private double _ScratchCardAmt;
        public double ScratchCardAmt
        {
            get { return _ScratchCardAmt; }
            set { _ScratchCardAmt = value; }
        }

        private string _sConsumerAddress;
        public string ConsumerAddress
        {
            get { return _sConsumerAddress; }
            set { _sConsumerAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CurrentBalance
        /// </summary>
        public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }

        // <summary>
        // Get set property for CreditPeriod
        // </summary>
        public DateTime CreditExpiredDate
        {
            get { return _dCreditExpiredDate; }
            set { _dCreditExpiredDate = value; }
        }

        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value; }
        }
        public CustomerDetail CustomerDetail
        {
            get
            {
                if (_oCustomerDetail == null)
                {
                    _oCustomerDetail = new CustomerDetail();
                    _oCustomerDetail.CustomerID = _nCustomerID;
                    _oCustomerDetail.RefreshForSalesOrder();
                }

                return _oCustomerDetail;
            }
        }
        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = _nCustomerID;
                    _oCustomer.RefreshForSalesOrder(_sCustomerCode, _sCustomerName);
                }

                return _oCustomer;
            }
        }
        public SalesOrder SalesOrder
        {
            get
            {
                if (_oSalesOrder == null)
                {
                    _oSalesOrder = new SalesOrder();
                    _oSalesOrder.OrderID = _nOrderID;
                    _oSalesOrder.Refresh(_sOrderNo, _sCustomerCode, _sCustomerName);
                }

                return _oSalesOrder;
            }
        }
        public User DeliveryUser
        {
            get
            {
                if (_oDeliveryUser == null)
                {
                    _oDeliveryUser = new User();
                    _oDeliveryUser.UserId = _nDeliveredBy;
                    _oDeliveryUser.RefreshByUserID();
                }

                return _oDeliveryUser;
            }

        }
        public User InvoiceUser
        {
            get
            {
                if (_oInvoiceUser == null)
                {
                    _oInvoiceUser = new User();
                    _oInvoiceUser.UserId = _nInvoiceBy;
                    _oInvoiceUser.RefreshByUserID();
                }

                return _oInvoiceUser;
            }

        }
        SystemInfo _oSystemInfo;

        private string _sConsumerCode;
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value.Trim(); }
        }
        private string _sConsumerName;
        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ConsumerName
        /// </summary>
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }


        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        private string _sMonthName;
        public string MonthName
        {
            get { return _sMonthName; }
            set { _sMonthName = value.Trim(); }
        }

        private int _MonthNo;
        public int MonthNo
        {
            get { return _MonthNo; }
            set { _MonthNo = value; }
        }
        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public object InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }

        /// <summary>
        /// Get set property for InvoiceStatus
        /// </summary>
        public int InvoiceStatus
        {
            get { return _nInvoiceStatus; }
            set { _nInvoiceStatus = value; }
        }

        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceAmount
        /// </summary>
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        /// <summary>
        /// Get set property for Discount
        /// </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
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
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        private int _nIsVerifiedEmail;
        public int IsVerifiedEmail
        {
            get { return _nIsVerifiedEmail; }
            set { _nIsVerifiedEmail = value; }
        }
        /// <summary>
        /// Get set property for SalesPersonID
        /// </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
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
        /// Get set property for UpdateDate
        /// </summary>
        public object UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public object CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        /// <summary>
        /// Get set property for VATChallanNo
        /// </summary>
        public int VATChallanNo
        {
            get { return _nVATChallanNo; }
            set { _nVATChallanNo = value; }
        }

        /// <summary>
        /// Get set property for InvoiceTypeID
        /// </summary>
        public int InvoiceTypeID
        {
            get { return _nInvoiceTypeID; }
            set { _nInvoiceTypeID = value; }
        }

        private int _nSalesType;
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }

        /// <summary>
        /// Get set property for InvoiceBy
        /// </summary>
        public int InvoiceBy
        {
            get { return _nInvoiceBy; }
            set { _nInvoiceBy = value; }
        }

        /// <summary>
        /// Get set property for DeliveryAddress
        /// </summary>
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PriceOptionID
        /// </summary>
        public int PriceOptionID
        {
            get { return _nPriceOptionID; }
            set { _nPriceOptionID = value; }
        }

        /// <summary>
        /// Get set property for DeliveredBy
        /// </summary>
        public int DeliveredBy
        {
            get { return _nDeliveredBy; }
            set { _nDeliveredBy = value; }
        }

        /// <summary>
        /// Get set property for DeliveryDate
        /// </summary>
        public object DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }

        /// <summary>
        /// Get set property for InvoicePrintCounter
        /// </summary>
        public int InvoicePrintCounter
        {
            get { return _nInvoicePrintCounter; }
            set { _nInvoicePrintCounter = value; }
        }

        /// <summary>
        /// Get set property for RefInvoiceID
        /// </summary>
        public string RefInvoiceID
        {
            get { return _sRefInvoiceID; }
            set { _sRefInvoiceID = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InvoicePrintByString
        /// </summary>
        public string InvoicePrintByString
        {
            get { return _sInvoicePrintByString; }
            set { _sInvoicePrintByString = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DueAmount
        /// </summary>
        public double DueAmount
        {
            get { return _DueAmount; }
            set { _DueAmount = value; }
        }

        /// <summary>
        /// Get set property for RefDetails
        /// </summary>
        public string RefDetails
        {
            get { return _sRefDetails; }
            set { _sRefDetails = value.Trim(); }
        }

        /// <summary>
        /// Get set property for OtherCharge
        /// </summary>
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
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
        /// Get set property for SundryCustomerID
        /// </summary>
        public long SundryCustomerID
        {
            get { return _SundryCustomerID; }
            set { _SundryCustomerID = value; }
        }
        private int _nThanaID;
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        public int IsCheck
        {
            get { return _nIsCheck; }
            set { _nIsCheck = value; }
        }

        private int _nQty;
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        private int _nTransferType;
        public int TransferType
        {
            get { return _nTransferType; }
            set { _nTransferType = value; }
        }

        private int _nIsDownload;
        public int IsDownload
        {
            get { return _nIsDownload; }
            set { _nIsDownload = value; }
        }
        private string _sInstrumentNo;
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }

        private string _sInvoiceStatusName;
        public string InvoiceStatusName
        {
            get { return _sInvoiceStatusName; }
            set { _sInvoiceStatusName = value; }
        }

        private int _nCassiopeiaCustID;
        public int CassiopeiaCustID
        {
            get { return _nCassiopeiaCustID; }
            set { _nCassiopeiaCustID = value; }
        }

        private int _nShowroomID;
        public int ShowroomID
        {
            get { return _nShowroomID; }
            set { _nShowroomID = value; }
        }

        private string _sShowroomCode;
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }

        private string _sOldInvoiceNo;
        public string OldInvoiceNo
        {
            get { return _sOldInvoiceNo; }
            set { _sOldInvoiceNo = value; }
        }
        private int _nDCSType;
        public int DCSType
        {
            get { return _nDCSType; }
            set { _nDCSType = value; }
        }

        private string _sEmail;
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }


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
        private ProductBarcodes oProductBarcodes;
        public ProductBarcodes ProductBarcodes
        {
            get
            {
                if (oProductBarcodes == null)
                {
                    oProductBarcodes = new ProductBarcodes();
                }
                return oProductBarcodes;
            }
        }
        private SalesInvoiceProductSerials oSalesInvoiceProductSerials;
        public SalesInvoiceProductSerials SalesInvoiceProductSerials
        {
            get
            {
                if (oSalesInvoiceProductSerials == null)
                {
                    oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
                }
                return oSalesInvoiceProductSerials;
            }
        }

        public SalesInvoiceItem this[int i]
        {
            get { return (SalesInvoiceItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoiceItem oSalesInvoiceItem)
        {
            InnerList.Add(oSalesInvoiceItem);
        }

        public void Insert(bool IsCancel)
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());

                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();

                if (IsCancel == false)
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _nWarehouseID;
                    _oWarehouse.Reresh();

                    _sRefDetails = _sOrderNo + "WH:" + _oWarehouse.WarehouseCode;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( " 
                                  +" InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  +" WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  +" InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  +" RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  +" DeliveryDate, SalesPromotionID) "
                                  +" Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID",_InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo",_sInvoiceNo );
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress",_sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID",_nSalesPersonID);
                if (IsCancel == false)
                    cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.PENDING);
                else cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.PRODUCT_RETURN);
                cmd.Parameters.AddWithValue("WarehouseID",_nWarehouseID);
                cmd.Parameters.AddWithValue("Discount",_Discount );
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                if (IsCancel == false)
                    cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                else cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID );
                cmd.Parameters.AddWithValue("InvoiceAmount",_InvoiceAmount );
                cmd.Parameters.AddWithValue("UpdateUserID",null );
                cmd.Parameters.AddWithValue("UpdateDate",null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID",_nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter",null);
                cmd.Parameters.AddWithValue("RefInvoiceID",null);
                cmd.Parameters.AddWithValue("DueAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("RefDetails",_sRefDetails );
                cmd.Parameters.AddWithValue("OtherCharge",0);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus",null );
                cmd.Parameters.AddWithValue("Terminal",_nTerminal);
                cmd.Parameters.AddWithValue("SundryCustomerID", null);
                cmd.Parameters.AddWithValue("DeliveryDate", null);              
                cmd.Parameters.AddWithValue("SalesPromotionID",_nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + _NextVatChallanNo + "' where  WarehouseID=?";
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";             
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForReplace()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());

                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);            
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.UNDELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", 0);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("SundryCustomerID", null);
                cmd.Parameters.AddWithValue("DeliveryDate", null);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + _NextVatChallanNo + "' where  WarehouseID=?";
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForEPS()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());

                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nWarehouseID;
                _oWarehouse.Reresh();

                _sRefDetails = _sOrderNo + "WH:" + _oWarehouse.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.UNDELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);              
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", 0);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", 0);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                if (_nWarehouseID == Utility.WebStore)
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", null);
                }
                
                cmd.Parameters.AddWithValue("DeliveryDate", null);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + _NextVatChallanNo + "' where  WarehouseID=?";
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertInvoice()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());

                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nWarehouseID;
                _oWarehouse.Reresh();

                _sRefDetails = _sOrderNo + "WH:" + _oWarehouse.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.UNDELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", 0);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                if (_nWarehouseID == Utility.WebStore)
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                }
                if (_nWarehouseID == 68)
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", null);
                }

                cmd.Parameters.AddWithValue("DeliveryDate", null);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + _NextVatChallanNo + "' where  WarehouseID=?";
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    // if(oItem.Quantity !=0)   Code Reviewed by Dipak 
                    if (oItem.Quantity + oItem.FreeQty != 0)
                    {                     
                    oItem.Insert(_InvoiceID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertInvoiceForLead()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;
            int nWarehouseID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());

                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nWarehouseID;
                _oWarehouse.Reresh();

                _sRefDetails = _sOrderNo + "WH:" + _oWarehouse.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.UNDELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                nWarehouseID = _nWarehouseID;
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", 0);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                if (_nWarehouseID == Utility.WebStore)
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                }
                if (_nWarehouseID == 68)
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SundryCustomerID", null);
                }

                cmd.Parameters.AddWithValue("DeliveryDate", null);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                //cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + _NextVatChallanNo + "' where  WarehouseID=?";
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    if (oItem.Quantity != 0)
                    {
                        oItem.Insert(_InvoiceID);
                        ProductStock oBookingStock = new ProductStock();
                        oBookingStock.UpdateBookingStock(true, Convert.ToInt32(oItem.Quantity), nWarehouseID, oItem.ProductID);
                    }


                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertDealerInvoice()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());

                }
                _sInvoiceNo = oSystemInfo.Shortcode.ToString() + "-" + nMaxInvoiceNo.ToString();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nWarehouseID;
                _oWarehouse.POSReresh();

                _sRefDetails = _sInvoiceNo + "WH:" + _oWarehouse.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", oSystemInfo.OperationDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.DELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", oSystemInfo.OperationDate);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", 0);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Branch_Office);
                cmd.Parameters.AddWithValue("SundryCustomerID", null);
                cmd.Parameters.AddWithValue("DeliveryDate", null);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
                cmd = DBController.Instance.GetCommand();

                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesInvoice";
                oDataTran.DataID = Convert.ToInt32(_InvoiceID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;

                oDataTran.Add();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertRetailInvoice(bool IsTrue)
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxInvoiceID = cmd.ExecuteScalar();
                if (maxInvoiceID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxInvoiceID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());
                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nWarehouseID;
                _oWarehouse.POSReresh();

                _sInvoiceNo = _oWarehouse.Shortcode + "-" + DateTime.Today.Year.ToString() + "-" + _sInvoiceNo.ToString();

                _sRefDetails = _sInvoiceNo + "WH:" + _oWarehouse.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.DELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", (int)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                if (IsTrue == true)
                {

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_SalesInvoice";
                    oDataTran.DataID = Convert.ToInt32(_InvoiceID);
                    oDataTran.WarehouseID = _nWarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    oDataTran.AddForTDPOS();
                }
                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertPOSInvoice(bool IsTrue)
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxInvoiceID = cmd.ExecuteScalar();
                if (maxInvoiceID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxInvoiceID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());
                }

                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();

                DateTime _dOperationDate = Convert.ToDateTime(_oSystemInfo.OperationDate);

                _sInvoiceNo = _oSystemInfo.Shortcode + "-" + _dOperationDate.Year.ToString() + "-" + nMaxInvoiceNo.ToString("0000");

                _sRefDetails = _sInvoiceNo + "WH:" + _oSystemInfo.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_CreateDate == null)
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                else cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                if (_sRefInvoiceID == "")
                    cmd.Parameters.AddWithValue("RefInvoiceID", null);
                else cmd.Parameters.AddWithValue("RefInvoiceID", _sRefInvoiceID);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", (int)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                if (IsTrue == true)
                {

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_SalesInvoice";
                    oDataTran.DataID = Convert.ToInt32(_InvoiceID);
                    oDataTran.WarehouseID = _nWarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    oDataTran.AddForTDPOS();
                }
                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    if (oItem.IsFreeProduct == 1)
                    {
                        SalesInvoiceItem oChkFreeProduct = new SalesInvoiceItem();
                        oChkFreeProduct.ProductID = oItem.ProductID;
                        oChkFreeProduct.InvoiceID = _InvoiceID;
                        int nFreeItemCount = oChkFreeProduct.IsFreeProductExist();
                        if (nFreeItemCount == 0)
                        {
                            oItem.Insert(_InvoiceID);
                        }
                        else
                        {
                            oItem.UpdateIsFreeQty(_InvoiceID);
                        }

                    }
                    else
                    {
                        oItem.Insert(_InvoiceID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPOSInvoiceNew()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxInvoiceID = cmd.ExecuteScalar();
                if (maxInvoiceID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxInvoiceID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());
                }

                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();

                DateTime _dOperationDate = Convert.ToDateTime(_oSystemInfo.OperationDate);

                _sInvoiceNo = _oSystemInfo.Shortcode + "-" + _dOperationDate.Year.ToString() + "-" +
                              nMaxInvoiceNo.ToString("0000");

                _sRefDetails = _sInvoiceNo + "WH:" + _oSystemInfo.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice(  " +
                                  "InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus,  " +
                                  "WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY,  " +
                                  "InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, " +
                                  "RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, " +
                                  "DeliveryDate, SalesPromotionID,CustThanaID ) " +
                                  "Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_CreateDate == null)
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                else cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                if (_sRefInvoiceID == "")
                    cmd.Parameters.AddWithValue("RefInvoiceID", null);
                else cmd.Parameters.AddWithValue("RefInvoiceID", _sRefInvoiceID);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", (int) Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);
                cmd.Parameters.AddWithValue("CustThanaID", _nThanaID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo +
                                  "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesInvoice";
                oDataTran.DataID = Convert.ToInt32(_InvoiceID);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int) Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int) Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                oDataTran.AddForTDPOS();
                cmd.Dispose();


                foreach (SalesInvoiceItem oItem in this)
                {
                    if (oItem.IsFreeProduct == 1)
                    {
                        SalesInvoiceItem oChkFreeProduct = new SalesInvoiceItem();
                        oChkFreeProduct.ProductID = oItem.ProductID;
                        oChkFreeProduct.InvoiceID = _InvoiceID;
                        int nFreeItemCount = oChkFreeProduct.IsFreeProductExist();
                        if (nFreeItemCount == 0)
                        {
                            oItem.InsertNewForPOS(_InvoiceID);
                            oItem.AddNewInvoiceItemForPOS(_InvoiceID);
                        }
                        else
                        {
                            oItem.UpdateIsFreeQty(_InvoiceID);
                            oItem.UpdateIsFreeQtyNewInvoice(_InvoiceID);

                        }

                    }
                    else
                    {
                        oItem.InsertNewForPOS(_InvoiceID);
                        oItem.AddNewInvoiceItemForPOS(_InvoiceID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPOSInvoiceRT()
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxInvoiceID = cmd.ExecuteScalar();
                if (maxInvoiceID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxInvoiceID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT NextInvoiceNo FROM t_Showroom where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());
                }
                _sInvoiceNo = Utility.ShowroomCode+ "-" + DateTime.Now.Year.ToString() + "-" +
                              nMaxInvoiceNo.ToString("0000");

                _sRefDetails = _sInvoiceNo + "WH:" + Utility.WarehouseCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice(  " +
                                  "InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus,  " +
                                  "WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY,  " +
                                  "InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, " +
                                  "RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, " +
                                  "DeliveryDate, SalesPromotionID,CustThanaID ) " +
                                  "Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_CreateDate == null)
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                else cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                if (_sRefInvoiceID == "")
                    cmd.Parameters.AddWithValue("RefInvoiceID", null);
                else cmd.Parameters.AddWithValue("RefInvoiceID", _sRefInvoiceID);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", (int)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);
                cmd.Parameters.AddWithValue("CustThanaID", _nThanaID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_Showroom set NextInvoiceNo='" + nMaxInvoiceNo +
                                  "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();



                foreach (SalesInvoiceItem oItem in this)
                {
                    if (oItem.IsFreeProduct == 1)
                    {
                        SalesInvoiceItem oChkFreeProduct = new SalesInvoiceItem();
                        oChkFreeProduct.ProductID = oItem.ProductID;
                        oChkFreeProduct.InvoiceID = _InvoiceID;
                        int nFreeItemCount = oChkFreeProduct.IsFreeProductExist();
                        if (nFreeItemCount == 0)
                        {
                            oItem.InsertNewForPOS(_InvoiceID);
                            oItem.AddNewInvoiceItemForPOS(_InvoiceID);
                        }
                        else
                        {
                            oItem.UpdateIsFreeQty(_InvoiceID);
                            oItem.UpdateIsFreeQtyNewInvoice(_InvoiceID);

                        }

                    }
                    else
                    {
                        oItem.InsertNewForPOS(_InvoiceID);
                        oItem.AddNewInvoiceItemForPOS(_InvoiceID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertReverseInvoicex()//should be deleted - Hakim
        {
            int nMaxID = 0;
            int nMaxInvoiceNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextInvoiceNo]) FROM t_NextDocumentNo where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxInvoiceNo = cmd.ExecuteScalar();
                if (MaxInvoiceNo == DBNull.Value)
                {
                    nMaxInvoiceNo = 1;
                }
                else
                {
                    nMaxInvoiceNo = int.Parse(MaxInvoiceNo.ToString());
                }
                _sInvoiceNo = nMaxInvoiceNo.ToString();


                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();


                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nWarehouseID;
                _oWarehouse.POSReresh();

                _sInvoiceNo = oSystemInfo.Shortcode + "-" + DateTime.Today.Year.ToString() + "-" + _sInvoiceNo.ToString();
              
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.REVERSE);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID",_sRefInvoiceID);
                cmd.Parameters.AddWithValue("DueAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", (int)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Branch_Office);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nMaxInvoiceNo = nMaxInvoiceNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextInvoiceNo='" + nMaxInvoiceNo + "'  where WarehouseID='" + _nWarehouseID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();


                //DataTran oDataTran = new DataTran();

                //oDataTran.TableName = "t_SalesInvoice";
                //oDataTran.DataID = Convert.ToInt32(_InvoiceID);
                //oDataTran.WarehouseID = _nWarehouseID;
                //oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                //oDataTran.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                //oDataTran.BatchNo = 0;
                ////oDataTran.CreateDate=;
                //oDataTran.AddForTDPOS();

                cmd = DBController.Instance.GetCommand();
                sSql = "INSERT INTO t_DataTransfer VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", "t_SalesInvoice");
                cmd.Parameters.AddWithValue("DataID", _InvoiceID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("TransferType", 1);
                cmd.Parameters.AddWithValue("IsDownload", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForSendRetailInvoice()
        {
            int nMaxID = 0;        

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;               

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();  
                
                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForSendRetailInvoiceNew()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID, CustThanaID, NoOfLineItem, NoOfPromo, NoOfPaymentMode, NetSales, TotalVat) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);
                cmd.Parameters.AddWithValue("CustThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("NoOfLineItem", _NoOfLineItem);
                cmd.Parameters.AddWithValue("NoOfPromo", _NoOfPromo);
                cmd.Parameters.AddWithValue("NoOfPaymentMode", _NoOfPaymentMode);
                cmd.Parameters.AddWithValue("NetSales", _NetSales);
                cmd.Parameters.AddWithValue("TotalVat", _TotalVat);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                    oItem.AddNewInvoiceItem(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForSendRetailReverseInvoice()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.DELIVERED);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", _sRefInvoiceID);
                cmd.Parameters.AddWithValue("DueAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", (int)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertSalesInvoicePromo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesInvoicePromo VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("PromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForSendDealerInvoice()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            long nInvoiceID = 0;
            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                nInvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nUserID);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _DeliveryDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);



                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(nInvoiceID);
                }

                MapBranchTran oMBT = new MapBranchTran();
                oMBT.TableName = "t_SalesInvoice";
                oMBT.HODataID = Convert.ToInt32(nInvoiceID);
                oMBT.BranchDataID = Convert.ToInt32(_InvoiceID);
                oMBT.WHID = _nWarehouseID;
                oMBT.Add();

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Upload Sales Invoice");

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Uploading Sales Invoice /" + ex.Message);
                throw (ex);
            }
        }

        public void InsertInvoiceRetail()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _InvoiceID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesInvoice( "
                                  + " InvoiceID,InvoiceNo,InvoiceDate,CustomerID,DeliveryAddress,SalesPersonID,InvoiceStatus, "
                                  + " WarehouseID, Discount, Remarks, OrderID, InvoiceTypeID,InvoiceBY, "
                                  + " InvoiceAmount, UpdateUserID, UpdateDate, CreateDate, VATChallanNo, PriceOptionID,InvoicePrintCounter, "
                                  + " RefInvoiceID,DueAmount,RefDetails,OtherCharge, RowStatus,UploadStatus, Terminal,SundryCustomerID, "
                                  + " DeliveryDate, SalesPromotionID) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("InvoiceStatus", _nInvoiceStatus);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderID", null);
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                cmd.Parameters.AddWithValue("InvoiceBY", _nInvoiceBy);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("VatChallanNo", null);
                cmd.Parameters.AddWithValue("PriceOptionID", _nPriceOptionID);
                cmd.Parameters.AddWithValue("InvoicePrintCounter", null);
                cmd.Parameters.AddWithValue("RefInvoiceID", null);
                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("RefDetails", _sRefDetails);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("RowStatus", null);
                cmd.Parameters.AddWithValue("UploadStatus", 1);
                cmd.Parameters.AddWithValue("Terminal", 1);
                cmd.Parameters.AddWithValue("SundryCustomerID", _SundryCustomerID);
                cmd.Parameters.AddWithValue("DeliveryDate", _InvoiceDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesInvoiceItem oItem in this)
                {
                    oItem.Insert(_InvoiceID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateDueAmount(long nInvoiceID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_SalesInvoice Set DueAmount=0 Where InvoiceID=?";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Upload Edit Sales Invoice");

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Uploading Edit Sales Invoice /" + ex.Message);
                throw (ex);
            }

        }

        public void EditForSendDealerInvoice(long nInvoiceID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_SalesInvoice Set DueAmount=? Where InvoiceID=?";

                cmd.Parameters.AddWithValue("DueAmount", _DueAmount);
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Upload Edit Sales Invoice");

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Uploading Edit Sales Invoice /" + ex.Message);
                throw (ex);
            }

        }

        public void GetInvoiceID(string sInvoiceNo)
        {
            int _nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoice where InvoiceNo =?";
                cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                    _nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }
        public long GetInvoiceIDByInvNo(string sInvoiceNo)
        {
            long nInvID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoice where InvoiceNo =?";
                cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nInvID = Convert.ToInt64(reader["InvoiceID"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nInvID;
        }
        public void GetInvoiceByInvoID(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select SI.InvoiceID,InvoiceNo,Convert(Varchar,OrderNo) as OrderNo,CustomerCode, CustomerName, Quantity " +
                                    "from t_SalesInvoice SI INNER JOIN t_Customer C ON SI.CustomerID=C.CustomerID INNER JOIN t_SalesOrder SO " +
                                    "ON SI.OrderID=SO.OrderID INNER JOIN (Select InvoiceID,Sum(Quantity)Quantity from t_SalesInvoiceDetail " +
                                    "group by InvoiceID)Qty ON SI.InvoiceID=Qty.InvoiceID Where SI.InvoiceID=?";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _nQty = Convert.ToInt32(reader["Quantity"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSalesDataForSCM(int nTyear,DateTime dtFromDate,DateTime dtTodate,int nIsYearWise,int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtTodate = dtTodate.AddDays(1);
            string SQL = "";
            if (nIsYearWise == 1)
            {
                SQL = "year(InvoiceDate)=" + nTyear + "";
            }
            else
            {
                SQL = "InvoiceDate between '" + dtFromDate + "' and '" + dtTodate + "' and InvoiceDate<'" + dtTodate + "'";
            }
            try
            {
                cmd.CommandText = "Select isnull(sum(DealerSalesQty),0) DealerSalesQty,isnull(sum(DealerSalesVal),0) DealerSalesVal,isnull(sum(B2BSalesQty),0) B2BSalesQty, " +
                                "isnull(sum(B2BSalesVal),0) B2BSalesVal,isnull(sum(RetailSalesQty),0) RetailSalesQty,isnull(sum(RetailSalesValue),0) RetailSalesValue, " +
                                "isnull(sum(OtherSalesQty),0) OtherSalesQty,isnull(sum(OtherSalesValue),0) OtherSalesValue " +
                                "From  " +
                                "( " +
                                "Select case when SalesType=5 then sum(SalesQty+FreeQty) else 0 end as DealerSalesQty, " +
                                "case when SalesType=5 then sum(NetSale) else 0 end as DealerSalesVal, " +
                                "case when SalesType=3 then sum(SalesQty+FreeQty) else 0 end as B2BSalesQty, " +
                                "case when SalesType=3 then sum(NetSale) else 0 end as B2BSalesVal, " +
                                "case when SalesType in (1,2,4,6) then sum(SalesQty+FreeQty) else 0 end as RetailSalesQty, " +
                                "case when SalesType in (1,2,4,6) then sum(NetSale) else 0 end as RetailSalesValue, " +
                                "case when isnull(SalesType,-1) not in (1,2,3,4,5,6) then sum(SalesQty+FreeQty) else 0 end as OtherSalesQty, " +
                                "case when isnull(SalesType,-1) not in (1,2,3,4,5,6) then sum(NetSale) else 0 end as OtherSalesValue " +
                                "From DWDB.DBO.t_SalesDataCustomerProduct a,TELSYSDB.DBO.t_CustomerType b  " +
                                "where a.CustomerTypeID=b.CustTypeID and CompanyName='TEL' and ProductID=" + nProductID + " " +
                                "and " + SQL + " " +
                                "group by SalesType " +
                                ") Main";
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _RetailSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _RetailSalesValue = Convert.ToDouble(reader["RetailSalesValue"].ToString());
                    _B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _B2BSalesValue = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _DealerSalesValue = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _OtherSalesQty = Convert.ToInt32(reader["OtherSalesQty"].ToString());
                    _OtherSalesValue = Convert.ToDouble(reader["OtherSalesValue"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByInvoiceID(long InvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesInvoice where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    if (reader["OrderID"] != DBNull.Value)
                        _nOrderID = int.Parse(reader["OrderID"].ToString());
                    else _nOrderID = 0;
                    _InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _InvoiceAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else _Discount = 0;
                    if (reader["InvoiceBy"] != DBNull.Value)
                        _nInvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _nInvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _nDeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _nDeliveredBy = -1;
                    _nInvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _sRefDetails = reader["RefDetails"].ToString();
                    _sRemarks = reader["Remarks"].ToString();
                    _sCustomerCode = "";
                    _sCustomerName = "";
                    _sOrderNo = "";

                    RefreshSalesInvoiceItem();

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        

        //public void AddSMSToCustomer()
        //{
        //    int nMaxID = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "SELECT MAX([ID]) FROM t_SMSMessageInividualHistory";
        //        cmd.CommandText = sSql;
        //        object maxID = cmd.ExecuteScalar();
        //        if (maxID == DBNull.Value)
        //        {
        //            nMaxID = 1;
        //        }
        //        else
        //        {
        //            nMaxID = Convert.ToInt32(maxID) + 1;
        //        }

        //        _nID = nMaxID;
        //        sSql = "INSERT INTO t_SMSMessageInividualHistory (ID, Message, MobileNo, SendDate, CustomerID, InvoiceID, Status) VALUES(?,?,?,?,?,?,?)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("ID",_nID);
        //        cmd.Parameters.AddWithValue("Message", _sMessage);
        //        cmd.Parameters.AddWithValue("MobileNo", 01709633913);
        //        cmd.Parameters.AddWithValue("SendDate", DateTime.Today.Date);
        //        cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
        //        cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
        //        cmd.Parameters.AddWithValue("Status", 0);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public bool IntegrateWithAPIBLL(int nID, string sMobileNo, string sMessage)
        //{
        //    string HtmlResult = "";
        //    //String sid = "TranscomElecNon";
        //    String sid = "TRANSTEC";
        //    String user = "transtec";
        //    String pass = "82@5J03g";

        //    String URI = "http://sms.sslwireless.com/pushapi/dynamic/server.php";
        //    String myParameters = "user=" + user + "&pass=" + pass + "&sms[0][0]=" + sMobileNo + "&sms[0][1]=" +
        //    System.Web.HttpUtility.UrlEncode("" + sMessage + "") + "&sms[0][2]=" + "" + nID + "" + "&sid=" + sid;
        //    using (WebClient wc = new WebClient())
        //    {
        //        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //        HtmlResult = wc.UploadString(URI, myParameters);
        //    }
        //    return SendStatus(HtmlResult);
        //}

        //private bool SendStatus(string uri)
        //{
        //    string sREFERENCEID = "";
        //    //using (XmlReader reader = XmlReader.Create(uri))
        //    using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(uri)))
        //    {
        //        string title = null;
        //        string author = null;

        //        reader.MoveToContent();
        //        while (reader.Read())
        //        {
        //            if (reader.NodeType == XmlNodeType.Element
        //                && reader.Name == "SMSINFO")
        //            {
        //                while (reader.Read())
        //                {
        //                    if (reader.NodeType == XmlNodeType.Element &&
        //                        reader.Name == "REFERENCEID")
        //                    {
        //                        sREFERENCEID = reader.ReadString();
        //                        break;
        //                    }
        //                }
        //                //while (reader.Read())
        //                //{
        //                //    if (reader.NodeType == XmlNodeType.Element &&
        //                //        reader.Name == "Author")
        //                //    {
        //                //        author = reader.ReadString();
        //                //        break;
        //                //    }
        //                //}
        //                //yield return new Book() {Title = title, Author = author};
        //            }
        //        }
        //    }
        //    if (sREFERENCEID != "")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public void RefreshByInvoiceNoForDP(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "Select InvoiceID,InvoiceNo,InvoiceDate,a.CustomerID,CustomerCode, " +
                                    " CustomerName,InvoiceAmount,CurrentBalance " +
                                    " From t_Salesinvoice a,v_CustomerDetails b " +
                                    " where a.CustomerID=b.CustomerID and InvoiceNo= ? ";

                cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerName = reader["CustomerName"].ToString();
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _InvoiceAmount = 0;
                    if (reader["CurrentBalance"] != DBNull.Value)
                        _CurrentBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    else _CurrentBalance = 0;

                    nCount++;
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetWarehouseIDByInvoiceID(long InvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesInvoice where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());

                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerIDByInvoiceNo(string InvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select CustomerID,ShowroomID from Cassiopeia_HO.dbo.Invoice Where TranNo='" + InvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCassiopeiaCustID = Convert.ToInt32(reader["CustomerID"].ToString());
                    _nShowroomID = int.Parse(reader["ShowroomID"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetIDByInvoiceNo(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_SalesInvoice Where InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    _nWarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetByCACCustomerMapping(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * from t_SalesInvoice Where CustomerID="+nCustomerID+"";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    _InvoiceDate= (object)reader["InvoiceDate"];
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetByCACInvoiceNo(string sInvoiceNo)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * from t_SalesInvoice a, t_Customer b Where a.CustomerID=b.CustomerID and InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    _nCustomerID= Convert.ToInt32(reader["CustomerID"].ToString());
                    _sCustomerName = (string)reader["CustomerName"];
                    _InvoiceDate = (object)reader["InvoiceDate"];
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCountItemData(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select isnull(sum(NetSales),0) as NetSales,isnull(sum(TotalVat),0) as TotalVat,isnull(sum(NoOfLineItem),0) as NoOfLineItem,isnull(sum(NoOfPaymentMode),0) as NoOfPaymentMode From  " +
                        "(  " +
                        "Select sum((UnitPrice * Quantity) + Charges - Discounts - (TradePrice * (Quantity + FreeQty) * VATAmount)) NetSales,  " +
                        "sum(TradePrice * (Quantity + FreeQty) * VATAmount) as TotalVat, count(ProductID) NoOfLineItem, 0 as NoOfPaymentMode  " +
                        "From t_SalesInvoiceDetailNew where InvoiceID = " + nInvoiceID + "  " +
                        "Union All  " +
                        "Select 0 as NetSales, 0 as TotalVat, 0 as NoOfLineItem, count(PaymentModeID) NoOfPaymentMode   " +
                        "from(Select distinct PaymentModeID from t_SalesInvoicePaymentModeNew where InvoiceID = " + nInvoiceID + ") x  " +
                        ") Main";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _NoOfLineItem = int.Parse(reader["NoOfLineItem"].ToString());
                    _NoOfPaymentMode = int.Parse(reader["NoOfPaymentMode"].ToString());
                    _NetSales = Convert.ToDouble(reader["NetSales"].ToString());
                    _TotalVat = Convert.ToDouble(reader["TotalVat"].ToString());
                    
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForReverseInvoice()
        {        
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_salesinvoice Where InvoiceID= ? ";
            cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
        
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _InvoiceDate = (object)reader["InvoiceDate"];
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    _DeliveryDate = (object)reader["DeliveryDate"];
                    _nSalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _sRefDetails = reader["RefDetails"].ToString();
                    _sRemarks = (reader["Remarks"].ToString());
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _nUserID = int.Parse(reader["InvoiceBy"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _nPriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    _nVATChallanNo = int.Parse(reader["VATChallanNo"].ToString());

                    if (reader["DueAmount"] != DBNull.Value)
                        _DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else _DueAmount = 0;
                    
                    // RefreshSalesInvoiceItemForDataSending();
                    oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
                    oSalesInvoiceProductSerials.GETSerialByInvoiceID(_InvoiceID);
                    
                }

                reader.Close();              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForInvoiceID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_salesinvoice Where OrderID= ? ";
            cmd.Parameters.AddWithValue("OrderID",_nOrderID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _nInvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        //public void UpadteInvoiceStatus(long InvoiceID,int nStatus)
        //{
        //     OleDbCommand cmd = DBController.Instance.GetCommand();          

        //    try
        //    {
        //        cmd.CommandText = "UPDATE t_SalesInvoice " +
        //                          "SET  InvoiceStatus = " + nStatus + ", UpdateUserID = " + _nUserID + ", UpdateDate = '" + DateTime.Now.Date + "', RowStatus = " + (short)Dictionary.RowStatus.UPDATE + ", UploadStatus = null, UploadDate = null, DownloadDate = null " +
        //                          " WHERE InvoiceID = " + InvoiceID + " ";

        //        cmd.CommandType = CommandType.Text;

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


            // Updated by Hrashid
        public void UpadteInvoiceStatus(long InvoiceID, int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET  InvoiceStatus = ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                  " WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUserID);
                if (_UpdateDate == null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _UpdateDate);
                }
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);

                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStatus(long InvoiceID, int _nProductID, double _nTradePrice)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update  t_SalesInvoiceDetail  set TradePrice=? where InvoiceID=? and ProductID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePrice", _nTradePrice);

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpadteInvoiceStatusnCountData(long InvoiceID, int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET  InvoiceStatus = ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ?, " +
                                  "NoOfLineItem =?,NoOfPromo =?,NoOfPaymentMode =?,NetSales =?,TotalVat =?  WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUserID);
                if (_UpdateDate == null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _UpdateDate);
                }
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);

                cmd.Parameters.AddWithValue("NoOfLineItem", _NoOfLineItem);
                cmd.Parameters.AddWithValue("NoOfPromo", _NoOfPromo);
                cmd.Parameters.AddWithValue("NoOfPaymentMode", _NoOfPaymentMode);
                cmd.Parameters.AddWithValue("NetSales", _NetSales);
                cmd.Parameters.AddWithValue("TotalVat", _TotalVat);

                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpadteInvoiceStatusnCountDataRT(long InvoiceID, int nStatus,int nInvoiceConsumerID, int nIsRTInvoice)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET  InvoiceStatus = ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ?, " +
                                  "NoOfLineItem =?,NoOfPromo =?,NoOfPaymentMode =?,NetSales =?,TotalVat =?,InvoiceConsumerID=?,IsRTInvoice=?  WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUserID);
                if (_UpdateDate == null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _UpdateDate);
                }
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);

                cmd.Parameters.AddWithValue("NoOfLineItem", _NoOfLineItem);
                cmd.Parameters.AddWithValue("NoOfPromo", _NoOfPromo);
                cmd.Parameters.AddWithValue("NoOfPaymentMode", _NoOfPaymentMode);
                cmd.Parameters.AddWithValue("NetSales", _NetSales);
                cmd.Parameters.AddWithValue("TotalVat", _TotalVat);
                cmd.Parameters.AddWithValue("InvoiceConsumerID", nInvoiceConsumerID);
                cmd.Parameters.AddWithValue("IsRTInvoice", nIsRTInvoice);

                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpadteInvoiceType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesInvoice SET InvoiceTypeID = ? WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceTypeID", _nInvoiceTypeID);
                
                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpadteRefInvoiceID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesInvoice SET RefInvoiceID = ? WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RefInvoiceID", _sRefInvoiceID);

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpadteInvoiceForDelivery(int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET InvoiceStatus = ? , VATChallanNo = ?, DeliveredBy = ?, DeliveryDate = ? " +
                                  " WHERE InvoiceID = ?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("VATChallanNo", 0);
                cmd.Parameters.AddWithValue("DeliveredBy", _nUserID);
                cmd.Parameters.AddWithValue("DeliveryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeliveryInvoice(long InvoiceID, int nStatus, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            long _NextVatChallanNo;
            try
            {
                cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + nWarehouseID + "'";
                //cmd.CommandText = "select NextVatChallanNo from t_SBU where SBUID='" + nSBUID + "'";
                object NextVatChallanNo = cmd.ExecuteScalar();
                if (NextVatChallanNo == DBNull.Value)
                {
                    _NextVatChallanNo = 1;
                }
                else
                {
                    _NextVatChallanNo = Convert.ToInt64(NextVatChallanNo);
                }             

                cmd.CommandText = "UPDATE t_SalesInvoice "+
                                  "SET InvoiceStatus = ? , VATChallanNo = ?, DeliveredBy = ?, DeliveryDate = ? "+
                                  " WHERE InvoiceID = ?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("VATChallanNo", _NextVatChallanNo);
                cmd.Parameters.AddWithValue("DeliveredBy", _nUserID);
                cmd.Parameters.AddWithValue("DeliveryDate", DateTime.Now);              
                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                _NextVatChallanNo = _NextVatChallanNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + _NextVatChallanNo + "' where  WarehouseID=?";
                //cmd.CommandText = "update t_SBU set NextVatChallanNo='" + _NextVatChallanNo + "' where  SBUID=?";
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       

        public void RetailDeliveryInvoice(long InvoiceID, int nStatus, int _nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET InvoiceStatus = ? , VATChallanNo = ?, DeliveredBy = ?, DeliveryDate = ? " +
                                  " WHERE InvoiceID = ?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("VATChallanNo", 0);
                cmd.Parameters.AddWithValue("DeliveredBy", _nUserID);
                if (_UpdateDate == null)
                {
                    cmd.Parameters.AddWithValue("DeliveryDate", DateTime.Now);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DeliveryDate", _UpdateDate);
                }
                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SendRetailDeliveryInvoice(int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
          
            try
            {               
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET InvoiceStatus = ? , VATChallanNo = ?, DeliveredBy = ?, DeliveryDate = ? " +
                                  " WHERE InvoiceID = ?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", nStatus);
                cmd.Parameters.AddWithValue("VATChallanNo", _nVATChallanNo);
                cmd.Parameters.AddWithValue("DeliveredBy", _nUserID);
                cmd.Parameters.AddWithValue("DeliveryDate", _InvoiceDate);

                cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshSalesInvoiceItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceDetail where InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["CostPrice"] != DBNull.Value)
                    {
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    }
                    else oItem.CostPrice = 0;


                    if (reader["TradePrice"] != DBNull.Value)
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    else oItem.TradePrice = 0;


                    if (reader["VATAmount"] != DBNull.Value)
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    else oItem.VATAmount = 0;

                    if (reader["ProductDiscount"] != DBNull.Value)
                    {
                        oItem.ProductDiscount = Convert.ToDouble(reader["ProductDiscount"].ToString());
                    }
                    else oItem.ProductDiscount = 0;

                    if (reader["SalesPersonBonus"] != DBNull.Value)
                    {
                        oItem.SalesPersonBonus = Convert.ToDouble(reader["SalesPersonBonus"].ToString());
                    }
                    else oItem.SalesPersonBonus = 0;


                    if (reader["CustomerProfitMargin"] != DBNull.Value)
                    {
                        oItem.CustomerProfitMargin = Convert.ToDouble(reader["CustomerProfitMargin"].ToString());
                    }
                    else oItem.CustomerProfitMargin = 0;

                    if (reader["TradePromotion"] != DBNull.Value)
                    {
                        oItem.TradePromotion = Convert.ToDouble(reader["TradePromotion"].ToString());
                    }
                    else oItem.TradePromotion = 0;

                    if (reader["Advertisement"] != DBNull.Value)
                    {
                        oItem.Advertisement = Convert.ToDouble(reader["Advertisement"].ToString());
                    }
                    else oItem.Advertisement = 0;
                    if (reader["RetailCommission"] != DBNull.Value)
                    {
                        oItem.RetailCommission = Convert.ToDouble(reader["RetailCommission"].ToString());
                    }
                    else oItem.FreeQty = 0;
                    if (reader["ProductWarrenty"] != DBNull.Value)
                    {
                        oItem.ProductWarrenty = Convert.ToDouble(reader["ProductWarrenty"].ToString());
                    }
                    else oItem.ProductWarrenty = 0;
                    if (reader["PrimaryFreightCost"] != DBNull.Value)
                    {
                        oItem.PrimaryFreightCost = Convert.ToDouble(reader["PrimaryFreightCost"].ToString());
                    }
                    else oItem.PrimaryFreightCost = 0;
                    if (reader["OtherProvission"] != DBNull.Value)
                    {
                        oItem.OtherProvission = Convert.ToDouble(reader["OtherProvission"].ToString());
                    }
                    else oItem.OtherProvission = 0;
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;
                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    else oItem.AdjustedTPAmount = 0;

                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;

                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;
                  

                    oItem.Product.ProductID = oItem.ProductID;
                    oItem.Product.RefreshByProductID();
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

        public void RefreshItemForTDVatProcess()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceDetail where InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());

                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["CostPrice"] != DBNull.Value)
                    {
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    }
                    else oItem.CostPrice = 0;


                    if (reader["TradePrice"] != DBNull.Value)
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    else oItem.TradePrice = 0;


                    if (reader["VATAmount"] != DBNull.Value)
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    else oItem.VATAmount = 0;

                    if (reader["ProductDiscount"] != DBNull.Value)
                    {
                        oItem.ProductDiscount = Convert.ToDouble(reader["ProductDiscount"].ToString());
                    }
                    else oItem.ProductDiscount = 0;

                    if (reader["SalesPersonBonus"] != DBNull.Value)
                    {
                        oItem.SalesPersonBonus = Convert.ToDouble(reader["SalesPersonBonus"].ToString());
                    }
                    else oItem.SalesPersonBonus = 0;


                    if (reader["CustomerProfitMargin"] != DBNull.Value)
                    {
                        oItem.CustomerProfitMargin = Convert.ToDouble(reader["CustomerProfitMargin"].ToString());
                    }
                    else oItem.CustomerProfitMargin = 0;

                    if (reader["TradePromotion"] != DBNull.Value)
                    {
                        oItem.TradePromotion = Convert.ToDouble(reader["TradePromotion"].ToString());
                    }
                    else oItem.TradePromotion = 0;

                    if (reader["Advertisement"] != DBNull.Value)
                    {
                        oItem.Advertisement = Convert.ToDouble(reader["Advertisement"].ToString());
                    }
                    else oItem.Advertisement = 0;
                    if (reader["RetailCommission"] != DBNull.Value)
                    {
                        oItem.RetailCommission = Convert.ToDouble(reader["RetailCommission"].ToString());
                    }
                    else oItem.FreeQty = 0;
                    if (reader["ProductWarrenty"] != DBNull.Value)
                    {
                        oItem.ProductWarrenty = Convert.ToDouble(reader["ProductWarrenty"].ToString());
                    }
                    else oItem.ProductWarrenty = 0;
                    if (reader["PrimaryFreightCost"] != DBNull.Value)
                    {
                        oItem.PrimaryFreightCost = Convert.ToDouble(reader["PrimaryFreightCost"].ToString());
                    }
                    else oItem.PrimaryFreightCost = 0;
                    if (reader["OtherProvission"] != DBNull.Value)
                    {
                        oItem.OtherProvission = Convert.ToDouble(reader["OtherProvission"].ToString());
                    }
                    else oItem.OtherProvission = 0;
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;
                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    else oItem.AdjustedTPAmount = 0;

                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;

                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    TDOldStock oTDOldStock = new TDOldStock();
                    oTDOldStock.WHID = _nWarehouseID;
                    oTDOldStock.ProductID = oItem.ProductID;
                    if (oTDOldStock.CheckQuantity())
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

        /// <summary>
        /// Refesh line item for sendind data from outlet to HO
        /// </summary>
        public void RefreshSalesInvoiceItemForDataSending()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.*,ProductCode,ProductName FROM t_SalesInvoiceDetail a, t_Product b where a.ProductID=b.ProductID and InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.InvoiceID = _InvoiceID;
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;

                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;
                    if (reader["CostPrice"] != DBNull.Value)
                    {
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    }
                    else oItem.CostPrice = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    else oItem.TradePrice = 0;
                    if (reader["VATAmount"] != DBNull.Value)
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    else oItem.VATAmount = 0;
                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;
                
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

        public void RefreshSalesInvoiceItemForDataSending1()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "   select distinct a.WarehouseID, b.ProductID, '['+ProductCode+'] '+ProductDesc as ProductDesc, ProductSerialNo, UnitPrice, Quantity,PromotionalDiscount from t_SalesInvoice a, t_SalesInvoiceProductSerial b, t_Product c, t_SalesInvoiceDetail D  where a.InvoiceID=b.InvoiceID  and b.ProductID=c.ProductID and a.InvoiceID=d.InvoiceID and b.ProductID=d.ProductID and a.InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.InvoiceID = _InvoiceID;
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductName = (string)reader["ProductDesc"];
                    oItem.ProductSerial = (string)reader["ProductSerialNo"];

                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;
                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;
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
        public void RefreshSalesInvoiceItemForDataSending2( int nReverseID, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select distinct a.WarehouseID, a.ProductID, '['+ProductCode+'] '+ProductDesc as ProductDesc,  ProductSerial as ProductSerialNo, StockType,DefectiveType,FaultDescription, FaultRemarks,a.Reason [RevReason], JobNo, UnitPrice, Quantity,PromotionalDiscount  from t_InvoiceReverseDetail a, t_Product b,  t_InvoiceReverse c, t_SalesInvoiceDetail d, t_SalesInvoice e where a.ProductID=b.ProductID and c.InvoiceNo=e.InvoiceNo and e.InvoiceID=d.InvoiceID and a.ProductID=d.ProductID  and a.ReverseID=c.ReverseID and c.ReverseID=? and c.WarehouseID=?";
                cmd.Parameters.AddWithValue("ReverseID", nReverseID);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.InvoiceID = _InvoiceID;
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductName = (string)reader["ProductDesc"];
                    oItem.ProductSerial = (string)reader["ProductSerialNo"];
                    oItem.StockType = int.Parse(reader["StockType"].ToString());
                    oItem.DefectiveType = int.Parse(reader["DefectiveType"].ToString());
                    if(reader["FaultDescription"]!=DBNull.Value)
                        oItem.FaultDescription = (string)reader["FaultDescription"];
                    if (reader["FaultRemarks"] != DBNull.Value)
                        oItem.FaultRemarks = (string)reader["FaultRemarks"];
                    if (reader["RevReason"] != DBNull.Value)
                        oItem.Reason = (string)reader["RevReason"];
                    if (reader["JobNo"] != DBNull.Value)
                        oItem.JobNo = (string)reader["JobNo"];

                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;
                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;

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
        public void RefreshSalesInvoiceItemForDataSendingNew()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.*,ProductCode,ProductName FROM t_SalesInvoiceDetailNew a, t_Product b where a.ProductID=b.ProductID and InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.InvoiceID = _InvoiceID;
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;

                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;
                    if (reader["CostPrice"] != DBNull.Value)
                    {
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    }
                    else oItem.CostPrice = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    else oItem.TradePrice = 0;
                    if (reader["VATAmount"] != DBNull.Value)
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    else oItem.VATAmount = 0;
                    oItem.PromotionalDiscount = 0;

                    oItem.TotalCharge = Convert.ToDouble(reader["Charges"].ToString());
                    oItem.TotalDiscount = Convert.ToDouble(reader["Discounts"].ToString());


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

        public void RefreshSalesInvoiceForSmartWarranty(string sInvoiceNo,DateTime dtDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                
                cmd.CommandText = "Select a.WarehouseID,b.ProductID,InvoiceNo,InvoiceDate,SundryCustomerID, " +
                                "ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,ProductSerialNo, " +
                                "SpecialComponentWarranty, " +
                                "(SELECT DATEADD(month, SpecialComponentWarranty, InvoiceDate)) WarrantyExpiryDate " +
                                "From t_SalesInvoice a,t_SalesInvoiceProductSerial b,t_Product d, " +
                                "( " +
                                "Select distinct a.InvoiceID,a.ProductID,SpecialComponentWarranty  " +
                                "From t_SalesInvoiceWarrantyCardNo a,t_WarrantyParam b  " +
                                "where a.WarrantyParameterID=b.WarrantyParamID " +
                                ") e  " +
                                "where a.InvoiceID=b.InvoiceID and b.ProductID in (Select distinct ProductID  " +
                                "From [dbo].[t_ExtendedWarrantyItem] where IsCurrent=1)   " +
                                "and b.ProductID=d.ProductID and InvoiceNo='" + sInvoiceNo + "'   " +
                                "and InvoiceDate>=DATEADD(month, -6, '" + dtDate + "') " +
                                "and a.InvoiceID=e.InvoiceID and b.ProductID=e.ProductID ";
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();
                    
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductName = (string)reader["ProductModel"];
                    oItem.ProductSerial = (string)reader["ProductSerialNo"];
                    oItem.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    oItem.SpecialComponentWarranty = int.Parse(reader["SpecialComponentWarranty"].ToString());
                    oItem.WarrantyExpiryDate = Convert.ToDateTime(reader["WarrantyExpiryDate"].ToString());


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
        public void RefreshReverseInvoiceItemNew()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,isnull(b.Charges,0) Charges,isnull(b.Discounts,0) Discounts From  " +
                                "(  " +
                                "Select InvoiceID, a.ProductID,ProductCode,ProductName, Quantity, UnitPrice,  " +
                                "CostPrice, TradePrice, VATAmount, IsFreeProduct, FreeQty  " +
                                "From t_SalesInvoiceDetail a,t_Product b where a.ProductID=b.ProductID and InvoiceID = "+ _InvoiceID + "  " +
                                ") a  " +
                                "left outer join  " +
                                "(  " +
                                "Select InvoiceID, ProductID, sum(Charges)Charges,  " +
                                "sum(Discounts) Discounts From t_SalesInvoiceDetailNew  " +
                                "where InvoiceID = "+ _InvoiceID + " group by InvoiceID, ProductID  " +
                                ") b  " +
                                "on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.InvoiceID = _InvoiceID;
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;

                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;
                    if (reader["CostPrice"] != DBNull.Value)
                    {
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    }
                    else oItem.CostPrice = 0;
                    if (reader["TradePrice"] != DBNull.Value)
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    else oItem.TradePrice = 0;
                    if (reader["VATAmount"] != DBNull.Value)
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    else oItem.VATAmount = 0;
                    oItem.PromotionalDiscount = 0;

                    oItem.TotalCharge = Convert.ToDouble(reader["Charges"].ToString());
                    oItem.TotalDiscount = Convert.ToDouble(reader["Discounts"].ToString());


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

        public void GetDPCorrectionItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.*,ProductCode,ProductName FROM t_SalesInvoiceDetail a, t_Product b where a.ProductID=b.ProductID and InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.InvoiceID = _InvoiceID;
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;

                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;

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

        public void UpadteDealerOrder()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_RetailOrderCheck " +
                                  "SET  IsCheck = ? WHERE OrderId = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsCheck", _nIsCheck);
                cmd.Parameters.AddWithValue("OrderId", _nOrderID);
              

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpadteInvoiceAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_Salesinvoice SET  InvoiceAmount = ? WHERE InvoiceID = ? and CustomerID = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetReverseInvoice(DateTime dFromDate)
        {
            double InvoiceAmount = 0;
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select Sum(InvoiceAmount) as InvoiceAmount from t_SalesInvoice " +
                        "where InvoiceDate between ? and ? and InvoiceDate < ? and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["InvoiceAmount"] != DBNull.Value)
                    {
                        InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    }
                    else
                    {
                        InvoiceAmount = 0;
                    }

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return InvoiceAmount;
        }

        public double GetReverseInvoiceHO(DateTime dFromDate, int nCustomerID)
        {
            double InvoiceAmount = 0;
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select Sum(InvoiceAmount) as InvoiceAmount from t_SalesInvoice a,t_Showroom b " +
                        "where a.WarehouseID=b.WarehouseID and b.CustomerID = ? and InvoiceDate between ? and ? and InvoiceDate < ? and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["InvoiceAmount"] != DBNull.Value)
                    {
                        InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    }
                    else
                    {
                        InvoiceAmount = 0;
                    }

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return InvoiceAmount;
        }


        public void GetWSSalesInvoice(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_WSSalesInvoice where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    if (reader["OrderID"] != DBNull.Value)
                        _nOrderID = int.Parse(reader["OrderID"].ToString());
                    else _nOrderID = 0;
                    _InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _InvoiceAmount = 0;
                    if (reader["Discount"] != DBNull.Value)
                        _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else _Discount = 0;

                    _sDeliveryAddress = (string)reader["DeliveryAddress"];
                    

                    if (reader["InvoiceBy"] != DBNull.Value)
                        _nInvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _nInvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _nDeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _nDeliveredBy = -1;
                    _nInvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _sRefDetails = reader["RefDetails"].ToString();
                    _sRemarks = reader["Remarks"].ToString();
                    _sCustomerCode = "";
                    _sCustomerName = "";
                    _sOrderNo = "";

                    GetWSSalesInvoiceItem(nInvoiceID);

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWSSalesInvoiceItem(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_WSSalesInvoiceDetail where InvoiceID=? ";
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceItem oItem = new SalesInvoiceItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["CostPrice"] != DBNull.Value)
                    {
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    }
                    else oItem.CostPrice = 0;


                    if (reader["TradePrice"] != DBNull.Value)
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    else oItem.TradePrice = 0;


                    if (reader["VATAmount"] != DBNull.Value)
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    else oItem.VATAmount = 0;

                    if (reader["ProductDiscount"] != DBNull.Value)
                    {
                        oItem.ProductDiscount = Convert.ToDouble(reader["ProductDiscount"].ToString());
                    }
                    else oItem.ProductDiscount = 0;

                    if (reader["SalesPersonBonus"] != DBNull.Value)
                    {
                        oItem.SalesPersonBonus = Convert.ToDouble(reader["SalesPersonBonus"].ToString());
                    }
                    else oItem.SalesPersonBonus = 0;


                    if (reader["CustomerProfitMargin"] != DBNull.Value)
                    {
                        oItem.CustomerProfitMargin = Convert.ToDouble(reader["CustomerProfitMargin"].ToString());
                    }
                    else oItem.CustomerProfitMargin = 0;

                    if (reader["TradePromotion"] != DBNull.Value)
                    {
                        oItem.TradePromotion = Convert.ToDouble(reader["TradePromotion"].ToString());
                    }
                    else oItem.TradePromotion = 0;

                    if (reader["Advertisement"] != DBNull.Value)
                    {
                        oItem.Advertisement = Convert.ToDouble(reader["Advertisement"].ToString());
                    }
                    else oItem.Advertisement = 0;
                    if (reader["RetailCommission"] != DBNull.Value)
                    {
                        oItem.RetailCommission = Convert.ToDouble(reader["RetailCommission"].ToString());
                    }
                    else oItem.FreeQty = 0;
                    if (reader["ProductWarrenty"] != DBNull.Value)
                    {
                        oItem.ProductWarrenty = Convert.ToDouble(reader["ProductWarrenty"].ToString());
                    }
                    else oItem.ProductWarrenty = 0;
                    if (reader["PrimaryFreightCost"] != DBNull.Value)
                    {
                        oItem.PrimaryFreightCost = Convert.ToDouble(reader["PrimaryFreightCost"].ToString());
                    }
                    else oItem.PrimaryFreightCost = 0;
                    if (reader["OtherProvission"] != DBNull.Value)
                    {
                        oItem.OtherProvission = Convert.ToDouble(reader["OtherProvission"].ToString());
                    }
                    else oItem.OtherProvission = 0;
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;

                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;

                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;


                    oItem.Product.ProductID = oItem.ProductID;
                   // oItem.Product.RefreshByProductID();
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
        public bool CheckInvoiceNo(string sInvoiceNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_SalesInvoice Where InvoiceNo='" + sInvoiceNo + "'";

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
            {
                _bFlag = false;
                return true;
            }
            else
            {
                _bFlag = true;
                return false;
            }
        }

        public bool CheckTranNoForDMS(string sTranNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_DMSProductStockTran Where TranNo='" + sTranNo + "'";

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
            {
                _bFlag = false;
                return true;
            }
            else
            {
                _bFlag = true;
                return false;
            }
        }
        public void RefreshByInvoiceForDMS(string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "select * from t_DMSProductStockTran Where TranNo=( " +
                                "Select b.Invoiceno From t_SalesInvoice a,t_SalesInvoice b  " +
                                "where a.RefInvoiceID=b.InvoiceID and a.invoiceno='" + sTranNo + "')";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["TranID"].ToString());

                    nCount++;
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForRetailInvoiceByNo(string nInvoiceNo,DateTime dInvoiceDate)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "SELECT a.*,ConsumerCode,ConsumerName,CellNo,SalesType FROM t_SalesInvoice a, t_RetailConsumer b Where a.SundryCustomerID=b.ConsumerID and InvoiceNo = '" + nInvoiceNo + "' and InvoiceDate>=DATEADD(month, -6, '" + dInvoiceDate + "') and InvoiceNo not in (Select InvoiceNo From t_ExtendedWarranty)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _InvoiceDate = (object)reader["InvoiceDate"];

                    _sConsumerCode = reader["ConsumerCode"].ToString();
                    _sConsumerName = reader["ConsumerName"].ToString();
                    _sMobileNo = reader["CellNo"].ToString();
                    _nSalesType = int.Parse(reader["SalesType"].ToString());
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _InvoiceAmount = 0;

                    if (reader["Discount"] != DBNull.Value)
                        _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else _Discount = 0;

                    if (reader["InvoiceBy"] != DBNull.Value)
                        _nInvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _nInvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _nDeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _nDeliveredBy = -1;
                    _nInvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _sRemarks = reader["Remarks"].ToString();
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    if (reader["PriceOptionID"] != DBNull.Value)
                        _nPriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    else _nPriceOptionID = -1;
                    _sRefDetails = reader["RefDetails"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                        _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    else _nSalesPromotionID = -1;
                    _SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    _nSalesPersonID = int.Parse(reader["SalesPersonID"].ToString());

                }

                reader.Close();
              
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForRetailInvoiceByNoRT(string nInvoiceNo, DateTime dInvoiceDate)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "SELECT a.*,ConsumerCode,ConsumerName,CellNo,SalesType FROM t_SalesInvoice a, t_RetailConsumer b "+
                "Where a.WarehouseID=b.WarehouseID and a.SundryCustomerID=b.ConsumerID and InvoiceNo = '" + nInvoiceNo + "' "+
                "and InvoiceDate>=DATEADD(month, -6, '" + dInvoiceDate + "') and InvoiceNo not in (Select InvoiceNo From t_ExtendedWarranty)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _InvoiceDate = (object)reader["InvoiceDate"];

                    _sConsumerCode = reader["ConsumerCode"].ToString();
                    _sConsumerName = reader["ConsumerName"].ToString();
                    _sMobileNo = reader["CellNo"].ToString();
                    _nSalesType = int.Parse(reader["SalesType"].ToString());
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _InvoiceAmount = 0;

                    if (reader["Discount"] != DBNull.Value)
                        _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else _Discount = 0;

                    if (reader["InvoiceBy"] != DBNull.Value)
                        _nInvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _nInvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _nDeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _nDeliveredBy = -1;
                    _nInvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _sRemarks = reader["Remarks"].ToString();
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    if (reader["PriceOptionID"] != DBNull.Value)
                        _nPriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    else _nPriceOptionID = -1;
                    _sRefDetails = reader["RefDetails"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                        _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    else _nSalesPromotionID = -1;
                    _SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    _nSalesPersonID = int.Parse(reader["SalesPersonID"].ToString());

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class SalesInvoices : CollectionBase
    {
        public SalesInvoice this[int i]
        {
            get { return (SalesInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoice oSalesInvoice)
        {
            InnerList.Add(oSalesInvoice);
        }

        public void RefreshForInvoiceDelivery(DateTime dFromDate, DateTime dToDate, int nStatus, string sInvoiceNo, string sCustomerCode, string sCustomerName, int nUserID)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT e.*  FROM t_SalesOrder a, t_user b, t_warehouse c, t_Employee d ,t_SalesInvoice e"+
                          " where e.orderid=a.orderid  and a.warehouseid = c.warehouseid and  b.Employeeid = d.Employeeid and c.locationid = d.locationid  and "+
                          "InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and b.userid = ? ";

            if (sInvoiceNo != "")         
            {               
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (nStatus > -1)
            {
                sSql = sSql + "and InvoiceStatus='" + nStatus + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", nUserID);
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OrderID"] != DBNull.Value)
                    {
                        SalesInvoice _oSalesInvoice = new SalesInvoice();

                        _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oSalesInvoice.OrderID = int.Parse(reader["OrderID"].ToString());
                        _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                        if (reader["InvoiceAmount"] != DBNull.Value)
                            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                        else _oSalesInvoice.InvoiceAmount = 0;
                        if (reader["InvoiceBy"] != DBNull.Value)
                            _oSalesInvoice.InvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                        else _oSalesInvoice.InvoiceBy = -1;
                        if (reader["DeliveredBy"] != DBNull.Value)
                            _oSalesInvoice.DeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                        else _oSalesInvoice.DeliveredBy = -1;
                        _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                        _oSalesInvoice.CustomerCode = sCustomerCode;
                        _oSalesInvoice.CustomerName = sCustomerName;

                        InnerList.Add(_oSalesInvoice);
                    }
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }

        public void RefreshForEPSInvoiceDelivery(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, int nIsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select InvoiceID, a.OrderID,InvoiceNo, OrderNo, b.CustomerID,b.WarehouseID,CustomerCode, " +
                            "InvoiceBy,DeliveredBy,c.Remarks,c.DeliveryAddress,PriceOptionID,RefDetails,c.SalesPromotionID, " +
                            "CustomerName,InvoiceDate,InvoiceAmount,InvoiceStatus  " +
                            "from t_EPSSales a, t_SalesOrder b, t_salesInvoice c, t_Customer d " +
                            "Where a.OrderID=b.OrderID and b.OrderID=c.OrderID and b.CustomerID=d.CustomerID ";

            if (nIsCheck != 1)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
          
            try
            {
                cmd.CommandText = sSql;                
                cmd.CommandType = CommandType.Text;      
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OrderID"] != DBNull.Value)
                    {
                        SalesInvoice _oSalesInvoice = new SalesInvoice();

                        _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oSalesInvoice.OrderID = int.Parse(reader["OrderID"].ToString());
                        _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                        _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                        _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                        if (reader["InvoiceAmount"] != DBNull.Value)
                            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                        else _oSalesInvoice.InvoiceAmount = 0;
                        if (reader["InvoiceBy"] != DBNull.Value)
                            _oSalesInvoice.InvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                        else _oSalesInvoice.InvoiceBy = -1;
                        if (reader["DeliveredBy"] != DBNull.Value)
                            _oSalesInvoice.DeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                        else _oSalesInvoice.DeliveredBy = -1;
                        _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                        _oSalesInvoice.Remarks = reader["Remarks"].ToString();
                        _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                        if (reader["PriceOptionID"] != DBNull.Value)
                            _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                        else _oSalesInvoice.PriceOptionID = -1;
                        _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                        if (reader["SalesPromotionID"] != DBNull.Value)
                            _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                        else _oSalesInvoice.SalesPromotionID = -1;
                        _oSalesInvoice.OrderNo = "";
                        _oSalesInvoice.CustomerCode = "";
                        _oSalesInvoice.CustomerName = "";
                       
                        InnerList.Add(_oSalesInvoice);
                    }
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
        public void GetDueAmountByCustomerID(int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID, InvoiceNo, InvoiceDate, CustomerID,InvoiceAmount, DueAmount from t_SalesInvoice " +
                            "Where InvoiceStatus=2 and DueAmount>0 and CustomerID=? Order by InvoiceDate ";

            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
 
                        SalesInvoice _oSalesInvoice = new SalesInvoice();

                        _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());

                        _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                        if (reader["InvoiceAmount"] != DBNull.Value)
                            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                        else _oSalesInvoice.InvoiceAmount = 0;
                        if (reader["DueAmount"] != DBNull.Value)
                            _oSalesInvoice.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                        else _oSalesInvoice.DueAmount = 0;

                        InnerList.Add(_oSalesInvoice);
                    
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForDealerorderMonitoring(DateTime dFromDate, DateTime dToDate, string sInvoiceNo)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,b.* from t_salesinvoice a,t_RetailOrderCheck b where a.orderid=b.orderid and b.DeliveryPoint= '"+(int)Dictionary.DealerOrderDeliveryPoint.Outlet+"'  and  "
                          +" a.InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and a.InvoiceDate < '" + dToDate + "' ";

            if (sInvoiceNo != "")
            {
                sInvoiceNo = "%" + sInvoiceNo + "%";
                sSql = sSql + " and InvoiceNo like '" + sInvoiceNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;              
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OrderID"] != DBNull.Value)
                    {
                        SalesInvoice _oSalesInvoice = new SalesInvoice();

                        _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oSalesInvoice.OrderID = int.Parse(reader["OrderID"].ToString());
                        _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                        _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                        _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                        if (reader["InvoiceAmount"] != DBNull.Value)
                            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                        else _oSalesInvoice.InvoiceAmount = 0;
                        if (reader["InvoiceBy"] != DBNull.Value)
                            _oSalesInvoice.InvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                        else _oSalesInvoice.InvoiceBy = -1;
                        if (reader["DeliveredBy"] != DBNull.Value)
                            _oSalesInvoice.DeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                        else _oSalesInvoice.DeliveredBy = -1;
                        _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                        _oSalesInvoice.IsCheck = int.Parse(reader["IsCheck"].ToString());

                        InnerList.Add(_oSalesInvoice);
                    }
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForRetailInvoice(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, string sCustomerID, string sCustomerName, string sMobileNo, string sAddress, bool IsCheck, int nSalesType)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "SELECT a.*,ConsumerCode,ConsumerName,CellNo, Email, SalesType,isnull(b.IsVerifiedEmail,0) IsVerifiedEmail FROM t_SalesInvoice a, t_RetailConsumer b Where a.SundryCustomerID=b.ConsumerID ";
            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (sCustomerID != "")
            {
                sSql = sSql + "and ConsumerCode = '" + sCustomerID + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + "and ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + "and CellNo like '%" + sMobileNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + "and Address like '%" + sAddress + "%'";
            }
            if (nSalesType != 0)
            {
                sSql = sSql + " and SalesType=" + nSalesType + "";
            }
            sSql = sSql + " Order by InvoiceID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];

                    _oSalesInvoice.ConsumerCode = reader["ConsumerCode"].ToString();
                    _oSalesInvoice.ConsumerName = reader["ConsumerName"].ToString();
                    _oSalesInvoice.MobileNo = reader["CellNo"].ToString();
                    _oSalesInvoice.SalesType = int.Parse(reader["SalesType"].ToString());
                    if (reader["Email"] != DBNull.Value)
                        _oSalesInvoice.Email = reader["Email"].ToString();
                    else _oSalesInvoice.Email = "";
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    if (reader["Discount"] != DBNull.Value)
                        _oSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else _oSalesInvoice.Discount = 0;

                    if (reader["InvoiceBy"] != DBNull.Value)
                        _oSalesInvoice.InvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _oSalesInvoice.InvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _oSalesInvoice.DeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _oSalesInvoice.DeliveredBy = -1;
                    _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.Remarks = reader["Remarks"].ToString();
                    _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    if (reader["PriceOptionID"] != DBNull.Value)
                        _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    else _oSalesInvoice.PriceOptionID = -1;
                    _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                        _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    else _oSalesInvoice.SalesPromotionID = -1;
                    _oSalesInvoice.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    _oSalesInvoice.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());

                    if (reader["RefInvoiceID"] != DBNull.Value)
                        _oSalesInvoice.RefInvoiceID = reader["RefInvoiceID"].ToString();
                    //else _oSalesInvoice.RefInvoiceID = "";

                    _oSalesInvoice.IsVerifiedEmail = Convert.ToInt32(reader["IsVerifiedEmail"].ToString());

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForRetailInvoiceRT(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, string sCustomerID, string sCustomerName, string sMobileNo, string sAddress, bool IsCheck, int nSalesType)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = @"Select * From 
                (
                SELECT a.*, ConsumerCode, ConsumerName, CellNo,
                Email, SalesType, isnull(b.IsVerifiedEmail, 0) IsVerifiedEmail
                FROM t_SalesInvoice a, t_RetailConsumer b
                Where a.SundryCustomerID = b.ConsumerID and a.WarehouseID = b.WarehouseID
                and a.WarehouseID = " + Utility.WarehouseID + @" and isnull(a.IsRTInvoice, 0) = 0
                Union All
                SELECT a.*, ConsumerCode, ConsumerName, CellNo,
                Email, SalesType, isnull(b.IsVerifiedEmail, 0) IsVerifiedEmail
                FROM t_SalesInvoice a, t_SalesInvoiceConsumer b
                Where a.InvoiceID = b.InvoiceID and a.InvoiceConsumerID = b.InvoiceConsumerID
                and a.WarehouseID =  " + Utility.WarehouseID + @" and isnull(a.IsRTInvoice, 0) = 1
                ) main where 1 = 1";


            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (sCustomerID != "")
            {
                sSql = sSql + "and ConsumerCode = '" + sCustomerID + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + "and ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + "and CellNo like '%" + sMobileNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + "and Address like '%" + sAddress + "%'";
            }
            if (nSalesType != 0)
            {
                sSql = sSql + " and SalesType=" + nSalesType + "";
            }
            sSql = sSql + " Order by InvoiceID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];

                    _oSalesInvoice.ConsumerCode = reader["ConsumerCode"].ToString();
                    _oSalesInvoice.ConsumerName = reader["ConsumerName"].ToString();
                    _oSalesInvoice.MobileNo = reader["CellNo"].ToString();
                    _oSalesInvoice.SalesType = int.Parse(reader["SalesType"].ToString());
                    if (reader["Email"] != DBNull.Value)
                        _oSalesInvoice.Email = reader["Email"].ToString();
                    else _oSalesInvoice.Email = "";
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    if (reader["Discount"] != DBNull.Value)
                        _oSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    else _oSalesInvoice.Discount = 0;

                    if (reader["InvoiceBy"] != DBNull.Value)
                        _oSalesInvoice.InvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _oSalesInvoice.InvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _oSalesInvoice.DeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _oSalesInvoice.DeliveredBy = -1;
                    _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.Remarks = reader["Remarks"].ToString();
                    _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    if (reader["PriceOptionID"] != DBNull.Value)
                        _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    else _oSalesInvoice.PriceOptionID = -1;
                    _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                        _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    else _oSalesInvoice.SalesPromotionID = -1;
                    _oSalesInvoice.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    _oSalesInvoice.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());

                    if (reader["RefInvoiceID"] != DBNull.Value)
                        _oSalesInvoice.RefInvoiceID = reader["RefInvoiceID"].ToString();
                    //else _oSalesInvoice.RefInvoiceID = "";

                    _oSalesInvoice.IsVerifiedEmail = Convert.ToInt32(reader["IsVerifiedEmail"].ToString());

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshRetailInvoice(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, string sCustomerName, string sMobileNo, long nInvoiceID, string sShowroomCode, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select * from t_SalesInvoice a, (Select ShowroomCode, WarehouseID, CustomerID from t_showroom )b, " +
                "(select WarehouseID, ConsumerID, ConsumerCode, ConsumerName, CustomerID, ParentCustomerID, Address, CellNo, PhoneNo, Email " +
                " from t_RetailConsumer) c  " +
                " Where a.WarehouseID=b.WarehouseID and a.WarehouseID=c.WarehouseID and c.ConsumerID=a.SundryCustomerID  " +
                " and SundryCustomerID Is Not Null ";

            if (nInvoiceID != 0)
            {
                sSql = sSql + "and InvoiceID = " + nInvoiceID + "";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + "and InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + "and ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + "and CellNo like '%" + sMobileNo + "%'";
            }
            if (sShowroomCode != "")
            {
                sSql = sSql + "and ShowroomCode like '%" + sShowroomCode + "%'";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.ShowroomCode = reader["ShowroomCode"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;
                    if (reader["InvoiceBy"] != DBNull.Value)
                        _oSalesInvoice.InvoiceBy = int.Parse(reader["InvoiceBy"].ToString());
                    else _oSalesInvoice.InvoiceBy = -1;
                    if (reader["DeliveredBy"] != DBNull.Value)
                        _oSalesInvoice.DeliveredBy = int.Parse(reader["DeliveredBy"].ToString());
                    else _oSalesInvoice.DeliveredBy = -1;
                    _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.Remarks = reader["Remarks"].ToString();
                    _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    if (reader["PriceOptionID"] != DBNull.Value)
                        _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    else _oSalesInvoice.PriceOptionID = -1;
                    _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                        _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    else _oSalesInvoice.SalesPromotionID = -1;
                    _oSalesInvoice.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    _oSalesInvoice.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForTDVatProcess(DateTime dFromDate, DateTime dToDate, string sInvoiceNo)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.* from t_salesinvoice a, v_customerdetails b Where   "
                          + " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' "
                          + " and a.customerid=b.customerid and b.channelid=4 and InvoiceTypeID in (1,2)";

            if (sInvoiceNo != "")
            {
                sInvoiceNo = "%" + sInvoiceNo + "%";
                sSql = sSql + " and InvoiceNo like '" + sInvoiceNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());                 
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    _oSalesInvoice.VATChallanNo = (int)reader["VATChallanNo"];
                                       
                    DutyTran oDutyTran = new DutyTran();
                    oDutyTran.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                    oDutyTran.DocumentNo = _oSalesInvoice.InvoiceNo;
                    oDutyTran.WHID = _oSalesInvoice.WarehouseID;

                    if (oDutyTran.Check())
                    {
                        _oSalesInvoice.RefreshItemForTDVatProcess();
                        if (_oSalesInvoice.Count > 0)
                            InnerList.Add(_oSalesInvoice);
                    }

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshVatProcess(DateTime dFromDate, DateTime dToDate, string sInvoiceNo)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_salesinvoice where "
                          + " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and InvoiceStatus in (2,7)"
                          + " and InvoiceTypeID not in ( " + (int)Dictionary.InvoiceType.CANCEL_INVOICE + ") and WarehouseID in (" + Utility.InvoiceWarehouse + ")";

            if (sInvoiceNo != "")
            {
                sInvoiceNo = "%" + sInvoiceNo + "%";
                sSql = sSql + " and InvoiceNo like '" + sInvoiceNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    
                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());                  
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                   
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["DeliveryDate"] != DBNull.Value)
                        _oSalesInvoice.DeliveryDate = (object)reader["DeliveryDate"];
                    else _oSalesInvoice.DeliveryDate = null;
                    if (reader["VATChallanNo"] != DBNull.Value)
                        _oSalesInvoice.VATChallanNo = (int)reader["VATChallanNo"];
                    else
                    {
                        //continue;
                        _oSalesInvoice.VATChallanNo = 0;
                    }

                    DutyTran oDutyTran = new DutyTran();
                    oDutyTran.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                    oDutyTran.DocumentNo = _oSalesInvoice.InvoiceNo;
                    oDutyTran.WHID = _oSalesInvoice.WarehouseID;

                    if (oDutyTran.Check())
                    {
                        _oSalesInvoice.RefreshSalesInvoiceItem();
                        InnerList.Add(_oSalesInvoice);
                    }
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
        // Refresh for Data Sending from TD oultlet to HO
        ///
        public void RefreshForDataSendingTD(int nWarehouseID)
        {
            InnerList.Clear();          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_salesinvoice a inner join t_DataTransfer b on b.DataID=a.InvoiceID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? Order By InvoiceID ";

            cmd.Parameters.AddWithValue("TableName", "t_salesinvoice");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    _oSalesInvoice.DeliveryDate = (object)reader["DeliveryDate"];
                    _oSalesInvoice.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _oSalesInvoice.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                    _oSalesInvoice.Remarks = (reader["Remarks"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.UserID = int.Parse(reader["InvoiceBy"].ToString());
                    _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    _oSalesInvoice.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _oSalesInvoice.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    if (_oSalesInvoice.VATChallanNo != 0)
                    {
                        _oSalesInvoice.VATChallanNo = int.Parse(reader["VATChallanNo"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.VATChallanNo = -1;
                    }
                    _oSalesInvoice.RefInvoiceID = reader["RefInvoiceID"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.SalesPromotionID = 0;
                    }
                    _oSalesInvoice.TransferType = int.Parse(reader["TransferType"].ToString());

                    if (_oSalesInvoice.RefInvoiceID != "")
                    {
                        RetailSalesInvoice _oRSI = new RetailSalesInvoice();
                        _oSalesInvoice.OldInvoiceNo = _oRSI.GetSalesInvoiceNo(Convert.ToInt32(_oSalesInvoice.RefInvoiceID));
                    }
                    _oSalesInvoice.RefreshSalesInvoiceItemForDataSending();
                    _oSalesInvoice.SalesInvoiceProductSerials.GETSerialByInvoiceID(_oSalesInvoice.InvoiceID);

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForDataSendingTDNew(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_salesinvoice a inner join t_DataTransfer b on b.DataID=a.InvoiceID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? Order By InvoiceID ";

            cmd.Parameters.AddWithValue("TableName", "t_salesinvoice");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    _oSalesInvoice.DeliveryDate = (object)reader["DeliveryDate"];
                    _oSalesInvoice.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _oSalesInvoice.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                    _oSalesInvoice.Remarks = (reader["Remarks"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.UserID = int.Parse(reader["InvoiceBy"].ToString());
                    _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    _oSalesInvoice.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _oSalesInvoice.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    if (_oSalesInvoice.VATChallanNo != 0)
                    {
                        _oSalesInvoice.VATChallanNo = int.Parse(reader["VATChallanNo"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.VATChallanNo = -1;
                    }
                    _oSalesInvoice.RefInvoiceID = reader["RefInvoiceID"].ToString();
                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.SalesPromotionID = 0;
                    }
                    _oSalesInvoice.TransferType = int.Parse(reader["TransferType"].ToString());

                    if (_oSalesInvoice.RefInvoiceID != "")
                    {
                        RetailSalesInvoice _oRSI = new RetailSalesInvoice();
                        _oSalesInvoice.OldInvoiceNo = _oRSI.GetSalesInvoiceNo(Convert.ToInt32(_oSalesInvoice.RefInvoiceID));
                    }
                    _oSalesInvoice.ThanaID = int.Parse(reader["CustThanaID"].ToString());

                    if (reader["NoOfLineItem"] != DBNull.Value)
                    {
                        _oSalesInvoice.NoOfLineItem = int.Parse(reader["NoOfLineItem"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.NoOfLineItem = 0;
                    }
                    if (reader["NoOfPromo"] != DBNull.Value)
                    {
                        _oSalesInvoice.NoOfPromo = int.Parse(reader["NoOfPromo"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.NoOfPromo = 0;
                    }
                    if (reader["NoOfPaymentMode"] != DBNull.Value)
                    {
                        _oSalesInvoice.NoOfPaymentMode = int.Parse(reader["NoOfPaymentMode"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.NoOfPaymentMode = 0;
                    }
                    if (reader["NetSales"] != DBNull.Value)
                    {
                        _oSalesInvoice.NetSales = Convert.ToDouble(reader["NetSales"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.NetSales = 0;
                    }
                    if (reader["TotalVat"] != DBNull.Value)
                    {
                        _oSalesInvoice.TotalVat = Convert.ToDouble(reader["TotalVat"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.TotalVat = 0;
                    }



                    _oSalesInvoice.RefreshSalesInvoiceItemForDataSendingNew();
                    _oSalesInvoice.SalesInvoiceProductSerials.GETSerialByInvoiceID(_oSalesInvoice.InvoiceID);

                    InnerList.Add(_oSalesInvoice);

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
        // Refresh for Data Sending from oultlet to HO
        ///
        public void RefreshForDataSending(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_salesinvoice a inner join t_DataTransfer b on b.DataID=a.InvoiceID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? Order By InvoiceID ";

            cmd.Parameters.AddWithValue("TableName", "t_salesinvoice");
            cmd.Parameters.AddWithValue("IsDownload", 1);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oSalesInvoice.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    _oSalesInvoice.DeliveryDate = (object)reader["DeliveryDate"];
                    _oSalesInvoice.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    _oSalesInvoice.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    _oSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _oSalesInvoice.RefDetails = reader["RefDetails"].ToString();
                    _oSalesInvoice.Remarks = (reader["Remarks"].ToString());
                    _oSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _oSalesInvoice.UserID = int.Parse(reader["InvoiceBy"].ToString());
                    _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _oSalesInvoice.PriceOptionID = int.Parse(reader["PriceOptionID"].ToString());
                    _oSalesInvoice.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    if (reader["SundryCustomerID"] != DBNull.Value)
                    {
                        _oSalesInvoice.SundryCustomerID = int.Parse(reader["SundryCustomerID"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.SundryCustomerID = -1;

                    }
                    if (reader["VATChallanNo"] != DBNull.Value)
                    {
                        _oSalesInvoice.VATChallanNo = int.Parse(reader["VATChallanNo"].ToString());
                    }
                    else
                    {
                        _oSalesInvoice.VATChallanNo = -1;
                    }
                    _oSalesInvoice.RefInvoiceID = reader["RefInvoiceID"].ToString();
                    _oSalesInvoice.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    _oSalesInvoice.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    _oSalesInvoice.TransferType = int.Parse(reader["TransferType"].ToString());

                    _oSalesInvoice.RefreshSalesInvoiceItemForDataSending();

                    _oSalesInvoice.SalesInvoiceProductSerials.GETSerialByInvoiceID(_oSalesInvoice.InvoiceID);

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshDealerInvoicePOS(DateTime dFromDate, DateTime dToDate, string sInvoiceNo)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,InvoiceNo, a.CustomerID, InvoiceDate,InvoiceStatus, InvoiceStatusName=CASE " +
                        "When InvoiceStatus=1 then 'UNDELIVERED'When InvoiceStatus=2 then 'DELIVERED'  " +
                        "When InvoiceStatus=3 then 'CANCEL'When InvoiceStatus=4 then 'REVERSE'  " +
                        "When InvoiceStatus=5 then 'PENDING'When InvoiceStatus=6 then 'PROCESSING_DELIVERY'  " +
                        "When InvoiceStatus=7 then 'PRODUCT_RETURN'When InvoiceStatus=8 then 'UNDELIVERED_DUE_TO_STOCK_LIMIT'  " +
                        "else 'Others' end,CustomerName,WarehouseID,InvoiceAmount,InstrumentNo from t_SalesInvoice a  " +
                        "INNER JOIN t_customer b ON a.CustomerID=b.customerID  " +
                        "Left outer JOIN t_CustomerTran CT ON CT.InstrumentNo=a.InvoiceNo  " +
                        "where InvoiceDate between ? and ? and InvoiceDate < ? ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

            if (sInvoiceNo != "")
            {
                sInvoiceNo = "%" + sInvoiceNo + "%";
                sSql = sSql + " and InvoiceNo like '" + sInvoiceNo + "'";
            }
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                        SalesInvoice _oSalesInvoice = new SalesInvoice();

                        _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                        _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                        if (reader["InvoiceAmount"] != DBNull.Value)
                            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                        else _oSalesInvoice.InvoiceAmount = 0;
                        _oSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                        _oSalesInvoice.CustomerName = reader["CustomerName"].ToString();
                        _oSalesInvoice.InvoiceStatusName = reader["InvoiceStatusName"].ToString();
                        _oSalesInvoice.InstrumentNo = reader["InstrumentNo"].ToString();

                        _oSalesInvoice.RefreshSalesInvoiceItemForDataSending();

                        InnerList.Add(_oSalesInvoice);
                    
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshRetailInvoiceWEB(DateTime dFromDate, DateTime dToDate,  int nCustomerID, string sInvoiceNo)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.InvoiceID,InvoiceNo,InvoiceDate, InvoiceAmount,c.Quantity, SundryCustomerName, Address,CellNo,InvoiceStatusName=CASE " +
                        "When InvoiceStatus=1 then 'UNDELIVERED'When InvoiceStatus=2 then 'DELIVERED'  " +
                        "When InvoiceStatus=3 then 'CANCEL'When InvoiceStatus=4 then 'REVERSE'  " +
                        "When InvoiceStatus=5 then 'PENDING'When InvoiceStatus=6 then 'PROCESSING_DELIVERY'  " +
                        "When InvoiceStatus=7 then 'PRODUCT_RETURN'When InvoiceStatus=8 then 'UNDELIVERED_DUE_TO_STOCK_LIMIT'  " +
                        "else 'Others' end " +
                        "from t_SalesInvoice a, t_SundryCustomer b, " +
                        "(Select InvoiceID,Sum(Quantity)Quantity from t_SalesInvoiceDetail Group by InvoiceID)c " +
                        "Where a.SundryCustomerID=b.SundryCustomerID and c.InvoiceID=a.InvoiceID " +
                        "and InvoiceDate Between ? and ? and InvoiceDate < ? " +
                        "and a.CustomerID=? ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            if (sInvoiceNo != "")
            {
                sInvoiceNo = "%" + sInvoiceNo + "%";
                sSql = sSql + " and InvoiceNo like '" + sInvoiceNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _oSalesInvoice.CustomerName = reader["SundryCustomerName"].ToString();
                    _oSalesInvoice.InvoiceStatusName = reader["InvoiceStatusName"].ToString();
                    _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _oSalesInvoice.Qty = Convert.ToInt32(reader["Quantity"].ToString());

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshInvoice(DateTime dFromDate)
        {
            InnerList.Clear();
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,InvoiceNo, InvoiceDate,WarehouseID,InvoiceAmount from t_SalesInvoice " +
                        "where InvoiceDate between ? and ? and InvoiceDate < ? and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.DELIVERED + " ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();

                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForDCS(DateTime dFromDate)
        {
            InnerList.Clear();
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select " + (int)Dictionary.DCSType.Invoice + " as DCSType,InvoiceID,InvoiceNo, InvoiceDate,InvoiceAmount from t_SalesInvoice " +
                            " where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.DELIVERED + " " +
                            " UNION All " +
                            " Select " + (int)Dictionary.DCSType.CreditCollection + " as DCSType, b.CreditApprovalID, b.ApprovalNo, a.CreateDate, Sum(a.Amount) as Amount " +
                            " from dbo.t_CustomerCreditApprovalCollection a, dbo.t_CustomerCreditApproval b " +
                            " Where a.CreditApprovalID=b.CreditApprovalID and a.WarehouseID=b.WarehouseID and a.CustomerID=b.CustomerID " +
                            " and a.CreateDate Between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate < '" + dToDate + "' " +
                            " Group by b.CreditApprovalID, b.ApprovalNo, a.CreateDate  " +
                            " Union All  " +
                            " Select 3 as DCSType,TranID,TranNo,TranDate,sum(Amount) Amount " +
                            " From t_CustomerTran where TranTypeID=5 and Terminal<>" + (int)Dictionary.Terminal.Head_Office + " " +
                            " and TranDate Between '" + dFromDate + "' and '" + dToDate + "'  " +
                            " and TranDate <'" + dToDate + "'  " +
                            " group by TranID,TranNo,TranDate   " +
                            " Union All " +
                            " Select " + (int)Dictionary.DCSType.ExtendedWarrantyCollection + "  as DCSType,ID as TranID,CertificateNo as TranNo, " +
                            " IssueDate TranDate, Amount  From t_ExtendedWarranty where IssueDate Between '" + dFromDate + "' and '" + dToDate + "'  " +
                            " and IssueDate <'" + dToDate + "' ";


      

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.DCSType = int.Parse(reader["DCSType"].ToString());
                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();

                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForDCSRT(DateTime dFromDate)
        {
            InnerList.Clear();
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select " + (int)Dictionary.DCSType.Invoice + " as DCSType,InvoiceID,InvoiceNo, InvoiceDate,InvoiceAmount from t_SalesInvoice " +
                            " where WarehouseID=" + Utility.WarehouseID + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.DELIVERED + " " +
                            " UNION All " +
                            " Select " + (int)Dictionary.DCSType.CreditCollection + " as DCSType, b.CreditApprovalID, b.ApprovalNo, a.CreateDate, Sum(a.Amount) as Amount " +
                            " from dbo.t_CustomerCreditApprovalCollection a, dbo.t_CustomerCreditApproval b " +
                            " Where a.WarehouseID=" + Utility.WarehouseID + " and a.CreditApprovalID=b.CreditApprovalID and a.WarehouseID=b.WarehouseID and a.CustomerID=b.CustomerID " +
                            " and a.CreateDate Between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate < '" + dToDate + "' " +
                            " Group by b.CreditApprovalID, b.ApprovalNo, a.CreateDate  " +
                            " Union All  " +
                            " Select 3 as DCSType,TranID,TranNo,TranDate,sum(Amount) Amount " +
                            " From t_CustomerTran where EntryLocationID=" + Utility.LocationID + " and TranTypeID=5 and Terminal<>" + (int)Dictionary.Terminal.Head_Office + " " +
                            " and TranDate Between '" + dFromDate + "' and '" + dToDate + "'  " +
                            " and TranDate <'" + dToDate + "'  " +
                            " group by TranID,TranNo,TranDate   " +
                            " Union All " +
                            " Select " + (int)Dictionary.DCSType.ExtendedWarrantyCollection + "  as DCSType,ID as TranID,CertificateNo as TranNo, " +
                            " IssueDate TranDate, Amount  From t_ExtendedWarranty where WarehouseID=" + Utility.WarehouseID + " and IssueDate Between '" + dFromDate + "' and '" + dToDate + "'  " +
                            " and IssueDate <'" + dToDate + "' ";




            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.DCSType = int.Parse(reader["DCSType"].ToString());
                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();

                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshReverseInvoice(DateTime dFromDate)
        {
            InnerList.Clear();
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,InvoiceNo, InvoiceDate,WarehouseID,InvoiceAmount from t_SalesInvoice " +
                        "where InvoiceDate between ? and ? and InvoiceDate < ? and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();

                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshReverseInvoiceRT(DateTime dFromDate)
        {
            InnerList.Clear();
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,InvoiceNo, InvoiceDate,WarehouseID,InvoiceAmount from t_SalesInvoice " +
                        "where WarehouseID=" + Utility.WarehouseID + " and InvoiceDate between ? and ? and InvoiceDate < ? and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " ";

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();

                    _oSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();

                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshInvoiceForCreditApproval(string nApprovalNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceNo,InvoiceDate,b.Amount,(InvoiceDate+CreditPeriod) as CreditExpiredDate "+
                          " From t_SalesInvoice a,t_SalesinvoicePaymentMode b,t_CustomerCreditApproval c  "+
                          " where a.InvoiceID=b.InvoiceID and b.InstrumentNo=c.ApprovalNo and PaymentModeID=6  " +
                          " and c.ApprovalNo = ?";

            cmd.Parameters.AddWithValue("ApprovalNo", nApprovalNo);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    _oSalesInvoice.CreditExpiredDate = Convert.ToDateTime(reader["CreditExpiredDate"].ToString());
                    if (reader["Amount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["Amount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSalesInvoicePromoMapping(string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_SalesInvoiceDiscountChargeMap where InvoiceNo = '" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoiceItem _oSalesInvoice = new SalesInvoiceItem();
                    _oSalesInvoice.ID = Convert.ToInt32(reader["ID"].ToString());
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    //_oSalesInvoice.ProductID = Convert.ToInt32(reader["ProductID"].ToString());

                    if (reader["DiscountTypeID"] != DBNull.Value)
                        _oSalesInvoice.DiscountTypeID = Convert.ToInt32(reader["DiscountTypeID"].ToString());
                    else _oSalesInvoice.DiscountTypeID = -1;

                    _oSalesInvoice.DataID = Convert.ToInt32(reader["DataID"].ToString());

                    if (reader["SlabID"] != DBNull.Value)
                        _oSalesInvoice.SlabID = Convert.ToInt32(reader["SlabID"].ToString());
                    else _oSalesInvoice.SlabID = -1;

                    if (reader["OfferID"] != DBNull.Value)
                        _oSalesInvoice.OfferID = Convert.ToInt32(reader["OfferID"].ToString());
                    else _oSalesInvoice.OfferID = -1;

                    _oSalesInvoice.TableName = reader["TableName"].ToString();
                    _oSalesInvoice.IsTableData = Convert.ToInt32(reader["IsTableData"].ToString());
                    _oSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    if (reader["FreeProductID"] != DBNull.Value)
                        _oSalesInvoice.FreeProductID = Convert.ToInt32(reader["FreeProductID"].ToString());
                    else _oSalesInvoice.FreeProductID = -1;

                    if (reader["FreeQty"] != DBNull.Value)
                        _oSalesInvoice.FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    else _oSalesInvoice.FreeQty = -1;

                    if (reader["IsScratchCardFreeProduct"] != DBNull.Value)
                        _oSalesInvoice.IsScratchCardFreeProduct = Convert.ToInt32(reader["IsScratchCardFreeProduct"].ToString());
                    else _oSalesInvoice.IsScratchCardFreeProduct = -1;

                    if (reader["PromoEMITenureID"] != DBNull.Value)
                        _oSalesInvoice.PromoEMITenureID = Convert.ToInt32(reader["PromoEMITenureID"].ToString());
                    else _oSalesInvoice.PromoEMITenureID = -1;

                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSalesInvoicePromoMappingProduct(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_SalesInvoiceDiscountChargeMapProduct where ID = " + nID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoiceItem _oSalesInvoice = new SalesInvoiceItem();
                    _oSalesInvoice.ID = Convert.ToInt32(reader["ID"].ToString());
                    _oSalesInvoice.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetGridLineItem(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select InvoiceNo,InvoiceDate,InvoiceAmount,DueAmount,Amount from t_SalesInvoice A "+
                           "inner join t_InvoiceWisePayment B on A.InvoiceID = B.InvoiceID "+
                            "where B.CustomerTranID = " + nTranID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();
                    
                    _oSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _oSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _oSalesInvoice.InvoiceAmount = 0;
                    if (reader["DueAmount"] != DBNull.Value)
                        _oSalesInvoice.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else _oSalesInvoice.DueAmount = 0;
                    if (reader["Amount"] != DBNull.Value)
                        _oSalesInvoice.ReceiveAmount = Convert.ToDouble(reader["Amount"].ToString());
                    else _oSalesInvoice.ReceiveAmount = 0;
                    InnerList.Add(_oSalesInvoice);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSalesDataForSCM(int nTyear,int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From (Select a.*,isnull(DealerSalesQty,0) DealerSalesQty,isnull(DealerSalesVal,0) DealerSalesVal, " +
                        "isnull(B2BSalesQty,0) B2BSalesQty,isnull(B2BSalesVal,0) B2BSalesVal,isnull(RetailSalesQty,0) RetailSalesQty, " +
                        "isnull(RetailSalesValue,0) RetailSalesValue, isnull(OtherSalesQty,0) OtherSalesQty, " +
                        "isnull(OtherSalesValue,0) OtherSalesValue  " +
                        "From ( " +
                        "SELECT number as MonthNo, " +
                        "DATENAME(MONTH, cast('2013 -'+ ltrim(rtrim(CAST(number as varchar(2)))) + '-1' as datetime)) MonthName " +
                        "FROM master..spt_values " +
                        "WHERE Type = 'P' and number between 1 and 12 " +
                        ") a " +
                        "Left Outer Join  " +
                        "( " +
                        "Select MonthNo,sum(DealerSalesQty) DealerSalesQty,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesQty) B2BSalesQty, " +
                        "sum(B2BSalesVal) B2BSalesVal,sum(RetailSalesQty) RetailSalesQty,sum(RetailSalesValue) RetailSalesValue, " +
                        "sum(OtherSalesQty) OtherSalesQty,sum(OtherSalesValue) OtherSalesValue " +
                        "From  " +
                        "( " +
                        "Select month(InvoiceDate) MonthNo,case when SalesType=5 then sum(SalesQty+FreeQty) else 0 end as DealerSalesQty, " +
                        "case when SalesType=5 then sum(NetSale) else 0 end as DealerSalesVal, " +
                        "case when SalesType=3 then sum(SalesQty+FreeQty) else 0 end as B2BSalesQty, " +
                        "case when SalesType=3 then sum(NetSale) else 0 end as B2BSalesVal, " +
                        "case when SalesType in (1,2,4,6) then sum(SalesQty+FreeQty) else 0 end as RetailSalesQty, " +
                        "case when SalesType in (1,2,4,6) then sum(NetSale) else 0 end as RetailSalesValue, " +
                        "case when isnull(SalesType,-1) not in (1,2,3,4,5,6) then sum(SalesQty+FreeQty) else 0 end as OtherSalesQty, " +
                        "case when isnull(SalesType,-1) not in (1,2,3,4,5,6) then sum(NetSale) else 0 end as OtherSalesValue " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct a,TELSYSDB.DBO.t_CustomerType b  " +
                        "where a.CustomerTypeID=b.CustTypeID and CompanyName='TEL' and ProductID=" + nProductID + " " +
                        "and year(InvoiceDate)=" + nTyear + " " +
                        "group by SalesType,month(InvoiceDate) " +
                        ") Main group by MonthNo " +
                        ") b " +
                        "on a.MonthNo=b.MonthNo) Main  ORDER BY MonthNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoice _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.MonthNo = Convert.ToInt32(reader["MonthNo"].ToString());
                    _oSalesInvoice.MonthName = reader["MonthName"].ToString();
                    _oSalesInvoice.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oSalesInvoice.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oSalesInvoice.RetailSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oSalesInvoice.OtherSalesQty = Convert.ToInt32(reader["OtherSalesQty"].ToString());


                    _oSalesInvoice.DealerSalesValue = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oSalesInvoice.B2BSalesValue = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oSalesInvoice.RetailSalesValue = Convert.ToDouble(reader["RetailSalesValue"].ToString());
                    _oSalesInvoice.OtherSalesValue = Convert.ToDouble(reader["OtherSalesValue"].ToString());

                    InnerList.Add(_oSalesInvoice);

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
