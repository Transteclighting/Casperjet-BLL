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
using CJ.Class.POS;


namespace CJ.Class.Promotion
{
    public class SalesPromotionSlab
    {
        private int _nCPSID;
        private int _nSalesPromotionID;
        private int _nSlabNo;
        private string _sSlabName;
        private int _nIsActive;
        private int _nDiscountType;
        private double _Discount;

        int _nCount = 0;

        private SPFreeGifts oSPFreeGifts;
        private SPFreeProducts oSPFreeProducts;
        private SPDiscountSlab oSPDiscountSlab;
        private SPFlatSlab oSPFlatSlab;
        private SPSlabAllRatio oSPSlabAllRatio;

        public SPFreeGifts SPFreeGifts
        {
            get
            {
                if (oSPFreeGifts == null)
                {
                    oSPFreeGifts = new SPFreeGifts();
                }
                return oSPFreeGifts;
            }
        }
        public SPFreeProducts SPFreeProducts
        {
            get
            {
                if (oSPFreeProducts == null)
                {
                    oSPFreeProducts = new SPFreeProducts();
                }
                return oSPFreeProducts;
            }
        }
        public SPDiscountSlab SPDiscountSlab
        {
            get
            {
                if (oSPDiscountSlab == null)
                {
                    oSPDiscountSlab = new SPDiscountSlab();
                }
                return oSPDiscountSlab;
            }
        }
        public SPFlatSlab SPFlatSlab
        {
            get
            {
                if (oSPFlatSlab == null)
                {
                    oSPFlatSlab = new SPFlatSlab();
                }
                return oSPFlatSlab;
            }
        }
        public SPSlabAllRatio SPSlabAllRatio
        {
            get
            {
                if (oSPSlabAllRatio == null)
                {
                    oSPSlabAllRatio = new SPSlabAllRatio();
                }
                return oSPSlabAllRatio;
            }
        }

        /// <summary>
        /// Get set property for CPSID
        /// </summary>
        public int CPSID
        {
            get { return _nCPSID; }
            set { _nCPSID = value; }
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
        /// Get set property for SlabNo
        /// </summary>
        public int SlabNo
        {
            get { return _nSlabNo; }
            set { _nSlabNo = value; }
        }
        /// <summary>
        /// Get set property for SlabName
        /// </summary>
        public string SlabName
        {
            get { return _sSlabName; }
            set { _sSlabName = value; }
        }
        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        /// Get set property for discount
        /// </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        
        
        public void Insert()
        {
            int nMaxCPSID = 0;         
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([CPSID]) FROM t_SalesPromoSlab";
                cmd.CommandText = sSql;
                object maxCPSID = cmd.ExecuteScalar();
                if (maxCPSID == DBNull.Value)
                {
                    nMaxCPSID = 1;
                }
                else
                {
                    nMaxCPSID = Convert.ToInt32(maxCPSID) + 1;
                }
                _nCPSID = nMaxCPSID;


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_SalesPromoSlab VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SlabNo", _nSlabNo);
                cmd.Parameters.AddWithValue("SlabName",_sSlabName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("DiscountType", _nDiscountType);
                cmd.Parameters.AddWithValue("Discount", _Discount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oSPSlabAllRatio != null)
                {
                    foreach (SPSlabRatio oSPSlabRatio in oSPSlabAllRatio)
                    {
                        oSPSlabRatio.CPSID = _nCPSID;
                        oSPSlabRatio.Insert();
                    }
                }
                //

                if (oSPFreeProducts != null)
                {
                    if (oSPFreeProducts.Count > 0)
                    {
                        foreach (SPFreeProduct oSPFreeProduct in oSPFreeProducts)
                        {
                            oSPFreeProduct.CPSID = _nCPSID;
                            oSPFreeProduct.Insert();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteDetail()
        {
            _nCount = 0;
            if (oSPSlabAllRatio != null)
            {
                foreach (SPSlabRatio oSPSlabRatio in oSPSlabAllRatio)
                {
                    oSPSlabRatio.CPSID = _nCPSID;
                    if (_nCount == 0)
                        oSPSlabRatio.Delete();
                    _nCount++;
                }
            }
            _nCount = 0;
            if (oSPFreeProducts != null)
            {
                if (oSPFreeProducts.Count > 0)
                {
                    foreach (SPFreeProduct oSPFreeProduct in oSPFreeProducts)
                    {
                        oSPFreeProduct.CPSID = _nCPSID;
                        if (_nCount == 0)
                            oSPFreeProduct.Delete();
                        _nCount++;
                    }
                }
            }
            //if (oSPDiscountSlab != null)
            //{
            //    oSPDiscountSlab.CPSID = _nCPSID;
            //    oSPDiscountSlab.Delete();
            //}
            //if (oSPFlatSlab != null)
            //{
            //    oSPFlatSlab.CPSID = _nCPSID;
            //    oSPFlatSlab.Delete();
            //}           
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_SalesPromoSlab WHERE SalesPromotionID=? ";

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
    public class SPromotion : CollectionBase
    {
        public SalesPromotionSlab this[int i]
        {
            get { return (SalesPromotionSlab)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesPromotionSlab oSalesPromotionSlab)
        {
            InnerList.Add(oSalesPromotionSlab);
        }

        private int _nSalesPromotionID;
        private int _nSalesPromotionNo;
        private string _sSalesPromotionName;
        private DateTime _dCreateDate;
        private DateTime _dUpdateDate;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private int _nEntryUserID;
        private int _nUpdateUserID;
        private int _nIsActive;
        private DateTime _dUploadDate;
        private int _nUploadStatus;
        private DateTime _dDownloadDate;
        private int _nRowStatus;
        private int _nTerminal;
        private double _InvoiceDiscountPercentage;
        private string _sRemarks;
        private int _nTransferType;

        private int _nInvoiceID;
        private int _nWarehouseID;
        

        int _nCount = 0;

        private SPChannels oSPChannels;
        private SPWarehouses oSPWarehouses;
        private SPProducts oSPProducts;
        private Showrooms oShowrooms;
        private ProductGroups oProductGroups;
        private SPProductGroups oSPProductGroups;
        private SPTypes oSPTypes;
        private SPCustomerTypes oSPCustomerTypes;
        
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
        public SPProducts SPProducts
        {
            get
            {
                if (oSPProducts == null)
                {
                    oSPProducts = new SPProducts();
                }
                return oSPProducts;
            }
        }
        public Showrooms Showrooms
        {
            get
            {
                if (oShowrooms == null)
                {
                    oShowrooms = new Showrooms();
                }
                return oShowrooms;
            }
        }
        public ProductGroups ProductGroups
        {
            get
            {
                if (oProductGroups == null)
                {
                    oProductGroups = new ProductGroups();
                }
                return oProductGroups;
            }
        }
        public SPProductGroups SPProductGroups
        {
            get
            {
                if (oSPProductGroups == null)
                {
                    oSPProductGroups = new SPProductGroups();
                }
                return oSPProductGroups;
            }
        }
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
        public SPCustomerTypes SPCustomerTypes
        {
            get
            {
                if (oSPCustomerTypes == null)
                {
                    oSPCustomerTypes = new SPCustomerTypes();
                }
                return oSPCustomerTypes;
            }
        }
        private SalesPromotionDetails oSalesPromotionDetails;
        public SalesPromotionDetails SalesPromotionDetails
        {
            get
            {
                if (oSalesPromotionDetails == null)
                {
                    oSalesPromotionDetails = new SalesPromotionDetails();
                }
                return oSalesPromotionDetails;
            }
        }

        private SalesPromotionCustTypes oSalesPromotionCustTypes;
        public SalesPromotionCustTypes SalesPromotionCustTypes
        {
            get
            {
                if (oSalesPromotionCustTypes == null)
                {
                    oSalesPromotionCustTypes = new SalesPromotionCustTypes();
                }
                return oSalesPromotionCustTypes;
            }
        }

        private SalesPromotionMarketGroups oSalesPromotionMarketGroups;
        public SalesPromotionMarketGroups SalesPromotionMarketGroups
        {
            get
            {
                if (oSalesPromotionMarketGroups == null)
                {
                    oSalesPromotionMarketGroups = new SalesPromotionMarketGroups();
                }
                return oSalesPromotionMarketGroups;
            }
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
        /// Get set property for SalesPromotionNo
        /// </summary>
        public int SalesPromotionNo
        {
            get { return _nSalesPromotionNo; }
            set { _nSalesPromotionNo = value; }
        }

        /// <summary>
        /// Get set property for SalesPromotionName
        /// </summary>
        public string SalesPromotionName
        {
            get { return _sSalesPromotionName; }
            set { _sSalesPromotionName = value.Trim(); }
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
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        /// <summary>
        /// Get set property for FromDate
        /// </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        /// <summary>
        /// Get set property for ToDate
        /// </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        /// <summary>
        /// Get set property for EntryUserID
        /// </summary>
        public int EntryUserID
        {
            get { return _nEntryUserID; }
            set { _nEntryUserID = value; }
        }

        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        /// <summary>
        /// Get set property for UploadDate
        /// </summary>
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }

        /// <summary>
        /// Get set property for UploadStatus
        /// </summary>
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }
        }

        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }

        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }
        }

        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }

        /// <summary>
        /// Get set property for InvoiceDiscountPercentage
        /// </summary>
        public double InvoiceDiscountPercentage
        {
            get { return _InvoiceDiscountPercentage; }
            set { _InvoiceDiscountPercentage = value; }
        }

        public int TransferType
        {
            get { return _nTransferType; }
            set { _nTransferType = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        private int _DiscountType;
        public int DiscountType
        {
            get { return _DiscountType; }
            set { _DiscountType = value; }
        
        }

        private double _DiscountPercent;
        public double DiscountPercent
        {
            get { return _DiscountPercent; }
            set { _DiscountPercent = value; }

        }
        private int _nForQty;
        public int ForQty
        {
            get { return _nForQty; }
            set { _nForQty = value; }

        }

        public void Insert()
        {
            int nMaxSPID = 0;
            int nMaxSPNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SalesPromotionID]) FROM t_SalesPromo";
                cmd.CommandText = sSql;
                object maxSPID = cmd.ExecuteScalar();
                if (maxSPID == DBNull.Value)
                {
                    nMaxSPID = 1;
                }
                else
                {
                    nMaxSPID = Convert.ToInt32(maxSPID) + 1;
                }
                _nSalesPromotionID = nMaxSPID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([SalesPromotionNo]) FROM t_SalesPromo";
                cmd.CommandText = sSql;
                object maxSPNo = cmd.ExecuteScalar();
                if (maxSPNo == DBNull.Value)
                {
                    nMaxSPNo = 1;
                }
                else
                {
                    nMaxSPNo = Convert.ToInt32(maxSPNo) + 1;
                }
                _nSalesPromotionNo = nMaxSPNo;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_SalesPromo VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SalesPromotionNo", _nSalesPromotionNo);
                cmd.Parameters.AddWithValue("SalesPromotionName", _sSalesPromotionName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("EntryUserID", _nEntryUserID);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (int)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("Remarks", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (oSPProducts != null)
                {
                    foreach (SPProduct oSPProduct in oSPProducts)
                    {
                        oSPProduct.SalesPromotionID = _nSalesPromotionID;
                        oSPProduct.Insert();
                    }
                }
                if (oSPChannels != null)
                {
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nSalesPromotionID;
                        oSPChannel.Insert();
                    }
                }
                if (oSPWarehouses != null)
                {
                    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                    {
                        oSPWarehouse.SalesPromotionID = _nSalesPromotionID;
                        oSPWarehouse.Insert();
                    }
                }
                if (oSPTypes != null)
                {
                    foreach (SPType oSPType in oSPTypes)
                    {
                        oSPType.SalesPromotionID = _nSalesPromotionID;
                        oSPType.Insert();
                    }
                }
                if (oSPCustomerTypes != null)
                {
                    foreach (SPCustomerType oSPCustomerType in oSPCustomerTypes)
                    {
                        oSPCustomerType.SalesPromotionID = _nSalesPromotionID;
                        oSPCustomerType.Insert();
                    }
                }
                if (_nForQty > 0)
                {
                    SPForQty oSPForQty = new SPForQty();
                    oSPForQty.SalesPromotionID = _nSalesPromotionID;
                    oSPForQty.Qty = _nForQty;
                    oSPForQty.Insert();
                }
                foreach (SalesPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.SalesPromotionID = _nSalesPromotionID;
                    oSalesPromotionSlab.Insert();
                }
                if (oShowrooms != null)
                {
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        SPWarehouse oSPWarehouse = new SPWarehouse();
                        oSPWarehouse.SalesPromotionID = _nSalesPromotionID;
                        oSPWarehouse.WarehouseID = oShowroom.WarehouseID;
                        oSPWarehouse.Insert();
                    }
                }
                if (oProductGroups != null)
                {
                    foreach (ProductGroup oProductGroup in oProductGroups)
                    {
                        SPProductGroup oSPProductGroup = new SPProductGroup();
                        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
                        oSPProductGroup.ProductGroupType = oProductGroup.PdtGroupType;
                        oSPProductGroup.ProductGroupID = oProductGroup.PdtGroupID;
                        oSPProductGroup.DiscountType = _DiscountType;
                        oSPProductGroup.DiscountPercentage = _DiscountPercent;
                        oSPProductGroup.Insert();
                    }
                }

                Showrooms _oShowrooms = new Showrooms();
                _oShowrooms.Refresh();

                foreach (Showroom oShowroom in _oShowrooms)
                {
                    DataTran oDataTran = new DataTran();

                    oDataTran.TableName = "t_SalesPromo";
                    oDataTran.DataID = _nSalesPromotionID;
                    oDataTran.WarehouseID = oShowroom.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    oDataTran.AddForTDPOS();
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

            try
            {
                cmd.CommandText = "UPDATE t_SalesPromo SET SalesPromotionName=?,FromDate=?,ToDate=?,UpdateUserID=?,UpdateDate=?, IsActive=? "
                                  + " WHERE SalesPromotionID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionName", _sSalesPromotionName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
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
                sSql = "Update t_SalesPromo set IsActive= ?,UpdateUserID = ?, UpdateDate = ? WHERE SalesPromotionID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesPromo SET SalesPromotionName=?,FromDate=?,ToDate=?,UpdateUserID=?,UpdateDate=? "
                                  + " WHERE SalesPromotionID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionName", _sSalesPromotionName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);

                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                
                if (oSPProducts != null)
                {
                    _nCount = 0;
                    foreach (SPProduct oSPProduct in oSPProducts)
                    {
                        oSPProduct.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPProduct.Delete();
                        oSPProduct.Insert();
                        _nCount++;
                    }
                }
                if (oSPChannels != null)
                {
                    _nCount = 0;
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPChannel.Delete();
                        oSPChannel.Insert();
                        _nCount++;
                    }
                }
                if (oSPWarehouses != null)
                {
                    _nCount = 0;
                    foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                    {
                        oSPWarehouse.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPWarehouse.Delete();
                        oSPWarehouse.Insert();
                        _nCount++;
                    }
                }
                foreach (SalesPromotionSlab oSalesPromotionSlab in this)
                {                  
                    oSalesPromotionSlab.SalesPromotionID = _nSalesPromotionID;
                    oSalesPromotionSlab.DeleteDetail();
                   
                }
                _nCount = 0;
                foreach (SalesPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.SalesPromotionID = _nSalesPromotionID;
                    
                    if (_nCount == 0)

                        oSalesPromotionSlab.Delete();                              
                  oSalesPromotionSlab.Insert();
                  _nCount++;
                }
                if (oSPProductGroups != null)
                {
                    _nCount = 0;
                    foreach (SPProductGroup oSPProductGroup in oSPProductGroups)
                    {
                        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPProductGroup.Delete();
                        oSPProductGroup.Insert();
                        _nCount++;
                    }
                }
                if (oSPCustomerTypes != null)
                {
                    _nCount = 0;
                    foreach (SPCustomerType oSPCustomerType in oSPCustomerTypes)
                    {
                        oSPCustomerType.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPCustomerType.Delete();
                        oSPCustomerType.Insert();
                        _nCount++;
                    }
                }

                SPForQty oSPForQty = new SPForQty();
                oSPForQty.SalesPromotionID = _nSalesPromotionID;
                oSPForQty.Qty = _nForQty;
                oSPForQty.Update();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCentral()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SalesPromo SET SalesPromotionName=?,FromDate=?,ToDate=?,UpdateUserID=?,UpdateDate=? "
                                  + " WHERE SalesPromotionID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionName", _sSalesPromotionName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);

                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                SPromotion oSP = new SPromotion();
                if (oSPChannels != null)
                {
                    _nCount = 0;
                    foreach (SPChannel oSPChannel in oSPChannels)
                    {
                        oSPChannel.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPChannel.Delete();
                        oSPChannel.Insert();
                        _nCount++;
                    }
                }

                _nCount = 0;
                foreach (SalesPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.SalesPromotionID = _nSalesPromotionID;

                    SPFreeProduct oSPFP = new SPFreeProduct();
                    if (_nCount == 0)
                    {
                        oSPFP.CPSID = oSP.GetCPSID(_nSalesPromotionID);
                        oSPFP.Delete();
                        _nCount++;
                    }
                    foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
                    {
                        oSPFP.ProductID = oSPFreeProduct.ProductID;
                        oSPFP.Qty = oSPFreeProduct.Qty;
                        oSPFP.Insert();
                    }

                }
                if (this.ProductGroups != null)
                {
                    _nCount = 0;
                    foreach (ProductGroup oProductGroup in this.ProductGroups)
                    {
                        SPProductGroup oSPProductGroup = new SPProductGroup();
                        oSPProductGroup.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPProductGroup.Delete();

                        oSPProductGroup.DiscountType = _DiscountType;
                        oSPProductGroup.DiscountPercentage = _DiscountPercent;
                        oSPProductGroup.ProductGroupType = oProductGroup.PdtGroupType;
                        oSPProductGroup.ProductGroupID = oProductGroup.PdtGroupID;
                        oSPProductGroup.Insert();
                        _nCount++;
                    }
                }
                if (oSPCustomerTypes != null)
                {
                    _nCount = 0;
                    foreach (SPCustomerType oSPCustomerType in oSPCustomerTypes)
                    {
                        oSPCustomerType.SalesPromotionID = _nSalesPromotionID;
                        if (_nCount == 0)
                            oSPCustomerType.Delete();
                        oSPCustomerType.Insert();
                        _nCount++;
                    }
                }

                SPForQty oSPForQty = new SPForQty();
                oSPForQty.SalesPromotionID = _nSalesPromotionID;
                oSPForQty.Qty = _nForQty;
                oSPForQty.Update();
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


                _nCount = 0;
                foreach (SPProduct oSPProduct in oSPProducts)
                {
                    oSPProduct.SalesPromotionID = _nSalesPromotionID;
                    if (_nCount == 0)
                        oSPProduct.Delete();
                    _nCount++;
                }
                _nCount = 0;
                foreach (SPChannel oSPChannel in oSPChannels)
                {
                    oSPChannel.SalesPromotionID = _nSalesPromotionID;
                    if (_nCount == 0)
                        oSPChannel.Delete();
                    _nCount++;
                }
                _nCount = 0;
                foreach (SPWarehouse oSPWarehouse in oSPWarehouses)
                {
                    oSPWarehouse.SalesPromotionID = _nSalesPromotionID;
                    if (_nCount == 0)
                        oSPWarehouse.Delete();
                    _nCount++;
                }
                foreach (SalesPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.SalesPromotionID = _nSalesPromotionID;
                    oSalesPromotionSlab.DeleteDetail();

                }
                _nCount = 0;
                foreach (SalesPromotionSlab oSalesPromotionSlab in this)
                {
                    oSalesPromotionSlab.SalesPromotionID = _nSalesPromotionID;
                    if (_nCount == 0)
                        oSalesPromotionSlab.Delete();
                    _nCount++;
                }

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesPromo";
                oDataTran.DataID = _nSalesPromotionID;
                oDataTran.Delete();

                sSql = "DELETE FROM t_SalesPromo WHERE SalesPromotionID=? ";
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


        public void RefreshSlab()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoSlab where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SalesPromotionSlab oSalesPromotionSlab = new SalesPromotionSlab();

                    oSalesPromotionSlab.CPSID = int.Parse(reader["CPSID"].ToString());
                    oSalesPromotionSlab.SlabNo = int.Parse(reader["SlabNo"].ToString());
                    oSalesPromotionSlab.SlabName = (reader["SlabName"].ToString());
                    oSalesPromotionSlab.IsActive = int.Parse(reader["IsActive"].ToString());
                    oSalesPromotionSlab.DiscountType = int.Parse(reader["DiscountType"].ToString());
                    oSalesPromotionSlab.Discount = Convert.ToDouble(reader["Discount"].ToString());

                    oSalesPromotionSlab.SPFreeProducts.Refresh(oSalesPromotionSlab.CPSID, oSalesPromotionSlab.SlabNo);
                    oSalesPromotionSlab.SPSlabAllRatio.Refresh(oSalesPromotionSlab.CPSID);

                    InnerList.Add(oSalesPromotionSlab);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetCPSID(int nSalesPromotionID)
        {
            int nCPSID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoSlab where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nCPSID = int.Parse(reader["CPSID"].ToString());
                    
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return nCPSID;
        }

    }
    public class SPromotions : CollectionBase
    {
        public SPromotion this[int i]
        {
            get { return (SPromotion)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPromotion oSPromotion)
        {
            InnerList.Add(oSPromotion);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "SELECT *  FROM t_SalesPromo " +
                          " WHERE CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' ";
         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString(); 
                    oSPromotion.SalesPromotionNo = int.Parse(reader["SalesPromotionNo"].ToString());
                    oSPromotion.FromDate = Convert.ToDateTime(reader["FromDate"]);
                    oSPromotion.ToDate = Convert.ToDateTime(reader["ToDate"]);
                    oSPromotion.IsActive = int.Parse(reader["IsActive"].ToString());

                    oSPromotion.SPChannels.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPProducts.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPWarehouses.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPCustomerTypes.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.RefreshSlab();

                    InnerList.Add(oSPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromotionByActive(DateTime dDate, int nSPTypeID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            //string sSql = "SELECT *  FROM t_SalesPromo " +
            //              " WHERE FromDate <= '" + dDate + "' and  ToDate >= '" + dDate + "' and IsActive=1";
            string sSql ="";
            sSql = "SELECT a.*  FROM t_SalesPromo a, t_SalesPromoType b WHERE '" + dDate + "' between " +
            "FromDate and  ToDate and a.SalesPromotionID=b.SalesPromotionID ";

            if (nSPTypeID != -1)
            {
                sSql = sSql + " and IsActive=1 and b.SalesPromotionTypeID=" + nSPTypeID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();
                    oSPromotion.SalesPromotionNo = int.Parse(reader["SalesPromotionNo"].ToString());
                    oSPromotion.FromDate = Convert.ToDateTime(reader["FromDate"]);
                    oSPromotion.ToDate = Convert.ToDateTime(reader["ToDate"]);

                    oSPromotion.SPChannels.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPProducts.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPWarehouses.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPProductGroups.Refresh(oSPromotion.SalesPromotionID);

                    oSPromotion.RefreshSlab();

                    InnerList.Add(oSPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetPromotion(DateTime dDate)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "SELECT *  FROM t_SalesPromo WHERE '" + dDate + "' between " +
            "FromDate and  ToDate and IsActive=1 ";

            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();
                    oSPromotion.SalesPromotionNo = int.Parse(reader["SalesPromotionNo"].ToString());
                    oSPromotion.FromDate = Convert.ToDateTime(reader["FromDate"]);
                    oSPromotion.ToDate = Convert.ToDateTime(reader["ToDate"]);

                    oSPromotion.SPChannels.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPProducts.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPWarehouses.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPProductGroups.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SPCustomerTypes.Refresh(oSPromotion.SalesPromotionID);

                    oSPromotion.RefreshSlab();

                    InnerList.Add(oSPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshAll(int nWarehouseID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
       
            string sSql = "SELECT *  FROM t_SalesPromo a inner join t_DataTransfer b on b.DataID=a.SalesPromotionID "
                        +" Where TableName = ? and  IsDownload = ? and WarehouseID = ? ";

            cmd.Parameters.AddWithValue("TableName", "t_SalesPromo");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();
                    oSPromotion.SalesPromotionNo = int.Parse(reader["SalesPromotionNo"].ToString());
                    oSPromotion.FromDate = Convert.ToDateTime(reader["FromDate"]);
                    oSPromotion.ToDate = Convert.ToDateTime(reader["ToDate"]);
                    oSPromotion.IsActive = Convert.ToInt32(reader["IsActive"]);
                    oSPromotion.TransferType = int.Parse(reader["TransferType"].ToString());

                    if (oSPromotion.TransferType == (int)Dictionary.DataTransferType.Add)
                    {
                        oSPromotion.SPChannels.Refresh(oSPromotion.SalesPromotionID);
                        oSPromotion.SPProducts.Refresh(oSPromotion.SalesPromotionID);
                        oSPromotion.SPWarehouses.Refresh(oSPromotion.SalesPromotionID);
                        oSPromotion.SPProductGroups.Refresh(oSPromotion.SalesPromotionID);
                        oSPromotion.SPTypes.Refresh(oSPromotion.SalesPromotionID);

                        oSPromotion.RefreshSlab();
                    }
                    InnerList.Add(oSPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshAllOtherThenTD(int nWarehouseID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_SalesPromotion a inner join t_DataTransfer b on b.DataID=a.SalesPromotionID "
                        + " Where TableName= ? and  IsDownload= ? and WarehouseID= ? ";

            cmd.Parameters.AddWithValue("TableName", "t_SalesPromotion");
            cmd.Parameters.AddWithValue("IsDownload", 1);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();
                    oSPromotion.SalesPromotionNo = int.Parse(reader["SalesPromotionNo"].ToString());
                    oSPromotion.FromDate = Convert.ToDateTime(reader["FromDate"]);
                    oSPromotion.ToDate = Convert.ToDateTime(reader["ToDate"]);
                    oSPromotion.IsActive = Convert.ToInt32(reader["IsActive"]);
                    oSPromotion.TransferType = int.Parse(reader["TransferType"].ToString());

                    oSPromotion.SalesPromotionDetails.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SalesPromotionCustTypes.Refresh(oSPromotion.SalesPromotionID);
                    oSPromotion.SalesPromotionMarketGroups.Refresh(oSPromotion.SalesPromotionID);

                    InnerList.Add(oSPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetSalesInvoiceSalesPromotion(int nInvoiceID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_SalesInvoicePromo " +
                          " WHERE InvoiceID=? ";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oSPromotion.SalesPromotionID = int.Parse(reader["PromotionID"].ToString());
                    oSPromotion.WarehouseID = (int)reader["WarehouseID"];                  
                  
                    InnerList.Add(oSPromotion);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetAllPromotiom()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();          
            string sSql = "SELECT *  FROM t_SalesPromotion ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();
                 
                    InnerList.Add(oSPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetPromotiom()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT *  FROM t_SalesPromo ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPromotion oSPromotion = new SPromotion();

                    oSPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();

                    InnerList.Add(oSPromotion);
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
    public class SalesPromotionDetail
    {
        private int _nSalesPromotionID;
        private int _nProductID;
        private int _nSalesQty;
        private int _nFreeProductID;
        private int _nFreeQty;
        private double _Discount;

        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        public int FreeProductID
        {
            get { return _nFreeProductID; }
            set { _nFreeProductID = value; }
        }
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

    }
    public class SalesPromotionDetails : CollectionBase
    {
        public SalesPromotionDetail this[int i]
        {
            get { return (SalesPromotionDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesPromotionDetail oSalesPromotionDetail)
        {
            InnerList.Add(oSalesPromotionDetail);
        }

        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Salespromotiondetail where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SalesPromotionDetail oSalesPromotionDetail = new SalesPromotionDetail();
                    oSalesPromotionDetail.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSalesPromotionDetail.ProductID = int.Parse(reader["ProductID"].ToString());
                    oSalesPromotionDetail.SalesQty = int.Parse(reader["SalesQty"].ToString());
                    oSalesPromotionDetail.FreeProductID = int.Parse(reader["FreeProductID"].ToString());
                    oSalesPromotionDetail.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    oSalesPromotionDetail.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    InnerList.Add(oSalesPromotionDetail);
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
    public class SalesPromotionCustType
    {
        private int _nSalesPromotionID;
        private int _nCustTypeID;

        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        /// <summary>
        /// Get set property for CustTypeID
        /// </summary>
        public int CustTypeID
        {
            get { return _nCustTypeID; }
            set { _nCustTypeID = value; }
        }

    }
    public class SalesPromotionCustTypes : CollectionBase
    {
        public SalesPromotionCustType this[int i]
        {
            get { return (SalesPromotionCustType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesPromotionCustType oSalesPromotionCustType)
        {
            InnerList.Add(oSalesPromotionCustType);
        }
        
        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_SalesPromotionCustomerType Where SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionCustType oSPCT = new SalesPromotionCustType();

                    oSPCT.SalesPromotionID = (int)reader["SalesPromotionID"];
                    oSPCT.CustTypeID = (int)reader["CustTypeID"];

                    InnerList.Add(oSPCT);
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
    public class SalesPromotionMarketGroup
    {
        private int _nSalesPromotionID;
        private int _nMarketGroupID;

        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        /// <summary>
        /// Get set property for MarketGroupID
        /// </summary>
        public int MarketGroupID
        {
            get { return _nMarketGroupID; }
            set { _nMarketGroupID = value; }
        }

    }
    public class SalesPromotionMarketGroups : CollectionBase
    {
        public SalesPromotionMarketGroup this[int i]
        {
            get { return (SalesPromotionMarketGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesPromotionMarketGroup oSalesPromotionMarketGroup)
        {
            InnerList.Add(oSalesPromotionMarketGroup);
        }

        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_SalesPromotionMarketGroup Where SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionMarketGroup oSPMG = new SalesPromotionMarketGroup();

                    oSPMG.SalesPromotionID = (int)reader["SalesPromotionID"];
                    oSPMG.MarketGroupID = (int)reader["MarketGroupID"];

                    InnerList.Add(oSPMG);
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
