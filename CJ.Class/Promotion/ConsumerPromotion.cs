// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 13, 2017
// Time : 03:10 PM
// Description: Class for ConsumerPromotion.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.Promotion;


namespace CJ.Class
{
    public class ConsumerPromotionSlab
    {
        private string _sProductGroupName;
        private string _sBrandName;

        private int _nConsumerPromoID;
        private int _nSlabID;
        private string _sSlabNo;
        private string _sSlabName;
        private int _nMinInvoiceQty;
        private int _nIsActive;
        private object _dCreateDate;
        private int _nCreateUserID;
        private object _dUpdateDate;
        private int _nUpdateUserID;

        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }


        public string ProductGroupName
        {
            get { return _sProductGroupName; }
            set { _sProductGroupName = value.Trim(); }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value.Trim(); }
        }

        private int _nTargetQty;
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
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

        private ConsumerPromotionSlabRatios oConsumerPromotionSlabRatios;
        public ConsumerPromotionSlabRatios ConsumerPromotionSlabRatios
        {
            get
            {
                if (oConsumerPromotionSlabRatios == null)
                {
                    oConsumerPromotionSlabRatios = new ConsumerPromotionSlabRatios();
                }
                return oConsumerPromotionSlabRatios;
            }
        }

        private ConsumerPromotionOffers oConsumerPromotionOffers;
        public ConsumerPromotionOffers ConsumerPromotionOffers
        {
            get
            {
                if (oConsumerPromotionOffers == null)
                {
                    oConsumerPromotionOffers = new ConsumerPromotionOffers();
                }
                return oConsumerPromotionOffers;
            }
        }

        //private ConsumerPromotionOfferDetails oConsumerPromotionOfferDetails;
        //public ConsumerPromotionOfferDetails ConsumerPromotionOfferDetails
        //{
        //    get
        //    {
        //        if (oConsumerPromotionOfferDetails == null)
        //        {
        //            oConsumerPromotionOfferDetails = new ConsumerPromotionOfferDetails();
        //        }
        //        return oConsumerPromotionOfferDetails;
        //    }
        //}


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

        public int MinInvoiceQty
        {
            get { return _nMinInvoiceQty; }
            set { _nMinInvoiceQty = value; }
        }

        // <summary>
        // Get set property for SlabNo
        // </summary>
        public string SlabNo
        {
            get { return _sSlabNo; }
            set { _sSlabNo = value.Trim(); }
        }

        // <summary>
        // Get set property for SlabName
        // </summary>
        public string SlabName
        {
            get { return _sSlabName; }
            set { _sSlabName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        private int _nQty;
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public object CreateDate
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
        // Get set property for UpdateDate
        // </summary>
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public void AddCP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
               
                sSql = "INSERT INTO t_PromoCPSlab (ConsumerPromoID, SlabID, SlabName, IsActive, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("SlabName", _sSlabName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
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
        public void AddTP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_PromoTPSlab (TradePromoID, SlabID, SlabName, MinInvoiceQty, IsActive, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("SlabName", _sSlabName);
                cmd.Parameters.AddWithValue("MinInvoiceQty", _nMinInvoiceQty);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ConsumerPromotionSlab SET SlabID = ?, SlabNo = ?, SlabName = ?, IsActive = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("SlabNo", _sSlabNo);
                cmd.Parameters.AddWithValue("SlabName", _sSlabName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

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
                sSql = "DELETE FROM t_ConsumerPromotionSlab WHERE [ConsumerPromoID]=?";
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
                cmd.CommandText = "SELECT * FROM t_ConsumerPromotionSlab where ConsumerPromoID =?";
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _nSlabID = (int)reader["SlabID"];
                    _sSlabNo = (string)reader["SlabNo"];
                    _sSlabName = (string)reader["SlabName"];
                    _nIsActive = (int)reader["IsActive"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertSlab()
        {
            int nMaxSlabID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SlabID]) FROM t_PromoCPSlab where ConsumerPromoID=" + _nConsumerPromoID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSlabID = 1;
                }
                else
                {
                    nMaxSlabID = Convert.ToInt32(maxID) + 1;
                }
                _nSlabID = nMaxSlabID;

                sSql = "INSERT INTO t_PromoCPSlab (ConsumerPromoID, SlabID, SlabName, IsActive, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("SlabName", _sSlabName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_dCreateDate == null)
                {
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                }
                if (_nCreateUserID == 0 || _nCreateUserID == -1)
                {
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                }

            
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionSlabRatios != null)
                {
                    foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oConsumerPromotionSlabRatios)
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionSlabRatio.SlabID = _nSlabID;
                        oConsumerPromotionSlabRatio.Insert();
                    }
                }
                if (oConsumerPromotionOffers != null)
                {

                    foreach (ConsumerPromotionOffer oConsumerPromotionOffer in oConsumerPromotionOffers)
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionOffer.SlabID = _nSlabID;
                        oConsumerPromotionOffer.Add();
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTPSlab()
        {
            int nMaxSlabID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SlabID]) FROM t_PromoTPSlab where TradePromoID=" + _nConsumerPromoID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSlabID = 1;
                }
                else
                {
                    nMaxSlabID = Convert.ToInt32(maxID) + 1;
                }
                _nSlabID = nMaxSlabID;

                sSql = "INSERT INTO t_PromoTPSlab (TradePromoID, SlabID, SlabName, MinInvoiceQty, IsActive, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("SlabName", _sSlabName);
                cmd.Parameters.AddWithValue("MinInvoiceQty", _nMinInvoiceQty);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionSlabRatios != null)
                {
                    foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oConsumerPromotionSlabRatios)
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionSlabRatio.SlabID = _nSlabID;
                        oConsumerPromotionSlabRatio.InsertTP();
                    }
                }
                if (oConsumerPromotionOffers != null)
                {

                    foreach (ConsumerPromotionOffer oConsumerPromotionOffer in oConsumerPromotionOffers)
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionOffer.SlabID = _nSlabID;
                        oConsumerPromotionOffer.AddTP();
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertTPSlabSecondary()
        {
            int nMaxSlabID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SlabID]) FROM t_PromoTPSlabSecondary where TradePromoID=" + _nConsumerPromoID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSlabID = 1;
                }
                else
                {
                    nMaxSlabID = Convert.ToInt32(maxID) + 1;
                }
                _nSlabID = nMaxSlabID;

                sSql = "INSERT INTO t_PromoTPSlabSecondary (TradePromoID, SlabID, SlabName, MinInvoiceQty, IsActive, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("SlabName", _sSlabName);
                cmd.Parameters.AddWithValue("MinInvoiceQty", _nMinInvoiceQty);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionSlabRatios != null)
                {
                    foreach (ConsumerPromotionSlabRatio oConsumerPromotionSlabRatio in oConsumerPromotionSlabRatios)
                    {
                        oConsumerPromotionSlabRatio.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionSlabRatio.SlabID = _nSlabID;
                        oConsumerPromotionSlabRatio.InsertTPSecoundary();
                    }
                }
                if (oConsumerPromotionOffers != null)
                {

                    foreach (ConsumerPromotionOffer oConsumerPromotionOffer in oConsumerPromotionOffers)
                    {
                        oConsumerPromotionOffer.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionOffer.SlabID = _nSlabID;
                        oConsumerPromotionOffer.AddTPSecoundary();
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class PromoTargetAllocator
    {
        private int _nSalesTypeID;
        private int _nTargetQty;
        private double _fTargetValue;
        private double _fPromoCostVal;
        private double _fNetSalesVal;
        private int _nRegularSalesQty;

        private int _nConsumerPromoID;


        public int SalesTypeID
        {
            get { return _nSalesTypeID; }
            set { _nSalesTypeID = value; }
        }
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }

        }

        public double TargetValue
        {
            get { return _fTargetValue; }
            set { _fTargetValue = value; }

        }

        // <summary>
        // Get set property for DiscountContributorID
        // </summary>
        public double PromoCostVal
        {
            get { return _fPromoCostVal; }
            set { _fPromoCostVal = value; }
        }

        // <summary>
        // Get set property for DiscountContributorName
        // </summary>
        public double NetSalesVal
        {
            get { return _fNetSalesVal; }
            set { _fNetSalesVal = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int RegularSalesQty
        {
            get { return _nRegularSalesQty; }
            set { _nRegularSalesQty = value; }
        }

        public int ConsumerPromoID
        {
            get { return _nConsumerPromoID; }
            set { _nConsumerPromoID = value; }

        }
        private double _fTargetMC;
        public double TargetMC
        {
            get { return _fTargetMC; }
            set { _fTargetMC = value; }

        }
        private int _nProductID;
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }

        }

        public void AddPromoTargetAllocator()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_PromoCPTargetAllocate (ConsumerPromoID,SalesTypeID,TargetQty,TargetValue, PromoCostVal, NetSalesVal, RegularSalesQty,TargetMC, ProductID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("SalesTypeID", _nSalesTypeID);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);
                cmd.Parameters.AddWithValue("TargetValue", _fTargetValue);
                cmd.Parameters.AddWithValue("PromoCostVal", _fPromoCostVal);
                cmd.Parameters.AddWithValue("NetSalesVal", _fNetSalesVal);
                cmd.Parameters.AddWithValue("RegularSalesQty", _nRegularSalesQty);
                cmd.Parameters.AddWithValue("TargetMC", _fTargetMC);
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
    public class ConsumerPromotion : CollectionBase
    {
        public ConsumerPromotionSlab this[int i]
        {
            get { return (ConsumerPromotionSlab)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotionSlab oConsumerPromotionSlab)
        {
            InnerList.Add(oConsumerPromotionSlab);
        }
        private double _ContributionAmount;
        private int _nConsumerPromoID;
        private string _sConsumerPromoNo;
        private string _sConsumerPromoName;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private string _sRemarks;
        private int _nIsActive;
        private object _dUpdateDate;
        private int _nUpdateUserID;
        private int _nStatus;
        private int _nApprovedUserID;
        private object _dApprovedDate;
        private string _sPromotionType;
        private string _sPromotionTypeName;
        private int _nTransferType;
        private int _nOfferType;
        private string _sTableName;

        public string TableName
        {
            get { return _sTableName; }
            set { _sTableName = value; }
        }
        public int OfferType
        {
            get { return _nOfferType; }
            set { _nOfferType = value; }
        }
        
        public int TransferType
        {
            get { return _nTransferType; }
            set { _nTransferType = value; }
        }
        //private ConsumerPromotionOfferDetails oConsumerPromotionOfferDetails;
        //public ConsumerPromotionOfferDetails ConsumerPromotionOfferDetails
        //{
        //    get
        //    {
        //        if (oConsumerPromotionOfferDetails == null)
        //        {
        //            oConsumerPromotionOfferDetails = new ConsumerPromotionOfferDetails();
        //        }
        //        return oConsumerPromotionOfferDetails;
        //    }
        //}
        private SPTypes oSPTypes;
        public SPTypes SPTypes
        {
            get
            {
                if (oSPTypes == null)
                {
                    oSPTypes = new SPTypes();
                }
                return oSPTypes;
            }
        }

        private SPChannels oSPChannels;
        public SPChannels SPChannels
        {
            get
            {
                if (oSPChannels == null)
                {
                    oSPChannels = new SPChannels();
                }
                return oSPChannels;
            }
        }
        private SPWarehouses oSPWarehouses;
        public SPWarehouses SPWarehouses
        {
            get
            {
                if (oSPWarehouses == null)
                {
                    oSPWarehouses = new SPWarehouses();
                }
                return oSPWarehouses;
            }
        }

        private ConsumerPromotionOffers oConsumerPromotionOffers;
        public ConsumerPromotionOffers ConsumerPromotionOffers
        {
            get
            {
                if (oConsumerPromotionOffers == null)
                {
                    oConsumerPromotionOffers = new ConsumerPromotionOffers();
                }
                return oConsumerPromotionOffers;
            }
        }
        private ConsumerPromotionProductFors oConsumerPromotionProductFors;
        public ConsumerPromotionProductFors ConsumerPromotionProductFors
        {
            get
            {
                if (oConsumerPromotionProductFors == null)
                {
                    oConsumerPromotionProductFors = new ConsumerPromotionProductFors();
                }
                return oConsumerPromotionProductFors;
            }
        }

        public double ContributionAmount
        {
            get { return _ContributionAmount; }
            set { _ContributionAmount = value; }
        }
        private int _nIsApplicableOnAllSKU;
        public int IsApplicableOnAllSKU
        {
            get { return _nIsApplicableOnAllSKU; }
            set { _nIsApplicableOnAllSKU = value; }
        }
        private string _sApplicableProductID;
        public string ApplicableProductID
        {
            get { return _sApplicableProductID; }
            set { _sApplicableProductID = value; }
        }
        // <summary>
        // Get set property for ConsumerPromoID
        // </summary>
        public int ConsumerPromoID
        {
            get { return _nConsumerPromoID; }
            set { _nConsumerPromoID = value; }
        }
        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        private string _sCPSimpleWarehouse;
        public string CPSimpleWarehouse
        {
            get { return _sCPSimpleWarehouse; }
            set { _sCPSimpleWarehouse = value; }
        }
        // <summary>
        // Get set property for ConsumerPromoNo
        // </summary>
        public string ConsumerPromoNo
        {
            get { return _sConsumerPromoNo; }
            set { _sConsumerPromoNo = value; }
        }

        public string PromotionType
        {
            get { return _sPromotionType; }
            set { _sPromotionType = value; }
        }

        

        // <summary>
        // Get set property for ConsumerPromoName
        // </summary>
        public string ConsumerPromoName
        {
            get { return _sConsumerPromoName; }
            set { _sConsumerPromoName = value.Trim(); }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
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
        private string _sPromoTable;
        public string PromoTable
        {
            get { return _sPromoTable; }
            set { _sPromoTable = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        private string _sIsPromoDisableFromOnline;
        public string IsPromoDisableFromOnline
        {
            get { return _sIsPromoDisableFromOnline; }
            set { _sIsPromoDisableFromOnline = value.Trim(); }
        }
        private string _sCreateUserName;
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value.Trim(); }
        }
        private string _sApprovedUserName;
        public string ApprovedUserName
        {
            get { return _sApprovedUserName; }
            set { _sApprovedUserName = value.Trim(); }
        }

        public string PromotionTypeName
        {
            get { return _sPromotionTypeName; }
            set { _sPromotionTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        private int _nIsApplicableOnOfferPrice;
        public int IsApplicableOnOfferPrice
        {
            get { return _nIsApplicableOnOfferPrice; }
            set { _nIsApplicableOnOfferPrice = value; }
        }
        // <summary>
        // Get set property for ApprovedUserID
        // </summary>
        public int ApprovedUserID
        {
            get { return _nApprovedUserID; }
            set { _nApprovedUserID = value; }
        }

        // <summary>
        // Get set property for ApprovedDate
        // </summary>
        public object ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
        }

        public void Add()
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ConsumerPromoID]) FROM t_ConsumerPromotion";
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
                sSql = "INSERT INTO t_ConsumerPromotion (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddPromoDisableFromOnline()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO TELADDDB.DBO.t_SalesPromoDisableforEcommerce (SalesPromotionNo,Company,DisableDate) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("Company", "TEL");
                cmd.Parameters.AddWithValue("DisableDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ChangeIsActiveStatusConsumerPromotion(int nIsActive,string sPromoTable)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nUserID = Utility.UserId;
            DateTime dUpdateDate = DateTime.Now;
            string sSql = "";
            try
            {
                if (sPromoTable == "t_PromoCP")
                    sSql = "Update t_PromoCP set IsActive= ?, UpdateDate = ?, UpdateUserID = ? WHERE ConsumerPromoID=" + _nConsumerPromoID + "";
                else sSql = "Update t_PromoCPSimple set IsActive= ?, UpdateDate = ?, UpdateUserID = ? WHERE CPSimpleID=" + _nConsumerPromoID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateDateCPSimple()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nUserID = Utility.UserId;
            DateTime dUpdateDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_PromoCPSimple set CPSimpleName=?, IsActive=?,ToDate= ?, UpdateDate = ?, UpdateUserID = ? WHERE CPSimpleID=" + _nConsumerPromoID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSimpleName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                //cmd.Parameters.AddWithValue("CPSimpleID", _nConsumerPromoID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ChangeIsActiveStatusScratchCardOffer(int nIsActive)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nUserID = Utility.UserId;
            DateTime dUpdateDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_ScratchCardOffer set IsActive= ?, UpdateDate = ?, UpdateUserID = ? WHERE ScratchCardOfferID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
                cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Insert(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sTableName == "t_PromoCP")
                {
                    sSql = "INSERT INTO t_PromoCP (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                }
                else if (sTableName == "t_PromoTP")
                {
                    sSql = "INSERT INTO t_PromoTP (TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (sTableName == "t_PromoCP")
                {
                    cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                    cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
                    cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                }
                else if (sTableName == "t_PromoTP")
                {
                    cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                    cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
                    cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
                }

                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_dUpdateDate != null)
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                else cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_nUpdateUserID != -1)
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                else cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_nApprovedUserID != -1)
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                else cmd.Parameters.AddWithValue("ApprovedUserID", null);
                if (_dApprovedDate != null)
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                else cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSalesPromo(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sTableName == "t_PromoCP")
                {
                    sSql = "UPDATE t_PromoCP SET ConsumerPromoNo = ?, ConsumerPromoName = ?, FromDate = ?, ToDate = ?, Remarks = ?,  IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ?,IsApplicableOnOfferPrice = ? WHERE ConsumerPromoID = ?";
                }
                else
                {
                    sSql = "UPDATE t_PromoTP SET TradePromoNo = ?, TradePromoName = ?, FromDate = ?, ToDate = ?, Remarks = ?,  IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ?,IsApplicableOnOfferPrice = ? WHERE TradePromoID = ?";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (sTableName == "t_PromoCP")
                {
                    cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
                    cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                }
                else if (sTableName == "t_PromoTP")
                {
                    cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
                    cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
                }
                
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_dUpdateDate != null)
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                else cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_nUpdateUserID != -1)
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                else cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_nApprovedUserID != -1)
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                else cmd.Parameters.AddWithValue("ApprovedUserID", null);
                if (_dApprovedDate != null)
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                else cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);
                
                if (sTableName == "t_PromoCP")
                {
                    cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

                }
                else if (sTableName == "t_PromoTP")
                {
                    cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);

                }

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
                sSql = "UPDATE t_ConsumerPromotion SET ConsumerPromoNo = ?, ConsumerPromoName = ?, FromDate = ?, ToDate = ?, CreateDate = ?, CreateUserID = ?, Remarks = ?, IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

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
                sSql = "DELETE FROM t_ConsumerPromotion WHERE [ConsumerPromoID]=?";
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
        public void DeleteDisablePromo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM TELADDDB.DBO.t_SalesPromoDisableforEcommerce WHERE [SalesPromotionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionNo", _sConsumerPromoNo);
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
                cmd.CommandText = "SELECT * FROM t_ConsumerPromotion where ConsumerPromoID =?";
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _sConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    _sConsumerPromoName = (string)reader["ConsumerPromoName"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _sRemarks = (string)reader["Remarks"];
                    _nIsActive = (int)reader["IsActive"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nStatus = (int)reader["Status"];
                    _nApprovedUserID = (int)reader["ApprovedUserID"];
                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetOfferDetails(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Select * From  " +
                                "(  " +
                                "Select ConsumerPromoID,SlabID,OfferID,SlabName,OfferName,  " +
                                "case OfferType when 0 then ProductName+':'+CAST(OfferQty as varchar(10))+'Pcs' else '' end as OfferProduct,  " +
                                "case OfferType when 1 then Discount else 0 end as OfferAmount,  " +
                                "case OfferType when 2 then Discount else 0 end as OfferPercentage  " +
                                "From   " +
                                "(Select a.*,OfferName,SlabName From t_ConsumerPromotionOfferDetail a,t_ConsumerPromotionOffer b,t_ConsumerPromotionSlab c  " +
                                "where a.ConsumerPromoID=b.ConsumerPromoID and a.SlabID=b.SlabID and a.OfferID=b.OfferID   " +
                                "and a.ConsumerPromoID=c.ConsumerPromoID and a.SlabID=c.SlabID   " +
                                "and b.ConsumerPromoID=c.ConsumerPromoID and b.SlabID=c.SlabID   " +
                                "and b.IsActive=1) a  " +
                                "left Outer Join   " +
                                "(Select ProductID,ProductCode,ProductName From t_Product ) b  " +
                                "on a.OfferProductID=b.ProductID  " +
                                ") Main where ConsumerPromoID=" + nConsumerPromoID + " order by SlabID,OfferID";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionOfferDetail oItem = new ConsumerPromotionOfferDetail();

                    oItem.SlabName = (reader["SlabName"].ToString());
                    oItem.OfferName = (reader["OfferName"].ToString());
                    oItem.OfferProduct = (reader["OfferProduct"].ToString());
                    oItem.OfferAmount = Convert.ToDouble(reader["OfferAmount"].ToString());
                    oItem.OfferPercentage = Convert.ToDouble(reader["OfferPercentage"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPromoInfoForReport(int nConsumerPromoID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From " +
                                "( " +
                                "Select a.*, isnull(b.UserName, '') ApprovedUserName, isnull(c.Amount, 0) as ContributionAmount " +
                                "from " +
                                "( " +
                                "SELECT a.*, UserName as CreateUserName " +
                                "FROM t_PromoCP a, t_User b " +
                                "where a.CreateUserID = b.UserID " +
                                ") a " +
                                "left outer join " +
                                "( " +
                                "Select * From t_User " +
                                ") b " +
                                "on a.ApprovedUserID = b.UserID " +
                                "left outer join " +
                                "( " +
                                "Select ConsumerPromoID, sum(Amount) Amount From t_PromoCPDiscountContribution " +
                                "group by ConsumerPromoID " +
                                ") c " +
                                "on a.ConsumerPromoID = c.ConsumerPromoID " +
                                ") a where ConsumerPromoID = " + nConsumerPromoID + "";

                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _sConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    _sConsumerPromoName = (string)reader["ConsumerPromoName"];
                    _nIsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    _sCreateUserName = (string)reader["CreateUserName"];
                    _sApprovedUserName = (string)reader["ApprovedUserName"];
                    _ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _sRemarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        _sRemarks ="";

                    }
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        _nApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        _nApprovedUserID = -1;

                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        _dApprovedDate = "";
                    }
                    nCount++;
                }

                //GetOfferDetails(nConsumerPromoID);
                GetPromoProductDetail(nConsumerPromoID);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTPInfoForReport(int nConsumerPromoID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From " +
                                "( " +
                                "Select a.*, isnull(b.UserName, '') ApprovedUserName, isnull(c.Amount, 0) as ContributionAmount " +
                                "from " +
                                "( " +
                                "SELECT a.*, UserName as CreateUserName " +
                                "FROM t_PromoTP a, t_User b " +
                                "where a.CreateUserID = b.UserID " +
                                ") a " +
                                "left outer join " +
                                "( " +
                                "Select * From t_User " +
                                ") b " +
                                "on a.ApprovedUserID = b.UserID " +
                                "left outer join " +
                                "( " +
                                "Select TradePromoID, sum(Amount) Amount From t_PromoTPDiscountContribution " +
                                "group by TradePromoID " +
                                ") c " +
                                "on a.TradePromoID = c.TradePromoID " +
                                ") a where TradePromoID = " + nConsumerPromoID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["TradePromoID"];
                    _sConsumerPromoNo = (string)reader["TradePromoNo"];
                    _nIsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    _sConsumerPromoName = (string)reader["TradePromoName"];
                    _sCreateUserName = (string)reader["CreateUserName"];
                    _sApprovedUserName = (string)reader["ApprovedUserName"];
                    _ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _sRemarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        _sRemarks = "";

                    }
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        _nApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        _nApprovedUserID = -1;

                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        _dApprovedDate = "";
                    }
                    nCount++;
                }

                //GetOfferDetails(nConsumerPromoID);
                GetTPProductDetail(nConsumerPromoID);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTPInfoForReportSecoundary(int nConsumerPromoID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From " +
                                "( " +
                                "Select a.*, isnull(b.UserName, '') ApprovedUserName, isnull(c.Amount, 0) as ContributionAmount " +
                                "from " +
                                "( " +
                                "SELECT a.*, UserName as CreateUserName " +
                                "FROM t_PromoTPSecondary a, t_User b " +
                                "where a.CreateUserID = b.UserID " +
                                ") a " +
                                "left outer join " +
                                "( " +
                                "Select * From t_User " +
                                ") b " +
                                "on a.ApprovedUserID = b.UserID " +
                                "left outer join " +
                                "( " +
                                "Select TradePromoID, sum(Amount) Amount From t_PromoTPDiscountContributionSecondary " +
                                "group by TradePromoID " +
                                ") c " +
                                "on a.TradePromoID = c.TradePromoID " +
                                ") a where TradePromoID = " + nConsumerPromoID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["TradePromoID"];
                    _sConsumerPromoNo = (string)reader["TradePromoNo"];
                    _nIsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    _sConsumerPromoName = (string)reader["TradePromoName"];
                    _sCreateUserName = (string)reader["CreateUserName"];
                    _sApprovedUserName = (string)reader["ApprovedUserName"];
                    _ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _sRemarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        _sRemarks = "";

                    }
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        _nApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        _nApprovedUserID = -1;

                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        _dApprovedDate = "";
                    }
                    nCount++;
                }

                //GetOfferDetails(nConsumerPromoID);
                GetTPProductDetailSecondary(nConsumerPromoID);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertConsumerPromotion(DSPromotionContribution _oDSPromotionContribution)
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ConsumerPromoID]) FROM t_PromoCP";
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
                _sConsumerPromoNo = "CP-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

                sSql = "INSERT INTO t_PromoCP (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionProductFors != null)
                {
                    foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionProductFor.Insert();
                    }
                }
                if (oSPChannels != null)
                {
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nConsumerPromoID;
                        oSPChannel.InsertConsumerPromoChannel();
                    }
                }
                if (oSPWarehouses != null)
                {
                    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                    {
                        oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
                        oSPWarehouse.InsertConsumerPromoWarehouse();
                    }
                }
                if (oSPTypes != null)
                {
                    foreach (SPType oSPType in oSPTypes)
                    {
                        oSPType.SalesPromotionID = _nConsumerPromoID;
                        oSPType.InsertConsumerPromotionType();
                    }
                }
                foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
                    oSalesPromotionSlab.InsertSlab();
                }

                foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
                {
                    PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
                    oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
                    oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
                    oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
                    oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
                    if (oPromoDiscountContributor.Amount > 0)
                    {
                        oPromoDiscountContributor.AddCPDiscountContributionNew();
                    }

                }
                //if (oProductGroups != null)
                //{
                //    foreach (ProductGroup oProductGroup in oProductGroups)
                //    {
                //        SPProductGroup oSPProductGroup = new SPProductGroup();
                //        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
                //        oSPProductGroup.ProductGroupType = oProductGroup.PdtGroupType;
                //        oSPProductGroup.ProductGroupID = oProductGroup.PdtGroupID;
                //        oSPProductGroup.DiscountType = _DiscountType;
                //        oSPProductGroup.DiscountPercentage = _DiscountPercent;
                //        oSPProductGroup.Insert();
                //    }
                //}

                //Showrooms _oShowrooms = new Showrooms();
                //_oShowrooms.Refresh();

                //foreach (Showroom oShowroom in _oShowrooms)
                //{
                //    DataTran oDataTran = new DataTran();

                //    oDataTran.TableName = "t_SalesPromo";
                //    oDataTran.DataID = _nSalesPromotionID;
                //    oDataTran.WarehouseID = oShowroom.WarehouseID;
                //    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                //    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //    oDataTran.BatchNo = 0;

                //    oDataTran.AddForTDPOS();
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertConsumerPromotion(DSPromotionContribution _oDSPromotionContribution, DSPromotionAllocate _oDSPromotionAllocate)
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ConsumerPromoID]) FROM t_PromoCP";
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
                _sConsumerPromoNo = "CP-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

                sSql = "INSERT INTO t_PromoCP (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionProductFors != null)
                {
                    foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionProductFor.Insert();
                    }
                }
                if (oSPChannels != null)
                {
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nConsumerPromoID;
                        oSPChannel.InsertConsumerPromoChannel();
                    }
                }
                if (oSPWarehouses != null)
                {
                    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                    {
                        oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
                        oSPWarehouse.InsertConsumerPromoWarehouse();
                    }
                }
                if (oSPTypes != null)
                {
                    foreach (SPType oSPType in oSPTypes)
                    {
                        oSPType.SalesPromotionID = _nConsumerPromoID;
                        oSPType.InsertConsumerPromotionType();
                    }
                }
                foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
                    oSalesPromotionSlab.InsertSlab();
                }

                foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
                {
                    PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
                    oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
                    oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
                    oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
                    oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
                    if (oPromoDiscountContributor.Amount > 0)
                    {
                        oPromoDiscountContributor.AddCPDiscountContributionNew();
                    }

                }

                foreach (DSPromotionAllocate.PromotionAllocateRow oPromotionAllocateRow in _oDSPromotionAllocate.PromotionAllocate)
                {
                    PromoTargetAllocator oPromoTargetAllocator = new PromoTargetAllocator();
                    oPromoTargetAllocator.ConsumerPromoID = _nConsumerPromoID;
                    oPromoTargetAllocator.SalesTypeID = oPromotionAllocateRow.SalesTypeID;
                    oPromoTargetAllocator.TargetQty = oPromotionAllocateRow.TargetQty;
                    oPromoTargetAllocator.TargetValue = oPromotionAllocateRow.TargetValue;
                    oPromoTargetAllocator.PromoCostVal = oPromotionAllocateRow.PromoCostVal;
                    oPromoTargetAllocator.NetSalesVal = oPromotionAllocateRow.NetSalesVal;
                    oPromoTargetAllocator.RegularSalesQty = oPromotionAllocateRow.RegularSalesQty;
                    oPromoTargetAllocator.TargetMC = oPromotionAllocateRow.TargetMC;
                    oPromoTargetAllocator.ProductID = oPromotionAllocateRow.ProductID;

                    oPromoTargetAllocator.AddPromoTargetAllocator();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertSPScratchCardOffer()
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ScratchCardOfferID]) FROM t_ScratchCardOffer";
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
                _sConsumerPromoNo = "SC-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

                sSql = "INSERT INTO t_ScratchCardOffer (ScratchCardOfferID,	ScratchCardOfferCode,	ScratchCardOfferName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,OfferType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("ScratchCardOfferCode", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("ScratchCardOfferName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionProductFors != null)
                {
                    foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionProductFor.InsertSC();
                    }
                }
                if (oSPChannels != null)
                {
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nConsumerPromoID;
                        oSPChannel.InsertScratchCardOfferChannel();
                    }
                }
                if (oSPWarehouses != null)
                {
                    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                    {
                        oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
                        oSPWarehouse.InsertScratchCardOfferWarehouse();
                    }
                }
               
               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ChangeIsActiveStatus(int nIsActive)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nUserID = Utility.UserId;
            DateTime dUpdateDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_PromoTP set IsActive= ?,UpdateUserID = ?, UpdateDate = ? WHERE TradePromoID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ChangeIsActiveStatusSecondary(int nIsActive)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nUserID = Utility.UserId;
            DateTime dUpdateDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_PromoTPSecondary set IsActive= ?,UpdateUserID = ?, UpdateDate = ? WHERE TradePromoID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertTradePromotion(DSPromotionContribution _oDSPromotionContribution)
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TradePromoID]) FROM t_PromoTP";
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
                _sConsumerPromoNo = "TP-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

                sSql = "INSERT INTO t_PromoTP (TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate, IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionProductFors != null)
                {
                    foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionProductFor.InsertTP();
                    }
                }
                if (oSPChannels != null)
                {
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nConsumerPromoID;
                        oSPChannel.InsertTPChannel();
                    }
                }
                if (oSPWarehouses != null)
                {
                    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                    {
                        oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
                        oSPWarehouse.InsertTPWarehouse();
                    }
                }
                if (oSPTypes != null)
                {
                    foreach (SPType oSPType in oSPTypes)
                    {
                        oSPType.SalesPromotionID = _nConsumerPromoID;
                        oSPType.InsertTPType();
                    }
                }

                foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
                    oSalesPromotionSlab.InsertTPSlab();
                }

                try
                {
                    foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
                    {
                        PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
                        oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
                        oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
                        oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
                        oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
                        if (oPromoDiscountContributor.Amount > 0)
                        {
                            oPromoDiscountContributor.AddTPDiscountContributionNew();
                        }

                    }
                }
                catch
                {

                }
                //if (oProductGroups != null)
                //{
                //    foreach (ProductGroup oProductGroup in oProductGroups)
                //    {
                //        SPProductGroup oSPProductGroup = new SPProductGroup();
                //        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
                //        oSPProductGroup.ProductGroupType = oProductGroup.PdtGroupType;
                //        oSPProductGroup.ProductGroupID = oProductGroup.PdtGroupID;
                //        oSPProductGroup.DiscountType = _DiscountType;
                //        oSPProductGroup.DiscountPercentage = _DiscountPercent;
                //        oSPProductGroup.Insert();
                //    }
                //}

                //Showrooms _oShowrooms = new Showrooms();
                //_oShowrooms.Refresh();

                //foreach (Showroom oShowroom in _oShowrooms)
                //{
                //    DataTran oDataTran = new DataTran();

                //    oDataTran.TableName = "t_SalesPromo";
                //    oDataTran.DataID = _nSalesPromotionID;
                //    oDataTran.WarehouseID = oShowroom.WarehouseID;
                //    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                //    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //    oDataTran.BatchNo = 0;

                //    oDataTran.AddForTDPOS();
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertTradePromotionSecondary(DSPromotionContribution _oDSPromotionContribution)
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TradePromoID]) FROM t_PromoTPSecondary";
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
                _sConsumerPromoNo = "TPS-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

                sSql = "INSERT INTO t_PromoTPSecondary (TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate, IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
                cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oConsumerPromotionProductFors != null)
                {
                    foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
                    {
                        oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
                        oConsumerPromotionProductFor.InsertTPSecondary();
                    }
                }
                if (oSPChannels != null)
                {
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nConsumerPromoID;
                        oSPChannel.InsertTPChannelSecondary();
                    }
                }
                //if (oSPWarehouses != null)
                //{
                //    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                //    {
                //        oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
                //        oSPWarehouse.InsertTPWarehouse();
                //    }
                //}
                if (oSPTypes != null)
                {
                    foreach (SPType oSPType in oSPTypes)
                    {
                        oSPType.SalesPromotionID = _nConsumerPromoID;
                        oSPType.InsertTPTypeSecondary();
                    }
                }

                foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
                    oSalesPromotionSlab.InsertTPSlabSecondary();
                }

                try
                {
                    foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
                    {
                        PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
                        oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
                        oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
                        oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
                        oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
                        if (oPromoDiscountContributor.Amount > 0)
                        {
                            oPromoDiscountContributor.AddTPDiscountContributionSecoundary();
                        }

                    }
                }
                catch
                {

                }
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPromoProductDetail1(int nConsumerPromoID, DateTime dtFromDate, string sCompany)
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
                    oConsumerPromotionProductFor.TGTQty = (int)reader["TargetQty"];

                    oConsumerPromotionProductFor.Month01SalesQty = (int)reader["Month01SalesQty"];
                    oConsumerPromotionProductFor.Month01NetSale = (double)reader["Month01NetSale"];

                    oConsumerPromotionProductFor.Month02SalesQty = (int)reader["Month02SalesQty"];
                    oConsumerPromotionProductFor.Month02NetSale = (double)reader["Month02NetSale"];

                    oConsumerPromotionProductFor.Month03SalesQty = (int)reader["Month03SalesQty"];
                    oConsumerPromotionProductFor.Month03NetSale = (double)reader["Month03NetSale"];

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

        public void GetPromoProductDetail(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From  " +
                        "(  " +
                        "Select ConsumerPromoID,'['+ProductCode+']'+ ProductName as ProductName,TargetQty, ISNULL(TargetValue,0) TargetValue,ISNULL(PromoCostVal,0) PromoCostVal, ISNULL(NetSalesVal,0) NetSalesVal,RegularSalesQty,DiscountRatio   " +
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
                    ConsumerPromotionSlab oConsumerPromotionProductFor = new ConsumerPromotionSlab();
                    oConsumerPromotionProductFor.ProductName = (string)reader["ProductName"];
                    oConsumerPromotionProductFor.TargetQty = (int)reader["TargetQty"];
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
        public void GetTPProductDetail(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,PdtGroupName as ProductGroupName,BrandDesc as BrandName " +
                        "From t_PromoTPProductFor a,t_Brand b, t_ProductGroup c " +
                        "where a.BrandID = b.BrandID and a.ProductGroupID = c.PdtGroupID and GroupTypeID = 3 " +
                        "and TradePromoID = "+ nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    ConsumerPromotionSlab oConsumerPromotionProductFor = new ConsumerPromotionSlab();
                    oConsumerPromotionProductFor.ProductGroupName = (string)reader["ProductGroupName"];
                    oConsumerPromotionProductFor.BrandName = (string)reader["BrandName"];
                    oConsumerPromotionProductFor.TargetQty = (int)reader["TargetQty"];
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

        public void GetTPProductDetailSecondary(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,PdtGroupName as ProductGroupName,BrandDesc as BrandName " +
                        "From t_PromoTPProductForSecondary a,t_Brand b, t_ProductGroup c " +
                        "where a.BrandID = b.BrandID and a.ProductGroupID = c.PdtGroupID and GroupTypeID = 3 " +
                        "and TradePromoID = " + nConsumerPromoID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ConsumerPromotionSlab oConsumerPromotionProductFor = new ConsumerPromotionSlab();
                    oConsumerPromotionProductFor.ProductGroupName = (string)reader["ProductGroupName"];
                    oConsumerPromotionProductFor.BrandName = (string)reader["BrandName"];
                    oConsumerPromotionProductFor.TargetQty = (int)reader["TargetQty"];
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

        public void UpdateStatus(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sTableName == "t_PromoCP")
                    sSql = "UPDATE t_PromoCP SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE ConsumerPromoID = "+ _nConsumerPromoID + "";
                else if (sTableName == "t_PromoTP") sSql = "UPDATE t_PromoTP SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE TradePromoID = " + _nConsumerPromoID + "";
                else if (sTableName == "t_PromoCPSimple") sSql = "UPDATE t_PromoCPSimple SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE CPSimpleID = " + _nConsumerPromoID + "";
                else if (sTableName == "t_PromoTPSecondary") sSql = "UPDATE t_PromoTPSecondary SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE TradePromoID = " + _nConsumerPromoID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdatePromoTP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoTP SET TradePromoName = ?, FromDate = ?, ToDate = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE TradePromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdatePromoCP()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoCP SET ConsumerPromoName = ?, FromDate = ?, ToDate = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE ConsumerPromoID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateScratchCardOffer(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sTableName == "t_ScratchCardOffer")
                {
                    sSql = "UPDATE t_ScratchCardOffer SET ScratchCardOfferCode = ?, ScratchCardOfferName = ?, FromDate = ?, ToDate = ?, Remarks = ?,  IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ?,OfferType = ? WHERE ScratchCardOfferID = ?";
                }
               
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (sTableName == "t_ScratchCardOffer")
                {
                    cmd.Parameters.AddWithValue("ScratchCardOfferCode", _sConsumerPromoNo);
                    cmd.Parameters.AddWithValue("ScratchCardOfferName", _sConsumerPromoName);
                }
               

                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_dUpdateDate != null)
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                else cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_nUpdateUserID != -1)
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                else cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_nApprovedUserID != -1)
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                else cmd.Parameters.AddWithValue("ApprovedUserID", null);
                if (_dApprovedDate != null)
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                else cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);

                if (sTableName == "t_ScratchCardOffer")
                {
                    cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);

                }
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertScratchCardOffer(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sTableName == "t_ScratchCardOffer")
                {
                    sSql = "INSERT INTO t_ScratchCardOffer (ScratchCardOfferID, ScratchCardOfferCode, ScratchCardOfferName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,OfferType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                }
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (sTableName == "t_ScratchCardOffer")
                {
                    cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);
                    cmd.Parameters.AddWithValue("ScratchCardOfferCode", _sConsumerPromoNo);
                    cmd.Parameters.AddWithValue("ScratchCardOfferName", _sConsumerPromoName);
                }
                

                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_dUpdateDate != null)
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                else cmd.Parameters.AddWithValue("UpdateDate", null);
                if (_nUpdateUserID != -1)
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                else cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_nApprovedUserID != -1)
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                else cmd.Parameters.AddWithValue("ApprovedUserID", null);
                if (_dApprovedDate != null)
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                else cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("OfferType", _nOfferType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusSC(string sTableName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
               
                sSql = "UPDATE t_ScratchCardOffer SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE ScratchCardOfferID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshCPNo(string sConsumerPromoNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            IDataReader reader;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoCP where ConsumerPromoNo =?";
                cmd.Parameters.AddWithValue("ConsumerPromoNo", sConsumerPromoNo);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerPromoID = (int)reader["ConsumerPromoID"];
                    _sTableName = "t_PromoCP";
                    nCount++;
                }
                reader.Close();

                if(nCount==0)
                {
                    cmd.CommandText = "SELECT * FROM t_PromoCPSimple where CPSimpleNo =?";
                    cmd.Parameters.AddWithValue("CPSimpleNo", sConsumerPromoNo);
                    cmd.CommandType = CommandType.Text;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        _nConsumerPromoID = (int)reader["CPSimpleID"];
                        _sTableName = "t_PromoCPSimple";
                        nCount++;
                    }
                    reader.Close();
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddNotApplicableToDms()
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_DMSPromoNotApplicableToDms (PromoId,TableName) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PromoId", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("TableName", _sTableName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteNotApplicableToDms()
        {
            int nMaxConsumerPromoID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "delete from t_DMSPromoNotApplicableToDms where PromoId=? and TableName=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PromoId", _nConsumerPromoID);
                cmd.Parameters.AddWithValue("TableName", _sTableName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class ConsumerPromotions : CollectionBase
    {
        public ConsumerPromotion this[int i]
        {
            get { return (ConsumerPromotion)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ConsumerPromotion oConsumerPromotion)
        {
            InnerList.Add(oConsumerPromotion);
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
            string sSql = "SELECT * FROM t_ConsumerPromotion";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    oConsumerPromotion.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oConsumerPromotion.UpdateUserID = (int)reader["UpdateUserID"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromotionList(DateTime dFromDate, DateTime dToDate, int nIsActive, int nStatus, string sPromoNo, string sPromoName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = @"Select a.*,B.UserFullName as CreateUserName,
                    isnull(c.UserFullName, '') as ApprovedUserName,
                    case when d.SalesPromotionNo is null then 'No' else 'Yes' end
                    as IsPromoDisableFromOnline
                    From
                    (
                    Select ConsumerPromoID, ConsumerPromoNo,IsActive,
                    ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID,
                    ApprovedUserID, ApprovedDate, Status, Remarks, 't_PromoCP' as PromoTable,'' as CPSimpleWarehouse
                    From t_PromoCP
                    Union All
                    Select CPSimpleID, CPSimpleNo,IsActive,
                    CPSimpleName, FromDate, ToDate, CreateDate, CreateUserID,
                    ApprovedUserID, ApprovedDate, Status, Remarks, 't_PromoCPSimple' as PromoTable,Warehouse as CPSimpleWarehouse
                    From t_PromoCPSimple
                    ) a
                    join t_User b on a.CreateUserID = b.UserID
                    left outer join t_User c on a.ApprovedUserID = c.UserID
                    Left outer join TELADDDB.DBO.t_SalesPromoDisableforEcommerce d on a.ConsumerPromoNo = d.SalesPromotionNo 
                    where a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate< '" + dToDate + "' ";

            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sPromoNo != "")
            {
                sSql = sSql + " AND ConsumerPromoNo like '%" + sPromoNo + "%'";
            }
            if (sPromoName != "")
            {
                sSql = sSql + " AND ConsumerPromoName like '%" + sPromoName + "%'";
            }
            sSql = sSql + " Order by a.CreateDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotion.CPSimpleWarehouse = (string)reader["CPSimpleWarehouse"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    oConsumerPromotion.CreateUserName = (string)reader["CreateUserName"];
                    oConsumerPromotion.IsPromoDisableFromOnline = (string)reader["IsPromoDisableFromOnline"];
                    oConsumerPromotion.ApprovedUserName = (string)reader["ApprovedUserName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotion.PromoTable = (string)reader["PromoTable"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedUserID = -1;

                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedDate = "";

                    }
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoTPList(DateTime dFromDate, DateTime dToDate, int nIsActive, int nStatus, string sPromoNo, string sPromoName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "SELECT * FROM t_PromoTP where CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";

            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sPromoNo != "")
            {
                sSql = sSql + " AND TradePromoNo like '%" + sPromoNo + "%'";
            }
            if (sPromoName != "")
            {
                sSql = sSql + " AND TradePromoName like '%" + sPromoName + "%'";
            }
            sSql = sSql + " Order by CreateDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["TradePromoID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["TradePromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["TradePromoName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    //oConsumerPromotion.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //oConsumerPromotion.UpdateUserID = (int)reader["UpdateUserID"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    //oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    //oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPromoTPListSecoundary(DateTime dFromDate, DateTime dToDate, int nIsActive, int nStatus, string sPromoNo, string sPromoName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "SELECT * FROM t_PromoTPSecondary where CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";

            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sPromoNo != "")
            {
                sSql = sSql + " AND TradePromoNo like '%" + sPromoNo + "%'";
            }
            if (sPromoName != "")
            {
                sSql = sSql + " AND TradePromoName like '%" + sPromoName + "%'";
            }
            sSql = sSql + " Order by CreateDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["TradePromoID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["TradePromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["TradePromoName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    //oConsumerPromotion.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //oConsumerPromotion.UpdateUserID = (int)reader["UpdateUserID"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    //oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    //oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCurrentPromotionList(string sPromoNo, string sPromoName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select* From " +
                    "( " +
                    "Select a.*, 'CP' as Type " +
                    "From t_PromoCP a, t_PromoCPWarehouse b, t_ThisSystem c " +
                    "where IsActive = 1 and Status = 1 and a.ConsumerPromoID = b.ConsumerPromoID " +
                    "and b.WarehouseID = c.WarehouseID and c.OperationDate between FromDate and ToDate " +
                    "Union All " +
                    "Select a.*, 'TP' as Type " +
                    "From t_PromoTP a, t_PromoTPWarehouse b, t_ThisSystem c " +
                    "where IsActive = 1 and Status = 1 and a.TradePromoID = b.TradePromoID " +
                    "and b.WarehouseID = c.WarehouseID and c.OperationDate between FromDate and ToDate " +
                    ") Main where 1=1";
            }


            if (sPromoNo != "")
            {
                sSql = sSql + " AND ConsumerPromoNo like '%" + sPromoNo + "%'";
            }
            if (sPromoName != "")
            {
                sSql = sSql + " AND ConsumerPromoName like '%" + sPromoName + "%'";
            }

            sSql = sSql + " Order by Type Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotion.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    oConsumerPromotion.PromotionType = (string)reader["Type"];
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCurrentPromotionListRT(string sPromoNo, string sPromoName,int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select* From " +
                    "( " +
                    "Select a.*, 'CP' as Type " +
                    "From t_PromoCP a, t_PromoCPWarehouse b " +
                    "where IsActive = 1 and Status = 1 and a.ConsumerPromoID = b.ConsumerPromoID " +
                    "and WarehouseID="+ nWHID + " and cast(getdate() as Date) between FromDate and ToDate " +
                    "Union All " +
                    "Select a.*, 'TP' as Type " +
                    "From t_PromoTP a, t_PromoTPWarehouse b " +
                    "where IsActive = 1 and Status = 1 and a.TradePromoID = b.TradePromoID " +
                    "and WarehouseID=" + nWHID + " and cast(getdate() as Date) between FromDate and ToDate " +
                    ") Main where 1=1";
            }


            if (sPromoNo != "")
            {
                sSql = sSql + " AND ConsumerPromoNo like '%" + sPromoNo + "%'";
            }
            if (sPromoName != "")
            {
                sSql = sSql + " AND ConsumerPromoName like '%" + sPromoName + "%'";
            }

            sSql = sSql + " Order by Type Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotion.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    oConsumerPromotion.PromotionType = (string)reader["Type"];
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSalesPromoByWH(int nWarehouseID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "Select b.*, TransferType From t_DataTransfer a,t_PromoCP b  " +
                                "where TableName = 't_PromoCP' and a.DataID = b.ConsumerPromoID " +
                                "and WarehouseID = " + nWarehouseID + " and IsDownload = " + (int)Dictionary.IsDownload.No + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "Select b.*, TransferType From t_DataTransfer a,t_PromoTP b  " +
                    "where TableName = 't_PromoTP' and a.DataID = b.TradePromoID  " +
                    "and WarehouseID = " + nWarehouseID + " and IsDownload = " + (int)Dictionary.IsDownload.No + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();

                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                        oConsumerPromotion.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                        oConsumerPromotion.ConsumerPromoName = (string)reader["ConsumerPromoName"];


                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotion.ConsumerPromoNo = (string)reader["TradePromoNo"];
                        oConsumerPromotion.ConsumerPromoName = (string)reader["TradePromoName"];



                    }
                    oConsumerPromotion.IsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
                    oConsumerPromotion.TransferType = Convert.ToInt32(reader["TransferType"]);
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oConsumerPromotion.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.UpdateDate = null;
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oConsumerPromotion.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.UpdateUserID = -1;
                    }
                    oConsumerPromotion.Status = (int)reader["Status"];
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedDate = null;
                    }
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedUserID = -1;
                    }
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoWHByPromoID(int nPromoID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "Select * From t_PromoCPWarehouse where ConsumerPromoID=" + nPromoID + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "Select * From t_PromoTPWarehouse where TradePromoID=" + nPromoID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();

                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["TradePromoID"];
                    }
                    oConsumerPromotion.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoWHByPromoIDWeb(string sPromoID, string sTableName,int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "Select * From t_PromoCPWarehouse where ConsumerPromoID in (" + sPromoID + ") and WarehouseID=" + nWHID + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "Select * From t_PromoTPWarehouse where TradePromoID in (" + sPromoID + ") and WarehouseID=" + nWHID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();

                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["TradePromoID"];
                    }
                    oConsumerPromotion.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oConsumerPromotion);
                    
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSlabByPromoID(int nPromoID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "Select * From t_PromoCPSlab where ConsumerPromoID=" + nPromoID + "";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "Select * From t_PromoTPSlab where TradePromoID=" + nPromoID + "";
            }
            else if (sTableName == "t_PromoTPSecondary")
            {
                sSql = "Select * From t_PromoTPSlabSecondary where TradePromoID=" + nPromoID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlab oConsumerPromotionSlab = new ConsumerPromotionSlab();

                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionSlab.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionSlab.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionSlab.MinInvoiceQty = (int)reader["MinInvoiceQty"];
                    }
                    else if (sTableName == "t_PromoTPSecondary")
                    {
                        oConsumerPromotionSlab.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionSlab.MinInvoiceQty = (int)reader["MinInvoiceQty"];
                    }
                    oConsumerPromotionSlab.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlab.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionSlab.IsActive = (int)reader["IsActive"];
                    oConsumerPromotionSlab.CreateDate = (DateTime)reader["CreateDate"];
                    oConsumerPromotionSlab.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oConsumerPromotionSlab.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotionSlab.UpdateDate = null;
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oConsumerPromotionSlab.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"].ToString());
                    }
                    else
                    {
                        oConsumerPromotionSlab.UpdateUserID = -1;
                    }

                    InnerList.Add(oConsumerPromotionSlab);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSlabByPromoIDWEB(string sPromoID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_PromoCP")
            {
                sSql = "Select * From t_PromoCPSlab where ConsumerPromoID in (" + sPromoID + ")";
            }
            else if (sTableName == "t_PromoTP")
            {
                sSql = "Select * From t_PromoTPSlab where TradePromoID in (" + sPromoID + ")";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotionSlab oConsumerPromotionSlab = new ConsumerPromotionSlab();

                    if (sTableName == "t_PromoCP")
                    {
                        oConsumerPromotionSlab.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    }
                    else if (sTableName == "t_PromoTP")
                    {
                        oConsumerPromotionSlab.ConsumerPromoID = (int)reader["TradePromoID"];
                        oConsumerPromotionSlab.MinInvoiceQty = (int)reader["MinInvoiceQty"];
                    }
                    oConsumerPromotionSlab.SlabID = (int)reader["SlabID"];
                    oConsumerPromotionSlab.SlabName = (string)reader["SlabName"];
                    oConsumerPromotionSlab.IsActive = (int)reader["IsActive"];
                    oConsumerPromotionSlab.CreateDate = (DateTime)reader["CreateDate"];
                    oConsumerPromotionSlab.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oConsumerPromotionSlab.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotionSlab.UpdateDate = null;
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oConsumerPromotionSlab.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"].ToString());
                    }
                    else
                    {
                        oConsumerPromotionSlab.UpdateUserID = -1;
                    }

                    InnerList.Add(oConsumerPromotionSlab);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetScratchCardOfferByWH(int nWarehouseID, string sTableName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            if (sTableName == "t_ScratchCardOffer")
            {
                sSql = "Select b.*, TransferType From t_DataTransfer a,t_ScratchCardOffer b  " +
                                "where TableName = 't_ScratchCardOffer' and a.DataID = b.ScratchCardOfferID " +
                                "and WarehouseID = " + nWarehouseID + " and IsDownload = " + (int)Dictionary.IsDownload.No + "";
            }
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();

                    oConsumerPromotion.ConsumerPromoID = (int)reader["ScratchCardOfferID"];
                        oConsumerPromotion.ConsumerPromoNo = (string)reader["ScratchCardOfferCode"];
                        oConsumerPromotion.ConsumerPromoName = (string)reader["ScratchCardOfferName"];


                   
                   
                    oConsumerPromotion.TransferType = Convert.ToInt32(reader["TransferType"]);
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oConsumerPromotion.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.UpdateDate = null;
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oConsumerPromotion.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.UpdateUserID = -1;
                    }
                    oConsumerPromotion.Status = (int)reader["Status"];
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedDate = null;
                    }
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedUserID = -1;
                    }
                    oConsumerPromotion.OfferType = (int)reader["OfferType"];

                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetScratchCardOfferWH(string sPromoID, string sTableName, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTableName == "t_ScratchCardOffer")
            {
                sSql = "Select * From t_ScratchCardOfferWarehouse where ScratchCardOfferID in (" + sPromoID + ") and WarehouseID=" + nWHID + "";
            }
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();

                    if (sTableName == "t_ScratchCardOffer")
                    {
                        oConsumerPromotion.ConsumerPromoID = (int)reader["ScratchCardOfferID"];
                    }
                   
                    oConsumerPromotion.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oConsumerPromotion);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetScratchCardOfferList(DateTime dFromDate, DateTime dToDate, int nIsActive, int nStatus, string sPromoNo, string sPromoName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*, isnull(b.UserFullName, '') as ApprovedUserName From  " +
                    "(  " +
                    "SELECT a.*, UserFullName as CreateUserName FROM t_ScratchCardOffer a, t_User b  " +
                    "where a.CreateUserID = b.UserID  " +
                    ") a  " +
                    "left Outer Join  " +
                    "(Select * From t_User) b  " +
                    "on a.ApprovedUserID = b.UserID  " +
                    //"Left Outer Join  " +
                    //"(Select *,'Yes' as IsPromoDisableFromOnline  From TELADDDB.DBO.t_SalesPromoDisableforEcommerce) c " +
                    //"on a.ConsumerPromoNo=c.SalesPromotionNo " +
                    ") A where CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate< '" + dToDate + "' ";

            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sPromoNo != "")
            {
                sSql = sSql + " AND ConsumerPromoNo like '%" + sPromoNo + "%'";
            }
            if (sPromoName != "")
            {
                sSql = sSql + " AND ConsumerPromoName like '%" + sPromoName + "%'";
            }
            sSql = sSql + " Order by CreateDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["ScratchCardOfferID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["ScratchCardOfferCode"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["ScratchCardOfferName"];
                    oConsumerPromotion.CreateUserName = (string)reader["CreateUserName"];
                    oConsumerPromotion.ApprovedUserName = (string)reader["ApprovedUserName"];
                    oConsumerPromotion.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oConsumerPromotion.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oConsumerPromotion.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oConsumerPromotion.CreateUserID = (int)reader["CreateUserID"];

                    oConsumerPromotion.OfferType = (int)reader["OfferType"];

                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oConsumerPromotion.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oConsumerPromotion.Remarks = "";
                    }
                    oConsumerPromotion.IsActive = (int)reader["IsActive"];
                    oConsumerPromotion.Status = (int)reader["Status"];
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedUserID = -1;

                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        oConsumerPromotion.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        oConsumerPromotion.ApprovedDate = "";

                    }
                    InnerList.Add(oConsumerPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshCPExcludedDMS()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT ConsumerPromoID,ConsumerPromoNo,ConsumerPromoName FROM t_PromoCP A, t_DMSPromoNotApplicableToDms B where A.ConsumerPromoID=B.PromoId  order by ConsumerPromoID desc";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
                    oConsumerPromotion.ConsumerPromoID = (int)reader["ConsumerPromoID"];
                    oConsumerPromotion.ConsumerPromoNo = (string)reader["ConsumerPromoNo"];
                    oConsumerPromotion.ConsumerPromoName = (string)reader["ConsumerPromoName"];
                    InnerList.Add(oConsumerPromotion);
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
    //public class ConsumerPromotionSC : CollectionBase
    //{

    //    private double _ContributionAmount;
    //    private int _nConsumerPromoID;
    //    private string _sConsumerPromoNo;
    //    private string _sConsumerPromoName;
    //    private DateTime _dFromDate;
    //    private DateTime _dToDate;
    //    private DateTime _dCreateDate;
    //    private int _nCreateUserID;
    //    private string _sRemarks;
    //    private int _nIsActive;
    //    private object _dUpdateDate;
    //    private int _nUpdateUserID;
    //    private int _nStatus;
    //    private int _nApprovedUserID;
    //    private object _dApprovedDate;
    //    private string _sPromotionType;
    //    private string _sPromotionTypeName;
    //    private int _nTransferType;
    //    private int _nOfferType;
    //    private int _nDiscountOrFreeProductOrBoth;
    //    public int OfferType
    //    {
    //        get { return _nOfferType; }
    //        set { _nOfferType = value; }
    //    }
    //    public int DiscountOrFreeProductOrBoth
    //    {
    //        get { return _nDiscountOrFreeProductOrBoth; }
    //        set { _nDiscountOrFreeProductOrBoth = value; }
    //    }
    //    public int TransferType
    //    {
    //        get { return _nTransferType; }
    //        set { _nTransferType = value; }
    //    }
    //    //private ConsumerPromotionOfferDetails oConsumerPromotionOfferDetails;
    //    //public ConsumerPromotionOfferDetails ConsumerPromotionOfferDetails
    //    //{
    //    //    get
    //    //    {
    //    //        if (oConsumerPromotionOfferDetails == null)
    //    //        {
    //    //            oConsumerPromotionOfferDetails = new ConsumerPromotionOfferDetails();
    //    //        }
    //    //        return oConsumerPromotionOfferDetails;
    //    //    }
    //    //}
    //    private SPTypes oSPTypes;
    //    public SPTypes SPTypes
    //    {
    //        get
    //        {
    //            if (oSPTypes == null)
    //            {
    //                oSPTypes = new SPTypes();
    //            }
    //            return oSPTypes;
    //        }
    //    }

    //    private SPChannels oSPChannels;
    //    public SPChannels SPChannels
    //    {
    //        get
    //        {
    //            if (oSPChannels == null)
    //            {
    //                oSPChannels = new SPChannels();
    //            }
    //            return oSPChannels;
    //        }
    //    }
    //    private SPWarehouses oSPWarehouses;
    //    public SPWarehouses SPWarehouses
    //    {
    //        get
    //        {
    //            if (oSPWarehouses == null)
    //            {
    //                oSPWarehouses = new SPWarehouses();
    //            }
    //            return oSPWarehouses;
    //        }
    //    }

    //    private ConsumerPromotionOffers oConsumerPromotionOffers;
    //    public ConsumerPromotionOffers ConsumerPromotionOffers
    //    {
    //        get
    //        {
    //            if (oConsumerPromotionOffers == null)
    //            {
    //                oConsumerPromotionOffers = new ConsumerPromotionOffers();
    //            }
    //            return oConsumerPromotionOffers;
    //        }
    //    }
    //    private ConsumerPromotionProductFors oConsumerPromotionProductFors;
    //    public ConsumerPromotionProductFors ConsumerPromotionProductFors
    //    {
    //        get
    //        {
    //            if (oConsumerPromotionProductFors == null)
    //            {
    //                oConsumerPromotionProductFors = new ConsumerPromotionProductFors();
    //            }
    //            return oConsumerPromotionProductFors;
    //        }
    //    }

    //    public double ContributionAmount
    //    {
    //        get { return _ContributionAmount; }
    //        set { _ContributionAmount = value; }
    //    }
    //    private int _nIsApplicableOnAllSKU;
    //    public int IsApplicableOnAllSKU
    //    {
    //        get { return _nIsApplicableOnAllSKU; }
    //        set { _nIsApplicableOnAllSKU = value; }
    //    }
    //    private string _sApplicableProductID;
    //    public string ApplicableProductID
    //    {
    //        get { return _sApplicableProductID; }
    //        set { _sApplicableProductID = value; }
    //    }
    //    // <summary>
    //    // Get set property for ConsumerPromoID
    //    // </summary>
    //    public int ConsumerPromoID
    //    {
    //        get { return _nConsumerPromoID; }
    //        set { _nConsumerPromoID = value; }
    //    }
    //    private int _nWarehouseID;
    //    public int WarehouseID
    //    {
    //        get { return _nWarehouseID; }
    //        set { _nWarehouseID = value; }
    //    }


    //    // <summary>
    //    // Get set property for ConsumerPromoNo
    //    // </summary>
    //    public string ConsumerPromoNo
    //    {
    //        get { return _sConsumerPromoNo; }
    //        set { _sConsumerPromoNo = value; }
    //    }

    //    public string PromotionType
    //    {
    //        get { return _sPromotionType; }
    //        set { _sPromotionType = value; }
    //    }



    //    // <summary>
    //    // Get set property for ConsumerPromoName
    //    // </summary>
    //    public string ConsumerPromoName
    //    {
    //        get { return _sConsumerPromoName; }
    //        set { _sConsumerPromoName = value.Trim(); }
    //    }

    //    // <summary>
    //    // Get set property for FromDate
    //    // </summary>
    //    public DateTime FromDate
    //    {
    //        get { return _dFromDate; }
    //        set { _dFromDate = value; }
    //    }

    //    // <summary>
    //    // Get set property for ToDate
    //    // </summary>
    //    public DateTime ToDate
    //    {
    //        get { return _dToDate; }
    //        set { _dToDate = value; }
    //    }

    //    // <summary>
    //    // Get set property for CreateDate
    //    // </summary>
    //    public DateTime CreateDate
    //    {
    //        get { return _dCreateDate; }
    //        set { _dCreateDate = value; }
    //    }

    //    // <summary>
    //    // Get set property for CreateUserID
    //    // </summary>
    //    public int CreateUserID
    //    {
    //        get { return _nCreateUserID; }
    //        set { _nCreateUserID = value; }
    //    }

    //    // <summary>
    //    // Get set property for Remarks
    //    // </summary>
    //    public string Remarks
    //    {
    //        get { return _sRemarks; }
    //        set { _sRemarks = value.Trim(); }
    //    }
    //    private string _sIsPromoDisableFromOnline;
    //    public string IsPromoDisableFromOnline
    //    {
    //        get { return _sIsPromoDisableFromOnline; }
    //        set { _sIsPromoDisableFromOnline = value.Trim(); }
    //    }
    //    private string _sCreateUserName;
    //    public string CreateUserName
    //    {
    //        get { return _sCreateUserName; }
    //        set { _sCreateUserName = value.Trim(); }
    //    }
    //    private string _sApprovedUserName;
    //    public string ApprovedUserName
    //    {
    //        get { return _sApprovedUserName; }
    //        set { _sApprovedUserName = value.Trim(); }
    //    }

    //    public string PromotionTypeName
    //    {
    //        get { return _sPromotionTypeName; }
    //        set { _sPromotionTypeName = value.Trim(); }
    //    }

    //    // <summary>
    //    // Get set property for IsActive
    //    // </summary>
    //    public int IsActive
    //    {
    //        get { return _nIsActive; }
    //        set { _nIsActive = value; }
    //    }

    //    // <summary>
    //    // Get set property for UpdateDate
    //    // </summary>
    //    public object UpdateDate
    //    {
    //        get { return _dUpdateDate; }
    //        set { _dUpdateDate = value; }
    //    }

    //    // <summary>
    //    // Get set property for UpdateUserID
    //    // </summary>
    //    public int UpdateUserID
    //    {
    //        get { return _nUpdateUserID; }
    //        set { _nUpdateUserID = value; }
    //    }

    //    // <summary>
    //    // Get set property for Status
    //    // </summary>
    //    public int Status
    //    {
    //        get { return _nStatus; }
    //        set { _nStatus = value; }
    //    }
    //    private int _nIsApplicableOnOfferPrice;
    //    public int IsApplicableOnOfferPrice
    //    {
    //        get { return _nIsApplicableOnOfferPrice; }
    //        set { _nIsApplicableOnOfferPrice = value; }
    //    }
    //    // <summary>
    //    // Get set property for ApprovedUserID
    //    // </summary>
    //    public int ApprovedUserID
    //    {
    //        get { return _nApprovedUserID; }
    //        set { _nApprovedUserID = value; }
    //    }

    //    // <summary>
    //    // Get set property for ApprovedDate
    //    // </summary>
    //    public object ApprovedDate
    //    {
    //        get { return _dApprovedDate; }
    //        set { _dApprovedDate = value; }
    //    }

    //    public void Add()
    //    {
    //        int nMaxConsumerPromoID = 0;
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "SELECT MAX([ConsumerPromoID]) FROM t_ConsumerPromotion";
    //            cmd.CommandText = sSql;
    //            object maxID = cmd.ExecuteScalar();
    //            if (maxID == DBNull.Value)
    //            {
    //                nMaxConsumerPromoID = 1;
    //            }
    //            else
    //            {
    //                nMaxConsumerPromoID = Convert.ToInt32(maxID) + 1;
    //            }
    //            _nConsumerPromoID = nMaxConsumerPromoID;
    //            sSql = "INSERT INTO t_ConsumerPromotion (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
    //            cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
    //            cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void AddPromoDisableFromOnline()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "INSERT INTO TELADDDB.DBO.t_SalesPromoDisableforEcommerce (SalesPromotionNo,Company,DisableDate) VALUES(?,?,?)";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("SalesPromotionNo", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("Company", "TEL");
    //            cmd.Parameters.AddWithValue("DisableDate", DateTime.Now);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void ChangeIsActiveStatusConsumerPromotion(int nIsActive)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        int nUserID = Utility.UserId;
    //        DateTime dUpdateDate = DateTime.Now;
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "Update t_PromoCP set IsActive= ?, UpdateDate = ?, UpdateUserID = ? WHERE ConsumerPromoID=?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.AddWithValue("IsActive", nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
    //            cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }



    //    public void Insert(string sTableName)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            if (sTableName == "t_PromoCP")
    //            {
    //                sSql = "INSERT INTO t_PromoCP (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            }
    //            else if (sTableName == "t_PromoTP")
    //            {
    //                sSql = "INSERT INTO t_PromoTP (TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            }
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            if (sTableName == "t_PromoCP")
    //            {
    //                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //                cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
    //                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            }
    //            else if (sTableName == "t_PromoTP")
    //            {
    //                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
    //                cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
    //                cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
    //            }

    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            if (_dUpdateDate != null)
    //                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
    //            else cmd.Parameters.AddWithValue("UpdateDate", null);
    //            if (_nUpdateUserID != -1)
    //                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
    //            else cmd.Parameters.AddWithValue("UpdateUserID", null);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            if (_nApprovedUserID != -1)
    //                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
    //            else cmd.Parameters.AddWithValue("ApprovedUserID", null);
    //            if (_dApprovedDate != null)
    //                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
    //            else cmd.Parameters.AddWithValue("ApprovedDate", null);
    //            cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);


    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void UpdateSalesPromo(string sTableName)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            if (sTableName == "t_PromoCP")
    //            {
    //                sSql = "UPDATE t_PromoCP SET ConsumerPromoNo = ?, ConsumerPromoName = ?, FromDate = ?, ToDate = ?, Remarks = ?,  IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ?,IsApplicableOnOfferPrice = ? WHERE ConsumerPromoID = ?";
    //            }
    //            else
    //            {
    //                sSql = "UPDATE t_PromoTP SET TradePromoNo = ?, TradePromoName = ?, FromDate = ?, ToDate = ?, Remarks = ?,  IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ?,IsApplicableOnOfferPrice = ? WHERE TradePromoID = ?";
    //            }
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            if (sTableName == "t_PromoCP")
    //            {
    //                cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
    //                cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            }
    //            else if (sTableName == "t_PromoTP")
    //            {
    //                cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
    //                cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
    //            }

    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            if (_dUpdateDate != null)
    //                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
    //            else cmd.Parameters.AddWithValue("UpdateDate", null);
    //            if (_nUpdateUserID != -1)
    //                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
    //            else cmd.Parameters.AddWithValue("UpdateUserID", null);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            if (_nApprovedUserID != -1)
    //                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
    //            else cmd.Parameters.AddWithValue("ApprovedUserID", null);
    //            if (_dApprovedDate != null)
    //                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
    //            else cmd.Parameters.AddWithValue("ApprovedDate", null);
    //            cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

    //            if (sTableName == "t_PromoCP")
    //            {
    //                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

    //            }
    //            else if (sTableName == "t_PromoTP")
    //            {
    //                cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);

    //            }

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void Edit()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "UPDATE t_ConsumerPromotion SET ConsumerPromoNo = ?, ConsumerPromoName = ?, FromDate = ?, ToDate = ?, CreateDate = ?, CreateUserID = ?, Remarks = ?, IsActive = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE ConsumerPromoID = ?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
    //            cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
    //            cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void Delete()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "DELETE FROM t_ConsumerPromotion WHERE [ConsumerPromoID]=?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void DeleteDisablePromo()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "DELETE FROM TELADDDB.DBO.t_SalesPromoDisableforEcommerce WHERE [SalesPromotionNo]=?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.AddWithValue("SalesPromotionNo", _sConsumerPromoNo);
    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void Refresh()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        int nCount = 0;
    //        try
    //        {
    //            cmd.CommandText = "SELECT * FROM t_ConsumerPromotion where ConsumerPromoID =?";
    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            if (reader.Read())
    //            {
    //                _nConsumerPromoID = (int)reader["ConsumerPromoID"];
    //                _sConsumerPromoNo = (string)reader["ConsumerPromoNo"];
    //                _sConsumerPromoName = (string)reader["ConsumerPromoName"];
    //                _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
    //                _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
    //                _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
    //                _nCreateUserID = (int)reader["CreateUserID"];
    //                _sRemarks = (string)reader["Remarks"];
    //                _nIsActive = (int)reader["IsActive"];
    //                _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
    //                _nUpdateUserID = (int)reader["UpdateUserID"];
    //                _nStatus = (int)reader["Status"];
    //                _nApprovedUserID = (int)reader["ApprovedUserID"];
    //                _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
    //                nCount++;
    //            }
    //            reader.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }


    //    public void GetOfferDetails(int nConsumerPromoID)
    //    {
    //        InnerList.Clear();
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        try
    //        {

    //            cmd.CommandText = "Select * From  " +
    //                            "(  " +
    //                            "Select ConsumerPromoID,SlabID,OfferID,SlabName,OfferName,  " +
    //                            "case OfferType when 0 then ProductName+':'+CAST(OfferQty as varchar(10))+'Pcs' else '' end as OfferProduct,  " +
    //                            "case OfferType when 1 then Discount else 0 end as OfferAmount,  " +
    //                            "case OfferType when 2 then Discount else 0 end as OfferPercentage  " +
    //                            "From   " +
    //                            "(Select a.*,OfferName,SlabName From t_ConsumerPromotionOfferDetail a,t_ConsumerPromotionOffer b,t_ConsumerPromotionSlab c  " +
    //                            "where a.ConsumerPromoID=b.ConsumerPromoID and a.SlabID=b.SlabID and a.OfferID=b.OfferID   " +
    //                            "and a.ConsumerPromoID=c.ConsumerPromoID and a.SlabID=c.SlabID   " +
    //                            "and b.ConsumerPromoID=c.ConsumerPromoID and b.SlabID=c.SlabID   " +
    //                            "and b.IsActive=1) a  " +
    //                            "left Outer Join   " +
    //                            "(Select ProductID,ProductCode,ProductName From t_Product ) b  " +
    //                            "on a.OfferProductID=b.ProductID  " +
    //                            ") Main where ConsumerPromoID=" + nConsumerPromoID + " order by SlabID,OfferID";


    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                ConsumerPromotionOfferDetail oItem = new ConsumerPromotionOfferDetail();

    //                oItem.SlabName = (reader["SlabName"].ToString());
    //                oItem.OfferName = (reader["OfferName"].ToString());
    //                oItem.OfferProduct = (reader["OfferProduct"].ToString());
    //                oItem.OfferAmount = Convert.ToDouble(reader["OfferAmount"].ToString());
    //                oItem.OfferPercentage = Convert.ToDouble(reader["OfferPercentage"].ToString());
    //                InnerList.Add(oItem);
    //            }

    //            reader.Close();
    //            InnerList.TrimToSize();

    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void GetPromoInfoForReport(int nConsumerPromoID)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        int nCount = 0;
    //        try
    //        {
    //            cmd.CommandText = "Select * From " +
    //                            "( " +
    //                            "Select a.*, isnull(b.UserName, '') ApprovedUserName, isnull(c.Amount, 0) as ContributionAmount " +
    //                            "from " +
    //                            "( " +
    //                            "SELECT a.*, UserName as CreateUserName " +
    //                            "FROM t_PromoCP a, t_User b " +
    //                            "where a.CreateUserID = b.UserID " +
    //                            ") a " +
    //                            "left outer join " +
    //                            "( " +
    //                            "Select * From t_User " +
    //                            ") b " +
    //                            "on a.ApprovedUserID = b.UserID " +
    //                            "left outer join " +
    //                            "( " +
    //                            "Select ConsumerPromoID, sum(Amount) Amount From t_PromoCPDiscountContribution " +
    //                            "group by ConsumerPromoID " +
    //                            ") c " +
    //                            "on a.ConsumerPromoID = c.ConsumerPromoID " +
    //                            ") a where ConsumerPromoID = " + nConsumerPromoID + "";


    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            if (reader.Read())
    //            {
    //                _nConsumerPromoID = (int)reader["ConsumerPromoID"];
    //                _sConsumerPromoNo = (string)reader["ConsumerPromoNo"];
    //                _sConsumerPromoName = (string)reader["ConsumerPromoName"];
    //                _nIsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
    //                _sCreateUserName = (string)reader["CreateUserName"];
    //                _sApprovedUserName = (string)reader["ApprovedUserName"];
    //                _ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
    //                _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
    //                _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
    //                _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
    //                _nCreateUserID = (int)reader["CreateUserID"];
    //                if (reader["Remarks"] != DBNull.Value)
    //                {
    //                    _sRemarks = (string)reader["Remarks"];
    //                }
    //                else
    //                {
    //                    _sRemarks = "";

    //                }
    //                _nIsActive = (int)reader["IsActive"];
    //                _nStatus = (int)reader["Status"];
    //                if (reader["ApprovedUserID"] != DBNull.Value)
    //                {
    //                    _nApprovedUserID = (int)reader["ApprovedUserID"];
    //                }
    //                else
    //                {
    //                    _nApprovedUserID = -1;

    //                }
    //                if (reader["ApprovedDate"] != DBNull.Value)
    //                {
    //                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
    //                }
    //                else
    //                {
    //                    _dApprovedDate = "";
    //                }
    //                nCount++;
    //            }

    //            //GetOfferDetails(nConsumerPromoID);
    //            GetPromoProductDetail(nConsumerPromoID);

    //            reader.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void GetTPInfoForReport(int nConsumerPromoID)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        int nCount = 0;
    //        try
    //        {
    //            cmd.CommandText = "Select * From " +
    //                            "( " +
    //                            "Select a.*, isnull(b.UserName, '') ApprovedUserName, isnull(c.Amount, 0) as ContributionAmount " +
    //                            "from " +
    //                            "( " +
    //                            "SELECT a.*, UserName as CreateUserName " +
    //                            "FROM t_PromoTP a, t_User b " +
    //                            "where a.CreateUserID = b.UserID " +
    //                            ") a " +
    //                            "left outer join " +
    //                            "( " +
    //                            "Select * From t_User " +
    //                            ") b " +
    //                            "on a.ApprovedUserID = b.UserID " +
    //                            "left outer join " +
    //                            "( " +
    //                            "Select TradePromoID, sum(Amount) Amount From t_PromoTPDiscountContribution " +
    //                            "group by TradePromoID " +
    //                            ") c " +
    //                            "on a.TradePromoID = c.TradePromoID " +
    //                            ") a where TradePromoID = " + nConsumerPromoID + "";


    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            if (reader.Read())
    //            {
    //                _nConsumerPromoID = (int)reader["TradePromoID"];
    //                _sConsumerPromoNo = (string)reader["TradePromoNo"];
    //                _nIsApplicableOnOfferPrice = (int)reader["IsApplicableOnOfferPrice"];
    //                _sConsumerPromoName = (string)reader["TradePromoName"];
    //                _sCreateUserName = (string)reader["CreateUserName"];
    //                _sApprovedUserName = (string)reader["ApprovedUserName"];
    //                _ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
    //                _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
    //                _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
    //                _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
    //                _nCreateUserID = (int)reader["CreateUserID"];
    //                if (reader["Remarks"] != DBNull.Value)
    //                {
    //                    _sRemarks = (string)reader["Remarks"];
    //                }
    //                else
    //                {
    //                    _sRemarks = "";

    //                }
    //                _nIsActive = (int)reader["IsActive"];
    //                _nStatus = (int)reader["Status"];
    //                if (reader["ApprovedUserID"] != DBNull.Value)
    //                {
    //                    _nApprovedUserID = (int)reader["ApprovedUserID"];
    //                }
    //                else
    //                {
    //                    _nApprovedUserID = -1;

    //                }
    //                if (reader["ApprovedDate"] != DBNull.Value)
    //                {
    //                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
    //                }
    //                else
    //                {
    //                    _dApprovedDate = "";
    //                }
    //                nCount++;
    //            }

    //            //GetOfferDetails(nConsumerPromoID);
    //            GetTPProductDetail(nConsumerPromoID);

    //            reader.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void InsertConsumerPromotion(DSPromotionContribution _oDSPromotionContribution)
    //    {
    //        int nMaxConsumerPromoID = 0;
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";

    //        try
    //        {
    //            sSql = "SELECT MAX([ConsumerPromoID]) FROM t_PromoCP";
    //            cmd.CommandText = sSql;
    //            object maxID = cmd.ExecuteScalar();
    //            if (maxID == DBNull.Value)
    //            {
    //                nMaxConsumerPromoID = 1;
    //            }
    //            else
    //            {
    //                nMaxConsumerPromoID = Convert.ToInt32(maxID) + 1;
    //            }
    //            _nConsumerPromoID = nMaxConsumerPromoID;
    //            _sConsumerPromoNo = "CP-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

    //            sSql = "INSERT INTO t_PromoCP (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", null);
    //            cmd.Parameters.AddWithValue("UpdateUserID", null);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", null);
    //            cmd.Parameters.AddWithValue("ApprovedDate", null);
    //            cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();

    //            if (oConsumerPromotionProductFors != null)
    //            {
    //                foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
    //                {
    //                    oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
    //                    oConsumerPromotionProductFor.Insert();
    //                }
    //            }
    //            if (oSPChannels != null)
    //            {
    //                foreach (SPChannel oSPChannel in oSPChannels)
    //                {
    //                    oSPChannel.SalesPromotionID = _nConsumerPromoID;
    //                    oSPChannel.InsertConsumerPromoChannel();
    //                }
    //            }
    //            if (oSPWarehouses != null)
    //            {
    //                foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
    //                {
    //                    oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
    //                    oSPWarehouse.InsertConsumerPromoWarehouse();
    //                }
    //            }
    //            if (oSPTypes != null)
    //            {
    //                foreach (SPType oSPType in oSPTypes)
    //                {
    //                    oSPType.SalesPromotionID = _nConsumerPromoID;
    //                    oSPType.InsertConsumerPromotionType();
    //                }
    //            }
    //            foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
    //            {
    //                oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
    //                oSalesPromotionSlab.InsertSlab();
    //            }

    //            foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
    //            {
    //                PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
    //                oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
    //                oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
    //                oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
    //                oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
    //                if (oPromoDiscountContributor.Amount > 0)
    //                {
    //                    oPromoDiscountContributor.AddCPDiscountContributionNew();
    //                }

    //            }
    //            //if (oProductGroups != null)
    //            //{
    //            //    foreach (ProductGroup oProductGroup in oProductGroups)
    //            //    {
    //            //        SPProductGroup oSPProductGroup = new SPProductGroup();
    //            //        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
    //            //        oSPProductGroup.ProductGroupType = oProductGroup.PdtGroupType;
    //            //        oSPProductGroup.ProductGroupID = oProductGroup.PdtGroupID;
    //            //        oSPProductGroup.DiscountType = _DiscountType;
    //            //        oSPProductGroup.DiscountPercentage = _DiscountPercent;
    //            //        oSPProductGroup.Insert();
    //            //    }
    //            //}

    //            //Showrooms _oShowrooms = new Showrooms();
    //            //_oShowrooms.Refresh();

    //            //foreach (Showroom oShowroom in _oShowrooms)
    //            //{
    //            //    DataTran oDataTran = new DataTran();

    //            //    oDataTran.TableName = "t_SalesPromo";
    //            //    oDataTran.DataID = _nSalesPromotionID;
    //            //    oDataTran.WarehouseID = oShowroom.WarehouseID;
    //            //    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
    //            //    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
    //            //    oDataTran.BatchNo = 0;

    //            //    oDataTran.AddForTDPOS();
    //            //}
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void InsertConsumerPromotion(DSPromotionContribution _oDSPromotionContribution, DSPromotionAllocate _oDSPromotionAllocate)
    //    {
    //        int nMaxConsumerPromoID = 0;
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";

    //        try
    //        {
    //            sSql = "SELECT MAX([ConsumerPromoID]) FROM t_PromoCP";
    //            cmd.CommandText = sSql;
    //            object maxID = cmd.ExecuteScalar();
    //            if (maxID == DBNull.Value)
    //            {
    //                nMaxConsumerPromoID = 1;
    //            }
    //            else
    //            {
    //                nMaxConsumerPromoID = Convert.ToInt32(maxID) + 1;
    //            }
    //            _nConsumerPromoID = nMaxConsumerPromoID;
    //            _sConsumerPromoNo = "CP-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

    //            sSql = "INSERT INTO t_PromoCP (ConsumerPromoID, ConsumerPromoNo, ConsumerPromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            cmd.Parameters.AddWithValue("ConsumerPromoNo", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", null);
    //            cmd.Parameters.AddWithValue("UpdateUserID", null);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", null);
    //            cmd.Parameters.AddWithValue("ApprovedDate", null);
    //            cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();

    //            if (oConsumerPromotionProductFors != null)
    //            {
    //                foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
    //                {
    //                    oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
    //                    oConsumerPromotionProductFor.Insert();
    //                }
    //            }
    //            if (oSPChannels != null)
    //            {
    //                foreach (SPChannel oSPChannel in oSPChannels)
    //                {
    //                    oSPChannel.SalesPromotionID = _nConsumerPromoID;
    //                    oSPChannel.InsertConsumerPromoChannel();
    //                }
    //            }
    //            if (oSPWarehouses != null)
    //            {
    //                foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
    //                {
    //                    oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
    //                    oSPWarehouse.InsertConsumerPromoWarehouse();
    //                }
    //            }
    //            if (oSPTypes != null)
    //            {
    //                foreach (SPType oSPType in oSPTypes)
    //                {
    //                    oSPType.SalesPromotionID = _nConsumerPromoID;
    //                    oSPType.InsertConsumerPromotionType();
    //                }
    //            }
    //            foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
    //            {
    //                oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
    //                oSalesPromotionSlab.InsertSlab();
    //            }

    //            foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
    //            {
    //                PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
    //                oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
    //                oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
    //                oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
    //                oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
    //                if (oPromoDiscountContributor.Amount > 0)
    //                {
    //                    oPromoDiscountContributor.AddCPDiscountContributionNew();
    //                }

    //            }

    //            foreach (DSPromotionAllocate.PromotionAllocateRow oPromotionAllocateRow in _oDSPromotionAllocate.PromotionAllocate)
    //            {
    //                PromoTargetAllocator oPromoTargetAllocator = new PromoTargetAllocator();
    //                oPromoTargetAllocator.ConsumerPromoID = _nConsumerPromoID;
    //                oPromoTargetAllocator.SalesTypeID = oPromotionAllocateRow.SalesTypeID;
    //                oPromoTargetAllocator.TargetQty = oPromotionAllocateRow.TargetQty;
    //                oPromoTargetAllocator.TargetValue = oPromotionAllocateRow.TargetValue;
    //                oPromoTargetAllocator.PromoCostVal = oPromotionAllocateRow.PromoCostVal;
    //                oPromoTargetAllocator.NetSalesVal = oPromotionAllocateRow.NetSalesVal;
    //                oPromoTargetAllocator.RegularSalesQty = oPromotionAllocateRow.RegularSalesQty;
    //                oPromoTargetAllocator.TargetMC = oPromotionAllocateRow.TargetMC;
    //                oPromoTargetAllocator.ProductID = oPromotionAllocateRow.ProductID;

    //                oPromoTargetAllocator.AddPromoTargetAllocator();
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void InsertSPScratchCardOffer()
    //    {
    //        int nMaxConsumerPromoID = 0;
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";

    //        try
    //        {
    //            sSql = "SELECT MAX([ScratchCardOfferID]) FROM t_ScratchCardOffer";
    //            cmd.CommandText = sSql;
    //            object maxID = cmd.ExecuteScalar();
    //            if (maxID == DBNull.Value)
    //            {
    //                nMaxConsumerPromoID = 1;
    //            }
    //            else
    //            {
    //                nMaxConsumerPromoID = Convert.ToInt32(maxID) + 1;
    //            }
    //            _nConsumerPromoID = nMaxConsumerPromoID;
    //            _sConsumerPromoNo = "SC-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

    //            sSql = "INSERT INTO t_ScratchCardOffer (ScratchCardOfferID,	ScratchCardOfferCode,	ScratchCardOfferName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate,OfferType,	DiscountOrFreeProductOrBoth) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("ScratchCardOfferID", _nConsumerPromoID);
    //            cmd.Parameters.AddWithValue("ScratchCardOfferCode", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("ScratchCardOfferName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", null);
    //            cmd.Parameters.AddWithValue("UpdateUserID", null);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", null);
    //            cmd.Parameters.AddWithValue("ApprovedDate", null);
    //            cmd.Parameters.AddWithValue("OfferType", _nOfferType);
    //            cmd.Parameters.AddWithValue("DiscountOrFreeProductOrBoth", _nDiscountOrFreeProductOrBoth);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();

    //            if (oConsumerPromotionProductFors != null)
    //            {
    //                foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
    //                {
    //                    oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
    //                    oConsumerPromotionProductFor.InsertSC();
    //                }
    //            }
    //            if (oSPChannels != null)
    //            {
    //                foreach (SPChannel oSPChannel in oSPChannels)
    //                {
    //                    oSPChannel.SalesPromotionID = _nConsumerPromoID;
    //                    oSPChannel.InsertScratchCardOfferChannel();
    //                }
    //            }
    //            if (oSPWarehouses != null)
    //            {
    //                foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
    //                {
    //                    oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
    //                    oSPWarehouse.InsertScratchCardOfferWarehouse();
    //                }
    //            }



    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void ChangeIsActiveStatus(int nIsActive)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        int nUserID = Utility.UserId;
    //        DateTime dUpdateDate = DateTime.Now;
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "Update t_PromoTP set IsActive= ?,UpdateUserID = ?, UpdateDate = ? WHERE TradePromoID=?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.AddWithValue("IsActive", nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
    //            cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
    //            cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }


    //    public void InsertTradePromotion(DSPromotionContribution _oDSPromotionContribution)
    //    {
    //        int nMaxConsumerPromoID = 0;
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";

    //        try
    //        {
    //            sSql = "SELECT MAX([TradePromoID]) FROM t_PromoTP";
    //            cmd.CommandText = sSql;
    //            object maxID = cmd.ExecuteScalar();
    //            if (maxID == DBNull.Value)
    //            {
    //                nMaxConsumerPromoID = 1;
    //            }
    //            else
    //            {
    //                nMaxConsumerPromoID = Convert.ToInt32(maxID) + 1;
    //            }
    //            _nConsumerPromoID = nMaxConsumerPromoID;
    //            _sConsumerPromoNo = "TP-" + DateTime.Now.ToString("yy") + "-" + nMaxConsumerPromoID.ToString("00000");

    //            sSql = "INSERT INTO t_PromoTP (TradePromoID, TradePromoNo, TradePromoName, FromDate, ToDate, CreateDate, CreateUserID, Remarks, IsActive, UpdateDate, UpdateUserID, Status, ApprovedUserID, ApprovedDate, IsApplicableOnOfferPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);
    //            cmd.Parameters.AddWithValue("TradePromoNo", _sConsumerPromoNo);
    //            cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
    //            cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
    //            cmd.Parameters.AddWithValue("Remarks", _sRemarks);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateDate", null);
    //            cmd.Parameters.AddWithValue("UpdateUserID", null);
    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", null);
    //            cmd.Parameters.AddWithValue("ApprovedDate", null);
    //            cmd.Parameters.AddWithValue("IsApplicableOnOfferPrice", _nIsApplicableOnOfferPrice);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();

    //            if (oConsumerPromotionProductFors != null)
    //            {
    //                foreach (ConsumerPromotionProductFor oConsumerPromotionProductFor in oConsumerPromotionProductFors)
    //                {
    //                    oConsumerPromotionProductFor.ConsumerPromoID = _nConsumerPromoID;
    //                    oConsumerPromotionProductFor.InsertTP();
    //                }
    //            }
    //            if (oSPChannels != null)
    //            {
    //                foreach (SPChannel oSPChannel in oSPChannels)
    //                {
    //                    oSPChannel.SalesPromotionID = _nConsumerPromoID;
    //                    oSPChannel.InsertTPChannel();
    //                }
    //            }
    //            if (oSPWarehouses != null)
    //            {
    //                foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
    //                {
    //                    oSPWarehouse.SalesPromotionID = _nConsumerPromoID;
    //                    oSPWarehouse.InsertTPWarehouse();
    //                }
    //            }
    //            if (oSPTypes != null)
    //            {
    //                foreach (SPType oSPType in oSPTypes)
    //                {
    //                    oSPType.SalesPromotionID = _nConsumerPromoID;
    //                    oSPType.InsertTPType();
    //                }
    //            }

    //            foreach (ConsumerPromotionSlab oSalesPromotionSlab in this)
    //            {
    //                oSalesPromotionSlab.ConsumerPromoID = _nConsumerPromoID;
    //                oSalesPromotionSlab.InsertTPSlab();
    //            }

    //            foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
    //            {
    //                PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
    //                oPromoDiscountContributor.ConsumerPromoID = _nConsumerPromoID;
    //                oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
    //                oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
    //                oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
    //                if (oPromoDiscountContributor.Amount > 0)
    //                {
    //                    oPromoDiscountContributor.AddTPDiscountContributionNew();
    //                }

    //            }
    //            //if (oProductGroups != null)
    //            //{
    //            //    foreach (ProductGroup oProductGroup in oProductGroups)
    //            //    {
    //            //        SPProductGroup oSPProductGroup = new SPProductGroup();
    //            //        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
    //            //        oSPProductGroup.ProductGroupType = oProductGroup.PdtGroupType;
    //            //        oSPProductGroup.ProductGroupID = oProductGroup.PdtGroupID;
    //            //        oSPProductGroup.DiscountType = _DiscountType;
    //            //        oSPProductGroup.DiscountPercentage = _DiscountPercent;
    //            //        oSPProductGroup.Insert();
    //            //    }
    //            //}

    //            //Showrooms _oShowrooms = new Showrooms();
    //            //_oShowrooms.Refresh();

    //            //foreach (Showroom oShowroom in _oShowrooms)
    //            //{
    //            //    DataTran oDataTran = new DataTran();

    //            //    oDataTran.TableName = "t_SalesPromo";
    //            //    oDataTran.DataID = _nSalesPromotionID;
    //            //    oDataTran.WarehouseID = oShowroom.WarehouseID;
    //            //    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
    //            //    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
    //            //    oDataTran.BatchNo = 0;

    //            //    oDataTran.AddForTDPOS();
    //            //}
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void GetPromoProductDetail1(int nConsumerPromoID, DateTime dtFromDate, string sCompany)
    //    {
    //        InnerList.Clear();
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "Select * From  " +
    //                    "(  " +
    //                    "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
    //                    "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
    //                    "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
    //                    "(Select a.ProductID,ConsumerPromoID,'['+ProductCode+']'+ ProductName as ProductName,TargetQty    " +
    //                    "From t_ConsumerPromotionProductFor a,t_Product b    " +
    //                    "where a.ProductID=b.ProductID and GroupTypeID=1) a  " +
    //                    "Left Outer Join   " +
    //                    "(Select ProductID,  " +
    //                    "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
    //                    "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
    //                    "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
    //                    "From   " +
    //                    "(  " +
    //                    "Select ProductID,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
    //                    "From DWDB.DBO.t_SalesDataCustomerProduct where   " +
    //                    "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
    //                    "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and CompanyName='" + sCompany + "'  " +
    //                    ") A group by ProductID) b  " +
    //                    "on a.ProductID=b.ProductID  " +
    //                    "Union All  " +
    //                    //---PG---
    //                    "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
    //                    "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
    //                    "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
    //                    "(Select ConsumerPromoID,PdtGroupID as PGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
    //                    "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=2 and PdtGroupType=1) a  " +
    //                    "Left Outer Join   " +
    //                    "(Select PGID,  " +
    //                    "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
    //                    "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
    //                    "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
    //                    "From   " +
    //                    "(  " +
    //                    "Select PGID,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
    //                    "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
    //                    "where a.ProductID=b.ProductID and   " +
    //                    "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
    //                    "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and CompanyName='" + sCompany + "'  " +
    //                    ") A group by PGID) b  " +
    //                    "on a.PGID=b.PGID  " +
    //                    "Union All  " +
    //                    //---MAG----
    //                    "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
    //                    "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
    //                    "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
    //                    "(Select ConsumerPromoID,PdtGroupID as MAGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
    //                    "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=3 and PdtGroupType=2) a  " +
    //                    "Left Outer Join   " +
    //                    "(Select MAGID,  " +
    //                    "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
    //                    "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
    //                    "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
    //                    "From   " +
    //                    "(  " +
    //                    "Select MAGID,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
    //                    "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
    //                    "where a.ProductID=b.ProductID and   " +
    //                    "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
    //                    "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and CompanyName='" + sCompany + "'  " +
    //                    ") A group by MAGID) b  " +
    //                    "on a.MAGID=b.MAGID  " +
    //                    "Union All  " +
    //                    //---ASG----
    //                    "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
    //                    "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
    //                    "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
    //                    "(Select ConsumerPromoID,PdtGroupID as ASGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
    //                    "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=4 and PdtGroupType=3) a  " +
    //                    "Left Outer Join   " +
    //                    "(Select ASGID,  " +
    //                    "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
    //                    "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
    //                    "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
    //                    "From   " +
    //                    "(  " +
    //                    "Select ASGID,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
    //                    "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
    //                    "where a.ProductID=b.ProductID and   " +
    //                    "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
    //                    "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and CompanyName='" + sCompany + "'  " +
    //                    ") A group by ASGID) b  " +
    //                    "on a.ASGID=b.ASGID  " +
    //                    "Union All  " +
    //                    //---AG---
    //                    "Select a.*,isnull(Month01SalesQty,0) Month01SalesQty,isnull(Month01NetSale,0) Month01NetSale,  " +
    //                    "isnull(Month02SalesQty,0) Month02SalesQty,isnull(Month02NetSale,0) Month02NetSale,  " +
    //                    "isnull(Month03SalesQty,0) Month03SalesQty,isnull(Month03NetSale,0) Month03NetSale From   " +
    //                    "(Select ConsumerPromoID,PdtGroupID as AGID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty     " +
    //                    "From t_ConsumerPromotionProductFor a,t_ProductGroup b    " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=5 and PdtGroupType=4) a  " +
    //                    "Left Outer Join   " +
    //                    "(Select AGID,  " +
    //                    "sum(Month01SalesQty) Month01SalesQty,sum(Month01NetSale) Month01NetSale,  " +
    //                    "sum(Month02SalesQty) Month02SalesQty,sum(Month02NetSale) Month02NetSale,  " +
    //                    "sum(Month03SalesQty) Month03SalesQty,sum(Month03NetSale) Month03NetSale   " +
    //                    "From   " +
    //                    "(  " +
    //                    "Select AGID,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then SalesQty+FreeQty else 0 end as Month01SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)) then NetSale else 0 end as Month01NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then SalesQty+FreeQty else 0 end as Month02SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-2, 0)) then NetSale else 0 end as Month02NetSale,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then SalesQty+FreeQty else 0 end as Month03SalesQty,  " +
    //                    "Case when month(InvoiceDate)=Month(DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-1, 0)) then NetSale else 0 end as Month03NetSale  " +
    //                    "From DWDB.DBO.t_SalesDataCustomerProduct a,v_productDetails b  " +
    //                    "where a.ProductID=b.ProductID and   " +
    //                    "InvoiceDate between DATEADD(MONTH, DATEDIFF(MONTH, 0, '" + dtFromDate + "')-3, 0)    " +
    //                    "and DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and InvoiceDate<DATEADD(m, DATEDIFF(m, 0, '" + dtFromDate + "'), 0)   " +
    //                    "and CompanyName='" + sCompany + "'  " +
    //                    ") A group by AGID) b  " +
    //                    "on a.AGID=b.AGID  " +
    //                    ") Main where ConsumerPromoID=" + nConsumerPromoID + "";
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
    //                oConsumerPromotionProductFor.ProductName = (string)reader["ProductName"];
    //                oConsumerPromotionProductFor.TGTQty = (int)reader["TargetQty"];

    //                oConsumerPromotionProductFor.Month01SalesQty = (int)reader["Month01SalesQty"];
    //                oConsumerPromotionProductFor.Month01NetSale = (double)reader["Month01NetSale"];

    //                oConsumerPromotionProductFor.Month02SalesQty = (int)reader["Month02SalesQty"];
    //                oConsumerPromotionProductFor.Month02NetSale = (double)reader["Month02NetSale"];

    //                oConsumerPromotionProductFor.Month03SalesQty = (int)reader["Month03SalesQty"];
    //                oConsumerPromotionProductFor.Month03NetSale = (double)reader["Month03NetSale"];

    //                InnerList.Add(oConsumerPromotionProductFor);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void GetPromoProductDetail(int nConsumerPromoID)
    //    {
    //        InnerList.Clear();
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "Select * From  " +
    //                    "(  " +
    //                    "Select ConsumerPromoID,'['+ProductCode+']'+ ProductName as ProductName,TargetQty, ISNULL(TargetValue,0) TargetValue,ISNULL(PromoCostVal,0) PromoCostVal, ISNULL(NetSalesVal,0) NetSalesVal,RegularSalesQty,DiscountRatio   " +
    //                    "From t_PromoCPProductFor a,t_Product b  " +
    //                    "where a.ProductID=b.ProductID and GroupTypeID=1  " +
    //                    "Union All  " +
    //                    "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
    //                    "From t_PromoCPProductFor a,t_ProductGroup b  " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=2 and PdtGroupType=1  " +
    //                    "Union All  " +
    //                    "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
    //                    "From t_PromoCPProductFor a,t_ProductGroup b  " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=3 and PdtGroupType=2  " +
    //                    "Union All  " +
    //                    "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
    //                    "From t_PromoCPProductFor a,t_ProductGroup b  " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=4 and PdtGroupType=3  " +
    //                    "Union All  " +
    //                    "Select ConsumerPromoID,'['+pdtGroupCode+']'+pdtGroupName as ProductName,TargetQty,TargetValue,PromoCostVal,NetSalesVal,RegularSalesQty,DiscountRatio   " +
    //                    "From t_PromoCPProductFor a,t_ProductGroup b  " +
    //                    "where a.ProductID=b.pdtGroupID and GroupTypeID=5 and PdtGroupType=4  " +
    //                    ") Main where ConsumerPromoID=" + nConsumerPromoID + "";
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                ConsumerPromotionSlab oConsumerPromotionProductFor = new ConsumerPromotionSlab();
    //                oConsumerPromotionProductFor.ProductName = (string)reader["ProductName"];
    //                oConsumerPromotionProductFor.TargetQty = (int)reader["TargetQty"];
    //                if (reader["TargetValue"] != DBNull.Value)
    //                {
    //                    oConsumerPromotionProductFor.TargetValue = (double)reader["TargetValue"];
    //                }
    //                if (reader["PromoCostVal"] != DBNull.Value)
    //                {
    //                    oConsumerPromotionProductFor.PromoCostVal = (double)reader["PromoCostVal"];
    //                }
    //                if (reader["NetSalesVal"] != DBNull.Value)
    //                {
    //                    oConsumerPromotionProductFor.NetSalesVal = (double)reader["NetSalesVal"];
    //                }
    //                oConsumerPromotionProductFor.RegularSalesQty = (int)reader["RegularSalesQty"];
    //                oConsumerPromotionProductFor.DiscountRatio = (double)reader["DiscountRatio"];

    //                InnerList.Add(oConsumerPromotionProductFor);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //    public void GetTPProductDetail(int nConsumerPromoID)
    //    {
    //        InnerList.Clear();
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "Select a.*,PdtGroupName as ProductGroupName,BrandDesc as BrandName " +
    //                    "From t_PromoTPProductFor a,t_Brand b, t_ProductGroup c " +
    //                    "where a.BrandID = b.BrandID and a.ProductGroupID = c.PdtGroupID and GroupTypeID = 3 " +
    //                    "and TradePromoID = " + nConsumerPromoID + "";
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();

    //            while (reader.Read())
    //            {
    //                ConsumerPromotionSlab oConsumerPromotionProductFor = new ConsumerPromotionSlab();
    //                oConsumerPromotionProductFor.ProductGroupName = (string)reader["ProductGroupName"];
    //                oConsumerPromotionProductFor.BrandName = (string)reader["BrandName"];
    //                oConsumerPromotionProductFor.TargetQty = (int)reader["TargetQty"];
    //                oConsumerPromotionProductFor.RegularSalesQty = (int)reader["RegularSalesQty"];
    //                oConsumerPromotionProductFor.DiscountRatio = (double)reader["DiscountRatio"];

    //                InnerList.Add(oConsumerPromotionProductFor);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void UpdateStatus(string sTableName)
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            if (sTableName == "t_PromoCP")
    //                sSql = "UPDATE t_PromoCP SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE ConsumerPromoID = ?";
    //            else sSql = "UPDATE t_PromoTP SET Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE TradePromoID = ?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;

    //            cmd.Parameters.AddWithValue("Status", _nStatus);
    //            cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);
    //            cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
    //            if (sTableName == "t_PromoCP")
    //                cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);
    //            else cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }

    //    public void UpdatePromoTP()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "UPDATE t_PromoTP SET TradePromoName = ?, FromDate = ?, ToDate = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE TradePromoID = ?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.AddWithValue("TradePromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
    //            cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

    //            cmd.Parameters.AddWithValue("TradePromoID", _nConsumerPromoID);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }


    //    public void UpdatePromoCP()
    //    {
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "";
    //        try
    //        {
    //            sSql = "UPDATE t_PromoCP SET ConsumerPromoName = ?, FromDate = ?, ToDate = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE ConsumerPromoID = ?";
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.Parameters.AddWithValue("ConsumerPromoName", _sConsumerPromoName);
    //            cmd.Parameters.AddWithValue("FromDate", _dFromDate);
    //            cmd.Parameters.AddWithValue("ToDate", _dToDate);
    //            cmd.Parameters.AddWithValue("IsActive", _nIsActive);
    //            cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
    //            cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

    //            cmd.Parameters.AddWithValue("ConsumerPromoID", _nConsumerPromoID);

    //            cmd.ExecuteNonQuery();
    //            cmd.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //}


}

