
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 19, 2012
// Time :  40:00 PM
// Description: Class for Spare Parts (Revised).
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class
{
    public class SparePartsR
    {        
        private int _nSparePartID;
        private string _sCode;
        private string _sName;
        private string _sModelNo;
        private double _sCostPrice;
        private double _sSalePrice;
        private int _nIsActive;
        private int _nReorderLevel;
        private int _nLocationID;
        private int _nSPGroupID;
        private int _nASGID;
        private int _nAGID;
        private int _nBrandID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private DateTime _dTranDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _nIsWarrantyValid;
        private int _nFromStoreId;
        private int _nToStoreId;


        private int _nSPtranID;
        private int _nSPTranSide;
        private string _nQty;
        private int _nSpQty;
        private string _sTotalPrice;
        private string _sUnitPrice;
        private string _nSl;
        private string _sUserName;
        private string _sRemarks;
        private string _sTranno;
        private string _sJobNo;
        private string _sCashMemoNo;

        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        private string _sCustomerAddress;
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }




        private string _sSupplierPartCode;
        public string SupplierPartCode
        {
            get { return _sSupplierPartCode; }
            set { _sSupplierPartCode = value; }
        }

        public int ConsumeQty { get; set; }

        public int SPTranSide
        {
            get { return _nSPtranID; }
            set { _nSPtranID = value; }
        }
        public int SpQty
        {
            get { return _nSpQty; }
            set { _nSpQty = value; }
        }
        public string IsWarantyValid
        {
            get { return _nIsWarrantyValid; }
            set { _nIsWarrantyValid = value; }
        }
        public string Tranno
        {
            get { return _sTranno; }
            set { _sTranno = value; }
        }
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        public string CashMemoNo
        {
            get { return _sCashMemoNo; }
            set { _sCashMemoNo = value; }
        }

        public int SPtranID
        {
            get { return _nSPtranID; }
            set { _nSPtranID = value; }
        }
        public string UnitPrice
        {
            get { return _sUnitPrice; }
            set { _sUnitPrice = value; }
        }

        private double _sOtherCharge;
        public double OtherCharge
        {
            get { return _sOtherCharge; }
            set { _sOtherCharge = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }

        private double _sDiscountAmt;
        public double DiscountAmt
        {
            get { return _sDiscountAmt; }
            set { _sDiscountAmt = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        

        public string Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public string TotalPrice
        {
            get { return _sTotalPrice; }
            set { _sTotalPrice = value; }
        }
       
        public string Sl
        {
            get { return _nSl; }
            set { _nSl = value; }
        }

    
        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        private int _CurrentStock;
        public int CurrentStock
        {
            get { return _CurrentStock;}
            set { _CurrentStock = value; }
        }

        private User _oUser;

        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ModelNo
        /// </summary>
        public string ModelNo
        {
            get { return _sModelNo; }
            set { _sModelNo = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public double CostPrice
        {
            get { return _sCostPrice; }
            set { _sCostPrice = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SalePrice
        /// </summary>
        public double SalePrice
        {
            get { return _sSalePrice; }
            set { _sSalePrice = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ReorderLevel
        /// </summary>
        public int ReorderLevel
        {
            get { return _nReorderLevel; }
            set { _nReorderLevel = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for LocationID
        /// </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SPGroupID
        /// </summary>
        public int SPGroupID
        {
            get { return _nSPGroupID; }
            set { _nSPGroupID = value; }
        }
        /// <summary>
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        /// <summary>
        /// Get set property for AGID
        /// </summary>
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        private int _nHSCodeID;
        public int HSCodeID
        {
            get { return _nHSCodeID; }
            set { _nHSCodeID = value; }
        }
        /// <summary>
        /// Get set property for BrandID
        /// </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for _dCreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }


        /// <summary>
        /// Get set property for FromStoreId
        /// </summary>
        public int FromStoreId
        {
            get { return _nFromStoreId; }
            set { _nFromStoreId = value; }
        }

        /// <summary>
        /// Get set property for FromStoreId
        /// </summary>
        public int ToStoreId
        {
            get { return _nToStoreId; }
            set { _nToStoreId = value; }
        }

        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private string _sSubCatName;
        public string SubCatName
        {
            get { return _sSubCatName; }
            set { _sSubCatName = value; }
        }
        private string _sMainCatName;
        public string MainCatName
        {
            get { return _sMainCatName; }
            set { _sMainCatName = value; }
        }

        private string _sBrandName;
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        private string _sLocationName;
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value; }
        }

        private ProductDetail _oProductDetailASG;
        public ProductDetail ProductDetailASG
        {
            get
            {
                if (_oProductDetailASG == null)
                {
                    _oProductDetailASG = new ProductDetail();
                    _oProductDetailASG.ASGID = _nASGID;
                    _oProductDetailASG.RefreshByASGID();
                }

                return _oProductDetailASG;
            }
        }
        private ProductDetail _oProductDetailBrand;
        public ProductDetail ProductDetailBrand
        {
            get
            {
                if (_oProductDetailBrand == null)
                {
                    _oProductDetailBrand = new ProductDetail();
                    _oProductDetailBrand.BrandID =_nBrandID;
                    _oProductDetailBrand.RefreshByBrandID();
                }

                return _oProductDetailBrand;
            }
        }
        //private SPSubCat _oSPSubCat;
        //public SPSubCat SPSubCat
        //{
        //    get
        //    {
        //        if (_oSPSubCat == null)
        //        {
        //            _oSPSubCat = new SPSubCat();
        //            _oSPSubCat.SPSubCatID =_nSPSubCatID;
        //            _oSPSubCat.RefreshBySPSubCatID();
        //        }
        //        return _oSPSubCat;
        //    }
        //}
        private SparePartLocation _oSparePartLocation;
        public SparePartLocation SparePartLocation
        {
            get
            {
                if (_oSparePartLocation == null)
                {
                    _oSparePartLocation = new SparePartLocation();
                    _oSparePartLocation.SPLocationID =_nLocationID;
                    _oSparePartLocation.RefreshBySPLocationID();
                }
                return _oSparePartLocation;
            }
        }
    
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId =_nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public void Add()
        {
            int nMaxSparePartID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SparePartID]) FROM t_CSDSpareParts";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSparePartID = 1;
                }
                else
                {
                    nMaxSparePartID = Convert.ToInt32(maxID) + 1;
                }
                _nSparePartID = nMaxSparePartID;


                sSql = "INSERT INTO t_CSDSpareParts(SparePartID,Code,SupplierPartCode,Name,ModelNo,CostPrice,SalePrice,IsActive,"
                    + " ReorderLevel,LocationID,SPGroupID,AGID,BrandID, CreateUserID,CreateDate,HSCodeID "
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("SupplierPartCode", _sSupplierPartCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ModelNo", _sModelNo);
                cmd.Parameters.AddWithValue("CostPrice", _sCostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _sSalePrice);
                cmd.Parameters.AddWithValue("IsActive",_nIsActive);
                cmd.Parameters.AddWithValue("ReorderLevel", _nReorderLevel);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("SPGroupID", _nSPGroupID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("HSCodeID", _nHSCodeID);
                
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

                cmd.CommandText = "UPDATE t_CSDSpareParts SET SupplierPartCode=?, Name=?,ModelNo=?,CostPrice=?,SalePrice=?,ReorderLevel=?,"
                    + " LocationID=?,SPGroupID=?,AGID=?,BrandID=?,IsActive=?,UpdateUserID=?,UpdateDate=?,HSCodeID=? Where SparePartID=?";

                cmd.CommandType = CommandType.Text;


                //cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("SupplierPartCode", _sSupplierPartCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ModelNo", _sModelNo);
                cmd.Parameters.AddWithValue("CostPrice", _sCostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _sSalePrice);
                cmd.Parameters.AddWithValue("ReorderLevel", _nReorderLevel);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("SPGroupID", _nSPGroupID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("HSCodeID", _nHSCodeID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckSpareByCode(int nStoreID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSpareParts SP INNER JOIN t_CSDSparePartStock SPS "
                         + " ON SP.SparePartID = SPS.SparePartID where SP.Code=? AND SPS.StoreID = " + nStoreID + " ";
            cmd.Parameters.AddWithValue("Code", _sCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nSparePartID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        _sSupplierPartCode = (string)reader["SupplierPartCode"];
                    _sName = (string)reader["Name"];
                    _CurrentStock = (int)reader["CurrentStockQty"];
                    _sCostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    _sCostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;
        }
        public void CheckSpareByCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSpareParts where Code=? AND IsActive = "+(int)Dictionary.YesOrNoStatus.YES+" ";
            cmd.Parameters.AddWithValue("Code", _sCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nSparePartID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        _sSupplierPartCode = (string)reader["SupplierPartCode"];
                    _sName = (string)reader["Name"];
                    //_CurrentStock = (int)reader["CurrentStockQty"];
                    _sCostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;
        }
        public void RefreshBySPID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_CSDSpareParts where SparePartID=?";

                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nSparePartID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        _sSupplierPartCode = (string)reader["SupplierPartCode"];
                    _sName = (string)reader["Name"];
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;
        }
        public void RefreshSpareParts()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Select * from t_CSDSpareParts where SparePartID=?";

                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSparePartID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        _sSupplierPartCode = (string)reader["SupplierPartCode"];
                    _sName = (string)reader["Name"];
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool RefreshBySparePartCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_CSDSpareParts where Code=?";

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSparePartID = (int)reader["SparePartID"];
                    _sCode = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        _sSupplierPartCode = (string)reader["SupplierPartCode"];
                    _sName = (string)reader["Name"];
                    _sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else
                return false;
        }

    }
    public class SparePartsRs : CollectionBase
    {

        public SparePartsR this[int i]
        {
            get { return (SparePartsR)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SparePartsR oSparePartsR)
        {
            InnerList.Add(oSparePartsR);
        }

        public void GetGRDItem(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"select a.SparePartID,c.SupplierPartCode,c.Name,c.Code,a.Qty GRDQty,b.CurrentStockQty 
                            from t_CSDSPTranItem a
                            INNER JOIN t_CSDSparePartStock b ON a.SparePartID = b.SparePartID
                            INNER JOIN t_CSDSpareParts c On c.SparePartID =a.SparePartID
                            INNER JOIN dbo.t_CSDSPTran d On d.SPTranID = a.SPTranID
                            Where a.SpTranID = ? and StoreID not in (4,5)";
                     

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("a.SpTranID", nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR();
                    oSparePartsR.SparePartID = int.Parse(reader["SparePartID"].ToString());
                    oSparePartsR.Code = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        oSparePartsR.SupplierPartCode = (string)reader["SupplierPartCode"];
                    oSparePartsR.Name = (string)reader["Name"];
                    oSparePartsR.Qty = Convert.ToString(reader["GRDQty"]);
                    oSparePartsR.CurrentStock = int.Parse(reader["CurrentStockQty"].ToString());                    
                    InnerList.Add(oSparePartsR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetIssueParts(DateTime dFromDate, DateTime dToDate)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select Tranno,TranDate,JobNo,UserName,a.Remarks,CashMemoNo
                          From t_CSDSPTran a
                          INNER JOIN dbo.t_CSDJob b On b.JobId = a.JobId
                          INNER JOIN dbo.t_CSDSPTranItem c On c.SpTranID = a.SpTranID
                          INNER JOIN dbo.t_CSDSpareparts d On c.SparePartID = d.SparePartID
                          INNER JOIN dbo.t_User e On e.Userid = a.Createuserid Where TranTypeId in(2,3) and TranDate Between '" + dFromDate + "' AND '" + dToDate + "' AND TranDate < '" + dToDate + "' ";
            
            try
            {
                cmd.CommandText = sSql;
                //cmd.Parameters.AddWithValue("a.SpTranID", nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR();
                    oSparePartsR.Tranno = (string)reader["Tranno"];
                    oSparePartsR.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oSparePartsR.JobNo = (string)reader["JobNo"];
                    oSparePartsR.UserName = (string)reader["UserName"];
                    oSparePartsR.Remarks = (string)reader["Remarks"];
                    oSparePartsR.CashMemoNo = (string)reader["CashMemoNo"];
                    InnerList.Add(oSparePartsR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetCashSale(DateTime dFromDate, DateTime dToDate)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select a.SPTranID,Tranno,TranDate,UserName,a.Remarks,CashMemoNo,
                          FromStoreID,ToStoreID,CustomerName,CustomerAddress
                          From t_CSDSPTran a
                          INNER JOIN dbo.t_User e On e.Userid = a.Createuserid Where TranTypeId=4 
                          and TranDate Between '" + dFromDate + "' AND '" + dToDate + "' AND TranDate < '" + dToDate + "' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR
                    {
                        SPtranID = (int) reader["SPtranID"],
                        Tranno = (string) reader["Tranno"],
                        TranDate = Convert.ToDateTime(reader["TranDate"].ToString()),
                        UserName = (string) reader["UserName"],
                        Remarks = (string) reader["Remarks"],
                        CashMemoNo = (string) reader["CashMemoNo"],
                        CustomerName = (string) reader["CustomerName"],
                        CustomerAddress = (string) reader["CustomerAddress"],
                        FromStoreId = (int) reader["FromStoreID"],
                        ToStoreId = (int)reader["ToStoreID"]
                    };
                    InnerList.Add(oSparePartsR);
                }
                reader?.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void PrintByCashSale(int nSPTranID)
        {
            //dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select a.SPTranID,Tranno,TranDate,Code,SupplierPartCode,Name,Qty,(Qty*b.Saleprice)as SalePrice,OtherCharge,DiscountAmt,UserName,a.Remarks,CashMemoNo,LocationName
                          From t_CSDSPTran a
                          INNER JOIN dbo.t_CSDSPTranItem b On b.SpTranID = a.SpTranID
                          INNER JOIN dbo.t_CSDSpareparts c On c.SparePartID = b.SparePartID
                          LEFT OUTER JOIN dbo.t_CSDSPLocation f On f.SPLocationID = c.LocationID
                          INNER JOIN dbo.t_User e On e.Userid = a.Createuserid Where a.SPTranID=" + nSPTranID + "";

            try
            {
                cmd.CommandText = sSql;
                //cmd.Parameters.AddWithValue("a.SpTranID", nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR();
                    oSparePartsR.SPtranID = (int)reader["SPtranID"];
                    oSparePartsR.Tranno = (string)reader["Tranno"];
                    oSparePartsR.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oSparePartsR.Code = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        oSparePartsR.SupplierPartCode = (string)reader["SupplierPartCode"];
                    oSparePartsR.Name = (string)reader["Name"];
                    oSparePartsR.SpQty = (int)reader["Qty"];
                    //oSparePartsR.Qty = Convert.ToString(reader["Qty"]);
                    oSparePartsR.SalePrice = (Double)reader["SalePrice"];
                    oSparePartsR.OtherCharge = (Double)reader["OtherCharge"];
                    oSparePartsR.DiscountAmt = (Double)reader["DiscountAmt"];
                    oSparePartsR.UserName = (string)reader["UserName"];
                    oSparePartsR.Remarks = (string)reader["Remarks"];
                    oSparePartsR.CashMemoNo = (string)reader["CashMemoNo"];
                    oSparePartsR.LocationName = (string)reader["LocationName"];
                    InnerList.Add(oSparePartsR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Refresh(String txtPartCode, String txtPartName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
                       
            string sSql = @"select a.*,Main.Name AS MainCatName,B.BrandDesc,U.UserName ,l.LocationName from t_CSDSpareParts A 
                            INNER JOIN (Select * from t_CSDSPGroup Where GroupCategory=1) Main
                            ON Main.SpGroupID = a.SpGroupID 
                            INNER JOIN t_CSDSPLocation l
                            ON a.LocationID = l.SPLocationID
                            INNER JOIN t_Brand B ON A.BrandID = B.BrandID
                            INNER JOIN t_User U ON U.UserID = a.CreateUserID
                            Where 1=1 ";

            if (txtPartCode != "")
            {
                txtPartCode = "%" + txtPartCode + "%";
                sSql = sSql + " AND A.Code LIKE '" + txtPartCode + "'";
            }
            if (txtPartName != "")
            {
                txtPartName = "%" + txtPartName + "%";
                sSql = sSql + " AND A.Name LIKE '" + txtPartName + "'";
            }
         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsR oSparePartsR = new SparePartsR();

                    oSparePartsR.SparePartID = (int)reader["SparePartID"];
                    oSparePartsR.Code = (string)reader["Code"];
                    if(reader["SupplierPartCode"]!=DBNull.Value)
                    oSparePartsR.SupplierPartCode = (string)reader["SupplierPartCode"];
                    oSparePartsR.Name = (string)reader["Name"];
                    oSparePartsR.ReorderLevel = (int)reader["ReorderLevel"];
                    oSparePartsR.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oSparePartsR.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    oSparePartsR.LocationID = (int)reader["LocationID"];
                    oSparePartsR.SparePartLocation.LocationName = (string)reader["LocationName"];
                    //oSparePartsR.SPGroupID = (int)reader["SubCatID"];
                    //oSparePartsR.SubCatName = (string)reader["SubCatName"];
                    oSparePartsR.SPGroupID = (int)reader["SPGroupID"];
                    oSparePartsR.MainCatName = (string)reader["MainCatName"];
                    oSparePartsR.ModelNo = (string)reader["ModelNo"];
                    oSparePartsR.AGID = (int)reader["AGID"];
                    oSparePartsR.BrandID = (int)reader["BrandID"];
                    oSparePartsR.ProductDetailBrand.BrandDesc = (string)reader["BrandDesc"];
                    oSparePartsR.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oSparePartsR.User.Username = (string)reader["UserName"];
                    oSparePartsR.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    
                    oSparePartsR.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oSparePartsR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPartsIssueAgaintsJob(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"SELECT c.SPTranID,c.TranSide,a.JobID,b.Code ProductCode,b.Name ProductName,a.UnitSalePrice,
                            a.Qty,TotalPrice=a.Qty*a.UnitSalePrice,ISNULL(c.FromStoreID,2) FromStoreID,
                            a.SparePartID,ISNULL(c.TranDate,'07-May-2017') TranDate,  
                            IsValidWarranty FROM t_CSDSparePartUse a
                            INNER JOIN t_CSDSpareParts b ON a.SparePartID = b.SparePartID
                            LEFT JOIN (Select JobID, TranDate, SPTranID, TranSide, FromStoreID from 
                            (Select max(SPTranID)MaxTranID from t_CSDSPTran 
                            Where JobID = ? and TranTypeID = ?)a, t_CSDSPTran b Where a.MaxTranID = b.SPTranID) c 
                            ON c.JobID = a.JobID Where a.JobID = ?";

            cmd.Parameters.AddWithValue("JobID", nJobID);
            cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.SparePartTranSide.OUT);
            cmd.Parameters.AddWithValue("JobID", nJobID);

            
            try 
            {
                
                int i = 1;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsR oSparePartsR = new SparePartsR();
                    oSparePartsR.Sl = i.ToString();

                    if (reader["IsValidWarranty"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(reader["IsValidWarranty"]) == (int)Dictionary.CSDIsWarantyValid.No)
                        {
                            oSparePartsR.IsWarantyValid = "No";
                        }
                        else
                        {
                            oSparePartsR.IsWarantyValid = "Yes";
                        }
                    }
                    else
                    {
                        oSparePartsR.IsWarantyValid = "No";
                    }
                    
                    oSparePartsR.SparePartID = (int)reader["SparePartID"];
                    if (reader["SPTranID"] != DBNull.Value)
                    oSparePartsR.SPtranID = (int)reader["SPTranID"];
                    if (reader["TranSide"] != DBNull.Value)
                    oSparePartsR.SPTranSide = (int)reader["TranSide"];
                    oSparePartsR.Code = (string)reader["ProductCode"];
                    oSparePartsR.Name = (string)reader["ProductName"];
                    oSparePartsR.Qty = Convert.ToString(reader["Qty"]);
                    oSparePartsR.UnitPrice = Convert.ToString(reader["UnitSalePrice"]);
                    oSparePartsR.TotalPrice = Convert.ToString(reader["TotalPrice"]);
                    InnerList.Add(oSparePartsR);
                    i++;
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForSearch(String txtCode, String txtName, String txtModel, String txtBrand, String txtLocationCode, int nStoreID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select SP.SparePartID, Code,SupplierPartCode, Name, ModelNo, SPL.LocationName Location,B.BrandDesc Brand, " +
                            "SP.CostPrice, SP.SalePrice, IsNull(CurrentStockQty,0)as CurrentStock  from t_CSDSpareParts SP "+
                            "INNER JOIN t_CSDSPLocation SPL ON SPL.SPLocationID=SP.LocationID INNER JOIN t_Brand B "+
                            "ON B.BrandID=SP.BrandID Left Outer JOIN (Select * from t_CSDSparePartStock Where StoreID=" + nStoreID + ")SPS " +
                            "ON SPS.SparePartID=SP.SparePartID Where B.BrandLevel=1 AND SP.IsActive=1";

            if (txtCode != "")
            {
                txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND Code LIKE '" + txtCode + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND Name LIKE '" + txtName + "'";
            }
            if (txtModel != "")
            {
                txtModel = "%" + txtModel + "%";
                sSql = sSql + " AND ModelNo LIKE '" + txtModel + "'";
            }
            if (txtBrand != "")
            {
                txtBrand = "%" + txtBrand + "%";
                sSql = sSql + " AND B.BrandDesc LIKE '" + txtBrand + "'";
            }
            if (txtLocationCode != "")
            {
                //txtLocationCode = "%" + txtLocationCode + "%";
                sSql = sSql + " AND SPL.LocationName LIKE '" + txtLocationCode + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR();
                    
                    oSparePartsR.SparePartID = (int)reader["SparePartID"];
                    oSparePartsR.Code = (string)reader["Code"];
                    if (reader["SupplierPartCode"] != DBNull.Value)
                        oSparePartsR.SupplierPartCode = (string)reader["SupplierPartCode"];
                    oSparePartsR.Name = (string)reader["Name"];
                    oSparePartsR.ModelNo = (string)reader["ModelNo"];
                    oSparePartsR.BrandName = (string)reader["Brand"];
                    oSparePartsR.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oSparePartsR.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    oSparePartsR.LocationName = (string)reader["Location"];
                    oSparePartsR.CurrentStock = (int)reader["CurrentStock"];
                    oSparePartsR.SalePrice = (double)reader["SalePrice"];

                    InnerList.Add(oSparePartsR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSpForOrder(string spCode,string spName, int brandId,int pgId, int magId, DateTime from,DateTime to)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            to = to.AddDays(1);
            string sSql;
           

            string tranDate = @" AND TranDate Between '{0}' and '{1}'
                        and TranDate < '{2}' ";
            tranDate = string.Format(tranDate, from, to, to);
            

            //sSql = @"Select a.SparePartID,c.Code,c.Name,c.ReorderLevel,c.CostPrice,
            //        c.SalePrice,CASE WHEN (a.StockOut-ISNULL(b.ReturnQty,0))<0 THEN 0 ELSE(a.StockOut-ISNULL(b.ReturnQty,0)) END
            //        AS ConsumeQty,d.CurrentStockQty  from
            //        (Select SparePartID,SUM(b.Qty) AS StockOut from t_CSDSPTran a,t_CSDSPTranItem b
            //        WHere a.SPTranID =b.SPTranID and TranSide = 2 {0}
            //        Group BY b.SparePartID) a
            //        LEFT OUTER JOIN 
            //        (select b.SparePartID,SUM(b.Qty) AS ReturnQty from t_CSDSPTran a,t_CSDSPTranItem b
            //        WHere a.SPTranID =b.SPTranID and TranSide = 1 and TranTypeID in(3,6,13) {1}
            //        Group BY b.SparePartID) as b
            //        ON a.SparePartID = b.SparePartID
            //        INNER JOIN t_CSDSpareParts c
            //        ON b.SparePartID = c.SparePartID
            //        INNER Join t_CSDSparePartStock d
            //        ON d.SparePartID = a.SparePartID
            //        WHERE d.StoreID=2   ";

            sSql = @"SELECT a.SparePartID,a.Code,a.Name,a.ReorderLevel,a.CostPrice,
                    a.SalePrice,ISNULL(ConsumeQty,0) ConsumeQty, c.CurrentStockQty,a.AGID FROM t_CSDSpareParts a
                    LEFT OUTER JOIN(
                    ----SP Stock Out----StockOut,ISNULL(ReturnQty,0) AS ReturnQty,
                    Select a.SparePartID,
                    CASE WHEN (StockOut-ISNULL(ReturnQty,0))<0 THEN 0 ELSE (StockOut-ISNULL(ReturnQty,0)) END AS ConsumeQty
                    FROM(
                    Select SparePartID,SUM(b.Qty) AS StockOut from t_CSDSPTran a,t_CSDSPTranItem b
                    WHere a.SPTranID =b.SPTranID and TranSide = 2 {0}
                    Group BY b.SparePartID)a
                    LEFT OUTER JOIN
                    ----SP Stock Return----
                    (select b.SparePartID,SUM(b.Qty) AS ReturnQty from t_CSDSPTran a,t_CSDSPTranItem b
                    WHere a.SPTranID = b.SPTranID and TranSide = 1 {1}
                    and TranTypeID in(3,6,13)
                    Group BY b.SparePartID)b
                    ON a.SparePartID = b.SparePartID) b
                    ON a.SparePartID = b.SparePartID
                    INNER JOIN t_CSDSparePartStock c 
                    ON c.SparePartID = a.SparePartID
                    WHERE 1 = 1 ";

            sSql = string.Format(sSql, tranDate, tranDate);

            if (!string.IsNullOrEmpty(spCode))
            {
                sSql += " AND Code Like '%"+ spCode + "%' ";
            }
            if (!string.IsNullOrEmpty(spName))
            {
                sSql += " AND Name Like '%" + spName + "%' ";
            }
            if (brandId > 0)
            {
                sSql += " AND BrandID = "+brandId+" ";
            }

            if (pgId > 0)
            {
                sSql += @" AND AGID IN(
                           Select DISTINCT AGID from v_ProductDetails Where PGID = {0} ) ";
                sSql = string.Format(sSql, pgId);
            }

            if (magId > 0)
            {
                sSql += @" AND AGID IN(
                        Select DISTINCT AGID from v_ProductDetails Where MAGID = {0} ) ";
                sSql = string.Format(sSql, magId);
            }

            sSql += " AND a.IsActive = 1  Order By Name ASC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR
                    {
                        SparePartID = (int) reader["SparePartID"],
                        Code = (string) reader["Code"],

                        //SupplierPartCode = (string)reader["SupplierPartCode"],
                        Name = (string) reader["Name"],
                        CostPrice = Convert.ToDouble(reader["CostPrice"].ToString()),
                        SalePrice = Convert.ToDouble(reader["SalePrice"].ToString()),
                        CurrentStock = (int) reader["CurrentStockQty"],
                        ReorderLevel = (int) reader["ReorderLevel"],
                        ConsumeQty = (int)reader["ConsumeQty"]
                    };

                    //oSparePartsR.ModelNo = (string)reader["ModelNo"];
                    //oSparePartsR.BrandName = (string)reader["Brand"];
                    //oSparePartsR.LocationName = (string)reader["Location"];
                    InnerList.Add(oSparePartsR);
                }
                reader?.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
}

