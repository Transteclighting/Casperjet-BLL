// <summary>
// Compamy: Transcom Electronics Limited
// Primary Author: <Unknown>
// Secondary Author: Arif Khan/Uttam
// Date: April 10, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Product.
// Modify Person And Date: Uttam 14-Apr-14
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
    public class Product
    {
        private int _nProductID;      
        private string _sProductCode;
        private string _sProductName;
        private string _sProductDesc;
        private string _sProductModel;
        private string _sSmallUnitOfMeasure;
        private string _sLargeUnitOfMeasure;
        private int _nUOMConversionFactor;
        private DateTime _dEntryDate;
        private object _dLastUpdateDate;
        private int _nProductType;
        private int _nProductGroupID;
        private int _nBrandID;
        private bool _bIsActive;
        private object _sHSCodeID;
        private string _sMidUnitOfMeasure;
        private int _nLSRatio;
        private int _nMSRatio;
        private int _nSupplyType;
        private int _nVATApplicable;
        private string _sProductSBUs;
        private bool _bUploadStatus;
        private DateTime _dUploadDate;
        private DateTime _dDownloadDate;
        private int _nRowStatus;
        private int _nInventoryCategory;
        private int _nItemCategory;
        private double _NSP;
        private double _RSP;
        private bool _bFlag;
        private int _nIsBarcodeItem;
        private int _nShadowPriceID;
        private ProductDetail _oProductDetail;
        private int _nActive;
        private int _nCurrentStock;
        private double _TradePrice;

        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }


        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        private int _IsActiveProduct;
        public int IsActiveProduct
        {
            get { return _IsActiveProduct; }
            set { _IsActiveProduct = value; }
        }
        private double _CostPrice;
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }

        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        public int Active
        {
            get { return _nActive; }
            set { _nActive = value; }
        }

        public int ProductID
		{
			get {return _nProductID;}
			set {_nProductID=value;}
		}

        public int ShadowPriceID
        {
            get { return _nShadowPriceID; }
            set { _nShadowPriceID = value; }
        }

        private string _sRemarks;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public string ProductCode
        {
            get {return _sProductCode;}
            set {_sProductCode = value;}
        }
        public string ProductName
        {
            get {return _sProductName;}
            set {_sProductName = value;}
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
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        public object LastUpdateDate
        {
            get { return _dLastUpdateDate; }
            set { _dLastUpdateDate = value; }
        }
        public int ProductType
        {
            get { return _nProductType; }
            set { _nProductType = value; }
        }
        public int ProductGroupID
        {
            get { return _nProductGroupID; }
            set { _nProductGroupID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
        }
        public object HSCodeID
        {
            get { return _sHSCodeID; }
            set { _sHSCodeID = value; }
        }
        public string MidUnitOfMeasure
        {
            get { return _sMidUnitOfMeasure; }
            set { _sMidUnitOfMeasure = value; }
        }
        public int LSRatio
        {
            get { return _nLSRatio; }
            set { _nLSRatio = value; }
        }

        private int _nVATType;
        public int VATType
        {
            get { return _nVATType; }
            set { _nVATType = value; }
        }

        private string _sPetName;
        public string PetName
        {
            get { return _sPetName; }
            set { _sPetName = value; }
        }
        private int _nIsVatApplicableonNetPrice;
        public int IsVatApplicableonNetPrice
        {
            get { return _nIsVatApplicableonNetPrice; }
            set { _nIsVatApplicableonNetPrice = value; }
        }

        public int MSRatio
        {
            get { return _nMSRatio; }
            set { _nMSRatio = value; }
        }
        public int SupplyType
        {
            get { return _nSupplyType; }
            set { _nSupplyType = value; }
        }
        public int VATApplicable
        {
            get { return _nVATApplicable; }
            set { _nVATApplicable = value; }
        }
        public string ProductSBUs
        {
            get { return _sProductSBUs; }
            set { _sProductSBUs = value; }
        }
        public bool UploadStatus
        {
            get { return _bUploadStatus; }
            set { _bUploadStatus = value; }
        }
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }
        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }
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
        public ProductDetail ProductDetail
        {
            get
            {
                if (_oProductDetail == null)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _nProductID;
                    _oProductDetail.Refresh();
                }

                return _oProductDetail;
            }
        }

        private DateTime _dEffectiveDate;

        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }
        private int _nType;
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        private int _nHistoryID;
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }
        private int _nFrom;
        public int From
        {
            get { return _nFrom; }
            set { _nFrom = value; }
        }
        private int _nTo;
        public int To
        {
            get { return _nTo; }
            set { _nTo = value; }
        }
        private string _sHistoryRemarks;
        public string HistoryRemarks
        {
            get { return _sHistoryRemarks; }
            set { _sHistoryRemarks = value.Trim(); }
        }

        private int _StakeLevel;
        public int StakeLevel
        {
            get { return _StakeLevel; }
            set { _StakeLevel = value; }
        }
        private double _Length;
        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        private double _Weight;
        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        private double _Hight;
        public double Hight
        {
            get { return _Hight; }
            set { _Hight = value; }
        }

        public void Add()
        {
            StringBuilder sQueryString = new StringBuilder();

            int nMaxProductID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                string sSql = "SELECT MAX([ProductID]) FROM t_Product";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductID = 1;
                }
                else
                {
                    nMaxProductID = Convert.ToInt32(maxID) + 1;
                }
                if (_nProductID == 0)
                {
                    _nProductID = nMaxProductID;
                }
                
                sQueryString.Append("INSERT INTO t_Product(");
                sQueryString.Append("ProductID, ProductCode, ProductName, ProductDesc,ProductModel,");
                sQueryString.Append("SmallUnitOfMeasure, LargeUnitOfMeasure, UOMConversionFactor,");
                sQueryString.Append("EntryDate, LastUpdateDate, ProductGroupID, ProductType, BrandID,");
                sQueryString.Append("IsActive,HSCodeID,MidUnitOfMeasure,LSRatio,MSRatio,SupplyType,");
                sQueryString.Append("VatApplicable,ProductSBUs, UploadStatus,InventoryCategory,ItemCategory,IsBarcodeItem,VATType,EntryUserID,EditUserID,IsVatApplicableonNetPrice,PetName)");
                sQueryString.Append("Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");

                cmd.CommandText = sQueryString.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("ProductDesc", _sProductDesc);

                if (_sProductModel != null)
                    cmd.Parameters.AddWithValue("ProductModel", _sProductModel);
                else cmd.Parameters.AddWithValue("ProductModel", null);

                cmd.Parameters.AddWithValue("SmallUnitOfMeasure", _sSmallUnitOfMeasure);
                cmd.Parameters.AddWithValue("LargeUnitOfMeasure", _sLargeUnitOfMeasure);
                cmd.Parameters.AddWithValue("UOMConversionFactor", _nUOMConversionFactor);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);

                if (_dLastUpdateDate != null)
                    cmd.Parameters.AddWithValue("LastUpdateDate", _dLastUpdateDate);
                else cmd.Parameters.AddWithValue("LastUpdateDate", null);

                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("ProductType", _nProductType);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);

                if (_sHSCodeID != null)
                    cmd.Parameters.AddWithValue("HSCodeID", _sHSCodeID);
                else cmd.Parameters.AddWithValue("HSCodeID", null);

                if (_sMidUnitOfMeasure != null)
                    cmd.Parameters.AddWithValue("MidUnitOfMeasure", _sMidUnitOfMeasure);
                else cmd.Parameters.AddWithValue("MidUnitOfMeasure", null);

                if (_nLSRatio != null)
                    cmd.Parameters.AddWithValue("LSRatio", _nLSRatio);
                else cmd.Parameters.AddWithValue("LSRatio", null);

                if (_nMSRatio != null)
                    cmd.Parameters.AddWithValue("MSRatio", _nMSRatio);
                else cmd.Parameters.AddWithValue("MSRatio", null);

                if (_nSupplyType != null)
                    cmd.Parameters.AddWithValue("SupplyType", _nSupplyType);
                else cmd.Parameters.AddWithValue("SupplyType", null);

                if (_nVATApplicable != null)
                    cmd.Parameters.AddWithValue("VatApplicable", _nVATApplicable);
                else cmd.Parameters.AddWithValue("VatApplicable", null);

                if (_sProductSBUs != null)
                    cmd.Parameters.AddWithValue("ProductSBUs", _sProductSBUs);
                else cmd.Parameters.AddWithValue("ProductSBUs", null);

                cmd.Parameters.AddWithValue("UploadStatus", Convert.DBNull);

                if (_nInventoryCategory != null)
                    cmd.Parameters.AddWithValue("InventoryCategory", _nInventoryCategory);
                else cmd.Parameters.AddWithValue("InventoryCategory", null);

                if (_nItemCategory != null)
                    cmd.Parameters.AddWithValue("ItemCategory", _nItemCategory);
                else cmd.Parameters.AddWithValue("ItemCategory", null);

                cmd.Parameters.AddWithValue("IsBarcodeItem", _nIsBarcodeItem);
                cmd.Parameters.AddWithValue("VATType", _nVATType);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("EditUserID", null);
                cmd.Parameters.AddWithValue("IsVatApplicableonNetPrice", _nIsVatApplicableonNetPrice);
                cmd.Parameters.AddWithValue("PetName", _sPetName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                InsertProductSpace(_nProductID);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public void InsertProductSpace(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            try
            {
                cmd.CommandText = "INSERT INTO t_ProductSpace (ProductID,StakeLevel,Length,Weight,Hight) VALUES(?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("StakeLevel", _StakeLevel);
                cmd.Parameters.AddWithValue("Length", _Length);
                cmd.Parameters.AddWithValue("Weight", _Weight);
                cmd.Parameters.AddWithValue("Hight", _Hight);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertCACProduct()
        {
            int nMaxProductID = 0;
            string sProductCode = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([ProductID]) FROM t_CACProduct";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductID = 1;
                }
                else
                {
                    nMaxProductID = Convert.ToInt32(maxID) + 1;
                }
                _nProductID = nMaxProductID;
                sProductCode = "CAC" + _nProductID.ToString("00000");
                _sProductCode = sProductCode;


                cmd.CommandText = "INSERT INTO t_CACProduct (ProductID,ProductCode, " +
                                   "ProductName,Description,Model,AGID,BrandID,CreateDate,CreateUserID, "+
                                   "UpdateDate,UpdateUserID,IsActive) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("ProductDesc", _sProductDesc);
                if (_sProductModel != null)
                    cmd.Parameters.AddWithValue("ProductModel", _sProductModel);
                else cmd.Parameters.AddWithValue("ProductModel", null);
                cmd.Parameters.AddWithValue("AGID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("IsActive", _nActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void EditCACProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_CACProduct SET ProductName=?, Description=?, Model=?, " +
                       "AGID=?, BrandID=?, IsActive=?, UpdateDate=?, UpdateUserID=? WHERE ProductID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("Description", _sProductDesc);
                if (_sProductModel != null)
                    cmd.Parameters.AddWithValue("Model", _sProductModel);
                else cmd.Parameters.AddWithValue("Model", null);
                cmd.Parameters.AddWithValue("AGID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("IsActive", _nActive);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
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
            string sSql = "";

            try
            {

                sSql = "UPDATE t_Product SET ProductCode=?, ProductName=?,ProductDesc=?,ProductModel=?," +
                     " SmallUnitOfMeasure=?, LargeUnitOfMeasure=?, UOMConversionFactor=?,LastUpdateDate=?," +
                     " ProductGroupID=?,ProductType=?,BrandID=?,IsActive=?,HSCodeID=?,MidUnitOfMeasure=?,LSRatio=?," +
                     " MSRatio=?,SupplyType=?,VatApplicable=?,ProductSBUs=?,UploadStatus=?,InventoryCategory=?,ItemCategory=?, IsBarcodeItem=?,VATType=?,EditUserID=?,IsVatApplicableonNetPrice=?,PetName=? " +
                     " WHERE ProductID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("ProductDesc", _sProductDesc);

                if (_sProductModel != null)
                    cmd.Parameters.AddWithValue("ProductModel", _sProductModel);
                else cmd.Parameters.AddWithValue("ProductModel", null);

                cmd.Parameters.AddWithValue("SmallUnitOfMeasure", _sSmallUnitOfMeasure);
                cmd.Parameters.AddWithValue("LargeUnitOfMeasure", _sLargeUnitOfMeasure);
                cmd.Parameters.AddWithValue("UOMConversionFactor", _nUOMConversionFactor);

                if (_dLastUpdateDate != null)
                    cmd.Parameters.AddWithValue("LastUpdateDate", _dLastUpdateDate);
                else cmd.Parameters.AddWithValue("LastUpdateDate", null);

                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("ProductType", _nProductType);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);

                if (_sHSCodeID != null)
                    cmd.Parameters.AddWithValue("HSCodeID", _sHSCodeID);
                else cmd.Parameters.AddWithValue("HSCodeID", null);

                if (_sMidUnitOfMeasure != null)
                    cmd.Parameters.AddWithValue("MidUnitOfMeasure", _sMidUnitOfMeasure);
                else cmd.Parameters.AddWithValue("MidUnitOfMeasure", null);

                if (_nLSRatio != null)
                    cmd.Parameters.AddWithValue("LSRatio", _nLSRatio);
                else cmd.Parameters.AddWithValue("LSRatio", null);

                if (_nMSRatio != null)
                    cmd.Parameters.AddWithValue("MSRatio", _nMSRatio);
                else cmd.Parameters.AddWithValue("MSRatio", null);

                if (_nSupplyType != null)
                    cmd.Parameters.AddWithValue("SupplyType", _nSupplyType);
                else cmd.Parameters.AddWithValue("SupplyType", null);

                if (_nVATApplicable != null)
                    cmd.Parameters.AddWithValue("VatApplicable", _nVATApplicable);
                else cmd.Parameters.AddWithValue("VatApplicable", null);

                if (_sProductSBUs != null)
                    cmd.Parameters.AddWithValue("ProductSBUs", _sProductSBUs);
                else cmd.Parameters.AddWithValue("ProductSBUs", null);

                cmd.Parameters.AddWithValue("UploadStatus", Convert.DBNull);

                if (_nInventoryCategory != null)
                    cmd.Parameters.AddWithValue("InventoryCategory", _nInventoryCategory);
                else cmd.Parameters.AddWithValue("InventoryCategory", null);

                if (_nItemCategory != null)
                    cmd.Parameters.AddWithValue("ItemCategory", _nItemCategory);
                else cmd.Parameters.AddWithValue("ItemCategory", null);

                cmd.Parameters.AddWithValue("IsBarcodeItem", _nIsBarcodeItem);
                cmd.Parameters.AddWithValue("VATType", _nVATType);
                cmd.Parameters.AddWithValue("EditUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IsVatApplicableonNetPrice", _nIsVatApplicableonNetPrice);
                cmd.Parameters.AddWithValue("PetName", _sPetName);

                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                UpdateProductSpace(_nProductID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateProductSpace(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_ProductSpace SET StakeLevel=?,Length=?,Weight=?,Hight=? WHERE ProductID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("StakeLevel", _StakeLevel);
                cmd.Parameters.AddWithValue("Length", _Length);
                cmd.Parameters.AddWithValue("Weight", _Weight);
                cmd.Parameters.AddWithValue("Hight", _Hight);

                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_Product SET InventoryCategory=? WHERE ProductID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                 
                
                if (_nInventoryCategory != null)
                    cmd.Parameters.AddWithValue("InventoryCategory", _nInventoryCategory);
                else cmd.Parameters.AddWithValue("InventoryCategory", null);
                
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void EditShadowPrice()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_SCMShadowPrice SET ShadowPrice = ?,UpdateDate = ?,UpdateUserID = ? WHERE ShadowPriceID = ? and ProductID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ShadowPrice", _RSP);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ShadowPriceID", _nShadowPriceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

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
                sSql = "DELETE FROM t_Product WHERE [ProductID]=?";
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
               
                throw (ex);
            }
        }

        public void DeleteShadowPrice(int nProductID, int nShadowPriceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_SCMShadowPrice WHERE [ProductID]=? and [ShadowPriceID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("ShadowPriceID", nShadowPriceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void Refresh()
            {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT a.*,isnull(IsVatApplicableonNetPrice,0) IsVatApplicableonNetPrice,isnull(VATType,0) VATType FROM v_ProductDetails a,t_Product b where a.ProductID=b.ProductID and  a.ProductCode =?";
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    _nProductID = (int)reader["ProductID"];
                    _nIsVatApplicableonNetPrice = (int)reader["IsVatApplicableonNetPrice"];
                    _nVATType = (int)reader["VATType"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;
                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _TradePrice = 0;

                    if (reader["NSP"] != DBNull.Value)
                        _NSP = Convert.ToDouble(reader["NSP"].ToString());
                    else _NSP = 0;

                    if (reader["VAT"] != DBNull.Value)
                        _VAT = Convert.ToDouble(reader["VAT"].ToString());
                    else _VAT = 0;


                    if (reader["SupplyType"] != DBNull.Value)
                        _nSupplyType = Convert.ToInt32(reader["SupplyType"].ToString());
                    else _nSupplyType = 1;

                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _CostPrice = 0;


                    if (reader["IsActive"] != DBNull.Value)
                        _IsActiveProduct = Convert.ToInt16(reader["IsActive"].ToString());
                    else _IsActiveProduct = 0;

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) Flag = false;
            else Flag = true;
        }

        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductCode =?";
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _nMAGID = (int)reader["MAGID"];


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) Flag = false;
            else Flag = true;
        }
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
          
            try
            {
                cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];
                    
                    if (reader["ProductModel"] != DBNull.Value)
                        _sProductModel = (string)reader["ProductModel"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _sSmallUnitOfMeasure = (string)reader["SmallUnitOfMeasure"];
                    if(reader["MidUnitOfMeasure"]!=DBNull.Value)
                        _sMidUnitOfMeasure = (string)reader["MidUnitOfMeasure"];
                    _sLargeUnitOfMeasure = (string)reader["LargeUnitOfMeasure"];
                    if (reader["MSRatio"] != DBNull.Value)
                        _nMSRatio = Convert.ToInt32(reader["MSRatio"]);
                    if (reader["LSRatio"] != DBNull.Value)
                        _nLSRatio = Convert.ToInt32(reader["LSRatio"]);
                    _nUOMConversionFactor = Convert.ToInt32(reader["UOMConversionFactor"]);

                    if (reader["RSP"] != DBNull.Value)
                        _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    else _RSP = 0;
                    if (reader["CostPrice"] != DBNull.Value)
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _CostPrice = 0;
                    if (reader["InventoryCategory"] != DBNull.Value)
                        _nInventoryCategory = Convert.ToInt32(reader["InventoryCategory"].ToString());
                    else _nInventoryCategory= 0;

                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 0;

                    if (reader["SupplyType"] != DBNull.Value)
                        _nSupplyType = Convert.ToInt32(reader["SupplyType"].ToString());
                    else _nSupplyType = 0;

                    if (reader["ProductType"] != DBNull.Value)
                        _nProductType = Convert.ToInt32(reader["ProductType"].ToString());
                    else _nProductType = 0;
                    if (reader["IsBarcodeItem"] != DBNull.Value)
                        _nIsBarcodeItem = Convert.ToInt32(reader["IsBarcodeItem"].ToString());
                    else _nIsBarcodeItem = 1;


                    if (reader["TradePrice"] != DBNull.Value)
                        _TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    else _TradePrice = 0;

                    if (reader["VAT"] != DBNull.Value)
                        _VAT = Convert.ToDouble(reader["VAT"].ToString());
                    else _VAT = 0;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }



            //txtSmallUOM.Text = oProduct.SmallUnitOfMeasure;
            //txtMidUOM.Text = oProduct.MidUnitOfMeasure;
            //txtLargeUOM.Text = oProduct.LargeUnitOfMeasure;
            //numMSRatio.Value = oProduct.MSRatio;
            //numLSRatio.Value = oProduct.LSRatio;
            //numMOQ.Value = oProduct.UOMConversionFactor;

            //cmbInventoryCategory.SelectedIndex = oProduct.InventoryCategory - 1;
            //cmbItemCategory.SelectedIndex = oProduct.ItemCategory - 1;
            //cmbProductType.SelectedIndex = oProduct.ProductType - 1;
            //cmbSupplyType.SelectedIndex = oProduct.SupplyType - 1;
            //cmbHSCode.SelectedIndex = 0;
            //if (oProduct.VATApplicable) cmbVAT.SelectedIndex = 1;
            //else cmbVAT.SelectedIndex = 0;
        }
        public void RefreshByProductID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM v_productDetails where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sProductDesc = (string)reader["ProductDesc"];

                    if (reader["ItemCategory"] != DBNull.Value)
                        _nItemCategory = Convert.ToInt32(reader["ItemCategory"].ToString());
                    else _nItemCategory = 1;

                    if (reader["IsBarcodeItem"] != DBNull.Value)
                    {
                        _nIsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());
                    }
                    else
                    {
                        _nIsBarcodeItem = 1;
                    }
                    if (reader["UOMConversionFactor"] != DBNull.Value)
                        _nUOMConversionFactor = int.Parse(reader["UOMConversionFactor"].ToString());
                    else _nUOMConversionFactor = 0;

                    if (reader["SmallUnitOfmeasure"] != DBNull.Value)
                        _sSmallUnitOfMeasure = reader["SmallUnitOfmeasure"].ToString();
                    else _sSmallUnitOfMeasure = "";

                    if (reader["MAGID"] != DBNull.Value)
                        _nMAGID = Convert.ToInt32(reader["MAGID"]);
                    else _nMAGID = 0;

                    if (reader["BrandID"] != DBNull.Value)
                        _nBrandID = Convert.ToInt32(reader["BrandID"]);
                    else _nBrandID = 0;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddShadowPrice()
        {
            int nPriceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                    sSql = "SELECT MAX([ShadowPriceID]) FROM t_SCMShadowPrice";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nPriceID = 1;
                    }
                    else
                    {
                        nPriceID = Convert.ToInt32(maxID) + 1;
                    }
                    _nShadowPriceID = nPriceID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SCMShadowPrice (ShadowPriceID,ProductID,ShadowPrice,CreateDate,CreateUserID,UpdateDate,UpdateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShadowPriceID", _nShadowPriceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ShadowPrice", _RSP);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
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
        public void RefreshByCACCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From  " +
                    "(    " +
                    "Select a.*,isnull(CPBDT,0) CostPrice,isnull(RSP,0) RSP,  " +
                    "isnull(isnull(CurrentStock,0)-isnull(BookingStock,0),0) as CurrentStock From     " +
                    "(    " +
                    "Select * From     " +
                    "(    " +
                    "Select ProductID,ProductCode,ProductName,Description,Model,    " +
                    "a.BrandID,BrandDesc as BrandName,AGID,AG.PDTGroupName as AG,    " +
                    "ASG.PdtGroupID as ASGID,ASG.PDTGroupName as ASG,    " +
                    "MAG.PdtGroupID as MAGID,MAG.PDTGroupName as MAG,    " +
                    "PG.PdtGroupID as PGGID,PG.PDTGroupName as PG,    " +
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
                    ") Main where ProductCode = ?";
                

                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _nCurrentStock = (int)reader["CurrentStock"];
                    _CostPrice = (double)reader["CostPrice"];
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

        public void AddProductHistory()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                //sSql = "SELECT MAX([HistoryID]) FROM t_ProductHistory";
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxHistoryID = 1;
                //}
                //else
                //{
                //    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                //}
                //_nHistoryID = nMaxHistoryID;
                
                sSql = "INSERT INTO t_ProductHistory (ProductID, Type, FromSide, ToSide, EffectiveDate, Remarks, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("FromSide", _nFrom);
                cmd.Parameters.AddWithValue("ToSide", _nTo);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshProductSpace()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * from t_ProductSpace where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];

                    _StakeLevel = (int)reader["StakeLevel"];
                    _Length = (double)reader["Length"];
                    _Weight = (double)reader["Weight"];
                    _Hight = (double)reader["Hight"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) Flag = false;
            else Flag = true;
        }
    }

    public class Products:CollectionBase
    {
        public Product this[int i]
        {
            get { return (Product)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndex(int nProductID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductID == nProductID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(Product oProduct)
        {
            InnerList.Add(oProduct);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Product order by ProductName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product oProduct = new Product();

                    oProduct.ProductID = (int)reader["ProductID"];
                    oProduct.ProductCode = (string)reader["ProductCode"];
                    oProduct.ProductName = (string)reader["ProductName"];
                    oProduct.ProductDesc = (string)reader["ProductDesc"];
                    oProduct.ProductModel = reader["ProductDesc"].ToString();  
                    InnerList.Add(oProduct);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMobileDescForTMLSMDPStock()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select DISTINCT ProductDesc from dbo.v_ProductDetails where IsActive = '1'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product oProduct = new Product();
                    oProduct.ProductName = (string)reader["ProductDesc"];                  
                    InnerList.Add(oProduct);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSearchBy(string sProductSearchBy,string sSearchBy)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sSearchBy == "Product Code")
            {
                if (sSearchBy != "")
                {
                    sProductSearchBy = "%" + sProductSearchBy + "%";
                    sSql = "SELECT * FROM t_Product where ProductCode like '" + sProductSearchBy + "'";
                }
                else sSql = "SELECT * FROM t_Product ";
            }
            else if (sSearchBy == "Product Name")
            {
                if (sSearchBy != "")
                {
                    sProductSearchBy = "%" + sProductSearchBy + "%";
                    sSql = "SELECT * FROM t_Product where ProductName like '" + sProductSearchBy + "'";
                }
                else sSql = "SELECT * FROM t_Product ";
            }
            else sSql = "SELECT * FROM t_Product ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product Product = new Product();
                    Product.ProductID = (int)reader["ProductID"];
                    Product.ProductCode = (string)reader["ProductCode"];
                    Product.ProductName = (string)reader["ProductName"];
                    Product.ProductDesc = (string)reader["ProductDesc"];
                    InnerList.Add(Product);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetProductModel()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Product oProduct;
            string sSql = "select DISTINCT ProductModel from dbo.v_ProductDetails where IsActive = '1'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProduct = new Product();
                    oProduct.ProductModel = reader["ProductModel"].ToString();
                    InnerList.Add(oProduct);
                }
                reader.Close();

                oProduct = new Product();
                oProduct.ProductModel = "ALL";
                InnerList.Add(oProduct);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetProductName()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Product oProduct;
            string sSql = "select DISTINCT ProductID,ProductName from dbo.v_ProductDetails where IsActive = '1'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProduct = new Product();
                    oProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oProduct.ProductName = reader["ProductName"].ToString();
                   
                    InnerList.Add(oProduct);
                }
                reader.Close();     
          
                oProduct = new Product();
                oProduct.ProductID = -1;
                oProduct.ProductName = "ALL";
                InnerList.Add(oProduct);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public string GetProductNameByID(int productID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Product oProduct;
            string sSql = "select DISTINCT ProductName from dbo.v_ProductDetails where IsActive = '1' and productID = "+productID;

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProduct = new Product();
                    oProduct.ProductName = reader["ProductName"].ToString();
                    return oProduct.ProductName;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return "";
        }

        public void GetCACProduct()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Product oProduct;
            string sSql = "select ProductID,ProductName from dbo.t_CACProduct";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oProduct = new Product();
                    oProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oProduct.ProductName = reader["ProductName"].ToString();

                    InnerList.Add(oProduct);
                }
                reader.Close();
                oProduct = new Product();
                oProduct.ProductID = -1;
                oProduct.ProductName = "ALL";
                InnerList.Add(oProduct);
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


    }

  

}
