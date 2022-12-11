// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 13, 2017
// Time : 03:29 PM
// Description: Class for ConsumerPromotionSlabRatio.
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
    public class ConsumerPromotionSlabRatio
    {
        private int _nConsumerPromoID;
        private int _nSlabID;
        private int _nProductID;
        private int _nQty;
        private string _sSlabName;
        private string _sProductName;
        private int _nGroupTypeID;
        private int _nBrandID;
        private int _nProductGroupID;
        private string _sMAG;
        private string _sBrandDesc;
        public int GroupTypeID
        {
            get { return _nGroupTypeID; }
            set { _nGroupTypeID = value; }
        }
        public string MAG
        {
            get { return _sMAG; }
            set { _sMAG = value.Trim(); }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public int ProductGroupID
        {
            get { return _nProductGroupID; }
            set { _nProductGroupID = value; }
        }


        private string _sProductGroupName;
        public string ProductGroupName
        {
            get { return _sProductGroupName; }
            set { _sProductGroupName = value.Trim(); }
        }
        private string _sBrandName;
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value.Trim(); }
        }

        public string SlabName
        {
            get { return _sSlabName; }
            set { _sSlabName = value.Trim(); }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        // <summary>
        // Get set property for ConsumerPromoID
        // </summary>
        public int ConsumerPromoID
        {
            get { return _nConsumerPromoID; }
            set { _nConsumerPromoID = value; }
        }

        // <summary>
        // Get set property for SlabID
        // </summary>
        public int SlabID
        {
            get { return _nSlabID; }
            set { _nSlabID = value; }
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
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        public void Add()
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ConsumerPromoID]) FROM t_ConsumerPromotionSlabRatio";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxConsumerPromoID = 1;
                }
                else
                {
                    nMaxConsumerPromoID = Convert.ToInt32(maxID) + 1;
                }
                _nConsumerPromoID = nMaxConsumerPromoID;
                sSql = "INSERT INTO t_ConsumerPromotionSlabRatio (ConsumerPromoID, SlabID, ProductID, Qty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
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

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoCPSlabRatio (ConsumerPromoID, SlabID, ProductID, Qty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
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

        public void InsertTP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoTPSlabRatio (TradePromoID, SlabID, GroupTypeID, ProductGroupID, BrandID, MinQty) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("MinQty", _nQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTPSecoundary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoTPSlabRatioSecondary (TradePromoID, SlabID, GroupTypeID, ProductGroupID, BrandID, MinQty) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("MinQty", _nQty);

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
                sSql = "UPDATE t_ConsumerPromotionSlabRatio SET SlabID = ?, ProductID = ?, Qty = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

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
                sSql = "DELETE FROM t_ConsumerPromotionSlabRatio WHERE [ConsumerPromoID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
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
                cmd.CommandText = "SELECT * FROM t_ConsumerPromotionSlabRatio where ConsumerPromoID =?";
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _nSlabID = (int)reader["SlabID"];
                    _nProductID = (int)reader["ProductID"];
                    _nQty = (int)reader["Qty"];
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
    public class ConsumerPromotionSlabRatios : CollectionBase
    {
        public ConsumerPromotionSlabRatio this[int i]
        {
            get { return (ConsumerPromotionSlabRatio)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio)
        {
            InnerList.Add(oConsumerPromotionSlabRatio);
        }
        public int GetIndex(int nConsumerPromoID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ConsumerPromoID == nConsumerPromoID)
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
            string sSql = "SELECT * FROM t_ConsumerPromotionSlabRatio";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlabRatio.ProductID = (int)reader["ProductID"];
                    oConsumerPromotionSlabRatio.Qty = (int)reader["Qty"];
                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nConsumerPromoID,int nSlabID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select SlabID,SlabName,ProductName,Qty From   " +
                        "(   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + ProductCode + ']' + ProductName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_Product b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.ProductID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and a.ProductID = c.ProductID and c.SlabID = d.SlabID and GroupTypeID = 1   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 2 and PdtGroupType = 1   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 3 and PdtGroupType = 2   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 4 and PdtGroupType = 3   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 5 and PdtGroupType = 4   " +
                        ") Main where ConsumerPromoID = " + nConsumerPromoID + " and SlabID=" + nSlabID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlabRatio.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionSlabRatio.ProductName = (string)reader["ProductName"];
                    oConsumerPromotionSlabRatio.Qty = (int)reader["Qty"];
                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshTPRatio(int nConsumerPromoID, int nSlabID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,SlabName,PdtGroupName as ProductGroupName,BrandDesc as BrandName  " +
                        "From t_PromoTPSlabRatio a,t_Brand b, t_ProductGroup c,t_PromoTPSlab d  " +
                        "where a.BrandID = b.BrandID and a.ProductGroupID = c.PdtGroupID and a.TradePromoID = d.TradePromoID  " +
                        "and a.SlabID = d.SlabID and GroupTypeID = 3  and a.TradePromoID = "+ nConsumerPromoID + " and a.SlabID = "+ nSlabID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlabRatio.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionSlabRatio.ProductGroupName = (string)reader["ProductGroupName"];
                    oConsumerPromotionSlabRatio.BrandName = (string)reader["BrandName"];
                    oConsumerPromotionSlabRatio.Qty = (int)reader["MinQty"];
                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshTPRatioSecondary(int nConsumerPromoID, int nSlabID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,SlabName,PdtGroupName as ProductGroupName,BrandDesc as BrandName  " +
                        "From t_PromoTPSlabRatioSecondary a,t_Brand b, t_ProductGroup c,t_PromoTPSlabSecondary d  " +
                        "where a.BrandID = b.BrandID and a.ProductGroupID = c.PdtGroupID and a.TradePromoID = d.TradePromoID  " +
                        "and a.SlabID = d.SlabID and GroupTypeID = 3  and a.TradePromoID = " + nConsumerPromoID + " and a.SlabID = " + nSlabID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlabRatio.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionSlabRatio.ProductGroupName = (string)reader["ProductGroupName"];
                    oConsumerPromotionSlabRatio.BrandName = (string)reader["BrandName"];
                    oConsumerPromotionSlabRatio.Qty = (int)reader["MinQty"];
                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select SlabID,SlabName,ProductName,Qty From   " +
                        "(   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + ProductCode + ']' + ProductName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_Product b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.ProductID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and a.ProductID = c.ProductID and c.SlabID = d.SlabID and GroupTypeID = 1   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 2 and PdtGroupType = 1   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 3 and PdtGroupType = 2   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 4 and PdtGroupType = 3   " +
                        "Union All   " +
                        "Select c.ConsumerPromoID, d.SlabID, SlabName, '[' + pdtGroupCode + ']' + pdtGroupName as ProductName, Qty   " +
                        "From t_PromoCPProductFor a, t_ProductGroup b, t_PromoCPSlabRatio c, t_PromoCPSlab d   " +
                        "where a.ProductID = b.pdtGroupID and a.ConsumerPromoID = c.ConsumerPromoID and c.ConsumerPromoID = d.ConsumerPromoID   " +
                        "and c.SlabID = d.SlabID and a.ProductID = c.ProductID  and GroupTypeID = 5 and PdtGroupType = 4   " +
                        ") Main where ConsumerPromoID = " + nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlabRatio.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionSlabRatio.ProductName = (string)reader["ProductName"];
                    oConsumerPromotionSlabRatio.Qty = (int)reader["Qty"];

                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nPromoID, int nSlabID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPSlabRatio where ConsumerPromoID =" + nPromoID + " and SlabID=" + nSlabID + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPSlabRatio where TradePromoID =" + nPromoID + " and SlabID=" + nSlabID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotionSlabRatio.ProductID = (int)reader["ProductID"];
                        oConsumerPromotionSlabRatio.Qty = (int)reader["Qty"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionSlabRatio.GroupTypeID = (int)reader["GroupTypeID"];
                        oConsumerPromotionSlabRatio.ProductGroupID = (int)reader["ProductGroupID"];
                        oConsumerPromotionSlabRatio.BrandID = (int)reader["BrandID"];
                        oConsumerPromotionSlabRatio.Qty = (int)reader["MinQty"];
                    }
                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalbInvoiceQty(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select SlabName+': '+cast(MinInvoiceQty as varchar)+'Pcs' as SlabDetail From t_PromoTPSlab where TradePromoID=" + nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabName = (string)reader["SlabDetail"];

                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalbInvoiceQtySecondary(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select SlabName+': '+cast(MinInvoiceQty as varchar)+'Pcs' as SlabDetail From t_PromoTPSlabSecondary where TradePromoID=" + nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabName = (string)reader["SlabDetail"];

                    InnerList.Add(oConsumerPromotionSlabRatio);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSlabRatio(string sPromoID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPSlabRatio where ConsumerPromoID in (" + sPromoID + ")";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPSlabRatio where TradePromoID in (" + sPromoID + ")";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio = new ConsumerPromotionSlabRatio();
                    oConsumerPromotionSlabRatio.SlabID = (int)reader["SlabID"];
                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotionSlabRatio.ProductID = (int)reader["ProductID"];
                        oConsumerPromotionSlabRatio.Qty = (int)reader["Qty"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionSlabRatio.GroupTypeID = (int)reader["GroupTypeID"];
                        oConsumerPromotionSlabRatio.ProductGroupID = (int)reader["ProductGroupID"];
                        oConsumerPromotionSlabRatio.BrandID = (int)reader["BrandID"];
                        oConsumerPromotionSlabRatio.Qty = (int)reader["MinQty"];
                    }
                    InnerList.Add(oConsumerPromotionSlabRatio);
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

