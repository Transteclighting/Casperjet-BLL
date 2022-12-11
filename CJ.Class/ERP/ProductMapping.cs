// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 06, 2012
// Time :  30:00 PM
// Description: Class for ERP Product Mapping.
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
    public class ProductMapping
    {

        private string _sProductERPCode;
        private string _sProductCode;
        private int _nProductCategory;
       
        /// <summary>
        /// Get set property for ProductERPCode
        /// </summary>
        public string ProductERPCode
        {
            get { return _sProductERPCode; }
            set { _sProductERPCode = value; }
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
        /// Get set property for ProductCategory
        /// </summary>
        public int ProductCategory
        {
            get { return _nProductCategory; }
            set { _nProductCategory = value; }
        }
        private string _sProductName;
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public void Add()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_MapERPProduct(ProductERPCode,ProductCode,ProductCategory) VALUES(?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductERPCode", _sProductERPCode);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductCategory", _nProductCategory);

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
                ProductMapping _oProductMapping;

                cmd.CommandText = "UPDATE t_MapERPProduct SET ProductCode=?,ProductCategory=?, ProductERPCode=? Where ProductERPCode=? "; 

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductCategory", _nProductCategory);
                cmd.Parameters.AddWithValue("ProductERPCode", _sProductERPCode);

                cmd.Parameters.AddWithValue("ProductERPCode", _sProductERPCode);

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
                sSql = "DELETE FROM t_MapERPProduct WHERE [ProductERPCode]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductERPCode", _sProductERPCode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public bool CheckProductERPCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_MapERPProduct where ProductERPCode=? ";
            cmd.Parameters.AddWithValue("ProductERPCode", _sProductERPCode);

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
                return true;
            else return false;
        }
        public bool CheckProductCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_MapERPProduct where ProductCode=? ";
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
            if (nCount == 0)
                return true;
            else return false;
        }
    }
    public class ProductMappings : CollectionBase
    {
        public ProductMapping this[int i]
        {
            get { return (ProductMapping)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductMapping oProductMapping)
        {
            InnerList.Add(oProductMapping);
        }
        public void Refresh(string txtERPCode, String txtProductCode, String txtProductName)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select M.*,PD.ProductName from t_MapERPProduct M "+
                            "INNER JOIN v_ProductDetails PD "+
                            "ON PD.ProductCode= M.ProductCode "+
                            "Where ProductERPCode <>'xyz'";

            if (txtERPCode != "")
            {
                txtERPCode = "%" + txtERPCode + "%";
                sSql = sSql + " AND ProductERPCode LIKE '" + txtERPCode + "'";
            }
            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND PD.ProductCode LIKE '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND PD.ProductName LIKE '" + txtProductName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductMapping oProductMapping = new ProductMapping();

                    oProductMapping.ProductERPCode = (string)reader["ProductERPCode"];
                    oProductMapping.ProductCode = (string)reader["ProductCode"];
                    oProductMapping.ProductName = (string)reader["ProductName"];
                    oProductMapping.ProductCategory = (int)reader["ProductCategory"];


                    InnerList.Add(oProductMapping);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshNonMapping(DateTime dtFromDate, String txtProductCodeU, String txtProductNameU)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select PD.ProductCode ProductCode, ProductName, M.ProductCode from v_ProductDetails PD " +
                            "Left OUter JOIN t_MapERPProduct M " +
                            "ON PD.ProductCode=M.ProductCode " +
                            "Where M.ProductCode Is null AND PD.EntryDate >= '" + dtFromDate + "'";


            if (txtProductCodeU != "")
            {
                txtProductCodeU = "%" + txtProductCodeU + "%";
                sSql = sSql + " AND PD.ProductCode LIKE '" + txtProductCodeU + "'";
            }
            if (txtProductNameU != "")
            {
                txtProductNameU = "%" + txtProductNameU + "%";
                sSql = sSql + " AND PD.ProductName LIKE '" + txtProductNameU + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ProductMapping oProductMapping = new ProductMapping();

                    oProductMapping.ProductCode = (string)reader["ProductCode"];
                    oProductMapping.ProductName = (string)reader["ProductName"];

                    InnerList.Add(oProductMapping);
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



