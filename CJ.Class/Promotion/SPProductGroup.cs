
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 12, 2014
// Time :  07:42 PM
// Description: Class for Product Group
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Promotion
{
    public class SPProductGroup
    {

        private int _nSalesPromoDiscountID;
        private int _nSalesPromotionID;
        private int _nProductGroupType;
        private int _nProductGroupID;
        private int _nDiscountType;
        private double _DiscountPercentage;


        /// <summary>
        /// Get set property for SalesPromoDiscountID
        /// </summary>
        public int SalesPromoDiscountID
        {
            get { return _nSalesPromoDiscountID; }
            set { _nSalesPromoDiscountID = value; }
        }

        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        /// <summary>
        /// Get set property for ProductGroupType
        /// </summary>
        public int ProductGroupType
        {
            get { return _nProductGroupType; }
            set { _nProductGroupType = value; }
        }

        /// <summary>
        /// Get set property for ProductGroupID
        /// </summary>
        public int ProductGroupID
        {
            get { return _nProductGroupID; }
            set { _nProductGroupID = value; }
        }

        /// <summary>
        /// Get set property for DiscountType
        /// </summary>
        public int DiscountType
        {
            get { return _nDiscountType; }
            set { _nDiscountType = value; }
        }

        /// <summary>
        /// Get set property for DiscountPercentage
        /// </summary>
        public double DiscountPercentage
        {
            get { return _DiscountPercentage; }
            set { _DiscountPercentage = value; }
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

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxSPDID = 0;
            try
            {
                if (_nSalesPromoDiscountID == 0)
                {
                    sSql = "SELECT MAX([SalesPromoDiscountID]) FROM t_SalesPromoDiscount";
                    cmd.CommandText = sSql;
                    object maxSPDID = cmd.ExecuteScalar();
                    if (maxSPDID == DBNull.Value)
                    {
                        nMaxSPDID = 1;
                    }
                    else
                    {
                        nMaxSPDID = Convert.ToInt32(maxSPDID) + 1;
                    }
                    _nSalesPromoDiscountID = nMaxSPDID;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_SalesPromoDiscount (SalesPromoDiscountID,SalesPromotionID,ProductGroupType, "
                    + " ProductGroupID,DiscountType,DiscountPercentage) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromoDiscountID", _nSalesPromoDiscountID);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("ProductGroupType", _nProductGroupType);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("DiscountType", _nDiscountType);
                cmd.Parameters.AddWithValue("DiscountPercentage", _DiscountPercentage);
              
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
                sSql = "DELETE FROM t_SalesPromoDiscount WHERE SalesPromotionID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        

    }
    public class SPProductGroups : CollectionBase
    {
        public SPProductGroup this[int i]
        {
            get { return (SPProductGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPProductGroup oSPProductGroup)
        {
            InnerList.Add(oSPProductGroup);
        }
        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoDiscount where SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPProductGroup oSPProductGroup = new SPProductGroup();
                    oSPProductGroup.SalesPromoDiscountID = int.Parse(reader["SalesPromoDiscountID"].ToString());
                    oSPProductGroup.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPProductGroup.ProductGroupType = int.Parse(reader["ProductGroupType"].ToString());
                    oSPProductGroup.ProductGroupID = int.Parse(reader["ProductGroupID"].ToString());
                    oSPProductGroup.DiscountType = int.Parse(reader["DiscountType"].ToString());
                    oSPProductGroup.DiscountPercentage = Convert.ToDouble(reader["DiscountPercentage"].ToString());
                    InnerList.Add(oSPProductGroup);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForSKU(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select a.*,ProductCode, ProductName  from t_SalesPromoDiscount a, t_Product b where a.ProductGroupID=b.ProductID and SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPProductGroup oSPProductGroup = new SPProductGroup();
                    oSPProductGroup.SalesPromoDiscountID = int.Parse(reader["SalesPromoDiscountID"].ToString());
                    oSPProductGroup.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPProductGroup.ProductGroupType = int.Parse(reader["ProductGroupType"].ToString());
                    oSPProductGroup.ProductGroupID = int.Parse(reader["ProductGroupID"].ToString());
                    oSPProductGroup.DiscountType = int.Parse(reader["DiscountType"].ToString());
                    oSPProductGroup.DiscountPercentage = Convert.ToDouble(reader["DiscountPercentage"].ToString());
                    oSPProductGroup.ProductCode = (string)reader["ProductCode"];
                    oSPProductGroup.ProductName = (string)reader["ProductName"];
                    InnerList.Add(oSPProductGroup);
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

