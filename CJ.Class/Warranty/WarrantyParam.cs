// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 18, 2013
// Time : 06:56 PM
// Description: class for Warranty Parameter Data.
// Modify Person And Date:
// </summary>

// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Feb 12, 2020
// Time : 02:22 PM
// Description: Class for WarrantyParamDetails.
// Modify Person And Date:
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
    public class WarrantyParamDetails
    {
        private int _nID;
        private int _nSupplierID;
        private int _nWarrantyParamID;
        private double _ServiceWarranty;
        private double _SparePartsWarranty;
        private double _SpecialComponentWarranty;
        private string _SupplierName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for SupplierID
        // </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }
        public int WarrantyparamID
        {
            get { return _nWarrantyParamID; }
            set { _nWarrantyParamID = value; }
        }
        // <summary>
        // Get set property for ServiceWarranty
        // </summary>
        public double ServiceWarranty
        {
            get { return _ServiceWarranty; }
            set { _ServiceWarranty = value; }
        }

        // <summary>
        // Get set property for SparePartsWarranty
        // </summary>
        public double SparePartsWarranty
        {
            get { return _SparePartsWarranty; }
            set { _SparePartsWarranty = value; }
        }

        // <summary>
        // Get set property for SpecialComponentWarranty
        // </summary>
        public double SpecialComponentWarranty
        {
            get { return _SpecialComponentWarranty; }
            set { _SpecialComponentWarranty = value; }
        }
        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }

        public void Add(int _nWarrantyParamID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_WarrantyParamDetails";
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
                sSql = "INSERT INTO t_WarrantyParamDetails (ID, WarrantyParamID,SupplierID, ServiceWarranty, SparePartsWarranty, SpecialComponentWarranty) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarrantyParamID", _nWarrantyParamID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("ServiceWarranty", _ServiceWarranty);
                cmd.Parameters.AddWithValue("SparePartsWarranty", _SparePartsWarranty);
                cmd.Parameters.AddWithValue("SpecialComponentWarranty", _SpecialComponentWarranty);

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
                sSql = "UPDATE t_WarrantyParamDetails SET SupplierID = ?, ServiceWarranty = ?, SparePartsWarranty = ?, SpecialComponentWarranty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("ServiceWarranty", _ServiceWarranty);
                cmd.Parameters.AddWithValue("SparePartsWarranty", _SparePartsWarranty);
                cmd.Parameters.AddWithValue("SpecialComponentWarranty", _SpecialComponentWarranty);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_WarrantyParamDetails WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_WarrantyParamDetails where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nSupplierID = (int)reader["SupplierID"];
                    _ServiceWarranty = Convert.ToDouble(reader["ServiceWarranty"].ToString());
                    _SparePartsWarranty = Convert.ToDouble(reader["SparePartsWarranty"].ToString());
                    _SpecialComponentWarranty = Convert.ToDouble(reader["SpecialComponentWarranty"].ToString());
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
}

public class WarrantyParam : CollectionBase
{
    public WarrantyParamDetails this[int i]
    {
        get { return (WarrantyParamDetails)InnerList[i]; }
        set { InnerList[i] = value; }
    }
    public void Add(WarrantyParamDetails oWarrantyParamDetails)
    {
        InnerList.Add(oWarrantyParamDetails);
    }
    private int _nWarrantyParamID;
        private int _nProductID;
        private int _nServiceWarranty;
        private int _nPartsWarranty;
        private int _nSpecialComponentWarranty;
        private int _nIsCurrent;
        private int _nIsPrintWarrantyCard;
        private int _nIsStoreBarcode;
        private DateTime _dEffectDate;
        private DateTime _dCreateDate;
        private int _nCreateUserID;

        private string _sProductCode;
        private string _sProductName;
        private int _nASGID;
        private string _sASGName;
        private int _nBrandID;
        private string _sBrandName;
        private int _nStatus;
        private int _nProductType;
        private string _sProductTypeName;


        /// <summary>
        /// Get set property for WarrantyParamID
        /// </summary>
        public int WarrantyParamID
        {
            get { return _nWarrantyParamID; }
            set { _nWarrantyParamID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private int _nSmartWarrantyTenure;
        public int SmartWarrantyTenure
        {
            get { return _nSmartWarrantyTenure; }
            set { _nSmartWarrantyTenure = value; }
        }
        private double _TotalPrice;
        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
        private int _nSmartWarrantyID;
        public int SmartWarrantyID
        {
            get { return _nSmartWarrantyID; }
            set { _nSmartWarrantyID = value; }
        }
        /// <summary>
        /// Get set property for ServiceWarranty
        /// </summary>
        public int ServiceWarranty
        {
            get { return _nServiceWarranty; }
            set { _nServiceWarranty = value; }
        }
        /// <summary>
        /// Get set property for PartsWarranty
        /// </summary>
        public int PartsWarranty
        {
            get { return _nPartsWarranty; }
            set { _nPartsWarranty = value; }
        }
        /// <summary>
        /// Get set property for SpecialComponentWarranty
        /// </summary>
        public int SpecialComponentWarranty
        {
            get { return _nSpecialComponentWarranty; }
            set { _nSpecialComponentWarranty = value; }
        }
        /// <summary>
        /// Get set property for IsCurrent
        /// </summary>
        public int IsCurrent
        {
            get { return _nIsCurrent; }
            set { _nIsCurrent = value; }
        }
        /// <summary>
        /// Get set property for IsPrintWarrantyCard
        /// </summary>
        public int IsPrintWarrantyCard
        {
            get { return _nIsPrintWarrantyCard; }
            set { _nIsPrintWarrantyCard = value; }
        }
        /// <summary>
        /// Get set property for IsStoreBarcode
        /// </summary>
        public int IsStoreBarcode
        {
            get { return _nIsStoreBarcode; }
            set { _nIsStoreBarcode = value; }
        }
        /// <summary>
        /// Get set property for EffectDate
        /// </summary>
        public DateTime EffectDate
        {
            get { return _dEffectDate; }
            set { _dEffectDate = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        /// <summary>
        /// Get set property for ASGName
        /// </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
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
        /// Get set property for BrandName
        /// </summary>
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
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
        /// Get set property for ProductType
        /// </summary>
        public int ProductType
        {
            get { return _nProductType; }
            set { _nProductType = value; }
        }
        /// <summary>
        /// Get set property for ProductTypeName
        /// </summary>
        public string ProductTypeName
        {
            get { return _sProductTypeName; }
            set { _sProductTypeName = value; }
        }

        public void Add()
        {
            int nMaxWarrantyParamID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([WarrantyParamID]) FROM t_WarrantyParam";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWarrantyParamID = 1;
                }
                else
                {
                    nMaxWarrantyParamID = Convert.ToInt32(maxID) + 1;
                }
                _nWarrantyParamID = nMaxWarrantyParamID;


                sSql = "INSERT INTO t_WarrantyParam(WarrantyParamID,ProductID,ServiceWarranty,PartsWarranty,SpecialComponentWarranty,IsCurrent, " +
                        "IsPrintWarrantyCard,IsStoreBarcode,EffectDate,CreateDate,CreateUserID ) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyParamID", _nWarrantyParamID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ServiceWarranty", _nServiceWarranty);
                cmd.Parameters.AddWithValue("PartsWarranty", _nPartsWarranty);
                cmd.Parameters.AddWithValue("SpecialComponentWarranty", _nSpecialComponentWarranty);
                cmd.Parameters.AddWithValue("IsCurrent", (int)Dictionary.IsCurrent.Yes);
                cmd.Parameters.AddWithValue("IsPrintWarrantyCard", _nIsPrintWarrantyCard);
                cmd.Parameters.AddWithValue("IsStoreBarcode", _nIsStoreBarcode);
                cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            foreach (WarrantyParamDetails oWarrantyParamDetails in this)
            {
                oWarrantyParamDetails.Add(_nWarrantyParamID);
            }
        }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForPOS()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {


                sSql = "Update t_WarrantyParam SET IsCurrent=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsCurrent", (int)Dictionary.IsCurrent.No);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "INSERT INTO t_WarrantyParam(WarrantyParamID,ProductID,ServiceWarranty,PartsWarranty,SpecialComponentWarranty,IsCurrent, " +
                        "IsPrintWarrantyCard,IsStoreBarcode,EffectDate,CreateDate,CreateUserID ) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyParamID", _nWarrantyParamID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ServiceWarranty", _nServiceWarranty);
                cmd.Parameters.AddWithValue("PartsWarranty", _nPartsWarranty);
                cmd.Parameters.AddWithValue("SpecialComponentWarranty", _nSpecialComponentWarranty);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("IsPrintWarrantyCard", _nIsPrintWarrantyCard);
                cmd.Parameters.AddWithValue("IsStoreBarcode", _nIsStoreBarcode);
                cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);


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

                sSql = "Update t_WarrantyParam SET ProductID=?,ServiceWarranty=?,PartsWarranty=?,SpecialComponentWarranty=?,IsCurrent=?, " +
                        "IsPrintWarrantyCard=?,IsStoreBarcode=?,EffectDate=?,CreateDate=?,CreateUserID=? Where WarrantyParamID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ServiceWarranty", _nServiceWarranty);
                cmd.Parameters.AddWithValue("PartsWarranty", _nPartsWarranty);
                cmd.Parameters.AddWithValue("SpecialComponentWarranty", _nSpecialComponentWarranty);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("IsPrintWarrantyCard", _nIsPrintWarrantyCard);
                cmd.Parameters.AddWithValue("IsStoreBarcode", _nIsStoreBarcode);
                cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

                cmd.Parameters.AddWithValue("WarrantyParamID", _nWarrantyParamID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIsCurrent()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_WarrantyParam SET IsCurrent=? WHERE WarrantyParamID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsCurrent", (int)Dictionary.IsCurrent.No);

                cmd.Parameters.AddWithValue("WarrantyParamID", _nWarrantyParamID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool GetWarranty(int nProductID, DateTime dInvoiceDate)
        {
            int nCount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select b.* from (select Max(WarrantyParamID)WarrantyParamID, ProductID from t_WarrantyParam " +
                            " where EffectDate <='" + dInvoiceDate + "' group by ProductID)a, " +
                            " t_WarrantyParam b Where a.WarrantyParamID=b.WarrantyParamID and b.ProductID=? ";

            cmd.Parameters.AddWithValue("ProductID", nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    _nWarrantyParamID = int.Parse(reader["WarrantyParamID"].ToString());
                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    _nServiceWarranty = int.Parse(reader["ServiceWarranty"].ToString());
                    _nPartsWarranty = int.Parse(reader["PartsWarranty"].ToString());
                    _nSpecialComponentWarranty = int.Parse(reader["SpecialComponentWarranty"].ToString());

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
            else return false;
        }
        public bool GetWarrantyParamByID(int nWarrantyParamID)
        {
            int nCount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyParam where WarrantyParamID=? ";

            cmd.Parameters.AddWithValue("WarrantyParamID", nWarrantyParamID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    _nWarrantyParamID = int.Parse(reader["WarrantyParamID"].ToString());
                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    _nServiceWarranty = int.Parse(reader["ServiceWarranty"].ToString());
                    _nPartsWarranty = int.Parse(reader["PartsWarranty"].ToString());
                    _nSpecialComponentWarranty = int.Parse(reader["SpecialComponentWarranty"].ToString());

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
            else return false;
        }
        public bool CheckWarranty(int nWarrantyParamID)
        {
            int nCount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyParam Where WarrantyParamID=? ";

            cmd.Parameters.AddWithValue("WarrantyParamID", nWarrantyParamID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
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
                return true;
            else return false;
        }

    }
    public class WarrantyParams : CollectionBase
    {
        public WarrantyParam this[int i]
        {
            get { return (WarrantyParam)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(WarrantyParam oWarrantyParam)
        {
            InnerList.Add(oWarrantyParam);
        }

        public int GetSmartWarrantyIndexByID(int _SmartWarrantyID)
        {
            int i = 0;
            foreach (WarrantyParam oWarrantyParam in this)
            {
                if (oWarrantyParam.SmartWarrantyID == _SmartWarrantyID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyParam ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    WarrantyParam oWarrantyParam = new WarrantyParam();

                    oWarrantyParam.WarrantyParamID = int.Parse(reader["WarrantyParamID"].ToString());
                    oWarrantyParam.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oWarrantyParam.ServiceWarranty = int.Parse(reader["ServiceWarranty"].ToString());
                    oWarrantyParam.PartsWarranty = int.Parse(reader["PartsWarranty"].ToString());
                    oWarrantyParam.SpecialComponentWarranty = int.Parse(reader["SpecialComponentWarranty"].ToString());
                    oWarrantyParam.IsCurrent = int.Parse(reader["IsCurrent"].ToString());
                    oWarrantyParam.IsPrintWarrantyCard = int.Parse(reader["IsPrintWarrantyCard"].ToString());
                    oWarrantyParam.IsStoreBarcode = int.Parse(reader["IsStoreBarcode"].ToString());
                    oWarrantyParam.EffectDate = Convert.ToDateTime(reader["EffectDate"].ToString());
                    oWarrantyParam.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oWarrantyParam.CreateUserID = int.Parse(reader["CreateUserID"].ToString());


                    InnerList.Add(oWarrantyParam);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nProductType, String txtProductCode, String txtProductName, int nASGID, int nBrandID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from (Select PD.ProductID,ProductCode, ProductName, ASGID,ASGName, BrandID,BrandDesc as BrandName, ProductType, ProductTypeName=CASE When productType=1 Then 'CE' " +
                            "When productType=2 Then 'EB4' When productType=3 Then 'LE_Import' When productType=4 Then 'PL' When productType=5 Then 'RAW_MET' end," +
                            "0 as WarrantyParamID, " +
                            "0 as ServiceWarranty, 0 as PartsWarranty,0 as SpecialComponentWarranty, 0 as IsCurrent,0 as IsPrintWarrantyCard,0 as IsStoreBarcode, " +
                            "GetDate() as EffectDate,GetDate() as CreateDate,0 as CreateUserID, 0 as Status from v_ProductDetails PD Left Outer JOIN t_WarrantyParam WP " +
                            "ON PD.ProductID=WP.ProductID Where WP.ProductID Is Null " +

                            "UNION ALL " +

                            "Select PD.ProductID,ProductCode, ProductName, ASGID,ASGName, BrandID,BrandDesc as BrandName, ProductType, ProductTypeName=CASE When productType=1 Then 'CE' " +
                            "When productType=2 Then 'EB4' When productType=3 Then 'LE_Import' When productType=4 Then 'PL' When productType=5 Then 'RAW_MET' end,WarrantyParamID, " +
                            "ServiceWarranty,PartsWarranty,SpecialComponentWarranty,IsCurrent,IsPrintWarrantyCard,IsStoreBarcode, " +
                            "EffectDate,CreateDate,CreateUserID, 1 as Status from t_WarrantyParam WP INNER JOIN  v_ProductDetails PD " +
                            "ON PD.ProductID=WP.ProductID Where IsCurrent=1) A Where ProductID <>0 ";

            //cmd.Parameters.AddWithValue("ExchangeOfferID", nExchangeOfferID);

            if (nProductType > -1)
            {
                sSql = sSql + "AND ProductType ='" + nProductType + "'";
            }
            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND ProductCode LIKE '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }
            if (nASGID > 0)
            {
                sSql = sSql + "AND ASGID ='" + nASGID + "'";
            }
            if (nBrandID > 0)
            {
                sSql = sSql + "AND BrandID ='" + nBrandID + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    WarrantyParam oWarrantyParam = new WarrantyParam();

                    oWarrantyParam.ProductCode = (string)reader["ProductCode"];
                    oWarrantyParam.ProductName = (string)reader["ProductName"];
                    oWarrantyParam.ASGID = (int)reader["ASGID"];
                    oWarrantyParam.ASGName = (string)reader["ASGName"];
                    oWarrantyParam.BrandID = (int)reader["BrandID"];
                    oWarrantyParam.BrandName = (string)reader["BrandName"];
                    oWarrantyParam.ProductType = (int)reader["ProductType"];
                    oWarrantyParam.ProductTypeName = (string)reader["ProductTypeName"];
                    oWarrantyParam.WarrantyParamID = (int)reader["WarrantyParamID"];
                    oWarrantyParam.ProductID = (int)reader["ProductID"];
                    oWarrantyParam.ServiceWarranty = (int)reader["ServiceWarranty"];
                    oWarrantyParam.PartsWarranty = (int)reader["PartsWarranty"];
                    oWarrantyParam.SpecialComponentWarranty = (int)reader["SpecialComponentWarranty"];
                    oWarrantyParam.IsCurrent = (int)reader["IsCurrent"];
                    oWarrantyParam.IsPrintWarrantyCard = (int)reader["IsPrintWarrantyCard"];
                    oWarrantyParam.IsStoreBarcode = (int)reader["IsStoreBarcode"];
                    oWarrantyParam.EffectDate = Convert.ToDateTime(reader["EffectDate"].ToString());
                    oWarrantyParam.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oWarrantyParam.CreateUserID = (int)reader["CreateUserID"];
                    oWarrantyParam.Status = (int)reader["Status"];

                    InnerList.Add(oWarrantyParam);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_WarrantyParam a inner join t_DataTransfer b on b.DataID=a.WarrantyParamID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and WarehouseID= ? ";

            cmd.Parameters.AddWithValue("TableName", "t_WarrantyParam");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    WarrantyParam oWarrantyParam = new WarrantyParam();

                    oWarrantyParam.WarrantyParamID = int.Parse(reader["WarrantyParamID"].ToString());
                    oWarrantyParam.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oWarrantyParam.ServiceWarranty = int.Parse(reader["ServiceWarranty"].ToString());
                    oWarrantyParam.PartsWarranty = int.Parse(reader["PartsWarranty"].ToString());
                    oWarrantyParam.SpecialComponentWarranty = int.Parse(reader["SpecialComponentWarranty"].ToString());
                    oWarrantyParam.IsCurrent = int.Parse(reader["IsCurrent"].ToString());
                    oWarrantyParam.IsPrintWarrantyCard = int.Parse(reader["IsPrintWarrantyCard"].ToString());
                    oWarrantyParam.IsStoreBarcode = int.Parse(reader["IsStoreBarcode"].ToString());
                    oWarrantyParam.EffectDate = Convert.ToDateTime(reader["EffectDate"].ToString());
                    oWarrantyParam.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oWarrantyParam.CreateUserID = int.Parse(reader["CreateUserID"].ToString());


                    InnerList.Add(oWarrantyParam);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetSmartWarrantyTenure(int nProductID, DateTime _dtSystemDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select SmartWarrantyID,SmartWarrantyTenure,NetPrice+Commission as TotalPrice  From t_ExtendedWarrantyItem where SmartWarrantyID in ( " +
                        "Select max(SmartWarrantyID)From t_ExtendedWarrantyItem where ProductID = " + nProductID + " " +
                        "and EffectiveDate <= '" + _dtSystemDate + "' group by SmartWarrantyTenure)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    WarrantyParam oWarrantyParam = new WarrantyParam();

                    oWarrantyParam.SmartWarrantyID = int.Parse(reader["SmartWarrantyID"].ToString());
                    oWarrantyParam.SmartWarrantyTenure = Convert.ToInt32(reader["SmartWarrantyTenure"].ToString());
                    oWarrantyParam.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());

                    InnerList.Add(oWarrantyParam);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    
    public void RefreshBySupplier()
    {
        InnerList.Clear();
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSql = "Select b.SupplierID,SupplierName from t_suppliermappingwarranty a, t_Supplier b Where b.SupplierID=a.SupplierID";

        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WarrantyParamDetails oWarrantyParamDetails = new WarrantyParamDetails();

                oWarrantyParamDetails.SupplierID = (int)reader["SupplierID"];
                oWarrantyParamDetails.SupplierName = (string)reader["SupplierName"];
                InnerList.Add(oWarrantyParamDetails);
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







