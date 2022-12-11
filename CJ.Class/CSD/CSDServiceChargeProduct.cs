// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Dec 01, 2016
// Time : 02:24 PM
// Description: Class for CSDServiceChargeProduct.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class CSDServiceChargeProduct
    {
        private int _nProductID;
        private int _nServiceChargeID;
        private string _sProductCode;
        private string _sProductName;
        private string _sServiceChargeName;
        private double _dServiceCharge;
        private double _dInspectionChatrge;
        private double _dInstallationCharge;
        private double _dReInstallationCharge;
        private double _dDismantlingCharge;
        private Product _oProduct;
        private CSDServiceCharge _oCSDServiceCharge;


        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                    _oProduct.ProductID = _nProductID;
                    _oProduct.Refresh();
                }

                return _oProduct;
            }
        }

        public CSDServiceCharge CSDServiceCharge
        {
            get
            {
                if (_oCSDServiceCharge == null)
                {
                    _oCSDServiceCharge = new CSDServiceCharge();
                    _oCSDServiceCharge.ServiceChargeID = _nServiceChargeID;
                    _oCSDServiceCharge.Refresh();
                }

                return _oCSDServiceCharge;
            }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for ServiceChargeID
        // </summary>
        public int ServiceChargeID
        {
            get { return _nServiceChargeID; }
            set { _nServiceChargeID = value; }
        }

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
        public string ServiceChargeName
        {
            get { return _sServiceChargeName; }
            set { _sServiceChargeName = value; }
        }
        public double ServiceCharge
        {
            get { return _dServiceCharge; }
            set { _dServiceCharge = value; }
        }
        public double InspectionChatrge
        {
            get { return _dInspectionChatrge; }
            set { _dInspectionChatrge = value; }
        }
        public double InstallationCharge
        {
            get { return _dInstallationCharge; }
            set { _dInstallationCharge = value; }
        }
        public double ReInstallationCharge
        {
            get { return _dReInstallationCharge; }
            set { _dReInstallationCharge = value; }
        }
        public double DismantlingCharge
        {
            get { return _dDismantlingCharge; }
            set { _dDismantlingCharge = value; }
        }
        public void Add()
        {
            //int nMaxProductID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX([ProductID]) FROM t_CSDServiceChargeProduct";
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxProductID = 1;
                //}
                //else
                //{
                //    nMaxProductID = Convert.ToInt32(maxID) + 1;
                //}
                //_nProductID = nMaxProductID;

                sSql = "INSERT INTO t_CSDServiceChargeProduct(ProductID, ServiceChargeID) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);

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
                sSql = "UPDATE t_CSDServiceChargeProduct SET ServiceChargeID = ? WHERE ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);

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
                sSql = "DELETE FROM t_CSDServiceChargeProduct WHERE [ProductID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDServiceChargeProduct where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _nServiceChargeID = (int)reader["ServiceChargeID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetServiceChargeID(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDServiceChargeProduct where ProductID =" + nProductID + "";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nServiceChargeID = (int)reader["ServiceChargeID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _nServiceChargeID;
        }
    }
    public class CSDServiceChargeProducts : CollectionBase
    {
        public CSDServiceChargeProduct this[int i]
        {
            get { return (CSDServiceChargeProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDServiceChargeProduct oCSDServiceChargeProduct)
        {
            InnerList.Add(oCSDServiceChargeProduct);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDServiceChargeProduct";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDServiceChargeProduct oCSDServiceChargeProduct = new CSDServiceChargeProduct();
                    oCSDServiceChargeProduct.ProductID = (int)reader["ProductID"];
                    oCSDServiceChargeProduct.ServiceChargeID = (int)reader["ServiceChargeID"];
                    InnerList.Add(oCSDServiceChargeProduct);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByServiceCharge(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ProductCode,ProductName,a.ServiceChargeID, " +
                            "sum(CASE when ChargeType=1 then Amount else 0 end) AS ServiceCharge, " +
                            "sum(CASE when ChargeType=2 then Amount else 0 end) AS InspectionChatrge, " +
                            "sum(CASE when ChargeType=3 then Amount else 0 end) AS InstallationCharge," +
                            "sum(CASE when ChargeType=4 then Amount else 0 end) AS ReInstallationCharge," +
                            "sum(CASE when ChargeType=5 then Amount else 0 end) AS DismantlingCharge " +
                            "from t_csdservicechargeproduct a " +
                            "INNER JOIN t_Product b On a.ProductID = b.ProductID " +
                            "INNER JOIN t_csdservicechargecustomer c ON a.ServiceCHargeID = c.ServiceCHargeID " +
                            "WHere 1=1 ";
            if (nProductID > 0)
            {
                sSql += " AND b.ProductID = " + nProductID + " ";
            }

            sSql += "group by productcode,productname,a.ServiceChargeID";
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDServiceChargeProduct oCSDServiceChargeProduct = new CSDServiceChargeProduct();
                    //oCSDServiceChargeProduct.ProductID = (int)reader["ProductID"];    
                    oCSDServiceChargeProduct.ServiceChargeID = Convert.ToInt32(reader["ServiceChargeID"]);
                    oCSDServiceChargeProduct.ProductCode = (string)reader["ProductCode"];
                    oCSDServiceChargeProduct.ProductName = (string)reader["ProductName"];
                    oCSDServiceChargeProduct.ServiceCharge = (double)reader["ServiceCharge"];
                    oCSDServiceChargeProduct.InspectionChatrge = (double)reader["InspectionChatrge"];
                    oCSDServiceChargeProduct.InspectionChatrge = (double)reader["InspectionChatrge"];
                    oCSDServiceChargeProduct.ReInstallationCharge = (double)reader["ReInstallationCharge"];
                    oCSDServiceChargeProduct.DismantlingCharge = (double)reader["DismantlingCharge"];
                    InnerList.Add(oCSDServiceChargeProduct);
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

