// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 28, 2011
// Time :  03:00 PM
// Description: Class for Promotion.
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
    public class SPSlabRatio
    {
        private int _nCPSID;
        private int _nProductID;
        private int _nQty;

        /// <summary>
        /// Get set property for CPSID
        /// </summary>
        public int CPSID
        {
            get { return _nCPSID; }
            set { _nCPSID = value; }
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
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        private double _Discount;
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        private int _nDiscountType;
        public int DiscountType
        {
            get { return _nDiscountType; }
            set { _nDiscountType = value; }
        }
        private int _nSlabNo;
        public int SlabNo
        {
            get { return _nSlabNo; }
            set { _nSlabNo = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoSlabRatio VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);

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
                sSql = "DELETE FROM t_SalesPromoSlabRatio WHERE CPSID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);               

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool RefreshRatioQty(int nSalesPromotionID, int nProductID, int nQty)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select a.CPSID,ProductID,Qty,Discount,DiscountType,SlabNo from t_SalesPromoSlab a, t_SalesPromoSlabRatio b where a.CPSID=b.CPSID " +
                            "and SalesPromotionID=? and ProductID=? Order by SlabNo desc";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (nQty >= int.Parse(reader["Qty"].ToString()))
                    {
                        SPSlabRatio oSPSlabRatio = new SPSlabRatio();

                        _nCPSID = int.Parse(reader["CPSID"].ToString());
                        _nProductID = int.Parse(reader["ProductID"].ToString());
                        _nQty = int.Parse(reader["Qty"].ToString());
                        _nSlabNo = int.Parse(reader["SlabNo"].ToString());
                        nCount++;
                        break;
                    }
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
    public class SPSlabAllRatio : CollectionBase
    {
        public SPSlabRatio this[int i]
        {
            get { return (SPSlabRatio)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPSlabRatio oSPSlabRatio)
        {
            InnerList.Add(oSPSlabRatio);
        }
        public void Refresh(int nCPSID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoSlabRatio where CPSID = ?";
            cmd.Parameters.AddWithValue("CPSID", nCPSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPSlabRatio oSPSlabRatio = new SPSlabRatio();

                    oSPSlabRatio.CPSID = int.Parse(reader["CPSID"].ToString());
                    oSPSlabRatio.ProductID = int.Parse(reader["ProductID"].ToString());
                    oSPSlabRatio.Qty = int.Parse(reader["Qty"].ToString());
                    InnerList.Add(oSPSlabRatio);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProductRatio(int nSalesPromotionID, int nProductID, int nQty)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select a.CPSID,ProductID,Qty,Discount,DiscountType,SlabNo from t_SalesPromoSlab a, t_SalesPromoSlabRatio b where a.CPSID=b.CPSID " +
                            "and SalesPromotionID=? and ProductID=? Order by SlabNo desc";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (nQty >= int.Parse(reader["Qty"].ToString()))
                    {
                        SPSlabRatio oSPSlabRatio = new SPSlabRatio();

                        oSPSlabRatio.CPSID = int.Parse(reader["CPSID"].ToString());
                        oSPSlabRatio.ProductID = int.Parse(reader["ProductID"].ToString());
                        oSPSlabRatio.Qty = int.Parse(reader["Qty"].ToString());
                        oSPSlabRatio.Discount = Convert.ToDouble(reader["Discount"].ToString());
                        oSPSlabRatio.DiscountType = int.Parse(reader["DiscountType"].ToString());
                        oSPSlabRatio.SlabNo = int.Parse(reader["SlabNo"].ToString());

                        InnerList.Add(oSPSlabRatio);
                        break;
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
        
    }
}
