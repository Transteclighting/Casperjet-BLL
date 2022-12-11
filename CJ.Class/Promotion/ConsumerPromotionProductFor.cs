// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 13, 2017
// Time : 03:15 PM
// Description: Class for ConsumerPromotionProductFor.
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
    public class ConsumerPromotionProductFor
    {
        private int _nConsumerPromoID;
        private int _nGroupTypeID;
        private int _nProductID;
        private int _nTGTQty;
        private int _nBrandID;
        private int _nProductGroupID;
        private string _sMAG;
        private string _sBrandDesc;

        private double _TargetMC;
        public double TargetMC
        {
            get { return _TargetMC; }
            set { _TargetMC = value; }
        }

        private double _TargetValue;
        public double TargetValue
        {
            get { return _TargetValue; }
            set { _TargetValue = value; }
        }
        private double _PromoCostVal;
        public double PromoCostVal
        {
            get { return _PromoCostVal; }
            set { _PromoCostVal = value; }
        }
        private double _NetSalesVal;
        public double NetSalesVal
        {
            get { return _NetSalesVal; }
            set { _NetSalesVal = value; }
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
        private double _Month01SalesQty;

        public double Month01SalesQty
        {
            get { return _Month01SalesQty; }
            set { _Month01SalesQty = value; }
        }
        private double _Month01NetSale;

        public double Month01NetSale
        {
            get { return _Month01NetSale; }
            set { _Month01NetSale = value; }
        }

        private double _Month02SalesQty;
        public double Month02SalesQty
        {
            get { return _Month02SalesQty; }
            set { _Month02SalesQty = value; }
        }
        private double _Month02NetSale;
        public double Month02NetSale
        {
            get { return _Month02NetSale; }
            set { _Month02NetSale = value; }
        }

        private double _Month03SalesQty;
        public double Month03SalesQty
        {
            get { return _Month03SalesQty; }
            set { _Month03SalesQty = value; }
        }
        private double _Month03NetSale;
        public double Month03NetSale
        {
            get { return _Month03NetSale; }
            set { _Month03NetSale = value; }
        }

        public int TGTQty
        {
            get { return _nTGTQty; }
            set { _nTGTQty = value; }
        }
        private int _nRegularSalesQty;
        public int RegularSalesQty
        {
            get { return _nRegularSalesQty; }
            set { _nRegularSalesQty = value; }
        }
        private double _DiscountRatio;
        public double DiscountRatio
        {
            get { return _DiscountRatio; }
            set { _DiscountRatio = value; }
        }

        private int _sIsApplicableOnAllSKU;
        public int IsApplicableOnAllSKU
        {
            get { return _sIsApplicableOnAllSKU; }
            set { _sIsApplicableOnAllSKU = value; }
        }
        private string _sApplicableProductID;
        public string ApplicableProductID
        {
            get { return _sApplicableProductID; }
            set { _sApplicableProductID = value.Trim(); }
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
        // Get set property for GroupTypeID
        // </summary>
        public int GroupTypeID
        {
            get { return _nGroupTypeID; }
            set { _nGroupTypeID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
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

        public void Add()
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ConsumerPromoID]) FROM t_ConsumerPromotionProductFor";
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
                sSql = "INSERT INTO t_ConsumerPromotionProductFor (ConsumerPromoID, GroupTypeID, ProductID) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Insert()// added TargetValue,PromoCostVal,NetSalesVal
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoCPProductFor (ConsumerPromoID, GroupTypeID, ProductID, TargetQty,TargetValue,PromoCostVal,NetSalesVal, RegularSalesQty, DiscountRatio,TargetMC) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                cmd.Parameters.AddWithValue("TargetValue;", _TargetValue);
                cmd.Parameters.AddWithValue("PromoCostVal", _PromoCostVal);
                cmd.Parameters.AddWithValue("NetSalesVal", _NetSalesVal);
                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("DiscountRatio", _DiscountRatio);
                cmd.Parameters.AddWithValue("TargetMC", _TargetMC);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertSC()// added TargetValue,PromoCostVal,NetSalesVal
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_ScratchCardOfferProductFor (ScratchCardOfferID, ProductID) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoCPProductFor (ConsumerPromoID, GroupTypeID, ProductID, TargetQty,RegularSalesQty, DiscountRatio) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("DiscountRatio", _DiscountRatio);



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
                sSql = "INSERT INTO t_PromoTPProductFor (TradePromoID, GroupTypeID, ProductGroupID, BrandID, TargetQty,TargetValue,PromoCostVal,NetSalesVal, RegularSalesQty, DiscountRatio,IsApplicableOnAllSKU,ApplicableProductID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                cmd.Parameters.AddWithValue("TargetValue;", _TargetValue);
                cmd.Parameters.AddWithValue("PromoCostVal", _PromoCostVal);
                cmd.Parameters.AddWithValue("NetSalesVal", _NetSalesVal);
                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("DiscountRatio", _DiscountRatio);

                cmd.Parameters.AddWithValue("IsApplicableOnAllSKU", _sIsApplicableOnAllSKU);
                cmd.Parameters.AddWithValue("ApplicableProductID", _sApplicableProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTPSecondary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoTPProductForSecondary (TradePromoID, GroupTypeID, ProductGroupID, BrandID, TargetQty,TargetValue,PromoCostVal,NetSalesVal, RegularSalesQty, DiscountRatio,IsApplicableOnAllSKU,ApplicableProductID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                cmd.Parameters.AddWithValue("TargetValue;", _TargetValue);
                cmd.Parameters.AddWithValue("PromoCostVal", _PromoCostVal);
                cmd.Parameters.AddWithValue("NetSalesVal", _NetSalesVal);
                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("DiscountRatio", _DiscountRatio);

                cmd.Parameters.AddWithValue("IsApplicableOnAllSKU", _sIsApplicableOnAllSKU);
                cmd.Parameters.AddWithValue("ApplicableProductID", _sApplicableProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertTPForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoTPProductFor (TradePromoID, GroupTypeID, ProductGroupID, BrandID, TargetQty, RegularSalesQty, DiscountRatio,IsApplicableOnAllSKU,ApplicableProductID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                
                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("DiscountRatio", _DiscountRatio);
                cmd.Parameters.AddWithValue("IsApplicableOnAllSKU", _sIsApplicableOnAllSKU);
                cmd.Parameters.AddWithValue("ApplicableProductID", _sApplicableProductID);

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
                sSql = "UPDATE t_ConsumerPromotionProductFor SET GroupTypeID = ?, ProductID = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateCP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoCPProductFor SET TargetQty=?,TargetValue=?,PromoCostVal=?,NetSalesVal=?,RegularSalesQty=?,TargetMC=? where GroupTypeID = ? and ProductID = ? and ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                cmd.Parameters.AddWithValue("TargetValue", _TargetValue);
                cmd.Parameters.AddWithValue("PromoCostVal", _PromoCostVal);
                cmd.Parameters.AddWithValue("NetSalesVal", _NetSalesVal);

                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("TargetMC", _TargetMC);
                /////

                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateTP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoTPProductFor SET TargetQty=?,TargetValue=?,PromoCostVal=?,NetSalesVal=?,RegularSalesQty=? where BrandID=? and GroupTypeID = ? and ProductGroupID = ? and TradePromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("TargetQty", _nTGTQty);
                cmd.Parameters.AddWithValue("TargetValue", _TargetValue);
                cmd.Parameters.AddWithValue("PromoCostVal", _PromoCostVal);
                cmd.Parameters.AddWithValue("NetSalesVal", _NetSalesVal);

                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                /////
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("GroupTypeID", _nGroupTypeID);
                cmd.Parameters.AddWithValue("ProductGroupID", _nProductGroupID);

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);

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
                sSql = "DELETE FROM t_ConsumerPromotionProductFor WHERE [ConsumerPromoID]=?";
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
                cmd.CommandText = "SELECT * FROM t_ConsumerPromotionProductFor where ConsumerPromoID =?";
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _nGroupTypeID = (int)reader["GroupTypeID"];
                    _nProductID = (int)reader["ProductID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertScratchCardOfferProductForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_ScratchCardOfferProductFor (ScratchCardOfferID, ProductID) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);
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
    public class ConsumerPromotionProductFors : CollectionBase
    {
        public ConsumerPromotionProductFor this[int i]
        {
            get { return (ConsumerPromotionProductFor)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotionProductFor oConsumerPromotionProductFor)
        {
            InnerList.Add(oConsumerPromotionProductFor);
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
            string sSql = "SELECT * FROM t_ConsumerPromotionProductFor";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    oConsumerPromotionProductFor.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotionProductFor.GroupTypeID = (int)reader["GroupTypeID"];
                    oConsumerPromotionProductFor.ProductID = (int)reader["ProductID"];
                    InnerList.Add(oConsumerPromotionProductFor);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPProductFor where ConsumerPromoID = " + nPromoID + " ";
            }
            else if (sTablename == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPProductFor where TradePromoID = " + nPromoID + " ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    if (sTablename == "t_PromoCP")
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotionProductFor.ProductID = (int)reader["ProductID"];
                        oConsumerPromotionProductFor.IsApplicableOnAllSKU = 1;
                        oConsumerPromotionProductFor.ApplicableProductID = "";
                                               
                    }
                    else if (sTablename == "t_PromoTP")
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionProductFor.ProductGroupID = (int)reader["ProductGroupID"];
                        oConsumerPromotionProductFor.BrandID = (int)reader["BrandID"];
                        oConsumerPromotionProductFor.IsApplicableOnAllSKU = (int)reader["IsApplicableOnAllSKU"];
                        oConsumerPromotionProductFor.ApplicableProductID = (string)reader["ApplicableProductID"];
                    }

                    /////////////
                    if (reader["TargetValue"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.TargetValue = (double)reader["TargetValue"];
                    }
                    if (reader["PromoCostVal"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.PromoCostVal = (double)reader["PromoCostVal"];
                    }
                    if (reader["NetSalesVal"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.NetSalesVal = (double)reader["NetSalesVal"];
                    }
                    ///////////////

                    oConsumerPromotionProductFor.GroupTypeID = (int)reader["GroupTypeID"];
                    oConsumerPromotionProductFor.TGTQty = (int)reader["TargetQty"];
                   
                    oConsumerPromotionProductFor.RegularSalesQty = (int)reader["RegularSalesQty"];
                    oConsumerPromotionProductFor.DiscountRatio = (double)reader["DiscountRatio"];

                    InnerList.Add(oConsumerPromotionProductFor);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetForProduct(string sPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPProductFor where ConsumerPromoID in ( " + sPromoID + " )";
            }
            else if (sTablename == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPProductFor where TradePromoID in ( " + sPromoID + " )";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    if (sTablename == "t_PromoCP")
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotionProductFor.ProductID = (int)reader["ProductID"];
                        oConsumerPromotionProductFor.IsApplicableOnAllSKU = 1;
                        oConsumerPromotionProductFor.ApplicableProductID = "";
                      
                    }
                    else if (sTablename == "t_PromoTP")
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionProductFor.ProductGroupID = (int)reader["ProductGroupID"];
                        oConsumerPromotionProductFor.BrandID = (int)reader["BrandID"];
                        oConsumerPromotionProductFor.IsApplicableOnAllSKU = (int)reader["IsApplicableOnAllSKU"];
                        oConsumerPromotionProductFor.ApplicableProductID = (string)reader["ApplicableProductID"];
                    }
                    /////////////
                    if (reader["TargetValue"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.TargetValue = (double)reader["TargetValue"];
                    }
                    if (reader["PromoCostVal"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.PromoCostVal = (double)reader["PromoCostVal"];
                    }
                    if (reader["NetSalesVal"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.NetSalesVal = (double)reader["NetSalesVal"];
                    }
                    ///////////////

                    oConsumerPromotionProductFor.GroupTypeID = (int)reader["GroupTypeID"];
                    oConsumerPromotionProductFor.TGTQty = (int)reader["TargetQty"];
                    
                    oConsumerPromotionProductFor.RegularSalesQty = (int)reader["RegularSalesQty"];
                    oConsumerPromotionProductFor.DiscountRatio = (double)reader["DiscountRatio"];

                    InnerList.Add(oConsumerPromotionProductFor);
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
            string sSql = "Select * From  " +
                        "(  " +
                        "Select ConsumerPromoID,'['+ProductCode+']'+ ProductName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
                        "From t_PromoCPProductFor a,t_Product b  " +
                        "where a.ProductID=b.ProductID and GroupTypeID=1  " +
                        "Union All  " +
                        "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
                        "From t_PromoCPProductFor a,t_ProductGroup b  " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=2 and PdtGroupType=1  " +
                        "Union All  " +
                        "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
                        "From t_PromoCPProductFor a,t_ProductGroup b  " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=3 and PdtGroupType=2  " +
                        "Union All  " +
                        "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
                        "From t_PromoCPProductFor a,t_ProductGroup b  " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=4 and PdtGroupType=3  " +
                        "Union All  " +
                        "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
                        "From t_PromoCPProductFor a,t_ProductGroup b  " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=5 and PdtGroupType=4  " +
                        ") Main where ConsumerPromoID=" + nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    oConsumerPromotionProductFor.ProductName = (string)reader["ProductName"];
                    oConsumerPromotionProductFor.TGTQty = Convert.ToInt32(reader["TargetQty"].ToString());
                    /////////////
                    if (reader["TargetValue"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.TargetValue = (double)reader["TargetValue"];
                    }
                    if (reader["PromoCostVal"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.PromoCostVal = (double)reader["PromoCostVal"];
                    }
                    if (reader["NetSalesVal"] != DBNull.Value)
                    {
                        oConsumerPromotionProductFor.NetSalesVal = (double)reader["NetSalesVal"];
                    }
                    ///////////////
                    oConsumerPromotionProductFor.RegularSalesQty = Convert.ToInt32(reader["RegularSalesQty"].ToString());
                    oConsumerPromotionProductFor.DiscountRatio = Convert.ToDouble(reader["DiscountRatio"].ToString());
                    InnerList.Add(oConsumerPromotionProductFor);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPromoProductDetail(int nConsumerPromoID, DateTime dtFromDate,string sCompany)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
                        "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
                        "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
                        "(Select a.ProductID,ConsumerPromoID,'['+ProductCode+']'+ ProductName as ProductName,TargetQty    " +
                        "From t_ConsumerPromotionProductFor a,t_Product b    " +
                        "where a.ProductID=b.ProductID and GroupTypeID=1) a  " +
                        "Left Outer Join   " +
                        "(Select ProductID,  " +
                        "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
                        "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
                        "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
                        "From   " +
                        "(  " +
                        "Select ProductID,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct where   " +
                        "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
                        "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and CompanyName='" + sCompany + "'  " +
                        ") A group by ProductID) b  " +
                        "on a.ProductID=b.ProductID  " +
                        "Union All  " +
                //---PG---
                        "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
                        "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
                        "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
                        "(Select ConsumerPromoID,PdtGroupID as PGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
                        "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=2 and PdtGroupType=1) a  " +
                        "Left Outer Join   " +
                        "(Select PGID,  " +
                        "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
                        "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
                        "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
                        "From   " +
                        "(  " +
                        "Select PGID,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
                        "where a.ProductID=b.ProductID and   " +
                        "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
                        "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and CompanyName='" + sCompany + "'  " +
                        ") A group by PGID) b  " +
                        "on a.PGID=b.PGID  " +
                        "Union All  " +
                //---MAG----
                        "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
                        "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
                        "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
                        "(Select ConsumerPromoID,PdtGroupID as MAGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
                        "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=3 and PdtGroupType=2) a  " +
                        "Left Outer Join   " +
                        "(Select MAGID,  " +
                        "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
                        "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
                        "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
                        "From   " +
                        "(  " +
                        "Select MAGID,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
                        "where a.ProductID=b.ProductID and   " +
                        "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
                        "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and CompanyName='" + sCompany + "'  " +
                        ") A group by MAGID) b  " +
                        "on a.MAGID=b.MAGID  " +
                        "Union All  " +
                //---ASG----
                        "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
                        "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
                        "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
                        "(Select ConsumerPromoID,PdtGroupID as ASGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
                        "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=4 and PdtGroupType=3) a  " +
                        "Left Outer Join   " +
                        "(Select ASGID,  " +
                        "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
                        "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
                        "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
                        "From   " +
                        "(  " +
                        "Select ASGID,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
                        "where a.ProductID=b.ProductID and   " +
                        "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
                        "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and CompanyName='" + sCompany + "'  " +
                        ") A group by ASGID) b  " +
                        "on a.ASGID=b.ASGID  " +
                        "Union All  " +
                //---AG---
                        "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
                        "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
                        "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
                        "(Select ConsumerPromoID,PdtGroupID as AGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
                        "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
                        "where a.ProductID=b.pdtGroupID and GroupTypeID=5 and PdtGroupType=4) a  " +
                        "Left Outer Join   " +
                        "(Select AGID,  " +
                        "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
                        "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
                        "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
                        "From   " +
                        "(  " +
                        "Select AGID,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
                        "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
                        "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
                        "where a.ProductID=b.ProductID and   " +
                        "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
                        "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
                        "and CompanyName='" + sCompany + "'  " +
                        ") A group by AGID) b  " +
                        "on a.AGID=b.AGID  " +
                        ") Main where ConsumerPromoID=" + nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    oConsumerPromotionProductFor.ProductName = (string)reader["ProductName"];
                    InnerList.Add(oConsumerPromotionProductFor);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetScratchCardForProduct(string sPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_ScratchCardOffer")
            {
                sSql = "SELECT * FROM t_ScratchCardOfferProductFor where ScratchCardOfferID in ( " + sPromoID + " )";
            }
           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                    if (sTablename == "t_ScratchCardOffer")
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = (int)reader["ScratchCardOfferID"];
                        oConsumerPromotionProductFor.ProductID = (int)reader["ProductID"];

                    }
                    InnerList.Add(oConsumerPromotionProductFor);
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

