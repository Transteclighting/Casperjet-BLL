// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 03, 2011
// Time :  02:00 PM
// Description: Class for Sales Promotion.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class
{
    public class SalesPromotion
    {
        private int _nSalesPromotionID;
        private int _nSalesPromotionNo;
        private string _sSalesPromotionName;
        private object _CreateDate;
        private object _UpdateDate;
        private object _FromDate;
        private object _ToDate;
        private int _nEntryUserID;
        private int _nUpdateUserID;
        private int _nIsActive;
        private object _UploadDate;
        private object _UploadStatus;
        private object _DownloadDate;
        private object _RowStatus;
        private object _Terminal;
        private object _InvoiceDiscountPercentage;
        private string _sRemarks;

        private double _Discount;


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
        public object CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public object UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        /// <summary>
        /// Get set property for FromDate
        /// </summary>
        public object FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        /// <summary>
        /// Get set property for ToDate
        /// </summary>
        public object ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
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
        public object UploadDate
        {
            get { return _UploadDate; }
            set { _UploadDate = value; }
        }
        /// <summary>
        /// Get set property for UploadStatus
        /// </summary>
        public object UploadStatus
        {
            get { return _UploadStatus; }
            set { _UploadStatus = value; }
        }
        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public object DownloadDate
        {
            get { return _DownloadDate; }
            set { _DownloadDate = value; }
        }
        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public object RowStatus
        {
            get { return _RowStatus; }
            set { _RowStatus = value; }
        }
        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public object Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }
        /// <summary>
        /// Get set property for InvoiceDiscountPercentage
        /// </summary>
        public object InvoiceDiscountPercentage
        {
            get { return _InvoiceDiscountPercentage; }
            set { _InvoiceDiscountPercentage = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for _Discount
        /// </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        public void Refresh(int nCustomerId)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select  " +
                        "final.salespromotionid, final.salespromotionname, final.createdate, final.fromdate, final.todate,   " +
                        "final.userid,  final.entryusername, final.updateuserid, final.updateusername,    " +
                        "final.isactive, final.remarks, final.customertypename, final.territoryname    " +
                        "from     " +
                        "(  " +
                        "select   " +
                        "a.salespromotionid, a.salespromotionname, a.createdate, a.fromdate, a.todate,   " +
                        "c.userid,  c.username as entryusername, a.updateuserid, c.username as updateusername,    " +
                        "a.isactive, a.remarks, f.customertypename, f.territoryname, f.customerid            " +
                        "from t_salespromotion a       " +
                        "inner join t_salespromotiondetail b  on a.salespromotionid = b.salespromotionid        " +
                        "inner join t_user c on a.entryuserid = c.userid    " +
                        "left outer join  t_SalesPromotionCustomerType d on  a.salespromotionid = d.salespromotionid    " +
                        "left outer join  t_SalesPromotionMarketGroup  e on  a.salespromotionid = e.salespromotionid    " +
                        "left outer join  v_customerdetails  f on d.custtypeid = f.customertypeid   " +
                        "and e.marketgroupid = f.territoryid      " +
                        "group by   " +
                        "a.salespromotionid, a.salespromotionname, a.createdate, a.fromdate,   " +
                        "a.todate, c.userid,  c.username, a.updateuserid, f.customerid,   " +
                        "c.username,  a.isactive, a.remarks, f.customertypename, f.territoryname   " +
                        ") as final  " +
                        "where  final.fromdate <= '" + DateTime.Today.Date + "' " +
                        "and todate >= '" + DateTime.Today.Date + "' and final.isactive = 1 and final.customerid='" + nCustomerId + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                 _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                 _sSalesPromotionName = reader["SalesPromotionName"].ToString();

                 nCount++;
                }
                reader.Close();               

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (nCount == 0) _nSalesPromotionID = -1;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByCustomerIDandProductID(int nCustomerID, int nProductID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select  " +
                        "final.salespromotionid, final.ProductID, final.Discount, final.salespromotionname, final.createdate, final.fromdate, final.todate,   " +
                        "final.userid,  final.entryusername, final.updateuserid, final.updateusername,    " +
                        "final.isactive, final.remarks, final.customertypename, final.territoryname    " +
                        "from     " +
                        "(  " +
                        "select   " +
                        "a.salespromotionid, b.ProductID, b.Discount, a.salespromotionname, a.createdate, a.fromdate, a.todate,   " +
                        "c.userid,  c.username as entryusername, a.updateuserid, c.username as updateusername,    " +
                        "a.isactive, a.remarks, f.customertypename, f.territoryname, f.customerid            " +
                        "from t_salespromotion a       " +
                        "inner join t_salespromotiondetail b  on a.salespromotionid = b.salespromotionid        " +
                        "inner join t_user c on a.entryuserid = c.userid    " +
                        "left outer join  t_SalesPromotionCustomerType d on  a.salespromotionid = d.salespromotionid    " +
                        "left outer join  t_SalesPromotionMarketGroup  e on  a.salespromotionid = e.salespromotionid    " +
                        "left outer join  v_customerdetails  f on d.custtypeid = f.customertypeid   " +
                        "and e.marketgroupid = f.territoryid      " +
                        "group by   " +
                        "a.salespromotionid,  b.ProductID, b.Discount, a.salespromotionname, a.createdate, a.fromdate,   " +
                        "a.todate, c.userid,  c.username, a.updateuserid, f.customerid,   " +
                        "c.username,  a.isactive, a.remarks, f.customertypename, f.territoryname   " +
                        ") as final  " +
                        "where  final.fromdate <= '" + DateTime.Today.Date + "' " +
                        "and todate >= '" + DateTime.Today.Date + "' and final.isactive = 1 and final.CustomerID=? and final.ProductID=?";

                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    _sSalesPromotionName = reader["SalesPromotionName"].ToString();
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());

                    nCount++;
                }
                reader.Close();

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (nCount == 0) _nSalesPromotionID = -1;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByCustomerIDandProductIDPOS(int nCustomerID, int nProductID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select  final.salespromotionid, final.ProductID, final.Discount, final.salespromotionname, "+
                                    "final.fromdate, final.todate,    "+
                                    "final.isactive, final.customertypename, final.territoryname    "+
                                    "from (select   "+
                                    "a.salespromotionid, b.ProductID, b.Discount, a.salespromotionname,  a.fromdate, a.todate,    "+
                                    "a.isactive,  f.customertypename, f.territoryname, f.customerid      "+      
                                    "from t_salespromotion a       "+
                                    "inner join t_salespromotiondetail b  on a.salespromotionid = b.salespromotionid    "+      
                                    "left outer join  t_SalesPromotionCustomerType d on  a.salespromotionid = d.salespromotionid   "+ 
                                    "left outer join  t_SalesPromotionMarketGroup  e on  a.salespromotionid = e.salespromotionid   "+ 
                                    "left outer join  v_customerdetails  f on d.custtypeid = f.customertypeid   "+
                                    "and e.marketgroupid = f.territoryid    "+  
                                    "group by   "+
                                    "a.salespromotionid,  b.ProductID, b.Discount, a.salespromotionname,  a.fromdate,   "+
                                    "a.todate,  f.customerid,   "+
                                    "a.isactive,  f.customertypename, f.territoryname   "+
                                    ") as final  " +
                                    "where  final.fromdate <= '" + DateTime.Today.Date + "' " +
                                    "and todate >= '" + DateTime.Today.Date + "' and final.isactive = 1 and final.CustomerID=? and final.ProductID=?";

                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    _sSalesPromotionName = reader["SalesPromotionName"].ToString();
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());

                    nCount++;
                }
                reader.Close();

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (nCount == 0) _nSalesPromotionID = -1;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public int GetNosOfHOPromo()
        {
            int nPromoCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select Count(SalesPromotionID) as CountPromo from t_SalesPromo";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nPromoCount = int.Parse(reader["CountPromo"].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return nPromoCount;

        }
    }
    public class SalesPromotions : CollectionBase
    {
        public SalesPromotion this[int i]
        {
            get { return (SalesPromotion)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesPromotion oSalesPromotion)
        {
            InnerList.Add(oSalesPromotion);
        }
        public int GetIndex(int nSalesPromotionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SalesPromotionID == nSalesPromotionID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshForSalesOrder(int nCustomerId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            try
            {
                cmd.CommandText = "select  " +
                        "final.salespromotionid, final.salespromotionname, final.createdate, final.fromdate, final.todate,   " +
                        "final.userid,  final.entryusername, final.updateuserid, final.updateusername,    " +
                        "final.isactive, final.remarks, final.customertypename, final.territoryname    " +
                        "from     " +
                        "(  " +
                        "select   " +
                        "a.salespromotionid, a.salespromotionname, a.createdate, a.fromdate, a.todate,   " +
                        "c.userid,  c.username as entryusername, a.updateuserid, c.username as updateusername,    " +
                        "a.isactive, a.remarks, f.customertypename, f.territoryname, f.customerid            " +
                        "from t_salespromotion a       " +
                        "inner join t_salespromotiondetail b  on a.salespromotionid = b.salespromotionid        " +
                        "inner join t_user c on a.entryuserid = c.userid    " +
                        "left outer join  t_SalesPromotionCustomerType d on  a.salespromotionid = d.salespromotionid    " +
                        "left outer join  t_SalesPromotionMarketGroup  e on  a.salespromotionid = e.salespromotionid    " +
                        "left outer join  v_customerdetails  f on d.custtypeid = f.customertypeid   " +
                        "and e.marketgroupid = f.territoryid      " +
                        "group by   " +
                        "a.salespromotionid, a.salespromotionname, a.createdate, a.fromdate,   " +
                        "a.todate, c.userid,  c.username, a.updateuserid, f.customerid,   " +
                        "c.username,  a.isactive, a.remarks, f.customertypename, f.territoryname   " +
                        ") as final  " +
                        "where  final.fromdate <= '" + DateTime.Today.Date + "' " +
                        "and todate >= '" + DateTime.Today.Date + "' and final.isactive = 1 and final.customerid='" + nCustomerId + "'";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    SalesPromotion oSalesPromotion = new SalesPromotion();
                    oSalesPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSalesPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();
                   
                    InnerList.Add(oSalesPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public void RefreshForSalesOrderPOS(int nCustomerId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select  final.salespromotionid, final.salespromotionname,  final.fromdate, final.todate, " +
                                "final.isactive, final.customertypename, final.territoryname " +
                                "from  " +
                                "(  " +
                                "select " +
                                "a.salespromotionid, a.salespromotionname,  a.fromdate, a.todate, " +
                                "a.isactive, f.customertypename, f.territoryname, f.customerid " +
                                "from t_salespromotion a " +
                                "inner join t_salespromotiondetail b  on a.salespromotionid = b.salespromotionid " +
                                "left outer join  t_SalesPromotionCustomerType d on  a.salespromotionid = d.salespromotionid " +
                                "left outer join  t_SalesPromotionMarketGroup  e on  a.salespromotionid = e.salespromotionid " +
                                "left outer join  v_customerdetails  f on d.custtypeid = f.customertypeid " +
                                "and e.marketgroupid = f.territoryid " +
                                "group by " +
                                "a.salespromotionid, a.salespromotionname,  a.fromdate, " +
                                "a.todate, f.customerid, a.isactive, f.customertypename, f.territoryname " +
                                ") as final   " +
                                "where  final.fromdate <= '" + DateTime.Today.Date + "' " +
                                "and todate >= '" + DateTime.Today.Date + "' and final.isactive = 1 and final.customerid='" + nCustomerId + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    SalesPromotion oSalesPromotion = new SalesPromotion();
                    oSalesPromotion.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    oSalesPromotion.SalesPromotionName = reader["SalesPromotionName"].ToString();

                    InnerList.Add(oSalesPromotion);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
