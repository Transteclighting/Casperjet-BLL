// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 13, 2017
// Time : 03:54 PM
// Description: Class for ConsumerPromotionOffer.
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
    public class ConsumerPromotionOfferDetail
    {
        private int _nConsumerPromoID;
        private int _nSlabID;
        private int _nOfferID;
        private int _nOfferType;
        private int _nOfferProductID;
        private int _nOfferQty;
        private double _Discount;
        private string _sOfferDetail;
        private string _sConsumerPromoName;
        public string ConsumerPromoName
        {
            get { return _sConsumerPromoName; }
            set { _sConsumerPromoName = value.Trim(); }
        }

        private string _sSlabName;
        public string SlabName
        {
            get { return _sSlabName; }
            set { _sSlabName = value.Trim(); }
        }
        private string _sOfferName;
        public string OfferName
        {
            get { return _sOfferName; }
            set { _sOfferName = value.Trim(); }
        }
        private string _sOfferProduct;
        public string OfferProduct
        {
            get { return _sOfferProduct; }
            set { _sOfferProduct = value.Trim(); }
        }
        private double _OfferAmount;
        public double OfferAmount
        {
            get { return _OfferAmount; }
            set { _OfferAmount = value; }
        }
        private double _OfferPercentage;
        private int _EMITenureID;
        public int EMITenureID
        {
            get { return _EMITenureID; }
            set { _EMITenureID = value; }
        }

        public double OfferPercentage
        {
            get { return _OfferPercentage; }
            set { _OfferPercentage = value; }
        }
        public string OfferDetail
        {
            get { return _sOfferDetail; }
            set { _sOfferDetail = value.Trim(); }
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
        // Get set property for OfferID
        // </summary>
        public int OfferID
        {
            get { return _nOfferID; }
            set { _nOfferID = value; }
        }

        // <summary>
        // Get set property for OfferType
        // </summary>
        public int OfferType
        {
            get { return _nOfferType; }
            set { _nOfferType = value; }
        }

        // <summary>
        // Get set property for OfferProductID
        // </summary>
        public int OfferProductID
        {
            get { return _nOfferProductID; }
            set { _nOfferProductID = value; }
        }

        // <summary>
        // Get set property for OfferQty
        // </summary>
        public int OfferQty
        {
            get { return _nOfferQty; }
            set { _nOfferQty = value; }
        }

        // <summary>
        // Get set property for Discount
        // </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoCPOfferDetail (ConsumerPromoID, SlabID, OfferID, OfferType, OfferProductID, OfferQty, Discount,EMITenureID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);
                cmd.Parameters.AddWithValue("OfferProductID", _nOfferProductID);
                cmd.Parameters.AddWithValue("OfferQty", _nOfferQty);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("EMITenureID", _EMITenureID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddTP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoTPOfferDetail (TradePromoID, SlabID, OfferID, OfferType, OfferProductID, OfferQty, Discount) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);
                cmd.Parameters.AddWithValue("OfferProductID", _nOfferProductID);
                cmd.Parameters.AddWithValue("OfferQty", _nOfferQty);
                cmd.Parameters.AddWithValue("Discount", _Discount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddTPSecoundary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoTPOfferDetailSecondary (TradePromoID, SlabID, OfferID, OfferType, OfferProductID, OfferQty, Discount) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);
                cmd.Parameters.AddWithValue("OfferProductID", _nOfferProductID);
                cmd.Parameters.AddWithValue("OfferQty", _nOfferQty);
                cmd.Parameters.AddWithValue("Discount", _Discount);

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
                sSql = "UPDATE t_ConsumerPromotionOfferDetail SET SlabID = ?, OfferID = ?, OfferType = ?, OfferProductID = ?, OfferQty = ?, Discount = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);
                cmd.Parameters.AddWithValue("OfferProductID", _nOfferProductID);
                cmd.Parameters.AddWithValue("OfferQty", _nOfferQty);
                cmd.Parameters.AddWithValue("Discount", _Discount);

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
                sSql = "DELETE FROM t_ConsumerPromotionOfferDetail WHERE [ConsumerPromoID]=?";
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
                cmd.CommandText = "SELECT * FROM t_ConsumerPromotionOfferDetail where ConsumerPromoID =?";
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _nSlabID = (int)reader["SlabID"];
                    _nOfferID = (int)reader["OfferID"];
                    _nOfferType = (int)reader["OfferType"];
                    _nOfferProductID = (int)reader["OfferProductID"];
                    _nOfferQty = (int)reader["OfferQty"];
                    _Discount = (double)reader["Discount"];
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

    public class ConsumerPromotionOffer : CollectionBase
    {
        public ConsumerPromotionOfferDetail this[int i]
        {
            get { return (ConsumerPromotionOfferDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotionOfferDetail oConsumerPromotionOfferDetail)
        {
            InnerList.Add(oConsumerPromotionOfferDetail);
        }
        private int _nConsumerPromoID;
        private int _nSlabID;
        private int _nOfferID;
        private string _sOfferName;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private int _nIsActive;

        private string _sConsumerPromoName;
        public string ConsumerPromoName
        {
            get { return _sConsumerPromoName; }
            set { _sConsumerPromoName = value.Trim(); }
        }

        private string _sOfferDetails;
        public string OfferDetails
        {
            get { return _sOfferDetails; }
            set { _sOfferDetails = value.Trim(); }
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
        // Get set property for OfferID
        // </summary>
        public int OfferID
        {
            get { return _nOfferID; }
            set { _nOfferID = value; }
        }

        // <summary>
        // Get set property for OfferName
        // </summary>
        public string OfferName
        {
            get { return _sOfferName; }
            set { _sOfferName = value.Trim(); }
        }
        private string _sDescription;
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }
        

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public void AddOffer(string sTableName)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sTableName == "t_PromoCP")
                {
                    sSql = "INSERT INTO t_PromoCPOffer (ConsumerPromoID, SlabID, OfferID, OfferName,Description, CreateDate, CreateUserID, IsActive) VALUES(?,?,?,?,?,?,?,?)";
                }
                if (sTableName == "t_PromoTP")
                {
                    sSql = "INSERT INTO t_PromoTPOffer (TradePromoID, SlabID, OfferID, OfferName,Description, CreateDate, CreateUserID, IsActive) VALUES(?,?,?,?,?,?,?,?)";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (sTableName == "t_PromoCP")
                {
                    cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                }
                if (sTableName == "t_PromoTP")
                {
                    cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                }
                
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferName", _sOfferName);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add()
        {
            int nOfferID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferID]) FROM t_PromoCPOffer where ConsumerPromoID=" + _nConsumerPromoID + " and SlabID=" + _nSlabID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nOfferID = 1;
                }
                else
                {
                    nOfferID = Convert.ToInt32(maxID) + 1;
                }
                _nOfferID = nOfferID;
                sSql = "INSERT INTO t_PromoCPOffer (ConsumerPromoID, SlabID, OfferID, OfferName,Description, CreateDate, CreateUserID, IsActive) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferName", _sOfferName);
                cmd.Parameters.AddWithValue("Description", _sOfferDetails);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ConsumerPromotionOfferDetail oConsumerPromotionOfferDetail in this)
                {
                    oConsumerPromotionOfferDetail.OfferID = _nOfferID;
                    oConsumerPromotionOfferDetail.ConsumerPromoID = _nConsumerPromoID;
                    oConsumerPromotionOfferDetail.SlabID = _nSlabID;
                    oConsumerPromotionOfferDetail.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddTP()
        {
            int nOfferID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferID]) FROM t_PromoTPOffer where TradePromoID=" + _nConsumerPromoID + " and SlabID=" + _nSlabID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nOfferID = 1;
                }
                else
                {
                    nOfferID = Convert.ToInt32(maxID) + 1;
                }
                _nOfferID = nOfferID;
                sSql = "INSERT INTO t_PromoTPOffer (TradePromoID, SlabID, OfferID, OfferName,Description, CreateDate, CreateUserID, IsActive) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferName", _sOfferName);
                cmd.Parameters.AddWithValue("Description", _sOfferDetails);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ConsumerPromotionOfferDetail oConsumerPromotionOfferDetail in this)
                {
                    oConsumerPromotionOfferDetail.OfferID = _nOfferID;
                    oConsumerPromotionOfferDetail.ConsumerPromoID = _nConsumerPromoID;
                    oConsumerPromotionOfferDetail.SlabID = _nSlabID;
                    oConsumerPromotionOfferDetail.AddTP();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddTPSecoundary()
        {
            int nOfferID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferID]) FROM t_PromoTPOfferSecondary where TradePromoID=" + _nConsumerPromoID + " and SlabID=" + _nSlabID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nOfferID = 1;
                }
                else
                {
                    nOfferID = Convert.ToInt32(maxID) + 1;
                }
                _nOfferID = nOfferID;
                sSql = "INSERT INTO t_PromoTPOfferSecondary (TradePromoID, SlabID, OfferID, OfferName,Description, CreateDate, CreateUserID, IsActive) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferName", _sOfferName);
                cmd.Parameters.AddWithValue("Description", _sOfferDetails);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ConsumerPromotionOfferDetail oConsumerPromotionOfferDetail in this)
                {
                    oConsumerPromotionOfferDetail.OfferID = _nOfferID;
                    oConsumerPromotionOfferDetail.ConsumerPromoID = _nConsumerPromoID;
                    oConsumerPromotionOfferDetail.SlabID = _nSlabID;
                    oConsumerPromotionOfferDetail.AddTPSecoundary();
                }

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
                sSql = "UPDATE t_ConsumerPromotionOffer SET SlabID = ?, OfferID = ?, OfferName = ?, CreateDate = ?, CreateUserID = ?, IsActive = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("OfferID", _nOfferID);
                cmd.Parameters.AddWithValue("OfferName", _sOfferName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "DELETE FROM t_ConsumerPromotionOffer WHERE [ConsumerPromoID]=?";
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
                cmd.CommandText = "SELECT * FROM t_ConsumerPromotionOffer where ConsumerPromoID =?";
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _nSlabID = (int)reader["SlabID"];
                    _nOfferID = (int)reader["OfferID"];
                    _sOfferName = (string)reader["OfferName"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nIsActive = (int)reader["IsActive"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOfferDetail(int nPromoID, int nSlabID,int nOfferID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPOfferDetail where ConsumerPromoID = " + nPromoID + " and SlabID=" + nSlabID + " and OfferID=" + nOfferID + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPOfferDetail where TradePromoID = " + nPromoID + " and SlabID=" + nSlabID + " and OfferID=" + nOfferID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOfferDetail oConsumerPromotionOffer = new ConsumerPromotionOfferDetail();
                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotionOffer.EMITenureID = (int)reader["EMITenureID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    }
                    oConsumerPromotionOffer.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOffer.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOffer.OfferType = (int)reader["OfferType"];
                    oConsumerPromotionOffer.OfferProductID = (int)reader["OfferProductID"];
                    oConsumerPromotionOffer.OfferQty = (int)reader["OfferQty"];
                    oConsumerPromotionOffer.Discount = (double)reader["Discount"];
                    
                    InnerList.Add(oConsumerPromotionOffer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOfferDetail(string sPromoID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPOfferDetail where ConsumerPromoID in (" + sPromoID + ")";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPOfferDetail where TradePromoID in (" + sPromoID + ")";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOfferDetail oConsumerPromotionOffer = new ConsumerPromotionOfferDetail();
                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotionOffer.EMITenureID = (int)reader["EMITenureID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    }
                    oConsumerPromotionOffer.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOffer.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOffer.OfferType = (int)reader["OfferType"];
                    oConsumerPromotionOffer.OfferProductID = (int)reader["OfferProductID"];
                    oConsumerPromotionOffer.OfferQty = (int)reader["OfferQty"];
                    oConsumerPromotionOffer.Discount = (double)reader["Discount"];

                    InnerList.Add(oConsumerPromotionOffer);
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

    public class ConsumerPromotionOffers : CollectionBase
    {
        public ConsumerPromotionOffer this[int i]
        {
            get { return (ConsumerPromotionOffer)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotionOffer oConsumerPromotionOffer)
        {
            InnerList.Add(oConsumerPromotionOffer);
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
            string sSql = "SELECT * FROM t_ConsumerPromotionOffer";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOffer oConsumerPromotionOffer = new ConsumerPromotionOffer();
                    oConsumerPromotionOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotionOffer.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOffer.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOffer.OfferName = (string)reader["OfferName"];
                    oConsumerPromotionOffer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotionOffer.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotionOffer.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oConsumerPromotionOffer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSinglePromotion(DateTime _dtOperationDate, int nConsumerPromoTypeID, int nChannelID, int nWarehouseID, int nGroupTypeID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ConsumerPromoID,ConsumerPromoName,SlabID,SlabName,OfferID,OfferName, " +
                        "max(OfferProduct) OfferProduct,max(OfferAmount) OfferAmount, " +
                        "max(OfferPercentage) OfferPercentage From  " +
                        "( " +
                        "Select ConsumerPromoID,ConsumerPromoName,SlabID,SlabName,OfferID,OfferName, " +
                        "case OfferType when 0 then ProductName+':'+CAST(OfferQty as varchar(100))+'Pcs'  " +
                        "else '' end as OfferProduct, " +
                        "case OfferType when 1 then Discount else 0 end as OfferAmount, " +
                        "case OfferType when 2 then Discount else 0 end as OfferPercentage " +
                        "From  " +
                        "( " +
                        "Select a.ConsumerPromoID,'['+ConsumerPromoNo+']'+' '+ConsumerPromoName as ConsumerPromoName, " +
                        "a.SlabID,SlabName,c.OfferID,OfferName,OfferType,OfferProductID,OfferQty,Discount " +
                        "From t_ConsumerPromotion x,t_ConsumerPromotionSlab a,t_ConsumerPromotionSlabRatio b, " +
                        "t_ConsumerPromotionOffer c,t_ConsumerPromotionOfferDetail d " +
                        "where x.ConsumerPromoID=a.ConsumerPromoID and  " +
                        "a.SlabID=b.SlabID and a.ConsumerPromoID=b.ConsumerPromoID  " +
                        "and a.SlabID=c.SlabID and a.ConsumerPromoID=c.ConsumerPromoID   " +
                        "and c.SlabID=d.SlabID and c.ConsumerPromoID=d.ConsumerPromoID and c.OfferID=d.OfferID " +
                        "and a.ConsumerPromoID in  " +
                        "( " +
                        "Select ConsumerPromoID From  dbo.t_ConsumerPromotionSlab  " +
                        "group by ConsumerPromoID HAVING COUNT(SlabID)=1 " +
                        ") and a.IsActive=1 and c.IsActive=1  " +
                        ") a " +
                        "Left Outer Join  " +
                        "( " +
                        "Select * From t_Product " +
                        ") b " +
                        "on a.OfferProductID=b.ProductID " +
                        ") a  where ConsumerPromoID in  " +
                        "( " +
                        "Select a.ConsumerPromoID From  " +
                        "dbo.t_ConsumerPromotion a,t_ConsumerPromotionType b, " +
                        "t_ConsumerPromotionChannel c,dbo.t_ConsumerPromotionWarehouse d, " +
                        "( " +
                        "Select * From t_ConsumerPromotionProductFor  " +
                        "where ConsumerPromoID in  " +
                        "( " +
                        "Select ConsumerPromoID " +
                        "From t_ConsumerPromotionProductFor group by ConsumerPromoID " +
                        "HAVING COUNT(ProductID)=1) " +
                        ") e " +
                        "where a.ConsumerPromoID=b.ConsumerPromoID  " +
                        "and a.ConsumerPromoID=c.ConsumerPromoID  " +
                        "and a.ConsumerPromoID=c.ConsumerPromoID  " +
                        "and a.ConsumerPromoID=e.ConsumerPromoID  " +
                        "and '" + _dtOperationDate + "' between fromdate and toDate  " +
                        "and ConsumerPromoTypeID=" + nConsumerPromoTypeID + " and ChannelID=" + nChannelID + " " +
                        "and WarehouseID=" + nWarehouseID + " and GroupTypeID=" + nGroupTypeID + " and ProductID=" + nProductID + " " +
                        ") " +
                        "group by ConsumerPromoID,ConsumerPromoName,SlabID,SlabName,OfferID,OfferName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOfferDetail oConsumerPromotionOfferDetail = new ConsumerPromotionOfferDetail();
                    oConsumerPromotionOfferDetail.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotionOfferDetail.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    oConsumerPromotionOfferDetail.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOfferDetail.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionOfferDetail.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOfferDetail.OfferName = (string)reader["OfferName"];
                    oConsumerPromotionOfferDetail.OfferProduct = (string)reader["OfferProduct"];
                    oConsumerPromotionOfferDetail.OfferAmount = Convert.ToDouble(reader["OfferAmount"].ToString());
                    oConsumerPromotionOfferDetail.OfferPercentage = Convert.ToDouble(reader["OfferPercentage"].ToString());
                    InnerList.Add(oConsumerPromotionOfferDetail);
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
                sSql = "SELECT * FROM t_PromoCPOffer where ConsumerPromoID = " + nPromoID + " and SlabID=" + nSlabID + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPOffer where TradePromoID = " + nPromoID + " and SlabID=" + nSlabID + "";
            }
            else if (sTableName == "t_PromoTPSecondary")
            {
                sSql = "SELECT * FROM t_PromoTPOfferSecondary where TradePromoID = " + nPromoID + " and SlabID=" + nSlabID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOffer oConsumerPromotionOffer = new ConsumerPromotionOffer();
                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    }
                    else if (sTableName == "t_PromoTPSecondary")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    }
                    oConsumerPromotionOffer.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOffer.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOffer.OfferName = (string)reader["OfferName"];
                    oConsumerPromotionOffer.Description = (string)reader["Description"];
                    oConsumerPromotionOffer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotionOffer.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotionOffer.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oConsumerPromotionOffer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoOffer(string sPromoID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "SELECT * FROM t_PromoCPOffer where ConsumerPromoID in ( " + sPromoID + ")";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "SELECT * FROM t_PromoTPOffer where TradePromoID in ( " + sPromoID + ")";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOffer oConsumerPromotionOffer = new ConsumerPromotionOffer();
                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = (int)reader["TradePromoID"];
                    }

                    oConsumerPromotionOffer.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionOffer.OfferID = (int)reader["OfferID"];
                    oConsumerPromotionOffer.OfferName = (string)reader["OfferName"];
                    oConsumerPromotionOffer.Description = (string)reader["Description"];
                    oConsumerPromotionOffer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotionOffer.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotionOffer.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oConsumerPromotionOffer);
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

